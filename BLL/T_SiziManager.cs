using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{

    public class T_SiziManager
    {

    DAL.T_SiziService tsss = new DAL.T_SiziService();



        #region 获取订单的尺碼明細  -    List<MODEL.T_Sizi> GetTSize(string comstomstylecode)
        /// 获取订单的尺碼明細
        /// </summary>
        /// <param name>date</param>
        /// <returns></returns>
        public List<MODEL.T_Sizi> GetTSize(string comstomstylecode)
        {
            return tsss.GetTSize(comstomstylecode);
        }
        #endregion


    }
}
