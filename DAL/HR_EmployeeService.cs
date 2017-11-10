using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class HR_EmployeeService
    {
        #region 获取舊系統人員信息  - List<MODEL.Employee> GetEmployee(float enrollno)

        /// <summary>
        ///
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.Employee> GetEmployee(float enrollno)
        {
            string sql = @"
            select  * 
            from Employee where EnrollNo>=@EnrollNo order by EnrollNo

                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@EnrollNo",enrollno)
                              };
            //連接198.抓舊人事資料
            //  DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            DataTable dt = SqlHelper.ExcuteTable1(sql, ps);
            List<MODEL.Employee> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.Employee>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.Employee c = new MODEL.Employee();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 加载舊系統人員数据到对象--void  LoadDataToList(DataRow dr, MODEL.Employee emp)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList(DataRow dr, MODEL.Employee emp)
        {
            emp.Accountno = (int)(SqlHelper.FromDbValue(dr["Accountno"]));
            emp.EmpID = (string)SqlHelper.FromDbValue(dr["EmpID"]);
            emp.EnrollNo = Convert.ToSingle(SqlHelper.FromDbValue(dr["EnrollNo"]));
            //       emp.EnrollNo = (float)SqlHelper.FromDbValue(dr["EnrollNo"]);
            emp.CallName = (string)SqlHelper.FromDbValue(dr["CallName"]);
            emp.KhName = (string)SqlHelper.FromDbValue(dr["KhName"]);
            emp.HireDate = (DateTime)SqlHelper.FromDbValue(dr["HireDate"]);
            emp.BirthDate = (DateTime?)SqlHelper.FromDbValue(dr["BirthDate"]);

            emp.DeptID = (int)(SqlHelper.FromDbValue(dr["DeptID"]));
            emp.JobID = (int)(SqlHelper.FromDbValue(dr["JobID"]));
            emp.NationalID = (int)(SqlHelper.FromDbValue(dr["NationalID"]));
            emp.ProvinceID = (int)(SqlHelper.FromDbValue(dr["ProvinceID"]));
            emp.ShiftID = (int)(SqlHelper.FromDbValue(dr["ShiftID"]));

            emp.Union1 = (int)(SqlHelper.FromDbValue(dr["Union1"]));
            emp.Union2 = (int)(SqlHelper.FromDbValue(dr["Union2"]));
            emp.Union3 = (int)(SqlHelper.FromDbValue(dr["Union3"]));
            emp.Union4 = (int)(SqlHelper.FromDbValue(dr["Union4"]));
            emp.Union5 = (int)(SqlHelper.FromDbValue(dr["Union5"]));
            emp.Union6 = (int)(SqlHelper.FromDbValue(dr["Union6"]));
            emp.Union7 = (int)(SqlHelper.FromDbValue(dr["Union7"]));
            emp.Union8 = (int)(SqlHelper.FromDbValue(dr["Union8"]));
            emp.Union9 = (int)(SqlHelper.FromDbValue(dr["Union9"]));
            emp.Union10 = (int)(SqlHelper.FromDbValue(dr["Union10"]));
            emp.Union11 = (int)(SqlHelper.FromDbValue(dr["Union11"]));
            emp.Union12 = (int)(SqlHelper.FromDbValue(dr["Union12"]));

            emp.IsContract = (bool)(SqlHelper.FromDbValue(dr["IsContract"]));
            emp.IsPermanent = (bool)(SqlHelper.FromDbValue(dr["IsPermanent"]));
            emp.IsResign = (bool)(SqlHelper.FromDbValue(dr["IsResign"]));


            emp.Address = (string)SqlHelper.FromDbValue(dr["Address"]);
            emp.Gender = (string)SqlHelper.FromDbValue(dr["Gender"]);
            emp.Status = (string)SqlHelper.FromDbValue(dr["Status"]);
            emp.NSSF = (string)SqlHelper.FromDbValue(dr["NSSF"]);
            emp.WorkBook = (string)SqlHelper.FromDbValue(dr["WorkBook"]);
            emp.Education = (string)SqlHelper.FromDbValue(dr["Education"]);
            emp.CardNo = (string)SqlHelper.FromDbValue(dr["CardNo"]);
            emp.PersonalID = (string)SqlHelper.FromDbValue(dr["PersonalID"]);
            emp.ResignType = (string)SqlHelper.FromDbValue(dr["ResignType"]);
            emp.ResignDate = (DateTime?)SqlHelper.FromDbValue(dr["ResignDate"]);
            emp.ResignReason = (string)SqlHelper.FromDbValue(dr["ResignReason"]);
            emp.CreateDate = (DateTime?)SqlHelper.FromDbValue(dr["CreateDate"]);
            // emp.Pic= ()SqlHelper.FromDbValue(dr["Pic"]);







        }
        #endregion


        #region 轉換舊系統人員信息  - List<MODEL.Employee> GetEmployee(float enrollno)

        /// <summary>
        ///
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.Employee> TransEmp(int enrollno)
        {
            string sql = @"
            select  * 
            from Employee where EnrollNo>=@EnrollNo order by EnrollNo

                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@EnrollNo",enrollno)
                              };

            //  DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            DataTable dt = SqlHelper.ExcuteTable1(sql, ps);
            List<MODEL.Employee> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.Employee>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.Employee c = new MODEL.Employee();
                    LoadDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion

        #region 获取部門AID  -    decimal? GetAID(string deptid)
        /// <summary>
        /// 获取部門AID
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public double? GetAID(int deptid)
        {
            string sql = @"
                      select top 1 AID from HR_Department where DeptID=@DeptID
            ";
            SqlParameter[] ps =
                {
              new SqlParameter("@DeptID",SqlDbType.Int) {Value=SqlHelper.FromDbValue( deptid) }
            };


            return SqlHelper.ExcuteScalar<double?>(sql, ps);


        }
        #endregion


        #region 獲取所有部門  -  List<MODEL.HR_Department> GetAllDept()
        /// <summary>
        ///
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.HR_Department> GetAllDept()
        {
            string sql = @"
        select* from HR_Department where(AID>=17.11111 and AID<17.99999) or(AID>=21.11111 and AID<21.99999)
  or(AID>=19.1111 and AID<19.99999) and isDelete = '0'

                            ";
            //SqlParameter[] ps = {
            //                   new SqlParameter("@AID",aid)
            //                  };

            //     DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            DataTable dt = SqlHelper.ExcuteTable(sql);
            List<MODEL.HR_Department> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.HR_Department>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.HR_Department c = new MODEL.HR_Department();
                    LoadDataToList2(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion
        #region 加载部門据到对象-- void LoadDataToList2(DataRow dr, MODEL.HR_Department dep)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList2(DataRow dr, MODEL.HR_Department dep)
        {
            dep.AID = Convert.ToDecimal(SqlHelper.FromDbValue(dr["AID"]));
            dep.Unit = (string)SqlHelper.FromDbValue(dr["Unit"]);
            dep.UnitName = (string)SqlHelper.FromDbValue(dr["UnitName"]);
        }
        #endregion














        #region 獲得部門人員信息  - List<MODEL.HR_Employee> GetHREmployee(float aid)
        /// <summary>
        ///
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.HR_Employee> GetHREmployee(string aid)
        {
            string sql = @"
            select  * 
            from HR_Employee where AID=@AID order by EnrollNo

                            ";
            SqlParameter[] ps = {
                               new SqlParameter("@AID",aid)
                              };

            DataTable dt = SqlHelper.ExcuteTable(sql, ps);
            List<MODEL.HR_Employee> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.HR_Employee>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.HR_Employee c = new MODEL.HR_Employee();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion



        #region 獲取所有人員  -  List<MODEL.HR_Employee> SeeHREmployee(string mempid, string menorllno,bool mchkfaid, string mfaid, bool mchktaid, string mtaid)
        /// <summary>
        ///
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.HR_Employee> SeeHREmployee(string mempid, string menorllno, bool mchkfaid, string mfaid, bool mchktaid, string mtaid,string mdel )
        {
            string sql = @"
            select  *  from HR_Employee 
                            ";
            List<string> listWhere = new List<string>();
            List<SqlParameter> listParameters = new List<SqlParameter>();

            if (mempid != "")
            {
                listWhere.Add(" EmpID like @EmpID ");
                listParameters.Add(new SqlParameter("@EmpID", mempid + "%"));
            }
            if (menorllno != "")
            {
                listWhere.Add(" EnrollNo=@EnrollNo ");
                listParameters.Add(new SqlParameter("@EnrollNo", menorllno));
            }


            if (mchkfaid == true)
            {
                if (mchktaid == true)
                {
                    listWhere.Add(" AID >=@FAID and AID<=@TAID ");
                    listParameters.Add(new SqlParameter("@FAID", mfaid));
                    listParameters.Add(new SqlParameter("@TAID", mtaid));
                }
                else
                {
                    listWhere.Add(" AID=@FAID ");
                    listParameters.Add(new SqlParameter("@FAID", mfaid));
                }

            }
            if (mdel != "")
            {
                listWhere.Add(" isDel<=@isDel ");
                listParameters.Add(new SqlParameter("@isDel", mdel));
            }


            if (listWhere.Count > 0)
            {
                string sqlWhere = string.Join(" and ", listWhere.ToArray());
                sql = sql + " where   " + sqlWhere + " order by AID,EmpID ";
            }

            DataTable dt = SqlHelper.ExcuteTable(sql, listParameters.ToArray());
            List<MODEL.HR_Employee> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<MODEL.HR_Employee>();
                foreach (DataRow row in dt.Rows)
                {
                    MODEL.HR_Employee c = new MODEL.HR_Employee();
                    LoadDataToList1(row, c);
                    lists.Add(c);
                }
            }
            return lists;
        }

        #endregion



        #region 加载系統人員数据到对象--void LoadDataToList1(DataRow dr, MODEL.HR_Employee emp)
        /// <summary>
        /// 加载行数据到对象--集合
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="classes"></param>
        public void LoadDataToList1(DataRow dr, MODEL.HR_Employee emp)
        {
            emp.Guid=(Guid)(SqlHelper.FromDbValue(dr["Guid"]));
            emp.AID = Convert.ToDecimal(SqlHelper.FromDbValue(dr["AID"]));
            emp.Accountno = (int?)(SqlHelper.FromDbValue(dr["Accountno"]));
            emp.EmpID = (string)SqlHelper.FromDbValue(dr["EmpID"]);

            emp.Title = (string)SqlHelper.FromDbValue(dr["Title"]);
            emp.Job = (string)SqlHelper.FromDbValue(dr["Job"]);
            emp.Salary = (string)SqlHelper.FromDbValue(dr["Salary"]);

            emp.ELName = (string)SqlHelper.FromDbValue(dr["ELName"]);
            emp.EName = (string)SqlHelper.FromDbValue(dr["EName"]);
            emp.KLName = (string)SqlHelper.FromDbValue(dr["KLName"]);
            emp.KName = (string)SqlHelper.FromDbValue(dr["KName"]);


            emp.EnrollNo = Convert.ToSingle(SqlHelper.FromDbValue(dr["EnrollNo"]));
            //       emp.EnrollNo = (float)SqlHelper.FromDbValue(dr["EnrollNo"]);
            emp.CallName = (string)SqlHelper.FromDbValue(dr["CallName"]);
            emp.KhName = (string)SqlHelper.FromDbValue(dr["KhName"]);
            emp.HireDate = (DateTime?)SqlHelper.FromDbValue(dr["HireDate"]);
            emp.BirthDate = (DateTime?)SqlHelper.FromDbValue(dr["BirthDate"]);
            emp.DeptID = (int?)(SqlHelper.FromDbValue(dr["DeptID"]));
            emp.JobID = (int?)(SqlHelper.FromDbValue(dr["JobID"]));
            emp.NationalID = (int?)(SqlHelper.FromDbValue(dr["NationalID"]));
            emp.ProvinceID = (int?)(SqlHelper.FromDbValue(dr["ProvinceID"]));
            emp.ShiftID = (int?)(SqlHelper.FromDbValue(dr["ShiftID"]));
            emp.Union1 = (int?)(SqlHelper.FromDbValue(dr["Union1"]));
            emp.Union2 = (int?)(SqlHelper.FromDbValue(dr["Union2"]));
            emp.Union3 = (int?)(SqlHelper.FromDbValue(dr["Union3"]));
            emp.Union4 = (int?)(SqlHelper.FromDbValue(dr["Union4"]));
            emp.Union5 = (int?)(SqlHelper.FromDbValue(dr["Union5"]));
            emp.Union6 = (int?)(SqlHelper.FromDbValue(dr["Union6"]));
            emp.Union7 = (int?)(SqlHelper.FromDbValue(dr["Union7"]));
            emp.Union8 = (int?)(SqlHelper.FromDbValue(dr["Union8"]));
            emp.Union9 = (int?)(SqlHelper.FromDbValue(dr["Union9"]));
            emp.Union10 = (int?)(SqlHelper.FromDbValue(dr["Union10"]));
            emp.Union11 = (int?)(SqlHelper.FromDbValue(dr["Union11"]));
            emp.Union12 = (int?)(SqlHelper.FromDbValue(dr["Union12"]));
            emp.isDel = (int?)(SqlHelper.FromDbValue(dr["isDel"]));
            emp.PrePaid = (bool?)(SqlHelper.FromDbValue(dr["PrePaid"]));
            emp.Paid = (bool?)(SqlHelper.FromDbValue(dr["Paid"]));
            emp.IsContract = (bool?)(SqlHelper.FromDbValue(dr["IsContract"]));
            emp.IsPermanent = (bool?)(SqlHelper.FromDbValue(dr["IsPermanent"]));
            emp.IsResign = (bool?)(SqlHelper.FromDbValue(dr["IsResign"]));
            emp.Address = (string)SqlHelper.FromDbValue(dr["Address"]);
            emp.Gender = (string)SqlHelper.FromDbValue(dr["Gender"]);
            emp.Status = (string)SqlHelper.FromDbValue(dr["Status"]);
            emp.NSSF = (string)SqlHelper.FromDbValue(dr["NSSF"]);
            emp.WorkBook = (string)SqlHelper.FromDbValue(dr["WorkBook"]);
            emp.Education = (string)SqlHelper.FromDbValue(dr["Education"]);
            emp.CardNo = (string)SqlHelper.FromDbValue(dr["CardNo"]);
            emp.PersonalID = (string)SqlHelper.FromDbValue(dr["PersonalID"]);
            emp.ResignType = (string)SqlHelper.FromDbValue(dr["ResignType"]);
            emp.ResignDate = (DateTime?)SqlHelper.FromDbValue(dr["ResignDate"]);
            emp.ResignReason = (string)SqlHelper.FromDbValue(dr["ResignReason"]);
            emp.CreateDate = (DateTime?)SqlHelper.FromDbValue(dr["CreateDate"]);
            emp.KeepFrom= (DateTime?)SqlHelper.FromDbValue(dr["KeepFrom"]);
            emp.BackWork = (DateTime?)SqlHelper.FromDbValue(dr["BackWork"]);
            emp.Photo = (byte[] )SqlHelper.FromDbValue(dr["Photo"]);


            // emp.Pic= ()SqlHelper.FromDbValue(dr["Pic"]);







        }
        #endregion








        #region 增加人員 - intAddHREmployee(MODEL.HR_Employee  emp)
        /// 增加人员
        /// </summary>
        /// <param name="addStyleBase"></param>
        /// <returns></returns>
        public int AddHREmployee(MODEL.HR_Employee emp)
        {
            //string sql = "";
            string sql = @"

INSERT INTO [dbo].[HR_Employee]
           ([AID],[DeptID],[EmpID],[Title],[Salary],[Job]
            ,[EnrollNo],[Accountno],[NationalID],[JobID]
            ,[ProvinceID],[ShiftID],[CallName],[KhName],[KLName],[KName],[ELName],[EName]
            ,[Gender],[Status],[PersonalID],[NSSF],[Education]
           ,[WorkBook],[CardNo],[Address],[PrePaid],[Paid]
            ,[IsPermanent],[IsContract],[IsResign],[ResignType],[ResignReason],[ResignDate],[BirthDate],[CreateDate]
           ,[Union1],[Union2],[Union3],[Union4],[Union5],[Union6],[Union7],[Union8],[Union9],[Union10],[Union11],[Union12],[Photo],[isDel])
     VALUES
           (@AID,@DeptID,@EmpID,@Title,@Salary,@Job
            ,@EnrollNo,@Accountno,@NationalID,@JobID
            ,@ProvinceID,@ShiftID,@CallName,@KhName,@KLName,@KName,@ELName,@EName
            ,@Gender,@Status,@PersonalID,@NSSF,@Education
           ,@WorkBook,@CardNo,@Address,@PrePaid,@Paid
           ,@IsPermanent,@IsContract,@IsResign,@ResignType,@ResignReason,@ResignDate,@BirthDate,@CreateDate
           ,@Union1,@Union2,@Union3,@Union4,@Union5,@Union6,@Union7,@Union8,@Union9,@Union10,@Union11,@Union12,@Photo,@isDel)
 
           
                            ";

            SqlParameter[] ps = {
                                new SqlParameter("@AID",SqlDbType.Decimal) {Value=SqlHelper.ToDbValue(emp.AID)},
                                new SqlParameter("DeptID",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.DeptID)},

                               new SqlParameter("@Title",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Title)},
                               new SqlParameter("@Salary",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Salary)},
                               new SqlParameter("@Job",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Job)},

                               new SqlParameter("@EmpID",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.EmpID)},
                                new SqlParameter("@EnrollNo",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.EnrollNo)},
                                new SqlParameter("@Accountno",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Accountno)},
                               new SqlParameter("@NationalID",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.NationalID)},
                               new SqlParameter("@JobID",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.JobID)},
                                new SqlParameter("@ProvinceID",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.ProvinceID)},
                               new SqlParameter("@ShiftID",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.ShiftID)},
                               new SqlParameter("@CallName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.CallName)},
                               new SqlParameter("@KhName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.KhName)},

                               new SqlParameter("@KLName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.KLName)},
                               new SqlParameter("@KName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.KName)},
                               new SqlParameter("@ELName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.ELName)},
                               new SqlParameter("@EName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.EName)},


                               new SqlParameter("@Gender",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Gender)},
                               new SqlParameter("@Status",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Status)},
                               new SqlParameter("@PersonalID",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.PersonalID)},
                               new SqlParameter("@NSSF",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.NSSF)},
                               new SqlParameter("@Education",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Education)},
                               new SqlParameter("@WorkBook",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.WorkBook)},
                               new SqlParameter("@CardNo",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.CardNo)},
                               new SqlParameter("@Address",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Address)},

                               new SqlParameter("@PrePaid",SqlDbType.Bit) {Value=SqlHelper.ToDbValue(emp.PrePaid)},
                               new SqlParameter("@Paid",SqlDbType.Bit) {Value=SqlHelper.ToDbValue(emp.Paid)},
                               new SqlParameter("@IsPermanent",SqlDbType.Bit) {Value=SqlHelper.ToDbValue(emp.IsPermanent)},
                               new SqlParameter("@IsContract",SqlDbType.Bit) {Value=SqlHelper.ToDbValue(emp.IsContract)},
                               new SqlParameter("@IsResign",SqlDbType.Bit) {Value=SqlHelper.ToDbValue(emp.IsResign)},
                               new SqlParameter("@ResignType",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.ResignType)},
                               new SqlParameter("@ResignReason",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.ResignReason)},

                               new SqlParameter("@ResignDate",SqlDbType.Date) {Value=SqlHelper.ToDbValue(emp.ResignDate)},
                               new SqlParameter("@BirthDate",SqlDbType.Date) {Value=SqlHelper.ToDbValue(emp.BirthDate)},
                               new SqlParameter("@CreateDate",SqlDbType.Date) {Value=SqlHelper.ToDbValue(emp.CreateDate)},

                                new SqlParameter("@Union1",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union1)},
                                new SqlParameter("@Union2",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union2)},
                                new SqlParameter("@Union3",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union3)},
                                new SqlParameter("@Union4",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union4)},
                                new SqlParameter("@Union5",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union5)},
                                new SqlParameter("@Union6",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union6)},
                                new SqlParameter("@Union7",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union7)},
                                new SqlParameter("@Union8",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union8)},
                                new SqlParameter("@Union9",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union9)},
                                new SqlParameter("@Union10",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union10)},
                                new SqlParameter("@Union11",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union11)},
                                new SqlParameter("@Union12",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union12)},
                                new SqlParameter("@Photo",SqlDbType.Image) {Value=SqlHelper.ToDbValue(emp.Photo)},

            new SqlParameter("@isDel",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.isDel)}

            };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion


        #region 修改人員 - int UpdateHREmployee(MODEL.HR_Employee  emp)
        /// 增加人员
        /// </summary>
        /// <param name="addStyleBase"></param>
        /// <returns></returns>
        public int UpdateHREmployee(MODEL.HR_Employee emp)
        {              
             string sql = @"

UPDATE  [dbo].[HR_Employee]

Set AID=@AID, DeptID=@DeptID,EmpID=@EmpID,Title=@Title,Salary=@Salary,Job=@Job,
EnrollNo=@EnrollNo,Accountno=@Accountno,NationalID=@NationalID,JobID=@JobID,ProvinceID=@ProvinceID,
ShiftID=@ShiftID,CallName=@CallName,KhName=@KhName,KLName=@KLName,KName=@KName,ELName=@ELName,EName=@EName,
Gender=@Gender,Status=@Status,PersonalID=@PersonalID,NSSF=@NSSF,Education=@Education,
WorkBook=@WorkBook,CardNo=@CardNo,Address=@Address,PrePaid=@PrePaid,Paid=@Paid,
IsPermanent=@IsPermanent,IsContract=@IsContract,IsResign=@IsResign,ResignType=@ResignType,ResignReason=@ResignReason,ResignDate=@ResignDate,
BirthDate=@BirthDate,CreateDate=@CreateDate,HireDate=@HireDate,KeepFrom=@KeepFrom,BackWork=@BackWork,
Union1=@Union1,Union2=@Union2,Union3=@Union3,Union4=@Union4,Union5=@Union5,Union6=@Union6,Union7=@Union7,Union8=@Union8,Union9=@Union9,Union10=@Union10,Union11=@Union11,Union12=@Union12,
Photo=@Photo,isDel=@isDel
WHERE Guid=@Guid
                            ";

            SqlParameter[] ps = {
                                new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value=SqlHelper.ToDbValue(emp.Guid)},
                                new SqlParameter("@AID",SqlDbType.Decimal) {Value=SqlHelper.ToDbValue(emp.AID)},
                                new SqlParameter("DeptID",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.DeptID)},
                               new SqlParameter("@EmpID",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.EmpID)},

                               new SqlParameter("@Title",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Title)},
                               new SqlParameter("@Salary",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Salary)},
                               new SqlParameter("@Job",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Job)},

                                new SqlParameter("@EnrollNo",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.EnrollNo)},
                                new SqlParameter("@Accountno",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Accountno)},
                               new SqlParameter("@NationalID",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.NationalID)},
                               new SqlParameter("@JobID",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.JobID)},
                                new SqlParameter("@ProvinceID",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.ProvinceID)},
                               new SqlParameter("@ShiftID",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.ShiftID)},
                               new SqlParameter("@CallName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.CallName)},
                               new SqlParameter("@KhName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.KhName)},

                               new SqlParameter("@KLName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.KLName)},
                               new SqlParameter("@KName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.KName)},
                              new SqlParameter("@ELName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.ELName)},
                               new SqlParameter("@EName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.EName)},


                               new SqlParameter("@Gender",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Gender)},
                               new SqlParameter("@Status",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Status)},
                               new SqlParameter("@PersonalID",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.PersonalID)},
                               new SqlParameter("@NSSF",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.NSSF)},
                               new SqlParameter("@Education",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Education)},
                                new SqlParameter("@WorkBook",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.WorkBook)},
                               new SqlParameter("@CardNo",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.CardNo)},
                               new SqlParameter("@Address",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.Address)},

                               new SqlParameter("@PrePaid",SqlDbType.Bit) {Value=SqlHelper.ToDbValue(emp.PrePaid)},
                               new SqlParameter("@Paid",SqlDbType.Bit) {Value=SqlHelper.ToDbValue(emp.Paid)},
                               new SqlParameter("@IsPermanent",SqlDbType.Bit) {Value=SqlHelper.ToDbValue(emp.IsPermanent)},
                               new SqlParameter("@IsContract",SqlDbType.Bit) {Value=SqlHelper.ToDbValue(emp.IsContract)},
                               new SqlParameter("@IsResign",SqlDbType.Bit) {Value=SqlHelper.ToDbValue(emp.IsResign)},
                               new SqlParameter("@ResignType",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.ResignType)},
                               new SqlParameter("@ResignReason",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(emp.ResignReason)},

                               new SqlParameter("@ResignDate",SqlDbType.Date) {Value=SqlHelper.ToDbValue(emp.ResignDate)},
                               new SqlParameter("@BirthDate",SqlDbType.Date) {Value=SqlHelper.ToDbValue(emp.BirthDate)},
                               new SqlParameter("@CreateDate",SqlDbType.Date) {Value=SqlHelper.ToDbValue(emp.CreateDate)},
                               new SqlParameter("@HireDate",SqlDbType.Date) {Value=SqlHelper.ToDbValue(emp.HireDate)},
                               new SqlParameter("@KeepFrom",SqlDbType.Date) {Value=SqlHelper.ToDbValue(emp.KeepFrom)},
                               new SqlParameter("@BackWork",SqlDbType.Date) {Value=SqlHelper.ToDbValue(emp.BackWork)},

                                new SqlParameter("@Union1",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union1)},
                                new SqlParameter("@Union2",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union2)},
                                new SqlParameter("@Union3",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union3)},
                                new SqlParameter("@Union4",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union4)},
                                new SqlParameter("@Union5",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union5)},
                                new SqlParameter("@Union6",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union6)},
                                new SqlParameter("@Union7",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union7)},
                                new SqlParameter("@Union8",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union8)},
                                new SqlParameter("@Union9",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union9)},
                                new SqlParameter("@Union10",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union10)},
                                new SqlParameter("@Union11",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union11)},
                                new SqlParameter("@Union12",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.Union12)},
                                new SqlParameter("@Photo",SqlDbType.Image) {Value=SqlHelper.ToDbValue(emp.Photo)},

                                new SqlParameter("@isDel",SqlDbType.Int) {Value=SqlHelper.ToDbValue(emp.isDel)}

            };
            return SqlHelper.ExecuteNonQuery(sql, ps);
        }
        #endregion

    



    }
}
