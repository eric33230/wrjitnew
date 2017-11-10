using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// doc_StyleBase:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
        public partial class doc_StyleBase
        {
            public doc_StyleBase()
            { }
            #region Model
            private Guid _guid;
            private string _style;
            private string _stylebase;
            private string _customname;
            private string _goodstypename;
            private string _name;
            private string _modelno;
            private string _rbcode;
            private string _mdcode;
            private string _editionhandle;
            private string _innor;
            private string _orderdate;
            private string _newcode;
            private string _hourqty;
        private string _customnames;

        /// <summary>
        /// 
        /// </summary>
        public string CustomNameS
        {
            set { _customnames = value; }
            get { return _customnames; }
        }





        /// <summary>
        /// 
        /// </summary>
        public string HourQty
        {
            set { _hourqty = value; }
            get { return _hourqty; }
        }
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
            public string Style
            {
                set { _style = value; }
                get { return _style; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string StyleBase
        {
                set { _stylebase = value; }
                get { return _stylebase; }
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
            public string GoodsTypeName
            {
                set { _goodstypename = value; }
                get { return _goodstypename; }
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
            public string ModelNo
            {
                set { _modelno = value; }
                get { return _modelno; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string RBcode
            {
                set { _rbcode = value; }
                get { return _rbcode; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string MDcode
            {
                set { _mdcode = value; }
                get { return _mdcode; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Editionhandle
            {
                set { _editionhandle = value; }
                get { return _editionhandle; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Innor
            {
                set { _innor = value; }
                get { return _innor; }
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
            public string NewCode
            {
                set { _newcode = value; }
                get { return _newcode; }
            }
            #endregion Model

        }
    }

