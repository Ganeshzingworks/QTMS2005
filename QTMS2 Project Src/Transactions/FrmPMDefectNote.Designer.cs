namespace QTMS.Transactions
{
    partial class FrmPMDefectNote
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
            frmPMDefectNote_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.grpremark = new System.Windows.Forms.GroupBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ChkLotComsumption = new System.Windows.Forms.CheckBox();
            this.ChkOnlineSorted = new System.Windows.Forms.CheckBox();
            this.txtPartlyQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.RdoPartly = new System.Windows.Forms.RadioButton();
            this.RdoComplete = new System.Windows.Forms.RadioButton();
            this.ChkLotReturn = new System.Windows.Forms.CheckBox();
            this.grpUserMail = new System.Windows.Forms.GroupBox();
            this.chkLstGroupName = new System.Windows.Forms.CheckedListBox();
            this.chkLstUserName = new System.Windows.Forms.CheckedListBox();
            this.gbFields = new System.Windows.Forms.GroupBox();
            this.dgDefect = new System.Windows.Forms.DataGridView();
            this.PMDefectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefectComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefectQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionTaken = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.QualityDecision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefectStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LineNumber = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoOfDefect = new System.Windows.Forms.TextBox();
            this.cmbDefectObserved = new System.Windows.Forms.ComboBox();
            this.lblPMTransactionDetectNoteSend = new System.Windows.Forms.Label();
            this.gbRMButtons = new System.Windows.Forms.GroupBox();
            this.BtnPMStatusChangeExit = new System.Windows.Forms.Button();
            this.BtnPMStatusChangeReset = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.BtnPMStatusChangeSave = new System.Windows.Forms.Button();
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
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.grpremark.SuspendLayout();
            this.grpUserMail.SuspendLayout();
            this.gbFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDefect)).BeginInit();
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
            this.panelOuter.Size = new System.Drawing.Size(1038, 900);
            this.panelOuter.TabIndex = 87;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1036, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(1036, 30);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(95, 27);
            this.toolStripLabel1.Text = "PM Defect Note";
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
            this.panelBottom.Size = new System.Drawing.Size(822, 773);
            this.panelBottom.TabIndex = 98;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.grpremark);
            this.panelFill.Controls.Add(this.grpUserMail);
            this.panelFill.Controls.Add(this.gbFields);
            this.panelFill.Controls.Add(this.gbRMButtons);
            this.panelFill.Controls.Add(this.dgRMStatusChangeFields);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(822, 773);
            this.panelFill.TabIndex = 0;
            // 
            // grpremark
            // 
            this.grpremark.Controls.Add(this.txtRemark);
            this.grpremark.Controls.Add(this.label8);
            this.grpremark.Controls.Add(this.ChkLotComsumption);
            this.grpremark.Controls.Add(this.ChkOnlineSorted);
            this.grpremark.Controls.Add(this.txtPartlyQuantity);
            this.grpremark.Controls.Add(this.lblQuantity);
            this.grpremark.Controls.Add(this.RdoPartly);
            this.grpremark.Controls.Add(this.RdoComplete);
            this.grpremark.Controls.Add(this.ChkLotReturn);
            this.grpremark.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpremark.Location = new System.Drawing.Point(16, 392);
            this.grpremark.Name = "grpremark";
            this.grpremark.Size = new System.Drawing.Size(791, 148);
            this.grpremark.TabIndex = 17;
            this.grpremark.TabStop = false;
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(152, 68);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(549, 74);
            this.txtRemark.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(91, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Remark";
            // 
            // ChkLotComsumption
            // 
            this.ChkLotComsumption.AutoSize = true;
            this.ChkLotComsumption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChkLotComsumption.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkLotComsumption.Location = new System.Drawing.Point(232, 42);
            this.ChkLotComsumption.Name = "ChkLotComsumption";
            this.ChkLotComsumption.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkLotComsumption.Size = new System.Drawing.Size(342, 20);
            this.ChkLotComsumption.TabIndex = 19;
            this.ChkLotComsumption.Text = "Lot Comsumption with heat on OEE/Productivity";
            this.ChkLotComsumption.UseVisualStyleBackColor = true;
            // 
            // ChkOnlineSorted
            // 
            this.ChkOnlineSorted.AutoSize = true;
            this.ChkOnlineSorted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChkOnlineSorted.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkOnlineSorted.Location = new System.Drawing.Point(89, 42);
            this.ChkOnlineSorted.Name = "ChkOnlineSorted";
            this.ChkOnlineSorted.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkOnlineSorted.Size = new System.Drawing.Size(113, 20);
            this.ChkOnlineSorted.TabIndex = 18;
            this.ChkOnlineSorted.Text = "Online Sorted";
            this.ChkOnlineSorted.UseVisualStyleBackColor = true;
            // 
            // txtPartlyQuantity
            // 
            this.txtPartlyQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartlyQuantity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartlyQuantity.Location = new System.Drawing.Point(581, 16);
            this.txtPartlyQuantity.Name = "txtPartlyQuantity";
            this.txtPartlyQuantity.Size = new System.Drawing.Size(120, 23);
            this.txtPartlyQuantity.TabIndex = 17;
            this.txtPartlyQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPartlyQuantity_KeyPress);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblQuantity.Location = new System.Drawing.Point(513, 19);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(65, 16);
            this.lblQuantity.TabIndex = 16;
            this.lblQuantity.Text = "Quantity";
            // 
            // RdoPartly
            // 
            this.RdoPartly.AutoSize = true;
            this.RdoPartly.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoPartly.Location = new System.Drawing.Point(409, 16);
            this.RdoPartly.Name = "RdoPartly";
            this.RdoPartly.Size = new System.Drawing.Size(64, 20);
            this.RdoPartly.TabIndex = 6;
            this.RdoPartly.Text = "Partly";
            this.RdoPartly.UseVisualStyleBackColor = true;
            this.RdoPartly.CheckedChanged += new System.EventHandler(this.RdoPartly_CheckedChanged);
            // 
            // RdoComplete
            // 
            this.RdoComplete.AutoSize = true;
            this.RdoComplete.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoComplete.Location = new System.Drawing.Point(312, 16);
            this.RdoComplete.Name = "RdoComplete";
            this.RdoComplete.Size = new System.Drawing.Size(87, 20);
            this.RdoComplete.TabIndex = 5;
            this.RdoComplete.Text = "Complete";
            this.RdoComplete.UseVisualStyleBackColor = true;
            // 
            // ChkLotReturn
            // 
            this.ChkLotReturn.AutoSize = true;
            this.ChkLotReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChkLotReturn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkLotReturn.Location = new System.Drawing.Point(89, 16);
            this.ChkLotReturn.Name = "ChkLotReturn";
            this.ChkLotReturn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkLotReturn.Size = new System.Drawing.Size(167, 20);
            this.ChkLotReturn.TabIndex = 4;
            this.ChkLotReturn.Text = "Lot Returned to store";
            this.ChkLotReturn.UseVisualStyleBackColor = true;
            this.ChkLotReturn.CheckedChanged += new System.EventHandler(this.ChkLotReturn_CheckedChanged);
            // 
            // grpUserMail
            // 
            this.grpUserMail.Controls.Add(this.chkLstGroupName);
            this.grpUserMail.Controls.Add(this.chkLstUserName);
            this.grpUserMail.Enabled = false;
            this.grpUserMail.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUserMail.Location = new System.Drawing.Point(18, 546);
            this.grpUserMail.Name = "grpUserMail";
            this.grpUserMail.Size = new System.Drawing.Size(788, 159);
            this.grpUserMail.TabIndex = 16;
            this.grpUserMail.TabStop = false;
            this.grpUserMail.Text = "Mail To User Name and Group Name";
            // 
            // chkLstGroupName
            // 
            this.chkLstGroupName.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkLstGroupName.FormattingEnabled = true;
            this.chkLstGroupName.Location = new System.Drawing.Point(417, 19);
            this.chkLstGroupName.Name = "chkLstGroupName";
            this.chkLstGroupName.Size = new System.Drawing.Size(368, 130);
            this.chkLstGroupName.TabIndex = 78;
            // 
            // chkLstUserName
            // 
            this.chkLstUserName.CheckOnClick = true;
            this.chkLstUserName.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkLstUserName.FormattingEnabled = true;
            this.chkLstUserName.Location = new System.Drawing.Point(3, 19);
            this.chkLstUserName.MultiColumn = true;
            this.chkLstUserName.Name = "chkLstUserName";
            this.chkLstUserName.Size = new System.Drawing.Size(404, 130);
            this.chkLstUserName.TabIndex = 77;
            // 
            // gbFields
            // 
            this.gbFields.Controls.Add(this.dgDefect);
            this.gbFields.Controls.Add(this.label5);
            this.gbFields.Controls.Add(this.txtNoOfDefect);
            this.gbFields.Controls.Add(this.cmbDefectObserved);
            this.gbFields.Controls.Add(this.lblPMTransactionDetectNoteSend);
            this.gbFields.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFields.Location = new System.Drawing.Point(15, 144);
            this.gbFields.Name = "gbFields";
            this.gbFields.Size = new System.Drawing.Size(791, 246);
            this.gbFields.TabIndex = 1;
            this.gbFields.TabStop = false;
            // 
            // dgDefect
            // 
            this.dgDefect.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgDefect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDefect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgDefect.ColumnHeadersHeight = 25;
            this.dgDefect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PMDefectID,
            this.DefectComment,
            this.DefectQuantity,
            this.ActionTaken,
            this.QualityDecision,
            this.DefectStatus,
            this.LineNumber});
            this.dgDefect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgDefect.Location = new System.Drawing.Point(3, 50);
            this.dgDefect.MultiSelect = false;
            this.dgDefect.Name = "dgDefect";
            this.dgDefect.RowHeadersWidth = 20;
            this.dgDefect.Size = new System.Drawing.Size(785, 193);
            this.dgDefect.TabIndex = 4;
            this.dgDefect.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDefect_CellValueChanged);
            this.dgDefect.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgDefect_DataError);
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
            this.DefectComment.Width = 200;
            // 
            // DefectQuantity
            // 
            this.DefectQuantity.HeaderText = "Defect Quantity";
            this.DefectQuantity.Name = "DefectQuantity";
            this.DefectQuantity.Width = 110;
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
            this.ActionTaken.Width = 260;
            // 
            // QualityDecision
            // 
            this.QualityDecision.HeaderText = "QualityDecision";
            this.QualityDecision.Name = "QualityDecision";
            this.QualityDecision.Visible = false;
            // 
            // DefectStatus
            // 
            this.DefectStatus.HeaderText = "Status";
            this.DefectStatus.Items.AddRange(new object[] {
            "Open",
            "Close"});
            this.DefectStatus.Name = "DefectStatus";
            this.DefectStatus.Width = 80;
            // 
            // LineNumber
            // 
            this.LineNumber.HeaderText = "Line Number";
            this.LineNumber.Name = "LineNumber";
            this.LineNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LineNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LineNumber.Width = 110;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(234, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "No of Defect";
            // 
            // txtNoOfDefect
            // 
            this.txtNoOfDefect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfDefect.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfDefect.Location = new System.Drawing.Point(329, 20);
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
            this.cmbDefectObserved.Location = new System.Drawing.Point(129, 19);
            this.cmbDefectObserved.Name = "cmbDefectObserved";
            this.cmbDefectObserved.Size = new System.Drawing.Size(101, 24);
            this.cmbDefectObserved.TabIndex = 1;
            this.cmbDefectObserved.SelectedIndexChanged += new System.EventHandler(this.cmbDefectObserved_SelectedIndexChanged);
            // 
            // lblPMTransactionDetectNoteSend
            // 
            this.lblPMTransactionDetectNoteSend.AutoSize = true;
            this.lblPMTransactionDetectNoteSend.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMTransactionDetectNoteSend.Location = new System.Drawing.Point(6, 23);
            this.lblPMTransactionDetectNoteSend.Name = "lblPMTransactionDetectNoteSend";
            this.lblPMTransactionDetectNoteSend.Size = new System.Drawing.Size(120, 16);
            this.lblPMTransactionDetectNoteSend.TabIndex = 0;
            this.lblPMTransactionDetectNoteSend.Text = "Detect Observed";
            // 
            // gbRMButtons
            // 
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeExit);
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeReset);
            this.gbRMButtons.Controls.Add(this.btnSend);
            this.gbRMButtons.Controls.Add(this.BtnPMStatusChangeSave);
            this.gbRMButtons.Location = new System.Drawing.Point(15, 708);
            this.gbRMButtons.Name = "gbRMButtons";
            this.gbRMButtons.Size = new System.Drawing.Size(792, 46);
            this.gbRMButtons.TabIndex = 2;
            this.gbRMButtons.TabStop = false;
            // 
            // BtnPMStatusChangeExit
            // 
            this.BtnPMStatusChangeExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMStatusChangeExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMStatusChangeExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMStatusChangeExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMStatusChangeExit.Location = new System.Drawing.Point(420, 10);
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
            this.BtnPMStatusChangeReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMStatusChangeReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMStatusChangeReset.Location = new System.Drawing.Point(119, 10);
            this.BtnPMStatusChangeReset.Name = "BtnPMStatusChangeReset";
            this.BtnPMStatusChangeReset.Size = new System.Drawing.Size(109, 32);
            this.BtnPMStatusChangeReset.TabIndex = 0;
            this.BtnPMStatusChangeReset.Text = "&Reset";
            this.BtnPMStatusChangeReset.UseVisualStyleBackColor = false;
            this.BtnPMStatusChangeReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSend.Enabled = false;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSend.Location = new System.Drawing.Point(564, 10);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(181, 32);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Save and Send Mail";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // BtnPMStatusChangeSave
            // 
            this.BtnPMStatusChangeSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMStatusChangeSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMStatusChangeSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMStatusChangeSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMStatusChangeSave.Location = new System.Drawing.Point(270, 10);
            this.BtnPMStatusChangeSave.Name = "BtnPMStatusChangeSave";
            this.BtnPMStatusChangeSave.Size = new System.Drawing.Size(109, 32);
            this.BtnPMStatusChangeSave.TabIndex = 1;
            this.BtnPMStatusChangeSave.Text = "&Save";
            this.BtnPMStatusChangeSave.UseVisualStyleBackColor = false;
            this.BtnPMStatusChangeSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            this.dgRMStatusChangeFields.Location = new System.Drawing.Point(15, 2);
            this.dgRMStatusChangeFields.Name = "dgRMStatusChangeFields";
            this.dgRMStatusChangeFields.Size = new System.Drawing.Size(791, 142);
            this.dgRMStatusChangeFields.TabIndex = 0;
            this.dgRMStatusChangeFields.TabStop = false;
            // 
            // txtCOC
            // 
            this.txtCOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCOC.Enabled = false;
            this.txtCOC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCOC.Location = new System.Drawing.Point(625, 83);
            this.txtCOC.Name = "txtCOC";
            this.txtCOC.Size = new System.Drawing.Size(120, 23);
            this.txtCOC.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label4.Location = new System.Drawing.Point(584, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "COC";
            // 
            // cmbPlantLotNo
            // 
            this.cmbPlantLotNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlantLotNo.FormattingEnabled = true;
            this.cmbPlantLotNo.Location = new System.Drawing.Point(363, 21);
            this.cmbPlantLotNo.Name = "cmbPlantLotNo";
            this.cmbPlantLotNo.Size = new System.Drawing.Size(132, 24);
            this.cmbPlantLotNo.TabIndex = 3;
            this.cmbPlantLotNo.SelectionChangeCommitted += new System.EventHandler(this.cmbPlantLotNo_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label6.Location = new System.Drawing.Point(42, 85);
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
            this.txtSupplier.Location = new System.Drawing.Point(128, 83);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(367, 23);
            this.txtSupplier.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label2.Location = new System.Drawing.Point(42, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(273, 24);
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
            this.txtDesc.Location = new System.Drawing.Point(128, 53);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(367, 23);
            this.txtDesc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(547, 26);
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
            this.DtpInspDate.Location = new System.Drawing.Point(625, 23);
            this.DtpInspDate.Name = "DtpInspDate";
            this.DtpInspDate.Size = new System.Drawing.Size(120, 23);
            this.DtpInspDate.TabIndex = 9;
            this.DtpInspDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // lblPMTransactionAcceptedDate
            // 
            this.lblPMTransactionAcceptedDate.AutoSize = true;
            this.lblPMTransactionAcceptedDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMTransactionAcceptedDate.Location = new System.Drawing.Point(513, 55);
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
            this.DtpAcceptedDate.Location = new System.Drawing.Point(625, 53);
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
            this.txtQuantity.Location = new System.Drawing.Point(625, 112);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(120, 23);
            this.txtQuantity.TabIndex = 15;
            // 
            // lblPMStatusChangeQtyReceived
            // 
            this.lblPMStatusChangeQtyReceived.AutoSize = true;
            this.lblPMStatusChangeQtyReceived.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMStatusChangeQtyReceived.Location = new System.Drawing.Point(530, 114);
            this.lblPMStatusChangeQtyReceived.Name = "lblPMStatusChangeQtyReceived";
            this.lblPMStatusChangeQtyReceived.Size = new System.Drawing.Size(91, 16);
            this.lblPMStatusChangeQtyReceived.TabIndex = 14;
            this.lblPMStatusChangeQtyReceived.Text = "Lot Quantity";
            // 
            // cmbPMCode
            // 
            this.cmbPMCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPMCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPMCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPMCode.FormattingEnabled = true;
            this.cmbPMCode.Location = new System.Drawing.Point(129, 21);
            this.cmbPMCode.Name = "cmbPMCode";
            this.cmbPMCode.Size = new System.Drawing.Size(132, 24);
            this.cmbPMCode.TabIndex = 1;
            this.cmbPMCode.SelectionChangeCommitted += new System.EventHandler(this.cmbPMCode_SelectionChangeCommitted);
            // 
            // lblPMCode
            // 
            this.lblPMCode.AutoSize = true;
            this.lblPMCode.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMCode.Location = new System.Drawing.Point(42, 26);
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
            // FrmPMDefectNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1038, 900);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(895, 749);
            this.Controls.Add(this.panelOuter);
            this.Name = "FrmPMDefectNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PM Defect Note";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPMDefectNote_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.grpremark.ResumeLayout(false);
            this.grpremark.PerformLayout();
            this.grpUserMail.ResumeLayout(false);
            this.gbFields.ResumeLayout(false);
            this.gbFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDefect)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn PMDefectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefectComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefectQuantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn ActionTaken;
        private System.Windows.Forms.DataGridViewTextBoxColumn QualityDecision;
        private System.Windows.Forms.DataGridViewComboBoxColumn DefectStatus;
        private System.Windows.Forms.DataGridViewComboBoxColumn LineNumber;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox grpUserMail;
        private System.Windows.Forms.CheckedListBox chkLstUserName;
        private System.Windows.Forms.CheckedListBox chkLstGroupName;
        private System.Windows.Forms.GroupBox grpremark;
        private System.Windows.Forms.CheckBox ChkLotReturn;
        private System.Windows.Forms.TextBox txtPartlyQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.RadioButton RdoPartly;
        private System.Windows.Forms.RadioButton RdoComplete;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ChkLotComsumption;
        private System.Windows.Forms.CheckBox ChkOnlineSorted;
    }
}