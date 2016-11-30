using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using OLEREO.Library;
using System.Windows.Forms;

namespace ZIKU.Control.Toolkit
{
    public partial class MatchVarValue : Form
    {
        public MatchVarValue()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ICON;
        }


        private Color _itemBackColor = Color.White;  
        private string _itemID = "";

        private Color getItemBackColor(string itemID)
        {
            if (itemID == "")
                return _itemBackColor;
            if (itemID != _itemID)
            {
                if (_itemBackColor == Color.White) _itemBackColor = Color.LightGray;
                else _itemBackColor = Color.White;
            }
            _itemID = itemID;
            return _itemBackColor;
        }

        private void getVarInfo(out ArrayList uid,out ArrayList path,out ArrayList name)
        {
            uid = new ArrayList() ; path = new ArrayList(); name = new ArrayList();
            DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM Variable",ZIKU.DataBase.Config.Instance.Path);
            foreach (DataRow row in dt.Rows)
            {
                uid.Add("%" + row["uid"].ToString() + "%");
                path.Add(myZiku.exPand(row["path"].ToString(),ZIKU.DataBase.Config.Instance.Path));
                name.Add(row["name"].ToString());
            }

            DataTable dtG = SQLite.ExecuteDataTable("SELECT * FROM Variable", Program.zikuSettingPath);
            foreach (DataRow row in dtG.Rows)
            {
                uid.Add("%G-" + row["uid"].ToString() + "%");
                path.Add(myZiku.exPand(row["path"].ToString(), Program.zikuSettingPath));
                name.Add(row["name"].ToString());
            }
        }

        private void match_Button_Click(object sender, EventArgs e)
        {
            replaceCheck_Button.Enabled = false;
            oListView1.Items.Clear();
            ArrayList varUID;
            ArrayList varPath ;
            ArrayList varName;
            getVarInfo(out varUID, out varPath, out varName);
            //DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM Variable",ZIKU.DataBase.Config.Instance.Path);
            //foreach(DataRow row in dt.Rows)
            //{
            //    varUID.Add("%" + row["uid"].ToString() + "%");
            //    varPath.Add(myZiku.exPand(row["path"].ToString(),ZIKU.DataBase.Config.Instance.Path));
            //    varName.Add(row["name"].ToString());
            //}

            //DataTable dtG = SQLite.ExecuteDataTable("SELECT * FROM Variable", Program.zikuSettingPath);
            //foreach (DataRow row in dtG.Rows)
            //{
            //    varUID.Add("%G-" + row["uid"].ToString() + "%");
            //    varPath.Add(myZiku.exPand(row["path"].ToString(), Program.zikuSettingPath));
            //    varName.Add(row["name"].ToString());
            //}


            DataTable itemDT = SQLite.ExecuteDataTable("SELECT * FROM Item",ZIKU.DataBase.Config.Instance.Path);

            _itemID = "";
            int indexVar = -1;
            foreach (DataRow itemRow in itemDT.Rows)
            {
                for (int i = 0; i < varPath.Count; i++)
                {
                    indexVar = itemRow["value"].ToString().ToLower().IndexOf(((string)varPath[i]).ToLower());
                    if (indexVar != -1)
                    {             
                        string var = itemRow["value"].ToString().Remove(indexVar, ((string)varPath[i]).Length);
                        var = var.Insert(indexVar, (string)varUID[i]);

                        ListViewItem li = new ListViewItem();
                        li.BackColor = getItemBackColor(itemRow["id"].ToString());
                        li.Tag = "value";
                        li.Text = itemRow["id"].ToString();
                        li.SubItems.Add(itemRow["name"].ToString());
                        li.SubItems.Add("项目主值");
                        li.SubItems.Add((string)varName[i]);
                        li.SubItems.Add(var);
                        li.SubItems.Add(itemRow["value"].ToString());
                        oListView1.Items.Add(li);
                    }

                    indexVar = itemRow["IV_x86"].ToString().ToLower().IndexOf(((string)varPath[i]).ToLower());
                    if (indexVar != -1)
                    {
                        string var = itemRow["IV_x86"].ToString().Remove(indexVar, ((string)varPath[i]).Length);
                        var = var.Insert(indexVar, (string)varUID[i]);

                        ListViewItem li = new ListViewItem();
                        li.BackColor = getItemBackColor(itemRow["id"].ToString());
                        li.Tag = "IV_x86";
                        li.Text = itemRow["id"].ToString();
                        li.SubItems.Add(itemRow["name"].ToString());
                        li.SubItems.Add("32位主值");
                        li.SubItems.Add((string)varName[i]);
                        li.SubItems.Add(var);
                        li.SubItems.Add(itemRow["IV_x86"].ToString());
                        oListView1.Items.Add(li);
                    }

                    indexVar = itemRow["IV_x64"].ToString().ToLower().IndexOf(((string)varPath[i]).ToLower());
                    if (indexVar != -1)
                    {
                        string var = itemRow["IV_x64"].ToString().Remove(indexVar, ((string)varPath[i]).Length);
                        var = var.Insert(indexVar, (string)varUID[i]);

                        ListViewItem li = new ListViewItem();
                        li.BackColor = getItemBackColor(itemRow["id"].ToString());
                        li.Tag = "IV_x64";
                        li.Text = itemRow["id"].ToString();
                        li.SubItems.Add(itemRow["name"].ToString());
                        li.SubItems.Add("64位主值");
                        li.SubItems.Add((string)varName[i]);
                        li.SubItems.Add(var);
                        li.SubItems.Add(itemRow["IV_x64"].ToString());               
                        oListView1.Items.Add(li);
                    } 
                }
            }

            if (oListView1.Items.Count == 0)
                MessageBox.Show("没有可以替换变量值的项目");
            else
                replaceCheck_Button.Enabled = true;
        }

        private void replaceCheck_Button_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem li in oListView1.Items)
            {
                if (li.Checked)
                {
                    SQLite.ExecuteNonQuery("UPDATE Item SET " + li.Tag.ToString() + " = '" + myZiku.variableToSave(li.SubItems[4].Text,ZIKU.DataBase.Config.Instance.Path).Replace("'","''") + "' WHERE id = " + li.Text,ZIKU.DataBase.Config.Instance.Path);
                }
            }
            match_Button_Click(null, null);
        }

        private void checkAll_Button_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem li in oListView1.Items)
            {
                li.Checked = true;
            }
        }

        private void cancelCheck_Button_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem li in oListView1.Items)
            {
                li.Checked = false;
            }
        }

        private void menus_Opening(object sender, CancelEventArgs e)
        {
            if (oListView1.SelectedItems.Count == 0) editItem_Menu.Enabled = false;editItem_Menu.Enabled = true;
        }

        private void editItem_Menu_Click(object sender, EventArgs e)
        {
            if (oListView1.SelectedItems.Count != 0)
            {
                Item.Item.Edit(oListView1.SelectedItems[0].Text);
                match_Button.PerformClick();           
            }
        }
    }
}
