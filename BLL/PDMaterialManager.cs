using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PDMaterialManager
    {
        PDMaterialService pds = new PDMaterialService();
        public List<string> getMaterialClass()
        {

            return pds.getMaterialClass();
        }
        public DataTable getMaterialall(List<WhereModeHelp> wherestrs)
        {
            return pds.getMaterialall(wherestrs);

        }
    }
}
