using BLL;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmInnerBoxin : Form
    {
        static  FrmInnerBoxin frm = null;

        public static FrmInnerBoxin GetSingleton()
        {
            if(frm==null || frm.IsDisposed)
            //if (frm == null)
            {
                frm = new FrmInnerBoxin();
            }
            return frm;
        }


        public FrmInnerBoxin()
        {
            InitializeComponent();
        }
        doc_InnerBoxManager Innerbox = new doc_InnerBoxManager();
        DataTable table = new DataTable();
        String filename = null;
        //public void UpdateTextBox(string newData)
        //{
        //    this.textBox1.Text = newData
        //}
        private void btnInterBoxImpro_Click(object sender, EventArgs e)
        {
        
            comsheetname.Items.Clear();
            dvgInnerBox.DataSource = null;
            OpenFileDialog sdfExport = new OpenFileDialog();
           
            sdfExport.Filter = "Excel 97-2003文件|*.xls|Excel 2007文件|*.xlsx";
            if (sdfExport.ShowDialog() != DialogResult.OK)
            {
                return;
            }

              filename = sdfExport.FileName;
            string excelName = System.IO.Path.GetFileName(filename);//文件名   
            
            txtfilename.Text = excelName;

            string[] sheetnames=Common.myCommon.getExcelSheetSum(filename);
          
            for (int t = 0; t < sheetnames.Length; t++)
            {
                comsheetname.Items.Add(sheetnames[t]);//添加表名
            }

           // if(comsheetname.SelectedItem == null)
         //   {

                MessageBox.Show("请选择工作表!");
            comsheetname.DroppedDown = true;
            //  comsheetname.SelectedIndex = 0;
            //     return;
            //    }
            //  loadExcel()

            btnLoadExcel.Enabled = true;

        }


        private void loadExcel()
        {
          if(txtfilename.Text.Length <= 0)
            {
                MessageBox.Show("请选择文件！");
                Cursor = Cursors.Default;
                return;
            }
            if (comsheetname.SelectedIndex == -1)
            {
                MessageBox.Show("请选择表名！");
                comsheetname.DroppedDown = true;
                Cursor = Cursors.Default;
                return;
            }
            string sheetname = comsheetname.SelectedItem.ToString();

            //  bool yesno = false;//第一行是否数据列名
            ////  if (radYES.Checked)
            //  {
            //      yesno = true;
            //  }
            //  else if (radNO.Checked)
            //  {
            //      yesno = false;
            //  }
            int headno = 0;
           // if(textHeadno.Text)
                Regex reg = new Regex("^[0-9]+$"); //正则表达式 检测是否数字
            Match ma = reg.Match(textHeadno.Text.ToString());
            if (!ma.Success)
            {
               // MessageBox.Show("部门编码不是数字！");
               // return;
                headno = 0;
                textHeadno.Text = headno.ToString();
            }

            if (Convert.ToInt32( textHeadno.Text) < 0 || textHeadno.Text=="")
            {
                headno = 0;
            }
              headno =Convert.ToInt32( textHeadno.Text);

            this.dvgInnerBox.ReadOnly = true;
            this.dvgInnerBox.AllowUserToAddRows = false;

            table = Innerbox.ExcelRead(filename, sheetname, headno);
            if(table != null)
            {
                this.dvgInnerBox.DataSource = table;
            }
           
        }

        private void btnSaveInnerBox_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //查询是否已有此文件//GUID报错  已有此文件
            if(dvgInnerBox.RowCount == 0 )
            {
                MessageBox.Show("请先加载excel数据！");
                Cursor = Cursors.Default;
                return;
            }
            string guid = Convert.ToString(dvgInnerBox.Rows[0].Cells[0].Value);
            if( Innerbox.ishavebyguid(guid))           
            {
                MessageBox.Show("此表已保存完成！");
                Cursor = Cursors.Default;
                return;
            }
            Innerbox.sqlbulkcopy(table);
            Cursor = Cursors.Default;
            MessageBox.Show("提示","保存成功");
            btnSaveInnerBox.Enabled = false;
        }

        private void dvgInnerBox_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }

        private void InterBoxLableWind_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void InterBoxLableWind_SizeChanged(object sender, EventArgs e)
        {
            groupBox1.Width = this.Width - 20;
            groupBox1.Height = this.Height - 80;
        }

        private void InterBoxLableWind_Load(object sender, EventArgs e)
        {
            // radYES.Checked = true;
            btnLoadExcel.Enabled = false;
            btnSaveInnerBox.Enabled = false;
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            //比较 内容没有改  不重加载
         //   string endguid = Convert.ToString(dvgInnerBox.Rows[dvgInnerBox.RowCount - 1].Cells[0].Value);  //最后一行的GUID
          //  if (endguid=)
           // {

          //  }
            Cursor = Cursors.WaitCursor;            
            loadExcel();
          Cursor = Cursors.Default;
            btnLoadExcel.Enabled = false;
            btnSaveInnerBox.Enabled = true;
          

        }

        private void comsheetname_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLoadExcel.Enabled = true;
            textHeadno.Text = "0";
        }

        private void textHeadno_TextChanged(object sender, EventArgs e)
        {
            btnLoadExcel.Enabled = true;
        }

        private void btnCleanRe_Click(object sender, EventArgs e)
        {
           int i=  Innerbox.CleanRe();
            MessageBox.Show("共清理重复数据 "+i.ToString()+" 条","清理完成");
             
        }

        private void txtfilename_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmInnerBoxin_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
