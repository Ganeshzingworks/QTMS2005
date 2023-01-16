namespace QTMS.Reports_Forms
{
    partial class FrmTestMethodMaster_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTestMethodMaster_Report));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMfgWo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.DtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDetails = new System.Windows.Forms.ComboBox();
            this.lblFormulaNo = new System.Windows.Forms.Label();
            this.BtnShow = new System.Windows.Forms.Button();
            this.ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbMfgWo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DtpDateTo);
            this.panel1.Controls.Add(this.DtpDateFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbDetails);
            this.panel1.Controls.Add(this.lblFormulaNo);
            this.panel1.Controls.Add(this.BtnShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 99);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 64;
            this.label4.Text = "MfgWo";
            this.label4.Visible = false;
            // 
            // cmbMfgWo
            // 
            this.cmbMfgWo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMfgWo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMfgWo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMfgWo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMfgWo.FormattingEnabled = true;
            this.cmbMfgWo.Location = new System.Drawing.Point(91, 41);
            this.cmbMfgWo.Name = "cmbMfgWo";
            this.cmbMfgWo.Size = new System.Drawing.Size(197, 24);
            this.cmbMfgWo.TabIndex = 63;
            this.cmbMfgWo.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 62;
            this.label2.Text = "To";
            this.label2.Visible = false;
            // 
            // DtpDateTo
            // 
            this.DtpDateTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtpDateTo.Checked = false;
            this.DtpDateTo.CustomFormat = "dd-MMM-yyyy";
            this.DtpDateTo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateTo.Location = new System.Drawing.Point(135, 55);
            this.DtpDateTo.Name = "DtpDateTo";
            this.DtpDateTo.ShowCheckBox = true;
            this.DtpDateTo.Size = new System.Drawing.Size(147, 23);
            this.DtpDateTo.TabIndex = 61;
            this.DtpDateTo.Value = new System.DateTime(2008, 1, 19, 0, 0, 0, 0);
            this.DtpDateTo.Visible = false;
            // 
            // DtpDateFrom
            // 
            this.DtpDateFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtpDateFrom.Checked = false;
            this.DtpDateFrom.CustomFormat = "dd-MMM-yyyy";
            this.DtpDateFrom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateFrom.Location = new System.Drawing.Point(135, 19);
            this.DtpDateFrom.Name = "DtpDateFrom";
            this.DtpDateFrom.ShowCheckBox = true;
            this.DtpDateFrom.Size = new System.Drawing.Size(147, 23);
            this.DtpDateFrom.TabIndex = 59;
            this.DtpDateFrom.Value = new System.DateTime(2008, 1, 25, 0, 0, 0, 0);
            this.DtpDateFrom.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "From";
            this.label1.Visible = false;
            // 
            // cmbDetails
            // 
            this.cmbDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDetails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDetails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDetails.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDetails.FormattingEnabled = true;
            this.cmbDetails.Location = new System.Drawing.Point(392, 36);
            this.cmbDetails.Name = "cmbDetails";
            this.cmbDetails.Size = new System.Drawing.Size(197, 24);
            this.cmbDetails.TabIndex = 53;
            this.cmbDetails.SelectionChangeCommitted += new System.EventHandler(this.cmbDetails_SelectionChangeCommitted);
            // 
            // lblFormulaNo
            // 
            this.lblFormulaNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFormulaNo.AutoSize = true;
            this.lblFormulaNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormulaNo.Location = new System.Drawing.Point(306, 40);
            this.lblFormulaNo.Name = "lblFormulaNo";
            this.lblFormulaNo.Size = new System.Drawing.Size(81, 16);
            this.lblFormulaNo.TabIndex = 51;
            this.lblFormulaNo.Text = "Formula No";
            // 
            // BtnShow
            // 
            this.BtnShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnShow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.Location = new System.Drawing.Point(628, 31);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(77, 34);
            this.BtnShow.TabIndex = 46;
            this.BtnShow.Text = "SHOW";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // ReportViewer
            // 
            this.ReportViewer.ActiveViewIndex = -1;
            this.ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewer.DisplayGroupTree = false;
            this.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer.Location = new System.Drawing.Point(0, 99);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.SelectionFormula = "";
            this.ReportViewer.Size = new System.Drawing.Size(963, 503);
            this.ReportViewer.TabIndex = 46;
            this.ReportViewer.ViewTimeSelectionFormula = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ReportViewer);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(963, 602);
            this.panel2.TabIndex = 54;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(963, 30);
            this.panelTop.TabIndex = 55;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonClose});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(963, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonClose.BackColor = System.Drawing.Color.White;
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClose.Image")));
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QTMS.Properties.Resources.Processing;
            this.pictureBox1.Location = new System.Drawing.Point(582, 353);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // FrmTestMethodMaster_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 632);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTestMethodMaster_Report";
            this.Text = "Test Method Master Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRM_Analysis_Report_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.Label lblFormulaNo;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewer;
        private System.Windows.Forms.ComboBox cmbDetails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMfgWo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpDateTo;
        private System.Windows.Forms.DateTimePicker DtpDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}