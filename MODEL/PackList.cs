using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    public class PackList
    {
        public Guid guid { get; set; } //PO NO
        public string CustomName { get; set; }
        public string GoodsTypeEnName { get; set; }

        public string CustomStyleName { get; set; }

        public string CustomStyleCode { get; set; }

        public string SizeName { get; set; }
        public string TotalCount { get; set; }
        public string CutNo { get; set; } //PO NO
        public string ManufactureOrder { get; set; } //LOT NO ORD / NO
        public string CustomPO { get; set; } //訂單號
        public string ColorGroupName { get; set; } //COLOR
        public string BoxSize { get; set; } //外箱規格
        public int? BoxNoTotal { get; set; } //CTN
        public int? PerCount { get; set; } //PRS/CTNS
        public int perCountTotal { get; set; } //TOTAL/PRS
        public double? NW { get; set; } //N.W
        public double? TNW { get; set; } //T/N.W
        public double? GW { get; set; } //G.W
        public double? TGW { get; set; } //T/G.W
        public double? BoxVolume { get; set; } //CBM
        public double? MT { get; set; } //M/T
        public string BOXTONO { get; set; } //C/NO
        public string BOXNO { get; set; }//箱号

        public int? Totsumcount { get; set; }//指令数量
        public int? Boxsumcount { get; set; }//总箱数量
        public string OrderDate { get; set; }//订单年月
    }
}
