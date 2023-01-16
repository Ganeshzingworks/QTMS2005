namespace QTMS.Transactions
{
    partial class FrmSFDetails
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
            frmSF_Obj = null;
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAOCPending = new System.Windows.Forms.TextBox();
            this.ChkAOCPending = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBatchCode = new System.Windows.Forms.TextBox();
            this.CmbLineNo = new System.Windows.Forms.ComboBox();
            this.DtpTrackCode = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.DtpFillDate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPkgWoNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSpecification = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgSF = new System.Windows.Forms.DataGridView();
            this.cmbFGCode = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.Mark = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TLFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGTLFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSF)).BeginInit();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.txtAOCPending);
            this.groupBox3.Controls.Add(this.ChkAOCPending);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 456);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(926, 60);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AOC Pending Decision";
            // 
            // txtAOCPending
            // 
            this.txtAOCPending.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAOCPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAOCPending.Enabled = false;
            this.txtAOCPending.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAOCPending.Location = new System.Drawing.Point(383, 19);
            this.txtAOCPending.MaxLength = 250;
            this.txtAOCPending.Name = "txtAOCPending";
            this.txtAOCPending.Size = new System.Drawing.Size(280, 22);
            this.txtAOCPending.TabIndex = 12;
            this.txtAOCPending.Leave += new System.EventHandler(this.txtAOCPending_Leave);
            // 
            // ChkAOCPending
            // 
            this.ChkAOCPending.AutoSize = true;
            this.ChkAOCPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChkAOCPending.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkAOCPending.Location = new System.Drawing.Point(263, 19);
            this.ChkAOCPending.Name = "ChkAOCPending";
            this.ChkAOCPending.Size = new System.Drawing.Size(108, 20);
            this.ChkAOCPending.TabIndex = 11;
            this.ChkAOCPending.Text = "AOC Pending";
            this.ChkAOCPending.UseVisualStyleBackColor = true;
            this.ChkAOCPending.CheckedChanged += new System.EventHandler(this.ChkAOCPending_CheckedChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox8.Controls.Add(this.BtnReset);
            this.groupBox8.Controls.Add(this.BtnExit);
            this.groupBox8.Controls.Add(this.BtnSave);
            this.groupBox8.Location = new System.Drawing.Point(13, 527);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(926, 60);
            this.groupBox8.TabIndex = 40;
            this.groupBox8.TabStop = false;
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(235, 16);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(112, 28);
            this.BtnReset.TabIndex = 1;
            this.BtnReset.Text = "&Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(579, 16);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(112, 28);
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(407, 16);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(112, 28);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtBatchCode);
            this.groupBox2.Controls.Add(this.CmbLineNo);
            this.groupBox2.Controls.Add(this.DtpTrackCode);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.DtpFillDate);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtPkgWoNo);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtSpecification);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 311);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(926, 138);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(699, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 16);
            this.label10.TabIndex = 68;
            this.label10.Text = "Batch Code";
            // 
            // txtBatchCode
            // 
            this.txtBatchCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBatchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchCode.Location = new System.Drawing.Point(787, 37);
            this.txtBatchCode.Name = "txtBatchCode";
            this.txtBatchCode.Size = new System.Drawing.Size(126, 23);
            this.txtBatchCode.TabIndex = 67;
            // 
            // CmbLineNo
            // 
            this.CmbLineNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbLineNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLineNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLineNo.FormattingEnabled = true;
            this.CmbLineNo.Location = new System.Drawing.Point(78, 35);
            this.CmbLineNo.Name = "CmbLineNo";
            this.CmbLineNo.Size = new System.Drawing.Size(126, 24);
            this.CmbLineNo.TabIndex = 66;
            // 
            // DtpTrackCode
            // 
            this.DtpTrackCode.CustomFormat = "dd-MMM-yyyy";
            this.DtpTrackCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpTrackCode.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpTrackCode.Location = new System.Drawing.Point(308, 36);
            this.DtpTrackCode.Name = "DtpTrackCode";
            this.DtpTrackCode.Size = new System.Drawing.Size(126, 23);
            this.DtpTrackCode.TabIndex = 64;
            this.DtpTrackCode.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(222, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 16);
            this.label9.TabIndex = 65;
            this.label9.Text = "Track Code";
            // 
            // DtpFillDate
            // 
            this.DtpFillDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpFillDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFillDate.Location = new System.Drawing.Point(78, 77);
            this.DtpFillDate.Name = "DtpFillDate";
            this.DtpFillDate.Size = new System.Drawing.Size(126, 23);
            this.DtpFillDate.TabIndex = 62;
            this.DtpFillDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 16);
            this.label17.TabIndex = 63;
            this.label17.Text = "Fill Date";
            // 
            // txtPkgWoNo
            // 
            this.txtPkgWoNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPkgWoNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPkgWoNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPkgWoNo.Location = new System.Drawing.Point(556, 37);
            this.txtPkgWoNo.MaxLength = 150;
            this.txtPkgWoNo.Name = "txtPkgWoNo";
            this.txtPkgWoNo.Size = new System.Drawing.Size(126, 23);
            this.txtPkgWoNo.TabIndex = 53;
            this.txtPkgWoNo.Leave += new System.EventHandler(this.txtPkgWoNo_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(459, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 16);
            this.label13.TabIndex = 61;
            this.label13.Text = "Pkg. Wo.No.";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(308, 77);
            this.txtPrice.MaxLength = 10;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(126, 23);
            this.txtPrice.TabIndex = 51;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(222, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 16);
            this.label12.TabIndex = 60;
            this.label12.Text = "Price";
            // 
            // txtSpecification
            // 
            this.txtSpecification.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSpecification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecification.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecification.Location = new System.Drawing.Point(556, 80);
            this.txtSpecification.MaxLength = 50;
            this.txtSpecification.Name = "txtSpecification";
            this.txtSpecification.Size = new System.Drawing.Size(126, 23);
            this.txtSpecification.TabIndex = 52;
            this.txtSpecification.Leave += new System.EventHandler(this.txtSpecification_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(459, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 16);
            this.label7.TabIndex = 58;
            this.label7.Text = "Specification";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 56;
            this.label8.Text = "Line No";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.dgSF);
            this.groupBox1.Controls.Add(this.cmbFGCode);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(926, 288);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Link Formula";
            // 
            // dgSF
            // 
            this.dgSF.AllowUserToAddRows = false;
            this.dgSF.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgSF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSF.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mark,
            this.TLFID,
            this.FGTLFID,
            this.FGCode,
            this.TrackCode,
            this.LineDesc});
            this.dgSF.Location = new System.Drawing.Point(225, 74);
            this.dgSF.MultiSelect = false;
            this.dgSF.Name = "dgSF";
            this.dgSF.RowHeadersVisible = false;
            this.dgSF.Size = new System.Drawing.Size(499, 208);
            this.dgSF.TabIndex = 43;
            this.dgSF.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgSF_ColumnHeaderMouseClick);
            // 
            // cmbFGCode
            // 
            this.cmbFGCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbFGCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFGCode.FormattingEnabled = true;
            this.cmbFGCode.Items.AddRange(new object[] {
            "--Select--"});
            this.cmbFGCode.Location = new System.Drawing.Point(335, 31);
            this.cmbFGCode.Name = "cmbFGCode";
            this.cmbFGCode.Size = new System.Drawing.Size(257, 24);
            this.cmbFGCode.TabIndex = 37;
            this.cmbFGCode.SelectionChangeCommitted += new System.EventHandler(this.cmbFGCode_SelectionChangeCommitted);
            this.cmbFGCode.Leave += new System.EventHandler(this.cmbFGCode_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(261, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 16);
            this.label15.TabIndex = 38;
            this.label15.Text = "F.G.Code";
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panel2);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(954, 636);
            this.panelOuter.TabIndex = 42;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(952, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(952, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 27);
            this.toolStripLabel1.Text = "SF Details";
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
            // panel2
            // 
            this.panel2.Controls.Add(this.panelFill);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 602);
            this.panel2.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.groupBox3);
            this.panelFill.Controls.Add(this.groupBox8);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(952, 602);
            this.panelFill.TabIndex = 0;
            // 
            // Mark
            // 
            this.Mark.HeaderText = "Mark";
            this.Mark.Name = "Mark";
            this.Mark.Width = 50;
            // 
            // TLFID
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.TLFID.DefaultCellStyle = dataGridViewCellStyle2;
            this.TLFID.HeaderText = "TLFID";
            this.TLFID.Name = "TLFID";
            this.TLFID.Visible = false;
            this.TLFID.Width = 10;
            // 
            // FGTLFID
            // 
            this.FGTLFID.HeaderText = "FGTLFID";
            this.FGTLFID.Name = "FGTLFID";
            this.FGTLFID.Visible = false;
            // 
            // FGCode
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FGCode.DefaultCellStyle = dataGridViewCellStyle3;
            this.FGCode.HeaderText = "FGCode";
            this.FGCode.Name = "FGCode";
            this.FGCode.ReadOnly = true;
            this.FGCode.Width = 160;
            // 
            // TrackCode
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackCode.DefaultCellStyle = dataGridViewCellStyle4;
            this.TrackCode.HeaderText = "TrackCode";
            this.TrackCode.Name = "TrackCode";
            this.TrackCode.ReadOnly = true;
            this.TrackCode.Width = 160;
            // 
            // LineDesc
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineDesc.DefaultCellStyle = dataGridViewCellStyle5;
            this.LineDesc.HeaderText = "LineDesc";
            this.LineDesc.Name = "LineDesc";
            this.LineDesc.ReadOnly = true;
            this.LineDesc.Width = 120;
            // 
            // FrmSFDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(954, 636);
            this.Controls.Add(this.panelOuter);
            this.Name = "FrmSFDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SF Details";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSFDetails_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSF)).EndInit();
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFGCode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CmbLineNo;
        private System.Windows.Forms.DateTimePicker DtpTrackCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker DtpFillDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtPkgWoNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSpecification;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox txtAOCPending;
        private System.Windows.Forms.CheckBox ChkAOCPending;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBatchCode;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.DataGridView dgSF;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mark;
        private System.Windows.Forms.DataGridViewTextBoxColumn TLFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGTLFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineDesc;
    }
}