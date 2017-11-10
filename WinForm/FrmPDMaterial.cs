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
using System.Windows.Forms;
using static Common.myCommon;

namespace WinForm
{
    public partial class FrmPDMaterial : Form
    {
        public FrmPDMaterial()
        {
            InitializeComponent();
        }
        static FrmPDMaterial frm;
        PDMaterialManager pdm = new PDMaterialManager();
        public static FrmPDMaterial GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmPDMaterial();
            }
            return frm;
        }
       
        /// <summary>
        /// 查询物料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            WhereModeHelp wherestr = new WhereModeHelp();
            List<WhereModeHelp> wherestrs = new List<WhereModeHelp>();
            string MaterialCodePrefix = txtMaterialCodePrefix.Text.Trim();//物料简码
            string DesignRemark = txtDesignRemark.Text.Trim();//物料色号
            string classstr = cbMaterialClass.Text.Trim();//物料大类
            if (classstr.Length <= 0 && MaterialCodePrefix.Length<=0 && DesignRemark.Length<=0)
            {
                MessageBox.Show("请选择物料类别再查询");
                return;
            }
            if (classstr.Length >0 && MaterialCodePrefix.Length <= 0 && DesignRemark.Length <= 0)
            {
                wherestr.Wherekey = "mc.Name";
                wherestr.Wherevalue = classstr;
                wherestrs.Add(wherestr);
            }



            //简码有文字
            if (MaterialCodePrefix.Length>0)
            {
                wherestr.Wherekey = "m.CodePrefix";
                wherestr.Wherevalue = MaterialCodePrefix;
                wherestrs.Add(wherestr);
            }
            //色号有文字
            if (DesignRemark.Length > 0)
            {
                wherestr.Wherekey = "m.DesignRemark";
                wherestr.Wherevalue = MaterialCodePrefix;
                wherestrs.Add(wherestr);
            }
            laodmaterialdata(wherestrs);
        }
        /// <summary>加载物料到表
        /// 加载到表
        /// </summary>
        /// <param name="wherestrs"></param>
        public void laodmaterialdata(List<WhereModeHelp> wherestrs)
        {
            DataTable dt= pdm.getMaterialall(wherestrs);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("此类条件下没有物料");
            }
            this.dgvmaterial.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
            this.dgvmaterial.DataSource = dt;
            this.dgvmaterial.Columns["MaterialClass"].HeaderText = "物料大类";
            this.dgvmaterial.Columns["MaterialSubClass"].HeaderText = "物料小类";
            this.dgvmaterial.Columns["MaterialCodePrefix"].HeaderText = "物料简码";
            this.dgvmaterial.Columns["MaterialName"].HeaderText = "物料名称";
            this.dgvmaterial.Columns["MaterialColor"].HeaderText = "物料颜色";
            this.dgvmaterial.Columns["DesignRemark"].HeaderText = "物料色号";
            this.dgvmaterial.Columns["StockCount"].HeaderText = "库存数量";
            this.dgvmaterial.Columns["MaterialUnitNo"].HeaderText = "单位";


        }

        /// <summary>开始最大化窗口
        /// 开始最大化窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPDMaterial_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        /// <summary>排版式
        /// 排版式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPDMaterial_Resize(object sender, EventArgs e)
        {
            gbpd.Width = this.Width - 20;
            gbpd.Height = this.Height - 70;

           
        }

        /// <summary>获取物料大类
        /// 获取物料大类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPDMaterial_Load(object sender, EventArgs e)
        {
            cbMaterialClass.Items.Clear();
            List<string> MaterialClass = pdm.getMaterialClass();
            for(int i = 0; i < MaterialClass.Count; i++)
            {
                cbMaterialClass.Items.Add(MaterialClass[i]);
            }
            
        }

        private void dgvmaterial_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }

        private void dgvmaterial_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvmaterial.Rows[e.RowIndex].Selected == false)
                    {
                        dgvmaterial.ClearSelection();
                        dgvmaterial.Rows[e.RowIndex].Selected = true;
                    }
                    dgvmaterial.Focus();
                    meEdit.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void meCopyRows_Click(object sender, EventArgs e)
        {
                Clipboard.SetDataObject(dgvmaterial.CurrentCell.Value.ToString());           
        }

        private void meCopyCell_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dgvmaterial.GetClipboardContent());            
        }

        private void meImproExcel_Click(object sender, EventArgs e)
        {
            
            ImproExcel();
        }
        public void ImproExcel( )
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
            
                tabl = GetDgvToTable(dgvmaterial);
            


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
    }
}
