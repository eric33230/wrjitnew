using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace BLL
{
    public class T_Fingerprint
    {
        T_FingerprintServices fp = new T_FingerprintServices();
        public int addfp(fingerprint fps)
        {
            return fp.addfinger(fps);
         
        }
        public DataTable getfplist()
        {
            return fp.getfplist();

        }
        public int upfp(string mycolname, string mycolvalue, string  myguid)
        {
            return fp.upfp(mycolname, mycolvalue, myguid);
        }
        public int  uploadtoserver(DataTable dt)
        {
            return fp.uploadtoserver(dt);
        }
    }
}
