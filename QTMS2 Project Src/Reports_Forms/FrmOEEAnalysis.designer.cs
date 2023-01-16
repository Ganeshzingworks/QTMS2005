namespace QTMS.Reports_Forms
{
    partial class FrmOEEAnalysis 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOEEAnalysis));
            this.oEEReportAnalysis2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oEEReportAnalysis2 = new QTMS.Reports.OEEReportAnalysis2();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelMid = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbTechFamily = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbVessel = new System.Windows.Forms.ComboBox();
            this.BtnShow = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbDailyPUR = new System.Windows.Forms.RadioButton();
            this.cmbGroupBy = new System.Windows.Forms.ComboBox();
            this.lblGroupBy = new System.Windows.Forms.Label();
            this.rdoDetails = new System.Windows.Forms.RadioButton();
            this.rdoSummary = new System.Windows.Forms.RadioButton();
            this.rdoMonthWise = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.DtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.oEEReportAnalysis2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oEEReportAnalysis2)).BeginInit();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelMid.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // oEEReportAnalysis2BindingSource
            // 
            this.oEEReportAnalysis2BindingSource.DataSource = this.oEEReportAnalysis2;
            this.oEEReportAnalysis2BindingSource.Position = 0;
            // 
            // oEEReportAnalysis2
            // 
            this.oEEReportAnalysis2.DataSetName = "OEEReportAnalysis2";
            this.oEEReportAnalysis2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // panelMid
            // 
            this.panelMid.Controls.Add(this.groupBox3);
            this.panelMid.Controls.Add(this.groupBox2);
            this.panelMid.Controls.Add(this.groupBox1);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMid.Location = new System.Drawing.Point(0, 30);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(972, 121);
            this.panelMid.TabIndex = 46;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbTechFamily);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmbVessel);
            this.groupBox3.Controls.Add(this.BtnShow);
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Location = new System.Drawing.Point(449, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(420, 110);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            // 
            // cmbTechFamily
            // 
            this.cmbTechFamily.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTechFamily.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTechFamily.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbTechFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTechFamily.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTechFamily.FormattingEnabled = true;
            this.cmbTechFamily.Location = new System.Drawing.Point(146, 9);
            this.cmbTechFamily.Name = "cmbTechFamily";
            this.cmbTechFamily.Size = new System.Drawing.Size(252, 24);
            this.cmbTechFamily.TabIndex = 56;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 57;
            this.label3.Text = "Technical Family";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 57;
            this.label4.Text = "Vessel";
            // 
            // cmbVessel
            // 
            this.cmbVessel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbVessel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbVessel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbVessel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVessel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVessel.FormattingEnabled = true;
            this.cmbVessel.Location = new System.Drawing.Point(146, 39);
            this.cmbVessel.Name = "cmbVessel";
            this.cmbVessel.Size = new System.Drawing.Size(252, 24);
            this.cmbVessel.TabIndex = 56;
            // 
            // BtnShow
            // 
            this.BtnShow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnShow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.Location = new System.Drawing.Point(265, 69);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(85, 35);
            this.BtnShow.TabIndex = 51;
            this.BtnShow.Text = "SHOW";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(166, 69);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 35);
            this.btnReset.TabIndex = 51;
            this.btnReset.Text = "&RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbDailyPUR);
            this.groupBox2.Controls.Add(this.cmbGroupBy);
            this.groupBox2.Controls.Add(this.lblGroupBy);
            this.groupBox2.Controls.Add(this.rdoDetails);
            this.groupBox2.Controls.Add(this.rdoSummary);
            this.groupBox2.Controls.Add(this.rdoMonthWise);
            this.groupBox2.Location = new System.Drawing.Point(6, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 66);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            // 
            // rdbDailyPUR
            // 
            this.rdbDailyPUR.AutoSize = true;
            this.rdbDailyPUR.Location = new System.Drawing.Point(325, 14);
            this.rdbDailyPUR.Name = "rdbDailyPUR";
            this.rdbDailyPUR.Size = new System.Drawing.Size(74, 17);
            this.rdbDailyPUR.TabIndex = 59;
            this.rdbDailyPUR.TabStop = true;
            this.rdbDailyPUR.Text = "Daily PUR";
            this.rdbDailyPUR.UseVisualStyleBackColor = true;
            this.rdbDailyPUR.CheckedChanged += new System.EventHandler(this.rdbDailyPUR_CheckedChanged);
            // 
            // cmbGroupBy
            // 
            this.cmbGroupBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGroupBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroupBy.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupBy.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroupBy.FormattingEnabled = true;
            this.cmbGroupBy.Items.AddRange(new object[] {
            "--None--",
            "Tech Family",
            "Vessel",
            "Tech Family & Vessel"});
            this.cmbGroupBy.Location = new System.Drawing.Point(167, 36);
            this.cmbGroupBy.Name = "cmbGroupBy";
            this.cmbGroupBy.Size = new System.Drawing.Size(186, 24);
            this.cmbGroupBy.TabIndex = 56;
            // 
            // lblGroupBy
            // 
            this.lblGroupBy.AutoSize = true;
            this.lblGroupBy.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupBy.Location = new System.Drawing.Point(94, 39);
            this.lblGroupBy.Name = "lblGroupBy";
            this.lblGroupBy.Size = new System.Drawing.Size(67, 16);
            this.lblGroupBy.TabIndex = 57;
            this.lblGroupBy.Text = "Group By";
            // 
            // rdoDetails
            // 
            this.rdoDetails.AutoSize = true;
            this.rdoDetails.Location = new System.Drawing.Point(51, 14);
            this.rdoDetails.Name = "rdoDetails";
            this.rdoDetails.Size = new System.Drawing.Size(57, 17);
            this.rdoDetails.TabIndex = 58;
            this.rdoDetails.TabStop = true;
            this.rdoDetails.Text = "Details";
            this.rdoDetails.UseVisualStyleBackColor = true;
            this.rdoDetails.CheckedChanged += new System.EventHandler(this.rdoDetails_CheckedChanged);
            // 
            // rdoSummary
            // 
            this.rdoSummary.AutoSize = true;
            this.rdoSummary.Location = new System.Drawing.Point(132, 14);
            this.rdoSummary.Name = "rdoSummary";
            this.rdoSummary.Size = new System.Drawing.Size(68, 17);
            this.rdoSummary.TabIndex = 58;
            this.rdoSummary.TabStop = true;
            this.rdoSummary.Text = "Summary";
            this.rdoSummary.UseVisualStyleBackColor = true;
            this.rdoSummary.CheckedChanged += new System.EventHandler(this.rdoSummary_CheckedChanged);
            // 
            // rdoMonthWise
            // 
            this.rdoMonthWise.AutoSize = true;
            this.rdoMonthWise.Location = new System.Drawing.Point(224, 14);
            this.rdoMonthWise.Name = "rdoMonthWise";
            this.rdoMonthWise.Size = new System.Drawing.Size(82, 17);
            this.rdoMonthWise.TabIndex = 58;
            this.rdoMonthWise.TabStop = true;
            this.rdoMonthWise.Text = "Month Wise";
            this.rdoMonthWise.UseVisualStyleBackColor = true;
            this.rdoMonthWise.CheckedChanged += new System.EventHandler(this.rdoDetails_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtpDateFrom);
            this.groupBox1.Controls.Add(this.DtpDateTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 40);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            // 
            // DtpDateFrom
            // 
            this.DtpDateFrom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtpDateFrom.Checked = false;
            this.DtpDateFrom.CustomFormat = "dd-MMM-yyyy";
            this.DtpDateFrom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateFrom.Location = new System.Drawing.Point(72, 10);
            this.DtpDateFrom.Name = "DtpDateFrom";
            this.DtpDateFrom.ShowCheckBox = true;
            this.DtpDateFrom.Size = new System.Drawing.Size(140, 23);
            this.DtpDateFrom.TabIndex = 52;
            this.DtpDateFrom.Value = new System.DateTime(2010, 4, 5, 0, 0, 0, 0);
            // 
            // DtpDateTo
            // 
            this.DtpDateTo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DtpDateTo.Checked = false;
            this.DtpDateTo.CustomFormat = "dd-MMM-yyyy";
            this.DtpDateTo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateTo.Location = new System.Drawing.Point(249, 11);
            this.DtpDateTo.Name = "DtpDateTo";
            this.DtpDateTo.ShowCheckBox = true;
            this.DtpDateTo.Size = new System.Drawing.Size(134, 23);
            this.DtpDateTo.TabIndex = 54;
            this.DtpDateTo.Value = new System.DateTime(2010, 4, 5, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 53;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(218, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 16);
            this.label2.TabIndex = 55;
            this.label2.Text = "To";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.ReportViewer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 151);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(972, 590);
            this.panel3.TabIndex = 47;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::QTMS.Properties.Resources.Processing;
            this.pictureBox1.Location = new System.Drawing.Point(433, 250);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
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
            this.ReportViewer.Size = new System.Drawing.Size(972, 590);
            this.ReportViewer.TabIndex = 45;
            this.ReportViewer.ViewTimeSelectionFormula = "";
            // 
            // FrmOEEAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 741);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmOEEAnalysis";
            this.Text = "OEE Analysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmProtocol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oEEReportAnalysis2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oEEReportAnalysis2)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelMid.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panel3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpDateTo;
        private System.Windows.Forms.DateTimePicker DtpDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.ComboBox cmbTechFamily;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbVessel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGroupBy;
        private System.Windows.Forms.Label lblGroupBy;
        private System.Windows.Forms.RadioButton rdoDetails;
        private System.Windows.Forms.RadioButton rdoSummary;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton rdoMonthWise;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingSource oEEReportAnalysis2BindingSource;
        private QTMS.Reports.OEEReportAnalysis2 oEEReportAnalysis2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rdbDailyPUR;

    }
}