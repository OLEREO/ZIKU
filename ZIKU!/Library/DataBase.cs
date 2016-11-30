using Microsoft.Win32;
using OLEREO.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ZIKU.DataBase
{
    #region Config
    /// <summary>
    /// 获取数据库的 Config 信息
    /// </summary>
    public class Config
    {
        private static Config _Instance;
        /// <summary>
        /// 当前使用的数据库Config实例，设为null会重新获取
        /// </summary>
        public static Config Instance { get { return _Instance; }

            set
            {
                if (value == null)
                {
                    if (_Instance != null)
                        _Instance = getInstance(_Instance.Path);
                    else
                        new Exception("Erro：在没有有效数据库信息时，重置当前数据库 Config 出现错误");
                }
                else _Instance = value;
            }
        }

        private Config() { }

        /// <summary>
        /// 获取数据库文件的信息，不存在返回null(函数内部会展开系统变量)
        /// </summary>
        /// <param name="DBPath">数据库的位置</param>
        /// <returns></returns>
        public static Config getInstance(string DBPath)
        {
            DBPath = Environment.ExpandEnvironmentVariables(DBPath);
            if (!File.Exists(DBPath)) return null;
            if (!ZIKU.DataBase.Options.checkAndUpdate(DBPath)) return null;
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Config WHERE main ='main'", System.Environment.ExpandEnvironmentVariables(DBPath));
            DataRow row = dt.Rows[0];
            Config c = new Config();
            c.Path = DBPath;
            c.name = row["name"].ToString();
            c.version = row["version"].ToString();
            c.dataFolder = row["dataFolder"].ToString();
            c.pCsort = row["pCsort"].ToString();
            return c;
        }


        private string _Path, _dbFolderPath, _name, _version, _dataFolder, _pCsort, _dataFolderExpand, _dataFolderShow;
        

        /// <summary>
        /// 数据文件的完整位置(已经展开系统变量)
        /// </summary>
        public string Path { get { return _Path; }private set { _Path = value; } }
        /// <summary>
        /// 数据库文件所在的目录
        /// </summary>
        public string dbFolderPath
        {
            get
            {
                if (_dbFolderPath == null)
                {
                    System.IO.FileInfo pPath = new System.IO.FileInfo(_Path);
                    _dbFolderPath = pPath.Directory.FullName;
                }
                return _dbFolderPath;
            }
        }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string name { get { return _name; }private set { _name = value; } }
        /// <summary>
        /// 数据库版本
        /// </summary>
        public string version { get { return _version; }private set { _version = value; } }

        /// <summary>
        /// 项目的总目录
        /// </summary>
        public string dataFolder { get { return _dataFolder; } private set { _dataFolder = value; } }
        /// <summary>
        /// 展开的项目资料目录
        /// </summary>
        public string dataFolderExpand
        {
            get
            {
                if (_dataFolderExpand == null)
                    _dataFolderExpand = myZiku.exPand(_dataFolder, _Path);
                return _dataFolderExpand;
            }
        }

        /// <summary>
        /// 展示的总资料目录
        /// </summary>
        public string dataFolderShow
        {
            get
            {
                if (_dataFolderShow == null)
                    _dataFolderShow = myZiku.variableToShow(_dataFolder, _Path);
                return _dataFolderShow;
            }
        }


        /// <summary>
        /// 父分类的排序
        /// </summary>
        public string pCsort { get { return _pCsort; }private set { _pCsort = value; } }

        /// <summary>
        /// 修改基本的数据库信息
        /// </summary>
        public static bool writeConfig(string name, string dataFolder, string DBPath)
        {
            if (!System.IO.File.Exists(System.Environment.ExpandEnvironmentVariables(DBPath))) return false;
            SQLite.ExecuteNonQuery("UPDATE Config SET name = '" + name.Replace("'", "''")
                + "',dataFolder = '" + dataFolder.Replace("'", "''")
                + "' WHERE main = 'main'", Environment.ExpandEnvironmentVariables(DBPath));
            if (Environment.ExpandEnvironmentVariables(DBPath) == Instance.Path)
                Instance = getInstance(Environment.ExpandEnvironmentVariables(DBPath));
            return true;
        }

        /// <summary>
        /// 更新父分类的排序
        /// </summary>
        /// <param name="pCsort"></param>
        public static void updatePCsort(string pCsort)
        {
            SQLite.ExecuteNonQuery("UPDATE Config SET pCsort = '" + pCsort + "' WHERE main='main'", Instance.Path);
            Instance.pCsort = pCsort;
        }

    }
    #endregion

    #region Item
    /// <summary>
    /// 当前数据库中的项目
    /// </summary>
    public class Item
    {
        private Item() { }
        private string _id, _name, _value, _arguments, _version, _intro, _introduce, _C_ID, _icon, _iPath, _X_ID, _searchAlias, _nameF
            , _workingDirectory, _CI_ID, _homePage, _dataFolderName, _IV_x86, _IV_x64,_UID;
        private bool _hideMain = false;
        private bool _hideSearch = false;
        private bool _onAdmin = false;

        private string _valueExpand, _argumentsExpand, _ipathExpand, _workingDirectoryExpand, _IV_x86Expand, _IV_x64Expand, _iconExpand;
        private string _valueShow, _argumentsShow, _ipathShow, _workingDirectoryShow, _IV_x86Show, _IV_x64Show, _iconShow;

        public string valueExpand { get { if (_valueExpand == null) _valueExpand = myZiku.exPand(_value,  Config.Instance.Path); return _valueExpand; } }
        public string argumentsExpand { get { if (_argumentsExpand == null) _argumentsExpand = myZiku.exPand(_arguments,  Config.Instance.Path); return _argumentsExpand; } }

        /// <summary>
        /// 展开的项目目录
        /// </summary>
        public string iPathExpand
        {
            get
            {
                if (_ipathExpand == null)
                    _ipathExpand = myZiku.exPand(_iPath,  Config.Instance.Path);
                return _ipathExpand;
            }
        }

        public string workingDirectoryExpand { get { if (_workingDirectoryExpand == null) _workingDirectoryExpand = myZiku.exPand(_workingDirectory,  Config.Instance.Path); return _workingDirectoryExpand; } }
        public string IV_x86Expand { get { if (_IV_x86Expand == null) _IV_x86Expand = myZiku.exPand(_IV_x86,  Config.Instance.Path); return _IV_x86Expand; } }
        public string IV_x64Expand { get { if (_IV_x64Expand == null) _IV_x64Expand = myZiku.exPand(_IV_x64,  Config.Instance.Path); return _IV_x64Expand; } }

        public string valueShow { get { if (_valueShow == null) _valueShow = myZiku.variableToShow(_value,  Config.Instance.Path); return _valueShow; } }
        public string argumentsShow { get { if (_argumentsShow == null) _argumentsShow = myZiku.variableToShow(_arguments,  Config.Instance.Path); return _argumentsShow; } }
        public string iPathShow { get { if (_ipathShow == null) _ipathShow = myZiku.variableToShow(_iPath,  Config.Instance.Path); return _ipathShow; } }
        public string workingDirectoryShow { get { if (_workingDirectoryShow == null) _workingDirectoryShow = myZiku.variableToShow(_workingDirectory,  Config.Instance.Path); return _workingDirectoryShow; } }
        public string IV_x86Show { get { if (_IV_x86Show == null) _IV_x86Show = myZiku.variableToShow(_IV_x86,  Config.Instance.Path); return _IV_x86Show; } }
        public string IV_x64Show { get { if (_IV_x64Show == null) _IV_x64Show = myZiku.variableToShow(_IV_x64,  Config.Instance.Path); return _IV_x64Show; } }

        /// <summary>
        /// 项目的ID
        /// </summary>
        public string id { get { return _id; }private set { _id = value; } }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get { return _name; } private set { _name = value; } }
        /// <summary>
        /// 主值
        /// </summary>
        public string value { get { return _value; } private set { _value = value; }  }
        /// <summary>
        /// 启动参数
        /// </summary>
        public string arguments { get { return _arguments; } private set { _arguments = value; } }
        /// <summary>
        /// 版本号
        /// </summary>
        public string version { get { return _version; } private set { _version = value; } }
        /// <summary>
        /// 简介
        /// </summary>
        public string intro { get { return _intro; } private set { _intro = value; } }
        /// <summary>
        /// 介绍
        /// </summary>
        public string introduce { get { return _introduce; } private set { _introduce = value; } }
        /// <summary>
        /// 归属分类
        /// </summary>
        public string C_ID { get { return _C_ID; } private set { _C_ID = value; } }
        /// <summary>
        /// 图标位置
        /// </summary>
        public string icon { get { return _icon; } private set { _icon = value; } }
        public string iconExpand { get { if (_iconExpand == null) _iconExpand = myZiku.exPand(_icon, Config.Instance.Path); return _iconExpand;} }
        public string iconShow{get{if (_iconShow == null)_iconShow = myZiku.variableToShow(_icon, Config.Instance.Path);return _iconShow;}}

        /// <summary>
        /// 是否在主页隐藏
        /// </summary>
        public bool isHideMain { get { return _hideMain; }private set { _hideMain = value; } }
        /// <summary>
        /// 是否在搜索界面隐藏
        /// </summary>
        public bool isHideSearch { get { return _hideSearch; }private set { _hideSearch = value; } }

        /// <summary>
        /// 项目目录
        /// </summary>
        public string iPath { get { return _iPath; } private set { _iPath = value; } }
        /// <summary>
        /// 小抄ID
        /// </summary>
        public string X_ID { get { return _X_ID; } private set { _X_ID = value; } }
        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string searchAlias { get { return _searchAlias; } private set { _searchAlias = value; } }
        /// <summary>
        /// 名称缩写
        /// </summary>
        public string nameF { get { return _nameF; } private set { _nameF = value; } }
        /// <summary>
        /// 工作目录
        /// </summary>
        public string workingDirectory { get { return _workingDirectory; } private set { _workingDirectory = value; } }
        /// <summary>
        /// 关联项目ID
        /// </summary>
        public string CI_ID { get { return _CI_ID; } private set { _CI_ID = value; } }
        /// <summary>
        /// 主页
        /// </summary>
        public string homePage { get { return _homePage; } private set { _homePage = value; } }
        /// <summary>
        /// 项目资料目录的名称(自动生成和修改)
        /// </summary>
        public string dataFolderName { get { return _dataFolderName; } private set { _dataFolderName = value; } }
        /// <summary>
        /// x86系统主值
        /// </summary>
        public string IV_x86 { get { return _IV_x86; } private set { _IV_x86 = value; } }
        /// <summary>
        /// x64系统主值
        /// </summary>
        public string IV_x64 { get { return _IV_x64; } private set { _IV_x64 = value; } }
        /// <summary>
        /// 用户自定义UID
        /// </summary>
        public string UID { get { return _UID; }private set { _UID = value; } }
        /// <summary>
        /// 是否开启Admin
        /// </summary>
        public bool onAdmin { get { return _onAdmin; } private set { _onAdmin = value; } }

        /// <summary>
        /// 根据主值是否存在文件，返回对于的 √ 或 ×
        /// </summary>
        public string existsText
        {
            get
            {
                if (!System.IO.File.Exists(valueExpand) && !System.IO.Directory.Exists(valueExpand)) return "×"; else return "√";
            }
        }

        /// <summary>
        /// 获取项目实例，不存在返回 null
        /// </summary>
        /// <param name="itemID">项目的ID</param>
        /// <param name="DBPath">指定数据库的位置</param>
        /// <returns></returns>
        public static Item getInstance(string itemID, string DBPath = null)
        {
            string path = DBPath;
            if (path == null)
                path = Config.Instance.Path;
            if (!System.IO.File.Exists(path)) return null;
            if (itemID == null) return null;
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Item WHERE id = " + itemID, path, null, false);
            if (dt == null) return null;
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];

            Item item = new Item();
            item.id = row["id"].ToString();
            item.name = row["name"].ToString();
            item.value = row["value"].ToString();
            item.arguments = row["arguments"].ToString();
            item.version = row["version"].ToString();
            item.intro = row["intro"].ToString();
            item.introduce = row["introduce"].ToString();
            item.C_ID = row["C_ID"].ToString();
            item.icon = row["icon"].ToString().Replace(" ", "") == "" ? "" : row["icon"].ToString();
            item.iPath = row["iPath"].ToString().Replace(" ", "") == "" ? "" : row["iPath"].ToString();
            item.X_ID = row["X_ID"].ToString();
            item.searchAlias = row["searchAlias"].ToString();
            item.nameF = row["nameF"].ToString();
            item.workingDirectory = row["workingDirectory"].ToString();
            item.CI_ID = row["CI_ID"].ToString();
            item.homePage = row["homePage"].ToString();
            item.dataFolderName = row["dataFolderName"].ToString();
            if (row["onAdmin"].ToString() == "TRUE") item.onAdmin = true;
            if (row["hideMain"].ToString() == "TRUE") item.isHideMain = true;
            if (row["hideSearch"].ToString() == "TRUE") item.isHideSearch = true;
            item.IV_x86 = row["IV_x86"].ToString();
            item.IV_x64 = row["IV_x64"].ToString();
            item.UID = row["UID"].ToString();
            return item;
        }

        /// <summary>
        /// 更新项目的关联项目
        /// </summary>
        public static void updateCI_ID(string itemiD, string oldCI_ID, string newCI_ID)
        {
            string[] chare = Tools.SearchDifferent(oldCI_ID, newCI_ID);
            addCI_ID(itemiD, chare[0]);
            delCI_ID(itemiD, chare[1]);
        }

        /// <summary>
        /// 彻底移除该项目(这里不会询问)
        /// </summary>
        /// <param name="ID"></param>
        public static void totalDelItem(string ID)
        {
            Item item = Item.getInstance(ID);
            if (item != null)
            {
                foreach (string cid in Tools.SplitString(item.C_ID))//从每一个所属分类中移除
                {
                    Category c = Category.getInstance(cid);
                    if (c != null)
                    {
                        string re = Tools.RemoveValue(c.I_ID, ID);
                        if (re != null)
                            Category.updateItem(c.id, re);
                    }
                }

                foreach (string iID in Tools.SplitString(item.CI_ID))//从每一个关联的项目中移除
                {
                    Item i = Item.getInstance(iID);
                    if (i != null)
                    {
                        string re = Tools.RemoveValue(i.CI_ID, ID);
                        if (re != null)
                            SQLite.ExecuteNonQuery("UPDATE Item SET CI_ID = '" + re + "' WHERE id = " + iID, Config.Instance.Path);
                    }
                }



                foreach (string xid in Tools.SplitString(item.X_ID)) //删除所有小抄
                {
                    XiaoChao xc = XiaoChao.getInstance(xid);
                    if (xc != null)
                        SQLite.ExecuteNonQuery("DELETE FROM XiaoChao WHERE id = " + xid,  Config.Instance.Path);
                }

                File.Delete( Config.Instance.Path + ".cache\\icon\\" + ID + ".png");     //删除缓存的图标


                //移除所有的变量引用
                Variable.removeVariableReference("%i-" + ID + "%", "%i-" + item.UID + "%");
                Variable.removeVariableReference("%item-" + ID + "%", "%item-" + item.UID + "%");
                Variable.removeVariableReference("%ITEM32-" + ID + "%", "%ITEM32-" + item.UID + "%");
                Variable.removeVariableReference("%i32-" + ID + "%", "%i32-" + item.UID + "%");
                Variable.removeVariableReference("%ITEM64-" + ID + "%", "%ITEM64-" + item.UID + "%");
                Variable.removeVariableReference("%i64-" + ID + "%", "%i64-" + item.UID + "%");
                Variable.removeVariableReference("%ITEMWORKPATH-" + ID + "%", "%ITEMWORKPATH-" + item.UID + "%");
                Variable.removeVariableReference("%iw-" + ID + "%", "%iw-" + item.UID + "%");
                Variable.removeVariableReference("%ITEMARGUMENTS-" + ID + "%", "%ITEMARGUMENTS-" + item.UID + "%");
                Variable.removeVariableReference("%ia-" + ID + "%", "%ia-" + item.UID + "%");
                Variable.removeVariableReference("%ITEMPATH-" + ID + "%", "%ITEMPATH-" + item.UID + "%");
                Variable.removeVariableReference("%ip-" + ID + "%", "%ip-" + item.UID + "%");
                Variable.removeVariableReference("%ITEMDATA-" + ID + "%", "%ITEMDATA-" + item.UID + "%");
                Variable.removeVariableReference("%id-" + ID + "%", "%id-" + item.UID + "%");

                SQLite.ExecuteNonQuery("DELETE FROM Item WHERE id = " + ID,  Config.Instance.Path);
            }
        }

        /// <summary>
        /// 添加关联项目 (可以是“;”格式)
        /// </summary>
        public static bool addCI_ID(string itemID, string CI_ID)
        {
            Item item = Item.getInstance(itemID); if (item == null) return false;
            string newCI_ID = item.CI_ID;
            foreach (string addCIID in CI_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Item addItem = Item.getInstance(addCIID);
                if (addItem != null)
                {
                    string re = Tools.AddValue(addItem.CI_ID, itemID);
                    if (re != null)
                        SQLite.ExecuteNonQuery("UPDATE Item SET CI_ID = '" + re + "' WHERE id = " + addCIID,  Config.Instance.Path); //添加原始项目ID，写入到关联的项目中


                    string re2 = Tools.AddValue(newCI_ID, addCIID);
                    if (re2 != null) newCI_ID = re2;
                }
            }
            //将最终的新的结果写入到原始项目
            SQLite.ExecuteNonQuery("UPDATE Item SET CI_ID = '" + newCI_ID + "' WHERE id = " + itemID,  Config.Instance.Path);
            return true;
        }
        /// <summary>
        /// 移除关联项目 (可以是“;”格式)
        /// </summary>
        public static bool delCI_ID(string itemID, string CI_ID)
        {
            Item item = Item.getInstance(itemID); if (item == null) return false;
            string newCI_ID = item.CI_ID;
            foreach (string delCIID in CI_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Item delItem = Item.getInstance(delCIID);
                if (delItem != null)
                {
                    string re = Tools.RemoveValue(delItem.CI_ID, itemID);
                    if (re != null)
                        SQLite.ExecuteNonQuery("UPDATE Item SET CI_ID = '" + re + "' WHERE id = " + delCIID,  Config.Instance.Path); //添加原始项目ID，写入到关联的项目中

                    string re2 = Tools.RemoveValue(newCI_ID, delCIID);
                    if (re2 != null) newCI_ID = re2;
                }
            }
            //将最终的新的结果写入到原始项目
            SQLite.ExecuteNonQuery("UPDATE Item SET CI_ID = '" + newCI_ID + "' WHERE id = " + itemID,  Config.Instance.Path);
            return true;
        }

    }
    #endregion

    #region Category
    public class Category
    {
        private Category() { }
        private string _id, _name, _type, _C_ID, _I_ID;
        public string id { get { return _id; } }
        public string name { get { return _name; } }
        /// <summary>
        /// 分类的类别 1：父分类  2：子分类
        /// </summary>
        public string type { get { return _type; } }
        /// <summary>
        /// 关联的分类，当类型为1(父分类)，这里记录的是子分类ID组，2记录的是父分类ID
        /// </summary>
        public string C_ID { get { return _C_ID; } }
        public string I_ID { get { return _I_ID; } }

        /// <summary>
        /// 获取数据库中的分类信息，没有返回NULL
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static Category getInstance(string categoryID)
        {
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Category WHERE id = " + categoryID, Config.Instance.Path);
            if (dt == null) return null; if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            Category c = new Category();
            c._id = row["id"].ToString();
            c._name = row["name"].ToString();
            c._type = row["type"].ToString();
            c._C_ID = row["C_ID"].ToString();
            c._I_ID = row["I_ID"].ToString();
            return c;
        }

        /// <summary>
        /// 改写分类信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="C_ID"></param>
        /// <returns></returns>
        public static string writeCategory(string id, string name, string type, string C_ID)
        {
            SQLite.ExecuteNonQuery("UPDATE Category SET name='" + name.Replace("'", "''") + "', C_ID = '" + C_ID + "',type = '" + type + "' WHERE id = " + id,  Config.Instance.Path);
            return null;
        }

        /// <summary>
        /// 将子分类转换成为父分类
        /// </summary>
        /// <param name="subCID"></param>
        /// <returns></returns>
        public static bool switchStoP(string subCID)
        {
            Category category = Category.getInstance(subCID);
            if (category == null) return false;

            if (MessageBox.Show("确定将“" + category.name + "”从“子分类”转换到“父分类”吗？", "转换分类", MessageBoxButtons.OKCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return false;

            Category pc = Category.getInstance(category.C_ID);
            if (pc != null)
            {
                string re = Tools.RemoveValue(pc.C_ID, subCID);
                if (re != null)
                    SQLite.ExecuteNonQuery("UPDATE Category SET C_ID = '" + re + "' WHERE id = " + pc.id,  Config.Instance.Path);
            }
            SQLite.ExecuteNonQuery("UPDATE Category SET C_ID = '',type = '1' WHERE id = " + subCID,  Config.Instance.Path);
            Config.updatePCsort(Config.Instance.pCsort + ";" + subCID);
            return true;
        }

        /// <summary>
        /// 移除分类
        /// </summary>
        /// <param name="Cid"></param>
        public static bool removeCategory(string Cid)
        {
            Category category = Category.getInstance(Cid);

            DialogResult re = MessageBox.Show("确定要删除“" + category.name + "”分类吗？\r\n\r\n注意，删除该分类不会导致该分类下的项目被删除", "确定删除该分类吗？", MessageBoxButtons.OKCancel);
            if (re == DialogResult.Cancel)
                return false;

            if (category.type != "2")//这是父分类
            {
                //是否有子分类（根据C_ID长度判定）
                if (category.C_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Length != 0)
                {
                    DialogResult isDelSub = MessageBox.Show("该分类下含有一个或多个子分类，请问是否保留这些子分类(转换成为父分类)？", "该分类包含有子分类", MessageBoxButtons.YesNoCancel);
                    if (isDelSub == DialogResult.Cancel)
                        return false;

                    //将所有子分类转移成为父分类
                    if (isDelSub == DialogResult.Yes)
                    {
                        string pCsort = Config.Instance.pCsort;
                        foreach (string subID in category.C_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            Category sub = Category.getInstance(subID);
                            if (sub != null)
                            {
                                Category.writeCategory(sub.id, sub.name, "1", "");
                                pCsort += ";" + sub.id + ";";
                            }
                        }
                        string re2 = Tools.RemoveValue(pCsort, Cid);
                        if (re2 != null)
                            Config.updatePCsort(re2);
                        else Config.updatePCsort(pCsort);
                    }
                    else
                    {
                        //将所有子分类也删除
                        try
                        {
                            foreach (string subID in category.C_ID.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                SQLite.ExecuteNonQuery("DELETE FROM Category WHERE id = " + subID, Config.Instance.Path);
                            }
                        }
                        catch { }
                    }
                }
            }
            else
            {
                //这是子分类
                Category pCategory = getInstance(category.C_ID);
                string newC_ID = Tools.RemoveValue(pCategory.C_ID, category.id);
                if (newC_ID != null)
                    writeCategory(pCategory.id, pCategory.name, "1", newC_ID);
            }
            SQLite.ExecuteNonQuery("DELETE FROM Category WHERE id = " + category.id, Config.Instance.Path);
            Config.Instance = null;
            return true;
        }
        /// <summary>
        /// 重命名分类，失败返回null，成功返回新的名称
        /// </summary>
        /// <param name="Cid">需要修改的名称</param>
        /// <returns></returns>
        public static string reName(string Cid)
        {
            Category c = Category.getInstance(Cid);
            if (c == null) return null;
            string re = Tools.InputBox("修改分类名称", "输入新的分类名称：", c.name);
            if (re == null) return null;
            SQLite.ExecuteNonQuery("UPDATE Category SET name = '" + re.Replace("'", "''") + "', nameF = '" + PinYinConverter.GetFirst(re).Replace("'", "''") + "' WHERE id = " + Cid,  Config.Instance.Path);
            return re;
        }


        /// <summary>
        /// 更新分类的项目(排序)
        /// </summary>
        /// <param name="Cid">分类的ID</param>
        /// <param name="itemSort">排序后的项目id组</param>
        public static void updateItem(string Cid, string itemSort)
        {
            SQLite.ExecuteNonQuery("UPDATE Category SET I_ID = '" + itemSort + "' WHERE id = " + Cid, Config.Instance.Path);
        }

        /// <summary>
        /// 新建一个分类
        /// </summary>
        /// <param name="name">分类的名称</param>
        /// <param name="type">1:父分类 2：子分类</param>
        public static int addNewCategory(string name, string type, string C_ID = "")
        {
            int re = SQLite.ExecuteNonQuery("INSERT INTO Category (name,type,C_ID,nameF) values('" + name.Replace("'", "''") + "','" + type + "','" + C_ID + "','" + PinYinConverter.GetFirst(name).Replace("'", "''") + "')", Config.Instance.Path);
            if (type == "2")
            {
                Category pc = getInstance(C_ID);
                if (pc != null)
                    SQLite.ExecuteNonQuery("UPDATE Category SET C_ID = '" + Tools.AddValue(pc.C_ID, re.ToString()) + "' WHERE id = " + pc.id, Config.Instance.Path);
            }
            else
                Config.updatePCsort(Config.Instance.pCsort + ";" + re);
            return re;
        }

        /// <summary>
        /// 添加新的项目到分类中
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public static bool addItem(string CategoryID, string ItemID)
        {
            Category c = getInstance(CategoryID);
            if (c == null) return false;
            string re = OLEREO.Library.Tools.AddValue(c.I_ID, ItemID);
            if (re != null)
                OLEREO.Library.SQLite.ExecuteNonQuery("UPDATE Category SET I_ID = '" + re + "' WHERE id = " + CategoryID,  Config.Instance.Path);
            return true;
        }
        /// <summary>
        /// 从分类中移除指定的项目ID
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public static bool removeItem(string CategoryID, string ItemID)
        {
            Category c = getInstance(CategoryID);
            Item item = Item.getInstance(ItemID);
            if (c == null || item == null) return false;
            string re = OLEREO.Library.Tools.RemoveValue(c.I_ID, ItemID);
            if (re != null)
                SQLite.ExecuteNonQuery("UPDATE Category SET I_ID = '" + re + "' WHERE id = " + CategoryID,  Config.Instance.Path);
            string re2 = Tools.RemoveValue(item.C_ID, CategoryID);
            if (re2 != null)
                SQLite.ExecuteNonQuery("UPDATE Item SET C_ID = '" + re2 + "' WHERE id = " + ItemID,  Config.Instance.Path);
            return true;
        }
    }
    #endregion

    #region XiaoChao
    public class XiaoChao
    {
        private XiaoChao() { }
        private string _id, _name, _value, _arguments, _introduce, _searchAlias, _itemID;
        private bool _copyIntroduce = false;
        /// <summary>
        /// 小抄的ID
        /// </summary>
        public string id { get { return _id; } }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get { return _name; } }
        /// <summary>
        /// 主值
        /// </summary>
        public string value { get { return _value; } }
        /// <summary>
        /// 启动参数(save)
        /// </summary>
        public string arguments { get { return _arguments; } }
        /// <summary>
        /// 介绍
        /// </summary>
        public string introduce { get { return _introduce; } }
        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string searchAlias { get { return _searchAlias; } }
        /// <summary>
        /// 所属的项目ID
        /// </summary>
        public string itemID { get { return _itemID; } }
        /// <summary>
        /// 该小抄是否只是复制介绍
        /// </summary>
        public bool copyIntroduce { get { return _copyIntroduce; } }
        /// <summary>
        /// 根据主值是否存在文件，返回对于的 √ 或 ×
        /// </summary>
        public string existsText
        {
            get
            {
                if (!System.IO.File.Exists(valueExpand) && !System.IO.Directory.Exists(valueExpand)) return "×"; else return "√";
            }
        }
        private string _valueExpand, _valueShow, _argumentsExpand, _argumentsShow;
        public string valueExpand { get { if (_valueExpand == null) _valueExpand = myZiku.exPand(_value,  Config.Instance.Path); return _valueExpand; } }
        public string valueShow { get { if (_valueShow == null) _valueShow = myZiku.variableToShow(_value, Config.Instance.Path); return _valueShow; } }
        public string argumentsExpand { get { if (_argumentsExpand == null) _argumentsExpand = myZiku.exPand(_arguments,  Config.Instance.Path); return _argumentsExpand; } }
        public string argumentsShow { get { if (_argumentsShow == null) _argumentsShow = myZiku.variableToShow(_arguments,  Config.Instance.Path); return _argumentsShow; } }

        /// <summary>
        /// 获取小抄类实例
        /// </summary>
        /// <param name="xcID"></param>
        /// <returns></returns>
        public static XiaoChao getInstance(string xcID)
        {
            DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM XiaoChao WHERE id = " + xcID,  Config.Instance.Path);
            if (dt == null) return null;
            if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            XiaoChao xc = new XiaoChao();
            xc._id = xcID;
            xc._name = row["name"].ToString();
            xc._introduce = row["introduce"].ToString();
            xc._value = row["value"].ToString();
            xc._arguments = row["arguments"].ToString();
            xc._searchAlias = row["searchAlias"].ToString();
            xc._itemID = row["itemID"].ToString();
            if (row["copyIntroduce"].ToString() == "TRUE") xc._copyIntroduce = true;
            return xc;
        }

        /// <summary>
        /// 写入小抄信息
        /// </summary>
        /// <param name="xcID">小抄的ID，null则会新建</param>
        /// <param name="itemID">只有当ID为null时才会生效</param>
        /// <returns></returns>
        public static bool writeXiaoChao(ref string xcID, string name, string value, string arguments, string introduce, string searchAlias, string itemID, bool copyIntroduce)
        {

            if (name.Replace(" ", "") == "")
            {
                System.Windows.Forms.MessageBox.Show("不管怎么说，名字还是要起一个的。", "名称不能为空");
                return false;
            }


            string itemIDup = "";
            if (xcID == null)
            {
                Item i = Item.getInstance(itemID);
                if (i == null) return false;
                itemIDup = "',itemID = '" + itemID;
                xcID = SQLite.ExecuteNonQuery("INSERT INTO XiaoChao (name) values('新的小抄')",  Config.Instance.Path).ToString();
                SQLite.ExecuteNonQuery("UPDATE Item SET X_ID = '" + i.X_ID + ";" + xcID + "' WHERE id = " + itemID,  Config.Instance.Path);
            }

            SQLite.ExecuteNonQuery("UPDATE XiaoChao SET name = '" + name.Replace("'", "''")
                + "',value = '" + myZiku.variableToSave(value,  Config.Instance.Path).Replace("'", "''")
                + "',arguments = '" + myZiku.variableToSave(arguments,  Config.Instance.Path).Replace("'", "''")
                + "',introduce = '" + introduce.Replace("'", "''")
                + "',searchAlias = '" + searchAlias.Replace("'", "''")
                + "',nameF = '" + PinYinConverter.GetFirst(name).Replace("'", "''")
                + itemIDup
                   + "',copyIntroduce = '" + copyIntroduce.ToString().ToUpper()
                + "' WHERE id = " + xcID,  Config.Instance.Path);
            return true;
        }

        /// <summary>
        /// 删除小抄
        /// </summary>
        /// <param name="xID">小抄的ID</param>
        /// <returns></returns>
        public static bool delXiaoChao(string xID)
        {
            XiaoChao xc = getInstance(xID);
            if (xc == null) return false;
            Item i = Item.getInstance(xc.itemID);
            if (i != null)
            {
                string re = Tools.RemoveValue(i.X_ID, xID);
                if (re != null)
                    SQLite.ExecuteNonQuery("UPDATE Item SET X_ID = '" + re + "' WHERE id = " + i.id,  Config.Instance.Path);
            }
            SQLite.ExecuteNonQuery("DELETE FROM XiaoChao WHERE id = " + xID,  Config.Instance.Path);
           
            return true;
        }
    }
    #endregion

    #region Options
    public class Options
    {
        /// <summary>
        /// 设置/切换当前使用的数据库文件
        /// </summary>
        public static bool setUseDB(string DBid)
        {
            SettingDataBase.DB db = SettingDataBase.DB.getInstance(DBid);
            string path = Environment.ExpandEnvironmentVariables(db.path);
            if (!File.Exists(path)) return false;
            Config config = Config.getInstance(path);
            if (config == null) return false;
            Config.Instance = config;
            SettingDataBase.Config.Instance = null;
            SQLite.ExecuteNonQuery("UPDATE Config SET Database_ID = '" + DBid + "' WHERE main='main'", Program.zikuSettingPath);

            //将当前使用的数据库写入到注册表中
           // string dbPath =  Config.Instance.Path;
          //  if (Config.Instance.Path.StartsWith(".\\"))
              //  dbPath = Program.ZIKUPATH + Config.Instance.Path.Remove(0, 1);
            //
         //   RegistryKey key = Registry.CurrentUser;
         //   RegistryKey software = key.CreateSubKey("Software\\OLEREO\\ZIKU!");
         //   software.SetValue(@"dbPath", dbPath, RegistryValueKind.String);
            return true;
        }

        /// <summary>
        /// 创建数据库文件，成功返回路径，否则返回null
        /// </summary>
        /// <returns></returns>
        public static string CreateDB()
        {
            string dbName = Tools.InputBox("新建一个数据库", "请输入数据库名称：");
            if (dbName == null)
                return null;

            int newSequence = 1;
            bool hav = System.IO.File.Exists(Program.ZIKUPATH + @"\Data\" + newSequence.ToString() + ".mc");

            while (hav)
            {
                newSequence++;
                hav = System.IO.File.Exists(Program.ZIKUPATH + @"\Data\" + newSequence.ToString() + ".mc");
            }

            byte[] Save = global::ZIKU.Properties.Resources.DB;
            FileStream fsObj = new FileStream(Program.ZIKUPATH + @"\Data\" + newSequence + ".mc", FileMode.CreateNew);
            fsObj.Write(Save, 0, Save.Length);
            fsObj.Close();


            SQLite.ExecuteNonQuery("UPDATE Config SET name = '" + dbName.Replace("'", "''") + "' WHERE main = 'main';", Program.ZIKUPATH + @"\Data\" + newSequence + ".mc");
            #region 需要写入的介绍
            string i0intro = @"右键点击“列表”可以进行“添加新的项目”等操作，点击项目则可以对项目进行一些操作。

主值是执行项目时所运行的命令，主值可以是文件、路径或者系统命令。

界面的右边是该项目的“子信息”，右键点击将可以获得相应的操作。

在主界面上，过长的介绍可以使用鼠标滚轮或拖动右边的滚动条查看。




通过右下角的“菜单按钮”可以进行“分类”的管理等操作。

记住，ZIKU!的默认搜索快捷键是“ALT + D”，界面显隐快捷键是“ALT + F”，它们都可以通过“设置”进行修改。";

            string i1intro = @"双击这个项目在64位系统下会打开 “ZIKU!” 所在目录，而在32位系统下则会打开回收站。

在搜索界面下，只有使用 “S”(所有) 搜索模式时，这个项目才会被搜索出来。";

            string x0intro = @"这是一条“小抄”

右键点击“子信息”列表，可以对相应的内容进行操作。";
            #endregion
            SQLite.ExecuteNonQuery("UPDATE Item SET version = '" + Program.ZIKUVER + "',introduce = '" + i0intro.Replace("'", "''") + "' WHERE id = 0;", Program.ZIKUPATH + @"\Data\" + newSequence + ".mc");
            SQLite.ExecuteNonQuery("UPDATE Item SET introduce = '" + i1intro.Replace("'", "''") + "' WHERE id = 1;", Program.ZIKUPATH + @"\Data\" + newSequence + ".mc");
            SQLite.ExecuteNonQuery("UPDATE XiaoChao SET introduce = '" + x0intro.Replace("'", "''") + "' WHERE id = 0;", Program.ZIKUPATH + @"\Data\" + newSequence + ".mc");
            return Program.ZIKUPATH + @"\Data\" + newSequence + ".mc";
        }

        /// <summary>
        /// 检查并升级数据库
        /// </summary>
        /// <param name="DBPath">数据库的路径(函数内会展开系统变量)</param>
        /// <returns></returns>
        public static bool checkAndUpdate(string DBPath)
        {
            return DataBaseCheckUP.checkAndUpdateDB(DBPath);
        }
    }
    #endregion
}


namespace ZIKU.SettingDataBase
{
    #region Config
    public class Config
    {
        private static Config _Instance;
        /// <summary>
        /// 设置为NULL则重置
        /// </summary>
        public static Config Instance {
            get {
                if (_Instance == null)
                    _Instance = new Config();
                return _Instance;
            }
            set
            {
                if (value == null)
                {
                    if (_Instance != null)
                        _Instance = new Config();
                    else
                        new Exception("Erro：在没有实例化配置库的情况下，尝试了重置配置信息");
                }
                else _Instance = value;                
            }
        }
        private Config()
        {
           Options.checkAndUpdate();
            DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM Config WHERE main = 'main'", Program.zikuSettingPath);
            DataRow row = dt.Rows[0];
            _Database_ID = row["Database_ID"].ToString();
            _version = row["version"].ToString();
            if (row["isHotKey"].ToString() == "TRUE") _isHotKey = true;
            _hotKeyA = row["hotKeyA"].ToString();
            _hotKeyB = row["hotKeyB"].ToString();
            if (row["isSeHotKey"].ToString() == "TRUE") _isSeHotKey = true;
            if (row["searchMode"].ToString() == "altMode") isAltMode = true;
            _seHotKeyA = row["seHotKeyA"].ToString();
            _seHotKeyB = row["seHotKeyB"].ToString();
            if (row["checkUP"].ToString() == "TRUE") _checkUP = true;
        }
        private string _Database_ID, _version, _hotKeyA, _hotKeyB, _seHotKeyA, _seHotKeyB;

        private bool _isHotKey = false; private bool _isSeHotKey; private bool _checkUP = false;private bool _isAltMode = false;
        /// <summary>
        /// 当前使用的数据库DBID
        /// </summary>
        public string DataBaseID { get { return _Database_ID; } }
        /// <summary>
        /// 数据库的版本
        /// </summary>
        public string version { get { return _version; } }
        /// <summary>
        /// 热键A
        /// </summary>
        public string hotKeyA { get { return _hotKeyA; } }
        /// <summary>
        /// 热键B
        /// </summary>
        public string hotKeyB { get { return _hotKeyB; } }
        /// <summary>
        /// 搜索热键A
        /// </summary>
        public string seHotKeyA { get { return _seHotKeyA; } }
        /// <summary>
        /// 搜索热键B
        /// </summary>
        public string seHotKeyB { get { return _seHotKeyB; } }
        /// <summary>
        /// 获取搜索窗口的模式是否为 ALT 模式
        /// </summary>
        public bool isAltMode { get { return _isAltMode; }private set { _isAltMode = value; } }
        /// <summary>
        /// 是否启用了热键
        /// </summary>
        public bool isHotKey { get { return _isHotKey; } }
        /// <summary>
        /// 是否启用了搜索热键
        /// </summary>
        public bool isSeHotKey { get { return _isSeHotKey; } }
        /// <summary>
        /// 是否启用了启动检查更新
        /// </summary>
        public bool checkUP { get { return _checkUP; } }

        /// <summary>
        /// 写入软件 Config 配置
        /// </summary>
        public static void writeConfig(bool isHotKey, string hotKeyA, string hotKeyB, bool isSeHotKey, string seHotKeyA, string seHotKeyB, bool checkUP)
        {
            SQLite.ExecuteNonQuery("UPDATE Config SET  isHotKey = '" + isHotKey.ToString().ToUpper()
                + "',hotKeyA='" + hotKeyA
                + "',hotKeyB='" + hotKeyB
                + "',isSeHotKey = '" + isSeHotKey.ToString().ToUpper()
                + "',seHotKeyA='" + seHotKeyA
                + "',seHotKeyB='" + seHotKeyB
                + "',checkUP='" + checkUP.ToString().ToUpper()
                + "' WHERE main='main'", Program.zikuSettingPath);
            Instance = null;
        }
    }
    #endregion

    #region DB
    public class DB
    {
        private string _id, _name, _path;
        public string id { get { return _id; } }
        public string name { get { return _name; } }
        /// <summary>
        /// 数据库文件在软件配置中的路径(未展开变量)
        /// </summary>
        public string path { get { return _path; } }

        /// <summary>
        /// 获取id在DB中的信息，找不到返回 null
        /// </summary>
        /// <param name="DBID"></param>
        /// <returns></returns>
        public static DB getInstance(string DBID)
        {
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM DB WHERE id = " + DBID, Program.zikuSettingPath);
            if (dt == null) return null; if (dt.Rows.Count == 0) return null;
            DataRow row = dt.Rows[0];
            DB db = new DB();
            db._id = row["id"].ToString();
            db._name = row["name"].ToString();
            db._path = row["path"].ToString();
            return db;
        }

        /// <summary>
        /// 修改DB内数据库的信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool writeDB(string id, string name, string path)
        {
            if (DataBase.Options.checkAndUpdate(path))
                SQLite.ExecuteNonQuery("UPDATE Config SET name = '" + name.Replace("'", "''") + "' WHERE main = 'main'", path);

            path = path.Replace(Program.ZIKUPATH, ".");
            SQLite.ExecuteNonQuery("UPDATE DB SET name = '" + name.Replace("'", "''") + "' ,path = '" + path.Replace("'", "''") + "' WHERE id = " + id, Program.ZIKUPATH + @"\Data\ziku.set");
            return true;
        }

        /// <summary>
        /// 导入数据库文件
        /// </summary>
        /// <returns></returns>
        public static bool inputDB()
        {
            OpenFileDialog opFileDialog = new OpenFileDialog();
            opFileDialog.InitialDirectory = Program.ZIKUPATH + "\\Data";
            opFileDialog.Filter = "ZIKU!数据库文件(*.mc)|*.mc";
            opFileDialog.Title = "选择一个现有的数据库文件";
            if (opFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (DataBase.Options.checkAndUpdate(opFileDialog.FileName))
                {
                    DataTable rTemp1 = SQLite.ExecuteDataTable("SELECT * FROM Config WHERE main = 'main'", opFileDialog.FileName);
                    DataRow read1 = rTemp1.Rows[0];
                    string cPath = opFileDialog.FileName.Replace(Program.ZIKUPATH, ".");
                    SQLite.ExecuteNonQuery("INSERT  INTO DB (name, path) VALUES ('" + read1["name"].ToString().Replace("'", "''") + "', '" + cPath.Replace("'", "''") + "');", Program.ZIKUPATH + @"\Data\ziku.set");
                }
                else
                {
                    MessageBox.Show("该数据库文件有误", "导入失败");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 移除软件配置中DB的信息
        /// </summary>
        /// <param name="DBid"></param>
        public static void removeDB(string DBid)
        {
            SQLite.ExecuteNonQuery("DELETE FROM DB WHERE id = " + DBid, Program.zikuSettingPath);
        }

        /// <summary>
        /// 创建数据库文件，并写入到软件配置中，失败返回0
        /// </summary>
        /// <returns></returns>
        public static int CreateDB()
        {
            string re = DataBase.Options.CreateDB();
            if (re == null) return 0;

            DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM Config WHERE main = 'main'", re);
            DataRow row = dt.Rows[0];
            re = re.Replace(Program.ZIKUPATH, ".");

            int re1 = SQLite.ExecuteNonQuery("INSERT  INTO DB (name, path) VALUES ('" + row["name"].ToString().Replace("'", "''") + "', '" + re.Replace("'", "''") + "');", Program.zikuSettingPath);
            return re1;
        }
    }
    #endregion

    #region Options
    class Options
    {
        /// <summary>
        /// 创建软件配置文件
        /// </summary>
        /// <returns></returns>
        public static bool CreateSettingDB()
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + Program.zikuSettingPath))
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(Program.ZIKUPATH + @"\Data");
                        conn.Open();
                        cmd.CommandText = "CREATE TABLE Config ( main STRING, Database_ID STRING, version STRING DEFAULT ('0.6.1.0'), isHotKey STRING DEFAULT TRUE, hotKeyA STRING DEFAULT ALT, hotKeyB STRING DEFAULT F, searchMode STRING DEFAULT altMode, isSeHotKey STRING DEFAULT TRUE, seHotKeyA STRING DEFAULT ALT, seHotKeyB STRING DEFAULT D, checkUP STRING DEFAULT TRUE);";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "CREATE TABLE DB ( id INTEGER PRIMARY KEY AUTOINCREMENT, name STRING, path STRING);";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "CREATE TABLE Variable ( id INTEGER PRIMARY KEY AUTOINCREMENT, uid STRING, name STRING, path STRING);";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "INSERT INTO Config (main) values ('main');";
                        cmd.ExecuteNonQuery();
                    }
                    catch { return false; }
                    finally
                    {
                        cmd.Dispose();
                        conn.Dispose();
                    }

                }
            }
            return true;
        }
        /// <summary>
        /// 检查并更新数据库
        /// </summary>
        /// <returns></returns>
        public static void checkAndUpdate()
        {
            DataBaseCheckUP.checkAndUpdateSET();
        }
    }
    #endregion
}

namespace ZIKU
{
    #region Variable
    public class Variable
    {
        private Variable(string id, string DBPath)
        {
            this.DBPath = Environment.ExpandEnvironmentVariables(DBPath);
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Variable WHERE id = " + id, DBPath);
            DataRow row = dt.Rows[0];
            _id = row["id"].ToString();
            _uid = row["uid"].ToString();
            _name = row["name"].ToString();
            _path = row["path"].ToString();
        }
        private Variable(DataRow row, string DBPath)
        {
            this.DBPath = Environment.ExpandEnvironmentVariables(DBPath);
            _id = row["id"].ToString();
            _uid = row["uid"].ToString();
            _name = row["name"].ToString();
            _path = row["path"].ToString();
        }
        private string _id, _uid, _name, _path, _expandPath, _pathShow;
        private string DBPath = "";
        public string id { get { return _id; } }
        /// <summary>
        /// 用户自定义id
        /// </summary>
        public string uid { get { return _uid; } }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get { return _name; } }
        /// <summary>
        /// 路径(save)
        /// </summary>
        public string path { get { return _path; } }
        /// <summary>
        /// 展开的路径
        /// </summary>
        public string pathExpand
        {
            get
            {
                if (_expandPath == null)
                {
                    _expandPath = myZiku.exPand(path, DBPath);
                }
                return _expandPath;
            }
        }
        public string pathShow
        {
            get
            {
                if (_pathShow == null)
                    _pathShow = myZiku.variableToShow(path, DBPath);
                return _pathShow;
            }
        }

        /// <summary>
        /// 获取数据库中对应的变量，没有返回null
        /// </summary>
        /// <param name="varID">变量的id</param>
        /// <returns></returns>
        public static Variable getIDVariable(string varID, string path)
        {
            if (!System.IO.File.Exists(System.Environment.ExpandEnvironmentVariables(path))) return null;

            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Variable WHERE id = " + varID, path, null, false);
            if (dt == null) return null;
            if (dt.Rows.Count == 0) return null;
            Variable var = new Variable(dt.Rows[0], path);
            return var;
        }
        /// <summary>
        /// 根据UID获取数据库中对应的变量
        /// </summary>
        /// <param name="varUID"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Variable getUIDVariable(string varUID, string path)
        {
            if (!System.IO.File.Exists(System.Environment.ExpandEnvironmentVariables(path))) return null;
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Variable WHERE LOWER(uid) = '" + varUID.ToLower() + "';", path, null, false);
            if (dt == null) return null;
            if (dt.Rows.Count == 0) return null;
            Variable var = new Variable(dt.Rows[0], path);
            return var;
        }

        /// <summary>
        /// 修改或创建一个变量，正确返回一个实例（传入save）
        /// </summary>
        public static Variable writeVariable(ref string id, string uid, string name, string path, string uidPrefix, string DBPath)
        {
            if (uidPrefix == null) uidPrefix = "";
            if (!checkVariable(id, uid, name, path, uidPrefix, DBPath)) return null;
            if (id == null || id == "")
                id = SQLite.ExecuteNonQuery("INSERT INTO Variable (name) values('__新的变量__')", DBPath).ToString();

            SQLite.ExecuteNonQuery("UPDATE Variable SET uid = '" + uid + "',name = '" + name.Replace("'", "''") + "',path = '" + path.Replace("'", "''") + "' WHERE id = " + id, DBPath);
            Variable var = new Variable(id, DBPath);
            return var;
        }

        /// <summary>
        /// 检查变量是否正确
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uid"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool checkVariable(string id, string uid, string name, string path, string uidPrefix, string DBPath)
        {
            if (name.Replace(" ", "") == "")
            {
                System.Windows.Forms.MessageBox.Show("“名称”不能为空");
                return false;
            }

            if (uid.Replace(" ", "") == "")
            {
                System.Windows.Forms.MessageBox.Show("“UID”不能为空");
                return false;
            }

            Regex reg = new Regex("^[a-zA-Z0-9\\-]+$");
            Match match = reg.Match(uid);
            if (!match.Success)
            {
                System.Windows.Forms.MessageBox.Show("“UID”只能包含英文字母以及数字和连字符“-”");
                return false;
            }

            if (uid.ToLower().StartsWith("ziku"))
            {
                MessageBox.Show("“UID”不能是“ZIKU”");
                return false;
            }

            string[] uidSP = uid.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (uidSP.Length == 2)
            {
                switch (uidSP[0])
                {
                    case "item":
                    case "i":
                    case "item32":
                    case "i32":
                    case "item64":
                    case "i64":
                    case "itemworkpath":
                    case "iw":
                    case "itemarguments":
                    case "ia":
                    case "itempath":
                    case "ip":
                    case "itemdata":
                    case "id":
                    case "g":
                        MessageBox.Show("“UID”不能以“" + uidSP[0] + "-”为开头");
                        return false;
                }
            }

            //判断是否有重复的 UID
            DataTable dt = OLEREO.Library.SQLite.ExecuteDataTable("SELECT * FROM Variable WHERE uid = '" + uid + "' COLLATE NOCASE;", DBPath);
            if (dt.Rows.Count > 0) //具有同名的变量
            {
                if (dt.Rows.Count == 1) //如果之后一个就判断是不是同一个变量即可，如果是同一个就说明这次没有修改
                {
                    if (dt.Rows[0]["id"].ToString() != id) //不是同一个，说明这次修改成了一个现有的
                    {
                        System.Windows.Forms.MessageBox.Show("变量UID与一个现有的重复，请重新指定一个", "UID 重复");
                        return false;
                    }
                }
                else
                {
                    //已经具有1个以上？？ 说明百分百重复，且有一个重复的了
                    System.Windows.Forms.MessageBox.Show("变量UID与一个现有的重复，请重新指定一个", "UID 重复");
                    return false;
                }
            }

            string var = "%" + uidPrefix + uid + "%";
            if (var != System.Environment.ExpandEnvironmentVariables(var))
            {
                System.Windows.Forms.MessageBox.Show("变量UID与系统变量重复，请重新指定一个", "UID 重复");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 移除变量的引用
        /// </summary>
        /// <param name="value">变量的数据库内部表示</param>
        /// <param name="rpValue">替换的值</param>
        public static void removeVariableReference(string value ,string rpValue)
        {
            //可以提供一个可以替换的值，如果不提供那就直接移除？

            //变量已经被引用，移除时是否使用变量值替换     是：替换成变量值  否：替换成变量

            //Category
            //Item    value,IV_x86,IV_x64,arguments,workingDirectory,iPath
           _removeReference("Item", "value", value, rpValue, DataBase.Config.Instance.Path);
           _removeReference("Item", "IV_x86", value, rpValue, ZIKU.DataBase.Config.Instance.Path);
           _removeReference("Item", "IV_x64", value, rpValue, ZIKU.DataBase.Config.Instance.Path);
           _removeReference("Item", "arguments", value, rpValue, ZIKU.DataBase.Config.Instance.Path);
           _removeReference("Item", "workingDirectory", value, rpValue, ZIKU.DataBase.Config.Instance.Path);
           _removeReference("Item", "iPath", value, rpValue,  ZIKU.DataBase.Config.Instance.Path);

            //Variable   path
           _removeReference("Variable", "path", value, rpValue,  ZIKU.DataBase.Config.Instance.Path);

            //XiaoChao   value,arguments
           _removeReference("XiaoChao", "value", value, rpValue,  ZIKU.DataBase.Config.Instance.Path);

           _removeReference("XiaoChao", "arguments", value, rpValue, ZIKU.DataBase.Config.Instance.Path);

            //Zset
            //Variable   path
            _removeReference("Variable", "path", value, rpValue, Program.zikuSettingPath);

        }
        private static void _removeReference(string table, string column, string value, string rpValue, string dbPath)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source = " + dbPath))
            {
                try
                {
                    conn.Open();
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        //创建配置表
                        DataTable dt = SQLite.ExecuteDataTable("SELECT * FROM " + table + " WHERE " + column + " LIKE '%" + value + "%';", dbPath);

                        foreach (DataRow row in dt.Rows)
                        {
                            string valueR = row[column].ToString();
                            cmd.CommandText = "UPDATE " + table + " SET " + column + " = '" + valueR.Replace(value, rpValue) + "' WHERE id = " + row["id"].ToString();
                            cmd.ExecuteNonQuery();
                        }

                        cmd.Dispose();
                        conn.Dispose();
                    }
                }
                catch
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

    }
    #endregion
}