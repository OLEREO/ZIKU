using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ZIKU.Control.Toolkit
{
    public partial class ReplaceItemValue : Form
    {
        public ReplaceItemValue()
        {
            InitializeComponent();
        }
        Thread searchBack;
        private void search_Box_Click(object sender, EventArgs e)
        {
            oListView1.Items.Clear();
            if (originalValue_Box.Text.Replace(" ", "") == "") return;
            if (searchBack != null) searchBack.Abort();
            searchBack = new Thread(new ParameterizedThreadStart(searchB));
            searchBack.Start(originalValue_Box.Text);
        }

        private void searchB(object original)
        {
            string originalS = ((string)original).ToLower();
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Item",ZIKU.DataBase.Config.Instance.Path);
            foreach (DataRow row in dt.Rows)
            {
                string value = myZiku.variableToShow(row["value"].ToString(),ZIKU.DataBase.Config.Instance.Path);
                if (value.ToLower().IndexOf(originalS) != -1) Invoke(new Action<string, string, string, string>(addItem)
                     , row["id"].ToString(), row["name"].ToString(), "value", value);

                value = myZiku.variableToShow(row["IV_x86"].ToString(),ZIKU.DataBase.Config.Instance.Path);
                if (value.ToLower().IndexOf(originalS) != -1) Invoke(new Action<string, string, string, string>(addItem)
                     , row["id"].ToString(), row["name"].ToString(), "IV_x86", value);

                value = myZiku.variableToShow(row["IV_x64"].ToString(),ZIKU.DataBase.Config.Instance.Path);
                if (value.ToLower().IndexOf(originalS) != -1) Invoke(new Action<string, string, string, string>(addItem)
                     , row["id"].ToString(), row["name"].ToString(), "IV_x64", value);
            }           
        }

        private void addItem(string itemID, string itemName, string valueType, string value)
        {
            ListViewItem li = new ListViewItem();
            li.Tag = valueType;
            li.Text = itemID;
            li.SubItems.Add(itemName);
            switch (valueType)
            {
                case "value":
                    li.SubItems.Add("项目主值");
                    break;
                case "IV_x86":
                    li.SubItems.Add("32位主值");
                    break;
                case "IV_x64":
                    li.SubItems.Add("64位主值");
                    break;
            }
            li.SubItems.Add(value); 
            oListView1.Items.Add(li);
        }

        private void ReplaceItemValue_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (searchBack != null) searchBack.Abort();
        }

        private void replaceSelect_Box_Click(object sender, EventArgs e)
        {
            if (oListView1.Items.Count == 0) return;
            if(replaceValue_Box.Text == "")
            {
                if (MessageBox.Show("“替换为”文字为空，确定这是你想要的吗？", "是否还未填写替换的文字", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            }
            foreach(ListViewItem li in oListView1.Items)
            {
                if (li.Checked)
                {

                    string rpValue = replace(li.SubItems[3].Text);
                    OLEREO.Library.SQLite.ExecuteNonQuery("UPDATE Item SET " + li.Tag.ToString() + " = '" + myZiku.variableToSave(rpValue,ZIKU.DataBase.Config.Instance.Path).Replace("'", "''") + "' WHERE id = " + li.Text,ZIKU.DataBase.Config.Instance.Path);
                    oListView1.Items.Remove(li);
                }
            }
        }

        private string replace(string value)
        {
            int indexRp = value.ToLower().IndexOf(originalValue_Box.Text.ToLower());
            value = value.Remove(indexRp, originalValue_Box.Text.Length);
            if (value.ToLower().IndexOf(originalValue_Box.Text.ToLower()) != -1)
                value = replace(value);
            value = value.Insert(indexRp, replaceValue_Box.Text);
            return value;
        }

        private void menus_Opening(object sender, CancelEventArgs e)
        {
            if (oListView1.SelectedItems.Count == 0) editItem_Menu.Enabled = false; else editItem_Menu.Enabled = true;
        }

        private void editItem_Menu_Click(object sender, EventArgs e)
        {
            if(oListView1.SelectedItems.Count != 0)
            {
                Item.Item.Edit(oListView1.SelectedItems[0].Text);

                DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Item WHERE id = " + oListView1.SelectedItems[0].Text,ZIKU.DataBase.Config.Instance.Path);
                if (dt.Rows[0][oListView1.SelectedItems[0].Tag.ToString()].ToString().ToLower().IndexOf(originalValue_Box.Text.ToLower()) != -1)
                {
                    oListView1.SelectedItems[0].SubItems[1].Text = dt.Rows[0]["name"].ToString();
                    oListView1.SelectedItems[0].SubItems[3].Text = myZiku.variableToShow(dt.Rows[0][oListView1.SelectedItems[0].Tag.ToString()].ToString(),ZIKU.DataBase.Config.Instance.Path);
                }
                else oListView1.Items.Remove(oListView1.SelectedItems[0]);
            }         
        }

        private void originalValue_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) search_Box.PerformClick();
        }

    }
}
