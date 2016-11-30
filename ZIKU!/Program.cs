using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.Permissions;

namespace ZIKU
{
    static class Program
    {
        public static string updateFileLink = "https://ock8ryf1x.qnssl.com/zikuUP.db";
        /// <summary>
        /// 主窗口的标题
        /// </summary>
        public static string mainFormTitle
        {
            get
            {
                if (System.IO.File.Exists(ZIKUPATH + "\\ziku"))    
                    return "ZIKU! - OLEREO.COM.";                
                else
                    return "ZIKU! - OLEREO.COM";
            }
        }
  
        private static string _ZIKUPATH;
        private static string _zikuSettingPath =  @".\Data\ziku.set";
        /// <summary>
        /// ZIKU! 所在的目录
        /// </summary>
        public static string ZIKUPATH
        {
            get
            {
                if(_ZIKUPATH == null)
                {
                    if (Application.StartupPath.ToLower().EndsWith("\\bin"))
                        _ZIKUPATH = Application.StartupPath.Remove(Application.StartupPath.Length - 4, 4);
                    else
                        _ZIKUPATH = Application.StartupPath;
                    System.Environment.CurrentDirectory = _ZIKUPATH;
                }
                return _ZIKUPATH;
            }
        }

        /// <summary>
        /// 软件配置文件完整路径
        /// </summary>
        public static string zikuSettingPath { get { return _zikuSettingPath; } }

        /// <summary>
        /// ZIKU的当前版本号
        /// </summary>
        public static string ZIKUVER = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion.ToString();

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        static void Main(string[] args)
        {
            string z = ZIKUPATH;
            #region 捕捉未知错误的引用
            Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //检查是否有配置文件
            if (!System.IO.File.Exists(_zikuSettingPath))            
                Welcome.show();
           
            //检查数据库文件是否存在

            SettingDataBase.DB db = SettingDataBase.DB.getInstance(SettingDataBase.Config.Instance.DataBaseID);
            if (db != null)
            {             
                if (!System.IO.File.Exists(System.Environment.ExpandEnvironmentVariables(db.path)))
                {
                    ZIKU.Control.DataBase.NotExists notExists = new Control.DataBase.NotExists(SettingDataBase.Config.Instance.DataBaseID);
                    notExists.ShowDialog();              
                }
            }
            else
            {
                Control.DataBase.NotExists notExists = new Control.DataBase.NotExists(SettingDataBase.Config.Instance.DataBaseID);
                notExists.ShowDialog();
            }

            //设置使用的数据库       
            if (!DataBase.Options.setUseDB(SettingDataBase.Config.Instance.DataBaseID))
            {

            }
           

            //启动主窗口
            IntPtr ihand = FindWindow(null, mainFormTitle);
            if (ihand == IntPtr.Zero)
            {
                if (args.Length == 0)
                    Application.Run(new MainForm());
                else
                {
                    if (args[0] == "startup")
                        Application.Run(new HideOnStartupApplicationContext(new MainForm()));
                    else if(args[0].StartsWith("item:"))
                    {
                        Application.Run(new HideOnStartupApplicationContext(new MainForm(args[0].Remove(0, 5))));
                    }
                    else
                        Application.Run(new MainForm());
                }
            }
            else
            {
                if (args.Length == 0)
                    SendMessage(ihand, Message.WM_NOTIFYICON, 300, 300);
                else
                {
                    if (args[0].StartsWith("item:"))                    
                        myZiku.run(DataBase.Item.getInstance(args[0].Remove(0, 5)));
                    else
                        SendMessage(ihand, Message.WM_NOTIFYICON, 300, 300);
                }
            }
        }

        #region 未知错误的处理
        private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            //DialogResult result = DialogResult.Cancel;
            //try
            //{
            //    result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
            //}
            //catch
            //{
            //    try
            //    {
            //        MessageBox.Show("Fatal Windows Forms Error",
            //            "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
            //    }
            //    finally
            //    {
            //        Application.Exit();
            //    }
            //}
            //// Exits the program when the user clicks Abort.
            //if (result == DialogResult.Abort)
            //    Application.Exit();
            OLEREO.Control.EmailContact.erroReport("严重的错误：" + "\r\n\r\n" 
                + t.Exception + "\r\n\r\n"
                + t.Exception.Message + "\r\n\r\n"
                 + t.Exception.StackTrace + "\r\n\r\n"
                + t.ToString(), "严重的错误", "程序发了一个严重的未知错误，您愿意将该错误的信息发送给我，以便我改进此错误吗？",false);           
                Application.Exit(); 
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //try
            //{
            //    Exception ex = (Exception)e.ExceptionObject;
            //    string errorMsg = "An application error occurred. Please contact the adminstrator " +
            //        "with the following information:\n\n";
            //    // Since we can't prevent the app from terminating, log this to the event log.
            //    if (!EventLog.SourceExists("ThreadException"))
            //    {
            //        EventLog.CreateEventSource("ThreadException", "Application");
            //    }
            //    // Create an EventLog instance and assign its source.
            //    EventLog myLog = new EventLog();
            //    myLog.Source = "ThreadException";
            //    myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
            //}
            //catch (Exception exc)
            //{
            //    try
            //    {
            //        MessageBox.Show("Fatal Non-UI Error",
            //            "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
            //            + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    }
            //    finally
            //    {
            //        Application.Exit();
            //    }
            //}
            OLEREO.Control.EmailContact.erroReport("严重的错误：" + "\r\n\r\n" 
                + e.ToString() + "\r\n\r\n" 
                + e.ExceptionObject.ToString(), "严重的错误", "程序发了一个严重的未知错误，您愿意将该错误的信息发送给我，以便我改进此错误吗？", false);
            Application.Exit();
        }
        //private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        //{
        //    string errorMsg = "An application error occurred. Please contact the adminstrator " +
        //        "with the following information:\n\n";
        //    errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
        //    return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
        //        MessageBoxIcon.Stop);
        //}
        #endregion
        internal class HideOnStartupApplicationContext : ApplicationContext
        {
            public HideOnStartupApplicationContext(Form mainForm)
            {
                mainForm.Closed += delegate (object sender, EventArgs e) {
                    Application.Exit();
                };
            }
        } 

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
    }
}