using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PdinventoryService
    {
        public List<string> getwarehouse()
        {
            string sql = @"SELECT DISTINCT SUBSTRING(WH,1,3) WH    FROM dbo.doc_PackListShipScan";
            DataTable dt= SqlHelper.ExcuteTable(sql);
            List<string> lists = new List<string>();
            if (dt.Rows.Count>0)
            {
                string wh = "";
                for (int i=0;i<dt.Rows.Count;i++)
                {
                    wh = dt.Rows[i]["WH"].ToString();
                    lists.Add(wh);
                }
            }

            return lists;
        }
        public DataTable getcustomstyle(List<string> strkey, List<string> strvalue)
        {
            string wherestr = "";
            if(strkey.Count>0 && strvalue.Count > 0)
            {
                for(int i = 0; i < strkey.Count; i++)
                {
                    if (strkey[i].Equals("WH"))
                    {
                        if (strvalue[i].Equals("ALL"))
                        {

                            strvalue[i] = " ";
                        }
                        else if (strvalue[i].Equals("NOWH"))
                        {
                            strvalue[i] = " ( p.WH = '' ) and";
                        }else{
                            strvalue[i] = " ( p.WH = '" + strvalue[i] + "' ) and";

                        }
                    }

                    if (strkey[i].Equals("CustomStyleCode"))
                    {
                        strvalue[i] = " p.CustomStyleCode = '" + strvalue[i] + "' and ";
                        wherestr = strvalue[i];
                    }
                    if (strkey[i].Equals("style"))
                    {
                        strvalue[i] = " p.style = '" + strvalue[i] + "' and ";
                        wherestr = strvalue[i];
                    }
                    if (strkey[i].Equals("OrderDate"))
                    {
                        strvalue[i] = " p.OrderDate  BETWEEN '" + strvalue[i] + "' and '" + strvalue[i+1] + "' and ";
                        wherestr = wherestr + strvalue[i];
                        break;
                    }


                    wherestr = wherestr + strvalue[i]  ;
                }
               
            }

            string sql = @"SELECT  p.CustomName ,
                                    p.name,
                                p.Code ,
                                p.CustomStyleCode ,
                                p.OrderDate ,
                                p.CartonBarcode ,
                               
                                p.WH ,
                                p.BOXNO ,
                                p.ScanIn ,
                                p.ScanOut ,
                                p.ShipOut,
	 	                        p1.Boxsumcount,
		                        ts.TotalCount 
                        FROM    dbo.doc_PackListShip p
                                 LEFT JOIN ( SELECT  MAX(BOXNO) Boxsumcount ,
                                                            CustomStyleCode
                                                    FROM    doc_PackListShip
                                                    GROUP BY CustomStyleCode
                                                  ) p1 ON p.CustomStyleCode = p1.CustomStyleCode
                           
		                        LEFT JOIN T_StyleCodeInfo ts ON p.CustomStyleCode = ts.CustomStyleCode
                         WHERE  " + wherestr + @"
                                 ( p.ShipOut != '1'
                                      OR p.ShipOut IS NULL
                                    )
                                AND p.ScanIn != p.ScanOut
                        GROUP BY p.CustomName ,
                                p.Code ,
                                p.CustomStyleCode ,
                                p.OrderDate ,
                                p.CartonBarcode ,
                                p.name,
                                p.WH,
                                p.BOXNO ,
                                p.ScanIn ,
                                p.ScanOut ,
                                p.ShipOut,
	 	                      p1.Boxsumcount,
		                        ts.TotalCount 
                        ORDER BY p.CustomStyleCode ,
                                p.BOXNO";            
           
            // SqlHelper.ExecuteNonQuery(sql);

            DataTable dt = SqlHelper.ExcuteTable(sql);
            
            return dt;
        }

       public DataTable getBoxAllbyCartonBarcode(string CustomStyleCode,string wherestr)
        {
            wherestr = wherestr.Remove(wherestr.LastIndexOf("or"),2);
            string sql = @"
                SELECT  CartonBarcode,
                        SizeName ,
                        SUM(CONVERT(INT, TotalCount)) sumcount
                        
                       
                FROM    dbo.doc_PackList
                WHERE   CustomStyleCode = '" + CustomStyleCode + @"'
                        AND ( "+ wherestr +@")
                GROUP BY SizeName ,
                        CartonBarcode
                ORDER BY CartonBarcode;";
           //SqlHelper.ExecuteNonQuery(sql);

            DataTable dt = SqlHelper.ExcuteTable(sql);

            return dt;
            
        }
        public DataTable getnopdboxno(string CustomStyleCode)
        {
            string sql = @"SELECT DISTINCT CartonBarcode ,
                                BOXNO
                        FROM    dbo.doc_PackList
                        WHERE   CustomStyleCode = '"+ CustomStyleCode + @"'
                        EXCEPT

                        SELECT  p.CartonBarcode ,
                                p.BOXNO
                        FROM    dbo.doc_PackListShip p
                        WHERE p.CustomStyleCode = '"+ CustomStyleCode + @"'
                                AND(p.ShipOut != '1'
                                      OR p.ShipOut IS NULL
                                    )
                                AND p.ScanIn != p.ScanOut
                        ORDER BY BOXNO
                     ";
            DataTable dt = SqlHelper.ExcuteTable(sql);

            return dt;
        }

        public int  updwhs(string whs,string customstylecode)
        {
            string sql = "";
            if(whs== "NOWH")
            {
                 sql = @"UPDATE dbo.doc_PackListShip SET 
                           WH='' WHERE CustomStyleCode='" + customstylecode + "'";
            }
            else
            {
                sql = @"UPDATE dbo.doc_PackListShip SET 
                           WH='" + whs + @"' WHERE CustomStyleCode='" + customstylecode + "'";
            }
             
           return SqlHelper.ExecuteNonQuery(sql);

        }
        public List<pdinventory> getpdfiletotxt(string whs )
        {

            string sql = @"
                             SELECT Code ,
                                    Name ,
                                    CustomStyleCode ,
                                    OrderDate ,
                                    BOXNO ,
                                    CartonBarcode ,
                                    WH ,
                                    ISNULL(PDScan1, '0') PDScan1 ,
                                    PDScan1Time ,
                                    ISNULL(PDScan2, '0') PDScan2 ,
                                    PDScan2Time ,
                                    ISNULL(PDScan3, '0') PDScan3 ,
                                    PDScan3Time
                             FROM   dbo.doc_PackListShip
                             WHERE  WH='" + whs + @"'
                                    AND (ShipOut=0  OR ShipOut IS NULL)
                                    AND ScanIn != ScanOut
                             ORDER BY CustomStyleCode ,
                                    BOXNO";
            DataTable dt = SqlHelper.ExcuteTable(sql);
            List<pdinventory> lists = null;
            if (dt.Rows.Count > 0)
            {
                lists = new List<pdinventory>();
                foreach (DataRow row in dt.Rows)
                {
                    pdinventory c = new pdinventory();
                    LoadPDDataToList(row, c);
                    lists.Add(c);
                }
            }
            return lists;           

        }
        public void LoadPDDataToList(DataRow dr, pdinventory pdlist)
        {
            pdlist.Code = (string)SqlHelper.FromDbValue(dr["Code"]); // 
            pdlist.Name = (string)SqlHelper.FromDbValue(dr["Name"]);  //   訂單號
            pdlist.CustomStyleCode = (string)SqlHelper.FromDbValue(dr["CustomStyleCode"]); // 
            pdlist.OrderDate = (string)SqlHelper.FromDbValue(dr["OrderDate"]);//
            pdlist.BOXNO = (int)SqlHelper.FromDbValue(dr["BOXNO"]);   //
            pdlist.CartonBarcode = (string)SqlHelper.FromDbValue(dr["CartonBarcode"]);
            pdlist.WH = (string)SqlHelper.FromDbValue(dr["WH"]);//
            pdlist.PDScan1 = (int)SqlHelper.FromDbValue(dr["PDScan1"]);//
            pdlist.PDScan1Time = (string)SqlHelper.FromDbValue(dr["PDScan1Time"]);//
            pdlist.PDScan2 = (int)SqlHelper.FromDbValue(dr["PDScan2"]);//
            pdlist.PDScan2Time = (string)SqlHelper.FromDbValue(dr["PDScan2Time"]);//
            pdlist.PDScan3 = (int)SqlHelper.FromDbValue(dr["PDScan3"]);//
            pdlist.PDScan3Time = (string)SqlHelper.FromDbValue(dr["PDScan3Time"]);//
        }
    }
}
