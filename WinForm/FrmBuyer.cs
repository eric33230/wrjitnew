using MODEL;
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
    public partial class FrmBuyer : Form
    {
        public FrmBuyer()
        {
            InitializeComponent();
            this.dgvBuyer.AutoGenerateColumns = false;
            this.dgvBuyerE.AutoGenerateColumns = false;
            this.dgvBuyer.Columns["CustomName"].ReadOnly = true;
            this.dgvBuyer.Columns["Destination"].ReadOnly = true;
            this.dgvBuyer.Columns["CustomName"].DefaultCellStyle.BackColor = Color.LightBlue;
            this.dgvBuyer.Columns["Destination"].DefaultCellStyle.BackColor = Color.LightBlue;

        }

        static FrmBuyer frm;
        public static FrmBuyer GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmBuyer();
            }
            return frm;
        }

        BLL.doc_BuyerManager bm = new BLL.doc_BuyerManager();
        int isEdit = 0;

        private void FrmBuyer_Load(object sender, EventArgs e)
        {
            List<doc_Buyer> buyer = new List<doc_Buyer>();
            buyer = bm.GetAllBuyer();
            if (buyer.Count <= 0)
            {
                MessageBox.Show("没有客户列表，请新增");
                return;
            }
            cbCustomName.Items.Add("不选");
            cbcustomBuyName.Items.Add("不选");
            cbDestination.Items.Add("不选");

            var customNames = buyer.MyDistinct(p => p.CustomName);
            var customBuyNames = buyer.MyDistinct(p => p.CustomBuyName);
            var destinations = buyer.MyDistinct(p => p.Destination);
            foreach (doc_Buyer customName in customNames)
            {
                if (customName.CustomName != null && customName.CustomName.Length > 0)
                {
                    cbCustomName.Items.Add(customName.CustomName);
                }
            }
            foreach (doc_Buyer customBuyName in customBuyNames)
            {
                if (customBuyName.CustomBuyName != null && customBuyName.CustomBuyName.Length > 0)
                {
                    cbcustomBuyName.Items.Add(customBuyName.CustomBuyName);
                }
            }
            foreach (doc_Buyer destination in destinations)
            {
                if (destination.Destination != null && destination.Destination.Length > 0)
                {
                    cbDestination.Items.Add(destination.Destination);
                }
            }

            //加载表格
            this.dgvBuyer.DataSource = bm.GetAllBuyer();

        }

        //
        private void btnBuyerE_Click(object sender, EventArgs e)
        {



            List<MODEL.doc_Buyer> listbuyer = new List<MODEL.doc_Buyer>();
            this.dgvBuyerE.DataSource = null;
            listbuyer = bm.GetlBuyerE(YearMounth.Text);
            if (listbuyer != null && listbuyer.Count() > 0)
            {
                this.dgvBuyerE.DataSource = listbuyer;

            }
            else
            {

                MessageBox.Show("没有新的目的地");
            }


        }


        private void dgvBuyerE_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string customname = this.dgvBuyerE.Rows[e.RowIndex].Cells["CustomName1"].Value.ToString();
            string destination = this.dgvBuyerE.Rows[e.RowIndex].Cells["Destination1"].Value.ToString();
            string custombuyname = this.dgvBuyerE.Rows[e.RowIndex].Cells["CustomBuyName1"].Value.ToString();

            DialogResult myResult = MessageBox.Show("是否新增目的地港口", "客户买主", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (myResult == DialogResult.Yes)//如果對話框的返回值是NO（按"N"按鈕）

            {

                bm.newtDestination(customname, destination, custombuyname);
                this.dgvBuyer.DataSource = null;
                this.dgvBuyer.DataSource = bm.GetAllBuyer();
            }

        }


        private void dgvBuyer_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            isEdit = 1;
        }

        private void dgvBuyer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isEdit == 1)
            {

                string mycolname = this.dgvBuyer.Columns[e.ColumnIndex].Name;
                string mycolvalue = this.dgvBuyer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string myguid = this.dgvBuyer.Rows[e.RowIndex].Cells["Guid"].Value.ToString();
                ///     MessageBox.Show(mycolname + "--" + mycolvalue + "--" + myguid);
                bm.updateBuyer(mycolname, mycolvalue, myguid);

                isEdit = 0;
            }
        }


        private void FrmBuyer_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FrmBuyer_Resize(object sender, EventArgs e)
        {
            groupBox2.Width = (int)(this.Width * 0.25);
            groupBox2.Height = this.Height - 80;

            groupBox1.Left = groupBox2.Width + 5;
            groupBox1.Width = this.Width - groupBox2.Width - 15;
            groupBox1.Height = this.Height - 80;

        }

        private void btnquerybykey_Click(object sender, EventArgs e)
        {
            
            List< string> codes = new List<string>();
            List<string> values = new List<string>();
            
            if(cbCustomName.Text.Length>0 && !(cbCustomName.Text.Equals("不选")))
            {
                codes.Add("CustomName");
                values.Add(cbCustomName.Text);
             
            }
            if (cbcustomBuyName.Text.Length > 0 && !(cbcustomBuyName.Text.Equals("不选")))
            {
                codes.Add("CustomBuyName");
                values.Add(cbcustomBuyName.Text);

            }
            if (cbDestination.Text.Length > 0 && !(cbDestination.Text.Equals("不选")))
            {
                codes.Add("Destination");
                values.Add(cbDestination.Text);

            }
            List<doc_Buyer> buyer = new List<doc_Buyer>();
            buyer = bm.GetAllBuyer(codes, values);
            this.dgvBuyer.DataSource = null;
            this.dgvBuyer.DataSource = buyer;
        }
    }
}
