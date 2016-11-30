using OLEREO.Control;

namespace ZIKU
{

    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.HideOrTopMost = new System.Windows.Forms.Button();
            this.MiniZiku = new System.Windows.Forms.Button();
            this.SubCategoryListBox = new CCWin.SkinControl.SkinListBox();
            this.CategoryListBox = new CCWin.SkinControl.SkinListBox();
            this.ZikuState = new System.Windows.Forms.Label();
            this.ItemValueExpandBox = new System.Windows.Forms.Label();
            this.ItemIntroduceBox = new System.Windows.Forms.TextBox();
            this.ExitZiku = new System.Windows.Forms.Button();
            this.ZikuSetButton = new System.Windows.Forms.Button();
            this.ItemIcoPictureBox = new System.Windows.Forms.PictureBox();
            this.ItemValueIsExist = new System.Windows.Forms.Label();
            this.ZikuIsUp = new System.Windows.Forms.LinkLabel();
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.ItemVersionsLabel = new System.Windows.Forms.Label();
            this.subInfo_Listview = new OLEREO.Control.oListView();
            this.subInfo_ListView_type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subInfo_ListView_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemListView = new OLEREO.Control.oListView();
            this.item_ListView_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.item_ListView_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.item_ListView_intro = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ItemIcoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ZIKU!\r\nOLEREO.COM";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // HideOrTopMost
            // 
            this.HideOrTopMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HideOrTopMost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.HideOrTopMost.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.HideOrTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HideOrTopMost.ForeColor = System.Drawing.SystemColors.WindowText;
            this.HideOrTopMost.Location = new System.Drawing.Point(541, 9);
            this.HideOrTopMost.Name = "HideOrTopMost";
            this.HideOrTopMost.Size = new System.Drawing.Size(107, 23);
            this.HideOrTopMost.TabIndex = 3;
            this.HideOrTopMost.TabStop = false;
            this.HideOrTopMost.Text = "自动隐藏";
            this.HideOrTopMost.UseVisualStyleBackColor = false;
            this.HideOrTopMost.Click += new System.EventHandler(this.HideOrTopMost_Click);
            // 
            // MiniZiku
            // 
            this.MiniZiku.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MiniZiku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.MiniZiku.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MiniZiku.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.MiniZiku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MiniZiku.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MiniZiku.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.MiniZiku.Location = new System.Drawing.Point(653, 8);
            this.MiniZiku.Name = "MiniZiku";
            this.MiniZiku.Size = new System.Drawing.Size(101, 23);
            this.MiniZiku.TabIndex = 1;
            this.MiniZiku.TabStop = false;
            this.MiniZiku.Text = "H";
            this.MiniZiku.UseVisualStyleBackColor = false;
            this.MiniZiku.Click += new System.EventHandler(this.MiniZiku_Click);
            // 
            // SubCategoryListBox
            // 
            this.SubCategoryListBox.Back = null;
            this.SubCategoryListBox.BackColor = System.Drawing.SystemColors.Control;
            this.SubCategoryListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SubCategoryListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SubCategoryListBox.FormattingEnabled = true;
            this.SubCategoryListBox.ImagePoint = false;
            this.SubCategoryListBox.ImageVisble = false;
            this.SubCategoryListBox.ItemBorderVisble = false;
            this.SubCategoryListBox.ItemGlassVisble = false;
            this.SubCategoryListBox.ItemHeight = 20;
            this.SubCategoryListBox.Location = new System.Drawing.Point(94, 284);
            this.SubCategoryListBox.MouseColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(206)))), ((int)(((byte)(255)))));
            this.SubCategoryListBox.Name = "SubCategoryListBox";
            this.SubCategoryListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SubCategoryListBox.RowBackColor1 = System.Drawing.SystemColors.ScrollBar;
            this.SubCategoryListBox.RowBackColor2 = System.Drawing.SystemColors.ScrollBar;
            this.SubCategoryListBox.SelectedColor = System.Drawing.Color.LightCoral;
            this.SubCategoryListBox.Size = new System.Drawing.Size(38, 280);
            this.SubCategoryListBox.TabIndex = 1;
            this.SubCategoryListBox.SelectedIndexChanged += new System.EventHandler(this.SubCategoryListBox_SelectedIndexChanged);
            this.SubCategoryListBox.MouseEnter += new System.EventHandler(this.SubCategoryListBox_MouseEnter);
            this.SubCategoryListBox.MouseLeave += new System.EventHandler(this.SubCategoryListBox_MouseLeave);
            // 
            // CategoryListBox
            // 
            this.CategoryListBox.Back = null;
            this.CategoryListBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CategoryListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CategoryListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CategoryListBox.FormattingEnabled = true;
            this.CategoryListBox.ImageVisble = false;
            this.CategoryListBox.ItemBorderVisble = false;
            this.CategoryListBox.ItemGlassVisble = false;
            this.CategoryListBox.ItemHeight = 20;
            this.CategoryListBox.Location = new System.Drawing.Point(1, 260);
            this.CategoryListBox.MouseColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(206)))), ((int)(((byte)(255)))));
            this.CategoryListBox.Name = "CategoryListBox";
            this.CategoryListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CategoryListBox.RowBackColor1 = System.Drawing.SystemColors.ScrollBar;
            this.CategoryListBox.RowBackColor2 = System.Drawing.SystemColors.ScrollBar;
            this.CategoryListBox.SelectedColor = System.Drawing.Color.LightCoral;
            this.CategoryListBox.Size = new System.Drawing.Size(93, 320);
            this.CategoryListBox.TabIndex = 0;
            this.CategoryListBox.SelectedIndexChanged += new System.EventHandler(this.CategoryListBox_SelectedIndexChanged);
            // 
            // ZikuState
            // 
            this.ZikuState.AutoSize = true;
            this.ZikuState.BackColor = System.Drawing.SystemColors.Control;
            this.ZikuState.Location = new System.Drawing.Point(6, 590);
            this.ZikuState.Name = "ZikuState";
            this.ZikuState.Size = new System.Drawing.Size(59, 12);
            this.ZikuState.TabIndex = 35;
            this.ZikuState.Text = "ZikuState";
            // 
            // ItemValueExpandBox
            // 
            this.ItemValueExpandBox.AutoSize = true;
            this.ItemValueExpandBox.BackColor = System.Drawing.SystemColors.Control;
            this.ItemValueExpandBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ItemValueExpandBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.ItemValueExpandBox.Location = new System.Drawing.Point(22, 229);
            this.ItemValueExpandBox.Margin = new System.Windows.Forms.Padding(5, 0, 3, 0);
            this.ItemValueExpandBox.Name = "ItemValueExpandBox";
            this.ItemValueExpandBox.Size = new System.Drawing.Size(125, 15);
            this.ItemValueExpandBox.TabIndex = 50;
            this.ItemValueExpandBox.Text = "ItemValueExpandBox";
            // 
            // ItemIntroduceBox
            // 
            this.ItemIntroduceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemIntroduceBox.BackColor = System.Drawing.SystemColors.Control;
            this.ItemIntroduceBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ItemIntroduceBox.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ItemIntroduceBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.ItemIntroduceBox.Location = new System.Drawing.Point(49, 89);
            this.ItemIntroduceBox.Multiline = true;
            this.ItemIntroduceBox.Name = "ItemIntroduceBox";
            this.ItemIntroduceBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ItemIntroduceBox.Size = new System.Drawing.Size(734, 135);
            this.ItemIntroduceBox.TabIndex = 57;
            this.ItemIntroduceBox.TabStop = false;
            this.ItemIntroduceBox.Text = "introduce";
            // 
            // ExitZiku
            // 
            this.ExitZiku.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitZiku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(243)))), ((int)(((byte)(240)))));
            this.ExitZiku.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitZiku.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.ExitZiku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitZiku.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ExitZiku.ForeColor = System.Drawing.Color.Red;
            this.ExitZiku.Location = new System.Drawing.Point(755, 8);
            this.ExitZiku.Name = "ExitZiku";
            this.ExitZiku.Size = new System.Drawing.Size(43, 23);
            this.ExitZiku.TabIndex = 60;
            this.ExitZiku.TabStop = false;
            this.ExitZiku.Text = "E";
            this.ExitZiku.UseVisualStyleBackColor = false;
            this.ExitZiku.Click += new System.EventHandler(this.ExitZiku_Click);
            // 
            // ZikuSetButton
            // 
            this.ZikuSetButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ZikuSetButton.FlatAppearance.BorderSize = 0;
            this.ZikuSetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZikuSetButton.Location = new System.Drawing.Point(708, 588);
            this.ZikuSetButton.Name = "ZikuSetButton";
            this.ZikuSetButton.Size = new System.Drawing.Size(88, 20);
            this.ZikuSetButton.TabIndex = 62;
            this.ZikuSetButton.TabStop = false;
            this.ZikuSetButton.Text = "菜单按钮";
            this.ZikuSetButton.UseVisualStyleBackColor = false;
            this.ZikuSetButton.Click += new System.EventHandler(this.ZikuSetButton_Click);
            this.ZikuSetButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ZikuSetButton_MouseClick);
            // 
            // ItemIcoPictureBox
            // 
            this.ItemIcoPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.ItemIcoPictureBox.Enabled = false;
            this.ItemIcoPictureBox.ErrorImage = null;
            this.ItemIcoPictureBox.Location = new System.Drawing.Point(7, 31);
            this.ItemIcoPictureBox.Name = "ItemIcoPictureBox";
            this.ItemIcoPictureBox.Size = new System.Drawing.Size(32, 32);
            this.ItemIcoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ItemIcoPictureBox.TabIndex = 38;
            this.ItemIcoPictureBox.TabStop = false;
            // 
            // ItemValueIsExist
            // 
            this.ItemValueIsExist.AutoSize = true;
            this.ItemValueIsExist.BackColor = System.Drawing.SystemColors.Control;
            this.ItemValueIsExist.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ItemValueIsExist.Location = new System.Drawing.Point(7, 232);
            this.ItemValueIsExist.Name = "ItemValueIsExist";
            this.ItemValueIsExist.Size = new System.Drawing.Size(11, 12);
            this.ItemValueIsExist.TabIndex = 65;
            this.ItemValueIsExist.Text = "V";
            // 
            // ZikuIsUp
            // 
            this.ZikuIsUp.AutoSize = true;
            this.ZikuIsUp.BackColor = System.Drawing.SystemColors.Control;
            this.ZikuIsUp.Location = new System.Drawing.Point(576, 593);
            this.ZikuIsUp.Name = "ZikuIsUp";
            this.ZikuIsUp.Size = new System.Drawing.Size(125, 12);
            this.ZikuIsUp.TabIndex = 66;
            this.ZikuIsUp.TabStop = true;
            this.ZikuIsUp.Text = "ZIKU! 有新的版本了！";
            this.ZikuIsUp.Visible = false;
            this.ZikuIsUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ZikuIsUp_LinkClicked);
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ItemNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(87)))), ((int)(((byte)(90)))));
            this.ItemNameLabel.Location = new System.Drawing.Point(37, 22);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(111, 46);
            this.ItemNameLabel.TabIndex = 68;
            this.ItemNameLabel.Text = "ZIKU!";
            // 
            // ItemVersionsLabel
            // 
            this.ItemVersionsLabel.AutoSize = true;
            this.ItemVersionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ItemVersionsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.ItemVersionsLabel.Location = new System.Drawing.Point(29, 68);
            this.ItemVersionsLabel.Name = "ItemVersionsLabel";
            this.ItemVersionsLabel.Size = new System.Drawing.Size(46, 15);
            this.ItemVersionsLabel.TabIndex = 69;
            this.ItemVersionsLabel.Text = "version";
            // 
            // subInfo_Listview
            // 
            this.subInfo_Listview.AllowDrop = true;
            this.subInfo_Listview.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.subInfo_Listview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subInfo_Listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.subInfo_ListView_type,
            this.subInfo_ListView_name});
            this.subInfo_Listview.Enabled = false;
            this.subInfo_Listview.EnabledColumnSort = false;
            this.subInfo_Listview.EnabledDragItemAndDragFile = false;
            this.subInfo_Listview.FullRowSelect = true;
            this.subInfo_Listview.GridLines = true;
            this.subInfo_Listview.HideSelection = false;
            this.subInfo_Listview.HoldLastItemBackeColor = false;
            this.subInfo_Listview.Location = new System.Drawing.Point(665, 260);
            this.subInfo_Listview.MultiSelect = false;
            this.subInfo_Listview.Name = "subInfo_Listview";
            this.subInfo_Listview.Size = new System.Drawing.Size(129, 320);
            this.subInfo_Listview.TabIndex = 3;
            this.subInfo_Listview.UseCompatibleStateImageBehavior = false;
            this.subInfo_Listview.View = System.Windows.Forms.View.Details;
            this.subInfo_Listview.SelectedIndexChanged += new System.EventHandler(this.subInfo_Listview_SelectedIndexChanged);
            this.subInfo_Listview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.subInfo_Listview_MouseDoubleClick);
            // 
            // subInfo_ListView_type
            // 
            this.subInfo_ListView_type.Text = "type";
            this.subInfo_ListView_type.Width = 1;
            // 
            // subInfo_ListView_name
            // 
            this.subInfo_ListView_name.Text = "项目子信息";
            this.subInfo_ListView_name.Width = 120;
            // 
            // itemListView
            // 
            this.itemListView.BackColor = System.Drawing.SystemColors.ControlLight;
            this.itemListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.item_ListView_id,
            this.item_ListView_name,
            this.item_ListView_intro});
            this.itemListView.EnabledColumnSort = false;
            this.itemListView.EnabledDragItemAndDragFile = true;
            this.itemListView.FullRowSelect = true;
            this.itemListView.GridLines = true;
            this.itemListView.HideSelection = false;
            this.itemListView.HoldLastItemBackeColor = false;
            this.itemListView.Location = new System.Drawing.Point(133, 260);
            this.itemListView.MultiSelect = false;
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(526, 320);
            this.itemListView.TabIndex = 2;
            this.itemListView.UseCompatibleStateImageBehavior = false;
            this.itemListView.View = System.Windows.Forms.View.Details;
            this.itemListView.DragFileOver += new OLEREO.Control.oListView.DragFile(this.listView1_DragFileOver);
            this.itemListView.SortChangeEvent += new OLEREO.Control.oListView._SaveSortEvent(this.itemListView_SortChangeEvent);
            this.itemListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.itemListView.SizeChanged += new System.EventHandler(this.listView1_SizeChanged);
            this.itemListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemListView_KeyDown);
            this.itemListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // item_ListView_id
            // 
            this.item_ListView_id.Text = "UID";
            this.item_ListView_id.Width = 50;
            // 
            // item_ListView_name
            // 
            this.item_ListView_name.Text = "项目名称";
            this.item_ListView_name.Width = 180;
            // 
            // item_ListView_intro
            // 
            this.item_ListView_intro.Text = "项目简介";
            this.item_ListView_intro.Width = 275;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 80);
            this.button1.TabIndex = 70;
            this.button1.Text = "看见该按钮是BUG，请反馈";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
           this.BackgroundImage = global::ZIKU.Properties.Resources.MainBackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.MiniZiku;
            this.ClientSize = new System.Drawing.Size(800, 610);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.subInfo_Listview);
            this.Controls.Add(this.ItemIcoPictureBox);
            this.Controls.Add(this.ExitZiku);
            this.Controls.Add(this.MiniZiku);
            this.Controls.Add(this.HideOrTopMost);
            this.Controls.Add(this.ItemNameLabel);
            this.Controls.Add(this.CategoryListBox);
            this.Controls.Add(this.SubCategoryListBox);
            this.Controls.Add(this.ZikuIsUp);
            this.Controls.Add(this.ItemValueIsExist);
            this.Controls.Add(this.ZikuSetButton);
            this.Controls.Add(this.ItemIntroduceBox);
            this.Controls.Add(this.ItemValueExpandBox);
            this.Controls.Add(this.ZikuState);
            this.Controls.Add(this.itemListView);
            this.Controls.Add(this.ItemVersionsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZIKU! - OLEREO.COM";
            this.Deactivate += new System.EventHandler(this.mainForm_Visible_False);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.ItemIcoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button MiniZiku;
        private System.Windows.Forms.Button HideOrTopMost;
        private CCWin.SkinControl.SkinListBox SubCategoryListBox;
        private CCWin.SkinControl.SkinListBox CategoryListBox;
        private System.Windows.Forms.Label ZikuState;
        private System.Windows.Forms.PictureBox ItemIcoPictureBox;
        private System.Windows.Forms.Label ItemValueExpandBox;
        private System.Windows.Forms.TextBox ItemIntroduceBox;
        private System.Windows.Forms.Button ExitZiku;
        private System.Windows.Forms.Button ZikuSetButton;
        private System.Windows.Forms.Label ItemValueIsExist;
        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.Label ItemVersionsLabel;
        private System.Windows.Forms.ColumnHeader subInfo_ListView_name;
        private oListView subInfo_Listview;
        private System.Windows.Forms.ColumnHeader item_ListView_id;
        private System.Windows.Forms.ColumnHeader item_ListView_name;
        private System.Windows.Forms.ColumnHeader item_ListView_intro;
        private oListView itemListView;
        private System.Windows.Forms.ColumnHeader subInfo_ListView_type;
        private System.Windows.Forms.LinkLabel ZikuIsUp;
        private System.Windows.Forms.Button button1;
    }
}

