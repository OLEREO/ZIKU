//#define Buged

using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CCWin.SkinControl;
using System.Drawing;
using OLEREO.Control;
using OLEREO.Library;
using ZIKU.DataBase;
using ZIKU.Control;
using System.Threading;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text;
namespace ZIKU
{
    public partial class MainForm : Form
    {

        /// <summary>
        /// 触发其他窗体的方法
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int msg, uint wParam, uint lParam);

        /// <summary>
        /// 主窗体的项目信息
        /// </summary>
        public Item item_Main;

        /// <summary>
        /// 主窗口所显示(使用)的分类
        /// </summary>
        public Category category_Main;



        private static MainForm _instance = null;
        /// <summary>
        /// 获取主窗口的实例
        /// </summary>
        public static MainForm Instance { get { return _instance; } }
        /// <summary>
        /// 构造器
        /// </summary>
        public MainForm(string runItemID = null)
        {
            InitializeComponent();
            _instance = this;

            RegistryKey key = Registry.CurrentUser;
            RegistryKey software = key.CreateSubKey("Software\\OLEREO\\ZIKU!");
            software.SetValue(@"zikuPath", Program.ZIKUPATH + "\\ZIKU!.exe", RegistryValueKind.String);

            Icon = Properties.Resources.ICON;
            string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            this.DoubleBuffered = true;

            //获取组件的右键菜单
            this.itemListView.ContextMenuStrip = new itemMenu();
            zsm = new Control.zMenu.TrayOrSettingMenu();
            notifyIcon1.ContextMenuStrip = new Control.zMenu.TrayOrSettingMenu();

            subInfo_Listview.ContextMenuStrip = new SubInfoListMenu(this);
            //刷新界面所有信息
            RefreshFormInfo();
            //注册快捷键
            RegisterHotKey();
            Text = Program.mainFormTitle;
     
            //开启测试按钮
            setTest();

            if (SettingDataBase.Config.Instance.checkUP)
               new Thread(new ThreadStart(CheckUpThread)).Start();
            if(runItemID != null)            
                myZiku.run(Item.getInstance(runItemID));
        }

        [Conditional("Buged")]
        void setTest()
        {
            button1.Visible = true;
        }


        #region 窗口行为
        /// <summary>
        /// 是否开启自动隐藏窗口
        /// </summary>
        private bool onAutoHide = true;
        /// <summary>
        /// 关闭自动隐藏
        /// </summary>
        /// <param name="toHide">是否隐藏主窗口</param>
        public void autoHideEn(bool toHide = false)
        {
            if (toHide)
                this.Hide();
            itemListView.SaveSort();
            onAutoHide = false;
            TopMost = false;
        }

        /// <summary>
        /// 开启自动隐藏
        /// </summary>
        /// <param name="toShow">同时显示界面</param>
        public void autoHideOn(bool toShow = false)
        {
            if (toShow)
                    Show();
            onAutoHide = true;
            if (_mainFormHorS == MianFormHorS.top) TopMost = true;
        }

        //窗口失去焦点
        private void mainForm_Visible_False(object sender, EventArgs e)
        {
            if (_mainFormHorS == MianFormHorS.auotoHide && onAutoHide)
                this.Visible = false;
        }
        //窗口关闭时(退出时)
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Hide();
            UnRegisterHotKey();
            itemListView.SaveSort();
            Environment.Exit(0);
        }

        /// <summary>
        /// 窗口自动显隐状态
        /// </summary>
        private MianFormHorS _mainFormHorS = MianFormHorS.auotoHide;
        private enum MianFormHorS
        {
            auotoHide,
            normal,
            top
        }


        #region 窗口移动
        bool formMove = false;       //是否开始移动
        int currentXPosition = 0;    //当前鼠标X坐标
        int currentYPosition = 0;    //当前鼠标Y坐标

        //函数:鼠标按下
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            formMove = true;                       //鼠标按下开始移动
            currentXPosition = MousePosition.X;    //鼠标的X坐标为当前窗体左上角X坐标
            currentYPosition = MousePosition.Y;    //鼠标的Y坐标为当前窗体的左上角Y坐标
        }
        //函数:鼠标移动
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (formMove)
            {
                //鼠标xy坐标确定窗体XY坐标 鼠标移动XY距离
                this.Left += MousePosition.X - currentXPosition;
                this.Top += MousePosition.Y - currentYPosition;
                //鼠标当前位置赋值
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }
        //函数:鼠标松开
        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            formMove = false;     //停止移动
        }
        //函数：鼠标离开
        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            //初始状态
            currentXPosition = 0;
            currentYPosition = 0;
            formMove = false;
        }
        #endregion

        /// <summary>
        /// 响应显示窗口函数
        /// </summary>
        public void showMainFormNotify()
        {
            if (onAutoHide)
            {
                if (!this.Visible)
                {
                    Tools.SetForegroundWindow(this.Handle);
                    this.Visible = true;
                }
            }
        }

        #region 托盘
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showMainFormNotify();
            }
        }

        /// <summary>
        /// 使用托盘提示气泡
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <param name="time">事件</param>
        /// <param name="tipType">图标</param>
        public void showNotifyTip(string title, string text, int time = 100, ToolTipIcon tipType = ToolTipIcon.None)
        {
            notifyIcon1.ShowBalloonTip(time, title, text, tipType);
        }
        #endregion  
        #endregion


        #region 快捷键
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_HOTKEY = 0x0312;

            switch (m.Msg)
            {
                case Message.WM_NOTIFYICON://处理消息
                    if (onAutoHide)
                    {
                        if (!this.Visible)
                        {
                            Tools.SetForegroundWindow(this.Handle);
                            this.Visible = true;
                        }
                        else
                        {
                            this.Visible = false;
                        }
                    }
                    break;

                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:     //显隐快捷键
                            if (onAutoHide)
                            {
                                if (!this.Visible)
                                {
                                    Tools.SetForegroundWindow(Handle);
                                    this.Visible = true;
                                }
                                else
                                {
                                    this.Visible = false;
                                }
                            }
                            else if (SearchFormOle.Instance.Visible)
                            {
                                SearchFormOle.Instance.setDone();
                                Tools.SetForegroundWindow(this.Handle);
                                this.Visible = true;
                            }
                            break;
                        case 101:  //搜索快捷键
                            if (onAutoHide)
                            {//没有锁住
                                if (SearchFormOle.Instance.Visible)
                                    SearchFormOle.Instance.setDone();
                                else
                                    SearchFormOle.Instance.setShow();
                            }
                            else if (SearchFormOle.Instance.Visible) //锁住了
                                SearchFormOle.Instance.setDone();
                            break;
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        //注销快捷键
        public void UnRegisterHotKey()
        {
            HotKey.UnregisterHotKey(Handle, 100);
            HotKey.UnregisterHotKey(Handle, 101);
        }
        //注册快捷键
        public void RegisterHotKey()
        {
            //搜索快捷键
            if (SettingDataBase.Config.Instance.isSeHotKey)
                Tools.RegisterHotKey(Handle, 101, SettingDataBase.Config.Instance.seHotKeyA, SettingDataBase.Config.Instance.seHotKeyB);
            else
                HotKey.UnregisterHotKey(Handle, 101);

            //全局快捷键
            if (SettingDataBase.Config.Instance.isHotKey)
                Tools.RegisterHotKey(Handle, 100, SettingDataBase.Config.Instance.hotKeyA, SettingDataBase.Config.Instance.hotKeyB);
            else
                HotKey.UnregisterHotKey(Handle, 100);
        }
        #endregion

        #region 界面按钮
        //退出按钮
        private void ExitZiku_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //最小化按钮
        private void MiniZiku_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        //显隐按钮状态切换
        private void HideOrTopMost_Click(object sender, EventArgs e)
        {

            switch (_mainFormHorS)
            {
                case MianFormHorS.auotoHide:
                    _mainFormHorS = MianFormHorS.normal;
                    HideOrTopMost.Text = "不自动隐藏";
                    this.TopMost = false;
                    break;
                case MianFormHorS.normal:
                    _mainFormHorS = MianFormHorS.top;
                    HideOrTopMost.Text = "窗口置顶";
                    this.TopMost = true;
                    break;
                case MianFormHorS.top:
                    _mainFormHorS = MianFormHorS.auotoHide;
                    HideOrTopMost.Text = "自动隐藏";
                    this.TopMost = false;
                    break;
            }

        }

        //"菜单按钮"
        private ContextMenuStrip zsm;
        private void ZikuSetButton_Click(object sender, EventArgs e) { }
        private void ZikuSetButton_MouseClick(object sender, MouseEventArgs e)
        {
            zsm.Show(ZikuSetButton, new Point(e.X, e.Y));
        }
        #endregion

        #region 检查更新
        private void ZikuIsUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            autoHideEn(false);
            Updates.showUpdates();
            autoHideOn(true);
        }
        private void CheckUpThread()
        {
            Thread.Sleep(60000);
            this.Invoke(new Action<int>(this.UpdateCheckUp), Updates.checkUpdates(Program.updateFileLink, Program.ZIKUVER, "ZIKU! 更新"));
        }
        private void UpdateCheckUp(int v)
        {
            if (v == 1)
                this.ZikuIsUp.Visible = true;
        }
        #endregion


        /// <summary>
        /// 重置数据库，界面的所有信息
        /// </summary>
        public void RefreshFormInfo()
        {
            Config.Instance = null;
            ZikuState.Text = "当前使用的数据库名称是：" + Config.Instance.name;
            CategoryListBox.Items.Clear();
            SubCategoryListBox.Items.Clear();
            itemListView.Items.Clear();
            //刷新父分类
            foreach (string pID in Config.Instance.pCsort.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Category ca = Category.getInstance(pID);
                if (ca != null)
                {
                    SkinListBoxItem eff = new SkinListBoxItem(ca.name);
                    eff.Tag = pID;
                    CategoryListBox.Items.Add(eff);
                }
            }

            if (CategoryListBox.Items.Count != 0)
                CategoryListBox.SelectedIndex = 0;
            ReUIinfo();
        }

        /// <summary>
        /// 重置界面信息为ZIKU!
        /// </summary>
        private void ReUIinfo()
        {
            ItemIcoPictureBox.Image = ZIKU.Properties.Resources.ICON.ToBitmap();
            ItemNameLabel.Text = "ZIKU!";
            ItemIntroduceBox.Text = "更多技巧请查阅 http://docs.olereo.com/?lang=ziku";
            ItemValueExpandBox.Text = "";
            ItemVersionsLabel.Text = Program.ZIKUVER + "  OLEREO.COM"; ;
            ItemValueIsExist.Text = "";
            subInfo_Listview.Items.Clear();
            subInfo_Listview.Enabled = false;
        }

        #region 分类列表
        private void CategoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryListBox.SelectedItems.Count > 0)
            {
                refreshCategoryItemList(((SkinListBoxItem)CategoryListBox.SelectedItems[0]).Tag.ToString());
                refreshSubCategoryListBox(category_Main.id);
            }
        }

        private void refreshSubCategoryListBox(string pID)
        {
            SubCategoryListBox.Items.Clear();
            DataTable d = SQLite.ExecuteDataTable("SELECT * FROM Category WHERE id = " + pID + ";", Config.Instance.Path, null, false);
            if (d.Rows.Count > 0)
            {
                foreach(string subID in Tools.SplitString(d.Rows[0]["C_ID"].ToString()))
                {
                    DataTable subDT = SQLite.ExecuteDataTable("SELECT * FROM Category WHERE id =" + subID, Config.Instance.Path);
                    if(subDT.Rows.Count > 0)
                    {
                        SkinListBoxItem eff = new SkinListBoxItem(subDT.Rows[0]["name"].ToString());
                        eff.Tag = subDT.Rows[0]["id"].ToString();
                        SubCategoryListBox.Items.Add(eff);
                    }
                }
            }        
        }

        private void SubCategoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SubCategoryListBox.SelectedItems.Count > 0)
            {
                refreshCategoryItemList(((SkinListBoxItem)SubCategoryListBox.SelectedItems[0]).Tag.ToString());
            }
        }
        private void SubCategoryListBox_MouseEnter(object sender, EventArgs e)
        {
            if (SubCategoryListBox.Items.Count != 0)
                SubCategoryListBox.Width = 100;
        }
        private void SubCategoryListBox_MouseLeave(object sender, EventArgs e)
        {
            SubCategoryListBox.Width = 38;
        }
        /// <summary>
        /// 刷新分类中的项目列表
        /// </summary>
        /// <param name="cID">项目ID列表，null则刷新当前分类</param>
        public void refreshCategoryItemList(string cID)
        {
            itemListView.clearItemSaveSort();
            ReUIinfo();
            if (cID == null) cID = Instance.category_Main.id;
            category_Main = Category.getInstance(cID);
            foreach (string itemID in category_Main.I_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                DataTable d = SQLite.ExecuteDataTable("SELECT * FROM Item WHERE id = " + itemID, Config.Instance.Path, null, false);
                if (d.Rows.Count > 0)
                {
                    DataRow row = d.Rows[0];
                    if(row["hideMain"].ToString() == "FALSE")
                    {
                        ListViewItem li = new ListViewItem();
                        li.Tag = row["id"].ToString();
                        li.Text = row["UID"].ToString();
                        li.SubItems.Add(row["name"].ToString());
                        li.SubItems.Add(row["intro"].ToString());
                        itemListView.Items.Add(li);
                    }
                }
            }
        }
        #endregion

        #region 项目列表
        //项目列表改变选择
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemListView.SelectedItems.Count != 0)
                setItemInfoToForm(itemListView.SelectedItems[0].Tag.ToString());
            else
                ReUIinfo();
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            setItemInfoToForm(itemListView.SelectedItems[0].Tag.ToString(), true);
        }
        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            int w = (itemListView.Width - 520) / 10;//减10是考虑到边框和滚动条的宽度
            itemListView.Columns[1].Width = w * 2 + 220;
            itemListView.Columns[2].Width = w * 8 + 255;
        }

        /// <summary>
        /// 设置界面为项目信息
        /// </summary>
        /// <param name="itemID">项目的ID</param>
        /// <param name="run">是否运行</param>
        /// <param name="isConnectItem">这是一个关联的项目</param>
        public void setItemInfoToForm(string itemID, bool run = false, bool isConnectItem = false)
        {
            subInfo_Listview.Enabled = true;
            Item item = Item.getInstance(itemID);
            ItemNameLabel.Text = item.name;
            ItemIntroduceBox.Text = item.introduce;
            ItemVersionsLabel.Text = item.version + "   " + item.intro;
            ItemValueExpandBox.Text = item.valueExpand;
            ItemValueIsExist.Text = item.existsText;
            ItemIcoPictureBox.Image = myZiku.IconOrFile(item.iconExpand, item.valueExpand, item.id);
            if (run)
            {
                myZiku.run(item);
                this.Visible = false;
            }

            if (!isConnectItem)
            {
                item_Main = item;
                Refresh_ItemSubList();
            }
        }
        private void itemListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (itemListView.SelectedItems.Count > 0)
                {
                    Item item = Item.getInstance(itemListView.SelectedItems[0].Tag.ToString());
                    myZiku.run(item);
                }
            }
        }
        private void listView1_DragFileOver(string[] DragFileList, ListViewItem DragItemOrNull, object OListView)
        {
            itemListView.SaveSort();
            autoHideEn(true);
            Control.Item.Item.Add(DragFileList[0],false,true);
        }

        private void itemListView_SortChangeEvent(object OListView)
        {
            string I_ID = "";
            foreach (ListViewItem Item in itemListView.Items)
                I_ID += Item.Tag.ToString() + ";";
            Category.updateItem(category_Main.id, I_ID);
        }
        #endregion


        #region 子信息
        /// <summary>
        /// 刷新子信息列表
        /// </summary>
        private void Refresh_ItemSubList()
        {
            subInfo_Listview.Items.Clear();
            subInfo_Listview.BeginUpdate();
            //小抄
            ListViewItem lix = new ListViewItem();
            lix.Text = "";
            lix.SubItems.Add("小抄");
            lix.BackColor = Color.LightBlue;
            subInfo_Listview.Items.Add(lix);

            foreach (string xcID in item_Main.X_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                XiaoChao xc = XiaoChao.getInstance(xcID);
                if (xc != null)
                {
                    ListViewItem li = new ListViewItem();
                    li.Tag = xc.id;
                    li.Text = "xc";
                    li.SubItems.Add(xc.name);
                    subInfo_Listview.Items.Add(li);
                }
            }
            subInfo_Listview.Items.Add("");

            //关联项目
            ListViewItem lic = new ListViewItem();
            lic.Text = "";
            lic.SubItems.Add("关联项目");
            lic.BackColor = Color.LightBlue;
            subInfo_Listview.Items.Add(lic);

            foreach (string itemID in item_Main.CI_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Item item = Item.getInstance(itemID);
                if (item != null)
                {
                    ListViewItem li = new ListViewItem();
                    li.Tag = item.id;
                    li.Text = "item";
                    li.SubItems.Add(item.name);
                    subInfo_Listview.Items.Add(li);
                }
            }
            subInfo_Listview.EndUpdate();
        }
        private void subInfo_Listview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (subInfo_Listview.SelectedItems.Count != 0)
                if (subInfo_Listview.SelectedItems[0].Tag != null)
                    setItemSubSelect(subInfo_Listview.SelectedItems[0].Text, subInfo_Listview.SelectedItems[0].Tag.ToString());
        }
        private void subInfo_Listview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (subInfo_Listview.SelectedItems.Count != 0)
                if (subInfo_Listview.SelectedItems[0].Tag != null)
                    setItemSubSelect(subInfo_Listview.SelectedItems[0].Text, subInfo_Listview.SelectedItems[0].Tag.ToString(), true);//双击，运行
        }
        /// <summary>
        /// 读取子信息到界面
        /// </summary>
        /// <param name="run">是否执行主值</param>
        private void setItemSubSelect(string type, string id, bool run = false)
        {
            switch (type)
            {
                case "item":
                    setItemInfoToForm(id, run, true);
                    break;
                case "xc":
                    subInfo_Listview.Enabled = true;
                    XiaoChao xc = XiaoChao.getInstance(id);
                    if (xc != null)
                    {
                        ItemNameLabel.Text = xc.name;
                        ItemIntroduceBox.Text = xc.introduce;
                        ItemValueExpandBox.Text = xc.valueExpand;
                        ItemValueIsExist.Text = xc.existsText;
                        ItemIcoPictureBox.Image = myZiku.IconOrFile(null, xc.valueExpand, null);
                        if (run)
                            myZiku.run(xc);
                    }
                    break;
            }
        }
        #endregion
        #region 子信息列表右键菜单
        class SubInfoListMenu : ContextMenuStrip
        {
            private MainForm main;
            /// <summary>
            /// 子项目列表选中的ID
            /// </summary>
            private string ID;
            private ToolStripMenuItem itemEdit_Menu = new ToolStripMenuItem("编辑该项目");
            private ToolStripMenuItem itemRemoveConnect_Menu = new ToolStripMenuItem("移除该关联项目");
            private ToolStripMenuItem switchItem_Menu = new ToolStripMenuItem("切换到该关联项目");

            private ToolStripMenuItem xcAdd_Menu = new ToolStripMenuItem("添加一条小抄");
            private ToolStripMenuItem xcEdit_Menu = new ToolStripMenuItem("编辑这条小抄");
            private ToolStripMenuItem xcDel_Menu = new ToolStripMenuItem("删除这条小抄");
            public SubInfoListMenu(MainForm liv)
            {
                main = liv;
                itemEdit_Menu.Click += ItemEdit_Menu_Click;
                itemRemoveConnect_Menu.Click += ItemRemoveConnect_Menu_Click;
                xcAdd_Menu.Click += XcAdd_Menu_Click;
                xcEdit_Menu.Click += XcEdit_Menu_Click;
                xcDel_Menu.Click += XcDel_Menu_Click;
                switchItem_Menu.Click += SwitchItem_Menu_Click;
                Items.Add(itemEdit_Menu);
                Items.Add(itemRemoveConnect_Menu);
                Items.Add(xcAdd_Menu);
                Items.Add(xcEdit_Menu);
                Items.Add(xcDel_Menu);
                Items.Add(switchItem_Menu);
                Opening += SubInfoListMenu_Opening;
            }

            private void SwitchItem_Menu_Click(object sender, EventArgs e)
            {
                main.setItemInfoToForm(ID);
            }

            private void SubInfoListMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
            {
                itemEdit_Menu.Visible = false;
                itemRemoveConnect_Menu.Visible = false;
                switchItem_Menu.Visible = false;
                xcEdit_Menu.Visible = false;
                xcDel_Menu.Visible = false;
                if (main.subInfo_Listview.SelectedItems.Count != 0)
                {
                    if (main.subInfo_Listview.SelectedItems[0].Tag == null) return;
                    ID = main.subInfo_Listview.SelectedItems[0].Tag.ToString();
                    switch (main.subInfo_Listview.SelectedItems[0].Text)
                    {
                        case "xc":
                            xcDel_Menu.Visible = true;
                            xcEdit_Menu.Visible = true;
                            break;
                        case "item":
                            itemEdit_Menu.Visible = true;
                            itemRemoveConnect_Menu.Visible = true;
                            switchItem_Menu.Visible = true;
                            break;
                    }
                }
            }

            private void XcDel_Menu_Click(object sender, EventArgs e)
            {
                main.autoHideEn(false);
                XiaoChao xc = XiaoChao.getInstance(ID);
                if (MessageBox.Show("确定删除小抄“" + xc.name + "”？", "删除小抄", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Cancel) return;
                if (XiaoChao.delXiaoChao(ID))
                    main.setItemInfoToForm(main.item_Main.id);
                main.autoHideOn();
            }

            private void XcEdit_Menu_Click(object sender, EventArgs e)
            {
                main.autoHideEn(false);
                if (ZIKU.Control.Item.XiaoChao.editXC(ID))
                    main.setItemInfoToForm(main.item_Main.id);
                main.autoHideOn(false);
            }

            private void XcAdd_Menu_Click(object sender, EventArgs e)
            {
                main.autoHideEn(false);
                if (Control.Item.XiaoChao.addNewXC(main.item_Main.id) != null) main.setItemInfoToForm(main.item_Main.id);
                main.autoHideOn(false);
            }

            private void ItemRemoveConnect_Menu_Click(object sender, EventArgs e)
            {
                Item.delCI_ID(main.item_Main.id, ID);
                main.setItemInfoToForm(main.item_Main.id);
            }

            private void ItemEdit_Menu_Click(object sender, EventArgs e)
            {
                main.autoHideEn(false);
                Control.Item.Item.Edit(ID);
                main.setItemInfoToForm(main.item_Main.id);
                main.autoHideOn(false);
            }
        }
        #endregion



        #region 主窗口“项目右键菜单”实现类
        class itemMenu : Control.zMenu.ItemMenu
        {
            /// <summary>
            /// 菜单打开之前
            /// </summary>
            /// <param name="itemID">项目ID</param>
            /// <param name="categoryID">从分类移除的ID（null则不显示）</param>
            /// <param name="visibleAddNew">是否显示“添加新项目”</param>
            /// <param name="visibleTotalRemoveItem">是否显示“彻底移除该项目”</param>
            public override void Menu_opening(out string itemID, out string categoryID, out bool visibleAddNew, out bool visibleTotalRemoveItem, out bool visibleConnectItem)
            {
                visibleAddNew = true;
                visibleConnectItem = true;
                if (Instance.itemListView.SelectedItems.Count == 0)
                {
                    itemID = null;
                    categoryID = null;
                    visibleTotalRemoveItem = false;
                }
                else
                {
                    Instance.item_Main = Item.getInstance(Instance.itemListView.SelectedItems[0].Tag.ToString());
                    itemID = Instance.item_Main.id;
                    categoryID = Instance.category_Main.id;
                    visibleTotalRemoveItem = true;
                }
            }
            public override void addNewItem_before()
            {
                Instance.autoHideEn();
            }
            public override void addNewItem_after()
            {
                Instance.autoHideOn();
            }
            public override void addNewItem_succeed(string newID)
            {
                Instance.refreshCategoryItemList(Instance.category_Main.id);
            }
            public override void editItem_before()
            {
                Instance.autoHideEn();
            }
            public override void editItem_after(string itemID)
            {
                Instance.autoHideOn();
            }
            public override void editeItem_succeed(string itemID)
            {
                Instance.refreshCategoryItemList(Instance.category_Main.id);
            }

            public override bool removeFromThisCategory_before()
            {
                return true;
            }

            public override void removeFromThisCategory_succeed()
            {
                Instance.refreshCategoryItemList(Instance.category_Main.id);
            }

            public override void totalRemoveItem_succeed()
            {
                Instance.autoHideOn(false);
                Instance.refreshCategoryItemList(Instance.category_Main.id);
            }

            public override bool totalRemoveItem_before(string itemID)
            {
                Instance.autoHideEn(false);
                if (MessageBox.Show("确定彻底移除：“" + Instance.item_Main.name + "”？\r\n\r\n注意，这会移除所有关于该项目的信息！\r\n不会删除任何实际的文件", "彻底移除项目", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    Instance.autoHideOn(false); return true;
                }
                else
                {
                    Instance.autoHideOn(false);
                    return false;
                }
            }

            public override void connectItem_before()
            {
                Instance.autoHideEn(false);
            }
            public override void connectItem_after()
            {
                Instance.autoHideOn(false);
            }

            public override void manageXiaoChao_before()
            {
                Instance.autoHideEn(false);
            }
            public override void AddXiaoChao_after(string xcID)
            {
                Instance.autoHideOn();
                Instance.setItemInfoToForm(Instance.item_Main.id);
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE Item SET name = 'q1' WHERE id = 1;");
            sql.Append("UPDATE Item SET name = 'fox' WHERE id = 3;");
            SQLite.ExecuteNonQuery(sql.ToString(), ZIKU.DataBase.Config.Instance.Path);
        }
    }

    class Message
    {
        public const int USER = 0x0400;
        public const int WM_NOTIFYICON = USER + 101;
        public const int WM_MSG = USER + 102;
    }
}


