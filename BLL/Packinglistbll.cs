using JITSystem.DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITSystem.BLL
{
    public class Packinglistbll
    {
        public DataTable getPacking(string CustomStyleCode)
        {
            Packinglistdal pk = new Packinglistdal();
            return pk.getPacking(CustomStyleCode);

        }

        public DataTable getCustomstr(string wherestr)
        {
            Packinglistdal pk = new Packinglistdal();
            return pk.getCustomstr(wherestr);

        }
        public DataTable getBox(string BatchOrderBoxID)
        {
            Packinglistdal pk = new Packinglistdal();
            return pk.getBox(BatchOrderBoxID);

        }
        public DataTable getboxPkFromDB(string StyleCode)
        {
            Packinglistdal pk = new Packinglistdal();
            return pk.getboxPkFromDB(StyleCode);

        }


        public byte[] getPhoto(string StyleCode)
        {
            Packinglistdal pk = new Packinglistdal();
            byte[] imgBytes = pk.getPhoto(StyleCode);
            return imgBytes;
        }
        public void pkUpDb(PackList pk)
        {
            Packinglistdal pkdll = new Packinglistdal();
            pkdll.pkUpDb(pk);
        }
        public void pkUpDb(PackList pk, string guid)
        {
            Packinglistdal pkdll = new Packinglistdal();
            pkdll.pkUpDb(pk, guid);
        }
        public DataTable getCodeFromPackList(string CustomStyleCode)
        {
            Packinglistdal pkdll = new Packinglistdal();
            return pkdll.getCodeFromPackList(CustomStyleCode);

        }
        public void delCodeFromPackList(string CustomStyleCode)
        {
            Packinglistdal pkdll = new Packinglistdal();
               pkdll.delCodeFromPackList(CustomStyleCode);

        }

        public void pkboxUpDb(packlistbox pkbox)
        {
            Packinglistdal pkdll = new Packinglistdal();
            pkdll.pkboxUpDb(pkbox);
        }
        public void MTphotoUpDb(byte[] picMTphoto, string CoutomCode)
        {
            Packinglistdal pkdll = new Packinglistdal();
            pkdll.MTphotoUpDb(picMTphoto, CoutomCode);
        }
        public void MTphotoUpDbByguid(byte[] picMTphoto, string guid)
        {
            Packinglistdal pkdll = new Packinglistdal();
            pkdll.MTphotoUpDbByguid(picMTphoto, guid);
        }
        public DataTable getMTphoto(string CoutomCode)
        {
            Packinglistdal pkdll = new Packinglistdal();
            return pkdll.getMTphoto(CoutomCode);
        }

        public DataTable pkGetDb(string CustomStyleCode)
        {
            Packinglistdal pkdll = new Packinglistdal();

            return pkdll.pkGetDb(CustomStyleCode);
        }
    }
}
