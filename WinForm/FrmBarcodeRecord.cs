using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Data;
using System.Configuration;
using System.ComponentModel;
using System.Net;

namespace WinForm
{
    public partial class FrmBarcodeRecord : Form
    {
        /// <summary>
        /// 上传图片用
        /// </summary>
        public static string ftpServerIP = "ftp://192.168.98.200";
        public static string ftpUserID = "QA";
        public static string ftpPassword = "qa1";
        string hname = Dns.GetHostName(); //得到本机的主机名  
        string BKDisk = @"d:\";//备份盘 默认
        String sourcePath = @"c:\WRJIT\IMG\"; //默认
        bool isDisk = false;//是否有盘符和目标位置是否可写//本地备份
        DateTime dt;    //记时  

        BackgroundWorker bgWorker = new BackgroundWorker();
        DataTable tpmdt = new DataTable();//保存下载的记录
        public delegate void OutDelegate(DataTable dt);
        public delegate void SetColour(string sip, Color colour, object value);
        public FrmBarcodeRecord()
        {
            InitializeComponent();
            this.dgvBarcode.AutoGenerateColumns = false;

            // InitializeComponent();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            //bgWorker.DoWork += DoWork_Handler;
            //bgWorker.DoWork += DoWork_Link;
            //bgWorker.ProgressChanged += ProgressChanged_Handler;
            //bgWorker.RunWorkerCompleted += RunWorkerCompleted_Handler;

            //    serialPort1.Open();
        }


        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        public int selectedDeviceIndex = 0;
        //  string hname = Dns.GetHostName(); //得到本机的主机名  
        string scanno = "";
        string responseStr = "";


        static FrmBarcodeRecord frm;
        public static FrmBarcodeRecord GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmBarcodeRecord();
            }
            return frm;
        }


        //Com口配置
        private static readonly string COM = ConfigurationManager.ConnectionStrings["COM"].ConnectionString;
        //       private static readonly string Bluetooth = ConfigurationManager.ConnectionStrings["Bluetooth"].ConnectionString;

        private void FrmBarcodeRecord_Load(object sender, EventArgs e)
        {
            // comboBox1.Visible = false;
            // comboBox1.SelectedIndex = 1;
            txtPwd.Focus();
            //摄像头  
            getcb();
            // USB接口掃描

            //COME口掃描
            //serialPort1.PortName = COM;
            //serialPort1.Open();
        }


        //拍照
        private void getPhotos()
        {
            MessageBox.Show("我要拍照了");
            getPhoto();
        }

        private void btnRgetcb_Click(object sender, EventArgs e)
        {
            getcb();
        }

        public void getcb()
        {

            if (tscbxCameras.Items.Count > 0)
            {
                tscbxCameras.Items.Clear();
            }

            try
            {

                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    MessageBox.Show("没有摄像头");
                    return;
                    //  throw new ApplicationException();
                }
                //       btnRgetcb.Visible = false;
                foreach (FilterInfo device in videoDevices)
                {
                    tscbxCameras.Items.Add(device.Name);
                }
                tscbxCameras.SelectedIndex = 0;
            }
            catch (ApplicationException ex)
            {
                tscbxCameras.Items.Add("No local capture devices");
                MessageBox.Show(ex.ToString() + "\r\n" + "没有摄像头");
                btnRgetcb.Visible = true;
                videoDevices = null;
            }
        }





        List<MODEL.doc_PackList> dpllist = new List<MODEL.doc_PackList>();
        List<MODEL.doc_PackListScan> dplscanlist = new List<MODEL.doc_PackListScan>();

        BLL.doc_PackListManager dplm = new BLL.doc_PackListManager();
        BLL.doc_PackListScanManager dplsm = new BLL.doc_PackListScanManager();
        BLL.doc_InnerBoxManager ib = new BLL.doc_InnerBoxManager();
        BLL.T_StyleCodeInfoManager od = new BLL.T_StyleCodeInfoManager();
        BLL.doc_PackListShipManager plsm = new BLL.doc_PackListShipManager();

        int kk = 1;


        /// <summary>
        ///  USB條碼接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {


            //條碼有帶回車健
            if (e.KeyCode == Keys.Enter)
            {
                responseStr = txtPwd.Text;
                // invoke
                this.Invoke(new Action(
                  delegate
                  {
                      //  tb2.Text = "";
                      //tb2.AppendText(responseStr);

                      //     scanno = tb2.Text;
                      scanno = responseStr.Trim();
                      txtPwd.Text = "";
                      scancheck(scanno);
                      //errorcheck(scanno);
                      //

                  }));
            }


        }



        /// <summary>
        ///  serialPort  数据接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            byte[] bytes = new byte[2 * 1024];//创建缓存区接收数据
            int len = serialPort1.Read(bytes, 0, bytes.Length);

            //串口的相应数据
            string responseStr1 = Encoding.Default.GetString(bytes, 0, len);
            // invoke
            this.Invoke(new Action(
              delegate
              {
                  // tb2.AppendText(responseStr1);
                  txtError.AppendText(responseStr1);

                  ////  判断
                  //#region 判斷
                  //if (System.Text.RegularExpressions.Regex.IsMatch(tb2.Text, @".*\r\n$"))

                  //{
                  //    scanno = tb2.Text;
                  //    scanno = scanno.Trim();
                  //    scancheck(scanno);
                  //    ///
                  //     errorcheck(scanno);
                  //    tb2.Text = "";
                  //}

                  if (System.Text.RegularExpressions.Regex.IsMatch(txtError.Text, @".*\r\n$"))

                  {
                      scanno = txtError.Text;
                      scanno = scanno.Trim();
                      //scancheck(scanno);
                      ///
                      errorcheck(scanno);
                      txtError.Text = "";
                  }
                  //#endregion
              }));



        }


        private void scancheck(string responseStr)
        {
            if (responseStr.Length<=0)
                return;
             
            if (lblStyle.Text == "")
            {
                scanCarton(responseStr);

            }
            else if (lblCarton.Text != responseStr)
            {

                scanInner(responseStr);

            }
            else
            {
                msgDiv.MsgDivShow(" 外箱条码重複刷", 60);
                
            }
        }

        private void scanCarton(string scanno)
        {
            this.dgvBarcode.DataSource = null;
            int scancount = 0;
            dpllist = dplm.GetCartonBarcode(scanno);
            tb13.Clear();
            cleansize();
            if (dpllist != null)
            {
                MODEL.doc_PackList dpl = new MODEL.doc_PackList();
                ///顯示外箱訊息
                lblCarton.Text = scanno;
                lblCartonNo.Text = dpllist[0].CustomStyleCode;
                lblStyle.Text = "STYLE:" + dpllist[0].Name;
                lblColor.Text = "COLOR:" + dpllist[0].Color;
                lblBOXNO.Text = dpllist[0].BOXNO.ToString();
                //顯示該箱尺碼明細
                tb13.AppendText("  QTY" + "  SIZE" + "\r\n");
                for (int c = 0; c < dpllist.Count; c++)
                {
                    tb13.AppendText("   " + dpllist[c].TotalCount + "    " + dpllist[c].SizeName + "\r\n");
                    //  tb13.AppendText("QTY:"+ dpllist[c].TotalCount+"    SIZE:" + dpllist[c].SizeName+ "\r\n");
                };


                int mscanout;
                if (plsm.GetScanOut(lblCarton.Text, lblCartonNo.Text) == null)
                {
                    mscanout = 1;
                }
                else
                {
                    mscanout = (int)plsm.GetScanOut(lblCarton.Text, lblCartonNo.Text);
                }



                ///把以前已刷完的資料叫出來 顯示已刷尺碼
                dplscanlist = dplsm.GetPackListScan(scanno, mscanout);
                MODEL.doc_PackListScan dpls = new MODEL.doc_PackListScan();

                if (dplscanlist != null)
                {
                    scancount = 0;
                    for (int d = 0; d < dplscanlist.Count; d++)
                    {
                        dpls.SizeName = dplscanlist[d].SizeName;
                        dpls.ScanNO = dplscanlist[d].ScanNO;
                        innerMark((int)dpls.ScanNO, dpls.SizeName);
                        scancount++;
                    }

                };
                /// 如果刷滿 顯示OK              
                int mtotal = dplm.GetPackListCartonCount(lblCarton.Text);
                if (mtotal == scancount)
                {
                    lblNo.Text = "OK";
                    frm.BackColor = System.Drawing.Color.DarkGreen;
                }
                else
                {
                    lblNo.Text = scancount.ToString();
                };
                //判断是否有上次错误未处理
                //如果有  显示出错误
                for (int i = 0; i < dpllist.Count; i++)
                {
                    if (dpllist[i].SizeNo != null)
                    {
                        txtError.PasswordChar = '#';
                        txtPwd.Enabled = false;
                        labinfo.Text = "请解锁后再刷，注意是否已替换掉错误内盒";
                        laberrorbarcode.Text = dpllist[i].SizeNo;
                        btntempsavebox.Visible = false;
                        gbError.BackColor = System.Drawing.Color.LightBlue;
                        gbError.Visible = true;
                        txtError.Focus();
                        break;
                    }

                }
            }
            else
            {

                MessageBox.Show("沒有此外箱條碼" + "\r\n" + responseStr);
                tbSize.Clear();
            };


            // 整個裝箱明細 未刷滿的叫出來
            if (lblCartonNo.Text == "")
            {
                tbSize.Clear();
            }
            else
            {
                dpllist = dplm.GetLeftOrder(lblCartonNo.Text);
                MODEL.doc_PackList dpl = new MODEL.doc_PackList();
                tbSize.Clear();
                if (dpllist == null)
                { return; }
                for (int d = 0; d < dpllist.Count; d++)
                {
                    dpl.BOXNO = dpllist[d].BOXNO;
                    dpl.SizeName = dpllist[d].SizeName;
                    dpl.TotalCount = dpllist[d].TotalCount;
                    dpl.BarcodeCount = dpllist[d].BarcodeCount;
                    tbSize.AppendText(dpllist[d].BOXNO + " :" + dpllist[d].BarcodeCount + "/" + dpllist[d].TotalCount + " :" + dpllist[d].SizeName + "\r\n");

                }

            }


        }
        private void scanInner(string scanno)
        {
            dpllist = null;
            MODEL.doc_PackListScan dpls = new MODEL.doc_PackListScan();
            dpllist = dplm.GetInnerBarcode(scanno, lblCarton.Text);
            this.dgvBarcode.DataSource = dpllist;
            //     MessageBox.Show(dpllist1[0].Name.ToString());
            if (dpllist != null)
            {
                if (lblNo.Text == "OK")
                {
                    msgDiv.MsgDivShow(" 已經刷好了", 60);
                    return;
                }
                else
                {
                    frm.BackColor = System.Drawing.Color.White;
                    // MessageBox.Show(dpllist[0].TotalCount.ToString()+dpllist[0].BarcodeCount.ToString());
                    dpls.Guid = Guid.NewGuid();
                    dpls.CartonBarcode = lblCarton.Text;
                    dpls.InnerBarcode = scanno;
                    dpls.ScanTime = DateTime.Now;
                    dpls.SizeName = dpllist[0].SizeName;
                    dpls.CustomStyleCode = dpllist[0].CustomStyleCode;
                    dpls.OrderDate = dpllist[0].OrderDate;
                    dpls.ScanCount = 1;

                    string hname = Dns.GetHostName(); //得到本机的主机名  
                    dpls.Part = "QA" + "." + hname;



                    int mscanout;
                    ///第一次Scanout 0 所以運算GetScanout 會加1 , 然後去除Barcodecount
                    if (plsm.GetScanOut(dpls.CartonBarcode, dpls.CustomStyleCode) == null)
                    {
                        mscanout = 1;
                    }
                    else
                    {
                        mscanout = (int)plsm.GetScanOut(dpls.CartonBarcode, dpls.CustomStyleCode);
                    }
                    //把ScanShip的Scanout +1 變成第幾次
                    dpls.ScanOut = Convert.ToInt32(mscanout);
                    //加入ScanOut 可以二刷,三刷
                    if (dplm.GetPackListSizeMatch(dpls.CartonBarcode, dpls.InnerBarcode, mscanout) == 1)
                    {
                        MessageBox.Show("該外箱的" + dpls.SizeName + "號數量已經刷滿");
                        return;
                    };
                    int scancount = int.Parse(lblNo.Text) + 1;
                    lblNo.Text = scancount.ToString();// 
                    dpls.ScanNO = scancount;

                    //一刷Scanout=1 ,二刷Scanout=2 ......
                    dplsm.AddPackList(dpls);
                    innerMark(scancount, dpllist[0].SizeName);

                    int mycount = (int)dpllist[0].BarcodeCount + 1; // 下一筆
                    //更新BarcodeCount
                    dplm.updatePackListBarcodeCount(dpllist[0].Guid, mycount);


                    int mtotal = dplm.GetPackListCartonCount(dpls.CartonBarcode);

                    if (mtotal == scancount)
                    {
                        //触发拍照
                        getPhoto();
                        lblNo.Text = "OK";
                        // packlistship 的QA 刷好後記錄QAOut數量+1 (可能二刷,三刷)
                        plsm.updatePackLisQAOut(dpls.CartonBarcode, dpls.CustomStyleCode);
                        lblStyle.Text = "";
                        msgDiv.MsgDivShow("太棒了,刷条码成功", 60);
                        frm.BackColor = System.Drawing.Color.DarkGreen;
                    }
                };


            }
            else
            {
                //該外箱沒有內盒的條碼,再判斷是否為別的外箱條碼.
                if (dplm.IsCartonBarcodetExisits(scanno) >= 1)
                {
                    scanCarton(scanno);
                    msgDiv.MsgDivShow("新外箱 ", 60);
                }
                else
                {
                    txtPwd.Enabled = false;
                    frm.BackColor = System.Drawing.Color.DarkRed;
                    gbError.BackColor = System.Drawing.Color.Orange;
                    laberrorbarcode.Text = scanno;
                    txtError.Text = "";
                    gbError.Visible = true;
                    txtError.Focus();
                    //     MessageBox.Show("內盒條碼不是這外箱的尺碼"+"\r\n" + responseStr);
                    btntempsavebox.Visible = false;
                    labinfo.Text = "内盒条码不是这个外箱的尺码";
                    //保存错误
                    txtError.PasswordChar = new char();

                    string cartonbarcode = lblCarton.Text.Trim();
                    string customstylecode = lblCartonNo.Text.Trim();
                    string errorbarcode = laberrorbarcode.Text.Trim();
                    int result = dplsm.UpdateErrorBox(customstylecode, cartonbarcode, errorbarcode);
                    gbError.BackColor = System.Drawing.Color.OrangeRed;

                    //if (result <= 0)
                    //{
                    //    MessageBox.Show("保存出错");
                    //    //写入日志文件
                    //}
                    //else
                    //{
                    //    //保存成功
                    //    cleansize();
                    //    laberrorbarcode.Text = "";
                    //    gbError.Visible = false;
                    //    txtPwd.Enabled = true;
                    //    txtPwd.Focus();

                    //}

                }
            }
        }

        private void innerMark(int k, string size)
        {
            // MessageBox.Show("kk=0");
            #region            // 外箱条码的型号与内盒不同

            switch (k)
            {
                case 0:


                    break;
                case 1:
                    lblSize1.Text = size;
                    lblSize1.BackColor = System.Drawing.Color.LightBlue;

                    break;
                case 2:
                    lblSize2.Text = size;
                    if (lblSize2.Text == lblSize1.Text)
                    {
                        lblSize2.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        lblSize2.BackColor = System.Drawing.Color.LightPink;
                    }


                    break;
                case 3:
                    lblSize3.Text = size;
                    if (lblSize3.Text == lblSize1.Text)
                    {
                        lblSize3.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        lblSize3.BackColor = System.Drawing.Color.LightPink;
                    }


                    break;
                case 4:
                    lblSize4.Text = size;
                    if (lblSize4.Text == lblSize1.Text)
                    {
                        lblSize4.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        lblSize4.BackColor = System.Drawing.Color.LightPink;
                    }

                    break;
                case 5:
                    lblSize5.Text = size;
                    if (lblSize5.Text == lblSize1.Text)
                    {
                        lblSize5.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        lblSize5.BackColor = System.Drawing.Color.LightPink;
                    }

                    break;
                case 6:
                    lblSize6.Text = size;
                    if (lblSize6.Text == lblSize1.Text)
                    {
                        lblSize6.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        lblSize6.BackColor = System.Drawing.Color.LightPink;
                    }

                    break;
                case 7:
                    lblSize7.Text = size;
                    if (lblSize7.Text == lblSize1.Text)
                    {
                        lblSize7.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        lblSize7.BackColor = System.Drawing.Color.LightPink;
                    }

                    break;
                case 8:
                    lblSize8.Text = size;
                    if (lblSize8.Text == lblSize1.Text)
                    {
                        lblSize8.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        lblSize8.BackColor = System.Drawing.Color.LightPink;
                    }


                    break;
                case 9:
                    lblSize9.Text = size;
                    if (lblSize9.Text == lblSize1.Text)
                    {
                        lblSize9.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        lblSize9.BackColor = System.Drawing.Color.LightPink;
                    }

                    break;
                case 10:
                    lblSize10.Text = size;
                    if (lblSize10.Text == lblSize1.Text)
                    {
                        lblSize10.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        lblSize10.BackColor = System.Drawing.Color.LightPink;
                    }

                    break;
                case 11:
                    lblSize11.Text = size;
                    if (lblSize11.Text == lblSize1.Text)
                    {
                        lblSize11.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        lblSize11.BackColor = System.Drawing.Color.LightPink;
                    }


                    break;
                case 12:
                    lblSize12.Text = size;
                    if (lblSize12.Text == lblSize1.Text)
                    {
                        lblSize12.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else
                    {
                        lblSize12.BackColor = System.Drawing.Color.LightPink;
                    }

                    break;
                case 13:
                    tb13.AppendText(size + "\r\n");
                    tb13.BackColor = System.Drawing.Color.LightBlue;

                    break;
                default:
                    tb13.AppendText(size + "\r\n");
                    tb13.BackColor = System.Drawing.Color.LightBlue;

                    break;
            }
            #endregion

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
                                    getPhoto();
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

        private void cleansize()
        {
            lblNo.Text = "";
            lblCarton.Text = "";
            lblStyle.Text = "";
            lblCartonNo.Text = "";
            tbSize.Text = "";
            lblBOXNO.Text = "";
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




        public void getPhoto()
        {
            if (videoSource == null)
                return;
            Bitmap bitmap1 = videoSourcePlayer1.GetCurrentVideoFrame();
            Bitmap bitmap2 = videoSourcePlayer2.GetCurrentVideoFrame();
            //  videoSourcePlayer1.p
            string fileName1 = "";
            string fileName2 = "";
            // if (lblStyle.Text != "" && lblColor.Text != "" && lblSize1.Text != "")
            if (comboBox1.SelectedIndex == 0)
            {
                //    string dd = System.Environment.CurrentDirectory;
                fileName1 = lblStyle.Text + "_" + lblColor.Text + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + lblSize1.Text + "_1.jpg";
                fileName2 = lblStyle.Text + "_" + lblColor.Text + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + lblSize1.Text + "_2.jpg";

            }
            else
            {
                //  string dd = System.Environment.CurrentDirectory;
                //       fileName1 = lblStyle.Text + "_" + lblColor.Text + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + lblSize1.Text + "_1.jpg";
                //     fileName2 = lblStyle.Text + "_" + lblColor.Text + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + lblSize1.Text + "_2.jpg";
                fileName1 = lblCartonNo.Text + "_" + lblBOXNO.Text + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_1.jpg";
                fileName2 = lblCartonNo.Text + "_" + lblBOXNO.Text + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_2.jpg";
            }


            string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff") + ".jpg";
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
            if (bitmap1 != null)
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
            }
            else
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
            }
            else
            {
                selectedDeviceIndex = 1;
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
                videoSourcePlayer2.VideoSource = videoSource;
                videoSourcePlayer2.Start();
            }


        }



        private void FrmBarcodeRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            videoSourcePlayer2.SignalToStop();
            videoSourcePlayer2.WaitForStop();
            frm = null;
            serialPort1.Close();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPwd.Focus();
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            //USB使用
            //手動填資料顯示
            responseStr = txtPwd.Text;
            int dd = txtPwd.Text.Length;
            //      MessageBox.Show("txtPwd_TextChanged");
            //  txtPwd.Text = "";
            this.Invoke(new Action(
             delegate
             {

                 if (System.Text.RegularExpressions.Regex.IsMatch(responseStr, @".*\r\n$"))
                 {

                     scanno = responseStr;
                     scanno = scanno.Trim();

                 }
             }));
        }

        private void txtError_KeyDown(object sender, KeyEventArgs e)
        {

            //條碼有帶回車健
            if (e.KeyCode == Keys.Enter)
            {
                // responseStr = scanno;
                responseStr = txtError.Text;
                // invoke
                this.Invoke(new Action(
                  delegate
                  {
                      scanno = responseStr.Trim();
                      errorcheck(scanno);
                      txtError.Text = "";
                      txtError.Focus();


                  }));
            }
        }

        private void txtError_TextChanged(object sender, EventArgs e)
        {
            responseStr = txtError.Text;
            this.Invoke(new Action(
             delegate
             {

                 if (System.Text.RegularExpressions.Regex.IsMatch(responseStr, @".*\r\n$"))
                 {


                     scanno = responseStr;
                     scanno = scanno.Trim();
                     errorcheck(scanno);
                     txtError.Text = "";
                     txtError.Focus();


                 }
             }));

        }

        private void errorcheck(string responseStr)
        {


            #region 判斷

            if (gbError.BackColor == System.Drawing.Color.LightBlue)
            {
                txtError.PasswordChar = '#';
                if (responseStr == dplsm.GetErrorUserPWD())
                {
                    gbError.Visible = false;
                    txtPwd.Enabled = true;
                    txtPwd.Focus();
                    //清空
                    string cartonbarcode = lblCarton.Text.Trim();
                    string customstylecode = lblCartonNo.Text.Trim();
                    int result = dplsm.UpdateErrorBox(customstylecode, cartonbarcode);
                    cleansize();
                    scanCarton(cartonbarcode);

                }
                else
                {
                    txtError.PasswordChar = '#';
                    labinfo.Text = "解锁密码错误";
                }


            }
            else
            {
                txtError.PasswordChar = new char();


                if (responseStr == laberrorbarcode.Text)
                {
                    btntempsavebox.Visible = true;
                    labinfo.Text = "找到内盒,请解锁";
                    gbError.BackColor = System.Drawing.Color.LightBlue;

                    txtError.PasswordChar = '#';

                }
                else
                {
                    btntempsavebox.Visible = false;
                    txtError.PasswordChar = new char();
                    // txtError.PasswordChar =new char();
                    labinfo.Text = "请先找出错误的内盒,再解锁";
                    gbError.BackColor = System.Drawing.Color.OrangeRed;

                }
                txtError.Text = "";
                txtError.Focus();

            }



            //if(gbError.BackColor != System.Drawing.Color.LightBlue)
            //{
            //    labinfo.Text = "请先找出错误的内盒,再解锁";
            //    return;
            //}


            #endregion
        }

        private void cbDisks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp = cbDisks.SelectedItem.ToString();
            string[] tmps = tmp.Split('|');
            BKDisk = tmps[0];
        }

        private void btnbackimg_Click(object sender, EventArgs e)
        {
            //增加进度条
            Thread myThread = new Thread(DoData);
            myThread.IsBackground = true;
            myThread.Start(); //线程开始  
            dt = DateTime.Now;  //开始记录当前时间  
        }

        private delegate void DoDataDelegate();
        /// <summary>  
        /// 进行循环  
        /// </summary>  
        /// <param name="number"></param>  
        private void DoData()
        {

            bool upresuls = false;//上传结果
            bool bkresuls = false;//备份到D盘结果
            ////第一种方法
            //var files = Directory.GetFiles(path, "*.exe");
            //foreach (var file in files)
            //    Console.WriteLine(file);

            //第二种方法
            DirectoryInfo folder = new DirectoryInfo(sourcePath);
            int filenum = 0;
            //判断路径
            if (!Directory.Exists(sourcePath))
            {
                MessageBox.Show("文件夹' " + sourcePath + " '不存在！");
                return;
            }

            //获取文件数量
            List<string> filenames = new List<string>();
            foreach (FileInfo file in folder.GetFiles("*.jpg"))
            {
                filenames.Add(file.FullName);
                //  string filename = file.FullName;
                //Upload(filename, ftpServerIP, ftpUserID, ftpPassword);
                // Console.WriteLine(file.FullName);
                filenum++;
            }
            if (filenum <= 0)
            {
                MessageBox.Show("文件夹' " + sourcePath + " '下没有图片文件！");
                return;
            }
            /////

            if (jingdutiao.InvokeRequired)
            {
                DoDataDelegate d = DoData;
                jingdutiao.Invoke(d);
            }
            else
            {
                jingdutiao.Maximum = filenum;
                isDisk = Directory.Exists(BKDisk);
                if (!isDisk)
                {
                    MessageBox.Show("备份失败，没有" + BKDisk + "盘。只进行上传到服务器，请注意手动备份！");
                }
                //if (isDisk)
                //{
                //    MessageBox.Show("如果自动关掉软件，是被360干掉了？？");
                //}

                for (int i = 0; i < filenum; i++)
                {
                    string filename = filenames[i];
                    upresuls = Upload(filename, ftpServerIP, ftpUserID, ftpPassword);//上传
                    //盘符是否存在，存在备份，不存在 只上传
                    if (isDisk)
                    {
                        //360会杀掉？？？
                        // MessageBox.Show("如果自动关掉软件，是被360干掉了？？");
                        bkresuls = BKtoDisk(filename);//备份到D盘
                    }

                    if (upresuls && bkresuls)//上传和备份都成功的时候 删除照片
                    {

                        System.IO.File.Delete(filename);

                    }
                    labbar.Text = "正在上传" + filename;
                    jingdutiao.Value = i;
                    label11.Text = (i + 1).ToString() + "/" + filenum.ToString();


                    Application.DoEvents();
                }
                jingdutiao.Value = filenum;

                if (isDisk)//上传和备份都成功的时候 删除照片
                {
                    labbar.Text = "上传完成,本地备份完成,C盘IMG清空";
                    MessageBox.Show("上传完成,共花费时间：\r\n" + DateTime.Now.Subtract(dt).ToString() + "\r\n"
                                                    + @"备份完成,备份目录为 " + BKDisk + @"WRJIT\IMG\指令号\",
                                                    "上传、备份完成", MessageBoxButtons.OK);  //循环结束截止时间  
                }
                else
                {
                    labbar.Text = "上传完成,本地备份失败,C盘IMG不清空";

                    MessageBox.Show("上传完成,共花费时间：\r\n" + DateTime.Now.Subtract(dt).ToString() + "\r\n"
                                                    + @"注意没有备份",
                                                    "上传完成、没有备份", MessageBoxButtons.OK);  //循环结束截止时间  
                }

            }
            //测试是否上传成功，失败的怎么处理
        }
        private bool BKtoDisk(string filename)
        {
            if (!Directory.Exists(BKDisk))
            {
                MessageBox.Show("备份失败，没有" + BKDisk + "盘。");
                return false;
            }
            FileInfo fileInf = new FileInfo(filename);

            string[] dirs = fileInf.Name.Split('_');
            string dir = dirs[0];
            string ToPath = BKDisk + @"WRJITIMG\" + dir + @"\";

            if (!System.IO.Directory.Exists(ToPath))

            {
                try
                {
                    System.IO.Directory.CreateDirectory(ToPath);

                }
                catch
                {
                    MessageBox.Show("目标位置没有写入权限");
                    isDisk = false;
                    return false;

                }


            }
            string destFile = ToPath + fileInf.Name;


            if (System.IO.File.Exists(filename))

            {
                try
                {
                    //   System.IO.File.Copy(filename, destFile, true);
                }
                catch (System.Net.WebException exp)
                {
                    MessageBox.Show(exp.ToString());
                }

            }
            else
            {
                MessageBox.Show("没有找到原文件" + filename + "备份失败", "备份失败", MessageBoxButtons.OK);
                return false;
            }
            return true;

        }
        //D盘目录是否存在
        //public bool DiskPathCheck(string destFilePath)
        //{


        //    string fullDir = FtpParseDirectory(destFilePath);
        //    string[] dirs = fullDir.Split('/');
        //    string curDir = "/";
        //    for (int i = 0; i < dirs.Length; i++)
        //    {
        //        string dir = dirs[i];
        //        //如果是以/开始的路径,第一个为空    
        //        if (dir != null && dir.Length > 0)
        //        {
        //            try
        //            {
        //                curDir += dir + "/";
        //                FtpMakeDir(curDir);
        //            }
        //            catch (Exception e)
        //            {
        //                Console.Write(e);
        //            }
        //        }
        //    }
        //    return false;
        //}
        private bool Upload(string filename, string ftpServerIP, string ftpUserID, string ftpPassword)
        {

            FileInfo fileInf = new FileInfo(filename);

            string ftpPath = hname + "/";

            string[] dirs = fileInf.Name.Split('_');
            //  string curDir = "/";
            //  for (int i = 0; i < dirs.Length; i++)
            // {
            string dir = dirs[0];

            ftpPath = ftpPath + dir + "/";
            FtpWebRequest reqFTP;

            FtpCheckDirectoryExist(ftpPath);
            string uri = ftpServerIP + "/" + ftpPath + fileInf.Name;
            //FileInfo fi = new FileInfo(localFile);
            //FileStream fs = fi.OpenRead();
            //long length = fs.Length;
            //FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpServerIP + ftpPath + fi.Name);

            //reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "上传出错");
                return false;
            }
            return true;
            // MessageBox.Show("上传成功!");
        }

        //判断文件的目录是否存,不存则创建  
        public static void FtpCheckDirectoryExist(string destFilePath)
        {
            string fullDir = FtpParseDirectory(destFilePath);
            string[] dirs = fullDir.Split('/');
            string curDir = "/";
            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i];
                //如果是以/开始的路径,第一个为空    
                if (dir != null && dir.Length > 0)
                {
                    try
                    {
                        curDir += dir + "/";
                        FtpMakeDir(curDir);
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                    }
                }
            }
        }

        public static string FtpParseDirectory(string destFilePath)
        {
            return destFilePath.Substring(0, destFilePath.LastIndexOf("/"));
        }

        //创建目录  
        public static Boolean FtpMakeDir(string localFile)
        {
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpServerIP + localFile);
            req.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            req.Method = WebRequestMethods.Ftp.MakeDirectory;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                req.Abort();
                return false;
            }
            req.Abort();
            return true;
        }
        private void getDisks()
        {
            //string[] disk = Directory.GetLogicalDrives();
            System.IO.DriveInfo[] disk = System.IO.DriveInfo.GetDrives();
            for (int i = 0; i < disk.Length; i++)
            {
                if (disk[i].IsReady)
                {

                    long freespace = disk[i].TotalFreeSpace / 1024 / 1024 / 1024;
                    cbDisks.Items.Add(disk[i].Name + "|" + freespace.ToString() + "GB");
                }

            }

        }

        private void FrmBarcodeRecord_Activated(object sender, EventArgs e)
        {

            getDisks();//获取盘符
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void btnrescan_Click(object sender, EventArgs e)
        {
            FrmReBarcodeScan frm = FrmReBarcodeScan.GetSingleton();
            frm.MdiParent = this.MdiParent;
            frm.Show();
            frm.Activate();
        }

        private void btntempsavebox_Click(object sender, EventArgs e)
        {
            //if (laberrorbarcode.Text.Trim().Length <= 0)
            //{
            //    return;
            //}

            //string cartonbarcode = lblCarton.Text.Trim();
            //string customstylecode = lblCartonNo.Text.Trim();
            //string errorbarcode = laberrorbarcode.Text.Trim();
            //int result = dplsm.UpdateErrorBox(customstylecode, cartonbarcode, errorbarcode);
            //gbError.BackColor = System.Drawing.Color.OrangeRed;

            //if (result <= 0)
            //{
            //    MessageBox.Show("保存出错");
            //    //写入日志文件
            //}
            //else
            //{
                //保存成功
                cleansize();
                laberrorbarcode.Text = "";
                gbError.Visible = false;
                txtPwd.Enabled = true;
                txtPwd.Focus();

            //}
        }
    }
}
