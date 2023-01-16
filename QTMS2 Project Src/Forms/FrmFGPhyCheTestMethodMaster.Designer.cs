namespace QTMS.Forms
{
    partial class FrmFGPhyCheTestMethodMaster
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
            frmFGPhyCheTestMethodMaster_Obj = null;
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
            this.List = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxSaveAs = new System.Windows.Forms.GroupBox();
            this.cmbFormulaNoSaveAs = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveAsNew = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.CmbFormulaNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlOuter = new System.Windows.Forms.TabControl();
            this.tabPageFGId = new System.Windows.Forms.TabPage();
            this.btnShow = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMethodName = new System.Windows.Forms.TextBox();
            this.btnFGIdReset = new System.Windows.Forms.Button();
            this.btnFGIdDelete = new System.Windows.Forms.Button();
            this.dgFGId = new System.Windows.Forms.DataGridView();
            this.FGIdTestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGIdTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MethodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGIdMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGIdMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnFGIdAdd = new System.Windows.Forms.Button();
            this.txtFGIdMax = new System.Windows.Forms.TextBox();
            this.txtFGIdMin = new System.Windows.Forms.TextBox();
            this.cmbFGIdTest = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPageFGCon = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCMethodName = new System.Windows.Forms.TextBox();
            this.btnFGConReset = new System.Windows.Forms.Button();
            this.btnFGConDelete = new System.Windows.Forms.Button();
            this.btnFGConAdd = new System.Windows.Forms.Button();
            this.dgFGCon = new System.Windows.Forms.DataGridView();
            this.FGConTestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGConTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MethodCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGConMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGConMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtFGConMax = new System.Windows.Forms.TextBox();
            this.txtFGConMin = new System.Windows.Forms.TextBox();
            this.cmbFGConTest = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxSaveAs.SuspendLayout();
            this.tabControlOuter.SuspendLayout();
            this.tabPageFGId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFGId)).BeginInit();
            this.tabPageFGCon.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFGCon)).BeginInit();
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
            this.List.Location = new System.Drawing.Point(11, 60);
            this.List.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(207, 450);
            this.List.TabIndex = 5;
            this.List.DoubleClick += new System.EventHandler(this.List_DoubleClick);
            this.List.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.List_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxSaveAs);
            this.groupBox1.Controls.Add(this.btnSaveAsNew);
            this.groupBox1.Controls.Add(this.BtnDelete);
            this.groupBox1.Controls.Add(this.BtnReset);
            this.groupBox1.Controls.Add(this.BtnExit);
            this.groupBox1.Controls.Add(this.CmbFormulaNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(231, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(597, 163);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBoxSaveAs
            // 
            this.groupBoxSaveAs.Controls.Add(this.cmbFormulaNoSaveAs);
            this.groupBoxSaveAs.Controls.Add(this.label2);
            this.groupBoxSaveAs.Controls.Add(this.btnSave);
            this.groupBoxSaveAs.Location = new System.Drawing.Point(71, 47);
            this.groupBoxSaveAs.Name = "groupBoxSaveAs";
            this.groupBoxSaveAs.Size = new System.Drawing.Size(455, 58);
            this.groupBoxSaveAs.TabIndex = 11;
            this.groupBoxSaveAs.TabStop = false;
            this.groupBoxSaveAs.Visible = false;
            // 
            // cmbFormulaNoSaveAs
            // 
            this.cmbFormulaNoSaveAs.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbFormulaNoSaveAs.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormulaNoSaveAs.FormattingEnabled = true;
            this.cmbFormulaNoSaveAs.Location = new System.Drawing.Point(92, 18);
            this.cmbFormulaNoSaveAs.Name = "cmbFormulaNoSaveAs";
            this.cmbFormulaNoSaveAs.Size = new System.Drawing.Size(280, 24);
            this.cmbFormulaNoSaveAs.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 22);
            this.label2.TabIndex = 12;
            this.label2.Text = "Save As";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Location = new System.Drawing.Point(378, 16);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 28);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAsNew
            // 
            this.btnSaveAsNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSaveAsNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAsNew.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAsNew.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveAsNew.Location = new System.Drawing.Point(200, 116);
            this.btnSaveAsNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveAsNew.Name = "btnSaveAsNew";
            this.btnSaveAsNew.Size = new System.Drawing.Size(93, 28);
            this.btnSaveAsNew.TabIndex = 9;
            this.btnSaveAsNew.Text = "Save&As";
            this.btnSaveAsNew.UseVisualStyleBackColor = false;
            this.btnSaveAsNew.Click += new System.EventHandler(this.btnSaveAsNew_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(313, 116);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(93, 28);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(87, 116);
            this.BtnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(93, 28);
            this.BtnReset.TabIndex = 6;
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
            this.BtnExit.Location = new System.Drawing.Point(426, 116);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(93, 28);
            this.BtnExit.TabIndex = 8;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // CmbFormulaNo
            // 
            this.CmbFormulaNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbFormulaNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFormulaNo.FormattingEnabled = true;
            this.CmbFormulaNo.Location = new System.Drawing.Point(206, 17);
            this.CmbFormulaNo.Name = "CmbFormulaNo";
            this.CmbFormulaNo.Size = new System.Drawing.Size(280, 24);
            this.CmbFormulaNo.TabIndex = 0;
            this.CmbFormulaNo.SelectionChangeCommitted += new System.EventHandler(this.CmbFormulaNo_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Formula No.";
            // 
            // tabControlOuter
            // 
            this.tabControlOuter.AllowDrop = true;
            this.tabControlOuter.Controls.Add(this.tabPageFGId);
            this.tabControlOuter.Controls.Add(this.tabPageFGCon);
            this.tabControlOuter.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlOuter.Location = new System.Drawing.Point(231, 177);
            this.tabControlOuter.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlOuter.Name = "tabControlOuter";
            this.tabControlOuter.Padding = new System.Drawing.Point(0, 0);
            this.tabControlOuter.SelectedIndex = 0;
            this.tabControlOuter.Size = new System.Drawing.Size(601, 332);
            this.tabControlOuter.TabIndex = 8;
            this.tabControlOuter.TabStop = false;
            // 
            // tabPageFGId
            // 
            this.tabPageFGId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.tabPageFGId.Controls.Add(this.btnShow);
            this.tabPageFGId.Controls.Add(this.label3);
            this.tabPageFGId.Controls.Add(this.txtMethodName);
            this.tabPageFGId.Controls.Add(this.btnFGIdReset);
            this.tabPageFGId.Controls.Add(this.btnFGIdDelete);
            this.tabPageFGId.Controls.Add(this.dgFGId);
            this.tabPageFGId.Controls.Add(this.label14);
            this.tabPageFGId.Controls.Add(this.label15);
            this.tabPageFGId.Controls.Add(this.btnFGIdAdd);
            this.tabPageFGId.Controls.Add(this.txtFGIdMax);
            this.tabPageFGId.Controls.Add(this.txtFGIdMin);
            this.tabPageFGId.Controls.Add(this.cmbFGIdTest);
            this.tabPageFGId.Controls.Add(this.label16);
            this.tabPageFGId.Location = new System.Drawing.Point(4, 25);
            this.tabPageFGId.Name = "tabPageFGId";
            this.tabPageFGId.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFGId.Size = new System.Drawing.Size(593, 303);
            this.tabPageFGId.TabIndex = 1;
            this.tabPageFGId.Text = "Identification";
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnShow.Location = new System.Drawing.Point(445, 117);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(70, 26);
            this.btnShow.TabIndex = 41;
            this.btnShow.Text = "Show";
            this.btnShow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Visible = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Method Name :";
            this.label3.Visible = false;
            // 
            // txtMethodName
            // 
            this.txtMethodName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMethodName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMethodName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMethodName.Location = new System.Drawing.Point(134, 77);
            this.txtMethodName.MaxLength = 25;
            this.txtMethodName.Name = "txtMethodName";
            this.txtMethodName.Size = new System.Drawing.Size(274, 23);
            this.txtMethodName.TabIndex = 39;
            this.txtMethodName.Visible = false;
            // 
            // btnFGIdReset
            // 
            this.btnFGIdReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnFGIdReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFGIdReset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFGIdReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFGIdReset.Location = new System.Drawing.Point(176, 117);
            this.btnFGIdReset.Name = "btnFGIdReset";
            this.btnFGIdReset.Size = new System.Drawing.Size(70, 26);
            this.btnFGIdReset.TabIndex = 38;
            this.btnFGIdReset.Text = "Reset ";
            this.btnFGIdReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFGIdReset.UseVisualStyleBackColor = false;
            this.btnFGIdReset.Click += new System.EventHandler(this.btnFGIdReset_Click);
            // 
            // btnFGIdDelete
            // 
            this.btnFGIdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnFGIdDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFGIdDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFGIdDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFGIdDelete.Location = new System.Drawing.Point(265, 117);
            this.btnFGIdDelete.Name = "btnFGIdDelete";
            this.btnFGIdDelete.Size = new System.Drawing.Size(70, 26);
            this.btnFGIdDelete.TabIndex = 37;
            this.btnFGIdDelete.Text = "Delete";
            this.btnFGIdDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFGIdDelete.UseVisualStyleBackColor = false;
            this.btnFGIdDelete.Click += new System.EventHandler(this.btnFGIdDelete_Click);
            // 
            // dgFGId
            // 
            this.dgFGId.AllowUserToAddRows = false;
            this.dgFGId.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgFGId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFGId.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgFGId.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFGId.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FGIdTestNo,
            this.FGIdTest,
            this.MethodName,
            this.FGIdMin,
            this.FGIdMax});
            this.dgFGId.Location = new System.Drawing.Point(9, 162);
            this.dgFGId.MultiSelect = false;
            this.dgFGId.Name = "dgFGId";
            this.dgFGId.Size = new System.Drawing.Size(578, 135);
            this.dgFGId.TabIndex = 36;
            this.dgFGId.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFGId_RowEnter);
            // 
            // FGIdTestNo
            // 
            this.FGIdTestNo.HeaderText = "TestNo";
            this.FGIdTestNo.Name = "FGIdTestNo";
            this.FGIdTestNo.Visible = false;
            this.FGIdTestNo.Width = 5;
            // 
            // FGIdTest
            // 
            this.FGIdTest.HeaderText = "Identification Test";
            this.FGIdTest.Name = "FGIdTest";
            this.FGIdTest.ReadOnly = true;
            this.FGIdTest.Width = 200;
            // 
            // MethodName
            // 
            this.MethodName.HeaderText = "Method Name";
            this.MethodName.Name = "MethodName";
            this.MethodName.Visible = false;
            this.MethodName.Width = 150;
            // 
            // FGIdMin
            // 
            this.FGIdMin.HeaderText = "Min";
            this.FGIdMin.Name = "FGIdMin";
            this.FGIdMin.ReadOnly = true;
            this.FGIdMin.Width = 90;
            // 
            // FGIdMax
            // 
            this.FGIdMax.HeaderText = "Max";
            this.FGIdMax.Name = "FGIdMax";
            this.FGIdMax.ReadOnly = true;
            this.FGIdMax.Width = 90;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(530, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 16);
            this.label14.TabIndex = 35;
            this.label14.Text = "Max";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(445, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 16);
            this.label15.TabIndex = 34;
            this.label15.Text = "Min";
            // 
            // btnFGIdAdd
            // 
            this.btnFGIdAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnFGIdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFGIdAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFGIdAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFGIdAdd.Location = new System.Drawing.Point(354, 117);
            this.btnFGIdAdd.Name = "btnFGIdAdd";
            this.btnFGIdAdd.Size = new System.Drawing.Size(70, 26);
            this.btnFGIdAdd.TabIndex = 32;
            this.btnFGIdAdd.Text = "Add ";
            this.btnFGIdAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFGIdAdd.UseVisualStyleBackColor = false;
            this.btnFGIdAdd.Click += new System.EventHandler(this.btnFGIdAdd_Click);
            // 
            // txtFGIdMax
            // 
            this.txtFGIdMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFGIdMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFGIdMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFGIdMax.Location = new System.Drawing.Point(506, 38);
            this.txtFGIdMax.MaxLength = 25;
            this.txtFGIdMax.Name = "txtFGIdMax";
            this.txtFGIdMax.Size = new System.Drawing.Size(77, 23);
            this.txtFGIdMax.TabIndex = 31;
            this.txtFGIdMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFGIdMax_KeyPress);
            // 
            // txtFGIdMin
            // 
            this.txtFGIdMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFGIdMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFGIdMin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFGIdMin.Location = new System.Drawing.Point(423, 38);
            this.txtFGIdMin.MaxLength = 25;
            this.txtFGIdMin.Name = "txtFGIdMin";
            this.txtFGIdMin.Size = new System.Drawing.Size(77, 23);
            this.txtFGIdMin.TabIndex = 30;
            this.txtFGIdMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFGIdMin_KeyPress);
            // 
            // cmbFGIdTest
            // 
            this.cmbFGIdTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbFGIdTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFGIdTest.FormattingEnabled = true;
            this.cmbFGIdTest.Location = new System.Drawing.Point(9, 36);
            this.cmbFGIdTest.Name = "cmbFGIdTest";
            this.cmbFGIdTest.Size = new System.Drawing.Size(399, 24);
            this.cmbFGIdTest.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 16);
            this.label16.TabIndex = 33;
            this.label16.Text = "Select Test";
            // 
            // tabPageFGCon
            // 
            this.tabPageFGCon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.tabPageFGCon.Controls.Add(this.panel3);
            this.tabPageFGCon.Location = new System.Drawing.Point(4, 25);
            this.tabPageFGCon.Name = "tabPageFGCon";
            this.tabPageFGCon.Size = new System.Drawing.Size(593, 303);
            this.tabPageFGCon.TabIndex = 3;
            this.tabPageFGCon.Text = "Control";
            this.tabPageFGCon.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtCMethodName);
            this.panel3.Controls.Add(this.btnFGConReset);
            this.panel3.Controls.Add(this.btnFGConDelete);
            this.panel3.Controls.Add(this.btnFGConAdd);
            this.panel3.Controls.Add(this.dgFGCon);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.txtFGConMax);
            this.panel3.Controls.Add(this.txtFGConMin);
            this.panel3.Controls.Add(this.cmbFGConTest);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(593, 303);
            this.panel3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 42;
            this.label4.Text = "Method Name :";
            this.label4.Visible = false;
            // 
            // txtCMethodName
            // 
            this.txtCMethodName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCMethodName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCMethodName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCMethodName.Location = new System.Drawing.Point(134, 76);
            this.txtCMethodName.MaxLength = 25;
            this.txtCMethodName.Name = "txtCMethodName";
            this.txtCMethodName.Size = new System.Drawing.Size(274, 23);
            this.txtCMethodName.TabIndex = 41;
            this.txtCMethodName.Visible = false;
            // 
            // btnFGConReset
            // 
            this.btnFGConReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnFGConReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFGConReset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFGConReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFGConReset.Location = new System.Drawing.Point(174, 117);
            this.btnFGConReset.Name = "btnFGConReset";
            this.btnFGConReset.Size = new System.Drawing.Size(70, 26);
            this.btnFGConReset.TabIndex = 31;
            this.btnFGConReset.Text = "Reset ";
            this.btnFGConReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFGConReset.UseVisualStyleBackColor = false;
            this.btnFGConReset.Click += new System.EventHandler(this.btnFGConReset_Click);
            // 
            // btnFGConDelete
            // 
            this.btnFGConDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnFGConDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFGConDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFGConDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFGConDelete.Location = new System.Drawing.Point(263, 117);
            this.btnFGConDelete.Name = "btnFGConDelete";
            this.btnFGConDelete.Size = new System.Drawing.Size(70, 26);
            this.btnFGConDelete.TabIndex = 30;
            this.btnFGConDelete.Text = "Delete";
            this.btnFGConDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFGConDelete.UseVisualStyleBackColor = false;
            this.btnFGConDelete.Click += new System.EventHandler(this.btnFGConDelete_Click);
            // 
            // btnFGConAdd
            // 
            this.btnFGConAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnFGConAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFGConAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFGConAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFGConAdd.Location = new System.Drawing.Point(352, 117);
            this.btnFGConAdd.Name = "btnFGConAdd";
            this.btnFGConAdd.Size = new System.Drawing.Size(70, 26);
            this.btnFGConAdd.TabIndex = 29;
            this.btnFGConAdd.Text = "Add ";
            this.btnFGConAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFGConAdd.UseVisualStyleBackColor = false;
            this.btnFGConAdd.Click += new System.EventHandler(this.btnFGConAdd_Click);
            // 
            // dgFGCon
            // 
            this.dgFGCon.AllowUserToAddRows = false;
            this.dgFGCon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgFGCon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgFGCon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgFGCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFGCon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FGConTestNo,
            this.FGConTest,
            this.MethodCName,
            this.FGConMin,
            this.FGConMax});
            this.dgFGCon.Location = new System.Drawing.Point(9, 162);
            this.dgFGCon.MultiSelect = false;
            this.dgFGCon.Name = "dgFGCon";
            this.dgFGCon.Size = new System.Drawing.Size(574, 129);
            this.dgFGCon.TabIndex = 26;
            this.dgFGCon.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFGCon_RowEnter);
            // 
            // FGConTestNo
            // 
            this.FGConTestNo.HeaderText = "TestNo";
            this.FGConTestNo.Name = "FGConTestNo";
            this.FGConTestNo.Visible = false;
            this.FGConTestNo.Width = 5;
            // 
            // FGConTest
            // 
            this.FGConTest.HeaderText = "Control Test";
            this.FGConTest.Name = "FGConTest";
            this.FGConTest.ReadOnly = true;
            this.FGConTest.Width = 200;
            // 
            // MethodCName
            // 
            this.MethodCName.HeaderText = "Method Name";
            this.MethodCName.Name = "MethodCName";
            this.MethodCName.Visible = false;
            this.MethodCName.Width = 150;
            // 
            // FGConMin
            // 
            this.FGConMin.HeaderText = "Min";
            this.FGConMin.Name = "FGConMin";
            this.FGConMin.ReadOnly = true;
            this.FGConMin.Width = 90;
            // 
            // FGConMax
            // 
            this.FGConMax.HeaderText = "Max";
            this.FGConMax.Name = "FGConMax";
            this.FGConMax.ReadOnly = true;
            this.FGConMax.Width = 90;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(530, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 16);
            this.label17.TabIndex = 25;
            this.label17.Text = "Max";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(445, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 16);
            this.label18.TabIndex = 24;
            this.label18.Text = "Min";
            // 
            // txtFGConMax
            // 
            this.txtFGConMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFGConMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFGConMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFGConMax.Location = new System.Drawing.Point(506, 38);
            this.txtFGConMax.MaxLength = 25;
            this.txtFGConMax.Name = "txtFGConMax";
            this.txtFGConMax.Size = new System.Drawing.Size(77, 23);
            this.txtFGConMax.TabIndex = 2;
            this.txtFGConMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFGConMax_KeyPress);
            // 
            // txtFGConMin
            // 
            this.txtFGConMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFGConMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFGConMin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFGConMin.Location = new System.Drawing.Point(423, 38);
            this.txtFGConMin.MaxLength = 25;
            this.txtFGConMin.Name = "txtFGConMin";
            this.txtFGConMin.Size = new System.Drawing.Size(77, 23);
            this.txtFGConMin.TabIndex = 1;
            this.txtFGConMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFGConMin_KeyPress);
            // 
            // cmbFGConTest
            // 
            this.cmbFGConTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbFGConTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFGConTest.FormattingEnabled = true;
            this.cmbFGConTest.Location = new System.Drawing.Point(9, 36);
            this.cmbFGConTest.Name = "cmbFGConTest";
            this.cmbFGConTest.Size = new System.Drawing.Size(399, 24);
            this.cmbFGConTest.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(9, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 16);
            this.label19.TabIndex = 20;
            this.label19.Text = "Select Test";
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(846, 552);
            this.panelOuter.TabIndex = 9;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(844, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(844, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(244, 27);
            this.toolStripLabel1.Text = "FG Physico-Chemical Test Method Master";
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
            this.panelBottom.Size = new System.Drawing.Size(844, 517);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.tabControlOuter);
            this.panelFill.Controls.Add(this.List);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(844, 517);
            this.panelFill.TabIndex = 43;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(11, 10);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 14;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(11, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(207, 23);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // FrmFGPhyCheTestMethodMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(846, 552);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmFGPhyCheTestMethodMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FG Physico-Chemical Test Method Master";
            this.Load += new System.EventHandler(this.FrmFGPhyCheTestMethodMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxSaveAs.ResumeLayout(false);
            this.tabControlOuter.ResumeLayout(false);
            this.tabPageFGId.ResumeLayout(false);
            this.tabPageFGId.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFGId)).EndInit();
            this.tabPageFGCon.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFGCon)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbFormulaNo;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.TabControl tabControlOuter;
        private System.Windows.Forms.TabPage tabPageFGId;
        private System.Windows.Forms.Button btnFGIdReset;
        private System.Windows.Forms.Button btnFGIdDelete;
        private System.Windows.Forms.DataGridView dgFGId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnFGIdAdd;
        private System.Windows.Forms.TextBox txtFGIdMax;
        private System.Windows.Forms.TextBox txtFGIdMin;
        private System.Windows.Forms.ComboBox cmbFGIdTest;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tabPageFGCon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnFGConReset;
        private System.Windows.Forms.Button btnFGConDelete;
        private System.Windows.Forms.Button btnFGConAdd;
        private System.Windows.Forms.DataGridView dgFGCon;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtFGConMax;
        private System.Windows.Forms.TextBox txtFGConMin;
        private System.Windows.Forms.ComboBox cmbFGConTest;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSaveAsNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBoxSaveAs;
        private System.Windows.Forms.ComboBox cmbFormulaNoSaveAs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtMethodName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCMethodName;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGIdTestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGIdTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn MethodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGIdMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGIdMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGConTestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGConTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn MethodCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGConMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGConMax;
    }
}