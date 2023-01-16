namespace QTMS.Transactions
{
    partial class FrmReagentStandardazation   
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
            FrmReagentStandardazation_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.dtpValidityDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtpTransDate = new System.Windows.Forms.DateTimePicker();
            this.txtStdNormality = new System.Windows.Forms.TextBox();
            this.lblNormalityUnit = new System.Windows.Forms.Label();
            this.cmbJar = new System.Windows.Forms.ComboBox();
            this.cmbRACode = new System.Windows.Forms.ComboBox();
            this.cmbLot = new System.Windows.Forms.ComboBox();
            this.lblValidityDate = new System.Windows.Forms.Label();
            this.lblStdNormality = new System.Windows.Forms.Label();
            this.lblRACode = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblLot = new System.Windows.Forms.Label();
            this.lblJar = new System.Windows.Forms.Label();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.btnPMExit = new System.Windows.Forms.Button();
            this.btnPMSave = new System.Windows.Forms.Button();
            this.btnStdReset = new System.Windows.Forms.Button();
            this.gbPMSupplierCOCFields = new System.Windows.Forms.GroupBox();
            this.dgvReagentStd = new System.Windows.Forms.DataGridView();
            this.ReagentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReagentTransID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReagentBottleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StdDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormalityUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidityDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.gbButtons.SuspendLayout();
            this.gbPMSupplierCOCFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReagentStd)).BeginInit();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnReset);
            this.groupBox1.Controls.Add(this.dtpValidityDate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.dtpTransDate);
            this.groupBox1.Controls.Add(this.txtStdNormality);
            this.groupBox1.Controls.Add(this.lblNormalityUnit);
            this.groupBox1.Controls.Add(this.cmbJar);
            this.groupBox1.Controls.Add(this.cmbRACode);
            this.groupBox1.Controls.Add(this.cmbLot);
            this.groupBox1.Controls.Add(this.lblValidityDate);
            this.groupBox1.Controls.Add(this.lblStdNormality);
            this.groupBox1.Controls.Add(this.lblRACode);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblLot);
            this.groupBox1.Controls.Add(this.lblJar);
            this.groupBox1.Location = new System.Drawing.Point(15, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(809, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BtnReset
            // 
            this.BtnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(341, 116);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(60, 26);
            this.BtnReset.TabIndex = 7;
            this.BtnReset.Text = "&Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // dtpValidityDate
            // 
            this.dtpValidityDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpValidityDate.Checked = false;
            this.dtpValidityDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpValidityDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpValidityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpValidityDate.Location = new System.Drawing.Point(352, 70);
            this.dtpValidityDate.Name = "dtpValidityDate";
            this.dtpValidityDate.ShowCheckBox = true;
            this.dtpValidityDate.Size = new System.Drawing.Size(130, 23);
            this.dtpValidityDate.TabIndex = 6;
            this.dtpValidityDate.Value = new System.DateTime(2008, 1, 19, 0, 0, 0, 0);
            this.dtpValidityDate.Leave += new System.EventHandler(this.dtpValidityDate_Leave);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.Location = new System.Drawing.Point(445, 116);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 26);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtpTransDate
            // 
            this.dtpTransDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTransDate.Checked = false;
            this.dtpTransDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpTransDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransDate.Location = new System.Drawing.Point(98, 70);
            this.dtpTransDate.Name = "dtpTransDate";
            this.dtpTransDate.ShowCheckBox = true;
            this.dtpTransDate.Size = new System.Drawing.Size(130, 23);
            this.dtpTransDate.TabIndex = 4;
            this.dtpTransDate.Value = new System.DateTime(2008, 1, 19, 0, 0, 0, 0);
            this.dtpTransDate.Leave += new System.EventHandler(this.dtpTransDate_Leave);
            // 
            // txtStdNormality
            // 
            this.txtStdNormality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStdNormality.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStdNormality.Location = new System.Drawing.Point(678, 70);
            this.txtStdNormality.Name = "txtStdNormality";
            this.txtStdNormality.Size = new System.Drawing.Size(78, 23);
            this.txtStdNormality.TabIndex = 5;
            this.txtStdNormality.Leave += new System.EventHandler(this.txtStdNormality_Leave);
            this.txtStdNormality.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStdNormality_KeyPress);
            // 
            // lblNormalityUnit
            // 
            this.lblNormalityUnit.AutoSize = true;
            this.lblNormalityUnit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNormalityUnit.Location = new System.Drawing.Point(762, 66);
            this.lblNormalityUnit.Name = "lblNormalityUnit";
            this.lblNormalityUnit.Size = new System.Drawing.Size(33, 16);
            this.lblNormalityUnit.TabIndex = 7;
            this.lblNormalityUnit.Text = "unit";
            // 
            // cmbJar
            // 
            this.cmbJar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJar.FormattingEnabled = true;
            this.cmbJar.Location = new System.Drawing.Point(678, 16);
            this.cmbJar.Name = "cmbJar";
            this.cmbJar.Size = new System.Drawing.Size(78, 21);
            this.cmbJar.TabIndex = 3;
            // 
            // cmbRACode
            // 
            this.cmbRACode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRACode.FormattingEnabled = true;
            this.cmbRACode.Items.AddRange(new object[] {
            "Y",
            "M"});
            this.cmbRACode.Location = new System.Drawing.Point(98, 16);
            this.cmbRACode.Name = "cmbRACode";
            this.cmbRACode.Size = new System.Drawing.Size(130, 21);
            this.cmbRACode.TabIndex = 1;
            this.cmbRACode.SelectionChangeCommitted += new System.EventHandler(this.cmbRACode_SelectionChangeCommitted);
            // 
            // cmbLot
            // 
            this.cmbLot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLot.FormattingEnabled = true;
            this.cmbLot.Location = new System.Drawing.Point(352, 16);
            this.cmbLot.Name = "cmbLot";
            this.cmbLot.Size = new System.Drawing.Size(142, 21);
            this.cmbLot.TabIndex = 2;
            this.cmbLot.SelectionChangeCommitted += new System.EventHandler(this.cmbLot_SelectionChangeCommitted);
            // 
            // lblValidityDate
            // 
            this.lblValidityDate.AutoSize = true;
            this.lblValidityDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidityDate.Location = new System.Drawing.Point(246, 72);
            this.lblValidityDate.Name = "lblValidityDate";
            this.lblValidityDate.Size = new System.Drawing.Size(103, 16);
            this.lblValidityDate.TabIndex = 3;
            this.lblValidityDate.Text = "Validity Date :";
            // 
            // lblStdNormality
            // 
            this.lblStdNormality.AutoSize = true;
            this.lblStdNormality.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStdNormality.Location = new System.Drawing.Point(521, 72);
            this.lblStdNormality.Name = "lblStdNormality";
            this.lblStdNormality.Size = new System.Drawing.Size(150, 16);
            this.lblStdNormality.TabIndex = 3;
            this.lblStdNormality.Text = "Standard  Normality :";
            // 
            // lblRACode
            // 
            this.lblRACode.AutoSize = true;
            this.lblRACode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRACode.Location = new System.Drawing.Point(6, 21);
            this.lblRACode.Name = "lblRACode";
            this.lblRACode.Size = new System.Drawing.Size(69, 16);
            this.lblRACode.TabIndex = 3;
            this.lblRACode.Text = "RACode :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(6, 72);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(83, 16);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Std. Date :";
            // 
            // lblLot
            // 
            this.lblLot.AutoSize = true;
            this.lblLot.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLot.Location = new System.Drawing.Point(246, 21);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(67, 16);
            this.lblLot.TabIndex = 3;
            this.lblLot.Text = "Lot No. :";
            // 
            // lblJar
            // 
            this.lblJar.AutoSize = true;
            this.lblJar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJar.Location = new System.Drawing.Point(540, 19);
            this.lblJar.Name = "lblJar";
            this.lblJar.Size = new System.Drawing.Size(110, 16);
            this.lblJar.TabIndex = 3;
            this.lblJar.Text = "Bottle/Jar No. :";
            this.lblJar.Click += new System.EventHandler(this.lblJar_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(175, 27);
            this.toolStripLabel2.Text = "Reagent Standardazation";
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.gbButtons);
            this.panelFill.Controls.Add(this.gbPMSupplierCOCFields);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 30);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(835, 398);
            this.panelFill.TabIndex = 0;
            // 
            // gbButtons
            // 
            this.gbButtons.Controls.Add(this.btnPMExit);
            this.gbButtons.Controls.Add(this.btnPMSave);
            this.gbButtons.Controls.Add(this.btnStdReset);
            this.gbButtons.Location = new System.Drawing.Point(18, 322);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(803, 54);
            this.gbButtons.TabIndex = 43;
            this.gbButtons.TabStop = false;
            // 
            // btnPMExit
            // 
            this.btnPMExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMExit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnPMExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMExit.Location = new System.Drawing.Point(432, 19);
            this.btnPMExit.Name = "btnPMExit";
            this.btnPMExit.Size = new System.Drawing.Size(68, 28);
            this.btnPMExit.TabIndex = 11;
            this.btnPMExit.Text = "&Exit";
            this.btnPMExit.UseVisualStyleBackColor = false;
            this.btnPMExit.Click += new System.EventHandler(this.btnPMExit_Click);
            // 
            // btnPMSave
            // 
            this.btnPMSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMSave.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnPMSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMSave.Location = new System.Drawing.Point(340, 19);
            this.btnPMSave.Name = "btnPMSave";
            this.btnPMSave.Size = new System.Drawing.Size(58, 28);
            this.btnPMSave.TabIndex = 10;
            this.btnPMSave.Text = "&Save";
            this.btnPMSave.UseVisualStyleBackColor = false;
            this.btnPMSave.Click += new System.EventHandler(this.btnPMSave_Click);
            // 
            // btnStdReset
            // 
            this.btnStdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnStdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStdReset.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnStdReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStdReset.Location = new System.Drawing.Point(246, 19);
            this.btnStdReset.Name = "btnStdReset";
            this.btnStdReset.Size = new System.Drawing.Size(63, 28);
            this.btnStdReset.TabIndex = 9;
            this.btnStdReset.Text = "&Reset";
            this.btnStdReset.UseVisualStyleBackColor = false;
            this.btnStdReset.Click += new System.EventHandler(this.btnStdReset_Click);
            // 
            // gbPMSupplierCOCFields
            // 
            this.gbPMSupplierCOCFields.Controls.Add(this.dgvReagentStd);
            this.gbPMSupplierCOCFields.Location = new System.Drawing.Point(15, 175);
            this.gbPMSupplierCOCFields.Name = "gbPMSupplierCOCFields";
            this.gbPMSupplierCOCFields.Size = new System.Drawing.Size(809, 132);
            this.gbPMSupplierCOCFields.TabIndex = 11;
            this.gbPMSupplierCOCFields.TabStop = false;
            // 
            // dgvReagentStd
            // 
            this.dgvReagentStd.AllowUserToAddRows = false;
            this.dgvReagentStd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReagentStd.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgvReagentStd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReagentStd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvReagentStd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReagentStd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReagentID,
            this.ReagentTransID,
            this.ReagentBottleNo,
            this.StdDate,
            this.NormalityUnit,
            this.ValidityDate});
            this.dgvReagentStd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReagentStd.Location = new System.Drawing.Point(3, 16);
            this.dgvReagentStd.MultiSelect = false;
            this.dgvReagentStd.Name = "dgvReagentStd";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReagentStd.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReagentStd.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvReagentStd.Size = new System.Drawing.Size(803, 113);
            this.dgvReagentStd.TabIndex = 37;
            // 
            // ReagentID
            // 
            this.ReagentID.HeaderText = "ReagentID";
            this.ReagentID.Name = "ReagentID";
            this.ReagentID.Visible = false;
            // 
            // ReagentTransID
            // 
            this.ReagentTransID.HeaderText = "ReagentTransID";
            this.ReagentTransID.Name = "ReagentTransID";
            this.ReagentTransID.Visible = false;
            // 
            // ReagentBottleNo
            // 
            this.ReagentBottleNo.HeaderText = "Reagent Bottle No.";
            this.ReagentBottleNo.Name = "ReagentBottleNo";
            // 
            // StdDate
            // 
            this.StdDate.HeaderText = "Std. Date";
            this.StdDate.Name = "StdDate";
            // 
            // NormalityUnit
            // 
            this.NormalityUnit.HeaderText = "Normality Unit";
            this.NormalityUnit.Name = "NormalityUnit";
            // 
            // ValidityDate
            // 
            this.ValidityDate.HeaderText = "Validity Date";
            this.ValidityDate.Name = "ValidityDate";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(835, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(835, 30);
            this.toolStrip1.TabIndex = 40;
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
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 0);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(835, 428);
            this.panelBottom.TabIndex = 0;
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
            this.panelOuter.Size = new System.Drawing.Size(837, 430);
            this.panelOuter.TabIndex = 6;
            // 
            // FrmReagentStandardazation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(837, 430);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReagentStandardazation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReagentStandardazation";
            this.Load += new System.EventHandler(this.FrmReagentMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelFill.ResumeLayout(false);
            this.gbButtons.ResumeLayout(false);
            this.gbPMSupplierCOCFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReagentStd)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelOuter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblJar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Label lblNormalityUnit;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblLot;
        private System.Windows.Forms.ComboBox cmbLot;
        private System.Windows.Forms.ComboBox cmbJar;
        private System.Windows.Forms.DateTimePicker dtpValidityDate;
        private System.Windows.Forms.DateTimePicker dtpTransDate;
        private System.Windows.Forms.TextBox txtStdNormality;
        private System.Windows.Forms.Label lblValidityDate;
        private System.Windows.Forms.Label lblStdNormality;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbPMSupplierCOCFields;
        private System.Windows.Forms.DataGridView dgvReagentStd;
        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.Button btnPMExit;
        private System.Windows.Forms.Button btnPMSave;
        private System.Windows.Forms.Button btnStdReset;
        private System.Windows.Forms.ComboBox cmbRACode;
        private System.Windows.Forms.Label lblRACode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReagentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReagentTransID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReagentBottleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StdDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NormalityUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidityDate;

    }
}