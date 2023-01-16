namespace QTMS.Transactions
{
    partial class FrmReagentTransaction 
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
            FrmReagentTransaction_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnlviewfile = new System.Windows.Forms.LinkLabel();
            this.cmbInspectedBy = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtcomments = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnUploadCOA = new System.Windows.Forms.Button();
            this.dtpValidityDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpMfgDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbPONumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTransDate = new System.Windows.Forms.DateTimePicker();
            this.lblNormalityUnit = new System.Windows.Forms.Label();
            this.cmbRACode = new System.Windows.Forms.ComboBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.txtReagentNormality = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.txtNoOfUnits = new System.Windows.Forms.TextBox();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.lblRNormality = new System.Windows.Forms.Label();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtReagentName = new System.Windows.Forms.TextBox();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.lblNoOfUnits = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblRagentDate = new System.Windows.Forms.Label();
            this.lblNormUnit = new System.Windows.Forms.Label();
            this.lblLot = new System.Windows.Forms.Label();
            this.lblRACode = new System.Windows.Forms.Label();
            this.lblReagentName = new System.Windows.Forms.Label();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.BtnExit = new System.Windows.Forms.Button();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.openFileDialogCOA = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnReset
            // 
            this.BtnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(300, 19);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(88, 26);
            this.BtnReset.TabIndex = 11;
            this.BtnReset.Text = "&Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnlviewfile);
            this.groupBox1.Controls.Add(this.cmbInspectedBy);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtcomments);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblFileName);
            this.groupBox1.Controls.Add(this.btnUploadCOA);
            this.groupBox1.Controls.Add(this.dtpValidityDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpMfgDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbPONumber);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpTransDate);
            this.groupBox1.Controls.Add(this.lblNormalityUnit);
            this.groupBox1.Controls.Add(this.cmbRACode);
            this.groupBox1.Controls.Add(this.cmbUnit);
            this.groupBox1.Controls.Add(this.txtReagentNormality);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.txtTotalQty);
            this.groupBox1.Controls.Add(this.txtNoOfUnits);
            this.groupBox1.Controls.Add(this.txtSupplierName);
            this.groupBox1.Controls.Add(this.lblRNormality);
            this.groupBox1.Controls.Add(this.txtLotNo);
            this.groupBox1.Controls.Add(this.lblQty);
            this.groupBox1.Controls.Add(this.txtReagentName);
            this.groupBox1.Controls.Add(this.lblTotalQty);
            this.groupBox1.Controls.Add(this.lblNoOfUnits);
            this.groupBox1.Controls.Add(this.lblSupplierName);
            this.groupBox1.Controls.Add(this.lblRagentDate);
            this.groupBox1.Controls.Add(this.lblNormUnit);
            this.groupBox1.Controls.Add(this.lblLot);
            this.groupBox1.Controls.Add(this.lblRACode);
            this.groupBox1.Controls.Add(this.lblReagentName);
            this.groupBox1.Location = new System.Drawing.Point(30, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(976, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lnlviewfile
            // 
            this.lnlviewfile.AutoSize = true;
            this.lnlviewfile.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlviewfile.Location = new System.Drawing.Point(770, 79);
            this.lnlviewfile.Name = "lnlviewfile";
            this.lnlviewfile.Size = new System.Drawing.Size(66, 16);
            this.lnlviewfile.TabIndex = 30;
            this.lnlviewfile.TabStop = true;
            this.lnlviewfile.Text = "View File";
            this.lnlviewfile.Visible = false;
            this.lnlviewfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnlviewfile_LinkClicked);
            // 
            // cmbInspectedBy
            // 
            this.cmbInspectedBy.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbInspectedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInspectedBy.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInspectedBy.FormattingEnabled = true;
            this.cmbInspectedBy.Items.AddRange(new object[] {
            "--Select--"});
            this.cmbInspectedBy.Location = new System.Drawing.Point(769, 157);
            this.cmbInspectedBy.Name = "cmbInspectedBy";
            this.cmbInspectedBy.Size = new System.Drawing.Size(189, 24);
            this.cmbInspectedBy.TabIndex = 29;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(660, 161);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(106, 16);
            this.label20.TabIndex = 28;
            this.label20.Text = "Inspected By :";
            // 
            // txtcomments
            // 
            this.txtcomments.BackColor = System.Drawing.Color.White;
            this.txtcomments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcomments.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcomments.Location = new System.Drawing.Point(153, 161);
            this.txtcomments.MaxLength = 50;
            this.txtcomments.Name = "txtcomments";
            this.txtcomments.Size = new System.Drawing.Size(505, 23);
            this.txtcomments.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Comments :";
            // 
            // lblFileName
            // 
            this.lblFileName.BackColor = System.Drawing.Color.White;
            this.lblFileName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblFileName.Location = new System.Drawing.Point(502, 73);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(264, 23);
            this.lblFileName.TabIndex = 25;
            // 
            // btnUploadCOA
            // 
            this.btnUploadCOA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnUploadCOA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadCOA.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadCOA.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnUploadCOA.Location = new System.Drawing.Point(354, 72);
            this.btnUploadCOA.Name = "btnUploadCOA";
            this.btnUploadCOA.Size = new System.Drawing.Size(142, 24);
            this.btnUploadCOA.TabIndex = 24;
            this.btnUploadCOA.Text = "Upload COA(.pdf)";
            this.btnUploadCOA.UseVisualStyleBackColor = false;
            this.btnUploadCOA.Click += new System.EventHandler(this.btnUploadCOA_Click);
            // 
            // dtpValidityDate
            // 
            this.dtpValidityDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpValidityDate.Checked = false;
            this.dtpValidityDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpValidityDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpValidityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpValidityDate.Location = new System.Drawing.Point(153, 73);
            this.dtpValidityDate.Name = "dtpValidityDate";
            this.dtpValidityDate.ShowCheckBox = true;
            this.dtpValidityDate.Size = new System.Drawing.Size(160, 23);
            this.dtpValidityDate.TabIndex = 16;
            this.dtpValidityDate.Value = new System.DateTime(2008, 1, 19, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Validity Date :";
            // 
            // dtpMfgDate
            // 
            this.dtpMfgDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpMfgDate.Checked = false;
            this.dtpMfgDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpMfgDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMfgDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMfgDate.Location = new System.Drawing.Point(769, 43);
            this.dtpMfgDate.Name = "dtpMfgDate";
            this.dtpMfgDate.ShowCheckBox = true;
            this.dtpMfgDate.Size = new System.Drawing.Size(189, 23);
            this.dtpMfgDate.TabIndex = 14;
            this.dtpMfgDate.Value = new System.DateTime(2008, 1, 19, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(687, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mfg Date :";
            // 
            // CmbPONumber
            // 
            this.CmbPONumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPONumber.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.CmbPONumber.FormattingEnabled = true;
            this.CmbPONumber.Location = new System.Drawing.Point(153, 44);
            this.CmbPONumber.Name = "CmbPONumber";
            this.CmbPONumber.Size = new System.Drawing.Size(160, 24);
            this.CmbPONumber.TabIndex = 11;
            this.CmbPONumber.SelectionChangeCommitted += new System.EventHandler(this.CmbPONumber_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "PO Number :";
            // 
            // dtpTransDate
            // 
            this.dtpTransDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTransDate.Checked = false;
            this.dtpTransDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpTransDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransDate.Location = new System.Drawing.Point(153, 132);
            this.dtpTransDate.Name = "dtpTransDate";
            this.dtpTransDate.ShowCheckBox = true;
            this.dtpTransDate.Size = new System.Drawing.Size(160, 23);
            this.dtpTransDate.TabIndex = 5;
            this.dtpTransDate.Value = new System.DateTime(2008, 1, 19, 0, 0, 0, 0);
            this.dtpTransDate.Leave += new System.EventHandler(this.dtpTransDate_Leave);
            // 
            // lblNormalityUnit
            // 
            this.lblNormalityUnit.AutoSize = true;
            this.lblNormalityUnit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNormalityUnit.Location = new System.Drawing.Point(721, 134);
            this.lblNormalityUnit.Name = "lblNormalityUnit";
            this.lblNormalityUnit.Size = new System.Drawing.Size(45, 16);
            this.lblNormalityUnit.TabIndex = 7;
            this.lblNormalityUnit.Text = "Unit :";
            // 
            // cmbRACode
            // 
            this.cmbRACode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRACode.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.cmbRACode.FormattingEnabled = true;
            this.cmbRACode.Location = new System.Drawing.Point(153, 16);
            this.cmbRACode.Name = "cmbRACode";
            this.cmbRACode.Size = new System.Drawing.Size(160, 24);
            this.cmbRACode.TabIndex = 1;
            this.cmbRACode.SelectionChangeCommitted += new System.EventHandler(this.cmbRACode_SelectionChangeCommitted);
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(233, 102);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(80, 24);
            this.cmbUnit.TabIndex = 7;
            // 
            // txtReagentNormality
            // 
            this.txtReagentNormality.BackColor = System.Drawing.Color.White;
            this.txtReagentNormality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReagentNormality.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReagentNormality.Location = new System.Drawing.Point(469, 132);
            this.txtReagentNormality.MaxLength = 50;
            this.txtReagentNormality.Name = "txtReagentNormality";
            this.txtReagentNormality.Size = new System.Drawing.Size(160, 23);
            this.txtReagentNormality.TabIndex = 10;
            this.txtReagentNormality.Leave += new System.EventHandler(this.txtReagentNormality_Leave);
            this.txtReagentNormality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReagentNormality_KeyPress);
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.White;
            this.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(153, 102);
            this.txtQty.MaxLength = 50;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(74, 23);
            this.txtQty.TabIndex = 6;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BackColor = System.Drawing.Color.White;
            this.txtTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.Location = new System.Drawing.Point(769, 102);
            this.txtTotalQty.MaxLength = 50;
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(189, 23);
            this.txtTotalQty.TabIndex = 9;
            // 
            // txtNoOfUnits
            // 
            this.txtNoOfUnits.BackColor = System.Drawing.Color.White;
            this.txtNoOfUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfUnits.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfUnits.Location = new System.Drawing.Point(469, 103);
            this.txtNoOfUnits.MaxLength = 50;
            this.txtNoOfUnits.Name = "txtNoOfUnits";
            this.txtNoOfUnits.Size = new System.Drawing.Size(97, 23);
            this.txtNoOfUnits.TabIndex = 8;
            this.txtNoOfUnits.TextChanged += new System.EventHandler(this.txtNoOfUnits_TextChanged);
            this.txtNoOfUnits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoOfUnits_KeyPress);
            this.txtNoOfUnits.Enter += new System.EventHandler(this.txtNoOfUnits_Enter);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.BackColor = System.Drawing.Color.White;
            this.txtSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Location = new System.Drawing.Point(469, 46);
            this.txtSupplierName.MaxLength = 50;
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(189, 23);
            this.txtSupplierName.TabIndex = 3;
            // 
            // lblRNormality
            // 
            this.lblRNormality.AutoSize = true;
            this.lblRNormality.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRNormality.Location = new System.Drawing.Point(330, 136);
            this.lblRNormality.Name = "lblRNormality";
            this.lblRNormality.Size = new System.Drawing.Size(136, 16);
            this.lblRNormality.TabIndex = 3;
            this.lblRNormality.Text = "Reagent Strength :";
            // 
            // txtLotNo
            // 
            this.txtLotNo.BackColor = System.Drawing.Color.White;
            this.txtLotNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLotNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotNo.Location = new System.Drawing.Point(769, 16);
            this.txtLotNo.MaxLength = 50;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(189, 23);
            this.txtLotNo.TabIndex = 4;
            this.txtLotNo.Leave += new System.EventHandler(this.txtLotNo_Leave);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(16, 105);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(133, 16);
            this.lblQty.TabIndex = 3;
            this.lblQty.Text = "Quantity per Unit :";
            // 
            // txtReagentName
            // 
            this.txtReagentName.BackColor = System.Drawing.Color.White;
            this.txtReagentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReagentName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReagentName.Location = new System.Drawing.Point(469, 16);
            this.txtReagentName.MaxLength = 50;
            this.txtReagentName.Name = "txtReagentName";
            this.txtReagentName.ReadOnly = true;
            this.txtReagentName.Size = new System.Drawing.Size(189, 23);
            this.txtReagentName.TabIndex = 2;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.Location = new System.Drawing.Point(588, 105);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(178, 16);
            this.lblTotalQty.TabIndex = 3;
            this.lblTotalQty.Text = "Total Quantity Received :";
            // 
            // lblNoOfUnits
            // 
            this.lblNoOfUnits.AutoSize = true;
            this.lblNoOfUnits.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfUnits.Location = new System.Drawing.Point(364, 106);
            this.lblNoOfUnits.Name = "lblNoOfUnits";
            this.lblNoOfUnits.Size = new System.Drawing.Size(102, 16);
            this.lblNoOfUnits.TabIndex = 3;
            this.lblNoOfUnits.Text = "No. of Units  :";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierName.Location = new System.Drawing.Point(354, 48);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(112, 16);
            this.lblSupplierName.TabIndex = 3;
            this.lblSupplierName.Text = "Supplier Name :";
            // 
            // lblRagentDate
            // 
            this.lblRagentDate.AutoSize = true;
            this.lblRagentDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRagentDate.Location = new System.Drawing.Point(43, 135);
            this.lblRagentDate.Name = "lblRagentDate";
            this.lblRagentDate.Size = new System.Drawing.Size(106, 16);
            this.lblRagentDate.TabIndex = 3;
            this.lblRagentDate.Text = "Receive Date :";
            // 
            // lblNormUnit
            // 
            this.lblNormUnit.AutoSize = true;
            this.lblNormUnit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNormUnit.Location = new System.Drawing.Point(779, 135);
            this.lblNormUnit.Name = "lblNormUnit";
            this.lblNormUnit.Size = new System.Drawing.Size(15, 16);
            this.lblNormUnit.TabIndex = 3;
            this.lblNormUnit.Text = "-";
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLot.Location = new System.Drawing.Point(699, 20);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(67, 16);
            this.lblLot.TabIndex = 3;
            this.lblLot.Text = "Lot No. :";
            // 
            // lblRACode
            // 
            this.lblRACode.AutoSize = true;
            this.lblRACode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRACode.Location = new System.Drawing.Point(75, 20);
            this.lblRACode.Name = "lblRACode";
            this.lblRACode.Size = new System.Drawing.Size(74, 16);
            this.lblRACode.TabIndex = 3;
            this.lblRACode.Text = "RA Code :";
            // 
            // lblReagentName
            // 
            this.lblReagentName.AutoSize = true;
            this.lblReagentName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReagentName.Location = new System.Drawing.Point(352, 20);
            this.lblReagentName.Name = "lblReagentName";
            this.lblReagentName.Size = new System.Drawing.Size(114, 16);
            this.lblReagentName.TabIndex = 3;
            this.lblReagentName.Text = "Reagent Name :";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.BackColor = System.Drawing.Color.White;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::QTMS.Properties.Resources.cancel;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 27);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(555, 19);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(88, 26);
            this.BtnExit.TabIndex = 13;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(144, 27);
            this.toolStripLabel2.Text = "Reagent Transaction";
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(1038, 378);
            this.panelFill.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(30, 306);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(976, 56);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(428, 19);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(88, 26);
            this.BtnSave.TabIndex = 12;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1038, 30);
            this.panelTop.TabIndex = 42;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripLabel2});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1038, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFill);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, -58);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1038, 378);
            this.panelBottom.TabIndex = 0;
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(1040, 322);
            this.panelOuter.TabIndex = 6;
            // 
            // openFileDialogCOA
            // 
            this.openFileDialogCOA.FileName = "openFileDialog1";
            // 
            // FrmReagentTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1040, 322);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReagentTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReagentTransaction";
            this.Load += new System.EventHandler(this.FrmReagentMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelFill.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtReagentName;
        private System.Windows.Forms.Label lblReagentName;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Label lblNormalityUnit;
        private System.Windows.Forms.Label lblRagentDate;
        private System.Windows.Forms.Label lblRACode;
        private System.Windows.Forms.ComboBox cmbRACode;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtLotNo;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblLot;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.TextBox txtNoOfUnits;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblNoOfUnits;
        private System.Windows.Forms.TextBox txtReagentNormality;
        private System.Windows.Forms.Label lblRNormality;
        private System.Windows.Forms.DateTimePicker dtpTransDate;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label lblNormUnit;
        private System.Windows.Forms.ComboBox CmbPONumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpValidityDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpMfgDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnUploadCOA;
        private System.Windows.Forms.TextBox txtcomments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbInspectedBy;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.OpenFileDialog openFileDialogCOA;
        private System.Windows.Forms.LinkLabel lnlviewfile;

    }
}