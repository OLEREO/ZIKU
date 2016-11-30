namespace ZIKU.Control.Toolkit
{
    partial class MatchPathItem
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
            this.components = new System.ComponentModel.Container();
            this.oListView1 = new OLEREO.Control.oListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileToItem_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToItem_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.selectPath_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.addToExcludeList_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPath_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.excludeMatch_Button = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.matching_Button = new System.Windows.Forms.Button();
            this.stopMatch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // oListView1
            // 
            this.oListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
            this.oListView1.ContextMenuStrip = this.menu;
            this.oListView1.EnabledColumnSort = false;
            this.oListView1.EnabledDragItemAndDragFile = false;
            this.oListView1.FullRowSelect = true;
            this.oListView1.GridLines = true;
            this.oListView1.HideSelection = false;
            this.oListView1.HoldLastItemBackeColor = false;
            this.oListView1.Location = new System.Drawing.Point(10, 79);
            this.oListView1.MultiSelect = false;
            this.oListView1.Name = "oListView1";
            this.oListView1.Size = new System.Drawing.Size(517, 267);
            this.oListView1.TabIndex = 0;
            this.oListView1.TabStop = false;
            this.oListView1.UseCompatibleStateImageBehavior = false;
            this.oListView1.View = System.Windows.Forms.View.Details;
            this.oListView1.SelectedIndexChanged += new System.EventHandler(this.oListView1_SelectedIndexChanged);
            this.oListView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.oListView1_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "文件(夹)";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "完整路径";
            this.columnHeader1.Width = 500;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToItem_Menu,
            this.folderToItem_Menu,
            this.selectPath_Menu,
            this.addToExcludeList_Menu,
            this.copyPath_Menu});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(233, 114);
            this.menu.Opening += new System.ComponentModel.CancelEventHandler(this.menu_Opening);
            // 
            // fileToItem_Menu
            // 
            this.fileToItem_Menu.Name = "fileToItem_Menu";
            this.fileToItem_Menu.Size = new System.Drawing.Size(232, 22);
            this.fileToItem_Menu.Text = "创建项目";
            this.fileToItem_Menu.Click += new System.EventHandler(this.fileToItem_Menu_Click);
            // 
            // folderToItem_Menu
            // 
            this.folderToItem_Menu.Name = "folderToItem_Menu";
            this.folderToItem_Menu.Size = new System.Drawing.Size(232, 22);
            this.folderToItem_Menu.Text = "使用文件夹内的文件创建项目";
            this.folderToItem_Menu.Click += new System.EventHandler(this.folderToItem_Menu_Click);
            // 
            // selectPath_Menu
            // 
            this.selectPath_Menu.Name = "selectPath_Menu";
            this.selectPath_Menu.Size = new System.Drawing.Size(232, 22);
            this.selectPath_Menu.Text = "在资源管理器选中该文件(夹)";
            this.selectPath_Menu.Click += new System.EventHandler(this.selectPath_Menu_Click);
            // 
            // addToExcludeList_Menu
            // 
            this.addToExcludeList_Menu.Name = "addToExcludeList_Menu";
            this.addToExcludeList_Menu.Size = new System.Drawing.Size(232, 22);
            this.addToExcludeList_Menu.Text = "加入排除列表";
            this.addToExcludeList_Menu.Click += new System.EventHandler(this.addToExcludeList_Menu_Click);
            // 
            // copyPath_Menu
            // 
            this.copyPath_Menu.Name = "copyPath_Menu";
            this.copyPath_Menu.Size = new System.Drawing.Size(232, 22);
            this.copyPath_Menu.Text = "复制完整的路径";
            this.copyPath_Menu.Click += new System.EventHandler(this.copyPath_Menu_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(414, 21);
            this.textBox1.TabIndex = 1;
            // 
            // excludeMatch_Button
            // 
            this.excludeMatch_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.excludeMatch_Button.Location = new System.Drawing.Point(427, 352);
            this.excludeMatch_Button.Name = "excludeMatch_Button";
            this.excludeMatch_Button.Size = new System.Drawing.Size(99, 34);
            this.excludeMatch_Button.TabIndex = 4;
            this.excludeMatch_Button.Text = "已经排除的列表";
            this.excludeMatch_Button.UseVisualStyleBackColor = true;
            this.excludeMatch_Button.Click += new System.EventHandler(this.excludeMatch_Button_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(81, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // matching_Button
            // 
            this.matching_Button.Location = new System.Drawing.Point(432, 27);
            this.matching_Button.Name = "matching_Button";
            this.matching_Button.Size = new System.Drawing.Size(44, 35);
            this.matching_Button.TabIndex = 2;
            this.matching_Button.Text = "开始查找";
            this.matching_Button.UseVisualStyleBackColor = true;
            this.matching_Button.Click += new System.EventHandler(this.matching_Button_Click);
            // 
            // stopMatch
            // 
            this.stopMatch.Enabled = false;
            this.stopMatch.Location = new System.Drawing.Point(482, 27);
            this.stopMatch.Name = "stopMatch";
            this.stopMatch.Size = new System.Drawing.Size(44, 35);
            this.stopMatch.TabIndex = 3;
            this.stopMatch.Text = "停止查找";
            this.stopMatch.UseVisualStyleBackColor = true;
            this.stopMatch.Click += new System.EventHandler(this.stopMatch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "使用变量值：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(12, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 53);
            this.label2.TabIndex = 7;
            this.label2.Text = "*双击为文件(夹)创建项目。\r\n*右键列表获取更多选项。\r\n*查找不包含子目录。";
            // 
            // MatchPathItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 406);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopMatch);
            this.Controls.Add(this.excludeMatch_Button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.matching_Button);
            this.Controls.Add(this.oListView1);
            this.Name = "MatchPathItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找系统目录中未被记录的项目";
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OLEREO.Control.oListView oListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToItem_Menu;
        private System.Windows.Forms.ToolStripMenuItem folderToItem_Menu;
        private System.Windows.Forms.ToolStripMenuItem selectPath_Menu;
        private System.Windows.Forms.ToolStripMenuItem addToExcludeList_Menu;
        private System.Windows.Forms.ToolStripMenuItem copyPath_Menu;
        private System.Windows.Forms.Button excludeMatch_Button;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button matching_Button;
        private System.Windows.Forms.Button stopMatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}