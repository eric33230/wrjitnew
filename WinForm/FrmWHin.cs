using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmWHin : Form
    {
        public FrmWHin()
        {
            InitializeComponent();
            this.dgvWHin.AutoGenerateColumns = false;
            this.dgvPackListScan.AutoGenerateColumns = false;
            this.dgvNotScan.AutoGenerateColumns = false;
        }
        static FrmWHin frm;
        public static FrmWHin GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmWHin();
            }
            return frm;
        }
        string checkScanIn = "OK";
        string scanno = "";
        string responseStr = "";
        BLL.doc_PackListShipManager plsm = new BLL.doc_PackListShipManager();
        BLL.doc_PackListShipScanManager pscanm = new BLL.doc_PackListShipScanManager();
        List<MODEL.doc_PackListShip> plslist = new List<MODEL.doc_PackListShip>();
        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            //好像沒有用到
            //  responseStr = txtPwd.Text;
            int dd = txtPwd.Text.Length;


            this.Invoke(new Action(
             delegate
             {
                 if (System.Text.RegularExpressions.Regex.IsMatch(responseStr, @".*\r\n$"))
                 {

                     //         scanno = responseStr;
                     //      scanno = scanno.Trim();
                     MessageBox.Show("1");

                 }
             }));
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
                      //      MessageBox.Show(scanno);
                      scancheck(scanno);
                      //

                  }));
            }


        }
        private void scancheck(string mcanno)
        {
            if (mcanno.Length <= 2)
            {
                return;
            }
            string part = mcanno.Substring(0, 2);
            ///重新開始掃描,清空datagridview資料 
            if (lblCheck.Text == "OK")
            {
                if (part == "QA")
                {
                    lblCheck.Text = "SCAN";
                    //            cboInOut.Enabled = false;
                    lblQA.Text = mcanno;
                    this.dgvScan.DataSource = "";
                    this.dgvScan.DataSource = pscanm.GetPackListShipScan("ERIC");
                    lblCheck.BackColor = Color.Gray;
                    lblNO.Text = "0";
                    msgDiv.MsgDivShow(" ", 60);
                    txtPwd.Focus();
                    return;
                }
            }
            // 暂停扫描下,恢复扫描 只有QA人员才可以恢复,不限定那位QA
            if (lblCheck.Text == "STOP")
            {
                if (part == "QA")
                {
                    //checkScanIn  以前寫在一起, 基本上現在沒有用到                    
                    checkScanIn = "inSCAN";
                    lblCheck.Text = "SCAN";
                    lblCheck.BackColor = Color.Gray;
                    //msgDiv.Visible = false;
                    msgDiv.MsgDivShow("开始扫描 ", 0);
                    lblQA.Text = mcanno;
                    lblRepeat.Text = "";
                    lblRepeat.BackColor = Color.Gray;
                    txtPwd.Focus();
                    return;
                }
                else
                {
                    msgDiv.MsgDivShow(" 请用QA条码开启扫描", 60);
                    txtPwd.Focus();
                    return;
                }
            }


            if (lblCheck.Text == "SCAN")
            {
                //如果在此情况下刷QA,表示斩停扫描
                if (part == "QA")
                {
                    cboInOut.Enabled = false;
                    lblCheck.Text = "STOP";
                    lblCheck.BackColor = Color.DarkOrange;
                    lblQA.Text = mcanno;
                    msgDiv.MsgDivShow("暂停扫描", 60);
                    lblRepeat.Text = "";
                    lblRepeat.BackColor = Color.Gray;
                    txtPwd.Focus();
                    return;
                }
                //更新doc_PackListShipScan 入库记录
                else if (part == "WH")
                {
                    cboInOut.Enabled = true;
                    checkScanIn = "OK";
                    msgDiv.MsgDivShow(" 仓库确认扫描", 60);
                    lblCheck.Text = "OK";
                    //更新WH 
                    lblCheck.BackColor = Color.Green;
                    lblQA.Text = mcanno;
                    lblRepeat.Text = "";
                    lblRepeat.BackColor = Color.Gray;
                    MODEL.doc_PackListShipScan plss = new MODEL.doc_PackListShipScan();
                    string mtime = lblQA.Text.Substring(0, 3) + string.Format("{0:yyMMddHHmmss}", DateTime.Now);
                    for (int i = 0; i < int.Parse(lblNO.Text); i++)
                    {
                        plss.Guid = Guid.NewGuid();
                        plss.BOXNO = int.Parse(this.dgvScan.Rows[i].Cells["BOXNO2"].Value.ToString());
                        plss.CartonBarcode = this.dgvScan.Rows[i].Cells["CartonBarcode2"].Value.ToString();
                        plss.OrderDate = this.dgvScan.Rows[i].Cells["OrderDate2"].Value.ToString();
                        plss.CustomStyleCode = this.dgvScan.Rows[i].Cells["CustomStyleCode2"].Value.ToString();
                        plss.ScanTime = Convert.ToDateTime(this.dgvScan.Rows[i].Cells["ScanTime2"].Value);
                        plss.QA = this.dgvScan.Rows[i].Cells["QA2"].Value.ToString();
                        this.dgvScan.Rows[i].Cells["WH2"].Value = lblQA.Text;
                        this.dgvScan.Rows[i].Cells["ScanBatch2"].Value = mtime;
                        plss.ScanBatch = mtime;
                        plss.ScanCount = 1;
                        if (cboInOut.SelectedIndex == 0)
                        {
                            plss.Part = "WHIN";
                        }
                        else
                        {
                            plss.Part = "WHOUT";
                        }
                        ///加入ScanOut
                        plslist = plsm.GetPacklistShipByCartonBarcode(plss.CartonBarcode);
                        plss.ScanOut = plslist[0].ScanOut.Value;
                        plss.WH = lblQA.Text;
                        pscanm.AddPackListShipScan(plss);
                        //仓库扫描入库确认 ，增加仓库库别
                        string wh = lblQA.Text.Trim();
                        wh = wh.Substring(0, 3);
                        plsm.updatePackListShipwh(wh, plslist[0].CartonBarcode.ToString(), plslist[0].CustomStyleCode.ToString());
                    }
                }
                /// 掃描紀錄 ScanIn ,這樣才能檢查 有沒有重複刷
                else
                {
                    checkScanIn = "inSCAN";
                    int mno = int.Parse(lblNO.Text);
                    lblCheck.BackColor = Color.Gray;
                    plslist = plsm.GetPacklistShipByCartonBarcode(mcanno);
                    if (plslist == null)
                    {
                        msgDiv.MsgDivShow(" 非外箱條碼", 60);
                        txtPwd.Focus();
                        return;
                    }
                    //if (plslist[0].CustomBuyName == "DCS")
                    //{       ///DCS有蛋裝不判斷

                    //}
                    //else
                    //{ 
                    #region 入库扫描
                    if (cboInOut.SelectedIndex == 0)
                    {
                        //第四次已掃瞄
                        if (plslist[0].ScanIn.Value >= 4 && plslist[0].QAOut.Value == 4)
                        {
                            msgDiv.MsgDivShow("第5次QA未扫描", 60);
                            MessageBox.Show("此條碼第4次入庫已經掃描\r\n第5次QA未扫描", "前一工序未完成", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblRepeat.Text = mcanno + "已掃描";
                            lblRepeat.BackColor = Color.Red;
                            txtPwd.Focus();
                            return;
                        }
                        //第三次掃瞄
                        if (plslist[0].ScanIn.Value >= 3 && plslist[0].QAOut.Value == 3)
                        {
                            msgDiv.MsgDivShow("第4次QA未扫描", 60);
                            MessageBox.Show("此條碼第3次入庫已經掃描\r\n第4次QA未扫描", "前一工序未完成", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblRepeat.Text = mcanno + "已掃描";
                            lblRepeat.BackColor = Color.Red;
                            txtPwd.Focus();
                            return;
                        }
                        //第二次掃瞄
                        if (plslist[0].ScanIn.Value >= 2 && plslist[0].QAOut.Value == 2)
                        {
                            msgDiv.MsgDivShow("第3次QA未扫描", 60);
                            MessageBox.Show("此條碼第2次入庫已經掃描\r\n第3次QA未扫描", "前一工序未完成", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblRepeat.Text = mcanno + "已掃描";
                            lblRepeat.BackColor = Color.Red;
                            txtPwd.Focus();
                            return;
                        }
                        //第一次掃瞄
                        if (plslist[0].ScanIn.Value >= 1 && plslist[0].QAOut.Value == 1)
                        {

                            msgDiv.MsgDivShow("第2次QA未扫描", 60);
                            MessageBox.Show("此條碼第1次入庫已經掃描\r\n第2次QA未扫描", "前一工序未完成",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            lblRepeat.Text = mcanno + "已掃描";
                            lblRepeat.BackColor = Color.Red;
                            txtPwd.Focus();
                            return;
                        }

                        //第一次掃瞄入庫,QA沒有掃描
                        if (plslist[0].QAOut.Value <= 0)
                        {
                            gbError.Visible = true;
                            gbError.BackColor = Color.OrangeRed;
                            btnCartonBarcode.Text = plslist[0].CartonBarcode;
                            btnBOXNO.Text = plslist[0].BOXNO.ToString();
                            btnScanIn.Text = plslist[0].ScanIn.ToString();
                            btnScanOut.Text = plslist[0].ScanOut.ToString();
                            btnQaout.Text = plslist[0].QAOut.ToString();
                            btnCustomStyleCode.Text = plslist[0].CustomStyleCode;
                            lbl1.Text = " QA扫描未完成";
                            lbl1.BackColor = Color.Gold;
                            btnOK.Visible = false;
                            txt1.Focus();
                            return;
                        }

                        //第二次掃瞄入庫,QA沒有掃描
                        if (plslist[0].ScanIn.Value == 1 && plslist[0].QAOut.Value <= 1)
                        {
                            gbError.Visible = true;
                            gbError.BackColor = Color.OrangeRed;
                            btnCartonBarcode.Text = plslist[0].CartonBarcode;
                            btnBOXNO.Text = plslist[0].BOXNO.ToString();
                            btnScanIn.Text = plslist[0].ScanIn.ToString();
                            btnScanOut.Text = plslist[0].ScanOut.ToString();
                            btnQaout.Text = plslist[0].QAOut.ToString();
                            btnCustomStyleCode.Text = plslist[0].CustomStyleCode;
                            lbl1.Text = " 第二次QA入库扫描未完成";
                            lbl1.BackColor = Color.Gold;
                            btnOK.Visible = false;
                            txt1.Focus();
                            return;
                        }

                        //第三次掃瞄入庫,QA沒有掃描
                        if (plslist[0].ScanIn.Value == 2 && plslist[0].QAOut.Value <= 2)
                        {
                            gbError.Visible = true;
                            gbError.BackColor = Color.OrangeRed;
                            btnCartonBarcode.Text = plslist[0].CartonBarcode;
                            btnBOXNO.Text = plslist[0].BOXNO.ToString();
                            btnScanIn.Text = plslist[0].ScanIn.ToString();
                            btnScanOut.Text = plslist[0].ScanOut.ToString();
                            btnQaout.Text = plslist[0].QAOut.ToString();
                            btnCustomStyleCode.Text = plslist[0].CustomStyleCode;
                            lbl1.Text = " 第三次QA入库扫描未完成";
                            lbl1.BackColor = Color.Gold;
                            btnOK.Visible = false;
                            txt1.Focus();
                            return;
                        }

                        //第四次掃瞄入庫,QA沒有掃描
                        if (plslist[0].ScanIn.Value == 3 && plslist[0].QAOut.Value <= 3)
                        {
                            gbError.Visible = true;
                            gbError.BackColor = Color.OrangeRed;
                            btnCartonBarcode.Text = plslist[0].CartonBarcode;
                            btnBOXNO.Text = plslist[0].BOXNO.ToString();
                            btnScanIn.Text = plslist[0].ScanIn.ToString();
                            btnScanOut.Text = plslist[0].ScanOut.ToString();
                            btnQaout.Text = plslist[0].QAOut.ToString();
                            btnCustomStyleCode.Text = plslist[0].CustomStyleCode;
                            lbl1.Text = " 前一工序沒有掃描完成,請把該箱找出重新掃描";
                            lbl1.BackColor = Color.Gold;
                            btnOK.Visible = false;
                            txt1.Focus();
                            return;
                        }
                        if (plslist[0].QAOut.Value > 3)
                        {
                            MessageBox.Show("服务器数库数据有问题，请报指令号，箱号 找IT修正");
                            return;
                        }

                        plsm.updatePackListShipScanIn(mcanno, plslist[0].CustomStyleCode.ToString());

                    }
                    #endregion
                    #region 出库扫描 
                    else if (cboInOut.SelectedIndex == 1)
                    {
                        if (plslist[0].ScanIn.Value == 0)
                        {
                            msgDiv.MsgDivShow(" 第一次沒有入庫", 60);
                            lblRepeat.Text = mcanno + "未入庫";
                            lblRepeat.BackColor = Color.Red;
                            txtPwd.Focus();
                            return;
                        }
                        if (plslist[0].ScanIn.Value == 1 && plslist[0].ScanOut.Value == 1)
                        {
                            msgDiv.MsgDivShow(" 第一次出庫已掃描", 60);
                            lblRepeat.Text = mcanno + "已掃描";
                            lblRepeat.BackColor = Color.Red;
                            txtPwd.Focus();
                            return;
                        }
                        if (plslist[0].ScanIn.Value == 2 && plslist[0].ScanOut.Value == 2)
                        {
                            msgDiv.MsgDivShow(" 第二次出庫已掃描", 60);
                            lblRepeat.Text = mcanno + "已掃描";
                            lblRepeat.BackColor = Color.Red;
                            txtPwd.Focus();
                            return;
                        }
                        if (plslist[0].ScanIn.Value == 3 && plslist[0].ScanOut.Value == 3)
                        {
                            msgDiv.MsgDivShow(" 第三次出庫已掃描", 60);
                            lblRepeat.Text = mcanno + "已掃描";
                            lblRepeat.BackColor = Color.Red;
                            txtPwd.Focus();
                            return;
                        }
                        if (plslist[0].ScanIn.Value == 4 && plslist[0].ScanOut.Value == 4)
                        {
                            msgDiv.MsgDivShow(" 第四次出庫已掃描", 60);
                            lblRepeat.Text = mcanno + "已掃描";
                            lblRepeat.BackColor = Color.Red;
                            txtPwd.Focus();
                            return;
                        }
                        plsm.updatePackListShipScanOut(mcanno, plslist[0].CustomStyleCode.ToString());
                    }
                    #endregion
                    //}
                    cboInOut.Enabled = false;
                    lblRepeat.Text = "";
                    lblRepeat.BackColor = Color.Gray;
                    // 完成顯示
                    MODEL.doc_PackListShipScan plsc = new MODEL.doc_PackListShipScan();
                    this.dgvScan.Rows.Add();
                    this.dgvScan.Rows[mno].Cells["BOXNO2"].Value = plslist[0].BOXNO;
                    this.dgvScan.Rows[mno].Cells["CartonBarcode2"].Value = plslist[0].CartonBarcode;
                    this.dgvScan.Rows[mno].Cells["Orderdate2"].Value = plslist[0].OrderDate;
                    this.dgvScan.Rows[mno].Cells["CustomStyleCode2"].Value = plslist[0].CustomStyleCode;
                    this.dgvScan.Rows[mno].Cells["ScanTime2"].Value = DateTime.Now;
                    this.dgvScan.Rows[mno].Cells["QA2"].Value = lblQA.Text;

                    this.dgvScan.Rows[mno].Cells["ScanOut2"].Value = plslist[0].ScanOut + 1;
                    mno = mno + 1;
                    lblNO.Text = mno.ToString();
                    msgDiv.MsgDivShow("正確", 0);
                    txtPwd.Focus();
                }
            }
        }     //Scan狀態結束括號                                  

        private void FrmWHin_Activated(object sender, EventArgs e)
        {
            txtPwd.Focus();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        private void FrmWHin_Load(object sender, EventArgs e)
        {
            cboInOut.SelectedIndex = 0;
            gbError.Visible = false;
        }

        public void ScanInBack(ref string checkScanIn)
        {

            if (checkScanIn == "inSCAN")
            {

                //for (int i = 0; i < this.dgvWHin.RowCount - 1; i++)
                //{

                //    //             plsm.updatePackListShipScanInBACK(this.dgvWHin.Rows[i].Cells["CartonBarcode"].Value.ToString(), this.dgvWHin.Rows[i].Cells["CustomStyleCode"].Value.ToString());

                //};
                // 先清空,在弄一個查不到的數據 ,以預防錯誤出現(跳不同數據源為空時會出錯)
                this.dgvWHin.DataSource = "";
                this.dgvWHin.DataSource = pscanm.GetPackListShipScan("ERIC");
                //    MessageBox.Show("ERIC");
            }
            checkScanIn = "OK";
        }
        private void btnScanList_Click(object sender, EventArgs e)
        {
            //     MessageBox.Show(checkScanIn);
            //當packlistship ScanIn 寫入時,又沒有完成,需要復原
            //     ScanInBack(ref checkScanIn);
            //  MessageBox.Show( checkScanIn);

            this.dtpdate.CustomFormat = "yyMMdd";
            string m = cmbWH.SelectedItem.ToString() + dtpdate.Text + cmbHour.SelectedItem.ToString() + "%";
            string m1 = cmbWH.SelectedItem.ToString() + dtpdate.Text + "24%";// +"0000";
                                                                             // MessageBox.Show(m+","+m1);
            this.dgvPackListScan.DataSource = "null";
            if (pscanm.GetScanBatch(m, m1) == null)
            {
                return;
            }
            if (pscanm.GetScanBatch(m, m1).Count >= 1)
            {
                this.dgvPackListScan.DataSource = pscanm.GetScanBatch(m, m1);
                this.dgvWHin.DataSource = pscanm.GetPackListShipScanBatch(m, m1);
                int mscan1 = dgvWHin.RowCount;
                lblTotal.Text = "";
                lblTotal.Text = mscan1.ToString();


            }

            txtPwd.Focus();
        }
        private void dgvPackListScan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblTotal.Text = "";
            if (this.dgvPackListScan.RowCount <= 0)
            {
                txtPwd.Focus();
                return;

            }

            //當packlistship ScanIn 寫入時,又沒有完成,需要復原
            ScanInBack(ref checkScanIn);


            string mbatch = this.dgvPackListScan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            this.dgvWHin.DataSource = pscanm.GetPackListShipScan(mbatch);
            txtPwd.Focus();

            //    MessageBox.Show(mbatch);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //      當packlistship ScanIn 寫入時,又沒有完成,需要復原
            //     ScanInBack(ref checkScanIn);

            if (txtOrder.Text == "")
            {
                txtOrder.Text = "请输入订单";
                // msgDiv.MsgDivShow("订单号码为空", 0);
                txtPwd.Focus();
                return;
            }
            //查詢未掃描訂單
            //第一次未掃,Scanout=0 , 入庫scanin=0,出庫scanin=1
            int mint = int.Parse(cmbNO.SelectedItem.ToString());

            //      MessageBox.Show(mint.ToString());
            this.dgvNotScan.DataSource = plsm.GetPacklistShipNoNotScanIn(txtOrder.Text, mint - 1);
            lblTotal.Text = "";
            int mnoscan = dgvNotScan.RowCount;

            this.dgvWHin.DataSource = plsm.GetPacklistShipNoYesScanIn(txtOrder.Text, mint.ToString());
            int mtotal = dgvWHin.RowCount;
            lblTotal.Text = mnoscan.ToString() + "/" + (mtotal + mnoscan).ToString();
            txtPwd.Focus();
        }
        private void dgvPackListScan_MouseClick_1(object sender, MouseEventArgs e)
        {
            txtPwd.Focus();
        }
        private void dgvPackListScan_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtPwd.Focus();
        }
        private void TOEXCEL_Click(object sender, EventArgs e)
        {
            string vg = "ShipScan";
            ImproExcel(vg);
        }
        public void ImproExcel(string VG)
        {

            SaveFileDialog sdfExport = new SaveFileDialog();
            sdfExport.Filter = "Excel 97-2003文件|*.xls|Excel 2007文件|*.xlsx";
            //   sdfExport.ShowDialog();

            if (sdfExport.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            String filename = sdfExport.FileName;
            myCommon.NPOIProgram NPOIexcel = new myCommon.NPOIProgram();
            DataTable tabl = new DataTable();
            if (VG == "ShipScan")
            {
                tabl = GetDgvToTable(dgvWHin);
            }
            else if (VG == "SizeRun")
            {
                //    tabl = GetDgvToTable(dataGridViewSizeRun);
            }

            // DataTable dt = (StyleCodeInfodataGridView.DataSource as DataTable);
            NPOIexcel.ExcelWrite(filename, tabl);//excelhelper写出           
            if (MessageBox.Show("导出成功，文件保存在" + filename.ToString()
                   + ",是否打开此文件？", "提示", MessageBoxButtons.YesNo) ==
                   DialogResult.Yes)
            {
                if (File.Exists(filename))//文件是否存在
                {
                    Process.Start(filename);//执行打开导出的文件  
                }
                else
                {
                    MessageBox.Show("文件不存在！", "提示");
                }
            }
        }
        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].HeaderText.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private void COPYCELL_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dgvWHin.CurrentCell.Value.ToString());
        }
        private void dgvWHin_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvWHin.Rows[e.RowIndex].Selected == false)
                    {
                        dgvWHin.ClearSelection();
                        dgvWHin.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvWHin.SelectedRows.Count == 1)
                    {
                        dgvWHin.CurrentCell = dgvWHin.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单

                    ctmsShipScan.Show(MousePosition.X, MousePosition.Y);
                    // MessageBox.Show("点右键了");
                }
            }
        }
        private void cboInOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPwd.Focus();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            gbError.Visible = false;
            gbError.BackColor = Color.OrangeRed;
            btnCartonBarcode.Text = "";
            btnBOXNO.Text = "";
            btnCustomStyleCode.Text = "";
            btnScanIn.Text = "";
            btnScanOut.Text = "";
            btnQaout.Text = "";
            txt1.Text = "";
            txtPwd.Focus();



        }
        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            //條碼有帶回車健
            if (e.KeyCode == Keys.Enter)
            {
                responseStr = txt1.Text;
                this.Invoke(new Action(
                  delegate
                  {
                      if (responseStr == btnCartonBarcode.Text)
                      {
                          lbl1.BackColor = Color.SpringGreen;
                          lbl1.Text = "找到,請移出";
                          gbError.BackColor = Color.LightBlue;
                          btnOK.Visible = true;
                          txt1.Text = "";
                      }
                      else
                      {
                          lbl1.Text = " 前一工序沒有掃描完成,請把該箱找出重新掃描";
                          lbl1.BackColor = Color.Gold;
                          btnOK.Visible = false;
                          gbError.BackColor = Color.OrangeRed;
                          txt1.Text = "";
                      }
                  }));
            }
        }


    }
}
