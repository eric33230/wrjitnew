using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// doc_calendar:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class doc_calendar
    {
        public doc_calendar()
        { }
        #region Model
        private DateTime _date;
        private string _year;
        private int _month;
        private int _day;
        private int _weekday;
        private int _week;
        private int? _worktime;
        private int? _basetime;
        private string _explain;
        private int? _planstr;
        private int _isholiday;
        /// <summary>
        /// 
        /// </summary>
        public DateTime date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string year
        {
            set { _year = value; }
            get { return _year; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int month
        {
            set { _month = value; }
            get { return _month; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int day
        {
            set { _day = value; }
            get { return _day; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int weekday
        {
            set { _weekday = value; }
            get { return _weekday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int week
        {
            set { _week = value; }
            get { return _week; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? worktime
        {
            set { _worktime = value; }
            get { return _worktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? basetime
        {
            set { _basetime = value; }
            get { return _basetime; }
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
        public int? planstr
        {
            set { _planstr = value; }
            get { return _planstr; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int isholiday
        {
            set { _isholiday = value; }
            get { return _isholiday; }
        }
        #endregion Model

    }
}

