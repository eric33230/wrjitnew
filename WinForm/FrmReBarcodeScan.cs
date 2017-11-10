using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmReBarcodeScan : Form
    {
        static FrmReBarcodeScan frm;
        public FrmReBarcodeScan()
        {
            InitializeComponent();
        }



        public static FrmReBarcodeScan GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmReBarcodeScan();
            }
            return frm;
        }
        string responseStr = "";
        string scanno = "";
        List<MODEL.doc_PackList> dpllist = new List<MODEL.doc_PackList>();
        List<MODEL.doc_PackListScan> dplscanlist = new List<MODEL.doc_PackListScan>();

        BLL.doc_PackListManager dplm = new BLL.doc_PackListManager();
        BLL.doc_PackListScanManager dplsm = new BLL.doc_PackListScanManager();
        BLL.doc_InnerBoxManager ib = new BLL.doc_InnerBoxManager();
        BLL.T_StyleCodeInfoManager od = new BLL.T_StyleCodeInfoManager();
        BLL.doc_PackListShipManager plsm = new BLL.doc_PackListShipManager();
        //  int kk = 1;
        List<string> scannolist = new List<string>();//扫描的号码
        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            responseStr = txtPwd.Text;
            int dd = txtPwd.Text.Length;
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

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] bytes = new byte[2 * 1024];//创建缓存区接收数据
            int len = serialPort1.Read(bytes, 0, bytes.Length);
            string responseStr1 = Encoding.Default.GetString(bytes, 0, len);
            // invoke
            this.Invoke(new Action(
              delegate
              {
                  tb2.AppendText(responseStr1);
                  if (System.Text.RegularExpressions.Regex.IsMatch(tb2.Text, @".*\r\n$"))
                  {
                      scanno = tb2.Text;
                      scanno = scanno.Trim();
                      scancheck(scanno);
                      tb2.Text = "";
                  }
              }));
        }
        private void scancheck(string responseStr)
        {
            // scanInner(scanno);
            //#region 判斷
            //// 外箱條碼沒有寫在桌面上,刷不同外箱更新
            if (lblNo.Text == "OK")
            {
                txtPwd.Enabled = false;
            }
            responseStr.Trim();
            if (responseStr.Length <= 0)
                return;
            if (lblStyle.Text == "")
            {
                scanCarton(scanno);
            }
            else if (lblCarton.Text != scanno)
            { //不同号码，或是新外箱
                scanInner(scanno);
            }
        }
        private void scanCarton(string scanno)
        {
            //this.dgvBarcode.DataSource = null;
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
                //dplscanlist = dplsm.GetPackListScan(scanno, mscanout);
                //MODEL.doc_PackListScan dpls = new MODEL.doc_PackListScan();
                //if (dplscanlist != null)
                //{
                //    scancount = 0;
                //    for (int d = 0; d < dplscanlist.Count; d++)
                //    {
                //        dpls.SizeName = dplscanlist[d].SizeName;
                //        dpls.ScanNO = dplscanlist[d].ScanNO;
                //        innerMark((int)dpls.ScanNO, dpls.SizeName);
                //        scancount++;
                //    }
                //};
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
            //dpllist = null;
            MODEL.doc_PackListScan dpls = new MODEL.doc_PackListScan();
            dpllist = dplm.GetInnerBarcode(scanno, lblCarton.Text);
           // this.dgvBarcode.DataSource = dpllist;
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
                        scannolist.Add(scanno);
                    // sizeCount 箱的size号码
                    int sizeCount = dplm.GetPackListSizeCount(dpls.CartonBarcode, dpls.InnerBarcode);
                    Dictionary<string, int> list = new Dictionary<string, int>();
                    for (int i = 0; i < scannolist.Count; i++)
                    {
                        if (list.ContainsKey(scannolist[i]))
                        {
                            list[scannolist[i]]++; //相同元素值加1 相同元素个数加1
                        }
                        else
                        {
                            list.Add(scannolist[i], 1);//加入不同元素 值不相等
                        }
                    }
                    int msscanno = 0;
                    for (int j = 0; j < list.Count; j++)
                    {
                        msscanno = list[scanno];
                        if (msscanno > sizeCount)
                        {
                            MessageBox.Show("該外箱的" + dpls.SizeName + "號數量已經刷滿");
                            return;
                        }
                    }
                    dpls.ScanOut = msscanno;
                    int lblnostr = 0;
                    if (lblNo.Text == "0" ||lblNo.Text == "")
                    {
                        lblnostr = 0;
                    }
                    else
                    {
                        lblnostr = int.Parse(lblNo.Text);
                    }                       
                    int scancount = lblnostr + 1;
                    lblNo.Text = scancount.ToString();// 
                    dpls.ScanNO = scancount;
                  //  dplsm.AddPackList(dpls);
                    innerMark(scancount, dpllist[0].SizeName);
                    int mycount = (int)dpllist[0].BarcodeCount + 1; // 下一筆
                    int mtotal = dplm.GetPackListCartonCount(dpls.CartonBarcode);
                    if (mtotal == scancount)
                    {  
                        lblNo.Text = "OK";                       
                        lblStyle.Text = "";
                        msgDiv.MsgDivShow("太棒了,刷条码成功", 60);
                        frm.BackColor = System.Drawing.Color.DarkGreen;
                        txtPwd.Enabled = false;
                    }
                };


            }
            else
            {
                //該外箱沒有內盒的條碼,再判斷是否為別的外箱條碼.
                if (dplm.IsCartonBarcodetExisits(scanno) >= 1)
                {                    //新外箱
                    if (lblNo.Text != "" && lblNo.Text != "0")
                    {
                        MessageBox.Show("请先刷完本箱、或按\"刷新箱重新刷\"按钮之后再换箱");
                        return;
                    }
                    else
                    {
                        scanCarton(scanno);
                    }
                }
                else
                {
                    MessageBox.Show("非此外箱内盒","错误了",MessageBoxButtons.OK,MessageBoxIcon.Error);              
                    frm.BackColor = System.Drawing.Color.DarkRed;
                    txtPwd.Enabled = false;
                   
                }
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
            scannolist.Clear();
          //   kk = 1;

        }
        private void innerMark(int k, string size)
        {
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

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            //條碼有帶回車健
            if (e.KeyCode == Keys.Enter)
            {
                responseStr = txtPwd.Text;
                this.Invoke(new Action(
                  delegate
                  {
                      scanno = responseStr.Trim();
                      txtPwd.Text = "";
                      scancheck(scanno);
                  }));
            }
        }

        private void btnrescan_Click(object sender, EventArgs e)
        {
            if (frm.BackColor == System.Drawing.Color.DarkRed)
            {
                MessageBox.Show("请先解除错误，再确认是否真的需要重刷");
                return;
            }
            cleansize();
            txtPwd.Enabled = true;
            txtPwd.Focus();
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            if (frm.BackColor == System.Drawing.Color.DarkRed)
            {
                txtPwd.Enabled = true;
                txtPwd.Focus();
                frm.BackColor = System.Drawing.Color.White;

            }

        }

        private void FrmReBarcodeScan_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
