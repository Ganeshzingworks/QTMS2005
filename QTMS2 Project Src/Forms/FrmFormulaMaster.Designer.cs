namespace QTMS.Forms
{
    partial class FrmFormulaNoMaster
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
            frmFormulaNoMaster_Obj = null;
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
            this.List = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label28 = new System.Windows.Forms.Label();
            this.DtpFDAApprovalExport = new System.Windows.Forms.DateTimePicker();
            this.lblFungalCount = new System.Windows.Forms.Label();
            this.txtFungalCount = new System.Windows.Forms.TextBox();
            this.lblBacterialCount = new System.Windows.Forms.Label();
            this.txtBacterialCount = new System.Windows.Forms.TextBox();
            this.txtFILCode = new System.Windows.Forms.TextBox();
            this.labelNorms = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.DtpFDAApproval = new System.Windows.Forms.DateTimePicker();
            this.cmbFormulaType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkExtLabReport = new System.Windows.Forms.CheckBox();
            this.DtpModificationDate = new System.Windows.Forms.DateTimePicker();
            this.DtpCreationDate = new System.Windows.Forms.DateTimePicker();
            this.chkDeactive = new System.Windows.Forms.CheckBox();
            this.DtpReferenceDate = new System.Windows.Forms.DateTimePicker();
            this.CmbFormulaNo = new System.Windows.Forms.ComboBox();
            this.DtpOfficializationNo = new System.Windows.Forms.DateTimePicker();
            this.txtNorms = new System.Windows.Forms.TextBox();
            this.ChkMicrobiologyTest = new System.Windows.Forms.CheckBox();
            this.ChkPreservativetest = new System.Windows.Forms.CheckBox();
            this.txtDensity = new System.Windows.Forms.TextBox();
            this.txtNoOfBatches = new System.Windows.Forms.TextBox();
            this.txtBulkDescription = new System.Windows.Forms.TextBox();
            this.CmbTechnicalFamily = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabControlOuter = new System.Windows.Forms.TabControl();
            this.tabPageBulkValId = new System.Windows.Forms.TabPage();
            this.btnValIdReset = new System.Windows.Forms.Button();
            this.btnValIdDelete = new System.Windows.Forms.Button();
            this.dgValId = new System.Windows.Forms.DataGridView();
            this.ValIdTestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValIdTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValIdMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValIdMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnValIdAdd = new System.Windows.Forms.Button();
            this.txtValIdMax = new System.Windows.Forms.TextBox();
            this.txtValIdMin = new System.Windows.Forms.TextBox();
            this.cmbValIdTest = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPageBulkValCon = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnValConReset = new System.Windows.Forms.Button();
            this.btnValConDelete = new System.Windows.Forms.Button();
            this.btnValConAdd = new System.Windows.Forms.Button();
            this.dgValCon = new System.Windows.Forms.DataGridView();
            this.ValConTestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValConTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValConMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValConMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtValConMax = new System.Windows.Forms.TextBox();
            this.txtValConMin = new System.Windows.Forms.TextBox();
            this.cmbValConTest = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tabPageBulkNonValId = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNonValIdReset = new System.Windows.Forms.Button();
            this.btnNonValIdDelete = new System.Windows.Forms.Button();
            this.btnNonValIdAdd = new System.Windows.Forms.Button();
            this.dgNonValId = new System.Windows.Forms.DataGridView();
            this.NonValIdTestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonValIdTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonValIdMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonValIdMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNonValIdMax = new System.Windows.Forms.TextBox();
            this.txtNonValIdMin = new System.Windows.Forms.TextBox();
            this.cmbNonValIdTest = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPageBulkNonValCon = new System.Windows.Forms.TabPage();
            this.panelTest = new System.Windows.Forms.Panel();
            this.btnNonValConReset = new System.Windows.Forms.Button();
            this.btnNonValConDelete = new System.Windows.Forms.Button();
            this.btnNonValConAdd = new System.Windows.Forms.Button();
            this.dgNonValCon = new System.Windows.Forms.DataGridView();
            this.NonValConTestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonValConTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonValConMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonValConMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNonValConMax = new System.Windows.Forms.TextBox();
            this.txtNonValConMin = new System.Windows.Forms.TextBox();
            this.cmbNonValConTest = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPageLine = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLineReset = new System.Windows.Forms.Button();
            this.btnLineDelete = new System.Windows.Forms.Button();
            this.btnLineAdd = new System.Windows.Forms.Button();
            this.dgLine = new System.Windows.Forms.DataGridView();
            this.LineTestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtLineMax = new System.Windows.Forms.TextBox();
            this.txtLineMin = new System.Windows.Forms.TextBox();
            this.cmbLineTest = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveAsNew = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tabControlOuter.SuspendLayout();
            this.tabPageBulkValId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgValId)).BeginInit();
            this.tabPageBulkValCon.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgValCon)).BeginInit();
            this.tabPageBulkNonValId.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNonValId)).BeginInit();
            this.tabPageBulkNonValCon.SuspendLayout();
            this.panelTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNonValCon)).BeginInit();
            this.tabPageLine.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLine)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.Color.WhiteSmoke;
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.List.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.ItemHeight = 16;
            this.List.Location = new System.Drawing.Point(11, 49);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(178, 578);
            this.List.TabIndex = 0;
            this.List.DoubleClick += new System.EventHandler(this.List_DoubleClick);
            this.List.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.List_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.DtpFDAApprovalExport);
            this.groupBox1.Controls.Add(this.lblFungalCount);
            this.groupBox1.Controls.Add(this.txtFungalCount);
            this.groupBox1.Controls.Add(this.lblBacterialCount);
            this.groupBox1.Controls.Add(this.txtBacterialCount);
            this.groupBox1.Controls.Add(this.txtFILCode);
            this.groupBox1.Controls.Add(this.labelNorms);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.DtpFDAApproval);
            this.groupBox1.Controls.Add(this.cmbFormulaType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chkExtLabReport);
            this.groupBox1.Controls.Add(this.DtpModificationDate);
            this.groupBox1.Controls.Add(this.DtpCreationDate);
            this.groupBox1.Controls.Add(this.chkDeactive);
            this.groupBox1.Controls.Add(this.DtpReferenceDate);
            this.groupBox1.Controls.Add(this.CmbFormulaNo);
            this.groupBox1.Controls.Add(this.DtpOfficializationNo);
            this.groupBox1.Controls.Add(this.txtNorms);
            this.groupBox1.Controls.Add(this.ChkMicrobiologyTest);
            this.groupBox1.Controls.Add(this.ChkPreservativetest);
            this.groupBox1.Controls.Add(this.txtDensity);
            this.groupBox1.Controls.Add(this.txtNoOfBatches);
            this.groupBox1.Controls.Add(this.txtBulkDescription);
            this.groupBox1.Controls.Add(this.CmbTechnicalFamily);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Location = new System.Drawing.Point(205, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(478, 134);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(143, 16);
            this.label28.TabIndex = 32;
            this.label28.Text = "FDA Approval Export";
            // 
            // DtpFDAApprovalExport
            // 
            this.DtpFDAApprovalExport.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFDAApprovalExport.Checked = false;
            this.DtpFDAApprovalExport.CustomFormat = "dd-MMM-yyyy";
            this.DtpFDAApprovalExport.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFDAApprovalExport.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFDAApprovalExport.Location = new System.Drawing.Point(624, 131);
            this.DtpFDAApprovalExport.Name = "DtpFDAApprovalExport";
            this.DtpFDAApprovalExport.ShowCheckBox = true;
            this.DtpFDAApprovalExport.Size = new System.Drawing.Size(143, 23);
            this.DtpFDAApprovalExport.TabIndex = 33;
            this.DtpFDAApprovalExport.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // lblFungalCount
            // 
            this.lblFungalCount.AutoSize = true;
            this.lblFungalCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFungalCount.Location = new System.Drawing.Point(306, 213);
            this.lblFungalCount.Name = "lblFungalCount";
            this.lblFungalCount.Size = new System.Drawing.Size(95, 16);
            this.lblFungalCount.TabIndex = 30;
            this.lblFungalCount.Text = "Fungal Count";
            this.lblFungalCount.Visible = false;
            // 
            // txtFungalCount
            // 
            this.txtFungalCount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFungalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFungalCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFungalCount.Location = new System.Drawing.Point(403, 211);
            this.txtFungalCount.MaxLength = 25;
            this.txtFungalCount.Name = "txtFungalCount";
            this.txtFungalCount.Size = new System.Drawing.Size(98, 23);
            this.txtFungalCount.TabIndex = 31;
            this.txtFungalCount.Visible = false;
            // 
            // lblBacterialCount
            // 
            this.lblBacterialCount.AutoSize = true;
            this.lblBacterialCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBacterialCount.Location = new System.Drawing.Point(27, 211);
            this.lblBacterialCount.Name = "lblBacterialCount";
            this.lblBacterialCount.Size = new System.Drawing.Size(109, 16);
            this.lblBacterialCount.TabIndex = 28;
            this.lblBacterialCount.Text = "Bacterial Count";
            this.lblBacterialCount.Visible = false;
            // 
            // txtBacterialCount
            // 
            this.txtBacterialCount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBacterialCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBacterialCount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBacterialCount.Location = new System.Drawing.Point(143, 209);
            this.txtBacterialCount.MaxLength = 25;
            this.txtBacterialCount.Name = "txtBacterialCount";
            this.txtBacterialCount.Size = new System.Drawing.Size(98, 23);
            this.txtBacterialCount.TabIndex = 29;
            this.txtBacterialCount.Visible = false;
            // 
            // txtFILCode
            // 
            this.txtFILCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFILCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFILCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFILCode.Location = new System.Drawing.Point(126, 142);
            this.txtFILCode.MaxLength = 10;
            this.txtFILCode.Name = "txtFILCode";
            this.txtFILCode.Size = new System.Drawing.Size(94, 23);
            this.txtFILCode.TabIndex = 19;
            // 
            // labelNorms
            // 
            this.labelNorms.AutoSize = true;
            this.labelNorms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNorms.Location = new System.Drawing.Point(351, 184);
            this.labelNorms.Name = "labelNorms";
            this.labelNorms.Size = new System.Drawing.Size(48, 16);
            this.labelNorms.TabIndex = 24;
            this.labelNorms.Text = "Norms";
            this.labelNorms.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formula No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(275, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Density";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bulk Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Technical Family";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(7, 145);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(66, 16);
            this.label27.TabIndex = 8;
            this.label27.Text = "FIL Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "No of Batches";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(478, 107);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(135, 16);
            this.label26.TabIndex = 16;
            this.label26.Text = "FDA Approval Local";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(478, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Reference Date";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(478, 81);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(132, 16);
            this.label23.TabIndex = 14;
            this.label23.Text = "Officialisation Date";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(478, 159);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(123, 16);
            this.label25.TabIndex = 20;
            this.label25.Text = "Modification Date";
            // 
            // DtpFDAApproval
            // 
            this.DtpFDAApproval.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFDAApproval.Checked = false;
            this.DtpFDAApproval.CustomFormat = "dd-MMM-yyyy";
            this.DtpFDAApproval.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFDAApproval.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFDAApproval.Location = new System.Drawing.Point(624, 104);
            this.DtpFDAApproval.Name = "DtpFDAApproval";
            this.DtpFDAApproval.ShowCheckBox = true;
            this.DtpFDAApproval.Size = new System.Drawing.Size(143, 23);
            this.DtpFDAApproval.TabIndex = 17;
            this.DtpFDAApproval.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // cmbFormulaType
            // 
            this.cmbFormulaType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbFormulaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormulaType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormulaType.FormattingEnabled = true;
            this.cmbFormulaType.Items.AddRange(new object[] {
            "Validated",
            "NonValidated"});
            this.cmbFormulaType.Location = new System.Drawing.Point(624, 15);
            this.cmbFormulaType.Name = "cmbFormulaType";
            this.cmbFormulaType.Size = new System.Drawing.Size(143, 24);
            this.cmbFormulaType.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(478, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Formula Type";
            // 
            // chkExtLabReport
            // 
            this.chkExtLabReport.AutoSize = true;
            this.chkExtLabReport.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExtLabReport.Location = new System.Drawing.Point(514, 210);
            this.chkExtLabReport.Name = "chkExtLabReport";
            this.chkExtLabReport.Size = new System.Drawing.Size(129, 20);
            this.chkExtLabReport.TabIndex = 26;
            this.chkExtLabReport.Text = "Ext. Lab Report";
            this.chkExtLabReport.UseVisualStyleBackColor = true;
            // 
            // DtpModificationDate
            // 
            this.DtpModificationDate.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpModificationDate.Checked = false;
            this.DtpModificationDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpModificationDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpModificationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpModificationDate.Location = new System.Drawing.Point(624, 156);
            this.DtpModificationDate.Name = "DtpModificationDate";
            this.DtpModificationDate.ShowCheckBox = true;
            this.DtpModificationDate.Size = new System.Drawing.Size(143, 23);
            this.DtpModificationDate.TabIndex = 21;
            this.DtpModificationDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // DtpCreationDate
            // 
            this.DtpCreationDate.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpCreationDate.Checked = false;
            this.DtpCreationDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpCreationDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpCreationDate.Location = new System.Drawing.Point(318, 139);
            this.DtpCreationDate.Name = "DtpCreationDate";
            this.DtpCreationDate.ShowCheckBox = true;
            this.DtpCreationDate.Size = new System.Drawing.Size(143, 23);
            this.DtpCreationDate.TabIndex = 19;
            this.DtpCreationDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // chkDeactive
            // 
            this.chkDeactive.AutoSize = true;
            this.chkDeactive.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeactive.Location = new System.Drawing.Point(658, 210);
            this.chkDeactive.Name = "chkDeactive";
            this.chkDeactive.Size = new System.Drawing.Size(85, 20);
            this.chkDeactive.TabIndex = 27;
            this.chkDeactive.Text = "Deactive";
            this.chkDeactive.UseVisualStyleBackColor = true;
            // 
            // DtpReferenceDate
            // 
            this.DtpReferenceDate.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpReferenceDate.Checked = false;
            this.DtpReferenceDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpReferenceDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpReferenceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpReferenceDate.Location = new System.Drawing.Point(624, 47);
            this.DtpReferenceDate.Name = "DtpReferenceDate";
            this.DtpReferenceDate.ShowCheckBox = true;
            this.DtpReferenceDate.Size = new System.Drawing.Size(143, 23);
            this.DtpReferenceDate.TabIndex = 13;
            this.DtpReferenceDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // CmbFormulaNo
            // 
            this.CmbFormulaNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbFormulaNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFormulaNo.FormattingEnabled = true;
            this.CmbFormulaNo.Location = new System.Drawing.Point(273, 15);
            this.CmbFormulaNo.Name = "CmbFormulaNo";
            this.CmbFormulaNo.Size = new System.Drawing.Size(188, 24);
            this.CmbFormulaNo.TabIndex = 1;
            this.CmbFormulaNo.SelectionChangeCommitted += new System.EventHandler(this.CmbFormulaNo_SelectionChangeCommitted);
            this.CmbFormulaNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbFormulaNo_KeyPress);
            // 
            // DtpOfficializationNo
            // 
            this.DtpOfficializationNo.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpOfficializationNo.Checked = false;
            this.DtpOfficializationNo.CustomFormat = "dd-MMM-yyyy";
            this.DtpOfficializationNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpOfficializationNo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpOfficializationNo.Location = new System.Drawing.Point(624, 78);
            this.DtpOfficializationNo.Name = "DtpOfficializationNo";
            this.DtpOfficializationNo.ShowCheckBox = true;
            this.DtpOfficializationNo.Size = new System.Drawing.Size(143, 23);
            this.DtpOfficializationNo.TabIndex = 15;
            this.DtpOfficializationNo.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // txtNorms
            // 
            this.txtNorms.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNorms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNorms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNorms.Location = new System.Drawing.Point(403, 176);
            this.txtNorms.MaxLength = 25;
            this.txtNorms.Name = "txtNorms";
            this.txtNorms.Size = new System.Drawing.Size(98, 23);
            this.txtNorms.TabIndex = 25;
            this.txtNorms.Visible = false;
            // 
            // ChkMicrobiologyTest
            // 
            this.ChkMicrobiologyTest.AutoSize = true;
            this.ChkMicrobiologyTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkMicrobiologyTest.Location = new System.Drawing.Point(188, 183);
            this.ChkMicrobiologyTest.Name = "ChkMicrobiologyTest";
            this.ChkMicrobiologyTest.Size = new System.Drawing.Size(142, 20);
            this.ChkMicrobiologyTest.TabIndex = 23;
            this.ChkMicrobiologyTest.Text = "Microbiology Test";
            this.ChkMicrobiologyTest.UseVisualStyleBackColor = true;
            this.ChkMicrobiologyTest.CheckedChanged += new System.EventHandler(this.ChkMicrobiologyTest_CheckedChanged);
            // 
            // ChkPreservativetest
            // 
            this.ChkPreservativetest.AutoSize = true;
            this.ChkPreservativetest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkPreservativetest.Location = new System.Drawing.Point(31, 183);
            this.ChkPreservativetest.Name = "ChkPreservativetest";
            this.ChkPreservativetest.Size = new System.Drawing.Size(143, 20);
            this.ChkPreservativetest.TabIndex = 22;
            this.ChkPreservativetest.Text = "Preservative Test";
            this.ChkPreservativetest.UseVisualStyleBackColor = true;
            // 
            // txtDensity
            // 
            this.txtDensity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDensity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDensity.Location = new System.Drawing.Point(336, 110);
            this.txtDensity.MaxLength = 7;
            this.txtDensity.Name = "txtDensity";
            this.txtDensity.Size = new System.Drawing.Size(125, 23);
            this.txtDensity.TabIndex = 11;
            this.txtDensity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDensity_KeyPress);
            // 
            // txtNoOfBatches
            // 
            this.txtNoOfBatches.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNoOfBatches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfBatches.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfBatches.Location = new System.Drawing.Point(126, 110);
            this.txtNoOfBatches.MaxLength = 4;
            this.txtNoOfBatches.Name = "txtNoOfBatches";
            this.txtNoOfBatches.Size = new System.Drawing.Size(131, 23);
            this.txtNoOfBatches.TabIndex = 9;
            this.txtNoOfBatches.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoOfBatches_KeyPress);
            // 
            // txtBulkDescription
            // 
            this.txtBulkDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBulkDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBulkDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBulkDescription.Location = new System.Drawing.Point(126, 47);
            this.txtBulkDescription.MaxLength = 250;
            this.txtBulkDescription.Name = "txtBulkDescription";
            this.txtBulkDescription.Size = new System.Drawing.Size(335, 23);
            this.txtBulkDescription.TabIndex = 5;
            this.txtBulkDescription.Leave += new System.EventHandler(this.txtBulkDescription_Leave);
            // 
            // CmbTechnicalFamily
            // 
            this.CmbTechnicalFamily.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbTechnicalFamily.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTechnicalFamily.FormattingEnabled = true;
            this.CmbTechnicalFamily.Location = new System.Drawing.Point(126, 78);
            this.CmbTechnicalFamily.Name = "CmbTechnicalFamily";
            this.CmbTechnicalFamily.Size = new System.Drawing.Size(335, 24);
            this.CmbTechnicalFamily.TabIndex = 7;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(224, 144);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(99, 16);
            this.label24.TabIndex = 18;
            this.label24.Text = "Creation Date";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExport.Location = new System.Drawing.Point(568, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(83, 28);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabControlOuter
            // 
            this.tabControlOuter.AllowDrop = true;
            this.tabControlOuter.Controls.Add(this.tabPageBulkValId);
            this.tabControlOuter.Controls.Add(this.tabPageBulkValCon);
            this.tabControlOuter.Controls.Add(this.tabPageBulkNonValId);
            this.tabControlOuter.Controls.Add(this.tabPageBulkNonValCon);
            this.tabControlOuter.Controls.Add(this.tabPageLine);
            this.tabControlOuter.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlOuter.Location = new System.Drawing.Point(202, 319);
            this.tabControlOuter.Name = "tabControlOuter";
            this.tabControlOuter.SelectedIndex = 0;
            this.tabControlOuter.Size = new System.Drawing.Size(774, 309);
            this.tabControlOuter.TabIndex = 3;
            this.tabControlOuter.TabStop = false;
            // 
            // tabPageBulkValId
            // 
            this.tabPageBulkValId.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPageBulkValId.Controls.Add(this.btnValIdReset);
            this.tabPageBulkValId.Controls.Add(this.btnValIdDelete);
            this.tabPageBulkValId.Controls.Add(this.dgValId);
            this.tabPageBulkValId.Controls.Add(this.label14);
            this.tabPageBulkValId.Controls.Add(this.label15);
            this.tabPageBulkValId.Controls.Add(this.btnValIdAdd);
            this.tabPageBulkValId.Controls.Add(this.txtValIdMax);
            this.tabPageBulkValId.Controls.Add(this.txtValIdMin);
            this.tabPageBulkValId.Controls.Add(this.cmbValIdTest);
            this.tabPageBulkValId.Controls.Add(this.label16);
            this.tabPageBulkValId.Location = new System.Drawing.Point(4, 25);
            this.tabPageBulkValId.Name = "tabPageBulkValId";
            this.tabPageBulkValId.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBulkValId.Size = new System.Drawing.Size(766, 280);
            this.tabPageBulkValId.TabIndex = 1;
            this.tabPageBulkValId.Text = "Validated Id";
            // 
            // btnValIdReset
            // 
            this.btnValIdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnValIdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValIdReset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValIdReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnValIdReset.Location = new System.Drawing.Point(262, 71);
            this.btnValIdReset.Name = "btnValIdReset";
            this.btnValIdReset.Size = new System.Drawing.Size(70, 26);
            this.btnValIdReset.TabIndex = 38;
            this.btnValIdReset.Text = "Reset ";
            this.btnValIdReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnValIdReset.UseVisualStyleBackColor = false;
            this.btnValIdReset.Click += new System.EventHandler(this.btnValIdReset_Click);
            // 
            // btnValIdDelete
            // 
            this.btnValIdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnValIdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValIdDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValIdDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnValIdDelete.Location = new System.Drawing.Point(351, 71);
            this.btnValIdDelete.Name = "btnValIdDelete";
            this.btnValIdDelete.Size = new System.Drawing.Size(70, 26);
            this.btnValIdDelete.TabIndex = 37;
            this.btnValIdDelete.Text = "Delete";
            this.btnValIdDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnValIdDelete.UseVisualStyleBackColor = false;
            this.btnValIdDelete.Click += new System.EventHandler(this.btnValIdRemove_Click);
            // 
            // dgValId
            // 
            this.dgValId.AllowUserToAddRows = false;
            this.dgValId.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgValId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgValId.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgValId.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgValId.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValIdTestNo,
            this.ValIdTest,
            this.ValIdMin,
            this.ValIdMax});
            this.dgValId.Location = new System.Drawing.Point(136, 103);
            this.dgValId.MultiSelect = false;
            this.dgValId.Name = "dgValId";
            this.dgValId.Size = new System.Drawing.Size(494, 161);
            this.dgValId.TabIndex = 36;
            this.dgValId.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgValId_RowEnter);
            // 
            // ValIdTestNo
            // 
            this.ValIdTestNo.HeaderText = "TestNo";
            this.ValIdTestNo.Name = "ValIdTestNo";
            this.ValIdTestNo.Visible = false;
            // 
            // ValIdTest
            // 
            this.ValIdTest.HeaderText = "Identification Test";
            this.ValIdTest.Name = "ValIdTest";
            this.ValIdTest.ReadOnly = true;
            this.ValIdTest.Width = 250;
            // 
            // ValIdMin
            // 
            this.ValIdMin.HeaderText = "Min";
            this.ValIdMin.Name = "ValIdMin";
            this.ValIdMin.ReadOnly = true;
            // 
            // ValIdMax
            // 
            this.ValIdMax.HeaderText = "Max";
            this.ValIdMax.Name = "ValIdMax";
            this.ValIdMax.ReadOnly = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(612, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 16);
            this.label14.TabIndex = 35;
            this.label14.Text = "Max";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(531, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 16);
            this.label15.TabIndex = 34;
            this.label15.Text = "Min";
            // 
            // btnValIdAdd
            // 
            this.btnValIdAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnValIdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValIdAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValIdAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnValIdAdd.Location = new System.Drawing.Point(440, 71);
            this.btnValIdAdd.Name = "btnValIdAdd";
            this.btnValIdAdd.Size = new System.Drawing.Size(70, 26);
            this.btnValIdAdd.TabIndex = 32;
            this.btnValIdAdd.Text = "Add ";
            this.btnValIdAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnValIdAdd.UseVisualStyleBackColor = false;
            this.btnValIdAdd.Click += new System.EventHandler(this.btnValIdAdd_Click);
            // 
            // txtValIdMax
            // 
            this.txtValIdMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValIdMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValIdMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValIdMax.Location = new System.Drawing.Point(591, 38);
            this.txtValIdMax.MaxLength = 25;
            this.txtValIdMax.Name = "txtValIdMax";
            this.txtValIdMax.Size = new System.Drawing.Size(77, 23);
            this.txtValIdMax.TabIndex = 31;
            this.txtValIdMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValIdMax_KeyPress);
            // 
            // txtValIdMin
            // 
            this.txtValIdMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValIdMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValIdMin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValIdMin.Location = new System.Drawing.Point(508, 38);
            this.txtValIdMin.MaxLength = 25;
            this.txtValIdMin.Name = "txtValIdMin";
            this.txtValIdMin.Size = new System.Drawing.Size(77, 23);
            this.txtValIdMin.TabIndex = 30;
            this.txtValIdMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValIdMin_KeyPress);
            // 
            // cmbValIdTest
            // 
            this.cmbValIdTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbValIdTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbValIdTest.FormattingEnabled = true;
            this.cmbValIdTest.Location = new System.Drawing.Point(99, 36);
            this.cmbValIdTest.Name = "cmbValIdTest";
            this.cmbValIdTest.Size = new System.Drawing.Size(399, 24);
            this.cmbValIdTest.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(99, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 16);
            this.label16.TabIndex = 33;
            this.label16.Text = "Select Test";
            // 
            // tabPageBulkValCon
            // 
            this.tabPageBulkValCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.tabPageBulkValCon.Controls.Add(this.panel3);
            this.tabPageBulkValCon.Location = new System.Drawing.Point(4, 25);
            this.tabPageBulkValCon.Name = "tabPageBulkValCon";
            this.tabPageBulkValCon.Size = new System.Drawing.Size(766, 280);
            this.tabPageBulkValCon.TabIndex = 3;
            this.tabPageBulkValCon.Text = "Validated Con";
            this.tabPageBulkValCon.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnValConReset);
            this.panel3.Controls.Add(this.btnValConDelete);
            this.panel3.Controls.Add(this.btnValConAdd);
            this.panel3.Controls.Add(this.dgValCon);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.txtValConMax);
            this.panel3.Controls.Add(this.txtValConMin);
            this.panel3.Controls.Add(this.cmbValConTest);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(766, 280);
            this.panel3.TabIndex = 2;
            // 
            // btnValConReset
            // 
            this.btnValConReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnValConReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValConReset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValConReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnValConReset.Location = new System.Drawing.Point(262, 71);
            this.btnValConReset.Name = "btnValConReset";
            this.btnValConReset.Size = new System.Drawing.Size(70, 26);
            this.btnValConReset.TabIndex = 31;
            this.btnValConReset.Text = "Reset ";
            this.btnValConReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnValConReset.UseVisualStyleBackColor = false;
            this.btnValConReset.Click += new System.EventHandler(this.btnValConReset_Click);
            // 
            // btnValConDelete
            // 
            this.btnValConDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnValConDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValConDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValConDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnValConDelete.Location = new System.Drawing.Point(351, 71);
            this.btnValConDelete.Name = "btnValConDelete";
            this.btnValConDelete.Size = new System.Drawing.Size(70, 26);
            this.btnValConDelete.TabIndex = 30;
            this.btnValConDelete.Text = "Delete";
            this.btnValConDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnValConDelete.UseVisualStyleBackColor = false;
            this.btnValConDelete.Click += new System.EventHandler(this.btnValConRemove_Click);
            // 
            // btnValConAdd
            // 
            this.btnValConAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnValConAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValConAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValConAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnValConAdd.Location = new System.Drawing.Point(440, 71);
            this.btnValConAdd.Name = "btnValConAdd";
            this.btnValConAdd.Size = new System.Drawing.Size(70, 26);
            this.btnValConAdd.TabIndex = 29;
            this.btnValConAdd.Text = "Add ";
            this.btnValConAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnValConAdd.UseVisualStyleBackColor = false;
            this.btnValConAdd.Click += new System.EventHandler(this.btnValConAdd_Click);
            // 
            // dgValCon
            // 
            this.dgValCon.AllowUserToAddRows = false;
            this.dgValCon.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgValCon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgValCon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgValCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgValCon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValConTestNo,
            this.ValConTest,
            this.ValConMin,
            this.ValConMax});
            this.dgValCon.Location = new System.Drawing.Point(136, 103);
            this.dgValCon.MultiSelect = false;
            this.dgValCon.Name = "dgValCon";
            this.dgValCon.Size = new System.Drawing.Size(494, 161);
            this.dgValCon.TabIndex = 26;
            this.dgValCon.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgValCon_RowEnter);
            // 
            // ValConTestNo
            // 
            this.ValConTestNo.HeaderText = "TestNo";
            this.ValConTestNo.Name = "ValConTestNo";
            this.ValConTestNo.Visible = false;
            // 
            // ValConTest
            // 
            this.ValConTest.HeaderText = "Control Test";
            this.ValConTest.Name = "ValConTest";
            this.ValConTest.ReadOnly = true;
            this.ValConTest.Width = 250;
            // 
            // ValConMin
            // 
            this.ValConMin.HeaderText = "Min";
            this.ValConMin.Name = "ValConMin";
            this.ValConMin.ReadOnly = true;
            // 
            // ValConMax
            // 
            this.ValConMax.HeaderText = "Max";
            this.ValConMax.Name = "ValConMax";
            this.ValConMax.ReadOnly = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(612, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 16);
            this.label17.TabIndex = 25;
            this.label17.Text = "Max";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(531, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 16);
            this.label18.TabIndex = 24;
            this.label18.Text = "Min";
            // 
            // txtValConMax
            // 
            this.txtValConMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValConMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValConMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValConMax.Location = new System.Drawing.Point(591, 38);
            this.txtValConMax.MaxLength = 25;
            this.txtValConMax.Name = "txtValConMax";
            this.txtValConMax.Size = new System.Drawing.Size(77, 23);
            this.txtValConMax.TabIndex = 2;
            this.txtValConMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValConMax_KeyPress);
            // 
            // txtValConMin
            // 
            this.txtValConMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValConMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValConMin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValConMin.Location = new System.Drawing.Point(508, 38);
            this.txtValConMin.MaxLength = 25;
            this.txtValConMin.Name = "txtValConMin";
            this.txtValConMin.Size = new System.Drawing.Size(77, 23);
            this.txtValConMin.TabIndex = 1;
            this.txtValConMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValConMin_KeyPress);
            // 
            // cmbValConTest
            // 
            this.cmbValConTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbValConTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbValConTest.FormattingEnabled = true;
            this.cmbValConTest.Location = new System.Drawing.Point(99, 36);
            this.cmbValConTest.Name = "cmbValConTest";
            this.cmbValConTest.Size = new System.Drawing.Size(399, 24);
            this.cmbValConTest.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(99, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 16);
            this.label19.TabIndex = 20;
            this.label19.Text = "Select Test";
            // 
            // tabPageBulkNonValId
            // 
            this.tabPageBulkNonValId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.tabPageBulkNonValId.Controls.Add(this.panel1);
            this.tabPageBulkNonValId.Location = new System.Drawing.Point(4, 25);
            this.tabPageBulkNonValId.Name = "tabPageBulkNonValId";
            this.tabPageBulkNonValId.Size = new System.Drawing.Size(766, 280);
            this.tabPageBulkNonValId.TabIndex = 4;
            this.tabPageBulkNonValId.Text = "NonValidated Id";
            this.tabPageBulkNonValId.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.btnNonValIdReset);
            this.panel1.Controls.Add(this.btnNonValIdDelete);
            this.panel1.Controls.Add(this.btnNonValIdAdd);
            this.panel1.Controls.Add(this.dgNonValId);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtNonValIdMax);
            this.panel1.Controls.Add(this.txtNonValIdMin);
            this.panel1.Controls.Add(this.cmbNonValIdTest);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 280);
            this.panel1.TabIndex = 2;
            // 
            // btnNonValIdReset
            // 
            this.btnNonValIdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnNonValIdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonValIdReset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonValIdReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNonValIdReset.Location = new System.Drawing.Point(262, 71);
            this.btnNonValIdReset.Name = "btnNonValIdReset";
            this.btnNonValIdReset.Size = new System.Drawing.Size(70, 26);
            this.btnNonValIdReset.TabIndex = 31;
            this.btnNonValIdReset.Text = "Reset ";
            this.btnNonValIdReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNonValIdReset.UseVisualStyleBackColor = false;
            this.btnNonValIdReset.Click += new System.EventHandler(this.btnNonValIdReset_Click);
            // 
            // btnNonValIdDelete
            // 
            this.btnNonValIdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnNonValIdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonValIdDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonValIdDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNonValIdDelete.Location = new System.Drawing.Point(351, 71);
            this.btnNonValIdDelete.Name = "btnNonValIdDelete";
            this.btnNonValIdDelete.Size = new System.Drawing.Size(70, 26);
            this.btnNonValIdDelete.TabIndex = 30;
            this.btnNonValIdDelete.Text = "Delete";
            this.btnNonValIdDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNonValIdDelete.UseVisualStyleBackColor = false;
            this.btnNonValIdDelete.Click += new System.EventHandler(this.btnNonValIdRemove_Click);
            // 
            // btnNonValIdAdd
            // 
            this.btnNonValIdAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnNonValIdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonValIdAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonValIdAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNonValIdAdd.Location = new System.Drawing.Point(440, 71);
            this.btnNonValIdAdd.Name = "btnNonValIdAdd";
            this.btnNonValIdAdd.Size = new System.Drawing.Size(70, 26);
            this.btnNonValIdAdd.TabIndex = 29;
            this.btnNonValIdAdd.Text = "Add ";
            this.btnNonValIdAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNonValIdAdd.UseVisualStyleBackColor = false;
            this.btnNonValIdAdd.Click += new System.EventHandler(this.btnNonValIdAdd_Click);
            // 
            // dgNonValId
            // 
            this.dgNonValId.AllowUserToAddRows = false;
            this.dgNonValId.BackgroundColor = System.Drawing.Color.Silver;
            this.dgNonValId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgNonValId.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgNonValId.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNonValId.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NonValIdTestNo,
            this.NonValIdTest,
            this.NonValIdMin,
            this.NonValIdMax});
            this.dgNonValId.Location = new System.Drawing.Point(136, 103);
            this.dgNonValId.MultiSelect = false;
            this.dgNonValId.Name = "dgNonValId";
            this.dgNonValId.Size = new System.Drawing.Size(494, 161);
            this.dgNonValId.TabIndex = 26;
            this.dgNonValId.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNonValId_RowEnter);
            // 
            // NonValIdTestNo
            // 
            this.NonValIdTestNo.HeaderText = "TestNo";
            this.NonValIdTestNo.Name = "NonValIdTestNo";
            this.NonValIdTestNo.Visible = false;
            // 
            // NonValIdTest
            // 
            this.NonValIdTest.HeaderText = "Identification Test";
            this.NonValIdTest.Name = "NonValIdTest";
            this.NonValIdTest.ReadOnly = true;
            this.NonValIdTest.Width = 250;
            // 
            // NonValIdMin
            // 
            this.NonValIdMin.HeaderText = "Min";
            this.NonValIdMin.Name = "NonValIdMin";
            this.NonValIdMin.ReadOnly = true;
            // 
            // NonValIdMax
            // 
            this.NonValIdMax.HeaderText = "Max";
            this.NonValIdMax.Name = "NonValIdMax";
            this.NonValIdMax.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(612, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "Max";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(531, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "Min";
            // 
            // txtNonValIdMax
            // 
            this.txtNonValIdMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNonValIdMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNonValIdMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNonValIdMax.Location = new System.Drawing.Point(591, 38);
            this.txtNonValIdMax.MaxLength = 25;
            this.txtNonValIdMax.Name = "txtNonValIdMax";
            this.txtNonValIdMax.Size = new System.Drawing.Size(77, 23);
            this.txtNonValIdMax.TabIndex = 2;
            this.txtNonValIdMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNonValIdMax_KeyPress);
            // 
            // txtNonValIdMin
            // 
            this.txtNonValIdMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNonValIdMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNonValIdMin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNonValIdMin.Location = new System.Drawing.Point(508, 38);
            this.txtNonValIdMin.MaxLength = 25;
            this.txtNonValIdMin.Name = "txtNonValIdMin";
            this.txtNonValIdMin.Size = new System.Drawing.Size(77, 23);
            this.txtNonValIdMin.TabIndex = 1;
            this.txtNonValIdMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNonValIdMin_KeyPress);
            // 
            // cmbNonValIdTest
            // 
            this.cmbNonValIdTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbNonValIdTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNonValIdTest.FormattingEnabled = true;
            this.cmbNonValIdTest.Location = new System.Drawing.Point(99, 36);
            this.cmbNonValIdTest.Name = "cmbNonValIdTest";
            this.cmbNonValIdTest.Size = new System.Drawing.Size(399, 24);
            this.cmbNonValIdTest.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(99, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "Select Test";
            // 
            // tabPageBulkNonValCon
            // 
            this.tabPageBulkNonValCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.tabPageBulkNonValCon.Controls.Add(this.panelTest);
            this.tabPageBulkNonValCon.Location = new System.Drawing.Point(4, 25);
            this.tabPageBulkNonValCon.Name = "tabPageBulkNonValCon";
            this.tabPageBulkNonValCon.Size = new System.Drawing.Size(766, 280);
            this.tabPageBulkNonValCon.TabIndex = 5;
            this.tabPageBulkNonValCon.Text = "NonValidated Con";
            this.tabPageBulkNonValCon.UseVisualStyleBackColor = true;
            // 
            // panelTest
            // 
            this.panelTest.BackColor = System.Drawing.Color.DarkGray;
            this.panelTest.Controls.Add(this.btnNonValConReset);
            this.panelTest.Controls.Add(this.btnNonValConDelete);
            this.panelTest.Controls.Add(this.btnNonValConAdd);
            this.panelTest.Controls.Add(this.dgNonValCon);
            this.panelTest.Controls.Add(this.label10);
            this.panelTest.Controls.Add(this.label9);
            this.panelTest.Controls.Add(this.txtNonValConMax);
            this.panelTest.Controls.Add(this.txtNonValConMin);
            this.panelTest.Controls.Add(this.cmbNonValConTest);
            this.panelTest.Controls.Add(this.label8);
            this.panelTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTest.Location = new System.Drawing.Point(0, 0);
            this.panelTest.Name = "panelTest";
            this.panelTest.Size = new System.Drawing.Size(766, 280);
            this.panelTest.TabIndex = 1;
            // 
            // btnNonValConReset
            // 
            this.btnNonValConReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnNonValConReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonValConReset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonValConReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNonValConReset.Location = new System.Drawing.Point(262, 71);
            this.btnNonValConReset.Name = "btnNonValConReset";
            this.btnNonValConReset.Size = new System.Drawing.Size(70, 26);
            this.btnNonValConReset.TabIndex = 34;
            this.btnNonValConReset.Text = "Reset ";
            this.btnNonValConReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNonValConReset.UseVisualStyleBackColor = false;
            this.btnNonValConReset.Click += new System.EventHandler(this.btnNonValConReset_Click);
            // 
            // btnNonValConDelete
            // 
            this.btnNonValConDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnNonValConDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonValConDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonValConDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNonValConDelete.Location = new System.Drawing.Point(351, 71);
            this.btnNonValConDelete.Name = "btnNonValConDelete";
            this.btnNonValConDelete.Size = new System.Drawing.Size(70, 26);
            this.btnNonValConDelete.TabIndex = 33;
            this.btnNonValConDelete.Text = "Delete";
            this.btnNonValConDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNonValConDelete.UseVisualStyleBackColor = false;
            this.btnNonValConDelete.Click += new System.EventHandler(this.btnNonValConRemove_Click);
            // 
            // btnNonValConAdd
            // 
            this.btnNonValConAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnNonValConAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonValConAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonValConAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnNonValConAdd.Location = new System.Drawing.Point(440, 71);
            this.btnNonValConAdd.Name = "btnNonValConAdd";
            this.btnNonValConAdd.Size = new System.Drawing.Size(70, 26);
            this.btnNonValConAdd.TabIndex = 32;
            this.btnNonValConAdd.Text = "Add ";
            this.btnNonValConAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNonValConAdd.UseVisualStyleBackColor = false;
            this.btnNonValConAdd.Click += new System.EventHandler(this.btnNonValConAdd_Click);
            // 
            // dgNonValCon
            // 
            this.dgNonValCon.AllowUserToAddRows = false;
            this.dgNonValCon.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgNonValCon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgNonValCon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgNonValCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNonValCon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NonValConTestNo,
            this.NonValConTest,
            this.NonValConMin,
            this.NonValConMax});
            this.dgNonValCon.Location = new System.Drawing.Point(136, 103);
            this.dgNonValCon.MultiSelect = false;
            this.dgNonValCon.Name = "dgNonValCon";
            this.dgNonValCon.Size = new System.Drawing.Size(494, 161);
            this.dgNonValCon.TabIndex = 26;
            this.dgNonValCon.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNonValCon_RowEnter);
            // 
            // NonValConTestNo
            // 
            this.NonValConTestNo.HeaderText = "TestNo";
            this.NonValConTestNo.Name = "NonValConTestNo";
            this.NonValConTestNo.Visible = false;
            // 
            // NonValConTest
            // 
            this.NonValConTest.HeaderText = "Control Test";
            this.NonValConTest.Name = "NonValConTest";
            this.NonValConTest.ReadOnly = true;
            this.NonValConTest.Width = 250;
            // 
            // NonValConMin
            // 
            this.NonValConMin.HeaderText = "Min";
            this.NonValConMin.Name = "NonValConMin";
            this.NonValConMin.ReadOnly = true;
            // 
            // NonValConMax
            // 
            this.NonValConMax.HeaderText = "Max";
            this.NonValConMax.Name = "NonValConMax";
            this.NonValConMax.ReadOnly = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(612, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "Max";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(531, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Min";
            // 
            // txtNonValConMax
            // 
            this.txtNonValConMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNonValConMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNonValConMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNonValConMax.Location = new System.Drawing.Point(591, 38);
            this.txtNonValConMax.MaxLength = 25;
            this.txtNonValConMax.Name = "txtNonValConMax";
            this.txtNonValConMax.Size = new System.Drawing.Size(77, 23);
            this.txtNonValConMax.TabIndex = 2;
            this.txtNonValConMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNonValConMax_KeyPress);
            // 
            // txtNonValConMin
            // 
            this.txtNonValConMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNonValConMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNonValConMin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNonValConMin.Location = new System.Drawing.Point(508, 38);
            this.txtNonValConMin.MaxLength = 25;
            this.txtNonValConMin.Name = "txtNonValConMin";
            this.txtNonValConMin.Size = new System.Drawing.Size(77, 23);
            this.txtNonValConMin.TabIndex = 1;
            this.txtNonValConMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNonValConMin_KeyPress);
            // 
            // cmbNonValConTest
            // 
            this.cmbNonValConTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbNonValConTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNonValConTest.FormattingEnabled = true;
            this.cmbNonValConTest.Location = new System.Drawing.Point(99, 36);
            this.cmbNonValConTest.Name = "cmbNonValConTest";
            this.cmbNonValConTest.Size = new System.Drawing.Size(399, 24);
            this.cmbNonValConTest.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(99, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Select Test";
            // 
            // tabPageLine
            // 
            this.tabPageLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.tabPageLine.Controls.Add(this.panel4);
            this.tabPageLine.Location = new System.Drawing.Point(4, 25);
            this.tabPageLine.Name = "tabPageLine";
            this.tabPageLine.Size = new System.Drawing.Size(766, 280);
            this.tabPageLine.TabIndex = 2;
            this.tabPageLine.Text = "Line Sample";
            this.tabPageLine.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.btnLineReset);
            this.panel4.Controls.Add(this.btnLineDelete);
            this.panel4.Controls.Add(this.btnLineAdd);
            this.panel4.Controls.Add(this.dgLine);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.txtLineMax);
            this.panel4.Controls.Add(this.txtLineMin);
            this.panel4.Controls.Add(this.cmbLineTest);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(766, 280);
            this.panel4.TabIndex = 1;
            // 
            // btnLineReset
            // 
            this.btnLineReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnLineReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineReset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLineReset.Location = new System.Drawing.Point(262, 71);
            this.btnLineReset.Name = "btnLineReset";
            this.btnLineReset.Size = new System.Drawing.Size(70, 26);
            this.btnLineReset.TabIndex = 34;
            this.btnLineReset.Text = "Reset ";
            this.btnLineReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLineReset.UseVisualStyleBackColor = false;
            this.btnLineReset.Click += new System.EventHandler(this.btnLineReset_Click);
            // 
            // btnLineDelete
            // 
            this.btnLineDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnLineDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLineDelete.Location = new System.Drawing.Point(351, 71);
            this.btnLineDelete.Name = "btnLineDelete";
            this.btnLineDelete.Size = new System.Drawing.Size(70, 26);
            this.btnLineDelete.TabIndex = 33;
            this.btnLineDelete.Text = "Delete";
            this.btnLineDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLineDelete.UseVisualStyleBackColor = false;
            this.btnLineDelete.Click += new System.EventHandler(this.btnLineRemove_Click);
            // 
            // btnLineAdd
            // 
            this.btnLineAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnLineAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLineAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLineAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLineAdd.Location = new System.Drawing.Point(440, 71);
            this.btnLineAdd.Name = "btnLineAdd";
            this.btnLineAdd.Size = new System.Drawing.Size(70, 26);
            this.btnLineAdd.TabIndex = 32;
            this.btnLineAdd.Text = "Add ";
            this.btnLineAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLineAdd.UseVisualStyleBackColor = false;
            this.btnLineAdd.Click += new System.EventHandler(this.btnLineAdd_Click);
            // 
            // dgLine
            // 
            this.dgLine.AllowUserToAddRows = false;
            this.dgLine.BackgroundColor = System.Drawing.Color.Gray;
            this.dgLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineTestNo,
            this.LineTest,
            this.LineMin,
            this.LineMax});
            this.dgLine.Location = new System.Drawing.Point(136, 103);
            this.dgLine.MultiSelect = false;
            this.dgLine.Name = "dgLine";
            this.dgLine.Size = new System.Drawing.Size(494, 161);
            this.dgLine.TabIndex = 26;
            this.dgLine.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLine_RowEnter);
            // 
            // LineTestNo
            // 
            this.LineTestNo.HeaderText = "TestNo";
            this.LineTestNo.Name = "LineTestNo";
            this.LineTestNo.Visible = false;
            // 
            // LineTest
            // 
            this.LineTest.HeaderText = "Line Sample Test";
            this.LineTest.Name = "LineTest";
            this.LineTest.ReadOnly = true;
            this.LineTest.Width = 250;
            // 
            // LineMin
            // 
            this.LineMin.HeaderText = "Min";
            this.LineMin.Name = "LineMin";
            this.LineMin.ReadOnly = true;
            // 
            // LineMax
            // 
            this.LineMax.HeaderText = "Max";
            this.LineMax.Name = "LineMax";
            this.LineMax.ReadOnly = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(612, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 16);
            this.label20.TabIndex = 25;
            this.label20.Text = "Max";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(531, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(30, 16);
            this.label21.TabIndex = 24;
            this.label21.Text = "Min";
            // 
            // txtLineMax
            // 
            this.txtLineMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLineMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLineMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineMax.Location = new System.Drawing.Point(591, 38);
            this.txtLineMax.MaxLength = 25;
            this.txtLineMax.Name = "txtLineMax";
            this.txtLineMax.Size = new System.Drawing.Size(77, 23);
            this.txtLineMax.TabIndex = 2;
            this.txtLineMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLineMax_KeyPress);
            // 
            // txtLineMin
            // 
            this.txtLineMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLineMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLineMin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineMin.Location = new System.Drawing.Point(508, 38);
            this.txtLineMin.MaxLength = 25;
            this.txtLineMin.Name = "txtLineMin";
            this.txtLineMin.Size = new System.Drawing.Size(77, 23);
            this.txtLineMin.TabIndex = 1;
            this.txtLineMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLineMin_KeyPress);
            // 
            // cmbLineTest
            // 
            this.cmbLineTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbLineTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLineTest.FormattingEnabled = true;
            this.cmbLineTest.Location = new System.Drawing.Point(99, 36);
            this.cmbLineTest.Name = "cmbLineTest";
            this.cmbLineTest.Size = new System.Drawing.Size(399, 24);
            this.cmbLineTest.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(99, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 16);
            this.label22.TabIndex = 20;
            this.label22.Text = "Select Test";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.btnSaveAsNew);
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnModify);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(204, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(774, 61);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnSaveAsNew
            // 
            this.btnSaveAsNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSaveAsNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAsNew.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAsNew.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveAsNew.Location = new System.Drawing.Point(127, 16);
            this.btnSaveAsNew.Name = "btnSaveAsNew";
            this.btnSaveAsNew.Size = new System.Drawing.Size(83, 28);
            this.btnSaveAsNew.TabIndex = 1;
            this.btnSaveAsNew.Text = "Save &As";
            this.btnSaveAsNew.UseVisualStyleBackColor = false;
            this.btnSaveAsNew.Click += new System.EventHandler(this.btnSaveAsNew_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(355, 16);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(83, 28);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModify.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModify.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnModify.Location = new System.Drawing.Point(241, 16);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(83, 28);
            this.BtnModify.TabIndex = 2;
            this.BtnModify.Text = "&Modify";
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(14, 16);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(83, 28);
            this.BtnReset.TabIndex = 0;
            this.BtnReset.Text = "&Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(675, 16);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(83, 28);
            this.BtnExit.TabIndex = 5;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(465, 16);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(83, 28);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // panelFill
            // 
            this.panelFill.AutoScroll = true;
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.tabControlOuter);
            this.panelFill.Controls.Add(this.List);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(990, 645);
            this.panelFill.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(11, 3);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Search :";
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(11, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(178, 23);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(992, 680);
            this.panelOuter.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(990, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(990, 30);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(98, 27);
            this.toolStripLabel1.Text = "Formula Master";
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
            this.panelBottom.Location = new System.Drawing.Point(0, 33);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(990, 645);
            this.panelBottom.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "TestNo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Identification Test";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Min";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Max";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "TestNo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Control Test";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 250;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Min";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Max";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "TestNo";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Identification Test";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 250;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Min";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Max";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "TestNo";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Control Test";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 250;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Min";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Max";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "TestNo";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "Line Sample Test";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 250;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "Min";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "Max";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // FrmFormulaNoMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(992, 680);
            this.Controls.Add(this.panelOuter);
            this.MaximizeBox = false;
            this.Name = "FrmFormulaNoMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formula Master";
            this.Load += new System.EventHandler(this.FrmFormulaMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControlOuter.ResumeLayout(false);
            this.tabPageBulkValId.ResumeLayout(false);
            this.tabPageBulkValId.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgValId)).EndInit();
            this.tabPageBulkValCon.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgValCon)).EndInit();
            this.tabPageBulkNonValId.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNonValId)).EndInit();
            this.tabPageBulkNonValCon.ResumeLayout(false);
            this.panelTest.ResumeLayout(false);
            this.panelTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgNonValCon)).EndInit();
            this.tabPageLine.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLine)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelFill.PerformLayout();
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox List;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBulkDescription;
        private System.Windows.Forms.ComboBox CmbTechnicalFamily;
        private System.Windows.Forms.TextBox txtNoOfBatches;
        private System.Windows.Forms.TextBox txtDensity;
        private System.Windows.Forms.CheckBox ChkPreservativetest;
        private System.Windows.Forms.CheckBox ChkMicrobiologyTest;
        private System.Windows.Forms.TextBox txtNorms;
        private System.Windows.Forms.TabControl tabControlOuter;
        private System.Windows.Forms.TabPage tabPageBulkValId;
        private System.Windows.Forms.TabPage tabPageLine;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgLine;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtLineMax;
        private System.Windows.Forms.TextBox txtLineMin;
        private System.Windows.Forms.ComboBox cmbLineTest;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker DtpOfficializationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineTestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineMax;
        private System.Windows.Forms.TabPage tabPageBulkValCon;
        private System.Windows.Forms.TabPage tabPageBulkNonValId;
        private System.Windows.Forms.TabPage tabPageBulkNonValCon;
        private System.Windows.Forms.Panel panelTest;
        private System.Windows.Forms.DataGridView dgNonValCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonValConTestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonValConTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonValConMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonValConMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNonValConMax;
        private System.Windows.Forms.TextBox txtNonValConMin;
        private System.Windows.Forms.ComboBox cmbNonValConTest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgValCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValConTestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValConTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValConMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValConMax;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtValConMax;
        private System.Windows.Forms.TextBox txtValConMin;
        private System.Windows.Forms.ComboBox cmbValConTest;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgNonValId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonValIdTestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonValIdTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonValIdMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonValIdMax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNonValIdMax;
        private System.Windows.Forms.TextBox txtNonValIdMin;
        private System.Windows.Forms.ComboBox cmbNonValIdTest;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveAsNew;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnModify;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button btnValConReset;
        private System.Windows.Forms.Button btnValConDelete;
        private System.Windows.Forms.Button btnValConAdd;
        private System.Windows.Forms.Button btnNonValIdReset;
        private System.Windows.Forms.Button btnNonValIdDelete;
        private System.Windows.Forms.Button btnNonValIdAdd;
        private System.Windows.Forms.Button btnNonValConReset;
        private System.Windows.Forms.Button btnNonValConDelete;
        private System.Windows.Forms.Button btnNonValConAdd;
        private System.Windows.Forms.Button btnLineReset;
        private System.Windows.Forms.Button btnLineDelete;
        private System.Windows.Forms.Button btnLineAdd;
        private System.Windows.Forms.Button btnValIdReset;
        private System.Windows.Forms.Button btnValIdDelete;
        private System.Windows.Forms.DataGridView dgValId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValIdTestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValIdTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValIdMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValIdMax;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnValIdAdd;
        private System.Windows.Forms.TextBox txtValIdMax;
        private System.Windows.Forms.TextBox txtValIdMin;
        private System.Windows.Forms.ComboBox cmbValIdTest;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox CmbFormulaNo;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.DateTimePicker DtpReferenceDate;
        private System.Windows.Forms.CheckBox chkDeactive;
        private System.Windows.Forms.DateTimePicker DtpModificationDate;
        private System.Windows.Forms.DateTimePicker DtpCreationDate;
        private System.Windows.Forms.CheckBox chkExtLabReport;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ComboBox cmbFormulaType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DtpFDAApproval;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label labelNorms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtFILCode;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblFungalCount;
        private System.Windows.Forms.TextBox txtFungalCount;
        private System.Windows.Forms.Label lblBacterialCount;
        private System.Windows.Forms.TextBox txtBacterialCount;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DateTimePicker DtpFDAApprovalExport;
    }
}