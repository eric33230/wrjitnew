namespace WinForm
{
    partial class FrmRoleManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roleGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgroles = new System.Windows.Forms.DataGridView();
            this.loginname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nousername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nologinname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noroleGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgnomeroles = new System.Windows.Forms.DataGridView();
            this.txemuname = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnadduser = new System.Windows.Forms.Button();
            this.btnMenuManager = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgroles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgnomeroles)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.HeaderText = "用户姓名";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Width = 80;
            // 
            // roleGuid
            // 
            this.roleGuid.HeaderText = "roleGuid";
            this.roleGuid.Name = "roleGuid";
            this.roleGuid.ReadOnly = true;
            this.roleGuid.Visible = false;
            // 
            // dgroles
            // 
            this.dgroles.AllowUserToAddRows = false;
            this.dgroles.AllowUserToResizeColumns = false;
            this.dgroles.AllowUserToResizeRows = false;
            this.dgroles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roleGuid,
            this.loginname,
            this.username});
            this.dgroles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgroles.Location = new System.Drawing.Point(3, 17);
            this.dgroles.Name = "dgroles";
            this.dgroles.ReadOnly = true;
            this.dgroles.RowHeadersVisible = false;
            this.dgroles.RowTemplate.Height = 23;
            this.dgroles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgroles.Size = new System.Drawing.Size(203, 233);
            this.dgroles.TabIndex = 4;
            this.dgroles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgroles_CellDoubleClick);
            // 
            // loginname
            // 
            this.loginname.HeaderText = "登录名";
            this.loginname.Name = "loginname";
            this.loginname.ReadOnly = true;
            this.loginname.ToolTipText = "10";
            this.loginname.Width = 80;
            // 
            // nousername
            // 
            this.nousername.HeaderText = "用户姓名";
            this.nousername.Name = "nousername";
            this.nousername.ReadOnly = true;
            this.nousername.Width = 80;
            // 
            // nologinname
            // 
            this.nologinname.HeaderText = "登录名";
            this.nologinname.Name = "nologinname";
            this.nologinname.ReadOnly = true;
            this.nologinname.Width = 80;
            // 
            // noroleGuid
            // 
            this.noroleGuid.HeaderText = "roleGuid";
            this.noroleGuid.Name = "noroleGuid";
            this.noroleGuid.Visible = false;
            // 
            // dgnomeroles
            // 
            this.dgnomeroles.AllowUserToAddRows = false;
            this.dgnomeroles.AllowUserToResizeColumns = false;
            this.dgnomeroles.AllowUserToResizeRows = false;
            this.dgnomeroles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgnomeroles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noroleGuid,
            this.nologinname,
            this.nousername});
            this.dgnomeroles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgnomeroles.Location = new System.Drawing.Point(3, 17);
            this.dgnomeroles.Name = "dgnomeroles";
            this.dgnomeroles.RowHeadersVisible = false;
            this.dgnomeroles.RowTemplate.Height = 23;
            this.dgnomeroles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgnomeroles.Size = new System.Drawing.Size(203, 233);
            this.dgnomeroles.TabIndex = 0;
            this.dgnomeroles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgnomeroles_CellDoubleClick);
            // 
            // txemuname
            // 
            this.txemuname.AutoSize = true;
            this.txemuname.Font = new System.Drawing.Font("宋体", 18F);
            this.txemuname.ForeColor = System.Drawing.Color.Navy;
            this.txemuname.Location = new System.Drawing.Point(79, 17);
            this.txemuname.Name = "txemuname";
            this.txemuname.Size = new System.Drawing.Size(0, 24);
            this.txemuname.TabIndex = 18;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgnomeroles);
            this.groupBox3.Location = new System.Drawing.Point(6, 55);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 253);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "无权限用户";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(289, 337);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 43);
            this.button3.TabIndex = 21;
            this.button3.Text = "刷新";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnadduser
            // 
            this.btnadduser.Location = new System.Drawing.Point(145, 337);
            this.btnadduser.Name = "btnadduser";
            this.btnadduser.Size = new System.Drawing.Size(75, 43);
            this.btnadduser.TabIndex = 20;
            this.btnadduser.Text = "新增用户";
            this.btnadduser.UseVisualStyleBackColor = true;
            this.btnadduser.Click += new System.EventHandler(this.btnadduser_Click);
            // 
            // btnMenuManager
            // 
            this.btnMenuManager.Location = new System.Drawing.Point(29, 337);
            this.btnMenuManager.Name = "btnMenuManager";
            this.btnMenuManager.Size = new System.Drawing.Size(75, 43);
            this.btnMenuManager.TabIndex = 19;
            this.btnMenuManager.Text = "菜单管理";
            this.btnMenuManager.UseVisualStyleBackColor = true;
            this.btnMenuManager.Click += new System.EventHandler(this.btnMenuManager_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(578, 337);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 43);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgroles);
            this.groupBox2.Location = new System.Drawing.Point(221, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 253);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "有权限用户";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(432, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 43);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 17);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(202, 296);
            this.treeView1.TabIndex = 5;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txemuname);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Location = new System.Drawing.Point(226, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(436, 316);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "设置";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 316);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "菜单";
            // 
            // FrmRoleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 387);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnadduser);
            this.Controls.Add(this.btnMenuManager);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRoleManager";
            this.Text = "角色权限管理";
            this.Activated += new System.EventHandler(this.FrmRoleManager_Activated);
            this.Load += new System.EventHandler(this.FrmRoleManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgroles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgnomeroles)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn roleGuid;
        private System.Windows.Forms.DataGridView dgroles;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginname;
        private System.Windows.Forms.DataGridViewTextBoxColumn nousername;
        private System.Windows.Forms.DataGridViewTextBoxColumn nologinname;
        private System.Windows.Forms.DataGridViewTextBoxColumn noroleGuid;
        private System.Windows.Forms.DataGridView dgnomeroles;
        private System.Windows.Forms.Label txemuname;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnadduser;
        private System.Windows.Forms.Button btnMenuManager;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}