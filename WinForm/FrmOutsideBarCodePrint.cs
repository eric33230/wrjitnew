using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using ZXing;
using System.IO;
using System.Diagnostics;
using JITSystem.MainWind;
using BLL;

namespace WinForm
{
    public partial class FrmOutsideBarCodePrint : Form
    {

        static FrmOutsideBarCodePrint frm = null;

        //  doc_InnerBoxManager ib = new doc_InnerBoxManager();


        //  private string filename = "Untitled";
        //１、實例化打印文檔
        PrintDocument pdDocument = new PrintDocument();

        // private string[] lines;
        private int linesPrinted;


        private PrintPreviewDialog PrintPreview = new PrintPreviewDialog();
        private PrintPreviewDialog m_printPreview = null;//打印预览UI
        private PrinterSettings psetting = new PrinterSettings();//实例打印设置对象

        //string responseStr = "";
       // string scanno = "";
        private BarCodeClass bcc = new BarCodeClass();
        // private DocementBase _docement;
        private string[] custompo;//型体
        private string[] cutno;//cutno
        private string[] boxno; //箱号
        private string[] barcode; //条码
        private string[] boxnostr; //箱号
        private Image[] barcodeimg; //箱号

        private int value = 0;//
        private int pageCount = 0;//页数
        PrintDocument m_printDoc = new PrintDocument();
        private float m_pageWidth = 100F;//纸张宽度 mm单位
        private float m_pageHeight = 25F;//纸张高度 mm单位

        public static FrmOutsideBarCodePrint GetSingleton()
        {
            if (frm == null)
            {
                frm = new FrmOutsideBarCodePrint();
            }
            return frm;
        }

        public FrmOutsideBarCodePrint()
        {
            InitializeComponent();

            //２、訂閱事件

            //訂閱PinrtPage事件,用於繪製各個頁內容
            pdDocument.PrintPage += new PrintPageEventHandler(OnPrintPage);
            //訂閱BeginPrint事件,用於得到被打印的內容
            pdDocument.BeginPrint += new PrintEventHandler(pdDocument_BeginPrint);
            //訂閱EndPrint事件,用於釋放資源
            pdDocument.EndPrint += new PrintEventHandler(pdDocument_EndPrint);
        //    txtCustomStyleCode.Enter +=  new EventHandler(txtCustomStyleCode_Enter);  //获得焦点事件
           // txtStyleCode.Enter += new EventHandler(txtStyleCode_Enter);
        }
       // public void txtCustomStyleCode_Enter(object sender, EventArgs e)
      //  {
      //      MessageBox.Show("获得了焦点");
      //  }
        // public void txtStyleCode_Enter(object sender, EventArgs e)
        //  {
        //     MessageBox.Show("获得了焦点");
        // }

        OutsideBarCodePrintManager obpm = new OutsideBarCodePrintManager();
        private void btnsearch_Click(object sender, EventArgs e)
        {
            dgvStyleCode.DataSource = null;
            dgvStyleCode.Columns.Clear();

            DataGridViewCheckBoxColumn ckcustomcode = new DataGridViewCheckBoxColumn();
            ckcustomcode.HeaderText = "打印";
            this.dgvStyleCode.Columns.Add(ckcustomcode);
            dgvStyleCode.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStyleCode.AllowUserToAddRows = false;
            string Code = "";
            ///
            //0  需要打印勾选
            //1  不需要打印勾选
            int CartonBarcodeNeed =0;
            if (ckneedp.Checked == true && cknop.Checked==false)
            {
                CartonBarcodeNeed = 0;  //0  需要打印勾选
            }
            if (cknop.Checked == true && ckneedp.Checked == false)
            {
                CartonBarcodeNeed = 1;  //1  不需要打印勾选
            }
            if (cknop.Checked == true && ckneedp.Checked == true)
            {
                CartonBarcodeNeed = 2;  //  都勾选
            }
            if (cknop.Checked == false && ckneedp.Checked == false)
            {
                CartonBarcodeNeed = 3; //都不勾选
            }


            bool isStyle = false;
            if (ckbStyleCode.Checked)
            {
                Code = txtStyleCode.Text;
                isStyle = true;
            }
            else if(ckbCustomStyleCode.Checked)
            {
                Code = txtCustomStyleCode.Text;
                isStyle = false;

            }
            bool isOrderDate = false;
            String orderDate = dTOrderDate.Value.Date.ToString("yyyy-MM");
            if (ckOrderDate.Checked)
            {
                isOrderDate = true;

            }
            else
            {
               // Code = txtCustomStyleCode.Text;
                isOrderDate = false;

            }

            bool isCustomStyleCode = false;
            if (ckbCustomStyleCode.Checked)
            {
                isCustomStyleCode = true;

            }
            else
            {
                isCustomStyleCode = false;

            }

            Code.Trim();
            if (isOrderDate==false && Code.Length<=0)
            {
                MessageBox.Show("至少输入一个条件");
                return;
            }

            DataTable dt = obpm.getOutsideByCustomStyleCode(isStyle, Code, CartonBarcodeNeed, isOrderDate, orderDate, isCustomStyleCode);
            dgvStyleCode.DataSource = dt;
            this.dgvStyleCode.ReadOnly = false;

            //  foreach (var item in combox.items)
            foreach (DataGridViewColumn c in dgvStyleCode.Columns)
            {
                if (c.Index != 0)
                {
                    c.ReadOnly = true;
                }
            }


            this.dgvStyleCode.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            int k = 0;
            if (dt == null)
            {
                MessageBox.Show("没有数据，请更改查询条件！");
                Cursor = Cursors.Default;
                return;


            }
            k = dt.Rows.Count;
            if (k <= 0)
            {
                MessageBox.Show("没有数据，请更改查询条件！");
                Cursor = Cursors.Default;
                return;

            }

            this.dgvStyleCode.Rows[k - 1].Selected = true;
            //this.dgvStyleCode.FirstDisplayedScrollingRowIndex = k-1;
            this.dgvStyleCode.FirstDisplayedScrollingRowIndex = k - 1;


            this.dgvStyleCode.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");

            this.dgvStyleCode.Columns["customname"].HeaderText = "客户";


            this.dgvStyleCode.Columns["style"].HeaderText = "型体";
            this.dgvStyleCode.Columns["name"].HeaderText = "客户型体";
            this.dgvStyleCode.Columns["color"].HeaderText = "颜色";
            this.dgvStyleCode.Columns["customstylecode"].HeaderText = "指令号";
            this.dgvStyleCode.Columns["custombuyname"].HeaderText = "客户买主";
            this.dgvStyleCode.Columns["orderdate"].HeaderText = "订单年月";
            this.dgvStyleCode.Columns["shipmentdate"].HeaderText = "交期";
            this.dgvStyleCode.Columns["custompo"].HeaderText = "PO";
            this.dgvStyleCode.Columns["manufactureorder"].HeaderText = "manufactureorder";
            this.dgvStyleCode.Columns["cutno"].HeaderText = "cutno";
             this.dgvStyleCode.Columns["CartonBarcodeNeed"].HeaderText = "是否需要打印";
            String Need = "";
            for (int i=0;i<dgvStyleCode.Rows.Count;i++)
            {
                Need = dgvStyleCode.Rows[i].Cells["CartonBarcodeNeed"].Value.ToString();
                if (Need=="No")
                {
                    //this.dgvStyleCode.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#93FF93");
                    this.dgvStyleCode.Rows[i].DefaultCellStyle.BackColor  = System.Drawing.ColorTranslator.FromHtml("#93FF93");
                }

            }
             
        }

        private void FrmOutsideBarCodePrint_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Width = this.Width - groupBox3.Width - 30;
            groupBox1.Height = this.Height - groupBox1.Top - 40;

            groupBox3.Left = this.Width - groupBox3.Width - 20;
            groupBox3.Height = this.Height - groupBox3.Top - 40;

            dgvBoxNo.Left = this.Width - btnsearch.Width - 10;

            btnbarcodeprint.Left= this.Width - btnbarcodeprint.Width - 10;

        }

        //生成条码
        private void btnCreateBarCode_Click(object sender, EventArgs e)
        {
            //pictureBox1.Width = (int)(90 / 25.4 * 100);//生成条码的长度 单位mm
            //pictureBox1.Height = (int)(15 / 25.4 * 100);//生成条码的长度 单位mm

            pictureBox1.Width = (int)(50 / 25.4 * 100);//生成条码的长度 单位mm
            pictureBox1.Height = (int)(15 / 25.4 * 100);//生成条码的长度 单位mm

            // T_PackList

            List<string> cartonBarcodes = new List<string>();

            //foreach (DataGridViewRow r in dgvBoxNo.Rows)
            //{
            //if (r.Cells[0].EditedFormattedValue.ToString() == "True")
            //{
            //    cartonBarcode.Add(r.Cells["CartonBarcode"].Value.ToString());
            //}
            //}
            string CartonBarcode = "";
            for (int i = 0; i < dgvBoxNo.Rows.Count; i++)
            {
                if (dgvBoxNo.Rows[i].Cells[0].Value == null)
                {
                    //break;

                }
                else if (dgvBoxNo.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    CartonBarcode = dgvBoxNo.Rows[i].Cells["CartonBarcode"].Value.ToString();
                    //txtMsg.Text = CartonBarcode;
                    cartonBarcodes.Add(CartonBarcode);
                }
            }
            if (cartonBarcodes.Count<=0)
            {
                MessageBox.Show("请勾选要打印的箱子");
                return;
            }

            //生成条码
            for(int i = 0; i < cartonBarcodes.Count; i++)
            {
                if (cartonBarcodes[i].Length > 0)
                {
                    bcc.CreateBarCode(pictureBox1, cartonBarcodes[i]);
                    //把图片保存在一个内存里
                }
            }    
                

            
          ////  string txtmsg = txtMsg.Text;
          //  if (txtmsg.Length <= 0)
          //  {
          //      MessageBox.Show("没有条码内容！");
          //      return;
          //  }

           // bcc.CreateBarCode(pictureBox1, txtMsg.Text);
        }

        private void btnCreateQuickMark_Click(object sender, EventArgs e)
        {

            List<string> cartonBarcodes = new List<string>();            
            string CartonBarcode = "";
            for (int i = 0; i < dgvBoxNo.Rows.Count; i++)
            {
                if (dgvBoxNo.Rows[i].Cells[0].Value == null)
                {

                }
                else if (dgvBoxNo.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    CartonBarcode = dgvBoxNo.Rows[i].Cells["CartonBarcode"].Value.ToString();

                    bcc.CreateQuickMark(pictureBox1, CartonBarcode);
                }
               
            }

            
        }

        private void btnBarcodeReader_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("请录入图像后再进行解码!");
                return;
            }
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBox1.Image);
            MessageBox.Show(result.Text);
        }

        private void btnbarcodeprint_Click(object sender, EventArgs e)
        {
            try
            {
                //調用打印

                pdDocument.Print();

                /*
                 * PrintDocument對象的Print()方法在PrintController類的幫助下，執行PrintPage事件。
                 */
            }
            catch (InvalidPrinterException ex)
            {
                MessageBox.Show(ex.Message, "Simple Editor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


        /// <summary>
        /// ３、得到打印內容
        /// 每個打印任務衹調用OnBeginPrint()一次。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pdDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            //  DataTable ibox = ib.getPackList();
            //List<string> Code = new List<string>();

            //**************************************
            List<string> cartonBarcodes = new List<string>();
            string CartonBarcode = "";
            for (int i = 0; i < dgvBoxNo.Rows.Count; i++)
            {
                if (dgvBoxNo.Rows[i].Cells[0].Value == null)
                {
                    //break;

                }
                else if (dgvBoxNo.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    CartonBarcode = dgvBoxNo.Rows[i].Cells["CartonBarcode"].Value.ToString();
                   // txtMsg.Text = CartonBarcode;
                    cartonBarcodes.Add(CartonBarcode);
                }
            }
                if (cartonBarcodes.Count <= 0)
                {
                    MessageBox.Show("请勾选要打印的箱子");
                    return;
                }
                //生成条码
             //   for (int i = 0; i < cartonBarcodes.Count; i++)
               // {
                   // if (cartonBarcodes[i].Length > 0)
                   // {
                      //  bcc.CreateBarCode(pictureBox1, cartonBarcodes[i]);//条码内容
                        //把图片保存在一个内存里
               //     }
              //  }

               
                     //   bcc.CreateBarCode(pictureBox1, CartonBarcode); 
            
            //*****************************************
            //Code.Add(txtCustomStyleCode.Text);
            DataTable ibox = obpm.getOutsideBycartonBarcode(cartonBarcodes);//取出其他内容

            dgvBoxNo.DataSource = ibox;
            progressBar1.Maximum = 100;
            pageCount = ibox.Rows.Count;
            progressBar1.Minimum = 0;
            custompo = new string[ibox.Rows.Count];
            boxno = new string[ibox.Rows.Count];
            boxnostr = new string[ibox.Rows.Count];
            barcode = new string[ibox.Rows.Count];
            cutno = new string[ibox.Rows.Count];
            barcodeimg = new Image[ibox.Rows.Count];
            for (int i = 0; i < ibox.Rows.Count; i++)
            {
                custompo[i] = Convert.ToString(ibox.Rows[i]["CustomPO"]);


                cutno[i] = Convert.ToString(ibox.Rows[i]["CutNo"]);
                boxno[i] = Convert.ToString(ibox.Rows[i]["BOXNO"]);//未出来BOXNO 
                boxnostr[i] = boxno[i];

                //while (boxno[i].Length < 4)
                //{
                //    boxno[i] = "0" + boxno[i];
                //}

                //if (cutno[i].Length <= 0 && ibox.Rows[i]["CustomName"].ToString() == "ASICS")
                //{
                //    cutno[i] = ibox.Rows[i]["CustomPO"].ToString().Substring(4) + ibox.Rows[i]["ManufactureOrder"].ToString().Substring(3);

                //}
                //barcode[i] = cutno[i] + boxno[i];
                barcode[i] = Convert.ToString(ibox.Rows[i]["CartonBarcode"]);

                pictureBox1.Width = (int)(70 / 25.4 * 100);//生成条码的长度 单位mm
                pictureBox1.Height = (int)(15 / 25.4 * 100);//生成条码的长度 单位mm

                bcc.CreateBarCode(pictureBox1, barcode[i]);//创建条码

                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("创建条码失败");
                    return;
                }
                else
                {


                    barcodeimg[i] = pictureBox1.Image;
                    //  pdDocument = new PrintDocument();//实例打印文档对象
                    m_printPreview = new PrintPreviewDialog();
                    //m_printPreview.PrintPreviewControl.AutoZoom = false;
                    //取得屏幕大小
                    //  m_printPreview.PrintPreviewControl.Zoom = 1;
                

                    m_printPreview.Width = Screen.PrimaryScreen.Bounds.Width;
                    m_printPreview.Height = Screen.PrimaryScreen.Bounds.Height;



                    //自定义纸张大小
                    pdDocument.DefaultPageSettings.PaperSize = new PaperSize("newPage100X25"
                   , (int)(m_pageWidth / 25.4 * 100)
                   , (int)(m_pageHeight / 25.4 * 100));

                    //自定义图片内容整体上间距/左间距
                    pdDocument.OriginAtMargins = true;
                    pdDocument.DefaultPageSettings.Margins.Top = (int)(0 / 25.4 * 100);//顶边距离 
                    pdDocument.DefaultPageSettings.Margins.Left = (int)(0 / 25.4 * 100);  //左边距离
                    //currentPageIndex = i;
                }
                //// }
                //currentPageIndex++;      //加新页
                ////if (currentPageIndex < pageCount)
                ////{
                ////    e.HasMorePages = true;  //如果小于定义页 那么增加新的页数
                ////}
                ////else
                ////{
                ////    e.HasMorePages = false; //停止增加新的页数
                ////    currentPageIndex = 0;
                ////}
                ////  }

                ////打印事件
                ////    m_printDoc.PrintPage += new PrintPageEventHandler(m_printDoc_PrintPage);
                //// m_printDoc_PrintPage( );
                ////m_printDoc 要打印的内容
                //m_printPreview.Document = m_printDoc;//把打印文档显示到预览对话框中

                ////不显示对话框
                //PrintController printController = new StandardPrintController();
                //m_printDoc.PrintController = printController;

                //m_printPreview.ShowDialog();
                ////   m_printDoc.Print();

                ////value = Convert.ToInt32(Convert.ToDouble(currentPageIndex) / ibox.Rows.Count * 100);
                ////progressBar1.Value = value;
                ////label1.Text = "已打印完成" + value + " %";

                ////m_printPreview.ShowDialog();
                ////m_printDoc.Print();
                ////  _docement.showPrintPreviewDialog();
                ////  }
                ////  _docement.showPrintPreviewDialog();
            }
        }




        /// <summary>
        /// ４、繪制多個打印頁面
        /// printDocument的PrintPage事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            /*
             * 得到TextBox中每行的字符串數組
             * \n換行
             * \r回車
             */

            //int x = 20;
            //int y = 20;
            if(barcode==null || barcode.Length<=0)
            {
             //   MessageBox.Show("取消打印");
                return;
            }
            while (linesPrinted < barcode.Length)
            {
                //繪製要打印的頁面
                //创建文本信息
                int left = Convert.ToInt32(40 / 25.4 * 100);//左距离
                int top = Convert.ToInt32(1 / 25.4 * 100);//顶距离
                e.Graphics.DrawString(custompo[linesPrinted], new Font("黑体", 17), Brushes.Black, left, top);//型体

                left = Convert.ToInt32(2 / 25.4 * 100);//左距离
                top = Convert.ToInt32(7 / 25.4 * 100);//顶距离
                e.Graphics.DrawString(boxnostr[linesPrinted], new Font("黑体", 30), Brushes.Black, left, top);//号码

                left = Convert.ToInt32(25 / 25.4 * 100);//条码左距离
                top = Convert.ToInt32(7 / 25.4 * 100);//条码顶距离            
                e.Graphics.DrawImage(barcodeimg[linesPrinted], left, top);//左，顶

                // y += 55;
                linesPrinted++;

                value = Convert.ToInt32(Convert.ToDouble(linesPrinted) / barcode.Length * 100);
                progressBar1.Value = value;
                msg.Text = "已打印完成" + value + " %";
               // msg.Text = "";
                //progressBar1.Value = 0;
               // pictureBox1.Image = null;

                //判斷超過一頁時，允許進行多頁打印
                if (barcode.Length >= linesPrinted)
                {
                    //允許多頁打印
                    e.HasMorePages = true;

                    /*
                     * PrintPageEventArgs類的HaeMorePages屬性為True時，通知控件器，必須再次調用OnPrintPage()方法，打印一個頁面。
                     * PrintLoopI()有一個用於每個要打印的頁面的序例。如果HasMorePages是False，PrintLoop()就會停止。
                     */
                    return;
                }
               
                // pictureBox1.

            }

            linesPrinted = 0;
            //繪制完成後，關閉多頁打印功能
            e.HasMorePages = false;

        }

        /// <summary>  
        ///５、EndPrint事件,釋放資源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pdDocument_EndPrint(object sender, PrintEventArgs e)
        {
            //變量Lines占用和引用的字符串數組，現在釋放
            custompo = null;
            cutno = null;
            boxno = null;
            barcode = null;
            boxnostr = null;
        }

        private void dgvStyleCode_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBoxNo.DataSource = null;
            dgvBoxNo.Columns.Clear();
            List<string> Code=new List<string>();
            Code.Add(this.dgvStyleCode["customstylecode", e.RowIndex].Value.ToString());
            DataTable table = obpm.getOutsideByCustomStyleBox(Code);
            DataGridViewCheckBoxColumn ckprint = new DataGridViewCheckBoxColumn();
            ckprint.HeaderText = "打印";
            this.dgvBoxNo.Columns.Add(ckprint);
            dgvBoxNo.DataSource = table;
            this.dgvBoxNo.ReadOnly = false;
            this.dgvBoxNo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvBoxNo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBoxNo.AllowUserToAddRows = false;
            int k = 0;
            if (table == null)
            {
                MessageBox.Show("没有数据，请更改查询条件！");
                Cursor = Cursors.Default;
                return;
            }
            k = table.Rows.Count;
            if (k <= 0)
            {
                MessageBox.Show("没有数据，请更改查询条件！");
                Cursor = Cursors.Default;
                return;

            }

            foreach (DataGridViewColumn c in dgvBoxNo.Columns)
            {
                if (c.Index != 0)
                {
                    c.ReadOnly = true;
                }
            }
            this.dgvBoxNo.Rows[k - 1].Selected = true;
            //this.dgvStyleCode.FirstDisplayedScrollingRowIndex = k-1;
            this.dgvBoxNo.FirstDisplayedScrollingRowIndex = k - 1;
            this.dgvBoxNo.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
            this.dgvBoxNo.Columns["CustomStyleCode"].HeaderText = "指令号";
            this.dgvBoxNo.Columns["CartonBarcode"].HeaderText = "外箱条码";
            this.dgvBoxNo.Columns["BOXNO"].HeaderText = "箱号";
        }


       

        private void FrmOutsideBarCodePrint_Load(object sender, EventArgs e)
        {
            ckbCustomStyleCode.Checked = true;
            ckneedp.Checked = true;
            btnBarcodeReader.Visible = false;
            btnCreateQuickMark.Visible = false;
            btnCreateBarCode.Visible = false;
        }

        private void txtCustomStyleCode_Enter(object sender, EventArgs e)
        {
           
            ckbCustomStyleCode.Checked = true;
            ckbStyleCode.Checked = false;
            ckOrderDate.Checked = false;


        }

        private void txtStyleCode_Enter(object sender, EventArgs e)
        {
            
            ckbStyleCode.Checked = true;
            ckbCustomStyleCode.Checked = false;
            ckOrderDate.Checked = false;

        }

        private void btnselectallcustomcode_Click(object sender, EventArgs e)
        {
            bool isallselect = false;
            foreach (DataGridViewRow r in dgvStyleCode.Rows)
            {
                if (r.Cells[0].EditedFormattedValue.ToString() == "True")
                {
                    isallselect = true;
                    btnselectallcustomcode.Text = "全选";

                }
                else
                {
                    isallselect = false;
                    btnselectallcustomcode.Text = "全不选";

                }

            }
            selectallcustomcode(isallselect);
        }
        public void selectallcustomcode(bool isallselect)
        {
            if (isallselect)
            {
                foreach (DataGridViewRow r in dgvStyleCode.Rows)
                {
                    r.Cells[0].Value = false;

                }
            }
            else
            {
                foreach (DataGridViewRow r in dgvStyleCode.Rows)
                {
                    r.Cells[0].Value = true;

                }
            }
        }

        private void btnselectallboxno_Click(object sender, EventArgs e)
        {
            bool isallselect = false;   
           foreach (DataGridViewRow r in dgvBoxNo.Rows)
                        {
                            if (r.Cells[0].EditedFormattedValue.ToString() == "True")
                            {
                                isallselect = true;
                                btnselectallboxno.Text = "全选";
                                break;

                            }
                            else
                            {
                                isallselect = false;
                                btnselectallboxno.Text = "全不选";
                                break;
                            }
                        }

            //Thread thread = new Thread(new ThreadStart(selectallboxno(isallselect)));
            //thread.IsBackground = true;
            //thread.Start();

            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = 100;

            selectallboxno(isallselect);

        }
        public void selectallboxno(bool isallselect)
        {

             

            if (isallselect)
            {
                foreach (DataGridViewRow r in dgvBoxNo.Rows)
                {
                    this.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        r.Cells[0].Value = false;
                    }));
                }
            }
            else
            {
                foreach (DataGridViewRow r in dgvBoxNo.Rows)
                {
                    this.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        r.Cells[0].Value = true; 
                    }));
                }
            }
        }
        

        private void dgvStyleCode_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }

        private void dgvBoxNo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }

        private void btnAddSelect_Click(object sender, EventArgs e)
        {
            dgvBoxNo.DataSource = null;
            dgvBoxNo.Columns.Clear();
            List<string> customstylecodes = new List<string>();
            string codes = "";
            foreach(DataGridViewRow r in dgvStyleCode.Rows)
            {
                if (r.Cells[0].EditedFormattedValue.ToString() == "True")
                {
                    // Code = this.dgvStyleCode["customstylecode", e.RowIndex].Value.ToString();
                    codes = r.Cells["customstylecode"].Value.ToString();
                    if (codes.Length > 0)
                    {
                        customstylecodes.Add(codes);
                    }
                }
            }
            DataTable table = obpm.getOutsideByCustomStyleBox(customstylecodes);


            
           
           
            DataGridViewCheckBoxColumn ckprint = new DataGridViewCheckBoxColumn();
            ckprint.HeaderText = "打印";
            this.dgvBoxNo.Columns.Add(ckprint);
            dgvBoxNo.DataSource = table;
            this.dgvBoxNo.ReadOnly = false;
            this.dgvBoxNo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvBoxNo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBoxNo.AllowUserToAddRows = false;
            int k = 0;
            if (table == null)
            {
                MessageBox.Show("没有数据，请更改查询条件！");
                Cursor = Cursors.Default;
                return;
            }
            k = table.Rows.Count;
            if (k <= 0)
            {
                MessageBox.Show("没有数据，请更改查询条件！");
                Cursor = Cursors.Default;
                return;

            }

            foreach (DataGridViewColumn c in dgvBoxNo.Columns)
            {
                if (c.Index != 0)
                {
                    c.ReadOnly = true;
                }
            }
            this.dgvBoxNo.Rows[k - 1].Selected = true;
            //this.dgvStyleCode.FirstDisplayedScrollingRowIndex = k-1;
            this.dgvBoxNo.FirstDisplayedScrollingRowIndex = k - 1;
            this.dgvBoxNo.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
            this.dgvBoxNo.Columns["CustomStyleCode"].HeaderText = "指令号";
            this.dgvBoxNo.Columns["CartonBarcode"].HeaderText = "外箱条码";
            this.dgvBoxNo.Columns["BOXNO"].HeaderText = "箱号";

        }

        private void ckOrderDate_CheckedChanged(object sender, EventArgs e)
        {
          if(  ckOrderDate.Checked == true){
                ckbStyleCode.Checked = false;
                ckbCustomStyleCode.Checked = false;
            }
        }

        private void ckbCustomStyleCode_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCustomStyleCode.Checked == true)
            {
                ckbStyleCode.Checked = false;
                ckOrderDate.Checked = false;
            }
        }

        private void ckbStyleCode_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbStyleCode.Checked == true)
            {
                ckOrderDate.Checked = false;
                ckbCustomStyleCode.Checked = false;
            }
        }

        private void dTOrderDate_Enter(object sender, EventArgs e)
        {
            ckOrderDate.Checked = true;
            ckbStyleCode.Checked = false;
            ckbCustomStyleCode.Checked = false;
        }

        private void meCopyRows_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dgvStyleCode.GetClipboardContent());
        }

        private void meCopyCell_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dgvStyleCode.CurrentCell.Value.ToString());
        }

        private void meImproExcel_Click(object sender, EventArgs e)
        {

            ImproExcel( );
          //  MessageBox.Show("稍等");
        }

        private void dgvStyleCode_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvStyleCode.Rows[e.RowIndex].Selected == false)
                    {
                        dgvStyleCode.ClearSelection();
                        dgvStyleCode.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvStyleCode.SelectedRows.Count == 1)
                    {
                        dgvStyleCode.CurrentCell = dgvStyleCode.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单

                    meEdit.Show(MousePosition.X, MousePosition.Y);
                    // MessageBox.Show("点右键了");
                }
            }
        }
        public void ImproExcel()
        {

            SaveFileDialog sdfExport = new SaveFileDialog();
            sdfExport.Filter = "Excel 97-2003文件|*.xls|Excel 2007文件|*.xlsx";
            //   sdfExport.ShowDialog();

            if (sdfExport.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            String filename = sdfExport.FileName;
            NPOIProgram NPOIexcel = new NPOIProgram();
            DataTable tabl = new DataTable();

            tabl = GetDgvToTable(dgvStyleCode);


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
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
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

        private void FrmOutsideBarCodePrint_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}

 

