using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
     public class doc_holidayeditManager
    {

        DAL.doc_holidayeditService hos = new DAL.doc_holidayeditService();
        
        #region 创建班级数据访问层类对象  -DAL.holidayeditService hos
        /// <summary>
        /// 创建班级数据访问层类对象
        /// </summary>

        #endregion

        #region 获取假期名称  -string Getholiday(string year,int month, int day)
        /// <summary>
        /// 获取假期名称
        /// </summary>
        /// <param name></param>
        /// <returns></returns>
        public string Getholiday(string year, int month, int day)
        {

            //     return  hos.Getholiday(year,month,day);
            return "test";
        }
        #endregion


        #region 获取所有该年的所有假期  -  List<MODEL.doc_holidayedit> GetAllholiday(string year)
        /// <summary>
        /// 获取某年所有假期其訊息
        /// </summary>
        /// <param name>date 就是year</param>
        /// <returns></returns>
        public List<MODEL.doc_holidayedit> GetAllholiday(string year)
        {
            
            return hos.GetAllholiday(year);
        }
        #endregion

        #region 增加假期信息  - int AddHoliday(MODEL.doc_holidayedit addHoliday)
        /// <summary>
        /// 增加假期信息
        /// </summary>
        /// <param name="addHoliday"></param>
        /// <returns></returns>
        public int AddHoliday(MODEL.doc_holidayedit addHoliday)
        {

            return hos.AddHoliday(addHoliday); ;// 成功返回1,不成功返回-1
        }
        #endregion

        #region 软删除，只是将状态修改为已经删除-bool DeleteHolidaySoftly(int pid)
        /// <summary>
        /// 并不是真正的删除，只是将状态修改为已经删除 -bool DeletePersonSoftly(int pid)
        /// </summary>
        public bool DeleteHolidaySoftly( string myid)
        {
              return hos.DeleteHolidaySoftly(myid)==1;
        }
        #endregion

        #region 修改假期信息  -int UpdateHoliday(MODEL.doc_holidayedit  upHoliday)
        /// <summary>
        /// 修改假期信息
        /// </summary>
        /// <param name="upHoliday"></param>
        /// <returns></returns>
        public int UpdateHoliday(MODEL.doc_holidayedit  upHoliday)
        {
            return hos.UpdateHoliday(upHoliday);
        }
        #endregion


    }
}
