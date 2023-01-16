namespace QTMS.Transactions
{
    partial class FrmRMValidityReport
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
            frmRMValidityReport_Obj = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRMValidityReport));
            this.gbRMVRSelectFields = new System.Windows.Forms.GroupBox();
            this.dtpRMVRToDate = new System.Windows.Forms.DateTimePicker();
            this.lblRMStatusChangeToDate = new System.Windows.Forms.Label();
            this.dtpRMVRFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblRMStatusChangeFromDate = new System.Windows.Forms.Label();
            this.gbRMVRFields = new System.Windows.Forms.GroupBox();
            this.cmbTypeOfControl = new System.Windows.Forms.ComboBox();
            this.lblRMTransactionTypeOfControl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpRMVRValidityExpanded = new System.Windows.Forms.DateTimePicker();
            this.lblRMValidityExpanded = new System.Windows.Forms.Label();
            this.txtRMVRReaminingQuantity = new System.Windows.Forms.TextBox();
            this.lblRMVRRemainingQuantity = new System.Windows.Forms.Label();
            this.txtRMVRAcceptedQuantity = new System.Windows.Forms.TextBox();
            this.lblRMVRAcceptedQuantity = new System.Windows.Forms.Label();
            this.txtRMVRQuantityReceived = new System.Windows.Forms.TextBox();
            this.lblRMVRQuantityReceived = new System.Windows.Forms.Label();
            this.cmbDetails = new System.Windows.Forms.ComboBox();
            this.lblRMVRRMCode = new System.Windows.Forms.Label();
            this.gbRMButtons = new System.Windows.Forms.GroupBox();
            this.BtnRMVRExit = new System.Windows.Forms.Button();
            this.BtnRMVRSave = new System.Windows.Forms.Button();
            this.BtnRMVRReset = new System.Windows.Forms.Button();
            this.gbRMTransactionStatus = new System.Windows.Forms.GroupBox();
            this.RdoRmValiditySenttoSupplier = new System.Windows.Forms.RadioButton();
            this.RdoRmValidityAWD = new System.Windows.Forms.RadioButton();
            this.RdoRMValidityReject = new System.Windows.Forms.RadioButton();
            this.RdoRMValidityAccept = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgTest = new System.Windows.Forms.DataGridView();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelbottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.chkSubcontract = new System.Windows.Forms.CheckBox();
            this.gbRMVRSelectFields.SuspendLayout();
            this.gbRMVRFields.SuspendLayout();
            this.gbRMButtons.SuspendLayout();
            this.gbRMTransactionStatus.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTest)).BeginInit();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelbottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRMVRSelectFields
            // 
            this.gbRMVRSelectFields.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbRMVRSelectFields.Controls.Add(this.dtpRMVRToDate);
            this.gbRMVRSelectFields.Controls.Add(this.lblRMStatusChangeToDate);
            this.gbRMVRSelectFields.Controls.Add(this.dtpRMVRFromDate);
            this.gbRMVRSelectFields.Controls.Add(this.lblRMStatusChangeFromDate);
            this.gbRMVRSelectFields.Location = new System.Drawing.Point(11, 6);
            this.gbRMVRSelectFields.Name = "gbRMVRSelectFields";
            this.gbRMVRSelectFields.Size = new System.Drawing.Size(798, 63);
            this.gbRMVRSelectFields.TabIndex = 5;
            this.gbRMVRSelectFields.TabStop = false;
            // 
            // dtpRMVRToDate
            // 
            this.dtpRMVRToDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpRMVRToDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpRMVRToDate.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpRMVRToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpRMVRToDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.dtpRMVRToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRMVRToDate.Location = new System.Drawing.Point(525, 20);
            this.dtpRMVRToDate.Name = "dtpRMVRToDate";
            this.dtpRMVRToDate.Size = new System.Drawing.Size(118, 23);
            this.dtpRMVRToDate.TabIndex = 85;
            this.dtpRMVRToDate.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            this.dtpRMVRToDate.ValueChanged += new System.EventHandler(this.dtpRMVRToDate_ValueChanged);
            // 
            // lblRMStatusChangeToDate
            // 
            this.lblRMStatusChangeToDate.AutoSize = true;
            this.lblRMStatusChangeToDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMStatusChangeToDate.Location = new System.Drawing.Point(434, 23);
            this.lblRMStatusChangeToDate.Name = "lblRMStatusChangeToDate";
            this.lblRMStatusChangeToDate.Size = new System.Drawing.Size(66, 16);
            this.lblRMStatusChangeToDate.TabIndex = 84;
            this.lblRMStatusChangeToDate.Text = "To  Date";
            // 
            // dtpRMVRFromDate
            // 
            this.dtpRMVRFromDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpRMVRFromDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpRMVRFromDate.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpRMVRFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpRMVRFromDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.dtpRMVRFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRMVRFromDate.Location = new System.Drawing.Point(257, 20);
            this.dtpRMVRFromDate.Name = "dtpRMVRFromDate";
            this.dtpRMVRFromDate.Size = new System.Drawing.Size(121, 23);
            this.dtpRMVRFromDate.TabIndex = 83;
            this.dtpRMVRFromDate.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            this.dtpRMVRFromDate.ValueChanged += new System.EventHandler(this.dtpRMVRFromDate_ValueChanged);
            // 
            // lblRMStatusChangeFromDate
            // 
            this.lblRMStatusChangeFromDate.AutoSize = true;
            this.lblRMStatusChangeFromDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMStatusChangeFromDate.Location = new System.Drawing.Point(156, 23);
            this.lblRMStatusChangeFromDate.Name = "lblRMStatusChangeFromDate";
            this.lblRMStatusChangeFromDate.Size = new System.Drawing.Size(76, 16);
            this.lblRMStatusChangeFromDate.TabIndex = 82;
            this.lblRMStatusChangeFromDate.Text = "From Date";
            // 
            // gbRMVRFields
            // 
            this.gbRMVRFields.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbRMVRFields.Controls.Add(this.chkSubcontract);
            this.gbRMVRFields.Controls.Add(this.cmbTypeOfControl);
            this.gbRMVRFields.Controls.Add(this.lblRMTransactionTypeOfControl);
            this.gbRMVRFields.Controls.Add(this.label1);
            this.gbRMVRFields.Controls.Add(this.dtpRMVRValidityExpanded);
            this.gbRMVRFields.Controls.Add(this.lblRMValidityExpanded);
            this.gbRMVRFields.Controls.Add(this.txtRMVRReaminingQuantity);
            this.gbRMVRFields.Controls.Add(this.lblRMVRRemainingQuantity);
            this.gbRMVRFields.Controls.Add(this.txtRMVRAcceptedQuantity);
            this.gbRMVRFields.Controls.Add(this.lblRMVRAcceptedQuantity);
            this.gbRMVRFields.Controls.Add(this.txtRMVRQuantityReceived);
            this.gbRMVRFields.Controls.Add(this.lblRMVRQuantityReceived);
            this.gbRMVRFields.Controls.Add(this.cmbDetails);
            this.gbRMVRFields.Controls.Add(this.lblRMVRRMCode);
            this.gbRMVRFields.Location = new System.Drawing.Point(11, 77);
            this.gbRMVRFields.Name = "gbRMVRFields";
            this.gbRMVRFields.Size = new System.Drawing.Size(798, 207);
            this.gbRMVRFields.TabIndex = 52;
            this.gbRMVRFields.TabStop = false;
            // 
            // cmbTypeOfControl
            // 
            this.cmbTypeOfControl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbTypeOfControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeOfControl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypeOfControl.FormattingEnabled = true;
            this.cmbTypeOfControl.Items.AddRange(new object[] {
            "Reduced Control",
            "Full Control"});
            this.cmbTypeOfControl.Location = new System.Drawing.Point(547, 78);
            this.cmbTypeOfControl.Name = "cmbTypeOfControl";
            this.cmbTypeOfControl.Size = new System.Drawing.Size(154, 24);
            this.cmbTypeOfControl.TabIndex = 104;
            this.cmbTypeOfControl.SelectionChangeCommitted += new System.EventHandler(this.cmbTypeOfControl_SelectionChangeCommitted);
            // 
            // lblRMTransactionTypeOfControl
            // 
            this.lblRMTransactionTypeOfControl.AutoSize = true;
            this.lblRMTransactionTypeOfControl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionTypeOfControl.Location = new System.Drawing.Point(429, 82);
            this.lblRMTransactionTypeOfControl.Name = "lblRMTransactionTypeOfControl";
            this.lblRMTransactionTypeOfControl.Size = new System.Drawing.Size(113, 16);
            this.lblRMTransactionTypeOfControl.TabIndex = 103;
            this.lblRMTransactionTypeOfControl.Text = "Type Of Control";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "( RMCode - Supplier -  Lot No )";
            // 
            // dtpRMVRValidityExpanded
            // 
            this.dtpRMVRValidityExpanded.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpRMVRValidityExpanded.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpRMVRValidityExpanded.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpRMVRValidityExpanded.CustomFormat = "dd-MMM-yyyy";
            this.dtpRMVRValidityExpanded.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.dtpRMVRValidityExpanded.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRMVRValidityExpanded.Location = new System.Drawing.Point(547, 121);
            this.dtpRMVRValidityExpanded.Name = "dtpRMVRValidityExpanded";
            this.dtpRMVRValidityExpanded.Size = new System.Drawing.Size(154, 23);
            this.dtpRMVRValidityExpanded.TabIndex = 86;
            this.dtpRMVRValidityExpanded.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            // 
            // lblRMValidityExpanded
            // 
            this.lblRMValidityExpanded.AutoSize = true;
            this.lblRMValidityExpanded.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMValidityExpanded.Location = new System.Drawing.Point(417, 124);
            this.lblRMValidityExpanded.Name = "lblRMValidityExpanded";
            this.lblRMValidityExpanded.Size = new System.Drawing.Size(124, 16);
            this.lblRMValidityExpanded.TabIndex = 101;
            this.lblRMValidityExpanded.Text = "Validity Expanded";
            // 
            // txtRMVRReaminingQuantity
            // 
            this.txtRMVRReaminingQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMVRReaminingQuantity.Enabled = false;
            this.txtRMVRReaminingQuantity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMVRReaminingQuantity.Location = new System.Drawing.Point(175, 164);
            this.txtRMVRReaminingQuantity.Name = "txtRMVRReaminingQuantity";
            this.txtRMVRReaminingQuantity.Size = new System.Drawing.Size(217, 23);
            this.txtRMVRReaminingQuantity.TabIndex = 100;
            // 
            // lblRMVRRemainingQuantity
            // 
            this.lblRMVRRemainingQuantity.AutoSize = true;
            this.lblRMVRRemainingQuantity.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMVRRemainingQuantity.Location = new System.Drawing.Point(36, 167);
            this.lblRMVRRemainingQuantity.Name = "lblRMVRRemainingQuantity";
            this.lblRMVRRemainingQuantity.Size = new System.Drawing.Size(135, 16);
            this.lblRMVRRemainingQuantity.TabIndex = 99;
            this.lblRMVRRemainingQuantity.Text = "Remaining Quantity";
            // 
            // txtRMVRAcceptedQuantity
            // 
            this.txtRMVRAcceptedQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMVRAcceptedQuantity.Enabled = false;
            this.txtRMVRAcceptedQuantity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMVRAcceptedQuantity.Location = new System.Drawing.Point(175, 121);
            this.txtRMVRAcceptedQuantity.Name = "txtRMVRAcceptedQuantity";
            this.txtRMVRAcceptedQuantity.Size = new System.Drawing.Size(217, 23);
            this.txtRMVRAcceptedQuantity.TabIndex = 98;
            // 
            // lblRMVRAcceptedQuantity
            // 
            this.lblRMVRAcceptedQuantity.AutoSize = true;
            this.lblRMVRAcceptedQuantity.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMVRAcceptedQuantity.Location = new System.Drawing.Point(38, 124);
            this.lblRMVRAcceptedQuantity.Name = "lblRMVRAcceptedQuantity";
            this.lblRMVRAcceptedQuantity.Size = new System.Drawing.Size(133, 16);
            this.lblRMVRAcceptedQuantity.TabIndex = 97;
            this.lblRMVRAcceptedQuantity.Text = "Accepted Quantity";
            // 
            // txtRMVRQuantityReceived
            // 
            this.txtRMVRQuantityReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMVRQuantityReceived.Enabled = false;
            this.txtRMVRQuantityReceived.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMVRQuantityReceived.Location = new System.Drawing.Point(175, 78);
            this.txtRMVRQuantityReceived.Name = "txtRMVRQuantityReceived";
            this.txtRMVRQuantityReceived.Size = new System.Drawing.Size(217, 23);
            this.txtRMVRQuantityReceived.TabIndex = 95;
            // 
            // lblRMVRQuantityReceived
            // 
            this.lblRMVRQuantityReceived.AutoSize = true;
            this.lblRMVRQuantityReceived.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMVRQuantityReceived.Location = new System.Drawing.Point(37, 81);
            this.lblRMVRQuantityReceived.Name = "lblRMVRQuantityReceived";
            this.lblRMVRQuantityReceived.Size = new System.Drawing.Size(134, 16);
            this.lblRMVRQuantityReceived.TabIndex = 94;
            this.lblRMVRQuantityReceived.Text = " Received Quantity";
            // 
            // cmbDetails
            // 
            this.cmbDetails.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDetails.FormattingEnabled = true;
            this.cmbDetails.Location = new System.Drawing.Point(210, 38);
            this.cmbDetails.Name = "cmbDetails";
            this.cmbDetails.Size = new System.Drawing.Size(399, 24);
            this.cmbDetails.TabIndex = 88;
            this.cmbDetails.SelectionChangeCommitted += new System.EventHandler(this.cmbDetails_SelectionChangeCommitted);
            // 
            // lblRMVRRMCode
            // 
            this.lblRMVRRMCode.AutoSize = true;
            this.lblRMVRRMCode.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMVRRMCode.Location = new System.Drawing.Point(153, 42);
            this.lblRMVRRMCode.Name = "lblRMVRRMCode";
            this.lblRMVRRMCode.Size = new System.Drawing.Size(52, 16);
            this.lblRMVRRMCode.TabIndex = 87;
            this.lblRMVRRMCode.Text = "Details";
            // 
            // gbRMButtons
            // 
            this.gbRMButtons.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbRMButtons.Controls.Add(this.BtnRMVRExit);
            this.gbRMButtons.Controls.Add(this.BtnRMVRSave);
            this.gbRMButtons.Controls.Add(this.BtnRMVRReset);
            this.gbRMButtons.Location = new System.Drawing.Point(11, 471);
            this.gbRMButtons.Name = "gbRMButtons";
            this.gbRMButtons.Size = new System.Drawing.Size(798, 73);
            this.gbRMButtons.TabIndex = 54;
            this.gbRMButtons.TabStop = false;
            // 
            // BtnRMVRExit
            // 
            this.BtnRMVRExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMVRExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMVRExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRMVRExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMVRExit.Location = new System.Drawing.Point(531, 22);
            this.BtnRMVRExit.Name = "BtnRMVRExit";
            this.BtnRMVRExit.Size = new System.Drawing.Size(112, 28);
            this.BtnRMVRExit.TabIndex = 58;
            this.BtnRMVRExit.Text = "&Exit";
            this.BtnRMVRExit.UseVisualStyleBackColor = false;
            this.BtnRMVRExit.Click += new System.EventHandler(this.BtnRMVRExit_Click);
            // 
            // BtnRMVRSave
            // 
            this.BtnRMVRSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMVRSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMVRSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRMVRSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMVRSave.Location = new System.Drawing.Point(348, 22);
            this.BtnRMVRSave.Name = "BtnRMVRSave";
            this.BtnRMVRSave.Size = new System.Drawing.Size(112, 28);
            this.BtnRMVRSave.TabIndex = 55;
            this.BtnRMVRSave.Text = "&Save";
            this.BtnRMVRSave.UseVisualStyleBackColor = false;
            this.BtnRMVRSave.Click += new System.EventHandler(this.BtnRMVRSave_Click);
            // 
            // BtnRMVRReset
            // 
            this.BtnRMVRReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMVRReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMVRReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRMVRReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMVRReset.Location = new System.Drawing.Point(155, 22);
            this.BtnRMVRReset.Name = "BtnRMVRReset";
            this.BtnRMVRReset.Size = new System.Drawing.Size(112, 28);
            this.BtnRMVRReset.TabIndex = 54;
            this.BtnRMVRReset.Text = "&Reset";
            this.BtnRMVRReset.UseVisualStyleBackColor = false;
            this.BtnRMVRReset.Click += new System.EventHandler(this.BtnRMVRReset_Click);
            // 
            // gbRMTransactionStatus
            // 
            this.gbRMTransactionStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbRMTransactionStatus.Controls.Add(this.RdoRmValiditySenttoSupplier);
            this.gbRMTransactionStatus.Controls.Add(this.RdoRmValidityAWD);
            this.gbRMTransactionStatus.Controls.Add(this.RdoRMValidityReject);
            this.gbRMTransactionStatus.Controls.Add(this.RdoRMValidityAccept);
            this.gbRMTransactionStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRMTransactionStatus.Location = new System.Drawing.Point(11, 396);
            this.gbRMTransactionStatus.Name = "gbRMTransactionStatus";
            this.gbRMTransactionStatus.Size = new System.Drawing.Size(798, 67);
            this.gbRMTransactionStatus.TabIndex = 55;
            this.gbRMTransactionStatus.TabStop = false;
            this.gbRMTransactionStatus.Text = "Status";
            // 
            // RdoRmValiditySenttoSupplier
            // 
            this.RdoRmValiditySenttoSupplier.AutoSize = true;
            this.RdoRmValiditySenttoSupplier.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoRmValiditySenttoSupplier.Location = new System.Drawing.Point(582, 23);
            this.RdoRmValiditySenttoSupplier.Name = "RdoRmValiditySenttoSupplier";
            this.RdoRmValiditySenttoSupplier.Size = new System.Drawing.Size(172, 20);
            this.RdoRmValiditySenttoSupplier.TabIndex = 88;
            this.RdoRmValiditySenttoSupplier.Text = "Sent Back To Supplier";
            this.RdoRmValiditySenttoSupplier.UseVisualStyleBackColor = true;
            // 
            // RdoRmValidityAWD
            // 
            this.RdoRmValidityAWD.AutoSize = true;
            this.RdoRmValidityAWD.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoRmValidityAWD.Location = new System.Drawing.Point(412, 23);
            this.RdoRmValidityAWD.Name = "RdoRmValidityAWD";
            this.RdoRmValidityAWD.Size = new System.Drawing.Size(57, 20);
            this.RdoRmValidityAWD.TabIndex = 87;
            this.RdoRmValidityAWD.Text = "AWD";
            this.RdoRmValidityAWD.UseVisualStyleBackColor = true;
            // 
            // RdoRMValidityReject
            // 
            this.RdoRMValidityReject.AutoSize = true;
            this.RdoRMValidityReject.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoRMValidityReject.Location = new System.Drawing.Point(231, 23);
            this.RdoRMValidityReject.Name = "RdoRMValidityReject";
            this.RdoRMValidityReject.Size = new System.Drawing.Size(68, 20);
            this.RdoRMValidityReject.TabIndex = 86;
            this.RdoRMValidityReject.Text = "Reject";
            this.RdoRMValidityReject.UseVisualStyleBackColor = true;
            // 
            // RdoRMValidityAccept
            // 
            this.RdoRMValidityAccept.AutoSize = true;
            this.RdoRMValidityAccept.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoRMValidityAccept.Location = new System.Drawing.Point(45, 23);
            this.RdoRMValidityAccept.Name = "RdoRMValidityAccept";
            this.RdoRMValidityAccept.Size = new System.Drawing.Size(73, 20);
            this.RdoRMValidityAccept.TabIndex = 85;
            this.RdoRMValidityAccept.Text = "Accept";
            this.RdoRMValidityAccept.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox5.Controls.Add(this.dgTest);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(11, 292);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(798, 96);
            this.groupBox5.TabIndex = 56;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Test";
            // 
            // dgTest
            // 
            this.dgTest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dgTest.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTest.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgTest.Location = new System.Drawing.Point(135, 14);
            this.dgTest.MultiSelect = false;
            this.dgTest.Name = "dgTest";
            this.dgTest.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgTest.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgTest.Size = new System.Drawing.Size(528, 68);
            this.dgTest.TabIndex = 0;
            this.dgTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTest_CellClick);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelbottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(822, 527);
            this.panelOuter.TabIndex = 57;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(820, 30);
            this.panelTop.TabIndex = 44;
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
            this.toolStrip1.Size = new System.Drawing.Size(820, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(113, 27);
            this.toolStripLabel1.Text = "RM Validity Report";
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
            // panelbottom
            // 
            this.panelbottom.Controls.Add(this.panelFill);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelbottom.Location = new System.Drawing.Point(0, -39);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(820, 564);
            this.panelbottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.groupBox5);
            this.panelFill.Controls.Add(this.gbRMTransactionStatus);
            this.panelFill.Controls.Add(this.gbRMButtons);
            this.panelFill.Controls.Add(this.gbRMVRFields);
            this.panelFill.Controls.Add(this.gbRMVRSelectFields);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(820, 564);
            this.panelFill.TabIndex = 0;
            // 
            // chkSubcontract
            // 
            this.chkSubcontract.AutoSize = true;
            this.chkSubcontract.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSubcontract.Location = new System.Drawing.Point(547, 164);
            this.chkSubcontract.Name = "chkSubcontract";
            this.chkSubcontract.Size = new System.Drawing.Size(104, 18);
            this.chkSubcontract.TabIndex = 105;
            this.chkSubcontract.Text = "SubContract";
            this.chkSubcontract.UseVisualStyleBackColor = true;
            this.chkSubcontract.CheckedChanged += new System.EventHandler(this.chkSubcontract_CheckedChanged);
            // 
            // FrmRMValidityReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(822, 527);
            this.Controls.Add(this.panelOuter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRMValidityReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RM Validity Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRMValidityReport_Load);
            this.gbRMVRSelectFields.ResumeLayout(false);
            this.gbRMVRSelectFields.PerformLayout();
            this.gbRMVRFields.ResumeLayout(false);
            this.gbRMVRFields.PerformLayout();
            this.gbRMButtons.ResumeLayout(false);
            this.gbRMTransactionStatus.ResumeLayout(false);
            this.gbRMTransactionStatus.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTest)).EndInit();
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelbottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRMVRSelectFields;
        private System.Windows.Forms.DateTimePicker dtpRMVRToDate;
        private System.Windows.Forms.Label lblRMStatusChangeToDate;
        private System.Windows.Forms.DateTimePicker dtpRMVRFromDate;
        private System.Windows.Forms.Label lblRMStatusChangeFromDate;
        private System.Windows.Forms.GroupBox gbRMVRFields;
        private System.Windows.Forms.TextBox txtRMVRQuantityReceived;
        private System.Windows.Forms.Label lblRMVRQuantityReceived;
        private System.Windows.Forms.ComboBox cmbDetails;
        private System.Windows.Forms.Label lblRMVRRMCode;
        private System.Windows.Forms.TextBox txtRMVRReaminingQuantity;
        private System.Windows.Forms.Label lblRMVRRemainingQuantity;
        private System.Windows.Forms.TextBox txtRMVRAcceptedQuantity;
        private System.Windows.Forms.Label lblRMVRAcceptedQuantity;
        private System.Windows.Forms.GroupBox gbRMButtons;
        private System.Windows.Forms.Button BtnRMVRExit;
        private System.Windows.Forms.Button BtnRMVRSave;
        private System.Windows.Forms.Button BtnRMVRReset;
        private System.Windows.Forms.Label lblRMValidityExpanded;
        private System.Windows.Forms.DateTimePicker dtpRMVRValidityExpanded;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbRMTransactionStatus;
        private System.Windows.Forms.RadioButton RdoRmValiditySenttoSupplier;
        private System.Windows.Forms.RadioButton RdoRmValidityAWD;
        private System.Windows.Forms.RadioButton RdoRMValidityReject;
        private System.Windows.Forms.RadioButton RdoRMValidityAccept;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.DataGridView dgTest;
        private System.Windows.Forms.ComboBox cmbTypeOfControl;
        private System.Windows.Forms.Label lblRMTransactionTypeOfControl;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelbottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.CheckBox chkSubcontract;
    }
}