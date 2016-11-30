using System;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using OLEREO.Control;
using System.Threading;

namespace ZIKU.Control
{
    public partial class setting : Form
    {


        public setting()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ICON;

            isHotKey.Checked = SettingDataBase.Config.Instance.isHotKey;
            HotKeyA_Box.SelectedItem = SettingDataBase.Config.Instance.hotKeyA;
            HotKeyB_Box.SelectedItem = SettingDataBase.Config.Instance.hotKeyB;
            HotKeyA_Box.Enabled = SettingDataBase.Config.Instance.isHotKey;
            HotKeyB_Box.Enabled = SettingDataBase.Config.Instance.isHotKey;

            isSeHotkey.Checked = SettingDataBase.Config.Instance.isSeHotKey;
            seA_box.SelectedItem = SettingDataBase.Config.Instance.seHotKeyA;
            seB_box.SelectedItem = SettingDataBase.Config.Instance.seHotKeyB;
            seA_box.Enabled = SettingDataBase.Config.Instance.isSeHotKey;
            seB_box.Enabled = SettingDataBase.Config.Instance.isSeHotKey;
            checkUP_Box.Checked = SettingDataBase.Config.Instance.checkUP;

            string startupPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            startup.Checked = System.IO.File.Exists(startupPath + "\\ziku.lnk");
            label1.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion.ToString();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 检查更新
        private Thread checkUPThread;
        private void CheckUP_Click(object sender, EventArgs e)
        {
            if (checkUPThread != null) checkUPThread.Abort();
             checkUPThread = new Thread(new ThreadStart(this.CheckUpThread));
            checkUPThread.Start();        
        }
        private void CheckUpThread()
        {
            Invoke(new Action<int>(UpdateCheckUp), Updates.checkUpdates(Program.updateFileLink, Program.ZIKUVER, "ZIKU! 更新"));
        }
        private void UpdateCheckUp(int v)
        {
            switch (v)
            {
                case 0:
                    label1.Text = "查询更新失败";
                    break;
                case 1:
                    Updates.showUpdates();
                    break;
                case 2:
                    label1.Text = "已经是最新版本";
                    break;
            }
        }
        #endregion

        private void Save_Click(object sender, EventArgs e)
        {
            SettingDataBase.Config.writeConfig(isHotKey.Checked, HotKeyA_Box.SelectedItem.ToString(), HotKeyB_Box.SelectedItem.ToString()
                , isSeHotkey.Checked, seA_box.SelectedItem.ToString(), seB_box.SelectedItem.ToString(),checkUP_Box.Checked);

            string startupPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Startup);

            if (startup.Checked)
            {
                System.IO.File.Delete(startupPath + "\\ziku.lnk");
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(startupPath + "\\ziku.lnk");
                shortcut.TargetPath = AppDomain.CurrentDomain.BaseDirectory + "\\ZIKU!.exe";
                shortcut.Arguments = "startup";// 参数 
                shortcut.Description = "ZIKU! - OLEREO.COM";
                shortcut.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                shortcut.WindowStyle = 1;
                shortcut.Save();
            }
            else
                System.IO.File.Delete(startupPath + "\\ziku.lnk");

            this.Close();
        }

         
        private void isHotKey_CheckedChanged(object sender, EventArgs e)
        {
            HotKeyA_Box.Enabled = isHotKey.Checked;
            HotKeyB_Box.Enabled = isHotKey.Checked;
        }

        private void isSeHotkey_CheckedChanged(object sender, EventArgs e)
        {
            seA_box.Enabled = isSeHotkey.Checked;
            seB_box.Enabled = isSeHotkey.Checked;
        }

        private void setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkUPThread != null) checkUPThread.Abort();
        }
    }
}
