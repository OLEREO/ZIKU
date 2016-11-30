using System;
using System.Windows.Forms;
using System.Data;

namespace ZIKU
{
    public partial class Welcome : Form
    {
        /// <summary>
        /// 首次启动欢迎窗口
        /// 通过布尔值 result 可以判定是否完成初始化
        /// </summary>
        private Welcome()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ICON;
            System.IO.Directory.CreateDirectory(Program.ZIKUPATH + "\\Data");
        }      
  
        private void newCategoryFile_Click(object sender, EventArgs e)
        {          
            string re = DataBase.Options.CreateDB();
            if (re == null)
                return;
            if (!SettingDataBase.Options.CreateSettingDB())
            {
                MessageBox.Show("创建软件配置文件失败");
                    this.Close();
            }
            DataBase.Config c = DataBase.Config.getInstance(re);
            re = re.Replace(Program.ZIKUPATH, ".");
            int re1 = OLEREO.Library.SQLite.ExecuteNonQuery("INSERT  INTO DB (name, path) VALUES ('" + c.name.ToString().Replace("'", "''") + "', '" + re.Replace("'", "''") + "');", Program.zikuSettingPath);
            OLEREO.Library.SQLite.ExecuteNonQuery("UPDATE Config SET Database_ID = '"+re1.ToString()+"' WHERE main='main'", Program.zikuSettingPath);        
            this.Close();
        }

        /// <summary>
        /// 显示欢迎界面，如果取消创建配置，会自动退出主线程
        /// </summary>
        public static void show()
        {
            Welcome we = new Welcome();
            we.ShowDialog();
            if(!System.IO.File.Exists(Program.zikuSettingPath))
                Environment.Exit(0);           
        }
    }
}
