using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
     public class HR_DepartmentManager
    {
        DAL.HR_DepartmentService ds = new DAL.HR_DepartmentService();

        #region 获取部門信息  - List<MODEL.HR_Department> GetDapartment()

        /// <summary>
        /// 获取部門信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.HR_Department> GetDapartment()
        {

            return ds.GetDapartment();
        }

        #endregion

        #region 获取部門信息 List<MODEL.HR_Department> GetDapartment(decimal aid)

        /// <summary>
        /// 获取部門信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.HR_Department> GetDapartment(decimal aid)
        {
            return ds.GetDapartment(aid);
        }

        #endregion


        #region 更新部門上層代號   int uupdateDeptAPid(float aid, float apid)
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updateDeptAPid(decimal aid, decimal apid)
        {

            return ds.updateDeptAPid(aid,apid);
        }
        #endregion


        #region 更新部門   int updateDept(decimal aid, string unitname, string empname)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updateDept(decimal aid, string unitname, string empname)
        {
            return ds.updateDept(aid, unitname, empname); 
        }
        #endregion









    }
}
