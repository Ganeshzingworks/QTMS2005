namespace QTMS.Forms
{
    partial class FrmPreservativeMethodMaster
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
            frmPreservativeMethodMaster_Obj = null;
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
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.CmbFormulaNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPresReset = new System.Windows.Forms.Button();
            this.btnPresDelete = new System.Windows.Forms.Button();
            this.btnPresAdd = new System.Windows.Forms.Button();
            this.dgPres = new System.Windows.Forms.DataGridView();
            this.PresTestNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PresTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PresMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PresMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPresMax = new System.Windows.Forms.TextBox();
            this.txtPresMin = new System.Windows.Forms.TextBox();
            this.cmbPresTest = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
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
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPres)).BeginInit();
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
            this.List.Location = new System.Drawing.Point(16, 62);
            this.List.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(207, 338);
            this.List.TabIndex = 5;
            this.List.DoubleClick += new System.EventHandler(this.List_DoubleClick);
            this.List.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.List_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnDelete);
            this.groupBox1.Controls.Add(this.BtnReset);
            this.groupBox1.Controls.Add(this.BtnExit);
            this.groupBox1.Controls.Add(this.CmbFormulaNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(245, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(597, 101);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(252, 60);
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
            this.BtnReset.Location = new System.Drawing.Point(140, 60);
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
            this.BtnExit.Location = new System.Drawing.Point(364, 60);
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
            this.label1.Location = new System.Drawing.Point(111, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Formula No.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPresReset);
            this.groupBox3.Controls.Add(this.btnPresDelete);
            this.groupBox3.Controls.Add(this.btnPresAdd);
            this.groupBox3.Controls.Add(this.dgPres);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtPresMax);
            this.groupBox3.Controls.Add(this.txtPresMin);
            this.groupBox3.Controls.Add(this.cmbPresTest);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Location = new System.Drawing.Point(245, 119);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(597, 284);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // btnPresReset
            // 
            this.btnPresReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPresReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPresReset.Location = new System.Drawing.Point(177, 73);
            this.btnPresReset.Name = "btnPresReset";
            this.btnPresReset.Size = new System.Drawing.Size(70, 26);
            this.btnPresReset.TabIndex = 44;
            this.btnPresReset.Text = "Reset ";
            this.btnPresReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPresReset.UseVisualStyleBackColor = false;
            this.btnPresReset.Click += new System.EventHandler(this.btnPresReset_Click);
            // 
            // btnPresDelete
            // 
            this.btnPresDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPresDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresDelete.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPresDelete.Location = new System.Drawing.Point(266, 73);
            this.btnPresDelete.Name = "btnPresDelete";
            this.btnPresDelete.Size = new System.Drawing.Size(70, 26);
            this.btnPresDelete.TabIndex = 43;
            this.btnPresDelete.Text = "Delete";
            this.btnPresDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPresDelete.UseVisualStyleBackColor = false;
            this.btnPresDelete.Click += new System.EventHandler(this.btnPresDelete_Click);
            // 
            // btnPresAdd
            // 
            this.btnPresAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPresAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresAdd.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPresAdd.Location = new System.Drawing.Point(355, 73);
            this.btnPresAdd.Name = "btnPresAdd";
            this.btnPresAdd.Size = new System.Drawing.Size(70, 26);
            this.btnPresAdd.TabIndex = 42;
            this.btnPresAdd.Text = "Add ";
            this.btnPresAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPresAdd.UseVisualStyleBackColor = false;
            this.btnPresAdd.Click += new System.EventHandler(this.btnPresAdd_Click);
            // 
            // dgPres
            // 
            this.dgPres.AllowUserToAddRows = false;
            this.dgPres.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgPres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPres.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PresTestNo,
            this.PresTest,
            this.PresMin,
            this.PresMax});
            this.dgPres.Location = new System.Drawing.Point(51, 105);
            this.dgPres.MultiSelect = false;
            this.dgPres.Name = "dgPres";
            this.dgPres.RowHeadersWidth = 20;
            this.dgPres.Size = new System.Drawing.Size(494, 161);
            this.dgPres.TabIndex = 41;
            this.dgPres.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPres_RowEnter);
            // 
            // PresTestNo
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PresTestNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.PresTestNo.HeaderText = "TestNo";
            this.PresTestNo.Name = "PresTestNo";
            this.PresTestNo.Visible = false;
            // 
            // PresTest
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PresTest.DefaultCellStyle = dataGridViewCellStyle3;
            this.PresTest.HeaderText = "Preservative Test";
            this.PresTest.Name = "PresTest";
            this.PresTest.ReadOnly = true;
            this.PresTest.Width = 250;
            // 
            // PresMin
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PresMin.DefaultCellStyle = dataGridViewCellStyle4;
            this.PresMin.HeaderText = "Min";
            this.PresMin.Name = "PresMin";
            this.PresMin.ReadOnly = true;
            // 
            // PresMax
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PresMax.DefaultCellStyle = dataGridViewCellStyle5;
            this.PresMax.HeaderText = "Max";
            this.PresMax.Name = "PresMax";
            this.PresMax.ReadOnly = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(485, 19);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 16);
            this.label20.TabIndex = 40;
            this.label20.Text = "Max";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(400, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(30, 16);
            this.label21.TabIndex = 39;
            this.label21.Text = "Min";
            // 
            // txtPresMax
            // 
            this.txtPresMax.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPresMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPresMax.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresMax.Location = new System.Drawing.Point(461, 40);
            this.txtPresMax.MaxLength = 25;
            this.txtPresMax.Name = "txtPresMax";
            this.txtPresMax.Size = new System.Drawing.Size(77, 23);
            this.txtPresMax.TabIndex = 37;
            this.txtPresMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPresMax_KeyPress);
            // 
            // txtPresMin
            // 
            this.txtPresMin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPresMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPresMin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresMin.Location = new System.Drawing.Point(378, 40);
            this.txtPresMin.MaxLength = 25;
            this.txtPresMin.Name = "txtPresMin";
            this.txtPresMin.Size = new System.Drawing.Size(77, 23);
            this.txtPresMin.TabIndex = 36;
            this.txtPresMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPresMin_KeyPress);
            // 
            // cmbPresTest
            // 
            this.cmbPresTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbPresTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPresTest.FormattingEnabled = true;
            this.cmbPresTest.Location = new System.Drawing.Point(64, 38);
            this.cmbPresTest.Name = "cmbPresTest";
            this.cmbPresTest.Size = new System.Drawing.Size(299, 24);
            this.cmbPresTest.TabIndex = 35;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(64, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 16);
            this.label22.TabIndex = 38;
            this.label22.Text = "Select Test";
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(859, 445);
            this.panelOuter.TabIndex = 9;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(857, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(857, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(167, 27);
            this.toolStripLabel1.Text = "Preservative Method Master";
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
            this.panelBottom.Location = new System.Drawing.Point(0, 30);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(857, 413);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.groupBox3);
            this.panelFill.Controls.Add(this.List);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(857, 413);
            this.panelFill.TabIndex = 43;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(13, 8);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(16, 31);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(207, 23);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // FrmPreservativeMethodMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(859, 445);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPreservativeMethodMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preservative Method Master";
            this.Load += new System.EventHandler(this.FrmPreservativeMethodMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPres)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPresReset;
        private System.Windows.Forms.Button btnPresDelete;
        private System.Windows.Forms.Button btnPresAdd;
        private System.Windows.Forms.DataGridView dgPres;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtPresMax;
        private System.Windows.Forms.TextBox txtPresMin;
        private System.Windows.Forms.ComboBox cmbPresTest;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresTestNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn PresMax;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}