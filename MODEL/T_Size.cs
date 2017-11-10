using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// T_Sizi:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Sizi
    {
        public T_Sizi()
        { }
        #region Model
        private Guid _guid;
        private Guid _t_stylecodeinfoguid;
        private string _doctreeid;
        private string _customstylecode;
        private string _sizeid;
        private string _size;
        private string _ccount;
        /// <summary>
        /// 
        /// </summary>
        public Guid Guid
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid T_StyleCodeInfoGuid
        {
            set { _t_stylecodeinfoguid = value; }
            get { return _t_stylecodeinfoguid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DocTreeID
        {
            set { _doctreeid = value; }
            get { return _doctreeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomStyleCode
        {
            set { _customstylecode = value; }
            get { return _customstylecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SizeID
        {
            set { _sizeid = value; }
            get { return _sizeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Ccount
        {
            set { _ccount = value; }
            get { return _ccount; }
        }
        #endregion Model

    }
}









