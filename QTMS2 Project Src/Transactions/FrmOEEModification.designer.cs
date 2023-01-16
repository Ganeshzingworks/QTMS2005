namespace QTMS.Transactions
{
    partial class FrmOEEModification
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
            frmOEEModification_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOEEModification));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.groupBox_Operator = new System.Windows.Forms.GroupBox();
            this.linkLblActivityGraph = new System.Windows.Forms.LinkLabel();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label_Comment = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.chkOverlap = new System.Windows.Forms.CheckBox();
            this.label_Operator = new System.Windows.Forms.Label();
            this.DtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.DtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.cmbOperator = new System.Windows.Forms.ComboBox();
            this.label_EndTime = new System.Windows.Forms.Label();
            this.cmbActivity = new System.Windows.Forms.ComboBox();
            this.label_StartTime = new System.Windows.Forms.Label();
            this.label_SelectActivity = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RdoClose = new System.Windows.Forms.RadioButton();
            this.RdoOpen = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnProtocol = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBox_ActivityFollowUp = new System.Windows.Forms.GroupBox();
            this.groupBox_ActivityDetails = new System.Windows.Forms.GroupBox();
            this.DgActivity = new System.Windows.Forms.DataGridView();
            this.MAID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Shift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activity = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupbox_Details = new System.Windows.Forms.GroupBox();
            this.txtTMT = new System.Windows.Forms.TextBox();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.txtTechFamily = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVessel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_VesselDesc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDetails = new System.Windows.Forms.ComboBox();
            this.DtpStartedOn = new System.Windows.Forms.DateTimePicker();
            this.label_mfgDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.groupBox_Operator.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox_ActivityDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgActivity)).BeginInit();
            this.groupbox_Details.SuspendLayout();
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
            this.panelOuter.Size = new System.Drawing.Size(941, 682);
            this.panelOuter.TabIndex = 46;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(939, 30);
            this.panelTop.TabIndex = 43;
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
            this.toolStrip1.Size = new System.Drawing.Size(939, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(103, 27);
            this.toolStripLabel1.Text = "OEE Modification";
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonClose.BackColor = System.Drawing.Color.White;
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClose.Image")));
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
            this.panelBottom.Size = new System.Drawing.Size(939, 647);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.groupBox_Operator);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Controls.Add(this.groupBox8);
            this.panelFill.Controls.Add(this.groupBox_ActivityFollowUp);
            this.panelFill.Controls.Add(this.groupBox_ActivityDetails);
            this.panelFill.Controls.Add(this.groupbox_Details);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(939, 647);
            this.panelFill.TabIndex = 46;
            // 
            // groupBox_Operator
            // 
            this.groupBox_Operator.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_Operator.Controls.Add(this.linkLblActivityGraph);
            this.groupBox_Operator.Controls.Add(this.txtComment);
            this.groupBox_Operator.Controls.Add(this.label4);
            this.groupBox_Operator.Controls.Add(this.label8);
            this.groupBox_Operator.Controls.Add(this.label_Comment);
            this.groupBox_Operator.Controls.Add(this.BtnAdd);
            this.groupBox_Operator.Controls.Add(this.cmbShift);
            this.groupBox_Operator.Controls.Add(this.chkOverlap);
            this.groupBox_Operator.Controls.Add(this.label_Operator);
            this.groupBox_Operator.Controls.Add(this.DtpEndTime);
            this.groupBox_Operator.Controls.Add(this.DtpStartTime);
            this.groupBox_Operator.Controls.Add(this.cmbOperator);
            this.groupBox_Operator.Controls.Add(this.label_EndTime);
            this.groupBox_Operator.Controls.Add(this.cmbActivity);
            this.groupBox_Operator.Controls.Add(this.label_StartTime);
            this.groupBox_Operator.Controls.Add(this.label_SelectActivity);
            this.groupBox_Operator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox_Operator.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Operator.Location = new System.Drawing.Point(6, 101);
            this.groupBox_Operator.Name = "groupBox_Operator";
            this.groupBox_Operator.Size = new System.Drawing.Size(930, 122);
            this.groupBox_Operator.TabIndex = 9;
            this.groupBox_Operator.TabStop = false;
            this.groupBox_Operator.Text = "Shift Details";
            // 
            // linkLblActivityGraph
            // 
            this.linkLblActivityGraph.AutoSize = true;
            this.linkLblActivityGraph.Location = new System.Drawing.Point(354, 95);
            this.linkLblActivityGraph.Name = "linkLblActivityGraph";
            this.linkLblActivityGraph.Size = new System.Drawing.Size(119, 13);
            this.linkLblActivityGraph.TabIndex = 56;
            this.linkLblActivityGraph.TabStop = true;
            this.linkLblActivityGraph.Text = "View Activity Graph";
            this.linkLblActivityGraph.Visible = false;
            this.linkLblActivityGraph.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblActivityGraph_LinkClicked);
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(97, 86);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(184, 23);
            this.txtComment.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(310, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "Shift";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(78, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Overlap With Last Activity";
            // 
            // label_Comment
            // 
            this.label_Comment.AutoSize = true;
            this.label_Comment.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Comment.Location = new System.Drawing.Point(26, 89);
            this.label_Comment.Name = "label_Comment";
            this.label_Comment.Size = new System.Drawing.Size(69, 16);
            this.label_Comment.TabIndex = 11;
            this.label_Comment.Text = "Comment";
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnAdd.Location = new System.Drawing.Point(751, 85);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(130, 25);
            this.BtnAdd.TabIndex = 17;
            this.BtnAdd.Text = "&Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbShift
            // 
            this.cmbShift.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbShift.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Items.AddRange(new object[] {
            "--Select--",
            "Shift1",
            "Shift2",
            "Shift3"});
            this.cmbShift.Location = new System.Drawing.Point(353, 20);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(184, 24);
            this.cmbShift.TabIndex = 50;
            // 
            // chkOverlap
            // 
            this.chkOverlap.AutoSize = true;
            this.chkOverlap.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOverlap.Location = new System.Drawing.Point(266, 56);
            this.chkOverlap.Name = "chkOverlap";
            this.chkOverlap.Size = new System.Drawing.Size(15, 14);
            this.chkOverlap.TabIndex = 0;
            this.chkOverlap.UseVisualStyleBackColor = true;
            this.chkOverlap.CheckedChanged += new System.EventHandler(this.chkOverlap_CheckedChanged);
            // 
            // label_Operator
            // 
            this.label_Operator.AutoSize = true;
            this.label_Operator.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Operator.Location = new System.Drawing.Point(27, 24);
            this.label_Operator.Name = "label_Operator";
            this.label_Operator.Size = new System.Drawing.Size(66, 16);
            this.label_Operator.TabIndex = 47;
            this.label_Operator.Text = "Opeartor";
            // 
            // DtpEndTime
            // 
            this.DtpEndTime.Checked = false;
            this.DtpEndTime.CustomFormat = "dd-MMM-yyyy HH:mm:ss ";
            this.DtpEndTime.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpEndTime.Location = new System.Drawing.Point(629, 52);
            this.DtpEndTime.Name = "DtpEndTime";
            this.DtpEndTime.ShowUpDown = true;
            this.DtpEndTime.Size = new System.Drawing.Size(183, 23);
            this.DtpEndTime.TabIndex = 9;
            this.DtpEndTime.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // DtpStartTime
            // 
            this.DtpStartTime.Checked = false;
            this.DtpStartTime.CustomFormat = "dd-MMM-yyyy HH:mm:ss";
            this.DtpStartTime.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpStartTime.Location = new System.Drawing.Point(353, 52);
            this.DtpStartTime.Name = "DtpStartTime";
            this.DtpStartTime.ShowUpDown = true;
            this.DtpStartTime.Size = new System.Drawing.Size(184, 23);
            this.DtpStartTime.TabIndex = 8;
            this.DtpStartTime.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // cmbOperator
            // 
            this.cmbOperator.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbOperator.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOperator.FormattingEnabled = true;
            this.cmbOperator.Location = new System.Drawing.Point(97, 20);
            this.cmbOperator.Name = "cmbOperator";
            this.cmbOperator.Size = new System.Drawing.Size(184, 24);
            this.cmbOperator.TabIndex = 46;
            // 
            // label_EndTime
            // 
            this.label_EndTime.AutoSize = true;
            this.label_EndTime.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EndTime.Location = new System.Drawing.Point(593, 55);
            this.label_EndTime.Name = "label_EndTime";
            this.label_EndTime.Size = new System.Drawing.Size(32, 16);
            this.label_EndTime.TabIndex = 6;
            this.label_EndTime.Text = "End";
            // 
            // cmbActivity
            // 
            this.cmbActivity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbActivity.FormattingEnabled = true;
            this.cmbActivity.Location = new System.Drawing.Point(629, 20);
            this.cmbActivity.Name = "cmbActivity";
            this.cmbActivity.Size = new System.Drawing.Size(252, 24);
            this.cmbActivity.TabIndex = 4;
            // 
            // label_StartTime
            // 
            this.label_StartTime.AutoSize = true;
            this.label_StartTime.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_StartTime.Location = new System.Drawing.Point(307, 55);
            this.label_StartTime.Name = "label_StartTime";
            this.label_StartTime.Size = new System.Drawing.Size(42, 16);
            this.label_StartTime.TabIndex = 5;
            this.label_StartTime.Text = "Start";
            // 
            // label_SelectActivity
            // 
            this.label_SelectActivity.AutoSize = true;
            this.label_SelectActivity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SelectActivity.Location = new System.Drawing.Point(566, 24);
            this.label_SelectActivity.Name = "label_SelectActivity";
            this.label_SelectActivity.Size = new System.Drawing.Size(59, 16);
            this.label_SelectActivity.TabIndex = 3;
            this.label_SelectActivity.Text = "Activity";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.RdoClose);
            this.groupBox1.Controls.Add(this.RdoOpen);
            this.groupBox1.Location = new System.Drawing.Point(15, 508);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(902, 37);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // RdoClose
            // 
            this.RdoClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RdoClose.AutoSize = true;
            this.RdoClose.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoClose.Location = new System.Drawing.Point(476, 12);
            this.RdoClose.Name = "RdoClose";
            this.RdoClose.Size = new System.Drawing.Size(61, 20);
            this.RdoClose.TabIndex = 61;
            this.RdoClose.TabStop = true;
            this.RdoClose.Text = "Close";
            this.RdoClose.UseVisualStyleBackColor = true;
            // 
            // RdoOpen
            // 
            this.RdoOpen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RdoOpen.AutoSize = true;
            this.RdoOpen.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdoOpen.Location = new System.Drawing.Point(354, 11);
            this.RdoOpen.Name = "RdoOpen";
            this.RdoOpen.Size = new System.Drawing.Size(60, 20);
            this.RdoOpen.TabIndex = 60;
            this.RdoOpen.TabStop = true;
            this.RdoOpen.Text = "Open";
            this.RdoOpen.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox8.Controls.Add(this.btnProtocol);
            this.groupBox8.Controls.Add(this.BtnReset);
            this.groupBox8.Controls.Add(this.BtnExit);
            this.groupBox8.Controls.Add(this.BtnSave);
            this.groupBox8.Location = new System.Drawing.Point(15, 549);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(902, 48);
            this.groupBox8.TabIndex = 10;
            this.groupBox8.TabStop = false;
            // 
            // btnProtocol
            // 
            this.btnProtocol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnProtocol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProtocol.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProtocol.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnProtocol.Location = new System.Drawing.Point(481, 10);
            this.btnProtocol.Name = "btnProtocol";
            this.btnProtocol.Size = new System.Drawing.Size(114, 28);
            this.btnProtocol.TabIndex = 3;
            this.btnProtocol.Text = "&Protocol";
            this.btnProtocol.UseVisualStyleBackColor = false;
            this.btnProtocol.Click += new System.EventHandler(this.btnProtocol_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(133, 10);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(114, 28);
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
            this.BtnExit.Location = new System.Drawing.Point(655, 10);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(114, 28);
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
            this.BtnSave.Location = new System.Drawing.Point(307, 10);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(114, 28);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBox_ActivityFollowUp
            // 
            this.groupBox_ActivityFollowUp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_ActivityFollowUp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ActivityFollowUp.Location = new System.Drawing.Point(15, 601);
            this.groupBox_ActivityFollowUp.Name = "groupBox_ActivityFollowUp";
            this.groupBox_ActivityFollowUp.Size = new System.Drawing.Size(902, 36);
            this.groupBox_ActivityFollowUp.TabIndex = 8;
            this.groupBox_ActivityFollowUp.TabStop = false;
            this.groupBox_ActivityFollowUp.Text = "Activity Follow Up";
            this.groupBox_ActivityFollowUp.Visible = false;
            // 
            // groupBox_ActivityDetails
            // 
            this.groupBox_ActivityDetails.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox_ActivityDetails.Controls.Add(this.btnDeleteAll);
            this.groupBox_ActivityDetails.Controls.Add(this.DgActivity);
            this.groupBox_ActivityDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox_ActivityDetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ActivityDetails.Location = new System.Drawing.Point(7, 229);
            this.groupBox_ActivityDetails.Name = "groupBox_ActivityDetails";
            this.groupBox_ActivityDetails.Size = new System.Drawing.Size(929, 273);
            this.groupBox_ActivityDetails.TabIndex = 6;
            this.groupBox_ActivityDetails.TabStop = false;
            this.groupBox_ActivityDetails.Text = "Activity Details";
            // 
            // DgActivity
            // 
            this.DgActivity.AllowUserToAddRows = false;
            this.DgActivity.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.DgActivity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgActivity.ColumnHeadersHeight = 30;
            this.DgActivity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MAID,
            this.FMID,
            this.OSID,
            this.Operator,
            this.Shift,
            this.Activity,
            this.StartTime,
            this.EndTime,
            this.Comment});
            this.DgActivity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DgActivity.Location = new System.Drawing.Point(3, 59);
            this.DgActivity.MultiSelect = false;
            this.DgActivity.Name = "DgActivity";
            this.DgActivity.ReadOnly = true;
            this.DgActivity.RowHeadersWidth = 30;
            this.DgActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgActivity.Size = new System.Drawing.Size(923, 211);
            this.DgActivity.TabIndex = 12;
            // 
            // MAID
            // 
            this.MAID.DataPropertyName = "MAID";
            this.MAID.HeaderText = "MAID";
            this.MAID.Name = "MAID";
            this.MAID.ReadOnly = true;
            this.MAID.Visible = false;
            // 
            // FMID
            // 
            this.FMID.DataPropertyName = "FMID";
            this.FMID.HeaderText = "FMID";
            this.FMID.Name = "FMID";
            this.FMID.ReadOnly = true;
            this.FMID.Visible = false;
            // 
            // OSID
            // 
            this.OSID.DataPropertyName = "OSID";
            this.OSID.HeaderText = "OSID";
            this.OSID.Name = "OSID";
            this.OSID.ReadOnly = true;
            this.OSID.Visible = false;
            // 
            // Operator
            // 
            this.Operator.HeaderText = "Operator";
            this.Operator.Name = "Operator";
            this.Operator.ReadOnly = true;
            // 
            // Shift
            // 
            this.Shift.HeaderText = "Shift";
            this.Shift.Name = "Shift";
            this.Shift.ReadOnly = true;
            this.Shift.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Activity
            // 
            dataGridViewCellStyle7.Format = "G";
            dataGridViewCellStyle7.NullValue = null;
            this.Activity.DefaultCellStyle = dataGridViewCellStyle7;
            this.Activity.HeaderText = "Activity";
            this.Activity.Name = "Activity";
            this.Activity.ReadOnly = true;
            this.Activity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Activity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Activity.Width = 200;
            // 
            // StartTime
            // 
            this.StartTime.DataPropertyName = "StartTime";
            dataGridViewCellStyle8.NullValue = null;
            this.StartTime.DefaultCellStyle = dataGridViewCellStyle8;
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.MinimumWidth = 20;
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StartTime.Width = 150;
            // 
            // EndTime
            // 
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "End Time";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EndTime.Width = 150;
            // 
            // Comment
            // 
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            this.Comment.Width = 300;
            // 
            // groupbox_Details
            // 
            this.groupbox_Details.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupbox_Details.Controls.Add(this.txtTMT);
            this.groupbox_Details.Controls.Add(this.txtBatchSize);
            this.groupbox_Details.Controls.Add(this.txtTechFamily);
            this.groupbox_Details.Controls.Add(this.label7);
            this.groupbox_Details.Controls.Add(this.txtVessel);
            this.groupbox_Details.Controls.Add(this.label6);
            this.groupbox_Details.Controls.Add(this.txtDesc);
            this.groupbox_Details.Controls.Add(this.label5);
            this.groupbox_Details.Controls.Add(this.label3);
            this.groupbox_Details.Controls.Add(this.label_VesselDesc);
            this.groupbox_Details.Controls.Add(this.label2);
            this.groupbox_Details.Controls.Add(this.cmbDetails);
            this.groupbox_Details.Controls.Add(this.DtpStartedOn);
            this.groupbox_Details.Controls.Add(this.label_mfgDate);
            this.groupbox_Details.Controls.Add(this.label1);
            this.groupbox_Details.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupbox_Details.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbox_Details.Location = new System.Drawing.Point(6, 9);
            this.groupbox_Details.Name = "groupbox_Details";
            this.groupbox_Details.Size = new System.Drawing.Size(930, 88);
            this.groupbox_Details.TabIndex = 1;
            this.groupbox_Details.TabStop = false;
            // 
            // txtTMT
            // 
            this.txtTMT.BackColor = System.Drawing.SystemColors.Control;
            this.txtTMT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTMT.Enabled = false;
            this.txtTMT.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTMT.Location = new System.Drawing.Point(837, 59);
            this.txtTMT.Name = "txtTMT";
            this.txtTMT.ReadOnly = true;
            this.txtTMT.Size = new System.Drawing.Size(79, 23);
            this.txtTMT.TabIndex = 58;
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.BackColor = System.Drawing.SystemColors.Control;
            this.txtBatchSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchSize.Enabled = false;
            this.txtBatchSize.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchSize.Location = new System.Drawing.Point(629, 59);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.ReadOnly = true;
            this.txtBatchSize.Size = new System.Drawing.Size(124, 23);
            this.txtBatchSize.TabIndex = 58;
            // 
            // txtTechFamily
            // 
            this.txtTechFamily.BackColor = System.Drawing.SystemColors.Control;
            this.txtTechFamily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTechFamily.Enabled = false;
            this.txtTechFamily.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTechFamily.Location = new System.Drawing.Point(357, 59);
            this.txtTechFamily.Name = "txtTechFamily";
            this.txtTechFamily.ReadOnly = true;
            this.txtTechFamily.Size = new System.Drawing.Size(177, 23);
            this.txtTechFamily.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(797, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 16);
            this.label7.TabIndex = 53;
            this.label7.Text = "TMT";
            // 
            // txtVessel
            // 
            this.txtVessel.BackColor = System.Drawing.SystemColors.Control;
            this.txtVessel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVessel.Enabled = false;
            this.txtVessel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVessel.Location = new System.Drawing.Point(59, 59);
            this.txtVessel.Name = "txtVessel";
            this.txtVessel.ReadOnly = true;
            this.txtVessel.Size = new System.Drawing.Size(206, 23);
            this.txtVessel.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(548, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 16);
            this.label6.TabIndex = 53;
            this.label6.Text = "Batch Size";
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.SystemColors.Control;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Enabled = false;
            this.txtDesc.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(399, 30);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(313, 23);
            this.txtDesc.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(272, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 53;
            this.label5.Text = "TechFamily";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 55;
            this.label3.Text = "Description";
            // 
            // label_VesselDesc
            // 
            this.label_VesselDesc.AutoSize = true;
            this.label_VesselDesc.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_VesselDesc.Location = new System.Drawing.Point(6, 62);
            this.label_VesselDesc.Name = "label_VesselDesc";
            this.label_VesselDesc.Size = new System.Drawing.Size(50, 16);
            this.label_VesselDesc.TabIndex = 53;
            this.label_VesselDesc.Text = "Vessel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "( FormulaNo - MfgWo )";
            // 
            // cmbDetails
            // 
            this.cmbDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbDetails.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDetails.FormattingEnabled = true;
            this.cmbDetails.Location = new System.Drawing.Point(59, 29);
            this.cmbDetails.Name = "cmbDetails";
            this.cmbDetails.Size = new System.Drawing.Size(252, 24);
            this.cmbDetails.TabIndex = 0;
            this.cmbDetails.SelectionChangeCommitted += new System.EventHandler(this.cmbDetails_SelectionChangeCommitted);
            // 
            // DtpStartedOn
            // 
            this.DtpStartedOn.CustomFormat = "dd-MMM-yyyy";
            this.DtpStartedOn.Enabled = false;
            this.DtpStartedOn.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpStartedOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpStartedOn.Location = new System.Drawing.Point(802, 30);
            this.DtpStartedOn.Name = "DtpStartedOn";
            this.DtpStartedOn.Size = new System.Drawing.Size(114, 23);
            this.DtpStartedOn.TabIndex = 1;
            this.DtpStartedOn.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // label_mfgDate
            // 
            this.label_mfgDate.AutoSize = true;
            this.label_mfgDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mfgDate.Location = new System.Drawing.Point(718, 33);
            this.label_mfgDate.Name = "label_mfgDate";
            this.label_mfgDate.Size = new System.Drawing.Size(81, 16);
            this.label_mfgDate.TabIndex = 14;
            this.label_mfgDate.Text = "Started On";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Details";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Activity";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Start Time";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "End Time";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 300;
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAll.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAll.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDeleteAll.Location = new System.Drawing.Point(33, 21);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(114, 28);
            this.btnDeleteAll.TabIndex = 13;
            this.btnDeleteAll.Text = "&Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = false;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // FrmOEEModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(940, 680);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(941, 682);
            this.Controls.Add(this.panelOuter);
            this.Name = "FrmOEEModification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OEE Modification";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmOEETransaction_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.groupBox_Operator.ResumeLayout(false);
            this.groupBox_Operator.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox_ActivityDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgActivity)).EndInit();
            this.groupbox_Details.ResumeLayout(false);
            this.groupbox_Details.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.GroupBox groupBox_ActivityDetails;
        private System.Windows.Forms.GroupBox groupbox_Details;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDetails;
        private System.Windows.Forms.DateTimePicker DtpStartedOn;
        private System.Windows.Forms.Label label_mfgDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_EndTime;
        private System.Windows.Forms.Label label_StartTime;
        private System.Windows.Forms.ComboBox cmbActivity;
        private System.Windows.Forms.Label label_SelectActivity;
        private System.Windows.Forms.DateTimePicker DtpEndTime;
        private System.Windows.Forms.DateTimePicker DtpStartTime;
        private System.Windows.Forms.ComboBox cmbOperator;
        private System.Windows.Forms.Label label_Operator;
        private System.Windows.Forms.GroupBox groupBox_ActivityFollowUp;
        private System.Windows.Forms.CheckBox chkOverlap;
        private System.Windows.Forms.DataGridView DgActivity;
        private System.Windows.Forms.Label label_Comment;
        private System.Windows.Forms.Label label_VesselDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox groupBox_Operator;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RdoClose;
        private System.Windows.Forms.RadioButton RdoOpen;
        private System.Windows.Forms.TextBox txtVessel;
        private System.Windows.Forms.Button btnProtocol;
        private System.Windows.Forms.LinkLabel linkLblActivityGraph;
        private System.Windows.Forms.TextBox txtTMT;
        private System.Windows.Forms.TextBox txtBatchSize;
        private System.Windows.Forms.TextBox txtTechFamily;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OSID;
        private System.Windows.Forms.DataGridViewComboBoxColumn Operator;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shift;
        private System.Windows.Forms.DataGridViewComboBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.Button btnDeleteAll;
    }
}