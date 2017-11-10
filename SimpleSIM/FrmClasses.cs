using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSIM
{
    public partial class FrmClasses : Form
    {
        #region  构造函数，设置了不自动生成列 --public FrmClasses()
        /// <summary>
        /// 构造函数，设置了不自动生成列
        /// </summary>
        private FrmClasses()
        {
            InitializeComponent();
            this.dgvClassList.AutoGenerateColumns = false;
        }
        #endregion

        static FrmClasses frm;
        public static FrmClasses GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmClasses();
            }
            return frm;
        }
        BLL.ClassesManager cm = new BLL.ClassesManager();

        private void FrmClasses_Load(object sender, EventArgs e)
        {
            this.gpAddClass.Visible = false;            
            this.dgvClassList.DataSource = cm.GetAllClass(false);
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            List<MODEL.Classes> lists = cm.GetAllClass(false);
            /*
             * 1.创建出工作薄
             * 2.为这个工作薄创建出工作表
             * 3.为这个表创建出行
             * 4.为这个行创建出每一列(单元格cell)--添加数据
             * 5.文件的写入
             */
            //创建一个工作薄
            HSSFWorkbook workbook = new HSSFWorkbook();
            //创建一张工作表
            HSSFSheet sheet1 = workbook.CreateSheet("sh1");
            //需要导出的数据在集合中，每一个对象对应着后期表的一行数据
            for (int i = 0; i < lists.Count;i++ )
            {
                //创建行
                HSSFRow row = sheet1.CreateRow(i);
                //创建第一个单元格
                HSSFCell cell1 = row.CreateCell(0);
                cell1.SetCellValue(lists[i].CID);
                //创建第2个单元格
                HSSFCell cell2 = row.CreateCell(1);
                cell2.SetCellValue(lists[i].CName);
                //创建第3个单元格
                HSSFCell cell3 = row.CreateCell(2);
                cell3.SetCellValue(lists[i].CCount);
                 //创建第4个单元格
                HSSFCell cell4 = row.CreateCell(3);
                cell4.SetCellValue(lists[i].CImg);
                 //创建第5个单元格
                HSSFCell cell5 = row.CreateCell(4);
                cell5.SetCellValue(lists[i].CIsDel);
                 //创建第6个单元格
                HSSFCell cell6 = row.CreateCell(5);
                //cell6.SetCellValue(lists[i].CAddTime.ToString("yyyy年MM月dd日"));  //日期值会被当成double
                cell6.SetCellValue(lists[i].CAddTime); 
                //如何修改日期类型的格式
                HSSFCellStyle cs = workbook.CreateCellStyle();
                HSSFDataFormat df = workbook.CreateDataFormat();
                cs.DataFormat = df.GetFormat("yyyy年MM月dd日");
                cell6.CellStyle = cs;
            }
            using(FileStream fs=new FileStream("aa.xls",FileMode.Create))
            {
                workbook.Write(fs);
                MessageBox.Show("ok");
            }
        }

        private void btnOutputPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if(opd.ShowDialog()==DialogResult.OK)
            {
                this.txtInput.Text = opd.FileName;
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            using(FileStream fs=new FileStream(txtInput.Text,FileMode.Open))
            {
                //通过文件流得到一个工作薄对象
                HSSFWorkbook workbook = new HSSFWorkbook(fs);
                //获取这个工作薄中的某一张工作表
                HSSFSheet sh = workbook.GetSheetAt(0);
                //应该遍历这张表的每一行
                for (int i = sh.FirstRowNum; i <= sh.LastRowNum;i++ )
                {
                    //得到行
                    HSSFRow row=sh.GetRow(i);
                    //得到行才能得到行中的每一列
                    for (int j = row.FirstCellNum; j < row.LastCellNum;j++ )
                    {
                        //取出每一列
                        HSSFCell cell = row.GetCell(j);
                        //在聚会之前必须先判断单元格的类型,因类不同类型的值需要不同的调用方式
                        switch(cell.CellType)
                        {
                            case HSSFCell.CELL_TYPE_BOOLEAN:
                                sb.Append(cell.BooleanCellValue+"  ");
                                break;
                            case HSSFCell.CELL_TYPE_STRING:
                                sb.Append(cell.StringCellValue + "  ");
                                break;
                            case HSSFCell.CELL_TYPE_NUMERIC:
                                sb.Append(cell.NumericCellValue + "  ");
                                break;
                            default:
                                sb.Append(cell.StringCellValue + "  ");
                                break;
                        }
                    }
                    sb.AppendLine();
                }
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
