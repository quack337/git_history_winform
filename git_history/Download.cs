using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace git_history
{
    class Download
    {
        public const string NUMSTAT_FILE_NAME = "_numstat.txt";
        private static Regex regex1 = new Regex(@".+/([^/]+).git$");
        private static Regex regex2 = new Regex(@".+/([^/]+)$");

        public static string GetProjectName(string url)
        {
            var match = regex1.Match(url);
            if (match.Success) return match.Groups[1].Value;
            match = regex2.Match(url);
            if (match.Success) return match.Groups[1].Value;
            return null;
        }

        public static void Clone(int projectId, string url, string 작업폴더)
        {
            if (Directory.Exists(작업폴더) == false) Directory.CreateDirectory(작업폴더);

            var projectName = GetProjectName(url);
            var info = new ProcessStartInfo();
            var process = new Process();

            info.FileName = "cmd.exe";
            info.WorkingDirectory = 작업폴더;
            info.CreateNoWindow = false;
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardError = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            process.StartInfo = info;
            process.Start();

            process.StandardInput.Write("mkdir " + projectId + Environment.NewLine);
            process.StandardInput.Write("cd " + projectId + Environment.NewLine);
            process.StandardInput.Write("git clone " + url + Environment.NewLine);
            process.StandardInput.Write("cd " + projectName + Environment.NewLine);
            process.StandardInput.Write("git log --numstat > _numstat.txt" + Environment.NewLine);

            process.StandardInput.Close();
            string s1 = process.StandardOutput.ReadToEnd();
            string s2 = process.StandardError.ReadToEnd();
            process.WaitForExit();
            process.Close();
        }

        public static void createNumstat(string 프로젝트폴더)
        {
            var info = new ProcessStartInfo();
            var process = new Process();

            info.FileName = "cmd.exe";
            info.WorkingDirectory = 프로젝트폴더;
            info.CreateNoWindow = false;
            info.UseShellExecute = false;
            info.RedirectStandardOutput = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardError = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            process.StartInfo = info;
            process.Start();

            process.StandardInput.Write("git pull" + Environment.NewLine);
            process.StandardInput.Write("git log --numstat > " + NUMSTAT_FILE_NAME + Environment.NewLine);

            process.StandardInput.Close();
            string s1 = process.StandardOutput.ReadToEnd();
            string s2 = process.StandardError.ReadToEnd();
            process.WaitForExit();
            process.Close();
        }
    }
}
