using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static BLL.PdinventoryManager;
using static Common.myCommon;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForm
{
    public partial class Frmpdinventory : Form
    {
        BackgroundWorker bgWorker = new BackgroundWorker();
        public Frmpdinventory()
        {
            InitializeComponent();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += DoWork_downloadpdtxt; //方法名称
            bgWorker.ProgressChanged += ProgressChanged_Handler;
            bgWorker.RunWorkerCompleted += RunWorkerCompleted_Handler;
        }
        static Frmpdinventory frm;
        DataTable dt = new DataTable();
        PdinventoryManager pvm = new PdinventoryManager();
        bool issum = false;//是否需要汇总计算标志
        public static Frmpdinventory GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new Frmpdinventory();
            }
            return frm;
        }

        private void Frmpdinventory_Load(object sender, EventArgs e)
        {
            initialization();
            // loadwarehouse();



        }

        private void Frmpdinventory_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void Frmpdinventory_Resize(object sender, EventArgs e)
        {
            bgCustomStyleCodesum.Width = (int)(this.Width * 0.55);
            bgCustomStyleCodesum.Height = this.Height - 160;

            bgCustomStyleCode.Left = bgCustomStyleCodesum.Width + 3;
            bgCustomStyleCode.Height = bgCustomStyleCodesum.Height;
            bgCustomStyleCode.Width = (int)((this.Width - bgCustomStyleCodesum.Width) * 0.4) - 10;


            bgboxall.Left = bgCustomStyleCodesum.Width + bgCustomStyleCode.Width + 3;
            bgboxall.Height = bgCustomStyleCodesum.Height;
            bgboxall.Width = bgCustomStyleCode.Width;

            gbsum.Width = this.Width - 20;
            gbsum.Top = bgCustomStyleCodesum.Height + 40;

            bgnobox.Left = bgCustomStyleCodesum.Width + bgCustomStyleCode.Width + bgboxall.Width + 3;
            bgnobox.Height = bgCustomStyleCodesum.Height;
            bgnobox.Width = this.Width - bgCustomStyleCodesum.Width - bgCustomStyleCode.Width - bgboxall.Width - 15;

            btncheck.Left = this.Width - 120;

        }
        /// <summary>
        /// 获取仓库
        /// </summary>
        private void loadwarehouse()
        {
            List<string> whs = pvm.getwarehouse();
            if (whs.Count <= 0)
            {
                MessageBox.Show("加载仓库出错，请刷新重试");
                return;
            }
            cbwhs.Items.Clear();
            cbwhs.Items.Add("ALL");
            
            for (int i = 0; i < whs.Count; i++)
            {
                cbwhs.Items.Add(whs[i]);
                cbcheckwhs.Items.Add(whs[i]);
            }
            cbwhs.Items.Add("NOWH");
            cbcheckwhs.Items.Add("NOWH");

            cbwhs.SelectedIndex = 0;

        }
        private void initialization()
        {
            loadwarehouse();
            this.dtpstardata.Format = DateTimePickerFormat.Custom;
            this.dtpstardata.CustomFormat = "yyyy-MM";
            this.dtpenddata.Format = DateTimePickerFormat.Custom;
            this.dtpenddata.CustomFormat = "yyyy-MM";
            dgvcustomstylecode.RowHeadersWidth = 30;
            dgvcustomstylecodebox.RowHeadersWidth = 30;
            dgvboxall.RowHeadersWidth = 30;
            dgvnobox.RowHeadersWidth = 30;
            btnCancel.Visible = false;
           
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            loaddate();

           


        }

        private void dgvcustomstylecode_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }

        private void dgvcustomstylecode_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {

                return;
            }
            Cursor = Cursors.WaitCursor;
            //Cursor.Clip = frm.Bounds;


            #region 获取指令箱明细
            string CustomStyleCode = this.dgvcustomstylecode["CustomStyleCode", e.RowIndex].Value.ToString();

            List<string> strkey = new List<string>();
            List<string> strvalue = new List<string>();
            List<Pdinfos> listpd = new List<Pdinfos>();
            strkey.Add("CustomStyleCode");
            strvalue.Add(CustomStyleCode);
            issum = false;
            listpd = pvm.getcustomstyle(strkey, strvalue, issum);

            if (listpd.Count <= 0)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("此指令号下无库存。");

                return;
            }
            dgvcustomstylecodebox.DataSource = listpd;


            this.dgvcustomstylecodebox.Columns["CustomName"].HeaderText = "客户";
            this.dgvcustomstylecodebox.Columns["CustomName"].Visible = false;
            this.dgvcustomstylecodebox.Columns["Name"].HeaderText = "客户型体";
            this.dgvcustomstylecodebox.Columns["Name"].Visible = false;

            // this.dgvcustomstylecode.Columns["CustomName"].Width = 80;
            this.dgvcustomstylecodebox.Columns["Code"].HeaderText = "工厂型体";
            this.dgvcustomstylecodebox.Columns["Code"].Visible = false;
            //this.dgvcustomstylecode.Columns["Code"].Width = 120;
            this.dgvcustomstylecodebox.Columns["CustomStyleCode"].HeaderText = "指令号";
            this.dgvcustomstylecodebox.Columns["OrderDate"].HeaderText = "订单年月";
            this.dgvcustomstylecodebox.Columns["OrderDate"].Visible = false;
            this.dgvcustomstylecodebox.Columns["WH"].HeaderText = "仓库";
            this.dgvcustomstylecodebox.Columns["WH"].Visible = false;
            this.dgvcustomstylecodebox.Columns["pdcounts"].HeaderText = "库存数量";
            this.dgvcustomstylecodebox.Columns["pdcounts"].Visible = false;
            this.dgvcustomstylecodebox.Columns["CartonBarcode"].HeaderText = "外箱条码";
            this.dgvcustomstylecodebox.Columns["BOXNO"].HeaderText = "箱号";
            this.dgvcustomstylecodebox.Columns["Boxsumcount"].HeaderText = "指令箱数";
            this.dgvcustomstylecodebox.Columns["Boxsumcount"].Visible = false;
            this.dgvcustomstylecodebox.Columns["TotalCount"].HeaderText = "指令双数";
            this.dgvcustomstylecodebox.Columns["TotalCount"].Visible = false;
            // Application.DoEvents();
            #endregion
            #region 获取箱双明细
            string wherestr = "";
            for (int i = 0; i < listpd.Count; i++)
            {
                wherestr = wherestr + " CartonBarcode ='" + listpd[i].CartonBarcode + "' or ";
            }



            List<BoxAlls> boxall = pvm.getBoxAllbyCartonBarcode(CustomStyleCode, wherestr);
            dgvboxall.DataSource = boxall;
            this.dgvboxall.Columns["CartonBarcode"].HeaderText = "外箱条码";

            //   AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
            this.dgvboxall.Columns["SizeName"].HeaderText = "SIZE";
            this.dgvboxall.Columns["sumcount"].HeaderText = "双数";

            //取得单独的箱号
            List<BoxAlls> customNames = boxall.MyDistinct(p => p.CartonBarcode).ToList<BoxAlls>();

            //分成两个集合
            List<BoxAlls> evencustomNames = new List<BoxAlls>(); //偶数
            List<BoxAlls> oddcustomNames = new List<BoxAlls>(); //奇数

            //取偶数集合
            for (int i = 0; i < customNames.Count; i++)
            {
                if (i % 2 == 0) //%取余 偶数                    
                {
                    evencustomNames.Add(customNames[i]);
                }
            }
            //取奇数集合
            for (int i = 0; i < customNames.Count; i++)
            {
                if (i % 2 != 0) //%取余 奇数
                {
                    oddcustomNames.Add(customNames[i]);
                }
            }
            //比较偶数 给色彩
            for (int i = 0; i < boxall.Count; i++)
            {
                for (int j = 0; j < evencustomNames.Count; j++)
                {
                    if (boxall[i].CartonBarcode.Equals(evencustomNames[j].CartonBarcode))// 一个颜色
                    {
                        this.dgvboxall.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#93FF93");

                    }
                }

            }
            for (int i = 0; i < boxall.Count; i++)
            {
                for (int j = 0; j < oddcustomNames.Count; j++)
                {
                    if (boxall[i].CartonBarcode.Equals(oddcustomNames[j].CartonBarcode))//另一个颜色
                    {
                        this.dgvboxall.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FF93FF");

                    }
                }

            }

            //计算双数
            int sumcount = 0;
            for (int i = 0; i < boxall.Count; i++)
            {
                sumcount = sumcount + boxall[i].sumcount;
            }
            labsumcount.Text = sumcount.ToString();//单指令库存双
            labpdboxcount.Text = customNames.Count.ToString(); //单指令库存箱
            labcustomcountbox.Text = listpd[0].Boxsumcount; //单指令箱数
            labcustomcount.Text = listpd[0].TotalCount;//单指令双数
            labpdnoboxcount.Text = (Convert.ToInt32(listpd[0].Boxsumcount) - customNames.Count).ToString();//单指令欠库箱
            labnosumcount.Text = (Convert.ToInt32(listpd[0].TotalCount) - sumcount).ToString();//单指令欠库双
            #endregion
            // this.dgvcustomstylecodebox.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");


            #region 获取未入库箱号
            DataTable dt = new DataTable();
            dt = pvm.getnopdboxno(CustomStyleCode);
            dgvnobox.DataSource = dt;
            this.dgvnobox.Columns["CartonBarcode"].HeaderText = "外箱条码";
            this.dgvnobox.Columns["CartonBarcode"].Visible = false;
            this.dgvnobox.Columns["BOXNO"].HeaderText = "欠箱号";

            #endregion


            Cursor = Cursors.Default;
            // MessageBox.Show(CustomStyleCode);
        }

        private void dgvcustomstylecodebox_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }

        private void dgvboxall_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }

        public void clearall()
        {
            //清空所有表
            dgvcustomstylecode.DataSource = null;
            dgvcustomstylecodebox.DataSource = null;
            dgvboxall.DataSource = null;

            labsumcoutom.Text = "0";
            labsumokbox.Text = "0";
            labsumnobox.Text = "0";

            labsumcodebox.Text = "0";
            labsumbox.Text = "0";
            labsumcodenobox.Text = "0";

            labcodecount.Text = "0";
            labpdcount.Text = "0";
            labnopdcount.Text = "0";


            labcustomcountbox.Text = "0";
            labpdboxcount.Text = "0";
            labpdnoboxcount.Text = "0";


            labcustomcount.Text = "0";
            labsumcount.Text = "0";
            labnosumcount.Text = "0";
            //  Cursor = Cursors.Default;
        }

        private void dgvnobox_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }


        private void btnSortByBox_Click(object sender, EventArgs e)
        {
            // 
            if (dt == null || dt.Rows.Count <= 0)
            {
                dt = DataGridView2DataTable(dgvcustomstylecode);
            }

            DataTable alldt = new DataTable();//满箱DATA
            alldt.Columns.Add("CustomName");
            alldt.Columns.Add("Name");
            alldt.Columns.Add("Code");
            alldt.Columns.Add("CustomStyleCode");
            alldt.Columns.Add("OrderDate");
            alldt.Columns.Add("WH");
            alldt.Columns.Add("pdcounts");
            alldt.Columns.Add("Boxsumcount");
            alldt.Columns.Add("TotalCount");

            DataTable okdt = new DataTable();//满箱DATA
            okdt.Columns.Add("CustomName");
            okdt.Columns.Add("Name");
            okdt.Columns.Add("Code");
            okdt.Columns.Add("CustomStyleCode");
            okdt.Columns.Add("OrderDate");
            okdt.Columns.Add("WH");
            okdt.Columns.Add("pdcounts");
            okdt.Columns.Add("Boxsumcount");
            okdt.Columns.Add("TotalCount");

            DataTable nodt = new DataTable();//未满箱DATA
            nodt.Columns.Add("CustomName");
            nodt.Columns.Add("Name");
            nodt.Columns.Add("Code");
            nodt.Columns.Add("CustomStyleCode");
            nodt.Columns.Add("OrderDate");
            nodt.Columns.Add("WH");
            nodt.Columns.Add("pdcounts");
            nodt.Columns.Add("Boxsumcount");
            nodt.Columns.Add("TotalCount");

            // okdt = dt;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow allrow = alldt.NewRow();
                    allrow["CustomName"] = dt.Rows[i]["客户"];
                    allrow["Name"] = dt.Rows[i]["客户型体"];
                    allrow["Code"] = dt.Rows[i]["工厂型体"];
                    allrow["CustomStyleCode"] = dt.Rows[i]["指令号"];
                    allrow["OrderDate"] = dt.Rows[i]["订单年月"];
                    allrow["WH"] = dt.Rows[i]["仓库"];
                    allrow["pdcounts"] = dt.Rows[i]["库存箱数"];
                    allrow["Boxsumcount"] = dt.Rows[i]["指令箱数"];
                    allrow["TotalCount"] = dt.Rows[i]["指令双数"];

                    alldt.Rows.Add(allrow);

                }

                    for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //如果满箱放一个dt
                    //不满箱 放另一具dt
                    if ((dt.Rows[i]["库存箱数"].ToString()) == dt.Rows[i]["指令箱数"].ToString())//满指令
                    {
                        DataRow okrow = okdt.NewRow();
                        okrow["CustomName"] = dt.Rows[i]["客户"];
                        okrow["Name"] = dt.Rows[i]["客户型体"];
                        okrow["Code"] = dt.Rows[i]["工厂型体"];
                        okrow["CustomStyleCode"] = dt.Rows[i]["指令号"];
                        okrow["OrderDate"] = dt.Rows[i]["订单年月"];
                        okrow["WH"] = dt.Rows[i]["仓库"];
                        okrow["pdcounts"] = dt.Rows[i]["库存箱数"];
                        okrow["Boxsumcount"] = dt.Rows[i]["指令箱数"];
                        okrow["TotalCount"] = dt.Rows[i]["指令双数"];

                        okdt.Rows.Add(okrow);
                    }
                    else
                    {
                        DataRow norow = nodt.NewRow();
                        norow["CustomName"] = dt.Rows[i]["客户"];
                        norow["Name"] = dt.Rows[i]["客户型体"];
                        norow["Code"] = dt.Rows[i]["工厂型体"];
                        norow["CustomStyleCode"] = dt.Rows[i]["指令号"];
                        norow["OrderDate"] = dt.Rows[i]["订单年月"];
                        norow["WH"] = dt.Rows[i]["仓库"];
                        norow["pdcounts"] = dt.Rows[i]["库存箱数"];
                        norow["Boxsumcount"] = dt.Rows[i]["指令箱数"];
                        norow["TotalCount"] = dt.Rows[i]["指令双数"];

                        nodt.Rows.Add(norow);
                    }


                }

            }

            //显示满箱dt
            if (btnSortByBox.Text.Equals("满箱"))
            {
                //加载满箱okdt
                dgvcustomstylecode.DataSource = null;
                dgvcustomstylecode.DataSource = okdt;
                for (int i = 0; i < okdt.Rows.Count; i++)
                {
                    if (okdt.Rows[i]["Boxsumcount"].ToString() == okdt.Rows[i]["pdcounts"].ToString())//满指令
                    {
                        this.dgvcustomstylecode.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#93FF93");
                    }
                    else
                    {
                        this.dgvcustomstylecode.Rows[i].DefaultCellStyle.BackColor = Color.Violet;
                    }

                }
                btnSortByBox.Text = "未满箱";
            }
            else if (btnSortByBox.Text.Equals("未满箱"))
            {
                //加载未满箱 nodt
                dgvcustomstylecode.DataSource = null;
                dgvcustomstylecode.DataSource = nodt;
                for (int i = 0; i < nodt.Rows.Count; i++)
                {
                    if (nodt.Rows[i]["Boxsumcount"].ToString() == nodt.Rows[i]["pdcounts"].ToString())//满指令
                    {
                        this.dgvcustomstylecode.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#93FF93");
                    }
                    else
                    {
                        this.dgvcustomstylecode.Rows[i].DefaultCellStyle.BackColor = Color.Violet;
                    }
                }


                btnSortByBox.Text = "所有";
            }
            else if (btnSortByBox.Text.Equals("所有"))
            {
                //加载全部 dt
                dgvcustomstylecode.DataSource = null;
                dgvcustomstylecode.DataSource = alldt;
                for (int i = 0; i < alldt.Rows.Count; i++)
                {

                    if (alldt.Rows[i]["Boxsumcount"].ToString() == alldt.Rows[i]["pdcounts"].ToString())//满指令
                    {
                        this.dgvcustomstylecode.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#93FF93");
                    }
                    else
                    {

                        this.dgvcustomstylecode.Rows[i].DefaultCellStyle.BackColor = Color.Violet;
                    }
                }
              //  this.dgvcustomstylecode.Columns["CartonBarcode"].Visible = false;
               // this.dgvcustomstylecode.Columns["BOXNO"].Visible = false;
                btnSortByBox.Text = "满箱";

            }
           
           
        }
    

        

        //Converts the DataGridView to DataTable  
        /// <summary>
        /// dgv转datatable
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="tblName"></param>
        /// <param name="minRow"></param>
        /// <returns></returns>
        public static DataTable DataGridView2DataTable(DataGridView dgv, String tblName = "", int minRow = 0)
        {
            DataTable dt = new DataTable();
            // Header columns  
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                //DataColumn dc = new DataColumn(column.Name.ToString());  
                DataColumn dc = new DataColumn(column.HeaderText.ToString());
                dt.Columns.Add(dc);
            }
            // Data cells  
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow row = dgv.Rows[i];
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
                }
                dt.Rows.Add(dr);
            }
            // Related to the bug arround min size when using ExcelLibrary for export  
            for (int i = dgv.Rows.Count; i < minRow; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = " ";
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private string  setvg()
        {
            string vg = "";
            if (dgvcustomstylecode.Focused == true)
            {
                vg = "dgvcustomstylecode";
            }

            if (dgvcustomstylecodebox.Focused == true)
            {
                vg = "dgvcustomstylecodebox";
            }

            if (dgvboxall.Focused == true)
            {
                vg = "dgvboxall";
            }

            if (dgvnobox.Focused == true)
            {
                vg = "dgvnobox";
            }
            return vg;

        } 

        private void meCopyRows_Click(object sender, EventArgs e)
        {
            string vg=setvg();
            if(vg=="")
            {
                return;
            }

            //---------------------------------
            if (vg == "dgvcustomstylecode")
            {
                Clipboard.SetDataObject(dgvcustomstylecode.GetClipboardContent());
                

            }
            else if (vg == "dgvcustomstylecodebox")
            {
                Clipboard.SetDataObject(dgvcustomstylecodebox.GetClipboardContent());
            }
            else if (vg == "dgvboxall")
            {
                Clipboard.SetDataObject(dgvboxall.GetClipboardContent());
            }
            else if (vg == "dgvnobox")
            {
                Clipboard.SetDataObject(dgvnobox.GetClipboardContent());
            }

        }

        private void meCopyCell_Click(object sender, EventArgs e)
        {
            string vg = setvg();
            if (vg == "")
            {
                return;
            }

            //---------------------------------
            if (vg == "dgvcustomstylecode")
            {
                Clipboard.SetDataObject(dgvcustomstylecode.CurrentCell.Value.ToString());


            }
            else if (vg == "dgvcustomstylecodebox")
            {
                Clipboard.SetDataObject(dgvcustomstylecodebox.CurrentCell.Value.ToString());
            }
            else if (vg == "dgvboxall")
            {
                Clipboard.SetDataObject(dgvboxall.CurrentCell.Value.ToString());
            }
            else if (vg == "dgvnobox")
            {
                Clipboard.SetDataObject(dgvnobox.CurrentCell.Value.ToString());
            }
           
        }

        private void meImproExcel_Click(object sender, EventArgs e)
        {
            string vg=setvg();
            ImproExcel(vg);
        }
        /// <summary>
        /// 导出单表
        /// </summary>
        /// <param name="VG"></param>
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
            NPOIProgram NPOIexcel = new NPOIProgram();
            DataTable tabl = new DataTable();
            if (VG == "dgvcustomstylecode")
            {
                tabl = GetDgvToTable(dgvcustomstylecode);
            }
            else if (VG == "dgvcustomstylecodebox")
            {
                tabl = GetDgvToTable(dgvcustomstylecodebox);
            }
            else if (VG == "dgvboxall")
            {
                tabl = GetDgvToTable(dgvboxall);
            }
            else if (VG == "dgvnobox")
            {
                tabl = GetDgvToTable(dgvnobox);
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

        private void dgvcustomstylecode_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvcustomstylecode.Rows[e.RowIndex].Selected == false)
                    {
                        dgvcustomstylecode.ClearSelection();
                        dgvcustomstylecode.Rows[e.RowIndex].Selected = true;
                    }
                    dgvcustomstylecode.Focus();
                    meEdit.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void dgvcustomstylecodebox_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvcustomstylecodebox.Rows[e.RowIndex].Selected == false)
                    {
                        dgvcustomstylecodebox.ClearSelection();
                        dgvcustomstylecodebox.Rows[e.RowIndex].Selected = true;
                    }
                    dgvcustomstylecodebox.Focus();
                    meEdit.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void dgvboxall_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvboxall.Rows[e.RowIndex].Selected == false)
                    {
                        dgvboxall.ClearSelection();
                        dgvboxall.Rows[e.RowIndex].Selected = true;
                    }
                    dgvboxall.Focus();
                    meEdit.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void dgvnobox_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvnobox.Rows[e.RowIndex].Selected == false)
                    {
                        dgvnobox.ClearSelection();
                        dgvnobox.Rows[e.RowIndex].Selected = true;
                    }
                    dgvnobox.Focus();
                    meEdit.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        /// <summary>
        /// 导出整表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
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
            //  DataTable tab1 = new DataTable();
            #region 生成表
            DataTable dt = new DataTable();

            dt.Columns.Add("指令数");//仓库指令数
            dt.Columns.Add("指令数量");//满箱指令数

            dt.Columns.Add("箱数");//未满指令数
            dt.Columns.Add("箱数量");//指令箱数

            dt.Columns.Add("双数");//仓库箱数
            dt.Columns.Add("双数量");//欠库箱数

            dt.Columns.Add("单箱数");//指令总双数
            dt.Columns.Add("单箱数量");//仓库总双数

            dt.Columns.Add("单双数");//总欠库双数
            dt.Columns.Add("单双数量");//单指令箱数
            //给值
            //行1
            DataRow dtrow1 = dt.NewRow();
            dtrow1["指令数"] = "仓库指令数";
            dtrow1["指令数量"] = labsumcoutom.Text;

            dtrow1["箱数"] = "指令箱数";
            dtrow1["箱数量"] = labsumcodebox.Text;

            dtrow1["双数"] = "指令总双数";
            dtrow1["双数量"] = labcodecount.Text;

            dtrow1["单箱数"] = "单指令箱数";
            dtrow1["单箱数量"] = labcustomcountbox.Text;

            dtrow1["单双数"] = "单指令双数";
            dtrow1["单双数量"] = labcustomcount.Text;            
            dt.Rows.Add(dtrow1);

            //行2
            DataRow dtrow2 = dt.NewRow();
            dtrow2["指令数"] = "满箱指令数";
            dtrow2["指令数量"] = labsumokbox.Text;

            dtrow2["箱数"] = "仓库箱数";
            dtrow2["箱数量"] = labsumbox.Text;

            dtrow2["双数"] = "仓库总双数";
            dtrow2["双数量"] = labpdcount.Text;

            dtrow2["单箱数"] = "单指令库存箱";
            dtrow2["单箱数量"] = labpdboxcount.Text;

            dtrow2["单双数"] = "单指令库存双";
            dtrow2["单双数量"] = labsumcount.Text;
            dt.Rows.Add(dtrow2);
            //行3
            DataRow dtrow3 = dt.NewRow();
            dtrow3["指令数"] = "未满指令数";
            dtrow3["指令数量"] = labsumnobox.Text;

            dtrow3["箱数"] = "欠库箱数";
            dtrow3["箱数量"] = labsumcodenobox.Text;

            dtrow3["双数"] = "总欠库双数";
            dtrow3["双数量"] = labnopdcount.Text;

            dtrow3["单箱数"] = "单指令欠库箱";
            dtrow3["单箱数量"] = labpdnoboxcount.Text;

            dtrow3["单双数"] = "单指令欠库双";
            dtrow3["单双数量"] = labnosumcount.Text;
            dt.Rows.Add(dtrow3);

            #endregion
            NPOIexcel.ExcelWrite(filename, dt);//excelhelper写出           
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

        private void btncheckok_Click(object sender, EventArgs e)
        {
            if (txtckeckcustomstylecode.Text.Trim().Length <= 0)
            {
                MessageBox.Show("请填写要修改的指令号");
                return;
            }
            if (cbcheckwhs.Text.Length <= 0)
            {
                MessageBox.Show("请选择仓库");
                return;

            }
           
            string whs = cbcheckwhs.Text;
            string customstylecode = txtckeckcustomstylecode.Text.Trim();
           int result= pvm.updwhs(whs, customstylecode);
            if (result > 0)
            {
                MessageBox.Show("修改成功，共修改了 " + result + " 条数据");

                loaddate();
            }
            else
            {
                MessageBox.Show("修改失败，请上报以查原因");
            }

        }
        private void loaddate()
        {
            clearall();
            Cursor = Cursors.WaitCursor;
            List<string> strkey = new List<string>();
            List<string> strvalue = new List<string>();
            strkey.Add("WH");
            strvalue.Add(cbwhs.Text);

            if (txtcustomstylecode.Text.Trim().Length > 0)
            {
                strkey.Add("CustomStyleCode");
                strvalue.Add(txtcustomstylecode.Text);
            }
            if (txtcustomstyle.Text.Trim().Length > 0)
            {
                strkey.Add("style");
                strvalue.Add(txtcustomstyle.Text);
            }
            //订单年月
            if (txtcustomstylecode.Text.Trim().Length <= 0 && txtcustomstyle.Text.Trim().Length <= 0)
            {
                //带仓别
                //strkey.Clear();
                // strvalue.Clear();

                strkey.Add("OrderDate");
                //strvalue.Add(dtpdata.Value.ToString());
                strvalue.Add(dtpstardata.Value.Date.ToString("yyyy-MM"));
                strkey.Add("p.OrderDate");
                //strvalue.Add(dtpdata.Value.ToString());
                strvalue.Add(dtpenddata.Value.Date.ToString("yyyy-MM"));
            }
            //  DataTable dt = new DataTable();
            List<Pdinfos> listpd = new List<Pdinfos>();
            issum = true;

            listpd = pvm.getcustomstyle(strkey, strvalue, issum);
            if (listpd.Count <= 0)
            {
                MessageBox.Show("此条件下无库存。");
                Cursor = Cursors.Default;
                return;
            }
            //查询下来，给个全局dt
            dgvcustomstylecode.DataSource = listpd;
            this.dgvcustomstylecode.Columns["CustomName"].HeaderText = "客户";
            this.dgvcustomstylecode.Columns["Name"].HeaderText = "客户型体";

            // this.dgvcustomstylecode.Columns["CustomName"].Width = 80;
            this.dgvcustomstylecode.Columns["Code"].HeaderText = "工厂型体";
            //this.dgvcustomstylecode.Columns["Code"].Width = 120;
            this.dgvcustomstylecode.Columns["CustomStyleCode"].HeaderText = "指令号";
            this.dgvcustomstylecode.Columns["OrderDate"].HeaderText = "订单年月";
            this.dgvcustomstylecode.Columns["WH"].HeaderText = "仓库";
            this.dgvcustomstylecode.Columns["pdcounts"].HeaderText = "库存箱数";
            this.dgvcustomstylecode.Columns["CartonBarcode"].Visible = false;
            this.dgvcustomstylecode.Columns["BOXNO"].Visible = false;
            this.dgvcustomstylecode.Columns["Boxsumcount"].HeaderText = "指令箱数";
            this.dgvcustomstylecode.Columns["TotalCount"].HeaderText = "指令双数";

            Application.DoEvents();

            //计算总箱数，总指令数。

            int sumbox = 0; //仓库总箱数
            int sumokbox = 0;//满箱数
            int sumcodebox = 0;//指令总箱数
            int pdcount = 0;//指令总双数
            for (int i = 0; i < listpd.Count; i++)
            {
                sumbox = sumbox + listpd[i].pdcounts;
                sumcodebox = sumcodebox + Convert.ToInt32(listpd[i].Boxsumcount);
                pdcount = pdcount + Convert.ToInt32(listpd[i].TotalCount);
                if (Convert.ToInt32(listpd[i].Boxsumcount) == listpd[i].pdcounts)//满指令
                {
                    this.dgvcustomstylecode.Rows[i].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#93FF93");
                    sumokbox++;
                }
            }
            labsumcoutom.Text = Convert.ToString(listpd.Count); //库存指令数
            labsumbox.Text = sumbox.ToString(); //仓库箱数
            labsumokbox.Text = sumokbox.ToString(); //满箱指令数
            labsumcodebox.Text = sumcodebox.ToString(); //指令箱数
            labsumnobox.Text = (listpd.Count - sumokbox).ToString(); //未满箱指令数
            labsumcodenobox.Text = (sumcodebox - sumbox).ToString();//欠库箱数
            labcodecount.Text = pdcount.ToString();//指令总双数



            this.dgvcustomstylecode.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
            dt = DataGridView2DataTable(dgvcustomstylecode);
            Cursor = Cursors.Default;
        }

        private void btnpdscantotxt_Click(object sender, EventArgs e)
        {
            btnpdscantotxt.Visible = false;
            btnCancel.Visible = true;
          //  Cursor = Cursors.WaitCursor;
            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
            }            
        }


        delegate void SetCursorDelegate(bool IsBusy);
        public void SetCursor(bool IsBusy)
        {
            if (IsBusy)
            {
                if (this.InvokeRequired)
                {
                    
                     Invoke(new SetCursorDelegate(SetCursor),true);
                }
                else
                {
                    Cursor = Cursors.WaitCursor;

                }

            }
            else
            {
                if (this.InvokeRequired)
                {

                    Invoke(new SetCursorDelegate(SetCursor),false);
                }
                else
                {
                    Cursor = Cursors.Default;

                }

            }
            
        }
        delegate string GetValueDelegate();
        public string GetcbwhsValue()
        {
            if (this.InvokeRequired)
            {
                return this.Invoke(new GetValueDelegate(GetcbwhsValue)) as string;
            }
            else
            {
                string whs = cbwhs.Text;
                return whs;
            }
        }

        private void DoWork_downloadpdtxt(object sender, DoWorkEventArgs args)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string whs= GetcbwhsValue();
            //  string whs = cbwhs.Text;
            string strExp = @"^WH";
            bool ispd = false;
            //创建正则表达式对象
            Regex myRegex = new Regex(strExp);
            if (myRegex.IsMatch(whs))
            {
                ispd = true;
            }
            List<pdinventory> pdlist = new List<pdinventory>();
            if (ispd)
            {
                pdlist = pvm.getpdfiletotxt(whs);

            }
            else
            {
                MessageBox.Show("请选选择仓库");
                return;
            }

            string temp = "";
            if (pdlist.Count <= 0)
            {
                MessageBox.Show("本仓库" + whs + "没有资料");
                return;
            }
            //  Cursor = Cursors.WaitCursor;
            bool IsBusy = true;
            SetCursor(IsBusy);
            for (int i = 0; i < pdlist.Count; i++)
            {
                //   Code,Name,CustomStyleCode,OrderDate,BOXNO,CartonBarcode,WH,PDScan1,PDScan1Time,PDScan2,PDScan2Time,PDScan3,PDScan3Time
                temp = temp + pdlist[i].Code + "|" + pdlist[i].Name + "|" + pdlist[i].CustomStyleCode + "|"
                     + pdlist[i].OrderDate + "|" + pdlist[i].BOXNO.ToString() + "|" + pdlist[i].CartonBarcode + "|"
                     + pdlist[i].WH + "|" + pdlist[i].PDScan1.ToString() + "|" + pdlist[i].PDScan1Time + "|"
                     + pdlist[i].PDScan2.ToString() + "|" + pdlist[i].PDScan2Time + "|"
                     + pdlist[i].PDScan3.ToString() + "|" + pdlist[i].PDScan3Time + "\r\n";          
            

                if (worker.CancellationPending)
                {
                    args.Cancel = true;
                    break;
                }
                else
                {
                    worker.ReportProgress(i * 100 / pdlist.Count);
                    Thread.Sleep(0);
                }
            }
            string path = Directory.GetCurrentDirectory();
            path = path +@"\"+ pdlist[0].WH + ".txt";
            if (path.Equals(null) || path.Equals(""))
            {
              MessageBox.Show("保存文件路径不能为空");               
                return;
            }
            try
            {


                FileStream fs = new FileStream(path, FileMode.Create);
                //获得字节数组
                byte[] data = System.Text.Encoding.Default.GetBytes(temp);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            }
            
           
            catch (Exception ex)
            {
                MessageBox.Show("文件操作异常"+ex.Message.ToString());
            }

            MessageBox.Show("文件保存成功，位置:"+ path);
             IsBusy = false;
            SetCursor(IsBusy);

            DialogResult dialogResult = MessageBox.Show("文件保存成功，位置:" + path+",是否打开文件夹？", "下载完成", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Directory.GetCurrentDirectory());
            }
            else if (dialogResult == DialogResult.No)
            {
              
            }
          
        }


    
        private void ProgressChanged_Handler(object sender, ProgressChangedEventArgs args)
        {
            progressBar1.Value = args.ProgressPercentage;            
        }
        private void RunWorkerCompleted_Handler(object sender, RunWorkerCompletedEventArgs args)
        {
            progressBar1.Value = 0;
            if (args.Error != null)
            {
                MessageBox.Show(args.Error.Message);
            }
            else if (args.Cancelled)
            {
                MessageBox.Show("取消保存。", "消息");
                btnCancel.Visible = false;
                btnpdscantotxt.Visible = true;
                Cursor = Cursors.Default;
               
            }
            else
            {
                MessageBox.Show("下载完成。", "消息");
                btnCancel.Visible = false;
                btnpdscantotxt.Visible = true;
                Cursor = Cursors.Default;               
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {          
                bgWorker.CancelAsync();
                bgWorker.Dispose();
        }
    }
}
