namespace git_history
{
    partial class frmDownload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmb과목 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn작업폴더생성 = new System.Windows.Forms.Button();
            this.btnNumstat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cmb과목
            // 
            this.cmb과목.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb과목.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmb과목.FormattingEnabled = true;
            this.cmb과목.Location = new System.Drawing.Point(69, 29);
            this.cmb과목.Name = "cmb과목";
            this.cmb과목.Size = new System.Drawing.Size(209, 24);
            this.cmb과목.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "과목";
            // 
            // btn작업폴더생성
            // 
            this.btn작업폴더생성.Location = new System.Drawing.Point(69, 64);
            this.btn작업폴더생성.Name = "btn작업폴더생성";
            this.btn작업폴더생성.Size = new System.Drawing.Size(118, 33);
            this.btn작업폴더생성.TabIndex = 13;
            this.btn작업폴더생성.Text = "작업폴더 생성";
            this.btn작업폴더생성.UseVisualStyleBackColor = true;
            this.btn작업폴더생성.Click += new System.EventHandler(this.btn작업폴더생성_Click);
            // 
            // btnNumstat
            // 
            this.btnNumstat.Location = new System.Drawing.Point(193, 64);
            this.btnNumstat.Name = "btnNumstat";
            this.btnNumstat.Size = new System.Drawing.Size(142, 33);
            this.btnNumstat.TabIndex = 14;
            this.btnNumstat.Text = "numstat 생성 & 파싱";
            this.btnNumstat.UseVisualStyleBackColor = true;
            this.btnNumstat.Click += new System.EventHandler(this.btnNumstat_Click);
            // 
            // frmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNumstat);
            this.Controls.Add(this.btn작업폴더생성);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb과목);
            this.Name = "frmDownload";
            this.Text = "frmDownload";
            this.Load += new System.EventHandler(this.frmDownload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cmb과목;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn작업폴더생성;
        private System.Windows.Forms.Button btnNumstat;
    }
}