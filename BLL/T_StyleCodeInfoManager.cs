using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
     public class T_StyleCodeInfoManager
    {
        DAL.T_StyleCodeInfoService od = new DAL.T_StyleCodeInfoService();
         public string GetStyle(string myCutNo)
        {
            return od.GetStyle(myCutNo);             
        }

        public string GetColor(string myCutNo)
        {
            string color =od.GetColor(myCutNo);
            color = color.Trim();
            string[] str = color.Split('/');
            str[1] = str[1].Trim();
        
            return str[1];
        }


        #region  獲取工厂型体  -string   GetAllCode(string yearmonth)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearmonth"></param>
        /// <returns></returns>

        public List<MODEL.T_StyleCodeInfo> GetAllCode(string yearrmonth)
        {            
            return od.GetAllCode(yearrmonth);
        }
        #endregion



        #region  獲取订单 List<MODEL.T_StyleCodeInfo> GetAllorder(string yearrmonth)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearmonth"></param>
        /// <returns></returns>

        public List<MODEL.T_StyleCodeInfo> GetAllorder(string yearrmonth)
        {
            return od.GetAllorder(yearrmonth);
        }
        #endregion


        #region  獲取型体  -string   GetOrdertoStyle(string yearmonth)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearmonth"></param>
        /// <returns></returns>

        public List<MODEL.doc_StyleBase> GetOrdertolStyle(string yearmonth)
        {

            return od.GetOrdertoStyle(yearmonth);
        }
        #endregion


    }
}
