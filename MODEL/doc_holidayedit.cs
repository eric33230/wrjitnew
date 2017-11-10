using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MODEL
{
    
    /// <summary>
    /// doc_holidayedit:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class doc_holidayedit
    {
        public doc_holidayedit()
        { }
        #region Model
        private string _id;
        private DateTime? _addtime;
        private string _date;
        private string _explain;
        private string _time_f;
        private string _time_t;
        private int? _beover;
        /// <summary>
        /// 
        /// </summary>
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? addTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string explain
        {
            set { _explain = value; }
            get { return _explain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string time_f
        {
            set { _time_f = value; }
            get { return _time_f; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string time_t
        {
            set { _time_t = value; }
            get { return _time_t; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? beover
        {
            set { _beover = value; }
            get { return _beover; }
        }
        #endregion Model

    }
}

