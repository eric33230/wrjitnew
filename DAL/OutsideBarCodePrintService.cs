using JITSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OutsideBarCodePrintService
    {
        public DataTable getOutsideByCustomStyleCode(bool isStyle, string CustomStyleCode, int CartonBarcodeNeed, bool isOrderDate, string orderDate,bool isCustomStyleCode)
        {

            CustomStyleCode = "%" + CustomStyleCode.Trim() + "%";
            string sql = "";
            if (isOrderDate) {
                if (CartonBarcodeNeed == 0)
                {
                    sql = @"
                select
    customname,
    style,
    name,
    color,
    customstylecode,
    custombuyname,
    orderdate,
    shipmentdate,
    custompo,
    manufactureorder,
    cutno,CartonBarcodeNeed
  from
    doc_PackList
  where
    orderdate ='" + orderDate + @"'
 and  CartonBarcodeNeed='Yes'     
  group by
      customname ,
    style ,
    name ,
    color ,
    customstylecode ,
    custombuyname ,
    orderdate ,
    shipmentdate ,
    custompo ,
    manufactureorder ,
    cutno,CartonBarcodeNeed 
order by CartonBarcodeNeed, customstylecode";
                }
                if (CartonBarcodeNeed == 1)
                {
                    sql = @"
                select
    customname,
    style,
    name,
    color,
    customstylecode,
    custombuyname,
    orderdate,
    shipmentdate,
    custompo,
    manufactureorder,
    cutno,CartonBarcodeNeed
  from
    doc_PackList
  where
    orderdate ='" + orderDate + @"'
 and  CartonBarcodeNeed='No'     
  group by
      customname ,
    style ,
    name ,
    color ,
    customstylecode ,
    custombuyname ,
    orderdate ,
    shipmentdate ,
    custompo ,
    manufactureorder ,
    cutno,CartonBarcodeNeed 
order by CartonBarcodeNeed, customstylecode";
                }
                if (CartonBarcodeNeed == 2 || CartonBarcodeNeed == 3)
                {
                    sql = @"
                select
    customname,
    style,
    name,
    color,
    customstylecode,
    custombuyname,
    orderdate,
    shipmentdate,
    custompo,
    manufactureorder,
    cutno,CartonBarcodeNeed
  from
    doc_PackList
  where
    orderdate ='" + orderDate + @"'
   
  group by
      customname ,
    style ,
    name ,
    color ,
    customstylecode ,
    custombuyname ,
    orderdate ,
    shipmentdate ,
    custompo ,
    manufactureorder ,
    cutno,CartonBarcodeNeed 
order by CartonBarcodeNeed, customstylecode";
                }
            }

                if (isStyle)
            {
                if (CartonBarcodeNeed==0) {
                    sql = @"
                select
    customname,
    style,
    name,
    color,
    customstylecode,
    custombuyname,
    orderdate,
    shipmentdate,
    custompo,
    manufactureorder,
    cutno,
CartonBarcodeNeed
  from
    doc_PackList
  where
    Style like @CustomStyleCode
    and  CartonBarcodeNeed='Yes'     
  group by
      customname ,
    style ,
    name ,
    color ,
    customstylecode ,
    custombuyname ,
    orderdate ,
    shipmentdate ,
    custompo ,
    manufactureorder ,
    cutno,
CartonBarcodeNeed 
order by customstylecode";
                }
                if (CartonBarcodeNeed == 1)
                {
                    sql = @"
                select
    customname,
    style,
    name,
    color,
    customstylecode,
    custombuyname,
    orderdate,
    shipmentdate,
    custompo,
    manufactureorder,
    cutno,
CartonBarcodeNeed
  from
    doc_PackList
  where
    Style like @CustomStyleCode
    and  CartonBarcodeNeed='No'     
  group by
      customname ,
    style ,
    name ,
    color ,
    customstylecode ,
    custombuyname ,
    orderdate ,
    shipmentdate ,
    custompo ,
    manufactureorder ,
    cutno,
CartonBarcodeNeed 
order by customstylecode";
                }
                if (CartonBarcodeNeed == 2 || CartonBarcodeNeed==3)
                {
                    sql = @"
                select
    customname,
    style,
    name,
    color,
    customstylecode,
    custombuyname,
    orderdate,
    shipmentdate,
    custompo,
    manufactureorder,
    cutno,
CartonBarcodeNeed
  from
    doc_PackList
  where
    Style like @CustomStyleCode   
  group by
      customname ,
    style ,
    name ,
    color ,
    customstylecode ,
    custombuyname ,
    orderdate ,
    shipmentdate ,
    custompo ,
    manufactureorder ,
    cutno,
CartonBarcodeNeed 
order by customstylecode";
                }


            }
            if(isCustomStyleCode)
            {
                if (CartonBarcodeNeed == 0)
                {
                    sql = @"
                select
    customname,
    style,
    name,
    color,
    customstylecode,
    custombuyname,
    orderdate,
    shipmentdate,
    custompo,
    manufactureorder,
    cutno,
CartonBarcodeNeed
  from
    doc_PackList
  where
    customstylecode  like @CustomStyleCode
    and  CartonBarcodeNeed='Yes'
  group by
      customname ,
    style ,
    name ,
    color ,
    customstylecode ,
    custombuyname ,
    orderdate ,
    shipmentdate ,
    custompo ,
    manufactureorder ,
    cutno,
CartonBarcodeNeed 
order by customstylecode";
                }
                if (CartonBarcodeNeed == 1) {
                    sql = @"
                select
    customname,
    style,
    name,
    color,
    customstylecode,
    custombuyname,
    orderdate,
    shipmentdate,
    custompo,
    manufactureorder,
    cutno,
CartonBarcodeNeed
  from
    doc_PackList
  where
    customstylecode  like @CustomStyleCode
    and  CartonBarcodeNeed='No'
  group by
      customname ,
    style ,
    name ,
    color ,
    customstylecode ,
    custombuyname ,
    orderdate ,
    shipmentdate ,
    custompo ,
    manufactureorder ,
    cutno,
CartonBarcodeNeed 
order by customstylecode";
                }
                if (CartonBarcodeNeed == 2 || CartonBarcodeNeed == 3)
                {
                    sql = @"
                select
    customname,
    style,
    name,
    color,
    customstylecode,
    custombuyname,
    orderdate,
    shipmentdate,
    custompo,
    manufactureorder,
    cutno,
CartonBarcodeNeed
  from
    doc_PackList
  where
    customstylecode  like @CustomStyleCode

  group by
      customname ,
    style ,
    name ,
    color ,
    customstylecode ,
    custombuyname ,
    orderdate ,
    shipmentdate ,
    custompo ,
    manufactureorder ,
    cutno,
CartonBarcodeNeed 
order by customstylecode";
                }
            }
            SqlParameter p = new SqlParameter("CustomStyleCode", CustomStyleCode);
            DataTable table = SqlHelper.ExcuteTable(sql, p);
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                return table;
            }
        }

        public DataTable getOutsideByCustomStyleBox(List<string> CustomStyleCodes)
        {
            string CustomStyleCode = "";
            string sqlwhere = "";
            string sql = "";
            if (CustomStyleCodes.Count() == 1)
            {
                CustomStyleCode = CustomStyleCodes[0].ToString();
                sql = @"
                select
 CustomStyleCode,
 CartonBarcode,
  BOXNO
  from
    doc_PackList
  where
    customstylecode = @CustomStyleCode 

  group by
     CustomStyleCode,
 CartonBarcode,
  BOXNO
order by BOXNO";

            }
            else
            {
                for (int i = 0; i < CustomStyleCodes.Count; i++)
                {
                    CustomStyleCode = "'" + CustomStyleCodes[i].ToString() + "'";
                    sqlwhere = CustomStyleCode + " or CustomStyleCode = " + sqlwhere;
                }
                CustomStyleCode = sqlwhere + CustomStyleCode;
                sql = @"
                select
 CustomStyleCode,
 CartonBarcode,
  BOXNO
  from
    doc_PackList
  where
    customstylecode = " + CustomStyleCode + @"

  group by
     CustomStyleCode,
 CartonBarcode,
  BOXNO
order by CustomStyleCode,BOXNO";
            }


            SqlParameter p = new SqlParameter("CustomStyleCode", CustomStyleCode);
            DataTable table = SqlHelper.ExcuteTable(sql, p);
            if (table == null || table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {

                return table;
            }
        }


        public DataTable getOutsideBycartonBarcode(List<string> cartonBarcodes)
        {
            string cartonBarcode = "";
            string sqlwhere = "";
            string sql = "";
            if (cartonBarcodes.Count() == 1)
            {
                cartonBarcode = cartonBarcodes[0].ToString();
                sql = @"select CustomPO,BOXNO,CutNo,CartonBarcode,CustomName from doc_PackList where CartonBarcode=@cartonBarcode group by CustomPO,BOXNO,CutNo,CartonBarcode,CustomName";

            }
            else
            {
                for (int i = 0; i < cartonBarcodes.Count; i++)
                {
                    cartonBarcode = "'" + cartonBarcodes[i].ToString() + "'";
                    sqlwhere = cartonBarcode + " or CartonBarcode = " + sqlwhere;
                }
                cartonBarcode = sqlwhere + cartonBarcode;

                sql = @"select CustomPO,BOXNO,CutNo,CartonBarcode,CustomName,ManufactureOrder from doc_PackList 
               where CartonBarcode= " + cartonBarcode + @"group by  CustomPO ,BOXNO ,CutNo , CartonBarcode,CustomName,ManufactureOrder order by CustomPO,BOXNO,CartonBarcode,CustomName,ManufactureOrder";
            }




            SqlParameter p = new SqlParameter("CartonBarcode", cartonBarcode);
            DataTable table = SqlHelper.ExcuteTable(sql, p);
            if (table == null || table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {

                return table;
            }
        }

    }
}
