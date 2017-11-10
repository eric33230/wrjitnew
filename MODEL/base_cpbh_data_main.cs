using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{

        /// <summary>
        /// base_cpbh_data_main:实体类(属性说明自动提取数据库字段的描述信息)
        /// </summary>
        [Serializable]
        public partial class base_cpbh_data_main
        {
            public base_cpbh_data_main()
            { }
            #region Model
            private string _id;
            private string _shosety;
            private string _cpbhty;
            private string _cpbh;
            private string _colorcode;
            private string _khph;
            private string _rb;
            private string _md;
            private string _last;
            private string _newflag;
            private string _mack;
            private string _days;
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
            public string shosety
            {
                set { _shosety = value; }
                get { return _shosety; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string cpbhty
            {
                set { _cpbhty = value; }
                get { return _cpbhty; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string cpbh
            {
                set { _cpbh = value; }
                get { return _cpbh; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string colorcode
            {
                set { _colorcode = value; }
                get { return _colorcode; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string khph
            {
                set { _khph = value; }
                get { return _khph; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string rb
            {
                set { _rb = value; }
                get { return _rb; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string md
            {
                set { _md = value; }
                get { return _md; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string last
            {
                set { _last = value; }
                get { return _last; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string newflag
            {
                set { _newflag = value; }
                get { return _newflag; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string mack
            {
                set { _mack = value; }
                get { return _mack; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string days
            {
                set { _days = value; }
                get { return _days; }
            }
            #endregion Model

        }
    }

