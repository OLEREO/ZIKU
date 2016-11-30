namespace ZIKU.Control.Toolkit
{
    partial class MatchVarValue
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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editItem_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.match_Button = new System.Windows.Forms.Button();
            this.checkAll_Button = new System.Windows.Forms.Button();
            this.cancelCheck_Button = new System.Windows.Forms.Button();
            this.replaceCheck_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menus.SuspendLayout();
            this.SuspendLayout();
            // 
            // oListView1
            // 
            this.oListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oListView1.CheckBoxes = true;
            this.oListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader4});
            this.oListView1.ContextMenuStrip = this.menus;
            this.oListView1.EnabledColumnSort = false;
            this.oListView1.EnabledDragItemAndDragFile = false;
            this.oListView1.FullRowSelect = true;
            this.oListView1.GridLines = true;
            this.oListView1.HideSelection = false;
            this.oListView1.HoldLastItemBackeColor = false;
            this.oListView1.Location = new System.Drawing.Point(12, 61);
            this.oListView1.MultiSelect = false;
            this.oListView1.Name = "oListView1";
            this.oListView1.Size = new System.Drawing.Size(760, 431);
            this.oListView1.TabIndex = 0;
            this.oListView1.TabStop = false;
            this.oListView1.UseCompatibleStateImageBehavior = false;
            this.oListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目名称";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "值类型";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "可替换的变量";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "替换后的值";
            this.columnHeader6.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "值";
            this.columnHeader4.Width = 300;
            // 
            // menus
            // 
            this.menus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editItem_Menu});
            this.menus.Name = "menus";
            this.menus.Size = new System.Drawing.Size(137, 26);
            this.menus.Opening += new System.ComponentModel.CancelEventHandler(this.menus_Opening);
            // 
            // editItem_Menu
            // 
            this.editItem_Menu.Name = "editItem_Menu";
            this.editItem_Menu.Size = new System.Drawing.Size(136, 22);
            this.editItem_Menu.Text = "编辑该项目";
            this.editItem_Menu.Click += new System.EventHandler(this.editItem_Menu_Click);
            // 
            // match_Button
            // 
            this.match_Button.Location = new System.Drawing.Point(12, 12);
            this.match_Button.Name = "match_Button";
            this.match_Button.Size = new System.Drawing.Size(119, 43);
            this.match_Button.TabIndex = 0;
            this.match_Button.Text = "开始查找";
            this.match_Button.UseVisualStyleBackColor = true;
            this.match_Button.Click += new System.EventHandler(this.match_Button_Click);
            // 
            // checkAll_Button
            // 
            this.checkAll_Button.Location = new System.Drawing.Point(164, 12);
            this.checkAll_Button.Name = "checkAll_Button";
            this.checkAll_Button.Size = new System.Drawing.Size(71, 43);
            this.checkAll_Button.TabIndex = 2;
            this.checkAll_Button.TabStop = false;
            this.checkAll_Button.Text = "全选";
            this.checkAll_Button.UseVisualStyleBackColor = true;
            this.checkAll_Button.Click += new System.EventHandler(this.checkAll_Button_Click);
            // 
            // cancelCheck_Button
            // 
            this.cancelCheck_Button.Location = new System.Drawing.Point(237, 12);
            this.cancelCheck_Button.Name = "cancelCheck_Button";
            this.cancelCheck_Button.Size = new System.Drawing.Size(71, 43);
            this.cancelCheck_Button.TabIndex = 3;
            this.cancelCheck_Button.TabStop = false;
            this.cancelCheck_Button.Text = "取消全选";
            this.cancelCheck_Button.UseVisualStyleBackColor = true;
            this.cancelCheck_Button.Click += new System.EventHandler(this.cancelCheck_Button_Click);
            // 
            // replaceCheck_Button
            // 
            this.replaceCheck_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.replaceCheck_Button.Enabled = false;
            this.replaceCheck_Button.Location = new System.Drawing.Point(12, 498);
            this.replaceCheck_Button.Name = "replaceCheck_Button";
            this.replaceCheck_Button.Size = new System.Drawing.Size(132, 61);
            this.replaceCheck_Button.TabIndex = 4;
            this.replaceCheck_Button.TabStop = false;
            this.replaceCheck_Button.Text = "替换选中的项目";
            this.replaceCheck_Button.UseVisualStyleBackColor = true;
            this.replaceCheck_Button.Click += new System.EventHandler(this.replaceCheck_Button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(150, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 44);
            this.label1.TabIndex = 5;
            this.label1.Text = "当同一个主值被多个 \"内部变量\" 匹配时，请选择只勾选最优的那一个。\r\n — 如果两个都勾选，则会替换为列表后面的那个替换值。";
            // 
            // MatchVarValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.replaceCheck_Button);
            this.Controls.Add(this.cancelCheck_Button);
            this.Controls.Add(this.checkAll_Button);
            this.Controls.Add(this.match_Button);
            this.Controls.Add(this.oListView1);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MatchVarValue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找项目中可替换为内部变量的主值";
            this.menus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OLEREO.Control.oListView oListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button match_Button;
        private System.Windows.Forms.Button checkAll_Button;
        private System.Windows.Forms.Button cancelCheck_Button;
        private System.Windows.Forms.Button replaceCheck_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip menus;
        private System.Windows.Forms.ToolStripMenuItem editItem_Menu;
    }
}