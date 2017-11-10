using System;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Common;
using System.Reflection;
using MODEL;
using System.Text.RegularExpressions;

namespace Common
{



    public class myCommon
    {

        /// <summary>
        /// 数字验证
        /// </summary>
        /// <param name="strNumber">被验证信息</param>
        /// <returns></returns>
        public static bool IsWholeNumber(string strNumber)
        {
            Regex notWholePattern = new Regex(@"^[-]?\d+[.]?\d*$");
            return notWholePattern.IsMatch(strNumber, 0);
        }







        public static int GetDayofWeek(DateTime date, string year)
        {
            //該年需要加多少數字
            int thisYear = Convert.ToInt32(year);
            DateTime dt = new DateTime( thisYear, 1, 1);
            string num = dt.DayOfWeek.ToString("d");
            int j = date.DayOfYear + Convert.ToInt16(num) - 1;
            return j / 7 + 1 + (thisYear - 2000) * 100;

        }
        /// <summary>
        ///  使用時間到毫秒傳回唯一的18位數字 
        /// </summary>
        /// <returns></returns>
        public string myGuid()
        {
            DateTime dt = DateTime.Now;
            string yyyy = Convert.ToString(dt.Year);
            string mm = Convert.ToString(Convert.ToInt32(dt.Month)+10);
            string dd = Convert.ToString(Convert.ToInt32(dt.Day) +10);
            string hh = Convert.ToString(Convert.ToInt32(dt.Hour) +10);
            string ff = Convert.ToString(Convert.ToInt32(dt.Minute)+10);
            string ss = Convert.ToString(Convert.ToInt32(dt.Second)+10);
            string ee = Convert.ToString(Convert.ToInt32(dt.Millisecond + 1000));
            

              string mynum= yyyy + mm + dd + hh + ff + ss +ee;
        //     System.Windows.Forms.MessageBox.Show(mynum);            
            return mynum;

        }


        public static string[] getExcelSheetSum(String filename)
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



        public class NPOIProgram
        {
            static void PrintData(DataTable data)
            {
                if (data == null) return;
                for (int i = 0; i < data.Rows.Count; ++i)
                {
                    for (int j = 0; j < data.Columns.Count; ++j)
                        Console.Write("{0} ", data.Rows[i][j]);
                    Console.Write("\n");
                }
            }

            //写入EXCEL表  导出
            public void ExcelWrite(string file, DataTable tabl)
            {
                try
                {
                    using (ExcelHelper excelHelper = new ExcelHelper(file))
                    {
                        //DataTable data = GenerateData();
                        //deptBLL getdataDept = new deptBLL();    //写一个从数据库查出来的表           

                        //  DataTable data = getdataDept.GetdatagetdataDept();


                        int count = excelHelper.DataTableToExcel(tabl, "MySheet", true);
                        if (count > 0)
                            Console.WriteLine("Number of imported data is {0} ", count);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }

            // 读EXCEL 导入EXCEL表

            public DataTable ExcelReadEmpTable(String filename, string sheetname, int headno)
            {
//                     Common.NPOIExcelExample NPOIexcel = new Common.NPOIExcelExample();


                List<MODEL.HR_Employee> emplists= ExcelReadEmp(filename, sheetname, headno);
                if (emplists == null)
                {
                    return null;
                }
                /*本地表*/
                //创建本地表
                DataTable table = new DataTable();
                table.Columns.Add("Guid");
                table.Columns.Add("AID");
                table.Columns.Add("DeptID");
                table.Columns.Add("EnrollNo");
                table.Columns.Add("EmpID");
                table.Columns.Add("KhName");
                table.Columns.Add("Accountno");
                table.Columns.Add("NationalID");
                table.Columns.Add("JobID");
                table.Columns.Add("ProvinceID");
                table.Columns.Add("ShiftID");
                table.Columns.Add("CallName");
                table.Columns.Add("Gender");
                table.Columns.Add("Status");
                table.Columns.Add("PersonalID");
                table.Columns.Add("NSSF");
                table.Columns.Add("Education");
                table.Columns.Add("WorkBook");
                table.Columns.Add("CardNo");
                table.Columns.Add("Address");
                table.Columns.Add("IsPermanent");
                table.Columns.Add("IsContract");
                table.Columns.Add("IsResign");
                table.Columns.Add("ResignType");
                table.Columns.Add("ResignReason");
                table.Columns.Add("ResignDate");
                table.Columns.Add("BirthDate");
                table.Columns.Add("CreateDate");
                table.Columns.Add("Union1");
                table.Columns.Add("Union2");
                table.Columns.Add("Union3");
                table.Columns.Add("Union4");
                table.Columns.Add("Union5");
                table.Columns.Add("Union6");
                table.Columns.Add("Union7");
                table.Columns.Add("Union8");
                table.Columns.Add("Union9");
                table.Columns.Add("Union10");
                table.Columns.Add("Union11");
                table.Columns.Add("Union12");

                try
                {


                    for (int i = 0; i < emplists.Count(); i++)
                    {
                        String AID = Convert.ToString(emplists[i].AID);
                        String DeptID = Convert.ToString(emplists[i].DeptID);
                        String EnrollNo = Convert.ToString(emplists[i].EnrollNo);
                        String EmpID = Convert.ToString(emplists[i].EmpID);
                        String KhName = Convert.ToString(emplists[i].KhName);
                        String Accountno = Convert.ToString(emplists[i].Accountno);
                        String NationalID = Convert.ToString(emplists[i].NationalID);
                        String JobID = Convert.ToString(emplists[i].JobID);
                        String ProvinceID = Convert.ToString(emplists[i].ProvinceID);
                        String ShiftID = Convert.ToString(emplists[i].ShiftID);
                        String CallName = Convert.ToString(emplists[i].CallName);
                        String Gender = Convert.ToString(emplists[i].Gender);
                        String Status = Convert.ToString(emplists[i].Status);
                        String PersonalID = Convert.ToString(emplists[i].PersonalID);
                        String NSSF = Convert.ToString(emplists[i].NSSF);
                        String Education = Convert.ToString(emplists[i].Education);
                        String WorkBook = Convert.ToString(emplists[i].WorkBook);
                        String CardNo = Convert.ToString(emplists[i].CardNo);
                        String Address = Convert.ToString(emplists[i].Address);
                        String IsPermanent = Convert.ToString(emplists[i].IsPermanent);
                        String IsContract = Convert.ToString(emplists[i].IsContract);
                        String IsResign = Convert.ToString(emplists[i].IsResign);
                        String ResignType = Convert.ToString(emplists[i].ResignType);
                        String ResignReason = Convert.ToString(emplists[i].ResignReason);
                        String ResignDate = Convert.ToString(emplists[i].ResignDate);
                        String BirthDate = Convert.ToString(emplists[i].BirthDate);
                        String CreateDate = Convert.ToString(emplists[i].CreateDate);
                        String Union1 = Convert.ToString(emplists[i].Union1);
                        String Union2 = Convert.ToString(emplists[i].Union2);
                        String Union3 = Convert.ToString(emplists[i].Union3);
                        String Union4 = Convert.ToString(emplists[i].Union4);
                        String Union5 = Convert.ToString(emplists[i].Union5);
                        String Union6 = Convert.ToString(emplists[i].Union6);
                        String Union7 = Convert.ToString(emplists[i].Union7);
                        String Union8 = Convert.ToString(emplists[i].Union8);
                        String Union9 = Convert.ToString(emplists[i].Union9);
                        String Union10 = Convert.ToString(emplists[i].Union10);
                        String Union11 = Convert.ToString(emplists[i].Union11);
                        String Union12 = Convert.ToString(emplists[i].Union12);

                      //本地表加入数据  Unique
                        DataRow row = table.NewRow();
                        row["AID"] = AID;
                        row["DeptID"] = DeptID;
                        row["EnrollNo"] = EnrollNo;
                        row["EmpID"] = EmpID;
                        row["KhName"] = KhName;
                        row["Accountno"] = Accountno;
                        row["NationalID"] = NationalID;
                        row["JobID"] = JobID;
                        row["ProvinceID"] = ProvinceID;
                        row["ShiftID"] = ShiftID;
                        row["CallName"] = CallName;
                        row["Gender"] = Gender;
                        row["Status"] = Status;
                        row["PersonalID"] = PersonalID;
                        row["NSSF"] = NSSF;
                        row["Education"] = Education;
                        row["Gender"] = Gender;
                        row["WorkBook"] = WorkBook;
                        row["CardNo"] = CardNo;
                        row["Address"] = Address;
                        row["IsPermanent"] = IsPermanent;
                        row["IsContract"] = IsContract;
                        row["IsResign"] = IsResign;
                        row["ResignType"] = ResignType;
                        row["ResignReason"] = ResignReason;
                        row["ResignDate"] = ResignDate;
                        row["BirthDate"] = BirthDate;
                        row["CreateDate"] = CreateDate;
                        row["Union1"] = Union1;
                        row["Union2"] = Union2;
                        row["Union3"] = Union3;
                        row["Union4"] = Union4;
                        row["Union5"] = Union5;
                        row["Union6"] = Union6;
                        row["Union7"] = Union7;
                        row["Union8"] = Union8;
                        row["Union9"] = Union9;
                        row["Union10"] = Union10;
                        row["Union11"] = Union11;
                        row["Union12"] = Union12;
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




            public List<MODEL.HR_Employee> ExcelReadEmp(string file, string sheetname, int headno)
            {
                try
                {
                    using (ExcelHelper excelHelper = new ExcelHelper(file))
                    {


                        Common.NPOIExcelExample NPOIexcel = new Common.NPOIExcelExample();
                                  List<MODEL.HR_Employee> depts = new List<MODEL.HR_Employee>();
                 
                        //              要显示的文件的model 例emp

                        //   DataTable dt = excelHelper.ExcelToDataTable("MySheet", headno);
                        //           DataTable dt = excelHelper.ExcelToDataTable(sheetname, headno);
                 //       DataTable dt = excelHelper.ExcelToDataTable(sheetname, headno);
                       DataTable dt = excelHelper.ReadExcelToDataTable(file, sheetname);



                        if (dt.Rows.Count <= 0)
                        {
                            return null;
                        }
                        else
                        {

                            //要显示的文件的model 例emp
//                            MODEL.HR_Employee dept = new MODEL.HR_Employee;
                        //    MODEL.HR_Employee[] depts = new MODEL.HR_Employee[dt.Rows.Count];
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
             
                                MODEL.HR_Employee dept = new MODEL.HR_Employee();
                                //  depts[i]= EmpToModel(dt.Rows[i]);//这里转换过来
                                  dept= EmpToModel(dt.Rows[i]);//这里转换过来
                                 depts.Add(dept);

                            }
                            return depts;

                        }
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    return null;
                }
            }

            private HR_Employee EmpToModel(DataRow row)//建立要导入的文件的model
            {
                HR_Employee emps = new HR_Employee();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    if (row.ItemArray.Length > 0)
                    {
                        emps.AID = Convert.ToDecimal(row.ItemArray[0].ToString());
                    }
                    if (row.ItemArray.Length > 1)
                    {
                        emps.DeptID = Convert.ToInt16(row.ItemArray[1].ToString());
                    }
                    if (row.ItemArray.Length > 2)
                    {
                        emps.EnrollNo = Convert.ToSingle(row.ItemArray[2].ToString());
                    }
                    if (row.ItemArray.Length > 3)
                    {
                        emps.EmpID = row.ItemArray[3].ToString();
                    }
                    if (row.ItemArray.Length > 4)
                    {
                        emps.KhName = row.ItemArray[4].ToString();
                    }
                    if (row.ItemArray.Length > 5)
                    {
                        emps.Accountno = Convert.ToInt16(row.ItemArray[5].ToString());
                    }
                    if (row.ItemArray.Length > 6)
                    {
                        emps.NationalID = Convert.ToInt16(row.ItemArray[6].ToString());
                    }
                    if (row.ItemArray.Length > 7)
                    {
                        emps.JobID = Convert.ToInt16(row.ItemArray[7].ToString());
                    }
                    if (row.ItemArray.Length > 8)
                    {
                        emps.ProvinceID = Convert.ToInt16(row.ItemArray[8].ToString());
                    }
                    if (row.ItemArray.Length > 9)
                    {
                        emps.ShiftID = Convert.ToInt16(row.ItemArray[9].ToString());
                    }
                    if (row.ItemArray.Length > 10)
                    {
                        emps.CallName = row.ItemArray[10].ToString();
                    }
                    if (row.ItemArray.Length > 11)
                    {
                        emps.Gender = row.ItemArray[11].ToString();
                    }
                    if (row.ItemArray.Length > 12)
                    {
                        emps.Status = row.ItemArray[12].ToString();
                    }
                    if (row.ItemArray.Length > 13)
                    {
                        emps.PersonalID = row.ItemArray[13].ToString();
                    }
                    if (row.ItemArray.Length > 14)
                    {
                        emps.NSSF = row.ItemArray[14].ToString();
                    }
                    if (row.ItemArray.Length > 15)
                    {
                        emps.Education = row.ItemArray[15].ToString();
                    }
                    if (row.ItemArray.Length > 16)
                    {
                        emps.WorkBook = row.ItemArray[16].ToString();
                    }
                    if (row.ItemArray.Length > 17)
                    {
                        emps.CardNo = row.ItemArray[17].ToString();
                    }
                    if (row.ItemArray.Length > 18)
                    {
                        emps.Address = row.ItemArray[18].ToString();
                    }
                    if (row.ItemArray.Length > 19)
                    {
                        emps.IsPermanent = Convert.ToBoolean(row.ItemArray[19].ToString());
                    }
                    if (row.ItemArray.Length > 20)
                    {
                        emps.IsContract = Convert.ToBoolean(row.ItemArray[20].ToString());
                    }
                    if (row.ItemArray.Length > 21)
                    {
                        emps.IsResign = Convert.ToBoolean(row.ItemArray[21].ToString());
                    }
                    if (row.ItemArray.Length > 22)
                    {
                        emps.ResignType = row.ItemArray[22].ToString();
                    }
                    if (row.ItemArray.Length > 23)
                    {
                        emps.ResignReason = row.ItemArray[23].ToString();
                    }
                    if (row.ItemArray.Length > 24)
                    {
                        if (row.ItemArray[24].ToString().Trim() == "")
                        {
                            emps.ResignDate = null;
                        }
                        else
                        {
                            emps.ResignDate = Convert.ToDateTime(row.ItemArray[24].ToString());
                        }

                    }
                    if (row.ItemArray.Length > 25)
                    {
                        if (row.ItemArray[25].ToString().Trim() == "")
                        {
                            emps.BirthDate = null;
                          }
                        else
                        {
                            emps.BirthDate = Convert.ToDateTime(row.ItemArray[25].ToString().Trim());
                        }
                    }
                    if (row.ItemArray.Length > 26)
                    {
                        if (row.ItemArray[26].ToString().Trim() == "")
                        {
                            emps.CreateDate = null;//
                        }
                        else
                        {
                            emps.CreateDate = Convert.ToDateTime(row.ItemArray[26].ToString());
          
                        }
              
                    }
                    if (row.ItemArray.Length > 27)
                    {
                        emps.Union1 = Convert.ToInt16(row.ItemArray[27].ToString());
                    }
                    if (row.ItemArray.Length > 28)
                    {
                        emps.Union2 = Convert.ToInt16(row.ItemArray[28].ToString());
                    }
                    if (row.ItemArray.Length > 29)
                    {
                        emps.Union3 = Convert.ToInt16(row.ItemArray[29].ToString());
                    }
                    if (row.ItemArray.Length > 30)
                    {
                        emps.Union4 = Convert.ToInt16(row.ItemArray[30].ToString());
                    }
                    if (row.ItemArray.Length > 31)
                    {
                        emps.Union5 = Convert.ToInt16(row.ItemArray[31].ToString());
                    }
                    if (row.ItemArray.Length > 32)
                    {
                        emps.Union6 = Convert.ToInt16(row.ItemArray[32].ToString());
                    }
                    if (row.ItemArray.Length > 33)
                    {
                        emps.Union7 = Convert.ToInt16(row.ItemArray[33].ToString());
                    }
                    if (row.ItemArray.Length > 34)
                    {
                        emps.Union8 = Convert.ToInt16(row.ItemArray[34].ToString());
                    }
                    if (row.ItemArray.Length > 35)
                    {
                        emps.Union9 = Convert.ToInt16(row.ItemArray[35].ToString());
                    }
                    if (row.ItemArray.Length > 36)
                    {
                        emps.Union10 = Convert.ToInt16(row.ItemArray[36].ToString());
                    }
                    if (row.ItemArray.Length > 37)
                    {
                        emps.Union11 = Convert.ToInt16(row.ItemArray[37].ToString());
                    }
                    if (row.ItemArray.Length > 38)
                    {
                        emps.Union12 = Convert.ToInt16(row.ItemArray[38].ToString());
                    }
                }
                return emps;
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


            static void Main(string[] args)
            {
               // string file = "..\\..\\myTest.xlsx";
               // TestExcelWrite(file);
               // TestExcelRead(file);
            }


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
            if (VG == "Order")
            {
           //     tabl = GetDgvToTable(dgvOrderSize);
            }
            else if (VG == "SizeRun")
            {
                //    tabl = GetDgvToTable(dataGridViewSizeRun);
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

        public static Object ToDbValue(Object value)
        {
            if (value == null)
            { return DBNull.Value; }
            else
            {
                return value;
            }
        }


        public static Object FromDbValue(Object value)
        {
            if (value == DBNull.Value)
            { return null; }
            else
            {
                return value;
            }
        }






    }



  

}
