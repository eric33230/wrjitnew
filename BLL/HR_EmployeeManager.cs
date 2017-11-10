using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class HR_EmployeeManager
    {
        DAL.HR_EmployeeService ems = new DAL.HR_EmployeeService();

        #region 获取舊系統人員信息  - List<MODEL.Employee> GetEmployee(float enrollno)

        /// <summary>
        ///
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.Employee> GetEmployee(float enrollno)
        {
            return ems.GetEmployee(enrollno);
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

            return  ems.GetAID(deptid);

        }
        #endregion


        #region 增加人員 - int AddHREmployee(MODEL.HR_Employee  emp)
        /// 增加人员
        /// </summary>
        /// <param name="addStyleBase"></param>
        /// <returns></returns>
        public int AddHREmployee(MODEL.HR_Employee emp)
        {
            return ems.AddHREmployee(emp);
        }
        #endregion

        #region 修改人員 - int UpdateHREmployee(MODEL.HR_Employee  emp)
        /// 增加人员
        /// </summary>
        /// <param name="addStyleBase"></param>
        /// <returns></returns>
        public int UpdateHREmployee(MODEL.HR_Employee emp)
        {    return ems.UpdateHREmployee(emp);
        }
        #endregion


        #region 加載人員信息  - List<MODEL.HR_Employee> GetHREmployee(float aid)
        /// <summary>
        ///
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.HR_Employee> GetHREmployee(string aid)
        {
            return ems.GetHREmployee(aid);
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
          return   ems.GetAllDept();
        }

        #endregion



        #region 獲取所有人員  -  List<MODEL.HR_Employee>  SeeHREmployee(string mempid, string menorllno,bool mchkfaid, string mfaid, bool mchktaid, string mtaid)
        /// <summary>
        ///
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.HR_Employee> SeeHREmployee(string mempid, string menorllno, bool mchkfaid, string mfaid, bool mchktaid, string mtaid, string mdel)
        {

            return ems.SeeHREmployee(mempid, menorllno, mchkfaid, mfaid, mchktaid, mtaid, mdel);
        }

        #endregion






    }
}
