using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL

    {
        /// <summary>
        /// doc_order:实体类(属性说明自动提取数据库字段的描述信息)
        /// </summary>
        [Serializable]
        public partial class doc_Order
        {
            public doc_Order()
            { }
            #region Model
            private Guid _guid;
            private Guid _t_stylecodeinfoguid;
            private DateTime? _theday;
            private string _cline;
            private string _cplan;
            private string _cdayp;
            private string _cdayf;
            private string _cfinish;
            private string _hline;
            private string _hplan;
            private string _hdayp;
            private string _hdayf;
            private string _hfinish;
            private string _sline;
            private string _splan;
            private string _sdayp;
            private string _sdayf;
            private string _sfinish;
            private string _lline;
            private string _lplan;
            private string _ldayp;
            private string _ldayf;
            private string _lfinish;
            private string _qline;
            private string _qplan;
            private string _qdayp;
            private string _qdayf;
            private string _qfinish;
            private string _wbuild;
            private string _wdayp;
            private string _wdayf;
            private string _wfinish;
            private string _wship;
            private string _wstock;
            private string _wlstock;
            private string _wmark;
            private string _ydayp;
            private string _ydayf;
            private string _yfinish;
            private string _ymark;
            private string _errormark;
            private string _errorcheck;
            private string _style;
            private string _color;
            private string _type;
            private string _cartonbarcodeneed;
            private string _aimarea;
            private string _name;
            private string _code;
            private string _goodstypename;
            private string _custombuyname;
            private string _customname;
            private string _customstylecode;
            private string _totalcount;
            private string _packlisttotalcount;
            private string _orderdate;
            private string _cutno;
            private DateTime? _shipmentdate;
            private string _proddate;
            private string _manufactureorder;
            private string _custompo;
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
            public DateTime? TheDay
            {
                set { _theday = value; }
                get { return _theday; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string CLine
            {
                set { _cline = value; }
                get { return _cline; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string CPlan
            {
                set { _cplan = value; }
                get { return _cplan; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string CDayP
            {
                set { _cdayp = value; }
                get { return _cdayp; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string CDayF
            {
                set { _cdayf = value; }
                get { return _cdayf; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string CFinish
            {
                set { _cfinish = value; }
                get { return _cfinish; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string HLine
            {
                set { _hline = value; }
                get { return _hline; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string HPlan
            {
                set { _hplan = value; }
                get { return _hplan; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string HDayP
            {
                set { _hdayp = value; }
                get { return _hdayp; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string HDayF
            {
                set { _hdayf = value; }
                get { return _hdayf; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string HFinish
            {
                set { _hfinish = value; }
                get { return _hfinish; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string SLine
            {
                set { _sline = value; }
                get { return _sline; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string SPlan
            {
                set { _splan = value; }
                get { return _splan; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string SDayP
            {
                set { _sdayp = value; }
                get { return _sdayp; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string SDayF
            {
                set { _sdayf = value; }
                get { return _sdayf; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string SFinish
            {
                set { _sfinish = value; }
                get { return _sfinish; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string LLine
            {
                set { _lline = value; }
                get { return _lline; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string LPlan
            {
                set { _lplan = value; }
                get { return _lplan; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string LDayP
            {
                set { _ldayp = value; }
                get { return _ldayp; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string LDayF
            {
                set { _ldayf = value; }
                get { return _ldayf; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string LFinish
            {
                set { _lfinish = value; }
                get { return _lfinish; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string QLine
            {
                set { _qline = value; }
                get { return _qline; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string QPlan
            {
                set { _qplan = value; }
                get { return _qplan; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string QDayP
            {
                set { _qdayp = value; }
                get { return _qdayp; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string QDayF
            {
                set { _qdayf = value; }
                get { return _qdayf; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string QFinish
            {
                set { _qfinish = value; }
                get { return _qfinish; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string WBuild
            {
                set { _wbuild = value; }
                get { return _wbuild; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string WDayP
            {
                set { _wdayp = value; }
                get { return _wdayp; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string WDayF
            {
                set { _wdayf = value; }
                get { return _wdayf; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string WFinish
            {
                set { _wfinish = value; }
                get { return _wfinish; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string WShip
            {
                set { _wship = value; }
                get { return _wship; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string WStock
            {
                set { _wstock = value; }
                get { return _wstock; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string WLStock
            {
                set { _wlstock = value; }
                get { return _wlstock; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Wmark
            {
                set { _wmark = value; }
                get { return _wmark; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string YDayP
            {
                set { _ydayp = value; }
                get { return _ydayp; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string YDayF
            {
                set { _ydayf = value; }
                get { return _ydayf; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string YFinish
            {
                set { _yfinish = value; }
                get { return _yfinish; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string YMark
            {
                set { _ymark = value; }
                get { return _ymark; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ErrorMark
            {
                set { _errormark = value; }
                get { return _errormark; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ErrorCheck
            {
                set { _errorcheck = value; }
                get { return _errorcheck; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Style
            {
                set { _style = value; }
                get { return _style; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Color
            {
                set { _color = value; }
                get { return _color; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Type
            {
                set { _type = value; }
                get { return _type; }
            }
        /// <summary>
        /// 
        /// </summary>
        public string CartonBarcodeNeed
        {
            set { _cartonbarcodeneed = value; }
            get { return _cartonbarcodeneed; }
        }




        /// <summary>
        /// 
        /// </summary>
        public string AimArea
            {
                set { _aimarea = value; }
                get { return _aimarea; }
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
            public string Code
            {
                set { _code = value; }
                get { return _code; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string GoodsTypeName
            {
                set { _goodstypename = value; }
                get { return _goodstypename; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string CustomBuyName
            {
                set { _custombuyname = value; }
                get { return _custombuyname; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string CustomName
            {
                set { _customname = value; }
                get { return _customname; }
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
            public string TotalCount
            {
                set { _totalcount = value; }
                get { return _totalcount; }
            }
        /// <summary>
        /// 
        /// </summary>
        public string Packlisttotalcount
        {
            set { _packlisttotalcount = value; }
            get { return _packlisttotalcount; }
        }











        /// <summary>
        /// 
        /// </summary>
        public string OrderDate
            {
                set { _orderdate = value; }
                get { return _orderdate; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string CutNo
            {
                set { _cutno = value; }
                get { return _cutno; }
            }
            /// <summary>
            /// 
            /// </summary>
            public DateTime? ShipMentDate
            {
                set { _shipmentdate = value; }
                get { return _shipmentdate; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string ProdDate
            {
                set { _proddate = value; }
                get { return _proddate; }
            }
        /// <summary>
        /// 
        /// </summary>
        public string ManufactureOrder
        {
            set { _manufactureorder = value; }
            get { return _manufactureorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomPO
        {
            set { _custompo = value; }
            get { return _custompo; }
        }














        #endregion Model

    }
    }


 