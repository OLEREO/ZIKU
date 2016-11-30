using OLEREO.Control;

namespace ZIKU.Control
{
    partial class SearchForm
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
            this.SeBox = new System.Windows.Forms.TextBox();
            this.ItemIntroduce = new System.Windows.Forms.TextBox();
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.title_Label = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.seTypeComboBox = new System.Windows.Forms.ComboBox();
            this.listView1 = new OLEREO.Control.oListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SeBox
            // 
            this.SeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SeBox.Location = new System.Drawing.Point(11, 49);
            this.SeBox.Margin = new System.Windows.Forms.Padding(2);
            this.SeBox.Name = "SeBox";
            this.SeBox.Size = new System.Drawing.Size(216, 21);
            this.SeBox.TabIndex = 0;
            this.SeBox.TabStop = false;
            this.SeBox.TextChanged += new System.EventHandler(this.SeBox_TextChanged);
            this.SeBox.Enter += new System.EventHandler(this.SeBox_Enter);
            this.SeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SeBox_KeyDown);
            this.SeBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SeBox_KeyUp);
            // 
            // ItemIntroduce
            // 
            this.ItemIntroduce.Location = new System.Drawing.Point(7, 211);
            this.ItemIntroduce.Multiline = true;
            this.ItemIntroduce.Name = "ItemIntroduce";
            this.ItemIntroduce.ReadOnly = true;
            this.ItemIntroduce.Size = new System.Drawing.Size(311, 123);
            this.ItemIntroduce.TabIndex = 8;
            this.ItemIntroduce.TabStop = false;
            // 
            // IconBox
            // 
            this.IconBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.IconBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.IconBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IconBox.Location = new System.Drawing.Point(4, 3);
            this.IconBox.Margin = new System.Windows.Forms.Padding(2);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(40, 40);
            this.IconBox.TabIndex = 10;
            this.IconBox.TabStop = false;
            // 
            // title_Label
            // 
            this.title_Label.AutoSize = true;
            this.title_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.title_Label.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title_Label.Location = new System.Drawing.Point(51, 16);
            this.title_Label.Name = "title_Label";
            this.title_Label.Size = new System.Drawing.Size(58, 24);
            this.title_Label.TabIndex = 11;
            this.title_Label.Text = "搜索";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 300;
            // 
            // seTypeComboBox
            // 
            this.seTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seTypeComboBox.FormattingEnabled = true;
            this.seTypeComboBox.Location = new System.Drawing.Point(243, 50);
            this.seTypeComboBox.Name = "seTypeComboBox";
            this.seTypeComboBox.Size = new System.Drawing.Size(75, 20);
            this.seTypeComboBox.TabIndex = 12;
            this.seTypeComboBox.TabStop = false;
            this.seTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.seTypeComboBox_SelectedIndexChanged);
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listView1.EnabledColumnSort = false;
            this.listView1.EnabledDragItemAndDragFile = true;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.HoldLastItemBackeColor = false;
            this.listView1.Location = new System.Drawing.Point(11, 76);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(301, 153);
            this.listView1.TabIndex = 6;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DragFileOver += new OLEREO.Control.oListView.DragFile(this.listView1_DragFileOver);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 300;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImage = global::ZIKU.Properties.Resources.seBackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(842, 544);
            this.Controls.Add(this.seTypeComboBox);
            this.Controls.Add(this.ItemIntroduce);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.IconBox);
            this.Controls.Add(this.SeBox);
            this.Controls.Add(this.title_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Deactivate += new System.EventHandler(this.SearchForm_Deactivate);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseLeave += new System.EventHandler(this.Form_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SeBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox ItemIntroduce;
        private System.Windows.Forms.PictureBox IconBox;
        private System.Windows.Forms.Label title_Label;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private oListView listView1;
        private System.Windows.Forms.ComboBox seTypeComboBox;
    }
}