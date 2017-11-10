namespace WinForm
{
    partial class FrmMenuManager
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvList = new System.Windows.Forms.TreeView();
            this.btnreload = new System.Windows.Forms.Button();
            this.btndeletemune = new System.Windows.Forms.Button();
            this.txtmunnamech = new System.Windows.Forms.TextBox();
            this.txtmunnameen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbfmune = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddMenu = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labmune = new System.Windows.Forms.Label();
            this.txtckmune = new System.Windows.Forms.TextBox();
            this.btnchangmune = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtorderno = new System.Windows.Forms.TextBox();
            this.btndown = new System.Windows.Forms.Button();
            this.btnup = new System.Windows.Forms.Button();
            this.btnchangNO = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.labckmune = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvList);
            this.groupBox1.Controls.Add(this.btnreload);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 316);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "菜单";
            // 
            // tvList
            // 
            this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvList.Location = new System.Drawing.Point(3, 17);
            this.tvList.Name = "tvList";
            this.tvList.Size = new System.Drawing.Size(202, 296);
            this.tvList.TabIndex = 5;
            this.tvList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvList_NodeMouseDoubleClick);
            // 
            // btnreload
            // 
            this.btnreload.Location = new System.Drawing.Point(141, 0);
            this.btnreload.Name = "btnreload";
            this.btnreload.Size = new System.Drawing.Size(47, 19);
            this.btnreload.TabIndex = 24;
            this.btnreload.Text = "刷新";
            this.btnreload.UseVisualStyleBackColor = true;
            this.btnreload.Click += new System.EventHandler(this.btnreload_Click);
            // 
            // btndeletemune
            // 
            this.btndeletemune.Location = new System.Drawing.Point(183, 14);
            this.btndeletemune.Name = "btndeletemune";
            this.btndeletemune.Size = new System.Drawing.Size(75, 23);
            this.btndeletemune.TabIndex = 26;
            this.btndeletemune.Text = "删除菜单";
            this.btndeletemune.UseVisualStyleBackColor = true;
            this.btndeletemune.Click += new System.EventHandler(this.btndeletemune_Click);
            // 
            // txtmunnamech
            // 
            this.txtmunnamech.Location = new System.Drawing.Point(105, 43);
            this.txtmunnamech.Name = "txtmunnamech";
            this.txtmunnamech.Size = new System.Drawing.Size(121, 21);
            this.txtmunnamech.TabIndex = 27;
            // 
            // txtmunnameen
            // 
            this.txtmunnameen.Location = new System.Drawing.Point(105, 70);
            this.txtmunnameen.Name = "txtmunnameen";
            this.txtmunnameen.Size = new System.Drawing.Size(121, 21);
            this.txtmunnameen.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "显示菜单名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "系统菜单名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "父菜单";
            // 
            // cbfmune
            // 
            this.cbfmune.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfmune.FormattingEnabled = true;
            this.cbfmune.Location = new System.Drawing.Point(105, 17);
            this.cbfmune.Name = "cbfmune";
            this.cbfmune.Size = new System.Drawing.Size(121, 20);
            this.cbfmune.TabIndex = 33;
            this.cbfmune.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbfmune_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddMenu);
            this.groupBox2.Controls.Add(this.cbfmune);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtmunnameen);
            this.groupBox2.Controls.Add(this.txtmunnamech);
            this.groupBox2.Location = new System.Drawing.Point(219, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 128);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加菜单";
            // 
            // btnAddMenu
            // 
            this.btnAddMenu.Location = new System.Drawing.Point(118, 97);
            this.btnAddMenu.Name = "btnAddMenu";
            this.btnAddMenu.Size = new System.Drawing.Size(75, 23);
            this.btnAddMenu.TabIndex = 34;
            this.btnAddMenu.Text = "添加菜单";
            this.btnAddMenu.UseVisualStyleBackColor = true;
            this.btnAddMenu.Click += new System.EventHandler(this.btnAddMenu_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labmune);
            this.groupBox3.Controls.Add(this.btndeletemune);
            this.groupBox3.Location = new System.Drawing.Point(219, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(275, 41);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "删除菜单";
            // 
            // labmune
            // 
            this.labmune.AutoSize = true;
            this.labmune.Font = new System.Drawing.Font("宋体", 15F);
            this.labmune.ForeColor = System.Drawing.Color.Red;
            this.labmune.Location = new System.Drawing.Point(17, 14);
            this.labmune.Name = "labmune";
            this.labmune.Size = new System.Drawing.Size(0, 20);
            this.labmune.TabIndex = 27;
            // 
            // txtckmune
            // 
            this.txtckmune.Location = new System.Drawing.Point(80, 19);
            this.txtckmune.Name = "txtckmune";
            this.txtckmune.Size = new System.Drawing.Size(121, 21);
            this.txtckmune.TabIndex = 37;
            // 
            // btnchangmune
            // 
            this.btnchangmune.Location = new System.Drawing.Point(207, 18);
            this.btnchangmune.Name = "btnchangmune";
            this.btnchangmune.Size = new System.Drawing.Size(59, 23);
            this.btnchangmune.TabIndex = 39;
            this.btnchangmune.Text = "确认";
            this.btnchangmune.UseVisualStyleBackColor = true;
            this.btnchangmune.Click += new System.EventHandler(this.btnchangmune_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.btnchangmune);
            this.groupBox4.Controls.Add(this.txtckmune);
            this.groupBox4.Location = new System.Drawing.Point(219, 137);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(272, 53);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "修改菜单";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "菜单新名";
            // 
            // txtorderno
            // 
            this.txtorderno.Location = new System.Drawing.Point(94, 47);
            this.txtorderno.Name = "txtorderno";
            this.txtorderno.Size = new System.Drawing.Size(31, 21);
            this.txtorderno.TabIndex = 46;
            // 
            // btndown
            // 
            this.btndown.Location = new System.Drawing.Point(188, 47);
            this.btndown.Name = "btndown";
            this.btndown.Size = new System.Drawing.Size(75, 23);
            this.btndown.TabIndex = 45;
            this.btndown.Text = "下移一位";
            this.btndown.UseVisualStyleBackColor = true;
            // 
            // btnup
            // 
            this.btnup.Location = new System.Drawing.Point(188, 17);
            this.btnup.Name = "btnup";
            this.btnup.Size = new System.Drawing.Size(75, 23);
            this.btnup.TabIndex = 44;
            this.btnup.Text = "上移一位";
            this.btnup.UseVisualStyleBackColor = true;
            // 
            // btnchangNO
            // 
            this.btnchangNO.Location = new System.Drawing.Point(131, 47);
            this.btnchangNO.Name = "btnchangNO";
            this.btnchangNO.Size = new System.Drawing.Size(43, 23);
            this.btnchangNO.TabIndex = 47;
            this.btnchangNO.Text = "確認";
            this.btnchangNO.UseVisualStyleBackColor = true;
            this.btnchangNO.Click += new System.EventHandler(this.btnchangNO_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.labckmune);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.btnchangNO);
            this.groupBox5.Controls.Add(this.txtorderno);
            this.groupBox5.Controls.Add(this.btndown);
            this.groupBox5.Controls.Add(this.btnup);
            this.groupBox5.Location = new System.Drawing.Point(219, 196);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(275, 76);
            this.groupBox5.TabIndex = 48;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "菜單順序";
            // 
            // labckmune
            // 
            this.labckmune.AutoSize = true;
            this.labckmune.Font = new System.Drawing.Font("宋体", 15F);
            this.labckmune.ForeColor = System.Drawing.Color.Red;
            this.labckmune.Location = new System.Drawing.Point(28, 18);
            this.labckmune.Name = "labckmune";
            this.labckmune.Size = new System.Drawing.Size(0, 20);
            this.labckmune.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "位置序號";
            // 
            // FrmMenuManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 322);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMenuManager";
            this.Text = "系统菜单管理";
            this.Load += new System.EventHandler(this.FrmMemuManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tvList;
        private System.Windows.Forms.Button btnreload;
        private System.Windows.Forms.Button btndeletemune;
        private System.Windows.Forms.TextBox txtmunnamech;
        private System.Windows.Forms.TextBox txtmunnameen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbfmune;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAddMenu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtckmune;
        private System.Windows.Forms.Button btnchangmune;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labmune;
        private System.Windows.Forms.TextBox txtorderno;
        private System.Windows.Forms.Button btndown;
        private System.Windows.Forms.Button btnup;
        private System.Windows.Forms.Button btnchangNO;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label labckmune;
        private System.Windows.Forms.Label label4;
    }
}