using System;
using System.Windows.Forms;

namespace ZIKU.Control.Variable
{
    
    public partial class Edit : Form
    {
        /// <summary>
        /// 需要返回的 Variable 实例
        /// </summary>
        private static ZIKU.Variable reVar;
        /// <summary>
        /// 编辑的变量ID，如果为空则表示为新建,不要通过null判断
        /// </summary>
        private string varID = "";
        /// <summary>
        /// UID前缀
        /// </summary>
        private string uidPrefix = "";
        /// <summary>
        /// 编辑变量所在的数据库
        /// </summary>
        private string DBPath;

        private Edit() {
            InitializeComponent();
            this.Icon = Properties.Resources.ICON;
        }

        /// <summary>
        /// 获取编辑后的变量,取消返回null，id为null 会新建一个
        /// </summary>
        /// <param name="path">数据库的位置(用以判断是否重复)</param>
        /// <param name="prefix">数据库变量的前缀</param>
        /// <param name="id">不填写则返回一个新的，填写则编辑一个现有的</param>
        /// <returns></returns>
        public static ZIKU.Variable getEditVariable(string path,string prefix,string id)
        {
            reVar = null;
            Edit ve = new Edit();
            ve.DBPath = path;
            ve.uidPrefix = prefix;
            if (id != null)
            {
                ZIKU.Variable v = ZIKU.Variable.getIDVariable(id, path);
                if (v == null) return null;
                ve.varID = id;
                ve.varName.Text = v.name;
                ve.varPath.text = v.pathShow;
                ve.varUID.Text = v.uid;               
            }
            ve.varUidPrefix.Text = "变量名：%" + prefix;
            ve.ShowDialog();
            return reVar;
        }


        private void Cancel_Click(object sender, EventArgs e) { reVar = null; this.Close(); }
        private void Save_Click(object sender, EventArgs e)
        {
            string name = varName.Text;
            string uid = varUID.Text;
            string path =  myZiku.variableToSave(varPath.text, DBPath);

            ZIKU.Variable var = ZIKU.Variable.writeVariable(ref varID, uid, name, path, uidPrefix, DBPath);
            if (var == null) return;
            reVar = var;   
            this.Close();
        }

        private void varPath_rButtonClicked(OLEREO.Control.FloatingTextBox THIS, OLEREO.Control.oTextBox oTextBox, EventArgs e)
        {
            THIS.ShowFloating(myZiku.exPand(myZiku.variableToSave(oTextBox.Text, DBPath), DBPath));
        }
    }
}
