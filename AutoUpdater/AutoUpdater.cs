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
        /// ����°汾
        /// </summary>
        /// <exception cref="System.Net.WebException">�޷��ҵ�ָ����Դ</exception>
        /// <exception cref="System.NotSupportException">������ַ���ô���</exception>
        /// <exception cref="System.Xml.XmlException">���ص������ļ��д���</exception>
        /// <exception cref="System.ArgumentException">���ص������ļ��д���</exception>
        /// <exception cref="System.Excpetion">δ֪����</exception>
        /// <returns></returns>
        public void Update()
        {
            if (!updateconfig.Enabled)
                return;
            /*
             * ����Web���������õ���ǰ���°汾���ļ��б���ʽͬ���ص�FileList.xml��
             * �뱾�ص�FileList.xml�Ƚϣ��ҵ���ͬ�汾���ļ�
             * ����һ�������ļ��б���ʼDownloadProgress
             * <UpdateFile>
             *  <File path="" url="" lastver="" size=""></File>
             * </UpdateFile>
             * pathΪ�����Ӧ�ó����Ŀ¼�����Ŀ¼λ�ã������ļ���
             */
            WebClient client = new WebClient();
            string strXml = client.DownloadString(updateconfig.ServerUrl);

            Dictionary<string, RemoteFile> listRemotFile = ParseRemoteXml(strXml);

            List<DownloadFileInfo> downloadList = new List<DownloadFileInfo>();

            //ĳЩ�ļ�������Ҫ�ˣ�ɾ��
            List<LocalFile> preDeleteFile = new List<LocalFile>();

            foreach (LocalFile file in updateconfig.UpdateFileList)
            {
                if (listRemotFile.ContainsKey(file.Path))
                {
                    RemoteFile rf = listRemotFile[file.Path];
                    //file.LastVer���ذ汾
                    //rf.LastVer �������汾
                    //�ָ�   һ��һ��С�汾�Ƚ�
                    //if(Convert.ToDecimal( file.LastVer) > Convert.ToDecimal(rf.LastVer))
                    //{
                    //    MessageBox.Show("����");
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
                //���³ɹ�
                updateconfig.SaveConfig(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME));
                if (updateconfig.UpdateFileList.Count <= 0) return;

                //      /// <param name="unRarPath">�ļ���·��</param>  
                string unRarPath = AppDomain.CurrentDomain.BaseDirectory +"TEMP";
                //      /// <param name="rarPath">ѹ���ļ���·��</param> 
                string rarPath = AppDomain.CurrentDomain.BaseDirectory;
                //     /// <param name="rarName">ѹ���ļ����ļ���</param>  
                string rarName = updateconfig.UpdateFileList[0].Path;

                unRarPath =  UnCompressRar( unRarPath,  rarPath, rarName);
                if(unRarPath.Trim().Length<=0)
                {
                    MessageBox.Show("δ��װWinRarѹ������������ʧ�ܣ��밲װ���������");
                    return;

                }

                if (bNeedRestart)
                {
                    File.Delete(unRarPath+ rarName);
                    MessageBox.Show("������Ҫ������������Ӧ�ø��£�����ȷ��������������", "�Զ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string batstr = @"xcopy TEMP\* * /s /f /h /y"
                                            + "\r\n" + "rd /s /q TEMP"
                                            + "\r\n" + "del " + rarName
                                            + "\r\n" + "start " + Application.ExecutablePath
                                            + "\r\n" + "del %0 ";
                    StreamWriter sw = new StreamWriter(rarPath + "\\update.bat", false);
                    sw.WriteLine(batstr);
                    sw.Close();//д��

                    Process.Start(rarPath + "\\update.bat");//�����³�ʽ
                  //  Process.Start(Application.ExecutablePath);
                    Environment.Exit(0);
                }
            }
        }
        /// <summary>  
        /// ��֤WinRar�Ƿ�װ��  
        /// </summary>  
        /// <returns>true���Ѱ�װ��false��δ��װ</returns>  
        private static bool ExistsRar(out String winRarPath)
        {
            winRarPath = String.Empty;

            //ͨ��Regedit��ע����ҵ�WinRar�ļ�   
            var registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");

            if (registryKey == null) return false;//δ��װ  

            //registryKey = theReg;����ֱ�ӷ���Registry���󹩻������  
            winRarPath = registryKey.GetValue("").ToString();//����Ϊ��Լ��Դ��ֱ�ӷ���·������������Ҳû�õ�  

            registryKey.Close();//�ر�ע���  

            return !String.IsNullOrEmpty(winRarPath);
        }
        /// <summary>  
        /// ����Zip  
        /// </summary>  
        /// <param name="path">�ļ���·��</param>  
        /// <param name="rarPath">����ѹ���ļ���·��</param>  
        /// <param name="rarName">����ѹ���ļ����ļ���</param>  
        public static void CompressRar(String path, String rarPath, String rarName)
        {
            try
            {
                String winRarPath = null;
                if (!ExistsRar(out winRarPath)) return;//��֤WinRar�Ƿ�װ��  

                var pathInfo = String.Format("a -afzip -m0 -ep1 \"{0}\" \"{1}\"", rarName, path);

                #region WinRar �õ�������ע��  

                //[a] ��ӵ�ѹ���ļ�  
                //afzip ִ��zipѹ����ʽ�������û��ڲ�ͬ������ʹ�á���ȡ���ò�����ִ��rarѹ����  
                //-m0 �洢 ��ӵ�ѹ���ļ�ʱ��ѹ���ļ�����6������0-5����ֵԽ��Ч��Խ�ã�ҲԽ��  
                //ep1 �������ų���Ŀ¼�����ɵ�ѹ���ļ�������ֲ���Ҫ�Ĳ㼶��  
                //r   �޸�ѹ������  
                //t   ����ѹ�������ڵ��ļ�   
                //as  ͬ��ѹ����������    
                //-p  ��ѹ���ļ������뷽ʽΪ��-p123456  

                #endregion

                //����ļ����Ŀ¼  
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = winRarPath,//ִ�е��ļ���  
                        Arguments = pathInfo,//��Ҫִ�е�����  
                        UseShellExecute = false,//ʹ��Shellִ��  
                        WindowStyle = ProcessWindowStyle.Hidden,//���ش���  
                        WorkingDirectory = rarPath,//rar ���λ��  
                        CreateNoWindow = false,//����ʾ����  
                    },
                };
                process.Start();//��ʼִ��  
                process.WaitForExit();//�ȴ���ɲ��˳�  
                process.Close();//�رյ��� cmd ��ʲôʲô  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// ��ѹ  
        /// </summary>  
        /// <param name="unRarPath">�ļ���·��</param>  
        /// <param name="rarPath">ѹ���ļ���·��</param>  
        /// <param name="rarName">ѹ���ļ����ļ���</param>  
        /// <returns></returns>  
        public static String UnCompressRar(String unRarPath, String rarPath, String rarName)
        {
            try
            {
                String winRarPath = null;
                if (!ExistsRar(out winRarPath))
                {
                  
                    return "";//��֤WinRar�Ƿ�װ��  

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
                        FileName = winRarPath,//ִ�е��ļ���  
                        Arguments = pathInfo,//��Ҫִ�е�����  
                        UseShellExecute = false,//ʹ��Shellִ��  
                        WindowStyle = ProcessWindowStyle.Hidden,//���ش���  
                        WorkingDirectory = rarPath,//rar ���λ��  
                        CreateNoWindow = false,//����ʾ����  
                    },
                };
                process.Start();//��ʼִ��  
                process.WaitForExit();//�ȴ���ɲ��˳�  
                process.Close();//�رյ��� cmd ��ʲôʲô  
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
        /// Ҫ�����������ļ�
        /// </summary>
        public string DownloadUrl { get { return downloadUrl; } }
        /// <summary>
        /// ������ɺ�Ҫ�ŵ�����ȥ
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
