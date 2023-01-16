namespace QTMS.Transactions
{
    partial class FrmRefSampleMgmtRMTransaction
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
            FrmRefSampleMgmtRMTransaction_Obj = null;
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.cmbRetainerLocation = new System.Windows.Forms.ComboBox();
            this.cmbPlantLotNo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.DtpWSValidityDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dgDetails = new System.Windows.Forms.DataGridView();
            this.RMWSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetainerLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidityDate = new QTMS.Tools.CalendarColumn();
            this.AnalysisReport = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.RMSamplingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetainerLocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbRMButtons = new System.Windows.Forms.GroupBox();
            this.BtnPMStatusChangeExit = new System.Windows.Forms.Button();
            this.BtnPMStatusChangeReset = new System.Windows.Forms.Button();
            this.BtnPMStatusChangeSave = new System.Windows.Forms.Button();
            this.dgRMStatusChangeFields = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cmbRMCode = new System.Windows.Forms.ComboBox();
            this.lblFormula = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.gbFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).BeginInit();
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
            this.panelOuter.Size = new System.Drawing.Size(824, 465);
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
            this.toolStripLabel1.Size = new System.Drawing.Size(223, 27);
            this.toolStripLabel1.Text = "Reference Sample Management (RM)";
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
            this.panelFill.Controls.Add(this.gbFields);
            this.panelFill.Controls.Add(this.gbRMButtons);
            this.panelFill.Controls.Add(this.dgRMStatusChangeFields);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(822, 539);
            this.panelFill.TabIndex = 0;
            // 
            // gbFields
            // 
            this.gbFields.Controls.Add(this.cmbRetainerLocation);
            this.gbFields.Controls.Add(this.cmbPlantLotNo);
            this.gbFields.Controls.Add(this.label9);
            this.gbFields.Controls.Add(this.btnAdd);
            this.gbFields.Controls.Add(this.label11);
            this.gbFields.Controls.Add(this.DtpWSValidityDate);
            this.gbFields.Controls.Add(this.label10);
            this.gbFields.Controls.Add(this.dgDetails);
            this.gbFields.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFields.Location = new System.Drawing.Point(15, 113);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(791, 225);
            this.gbFields.TabIndex = 2;
            this.gbFields.TabStop = false;
            this.gbFields.Text = "Working standard details";
            // 
            // cmbRetainerLocation
            // 
            this.cmbRetainerLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRetainerLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRetainerLocation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRetainerLocation.FormattingEnabled = true;
            this.cmbRetainerLocation.Location = new System.Drawing.Point(135, 27);
            this.cmbRetainerLocation.Name = "cmbRetainerLocation";
            this.cmbRetainerLocation.Size = new System.Drawing.Size(93, 24);
            this.cmbRetainerLocation.TabIndex = 7;
            this.cmbRetainerLocation.Visible = false;
            // 
            // cmbPlantLotNo
            // 
            this.cmbPlantLotNo.FormattingEnabled = true;
            this.cmbPlantLotNo.Location = new System.Drawing.Point(331, 29);
            this.cmbPlantLotNo.Name = "cmbPlantLotNo";
            this.cmbPlantLotNo.Size = new System.Drawing.Size(120, 21);
            this.cmbPlantLotNo.TabIndex = 1;
            this.cmbPlantLotNo.SelectionChangeCommitted += new System.EventHandler(this.cmbPlantLotNo_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label9.Location = new System.Drawing.Point(6, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Retainer Location";
            this.label9.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.Location = new System.Drawing.Point(694, 25);
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
            this.label11.Location = new System.Drawing.Point(457, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "Validity Date";
            // 
            // DtpWSValidityDate
            // 
            this.DtpWSValidityDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpWSValidityDate.Enabled = false;
            this.DtpWSValidityDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpWSValidityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpWSValidityDate.Location = new System.Drawing.Point(558, 26);
            this.DtpWSValidityDate.Name = "DtpWSValidityDate";
            this.DtpWSValidityDate.Size = new System.Drawing.Size(120, 23);
            this.DtpWSValidityDate.TabIndex = 2;
            this.DtpWSValidityDate.Value = new System.DateTime(2010, 4, 17, 0, 0, 0, 0);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label10.Location = new System.Drawing.Point(238, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Plant Lot No";
            // 
            // dgDetails
            // 
            this.dgDetails.AllowUserToAddRows = false;
            this.dgDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDetails.ColumnHeadersHeight = 25;
            this.dgDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RMWSID,
            this.RMCode,
            this.SupplierName,
            this.PlantLotNo,
            this.RetainerLocation,
            this.ValidityDate,
            this.AnalysisReport,
            this.Delete,
            this.RMSamplingID,
            this.RetainerLocID,
            this.SupplierID});
            this.dgDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgDetails.Location = new System.Drawing.Point(3, 56);
            this.dgDetails.MultiSelect = false;
            this.dgDetails.Name = "dgDetails";
            this.dgDetails.RowHeadersWidth = 20;
            this.dgDetails.Size = new System.Drawing.Size(785, 166);
            this.dgDetails.TabIndex = 4;
            this.dgDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgWSDetails_CellClick);
            // 
            // RMWSID
            // 
            this.RMWSID.HeaderText = "RMWSID";
            this.RMWSID.Name = "RMWSID";
            this.RMWSID.ReadOnly = true;
            this.RMWSID.Visible = false;
            this.RMWSID.Width = 120;
            // 
            // RMCode
            // 
            this.RMCode.HeaderText = "RM Code";
            this.RMCode.Name = "RMCode";
            // 
            // SupplierName
            // 
            this.SupplierName.HeaderText = "Supplier Name";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.Width = 250;
            // 
            // PlantLotNo
            // 
            this.PlantLotNo.HeaderText = "Plant Lot No";
            this.PlantLotNo.Name = "PlantLotNo";
            this.PlantLotNo.Width = 90;
            // 
            // RetainerLocation
            // 
            this.RetainerLocation.HeaderText = "Retainer Location";
            this.RetainerLocation.Name = "RetainerLocation";
            this.RetainerLocation.Visible = false;
            this.RetainerLocation.Width = 150;
            // 
            // ValidityDate
            // 
            dataGridViewCellStyle2.Format = "d";
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
            this.AnalysisReport.Width = 110;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Width = 65;
            // 
            // RMSamplingID
            // 
            this.RMSamplingID.HeaderText = "RMSamplingID";
            this.RMSamplingID.Name = "RMSamplingID";
            this.RMSamplingID.Visible = false;
            // 
            // RetainerLocID
            // 
            this.RetainerLocID.HeaderText = "RetainerLocID";
            this.RetainerLocID.Name = "RetainerLocID";
            this.RetainerLocID.Visible = false;
            // 
            // SupplierID
            // 
            this.SupplierID.HeaderText = "SupplierID";
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.Visible = false;
            // 
            // gbRMButtons
            // 
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeExit);
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeReset);
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeSave);
            this.gbRMButtons.Location = new System.Drawing.Point(14, 353);
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
            this.dgRMStatusChangeFields.Controls.Add(this.cmbRMCode);
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
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "INCI Name";
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Enabled = false;
            this.txtDesc.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(128, 53);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(646, 23);
            this.txtDesc.TabIndex = 2;
            // 
            // cmbRMCode
            // 
            this.cmbRMCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRMCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRMCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRMCode.FormattingEnabled = true;
            this.cmbRMCode.Location = new System.Drawing.Point(129, 21);
            this.cmbRMCode.Name = "cmbRMCode";
            this.cmbRMCode.Size = new System.Drawing.Size(198, 24);
            this.cmbRMCode.TabIndex = 1;
            this.cmbRMCode.SelectionChangeCommitted += new System.EventHandler(this.cmbRMCode_SelectionChangeCommitted);
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblFormula.Location = new System.Drawing.Point(32, 26);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(65, 16);
            this.lblFormula.TabIndex = 0;
            this.lblFormula.Text = "RM Code";
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
            // FrmRefSampleMgmtRMTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(824, 465);
            this.Controls.Add(this.panelOuter);
            this.Name = "FrmRefSampleMgmtRMTransaction";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reference Sample Management (RM)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRefSampleMgmtRMTransaction_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.gbFields.ResumeLayout(false);
            this.gbFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetails)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbRMCode;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.GroupBox gbRMButtons;
        private System.Windows.Forms.Button BtnPMStatusChangeExit;
        private System.Windows.Forms.Button BtnPMStatusChangeReset;
        private System.Windows.Forms.Button BtnPMStatusChangeSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.GroupBox gbFields;
        private System.Windows.Forms.DataGridView dgDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ComboBox cmbRetainerLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker DtpWSValidityDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbPlantLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RMWSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RMCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetainerLocation;
        private QTMS.Tools.CalendarColumn ValidityDate;
        private System.Windows.Forms.DataGridViewLinkColumn AnalysisReport;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn RMSamplingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetainerLocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierID;
    }
}