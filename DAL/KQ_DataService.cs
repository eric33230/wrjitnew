using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DAL
{
    public class KQ_DataService
    {

        #region 获取部門信息  -  List<MODEL.HR_Department> GetDapartment(float aid)

        /// <summary>
        /// 获取部門信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.HR_Department> GetDapartment(decimal aidfrom, decimal aidto)
        {
            string sql = @"
                    SELECT [AID] ,[UnitName],[Unit] ,[Title] ,[EmpID] ,[EmpName]
                      FROM [HR_Department] 

                    where AID>=@AIDF
                    and AID<=@AIDT
                      order by AID
                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@AIDF",aidfrom),
                               new SqlParameter("@AIDT",aidto)
                              };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.HR_Department> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.HR_Department>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.HR_Department c = new MODEL.HR_Department();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion
        #region 加载行数据到对象-- LoadDataToList(DataRow dr, MODEL.HR_Department department)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.HR_Department department)
        {
            department.AID = (decimal)Convert.ToDecimal(SqlHelper.FromDbValue(dr["AID"]));
            department.UnitName = (string)SqlHelper.FromDbValue(dr["UnitName"]);
            department.Unit = (string)SqlHelper.FromDbValue(dr["Unit"]);
            department.Title = (string)SqlHelper.FromDbValue(dr["Title"]);
            department.EmpID = (string)SqlHelper.FromDbValue(dr["EmpID"]);
            department.EmpName = (string)SqlHelper.FromDbValue(dr["EmpName"]);

        }
        #endregion

        #region 查核考勤員工工號資料是否為空  -  List<MODEL.KQ_Data> CheckKQData(string  timefrom, decimal timeto)
        /// <summary>
        /// 获取考勤資料
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Data> CheckKQData(string  timefrom, string timeto)
        {
            string sql = @"
  select a.Guid,KQtime,a.EnrollNo,Machine,b.EmpID,b.AID,TimeNO,b.KhName from KQ_Data a
  left join(select  * from HR_Employee)b on  a.EnrollNo=b.EnrollNo
  where KQTime>@KQTimefrom and KQTime<@KQTimeto
  and (b.EmpID is null or b.AID is null)
  ORDER BY AID,EmpID,KQTime
                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@KQTimefrom",timefrom),
                               new SqlParameter("@KQTimeto",timeto)
                              };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.KQ_Data> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.KQ_Data>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.KQ_Data c = new MODEL.KQ_Data();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }
        #endregion

        #region 查尋考勤資料  -  List<MODEL.KQ_Data> SeeKQData(string timefrom, string timeto)
        /// <summary>
        /// 获取考勤資料
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Data> SeeKQData(string timefrom, string timeto)
        {
            string sql = @"
  select a.Guid,KQtime,a.EnrollNo,Machine,b.EmpID,b.AID,TimeNO,b.KhName,a.KQDate from KQ_Data a
  left join(select  * from HR_Employee)b on  a.EnrollNo=b.EnrollNo
  where KQTime>@KQTimefrom and KQTime<@KQTimeto

  ORDER BY AID,EmpID,KQTime
                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@KQTimefrom",timefrom),
                               new SqlParameter("@KQTimeto",timeto)
                              };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.KQ_Data> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.KQ_Data>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.KQ_Data c = new MODEL.KQ_Data();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }




        #endregion

        #region 查尋考勤資料  -   List<MODEL.KQ_Data> SeeKQDataByID( string empid,string kqdate)
        /// <summary>
        /// 获取考勤資料
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Data> SeeKQDataByID( string empid,string kqdate)
        {
            string sql = @"
  select * from KQ_Data where EmpID=@EmpID and  KQDate=@KQDate 	  order by KQTime desc
                            ";

            SqlParameter[] ps = {

                               new SqlParameter("@EmpID",empid),
                               new SqlParameter("@KQDate",kqdate)
                              };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.KQ_Data> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.KQ_Data>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.KQ_Data c = new MODEL.KQ_Data();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }




        #endregion




        #region 加载行数据到对象-- LoadDataToList(DataRow dr, MODEL.HR_Department department)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList1(DataRow dr, MODEL.KQ_Data  kqdata)
        {
            kqdata.Guid = (Guid)SqlHelper.FromDbValue(dr["Guid"]);
            kqdata.KQTime = (DateTime?)SqlHelper.FromDbValue(dr["KQTime"]);
            kqdata.EnrollNo = (int?)SqlHelper.FromDbValue(dr["EnrollNo"]);
            kqdata.Machine = (string)SqlHelper.FromDbValue(dr["Machine"]);
            kqdata.EmpID = (string)SqlHelper.FromDbValue(dr["EmpID"]);
            kqdata.AID = (decimal?)Convert.ToDecimal(SqlHelper.FromDbValue(dr["AID"]));
            kqdata.TimeNO = (string)SqlHelper.FromDbValue(dr["TimeNO"]);
            kqdata.KhName = (string)SqlHelper.FromDbValue(dr["KhName"]);
            kqdata.KQDate= (string)SqlHelper.FromDbValue(dr["KQDate"]);

        }
        #endregion

        #region 查尋考勤資料  - List<MODEL.KQ_Data> SeeKQDataEmpID(string kqdate)
        /// <summary>
        /// 获取考勤資料
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Data> SeeKQDataEmpID(string kqdate)
        {
            string sql = @"
  select AID,EmpID from KQ_Data where KQDate=@KQDate  Group by AID,EmpID order by AID,EmpID
                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@KQDate",kqdate)
                              };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.KQ_Data> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.KQ_Data>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.KQ_Data c = new MODEL.KQ_Data();
                    LoadDataToList3(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 加载行数据到对象-- LoadDataToList3(DataRow dr, MODEL.HR_Department department)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList3(DataRow dr, MODEL.KQ_Data kqdata)
        {


            kqdata.EmpID = (string)SqlHelper.FromDbValue(dr["EmpID"]);
            kqdata.AID = (decimal?)Convert.ToDecimal(SqlHelper.FromDbValue(dr["AID"]));


        }
        #endregion





        #region 更新考勤資料  int updateKQData(Guid guid, string timeno,string empid,string aid,string khname)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public int updateKQData(Guid guid, string timeno,string empid,decimal? aid,string khname,string kqdate )
        {

            string sql = @" 
                update KQ_Data set TimeNO=@TimeNO,EmpID=@EmpID,AID=@AID,KhName=@KhName,KQDate=@KQDate   where Guid=@Guid                
                ";

            SqlParameter[] ps = {
                new SqlParameter("@Guid", guid),
                new SqlParameter("@TimeNO", timeno),
                new SqlParameter("@EmpID", empid),
                new SqlParameter("@AID", aid),
                new SqlParameter("@KhName", khname),
                new SqlParameter("@KQDate", kqdate),
            };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        #region 查尋時間段落資料  -  List<MODEL.KQ_Section> SeeKQSection(string groupno)
        /// <summary>
        /// 获取考勤資料
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Section> SeeKQSection(string groupno)
        {
            string sql = @"
  select  *  from KQ_Section  
  where GroupNo=@GroupNo 
  ORDER BY No
                            ";

            SqlParameter[] ps = {
                               new SqlParameter("@GroupNo",groupno)

                              };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.KQ_Section> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.KQ_Section>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.KQ_Section c = new MODEL.KQ_Section();
                    LoadDataToList2(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 加载行数据到对象-- LoadDataToList2(DataRow dr, MODEL.KQ_Section kqs)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList2(DataRow dr, MODEL.KQ_Section kqs)
        {
            kqs.No = (int)SqlHelper.FromDbValue(dr["No"]);
            kqs.GroupNo = (string)SqlHelper.FromDbValue(dr["GroupNo"]);
            kqs.Section = (string)SqlHelper.FromDbValue(dr["Section"]);

            kqs.DayF = (string)SqlHelper.FromDbValue(dr["DayF"]);
            kqs.HourF = (int)SqlHelper.FromDbValue(dr["HourF"]);
            kqs.MinF = (int)SqlHelper.FromDbValue(dr["MinF"]);
            kqs.DayT = (string)SqlHelper.FromDbValue(dr["DayT"]);
            kqs.HourT = (int)SqlHelper.FromDbValue(dr["HourT"]);
            kqs.MinT = (int)SqlHelper.FromDbValue(dr["MinT"]);
            kqs.HourFSTD = (int)SqlHelper.FromDbValue(dr["HourFSTD"]);
            kqs.MinFSTD = (int)SqlHelper.FromDbValue(dr["MinFSTD"]);
            kqs.HourTSTD = (int)SqlHelper.FromDbValue(dr["HourTSTD"]);
            kqs.MinTSTD = (int)SqlHelper.FromDbValue(dr["MinTSTD"]);
        }
        #endregion




        #region 私有的静态的只读的连接字符串  -private static readonly string connStr
        /// <summary>
        /// 私有的静态的只读的连接字符串
        /// </summary>
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        #endregion

        public void InsertBulkKQDaily(DataTable table)
        {

            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connStr))
            {

                bulkcopy.BulkCopyTimeout = 0;//超时设置
                bulkcopy.DestinationTableName = "KQ_Daily";
                //--------- from T_PackList
                bulkcopy.ColumnMappings.Add("Machine", "Machine");
                bulkcopy.ColumnMappings.Add("EmpID", "EmpID");
                bulkcopy.ColumnMappings.Add("KhName", "KhName");
                bulkcopy.ColumnMappings.Add("Unit", "Unit");
                bulkcopy.ColumnMappings.Add("KQDate", "KQDate");

                bulkcopy.ColumnMappings.Add("EnrollNo", "EnrollNo");
                bulkcopy.ColumnMappings.Add("AID", "AID");

                bulkcopy.ColumnMappings.Add("KQTime1", "KQTime1");
                bulkcopy.ColumnMappings.Add("KQTime2", "KQTime2");
                bulkcopy.ColumnMappings.Add("KQTime3", "KQTime3");

                bulkcopy.ColumnMappings.Add("KQOut1", "KQOut1");
                bulkcopy.ColumnMappings.Add("KQOut2", "KQOut2");
                bulkcopy.ColumnMappings.Add("KQOut3", "KQOut3");
                bulkcopy.ColumnMappings.Add("KQOut4", "KQOut4");
                bulkcopy.ColumnMappings.Add("KQOut5", "KQOut5");
                bulkcopy.ColumnMappings.Add("KQOut6", "KQOut6");
                bulkcopy.ColumnMappings.Add("KQOut5", "KQOut7");
                bulkcopy.ColumnMappings.Add("KQOut6", "KQOut8");

                try
                {

                    bulkcopy.WriteToServer(table);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }


        }






    }
}
