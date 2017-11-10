using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class KQ_DataManager
    {

        DAL.KQ_DataService ds = new DAL.KQ_DataService();

        #region 获取部門信息  -  List<MODEL.HR_Department> GetDapartment(float aid)

        /// <summary>
        /// 获取部門信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.HR_Department> GetDapartment(decimal aidfrom, decimal aidto)
        {

            return ds.GetDapartment(aidfrom, aidto);
        }

        #endregion

        #region 查核考勤員工工號資料是否為空  -  List<MODEL.KQ_Data> CheckKQData(string  timefrom, string timeto)

        /// <summary>
        /// 获取考勤資料
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Data> CheckKQData(string timefrom, string timeto)
        {

            return  ds.CheckKQData(timefrom,timeto);
        }

        #endregion

        #region 查尋懸考勤資料  -  List<MODEL.KQ_Data> SeeQData(string  timefrom, string timeto)

        /// <summary>
        /// 获取考勤資料
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Data> SeeKQData(string timefrom, string timeto)
        {

            return ds.SeeKQData(timefrom, timeto);
        }

        #endregion


        #region 更新考勤資料  int updateKQData(Guid guid, string timeno,string empid,string aid,string khname,string kqdate)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public int updateKQData(Guid guid, string timeno, string empid, decimal? aid, string khname,string kqdate)
        {            
            return ds.updateKQData(guid, timeno, empid, aid, khname, kqdate);
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

            return  ds.SeeKQSection(groupno);
        }

        #endregion



        public void InsertBulkKQDaily(DataTable table)
        {

          ds.InsertBulkKQDaily(table);


        }

        #region 查尋考勤資料  - List<MODEL.KQ_Data> SeeKQDataEmpID(string kqdate)
        /// <summary>
        /// 获取考勤資料
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Data> SeeKQDataEmpID(string kqdate)
        {

            return ds.SeeKQDataEmpID(kqdate);
        }

        #endregion


        #region 查尋考勤資料  -   List<MODEL.KQ_Data> SeeKQDataByID( string empid,string kqdate)
        /// <summary>
        /// 获取考勤資料
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Data> SeeKQDataByID(string empid, string kqdate)
        {

            return  ds.SeeKQDataByID(empid, kqdate);
        }
        #endregion




    }
}
