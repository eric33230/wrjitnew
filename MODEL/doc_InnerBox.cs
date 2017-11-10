using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace MODEL
{
    /// <summary>
    /// InnerBox:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public  class doc_InnerBox
    {
        public doc_InnerBox()
        { }    
            #region Model
            private Guid _guid;
        private string _customname;
            private string _innerbarcode;
            private string _stylecode;
            private string _name;
            private string _style;
            private string _color;
            private string _size;
            private string _type;
            private string _newcode;
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
        public string CustomName 
        {
            set { _customname = value; }
            get { return _customname; }
        }








        /// <summary>
        /// 
        /// </summary>
        public string InnerBarcode
            {
                set { _innerbarcode = value; }
                get { return _innerbarcode; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string StyleCode
            {
                set { _stylecode = value; }
                get { return _stylecode; }
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
            public string Size
            {
                set { _size = value; }
                get { return _size; }
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
            public string NewCode
            {
                set { _newcode = value; }
                get { return _newcode; }
            }
            #endregion Model

        }
    }


