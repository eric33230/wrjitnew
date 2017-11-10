using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
     public class doc_BuyerManager
    {
        
        DAL.doc_BuyerService bs = new DAL.doc_BuyerService();
        #region 获取所有客户买主  -  List<MODEL.doc_Buyer> GetAllBuyer()
        /// <summary>
        /// 获取某年所有假期其訊息
        /// </summary>
        /// <param name>date</param>
        /// <returns></returns>
        public List<doc_Buyer> GetAllBuyer()
        {
            return bs.GetAllBuyer();
        }
        #endregion

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="code">要查询的列</param>
        /// <param name="value">要查询的值</param>
        /// <returns></returns>
        public List<doc_Buyer> GetAllBuyer(List<string> codes, List<string> values)
        {
            return bs.GetAllBuyer(codes, values);
        }

        #region 获取订单年月目的地  -  List<MODEL.doc_Buyer> GetABuyerE(string yyyymm)
        /// <summary>
        /// 获取某年所有假期其訊息
        /// </summary>
        /// <param name>date</param>
        /// <returns></returns>
        public List<MODEL.doc_Buyer> GetlBuyerE(string yyyymm)
        {
            return  bs.GetlBuyerE(yyyymm);
        }
        #endregion


        #region 新增客户买主目的地 - int newtDestination(string customname, string destination)
        /// <summary>
        ///  只增加客户跟目的地两栏位增加一笔资料 其余使用更新
        /// </summary>
        /// <param name="name , newcode"></param>
        /// <returns></returns>

        public int newtDestination(string customname, string destination,string custombuyname)
        {
            return bs.newtDestination(customname,destination, custombuyname);
        }
        #endregion

        #region 更新客户买主  - int updateBuyer(string colname, string colvalue, string guid)
        /// <summary>
        ///  传入要更新的栏位名称,栏位值,与唯一的GUID
        ///  
        /// </summary>
        /// <param name="C"></param>
        /// <returns></returns>

        public int updateBuyer(string colname, string colvalue, string guid)
        {
            return bs.updateBuyer(colname, colvalue, guid);
        }
        #endregion






    }
}
