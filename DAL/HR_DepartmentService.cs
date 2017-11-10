using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class HR_DepartmentService
    {

        #region 获取部門信息  - List<MODEL.HR_Department> GetDapartment()

        /// <summary>
        /// 获取部門信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.HR_Department> GetDapartment()
        {
            string sql = @"
            select  * 
            from HR_Department order by AID

                            ";
            //  SqlParameter[] ps = {
            //                   new SqlParameter("@CustomStyleCode",customstylecode)
            //                  };

            //  DataTable dt = SqlHelper.ExcuteTable(sql, ps);
              DataTable dt = SqlHelper.ExcuteTable(sql);
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

        #region 获取部門信息  -  List<MODEL.HR_Department> GetDapartment(decimal aid)

        /// <summary>
        /// 获取部門信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.HR_Department> GetDapartment(decimal aid)
        {
            string sql = @"
            select  * 
            from HR_Department where AID=@AID 

                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@AID",aid)
                              };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
         //   DataTable dt = SqlHelper.ExcuteTable(sql);
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
           department.AID= (decimal)Convert.ToDecimal(SqlHelper.FromDbValue(dr["AID"]));
            department.DeptID =(int?)(SqlHelper.FromDbValue(dr["DeptID"]));
            department.Unit = (string)SqlHelper.FromDbValue(dr["Unit"]);
            department.EmpName = (string)SqlHelper.FromDbValue(dr["EmpName"]);
            department.UnitName = (string)SqlHelper.FromDbValue(dr["UnitName"]);
            department.Apid = Convert.ToDecimal(SqlHelper.FromDbValue(dr["Apid"]));


        }
        #endregion

        #region 更新部門上層代號   int updatePackListBarcodeCount(float aid, float apid)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updateDeptAPid(decimal aid, decimal apid)
        {

            string sql = @" 
                update HR_Department  set Apid=@Apid where AID=@AID                
                ";
            SqlParameter[] ps = {
                new SqlParameter("@AID", aid),
                new SqlParameter("@Apid", apid)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        #region 更新部門   updateDept(float aid, string  unitname,string empname)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updateDept(decimal aid, string  unitname,string empname)
        {

            string sql = @" 
                update HR_Department  set UnitName=@UnitName,EmpName=@EmpName where AID=@AID                
                ";
            SqlParameter[] ps = {
                new SqlParameter("@AID", aid),
                new SqlParameter("@UnitName", unitname),
                new SqlParameter("@EmpName", empname)
                                };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        #region 增加掃描訊息 -  int AddPackList(MODEL.doc_PackListScan packlist)
        /// </summary>
        /// <param>"order"></param>
        /// <returns></returns>
        public int AddPackList(MODEL.doc_PackListScan packlist)
        {



            string sql = @"
              insert into doc_PackListScan(Guid,CartonBarcode,InnerBarcode,ScanTime,SizeName,CustomStyleCode,OrderDate,ScanCount,ScanNO,Part)
        values(@Guid,@CartonBarcode,@InnerBarcode,@ScanTime,@SizeName,@CustomStyleCode,@OrderDate,@ScanCount,@ScanNO,@Part)";
            SqlParameter[] ps = {
                                new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(packlist.Guid)},
                               new SqlParameter("@CartonBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CartonBarcode)},
                               new SqlParameter("@InnerBarcode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.InnerBarcode)},
                              new SqlParameter("@ScanTime",SqlDbType.DateTime) {Value=SqlHelper.ToDbValue(packlist.ScanTime)},
                               new SqlParameter("@SizeName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.SizeName)},
                               new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.CustomStyleCode)},
                               new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.OrderDate)},
                               new SqlParameter("@ScanCount",SqlDbType.Int) {Value=SqlHelper.ToDbValue(packlist.ScanCount)},
                               new SqlParameter("@ScanNO",SqlDbType.Int) {Value=SqlHelper.ToDbValue(packlist.ScanNO)},
                               new SqlParameter("@Part",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(packlist.Part)}
        };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion






    }
}
