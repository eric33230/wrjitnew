using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MODEL
{
    class progressbar
    {
    }
    public class Secont : INotifyPropertyChanged
    {
        private double ellapsedSec;
        public double EllapsedSec
        {
            get
            {
                return ellapsedSec;
            }
            set
            {
                this.ellapsedSec = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("EllapsedSec"));
                }
            }
        }
        private double countSec;
        public double CountSec
        {
            get
            {
                return countSec;
            }
            set
            {
                this.countSec = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CountSec"));

                }
            }
        }

        private int value;
        public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));

                }
            }
        }
        private int zvalue;
        public int ZValue
        {
            get
            {
                return zvalue;
            }
            set
            {
                this.zvalue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ZValue"));

                }
            }
        }

        private int linesCount;
        public int LinesCount
        {
            get
            {
                return linesCount;
            }
            set
            {
                this.linesCount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LinesCount"));

                }
            }
        }

        private string log;
        public string Log
        {
            get
            {
                return log;
            }
            set
            {
                this.log = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Log"));

                }
            }
        }


        

        private string iGLCount;
        public string IGLCount
        {
            get
            {
                return iGLCount;
            }
            set
            {
                this.iGLCount = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IGLCount"));

                }
            }
        }
        private string sdwEnrollNumber;

        public string SdwEnrollNumber
        {
            get
            {
                return sdwEnrollNumber;
            }
            set
            {
                this.sdwEnrollNumber = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SdwEnrollNumber"));

                }
            }
        }
        private string data;
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                this.data = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Data"));

                }
            }
        }
        private string sip;
        public string Sip
        {
            get
            {
                return sip;
            }
            set
            {
                this.sip = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Sip"));

                }
            }
        }
        private string result;
        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                this.result = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Result"));

                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    
}
