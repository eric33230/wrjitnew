using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinForm
{
    public class AboutMenu
    {
        public class TextAndValue
        {
            private string _RealValue = "";
            private string _DisplayText = "";

            public string DisplayText
            {
                get
                {
                    return _DisplayText;
                }
            }

            public string RealValue
            {
                get
                {
                    return _RealValue;
                }
            }

            public TextAndValue(string ShowText, string RealVal)
            {
                _DisplayText = ShowText;
                _RealValue = RealVal;
            }

            public override string ToString()
            {
                return _RealValue.ToString();
            }

        }
    }
}
