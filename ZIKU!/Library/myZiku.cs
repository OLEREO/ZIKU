using System;
using ZIKU.DataBase;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;

namespace ZIKU
{
    class myZiku
    {

        #region 对变量路径进行操作(ZIKU)
        /// <summary>
        /// 变量循环次数（用来防止展开字符串死循环）
        /// </summary>
        static int DontSOf = 0;
        /// <summary>
        /// 展开变量(请传入save值)
        /// </summary>
        /// <param name="repath">需要展开的路径</param>
        /// <returns></returns>
        public static string exPand(string repath, string DBPath)
        {
            if (!File.Exists(System.Environment.ExpandEnvironmentVariables(DBPath))) return null;

            DontSOf = 0;
            repath = UseExPand(repath, Environment.ExpandEnvironmentVariables(DBPath));

            DontSOf = 0;
            return repath;
        }

        /// <summary>
        /// 将show值转换成save值
        /// </summary>
        /// <param name="DirValue">包含变量缩写的路径</param>
        /// <returns>返回转换后的路径</returns>
        public static string variableToSave(string DirValue, string DBPath)
        {
            if (!File.Exists(Environment.ExpandEnvironmentVariables(DBPath))) return null;

            Match gMatch = Regex.Match(DirValue, @"\%.*?\%");
            while (gMatch.Success)
            {
                string BL = gMatch.Groups[0].Value.Replace("%", "");
                string tou, UID;
                if (getItemIDorUID(BL,out tou,out UID))
                {
                    DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Item WHERE UID LIKE '" + UID + "'", Config.Instance.Path);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            DirValue = DirValue.Replace("%" + BL + "%", "%" + tou + "-" + dt.Rows[0]["id"].ToString() + "%");
                        }
                    }
                }
                else if (BL.ToUpper().StartsWith("G-"))
                {
                    string varUID = BL.Remove(0, 2);
                    Variable var = Variable.getUIDVariable(varUID, Program.zikuSettingPath);
                    if (var != null)
                        DirValue = DirValue.Replace("%" + BL + "%", "%g$" + var.id + "%");

                } else if (!BL.ToUpper().StartsWith("OVAR$"))
                {
                    Variable var = Variable.getUIDVariable(BL, DBPath);
                    if (var != null)
                        DirValue = DirValue.Replace("%" + BL + "%", "%ovar$" + var.id + "%");
                }
                gMatch = gMatch.NextMatch();
            }   
            return DirValue;
        }

        /// <summary>
        /// 获取值中的项目id或UID
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tou"></param>
        /// <param name="idORuid"></param>
        /// <returns></returns>
        static bool getItemIDorUID(string value, out string tou, out string idORuid)
        {
            bool isItemIDorUID = false;
            tou = "";
            idORuid = "";
            string[] bkSP = value.ToUpper().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (bkSP.Length == 2) //如果是项目的变量，只会有两个部分 开头-UID
            {
                switch (bkSP[0])
                {
                    case "ITEM":
                    case "I":
                    case "ITEM32":
                    case "I32":
                    case "ITEM64":
                    case "I64":
                    case "ITEMWORKPATH":
                    case "IW":
                    case "ITEMARGUMENTS":
                    case "IA":
                    case "ITEMPATH":
                    case "IP":
                    case "ITEMDATA":
                    case "ID":
                        isItemIDorUID = true;
                        tou = bkSP[0].ToLower();
                        idORuid = bkSP[1];
                        break;
                    default:
                        bkSP = null;
                        break;
                }
            }
            return isItemIDorUID;
        }

        /// <summary>
        /// 将save值转成show变量
        /// </summary>
        /// <param name="DirValue">需要转换的变量</param>
        /// <returns>返回转换后的展示变量</returns>
        public static string variableToShow(string DirValue, string DBPath)
        {
            if (!File.Exists(System.Environment.ExpandEnvironmentVariables(DBPath))) return null;

            Match gMatch = Regex.Match(DirValue, @"\%.*?\%");
            while (gMatch.Success)
            {
                string BL = gMatch.Groups[0].Value.Replace("%", "");

                string tou, id;

                if (getItemIDorUID(BL,out tou,out id))
                {
                    DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Item WHERE id = " + id, Config.Instance.Path, null, false);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            DirValue = DirValue.Replace("%" + BL + "%", "%" + tou + "-" + dt.Rows[0]["UID"].ToString() + "%");
                        }
                    }
                }else if (BL.StartsWith("ovar$"))
                {
                    Variable var = Variable.getIDVariable(BL.Remove(0, 5), DBPath);
                    if (var != null)
                        DirValue = DirValue.Replace("%" + BL + "%", "%" + var.uid + "%");
                }
                else if (BL.StartsWith("g$"))
                {
                    Variable var = Variable.getIDVariable(BL.Remove(0, 2), Program.zikuSettingPath);
                    if (var != null)
                        DirValue = DirValue.Replace("%" + BL + "%", "%G-" + var.uid + "%");
                }
                gMatch = gMatch.NextMatch();
            }
 
            return DirValue;
        }


        /// <summary>
        /// 展开全局变量
        /// </summary>
        /// <param name="repath"></param>
        /// <returns></returns>
        static string ExPandG(string repath)
        {
            if (DontSOf == 10)
                return repath;
            DontSOf++;

            Match gMatch = Regex.Match(repath, @"\%.*?\%");
            while (gMatch.Success)
            {
                string GL = gMatch.Groups[0].Value.Replace("%", "");
                bool unCheck = true;
                if (GL.ToLower().StartsWith("g$"))
                {
                    string gVarid = GL.Remove(0, 2);
                    Variable var = Variable.getIDVariable(gVarid, Program.zikuSettingPath);
                    if (var != null)
                        repath = repath.Replace("%" + GL + "%", ExPandG(var.path));
                    unCheck = false;
                }

                #region ZIKU所在目录
                if (unCheck)
                {
                    if (GL.ToLower() == "ziku")
                    {
                        repath = repath.Replace("%" + GL + "%", Program.ZIKUPATH);
                        unCheck = false;
                    }
                }
                #endregion

                #region ZIKU所在磁盘盘符
                if (unCheck)
                {
                    if (GL.ToLower() == "root")
                    {
                        repath = repath.Replace("%" + GL + "%", Program.ZIKUPATH.Split(Convert.ToChar("\\"))[0]);
                        unCheck = false;
                    }
                }
                #endregion


                #region 未被引用的全局变量UID
                if (unCheck)
                {
                    if (GL.ToUpper().StartsWith("G-"))
                    {
                        DataTable dtUID = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Variable WHERE UID LIKE '" + GL.Remove(0, 2) + "'", Program.zikuSettingPath);
                        if (dtUID.Rows.Count != 0)
                        {
                            repath = repath.Replace("%" + GL + "%", ExPandG(dtUID.Rows[0]["path"].ToString()));
                            unCheck = false;
                        }
                    }
                }
                #endregion

                gMatch = gMatch.NextMatch();
            }
            repath = upPath(repath);
            return repath;
        }

        /// <summary>
        /// 展开数据库变量
        /// </summary>
        /// <param name="repath">需要展开的路径</param>
        static string UseExPand(string repath, string DBPath)
        {
            if (DontSOf == 10)
                return repath;
            DontSOf++;
            Match varMatch = Regex.Match(repath, @"\%.*?\%");
            while (varMatch.Success)
            {
                string BL = varMatch.Groups[0].Value.Replace("%", "");

                bool unCheck = true;

                #region 全局变量
                if (unCheck)
                {
                    if (BL.ToUpper().StartsWith("G$"))
                    {
                        unCheck = false;
                        string gVarid = BL.Remove(0, 2);
                        Variable var = Variable.getIDVariable(gVarid, Program.zikuSettingPath);
                        if (var != null)
                            repath = repath.Replace("%" + BL + "%", ExPandG(var.path));
                    }
                }
                #endregion

                #region 项目变量   
                if (unCheck)
                {
                    //如果这是一个项目变量，除了尝试查找符合的 id 之外，还应该查找 uid ，因为有可能 uid 是后来填写的
                    string tou, idORuid;
                    if(getItemIDorUID(BL,out tou,out idORuid))
                    {
                        DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Item WHERE id = " + idORuid, Config.Instance.Path, null, false);
                        if(dt == null)
                            dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Item WHERE UID LIKE '" + idORuid + "'", Config.Instance.Path);
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                unCheck = false;
                                switch (tou)
                                {
                                    case "item":
                                    case "i":
                                        unCheck = false;
                                        repath = repath.Replace("%" + BL + "%", UseExPand(dt.Rows[0]["value"].ToString(), DBPath));
                                        break;
                                    case "item32":
                                    case "i32":
                                        unCheck = false;
                                        repath = repath.Replace("%" + BL + "%", UseExPand(dt.Rows[0]["IV_x86"].ToString(), DBPath));
                                        break;
                                    case "item64":
                                    case "i64":
                                        unCheck = false;
                                        repath = repath.Replace("%" + BL + "%", UseExPand(dt.Rows[0]["IV_x64"].ToString(), DBPath));
                                        break;
                                    case "itemworkpath":
                                    case "iw":
                                        unCheck = false;
                                        repath = repath.Replace("%" + BL + "%", UseExPand(dt.Rows[0]["workingDirectory"].ToString(), DBPath));
                                        break;
                                    case "itemarguments":
                                    case "ia":
                                        unCheck = false;
                                        repath = repath.Replace("%" + BL + "%", UseExPand(dt.Rows[0]["arguments"].ToString(), DBPath));
                                        break;
                                    case "itempath":
                                    case "ip":
                                        unCheck = false;
                                        repath = repath.Replace("%" + BL + "%", UseExPand(dt.Rows[0]["iPath"].ToString(), DBPath));
                                        break;
                                    case "itemdata":
                                    case "id":
                                        unCheck = false;
                                        if (dt.Rows[0]["iPath"].ToString().Replace(" ","") != "")
                                            repath = repath.Replace("%" + BL + "%", UseExPand(dt.Rows[0]["iPath"].ToString(), DBPath));
                                        else
                                        {
                                            Config config = Config.getInstance(DBPath);
                                            if (config != null)
                                                repath = repath.Replace("%" + BL + "%", config.dataFolderExpand + "\\" + dt.Rows[0]["dataFolderName"].ToString());
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region ZIKU所在目录
                if (unCheck)
                {
                    if (BL.ToUpper() == "ZIKU")
                    {
                        repath = repath.Replace("%" + BL + "%", Program.ZIKUPATH);
                        unCheck = false;
                    }
                }
                #endregion

                #region ZIKU所在磁盘盘符
                if (unCheck)
                {
                    if (BL.ToUpper() == "ROOT")
                    {
                        repath = repath.Replace("%" + BL + "%", Program.ZIKUPATH.Split(Convert.ToChar("\\"))[0]);
                        unCheck = false;
                    }
                }
                #endregion

                #region 未被引用的内部变量UID
                if (unCheck)
                {
                    DataTable dtUID = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Variable WHERE UID LIKE '" + BL + "'", Config.Instance.Path);
                    if (dtUID.Rows.Count != 0)
                    {
                        repath = repath.Replace("%" + BL + "%", UseExPand(dtUID.Rows[0]["path"].ToString(), Config.Instance.Path));
                        unCheck = false;
                    }
                }
                #endregion

                #region 未被引用的全局变量UID
                if (unCheck)
                {
                    if (BL.ToUpper().StartsWith("G-")) {
                        DataTable dtUID = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Variable WHERE UID LIKE '" + BL.Remove(0,2) + "'", Program.zikuSettingPath);
                        if (dtUID.Rows.Count != 0)
                        {
                            repath = repath.Replace("%" + BL + "%", ExPandG(dtUID.Rows[0]["path"].ToString()));
                            unCheck = false;
                        }
                    }
                }
                #endregion

                #region 数据库变量
                if (unCheck)
                {
                    if (BL.ToLower().StartsWith("ovar$"))
                    {
                        unCheck = false;
                        string varID = BL.Remove(0, 5);
                        if (varID != "")
                        {
                            Variable var = Variable.getIDVariable(varID, DBPath);
                            if (var != null)
                                repath = repath.Replace("%" + BL + "%", UseExPand(var.path, DBPath));
                        }
                    }
                }
                #endregion

                //系统变量
                if (unCheck)
                    repath = Environment.ExpandEnvironmentVariables(repath);

                varMatch = varMatch.NextMatch();
            }
    
            repath = upPath(repath);
            return repath;
        }


        /// <summary>
        /// 提升路径层级
        /// </summary>
        public static string upPath(string path)
        {
            Match match = Regex.Match(path, @"\[\.+\\.*?\\\]");
            while (match.Success)
            {
                string upText = (Regex.Match(match.Groups[0].Value, @"^\[\.+\\")).Groups[0].Value;
                string rePath = match.Groups[0].Value.Replace(upText, "").Replace("\\]", "");

                upText = upText.Replace("\\", "").Replace("[", "");

                string[] pSP = rePath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                int pathCoun = pSP.Length - upText.Length;

                if (pathCoun > 0)
                {
                    rePath = "";
                    for (int i = 0; i < pathCoun; i++)
                    {
                        if (i == 0)
                            rePath += pSP[i];
                        else
                            rePath += "\\" + pSP[i];
                    }
                }
                path = path.Replace(match.Groups[0].Value, rePath);//将表达式替换
                match = match.NextMatch();
            }
            return path;
        }
        #endregion

        /// <summary>
        /// 返回图标Image数据流(ZIKU)
        /// </summary>
        /// <param name="IconPath">图标文件位置</param>
        /// <param name="FilePath">项目主值</param>
        /// <param name="itemID">项目ID，用来查找缓存</param>
        /// <returns></returns>
        public static Image IconOrFile(string IconPath, string FilePath, string itemID)
        {         
            Image reImage = Properties.Resources.noicon.ToBitmap();
            if (IconPath == null) IconPath = "";
            IconPath = IconPath.ToLower();
            //启用了图标缓存
            if (itemID != null)
            {                
                System.IO.Directory.CreateDirectory(Config.Instance.Path + ".cache\\icon");

                //缓存图标是否存在
                if (System.IO.File.Exists(Config.Instance.Path + ".cache\\icon\\" + itemID + ".png"))
                {
                    byte[] bytes = File.ReadAllBytes(Config.Instance.Path + ".cache\\icon\\" + itemID + ".png");
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }

            //没有文件，文件夹，图标文件也不存在
            if (System.IO.File.Exists(IconPath) == false && System.IO.File.Exists(FilePath) == false && System.IO.Directory.Exists(FilePath) == false && IconPath == "")
                return reImage;

            //图标文件存在
            if (System.IO.File.Exists(IconPath))
            {
                try
                {
                    reImage = Image.FromFile(IconPath);
                    Bitmap objBitmap = new Bitmap(reImage, new Size(32, 32));
                    reImage = objBitmap;

                    if (itemID != null && !System.IO.File.Exists(Config.Instance.Path + ".cache\\icon\\" + itemID + ".png"))
                        reImage.Save(Config.Instance.Path + ".cache\\icon\\" + itemID + ".png");
                    return reImage;
                }
                catch { }
            }

            //文件存在
            if (System.IO.File.Exists(FilePath))
            {
                reImage = Icon.ExtractAssociatedIcon(FilePath).ToBitmap();
                if (itemID != null && !System.IO.File.Exists(Config.Instance.Path + ".cache\\icon\\" + itemID + ".png"))
                    reImage.Save(Config.Instance.Path + ".cache\\icon\\" + itemID + ".png");
                return reImage;
            }


            return reImage;
        }

        #region Run 执行程序
        /// <summary>
        /// 运行程序或执行命令
        /// </summary>
        /// <param name="path">程序或命令</param>
        public static void run(Item i)
        {
            Thread workerThread = new Thread(new Run(i,i.onAdmin).DoWork);
            workerThread.Start();
        }

        /// <summary>
        /// 运行程序或执行命令
        /// </summary>
        /// <param name="path">程序或命令</param>
        public static void run(Item i,bool onAdmin)
        {
            Thread workerThread = new Thread(new Run(i,onAdmin).DoWork);
            workerThread.Start();
        }

        /// <summary>
        /// 运行小抄
        /// </summary>
        /// <param name="xc"></param>
        public static void run(XiaoChao xc)
        {
            if (xc == null) return;
            if (xc.copyIntroduce)
            {
                Clipboard.SetDataObject(xc.introduce);
                MainForm.Instance.showNotifyTip(xc.name, "已经复制该小抄的介绍到剪贴板。");
            }              
            else
            {
                Thread workerThread = new Thread(new Run(xc.valueExpand, xc.argumentsExpand).DoWork);
                workerThread.Start();
            }
        }

        public static void runXC(string xcID)
        {
            XiaoChao xc = XiaoChao.getInstance(xcID);
            if (xc != null) run(xc);
        }

        //Run 类，用来做多线程
        class Run
        {
            Item runItem;
            string runValue, runArguments;
            bool onAdmin = false;

            public Run(Item item,bool admin)
            {
                runItem = item;
                onAdmin = admin;
            }

            public Run(string value,string arguments)
            {
                runValue = value;
                runArguments = arguments;
            }

            /// <summary>
            /// 执行run
            /// </summary>
            public void DoWork()
            {
                if (runItem != null)
                {
                    if (Environment.Is64BitOperatingSystem)
                    {
                        //64 //v  //32
                        bool runOK = false;
                        string fPath = "";
                        if (runItem.IV_x64Expand != "")
                        {
                            runOK = running(runItem.IV_x64Expand, runItem.argumentsExpand, runItem.workingDirectoryExpand,onAdmin);
                            if (!runOK)
                            {
                                fPath += "“" + runItem.IV_x64Expand + "”";
                            }
                        }

                        if (!runOK)
                        {
                            if (runItem.valueExpand != "")
                            {
                                runOK = running(runItem.valueExpand, runItem.argumentsExpand, runItem.workingDirectoryExpand, onAdmin);
                                if (!runOK)
                                {
                                    fPath += "“"+runItem.valueExpand+"”";
                                }
                            }
                        }

                        if (!runOK)
                        {
                            if (runItem.IV_x86Expand != "")
                            {
                                runOK = running(runItem.IV_x86Expand, runItem.argumentsExpand, runItem.workingDirectoryExpand, onAdmin);
                                if (!runOK)
                                {
                                    fPath += "“" + runItem.IV_x86Expand + "”";
                                }
                            }
                        }

                        if (fPath != "")
                            OLEREO.Control.PushForm.pushInfo(runItem.name + " 启动失败", "项目值：" +fPath + "无效，请检查是否填写正确。");
                    }
                    else
                    {
                        bool runOK = false;
                        string fPath = "";
                        if (runItem.IV_x86Expand != "")
                        {
                            runOK = running(runItem.IV_x86Expand, runItem.argumentsExpand, runItem.workingDirectoryExpand, onAdmin);
                            if (!runOK)
                            {
                                fPath += "“" + runItem.IV_x86Expand + "”";
                            }
                        }

                        if (!runOK)
                        {
                            if (runItem.valueExpand != "")
                            {
                                runOK = running(runItem.valueExpand, runItem.argumentsExpand, runItem.workingDirectoryExpand, onAdmin);
                                if (!runOK)
                                {
                                    fPath += "“" + runItem.valueExpand + "”";
                                }
                            }
                        }
                        if (fPath != "")
                        OLEREO.Control.PushForm.pushInfo(runItem.name + " 启动失败", "项目值：" + fPath + "”无效，请检查是否填写正确。");
                    }
                }
                else
                {
                    if (!running(runValue, runArguments))
                    OLEREO.Control.PushForm.pushInfo("启动失败", "小抄主值“"+ runValue + "”无效，请检查是否填写正确。");
                }
            }

            public bool running(string path, string arguments, string workingDirectory = "", bool admin = false)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(path, arguments);
                        if (admin)
                            psi.Verb = "runas";
                        if (workingDirectory != "")
                        {
                            psi.WorkingDirectory = workingDirectory;
                        }
                        else
                        {
                            FileInfo pPath = new System.IO.FileInfo(path);
                            psi.WorkingDirectory = pPath.Directory.FullName;
                        }
                        System.Diagnostics.Process.Start(psi);
                    }
                    else
                        System.Diagnostics.Process.Start(path, arguments);
                    return true;
                }
                catch { return false; }
            }
        }
        #endregion

        /// <summary>
        /// 尝试创建目录，无法创建返回false，已经存在也会返回true
        /// </summary>
        /// <param name="folderPath">需要创建的目录路径值</param>
        /// <returns></returns>
        public static bool createItemDataFolder(string folderPath)
        {
            if (folderPath.Replace(" ", "") == "")
                return false;
            try
            {
                Directory.CreateDirectory(folderPath);
            }
            catch { }
            return Directory.Exists(folderPath);
        }

        public static void throwErro(string title,string value,string funPath,string erroInfo)
        {
            OLEREO.Control.EmailContact.erroReport("funPath:" +funPath+ "\r\nZIKUVER:" + Program.ZIKUVER+ "\r\nDBVER:" + DataBase.Config.Instance.version + "\r\nSystemVER:" + Environment.OSVersion.Version.ToString() + "\r\n\r\n" + erroInfo, title, value, false);
        }
    }
}

 

