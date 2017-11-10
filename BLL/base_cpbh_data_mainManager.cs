using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class base_cpbh_data_mainManager
    {


         DAL.base_cpbh_data_main mystyleno = new DAL.base_cpbh_data_main();
        #region  獲取工厂型体  -string   GetAllCode(string yearmonth)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearmonth"></param>
        /// <returns></returns>
        public List<MODEL.base_cpbh_data_main> GetOldStyle(string yearrmonth)
        {
            
            return  mystyleno.GetOldStyle(yearrmonth);
        }

        #endregion










    }
}
