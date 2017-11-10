using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class doc_StyleBaseManager
    {

        DAL.doc_StyleBaseService stb = new DAL.doc_StyleBaseService();

        #region 增加型体大类 - int AddStyleBase(MODEL.doc_StyleBase addStyleBase)
        /// 增加人员信息
        /// </summary>
        /// <param name="addStyleBase"></param>
        /// <returns></returns>
        public int AddStyleBase(MODEL.doc_StyleBase addStyleBase)
        {
            return stb.AddStyleBase(addStyleBase);
        }
        #endregion


        #region 获取所有型体大类信息  - List<MODEL.doc_StyleBase> GetAllStyleBase()
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_StyleBase> GetAllStyleBase()
        {

            return stb.GetAllStyleBase();
        }
        #endregion


        #region 验证型体大类是否存在 -int IsStyleBaseExisits(string name)
        /// <summary>
        /// 验证登录名是否已经存在 
        /// </summary> 客户型体
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsStyleBaseExisits(string code)
        {

            return stb.IsStyleBaseExisits(code);
        }
        #endregion


        #region 获取所有大类信息  - List<MODEL.doc_StyleBase> GetStyleBaseNewCode(stirng yyyymm,string name)
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public List<MODEL.doc_StyleBase> GetStyleBaseNewCode(string yyyymm,string name)
        {
            return stb.GetStyleBaseNewCode(yyyymm,name);
        }
        #endregion

        #region 根據訂單年月获取型體大类年月的信息  -  string GetSBNewCode(string yyyymm, string name)
        /// <summary>
        /// 比較OrderDate and NewCode 就可以知道是否為新型體        /
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public string GetSBNewCode(string yyyymm, string name)
        {    
                                
            return stb.GetSBNewCode(yyyymm,name);

        }
        #endregion


        #region  查询型體大类- List<MODEL.doc_StyleBase> SeeStylebase(string stylebase, string style)
        /// <summary>
        /// 
        /// </summary>
        /// <param name=" Newcode,Style,StyleBase,Name , ModelNo"></param>
        /// <returns></returns>

        public List<MODEL.doc_StyleBase> SeeStylebase(string stylebase, string style,string name, string modelno,bool cbdate, string yyyymm)
        {
            return  stb.SeeStylebase(stylebase,style,name,modelno,cbdate,yyyymm);
        }
        #endregion









        #region 更新型體大類的newcode日期  - int updateStylebaseNewCode(string name, string newcode)
        /// <summary>
        /// NewCode日期可能後續月份,表示此新型體,後續月份還有,以此判斷新型體會做多久
        /// </summary>
        /// <param name="name , newcode"></param>
        /// <returns></returns>

        public int updateStylebaseNewCode(string name, string newcode)
        {
            return stb.updateStylebaseNewCode(name,newcode);
        }
        #endregion



        public int updateStylebase(string colname, string colvalue, string guid)
        {

            return stb.updateStylebase( colname,colvalue,guid);
        }






    }
}