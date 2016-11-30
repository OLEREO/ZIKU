using System;
using System.Data;
using System.Windows.Forms;
namespace ZIKU.Control.DataBase
{
    public partial class NotExists : Form
    {
        private string DBid;
        public NotExists(string DBid)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ICON;
            this.DBid = DBid;
           SettingDataBase.DB db = SettingDataBase.DB.getInstance(DBid);
            dbFilePath.Text = db.path;
        }

        private void cancel_Click(object sender, EventArgs e) { Environment.Exit(0); }


        private void chooseDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFileDialog = new OpenFileDialog();
            opFileDialog.InitialDirectory = Program.ZIKUPATH + "\\Data";
            opFileDialog.Filter = "ZIKU!数据库文件(*.mc)|*.mc";
            opFileDialog.Title = "选择一个数据库文件";
            if (opFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (ZIKU.DataBase.Options.checkAndUpdate(opFileDialog.FileName))
                {
                    ZIKU.DataBase.Config c = ZIKU.DataBase.Config.getInstance(opFileDialog.FileName);
                    SettingDataBase.DB.writeDB(DBid, c.name, opFileDialog.FileName);
                    SettingDataBase.Config.Instance = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("该数据库文件有误","选择失败");
                }
            }
        }

        private void searchDB_Click(object sender, EventArgs e)
        {     
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM DB", Program.zikuSettingPath);
            foreach(DataRow row in dt.Rows)
            {
                if (ZIKU.DataBase.Options.checkAndUpdate(row["path"].ToString()))
                {
                    OLEREO.Library.SQLite.ExecuteNonQuery("UPDATE Config SET Database_ID = '" + row["id"].ToString() + "' WHERE main='main'", Program.zikuSettingPath);
                    SettingDataBase.Config.Instance = null;
                    this.Close();
                    return;
                }
            }           
            MessageBox.Show("配置中所有记录的数据库文件都无效！\r\n\r\n请新建一个数据库文件", "配置中没有可用的数据库文件");
            searchDB.Enabled = false;
        }

        private void createNewDB_Click(object sender, EventArgs e)
        {
            string re = ZIKU.DataBase.Options.CreateDB();
            if(re != null)
            {
                ZIKU.DataBase.Config c = ZIKU.DataBase.Config.getInstance(re);
                SettingDataBase.DB.writeDB(DBid, c.name, re);
                SettingDataBase.Config.Instance = null;
                this.Close();
            }
        }
    }
}
