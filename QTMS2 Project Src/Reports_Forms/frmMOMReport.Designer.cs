namespace QTMS.Reports_Forms
{
    partial class frmMOMReport
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
            this.cmbmom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnShow = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rptviewmom = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panelMid = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbVesselNo = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtvessel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBatchsize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbformula = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelMid.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbmom
            // 
            this.cmbmom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbmom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbmom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbmom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbmom.FormattingEnabled = true;
            this.cmbmom.Location = new System.Drawing.Point(73, 8);
            this.cmbmom.Name = "cmbmom";
            this.cmbmom.Size = new System.Drawing.Size(252, 24);
            this.cmbmom.TabIndex = 0;
            this.cmbmom.SelectionChangeCommitted += new System.EventHandler(this.cmbmom_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 57;
            this.label3.Text = "MOM No.";
            // 
            // BtnShow
            // 
            this.BtnShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnShow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.Location = new System.Drawing.Point(88, 46);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(85, 34);
            this.BtnShow.TabIndex = 1;
            this.BtnShow.Text = "SHOW";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonClose});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1028, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonClose.BackColor = System.Drawing.Color.White;
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = global::QTMS.Properties.Resources.cancel;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rptviewmom);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1028, 630);
            this.panel3.TabIndex = 50;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // rptviewmom
            // 
            this.rptviewmom.ActiveViewIndex = -1;
            this.rptviewmom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptviewmom.DisplayGroupTree = false;
            this.rptviewmom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptviewmom.Location = new System.Drawing.Point(0, 0);
            this.rptviewmom.Name = "rptviewmom";
            this.rptviewmom.SelectionFormula = "";
            this.rptviewmom.Size = new System.Drawing.Size(1028, 630);
            this.rptviewmom.TabIndex = 0;
            this.rptviewmom.ViewTimeSelectionFormula = "";
            // 
            // panelMid
            // 
            this.panelMid.Controls.Add(this.groupBox3);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMid.Location = new System.Drawing.Point(0, 30);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(1028, 86);
            this.panelMid.TabIndex = 49;
            this.panelMid.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMid_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbVesselNo);
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.txtvessel);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtBatchsize);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cmbformula);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbmom);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.BtnShow);
            this.groupBox3.Location = new System.Drawing.Point(3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1233, 80);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            // 
            // cmbVesselNo
            // 
            this.cmbVesselNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVesselNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVesselNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbVesselNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVesselNo.FormattingEnabled = true;
            this.cmbVesselNo.Location = new System.Drawing.Point(841, 9);
            this.cmbVesselNo.Name = "cmbVesselNo";
            this.cmbVesselNo.Size = new System.Drawing.Size(252, 24);
            this.cmbVesselNo.TabIndex = 5;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(179, 46);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 34);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtvessel
            // 
            this.txtvessel.Location = new System.Drawing.Point(841, 12);
            this.txtvessel.Name = "txtvessel";
            this.txtvessel.Size = new System.Drawing.Size(252, 20);
            this.txtvessel.TabIndex = 63;
            this.txtvessel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(763, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 62;
            this.label4.Text = "Vessel No.";
            // 
            // txtBatchsize
            // 
            this.txtBatchsize.Location = new System.Drawing.Point(472, 42);
            this.txtBatchsize.Name = "txtBatchsize";
            this.txtBatchsize.Size = new System.Drawing.Size(252, 20);
            this.txtBatchsize.TabIndex = 4;
            this.txtBatchsize.Leave += new System.EventHandler(this.txtBatchsize_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(376, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "Batch Size.";
            // 
            // cmbformula
            // 
            this.cmbformula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbformula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbformula.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbformula.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbformula.FormattingEnabled = true;
            this.cmbformula.Location = new System.Drawing.Point(472, 9);
            this.cmbformula.Name = "cmbformula";
            this.cmbformula.Size = new System.Drawing.Size(252, 24);
            this.cmbformula.TabIndex = 3;
            this.cmbformula.SelectionChangeCommitted += new System.EventHandler(this.cmbformula_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 58;
            this.label1.Text = "Formula No.";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1028, 30);
            this.panelTop.TabIndex = 48;
            // 
            // frmMOMReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panelTop);
            this.Name = "frmMOMReport";
            this.Text = "frmMOMReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMOMReport_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelMid.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbmom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panelTop;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptviewmom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVesselNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBatchsize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbformula;
        private System.Windows.Forms.TextBox txtvessel;

    }
}