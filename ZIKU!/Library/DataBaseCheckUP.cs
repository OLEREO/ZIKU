

using OLEREO.Library;
using System;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace ZIKU
{
    class DataBaseCheckUP
    {
        public static bool checkAndUpdateDB(string DBPath)
        {
            if (DBPath == null) return false;
            if (DBPath.Replace(" ", "") == "") return false;
            DBPath = System.Environment.ExpandEnvironmentVariables(DBPath);
            if (!System.IO.File.Exists(DBPath)) return false;

            if (!(SQLite.isEXISTS(DBPath, "Config", "version") && SQLite.isEXISTS(DBPath, "Item", "id") && SQLite.isEXISTS(DBPath, "Item", "arguments")))
                return false;
            #region 更新的命令
            DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM Config WHERE main = 'main'", DBPath);
            DataRow row = dt.Rows[0];
            string version = row["version"].ToString();//获取到版本信息
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + DBPath))
            {
                try
                {
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        bool isUpdate = false;
                        #region X.X.X.X
                        if (version == "X.X.X.X") //to  0.5.0.0
                        {
                            if (!isUpdate)
                            {
                                OLEREO.Control.PushForm.pushInfo("正在升级数据库", "升级数据库需要一定时间，界面会卡住，请耐心等候，不要强行关闭");
                                try { System.IO.File.Copy(DBPath, DBPath + " - " + version + ".mc", true); } catch { }
                            }
                            isUpdate = true;

                            //UPDATE 的命令必须一条接着一条执行  ，其他命令，可以使用  ; 符号
                            cmd.CommandText = "SQLITE";
                            cmd.ExecuteNonQuery();


                            version = "0.5.0.0";
                        }
                        #endregion

                        #region 0.4.50
                        if (version == "0.4.5.0") //to  0.5.0.0
                        {
                            if (!isUpdate) pushUPDB(version, DBPath);
                            isUpdate = true;

                            cmd.CommandText = "CREATE TABLE Category ( id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING, type STRING, C_ID STRING, I_ID STRING, nameF STRING);INSERT INTO Category ( id, name, type, C_ID, I_ID, nameF ) SELECT id, name, type, C_ID, I_ID,nameF FROM categoryInfo;DROP TABLE categoryInfo;CREATE TABLE sqlitestudio_temp_table AS SELECT * FROM config;DROP TABLE config;CREATE TABLE Config ( main STRING, name STRING, version STRING, dataFolder STRING, pCsort STRING);INSERT INTO Config ( main, name, version, dataFolder, pCsort ) SELECT main, name, version, itemDataFolder, pCsort FROM sqlitestudio_temp_table;DROP TABLE sqlitestudio_temp_table;CREATE TABLE Variable ( id INTEGER PRIMARY KEY AUTOINCREMENT, uid STRING, name STRING, path STRING);INSERT INTO Variable ( id, uid, name, path ) SELECT id, uuid, name, dPath FROM dir;DROP TABLE dir;";
                            cmd.ExecuteNonQuery();

                            DataTable dt2 = SQLite.ExecuteDataTable("SELECT * FROM Variable", DBPath);//遍历转换变量中的path
                            foreach (DataRow row2 in dt2.Rows)
                            {
                                cmd.CommandText = "UPDATE Variable SET uid = '" + row2["uid"].ToString().Replace("%", "").Replace("'", "''") + "',path = '" + row2["path"].ToString().Replace("%ml-", "%ovar$").Replace("'", "''") + "' WHERE id = " + row2["id"].ToString() + ";";
                                cmd.ExecuteNonQuery();
                            }

                            cmd.CommandText = "CREATE TABLE XiaoChao ( id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING, value STRING, arguments STRING, introduce STRING, searchAlias STRING, nameF STRING, itemID STRING);INSERT INTO XiaoChao ( id, name, value, arguments, introduce, searchAlias, nameF ) SELECT id, name, value, arguments, introduce, seKey, nameF FROM xc;DROP TABLE xc;CREATE TABLE sqlitestudio_temp_table AS SELECT * FROM item;DROP TABLE item;CREATE TABLE Item ( id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING, nameF STRING, value STRING, IV_x86 STRING, IV_x64 STRING, arguments STRING, workingDirectory STRING, version STRING, intro STRING, introduce STRING, CI_ID STRING, X_ID STRING, C_ID STRING, iPath STRING, icon STRING, type STRING, searchAlias STRING, homePage STRING, dataFolderName STRING, uPtD STRING);INSERT INTO Item ( id, name, nameF, value, IV_x86, IV_x64, arguments, workingDirectory, version, intro, introduce, CI_ID, X_ID, C_ID, iPath, icon, type, searchAlias, homePage, dataFolderName, uPtD ) SELECT id, name, nameF, value, IV_x86, IV_x64, arguments, workingDirectory, versions, intro, introduce, CI_ID, X_ID, C_ID, iPath, icon, type, seKey, homePage, itemDataFolderName, uPtD FROM sqlitestudio_temp_table;DROP TABLE sqlitestudio_temp_table;";
                            cmd.ExecuteNonQuery();

                            DataTable dt3 = SQLite.ExecuteDataTable("SELECT * FROM Item", DBPath);
                            foreach (DataRow item in dt3.Rows)//遍历转换项目中的value等，以及将项目的ID写入到小抄
                            {
                                string uPtD = "FALSE";

                                if (item["uPtD"].ToString() == "1")
                                {
                                    uPtD = "TRUE";
                                }

                                cmd.CommandText = "UPDATE Item SET uPtD = '" + uPtD
                                    + "',value = '" + item["value"].ToString().Replace("%ml-", "%ovar$").Replace("'", "''")
                                    + "',IV_x86 = '" + item["IV_x86"].ToString().Replace("%ml-", "%ovar$").Replace("'", "''")
                                    + "',IV_x64='" + item["IV_x64"].ToString().Replace("%ml-", "%ovar$").Replace("'", "''")
                                    + "',arguments = '" + item["arguments"].ToString().Replace("%ml-", "%ovar$").Replace("'", "''")
                                    + "',workingDirectory = '" + item["workingDirectory"].ToString().Replace("%ml-", "%ovar$").Replace("'", "''")
                                    + "',iPath = '" + item["iPath"].ToString().Replace("%ml-", "%ovar$").Replace("'", "''")
                                    + "' WHERE id = " + item["id"].ToString() + ";";
                                cmd.ExecuteNonQuery();
                                foreach (string xID in Tools.SplitString(item["X_ID"].ToString()))
                                {
                                    try
                                    {
                                        cmd.CommandText = "UPDATE XiaoChao SET itemID = '" + item["id"].ToString() + "' WHERE id = " + xID;
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch { }
                                }
                            }

                            DataTable dt4 = SQLite.ExecuteDataTable("SELECT * FROM XiaoChao", DBPath);
                            foreach (DataRow xc in dt4.Rows)//遍历转换小抄的 value 中的 变量
                            {
                                cmd.CommandText = "UPDATE XiaoChao SET value = '" + xc["value"].ToString().Replace("%ml-", "%ovar$").Replace("'", "''")
                                    + "',arguments= '" + xc["arguments"].ToString().Replace("%ml-", "%ovar$").Replace("'", "''") + "' WHERE id = " + xc["id"].ToString();
                                cmd.ExecuteNonQuery();
                            }
                            version = "0.5.0.0";
                        }
                        #endregion

                        #region 0.5.0.0
                        if (version == "0.5.0.0") //to  0.5.0.0
                        {
                            if (!isUpdate) pushUPDB(version, DBPath);
                            isUpdate = true;

                            DataTable itemDT = SQLite.ExecuteDataTable("SELECT * FROM Item", DBPath);
                            foreach (DataRow item in itemDT.Rows)
                            {
                                cmd.CommandText = "UPDATE Item SET value = '" + item["value"].ToString().Replace("%xm-", "%item-").Replace("%xmml-", "%itemPath-").Replace("'", "''")
                                    + "',IV_x86 = '" + item["IV_x86"].ToString().Replace("%xm-", "%item-").Replace("%xmml-", "%itemPath-").Replace("'", "''")
                                    + "',IV_x64 = '" + item["IV_x64"].ToString().Replace("%xm-", "%item-").Replace("%xmml-", "%itemPath-").Replace("'", "''")
                                    + "',arguments = '" + item["arguments"].ToString().Replace("%xm-", "%item-").Replace("%xmml-", "%itemPath-").Replace("'", "''")
                                    + "',workingDirectory = '" + item["workingDirectory"].ToString().Replace("%xm-", "%item-").Replace("%xmml-", "%itemPath-").Replace("'", "''")
                                    + "',iPath = '" + item["iPath"].ToString().Replace("%xm-", "%item-").Replace("%xmml-", "%itemPath-").Replace("'", "''")
                                    + "' WHERE id = " + item["id"].ToString();
                                cmd.ExecuteNonQuery();
                            }
                            DataTable configDT = SQLite.ExecuteDataTable("SELECT * FROM Config", DBPath);
                            foreach (DataRow config in configDT.Rows)
                            {
                                cmd.CommandText = "UPDATE Config SET dataFolder = '" + config["dataFolder"].ToString().Replace("%xm-", "%item-").Replace("%xmml-", "%itemPath-").Replace("'", "''")
                                    + "' WHERE main = 'main'";
                                cmd.ExecuteNonQuery();
                            }
                            DataTable variableDT = SQLite.ExecuteDataTable("SELECT * FROM Variable", DBPath);
                            foreach (DataRow variable in variableDT.Rows)
                            {
                                cmd.CommandText = "UPDATE Variable SET path = '" + variable["path"].ToString().Replace("%xm-", "%item-").Replace("%xmml-", "%itemPath-").Replace("'", "''")
                                    + "' WHERE id = " + variable["id"].ToString();
                                cmd.ExecuteNonQuery();
                            }
                            DataTable xiaochaoDT = SQLite.ExecuteDataTable("SELECT * FROM XiaoChao", DBPath);
                            foreach (DataRow xiaochao in xiaochaoDT.Rows)
                            {
                                cmd.CommandText = "UPDATE XiaoChao SET value = '" + xiaochao["value"].ToString().Replace("%xm-", "%item-").Replace("%xmml-", "%itemPath-").Replace("'", "''")
                                    + "',arguments = '" + xiaochao["arguments"].ToString().Replace("%xm-", "%item-").Replace("%xmml-", "%itemPath-").Replace("'", "''")
                                    + "' WHERE id = " + xiaochao["id"].ToString();
                                cmd.ExecuteNonQuery();
                            }
                            version = "0.5.0.3";
                        }
                        #endregion

                        #region 0.5.0.3
                        if (version == "0.5.0.3") //to  0.5.0.0
                        {
                            if (!isUpdate) pushUPDB(version, DBPath);
                            isUpdate = true;

                            //UPDATE 的命令必须一条接着一条执行  ，其他命令，可以使用  ; 符号
                            cmd.CommandText = "CREATE TABLE Exclude ( id INTEGER PRIMARY KEY AUTOINCREMENT, value STRING);                            ";
                            cmd.ExecuteNonQuery();
                            version = "0.5.0.6";
                        }
                        #endregion


                        #region 0.5.0.6
                        if (version == "0.5.0.6") //to  0.5.0.0
                        {
                            if (!isUpdate) pushUPDB(version, DBPath);
                            isUpdate = true;

                            //UPDATE 的命令必须一条接着一条执行  ，其他命令，可以使用  ; 符号
                            cmd.CommandText = "ALTER TABLE XiaoChao ADD COLUMN copyIntroduce STRING;";
                            cmd.ExecuteNonQuery();
                            version = "0.5.0.7";
                        }
                        #endregion


                        #region 0.5.0.7
                        if (version == "0.5.0.7")
                        {
                            if (!isUpdate) pushUPDB(version, DBPath);
                            isUpdate = true;

                            DataTable cDT = SQLite.ExecuteDataTable("SELECT * FROM Category", DBPath);
                            foreach (DataRow cRow in cDT.Rows)
                            {
                                if (cRow["type"].ToString() == "1")
                                {
                                    foreach (string subID in Tools.SplitString(cRow["C_ID"].ToString()))
                                    {
                                        try
                                        {
                                            cmd.CommandText = "UPDATE Category SET C_ID = '" + cRow["id"].ToString() + "',type='2' WHERE id = " + subID + ";";
                                            cmd.ExecuteNonQuery();
                                        }
                                        catch { }
                                    }
                                }
                            }
                            version = "0.5.0.8";
                        }
                        #endregion



                        #region 0.5.0.8  to 0.6.1.0
                        if (version == "0.5.0.8")
                        {
                            if (!isUpdate) pushUPDB(version, DBPath);
                            isUpdate = true;

                            //将  type 改为 hideMain ，添加  hideSearch  UID
                            cmd.CommandText = "CREATE TABLE sqlitestudio_temp_table AS SELECT * FROM Item;";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "DROP TABLE Item;";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "CREATE TABLE Item ( id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING, nameF STRING, value STRING, IV_x86 STRING, IV_x64 STRING, arguments STRING, workingDirectory STRING, version STRING, intro STRING, introduce STRING, CI_ID STRING, X_ID STRING, C_ID STRING, iPath STRING, icon STRING, hideMain STRING, searchAlias STRING, homePage STRING, dataFolderName STRING, uPtD STRING, hideSearch STRING, UID STRING);";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "INSERT INTO Item ( id, name, nameF, value, IV_x86, IV_x64, arguments, workingDirectory, version, intro, introduce, CI_ID, X_ID, C_ID, iPath, icon, hideMain, searchAlias, homePage, dataFolderName, uPtD ) SELECT id, name, nameF, value, IV_x86, IV_x64, arguments, workingDirectory, version, intro, introduce, CI_ID, X_ID, C_ID, iPath, icon, type, searchAlias, homePage, dataFolderName, uPtD FROM sqlitestudio_temp_table;";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "DROP TABLE sqlitestudio_temp_table;";
                            cmd.ExecuteNonQuery();


                            DataTable cDT = SQLite.ExecuteDataTable("SELECT * FROM Item", DBPath);
                            StringBuilder sql0610 = new StringBuilder();
                            foreach (DataRow iRow in cDT.Rows)
                            {
                                string hideMS = "";
                                if (Tools.isHaveStr(iRow["hideMain"].ToString(), "main"))
                                    hideMS = ",hideMain = 'TRUE' ";
                                else
                                    hideMS = ",hideMain = 'FALSE' ";

                                if (Tools.isHaveStr(iRow["hideMain"].ToString(), "search"))
                                    hideMS += ",hideSearch = 'TRUE'";
                                else
                                    hideMS += ",hideSearch = 'FALSE'";

                                sql0610.Append("UPDATE Item SET UID = '" + iRow["id"].ToString() + "' " + hideMS + " WHERE id = " + iRow["id"].ToString() + ";");
                            }

                            cmd.CommandText = sql0610.ToString();
                            cmd.ExecuteNonQuery();
                            version = "0.6.1.0";
                        }
                        #endregion


                        #region 0.5.0.8  to 0.6.1.0
                        if (version == "0.6.1.0")
                        {
                            if (!isUpdate) pushUPDB(version, DBPath);
                            isUpdate = true;

                            //移除了 Item 的 uPtD
                            //Item 添加了 onAdmin
                            cmd.CommandText = "CREATE TABLE sqlitestudio_temp_table AS SELECT * FROM Item;";
                            // cmd.ExecuteNonQuery();
                            cmd.CommandText += "DROP TABLE Item;";
                            //  cmd.ExecuteNonQuery();
                            cmd.CommandText += "CREATE TABLE Item ( id INTEGER PRIMARY KEY AUTOINCREMENT, UID STRING, version STRING, name STRING, searchAlias STRING, homePage STRING, value STRING, IV_x86 STRING, IV_x64 STRING, arguments STRING, workingDirectory STRING, intro STRING, introduce STRING, CI_ID STRING, X_ID STRING, C_ID STRING, iPath STRING, icon STRING, dataFolderName STRING, hideMain STRING, hideSearch STRING, onAdmin STRING, nameF STRING);";
                            // cmd.ExecuteNonQuery();
                            cmd.CommandText += "INSERT INTO Item ( id, UID, version, name, searchAlias, homePage, value, IV_x86, IV_x64, arguments, workingDirectory, intro, introduce, CI_ID, X_ID, C_ID, iPath, icon, dataFolderName, hideMain, hideSearch, nameF ) SELECT id, UID, version, name, searchAlias, homePage, value, IV_x86, IV_x64, arguments, workingDirectory, intro, introduce, CI_ID, X_ID, C_ID, iPath, icon, dataFolderName, hideMain, hideSearch, nameF FROM sqlitestudio_temp_table;";
                            // cmd.ExecuteNonQuery();
                            cmd.CommandText += "DROP TABLE sqlitestudio_temp_table;";
                            cmd.ExecuteNonQuery();
                            version = "0.6.2.1";
                        }
                        #endregion



                        if (isUpdate)
                        {
                            cmd.CommandText = "UPDATE Config SET version = '" + version + "' WHERE main='main'"; ;
                            cmd.ExecuteNonQuery();
                        }
                        cmd.Dispose();
                        conn.Close();
                    }
                }
                catch
                {
                    conn.Close();
                    conn.Dispose();
                    return false;
                }
            }
            #endregion
            return true;
        }

        static void pushUPDB(string version, string DBPath)
        {
            try { System.IO.File.Copy(DBPath, DBPath + " - " + version + ".mc", true); } catch { }
            OLEREO.Control.PushForm.pushInfo("正在升级数据库", "升级数据库需要一定时间，程序会无响应，请耐心等候。如无出错，请不要强行关闭。\r\n数据库文件已经备份“" + DBPath + " - " + version + ".mc" + "”。\r\n如果更新失败，请暂时先退回旧版本使用。", 150, 350, 5000);
        }


        public static void checkAndUpdateSET()
        {
            bool isTrueDB = false;
            #region 这是从0.4.5.0的升级兼容代码
            if (SQLite.isEXISTS(Program.zikuSettingPath, "Config", "version", null, false) && SQLite.isEXISTS(Program.zikuSettingPath, "Config", "Database_ID", null, false) && SQLite.isEXISTS(Program.zikuSettingPath, "DB", "path", null, false))
                isTrueDB = true;
            else
            {
                if (SQLite.isEXISTS(Program.zikuSettingPath, "cinfo", "path", null, false) && SQLite.isEXISTS(Program.zikuSettingPath, "data", "Database_ID", null, false) && SQLite.isEXISTS(Program.zikuSettingPath, "data", "isIconCache", null, false))
                {
                    //0.4.5.0
                    try { System.IO.File.Copy(Program.zikuSettingPath, Program.zikuSettingPath + " - 0.4.5.0.set", true); } catch { }
                    SQLite.ExecuteNonQuery("CREATE TABLE DB ( id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING, path STRING);", Program.zikuSettingPath);
                    SQLite.ExecuteNonQuery("INSERT INTO DB ( id, name, path ) SELECT id, name, path FROM cinfo;", Program.zikuSettingPath);
                    SQLite.ExecuteNonQuery("DROP TABLE cinfo;", Program.zikuSettingPath);
                    SQLite.ExecuteNonQuery("CREATE TABLE Config ( main STRING, Database_ID STRING, version STRING, isHotKey STRING, hotKeyA STRING, hotKeyB STRING, isIconCache STRING, isSeHotKey STRING, seHotKeyA STRING, seHotKeyB STRING);", Program.zikuSettingPath);
                    SQLite.ExecuteNonQuery("INSERT INTO Config ( main, Database_ID, version, isHotKey, hotKeyA, hotKeyB, isIconCache, isSeHotKey, seHotKeyA, seHotKeyB ) SELECT main, Database_ID, versions, isHotKey, hotKeyA, hotKeyB, isIconCache, isSeHotKey, seHotKeyA, seHotKeyB FROM data;", Program.zikuSettingPath);
                    SQLite.ExecuteNonQuery("DROP TABLE data;", Program.zikuSettingPath);
                    SQLite.ExecuteNonQuery("CREATE TABLE Variable ( id INTEGER PRIMARY KEY AUTOINCREMENT, uid STRING, name STRING, path STRING);", Program.zikuSettingPath);
                    SQLite.ExecuteNonQuery("UPDATE Config SET version = '0.5.0.0' WHERE main='main';", Program.zikuSettingPath);
                    DataTable dt2 = SQLite.ExecuteDataTable("SELECT * FROM Config WHERE main='main'", Program.zikuSettingPath);
                    DataRow row2 = dt2.Rows[0];
                    if (row2["isHotKey"].ToString() == "1") SQLite.ExecuteNonQuery("UPDATE Config SET isHotKey = 'TRUE' WHERE main='main';", Program.zikuSettingPath);
                    if (row2["isSeHotKey"].ToString() == "1") SQLite.ExecuteNonQuery("UPDATE Config SET isSeHotKey = 'TRUE' WHERE main='main';", Program.zikuSettingPath);
                    if (row2["isIconCache"].ToString() == "1") SQLite.ExecuteNonQuery("UPDATE Config SET isIconCache = 'TRUE' WHERE main='main';", Program.zikuSettingPath);
                    isTrueDB = true;
                }
            }
            if (!isTrueDB)
            {
                MessageBox.Show("软件配置文件有误，程序无法启动。"
                    + "请手动删除现有配置文件后重试：\r\n" + Program.zikuSettingPath, "ZIKU! 启动失败");
                Environment.Exit(0);
            }
            #endregion

            #region 更新的命令
            DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM Config WHERE main = 'main'", Program.zikuSettingPath);
            DataRow row = dt.Rows[0];
            string version = row["version"].ToString();//获取到版本信息
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + Program.zikuSettingPath))
            {
                try
                {
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        bool isUpdate = false;
                        #region X.X.X.X
                        if (version == "X.X.X.X")
                        {
                            if (!isUpdate)
                                try { System.IO.File.Copy(Program.zikuSettingPath, Program.zikuSettingPath + " - " + version + ".set", true); } catch { }
                            isUpdate = true;

                            //UPDATE 的命令必须一条接着一条执行  ，其他命令，可以使用  ; 符号
                            cmd.CommandText = "SQLITE";
                            cmd.ExecuteNonQuery();


                            version = "newX.X.X.X";
                        }
                        #endregion

                        #region 0.5.0.0
                        if (version == "0.5.0.0")
                        {
                            if (!isUpdate)
                                try { System.IO.File.Copy(Program.zikuSettingPath, Program.zikuSettingPath + " - " + version + ".set", true); } catch { }
                            isUpdate = true;

                            //UPDATE 的命令必须一条接着一条执行  ，其他命令，可以使用  ; 符号
                            cmd.CommandText = "ALTER TABLE Config ADD COLUMN checkUP STRING;";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "UPDATE Config SET checkUP = 'TRUE' WHERE main='main';";
                            cmd.ExecuteNonQuery();

                            version = "0.5.0.5";
                        }
                        #endregion

                        #region 0.5.0.5  to 0.6.1.0
                        if (version == "0.5.0.5")
                        {
                            if (!isUpdate)
                                try { System.IO.File.Copy(Program.zikuSettingPath, Program.zikuSettingPath + " - " + version + ".set", true); } catch { }
                            isUpdate = true;

                            //将 isIconCache 改成了 searchMode
                            cmd.CommandText = "CREATE TABLE sqlitestudio_temp_table AS SELECT * FROM Config;";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "DROP TABLE Config;";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "CREATE TABLE Config ( main STRING, Database_ID STRING, version STRING, isHotKey STRING, hotKeyA STRING, hotKeyB STRING, searchMode STRING, isSeHotKey STRING, seHotKeyA STRING, seHotKeyB STRING, checkUP STRING);";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "INSERT INTO Config ( main, Database_ID, version, isHotKey, hotKeyA, hotKeyB, searchMode, isSeHotKey, seHotKeyA, seHotKeyB, checkUP ) SELECT main, Database_ID, version, isHotKey, hotKeyA, hotKeyB, isIconCache, isSeHotKey, seHotKeyA, seHotKeyB, checkUP FROM sqlitestudio_temp_table;";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "DROP TABLE sqlitestudio_temp_table;";
                            cmd.ExecuteNonQuery();

                            version = "0.6.1.0";
                        }
                        #endregion

                        if (isUpdate)
                        {
                            cmd.CommandText = "UPDATE Config SET version = '" + version + "' WHERE main='main'";
                            cmd.ExecuteNonQuery();
                        }
                        cmd.Dispose();
                        conn.Dispose();
                    }
                }
                catch (Exception e)
                {
                    conn.Dispose();
                    MessageBox.Show("软件配置文件有误，程序无法启动。"
                      + "请手动删除现有配置文件后重试：\r\n" + Program.zikuSettingPath + e.ToString(), "ZIKU! 启动失败");
                    Environment.Exit(0);
                }
            }
            #endregion
        }
    }
}
