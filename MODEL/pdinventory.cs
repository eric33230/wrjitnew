using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class pdinventory
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string CustomStyleCode { get; set; }
        public string OrderDate { get; set; }
        public int? BOXNO { get; set; }
        public string CartonBarcode { get; set; }
        public string WH { get; set; }
        public int PDScan1 { get; set; }
        public string PDScan1Time { get; set; }
        public int PDScan2 { get; set; }
        public string PDScan2Time { get; set; }
        public int PDScan3 { get; set; }
        public string PDScan3Time { get; set; }
    }
}
