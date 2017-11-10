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
    public partial class FrmScanSee : Form
    {
        public FrmScanSee()
        {

            InitializeComponent();
            this.dgvPackList.AutoGenerateColumns = false;
            this.dgvPackListScan.AutoGenerateColumns = false;
        }

        static FrmScanSee frm;
        public static FrmScanSee GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmScanSee();
            }
            return frm;
        }



        private void FrmScanSee_Load(object sender, EventArgs e)
        {

        }

        BLL.doc_PackListManager plm = new BLL.doc_PackListManager();
        List<MODEL.doc_PackListScan> dplscanlist = new List<MODEL.doc_PackListScan>();


        private void txtSeeOrder_Click(object sender, EventArgs e)
        {
            bool mchkorder = chkOrder.Checked;
            string morderdate = YearMounth.Text;
            string mcustomstylecode = txtOrder.Text;
            string mcustombuyname = txtBuyer.Text;
            string mname = txtName.Text;
            string mcolor = txtColor.Text;
            string mtype = txtType.Text;
            bool mchkscan = chkScan.Checked;
            this.dgvPackList.DataSource = "";                 
            this.dgvPackList.DataSource = plm.SeePackList(mchkorder, morderdate, mcustomstylecode, mcustombuyname, mname, mcolor, mtype, mchkscan);         
            test.Text = "共"+this.dgvPackList.RowCount.ToString()+"筆";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(chkScan.Checked==true)
            {
                MessageBox.Show("勾選中");
            }
        }

        private void test_TextChanged(object sender, EventArgs e)
        {

        }

        BLL.doc_PackListScanManager plsm = new BLL.doc_PackListScanManager();
        List<MODEL.doc_PackListScan> pls = new  List<MODEL.doc_PackListScan>();
        private void dgvPackList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

           string  order = this.dgvPackList.Rows[e.RowIndex].Cells[0].Value.ToString();
            string cartonbarcode = this.dgvPackList.Rows[e.RowIndex].Cells[9].Value.ToString();
          //   MessageBox.Show(order+cartonbarcode);
            test.Text = "";
            pls = null;
            pls  =plsm.GetPackListScanInfo(order,cartonbarcode);
            if (pls == null)
            {
                test.Text = "沒有未掃描明細";
            }
            else
            {
                test.Text = "未掃描明細有" + pls.Count.ToString() + "筆";
            }
            this.dgvPackListScan.DataSource = pls;
        }

        private void TOEXCEL_Click(object sender, EventArgs e)
        {
            string vg = "packlist";
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
            if (VG == "packlist")
            {
                tabl = GetDgvToTable(dgvPackList);
            }
            else if (VG == "packlistscan")
            {
                 tabl = GetDgvToTable(dgvPackListScan);
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
                //                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                                DataColumn dc = new DataColumn(dgv.Columns[count].HeaderText.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {

                                        // dr[countsub] = dgv.Columns[0].HeaderCell.Value.ToString();
                           
                    
                    
                        dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                    
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void dgvPackList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if ( dgvPackList.Rows[e.RowIndex].Selected == false)
                    {
                        dgvPackList.ClearSelection();
                        dgvPackList.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvPackList.SelectedRows.Count == 1)
                    {
                        dgvPackList.CurrentCell = dgvPackList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单

                 ctmsPacklist.Show(MousePosition.X, MousePosition.Y);
                   // MessageBox.Show("点右键了");
                }
            }

        }

        private void dgvPackListScan_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvPackListScan.Rows[e.RowIndex].Selected == false)
                    {
                        dgvPackListScan.ClearSelection();
                        dgvPackListScan.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvPackListScan.SelectedRows.Count == 1)
                    {
                        dgvPackListScan.CurrentCell = dgvPackListScan.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单

                    ctmsPacklistScan.Show(MousePosition.X, MousePosition.Y);
                    // MessageBox.Show("点右键了");
                }
            }





        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string vg = "packlistscan";
            ImproExcel(vg);
        }

        private void COPYCELL_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dgvPackList.CurrentCell.Value.ToString());
        }

        private void ctmsPacklist_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dgvPackList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmScanSee_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
