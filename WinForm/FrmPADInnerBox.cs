using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ZXing;

namespace WinForm
{
    public partial class FrmPADInnerBox : Form
    {
      //  private string filename = "Untitled";

        //１、實例化打印文檔
        PrintDocument pdDocument = new PrintDocument();

       // private string[] lines;
         private int linesPrinted;


        private PrintPreviewDialog PrintPreview = new PrintPreviewDialog();
        static FrmPADInnerBox frm = null;
        doc_InnerBoxManager ib = new doc_InnerBoxManager();

         private PrintPreviewDialog m_printPreview = null;//打印预览UI
        private PrinterSettings psetting = new PrinterSettings();//实例打印设置对象

        string responseStr = "";
        string scanno = "";
        private BarCodeClass bcc = new BarCodeClass();
        // private DocementBase _docement;
        private string[] custompo ;//型体
        private string[] cutno  ;//cutno
        private string[] boxno  ; //箱号
        private string[] barcode  ; //条码
        private string[] boxnostr  ; //箱号
        private Image[] barcodeimg; //箱号

        private int value = 0;//
        private int pageCount = 0;//页数
       PrintDocument m_printDoc = new PrintDocument();
        private float m_pageWidth = 100F;//纸张宽度 mm单位
        private float m_pageHeight = 25F;//纸张高度 mm单位
        public FrmPADInnerBox()
        {
            InitializeComponent();
            //２、訂閱事件

            //訂閱PinrtPage事件,用於繪製各個頁內容
            pdDocument.PrintPage += new PrintPageEventHandler(OnPrintPage);
            //訂閱BeginPrint事件,用於得到被打印的內容
            pdDocument.BeginPrint += new PrintEventHandler(pdDocument_BeginPrint);
            //訂閱EndPrint事件,用於釋放資源
            pdDocument.EndPrint += new PrintEventHandler(pdDocument_EndPrint);
        }    


        public static FrmPADInnerBox GetSingleton()
        {
            //if(frm==null || frm.IsDisposed)
            if (frm == null)
            {
                frm = new FrmPADInnerBox();
            }
            return frm;
        }
        private void FrmPADInnerBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
        private void butupdatadblocal_Click(object sender, EventArgs e)
        {
            ib.CopyAllInneBox();
            MessageBox.Show("同步完成");
            txtbarcode.Focus();
        }
        private void txtbarcode_TextChanged(object sender, EventArgs e)
        {
            responseStr = txtbarcode.Text;
            int dd = txtbarcode.Text.Length;
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
        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string responseStr = txtbarcode.Text;
                txtbarcode.Text = "";
                responseStr = responseStr.Trim();
                txtMsg.Text = responseStr;
                getinfobybarcode(responseStr);
                //  MessageBox.Show(responseStr + "is me");//执行任务               
            }
        }
        public void getinfobybarcode(string scanno)
        {
            doc_InnerBox[] ibox = ib.getByInneBox(scanno);
            if (ibox.Length > 0)
            {
                for (int i = 0; i < ibox.Length; i++)
                {
                    labguid.Text = Convert.ToString(ibox[i].Guid);
                    labstylecode.Text = Convert.ToString(ibox[i].InnerBarcode);
                    labname.Text = Convert.ToString(ibox[i].Name);
                    labstyle.Text = Convert.ToString(ibox[i].Style);
                    labcolor.Text = Convert.ToString(ibox[i].Color);
                    labsize.Text = Convert.ToString(ibox[i].Size);
                    labtype.Text = Convert.ToString(ibox[i].Type);
                    labnewcode.Text = Convert.ToString(ibox[i].NewCode);
                    labCustomName.Text = Convert.ToString(ibox[i].CustomName);

                }

            }
            else
            {
                labguid.Text = "";
                labstylecode.Text = "无此条码";
                labname.Text = "";
                labstyle.Text = "";
                labcolor.Text = "";
                labsize.Text = "";
                labtype.Text = "";
                labnewcode.Text = "";
                labCustomName.Text = "";
            }
        }

        private void btnCreateBarCode_Click(object sender, EventArgs e)
        {
            pictureBox1.Width = (int)(90 / 25.4 * 100);//生成条码的长度 单位mm
            pictureBox1.Height = (int)(15 / 25.4 * 100);//生成条码的长度 单位mm

            // T_PackList
            bcc.CreateBarCode(pictureBox1, txtMsg.Text);
        }
        private void btnCreateQuickMark_Click(object sender, EventArgs e)
        {
            //  bcc.CreateQuickMark(pictureBox1, txtMsg.Text);
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
        private void button2_Click(object sender, EventArgs e)
        {
            // m_printDoc.Print();//打印
        }

  
        private void btnbarcodeprint_Click(object sender, EventArgs e)
        {
          //  m_printDoc = new PrintDocument();//实例打印文档对象
           // m_printPreview = new PrintPreviewDialog();
        //    m_printDoc.PrintPage += new PrintPageEventHandler(m_printDoc_PrintPage);
            //  m_printPreview.Document = m_printDoc;//把打印文档显示到预览对话框中
            // m_printPreview.ShowDialog();



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
            DataTable ibox = ib.getPackList();
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
                boxno[i] = Convert.ToString(ibox.Rows[i]["BOXNO"]);
                boxnostr[i] = boxno[i];
                while (boxno[i].Length < 4)
                {
                    boxno[i] = "0" + boxno[i];
                }
                barcode[i] = cutno[i] + boxno[i];
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

                left = Convert.ToInt32(35 / 25.4 * 100);//条码左距离
                top = Convert.ToInt32(7 / 25.4 * 100);//条码顶距离            
                e.Graphics.DrawImage(barcodeimg[linesPrinted], left, top);//左，顶

                // y += 55;
                linesPrinted++;

                value = Convert.ToInt32(Convert.ToDouble(linesPrinted) / barcode.Length * 100);
                progressBar1.Value = value;
                label1.Text = "已打印完成" + value + " %";
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
    
}
}


    


 


