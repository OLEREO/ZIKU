namespace ZIKU
{
    partial class Welcome
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
            this.label1 = new System.Windows.Forms.Label();
            this.newCategoryFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎使用 ZIKU!，请先创建一个数据库以保存所有信息。\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // newCategoryFile
            // 
            this.newCategoryFile.Location = new System.Drawing.Point(11, 92);
            this.newCategoryFile.Margin = new System.Windows.Forms.Padding(2);
            this.newCategoryFile.Name = "newCategoryFile";
            this.newCategoryFile.Size = new System.Drawing.Size(320, 110);
            this.newCategoryFile.TabIndex = 1;
            this.newCategoryFile.Text = "创建一个新数据库";
            this.newCategoryFile.UseVisualStyleBackColor = true;
            this.newCategoryFile.Click += new System.EventHandler(this.newCategoryFile_Click);
            // 
            // Welcome
            // 
            this.AcceptButton = this.newCategoryFile;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 213);
            this.Controls.Add(this.newCategoryFile);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用 ZIKU!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newCategoryFile;
    }
}