namespace ZIKU.Control.DataBase
{
    partial class NotExists
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
            this.createNewDB = new System.Windows.Forms.Button();
            this.chooseDB = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.searchDB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dbFilePath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createNewDB
            // 
            this.createNewDB.Location = new System.Drawing.Point(26, 139);
            this.createNewDB.Margin = new System.Windows.Forms.Padding(2);
            this.createNewDB.Name = "createNewDB";
            this.createNewDB.Size = new System.Drawing.Size(144, 52);
            this.createNewDB.TabIndex = 3;
            this.createNewDB.Text = "创建一个新的数据库替代";
            this.createNewDB.UseVisualStyleBackColor = true;
            this.createNewDB.Click += new System.EventHandler(this.createNewDB_Click);
            // 
            // chooseDB
            // 
            this.chooseDB.Location = new System.Drawing.Point(26, 79);
            this.chooseDB.Margin = new System.Windows.Forms.Padding(2);
            this.chooseDB.Name = "chooseDB";
            this.chooseDB.Size = new System.Drawing.Size(144, 52);
            this.chooseDB.TabIndex = 1;
            this.chooseDB.Text = "选择一个数据库文件";
            this.chooseDB.UseVisualStyleBackColor = true;
            this.chooseDB.Click += new System.EventHandler(this.chooseDB_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.DarkRed;
            this.cancel.ForeColor = System.Drawing.Color.White;
            this.cancel.Location = new System.Drawing.Point(202, 139);
            this.cancel.Margin = new System.Windows.Forms.Padding(2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(144, 52);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "退出 ZIKU!";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // searchDB
            // 
            this.searchDB.Location = new System.Drawing.Point(202, 79);
            this.searchDB.Margin = new System.Windows.Forms.Padding(2);
            this.searchDB.Name = "searchDB";
            this.searchDB.Size = new System.Drawing.Size(144, 52);
            this.searchDB.TabIndex = 2;
            this.searchDB.Text = "从现有配置中搜索一个可用的数据库文件";
            this.searchDB.UseVisualStyleBackColor = true;
            this.searchDB.Click += new System.EventHandler(this.searchDB_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 68);
            this.label1.TabIndex = 11;
            this.label1.Text = "上一次使用的数据库文件丢失！\r\n请从下面的选项中选择一个项以继续：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbFilePath
            // 
            this.dbFilePath.AutoSize = true;
            this.dbFilePath.Location = new System.Drawing.Point(7, 202);
            this.dbFilePath.Name = "dbFilePath";
            this.dbFilePath.Size = new System.Drawing.Size(41, 12);
            this.dbFilePath.TabIndex = 12;
            this.dbFilePath.Text = "label2";
            // 
            // NotExists
            // 
            this.AcceptButton = this.chooseDB;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 220);
            this.Controls.Add(this.dbFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createNewDB);
            this.Controls.Add(this.chooseDB);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.searchDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotExists";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "上一次使用的数据库文件丢失";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createNewDB;
        private System.Windows.Forms.Button chooseDB;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button searchDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dbFilePath;
    }
}