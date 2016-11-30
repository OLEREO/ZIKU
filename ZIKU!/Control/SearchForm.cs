using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OLEREO.Control;
using OLEREO.Library;
using System.Collections.Generic;
using System.Text;

namespace ZIKU.Control
{
    public partial class SearchFormOle : Form
    {

        private bool canDone = false;
        public void setShow()
        {
            MainForm.Instance.autoHideEn(true);
            canDone = true;
            Show();
            SeBox.Focus();
            Tools.SetForegroundWindow(Handle);
        }
        void setItemInfo(string itemID)
        {
            MainForm.Instance.setItemInfoToForm(itemID);
            Hide();
            MainForm.Instance.autoHideOn(true);
        }

        public void setDone()
        {
            Hide();
            SeBox.Text = "";
            MainForm.Instance.autoHideOn();
        }

        /// <summary>
        /// 搜索窗口上的项目实例
        /// </summary>
        private ZIKU.DataBase.Item item_SeForm;
        private static SearchFormOle _instance = new SearchFormOle();
        public static SearchFormOle Instance { get { return _instance; } }

        /// <summary>
        /// 构造器
        /// </summary>
        private SearchFormOle()
        {
            InitializeComponent();
            clearItemBox();
            SeBox.Text = "";
            Tools.SetControlEnabled(title_Label, false);
            searchItemMenu = new seItemMenu();
            searchXiaoChaoMenu = new XiaoChaoMenu(this);
    
            if (SettingDataBase.Config.Instance.isAltMode)
                altMode.Checked = true;
            else
                imeMode.Checked = true;
            //开启双缓冲
            DoubleBuffered = true;
        }



        /// <summary>
        /// 进行“搜索”
        /// </summary>
        protected void setSearchResult()
        {
            if (SeBox.Text.StartsWith("  "))
                title_Label.Text = "执行系统命令";
            else
            {
                title_Label.Text = nowSeMode.Intro;
                if (SeBox.Text == " ")
                {
                    clearItemBox();
                    return;
                }
                string seKey = SeBox.Text;

                #region 选择搜索类别
                string seHead = SeBox.Text.ToUpper();
                if (seHead.Length >= 3)
                    seHead = seHead.Substring(0, 2);
                switch (seHead)
                {
                    case "J ":
                        setSearchMode(ItemIntroMode.Instance);
                        seKey = SeBox.Text.Remove(0, 2);
                        break;
                    case "F ":
                        setSearchMode(CategoryMode.Instance);
                        seKey = SeBox.Text.Remove(0, 2);
                        break;
                    case "X ":
                        setSearchMode(XiaoChaoMode.Instance);
                        seKey = SeBox.Text.Remove(0, 2);
                        break;
                    case "S ":
                        setSearchMode(AllItemMode.Instance);
                        seKey = SeBox.Text.Remove(0, 2);
                        break;
                    default:
                        setSearchMode(ItemNameMode.Instance);
                        break;
                }
                #endregion

                DataTable dt = SQLite.ExecuteDataTable(nowSeMode.getSearchSQL(seKey), ZIKU.DataBase.Config.Instance.Path);
                RestItemBox(dt);
            }
        }

        /// <summary>
        /// 设置窗口上的项目信息
        /// </summary>
        /// <param name="id">项目的ID</param>
        private void SetItemIntroduce(string id)
        {
            item_SeForm = ZIKU.DataBase.Item.getInstance(id); 
            ItemIntroduce.Text = item_SeForm.introduce;
            title_Label.Text = item_SeForm.name;
        }

        private void SeBox_Enter(object sender, EventArgs e)
        {
            title_Label.Text = nowSeMode.Intro;
            ItemIntroduce.Text = "";
        }

        #region 输入框
        /// <summary>
        /// 输入框“文字改变”
        /// </summary>
        private void SeBox_TextChanged(object sender, EventArgs e)
        {
            if (SeBox.Text == "")
            {
                clearItemBox();
                setSearchMode(ItemNameMode.Instance);
                ItemIntroduce.Text = "";
                SeBox.Focus();
            }
            else setSearchResult();       
        }
        private void SeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = seBoxKeyHandled;
        }
        bool seBoxKeyHandled = false;
        /// <summary>
        /// 输入框“按键按下”
        /// </summary>
        private void SeBox_KeyDown(object sender, KeyEventArgs e)
        {
            seBoxKeyHandled = false;
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (SeBox.Text != "")
                        SeBox.Text = "";
                    else
                        setDone();
                    break;       
                case Keys.Enter:
                    if(SeBox.Text.StartsWith("  "))
                    {                        
                        try { System.Diagnostics.Process.Start(SeBox.Text.TrimStart(' ')); } catch {
                            OLEREO.Control.PushForm.pushInfo("无效的系统命令", "“" + SeBox.Text.TrimStart(' ') + "”不是一条有效的系统命令");
                        }                     
                        setDone();
                    }else if (itemBox1.Visible)
                    {
                        nowSeMode.Execute(itemBox1.Tag.ToString());
                    }
                    break;
                //下方向键
                case Keys.Down:       
                    if (itemBox1.Visible)
                        itemBox1.Focus();
                    e.Handled = true;
                    break;
            }

            //if ((e.Modifiers == Keys.Alt) && imeMode.Checked)//当前按下了 ALT 和 当前是 ALT 模式
            //{//通过ALT+数字键激活项目
            //    bool eHandled = true;
            //    int ss = SeBox.SelectionStart;
            //    switch (e.KeyCode)
            //    {
            //        case Keys.D1:
            //            SeBox.Text = SeBox.Text.Insert(SeBox.SelectionStart, "1");
            //            SeBox.SelectionStart = ss + 1;
            //            break;
            //        case Keys.D2:
            //            SeBox.Text = SeBox.Text.Insert(SeBox.SelectionStart, "2");
            //            SeBox.SelectionStart = ss + 1;
            //            break;
            //        case Keys.D3:
            //            SeBox.Text = SeBox.Text.Insert(SeBox.SelectionStart, "3");
            //            SeBox.SelectionStart = ss + 1;
            //            break;
            //        case Keys.D4:
            //            SeBox.Text = SeBox.Text.Insert(SeBox.SelectionStart, "4");
            //            SeBox.SelectionStart = ss + 1;
            //            break;
            //        case Keys.D5:
            //            SeBox.Text = SeBox.Text.Insert(SeBox.SelectionStart, "5");
            //            SeBox.SelectionStart = ss + 1;
            //            break;
            //        case Keys.D6:
            //            SeBox.Text = SeBox.Text.Insert(SeBox.SelectionStart, "6");
            //            SeBox.SelectionStart = ss + 1;
            //            break;
            //        case Keys.D7:
            //            SeBox.Text = SeBox.Text.Insert(SeBox.SelectionStart, "7");
            //            SeBox.SelectionStart = ss + 1;
            //            break;
            //        case Keys.D8:
            //            SeBox.Text = SeBox.Text.Insert(SeBox.SelectionStart, "8");
            //            SeBox.SelectionStart = ss + 1;
            //            break;
            //        case Keys.D9:
            //            SeBox.Text = SeBox.Text.Insert(SeBox.SelectionStart, "9");
            //            SeBox.SelectionStart = ss + 1;
            //            break;
            //        case Keys.OemMinus:
            //            SeBox.Text = SeBox.Text.Insert(SeBox.SelectionStart, "-");
            //            SeBox.SelectionStart = ss + 1;
            //            break;
            //        case Keys.Oemplus:
            //            SeBox.Text = SeBox.Text.Insert(SeBox.SelectionStart, "=");
            //            SeBox.SelectionStart = ss + 1;
            //            break;
            //        default:
            //            eHandled = false;
            //            break;
            //    }
            //    seBoxKeyHandled = eHandled;
            //}
            if (imeMode.Checked)
            {
                bool eHandled = true;
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        if (itemBox1.Visible)
                            itemBox1.Execute();
                        break;
                    case Keys.D2:
                        if (itemBox2.Visible)
                            itemBox2.Execute();
                        break;
                    case Keys.D3:
                        if (itemBox3.Visible)
                            itemBox3.Execute();
                        break;
                    case Keys.D4:
                        if (itemBox4.Visible)
                            itemBox4.Execute();
                        break;
                    case Keys.D5:
                        if (itemBox5.Visible)
                            itemBox5.Execute();
                        break;
                    case Keys.D6:
                        if (itemBox6.Visible)
                            itemBox6.Execute();
                        break;
                    case Keys.D7:
                        if (itemBox7.Visible)
                            itemBox7.Execute();
                        break;
                    case Keys.D8:
                        if (itemBox8.Visible)
                            itemBox8.Execute();
                        break;
                    case Keys.D9:
                        if (itemBox9.Visible)
                            itemBox9.Execute();
                        break;
                    case Keys.OemMinus:
                        lastPage();
                        break;
                    case Keys.Oemplus:
                        nextPage();
                        break;
                    default:
                        eHandled = false;
                        break;
                }
               seBoxKeyHandled = eHandled;
            }
        }

        /// <summary>
        /// 输入框“按键抬起”
        /// </summary>
        private void SeBox_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                    if (SeBox.Text == "")
                        setSearchMode(ItemNameMode.Instance);
                    break;
                case Keys.Escape:
                    if (SeBox.Text == "")
                        setSearchMode(ItemNameMode.Instance);
                    break;
            }
        }
        #endregion

        private XiaoChaoMenu searchXiaoChaoMenu;
        #region 小抄右键菜单类
        /// <summary>
        /// 小抄右键菜单类
        /// </summary>
        class XiaoChaoMenu : ContextMenuStrip
        {
            private SearchFormOle seForm;
            private ZIKU.DataBase.XiaoChao xc;
            private ToolStripMenuItem editXC_Menu = new ToolStripMenuItem("编辑该小抄");
            private ToolStripMenuItem openXCPath_Menu = new ToolStripMenuItem("打开该小抄主值所在目录");

            public XiaoChaoMenu(SearchFormOle seForm)
            {
                this.seForm = seForm;
                editXC_Menu.Click += EditXC_Menu_Click;
                openXCPath_Menu.Click += OpenXCValueLocation_Click;
                this.Items.Add(editXC_Menu);
                this.Items.Add(openXCPath_Menu);
                this.Opening += XiaoChaoMenu_Opening;
            }

            private void XiaoChaoMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
            {
                editXC_Menu.Enabled = false;
                openXCPath_Menu.Visible = false;
                xc =ZIKU.DataBase.XiaoChao.getInstance(seForm.nowSelectItemBox.Tag.ToString());
                if (xc != null)
                {
                    editXC_Menu.Enabled = true;
                    if (xc.valueExpand != "" && (System.IO.File.Exists(xc.valueExpand) || System.IO.Directory.Exists(xc.valueExpand)))
                        openXCPath_Menu.Visible = true;
                }
            }

            private void OpenXCValueLocation_Click(object sender, EventArgs e)
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select," + xc.valueExpand);
            }

            private void EditXC_Menu_Click(object sender, EventArgs e)
            {
                Instance.canDone = false;
                seForm.Hide();
                Item.XiaoChao.editXC(xc.id);
                seForm.setDone();
            }
        }
        #endregion

        private seItemMenu searchItemMenu;
        #region 搜索窗口实现的“项目右键菜单”
        class seItemMenu : ZIKU.Control.zMenu.ItemMenu
        {
            public override void connectItem_after()
            {
                Instance.setDone();
            }

            public override void connectItem_before()
            {
               // Instance.done = false;
                Instance.Hide();
            }
            public override void editItem_after(string itemID)
            {
                Instance.setDone();
            }

            public override void editItem_before()
            {
                Instance.canDone = false;
                Instance.Hide();
            }

            public override void Menu_opening(out string itemID, out string categoryID, out bool visibleAddNew, out bool visibleTotalRemoveItem, out bool visibleConnectItem)
            {
                itemID = Instance.nowSelectItemBox.Tag.ToString();
                categoryID = null;
                visibleAddNew = false;
                visibleTotalRemoveItem = true;
                visibleConnectItem = true;
            }

            public override void totalRemoveItem_succeed()
            {
                Instance.SeBox.Focus();
                Instance.setSearchResult();
            }

            public override bool totalRemoveItem_before(string itemID)
            {
                //Instance.done = false;
                ZIKU.DataBase.Item item = ZIKU.DataBase.Item.getInstance(itemID);
                if (item != null)
                {
                    if (MessageBox.Show("确定彻底移除：“" + item.name + "”？\r\n\r\n注意，这会移除所有关于该项目的信息！\r\n不会删除任何实际的文件", "彻底移除项目", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                       // Instance.done = true;
                        return true;
                    }
                }
               // Instance.done = true;
                return false;
            }

            public override void manageXiaoChao_before()
            {
                //Instance.done = false;
                Instance.Hide();
            }

            public override void AddXiaoChao_after(string xcID)
            {
                Instance.setDone();
            }
        }
        #endregion

        #region 窗口行为
        bool formMove = false;       //是否开始移动
        int currentXPosition = 0;    //当前鼠标X坐标
        int currentYPosition = 0;    //当前鼠标Y坐标

        //函数:鼠标按下
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            formMove = true;                       //鼠标按下开始移动
            currentXPosition = MousePosition.X;    //鼠标的X坐标为当前窗体左上角X坐标
            currentYPosition = MousePosition.Y;    //鼠标的Y坐标为当前窗体的左上角Y坐标
        }
        //函数:鼠标移动
        private void Form_MouseMove(object sender, MouseEventArgs e)
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
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            formMove = false;     //停止移动
        }
        //函数：鼠标离开
        private void Form_MouseLeave(object sender, EventArgs e)
        {
            //初始状态
            currentXPosition = 0;
            currentYPosition = 0;
            formMove = false;
        }

        //窗口失去焦点
        private void SearchForm_Deactivate(object sender, EventArgs e)
        {
            if (canDone)
                setDone();
        }

        //重写系统键处理方式
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab:
                    if (altMode.Checked)
                    {
                        title_Label.Text = "切换至：" + imeMode.Text;
                        imeMode.Checked = true;
                    }
                    else
                    {
                        title_Label.Text = "切换至：" + altMode.Text;
                        altMode.Checked = true;
                    }
                    return true;
                case Keys.Up:
                    if (itemBox1.Focused)
                    {
                        if (currentlyPage > 1)
                        {
                            if (lastPage())
                            {
                                itemBox9.Focus();
                                return true;
                            }
                        }
                        else
                            SeBox.Focus();
                        return true;
                    }
                    break;
                case Keys.Down:
                   if(currentlyPage < countPage)
                    {
                        if (itemBox9.Focused)
                        {
                           if (nextPage())
                            {
                                itemBox1.Focus();
                                return true;
                            }
                        }
                    }
                    break;
                case Keys.Right:
                    if(nowSelectItemBox != null)
                    {
                        if(nowSelectItemBox.ContextMenuStrip !=null)
                        {
                            Point screenPoint = PointToScreen(nowSelectItemBox.Location);
                            screenPoint.X += 20;
                            screenPoint.Y += 38;
                            nowSelectItemBox.ContextMenuStrip.Show(screenPoint);
                            return true;
                        }
                    }                    
                    break;
                case Keys.Left:
                    if (isItemMode(nowSeMode))
                    {
                        setItemInfo(nowSelectItemBox.Tag.ToString());
                        setDone();
                    }
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }
        #endregion

        #region ItemBox 列表行为
        Image noIcon = Properties.Resources.ICON.ToBitmap();
        /// <summary>
        /// 当前的页面
        /// </summary>
        private int currentlyPage = 1;
        /// <summary>
        /// 总共的页数
        /// </summary>
        private int countPage = 0;

        /// <summary>
        /// 项目数据库表
        /// </summary>
        private DataTable pageDT = null;
        /// <summary>
        /// 当前选中的ItemBox
        /// </summary>
        private ItemBox nowSelectItemBox = null;

        //----------设置页面

        /// <summary>
        /// 传入新的项目数据表列表(无需处理重复)
        /// </summary>
        /// <param name="dt"></param>
        void RestItemBox(DataTable dt)
        {
            SeBox.Focus();
            if(dt == null)
            {
                clearItemBox();
                return;
            }
            if (dt.Rows.Count ==0)
            {
                clearItemBox();
                return;
            }
            //去除重复的项目
            DataView dv = new DataView(dt);
            pageDT = dv.ToTable(true, nowSeMode.needColumn);

            currentlyPage = 0;
            countPage = (int)Math.Ceiling((double)pageDT.Rows.Count / 9);
            nextPage();
        }

        /// <summary>
        /// 清空ItemBox
        /// </summary>
        void clearItemBox()
        {
            currentlyPage = 0;
            countPage = 0;
            pageCountLabel.Text = "";
            itemBox1.Visible = false;
            itemBox2.Visible = false;
            itemBox3.Visible = false;
            itemBox4.Visible = false;
            itemBox5.Visible = false;
            itemBox6.Visible = false;
            itemBox7.Visible = false;
            itemBox8.Visible = false;
            itemBox9.Visible = false;
        }

        /// <summary>
        /// 刷新当前页
        /// </summary>
        void refreshCurrentlyPage()
        {
            pageCountLabel.Text = currentlyPage + "，共" + countPage + "页";
            //从(页面*数量)得到当前页面可以得到的最大下标
            int forNume = 9 * currentlyPage;


            int minIndex = 9 * currentlyPage - 9;
            int itemBoxIndex = 0;
            for(int i = 1; i <= 9 ; i++)
            {
                if (minIndex >= pageDT.Rows.Count)  //0   1
                    break;     
                switch (i)
                {
                    case 1:
                        setItemBox(itemBox1, pageDT.Rows[minIndex]);
                        break;
                    case 2:
                        setItemBox(itemBox2, pageDT.Rows[minIndex]);
                        break;
                    case 3:
                        setItemBox(itemBox3, pageDT.Rows[minIndex]);
                        break;
                    case 4:
                        setItemBox(itemBox4, pageDT.Rows[minIndex]);
                        break;
                    case 5:
                        setItemBox(itemBox5, pageDT.Rows[minIndex]);
                        break;
                    case 6:
                        setItemBox(itemBox6, pageDT.Rows[minIndex]);
                        break;
                    case 7:
                        setItemBox(itemBox7, pageDT.Rows[minIndex]);
                        break;
                    case 8:
                        setItemBox(itemBox8, pageDT.Rows[minIndex]);
                        break;
                    case 9:
                        setItemBox(itemBox9, pageDT.Rows[minIndex]);
                        break;
                }
                minIndex++;
                itemBoxIndex++;
            }

            //  6
            for(int i = 9; i > itemBoxIndex; i--)
            {
                switch (i)
                {
                    case 1:
                        itemBox1.Visible = false;
                        break;
                    case 2:
                        itemBox2.Visible = false;
                        break;
                    case 3:
                        itemBox3.Visible = false;
                        break;
                    case 4:
                        itemBox4.Visible = false;
                        break;
                    case 5:
                        itemBox5.Visible = false;
                        break;
                    case 6:
                        itemBox6.Visible = false;
                        break;
                    case 7:
                        itemBox7.Visible = false;
                        break;
                    case 8:
                        itemBox8.Visible = false;
                        break;
                    case 9:
                        itemBox9.Visible = false;
                        break;
                }
            }
            ////最大下标减去(数量)得到最小下标
            ////从最小下标 到 最大下标
            //for (int i = 9 * currentlyPage - 9; i < forNume; i++)
            //{
            //    //如果当前下标(比数量小1)，小于总数-1，则已经到了尽头。
            //    if (i > pageDT.Rows.Count - 1)
            //        break;

            //    if (!itemBox1.Visible)
            //    {
            //        setItemBox(itemBox1, pageDT.Rows[i]);
            //    }
            //    else if (!itemBox2.Visible){
            //        setItemBox(itemBox2, pageDT.Rows[i]);
            //    }
            //    else if (!itemBox3.Visible)
            //    {
            //        setItemBox(itemBox3, pageDT.Rows[i]);
            //    }
            //    else if (!itemBox4.Visible)
            //    {
            //        setItemBox(itemBox4, pageDT.Rows[i]);
            //    }
            //    else if (!itemBox5.Visible)
            //    {
            //        setItemBox(itemBox5, pageDT.Rows[i]);
            //    }
            //    else if (!itemBox6.Visible)
            //    {
            //        setItemBox(itemBox6, pageDT.Rows[i]);
            //    }
            //    else if (!itemBox7.Visible)
            //    {
            //        setItemBox(itemBox7, pageDT.Rows[i]);
            //    }
            //    else if (!itemBox8.Visible)
            //    {
            //        setItemBox(itemBox8, pageDT.Rows[i]);
            //    }
            //    else if (!itemBox9.Visible)
            //    {
            //        setItemBox(itemBox9, pageDT.Rows[i]);
            //    }
            //}

        }

        /// <summary>
        /// 设置ItemBox的信息
        /// </summary>
        /// <param name="ib"></param>
        /// <param name="row"></param>
        bool setItemBox(ItemBox ib, DataRow row)
        {
            
            if (isItemMode(nowSeMode))
            {
                Image icon = myZiku.IconOrFile(myZiku.exPand(row["icon"].ToString(),ZIKU.DataBase.Config.Instance.Path), myZiku.exPand(row["value"].ToString(), ZIKU.DataBase.Config.Instance.Path), row["id"].ToString());
                ib.setItem(row["name"].ToString(), row["intro"].ToString(), icon);
            }
            else if (nowSeMode is CategoryMode)
            {
                ib.setItem(row["name"].ToString(), "", noIcon);
            }
            else if (nowSeMode is XiaoChaoMode)
            {
                ib.setItem(row["name"].ToString(), row["introduce"].ToString(), noIcon);
            }
            ib.Tag = row["id"].ToString();
            ib.Visible = true;
            return true;
        }


        /// <summary>
        /// 设置下一页
        /// </summary>
        bool nextPage()
        {
            if (currentlyPage >= countPage) return false;
            currentlyPage++;
            refreshCurrentlyPage();
            return true;
        }
        /// <summary>
        /// 设置上一页
        /// </summary>
        bool lastPage()
        {
            if (currentlyPage <= 1) return false;
            currentlyPage--;
            refreshCurrentlyPage();
            return true;
        }




        //----------当个ItemBox行为

        /// <summary>
        /// 进入ItemBox  //切换
        /// </summary>
        private void itemBox_Enter(object sender, EventArgs e)
        {
            ItemBox ib = sender as ItemBox;
            nowSelectItemBox = ib;
            if (ib.Tag != null)
            {
                if (isItemMode(nowSeMode))
                {
                    if (ib.Tag != null)
                        SetItemIntroduce(ib.Tag.ToString());
                }else if (nowSeMode is XiaoChaoMode)
                {
                    ZIKU.DataBase.XiaoChao xc = ZIKU.DataBase.XiaoChao.getInstance(ib.Tag.ToString());
                    if (xc != null)
                    {
                        title_Label.Text = xc.name;
                        ItemIntroduce.Text = xc.introduce;
                    }
                }
            }
        }

        //离开ItemBox
        private void itemBox_Leave(object sender, EventArgs e)
        {
            nowSelectItemBox = null;
        }

        /// <summary>
        /// 按下按键(不包括 UP DOWN RIGHT LEFT  需要在窗口行为中重写的系统键行为中处理)
        /// </summary>
        private void itemBox_KeyDown(object sender, KeyEventArgs e)
        {
            ItemBox ib = sender as ItemBox;
            switch (e.KeyCode)
            {
                case Keys.Enter:                   
                    ib.Execute(); 
                    break;         
                case Keys.Alt:
                case Keys.Menu:
                    break;
                case Keys.Apps:
                    break;
                case Keys.Space:
                    #region 空格
                    if (isItemMode(nowSeMode))
                    {
                       // this.done = false;
                        Hide();
                        Item.Item.Edit(ib.Tag.ToString());
                        setDone();
                    }
                    else if(nowSeMode is XiaoChaoMode)
                    {
                      //  this.done = false;
                        Hide();
                        Item.XiaoChao.editXC(ib.Tag.ToString());
                        setDone();
                    }          
                    break;
                #endregion
                default:
                    SeBox.Focus();
                    break;
            }
        }


        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="obj"></param>
        private void itemBox_ExecuteEvent(object obj)
        {
            ItemBox ib = obj as ItemBox;
            nowSeMode.Execute(ib.Tag.ToString()); 
        }



        #region 拖放文件到ItemBox
        private void itemBox_DragFileDrop(object obj, string[] DragFileList)
        {
            ItemBox ib = obj as ItemBox;

            DragFilesList = DragFileList;
            if (DragFileList.Length > 0)
            {
                item_SeForm = ZIKU.DataBase.Item.getInstance(ib.Tag.ToString());
                if (item_SeForm != null)
                {
                    SetItemIntroduce(ib.Tag.ToString());
                    ToolStripMenuItem itemName_Menu = new ToolStripMenuItem("项目的名称");
                    ToolStripMenuItem copyFiles_Menu = new ToolStripMenuItem("打开“项目资料目录”");
                    ToolStripMenuItem moveFiles_Menu = new ToolStripMenuItem("打开“项目资料目录”");
                    copyFiles_Menu.Click += CopyFiles_Menu_Click;
                    moveFiles_Menu.Click += MoveFiles_Menu_Click;
                    ContextMenuStrip cm = new ContextMenuStrip();
                    itemName_Menu.Enabled = false;
                    itemName_Menu.Text = item_SeForm.name;
                    cm.Items.Add(itemName_Menu);
                    cm.Items.Add("-");
                    cm.Items.Add(copyFiles_Menu);
                    cm.Items.Add(moveFiles_Menu);
                    if (item_SeForm.iPathExpand != "")
                    {
                        if (Tools.checkFolderCreation(item_SeForm.iPathExpand))
                        {
                            copyFiles_Menu.Enabled = true;
                            copyFiles_Menu.Text = "复制所有文件到“项目资料目录”";
                            moveFiles_Menu.Enabled = true;
                            moveFiles_Menu.Text = "移动所有文件到“项目资料目录”";
                        }
                        else
                        {
                            copyFiles_Menu.Enabled = false;
                            copyFiles_Menu.Text = "自定义“项目资料目录”无效";
                            moveFiles_Menu.Visible = false;
                        }
                    }
                    else
                    {
                        if (Tools.checkFolderCreation(ZIKU.DataBase.Config.Instance.dataFolderExpand))
                        {
                            copyFiles_Menu.Enabled = true;
                            copyFiles_Menu.Text = "复制所有文件到“项目资料目录”";
                            moveFiles_Menu.Enabled = true;
                            moveFiles_Menu.Text = "移动所有文件到“项目资料目录”";
                        }
                        else
                        {
                            copyFiles_Menu.Enabled = false;
                            copyFiles_Menu.Text = "“项目资料总目录”无效，请检查数据库设置";
                            moveFiles_Menu.Visible = false;
                        }
                    }
                    cm.Show(MousePosition);
                }
            }

        }

        /// <summary>
        /// 成功拖拽后记录的文件列表
        /// </summary>
        private string[] DragFilesList;
        private void MoveFiles_Menu_Click(object sender, EventArgs e)
        {
            if (DragFilesList == null) return;
            string ero = "";
            if (item_SeForm.iPathExpand != "")
            {
                if (Tools.checkFolderCreation(item_SeForm.iPathExpand))
                    FileOperateProxy.MoveFiles(DragFilesList, item_SeForm.iPathExpand, true, true, false, ref ero);
            }
            else
            {
                if (Tools.checkFolderCreation(ZIKU.DataBase.Config.Instance.dataFolderExpand)) {
                    System.IO.Directory.CreateDirectory(ZIKU.DataBase.Config.Instance.dataFolderExpand + @"\" + item_SeForm.dataFolderName);
                    FileOperateProxy.MoveFiles(DragFilesList, ZIKU.DataBase.Config.Instance.dataFolderExpand + @"\" + item_SeForm.dataFolderName, true, true, false, ref ero);
                }
            }
        }
        private void CopyFiles_Menu_Click(object sender, EventArgs e)
        {
            if (DragFilesList == null) return;
            string ero = "";
            if (item_SeForm.iPathExpand != "")
            {
                if (Tools.checkFolderCreation(item_SeForm.iPathExpand))                     
                    FileOperateProxy.CopyFiles(DragFilesList, item_SeForm.iPathExpand, true, true, false, ref ero);                
            }
            else
            {
                if (Tools.checkFolderCreation(ZIKU.DataBase.Config.Instance.dataFolderExpand))
                {
                    System.IO.Directory.CreateDirectory( ZIKU.DataBase.Config.Instance.dataFolderExpand + @"\" + item_SeForm.dataFolderName);
                    FileOperateProxy.CopyFiles(DragFilesList,  ZIKU.DataBase.Config.Instance.dataFolderExpand + @"\" + item_SeForm.dataFolderName, true, true, false, ref ero);
                }
            }
        }
        #endregion

        /// <summary>
        /// 鼠标点击
        /// </summary>
        private void itemBox_MouseClick(object sender, MouseEventArgs e)
        {
          if(e.Button == MouseButtons.Left)
            {
                ItemBox ib = sender as ItemBox;
                nowSeMode.Execute(ib.Tag.ToString());
            }
        }

        void setItemBoxContextMneuStrip(ContextMenuStrip cms)
        {
            itemBox1.ContextMenuStrip = cms;
            itemBox2.ContextMenuStrip = cms;
            itemBox3.ContextMenuStrip = cms;
            itemBox4.ContextMenuStrip = cms;
            itemBox5.ContextMenuStrip = cms;
            itemBox6.ContextMenuStrip = cms;
            itemBox7.ContextMenuStrip = cms;
            itemBox8.ContextMenuStrip = cms;
            itemBox9.ContextMenuStrip = cms;
        }
        #endregion

        #region 搜索模式类
        /// <summary>
        /// 当前的搜索模式
        /// </summary>
        private SearchMode nowSeMode = ItemNameMode.Instance;
        abstract class SearchMode
        {
            //这些都是需要初始化的
            public string[] needColumn = new string[] { "id", "name", "intro", "value", "icon"};
            /// <summary>
            /// 搜索模式的开头关键字
            /// </summary>
            public string ModeSearchKey = "";
            public string Intro = "搜索项目名称";
            public readonly string Type;

            protected SearchMode(string t)
            {
                Type = t;
            }

            /// <summary>
            /// 获取搜索字符串
            /// </summary>
            /// <param name="seKey"></param>
            /// <returns></returns>
            public abstract List<string> getSearchSQL(string seKey);

            /// <summary>
            /// 执行命令
            /// </summary>
            public abstract void Execute(string id);
        }

        void setSearchMode(SearchMode sm)
        {
            nowSeMode = sm;
            title_Label.Text = sm.Intro;

            if (isItemMode(nowSeMode))
            {
                setItemBoxContextMneuStrip(searchItemMenu);
            }
            else if (nowSeMode is XiaoChaoMode)
            {
                setItemBoxContextMneuStrip(searchXiaoChaoMenu);
            }
            else
            {
                setItemBoxContextMneuStrip(null);
            }
        }
        /// <summary>
        /// 获取模糊搜索的字符串 %
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string getFuzzy(string str)
        {
            str = str.Replace(" ", "");
            StringBuilder fuzzySeKBey = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (i != str.Length)
                    fuzzySeKBey.Append(str.Substring(i, 1) + "%");
            }
            return fuzzySeKBey.ToString();
        }

        /// <summary>
        /// 项目的父类
        /// </summary>
        abstract class ItemMode : SearchMode
        {
            public ItemMode(string t) : base(t)
            {
            }
            public override void Execute(string id)
            {
                SearchFormOle.Instance.setDone();
                myZiku.run(ZIKU.DataBase.Item.getInstance(id));
            }
        }
        /// <summary>
        /// 判断模式类是不是项目的子类
        /// </summary>
        /// <param name="im"></param>
        /// <returns></returns>
        bool isItemMode(SearchMode im)
        {
            if (typeof(ItemMode).IsAssignableFrom(im.GetType()))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 项目名称模式
        /// </summary>
        class ItemNameMode : ItemMode
        {
            private static ItemNameMode _instance = new ItemNameMode("项目名称");
            public static ItemNameMode Instance { get { return _instance; } }

            protected ItemNameMode(string s) :base(s)
            {
            }

            public override List<string> getSearchSQL(string seKey)
            {
                List<string> sql = new List<string>();
                if (seKey == "") return sql;
                seKey = seKey.Replace("'", "''");

                // 第一次搜索             
                sql.Add("SELECT * FROM Item WHERE searchAlias LIKE '" + seKey.Replace("'", "''") + "%' AND hideSearch = 'FALSE';");
                sql.Add("SELECT * FROM Item WHERE searchAlias LIKE '%" + seKey.Replace("'", "''") + "%' AND hideSearch = 'FALSE';");
                sql.Add("SELECT * FROM Item WHERE name LIKE '" + seKey.Replace("'", "''") + "%' AND hideSearch = 'FALSE';");
                sql.Add("SELECT * FROM Item WHERE nameF LIKE '" + seKey.Replace("'", "''") + "%' AND hideSearch = 'FALSE';");

                // 模糊搜索
                string fuzzySearch = getFuzzy(seKey);

                sql.Add("SELECT * FROM Item WHERE name LIKE '%" + fuzzySearch.Replace("'", "''") + "' AND hideSearch = 'FALSE';");
                sql.Add("SELECT * FROM Item WHERE nameF LIKE '%" + fuzzySearch.Replace("'", "''") + "' AND hideSearch = 'FALSE';");
                return sql;
            }
        }


        //--------------------------------------
        class XiaoChaoMode : SearchMode
        {
            private static XiaoChaoMode _instance = new XiaoChaoMode();
            public static XiaoChaoMode Instance { get { return _instance; } }

            private XiaoChaoMode():base("小抄名称")
            {
                needColumn = new string[] { "id", "name", "introduce" };
                ModeSearchKey = "X";
                Intro = "搜索小抄";
            }

            public override List<string> getSearchSQL(string seKey)
            {
                List<string> sql = new List<string>();
                if (seKey == "") return sql;
                seKey = seKey.Replace("'", "''");
                sql.Add("SELECT * FROM XiaoChao WHERE name LIKE '" + seKey + "%';");
                sql.Add("SELECT * FROM XiaoChao WHERE nameF LIKE '" + seKey + "%';");

                string fuzzySearch = getFuzzy(seKey);
                sql.Add("SELECT * FROM XiaoChao WHERE name LIKE '%" + fuzzySearch.Replace("'", "''") + "';");
                sql.Add("SELECT * FROM XiaoChao WHERE nameF LIKE '%" + fuzzySearch.Replace("'", "''") + "';");
                return sql;
            }

            public override void Execute(string id)
            {
                SearchFormOle.Instance.setDone();
                myZiku.run(ZIKU.DataBase.XiaoChao.getInstance(id));
            }
        }
      
        //----------------------
        class ItemIntroMode : ItemNameMode
        {
            private static ItemIntroMode _Instance = new ItemIntroMode();
           new public static ItemIntroMode Instance
            {
                get
                {
                    return _Instance;
                }
            }
           private ItemIntroMode() :base("项目介绍")
            {
                ModeSearchKey = "J";
                Intro = "搜索项目介绍";
            }


            public override List<string> getSearchSQL(string seKey)
            {
                List<string> sql = new List<string>();
                if (seKey.Replace(" ","") == "") return sql;
           
                string[] keyArray = seKey.Replace("'", "''").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder introSeKey = new StringBuilder();
                StringBuilder introduceSeKey = new StringBuilder();

                introSeKey.Append("intro LIKE '%" + keyArray[0] + "%'");
                introduceSeKey.Append("introduce LIKE '%" + keyArray[0] + "%'");

                for (int i = 1;i< keyArray.Length;i++)
                {
                    introSeKey.Append(" AND intro LIKE '%" + keyArray[i] + "%'");
                    introduceSeKey.Append(" AND introduce LIKE '%" + keyArray[i] + "%'");
                }

                sql.Add("SELECT * FROM item WHERE " + introSeKey.ToString() + ";");
                sql.Add("SELECT * FROM item WHERE " + introduceSeKey.ToString() + ";");

                return sql;
            }
        }

    

        //---------------------
        class CategoryMode : SearchMode
        {
            private static  CategoryMode _Instance = new CategoryMode();
            public static CategoryMode Instance { get { return _Instance; } }

            private CategoryMode():base("搜索分类")
            {
                needColumn = new string[] { "id", "name" };
                ModeSearchKey = "F";
                Intro = "搜索分类";
            }
            public override List<string> getSearchSQL(string seKey)
            {
                List<string> sql = new List<string>();            
                seKey = seKey.Replace("'", "''");
                sql.Add("SELECT * FROM Category WHERE name LIKE '" + seKey + "%';");
                sql.Add("SELECT * FROM Category WHERE name LIKE '_%" + seKey + "%';");
                sql.Add("SELECT * FROM Category WHERE nameF LIKE '" + seKey + "%';");
                sql.Add("SELECT * FROM Category WHERE nameF LIKE '_%" + seKey + "%';");
                return sql;
            }

            public override void Execute(string id)
            {
                SearchFormOle.Instance.nowSeMode = ItemNameMode.Instance;
                ZIKU.DataBase.Category category = ZIKU.DataBase.Category.getInstance(id);
                List<string> sql = new List<string>();
                foreach (string itemID in category.I_ID.Split(new char[] { Convert.ToChar(";") }, StringSplitOptions.RemoveEmptyEntries))
                {
                    sql.Add("SELECT * FROM Item WHERE id = " + itemID);         
                }
                SearchFormOle.Instance.RestItemBox(SQLite.ExecuteDataTable(sql, ZIKU.DataBase.Config.Instance.Path));            
            }
        }


        //--------------------------
        class AllItemMode : ItemNameMode
        {
            private static AllItemMode _instance = new AllItemMode();
           new  public static AllItemMode Instance
            {
                get { return _instance; }
            }
            private AllItemMode() : base("所有项目")
            {
                ModeSearchKey = "S";
                Intro = "搜索所有项目";
            }

            public override List<string> getSearchSQL(string seKey)
            {
                List<string> sql = new List<string>();
                if (seKey == "") return sql;
                seKey = seKey.Replace("'", "''");

                // 第一次搜索             
                sql.Add("SELECT * FROM Item WHERE searchAlias LIKE '" + seKey.Replace("'", "''") + "%';");
                sql.Add("SELECT * FROM Item WHERE searchAlias LIKE '%" + seKey.Replace("'", "''") + "%';");
                sql.Add("SELECT * FROM Item WHERE name LIKE '" + seKey.Replace("'", "''") + "%';");
                sql.Add("SELECT * FROM Item WHERE nameF LIKE '" + seKey.Replace("'", "''") + "%';");

                // 模糊搜索
                string fuzzySearch = getFuzzy(seKey);

                sql.Add("SELECT * FROM Item WHERE name LIKE '%" + fuzzySearch.Replace("'", "''") + "';");
                sql.Add("SELECT * FROM Item WHERE nameF LIKE '%" + fuzzySearch.Replace("'", "''") + "';");
                return sql;
            }
        }
        #endregion


        private void SearchFormOle_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers == Keys.Alt) && altMode.Checked)//当前按下了 ALT 和 当前是 ALT 模式
            {//通过ALT+数字键激活项目
                bool eHandled = true;
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        if (itemBox1.Visible)
                            itemBox1.Execute();
                        break;
                    case Keys.D2:
                        if (itemBox2.Visible)
                            itemBox2.Execute();
                        break;
                    case Keys.D3:
                        if (itemBox3.Visible)
                            itemBox3.Execute();
                        break;
                    case Keys.D4:
                        if (itemBox4.Visible)
                            itemBox4.Execute();
                        break;
                    case Keys.D5:
                        if (itemBox5.Visible)
                            itemBox5.Execute();
                        break;
                    case Keys.D6:
                        if (itemBox6.Visible)
                            itemBox6.Execute();
                        break;
                    case Keys.D7:
                        if (itemBox7.Visible)
                            itemBox7.Execute();
                        break;
                    case Keys.D8:
                        if (itemBox8.Visible)
                            itemBox8.Execute();
                        break;
                    case Keys.D9:
                        if (itemBox9.Visible)
                            itemBox9.Execute();
                        break;
                    case Keys.OemMinus:
                        lastPage();
                        break;
                    case Keys.Oemplus:
                        nextPage();
                        break;
                    default:
                        eHandled = false;
                        break;
                }
                e.Handled = eHandled;
            }
        }

        private void altMode_CheckedChanged(object sender, EventArgs e)
        {
            if (altMode.Checked)
                SQLite.ExecuteNonQuery("UPDATE Config SET searchMode = 'altMode' WHERE main='main';", Program.zikuSettingPath);
            else
                SQLite.ExecuteNonQuery("UPDATE Config SET searchMode = 'imeMode' WHERE main='main';", Program.zikuSettingPath);
        }

        private void NextPateButton_Enter(object sender, EventArgs e)
        {
            SeBox.Focus();
        }
    }
}



