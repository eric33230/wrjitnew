using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
     public class doc_StyleManager
    {

        DAL.doc_StyleService st = new DAL.doc_StyleService();
        DAL.T_StyleCodeInfoService od = new DAL.T_StyleCodeInfoService();


        #region 增加型体 - int AddStyle(MODEL.doc_Style  addStyle)
        /// <summary>
        /// 增加人员信息
        /// </summary>
        /// <param name="addStyle"></param>
        /// <returns></returns>
        public int AddStyle(MODEL.doc_Style addStyle)
        {                                 
            return   st.AddStyle(addStyle);
        }
        #endregion


        #region 根據訂單年月获取型體年月的信息  -  string GetSNewCode(string yyyymm, string code)
        /// <summary>
        /// 比較OrderDate and NewCode 就可以知道是否為新型體        /
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>

        public string GetSNewCode(string yyyymm, string code)
        {
               return   st.GetSNewCode(yyyymm,code);        
        }

        #endregion


        



        #region 获取所有型体信息  - List<MODEL.doc_Style> GetAllStyle()
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_Style> GetAllStyle()
        {

            return st.GetAllStyle();
        }
        #endregion

        #region 更新型體配色的newcode日期  - int updateStyleNewCode(string code, string newcode)
        /// <summary>
        /// NewCode日期可能後續月份,表示此新型體配色,後續月份還有,以此判斷新型體會做多久
        /// </summary>
        /// <param name="name , newcode"></param>
        /// <returns></returns>

        public int updateStyleNewCode(string code, string newcode)
        {                               
            return  st.updateStyleNewCode(code,newcode);
        }
        #endregion



       


        #region 验证工厂型体是否存在 -int IsCodeExisits(string code)
        /// <summary>
        /// 验证登录名是否已经存在 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsCodeExisits(string code)
        {       
            return st.IsCodeExisits(code);
        }
        #endregion






    }
}
