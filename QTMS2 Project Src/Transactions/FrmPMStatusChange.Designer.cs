namespace QTMS.Transactions
{
    partial class FrmPMStatusChange
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
            frmPMStatusChange_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPMStatusChange));
            this.gbRMStatusChangeSelectFields = new System.Windows.Forms.GroupBox();
            this.dtpPMStatusChangeToDate = new System.Windows.Forms.DateTimePicker();
            this.lblPMStatusChangeToDate = new System.Windows.Forms.Label();
            this.dtpPMStatusChangeFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblPMStatusChangeFromDate = new System.Windows.Forms.Label();
            this.dgRMStatusChangeFields = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPMStatusChangeQtyReceived = new System.Windows.Forms.TextBox();
            this.lblPMStatusChangeQtyReceived = new System.Windows.Forms.Label();
            this.txtPMStatusChangeChallanNo = new System.Windows.Forms.TextBox();
            this.lblPMStatusChangeChallanNo = new System.Windows.Forms.Label();
            this.cmbPMStatusChangeDetails = new System.Windows.Forms.ComboBox();
            this.lblPMStatusChangeDetails = new System.Windows.Forms.Label();
            this.gbRMStatus = new System.Windows.Forms.GroupBox();
            this.chkRejectComments = new System.Windows.Forms.CheckedListBox();
            this.RdoSendBackToSupplier = new System.Windows.Forms.RadioButton();
            this.RdoTreatment = new System.Windows.Forms.RadioButton();
            this.RdoAWD = new System.Windows.Forms.RadioButton();
            this.RdoReject = new System.Windows.Forms.RadioButton();
            this.RdoAccept = new System.Windows.Forms.RadioButton();
            this.gbRMButtons = new System.Windows.Forms.GroupBox();
            this.BtnPMStatusChangeExit = new System.Windows.Forms.Button();
            this.BtnPMStatusChangeReset = new System.Windows.Forms.Button();
            this.BtnPMStatusChangeSave = new System.Windows.Forms.Button();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDefect = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoOfDefect = new System.Windows.Forms.TextBox();
            this.cmbPMStatusChangeDefectObserved = new System.Windows.Forms.ComboBox();
            this.lblPMStatusChangeQtyDefCouples = new System.Windows.Forms.Label();
            this.txtPMStatusDefectComment = new System.Windows.Forms.TextBox();
            this.txtPMStatusChangeQtyDefSamples = new System.Windows.Forms.TextBox();
            this.lblPMStatusChangeCategoryDef = new System.Windows.Forms.Label();
            this.lblPMStatusChangeDefectObserved = new System.Windows.Forms.Label();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.gbRMStatusChangeSelectFields.SuspendLayout();
            this.dgRMStatusChangeFields.SuspendLayout();
            this.gbRMStatus.SuspendLayout();
            this.gbRMButtons.SuspendLayout();
            this.gbFields.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRMStatusChangeSelectFields
            // 
            this.gbRMStatusChangeSelectFields.Controls.Add(this.dtpPMStatusChangeToDate);
            this.gbRMStatusChangeSelectFields.Controls.Add(this.lblPMStatusChangeToDate);
            this.gbRMStatusChangeSelectFields.Controls.Add(this.dtpPMStatusChangeFromDate);
            this.gbRMStatusChangeSelectFields.Controls.Add(this.lblPMStatusChangeFromDate);
            this.gbRMStatusChangeSelectFields.Location = new System.Drawing.Point(15, 18);
            this.gbRMStatusChangeSelectFields.Name = "gbRMStatusChangeSelectFields";
            this.gbRMStatusChangeSelectFields.Size = new System.Drawing.Size(791, 63);
            this.gbRMStatusChangeSelectFields.TabIndex = 5;
            this.gbRMStatusChangeSelectFields.TabStop = false;
            // 
            // dtpPMStatusChangeToDate
            // 
            this.dtpPMStatusChangeToDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpPMStatusChangeToDate.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpPMStatusChangeToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpPMStatusChangeToDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.dtpPMStatusChangeToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPMStatusChangeToDate.Location = new System.Drawing.Point(490, 20);
            this.dtpPMStatusChangeToDate.Name = "dtpPMStatusChangeToDate";
            this.dtpPMStatusChangeToDate.Size = new System.Drawing.Size(124, 23);
            this.dtpPMStatusChangeToDate.TabIndex = 85;
            this.dtpPMStatusChangeToDate.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            this.dtpPMStatusChangeToDate.Leave += new System.EventHandler(this.dtpPMStatusChangeToDate_Leave);
            // 
            // lblPMStatusChangeToDate
            // 
            this.lblPMStatusChangeToDate.AutoSize = true;
            this.lblPMStatusChangeToDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMStatusChangeToDate.Location = new System.Drawing.Point(421, 23);
            this.lblPMStatusChangeToDate.Name = "lblPMStatusChangeToDate";
            this.lblPMStatusChangeToDate.Size = new System.Drawing.Size(66, 16);
            this.lblPMStatusChangeToDate.TabIndex = 84;
            this.lblPMStatusChangeToDate.Text = "To  Date";
            // 
            // dtpPMStatusChangeFromDate
            // 
            this.dtpPMStatusChangeFromDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpPMStatusChangeFromDate.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpPMStatusChangeFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpPMStatusChangeFromDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.dtpPMStatusChangeFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPMStatusChangeFromDate.Location = new System.Drawing.Point(257, 20);
            this.dtpPMStatusChangeFromDate.Name = "dtpPMStatusChangeFromDate";
            this.dtpPMStatusChangeFromDate.Size = new System.Drawing.Size(120, 23);
            this.dtpPMStatusChangeFromDate.TabIndex = 83;
            this.dtpPMStatusChangeFromDate.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            this.dtpPMStatusChangeFromDate.Leave += new System.EventHandler(this.dtpPMStatusChangeFromDate_Leave);
            // 
            // lblPMStatusChangeFromDate
            // 
            this.lblPMStatusChangeFromDate.AutoSize = true;
            this.lblPMStatusChangeFromDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMStatusChangeFromDate.Location = new System.Drawing.Point(178, 23);
            this.lblPMStatusChangeFromDate.Name = "lblPMStatusChangeFromDate";
            this.lblPMStatusChangeFromDate.Size = new System.Drawing.Size(76, 16);
            this.lblPMStatusChangeFromDate.TabIndex = 82;
            this.lblPMStatusChangeFromDate.Text = "From Date";
            // 
            // dgRMStatusChangeFields
            // 
            this.dgRMStatusChangeFields.Controls.Add(this.label1);
            this.dgRMStatusChangeFields.Controls.Add(this.txtPMStatusChangeQtyReceived);
            this.dgRMStatusChangeFields.Controls.Add(this.lblPMStatusChangeQtyReceived);
            this.dgRMStatusChangeFields.Controls.Add(this.txtPMStatusChangeChallanNo);
            this.dgRMStatusChangeFields.Controls.Add(this.lblPMStatusChangeChallanNo);
            this.dgRMStatusChangeFields.Controls.Add(this.cmbPMStatusChangeDetails);
            this.dgRMStatusChangeFields.Controls.Add(this.lblPMStatusChangeDetails);
            this.dgRMStatusChangeFields.Location = new System.Drawing.Point(15, 86);
            this.dgRMStatusChangeFields.Name = "dgRMStatusChangeFields";
            this.dgRMStatusChangeFields.Size = new System.Drawing.Size(791, 112);
            this.dgRMStatusChangeFields.TabIndex = 52;
            this.dgRMStatusChangeFields.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(292, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 16);
            this.label1.TabIndex = 97;
            this.label1.Text = "( PMCode - Supplier - Lot No )";
            // 
            // txtPMStatusChangeQtyReceived
            // 
            this.txtPMStatusChangeQtyReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMStatusChangeQtyReceived.Enabled = false;
            this.txtPMStatusChangeQtyReceived.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMStatusChangeQtyReceived.Location = new System.Drawing.Point(161, 72);
            this.txtPMStatusChangeQtyReceived.Name = "txtPMStatusChangeQtyReceived";
            this.txtPMStatusChangeQtyReceived.Size = new System.Drawing.Size(217, 23);
            this.txtPMStatusChangeQtyReceived.TabIndex = 96;
            // 
            // lblPMStatusChangeQtyReceived
            // 
            this.lblPMStatusChangeQtyReceived.AutoSize = true;
            this.lblPMStatusChangeQtyReceived.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMStatusChangeQtyReceived.Location = new System.Drawing.Point(28, 75);
            this.lblPMStatusChangeQtyReceived.Name = "lblPMStatusChangeQtyReceived";
            this.lblPMStatusChangeQtyReceived.Size = new System.Drawing.Size(129, 16);
            this.lblPMStatusChangeQtyReceived.TabIndex = 93;
            this.lblPMStatusChangeQtyReceived.Text = "Quantity Received";
            // 
            // txtPMStatusChangeChallanNo
            // 
            this.txtPMStatusChangeChallanNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMStatusChangeChallanNo.Enabled = false;
            this.txtPMStatusChangeChallanNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMStatusChangeChallanNo.Location = new System.Drawing.Point(559, 72);
            this.txtPMStatusChangeChallanNo.Name = "txtPMStatusChangeChallanNo";
            this.txtPMStatusChangeChallanNo.Size = new System.Drawing.Size(217, 23);
            this.txtPMStatusChangeChallanNo.TabIndex = 91;
            // 
            // lblPMStatusChangeChallanNo
            // 
            this.lblPMStatusChangeChallanNo.AutoSize = true;
            this.lblPMStatusChangeChallanNo.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMStatusChangeChallanNo.Location = new System.Drawing.Point(479, 75);
            this.lblPMStatusChangeChallanNo.Name = "lblPMStatusChangeChallanNo";
            this.lblPMStatusChangeChallanNo.Size = new System.Drawing.Size(77, 16);
            this.lblPMStatusChangeChallanNo.TabIndex = 89;
            this.lblPMStatusChangeChallanNo.Text = "Challan No";
            // 
            // cmbPMStatusChangeDetails
            // 
            this.cmbPMStatusChangeDetails.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPMStatusChangeDetails.FormattingEnabled = true;
            this.cmbPMStatusChangeDetails.Location = new System.Drawing.Point(213, 34);
            this.cmbPMStatusChangeDetails.Name = "cmbPMStatusChangeDetails";
            this.cmbPMStatusChangeDetails.Size = new System.Drawing.Size(368, 24);
            this.cmbPMStatusChangeDetails.TabIndex = 88;
            this.cmbPMStatusChangeDetails.SelectionChangeCommitted += new System.EventHandler(this.cmbPMStatusChangeDetails_SelectionChangeCommitted);
            // 
            // lblPMStatusChangeDetails
            // 
            this.lblPMStatusChangeDetails.AutoSize = true;
            this.lblPMStatusChangeDetails.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMStatusChangeDetails.Location = new System.Drawing.Point(157, 37);
            this.lblPMStatusChangeDetails.Name = "lblPMStatusChangeDetails";
            this.lblPMStatusChangeDetails.Size = new System.Drawing.Size(52, 16);
            this.lblPMStatusChangeDetails.TabIndex = 87;
            this.lblPMStatusChangeDetails.Text = "Details";
            // 
            // gbRMStatus
            // 
            this.gbRMStatus.Controls.Add(this.chkRejectComments);
            this.gbRMStatus.Controls.Add(this.RdoSendBackToSupplier);
            this.gbRMStatus.Controls.Add(this.RdoTreatment);
            this.gbRMStatus.Controls.Add(this.RdoAWD);
            this.gbRMStatus.Controls.Add(this.RdoReject);
            this.gbRMStatus.Controls.Add(this.RdoAccept);
            this.gbRMStatus.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.gbRMStatus.Location = new System.Drawing.Point(15, 352);
            this.gbRMStatus.Name = "gbRMStatus";
            this.gbRMStatus.Size = new System.Drawing.Size(791, 84);
            this.gbRMStatus.TabIndex = 53;
            this.gbRMStatus.TabStop = false;
            this.gbRMStatus.Text = "Status";
            // 
            // chkRejectComments
            // 
            this.chkRejectComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkRejectComments.FormattingEnabled = true;
            this.chkRejectComments.Items.AddRange(new object[] {
            "Blocked on Receipt",
            "Blocked on Floor",
            "COC"});
            this.chkRejectComments.Location = new System.Drawing.Point(332, 14);
            this.chkRejectComments.Name = "chkRejectComments";
            this.chkRejectComments.Size = new System.Drawing.Size(148, 56);
            this.chkRejectComments.TabIndex = 96;
            this.chkRejectComments.Visible = false;
            this.chkRejectComments.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkPMStatusChangeRejectComments_ItemCheck);
            this.chkRejectComments.Click += new System.EventHandler(this.chkPMStatusChangeRejectComments_Click);
            // 
            // RdoSendBackToSupplier
            // 
            this.RdoSendBackToSupplier.AutoSize = true;
            this.RdoSendBackToSupplier.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoSendBackToSupplier.Location = new System.Drawing.Point(72, 46);
            this.RdoSendBackToSupplier.Name = "RdoSendBackToSupplier";
            this.RdoSendBackToSupplier.Size = new System.Drawing.Size(151, 17);
            this.RdoSendBackToSupplier.TabIndex = 95;
            this.RdoSendBackToSupplier.Text = "Send BackTo Supplier";
            this.RdoSendBackToSupplier.UseVisualStyleBackColor = true;
            // 
            // RdoTreatment
            // 
            this.RdoTreatment.AutoSize = true;
            this.RdoTreatment.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoTreatment.Location = new System.Drawing.Point(638, 18);
            this.RdoTreatment.Name = "RdoTreatment";
            this.RdoTreatment.Size = new System.Drawing.Size(84, 17);
            this.RdoTreatment.TabIndex = 94;
            this.RdoTreatment.Text = "Treatment";
            this.RdoTreatment.UseVisualStyleBackColor = true;
            this.RdoTreatment.Visible = false;
            // 
            // RdoAWD
            // 
            this.RdoAWD.AutoSize = true;
            this.RdoAWD.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoAWD.Location = new System.Drawing.Point(523, 18);
            this.RdoAWD.Name = "RdoAWD";
            this.RdoAWD.Size = new System.Drawing.Size(53, 17);
            this.RdoAWD.TabIndex = 93;
            this.RdoAWD.Text = "AWD";
            this.RdoAWD.UseVisualStyleBackColor = true;
            this.RdoAWD.Visible = false;
            // 
            // RdoReject
            // 
            this.RdoReject.AutoSize = true;
            this.RdoReject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoReject.Location = new System.Drawing.Point(260, 14);
            this.RdoReject.Name = "RdoReject";
            this.RdoReject.Size = new System.Drawing.Size(61, 17);
            this.RdoReject.TabIndex = 92;
            this.RdoReject.Text = "Reject";
            this.RdoReject.UseVisualStyleBackColor = true;
            this.RdoReject.CheckedChanged += new System.EventHandler(this.RdoPMStatusReject_CheckedChanged);
            // 
            // RdoAccept
            // 
            this.RdoAccept.AutoSize = true;
            this.RdoAccept.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoAccept.Location = new System.Drawing.Point(73, 14);
            this.RdoAccept.Name = "RdoAccept";
            this.RdoAccept.Size = new System.Drawing.Size(63, 17);
            this.RdoAccept.TabIndex = 91;
            this.RdoAccept.Text = "Accept";
            this.RdoAccept.UseVisualStyleBackColor = true;
            this.RdoAccept.CheckedChanged += new System.EventHandler(this.RdoPMStatusAccept_CheckedChanged);
            // 
            // gbRMButtons
            // 
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeExit);
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeReset);
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeSave);
            this.gbRMButtons.Location = new System.Drawing.Point(15, 442);
            this.gbRMButtons.Name = "gbRMButtons";
            this.gbRMButtons.Size = new System.Drawing.Size(792, 76);
            this.gbRMButtons.TabIndex = 54;
            this.gbRMButtons.TabStop = false;
            // 
            // BtnPMStatusChangeExit
            // 
            this.BtnPMStatusChangeExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMStatusChangeExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMStatusChangeExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMStatusChangeExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMStatusChangeExit.Location = new System.Drawing.Point(557, 20);
            this.BtnPMStatusChangeExit.Name = "BtnPMStatusChangeExit";
            this.BtnPMStatusChangeExit.Size = new System.Drawing.Size(109, 35);
            this.BtnPMStatusChangeExit.TabIndex = 53;
            this.BtnPMStatusChangeExit.Text = "&Exit";
            this.BtnPMStatusChangeExit.UseVisualStyleBackColor = false;
            this.BtnPMStatusChangeExit.Click += new System.EventHandler(this.BtnPMStatusChangeExit_Click);
            // 
            // BtnPMStatusChangeReset
            // 
            this.BtnPMStatusChangeReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMStatusChangeReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMStatusChangeReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMStatusChangeReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMStatusChangeReset.Location = new System.Drawing.Point(127, 20);
            this.BtnPMStatusChangeReset.Name = "BtnPMStatusChangeReset";
            this.BtnPMStatusChangeReset.Size = new System.Drawing.Size(109, 35);
            this.BtnPMStatusChangeReset.TabIndex = 50;
            this.BtnPMStatusChangeReset.Text = "&Reset";
            this.BtnPMStatusChangeReset.UseVisualStyleBackColor = false;
            this.BtnPMStatusChangeReset.Click += new System.EventHandler(this.BtnPMStatusChangeReset_Click);
            // 
            // BtnPMStatusChangeSave
            // 
            this.BtnPMStatusChangeSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMStatusChangeSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMStatusChangeSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMStatusChangeSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMStatusChangeSave.Location = new System.Drawing.Point(342, 22);
            this.BtnPMStatusChangeSave.Name = "BtnPMStatusChangeSave";
            this.BtnPMStatusChangeSave.Size = new System.Drawing.Size(109, 35);
            this.BtnPMStatusChangeSave.TabIndex = 49;
            this.BtnPMStatusChangeSave.Text = "&Save";
            this.BtnPMStatusChangeSave.UseVisualStyleBackColor = false;
            this.BtnPMStatusChangeSave.Click += new System.EventHandler(this.BtnPMStatusChangeSave_Click);
            // 
            // gbFields
            // 
            this.gbFields.Controls.Add(this.label4);
            this.gbFields.Controls.Add(this.txtDefect);
            this.gbFields.Controls.Add(this.label5);
            this.gbFields.Controls.Add(this.txtNoOfDefect);
            this.gbFields.Controls.Add(this.cmbPMStatusChangeDefectObserved);
            this.gbFields.Controls.Add(this.lblPMStatusChangeQtyDefCouples);
            this.gbFields.Controls.Add(this.txtPMStatusDefectComment);
            this.gbFields.Controls.Add(this.txtPMStatusChangeQtyDefSamples);
            this.gbFields.Controls.Add(this.lblPMStatusChangeCategoryDef);
            this.gbFields.Controls.Add(this.lblPMStatusChangeDefectObserved);
            this.gbFields.Location = new System.Drawing.Point(15, 202);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(791, 144);
            this.gbFields.TabIndex = 55;
            this.gbFields.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(497, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 136;
            this.label4.Text = "Defect";
            // 
            // txtDefect
            // 
            this.txtDefect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDefect.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefect.Location = new System.Drawing.Point(555, 97);
            this.txtDefect.Name = "txtDefect";
            this.txtDefect.Size = new System.Drawing.Size(174, 23);
            this.txtDefect.TabIndex = 135;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(61, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 134;
            this.label5.Text = "No of Defect";
            // 
            // txtNoOfDefect
            // 
            this.txtNoOfDefect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfDefect.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfDefect.Location = new System.Drawing.Point(157, 97);
            this.txtNoOfDefect.Name = "txtNoOfDefect";
            this.txtNoOfDefect.Size = new System.Drawing.Size(217, 23);
            this.txtNoOfDefect.TabIndex = 133;
            this.txtNoOfDefect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoOfDefect_KeyPress);
            // 
            // cmbPMStatusChangeDefectObserved
            // 
            this.cmbPMStatusChangeDefectObserved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPMStatusChangeDefectObserved.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPMStatusChangeDefectObserved.FormattingEnabled = true;
            this.cmbPMStatusChangeDefectObserved.Items.AddRange(new object[] {
            "--Select--",
            "No",
            "Yes"});
            this.cmbPMStatusChangeDefectObserved.Location = new System.Drawing.Point(157, 25);
            this.cmbPMStatusChangeDefectObserved.Name = "cmbPMStatusChangeDefectObserved";
            this.cmbPMStatusChangeDefectObserved.Size = new System.Drawing.Size(217, 24);
            this.cmbPMStatusChangeDefectObserved.TabIndex = 122;
            // 
            // lblPMStatusChangeQtyDefCouples
            // 
            this.lblPMStatusChangeQtyDefCouples.AutoSize = true;
            this.lblPMStatusChangeQtyDefCouples.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMStatusChangeQtyDefCouples.Location = new System.Drawing.Point(382, 29);
            this.lblPMStatusChangeQtyDefCouples.Name = "lblPMStatusChangeQtyDefCouples";
            this.lblPMStatusChangeQtyDefCouples.Size = new System.Drawing.Size(170, 16);
            this.lblPMStatusChangeQtyDefCouples.TabIndex = 121;
            this.lblPMStatusChangeQtyDefCouples.Text = "Qty of Defective Sample";
            // 
            // txtPMStatusDefectComment
            // 
            this.txtPMStatusDefectComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMStatusDefectComment.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMStatusDefectComment.Location = new System.Drawing.Point(157, 61);
            this.txtPMStatusDefectComment.Name = "txtPMStatusDefectComment";
            this.txtPMStatusDefectComment.Size = new System.Drawing.Size(217, 23);
            this.txtPMStatusDefectComment.TabIndex = 119;
            // 
            // txtPMStatusChangeQtyDefSamples
            // 
            this.txtPMStatusChangeQtyDefSamples.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMStatusChangeQtyDefSamples.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMStatusChangeQtyDefSamples.Location = new System.Drawing.Point(555, 26);
            this.txtPMStatusChangeQtyDefSamples.Name = "txtPMStatusChangeQtyDefSamples";
            this.txtPMStatusChangeQtyDefSamples.Size = new System.Drawing.Size(217, 23);
            this.txtPMStatusChangeQtyDefSamples.TabIndex = 117;
            // 
            // lblPMStatusChangeCategoryDef
            // 
            this.lblPMStatusChangeCategoryDef.AutoSize = true;
            this.lblPMStatusChangeCategoryDef.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMStatusChangeCategoryDef.Location = new System.Drawing.Point(18, 64);
            this.lblPMStatusChangeCategoryDef.Name = "lblPMStatusChangeCategoryDef";
            this.lblPMStatusChangeCategoryDef.Size = new System.Drawing.Size(135, 16);
            this.lblPMStatusChangeCategoryDef.TabIndex = 116;
            this.lblPMStatusChangeCategoryDef.Text = "Category of Defect";
            // 
            // lblPMStatusChangeDefectObserved
            // 
            this.lblPMStatusChangeDefectObserved.AutoSize = true;
            this.lblPMStatusChangeDefectObserved.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMStatusChangeDefectObserved.Location = new System.Drawing.Point(34, 29);
            this.lblPMStatusChangeDefectObserved.Name = "lblPMStatusChangeDefectObserved";
            this.lblPMStatusChangeDefectObserved.Size = new System.Drawing.Size(119, 16);
            this.lblPMStatusChangeDefectObserved.TabIndex = 115;
            this.lblPMStatusChangeDefectObserved.Text = "Defect Observed";
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
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(112, 27);
            this.toolStripLabel1.Text = "PM Status Change";
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
            this.panelFill.Controls.Add(this.gbFields);
            this.panelFill.Controls.Add(this.gbRMButtons);
            this.panelFill.Controls.Add(this.gbRMStatus);
            this.panelFill.Controls.Add(this.dgRMStatusChangeFields);
            this.panelFill.Controls.Add(this.gbRMStatusChangeSelectFields);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(822, 539);
            this.panelFill.TabIndex = 99;
            // 
            // FrmPMStatusChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(824, 574);
            this.Controls.Add(this.panelOuter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPMStatusChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PM Status Change";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPMStatusChange_Load);
            this.gbRMStatusChangeSelectFields.ResumeLayout(false);
            this.gbRMStatusChangeSelectFields.PerformLayout();
            this.dgRMStatusChangeFields.ResumeLayout(false);
            this.dgRMStatusChangeFields.PerformLayout();
            this.gbRMStatus.ResumeLayout(false);
            this.gbRMStatus.PerformLayout();
            this.gbRMButtons.ResumeLayout(false);
            this.gbFields.ResumeLayout(false);
            this.gbFields.PerformLayout();
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRMStatusChangeSelectFields;
        private System.Windows.Forms.DateTimePicker dtpPMStatusChangeToDate;
        private System.Windows.Forms.Label lblPMStatusChangeToDate;
        private System.Windows.Forms.DateTimePicker dtpPMStatusChangeFromDate;
        private System.Windows.Forms.Label lblPMStatusChangeFromDate;
        private System.Windows.Forms.GroupBox dgRMStatusChangeFields;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPMStatusChangeDetails;
        private System.Windows.Forms.Label lblPMStatusChangeDetails;
        private System.Windows.Forms.TextBox txtPMStatusChangeQtyReceived;
        private System.Windows.Forms.Label lblPMStatusChangeQtyReceived;
        private System.Windows.Forms.TextBox txtPMStatusChangeChallanNo;
        private System.Windows.Forms.Label lblPMStatusChangeChallanNo;
        private System.Windows.Forms.GroupBox gbRMStatus;
        private System.Windows.Forms.GroupBox gbRMButtons;
        private System.Windows.Forms.Button BtnPMStatusChangeExit;
        private System.Windows.Forms.Button BtnPMStatusChangeReset;
        private System.Windows.Forms.Button BtnPMStatusChangeSave;
        private System.Windows.Forms.GroupBox gbFields;
        private System.Windows.Forms.ComboBox cmbPMStatusChangeDefectObserved;
        private System.Windows.Forms.Label lblPMStatusChangeQtyDefCouples;
        private System.Windows.Forms.TextBox txtPMStatusDefectComment;
        private System.Windows.Forms.TextBox txtPMStatusChangeQtyDefSamples;
        private System.Windows.Forms.Label lblPMStatusChangeCategoryDef;
        private System.Windows.Forms.Label lblPMStatusChangeDefectObserved;
        private System.Windows.Forms.CheckedListBox chkRejectComments;
        private System.Windows.Forms.RadioButton RdoSendBackToSupplier;
        private System.Windows.Forms.RadioButton RdoTreatment;
        private System.Windows.Forms.RadioButton RdoAWD;
        private System.Windows.Forms.RadioButton RdoReject;
        private System.Windows.Forms.RadioButton RdoAccept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDefect;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoOfDefect;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
    }
}