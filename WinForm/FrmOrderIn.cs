using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmOrderIn : Form
    {
        public FrmOrderIn()
        {
            InitializeComponent();

        }

            #region 单例窗体对象  -static FrmOrderIn frm
            /// <summary>
            /// 单例窗体对象
            /// </summary>
            static FrmOrderIn frm = null;
            #endregion

            #region 单例模式，返回单个窗体对象  -static FrmOrderIn GetSingleton()
            /// <summary>
            /// 单例模式，返回单个窗体对象
            /// </summary>
            /// <returns></returns>
            public static FrmOrderIn GetSingleton()
            {
                //if(frm==null || frm.IsDisposed)
                if (frm == null)
                {
                    frm = new FrmOrderIn();
                }
                return frm;
            }


        #endregion


        List<MODEL.doc_StyleBase> stylist = null;
        List<MODEL.T_StyleCodeInfo> odlist = null;
        List<MODEL.doc_StyleSize> sslist = new List<MODEL.doc_StyleSize>();
        List<MODEL.doc_InnerBox> solist = new List<MODEL.doc_InnerBox>();

        BLL.T_StyleCodeInfoManager od = new BLL.T_StyleCodeInfoManager();
        BLL.doc_StyleBaseManager sbm = new BLL.doc_StyleBaseManager();
        BLL.doc_StyleManager sm = new BLL.doc_StyleManager();
        BLL.doc_StyleSIzeManager ssm = new BLL.doc_StyleSIzeManager();
        BLL.doc_InnerBoxManager ibm = new BLL.doc_InnerBoxManager();
        // BLL.doc_StyleBaseManager stm = new BLL.doc_StyleBaseManager();


        private void btnALLStyle_Click(object sender, EventArgs e)
        {
            //----------------StyleBase

            // 从订单中提出形体大类需要的资讯 ,使用唯一的Code 工厂型体捉出订单中大类的其他栏位
            stylist = od.GetOrdertolStyle(YearMounth.Text);
            MODEL.doc_StyleBase sb = new MODEL.doc_StyleBase();
            int aa = 0;
            for (int k = 0; k < stylist.Count; k++)
            {
                test.Clear();
                sb.Guid = System.Guid.NewGuid();
                sb.Style = stylist[k].Style;
                sb.StyleBase = stylist[k].StyleBase;
                sb.Name = stylist[k].Name;
                sb.CustomName = stylist[k].CustomName;
                sb.GoodsTypeName = stylist[k].GoodsTypeName;
                sb.ModelNo = stylist[k].ModelNo;
                sb.RBcode = stylist[k].RBcode;
                sb.MDcode = stylist[k].MDcode;
                sb.Editionhandle = stylist[k].Editionhandle;
                sb.Innor = stylist[k].Editionhandle;
                sb.OrderDate = stylist[k].OrderDate;
                sb.NewCode = stylist[k].NewCode;
                test.AppendText("型体大类" + "\r\n" + sb.Style + sb.OrderDate + "\r\n" + (k+1).ToString() + "/" + stylist.Count.ToString());
                if (sbm.IsStyleBaseExisits(stylist[k].Name) < 1)
                {
                    //     MessageBox.Show("自动增加" + sb.Name);
                    sbm.AddStyleBase(sb);
                    aa = aa + 1;
                };

            }
            MessageBox.Show(aa.ToString() + "筆新型體新增");
            //    List<MODEL.doc_StyleBase> stybase = null;
            //      stybase = stm.GetAllStyleBase();
            //        this.dgvStyleBase.DataSource = stybase;

            //----------------Style

            int myadd = 0;
           odlist = od.GetAllCode(YearMounth.Text);

            List<MODEL.doc_Style> lists = null;
            lists = new List<MODEL.doc_Style>();
            for (int j = 0; j < odlist.Count; j++)
            {
                test.Clear();
                MODEL.doc_Style c = new MODEL.doc_Style();
                c.Code = odlist[j].Code;
                string[] mycode = odlist[j].Code.Split('/');
                c.Style = mycode[0].Trim();
                c.Guid = new Guid();

                //判断如果没有/ 那么长度就会为1(一段)

                // if (odlist[j].Code.Length > mycode[0].Length)
                if (mycode.Length > 1)
                {
                    c.Color = mycode[1].Trim();
                };
                c.OrderDate = odlist[j].OrderDate;
                test.AppendText("型体" + "\r\n" + c.Style +c.OrderDate + "\r\n" + (j+1).ToString() + "/" + odlist.Count.ToString());


                lists.Add(c);
                if (sm.IsCodeExisits(odlist[j].Code) < 1)
                {
                    sm.AddStyle(c);
                    myadd++;

                }

            }

            MessageBox.Show(myadd.ToString() + "筆新配色新增");


            //-------stylesize
            sslist = null;
            sslist = ssm.GetStyleSizefromOrder(YearMounth.Text);
            List<MODEL.doc_StyleSize> sslists = null;
            sslists = new List<MODEL.doc_StyleSize>();
            int sscount = 0;

            for (int j = 0; j < sslist.Count; j++)
            {
                test.Clear();
                MODEL.doc_StyleSize ss = new MODEL.doc_StyleSize();
                ss.Guid = System.Guid.NewGuid();
                ss.Style = sslist[j].Style;
                ss.StyleBase = sslist[j].StyleBase;
                // 取消sStyleBase
                ss.OrderDate = sslist[j].OrderDate;
                // 取消OrderDate 由於Code 不規範 (有些中間會有空格) ,所以OrderDate會多筆
                ss.Size = sslist[j].Size;
                ss.NewCode = "";
                ss.BoxSize = "";
                ss.Section = "";
                ss.Unit = "cm";
                ss.Weight = null;
                ss.Range = null;
                ss.L = null;
                ss.W = null;
                ss.H = null;
                test.AppendText("型体尺码" + "\r\n" + ss.Style+ ss.Size + "\r\n" +(j+1).ToString() + "/" + sslist.Count.ToString());
                sslists.Add(ss);
                if (ssm.IsStyleSizeExisits(ss.Style, ss.Size) < 1)
                {
                    ssm.AddStyleSize(ss);
                    sscount++;
            
                };
                sslists.Clear();

            }
            MessageBox.Show(sscount.ToString() + "筆型體尺碼新增");

            //------- inneer Box
            //獲得該月訂單年月的型體尺碼數量
            solist = null;
            solist = ibm.GetInnerfromOrder(YearMounth.Text);
            //    MessageBox.Show(solist.Count.ToString());
            string show = solist.Count.ToString();
            int ibcount = 0;
            List<MODEL.doc_InnerBox> iblists = null;
            iblists = new List<MODEL.doc_InnerBox>();
            // doc_innorbox 沒有尺碼的增加 ,使用 name , size, color 判斷
            for (int j = 0; j < solist.Count; j++)
            {
                test.Clear();
                MODEL.doc_InnerBox ib = new MODEL.doc_InnerBox();
                ib.Guid = System.Guid.NewGuid();
                ib.InnerBarcode = "";
                ib.Name = solist[j].Name.Trim();
                ib.Style = solist[j].Style.Trim();
                ib.Color = solist[j].Color.Trim();
                ib.Size = solist[j].Size.Trim();
                test.AppendText("内盒资料" + "\r\n" + ib.Name + ib.Color + ib.Size + "\r\n" +(j+1).ToString()+"/"+solist.Count.ToString());
                ib.CustomName = solist[j].CustomName;
                ib.Type = "";
                ib.StyleCode = solist[j].Name + "." + solist[j].Color;
                ib.NewCode = "";
                iblists.Add(ib);
                if (ibm.IsInnerBoxExisits(ib.Name, ib.Color, ib.Size) < 1)
                {
                    ibm.AddInnerBox(ib);
                    ibcount++;
                }

            }

            MessageBox.Show(ibcount.ToString() + "筆內盒資料新增");

        }

        private void FrmOrderIn_Load(object sender, EventArgs e)
        {

        }

        private void FrmOrderIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void test_TextChanged(object sender, EventArgs e)
        {

        }
    }





    }
