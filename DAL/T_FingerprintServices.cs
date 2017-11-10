using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class T_FingerprintServices
    {
        public int addfinger(fingerprint fps)
        {
            string sql = @"
INSERT dbo.T_Fingerprint
        ( guid ,
          ip ,
          port ,
          name ,
          dept ,
          house ,
          address ,
          note ,
          buydate ,
          buyname ,
          buyfone
        )
VALUES  ( @guid , 
          @ip, 
          @port, 
          @name,
          @dept, 
          @house, 
          @address, 
          @note, 
          @buydate , 
          @buyname , 
          @buyfone  
        );";
            SqlParameter[] sps =
              {
                       new SqlParameter("@guid",SqlDbType.UniqueIdentifier) {Value= fps.guid },
                       new SqlParameter("@ip",SqlDbType.NVarChar) {Value= fps.fip },
                       new SqlParameter("@port",SqlDbType.Int) {Value= fps.fport },
                       new SqlParameter("@name",SqlDbType.NVarChar) {Value= fps.fname },
                       new SqlParameter("@dept",SqlDbType.NVarChar) {Value= fps.fdetp },
                       new SqlParameter("@house",SqlDbType.NVarChar) {Value= fps.fhouse },
                       new SqlParameter("@address",SqlDbType.NVarChar) {Value= fps.faddress },
                       new SqlParameter("@note",SqlDbType.NVarChar) {Value= fps.fnote },
                       new SqlParameter("@buydate",SqlDbType.NVarChar) {Value= fps.fbuydate },
                       new SqlParameter("@buyname",SqlDbType.NVarChar) {Value= fps.fbuyname },
                       new SqlParameter("@buyfone",SqlDbType.NVarChar) {Value= fps.fbuyfone }
        };
             int count = SqlHelper.ExecuteNonQuery(sql, sps);            
            return count;
             
        }
        public DataTable getfplist( )
        {
            string sql = @"select * from T_Fingerprint;";
            DataTable tb = new DataTable();
            tb = SqlHelper.ExcuteTable(sql);
            return tb;

        }
        public int upfp(string mycolname, string mycolvalue, string myguid)
        {
            string sql = @"UPDATE dbo.T_Fingerprint SET "+mycolname+"='"+ mycolvalue +"' WHERE guid='"+ myguid + "';";
            int count = SqlHelper.ExecuteNonQuery(sql);
            return count;

        }
        public int  uploadtoserver(DataTable dt)
        {
            //DataTable dt = new DataTable();
            //dt.Columns.Add("guid",typeof(Guid));
            //dt.Columns.Add("userid",typeof(int));
            //dt.Columns.Add("data",typeof(DateTime));
            //dt.Columns.Add("fip",typeof(string));
            //foreach (var attlists in attlist)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["guid"] = attlists.guid;
            //    dr["userid"] = attlists.userid;
            //    dr["data"] = attlists.data;
            //    dr["fip"] = attlists.fip;
            //    dt.Rows.Add(dr);
            //}
           return SqlHelper.bulkattlist(dt);
        }
    }
}
