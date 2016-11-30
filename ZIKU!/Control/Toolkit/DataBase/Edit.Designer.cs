namespace ZIKU.Control.DataBase
{
    partial class Edit
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
            this.label3 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dbName = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.chooseDB = new System.Windows.Forms.Button();
            this.reReadDB = new System.Windows.Forms.Button();
            this.dbFilePath = new OLEREO.Control.oTextBox();
            this.dbDataFolder = new OLEREO.Control.FloatingTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "项目资料总目录:";
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(122, 105);
            this.cancel.Margin = new System.Windows.Forms.Padding(2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(96, 39);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(5, 105);
            this.save.Margin = new System.Windows.Forms.Padding(2);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(96, 39);
            this.save.TabIndex = 5;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "数据库名称：";
            // 
            // dbName
            // 
            this.dbName.Location = new System.Drawing.Point(5, 21);
            this.dbName.Margin = new System.Windows.Forms.Padding(2);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(223, 21);
            this.dbName.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Cursor = System.Windows.Forms.Cursors.No;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Enabled = false;
            this.splitter1.Location = new System.Drawing.Point(0, 172);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(264, 110);
            this.splitter1.TabIndex = 21;
            this.splitter1.TabStop = false;
            // 
            // chooseDB
            // 
            this.chooseDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chooseDB.Location = new System.Drawing.Point(233, 254);
            this.chooseDB.Margin = new System.Windows.Forms.Padding(2);
            this.chooseDB.Name = "chooseDB";
            this.chooseDB.Size = new System.Drawing.Size(22, 22);
            this.chooseDB.TabIndex = 23;
            this.chooseDB.UseVisualStyleBackColor = true;
            this.chooseDB.Click += new System.EventHandler(this.chooseDB_Click);
            // 
            // reReadDB
            // 
            this.reReadDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reReadDB.Location = new System.Drawing.Point(11, 180);
            this.reReadDB.Margin = new System.Windows.Forms.Padding(2);
            this.reReadDB.Name = "reReadDB";
            this.reReadDB.Size = new System.Drawing.Size(239, 66);
            this.reReadDB.TabIndex = 6;
            this.reReadDB.Text = "读取数据库文件信息\r\n(如果手动修改了下面的位置)";
            this.reReadDB.UseVisualStyleBackColor = true;
            this.reReadDB.Click += new System.EventHandler(this.reReadDB_Click);
            // 
            // dbFilePath
            // 
            this.dbFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dbFilePath.HintText = "支持系统变量";
            this.dbFilePath.Location = new System.Drawing.Point(11, 254);
            this.dbFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.dbFilePath.Name = "dbFilePath";
            this.dbFilePath.Size = new System.Drawing.Size(217, 21);
            this.dbFilePath.TabIndex = 7;
            // 
            // dbDataFolder
            // 
            this.dbDataFolder.AutoSize = true;
            this.dbDataFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dbDataFolder.FloatingText = null;
            this.dbDataFolder.HintText = "支持所有变量";
            this.dbDataFolder.Location = new System.Drawing.Point(5, 70);
            this.dbDataFolder.Name = "dbDataFolder";
            this.dbDataFolder.Size = new System.Drawing.Size(244, 27);
            this.dbDataFolder.TabIndex = 2;
            this.dbDataFolder.text = "";
            this.dbDataFolder.rButtonClicked += new OLEREO.Control.FloatingTextBox.BtnClickHandle(this.dbDataFolder_rButtonClicked);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(7, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "数据库文件位置(支持系统变量)：";
            // 
            // Edit
            // 
            this.AcceptButton = this.save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(264, 282);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reReadDB);
            this.Controls.Add(this.chooseDB);
            this.Controls.Add(this.dbFilePath);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dbDataFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑数据库文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dbName;
        private OLEREO.Control.FloatingTextBox dbDataFolder;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button chooseDB;
        private OLEREO.Control.oTextBox dbFilePath;
        private System.Windows.Forms.Button reReadDB;
        private System.Windows.Forms.Label label2;
    }
}