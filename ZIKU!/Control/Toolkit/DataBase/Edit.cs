using System;
using System.Windows.Forms;

namespace ZIKU.Control.DataBase
{
    public partial class Edit : Form
    {
        /// <summary>
        /// 编辑的数据库文件路径(已经展开变量)
        /// </summary>
      //  private string DBPath ="";

 
        /// <summary>
        /// 编辑的数据库文件在软件配置中的ID
        /// </summary>
        private string DBid;
        public Edit(string DBID)
        {
            InitializeComponent();
            this.DBid = DBID;
            SettingDataBase.DB db = SettingDataBase.DB.getInstance(DBID);
            if(db != null) 
            {
                ZIKU.DataBase.Config d = ZIKU.DataBase.Config.getInstance(db.path);//获取实际数据库文件的信息
                if(d != null)
                {
                    dbName.Text = d.name;
                    dbDataFolder.text = d.dataFolderShow;
                }
                else
                {
                    dbName.Text = db.name;
                    dbDataFolder.Enabled = false;
                }
                dbFilePath.Text = db.path;            
            }
            else
            {
                dbName.Text = "找不到该数据库文件在软件配置中的信息";
                dbName.Enabled = false;
                dbFilePath.Enabled = false;
                dbFilePath.Text = "请指定一个现有的数据库文件";
                dbDataFolder.Enabled = false;
                save.Enabled = false;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            string name = dbName.Text;
            string dataFolder = dbDataFolder.text;      
            string path = Environment.ExpandEnvironmentVariables(dbFilePath.Text);
            if (!ZIKU.DataBase.Options.checkAndUpdate(path))
            {
                if (MessageBox.Show("检测到数据库文件设置有误，是否返回修改？\r\n\r\n“否”会忽略错误", "数据库有误", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    return;
            }
     
                       
            SettingDataBase.DB.writeDB(DBid, name, path);//保存到软件配置

            //保持到数据库文件
            if (System.IO.File.Exists(path))
            {
                ZIKU.DataBase.Config db = ZIKU.DataBase.Config.getInstance(path);
                string dataFolderExpand = myZiku.exPand(myZiku.variableToSave(dataFolder, path),path);
                //新旧 的项目资料目录不一样
                if (db.dataFolderExpand != dataFolderExpand)
                {
                    //是否可以成功创建新的目录
                    try { System.IO.Directory.CreateDirectory(dataFolderExpand); } catch { }
                    if (!System.IO.Directory.Exists(dataFolderExpand))
                    {
                        DialogResult mbbRE = MessageBox.Show("新的“项目资料目录”无法创建，请确认路径填写正确以及当前系统用户有权限在该目录下创建文件\r\n\r\n是否重新编辑？", "无法创建“项目资料目录”", MessageBoxButtons.YesNo);
                        if (mbbRE == DialogResult.Yes)
                            return;
                    }
                    else
                    {
                        //判断是否为根目录
                        if (dataFolderExpand.Length == 3)
                        {
                            DialogResult mbbRE = MessageBox.Show("新的“项目资料目录”为根目录？\r\n\r\n如果是根目录的话，实在是不推荐你这样做。\r\n\r\n是否重新编辑？", "新的“项目资料目录”是根目录？", MessageBoxButtons.YesNo);
                            if (mbbRE == DialogResult.Yes)
                                return;
                        }

                        //成功创建新的目录
                        //旧的目录是否存在
                        if (System.IO.Directory.Exists(db.dataFolderExpand))
                        {
                            string[] arrOIDF = System.IO.Directory.GetFileSystemEntries(db.dataFolderExpand);
                            if (arrOIDF.Length != 0)
                            {
                                DialogResult mbbRE = MessageBox.Show("旧的“项目资料目录”中有文件，请问是否转移(移动)到新的“项目资料目录”中？", "旧的“项目资料目录”中已有文件", MessageBoxButtons.YesNo);
                                //尝试转移旧的项目资料目录到新的资料目录中
                                if (mbbRE == DialogResult.Yes)
                                {
                                    OLEREO.Library.Tools.MyComputer.FileSystem.MoveDirectory(db.dataFolderExpand, dataFolderExpand, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
                                }
                            }
                        }
                    }
                }
                ZIKU.DataBase.Config.writeConfig(name, myZiku.variableToSave(dataFolder, path), path);
            }
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                        dbName.Text = c.name;
                        dbDataFolder.text = c.dataFolderShow;
                    dbFilePath.Text = opFileDialog.FileName.Replace(Program.ZIKUPATH, ".");                
                    dbName.Enabled = true;
                    dbDataFolder.Enabled = true;
                    save.Enabled = true;
                }
                else
                {
                    MessageBox.Show("错误的数据库文件", "导入失败");
                }
            }
        }

        private void dbDataFolder_rButtonClicked(OLEREO.Control.FloatingTextBox THIS, OLEREO.Control.oTextBox oTextBox, EventArgs e)
        {
            THIS.ShowFloating(myZiku.exPand(myZiku.variableToSave(oTextBox.Text, ZIKU.DataBase.Config.Instance.Path), ZIKU.DataBase.Config.Instance.Path));
        }

        private void reReadDB_Click(object sender, EventArgs e)
        {     
            if (ZIKU.DataBase.Options.checkAndUpdate(Environment.ExpandEnvironmentVariables(dbFilePath.Text)))
                {
                    ZIKU.DataBase.Config c = ZIKU.DataBase.Config.getInstance(Environment.ExpandEnvironmentVariables(dbFilePath.Text));
                    dbName.Text = c.name;
                    dbDataFolder.text = c.dataFolderShow;
                    dbFilePath.Text = Environment.ExpandEnvironmentVariables(dbFilePath.Text).Replace(Program.ZIKUPATH, ".");
                    dbName.Enabled = true;
                    dbDataFolder.Enabled = true;
                    save.Enabled = true;
                }
                else
                {
                    MessageBox.Show("错误的数据库文件", "读取失败");
                }            
        }
    }
}
