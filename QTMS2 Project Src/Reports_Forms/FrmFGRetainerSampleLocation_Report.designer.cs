namespace QTMS.Reports_Forms
{
    partial class FrmFGRetainerSampleLocation_Report
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbLocation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMfgWo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.DtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFGCode = new System.Windows.Forms.ComboBox();
            this.BtnShow = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 711);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ReportViewer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(972, 624);
            this.panel3.TabIndex = 1;
            // 
            // ReportViewer
            // 
            this.ReportViewer.ActiveViewIndex = -1;
            this.ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewer.DisplayGroupTree = false;
            this.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.SelectionFormula = "";
            this.ReportViewer.Size = new System.Drawing.Size(972, 624);
            this.ReportViewer.TabIndex = 45;
            this.ReportViewer.ViewTimeSelectionFormula = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CmbLocation);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbMfgWo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DtpDateTo);
            this.panel1.Controls.Add(this.DtpDateFrom);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbFGCode);
            this.panel1.Controls.Add(this.BtnShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 87);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(345, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 60;
            this.label5.Text = "Location";
            // 
            // CmbLocation
            // 
            this.CmbLocation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLocation.FormattingEnabled = true;
            this.CmbLocation.Location = new System.Drawing.Point(431, 14);
            this.CmbLocation.Name = "CmbLocation";
            this.CmbLocation.Size = new System.Drawing.Size(197, 24);
            this.CmbLocation.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(345, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 58;
            this.label4.Text = "MfgWo";
            this.label4.Visible = false;
            // 
            // cmbMfgWo
            // 
            this.cmbMfgWo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMfgWo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMfgWo.FormattingEnabled = true;
            this.cmbMfgWo.Location = new System.Drawing.Point(431, 47);
            this.cmbMfgWo.Name = "cmbMfgWo";
            this.cmbMfgWo.Size = new System.Drawing.Size(197, 24);
            this.cmbMfgWo.TabIndex = 57;
            this.cmbMfgWo.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 56;
            this.label2.Text = "To";
            // 
            // DtpDateTo
            // 
            this.DtpDateTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtpDateTo.Checked = false;
            this.DtpDateTo.CustomFormat = "dd-MMM-yyyy";
            this.DtpDateTo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateTo.Location = new System.Drawing.Point(170, 47);
            this.DtpDateTo.Name = "DtpDateTo";
            this.DtpDateTo.ShowCheckBox = true;
            this.DtpDateTo.Size = new System.Drawing.Size(147, 23);
            this.DtpDateTo.TabIndex = 55;
            this.DtpDateTo.Value = new System.DateTime(2008, 1, 19, 0, 0, 0, 0);
            // 
            // DtpDateFrom
            // 
            this.DtpDateFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtpDateFrom.Checked = false;
            this.DtpDateFrom.CustomFormat = "dd-MMM-yyyy";
            this.DtpDateFrom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateFrom.Location = new System.Drawing.Point(170, 11);
            this.DtpDateFrom.Name = "DtpDateFrom";
            this.DtpDateFrom.ShowCheckBox = true;
            this.DtpDateFrom.Size = new System.Drawing.Size(147, 23);
            this.DtpDateFrom.TabIndex = 53;
            this.DtpDateFrom.Value = new System.DateTime(2008, 1, 25, 0, 0, 0, 0);
            this.DtpDateFrom.ValueChanged += new System.EventHandler(this.DtpDateFrom_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 54;
            this.label1.Text = "From";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(345, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 52;
            this.label3.Text = "FG Code";
            this.label3.Visible = false;
            // 
            // cmbFGCode
            // 
            this.cmbFGCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbFGCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFGCode.FormattingEnabled = true;
            this.cmbFGCode.Location = new System.Drawing.Point(431, 14);
            this.cmbFGCode.Name = "cmbFGCode";
            this.cmbFGCode.Size = new System.Drawing.Size(197, 24);
            this.cmbFGCode.TabIndex = 51;
            this.cmbFGCode.Visible = false;
            this.cmbFGCode.SelectionChangeCommitted += new System.EventHandler(this.cmbFormulaNo_SelectionChangeCommitted);
            // 
            // BtnShow
            // 
            this.BtnShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnShow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.Location = new System.Drawing.Point(656, 14);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(80, 55);
            this.BtnShow.TabIndex = 46;
            this.BtnShow.Text = "SHOW";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(972, 30);
            this.panelTop.TabIndex = 45;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonClose});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(972, 30);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QTMS.Properties.Resources.Processing;
            this.pictureBox1.Location = new System.Drawing.Point(564, 328);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // FrmFGRetainerSampleLocation_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 741);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmFGRetainerSampleLocation_Report";
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmFormulaHistoryReport_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFGCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpDateTo;
        private System.Windows.Forms.DateTimePicker DtpDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMfgWo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbLocation;

    }
}