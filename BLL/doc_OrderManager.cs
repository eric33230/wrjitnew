using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
     public class doc_OrderManager
    {
        DAL.doc_OrderService ods = new DAL.doc_OrderService();

        #region 验证订单是否存在 -int IsCustomStyleCodeExisits(string customstylecode )
        /// <summary>
        /// 验证订单是否存在 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsCustomStyleCodeExisits(string customstylecode)
        {
            return ods.IsCustomStyleCodeExisits(customstylecode);
        }
        #endregion

        #region 增加订单 -  int AddOrder(MODEL.doc_Order  order)
    /// 增加订单
    /// </summary>
    /// <param>"order"></param>
    /// <returns></returns>
    public int AddOrder(MODEL.doc_Order order)
    {
                               
        return ods.AddOrder(order);
    }
        #endregion



        #region 获取訂單信息  - List<MODEL.doc_Order> GetOrder(string yyyymm)
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_Order> GetOrder(string yyyymm)
        {

            return ods.GetOrder(yyyymm);
        }
        #endregion

        #region 获取訂單信息  - List<MODEL.doc_Order> GetOrderASICS(string yyyymm)
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_Order> GetOrderASICS(string yyyymm)
        {

            return ods.GetOrderASICS(yyyymm);
        }
        #endregion


        #region 获取訂單信息  -  List<MODEL.doc_Order> GetOrderOne(string customstylecode)
        /// <summary>
        /// 获取訂單信息
        /// </summary> ...................................and CustomName='ASICS' 
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_Order> GetOrderOne(string customstylecode)
        {
            return ods.GetOrderOne(customstylecode);
        }
        #endregion









        #region 更新裝箱明細總數   int updatePacklisttotalcount(string customstylecode)
        /// <summary>
        ///  
        /// </summary>
        /// <param ></param>
        /// <returns></returns>

        public int updatePacklisttotalcount(string customstylecode,string packlisttotalcount)
        {

            return ods.updatePacklisttotalcount(customstylecode, packlisttotalcount);
        }
        #endregion






        public int GetPacklisttotalcount(string customstylecode)
        {

            return ods.GetPacklisttotalcount(customstylecode);
        }


        #region  查询訂單- List<MODEL.doc_Order> SeeOrder(string orderdate, string customname, string name, string customstylecode)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>

        public List<MODEL.doc_Order> SeeOrder(string orderdate, string customname, string name, string customstylecode,string custombuyname)
        {
                return ods.SeeOrder(orderdate,customname, name,customstylecode, custombuyname);
        }
        #endregion










        #region 获取訂單信息與裝箱明細數量不同的訂單  - List<MODEL.doc_Order> GetOrderW(string yyyymm)
        /// <summary>
        /// 获取訂單信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_Order> GetOrderW(string yyyymm)
        {
            return ods.GetOrderW(yyyymm);
        }
        #endregion











    }
}
