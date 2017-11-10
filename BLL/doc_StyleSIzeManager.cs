using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class doc_StyleSIzeManager
    {

        DAL.doc_StyleSizeService ss = new DAL.doc_StyleSizeService();
  
        #region 获取所有型体尺碼信息  - List<MODEL.doc_StyleSize> GetStyleSizefromOrder(string yyyymm)
        /// <summary>
        /// 從訂單資料抓出來型體尺碼訊息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_StyleSize> GetStyleSizefromOrder(string yyyymm)
        {
            
            return ss.GetStyleSizefromOrder(yyyymm); 
        }
        #endregion
        
        
        
                
        #region 增加型体尺碼 - int AddStyleSize(MODEL .doc_Style  addStyle)
        /// <summary>
        /// 增加人员信息
        /// </summary>
        /// <param name="addStyle"></param>
        /// <returns></returns>
        public int AddStyleSize(MODEL.doc_StyleSize addStyleSize)
        {
          return  ss.AddStyleSize(addStyleSize);
        }
        #endregion

        
        #region 验证型体尺碼是否存在 - int IsStyleSizeExisits(string style,string size)
        /// <summary>
        ///  形体大类 可能一个工厂型体会有多个客户型体 ,所以判断有没有客户型体Name
        /// </summary>
        /// <param name="style","size"></param>
        /// <returns></returns>
        public int IsStyleSizeExisits(string style, string size)
        {
                  
            return  ss.IsStyleSizeExisits(style, size);
        }
        #endregion


        #region 获取所有型体尺码信息  - List<MODEL.doc_StyleSize> GetAllStyleSize()
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_StyleSize> GetAllStyleSize()
        {            
            return ss.GetAllStyleSize();
        }
        #endregion


        #region 获取所有型体尺码信息  - List<MODEL.doc_StyleSize> GetAllStyleSize1()
        /// <summary>
        /// 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_StyleSize> GetAllStyleSize1(string yyyymm)
        {
            return ss.GetAllStyleSize1(yyyymm);
        }
        #endregion








        /// <summary>  string GetSBNewCodeToSS(string yyyymm, string style)
        /// 尺码只需要从型体中找出大于该订单年月(表示有)的,新型体配色对应的 新型体中 最小的日期,(后面的就变成旧尺码)
        /// </summary>
        /// <param name="yyyymm"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public string GetSBNewCodeToSS(string yyyymm, string style)
        {

            return  ss.GetSBNewCodeToSS(yyyymm,style);

        }


        #region 更新型體尺码newcode日期  - int updateStyleSizeNewCode(string style, string newcode)
        /// <summary>
        /// NewCode日期可能後續月份,表示此新型體,後續月份還有,以此判斷新型體會做多久
        /// </summary>
        /// <param name="style , newcode"></param>
        /// <returns></returns>

        public int updateStyleSizeNewCode(string style, string newcode)
        {
         return   ss.updateStyleSizeNewCode(style, newcode);    
        }
        #endregion






    }
}
