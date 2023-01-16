namespace QTMS.Transactions
{
    partial class FrmWA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWA));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelbottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgMettler = new System.Windows.Forms.DataGridView();
            this.MettlerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TareWeightTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TareWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MettlerTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AVERAGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STDDEV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DISPERSION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EntryType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAvg = new System.Windows.Forms.TextBox();
            this.lblAvg = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RdoHold = new System.Windows.Forms.RadioButton();
            this.cmbInspectedBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RdoRejected = new System.Windows.Forms.RadioButton();
            this.RdoAccepted = new System.Windows.Forms.RadioButton();
            this.groupBoxReadings = new System.Windows.Forms.GroupBox();
            this.dgReadings = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RdbMettler = new System.Windows.Forms.RadioButton();
            this.RdbWeighing = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelbottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMettler)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxReadings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReadings)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelOuter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1122, 487);
            this.panel1.TabIndex = 0;
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelbottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(1122, 487);
            this.panelOuter.TabIndex = 5;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1120, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(1120, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(54, 27);
            this.toolStripLabel1.Text = "Analysis";
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
            // panelbottom
            // 
            this.panelbottom.Controls.Add(this.panelFill);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelbottom.Location = new System.Drawing.Point(0, 32);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(1120, 453);
            this.panelbottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.groupBox4);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Controls.Add(this.groupBoxReadings);
            this.panelFill.Controls.Add(this.groupBox3);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(1120, 453);
            this.panelFill.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgMettler);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(525, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(586, 441);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // dgMettler
            // 
            this.dgMettler.AllowUserToAddRows = false;
            this.dgMettler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgMettler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgMettler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgMettler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMettler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MettlerID,
            this.TareWeightTime,
            this.TareWeight,
            this.MettlerTime,
            this.AVERAGE,
            this.STDDEV,
            this.M_MAX,
            this.M_MIN,
            this.DISPERSION,
            this.GAP,
            this.EntryType});
            this.dgMettler.Location = new System.Drawing.Point(6, 14);
            this.dgMettler.MultiSelect = false;
            this.dgMettler.Name = "dgMettler";
            this.dgMettler.RowHeadersVisible = false;
            this.dgMettler.Size = new System.Drawing.Size(574, 423);
            this.dgMettler.TabIndex = 57;
            this.dgMettler.TabStop = false;
            // 
            // MettlerID
            // 
            this.MettlerID.DataPropertyName = "MettlerID";
            this.MettlerID.HeaderText = "MettlerID";
            this.MettlerID.Name = "MettlerID";
            this.MettlerID.ReadOnly = true;
            this.MettlerID.Visible = false;
            // 
            // TareWeightTime
            // 
            this.TareWeightTime.DataPropertyName = "TareWeightTime";
            this.TareWeightTime.HeaderText = "TareWeightTime";
            this.TareWeightTime.Name = "TareWeightTime";
            this.TareWeightTime.ReadOnly = true;
            // 
            // TareWeight
            // 
            this.TareWeight.DataPropertyName = "TareWeight";
            this.TareWeight.HeaderText = "TareWeight";
            this.TareWeight.Name = "TareWeight";
            this.TareWeight.ReadOnly = true;
            // 
            // MettlerTime
            // 
            this.MettlerTime.DataPropertyName = "MettlerTime";
            this.MettlerTime.HeaderText = "MettlerTime";
            this.MettlerTime.Name = "MettlerTime";
            this.MettlerTime.ReadOnly = true;
            // 
            // AVERAGE
            // 
            this.AVERAGE.DataPropertyName = "AVERAGE";
            this.AVERAGE.HeaderText = "AVERAGE";
            this.AVERAGE.Name = "AVERAGE";
            this.AVERAGE.ReadOnly = true;
            // 
            // STDDEV
            // 
            this.STDDEV.DataPropertyName = "STDDEV";
            this.STDDEV.HeaderText = "STDDEV";
            this.STDDEV.Name = "STDDEV";
            this.STDDEV.ReadOnly = true;
            // 
            // M_MAX
            // 
            this.M_MAX.DataPropertyName = "M_MAX";
            this.M_MAX.HeaderText = "MAX";
            this.M_MAX.Name = "M_MAX";
            this.M_MAX.ReadOnly = true;
            // 
            // M_MIN
            // 
            this.M_MIN.DataPropertyName = "M_MIN";
            this.M_MIN.HeaderText = "MIN";
            this.M_MIN.Name = "M_MIN";
            this.M_MIN.ReadOnly = true;
            // 
            // DISPERSION
            // 
            this.DISPERSION.DataPropertyName = "DISPERSION";
            this.DISPERSION.HeaderText = "DISPERSION";
            this.DISPERSION.Name = "DISPERSION";
            this.DISPERSION.ReadOnly = true;
            // 
            // GAP
            // 
            this.GAP.DataPropertyName = "GAP";
            this.GAP.HeaderText = "GAP";
            this.GAP.Name = "GAP";
            this.GAP.ReadOnly = true;
            // 
            // EntryType
            // 
            this.EntryType.DataPropertyName = "EntryType";
            this.EntryType.HeaderText = "EntryType";
            this.EntryType.Name = "EntryType";
            this.EntryType.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAvg);
            this.groupBox2.Controls.Add(this.lblAvg);
            this.groupBox2.Controls.Add(this.txtMax);
            this.groupBox2.Controls.Add(this.lblMax);
            this.groupBox2.Controls.Add(this.txtMin);
            this.groupBox2.Controls.Add(this.lblMin);
            this.groupBox2.Location = new System.Drawing.Point(14, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 48);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // txtAvg
            // 
            this.txtAvg.BackColor = System.Drawing.Color.LightGray;
            this.txtAvg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAvg.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvg.Location = new System.Drawing.Point(228, 13);
            this.txtAvg.MaxLength = 50;
            this.txtAvg.Name = "txtAvg";
            this.txtAvg.ReadOnly = true;
            this.txtAvg.Size = new System.Drawing.Size(79, 23);
            this.txtAvg.TabIndex = 63;
            this.txtAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAvg
            // 
            this.lblAvg.AutoSize = true;
            this.lblAvg.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvg.Location = new System.Drawing.Point(191, 16);
            this.lblAvg.Name = "lblAvg";
            this.lblAvg.Size = new System.Drawing.Size(33, 16);
            this.lblAvg.TabIndex = 64;
            this.lblAvg.Text = "Avg";
            // 
            // txtMax
            // 
            this.txtMax.BackColor = System.Drawing.Color.LightGray;
            this.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMax.Location = new System.Drawing.Point(350, 13);
            this.txtMax.MaxLength = 50;
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(79, 23);
            this.txtMax.TabIndex = 61;
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMax.Location = new System.Drawing.Point(313, 16);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(34, 16);
            this.lblMax.TabIndex = 62;
            this.lblMax.Text = "Max";
            // 
            // txtMin
            // 
            this.txtMin.BackColor = System.Drawing.Color.LightGray;
            this.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMin.Location = new System.Drawing.Point(108, 13);
            this.txtMin.MaxLength = 50;
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(79, 23);
            this.txtMin.TabIndex = 59;
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMin.Location = new System.Drawing.Point(75, 16);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(30, 16);
            this.lblMin.TabIndex = 60;
            this.lblMin.Text = "Min";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RdoHold);
            this.groupBox1.Controls.Add(this.cmbInspectedBy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.RdoRejected);
            this.groupBox1.Controls.Add(this.RdoAccepted);
            this.groupBox1.Location = new System.Drawing.Point(14, 349);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 48);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // RdoHold
            // 
            this.RdoHold.AutoSize = true;
            this.RdoHold.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoHold.Location = new System.Drawing.Point(199, 19);
            this.RdoHold.Name = "RdoHold";
            this.RdoHold.Size = new System.Drawing.Size(54, 20);
            this.RdoHold.TabIndex = 13;
            this.RdoHold.Text = "Hold";
            this.RdoHold.UseVisualStyleBackColor = true;
            // 
            // cmbInspectedBy
            // 
            this.cmbInspectedBy.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbInspectedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInspectedBy.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInspectedBy.FormattingEnabled = true;
            this.cmbInspectedBy.Items.AddRange(new object[] {
            "--Select--"});
            this.cmbInspectedBy.Location = new System.Drawing.Point(356, 17);
            this.cmbInspectedBy.Name = "cmbInspectedBy";
            this.cmbInspectedBy.Size = new System.Drawing.Size(140, 24);
            this.cmbInspectedBy.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(256, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Inspected By";
            // 
            // RdoRejected
            // 
            this.RdoRejected.AutoSize = true;
            this.RdoRejected.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoRejected.Location = new System.Drawing.Point(109, 19);
            this.RdoRejected.Name = "RdoRejected";
            this.RdoRejected.Size = new System.Drawing.Size(84, 20);
            this.RdoRejected.TabIndex = 5;
            this.RdoRejected.Text = "Rejected";
            this.RdoRejected.UseVisualStyleBackColor = true;
            // 
            // RdoAccepted
            // 
            this.RdoAccepted.AutoSize = true;
            this.RdoAccepted.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoAccepted.Location = new System.Drawing.Point(12, 19);
            this.RdoAccepted.Name = "RdoAccepted";
            this.RdoAccepted.Size = new System.Drawing.Size(89, 20);
            this.RdoAccepted.TabIndex = 4;
            this.RdoAccepted.Text = "Accepted";
            this.RdoAccepted.UseVisualStyleBackColor = true;
            // 
            // groupBoxReadings
            // 
            this.groupBoxReadings.Controls.Add(this.RdbMettler);
            this.groupBoxReadings.Controls.Add(this.RdbWeighing);
            this.groupBoxReadings.Controls.Add(this.dgReadings);
            this.groupBoxReadings.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxReadings.Location = new System.Drawing.Point(14, 4);
            this.groupBoxReadings.Name = "groupBoxReadings";
            this.groupBoxReadings.Size = new System.Drawing.Size(505, 297);
            this.groupBoxReadings.TabIndex = 1;
            this.groupBoxReadings.TabStop = false;
            // 
            // dgReadings
            // 
            this.dgReadings.AllowUserToAddRows = false;
            this.dgReadings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgReadings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgReadings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgReadings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReadings.ColumnHeadersVisible = false;
            this.dgReadings.Location = new System.Drawing.Point(3, 50);
            this.dgReadings.MultiSelect = false;
            this.dgReadings.Name = "dgReadings";
            this.dgReadings.RowHeadersVisible = false;
            this.dgReadings.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgReadings.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgReadings.Size = new System.Drawing.Size(499, 241);
            this.dgReadings.TabIndex = 0;
            this.dgReadings.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgReadings_CellEndEdit);
            this.dgReadings.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgReadings_EditingControlShowing);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnbrowse);
            this.groupBox3.Controls.Add(this.BtnExit);
            this.groupBox3.Controls.Add(this.BtnSave);
            this.groupBox3.Location = new System.Drawing.Point(14, 397);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(505, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnbrowse
            // 
            this.btnbrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnbrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbrowse.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrowse.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnbrowse.Location = new System.Drawing.Point(48, 10);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(103, 28);
            this.btnbrowse.TabIndex = 44;
            this.btnbrowse.Text = "&Browse";
            this.btnbrowse.UseVisualStyleBackColor = false;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(336, 10);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(112, 28);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "&Close";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(191, 10);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(112, 28);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MettlerDate";
            this.dataGridViewTextBoxColumn1.HeaderText = "MettlerDate";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "MettlerTime";
            this.dataGridViewTextBoxColumn2.HeaderText = "MettlerTime";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TareWeight";
            this.dataGridViewTextBoxColumn3.HeaderText = "TareWeight";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Weight";
            this.dataGridViewTextBoxColumn4.HeaderText = "Weight";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // RdbMettler
            // 
            this.RdbMettler.AutoSize = true;
            this.RdbMettler.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbMettler.Location = new System.Drawing.Point(264, 15);
            this.RdbMettler.Name = "RdbMettler";
            this.RdbMettler.Size = new System.Drawing.Size(73, 20);
            this.RdbMettler.TabIndex = 7;
            this.RdbMettler.Text = "Mettler";
            this.RdbMettler.UseVisualStyleBackColor = true;
            this.RdbMettler.CheckedChanged += new System.EventHandler(this.RdbMettler_CheckedChanged);
            // 
            // RdbWeighing
            // 
            this.RdbWeighing.AutoSize = true;
            this.RdbWeighing.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbWeighing.Location = new System.Drawing.Point(167, 15);
            this.RdbWeighing.Name = "RdbWeighing";
            this.RdbWeighing.Size = new System.Drawing.Size(84, 20);
            this.RdbWeighing.TabIndex = 6;
            this.RdbWeighing.Text = "Weighing";
            this.RdbWeighing.UseVisualStyleBackColor = true;
            // 
            // FrmWA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1122, 487);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmWA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analysis";
            this.Load += new System.EventHandler(this.FrmWA_Load);
            this.panel1.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelbottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMettler)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxReadings.ResumeLayout(false);
            this.groupBoxReadings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReadings)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox groupBoxReadings;
        private System.Windows.Forms.DataGridView dgReadings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RdoRejected;
        private System.Windows.Forms.RadioButton RdoAccepted;
        private System.Windows.Forms.ComboBox cmbInspectedBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TextBox txtAvg;
        private System.Windows.Forms.Label lblAvg;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelbottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.RadioButton RdoHold;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgMettler;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MettlerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TareWeightTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TareWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn MettlerTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AVERAGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn STDDEV;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn M_MIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISPERSION;
        private System.Windows.Forms.DataGridViewTextBoxColumn GAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntryType;
        private System.Windows.Forms.RadioButton RdbMettler;
        private System.Windows.Forms.RadioButton RdbWeighing;
    }
}