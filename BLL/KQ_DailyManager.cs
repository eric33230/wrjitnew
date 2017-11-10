using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public class KQ_DailyManager
    {

        DAL.KQ_DailyService dls = new DAL.KQ_DailyService();

        #region 查尋日考勤  - List<MODEL.KQ_Daily> SeeKQDaily(string kqdate)
        /// 查尋日考勤
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Daily> SeeKQDaily(string kqdate)
        {
            return dls.SeeKQDaily(kqdate);
        }

        #endregion

        #region 查尋日考勤未打卡  -  List<MODEL.KQ_Daily> SeeKQDailyNO(string kqdate)
        /// 查尋日考勤
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Daily> SeeKQDailyNO(string kqdate)
        {

            return dls.SeeKQDailyNO(kqdate);
        }

        #endregion


        #region 查尋日部門考勤未打卡  -  List<MODEL.KQ_Daily> SeeKQDailyNO(string kqdate,string aidf ,string aidt)
        /// 查尋部門日考勤
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.KQ_Daily> SeeKQDailyNO(string kqdate, string aidf, string aidt)
        {

            return dls.SeeKQDailyNO(kqdate,aidf,aidt);
        }

        #endregion










        #region 更新日考勤 int updateKQDaily(string whout,string ohour, string lmin1,string emin2, string lmin2,string emin3)
        /// <summary>
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updateKQDaily(string whout, string ohour, string lmin1, string emin2, string lmin2, string emin3, Guid guid)
        {
            return dls.updateKQDaily(whout, ohour, lmin1, emin2, lmin2, emin3, guid);
        }



        #endregion





    }
}

