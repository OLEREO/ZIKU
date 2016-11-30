using OLEREO.Library;
using System;
using System.Windows.Forms;

namespace ZIKU.Control.Category
{
    public partial class SwitchPtoS : Form
    {
        public SwitchPtoS(string pID)
        {
            InitializeComponent();
            switchPCID = pID;
           foreach(string pc in Tools.SplitString(ZIKU.DataBase.Config.Instance.pCsort))
            {
                if(pc != pID)
                {
                    ZIKU.DataBase.Category cc = ZIKU.DataBase.Category.getInstance(pc);
                    if(cc != null)
                    {
                        ListViewItem li = new ListViewItem();
                        li.Tag = pc;
                        li.Text = cc.name;
                        oListView1.Items.Add(li);
                    }                 
                }
            }
        }
        private string switchPCID = null;
        private string selectPCID = null;
        private void oListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(oListView1.SelectedItems.Count > 0)
            {
                ok_Button.Enabled = true;
                selectPCID = oListView1.SelectedItems[0].Tag.ToString();
            }           
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Button_Click(object sender, EventArgs e)
        {
            ZIKU.DataBase.Category category = ZIKU.DataBase.Category.getInstance(switchPCID);

            string oSub = ""; //旧的子分类
            foreach (string subID in category.C_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                ZIKU.DataBase.Category sub = ZIKU.DataBase.Category.getInstance(subID);
                if (sub != null)
                {
                    ZIKU.DataBase.Category.writeCategory(sub.id, sub.name, "1", "");//将子分类改成父分类，并记录ID
                    oSub += ";" + sub.id + ";";
                }
            }

            ZIKU.DataBase.Category P = ZIKU.DataBase.Category.getInstance(selectPCID);

            SQLite.ExecuteNonQuery("UPDATE Category SET  C_ID = '" + P.C_ID + ";" + switchPCID + "' WHERE id = " + selectPCID, ZIKU.DataBase.Config.Instance.Path);
            SQLite.ExecuteNonQuery("UPDATE Category SET  C_ID = '" + selectPCID + "',type = '2' WHERE id = " + switchPCID, ZIKU.DataBase.Config.Instance.Path);

            string pCsort = "";
            foreach (ListViewItem li in oListView1.Items)
            {
                pCsort += ";" + li.Tag.ToString();
            }
            ZIKU.DataBase.Config.updatePCsort(pCsort + oSub);
            this.Close();
        }
    }
}
