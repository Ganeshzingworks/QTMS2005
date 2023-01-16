namespace QTMS.Transactions
{
    partial class FrmRMStatusChange
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
            frmRMStatusChange_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRMStatusChange));
            this.gbRMStatusChangeSelectFields = new System.Windows.Forms.GroupBox();
            this.dtpRMStatusChangeToDate = new System.Windows.Forms.DateTimePicker();
            this.lblRMStatusChangeToDate = new System.Windows.Forms.Label();
            this.dtpRMStatusChangeFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblRMStatusChangeFromDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRMStatusChangeAcceptedQuantity = new System.Windows.Forms.Label();
            this.lblRMStatusChangeNonConformityReason = new System.Windows.Forms.Label();
            this.txtRMStatusChangeAcceptedQuantity = new System.Windows.Forms.TextBox();
            this.txtRMStatusChangeNonConReason = new System.Windows.Forms.TextBox();
            this.gbRMStatus = new System.Windows.Forms.GroupBox();
            this.RdoRmStatusSenttoSupplier = new System.Windows.Forms.RadioButton();
            this.RdoRMStatusChangeAWD = new System.Windows.Forms.RadioButton();
            this.txtRMStatusChangeComments = new System.Windows.Forms.TextBox();
            this.lblRMStatusComments = new System.Windows.Forms.Label();
            this.RdoRMStatusReject = new System.Windows.Forms.RadioButton();
            this.RDoRMStatusAccept = new System.Windows.Forms.RadioButton();
            this.gbRMButtons = new System.Windows.Forms.GroupBox();
            this.BtnRMStatusExit = new System.Windows.Forms.Button();
            this.BtnRMStatusReset = new System.Windows.Forms.Button();
            this.BtnRMStatusSave = new System.Windows.Forms.Button();
            this.dgRMStatusChangeFields = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRMStatusChangeQuantityReceived = new System.Windows.Forms.TextBox();
            this.lblRMStatusChangeQuantityReceived = new System.Windows.Forms.Label();
            this.txtRMStatusChallanNo = new System.Windows.Forms.TextBox();
            this.lblRMStatusChangeChallanNo = new System.Windows.Forms.Label();
            this.cmbRMStatusChangeRMCode = new System.Windows.Forms.ComboBox();
            this.lblRMStatusChangeRMCode = new System.Windows.Forms.Label();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.gbRMStatusChangeSelectFields.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbRMStatus.SuspendLayout();
            this.gbRMButtons.SuspendLayout();
            this.dgRMStatusChangeFields.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRMStatusChangeSelectFields
            // 
            this.gbRMStatusChangeSelectFields.Controls.Add(this.dtpRMStatusChangeToDate);
            this.gbRMStatusChangeSelectFields.Controls.Add(this.lblRMStatusChangeToDate);
            this.gbRMStatusChangeSelectFields.Controls.Add(this.dtpRMStatusChangeFromDate);
            this.gbRMStatusChangeSelectFields.Controls.Add(this.lblRMStatusChangeFromDate);
            this.gbRMStatusChangeSelectFields.Location = new System.Drawing.Point(15, 15);
            this.gbRMStatusChangeSelectFields.Name = "gbRMStatusChangeSelectFields";
            this.gbRMStatusChangeSelectFields.Size = new System.Drawing.Size(799, 63);
            this.gbRMStatusChangeSelectFields.TabIndex = 4;
            this.gbRMStatusChangeSelectFields.TabStop = false;
            // 
            // dtpRMStatusChangeToDate
            // 
            this.dtpRMStatusChangeToDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpRMStatusChangeToDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpRMStatusChangeToDate.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpRMStatusChangeToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpRMStatusChangeToDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.dtpRMStatusChangeToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRMStatusChangeToDate.Location = new System.Drawing.Point(496, 20);
            this.dtpRMStatusChangeToDate.Name = "dtpRMStatusChangeToDate";
            this.dtpRMStatusChangeToDate.Size = new System.Drawing.Size(126, 23);
            this.dtpRMStatusChangeToDate.TabIndex = 85;
            this.dtpRMStatusChangeToDate.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            this.dtpRMStatusChangeToDate.ValueChanged += new System.EventHandler(this.dtpRMStatusChangeToDate_ValueChanged);
            // 
            // lblRMStatusChangeToDate
            // 
            this.lblRMStatusChangeToDate.AutoSize = true;
            this.lblRMStatusChangeToDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMStatusChangeToDate.Location = new System.Drawing.Point(425, 23);
            this.lblRMStatusChangeToDate.Name = "lblRMStatusChangeToDate";
            this.lblRMStatusChangeToDate.Size = new System.Drawing.Size(66, 16);
            this.lblRMStatusChangeToDate.TabIndex = 84;
            this.lblRMStatusChangeToDate.Text = "To  Date";
            // 
            // dtpRMStatusChangeFromDate
            // 
            this.dtpRMStatusChangeFromDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpRMStatusChangeFromDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtpRMStatusChangeFromDate.CalendarTitleForeColor = System.Drawing.SystemColors.Control;
            this.dtpRMStatusChangeFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpRMStatusChangeFromDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.dtpRMStatusChangeFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRMStatusChangeFromDate.Location = new System.Drawing.Point(188, 20);
            this.dtpRMStatusChangeFromDate.Name = "dtpRMStatusChangeFromDate";
            this.dtpRMStatusChangeFromDate.Size = new System.Drawing.Size(126, 23);
            this.dtpRMStatusChangeFromDate.TabIndex = 83;
            this.dtpRMStatusChangeFromDate.Value = new System.DateTime(2008, 7, 18, 0, 0, 0, 0);
            this.dtpRMStatusChangeFromDate.ValueChanged += new System.EventHandler(this.dtpRMStatusChangeFromDate_ValueChanged);
            // 
            // lblRMStatusChangeFromDate
            // 
            this.lblRMStatusChangeFromDate.AutoSize = true;
            this.lblRMStatusChangeFromDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMStatusChangeFromDate.Location = new System.Drawing.Point(107, 23);
            this.lblRMStatusChangeFromDate.Name = "lblRMStatusChangeFromDate";
            this.lblRMStatusChangeFromDate.Size = new System.Drawing.Size(76, 16);
            this.lblRMStatusChangeFromDate.TabIndex = 82;
            this.lblRMStatusChangeFromDate.Text = "From Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRMStatusChangeAcceptedQuantity);
            this.groupBox1.Controls.Add(this.lblRMStatusChangeNonConformityReason);
            this.groupBox1.Controls.Add(this.txtRMStatusChangeAcceptedQuantity);
            this.groupBox1.Controls.Add(this.txtRMStatusChangeNonConReason);
            this.groupBox1.Location = new System.Drawing.Point(15, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(799, 66);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // lblRMStatusChangeAcceptedQuantity
            // 
            this.lblRMStatusChangeAcceptedQuantity.AutoSize = true;
            this.lblRMStatusChangeAcceptedQuantity.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMStatusChangeAcceptedQuantity.Location = new System.Drawing.Point(10, 22);
            this.lblRMStatusChangeAcceptedQuantity.Name = "lblRMStatusChangeAcceptedQuantity";
            this.lblRMStatusChangeAcceptedQuantity.Size = new System.Drawing.Size(133, 16);
            this.lblRMStatusChangeAcceptedQuantity.TabIndex = 30;
            this.lblRMStatusChangeAcceptedQuantity.Text = "Accepted Quantity";
            // 
            // lblRMStatusChangeNonConformityReason
            // 
            this.lblRMStatusChangeNonConformityReason.AutoSize = true;
            this.lblRMStatusChangeNonConformityReason.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMStatusChangeNonConformityReason.Location = new System.Drawing.Point(392, 26);
            this.lblRMStatusChangeNonConformityReason.Name = "lblRMStatusChangeNonConformityReason";
            this.lblRMStatusChangeNonConformityReason.Size = new System.Drawing.Size(161, 16);
            this.lblRMStatusChangeNonConformityReason.TabIndex = 32;
            this.lblRMStatusChangeNonConformityReason.Text = "Non Conformity Reason";
            // 
            // txtRMStatusChangeAcceptedQuantity
            // 
            this.txtRMStatusChangeAcceptedQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMStatusChangeAcceptedQuantity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMStatusChangeAcceptedQuantity.Location = new System.Drawing.Point(148, 19);
            this.txtRMStatusChangeAcceptedQuantity.Name = "txtRMStatusChangeAcceptedQuantity";
            this.txtRMStatusChangeAcceptedQuantity.Size = new System.Drawing.Size(217, 23);
            this.txtRMStatusChangeAcceptedQuantity.TabIndex = 31;
            this.txtRMStatusChangeAcceptedQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRMStatusChangeAcceptedQuantity_KeyPress);
            // 
            // txtRMStatusChangeNonConReason
            // 
            this.txtRMStatusChangeNonConReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMStatusChangeNonConReason.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMStatusChangeNonConReason.Location = new System.Drawing.Point(559, 23);
            this.txtRMStatusChangeNonConReason.Name = "txtRMStatusChangeNonConReason";
            this.txtRMStatusChangeNonConReason.Size = new System.Drawing.Size(217, 23);
            this.txtRMStatusChangeNonConReason.TabIndex = 27;
            // 
            // gbRMStatus
            // 
            this.gbRMStatus.Controls.Add(this.RdoRmStatusSenttoSupplier);
            this.gbRMStatus.Controls.Add(this.RdoRMStatusChangeAWD);
            this.gbRMStatus.Controls.Add(this.txtRMStatusChangeComments);
            this.gbRMStatus.Controls.Add(this.lblRMStatusComments);
            this.gbRMStatus.Controls.Add(this.RdoRMStatusReject);
            this.gbRMStatus.Controls.Add(this.RDoRMStatusAccept);
            this.gbRMStatus.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.gbRMStatus.Location = new System.Drawing.Point(15, 284);
            this.gbRMStatus.Name = "gbRMStatus";
            this.gbRMStatus.Size = new System.Drawing.Size(799, 95);
            this.gbRMStatus.TabIndex = 6;
            this.gbRMStatus.TabStop = false;
            this.gbRMStatus.Text = "Status";
            // 
            // RdoRmStatusSenttoSupplier
            // 
            this.RdoRmStatusSenttoSupplier.AutoSize = true;
            this.RdoRmStatusSenttoSupplier.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoRmStatusSenttoSupplier.Location = new System.Drawing.Point(158, 59);
            this.RdoRmStatusSenttoSupplier.Name = "RdoRmStatusSenttoSupplier";
            this.RdoRmStatusSenttoSupplier.Size = new System.Drawing.Size(152, 17);
            this.RdoRmStatusSenttoSupplier.TabIndex = 90;
            this.RdoRmStatusSenttoSupplier.Text = "Sent Back To Supplier";
            this.RdoRmStatusSenttoSupplier.UseVisualStyleBackColor = true;
            // 
            // RdoRMStatusChangeAWD
            // 
            this.RdoRMStatusChangeAWD.AutoSize = true;
            this.RdoRMStatusChangeAWD.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoRMStatusChangeAWD.Location = new System.Drawing.Point(45, 59);
            this.RdoRMStatusChangeAWD.Name = "RdoRMStatusChangeAWD";
            this.RdoRMStatusChangeAWD.Size = new System.Drawing.Size(53, 17);
            this.RdoRMStatusChangeAWD.TabIndex = 89;
            this.RdoRMStatusChangeAWD.Text = "AWD";
            this.RdoRMStatusChangeAWD.UseVisualStyleBackColor = true;
            // 
            // txtRMStatusChangeComments
            // 
            this.txtRMStatusChangeComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMStatusChangeComments.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMStatusChangeComments.Location = new System.Drawing.Point(467, 22);
            this.txtRMStatusChangeComments.Name = "txtRMStatusChangeComments";
            this.txtRMStatusChangeComments.Size = new System.Drawing.Size(309, 23);
            this.txtRMStatusChangeComments.TabIndex = 36;
            // 
            // lblRMStatusComments
            // 
            this.lblRMStatusComments.AutoSize = true;
            this.lblRMStatusComments.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMStatusComments.Location = new System.Drawing.Point(376, 28);
            this.lblRMStatusComments.Name = "lblRMStatusComments";
            this.lblRMStatusComments.Size = new System.Drawing.Size(76, 16);
            this.lblRMStatusComments.TabIndex = 35;
            this.lblRMStatusComments.Text = "Comments";
            // 
            // RdoRMStatusReject
            // 
            this.RdoRMStatusReject.AutoSize = true;
            this.RdoRMStatusReject.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.RdoRMStatusReject.Location = new System.Drawing.Point(158, 24);
            this.RdoRMStatusReject.Name = "RdoRMStatusReject";
            this.RdoRMStatusReject.Size = new System.Drawing.Size(68, 20);
            this.RdoRMStatusReject.TabIndex = 1;
            this.RdoRMStatusReject.TabStop = true;
            this.RdoRMStatusReject.Text = "Reject";
            this.RdoRMStatusReject.UseVisualStyleBackColor = true;
            // 
            // RDoRMStatusAccept
            // 
            this.RDoRMStatusAccept.AutoSize = true;
            this.RDoRMStatusAccept.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.RDoRMStatusAccept.Location = new System.Drawing.Point(45, 24);
            this.RDoRMStatusAccept.Name = "RDoRMStatusAccept";
            this.RDoRMStatusAccept.Size = new System.Drawing.Size(73, 20);
            this.RDoRMStatusAccept.TabIndex = 0;
            this.RDoRMStatusAccept.TabStop = true;
            this.RDoRMStatusAccept.Text = "Accept";
            this.RDoRMStatusAccept.UseVisualStyleBackColor = true;
            // 
            // gbRMButtons
            // 
            this.gbRMButtons.Controls.Add(this.BtnRMStatusExit);
            this.gbRMButtons.Controls.Add(this.BtnRMStatusReset);
            this.gbRMButtons.Controls.Add(this.BtnRMStatusSave);
            this.gbRMButtons.Location = new System.Drawing.Point(15, 384);
            this.gbRMButtons.Name = "gbRMButtons";
            this.gbRMButtons.Size = new System.Drawing.Size(799, 76);
            this.gbRMButtons.TabIndex = 50;
            this.gbRMButtons.TabStop = false;
            // 
            // BtnRMStatusExit
            // 
            this.BtnRMStatusExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMStatusExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMStatusExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRMStatusExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMStatusExit.Location = new System.Drawing.Point(546, 21);
            this.BtnRMStatusExit.Name = "BtnRMStatusExit";
            this.BtnRMStatusExit.Size = new System.Drawing.Size(128, 35);
            this.BtnRMStatusExit.TabIndex = 53;
            this.BtnRMStatusExit.Text = "&Exit";
            this.BtnRMStatusExit.UseVisualStyleBackColor = false;
            this.BtnRMStatusExit.Click += new System.EventHandler(this.BtnRMStatusExit_Click);
            // 
            // BtnRMStatusReset
            // 
            this.BtnRMStatusReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMStatusReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMStatusReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRMStatusReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMStatusReset.Location = new System.Drawing.Point(125, 21);
            this.BtnRMStatusReset.Name = "BtnRMStatusReset";
            this.BtnRMStatusReset.Size = new System.Drawing.Size(128, 35);
            this.BtnRMStatusReset.TabIndex = 50;
            this.BtnRMStatusReset.Text = "&Reset";
            this.BtnRMStatusReset.UseVisualStyleBackColor = false;
            this.BtnRMStatusReset.Click += new System.EventHandler(this.BtnRMStatusReset_Click);
            // 
            // BtnRMStatusSave
            // 
            this.BtnRMStatusSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMStatusSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMStatusSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRMStatusSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMStatusSave.Location = new System.Drawing.Point(342, 21);
            this.BtnRMStatusSave.Name = "BtnRMStatusSave";
            this.BtnRMStatusSave.Size = new System.Drawing.Size(128, 35);
            this.BtnRMStatusSave.TabIndex = 49;
            this.BtnRMStatusSave.Text = "&Save";
            this.BtnRMStatusSave.UseVisualStyleBackColor = false;
            this.BtnRMStatusSave.Click += new System.EventHandler(this.BtnRMStatusSave_Click);
            // 
            // dgRMStatusChangeFields
            // 
            this.dgRMStatusChangeFields.Controls.Add(this.label1);
            this.dgRMStatusChangeFields.Controls.Add(this.txtRMStatusChangeQuantityReceived);
            this.dgRMStatusChangeFields.Controls.Add(this.lblRMStatusChangeQuantityReceived);
            this.dgRMStatusChangeFields.Controls.Add(this.txtRMStatusChallanNo);
            this.dgRMStatusChangeFields.Controls.Add(this.lblRMStatusChangeChallanNo);
            this.dgRMStatusChangeFields.Controls.Add(this.cmbRMStatusChangeRMCode);
            this.dgRMStatusChangeFields.Controls.Add(this.lblRMStatusChangeRMCode);
            this.dgRMStatusChangeFields.Location = new System.Drawing.Point(15, 81);
            this.dgRMStatusChangeFields.Name = "dgRMStatusChangeFields";
            this.dgRMStatusChangeFields.Size = new System.Drawing.Size(799, 130);
            this.dgRMStatusChangeFields.TabIndex = 51;
            this.dgRMStatusChangeFields.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(332, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 16);
            this.label1.TabIndex = 97;
            this.label1.Text = "( RMCode - Supplier - Lot No )";
            // 
            // txtRMStatusChangeQuantityReceived
            // 
            this.txtRMStatusChangeQuantityReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMStatusChangeQuantityReceived.Enabled = false;
            this.txtRMStatusChangeQuantityReceived.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMStatusChangeQuantityReceived.Location = new System.Drawing.Point(148, 74);
            this.txtRMStatusChangeQuantityReceived.Name = "txtRMStatusChangeQuantityReceived";
            this.txtRMStatusChangeQuantityReceived.Size = new System.Drawing.Size(217, 23);
            this.txtRMStatusChangeQuantityReceived.TabIndex = 95;
            // 
            // lblRMStatusChangeQuantityReceived
            // 
            this.lblRMStatusChangeQuantityReceived.AutoSize = true;
            this.lblRMStatusChangeQuantityReceived.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMStatusChangeQuantityReceived.Location = new System.Drawing.Point(9, 77);
            this.lblRMStatusChangeQuantityReceived.Name = "lblRMStatusChangeQuantityReceived";
            this.lblRMStatusChangeQuantityReceived.Size = new System.Drawing.Size(134, 16);
            this.lblRMStatusChangeQuantityReceived.TabIndex = 94;
            this.lblRMStatusChangeQuantityReceived.Text = "Received Quantity ";
            // 
            // txtRMStatusChallanNo
            // 
            this.txtRMStatusChallanNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMStatusChallanNo.Enabled = false;
            this.txtRMStatusChallanNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMStatusChallanNo.Location = new System.Drawing.Point(559, 74);
            this.txtRMStatusChallanNo.Name = "txtRMStatusChallanNo";
            this.txtRMStatusChallanNo.Size = new System.Drawing.Size(217, 23);
            this.txtRMStatusChallanNo.TabIndex = 96;
            // 
            // lblRMStatusChangeChallanNo
            // 
            this.lblRMStatusChangeChallanNo.AutoSize = true;
            this.lblRMStatusChangeChallanNo.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMStatusChangeChallanNo.Location = new System.Drawing.Point(476, 77);
            this.lblRMStatusChangeChallanNo.Name = "lblRMStatusChangeChallanNo";
            this.lblRMStatusChangeChallanNo.Size = new System.Drawing.Size(77, 16);
            this.lblRMStatusChangeChallanNo.TabIndex = 93;
            this.lblRMStatusChangeChallanNo.Text = "Challan No";
            // 
            // cmbRMStatusChangeRMCode
            // 
            this.cmbRMStatusChangeRMCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRMStatusChangeRMCode.FormattingEnabled = true;
            this.cmbRMStatusChangeRMCode.Location = new System.Drawing.Point(233, 34);
            this.cmbRMStatusChangeRMCode.Name = "cmbRMStatusChangeRMCode";
            this.cmbRMStatusChangeRMCode.Size = new System.Drawing.Size(408, 24);
            this.cmbRMStatusChangeRMCode.TabIndex = 88;
            this.cmbRMStatusChangeRMCode.SelectionChangeCommitted += new System.EventHandler(this.cmbRMStatusChangeRMCode_SelectionChangeCommitted);
            // 
            // lblRMStatusChangeRMCode
            // 
            this.lblRMStatusChangeRMCode.AutoSize = true;
            this.lblRMStatusChangeRMCode.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMStatusChangeRMCode.Location = new System.Drawing.Point(176, 37);
            this.lblRMStatusChangeRMCode.Name = "lblRMStatusChangeRMCode";
            this.lblRMStatusChangeRMCode.Size = new System.Drawing.Size(52, 16);
            this.lblRMStatusChangeRMCode.TabIndex = 87;
            this.lblRMStatusChangeRMCode.Text = "Details";
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(831, 510);
            this.panelOuter.TabIndex = 52;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(829, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(829, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(113, 27);
            this.toolStripLabel1.Text = "RM Status Change";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFill);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 33);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(829, 475);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.dgRMStatusChangeFields);
            this.panelFill.Controls.Add(this.gbRMButtons);
            this.panelFill.Controls.Add(this.gbRMStatus);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Controls.Add(this.gbRMStatusChangeSelectFields);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(829, 475);
            this.panelFill.TabIndex = 0;
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
            // FrmRMStatusChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(831, 510);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRMStatusChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RM Status Change";
            this.Load += new System.EventHandler(this.FrmRMStatusChange_Load);
            this.gbRMStatusChangeSelectFields.ResumeLayout(false);
            this.gbRMStatusChangeSelectFields.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbRMStatus.ResumeLayout(false);
            this.gbRMStatus.PerformLayout();
            this.gbRMButtons.ResumeLayout(false);
            this.dgRMStatusChangeFields.ResumeLayout(false);
            this.dgRMStatusChangeFields.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRMStatusChangeAcceptedQuantity;
        private System.Windows.Forms.Label lblRMStatusChangeNonConformityReason;
        private System.Windows.Forms.TextBox txtRMStatusChangeAcceptedQuantity;
        private System.Windows.Forms.TextBox txtRMStatusChangeNonConReason;
        private System.Windows.Forms.DateTimePicker dtpRMStatusChangeToDate;
        private System.Windows.Forms.Label lblRMStatusChangeToDate;
        private System.Windows.Forms.DateTimePicker dtpRMStatusChangeFromDate;
        private System.Windows.Forms.Label lblRMStatusChangeFromDate;
        private System.Windows.Forms.GroupBox gbRMStatus;
        private System.Windows.Forms.RadioButton RdoRMStatusReject;
        private System.Windows.Forms.RadioButton RDoRMStatusAccept;
        private System.Windows.Forms.GroupBox gbRMButtons;
        private System.Windows.Forms.Button BtnRMStatusExit;
        private System.Windows.Forms.Button BtnRMStatusReset;
        private System.Windows.Forms.Button BtnRMStatusSave;
        private System.Windows.Forms.GroupBox dgRMStatusChangeFields;
        private System.Windows.Forms.TextBox txtRMStatusChangeQuantityReceived;
        private System.Windows.Forms.Label lblRMStatusChangeQuantityReceived;
        private System.Windows.Forms.TextBox txtRMStatusChallanNo;
        private System.Windows.Forms.Label lblRMStatusChangeChallanNo;
        private System.Windows.Forms.ComboBox cmbRMStatusChangeRMCode;
        private System.Windows.Forms.Label lblRMStatusChangeRMCode;
        private System.Windows.Forms.TextBox txtRMStatusChangeComments;
        private System.Windows.Forms.Label lblRMStatusComments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RdoRmStatusSenttoSupplier;
        private System.Windows.Forms.RadioButton RdoRMStatusChangeAWD;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
    }
}