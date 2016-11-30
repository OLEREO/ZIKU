using System;
using System.ComponentModel;
using OLEREO.Library;
using System.Windows.Forms;

namespace ZIKU.Control.Category
{
    public partial class Manage : Form
    {
        /// <summary>
        /// 分类管理窗口当前的父分类ID
        /// </summary>
        public string pCid = null;

        private Manage()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ICON;
            Refresh_CategoryList();
        }

        public static void show()
        {
            Manage manage = new Manage();
            manage.ShowDialog();
        }
        /// <summary>
        /// 刷新父分类列表
        /// </summary>
        private void Refresh_CategoryList()
        {
            pCategoryListView.clearItemSaveSort();
            subCategoryListView.clearItemSaveSort();
            subCategoryListView.Enabled = false;
            pCid = null;
            foreach (string Cid in ZIKU.DataBase.Config.Instance.pCsort.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                ZIKU.DataBase.Category category = ZIKU.DataBase.Category.getInstance(Cid);
                if (category != null)
                {
                    ListViewItem li = new ListViewItem();
                    li.Tag = category.id;
                    li.Text = category.name;
                    pCategoryListView.Items.Add(li);
                }
            }
        }

        private void pCategoryListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            subCategoryListView.SaveSort();
            if (pCategoryListView.SelectedItems.Count > 0)
            {
                pCid = pCategoryListView.SelectedItems[0].Tag.ToString();
                ZIKU.DataBase.Category category = ZIKU.DataBase.Category.getInstance(pCid);
                if (category.type != "2")
                {
                    subCategoryListView.Enabled = true;
                    subCategoryListView.clearItemSaveSort();
                    subCategoryListView.BeginUpdate();
                    foreach (string subID in category.C_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        ZIKU.DataBase.Category subCategory = ZIKU.DataBase.Category.getInstance(subID);
                        if (subCategory != null)
                        {
                            ListViewItem li = new ListViewItem();
                            li.Tag = subCategory.id;
                            li.Text = subCategory.name;
                            subCategoryListView.Items.Add(li);
                        }
                    }
                    subCategoryListView.EndUpdate();
                }
            }
            else
            {
                pCid = null;
                subCategoryListView.clearItemSaveSort();
                subCategoryListView.Enabled = false;
            }
        }

        private void CategoryManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            subCategoryListView.SaveSort();
            pCategoryListView.SaveSort();
        }


        private void Pcategory_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (pCategoryListView.SelectedItems.Count > 0)
            {
                Pcategory_Menu_Del.Visible = true;
                Pcategory_Menu_ReName.Visible = true;
                if(pCategoryListView.Items.Count >1)
                switchPtoS_MenuItem.Visible = true;
            }
            else
            {
                Pcategory_Menu_Del.Visible = false;
                Pcategory_Menu_ReName.Visible = false;
                switchPtoS_MenuItem.Visible = false;
            }
        }

        private void Pcategory_Menu_Add_Click(object sender, EventArgs e)
        {
            string re = Tools.InputBox("新建父分类", "请输入分类的名称：", "");
            if (re != null)
            {
                pCategoryListView.SaveSort();
                ListViewItem li = new ListViewItem();
                li.Tag = ZIKU.DataBase.Category.addNewCategory(re, "1").ToString();
                li.Text = re;
                pCategoryListView.Items.Add(li);
            }
        }

        private void Pcategory_Menu_Del_Click(object sender, EventArgs e)
        {
            pCategoryListView.SaveSort();
            if (ZIKU.DataBase.Category.removeCategory(pCategoryListView.SelectedItems[0].Tag.ToString()))
                Refresh_CategoryList();
        }

        private void Pcategory_Menu_ReName_Click(object sender, EventArgs e)
        {
            string re = ZIKU.DataBase.Category.reName(pCategoryListView.SelectedItems[0].Tag.ToString());
            if(re !=null) pCategoryListView.SelectedItems[0].Text = re;         
        }
        private void switchPtoS_MenuItem_Click(object sender, EventArgs e)
        {
            pCategoryListView.SaveSort();
            SwitchPtoS sPtoS = new SwitchPtoS(pCategoryListView.SelectedItems[0].Tag.ToString());
            sPtoS.ShowDialog();
            Refresh_CategoryList();
        }
        private void Scategory_Menu_Opening(object sender, CancelEventArgs e)
        {
            if (subCategoryListView.SelectedItems.Count > 0)
            {
                SubCategory_Menu_Del.Visible = true;
                SubCategory_Menu_ReName.Visible = true;
                SubCategory_Menu_SubToP.Visible = true;
            }
            else
            {
                SubCategory_Menu_Del.Visible = false;
                SubCategory_Menu_ReName.Visible = false;
                SubCategory_Menu_SubToP.Visible = false;
            }
        }
        private void SubCategory_Menu_Add_Click(object sender, EventArgs e)
        {
            string re = Tools.InputBox("新建子分类", "请输入分类的名称：", "");
            if (re != null)
            {
                subCategoryListView.SaveSort();
                ListViewItem li = new ListViewItem();
                li.Tag = ZIKU.DataBase.Category.addNewCategory(re, "2",pCid).ToString();
                li.Text = re;
                subCategoryListView.Items.Add(li);
            }

        }

        private void SubCategory_Menu_Del_Click(object sender, EventArgs e)
        {
            if(ZIKU.DataBase.Category.removeCategory(subCategoryListView.SelectedItems[0].Tag.ToString()))
            //从列表中删除
            subCategoryListView.SelectedItems[0].Remove();
        }

        private void SubCategory_Menu_ReName_Click(object sender, EventArgs e)
        {
            string re = ZIKU.DataBase.Category.reName(subCategoryListView.SelectedItems[0].Tag.ToString());
            if (re == null) return;
            subCategoryListView.SelectedItems[0].Text = re;          
        }

        private void SubCategory_Menu_SubToP_Click(object sender, EventArgs e)
        {
            pCategoryListView.SaveSort();
            if (ZIKU.DataBase.Category.switchStoP(subCategoryListView.SelectedItems[0].Tag.ToString()))
                Refresh_CategoryList();      
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void subCategoryListView_SortChangeEvent(object OListView)
        {
            if (pCid != null)
            {
                string subID = "";
                foreach (ListViewItem li in subCategoryListView.Items)
                {
                    subID += ";" + li.Tag.ToString();
                }
                SQLite.ExecuteNonQuery("UPDATE Category SET C_ID = '" + subID + "' WHERE id = " + pCid, ZIKU.DataBase.Config.Instance.Path);
            }
        }

        private void pCategoryListView_SortChangeEvent(object OListView)
        {
            string pCsort = "";
            foreach (ListViewItem li in pCategoryListView.Items)
            {
                pCsort += ";" + li.Tag.ToString();
            }
            ZIKU.DataBase.Config.updatePCsort(pCsort);
        }
    }
}
