using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{

        /// <summary>
        /// doc_Style:实体类(属性说明自动提取数据库字段的描述信息)
        /// </summary>
        [Serializable]
        public partial class doc_Style
        {
            public doc_Style()
            { }
            #region Model
            private Guid _guid;
            private string _code;
            private string _style;
            private string _orderdate;
            private string _color;
        private byte[] _image;
        private string _newcode;

        ///   private string _size;// 多增加一個虛擬字段,可以利用它檢查訂單年月的style, stylesize, innerbox 寫入NewCode 用以辨識需要填充資料
        /// private string _name;// 多增加一個虛擬字段,可以利用它檢查訂單年月的style, stylesize, innerbox 寫入NewCode 用以辨識需要填充資料
        /// private string _customname;// 多增加一個虛擬字段,可以利用它檢查訂單年月的style, stylesize, innerbox 寫入NewCode 用以辨識需要填充資料

            /*
        /// <summary>
        /// 多增加一個虛擬字段,可以利用它檢查訂單年月的style, stylesize, innerbox 寫入NewCode 用以辨識需要填充資料
        /// </summary>
        
        public string Size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 多增加一個虛擬字段,可以利用它檢查訂單年月的style, stylesize, innerbox 寫入NewCode 用以辨識需要填充資料
        /// </summary>
        public string Name
        {
            set { _name= value; }
            get { return _name; }
        }
        /// <summary>
        /// 多增加一個虛擬字段,可以利用它檢查訂單年月的style, stylesize, innerbox 寫入NewCode 用以辨識需要填充資料
        /// </summary>
        public string CustomName
        {
            set { _customname = value; }
            get { return _customname; }
        }
        
    */

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
            public string Code
            {
                set { _code = value; }
                get { return _code; }
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
            public string OrderDate
            {
                set { _orderdate = value; }
                get { return _orderdate; }
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
        public byte[] Image
        {
            set { _image = value; }
            get { return _image; }
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

