using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
     public class doc_calendarManager
    {
        
        DAL.doc_calendarService cs = new DAL.doc_calendarService();

        #region 增加工作日历  - int AddCalendar(MODEL.doc_calendar addCalendar)
        /// <summary>
        /// 增加工作日历
        /// </summary>
        /// <param name="addCalendar"></param>
        /// <returns></returns>
        public int AddCalendar(MODEL.doc_calendar addCalendar)
        {
            return cs.AddCalendar(addCalendar);
        }
        #endregion

        #region 更新工作日历  - int updateCalendar(MODEL.doc_calendar updateCalendar)
        /// <summary>
        /// 更新工作日历
        /// </summary>
        /// <param name="updateCalendar"></param>
        /// <returns></returns>

        public int updateCalendar(string myear, string mmonth, string mday, string newworktime)
        {
            return cs.updateCalendar(myear, mmonth, mday, newworktime);
            }
        #endregion

        #region 验证工作日历日期是否存在  -int IsDateExisit(string plastr)
        /// <summary>
        /// 验证日期其是否已经存在 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public int IsDateExist(DateTime date)
        {
            return cs.IsDateExist(date);
        }
        #endregion




        public int getweektime(int week, int month, string year)
        {
            return  cs.getweektime(week,month,year);
        }

        public int getmonthtime(int month, string year)
        {           
            return cs.getmonthtime(month,year);
        }


        public int getweekenday(int month, string year)
        {  
            return cs.getweekenday( month, year);
        }

        public int getnormalday(int month, string year)
        {
            return  cs.getnormalday(month, year);
        }








        #region 获取某年某月工作日历 List<MODEL.doc_calendar> GetMonthCalendar(string year, string month)
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.doc_calendar> GetMonthCalendar(string year, string month)
        {
            return cs.GetMonthCalendar(year,month);
        }
        #endregion












    }
}
