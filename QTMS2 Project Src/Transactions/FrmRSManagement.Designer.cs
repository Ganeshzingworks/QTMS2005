namespace QTMS.Transactions
{
    partial class FrmRSManagement
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
            frmRSManagement_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPFLot = new System.Windows.Forms.TextBox();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpValidityDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMfgWo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFIFormulaNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpReceivingDate = new System.Windows.Forms.DateTimePicker();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.cmbRefLocation = new System.Windows.Forms.ComboBox();
            this.cmbWSmfgwo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.DtpWSValidityDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dgWSDetails = new System.Windows.Forms.DataGridView();
            this.WSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormulaNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MfgWo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidityDate = new QTMS.Tools.CalendarColumn();
            this.AnalysisReport = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.FMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbRMButtons = new System.Windows.Forms.GroupBox();
            this.BtnPMStatusChangeExit = new System.Windows.Forms.Button();
            this.BtnPMStatusChangeReset = new System.Windows.Forms.Button();
            this.BtnPMStatusChangeSave = new System.Windows.Forms.Button();
            this.dgRMStatusChangeFields = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cmbFormulaNo = new System.Windows.Forms.ComboBox();
            this.lblFormula = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWSDetails)).BeginInit();
            this.gbRMButtons.SuspendLayout();
            this.dgRMStatusChangeFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(824, 574);
            this.panelOuter.TabIndex = 87;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(822, 30);
            this.panelTop.TabIndex = 99;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonClose});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(822, 30);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(191, 27);
            this.toolStripLabel1.Text = "Reference Sample Management";
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
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFill);
            this.panelBottom.Location = new System.Drawing.Point(0, 30);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(822, 539);
            this.panelBottom.TabIndex = 98;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Controls.Add(this.gbFields);
            this.panelFill.Controls.Add(this.gbRMButtons);
            this.panelFill.Controls.Add(this.dgRMStatusChangeFields);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(822, 539);
            this.panelFill.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPFLot);
            this.groupBox1.Controls.Add(this.cmbCountry);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DtpValidityDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMfgWo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFIFormulaNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DtpReceivingDate);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 106);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reference sample for first industrial run";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label8.Location = new System.Drawing.Point(298, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "PF Lot";
            // 
            // txtPFLot
            // 
            this.txtPFLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPFLot.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPFLot.Location = new System.Drawing.Point(363, 58);
            this.txtPFLot.Name = "txtPFLot";
            this.txtPFLot.Size = new System.Drawing.Size(132, 23);
            this.txtPFLot.TabIndex = 5;
            // 
            // cmbCountry
            // 
            this.cmbCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCountry.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(129, 57);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(132, 24);
            this.cmbCountry.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label7.Location = new System.Drawing.Point(32, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Country";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(515, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Validity Date";
            // 
            // DtpValidityDate
            // 
            this.DtpValidityDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpValidityDate.Enabled = false;
            this.DtpValidityDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpValidityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpValidityDate.Location = new System.Drawing.Point(625, 58);
            this.DtpValidityDate.Name = "DtpValidityDate";
            this.DtpValidityDate.Size = new System.Drawing.Size(120, 23);
            this.DtpValidityDate.TabIndex = 6;
            this.DtpValidityDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label6.Location = new System.Drawing.Point(298, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mfg WO";
            // 
            // txtMfgWo
            // 
            this.txtMfgWo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMfgWo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMfgWo.Location = new System.Drawing.Point(363, 24);
            this.txtMfgWo.Name = "txtMfgWo";
            this.txtMfgWo.Size = new System.Drawing.Size(132, 23);
            this.txtMfgWo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(32, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Formula No";
            // 
            // txtFIFormulaNo
            // 
            this.txtFIFormulaNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFIFormulaNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFIFormulaNo.Location = new System.Drawing.Point(129, 24);
            this.txtFIFormulaNo.Name = "txtFIFormulaNo";
            this.txtFIFormulaNo.Size = new System.Drawing.Size(132, 23);
            this.txtFIFormulaNo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(515, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Receiving Date";
            // 
            // DtpReceivingDate
            // 
            this.DtpReceivingDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpReceivingDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpReceivingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpReceivingDate.Location = new System.Drawing.Point(625, 24);
            this.DtpReceivingDate.Name = "DtpReceivingDate";
            this.DtpReceivingDate.Size = new System.Drawing.Size(120, 23);
            this.DtpReceivingDate.TabIndex = 3;
            this.DtpReceivingDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            this.DtpReceivingDate.ValueChanged += new System.EventHandler(this.DtpReceivingDate_ValueChanged);
            // 
            // gbFields
            // 
            this.gbFields.Controls.Add(this.cmbRefLocation);
            this.gbFields.Controls.Add(this.cmbWSmfgwo);
            this.gbFields.Controls.Add(this.label9);
            this.gbFields.Controls.Add(this.btnAdd);
            this.gbFields.Controls.Add(this.label11);
            this.gbFields.Controls.Add(this.DtpWSValidityDate);
            this.gbFields.Controls.Add(this.label10);
            this.gbFields.Controls.Add(this.dgWSDetails);
            this.gbFields.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFields.Location = new System.Drawing.Point(15, 225);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(791, 225);
            this.gbFields.TabIndex = 2;
            this.gbFields.TabStop = false;
            this.gbFields.Text = "Working standard details";
            // 
            // cmbRefLocation
            // 
            this.cmbRefLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRefLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRefLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRefLocation.FormattingEnabled = true;
            this.cmbRefLocation.Location = new System.Drawing.Point(128, 26);
            this.cmbRefLocation.Name = "cmbRefLocation";
            this.cmbRefLocation.Size = new System.Drawing.Size(132, 24);
            this.cmbRefLocation.TabIndex = 7;
            // 
            // cmbWSmfgwo
            // 
            this.cmbWSmfgwo.FormattingEnabled = true;
            this.cmbWSmfgwo.Location = new System.Drawing.Point(342, 28);
            this.cmbWSmfgwo.Name = "cmbWSmfgwo";
            this.cmbWSmfgwo.Size = new System.Drawing.Size(131, 21);
            this.cmbWSmfgwo.TabIndex = 1;
            this.cmbWSmfgwo.SelectionChangeCommitted += new System.EventHandler(this.cmbWSmfgwo_SelectionChangeCommitted);
            this.cmbWSmfgwo.SelectedIndexChanged += new System.EventHandler(this.cmbWSmfgwo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label9.Location = new System.Drawing.Point(32, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Ref Location";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.Location = new System.Drawing.Point(732, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 24);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(479, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "Validity Date";
            // 
            // DtpWSValidityDate
            // 
            this.DtpWSValidityDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpWSValidityDate.Enabled = false;
            this.DtpWSValidityDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpWSValidityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpWSValidityDate.Location = new System.Drawing.Point(577, 26);
            this.DtpWSValidityDate.Name = "DtpWSValidityDate";
            this.DtpWSValidityDate.Size = new System.Drawing.Size(120, 23);
            this.DtpWSValidityDate.TabIndex = 2;
            this.DtpWSValidityDate.Value = new System.DateTime(2010, 4, 17, 0, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label10.Location = new System.Drawing.Point(276, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Mfg WO";
            // 
            // dgWSDetails
            // 
            this.dgWSDetails.AllowUserToAddRows = false;
            this.dgWSDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgWSDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgWSDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgWSDetails.ColumnHeadersHeight = 25;
            this.dgWSDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WSID,
            this.FormulaNo,
            this.MfgWo,
            this.RefLocation,
            this.ValidityDate,
            this.AnalysisReport,
            this.Delete,
            this.FMID,
            this.LocID});
            this.dgWSDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgWSDetails.Location = new System.Drawing.Point(3, 56);
            this.dgWSDetails.MultiSelect = false;
            this.dgWSDetails.Name = "dgWSDetails";
            this.dgWSDetails.RowHeadersWidth = 20;
            this.dgWSDetails.Size = new System.Drawing.Size(785, 166);
            this.dgWSDetails.TabIndex = 4;
            this.dgWSDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgWSDetails_CellClick);
            // 
            // WSID
            // 
            this.WSID.HeaderText = "WSID";
            this.WSID.Name = "WSID";
            this.WSID.ReadOnly = true;
            this.WSID.Visible = false;
            this.WSID.Width = 120;
            // 
            // FormulaNo
            // 
            this.FormulaNo.HeaderText = "Formula No";
            this.FormulaNo.Name = "FormulaNo";
            this.FormulaNo.Width = 150;
            // 
            // MfgWo
            // 
            this.MfgWo.HeaderText = "MfgWo";
            this.MfgWo.Name = "MfgWo";
            this.MfgWo.Width = 150;
            // 
            // RefLocation
            // 
            this.RefLocation.HeaderText = "Reference Location";
            this.RefLocation.Name = "RefLocation";
            this.RefLocation.Width = 180;
            // 
            // ValidityDate
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.ValidityDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.ValidityDate.HeaderText = "ValidityDate";
            this.ValidityDate.Name = "ValidityDate";
            this.ValidityDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ValidityDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AnalysisReport
            // 
            this.AnalysisReport.HeaderText = "Analysis Report";
            this.AnalysisReport.Name = "AnalysisReport";
            this.AnalysisReport.Width = 120;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Width = 65;
            // 
            // FMID
            // 
            this.FMID.HeaderText = "FMID";
            this.FMID.Name = "FMID";
            this.FMID.Visible = false;
            // 
            // LocID
            // 
            this.LocID.HeaderText = "LocID";
            this.LocID.Name = "LocID";
            this.LocID.Visible = false;
            // 
            // gbRMButtons
            // 
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeExit);
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeReset);
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeSave);
            this.gbRMButtons.Location = new System.Drawing.Point(15, 456);
            this.gbRMButtons.Name = "gbRMButtons";
            this.gbRMButtons.Size = new System.Drawing.Size(792, 67);
            this.gbRMButtons.TabIndex = 3;
            this.gbRMButtons.TabStop = false;
            // 
            // BtnPMStatusChangeExit
            // 
            this.BtnPMStatusChangeExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMStatusChangeExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMStatusChangeExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMStatusChangeExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMStatusChangeExit.Location = new System.Drawing.Point(493, 19);
            this.BtnPMStatusChangeExit.Name = "BtnPMStatusChangeExit";
            this.BtnPMStatusChangeExit.Size = new System.Drawing.Size(109, 32);
            this.BtnPMStatusChangeExit.TabIndex = 2;
            this.BtnPMStatusChangeExit.Text = "&Exit";
            this.BtnPMStatusChangeExit.UseVisualStyleBackColor = false;
            this.BtnPMStatusChangeExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnPMStatusChangeReset
            // 
            this.BtnPMStatusChangeReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMStatusChangeReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMStatusChangeReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMStatusChangeReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMStatusChangeReset.Location = new System.Drawing.Point(191, 19);
            this.BtnPMStatusChangeReset.Name = "BtnPMStatusChangeReset";
            this.BtnPMStatusChangeReset.Size = new System.Drawing.Size(109, 32);
            this.BtnPMStatusChangeReset.TabIndex = 0;
            this.BtnPMStatusChangeReset.Text = "&Reset";
            this.BtnPMStatusChangeReset.UseVisualStyleBackColor = false;
            this.BtnPMStatusChangeReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnPMStatusChangeSave
            // 
            this.BtnPMStatusChangeSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMStatusChangeSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMStatusChangeSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMStatusChangeSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMStatusChangeSave.Location = new System.Drawing.Point(342, 19);
            this.BtnPMStatusChangeSave.Name = "BtnPMStatusChangeSave";
            this.BtnPMStatusChangeSave.Size = new System.Drawing.Size(109, 32);
            this.BtnPMStatusChangeSave.TabIndex = 1;
            this.BtnPMStatusChangeSave.Text = "&Save";
            this.BtnPMStatusChangeSave.UseVisualStyleBackColor = false;
            this.BtnPMStatusChangeSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // dgRMStatusChangeFields
            // 
            this.dgRMStatusChangeFields.Controls.Add(this.label2);
            this.dgRMStatusChangeFields.Controls.Add(this.txtDesc);
            this.dgRMStatusChangeFields.Controls.Add(this.cmbFormulaNo);
            this.dgRMStatusChangeFields.Controls.Add(this.lblFormula);
            this.dgRMStatusChangeFields.Location = new System.Drawing.Point(15, 16);
            this.dgRMStatusChangeFields.Name = "dgRMStatusChangeFields";
            this.dgRMStatusChangeFields.Size = new System.Drawing.Size(791, 91);
            this.dgRMStatusChangeFields.TabIndex = 0;
            this.dgRMStatusChangeFields.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label2.Location = new System.Drawing.Point(32, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Enabled = false;
            this.txtDesc.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(128, 53);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(367, 23);
            this.txtDesc.TabIndex = 2;
            // 
            // cmbFormulaNo
            // 
            this.cmbFormulaNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFormulaNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFormulaNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormulaNo.FormattingEnabled = true;
            this.cmbFormulaNo.Location = new System.Drawing.Point(129, 21);
            this.cmbFormulaNo.Name = "cmbFormulaNo";
            this.cmbFormulaNo.Size = new System.Drawing.Size(132, 24);
            this.cmbFormulaNo.TabIndex = 1;
            this.cmbFormulaNo.SelectionChangeCommitted += new System.EventHandler(this.cmbFormulaNo_SelectionChangeCommitted);
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblFormula.Location = new System.Drawing.Point(32, 26);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(81, 16);
            this.lblFormula.TabIndex = 0;
            this.lblFormula.Text = "Formula No";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "PMDefectID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Defect Comment";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Defect Quantity";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "QualityDecision";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // FrmRSManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(824, 574);
            this.Controls.Add(this.panelOuter);
            this.Name = "FrmRSManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRSManagement_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFields.ResumeLayout(false);
            this.gbFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWSDetails)).EndInit();
            this.gbRMButtons.ResumeLayout(false);
            this.dgRMStatusChangeFields.ResumeLayout(false);
            this.dgRMStatusChangeFields.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.GroupBox dgRMStatusChangeFields;
        private System.Windows.Forms.ComboBox cmbFormulaNo;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.GroupBox gbRMButtons;
        private System.Windows.Forms.Button BtnPMStatusChangeExit;
        private System.Windows.Forms.Button BtnPMStatusChangeReset;
        private System.Windows.Forms.Button BtnPMStatusChangeSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.GroupBox gbFields;
        private System.Windows.Forms.DataGridView dgWSDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFIFormulaNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtpReceivingDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMfgWo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPFLot;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpValidityDate;
        private System.Windows.Forms.ComboBox cmbRefLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker DtpWSValidityDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbWSmfgwo;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormulaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MfgWo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefLocation;
        private QTMS.Tools.CalendarColumn ValidityDate;
        private System.Windows.Forms.DataGridViewLinkColumn AnalysisReport;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn FMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocID;
    }
}