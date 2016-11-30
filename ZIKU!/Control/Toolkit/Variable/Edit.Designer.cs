namespace ZIKU.Control.Variable
{
    partial class Edit
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
            this.Cancel = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.varName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.varUidPrefix = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.varUID = new OLEREO.Control.oTextBox();
            this.varPath = new OLEREO.Control.FloatingTextBox();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(138, 93);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(110, 42);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(6, 93);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(110, 42);
            this.Save.TabIndex = 4;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "变量值：";
            // 
            // varName
            // 
            this.varName.Location = new System.Drawing.Point(74, 6);
            this.varName.Name = "varName";
            this.varName.Size = new System.Drawing.Size(217, 21);
            this.varName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "备注名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "%";
            // 
            // varUidPrefix
            // 
            this.varUidPrefix.AutoSize = true;
            this.varUidPrefix.Location = new System.Drawing.Point(6, 37);
            this.varUidPrefix.Name = "varUidPrefix";
            this.varUidPrefix.Size = new System.Drawing.Size(59, 12);
            this.varUidPrefix.TabIndex = 12;
            this.varUidPrefix.Text = "变量名：%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "*注：\"全局变量\"中无法引用\"数据库变量\"。";
            // 
            // varUID
            // 
            this.varUID.HintText = "字母/数字/连接符\"-\"";
            this.varUID.Location = new System.Drawing.Point(76, 33);
            this.varUID.Name = "varUID";
            this.varUID.Size = new System.Drawing.Size(217, 21);
            this.varUID.TabIndex = 2;
            // 
            // varPath
            // 
            this.varPath.AutoSize = true;
            this.varPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.varPath.FloatingText = null;
            this.varPath.HintText = "";
            this.varPath.Location = new System.Drawing.Point(74, 60);
            this.varPath.Name = "varPath";
            this.varPath.Size = new System.Drawing.Size(273, 27);
            this.varPath.TabIndex = 3;
            this.varPath.text = "";
            this.varPath.rButtonClicked += new OLEREO.Control.FloatingTextBox.BtnClickHandle(this.varPath_rButtonClicked);
            // 
            // Edit
            // 
            this.AcceptButton = this.Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(354, 162);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.varUID);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.varPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.varName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.varUidPrefix);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "变量编辑";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Save;
        private OLEREO.Control.FloatingTextBox varPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox varName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label varUidPrefix;
        private OLEREO.Control.oTextBox varUID;
        private System.Windows.Forms.Label label1;
    }
}