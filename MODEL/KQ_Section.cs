using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// KQ_Section:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KQ_Section
    {
        public KQ_Section()
        { }
        #region Model
        private int _no;
        private string _groupno;
        private string _name;
        private string _kname;
        private string _section;
        private string _dayf;
        private int _hourf;
        private int _minf;
        private string _dayt;
        private int _hourt;
        private int _mint;
        private int _hourfstd;
        private int _minfstd;
        private int _hourtstd;
        private int _mintstd;





        /// <summary>
        /// 
        /// </summary>
        public int No
        {
            set { _no = value; }
            get { return _no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GroupNo
        {
            set { _groupno = value; }
            get { return _groupno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Kname
        {
            set { _kname = value; }
            get { return _kname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Section
        {
            set { _section = value; }
            get { return _section; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DayF
        {
            set { _dayf = value; }
            get { return _dayf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int HourF
        {
            set { _hourf = value; }
            get { return _hourf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MinF
        {
            set { _minf = value; }
            get { return _minf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DayT
        {
            set { _dayt = value; }
            get { return _dayt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int HourT
        {
            set { _hourt = value; }
            get { return _hourt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MinT
        {
            set { _mint = value; }
            get { return _mint; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int HourFSTD
        {
            set { _hourfstd = value; }
            get { return _hourfstd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MinFSTD
        {
            set { _minfstd = value; }
            get { return _minfstd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int HourTSTD
        {
            set { _hourtstd = value; }
            get { return _hourtstd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MinTSTD
        {
            set { _mintstd = value; }
            get { return _mintstd; }
        }
        #endregion Model
    }
}

