using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace git_history
{
    public partial class frm과제현황 : Form
    {
        public frm과제현황()
        {
            InitializeComponent();
        }


        private void frm과제현황_Load(object sender, EventArgs e)
        {
            using (var db = new DBDataContext())
            {
                var list = db.과목.Select(p => p.과목명).ToArray();
                cmb과목.Items.AddRange(list);
            }
        }


        static string SQL1 = @"
  SELECT s.학번, 이름, 파일명1 파일명, 
    CASE 
      WHEN c.시각 <= hw.종료일 THEN ' O' -- 앞에 공백이 있어야 MIN 됨.
      WHEN c.시각 > hw.종료일 THEN CONVERT(VARCHAR(25), 시각, 120)
      END 제출
  FROM 과제파일 hw
    JOIN SourceFile f ON 
                  CHARINDEX(LOWER(hw.파일명1), LOWER(f.경로명)) > 0 OR
                  CHARINDEX(LOWER(hw.파일명2), LOWER(f.경로명)) > 0 OR
                  CHARINDEX(LOWER(hw.파일명3), LOWER(f.경로명)) > 0
    JOIN Numstat n ON n.sourceFileId = f.id
    JOIN [Commit] c ON n.commitId = c.id
    JOIN 학생_프로젝트 s ON s.projectId = c.projectId
    JOIN Project p ON p.id = c.projectId AND p.과목 = hw.과목
    JOIN 학생 ss ON ss.학번 = s.학번
  WHERE 
    hw.시작일 = '{0:yyyy-MM-dd}'
    AND hw.과목 = '{1}'
  ";

        List<과제제출> 결과목록;
        List<string> 파일목록;

        private void btn조회_Click(object sender, EventArgs e)
        {
            결과목록 = new List<과제제출>();
            var 시작일 = dateTimePicker1.Value.Date;
            var 종료일 = 시작일.AddDays(7);
            var 과목 = cmb과목.SelectedItem.ToString();
            using (var db = new DBDataContext())
            {
                파일목록 = db.과제파일.Where(p => p.과목 == 과목 && p.시작일 == 시작일).OrderBy(p => p.No).Select(p => p.파일명1).ToList();
                while (파일목록.Count < 6)
                    파일목록.Add("");
                var 헤더 = new 과제제출 { 학번 = "학번", 이름 = "이름", 제출1 = 파일목록[0],
                    제출2 = 파일목록[1], 제출3 = 파일목록[2], 제출4 = 파일목록[3], 제출5 = 파일목록[4], 제출6 = 파일목록[5] };
                결과목록.Add(헤더);

                var sql = String.Format(SQL1, 시작일, 과목);
                var 조회결과목록 = db.ExecuteQuery<조회결과1>(sql);
                var map = new Dictionary<string, 과제제출>();
                foreach (var p in 조회결과목록)
                {
                    var prjId = db.학생_프로젝트.Where(q => q.학번 == p.학번 && q.Project.과목 == 과목).Select(q => q.Project.id).ToArray();

                    if (map.ContainsKey(p.학번) == false)
                        map[p.학번] = new 과제제출 { 학번 = p.학번, 이름 = p.이름, 프로젝트ID = string.Join(" ", prjId) };
                    var r = map[p.학번];
                    if (파일목록[0] == p.파일명) r.제출1 = p.제출;
                    else if (파일목록[1] == p.파일명) r.제출2 = p.제출;
                    else if (파일목록[2] == p.파일명) r.제출3 = p.제출;
                    else if (파일목록[3] == p.파일명) r.제출4 = p.제출;
                    else if (파일목록[4] == p.파일명) r.제출5 = p.제출;
                    else if (파일목록[5] == p.파일명) r.제출6 = p.제출;
                }
                var keys = map.Keys.ToList();
                keys.Sort();
                foreach (var k in keys)
                    결과목록.Add(map[k]);
            }
            dataGridView1.DataSource = 결과목록;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 2) return;
            if (e.RowIndex < 1) return;
            var 학번 = 결과목록[e.RowIndex].학번;
            var 파일명 = 파일목록[e.ColumnIndex - 2];
            var 과목명 = cmb과목.SelectedItem.ToString();
            using (var db = new DBDataContext())
            {
                var 프로젝트목록 = db.학생_프로젝트.Where(p => p.학번 == 학번 && p.Project.과목 == 과목명).Select(p => p.Project);
                foreach (var prj in 프로젝트목록)
                {
                    var file = prj.SourceFile.Where(p => p.경로명.Contains(파일명)).OrderByDescending(p => p.id).FirstOrDefault();
                    if (file != null)
                    {
                        var url = prj.url.Replace(".git", "/blob/master/") + file.경로명;
                        System.Diagnostics.Process.Start(url);
                        break;
                    }
                }
            }
        }
    }

    class 과제제출
    {
        public string 학번 { get; set; }
        public string 이름 { get; set; }
        public string 제출1 { get; set; }
        public string 제출2 { get; set; }
        public string 제출3 { get; set; }
        public string 제출4 { get; set; }
        public string 제출5 { get; set; }
        public string 제출6 { get; set; }
        public string 프로젝트ID { get; set; }
    }

    class 조회결과1
    {
        public string 학번 { get; set; }
        public string 이름 { get; set; }
        public string 파일명 { get; set; }
        public string 제출 { get; set; }
    }


}
