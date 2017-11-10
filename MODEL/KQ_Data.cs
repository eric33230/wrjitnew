using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// KQ_Data:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KQ_Data
    {
        public KQ_Data()
        { }
        #region Model
        private Guid _guid;
        private DateTime? _kqtime;
        private int? _enrollno;
        private string _machine;
        private string _timeno;
        private string _empid;
        private string _khname;
        private string _kqdate;
        private decimal? _aid;

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
        public DateTime? KQTime
        {
            set { _kqtime = value; }
            get { return _kqtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EnrollNo
        {
            set { _enrollno = value; }
            get { return _enrollno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Machine
        {
            set { _machine = value; }
            get { return _machine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TimeNO
        {
            set { _timeno = value; }
            get { return _timeno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmpID
        {
            set { _empid = value; }
            get { return _empid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AID
        {
            set { _aid = value; }
            get { return _aid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KhName
        {
            set { _khname = value; }
            get { return _khname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string KQDate
        {
            set { _kqdate = value; }
            get { return _kqdate; }
        }






        #endregion Model





    }
}


