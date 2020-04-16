namespace git_history
{
    partial class frmMain
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
            this.btn과제제출현황 = new System.Windows.Forms.Button();
            this.btn다운로드 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn과제제출현황
            // 
            this.btn과제제출현황.Location = new System.Drawing.Point(40, 68);
            this.btn과제제출현황.Name = "btn과제제출현황";
            this.btn과제제출현황.Size = new System.Drawing.Size(162, 36);
            this.btn과제제출현황.TabIndex = 18;
            this.btn과제제출현황.Text = "과제제출 현황";
            this.btn과제제출현황.UseVisualStyleBackColor = true;
            this.btn과제제출현황.Click += new System.EventHandler(this.btn과제제출현황_Click);
            // 
            // btn다운로드
            // 
            this.btn다운로드.Location = new System.Drawing.Point(40, 26);
            this.btn다운로드.Name = "btn다운로드";
            this.btn다운로드.Size = new System.Drawing.Size(162, 36);
            this.btn다운로드.TabIndex = 19;
            this.btn다운로드.Text = "다운로드";
            this.btn다운로드.UseVisualStyleBackColor = true;
            this.btn다운로드.Click += new System.EventHandler(this.btn다운로드_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 300);
            this.Controls.Add(this.btn다운로드);
            this.Controls.Add(this.btn과제제출현황);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn과제제출현황;
        private System.Windows.Forms.Button btn다운로드;
    }
}