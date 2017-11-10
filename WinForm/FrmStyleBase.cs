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
    public partial class FrmStyleBase : Form
    {
        public FrmStyleBase()
        {
            InitializeComponent();
            this.dgvStyleBase.AutoGenerateColumns = false;
            this.dgvStyleBase.Columns["CustomName"].ReadOnly = true;
            this.dgvStyleBase.Columns["Style"].ReadOnly = true;
            this.dgvStyleBase.Columns["Name1"].ReadOnly = true;
            this.dgvStyleBase.Columns["OrderDate"].ReadOnly = true;
            this.dgvStyleBase.Columns["NewCode"].ReadOnly = true;

            this.dgvStyleBase.Columns["CustomName"].DefaultCellStyle.BackColor = Color.LightBlue;
            this.dgvStyleBase.Columns["Style"].DefaultCellStyle.BackColor = Color.LightBlue;
            this.dgvStyleBase.Columns["Name1"].DefaultCellStyle.BackColor = Color.LightBlue;
            this.dgvStyleBase.Columns["OrderDate"].DefaultCellStyle.BackColor = Color.LightBlue;
            this.dgvStyleBase.Columns["NewCode"].DefaultCellStyle.BackColor = Color.LightBlue;
 

        }


        static FrmStyleBase frm;
        public static FrmStyleBase GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmStyleBase();
            }
            return frm;
        }


        private void FrmStyleBase_Load(object sender, EventArgs e)
        {
            sblist1 = sbm.GetAllStyleBase();
            this.dgvStyleBase.DataSource = sblist1;

        }

        private void FrmStyleBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }



        List<MODEL.doc_StyleBase> sblist = new List<MODEL.doc_StyleBase>();
        List<MODEL.doc_StyleBase> sblist1 = new List<MODEL.doc_StyleBase>();
        List<MODEL.doc_Style> slist1 = new List<MODEL.doc_Style>();
        List<MODEL.T_StyleCodeInfo> odlist = null;
        List<MODEL.doc_StyleSize> sslist = new List<MODEL.doc_StyleSize>();
        List<MODEL.doc_StyleSize> sslist1 = new List<MODEL.doc_StyleSize>();
        // List<MODEL.doc_InnerBox> solist = new List<MODEL.doc_InnerBox>();
        int isEdit = 0;

        BLL.T_StyleCodeInfoManager od = new BLL.T_StyleCodeInfoManager();
        BLL.doc_StyleBaseManager sbm = new BLL.doc_StyleBaseManager();
        BLL.doc_StyleManager sm = new BLL.doc_StyleManager();
        BLL.doc_StyleSIzeManager ssm = new BLL.doc_StyleSIzeManager();
        // BLL.doc_InnerBoxManager ibm = new BLL.doc_InnerBoxManager();

        MODEL.doc_StyleBase sb = new MODEL.doc_StyleBase();

        private void button1_Click(object sender, EventArgs e)
        {


        }

   
        private void btnALLStyle_Click(object sender, EventArgs e)
        {

            #region----------------StyleBase
            int aa = 0;
            ///*
            // 从订单中提出形体大类需要的资讯 ,使用唯一的Code 工厂型体捉出订单中大类的其他栏位
            sblist = od.GetOrdertolStyle(YearMounth.Text);
            MODEL.doc_StyleBase sb = new MODEL.doc_StyleBase();

            for (int k = 0; k < sblist.Count; k++)
            {
                test.Clear();
                sb.Guid = System.Guid.NewGuid();
                sb.Style = sblist[k].Style;
                 sb.StyleBase = sblist[k].StyleBase;
                sb.Name = sblist[k].Name;
                sb.CustomName = sblist[k].CustomName;
            //    sb.CustomNameS = sblist[k].CustomNameS;
                sb.GoodsTypeName = sblist[k].GoodsTypeName;
                sb.ModelNo = sblist[k].ModelNo;
                sb.RBcode = sblist[k].RBcode;
                sb.MDcode = sblist[k].MDcode;
                sb.Editionhandle = sblist[k].Editionhandle;
                sb.Innor = sblist[k].Editionhandle;
                sb.OrderDate = sblist[k].OrderDate;
                sb.NewCode = sblist[k].NewCode;
                test.AppendText("型体大类" + "\r\n" + sb.Style + sb.OrderDate + "\r\n" + (k + 1).ToString() + "/" + sblist.Count.ToString());
                if (sbm.IsStyleBaseExisits(sblist[k].Name) < 1)
                {
                    //     MessageBox.Show("自动增加" + sb.Name);
                    sbm.AddStyleBase(sb);
                    aa = aa + 1;
                };

            }
            //*/
            MessageBox.Show(aa.ToString() + "筆新型體新增");
            #endregion


            #region ----- add  StyleBase newcode
            ///*
            BLL.doc_StyleBaseManager sbm1 = new BLL.doc_StyleBaseManager();
            sblist1 = sbm.GetAllStyleBase();

            for (int l = 0; l < sblist1.Count; l++)
            {
                test.Clear();
                //   MessageBox.Show(sblist1[l].Name);
                string mycode = "";
                mycode = sbm.GetSBNewCode(YearMounth.Text, sblist1[l].Name);
                test.AppendText("型体日期" + "\r\n" + mycode + "\r\n" + (l + 1).ToString() + "/" + sblist1.Count.ToString());
                sbm1.updateStylebaseNewCode(sblist1[l].Name, mycode);
            }

            sblist1 = sbm.GetAllStyleBase();
            this.dgvStyleBase.DataSource = sblist1;

            ///*/
            #endregion-----end add new code


            #region----------------Style
            // /*          
           int myadd = 0;
            odlist = od.GetAllCode(YearMounth.Text);
            List<MODEL.doc_Style> lists = null;
            lists = new List<MODEL.doc_Style>();
            for (int b = 0; b < odlist.Count; b++)
            {
                test.Clear();
                MODEL.doc_Style c = new MODEL.doc_Style();
                c.Code = odlist[b].Code;
                string[] mycode = odlist[b].Code.Split('/');
                c.Style = mycode[0].Trim();
                c.Guid = new Guid();

                //判断如果没有/ 那么长度就会为1(一段)
                // if (odlist[j].Code.Length > mycode[0].Length)
                if (mycode.Length > 1)
                {
                    c.Color = mycode[1].Trim();
                };

                c.OrderDate = odlist[b].OrderDate;
                test.AppendText("型体配色" + "\r\n" + "c.Style" + "\r\n" + (b + 1).ToString() + "/" + odlist.Count.ToString());
                lists.Add(c);

                if (sm.IsCodeExisits(odlist[b].Code) < 1)
                {
                    sm.AddStyle(c);
                    myadd++;
                }

            }
            
            MessageBox.Show(myadd.ToString() + "筆新配色新增");
            //*/
            #endregion
            #region ----- add style newcode
            ///*
            BLL.doc_StyleManager sm1 = new BLL.doc_StyleManager();
            slist1 = sm1.GetAllStyle();

            for (int c = 0; c < slist1.Count; c++)
            {
                test.Clear();
                //   MessageBox.Show(sblist1[l].Name);
                string mycode1 = "";
                mycode1 = sm.GetSNewCode(YearMounth.Text, slist1[c].Code);
                test.AppendText("型体配色日期" + "\r\n" + mycode1 + "\r\n" + (c + 1).ToString() + "/" + slist1.Count.ToString());
                sm1.updateStyleNewCode(slist1[c].Code, mycode1);
            }
            //*/
            #endregion-----end add new code


            #region-------stylesize
            int sscount = 0;
           //*
            sslist = null;
            sslist = ssm.GetStyleSizefromOrder(YearMounth.Text);
            List<MODEL.doc_StyleSize> sslists = null;
            sslists = new List<MODEL.doc_StyleSize>();

            for (int a = 0; a < sslist.Count; a++)
            {
                test.Clear();
                MODEL.doc_StyleSize ss = new MODEL.doc_StyleSize();
                ss.Guid = System.Guid.NewGuid();
                ss.Style = sslist[a].Style;
                ss.StyleBase = sslist[a].StyleBase;
                // 取消sStyleBase
                ss.OrderDate = sslist[a].OrderDate;
                // 取消OrderDate 由於Code 不規範 (有些中間會有空格) ,所以OrderDate會多筆
                ss.Size = sslist[a].Size;

                ss.NewCode = "";
                ss.BoxSize = "";
                ss.Section = "";
                ss.Unit = "cm";
                ss.Weight = 0;
                ss.Range = null;
                ss.L = null;
                ss.W = null;
                ss.H = null;
                test.AppendText("型体尺码" + "\r\n" + ss.Style + "\r\n" + (a + 1).ToString() + "/" + sslist.Count.ToString());
                sslists.Add(ss);
                if (ssm.IsStyleSizeExisits(ss.Style, ss.Size) < 1)
                {
                    ssm.AddStyleSize(ss);
                    sscount++;

                };
                sslists.Clear();

            }


            // */
            MessageBox.Show(sscount.ToString() + "筆型體尺碼新增");

            #endregion
            #region ----- add stylesize new code
            ///*
            BLL.doc_StyleSIzeManager ssm1 = new BLL.doc_StyleSIzeManager();
            sslist1 = ssm1.GetAllStyleSize();

            for (int c = 0; c < sslist1.Count; c++)
            {
                test.Clear();
                //   MessageBox.Show(sblist1[l].Name);
                string mycode2 = "";
                mycode2 = ssm1.GetSBNewCodeToSS(YearMounth.Text, sslist1[c].Style);
                test.AppendText("型体尺码日期" + "\r\n" + mycode2 + "\r\n" + (c + 1).ToString() + "/" + sslist1.Count.ToString());
                ssm1.updateStyleSizeNewCode(sslist1[c].Style, mycode2);
            }
            //*/
            MessageBox.Show("更新完毕");

            #endregion-----end add stylesize new code



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string mystylebase = txtStyleBase.Text;
            string mystyle = txtStyle.Text;
            string myname = txtName.Text;
            string mymodelno = txtModelNo.Text;
            bool mycbdate = cbDate.Checked;
            string myyyyymm = YearMounth.Text;
            this.dgvStyleBase.DataSource = sbm.SeeStylebase(mystylebase, mystyle, myname, mymodelno, mycbdate, myyyyymm);


        }
        

        private void dgvStyleBase_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            isEdit = 1; //编辑模式开启
           string   oldstylebase = this.dgvStyleBase.Rows[e.RowIndex].Cells["StyleBase"].Value.ToString();
           string oldsname = this.dgvStyleBase.Rows[e.RowIndex].Cells["Name1"].Value.ToString();
            string oldguid = this.dgvStyleBase.Rows[e.RowIndex].Cells["Guid"].Value.ToString();
            string columnname = this.dgvStyleBase.Columns[e.ColumnIndex].Name;;
            // string 
        ///    MessageBox.Show(columnname);
        }

        private void dgvStyleBase_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isEdit == 1)
            {
                string mycolname = this.dgvStyleBase.Columns[e.ColumnIndex].Name;
                string mycolvalue = this.dgvStyleBase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                 string myguid =this.dgvStyleBase.Rows[e.RowIndex].Cells["Guid"].Value.ToString();
           ///     MessageBox.Show(mycolname + "--" + mycolvalue + "--" + myguid);
                sbm.updateStylebase(mycolname, mycolvalue, myguid);
            }
        


        }

        private void FrmStyleBase_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }


}

