using OLEREO.Control;

namespace ZIKU.Control
{
    partial class SearchFormOle
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
            this.title_Label = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemBox9 = new OLEREO.Control.ItemBox();
            this.itemBox8 = new OLEREO.Control.ItemBox();
            this.itemBox7 = new OLEREO.Control.ItemBox();
            this.itemBox6 = new OLEREO.Control.ItemBox();
            this.itemBox5 = new OLEREO.Control.ItemBox();
            this.itemBox4 = new OLEREO.Control.ItemBox();
            this.itemBox3 = new OLEREO.Control.ItemBox();
            this.itemBox2 = new OLEREO.Control.ItemBox();
            this.itemBox1 = new OLEREO.Control.ItemBox();
            this.pageCountLabel = new System.Windows.Forms.Label();
            this.imeMode = new System.Windows.Forms.RadioButton();
            this.altMode = new System.Windows.Forms.RadioButton();
            this.NextPateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SeBox
            // 
            this.SeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.SeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SeBox.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SeBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.SeBox.Location = new System.Drawing.Point(9, 43);
            this.SeBox.Margin = new System.Windows.Forms.Padding(2);
            this.SeBox.Name = "SeBox";
            this.SeBox.Size = new System.Drawing.Size(699, 33);
            this.SeBox.TabIndex = 0;
            this.SeBox.TabStop = false;
            this.SeBox.Text = "seBoxKey";
            this.SeBox.TextChanged += new System.EventHandler(this.SeBox_TextChanged);
            this.SeBox.Enter += new System.EventHandler(this.SeBox_Enter);
            this.SeBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SeBox_KeyDown);
            this.SeBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SeBox_KeyPress);
            this.SeBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SeBox_KeyUp);
            // 
            // ItemIntroduce
            // 
            this.ItemIntroduce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.ItemIntroduce.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ItemIntroduce.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ItemIntroduce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ItemIntroduce.Location = new System.Drawing.Point(9, 81);
            this.ItemIntroduce.Multiline = true;
            this.ItemIntroduce.Name = "ItemIntroduce";
            this.ItemIntroduce.ReadOnly = true;
            this.ItemIntroduce.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ItemIntroduce.Size = new System.Drawing.Size(700, 96);
            this.ItemIntroduce.TabIndex = 8;
            this.ItemIntroduce.TabStop = false;
            this.ItemIntroduce.Text = "introduce";
            // 
            // title_Label
            // 
            this.title_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.title_Label.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title_Label.ForeColor = System.Drawing.Color.Gainsboro;
            this.title_Label.Location = new System.Drawing.Point(3, 6);
            this.title_Label.Name = "title_Label";
            this.title_Label.Size = new System.Drawing.Size(710, 32);
            this.title_Label.TabIndex = 11;
            this.title_Label.Text = "搜索";
            this.title_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 300;
            // 
            // itemBox9
            // 
            this.itemBox9.AllowDrop = true;
            this.itemBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.itemBox9.Location = new System.Drawing.Point(9, 510);
            this.itemBox9.Name = "itemBox9";
            this.itemBox9.Number = "9";
            this.itemBox9.Size = new System.Drawing.Size(700, 40);
            this.itemBox9.TabIndex = 21;
            this.itemBox9.DragFileDrop += new OLEREO.Control.ItemBox._DragFile(this.itemBox_DragFileDrop);
            this.itemBox9.ExecuteEvent += new OLEREO.Control.ItemBox._Execute(this.itemBox_ExecuteEvent);
            this.itemBox9.Enter += new System.EventHandler(this.itemBox_Enter);
            this.itemBox9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemBox_KeyDown);
            this.itemBox9.Leave += new System.EventHandler(this.itemBox_Leave);
            this.itemBox9.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemBox_MouseClick);
            // 
            // itemBox8
            // 
            this.itemBox8.AllowDrop = true;
            this.itemBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.itemBox8.Location = new System.Drawing.Point(9, 469);
            this.itemBox8.Name = "itemBox8";
            this.itemBox8.Number = "8";
            this.itemBox8.Size = new System.Drawing.Size(700, 40);
            this.itemBox8.TabIndex = 20;
            this.itemBox8.DragFileDrop += new OLEREO.Control.ItemBox._DragFile(this.itemBox_DragFileDrop);
            this.itemBox8.ExecuteEvent += new OLEREO.Control.ItemBox._Execute(this.itemBox_ExecuteEvent);
            this.itemBox8.Enter += new System.EventHandler(this.itemBox_Enter);
            this.itemBox8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemBox_KeyDown);
            this.itemBox8.Leave += new System.EventHandler(this.itemBox_Leave);
            this.itemBox8.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemBox_MouseClick);
            // 
            // itemBox7
            // 
            this.itemBox7.AllowDrop = true;
            this.itemBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.itemBox7.Location = new System.Drawing.Point(9, 428);
            this.itemBox7.Name = "itemBox7";
            this.itemBox7.Number = "7";
            this.itemBox7.Size = new System.Drawing.Size(700, 40);
            this.itemBox7.TabIndex = 19;
            this.itemBox7.DragFileDrop += new OLEREO.Control.ItemBox._DragFile(this.itemBox_DragFileDrop);
            this.itemBox7.ExecuteEvent += new OLEREO.Control.ItemBox._Execute(this.itemBox_ExecuteEvent);
            this.itemBox7.Enter += new System.EventHandler(this.itemBox_Enter);
            this.itemBox7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemBox_KeyDown);
            this.itemBox7.Leave += new System.EventHandler(this.itemBox_Leave);
            this.itemBox7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemBox_MouseClick);
            // 
            // itemBox6
            // 
            this.itemBox6.AllowDrop = true;
            this.itemBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.itemBox6.Location = new System.Drawing.Point(9, 387);
            this.itemBox6.Name = "itemBox6";
            this.itemBox6.Number = "6";
            this.itemBox6.Size = new System.Drawing.Size(700, 40);
            this.itemBox6.TabIndex = 18;
            this.itemBox6.DragFileDrop += new OLEREO.Control.ItemBox._DragFile(this.itemBox_DragFileDrop);
            this.itemBox6.ExecuteEvent += new OLEREO.Control.ItemBox._Execute(this.itemBox_ExecuteEvent);
            this.itemBox6.Enter += new System.EventHandler(this.itemBox_Enter);
            this.itemBox6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemBox_KeyDown);
            this.itemBox6.Leave += new System.EventHandler(this.itemBox_Leave);
            this.itemBox6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemBox_MouseClick);
            // 
            // itemBox5
            // 
            this.itemBox5.AllowDrop = true;
            this.itemBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.itemBox5.Location = new System.Drawing.Point(9, 346);
            this.itemBox5.Name = "itemBox5";
            this.itemBox5.Number = "5";
            this.itemBox5.Size = new System.Drawing.Size(700, 40);
            this.itemBox5.TabIndex = 17;
            this.itemBox5.DragFileDrop += new OLEREO.Control.ItemBox._DragFile(this.itemBox_DragFileDrop);
            this.itemBox5.ExecuteEvent += new OLEREO.Control.ItemBox._Execute(this.itemBox_ExecuteEvent);
            this.itemBox5.Enter += new System.EventHandler(this.itemBox_Enter);
            this.itemBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemBox_KeyDown);
            this.itemBox5.Leave += new System.EventHandler(this.itemBox_Leave);
            this.itemBox5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemBox_MouseClick);
            // 
            // itemBox4
            // 
            this.itemBox4.AllowDrop = true;
            this.itemBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.itemBox4.Location = new System.Drawing.Point(9, 305);
            this.itemBox4.Name = "itemBox4";
            this.itemBox4.Number = "4";
            this.itemBox4.Size = new System.Drawing.Size(700, 40);
            this.itemBox4.TabIndex = 16;
            this.itemBox4.DragFileDrop += new OLEREO.Control.ItemBox._DragFile(this.itemBox_DragFileDrop);
            this.itemBox4.ExecuteEvent += new OLEREO.Control.ItemBox._Execute(this.itemBox_ExecuteEvent);
            this.itemBox4.Enter += new System.EventHandler(this.itemBox_Enter);
            this.itemBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemBox_KeyDown);
            this.itemBox4.Leave += new System.EventHandler(this.itemBox_Leave);
            this.itemBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemBox_MouseClick);
            // 
            // itemBox3
            // 
            this.itemBox3.AllowDrop = true;
            this.itemBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.itemBox3.Location = new System.Drawing.Point(9, 264);
            this.itemBox3.Name = "itemBox3";
            this.itemBox3.Number = "3";
            this.itemBox3.Size = new System.Drawing.Size(700, 40);
            this.itemBox3.TabIndex = 15;
            this.itemBox3.DragFileDrop += new OLEREO.Control.ItemBox._DragFile(this.itemBox_DragFileDrop);
            this.itemBox3.ExecuteEvent += new OLEREO.Control.ItemBox._Execute(this.itemBox_ExecuteEvent);
            this.itemBox3.Enter += new System.EventHandler(this.itemBox_Enter);
            this.itemBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemBox_KeyDown);
            this.itemBox3.Leave += new System.EventHandler(this.itemBox_Leave);
            this.itemBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemBox_MouseClick);
            // 
            // itemBox2
            // 
            this.itemBox2.AllowDrop = true;
            this.itemBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.itemBox2.Location = new System.Drawing.Point(9, 223);
            this.itemBox2.Name = "itemBox2";
            this.itemBox2.Number = "2";
            this.itemBox2.Size = new System.Drawing.Size(700, 40);
            this.itemBox2.TabIndex = 14;
            this.itemBox2.DragFileDrop += new OLEREO.Control.ItemBox._DragFile(this.itemBox_DragFileDrop);
            this.itemBox2.ExecuteEvent += new OLEREO.Control.ItemBox._Execute(this.itemBox_ExecuteEvent);
            this.itemBox2.Enter += new System.EventHandler(this.itemBox_Enter);
            this.itemBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemBox_KeyDown);
            this.itemBox2.Leave += new System.EventHandler(this.itemBox_Leave);
            this.itemBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemBox_MouseClick);
            // 
            // itemBox1
            // 
            this.itemBox1.AllowDrop = true;
            this.itemBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.itemBox1.Location = new System.Drawing.Point(9, 182);
            this.itemBox1.Name = "itemBox1";
            this.itemBox1.Number = "1";
            this.itemBox1.Size = new System.Drawing.Size(700, 40);
            this.itemBox1.TabIndex = 13;
            this.itemBox1.DragFileDrop += new OLEREO.Control.ItemBox._DragFile(this.itemBox_DragFileDrop);
            this.itemBox1.ExecuteEvent += new OLEREO.Control.ItemBox._Execute(this.itemBox_ExecuteEvent);
            this.itemBox1.Enter += new System.EventHandler(this.itemBox_Enter);
            this.itemBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemBox_KeyDown);
            this.itemBox1.Leave += new System.EventHandler(this.itemBox_Leave);
            this.itemBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemBox_MouseClick);
            // 
            // pageCountLabel
            // 
            this.pageCountLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pageCountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.pageCountLabel.Location = new System.Drawing.Point(630, 50);
            this.pageCountLabel.Name = "pageCountLabel";
            this.pageCountLabel.Size = new System.Drawing.Size(77, 21);
            this.pageCountLabel.TabIndex = 22;
            this.pageCountLabel.Text = "0";
            this.pageCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imeMode
            // 
            this.imeMode.AutoSize = true;
            this.imeMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.imeMode.ForeColor = System.Drawing.Color.Gainsboro;
            this.imeMode.Location = new System.Drawing.Point(630, 24);
            this.imeMode.Name = "imeMode";
            this.imeMode.Size = new System.Drawing.Size(83, 16);
            this.imeMode.TabIndex = 26;
            this.imeMode.Text = "输入法模式";
            this.imeMode.UseVisualStyleBackColor = false;
            // 
            // altMode
            // 
            this.altMode.AutoSize = true;
            this.altMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.altMode.Checked = true;
            this.altMode.ForeColor = System.Drawing.Color.Gainsboro;
            this.altMode.Location = new System.Drawing.Point(630, 8);
            this.altMode.Name = "altMode";
            this.altMode.Size = new System.Drawing.Size(71, 16);
            this.altMode.TabIndex = 27;
            this.altMode.TabStop = true;
            this.altMode.Text = "ALT 模式";
            this.altMode.UseVisualStyleBackColor = false;
            this.altMode.CheckedChanged += new System.EventHandler(this.altMode_CheckedChanged);
            // 
            // NextPateButton
            // 
            this.NextPateButton.Location = new System.Drawing.Point(143, 108);
            this.NextPateButton.Name = "NextPateButton";
            this.NextPateButton.Size = new System.Drawing.Size(75, 23);
            this.NextPateButton.TabIndex = 23;
            this.NextPateButton.TabStop = false;
            this.NextPateButton.Text = "(&=)";
            this.NextPateButton.UseVisualStyleBackColor = true;
            this.NextPateButton.Enter += new System.EventHandler(this.NextPateButton_Enter);
            // 
            // SearchFormOle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::ZIKU.Properties.Resources.SearchBackGround;
            this.ClientSize = new System.Drawing.Size(720, 560);
            this.Controls.Add(this.altMode);
            this.Controls.Add(this.pageCountLabel);
            this.Controls.Add(this.itemBox9);
            this.Controls.Add(this.itemBox8);
            this.Controls.Add(this.itemBox7);
            this.Controls.Add(this.itemBox6);
            this.Controls.Add(this.itemBox5);
            this.Controls.Add(this.itemBox4);
            this.Controls.Add(this.itemBox3);
            this.Controls.Add(this.itemBox2);
            this.Controls.Add(this.itemBox1);
            this.Controls.Add(this.imeMode);
            this.Controls.Add(this.title_Label);
            this.Controls.Add(this.SeBox);
            this.Controls.Add(this.ItemIntroduce);
            this.Controls.Add(this.NextPateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SearchFormOle";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZIKUSearch";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Deactivate += new System.EventHandler(this.SearchForm_Deactivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchFormOle_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseLeave += new System.EventHandler(this.Form_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SeBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox ItemIntroduce;
        private System.Windows.Forms.Label title_Label;
        private ItemBox itemBox1;
        private ItemBox itemBox2;
        private ItemBox itemBox3;
        private ItemBox itemBox4;
        private ItemBox itemBox5;
        private ItemBox itemBox6;
        private ItemBox itemBox7;
        private ItemBox itemBox8;
        private ItemBox itemBox9;
        private System.Windows.Forms.Label pageCountLabel;
        private System.Windows.Forms.RadioButton imeMode;
        private System.Windows.Forms.RadioButton altMode;
        private System.Windows.Forms.Button NextPateButton;
    }
}