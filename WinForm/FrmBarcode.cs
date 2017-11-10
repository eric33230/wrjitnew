using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.IO;
using System.Configuration;
using InTheHand.Net.Sockets;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using System.Threading;

namespace WinForm
{
    public partial class FrmBarcode : Form
    {

        #region  构造函数，设置了不自动生成列 --Private FrmBarcode()
        /// <summary>
        /// 构造函数，设置了不自动生成列
        /// </summary>
        private FrmBarcode()
        {
            InitializeComponent();
            this.dgvBarcode.AutoGenerateColumns = false;           
           // serialPort1.Open();             

        }
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        public int selectedDeviceIndex = 0;
      
      
        #endregion
        public void GetComList()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();//线被拔掉时报错
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请检查COM线是否已被拔除！\r\n错误信息:\r\n" + ex.ToString());
                //  MessageBox.Show(ex.ToString());
            }
            cmbComPort.Items.Clear();
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
            if (keyCom != null)
            {
                string[] sSubKeys = keyCom.GetValueNames();
                this.cmbComPort.Items.Clear();
                foreach (string sName in sSubKeys)
                {
                    string sValue = (string)keyCom.GetValue(sName);
                    this.cmbComPort.Items.Add(sValue);
                }
            }
        }
        #region 单例窗体对象  -static FrmBarcode frm
        /// <summary>
        /// 单例窗体对象
        /// </summary>
        static FrmBarcode frm = null;
        #endregion
        #region 单例模式，返回单个窗体对象  -static FrmBarcode GetSingleton()
        /// <summary>
        /// 单例模式，返回单个窗体对象
        /// </summary>
        /// <returns></returns>
        public static FrmBarcode GetSingleton()
        {
            //if(frm==null || frm.IsDisposed)
            if (frm == null)
            {
                frm = new FrmBarcode();
            }
            return frm;
        }
        #endregion
        BLL.doc_InnerBoxManager ib = new BLL.doc_InnerBoxManager();
        BLL.T_StyleCodeInfoManager od = new BLL.T_StyleCodeInfoManager();
        int kk = 1;
        /// <summary>
        ///  serialPort  数据接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        string scanno = "";
        string responseStr = "";        
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] bytes = new byte[2 * 1024];//创建缓存区接收数据
            int len = serialPort1.Read(bytes, 0, bytes.Length);

            //串口的相应数据
            responseStr = Encoding.Default.GetString(bytes, 0, len);
            // invoke
            this.Invoke(new Action(
              delegate
                   {
                       tb2.AppendText(responseStr);
                       btnRgetCom.Visible = false;
                       cmbComPort.Visible = false;

                       //  判断
                       #region 判斷
                       if (System.Text.RegularExpressions.Regex.IsMatch(tb2.Text, @".*\r\n$"))
                       {
                           scanno = tb2.Text;
                           scanno = scanno.Trim();
                           tb2.Text = "";
                           getinfobybarcode(scanno);
                       };
                       #endregion
                   }));
        }
        private void cleansize()
        {
            lblNo.Text = "";
            lblColor.Text = "";
            lblSize1.Text = "";
            lblSize1.BackColor = System.Drawing.Color.AliceBlue;
            lblSize2.Text = "";
            lblSize2.BackColor = System.Drawing.Color.AliceBlue;
            lblSize3.Text = "";
            lblSize3.BackColor = System.Drawing.Color.AliceBlue;
            lblSize4.Text = "";
            lblSize4.BackColor = System.Drawing.Color.AliceBlue;
            lblSize5.Text = "";
            lblSize5.BackColor = System.Drawing.Color.AliceBlue;
            lblSize6.Text = "";
            lblSize6.BackColor = System.Drawing.Color.AliceBlue;
            lblSize7.Text = "";
            lblSize7.BackColor = System.Drawing.Color.AliceBlue;
            lblSize8.Text = "";
            lblSize8.BackColor = System.Drawing.Color.AliceBlue;
            lblSize9.Text = "";
            lblSize9.BackColor = System.Drawing.Color.AliceBlue;
            lblSize10.Text = "";
            lblSize10.BackColor = System.Drawing.Color.AliceBlue;
            lblSize11.Text = "";
            lblSize11.BackColor = System.Drawing.Color.AliceBlue;
            lblSize12.Text = "";
            lblSize12.BackColor = System.Drawing.Color.AliceBlue;
            tb13.Text = "";
            tb13.BackColor = System.Drawing.Color.AliceBlue;
            frm.BackColor = System.Drawing.Color.White;
            msgDiv.MsgDivHidden();
            kk = 1;

        }
        private void innershow(int k, string size)
        {
            // MessageBox.Show("kk=0");
            #region            // 外箱条码的型号与内盒不同

            switch (k)
            {
                case 0:

                    kk++;
                    break;
                case 1:
                    lblSize1.Text = size;
                    lblSize1.BackColor = System.Drawing.Color.LightGreen;
                    kk++;
                    break;
                case 2:
                    lblSize2.Text = size;
                    if (lblSize2.Text == lblSize1.Text)
                    {
                        lblSize2.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        lblSize2.BackColor = System.Drawing.Color.Red;
                    }


                    kk++;
                    break;
                case 3:
                    lblSize3.Text = size;
                    if (lblSize3.Text == lblSize1.Text)
                    {
                        lblSize3.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        lblSize3.BackColor = System.Drawing.Color.Red;
                    }

                    kk++;
                    break;
                case 4:
                    lblSize4.Text = size;
                    if (lblSize4.Text == lblSize1.Text)
                    {
                        lblSize4.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        lblSize4.BackColor = System.Drawing.Color.Red;
                    }
                    kk++;
                    break;
                case 5:
                    lblSize5.Text = size;
                    if (lblSize5.Text == lblSize1.Text)
                    {
                        lblSize5.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        lblSize5.BackColor = System.Drawing.Color.Red;
                    }

                    kk++;
                    break;
                case 6:
                    lblSize6.Text = size;
                    if (lblSize6.Text == lblSize1.Text)
                    {
                        lblSize6.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        lblSize6.BackColor = System.Drawing.Color.Red;
                    }
                    kk++;
                    break;
                case 7:
                    lblSize7.Text = size;
                    if (lblSize7.Text == lblSize1.Text)
                    {
                        lblSize7.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        lblSize7.BackColor = System.Drawing.Color.Red;
                    }
                    kk++;
                    break;
                case 8:
                    lblSize8.Text = size;
                    if (lblSize8.Text == lblSize1.Text)
                    {
                        lblSize8.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        lblSize8.BackColor = System.Drawing.Color.Red;
                    }

                    kk++;
                    break;
                case 9:
                    lblSize9.Text = size;
                    if (lblSize9.Text == lblSize1.Text)
                    {
                        lblSize9.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        lblSize9.BackColor = System.Drawing.Color.Red;
                    }



                    kk++;
                    break;
                case 10:
                    lblSize10.Text = size;
                    if (lblSize10.Text == lblSize1.Text)
                    {
                        lblSize10.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        lblSize10.BackColor = System.Drawing.Color.Red;
                    }
                    kk++;
                    break;
                case 11:
                    lblSize11.Text = size;
                    if (lblSize11.Text == lblSize1.Text)
                    {
                        lblSize11.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        lblSize11.BackColor = System.Drawing.Color.Red;
                    }


                    kk++;
                    break;
                case 12:
                    lblSize12.Text = size;
                    if (lblSize12.Text == lblSize1.Text)
                    {
                        lblSize12.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        lblSize12.BackColor = System.Drawing.Color.Red;
                    }


                    kk++;
                    break;
                case 13:
                    tb13.AppendText(size + "\r\n");
                    tb13.BackColor = System.Drawing.Color.LightGreen;
                    kk++;
                    break;
                default:
                    tb13.AppendText(size + "\r\n");
                    tb13.BackColor = System.Drawing.Color.LightGreen;
                    kk++;
                    break;
            }
            #endregion

        }
        private void FrmBarcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            videoSourcePlayer2.SignalToStop();
            videoSourcePlayer2.WaitForStop();
            frm = null;
            serialPort1.Close();
        }

        //Com口配置
        private static readonly string COM = ConfigurationManager.ConnectionStrings["COM"].ConnectionString;
        private static readonly string Bluetooth = ConfigurationManager.ConnectionStrings["Bluetooth"].ConnectionString;
        private void FrmBarcode_Load(object sender, EventArgs e)
        {
            tscbxCameras.Visible = false;
            btnRgetcb.Visible = false;
            btnOpen.Visible = false;
            btnTake.Visible = false;
            btnCloses.Visible = false;
            cmbComPort.Visible = false;
            btnRgetCom.Visible = false;
            groupBox2.Visible = false;

            //摄像头  
            getcb();

            //有线枪
            GetComList();
            if (cmbComPort.Items.Count > 0)
            {
                for (int i = 0; i < cmbComPort.Items.Count; i++)
                {
                    string comname = cmbComPort.Items[i].ToString();
                    if (comname == COM)
                    {
                        serialPort1.PortName = COM;
                       // serialPort1.Open();
                        break;
                    }
                    else if(cmbComPort.Items.Count == 1)
                    {
                        MessageBox.Show("COM线接在 " + comname + " 上，请检查COM口与配置文件COM配置是否正确！");
                        //  Close();
                    }
                    else if (cmbComPort.Items.Count > 1)
                    {
                      //  MessageBox.Show("多个COM 请注意COM口连接在哪个口");
                        //  Close();
                    }
                }
            }
            else
            {
                //蓝牙
                //Thread t1 = new Thread(new ThreadStart(frmwait));
                //t1.Start();
                MessageBox.Show("没有找到COM设备，搜索蓝牙需时10秒左右，请稍等！");               

                getBluetooth();
                if (lsbDevices.Items.Count > 0)
                {
                    bool ishave = false;
                    for (int i = 0; i < lsbDevices.Items.Count; i++)
                    {
                        string comname = lsbDevices.Items[i].ToString();
                        if (comname == Bluetooth)
                        {
                            MessageBox.Show("已找到蓝牙设备 " + comname );
                            ishave = true;
                            break;
                        }

                    }
                    if(!ishave)
                        {
                        MessageBox.Show("没有找到蓝牙设备，请检查配置文件的蓝牙的名称是否正确！");
                        //  Close();
                    }
                }
            }

            
            if (lsbDevices.Items.Count <= 0 && cmbComPort.Items.Count <= 0)
            {
                MessageBox.Show("没有找到COM连接线，也没有找到蓝牙设备，请检查硬件是否正确连接并可使用！");
            }

        }
              
        private void FrmBarcode_Activated(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                //       serialPort1.Open();
            }
        }
        private void FrmBarcode_Deactivate(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();

            }
        }
        //拍照
        private void getPhotos()
        {
            // MessageBox.Show("我要拍照了");
            getPhoto();
        }
        private void btnRgetcb_Click(object sender, EventArgs e)
        {
            getcb();
        }
        public void getcb()
        {
            tscbxCameras.Items.Clear();
            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    throw new ApplicationException();                   
                }
                btnRgetcb.Visible = false;
                foreach (FilterInfo device in videoDevices)
                {
                    tscbxCameras.Items.Add(device.Name);
                }
                tscbxCameras.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                tscbxCameras.Items.Add("No local capture devices");
                MessageBox.Show("没有摄像头");
                btnRgetcb.Visible = true;
                videoDevices = null;
            }
        }      
        public void getPhoto()
        {
            if (videoSource == null)
                return;
            Bitmap bitmap1 = videoSourcePlayer1.GetCurrentVideoFrame();
            Bitmap bitmap2 = videoSourcePlayer2.GetCurrentVideoFrame();
            //  videoSourcePlayer1.p
            string fileName1 = "";
            string fileName2 = "";
            if (lblStyle.Text != "" && lblColor.Text != "" && lblSize1.Text != "")
            {
                //      string dd = System.Environment.CurrentDirectory;
                fileName1 = lblStyle.Text + "_" + lblColor.Text + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + lblSize1.Text + "_1.jpg";
                fileName2 = lblStyle.Text + "_" + lblColor.Text + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + lblSize1.Text + "_2.jpg";
            }
            //  string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff") + ".jpg";
            string dirpath = System.Environment.CurrentDirectory + @"\IMG\";
                if (!Directory.Exists(dirpath))
            {
                Directory.CreateDirectory(dirpath);
            }
               
            if (bitmap1 != null && fileName1 != "")
            {

                bitmap1.Save(dirpath + fileName1, ImageFormat.Jpeg);
            }
            else
            {
                //msgDiv.MsgDivShow("保存图片1失败，请找IT小明查找原因！电话：069907522", 60);
                 MessageBox.Show("保存图片1失败，请检查摄像头或找小明查找原因！\r\n 电话：069907522");
            }
            if (bitmap2 != null && fileName2 != "")
            {
                bitmap2.Save(dirpath + fileName2, ImageFormat.Jpeg);
            }
            else
            {
               // msgDiv.MsgDivShow("保存图片1失败，请找IT小明查找原因！电话：069907522", 60);
                 MessageBox.Show("保存图片2失败，请检查摄像头或找IT小明查找原因！\r\n电话：069907522");
            }
            if (bitmap1!=null)
            {
                bitmap1.Dispose();
            }
            if (bitmap2 != null)
            {
                bitmap2.Dispose();
            }

           

        }
        private void tscbxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            //打开摄像头
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //如果已经打开  则关闭
            if (videoSourcePlayer1.IsRunning)
            {
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
            }
            // selectedDeviceIndex =1; //镜头源
            //selectedDeviceIndex = tscbxCameras.SelectedIndex; //镜头源
            //    selectedDeviceIndex = tscbxCameras.Items.Count;// 1 2 
            if (tscbxCameras.Items.Count <= 0)
            {
               //  msgDiv.MsgDivShow("内盒条码没有对应型体数据", 60);
                MessageBox.Show("没有找到摄像头，请检查摄像头线路");
                btnRgetcb.Visible = true;
                return;
            }else
            {
                btnRgetcb.Visible = false;
                selectedDeviceIndex = 0;
                videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头。
                int i = videoSource.VideoCapabilities.Length;
                if (i >= 15)
                {

                    videoSource.VideoResolution = videoSource.VideoCapabilities[15];//I取最大值卡 取16
                }
                else
                {

                    videoSource.VideoResolution = videoSource.VideoCapabilities[i - 1];//I取最大值  最大
                }
                videoSourcePlayer1.VideoSource = videoSource;
                videoSourcePlayer1.Start();
            }
           


            //镜头2
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //如果已经打开  则关闭
            if (videoSourcePlayer2.IsRunning)
            {
                videoSourcePlayer2.SignalToStop();
                videoSourcePlayer2.WaitForStop();
            }
            // selectedDeviceIndex =1; //镜头源
            //selectedDeviceIndex = tscbxCameras.SelectedIndex; //镜头源
            //selectedDeviceIndex = tscbxCameras.Items.Count;// 1 2 
            if (tscbxCameras.Items.Count <= 1)
            {
                //msgDiv.MsgDivShow("没有找到摄像头2，请检查摄像头线路", 60);
                 MessageBox.Show("没有找到摄像头2，请检查摄像头线路");
                btnRgetcb.Visible = true;
                return;
            } else
            {
                selectedDeviceIndex = 1;
                videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头。
                int  i = videoSource.VideoCapabilities.Length;
                if (i >= 15)
                {

                    videoSource.VideoResolution = videoSource.VideoCapabilities[15];//I取最大值卡 取16
                }
                else
                {

                    videoSource.VideoResolution = videoSource.VideoCapabilities[i - 1];//I取最大值  最大
                }
                videoSourcePlayer2.VideoSource = videoSource;
                videoSourcePlayer2.Start();
            }
           
        }
        private void btnRgetCom_Click(object sender, EventArgs e)
        {
            GetComList();
            cmbComPort.DroppedDown = true;
            try
            {
                if (cmbComPort.Items.Count <= 0)
                {
                    MessageBox.Show("请连接com口");
                    return;
                }
               // cmbComPort.SelectedIndex = 0;
                string portname = "";
                portname = Convert.ToString(cmbComPort.SelectedItem);
                //SeralPort.Open() ，open 方法
                //SerialPort.IsOpen() ，值为true就是已开；false已关//
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = portname;//被占用时
                    serialPort1.Open();
                }
                //serialPort1.PortName = portname;//被占用时
                //serialPort1.Open();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
                MessageBox.Show("请检查COM线是否已被拔除！\r\n错误信息:\r\n" + ex);
            }
        }
        
        private void FrmBarcode_KeyDown_1(object sender, KeyEventArgs e)
        {
            MessageBox.Show("OK");

        }
        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            responseStr = txtPwd.Text;
            int dd = txtPwd.Text.Length;
          //  txtPwd.Text = "";
            this.Invoke(new Action(
             delegate
             {
                 ////tb2.AppendText(responseStr);
                 if (System.Text.RegularExpressions.Regex.IsMatch(responseStr, @".*\r\n$"))
                 {
                     scanno = responseStr;
                     //  tb2.Text = scanno;
                     scanno = scanno.Trim();
                     //tb2.Text = "";
                     //  txtPwd.Text = "";
                //     MessageBox.Show(responseStr + "is me");
                 }            
             }));
        }
        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string responseStr = txtPwd.Text;
                txtPwd.Text = "";
                getinfobybarcode(responseStr);
              //  MessageBox.Show(responseStr + "is me");//执行任务               
            }            
        }
        public void getinfobybarcode(string scanno)
        {          
            //外箱条码=14,12位(有100),内盒 13,12位(没有100)  
            if (scanno.Length == 14 || (scanno.Length == 12 && scanno.Substring(0, 3) == "100"))
            {
                #region if 狀況
                kk = 0;
                #region
                if (scanno.Length == 14)
                {
                    cleansize();
                    lblNo.Text = "";

                    if (scanno.Substring(0, 3) == "001")
                    {
                        lblCarton.Text = scanno.Substring(2, 8);
                        lblCartonNo.Text = scanno.Substring(10);
                        lblStyle.Text = od.GetStyle(lblCarton.Text);

                    }
                    else
                    {
                        lblCarton.Text = scanno.Substring(0, 10);
                        lblCartonNo.Text = scanno.Substring(10);
                        lblStyle.Text = od.GetStyle(lblCarton.Text);
                    }

                    if (lblStyle.Text == "")
                    {
                        frm.BackColor = System.Drawing.Color.Yellow;
                        msgDiv.MsgDivShow("内盒条码没有对应型体数据", 60);
                        MessageBox.Show("请导入内盒条码型体");
                        frm.BackColor = System.Drawing.Color.BurlyWood;
                        //  MessageBox.Show("条码没有对应型体数据");
                    }
                    else
                    {
                        lblColor.Text = od.GetColor(lblCarton.Text);
                    }
                }
                #endregion
                //外箱100条码 12位
                else if (scanno.Length == 12 && scanno.Substring(0, 3) == "100")
                {
                    #region CLEANSIZE
                    lblStyle.Text = "";
                    lblColor.Text = "";
                    lblSize1.Text = "";
                    lblSize1.BackColor = System.Drawing.Color.AliceBlue;
                    lblSize2.Text = "";
                    lblSize2.BackColor = System.Drawing.Color.AliceBlue;
                    lblSize3.Text = "";
                    lblSize3.BackColor = System.Drawing.Color.AliceBlue;
                    lblSize4.Text = "";
                    lblSize4.BackColor = System.Drawing.Color.AliceBlue;
                    lblSize5.Text = "";
                    lblSize5.BackColor = System.Drawing.Color.AliceBlue;
                    lblSize6.Text = "";
                    lblSize6.BackColor = System.Drawing.Color.AliceBlue;
                    lblSize7.Text = "";
                    lblSize7.BackColor = System.Drawing.Color.AliceBlue;
                    lblSize8.Text = "";
                    lblSize8.BackColor = System.Drawing.Color.AliceBlue;
                    lblSize9.Text = "";
                    lblSize9.BackColor = System.Drawing.Color.AliceBlue;
                    lblSize10.Text = "";
                    lblSize10.BackColor = System.Drawing.Color.AliceBlue;
                    lblSize11.Text = "";
                    lblSize11.BackColor = System.Drawing.Color.AliceBlue;
                    lblSize12.Text = "";
                    lblSize12.BackColor = System.Drawing.Color.AliceBlue;
                    kk = 1;
                    #endregion cleansize
                    lblNo.Text = "";
                    lblCarton.Text = scanno.Substring(0, 8);
                    lblCartonNo.Text = scanno.Substring(8);
                    lblStyle.Text = od.GetStyle(lblCarton.Text);
                    #region
                    if (lblStyle.Text == "")
                    {
                        frm.BackColor = System.Drawing.Color.Yellow;
                        msgDiv.MsgDivShow(" 外箱条码没有对应型体数据", 60);
                        MessageBox.Show("请导入订单外箱型体数据---IT小明");
                        frm.BackColor = System.Drawing.Color.BurlyWood;
                        ///      MessageBox.Show("条码没有对应型体数据");
                        // kk = 0;
                    }
                    else
                    {
                        lblColor.Text = od.GetColor(lblCarton.Text);
                    }
                    #endregion
                }
                #endregion if 狀況
            }

            // 内盒条码扫描
            else if (scanno.Length == 13 || (scanno.Length == 12 && scanno.Substring(0, 3) != "100"))
            {
                #region else if 內容
                if (lblCarton.Text == "")
                {
                    #region
                    if (scanno.Substring(0, 3) == "454")
                    {
                        //   msgDiv.MsgDivShow("哈哈哈",60);
                        lblCarton.Text = scanno.Substring(0, scanno.Length);
                        lblCartonNo.Text = scanno.Substring(9);
                        List<MODEL.doc_InnerBox> temp = new List<MODEL.doc_InnerBox>();
                        temp = ib.GetAllInneBox(scanno);
                        if (temp != null && temp.Count >= 1)
                        {
                            lblStyle.Text = temp[0].Name.ToString();
                            lblColor.Text = temp[0].Color.ToString();
                        }
                    }
                    else
                    {
                        frm.BackColor = System.Drawing.Color.Yellow;
                        msgDiv.MsgDivShow("没有扫描外箱");
                        frm.BackColor = System.Drawing.Color.BurlyWood;
                    }
                    #endregion
                }
                // 内盒显示在这里
                else
                {
                    msgDiv.MsgDivHidden();
                    MODEL.doc_InnerBox newinnerbox = new MODEL.doc_InnerBox();
                    List<MODEL.doc_InnerBox> lists = new List<MODEL.doc_InnerBox>();
                    this.dgvBarcode.DataSource = ib.GetAllInneBox(scanno);
                    lblNo.Text = kk.ToString();
                    tb13.AppendText(kk.ToString() + "--" + scanno + "\r\n");
                    lists = ib.GetAllInneBox(scanno);
                    #region  else 內容
                    if (lists == null)
                    {
                        frm.BackColor = System.Drawing.Color.Yellow;
                        msgDiv.MsgDivShow("没有内盒商品条码资料请导入", 60);
                        MessageBox.Show("请导入内盒条码型体----IE如中");
                        frm.BackColor = System.Drawing.Color.BurlyWood;
                    }
                    else
                    {
                        frm.BackColor = System.Drawing.Color.White;
                        string size = lists[0].Size;
                        #region      //日本線掃描主要判斷        
                        // 形体配色一样,内盒条码Jan 混入ean          

                        if (lblCarton.Text.Substring(0, 3) == "454")
                        {
                            //去掉型体,自然显示外箱内盒条码不正确      
                            if (lists[0].InnerBarcode.Substring(0, 3) != "454")
                            {
                                lblStyle.Text = "";

                            }
                        }
                        if (lblStyle.Text == lists[0].Name && lblColor.Text == lists[0].Color)
                        {
                            innershow(kk, size);
                            #region  
                            if (kk == 13)
                            {
                                if (lblSize1.Text == lblSize2.Text && lblSize1.Text == lblSize3.Text && lblSize1.Text == lblSize4.Text && lblSize1.Text == lblSize5.Text && lblSize1.Text == lblSize6.Text && lblSize1.Text == lblSize7.Text && lblSize1.Text == lblSize8.Text && lblSize1.Text == lblSize9.Text && lblSize1.Text == lblSize10.Text && lblSize1.Text == lblSize11.Text && lblSize1.Text == lblSize12.Text)
                                {
                                    //触发拍照
                                    getPhotos();
                                    //  cleansize();
                                    lblNo.Text = "OK";
                                    lblStyle.Text = "";
                                    msgDiv.MsgDivShow("太棒了,刷条码成功", 60);
                                    frm.BackColor = System.Drawing.Color.DarkGreen;
                                }
                                else
                                {
                                    //  DialogResult resault = MessageBox.Show("混码箱请人工核对外箱上尺码数量与内盒数量再次确认"+ "\r\n" + "检查尺码正确 请按 ----------确定" + "\r\n" + " 检查尺码错误 请按 ----------------------------------取消" , "检查尺码", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    //        cleansize();
                                    lblNo.Text = "";
                                    lblStyle.Text = "";
                                    msgDiv.MsgDivShow("混码自行核對,不顯示綠色成功", 60);
                                    //   frm.BackColor = System.Drawing.Color.DarkGreen;                                                                                                                                                                                                                                                                                                   

                                }
                            };
                            #endregion
                        }
                        else
                        {
                            if (scanno.Substring(0, 3) == "454")
                            {
                                msgDiv.MsgDivShow("更换内盒", 60);
                                cleansize();
                                lblCarton.Text = scanno.Substring(0, 13);
                                lblCartonNo.Text = scanno.Substring(9);
                                List<MODEL.doc_InnerBox> temp = new List<MODEL.doc_InnerBox>();
                                temp = ib.GetAllInneBox(scanno);
                                lblStyle.Text = temp[0].Name.ToString();
                                lblColor.Text = temp[0].Color.ToString();
                            }
                            else
                            {
                                frm.BackColor = System.Drawing.Color.Yellow;
                                msgDiv.MsgDivShow("内盒外箱条码型体不对", 60);
                                MessageBox.Show("请更换正确条码型体内盒");
                                frm.BackColor = System.Drawing.Color.BurlyWood;
                            };

                        };

                        #endregion     //日本線掃描主要判斷       
                    }
                    #endregion else 內容

                }

                #endregion else if 內容
            }

            // if ,elseif 其他狀況
            else
            {
                frm.BackColor = System.Drawing.Color.Yellow;
                msgDiv.MsgDivShow("内盒条码没有对应型体数据", 60);
                MessageBox.Show("请找IT小明查明原因");
                frm.BackColor = System.Drawing.Color.BurlyWood;
                //  MessageBox.Show("非14位外箱条码也非12,13位内盒条码");
            }
        }
      
        public void getBluetooth()
        {
            BluetoothRadio BuleRadio = BluetoothRadio.PrimaryRadio;
            if (BuleRadio==null)
            {
                MessageBox.Show("本机蓝牙设备不可用！");
                return; 
            }
            //蓝牙功能
            BluetoothClient Blueclient = new BluetoothClient();
            Dictionary<string, BluetoothAddress> deviceAddresses = new Dictionary<string, BluetoothAddress>();

            BuleRadio.Mode = RadioMode.Connectable;
            BluetoothDeviceInfo[] Devices = Blueclient.DiscoverDevices();
            lsbDevices.Items.Clear();
            deviceAddresses.Clear();
            foreach (BluetoothDeviceInfo device in Devices)
            {
                lsbDevices.Items.Add(device.DeviceName);
                deviceAddresses[device.DeviceName] = device.DeviceAddress;
            }
            

            //   MessageBox.Show("搜索设备完成,搜索到" + lsbDevices.Items.Count + "个蓝牙设备");
            //   this.lblMessage.Text = "搜索设备完成,搜索到" + lsbDevices.Items.Count + "个蓝牙设备。";

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }
    }
}