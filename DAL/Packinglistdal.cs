using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JITSystem.DAL
{
    public class Packinglistdal
    {
        public DataTable getPacking(string CustomStyleCode)
        {
            string sql = @"

select
     
    a.CustomName ,
    a.GoodsTypeEnName ,
    a.CustomStyleName ,
    a.CustomStyleCode ,
    a.CutNo ,
    a.ManufactureOrder ,
    a.CustomPO ,
    a.ColorGroupName ,
    a.BoxSize ,
    a.SizeName ,
    a.ddcount as TotalCount ,
    a.BoxNoTotal ,
    a.PerCount ,
    a.BOXTONO ,
    a.perCountTotal ,
    a.BoxVolume ,
    ( a.ToBoxNo - a.BoxNo + 1 ) * a.BoxVolume as MT ,
    a.InBoxSpec ,
    a.Totsumcount ,
    a.Boxsumcount ,
    a.BatchOrderBoxID ,
    a.GW ,
    round(a.GW * a.perCountTotal, 2) as TGW ,
    a.NW ,
    round(a.NW * a.perCountTotal, 2) as TNW,
    a.OrderDate
from
    ( select
        dd.ID ,
        sf.Remark as GoodsTypeEnName ,
        vs.name + ' ' + isnull(vs.stylenumber, ' ') CustomStyleName ,
        dd.Count as ddcount ,
        cast(sum(dd.Count) over ( partition by dd.BoxNo ) as varchar(10)) perboxcount ,
        cast(sum(dd.Count) over ( partition by dd.BoxNo ) * ( dd.ToBoxNo
                                                              - dd.BoxNo + 1 ) as varchar(10)) runcount ,
        cast(( dd.ToBoxNo - dd.BoxNo + 1 ) as varchar(20)) as BoxNoTotal ,
        convert(varchar(10), dd.BoxNo) + '-' + convert(varchar(10), dd.TOBoxNo) BOXTONO ,
        vs.DocCode as OrderCode ,
        dd.StyleCode ,
        dd.StyleName ,
        dd.AimArea ,
        dd.OrderShipDestinationID ,
        dd.BatchOrderBoxID ,
        dd.OrderBoxDocID ,
        dd.BoxRule ,
        dd.BoxNo ,
        dd.ToBoxNo ,
        dd.BoxSize ,
        dd.ColorID ,
        dd.ColorName ,
        dd.SizeName ,
        cast(isnull(cast(os.Code as varchar(10)), dd.SizeName) as int) as SizeCode ,
        dd.Remark ,
        vs.CustomStyleCode ,
        vs.CutNo ,
        dd.PackingBoxLayoutID ,
        vs.StyleDocTreeID ,
        dd.IsShortShip ,
        dd.BatchNo ,
        dd.BatchDate ,
        bb.BeenCancelShortShip ,
        dd.ParentBoxID ,
        dd.BlockNo as ddBlockNo ,
        oc.Code as ColorCode ,
        oc.GroupName as ColorGroupName ,
        osd.ManufactureOrder ,
 
        obb.count as obbcount ,
        obb.PerCount ,
        obb.BoxGrossWeight ,
        obb.BoxWeight ,
        dd.BoxVolume ,
        obb.perCountTotal ,
        obb.BoxWeightotal ,
        obb.BoxGrossWeighttotal ,
        vs.CustomName ,
        vs.CustomPO ,
        case when charindex('*', dd.BoxSize) <> 0
             then substring(dd.BoxSize, 1, charindex('*', dd.BoxSize) - 1)
             else ' '
        end as BoxSizeL ,
        case when charindex('*', dd.BoxSize) <> 0
             then substring(substring(dd.BoxSize,
                                      charindex('*', dd.BoxSize) + 1,
                                      len(dd.BoxSize)), 1,
                            charindex('*',
                                      substring(dd.BoxSize,
                                                charindex('*', dd.BoxSize) + 1,
                                                len(dd.BoxSize))) - 1)
             else ' '
        end as BoxSizeW ,
        substring(substring(dd.BoxSize, charindex('*', dd.BoxSize) + 1,
                            len(dd.BoxSize)),
                  charindex('*',
                            substring(dd.BoxSize,
                                      charindex('*', dd.BoxSize) + 1,
                                      len(dd.BoxSize))) + 1, len(dd.BoxSize)) as BoxSizeH ,
        dd.StyleCode + dd.ColorName as StyleColor ,
        PB.InBoxSpec ,
        sqb.Totsumcount ,
        sqb.Boxsumcount ,
        dd.BlockNo ,
        twg.GW ,
        twg.NW,
        vs.OrderDate
      from
        View_IO_OrderBoxDocDetail dd
        left join View_IO_OrderBoxDoc d on dd.OrderBoxDocID = d.ID
        left join View_OrderStyleShip vs on vs.ShipDocTreeID = d.ShipDocTreeID
        left join View_SelectInfo sf on vs.GoodsType = sf.ID
        left join ( select
                        d.ParentBoxID ,
                        count(*) as BeenCancelShortShip
                    from
                        View_IO_OrderBoxDocDetail d
                    group by
                        d.ParentBoxID
                  ) bb on bb.ParentBoxID = dd.ID
        left join View_OrderStyleSize os on dd.SizeID = os.ID
        left join View_OrderStyleColor oc on dd.ColorID = oc.ID
        left join View_OrderShipDestination osd on osd.ID = d.OrderShipDestinationID
        left join View_IO_OrderBoxDocPackingBox pb on dd.BatchOrderBoxID = pb.BatchOrderBoxDocID
                                                      and pb.StyleDocTreeID = vs.StyleDocTreeID
                                                      and convert(varchar(20), pb.XSize)
                                                      + '*'
                                                      + convert(varchar(20), pb.YSize)
                                                      + '*'
                                                      + convert(varchar(20), pb.ZSize) = dd.BoxSize
        left join ( select
                        oba.OrderBoxDocID ,
                        oba.BoxNo ,
                        oba.ToBoxNo ,
                        oba.SizeId,
                        ( oba.ToBoxNo - oba.BoxNo + 1 ) * oba.perCount as perCountTotal ,
                        oba.perCount as perCount ,
                        sum(oba.Count) as Count ,
                        sum(oba.Count * ( oba.ToBoxNo - BoxNo + 1 )) as TotalCount ,
                        sum(oba.BoxGrossWeight) as BoxGrossWeight ,
                        sum(oba.BoxWeight) as BoxWeight ,
                        sum(oba.BoxVolume) as BoxVolume ,
                        sum(oba.ToBoxNo - BoxNo + 1) as BoxNoTotal ,
                        sum(( oba.ToBoxNo - oba.BoxNo + 1 ) * oba.BoxWeight) as BoxWeightotal ,
                        sum(( oba.ToBoxNo - oba.BoxNo + 1 )
                            * oba.BoxGrossWeight) as BoxGrossWeighttotal
                    from
                        View_IO_OrderBoxDocDetail oba
                    group by
                        oba.OrderBoxDocID ,
                        oba.BoxNo ,
                        oba.ToBoxNo ,
                        oba.SizeId,
                        oba.perCount ,
                        ( oba.ToBoxNo - oba.BoxNo + 1 ) * oba.perCount
                  ) obb on obb.OrderBoxDocID = dd.OrderBoxDocID
                           and obb.BoxNo = dd.BoxNo
                           and obb.ToBoxNo = dd.ToBoxNo
                           and obb.SizeId=dd.SizeId
        full join ( select
                        ID ,
                        Totsumcount ,
                        Boxsumcount
                    from
                        View_IO_OrderBoxDocDetail_sumqtybox
                    group by
                        Totsumcount ,
                        Boxsumcount ,
                        ID
                  ) sqb on dd.ID = sqb.ID
        left join T_weight twg on vs.CustomStyleCode = twg.CoutomCode
                                  and twg.StyleSize = dd.SizeName
      where
        isnull(dd.IsShortShip, 0) <> 1
       and dd.BatchOrderBoxID = '" + CustomStyleCode + @"' 
    ) as a
order by
    a.BoxNo;";
            //and vs.CustomStyleCode = '" + CustomStyleCode + @"'
            // left join IO_OrderBoxDocDetail_sumqtybox sqb on dd.ID = sqb.ID

            DataTable table = SqlHelper.GetPackingList(sql);
            return table;

        }


        public DataTable getCustomstr(string wherestr)
        {
            string sql = @"
    select
        max(BatchOrderBoxID) BatchOrderBoxID ,
        CustomStyleCode ,
        OrderDate
    from
         T_StyleCodeInfo a
        left join View_IO_OrderBoxDoc as b ( nolock ) on a.osmDocTreeID = b.ShipDocTreeID
    where
      " + wherestr + @" group by
        CustomStyleCode ,
        OrderDate;";

            DataTable table = SqlHelper.ExecuteReader(sql);
            return table;

        }
        public DataTable getBox(string BatchOrderBoxID)
        {
            string sql = @"
select
    aa.BatchOrderBoxID ,
    aa.PerBoxCount ,
    sum(aa.BoxNOtotal) BoxNOtotal ,
    aa.boxspec ,
    aa.BoxSize ,
    aa.ccmb
into
    #tempaa
from
    ( select  distinct
        dd.BatchOrderBoxID ,
        dd.BoxNo ,
        dd.ToBoxNo - dd.BoxNo + 1 as BoxNOtotal ,
        PerBoxCount ,
        dd.BoxSize ,
        boxspec ,
        dbo.fu_change_cbm(dd.BoxSize) ccmb
      from
        View_IO_OrderBoxDocDetail dd
        left join View_style_size b on dd.StyleCode = b.code
                                          and dd.SizeName = b.sizename
        left join ( select distinct
                        BatchOrderBoxID ,
                        BoxNo ,
                        stuff(( select
                                    '/' + BoxSpec
                                from
                                    View_IO_OrderBoxDocDetail_boxspec
                                where
                                    BatchOrderBoxID = A.BatchOrderBoxID
                                    and BoxNo = a.BoxNo
                              for
                                xml path('')
                              ), 1, 1, '') as boxspec
                    from
                        View_IO_OrderBoxDocDetail_boxspec A
                    where
                        BatchOrderBoxID = " + BatchOrderBoxID + @"
                  ) BS on DD.BoxNo = BS.BoxNo
        left join ( select
                        BoxNo ,
                        sum(count) PerBoxCount
                    from
                        View_IO_OrderBoxDocDetail
                    where
                        BatchOrderBoxID = " + BatchOrderBoxID + @"
                    group by
                        BoxNo
                  ) BC on BC.BoxNo = DD.BoxNo
      where
        isnull(dd.IsShortShip, 0) <> 1
        and dd.BatchOrderBoxID = " + BatchOrderBoxID + @"
    ) aa
group by
    aa.BatchOrderBoxID ,
    aa.PerBoxCount ,
    aa.boxspec ,
    aa.BoxSize ,
    aa.ccmb

select
    dd.BatchOrderBoxID ,
    aa.percount ,
    boxspec ,
    BoxSize ,
    min(sizename) + '-' + max(SizeName) as sizename
into
    #tempbb
from
    View_IO_OrderBoxDocDetail dd
    left join ( select
                    boxno ,
                    sum(count) percount
                from
                    View_IO_OrderBoxDocDetail dd
                where
                    isnull(dd.IsShortShip, 0) <> 1
                    and dd.BatchOrderBoxID = " + BatchOrderBoxID + @"
                group by
                    boxno
              ) aa on dd.BoxNo = aa.boxno
    left join ( select distinct
                    BatchOrderBoxID ,
                    BoxNo ,
                    stuff(( select
                                '/' + BoxSpec
                            from
                                View_IO_OrderBoxDocDetail_boxspec
                            where
                                BatchOrderBoxID = A.BatchOrderBoxID
                                and BoxNo = a.BoxNo
                          for
                            xml path('')
                          ), 1, 1, '') as boxspec
                from
                    View_IO_OrderBoxDocDetail_boxspec A
                where
                    BatchOrderBoxID = " + BatchOrderBoxID + @"
              ) BS on DD.BoxNo = BS.BoxNo
where
    isnull(dd.IsShortShip, 0) <> 1
    and dd.BatchOrderBoxID = " + BatchOrderBoxID + @"
group by
    dd.BatchOrderBoxID ,
    aa.percount ,
    boxspec ,
    BoxSize


select  distinct
    dd.BatchOrderBoxID ,
    PerBoxCount ,
    dd.BoxSize ,
    boxspec ,
    vs.CustomStyleCode
into
    #tempcc
from
    View_IO_OrderBoxDocDetail dd
    left join View_IO_OrderBoxDoc d on dd.OrderBoxDocID = d.ID
    left join view_OrderStyleShip vs on vs.ShipDocTreeID = d.ShipDocTreeID
    left join ( select distinct
                    BatchOrderBoxID ,
                    BoxNo ,
                    stuff(( select
                                '/' + BoxSpec
                            from
                                View_IO_OrderBoxDocDetail_boxspec
                            where
                                BatchOrderBoxID = A.BatchOrderBoxID
                                and BoxNo = a.BoxNo
                          for
                            xml path('')
                          ), 1, 1, '') as boxspec
                from
                    view_IO_OrderBoxDocDetail_boxspec A
                where
                    BatchOrderBoxID = " + BatchOrderBoxID + @"
              ) BS on DD.BoxNo = BS.BoxNo
    left join ( select
                    BoxNo ,
                    sum(count) PerBoxCount
                from
                    View_IO_OrderBoxDocDetail
                where
                    BatchOrderBoxID = " + BatchOrderBoxID + @"
                group by
                    BoxNo
              ) BC on BC.BoxNo = DD.BoxNo
where
    isnull(dd.IsShortShip, 0) <> 1
    and dd.BatchOrderBoxID = " + BatchOrderBoxID + @"

select
    a.PerBoxCount ,
    a.boxspec ,
    a.BoxSize ,
    '=' + cast(a.ccmb as varchar) ccmb ,
    a.BoxNOtotal ,
    a.BoxNOtotal * a.ccmb as CMB ,
    b.sizename ,
    c.CustomStyleCode
from
    #tempaa a
    left join #tempbb b on a.BatchOrderBoxID = b.BatchOrderBoxID
                           and a.PerBoxCount = b.percount
                           and a.boxspec = b.boxspec
                           and a.BoxSize = b.BoxSize
    left join ( select distinct
                    aa.BatchOrderBoxID ,
                    aa.PerBoxCount ,
                    aa.BoxSize ,
                    aa.boxspec ,
                    stuff(( select
                                '/' + CustomStyleCode
                            from
                                #tempcc
                            where
                                PerBoxCount = aa.PerBoxCount
                                and BoxSize = aa.BoxSize
                                and boxspec = aa.boxspec
                          for
                            xml path('')
                          ), 1, 1, '') as CustomStyleCode
                from
                    #tempcc aa
              ) c on a.BatchOrderBoxID = c.BatchOrderBoxID
                     and a.PerBoxCount = c.PerBoxCount
                     and a.boxspec = c.boxspec
                     and a.BoxSize = c.BoxSize
";
            DataTable table = SqlHelper.GetPackingList(sql);
            return table;

        }
        public byte[] getPhoto(string StyleCode)
        {
            String sql = @"select MTphoto from  T_PackMT where CoutomCode ='" + StyleCode + "';";
            DataTable table = SqlHelper.MTphoto(sql);
            if (table == null)
            {
                return null;

            }
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                return toPhoto(table.Rows[0]);
            }
        }
        private byte[] toPhoto(DataRow row)
        {
            byte[] bs = (byte[])SqlHelper.FromDbValue(row["MTphoto"]);
            return bs;
        }

        public void pkUpDb(PackList pk)
        {
            String sql = @"INSERT INTO  T_PackList
           (guid
           ,CustomName
           ,GoodsTypeEnName
           ,CustomStyleName
           ,CustomStyleCode
           ,SizeName
           ,TotalCount
           ,CutNo
           ,ManufactureOrder
           ,CustomPO
           ,ColorGroupName
           ,BoxSize
           ,BoxNoTotal
           ,PerCount
           ,perCountTotal
           ,NW
           ,TNW
           ,GW
           ,TGW
           ,BoxVolume
           ,MT
           ,BOXTONO
           ,BOXNO
           ,Totsumcount
           ,Boxsumcount
           ,OrderDate)
  VALUES
            (@guid
           ,@CustomName
           ,@GoodsTypeEnName
           ,@CustomStyleName
           ,@CustomStyleCode
           ,@SizeName
           ,@TotalCount
           ,@CutNo
           ,@ManufactureOrder
           ,@CustomPO
           ,@ColorGroupName
           ,@BoxSize
           ,@BoxNoTotal
           ,@PerCount
           ,@perCountTotal
           ,@NW
           ,@TNW
           ,@GW
           ,@TGW
           ,@BoxVolume
           ,@MT
           ,@BOXTONO
           ,@BOXNO
           ,@Totsumcount
           ,@Boxsumcount
           ,@OrderDate);";

            SqlParameter[] sps =
               {
                       new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value= pk.guid },
                        new SqlParameter("@CustomName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.CustomName) },
                        new SqlParameter("@GoodsTypeEnName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.GoodsTypeEnName) },
                        new SqlParameter("@CustomStyleName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.CustomStyleName) },
                        new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.CustomStyleCode) },
                        new SqlParameter("@SizeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.SizeName) },
                        new SqlParameter("@TotalCount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.TotalCount) },
                        new SqlParameter("@CutNo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.CutNo) },
                        new SqlParameter("@ManufactureOrder",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.ManufactureOrder) },
                        new SqlParameter("@CustomPO",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.CustomPO) },
                        new SqlParameter("@ColorGroupName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.ColorGroupName) },
                        new SqlParameter("@BoxSize",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.BoxSize) },
                        new SqlParameter("@BoxNoTotal",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.BoxNoTotal) },
                        new SqlParameter("@PerCount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.PerCount) },
                        new SqlParameter("@perCountTotal",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.perCountTotal) },
                        new SqlParameter("@NW",SqlDbType.Float) {Value= SqlHelper.ToDbValue(pk.NW) },
                        new SqlParameter("@TNW",SqlDbType.Float) {Value= SqlHelper.ToDbValue(pk.TNW) },
                        new SqlParameter("@GW",SqlDbType.Float) {Value= SqlHelper.ToDbValue(pk.GW) },
                        new SqlParameter("@TGW",SqlDbType.Float) {Value= SqlHelper.ToDbValue(pk.TGW) },
                        new SqlParameter("@BoxVolume",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.BoxVolume) },
                        new SqlParameter("@MT",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.MT) },
                        new SqlParameter("@BOXTONO",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.BOXTONO) },
                        new SqlParameter("@BOXNO",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.BOXNO) },
                        new SqlParameter("@Totsumcount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.Totsumcount) },
                        new SqlParameter("@Boxsumcount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.Boxsumcount) },
                        new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.OrderDate) }
            };
            SqlHelper.ExecuteNonQuery(sql, sps);

        }
        public void pkUpDb(PackList pk, string guid)
        {
            String sql = @" UPDATE T_PackList   SET
            CustonName=@CustonName
           ,GoodsTypeEnName=@GoodsTypeEnName
           ,CustoStyleName=@CustoStyleName
           ,CustomStyleCode=CustomStyleCode
           ,SizeName=@SizeName
           ,TotalCount=@TotalCount
           ,CutNo=@CutNo
           ,ManufactureOrder=@ManufactureOrder
           ,CustomPO=@CustomPO
           ,ColorGroupName=@ColorGroupName
           ,BoxSize=@BoxSize
           ,BoxNoTotal=@BoxNoTotal
           ,PerCount=@PerCount
           ,perCountTotal=@perCountTotal
           ,NW=@NW
           ,TNW=@TNW
           ,GW=@GW
           ,TGW=@TGW
           ,BoxVolume=@BoxVolume
           ,MT=@MT
           ,BOXTONO=@BOXTONO
           ,BOXNO=@BOXNO
           ,Totsumcount=@Totsumcount
           ,Boxsumcount=@Boxsumcount
            ,OrderDate=@OrderDate WHERE  guid= '" + guid + "'";

            SqlParameter[] sps =
               {
                    //   new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value= pk.guid },
                        new SqlParameter("@CustomName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.CustomName) },
                        new SqlParameter("@GoodsTypeEnName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.GoodsTypeEnName) },
                        new SqlParameter("@CustomStyleName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.CustomStyleName) },
                        new SqlParameter("@CustomStyleCode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.CustomStyleCode) },
                        new SqlParameter("@SizeName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.SizeName) },
                        new SqlParameter("@TotalCount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.TotalCount) },
                        new SqlParameter("@CutNo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.CutNo) },
                        new SqlParameter("@ManufactureOrder",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.ManufactureOrder) },
                        new SqlParameter("@CustomPO",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.CustomPO) },
                        new SqlParameter("@ColorGroupName",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.ColorGroupName) },
                        new SqlParameter("@BoxSize",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.BoxSize) },
                        new SqlParameter("@BoxNoTotal",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.BoxNoTotal) },
                        new SqlParameter("@PerCount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.PerCount) },
                        new SqlParameter("@perCountTotal",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.perCountTotal) },
                        new SqlParameter("@NW",SqlDbType.Float) {Value= SqlHelper.ToDbValue(pk.NW) },
                        new SqlParameter("@TNW",SqlDbType.Float) {Value= SqlHelper.ToDbValue(pk.TNW) },
                        new SqlParameter("@GW",SqlDbType.Float) {Value= SqlHelper.ToDbValue(pk.GW) },
                        new SqlParameter("@TGW",SqlDbType.Float) {Value= SqlHelper.ToDbValue(pk.TGW) },
                        new SqlParameter("@BoxVolume",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.BoxVolume) },
                        new SqlParameter("@MT",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.MT) },
                        new SqlParameter("@BOXTONO",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.BOXTONO) },
                        new SqlParameter("@BOXNO",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.BOXNO) },
                        new SqlParameter("@Totsumcount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.Totsumcount) },
                        new SqlParameter("@Boxsumcount",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.Boxsumcount) },
                         new SqlParameter("@OrderDate",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pk.OrderDate) }
            };
            SqlHelper.ExecuteNonQuery(sql, sps);

        }
        public DataTable getCodeFromPackList(string CustomStyleCode)
        {
            String sql = @"select * from  T_PackList where CustomStyleCode ='" + CustomStyleCode + "';";
            DataTable table = SqlHelper.ExecuteReader(sql);
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {

                return table;
            }

        }
        public void delCodeFromPackList(string CustomStyleCode)
        {
            String sql = @"DELETE  dbo.T_PackList WHERE CustomStyleCode ='" + CustomStyleCode + "';";
            SqlHelper.ExecuteNonQuery(sql);
           // SqlHelper.ExecuteReader(sql);
            

        }
        public void pkboxUpDb(packlistbox pkbox)
        {
            String sql = @"INSERT INTO T_BoxPackList
           (Guid
           ,PC
           ,BoxSize
           ,MT
           ,CCBM
           ,CTNS
           ,CBM
           ,SizeTo
           ,CoutomCode)
     VALUES
            (@Guid
           ,@PC
           ,@BoxSize
           ,@MT
           ,@CCBM
           ,@CTNS
           ,@CBM
           ,@SizeTo
           ,@CoutomCode);";

            SqlParameter[] sps =
               {
                // new SqlParameter("@DeptName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(  deptrow.DeptName) },
                        new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value= pkbox.guid },
                        new SqlParameter("@PC",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pkbox.PC) },
                        new SqlParameter("@BoxSize",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pkbox.BoxSize) },
                        new SqlParameter("@MT",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pkbox.MT) },
                        new SqlParameter("@CCBM",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pkbox.CCBM) },
                        new SqlParameter("@CTNS",SqlDbType.Int) {Value= SqlHelper.ToDbValue(pkbox.CTNS) },
                        new SqlParameter("@CBM",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pkbox.CBM) },
                        new SqlParameter("@SizeTo",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pkbox.SizeTo) },
                        new SqlParameter("@CoutomCode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(pkbox.CoutomCode) }

            };
            SqlHelper.ExecuteNonQuery(sql, sps);

        }
        public void MTphotoUpDb(byte[] picMTphoto, string CoutomCode)
        {
            String sql = @"INSERT INTO T_PackMT
           (Guid
           ,MTphoto
           ,CoutomCode)
     VALUES
            (@Guid
           ,@MTphoto
           ,@CoutomCode);";

            SqlParameter[] sps =
               {
                // new SqlParameter("@DeptName",SqlDbType.NVarChar) {Value=SqlHelper.ToDbValue(  deptrow.DeptName) },
                        new SqlParameter("@Guid",SqlDbType.UniqueIdentifier) {Value= Guid.NewGuid() },
                        new SqlParameter("@MTphoto",SqlDbType.Image) {Value= SqlHelper.ToDbValue(picMTphoto) },
                        new SqlParameter("@CoutomCode",SqlDbType.NVarChar) {Value= SqlHelper.ToDbValue(CoutomCode) }

            };
            SqlHelper.ExecuteNonQuery(sql, sps);

        }
        public void MTphotoUpDbByguid(byte[] picMTphoto, string guid)
        {
            String sql = @"UPDATE T_PackMT   SET MTphoto = @MTphoto WHERE guid='" + guid + "';";

            SqlParameter[] sps =
               {
                new SqlParameter("@MTphoto",SqlDbType.Image) {Value= SqlHelper.ToDbValue(picMTphoto) }
            };
            SqlHelper.ExecuteNonQuery(sql, sps);
        }
        public DataTable getMTphoto(string CoutomCode)
        {
            String sql = @"SELECT Guid  FROM T_PackMT  where CoutomCode = '" + CoutomCode + "'";
            DataTable tb = SqlHelper.ExecuteReader(sql);
            return tb;
        }
        public DataTable pkGetDb(string CustomStyleCode)
        {
            String sql = @"select * from  T_PackList where CustomStyleCode ='" + CustomStyleCode + "' order by boxno,SizeName";
            DataTable table = SqlHelper.ExecuteReader(sql);
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {

                return table;
            }



        }
        public DataTable getboxPkFromDB(string StyleCode)
        {
            String sql = @"select * from T_BoxPackList where coutomcode ='" + StyleCode + "'";
            DataTable table = SqlHelper.ExecuteReader(sql);
            if (table.Rows.Count <= 0)
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
