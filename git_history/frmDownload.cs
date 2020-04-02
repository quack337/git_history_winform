using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace git_history
{
    public partial class frmDownload : Form
    {
        public frmDownload()
        {
            InitializeComponent();
        }

        private void frmDownload_Load(object sender, EventArgs e)
        {
            using (var db = new DBDataContext())
            {
                var list = db.과목.Select(p => p.과목명).ToArray();
                cmb과목.Items.AddRange(list);
            }
        }

        private void btn작업폴더생성_Click(object sender, EventArgs e)
        {
            btn작업폴더생성.Enabled = false;
            using (var db = new DBDataContext())
            {
                var 과목 = db.과목.FirstOrDefault(p => p.과목명 == cmb과목.SelectedItem.ToString());
                foreach (var 프로젝트 in 과목.Project)
                {
                    if (txt학번.Text.Trim().Length > 0 && 프로젝트.학생_프로젝트.Any(p => p.학번 == txt학번.Text) == false)
                        continue;
                    if (string.IsNullOrEmpty(프로젝트.프로젝트명))
                    {
                        var s = Download.GetProjectName(프로젝트.url);
                        if (string.IsNullOrEmpty(s)) continue;
                        프로젝트.프로젝트명 = s;
                        db.SubmitChanges();
                    }
                    var 프로젝트폴더 = 과목.작업폴더 + @"\" + 프로젝트.프로젝트명;
                    if (Directory.Exists(프로젝트폴더) == false)
                        Download.Clone(프로젝트.id, 프로젝트.url, 과목.작업폴더);
                }
            }
            btn작업폴더생성.Enabled = true;
        }

        private void btnNumstat_Click(object sender, EventArgs e)
        {
            btnNumstat.Enabled = false;
            using (var db = new DBDataContext())
            {
                var 과목 = db.과목.FirstOrDefault(p => p.과목명 == cmb과목.SelectedItem.ToString());
                foreach (var 프로젝트 in 과목.Project)
                {
                    if (txt학번.Text.Trim().Length > 0 && 프로젝트.학생_프로젝트.Any(p => p.학번 == txt학번.Text) == false)
                        continue;
                    var 프로젝트폴더 = 과목.작업폴더 + @"\" + 프로젝트.id + @"\" + 프로젝트.프로젝트명;
                    if (Directory.Exists(프로젝트폴더) == false) continue;
                    Download.createNumstat(프로젝트폴더);
                    Git.parseLog(db, 프로젝트폴더, 프로젝트.id);
                }
            }
            btnNumstat.Enabled = true;
        }
    }
}
