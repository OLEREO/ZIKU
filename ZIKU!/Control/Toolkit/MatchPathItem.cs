using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using OLEREO.Library;

namespace ZIKU.Control.Toolkit
{
    public partial class MatchPathItem : Form
    {
        public MatchPathItem()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ICON;

            DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM Variable",ZIKU.DataBase.Config.Instance.Path);
            foreach (DataRow row in dt.Rows)
            {
                comboBox1.Items.Add(row["name"].ToString());
                varComboBoxList.Add(row["path"].ToString());
            }

            DataTable dt2 = SQLite.ExecuteDataTable("SELECT * FROM Variable", Program.zikuSettingPath);
            foreach (DataRow row in dt2.Rows)
            {
                comboBox1.Items.Add(row["name"].ToString());
                varComboBoxList.Add(row["path"].ToString());
            }
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
        }
        private ArrayList varComboBoxList = new ArrayList();
        private Thread uithread;
        private void matching_Button_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox1.Text))
            {
                oListView1.Items.Clear();
                uithread = new Thread(new ParameterizedThreadStart(CheckUpThread));
                uithread.Start(textBox1.Text);
                stopMatch.Enabled = true;
            }
        }

        private void CheckUpThread(object path)
        {
            DirectoryInfo TheFolder = new DirectoryInfo((string)path);
    
            ArrayList itemPathList = new ArrayList();
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Item", ZIKU.DataBase.Config.Instance.Path);
            foreach(DataRow item in dt.Rows)
            {
                string value = myZiku.exPand(item["value"].ToString(),ZIKU.DataBase.Config.Instance.Path);
                if (value.Replace(" ", "") != "")
                    itemPathList.Add(value.ToLower());
                value = myZiku.exPand(item["IV_x86"].ToString(),ZIKU.DataBase.Config.Instance.Path);
                if (value.Replace(" ", "") != "")
                    itemPathList.Add(value.ToLower());
                value = myZiku.exPand(item["IV_x64"].ToString(),ZIKU.DataBase.Config.Instance.Path);
                if (value.Replace(" ", "") != "")
                    itemPathList.Add(value.ToLower());
            }
          
            //遍历文件
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                bool noHave = true;
                foreach (string itemPath in itemPathList)
                {
                    if(itemPath.StartsWith(NextFile.FullName.ToLower()))
                    {
                        itemPathList.Remove(itemPath);
                        noHave = false;
                        break;
                    }
                }
                if (noHave)
                {
                    if (!SQLite.isEXISTS(ZIKU.DataBase.Config.Instance.Path, "Exclude", "value", NextFile.FullName))
                        this.Invoke(new Action<string, string>(this.addPath), "文件", NextFile.FullName);
                }
                   
            }

            //遍历文件夹
            foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
            {
                bool noHave = true;
                foreach (string itemPath in itemPathList)
                {
                    if (itemPath.StartsWith(NextFolder.FullName.ToLower()))
                    {
                        itemPathList.Remove(itemPath);
                        noHave = false;
                        break;
                    }
                }
                if (noHave)
                {
                    if (!SQLite.isEXISTS(ZIKU.DataBase.Config.Instance.Path, "Exclude", "value", NextFolder.FullName))
                        this.Invoke(new Action<string, string>(this.addPath), "文件夹", NextFolder.FullName);
                }                   
            }

            this.Invoke(new Action<string>(this.DisbledStopMath),"");
        } 

        private void addPath(string bb, string path)
        {
            ListViewItem li = new ListViewItem();
            li.Text = bb;
            li.SubItems.Add(path);
            oListView1.Items.Add(li);
        }

        private void fileToItem_Menu_Click(object sender, EventArgs e)
        {
            if (oListView1.SelectedItems.Count > 0)
            {
                string path = oListView1.SelectedItems[0].SubItems[1].Text;
                if (File.Exists(path))
                {
                    string iID = Item.Item.Add(path,true);
                    if (iID != null)
                        oListView1.Items.Remove(oListView1.SelectedItems[0]);
                   Tools.SetForegroundWindow(this.Handle);
                }
            }
        }

        private void folderToItem_Menu_Click(object sender, EventArgs e)
        {
            if (oListView1.SelectedItems.Count > 0)
            {
                string path = oListView1.SelectedItems[0].SubItems[1].Text;
                if (Directory.Exists(path))
                {
                    OpenFileDialog opFileDialog = new OpenFileDialog();
                    opFileDialog.Title = "选择一个支持的图像文件作为自定义图标";
                    opFileDialog.InitialDirectory = path;

                    if (opFileDialog.ShowDialog() == DialogResult.OK)
                    {
                       string iID = Item.Item.Add(opFileDialog.FileName,true);
                        if (iID != null)
                            oListView1.Items.Remove(oListView1.SelectedItems[0]);
                        OLEREO.Library.Tools.SetForegroundWindow(this.Handle);
                    }                   
                }
            }
     
        }

        private void menu_Opening(object sender, CancelEventArgs e)
        {
            fileToItem_Menu.Visible = false;
            folderToItem_Menu.Visible = false;
            selectPath_Menu.Enabled = false;
            addToExcludeList_Menu.Enabled = false;
            copyPath_Menu.Enabled = false;
            if(oListView1.SelectedItems.Count > 0)
            {
                if (System.IO.File.Exists(oListView1.SelectedItems[0].SubItems[1].Text))
                {
                    fileToItem_Menu.Visible = true;
                    selectPath_Menu.Enabled = true;
                    addToExcludeList_Menu.Enabled = true;
                    copyPath_Menu.Enabled = true;
                }
                else if (Directory.Exists(oListView1.SelectedItems[0].SubItems[1].Text))
                {
                    folderToItem_Menu.Visible = true;
                    selectPath_Menu.Enabled = true;
                    addToExcludeList_Menu.Enabled = true;
                    copyPath_Menu.Enabled = true;
                }
            }
     
        }

        private void selectPath_Menu_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + oListView1.SelectedItems[0].SubItems[1].Text);
        }

        private void copyPath_Menu_Click(object sender, EventArgs e)
        {    
            Clipboard.SetDataObject(oListView1.SelectedItems[0].SubItems[1].Text);
            MainForm.Instance.showNotifyTip("复制到剪贴板", oListView1.SelectedItems[0].SubItems[1].Text);
        }

        private void addToExcludeList_Menu_Click(object sender, EventArgs e)
        {
            if(!SQLite.isEXISTS(ZIKU.DataBase.Config.Instance.Path, "Exclude", "value", oListView1.SelectedItems[0].SubItems[1].Text))
            SQLite.ExecuteNonQuery("INSERT INTO Exclude (value) values('" + oListView1.SelectedItems[0].SubItems[1].Text.Replace("'","''") + "')",ZIKU.DataBase.Config.Instance.Path);
            oListView1.Items.Remove(oListView1.SelectedItems[0]);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = (string)varComboBoxList[comboBox1.SelectedIndex];
        }
        private void DisbledStopMath(string ff)
        {
            stopMatch.Enabled = false;
            if (oListView1.Items.Count == 0)
                MessageBox.Show("该目录下没有未被记录的项目");
        }

        private void stopMatch_Click(object sender, EventArgs e)
        {
            if (uithread != null)
                uithread.Abort();
            stopMatch.Enabled = false;
        }

        private void excludeMatch_Button_Click(object sender, EventArgs e)
        {
            ExcludeMatchPath ecm = new ExcludeMatchPath();
            ecm.ShowDialog();
        }

        private void oListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (oListView1.SelectedItems.Count > 0)
            {
                if (System.IO.File.Exists(oListView1.SelectedItems[0].SubItems[1].Text))
                {
                    fileToItem_Menu_Click("", e);   
                }
                else if (Directory.Exists(oListView1.SelectedItems[0].SubItems[1].Text))
                {
                    folderToItem_Menu_Click("", e);
                }
            }
        }

        private void oListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
