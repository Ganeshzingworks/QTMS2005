namespace QTMS.Transactions
{
    partial class frmHPLCReferenceMgmt
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
            frmHPLCReferenceMgmt_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgHPLCRSMgmt = new System.Windows.Forms.DataGridView();
            this.Prsno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HPLCRefID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreservativeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfPreparation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfValidity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbRMButtons = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgRMStatusChangeFields = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateOfPreparation = new System.Windows.Forms.DateTimePicker();
            this.cmbRMCode = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFormula = new System.Windows.Forms.Label();
            this.dtpValidityDate = new System.Windows.Forms.DateTimePicker();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHPLCRSMgmt)).BeginInit();
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
            this.panelOuter.Size = new System.Drawing.Size(736, 389);
            this.panelOuter.TabIndex = 88;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(734, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(734, 30);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(181, 27);
            this.toolStripLabel1.Text = "HPLC Reference  Management";
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
            this.panelBottom.Size = new System.Drawing.Size(735, 354);
            this.panelBottom.TabIndex = 98;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Controls.Add(this.gbRMButtons);
            this.panelFill.Controls.Add(this.dgRMStatusChangeFields);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(735, 354);
            this.panelFill.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgHPLCRSMgmt);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(709, 178);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Show Details :";
            // 
            // dgHPLCRSMgmt
            // 
            this.dgHPLCRSMgmt.AllowUserToAddRows = false;
            this.dgHPLCRSMgmt.AllowUserToDeleteRows = false;
            this.dgHPLCRSMgmt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHPLCRSMgmt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Prsno,
            this.HPLCRefID,
            this.LoginID,
            this.PreservativeName,
            this.DateOfPreparation,
            this.DateOfValidity});
            this.dgHPLCRSMgmt.Location = new System.Drawing.Point(23, 35);
            this.dgHPLCRSMgmt.Name = "dgHPLCRSMgmt";
            this.dgHPLCRSMgmt.ReadOnly = true;
            this.dgHPLCRSMgmt.Size = new System.Drawing.Size(633, 137);
            this.dgHPLCRSMgmt.TabIndex = 15;
            // 
            // Prsno
            // 
            this.Prsno.DataPropertyName = "Prsno";
            this.Prsno.HeaderText = "Prsno";
            this.Prsno.Name = "Prsno";
            this.Prsno.ReadOnly = true;
            this.Prsno.Visible = false;
            // 
            // HPLCRefID
            // 
            this.HPLCRefID.DataPropertyName = "HPLCRefID";
            this.HPLCRefID.HeaderText = "HPLCRefID";
            this.HPLCRefID.Name = "HPLCRefID";
            this.HPLCRefID.ReadOnly = true;
            this.HPLCRefID.Visible = false;
            // 
            // LoginID
            // 
            this.LoginID.DataPropertyName = "LoginID";
            this.LoginID.HeaderText = "LoginID";
            this.LoginID.Name = "LoginID";
            this.LoginID.ReadOnly = true;
            this.LoginID.Visible = false;
            // 
            // PreservativeName
            // 
            this.PreservativeName.DataPropertyName = "PresType";
            this.PreservativeName.HeaderText = "Preservative Name";
            this.PreservativeName.Name = "PreservativeName";
            this.PreservativeName.ReadOnly = true;
            this.PreservativeName.Width = 250;
            // 
            // DateOfPreparation
            // 
            this.DateOfPreparation.DataPropertyName = "DateOfPreparation";
            this.DateOfPreparation.HeaderText = "Date Of Preparation";
            this.DateOfPreparation.Name = "DateOfPreparation";
            this.DateOfPreparation.ReadOnly = true;
            this.DateOfPreparation.Width = 150;
            // 
            // DateOfValidity
            // 
            this.DateOfValidity.DataPropertyName = "DateOfValidity";
            this.DateOfValidity.HeaderText = "Date Of Validity";
            this.DateOfValidity.Name = "DateOfValidity";
            this.DateOfValidity.ReadOnly = true;
            this.DateOfValidity.Width = 150;
            // 
            // gbRMButtons
            // 
            this.gbRMButtons.Controls.Add(this.btnExit);
            this.gbRMButtons.Controls.Add(this.btnReset);
            this.gbRMButtons.Controls.Add(this.btnSave);
            this.gbRMButtons.Location = new System.Drawing.Point(15, 110);
            this.gbRMButtons.Name = "gbRMButtons";
            this.gbRMButtons.Size = new System.Drawing.Size(709, 57);
            this.gbRMButtons.TabIndex = 3;
            this.gbRMButtons.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.Location = new System.Drawing.Point(423, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 32);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.Location = new System.Drawing.Point(310, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 32);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Location = new System.Drawing.Point(197, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgRMStatusChangeFields
            // 
            this.dgRMStatusChangeFields.Controls.Add(this.label1);
            this.dgRMStatusChangeFields.Controls.Add(this.dtpDateOfPreparation);
            this.dgRMStatusChangeFields.Controls.Add(this.cmbRMCode);
            this.dgRMStatusChangeFields.Controls.Add(this.label11);
            this.dgRMStatusChangeFields.Controls.Add(this.lblFormula);
            this.dgRMStatusChangeFields.Controls.Add(this.dtpValidityDate);
            this.dgRMStatusChangeFields.Location = new System.Drawing.Point(15, 6);
            this.dgRMStatusChangeFields.Name = "dgRMStatusChangeFields";
            this.dgRMStatusChangeFields.Size = new System.Drawing.Size(709, 98);
            this.dgRMStatusChangeFields.TabIndex = 0;
            this.dgRMStatusChangeFields.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Date Of Preparation :";
            // 
            // dtpDateOfPreparation
            // 
            this.dtpDateOfPreparation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtpDateOfPreparation.CustomFormat = " ";
            this.dtpDateOfPreparation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfPreparation.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfPreparation.Location = new System.Drawing.Point(188, 60);
            this.dtpDateOfPreparation.Name = "dtpDateOfPreparation";
            this.dtpDateOfPreparation.Size = new System.Drawing.Size(138, 23);
            this.dtpDateOfPreparation.TabIndex = 1;
            this.dtpDateOfPreparation.Value = new System.DateTime(2011, 2, 11, 0, 0, 0, 0);
            this.dtpDateOfPreparation.ValueChanged += new System.EventHandler(this.dtpDateOfPreparation_ValueChanged);
            // 
            // cmbRMCode
            // 
            this.cmbRMCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRMCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRMCode.FormattingEnabled = true;
            this.cmbRMCode.Location = new System.Drawing.Point(259, 19);
            this.cmbRMCode.Name = "cmbRMCode";
            this.cmbRMCode.Size = new System.Drawing.Size(217, 24);
            this.cmbRMCode.TabIndex = 0;
            this.cmbRMCode.SelectionChangeCommitted += new System.EventHandler(this.cmbRMCode_SelectionChangeCommitted);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(333, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "Validity Date :";
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblFormula.Location = new System.Drawing.Point(90, 21);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(163, 16);
            this.lblFormula.TabIndex = 0;
            this.lblFormula.Text = "Preservative RM Code :";
            // 
            // dtpValidityDate
            // 
            this.dtpValidityDate.CustomFormat = " ";
            this.dtpValidityDate.Enabled = false;
            this.dtpValidityDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpValidityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpValidityDate.Location = new System.Drawing.Point(442, 60);
            this.dtpValidityDate.Name = "dtpValidityDate";
            this.dtpValidityDate.Size = new System.Drawing.Size(140, 23);
            this.dtpValidityDate.TabIndex = 2;
            this.dtpValidityDate.Value = new System.DateTime(2011, 2, 11, 0, 0, 0, 0);
            this.dtpValidityDate.ValueChanged += new System.EventHandler(this.dtpValidityDate_ValueChanged);
            // 
            // frmHPLCReferenceMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(736, 389);
            this.Controls.Add(this.panelOuter);
            this.Name = "frmHPLCReferenceMgmt";
            this.Text = "HPLCReferenceMgmt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHPLCReferenceMgmt_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHPLCRSMgmt)).EndInit();
            this.gbRMButtons.ResumeLayout(false);
            this.dgRMStatusChangeFields.ResumeLayout(false);
            this.dgRMStatusChangeFields.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpValidityDate;
        private System.Windows.Forms.GroupBox gbRMButtons;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox dgRMStatusChangeFields;
        private System.Windows.Forms.ComboBox cmbRMCode;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateOfPreparation;
        private System.Windows.Forms.DataGridView dgHPLCRSMgmt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prsno;
        private System.Windows.Forms.DataGridViewTextBoxColumn HPLCRefID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreservativeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfPreparation;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfValidity;
    }
}