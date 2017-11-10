using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class PDMaterialService
    {
        public List<string> getMaterialClass()
        {
            string sql = @"SELECT id,name FROM view_MaterialClass ";
            List<string> MaterialClass = new List<string>();
            DataTable tb = new DataTable();
            tb = SqlHelper.getMaterialClass(sql);
            if (tb.Rows.Count <= 0)
            {
                MaterialClass.Add("拉取物料大类出错，请重试");                
            }
            else
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    MaterialClass.Add(tb.Rows[i]["name"].ToString());
                }
            }
            
            return MaterialClass;
        }

        public DataTable getMaterialall(List<WhereModeHelp> wherestrs)
        {
            if (wherestrs.Count <= 0)
            {
                return null;
            }
            string wherestr = "";
            for(int i=0;i< wherestrs.Count; i++)
            {
                wherestr = wherestr + wherestrs[i].Wherekey +" = '"+ wherestrs[i].Wherevalue +"' and ";
            }

            string sql = @"

                            SELECT 
                                    mc.Name AS MaterialClass ,
                                    sc.Name AS MaterialSubClass ,
                                    m.CodePrefix AS MaterialCodePrefix ,
                                    m.Name AS MaterialName ,
                                    m.Color AS MaterialColor ,
                                    m.DesignRemark ,                                   
                                    SUM(CAST(a.[Count] AS DECIMAL(18, 0))) AS StockCount ,                                   
                                    vu.Name AS MaterialUnitNo
                            FROM    View_MaterialCurrentStock a ( NOLOCK )
                                    LEFT JOIN view_MXMaterial m ( NOLOCK ) ON a.MaterialID = M.ID
                                    LEFT JOIN view_MaterialUnitNo vu ( NOLOCK ) ON m.UnitNo = vu.ID
                                    LEFT JOIN view_MaterialSubClass sc ( NOLOCK ) ON m.SubClass = sc.ID
                                    LEFT JOIN view_MaterialClass mc ( NOLOCK ) ON m.Class = mc.ID
                            WHERE  "+ wherestr + @" a.Warehouse = 291    AND a.[Count] >0
                            GROUP BY a.Warehouse ,
                                    sc.Name ,
                                    mc.Name ,
                                    m.CodePrefix ,
                                    m.Name ,
                                    m.Color ,
                                    m.DesignRemark ,                                   
                                    vu.Name
                            ORDER BY mc.Name ,
                                    CodePrefix
                        ";
            List<string> MaterialClass = new List<string>();
            DataTable tb = new DataTable();
            tb = SqlHelper.getMaterialClass(sql);         

            return tb;
        }
    }
}
