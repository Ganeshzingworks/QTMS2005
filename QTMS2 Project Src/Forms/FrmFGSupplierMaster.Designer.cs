namespace QTMS.Forms
{
    partial class FrmFGSupplierMaster
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
            frmFGSupplierMaster_Obj = null;
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
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.gbSupplierName = new System.Windows.Forms.GroupBox();
            this.gbcoc = new System.Windows.Forms.GroupBox();
            this.rdbSFMark = new System.Windows.Forms.RadioButton();
            this.rdbFGMark = new System.Windows.Forms.RadioButton();
            this.cmbPMCOC = new System.Windows.Forms.ComboBox();
            this.txtActualLots = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPMNumberOfLots = new System.Windows.Forms.TextBox();
            this.lblPMNoOfLots = new System.Windows.Forms.Label();
            this.dgPMMaster = new System.Windows.Forms.DataGridView();
            this.FGNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValPMCOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Packing = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Micro = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.physicochemical = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ValPMNoofLots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualLots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChkPhysicochemical = new System.Windows.Forms.CheckBox();
            this.ChkMicro = new System.Windows.Forms.CheckBox();
            this.ChkPacking = new System.Windows.Forms.CheckBox();
            this.btnFormulaAdd = new System.Windows.Forms.Button();
            this.CmbFGCode = new System.Windows.Forms.ComboBox();
            this.btnFormulaReset = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFormulaDelete = new System.Windows.Forms.Button();
            this.txtSupplierMailID = new System.Windows.Forms.TextBox();
            this.txtPMSupplierName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPMSupplierName = new System.Windows.Forms.Label();
            this.List = new System.Windows.Forms.ListBox();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbButtons.SuspendLayout();
            this.gbSupplierName.SuspendLayout();
            this.gbcoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPMMaster)).BeginInit();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbButtons
            // 
            this.gbButtons.Controls.Add(this.btnExport);
            this.gbButtons.Controls.Add(this.btnModify);
            this.gbButtons.Controls.Add(this.btnExit);
            this.gbButtons.Controls.Add(this.btnSave);
            this.gbButtons.Controls.Add(this.btnDelete);
            this.gbButtons.Controls.Add(this.btnReset);
            this.gbButtons.Location = new System.Drawing.Point(222, 335);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(971, 56);
            this.gbButtons.TabIndex = 7;
            this.gbButtons.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExport.Location = new System.Drawing.Point(521, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(76, 28);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnModify.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnModify.Location = new System.Drawing.Point(409, 62);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(80, 28);
            this.btnModify.TabIndex = 4;
            this.btnModify.Text = "&Modify";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Visible = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.Location = new System.Drawing.Point(603, 19);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(63, 28);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "&Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Location = new System.Drawing.Point(452, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 28);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.Location = new System.Drawing.Point(373, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(73, 28);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.Location = new System.Drawing.Point(304, 19);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(63, 28);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // gbSupplierName
            // 
            this.gbSupplierName.Controls.Add(this.gbcoc);
            this.gbSupplierName.Controls.Add(this.txtSupplierMailID);
            this.gbSupplierName.Controls.Add(this.txtPMSupplierName);
            this.gbSupplierName.Controls.Add(this.label1);
            this.gbSupplierName.Controls.Add(this.lblPMSupplierName);
            this.gbSupplierName.Location = new System.Drawing.Point(222, 8);
            this.gbSupplierName.Name = "gbSupplierName";
            this.gbSupplierName.Size = new System.Drawing.Size(971, 321);
            this.gbSupplierName.TabIndex = 6;
            this.gbSupplierName.TabStop = false;
            // 
            // gbcoc
            // 
            this.gbcoc.Controls.Add(this.rdbSFMark);
            this.gbcoc.Controls.Add(this.rdbFGMark);
            this.gbcoc.Controls.Add(this.cmbPMCOC);
            this.gbcoc.Controls.Add(this.txtActualLots);
            this.gbcoc.Controls.Add(this.label2);
            this.gbcoc.Controls.Add(this.txtPMNumberOfLots);
            this.gbcoc.Controls.Add(this.lblPMNoOfLots);
            this.gbcoc.Controls.Add(this.dgPMMaster);
            this.gbcoc.Controls.Add(this.ChkPhysicochemical);
            this.gbcoc.Controls.Add(this.ChkMicro);
            this.gbcoc.Controls.Add(this.ChkPacking);
            this.gbcoc.Controls.Add(this.btnFormulaAdd);
            this.gbcoc.Controls.Add(this.CmbFGCode);
            this.gbcoc.Controls.Add(this.btnFormulaReset);
            this.gbcoc.Controls.Add(this.label9);
            this.gbcoc.Controls.Add(this.label8);
            this.gbcoc.Controls.Add(this.btnFormulaDelete);
            this.gbcoc.Location = new System.Drawing.Point(6, 40);
            this.gbcoc.Name = "gbcoc";
            this.gbcoc.Size = new System.Drawing.Size(953, 275);
            this.gbcoc.TabIndex = 2;
            this.gbcoc.TabStop = false;
            this.gbcoc.Tag = "";
            this.gbcoc.Text = "COC Details";
            // 
            // rdbSFMark
            // 
            this.rdbSFMark.AutoSize = true;
            this.rdbSFMark.Location = new System.Drawing.Point(621, 41);
            this.rdbSFMark.Name = "rdbSFMark";
            this.rdbSFMark.Size = new System.Drawing.Size(65, 17);
            this.rdbSFMark.TabIndex = 49;
            this.rdbSFMark.Text = "SF Mark";
            this.rdbSFMark.UseVisualStyleBackColor = true;
            // 
            // rdbFGMark
            // 
            this.rdbFGMark.AutoSize = true;
            this.rdbFGMark.Checked = true;
            this.rdbFGMark.Location = new System.Drawing.Point(545, 41);
            this.rdbFGMark.Name = "rdbFGMark";
            this.rdbFGMark.Size = new System.Drawing.Size(66, 17);
            this.rdbFGMark.TabIndex = 48;
            this.rdbFGMark.TabStop = true;
            this.rdbFGMark.Text = "FG Mark";
            this.rdbFGMark.UseVisualStyleBackColor = true;
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
            this.cmbPMCOC.Location = new System.Drawing.Point(193, 37);
            this.cmbPMCOC.Name = "cmbPMCOC";
            this.cmbPMCOC.Size = new System.Drawing.Size(88, 24);
            this.cmbPMCOC.TabIndex = 4;
            this.cmbPMCOC.SelectedIndexChanged += new System.EventHandler(this.cmbPMCOC_SelectedIndexChanged);
            // 
            // txtActualLots
            // 
            this.txtActualLots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActualLots.Enabled = false;
            this.txtActualLots.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActualLots.Location = new System.Drawing.Point(824, 41);
            this.txtActualLots.Name = "txtActualLots";
            this.txtActualLots.Size = new System.Drawing.Size(114, 23);
            this.txtActualLots.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(840, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Actual Lots";
            // 
            // txtPMNumberOfLots
            // 
            this.txtPMNumberOfLots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMNumberOfLots.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMNumberOfLots.Location = new System.Drawing.Point(701, 41);
            this.txtPMNumberOfLots.Name = "txtPMNumberOfLots";
            this.txtPMNumberOfLots.Size = new System.Drawing.Size(114, 23);
            this.txtPMNumberOfLots.TabIndex = 5;
            // 
            // lblPMNoOfLots
            // 
            this.lblPMNoOfLots.AutoSize = true;
            this.lblPMNoOfLots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.lblPMNoOfLots.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMNoOfLots.Location = new System.Drawing.Point(704, 19);
            this.lblPMNoOfLots.Name = "lblPMNoOfLots";
            this.lblPMNoOfLots.Size = new System.Drawing.Size(110, 16);
            this.lblPMNoOfLots.TabIndex = 47;
            this.lblPMNoOfLots.Text = "COC Frequency";
            // 
            // dgPMMaster
            // 
            this.dgPMMaster.AllowUserToAddRows = false;
            this.dgPMMaster.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgPMMaster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPMMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPMMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPMMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FGNo,
            this.FGCode,
            this.ValPMCOC,
            this.Packing,
            this.Micro,
            this.physicochemical,
            this.ValPMNoofLots,
            this.ActualLots,
            this.Mark});
            this.dgPMMaster.Location = new System.Drawing.Point(107, 96);
            this.dgPMMaster.MultiSelect = false;
            this.dgPMMaster.Name = "dgPMMaster";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPMMaster.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgPMMaster.Size = new System.Drawing.Size(755, 173);
            this.dgPMMaster.TabIndex = 46;
            this.dgPMMaster.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPMMaster_RowEnter);
           
            // 
            // FGNo
            // 
            this.FGNo.HeaderText = "FGNO";
            this.FGNo.Name = "FGNo";
            this.FGNo.Visible = false;
            // 
            // FGCode
            // 
            this.FGCode.HeaderText = "FG Code";
            this.FGCode.Name = "FGCode";
            this.FGCode.ReadOnly = true;
            this.FGCode.Width = 200;
            // 
            // ValPMCOC
            // 
            this.ValPMCOC.HeaderText = "COC ";
            this.ValPMCOC.Name = "ValPMCOC";
            this.ValPMCOC.ReadOnly = true;
            this.ValPMCOC.Width = 50;
            // 
            // Packing
            // 
            this.Packing.HeaderText = "Packing";
            this.Packing.Name = "Packing";
            this.Packing.ReadOnly = true;
            this.Packing.Width = 70;
            // 
            // Micro
            // 
            this.Micro.HeaderText = "Micro";
            this.Micro.Name = "Micro";
            this.Micro.ReadOnly = true;
            this.Micro.Width = 60;
            // 
            // physicochemical
            // 
            this.physicochemical.HeaderText = "physicochemical";
            this.physicochemical.Name = "physicochemical";
            this.physicochemical.ReadOnly = true;
            this.physicochemical.Width = 120;
            // 
            // ValPMNoofLots
            // 
            this.ValPMNoofLots.HeaderText = "No of Lots";
            this.ValPMNoofLots.Name = "ValPMNoofLots";
            this.ValPMNoofLots.ReadOnly = true;
            // 
            // ActualLots
            // 
            this.ActualLots.HeaderText = "Actual Lots";
            this.ActualLots.Name = "ActualLots";
            this.ActualLots.Visible = false;
            // 
            // Mark
            // 
            this.Mark.HeaderText = "Mark";
            this.Mark.Name = "Mark";
            // 
            // ChkPhysicochemical
            // 
            this.ChkPhysicochemical.AutoSize = true;
            this.ChkPhysicochemical.Location = new System.Drawing.Point(416, 41);
            this.ChkPhysicochemical.Name = "ChkPhysicochemical";
            this.ChkPhysicochemical.Size = new System.Drawing.Size(105, 17);
            this.ChkPhysicochemical.TabIndex = 45;
            this.ChkPhysicochemical.Text = "Physicochemical";
            this.ChkPhysicochemical.UseVisualStyleBackColor = true;
            // 
            // ChkMicro
            // 
            this.ChkMicro.AutoSize = true;
            this.ChkMicro.Location = new System.Drawing.Point(358, 41);
            this.ChkMicro.Name = "ChkMicro";
            this.ChkMicro.Size = new System.Drawing.Size(55, 17);
            this.ChkMicro.TabIndex = 45;
            this.ChkMicro.Text = "Micro.";
            this.ChkMicro.UseVisualStyleBackColor = true;
            // 
            // ChkPacking
            // 
            this.ChkPacking.AutoSize = true;
            this.ChkPacking.Location = new System.Drawing.Point(288, 41);
            this.ChkPacking.Name = "ChkPacking";
            this.ChkPacking.Size = new System.Drawing.Size(65, 17);
            this.ChkPacking.TabIndex = 45;
            this.ChkPacking.Text = "Packing";
            this.ChkPacking.UseVisualStyleBackColor = true;
            // 
            // btnFormulaAdd
            // 
            this.btnFormulaAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnFormulaAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormulaAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormulaAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFormulaAdd.Location = new System.Drawing.Point(419, 68);
            this.btnFormulaAdd.Name = "btnFormulaAdd";
            this.btnFormulaAdd.Size = new System.Drawing.Size(70, 22);
            this.btnFormulaAdd.TabIndex = 7;
            this.btnFormulaAdd.Text = "Add ";
            this.btnFormulaAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFormulaAdd.UseVisualStyleBackColor = false;
            this.btnFormulaAdd.Click += new System.EventHandler(this.btnFormulaAdd_Click);
            // 
            // CmbFGCode
            // 
            this.CmbFGCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbFGCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFGCode.FormattingEnabled = true;
            this.CmbFGCode.Location = new System.Drawing.Point(6, 37);
            this.CmbFGCode.Name = "CmbFGCode";
            this.CmbFGCode.Size = new System.Drawing.Size(178, 24);
            this.CmbFGCode.TabIndex = 3;
            // 
            // btnFormulaReset
            // 
            this.btnFormulaReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnFormulaReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormulaReset.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormulaReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFormulaReset.Location = new System.Drawing.Point(241, 68);
            this.btnFormulaReset.Name = "btnFormulaReset";
            this.btnFormulaReset.Size = new System.Drawing.Size(70, 22);
            this.btnFormulaReset.TabIndex = 8;
            this.btnFormulaReset.Text = "Reset ";
            this.btnFormulaReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFormulaReset.UseVisualStyleBackColor = false;
            this.btnFormulaReset.Click += new System.EventHandler(this.btnFormulaReset_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(190, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 22);
            this.label9.TabIndex = 43;
            this.label9.Text = "COC";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(42, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 22);
            this.label8.TabIndex = 43;
            this.label8.Text = "FG Code";
            // 
            // btnFormulaDelete
            // 
            this.btnFormulaDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnFormulaDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormulaDelete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormulaDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFormulaDelete.Location = new System.Drawing.Point(330, 68);
            this.btnFormulaDelete.Name = "btnFormulaDelete";
            this.btnFormulaDelete.Size = new System.Drawing.Size(70, 22);
            this.btnFormulaDelete.TabIndex = 9;
            this.btnFormulaDelete.Text = "Delete";
            this.btnFormulaDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFormulaDelete.UseVisualStyleBackColor = false;
            this.btnFormulaDelete.Visible = false;
            this.btnFormulaDelete.Click += new System.EventHandler(this.btnFormulaDelete_Click);
            // 
            // txtSupplierMailID
            // 
            this.txtSupplierMailID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupplierMailID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierMailID.Location = new System.Drawing.Point(629, 15);
            this.txtSupplierMailID.MaxLength = 140;
            this.txtSupplierMailID.Name = "txtSupplierMailID";
            this.txtSupplierMailID.Size = new System.Drawing.Size(263, 23);
            this.txtSupplierMailID.TabIndex = 2;
            // 
            // txtPMSupplierName
            // 
            this.txtPMSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMSupplierName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMSupplierName.Location = new System.Drawing.Point(235, 15);
            this.txtPMSupplierName.MaxLength = 140;
            this.txtPMSupplierName.Name = "txtPMSupplierName";
            this.txtPMSupplierName.Size = new System.Drawing.Size(222, 23);
            this.txtPMSupplierName.TabIndex = 1;
            this.txtPMSupplierName.Leave += new System.EventHandler(this.txtPMSupplierName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(475, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "SubContractor Mail ID";
            // 
            // lblPMSupplierName
            // 
            this.lblPMSupplierName.AutoSize = true;
            this.lblPMSupplierName.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMSupplierName.Location = new System.Drawing.Point(89, 17);
            this.lblPMSupplierName.Name = "lblPMSupplierName";
            this.lblPMSupplierName.Size = new System.Drawing.Size(145, 16);
            this.lblPMSupplierName.TabIndex = 0;
            this.lblPMSupplierName.Text = "SubContractor Name";
            // 
            // List
            // 
            this.List.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.FormattingEnabled = true;
            this.List.ItemHeight = 16;
            this.List.Location = new System.Drawing.Point(14, 56);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(202, 340);
            this.List.TabIndex = 4;
            this.List.DoubleClick += new System.EventHandler(this.List_DoubleClick);
            this.List.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.List_KeyPress);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(1201, 439);
            this.panelOuter.TabIndex = 8;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1199, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(1199, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(203, 27);
            this.toolStripLabel1.Text = "FG SubContractor Supplier Master";
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
            this.panelBottom.Location = new System.Drawing.Point(0, 34);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1199, 403);
            this.panelBottom.TabIndex = 1;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.gbButtons);
            this.panelFill.Controls.Add(this.gbSupplierName);
            this.panelFill.Controls.Add(this.List);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(1199, 403);
            this.panelFill.TabIndex = 81;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(21, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 16;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(14, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(202, 23);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "FGNO";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "FG Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "COC ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "No of Lots";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Actual Lots";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // FrmFGSupplierMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1201, 439);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFGSupplierMaster";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FG Supplier Master";
            this.Load += new System.EventHandler(this.FrmPMSupplierMaster_Load);
            this.gbButtons.ResumeLayout(false);
            this.gbSupplierName.ResumeLayout(false);
            this.gbSupplierName.PerformLayout();
            this.gbcoc.ResumeLayout(false);
            this.gbcoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPMMaster)).EndInit();
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

        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox gbSupplierName;
        private System.Windows.Forms.TextBox txtPMSupplierName;
        private System.Windows.Forms.Label lblPMSupplierName;
        private System.Windows.Forms.ListBox List;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.TextBox txtSupplierMailID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox gbcoc;
        private System.Windows.Forms.CheckBox ChkPhysicochemical;
        private System.Windows.Forms.CheckBox ChkMicro;
        private System.Windows.Forms.CheckBox ChkPacking;
        private System.Windows.Forms.Button btnFormulaAdd;
        private System.Windows.Forms.ComboBox CmbFGCode;
        private System.Windows.Forms.Button btnFormulaReset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFormulaDelete;
        private System.Windows.Forms.DataGridView dgPMMaster;
        private System.Windows.Forms.TextBox txtPMNumberOfLots;
        private System.Windows.Forms.Label lblPMNoOfLots;
        private System.Windows.Forms.TextBox txtActualLots;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPMCOC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.RadioButton rdbSFMark;
        private System.Windows.Forms.RadioButton rdbFGMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValPMCOC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Packing;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Micro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn physicochemical;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValPMNoofLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mark;
    }
}