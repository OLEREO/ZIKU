namespace ZIKU.Control.Toolkit
{
    partial class ReplaceItemValue
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
            this.originalValue_Box = new System.Windows.Forms.TextBox();
            this.replaceValue_Box = new System.Windows.Forms.TextBox();
            this.search_Box = new System.Windows.Forms.Button();
            this.oListView1 = new OLEREO.Control.oListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editItem_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceSelect_Box = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menus.SuspendLayout();
            this.SuspendLayout();
            // 
            // originalValue_Box
            // 
            this.originalValue_Box.Location = new System.Drawing.Point(53, 12);
            this.originalValue_Box.Name = "originalValue_Box";
            this.originalValue_Box.Size = new System.Drawing.Size(186, 21);
            this.originalValue_Box.TabIndex = 0;
//            this.originalValue_Box.TextChanged += new System.EventHandler(this.originalValue_Box_TextChanged);
            this.originalValue_Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.originalValue_Box_KeyDown);
            // 
            // replaceValue_Box
            // 
            this.replaceValue_Box.Location = new System.Drawing.Point(431, 12);
            this.replaceValue_Box.Name = "replaceValue_Box";
            this.replaceValue_Box.Size = new System.Drawing.Size(167, 21);
            this.replaceValue_Box.TabIndex = 2;
            // 
            // search_Box
            // 
            this.search_Box.Location = new System.Drawing.Point(245, 11);
            this.search_Box.Name = "search_Box";
            this.search_Box.Size = new System.Drawing.Size(91, 23);
            this.search_Box.TabIndex = 1;
            this.search_Box.Text = "查找";
            this.search_Box.UseVisualStyleBackColor = true;
            this.search_Box.Click += new System.EventHandler(this.search_Box_Click);
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
            this.columnHeader4});
            this.oListView1.ContextMenuStrip = this.menus;
            this.oListView1.EnabledColumnSort = false;
            this.oListView1.EnabledDragItemAndDragFile = false;
            this.oListView1.FullRowSelect = true;
            this.oListView1.GridLines = true;
            this.oListView1.HideSelection = false;
            this.oListView1.HoldLastItemBackeColor = false;
            this.oListView1.Location = new System.Drawing.Point(6, 52);
            this.oListView1.MultiSelect = false;
            this.oListView1.Name = "oListView1";
            this.oListView1.Size = new System.Drawing.Size(698, 477);
            this.oListView1.TabIndex = 3;
            this.oListView1.TabStop = false;
            this.oListView1.UseCompatibleStateImageBehavior = false;
            this.oListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "值类型";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "值";
            this.columnHeader4.Width = 450;
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
            // replaceSelect_Box
            // 
            this.replaceSelect_Box.Location = new System.Drawing.Point(604, 11);
            this.replaceSelect_Box.Name = "replaceSelect_Box";
            this.replaceSelect_Box.Size = new System.Drawing.Size(91, 23);
            this.replaceSelect_Box.TabIndex = 3;
            this.replaceSelect_Box.Text = "替换选中";
            this.replaceSelect_Box.UseVisualStyleBackColor = true;
            this.replaceSelect_Box.Click += new System.EventHandler(this.replaceSelect_Box_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "替换为：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "搜索值：";
            // 
            // ReplaceItemValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 538);
            this.Controls.Add(this.replaceValue_Box);
            this.Controls.Add(this.originalValue_Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.replaceSelect_Box);
            this.Controls.Add(this.oListView1);
            this.Controls.Add(this.search_Box);
            this.Name = "ReplaceItemValue";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "替换项目的主值";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReplaceItemValue_FormClosing);
            this.menus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox originalValue_Box;
        private System.Windows.Forms.TextBox replaceValue_Box;
        private System.Windows.Forms.Button search_Box;
        private OLEREO.Control.oListView oListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button replaceSelect_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip menus;
        private System.Windows.Forms.ToolStripMenuItem editItem_Menu;
    }
}