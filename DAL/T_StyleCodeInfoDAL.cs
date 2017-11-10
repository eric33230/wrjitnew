using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace JITSystem.DAL
{
    public class T_StyleCodeInfoDAL
    {
        public void UpdateFromERPDB()
        {
            //确定表是否存在
            //存在 删除
            string tsql = @"SELECT  * FROM dbo.SysObjects WHERE ID = object_id(N'Custom')";

            bool IsNotTmp = false;
            DataTable table = SqlHelper.IsNotTmp(tsql);
            if (table.Rows.Count <= 0)
            {
                IsNotTmp = false;
            }
            else
            {

                IsNotTmp = true;
            }
            string sql;
            if (IsNotTmp)
            {
                sql = @"DROP TABLE Custom";
                SqlHelper.ExecuteNonQuery(sql);
            }
            sql = @"select * into Custom from (select * from View_Custom)as a";
            SqlHelper.ExecuteNonQuery(sql);
        }
        public DataTable GetT_StyleCodeSizeRun(string DocTreeID, string osmDocTreeID)
        {
            String sql = @"
declare @sql varchar(8000)
select @sql = isnull(@sql + '],[','') + name from View_OrderStyleSize  where DocTreeID = " + DocTreeID;

            string sqlw = @" set @sql = '[' + @sql + ']'
exec(  ' select  DocTreeID,CustomStyleCode, ' + @sql + '  from  
(select osm.DocTreeID,o.CustomStyleCode,os.name as Size ,osm.Ccount as Ccount
  from View_OrderShipMatch osm
  left outer join View_OrderStyleSize as os ( nolock ) on os.id=osm.SizeID
left outer join View_OrderDocTree as t ( nolock ) on t.id = osm.DocTreeID
 left outer join View_OrderStyle as o ( nolock ) on t.PrevID = o.DocTreeID
where  osm.DocTreeID =" + osmDocTreeID;
            sql = sql + sqlw + @" ) as P
	 PIVOT 
			(  sum(Ccount)
			for Size in (' + @sql + ' ) 
			) tq ')";
            //  SqlHelper.ExecuteNonQuery(sql);
            DataTable table = SqlHelper.GetStyleCodeInfo(sql);
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {

                return table;
            }
        }

        public byte[] getPhoto(string DocTreeID)
        {
            String sql = @"
select

    m.StyleImage 
   
from
     OrderStyle o ( nolock )
    left join  OrderStyleImage m ( nolock ) on o.ID = m.OrderStyleID
where
    o.DocTreeID = " + DocTreeID;

            DataTable table = SqlHelper.getPhoto(sql);
            if (table.Rows.Count <= 0)
            {
                return null;
            }

            else
            {
                return toPhoto(table.Rows[0]);
                // byte bs = Convert.ToByte(table.Rows[0]);
                //  (byte[])SqlHelper.FromDbValue(row["Photo"]);

                //  return bs;
            }

        }
        private byte[] toPhoto(DataRow row)
        {
            byte[] bs = (byte[])SqlHelper.FromDbValue(row["StyleImage"]);

            return bs;
        }

        public T_Sizi[] GetSizeRun(string osmDocTreeID, Guid infoguid)
        {
            String sql = @"select
                osm.DocTreeID ,
                o.CustomStyleCode ,
				osm.SizeID ,
                os.name as Size ,                
                osm.Ccount as Ccount
            from
                View_OrderShipMatch osm
                left outer join View_OrderStyleSize as os ( nolock ) on os.id = osm.SizeID
                left outer join View_OrderDocTree as t ( nolock ) on t.id = osm.DocTreeID
                left outer join View_OrderStyle as o ( nolock ) on t.PrevID = o.DocTreeID
            where
                osm.DocTreeID = " + osmDocTreeID;
            DataTable table = SqlHelper.GetSizeRun(sql);
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                T_Sizi[] SizeRun = new T_Sizi[table.Rows.Count];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    SizeRun[i] = ToSizeRun(table.Rows[i], infoguid);
                }
                return SizeRun;
            }

        }
        public DataTable GetT_Size(string CustomStyleCode)
        {
            String sql = @"select ts.CustomStyleCode,tc.Code,ts.size,ts.Ccount from dbo.T_Sizi  ts
left join dbo.T_StyleCodeInfo as tc (nolock) on tc.Guid=ts.T_StyleCodeInfoGuid
where ts.CustomStyleCode='" + CustomStyleCode + @"'
order by Size ";
            DataTable table = SqlHelper.GetStyleCodeInfo(sql);
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                //T_Sizi[] SizeRun = new T_Sizi[table.Rows.Count];
                //for (int i = 0; i < table.Rows.Count; i++)
                //{
                //    SizeRun[i] = ToSize(table.Rows[i]);
                //}
                return table;
            }

        }
        private T_Sizi ToSize(DataRow row)
        {
            T_Sizi SizeRun = new T_Sizi();
            // SizeRun.guid = Guid.NewGuid();
            // SizeRun.T_StyleCodeInfoGuid = infoguid;//
            SizeRun.DocTreeID = Convert.ToString(SqlHelper.FromDbValue(row["DocTreeID"]));//
            SizeRun.CustomStyleCode = Convert.ToString(SqlHelper.FromDbValue(row["CustomStyleCode"]));//
            SizeRun.SizeID = Convert.ToString(SqlHelper.FromDbValue(row["SizeID"]));//
            SizeRun.Size = Convert.ToString(SqlHelper.FromDbValue(row["Size"]));//
            SizeRun.Ccount = Convert.ToString(SqlHelper.FromDbValue(row["Ccount"]));//

            return SizeRun;
        }
        private T_Sizi ToSizeRun(DataRow row, Guid infoguid)
        {
            T_Sizi SizeRun = new T_Sizi();
            // SizeRun.guid = Guid.NewGuid();
            SizeRun.T_StyleCodeInfoGuid = infoguid;//
            SizeRun.DocTreeID = Convert.ToString(SqlHelper.FromDbValue(row["DocTreeID"]));//
            SizeRun.CustomStyleCode = Convert.ToString(SqlHelper.FromDbValue(row["CustomStyleCode"]));//
            SizeRun.SizeID = Convert.ToString(SqlHelper.FromDbValue(row["SizeID"]));//
            SizeRun.Size = Convert.ToString(SqlHelper.FromDbValue(row["Size"]));//
            SizeRun.Ccount = Convert.ToString(SqlHelper.FromDbValue(row["Ccount"]));//

            return SizeRun;
        }




        public T_StyleCodeInfo[] GetT_StyleCodeInfo(List<string> whereList, List<string> whereListText, string type)
        {


            String sql = @"select
        *
    from
        ( select
            *
          from
            ( select  distinct 
                SM.ID as StyleID ,
                sm.StyleNumber ,
                si1.Name as ShipTypeName ,
                logo.Code as logocode ,
                logo.Name as logoname ,
                odoc.code as doccode ,
                VODT.Name as OrderDocTypeName,
                osm.DocTreeID as osmDocTreeID ,  
                o.ID ,
                o.DocTreeID ,
                o.Code ,
                o.Name ,
                o.StyleNo ,
                o.Editionhandle ,
                o.CuttingNo ,
                o.ModelNo ,
                o.SingleTurn ,
                o.CustomID ,
				VCustom.CustomName,
                o.CustomBuyer ,
				VCustomBuy.name as CustomBuyName,
                o.LogoLibrary ,
                o.CustomStyleCode ,
                o.FactoryID ,
				Vf.name as FactoryName,
                o.WarehouseID ,
				VFW.name as Warehouse,
                convert(varchar(7), o.OrderDate, 120) as OrderDate ,
                o.CustomClothBrand ,
                o.CCount ,
                o.DesignTypeID ,
                dsty.Name as DesignTypeName ,
                o.GoodsType ,
                 goodstype.Name as GoodsTypeName ,
                o.PriceItem ,
                PriceItem.name as PriceItemName,
                o.BalanceType ,
                BalanceType.name as BalanceTypeName,
                o.ExportPrice ,
                o.MonetaryUnit ,
				VMonet.name as MonetaryUnitname,
                o.IsNeedQuote ,
                o.SessionType ,
                o.IsSinglePrice ,
                o.IsSingleCostPrice ,
                o.IsSingleShowPrice ,
                o.CountryName ,
                o.CountryNum ,
                oship.CustomPO ,
                oship.DeliverDate ,
                oship.ShipMentDate ,
                oship.ExportArea ,
                v1.Name AS AimArea ,
                oship.TotalCount ,
                oship.CutNo ,
                oship.Memo ,
                osd.ShipType ,
                osd.ManufactureOrder ,
                osm.ActualCustomPerCount ,
    			odoc.OrderDocType,
                osm.ColorID ,
				VOC.name as ColorName
              from
                View_OrderStyle as o with ( nolock )

                left outer join View_OrderDocTree as t ( nolock ) on t.PrevID = o.DocTreeID
                left outer join View_OrderShipMatch as osm with ( nolock ) on osm.DocTreeID = t.ID
                left outer join View_OrderShipDestination as osd with ( nolock ) on osm.ShipDestinationID = osd.ID
                left outer join View_Port AS v1 ON v1.ID = osd.DestinationPort
                left outer join View_SelectInfo si1 ( nolock ) on si1.ID = osd.ShipType
                left outer join View_OrderShip as oship with ( nolock ) on oship.DocTreeID = osm.DocTreeID
                left outer join View_OrderDoc as odoc with ( nolock ) on odoc.UID = t.DocCode
                left outer join View_LogoLibrary as logo with ( nolock ) on logo.id = o.LogoLibrary
                left outer join View_SM_Style as SM with ( nolock ) on o.Code = SM.Code
                left outer join View_SysMonetaryUnit as VMonet with ( nolock ) on o.MonetaryUnit = VMonet.ID
				left outer join View_Factory as Vf with ( nolock ) on o.FactoryID = Vf.ID
				left outer join View_FactoryWarehouse as VFW with ( nolock ) on o.WarehouseID = VFW.ID
				left outer join View_Custom as VCustom with ( nolock ) on o.CustomID = VCustom.ID
				left outer join View_CustomBuyer as VCustomBuy with ( nolock ) on o.CustomBuyer = VCustomBuy.ID
				left outer join View_OrderStyleColor as VOC with ( nolock ) on osm.ColorID = VOC.ID
                left outer join View_OrderDocType as VODT with ( nolock ) on odoc.OrderDocType = VODT.ID
                left outer join View_SelectInfo dsty ( nolock ) on dsty.id = o.DesignTypeID
                left outer join View_SelectInfo goodstype ( nolock ) on o.GoodsType = goodstype.ID
                left outer join View_SelectInfo as PriceItem with ( nolock ) on PriceItem.id = o.PriceItem
				left outer join View_SelectInfo BalanceType  ( nolock ) on BalanceType .id = o.BalanceType
            ) as a ";

            String sqlw = @"  ) as d
      
        left outer join ( select
                            *
                          from
                            ( select
                                B.StyleID ,
                                ( B.DesignRemark + B.MaterialCode ) as MDcolor ,
                                B.MaterialElement as MDcode ,
                                ( S1.DesignRemark + S1.MaterialCode ) as RBcolor ,
                                S1.MaterialElement as RBcode ,
                                S2.MaterialName as towcode ,
                                S3.MaterialName as aocode ,
                                S4.MaterialName as ddlcode ,
                                S5.MaterialName as ddwcode ,
                                S6.MaterialName as ddqcode ,
                                S7.MaterialName as ddhcode ,
                                S8.MaterialName as ddscode
                              from
                                View_SM_StyleMaterial b
                                left outer join View_SM_StyleMaterial as S1 on S1.StyleID = B.StyleID
                                                                  and S1.PartNo = 'BB070'	-- BB070	RB
                                left outer join View_SM_StyleMaterial as S2 on S2.StyleID = B.StyleID
                                                                  and S2.PartNo = 'BL007'	--BL007	成底
                                left outer join View_SM_StyleMaterial as S3 on S3.StyleID = B.StyleID
                                                                  and S3.PartNo = 'BB062'	--BB062	成底墊片
                                left outer join View_SM_StyleMaterial as S4 on S4.StyleID = B.StyleID
                                                                  and S4.PartNo = 'BB004'	-- 大底飾片(內腰)
                                left outer join View_SM_StyleMaterial as S5 on S5.StyleID = B.StyleID
                                                                  and S5.PartNo = 'BB005' --大底飾片(外腰)
                                                                  and S5.materialcodeprefix like 'Q%'
                                left outer join View_SM_StyleMaterial as S6 on S6.StyleID = B.StyleID
                                                                  and S6.PartNo = 'BB006' --大底飾片(前掌) 	
                                left outer join View_SM_StyleMaterial as S7 on S7.StyleID = B.StyleID
                                                                  and S7.PartNo = 'BB007' --大底飾片(後跟) 
                                left outer join View_SM_StyleMaterial as S8 on S8.StyleID = B.StyleID
                                                                  and S8.PartNo = 'BB035' --大底射出片   
                              where b.PartNo = 'BB071' or b.PartNo = 'BB023'
                                     and b.materialcodeprefix like 'O12%' 
                                        --    )  --BB071	MD    BB023	大底
                              group by
                                b.StyleID ,
                                ( B.DesignRemark + B.MaterialCode ) ,
                                B.MaterialElement ,
                                ( S1.DesignRemark + S1.MaterialCode ) ,
                                S1.MaterialElement ,
                                S2.MaterialName ,
                                S3.MaterialName ,
                                S4.MaterialName ,
                                S5.MaterialName ,
                                S6.MaterialName ,
                                S7.MaterialName ,
                                S8.MaterialName
                            ) as a
                        ) as SMS on d.StyleID = SMS.StyleID  ";
            /*  图片表
                 left outer join OrderStyleImage as m with ( nolock ) on o.ID = m.OrderStyleID
                left outer join OrderStyleBackImage as mb with ( nolock ) on o.ID = mb.OrderStyleID
             */
            String sqlstr = @"select * from T_StyleCodeInfo";

            if (whereList.Count() > 0)
            {
                sql = sql + " where ";
                sqlstr = sqlstr + " where ";

                for (int i = 0; i < whereList.Count; i++)
                {
                    sql = sql + whereList[i].ToString() + "  " + whereListText[i].ToString() + " and ";
                    sqlstr = sqlstr + whereList[i].ToString() + "  " + whereListText[i].ToString() + " and ";

                }
                sql = sql + "1 = 1" + "and a.CustomStyleCode is not null  and a.OrderDocType=90 and a.FactoryID=121 and a.CustomPO is not null " + sqlw + "  order by ShipMentDate,DeliverDate,OrderDate, CustomStyleCode ";
                sqlstr = sqlstr + "1 = 1  order by ShipMentDate,DeliverDate,OrderDate, CustomStyleCode ";
            }
            //  sql = sql + sqlw;
            DataTable table = new DataTable();
            if (type == "btnsearch")
            {
                table = SqlHelper.GetStyleCodeInfo(sql);
            }
            else if (type == "btnsearchAll")
            {
                table = SqlHelper.GetStyleCodeInfo(sqlstr);
            }

            // DataTable table = SqlHelper.GetStyleCodeInfo(sql);


            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                T_StyleCodeInfo[] T_StyleCodeInfos = new T_StyleCodeInfo[table.Rows.Count];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    T_StyleCodeInfos[i] = ToT_StyleCodeInfos(table.Rows[i], type);
                }
                return T_StyleCodeInfos;
            }
        }
        private T_StyleCodeInfo ToT_StyleCodeInfos(DataRow row,string type)
        {
            T_StyleCodeInfo T_StyleCodeInfos = new T_StyleCodeInfo();
            if (type == "btnsearchAll")
            {
                T_StyleCodeInfos.Guid = (Guid)SqlHelper.FromDbValue(row["Guid"]);//Guid
            }
            

           
            T_StyleCodeInfos.DeliverDate = (DateTime?)SqlHelper.FromDbValue(row["DeliverDate"]);//接單日期
            T_StyleCodeInfos.DocTreeID = Convert.ToString(SqlHelper.FromDbValue(row["DocTreeID"]));//正式订单ID
            T_StyleCodeInfos.doccode = Convert.ToString(SqlHelper.FromDbValue(row["doccode"]));//订单合同号
            T_StyleCodeInfos.OrderDate = Convert.ToString(SqlHelper.FromDbValue(row["OrderDate"]));//订单年月
            T_StyleCodeInfos.SessionType = Convert.ToString(SqlHelper.FromDbValue(row["SessionType"]));//季节号
            T_StyleCodeInfos.CCount = Convert.ToString(SqlHelper.FromDbValue(row["CCount"]));//订单总双数
            T_StyleCodeInfos.TotalCount = Convert.ToString(SqlHelper.FromDbValue(row["TotalCount"]));//SIZI总数
            T_StyleCodeInfos.ExportPrice = Convert.ToString(SqlHelper.FromDbValue(row["ExportPrice"]));//单价
            T_StyleCodeInfos.MonetaryUnit = Convert.ToString(SqlHelper.FromDbValue(row["MonetaryUnit"]));//币种ID
            T_StyleCodeInfos.MonetaryUnitname = Convert.ToString(SqlHelper.FromDbValue(row["MonetaryUnitname"]));//币种
            T_StyleCodeInfos.FactoryID = Convert.ToString(SqlHelper.FromDbValue(row["FactoryID"]));//工厂ID
            T_StyleCodeInfos.FactoryName = Convert.ToString(SqlHelper.FromDbValue(row["FactoryName"]));//生产工厂
            T_StyleCodeInfos.WarehouseID = Convert.ToString(SqlHelper.FromDbValue(row["WarehouseID"]));//仓库ID
            T_StyleCodeInfos.Warehouse = Convert.ToString(SqlHelper.FromDbValue(row["Warehouse"]));//承接仓库
            T_StyleCodeInfos.CustomStyleCode = Convert.ToString(SqlHelper.FromDbValue(row["CustomStyleCode"]));//指令号
            T_StyleCodeInfos.CutNo = Convert.ToString(SqlHelper.FromDbValue(row["CutNo"]));//ORDER NO/PO NO
            T_StyleCodeInfos.CustomID = Convert.ToString(SqlHelper.FromDbValue(row["CustomID"]));//客户ID
            T_StyleCodeInfos.CustomName = Convert.ToString(SqlHelper.FromDbValue(row["CustomName"]));//客户
            T_StyleCodeInfos.CustomBuyer = Convert.ToString(SqlHelper.FromDbValue(row["CustomBuyer"]));//客户买主ID            
            T_StyleCodeInfos.CustomBuyName = Convert.ToString(SqlHelper.FromDbValue(row["CustomBuyName"]));//客户买主ID
            T_StyleCodeInfos.StyleID = Convert.ToString(SqlHelper.FromDbValue(row["StyleID"]));//客户买主ID
            T_StyleCodeInfos.Code = Convert.ToString(SqlHelper.FromDbValue(row["Code"]));//工厂型体+配色
            T_StyleCodeInfos.Name = Convert.ToString(SqlHelper.FromDbValue(row["Name"]));//客户型体
            T_StyleCodeInfos.SingleTurn = Convert.ToString(SqlHelper.FromDbValue(row["SingleTurn"]));//客戶訂單號
            T_StyleCodeInfos.CustomPO = Convert.ToString(SqlHelper.FromDbValue(row["CustomPO"]));//客戶訂單號
            T_StyleCodeInfos.ManufactureOrder = Convert.ToString(SqlHelper.FromDbValue(row["ManufactureOrder"]));//LOTNO
            T_StyleCodeInfos.StyleNumber = Convert.ToString(SqlHelper.FromDbValue(row["StyleNumber"]));//客戶鞋名
            T_StyleCodeInfos.ColorID = Convert.ToString(SqlHelper.FromDbValue(row["ColorID"]));//颜色ID
            T_StyleCodeInfos.ColorName = Convert.ToString(SqlHelper.FromDbValue(row["ColorName"]));//颜色            
            T_StyleCodeInfos.Editionhandle = Convert.ToString(SqlHelper.FromDbValue(row["Editionhandle"]));//楦头编号
            T_StyleCodeInfos.ModelNo = Convert.ToString(SqlHelper.FromDbValue(row["ModelNo"]));//大底编号
            T_StyleCodeInfos.CuttingNo = Convert.ToString(SqlHelper.FromDbValue(row["CuttingNo"]));//后跟编号
            T_StyleCodeInfos.RBcode = Convert.ToString(SqlHelper.FromDbValue(row["RBcode"]));//RB模号
            T_StyleCodeInfos.RBcolor = Convert.ToString(SqlHelper.FromDbValue(row["RBcolor"]));//RB颜色
            T_StyleCodeInfos.MDcode = Convert.ToString(SqlHelper.FromDbValue(row["MDcode"]));//MD模号
            T_StyleCodeInfos.MDcolor = Convert.ToString(SqlHelper.FromDbValue(row["MDcolor"]));//MD颜色
            T_StyleCodeInfos.ddlcode = Convert.ToString(SqlHelper.FromDbValue(row["ddlcode"]));//大底飾片(內腰)
            T_StyleCodeInfos.ddwcode = Convert.ToString(SqlHelper.FromDbValue(row["ddwcode"]));//大底飾片(外腰)
            T_StyleCodeInfos.ddqcode = Convert.ToString(SqlHelper.FromDbValue(row["ddqcode"]));//大底飾片(前掌)
            T_StyleCodeInfos.ddhcode = Convert.ToString(SqlHelper.FromDbValue(row["ddhcode"]));//大底飾片(後跟) 
            T_StyleCodeInfos.ddscode = Convert.ToString(SqlHelper.FromDbValue(row["ddscode"]));//大底射出片  
            T_StyleCodeInfos.aocode = Convert.ToString(SqlHelper.FromDbValue(row["aocode"]));//凹槽
            T_StyleCodeInfos.towcode = Convert.ToString(SqlHelper.FromDbValue(row["towcode"]));//二次工艺
            T_StyleCodeInfos.ShipMentDate = (DateTime?)SqlHelper.FromDbValue(row["ShipMentDate"]);//客户交期
            T_StyleCodeInfos.AimArea = Convert.ToString(SqlHelper.FromDbValue(row["AimArea"]));//目的地
            T_StyleCodeInfos.ExportArea = Convert.ToString(SqlHelper.FromDbValue(row["ExportArea"]));//出货港
            T_StyleCodeInfos.ShipType = Convert.ToString(SqlHelper.FromDbValue(row["ShipType"]));//运输方式ID
            T_StyleCodeInfos.ShipTypeName = Convert.ToString(SqlHelper.FromDbValue(row["ShipTypeName"]));//运输方式
            T_StyleCodeInfos.Memo = Convert.ToString(SqlHelper.FromDbValue(row["Memo"]));//交期備注
            T_StyleCodeInfos.CustomClothBrand = Convert.ToString(SqlHelper.FromDbValue(row["CustomClothBrand"]));//LOGO
            T_StyleCodeInfos.logocode = Convert.ToString(SqlHelper.FromDbValue(row["logocode"]));//LOGO编码
            T_StyleCodeInfos.logoname = Convert.ToString(SqlHelper.FromDbValue(row["logoname"]));//LOGO名称
            T_StyleCodeInfos.OrderDocType = Convert.ToString(SqlHelper.FromDbValue(row["OrderDocType"]));//订单类型ID
            T_StyleCodeInfos.OrderDocTypeName = Convert.ToString(SqlHelper.FromDbValue(row["OrderDocTypeName"]));//订单类型
            T_StyleCodeInfos.osmDocTreeID = Convert.ToString(SqlHelper.FromDbValue(row["osmDocTreeID"]));//鞋型库订单号
            T_StyleCodeInfos.DesignTypeName = Convert.ToString(SqlHelper.FromDbValue(row["DesignTypeName"]));//鞋款做法
            T_StyleCodeInfos.DesignTypeID = Convert.ToString(SqlHelper.FromDbValue(row["DesignTypeID"]));//鞋款做法ID
            T_StyleCodeInfos.GoodsType = Convert.ToString(SqlHelper.FromDbValue(row["GoodsType"]));//产品类型ID
            T_StyleCodeInfos.GoodsTypeName = Convert.ToString(SqlHelper.FromDbValue(row["GoodsTypeName"]));//产品类型
            T_StyleCodeInfos.ID = Convert.ToString(SqlHelper.FromDbValue(row["ID"]));//
            T_StyleCodeInfos.StyleNo = Convert.ToString(SqlHelper.FromDbValue(row["StyleNo"]));//
                                                                                               //  T_StyleCodeInfos.LogoLibrary =  Convert.ToString(SqlHelper.FromDbValue(row["LogoLibrary"]));//
            T_StyleCodeInfos.PriceItem = Convert.ToString(SqlHelper.FromDbValue(row["PriceItem"]));//交易条件ID
            T_StyleCodeInfos.PriceItemName = Convert.ToString(SqlHelper.FromDbValue(row["PriceItemName"]));//交易条件
            T_StyleCodeInfos.BalanceType = Convert.ToString(SqlHelper.FromDbValue(row["BalanceType"]));//付款方式ID
            T_StyleCodeInfos.BalanceTypeName = Convert.ToString(SqlHelper.FromDbValue(row["BalanceTypeName"]));//付款方式
                                                                                                               //  T_StyleCodeInfos.IsNeedQuote =  Convert.ToString(SqlHelper.FromDbValue(row["IsNeedQuote"]));//
                                                                                                               //  T_StyleCodeInfos.IsSinglePrice =  Convert.ToString(SqlHelper.FromDbValue(row["IsSinglePrice"]));//
                                                                                                               //  T_StyleCodeInfos.IsSingleCostPrice =  Convert.ToString(SqlHelper.FromDbValue(row["IsSingleCostPrice"]));//
                                                                                                               // T_StyleCodeInfos.IsSingleShowPrice =  Convert.ToString(SqlHelper.FromDbValue(row["IsSingleShowPrice"]));//
            T_StyleCodeInfos.CountryName = Convert.ToString(SqlHelper.FromDbValue(row["CountryName"]));//国家名称
            T_StyleCodeInfos.CountryNum = Convert.ToString(SqlHelper.FromDbValue(row["CountryNum"]));//国家代码
                                                                                                     //  T_StyleCodeInfos.ActualCustomPerCount =  Convert.ToString(SqlHelper.FromDbValue(row["ActualCustomPerCount"]));
            return T_StyleCodeInfos;
        }
        public void updataFromDV(T_StyleCodeInfo dvsytleinfo, Guid guid)
        {

            String sql = @"INSERT INTO T_StyleCodeInfo
           (Guid
           ,osmDocTreeID
           ,DocTreeID
           ,DeliverDate
           ,doccode
           ,OrderDate
           ,SessionType
           ,CCount
           ,TotalCount
           ,ExportPrice
           ,MonetaryUnit
           ,MonetaryUnitname
           ,FactoryID
           ,FactoryName
           ,WarehouseID
           ,Warehouse
           ,CustomStyleCode
           ,CutNo
           ,CustomID
           ,CustomName
           ,CustomBuyer
           ,CustomBuyName
           ,StyleID
           ,Code
           ,Name
           ,SingleTurn
           ,CustomPO
           ,ManufactureOrder
           ,StyleNumber
           ,ColorID
           ,ColorName
           ,Editionhandle
           ,ModelNo
           ,CuttingNo
           ,RBcode
           ,RBcolor
           ,MDcode
           ,MDcolor
           ,ddlcode
           ,ddwcode
           ,ddqcode
           ,ddhcode
           ,ddscode
           ,aocode
           ,towcode
           ,ShipMentDate
           ,ExportArea
           ,AimArea
           ,ShipType
           ,ShipTypeName
           ,Memo
           ,CustomClothBrand
           ,logocode
           ,logoname
           ,OrderDocType
           ,OrderDocTypeName
           ,DesignTypeID
           ,DesignTypeName
           ,GoodsType
           ,GoodsTypeName
           ,ID
           ,StyleNo
           ,PriceItem
           ,PriceItemName
           ,BalanceType
           ,BalanceTypeName
           ,CountryName
           ,CountryNum)
 VALUES
(@Guid
           ,@osmDocTreeID
           ,@DocTreeID
           ,@DeliverDate
           ,@doccode
           ,@OrderDate
           ,@SessionType
           ,@CCount
           ,@TotalCount
           ,@ExportPrice
           ,@MonetaryUnit
           ,@MonetaryUnitname
           ,@FactoryID
           ,@FactoryName
           ,@WarehouseID
           ,@Warehouse
           ,@CustomStyleCode
           ,@CutNo
           ,@CustomID
           ,@CustomName
           ,@CustomBuyer
           ,@CustomBuyName
           ,@StyleID
           ,@Code
           ,@Name
           ,@SingleTurn
           ,@CustomPO
           ,@ManufactureOrder
           ,@StyleNumber
           ,@ColorID
           ,@ColorName
           ,@Editionhandle
           ,@ModelNo
           ,@CuttingNo
           ,@RBcode
           ,@RBcolor
           ,@MDcode
           ,@MDcolor
           ,@ddlcode
           ,@ddwcode
           ,@ddqcode
           ,@ddhcode
           ,@ddscode
           ,@aocode
           ,@towcode
           ,@ShipMentDate
           ,@ExportArea
           ,@AimArea
           ,@ShipType
           ,@ShipTypeName
           ,@Memo
           ,@CustomClothBrand
           ,@logocode
           ,@logoname
           ,@OrderDocType
           ,@OrderDocTypeName
           ,@DesignTypeID
           ,@DesignTypeName
           ,@GoodsType
           ,@GoodsTypeName
           ,@ID
           ,@StyleNo
           ,@PriceItem
           ,@PriceItemName
           ,@BalanceType
           ,@BalanceTypeName
           ,@CountryName
           ,@CountryNum);";
            // Guid guid;
            //  guid = Guid.NewGuid();


            SqlParameter[] sps =
              {
                        new SqlParameter("@Guid",guid),
                        new SqlParameter("@osmDocTreeID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.osmDocTreeID) },
                        new SqlParameter("@DocTreeID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.DocTreeID) },
                        new SqlParameter("@DeliverDate",SqlDbType.DateTime) {Value= SqlHelper.ToDbValue(dvsytleinfo.DeliverDate) },
                        new SqlParameter("@doccode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.doccode) },
                        new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.OrderDate) },
                        new SqlParameter("@SessionType",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.SessionType) },

                        new SqlParameter("@CCount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CCount) },
                        new SqlParameter("@TotalCount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.TotalCount) },
                        new SqlParameter("@ExportPrice",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ExportPrice) },
                        new SqlParameter("@MonetaryUnit",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.MonetaryUnit) },
                        new SqlParameter("@MonetaryUnitname",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.MonetaryUnitname) },

                        new SqlParameter("@FactoryID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.FactoryID) },
                        new SqlParameter("@FactoryName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.FactoryName) },
                        new SqlParameter("@WarehouseID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.WarehouseID) },
                        new SqlParameter("@Warehouse",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.Warehouse) },
                        new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomStyleCode) },
                        new SqlParameter("@CutNo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CutNo) },
                        new SqlParameter("@CustomID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomID) },
                        new SqlParameter("@CustomName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomName) },
                        new SqlParameter("@CustomBuyer",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomBuyer) },
                        new SqlParameter("@CustomBuyName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomBuyName) },
                        new SqlParameter("@StyleID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.StyleID) },

                        new SqlParameter("@Code",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.Code) },
                        new SqlParameter("@Name",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.Name) },
                        new SqlParameter("@SingleTurn",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.SingleTurn) },
                        new SqlParameter("@CustomPO",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomPO) },
                        new SqlParameter("@ManufactureOrder",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ManufactureOrder) },
                        new SqlParameter("@StyleNumber",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.StyleNumber) },
                        new SqlParameter("@ColorID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ColorID) },
                        new SqlParameter("@ColorName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ColorName) },
                        new SqlParameter("@Editionhandle",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.Editionhandle) },
                        new SqlParameter("@ModelNo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ModelNo) },
                        new SqlParameter("@CuttingNo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CuttingNo) },

                        new SqlParameter("@RBcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.RBcode) },
                        new SqlParameter("@RBcolor",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.RBcolor) },
                        new SqlParameter("@MDcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.MDcode) },
                        new SqlParameter("@MDcolor",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.MDcolor) },
                        new SqlParameter("@ddlcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ddlcode) },
                        new SqlParameter("@ddwcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ddwcode) },
                        new SqlParameter("@ddqcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ddqcode) },
                        new SqlParameter("@ddhcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ddhcode) },
                        new SqlParameter("@ddscode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ddscode) },
                        new SqlParameter("@aocode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.aocode) },
                        new SqlParameter("@towcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.towcode) },

                        new SqlParameter("@ShipMentDate",SqlDbType.DateTime) {Value= SqlHelper.ToDbValue(dvsytleinfo.ShipMentDate) },
                        new SqlParameter("@ExportArea",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ExportArea) },
                        new SqlParameter("@AimArea",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.AimArea) },
                        new SqlParameter("@ShipType",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ShipType) },
                        new SqlParameter("@ShipTypeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ShipTypeName) },
                        new SqlParameter("@Memo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.Memo) },
                        new SqlParameter("@CustomClothBrand",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomClothBrand) },
                        new SqlParameter("@logocode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.logocode) },
                        new SqlParameter("@logoname",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.logoname) },
                        new SqlParameter("@OrderDocType",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.OrderDocType) },
                        new SqlParameter("@OrderDocTypeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.OrderDocTypeName) },
                        new SqlParameter("@DesignTypeID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.DesignTypeID) },

                        new SqlParameter("@DesignTypeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.DesignTypeName) },
                        new SqlParameter("@GoodsType",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.GoodsType) },
                        new SqlParameter("@GoodsTypeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.GoodsTypeName) },
                        new SqlParameter("@ID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ID) },
                        new SqlParameter("@StyleNo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.StyleNo) },
                        new SqlParameter("@PriceItem",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.PriceItem) },
                        new SqlParameter("@PriceItemName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.PriceItemName) },
                        new SqlParameter("@BalanceType",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.BalanceType) },
                        new SqlParameter("@BalanceTypeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.BalanceTypeName) },
                        new SqlParameter("@CountryName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CountryName) },
                        new SqlParameter("@CountryNum",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CountryNum) }
            };
            SqlHelper.ExecuteNonQuery(sql, sps);
            // SqlHelper.GetStyleCodeInfo(sql);
        }
        public void updataFromSizeRun(T_Sizi sizerun)
        {

            String sql = @"INSERT INTO T_Sizi
 
           (Guid
           ,T_StyleCodeInfoGuid
           ,DocTreeID
           ,CustomStyleCode
           ,SizeID
           ,Size
           ,Ccount)
            VALUES
            (@Guid
           ,@T_StyleCodeInfoGuid
           ,@DocTreeID
           ,@CustomStyleCode
           ,@SizeID
           ,@Size
           ,@Ccount)";

            SqlParameter[] sps =
              {
                        new SqlParameter("@Guid",Guid.NewGuid()),
                        new SqlParameter("@T_StyleCodeInfoGuid",SqlDbType.UniqueIdentifier) {Value= SqlHelper.ToDbValue(sizerun.T_StyleCodeInfoGuid) },
                        new SqlParameter("@DocTreeID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(sizerun.DocTreeID) },
                        new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(sizerun.CustomStyleCode) },
                        new SqlParameter("@SizeID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(sizerun.SizeID) },
                        new SqlParameter("@Size",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(sizerun.Size) },
                        new SqlParameter("@Ccount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(sizerun.Ccount) }

            };
            SqlHelper.ExecuteNonQuery(sql, sps);
            // SqlHelper.GetStyleCodeInfo(sql);
        }
        public void sqlbulkcopy(DataTable table)
        {
            SqlHelper.SqlBulkCopy(table);

        }
        public string GetCountByosmDocTreeID(string CustomStyleCode)
        {
            String sql = @"select * from dbo.T_StyleCodeInfo where CustomStyleCode= '" + CustomStyleCode + "'";
            DataTable table = SqlHelper.ExecuteReader(sql);

            int i = table.Rows.Count;
            string guid = "";
            if (i > 0)
            {
                guid = table.Rows[0][0].ToString();

            }
            return guid;


        }
        public int GetCountByosmDocTreeID(string osmDocTreeID, string SizeID)
        {
            String sql = @"select * from dbo.T_Sizi where DocTreeID= " + osmDocTreeID + "and SizeID = " + SizeID;
            DataTable table = SqlHelper.ExecuteReader(sql);
            int i = table.Rows.Count;
            return i;


        }
        public void updataFromsinfoDV(T_StyleCodeInfo dvsytleinfo, string guid)
        {
            String sql = @"UPDATE T_StyleCodeInfo
           SET
           osmDocTreeID = @osmDocTreeID
, DocTreeID = @DocTreeID
, DeliverDate = @DeliverDate
, doccode = @doccode
, OrderDate = @OrderDate
, SessionType = @SessionType
, CCount = @CCount
, TotalCount = @TotalCount
, ExportPrice = @ExportPrice
, MonetaryUnit = @MonetaryUnit
, MonetaryUnitname = @MonetaryUnitname
, FactoryID = @FactoryID
, FactoryName = @FactoryName
, WarehouseID = @WarehouseID
, Warehouse = @Warehouse
, CustomStyleCode = @CustomStyleCode
, CutNo = @CutNo
, CustomID = @CustomID
, CustomName = @CustomName
, CustomBuyer = @CustomBuyer
, CustomBuyName = @CustomBuyName
, StyleID = @StyleID
, Code = @Code
, Name = @Name
, SingleTurn = @SingleTurn
, CustomPO = @CustomPO
, ManufactureOrder = @ManufactureOrder
, StyleNumber = @StyleNumber
, ColorID = @ColorID
, ColorName = @ColorName
, Editionhandle = @Editionhandle
, ModelNo = @ModelNo
, CuttingNo = @CuttingNo
, RBcode = @RBcode
, RBcolor = @RBcolor
, MDcode = @MDcode
, MDcolor = @MDcolor
, ddlcode = @ddlcode
, ddwcode = @ddwcode
, ddqcode = @ddqcode
, ddhcode = @ddhcode
, ddscode = @ddscode
, aocode = @aocode
, towcode = @towcode
, ShipMentDate = @ShipMentDate
, ExportArea = @ExportArea
, AimArea = @AimArea

, ShipType = @ShipType
, ShipTypeName = @ShipTypeName
, Memo = @Memo
, CustomClothBrand = @CustomClothBrand
, logocode = @logocode
, logoname = @logoname
, OrderDocType = @OrderDocType
, OrderDocTypeName = @OrderDocTypeName
, DesignTypeID = @DesignTypeID
, DesignTypeName = @DesignTypeName
, GoodsType = @GoodsType
, GoodsTypeName = @GoodsTypeName
, ID = @ID
, StyleNo = @StyleNo
, PriceItem = @PriceItem
, PriceItemName = @PriceItemName
, BalanceType = @BalanceType
, BalanceTypeName = @BalanceTypeName
, CountryName = @CountryName
, CountryNum = @CountryNum
WHERE Guid = '" + guid + "'";
            // Guid guid;
            //  guid = Guid.NewGuid();


            SqlParameter[] sps =
              {

                        new SqlParameter("@osmDocTreeID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.osmDocTreeID) },
                        new SqlParameter("@DocTreeID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.DocTreeID) },
                        new SqlParameter("@DeliverDate",SqlDbType.DateTime) {Value= SqlHelper.ToDbValue(dvsytleinfo.DeliverDate) },
                        new SqlParameter("@doccode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.doccode) },
                        new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.OrderDate) },
                        new SqlParameter("@SessionType",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.SessionType) },

                        new SqlParameter("@CCount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CCount) },
                        new SqlParameter("@TotalCount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.TotalCount) },
                        new SqlParameter("@ExportPrice",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ExportPrice) },
                        new SqlParameter("@MonetaryUnit",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.MonetaryUnit) },
                        new SqlParameter("@MonetaryUnitname",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.MonetaryUnitname) },

                        new SqlParameter("@FactoryID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.FactoryID) },
                        new SqlParameter("@FactoryName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.FactoryName) },
                        new SqlParameter("@WarehouseID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.WarehouseID) },
                        new SqlParameter("@Warehouse",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.Warehouse) },
                        new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomStyleCode) },
                        new SqlParameter("@CutNo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CutNo) },
                        new SqlParameter("@CustomID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomID) },
                        new SqlParameter("@CustomName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomName) },
                        new SqlParameter("@CustomBuyer",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomBuyer) },
                        new SqlParameter("@CustomBuyName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomBuyName) },
                        new SqlParameter("@StyleID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.StyleID) },

                        new SqlParameter("@Code",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.Code) },
                        new SqlParameter("@Name",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.Name) },
                        new SqlParameter("@SingleTurn",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.SingleTurn) },
                        new SqlParameter("@CustomPO",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomPO) },
                        new SqlParameter("@ManufactureOrder",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ManufactureOrder) },
                        new SqlParameter("@StyleNumber",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.StyleNumber) },
                        new SqlParameter("@ColorID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ColorID) },
                        new SqlParameter("@ColorName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ColorName) },
                        new SqlParameter("@Editionhandle",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.Editionhandle) },
                        new SqlParameter("@ModelNo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ModelNo) },
                        new SqlParameter("@CuttingNo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CuttingNo) },

                        new SqlParameter("@RBcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.RBcode) },
                        new SqlParameter("@RBcolor",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.RBcolor) },
                        new SqlParameter("@MDcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.MDcode) },
                        new SqlParameter("@MDcolor",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.MDcolor) },
                        new SqlParameter("@ddlcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ddlcode) },
                        new SqlParameter("@ddwcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ddwcode) },
                        new SqlParameter("@ddqcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ddqcode) },
                        new SqlParameter("@ddhcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ddhcode) },
                        new SqlParameter("@ddscode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ddscode) },
                        new SqlParameter("@aocode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.aocode) },
                        new SqlParameter("@towcode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.towcode) },

                        new SqlParameter("@ShipMentDate",SqlDbType.DateTime) {Value= SqlHelper.ToDbValue(dvsytleinfo.ShipMentDate) },
                         new SqlParameter("@AimArea",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.AimArea) },
                        new SqlParameter("@ExportArea",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ExportArea) },
                        new SqlParameter("@ShipType",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ShipType) },
                        new SqlParameter("@ShipTypeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ShipTypeName) },
                        new SqlParameter("@Memo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.Memo) },
                        new SqlParameter("@CustomClothBrand",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CustomClothBrand) },
                        new SqlParameter("@logocode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.logocode) },
                        new SqlParameter("@logoname",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.logoname) },
                        new SqlParameter("@OrderDocType",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.OrderDocType) },
                        new SqlParameter("@OrderDocTypeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.OrderDocTypeName) },
                        new SqlParameter("@DesignTypeID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.DesignTypeID) },

                        new SqlParameter("@DesignTypeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.DesignTypeName) },
                        new SqlParameter("@GoodsType",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.GoodsType) },
                        new SqlParameter("@GoodsTypeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.GoodsTypeName) },
                        new SqlParameter("@ID",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.ID) },
                        new SqlParameter("@StyleNo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.StyleNo) },
                        new SqlParameter("@PriceItem",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.PriceItem) },
                        new SqlParameter("@PriceItemName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.PriceItemName) },
                        new SqlParameter("@BalanceType",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.BalanceType) },
                        new SqlParameter("@BalanceTypeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.BalanceTypeName) },
                        new SqlParameter("@CountryName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CountryName) },
                        new SqlParameter("@CountryNum",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(dvsytleinfo.CountryNum) }
            };
            SqlHelper.ExecuteNonQuery(sql, sps);
            // SqlHelper.GetStyleCodeInfo(sql);
        }
    }
}

