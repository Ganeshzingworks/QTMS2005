namespace QTMS.Transactions
{
    partial class FrmPMTreatment
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
            frmPMTreatment_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPMTreatment));
            this.dgRMStatusChangeFields = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDefect = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoOfDefect = new System.Windows.Forms.TextBox();
            this.lblPMTransactionInspDate = new System.Windows.Forms.Label();
            this.DtpInspDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDefectQuantity = new System.Windows.Forms.TextBox();
            this.lblPMTransactionReason = new System.Windows.Forms.Label();
            this.cmbDetectObserved = new System.Windows.Forms.ComboBox();
            this.txtDefectComment = new System.Windows.Forms.TextBox();
            this.lblPMTransactionDetectNoteSend = new System.Windows.Forms.Label();
            this.txtControlType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRejectComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPMTreatmentReasonRejection = new System.Windows.Forms.Label();
            this.cmbPMTreatmentDetails = new System.Windows.Forms.ComboBox();
            this.lblPMTreatmentDetails = new System.Windows.Forms.Label();
            this.gbPMTreatmentdone = new System.Windows.Forms.GroupBox();
            this.txtPMTreatmentQty = new System.Windows.Forms.TextBox();
            this.lblPMTreatmentQty = new System.Windows.Forms.Label();
            this.dgAllTests = new System.Windows.Forms.DataGridView();
            this.FGMethodNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.RdoPMTransactionNo = new System.Windows.Forms.RadioButton();
            this.RdoPMTreatmentYes = new System.Windows.Forms.RadioButton();
            this.gbPMTransactionButtons = new System.Windows.Forms.GroupBox();
            this.BtnPMTreatmentReset = new System.Windows.Forms.Button();
            this.BtnPMTreatmentExit = new System.Windows.Forms.Button();
            this.BtnPMTreatmentSave = new System.Windows.Forms.Button();
            this.gbPMTransactionStatus = new System.Windows.Forms.GroupBox();
            this.chkRejectComments = new System.Windows.Forms.CheckedListBox();
            this.RdoSendBackToSupplier = new System.Windows.Forms.RadioButton();
            this.RdoTreatment = new System.Windows.Forms.RadioButton();
            this.RdoAWD = new System.Windows.Forms.RadioButton();
            this.RdoReject = new System.Windows.Forms.RadioButton();
            this.RdoAccept = new System.Windows.Forms.RadioButton();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.dgRMStatusChangeFields.SuspendLayout();
            this.gbPMTreatmentdone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllTests)).BeginInit();
            this.gbPMTransactionButtons.SuspendLayout();
            this.gbPMTransactionStatus.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgRMStatusChangeFields
            // 
            this.dgRMStatusChangeFields.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgRMStatusChangeFields.Controls.Add(this.label4);
            this.dgRMStatusChangeFields.Controls.Add(this.txtDefect);
            this.dgRMStatusChangeFields.Controls.Add(this.label5);
            this.dgRMStatusChangeFields.Controls.Add(this.txtNoOfDefect);
            this.dgRMStatusChangeFields.Controls.Add(this.lblPMTransactionInspDate);
            this.dgRMStatusChangeFields.Controls.Add(this.DtpInspDate);
            this.dgRMStatusChangeFields.Controls.Add(this.label3);
            this.dgRMStatusChangeFields.Controls.Add(this.txtDefectQuantity);
            this.dgRMStatusChangeFields.Controls.Add(this.lblPMTransactionReason);
            this.dgRMStatusChangeFields.Controls.Add(this.cmbDetectObserved);
            this.dgRMStatusChangeFields.Controls.Add(this.txtDefectComment);
            this.dgRMStatusChangeFields.Controls.Add(this.lblPMTransactionDetectNoteSend);
            this.dgRMStatusChangeFields.Controls.Add(this.txtControlType);
            this.dgRMStatusChangeFields.Controls.Add(this.label2);
            this.dgRMStatusChangeFields.Controls.Add(this.txtRejectComment);
            this.dgRMStatusChangeFields.Controls.Add(this.label1);
            this.dgRMStatusChangeFields.Controls.Add(this.lblPMTreatmentReasonRejection);
            this.dgRMStatusChangeFields.Controls.Add(this.cmbPMTreatmentDetails);
            this.dgRMStatusChangeFields.Controls.Add(this.lblPMTreatmentDetails);
            this.dgRMStatusChangeFields.Location = new System.Drawing.Point(18, 40);
            this.dgRMStatusChangeFields.Name = "dgRMStatusChangeFields";
            this.dgRMStatusChangeFields.Size = new System.Drawing.Size(968, 199);
            this.dgRMStatusChangeFields.TabIndex = 53;
            this.dgRMStatusChangeFields.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 132;
            this.label4.Text = "Defect";
            // 
            // txtDefect
            // 
            this.txtDefect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDefect.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefect.Location = new System.Drawing.Point(457, 152);
            this.txtDefect.Name = "txtDefect";
            this.txtDefect.Size = new System.Drawing.Size(174, 23);
            this.txtDefect.TabIndex = 131;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 130;
            this.label5.Text = "No of Defect";
            // 
            // txtNoOfDefect
            // 
            this.txtNoOfDefect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfDefect.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfDefect.Location = new System.Drawing.Point(137, 152);
            this.txtNoOfDefect.Name = "txtNoOfDefect";
            this.txtNoOfDefect.Size = new System.Drawing.Size(174, 23);
            this.txtNoOfDefect.TabIndex = 129;
            this.txtNoOfDefect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoOfDefect_KeyPress);
            // 
            // lblPMTransactionInspDate
            // 
            this.lblPMTransactionInspDate.AutoSize = true;
            this.lblPMTransactionInspDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMTransactionInspDate.Location = new System.Drawing.Point(750, 40);
            this.lblPMTransactionInspDate.Name = "lblPMTransactionInspDate";
            this.lblPMTransactionInspDate.Size = new System.Drawing.Size(72, 16);
            this.lblPMTransactionInspDate.TabIndex = 128;
            this.lblPMTransactionInspDate.Text = "Insp Date";
            // 
            // DtpInspDate
            // 
            this.DtpInspDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpInspDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpInspDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpInspDate.Location = new System.Drawing.Point(827, 37);
            this.DtpInspDate.Name = "DtpInspDate";
            this.DtpInspDate.Size = new System.Drawing.Size(120, 23);
            this.DtpInspDate.TabIndex = 127;
            this.DtpInspDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(664, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 124;
            this.label3.Text = "Defect Quantity";
            // 
            // txtDefectQuantity
            // 
            this.txtDefectQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDefectQuantity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefectQuantity.Location = new System.Drawing.Point(781, 114);
            this.txtDefectQuantity.Name = "txtDefectQuantity";
            this.txtDefectQuantity.Size = new System.Drawing.Size(174, 23);
            this.txtDefectQuantity.TabIndex = 123;
            // 
            // lblPMTransactionReason
            // 
            this.lblPMTransactionReason.AutoSize = true;
            this.lblPMTransactionReason.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMTransactionReason.Location = new System.Drawing.Point(335, 117);
            this.lblPMTransactionReason.Name = "lblPMTransactionReason";
            this.lblPMTransactionReason.Size = new System.Drawing.Size(118, 16);
            this.lblPMTransactionReason.TabIndex = 122;
            this.lblPMTransactionReason.Text = "Defect Comment";
            // 
            // cmbDetectObserved
            // 
            this.cmbDetectObserved.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbDetectObserved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDetectObserved.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDetectObserved.FormattingEnabled = true;
            this.cmbDetectObserved.Items.AddRange(new object[] {
            "--Select--",
            "No",
            "Yes"});
            this.cmbDetectObserved.Location = new System.Drawing.Point(137, 113);
            this.cmbDetectObserved.Name = "cmbDetectObserved";
            this.cmbDetectObserved.Size = new System.Drawing.Size(174, 24);
            this.cmbDetectObserved.TabIndex = 119;
            // 
            // txtDefectComment
            // 
            this.txtDefectComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDefectComment.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefectComment.Location = new System.Drawing.Point(457, 114);
            this.txtDefectComment.Name = "txtDefectComment";
            this.txtDefectComment.Size = new System.Drawing.Size(174, 23);
            this.txtDefectComment.TabIndex = 120;
            // 
            // lblPMTransactionDetectNoteSend
            // 
            this.lblPMTransactionDetectNoteSend.AutoSize = true;
            this.lblPMTransactionDetectNoteSend.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMTransactionDetectNoteSend.Location = new System.Drawing.Point(14, 117);
            this.lblPMTransactionDetectNoteSend.Name = "lblPMTransactionDetectNoteSend";
            this.lblPMTransactionDetectNoteSend.Size = new System.Drawing.Size(120, 16);
            this.lblPMTransactionDetectNoteSend.TabIndex = 121;
            this.lblPMTransactionDetectNoteSend.Text = "Detect Observed";
            // 
            // txtControlType
            // 
            this.txtControlType.BackColor = System.Drawing.SystemColors.Control;
            this.txtControlType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtControlType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtControlType.Location = new System.Drawing.Point(673, 75);
            this.txtControlType.Name = "txtControlType";
            this.txtControlType.Size = new System.Drawing.Size(192, 23);
            this.txtControlType.TabIndex = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label2.Location = new System.Drawing.Point(574, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 99;
            this.label2.Text = "Control Type";
            // 
            // txtRejectComment
            // 
            this.txtRejectComment.BackColor = System.Drawing.SystemColors.Control;
            this.txtRejectComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRejectComment.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRejectComment.Location = new System.Drawing.Point(246, 75);
            this.txtRejectComment.Name = "txtRejectComment";
            this.txtRejectComment.Size = new System.Drawing.Size(192, 23);
            this.txtRejectComment.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(385, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 16);
            this.label1.TabIndex = 97;
            this.label1.Text = "(PM Code-Supplier Name-Lot No)";
            // 
            // lblPMTreatmentReasonRejection
            // 
            this.lblPMTreatmentReasonRejection.AutoSize = true;
            this.lblPMTreatmentReasonRejection.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMTreatmentReasonRejection.Location = new System.Drawing.Point(104, 78);
            this.lblPMTreatmentReasonRejection.Name = "lblPMTreatmentReasonRejection";
            this.lblPMTreatmentReasonRejection.Size = new System.Drawing.Size(139, 16);
            this.lblPMTreatmentReasonRejection.TabIndex = 89;
            this.lblPMTreatmentReasonRejection.Text = "Reason of Rejection";
            // 
            // cmbPMTreatmentDetails
            // 
            this.cmbPMTreatmentDetails.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPMTreatmentDetails.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPMTreatmentDetails.FormattingEnabled = true;
            this.cmbPMTreatmentDetails.Location = new System.Drawing.Point(304, 36);
            this.cmbPMTreatmentDetails.Name = "cmbPMTreatmentDetails";
            this.cmbPMTreatmentDetails.Size = new System.Drawing.Size(388, 24);
            this.cmbPMTreatmentDetails.TabIndex = 88;
            this.cmbPMTreatmentDetails.SelectionChangeCommitted += new System.EventHandler(this.cmbPMTreatmentDetails_SelectionChangeCommitted);
            // 
            // lblPMTreatmentDetails
            // 
            this.lblPMTreatmentDetails.AutoSize = true;
            this.lblPMTreatmentDetails.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMTreatmentDetails.Location = new System.Drawing.Point(246, 40);
            this.lblPMTreatmentDetails.Name = "lblPMTreatmentDetails";
            this.lblPMTreatmentDetails.Size = new System.Drawing.Size(52, 16);
            this.lblPMTreatmentDetails.TabIndex = 87;
            this.lblPMTreatmentDetails.Text = "Details";
            // 
            // gbPMTreatmentdone
            // 
            this.gbPMTreatmentdone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbPMTreatmentdone.Controls.Add(this.txtPMTreatmentQty);
            this.gbPMTreatmentdone.Controls.Add(this.lblPMTreatmentQty);
            this.gbPMTreatmentdone.Controls.Add(this.dgAllTests);
            this.gbPMTreatmentdone.Controls.Add(this.RdoPMTransactionNo);
            this.gbPMTreatmentdone.Controls.Add(this.RdoPMTreatmentYes);
            this.gbPMTreatmentdone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPMTreatmentdone.Location = new System.Drawing.Point(18, 239);
            this.gbPMTreatmentdone.Name = "gbPMTreatmentdone";
            this.gbPMTreatmentdone.Size = new System.Drawing.Size(966, 272);
            this.gbPMTreatmentdone.TabIndex = 62;
            this.gbPMTreatmentdone.TabStop = false;
            this.gbPMTreatmentdone.Text = "Treatment Done";
            // 
            // txtPMTreatmentQty
            // 
            this.txtPMTreatmentQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMTreatmentQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMTreatmentQty.Location = new System.Drawing.Point(681, 61);
            this.txtPMTreatmentQty.Name = "txtPMTreatmentQty";
            this.txtPMTreatmentQty.Size = new System.Drawing.Size(194, 23);
            this.txtPMTreatmentQty.TabIndex = 104;
            this.txtPMTreatmentQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPMTreatmentQty_KeyPress);
            // 
            // lblPMTreatmentQty
            // 
            this.lblPMTreatmentQty.AutoSize = true;
            this.lblPMTreatmentQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMTreatmentQty.Location = new System.Drawing.Point(606, 64);
            this.lblPMTreatmentQty.Name = "lblPMTreatmentQty";
            this.lblPMTreatmentQty.Size = new System.Drawing.Size(65, 16);
            this.lblPMTreatmentQty.TabIndex = 103;
            this.lblPMTreatmentQty.Text = "Quantity";
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
            this.FGMethodNo,
            this.TestMethod,
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
            this.dgAllTests.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.dgAllTests.Location = new System.Drawing.Point(3, 98);
            this.dgAllTests.MultiSelect = false;
            this.dgAllTests.Name = "dgAllTests";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgAllTests.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgAllTests.RowHeadersVisible = false;
            this.dgAllTests.Size = new System.Drawing.Size(960, 171);
            this.dgAllTests.TabIndex = 101;
            this.dgAllTests.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgAllTests_EditingControlShowing);
            this.dgAllTests.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgAllTests_KeyPress);
            // 
            // FGMethodNo
            // 
            this.FGMethodNo.HeaderText = "PMMethodNo";
            this.FGMethodNo.Name = "FGMethodNo";
            this.FGMethodNo.ReadOnly = true;
            this.FGMethodNo.Visible = false;
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
            // Frequency
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Frequency.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.InspectionMethod.DefaultCellStyle = dataGridViewCellStyle4;
            this.InspectionMethod.HeaderText = "Inspection Method";
            this.InspectionMethod.Name = "InspectionMethod";
            this.InspectionMethod.Width = 70;
            // 
            // LotSize
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LotSize.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SampleSizeStandard.DefaultCellStyle = dataGridViewCellStyle6;
            this.SampleSizeStandard.HeaderText = "Sample Size (Std)";
            this.SampleSizeStandard.Name = "SampleSizeStandard";
            this.SampleSizeStandard.ReadOnly = true;
            this.SampleSizeStandard.Width = 70;
            // 
            // SampleSizeReading
            // 
            this.SampleSizeReading.HeaderText = "Samples Size (Read)";
            this.SampleSizeReading.Name = "SampleSizeReading";
            this.SampleSizeReading.Width = 70;
            // 
            // AQLStandard
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AQLStandard.DefaultCellStyle = dataGridViewCellStyle7;
            this.AQLStandard.HeaderText = "AQL (std)";
            this.AQLStandard.MaxInputLength = 6;
            this.AQLStandard.Name = "AQLStandard";
            this.AQLStandard.ReadOnly = true;
            this.AQLStandard.Width = 50;
            // 
            // AQLReading
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.AQLReading.DefaultCellStyle = dataGridViewCellStyle8;
            this.AQLReading.HeaderText = "AQL (Read)";
            this.AQLReading.MaxInputLength = 6;
            this.AQLReading.Name = "AQLReading";
            this.AQLReading.Width = 50;
            // 
            // AQLzStandard
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AQLzStandard.DefaultCellStyle = dataGridViewCellStyle9;
            this.AQLzStandard.HeaderText = "AQL(z) (Std)";
            this.AQLzStandard.Name = "AQLzStandard";
            this.AQLzStandard.ReadOnly = true;
            this.AQLzStandard.Width = 50;
            // 
            // AQLzReading
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.AQLzReading.DefaultCellStyle = dataGridViewCellStyle10;
            this.AQLzReading.HeaderText = "AQL(z) (Read)";
            this.AQLzReading.Name = "AQLzReading";
            this.AQLzReading.Width = 50;
            // 
            // AQLcStandard
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AQLcStandard.DefaultCellStyle = dataGridViewCellStyle11;
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
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AQLMStandard.DefaultCellStyle = dataGridViewCellStyle12;
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
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AQLM1Standard.DefaultCellStyle = dataGridViewCellStyle13;
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
            // RdoPMTransactionNo
            // 
            this.RdoPMTransactionNo.AutoSize = true;
            this.RdoPMTransactionNo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoPMTransactionNo.Location = new System.Drawing.Point(546, 22);
            this.RdoPMTransactionNo.Name = "RdoPMTransactionNo";
            this.RdoPMTransactionNo.Size = new System.Drawing.Size(48, 22);
            this.RdoPMTransactionNo.TabIndex = 99;
            this.RdoPMTransactionNo.Text = "No";
            this.RdoPMTransactionNo.UseVisualStyleBackColor = true;
            this.RdoPMTransactionNo.CheckedChanged += new System.EventHandler(this.RdoPMTransactionNo_CheckedChanged);
            // 
            // RdoPMTreatmentYes
            // 
            this.RdoPMTreatmentYes.AutoSize = true;
            this.RdoPMTreatmentYes.Checked = true;
            this.RdoPMTreatmentYes.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoPMTreatmentYes.Location = new System.Drawing.Point(372, 21);
            this.RdoPMTreatmentYes.Name = "RdoPMTreatmentYes";
            this.RdoPMTreatmentYes.Size = new System.Drawing.Size(56, 22);
            this.RdoPMTreatmentYes.TabIndex = 86;
            this.RdoPMTreatmentYes.TabStop = true;
            this.RdoPMTreatmentYes.Text = "Yes";
            this.RdoPMTreatmentYes.UseVisualStyleBackColor = true;
            this.RdoPMTreatmentYes.CheckedChanged += new System.EventHandler(this.RdoPMTreatmentYes_CheckedChanged);
            // 
            // gbPMTransactionButtons
            // 
            this.gbPMTransactionButtons.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbPMTransactionButtons.Controls.Add(this.BtnPMTreatmentReset);
            this.gbPMTransactionButtons.Controls.Add(this.BtnPMTreatmentExit);
            this.gbPMTransactionButtons.Controls.Add(this.BtnPMTreatmentSave);
            this.gbPMTransactionButtons.Location = new System.Drawing.Point(19, 591);
            this.gbPMTransactionButtons.Name = "gbPMTransactionButtons";
            this.gbPMTransactionButtons.Size = new System.Drawing.Size(966, 64);
            this.gbPMTransactionButtons.TabIndex = 64;
            this.gbPMTransactionButtons.TabStop = false;
            // 
            // BtnPMTreatmentReset
            // 
            this.BtnPMTreatmentReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMTreatmentReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMTreatmentReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMTreatmentReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMTreatmentReset.Location = new System.Drawing.Point(193, 17);
            this.BtnPMTreatmentReset.Name = "BtnPMTreatmentReset";
            this.BtnPMTreatmentReset.Size = new System.Drawing.Size(112, 28);
            this.BtnPMTreatmentReset.TabIndex = 7;
            this.BtnPMTreatmentReset.Text = "&Reset";
            this.BtnPMTreatmentReset.UseVisualStyleBackColor = false;
            this.BtnPMTreatmentReset.Click += new System.EventHandler(this.BtnPMTreatmentReset_Click);
            // 
            // BtnPMTreatmentExit
            // 
            this.BtnPMTreatmentExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMTreatmentExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMTreatmentExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMTreatmentExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMTreatmentExit.Location = new System.Drawing.Point(661, 19);
            this.BtnPMTreatmentExit.Name = "BtnPMTreatmentExit";
            this.BtnPMTreatmentExit.Size = new System.Drawing.Size(112, 28);
            this.BtnPMTreatmentExit.TabIndex = 6;
            this.BtnPMTreatmentExit.Text = "&Close";
            this.BtnPMTreatmentExit.UseVisualStyleBackColor = false;
            this.BtnPMTreatmentExit.Click += new System.EventHandler(this.BtnPMTreatmentExit_Click);
            // 
            // BtnPMTreatmentSave
            // 
            this.BtnPMTreatmentSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMTreatmentSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMTreatmentSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMTreatmentSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMTreatmentSave.Location = new System.Drawing.Point(427, 18);
            this.BtnPMTreatmentSave.Name = "BtnPMTreatmentSave";
            this.BtnPMTreatmentSave.Size = new System.Drawing.Size(112, 28);
            this.BtnPMTreatmentSave.TabIndex = 5;
            this.BtnPMTreatmentSave.Text = "&Save";
            this.BtnPMTreatmentSave.UseVisualStyleBackColor = false;
            this.BtnPMTreatmentSave.Click += new System.EventHandler(this.BtnPMTreatmentSave_Click);
            // 
            // gbPMTransactionStatus
            // 
            this.gbPMTransactionStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbPMTransactionStatus.Controls.Add(this.chkRejectComments);
            this.gbPMTransactionStatus.Controls.Add(this.RdoSendBackToSupplier);
            this.gbPMTransactionStatus.Controls.Add(this.RdoTreatment);
            this.gbPMTransactionStatus.Controls.Add(this.RdoAWD);
            this.gbPMTransactionStatus.Controls.Add(this.RdoReject);
            this.gbPMTransactionStatus.Controls.Add(this.RdoAccept);
            this.gbPMTransactionStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPMTransactionStatus.Location = new System.Drawing.Point(18, 511);
            this.gbPMTransactionStatus.Name = "gbPMTransactionStatus";
            this.gbPMTransactionStatus.Size = new System.Drawing.Size(968, 80);
            this.gbPMTransactionStatus.TabIndex = 65;
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
            this.chkRejectComments.Location = new System.Drawing.Point(351, 15);
            this.chkRejectComments.Name = "chkRejectComments";
            this.chkRejectComments.Size = new System.Drawing.Size(148, 50);
            this.chkRejectComments.TabIndex = 90;
            this.chkRejectComments.Visible = false;
            this.chkRejectComments.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkRejectComments_ItemCheck);
            this.chkRejectComments.Click += new System.EventHandler(this.chkRejectComments_Click);
            // 
            // RdoSendBackToSupplier
            // 
            this.RdoSendBackToSupplier.AutoSize = true;
            this.RdoSendBackToSupplier.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoSendBackToSupplier.Location = new System.Drawing.Point(91, 47);
            this.RdoSendBackToSupplier.Name = "RdoSendBackToSupplier";
            this.RdoSendBackToSupplier.Size = new System.Drawing.Size(151, 17);
            this.RdoSendBackToSupplier.TabIndex = 30;
            this.RdoSendBackToSupplier.Text = "Send BackTo Supplier";
            this.RdoSendBackToSupplier.UseVisualStyleBackColor = true;
            this.RdoSendBackToSupplier.CheckedChanged += new System.EventHandler(this.RdoSendBackToSupplier_CheckedChanged);
            // 
            // RdoTreatment
            // 
            this.RdoTreatment.AutoSize = true;
            this.RdoTreatment.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoTreatment.Location = new System.Drawing.Point(793, 15);
            this.RdoTreatment.Name = "RdoTreatment";
            this.RdoTreatment.Size = new System.Drawing.Size(84, 17);
            this.RdoTreatment.TabIndex = 29;
            this.RdoTreatment.Text = "Treatment";
            this.RdoTreatment.UseVisualStyleBackColor = true;
            this.RdoTreatment.Visible = false;
            // 
            // RdoAWD
            // 
            this.RdoAWD.AutoSize = true;
            this.RdoAWD.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoAWD.Location = new System.Drawing.Point(623, 15);
            this.RdoAWD.Name = "RdoAWD";
            this.RdoAWD.Size = new System.Drawing.Size(53, 17);
            this.RdoAWD.TabIndex = 28;
            this.RdoAWD.Text = "AWD";
            this.RdoAWD.UseVisualStyleBackColor = true;
            this.RdoAWD.Visible = false;
            // 
            // RdoReject
            // 
            this.RdoReject.AutoSize = true;
            this.RdoReject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoReject.Location = new System.Drawing.Point(279, 15);
            this.RdoReject.Name = "RdoReject";
            this.RdoReject.Size = new System.Drawing.Size(61, 17);
            this.RdoReject.TabIndex = 27;
            this.RdoReject.Text = "Reject";
            this.RdoReject.UseVisualStyleBackColor = true;
            this.RdoReject.CheckedChanged += new System.EventHandler(this.RdoReject_CheckedChanged);
            // 
            // RdoAccept
            // 
            this.RdoAccept.AutoSize = true;
            this.RdoAccept.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoAccept.Location = new System.Drawing.Point(92, 15);
            this.RdoAccept.Name = "RdoAccept";
            this.RdoAccept.Size = new System.Drawing.Size(63, 17);
            this.RdoAccept.TabIndex = 26;
            this.RdoAccept.Text = "Accept";
            this.RdoAccept.UseVisualStyleBackColor = true;
            this.RdoAccept.CheckedChanged += new System.EventHandler(this.RdoAccept_CheckedChanged);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(1006, 705);
            this.panelOuter.TabIndex = 133;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1004, 30);
            this.panelTop.TabIndex = 43;
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
            this.toolStrip1.Size = new System.Drawing.Size(1004, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(89, 27);
            this.toolStripLabel1.Text = "PM Treatment";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFill);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 8);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1004, 695);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.gbPMTransactionStatus);
            this.panelFill.Controls.Add(this.gbPMTransactionButtons);
            this.panelFill.Controls.Add(this.gbPMTreatmentdone);
            this.panelFill.Controls.Add(this.dgRMStatusChangeFields);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(1004, 695);
            this.panelFill.TabIndex = 133;
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
            // FrmPMTreatment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(990, 690);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1006, 705);
            this.Controls.Add(this.panelOuter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPMTreatment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PM Treatment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPMTreatment_Load);
            this.dgRMStatusChangeFields.ResumeLayout(false);
            this.dgRMStatusChangeFields.PerformLayout();
            this.gbPMTreatmentdone.ResumeLayout(false);
            this.gbPMTreatmentdone.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAllTests)).EndInit();
            this.gbPMTransactionButtons.ResumeLayout(false);
            this.gbPMTransactionStatus.ResumeLayout(false);
            this.gbPMTransactionStatus.PerformLayout();
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

        private System.Windows.Forms.GroupBox dgRMStatusChangeFields;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPMTreatmentReasonRejection;
        private System.Windows.Forms.ComboBox cmbPMTreatmentDetails;
        private System.Windows.Forms.Label lblPMTreatmentDetails;
        private System.Windows.Forms.GroupBox gbPMTreatmentdone;
        private System.Windows.Forms.RadioButton RdoPMTreatmentYes;
        private System.Windows.Forms.RadioButton RdoPMTransactionNo;
        private System.Windows.Forms.GroupBox gbPMTransactionButtons;
        private System.Windows.Forms.Button BtnPMTreatmentReset;
        private System.Windows.Forms.Button BtnPMTreatmentExit;
        private System.Windows.Forms.Button BtnPMTreatmentSave;
        private System.Windows.Forms.Label lblPMTreatmentQty;
        private System.Windows.Forms.DataGridView dgAllTests;
        private System.Windows.Forms.TextBox txtPMTreatmentQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGMethodNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestMethod;
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
        private System.Windows.Forms.TextBox txtRejectComment;
        private System.Windows.Forms.TextBox txtControlType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbPMTransactionStatus;
        private System.Windows.Forms.CheckedListBox chkRejectComments;
        private System.Windows.Forms.RadioButton RdoSendBackToSupplier;
        private System.Windows.Forms.RadioButton RdoTreatment;
        private System.Windows.Forms.RadioButton RdoAWD;
        private System.Windows.Forms.RadioButton RdoReject;
        private System.Windows.Forms.RadioButton RdoAccept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDefectQuantity;
        private System.Windows.Forms.Label lblPMTransactionReason;
        private System.Windows.Forms.ComboBox cmbDetectObserved;
        private System.Windows.Forms.TextBox txtDefectComment;
        private System.Windows.Forms.Label lblPMTransactionDetectNoteSend;
        private System.Windows.Forms.Label lblPMTransactionInspDate;
        private System.Windows.Forms.DateTimePicker DtpInspDate;
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