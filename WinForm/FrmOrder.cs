using System;
using System.Collections.Generic;
using System.Data;
using Common;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;



namespace WinForm
{
    public partial class FrmOrder : Form
    {
        public FrmOrder()
        {
            InitializeComponent();
            this.dgvOrderSize.AutoGenerateColumns = false;
        }

        static FrmOrder frm;
        public static FrmOrder GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmOrder();
            }
            return frm;
        }



        private void FrmOrder_Load(object sender, EventArgs e)
        {

        }

        BLL.T_StyleCodeInfoManager tod = new BLL.T_StyleCodeInfoManager();
        BLL.doc_OrderManager odm = new BLL.doc_OrderManager();
        BLL.doc_OrderSizeManager odsm = new BLL.doc_OrderSizeManager();
        BLL.T_SiziManager   tsm = new BLL.T_SiziManager();
        BLL.doc_PackListManager plm = new BLL.doc_PackListManager();
        BLL.doc_BuyerManager bm = new BLL.doc_BuyerManager();

        List<MODEL.T_StyleCodeInfo> todlist = new List<MODEL.T_StyleCodeInfo>();
        List<MODEL.doc_Order> odlist = new List<MODEL.doc_Order>();
        List<MODEL.T_Sizi> tsslist = new List<MODEL.T_Sizi>();
         List<MODEL.doc_Buyer> listbuyer = new List<MODEL.doc_Buyer>();
        private void btnOrderIn_Click(object sender, EventArgs e)
        {


            listbuyer = null;
            listbuyer = bm.GetlBuyerE(YearMounth.Text);
          //  if (listbuyer != null && listbuyer.Count() > 0)
                if (listbuyer != null && listbuyer.Count() > 0)
            {

                MessageBox.Show("有新的目的地,請先到客戶買主窗口新增");
                return;
            }
            else
            {

            }

            /////-----Order
            ///*
            int aa = 0;
            todlist = tod.GetAllorder(YearMounth.Text);
            if(todlist==null)
            {
                MessageBox.Show("沒有訂單資料接轉,請找IT");
            }

            for (int a = 0; a < todlist.Count; a++)
            {
            MODEL.doc_Order od = new MODEL.doc_Order();
                test.Clear();
                od.Guid = Guid.NewGuid();
                od.T_StyleCodeInfoGuid = todlist[a].Guid;
                od.AimArea = todlist[a].AimArea;
                od.Name = todlist[a].Name;
                od.Code = todlist[a].Code;
                od.GoodsTypeName = todlist[a].GoodsTypeName;
                od.CustomBuyName = todlist[a].CustomBuyName;
                if(od.CustomBuyName=="")
                {
                    if(od.AimArea=="KOBE")
                    {
                        od.CustomBuyName = "TRASICS";
                    }
                    else if(od.AimArea== "VENICE" )
                        {
                        od.CustomBuyName = "GEOX";
                    }
                    else
                    {

                    }

                }
                od.CustomName = todlist[a].CustomName;
                od.CustomStyleCode = todlist[a].CustomStyleCode;
                od.ManufactureOrder = todlist[a].ManufactureOrder;
                od.CustomPO= todlist[a].CustomPO;
                od.TotalCount = todlist[a].TotalCount;
                od.OrderDate = todlist[a].OrderDate;
                od.ProdDate = todlist[a].OrderDate;
                od.CutNo = todlist[a].CutNo;
                od.ShipMentDate = todlist[a].ShipMentDate;
                ///...............
                string[] mycode = todlist[a].Code.Split('/');
                  od.Style = mycode[0].Trim();
                //判断如果没有/ 那么长度就会为1(一段)
                if (mycode.Length > 1)
                {
                    od.Color = mycode[1].Trim();
    
                };

                od.CartonBarcodeNeed = plm.GetBuyerCartonBarcodeNeed(od.CustomBuyName, od.CustomName.ToString(), od.AimArea);
                od.Type = plm.GetBuyertype(od.CustomBuyName, od.CustomName.ToString(), od.AimArea);
                 if (plm.GetBuyertype(od.CustomBuyName, od.CustomName.ToString(), od.AimArea)==null)
                {
                    MessageBox.Show("CustomBuyName:" + od.CustomBuyName + ",Destination:" + od.AimArea + "為空請查doc_Buyer");
                    return;
                }

                if (odm.IsCustomStyleCodeExisits(todlist[a].CustomStyleCode) < 1)
                {
                    //// 先转基本的订单,计划日期,产量,TYPE都使用更新
                     odm.AddOrder(od);
                    aa++;
                }
                test.AppendText("订单" + "\r\n" + od.CustomStyleCode + "\r\n" + (a + 1).ToString() + "/" + todlist.Count.ToString());
                }
            MessageBox.Show("总共有"+ aa.ToString() +"笔订单新增");
            //沒有訂單新增,下面就不用跑了
            if(aa==0)
            {
                return;
            }

            ///*/
            ////  ------------ OderSize

           odlist = odm.GetOrder(YearMounth.Text);
            this.dgvOrderSize.DataSource = odlist;
            int dd = 0;
            for (int f = 0; f < odlist.Count; f++)
            {
       MODEL.doc_OrderSize ods = new MODEL.doc_OrderSize();
                   test.Clear();
                   ods.docOrderGuid = odlist[f] .Guid;
                  ods.CustomName = odlist[f].CustomName;
                  ods.CustomStyleCode = odlist[f].CustomStyleCode;
                   ods.TotalCount = odlist[f].TotalCount;
                   ods.Code = odlist[f].Code;
                   ods.Name =odlist[f].Name;
                   ods.Color = odlist[f].Color;
                   ods.OrderDate = odlist[f].OrderDate;
                   ods.Type = odlist[f].Type;

                tsslist = tsm.GetTSize(ods.CustomStyleCode);

                for (int d = 0; d < tsslist.Count; d++)
                {
                    test.Clear();
                    ods.Guid = Guid.NewGuid();
                    ods.Size = tsslist[d].Size;
                    ods.TsizeGuid = tsslist[d].Guid;
                    ods.SizeCount = tsslist[d].Ccount;
                    if (ods.Color != null && ods.Type!=null)
                    {
                        ods.InnerBarcode = plm.GetInnerBarcode(ods.Name, ods.Color, ods.Size, ods.Type);
                    }
                    if (odsm.IsOrderSizeExisits(ods.CustomStyleCode, ods.Size) < 1)
                    {
                        odsm.AddOrderSize(ods);
                        dd++;
                    }
                    test.AppendText(ods.CustomStyleCode + "\r\n" +(d + 1).ToString() + "/" + tsslist.Count+ "\r\n" + (f + 1).ToString() + "/" + odlist.Count.ToString());
                    
                }

            }
            MessageBox.Show("总共有" + dd.ToString() + "笔订单尺碼新增");
        }

        private void test_TextChanged(object sender, EventArgs e)
        {

        }

        
        List<MODEL.doc_OrderSize> odslist = new List<MODEL.doc_OrderSize>();        

        private void btnOrderSIze_Click(object sender, EventArgs e)
        {
            odslist = odsm.GetNoInnerBarcode(YearMounth.Text);
            if(odslist==null)
            {
                MessageBox.Show("內盒條碼都有了");
            }
            this.dgvOrderSize.DataSource = odslist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MODEL.doc_OrderSize ods = new MODEL.doc_OrderSize();
            odslist = odsm.GetNoInnerBarcode(YearMounth.Text);
            if (odslist == null)
            {
                MessageBox.Show("OK沒有新的內盒尺碼需要更新");
            }
            else
            {
                for (int g = 0; g < odslist.Count; g++)
                {

                    test.Clear();
                    string myinnerbarcode = odsm.GetInnerBarcode(odslist[g].Name, odslist[g].Color, odslist[g].Size, odslist[g].Type);
                    if (myinnerbarcode == "")
                    {
                        MessageBox.Show("沒有內盒條碼資料");
                    }
                    else
                    {
                        odsm.updateOrderSizeInnerBarcode(myinnerbarcode, odslist[g].Name, odslist[g].Color, odslist[g].Size, odslist[g].Type);
                        test.AppendText(odslist[g].Name.ToString() + "\r\n" + odslist[g].Size.ToString() + "\r\n" + (g + 1).ToString() + "/" + odslist.Count.ToString());
                    }
                }

                MessageBox.Show("尺碼內盒條碼更新OK");
            }
        }

        private void TOEXCEL_Click(object sender, EventArgs e)
        {
            string vg = "Order";
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
             myCommon.NPOIProgram  NPOIexcel = new myCommon.NPOIProgram();
            DataTable tabl = new DataTable();
            if (VG == "Order")
            {
                tabl = GetDgvToTable(dgvOrderSize);
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

        private void dgvOrderSize_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvOrderSize.Rows[e.RowIndex].Selected == false)
                    {
                        dgvOrderSize.ClearSelection();
                        dgvOrderSize.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvOrderSize.SelectedRows.Count == 1)
                    {
                        dgvOrderSize.CurrentCell = dgvOrderSize.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单

                    ctmsOrder.Show(MousePosition.X, MousePosition.Y);
                    // MessageBox.Show("点右键了");
                }
            }


        }

        private void COPYROW_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dgvOrderSize.GetClipboardContent());
        }

        private void COPYCELL_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dgvOrderSize.CurrentCell.Value.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSeeOrderSize_Click(object sender, EventArgs e)
        {
            string morderdate = YearMounth.Text;
            string mcustomname = txtCustomName.Text;
            string mname = txtName.Text;
            string mcustomstylecode = txtOrder.Text;
            this.dgvOrderSize.DataSource = odsm.SeeOrderSize(morderdate, mcustomname, mname, mcustomstylecode);
        }

        private void txtSeeOrder_Click(object sender, EventArgs e)
        {
            string morderdate = YearMounth.Text;
            string mcustomname = txtCustomName.Text;
            string mname = txtName.Text;
            string mcustomstylecode = txtOrder.Text;
            string mcustombuyname = txtBuyer.Text;
            this.dgvOrderSize.DataSource = odm.SeeOrder(morderdate, mcustomname, mname, mcustomstylecode, mcustombuyname);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FrmOrder_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
