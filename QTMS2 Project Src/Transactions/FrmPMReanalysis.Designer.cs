namespace QTMS.Transactions
{
    partial class FrmPMReanalysis
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
            frmPMReanalysis_Obj = null;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.gbPMTreatmentdone = new System.Windows.Forms.GroupBox();
            this.dgAllTests = new System.Windows.Forms.DataGridView();
            this.PMMethodNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InspectionMethod = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LotSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleSizeStandard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleSizeReading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQLStandard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQLReading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQLzStandard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQLzReading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQLcStandard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQLcReading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQLMStandard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQLMReading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQLM1Standard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AQLM1Reading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RdoNo = new System.Windows.Forms.RadioButton();
            this.RdoYes = new System.Windows.Forms.RadioButton();
            this.gbRMButtons = new System.Windows.Forms.GroupBox();
            this.BtnPMStatusChangeExit = new System.Windows.Forms.Button();
            this.BtnPMStatusChangeReset = new System.Windows.Forms.Button();
            this.BtnPMStatusChangeSave = new System.Windows.Forms.Button();
            this.gbPMTransactionStatus = new System.Windows.Forms.GroupBox();
            this.chkRejectComments = new System.Windows.Forms.CheckedListBox();
            this.RdoSendBackToSupplier = new System.Windows.Forms.RadioButton();
            this.RdoTreatment = new System.Windows.Forms.RadioButton();
            this.RdoAWD = new System.Windows.Forms.RadioButton();
            this.RdoReject = new System.Windows.Forms.RadioButton();
            this.RdoAccept = new System.Windows.Forms.RadioButton();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.dgDefect = new System.Windows.Forms.DataGridView();
            this.PMDefectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefectComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefectQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionTaken = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.QualityDecision = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DefectStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoOfDefect = new System.Windows.Forms.TextBox();
            this.cmbDefectObserved = new System.Windows.Forms.ComboBox();
            this.lblPMTransactionDetectNoteSend = new System.Windows.Forms.Label();
            this.dgRMStatusChangeFields = new System.Windows.Forms.GroupBox();
            this.txtCOC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPlantLotNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpInspDate = new System.Windows.Forms.DateTimePicker();
            this.lblPMTransactionAcceptedDate = new System.Windows.Forms.Label();
            this.DtpAcceptedDate = new System.Windows.Forms.DateTimePicker();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblPMStatusChangeQtyReceived = new System.Windows.Forms.Label();
            this.cmbPMCode = new System.Windows.Forms.ComboBox();
            this.lblPMCode = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.gbPMTreatmentdone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllTests)).BeginInit();
            this.gbRMButtons.SuspendLayout();
            this.gbPMTransactionStatus.SuspendLayout();
            this.gbFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDefect)).BeginInit();
            this.dgRMStatusChangeFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelFill);
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(1026, 751);
            this.panelOuter.TabIndex = 87;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1024, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(1024, 30);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(89, 27);
            this.toolStripLabel1.Text = "PM Reanalysis";
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
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 67);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1024, 682);
            this.panelBottom.TabIndex = 98;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.gbPMTreatmentdone);
            this.panelFill.Controls.Add(this.gbRMButtons);
            this.panelFill.Controls.Add(this.gbPMTransactionStatus);
            this.panelFill.Controls.Add(this.gbFields);
            this.panelFill.Controls.Add(this.dgRMStatusChangeFields);
            this.panelFill.Location = new System.Drawing.Point(1, 33);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(1024, 682);
            this.panelFill.TabIndex = 0;
            // 
            // gbPMTreatmentdone
            // 
            this.gbPMTreatmentdone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbPMTreatmentdone.Controls.Add(this.dgAllTests);
            this.gbPMTreatmentdone.Controls.Add(this.RdoNo);
            this.gbPMTreatmentdone.Controls.Add(this.RdoYes);
            this.gbPMTreatmentdone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPMTreatmentdone.Location = new System.Drawing.Point(20, 315);
            this.gbPMTreatmentdone.Name = "gbPMTreatmentdone";
            this.gbPMTreatmentdone.Size = new System.Drawing.Size(984, 239);
            this.gbPMTreatmentdone.TabIndex = 63;
            this.gbPMTreatmentdone.TabStop = false;
            this.gbPMTreatmentdone.Text = "Tests";
            // 
            // dgAllTests
            // 
            this.dgAllTests.AllowUserToAddRows = false;
            this.dgAllTests.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgAllTests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAllTests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAllTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAllTests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PMMethodNo,
            this.TestMethod,
            this.TestDesc,
            this.Frequency,
            this.InspectionMethod,
            this.LotSize,
            this.SampleSizeStandard,
            this.SampleSizeReading,
            this.AQLStandard,
            this.AQLReading,
            this.AQLzStandard,
            this.AQLzReading,
            this.AQLcStandard,
            this.AQLcReading,
            this.AQLMStandard,
            this.AQLMReading,
            this.AQLM1Standard,
            this.AQLM1Reading});
            this.dgAllTests.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgAllTests.Location = new System.Drawing.Point(3, 42);
            this.dgAllTests.MultiSelect = false;
            this.dgAllTests.Name = "dgAllTests";
            this.dgAllTests.RowHeadersVisible = false;
            this.dgAllTests.Size = new System.Drawing.Size(978, 194);
            this.dgAllTests.TabIndex = 100;
            this.dgAllTests.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgAllTests_CellValidating);
            this.dgAllTests.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgAllTests_EditingControlShowing);
            this.dgAllTests.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgAllTests_KeyPress);
            // 
            // PMMethodNo
            // 
            this.PMMethodNo.HeaderText = "PMMethodNo";
            this.PMMethodNo.Name = "PMMethodNo";
            this.PMMethodNo.ReadOnly = true;
            this.PMMethodNo.Visible = false;
            // 
            // TestMethod
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestMethod.DefaultCellStyle = dataGridViewCellStyle2;
            this.TestMethod.HeaderText = "Test Method";
            this.TestMethod.MaxInputLength = 100;
            this.TestMethod.Name = "TestMethod";
            this.TestMethod.ReadOnly = true;
            this.TestMethod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TestMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TestMethod.Width = 60;
            // 
            // TestDesc
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestDesc.DefaultCellStyle = dataGridViewCellStyle3;
            this.TestDesc.HeaderText = "Test Desc";
            this.TestDesc.Name = "TestDesc";
            this.TestDesc.ReadOnly = true;
            this.TestDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TestDesc.Width = 60;
            // 
            // Frequency
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Frequency.DefaultCellStyle = dataGridViewCellStyle4;
            this.Frequency.HeaderText = "Frequency";
            this.Frequency.MaxInputLength = 6;
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            this.Frequency.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Frequency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Frequency.Width = 70;
            // 
            // InspectionMethod
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.InspectionMethod.DefaultCellStyle = dataGridViewCellStyle5;
            this.InspectionMethod.HeaderText = "Insp Method";
            this.InspectionMethod.Name = "InspectionMethod";
            this.InspectionMethod.Width = 50;
            // 
            // LotSize
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LotSize.DefaultCellStyle = dataGridViewCellStyle6;
            this.LotSize.HeaderText = "Lot Size";
            this.LotSize.MaxInputLength = 6;
            this.LotSize.Name = "LotSize";
            this.LotSize.ReadOnly = true;
            this.LotSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LotSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LotSize.Width = 80;
            // 
            // SampleSizeStandard
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SampleSizeStandard.DefaultCellStyle = dataGridViewCellStyle7;
            this.SampleSizeStandard.HeaderText = "Sample Size (Std)";
            this.SampleSizeStandard.Name = "SampleSizeStandard";
            this.SampleSizeStandard.ReadOnly = true;
            this.SampleSizeStandard.Width = 60;
            // 
            // SampleSizeReading
            // 
            this.SampleSizeReading.HeaderText = "Samples Size (Read)";
            this.SampleSizeReading.Name = "SampleSizeReading";
            this.SampleSizeReading.Width = 60;
            // 
            // AQLStandard
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AQLStandard.DefaultCellStyle = dataGridViewCellStyle8;
            this.AQLStandard.HeaderText = "AQL (std)";
            this.AQLStandard.MaxInputLength = 6;
            this.AQLStandard.Name = "AQLStandard";
            this.AQLStandard.ReadOnly = true;
            this.AQLStandard.Width = 50;
            // 
            // AQLReading
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.AQLReading.DefaultCellStyle = dataGridViewCellStyle9;
            this.AQLReading.HeaderText = "AQL (Read)";
            this.AQLReading.MaxInputLength = 6;
            this.AQLReading.Name = "AQLReading";
            this.AQLReading.Width = 50;
            // 
            // AQLzStandard
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AQLzStandard.DefaultCellStyle = dataGridViewCellStyle10;
            this.AQLzStandard.HeaderText = "AQL(z) (Std)";
            this.AQLzStandard.Name = "AQLzStandard";
            this.AQLzStandard.ReadOnly = true;
            this.AQLzStandard.Width = 50;
            // 
            // AQLzReading
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            this.AQLzReading.DefaultCellStyle = dataGridViewCellStyle11;
            this.AQLzReading.HeaderText = "AQL(z) (Read)";
            this.AQLzReading.Name = "AQLzReading";
            this.AQLzReading.Width = 50;
            // 
            // AQLcStandard
            // 
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AQLcStandard.DefaultCellStyle = dataGridViewCellStyle12;
            this.AQLcStandard.HeaderText = "AQL(c) (Std)";
            this.AQLcStandard.Name = "AQLcStandard";
            this.AQLcStandard.ReadOnly = true;
            this.AQLcStandard.Width = 50;
            // 
            // AQLcReading
            // 
            this.AQLcReading.HeaderText = "AQL(c) (Read)";
            this.AQLcReading.Name = "AQLcReading";
            this.AQLcReading.Width = 50;
            // 
            // AQLMStandard
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AQLMStandard.DefaultCellStyle = dataGridViewCellStyle13;
            this.AQLMStandard.HeaderText = "AQL(M) (Std)";
            this.AQLMStandard.Name = "AQLMStandard";
            this.AQLMStandard.ReadOnly = true;
            this.AQLMStandard.Width = 50;
            // 
            // AQLMReading
            // 
            this.AQLMReading.HeaderText = "AQL(M) (Read)";
            this.AQLMReading.Name = "AQLMReading";
            this.AQLMReading.Width = 50;
            // 
            // AQLM1Standard
            // 
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AQLM1Standard.DefaultCellStyle = dataGridViewCellStyle14;
            this.AQLM1Standard.HeaderText = "AQL(M1) (Std)";
            this.AQLM1Standard.Name = "AQLM1Standard";
            this.AQLM1Standard.ReadOnly = true;
            this.AQLM1Standard.Width = 60;
            // 
            // AQLM1Reading
            // 
            this.AQLM1Reading.HeaderText = "AQL(M1) (Read)";
            this.AQLM1Reading.Name = "AQLM1Reading";
            this.AQLM1Reading.Width = 60;
            // 
            // RdoNo
            // 
            this.RdoNo.AutoSize = true;
            this.RdoNo.Checked = true;
            this.RdoNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoNo.Location = new System.Drawing.Point(159, 14);
            this.RdoNo.Name = "RdoNo";
            this.RdoNo.Size = new System.Drawing.Size(48, 22);
            this.RdoNo.TabIndex = 99;
            this.RdoNo.TabStop = true;
            this.RdoNo.Text = "No";
            this.RdoNo.UseVisualStyleBackColor = true;
            this.RdoNo.CheckedChanged += new System.EventHandler(this.RdoNo_CheckedChanged);
            // 
            // RdoYes
            // 
            this.RdoYes.AutoSize = true;
            this.RdoYes.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoYes.Location = new System.Drawing.Point(83, 14);
            this.RdoYes.Name = "RdoYes";
            this.RdoYes.Size = new System.Drawing.Size(56, 22);
            this.RdoYes.TabIndex = 86;
            this.RdoYes.Text = "Yes";
            this.RdoYes.UseVisualStyleBackColor = true;
            this.RdoYes.CheckedChanged += new System.EventHandler(this.RdoYes_CheckedChanged);
            // 
            // gbRMButtons
            // 
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeExit);
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeReset);
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeSave);
            this.gbRMButtons.Location = new System.Drawing.Point(16, 627);
            this.gbRMButtons.Name = "gbRMButtons";
            this.gbRMButtons.Size = new System.Drawing.Size(984, 45);
            this.gbRMButtons.TabIndex = 2;
            this.gbRMButtons.TabStop = false;
            // 
            // BtnPMStatusChangeExit
            // 
            this.BtnPMStatusChangeExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMStatusChangeExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMStatusChangeExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMStatusChangeExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMStatusChangeExit.Location = new System.Drawing.Point(589, 12);
            this.BtnPMStatusChangeExit.Name = "BtnPMStatusChangeExit";
            this.BtnPMStatusChangeExit.Size = new System.Drawing.Size(109, 26);
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
            this.BtnPMStatusChangeReset.Location = new System.Drawing.Point(287, 12);
            this.BtnPMStatusChangeReset.Name = "BtnPMStatusChangeReset";
            this.BtnPMStatusChangeReset.Size = new System.Drawing.Size(109, 26);
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
            this.BtnPMStatusChangeSave.Location = new System.Drawing.Point(438, 12);
            this.BtnPMStatusChangeSave.Name = "BtnPMStatusChangeSave";
            this.BtnPMStatusChangeSave.Size = new System.Drawing.Size(109, 26);
            this.BtnPMStatusChangeSave.TabIndex = 1;
            this.BtnPMStatusChangeSave.Text = "&Save";
            this.BtnPMStatusChangeSave.UseVisualStyleBackColor = false;
            this.BtnPMStatusChangeSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // gbPMTransactionStatus
            // 
            this.gbPMTransactionStatus.Controls.Add(this.chkRejectComments);
            this.gbPMTransactionStatus.Controls.Add(this.RdoSendBackToSupplier);
            this.gbPMTransactionStatus.Controls.Add(this.RdoTreatment);
            this.gbPMTransactionStatus.Controls.Add(this.RdoAWD);
            this.gbPMTransactionStatus.Controls.Add(this.RdoReject);
            this.gbPMTransactionStatus.Controls.Add(this.RdoAccept);
            this.gbPMTransactionStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPMTransactionStatus.Location = new System.Drawing.Point(16, 557);
            this.gbPMTransactionStatus.Name = "gbPMTransactionStatus";
            this.gbPMTransactionStatus.Size = new System.Drawing.Size(984, 67);
            this.gbPMTransactionStatus.TabIndex = 6;
            this.gbPMTransactionStatus.TabStop = false;
            this.gbPMTransactionStatus.Text = "Status";
            // 
            // chkRejectComments
            // 
            this.chkRejectComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkRejectComments.FormattingEnabled = true;
            this.chkRejectComments.Items.AddRange(new object[] {
            "Blocked on Receipt",
            "Blocked on Floor",
            "COC"});
            this.chkRejectComments.Location = new System.Drawing.Point(426, 12);
            this.chkRejectComments.Name = "chkRejectComments";
            this.chkRejectComments.Size = new System.Drawing.Size(148, 50);
            this.chkRejectComments.TabIndex = 2;
            this.chkRejectComments.Visible = false;
            this.chkRejectComments.Click += new System.EventHandler(this.chkRejectComments_Click);
            // 
            // RdoSendBackToSupplier
            // 
            this.RdoSendBackToSupplier.AutoSize = true;
            this.RdoSendBackToSupplier.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoSendBackToSupplier.Location = new System.Drawing.Point(166, 35);
            this.RdoSendBackToSupplier.Name = "RdoSendBackToSupplier";
            this.RdoSendBackToSupplier.Size = new System.Drawing.Size(151, 17);
            this.RdoSendBackToSupplier.TabIndex = 5;
            this.RdoSendBackToSupplier.Text = "Send BackTo Supplier";
            this.RdoSendBackToSupplier.UseVisualStyleBackColor = true;
            this.RdoSendBackToSupplier.CheckedChanged += new System.EventHandler(this.RdoSendBackToSupplier_CheckedChanged);
            // 
            // RdoTreatment
            // 
            this.RdoTreatment.AutoSize = true;
            this.RdoTreatment.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoTreatment.Location = new System.Drawing.Point(734, 12);
            this.RdoTreatment.Name = "RdoTreatment";
            this.RdoTreatment.Size = new System.Drawing.Size(84, 17);
            this.RdoTreatment.TabIndex = 4;
            this.RdoTreatment.Text = "Treatment";
            this.RdoTreatment.UseVisualStyleBackColor = true;
            this.RdoTreatment.Visible = false;
            // 
            // RdoAWD
            // 
            this.RdoAWD.AutoSize = true;
            this.RdoAWD.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoAWD.Location = new System.Drawing.Point(616, 12);
            this.RdoAWD.Name = "RdoAWD";
            this.RdoAWD.Size = new System.Drawing.Size(53, 17);
            this.RdoAWD.TabIndex = 3;
            this.RdoAWD.Text = "AWD";
            this.RdoAWD.UseVisualStyleBackColor = true;
            this.RdoAWD.Visible = false;
            // 
            // RdoReject
            // 
            this.RdoReject.AutoSize = true;
            this.RdoReject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoReject.Location = new System.Drawing.Point(354, 12);
            this.RdoReject.Name = "RdoReject";
            this.RdoReject.Size = new System.Drawing.Size(61, 17);
            this.RdoReject.TabIndex = 1;
            this.RdoReject.Text = "Reject";
            this.RdoReject.UseVisualStyleBackColor = true;
            this.RdoReject.CheckedChanged += new System.EventHandler(this.RdoReject_CheckedChanged);
            // 
            // RdoAccept
            // 
            this.RdoAccept.AutoSize = true;
            this.RdoAccept.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoAccept.Location = new System.Drawing.Point(167, 12);
            this.RdoAccept.Name = "RdoAccept";
            this.RdoAccept.Size = new System.Drawing.Size(63, 17);
            this.RdoAccept.TabIndex = 0;
            this.RdoAccept.Text = "Accept";
            this.RdoAccept.UseVisualStyleBackColor = true;
            this.RdoAccept.CheckedChanged += new System.EventHandler(this.RdoAccept_CheckedChanged);
            // 
            // gbFields
            // 
            this.gbFields.Controls.Add(this.dgDefect);
            this.gbFields.Controls.Add(this.label5);
            this.gbFields.Controls.Add(this.txtNoOfDefect);
            this.gbFields.Controls.Add(this.cmbDefectObserved);
            this.gbFields.Controls.Add(this.lblPMTransactionDetectNoteSend);
            this.gbFields.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFields.Location = new System.Drawing.Point(16, 151);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(984, 161);
            this.gbFields.TabIndex = 1;
            this.gbFields.TabStop = false;
            // 
            // dgDefect
            // 
            this.dgDefect.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgDefect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDefect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgDefect.ColumnHeadersHeight = 25;
            this.dgDefect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PMDefectID,
            this.DefectComment,
            this.DefectQuantity,
            this.ActionTaken,
            this.QualityDecision,
            this.DefectStatus});
            this.dgDefect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgDefect.Location = new System.Drawing.Point(3, 44);
            this.dgDefect.MultiSelect = false;
            this.dgDefect.Name = "dgDefect";
            this.dgDefect.RowHeadersWidth = 20;
            this.dgDefect.Size = new System.Drawing.Size(978, 114);
            this.dgDefect.TabIndex = 4;
            // 
            // PMDefectID
            // 
            this.PMDefectID.HeaderText = "PMDefectID";
            this.PMDefectID.Name = "PMDefectID";
            this.PMDefectID.ReadOnly = true;
            this.PMDefectID.Visible = false;
            // 
            // DefectComment
            // 
            this.DefectComment.HeaderText = "Defect Comment";
            this.DefectComment.Name = "DefectComment";
            this.DefectComment.Width = 300;
            // 
            // DefectQuantity
            // 
            this.DefectQuantity.HeaderText = "Defect Quantity";
            this.DefectQuantity.Name = "DefectQuantity";
            this.DefectQuantity.Width = 120;
            // 
            // ActionTaken
            // 
            this.ActionTaken.HeaderText = "ActionTaken";
            this.ActionTaken.Items.AddRange(new object[] {
            "Line Stopped : Requested QC to check",
            "Line Stopped : Material returned to store",
            "On Line Sorting",
            "On Line Adjustment",
            "Other"});
            this.ActionTaken.Name = "ActionTaken";
            this.ActionTaken.Width = 300;
            // 
            // QualityDecision
            // 
            this.QualityDecision.HeaderText = "QualityDecision";
            this.QualityDecision.Items.AddRange(new object[] {
            "ZD",
            "Critical",
            "Major",
            "Minor",
            "Other"});
            this.QualityDecision.Name = "QualityDecision";
            this.QualityDecision.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QualityDecision.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DefectStatus
            // 
            this.DefectStatus.HeaderText = "Status";
            this.DefectStatus.Items.AddRange(new object[] {
            "Open",
            "Close"});
            this.DefectStatus.Name = "DefectStatus";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(234, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "No of Defect";
            // 
            // txtNoOfDefect
            // 
            this.txtNoOfDefect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfDefect.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfDefect.Location = new System.Drawing.Point(329, 15);
            this.txtNoOfDefect.Name = "txtNoOfDefect";
            this.txtNoOfDefect.Size = new System.Drawing.Size(81, 23);
            this.txtNoOfDefect.TabIndex = 3;
            // 
            // cmbDefectObserved
            // 
            this.cmbDefectObserved.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbDefectObserved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefectObserved.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDefectObserved.FormattingEnabled = true;
            this.cmbDefectObserved.Items.AddRange(new object[] {
            "--Select--",
            "No",
            "Yes"});
            this.cmbDefectObserved.Location = new System.Drawing.Point(129, 14);
            this.cmbDefectObserved.Name = "cmbDefectObserved";
            this.cmbDefectObserved.Size = new System.Drawing.Size(101, 24);
            this.cmbDefectObserved.TabIndex = 1;
            this.cmbDefectObserved.SelectedIndexChanged += new System.EventHandler(this.cmbDefectObserved_SelectedIndexChanged);
            // 
            // lblPMTransactionDetectNoteSend
            // 
            this.lblPMTransactionDetectNoteSend.AutoSize = true;
            this.lblPMTransactionDetectNoteSend.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMTransactionDetectNoteSend.Location = new System.Drawing.Point(6, 18);
            this.lblPMTransactionDetectNoteSend.Name = "lblPMTransactionDetectNoteSend";
            this.lblPMTransactionDetectNoteSend.Size = new System.Drawing.Size(120, 16);
            this.lblPMTransactionDetectNoteSend.TabIndex = 0;
            this.lblPMTransactionDetectNoteSend.Text = "Detect Observed";
            // 
            // dgRMStatusChangeFields
            // 
            this.dgRMStatusChangeFields.Controls.Add(this.txtCOC);
            this.dgRMStatusChangeFields.Controls.Add(this.label4);
            this.dgRMStatusChangeFields.Controls.Add(this.cmbPlantLotNo);
            this.dgRMStatusChangeFields.Controls.Add(this.label6);
            this.dgRMStatusChangeFields.Controls.Add(this.txtSupplier);
            this.dgRMStatusChangeFields.Controls.Add(this.label2);
            this.dgRMStatusChangeFields.Controls.Add(this.label1);
            this.dgRMStatusChangeFields.Controls.Add(this.txtDesc);
            this.dgRMStatusChangeFields.Controls.Add(this.label3);
            this.dgRMStatusChangeFields.Controls.Add(this.DtpInspDate);
            this.dgRMStatusChangeFields.Controls.Add(this.lblPMTransactionAcceptedDate);
            this.dgRMStatusChangeFields.Controls.Add(this.DtpAcceptedDate);
            this.dgRMStatusChangeFields.Controls.Add(this.txtQuantity);
            this.dgRMStatusChangeFields.Controls.Add(this.lblPMStatusChangeQtyReceived);
            this.dgRMStatusChangeFields.Controls.Add(this.cmbPMCode);
            this.dgRMStatusChangeFields.Controls.Add(this.lblPMCode);
            this.dgRMStatusChangeFields.Location = new System.Drawing.Point(16, 11);
            this.dgRMStatusChangeFields.Name = "dgRMStatusChangeFields";
            this.dgRMStatusChangeFields.Size = new System.Drawing.Size(984, 137);
            this.dgRMStatusChangeFields.TabIndex = 0;
            this.dgRMStatusChangeFields.TabStop = false;
            // 
            // txtCOC
            // 
            this.txtCOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCOC.Enabled = false;
            this.txtCOC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCOC.Location = new System.Drawing.Point(698, 76);
            this.txtCOC.Name = "txtCOC";
            this.txtCOC.Size = new System.Drawing.Size(120, 23);
            this.txtCOC.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label4.Location = new System.Drawing.Point(657, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "COC";
            // 
            // cmbPlantLotNo
            // 
            this.cmbPlantLotNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlantLotNo.FormattingEnabled = true;
            this.cmbPlantLotNo.Location = new System.Drawing.Point(363, 14);
            this.cmbPlantLotNo.Name = "cmbPlantLotNo";
            this.cmbPlantLotNo.Size = new System.Drawing.Size(132, 24);
            this.cmbPlantLotNo.TabIndex = 3;
            this.cmbPlantLotNo.SelectionChangeCommitted += new System.EventHandler(this.cmbPlantLotNo_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label6.Location = new System.Drawing.Point(42, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Supplier";
            // 
            // txtSupplier
            // 
            this.txtSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplier.Enabled = false;
            this.txtSupplier.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplier.Location = new System.Drawing.Point(128, 76);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(367, 23);
            this.txtSupplier.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label2.Location = new System.Drawing.Point(42, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(273, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Plant Lot No";
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Enabled = false;
            this.txtDesc.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(128, 46);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(367, 23);
            this.txtDesc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(620, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Insp Date";
            // 
            // DtpInspDate
            // 
            this.DtpInspDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpInspDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpInspDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpInspDate.Location = new System.Drawing.Point(698, 16);
            this.DtpInspDate.Name = "DtpInspDate";
            this.DtpInspDate.Size = new System.Drawing.Size(120, 23);
            this.DtpInspDate.TabIndex = 9;
            this.DtpInspDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // lblPMTransactionAcceptedDate
            // 
            this.lblPMTransactionAcceptedDate.AutoSize = true;
            this.lblPMTransactionAcceptedDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMTransactionAcceptedDate.Location = new System.Drawing.Point(586, 48);
            this.lblPMTransactionAcceptedDate.Name = "lblPMTransactionAcceptedDate";
            this.lblPMTransactionAcceptedDate.Size = new System.Drawing.Size(107, 16);
            this.lblPMTransactionAcceptedDate.TabIndex = 10;
            this.lblPMTransactionAcceptedDate.Text = "Accepted Date";
            // 
            // DtpAcceptedDate
            // 
            this.DtpAcceptedDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpAcceptedDate.Enabled = false;
            this.DtpAcceptedDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpAcceptedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpAcceptedDate.Location = new System.Drawing.Point(698, 46);
            this.DtpAcceptedDate.Name = "DtpAcceptedDate";
            this.DtpAcceptedDate.Size = new System.Drawing.Size(120, 23);
            this.DtpAcceptedDate.TabIndex = 11;
            this.DtpAcceptedDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Enabled = false;
            this.txtQuantity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(698, 105);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(120, 23);
            this.txtQuantity.TabIndex = 15;
            // 
            // lblPMStatusChangeQtyReceived
            // 
            this.lblPMStatusChangeQtyReceived.AutoSize = true;
            this.lblPMStatusChangeQtyReceived.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMStatusChangeQtyReceived.Location = new System.Drawing.Point(628, 107);
            this.lblPMStatusChangeQtyReceived.Name = "lblPMStatusChangeQtyReceived";
            this.lblPMStatusChangeQtyReceived.Size = new System.Drawing.Size(65, 16);
            this.lblPMStatusChangeQtyReceived.TabIndex = 14;
            this.lblPMStatusChangeQtyReceived.Text = "Quantity";
            // 
            // cmbPMCode
            // 
            this.cmbPMCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPMCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPMCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPMCode.FormattingEnabled = true;
            this.cmbPMCode.Location = new System.Drawing.Point(129, 14);
            this.cmbPMCode.Name = "cmbPMCode";
            this.cmbPMCode.Size = new System.Drawing.Size(132, 24);
            this.cmbPMCode.TabIndex = 1;
            this.cmbPMCode.SelectionChangeCommitted += new System.EventHandler(this.cmbPMCode_SelectionChangeCommitted);
            // 
            // lblPMCode
            // 
            this.lblPMCode.AutoSize = true;
            this.lblPMCode.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMCode.Location = new System.Drawing.Point(42, 19);
            this.lblPMCode.Name = "lblPMCode";
            this.lblPMCode.Size = new System.Drawing.Size(60, 16);
            this.lblPMCode.TabIndex = 0;
            this.lblPMCode.Text = "PMCode";
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
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn2.HeaderText = "Defect Comment";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn3.HeaderText = "Defect Quantity";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn4.HeaderText = "QualityDecision";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewTextBoxColumn5.HeaderText = "Sample Size (Std)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Samples Size (Read)";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewTextBoxColumn7.HeaderText = "AQL (std)";
            this.dataGridViewTextBoxColumn7.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewTextBoxColumn8.HeaderText = "AQL (Read)";
            this.dataGridViewTextBoxColumn8.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 50;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn9.HeaderText = "AQL(z) (Std)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 50;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn10.HeaderText = "AQL(z) (Read)";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 50;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn11.HeaderText = "AQL(c) (Std)";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 50;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "AQL(c) (Read)";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 50;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn13.HeaderText = "AQL(M) (Std)";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 50;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "AQL(M) (Read)";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 50;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridViewTextBoxColumn15.HeaderText = "AQL(M1) (Std)";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 60;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "AQL(M1) (Read)";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 60;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "PMDefectID";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "Defect Comment";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 300;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "Defect Quantity";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Width = 120;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "QualityDecision";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // FrmPMReanalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1026, 751);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1018, 717);
            this.Controls.Add(this.panelOuter);
            this.Name = "FrmPMReanalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PM Reanalysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPMReanalysis_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelFill.ResumeLayout(false);
            this.gbPMTreatmentdone.ResumeLayout(false);
            this.gbPMTreatmentdone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllTests)).EndInit();
            this.gbRMButtons.ResumeLayout(false);
            this.gbPMTransactionStatus.ResumeLayout(false);
            this.gbPMTransactionStatus.PerformLayout();
            this.gbFields.ResumeLayout(false);
            this.gbFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDefect)).EndInit();
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
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblPMStatusChangeQtyReceived;
        private System.Windows.Forms.ComboBox cmbPMCode;
        private System.Windows.Forms.Label lblPMCode;
        private System.Windows.Forms.GroupBox gbRMButtons;
        private System.Windows.Forms.Button BtnPMStatusChangeExit;
        private System.Windows.Forms.Button BtnPMStatusChangeReset;
        private System.Windows.Forms.Button BtnPMStatusChangeSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpInspDate;
        private System.Windows.Forms.Label lblPMTransactionAcceptedDate;
        private System.Windows.Forms.DateTimePicker DtpAcceptedDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.ComboBox cmbPlantLotNo;
        private System.Windows.Forms.GroupBox gbFields;
        private System.Windows.Forms.DataGridView dgDefect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoOfDefect;
        private System.Windows.Forms.ComboBox cmbDefectObserved;
        private System.Windows.Forms.Label lblPMTransactionDetectNoteSend;
        private System.Windows.Forms.TextBox txtCOC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox gbPMTransactionStatus;
        private System.Windows.Forms.CheckedListBox chkRejectComments;
        private System.Windows.Forms.RadioButton RdoSendBackToSupplier;
        private System.Windows.Forms.RadioButton RdoTreatment;
        private System.Windows.Forms.RadioButton RdoAWD;
        private System.Windows.Forms.RadioButton RdoReject;
        private System.Windows.Forms.RadioButton RdoAccept;
        private System.Windows.Forms.GroupBox gbPMTreatmentdone;
        private System.Windows.Forms.RadioButton RdoNo;
        private System.Windows.Forms.RadioButton RdoYes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridView dgAllTests;
        private System.Windows.Forms.DataGridViewTextBoxColumn PMMethodNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewComboBoxColumn InspectionMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleSizeStandard;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleSizeReading;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQLStandard;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQLReading;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQLzStandard;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQLzReading;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQLcStandard;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQLcReading;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQLMStandard;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQLMReading;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQLM1Standard;
        private System.Windows.Forms.DataGridViewTextBoxColumn AQLM1Reading;
        private System.Windows.Forms.DataGridViewTextBoxColumn PMDefectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefectComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefectQuantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn ActionTaken;
        private System.Windows.Forms.DataGridViewComboBoxColumn QualityDecision;
        private System.Windows.Forms.DataGridViewComboBoxColumn DefectStatus;
    }
}