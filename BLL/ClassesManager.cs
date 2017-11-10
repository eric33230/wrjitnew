using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 班级表业务层类
    /// </summary>
    public class ClassesManager
    {
        #region 创建班级数据访问层类对象  -DAL.ClassesService cs 
        /// <summary>
        /// 创建班级数据访问层类对象
        /// </summary>
        DAL.ClassesService cs = new DAL.ClassesService(); 
        #endregion

        #region 获取所有班级信息  - List<MODEL.Classes> GetAllClass(bool isDel)
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <param name="isDel"></param>
        /// <returns></returns>
        public List<MODEL.Classes> GetAllClass(bool isDel)
        {
            return cs.GetAllClass(isDel);
        } 
        #endregion

    }
}
