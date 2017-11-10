using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class doc_OrderSizeManager
    {

        DAL.doc_OrderSizeService oss = new DAL.doc_OrderSizeService();

        #region 验证订单明細是否存在 -nt IsOrderSizeExisits(string customstylecode,string size)
        /// <summary>
        /// 验证订单是否存在 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsOrderSizeExisits(string customstylecode, string size)
        {
            return oss.IsOrderSizeExisits(customstylecode, size);
        }
        #endregion



        #region 增加订单明細 -  int AddOrderSize(MODEL.doc_Order  order)
        /// 增加订单
        /// </summary>
        /// <param>"order"></param>
        /// <returns></returns>
        public int AddOrderSize(MODEL.doc_OrderSize ordersize)
        {
            return oss.AddOrderSize(ordersize);
        }
        #endregion

        #region 获取訂單尺碼沒有內盒條碼的訊息  -  List<MODEL.doc_OrderSize> GetNoInnerBarcode(string yyyymm)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_OrderSize> GetNoInnerBarcode(string yyyymm)
        {
            return oss.GetNoInnerBarcode(yyyymm);
        }
        #endregion


        #region 更新訂單尺碼內盒條碼   int updateOrderSizeInnerBarcode(string name,string color,string size)
        /// <summary>
        ///  
        /// </summary>
        /// <param ></param>
        /// <returns></returns>

        public int updateOrderSizeInnerBarcode(string innerbarcode, string name, string color, string size, string type)
        {
            return oss.updateOrderSizeInnerBarcode(innerbarcode,name, color, size, type);
        }
        #endregion


        #region 獲取內盒條碼  string GetInnerBarcode(string name, string color, string size, string type)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cutno"></param>
        /// <returns></returns>

        public string GetInnerBarcode(string name, string color, string size, string type)
        { 
        return oss.GetInnerBarcode(name,color,size,type);
          }
        #endregion


        #region  查询訂單尺碼- List<MODEL.doc_OrderSize> SeeOrderSize(string orderdate, string customname, string name, string customstylecode)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>

        public List<MODEL.doc_OrderSize> SeeOrderSize(string orderdate, string customname, string name, string customstylecode)
        {

            return oss.SeeOrderSize(orderdate,customname, name, customstylecode);
        }
        #endregion




    }
}
