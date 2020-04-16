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
            this.txt학번 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.cmb과목.Location = new System.Drawing.Point(79, 31);
            this.cmb과목.Name = "cmb과목";
            this.cmb과목.Size = new System.Drawing.Size(238, 24);
            this.cmb과목.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "과목";
            // 
            // btn작업폴더생성
            // 
            this.btn작업폴더생성.Location = new System.Drawing.Point(79, 69);
            this.btn작업폴더생성.Name = "btn작업폴더생성";
            this.btn작업폴더생성.Size = new System.Drawing.Size(135, 36);
            this.btn작업폴더생성.TabIndex = 13;
            this.btn작업폴더생성.Text = "작업폴더 생성";
            this.btn작업폴더생성.UseVisualStyleBackColor = true;
            this.btn작업폴더생성.Click += new System.EventHandler(this.btn작업폴더생성_Click);
            // 
            // btnNumstat
            // 
            this.btnNumstat.Location = new System.Drawing.Point(221, 69);
            this.btnNumstat.Name = "btnNumstat";
            this.btnNumstat.Size = new System.Drawing.Size(162, 36);
            this.btnNumstat.TabIndex = 14;
            this.btnNumstat.Text = "numstat 생성 & 파싱";
            this.btnNumstat.UseVisualStyleBackColor = true;
            this.btnNumstat.Click += new System.EventHandler(this.btnNumstat_Click);
            // 
            // txt학번
            // 
            this.txt학번.Location = new System.Drawing.Point(382, 32);
            this.txt학번.Name = "txt학번";
            this.txt학번.Size = new System.Drawing.Size(147, 22);
            this.txt학번.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "학번";
            // 
            // frmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 189);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt학번);
            this.Controls.Add(this.btnNumstat);
            this.Controls.Add(this.btn작업폴더생성);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb과목);
            this.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
        private System.Windows.Forms.TextBox txt학번;
        private System.Windows.Forms.Label label2;
    }
}