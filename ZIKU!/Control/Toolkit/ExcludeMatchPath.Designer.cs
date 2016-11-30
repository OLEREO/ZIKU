namespace ZIKU.Control.Toolkit
{
    partial class ExcludeMatchPath
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
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeExclude_Menu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.columnHeader1});
            this.oListView1.ContextMenuStrip = this.menu;
            this.oListView1.EnabledColumnSort = false;
            this.oListView1.EnabledDragItemAndDragFile = false;
            this.oListView1.FullRowSelect = true;
            this.oListView1.GridLines = true;
            this.oListView1.HideSelection = false;
            this.oListView1.HoldLastItemBackeColor = false;
            this.oListView1.Location = new System.Drawing.Point(2, 1);
            this.oListView1.MultiSelect = false;
            this.oListView1.Name = "oListView1";
            this.oListView1.Size = new System.Drawing.Size(279, 260);
            this.oListView1.TabIndex = 0;
            this.oListView1.UseCompatibleStateImageBehavior = false;
            this.oListView1.View = System.Windows.Forms.View.Details;
            this.oListView1.SizeChanged += new System.EventHandler(this.oListView1_SizeChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "目标路径";
            this.columnHeader1.Width = 270;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeExclude_Menu});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(149, 26);
            this.menu.Opening += new System.ComponentModel.CancelEventHandler(this.menu_Opening);
            // 
            // removeExclude_Menu
            // 
            this.removeExclude_Menu.Name = "removeExclude_Menu";
            this.removeExclude_Menu.Size = new System.Drawing.Size(148, 22);
            this.removeExclude_Menu.Text = "移出排除列表";
            this.removeExclude_Menu.Click += new System.EventHandler(this.removeExclude_Menu_Click);
            // 
            // ExcludeMatchPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 263);
            this.Controls.Add(this.oListView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcludeMatchPath";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "已经排除的匹配目录";
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OLEREO.Control.oListView oListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem removeExclude_Menu;
    }
}