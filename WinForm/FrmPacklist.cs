using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;



namespace WinForm
{
    public partial class FrmPacklist : Form
    {
        public FrmPacklist()
        {
            InitializeComponent();
            this.dgvOrder.AutoGenerateColumns = false;
            this.dgvPacklist.AutoGenerateColumns = false;
            this.dgvPacklistShip .AutoGenerateColumns = false;
            this.dgvPackOrder.AutoGenerateColumns = false;

        }

        static FrmPacklist frm;
        public static FrmPacklist GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmPacklist();
            }
            return frm;
        }


        List<MODEL.doc_Order> listorder = new List<MODEL.doc_Order>();
        List<MODEL.T_PackList> tpacklist = new List<MODEL.T_PackList>();
        List<MODEL.doc_PackList> docpacklist = new List<MODEL.doc_PackList>();
        List<MODEL.doc_PackList> docpacklist1 = new List<MODEL.doc_PackList>();
        List<MODEL.doc_PackListShip> pshiplist = new List<MODEL.doc_PackListShip>();
        List<MODEL.doc_PackListShip> pshiplist1 = new List<MODEL.doc_PackListShip>();
        BLL.doc_OrderManager om = new BLL.doc_OrderManager();
        BLL.doc_PackListManager plm = new BLL.doc_PackListManager();
        BLL.doc_PackListShipManager pship = new BLL.doc_PackListShipManager();
        //  int check = 0;




        private void button1_Click(object sender, EventArgs e)
        {

            docpacklist = null;
            docpacklist = plm.GetToPacklist(YearMounth.Text);

            if (plm.GetPackListCount(YearMounth.Text) == docpacklist.Count)
            {
            //    MessageBox.Show("已經接轉完畢總共有" + docpacklist.Count.ToString() + "筆資料");
             //   return;
            };



            test.Clear();



            if (om.GetOrderW(YearMounth.Text) == null)
            {
              //  MessageBox.Show("OK裝箱數量與訂單數量一致");
                //if (check == 0)
                //{

            //    return;
                //}

            };

            //check = 0;
            int cc = 0;
            listorder = null;
            //if(check==1)
            //{
            //    MessageBox.Show()
            //}
            listorder = om.GetOrder(YearMounth.Text);

            for (int c = 0; c < listorder.Count; c++)
            {
                test.Clear();


                int? kk = om.GetPacklisttotalcount(listorder[c].CustomStyleCode);
                if (kk == null)
                {
                    kk = 0;
                }
                om.updatePacklisttotalcount(listorder[c].CustomStyleCode, kk.ToString());
                cc++;
                test.AppendText(listorder[c].CustomStyleCode.ToString() + "\r\n" + cc.ToString() + " / " + listorder.Count.ToString());

            }
            MessageBox.Show("更新OK");



        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (om.GetOrderW(YearMounth.Text) == null)
            {
                MessageBox.Show("OK裝箱數量與訂單數量一致");
            }
            this.dgvOrder.DataSource = om.GetOrderW(YearMounth.Text);
        }

        private void getInnerCode()
        {
            docpacklist = null;
            docpacklist = plm.GetInnerNeedASICS(YearMounth.Text);
            string myInnerBarcode = "";
            string myInnerBarcode1 = "";
//            int mBarcodeCount = 0;


            if (docpacklist == null || docpacklist.Count <= 0)
            {
               MessageBox.Show("OK都更新了");
               // return;
            }
            for (int b = 0; b < docpacklist.Count; b++)
            {
                test.Clear();
                if (docpacklist[b].Type == "JAN")
                { 
                myInnerBarcode1 = plm.GetInnerBarcodeEAN(docpacklist[b].Name, docpacklist[b].Color, docpacklist[b].SizeName);
            }     
                else
                {
                    myInnerBarcode1 = "";

                }
                // if(myInnerBarcode1=="")
                //{
                //    myInnerBarcode1 = "notEUState";
                //}

                if(docpacklist[b].Type==null)
                    {
                    MessageBox.Show("Type為空,請查目的地");
                    return;
                }
                if (docpacklist[b].SizeName == null)
                {
                    MessageBox.Show("SizeName為空,請查尺碼");
                    return;
                }
                if (docpacklist[b].Color == null)
                {
                    MessageBox.Show("Color為空,請查配色");
                    return;
                }
                if (docpacklist[b].Name == null)
                {
                    MessageBox.Show("Name為空,請查型體");
                    return;
                }

                myInnerBarcode = plm.GetInnerBarcode(docpacklist[b].Name, docpacklist[b].Color, docpacklist[b].SizeName, docpacklist[b].Type);


                if (myInnerBarcode != "")
                {
                    try
                    {
     
                        plm.updatePackListBarcode(docpacklist[b].Name, docpacklist[b].Color, docpacklist[b].SizeName, docpacklist[b].Type, myInnerBarcode, myInnerBarcode1);
                        myInnerBarcode = "";
                        myInnerBarcode1 = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                test.AppendText(docpacklist[b].Name + "\r\n" + (b + 1).ToString() + " / " + docpacklist.Count.ToString());
            }

            MessageBox.Show("OK");
        }
        int repacklist = 0;
        private void btnPackListIn_Click(object sender, EventArgs e)
        {
            test.Clear();

            //Table 定義數據類型
            DataTable pl = new DataTable();
            //from t_packlist
            pl.Columns.Add("T_PackListGuid", typeof(SqlGuid));
            pl.Columns.Add("CustomStyleName");
            pl.Columns.Add("CustomStyleCode");
            pl.Columns.Add("CustomName");
            pl.Columns.Add("OrderDate");
            pl.Columns.Add("CustomPO");
            pl.Columns.Add("ManufactureOrder");
            pl.Columns.Add("CutNo");
            pl.Columns.Add("BOXNO", typeof(int));
            pl.Columns.Add("BOXTONO");
            pl.Columns.Add("BoxNoTotal");
            pl.Columns.Add("PerCount");
            pl.Columns.Add("SizeName");
            pl.Columns.Add("TotalCount");
            pl.Columns.Add("BoxSize");
            //from doc_order 
            pl.Columns.Add("doc_OrderGuid", typeof(SqlGuid));
            pl.Columns.Add("Style");
            pl.Columns.Add("Name");
            pl.Columns.Add("Color");
            pl.Columns.Add("Code");
            pl.Columns.Add("CustomBuyName");
            pl.Columns.Add("AimArea");
            pl.Columns.Add("ShipMentDate", typeof(SqlDateTime));
            pl.Columns.Add("CartonBarcodeNeed");
            pl.Columns.Add("GoodsTypeName");
            pl.Columns.Add("Type");
            //doc_packlist
            pl.Columns.Add("Guid", typeof(SqlGuid));
            pl.Columns.Add("BarcodeCount", typeof(SqlInt32));
            pl.Columns.Add("CartonBarcode");
            // pl.Columns.Add("InnerBarcode");


            docpacklist = null;
            docpacklist = plm.GetToPacklist(YearMounth.Text);

            int bb = 0;
            if (docpacklist == null)
            {
                MessageBox.Show("沒有該年月裝箱明細的資料,請找小明接轉");
                return;
            };


            if (plm.GetPackListCount(YearMounth.Text) == docpacklist.Count)
            {
                MessageBox.Show("已經接轉完畢總共有" + docpacklist.Count.ToString() + "筆資料");
                //check = 1;
           //     return;
            };

            if (plm.GetPackListCount(YearMounth.Text) != 0)
            {
               // MessageBox.Show("資料有誤請" + "\r\n" + "接轉裝箱數量" + "\r\n" + "查核裝箱數量" + "\r\n" + "找出錯誤訂單修改後單筆接轉");
                if (MessageBox.Show("重新接轉需要半小時以上 \r\n接轉裝箱明細請按<確定>", "标题", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    repacklist = 1;
                }
                else
                {
                    if (MessageBox.Show("新接轉(當月已經掃描數不能接轉)\r\n接轉裝箱明細請按<確定>", "标题", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        repacklist = 0;
                    }
                    else
                    {
                        return;
                    }
                }

            }

                #region datatable   使用SQLBULK     
                plm.DelPackListOrderALL(YearMounth.Text);

                for (int b = 0; b < docpacklist.Count; b++)
                {

                    test.Clear();
                    pl.Rows.Add();

                    //--------- from T_PackList
                    pl.Rows[b]["T_PackListGuid"] = docpacklist[b].T_PackListGuid;
                    pl.Rows[b]["CustomStyleName"] = docpacklist[b].CustomStyleName;
                    pl.Rows[b]["CustomStyleCode"] = docpacklist[b].CustomStyleCode;//訂單號
                    pl.Rows[b]["CustomName"] = docpacklist[b].CustomName;//客戶
                    pl.Rows[b]["OrderDate"] = docpacklist[b].OrderDate;//客戶
                    pl.Rows[b]["CustomPO"] = docpacklist[b].CustomPO;//
                    pl.Rows[b]["ManufactureOrder"] = docpacklist[b].ManufactureOrder;//
                    pl.Rows[b]["CutNo"] = docpacklist[b].CutNo;//
                    pl.Rows[b]["BOXNO"] = docpacklist[b].BOXNO; //箱號
                    pl.Rows[b]["BOXTONO"] = docpacklist[b].BOXTONO; //  相同裝箱方式的起始箱號
                    pl.Rows[b]["BoxNoTotal"] = docpacklist[b].BoxNoTotal;   //   BOXTONO 的箱子數量
                    pl.Rows[b]["PerCount"] = docpacklist[b].PerCount;//   BOXNO 這一箱的數量裝幾雙   BOXNOPerCount     
                    pl.Rows[b]["SizeName"] = docpacklist[b].SizeName;     //   尺碼
                    pl.Rows[b]["TotalCount"] = docpacklist[b].TotalCount; //   BOXNO 這一箱的 尺碼 裝幾雙 BOXNOSizeCount*** 單碼裝則與BOXNOPerCount 數量相同
                    pl.Rows[b]["BoxSize"] = docpacklist[b].BoxSize;     // 外箱的尺寸 
                                                                        //------ from doc_Order
                    pl.Rows[b]["doc_OrderGuid"] = docpacklist[b].doc_OrderGuid;
                    pl.Rows[b]["Style"] = docpacklist[b].Style;
                    pl.Rows[b]["Name"] = docpacklist[b].Name;
                    pl.Rows[b]["Color"] = docpacklist[b].Color;
                    pl.Rows[b]["Code"] = docpacklist[b].Code;
                    pl.Rows[b]["CustomBuyName"] = docpacklist[b].CustomBuyName;
                    pl.Rows[b]["AimArea"] = docpacklist[b].AimArea;
                    pl.Rows[b]["ShipMentDate"] = docpacklist[b].ShipMentDate;
                    pl.Rows[b]["CartonBarcodeNeed"] = docpacklist[b].CartonBarcodeNeed;
                    pl.Rows[b]["GoodsTypeName"] = docpacklist[b].GoodsTypeName;
                    pl.Rows[b]["Type"] = docpacklist[b].Type;
                    //--- doc_packlist
                    //---  --Guid(doc_packlist), OrderCount,CartonBarcode,InnerBarcode,SizeNo,BarcodeCount
                    pl.Rows[b]["Guid"] = System.Guid.NewGuid();

                    if (docpacklist[b].CutNo != null && docpacklist[b].CustomName == "ASICS")
                    {
                        //外箱条码产生....
                        int cartonno = docpacklist[b].BOXNO.Value + 10000;

                        pl.Rows[b]["CartonBarcode"] = docpacklist[b].CutNo + cartonno.ToString().Substring(1, 4); //外箱條碼產生;        

                    }
                    else if (docpacklist[b].CutNo == null && docpacklist[b].CustomName == "ASICS")
                    {

                        int cartonno = docpacklist[b].BOXNO.Value + 10000;
                        pl.Rows[b]["CartonBarcode"] = docpacklist[b].CustomPO.Substring(4) + docpacklist[b].ManufactureOrder.Substring(3) + cartonno.ToString().Substring(1, 4);

                    }
                    else
                    {
                        pl.Rows[b]["CartonBarcode"] = docpacklist[b].CartonBarcode;
                    };
                // 单一订单可以接转BarcodeCount ,用这接转要跑很久,程序没有问题应该不用这样转
                if (repacklist == 1)
                {
                    pl.Rows[b]["BarcodeCount"] = plm.GetPackListInnerCount(pl.Rows[b]["CartonBarcode"].ToString(), pl.Rows[b]["OrderDate"].ToString(), pl.Rows[b]["SizeName"].ToString());

                }
                else
                {
                     pl.Rows[b]["BarcodeCount"] = 0;
                }

     


                    //if (docpacklist[b].CustomName == "ASICS")
                    //{
                    // pl.Rows[b]["InnerBarcode"] = plm.GetInnerBarcode(docpacklist[b].Name, docpacklist[b].Color, docpacklist[b].SizeName, docpacklist[b].Type);
                    //}
                    //else
                    //{
                    //    pl.Rows[b]["InnerBarcode"]= docpacklist[b].InnerBarcode;
                    //}

                    test.AppendText(pl.Rows[b]["CustomStyleCode"] + "\r\n" + (bb + 1).ToString() + " / " + docpacklist.Count.ToString());
                    bb++;

                }
                plm.GetPacklistBulkPackList(pl);
            repacklist = 0;
            #endregion






                #region   修正APL外箱编号尾数

                int mno = 0;
                docpacklist = null;
            // APL条码订单 且 为单码装
                docpacklist = plm.FirstBoxnoPrintAPL(YearMounth.Text);
                for (int b = 0; b < docpacklist.Count; b++)
                {

                        //数量跟第一盒不一样的第一张尾数箱号  例如 SW171318  第44箱
                        int? leftboxno1 = plm.LeftBoxno1(docpacklist[b].CustomStyleCode.ToString());
                    if (leftboxno1 != null)
                    {
                        docpacklist1 = null;
                        int cartonno = (int)leftboxno1;
                        docpacklist1 = plm.LeftBoxno(docpacklist[b].CustomStyleCode.ToString(), cartonno);
                        for (int c = 0; c < docpacklist1.Count; c++)
                        {
                        int mbno = docpacklist1[c].BOXNO.Value - (int)leftboxno1 + 9001;
                            string mcarton = docpacklist1[c].CartonBarcode;
                            string mtr = mcarton.Substring(0, mcarton.Length - 4) + mbno.ToString();
                            plm.updatePackListCartonBarcode(docpacklist1[c].CustomStyleCode.ToString(), docpacklist1[c].BOXNO.Value, mtr);
                            //            MessageBox.Show(mtr + "--" + docpacklist1[c].CartonBarcode.ToString() + "----" + docpacklist1[c].BOXNO.ToString() + " / " + docpacklist1.Count.ToString());

                        }
                    }

                    test.Clear();
                    test.AppendText("APL外箱不規格尾數" +"\r\n"  +(mno + 1).ToString() + " / " + docpacklist.Count.ToString());
                    mno++;
                }
            #endregion




            DialogResult result =  MessageBox.Show("接轉裝箱明細完成，需要接转内盒条码，是否现在接转内盒条码", "是否接转内盒条码！",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                getInnerCode();
            }
            MessageBox.Show("接转完成OK--請立刻接轉成品裝箱明細,否則會有QA刷了沒有寫入裝箱明細的後續處理問題");

        }

        

        private void button3_Click_1(object sender, EventArgs e)
        {
            test.Clear();
            #region 

            //Table 定義數據類型
            DataTable pls = new DataTable();
            //from t_packlist
            pls.Columns.Add("Guid", typeof(SqlGuid));
            pls.Columns.Add("Style");
            pls.Columns.Add("Name");
            pls.Columns.Add("Color");
            pls.Columns.Add("Code");

            pls.Columns.Add("CustomStyleName");
            pls.Columns.Add("CustomStyleCode");
            pls.Columns.Add("CustomName");
            pls.Columns.Add("CustomBuyName");

            pls.Columns.Add("AimArea");
            pls.Columns.Add("OrderDate");
            pls.Columns.Add("ShipMentDate", typeof(SqlDateTime));
            pls.Columns.Add("CustomPO");

            pls.Columns.Add("ManufactureOrder");
            pls.Columns.Add("CutNo");
            pls.Columns.Add("BOXNO", typeof(SqlInt32));
            pls.Columns.Add("CartonBarcode");
            pls.Columns.Add("CartonBarcodeNeed");

            pls.Columns.Add("BoxSize");
            pls.Columns.Add("ScanIn", typeof(SqlInt32));
            pls.Columns.Add("ScanOut", typeof(SqlInt32));
            pls.Columns.Add("QAIn", typeof(SqlInt32));
            pls.Columns.Add("QAOut", typeof(SqlInt32));
            pls.Columns.Add("ShipOut");
            pls.Columns.Add("ShipScanTime");
            pls.Columns.Add("CarNo");

            docpacklist = null;
            docpacklist = plm.GetToPacklistShip(YearMounth.Text);

            int bb = 0;
            if (docpacklist == null)
            {
                MessageBox.Show("沒有該年月成品裝箱明細的資料,請接轉");
                return;
            };


            if (plm.GetPackListShipCount(YearMounth.Text) == docpacklist.Count)
            {
                if (MessageBox.Show("已經接轉完畢,重新接轉請按 < 確定>", "标题", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                }
                else
                {
                    MessageBox.Show("成品箱已經接轉完畢總共有" + docpacklist.Count.ToString() + "筆資料");
                    return;
                }
            };


            if (plm.GetPackListShipCount(YearMounth.Text) == 0)
            {
                #region datatable   使用SQLBULK     
                for (int b = 0; b < docpacklist.Count; b++)
                {
                    test.Clear();

                    pls.Rows.Add();
                    pls.Rows[b]["Guid"] = System.Guid.NewGuid();
                    pls.Rows[b]["Style"] = docpacklist[b].Style;
                    pls.Rows[b]["Name"] = docpacklist[b].Name;
                    pls.Rows[b]["Color"] = docpacklist[b].Color;
                    pls.Rows[b]["Code"] = docpacklist[b].Code;

                    pls.Rows[b]["CustomStyleName"] = docpacklist[b].CustomStyleName;
                    pls.Rows[b]["CustomStyleCode"] = docpacklist[b].CustomStyleCode;//訂單號
                    pls.Rows[b]["CustomName"] = docpacklist[b].CustomName;//客戶
                    pls.Rows[b]["CustomBuyName"] = docpacklist[b].CustomBuyName;

                    pls.Rows[b]["AimArea"] = docpacklist[b].AimArea;
                    pls.Rows[b]["OrderDate"] = docpacklist[b].OrderDate;//客戶
                    pls.Rows[b]["ShipMentDate"] = docpacklist[b].ShipMentDate;
                    pls.Rows[b]["CustomPO"] = docpacklist[b].CustomPO;//

                    pls.Rows[b]["ManufactureOrder"] = docpacklist[b].ManufactureOrder;//
                    pls.Rows[b]["CutNo"] = docpacklist[b].CutNo;//
                    pls.Rows[b]["BOXNO"] = docpacklist[b].BOXNO; //箱號
                    pls.Rows[b]["CartonBarcode"] = docpacklist[b].CartonBarcode; //外箱條碼
                    pls.Rows[b]["CartonBarcodeNeed"] = docpacklist[b].CartonBarcodeNeed; //外箱條碼打印

                    pls.Rows[b]["BoxSize"] = docpacklist[b].BoxSize;//     
                    pls.Rows[b]["ScanIn"] = 0;//                
                    pls.Rows[b]["ScanOut"] = 0;//     
                    pls.Rows[b]["QAIn"] = 0;//                
                    pls.Rows[b]["QAOut"] = 0;//                
                    pls.Rows[b]["ShipOut"] = "0";//       
                    pls.Rows[b]["ShipScanTime"] =null;//       

                    test.AppendText(pls.Rows[b]["CustomStyleCode"] + "\r\n" + (bb + 1).ToString() + " / " + docpacklist.Count.ToString());

                    bb++;


                }

                plm.GetPacklistBulkPackListShip(pls);
                MessageBox.Show("OK");



                #endregion
            }
            else
            {

                #region datatable   使用SQLBULK     刪除重新接轉, 保留現有紀錄訊息

                MessageBox.Show("開始,需要兩分鐘");
                pshiplist = null;
                  pshiplist= plm.GetToPacklistShipUpdate(YearMounth.Text);
                 MessageBox.Show("開始...");
                for (int b = 0; b < pshiplist.Count; b++)
                {
                    test.Clear();

                    pls.Rows.Add();
                    pls.Rows[b]["Guid"] = System.Guid.NewGuid();
                    pls.Rows[b]["Style"] = pshiplist[b].Style;
                    pls.Rows[b]["Name"] = pshiplist[b].Name;
                    pls.Rows[b]["Color"] = pshiplist[b].Color;
                    pls.Rows[b]["Code"] = pshiplist[b].Code;

                    pls.Rows[b]["CustomStyleName"] = pshiplist[b].CustomStyleName;
                    pls.Rows[b]["CustomStyleCode"] = pshiplist[b].CustomStyleCode;//訂單號
                    pls.Rows[b]["CustomName"] = pshiplist[b].CustomName;//客戶
                    pls.Rows[b]["CustomBuyName"] = pshiplist[b].CustomBuyName;

                    pls.Rows[b]["AimArea"] = pshiplist[b].AimArea;
                    pls.Rows[b]["OrderDate"] = pshiplist[b].OrderDate;//客戶
                    pls.Rows[b]["ShipMentDate"] = pshiplist[b].ShipMentDate;
                    pls.Rows[b]["CustomPO"] = pshiplist[b].CustomPO;//

                    pls.Rows[b]["ManufactureOrder"] = pshiplist[b].ManufactureOrder;//
                    pls.Rows[b]["CutNo"] = pshiplist[b].CutNo;//
                    pls.Rows[b]["BOXNO"] = pshiplist[b].BOXNO; //箱號
                    pls.Rows[b]["CartonBarcode"] = pshiplist[b].CartonBarcode; //外箱條碼
                    pls.Rows[b]["CartonBarcodeNeed"] = pshiplist[b].CartonBarcodeNeed; //外箱條碼打印

                    pls.Rows[b]["BoxSize"] = pshiplist[b].BoxSize;//    
                    if (pshiplist[b].ScanIn == null)
                    { pls.Rows[b]["ScanIn"] = 0; }else { pls.Rows[b]["ScanIn"] = pshiplist[b].ScanIn; }
                    if (pshiplist[b].ScanOut == null)
                    { pls.Rows[b]["ScanOut"] = 0; }  else { pls.Rows[b]["ScanOut"] = pshiplist[b].ScanOut; }
                    if (pshiplist[b].QAIn == null)
                    { pls.Rows[b]["QAIn"] = 0; }  else { pls.Rows[b]["QAIn"] = pshiplist[b].QAIn; }
                    if (pshiplist[b].QAOut == null)
                    { pls.Rows[b]["QAOut"] = 0; }    else { pls.Rows[b]["QAOut"] = pshiplist[b].QAOut; }
                    pls.Rows[b]["ShipOut"] = pshiplist[b].ShipOut;
                    pls.Rows[b]["ShipScanTime"] = pshiplist[b].ShipScanTime;
                    pls.Rows[b]["CarNo"] = pshiplist[b].CarNo;


                    test.AppendText(pls.Rows[b]["CustomStyleCode"] + "\r\n" + (bb + 1).ToString() + " / " + pshiplist.Count.ToString());

                    bb++;


                }
                plm.DelPackListShiptMonth(YearMounth.Text);
                plm.GetPacklistBulkPackListShip(pls);
                MessageBox.Show("OK");



                #endregion             

            }

///  this.dgvPacklist.DataSource = plm.EXCEPTPacklistShip(YearMounth.Text);



            #endregion

        }
        int fistboxbo;

        private void button5_Click(object sender, EventArgs e)
        {
            test.Clear();
            #region 

            //Table 定義數據類型
            DataTable pl = new DataTable();
            //from t_packlist
            pl.Columns.Add("T_PackListGuid", typeof(SqlGuid));
            pl.Columns.Add("CustomStyleName");
            pl.Columns.Add("CustomStyleCode");
            pl.Columns.Add("CustomName");
            pl.Columns.Add("OrderDate");
            pl.Columns.Add("CustomPO");
            pl.Columns.Add("ManufactureOrder");
            pl.Columns.Add("CutNo");
            pl.Columns.Add("BOXNO", typeof(SqlInt32));
            pl.Columns.Add("BOXTONO");
            pl.Columns.Add("BoxNoTotal");
            pl.Columns.Add("PerCount");
            pl.Columns.Add("SizeName");
            pl.Columns.Add("TotalCount");
            pl.Columns.Add("BoxSize");
            //from doc_order 
            pl.Columns.Add("doc_OrderGuid", typeof(SqlGuid));
            pl.Columns.Add("Style");
            pl.Columns.Add("Name");
            pl.Columns.Add("Color");
            pl.Columns.Add("Code");
            pl.Columns.Add("CustomBuyName");
            pl.Columns.Add("AimArea");
            pl.Columns.Add("ShipMentDate", typeof(SqlDateTime));
            pl.Columns.Add("CartonBarcodeNeed");
            pl.Columns.Add("GoodsTypeName");
            pl.Columns.Add("Type");
            //doc_packlist
            pl.Columns.Add("Guid", typeof(SqlGuid));
            pl.Columns.Add("BarcodeCount", typeof(SqlInt32));
            pl.Columns.Add("CartonBarcode");
            pl.Columns.Add("InnerBarcode");
            pl.Columns.Add("InnerBarcode1");


            docpacklist = null;
            string myod = txtOrder.Text;
            if (myod == "")
            {
                MessageBox.Show("訂單欄位為空");
                return;
            };
            //删除前先确定是否为混码装 ,单码装第一张单指有一笔,
            fistboxbo = plm.FirstBoxno(myod);
           // leftboxno1 = plm.LeftBoxno1(myod);
            //1.----先刪除掉 該訂單資料 ,預防NINA訂單資料做錯重新轉

            plm.DelPackListOrder(myod);


            //2.----重新接轉訂單年月的資料
            docpacklist = plm.GetToPacklistOrder(myod);
            if(docpacklist==null)
            {
                MessageBox.Show("没有此订单");
                return;
            }
            int bb = 0;
            #region datatable   使用SQLBULK     
            for (int b = 0; b < docpacklist.Count; b++)
            {

                test.Clear();
                pl.Rows.Add();
                //--------- from T_PackList
                pl.Rows[b]["T_PackListGuid"] = docpacklist[b].T_PackListGuid;
                pl.Rows[b]["CustomStyleName"] = docpacklist[b].CustomStyleName;
                pl.Rows[b]["CustomStyleCode"] = docpacklist[b].CustomStyleCode;//訂單號
                pl.Rows[b]["CustomName"] = docpacklist[b].CustomName;//客戶
                pl.Rows[b]["OrderDate"] = docpacklist[b].OrderDate;//客戶
                pl.Rows[b]["CustomPO"] = docpacklist[b].CustomPO;//
                pl.Rows[b]["ManufactureOrder"] = docpacklist[b].ManufactureOrder;//
                pl.Rows[b]["CutNo"] = docpacklist[b].CutNo;//
                pl.Rows[b]["BOXNO"] = docpacklist[b].BOXNO; //箱號
                pl.Rows[b]["BOXTONO"] = docpacklist[b].BOXTONO; //  相同裝箱方式的起始箱號
                pl.Rows[b]["BoxNoTotal"] = docpacklist[b].BoxNoTotal;   //   BOXTONO 的箱子數量
                pl.Rows[b]["PerCount"] = docpacklist[b].PerCount;//   BOXNO 這一箱的數量裝幾雙   BOXNOPerCount     
                pl.Rows[b]["SizeName"] = docpacklist[b].SizeName;     //   尺碼
                pl.Rows[b]["TotalCount"] = docpacklist[b].TotalCount; //   BOXNO 這一箱的 尺碼 裝幾雙 BOXNOSizeCount*** 單碼裝則與BOXNOPerCount 數量相同
                pl.Rows[b]["BoxSize"] = docpacklist[b].BoxSize;     // 外箱的尺寸 
                                                                    //------ from doc_Order
                pl.Rows[b]["doc_OrderGuid"] = docpacklist[b].doc_OrderGuid;
                pl.Rows[b]["Style"] = docpacklist[b].Style;
                pl.Rows[b]["Name"] = docpacklist[b].Name;
                pl.Rows[b]["Color"] = docpacklist[b].Color;
                pl.Rows[b]["Code"] = docpacklist[b].Code;
                pl.Rows[b]["CustomBuyName"] = docpacklist[b].CustomBuyName;
                pl.Rows[b]["AimArea"] = docpacklist[b].AimArea;
                pl.Rows[b]["ShipMentDate"] = docpacklist[b].ShipMentDate;
                pl.Rows[b]["CartonBarcodeNeed"] = docpacklist[b].CartonBarcodeNeed;
                pl.Rows[b]["GoodsTypeName"] = docpacklist[b].GoodsTypeName;
                pl.Rows[b]["Type"] = docpacklist[b].Type;

                                if (docpacklist[b].Type == "JAN")
                {
                    pl.Rows[b]["InnerBarcode1"] = plm.GetInnerBarcodeEAN(docpacklist[b].Name, docpacklist[b].Color, docpacklist[b].SizeName);
                }     
                else
                {
                    pl.Rows[b]["InnerBarcode1"] = "";

                }

          //      pl.Rows[b]["InnerBarcode1"] = plm.GetInnerBarcodeEAN(docpacklist[b].Name, docpacklist[b].Color, docpacklist[b].SizeName);
                // if(myInnerBarcode1=="")
                //{
                //    myInnerBarcode1 = "notEUState";
                //}
                pl.Rows[b]["InnerBarcode"]  = plm.GetInnerBarcode(docpacklist[b].Name, docpacklist[b].Color, docpacklist[b].SizeName, docpacklist[b].Type);

                pl.Rows[b]["Guid"] = System.Guid.NewGuid();
                
                if (docpacklist[b].CutNo != null && docpacklist[b].CustomName == "ASICS")
                {
                    int cartonno = docpacklist[b].BOXNO.Value + 10000;

                    //APL 尾数没有规则条码的情况
                    //isAPL==1(是APL条码&&FistBoxno==1(除去混码,因为混码不可能有尾数)&& 与b=1 之 数量不同,产生新的条码尾数号

                    if (plm.PrintAPL(docpacklist[b].CustomBuyName.ToString()) >= 1 &&  fistboxbo==1)
                        {  
                         //     if (leftboxno != null)
                           //       {    
                                  //后面更新在改  
                                  ///cartonno = docpacklist[b].BOXNO.Value - (int)leftboxno + 19001; 
                             //          }
                        }                   
                    
                    pl.Rows[b]["CartonBarcode"] = docpacklist[b].CutNo + cartonno.ToString().Substring(1, 4); //外箱條碼產生;                       
                }
                else if (docpacklist[b].CutNo == null && docpacklist[b].CustomName == "ASICS")
                {

                    int cartonno = docpacklist[b].BOXNO.Value + 10000;
                    pl.Rows[b]["CartonBarcode"] = docpacklist[b].CustomPO.Substring(4) + docpacklist[b].ManufactureOrder.Substring(3) + cartonno.ToString().Substring(1, 4);
                }
                else
                {
                    pl.Rows[b]["CartonBarcode"] = docpacklist[b].CartonBarcode;
                };

                //3.---把該訂單的已經刷條碼的訊息再次裝入                
                pl.Rows[b]["BarcodeCount"] = plm.GetPackListInnerCount(pl.Rows[b]["CartonBarcode"].ToString(), pl.Rows[b]["OrderDate"].ToString(), pl.Rows[b]["SizeName"].ToString());
                

                test.AppendText(pl.Rows[b]["CustomStyleCode"] + "\r\n" + (bb + 1).ToString() + " / " + docpacklist.Count.ToString());

                bb++;
            }
            plm.GetPacklistBulkPackList1(pl);
            #endregion






                    ///修正APL尾数 外箱号
                    int mno = 0;
                    //////docpacklist = null;
                    //APL的订单
                    // docpacklist = plm.FirstBoxnoPrintAPL(YearMounth.Text);
                    // for (int b = 0; b < docpacklist.Count; b++)
                    //  {
                    //有两条资料的第一笔箱号 , >= 之后都取出来
                    int? leftboxno1 = plm.LeftBoxno1(txtOrder.Text);
       //     MessageBox.Show(leftboxno1.ToString());   
       // 只有第一箱單碼裝 ,後面才有尾數 .去修改
          if(fistboxbo==1 )
            {
                if (leftboxno1 != null)
                {

                      docpacklist1 = null;
                    int cartonno = (int)leftboxno1;
                    docpacklist1 = plm.LeftBoxno(txtOrder.Text, cartonno);
                    for (int c = 0; c < docpacklist1.Count; c++)
                    {

                        int mbno = docpacklist1[c].BOXNO.Value - (int)leftboxno1 + 9001;
                        string mcarton = docpacklist1[c].CartonBarcode;
                        string mtr = mcarton.Substring(0, mcarton.Length - 4) + mbno.ToString();
                        plm.updatePackListCartonBarcode(docpacklist1[c].CustomStyleCode.ToString(), docpacklist1[c].BOXNO.Value, mtr);

                        test.Clear();
                        test.AppendText((mno + 1).ToString() + " / " + docpacklist1.Count.ToString());
                        mno++;
                    }
                }

            //    }
                

            }    




            MessageBox.Show("OK,請立刻接轉---該單一訂單---的成品裝箱明細");
            
            #endregion
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            //Table 定義數據類型
            DataTable pls = new DataTable();
            //from t_packlist
            pls.Columns.Add("Guid", typeof(SqlGuid));
            pls.Columns.Add("Style");
            pls.Columns.Add("Name");
            pls.Columns.Add("Color");
            pls.Columns.Add("Code");

            pls.Columns.Add("CustomStyleName");
            pls.Columns.Add("CustomStyleCode");
            pls.Columns.Add("CustomName");
            pls.Columns.Add("CustomBuyName");

            pls.Columns.Add("AimArea");
            pls.Columns.Add("OrderDate");
            pls.Columns.Add("ShipMentDate", typeof(SqlDateTime));
            pls.Columns.Add("CustomPO");

            pls.Columns.Add("ManufactureOrder");
            pls.Columns.Add("CutNo");
            pls.Columns.Add("BOXNO", typeof(SqlInt32));
            pls.Columns.Add("CartonBarcode");
            pls.Columns.Add("CartonBarcodeNeed");
            pls.Columns.Add("BoxSize");
            pls.Columns.Add("ScanIn", typeof(SqlInt32));
            pls.Columns.Add("ScanOut", typeof(SqlInt32));
            pls.Columns.Add("QAIn", typeof(SqlInt32));
            pls.Columns.Add("QAOut", typeof(SqlInt32));
            pls.Columns.Add("ShipOut");
             pls.Columns.Add("ShipScanTime");
            pls.Columns.Add("CarNo");



  
            string myod1 = txtOrder1.Text;
            if (myod1 == "")
            {
                MessageBox.Show("訂單欄位為空");
                return;
            };


            //.----重新接轉訂單年月的資料
            
//            docpacklist = null;
  //          docpacklist = plm.GetToPacklistShipOrder(myod1);
            pshiplist = null;
            pshiplist = plm.GetToPacklistShipOrder1(myod1);
            int bb = 0;

            #region datatable   使用SQLBULK     
            for (int b = 0; b < pshiplist.Count; b++)
            {
                test.Clear();

                pls.Rows.Add();
                pls.Rows[b]["Guid"] = System.Guid.NewGuid();
                pls.Rows[b]["Style"] = pshiplist[b].Style;
                pls.Rows[b]["Name"] = pshiplist[b].Name;
                pls.Rows[b]["Color"] = pshiplist[b].Color;
                pls.Rows[b]["Code"] = pshiplist[b].Code;

                pls.Rows[b]["CustomStyleName"] = pshiplist[b].CustomStyleName;
                pls.Rows[b]["CustomStyleCode"] = pshiplist[b].CustomStyleCode;//訂單號
                pls.Rows[b]["CustomName"] = pshiplist[b].CustomName;//客戶
                pls.Rows[b]["CustomBuyName"] = pshiplist[b].CustomBuyName;

                pls.Rows[b]["AimArea"] = pshiplist[b].AimArea;
                pls.Rows[b]["OrderDate"] = pshiplist[b].OrderDate;//客戶
                pls.Rows[b]["ShipMentDate"] = pshiplist[b].ShipMentDate;
                pls.Rows[b]["CustomPO"] = pshiplist[b].CustomPO;//

                pls.Rows[b]["ManufactureOrder"] = pshiplist[b].ManufactureOrder;//
                pls.Rows[b]["CutNo"] = pshiplist[b].CutNo;//
                pls.Rows[b]["BOXNO"] = pshiplist[b].BOXNO; //箱號
                pls.Rows[b]["CartonBarcode"] = pshiplist[b].CartonBarcode; //外箱條碼
                pls.Rows[b]["CartonBarcodeNeed"] = pshiplist[b].CartonBarcodeNeed; //外箱條碼
                pls.Rows[b]["BoxSize"] = pshiplist[b].BoxSize;//     
                                                                // 掃描檔案刪除後加入
                                                                //3.---把該訂單的已經刷條碼的訊息再次裝入           

                if (pshiplist[b].ScanIn == null)
                { pls.Rows[b]["ScanIn"] = 0; }
                else { pls.Rows[b]["ScanIn"] = pshiplist[b].ScanIn; }

                if (pshiplist[b].ScanOut == null)
                { pls.Rows[b]["ScanOut"] = 0; }
                else { pls.Rows[b]["ScanOut"] = pshiplist[b].ScanOut; }
                if (pshiplist[b].QAIn == null)
                { pls.Rows[b]["QAIn"] = 0; }
                else { pls.Rows[b]["QAIn"] = pshiplist[b].QAIn; }
                if (pshiplist[b].QAOut == null)
                { pls.Rows[b]["QAOut"] = 0; }
                else { pls.Rows[b]["QAOut"] = pshiplist[b].QAOut; }
                pls.Rows[b]["ShipOut"] = pshiplist[b].ShipOut;
                pls.Rows[b]["ShipScanTime"] = pshiplist[b].ShipScanTime;
                pls.Rows[b]["CarNo"] = pshiplist[b].CarNo;




                

                test.AppendText(pls.Rows[b]["CustomStyleCode"] + "\r\n" + (bb + 1).ToString() + " / " + pshiplist.Count.ToString());

                bb++;


            }

            //.----刪除掉 該訂單資料 ,預防NINA訂單資料做錯重新轉
            plm.DelPackListShiptOrder(myod1);
            plm.GetPacklistBulkPackListShip(pls);
            MessageBox.Show("OK");
            #endregion


        }

       


        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt1 = dtpdate.Value;
            string myear = dt1.Year.ToString();
            txtPlanNo.Text = Common.myCommon.GetDayofWeek(dt1, myear).ToString();
        }


        

        private void btnOrderCheck_Click(object sender, EventArgs e)
        {
            
            if(txtBuyer.Text=="")
            {
            //    MessageBox.Show("請填寫客戶買主");
            //    return;
            }
            pshiplist = null;
            if(txtMorder.Text!="")
            {
                YearMounth.Text = pship.GetMOrderDate(txtMorder.Text);
            }
            pshiplist= pship.GetPacklistCarNo1(YearMounth.Text, txtBuyer.Text,txtMorder.Text);
            this.dgvPackOrder.DataSource = pshiplist;

        }

      

        private void btnOrderCancel_Click(object sender, EventArgs e)
        {
 
            int bb = 0;
            for (int i = 0; i < pshiplist.Count; i++)
            {


                if (dgvPackOrder.Rows[i].Cells["V"].EditedFormattedValue.ToString() == "True" && dgvPackOrder.Rows[i].Cells["CarNo3"].Value != null)
                {
                    string order = dgvPackOrder.Rows[i].Cells["CustomStyleCode3"].Value.ToString();
                    string carno1 = dgvPackOrder.Rows[i].Cells["CarNo3"].Value.ToString();
                    int nub = pship.cancelPackListShipNo(carno1, order);
                    bb = bb + nub;
                };
            }



            txtW.Text = "";
            txtW.Text="總共有" + bb.ToString() + "箱取消";







        }

        private void btnUpdateShip_Click(object sender, EventArgs e)
        {

            if (txtPlanNo.Text == "")
            {
                  MessageBox.Show("計畫編號為空");
                    return;
            }
            if (txtCartonNo.Text == "")
            {
                 MessageBox.Show("周貨櫃編號為空");
                return;
            }
            if (pshiplist.Count == 0)
            {
                //MessageBox.Show("請查詢訂單");
                // return;
            }
            int bb = 0;

            for (int i = 0; i < pshiplist.Count; i++)
            {
                if (dgvPackOrder.Rows[i].Cells["V"].EditedFormattedValue.ToString() == "True" && dgvPackOrder.Rows[i].Cells["CarNo3"].Value == null)
                {
                    string order = dgvPackOrder.Rows[i].Cells["CustomStyleCode3"].Value.ToString();
                    string carno1 = txtPlanNo.Text.Trim() + txtCartonNo.Text.Trim();
                    int nub = pship.updatePackListShipNo(carno1, order);
                    bb = bb + nub;
                };
            }


         //   MessageBox.Show("總共有" + bb.ToString() + "箱加入");
            string carno = txtPlanNo.Text.Trim() + txtCartonNo.Text.Trim();
            //   pshiplist1  所有的該櫃的裝箱明細 ,   pshiplist選擇訂單的裝櫃訂單
            pshiplist1 = pship.GetPacklistShpByCarNo(carno);
            this.dgvPacklistShip.DataSource = pshiplist1;
            double T = 0;
                txtW.Text = "";

            if (pshiplist1==null)
            {
                txtW.AppendText("該周貨櫃號沒有資料");
                //MessageBox.Show("ggg");
                return;
            }
            else
            {
                txtW.AppendText("總共有" + bb.ToString() + "箱加入");
                //   MessageBox.Show("總共有" + bb.ToString() + "箱加入");
            }
            double T1 = 0;
            for (int j = 0; j < pshiplist1.Count; j++)
            {

                String boxsize = dgvPacklistShip.Rows[j].Cells["BoxSize"].Value.ToString();
                string[] mybox = boxsize.Split('*');
                double L = Convert.ToDouble(mybox[0].Trim());
                double W = Convert.ToDouble(mybox[1].Trim());
                double H = Convert.ToDouble(mybox[2].Trim());
                double V = L * W * H;
                double V1 =V / 1000000;
        //        pship.updatePackListBoxCBM(V1, pshiplist1[j].CarNo.ToString(), pshiplist1[j].CustomStyleCode.ToString());
                //該貨櫃的所有外箱容積總和
                T = T + V;
               T1 = (double)T / 1000000;
                //       txtW.Text = T1.ToString("f2") + "\r\n" + T.ToString();

            }
                txtW.AppendText("\r\n" + T1.ToString("f2") + "\r\n" + T.ToString());


        }

        private void btnCancelBox_Click(object sender, EventArgs e)
        {
            txtW.Text = "";
            int cc = 0;
            if(pshiplist1==null)
            {
                txtW.Text = "沒有資料選中取消";
                return; 
            }
            for (int j = 0; j < pshiplist1.Count; j++)
            {


                if (dgvPacklistShip.Rows[j].Selected == true)
                {
                    String po = dgvPacklistShip.Rows[j].Cells["CustomStyleCode2"].Value.ToString();
                    String cno = dgvPacklistShip.Rows[j].Cells["BOXNO3"].Value.ToString();
                   int ca=pship.cancelCartonPackListShipNo(cno, po);
                    cc = cc + ca;

                }
           //     txtW.AppendText()
                txtW.Text = "總共"+ cc.ToString() + "筆外箱取消" ;

            }

        }



        private void button7_Click_2(object sender, EventArgs e)
        {
 
            if (txtPlanNo.Text == "")
            {
                MessageBox.Show("計畫編號為空");
                return;
            }
            if (txtCartonNo.Text == "")
            {
                MessageBox.Show("周貨櫃編號為空");
                return;
            }

            pshiplist1 = null;
            //   MessageBox.Show("總共有" + bb.ToString() + "箱加入");
            string carno = txtPlanNo.Text.Trim() + txtCartonNo.Text.Trim();
            //   pshiplist1  所有的該櫃的裝箱明細 ,   pshiplist選擇訂單的裝櫃訂單
            pshiplist1 = pship.GetPacklistShpByCarNo(carno);
            this.dgvPacklistShip.DataSource = pshiplist1;
            ///*
            if (pshiplist1==null)
            {
                MessageBox.Show("沒有該裝櫃號碼資料");
                return;
            }




            //*/
            //创建一个文本文件,最好先判断一下 
       //     ofg.InitialDirectory = @"\\192.168.98.200\集团公开资料\ASICSTXT\IN";
            StreamWriter sw;
            if (!File.Exists(@"\\192.168.98.200\集团公开资料\ASICSTXT\IN\" + carno + ".txt"))
            {
                //不存在就新建一个文本文件,并写入一些内容 
                sw = File.CreateText(@"\\192.168.98.200\集团公开资料\ASICSTXT\IN\" + carno+".txt");
                for (int i = 0; i < pshiplist1.Count; i++)
                {
                    string mshipout;
                    string mshipscantime;
                    if (pshiplist1[i].ShipOut == null)
                    {
                        mshipout = "0";
                            }
                    else
                    {
                        mshipout = pshiplist1[i].ShipOut.ToString();
                    }

                    if (pshiplist1[i].ShipScanTime == null)
                    {
                        mshipscantime = "null";
                    }
                    else
                    {
                        mshipscantime = pshiplist1[i].ShipScanTime.ToString();
                    }





                    string mlist = pshiplist1[i].CarNo.ToString()
                         + "|" + pshiplist1[i].CustomStyleCode.ToString()
                        + "|" + pshiplist1[i].BOXNO.Value.ToString()
                         + "|" + pshiplist1[i].AimArea.ToString()
                         + "|" + pshiplist1[i].CartonBarcode.ToString()
                         + "|" + pshiplist1[i].BoxSize.ToString()
                         + "|" + mshipout
                     + "|" + mshipscantime;
                    sw.WriteLine(mlist);

                }
                    sw.Close();

            }
            else
            {
                if (MessageBox.Show("確定刪除請按<確定>", "标题", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                  File.Delete(@"\\192.168.98.200\集团公开资料\ASICSTXT\IN\" + carno + ".txt");
                MessageBox.Show(@"\\192.168.98.200\集团公开资料\ASICSTXT\IN\" + carno + ".txt"+"檔案已經刪除");
                };


            }

            MessageBox.Show("ok");
        }


        public class User
        {
            private int userID = 0;

            private string userName = string.Empty;

            public int UserID
            {
                get
                {
                    return this.userID;
                }
            }

            public string UserName
            {
                get
                {
                    return this.userName;
                }
            }

            public User(int userID, string userName)
            {
                this.userID = userID;

                this.userName = userName;
            }
        }

        private void btnSeeShip_Click(object sender, EventArgs e)
        {
            if (txtPlanNo.Text == "")
            {
                MessageBox.Show("計畫編號為空");
                return;
            }
            if (txtCartonNo.Text == "")
            {
                MessageBox.Show("周貨櫃編號為空");
                return;
            }


            //   MessageBox.Show("總共有" + bb.ToString() + "箱加入");

            string carno = txtPlanNo.Text.Trim() + txtCartonNo.Text.Trim();
            //   pshiplist1  所有的該櫃的裝箱明細 ,   pshiplist選擇訂單的裝櫃訂單
            pshiplist1 = pship.GetPacklistShpByCarNo(carno);
            this.dgvPacklistShip.DataSource = pshiplist1;
            Double T = 0;
            txtW.Text = "";

            if (pshiplist1 == null)
            {
                txtW.AppendText("該周貨櫃號沒有資料");
                //MessageBox.Show("ggg");
                return;
            }
            else
            {
                txtW.AppendText("貨櫃編號  " + carno + "\r\n" +"貨櫃內裝  " + pshiplist1.Count.ToString() + "箱");
                //   MessageBox.Show("總共有" + bb.ToString() + "箱加入");
            }
            double T1 = 0;
            for (int j = 0; j < pshiplist1.Count; j++)
            {

                String boxsize = dgvPacklistShip.Rows[j].Cells["BoxSize"].Value.ToString();
                string[] mybox = boxsize.Split('*');
                Double L = Convert.ToDouble(mybox[0].Trim());
                Double W = Convert.ToDouble(mybox[1].Trim());
                Double H = Convert.ToDouble(mybox[2].Trim());
                Double V = L * W * H;
                Double V1 = V * 0.000001;
                //   MessageBox.Show(V1.ToString());
                dgvPacklistShip.Rows[j].Cells["BoxCBM"].Value = V1.ToString();

                //該貨櫃的所有外箱容積總和
                T = T + V;
                T1 = (double)T / 1000000;
                //       txtW.Text = T1.ToString("f2") + "\r\n" + T.ToString();

            }
            txtW.AppendText("\r\n" + "使用容積  " +T1.ToString("f2") + "  CBM");
            pshiplist = null;
            pshiplist=pship.GetPacklistCarNoOK(carno);

            this.dgvPackOrder.DataSource = pshiplist;

        }

        private void TOEXCEL_Click(object sender, EventArgs e)
        {
            string vg = "Ship";
            ImproExcel(vg);
        }

        public void ImproExcel(string VG)
        {

            SaveFileDialog sdfExport = new SaveFileDialog();
            sdfExport.Filter = "Excel 97-2003文件|*.xls|Excel 2007文件|*.xlsx";
            //   sdfExport.ShowDialog();

            if (sdfExport.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            String filename = sdfExport.FileName;
            myCommon.NPOIProgram NPOIexcel = new myCommon.NPOIProgram();
            DataTable tabl = new DataTable();
            if (VG == "Ship")
            {
                tabl = GetDgvToTable(dgvPacklistShip);
            }
            else if (VG == "SizeRun")
            {
                //    tabl = GetDgvToTable(dataGridViewSizeRun);
            }

            // DataTable dt = (StyleCodeInfodataGridView.DataSource as DataTable);
            NPOIexcel.ExcelWrite(filename, tabl);//excelhelper写出           
            if (MessageBox.Show("导出成功，文件保存在" + filename.ToString()
                   + ",是否打开此文件？", "提示", MessageBoxButtons.YesNo) ==
                   DialogResult.Yes)
            {
                if (File.Exists(filename))//文件是否存在
                {
                    Process.Start(filename);//执行打开导出的文件  
                }
                else
                {
                    MessageBox.Show("文件不存在！", "提示");
                }
            }
        }
        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].HeaderText.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void dgvPacklistShip_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgvPacklistShip.Rows[e.RowIndex].Selected == false)
                    {
                        dgvPacklistShip.ClearSelection();
                        dgvPacklistShip.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgvPacklistShip.SelectedRows.Count == 1)
                    {
                        dgvPacklistShip.CurrentCell = dgvPacklistShip.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单

                    ctmsShip.Show(MousePosition.X, MousePosition.Y);
                    // MessageBox.Show("点右键了");
                }
            }



        }

      

        private void btnGetInnerCode_Click(object sender, EventArgs e)
        {
            getInnerCode();
        }

        private void FrmPacklist_Load(object sender, EventArgs e)
        {

        }

        private void FrmPacklist_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}

