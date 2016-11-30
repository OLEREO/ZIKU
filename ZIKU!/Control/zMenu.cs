using System;
using System.Windows.Forms;
using ZIKU.DataBase;



namespace ZIKU.Control.zMenu
{
    #region ItemMenu
    public abstract  class ItemMenu : ContextMenuStrip
    {

        /// <summary>
        /// 添加新项目菜单（排除搜索窗口）
        /// </summary>
        protected ToolStripMenuItem addnNewItem_Menu = new ToolStripMenuItem("添加新项目");
        /// <summary>
        /// 编辑该项目菜单
        /// </summary>
        private ToolStripMenuItem editItem_Menu = new ToolStripMenuItem("编辑该项目");
        /// <summary>
        /// 从当前分类移除菜单（仅主窗口）
        /// </summary>
        private ToolStripMenuItem removeFromThisCategory_Menu = new ToolStripMenuItem("从当前分类移除");
        /// <summary>
        /// 
        /// 彻底移除该项目
        /// </summary>
        private ToolStripMenuItem totalRemoveItem_Menu = new ToolStripMenuItem("彻底删除该项目");
        /// <summary>
        /// 打开项目主值所在目录
        /// </summary>
        private ToolStripMenuItem openValuePath_Menu = new ToolStripMenuItem("主值文件所在目录");
        /// <summary>
        /// 打开项目资料目录
        /// </summary>
        private ToolStripMenuItem openDataFolder_Menu = new ToolStripMenuItem("资料目录");
        /// <summary>
        /// 打开项目主页
        /// </summary>
        private ToolStripMenuItem openHomePate_Menu = new ToolStripMenuItem("主页");
        /// <summary>
        /// 已经关联的项目
        /// </summary>
        private ToolStripMenuItem connectItem_Menu = new ToolStripMenuItem("关联项目");

        private ToolStripMenuItem admin_Menu = new ToolStripMenuItem("使用管理员权限运行");

        /// <summary>
        /// 项目的小抄
        /// </summary>
        private ToolStripMenuItem xc_Menu = new ToolStripMenuItem("小抄");

        private ToolStripMenuItem manageXiaoChao_Menu = new ToolStripMenuItem("管理小抄");
        private ToolStripMenuItem copyInfo_Menu = new ToolStripMenuItem("复制项目信息");
        private ToolStripMenuItem copyName_Menu = new ToolStripMenuItem("名称");
        private ToolStripMenuItem copyValue_Menu = new ToolStripMenuItem("主值");
        private ToolStripMenuItem copyX86_Menu = new ToolStripMenuItem("x86主值");
        private ToolStripMenuItem copyX64_Menu = new ToolStripMenuItem("x64主值");
        private ToolStripMenuItem copyIntro_Menu = new ToolStripMenuItem("项目简介");
        private ToolStripMenuItem copyIntroduce_Menu = new ToolStripMenuItem("项目介绍");

        private ToolStripMenuItem functionMenu = new ToolStripMenuItem("功能选项");
        private ToolStripMenuItem clearIconCache_Menu = new ToolStripMenuItem("清除该项目图标缓存");


        /// <summary>
        /// 构造函数
        /// </summary>
        public ItemMenu()
        {          
            addnNewItem_Menu.Click += addNewItem;            
            editItem_Menu.Click += editItem;
            removeFromThisCategory_Menu.Click += RemoveFromThisCategory_Menu_Click;
            totalRemoveItem_Menu.Click += totalRemoveItem;
            openValuePath_Menu.Click += openItemValuePath;
            openDataFolder_Menu.Click += openItemDataFolder;
            openHomePate_Menu.Click += openItemHomePate;
            manageXiaoChao_Menu.Click += ManageXiaoChao_Menu_Click;
            admin_Menu.Click += Admin_Menu_Click;
            clearIconCache_Menu.Click += ClearIconCache_Menu_Click;
            copyName_Menu.Click += CopyInfo_Menu_Click;
            copyValue_Menu.Click += CopyInfo_Menu_Click;
            copyX86_Menu.Click += CopyInfo_Menu_Click;
            copyX64_Menu.Click += CopyInfo_Menu_Click;
            copyIntro_Menu.Click += CopyInfo_Menu_Click;
            copyIntroduce_Menu.Click += CopyInfo_Menu_Click;

            copyInfo_Menu.DropDownItems.Add(copyName_Menu);
            copyInfo_Menu.DropDownItems.Add(copyValue_Menu);
            copyInfo_Menu.DropDownItems.Add(copyX86_Menu);
            copyInfo_Menu.DropDownItems.Add(copyX64_Menu);
            copyInfo_Menu.DropDownItems.Add(copyIntro_Menu);
            copyInfo_Menu.DropDownItems.Add(copyIntroduce_Menu);
       

            Items.Add(addnNewItem_Menu);
            Items.Add(editItem_Menu);
            Items.Add(openValuePath_Menu);
            Items.Add(openDataFolder_Menu);
            Items.Add(openHomePate_Menu);
            Items.Add(connectItem_Menu);
            Items.Add(xc_Menu);

            functionMenu.DropDownItems.Add(admin_Menu);
            functionMenu.DropDownItems.Add(openValuePath_Menu);
            functionMenu.DropDownItems.Add(copyInfo_Menu);
            functionMenu.DropDownItems.Add(removeFromThisCategory_Menu);
            functionMenu.DropDownItems.Add(totalRemoveItem_Menu);
            functionMenu.DropDownItems.Add(clearIconCache_Menu);

            Items.Add(functionMenu);

            Opening += new System.ComponentModel.CancelEventHandler(itemMenu_Opening);
        }

        private void ClearIconCache_Menu_Click(object sender, EventArgs e)
        {
            System.IO.File.Delete(Config.Instance.Path + ".cache\\icon\\" + item_zMenu.id + ".png");
        }

        private void Admin_Menu_Click(object sender, EventArgs e)
        {
            myZiku.run(item_zMenu,!item_zMenu.onAdmin);
        }

        private void CopyInfo_Menu_Click(object sender, System.EventArgs e)
        {
            if (sender == copyName_Menu)
                Clipboard.SetText(item_zMenu.name);
            else if (sender == copyValue_Menu)
                Clipboard.SetText(item_zMenu.valueExpand);
            else if (sender == copyX86_Menu)
                Clipboard.SetText(item_zMenu.IV_x86Expand);
            else if (sender == copyX64_Menu)
                Clipboard.SetText(item_zMenu.IV_x64Expand);
            else if (sender == copyIntro_Menu)
                Clipboard.SetText(item_zMenu.intro);
            else if (sender == copyIntroduce_Menu)
                Clipboard.SetText(item_zMenu.introduce);
        }

        private string _itemID, _categoryID;
        /// <summary>
        /// zMenu的实例
        /// </summary>
        ZIKU.DataBase.Item item_zMenu;
        /// <summary>
        /// 菜单打开之前
        /// </summary>
        /// <param name="itemID">项目ID</param>
        /// <param name="categoryID">从分类移除的ID（null则不显示）</param>
        /// <param name="visibleAddNew">是否显示“添加新项目”</param>
        /// <param name="visibleTotalRemoveItem">是否显示“彻底移除该项目”</param>
        public abstract void Menu_opening(out string itemID,out string categoryID,out bool visibleAddNew, out bool visibleTotalRemoveItem,out bool visibleConnectItem);
        /// <summary>
        /// 打开之前
        /// </summary>
        void itemMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool vAddNew, vTotalRemove, visibleConnectItem;
            Menu_opening(out _itemID, out _categoryID, out vAddNew, out vTotalRemove,out visibleConnectItem);
            //removeFromThisCategory_Menu.Visible = false;
            addnNewItem_Menu.Visible = vAddNew;

            editItem_Menu.Visible = false;
           //totalRemoveItem_Menu.Visible = false;
          //  openValuePath_Menu.Visible = false;
            openDataFolder_Menu.Visible = false;
            openHomePate_Menu.Visible = false;
            connectItem_Menu.Visible = false;
            xc_Menu.Visible = false;
            functionMenu.Visible = false;


            item_zMenu = ZIKU.DataBase.Item.getInstance(_itemID);
            if (item_zMenu != null)
            {
                editItem_Menu.Visible = true;
                functionMenu.Visible = true;
                openValuePath_Menu.Visible = (System.IO.File.Exists(item_zMenu.valueExpand) || System.IO.Directory.Exists(item_zMenu.valueExpand));
                removeFromThisCategory_Menu.Visible = (_categoryID != null);

                openDataFolder_Menu.Visible = true;
                openDataFolder_Menu.Enabled = true;
            
                openDataFolder_Menu.Text = "资料目录";
                if (item_zMenu.iPathExpand != "") //资料目录
                {
                    if (!OLEREO.Library.Tools.checkFolderCreation(item_zMenu.iPathExpand))
                    {
                        openDataFolder_Menu.Enabled = false;
                        openDataFolder_Menu.Text = "自定义“项目资料目录”无效";
                    }
                }
                else
                {
                    if(!OLEREO.Library.Tools.checkFolderCreation(Config.Instance.dataFolderExpand))
                    {
                        openDataFolder_Menu.Enabled = false;
                        openDataFolder_Menu.Text = "“项目资料总目录”无效，请检查数据库设置";
                    }
                }

                openHomePate_Menu.Visible = (item_zMenu.homePage != "");

                if (item_zMenu.onAdmin)
                    admin_Menu.Text = "以当前用户身份运行";
                else
                    admin_Menu.Text = "以管理员身份运行";

                totalRemoveItem_Menu.Visible = vTotalRemove;              
           
                //判断已经关联的项目
                if (visibleConnectItem)
                {
                    connectItem_Menu.Visible = true;
                    connectItem_Menu.DropDownItems.Clear();
                    ToolStripMenuItem manageCI = new ToolStripMenuItem("管理关联项目");
                    manageCI.Click += ConnectItem_Menu_Click;
                    connectItem_Menu.DropDownItems.Add(manageCI);
                    foreach (string ciID in OLEREO.Library.Tools.SplitString(item_zMenu.CI_ID))
                    {
                        ZIKU.DataBase.Item ciItem = ZIKU.DataBase.Item.getInstance(ciID);
                        if (ciItem != null)
                        {
                            if (connectItem_Menu.DropDownItems.Count == 1)
                                connectItem_Menu.DropDownItems.Add("-");
                            ToolStripMenuItem tempci = new ToolStripMenuItem(ciItem.name);
                            tempci.Click += Tempci_Click;
                            tempci.Tag = ciItem.id;
                            connectItem_Menu.DropDownItems.Add(tempci);
                        }
                    }
                }

                //判断小抄
                xc_Menu.Visible = true;
                xc_Menu.DropDownItems.Clear();
                xc_Menu.DropDownItems.Add(manageXiaoChao_Menu);
                foreach(string xID in OLEREO.Library.Tools.SplitString(item_zMenu.X_ID))
                {
                    ZIKU.DataBase.XiaoChao xc = ZIKU.DataBase.XiaoChao.getInstance(xID);
                    if (xc != null)
                    {
                        if (xc_Menu.DropDownItems.Count == 1)
                            xc_Menu.DropDownItems.Add("-");
                        ToolStripMenuItem tempXC = new ToolStripMenuItem(xc.name);
                        tempXC.Click += TempXC_Click;
                        tempXC.Tag = xc.id;
                        xc_Menu.DropDownItems.Add(tempXC);
                    }
                }

                //复制
                if (item_zMenu.value == "")
                    copyValue_Menu.Visible = false;
                else copyValue_Menu.Visible = true;
                if (item_zMenu.IV_x86 == "")
                    copyX86_Menu.Visible = false;
                else copyX86_Menu.Visible = true;
                if (item_zMenu.IV_x64 == "")
                    copyX64_Menu.Visible = false;
                else copyX64_Menu.Visible = true;
                if (item_zMenu.intro == "")
                    copyIntro_Menu.Visible = false;
                else copyIntro_Menu.Visible = true;
                if (item_zMenu.introduce == "")
                    copyIntroduce_Menu.Visible = false;
                else copyIntroduce_Menu.Visible = true;
            }
        }


        /// <summary>
        /// 点击“关联项目”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tempci_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem tsm = (ToolStripMenuItem)sender;
            myZiku.run(ZIKU.DataBase.Item.getInstance(tsm.Tag.ToString()));
        }

        private void TempXC_Click(object sender, System.EventArgs e)
        {
            ToolStripMenuItem tsm = (ToolStripMenuItem)sender;
            ZIKU.DataBase.XiaoChao xc = ZIKU.DataBase.XiaoChao.getInstance(tsm.Tag.ToString());          
                myZiku.run(xc);
        }

        /// <summary>
        /// 在添加新项目之前
        /// </summary>
        public virtual void addNewItem_before() { }
        /// <summary>
        /// 添加新项目之后
        /// </summary>
        public virtual void addNewItem_after() { }
        /// <summary>
        /// 成功添加新项目
        /// </summary>
        /// <param name="newID">新的项目ID</param>
        public virtual void addNewItem_succeed(string newID) { }
        /// <summary>
        /// 添加新项目
        /// </summary>
        private void addNewItem(object obj, System.EventArgs e)
        {
            addNewItem_before();
            string newID = Item.Item.Add(null,true);
            addNewItem_after();
            if (newID != null)
                addNewItem_succeed(newID);
        }

        /// <summary>
        /// 编辑项目之前
        /// </summary>
        public virtual void editItem_before() { }
        /// <summary>
        /// 成功编辑项目
        /// </summary>
        /// <param name="itemID"></param>
        public virtual void editeItem_succeed(string itemID) { }
        /// <summary>
        /// 编辑项目之后
        /// </summary>
        /// <param name="itemID"></param>
        public virtual void editItem_after(string itemID) { }
        /// <summary>
        /// 编辑项目
        /// </summary>
        private void editItem(object obj, System.EventArgs e)
        {
            editItem_before();
            if (ZIKU.Control.Item.Item.Edit(_itemID))
                editeItem_succeed(_itemID);
            editItem_after(_itemID);
        }

        /// <summary>
        /// 从分类中移除项目，返回结果
        /// </summary>
        public virtual bool removeFromThisCategory_before() { return false; }
        /// <summary>
        /// 成功将项目移出分类
        /// </summary>
        public virtual void removeFromThisCategory_succeed() { }
        private void RemoveFromThisCategory_Menu_Click(object sender, System.EventArgs e)
        {      
            if (removeFromThisCategory_before())
            {
                if (ZIKU.DataBase.Category.removeItem(_categoryID, _itemID))
                    removeFromThisCategory_succeed();
            }
        }       

        /// <summary>
        /// 彻底移除项目之前，返回询问结果
        /// </summary>
        public virtual bool totalRemoveItem_before(string itemID) { return false; }
        /// <summary>
        /// 在彻底移除项目之后
        /// </summary>
        /// <returns></returns>
        public virtual void totalRemoveItem_succeed() { }
        /// <summary>
        /// 彻底移除项目
        /// </summary>
        private void totalRemoveItem(object obj, System.EventArgs e)
        {       
            if(totalRemoveItem_before(_itemID))
            {
                ZIKU.DataBase.Item.totalDelItem(_itemID);
                totalRemoveItem_succeed();
            }
        }

        /// <summary>
        /// 打开项目主值所在目录
        /// </summary>
        private void openItemValuePath(object obj, System.EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + item_zMenu.valueExpand);
        }

        /// <summary>
        /// 打开项目资料目录
        /// </summary>
        private void openItemDataFolder(object obj, System.EventArgs e)
        {
            string path;
            if (item_zMenu.iPathExpand != "")
            {
                    System.IO.Directory.CreateDirectory(item_zMenu.iPathExpand);
                    System.Diagnostics.Process.Start(item_zMenu.iPathExpand);                           
            }
            else
            {
                if (ZIKU.DataBase.Config.Instance.dataFolderExpand != null)
                {
                    path = (ZIKU.DataBase.Config.Instance.dataFolderExpand + "\\" + item_zMenu.dataFolderName).Replace("\\\\", "\\");
                    System.IO.Directory.CreateDirectory(path);
                    System.Diagnostics.Process.Start(path);
                }
            }
        }

        /// <summary>
        /// 管理小抄之前
        /// </summary>
        public virtual void manageXiaoChao_before() { }
        /// <summary>
        /// 成功添加新小抄
        /// </summary>
        /// <param name="xcID"></param>
        public virtual void AddXiaoChao_after(string xcID) { }
        private void ManageXiaoChao_Menu_Click(object sender, System.EventArgs e)
        {
            manageXiaoChao_before();
            new Item.ManageXiaoChao(item_zMenu.id).ShowDialog();
            AddXiaoChao_after(item_zMenu.id);
        }
        /// <summary>
        /// 管理关联项目之前
        /// </summary>
        public virtual void connectItem_before() { }
        /// <summary>
        /// 管理关联项目之后
        /// </summary>
        public virtual void connectItem_after() { }
        /// <summary>
        /// 编辑关联项目
        /// </summary>
        private void ConnectItem_Menu_Click(object sender, System.EventArgs e)
        {
            connectItem_before();
            Item.Manage.ManageConnectItems(item_zMenu.id);
            connectItem_after();
        }

        /// <summary>
        /// 打开项目主页
        /// </summary>
        private void openItemHomePate(object obj, System.EventArgs e)
        {
            try { System.Diagnostics.Process.Start(item_zMenu.homePage); } catch
            {
                OLEREO.Control.EmailContact.erroReport(item_zMenu.homePage, "打开“项目主页”出错", "打开项目主页出错了，这通常是不应该发生的，你愿意协助我修复该错误吗？");
            }
        } 
    }
    #endregion

    #region TrayOrSettingMenu
    class TrayOrSettingMenu : ContextMenuStrip
    {
        private ToolStripMenuItem tools_Menus = new ToolStripMenuItem("工具箱");

        private ToolStripMenuItem manage0SwitchDatabase_Menu = new ToolStripMenuItem("管理或切换数据库");
        private ToolStripMenuItem categoryManage_Menu = new ToolStripMenuItem("分类管理");
        private ToolStripMenuItem itemManage_Menu = new ToolStripMenuItem("项目管理");

        private ToolStripMenuItem matchItem_Menu = new ToolStripMenuItem("查找系统目录中未被记录的项目");
        private ToolStripMenuItem matchVar_Menu = new ToolStripMenuItem("查找项目中可替换为内部变量的主值");
        private ToolStripMenuItem replaceItemValue_Menu = new ToolStripMenuItem("替换项目的主值");

        private ToolStripMenuItem varManage_Menu = new ToolStripMenuItem("数据库内部变量");
        private ToolStripMenuItem gVarManage_Menu = new ToolStripMenuItem("全局内部变量");


        /// <summary>
        /// 设置
        /// </summary>
        private ToolStripMenuItem setting_Menu = new ToolStripMenuItem("设置");
        /// <summary>
        /// 意见反馈
        /// </summary>
        private ToolStripMenuItem emailContact_Menu = new ToolStripMenuItem("反馈");

        /// <summary>
        /// 关于ZIKU!
        /// </summary>
        private ToolStripMenuItem about_Menu = new ToolStripMenuItem("关于");


        /// <summary>
        /// 退出
        /// </summary>
        private ToolStripMenuItem exit_Menu = new ToolStripMenuItem("退出");


        /// <summary>
        /// 托盘或设置菜单
        /// </summary>
        /// <param name="tos">获取托盘还是设置菜单</param>
        /// <param name="mForm">主窗口引用</param>
        public TrayOrSettingMenu()
        { 
            manage0SwitchDatabase_Menu.Click += Manage0SwitchDatabaseMenu_Click;
            categoryManage_Menu.Click += CategoryManageMenu_Click;
            itemManage_Menu.Click += ItemManageMenu_Click;
            matchItem_Menu.Click += MatchItem_Menu_Click;
            matchVar_Menu.Click += MatchVar_Menu_Click;
            replaceItemValue_Menu.Click += ReplaceItemValue_Menu_Click;
            setting_Menu.Click += SettingMenu_Click;
            about_Menu.Click += AboutMenu_Click;
            emailContact_Menu.Click += EmailContact_Menu_Click;
            varManage_Menu.Click += VarManage_Menu_Click;
            gVarManage_Menu.Click += GVarManage_Menu_Click;

            tools_Menus.DropDownItems.Add(manage0SwitchDatabase_Menu);
            tools_Menus.DropDownItems.Add(categoryManage_Menu);
            tools_Menus.DropDownItems.Add(itemManage_Menu);
            tools_Menus.DropDownItems.Add("-");
            tools_Menus.DropDownItems.Add(varManage_Menu);
            tools_Menus.DropDownItems.Add(gVarManage_Menu);            
            tools_Menus.DropDownItems.Add("-");
            tools_Menus.DropDownItems.Add(matchItem_Menu);
            tools_Menus.DropDownItems.Add(matchVar_Menu);
            tools_Menus.DropDownItems.Add(replaceItemValue_Menu);
            Items.Add(tools_Menus);
            Items.Add(setting_Menu);
            Items.Add(emailContact_Menu);
            Items.Add(about_Menu);
            
                exit_Menu.Click += ExitMenu_Click;
                Items.Add(exit_Menu);
            
        }

        private void ReplaceItemValue_Menu_Click(object sender, System.EventArgs e)
        {
            MainForm.Instance.autoHideEn(false);
            new Toolkit.ReplaceItemValue().ShowDialog();
             MainForm.Instance.autoHideOn(false);
        }

        private void GVarManage_Menu_Click(object sender, System.EventArgs e)
        {
             MainForm.Instance.autoHideEn(false);
            Variable.Manage.ShowManage(true);
             MainForm.Instance.autoHideOn(false);
        }

        private void VarManage_Menu_Click(object sender, System.EventArgs e)
        {
             MainForm.Instance.autoHideEn(false);
            Variable.Manage.ShowManage(false);
             MainForm.Instance.autoHideOn(false);
        }

        private void MatchVar_Menu_Click(object sender, System.EventArgs e)
        {
             MainForm.Instance.autoHideEn(false);
            Toolkit.MatchVarValue m = new Toolkit.MatchVarValue();
            m.Show();
             MainForm.Instance.autoHideOn(false);
        }

        private void MatchItem_Menu_Click(object sender, System.EventArgs e)
        {
             MainForm.Instance.autoHideEn(false);
            Toolkit.MatchPathItem m = new Toolkit.MatchPathItem();
            m.Show();
             MainForm.Instance.autoHideOn(false);
        }

        private void EmailContact_Menu_Click(object sender, System.EventArgs e)
        {
             MainForm.Instance.autoHideEn(false);
            OLEREO.Control.EmailContact.contact();
             MainForm.Instance.autoHideOn(false);
        }

        private void AboutMenu_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ziku.olereo.com/");
        }

        private void SettingMenu_Click(object sender, System.EventArgs e)
        {
             MainForm.Instance.autoHideEn(false);
            new setting().ShowDialog();       
             MainForm.Instance.autoHideOn(false);
             MainForm.Instance.UnRegisterHotKey();
             MainForm.Instance.RegisterHotKey();
        }

        private void ItemManageMenu_Click(object sender, System.EventArgs e)
        {           
             MainForm.Instance.autoHideEn(false);
            Item.Manage.ManageItems();
             MainForm.Instance.autoHideOn(false);
             MainForm.Instance.refreshCategoryItemList(MainForm.Instance.category_Main.id);
        }

        private void CategoryManageMenu_Click(object sender, System.EventArgs e)
        {
           
             MainForm.Instance.autoHideEn(false);
            Category.Manage.show();
             MainForm.Instance.autoHideOn(false);
             MainForm.Instance.RefreshFormInfo();
        }

        private void Manage0SwitchDatabaseMenu_Click(object sender, System.EventArgs e)
        {
             MainForm.Instance.autoHideEn(false);
            DataBase.Manage.show();
             MainForm.Instance.RefreshFormInfo();
             MainForm.Instance.autoHideOn(false);
        }

        private void ExitMenu_Click(object sender, System.EventArgs e)
        {
             MainForm.Instance.Close();
        }

      
    }
    #endregion
}
