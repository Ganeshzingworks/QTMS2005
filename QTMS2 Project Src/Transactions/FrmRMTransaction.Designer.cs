namespace QTMS.Transactions
{
    partial class FrmRMTransaction
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
            frmRMTransaction_Obj = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRMTransaction));
            this.gbRMSamplingFields = new System.Windows.Forms.GroupBox();
            this.lblCountryOfOrigin = new System.Windows.Forms.Label();
            this.lblForCountryofOrigin = new System.Windows.Forms.Label();
            this.lblForPlantOrigin = new System.Windows.Forms.Label();
            this.lblForHalal = new System.Windows.Forms.Label();
            this.lblplantOrigin = new System.Windows.Forms.Label();
            this.lblHalal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblIsAligned = new System.Windows.Forms.Label();
            this.txtAgentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMsgFull = new System.Windows.Forms.Label();
            this.txtQuantityReceived = new System.Windows.Forms.TextBox();
            this.lblRMTransactionQuantityReceived = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblRMSamplingSupplierName = new System.Windows.Forms.Label();
            this.txtPlantLotNo = new System.Windows.Forms.TextBox();
            this.lblRMSamplingLotNo = new System.Windows.Forms.Label();
            this.cmbTypeOfControl = new System.Windows.Forms.ComboBox();
            this.dtpInspDate = new System.Windows.Forms.DateTimePicker();
            this.lblRMTransactionTypeOfControl = new System.Windows.Forms.Label();
            this.lblRMTransactionInspDate = new System.Windows.Forms.Label();
            this.cmbRMCode = new System.Windows.Forms.ComboBox();
            this.lblRMTransactionDetails = new System.Windows.Forms.Label();
            this.dtpAcceptedDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.gbManualFields = new System.Windows.Forms.GroupBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.dtpManufacturingDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDateOfValidity = new System.Windows.Forms.DateTimePicker();
            this.cmbFirstRMReception = new System.Windows.Forms.ComboBox();
            this.dtpDisposalDate = new System.Windows.Forms.DateTimePicker();
            this.dtpReceiptDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSupplierReportReceived = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbConfirmation = new System.Windows.Forms.ComboBox();
            this.lblRMTransactionDateofValidity = new System.Windows.Forms.Label();
            this.txtChallanNo = new System.Windows.Forms.TextBox();
            this.lblRMTransactionChallanNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRMTransactionFirstRMReception = new System.Windows.Forms.Label();
            this.lblRMTransactionReceived = new System.Windows.Forms.Label();
            this.lblRMTransactionConfirmation = new System.Windows.Forms.Label();
            this.txtSupplierLotNo = new System.Windows.Forms.TextBox();
            this.lblRMTransactionSupplierLotNo = new System.Windows.Forms.Label();
            this.txtMRR = new System.Windows.Forms.TextBox();
            this.lblRMTransactionMRR = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRMTransactionReceiptDate = new System.Windows.Forms.Label();
            this.gbRMButtons = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.BtnRMProtocol = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.gbRMTransactionStatus = new System.Windows.Forms.GroupBox();
            this.txtRejectDescription = new System.Windows.Forms.TextBox();
            this.lblReject = new System.Windows.Forms.Label();
            this.RdoHold = new System.Windows.Forms.RadioButton();
            this.RdoSentToSupplier = new System.Windows.Forms.RadioButton();
            this.RdoAWD = new System.Windows.Forms.RadioButton();
            this.RdoReject = new System.Windows.Forms.RadioButton();
            this.RdoAccept = new System.Windows.Forms.RadioButton();
            this.gbRMTransactionLabelForRetainer = new System.Windows.Forms.GroupBox();
            this.btnPrintValidity = new System.Windows.Forms.Button();
            this.chkSubcontract = new System.Windows.Forms.CheckBox();
            this.labelMicro = new System.Windows.Forms.Label();
            this.RdoNegative = new System.Windows.Forms.RadioButton();
            this.RdoPositive = new System.Windows.Forms.RadioButton();
            this.btnPrint = new System.Windows.Forms.Button();
            this.chkLabelForRetainer = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgTest = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMsgSampling = new System.Windows.Forms.Label();
            this.txtNoOfSegments = new System.Windows.Forms.TextBox();
            this.lblRMSamplingNoOfSegments = new System.Windows.Forms.Label();
            this.lblRMSamplingActualNoSegments = new System.Windows.Forms.Label();
            this.txtActualNoSegments = new System.Windows.Forms.TextBox();
            this.txtQuantitySampled = new System.Windows.Forms.TextBox();
            this.lblRMSamplingQantityToComplete = new System.Windows.Forms.Label();
            this.txtProtocolNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblTradeName = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbRMSamplingFields.SuspendLayout();
            this.gbManualFields.SuspendLayout();
            this.gbRMButtons.SuspendLayout();
            this.gbRMTransactionStatus.SuspendLayout();
            this.gbRMTransactionLabelForRetainer.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTest)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRMSamplingFields
            // 
            this.gbRMSamplingFields.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbRMSamplingFields.Controls.Add(this.lblTradeName);
            this.gbRMSamplingFields.Controls.Add(this.label9);
            this.gbRMSamplingFields.Controls.Add(this.lblCountryOfOrigin);
            this.gbRMSamplingFields.Controls.Add(this.lblForCountryofOrigin);
            this.gbRMSamplingFields.Controls.Add(this.lblForPlantOrigin);
            this.gbRMSamplingFields.Controls.Add(this.lblForHalal);
            this.gbRMSamplingFields.Controls.Add(this.lblplantOrigin);
            this.gbRMSamplingFields.Controls.Add(this.lblHalal);
            this.gbRMSamplingFields.Controls.Add(this.label7);
            this.gbRMSamplingFields.Controls.Add(this.lblIsAligned);
            this.gbRMSamplingFields.Controls.Add(this.txtAgentName);
            this.gbRMSamplingFields.Controls.Add(this.label2);
            this.gbRMSamplingFields.Controls.Add(this.lblMsgFull);
            this.gbRMSamplingFields.Controls.Add(this.txtQuantityReceived);
            this.gbRMSamplingFields.Controls.Add(this.lblRMTransactionQuantityReceived);
            this.gbRMSamplingFields.Controls.Add(this.cmbSupplier);
            this.gbRMSamplingFields.Controls.Add(this.lblRMSamplingSupplierName);
            this.gbRMSamplingFields.Controls.Add(this.txtPlantLotNo);
            this.gbRMSamplingFields.Controls.Add(this.lblRMSamplingLotNo);
            this.gbRMSamplingFields.Controls.Add(this.cmbTypeOfControl);
            this.gbRMSamplingFields.Controls.Add(this.dtpInspDate);
            this.gbRMSamplingFields.Controls.Add(this.lblRMTransactionTypeOfControl);
            this.gbRMSamplingFields.Controls.Add(this.lblRMTransactionInspDate);
            this.gbRMSamplingFields.Controls.Add(this.cmbRMCode);
            this.gbRMSamplingFields.Controls.Add(this.lblRMTransactionDetails);
            this.gbRMSamplingFields.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRMSamplingFields.Location = new System.Drawing.Point(25, 32);
            this.gbRMSamplingFields.Name = "gbRMSamplingFields";
            this.gbRMSamplingFields.Size = new System.Drawing.Size(872, 139);
            this.gbRMSamplingFields.TabIndex = 0;
            this.gbRMSamplingFields.TabStop = false;
            // 
            // lblCountryOfOrigin
            // 
            this.lblCountryOfOrigin.AutoSize = true;
            this.lblCountryOfOrigin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountryOfOrigin.ForeColor = System.Drawing.Color.Red;
            this.lblCountryOfOrigin.Location = new System.Drawing.Point(451, 120);
            this.lblCountryOfOrigin.Name = "lblCountryOfOrigin";
            this.lblCountryOfOrigin.Size = new System.Drawing.Size(0, 14);
            this.lblCountryOfOrigin.TabIndex = 23;
            // 
            // lblForCountryofOrigin
            // 
            this.lblForCountryofOrigin.AutoSize = true;
            this.lblForCountryofOrigin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForCountryofOrigin.Location = new System.Drawing.Point(315, 120);
            this.lblForCountryofOrigin.Name = "lblForCountryofOrigin";
            this.lblForCountryofOrigin.Size = new System.Drawing.Size(130, 14);
            this.lblForCountryofOrigin.TabIndex = 22;
            this.lblForCountryofOrigin.Text = "Country of Origin :";
            // 
            // lblForPlantOrigin
            // 
            this.lblForPlantOrigin.AutoSize = true;
            this.lblForPlantOrigin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForPlantOrigin.Location = new System.Drawing.Point(413, 98);
            this.lblForPlantOrigin.Name = "lblForPlantOrigin";
            this.lblForPlantOrigin.Size = new System.Drawing.Size(95, 14);
            this.lblForPlantOrigin.TabIndex = 21;
            this.lblForPlantOrigin.Text = "Animal Free :";
            // 
            // lblForHalal
            // 
            this.lblForHalal.AutoSize = true;
            this.lblForHalal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForHalal.Location = new System.Drawing.Point(315, 98);
            this.lblForHalal.Name = "lblForHalal";
            this.lblForHalal.Size = new System.Drawing.Size(50, 14);
            this.lblForHalal.TabIndex = 20;
            this.lblForHalal.Text = "Halal :";
            // 
            // lblplantOrigin
            // 
            this.lblplantOrigin.AutoSize = true;
            this.lblplantOrigin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblplantOrigin.ForeColor = System.Drawing.Color.Red;
            this.lblplantOrigin.Location = new System.Drawing.Point(507, 98);
            this.lblplantOrigin.Name = "lblplantOrigin";
            this.lblplantOrigin.Size = new System.Drawing.Size(0, 14);
            this.lblplantOrigin.TabIndex = 19;
            // 
            // lblHalal
            // 
            this.lblHalal.AutoSize = true;
            this.lblHalal.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalal.ForeColor = System.Drawing.Color.Red;
            this.lblHalal.Location = new System.Drawing.Point(365, 98);
            this.lblHalal.Name = "lblHalal";
            this.lblHalal.Size = new System.Drawing.Size(0, 14);
            this.lblHalal.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(831, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "KG";
            // 
            // lblIsAligned
            // 
            this.lblIsAligned.AutoSize = true;
            this.lblIsAligned.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsAligned.Location = new System.Drawing.Point(315, 75);
            this.lblIsAligned.Name = "lblIsAligned";
            this.lblIsAligned.Size = new System.Drawing.Size(48, 14);
            this.lblIsAligned.TabIndex = 16;
            this.lblIsAligned.Text = "label7";
            // 
            // txtAgentName
            // 
            this.txtAgentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgentName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgentName.Location = new System.Drawing.Point(76, 83);
            this.txtAgentName.Name = "txtAgentName";
            this.txtAgentName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAgentName.Size = new System.Drawing.Size(205, 23);
            this.txtAgentName.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label2.Location = new System.Drawing.Point(10, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Agent";
            // 
            // lblMsgFull
            // 
            this.lblMsgFull.AutoSize = true;
            this.lblMsgFull.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.lblMsgFull.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgFull.ForeColor = System.Drawing.Color.Blue;
            this.lblMsgFull.Location = new System.Drawing.Point(9, 120);
            this.lblMsgFull.Name = "lblMsgFull";
            this.lblMsgFull.Size = new System.Drawing.Size(56, 16);
            this.lblMsgFull.TabIndex = 12;
            this.lblMsgFull.Text = "MsgFull";
            // 
            // txtQuantityReceived
            // 
            this.txtQuantityReceived.BackColor = System.Drawing.SystemColors.Window;
            this.txtQuantityReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantityReceived.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantityReceived.Location = new System.Drawing.Point(707, 83);
            this.txtQuantityReceived.Name = "txtQuantityReceived";
            this.txtQuantityReceived.Size = new System.Drawing.Size(113, 23);
            this.txtQuantityReceived.TabIndex = 11;
            this.txtQuantityReceived.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantityReceived_KeyPress);
            // 
            // lblRMTransactionQuantityReceived
            // 
            this.lblRMTransactionQuantityReceived.AutoSize = true;
            this.lblRMTransactionQuantityReceived.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionQuantityReceived.Location = new System.Drawing.Point(571, 86);
            this.lblRMTransactionQuantityReceived.Name = "lblRMTransactionQuantityReceived";
            this.lblRMTransactionQuantityReceived.Size = new System.Drawing.Size(129, 16);
            this.lblRMTransactionQuantityReceived.TabIndex = 10;
            this.lblRMTransactionQuantityReceived.Text = "Quantity Received";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(76, 47);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(205, 24);
            this.cmbSupplier.TabIndex = 5;
            this.cmbSupplier.SelectionChangeCommitted += new System.EventHandler(this.cmbSupplier_SelectionChangeCommitted);
            // 
            // lblRMSamplingSupplierName
            // 
            this.lblRMSamplingSupplierName.AutoSize = true;
            this.lblRMSamplingSupplierName.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMSamplingSupplierName.Location = new System.Drawing.Point(10, 51);
            this.lblRMSamplingSupplierName.Name = "lblRMSamplingSupplierName";
            this.lblRMSamplingSupplierName.Size = new System.Drawing.Size(60, 16);
            this.lblRMSamplingSupplierName.TabIndex = 4;
            this.lblRMSamplingSupplierName.Text = "Supplier";
            // 
            // txtPlantLotNo
            // 
            this.txtPlantLotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlantLotNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlantLotNo.Location = new System.Drawing.Point(414, 48);
            this.txtPlantLotNo.Name = "txtPlantLotNo";
            this.txtPlantLotNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPlantLotNo.Size = new System.Drawing.Size(156, 23);
            this.txtPlantLotNo.TabIndex = 7;
            this.txtPlantLotNo.Leave += new System.EventHandler(this.txtPlantLotNo_Leave);
            // 
            // lblRMSamplingLotNo
            // 
            this.lblRMSamplingLotNo.AutoSize = true;
            this.lblRMSamplingLotNo.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMSamplingLotNo.Location = new System.Drawing.Point(327, 51);
            this.lblRMSamplingLotNo.Name = "lblRMSamplingLotNo";
            this.lblRMSamplingLotNo.Size = new System.Drawing.Size(83, 16);
            this.lblRMSamplingLotNo.TabIndex = 6;
            this.lblRMSamplingLotNo.Text = "Lot Number";
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
            this.cmbTypeOfControl.Location = new System.Drawing.Point(707, 47);
            this.cmbTypeOfControl.Name = "cmbTypeOfControl";
            this.cmbTypeOfControl.Size = new System.Drawing.Size(154, 24);
            this.cmbTypeOfControl.TabIndex = 9;
            this.cmbTypeOfControl.SelectionChangeCommitted += new System.EventHandler(this.cmbTypeOfControl_SelectionChangeCommitted);
            this.cmbTypeOfControl.Leave += new System.EventHandler(this.cmbTypeOfControl_Leave);
            // 
            // dtpInspDate
            // 
            this.dtpInspDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpInspDate.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpInspDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpInspDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInspDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInspDate.Location = new System.Drawing.Point(708, 14);
            this.dtpInspDate.Name = "dtpInspDate";
            this.dtpInspDate.Size = new System.Drawing.Size(154, 23);
            this.dtpInspDate.TabIndex = 3;
            this.dtpInspDate.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            // 
            // lblRMTransactionTypeOfControl
            // 
            this.lblRMTransactionTypeOfControl.AutoSize = true;
            this.lblRMTransactionTypeOfControl.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionTypeOfControl.Location = new System.Drawing.Point(591, 51);
            this.lblRMTransactionTypeOfControl.Name = "lblRMTransactionTypeOfControl";
            this.lblRMTransactionTypeOfControl.Size = new System.Drawing.Size(112, 16);
            this.lblRMTransactionTypeOfControl.TabIndex = 8;
            this.lblRMTransactionTypeOfControl.Text = "Type Of Control";
            // 
            // lblRMTransactionInspDate
            // 
            this.lblRMTransactionInspDate.AutoSize = true;
            this.lblRMTransactionInspDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionInspDate.Location = new System.Drawing.Point(632, 17);
            this.lblRMTransactionInspDate.Name = "lblRMTransactionInspDate";
            this.lblRMTransactionInspDate.Size = new System.Drawing.Size(72, 16);
            this.lblRMTransactionInspDate.TabIndex = 2;
            this.lblRMTransactionInspDate.Text = "Insp Date";
            // 
            // cmbRMCode
            // 
            this.cmbRMCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbRMCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRMCode.FormattingEnabled = true;
            this.cmbRMCode.Items.AddRange(new object[] {
            "select"});
            this.cmbRMCode.Location = new System.Drawing.Point(305, 13);
            this.cmbRMCode.Name = "cmbRMCode";
            this.cmbRMCode.Size = new System.Drawing.Size(265, 24);
            this.cmbRMCode.TabIndex = 1;
            this.cmbRMCode.SelectionChangeCommitted += new System.EventHandler(this.cmbRMCode_SelectionChangeCommitted);
            // 
            // lblRMTransactionDetails
            // 
            this.lblRMTransactionDetails.AutoSize = true;
            this.lblRMTransactionDetails.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionDetails.Location = new System.Drawing.Point(234, 17);
            this.lblRMTransactionDetails.Name = "lblRMTransactionDetails";
            this.lblRMTransactionDetails.Size = new System.Drawing.Size(65, 16);
            this.lblRMTransactionDetails.TabIndex = 0;
            this.lblRMTransactionDetails.Text = "RM Code";
            // 
            // dtpAcceptedDate
            // 
            this.dtpAcceptedDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpAcceptedDate.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpAcceptedDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpAcceptedDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAcceptedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAcceptedDate.Location = new System.Drawing.Point(416, 132);
            this.dtpAcceptedDate.Name = "dtpAcceptedDate";
            this.dtpAcceptedDate.Size = new System.Drawing.Size(154, 23);
            this.dtpAcceptedDate.TabIndex = 16;
            this.dtpAcceptedDate.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(305, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Accepted Date";
            // 
            // gbManualFields
            // 
            this.gbManualFields.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbManualFields.Controls.Add(this.dtpAcceptedDate);
            this.gbManualFields.Controls.Add(this.cmbLocation);
            this.gbManualFields.Controls.Add(this.label3);
            this.gbManualFields.Controls.Add(this.dtpManufacturingDate);
            this.gbManualFields.Controls.Add(this.dtpDateOfValidity);
            this.gbManualFields.Controls.Add(this.cmbFirstRMReception);
            this.gbManualFields.Controls.Add(this.dtpDisposalDate);
            this.gbManualFields.Controls.Add(this.dtpReceiptDate);
            this.gbManualFields.Controls.Add(this.cmbSupplierReportReceived);
            this.gbManualFields.Controls.Add(this.label6);
            this.gbManualFields.Controls.Add(this.cmbConfirmation);
            this.gbManualFields.Controls.Add(this.lblRMTransactionDateofValidity);
            this.gbManualFields.Controls.Add(this.txtChallanNo);
            this.gbManualFields.Controls.Add(this.lblRMTransactionChallanNo);
            this.gbManualFields.Controls.Add(this.label4);
            this.gbManualFields.Controls.Add(this.lblRMTransactionFirstRMReception);
            this.gbManualFields.Controls.Add(this.lblRMTransactionReceived);
            this.gbManualFields.Controls.Add(this.lblRMTransactionConfirmation);
            this.gbManualFields.Controls.Add(this.txtSupplierLotNo);
            this.gbManualFields.Controls.Add(this.lblRMTransactionSupplierLotNo);
            this.gbManualFields.Controls.Add(this.txtMRR);
            this.gbManualFields.Controls.Add(this.lblRMTransactionMRR);
            this.gbManualFields.Controls.Add(this.label5);
            this.gbManualFields.Controls.Add(this.lblRMTransactionReceiptDate);
            this.gbManualFields.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbManualFields.Location = new System.Drawing.Point(25, 255);
            this.gbManualFields.Name = "gbManualFields";
            this.gbManualFields.Size = new System.Drawing.Size(872, 169);
            this.gbManualFields.TabIndex = 3;
            this.gbManualFields.TabStop = false;
            this.gbManualFields.Text = "Details";
            // 
            // cmbLocation
            // 
            this.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(709, 93);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(154, 24);
            this.cmbLocation.TabIndex = 16;
            // 
            // dtpManufacturingDate
            // 
            this.dtpManufacturingDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpManufacturingDate.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpManufacturingDate.CustomFormat = " ";
            this.dtpManufacturingDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpManufacturingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpManufacturingDate.Location = new System.Drawing.Point(709, 132);
            this.dtpManufacturingDate.Name = "dtpManufacturingDate";
            this.dtpManufacturingDate.Size = new System.Drawing.Size(154, 23);
            this.dtpManufacturingDate.TabIndex = 5;
            this.dtpManufacturingDate.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            this.dtpManufacturingDate.ValueChanged += new System.EventHandler(this.dtpManufacturingDate_ValueChanged);
            // 
            // dtpDateOfValidity
            // 
            this.dtpDateOfValidity.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDateOfValidity.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpDateOfValidity.CustomFormat = "dd-MMM-yyyy";
            this.dtpDateOfValidity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfValidity.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfValidity.Location = new System.Drawing.Point(709, 15);
            this.dtpDateOfValidity.Name = "dtpDateOfValidity";
            this.dtpDateOfValidity.Size = new System.Drawing.Size(154, 23);
            this.dtpDateOfValidity.TabIndex = 5;
            this.dtpDateOfValidity.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            // 
            // cmbFirstRMReception
            // 
            this.cmbFirstRMReception.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbFirstRMReception.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFirstRMReception.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFirstRMReception.FormattingEnabled = true;
            this.cmbFirstRMReception.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbFirstRMReception.Location = new System.Drawing.Point(709, 52);
            this.cmbFirstRMReception.Name = "cmbFirstRMReception";
            this.cmbFirstRMReception.Size = new System.Drawing.Size(154, 24);
            this.cmbFirstRMReception.TabIndex = 11;
            // 
            // dtpDisposalDate
            // 
            this.dtpDisposalDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpDisposalDate.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpDisposalDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDisposalDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDisposalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDisposalDate.Location = new System.Drawing.Point(128, 132);
            this.dtpDisposalDate.Name = "dtpDisposalDate";
            this.dtpDisposalDate.Size = new System.Drawing.Size(154, 23);
            this.dtpDisposalDate.TabIndex = 1;
            this.dtpDisposalDate.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            // 
            // dtpReceiptDate
            // 
            this.dtpReceiptDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpReceiptDate.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpReceiptDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpReceiptDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceiptDate.Location = new System.Drawing.Point(128, 15);
            this.dtpReceiptDate.Name = "dtpReceiptDate";
            this.dtpReceiptDate.Size = new System.Drawing.Size(154, 23);
            this.dtpReceiptDate.TabIndex = 1;
            this.dtpReceiptDate.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            this.dtpReceiptDate.ValueChanged += new System.EventHandler(this.dtpReceiptDate_ValueChanged);
            // 
            // cmbSupplierReportReceived
            // 
            this.cmbSupplierReportReceived.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbSupplierReportReceived.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplierReportReceived.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplierReportReceived.FormattingEnabled = true;
            this.cmbSupplierReportReceived.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbSupplierReportReceived.Location = new System.Drawing.Point(415, 93);
            this.cmbSupplierReportReceived.Name = "cmbSupplierReportReceived";
            this.cmbSupplierReportReceived.Size = new System.Drawing.Size(154, 24);
            this.cmbSupplierReportReceived.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(610, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Date Of Mfg";
            // 
            // cmbConfirmation
            // 
            this.cmbConfirmation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbConfirmation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConfirmation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConfirmation.FormattingEnabled = true;
            this.cmbConfirmation.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbConfirmation.Location = new System.Drawing.Point(415, 52);
            this.cmbConfirmation.Name = "cmbConfirmation";
            this.cmbConfirmation.Size = new System.Drawing.Size(154, 24);
            this.cmbConfirmation.TabIndex = 9;
            // 
            // lblRMTransactionDateofValidity
            // 
            this.lblRMTransactionDateofValidity.AutoSize = true;
            this.lblRMTransactionDateofValidity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionDateofValidity.Location = new System.Drawing.Point(588, 17);
            this.lblRMTransactionDateofValidity.Name = "lblRMTransactionDateofValidity";
            this.lblRMTransactionDateofValidity.Size = new System.Drawing.Size(111, 16);
            this.lblRMTransactionDateofValidity.TabIndex = 4;
            this.lblRMTransactionDateofValidity.Text = "Date Of Validity";
            // 
            // txtChallanNo
            // 
            this.txtChallanNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtChallanNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChallanNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChallanNo.Location = new System.Drawing.Point(128, 94);
            this.txtChallanNo.MaxLength = 100;
            this.txtChallanNo.Name = "txtChallanNo";
            this.txtChallanNo.Size = new System.Drawing.Size(154, 23);
            this.txtChallanNo.TabIndex = 13;
            // 
            // lblRMTransactionChallanNo
            // 
            this.lblRMTransactionChallanNo.AutoSize = true;
            this.lblRMTransactionChallanNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionChallanNo.Location = new System.Drawing.Point(31, 97);
            this.lblRMTransactionChallanNo.Name = "lblRMTransactionChallanNo";
            this.lblRMTransactionChallanNo.Size = new System.Drawing.Size(77, 16);
            this.lblRMTransactionChallanNo.TabIndex = 12;
            this.lblRMTransactionChallanNo.Text = "Challan No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(583, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Retainer Location";
            // 
            // lblRMTransactionFirstRMReception
            // 
            this.lblRMTransactionFirstRMReception.AutoSize = true;
            this.lblRMTransactionFirstRMReception.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionFirstRMReception.Location = new System.Drawing.Point(583, 56);
            this.lblRMTransactionFirstRMReception.Name = "lblRMTransactionFirstRMReception";
            this.lblRMTransactionFirstRMReception.Size = new System.Drawing.Size(123, 16);
            this.lblRMTransactionFirstRMReception.TabIndex = 10;
            this.lblRMTransactionFirstRMReception.Text = "1st RM Reception";
            // 
            // lblRMTransactionReceived
            // 
            this.lblRMTransactionReceived.AutoSize = true;
            this.lblRMTransactionReceived.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionReceived.Location = new System.Drawing.Point(304, 89);
            this.lblRMTransactionReceived.Name = "lblRMTransactionReceived";
            this.lblRMTransactionReceived.Size = new System.Drawing.Size(108, 32);
            this.lblRMTransactionReceived.TabIndex = 14;
            this.lblRMTransactionReceived.Text = "Supplier Report\r\nReceived\r\n";
            // 
            // lblRMTransactionConfirmation
            // 
            this.lblRMTransactionConfirmation.AutoSize = true;
            this.lblRMTransactionConfirmation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionConfirmation.Location = new System.Drawing.Point(304, 48);
            this.lblRMTransactionConfirmation.Name = "lblRMTransactionConfirmation";
            this.lblRMTransactionConfirmation.Size = new System.Drawing.Size(106, 32);
            this.lblRMTransactionConfirmation.TabIndex = 8;
            this.lblRMTransactionConfirmation.Text = "Supplier/Result\r\nConfirmation";
            // 
            // txtSupplierLotNo
            // 
            this.txtSupplierLotNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSupplierLotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierLotNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierLotNo.Location = new System.Drawing.Point(415, 15);
            this.txtSupplierLotNo.MaxLength = 100;
            this.txtSupplierLotNo.Name = "txtSupplierLotNo";
            this.txtSupplierLotNo.Size = new System.Drawing.Size(154, 23);
            this.txtSupplierLotNo.TabIndex = 3;
            // 
            // lblRMTransactionSupplierLotNo
            // 
            this.lblRMTransactionSupplierLotNo.AutoSize = true;
            this.lblRMTransactionSupplierLotNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionSupplierLotNo.Location = new System.Drawing.Point(304, 18);
            this.lblRMTransactionSupplierLotNo.Name = "lblRMTransactionSupplierLotNo";
            this.lblRMTransactionSupplierLotNo.Size = new System.Drawing.Size(108, 16);
            this.lblRMTransactionSupplierLotNo.TabIndex = 2;
            this.lblRMTransactionSupplierLotNo.Text = "Supplier Lot No";
            // 
            // txtMRR
            // 
            this.txtMRR.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMRR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRR.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMRR.Location = new System.Drawing.Point(128, 53);
            this.txtMRR.MaxLength = 100;
            this.txtMRR.Name = "txtMRR";
            this.txtMRR.Size = new System.Drawing.Size(154, 23);
            this.txtMRR.TabIndex = 7;
            // 
            // lblRMTransactionMRR
            // 
            this.lblRMTransactionMRR.AutoSize = true;
            this.lblRMTransactionMRR.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionMRR.Location = new System.Drawing.Point(31, 56);
            this.lblRMTransactionMRR.Name = "lblRMTransactionMRR";
            this.lblRMTransactionMRR.Size = new System.Drawing.Size(35, 16);
            this.lblRMTransactionMRR.TabIndex = 6;
            this.lblRMTransactionMRR.Text = "MRR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Disposal Date";
            // 
            // lblRMTransactionReceiptDate
            // 
            this.lblRMTransactionReceiptDate.AutoSize = true;
            this.lblRMTransactionReceiptDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMTransactionReceiptDate.Location = new System.Drawing.Point(31, 18);
            this.lblRMTransactionReceiptDate.Name = "lblRMTransactionReceiptDate";
            this.lblRMTransactionReceiptDate.Size = new System.Drawing.Size(93, 16);
            this.lblRMTransactionReceiptDate.TabIndex = 0;
            this.lblRMTransactionReceiptDate.Text = "Receipt Date";
            // 
            // gbRMButtons
            // 
            this.gbRMButtons.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbRMButtons.AutoSize = true;
            this.gbRMButtons.Controls.Add(this.btnDelete);
            this.gbRMButtons.Controls.Add(this.BtnRMProtocol);
            this.gbRMButtons.Controls.Add(this.BtnExit);
            this.gbRMButtons.Controls.Add(this.BtnSave);
            this.gbRMButtons.Controls.Add(this.BtnReset);
            this.gbRMButtons.Location = new System.Drawing.Point(25, 637);
            this.gbRMButtons.Name = "gbRMButtons";
            this.gbRMButtons.Size = new System.Drawing.Size(857, 67);
            this.gbRMButtons.TabIndex = 7;
            this.gbRMButtons.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.Location = new System.Drawing.Point(235, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 28);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // BtnRMProtocol
            // 
            this.BtnRMProtocol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMProtocol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMProtocol.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRMProtocol.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMProtocol.Location = new System.Drawing.Point(525, 20);
            this.BtnRMProtocol.Name = "BtnRMProtocol";
            this.BtnRMProtocol.Size = new System.Drawing.Size(112, 28);
            this.BtnRMProtocol.TabIndex = 2;
            this.BtnRMProtocol.Text = "&Protocol";
            this.BtnRMProtocol.UseVisualStyleBackColor = false;
            this.BtnRMProtocol.Click += new System.EventHandler(this.BtnRMProtocol_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(670, 20);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(112, 28);
            this.BtnExit.TabIndex = 3;
            this.BtnExit.Text = "&Exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(380, 20);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(112, 28);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(90, 20);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(112, 28);
            this.BtnReset.TabIndex = 0;
            this.BtnReset.Text = "&Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // gbRMTransactionStatus
            // 
            this.gbRMTransactionStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbRMTransactionStatus.Controls.Add(this.txtRejectDescription);
            this.gbRMTransactionStatus.Controls.Add(this.lblReject);
            this.gbRMTransactionStatus.Controls.Add(this.RdoHold);
            this.gbRMTransactionStatus.Controls.Add(this.RdoSentToSupplier);
            this.gbRMTransactionStatus.Controls.Add(this.RdoAWD);
            this.gbRMTransactionStatus.Controls.Add(this.RdoReject);
            this.gbRMTransactionStatus.Controls.Add(this.RdoAccept);
            this.gbRMTransactionStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRMTransactionStatus.Location = new System.Drawing.Point(25, 548);
            this.gbRMTransactionStatus.Name = "gbRMTransactionStatus";
            this.gbRMTransactionStatus.Size = new System.Drawing.Size(872, 85);
            this.gbRMTransactionStatus.TabIndex = 5;
            this.gbRMTransactionStatus.TabStop = false;
            this.gbRMTransactionStatus.Text = "Status";
            // 
            // txtRejectDescription
            // 
            this.txtRejectDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRejectDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRejectDescription.Location = new System.Drawing.Point(348, 42);
            this.txtRejectDescription.Multiline = true;
            this.txtRejectDescription.Name = "txtRejectDescription";
            this.txtRejectDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRejectDescription.Size = new System.Drawing.Size(318, 37);
            this.txtRejectDescription.TabIndex = 9;
            this.txtRejectDescription.Visible = false;
            // 
            // lblReject
            // 
            this.lblReject.AutoSize = true;
            this.lblReject.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblReject.Location = new System.Drawing.Point(206, 45);
            this.lblReject.Name = "lblReject";
            this.lblReject.Size = new System.Drawing.Size(143, 16);
            this.lblReject.TabIndex = 8;
            this.lblReject.Text = "Regect Description :";
            this.lblReject.Visible = false;
            // 
            // RdoHold
            // 
            this.RdoHold.AutoSize = true;
            this.RdoHold.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoHold.Location = new System.Drawing.Point(672, 16);
            this.RdoHold.Name = "RdoHold";
            this.RdoHold.Size = new System.Drawing.Size(54, 20);
            this.RdoHold.TabIndex = 4;
            this.RdoHold.Text = "Hold";
            this.RdoHold.UseVisualStyleBackColor = true;
            // 
            // RdoSentToSupplier
            // 
            this.RdoSentToSupplier.AutoSize = true;
            this.RdoSentToSupplier.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoSentToSupplier.Location = new System.Drawing.Point(461, 16);
            this.RdoSentToSupplier.Name = "RdoSentToSupplier";
            this.RdoSentToSupplier.Size = new System.Drawing.Size(171, 20);
            this.RdoSentToSupplier.TabIndex = 3;
            this.RdoSentToSupplier.Text = "Sent Back To Supplier";
            this.RdoSentToSupplier.UseVisualStyleBackColor = true;
            // 
            // RdoAWD
            // 
            this.RdoAWD.AutoSize = true;
            this.RdoAWD.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoAWD.Location = new System.Drawing.Point(365, 16);
            this.RdoAWD.Name = "RdoAWD";
            this.RdoAWD.Size = new System.Drawing.Size(57, 20);
            this.RdoAWD.TabIndex = 2;
            this.RdoAWD.Text = "AWD";
            this.RdoAWD.UseVisualStyleBackColor = true;
            // 
            // RdoReject
            // 
            this.RdoReject.AutoSize = true;
            this.RdoReject.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoReject.Location = new System.Drawing.Point(258, 16);
            this.RdoReject.Name = "RdoReject";
            this.RdoReject.Size = new System.Drawing.Size(68, 20);
            this.RdoReject.TabIndex = 1;
            this.RdoReject.Text = "Reject";
            this.RdoReject.UseVisualStyleBackColor = true;
            this.RdoReject.CheckedChanged += new System.EventHandler(this.RdoReject_CheckedChanged);
            // 
            // RdoAccept
            // 
            this.RdoAccept.AutoSize = true;
            this.RdoAccept.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoAccept.Location = new System.Drawing.Point(146, 16);
            this.RdoAccept.Name = "RdoAccept";
            this.RdoAccept.Size = new System.Drawing.Size(73, 20);
            this.RdoAccept.TabIndex = 0;
            this.RdoAccept.Text = "Accept";
            this.RdoAccept.UseVisualStyleBackColor = true;
            // 
            // gbRMTransactionLabelForRetainer
            // 
            this.gbRMTransactionLabelForRetainer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbRMTransactionLabelForRetainer.Controls.Add(this.btnPrintValidity);
            this.gbRMTransactionLabelForRetainer.Controls.Add(this.chkSubcontract);
            this.gbRMTransactionLabelForRetainer.Controls.Add(this.labelMicro);
            this.gbRMTransactionLabelForRetainer.Controls.Add(this.RdoNegative);
            this.gbRMTransactionLabelForRetainer.Controls.Add(this.RdoPositive);
            this.gbRMTransactionLabelForRetainer.Controls.Add(this.btnPrint);
            this.gbRMTransactionLabelForRetainer.Controls.Add(this.chkLabelForRetainer);
            this.gbRMTransactionLabelForRetainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRMTransactionLabelForRetainer.Location = new System.Drawing.Point(25, 505);
            this.gbRMTransactionLabelForRetainer.Name = "gbRMTransactionLabelForRetainer";
            this.gbRMTransactionLabelForRetainer.Size = new System.Drawing.Size(872, 43);
            this.gbRMTransactionLabelForRetainer.TabIndex = 6;
            this.gbRMTransactionLabelForRetainer.TabStop = false;
            // 
            // btnPrintValidity
            // 
            this.btnPrintValidity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPrintValidity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintValidity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintValidity.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrintValidity.Location = new System.Drawing.Point(553, 14);
            this.btnPrintValidity.Name = "btnPrintValidity";
            this.btnPrintValidity.Size = new System.Drawing.Size(150, 24);
            this.btnPrintValidity.TabIndex = 15;
            this.btnPrintValidity.Text = "Print Validity Label";
            this.btnPrintValidity.UseVisualStyleBackColor = false;
            this.btnPrintValidity.Click += new System.EventHandler(this.btnPrintValidity_Click);
            // 
            // chkSubcontract
            // 
            this.chkSubcontract.AutoSize = true;
            this.chkSubcontract.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSubcontract.Location = new System.Drawing.Point(265, 17);
            this.chkSubcontract.Name = "chkSubcontract";
            this.chkSubcontract.Size = new System.Drawing.Size(104, 18);
            this.chkSubcontract.TabIndex = 14;
            this.chkSubcontract.Text = "SubContract";
            this.chkSubcontract.UseVisualStyleBackColor = true;
            // 
            // labelMicro
            // 
            this.labelMicro.AutoSize = true;
            this.labelMicro.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMicro.Location = new System.Drawing.Point(15, 17);
            this.labelMicro.Name = "labelMicro";
            this.labelMicro.Size = new System.Drawing.Size(92, 16);
            this.labelMicro.TabIndex = 13;
            this.labelMicro.Text = "Micro Status";
            this.labelMicro.Visible = false;
            // 
            // RdoNegative
            // 
            this.RdoNegative.AutoSize = true;
            this.RdoNegative.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoNegative.Location = new System.Drawing.Point(180, 15);
            this.RdoNegative.Name = "RdoNegative";
            this.RdoNegative.Size = new System.Drawing.Size(49, 20);
            this.RdoNegative.TabIndex = 3;
            this.RdoNegative.Text = "-ve";
            this.RdoNegative.UseVisualStyleBackColor = true;
            this.RdoNegative.Visible = false;
            // 
            // RdoPositive
            // 
            this.RdoPositive.AutoSize = true;
            this.RdoPositive.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoPositive.Location = new System.Drawing.Point(124, 15);
            this.RdoPositive.Name = "RdoPositive";
            this.RdoPositive.Size = new System.Drawing.Size(51, 20);
            this.RdoPositive.TabIndex = 2;
            this.RdoPositive.Text = "+ve";
            this.RdoPositive.UseVisualStyleBackColor = true;
            this.RdoPositive.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrint.Location = new System.Drawing.Point(708, 13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(152, 24);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print Retainer Label";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // chkLabelForRetainer
            // 
            this.chkLabelForRetainer.AutoSize = true;
            this.chkLabelForRetainer.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLabelForRetainer.Location = new System.Drawing.Point(386, 15);
            this.chkLabelForRetainer.Name = "chkLabelForRetainer";
            this.chkLabelForRetainer.Size = new System.Drawing.Size(146, 20);
            this.chkLabelForRetainer.TabIndex = 0;
            this.chkLabelForRetainer.Text = "Label For Retainer";
            this.chkLabelForRetainer.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox5.Controls.Add(this.dgTest);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(25, 426);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(872, 80);
            this.groupBox5.TabIndex = 4;
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
            this.dgTest.Location = new System.Drawing.Point(172, 12);
            this.dgTest.MultiSelect = false;
            this.dgTest.Name = "dgTest";
            this.dgTest.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgTest.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgTest.Size = new System.Drawing.Size(528, 62);
            this.dgTest.TabIndex = 0;
            this.dgTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTest_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.lblMsgSampling);
            this.groupBox1.Controls.Add(this.txtNoOfSegments);
            this.groupBox1.Controls.Add(this.lblRMSamplingNoOfSegments);
            this.groupBox1.Controls.Add(this.lblRMSamplingActualNoSegments);
            this.groupBox1.Controls.Add(this.txtActualNoSegments);
            this.groupBox1.Controls.Add(this.txtQuantitySampled);
            this.groupBox1.Controls.Add(this.lblRMSamplingQantityToComplete);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 72);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sampling";
            // 
            // lblMsgSampling
            // 
            this.lblMsgSampling.AutoSize = true;
            this.lblMsgSampling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.lblMsgSampling.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgSampling.ForeColor = System.Drawing.Color.Blue;
            this.lblMsgSampling.Location = new System.Drawing.Point(131, 50);
            this.lblMsgSampling.Name = "lblMsgSampling";
            this.lblMsgSampling.Size = new System.Drawing.Size(92, 16);
            this.lblMsgSampling.TabIndex = 6;
            this.lblMsgSampling.Text = "MsgSampling";
            this.lblMsgSampling.Visible = false;
            // 
            // txtNoOfSegments
            // 
            this.txtNoOfSegments.BackColor = System.Drawing.SystemColors.Control;
            this.txtNoOfSegments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfSegments.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfSegments.Location = new System.Drawing.Point(709, 17);
            this.txtNoOfSegments.Name = "txtNoOfSegments";
            this.txtNoOfSegments.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNoOfSegments.Size = new System.Drawing.Size(154, 23);
            this.txtNoOfSegments.TabIndex = 4;
            this.txtNoOfSegments.TabStop = false;
            this.txtNoOfSegments.TextChanged += new System.EventHandler(this.txtNoOfSegments_TextChanged);
            this.txtNoOfSegments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoOfSegments_KeyPress);
            // 
            // lblRMSamplingNoOfSegments
            // 
            this.lblRMSamplingNoOfSegments.AutoSize = true;
            this.lblRMSamplingNoOfSegments.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMSamplingNoOfSegments.Location = new System.Drawing.Point(583, 20);
            this.lblRMSamplingNoOfSegments.Name = "lblRMSamplingNoOfSegments";
            this.lblRMSamplingNoOfSegments.Size = new System.Drawing.Size(115, 16);
            this.lblRMSamplingNoOfSegments.TabIndex = 4;
            this.lblRMSamplingNoOfSegments.Text = "No Of Segments";
            // 
            // lblRMSamplingActualNoSegments
            // 
            this.lblRMSamplingActualNoSegments.AutoSize = true;
            this.lblRMSamplingActualNoSegments.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMSamplingActualNoSegments.Location = new System.Drawing.Point(291, 20);
            this.lblRMSamplingActualNoSegments.Name = "lblRMSamplingActualNoSegments";
            this.lblRMSamplingActualNoSegments.Size = new System.Drawing.Size(120, 16);
            this.lblRMSamplingActualNoSegments.TabIndex = 2;
            this.lblRMSamplingActualNoSegments.Text = "Actual Segments";
            // 
            // txtActualNoSegments
            // 
            this.txtActualNoSegments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActualNoSegments.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActualNoSegments.Location = new System.Drawing.Point(415, 17);
            this.txtActualNoSegments.Name = "txtActualNoSegments";
            this.txtActualNoSegments.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtActualNoSegments.Size = new System.Drawing.Size(154, 23);
            this.txtActualNoSegments.TabIndex = 3;
            this.txtActualNoSegments.Leave += new System.EventHandler(this.txtActualNoSegments_Leave);
            this.txtActualNoSegments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActualNoSegments_KeyPress);
            // 
            // txtQuantitySampled
            // 
            this.txtQuantitySampled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantitySampled.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantitySampled.Location = new System.Drawing.Point(128, 17);
            this.txtQuantitySampled.Name = "txtQuantitySampled";
            this.txtQuantitySampled.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtQuantitySampled.Size = new System.Drawing.Size(154, 23);
            this.txtQuantitySampled.TabIndex = 1;
            this.txtQuantitySampled.Leave += new System.EventHandler(this.txtQuantitySampled_Leave);
            this.txtQuantitySampled.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantitySampled_KeyPress);
            // 
            // lblRMSamplingQantityToComplete
            // 
            this.lblRMSamplingQantityToComplete.AutoSize = true;
            this.lblRMSamplingQantityToComplete.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMSamplingQantityToComplete.Location = new System.Drawing.Point(2, 20);
            this.lblRMSamplingQantityToComplete.Name = "lblRMSamplingQantityToComplete";
            this.lblRMSamplingQantityToComplete.Size = new System.Drawing.Size(125, 16);
            this.lblRMSamplingQantityToComplete.TabIndex = 0;
            this.lblRMSamplingQantityToComplete.Text = "Quantity Sampled";
            // 
            // txtProtocolNo
            // 
            this.txtProtocolNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtProtocolNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProtocolNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProtocolNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProtocolNo.Location = new System.Drawing.Point(725, 9);
            this.txtProtocolNo.Name = "txtProtocolNo";
            this.txtProtocolNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProtocolNo.Size = new System.Drawing.Size(172, 23);
            this.txtProtocolNo.TabIndex = 9;
            this.txtProtocolNo.Leave += new System.EventHandler(this.txtProtocolNo_Leave);
            this.txtProtocolNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProtocolNo_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(630, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Protocol No";
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(925, 749);
            this.panelOuter.TabIndex = 10;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(923, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(923, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(97, 27);
            this.toolStripLabel1.Text = "RM Transaction";
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
            this.panelBottom.Location = new System.Drawing.Point(0, 36);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(923, 712);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.txtProtocolNo);
            this.panelFill.Controls.Add(this.label1);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Controls.Add(this.groupBox5);
            this.panelFill.Controls.Add(this.gbRMSamplingFields);
            this.panelFill.Controls.Add(this.gbRMTransactionLabelForRetainer);
            this.panelFill.Controls.Add(this.gbRMTransactionStatus);
            this.panelFill.Controls.Add(this.gbRMButtons);
            this.panelFill.Controls.Add(this.gbManualFields);
            this.panelFill.Location = new System.Drawing.Point(0, -5);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(923, 719);
            this.panelFill.TabIndex = 18;
            // 
            // lblTradeName
            // 
            this.lblTradeName.AutoSize = true;
            this.lblTradeName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTradeName.ForeColor = System.Drawing.Color.Red;
            this.lblTradeName.Location = new System.Drawing.Point(600, 122);
            this.lblTradeName.Name = "lblTradeName";
            this.lblTradeName.Size = new System.Drawing.Size(0, 14);
            this.lblTradeName.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(502, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 14);
            this.label9.TabIndex = 24;
            this.label9.Text = "Trade Name :";
            // 
            // FrmRMTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(925, 695);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(925, 741);
            this.Controls.Add(this.panelOuter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRMTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RM Transaction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRMTransaction_Load);
            this.gbRMSamplingFields.ResumeLayout(false);
            this.gbRMSamplingFields.PerformLayout();
            this.gbManualFields.ResumeLayout(false);
            this.gbManualFields.PerformLayout();
            this.gbRMButtons.ResumeLayout(false);
            this.gbRMTransactionStatus.ResumeLayout(false);
            this.gbRMTransactionStatus.PerformLayout();
            this.gbRMTransactionLabelForRetainer.ResumeLayout(false);
            this.gbRMTransactionLabelForRetainer.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTest)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelFill.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRMSamplingFields;
        private System.Windows.Forms.Label lblRMTransactionQuantityReceived;
        private System.Windows.Forms.Label lblRMTransactionDetails;
        private System.Windows.Forms.ComboBox cmbRMCode;
        private System.Windows.Forms.TextBox txtQuantityReceived;
        private System.Windows.Forms.GroupBox gbManualFields;
        private System.Windows.Forms.Label lblRMTransactionFirstRMReception;
        private System.Windows.Forms.Label lblRMTransactionReceived;
        private System.Windows.Forms.Label lblRMTransactionConfirmation;
        private System.Windows.Forms.TextBox txtSupplierLotNo;
        private System.Windows.Forms.Label lblRMTransactionSupplierLotNo;
        private System.Windows.Forms.TextBox txtMRR;
        private System.Windows.Forms.Label lblRMTransactionMRR;
        private System.Windows.Forms.Label lblRMTransactionReceiptDate;
        private System.Windows.Forms.Label lblRMTransactionDateofValidity;
        private System.Windows.Forms.TextBox txtChallanNo;
        private System.Windows.Forms.Label lblRMTransactionChallanNo;
        private System.Windows.Forms.ComboBox cmbConfirmation;
        private System.Windows.Forms.ComboBox cmbSupplierReportReceived;
        private System.Windows.Forms.Label lblRMTransactionInspDate;
        private System.Windows.Forms.DateTimePicker dtpReceiptDate;
        private System.Windows.Forms.DateTimePicker dtpInspDate;
        private System.Windows.Forms.ComboBox cmbFirstRMReception;
        private System.Windows.Forms.DateTimePicker dtpDateOfValidity;
        private System.Windows.Forms.GroupBox gbRMButtons;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.GroupBox gbRMTransactionStatus;
        private System.Windows.Forms.RadioButton RdoAWD;
        private System.Windows.Forms.RadioButton RdoReject;
        private System.Windows.Forms.RadioButton RdoAccept;
        private System.Windows.Forms.RadioButton RdoSentToSupplier;
        private System.Windows.Forms.GroupBox gbRMTransactionLabelForRetainer;
        private System.Windows.Forms.CheckBox chkLabelForRetainer;
        private System.Windows.Forms.Label lblRMTransactionTypeOfControl;
        private System.Windows.Forms.ComboBox cmbTypeOfControl;
        private System.Windows.Forms.Button BtnRMProtocol;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.DataGridView dgTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lblRMSamplingSupplierName;
        private System.Windows.Forms.TextBox txtPlantLotNo;
        private System.Windows.Forms.Label lblRMSamplingLotNo;
        private System.Windows.Forms.TextBox txtNoOfSegments;
        private System.Windows.Forms.Label lblRMSamplingNoOfSegments;
        private System.Windows.Forms.Label lblRMSamplingActualNoSegments;
        private System.Windows.Forms.TextBox txtActualNoSegments;
        private System.Windows.Forms.TextBox txtQuantitySampled;
        private System.Windows.Forms.Label lblRMSamplingQantityToComplete;
        private System.Windows.Forms.Label lblMsgSampling;
        private System.Windows.Forms.Label lblMsgFull;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtProtocolNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMicro;
        private System.Windows.Forms.RadioButton RdoNegative;
        private System.Windows.Forms.RadioButton RdoPositive;
        private System.Windows.Forms.RadioButton RdoHold;
        private System.Windows.Forms.TextBox txtAgentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpAcceptedDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDisposalDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpManufacturingDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIsAligned;
        private System.Windows.Forms.CheckBox chkSubcontract;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPrintValidity;
        private System.Windows.Forms.Label lblHalal;
        private System.Windows.Forms.Label lblplantOrigin;
        private System.Windows.Forms.Label lblForHalal;
        private System.Windows.Forms.Label lblForPlantOrigin;
        private System.Windows.Forms.Label lblForCountryofOrigin;
        private System.Windows.Forms.Label lblCountryOfOrigin;
        private System.Windows.Forms.TextBox txtRejectDescription;
        private System.Windows.Forms.Label lblReject;
        private System.Windows.Forms.Label lblTradeName;
        private System.Windows.Forms.Label label9;
    }
}