using System;
using System.Windows.Forms;
using OLEREO.Library;
using System.Data;

namespace ZIKU.Control.Variable
{
    //编辑全局变量 zset   //数据库，利用path   //项目id
    public partial class Manage : Form
    {
        ///// <summary>
        ///// 数据库文件路径，编辑项目时为当前数据库
        ///// </summary>
        //private string DBPath = null;
        ///// <summary>
        ///// 数据库的变量前缀
        ///// </summary>
        //private string uidPrefix = "";

        /// <summary>
        /// 当前编辑的是全局数据库变量吗
        /// </summary>
        private bool isGlobal = false;

        private string dbPath = "";
        private string prefix = "";

        ///// <summary>
        ///// 管理数据库中的变量
        ///// </summary>
        ///// <param name="path">数据库的路径</param>
        ///// <param name="prefix">数据库变量的前缀</param>
        //private Manage(string path,string prefix)
        //{
      
        //    this.Icon = Properties.Resources.ICON;
        //    MaximizeBox = false;
        //    MinimizeBox = false;
        //    if (prefix != null) this.uidPrefix = prefix;
        //    DBPath = path;
        //    readVariable();
        //}

        private Manage(bool isGlobal)
        {
            InitializeComponent();
            this.isGlobal = isGlobal;
            if(isGlobal)
            {
                dbPath = Program.zikuSettingPath;
                prefix = "G-";
            }else
            {
                dbPath = ZIKU.DataBase.Config.Instance.Path;
            }
            Icon = Properties.Resources.ICON;
            MaximizeBox = false;
            MinimizeBox = false;
            readVariable();
        }


        public static void ShowManage(bool isGlobal)
        {
            Manage m = new Manage(isGlobal);
            if (isGlobal)
            {
                m.Text = "全局内部变量管理";
                m.dbPathLabel.Text = Program.zikuSettingPath;
            }
            else
            {
                m.Text = "数据库内部变量管理";
                m.dbPathLabel.Text = ZIKU.DataBase.Config.Instance.Path;
            }
            m.ShowDialog();
        }


        ///// <summary>
        ///// 打开管理数据库文件变量窗口
        ///// </summary>
        ///// <param name="path">数据库的路径</param>
        ///// <param name="prefix">数据库变量的前缀</param>
        //public static void manageVariable(string path, string prefix,string title = "内部变量管理")
        //{
        //    Manage varM = new Manage(path, prefix);
        //    varM.Text = title;
        //    varM.varDBPath.Text = path;
        //    varM.ShowDialog();
        //}

        /// <summary>
        /// 读取变量列表
        /// </summary>
        private  void readVariable()
        {
            VariableListview.Items.Clear();
            DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM Variable;", dbPath);

            foreach(DataRow row in dt.Rows)
            {
                ListViewItem li = new ListViewItem();
                li.Tag = row["id"].ToString();            
                li.Text = row["name"].ToString();
                li.SubItems.Add(prefix + row["uid"].ToString());
                li.SubItems.Add(myZiku.variableToShow(row["path"].ToString(),dbPath));
                VariableListview.Items.Add(li);
            }
        }

        private void addVariableButton_Click(object sender, EventArgs e)
        {
            ZIKU.Variable v = Edit.getEditVariable(dbPath,prefix,null);
            if (v != null)
            {
                readVariable();
                //ListViewItem li = new ListViewItem();
                //li.Tag = v.id;
                //li.Text = uidPrefix + v.uid;
                //li.SubItems.Add(v.name);
                //li.SubItems.Add(v.pathShow);
                //VariableListview.Items.Add(li); 
            }
        }

        private void editVariable_Click(object sender, EventArgs e)
        {
            if (VariableListview.SelectedItems.Count > 0)
            {
                string id = VariableListview.SelectedItems[0].Tag.ToString();
                ZIKU.Variable v = Edit.getEditVariable(dbPath,prefix, id);
                if (v != null)
                {
                    readVariable();
                }
            }
            else editVariable.Enabled = false;
        }

        private void delVariableButton_Click(object sender, EventArgs e)
        {
            if (VariableListview.SelectedItems.Count > 0)
            {
                string id = VariableListview.SelectedItems[0].Tag.ToString();
                ZIKU.Variable v = ZIKU.Variable.getIDVariable(id, dbPath);
                if(v == null) { VariableListview.Items.Remove(VariableListview.SelectedItems[0]);delVariableButton.Enabled = false;return; }
                if (MessageBox.Show("确定删除变量“"+v.name+"”(%" + prefix+v.uid+"%)","删除变量",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    string flag = "%ovar$" + id + "%";
                    if (isGlobal)
                        flag = "%g$" + id + "%";

                    if (MessageBox.Show("是否使用“变量值”替换引用处的值\r\n\r\n否：保留“变量名”", "引用值处理", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        ZIKU.Variable.removeVariableReference(flag, v.path);
                    else
                        ZIKU.Variable.removeVariableReference(flag, "%" + prefix + v.uid + "%");

                    SQLite.ExecuteNonQuery("DELETE FROM Variable WHERE id = " + id, dbPath);

                    VariableListview.Items.Remove(VariableListview.SelectedItems[0]);
                    delVariableButton.Enabled = false;
                    editVariable.Enabled = false;
                }
            }
            else delVariableButton.Enabled = false;
        }

        private void VariableListview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VariableListview.SelectedItems.Count > 0)
            {
                delVariableButton.Enabled = true;
                editVariable.Enabled = true;
            }
            else
            {
                delVariableButton.Enabled = false;
                editVariable.Enabled = false;
            }
        }
    }
}
