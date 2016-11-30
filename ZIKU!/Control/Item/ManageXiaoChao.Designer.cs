namespace ZIKU.Control.Item
{
    partial class ManageXiaoChao
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
            this.menus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addXC_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.editXC_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.delXC_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.menus.SuspendLayout();
            this.SuspendLayout();
            // 
            // oListView1
            // 
            this.oListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.oListView1.ContextMenuStrip = this.menus;
            this.oListView1.EnabledColumnSort = false;
            this.oListView1.EnabledDragItemAndDragFile = false;
            this.oListView1.FullRowSelect = true;
            this.oListView1.GridLines = true;
            this.oListView1.HideSelection = false;
            this.oListView1.HoldLastItemBackeColor = false;
            this.oListView1.Location = new System.Drawing.Point(3, 6);
            this.oListView1.MultiSelect = false;
            this.oListView1.Name = "oListView1";
            this.oListView1.Size = new System.Drawing.Size(308, 301);
            this.oListView1.TabIndex = 0;
            this.oListView1.UseCompatibleStateImageBehavior = false;
            this.oListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "小抄名称";
            this.columnHeader1.Width = 300;
            // 
            // menus
            // 
            this.menus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addXC_Menu,
            this.editXC_Menu,
            this.delXC_Menu});
            this.menus.Name = "menus";
            this.menus.Size = new System.Drawing.Size(153, 92);
            this.menus.Opening += new System.ComponentModel.CancelEventHandler(this.menus_Opening);
            // 
            // addXC_Menu
            // 
            this.addXC_Menu.Name = "addXC_Menu";
            this.addXC_Menu.Size = new System.Drawing.Size(152, 22);
            this.addXC_Menu.Text = "添加小抄";
            this.addXC_Menu.Click += new System.EventHandler(this.addXC_Menu_Click);
            // 
            // editXC_Menu
            // 
            this.editXC_Menu.Name = "editXC_Menu";
            this.editXC_Menu.Size = new System.Drawing.Size(152, 22);
            this.editXC_Menu.Text = "编辑该小抄";
            this.editXC_Menu.Click += new System.EventHandler(this.editXC_Menu_Click);
            // 
            // delXC_Menu
            // 
            this.delXC_Menu.Name = "delXC_Menu";
            this.delXC_Menu.Size = new System.Drawing.Size(152, 22);
            this.delXC_Menu.Text = "删除该小抄";
            this.delXC_Menu.Click += new System.EventHandler(this.delXC_Menu_Click);
            // 
            // ManageXiaoChao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 319);
            this.Controls.Add(this.oListView1);
            this.Name = "ManageXiaoChao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理小抄";
            this.menus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OLEREO.Control.oListView oListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip menus;
        private System.Windows.Forms.ToolStripMenuItem addXC_Menu;
        private System.Windows.Forms.ToolStripMenuItem editXC_Menu;
        private System.Windows.Forms.ToolStripMenuItem delXC_Menu;
    }
}