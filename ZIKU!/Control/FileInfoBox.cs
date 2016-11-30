using IWshRuntimeLibrary;
using System;
using System.Collections;
using OLEREO.Library;
using System.Windows.Forms;
using System.Diagnostics;

namespace ZIKU.Control
{
    public class FileInfoBox
    {
        private static  FileInfoBox _Instance = null;
        public static FileInfoBox Instance {
            get {
                if (_Instance == null)
                    _Instance = new FileInfoBox();
                return _Instance;
            }
        }

        private Item.Item pForm = null;
        private Form infoForm;
        private TextBox infoFText;
        ToolTip tip = new ToolTip();

        ArrayList infoFormArray = new ArrayList();

        public class ItemFileInfo
        {
            public FileVersionInfo fileVerInfo { get { return _fileVerInfo; } }
            private FileVersionInfo _fileVerInfo = null;
            public string fileInfo { get { return _fileInfo; } }
            private string _fileInfo = "";
            /// <summary>
            /// 启动参数
            /// </summary>
            public string arguments = "";
            /// <summary>
            /// 工作目录
            /// </summary>
            public string workdir = "";
            /// <summary>
            /// 文件名称
            /// </summary>
            public string name = "";
            /// <summary>
            /// 主值
            /// </summary>
            public string value = "";
            /// <summary>
            /// 版本号
            /// </summary>
            public string version = "";
            /// <summary>
            /// 介绍
            /// </summary>
            public string induce = "";
            /// <summary>
            /// 图标
            /// </summary>
            public string icon = "";
            public ItemFileInfo(string filePath)
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);
                _fileInfo = "文件路径：" + filePath;     
                 
                value = filePath;
                // 如果文件存在
                if (fileInfo != null && fileInfo.Exists)
                {
                    FileVersionInfo info = FileVersionInfo.GetVersionInfo(fileInfo.FullName);
                    value = fileInfo.FullName;
                    name = fileInfo.FullName;
                    if (info.InternalName != "")
                    {
                        _fileInfo += "\r\n" + "文件名称：" + info.InternalName;
                        name = info.InternalName;
                    }
                    _fileInfo += "\r\n" + "产品名称：" + info.ProductName;
                    if (info.ProductName != "")
                        name = info.ProductName;
                    _fileInfo += "\r\n" + "公司名称：" + info.CompanyName;
                    _fileInfo += "\r\n" + "文件版本：" + info.FileVersion;
                    _fileInfo += "\r\n" + "产品版本：" + info.ProductVersion;
                    version = info.ProductVersion;
                    _fileInfo += "\r\n" + "系统显示文件版本：" + info.ProductMajorPart;
                    _fileInfo += "\r\n" + "文件说明：" + info.FileDescription;        
                     induce = info.FileDescription;
                    _fileInfo += "\r\n" + "文件语言：" + info.Language;
                    _fileInfo += "\r\n" + "原始文件名称：" + info.OriginalFilename;
                    _fileInfo += "\r\n" + "文件版权：" + info.LegalCopyright;

                    switch (fileInfo.Extension.ToLower())
                    {
                        case ".lnk":
                            WshShell shell = new WshShell();
                            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(filePath);
                            _fileInfo += "\r\n" + "目标文件：" + shortcut.TargetPath;
                            value = shortcut.TargetPath;
                            _fileInfo += "\r\n" + "图标文件：" + shortcut.IconLocation.TrimEnd(",0".ToCharArray());
                            icon = shortcut.IconLocation.TrimEnd(",0".ToCharArray());
                            if (shortcut.Arguments != "" && shortcut.Arguments != null)
                                _fileInfo += "\r\n" + "命令行参数：" + shortcut.Arguments;
                            arguments = shortcut.Arguments;
                            _fileInfo += "\r\n" + "起始位置：" + shortcut.WorkingDirectory;
                            workdir = shortcut.WorkingDirectory;
                            _fileInfo += "\r\n" + "备注：" + shortcut.Description;
                            induce = shortcut.Description;
                            _fileInfo += "\r\n" + "快捷键：" + shortcut.Hotkey;
                            if (System.IO.File.Exists(shortcut.TargetPath))
                                fileInfo = new System.IO.FileInfo(shortcut.TargetPath);
                            break;
                        case ".url":
                            _fileInfo += "\r\n" + "图标位置：" + iniFile.ReadIniKeys("InternetShortcut", "IconFile", filePath);
                            _fileInfo += "\r\n" + "目标文件：" + iniFile.ReadIniKeys("InternetShortcut", "URL", filePath);
                            icon = iniFile.ReadIniKeys("InternetShortcut", "IconFile", filePath);
                            value = iniFile.ReadIniKeys("InternetShortcut", "URL", filePath);
                            if (System.IO.File.Exists(iniFile.ReadIniKeys("InternetShortcut", "URL", filePath)))
                                fileInfo = new System.IO.FileInfo(iniFile.ReadIniKeys("InternetShortcut", "URL", filePath));
                            else
                            {
                                fileInfo = null;
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 设置该窗口的拥有着
        /// </summary>
        public Item.Item owner
        {
            set
            {
                pForm = value;
                pForm.FormClosing += PForm_FormClosing;
            }
        }

        private void PForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(Form f in infoFormArray)
            {
                if (f != null)
                    f.Close();
            }
        }
 

        /// <summary>
        /// 展示文件的信息（如果存在的话）
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public void showFileInfo(string filePath)
        {
            if (System.IO.File.Exists(filePath) && pForm != null)
            {
                infoForm = new Form();
                infoFText = new TextBox();
                infoForm.Text = "主值文件信息";
                infoForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                infoForm.SetBounds(10, 10, 400, 300);
                infoForm.Controls.Add(infoFText);
                infoFText.Multiline = true;
                infoFText.SetBounds(5, 5, infoForm.Width - 25, infoForm.Height - 50);
                infoFText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

                infoFormArray.Add(infoForm);
                ItemFileInfo itemI = new ItemFileInfo(filePath);
                infoFText.Text = itemI.fileInfo;
                itemI.name = System.IO.Path.GetFileNameWithoutExtension(filePath);
                itemI.value = filePath;
                infoForm.Show();
            }
        }

    }
}
