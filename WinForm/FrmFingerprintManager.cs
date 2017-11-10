using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinForm
{
    public partial class FrmFingerprintManager : Form
    {
        /// <summary>
        /// 上传图片用
        /// </summary>
        public static string ftpServerIP = "ftp://192.168.98.200";
        public static string ftpUserID = "QA";
        public static string ftpPassword = "qa1";
        string hname = Dns.GetHostName(); //得到本机的主机名  
        string BKDisk = @"d:\";//备份盘 默认
        String sourcePath = @"c:\WRJIT\IMG\"; //默认
        bool isDisk = false;//是否有盘符和目标位置是否可写//本地备份

        DateTime dt;    //记时  

        BackgroundWorker bgWorker = new BackgroundWorker();
        DataTable tpmdt = new DataTable();//保存下载的记录
        public delegate void OutDelegate(DataTable dt);
        public delegate void SetColour(string sip, Color colour, object value);
        public FrmFingerprintManager()
        {
            InitializeComponent();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            //bgWorker.DoWork += DoWork_Handler;
            bgWorker.DoWork += DoWork_Link;
            bgWorker.ProgressChanged += ProgressChanged_Handler;
            bgWorker.RunWorkerCompleted += RunWorkerCompleted_Handler;
        }
        #region 全局类声明

        Secont secont = new Secont();
        //public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
        public zkemkeeper.CZKEMClass axCZKEM1;
        static FrmFingerprintManager frm = null;
        T_Fingerprint fp = new T_Fingerprint();
        fingerprint fps = new fingerprint();
        string mycolvalue = "";//值 
        private delegate void uptolvLogs(int iMachineNumber);//代理
        #endregion
        /// <summary>
        /// 单窗口实例化
        /// </summary>
        /// <returns></returns>
        public static FrmFingerprintManager GetSingleton()
        {
            if (frm == null || frm.IsDisposed)
            // if (frm == null)
            {
                frm = new FrmFingerprintManager();
            }
            frm.Activate();
            return frm;
        }
        /// <summary>
        /// 进度条 文字信息同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ProgressChanged_Handler(object sender, ProgressChangedEventArgs args)
        {
            jingdutiao.Value = args.ProgressPercentage;
            labbar.Text = secont.Log;
            //添加考勤记录
            if (secont.IGLCount != null && secont.SdwEnrollNumber != null && secont.Data != null && secont.Sip != null)
            {
                if (secont.IGLCount.Trim().Length > 0 && secont.SdwEnrollNumber.Trim().Length > 0 && secont.Data.Trim().Length > 0 && secont.Sip.Trim().Length > 0)
                {
                    string reIGLCount = secont.IGLCount;
                    string reSdwEnrollNumber = secont.SdwEnrollNumber;
                    string reData = secont.Data;
                    string reSip = secont.Sip;
                    if (lvLogs.Items.Count > 0)
                    {
                        string listIGLCount = lvLogs.Items[lvLogs.Items.Count - 1].SubItems[0].Text;
                        string listSdwEnrollNumber = lvLogs.Items[lvLogs.Items.Count - 1].SubItems[1].Text;
                        string listData = lvLogs.Items[lvLogs.Items.Count - 1].SubItems[2].Text;
                        string listSip = lvLogs.Items[lvLogs.Items.Count - 1].SubItems[3].Text;
                        if (reIGLCount != listIGLCount || reSdwEnrollNumber != listSdwEnrollNumber || reData != listData || reSip != listSip)
                        {
                            lvLogs.Items.Add(new ListViewItem(new string[] { reIGLCount, reSdwEnrollNumber, reData, reSip }));
                            this.lvLogs.EnsureVisible(this.lvLogs.Items.Count - 1);
                            this.lvLogs.Items[this.lvLogs.Items.Count - 1].Checked = true;
                        }
                    }
                    else
                    {
                        lvLogs.Items.Add(new ListViewItem(new string[] { reIGLCount, reSdwEnrollNumber, reData, reSip }));
                        this.lvLogs.EnsureVisible(this.lvLogs.Items.Count - 1);
                        this.lvLogs.Items[this.lvLogs.Items.Count - 1].Checked = true;
                    }
                }
            }

            if (secont.Result != null && secont.Result.Trim().Length > 0)
            {
                string val = secont.Result;
                if (listView1.Items.Count <= 0)
                {
                    listView1.Items.Add(secont.Result);
                    this.listView1.EnsureVisible(this.listView1.Items.Count - 1);
                    this.listView1.Items[this.listView1.Items.Count - 1].Checked = true;
                }
                else
                {

                    if (listView1.Items[listView1.Items.Count - 1].SubItems[0].Text != val)
                    {
                        listView1.Items.Add(secont.Result);
                        this.listView1.EnsureVisible(this.listView1.Items.Count - 1);
                        this.listView1.Items[this.listView1.Items.Count - 1].Checked = true;
                    }
                }
            }
            //if (tpmdt.Rows.Count>0)
            //{

            //}

            secont.Data = "";
            secont.IGLCount = "";
            secont.Sip = "";
            secont.SdwEnrollNumber = "";
            secont.Result = "";

            //lvLogs.Items.Add(secont.IGLCount,);
            //lvLogs.Items.Add(secont.SdwEnrollNumber);
            //lvLogs.Items.Add(secont.Data);
            //lvLogs.Items.Add(secont.Sip); 

            // labbar.Text = "已完成" + ((int)args.ProgressPercentage).ToString() + "%";
        }
        private void RunWorkerCompleted_Handler(object sender, RunWorkerCompletedEventArgs args)
        {
            jingdutiao.Value = 0;
            if (args.Error != null)
            {
                MessageBox.Show(args.Error.Message);
            }
            else if (args.Cancelled)
            {

                Cursor = Cursors.Default;
                MessageBox.Show("下载任务已经被取消。", "消息");
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("下载完成。", "消息");
            }

        }
        private void FrmFingerprintManager_Load(object sender, EventArgs e)
        {
            this.dtpbuydate.Format = DateTimePickerFormat.Custom;
            this.dtpbuydate.CustomFormat = "yyyy-MM-dd";
            dgvfinger.AllowUserToAddRows = false;
            getDisks();//获取盘符
            dgvfinger.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Loadlist();
        }
        private void getDisks()
        {
            //string[] disk = Directory.GetLogicalDrives();
            System.IO.DriveInfo[] disk = System.IO.DriveInfo.GetDrives();
            for (int i=0;i<disk.Length;i++)
            {
                if (disk[i].IsReady)
                {
                    
                    long freespace = disk[i].TotalFreeSpace / 1024 / 1024 / 1024;
                    cbDisks.Items.Add(disk[i].Name + "|" + freespace.ToString()+"GB");
                }
               
            }
           
        }
        
        private void nulldv()
        {
            int j = dgvfinger.ColumnCount;
            for (int i = 0; i < j; j--)
            {
                dgvfinger.Columns.RemoveAt(j - 1);
            }
        }
        private void nulldt(DataTable dt)
        {
            int j = dt.Columns.Count;
            for (int i = 0; i < j; j--)
            {
                dt.Columns.RemoveAt(j - 1);
            }
        }
        public void Loadlist()
        {
            nulldv();
            DataGridViewCheckBoxColumn ckcustomcode = new DataGridViewCheckBoxColumn();
            ckcustomcode.HeaderText = "一键下载";
            ckcustomcode.Name = "select";

            DataGridViewButtonColumn btcustomcode = new DataGridViewButtonColumn();
            btcustomcode.HeaderText = "下载";
            btcustomcode.Name = "download";
            btcustomcode.UseColumnTextForButtonValue = true;
            btcustomcode.Text = "下载考勤资料";

            DataGridViewTextBoxColumn txtstatus = new DataGridViewTextBoxColumn();
            txtstatus.Name = "status";
            txtstatus.HeaderText = "状态";


            // txtstatus. = "status";

            this.dgvfinger.Columns.Add(ckcustomcode);
            this.dgvfinger.Columns.Add(btcustomcode);
            this.dgvfinger.Columns.Add(txtstatus);

            DataTable flist = new DataTable();

            flist = fp.getfplist();
            if (flist.Rows.Count <= 0)
            {
                MessageBox.Show("没有指纹机，请知添加指纹机");
            }
            dgvfinger.DataSource = flist;
            this.dgvfinger.Columns["select"].Width = 40;
            this.dgvfinger.Columns["download"].Width = 80;
            this.dgvfinger.Columns["status"].Width = 80;
            this.dgvfinger.Columns["ip"].Width = 60;
            this.dgvfinger.Columns["port"].Width = 40;
            this.dgvfinger.Columns["name"].Width = 40;
            this.dgvfinger.Columns["dept"].Width = 40;

            this.dgvfinger.Columns["guid"].HeaderText = "GUID";
            this.dgvfinger.Columns["guid"].Visible = false;
            this.dgvfinger.Columns["ip"].HeaderText = "指纹机IP";
            this.dgvfinger.Columns["port"].HeaderText = "Port";
            this.dgvfinger.Columns["name"].HeaderText = "机名";
            this.dgvfinger.Columns["dept"].HeaderText = "部门";

            this.dgvfinger.Columns["house"].HeaderText = "栋别";
            this.dgvfinger.Columns["house"].Visible = false;

            this.dgvfinger.Columns["address"].HeaderText = "安装位置";
            this.dgvfinger.Columns["address"].Visible = false;

            this.dgvfinger.Columns["note"].HeaderText = "备注";
            this.dgvfinger.Columns["note"].Visible = false;

            this.dgvfinger.Columns["buydate"].HeaderText = "购买时间";
            this.dgvfinger.Columns["buydate"].Visible = false;

            this.dgvfinger.Columns["buyname"].HeaderText = "供货商";
            this.dgvfinger.Columns["buyname"].Visible = false;

            this.dgvfinger.Columns["buyfone"].HeaderText = "供货商电话";
            this.dgvfinger.Columns["buyfone"].Visible = false;

        }
        void DisplayCol(DataGridView dgv, String dataPropertyName, String headerText)
        {

            dgv.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn obj = new DataGridViewTextBoxColumn();
            obj.DataPropertyName = dataPropertyName;
            obj.HeaderText = headerText;
            obj.Name = dataPropertyName;
            obj.Resizable = DataGridViewTriState.True;
            dgv.Columns.AddRange(new DataGridViewColumn[] { obj });
        }
        private void ckaddfinger_CheckedChanged(object sender, EventArgs e)
        {
            if (ckaddfinger.Checked)
            {
                gbaddringer.Enabled = true;
                gbaddringer.Visible = true;

            }
            else
            {
                gbaddringer.Enabled = false;
                gbaddringer.Visible = false;
            }
        }
        private void btnaddfinger_Click(object sender, EventArgs e)
        {
            //  Guid guid { set; get; }
            string fip = txtfip.Text.Trim(); //不可为空
            string fport = txtfport.Text.Trim(); //不可为空
            string fname = txtfname.Text.Trim(); //不可为空
            string fdetp = cbfdept.Text.Trim();
            string fhouse = cbfhouse.Text.Trim();
            string faddress = txtfaddress.Text.Trim();
            string fnote = txtfnote.Text.Trim();
            this.dtpbuydate.Format = DateTimePickerFormat.Custom;
            this.dtpbuydate.CustomFormat = "yyyy-MM-dd";
            string fbuydate = dtpbuydate.Text;
            string fbuyname = txtbuyname.Text.Trim();
            string fbuyfone = txtbuyfone.Text.Trim();
            if (fip.Length <= 0 || fport.Length <= 0)
            {
                MessageBox.Show("IP与Port不可为空");
                return;
            }

            fps.guid = Guid.NewGuid();
            fps.fip = fip;
            fps.fport = fport;
            fps.fname = fname;
            fps.fdetp = fdetp;
            fps.fhouse = fhouse;
            fps.faddress = faddress;
            fps.fnote = fnote;
            fps.fbuydate = fbuydate;
            fps.fbuyname = fbuyname;
            fps.fbuyfone = fbuyfone;


            int result = fp.addfp(fps);
            if (result <= 0)
            {
                MessageBox.Show("添加指纹机失败！请检查数据", "添加指纹机");
                return;
            }
            MessageBox.Show("添加完成", "添加指纹机");
            Loadlist();

        }
        private void FrmFingerprintManager_SizeChanged(object sender, EventArgs e)
        {
            gbfingerlist.Width = this.Width - 470;
            gbfingerlist.Height = this.Height - 95;
            gbkey.Left = gbfingerlist.Width + 10;
            gbkey.Height = this.Height / 2;
            labbar.Top = this.Height - 65;
            labbar.Width = this.gbfingerlist.Width;
            jingdutiao.Top = this.Height - 65;
            jingdutiao.Left = gbkey.Left;
            jingdutiao.Width = gbkey.Width;
            groupBox2.Left = gbkey.Left;
            groupBox2.Top = this.Height / 2 + 40;
            groupBox2.Height = this.Height / 2 - 110;
            ckaddfinger.Left = this.Width - 100;
            btnrefresh.Left = this.Width - 190;
        }
        private void dgvfinger_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (this.dgvfinger.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) //true 不更新到数据库但要连接机器         
            {
                return;
            }

            string newmycolvalue = this.dgvfinger.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim();//值 
            if (mycolvalue.Equals(newmycolvalue))
            {
                return;
            };


            //if (DialogResult.OK == MessageBox.Show("是否要修改", "", MessageBoxButtons.OKCancel))
            //{
            string mycolname = this.dgvfinger.Columns[e.ColumnIndex].Name;//列名

            string myguid = this.dgvfinger.Rows[e.RowIndex].Cells["Guid"].Value.ToString();//GUID

            if (mycolname == "select")
            {
                //  MessageBox.Show("选择了");//做list确定选择项
                // return;
            }
            else
            {
                int count = fp.upfp(mycolname, newmycolvalue, myguid); //更新
                if (count <= 0)
                {
                    MessageBox.Show("修改失败");
                    return;
                }
            }
            // MessageBox.Show("更新成功！");
            //Thread thread = new Thread(DoWork);
            //thread.Start();
        }
        private void dgvfinger_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            if (this.dgvfinger.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                return;
            }
            mycolvalue = this.dgvfinger.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(); ;//值 
        }
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            Loadlist();
        }
        private void dgvfinger_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, rect, e.InheritedRowStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }
        private void btnselectfp_Click(object sender, EventArgs e)
        {
            bool isallselect = false;
            foreach (DataGridViewRow r in dgvfinger.Rows)
            {
                if (r.Cells["select"].EditedFormattedValue.ToString() == "True")
                {
                    isallselect = true;
                    btnselectfp.Text = "全选";
                    break;

                }
                else
                {
                    isallselect = false;
                    btnselectfp.Text = "全不选";
                    break;
                }
            }
            selectallboxno(isallselect);
        }
        public void selectallboxno(bool isallselect)
        {
            if (isallselect)
            {
                foreach (DataGridViewRow r in dgvfinger.Rows)
                {
                    this.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        r.Cells["select"].Value = false;
                    }));
                }
            }
            else
            {
                foreach (DataGridViewRow r in dgvfinger.Rows)
                {
                    this.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        r.Cells["select"].Value = true;
                    }));
                }
            }
        }
        private void btnonekeydownload_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Clearlist();
            if (!bgWorker.IsBusy)
            {
                bgWorker.RunWorkerAsync();
            }
            Cursor = Cursors.Default;
        }
        private bool Clearlist()
        {
            bool val = false;

            if (tpmdt.Rows.Count > 0)
            {
                DialogResult key = MessageBox.Show("已有下载考勤资料，还未上传，是否上传服务器？",
                    "温馨提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (key == DialogResult.Yes)//上传
                {
                    //  MessageBox.Show("YES");
                    val = true;
                    //  System.Environment.Exit(0);
                    //上传资料   
                    uploadlvlogs();
                    tpmdt.Clear();
                    nulldt(tpmdt);
                    lvLogs.Items.Clear();
                }
                if (key == DialogResult.No)//直接清除
                {
                    val = true;
                    tpmdt.Clear();
                    lvLogs.Items.Clear();
                    nulldt(tpmdt);
                    //  MessageBox.Show("NO");
                    // return;
                }
                if (key == DialogResult.Cancel)//什么也不做
                {
                    // MessageBox.Show("Cancel");
                    val = false;
                    return val;
                }
            }
            //清除资料
            do
            {
                listView1.Items.Clear();
            } while (listView1.Items.Count > 0);
            nulldt(tpmdt);
            Thread.Sleep(0);
            val = true;
            return val;
        }
        private void uploadlvlogs()
        {

            if (tpmdt.Rows.Count <= 0)
            {
                MessageBox.Show("考勤资料为空，请先下载考勤资料");
                return;
            }

            int result = fp.uploadtoserver(tpmdt);//结果行
                                                  // MessageBox.Show(result.ToString());
            if (result <= 0)
            {
                MessageBox.Show("上传失败");
                return;
            }
            // attlist.Clear();
            tpmdt.Clear();
            lvLogs.Items.Clear();

            MessageBox.Show("上传完成");

        }
        private void DoWork_Link(object sender, DoWorkEventArgs args)
        {
            //Thread t1 = new Thread(test);
            //t1.IsBackground = true;
            //t1.Start();
            List<fplinks> fpss = new List<fplinks>();
            BackgroundWorker worker = sender as BackgroundWorker;


            tpmdt.Columns.Add("guid", typeof(Guid));
            tpmdt.Columns.Add("xuhao", typeof(int));
            tpmdt.Columns.Add("userid", typeof(int));
            tpmdt.Columns.Add("data", typeof(DateTime));
            tpmdt.Columns.Add("fip", typeof(string));



            string sip = "";
            int sstrport = 0;
            int iMachineNumber = 0;

            bool bIsConnected = false;//连接网络结果
            bool fpIsConnected = false;//连接指纹机结果

            int idwErrorCode = 0; //错误代码

            string sdwEnrollNumber = ""; //登记号码
            int idwVerifyMode = 0; //验证模式  0为密码验证，  1为指纹验证，  2为卡验证 
            int idwInOutMode = 0; //考勤状态：0 checkIn 1 CheckOut 2 BreakOut 3 BreakIn 4 OtIn 5 OtOut 
            int idwYear = 0; //年
            int idwMonth = 0;//月
            int idwDay = 0;//日
            int idwHour = 0;//时
            int idwMinute = 0;//分
            int dwSecond = 0;//秒 
            int dwWorkCode = 0;
            //  int iGLCount = 0; //记录总数
            int iIndex = 0;//记录索引
            string data = "";

            worker.ReportProgress(100, secont);
            secont.Log = DateTime.Now.ToString() + ":数据:正在计算要下载的考勤机...";

            //            Cursor = Cursors.WaitCursor;
            foreach (DataGridViewRow r in dgvfinger.Rows)
            {

                if (r.Cells["select"].EditedFormattedValue.ToString() == "True")
                {
                    fplinks iplist = new fplinks();

                    iplist.ip = r.Cells["ip"].Value.ToString();
                    iplist.strport = r.Cells["port"].Value.ToString();
                    iplist.name = r.Cells["name"].Value.ToString();

                    if (iplist.ip.Length > 0 && iplist.strport.Length > 0)
                    {
                        fpss.Add(iplist);
                    }
                }


            }
            if (fpss.Count <= 0)
            {
                MessageBox.Show("至少选择1台指纹机");
                // axCZKEM1.EnableDevice(iMachineNumber, true);//启用机器
                // args.Cancel = true;
                //bgWorker.CancelAsync();
                //bgWorker.Dispose();//释放资源 
                return;


            }
            int selfpcount = fpss.Count;
            if (selfpcount > 0)
            {

                for (int i = 0; i < selfpcount; i++)
                {
                    ////取消任务
                    //预防一轮重新连接指纹机
                    if (worker.CancellationPending)
                    {
                        secont.Log = DateTime.Now.ToString() + " :用户取消任务";
                        worker.ReportProgress(0, secont);
                        axCZKEM1.EnableDevice(iMachineNumber, true);//启用机器
                        Thread.Sleep(0);
                        args.Cancel = true;
                        return;
                    }

                    DataTable tpm = new DataTable();//写入显示用
                    tpm.Columns.Add("guid", typeof(Guid));
                    tpm.Columns.Add("xuhao", typeof(int));
                    tpm.Columns.Add("userid", typeof(int));
                    tpm.Columns.Add("data", typeof(DateTime));
                    tpm.Columns.Add("fip", typeof(string));

                    sip = fpss[i].ip;
                    sstrport = Convert.ToInt32(fpss[i].strport);
                    iMachineNumber = Convert.ToInt32(fpss[i].name);
                    worker.ReportProgress(i * 100 / selfpcount, secont);
                    secont.Log = DateTime.Now.ToString() + ":网络:" + sip + "正在连接网络...";

                    bIsConnected = TestConnection(sip, sstrport, 1000);
                    if (bIsConnected)  //连接网络结果
                    {
                        //设置当前行背景为黄色
                        if (lvLogs.InvokeRequired)
                        {
                            SetColour setcolour = new SetColour(setBackgroundcolor);
                            this.BeginInvoke(setcolour, sip, Color.Aqua, new object[] { "正在连接指纹机..." });
                        }
                        else
                        {
                            setBackgroundcolor(sip, Color.Aqua, "正在连接指纹机");
                        }
                        //
                        worker.ReportProgress(i * 100 / selfpcount, secont);
                        secont.Log = DateTime.Now.ToString() + ":网络:" + sip + " 连接成功!正在连接考勤机...";
                        axCZKEM1 = new zkemkeeper.CZKEMClass();
                        fpIsConnected = axCZKEM1.Connect_Net(sip, sstrport);//连接指纹机比较慢
                        //一般连接指纹机比较慢 可以在此停下来
                        //取消任务
                        if (worker.CancellationPending)
                        {
                            secont.Log = DateTime.Now.ToString() + " :用户取消任务";
                            worker.ReportProgress(0, secont);
                            axCZKEM1.EnableDevice(iMachineNumber, true);//启用机器
                            Thread.Sleep(0);
                            args.Cancel = true;
                            return;
                        }
                    }
                    else
                    {
                        //设置当前行背景为红色
                        if (lvLogs.InvokeRequired)
                        {
                            SetColour setcolour = new SetColour(setBackgroundcolor);
                            this.BeginInvoke(setcolour, sip, Color.Red,
                                new object[] { "网络不通" });

                        }
                        else
                        {
                            setBackgroundcolor(sip, Color.Red, "网络不通");
                        }
                        worker.ReportProgress(i * 100 / selfpcount, secont);
                        secont.Log = DateTime.Now.ToString() + ":网络:" + sip + " 连接失败!请检查网络...";
                        secont.Result = DateTime.Now.ToString() + ":网络:" + sip + " 连接失败!";
                        continue;
                    }
                    if (fpIsConnected)  //连接指纹机结果
                    {


                        //设置当前行背景为绿色
                        if (lvLogs.InvokeRequired)
                        {
                            SetColour setcolour = new SetColour(setBackgroundcolor);

                            this.BeginInvoke(setcolour, sip, Color.Green,
                               new object[] { "正在下载..." });
                        }
                        else
                        {
                            setBackgroundcolor(sip, Color.Green, "正在下载...");
                        }

                        worker.ReportProgress(i * 100 / selfpcount, secont);
                        //获取考勤记录总数
                        secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 连接成功!正在下载考勤数据...";
                        //下载
                        axCZKEM1.EnableDevice(iMachineNumber, false);//禁用这台机器
                        if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//把所有的考勤记录读到内存中
                        {
                            while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode, out idwInOutMode,
                                         out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out dwSecond, ref dwWorkCode))
                            {
                                //跳过空指针记录
                                if (sdwEnrollNumber != null || sdwEnrollNumber.Trim().Length > 0)
                                {
                                    //iGLCount++;
                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    //secont.IGLCount = iGLCount.ToString();
                                    //secont.SdwEnrollNumber = sdwEnrollNumber.ToString();

                                    data = idwYear.ToString() + "-" + idwMonth.ToString() + "-" +
                                        idwDay.ToString() + " " + idwHour.ToString()
                                        + ":" + idwMinute.ToString() + ":" + dwSecond.ToString();//日期时间
                                    //secont.Data = data.ToString();
                                    //secont.Sip = sip.ToString();
                                    //lvLogs.Items.Add(iGLCount.ToString());//序号
                                    //lvLogs.Items[iIndex].SubItems.Add(sdwEnrollNumber);//登记号码
                                    //                                                   //  lvLogs.Items[iIndex].SubItems.Add(idwVerifyMode.ToString());//验证模式
                                    //                                                   // lvLogs.Items[iIndex].SubItems.Add(idwInOutMode.ToString());//考勤状态
                                    //lvLogs.Items[iIndex].SubItems.Add(idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString());//日期时间
                                    //lvLogs.Items[iIndex].SubItems.Add(iMachineNumber.ToString());//机器IP
                                    iIndex++;
                                    DataRow dr = tpmdt.NewRow();
                                    dr["guid"] = Guid.NewGuid();
                                    dr["xuhao"] = iIndex;
                                    dr["userid"] = Convert.ToInt32(sdwEnrollNumber);
                                    dr["data"] = Convert.ToDateTime(data);
                                    dr["fip"] = sip.ToString();
                                    tpmdt.Rows.Add(dr);

                                    //DataRow tpmdr = tpm.NewRow();
                                    DataRow tpmdr = tpm.NewRow();
                                    tpmdr["guid"] = Guid.NewGuid();
                                    tpmdr["xuhao"] = iIndex;
                                    tpmdr["userid"] = Convert.ToInt32(sdwEnrollNumber);
                                    tpmdr["data"] = Convert.ToDateTime(data);
                                    tpmdr["fip"] = sip.ToString();
                                    tpm.Rows.Add(tpmdr);
                                }
                                Thread.Sleep(0);//如果界面卡了 会写入不了记录 造成少记录的结果出现
                            }
                            int ivalue = 0;
                            axCZKEM1.GetDeviceStatus(iMachineNumber, 6, ref ivalue);//获取总记录总和
                                                                                    // this.lbRTShow.Items.Add("指纹机：" + txtIP.Text + " 的当前状态为:" + ivalue.ToString());
                                                                                    //设置当前行背景为淡灰色
                            if (lvLogs.InvokeRequired)
                            {
                                SetColour setcolour = new SetColour(setBackgroundcolor);
                                // this.BeginInvoke(setcolour, sip, Color.LightGray, "下载完成.记录数：" + ivalue.ToString());
                                this.BeginInvoke(setcolour, sip, Color.LightGray,
                               new object[] { "下载完成.记录数：" + ivalue.ToString() });
                            }
                            else
                            {
                                setBackgroundcolor(sip, Color.LightGray, "下载完成.记录数：" + ivalue.ToString());
                            }
                            worker.ReportProgress(i * 100 / selfpcount, secont);
                            secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 下载考勤数据成功...";
                            //委托异步调用
                            //a、委托的BeginInvoke方法，在线程池分配的子线程中执行委托
                            //b、委托执行时不会阻塞主线程（调用委托的BeginInvoke线程），主线程继续向下执行。
                            //c、委托执行时会阻塞子线程。
                            //d、委托结束时，如果有返回值，子线程讲返回值传递给主线程；如果有回调函数，子线程将继续执行回调函数。
                            //完事之后 ，更新listview
                            if (lvLogs.InvokeRequired)
                            {
                                OutDelegate outdelegate = new OutDelegate(OutText);
                                this.BeginInvoke(outdelegate, new object[] { tpm }); //委托异步调用

                                //  return;
                            }
                            else
                            {
                                OutText(tpm);
                            }

                            ////委托同步调用
                            ////a、委托的Invoke方法，在当前线程中执行委托。
                            ////b、委托执行时阻塞当前线程，知道委托执行完毕，当前线程才继续向下执行。
                            ////c、委托的Invoke方法，类似方法的常规调用。
                            ////完事之后 ，更新listview
                            //if (lvLogs.InvokeRequired)
                            //{
                            //    OutDelegate outdelegate = new OutDelegate(OutText);
                            //    this.Invoke(outdelegate, new object[] { tpm }); //委托同步调用
                            //    //  return;
                            //}
                            //else
                            //{
                            //    OutText(tpm);
                            //}

                            //   uplistview(tpm);
                        }
                        else
                        {

                            worker.ReportProgress(i * 100 / selfpcount, secont);
                            secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 下载考勤数据失败，正在获取失败原因...";
                            secont.Result = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 下载考勤数据失败，正在获取失败原因...";
                            axCZKEM1.GetLastError(ref idwErrorCode);//获取最后一次错误信息
                            switch (idwErrorCode)
                            {
                                case -100:
                                    //设置当前行背景为红色
                                    if (lvLogs.InvokeRequired)
                                    {
                                        SetColour setcolour = new SetColour(setBackgroundcolor);

                                        this.BeginInvoke(setcolour, sip, Color.Red,
                                            new object[] { "不支持或数据存在" });
                                    }
                                    else
                                    {
                                        setBackgroundcolor(sip, Color.Red, "不支持或数据存在");
                                    }
                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + " 失败原因：不支持或数据存在.";
                                    secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 不支持或数据存在";
                                    break;
                                case -10:
                                    //设置当前行背景为红色
                                    if (lvLogs.InvokeRequired)
                                    {
                                        SetColour setcolour = new SetColour(setBackgroundcolor);
                                        //this.BeginInvoke(setcolour, Color.Red, "传输的数据长度不对");
                                        this.BeginInvoke(setcolour, sip, Color.Red,
                                            new object[] { "传输的数据长度不对" });
                                    }
                                    else
                                    {
                                        setBackgroundcolor(sip, Color.Red, "传输的数据长度不对");
                                    }
                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 传输的数据长度不对";
                                    secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + "  失败原因：传输的数据长度不对.";
                                    break;
                                case -5:
                                    if (lvLogs.InvokeRequired)
                                    {
                                        SetColour setcolour = new SetColour(setBackgroundcolor);
                                        // this.BeginInvoke(setcolour, Color.Red, "数据已经存在");
                                        this.BeginInvoke(setcolour, sip, Color.Red,
                                            new object[] { "数据已经存在" });
                                    }
                                    else
                                    {
                                        setBackgroundcolor(sip, Color.Red, "数据已经存在");
                                    }
                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 数据已经存在";
                                    secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + "  失败原因：数据已经存在.";
                                    break;
                                case -4:
                                    if (lvLogs.InvokeRequired)
                                    {
                                        SetColour setcolour = new SetColour(setBackgroundcolor);
                                        //  this.BeginInvoke(setcolour, Color.Red, "空间不足");
                                        this.BeginInvoke(setcolour, sip, Color.Red,
                                           new object[] { "空间不足" });
                                    }
                                    else
                                    {
                                        setBackgroundcolor(sip, Color.Red, "空间不足");
                                    }
                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 空间不足";
                                    secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + "  失败原因：空间不足.";
                                    break;
                                case -3:
                                    if (lvLogs.InvokeRequired)
                                    {
                                        SetColour setcolour = new SetColour(setBackgroundcolor);
                                        // this.BeginInvoke(setcolour, Color.Red, "错误的大小");
                                        this.BeginInvoke(setcolour, sip, Color.Red,
                                          new object[] { "错误的大小" });
                                    }
                                    else
                                    {
                                        setBackgroundcolor(sip, Color.Red, "错误的大小");
                                    }
                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 错误的大小";
                                    secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + " 失败原因： 错误的大小.";
                                    break;
                                case -2:
                                    if (lvLogs.InvokeRequired)
                                    {
                                        SetColour setcolour = new SetColour(setBackgroundcolor);
                                        // this.BeginInvoke(setcolour, Color.Red, "文件读写错误");

                                        this.BeginInvoke(setcolour, sip, Color.Red,
                                       new object[] { "文件读写错误" });
                                    }
                                    else
                                    {
                                        setBackgroundcolor(sip, Color.Red, "文件读写错误");
                                    }
                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 文件读写错误";
                                    secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + "  失败原因：文件读写错误.";
                                    break;
                                case -1:
                                    if (lvLogs.InvokeRequired)
                                    {
                                        SetColour setcolour = new SetColour(setBackgroundcolor);
                                        //this.BeginInvoke(setcolour, Color.Red, "SDK未初始化,需要重新连接");
                                        this.BeginInvoke(setcolour, sip, Color.Red,
                                      new object[] { "SDK未初始化,需要重新连接" });
                                    }
                                    else
                                    {
                                        setBackgroundcolor(sip, Color.Red, "SDK未初始化,需要重新连接");
                                    }
                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " SDK未初始化,需要重新连接";
                                    secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + "  失败原因：SDK未初始化,需要重新连接.";
                                    break;
                                case 0:
                                    if (lvLogs.InvokeRequired)
                                    {
                                        SetColour setcolour = new SetColour(setBackgroundcolor);
                                        //this.BeginInvoke(setcolour, Color.Red, "没有数据");
                                        this.BeginInvoke(setcolour, sip, Color.Red,
                                         new object[] { "没有数据" });
                                    }
                                    else
                                    {
                                        setBackgroundcolor(sip, Color.Red, "没有数据");
                                    }
                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 没有数据";
                                    secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + " 失败原因： 没有数据.";
                                    break;
                                case 1:
                                    if (lvLogs.InvokeRequired)
                                    {
                                        SetColour setcolour = new SetColour(setBackgroundcolor);
                                        //  this.BeginInvoke(setcolour, Color.Red, "操作正确");
                                        this.BeginInvoke(setcolour, sip, Color.Red,
                                        new object[] { "操作正确" });
                                    }
                                    else
                                    {
                                        setBackgroundcolor(sip, Color.Red, "操作正确");
                                    }
                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 操作正确";
                                    secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + "  失败原因：操作正确.";
                                    break;
                                case 4:
                                    if (lvLogs.InvokeRequired)
                                    {
                                        SetColour setcolour = new SetColour(setBackgroundcolor);
                                        //this.BeginInvoke(setcolour, Color.Red, "参数错误");
                                        this.BeginInvoke(setcolour, sip, Color.Red,
                                       new object[] { "参数错误" });
                                    }
                                    else
                                    {
                                        setBackgroundcolor(sip, Color.Red, "参数错误");
                                    }

                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 参数错误";
                                    secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + "  失败原因：参数错误.";
                                    break;
                                case 101:
                                    if (lvLogs.InvokeRequired)
                                    {
                                        SetColour setcolour = new SetColour(setBackgroundcolor);
                                        // this.BeginInvoke(setcolour, Color.Red, "分配缓冲区错误");
                                        this.BeginInvoke(setcolour, sip, Color.Red,
                                            new object[] { "分配缓冲区错误" });
                                    }
                                    else
                                    {
                                        setBackgroundcolor(sip, Color.Red, "分配缓冲区错误");
                                    }
                                    worker.ReportProgress(i * 100 / selfpcount, secont);
                                    secont.Log = DateTime.Now.ToString() + ":指纹机: " + iMachineNumber + " 分配缓冲区错误";
                                    secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + " 失败原因： 分配缓冲区错误.";
                                    break;
                            }
                        }
                        //启用机器
                        axCZKEM1.EnableDevice(iMachineNumber, true);//启用机器
                    }
                    else
                    {
                        //设置当前行背景为红色
                        if (lvLogs.InvokeRequired)
                        {
                            SetColour setcolour = new SetColour(setBackgroundcolor);
                            //  this.BeginInvoke(setcolour, Color.Red, "连接失败");
                            this.BeginInvoke(setcolour, sip, Color.Red,
                                           new object[] { "连接失败" });
                        }
                        else
                        {
                            setBackgroundcolor(sip, Color.Red, "连接失败");
                        }
                        worker.ReportProgress(i * 100 / selfpcount, secont);
                        secont.Log = DateTime.Now.ToString() + ":指纹机:" + sip + " 连接失败!请重试...";
                        secont.Result = DateTime.Now.ToString() + ":指纹机:" + sip + " 连接失败!";
                        continue;
                    }

                }
                worker.ReportProgress(0, secont);
                secont.Log = DateTime.Now.ToString() + "所有考勤机下载数据完成";

                //完事之后 ，更新listview
                //if (lvLogs.InvokeRequired)
                //{
                //    OutDelegate outdelegate = new OutDelegate(OutText);
                //    this.BeginInvoke(outdelegate, new object[] { tpmdt });
                //    //  return;
                //}
                //else
                //{
                //    OutText(tpmdt);
                //}
                // }
                //axCZKEM1.EnableDevice(iMachineNumber, true);//启用机器
            }                                           // Cursor = Cursors.Default;

        }
        public void uplistview(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                lvLogs.Clear();
                //string reIGLCount = "";
                string reSdwEnrollNumber = "";
                string reData = "";
                string reSip = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    reSdwEnrollNumber = dt.Rows[i]["userid"].ToString();
                    reData = dt.Rows[i]["data"].ToString();
                    reSip = dt.Rows[i]["fip"].ToString();


                    lvLogs.Items.Add(new ListViewItem(new string[] { i.ToString(), reSdwEnrollNumber, reData, reSip }));
                    this.lvLogs.EnsureVisible(this.lvLogs.Items.Count - 1);
                    this.lvLogs.Items[this.lvLogs.Items.Count - 1].Checked = true;

                }
            }
        }
        /// <summary>
        /// 测试网络连接性
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="millisecondsTimeout"></param>
        /// <returns></returns>
        public bool TestConnection(string ip, int port, int millisecondsTimeout)
        {
            TcpClient client = new TcpClient();
            try
            {
                var ar = client.BeginConnect(ip, port, null, null);
                ar.AsyncWaitHandle.WaitOne(millisecondsTimeout);
                return client.Connected;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                client.Close();
            }
        }
        public class fplinks
        {
            public string ip { set; get; }
            public string strport { set; get; }
            public string value { set; get; }
            public string name { set; get; }


        }
        #region 重画进度条
        /// <summary>
        /// 重画进度条
        /// </summary>

        class DataGridViewProgressColumn : DataGridViewImageColumn
        {
            public DataGridViewProgressColumn()
            {
                this.CellTemplate = new DataGridViewProgressCell();
            }
        }
        class DataGridViewProgressCell : DataGridViewImageCell
        {
            static Image emptyImage;
            static DataGridViewProgressCell()
            {
                emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            }
            public DataGridViewProgressCell()
            {
                this.ValueType = typeof(int);
            }
            public string ShowText { get; set; } //如果要显示独立的文字而不是百分比，设置此属性。
            protected override object GetFormattedValue(object value,
                                int rowIndex, ref DataGridViewCellStyle cellStyle,
                                TypeConverter valueTypeConverter,
                                TypeConverter formattedValueTypeConverter,
                                DataGridViewDataErrorContexts context)
            {
                return emptyImage;
            }

            protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
            {
                string tValue = "";
                if (ShowText == null || ShowText == "")
                {
                    ShowText = "未连接";
                }

                if (value == null)
                {
                    tValue = "0";
                }
                else
                {
                    tValue = value.ToString();
                }
                //  string tValue = value.ToString();
                // string tValue = "30";
                if (tValue == "")
                {
                    tValue = "0";
                }
                int progressVal;
                try { progressVal = Convert.ToInt32(tValue); }
                catch
                {
                    progressVal = 0;
                }
                float percentage = ((float)progressVal / 100.0f);
                Brush backColorBrush = new SolidBrush(cellStyle.BackColor);
                Brush foreColorBrush = new SolidBrush(cellStyle.ForeColor);
                base.Paint(g, clipBounds, cellBounds,
                 rowIndex, cellState, value, formattedValue, errorText,
                 cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));

                string DrawStringStr = progressVal.ToString() + "%";
                if (ShowText != "")
                {
                    DrawStringStr = ShowText;
                }
                if (percentage > 0.0)
                {
                    g.FillRectangle(new SolidBrush(Color.FromArgb(163, 189, 242)), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 4);
                    g.DrawString(DrawStringStr, cellStyle.Font, foreColorBrush, cellBounds.X + 30, cellBounds.Y + 5);
                }
                else
                {
                    if (this.DataGridView.CurrentRow.Index == rowIndex)
                        g.DrawString(DrawStringStr, cellStyle.Font, new SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 30, cellBounds.Y + 5);
                    else
                        g.DrawString(DrawStringStr, cellStyle.Font, foreColorBrush, cellBounds.X + 30, cellBounds.Y + 5);
                }
            }
        }
        #endregion

        private void dgvfinger_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (e.RowIndex >= 0)
            {
                string val = this.dgvfinger["guid", e.RowIndex].Value.ToString();
                DataGridViewColumn column = dgvfinger.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    //这里可以编写你需要的任意关于按钮事件的操作~

                    foreach (DataGridViewRow r in dgvfinger.Rows)
                    {
                        this.BeginInvoke(new MethodInvoker(delegate ()
                        {
                            r.Cells["select"].Value = false;
                        }));
                    }
                    for (int i = 0; i < dgvfinger.Rows.Count; i++)
                    {
                        if (dgvfinger.Rows[i].Cells["guid"].Value.ToString() == val)
                        {
                            var bi = this.Invoke(new MethodInvoker(delegate ()
                            {
                                dgvfinger.Rows[i].Cells["select"].Value = true;//全部完成之后再执行 BeginInvoke i会超出数组
                            }));

                            continue;

                        }
                    }
                    if (Clearlist())
                    {
                        if (!bgWorker.IsBusy)
                        {
                            bgWorker.RunWorkerAsync();
                        }
                    };
                }
            }
            Cursor = Cursors.Default;   //DGV下拉框的取值
                                        // MessageBox.Show(dgvfinger.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString());
        }

        private void lvLogs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tomeClearl.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tomeClearl.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void meclearl_Click(object sender, EventArgs e)
        {
            Clearlist();
        }

        private void btuploadtoserver_Click(object sender, EventArgs e)
        {
            if (tpmdt.Rows.Count <= 0)
            {
                MessageBox.Show("考勤资料为空，请先下载考勤资料");
                return;
            }
            // if (lvLogs.Items.Count<=0)
            // {
            //     MessageBox.Show("考勤资料为空，请先下载考勤资料");
            //     return;
            // }
            //// DataTable dt = new DataTable();

            // List<att> attlist = new List<att>();
            // for (int i=0;i< lvLogs.Items.Count;i++)
            // {
            //     att useratt = new att();
            //     useratt.guid = Guid.NewGuid();
            //     useratt.userid = Convert.ToInt32(lvLogs.Items[i].SubItems[1].Text);
            //     useratt.data = Convert.ToDateTime(lvLogs.Items[i].SubItems[2].Text);
            //     useratt.fip = Convert.ToString(lvLogs.Items[i].SubItems[3].Text);
            //     attlist.Add(useratt);
            // }

            int result = fp.uploadtoserver(tpmdt);//结果行
                                                  // MessageBox.Show(result.ToString());
            if (result <= 0)
            {
                MessageBox.Show("上传失败");
                return;
            }
            lvLogs.Clear();
            tpmdt.Clear();
            nulldt(tpmdt);
            MessageBox.Show("上传完成");

            //lvLogs.Items.Clear();
        }

        public void OutText(DataTable dt)
        {
            //if (lvLogs.InvokeRequired)
            //{
            //    OutDelegate outdelegate = new OutDelegate(OutText);
            //    this.BeginInvoke(outdelegate, new object[] { tpmdt });
            //    return;
            //}
            // lvLogs.AppendText(text);
            // lvLogs.AppendText("\t\n");
            string uid = "";
            string uhao = "";
            string udata = "";
            string uip = "";


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                uid = dt.Rows[i]["userid"].ToString();
                uhao = dt.Rows[i]["xuhao"].ToString();
                udata = dt.Rows[i]["data"].ToString();
                uip = dt.Rows[i]["fip"].ToString();

                lvLogs.Items.Add(new ListViewItem(new string[] { uhao, uid, udata, uip }));
                this.lvLogs.EnsureVisible(this.lvLogs.Items.Count - 1);
                this.lvLogs.Items[this.lvLogs.Items.Count - 1].Checked = true;
            }
            dt.Dispose();
        }
        public void setBackgroundcolor(string sip, Color color, object values)
        {
            string value = Convert.ToString(((object[])values)[0]);
            for (int i = 0; i < dgvfinger.Rows.Count; i++)
            {
                if (dgvfinger.Rows[i].Cells["ip"].Value.ToString() == sip)
                {
                    dgvfinger.Rows[i].DefaultCellStyle.BackColor = color;
                    dgvfinger.Rows[i].Cells["status"].Value = value;
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {


            bgWorker.CancelAsync();
            bgWorker.Dispose();//释放资源 
        }
        #region 上传文件到FTP服务器
        //
        private void button1_Click(object sender, EventArgs e)
        {
            //增加进度条
            Thread myThread = new Thread(DoData);
            myThread.IsBackground = true;
            myThread.Start(); //线程开始  
            dt = DateTime.Now;  //开始记录当前时间  

            //for (int i=0;i< filenum;i++)
            //{

            //}
            //MessageBox.Show("上传成功!");
            // this.listBox2.Items.Add(NextFile.Name);

            // Upload(filename, ftpServerIP, ftpUserID, ftpPassword);

        }
        private delegate void DoDataDelegate( );

        /// <summary>  
        /// 进行循环  
        /// </summary>  
        /// <param name="number"></param>  
        private void DoData( )
        {
            
            bool upresuls = false;//上传结果
            bool bkresuls = false;//备份到D盘结果
            ////第一种方法
            //var files = Directory.GetFiles(path, "*.exe");
            //foreach (var file in files)
            //    Console.WriteLine(file);

            //第二种方法
            DirectoryInfo folder = new DirectoryInfo(sourcePath);
            int filenum = 0;
            //判断路径
            if (!Directory.Exists(sourcePath))
            {
                MessageBox.Show("文件夹' " + sourcePath + " '不存在！");
                return;
            }

            //获取文件数量
            List<string> filenames = new List<string>();
            foreach (FileInfo file in folder.GetFiles("*.jpg"))
            {
                filenames.Add(file.FullName);
                   //  string filename = file.FullName;
                   //Upload(filename, ftpServerIP, ftpUserID, ftpPassword);
                   // Console.WriteLine(file.FullName);
                   filenum++;
            }
            if (filenum <= 0)
            {
                MessageBox.Show("文件夹' " + sourcePath + " '下没有图片文件！");
                return;
            }
            /////

            if (jingdutiao.InvokeRequired)
            {
                DoDataDelegate d = DoData;
                jingdutiao.Invoke(d);
            }
            else
            {
                jingdutiao.Maximum = filenum;
                 isDisk = Directory.Exists(BKDisk);
                if (!isDisk)
                {
                    MessageBox.Show("备份失败，没有" + BKDisk + "盘。只进行上传到服务器，请注意手动备份！");                 
                }

                for (int i = 0; i < filenum; i++)
                {
                    string filename = filenames[i];
                    upresuls = Upload(filename, ftpServerIP, ftpUserID, ftpPassword);//上传
                    //盘符是否存在，存在备份，不存在 只上传
                    if (isDisk)
                    {
                        bkresuls = BKtoDisk(filename);//备份到D盘
                    } 

                    if (upresuls && bkresuls)//上传和备份都成功的时候 删除照片
                    {

                        System.IO.File.Delete(filename);
                      //  System.Threading.Thread.Sleep(2000);

                    }
                    labbar.Text= "正在上传" + filename ;
                    jingdutiao.Value = i;
                    label11.Text = (i+1).ToString()+"/" + filenum.ToString();
                   
                  
                    Application.DoEvents();
                }
                jingdutiao.Value = 0;
                if (isDisk)//上传和备份都成功的时候 删除照片
                {
                  
                    MessageBox.Show("上传完成,共花费时间：\r\n" + DateTime.Now.Subtract(dt).ToString() + "\r\n"
                                                    + @"备份完成,备份目录为 " + BKDisk + @"WRJIT\IMG\指令号\",
                                                    "上传、备份完成", MessageBoxButtons.OK);  //循环结束截止时间  
                }
                else
                {
                    
                    MessageBox.Show("上传完成,共花费时间：\r\n" + DateTime.Now.Subtract(dt).ToString() + "\r\n"
                                                    + @"注意没有备份",
                                                    "上传完成、没有备份", MessageBoxButtons.OK);  //循环结束截止时间  
                }
                
            }
            //测试是否上传成功，失败的怎么处理
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            jingdutiao.Value = 0;
            
        }
        /// <summary>
        /// 盘符是否存在
        ///存在盘符，自建目录
        ///没有盘符，返回false
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>备份结果</returns>

        private bool BKtoDisk(string filename)
        {
            if (!Directory.Exists(BKDisk))
            {
                MessageBox.Show("备份失败，没有"+ BKDisk + "盘。");
                return false;
            }
            FileInfo fileInf = new FileInfo(filename);
          
            string[] dirs = fileInf.Name.Split('_');
            string dir = dirs[0];
            string ToPath = BKDisk+@"WRJITIMG\" + dir + @"\";

            if (!System.IO.Directory.Exists(ToPath))
                
            {
                try {
                    System.IO.Directory.CreateDirectory(ToPath);
                   
                } catch  {
                    MessageBox.Show("目标位置没有写入权限");
                    isDisk = false;
                    return false;

                }

               
            }
            string destFile = ToPath + fileInf.Name;

           
            if (System.IO.File.Exists(filename))
            {
                System.IO.File.Copy(filename, destFile, true);
            }
            else
            {
                MessageBox.Show("没有找到原文件" + filename + "备份失败", "备份失败",MessageBoxButtons.OK);
                return false;
            }
            return true;

        }
        //D盘目录是否存在
        public bool  DiskPathCheck(string destFilePath)
        {
            

            string fullDir = FtpParseDirectory(destFilePath);
            string[] dirs = fullDir.Split('/');
            string curDir = "/";
            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i];
                //如果是以/开始的路径,第一个为空    
                if (dir != null && dir.Length > 0)
                {
                    try
                    {
                        curDir += dir + "/";
                        FtpMakeDir(curDir);
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                    }
                }
            }
            return false;
        }
        private bool Upload(string filename, string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            
            FileInfo fileInf = new FileInfo(filename);

            string ftpPath = hname + "/";

            string[] dirs = fileInf.Name.Split('_');
            //  string curDir = "/";
            //  for (int i = 0; i < dirs.Length; i++)
            // {
            string dir = dirs[0];

            ftpPath = ftpPath + dir + "/";
            FtpWebRequest reqFTP;

            FtpCheckDirectoryExist(ftpPath);
            string uri = ftpServerIP + "/" + ftpPath + fileInf.Name;
            //FileInfo fi = new FileInfo(localFile);
            //FileStream fs = fi.OpenRead();
            //long length = fs.Length;
            //FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpServerIP + ftpPath + fi.Name);

            //reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "上传出错");
                return false;
            }
            return true;
            // MessageBox.Show("上传成功!");
        }
        
        //判断文件的目录是否存,不存则创建  
        public static void FtpCheckDirectoryExist(string destFilePath)
        {
            string fullDir = FtpParseDirectory(destFilePath);
            string[] dirs = fullDir.Split('/');
            string curDir = "/";
            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i];
                //如果是以/开始的路径,第一个为空    
                if (dir != null && dir.Length > 0)
                {
                    try
                    {
                        curDir += dir + "/";
                        FtpMakeDir(curDir);
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                    }
                }
            }
        }

        public static string FtpParseDirectory(string destFilePath)
        {
            return destFilePath.Substring(0, destFilePath.LastIndexOf("/"));
        }

        //创建目录  
        public static Boolean FtpMakeDir(string localFile)
        {
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpServerIP + localFile);
            req.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            req.Method = WebRequestMethods.Ftp.MakeDirectory;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                req.Abort();
                return false;
            }
            req.Abort();
            return true;
        }
        #endregion

        private void cbDisks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tmp= cbDisks.SelectedItem.ToString();
            string[] tmps = tmp.Split('|');
            BKDisk = tmps[0];
        }

        private void FrmFingerprintManager_Activated(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
