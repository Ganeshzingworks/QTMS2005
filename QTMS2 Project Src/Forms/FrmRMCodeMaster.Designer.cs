namespace QTMS.Forms
{
    partial class FrmRMCodeMaster
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
            frmRMCodeMaster_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbRMMasterFields = new System.Windows.Forms.GroupBox();
            this.txtX3Barcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ChkCategory = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRMCodeNoOfLot = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdBtnViscosityIncrease = new System.Windows.Forms.RadioButton();
            this.rdBtnViscosityDecrease = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBtnPHIncrease = new System.Windows.Forms.RadioButton();
            this.rdBtnPHDecrease = new System.Windows.Forms.RadioButton();
            this.lblMicroSpecDate = new System.Windows.Forms.Label();
            this.DtpMicroSpecDate = new System.Windows.Forms.DateTimePicker();
            this.DtpModificationDate = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.DtpCreationDate = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.labelNorms = new System.Windows.Forms.Label();
            this.txtMicroNorms = new System.Windows.Forms.TextBox();
            this.chkFDADone = new System.Windows.Forms.CheckBox();
            this.ChkPreservativeTest = new System.Windows.Forms.CheckBox();
            this.ChkMicrobiologyTest = new System.Windows.Forms.CheckBox();
            this.txtRMSpecification = new System.Windows.Forms.TextBox();
            this.lblRMSpecification = new System.Windows.Forms.Label();
            this.cmbRMFamilyName = new System.Windows.Forms.ComboBox();
            this.lblRMFamilyName = new System.Windows.Forms.Label();
            this.txtINCIName = new System.Windows.Forms.TextBox();
            this.lblINCIName = new System.Windows.Forms.Label();
            this.txtRMDescription = new System.Windows.Forms.TextBox();
            this.lblRMDescription = new System.Windows.Forms.Label();
            this.txtRMCode = new System.Windows.Forms.TextBox();
            this.lblRMCode = new System.Windows.Forms.Label();
            this.gbSupplierAgentFields = new System.Windows.Forms.GroupBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrigin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblplantorigin = new System.Windows.Forms.Label();
            this.lblHalal = new System.Windows.Forms.Label();
            this.cmbHalal = new System.Windows.Forms.ComboBox();
            this.cmbPlantOrigin = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoOfLots = new System.Windows.Forms.TextBox();
            this.dgRMSupplierAgent = new System.Windows.Forms.DataGridView();
            this.cmbAlignemnt = new System.Windows.Forms.ComboBox();
            this.BtnRMCodeReset = new System.Windows.Forms.Button();
            this.BtnRMSupplierAgentDelete = new System.Windows.Forms.Button();
            this.BtnValRMSupplierAgentAdd = new System.Windows.Forms.Button();
            this.txtRMAgentName = new System.Windows.Forms.TextBox();
            this.lblRMAgentName = new System.Windows.Forms.Label();
            this.lblRMSupplierName = new System.Windows.Forms.Label();
            this.cmbRMSupplierName = new System.Windows.Forms.ComboBox();
            this.List = new System.Windows.Forms.ListBox();
            this.gbRMButtons = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.BtnRMExit = new System.Windows.Forms.Button();
            this.BtnRMDelete = new System.Windows.Forms.Button();
            this.BtnRMModify = new System.Windows.Forms.Button();
            this.BtnRMReset = new System.Windows.Forms.Button();
            this.BtnRMSave = new System.Windows.Forms.Button();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtTradeName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ValSupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValRMSupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alignment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValRMAgentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOFLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Halal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantOrigin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryoforigin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TradeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbRMMasterFields.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbSupplierAgentFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRMSupplierAgent)).BeginInit();
            this.gbRMButtons.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRMMasterFields
            // 
            this.gbRMMasterFields.Controls.Add(this.txtX3Barcode);
            this.gbRMMasterFields.Controls.Add(this.label5);
            this.gbRMMasterFields.Controls.Add(this.label11);
            this.gbRMMasterFields.Controls.Add(this.ChkCategory);
            this.gbRMMasterFields.Controls.Add(this.label3);
            this.gbRMMasterFields.Controls.Add(this.txtRMCodeNoOfLot);
            this.gbRMMasterFields.Controls.Add(this.groupBox2);
            this.gbRMMasterFields.Controls.Add(this.groupBox1);
            this.gbRMMasterFields.Controls.Add(this.lblMicroSpecDate);
            this.gbRMMasterFields.Controls.Add(this.DtpMicroSpecDate);
            this.gbRMMasterFields.Controls.Add(this.DtpModificationDate);
            this.gbRMMasterFields.Controls.Add(this.label25);
            this.gbRMMasterFields.Controls.Add(this.DtpCreationDate);
            this.gbRMMasterFields.Controls.Add(this.label24);
            this.gbRMMasterFields.Controls.Add(this.labelNorms);
            this.gbRMMasterFields.Controls.Add(this.txtMicroNorms);
            this.gbRMMasterFields.Controls.Add(this.chkFDADone);
            this.gbRMMasterFields.Controls.Add(this.ChkPreservativeTest);
            this.gbRMMasterFields.Controls.Add(this.ChkMicrobiologyTest);
            this.gbRMMasterFields.Controls.Add(this.txtRMSpecification);
            this.gbRMMasterFields.Controls.Add(this.lblRMSpecification);
            this.gbRMMasterFields.Controls.Add(this.cmbRMFamilyName);
            this.gbRMMasterFields.Controls.Add(this.lblRMFamilyName);
            this.gbRMMasterFields.Controls.Add(this.txtINCIName);
            this.gbRMMasterFields.Controls.Add(this.lblINCIName);
            this.gbRMMasterFields.Controls.Add(this.txtRMDescription);
            this.gbRMMasterFields.Controls.Add(this.lblRMDescription);
            this.gbRMMasterFields.Controls.Add(this.txtRMCode);
            this.gbRMMasterFields.Controls.Add(this.lblRMCode);
            this.gbRMMasterFields.Location = new System.Drawing.Point(208, 6);
            this.gbRMMasterFields.Name = "gbRMMasterFields";
            this.gbRMMasterFields.Size = new System.Drawing.Size(697, 338);
            this.gbRMMasterFields.TabIndex = 1;
            this.gbRMMasterFields.TabStop = false;
            // 
            // txtX3Barcode
            // 
            this.txtX3Barcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtX3Barcode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtX3Barcode.Location = new System.Drawing.Point(486, 265);
            this.txtX3Barcode.Name = "txtX3Barcode";
            this.txtX3Barcode.Size = new System.Drawing.Size(174, 23);
            this.txtX3Barcode.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label5.Location = new System.Drawing.Point(399, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "X3 Barcode";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(413, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "Category";
            // 
            // ChkCategory
            // 
            this.ChkCategory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ChkCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChkCategory.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkCategory.FormattingEnabled = true;
            this.ChkCategory.Location = new System.Drawing.Point(488, 112);
            this.ChkCategory.Name = "ChkCategory";
            this.ChkCategory.Size = new System.Drawing.Size(183, 92);
            this.ChkCategory.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "No Of Lots";
            // 
            // txtRMCodeNoOfLot
            // 
            this.txtRMCodeNoOfLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMCodeNoOfLot.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMCodeNoOfLot.Location = new System.Drawing.Point(153, 255);
            this.txtRMCodeNoOfLot.Name = "txtRMCodeNoOfLot";
            this.txtRMCodeNoOfLot.ReadOnly = true;
            this.txtRMCodeNoOfLot.Size = new System.Drawing.Size(64, 23);
            this.txtRMCodeNoOfLot.TabIndex = 33;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdBtnViscosityIncrease);
            this.groupBox2.Controls.Add(this.rdBtnViscosityDecrease);
            this.groupBox2.Location = new System.Drawing.Point(330, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 40);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // rdBtnViscosityIncrease
            // 
            this.rdBtnViscosityIncrease.AutoSize = true;
            this.rdBtnViscosityIncrease.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnViscosityIncrease.Location = new System.Drawing.Point(6, 10);
            this.rdBtnViscosityIncrease.Name = "rdBtnViscosityIncrease";
            this.rdBtnViscosityIncrease.Size = new System.Drawing.Size(147, 20);
            this.rdBtnViscosityIncrease.TabIndex = 31;
            this.rdBtnViscosityIncrease.Text = "Viscosity Increase";
            this.rdBtnViscosityIncrease.UseVisualStyleBackColor = true;
            // 
            // rdBtnViscosityDecrease
            // 
            this.rdBtnViscosityDecrease.AutoSize = true;
            this.rdBtnViscosityDecrease.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnViscosityDecrease.Location = new System.Drawing.Point(170, 10);
            this.rdBtnViscosityDecrease.Name = "rdBtnViscosityDecrease";
            this.rdBtnViscosityDecrease.Size = new System.Drawing.Size(151, 20);
            this.rdBtnViscosityDecrease.TabIndex = 31;
            this.rdBtnViscosityDecrease.Text = "Viscosity Decrease";
            this.rdBtnViscosityDecrease.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBtnPHIncrease);
            this.groupBox1.Controls.Add(this.rdBtnPHDecrease);
            this.groupBox1.Location = new System.Drawing.Point(51, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 40);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // rdBtnPHIncrease
            // 
            this.rdBtnPHIncrease.AutoSize = true;
            this.rdBtnPHIncrease.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnPHIncrease.Location = new System.Drawing.Point(6, 10);
            this.rdBtnPHIncrease.Name = "rdBtnPHIncrease";
            this.rdBtnPHIncrease.Size = new System.Drawing.Size(105, 20);
            this.rdBtnPHIncrease.TabIndex = 31;
            this.rdBtnPHIncrease.Text = "PH Increase";
            this.rdBtnPHIncrease.UseVisualStyleBackColor = true;
            // 
            // rdBtnPHDecrease
            // 
            this.rdBtnPHDecrease.AutoSize = true;
            this.rdBtnPHDecrease.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnPHDecrease.Location = new System.Drawing.Point(125, 10);
            this.rdBtnPHDecrease.Name = "rdBtnPHDecrease";
            this.rdBtnPHDecrease.Size = new System.Drawing.Size(109, 20);
            this.rdBtnPHDecrease.TabIndex = 31;
            this.rdBtnPHDecrease.Text = "PH Decrease";
            this.rdBtnPHDecrease.UseVisualStyleBackColor = true;
            // 
            // lblMicroSpecDate
            // 
            this.lblMicroSpecDate.AutoSize = true;
            this.lblMicroSpecDate.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblMicroSpecDate.Location = new System.Drawing.Point(368, 239);
            this.lblMicroSpecDate.Name = "lblMicroSpecDate";
            this.lblMicroSpecDate.Size = new System.Drawing.Size(117, 16);
            this.lblMicroSpecDate.TabIndex = 30;
            this.lblMicroSpecDate.Text = "Micro Spec Date";
            // 
            // DtpMicroSpecDate
            // 
            this.DtpMicroSpecDate.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpMicroSpecDate.Checked = false;
            this.DtpMicroSpecDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpMicroSpecDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpMicroSpecDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpMicroSpecDate.Location = new System.Drawing.Point(488, 236);
            this.DtpMicroSpecDate.Name = "DtpMicroSpecDate";
            this.DtpMicroSpecDate.ShowCheckBox = true;
            this.DtpMicroSpecDate.Size = new System.Drawing.Size(142, 23);
            this.DtpMicroSpecDate.TabIndex = 29;
            this.DtpMicroSpecDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // DtpModificationDate
            // 
            this.DtpModificationDate.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpModificationDate.Checked = false;
            this.DtpModificationDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpModificationDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpModificationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpModificationDate.Location = new System.Drawing.Point(153, 144);
            this.DtpModificationDate.Name = "DtpModificationDate";
            this.DtpModificationDate.ShowCheckBox = true;
            this.DtpModificationDate.Size = new System.Drawing.Size(142, 23);
            this.DtpModificationDate.TabIndex = 28;
            this.DtpModificationDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(20, 144);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(123, 23);
            this.label25.TabIndex = 27;
            this.label25.Text = "Modification Date";
            // 
            // DtpCreationDate
            // 
            this.DtpCreationDate.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpCreationDate.Checked = false;
            this.DtpCreationDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpCreationDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpCreationDate.Location = new System.Drawing.Point(153, 115);
            this.DtpCreationDate.Name = "DtpCreationDate";
            this.DtpCreationDate.ShowCheckBox = true;
            this.DtpCreationDate.Size = new System.Drawing.Size(142, 23);
            this.DtpCreationDate.TabIndex = 26;
            this.DtpCreationDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(48, 115);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(102, 23);
            this.label24.TabIndex = 25;
            this.label24.Text = "Creation Date";
            // 
            // labelNorms
            // 
            this.labelNorms.AutoSize = true;
            this.labelNorms.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.labelNorms.Location = new System.Drawing.Point(437, 209);
            this.labelNorms.Name = "labelNorms";
            this.labelNorms.Size = new System.Drawing.Size(48, 16);
            this.labelNorms.TabIndex = 18;
            this.labelNorms.Text = "Norms";
            // 
            // txtMicroNorms
            // 
            this.txtMicroNorms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMicroNorms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMicroNorms.Location = new System.Drawing.Point(488, 207);
            this.txtMicroNorms.Name = "txtMicroNorms";
            this.txtMicroNorms.Size = new System.Drawing.Size(81, 23);
            this.txtMicroNorms.TabIndex = 17;
            // 
            // chkFDADone
            // 
            this.chkFDADone.AutoSize = true;
            this.chkFDADone.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFDADone.Location = new System.Drawing.Point(152, 228);
            this.chkFDADone.Name = "chkFDADone";
            this.chkFDADone.Size = new System.Drawing.Size(53, 20);
            this.chkFDADone.TabIndex = 16;
            this.chkFDADone.Text = "FDA";
            this.chkFDADone.UseVisualStyleBackColor = true;
            this.chkFDADone.CheckedChanged += new System.EventHandler(this.chkFDADone_CheckedChanged);
            // 
            // ChkPreservativeTest
            // 
            this.ChkPreservativeTest.AutoSize = true;
            this.ChkPreservativeTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkPreservativeTest.Location = new System.Drawing.Point(153, 176);
            this.ChkPreservativeTest.Name = "ChkPreservativeTest";
            this.ChkPreservativeTest.Size = new System.Drawing.Size(109, 20);
            this.ChkPreservativeTest.TabIndex = 14;
            this.ChkPreservativeTest.Text = "Preservative";
            this.ChkPreservativeTest.UseVisualStyleBackColor = true;
            this.ChkPreservativeTest.CheckedChanged += new System.EventHandler(this.ChkPreservativeTest_CheckedChanged);
            // 
            // ChkMicrobiologyTest
            // 
            this.ChkMicrobiologyTest.AutoSize = true;
            this.ChkMicrobiologyTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkMicrobiologyTest.Location = new System.Drawing.Point(153, 202);
            this.ChkMicrobiologyTest.Name = "ChkMicrobiologyTest";
            this.ChkMicrobiologyTest.Size = new System.Drawing.Size(108, 20);
            this.ChkMicrobiologyTest.TabIndex = 15;
            this.ChkMicrobiologyTest.Text = "Microbiology";
            this.ChkMicrobiologyTest.UseVisualStyleBackColor = true;
            this.ChkMicrobiologyTest.CheckedChanged += new System.EventHandler(this.ChkMicrobiologyTest_CheckedChanged);
            // 
            // txtRMSpecification
            // 
            this.txtRMSpecification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMSpecification.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMSpecification.Location = new System.Drawing.Point(488, 83);
            this.txtRMSpecification.Name = "txtRMSpecification";
            this.txtRMSpecification.Size = new System.Drawing.Size(174, 23);
            this.txtRMSpecification.TabIndex = 13;
            // 
            // lblRMSpecification
            // 
            this.lblRMSpecification.AutoSize = true;
            this.lblRMSpecification.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMSpecification.Location = new System.Drawing.Point(355, 86);
            this.lblRMSpecification.Name = "lblRMSpecification";
            this.lblRMSpecification.Size = new System.Drawing.Size(129, 16);
            this.lblRMSpecification.TabIndex = 12;
            this.lblRMSpecification.Text = "Specification Date";
            // 
            // cmbRMFamilyName
            // 
            this.cmbRMFamilyName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRMFamilyName.FormattingEnabled = true;
            this.cmbRMFamilyName.Location = new System.Drawing.Point(153, 82);
            this.cmbRMFamilyName.Name = "cmbRMFamilyName";
            this.cmbRMFamilyName.Size = new System.Drawing.Size(174, 24);
            this.cmbRMFamilyName.TabIndex = 9;
            // 
            // lblRMFamilyName
            // 
            this.lblRMFamilyName.AutoSize = true;
            this.lblRMFamilyName.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMFamilyName.Location = new System.Drawing.Point(48, 86);
            this.lblRMFamilyName.Name = "lblRMFamilyName";
            this.lblRMFamilyName.Size = new System.Drawing.Size(89, 16);
            this.lblRMFamilyName.TabIndex = 8;
            this.lblRMFamilyName.Text = "Family Name";
            // 
            // txtINCIName
            // 
            this.txtINCIName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtINCIName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtINCIName.Location = new System.Drawing.Point(153, 48);
            this.txtINCIName.Name = "txtINCIName";
            this.txtINCIName.Size = new System.Drawing.Size(174, 23);
            this.txtINCIName.TabIndex = 3;
            // 
            // lblINCIName
            // 
            this.lblINCIName.AutoSize = true;
            this.lblINCIName.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblINCIName.Location = new System.Drawing.Point(48, 51);
            this.lblINCIName.Name = "lblINCIName";
            this.lblINCIName.Size = new System.Drawing.Size(77, 16);
            this.lblINCIName.TabIndex = 2;
            this.lblINCIName.Text = "INCI Name";
            // 
            // txtRMDescription
            // 
            this.txtRMDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMDescription.Location = new System.Drawing.Point(488, 48);
            this.txtRMDescription.Name = "txtRMDescription";
            this.txtRMDescription.Size = new System.Drawing.Size(174, 23);
            this.txtRMDescription.TabIndex = 5;
            // 
            // lblRMDescription
            // 
            this.lblRMDescription.AutoSize = true;
            this.lblRMDescription.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMDescription.Location = new System.Drawing.Point(355, 51);
            this.lblRMDescription.Name = "lblRMDescription";
            this.lblRMDescription.Size = new System.Drawing.Size(81, 16);
            this.lblRMDescription.TabIndex = 4;
            this.lblRMDescription.Text = "Description";
            // 
            // txtRMCode
            // 
            this.txtRMCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMCode.Location = new System.Drawing.Point(288, 14);
            this.txtRMCode.MaxLength = 32525;
            this.txtRMCode.Name = "txtRMCode";
            this.txtRMCode.Size = new System.Drawing.Size(208, 23);
            this.txtRMCode.TabIndex = 1;
            this.txtRMCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRMCode_KeyPress);
            // 
            // lblRMCode
            // 
            this.lblRMCode.AutoSize = true;
            this.lblRMCode.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblRMCode.Location = new System.Drawing.Point(218, 17);
            this.lblRMCode.Name = "lblRMCode";
            this.lblRMCode.Size = new System.Drawing.Size(65, 16);
            this.lblRMCode.TabIndex = 0;
            this.lblRMCode.Text = "RM Code";
            // 
            // gbSupplierAgentFields
            // 
            this.gbSupplierAgentFields.Controls.Add(this.txtTradeName);
            this.gbSupplierAgentFields.Controls.Add(this.label7);
            this.gbSupplierAgentFields.Controls.Add(this.txtBarcode);
            this.gbSupplierAgentFields.Controls.Add(this.label6);
            this.gbSupplierAgentFields.Controls.Add(this.txtOrigin);
            this.gbSupplierAgentFields.Controls.Add(this.label4);
            this.gbSupplierAgentFields.Controls.Add(this.lblplantorigin);
            this.gbSupplierAgentFields.Controls.Add(this.lblHalal);
            this.gbSupplierAgentFields.Controls.Add(this.cmbHalal);
            this.gbSupplierAgentFields.Controls.Add(this.cmbPlantOrigin);
            this.gbSupplierAgentFields.Controls.Add(this.label2);
            this.gbSupplierAgentFields.Controls.Add(this.label1);
            this.gbSupplierAgentFields.Controls.Add(this.txtNoOfLots);
            this.gbSupplierAgentFields.Controls.Add(this.dgRMSupplierAgent);
            this.gbSupplierAgentFields.Controls.Add(this.cmbAlignemnt);
            this.gbSupplierAgentFields.Controls.Add(this.BtnRMCodeReset);
            this.gbSupplierAgentFields.Controls.Add(this.BtnRMSupplierAgentDelete);
            this.gbSupplierAgentFields.Controls.Add(this.BtnValRMSupplierAgentAdd);
            this.gbSupplierAgentFields.Controls.Add(this.txtRMAgentName);
            this.gbSupplierAgentFields.Controls.Add(this.lblRMAgentName);
            this.gbSupplierAgentFields.Controls.Add(this.lblRMSupplierName);
            this.gbSupplierAgentFields.Controls.Add(this.cmbRMSupplierName);
            this.gbSupplierAgentFields.Location = new System.Drawing.Point(148, 350);
            this.gbSupplierAgentFields.Name = "gbSupplierAgentFields";
            this.gbSupplierAgentFields.Size = new System.Drawing.Size(952, 222);
            this.gbSupplierAgentFields.TabIndex = 2;
            this.gbSupplierAgentFields.TabStop = false;
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(653, 35);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(114, 23);
            this.txtBarcode.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label6.Location = new System.Drawing.Point(675, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Barcode";
            // 
            // txtOrigin
            // 
            this.txtOrigin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrigin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrigin.Location = new System.Drawing.Point(479, 33);
            this.txtOrigin.Name = "txtOrigin";
            this.txtOrigin.Size = new System.Drawing.Size(69, 23);
            this.txtOrigin.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(476, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Country of Origin";
            // 
            // lblplantorigin
            // 
            this.lblplantorigin.AutoSize = true;
            this.lblplantorigin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblplantorigin.Location = new System.Drawing.Point(398, 16);
            this.lblplantorigin.Name = "lblplantorigin";
            this.lblplantorigin.Size = new System.Drawing.Size(75, 13);
            this.lblplantorigin.TabIndex = 20;
            this.lblplantorigin.Text = "Animal Free";
            // 
            // lblHalal
            // 
            this.lblHalal.AutoSize = true;
            this.lblHalal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalal.Location = new System.Drawing.Point(312, 17);
            this.lblHalal.Name = "lblHalal";
            this.lblHalal.Size = new System.Drawing.Size(35, 13);
            this.lblHalal.TabIndex = 19;
            this.lblHalal.Text = "Halal";
            // 
            // cmbHalal
            // 
            this.cmbHalal.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHalal.FormattingEnabled = true;
            this.cmbHalal.Items.AddRange(new object[] {
            "--Select--",
            "Yes",
            "No"});
            this.cmbHalal.Location = new System.Drawing.Point(312, 33);
            this.cmbHalal.Name = "cmbHalal";
            this.cmbHalal.Size = new System.Drawing.Size(75, 24);
            this.cmbHalal.TabIndex = 18;
            // 
            // cmbPlantOrigin
            // 
            this.cmbPlantOrigin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlantOrigin.FormattingEnabled = true;
            this.cmbPlantOrigin.Items.AddRange(new object[] {
            "--Select--",
            "Yes",
            "No"});
            this.cmbPlantOrigin.Location = new System.Drawing.Point(399, 33);
            this.cmbPlantOrigin.Name = "cmbPlantOrigin";
            this.cmbPlantOrigin.Size = new System.Drawing.Size(74, 24);
            this.cmbPlantOrigin.TabIndex = 17;
            this.cmbPlantOrigin.SelectedIndexChanged += new System.EventHandler(this.cmbPlantOrigin_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(142, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Alignment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(583, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "No Of Lots";
            // 
            // txtNoOfLots
            // 
            this.txtNoOfLots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfLots.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfLots.Location = new System.Drawing.Point(583, 35);
            this.txtNoOfLots.Name = "txtNoOfLots";
            this.txtNoOfLots.ReadOnly = true;
            this.txtNoOfLots.Size = new System.Drawing.Size(64, 23);
            this.txtNoOfLots.TabIndex = 13;
            // 
            // dgRMSupplierAgent
            // 
            this.dgRMSupplierAgent.AllowUserToAddRows = false;
            this.dgRMSupplierAgent.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgRMSupplierAgent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRMSupplierAgent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgRMSupplierAgent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRMSupplierAgent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ValSupplierID,
            this.ValRMSupplierName,
            this.Alignment,
            this.ValRMAgentName,
            this.NoOFLot,
            this.Halal,
            this.PlantOrigin,
            this.countryoforigin,
            this.Barcode,
            this.TradeName});
            this.dgRMSupplierAgent.Location = new System.Drawing.Point(9, 117);
            this.dgRMSupplierAgent.Name = "dgRMSupplierAgent";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRMSupplierAgent.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgRMSupplierAgent.Size = new System.Drawing.Size(937, 91);
            this.dgRMSupplierAgent.TabIndex = 12;
            this.dgRMSupplierAgent.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgRMSupplierAgent_RowHeaderMouseDoubleClick);
            // 
            // cmbAlignemnt
            // 
            this.cmbAlignemnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlignemnt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAlignemnt.FormattingEnabled = true;
            this.cmbAlignemnt.Items.AddRange(new object[] {
            "--Select--",
            "Aligned",
            "Not Aligned"});
            this.cmbAlignemnt.Location = new System.Drawing.Point(142, 34);
            this.cmbAlignemnt.Name = "cmbAlignemnt";
            this.cmbAlignemnt.Size = new System.Drawing.Size(84, 24);
            this.cmbAlignemnt.TabIndex = 11;
            // 
            // BtnRMCodeReset
            // 
            this.BtnRMCodeReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMCodeReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMCodeReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRMCodeReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMCodeReset.Location = new System.Drawing.Point(328, 75);
            this.BtnRMCodeReset.Name = "BtnRMCodeReset";
            this.BtnRMCodeReset.Size = new System.Drawing.Size(75, 26);
            this.BtnRMCodeReset.TabIndex = 4;
            this.BtnRMCodeReset.Text = "&Reset";
            this.BtnRMCodeReset.UseVisualStyleBackColor = false;
            this.BtnRMCodeReset.Click += new System.EventHandler(this.BtnRMCodeReset_Click);
            // 
            // BtnRMSupplierAgentDelete
            // 
            this.BtnRMSupplierAgentDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMSupplierAgentDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMSupplierAgentDelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRMSupplierAgentDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMSupplierAgentDelete.Location = new System.Drawing.Point(439, 75);
            this.BtnRMSupplierAgentDelete.Name = "BtnRMSupplierAgentDelete";
            this.BtnRMSupplierAgentDelete.Size = new System.Drawing.Size(75, 26);
            this.BtnRMSupplierAgentDelete.TabIndex = 5;
            this.BtnRMSupplierAgentDelete.Text = "&Delete";
            this.BtnRMSupplierAgentDelete.UseVisualStyleBackColor = false;
            this.BtnRMSupplierAgentDelete.Click += new System.EventHandler(this.BtnRMSupplierAgentDelete_Click);
            // 
            // BtnValRMSupplierAgentAdd
            // 
            this.BtnValRMSupplierAgentAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnValRMSupplierAgentAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnValRMSupplierAgentAdd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnValRMSupplierAgentAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnValRMSupplierAgentAdd.Location = new System.Drawing.Point(550, 75);
            this.BtnValRMSupplierAgentAdd.Name = "BtnValRMSupplierAgentAdd";
            this.BtnValRMSupplierAgentAdd.Size = new System.Drawing.Size(75, 26);
            this.BtnValRMSupplierAgentAdd.TabIndex = 6;
            this.BtnValRMSupplierAgentAdd.Text = "&Add";
            this.BtnValRMSupplierAgentAdd.UseVisualStyleBackColor = false;
            this.BtnValRMSupplierAgentAdd.Click += new System.EventHandler(this.BtnValRMSupplierAgentAdd_Click);
            // 
            // txtRMAgentName
            // 
            this.txtRMAgentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMAgentName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMAgentName.Location = new System.Drawing.Point(234, 35);
            this.txtRMAgentName.Name = "txtRMAgentName";
            this.txtRMAgentName.Size = new System.Drawing.Size(69, 23);
            this.txtRMAgentName.TabIndex = 3;
            // 
            // lblRMAgentName
            // 
            this.lblRMAgentName.AutoSize = true;
            this.lblRMAgentName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMAgentName.Location = new System.Drawing.Point(231, 16);
            this.lblRMAgentName.Name = "lblRMAgentName";
            this.lblRMAgentName.Size = new System.Drawing.Size(74, 13);
            this.lblRMAgentName.TabIndex = 2;
            this.lblRMAgentName.Text = "Enter Agent";
            // 
            // lblRMSupplierName
            // 
            this.lblRMSupplierName.AutoSize = true;
            this.lblRMSupplierName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRMSupplierName.Location = new System.Drawing.Point(6, 16);
            this.lblRMSupplierName.Name = "lblRMSupplierName";
            this.lblRMSupplierName.Size = new System.Drawing.Size(93, 13);
            this.lblRMSupplierName.TabIndex = 0;
            this.lblRMSupplierName.Text = "Select Supplier";
            // 
            // cmbRMSupplierName
            // 
            this.cmbRMSupplierName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRMSupplierName.FormattingEnabled = true;
            this.cmbRMSupplierName.Location = new System.Drawing.Point(6, 34);
            this.cmbRMSupplierName.Name = "cmbRMSupplierName";
            this.cmbRMSupplierName.Size = new System.Drawing.Size(126, 24);
            this.cmbRMSupplierName.TabIndex = 1;
            this.cmbRMSupplierName.SelectionChangeCommitted += new System.EventHandler(this.cmbRMSupplierName_SelectionChangeCommitted);
            // 
            // List
            // 
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.List.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.FormattingEnabled = true;
            this.List.ItemHeight = 16;
            this.List.Location = new System.Drawing.Point(11, 59);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(131, 482);
            this.List.TabIndex = 4;
            this.List.DoubleClick += new System.EventHandler(this.List_DoubleClick);
            this.List.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.List_KeyPress);
            // 
            // gbRMButtons
            // 
            this.gbRMButtons.Controls.Add(this.btnExport);
            this.gbRMButtons.Controls.Add(this.BtnRMExit);
            this.gbRMButtons.Controls.Add(this.BtnRMDelete);
            this.gbRMButtons.Controls.Add(this.BtnRMModify);
            this.gbRMButtons.Controls.Add(this.BtnRMReset);
            this.gbRMButtons.Controls.Add(this.BtnRMSave);
            this.gbRMButtons.Location = new System.Drawing.Point(208, 581);
            this.gbRMButtons.Name = "gbRMButtons";
            this.gbRMButtons.Size = new System.Drawing.Size(697, 47);
            this.gbRMButtons.TabIndex = 3;
            this.gbRMButtons.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExport.Location = new System.Drawing.Point(457, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(71, 29);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // BtnRMExit
            // 
            this.BtnRMExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMExit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnRMExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMExit.Location = new System.Drawing.Point(553, 12);
            this.BtnRMExit.Name = "BtnRMExit";
            this.BtnRMExit.Size = new System.Drawing.Size(66, 29);
            this.BtnRMExit.TabIndex = 4;
            this.BtnRMExit.Text = "&Exit";
            this.BtnRMExit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnRMExit.UseVisualStyleBackColor = false;
            this.BtnRMExit.Click += new System.EventHandler(this.BtnRMExit_Click_1);
            // 
            // BtnRMDelete
            // 
            this.BtnRMDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMDelete.Enabled = false;
            this.BtnRMDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMDelete.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnRMDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMDelete.Location = new System.Drawing.Point(269, 11);
            this.BtnRMDelete.Name = "BtnRMDelete";
            this.BtnRMDelete.Size = new System.Drawing.Size(66, 29);
            this.BtnRMDelete.TabIndex = 2;
            this.BtnRMDelete.Text = "&Delete";
            this.BtnRMDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnRMDelete.UseVisualStyleBackColor = false;
            this.BtnRMDelete.Click += new System.EventHandler(this.BtnRMDelete_Click);
            // 
            // BtnRMModify
            // 
            this.BtnRMModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMModify.Enabled = false;
            this.BtnRMModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMModify.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnRMModify.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMModify.Location = new System.Drawing.Point(169, 11);
            this.BtnRMModify.Name = "BtnRMModify";
            this.BtnRMModify.Size = new System.Drawing.Size(72, 29);
            this.BtnRMModify.TabIndex = 1;
            this.BtnRMModify.Text = "&Modify";
            this.BtnRMModify.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnRMModify.UseVisualStyleBackColor = false;
            this.BtnRMModify.Click += new System.EventHandler(this.BtnRMModify_Click);
            // 
            // BtnRMReset
            // 
            this.BtnRMReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMReset.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnRMReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMReset.Location = new System.Drawing.Point(77, 11);
            this.BtnRMReset.Name = "BtnRMReset";
            this.BtnRMReset.Size = new System.Drawing.Size(66, 29);
            this.BtnRMReset.TabIndex = 0;
            this.BtnRMReset.Text = "&Reset";
            this.BtnRMReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnRMReset.UseVisualStyleBackColor = false;
            this.BtnRMReset.Click += new System.EventHandler(this.BtnRMReset_Click);
            // 
            // BtnRMSave
            // 
            this.BtnRMSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnRMSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRMSave.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnRMSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRMSave.Location = new System.Drawing.Point(363, 11);
            this.BtnRMSave.Name = "BtnRMSave";
            this.BtnRMSave.Size = new System.Drawing.Size(66, 29);
            this.BtnRMSave.TabIndex = 3;
            this.BtnRMSave.Text = "&Save";
            this.BtnRMSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnRMSave.UseVisualStyleBackColor = false;
            this.BtnRMSave.Click += new System.EventHandler(this.BtnRMSave_Click);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(1125, 676);
            this.panelOuter.TabIndex = 5;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1123, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(1123, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(102, 27);
            this.toolStripLabel1.Text = "RM Code Master";
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
            this.panelBottom.Location = new System.Drawing.Point(0, 33);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1119, 639);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.gbRMButtons);
            this.panelFill.Controls.Add(this.gbSupplierAgentFields);
            this.panelFill.Controls.Add(this.gbRMMasterFields);
            this.panelFill.Controls.Add(this.List);
            this.panelFill.Location = new System.Drawing.Point(0, 3);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(1113, 632);
            this.panelFill.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(16, 9);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(11, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(130, 23);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // txtTradeName
            // 
            this.txtTradeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTradeName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTradeName.Location = new System.Drawing.Point(773, 35);
            this.txtTradeName.Name = "txtTradeName";
            this.txtTradeName.Size = new System.Drawing.Size(173, 23);
            this.txtTradeName.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label7.Location = new System.Drawing.Point(831, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Trade Name";
            // 
            // ValSupplierID
            // 
            this.ValSupplierID.HeaderText = "SupplierID";
            this.ValSupplierID.Name = "ValSupplierID";
            this.ValSupplierID.ReadOnly = true;
            this.ValSupplierID.Visible = false;
            this.ValSupplierID.Width = 50;
            // 
            // ValRMSupplierName
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValRMSupplierName.DefaultCellStyle = dataGridViewCellStyle6;
            this.ValRMSupplierName.HeaderText = "Supplier";
            this.ValRMSupplierName.Name = "ValRMSupplierName";
            this.ValRMSupplierName.ReadOnly = true;
            this.ValRMSupplierName.Width = 120;
            // 
            // Alignment
            // 
            this.Alignment.HeaderText = "Is Aligned";
            this.Alignment.Name = "Alignment";
            this.Alignment.ReadOnly = true;
            this.Alignment.Width = 90;
            // 
            // ValRMAgentName
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValRMAgentName.DefaultCellStyle = dataGridViewCellStyle7;
            this.ValRMAgentName.HeaderText = "Agent";
            this.ValRMAgentName.Name = "ValRMAgentName";
            this.ValRMAgentName.ReadOnly = true;
            this.ValRMAgentName.Width = 50;
            // 
            // NoOFLot
            // 
            this.NoOFLot.HeaderText = "No Of Lots";
            this.NoOFLot.Name = "NoOFLot";
            this.NoOFLot.ReadOnly = true;
            this.NoOFLot.Width = 105;
            // 
            // Halal
            // 
            this.Halal.HeaderText = "Halal";
            this.Halal.Name = "Halal";
            this.Halal.ReadOnly = true;
            this.Halal.Width = 75;
            // 
            // PlantOrigin
            // 
            this.PlantOrigin.HeaderText = "Animal Free";
            this.PlantOrigin.Name = "PlantOrigin";
            this.PlantOrigin.ReadOnly = true;
            this.PlantOrigin.Width = 105;
            // 
            // countryoforigin
            // 
            this.countryoforigin.HeaderText = "Country of Origin";
            this.countryoforigin.Name = "countryoforigin";
            this.countryoforigin.ReadOnly = true;
            this.countryoforigin.Width = 150;
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            // 
            // TradeName
            // 
            this.TradeName.HeaderText = "Trade Name";
            this.TradeName.Name = "TradeName";
            this.TradeName.ReadOnly = true;
            // 
            // FrmRMCodeMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1125, 676);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRMCodeMaster";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RM Code Master";
            this.Load += new System.EventHandler(this.FrmRMMaster_Load);
            this.gbRMMasterFields.ResumeLayout(false);
            this.gbRMMasterFields.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSupplierAgentFields.ResumeLayout(false);
            this.gbSupplierAgentFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRMSupplierAgent)).EndInit();
            this.gbRMButtons.ResumeLayout(false);
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

        private System.Windows.Forms.GroupBox gbRMMasterFields;
        private System.Windows.Forms.GroupBox gbSupplierAgentFields;
        private System.Windows.Forms.TextBox txtRMSpecification;
        private System.Windows.Forms.Label lblRMSpecification;
        private System.Windows.Forms.ComboBox cmbRMFamilyName;
        private System.Windows.Forms.Label lblRMFamilyName;
        private System.Windows.Forms.TextBox txtINCIName;
        private System.Windows.Forms.Label lblINCIName;
        private System.Windows.Forms.TextBox txtRMDescription;
        private System.Windows.Forms.Label lblRMDescription;
        private System.Windows.Forms.TextBox txtRMCode;
        private System.Windows.Forms.Label lblRMCode;
        private System.Windows.Forms.ListBox List;
        private System.Windows.Forms.Button BtnValRMSupplierAgentAdd;
        private System.Windows.Forms.TextBox txtRMAgentName;
        private System.Windows.Forms.Label lblRMAgentName;
        private System.Windows.Forms.Label lblRMSupplierName;
        private System.Windows.Forms.ComboBox cmbRMSupplierName;
        private System.Windows.Forms.GroupBox gbRMButtons;
        private System.Windows.Forms.Button BtnRMExit;
        private System.Windows.Forms.Button BtnRMDelete;
        private System.Windows.Forms.Button BtnRMModify;
        private System.Windows.Forms.Button BtnRMReset;
        private System.Windows.Forms.Button BtnRMSave;
        private System.Windows.Forms.Button BtnRMSupplierAgentDelete;
        private System.Windows.Forms.Button BtnRMCodeReset;
        private System.Windows.Forms.CheckBox chkFDADone;
        private System.Windows.Forms.CheckBox ChkPreservativeTest;
        private System.Windows.Forms.CheckBox ChkMicrobiologyTest;
        private System.Windows.Forms.TextBox txtMicroNorms;
        private System.Windows.Forms.Label labelNorms;
        private System.Windows.Forms.DateTimePicker DtpModificationDate;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker DtpCreationDate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblMicroSpecDate;
        private System.Windows.Forms.DateTimePicker DtpMicroSpecDate;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.RadioButton rdBtnViscosityDecrease;
        private System.Windows.Forms.RadioButton rdBtnViscosityIncrease;
        private System.Windows.Forms.RadioButton rdBtnPHDecrease;
        private System.Windows.Forms.RadioButton rdBtnPHIncrease;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cmbAlignemnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoOfLots;
        private System.Windows.Forms.DataGridView dgRMSupplierAgent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRMCodeNoOfLot;
        private System.Windows.Forms.Label lblHalal;
        private System.Windows.Forms.ComboBox cmbHalal;
        private System.Windows.Forms.ComboBox cmbPlantOrigin;
        private System.Windows.Forms.Label lblplantorigin;
        private System.Windows.Forms.TextBox txtOrigin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckedListBox ChkCategory;
        private System.Windows.Forms.TextBox txtX3Barcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTradeName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValSupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValRMSupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alignment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValRMAgentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOFLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Halal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantOrigin;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryoforigin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TradeName;
    }
}