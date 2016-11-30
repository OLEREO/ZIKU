using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ZIKU.Control.DataBase
{
    public partial class Manage : Form
    {
        private Manage()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ICON;
            refreshList();
        }
        public static void show()
        {
            Manage manage = new Manage();
            manage.ShowDialog();
        }
     
        private void refreshList()
        {
            DBListView.Items.Clear();
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM DB", Program.zikuSettingPath);
            foreach(DataRow row in dt.Rows)
            {
                ListViewItem li = new ListViewItem();
                li.Tag = row["id"].ToString();
                if (row["id"].ToString() == SettingDataBase.Config.Instance.DataBaseID) 
                    li.Text = "●当前使用";
                else if (System.IO.File.Exists(Environment.ExpandEnvironmentVariables(row["path"].ToString())))
                    li.Text = "√";
                else
                    li.Text ="×";
                li.SubItems.Add(row["name"].ToString());
                li.SubItems.Add(row["path"].ToString());
                DBListView.Items.Add(li);
            }
        }

 


        private void ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private void DBListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switchDB_Menu_Click(null, null);
        }
        private void createDB_Menu_Click(object sender, EventArgs e)
        {
            if (SettingDataBase.DB.CreateDB() != 0) refreshList();
        }

        private void inputDB_Menu_Click(object sender, EventArgs e)
        {
            if (SettingDataBase.DB.inputDB()) refreshList();           
        }

        private void editDB_Menu_Click(object sender, EventArgs e)
        {
            if (DBListView.SelectedItems.Count > 0)
            {
                string id = DBListView.SelectedItems[0].Tag.ToString();
                new Edit(id).ShowDialog();
                refreshList();
            }         
        }

        private void switchDB_Menu_Click(object sender, EventArgs e)
        {
            if (DBListView.SelectedItems.Count > 0)
            {
                SettingDataBase.DB db = SettingDataBase.DB.getInstance(DBListView.SelectedItems[0].Tag.ToString());
                if (!System.IO.File.Exists(System.Environment.ExpandEnvironmentVariables(db.path)))
                {
                    DBListView.SelectedItems[0].Text = "×";                   
                    return;
                }

                if (!ZIKU.DataBase.Options.setUseDB(db.id))
                {                    
                    DBListView.SelectedItems[0].Text = "×";
                    MessageBox.Show("该数据库文件有误，无法切换");
                    return;
                }
                SettingDataBase.Config.Instance = null;
                Close();
            }
        }

        private void removeDBInfo_Menu_Click(object sender, EventArgs e)
        {
            SettingDataBase.DB db = SettingDataBase.DB.getInstance(DBListView.SelectedItems[0].Tag.ToString());
            if (MessageBox.Show("确定移除“" + db.name + "”的信息？\r\n\r\n该操作不会删除真实的数据库文件", "移除数据库文件信息", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                SettingDataBase.DB.removeDB(db.id);
                DBListView.Items.Remove(DBListView.SelectedItems[0]);  
            }
        }

        private void menu_Opening(object sender, CancelEventArgs e)
        {
            editDB_Menu.Visible = false;
            switchDB_Menu.Visible = false;
            removeDBInfo_Menu.Visible = false;
            if (DBListView.SelectedItems.Count > 0)
            {
                editDB_Menu.Visible = true;
               
                SettingDataBase.DB db = SettingDataBase.DB.getInstance(DBListView.SelectedItems[0].Tag.ToString());
                if (DBListView.SelectedItems[0].Text == "●当前使用")
                {
                    removeDBInfo_Menu.Visible = false;
                    switchDB_Menu.Visible = false;
                }
                else {
                    removeDBInfo_Menu.Visible = true;
                    if (System.IO.File.Exists(Environment.ExpandEnvironmentVariables(db.path)))
                        switchDB_Menu.Visible = true;
                    else
                    {
                        DBListView.SelectedItems[0].Text = "×";
                        switchDB_Menu.Visible = false;
                    }
                }

            }
        }

        private void DBListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
