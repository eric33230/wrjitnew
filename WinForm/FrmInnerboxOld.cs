
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.POIFS;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmInnerboxOld : Form
    {
        public FrmInnerboxOld()
        {
            InitializeComponent();

            //设置不自动生列：没有绑定在Dgv 控件中的列不会显示出来
            this.dgvInnerbox.AutoGenerateColumns = false;

        //    serialPort1.Open();
        
        }
        #region 单例窗体对象  -static FrmInnerboxIn frm
        /// <summary>
        /// 单例窗体对象
        /// </summary>
        static FrmInnerboxOld frm = null;
        #endregion

        #region 单例模式，返回单个窗体对象  -static FrmInnerboxIn GetSingleton()
        /// <summary>
        /// 单例模式，返回单个窗体对象
        /// </summary>
        /// <returns></returns>
        public static FrmInnerboxOld GetSingleton()
        {
            //if(frm==null || frm.IsDisposed)
            if (frm == null)
            {
                frm = new FrmInnerboxOld();
            }
            return frm;
        }

        

        #endregion

        BLL.doc_InnerBoxManager ibm = new BLL.doc_InnerBoxManager();

        private void dgvClassList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {


        }


        private void FrmInnerboxIn_Load(object sender, EventArgs e)
        {
          //  this.dgvInnerbox.DataSource = ibm.GetEmptyBox(YearMounth.Text);
            this.dgvInnerbox.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInnerbox.ColumnHeadersHeight = 28;
           // srpinner.Open();
        }

        private void 訂單年月_Click(object sender, EventArgs e)
        {

        }
        //string scanno = "";
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

     
        }


        private void srpinner_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            


        }

        private void FrmInnerbox_ImeModeChanged(object sender, EventArgs e)
        {
           
        }

        private void FrmInnerbox_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
           // if (!sP1.IsOpen)
           //{
      
           //         //   sP1.Open();
           //}
        }

        private void FrmInnerbox_Deactivate(object sender, EventArgs e)
        {
            if (sP1.IsOpen)
            {
                sP1.Close();
            }
        }

        private void sP1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            byte[] bytes = new byte[2 * 1024];//创建缓存区接收数据
            int len = sP1.Read(bytes, 0, bytes.Length);

            //串口的相应数据
            string responseStr = Encoding.Default.GetString(bytes, 0, len);
            #region invoke
            this.Invoke(new Action
                (
                    delegate
                    {

                        tb2.AppendText(responseStr);

                        if (System.Text.RegularExpressions.Regex.IsMatch(tb2.Text, @".*\r\n$"))
                        {
                            txtBarcode.Text = tb2.Text;
                            tb2.Text = "";

                        }

                        // frm.BackColor = System.Drawing.Color.Yellow;
                        //   msgDiv.MsgDivShow("内盒条码没有对应型体数据", 60);
                        // MessageBox.Show("请找IT小明查明原因");


                    }));

            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            //------- inneer Box
            //獲得該月訂單年月的型體尺碼數量
            solist = null;
            solist = ibm.GetInnerfromOrder(YearMounth.Text);
            //    MessageBox.Show(solist.Count.ToString());
            string show = solist.Count.ToString();
            int ibcount = 0;
            List<MODEL.doc_InnerBox> iblists = null;
            iblists = new List<MODEL.doc_InnerBox>();
            // doc_innorbox 沒有尺碼的增加 ,使用 name , size, color 判斷
            for (int j = 0; j < solist.Count; j++)
            {
                test.Clear();
                MODEL.doc_InnerBox ib = new MODEL.doc_InnerBox();
                ib.Guid = System.Guid.NewGuid();
                ib.InnerBarcode = "";
                ib.Name = solist[j].Name.Trim();
                ib.Style = solist[j].Style.Trim();
                ib.Color = solist[j].Color.Trim();
                ib.Size = solist[j].Size.Trim();
                test.AppendText(ib.Name + ib.Color + ib.Size);
                ib.CustomName = solist[j].CustomName;
                ib.Type = "";
                ib.StyleCode = solist[j].Name + "." + solist[j].Color;
                ib.NewCode = "";
                iblists.Add(ib);
                if (ibm.IsInnerBoxExisits(ib.Name, ib.Color, ib.Size) < 1)
                {
                    ibm.AddInnerBox(ib);
                    ibcount++;
                }

            }

            MessageBox.Show(ibcount.ToString() + "筆內盒資料新增");
            */
        }
    }
    }
    