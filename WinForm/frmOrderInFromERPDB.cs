using DAL;
using JITSystem.BLL;
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
using System.Threading;
using System.Windows.Forms;
using static Common.myCommon;

namespace WinForm
{
    public partial class frmOrderInFromERPDB : Form
    {
        private delegate void SetPos(int ipos);
        JITSystem.BLL.TestLinServer testl = new JITSystem.BLL.TestLinServer();
        BackgroundWorker bgWorker = new BackgroundWorker();
        int RowIndex = -1;
        public frmOrderInFromERPDB()
        {
            InitializeComponent();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += DoWork_CusUpdata; //方法名称
            bgWorker.ProgressChanged += ProgressChanged_Handler;
            bgWorker.RunWorkerCompleted += RunWorkerCompleted_Handler;
        }

        static frmOrderInFromERPDB frm = null;
        public static frmOrderInFromERPDB GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            // if (frm == null)
            {
                frm = new frmOrderInFromERPDB();
            }
            return frm;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            btnSave.Enabled = true;
            if (!LoadDate())
            {
                return;
            }
            List<string> whereList = new List<string>();
            List<string> whereListText = new List<string>();

            if (ckFactoryOperateDate.Checked == true)
            {
                DateTime time1 = Convert.ToDateTime(dateTimePickerOperateDate.Value.Date.ToString("yyyy-MM"));

                DateTime time2 = Convert.ToDateTime(dateTimePickerOperateDateEnd.Value.Date.ToString("yyyy-MM"));

                if (DateTime.Compare(time1, time2) > 0) //判断日期大小
                {

                    MessageBox.Show("结束日期不能小于开始日期！");
                    return;
                }
                String strtime1 = dateTimePickerOperateDate.Value.Date.ToString("yyyy-MM");
                String strtime2 = dateTimePickerOperateDateEnd.Value.Date.ToString("yyyy-MM");
                whereList.Add("OrderDate");
                whereListText.Add("between '" + strtime1 + "' and '" + strtime2 + "'");

            }


            if (ckFactoryStyleCode.Checked == true)
            {
                string str = txtFactoryStyleCode.Text;
                str = str.Trim();
                if (str.Length <= 0)
                {
                    MessageBox.Show("工厂型体不能为空！");
                    return;
                }

                whereList.Add("Code");
                whereListText.Add("like \'%" + str + "%\'");

            }
            if (ckFactoryOrderCode.Checked == true)
            {
                string str = txtFactoryOrderCode.Text;
                str = str.Trim();

                if (str.Length <= 0)
                {

                    MessageBox.Show("指令号不能为空！");
                    return;
                }

                whereList.Add("CustomStyleCode");
                whereListText.Add("like \'%" + str + "%\'");

            }
            if (ckFactoryOperateDate.Checked == false && ckFactoryStyleCode.Checked == false && ckFactoryOrderCode.Checked == false)
            {
                MessageBox.Show("至少选择一个条件！");
                return;
            }
            string type = "btnsearch";
            LoadDate(whereList, whereListText, type);
        }
        private void LoadDate(List<string> whereList, List<string> whereListText, string type)
        {
            Cursor = Cursors.WaitCursor;
            T_StyleCodeInfoBLL stylecodeinfobll = new T_StyleCodeInfoBLL();

            T_StyleCodeInfo[] StyleCodeInfos = stylecodeinfobll.GetStyleCodeInfos(whereList, whereListText, type);
            int k = 0;
            if (StyleCodeInfos != null)
            {
                k = StyleCodeInfos.Count();
            }
            if (k <= 0)
            {
                MessageBox.Show("没有数据，请更改查询条件！");
                Cursor = Cursors.Default;
                return;

            }

            this.StyleCodeInfodataGridView.DataSource = StyleCodeInfos;


            this.StyleCodeInfodataGridView.Rows[k - 1].Selected = true;
            //this.StyleCodeInfodataGridView.FirstDisplayedScrollingRowIndex = k-1;
            this.StyleCodeInfodataGridView.FirstDisplayedScrollingRowIndex = k - 1;

            string DocTreeID;
            string osmDocTreeID;
            DocTreeID = this.StyleCodeInfodataGridView["DocTreeID", k - 1].Value.ToString();//第1列为ID 取值去查SIZERUN
            osmDocTreeID = this.StyleCodeInfodataGridView["osmDocTreeID", k - 1].Value.ToString();//第0列为ID 取值去查SIZERUN            
                                                                                     // str = e.ColumnIndex.ToString();
            getSizeRun(DocTreeID, osmDocTreeID);

            //  this.StyleCodeInfodataGridView.ReadOnly = true;
            this.StyleCodeInfodataGridView.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");

            if (type == "btnsearchAll")
            {
                this.StyleCodeInfodataGridView.Columns["Guid"].HeaderText = "Guid";
                this.StyleCodeInfodataGridView.Columns["Guid"].Visible = false;
            }
           

            this.StyleCodeInfodataGridView.Columns["osmDocTreeID"].HeaderText = "鞋型库订单号";
            this.StyleCodeInfodataGridView.Columns["osmDocTreeID"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["DocTreeID"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["DeliverDate"].HeaderText = "接单日期";
            this.StyleCodeInfodataGridView.Columns["doccode"].HeaderText = "订单合同号";
            this.StyleCodeInfodataGridView.Columns["OrderDate"].HeaderText = "订单年月";
            this.StyleCodeInfodataGridView.Columns["SessionType"].HeaderText = "季节号";

            this.StyleCodeInfodataGridView.Columns["CCount"].HeaderText = "订单总双数";
            this.StyleCodeInfodataGridView.Columns["TotalCount"].HeaderText = "SIZI总数";
            this.StyleCodeInfodataGridView.Columns["ExportPrice"].HeaderText = "单价";
            this.StyleCodeInfodataGridView.Columns["MonetaryUnit"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["MonetaryUnitname"].HeaderText = "币种";
            this.StyleCodeInfodataGridView.Columns["FactoryID"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["FactoryName"].HeaderText = "生产工厂";
            this.StyleCodeInfodataGridView.Columns["WarehouseID"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["Warehouse"].HeaderText = "承接仓库";
            this.StyleCodeInfodataGridView.Columns["CustomStyleCode"].HeaderText = "指令号";
            this.StyleCodeInfodataGridView.Columns["CutNo"].HeaderText = "ORDER NO/PO NO";
            this.StyleCodeInfodataGridView.Columns["CustomID"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["CustomName"].HeaderText = "客户";
            this.StyleCodeInfodataGridView.Columns["CustomBuyer"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["CustomBuyName"].HeaderText = "客户买主";
            this.StyleCodeInfodataGridView.Columns["StyleID"].HeaderText = "鞋型ID";
            this.StyleCodeInfodataGridView.Columns["StyleID"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["Code"].HeaderText = "工厂型体";

            this.StyleCodeInfodataGridView.Columns["Name"].HeaderText = "客户型体";
            this.StyleCodeInfodataGridView.Columns["SingleTurn"].HeaderText = "客户订单号";
            this.StyleCodeInfodataGridView.Columns["CustomPO"].HeaderText = "客户订单号";
            this.StyleCodeInfodataGridView.Columns["CustomPO"].Visible = false;


            this.StyleCodeInfodataGridView.Columns["ManufactureOrder"].HeaderText = "LOTNO";
            this.StyleCodeInfodataGridView.Columns["StyleNumber"].HeaderText = "客户鞋名";
            this.StyleCodeInfodataGridView.Columns["ColorID"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["ColorName"].HeaderText = "颜色";
            this.StyleCodeInfodataGridView.Columns["Editionhandle"].HeaderText = "楦头编号";
            this.StyleCodeInfodataGridView.Columns["ModelNo"].HeaderText = "大底编号";
            this.StyleCodeInfodataGridView.Columns["CuttingNo"].HeaderText = "后跟编号";

            this.StyleCodeInfodataGridView.Columns["RBcode"].HeaderText = "RB模号";
            this.StyleCodeInfodataGridView.Columns["RBcolor"].HeaderText = "RB颜色";
            this.StyleCodeInfodataGridView.Columns["MDcode"].HeaderText = "MD模号";

            this.StyleCodeInfodataGridView.Columns["MDcolor"].HeaderText = "MD颜色";
            this.StyleCodeInfodataGridView.Columns["ddlcode"].HeaderText = "大底饰片（内腰）";
            this.StyleCodeInfodataGridView.Columns["ddwcode"].HeaderText = "大底饰片（外腰）";

            this.StyleCodeInfodataGridView.Columns["ddqcode"].HeaderText = "大底饰片（前掌）";
            this.StyleCodeInfodataGridView.Columns["ddhcode"].HeaderText = "大底饰片（后跟）";
            this.StyleCodeInfodataGridView.Columns["ddscode"].HeaderText = "大底射出片";

            this.StyleCodeInfodataGridView.Columns["aocode"].HeaderText = "凹槽";
            this.StyleCodeInfodataGridView.Columns["towcode"].HeaderText = "二次工艺";
            this.StyleCodeInfodataGridView.Columns["ShipMentDate"].HeaderText = "客户交期";

            this.StyleCodeInfodataGridView.Columns["ExportArea"].HeaderText = "出货港";
            this.StyleCodeInfodataGridView.Columns["AimArea"].HeaderText = "目的地";

            this.StyleCodeInfodataGridView.Columns["ShipType"].HeaderText = "运输方式ID";
            this.StyleCodeInfodataGridView.Columns["ShipType"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["ShipTypeName"].HeaderText = "运输方式";

            this.StyleCodeInfodataGridView.Columns["Memo"].HeaderText = "交期備注";
            this.StyleCodeInfodataGridView.Columns["CustomClothBrand"].HeaderText = "LOGO";
            this.StyleCodeInfodataGridView.Columns["logocode"].HeaderText = "LOGO编码";

            this.StyleCodeInfodataGridView.Columns["logoname"].HeaderText = "LOGO名称";
            this.StyleCodeInfodataGridView.Columns["OrderDocType"].Visible = false;

            this.StyleCodeInfodataGridView.Columns["OrderDocTypeName"].HeaderText = "订单类型";

            this.StyleCodeInfodataGridView.Columns["DesignTypeID"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["DesignTypeName"].HeaderText = "鞋款做法";
            this.StyleCodeInfodataGridView.Columns["GoodsType"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["GoodsTypeName"].HeaderText = "产品类型";
            this.StyleCodeInfodataGridView.Columns["ID"].HeaderText = "ID";
            this.StyleCodeInfodataGridView.Columns["ID"].Visible = false;

            this.StyleCodeInfodataGridView.Columns["StyleNo"].HeaderText = "款序";
            // this.StyleCodeInfodataGridView.Columns["LogoLibrary"].HeaderText = "LOGO库";
            this.StyleCodeInfodataGridView.Columns["PriceItem"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["PriceItemName"].HeaderText = "交易条件";

            this.StyleCodeInfodataGridView.Columns["BalanceType"].Visible = false;
            this.StyleCodeInfodataGridView.Columns["BalanceTypeName"].HeaderText = "付款方式";
            //  this.StyleCodeInfodataGridView.Columns["IsNeedQuote"].HeaderText = "IsNeedQuote";
            // this.StyleCodeInfodataGridView.Columns["IsSinglePrice"].HeaderText = "IsSinglePrice";

            //   this.StyleCodeInfodataGridView.Columns["IsSingleCostPrice"].HeaderText = "IsSingleCostPrice";
            //  this.StyleCodeInfodataGridView.Columns["IsSingleShowPrice"].HeaderText = "IsSingleShowPrice";
            this.StyleCodeInfodataGridView.Columns["CountryName"].HeaderText = "国家名称";

            this.StyleCodeInfodataGridView.Columns["CountryNum"].HeaderText = "国家代码";
            //  this.StyleCodeInfodataGridView.Columns["ActualCustomPerCount"].HeaderText = "ActualCustomPerCount";

            //总订单数
            int j = 0;
            for (int i = 0; i < k; i++)
            {
                j = j + Convert.ToInt32(StyleCodeInfos[i].CCount);
            }
            txtPOCount.Text = j.ToString();

            //总型体数 Code
            j = 0;
            string strCode = "0";
            for (int i = 0; i < k; i++)
            {
                if (strCode == "0")
                {
                    strCode = StyleCodeInfos[i].Code;
                    string[] s = strCode.Split(new char[] { '/' });
                    strCode = s[0];
                }

                if (strCode != StyleCodeInfos[i].Code.Split(new char[] { '/' })[0])
                {
                    j++;
                    strCode = StyleCodeInfos[i].Code.Split(new char[] { '/' })[0];
                }
                txtCodeCount.Text = j.ToString();
            }
            //总交期数 ShipMentDate
            // DateTime[] ShipMentDates;
            List<DateTime> listArr = new List<DateTime>();
            List<string> ShipMentDates = new List<string>();
            List<int> ShipCounts = new List<int>();
            int ShipCount = 0;
            j = 0;
            for (int i = 0; i < k; i++)
            {

                if (StyleCodeInfos[i].ShipMentDate == null || StyleCodeInfos[i].ShipMentDate.ToString().Length <= 0)
                {
                    StyleCodeInfos[i].ShipMentDate = Convert.ToDateTime("2014-01");
                }
                DateTime ShipMentDate = (DateTime)StyleCodeInfos[i].ShipMentDate;
                if (listArr.Count() <= 0)
                {
                    listArr.Add(ShipMentDate);
                    ShipMentDates.Add(ShipMentDate.ToString("d"));
                    ShipCounts.Add(ShipCount);
                    if (StyleCodeInfos[i].CCount == null)
                    {
                        ShipCounts[i] = ShipCount + 0;
                    }
                    ShipCounts[i] = ShipCount + Convert.ToInt32(StyleCodeInfos[i].CCount);
                }
                if (listArr[j] == ShipMentDate)
                {
                    ShipCounts[j] = ShipCount + Convert.ToInt32(StyleCodeInfos[i].CCount);
                }
                else
                if (listArr[j] != ShipMentDate)
                {
                    listArr.Add(ShipMentDate);
                    ShipMentDates.Add(ShipMentDate.ToString("d"));
                    ShipCounts.Add(ShipCount);
                    if (StyleCodeInfos[i].CCount == null)
                    {
                        ShipCounts[j] = ShipCount + 0;
                    }
                    ShipCounts[j] = ShipCount + Convert.ToInt32(StyleCodeInfos[i].CCount);
                    j++;
                }
                //   }

            };
            txtShipMentDateCount.Text = listArr.Count.ToString();
            for (int l = 0; l < listArr.Count; l++)
            {
                btnIMPEXCEL.Text = btnIMPEXCEL.Text + " | " + ShipMentDates[l].ToString() + " _ " + ShipCounts[l].ToString();
            }

            Cursor = Cursors.Default;


        }
        private bool LoadDate()
        {
            btnReLink.Visible = false;
            progressBar.Visible = false;
            if (testl.LinServer())
            {

                btnsearch.Enabled = true;
                LabelTestLinServer.BackColor = Color.Lime;
                txtTestLinServer.Text = "服务器已连接！";
                txtTestLinServer.ForeColor = Color.Lime;
                return true;
            }
            else
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (!testl.LinServer())
                    {
                        LabelTestLinServer.BackColor = Color.Red;
                        txtTestLinServer.Text = "服务器连接失败！正在尝试重新连接，第 " + i.ToString() + " 次...";
                        txtTestLinServer.ForeColor = Color.Red;
                        btnsearch.Enabled = false;
                        progressBar.Visible = true;
                        progressBar.Maximum = 5;
                        progressBar.Minimum = 0;
                        progressBar.Value = i;
                        Thread.Sleep(500);
                        // LoadDate();

                    }
                    else
                    {
                        progressBar.Visible = false;
                        btnsearch.Enabled = true;
                        LabelTestLinServer.BackColor = Color.Lime;
                        txtTestLinServer.Text = "服务器已连接！";
                        txtTestLinServer.ForeColor = Color.Lime;

                        break;
                    }

                }
                if (!testl.LinServer())
                {
                    LabelTestLinServer.BackColor = Color.Red;
                    txtTestLinServer.Text = "服务器连接失败！请检查网络连接!";
                    txtTestLinServer.ForeColor = Color.Red;
                    btnsearch.Enabled = false;
                    progressBar.Visible = false;
                    btnReLink.Visible = true;

                    return false;

                }
                else
                {
                    return true;
                }

            }
        }
       
        private void StyleCodeInfodataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string DocTreeID;
            string osmDocTreeID;
            DocTreeID = this.StyleCodeInfodataGridView["DocTreeID", e.RowIndex].Value.ToString();//第1列为ID 取值去查SIZERUN
            osmDocTreeID = this.StyleCodeInfodataGridView["osmDocTreeID", e.RowIndex].Value.ToString();//第0列为ID 取值去查SIZERUN            
            RowIndex = StyleCodeInfodataGridView.CurrentRow.Index;                                                                  // str = e.ColumnIndex.ToString();
            getSizeRun(DocTreeID, osmDocTreeID);
            getPhoto(DocTreeID);
            //   MessageBox.Show(str);
        }
        private void getSizeRun(string DocTreeID, string osmDocTreeID)
        {
            if (!LoadDate())
            {
                return;
            }
            Cursor = Cursors.WaitCursor;

            T_StyleCodeInfoBLL stylecodeinfobll = new T_StyleCodeInfoBLL();
            this.dataGridViewSizeRun.DataSource = stylecodeinfobll.GetT_StyleCodeSizeRun(DocTreeID, osmDocTreeID);
            Cursor = Cursors.Default;
        }
        private void getPhoto(string DocTreeID)
        {
            if (!LoadDate())
            {
                return;
            }
            Cursor = Cursors.WaitCursor;

            T_StyleCodeInfoBLL stylecodeinfobll = new T_StyleCodeInfoBLL();
            // this.picStylePhoto.Image = 
            ShowImg(stylecodeinfobll.getPhoto(DocTreeID));
            Cursor = Cursors.Default;
        }
        private void ShowImg(byte[] imgBytes)
        {
            try
            {

                MemoryStream stream = new MemoryStream(imgBytes);
                //Image image = Image.FromStream(stream, true);
                Bitmap bmap = new Bitmap(stream);
                this.picStylePhoto.Image = bmap;
                stream.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }



        }
        private void StyleCodeInfodataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }

        private void btnReLink_Click(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void dataGridViewSizeRun_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            String searchValue = dataGridViewSizeRun.Rows[0].Cells["CustomStyleCode"].Value.ToString();
            int rowIndex = -1;
            foreach (DataGridViewRow row in StyleCodeInfodataGridView.Rows)
            {
                if (row.Cells["CustomStyleCode"].Value.ToString().Equals(searchValue))
                {
                    rowIndex = row.Index;
                    break;
                }
            }

            //  int i=
           

         
            this.StyleCodeInfodataGridView.Rows[rowIndex].Selected = true;
            this.StyleCodeInfodataGridView.FirstDisplayedScrollingRowIndex = rowIndex;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnCancel.Text = "取消保存";
            Cursor = Cursors.WaitCursor;
            btnSave.Enabled = false;
            this.progressBar.Visible = true;
            txtTestLinServer.ForeColor = Color.Black;
            //不忙  保存
            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
            }

            //Thread TLoadDate = new Thread(new ThreadStart(CusUpdata));//开辟一个新的线程
            //TLoadDate.IsBackground = true;
            //TLoadDate.Start();

        }
        private void ProgressChanged_Handler(object sender, ProgressChangedEventArgs args)
        {
            progressBar.Value = args.ProgressPercentage;
            //  this.txtTestLinServer.Text = "正在保存：已保存 " + ipos.ToString() + " %";
            this.txtTestLinServer.Text = "正在保存：已保存" + ((int)args.ProgressPercentage).ToString() + "%";
            //    txtTestLinServer.Text = "已导入条数：" + (secont.Value + 1).ToString() + "条数据.共有" + secont.LinesCount.ToString() + "条数据！";

            //    yiyongshi.DataContext = secont;
            // zongyongshi.DataContext = secont;

        }
        private void RunWorkerCompleted_Handler(object sender, RunWorkerCompletedEventArgs args)
        {
            progressBar.Value = 0;
            if (args.Error != null)
            {
                MessageBox.Show(args.Error.Message);
            }
            else if (args.Cancelled)
            {
                MessageBox.Show("取消保存。", "消息");
                btnCancel.Text = "关闭";
                Cursor = Cursors.Default;
                btnSave.Enabled = true;
            }
            else
            {

                // zongyongshi.Content = args.Result.ToString() + "秒";
                MessageBox.Show("保存完成。", "消息");
                txtTestLinServer.Text = "保存完成！";
                btnCancel.Text = "关闭";
                Cursor = Cursors.Default;
                btnSave.Enabled = true;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(bgWorker.ToString());
            if (!btnSave.Enabled || btnSave.Text == "取消保存")
            {
                bgWorker.CancelAsync();
                bgWorker.Dispose();//释放资源 
                                   //  Close();
            }
            else
            {
                Close();
                //this.Visible = false;
            }

        }
        private void DoWork_CusUpdata(object sender, DoWorkEventArgs args)
        {

            BackgroundWorker worker = sender as BackgroundWorker;
            //  T_StyleCodeInfo[] styleinfo = new T_StyleCodeInfo();
            T_StyleCodeInfo styleinfo = new T_StyleCodeInfo();
            //using (TransactionScope ts = new TransactionScope())
            //{
            for (int i = 0; i < StyleCodeInfodataGridView.RowCount; i++)
            {
                //  this.Invoke((EventHandler)(delegate
                // {
                //写入语句
                //SQLBALLCOPY
                styleinfo.osmDocTreeID = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["osmDocTreeID"].Value);
                styleinfo.DocTreeID = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["DocTreeID"].Value);
                if (StyleCodeInfodataGridView.Rows[i].Cells["DeliverDate"].Value != null)
                {
                    styleinfo.DeliverDate = Convert.ToDateTime(StyleCodeInfodataGridView.Rows[i].Cells["DeliverDate"].Value);
                }

                styleinfo.doccode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["doccode"].Value);
                styleinfo.OrderDate = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["OrderDate"].Value);
                styleinfo.SessionType = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["SessionType"].Value);
                styleinfo.CCount = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CCount"].Value);
                styleinfo.TotalCount = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["TotalCount"].Value);
                styleinfo.ExportPrice = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ExportPrice"].Value);
                styleinfo.MonetaryUnit = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["MonetaryUnit"].Value);
                styleinfo.MonetaryUnitname = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["MonetaryUnitname"].Value);

                styleinfo.FactoryID = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["FactoryID"].Value);
                styleinfo.FactoryName = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["FactoryName"].Value);
                styleinfo.WarehouseID = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["WarehouseID"].Value);
                styleinfo.Warehouse = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["Warehouse"].Value);
                styleinfo.CustomStyleCode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CustomStyleCode"].Value);
                styleinfo.CutNo = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CutNo"].Value);
                styleinfo.CustomID = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CustomID"].Value);
                styleinfo.CustomName = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CustomName"].Value);
                styleinfo.CustomBuyer = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CustomBuyer"].Value);
                styleinfo.CustomBuyName = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CustomBuyName"].Value);

                styleinfo.StyleID = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["StyleID"].Value);
                styleinfo.Code = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["Code"].Value);
                styleinfo.Name = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["Name"].Value);
                styleinfo.SingleTurn = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["SingleTurn"].Value);
                styleinfo.CustomPO = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CustomPO"].Value);
                styleinfo.ManufactureOrder = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ManufactureOrder"].Value);
                styleinfo.StyleNumber = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["StyleNumber"].Value);
                styleinfo.ColorID = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ColorID"].Value);
                styleinfo.ColorName = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ColorName"].Value);
                styleinfo.Editionhandle = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["Editionhandle"].Value);

                styleinfo.ModelNo = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ModelNo"].Value);
                styleinfo.CuttingNo = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CuttingNo"].Value);
                styleinfo.RBcode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["RBcode"].Value);
                styleinfo.RBcolor = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["RBcolor"].Value);
                styleinfo.MDcode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["MDcode"].Value);
                styleinfo.MDcolor = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["MDcolor"].Value);
                styleinfo.ddlcode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ddlcode"].Value);
                styleinfo.ddwcode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ddwcode"].Value);
                styleinfo.ddqcode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ddqcode"].Value);
                styleinfo.ddhcode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ddhcode"].Value);

                styleinfo.ddscode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ddscode"].Value);
                styleinfo.aocode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["aocode"].Value);
                styleinfo.towcode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["towcode"].Value);
                if (StyleCodeInfodataGridView.Rows[i].Cells["ShipMentDate"].Value != null)
                {
                    styleinfo.ShipMentDate = Convert.ToDateTime(StyleCodeInfodataGridView.Rows[i].Cells["ShipMentDate"].Value);
                }
                styleinfo.ExportArea = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ExportArea"].Value);
                styleinfo.AimArea = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["AimArea"].Value);
                styleinfo.ShipType = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ShipType"].Value);
                styleinfo.ShipTypeName = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ShipTypeName"].Value);
                styleinfo.Memo = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["Memo"].Value);
                styleinfo.CustomClothBrand = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CustomClothBrand"].Value);
                styleinfo.logocode = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["logocode"].Value);

                styleinfo.logoname = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["logoname"].Value);
                styleinfo.OrderDocType = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["OrderDocType"].Value);
                styleinfo.OrderDocTypeName = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["OrderDocTypeName"].Value);
                styleinfo.DesignTypeID = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["DesignTypeID"].Value);
                styleinfo.DesignTypeName = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["DesignTypeName"].Value);
                styleinfo.GoodsType = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["GoodsType"].Value);
                styleinfo.GoodsTypeName = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["GoodsTypeName"].Value);
                styleinfo.ID = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["ID"].Value);
                styleinfo.StyleNo = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["StyleNo"].Value);
                styleinfo.PriceItem = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["PriceItem"].Value);

                styleinfo.PriceItemName = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["PriceItemName"].Value);
                styleinfo.BalanceType = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["BalanceType"].Value);
                styleinfo.BalanceTypeName = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["BalanceTypeName"].Value);
                styleinfo.CountryName = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CountryName"].Value);
                styleinfo.CountryNum = Convert.ToString(StyleCodeInfodataGridView.Rows[i].Cells["CountryNum"].Value);
                // SetTextMessage((i + 1) * 100 / StyleCodeInfodataGridView.RowCount);
                //    using (TransactionScope ts = new TransactionScope())//分布式事务  有错误
                //  {
                T_StyleCodeInfoBLL stylecodeinfobll = new T_StyleCodeInfoBLL();
                // Guid guid = Guid.NewGuid();
                string guidstr = stylecodeinfobll.GetCountByosmDocTreeID(styleinfo.CustomStyleCode);
                if (guidstr.Length <= 0)//保存前检查是否已有记录
                {
                    Guid guid = Guid.NewGuid();
                    stylecodeinfobll.updataFromDV(styleinfo, guid);   //写订单明细
                                                                      //写sizerun
                    string DocTreeID;
                    string osmDocTreeID;
                    DocTreeID = this.StyleCodeInfodataGridView["DocTreeID", i].Value.ToString();//第1列为ID 取值去查SIZERUN
                    osmDocTreeID = this.StyleCodeInfodataGridView["osmDocTreeID", i].Value.ToString();//第0列为ID 取值去查SIZERUN  
                    stylecodeinfobll.updataFromSize(Convert.ToString(guid), osmDocTreeID);
                    //    ts.Complete();
                }
                else
                {
                    // Guid guid = styleinfo.;
                    stylecodeinfobll.updataFromsinfoDV(styleinfo, guidstr);   //写订单明细
                                                                              //写sizerun
                    string DocTreeID;
                    string osmDocTreeID;
                    DocTreeID = this.StyleCodeInfodataGridView["DocTreeID", i].Value.ToString();//第1列为ID 取值去查SIZERUN
                    osmDocTreeID = this.StyleCodeInfodataGridView["osmDocTreeID", i].Value.ToString();//第0列为ID 取值去查SIZERUN  
                    stylecodeinfobll.updataFromSize(guidstr, osmDocTreeID);
                    //     ts.Complete();
                }


                //  }

                if (worker.CancellationPending)
                {
                    args.Cancel = true;
                    break;
                }
                else
                {
                    worker.ReportProgress(i * 100 / StyleCodeInfodataGridView.RowCount);
                    Thread.Sleep(0);

                }

                //}
                //if (!args.Cancel)   //没有取消   写入库
                //{
                //    ts.Complete();
                //}

                // }));
                //     Thread.Sleep(100);//显示出来
            }

        }
        private void meCopyRows_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(StyleCodeInfodataGridView.GetClipboardContent());
        }
        private void meCopyCell_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(StyleCodeInfodataGridView.CurrentCell.Value.ToString());
        }

        private void meImproExcel_Click(object sender, EventArgs e)//导出到excel
        {
            string vg = "StyleCode";
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
            NPOIProgram NPOIexcel = new NPOIProgram();
            DataTable tabl = new DataTable();
            if (VG == "StyleCode")
            {
                tabl = GetDgvToTable(StyleCodeInfodataGridView);
            }
            else if (VG == "SizeRun")
            {
                tabl = GetDgvToTable(dataGridViewSizeRun);
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

        private void btnsearchAll_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (!LoadDate())
            {
                return;
            }
            List<string> whereList = new List<string>();
            List<string> whereListText = new List<string>();
            //whereList = new List<string>();
            // whereListText = new List<string>();

            //    bool ckboxIdentity;
            if (ckFactoryOperateDate.Checked == true)
            {
                DateTime time1 = Convert.ToDateTime(dateTimePickerOperateDate.Value.Date.ToString("yyyy-MM"));

                DateTime time2 = Convert.ToDateTime(dateTimePickerOperateDateEnd.Value.Date.ToString("yyyy-MM"));

                if (DateTime.Compare(time1, time2) > 0) //判断日期大小
                {

                    MessageBox.Show("结束日期不能小于开始日期！");
                    return;
                }
                String strtime1 = dateTimePickerOperateDate.Value.Date.ToString("yyyy-MM");
                String strtime2 = dateTimePickerOperateDateEnd.Value.Date.ToString("yyyy-MM");
                whereList.Add("OrderDate");
                whereListText.Add("between '" + strtime1 + "' and '" + strtime2 + "'");

            }


            if (ckFactoryStyleCode.Checked == true)
            {
                string str = txtFactoryStyleCode.Text;
                str = str.Trim();
                if (str.Length <= 0)
                {
                    MessageBox.Show("工厂型体不能为空！");
                    return;
                }

                whereList.Add("Code");
                whereListText.Add("like \'%" + str + "%\'");

            }
            if (ckFactoryOrderCode.Checked == true)
            {
                string str = txtFactoryOrderCode.Text;
                str = str.Trim();

                if (str.Length <= 0)
                {

                    MessageBox.Show("指令号不能为空！");
                    return;
                }

                whereList.Add("CustomStyleCode");
                whereListText.Add("like \'%" + str + "%\'");

            }
            if (ckFactoryOperateDate.Checked == false && ckFactoryStyleCode.Checked == false && ckFactoryOrderCode.Checked == false)
            {
                MessageBox.Show("至少选择一个条件！");
                return;
            }
            string type = "btnsearchAll";
            LoadDate(whereList, whereListText, type);
        }

        private void btnImproExcel_Click(object sender, EventArgs e)
        {
            string vg = "StyleCode";
            ImproExcel(vg);
        }

        private void dataGridViewSizeRun_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (StyleCodeInfodataGridView.Rows[e.RowIndex].Selected == false)
                    {
                        StyleCodeInfodataGridView.ClearSelection();
                        StyleCodeInfodataGridView.Rows[e.RowIndex].Selected = true;
                    }
                    ////只选中一行时设置活动单元格
                    //if (StyleCodeInfodataGridView.SelectedRows.Count == 1)
                    //{
                    //    StyleCodeInfodataGridView.CurrentCell = StyleCodeInfodataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //}
                    //弹出操作菜单

                    mePrintSizeLable.Show(MousePosition.X, MousePosition.Y);
                    // MessageBox.Show("点右键了");
                }
            }

        }

                

        private void meCopyRowss_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dataGridViewSizeRun.GetClipboardContent());
        }

        private void meCopySelectCell_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dataGridViewSizeRun.CurrentCell.Value.ToString());
        }

        private void meImporExcel_Click(object sender, EventArgs e)
        {
            string vg = "SizeRun";
            ImproExcel(vg);
        }

        private void picStylePhoto_DoubleClick(object sender, EventArgs e)
        {
            FrmStylePhoto frm = new FrmStylePhoto(picStylePhoto.Image);

            frm.Show();

        }

       

        private void frmOrderInFromERPDB_Load(object sender, EventArgs e)
        {

            btnReLink.Visible = false;
            if (!LoadDate())
            {
                return;
            }
            this.dateTimePickerOperateDate.Format = DateTimePickerFormat.Custom;
            // this.dateTimePickerOperateDate.ShowUpDown = true;
            this.dateTimePickerOperateDate.CustomFormat = "yyyy-MM";

            this.dateTimePickerOperateDateEnd.Format = DateTimePickerFormat.Custom;
            //this.dateTimePickerOperateDateEnd.ShowUpDown = true;
            this.dateTimePickerOperateDateEnd.CustomFormat = "yyyy-MM";
            //this.dateTimePickerOperateDate.Value = Convert.ToDateTime(DateTime.Now.ToString());
            this.dateTimePickerOperateDate.Value = Convert.ToDateTime(DateTime.Today.ToString());
            this.dateTimePickerOperateDateEnd.Value = Convert.ToDateTime(DateTime.Today.AddMonths(+2).ToString());

        }

        private void frmOrderInFromERPDB_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Width = this.Width - 20;
            groupBox1.Height = this.Height - 675;
            groupBox2.Width = this.Width - 20;
            groupBox4.Width = this.Width - 230;
            groupBox5.Width = this.Width - 30;
        }

        private void frmOrderInFromERPDB_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
