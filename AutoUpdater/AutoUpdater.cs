using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
namespace zengzhouming.Update
{
    public class AutoUpdater
    {
        const string FILENAME = "update.config";
        private UpdateConfig updateconfig = null;
        private bool bNeedRestart = false;

        public AutoUpdater()
        {
            updateconfig = UpdateConfig.LoadConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));
        }
        /// <summary>
        /// 检查新版本
        /// </summary>
        /// <exception cref="System.Net.WebException">无法找到指定资源</exception>
        /// <exception cref="System.NotSupportException">升级地址配置错误</exception>
        /// <exception cref="System.Xml.XmlException">下载的升级文件有错误</exception>
        /// <exception cref="System.ArgumentException">下载的升级文件有错误</exception>
        /// <exception cref="System.Excpetion">未知错误</exception>
        /// <returns></returns>
        public void Update()
        {
            if (!updateconfig.Enabled)
                return;
            /*
             * 请求Web服务器，得到当前最新版本的文件列表，格式同本地的FileList.xml。
             * 与本地的FileList.xml比较，找到不同版本的文件
             * 生成一个更新文件列表，开始DownloadProgress
             * <UpdateFile>
             *  <File path="" url="" lastver="" size=""></File>
             * </UpdateFile>
             * path为相对于应用程序根目录的相对目录位置，包括文件名
             */
            WebClient client = new WebClient();
            string strXml = client.DownloadString(updateconfig.ServerUrl);

            Dictionary<string, RemoteFile> listRemotFile = ParseRemoteXml(strXml);

            List<DownloadFileInfo> downloadList = new List<DownloadFileInfo>();

            //某些文件不再需要了，删除
            List<LocalFile> preDeleteFile = new List<LocalFile>();

            foreach (LocalFile file in updateconfig.UpdateFileList)
            {
                if (listRemotFile.ContainsKey(file.Path))
                {
                    RemoteFile rf = listRemotFile[file.Path];
                    //file.LastVer本地版本
                    //rf.LastVer 服务器版本
                    //分割   一个一个小版本比较
                    //if(Convert.ToDecimal( file.LastVer) > Convert.ToDecimal(rf.LastVer))
                    //{
                    //    MessageBox.Show("最新");
                    //}

                    if (rf.LastVer != file.LastVer)
                    {
                        downloadList.Add(new DownloadFileInfo(rf.Url, file.Path, rf.LastVer, rf.Size,rf.ReMark));
                        file.LastVer = rf.LastVer;
                        file.Size = rf.Size;

                        if (rf.NeedRestart)
                            bNeedRestart = true;
                    }

                    listRemotFile.Remove(file.Path);
                }
                else
                {
                    preDeleteFile.Add(file);
                }
            }

            foreach (RemoteFile file in listRemotFile.Values)
            {
                downloadList.Add(new DownloadFileInfo(file.Url, file.Path, file.LastVer, file.Size,file.ReMark));
                updateconfig.UpdateFileList.Add(new LocalFile(file.Path, file.LastVer, file.Size, file.ReMark));

                if (file.NeedRestart)
                    bNeedRestart = true;
            }

            if (downloadList.Count > 0)
            {
                DownloadConfirm dc = new DownloadConfirm(downloadList);

                if (this.OnShow != null)
                    this.OnShow();

                if (DialogResult.OK == dc.ShowDialog())
                {
                    foreach (LocalFile file in preDeleteFile)
                    {
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file.Path);
                        if (File.Exists(filePath))
                            File.Delete(filePath);

                        updateconfig.UpdateFileList.Remove(file);
                    }

                    StartDownload(downloadList);
                }
            }
        }

        private void StartDownload(List<DownloadFileInfo> downloadList)
        {
            DownloadProgress dp = new DownloadProgress(downloadList);
            if (dp.ShowDialog() == DialogResult.OK)
            {
                //更新成功
                updateconfig.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));
                if (updateconfig.UpdateFileList.Count <= 0) return;

                //      /// <param name="unRarPath">文件夹路径</param>  
                string unRarPath = AppDomain.CurrentDomain.BaseDirectory +"TEMP";
                //      /// <param name="rarPath">压缩文件的路径</param> 
                string rarPath = AppDomain.CurrentDomain.BaseDirectory;
                //     /// <param name="rarName">压缩文件的文件名</param>  
                string rarName = updateconfig.UpdateFileList[0].Path;

                unRarPath =  UnCompressRar( unRarPath,  rarPath, rarName);
                if(unRarPath.Trim().Length<=0)
                {
                    MessageBox.Show("未安装WinRar压缩软件，会更新失败，请安装软件后再试");
                    return;

                }

                if (bNeedRestart)
                {
                    File.Delete(unRarPath+ rarName);
                    MessageBox.Show("程序需要重新启动才能应用更新，请点击确定重新启动程序。", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string batstr = @"xcopy TEMP\* * /s /f /h /y"
                                            + "\r\n" + "rd /s /q TEMP"
                                            + "\r\n" + "del " + rarName
                                            + "\r\n" + "start " + Application.ExecutablePath
                                            + "\r\n" + "del %0 ";
                    StreamWriter sw = new StreamWriter(rarPath + "\\update.bat", false);
                    sw.WriteLine(batstr);
                    sw.Close();//写入

                    Process.Start(rarPath + "\\update.bat");//启动新程式
                  //  Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
            }
        }
        /// <summary>  
        /// 验证WinRar是否安装。  
        /// </summary>  
        /// <returns>true：已安装，false：未安装</returns>  
        private static bool ExistsRar(out String winRarPath)
        {
            winRarPath = String.Empty;

            //通过Regedit（注册表）找到WinRar文件   
            var registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");

            if (registryKey == null) return false;//未安装  

            //registryKey = theReg;可以直接返回Registry对象供会面操作  
            winRarPath = registryKey.GetValue("").ToString();//这里为节约资源，直接返回路径，反正下面也没用到  

            registryKey.Close();//关闭注册表  

            return !String.IsNullOrEmpty(winRarPath);
        }
        /// <summary>  
        /// 生成Zip  
        /// </summary>  
        /// <param name="path">文件夹路径</param>  
        /// <param name="rarPath">生成压缩文件的路径</param>  
        /// <param name="rarName">生成压缩文件的文件名</param>  
        public static void CompressRar(String path, String rarPath, String rarName)
        {
            try
            {
                String winRarPath = null;
                if (!ExistsRar(out winRarPath)) return;//验证WinRar是否安装。  

                var pathInfo = String.Format("a -afzip -m0 -ep1 \"{0}\" \"{1}\"", rarName, path);

                #region WinRar 用到的命令注释  

                //[a] 添加到压缩文件  
                //afzip 执行zip压缩方式，方便用户在不同环境下使用。（取消该参数则执行rar压缩）  
                //-m0 存储 添加到压缩文件时不压缩文件。共6个级别【0-5】，值越大效果越好，也越慢  
                //ep1 依名称排除主目录（生成的压缩文件不会出现不必要的层级）  
                //r   修复压缩档案  
                //t   测试压缩档案内的文件   
                //as  同步压缩档案内容    
                //-p  给压缩文件加密码方式为：-p123456  

                #endregion

                //打包文件存放目录  
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = winRarPath,//执行的文件名  
                        Arguments = pathInfo,//需要执行的命令  
                        UseShellExecute = false,//使用Shell执行  
                        WindowStyle = ProcessWindowStyle.Hidden,//隐藏窗体  
                        WorkingDirectory = rarPath,//rar 存放位置  
                        CreateNoWindow = false,//不显示窗体  
                    },
                };
                process.Start();//开始执行  
                process.WaitForExit();//等待完成并退出  
                process.Close();//关闭调用 cmd 的什么什么  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 解压  
        /// </summary>  
        /// <param name="unRarPath">文件夹路径</param>  
        /// <param name="rarPath">压缩文件的路径</param>  
        /// <param name="rarName">压缩文件的文件名</param>  
        /// <returns></returns>  
        public static String UnCompressRar(String unRarPath, String rarPath, String rarName)
        {
            try
            {
                String winRarPath = null;
                if (!ExistsRar(out winRarPath))
                {
                  
                    return "";//验证WinRar是否安装。  

                }
                   

                if (Directory.Exists(unRarPath) == false)
                {
                    Directory.CreateDirectory(unRarPath);
                }

                var pathInfo = "x " + rarName + " \"" + unRarPath + "\" -y";

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = winRarPath,//执行的文件名  
                        Arguments = pathInfo,//需要执行的命令  
                        UseShellExecute = false,//使用Shell执行  
                        WindowStyle = ProcessWindowStyle.Hidden,//隐藏窗体  
                        WorkingDirectory = rarPath,//rar 存放位置  
                        CreateNoWindow = false,//不显示窗体  
                    },
                };
                process.Start();//开始执行  
                process.WaitForExit();//等待完成并退出  
                process.Close();//关闭调用 cmd 的什么什么  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return unRarPath;
        }
        private Dictionary<string,RemoteFile> ParseRemoteXml(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);

            Dictionary<string, RemoteFile> list = new Dictionary<string, RemoteFile>();
            foreach (XmlNode node in document.DocumentElement.ChildNodes)
            {
                list.Add(node.Attributes["path"].Value, new RemoteFile(node));
            }

            return list;
        }
        public event ShowHandler OnShow;
    }

    public class RemoteFile
    {
        private string path = "";
        private string url = "";
        private string lastver = "";
        private int size = 0;
        private string remark = "";
        private bool needRestart = false;

        public string Path { get { return path; } }
        public string Url { get { return url; } }
        public string LastVer { get { return lastver; } }
        public int Size { get { return size; } }

        public string ReMark { get { return remark; } }
        public bool NeedRestart { get { return needRestart; } }

        public RemoteFile(XmlNode node)
        {
            this.path = node.Attributes["path"].Value;
            this.url = node.Attributes["url"].Value;
            this.lastver = node.Attributes["lastver"].Value;
            this.size = Convert.ToInt32(node.Attributes["size"].Value);
            this.remark = node.Attributes["remark"].Value;
            this.needRestart = Convert.ToBoolean(node.Attributes["needRestart"].Value);
        }
    }

    public class LocalFile
    {
        private string path = "";
        private string lastver = "";
        private int size = 0;
        private string remark = "";
        [XmlAttribute("path")]
        public string Path { get { return path; } set { path = value; } }
        [XmlAttribute("lastver")]
        public string LastVer { get { return lastver; } set { lastver = value; } }
        [XmlAttribute("size")]
        public int Size { get { return size; } set { size = value; } }

        [XmlAttribute("remark")]
        public string ReMark { get { return remark; } set { remark = value; } }
        public LocalFile(string path, string ver, int size,string remark)
        {
            this.path = path;
            this.lastver = ver;
            this.size = size;
            this.remark = remark;
        }

        public LocalFile()
        {
        }

    }


    public delegate void ShowHandler();

    public class DownloadFileInfo
    {
        string downloadUrl = "";
        string fileName = "";
        string lastver = "";
        string remark = "";
        int size = 0;

        /// <summary>
        /// 要从哪里下载文件
        /// </summary>
        public string DownloadUrl { get { return downloadUrl; } }
        /// <summary>
        /// 下载完成后要放到哪里去
        /// </summary>
        public string FileFullName { get { return fileName; } }
        public string FileName { get { return Path.GetFileName(FileFullName); } }
        public string LastVer { get { return lastver; } set { lastver = value; } }
        public string ReMark { get { return remark; } set { remark = value; } }
        public int Size { get { return size; } }

        public DownloadFileInfo(string url, string name, string ver, int size, string remark)
        {
            this.downloadUrl = url;
            this.fileName = name;
            this.lastver = ver;
            this.size = size;
            this.remark = remark;
        }
    }
}
