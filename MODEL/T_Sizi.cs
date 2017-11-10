using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITSystem.Model
{
    public class T_Sizi
    { 
        public Guid guid { set; get; }
        public Guid T_StyleCodeInfoGuid { set; get; }
        public string DocTreeID { set; get; }
        public string CustomStyleCode { set; get; }
        public string SizeID { set; get; }
        public string Size { set; get; }
        public string Ccount { set; get; }
    }
}
