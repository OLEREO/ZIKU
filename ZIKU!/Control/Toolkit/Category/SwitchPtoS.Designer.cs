namespace ZIKU.Control.Category
{
    partial class SwitchPtoS
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
            this.oListView1 = new OLEREO.Control.oListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.ok_Button = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // oListView1
            // 
            this.oListView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.oListView1.EnabledColumnSort = false;
            this.oListView1.EnabledDragItemAndDragFile = false;
            this.oListView1.FullRowSelect = true;
            this.oListView1.GridLines = true;
            this.oListView1.HideSelection = false;
            this.oListView1.HoldLastItemBackeColor = true;
            this.oListView1.Location = new System.Drawing.Point(8, 44);
            this.oListView1.MultiSelect = false;
            this.oListView1.Name = "oListView1";
            this.oListView1.Size = new System.Drawing.Size(212, 161);
            this.oListView1.TabIndex = 0;
            this.oListView1.UseCompatibleStateImageBehavior = false;
            this.oListView1.View = System.Windows.Forms.View.Details;
            this.oListView1.SelectedIndexChanged += new System.EventHandler(this.oListView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "父分类";
            this.columnHeader1.Width = 200;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "转成子分类的同时，该分类下原有的子分类，将全部转换成为父分类。";
            // 
            // ok_Button
            // 
            this.ok_Button.Enabled = false;
            this.ok_Button.Location = new System.Drawing.Point(8, 211);
            this.ok_Button.Name = "ok_Button";
            this.ok_Button.Size = new System.Drawing.Size(75, 39);
            this.ok_Button.TabIndex = 2;
            this.ok_Button.Text = "确定选择";
            this.ok_Button.UseVisualStyleBackColor = true;
            this.ok_Button.Click += new System.EventHandler(this.ok_Button_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(145, 211);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 39);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "取消转换";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // SwitchPtoS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(232, 262);
            this.Controls.Add(this.oListView1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok_Button);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SwitchPtoS";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转换成为子分类";
            this.ResumeLayout(false);

        }

        #endregion

        private OLEREO.Control.oListView oListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ok_Button;
        private System.Windows.Forms.Button cancel;
    }
}