using MODEL;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class NPOIExcelExample
    {
        //public void ExcelWrite(string file)
        //{
        //    try
        //    {
        //        using (ExcelHelper excelHelper = new ExcelHelper(file))
        //        {
        //            DataTable data = GenerateData();
        //            deptBLL getdataDept = new deptBLL();    //写一个从数据库查出来的表           

        //            DataTable data = getdataDept.GetdatagetdataDept();
        //            int count = excelHelper.DataTableToExcel(data, "MySheet", true);
        //            if (count > 0)
        //                Console.WriteLine("Number of imported data is {0} ", count);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception: " + ex.Message);
        //    }
        //}


        //读EXCEL   导入EXCEL表
        public doc_InnerBox[] ExcelRead(string file , string sheetname, int headno)
        {
            try
            {
                using (ExcelHelper excelHelper = new ExcelHelper(file))
                {
                    DataTable dt = excelHelper.ExcelToDataTable(sheetname, headno);
                    //   PrintData(dt);//显示出来

                    if (dt.Rows.Count <= 0)
                    {
                        return null;
                    }
                    else
                    {
                        //要显示的文件的model 例emp
                        doc_InnerBox[] InnerBoxs = new doc_InnerBox[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            InnerBoxs[i] = ToModel(dt.Rows[i]);//这里转换过来
                        }
                        return InnerBoxs;
                        //InterBoxLableWind IExcel = new InterBoxLableWind();                       
                         // IExcel.dvgInnerBox.ItemsSource = InnerBoxs;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return null;
            }
        }

        private doc_InnerBox ToModel(DataRow row)//建立要导入的文件的model
        { 
            doc_InnerBox InnerBoxs = new doc_InnerBox();
            
                if (row.ItemArray.Length>0)
                {
                    InnerBoxs.InnerBarcode = row.ItemArray[0].ToString();
                }
                if (row.ItemArray.Length > 1)
                {
                InnerBoxs.StyleCode = row.ItemArray[1].ToString();
                 }
            if (row.ItemArray.Length > 2)
            {
                InnerBoxs.Name = row.ItemArray[2].ToString();
            }
            
            if (row.ItemArray.Length > 3)
            {
                InnerBoxs.Color = row.ItemArray[3].ToString();
            }
            if (row.ItemArray.Length > 4)
            {
                InnerBoxs.Size = row.ItemArray[4].ToString();
            }
            if (row.ItemArray.Length > 5)
            {
                InnerBoxs.Type = row.ItemArray[5].ToString();
            }
            if (row.ItemArray.Length > 6)
            {
                InnerBoxs.NewCode = row.ItemArray[6].ToString();
            }
            if (row.ItemArray.Length > 7)
            {
                InnerBoxs.CustomName = row.ItemArray[7].ToString();
            }
            if (row.ItemArray.Length > 8)
            {
                InnerBoxs.Type = row.ItemArray[7].ToString();
            }

            return InnerBoxs;
        }
        public string[] getExcelSheetSum(String filename)
        {
            ExcelHelper excelHelper = new ExcelHelper(filename);
            string[] sheetname = excelHelper.getExcelSheetName(filename);
           // string[] sheetname = new string[k];//表名
            for (int t = 0; t < sheetname.Count(); t++)
            {
               // sheetname[t] = excelHelper.getExcelSheetName(t);
                // sheetname[t] = workbook.GetSheetName(t); 
            }
            
            return sheetname;
        }
        //public string getExcelSheetName(String filename,int sheetNo)
        //{
        // //   ExcelHelper excelHelper = new ExcelHelper(filename);
        //   // return excelHelper.getExcelSheetName(sheetNo);
        //}
        
    }
}
