namespace ZIKU.Control
{
    partial class setting
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
            this.CheckUP = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.checkUP_Box = new System.Windows.Forms.CheckBox();
            this.seB_box = new System.Windows.Forms.ComboBox();
            this.seA_box = new System.Windows.Forms.ComboBox();
            this.isSeHotkey = new System.Windows.Forms.CheckBox();
            this.HotKeyB_Box = new System.Windows.Forms.ComboBox();
            this.HotKeyA_Box = new System.Windows.Forms.ComboBox();
            this.isHotKey = new System.Windows.Forms.CheckBox();
            this.startup = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CheckUP
            // 
            this.CheckUP.Location = new System.Drawing.Point(191, 11);
            this.CheckUP.Margin = new System.Windows.Forms.Padding(2);
            this.CheckUP.Name = "CheckUP";
            this.CheckUP.Size = new System.Drawing.Size(146, 37);
            this.CheckUP.TabIndex = 12;
            this.CheckUP.Text = "检查更新";
            this.CheckUP.UseVisualStyleBackColor = true;
            this.CheckUP.Click += new System.EventHandler(this.CheckUP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(191, 158);
            this.Save.Margin = new System.Windows.Forms.Padding(2);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(146, 39);
            this.Save.TabIndex = 14;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(191, 115);
            this.Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(146, 39);
            this.Cancel.TabIndex = 13;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // checkUP_Box
            // 
            this.checkUP_Box.AutoSize = true;
            this.checkUP_Box.Location = new System.Drawing.Point(191, 79);
            this.checkUP_Box.Margin = new System.Windows.Forms.Padding(2);
            this.checkUP_Box.Name = "checkUP_Box";
            this.checkUP_Box.Size = new System.Drawing.Size(132, 16);
            this.checkUP_Box.TabIndex = 2;
            this.checkUP_Box.Text = "启动时检查一次更新";
            this.checkUP_Box.UseVisualStyleBackColor = true;
            // 
            // seB_box
            // 
            this.seB_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seB_box.FormattingEnabled = true;
            this.seB_box.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.seB_box.Location = new System.Drawing.Point(88, 150);
            this.seB_box.Margin = new System.Windows.Forms.Padding(2);
            this.seB_box.Name = "seB_box";
            this.seB_box.Size = new System.Drawing.Size(45, 20);
            this.seB_box.TabIndex = 8;
            // 
            // seA_box
            // 
            this.seA_box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seA_box.FormattingEnabled = true;
            this.seA_box.Items.AddRange(new object[] {
            "SHIFT",
            "CTRT",
            "ALT"});
            this.seA_box.Location = new System.Drawing.Point(11, 150);
            this.seA_box.Margin = new System.Windows.Forms.Padding(2);
            this.seA_box.Name = "seA_box";
            this.seA_box.Size = new System.Drawing.Size(68, 20);
            this.seA_box.TabIndex = 7;
            // 
            // isSeHotkey
            // 
            this.isSeHotkey.AutoSize = true;
            this.isSeHotkey.Location = new System.Drawing.Point(11, 130);
            this.isSeHotkey.Margin = new System.Windows.Forms.Padding(2);
            this.isSeHotkey.Name = "isSeHotkey";
            this.isSeHotkey.Size = new System.Drawing.Size(120, 16);
            this.isSeHotkey.TabIndex = 6;
            this.isSeHotkey.Text = "否启用搜索快捷键";
            this.isSeHotkey.UseVisualStyleBackColor = true;
            // 
            // HotKeyB_Box
            // 
            this.HotKeyB_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HotKeyB_Box.FormattingEnabled = true;
            this.HotKeyB_Box.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.HotKeyB_Box.Location = new System.Drawing.Point(88, 84);
            this.HotKeyB_Box.Margin = new System.Windows.Forms.Padding(2);
            this.HotKeyB_Box.Name = "HotKeyB_Box";
            this.HotKeyB_Box.Size = new System.Drawing.Size(45, 20);
            this.HotKeyB_Box.TabIndex = 5;
            // 
            // HotKeyA_Box
            // 
            this.HotKeyA_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HotKeyA_Box.FormattingEnabled = true;
            this.HotKeyA_Box.Items.AddRange(new object[] {
            "SHIFT",
            "CTRT",
            "ALT"});
            this.HotKeyA_Box.Location = new System.Drawing.Point(11, 84);
            this.HotKeyA_Box.Margin = new System.Windows.Forms.Padding(2);
            this.HotKeyA_Box.Name = "HotKeyA_Box";
            this.HotKeyA_Box.Size = new System.Drawing.Size(68, 20);
            this.HotKeyA_Box.TabIndex = 4;
            // 
            // isHotKey
            // 
            this.isHotKey.AutoSize = true;
            this.isHotKey.Location = new System.Drawing.Point(11, 64);
            this.isHotKey.Margin = new System.Windows.Forms.Padding(2);
            this.isHotKey.Name = "isHotKey";
            this.isHotKey.Size = new System.Drawing.Size(132, 16);
            this.isHotKey.TabIndex = 3;
            this.isHotKey.Text = "启用界面显隐快捷键";
            this.isHotKey.UseVisualStyleBackColor = true;
            // 
            // startup
            // 
            this.startup.AutoSize = true;
            this.startup.Location = new System.Drawing.Point(11, 11);
            this.startup.Margin = new System.Windows.Forms.Padding(2);
            this.startup.Name = "startup";
            this.startup.Size = new System.Drawing.Size(168, 16);
            this.startup.TabIndex = 1;
            this.startup.Text = "开机启动(仅当前用户有效)";
            this.startup.UseVisualStyleBackColor = true;
            // 
            // setting
            // 
            this.AcceptButton = this.Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(348, 206);
            this.Controls.Add(this.checkUP_Box);
            this.Controls.Add(this.seB_box);
            this.Controls.Add(this.seA_box);
            this.Controls.Add(this.isSeHotkey);
            this.Controls.Add(this.HotKeyB_Box);
            this.Controls.Add(this.HotKeyA_Box);
            this.Controls.Add(this.isHotKey);
            this.Controls.Add(this.startup);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckUP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZIKU!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.setting_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CheckUP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.CheckBox checkUP_Box;
        private System.Windows.Forms.ComboBox seB_box;
        private System.Windows.Forms.ComboBox seA_box;
        private System.Windows.Forms.CheckBox isSeHotkey;
        private System.Windows.Forms.ComboBox HotKeyB_Box;
        private System.Windows.Forms.ComboBox HotKeyA_Box;
        private System.Windows.Forms.CheckBox isHotKey;
        private System.Windows.Forms.CheckBox startup;
    }
}