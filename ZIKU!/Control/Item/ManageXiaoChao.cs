using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ZIKU.Control.Item
{
    public partial class ManageXiaoChao : Form
    {
        private string itemID = "";
        public ManageXiaoChao(string itemID)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ICON;
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Item WHERE id =" + itemID, ZIKU.DataBase.Config.Instance.Path);
            if (dt.Rows.Count == 0) MessageBox.Show("发生错误，找不到需要的项目");
            else
                foreach (string xcID in dt.Rows[0]["X_ID"].ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    DataTable dt2 = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM XiaoChao WHERE id = " + xcID,ZIKU.DataBase.Config.Instance.Path);
                    if (dt2.Rows.Count != 0)
                    {
                        ListViewItem li = new ListViewItem();
                        li.Tag = dt2.Rows[0]["id"].ToString();
                        li.Text = dt2.Rows[0]["name"].ToString();
                        oListView1.Items.Add(li);
                    }
                }
            this.itemID = itemID;
        }

        private void addXC_Menu_Click(object sender, EventArgs e)
        {
            string xcID = XiaoChao.addNewXC(itemID);
            if(xcID != null)
            {
                DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM XiaoChao WHERE id = " + xcID, ZIKU.DataBase.Config.Instance.Path);
                ListViewItem li = new ListViewItem();
                li.Tag = xcID;
                li.Text = dt.Rows[0]["name"].ToString();
                oListView1.Items.Add(li);
            }
        }

        private void editXC_Menu_Click(object sender, EventArgs e)
        {
            XiaoChao.editXC(oListView1.SelectedItems[0].Tag.ToString());
        }

        private void delXC_Menu_Click(object sender, EventArgs e)
        {
     
            if (MessageBox.Show("确定删除小抄“" + oListView1.SelectedItems[0].Text + "”？", "删除小抄", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Cancel) return;
            if (ZIKU.DataBase.XiaoChao.delXiaoChao(oListView1.SelectedItems[0].Tag.ToString()))
                oListView1.Items.Remove(oListView1.SelectedItems[0]);
        }

        private void menus_Opening(object sender, CancelEventArgs e)
        {
            if(oListView1.SelectedItems.Count == 0)
            {
                editXC_Menu.Visible = false;
                delXC_Menu.Visible = false;
            }
            else
            {
                editXC_Menu.Visible = true;
                delXC_Menu.Visible = true;
            }
        }
    }
}
