namespace ZIKU.Control.Variable
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
            this.VariableListview = new OLEREO.Control.oListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addVariableButton = new System.Windows.Forms.Button();
            this.delVariableButton = new System.Windows.Forms.Button();
            this.editVariable = new System.Windows.Forms.Button();
            this.dbPathLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VariableListview
            // 
            this.VariableListview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VariableListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3});
            this.VariableListview.EnabledColumnSort = false;
            this.VariableListview.EnabledDragItemAndDragFile = false;
            this.VariableListview.FullRowSelect = true;
            this.VariableListview.GridLines = true;
            this.VariableListview.HideSelection = false;
            this.VariableListview.HoldLastItemBackeColor = false;
            this.VariableListview.Location = new System.Drawing.Point(7, 12);
            this.VariableListview.MultiSelect = false;
            this.VariableListview.Name = "VariableListview";
            this.VariableListview.Size = new System.Drawing.Size(357, 178);
            this.VariableListview.TabIndex = 0;
            this.VariableListview.TabStop = false;
            this.VariableListview.UseCompatibleStateImageBehavior = false;
            this.VariableListview.View = System.Windows.Forms.View.Details;
            this.VariableListview.SelectedIndexChanged += new System.EventHandler(this.VariableListview_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "备注名称";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "变量名";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "变量值";
            this.columnHeader3.Width = 200;
            // 
            // addVariableButton
            // 
            this.addVariableButton.Location = new System.Drawing.Point(370, 12);
            this.addVariableButton.Name = "addVariableButton";
            this.addVariableButton.Size = new System.Drawing.Size(61, 50);
            this.addVariableButton.TabIndex = 1;
            this.addVariableButton.Text = "添加";
            this.addVariableButton.UseVisualStyleBackColor = true;
            this.addVariableButton.Click += new System.EventHandler(this.addVariableButton_Click);
            // 
            // delVariableButton
            // 
            this.delVariableButton.Enabled = false;
            this.delVariableButton.Location = new System.Drawing.Point(370, 136);
            this.delVariableButton.Name = "delVariableButton";
            this.delVariableButton.Size = new System.Drawing.Size(61, 50);
            this.delVariableButton.TabIndex = 3;
            this.delVariableButton.Text = "删除";
            this.delVariableButton.UseVisualStyleBackColor = true;
            this.delVariableButton.Click += new System.EventHandler(this.delVariableButton_Click);
            // 
            // editVariable
            // 
            this.editVariable.Enabled = false;
            this.editVariable.Location = new System.Drawing.Point(370, 74);
            this.editVariable.Name = "editVariable";
            this.editVariable.Size = new System.Drawing.Size(61, 50);
            this.editVariable.TabIndex = 2;
            this.editVariable.Text = "编辑";
            this.editVariable.UseVisualStyleBackColor = true;
            this.editVariable.Click += new System.EventHandler(this.editVariable_Click);
            // 
            // dbPathLabel
            // 
            this.dbPathLabel.AutoSize = true;
            this.dbPathLabel.Location = new System.Drawing.Point(8, 197);
            this.dbPathLabel.Name = "dbPathLabel";
            this.dbPathLabel.Size = new System.Drawing.Size(29, 12);
            this.dbPathLabel.TabIndex = 4;
            this.dbPathLabel.Text = "位于";
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 218);
            this.Controls.Add(this.dbPathLabel);
            this.Controls.Add(this.editVariable);
            this.Controls.Add(this.delVariableButton);
            this.Controls.Add(this.addVariableButton);
            this.Controls.Add(this.VariableListview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "内部变量管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OLEREO.Control.oListView VariableListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button addVariableButton;
        private System.Windows.Forms.Button delVariableButton;
        private System.Windows.Forms.Button editVariable;
        private System.Windows.Forms.Label dbPathLabel;
    }
}