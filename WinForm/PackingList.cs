using JITSystem.BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinForm
{
    public partial class PackingList : Form
    {

        static PackingList frm = null;
        BackgroundWorker bgWorker = new BackgroundWorker();
        Secont secont = new Secont();
        public static PackingList GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            //if (frm == null)
            {
                frm = new PackingList();
            }
            return frm;
        }
        public PackingList()
        {
            InitializeComponent();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            //bgWorker.DoWork += DoWork_Handler;
            bgWorker.DoWork += DoWork_AutoCreatePackList;
            bgWorker.ProgressChanged += ProgressChanged_Handler;
            bgWorker.RunWorkerCompleted += RunWorkerCompleted_Handler;
        }
        private void ProgressChanged_Handler(object sender, ProgressChangedEventArgs args)
        {
            jingdutiao.Value = args.ProgressPercentage;
            txtjingdutiao.Text = "已完成" + ((int)args.ProgressPercentage).ToString() + "%";
            yitiaoshu.Text = "已导入指令号数量：" + (secont.Value).ToString() + " .共有" + secont.LinesCount.ToString() + " 个指令号！";

            if (dataGridViewPacking.Columns.Count <= 0)
            {
                DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
                acCode.Name = "LOG";
                acCode.HeaderText = "Run Log";
                dataGridViewPacking.Columns.Add(acCode);
                dataGridViewPacking.Columns[0].Width = 500;
            }

            this.dataGridViewPacking.MultiSelect = false;
            DataGridViewRow dr = new DataGridViewRow();
            dr.CreateCells(dataGridViewPacking);
            dr.Cells[0].Value = secont.Log;
            dataGridViewPacking.Rows.Insert(0, dr);
            dataGridViewPacking.Rows[0].Selected = true;
            dataGridViewPacking.FirstDisplayedScrollingRowIndex = 0;
            yiyongshi.Text = Convert.ToString(secont.EllapsedSec);
            zongyongshi.Text = Convert.ToString(secont.CountSec);
            // WriteTxt(secont.Log);
        }
        public void WriteTxt(string str)
        {
            string rstr = "";
            string Path = Application.StartupPath + "\\Log.txt";

            // DirectoryInfo TheFolder = new DirectoryInfo("F:\\OneDrive\\VS2015Projects\\WRJIT\\WinForm\\bin\\Debug\\Log.txt");
            if (File.Exists(Path))
            {
                StreamReader sr = new StreamReader(Application.StartupPath + "\\Log.txt", false);
                rstr = sr.ReadLine().ToString();
                Thread.Sleep(100);
                sr.Close();
            }

            // this.textBox1.Text = str;///读取     
            str = str + "\r\n" + rstr;

            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Log.txt", false);
            sw.WriteLine(str);
            Thread.Sleep(100);
            sw.Close();
        }
        private void RunWorkerCompleted_Handler(object sender, RunWorkerCompletedEventArgs args)
        {
            jingdutiao.Value = 0;
            if (args.Error != null)
            {
                MessageBox.Show(args.Error.Message);
            }
            else if (args.Cancelled)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("导入任务已经被取消。", "消息");
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("导入完成。", "消息");
            }

        }
        private void getPhoto(string StyleCode)
        {
            Cursor = Cursors.WaitCursor;
            Packinglistbll pk = new Packinglistbll();
            byte[] rtfbyte = pk.getPhoto(StyleCode);
            // ShowImg(pk.getPhoto(OrderBoxDocID));
            if (rtfbyte != null)
            {
                ShowImg(rtfbyte);
            }
            Cursor = Cursors.Default;
        }
        private void ShowImg(byte[] imgBytes)
        {
            try
            {
                //  FileStream fs = new FileStream(@"C:\1.png" ,FileMode.Create, FileAccess.Write, FileShare.None);
                // // byte[] farr = new byte[1024];
                // // const int rbuffer = 1024;
                // // while (fs.Read(imgBytes, 0, rbuffer) != 0) //返回0表示读完  
                // // {
                //      fs.Write(imgBytes, 0,imgBytes.Length);
                ////  }
                //  fs.Close();

                MemoryStream stream = new MemoryStream(imgBytes);
                Image image = Image.FromStream(stream, true);
                //  Image image = new Bitmap(stream);
                this.picMT.Image = image;
                stream.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            // ds.Clear(); ds.Dispose();

            // this.pictureBox1.Image = image;


        }
        void DisplayCol(DataGridView dgv, String dataPropertyName, String headerText)
        {
            dgv.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn obj = new DataGridViewTextBoxColumn();
            obj.DataPropertyName = dataPropertyName;
            obj.HeaderText = headerText;
            obj.Name = dataPropertyName;
            obj.Resizable = DataGridViewTriState.True;
            dgv.Columns.AddRange(new DataGridViewColumn[] { obj });
        }
        private void PackingList_Load(object sender, EventArgs e)
        {
            dataGridViewPacking.AllowUserToAddRows = false;
            // Control.CheckForIllegalCrossThreadCalls = false;
            //btnReLink.Visible = false;
            //if (!LoadDate())
            //{
            //    return;
            //}
            this.dateTimePickerOperateDate.Format = DateTimePickerFormat.Custom;
            // this.dateTimePickerOperateDate.ShowUpDown = true;
            this.dateTimePickerOperateDate.CustomFormat = "yyyy-MM";

            this.dateTimePickerOperateDateEnd.Format = DateTimePickerFormat.Custom;
            //this.dateTimePickerOperateDateEnd.ShowUpDown = true;
            this.dateTimePickerOperateDateEnd.CustomFormat = "yyyy-MM";
            //this.dateTimePickerOperateDate.Value = Convert.ToDateTime(DateTime.Now.ToString());
            this.dateTimePickerOperateDate.Value = Convert.ToDateTime(DateTime.Today.AddMonths(-1).ToString());
            this.dateTimePickerOperateDateEnd.Value = Convert.ToDateTime(DateTime.Today.AddMonths(-1).ToString());


        }
        private void dataGridViewPacking_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }
        private void dataGridViewOrderBoxDocDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }
        private void nulldv()
        {
            dataGridViewPacking.DataSource = null;
            dataGridViewOrderBoxDocDetail.DataSource = null;
            int j = dataGridViewPacking.ColumnCount;
            for (int i = 0; i < j; j--)
            {
                dataGridViewPacking.Columns.RemoveAt(j - 1);
            }
            j = dataGridViewOrderBoxDocDetail.ColumnCount;
            for (int i = 0; i < j; j--)
            {
                dataGridViewOrderBoxDocDetail.Columns.RemoveAt(j - 1);
            }
            this.picMT.Image = null;
        }
        private void PackingList_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void butSave_Click(object sender, EventArgs e)
        {
            //bool autopk = false;
            SaveDataTable();
        }
        public void SaveDataTable()
        {
            Cursor = Cursors.WaitCursor;
            if (picMT.Image == null)
            {
                if (DialogResult.Yes == (MessageBox.Show("没有唛头图片，是否继续保存", "提示", MessageBoxButtons.YesNo)))
                {
                    //保存
                    //  MessageBox.Show("是");
                }
                else
                {
                    Cursor = Cursors.Default;
                    return;
                }
            }
            //保存订单信息
            DataTable table = (dataGridViewPacking.DataSource as DataTable);
            try
            {
                if (table == null || table.Rows.Count <= 0)
                {
                    MessageBox.Show("没有装箱单数据");
                    Cursor = Cursors.Default;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Cursor = Cursors.Default;
                return;
            }
            PackList pk = new PackList();
            Packinglistbll pkbll = new Packinglistbll();

            //写入前比较，如果已有  不保存
            pk.CustomStyleCode = Convert.ToString(table.Rows[0]["CustomStyleCode"]);
            DataTable dt = pkbll.getCodeFromPackList(pk.CustomStyleCode);
            bool Code = false;
            if (dt != null)
            {
                if (dt.Rows.Count <= 0)
                {
                    Code = false;
                }
                else
                {
                    Code = true;
                }
            }
            else
            {
                Code = false;
            }


            //bool updb = false; //更新标志
            if (Code)
            {
                if (DialogResult.No == (MessageBox.Show("此指令号已保存，是否更新", "提示", MessageBoxButtons.YesNo)))
                {
                    
                    //updb = true;//允许更新标志
                    //更新语句
                    //  MessageBox.Show("是");
                //}
                //else
                //{

                    Cursor = Cursors.Default;
                    return;
                }
                pkbll.delCodeFromPackList(pk.CustomStyleCode);
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];
                if (dr["CustomName"] is DBNull == false)
                {
                    pk.CustomName = Convert.ToString(dr["CustomName"]);
                }
                if (dr["GoodsTypeEnName"] is DBNull == false)
                {
                    pk.GoodsTypeEnName = Convert.ToString(dr["GoodsTypeEnName"]);
                }
                if (dr["CustomStyleName"] is DBNull == false)
                {
                    pk.CustomStyleName = Convert.ToString(dr["CustomStyleName"]);
                }
                if (dr["CustomStyleCode"] is DBNull == false)
                {
                    pk.CustomStyleCode = Convert.ToString(dr["CustomStyleCode"]);
                }
                if (dr["SizeName"] is DBNull == false)
                {
                    pk.SizeName = Convert.ToString(dr["SizeName"]); //  尺码
                }
                if (dr["TotalCount"] is DBNull == false)
                {
                    pk.TotalCount = Convert.ToString(dr["TotalCount"]);//尺码数量
                }
                if (dr["CutNo"] is DBNull == false)
                {
                    pk.CutNo = Convert.ToString(dr["CutNo"]);
                }
                if (dr["ManufactureOrder"] is DBNull == false)
                {
                    pk.ManufactureOrder = Convert.ToString(dr["ManufactureOrder"]);
                }
                if (dr["CustomPO"] is DBNull == false)
                {
                    pk.CustomPO = Convert.ToString(dr["CustomPO"]);
                }
                if (dr["ColorGroupName"] is DBNull == false)
                {
                    pk.ColorGroupName = Convert.ToString(dr["ColorGroupName"]);
                }
                if (dr["BoxSize"] is DBNull == false)
                {
                    pk.BoxSize = Convert.ToString(dr["BoxSize"]);
                }
                if (dr["BoxNoTotal"] is DBNull == false)
                {
                    pk.BoxNoTotal = Convert.ToInt32(dr["BoxNoTotal"]);
                }
                if (dr["PerCount"] is DBNull == false)
                {
                    pk.PerCount = Convert.ToInt32(dr["PerCount"]);
                }
                if (dr["perCountTotal"] is DBNull == false)
                {
                    pk.perCountTotal = Convert.ToInt32(dr["perCountTotal"]);
                }
                if (dr["NW"] is DBNull == false)
                {
                    pk.NW = Convert.ToDouble(dr["NW"]);
                }
                if (dr["TNW"] is DBNull == false)
                {
                    pk.TNW = Convert.ToDouble(dr["TNW"]);
                }
                if (dr["GW"] is DBNull == false)
                {
                    pk.GW = Convert.ToDouble(dr["GW"]);
                }
                if (dr["TGW"] is DBNull == false)
                {
                    pk.TGW = Convert.ToDouble(dr["TGW"]);
                }
                if (dr["BoxVolume"] is DBNull == false)
                {
                    pk.BoxVolume = Convert.ToDouble(dr["BoxVolume"]);
                }
                if (dr["MT"] is DBNull == false)
                {
                    pk.MT = Convert.ToDouble(dr["MT"]);
                }
                if (dr["BOXTONO"] is DBNull == false)
                {
                    pk.BOXTONO = Convert.ToString(dr["BOXTONO"]);
                }
                if (dr["Totsumcount"] is DBNull == false)
                {
                    pk.Totsumcount = Convert.ToInt32(dr["Totsumcount"]);
                }
                if (dr["Boxsumcount"] is DBNull == false)
                {
                    pk.Boxsumcount = Convert.ToInt32(dr["Boxsumcount"]);
                }
                if (dr["OrderDate"] is DBNull == false)
                {
                    pk.OrderDate = Convert.ToString(dr["OrderDate"]);
                }

                //计算箱号
                int starno = 0;
                int endnos = 0;

                String[] strs = Convert.ToString(dr["BOXTONO"]).Split('-');
                starno = Convert.ToInt32(strs[0]);
                endnos = Convert.ToInt32(strs[1]);

                for (int k = starno; k <= endnos; k++)
                {
                    pk.guid = Guid.NewGuid();
                    pk.BOXNO = Convert.ToString(k);//需要计算 箱号
                    //写入库 或更新库  updb=true 更新
                    //if (updb)
                    //{
                    //    //string guid = "";
                    //    //for (int j=0;j<dt.Rows.Count;j++)
                    //    //{
                    //    //    guid = dt.Rows[j][0].ToString();
                    //    //    pkbll.pkUpDb(pk,guid);
                    //    //}
                    //}
                    //else
                    //{
                   

                        pkbll.pkUpDb(pk);
                    //}

                }
            }

            //保存内盒信息
            DataTable boxtable = (dataGridViewOrderBoxDocDetail.DataSource as DataTable);
            packlistbox pkbox = new packlistbox();
            try
            {
                if (boxtable == null || boxtable.Rows.Count <= 0)
                {
                    MessageBox.Show("没有内盒数据");
                    Cursor = Cursors.Default;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Cursor = Cursors.Default;
                return;
            }
            for (int i = 0; i < boxtable.Rows.Count - 1; i++)
            {
                pkbox.guid = Guid.NewGuid();
                DataRow dr = boxtable.Rows[i];
                pkbox.PC = Convert.ToString(dr["PerBoxCount"]);
                pkbox.BoxSize = Convert.ToString(dr["boxspec"]);
                pkbox.MT = Convert.ToString(dr["BoxSize"]);
                pkbox.CCBM = Convert.ToString(dr["ccmb"]);
                pkbox.CTNS = Convert.ToInt32(dr["BoxNOtotal"]);
                pkbox.CBM = Convert.ToString(dr["CMB"]);
                pkbox.SizeTo = Convert.ToString(dr["sizename"]);
                pkbox.CoutomCode = Convert.ToString(dr["CustomStyleCode"]);
                //写入库 或更新库

                //if (updb)
                //{
                //    //string guid = "";
                //    //for (int j = 0; j < boxtable.Rows.Count; j++)
                //    //{
                //    //    guid = dt.Rows[j][0].ToString();
                //    //  //  pkbll.pkboxUpDb(pkbox, guid);
                //    //}
                //}
                //else
                //{
                    pkbll.pkboxUpDb(pkbox);
                //}

            }
            //保存唛头图片
            if (picMT.Image != null)
            {
                byte[] picMTphoto = GetImageBytes(picMT.Image);
                DataRow dr = boxtable.Rows[0];
                string CoutomCode = Convert.ToString(dr["CustomStyleCode"]);
                //查是此指令是否有图片
                DataTable tb = pkbll.getMTphoto(CoutomCode);
                //写入库 或更新库
                bool updb = false;//是否有唛头图片
                if (tb.Rows.Count <= 0)
                {
                    updb = false;
                    //MessageBox.Show("此指令号没有唛头图片");
                    //return;
                }
                if (updb)
                {
                    string guid = "";
                    for (int j = 0; j < tb.Rows.Count; j++)
                    {
                        guid = tb.Rows[j][0].ToString();
                        pkbll.MTphotoUpDbByguid(picMTphoto, guid);
                    }
                }
                else
                {
                    pkbll.MTphotoUpDb(picMTphoto, CoutomCode);
                }
            }
            MessageBox.Show("保存完成");
            Cursor = Cursors.Default;
        }
        private byte[] GetImageBytes(Image image)
        {
            MemoryStream mstream = new MemoryStream();
            image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byteData, 0, byteData.Length);
            mstream.Close();
            return byteData;
        }
        private void butSelectPK_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdphoto = new OpenFileDialog();
            ofdphoto.Filter = "jpg图片|*.jpg|png图片|*.png|gif图片|*.jif|bmp图片|*.bmp";

            ofdphoto.ShowDialog(this);

            String filename = ofdphoto.FileName;
            if (filename.Length <= 0)
            {
                return;
            }

            byte[] picMTphoto = File.ReadAllBytes(filename);
            picMT.Image = Image.FromFile(filename);

        }
        public void createPackList(string wherestr, bool autopk, string CustomStyleCode)
        {
            Packinglistbll pk = new Packinglistbll();
            Cursor = Cursors.WaitCursor;
            dataGridViewPacking.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
            dataGridViewPacking.AutoGenerateColumns = false;
            dataGridViewOrderBoxDocDetail.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
            dataGridViewOrderBoxDocDetail.AutoGenerateColumns = false;
            //string CustomStyleCode = txtCreateCustomStyleCode.Text;
            //string wherestr="";
            //bool autopk = false;
            //if (radCustomCode.Checked == false &&
            //    radFactoryOperateDate.Checked == false)
            //{
            //    MessageBox.Show("请选择一个生成条件！");
            //    Cursor = Cursors.Default;
            //    return;
            //}
            //if (radCustomCode.Checked == true && CustomStyleCode.Length <= 0)
            //{
            //    MessageBox.Show("指令号不能为空！");
            //    Cursor = Cursors.Default;
            //    return;
            //}

            //if (radCustomCode.Checked == true && CustomStyleCode.Length > 0)//指令号条件
            //{
            //    autopk = false;
            //    wherestr = "CustomStyleCode = '" + CustomStyleCode + "'";
            //}
            //
            //if (radFactoryOperateDate.Checked == true) //订单年月条件
            //{
            //    autopk = true;
            //    DateTime time1 = Convert.ToDateTime(dateTimePickerOperateDate.Value.Date.ToString("yyyy-MM"));
            //    DateTime time2 = Convert.ToDateTime(dateTimePickerOperateDateEnd.Value.Date.ToString("yyyy-MM"));
            //    if (DateTime.Compare(time1, time2) > 0) //判断日期大小
            //    {
            //        MessageBox.Show("结束日期不能小于开始日期！");
            //        Cursor = Cursors.Default;
            //        return;
            //    }
            //    String strtime1 = dateTimePickerOperateDate.Value.Date.ToString("yyyy-MM");
            //    String strtime2 = dateTimePickerOperateDateEnd.Value.Date.ToString("yyyy-MM");

            //    wherestr = "OrderDate between '" + strtime1 + "' and '" + strtime2 + "'";
            //}

            DataTable Customstrtb = new DataTable();
            Customstrtb = pk.getCustomstr(wherestr);
            if (Customstrtb.Rows.Count <= 0)
            {
                if (!autopk)
                {
                    MessageBox.Show("沒有找到數據，可能此訂單還未做裝箱！");
                }
                nulldv();
                Cursor = Cursors.Default;
                return;
            }
            DataTable table = new DataTable();

            /*下面循环检查出表*/
            for (int k = 0; k < Customstrtb.Rows.Count; k++)  //自动装箱单开始
            {
                if (Customstrtb.Rows[k]["BatchOrderBoxID"].ToString().Length <= 0 )
               // {
              //     
              //  }
              //  else 
                {
                    if (!autopk)//手动时提示
                    {
                        MessageBox.Show(txtCreateCustomStyleCode.Text + "还未做装箱单！");
                    }

                    nulldv();
                    Cursor = Cursors.Default;
                    continue;
                }

                CustomStyleCode = Customstrtb.Rows[k]["BatchOrderBoxID"].ToString();
                table = pk.getPacking(CustomStyleCode);//装箱单

                if (table.Rows.Count <= 0)
                {
                    if (!autopk)//手动时提示
                    {
                        MessageBox.Show("沒有找到數據，可能此訂單還未做裝箱！");
                    }

                    nulldv();
                    Cursor = Cursors.Default;
                    continue;
                }
                /*加载到写入表*/
                //  loadDataTable(table);
                /*主體*/
                nulldv();
                dataGridViewPacking.DataSource = table;
                string OrderBoxDocID = table.Rows[0][20].ToString();
                DisplayCol(dataGridViewPacking, "CutNo", "PO NO");
                DisplayCol(dataGridViewPacking, "ManufactureOrder", "LOT NO ORD / NO");
                DisplayCol(dataGridViewPacking, "CustomPO", "訂單號");
                DisplayCol(dataGridViewPacking, "ColorGroupName", "COLOR");
                DisplayCol(dataGridViewPacking, "BoxSize", "外箱規格");
                DisplayCol(dataGridViewPacking, "BoxNoTotal", "CTN");
                DisplayCol(dataGridViewPacking, "PerCount", "PRS/CTNS");
                DisplayCol(dataGridViewPacking, "perCountTotal", "TOTAL/PRS");
                DisplayCol(dataGridViewPacking, "NW", "N.W");
                DisplayCol(dataGridViewPacking, "TNW", "T/N.W");
                DisplayCol(dataGridViewPacking, "GW", "G.W");
                DisplayCol(dataGridViewPacking, "TGW", "T/G.W");
                DisplayCol(dataGridViewPacking, "BoxVolume", "CBM");
                DisplayCol(dataGridViewPacking, "MT", "M/T");
                DisplayCol(dataGridViewPacking, "BOXTONO", "C/NO");


                /*統計*/
                int d = table.Columns.Count;
                string columnsname = "";
                bool isHaveColumns = true;
                int f = 0;
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    columnsname = table.Rows[i][9].ToString();
                    isHaveColumns = true;
                    int j = 0;
                    for (j = 0; j < table.Columns.Count; j++)
                    {
                        if (table.Columns[j].ToString() != columnsname)
                        {
                            isHaveColumns = false;
                        }
                        else
                        {
                            isHaveColumns = true;
                            break;
                        }
                    }
                    //全部沒有 增加列
                    if (!isHaveColumns)
                    {
                        table.Columns.Add(table.Rows[i][9].ToString());//增加列
                        table.Rows[i][d + i - f] = table.Rows[i][10].ToString();//列名稱
                        DisplayCol(dataGridViewPacking, table.Rows[i][9].ToString(), table.Rows[i][9].ToString());
                    }
                    else if (isHaveColumns)
                    {
                        //有列 赋值
                        table.Rows[i][j] = table.Rows[i][10].ToString();//列名稱
                        f++;
                    }
                }



                /*表頭*/
                txtCustomName.Text = table.Rows[0][0].ToString();
                txtGoodsTypeEnName.Text = table.Rows[0][1].ToString();
                txtcustomstylename.Text = table.Rows[0][2].ToString();
                txtCustomStyleCode2.Text = table.Rows[0][3].ToString();
                txtTotsumcount.Text = table.Rows[0][19].ToString();
                int Boxsumcount = 0;
                for (int c = 0; c < table.Rows.Count; c++)
                {
                    if (table.Rows[c][18] != DBNull.Value)
                    {
                        Boxsumcount = Boxsumcount + Convert.ToInt32(table.Rows[c][18]);
                    }

                }
                txtBoxsumcount.Text = Boxsumcount.ToString();
                //   txtSumMT.Text = c.ToString();
                string BatchOrderBoxID = table.Rows[0][20].ToString();

                DataTable boxTable = new DataTable();
                boxTable = pk.getBox(BatchOrderBoxID);
                dataGridViewOrderBoxDocDetail.DataSource = boxTable;
                DisplayCol(dataGridViewOrderBoxDocDetail, "PerBoxCount", "P/C");
                DisplayCol(dataGridViewOrderBoxDocDetail, "boxspec", "BOX SIZE");
                DisplayCol(dataGridViewOrderBoxDocDetail, "BoxSize", "M/T");
                DisplayCol(dataGridViewOrderBoxDocDetail, "ccmb", "C/CBM");
                DisplayCol(dataGridViewOrderBoxDocDetail, "BoxNOtotal", "CTNS");
                DisplayCol(dataGridViewOrderBoxDocDetail, "CMB", "CBM");
                DisplayCol(dataGridViewOrderBoxDocDetail, "sizename", "SIZE");
                DisplayCol(dataGridViewOrderBoxDocDetail, "CustomStyleCode", "指令單號");
                int ctns = 0;
                decimal cbm = 0;

                for (int i = 0; i < boxTable.Rows.Count; i++)
                {
                    ctns += Convert.ToInt32(boxTable.Rows[i][4].ToString());
                    cbm += Convert.ToDecimal(boxTable.Rows[i][5].ToString());
                }
                DataRow dr = boxTable.NewRow();
                dr[3] = "合計";
                dr[4] = ctns;
                dr[5] = cbm;
                boxTable.Rows.Add(dr);
                // boxTable.Rows.Add(dr);
                txtSumMT.Text = cbm.ToString();
                //唛头
                //保存的为word文件
                //getPhoto(OrderBoxDocID);
                butSelectPK.Enabled = true;
                butSave.Enabled = true;

                /*下面保存表*/
                // if (autopk)
                //  {
                //    SaveDataTable();
                //  }

            }//自动保存循环结速
             /// if (autopk)
            //  {
            //     int c = Convert.ToInt32(Customstrtb.Rows.Count);
            //     MessageBox.Show("合部保全完成，共保存 " + c.ToString() + " 个指令号");
            //  }

            Cursor = Cursors.Default;


        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            butSelectPK.Enabled = false;
            butSave.Enabled = false;
            Packinglistbll pk = new Packinglistbll();
            string CustomStyleCode = txtCustomStyleCode.Text;
            if (ckFactoryOrderCode.Checked == false)
            {
                return;
            }
            if (txtCustomStyleCode.Text.Length <= 0)
            {
                MessageBox.Show("指令号不能为空！");
                return;
            }
            Cursor = Cursors.WaitCursor;
            dataGridViewPacking.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
            dataGridViewPacking.AutoGenerateColumns = false;
            dataGridViewOrderBoxDocDetail.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
            dataGridViewOrderBoxDocDetail.AutoGenerateColumns = false;
            DataTable table = new DataTable();
            table = pk.pkGetDb(CustomStyleCode);
            //  table = pk.getPacking(CustomStyleCode);
            if (table == null)
            {
                MessageBox.Show("沒有找到此指令号，请先生成装箱单！");
                nulldv();
                Cursor = Cursors.Default;

                return;
            }
            if (table.Rows.Count <= 0)
            {
                MessageBox.Show("沒有找到此指令号，请先生成装箱单！");
                nulldv();
                Cursor = Cursors.Default;
                return;
            }
            /*加载到写入表*/
            //  loadDataTable(table);
            /*主體*/
            nulldv();
            dataGridViewPacking.DataSource = table;
            // string OrderBoxDocID = table.Rows[0][20].ToString();
            DisplayCol(dataGridViewPacking, "CustonName", "客户");
            DisplayCol(dataGridViewPacking, "GoodsTypeEnName", "鞋型类别");
            DisplayCol(dataGridViewPacking, "CustoStyleName", "客户型体");
            DisplayCol(dataGridViewPacking, "CustomStyleCode", "指令号");
            //   DisplayCol(dataGridViewPacking, "SizeName", "尺码");
            // DisplayCol(dataGridViewPacking, "TotalCount", "尺码数量");
            DisplayCol(dataGridViewPacking, "CutNo", "PO NO");
            DisplayCol(dataGridViewPacking, "ManufactureOrder", "LOT NO ORD / NO");
            DisplayCol(dataGridViewPacking, "CustomPO", "訂單號");
            DisplayCol(dataGridViewPacking, "ColorGroupName", "COLOR");
            DisplayCol(dataGridViewPacking, "BoxSize", "外箱規格");
            DisplayCol(dataGridViewPacking, "BoxNoTotal", "CTN");
            DisplayCol(dataGridViewPacking, "PerCount", "PRS/CTNS");
            DisplayCol(dataGridViewPacking, "perCountTotal", "TOTAL/PRS");
            DisplayCol(dataGridViewPacking, "NW", "N.W");
            DisplayCol(dataGridViewPacking, "TNW", "T/N.W");
            DisplayCol(dataGridViewPacking, "GW", "G.W");
            DisplayCol(dataGridViewPacking, "TGW", "T/G.W");
            DisplayCol(dataGridViewPacking, "BoxVolume", "CBM");
            DisplayCol(dataGridViewPacking, "MT", "M/T");
            DisplayCol(dataGridViewPacking, "BOXTONO", "C/NO");
            DisplayCol(dataGridViewPacking, "BOXNO", "箱号");
            DisplayCol(dataGridViewPacking, "Totsumcount", "总双数");
            DisplayCol(dataGridViewPacking, "Boxsumcount", "总箱数");


            /*統計*/
            int d = table.Columns.Count;
            string columnsname = "";
            bool isHaveColumns = true;
            int f = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                columnsname = table.Rows[i][5].ToString();
                isHaveColumns = true;
                int j = 0;
                for (j = 0; j < table.Columns.Count; j++)
                {
                    if (table.Columns[j].ToString() != columnsname)
                    {
                        isHaveColumns = false;
                    }
                    else
                    {
                        isHaveColumns = true;
                        break;
                    }
                }
                //全部沒有 增加列
                if (!isHaveColumns)
                {
                    table.Columns.Add(table.Rows[i][5].ToString());//增加列
                    table.Rows[i][d + i - f] = table.Rows[i][6].ToString();//列名稱
                    DisplayCol(dataGridViewPacking, table.Rows[i][5].ToString(), table.Rows[i][5].ToString());
                }
                else if (isHaveColumns)
                {
                    //有列 赋值
                    table.Rows[i][j] = table.Rows[i][6].ToString();//列名稱
                    f++;
                }
            }

            /*表頭*/
            txtCustomName.Text = table.Rows[0][1].ToString();
            txtGoodsTypeEnName.Text = table.Rows[0][2].ToString();
            txtcustomstylename.Text = table.Rows[0][3].ToString();
            txtCustomStyleCode2.Text = table.Rows[0][4].ToString();
            txtTotsumcount.Text = table.Rows[0][23].ToString();
            //int Boxsumcount = 0;
            //for (int c = 0; c < table.Rows.Count; c++)
            //{
            //    Boxsumcount = Boxsumcount + Convert.ToInt32(table.Rows[c][24]);
            //}
            //txtBoxsumcount.Text = Boxsumcount.ToString();

            txtBoxsumcount.Text = table.Rows[0][24].ToString();

            //string BatchOrderBoxID = table.Rows[0][20].ToString();
            string StyleCode = table.Rows[0][4].ToString();

            //内盒信息
            DataTable boxTable = new DataTable();
            boxTable = pk.getboxPkFromDB(StyleCode);
            if (boxTable != null)
            {



                // boxTable = pk.getBox(StyleCode);
                dataGridViewOrderBoxDocDetail.DataSource = boxTable;
                DisplayCol(dataGridViewOrderBoxDocDetail, "PC", "P/C");
                DisplayCol(dataGridViewOrderBoxDocDetail, "Boxsize", "BOX SIZE");
                DisplayCol(dataGridViewOrderBoxDocDetail, "MT", "M/T");
                DisplayCol(dataGridViewOrderBoxDocDetail, "CCBM", "C/CBM");
                DisplayCol(dataGridViewOrderBoxDocDetail, "CTNS", "CTNS");
                DisplayCol(dataGridViewOrderBoxDocDetail, "CBM", "CBM");
                DisplayCol(dataGridViewOrderBoxDocDetail, "Sizeto", "SIZE");
                DisplayCol(dataGridViewOrderBoxDocDetail, "CoutomCode", "指令單號");
                int ctns = 0;
                decimal cbm = 0;


                for (int i = 0; i < boxTable.Rows.Count; i++)
                {
                    ctns += Convert.ToInt32(boxTable.Rows[i][5].ToString());
                    cbm += Convert.ToDecimal(boxTable.Rows[i][6].ToString());
                }
                DataRow dr = boxTable.NewRow();
                dr[4] = "合計";
                dr[5] = ctns;
                dr[6] = cbm;
                boxTable.Rows.Add(dr);
                // boxTable.Rows.Add(dr);
                txtSumMT.Text = cbm.ToString();
            }

            ////唛头
            ////保存的为word文件
            getPhoto(StyleCode);
            Cursor = Cursors.Default;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Packinglistbll pk = new Packinglistbll();
            string CustomStyleCode = txtCreateCustomStyleCode.Text;
            string wherestr = "";
            bool autopk = false;
            if (radCustomCode.Checked == false &&
                radFactoryOperateDate.Checked == false)
            {
                MessageBox.Show("请选择一个生成条件！");
                Cursor = Cursors.Default;
                return;
            }
            if (radCustomCode.Checked == true && CustomStyleCode.Length <= 0)
            {
                MessageBox.Show("指令号不能为空！");
                Cursor = Cursors.Default;
                return;
            }

            if (radCustomCode.Checked == true && CustomStyleCode.Length > 0)//指令号条件
            {
                autopk = false;
                wherestr = "CustomStyleCode = '" + CustomStyleCode + "'";
            }
            // DataTable Customstrtb = new DataTable();
            if (radFactoryOperateDate.Checked == true) //订单年月条件
            {
                autopk = true;
                DateTime time1 = Convert.ToDateTime(dateTimePickerOperateDate.Value.Date.ToString("yyyy-MM"));
                DateTime time2 = Convert.ToDateTime(dateTimePickerOperateDateEnd.Value.Date.ToString("yyyy-MM"));
                if (DateTime.Compare(time1, time2) > 0) //判断日期大小
                {
                    MessageBox.Show("结束日期不能小于开始日期！");
                    Cursor = Cursors.Default;
                    return;
                }
                String strtime1 = dateTimePickerOperateDate.Value.Date.ToString("yyyy-MM");
                String strtime2 = dateTimePickerOperateDateEnd.Value.Date.ToString("yyyy-MM");

                wherestr = "OrderDate between '" + strtime1 + "' and '" + strtime2 + "'";
            }


            if (!autopk)
            {
                createPackList(wherestr, autopk, CustomStyleCode);
            }
            else
            {
                nulldv();
                if (!bgWorker.IsBusy)
                {
                    bgWorker.RunWorkerAsync();
                }
            }

        }
        public void DoWork_AutoCreatePackList(object sender, DoWorkEventArgs args)
        {

            BackgroundWorker worker = sender as BackgroundWorker;
            Packinglistbll pk = new Packinglistbll();
            DateTime startime = DateTime.Now;

            string wherestr = "";
            string CustomStyleCode = "";
            string BatchOrderBoxID = "";
            String strtime1 = "";
            String strtime2 = "";
            // bool autopk = false;
            DataTable Customstrtb = new DataTable();
            if (radFactoryOperateDate.Checked == true) //订单年月条件
            {
                //  autopk = true;
                DateTime time1 = Convert.ToDateTime(dateTimePickerOperateDate.Value.Date.ToString("yyyy-MM"));
                DateTime time2 = Convert.ToDateTime(dateTimePickerOperateDateEnd.Value.Date.ToString("yyyy-MM"));
                if (DateTime.Compare(time1, time2) > 0) //判断日期大小
                {
                    //MessageBox.Show("结束日期不能小于开始日期！");
                    worker.ReportProgress(1 / 1, secont);
                    secont.Log = DateTime.Now.ToString() + " :结束日期不能小于开始日期";
                    return;
                }
                strtime1 = dateTimePickerOperateDate.Value.Date.ToString("yyyy-MM");
                strtime2 = dateTimePickerOperateDateEnd.Value.Date.ToString("yyyy-MM");

                wherestr = "OrderDate between '" + strtime1 + "' and '" + strtime2 + "'";

                secont.Log = DateTime.Now.ToString() + " :正在查找订单年月为：'" + strtime1.ToString() + "' - '" + strtime2.ToString() + "' 的指令号...";
                worker.ReportProgress(1 / 1, secont);
                Thread.Sleep(100);
            }

            Customstrtb = pk.getCustomstr(wherestr);

            if (Customstrtb.Rows.Count <= 0)
            {
                //MessageBox.Show("沒有找到數據，可能此訂單還未做裝箱！"); //写入日志  指令号

                secont.Log = DateTime.Now.ToString() + " ：" + strtime1 + " - " + strtime2 + "未找到数据。此月份中无订单";
                worker.ReportProgress(1 / 1, secont);
                return;


            }

            secont.Log = DateTime.Now.ToString() + " :共找到订单：" + Customstrtb.Rows.Count.ToString() + " 个指令号,开始生成装箱明细表...";
            worker.ReportProgress(1 * 100 / Customstrtb.Rows.Count, secont);
            Thread.Sleep(100);
            DataTable table = new DataTable();


            for (int k = 0; k < Customstrtb.Rows.Count; k++)
            {
                int t = k;
                if (worker.CancellationPending)
                {

                    secont.Log = DateTime.Now.ToString() + " :用户取消任务";
                    worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);

                    Thread.Sleep(100);
                    args.Cancel = true;
                    break;
                }

                else
                {
                    // worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                    //Thread.Sleep(100);
                    if (Customstrtb.Rows[k][0].ToString().Length > 0)
                    {
                        CustomStyleCode = Customstrtb.Rows[k]["CustomStyleCode"].ToString();
                        BatchOrderBoxID = Customstrtb.Rows[k]["BatchOrderBoxID"].ToString();

                    }
                    else
                    {
                        CustomStyleCode = Customstrtb.Rows[k]["CustomStyleCode"].ToString();
                        secont.Log = DateTime.Now.ToString() + " :指令号：'" + CustomStyleCode + "'，未找到数据。此訂單還未做裝箱";
                        worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                        Thread.Sleep(100);
                        continue;
                    }
                    //先查询本地是否已有

                    secont.Log = DateTime.Now.ToString() + " :正在确认是否已有指令号：" + CustomStyleCode.ToString() + " ...";
                    worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                    Thread.Sleep(100);
                    DataTable tabledb = pk.pkGetDb(CustomStyleCode);

                    PackList pklist = new PackList();
                    Packinglistbll pkbll = new Packinglistbll();
                    bool Code = false;
                    if (tabledb != null)
                    {
                        pklist.CustomStyleCode = Convert.ToString(tabledb.Rows[0]["CustomStyleCode"]);
                        DataTable dt = pkbll.getCodeFromPackList(pklist.CustomStyleCode);//标示
                        if (dt != null)
                        {
                            if (dt.Rows.Count <= 0)
                            {
                                Code = false;
                            }
                            else
                            {
                                Code = true;
                            }
                        }
                        else
                        {
                            Code = false;
                        }
                    }

                    if (Code)
                    {
                        secont.Log = DateTime.Now.ToString() + " :指令号：" + CustomStyleCode.ToString() + "已保存 ...";
                        worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                        Thread.Sleep(100);
                        continue;
                    }
                    secont.Log = DateTime.Now.ToString() + " :正在生成指令号为：" + CustomStyleCode.ToString() + " 的装箱明细..";
                    worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                    Thread.Sleep(100);
                    table = pk.getPacking(BatchOrderBoxID);//装箱单
                    if (table.Rows.Count <= 0)
                    {

                        secont.Log = DateTime.Now.ToString() + " :指令号为：" + CustomStyleCode.ToString() + " 没有找到数据,可能此訂單還未做裝箱..";
                        worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                        Thread.Sleep(100);
                        continue;
                    }

                    string OrderBoxDocID = table.Rows[0][20].ToString();

                    /*統計*/
                    int d = table.Columns.Count;
                    string columnsname = "";
                    bool isHaveColumns = true;
                    int f = 0;

                    secont.Log = DateTime.Now.ToString() + " :正在生成指令号：" + CustomStyleCode.ToString() + " 的SIZERUN...";
                    worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                    Thread.Sleep(100);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        columnsname = table.Rows[i][9].ToString();
                        isHaveColumns = true;
                        int j = 0;
                        for (j = 0; j < table.Columns.Count; j++)
                        {
                            if (table.Columns[j].ToString() != columnsname)
                            {
                                isHaveColumns = false;
                            }
                            else
                            {
                                isHaveColumns = true;
                                break;
                            }
                        }
                        //全部沒有 增加列
                        if (!isHaveColumns)
                        {
                            table.Columns.Add(table.Rows[i][9].ToString());//增加列
                            table.Rows[i][d + i - f] = table.Rows[i][10].ToString();//列名稱
                                                                                    //DisplayCol(dataGridViewPacking, table.Rows[i][9].ToString(), table.Rows[i][9].ToString());
                        }
                        else if (isHaveColumns)
                        {
                            //有列 赋值
                            table.Rows[i][j] = table.Rows[i][10].ToString();//列名稱
                            f++;
                        }
                    }

                    //  string BatchOrderBoxID = table.Rows[0][20].ToString();

                    DataTable boxTable = new DataTable();

                    secont.Log = DateTime.Now.ToString() + " :正在生成指令号：" + CustomStyleCode.ToString() + " 的内盒信息...";
                    worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                    Thread.Sleep(100);
                    boxTable = pk.getBox(BatchOrderBoxID);

                    int ctns = 0;
                    decimal cbm = 0;

                    for (int i = 0; i < boxTable.Rows.Count; i++)
                    {
                        ctns += Convert.ToInt32(boxTable.Rows[i][4].ToString());
                        cbm += Convert.ToDecimal(boxTable.Rows[i][5].ToString());
                    }
                    DataRow dr = boxTable.NewRow();
                    dr[3] = "合計";
                    dr[4] = ctns;
                    dr[5] = cbm;
                    boxTable.Rows.Add(dr);

                    secont.Log = DateTime.Now.ToString() + " :正在保存指令号：" + CustomStyleCode.ToString() + " 的装箱信息...";
                    worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                    Thread.Sleep(100);

                    //保存
                    /*------------------------------------------------*/

                    //保存订单信息

                    //  DataTable table = (dataGridViewPacking.DataSource as DataTable);

                    if (table == null || table.Rows.Count <= 0)
                    {
                        secont.Log = DateTime.Now.ToString() + " :指令号：" + CustomStyleCode.ToString() + " 没有装箱单数据...";
                        worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                        Thread.Sleep(100);
                        continue;
                    }

                    //secont.Log = DateTime.Now.ToString() + " :正在确认是否已有指令号：" + CustomStyleCode.ToString() + " ...";
                    //worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                    //Thread.Sleep(100);
                    //DataTable  tabledb = pk.pkGetDb(CustomStyleCode);

                    //PackList pklist = new PackList();
                    //Packinglistbll pkbll = new Packinglistbll();
                    //bool Code = false;
                    //if (tabledb != null)
                    //{
                    //    pklist.CustomStyleCode = Convert.ToString(tabledb.Rows[0]["CustomStyleCode"]);
                    //    DataTable dt = pkbll.getCodeFromPackList(pklist.CustomStyleCode);//标示
                    //    if (dt != null)
                    //    {
                    //        if (dt.Rows.Count <= 0)
                    //        {
                    //            Code = false;
                    //        }
                    //        else
                    //        {
                    //            Code = true;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        Code = false;
                    //    }
                    //}

                    //if (Code)
                    //{
                    //    secont.Log = DateTime.Now.ToString() + " :指令号：" + CustomStyleCode.ToString() + "已保存 ...";
                    //    worker.ReportProgress(k * 100 / Customstrtb.Rows.Count, secont);
                    //    Thread.Sleep(100);
                    //    continue;
                    //}

                    secont.Log = DateTime.Now.ToString() + " :正在保存指令号：" + CustomStyleCode.ToString() + " 的装箱明细表...";
                    worker.ReportProgress(1 * 100 / Customstrtb.Rows.Count, secont);
                    Thread.Sleep(100);

                    secont.Log = DateTime.Now.ToString() + " :正在计箱指令号：" + CustomStyleCode.ToString() + " 的箱号...";
                    worker.ReportProgress(1 * 100 / Customstrtb.Rows.Count, secont);
                    Thread.Sleep(100);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow drdb = table.Rows[i];
                        if (drdb["CustomName"] is DBNull == false)
                        {
                            pklist.CustomName = Convert.ToString(drdb["CustomName"]);
                        }
                        if (drdb["GoodsTypeEnName"] is DBNull == false)
                        {
                            pklist.GoodsTypeEnName = Convert.ToString(drdb["GoodsTypeEnName"]);
                        }
                        if (drdb["CustomStyleName"] is DBNull == false)
                        {
                            pklist.CustomStyleName = Convert.ToString(drdb["CustomStyleName"]);
                        }
                        if (drdb["CustomStyleCode"] is DBNull == false)
                        {
                            pklist.CustomStyleCode = Convert.ToString(drdb["CustomStyleCode"]);
                        }
                        if (drdb["SizeName"] is DBNull == false)
                        {
                            pklist.SizeName = Convert.ToString(drdb["SizeName"]); //  尺码
                        }
                        if (drdb["TotalCount"] is DBNull == false)
                        {
                            pklist.TotalCount = Convert.ToString(drdb["TotalCount"]);//尺码数量
                        }
                        if (drdb["CutNo"] is DBNull == false)
                        {
                            pklist.CutNo = Convert.ToString(drdb["CutNo"]);
                        }
                        if (drdb["ManufactureOrder"] is DBNull == false)
                        {
                            pklist.ManufactureOrder = Convert.ToString(drdb["ManufactureOrder"]);
                        }
                        if (drdb["CustomPO"] is DBNull == false)
                        {
                            pklist.CustomPO = Convert.ToString(drdb["CustomPO"]);
                        }
                        if (drdb["ColorGroupName"] is DBNull == false)
                        {
                            pklist.ColorGroupName = Convert.ToString(drdb["ColorGroupName"]);
                        }
                        if (drdb["BoxSize"] is DBNull == false)
                        {
                            pklist.BoxSize = Convert.ToString(drdb["BoxSize"]);
                        }
                        if (drdb["BoxNoTotal"] is DBNull == false)
                        {
                            pklist.BoxNoTotal = Convert.ToInt32(drdb["BoxNoTotal"]);
                        }
                        if (drdb["PerCount"] is DBNull == false)
                        {
                            pklist.PerCount = Convert.ToInt32(drdb["PerCount"]);
                        }
                        if (drdb["perCountTotal"] is DBNull == false)
                        {
                            pklist.perCountTotal = Convert.ToInt32(drdb["perCountTotal"]);
                        }
                        if (drdb["NW"] is DBNull == false)
                        {
                            pklist.NW = Convert.ToDouble(drdb["NW"]);
                        }
                        if (drdb["TNW"] is DBNull == false)
                        {
                            pklist.TNW = Convert.ToDouble(drdb["TNW"]);
                        }
                        if (drdb["GW"] is DBNull == false)
                        {
                            pklist.GW = Convert.ToDouble(drdb["GW"]);
                        }
                        if (drdb["TGW"] is DBNull == false)
                        {
                            pklist.TGW = Convert.ToDouble(drdb["TGW"]);
                        }
                        if (drdb["BoxVolume"] is DBNull == false)
                        {
                            pklist.BoxVolume = Convert.ToDouble(drdb["BoxVolume"]);
                        }
                        if (drdb["MT"] is DBNull == false)
                        {
                            pklist.MT = Convert.ToDouble(drdb["MT"]);
                        }
                        if (drdb["BOXTONO"] is DBNull == false)
                        {
                            pklist.BOXTONO = Convert.ToString(drdb["BOXTONO"]);
                        }
                        if (drdb["Totsumcount"] is DBNull == false)
                        {
                            pklist.Totsumcount = Convert.ToInt32(drdb["Totsumcount"]);
                        }
                        if (drdb["Boxsumcount"] is DBNull == false)
                        {
                            pklist.Boxsumcount = Convert.ToInt32(drdb["Boxsumcount"]);
                        }
                        if (drdb["OrderDate"] is DBNull == false)
                        {
                            pklist.OrderDate = Convert.ToString(drdb["OrderDate"]);
                        }
                        /*
                        pklist.CustonName = Convert.ToString(drdb["CustomName"]);
                        pklist.GoodsTypeEnName = Convert.ToString(drdb["GoodsTypeEnName"]);
                        pklist.CustoStyleName = Convert.ToString(drdb["CustomStyleName"]);
                        pklist.CustomStyleCode = Convert.ToString(drdb["CustomStyleCode"]);
                        pklist.SizeName = Convert.ToString(drdb["SizeName"]); //  尺码
                        pklist.TotalCount = Convert.ToString(drdb["TotalCount"]);//尺码数量
                        pklist.CutNo = Convert.ToString(drdb["CutNo"]);
                        pklist.ManufactureOrder = Convert.ToString(drdb["ManufactureOrder"]);
                        pklist.CustomPO = Convert.ToString(drdb["CustomPO"]);
                        pklist.ColorGroupName = Convert.ToString(drdb["ColorGroupName"]);
                        pklist.BoxSize = Convert.ToString(drdb["BoxSize"]);
                        pklist.BoxNoTotal = Convert.ToInt32(drdb["BoxNoTotal"]);
                        pklist.PerCount = Convert.ToInt32(drdb["PerCount"]);
                        pklist.perCountTotal = Convert.ToInt32(drdb["perCountTotal"]);
                        if (drdb["NW"] is DBNull == false)
                        {
                            pklist.NW = Convert.ToDouble(drdb["NW"]);
                        }
                        if (drdb["TNW"] is DBNull == false)
                        {
                            pklist.TNW = Convert.ToDouble(drdb[""]);
                        }
                        if (drdb["GW"] is DBNull == false)
                        {
                            pklist.GW = Convert.ToDouble(drdb["GW"]);
                        }
                        if (drdb["TGW"] is DBNull == false)
                        {
                            pklist.TGW = Convert.ToDouble(drdb["TGW"]);
                        }
                        pklist.BoxVolume = Convert.ToDouble(drdb["BoxVolume"]);
                        pklist.MT = Convert.ToDouble(drdb["MT"]);
                        pklist.BOXTONO = Convert.ToString(drdb["BOXTONO"]);
                        pklist.Totsumcount = Convert.ToInt32(drdb["Totsumcount"]);
                        pklist.Boxsumcount = Convert.ToInt32(drdb["Boxsumcount"]);
                        */
                        //计算箱号
                        int starno = 0;
                        int endnos = 0;


                        String[] strs = Convert.ToString(drdb["BOXTONO"]).Split('-');
                        starno = Convert.ToInt32(strs[0]);
                        endnos = Convert.ToInt32(strs[1]);



                        for (int u = starno; u <= endnos; u++)
                        {
                            pklist.guid = Guid.NewGuid();
                            pklist.BOXNO = Convert.ToString(u);//需要计算 箱号
                            if (starno == 2330)
                            {
                                MessageBox.Show("1");
                            }
                            //写入库
                            pkbll.pkUpDb(pklist);
                        }
                    }
                    secont.Log = DateTime.Now.ToString() + " :正在保存指令号：" + CustomStyleCode.ToString() + " 的箱号...";
                    worker.ReportProgress(1 * 100 / Customstrtb.Rows.Count, secont);
                    Thread.Sleep(100);

                    //保存内盒信息
                    //  DataTable boxtable = (dataGridViewOrderBoxDocDetail.DataSource as DataTable);
                    packlistbox pkbox = new packlistbox();

                    try
                    {
                        if (boxTable == null || boxTable.Rows.Count <= 0)
                        {
                            secont.Log = DateTime.Now.ToString() + " : 指令号：" + CustomStyleCode.ToString() + " 没有内盒数据...";
                            worker.ReportProgress(1 * 100 / Customstrtb.Rows.Count, secont);
                            Thread.Sleep(100);
                            continue;
                        }
                    }
                    //  catch (Exception ex)
                    catch (Exception)
                    {
                        //MessageBox.Show(ex.ToString());
                        continue;
                    }

                    secont.Log = DateTime.Now.ToString() + " :正在保存指令号：" + CustomStyleCode.ToString() + " 的内盒信息...";
                    worker.ReportProgress(1 * 100 / Customstrtb.Rows.Count, secont);
                    Thread.Sleep(100);

                    for (int i = 0; i < boxTable.Rows.Count - 1; i++)
                    {
                        pkbox.guid = Guid.NewGuid();
                        DataRow drbox = boxTable.Rows[i];
                        pkbox.PC = Convert.ToString(drbox["PerBoxCount"]);
                        pkbox.BoxSize = Convert.ToString(drbox["boxspec"]);
                        pkbox.MT = Convert.ToString(drbox["BoxSize"]);
                        pkbox.CCBM = Convert.ToString(drbox["ccmb"]);
                        pkbox.CTNS = Convert.ToInt32(drbox["BoxNOtotal"]);
                        pkbox.CBM = Convert.ToString(drbox["CMB"]);
                        pkbox.SizeTo = Convert.ToString(drbox["sizename"]);
                        pkbox.CoutomCode = Convert.ToString(drbox["CustomStyleCode"]);

                        pkbll.pkboxUpDb(pkbox);
                    }
                    //保存唛头图片
                    if (picMT.Image != null)
                    {
                        secont.Log = DateTime.Now.ToString() + " :正在保存指令号：" + CustomStyleCode.ToString() + " 的唛头...";
                        worker.ReportProgress(1 * 100 / Customstrtb.Rows.Count, secont);
                        Thread.Sleep(100);

                        //byte picMTphoto = Convert.ToByte(picMT.Image);
                        byte[] picMTphoto = GetImageBytes(picMT.Image);
                        DataRow drpic = boxTable.Rows[0];
                        string CoutomCode = Convert.ToString(drpic["CustomStyleCode"]);

                        pkbll.MTphotoUpDb(picMTphoto, CoutomCode);

                    }
                    else
                    {
                        secont.Log = DateTime.Now.ToString() + " :指令号：" + CustomStyleCode.ToString() + " 没有唛头...";
                        worker.ReportProgress(1 * 100 / Customstrtb.Rows.Count, secont);
                        Thread.Sleep(100);
                    }
                    secont.Log = DateTime.Now.ToString() + " :指令号：" + CustomStyleCode.ToString() + " 保存完成";
                    worker.ReportProgress(1 * 100 / Customstrtb.Rows.Count, secont);
                    Thread.Sleep(100);
                    //  MessageBox.Show("保存完成");
                    TimeSpan ts = DateTime.Now - startime;
                    secont.EllapsedSec = ts.TotalSeconds;//已耗用秒数
                    secont.CountSec = secont.EllapsedSec * Customstrtb.Rows.Count / k;//估计总需时间
                    secont.Value = k;
                    secont.LinesCount = Customstrtb.Rows.Count;
                }
            }
            secont.Log = DateTime.Now.ToString() + " :全部指令号，共" + Customstrtb.Rows.Count + " 个保存完成";
            worker.ReportProgress(1 * 100 / Customstrtb.Rows.Count, secont);
            Thread.Sleep(100);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bgWorker.CancelAsync();
            bgWorker.Dispose();//释放资源 
        }

        private void txtCreateCustomStyleCode_Click(object sender, EventArgs e)
        {
            radCustomCode.Checked = true;
        }

        private void txtCustomStyleCode_TextChanged(object sender, EventArgs e)
        {
            ckFactoryOrderCode.Checked = true;
        }

        private void radFactoryOperateDate_CheckedChanged(object sender, EventArgs e)
        {
            if (radFactoryOperateDate.Checked)
            {
                btnCreate.Text = "生成装箱单并自動保存";
            }
        }

        private void radCustomCode_CheckedChanged(object sender, EventArgs e)
        {
            if (radCustomCode.Checked)
            {
                btnCreate.Text = "生成装箱单";
            }
        }

        private void PackingList_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
