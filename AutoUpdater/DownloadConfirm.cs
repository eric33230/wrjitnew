using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using zengzhouming.Update;

namespace zengzhouming.Update
{
    public partial class DownloadConfirm : Form
    {
        List<DownloadFileInfo> downloadFileList = null;

        public DownloadConfirm(List<DownloadFileInfo> dfl)
        {
            InitializeComponent();

            downloadFileList = dfl;
        }

        private void OnLoad(object sender, EventArgs e)
        {
           // string remake = "";
            foreach (DownloadFileInfo file in this.downloadFileList)
            {
                ListViewItem item = new ListViewItem(new string[] { file.FileName, file.LastVer, file.Size.ToString() });
               // remake = file.ReMark;
                this.listDownloadFile.Items.Add(item);
                txtUpdateStr.Text = file.ReMark;

            }
             
            this.Activate();
            this.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void listDownloadFile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}