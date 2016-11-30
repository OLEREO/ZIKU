using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using OLEREO.Library;
using System.Windows.Forms;

namespace ZIKU.Control.Toolkit
{
    public partial class ExcludeMatchPath : Form
    {
        public ExcludeMatchPath()
        {
            InitializeComponent();
            DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM Exclude", ZIKU.DataBase.Config.Instance.Path);
            foreach(DataRow row in dt.Rows)
            {
                ListViewItem li = new ListViewItem();
                li.Tag = row["id"].ToString();
                li.Text = row["value"].ToString();
                oListView1.Items.Add(li);
            }
        }

        private void menu_Opening(object sender, CancelEventArgs e)
        {
            menu.Enabled = true;
            if (oListView1.SelectedItems.Count == 0) menu.Enabled = false;
        }

        private void oListView1_SizeChanged(object sender, EventArgs e)
        {
            oListView1.Columns[0].Width = this.Size.Width - 30;
        }

        private void removeExclude_Menu_Click(object sender, EventArgs e)
        {
            SQLite.ExecuteNonQuery("DELETE FROM [Exclude] WHERE id = " + (string)oListView1.SelectedItems[0].Tag,ZIKU.DataBase.Config.Instance.Path);
            oListView1.Items.Remove(oListView1.SelectedItems[0]);
        }
    }
}
