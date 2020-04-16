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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btn다운로드_Click(object sender, EventArgs e)
        {
            new frmDownload().Show();
        }

        private void btn과제제출현황_Click(object sender, EventArgs e)
        {
            new frm과제현황().Show();
        }
    }
}
