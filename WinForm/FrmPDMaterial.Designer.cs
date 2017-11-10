namespace WinForm
{
    partial class FrmPDMaterial
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbMaterialClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaterialCodePrefix = new System.Windows.Forms.TextBox();
            this.txtDesignRemark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.gbpd = new System.Windows.Forms.GroupBox();
            this.dgvmaterial = new System.Windows.Forms.DataGridView();
            this.meEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.meCopyRows = new System.Windows.Forms.ToolStripMenuItem();
            this.meCopyCell = new System.Windows.Forms.ToolStripMenuItem();
            this.meImproExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.gbpd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmaterial)).BeginInit();
            this.meEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMaterialClass
            // 
            this.cbMaterialClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterialClass.FormattingEnabled = true;
            this.cbMaterialClass.Location = new System.Drawing.Point(70, 5);
            this.cbMaterialClass.Name = "cbMaterialClass";
            this.cbMaterialClass.Size = new System.Drawing.Size(121, 20);
            this.cbMaterialClass.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "物料大类";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "物料简码";
            // 
            // txtMaterialCodePrefix
            // 
            this.txtMaterialCodePrefix.Location = new System.Drawing.Point(265, 5);
            this.txtMaterialCodePrefix.Name = "txtMaterialCodePrefix";
            this.txtMaterialCodePrefix.Size = new System.Drawing.Size(100, 21);
            this.txtMaterialCodePrefix.TabIndex = 3;
            // 
            // txtDesignRemark
            // 
            this.txtDesignRemark.Location = new System.Drawing.Point(434, 5);
            this.txtDesignRemark.Name = "txtDesignRemark";
            this.txtDesignRemark.Size = new System.Drawing.Size(100, 21);
            this.txtDesignRemark.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "色号";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(596, 5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 26);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // gbpd
            // 
            this.gbpd.Controls.Add(this.dgvmaterial);
            this.gbpd.Location = new System.Drawing.Point(2, 29);
            this.gbpd.Name = "gbpd";
            this.gbpd.Size = new System.Drawing.Size(672, 346);
            this.gbpd.TabIndex = 7;
            this.gbpd.TabStop = false;
            this.gbpd.Text = "库存明细";
            // 
            // dgvmaterial
            // 
            this.dgvmaterial.AllowUserToAddRows = false;
            this.dgvmaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvmaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvmaterial.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvmaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvmaterial.Location = new System.Drawing.Point(3, 17);
            this.dgvmaterial.Name = "dgvmaterial";
            this.dgvmaterial.ReadOnly = true;
            this.dgvmaterial.RowTemplate.Height = 23;
            this.dgvmaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvmaterial.Size = new System.Drawing.Size(666, 326);
            this.dgvmaterial.TabIndex = 0;
            this.dgvmaterial.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvmaterial_CellMouseDown);
            this.dgvmaterial.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvmaterial_RowPostPaint);
            // 
            // meEdit
            // 
            this.meEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.meCopyRows,
            this.meCopyCell,
            this.meImproExcel});
            this.meEdit.Name = "编辑";
            this.meEdit.Size = new System.Drawing.Size(185, 70);
            this.meEdit.Text = "编辑";
            // 
            // meCopyRows
            // 
            this.meCopyRows.Name = "meCopyRows";
            this.meCopyRows.Size = new System.Drawing.Size(184, 22);
            this.meCopyRows.Text = "复选当前单元格";
            this.meCopyRows.Click += new System.EventHandler(this.meCopyRows_Click);
            // 
            // meCopyCell
            // 
            this.meCopyCell.Name = "meCopyCell";
            this.meCopyCell.Size = new System.Drawing.Size(184, 22);
            this.meCopyCell.Text = "复制选中行到剪贴板";
            this.meCopyCell.Click += new System.EventHandler(this.meCopyCell_Click);
            // 
            // meImproExcel
            // 
            this.meImproExcel.Name = "meImproExcel";
            this.meImproExcel.Size = new System.Drawing.Size(184, 22);
            this.meImproExcel.Text = "导出此表到EXCEL";
            this.meImproExcel.Click += new System.EventHandler(this.meImproExcel_Click);
            // 
            // FrmPDMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 389);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.gbpd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDesignRemark);
            this.Controls.Add(this.txtMaterialCodePrefix);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbMaterialClass);
            this.Name = "FrmPDMaterial";
            this.Text = "原物料仓盘点";
            this.Activated += new System.EventHandler(this.FrmPDMaterial_Activated);
            this.Load += new System.EventHandler(this.FrmPDMaterial_Load);
            this.Resize += new System.EventHandler(this.FrmPDMaterial_Resize);
            this.gbpd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmaterial)).EndInit();
            this.meEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMaterialClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaterialCodePrefix;
        private System.Windows.Forms.TextBox txtDesignRemark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox gbpd;
        private System.Windows.Forms.DataGridView dgvmaterial;
        private System.Windows.Forms.ContextMenuStrip meEdit;
        private System.Windows.Forms.ToolStripMenuItem meCopyRows;
        private System.Windows.Forms.ToolStripMenuItem meCopyCell;
        private System.Windows.Forms.ToolStripMenuItem meImproExcel;
    }
}