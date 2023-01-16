namespace QTMS.Forms
{
    partial class FrmPMCodeMaster
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
            frmPMMaster_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.List = new System.Windows.Forms.ListBox();
            this.gbPMFields = new System.Windows.Forms.GroupBox();
            this.txtTotalNoOfLots = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgPMPeriodicTest = new System.Windows.Forms.DataGridView();
            this.Mark = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ValPMTestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValPMTestMethod = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ValPMFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValPMInspectionMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmbPMFamily = new System.Windows.Forms.ComboBox();
            this.lblPMFamily = new System.Windows.Forms.Label();
            this.txtPMDescription = new System.Windows.Forms.TextBox();
            this.lblPMDescription = new System.Windows.Forms.Label();
            this.txtPMCode = new System.Windows.Forms.TextBox();
            this.lblPMCode = new System.Windows.Forms.Label();
            this.gbPMSupplierCOCFields = new System.Windows.Forms.GroupBox();
            this.cmbPMSupplierName = new System.Windows.Forms.ComboBox();
            this.btnPMSupplierCOCAdd = new System.Windows.Forms.Button();
            this.btnPMSupplierCOCDelete = new System.Windows.Forms.Button();
            this.btnPMSupplierCOCReset = new System.Windows.Forms.Button();
            this.txtPMNumberOfLots = new System.Windows.Forms.TextBox();
            this.lblPMNoOfLots = new System.Windows.Forms.Label();
            this.cmbPMCOC = new System.Windows.Forms.ComboBox();
            this.dgPMMaster = new System.Windows.Forms.DataGridView();
            this.ValPMSupplierNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValPMSupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValPMCOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValPMNoofLots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPMCOC = new System.Windows.Forms.Label();
            this.lblPMSupplierName = new System.Windows.Forms.Label();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPMModify = new System.Windows.Forms.Button();
            this.btnPMExit = new System.Windows.Forms.Button();
            this.btnPMSave = new System.Windows.Forms.Button();
            this.btnPMDelete = new System.Windows.Forms.Button();
            this.btnPMReset = new System.Windows.Forms.Button();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gbPMFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPMPeriodicTest)).BeginInit();
            this.gbPMSupplierCOCFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPMMaster)).BeginInit();
            this.gbButtons.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.Color.WhiteSmoke;
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.List.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.ItemHeight = 16;
            this.List.Location = new System.Drawing.Point(19, 60);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(191, 562);
            this.List.TabIndex = 6;
            this.List.DoubleClick += new System.EventHandler(this.List_DoubleClick);
            this.List.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.List_KeyPress);
            // 
            // gbPMFields
            // 
            this.gbPMFields.Controls.Add(this.txtTotalNoOfLots);
            this.gbPMFields.Controls.Add(this.label1);
            this.gbPMFields.Controls.Add(this.dgPMPeriodicTest);
            this.gbPMFields.Controls.Add(this.CmbPMFamily);
            this.gbPMFields.Controls.Add(this.lblPMFamily);
            this.gbPMFields.Controls.Add(this.txtPMDescription);
            this.gbPMFields.Controls.Add(this.lblPMDescription);
            this.gbPMFields.Controls.Add(this.txtPMCode);
            this.gbPMFields.Controls.Add(this.lblPMCode);
            this.gbPMFields.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPMFields.Location = new System.Drawing.Point(231, 9);
            this.gbPMFields.Name = "gbPMFields";
            this.gbPMFields.Size = new System.Drawing.Size(569, 280);
            this.gbPMFields.TabIndex = 7;
            this.gbPMFields.TabStop = false;
            // 
            // txtTotalNoOfLots
            // 
            this.txtTotalNoOfLots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalNoOfLots.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNoOfLots.Location = new System.Drawing.Point(174, 113);
            this.txtTotalNoOfLots.Name = "txtTotalNoOfLots";
            this.txtTotalNoOfLots.ReadOnly = true;
            this.txtTotalNoOfLots.Size = new System.Drawing.Size(72, 23);
            this.txtTotalNoOfLots.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(81, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "No of Lots :";
            // 
            // dgPMPeriodicTest
            // 
            this.dgPMPeriodicTest.AllowUserToAddRows = false;
            this.dgPMPeriodicTest.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgPMPeriodicTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPMPeriodicTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgPMPeriodicTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mark,
            this.ValPMTestNo,
            this.ValPMTestMethod,
            this.ValPMFrequency,
            this.ValPMInspectionMethod});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPMPeriodicTest.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgPMPeriodicTest.Location = new System.Drawing.Point(70, 147);
            this.dgPMPeriodicTest.MultiSelect = false;
            this.dgPMPeriodicTest.Name = "dgPMPeriodicTest";
            this.dgPMPeriodicTest.RowHeadersVisible = false;
            this.dgPMPeriodicTest.Size = new System.Drawing.Size(493, 122);
            this.dgPMPeriodicTest.TabIndex = 7;
            this.dgPMPeriodicTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPMPeriodicTest_CellClick);
            this.dgPMPeriodicTest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPMPeriodicTest_CellContentClick);
            // 
            // Mark
            // 
            this.Mark.HeaderText = "Mark";
            this.Mark.Name = "Mark";
            this.Mark.Width = 50;
            // 
            // ValPMTestNo
            // 
            this.ValPMTestNo.HeaderText = "TestNo";
            this.ValPMTestNo.Name = "ValPMTestNo";
            this.ValPMTestNo.ReadOnly = true;
            this.ValPMTestNo.Visible = false;
            this.ValPMTestNo.Width = 80;
            // 
            // ValPMTestMethod
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValPMTestMethod.DefaultCellStyle = dataGridViewCellStyle9;
            this.ValPMTestMethod.HeaderText = "TestMethod";
            this.ValPMTestMethod.Name = "ValPMTestMethod";
            this.ValPMTestMethod.ReadOnly = true;
            this.ValPMTestMethod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ValPMTestMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ValPMTestMethod.Width = 310;
            // 
            // ValPMFrequency
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValPMFrequency.DefaultCellStyle = dataGridViewCellStyle10;
            this.ValPMFrequency.HeaderText = "Frequency";
            this.ValPMFrequency.Name = "ValPMFrequency";
            this.ValPMFrequency.ReadOnly = true;
            this.ValPMFrequency.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ValPMFrequency.Width = 105;
            // 
            // ValPMInspectionMethod
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValPMInspectionMethod.DefaultCellStyle = dataGridViewCellStyle11;
            this.ValPMInspectionMethod.HeaderText = "InspectionMethod";
            this.ValPMInspectionMethod.Name = "ValPMInspectionMethod";
            this.ValPMInspectionMethod.ReadOnly = true;
            this.ValPMInspectionMethod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ValPMInspectionMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ValPMInspectionMethod.Visible = false;
            this.ValPMInspectionMethod.Width = 132;
            // 
            // CmbPMFamily
            // 
            this.CmbPMFamily.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbPMFamily.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPMFamily.FormattingEnabled = true;
            this.CmbPMFamily.Location = new System.Drawing.Point(174, 78);
            this.CmbPMFamily.Name = "CmbPMFamily";
            this.CmbPMFamily.Size = new System.Drawing.Size(262, 24);
            this.CmbPMFamily.TabIndex = 6;
            this.CmbPMFamily.SelectionChangeCommitted += new System.EventHandler(this.CmbPMFamily_SelectionChangeCommitted);
            // 
            // lblPMFamily
            // 
            this.lblPMFamily.AutoSize = true;
            this.lblPMFamily.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMFamily.Location = new System.Drawing.Point(67, 81);
            this.lblPMFamily.Name = "lblPMFamily";
            this.lblPMFamily.Size = new System.Drawing.Size(101, 16);
            this.lblPMFamily.TabIndex = 5;
            this.lblPMFamily.Text = "Family Name :";
            // 
            // txtPMDescription
            // 
            this.txtPMDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMDescription.Location = new System.Drawing.Point(174, 46);
            this.txtPMDescription.Name = "txtPMDescription";
            this.txtPMDescription.Size = new System.Drawing.Size(260, 23);
            this.txtPMDescription.TabIndex = 4;
            // 
            // lblPMDescription
            // 
            this.lblPMDescription.AutoSize = true;
            this.lblPMDescription.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMDescription.Location = new System.Drawing.Point(76, 48);
            this.lblPMDescription.Name = "lblPMDescription";
            this.lblPMDescription.Size = new System.Drawing.Size(92, 16);
            this.lblPMDescription.TabIndex = 3;
            this.lblPMDescription.Text = "Description :";
            // 
            // txtPMCode
            // 
            this.txtPMCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMCode.Location = new System.Drawing.Point(174, 14);
            this.txtPMCode.Name = "txtPMCode";
            this.txtPMCode.Size = new System.Drawing.Size(259, 23);
            this.txtPMCode.TabIndex = 2;
            // 
            // lblPMCode
            // 
            this.lblPMCode.AutoSize = true;
            this.lblPMCode.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMCode.Location = new System.Drawing.Point(92, 16);
            this.lblPMCode.Name = "lblPMCode";
            this.lblPMCode.Size = new System.Drawing.Size(76, 16);
            this.lblPMCode.TabIndex = 1;
            this.lblPMCode.Text = "PM Code :";
            // 
            // gbPMSupplierCOCFields
            // 
            this.gbPMSupplierCOCFields.Controls.Add(this.cmbPMSupplierName);
            this.gbPMSupplierCOCFields.Controls.Add(this.btnPMSupplierCOCAdd);
            this.gbPMSupplierCOCFields.Controls.Add(this.btnPMSupplierCOCDelete);
            this.gbPMSupplierCOCFields.Controls.Add(this.btnPMSupplierCOCReset);
            this.gbPMSupplierCOCFields.Controls.Add(this.txtPMNumberOfLots);
            this.gbPMSupplierCOCFields.Controls.Add(this.lblPMNoOfLots);
            this.gbPMSupplierCOCFields.Controls.Add(this.cmbPMCOC);
            this.gbPMSupplierCOCFields.Controls.Add(this.dgPMMaster);
            this.gbPMSupplierCOCFields.Controls.Add(this.lblPMCOC);
            this.gbPMSupplierCOCFields.Controls.Add(this.lblPMSupplierName);
            this.gbPMSupplierCOCFields.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPMSupplierCOCFields.Location = new System.Drawing.Point(231, 295);
            this.gbPMSupplierCOCFields.Name = "gbPMSupplierCOCFields";
            this.gbPMSupplierCOCFields.Size = new System.Drawing.Size(569, 259);
            this.gbPMSupplierCOCFields.TabIndex = 8;
            this.gbPMSupplierCOCFields.TabStop = false;
            // 
            // cmbPMSupplierName
            // 
            this.cmbPMSupplierName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbPMSupplierName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPMSupplierName.FormattingEnabled = true;
            this.cmbPMSupplierName.Items.AddRange(new object[] {
            "Not Applicable",
            "Applicable"});
            this.cmbPMSupplierName.Location = new System.Drawing.Point(39, 35);
            this.cmbPMSupplierName.Name = "cmbPMSupplierName";
            this.cmbPMSupplierName.Size = new System.Drawing.Size(194, 24);
            this.cmbPMSupplierName.TabIndex = 40;
            this.cmbPMSupplierName.SelectedIndexChanged += new System.EventHandler(this.cmbPMSupplierName_SelectedIndexChanged);
            // 
            // btnPMSupplierCOCAdd
            // 
            this.btnPMSupplierCOCAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMSupplierCOCAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMSupplierCOCAdd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMSupplierCOCAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMSupplierCOCAdd.Location = new System.Drawing.Point(356, 74);
            this.btnPMSupplierCOCAdd.Name = "btnPMSupplierCOCAdd";
            this.btnPMSupplierCOCAdd.Size = new System.Drawing.Size(70, 26);
            this.btnPMSupplierCOCAdd.TabIndex = 39;
            this.btnPMSupplierCOCAdd.Text = "Add ";
            this.btnPMSupplierCOCAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPMSupplierCOCAdd.UseVisualStyleBackColor = false;
            this.btnPMSupplierCOCAdd.Click += new System.EventHandler(this.btnPMSupplierCOCAdd_Click);
            // 
            // btnPMSupplierCOCDelete
            // 
            this.btnPMSupplierCOCDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMSupplierCOCDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMSupplierCOCDelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMSupplierCOCDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMSupplierCOCDelete.Location = new System.Drawing.Point(255, 74);
            this.btnPMSupplierCOCDelete.Name = "btnPMSupplierCOCDelete";
            this.btnPMSupplierCOCDelete.Size = new System.Drawing.Size(70, 26);
            this.btnPMSupplierCOCDelete.TabIndex = 40;
            this.btnPMSupplierCOCDelete.Text = "Delete";
            this.btnPMSupplierCOCDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPMSupplierCOCDelete.UseVisualStyleBackColor = false;
            this.btnPMSupplierCOCDelete.Click += new System.EventHandler(this.btnPMSupplierCOCDelete_Click);
            // 
            // btnPMSupplierCOCReset
            // 
            this.btnPMSupplierCOCReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMSupplierCOCReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMSupplierCOCReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMSupplierCOCReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMSupplierCOCReset.Location = new System.Drawing.Point(154, 74);
            this.btnPMSupplierCOCReset.Name = "btnPMSupplierCOCReset";
            this.btnPMSupplierCOCReset.Size = new System.Drawing.Size(70, 26);
            this.btnPMSupplierCOCReset.TabIndex = 41;
            this.btnPMSupplierCOCReset.Text = "Reset ";
            this.btnPMSupplierCOCReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPMSupplierCOCReset.UseVisualStyleBackColor = false;
            this.btnPMSupplierCOCReset.Click += new System.EventHandler(this.btnPMSupplierCOCReset_Click);
            // 
            // txtPMNumberOfLots
            // 
            this.txtPMNumberOfLots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMNumberOfLots.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMNumberOfLots.Location = new System.Drawing.Point(393, 36);
            this.txtPMNumberOfLots.Name = "txtPMNumberOfLots";
            this.txtPMNumberOfLots.ReadOnly = true;
            this.txtPMNumberOfLots.Size = new System.Drawing.Size(136, 23);
            this.txtPMNumberOfLots.TabIndex = 39;
            // 
            // lblPMNoOfLots
            // 
            this.lblPMNoOfLots.AutoSize = true;
            this.lblPMNoOfLots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.lblPMNoOfLots.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMNoOfLots.Location = new System.Drawing.Point(397, 15);
            this.lblPMNoOfLots.Name = "lblPMNoOfLots";
            this.lblPMNoOfLots.Size = new System.Drawing.Size(110, 16);
            this.lblPMNoOfLots.TabIndex = 38;
            this.lblPMNoOfLots.Text = "Number Of Lots";
            // 
            // cmbPMCOC
            // 
            this.cmbPMCOC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbPMCOC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPMCOC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPMCOC.FormattingEnabled = true;
            this.cmbPMCOC.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbPMCOC.Location = new System.Drawing.Point(269, 35);
            this.cmbPMCOC.Name = "cmbPMCOC";
            this.cmbPMCOC.Size = new System.Drawing.Size(88, 24);
            this.cmbPMCOC.TabIndex = 7;
            // 
            // dgPMMaster
            // 
            this.dgPMMaster.AllowUserToAddRows = false;
            this.dgPMMaster.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgPMMaster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPMMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgPMMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPMMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValPMSupplierNo,
            this.ValPMSupplierName,
            this.ValPMCOC,
            this.ValPMNoofLots});
            this.dgPMMaster.Location = new System.Drawing.Point(46, 121);
            this.dgPMMaster.MultiSelect = false;
            this.dgPMMaster.Name = "dgPMMaster";
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPMMaster.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgPMMaster.Size = new System.Drawing.Size(494, 132);
            this.dgPMMaster.TabIndex = 37;
            this.dgPMMaster.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPMMaster_RowEnter);
            // 
            // ValPMSupplierNo
            // 
            this.ValPMSupplierNo.HeaderText = "Supplier No";
            this.ValPMSupplierNo.Name = "ValPMSupplierNo";
            this.ValPMSupplierNo.Visible = false;
            // 
            // ValPMSupplierName
            // 
            this.ValPMSupplierName.HeaderText = "Supplier Name";
            this.ValPMSupplierName.Name = "ValPMSupplierName";
            this.ValPMSupplierName.ReadOnly = true;
            this.ValPMSupplierName.Width = 250;
            // 
            // ValPMCOC
            // 
            this.ValPMCOC.HeaderText = "COC ";
            this.ValPMCOC.Name = "ValPMCOC";
            this.ValPMCOC.ReadOnly = true;
            this.ValPMCOC.Width = 50;
            // 
            // ValPMNoofLots
            // 
            this.ValPMNoofLots.HeaderText = "No of Lots";
            this.ValPMNoofLots.Name = "ValPMNoofLots";
            this.ValPMNoofLots.ReadOnly = true;
            this.ValPMNoofLots.Width = 150;
            // 
            // lblPMCOC
            // 
            this.lblPMCOC.AutoSize = true;
            this.lblPMCOC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.lblPMCOC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMCOC.Location = new System.Drawing.Point(272, 15);
            this.lblPMCOC.Name = "lblPMCOC";
            this.lblPMCOC.Size = new System.Drawing.Size(36, 16);
            this.lblPMCOC.TabIndex = 37;
            this.lblPMCOC.Text = "COC";
            // 
            // lblPMSupplierName
            // 
            this.lblPMSupplierName.AutoSize = true;
            this.lblPMSupplierName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.lblPMSupplierName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMSupplierName.Location = new System.Drawing.Point(43, 15);
            this.lblPMSupplierName.Name = "lblPMSupplierName";
            this.lblPMSupplierName.Size = new System.Drawing.Size(101, 16);
            this.lblPMSupplierName.TabIndex = 36;
            this.lblPMSupplierName.Text = "Supplier Name";
            // 
            // gbButtons
            // 
            this.gbButtons.Controls.Add(this.btnExport);
            this.gbButtons.Controls.Add(this.btnPMModify);
            this.gbButtons.Controls.Add(this.btnPMExit);
            this.gbButtons.Controls.Add(this.btnPMSave);
            this.gbButtons.Controls.Add(this.btnPMDelete);
            this.gbButtons.Controls.Add(this.btnPMReset);
            this.gbButtons.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbButtons.Location = new System.Drawing.Point(233, 560);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(567, 57);
            this.gbButtons.TabIndex = 42;
            this.gbButtons.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExport.Location = new System.Drawing.Point(368, 14);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(71, 28);
            this.btnExport.TabIndex = 42;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPMModify
            // 
            this.btnPMModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMModify.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMModify.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMModify.Location = new System.Drawing.Point(107, 14);
            this.btnPMModify.Name = "btnPMModify";
            this.btnPMModify.Size = new System.Drawing.Size(73, 28);
            this.btnPMModify.TabIndex = 4;
            this.btnPMModify.Text = "&Modify";
            this.btnPMModify.UseVisualStyleBackColor = false;
            this.btnPMModify.Click += new System.EventHandler(this.btnPMModify_Click);
            // 
            // btnPMExit
            // 
            this.btnPMExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMExit.Location = new System.Drawing.Point(459, 14);
            this.btnPMExit.Name = "btnPMExit";
            this.btnPMExit.Size = new System.Drawing.Size(68, 28);
            this.btnPMExit.TabIndex = 3;
            this.btnPMExit.Text = "&Exit";
            this.btnPMExit.UseVisualStyleBackColor = false;
            this.btnPMExit.Click += new System.EventHandler(this.btnPMExit_Click);
            // 
            // btnPMSave
            // 
            this.btnPMSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMSave.Location = new System.Drawing.Point(287, 14);
            this.btnPMSave.Name = "btnPMSave";
            this.btnPMSave.Size = new System.Drawing.Size(58, 28);
            this.btnPMSave.TabIndex = 2;
            this.btnPMSave.Text = "&Save";
            this.btnPMSave.UseVisualStyleBackColor = false;
            this.btnPMSave.Click += new System.EventHandler(this.btnPMSave_Click);
            // 
            // btnPMDelete
            // 
            this.btnPMDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMDelete.Enabled = false;
            this.btnPMDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMDelete.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMDelete.Location = new System.Drawing.Point(200, 14);
            this.btnPMDelete.Name = "btnPMDelete";
            this.btnPMDelete.Size = new System.Drawing.Size(68, 28);
            this.btnPMDelete.TabIndex = 1;
            this.btnPMDelete.Text = "&Delete";
            this.btnPMDelete.UseVisualStyleBackColor = false;
            this.btnPMDelete.Click += new System.EventHandler(this.btnPMDelete_Click);
            // 
            // btnPMReset
            // 
            this.btnPMReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMReset.Location = new System.Drawing.Point(26, 14);
            this.btnPMReset.Name = "btnPMReset";
            this.btnPMReset.Size = new System.Drawing.Size(63, 28);
            this.btnPMReset.TabIndex = 0;
            this.btnPMReset.Text = "&Reset";
            this.btnPMReset.UseVisualStyleBackColor = false;
            this.btnPMReset.Click += new System.EventHandler(this.btnPMReset_Click);
            // 
            // panelOuter
            // 
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(822, 671);
            this.panelOuter.TabIndex = 43;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(822, 30);
            this.panelTop.TabIndex = 42;
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
            this.toolStripLabel1.Size = new System.Drawing.Size(101, 27);
            this.toolStripLabel1.Text = "PM Code Master";
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
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 36);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(822, 635);
            this.panelBottom.TabIndex = 43;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.gbButtons);
            this.panelFill.Controls.Add(this.gbPMSupplierCOCFields);
            this.panelFill.Controls.Add(this.gbPMFields);
            this.panelFill.Controls.Add(this.List);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(822, 635);
            this.panelFill.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(22, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 44;
            this.lblSearch.Text = "Search :";
            this.lblSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(19, 33);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(191, 23);
            this.txtSearch.TabIndex = 43;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // FrmPMCodeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(822, 671);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPMCodeMaster";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PM Code Master";
            this.Load += new System.EventHandler(this.FrmPMMaster_Load);
            this.gbPMFields.ResumeLayout(false);
            this.gbPMFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPMPeriodicTest)).EndInit();
            this.gbPMSupplierCOCFields.ResumeLayout(false);
            this.gbPMSupplierCOCFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPMMaster)).EndInit();
            this.gbButtons.ResumeLayout(false);
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

        private System.Windows.Forms.ListBox List;
        private System.Windows.Forms.GroupBox gbPMFields;
        private System.Windows.Forms.Label lblPMCode;
        private System.Windows.Forms.TextBox txtPMCode;
        private System.Windows.Forms.TextBox txtPMDescription;
        private System.Windows.Forms.Label lblPMDescription;
        private System.Windows.Forms.Label lblPMFamily;
        private System.Windows.Forms.ComboBox CmbPMFamily;
        private System.Windows.Forms.GroupBox gbPMSupplierCOCFields;
        private System.Windows.Forms.Label lblPMSupplierName;
        private System.Windows.Forms.Label lblPMCOC;
        private System.Windows.Forms.ComboBox cmbPMCOC;
        private System.Windows.Forms.Label lblPMNoOfLots;
        private System.Windows.Forms.TextBox txtPMNumberOfLots;
        private System.Windows.Forms.ComboBox cmbPMSupplierName;
        private System.Windows.Forms.DataGridView dgPMMaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValPMSupplierNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValPMSupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValPMCOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValPMNoofLots;
        private System.Windows.Forms.Button btnPMSupplierCOCReset;
        private System.Windows.Forms.Button btnPMSupplierCOCDelete;
        private System.Windows.Forms.Button btnPMSupplierCOCAdd;
        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.Button btnPMModify;
        private System.Windows.Forms.Button btnPMExit;
        private System.Windows.Forms.Button btnPMSave;
        private System.Windows.Forms.Button btnPMDelete;
        private System.Windows.Forms.Button btnPMReset;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.DataGridView dgPMPeriodicTest;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Mark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValPMTestNo;
        private System.Windows.Forms.DataGridViewLinkColumn ValPMTestMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValPMFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValPMInspectionMethod;
        private System.Windows.Forms.TextBox txtTotalNoOfLots;
        private System.Windows.Forms.Label label1;
    }
}