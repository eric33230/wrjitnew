using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{

        /// <summary>
        /// doc_StyleSize:实体类(属性说明自动提取数据库字段的描述信息)
        /// </summary>
        [Serializable]
        public partial class doc_StyleSize
        {
            public doc_StyleSize()
            { }
            #region Model
            private Guid _guid;
            private string _style;
            private string _stylebase;
            private string _orderdate;
            private string _section;
            private string _size;
            private string _boxsize;
            private decimal? _weight;
            private decimal? _range;
            private decimal? _l;
            private decimal? _w;
            private decimal? _h;
            private string _unit;
            private string _newcode;
            private string _name;
            /// <summary>
            /// 獲取訂單的尺碼,對應客戶型體 ,這裡面沒有name ,增加一個暫存
            /// </summary>
            public string Name
            {
                set { _name = value; }
                get { return _name; }
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
            public string OrderDate
            {
                set { _orderdate = value; }
                get { return _orderdate; }
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
            public string Size
            {
                set { _size = value; }
                get { return _size; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string BoxSize
            {
                set { _boxsize = value; }
                get { return _boxsize; }
            }
            /// <summary>
            /// 
            /// </summary>
            public decimal? Weight
            {
                set { _weight = value; }
                get { return _weight; }
            }
            /// <summary>
            /// 
            /// </summary>
            public decimal? Range
            {
                set { _range = value; }
                get { return _range; }
            }
            /// <summary>
            /// 
            /// </summary>
            public decimal? L
            {
                set { _l = value; }
                get { return _l; }
            }
            /// <summary>
            /// 
            /// </summary>
            public decimal? W
            {
                set { _w = value; }
                get { return _w; }
            }
            /// <summary>
            /// 
            /// </summary>
            public decimal? H
            {
                set { _h = value; }
                get { return _h; }
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
            public string NewCode
            {
                set { _newcode = value; }
                get { return _newcode; }
            }
            #endregion Model

        }
    }






