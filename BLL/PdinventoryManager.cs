using DAL;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PdinventoryManager
    {
        PdinventoryService pvs = new PdinventoryService();
        public List<string> getwarehouse()
        {
            List<string> warehouses = pvs.getwarehouse();
            return warehouses;
        }
        public List<Pdinfos> getcustomstyle(List<string> strkey, List<string> strvalue,bool issum)
        {
            DataTable dt = pvs.getcustomstyle(strkey, strvalue);           
            List<Pdinfos> singdt = new List<Pdinfos>();
            // Pdinfos singdt = new Pdinfos();
            //计算每个指令的箱数
            if (dt.Rows.Count > 0)
            {


                if (!issum)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Pdinfos pdfs = new Pdinfos();
                        pdfs.CustomName = dt.Rows[i]["CustomName"].ToString();
                        pdfs.Name = dt.Rows[i]["Name"].ToString();
                        pdfs.Code = dt.Rows[i]["Code"].ToString();
                        pdfs.CustomStyleCode = dt.Rows[i]["CustomStyleCode"].ToString();
                        pdfs.OrderDate = dt.Rows[i]["OrderDate"].ToString();
                        pdfs.CartonBarcode = dt.Rows[i]["CartonBarcode"].ToString();
                        pdfs.WH = dt.Rows[i]["WH"].ToString();
                        pdfs.BOXNO = dt.Rows[i]["BOXNO"].ToString();
                        pdfs.Boxsumcount = dt.Rows[i]["Boxsumcount"].ToString();
                        pdfs.TotalCount = dt.Rows[i]["TotalCount"].ToString();
                        singdt.Add(pdfs);
                    }
                    return singdt;                    
                }




                //提取所有的指令号
                #region 提取所有的指令号
                bool ifadd = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Pdinfos pdfs = new Pdinfos();
                    if ((i - 1) < 0)
                    {

                        pdfs.CustomName = dt.Rows[i]["CustomName"].ToString();
                        pdfs.Name = dt.Rows[i]["Name"].ToString();
                        pdfs.Code = dt.Rows[i]["Code"].ToString();
                        pdfs.CustomStyleCode = dt.Rows[i]["CustomStyleCode"].ToString();
                        pdfs.OrderDate = dt.Rows[i]["OrderDate"].ToString();
                        pdfs.WH = dt.Rows[i]["WH"].ToString();
                        pdfs.Boxsumcount = dt.Rows[i]["Boxsumcount"].ToString();
                        pdfs.TotalCount = dt.Rows[i]["TotalCount"].ToString();
                        //  singdt.WH = dt.Rows[i]["WH"].ToString();
                        ifadd = true;
                    }
                    else
                    {
                        // if (dt.Rows[i]["CustomStyleCode"].ToString() != dt.Rows[i - 1]["CustomStyleCode"].ToString())//跟上一个比较，如果混乱了顺序有问题
                        for (int j = 0; j < singdt.Count; j++)
                        {
                            if (dt.Rows[i]["CustomStyleCode"].ToString() != singdt[j].CustomStyleCode.ToString())
                            {
                                pdfs.CustomName = dt.Rows[i]["CustomName"].ToString();
                                pdfs.Name = dt.Rows[i]["Name"].ToString();
                                pdfs.Code = dt.Rows[i]["Code"].ToString();
                                pdfs.CustomStyleCode = dt.Rows[i]["CustomStyleCode"].ToString();
                                pdfs.OrderDate = dt.Rows[i]["OrderDate"].ToString();
                                pdfs.WH = dt.Rows[i]["WH"].ToString();
                                pdfs.Boxsumcount = dt.Rows[i]["Boxsumcount"].ToString();
                                pdfs.TotalCount = dt.Rows[i]["TotalCount"].ToString();

                                ifadd = true;
                                //全部不相等，添加，
                                //有一个相等，跳出
                            }
                            else
                            {
                                ifadd = false;
                                continue;
                            }

                        }

                    }
                    if (ifadd)
                    {
                        singdt.Add(pdfs);
                    }

                }


            }
            #endregion
            #region 计算箱数
          //  int counts = 0;
            //List<Pdinfos> pdlist = new List<Pdinfos>();

            for (int j = 0; j < singdt.Count; j++)
            {
               // Pdinfos pdis = new Pdinfos();
               // pdis.CustomStyleCode = singdt[j].ToString();

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (dt.Rows[i]["CustomStyleCode"].ToString() == singdt[j].CustomStyleCode.ToString())
                    {
                      //  counts++;
                        singdt[j].pdcounts++;

                        //   pdis.pdcounts++;
                    }
                }
               // singdt[j].pdcounts= counts;

                // pdlist.Add(pdis);
            }

            #endregion
            return singdt;

        }
       
        public List<BoxAlls> getBoxAllbyCartonBarcode(string CustomStyleCode,string wherestr)
        {
            DataTable dt = pvs.getBoxAllbyCartonBarcode(CustomStyleCode,wherestr);
            List<BoxAlls> boxall = new List<BoxAlls>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BoxAlls boxs = new BoxAlls();
                    boxs.sumcount = Convert.ToInt32( dt.Rows[i]["sumcount"].ToString());
                    boxs.SizeName = dt.Rows[i]["SizeName"].ToString();
                    boxs.CartonBarcode = dt.Rows[i]["CartonBarcode"].ToString();

                    boxall.Add(boxs);
                }
              //  return boxall;

            }
            return boxall;

        }
        public DataTable getnopdboxno(string CustomStyleCode)
        {
            return pvs.getnopdboxno(CustomStyleCode);

        }
        public class Pdinfos
        {
            public string CustomName { set; get; }
            public string Name { set; get; }
            public string Code { set; get; }
            public string CustomStyleCode { set; get; }
            public string OrderDate { set; get; }
            public string WH { set; get; }
            public int pdcounts { set; get; }
            public string CartonBarcode { set; get; }

            public string BOXNO { set; get; }
            public string Boxsumcount { set; get; }
            public string TotalCount { set; get; }
            //  public string ShipOut { set; get; }
        }
        public class BoxAlls
        { 
            public string CartonBarcode { set; get; }
            public string SizeName { set; get; }
            public int sumcount { set; get; }

        }
        public int updwhs(string whs,string customstylecode)
        {
            return pvs.updwhs(whs, customstylecode);
        }
        public List<pdinventory> getpdfiletotxt(string whs)
        {           
           return  pvs.getpdfiletotxt(whs);            
        }
        
    }
}
