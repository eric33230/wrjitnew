using JITSystem.DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace JITSystem.BLL
{
    public class T_StyleCodeInfoBLL
    {
        public T_StyleCodeInfo[] GetStyleCodeInfos(List<string> whereList, List<string> whereListText, string type)
        {
            T_StyleCodeInfoDAL StyleCodeInfodal = new T_StyleCodeInfoDAL();

            //先找本地庫的
            T_StyleCodeInfo[] StyleCodeInfos = StyleCodeInfodal.GetT_StyleCodeInfo(whereList, whereListText, type);

            //if (StyleCodeInfos.Length <= 0)
            //{
            //    //找ERP數據庫里的
            //     StyleCodeInfos = StyleCodeInfodal.GetT_StyleCodeInfo(whereList, whereListText, type);
            //}
            return StyleCodeInfos;
        }
        public DataTable GetT_StyleCodeSizeRun(string DocTreeID, string osmDocTreeID)
        {
            T_StyleCodeInfoDAL StyleCodeInfodal = new T_StyleCodeInfoDAL();

            DataTable SizeRunTable = StyleCodeInfodal.GetT_StyleCodeSizeRun(DocTreeID, osmDocTreeID);
            return SizeRunTable;
        }
        public byte[] getPhoto(string DocTreeID)
        {
            T_StyleCodeInfoDAL StyleCodeInfodal = new T_StyleCodeInfoDAL();

            byte[] imgBytes = StyleCodeInfodal.getPhoto(DocTreeID);
            return imgBytes;
        }


        public void updataFromDV(T_StyleCodeInfo dvsytleinfo, Guid guid)
        {
            T_StyleCodeInfoDAL StyleCodeInfodal = new T_StyleCodeInfoDAL();
            //int t = 0;
            //t = StyleCodeInfodal.GetCountByosmDocTreeID(dvsytleinfo.CustomStyleCode);
            //if (t == 0)
            //{
            StyleCodeInfodal.updataFromDV(dvsytleinfo, guid);
            //}
        }
        public void updataFromsinfoDV(T_StyleCodeInfo dvsytleinfo, string guid)
        {
            T_StyleCodeInfoDAL StyleCodeInfodal = new T_StyleCodeInfoDAL();
            //int t = 0;
            //t = StyleCodeInfodal.GetCountByosmDocTreeID(dvsytleinfo.CustomStyleCode);
            //if (t == 0)
            //{
            StyleCodeInfodal.updataFromsinfoDV(dvsytleinfo, guid);
            //}
        }
        public string GetCountByosmDocTreeID(string CustomStyleCode)
        {
            T_StyleCodeInfoDAL StyleCodeInfodal = new T_StyleCodeInfoDAL();
            string guid = StyleCodeInfodal.GetCountByosmDocTreeID(CustomStyleCode);
            return guid;
            //  if (t == 0)
            // {
            //   StyleCodeInfodal.updataFromDV(dvsytleinfo, guid);
            //  }
        }

        public void updataFromSize(string infoguid, string osmDocTreeID)
        {
            T_StyleCodeInfoDAL StyleCodeInfodal = new T_StyleCodeInfoDAL();
            Guid guid = new Guid(infoguid);
            T_Sizi[] SizeRun = StyleCodeInfodal.GetSizeRun(osmDocTreeID, guid);
            for (int i = 0; i < SizeRun.Count(); i++)
            {
                //  int t=0;
                //  t = StyleCodeInfodal.GetCountByosmDocTreeID(osmDocTreeID, SizeRun[i].SizeID);
                //  if (t == 0)
                // {
                StyleCodeInfodal.updataFromSizeRun(SizeRun[i]);
                //  }



                //Guid guid = Guid.NewGuid();
                //Guid T_StyleCodeInfoGuid = SizeRun[i].T_StyleCodeInfoGuid;
                //string DocTreeID = SizeRun[i].DocTreeID;
                //string CustomStyleCode = SizeRun[i].CustomStyleCode;
                //string SizeID = SizeRun[i].SizeID;
                //string Size = SizeRun[i].Size;
                //string Ccount = SizeRun[i].Ccount 
            }
            //创建本地表
            //DataTable table = new DataTable();
            //table.Columns.Add("Guid", typeof(SqlGuid));
            //table.Columns.Add("T_StyleCodeInfoGuid", typeof(SqlGuid));
            //table.Columns.Add("DocTreeID");
            //table.Columns.Add("CustomStyleCode");
            //table.Columns.Add("SizeID");
            //table.Columns.Add("Size");
            //table.Columns.Add("Ccount");

            //for (int i = 1; i < SizeRun.Count(); i++)
            //{

            //    Guid guid = Guid.NewGuid();
            //    Guid T_StyleCodeInfoGuid = SizeRun[i].T_StyleCodeInfoGuid;
            //    string DocTreeID = SizeRun[i].DocTreeID;
            //    string CustomStyleCode = SizeRun[i].CustomStyleCode;
            //    string SizeID = SizeRun[i].SizeID;
            //    string Size = SizeRun[i].Size;
            //    string Ccount = SizeRun[i].Ccount;


            //    ////本地表加入数据  Unique
            //    DataRow row = table.NewRow();
            //    row["Guid"] = guid;
            //    row["T_StyleCodeInfoGuid"] = T_StyleCodeInfoGuid;
            //    row["DocTreeID"] = DocTreeID;
            //    row["CustomStyleCode"] = CustomStyleCode;
            //    row["SizeID"] = SizeID;
            //    row["Size"] = Size;
            //    row["Ccount"] = Ccount;
            //    table.Rows.Add(row);


            //    StyleCodeInfodal.sqlbulkcopy(table);

            //}
        }
        public DataTable GetT_Size(string CustomStyleCode)
        {
            T_StyleCodeInfoDAL StyleCodeInfodal = new T_StyleCodeInfoDAL();

            DataTable SizeRunTable = StyleCodeInfodal.GetT_Size(CustomStyleCode);
            return SizeRunTable;
        }
    }
}
