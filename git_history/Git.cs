using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace git_history
{
    public class Git
    {
        public static void parseLog(DBDataContext db, string projectPath, int projectId)
        {
            var filePath = projectPath + @"\" + Download.NUMSTAT_FILE_NAME;

            Regex regex_merge = new Regex(@"Merge: ([^ ]+) ([^ ]+)$");
            Regex regex_author = new Regex(@"Author: ([^<]+)<([^>]+)>");
            Regex regex_numstat = new Regex(@"([-0-9]+)\t([-0-9]+)\t(.+)$");
            Regex regex_rename1 = new Regex(@"^(.*){(.*) => (.*)}(.*)$");
            Regex regex_rename2 = new Regex(@"(.*) => (.*)$");
            var a = CultureInfo.InvariantCulture;

            using (var reader = new StreamReader(filePath))
            {
                string s;
                while ((s = reader.ReadLine()) != null)
                {
                restart:
                    if (s.StartsWith("commit") == false) 
                        continue;
                    
                    var commitNo = s.Split(' ')[1];
                    if (db.Commit.Any(p => p.commitNo == commitNo))
                        continue;

                    // commit
                    var commit = new Commit { commitNo = s.Split(' ')[1] };
                    s = reader.ReadLine();
                    var match = regex_merge.Match(s);
                    if (match.Success)
                    {
                        commit.merge1 = match.Groups[1].Value;
                        commit.merge2 = match.Groups[1].Value;
                        s = reader.ReadLine();
                    }

                    // author
                    match = regex_author.Match(s);
                    if (match.Success == false)
                    {
                        if (s.StartsWith("Merge:"))
                        {
                            while (true)
                            {
                                s = reader.ReadLine();
                                if (s.StartsWith("commit")) goto restart;
                            }
                        }
                        else
                            throw new Exception("실패");
                    }
                    string email = match.Groups[2].Value.Trim();
                    var author = db.Author.FirstOrDefault(p => p.이메일 == email);
                    if (author == null)
                    {
                        author = new Author { 이메일 = email, 계정 = match.Groups[1].Value.Trim() };
                        db.Author.InsertOnSubmit(author);
                        db.SubmitChanges();
                    }

                    // date
                    s = reader.ReadLine();
                    var d = DateTime.ParseExact(s.Substring(5).Trim(), "ddd MMM d HH:mm:ss yyyy K", CultureInfo.InvariantCulture);
                    commit.시각 = d;

                    // comment
                    reader.ReadLine();
                    var builder = new StringBuilder();
                    var numstat를먼저읽음 = false;
                    for (; ; )
                    {
                        s = reader.ReadLine();
                        if (s[0] != ' ')
                        {
                            numstat를먼저읽음 = true; // 주석이 없고 바로 numstat
                            break;
                        }
                        if (s.Length == 0) break;
                        builder.Append(s.Trim()).Append('\n');
                    }
                    if (numstat를먼저읽음 == false) commit.메모 = builder.ToString();
                    commit.projectId = projectId;
                    commit.authorId = author.id;
                    db.Commit.InsertOnSubmit(commit);
                    db.SubmitChanges();

                    // numstat
                    for (; ; )
                    {
                        if (numstat를먼저읽음) numstat를먼저읽음 = false;
                        else s = reader.ReadLine();

                        if (s == null || s.Length == 0) break;
                        if (s.StartsWith("commit")) goto restart;

                        match = regex_numstat.Match(s);
                        if (match.Success == false) throw new Exception("실패");

                        string path1, path2 = null;
                        path1 = match.Groups[3].Value;
                        if (path1.Contains("node_modules")) continue;

                        var numstat = new Numstat();
                        numstat.추가된줄수 = int.Parse(match.Groups[1].Value.Replace("-", "0"));
                        numstat.삭제된줄수 = int.Parse(match.Groups[2].Value.Replace("-", "0"));

                        if (path1.Contains("=>"))
                        {
                            match = regex_rename1.Match(path1);
                            if (match.Success)
                            {
                                path1 = match.Groups[1].Value + match.Groups[3].Value + match.Groups[4].Value;
                                path2 = match.Groups[1].Value + match.Groups[2].Value + match.Groups[4].Value;
                            }
                            else
                            {
                                match = regex_rename2.Match(path1);
                                if (match.Success == false) throw new Exception("실패");
                                path1 = match.Groups[1].Value;
                                path2 = match.Groups[2].Value;
                            }
                        }
                        var sourceFile = db.SourceFile.FirstOrDefault(p => p.projectId == projectId && p.경로명.Equals(path1));
                        if (sourceFile == null)
                        {
                            sourceFile = new SourceFile { projectId = projectId, 가중치 = 0, 경로명 = path1, 이전경로명 = path2, 이진파일 = (s[0] == '-') };
                            if (sourceFile.이진파일 == false)
                            {
                                sourceFile.경로명 = sourceFile.경로명.Replace("\"", "");
                                var sourceFilePath = Path.Combine(projectPath, sourceFile.경로명.Replace("\"", ""));
                                if (File.Exists(sourceFilePath))
                                    sourceFile.라인수 = File.ReadLines(sourceFilePath).Count();

                                // 확장자 가중치 설정
                                sourceFile.종류 = Path.GetExtension(sourceFile.경로명);
                                var 가중치설정 = db.가중치설정.FirstOrDefault(p => p.종류 == "확장자" && p.값 == sourceFile.종류);
                                if (가중치설정 != null) sourceFile.가중치 = 가중치설정.가중치;

                                // 파일 가중치 설정
                                var 파일명 = Path.GetFileName(sourceFile.경로명);
                                가중치설정 = db.가중치설정.FirstOrDefault(p => p.종류 == "파일" && p.값 == 파일명);
                                if (가중치설정 != null) sourceFile.가중치 = 가중치설정.가중치;

                                // 폴더 가중치 설정
                                foreach (var 설정 in db.가중치설정.Where(p => p.종류 == "폴더"))
                                {
                                    if (sourceFile.경로명.Contains(설정.값))
                                        sourceFile.가중치 = 설정.가중치;
                                }
                            }
                            db.SourceFile.InsertOnSubmit(sourceFile);
                            db.SubmitChanges();
                        }
                        numstat.sourceFileId = sourceFile.id;
                        numstat.commitId = commit.id;
                        db.Numstat.InsertOnSubmit(numstat);
                        db.SubmitChanges();
                    }
                }
            }
        }


    }
}
