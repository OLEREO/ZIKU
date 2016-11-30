using System;
using System.Drawing;
using System.Windows.Forms;
using OLEREO.Library;
using OLEREO.Control;
using System.Data;
using System.Text.RegularExpressions;

namespace ZIKU.Control.Item
{

    public partial class Item : Form
    {
        /// <summary>
        /// 提示框实例
        /// </summary>
        private FloatingForm reminder = new FloatingForm();

        /// <summary>
        /// 缓存的图标路径
        /// </summary>
      //  private string buff_icon = "";

        /// <summary>
        /// 旧的UID（大写）
        /// </summary>
        private string oleUID = null;

        //设为静态，是为了可以在添加新项目之后，可以返回新项目的ID
        /// <summary>
        /// 编辑的项目ID或者为null(为null表示这是在创建新的项目)
        /// </summary>
        private static string idORnull = null;

        /// <summary>
        /// 是主窗口调用的吗
        /// </summary>
        private bool isMainForm = false;


        private Item()
        {
            InitializeComponent();
            Icon = Properties.Resources.ICON;
            valueBox.Floating = reminder;
            iv_x86_BOX.Floating = reminder;
            iv_x64_BOX.Floating = reminder;
            argumentsBox.Floating = reminder;
            workingdirBox.Floating = reminder;
            iPath_BOX.Floating = reminder;
            iconBox.Floating = reminder;
            FileInfoBox.Instance.owner = this;
        }

        /// <summary>
        /// 打开添加新的项目窗口,成功返回新的ID，失败NULL
        /// </summary>
        /// <param name="filePath">新项目的目录，可以不填写</param>
        /// <param name="Dialog">是否使用模式窗口</param>
        /// <returns></returns>
        public static string Add(string filePath,bool Dialog,bool isMainForm = false)
        {
            idORnull = null;
            Item e = new Item();
            e.isMainForm = isMainForm;
            e.initAndShow(filePath, Dialog);
            return idORnull;
        }
        /// <summary>
        /// 编辑项目窗口
        /// </summary>
        public static bool Edit(string itemId)
        {
            Item e = new Item();
            idORnull = itemId;
            e.initAndShow();
            if (idORnull != null) return true;
            return false;
        }

        /// <summary>
        /// 初始化，并显示窗口
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="Dialog">是否采用模式窗口</param>
        private void initAndShow(string filePath = null, bool Dialog = true)
        {
            if(idORnull != null)
            {
 
               ZIKU.DataBase.Item item = ZIKU.DataBase.Item.getInstance(idORnull);
                nameBox.Text = item.name;
                valueBox.text = item.valueShow;
                argumentsBox.text = item.argumentsShow;
                versionBox.Text = item.version;
                introBox.Text = item.intro;
                introduceBox.Text = item.introduce;
               // buff_icon = item.icon;
                item_Hide_main.Checked = item.isHideMain;
                item_Hide_search.Checked = item.isHideSearch;
                iPath_BOX.text = item.iPathShow;
                searchAliasBox.Text = item.searchAlias;
                workingdirBox.text = item.workingDirectoryShow;
                homePageBox.Text = item.homePage;
                onAdminBox.Checked = item.onAdmin;
                iv_x64_BOX.text = item.IV_x64Show;
                iv_x86_BOX.text = item.IV_x86Show;
                oleUID = item.UID.ToUpper();
                UIDBox.Text = item.UID;
              
                ItemIconBox.Image = myZiku.IconOrFile(item.icon, item.valueExpand, idORnull);
                iconBox.text = item.iconShow;
                refreshCategoryListBox(item.C_ID);

                okButton.Text = "保存";
                Text = "编辑项目：当前项目的UID是：" + item.UID;
                Tip.SetToolTip(value_Text, "%i-" + item.UID + "%");
                Tip.SetToolTip(x86Value_Text, "%i32-" + item.UID + "%");
                Tip.SetToolTip(x64Value_Text, "%i64-" + item.UID + "%");
                Tip.SetToolTip(arguments_Text, "%ia-" + item.UID + "%");
                Tip.SetToolTip(iPath_Text, "%ip-" + item.UID + "%\r\n%id-" + item.UID + "%");
                Tip.SetToolTip(workingDir_Text, "%iw-" + item.UID + "%");
            }
            else
            {
                Text = "新建项目";
                UIDBox.Text = "";
                if (filePath != null)
                {
                    //设置项目信息
                    FileInfoBox.ItemFileInfo re = new FileInfoBox.ItemFileInfo(filePath);
                    nameBox.Text = re.name;
                    versionBox.Text = re.version;
                    valueBox.text = re.value;
                    argumentsBox.text = re.arguments;
                    workingdirBox.text = re.workdir;
                    introBox.Text = re.induce;
                    iconBox.text = re.icon;
                                        
                    ItemIconBox.Image = myZiku.IconOrFile(re.icon, myZiku.exPand(re.value, ZIKU.DataBase.Config.Instance.Path), null);
                }
                refreshCategoryListBox(MainForm.Instance.category_Main.id);
            }
            Tools.SetForegroundWindow(this.Handle);
            if (Dialog)
                this.ShowDialog();//这里不要用 ShowDialog ，模式窗口会导致拖拽进入的窗口冻结
            else
                this.Show();
        }

        #region 刷新分类
        /// <summary>
        /// 刷新分类树
        /// </summary>
        /// <param name="categoryID">项目的归属项目</param>
        private void refreshCategoryListBox(string categoryID = "")
        {
            categoryBox.Nodes.Clear();
            //搜索所有的父分类
            foreach (string pID in ZIKU.DataBase.Config.Instance.pCsort.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                ZIKU.DataBase.Category c = ZIKU.DataBase.Category.getInstance(pID);
                if (c != null)
                {
                    TreeNode node = new TreeNode();
                    node.ExpandAll();
                    node.Tag = c.id;
                    node.Text = c.name;
                    categoryBox.Nodes.Add(node);
                    //判定是否勾选该分类
                    if (OLEREO.Library.Tools.AddValue(categoryID, c.id) == null)
                        node.Checked = true;

                    foreach (string subid in c.C_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        ZIKU.DataBase.Category subC = ZIKU.DataBase.Category.getInstance(subid);
                        
                        if (subC != null)
                        {
                            TreeNode node2 = new TreeNode();
                            node2.Tag = subC.id;
                            node2.Text = subC.name;
                            node.Nodes.Add(node2);
                            if (Tools.AddValue(categoryID, subC.id) == null)
                                node2.Checked = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region Icon 图标控件行为
        private void iconText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog opFileDialog = new OpenFileDialog();
            opFileDialog.Filter = "支持的图标格式|*.ico;*.png;*.jpg";
            opFileDialog.Title = "选择一个支持的图像文件作为自定义图标";
            string exIcon = myZiku.exPand(myZiku.variableToSave(iconBox.text, ZIKU.DataBase.Config.Instance.Path), ZIKU.DataBase.Config.Instance.Path);
            if (System.IO.File.Exists(exIcon) && iconBox.text != "")
            {
                System.IO.FileInfo ff = new System.IO.FileInfo(exIcon);
                opFileDialog.InitialDirectory = ff.Directory.FullName;
            }

            if (opFileDialog.ShowDialog() == DialogResult.OK)
            {
                iconBox.text = opFileDialog.FileName;
                Tip.SetToolTip(ItemIconBox, "自定义图标：" + opFileDialog.FileName);
                ItemIconBox.Image = myZiku.IconOrFile(iconBox.text, myZiku.exPand(myZiku.variableToSave(valueBox.text, ZIKU.DataBase.Config.Instance.Path), ZIKU.DataBase.Config.Instance.Path), null);
                if (idORnull != null)
                    System.IO.File.Delete(ZIKU.DataBase.Config.Instance.Path + ".cache\\icon\\" + idORnull + ".png");
            }
        }
        #endregion

        #region 值编辑框

        private string DragFileToName = null;
        private void ItemValueBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            string[] str_Drop = (string[])e.Data.GetData(DataFormats.FileDrop, true);//必须用字符串数组  
            DragFileToName = str_Drop[0];
        }

        private void ItemValueBox_DragDrop(object sender, DragEventArgs e)
        {
            FloatingTextBox ftb = sender as FloatingTextBox;
            ftb.text = DragFileToName;
            FileInfoBox.Instance.showFileInfo(DragFileToName);
        }

        private void value_Text_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(selectFileToBeValue(valueBox))
                FileInfoBox.Instance.showFileInfo(valueBox.text);
        }
        private void x86Value_Text_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selectFileToBeValue(iv_x86_BOX))
                FileInfoBox.Instance.showFileInfo(iv_x86_BOX.text);
        }

        private void x64Value_Text_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selectFileToBeValue(iv_x64_BOX))
                FileInfoBox.Instance.showFileInfo(iv_x64_BOX.text);
        }
        private void arguments_Text_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectFileToBeValue(argumentsBox);
        }
        private void workingDir_Text_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectPathToBeValue(workingdirBox);
        }
        private void iPath_Text_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            selectPathToBeValue(iPath_BOX);
        }
        bool selectFileToBeValue(FloatingTextBox ftb)
        {
            OpenFileDialog opFileDialog = new OpenFileDialog();
            opFileDialog.Title = "请选择一个文件";
            if (opFileDialog.ShowDialog() == DialogResult.OK)
            {
                ftb.text = opFileDialog.FileName;
                return true;          
            }
            return false;
        }
        void selectPathToBeValue(FloatingTextBox ftb)
        {
            FolderBrowserDialog dilog = new FolderBrowserDialog();
            dilog.Description = "请选择文件夹";
            DialogResult re = dilog.ShowDialog();
            if (re == DialogResult.OK || re == DialogResult.Yes)
            {
                ftb.text = dilog.SelectedPath;
            }
        }

        //展开编辑框的变量
        private void expandValue_rButtonClicked(FloatingTextBox THIS, oTextBox oTextBox, EventArgs e)
        {
            THIS.ShowFloating(myZiku.exPand(myZiku.variableToSave(oTextBox.Text, ZIKU.DataBase.Config.Instance.Path), ZIKU.DataBase.Config.Instance.Path));
        }
        #endregion

        #region 窗口行为  || 保存  || 取消
        //窗口关闭的时候
        private void onFormClosed(object sender, FormClosedEventArgs e)
        {
            if(isMainForm)
            {
                MainForm.Instance.autoHideOn();
                MainForm.Instance.refreshCategoryItemList(null);
            }
            if (reminder != null)
                reminder.Dispose();
        }
        private void cancel_Click(object sender, EventArgs e) { idORnull = null; Close(); }
        //窗口加载的时候
        private void Edit_Shown(object sender, EventArgs e)
        {
            if (idORnull == null) //如果不是编辑的话，去尝试获取主值的信息
                FileInfoBox.Instance.showFileInfo(valueBox.text);
        }
        //保存
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //判断所有信息是否填写正确

            //判断UID是否正确
            if (!checkUID())
            {
                MessageBox.Show("“UID”与现有项目重复或不符合要求：\r\n\r\n支持：中文、英文、数字、_", "“UID”填写不正确");
                return;
            }


            //名称
            if (nameBox.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("名称不能为空", "名称为空");
                return;
            }

            //判断是否重名
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Item WHERE name = '" + nameBox.Text.Replace("'", "''") + "' COLLATE NOCASE;", ZIKU.DataBase.Config.Instance.Path);
            if (dt.Rows.Count > 0) //具有同名的项目
            {
                if (dt.Rows.Count == 1) //同名只有一个，判断是不是和当前项目同一个
                {
                    if (dt.Rows[0]["id"].ToString() != idORnull) //不是同一个，说明这次修改成了一个现有的
                    {
                        MessageBox.Show("有一个重名的项目，请改变名称，又或者编辑已有的项目");
                        return;
                    }
                }
                else
                {
                    //具有一个以上的同名项目，绝对重名了。   
                    MessageBox.Show("有一个重名的项目，请改变名称，又或者编辑已有的项目");
                    return;
                }
            }

            //判断项目目录是否符合命名
            if (!Tools.isMeetDirPath(iPath_BOX.text))
            {
                MessageBox.Show("“项目目录”不符合命名要求，需要以X:\\开头，且路径中不能包含以下字符：\r\n\r\n/:*?\"<>|");
                return;
            }

            //判断主页填写是否正确
            if (homePageBox.Text.Replace(" ", "") != "")
            {
                bool https = homePageBox.Text.ToUpper().StartsWith(@"HTTPS://");
                bool http = homePageBox.Text.ToUpper().StartsWith(@"HTTP://");
                bool www = homePageBox.Text.ToUpper().StartsWith(@"WWW.");

                if (!(https || http || www))
                {
                    MessageBox.Show("主页要以下其中之一开头：\r\n\r\nhttps://\r\nhttp://\r\nwww.");
                    return;
                }
            }else { homePageBox.Text = ""; }


            //dataFolderName  过滤掉 name 中非法字符
            string newDataFolderName = Tools.filterFileName(nameBox.Text);

            if (iPath_BOX.text.Replace(" ", "") == "")
                iPath_BOX.text = "";

            //名称改变之后，要尝试修改现有的目录
            if (idORnull != null) //项目id不为空，表示这是编辑
            {
                ZIKU.DataBase.Item em = ZIKU.DataBase.Item.getInstance(idORnull);

                if ((em.dataFolderName != newDataFolderName) && iPath_BOX.text == "")
                {
                    string oldFullFolder = ZIKU.DataBase.Config.Instance.dataFolderExpand + "\\" + em.dataFolderName; //完整的旧目录名称
                    //if (iPath_BOX.text != "")
                    //    oldFullFolder = myZiku.exPand(myZiku.variableToSave(iPath_BOX.text, ZIKU.DataBase.Config.Instance.Path), ZIKU.DataBase.Config.Instance.Path);// + em.dataFolderName;
                    //else
                    //    oldFullFolder = ZIKU.DataBase.Config.Instance.dataFolderExpand + "\\" + em.dataFolderName;

                    if (/*(oldFullFolder.Replace(" ", "") != "") &&  没有必要判断是否空格，编辑的项目总会有资料目录名称*/ System.IO.Directory.Exists(oldFullFolder))
                    {
                        try
                        {
                            Tools.MyComputer.FileSystem.RenameDirectory(oldFullFolder, newDataFolderName); //尝试将旧的目录名称修改成新的
                        }
                        catch
                        {
                            newDataFolderName = em.dataFolderName; //如果失败了旧继续沿用旧的资料目录名称
                        }
                    }
                }
            }

            //为新的项目获取一个ID
            if ((idORnull == null))
                idORnull = SQLite.ExecuteNonQuery("INSERT INTO Item (name) values('新的项目')", ZIKU.DataBase.Config.Instance.Path).ToString();

            if (UIDBox.Text.Replace(" ", "") == "")
                UIDBox.Text = idORnull;

            //获取所有分类
            string allSelectC_ID = "";
            TreeNode tnn = Tools.GetNode(categoryBox.Nodes);
            foreach (TreeNode t in tnn.Nodes)
            {
                if (t.Checked) allSelectC_ID += t.Tag.ToString() + ";";
            }


            ZIKU.DataBase.Item oleItemInfo = ZIKU.DataBase.Item.getInstance(idORnull);
            //更新分类选择
            string[] newCID = Tools.SearchDifferent(oleItemInfo.C_ID, allSelectC_ID);
            foreach (string addCid in newCID[0].Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries))
            {
                ZIKU.DataBase.Category.addItem(addCid, idORnull);
            }

            foreach (string delCID in newCID[1].Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries))
            {
               ZIKU.DataBase.Category.removeItem(delCID, idORnull);
            }

            //判断新旧的图标值是否一样
            if (iconBox.text.Replace(" ", "") == "")
                iconBox.text = "";
            if (oleItemInfo.icon != iconBox.text)
            {
                System.IO.File.Delete(ZIKU.DataBase.Config.Instance.Path + ".cache\\icon\\" + idORnull + ".png");
            }

            //先把 UID 写入到数据库中，要不后面的将值转换为save时，无法识别当前项目的 UID
            SQLite.ExecuteNonQuery("UPDATE Item SET UID = '" + UIDBox.Text + "' WHERE id = " + idORnull, ZIKU.DataBase.Config.Instance.Path);


            SQLite.ExecuteNonQuery("UPDATE Item SET name = '" + nameBox.Text.Replace("'", "''")
                + "',value = '" + myZiku.variableToSave(valueBox.text, ZIKU.DataBase.Config.Instance.Path).Replace("'", "''")
                + "',arguments = '" + myZiku.variableToSave(argumentsBox.text, ZIKU.DataBase.Config.Instance.Path).Replace("'", "''")
                + "',version = '" + versionBox.Text.Replace("'", "''")
                + "',intro = '" + introBox.Text.Replace("'", "''")
                + "',introduce = '" + introduceBox.Text.Replace("'", "''")
                + "',C_ID = '" + allSelectC_ID
                + "',icon = '" + myZiku.variableToSave(iconBox.text,ZIKU.DataBase.Config.Instance.Path).Replace("'", "''")
                + "',hideMain = '" + item_Hide_main.Checked.ToString().ToUpper()
                + "',hideSearch = '" + item_Hide_search.Checked.ToString().ToUpper()
                + "',iPath = '" + myZiku.variableToSave(iPath_BOX.text, ZIKU.DataBase.Config.Instance.Path).Replace("'", "''")
                + "',searchAlias = '" + searchAliasBox.Text.Replace("'", "''")
                + "',nameF = '" + PinYinConverter.GetFirst(nameBox.Text).Replace("'", "''")
                + "',workingDirectory = '" + myZiku.variableToSave(workingdirBox.text, ZIKU.DataBase.Config.Instance.Path).Replace("'", "''")
                + "',homePage = '" + homePageBox.Text.Replace("'", "''")
                + "',dataFolderName = '" + newDataFolderName.Replace("'", "''")
                + "',onAdmin = '" + onAdminBox.Checked.ToString().ToUpper()
                + "',IV_x86 = '" + myZiku.variableToSave(iv_x86_BOX.text, ZIKU.DataBase.Config.Instance.Path).Replace("'", "''")
                + "',IV_x64 = '" + myZiku.variableToSave(iv_x64_BOX.text, ZIKU.DataBase.Config.Instance.Path).Replace("'", "''")
                + "' WHERE id = " + idORnull, ZIKU.DataBase.Config.Instance.Path);
            this.Close();
        }
        #endregion


        #region UID输入判断
        private void UIDBox_TextChanged(object sender, EventArgs e)
        {
            checkUID();
        }

        /// <summary>
        /// 坚持UID是否填写正确
        /// </summary>
        /// <returns></returns>
        bool checkUID()
        {
            if((UIDBox.Text.Replace(" ", "") == "") &&( oleUID == null))
            {
                UIDState(true);
                return true;
            }

            if (UIDBox.Text.ToUpper() == oleUID)
            {
                UIDState(true);
                return true;
            }

            Regex reg = new System.Text.RegularExpressions.Regex(@"^[\u4e00-\u9fa5_a-zA-Z0-9]+$");//匹配中文+英文+数字+下划线
            if (!reg.IsMatch(UIDBox.Text))
            {
                UIDState(false);
                return false;
            }
            DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM Item WHERE  UID LIKE '" + UIDBox.Text + "';", ZIKU.DataBase.Config.Instance.Path);
            if (dt.Rows.Count > 0)
            {
                UIDState(false);
                return false;
            }
            else
            {
                UIDState(true);
                return true;
            }
        }

        void UIDState(bool state)
        {
            if (state)
                UIDBox.BackColor = Color.LightSkyBlue;
            else
                UIDBox.BackColor = Color.Red;
        }


        #endregion

    
    }
}
