using System;
using System.Data;
using System.Windows.Forms;
using OLEREO.Library;
using System.Collections;

namespace ZIKU.Control.Item
{
    public partial class Manage : Form
    {
        /// <summary>
        /// 项目的实例，null则管理项目。！！不要在这里面手动修改！！！
        /// </summary>
        private ZIKU.DataBase.Item manageItem = null;
        private string CI_IDbuff = "";
        /// <summary>
        /// 项目管理
        /// </summary>
        /// <param name="itemID">窗口管理关联项目的项目ID，null则是关联所有的项目</param>
        private Manage(string itemID)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ICON;
            manageItem = ZIKU.DataBase.Item.getInstance(itemID);
            if(manageItem != null)
            {
                CI_IDbuff = manageItem.CI_ID;
                refSelList(CI_IDbuff);
            }
            addItemsToList(SQLite.ExecuteDataTable("SELECT * FROM Item", ZIKU.DataBase.Config.Instance.Path));
            itemList.ContextMenuStrip = new ManageItemMenu(this);          
        }

 
        /// <summary>
        /// 打开管理关联项目窗口
        /// </summary>
        /// <param name="itemID"></param>
        public static void ManageConnectItems(string itemID)
        {
            Manage manage = new Manage(itemID);
            //将“勾选”列头显示出来
            manage.itemList.Columns[0].Width = 50;
            manage.ShowDialog();  
        }

        /// <summary>
        /// 打开管理所有项目窗口
        /// </summary>
        public static void ManageItems()
        {
            Manage manage = new Manage(null);
            manage.Width = 425;
            manage.okButton.Text = "关闭";
            manage.iCategory.Height = 310;
            manage.cancelButton.Visible = false;
            manage.selectItemList.Visible = false;
            manage.ShowDialog();
        }


        ArrayList itemIDlist = new ArrayList();
        /// <summary>
        /// 增加数据表中的项目信息到列表中
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="clearItems">是否清除现有</param>
        private void addItemsToList(DataTable dt, bool clearItems = true)
        {
            if (clearItems)
            {
                itemList.Items.Clear();               
                itemIDlist.Clear();
            }

            foreach (DataRow item in dt.Rows)
            {
                if(itemIDlist.IndexOf(item["id"].ToString()) == -1)
                {
                    itemIDlist.Add(item["id"].ToString());
                    ListViewItem li = new ListViewItem();
                    if (manageItem == null)
                    {
                        li.Tag = item["id"].ToString();
                        li.Text = "x";
                        li.SubItems.Add(item["UID"].ToString());
                        li.SubItems.Add(item["name"].ToString());
                        itemList.Items.Add(li);
                    }
                    else
                    {
                        if (item["id"].ToString() != manageItem.id)
                        {
                            li.Text = "";
                            li.Tag = item["id"].ToString();
                            if (Tools.AddValue(CI_IDbuff, item["id"].ToString()) == null)                            
                                li.Text = "√";
                            li.SubItems.Add(item["UID"].ToString());
                            li.SubItems.Add(item["name"].ToString());
                            itemList.Items.Add(li);
                        }
                    }
                }               
            }
        }

        private void refSelList(string selIDlist)
        {
            selectItemList.Items.Clear();
            foreach (string selID in  selIDlist.Split(new char[] {';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM Item WHERE id =" + selID,ZIKU.DataBase.Config.Instance.Path);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];              
                    ListViewItem selList = new ListViewItem();
                    selList.Tag = row["id"].ToString();
                    selList.Text = row["UID"].ToString();
                    selList.SubItems.Add(row["name"].ToString());
                    selectItemList.Items.Add(selList);
                }
            }
        }


        //点击项目列表，勾选或取消关联的项目
        private void itemList_SelectedIndexChanged(object sender, EventArgs e){}
        private void itemList_MouseClick(object sender, MouseEventArgs e)
        {
            setInfo(itemList.SelectedItems[0].Tag.ToString());
            if ((itemList.SelectedItems.Count != 0) && (e.Button == MouseButtons.Left) && selectItemList.Visible)
            {
                if(itemList.SelectedItems[0].SubItems[0].Text == "")//将没勾选的项目添加
                {
                    itemList.SelectedItems[0].SubItems[0].Text = "√";
                    ListViewItem selList = new ListViewItem();
                    selList.Tag = itemList.SelectedItems[0].Tag.ToString();
                    selList.Text = itemList.SelectedItems[0].SubItems[1].Text;
                    selList.SubItems.Add(itemList.SelectedItems[0].SubItems[2].Text);
                    selectItemList.Items.Add(selList);
                    CI_IDbuff = Tools.AddValue(CI_IDbuff, itemList.SelectedItems[0].Tag.ToString());
                }
                else
                {//取消已经勾选的项目
                    itemList.SelectedItems[0].SubItems[0].Text = "";
                    foreach (ListViewItem seList in selectItemList.Items)
                    {
                        if(seList.Tag.ToString() == itemList.SelectedItems[0].Tag.ToString())
                        {
                            selectItemList.Items.Remove(seList);
                            CI_IDbuff = Tools.RemoveValue(CI_IDbuff, itemList.SelectedItems[0].Tag.ToString());
                            return;
                        }
                    }
                }
            }
        }
        private void itemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             ZIKU.DataBase.Item item =  ZIKU.DataBase.Item.getInstance(itemList.SelectedItems[0].Tag.ToString());
            myZiku.run(item);
        }
        /// <summary>
        /// 设置界面的项目信息
        /// </summary>
        /// <param name="itemID">项目的ID</param>
        private void setInfo(string itemID)
        {
            if(itemID != null)
            {
                ZIKU.DataBase.Item item =  ZIKU.DataBase.Item.getInstance(itemID);
                if (item != null)
                {
                    introduceBox.Text = item.intro + "\r\n\r\n" +item.introduce;
                    iCategory.Text = "";
                    foreach (string cID in item.C_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                         ZIKU.DataBase.Category category =  ZIKU.DataBase.Category.getInstance(cID);
                        if (category != null)
                            iCategory.Text += category.name + "\r\n";
                    }
                }
            }
            else
            {
                introduceBox.Text = "";
                iCategory.Text = "";
            }
           
        }     

        /// <summary>
        /// 确定按钮
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            if(manageItem != null)
            {
                string connectID = "";
                foreach (ListViewItem item in selectItemList.Items)
                {
                    connectID += item.Text + ";";
                }

                 ZIKU.DataBase.Item.updateCI_ID(manageItem.id, manageItem.CI_ID, connectID);     
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cancelSelectMenuItem_Click(object sender, EventArgs e)
        {           
            foreach(ListViewItem item in itemList.Items)
            {
                if(item.Tag.ToString() == selectItemList.SelectedItems[0].Tag.ToString())
                {
                    item.Text = "";
                    CI_IDbuff = Tools.RemoveValue(CI_IDbuff, selectItemList.SelectedItems[0].Tag.ToString());
                    selectItemList.Items.Remove(selectItemList.SelectedItems[0]);                   
                    return;
                }
            }           
        }
        private void selectItemList_MouseClick(object sender, MouseEventArgs e)
        {
            setInfo(selectItemList.SelectedItems[0].SubItems[0].Text);
            if (e.Button == MouseButtons.Right)
            {
                selectItemMenuStrip.Show(MousePosition);
            }
        }

        #region  项目右键菜单
        class ManageItemMenu : zMenu.ItemMenu
        {
            private Manage manage;
            public  ManageItemMenu(Manage man)
            {
                manage = man;
            }

            public override void addNewItem_after() { }
            public override void addNewItem_before() { }
            public override void addNewItem_succeed(string newID) { }
            public override void connectItem_after() { }
            public override void connectItem_before() { }
            public override void editItem_after(string itemID) { }
            public override void editItem_before() { }
            public override bool removeFromThisCategory_before() { return false; }
            public override void removeFromThisCategory_succeed() { }
            public override void editeItem_succeed(string itemID)
            {
                 ZIKU.DataBase.Item item =  ZIKU.DataBase.Item.getInstance(itemID);
                if(item!= null)
                {
                    manage.itemList.SelectedItems[0].SubItems[2].Text = item.name;
                    manage.setInfo(itemID);
                }
            }         

            public override void Menu_opening(out string itemID, out string categoryID, out bool visibleAddNew, out bool visibleTotalRemoveItem,out bool visibleConnectItem)
            {
                itemID = null;
                categoryID = null;
                visibleAddNew = false;
                visibleTotalRemoveItem = false;
                visibleConnectItem = false;
                if (manage.itemList.SelectedItems.Count != 0)
                {
                    itemID = manage.itemList.SelectedItems[0].Tag.ToString();
                    visibleTotalRemoveItem = true;
                }
            }

            public override void totalRemoveItem_succeed()
            {
                string itemID = manage.itemList.SelectedItems[0].Tag.ToString();
                manage.itemList.Items.Remove(manage.itemList.SelectedItems[0]);
                manage.introduceBox.Text = "";
                manage.iCategory.Text = "";

                foreach (ListViewItem seList in manage.selectItemList.Items)
                {
                    if (seList.Tag.ToString() == itemID)
                    {
                        manage.selectItemList.Items.Remove(seList);
                        break;
                    }
                }
            }

            public override bool totalRemoveItem_before(string itemID)
            {
                 ZIKU.DataBase.Item item =  ZIKU.DataBase.Item.getInstance(itemID);
                if (MessageBox.Show("确定彻底移除：“" + item.name + "”？\r\n\r\n注意，这会移除所有关于该项目的信息！\r\n不会删除任何实际的文件", "彻底移除项目", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    return true;
                else
                    return false;
            }

            public override void manageXiaoChao_before()
            {
               
            }

            public override void AddXiaoChao_after(string xcID)
            {
              //
            }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            addItemsToList(SQLite.ExecuteDataTable("SELECT * FROM Item",  ZIKU.DataBase.Config.Instance.Path));
        }

        private void seBox_TextChanged(object sender, EventArgs e)
        {
            setInfo(null);
            if (seBox.Text.Replace(" ", "") == "")
            {
                addItemsToList(SQLite.ExecuteDataTable("SELECT * FROM Item",  ZIKU.DataBase.Config.Instance.Path));
            }
            else
            {
                string mh = "%";
                for (int i = 0; i < seBox.Text.Length; i++)
                {
                    mh += seBox.Text.Substring(i, 1) + "%";
                }
                addItemsToList(SQLite.ExecuteDataTable("SELECT * FROM Item WHERE nameF LIKE '" + (seBox.Text + "%").ToLower().Replace("'", "''") + "'",  ZIKU.DataBase.Config.Instance.Path));              
                addItemsToList(SQLite.ExecuteDataTable("SELECT * FROM Item WHERE nameF LIKE '" + mh.Replace("'", "''") + "'",  ZIKU.DataBase.Config.Instance.Path),false);
                addItemsToList(SQLite.ExecuteDataTable("SELECT * FROM Item WHERE name LIKE '" + (seBox.Text + "%").ToLower().Replace("'", "''") + "'",  ZIKU.DataBase.Config.Instance.Path), false);
                addItemsToList(SQLite.ExecuteDataTable("SELECT * FROM Item WHERE name LIKE '" + mh.Replace("'", "''") + "'",  ZIKU.DataBase.Config.Instance.Path),false);
            }
        }

     
    }
}
