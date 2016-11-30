namespace ZIKU.Control.Item
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
            this.itemList = new OLEREO.Control.oListView();
            this.checkItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.idItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.okButton = new System.Windows.Forms.Button();
            this.introduceBox = new System.Windows.Forms.TextBox();
            this.iCategory = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectItemList = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectItemMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelSelectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.seBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectItemMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemList
            // 
            this.itemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.checkItem,
            this.idItem,
            this.nameItem});
            this.itemList.EnabledColumnSort = true;
            this.itemList.EnabledDragItemAndDragFile = false;
            this.itemList.FullRowSelect = true;
            this.itemList.GridLines = true;
            this.itemList.HideSelection = false;
            this.itemList.HoldLastItemBackeColor = false;
            this.itemList.Location = new System.Drawing.Point(5, 29);
            this.itemList.Margin = new System.Windows.Forms.Padding(2);
            this.itemList.MultiSelect = false;
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(295, 231);
            this.itemList.TabIndex = 0;
            this.itemList.TabStop = false;
            this.itemList.UseCompatibleStateImageBehavior = false;
            this.itemList.View = System.Windows.Forms.View.Details;
            this.itemList.SelectedIndexChanged += new System.EventHandler(this.itemList_SelectedIndexChanged);
            this.itemList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemList_MouseClick);
            this.itemList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.itemList_MouseDoubleClick);
            // 
            // checkItem
            // 
            this.checkItem.Text = "勾选";
            this.checkItem.Width = 1;
            // 
            // idItem
            // 
            this.idItem.Text = "UID";
            this.idItem.Width = 40;
            // 
            // nameItem
            // 
            this.nameItem.Text = "项目名称";
            this.nameItem.Width = 240;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(304, 342);
            this.okButton.Margin = new System.Windows.Forms.Padding(2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(101, 29);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "保存";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // introduceBox
            // 
            this.introduceBox.Location = new System.Drawing.Point(5, 264);
            this.introduceBox.Margin = new System.Windows.Forms.Padding(2);
            this.introduceBox.Multiline = true;
            this.introduceBox.Name = "introduceBox";
            this.introduceBox.ReadOnly = true;
            this.introduceBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.introduceBox.Size = new System.Drawing.Size(295, 107);
            this.introduceBox.TabIndex = 8;
            this.introduceBox.TabStop = false;
            // 
            // iCategory
            // 
            this.iCategory.Location = new System.Drawing.Point(304, 29);
            this.iCategory.Margin = new System.Windows.Forms.Padding(2);
            this.iCategory.Multiline = true;
            this.iCategory.Name = "iCategory";
            this.iCategory.ReadOnly = true;
            this.iCategory.Size = new System.Drawing.Size(101, 272);
            this.iCategory.TabIndex = 10;
            this.iCategory.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(304, 308);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 29);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // selectItemList
            // 
            this.selectItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.selectItemList.ContextMenuStrip = this.selectItemMenuStrip;
            this.selectItemList.FullRowSelect = true;
            this.selectItemList.GridLines = true;
            this.selectItemList.Location = new System.Drawing.Point(410, 4);
            this.selectItemList.Margin = new System.Windows.Forms.Padding(2);
            this.selectItemList.MultiSelect = false;
            this.selectItemList.Name = "selectItemList";
            this.selectItemList.Size = new System.Drawing.Size(139, 367);
            this.selectItemList.TabIndex = 13;
            this.selectItemList.TabStop = false;
            this.selectItemList.UseCompatibleStateImageBehavior = false;
            this.selectItemList.View = System.Windows.Forms.View.Details;
            this.selectItemList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.selectItemList_MouseClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "UID";
            this.columnHeader5.Width = 30;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "项目名称";
            this.columnHeader6.Width = 200;
            // 
            // selectItemMenuStrip
            // 
            this.selectItemMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelSelectMenuItem});
            this.selectItemMenuStrip.Name = "selectItemMenuStrip";
            this.selectItemMenuStrip.Size = new System.Drawing.Size(161, 26);
            // 
            // cancelSelectMenuItem
            // 
            this.cancelSelectMenuItem.Name = "cancelSelectMenuItem";
            this.cancelSelectMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cancelSelectMenuItem.Text = "取消选择该项目";
            this.cancelSelectMenuItem.Click += new System.EventHandler(this.cancelSelectMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "归属分类：";
            // 
            // seBox
            // 
            this.seBox.Location = new System.Drawing.Point(41, 5);
            this.seBox.Name = "seBox";
            this.seBox.Size = new System.Drawing.Size(240, 21);
            this.seBox.TabIndex = 1;
            this.seBox.TextChanged += new System.EventHandler(this.seBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "搜索：";
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(552, 376);
            this.Controls.Add(this.itemList);
            this.Controls.Add(this.seBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectItemList);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.iCategory);
            this.Controls.Add(this.introduceBox);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目管理";
            this.selectItemMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OLEREO.Control.oListView itemList;
        private System.Windows.Forms.ColumnHeader idItem;
        private System.Windows.Forms.ColumnHeader nameItem;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox introduceBox;
        private System.Windows.Forms.TextBox iCategory;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ColumnHeader checkItem;
        private System.Windows.Forms.ListView selectItemList;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenuStrip selectItemMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cancelSelectMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox seBox;
        private System.Windows.Forms.Label label2;
    }
}