using OLEREO.Control;

namespace ZIKU.Control.Category
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
            this.Pcategory_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Pcategory_Menu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Pcategory_Menu_Del = new System.Windows.Forms.ToolStripMenuItem();
            this.Pcategory_Menu_ReName = new System.Windows.Forms.ToolStripMenuItem();
            this.switchPtoS_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Scategory_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SubCategory_Menu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.SubCategory_Menu_Del = new System.Windows.Forms.ToolStripMenuItem();
            this.SubCategory_Menu_ReName = new System.Windows.Forms.ToolStripMenuItem();
            this.SubCategory_Menu_SubToP = new System.Windows.Forms.ToolStripMenuItem();
            this.ok = new System.Windows.Forms.Button();
            this.subCategoryListView = new OLEREO.Control.oListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pCategoryListView = new OLEREO.Control.oListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.Pcategory_Menu.SuspendLayout();
            this.Scategory_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pcategory_Menu
            // 
            this.Pcategory_Menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Pcategory_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Pcategory_Menu_Add,
            this.Pcategory_Menu_Del,
            this.Pcategory_Menu_ReName,
            this.switchPtoS_MenuItem});
            this.Pcategory_Menu.Name = "Pcategory_Menu";
            this.Pcategory_Menu.Size = new System.Drawing.Size(149, 92);
            this.Pcategory_Menu.Opening += new System.ComponentModel.CancelEventHandler(this.Pcategory_Menu_Opening);
            // 
            // Pcategory_Menu_Add
            // 
            this.Pcategory_Menu_Add.Name = "Pcategory_Menu_Add";
            this.Pcategory_Menu_Add.Size = new System.Drawing.Size(148, 22);
            this.Pcategory_Menu_Add.Text = "新建父分类";
            this.Pcategory_Menu_Add.Click += new System.EventHandler(this.Pcategory_Menu_Add_Click);
            // 
            // Pcategory_Menu_Del
            // 
            this.Pcategory_Menu_Del.Name = "Pcategory_Menu_Del";
            this.Pcategory_Menu_Del.Size = new System.Drawing.Size(148, 22);
            this.Pcategory_Menu_Del.Text = "删除";
            this.Pcategory_Menu_Del.Click += new System.EventHandler(this.Pcategory_Menu_Del_Click);
            // 
            // Pcategory_Menu_ReName
            // 
            this.Pcategory_Menu_ReName.Name = "Pcategory_Menu_ReName";
            this.Pcategory_Menu_ReName.Size = new System.Drawing.Size(148, 22);
            this.Pcategory_Menu_ReName.Text = "修改名称";
            this.Pcategory_Menu_ReName.Click += new System.EventHandler(this.Pcategory_Menu_ReName_Click);
            // 
            // switchPtoS_MenuItem
            // 
            this.switchPtoS_MenuItem.Name = "switchPtoS_MenuItem";
            this.switchPtoS_MenuItem.Size = new System.Drawing.Size(148, 22);
            this.switchPtoS_MenuItem.Text = "转换成子分类";
            this.switchPtoS_MenuItem.Click += new System.EventHandler(this.switchPtoS_MenuItem_Click);
            // 
            // Scategory_Menu
            // 
            this.Scategory_Menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.Scategory_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubCategory_Menu_Add,
            this.SubCategory_Menu_Del,
            this.SubCategory_Menu_ReName,
            this.SubCategory_Menu_SubToP});
            this.Scategory_Menu.Name = "Scategory_Menu";
            this.Scategory_Menu.Size = new System.Drawing.Size(149, 92);
            this.Scategory_Menu.Opening += new System.ComponentModel.CancelEventHandler(this.Scategory_Menu_Opening);
            // 
            // SubCategory_Menu_Add
            // 
            this.SubCategory_Menu_Add.Name = "SubCategory_Menu_Add";
            this.SubCategory_Menu_Add.Size = new System.Drawing.Size(148, 22);
            this.SubCategory_Menu_Add.Text = "新建子分类";
            this.SubCategory_Menu_Add.Click += new System.EventHandler(this.SubCategory_Menu_Add_Click);
            // 
            // SubCategory_Menu_Del
            // 
            this.SubCategory_Menu_Del.Name = "SubCategory_Menu_Del";
            this.SubCategory_Menu_Del.Size = new System.Drawing.Size(148, 22);
            this.SubCategory_Menu_Del.Text = "删除";
            this.SubCategory_Menu_Del.Click += new System.EventHandler(this.SubCategory_Menu_Del_Click);
            // 
            // SubCategory_Menu_ReName
            // 
            this.SubCategory_Menu_ReName.Name = "SubCategory_Menu_ReName";
            this.SubCategory_Menu_ReName.Size = new System.Drawing.Size(148, 22);
            this.SubCategory_Menu_ReName.Text = "修改名称";
            this.SubCategory_Menu_ReName.Click += new System.EventHandler(this.SubCategory_Menu_ReName_Click);
            // 
            // SubCategory_Menu_SubToP
            // 
            this.SubCategory_Menu_SubToP.Name = "SubCategory_Menu_SubToP";
            this.SubCategory_Menu_SubToP.Size = new System.Drawing.Size(148, 22);
            this.SubCategory_Menu_SubToP.Text = "转换成父分类";
            this.SubCategory_Menu_SubToP.Click += new System.EventHandler(this.SubCategory_Menu_SubToP_Click);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(280, 258);
            this.ok.Margin = new System.Windows.Forms.Padding(2);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(94, 29);
            this.ok.TabIndex = 2;
            this.ok.Text = "完成";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // subCategoryListView
            // 
            this.subCategoryListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.subCategoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.subCategoryListView.ContextMenuStrip = this.Scategory_Menu;
            this.subCategoryListView.Enabled = false;
            this.subCategoryListView.EnabledColumnSort = false;
            this.subCategoryListView.EnabledDragItemAndDragFile = true;
            this.subCategoryListView.FullRowSelect = true;
            this.subCategoryListView.GridLines = true;
            this.subCategoryListView.HideSelection = false;
            this.subCategoryListView.HoldLastItemBackeColor = false;
            this.subCategoryListView.Location = new System.Drawing.Point(198, 6);
            this.subCategoryListView.Margin = new System.Windows.Forms.Padding(2);
            this.subCategoryListView.MultiSelect = false;
            this.subCategoryListView.Name = "subCategoryListView";
            this.subCategoryListView.Size = new System.Drawing.Size(176, 241);
            this.subCategoryListView.TabIndex = 1;
            this.subCategoryListView.UseCompatibleStateImageBehavior = false;
            this.subCategoryListView.View = System.Windows.Forms.View.Details;
            this.subCategoryListView.SortChangeEvent += new OLEREO.Control.oListView._SaveSortEvent(this.subCategoryListView_SortChangeEvent);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "子分类";
            this.columnHeader2.Width = 346;
            // 
            // pCategoryListView
            // 
            this.pCategoryListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pCategoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.pCategoryListView.ContextMenuStrip = this.Pcategory_Menu;
            this.pCategoryListView.EnabledColumnSort = false;
            this.pCategoryListView.EnabledDragItemAndDragFile = true;
            this.pCategoryListView.FullRowSelect = true;
            this.pCategoryListView.GridLines = true;
            this.pCategoryListView.HideSelection = false;
            this.pCategoryListView.HoldLastItemBackeColor = false;
            this.pCategoryListView.Location = new System.Drawing.Point(11, 6);
            this.pCategoryListView.Margin = new System.Windows.Forms.Padding(2);
            this.pCategoryListView.MultiSelect = false;
            this.pCategoryListView.Name = "pCategoryListView";
            this.pCategoryListView.Size = new System.Drawing.Size(176, 241);
            this.pCategoryListView.TabIndex = 0;
            this.pCategoryListView.UseCompatibleStateImageBehavior = false;
            this.pCategoryListView.View = System.Windows.Forms.View.Details;
            this.pCategoryListView.SortChangeEvent += new OLEREO.Control.oListView._SaveSortEvent(this.pCategoryListView_SortChangeEvent);
            this.pCategoryListView.SelectedIndexChanged += new System.EventHandler(this.pCategoryListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "父分类";
            this.columnHeader1.Width = 347;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "*右键列表获取更多选项。";
            // 
            // Manage
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 288);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.subCategoryListView);
            this.Controls.Add(this.pCategoryListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分类管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CategoryManage_FormClosed);
            this.Pcategory_Menu.ResumeLayout(false);
            this.Scategory_Menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private oListView pCategoryListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private oListView subCategoryListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip Pcategory_Menu;
        private System.Windows.Forms.ToolStripMenuItem Pcategory_Menu_Add;
        private System.Windows.Forms.ToolStripMenuItem Pcategory_Menu_Del;
        private System.Windows.Forms.ToolStripMenuItem Pcategory_Menu_ReName;
        private System.Windows.Forms.ContextMenuStrip Scategory_Menu;
        private System.Windows.Forms.ToolStripMenuItem SubCategory_Menu_Add;
        private System.Windows.Forms.ToolStripMenuItem SubCategory_Menu_Del;
        private System.Windows.Forms.ToolStripMenuItem SubCategory_Menu_ReName;
        private System.Windows.Forms.ToolStripMenuItem SubCategory_Menu_SubToP;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.ToolStripMenuItem switchPtoS_MenuItem;
        private System.Windows.Forms.Label label1;
    }
}