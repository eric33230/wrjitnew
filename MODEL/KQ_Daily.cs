using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL

{
    /// <summary>
    /// KQ_Daily:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class KQ_Daily
    {
        public KQ_Daily()
        { }
        #region Model
        private Guid _guid;
        private string _machine;
        private string _empid;
        private string _khname;

        private string _enrollno;

        private string _aid;
        private string _unit;

        private string _kqdate;
        private string _whour;
        private string _ohour;
        private string _lmin1;
        private string _emin3;
        private string _lmin2;
        private string _emin2;

        private string _ws;
        private string _sj;
        private string _kg;
        private string _wc;
        private string _bx;
        private string _bk;
        private string _bg;
        private string _gk;
        private string _gg;
        private string _hj;
        private string _dj;
        private string _y3;
        private string _nj;
        private string _kd;
        private string _tb;
        private string _cc;
        private string _cj;
        private string _pr;

        private DateTime? _kqtime;
        private DateTime? _kqtime1;
        private DateTime? _kqtime2;
        private DateTime? _kqtime3;
        private DateTime? _kqout1;
        private DateTime? _kqout2;
        private DateTime? _kqout3;
        private DateTime? _kqout4;
        private DateTime? _kqout5;
        private DateTime? _kqout6;
        private DateTime? _kqout7;
        private DateTime? _kqout8;


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
        public string Machine
        {
            set { _machine = value; }
            get { return _machine; }
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
        public string KhName
        {
            set { _khname = value; }
            get { return _khname; }
        }




        /// <summary>
        /// 
        /// </summary>
        public string EnrollNo
        {
            set { _enrollno = value; }
            get { return _enrollno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AID
        {
            set { _aid = value; }
            get { return _aid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
        }



        /// <summary>
        /// 
        /// </summary>
        public string KQDate
        {
            set { _kqdate = value; }
            get { return _kqdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WHour
        {
            set { _whour = value; }
            get { return _whour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OHour
        {
            set { _ohour = value; }
            get { return _ohour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LMin1
        {
            set { _lmin1 = value; }
            get { return _lmin1; }
        }


        /// <summary>
        /// 
        /// </summary>
        public string EMin3
        {
            set { _emin3 = value; }
            get { return _emin3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LMin2
        {
            set { _lmin2 = value; }
            get { return _lmin2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMin2
        {
            set { _emin2 = value; }
            get { return _emin2; }
        }









        /// <summary>
        /// 
        /// </summary>
        public string WS
        {
            set { _ws = value; }
            get { return _ws; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SJ
        {
            set { _sj = value; }
            get { return _sj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KG
        {
            set { _kg = value; }
            get { return _kg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WC
        {
            set { _wc = value; }
            get { return _wc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BX
        {
            set { _bx = value; }
            get { return _bx; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BK
        {
            set { _bk = value; }
            get { return _bk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BG
        {
            set { _bg = value; }
            get { return _bg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GK
        {
            set { _gk = value; }
            get { return _gk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GG
        {
            set { _gg = value; }
            get { return _gg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HJ
        {
            set { _hj = value; }
            get { return _hj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DJ
        {
            set { _dj = value; }
            get { return _dj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Y3
        {
            set { _y3 = value; }
            get { return _y3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NJ
        {
            set { _nj = value; }
            get { return _nj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KD
        {
            set { _kd = value; }
            get { return _kd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TB
        {
            set { _tb = value; }
            get { return _tb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CC
        {
            set { _cc = value; }
            get { return _cc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CJ
        {
            set { _cj = value; }
            get { return _cj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PR
        {
            set { _pr = value; }
            get { return _pr; }
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
        public DateTime? KQTime1
        {
            set { _kqtime1 = value; }
            get { return _kqtime1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KQTime2
        {
            set { _kqtime2 = value; }
            get { return _kqtime2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KQTime3
        {
            set { _kqtime3 = value; }
            get { return _kqtime3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KQOut1
        {
            set { _kqout1 = value; }
            get { return _kqout1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KQOut2
        {
            set { _kqout2 = value; }
            get { return _kqout2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KQOut3
        {
            set { _kqout3 = value; }
            get { return _kqout3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KQOut4
        {
            set { _kqout4 = value; }
            get { return _kqout4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KQOut5
        {
            set { _kqout5 = value; }
            get { return _kqout5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KQOut6
        {
            set { _kqout6 = value; }
            get { return _kqout6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KQOut7
        {
            set { _kqout7 = value; }
            get { return _kqout7; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? KQOut8
        {
            set { _kqout8 = value; }
            get { return _kqout8; }
        }
        #endregion Model

    }
}


