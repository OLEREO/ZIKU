namespace ZIKU.Control.DataBase
{
    partial class Manage
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
            this.ok = new System.Windows.Forms.Button();
            this.DBListView = new OLEREO.Control.oListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createDB_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.inputDB_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.editDB_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.switchDB_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDBInfo_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.listView_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_exists = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(325, 227);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(108, 35);
            this.ok.TabIndex = 5;
            this.ok.Text = "完成";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // DBListView
            // 
            this.DBListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DBListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.DBListView.ContextMenuStrip = this.menu;
            this.DBListView.EnabledColumnSort = false;
            this.DBListView.EnabledDragItemAndDragFile = false;
            this.DBListView.FullRowSelect = true;
            this.DBListView.GridLines = true;
            this.DBListView.HideSelection = false;
            this.DBListView.HoldLastItemBackeColor = false;
            this.DBListView.Location = new System.Drawing.Point(5, 12);
            this.DBListView.MultiSelect = false;
            this.DBListView.Name = "DBListView";
            this.DBListView.Size = new System.Drawing.Size(437, 209);
            this.DBListView.TabIndex = 4;
            this.DBListView.TabStop = false;
            this.DBListView.UseCompatibleStateImageBehavior = false;
            this.DBListView.View = System.Windows.Forms.View.Details;
            this.DBListView.SelectedIndexChanged += new System.EventHandler(this.DBListView_SelectedIndexChanged);
            this.DBListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DBListView_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "状态";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "数据库名称";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "数据库文件路径";
            this.columnHeader4.Width = 250;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDB_Menu,
            this.inputDB_Menu,
            this.editDB_Menu,
            this.switchDB_Menu,
            this.removeDBInfo_Menu});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(173, 114);
            this.menu.Opening += new System.ComponentModel.CancelEventHandler(this.menu_Opening);
            // 
            // createDB_Menu
            // 
            this.createDB_Menu.Name = "createDB_Menu";
            this.createDB_Menu.Size = new System.Drawing.Size(172, 22);
            this.createDB_Menu.Text = "新建数据库";
            this.createDB_Menu.Click += new System.EventHandler(this.createDB_Menu_Click);
            // 
            // inputDB_Menu
            // 
            this.inputDB_Menu.Name = "inputDB_Menu";
            this.inputDB_Menu.Size = new System.Drawing.Size(172, 22);
            this.inputDB_Menu.Text = "导入数据库";
            this.inputDB_Menu.Click += new System.EventHandler(this.inputDB_Menu_Click);
            // 
            // editDB_Menu
            // 
            this.editDB_Menu.Name = "editDB_Menu";
            this.editDB_Menu.Size = new System.Drawing.Size(172, 22);
            this.editDB_Menu.Text = "编辑该数据库信息";
            this.editDB_Menu.Click += new System.EventHandler(this.editDB_Menu_Click);
            // 
            // switchDB_Menu
            // 
            this.switchDB_Menu.Name = "switchDB_Menu";
            this.switchDB_Menu.Size = new System.Drawing.Size(172, 22);
            this.switchDB_Menu.Text = "切换至该数据库";
            this.switchDB_Menu.Click += new System.EventHandler(this.switchDB_Menu_Click);
            // 
            // removeDBInfo_Menu
            // 
            this.removeDBInfo_Menu.Name = "removeDBInfo_Menu";
            this.removeDBInfo_Menu.Size = new System.Drawing.Size(172, 22);
            this.removeDBInfo_Menu.Text = "移除该数据库";
            this.removeDBInfo_Menu.Click += new System.EventHandler(this.removeDBInfo_Menu_Click);
            // 
            // listView_ID
            // 
            this.listView_ID.Text = "id";
            this.listView_ID.Width = 1;
            // 
            // listView_exists
            // 
            this.listView_exists.Text = "是否存在";
            // 
            // listView_name
            // 
            this.listView_name.Text = "数据库名称";
            this.listView_name.Width = 180;
            // 
            // listView_path
            // 
            this.listView_path.Text = "数据库路径";
            this.listView_path.Width = 300;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "*右键列表获取更多选项。\r\n*状态\"×\"：表示系统中不存在该文件。";
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 268);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.DBListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库管理";
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ok;
        private OLEREO.Control.oListView DBListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader listView_ID;
        private System.Windows.Forms.ColumnHeader listView_exists;
        private System.Windows.Forms.ColumnHeader listView_name;
        private System.Windows.Forms.ColumnHeader listView_path;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem createDB_Menu;
        private System.Windows.Forms.ToolStripMenuItem inputDB_Menu;
        private System.Windows.Forms.ToolStripMenuItem editDB_Menu;
        private System.Windows.Forms.ToolStripMenuItem switchDB_Menu;
        private System.Windows.Forms.ToolStripMenuItem removeDBInfo_Menu;
        private System.Windows.Forms.Label label1;
    }
}