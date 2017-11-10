using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AreasManager
    {
        #region 创建地区数据访问层对象  -DAL.AreasService areasSer
        /// <summary>
        /// 创建地区数据访问层对象
        /// </summary>
        DAL.AreasService areasSer = new DAL.AreasService(); 
        #endregion

        #region 返回所有地区信息  -List<MODEL.Areas> GetAllAreasList(bool isDel)
        /// <summary>
        /// 返回所有地区信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.Areas> GetAllAreasList(bool isDel)
        {
            return areasSer.GetAllAreasList(isDel);
        } 
        #endregion
    }
}
