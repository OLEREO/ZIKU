using OLEREO.Control;
namespace ZIKU.Control.Item
{
    partial class XiaoChao
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.valueBox = new OLEREO.Control.FloatingTextBox();
            this.argumentsBox = new OLEREO.Control.FloatingTextBox();
            this.introduceBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancetButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchAliasBox = new System.Windows.Forms.TextBox();
            this.copyIntroduce_Box = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Location = new System.Drawing.Point(42, 8);
            this.nameBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(128, 21);
            this.nameBox.TabIndex = 1;
            // 
            // valueBox
            // 
            this.valueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.valueBox.AutoSize = true;
            this.valueBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.valueBox.FloatingText = null;
            this.valueBox.HintText = "";
            this.valueBox.Location = new System.Drawing.Point(40, 35);
            this.valueBox.Margin = new System.Windows.Forms.Padding(2);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(284, 25);
            this.valueBox.TabIndex = 3;
            this.valueBox.text = "";
            this.valueBox.rButtonClicked += new OLEREO.Control.FloatingTextBox.BtnClickHandle(this.valueBox_rButtonClicked);
            // 
            // argumentsBox
            // 
            this.argumentsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.argumentsBox.AutoSize = true;
            this.argumentsBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.argumentsBox.FloatingText = null;
            this.argumentsBox.HintText = "";
            this.argumentsBox.Location = new System.Drawing.Point(64, 65);
            this.argumentsBox.Margin = new System.Windows.Forms.Padding(2);
            this.argumentsBox.Name = "argumentsBox";
            this.argumentsBox.Size = new System.Drawing.Size(260, 25);
            this.argumentsBox.TabIndex = 4;
            this.argumentsBox.text = "";
            this.argumentsBox.rButtonClicked += new OLEREO.Control.FloatingTextBox.BtnClickHandle(this.valueBox_rButtonClicked);
            // 
            // introduceBox
            // 
            this.introduceBox.Location = new System.Drawing.Point(6, 116);
            this.introduceBox.Margin = new System.Windows.Forms.Padding(2);
            this.introduceBox.Multiline = true;
            this.introduceBox.Name = "introduceBox";
            this.introduceBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.introduceBox.Size = new System.Drawing.Size(320, 88);
            this.introduceBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "主值：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "启动参数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "介绍：";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(6, 227);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(140, 40);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "保存";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancetButton
            // 
            this.CancetButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancetButton.Location = new System.Drawing.Point(191, 227);
            this.CancetButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancetButton.Name = "CancetButton";
            this.CancetButton.Size = new System.Drawing.Size(140, 40);
            this.CancetButton.TabIndex = 7;
            this.CancetButton.Text = "取消";
            this.CancetButton.UseVisualStyleBackColor = true;
            this.CancetButton.Click += new System.EventHandler(this.CancetButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "搜索别名：";
            // 
            // searchAliasBox
            // 
            this.searchAliasBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchAliasBox.Location = new System.Drawing.Point(242, 8);
            this.searchAliasBox.Margin = new System.Windows.Forms.Padding(2);
            this.searchAliasBox.Name = "searchAliasBox";
            this.searchAliasBox.Size = new System.Drawing.Size(82, 21);
            this.searchAliasBox.TabIndex = 2;
            // 
            // copyIntroduce_Box
            // 
            this.copyIntroduce_Box.AutoSize = true;
            this.copyIntroduce_Box.Location = new System.Drawing.Point(12, 209);
            this.copyIntroduce_Box.Name = "copyIntroduce_Box";
            this.copyIntroduce_Box.Size = new System.Drawing.Size(216, 16);
            this.copyIntroduce_Box.TabIndex = 14;
            this.copyIntroduce_Box.Text = "\"执行主值\"换成\"复制介绍到剪贴板\"";
            this.copyIntroduce_Box.UseVisualStyleBackColor = true;
            // 
            // XiaoChao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.CancetButton;
            this.ClientSize = new System.Drawing.Size(336, 275);
            this.Controls.Add(this.copyIntroduce_Box);
            this.Controls.Add(this.valueBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.searchAliasBox);
            this.Controls.Add(this.argumentsBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancetButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.introduceBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XiaoChao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "小抄";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private FloatingTextBox valueBox;
        private FloatingTextBox argumentsBox;
        private System.Windows.Forms.TextBox introduceBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancetButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchAliasBox;
        private System.Windows.Forms.CheckBox copyIntroduce_Box;
    }
}