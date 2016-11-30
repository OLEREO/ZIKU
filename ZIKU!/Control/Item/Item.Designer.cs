namespace ZIKU.Control.Item
{
    partial class Item
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
            this.ItemIconBox = new System.Windows.Forms.PictureBox();
            this.versionBox = new System.Windows.Forms.TextBox();
            this.introBox = new System.Windows.Forms.TextBox();
            this.introduceBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.value_Text = new System.Windows.Forms.LinkLabel();
            this.arguments_Text = new System.Windows.Forms.LinkLabel();
            this.categoryBox = new System.Windows.Forms.TreeView();
            this.workingDir_Text = new System.Windows.Forms.LinkLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.searchAliasBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.iPath_Text = new System.Windows.Forms.LinkLabel();
            this.x86Value_Text = new System.Windows.Forms.LinkLabel();
            this.x64Value_Text = new System.Windows.Forms.LinkLabel();
            this.homePageBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.item_Hide_main = new System.Windows.Forms.CheckBox();
            this.item_Hide_search = new System.Windows.Forms.CheckBox();
            this.iv_x64_BOX = new OLEREO.Control.FloatingTextBox();
            this.iv_x86_BOX = new OLEREO.Control.FloatingTextBox();
            this.workingdirBox = new OLEREO.Control.FloatingTextBox();
            this.iPath_BOX = new OLEREO.Control.FloatingTextBox();
            this.argumentsBox = new OLEREO.Control.FloatingTextBox();
            this.valueBox = new OLEREO.Control.FloatingTextBox();
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.iconLabel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.UIDBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.onAdminBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.iconBox = new OLEREO.Control.FloatingTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ItemIconBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemIconBox
            // 
            this.ItemIconBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ItemIconBox.Location = new System.Drawing.Point(10, 9);
            this.ItemIconBox.Margin = new System.Windows.Forms.Padding(2);
            this.ItemIconBox.Name = "ItemIconBox";
            this.ItemIconBox.Size = new System.Drawing.Size(40, 40);
            this.ItemIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ItemIconBox.TabIndex = 0;
            this.ItemIconBox.TabStop = false;
            // 
            // versionBox
            // 
            this.versionBox.Location = new System.Drawing.Point(410, 8);
            this.versionBox.Margin = new System.Windows.Forms.Padding(2);
            this.versionBox.Name = "versionBox";
            this.versionBox.Size = new System.Drawing.Size(95, 21);
            this.versionBox.TabIndex = 4;
            // 
            // introBox
            // 
            this.introBox.Location = new System.Drawing.Point(44, 55);
            this.introBox.Margin = new System.Windows.Forms.Padding(2);
            this.introBox.Name = "introBox";
            this.introBox.Size = new System.Drawing.Size(617, 21);
            this.introBox.TabIndex = 5;
            // 
            // introduceBox
            // 
            this.introduceBox.Location = new System.Drawing.Point(9, 93);
            this.introduceBox.Margin = new System.Windows.Forms.Padding(2);
            this.introduceBox.Multiline = true;
            this.introduceBox.Name = "introduceBox";
            this.introduceBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.introduceBox.Size = new System.Drawing.Size(480, 227);
            this.introduceBox.TabIndex = 13;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(503, 490);
            this.okButton.Margin = new System.Windows.Forms.Padding(2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(77, 33);
            this.okButton.TabIndex = 16;
            this.okButton.Text = "创建";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(584, 490);
            this.cancel.Margin = new System.Windows.Forms.Padding(2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(77, 33);
            this.cancel.TabIndex = 17;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "名称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "版本：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "简介：";
            // 
            // value_Text
            // 
            this.value_Text.AutoSize = true;
            this.value_Text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.value_Text.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.value_Text.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.value_Text.Location = new System.Drawing.Point(9, 330);
            this.value_Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.value_Text.Name = "value_Text";
            this.value_Text.Size = new System.Drawing.Size(65, 12);
            this.value_Text.TabIndex = 20;
            this.value_Text.TabStop = true;
            this.value_Text.Text = "项目主值：";
            this.Tip.SetToolTip(this.value_Text, "暂无变量");
            this.value_Text.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.value_Text_LinkClicked);
            // 
            // arguments_Text
            // 
            this.arguments_Text.AutoSize = true;
            this.arguments_Text.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.arguments_Text.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.arguments_Text.Location = new System.Drawing.Point(9, 405);
            this.arguments_Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.arguments_Text.Name = "arguments_Text";
            this.arguments_Text.Size = new System.Drawing.Size(65, 12);
            this.arguments_Text.TabIndex = 23;
            this.arguments_Text.TabStop = true;
            this.arguments_Text.Text = "启动参数：";
            this.Tip.SetToolTip(this.arguments_Text, "暂无变量");
            this.arguments_Text.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.arguments_Text_LinkClicked);
            // 
            // categoryBox
            // 
            this.categoryBox.CheckBoxes = true;
            this.categoryBox.Location = new System.Drawing.Point(503, 94);
            this.categoryBox.Margin = new System.Windows.Forms.Padding(2);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(160, 316);
            this.categoryBox.TabIndex = 10;
            this.categoryBox.TabStop = false;
            // 
            // workingDir_Text
            // 
            this.workingDir_Text.AutoSize = true;
            this.workingDir_Text.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.workingDir_Text.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.workingDir_Text.Location = new System.Drawing.Point(9, 430);
            this.workingDir_Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.workingDir_Text.Name = "workingDir_Text";
            this.workingDir_Text.Size = new System.Drawing.Size(137, 12);
            this.workingDir_Text.TabIndex = 36;
            this.workingDir_Text.TabStop = true;
            this.workingDir_Text.Text = "起始位置（工作目录）：";
            this.Tip.SetToolTip(this.workingDir_Text, "暂无变量");
            this.workingDir_Text.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.workingDir_Text_LinkClicked);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(514, 11);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 38;
            this.label13.Text = "搜索别名：";
            // 
            // searchAliasBox
            // 
            this.searchAliasBox.Location = new System.Drawing.Point(572, 7);
            this.searchAliasBox.Margin = new System.Windows.Forms.Padding(2);
            this.searchAliasBox.Name = "searchAliasBox";
            this.searchAliasBox.Size = new System.Drawing.Size(88, 21);
            this.searchAliasBox.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 40;
            this.label7.Text = "主页：";
            // 
            // iPath_Text
            // 
            this.iPath_Text.AutoSize = true;
            this.iPath_Text.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.iPath_Text.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.iPath_Text.Location = new System.Drawing.Point(9, 455);
            this.iPath_Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.iPath_Text.Name = "iPath_Text";
            this.iPath_Text.Size = new System.Drawing.Size(65, 12);
            this.iPath_Text.TabIndex = 43;
            this.iPath_Text.TabStop = true;
            this.iPath_Text.Text = "资料目录：";
            this.Tip.SetToolTip(this.iPath_Text, "暂无变量");
            this.iPath_Text.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iPath_Text_LinkClicked);
            // 
            // x86Value_Text
            // 
            this.x86Value_Text.AutoSize = true;
            this.x86Value_Text.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.x86Value_Text.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.x86Value_Text.Location = new System.Drawing.Point(9, 355);
            this.x86Value_Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.x86Value_Text.Name = "x86Value_Text";
            this.x86Value_Text.Size = new System.Drawing.Size(65, 12);
            this.x86Value_Text.TabIndex = 49;
            this.x86Value_Text.TabStop = true;
            this.x86Value_Text.Text = "32位主值：";
            this.Tip.SetToolTip(this.x86Value_Text, "暂无变量");
            this.x86Value_Text.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.x86Value_Text_LinkClicked);
            // 
            // x64Value_Text
            // 
            this.x64Value_Text.AutoSize = true;
            this.x64Value_Text.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.x64Value_Text.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.x64Value_Text.Location = new System.Drawing.Point(9, 380);
            this.x64Value_Text.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.x64Value_Text.Name = "x64Value_Text";
            this.x64Value_Text.Size = new System.Drawing.Size(65, 12);
            this.x64Value_Text.TabIndex = 51;
            this.x64Value_Text.TabStop = true;
            this.x64Value_Text.Text = "64位主值：";
            this.Tip.SetToolTip(this.x64Value_Text, "暂无变量");
            this.x64Value_Text.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.x64Value_Text_LinkClicked);
            // 
            // homePageBox
            // 
            this.homePageBox.Location = new System.Drawing.Point(93, 31);
            this.homePageBox.Margin = new System.Windows.Forms.Padding(2);
            this.homePageBox.Name = "homePageBox";
            this.homePageBox.Size = new System.Drawing.Size(568, 21);
            this.homePageBox.TabIndex = 3;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(212, 8);
            this.nameBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(147, 21);
            this.nameBox.TabIndex = 1;
            // 
            // item_Hide_main
            // 
            this.item_Hide_main.AutoSize = true;
            this.item_Hide_main.Location = new System.Drawing.Point(13, 17);
            this.item_Hide_main.Name = "item_Hide_main";
            this.item_Hide_main.Size = new System.Drawing.Size(108, 16);
            this.item_Hide_main.TabIndex = 14;
            this.item_Hide_main.Text = "界面分类中隐藏";
            this.item_Hide_main.UseVisualStyleBackColor = true;
            // 
            // item_Hide_search
            // 
            this.item_Hide_search.AutoSize = true;
            this.item_Hide_search.Location = new System.Drawing.Point(13, 38);
            this.item_Hide_search.Name = "item_Hide_search";
            this.item_Hide_search.Size = new System.Drawing.Size(108, 16);
            this.item_Hide_search.TabIndex = 15;
            this.item_Hide_search.Text = "搜索名称时隐藏";
            this.item_Hide_search.UseVisualStyleBackColor = true;
            // 
            // iv_x64_BOX
            // 
            this.iv_x64_BOX.AllowDrop = true;
            this.iv_x64_BOX.AutoSize = true;
            this.iv_x64_BOX.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iv_x64_BOX.FloatingText = null;
            this.iv_x64_BOX.HintText = "可留空：在“64位系统”下优先使用";
            this.iv_x64_BOX.Location = new System.Drawing.Point(63, 374);
            this.iv_x64_BOX.Margin = new System.Windows.Forms.Padding(2);
            this.iv_x64_BOX.Name = "iv_x64_BOX";
            this.iv_x64_BOX.Size = new System.Drawing.Size(426, 25);
            this.iv_x64_BOX.TabIndex = 8;
            this.iv_x64_BOX.text = "";
            this.iv_x64_BOX.rButtonClicked += new OLEREO.Control.FloatingTextBox.BtnClickHandle(this.expandValue_rButtonClicked);
            this.iv_x64_BOX.DragDrop += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragDrop);
            this.iv_x64_BOX.DragEnter += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragEnter);
            // 
            // iv_x86_BOX
            // 
            this.iv_x86_BOX.AllowDrop = true;
            this.iv_x86_BOX.AutoSize = true;
            this.iv_x86_BOX.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iv_x86_BOX.FloatingText = null;
            this.iv_x86_BOX.HintText = "可留空：在“32位系统”下优先使用";
            this.iv_x86_BOX.Location = new System.Drawing.Point(63, 349);
            this.iv_x86_BOX.Margin = new System.Windows.Forms.Padding(2);
            this.iv_x86_BOX.Name = "iv_x86_BOX";
            this.iv_x86_BOX.Size = new System.Drawing.Size(426, 25);
            this.iv_x86_BOX.TabIndex = 7;
            this.iv_x86_BOX.text = "";
            this.iv_x86_BOX.rButtonClicked += new OLEREO.Control.FloatingTextBox.BtnClickHandle(this.expandValue_rButtonClicked);
            this.iv_x86_BOX.DragDrop += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragDrop);
            this.iv_x86_BOX.DragEnter += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragEnter);
            // 
            // workingdirBox
            // 
            this.workingdirBox.AllowDrop = true;
            this.workingdirBox.AutoSize = true;
            this.workingdirBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.workingdirBox.FloatingText = null;
            this.workingdirBox.HintText = "可留空：修改主值的工作目录";
            this.workingdirBox.Location = new System.Drawing.Point(141, 424);
            this.workingdirBox.Margin = new System.Windows.Forms.Padding(2);
            this.workingdirBox.Name = "workingdirBox";
            this.workingdirBox.Size = new System.Drawing.Size(348, 25);
            this.workingdirBox.TabIndex = 10;
            this.workingdirBox.text = "";
            this.workingdirBox.rButtonClicked += new OLEREO.Control.FloatingTextBox.BtnClickHandle(this.expandValue_rButtonClicked);
            this.workingdirBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragDrop);
            this.workingdirBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragEnter);
            // 
            // iPath_BOX
            // 
            this.iPath_BOX.AllowDrop = true;
            this.iPath_BOX.AutoSize = true;
            this.iPath_BOX.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iPath_BOX.FloatingText = null;
            this.iPath_BOX.HintText = "可留空：留空采用数据库设置的目录";
            this.iPath_BOX.Location = new System.Drawing.Point(64, 449);
            this.iPath_BOX.Margin = new System.Windows.Forms.Padding(2);
            this.iPath_BOX.Name = "iPath_BOX";
            this.iPath_BOX.Size = new System.Drawing.Size(425, 25);
            this.iPath_BOX.TabIndex = 11;
            this.iPath_BOX.text = "";
            this.iPath_BOX.rButtonClicked += new OLEREO.Control.FloatingTextBox.BtnClickHandle(this.expandValue_rButtonClicked);
            this.iPath_BOX.DragDrop += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragDrop);
            this.iPath_BOX.DragEnter += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragEnter);
            // 
            // argumentsBox
            // 
            this.argumentsBox.AllowDrop = true;
            this.argumentsBox.AutoSize = true;
            this.argumentsBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.argumentsBox.FloatingText = null;
            this.argumentsBox.HintText = "可留空";
            this.argumentsBox.Location = new System.Drawing.Point(63, 399);
            this.argumentsBox.Margin = new System.Windows.Forms.Padding(2);
            this.argumentsBox.Name = "argumentsBox";
            this.argumentsBox.Size = new System.Drawing.Size(426, 25);
            this.argumentsBox.TabIndex = 9;
            this.argumentsBox.text = "";
            this.argumentsBox.rButtonClicked += new OLEREO.Control.FloatingTextBox.BtnClickHandle(this.expandValue_rButtonClicked);
            this.argumentsBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragDrop);
            this.argumentsBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragEnter);
            // 
            // valueBox
            // 
            this.valueBox.AllowDrop = true;
            this.valueBox.AutoSize = true;
            this.valueBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.valueBox.FloatingText = null;
            this.valueBox.HintText = "可留空：缺省主值";
            this.valueBox.Location = new System.Drawing.Point(63, 324);
            this.valueBox.Margin = new System.Windows.Forms.Padding(2);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(426, 25);
            this.valueBox.TabIndex = 6;
            this.valueBox.text = "";
            this.valueBox.rButtonClicked += new OLEREO.Control.FloatingTextBox.BtnClickHandle(this.expandValue_rButtonClicked);
            this.valueBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragDrop);
            this.valueBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.ItemValueBox_DragEnter);
            // 
            // iconLabel
            // 
            this.iconLabel.AutoSize = true;
            this.iconLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.iconLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.iconLabel.Location = new System.Drawing.Point(9, 481);
            this.iconLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.iconLabel.Name = "iconLabel";
            this.iconLabel.Size = new System.Drawing.Size(77, 12);
            this.iconLabel.TabIndex = 63;
            this.iconLabel.TabStop = true;
            this.iconLabel.Text = "自定义图标：";
            this.Tip.SetToolTip(this.iconLabel, "暂无变量");
            this.iconLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iconText_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "UID：";
            // 
            // UIDBox
            // 
            this.UIDBox.BackColor = System.Drawing.Color.Red;
            this.UIDBox.Location = new System.Drawing.Point(93, 8);
            this.UIDBox.Margin = new System.Windows.Forms.Padding(2);
            this.UIDBox.Name = "UIDBox";
            this.UIDBox.Size = new System.Drawing.Size(74, 21);
            this.UIDBox.TabIndex = 54;
            this.UIDBox.Text = "UID";
            this.UIDBox.TextChanged += new System.EventHandler(this.UIDBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.item_Hide_search);
            this.groupBox1.Controls.Add(this.item_Hide_main);
            this.groupBox1.Location = new System.Drawing.Point(501, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 59);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "隐藏";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(499, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = "分类：";
            // 
            // onAdminBox
            // 
            this.onAdminBox.AutoSize = true;
            this.onAdminBox.Location = new System.Drawing.Point(11, 507);
            this.onAdminBox.Name = "onAdminBox";
            this.onAdminBox.Size = new System.Drawing.Size(120, 16);
            this.onAdminBox.TabIndex = 57;
            this.onAdminBox.Text = "以管理员身份运行";
            this.onAdminBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 58;
            this.label3.Text = "介绍：";
            // 
            // iconBox
            // 
            this.iconBox.AllowDrop = true;
            this.iconBox.AutoSize = true;
            this.iconBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.iconBox.FloatingText = null;
            this.iconBox.HintText = "可留空";
            this.iconBox.Location = new System.Drawing.Point(80, 474);
            this.iconBox.Margin = new System.Windows.Forms.Padding(2);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(409, 27);
            this.iconBox.TabIndex = 59;
            this.iconBox.text = "";
            this.iconBox.rButtonClicked += new OLEREO.Control.FloatingTextBox.BtnClickHandle(this.expandValue_rButtonClicked);
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(675, 530);
            this.Controls.Add(this.iconBox);
            this.Controls.Add(this.iconLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.onAdminBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchAliasBox);
            this.Controls.Add(this.versionBox);
            this.Controls.Add(this.UIDBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.introBox);
            this.Controls.Add(this.homePageBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.valueBox);
            this.Controls.Add(this.iv_x64_BOX);
            this.Controls.Add(this.iv_x86_BOX);
            this.Controls.Add(this.ItemIconBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.workingdirBox);
            this.Controls.Add(this.iPath_BOX);
            this.Controls.Add(this.argumentsBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.introduceBox);
            this.Controls.Add(this.x64Value_Text);
            this.Controls.Add(this.x86Value_Text);
            this.Controls.Add(this.iPath_Text);
            this.Controls.Add(this.workingDir_Text);
            this.Controls.Add(this.arguments_Text);
            this.Controls.Add(this.value_Text);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑项目";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClosed);
            this.Shown += new System.EventHandler(this.Edit_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ItemIconBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ItemIconBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox versionBox;
        private System.Windows.Forms.TextBox introBox;
        private OLEREO.Control.FloatingTextBox valueBox;
        private System.Windows.Forms.TextBox introduceBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel value_Text;
        private System.Windows.Forms.LinkLabel arguments_Text;
        private OLEREO.Control.FloatingTextBox argumentsBox;
        private OLEREO.Control.FloatingTextBox iPath_BOX;
        private System.Windows.Forms.TreeView categoryBox;
        private System.Windows.Forms.LinkLabel workingDir_Text;
        private OLEREO.Control.FloatingTextBox workingdirBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox searchAliasBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox homePageBox;
        private System.Windows.Forms.LinkLabel iPath_Text;
        private System.Windows.Forms.LinkLabel x86Value_Text;
        private OLEREO.Control.FloatingTextBox iv_x86_BOX;
        private System.Windows.Forms.LinkLabel x64Value_Text;
        private OLEREO.Control.FloatingTextBox iv_x64_BOX;
        private System.Windows.Forms.CheckBox item_Hide_main;
        private System.Windows.Forms.CheckBox item_Hide_search;
        private System.Windows.Forms.ToolTip Tip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UIDBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox onAdminBox;
        private System.Windows.Forms.Label label3;
        private OLEREO.Control.FloatingTextBox iconBox;
        private System.Windows.Forms.LinkLabel iconLabel;
    }
}