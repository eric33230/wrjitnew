using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlTypes;
using System.Transactions;
using System.Windows.Forms;

namespace BLL
{
     public class doc_InnerBoxManager
    {
        #region 创建班级数据访问层类对象  -DAL.InnerBoxService ibs
        /// <summary>
        /// 创建班级数据访问层类对象
        /// </summary>
        DAL.doc_InnerBoxService ibs = new DAL.doc_InnerBoxService();
        #endregion

        #region 获取所有內盒條碼  - List<MODEL.doc_InnerBox> GetAllInneBox(string innerbarcode)
        /// <summary>
        /// 获取所有內盒條碼訊息
        /// </summary>
        /// <param name></param>
        /// <returns></returns>
        public List<MODEL.doc_InnerBox> GetAllInneBox(string innerbarcode)
        {

            return ibs.GetAllInneBox(innerbarcode);
        }
        #endregion


        #region 增加內盒條碼資料 - int AddInnerBox(MODEL.doc_InnerBox addInnerBox)
        /// <summary>
        /// 增加內盒條碼資料 , 內盒條碼使用掃描後 更新
        /// </summary>
        /// <param name="addStyle"></param>
        /// <returns></returns>
        public int AddInnerBox(MODEL.doc_InnerBox addInnerBox)
        {   
            return ibs.AddInnerBox(addInnerBox);
        }
        #endregion


        #region 验证內盒條碼基本資料是否存在 -int IsInnerBoxExisits(string name, string color ,string size)
        /// <summary>
        /// 验证內盒條碼基本資料是否存在 
        /// </summary>
        /// <param name="name,color,size"></param>
        /// <returns></returns>
        public int IsInnerBoxExisits(string name, string color, string size)
        {

            return  ibs.IsInnerBoxExisits(name,color,size);
        }
        #endregion



        #region 获取所有沒有內盒條碼信息List<MODEL.doc_InnerBox> GetEmptyBox(string yyyymm)
        /// <summary>
        /// 获取沒有內盒條碼訊息所有班级信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.doc_InnerBox> GetEmptyBox(string yyyymm)
        {

            return ibs.GetEmptyBox(yyyymm);
        }
        #endregion


        #region 获取所有該月訂單内核尺码型体信息  - List<MODEL.doc_Style> GetIInnerfromOrder(string yyyymm)
        /// <summary>
        /// 用來確認內盒條碼 ,內盒尺碼,型體,配色 基本資料有沒有.... MARK NewCode
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_InnerBox> GetInnerfromOrder(string yyyymm)
        {       

            return ibs.GetInnerfromOrder(yyyymm);
        }
        #endregion

        //----- 小明

         DAL.doc_InnerBoxService innerboxdal = new DAL.doc_InnerBoxService();
        public DataTable ExcelRead(String filename, string sheetname, int headno)
        {
            Common.NPOIExcelExample NPOIexcel = new Common.NPOIExcelExample();
            //获取个数
            //  string[] sheetname = NPOIexcel.getExcelSheetSum(filename);

            //获取表名
            //  string[] sheetname=new string[k];//表名
            //for (int t = 0; t < sheetname.Count(); t++)
            //{

            //    InterBoxLableWind.comsheetname.Items.Add(Convert.ToString(sheetname[t]));
            //    // sheetname[t]= NPOIexcel.getExcelSheetName(filename,t);
            //    // sheetname[t] = workbook.GetSheetName(t); 
            //}
            //返回表名
            //  comsheetname.Items.Add("111");

            //   string sheetname= comsheetname.SelectedItem.ToString();




           MODEL.doc_InnerBox[] innerboxs = NPOIexcel.ExcelRead(filename, sheetname, headno);
            if (innerboxs == null)
            {
                return null;
            }
            /*本地表*/
            //创建本地表
            DataTable table = new DataTable();
            table.Columns.Add("Guid", typeof(SqlGuid));
            table.Columns.Add("InnerBarcode");
            table.Columns.Add("StyleCode");
            table.Columns.Add("Name");
            table.Columns.Add("Color");
            table.Columns.Add("Size");
            table.Columns.Add("Type");
            table.Columns.Add("Style");
            table.Columns.Add("NewCode");
            table.Columns.Add("CustomName");
            try
            {


                for (int i = 0; i < innerboxs.Count(); i++)
                {
                    Guid guid = Guid.NewGuid();
                    String InnerBarcode = Convert.ToString(innerboxs[i].InnerBarcode);
                    String StyleCode = Convert.ToString(innerboxs[i].StyleCode);
                    String Color = Convert.ToString(innerboxs[i].Color);
                    String Size = Convert.ToString(innerboxs[i].Size);
                    String Type = Convert.ToString(innerboxs[i].Type);
                    String Style = Convert.ToString(innerboxs[i].Style);
                    String Name = Convert.ToString(innerboxs[i].Name);
                    String NewCode = Convert.ToString(innerboxs[i].NewCode);
                    String CustomName = Convert.ToString(innerboxs[i].CustomName);
                    //本地表加入数据  Unique
                    DataRow row = table.NewRow();
                    row["Guid"] = guid;
                    row["InnerBarcode"] = InnerBarcode;
                    row["StyleCode"] = StyleCode;
                    row["Name"] = Name;
                    row["Color"] = Color;
                    row["Size"] = Size;
                    row["Type"] = Type;
                    row["Style"] = Style;
                    row["NewCode"] = NewCode;
                    row["CustomName"] = CustomName;
                    table.Rows.Add(row);
                    /*************/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return table;
        }

        public void sqlbulkcopy(DataTable table)
        {

            using (TransactionScope ts = new TransactionScope())
            {
                innerboxdal.sqlbulkcopy(table);
                ts.Complete();
            }
        }

        public bool ishavebyguid(string guid)
        {
            int i = innerboxdal.getInnerBoxByGuid(guid);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string[] getExcelSheetName(String filename)
        {
            Common.NPOIExcelExample NPOIexcel = new  Common.NPOIExcelExample();
            //获取个数
            string[] sheetname = NPOIexcel.getExcelSheetSum(filename);

            //获取表名
            //  string[] sheetname=new string[k];//表名
            //for (int t = 0; t < sheetname.Count(); t++)
            //{

            //    InterBoxLableWind.comsheetname.Items.Add(Convert.ToString(sheetname[t]));
            //    // sheetname[t]= NPOIexcel.getExcelSheetName(filename,t);
            //    // sheetname[t] = workbook.GetSheetName(t); 
            //}
            return sheetname;
        }
        public int CleanRe()
        {
            return innerboxdal.CleanRe();
        }








    }
}
