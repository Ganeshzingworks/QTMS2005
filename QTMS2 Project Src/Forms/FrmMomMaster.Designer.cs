namespace QTMS.Forms
{
    partial class FrmMOMMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMOMMaster));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnreset = new System.Windows.Forms.Button();
            this.btnSaveAsNew = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.panelFill = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.txtSerachMom = new System.Windows.Forms.TextBox();
            this.List = new System.Windows.Forms.ListBox();
            this.tabMom = new System.Windows.Forms.TabControl();
            this.MOMtab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMomNo = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ChkSHE = new System.Windows.Forms.CheckBox();
            this.ChkUp = new System.Windows.Forms.CheckBox();
            this.ChkIndestrial = new System.Windows.Forms.CheckBox();
            this.btnnext = new System.Windows.Forms.Button();
            this.cmbMOMNo = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cheklistVessel = new System.Windows.Forms.CheckedListBox();
            this.checkedListAnnexTank = new System.Windows.Forms.CheckedListBox();
            this.checkedListFormulano = new System.Windows.Forms.CheckedListBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtISODocumentNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSHEAcceptedby = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUPAcceptedby = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIQAcceptedby = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtProductDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.DtpUPAcceptedDate = new System.Windows.Forms.DateTimePicker();
            this.DtpIQDate = new System.Windows.Forms.DateTimePicker();
            this.DtpSHEAcceptedDate = new System.Windows.Forms.DateTimePicker();
            this.txtReferenceDoc = new System.Windows.Forms.TextBox();
            this.txtIQPreparedby = new System.Windows.Forms.TextBox();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.MOMPorcess = new System.Windows.Forms.TabPage();
            this.btnDeleteProcess = new System.Windows.Forms.Button();
            this.kaireeHTMLEditor1 = new Kairee.Editor.KaireeHTMLEditor();
            this.reset = new System.Windows.Forms.Button();
            this.btcancel = new System.Windows.Forms.Button();
            this.lblDetailID = new System.Windows.Forms.Label();
            this.lblisnew = new System.Windows.Forms.Label();
            this.lblrowupdateID = new System.Windows.Forms.Label();
            this.lblisupdate = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PrintSequenceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.htmlProcessDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsNoteProSubPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcessDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accsessories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scrapper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impeller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emulsifer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Isupdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dummysrno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrintSquenceNo = new System.Windows.Forms.TextBox();
            this.txtSrNo = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.cmbVaC = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnPrevioustab2 = new System.Windows.Forms.Button();
            this.btntab2next = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.checklistAccessory = new System.Windows.Forms.CheckedListBox();
            this.label34 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checklistSafetysymbol = new System.Windows.Forms.CheckedListBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtprocessdesc = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbemulsifer = new System.Windows.Forms.ComboBox();
            this.cmbImpeller = new System.Windows.Forms.ComboBox();
            this.cmbScarpper = new System.Windows.Forms.ComboBox();
            this.cmbdesc = new System.Windows.Forms.ComboBox();
            this.MOMFooter = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAdjustmentquantity = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnPrevioustab3 = new System.Windows.Forms.Button();
            this.btexit = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
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
            this.groupBox2.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.tabMom.SuspendLayout();
            this.MOMtab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.MOMPorcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.MOMFooter.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnreset);
            this.groupBox2.Controls.Add(this.btnSaveAsNew);
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnModify);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Location = new System.Drawing.Point(223, 492);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(651, 53);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnreset.Location = new System.Drawing.Point(523, 19);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(101, 28);
            this.btnreset.TabIndex = 30;
            this.btnreset.Text = "&Reset";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnSaveAsNew
            // 
            this.btnSaveAsNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSaveAsNew.Enabled = false;
            this.btnSaveAsNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAsNew.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAsNew.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveAsNew.Location = new System.Drawing.Point(18, 19);
            this.btnSaveAsNew.Name = "btnSaveAsNew";
            this.btnSaveAsNew.Size = new System.Drawing.Size(111, 28);
            this.btnSaveAsNew.TabIndex = 17;
            this.btnSaveAsNew.Text = "Save &As";
            this.btnSaveAsNew.UseVisualStyleBackColor = false;
            this.btnSaveAsNew.Visible = false;
            this.btnSaveAsNew.Click += new System.EventHandler(this.btnSaveAsNew_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(268, 19);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(111, 28);
            this.BtnDelete.TabIndex = 19;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnModify.Enabled = false;
            this.BtnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModify.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModify.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnModify.Location = new System.Drawing.Point(147, 19);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(99, 28);
            this.BtnModify.TabIndex = 18;
            this.BtnModify.Text = "&Modify";
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Visible = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(395, 19);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(111, 28);
            this.BtnExit.TabIndex = 20;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panelFill
            // 
            this.panelFill.AutoScroll = true;
            this.panelFill.Controls.Add(this.label36);
            this.panelFill.Controls.Add(this.txtSerachMom);
            this.panelFill.Controls.Add(this.List);
            this.panelFill.Controls.Add(this.tabMom);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(1255, 615);
            this.panelFill.TabIndex = 0;
            this.panelFill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFill_Paint);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(0, 6);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(47, 13);
            this.label36.TabIndex = 15;
            this.label36.Text = "Search :";
            // 
            // txtSerachMom
            // 
            this.txtSerachMom.Location = new System.Drawing.Point(2, 22);
            this.txtSerachMom.Name = "txtSerachMom";
            this.txtSerachMom.Size = new System.Drawing.Size(177, 20);
            this.txtSerachMom.TabIndex = 14;
            this.txtSerachMom.TextChanged += new System.EventHandler(this.txtSerachMom_TextChanged);
            this.txtSerachMom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerachMom_KeyDown);
            this.txtSerachMom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSerachMom_KeyUp);
            this.txtSerachMom.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSerachMom_MouseClick);
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.Color.WhiteSmoke;
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.List.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.HorizontalScrollbar = true;
            this.List.Location = new System.Drawing.Point(2, 44);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(178, 535);
            this.List.TabIndex = 17;
            this.List.DoubleClick += new System.EventHandler(this.List_DoubleClick);
            // 
            // tabMom
            // 
            this.tabMom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tabMom.Controls.Add(this.MOMtab);
            this.tabMom.Controls.Add(this.MOMPorcess);
            this.tabMom.Controls.Add(this.MOMFooter);
            this.tabMom.Location = new System.Drawing.Point(182, 7);
            this.tabMom.Name = "tabMom";
            this.tabMom.SelectedIndex = 0;
            this.tabMom.Size = new System.Drawing.Size(1065, 612);
            this.tabMom.TabIndex = 3;
            this.tabMom.TabIndexChanged += new System.EventHandler(this.tabMom_TabIndexChanged);
            this.tabMom.SelectedIndexChanged += new System.EventHandler(this.tabMom_SelectedIndexChanged);
            // 
            // MOMtab
            // 
            this.MOMtab.Controls.Add(this.panel1);
            this.MOMtab.Location = new System.Drawing.Point(4, 22);
            this.MOMtab.Name = "MOMtab";
            this.MOMtab.Padding = new System.Windows.Forms.Padding(3);
            this.MOMtab.Size = new System.Drawing.Size(1057, 586);
            this.MOMtab.TabIndex = 0;
            this.MOMtab.Text = "MomMaster ";
            this.MOMtab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 580);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.groupBox1.Controls.Add(this.txtMomNo);
            this.groupBox1.Controls.Add(this.lblSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.ChkSHE);
            this.groupBox1.Controls.Add(this.ChkUp);
            this.groupBox1.Controls.Add(this.ChkIndestrial);
            this.groupBox1.Controls.Add(this.btnnext);
            this.groupBox1.Controls.Add(this.cmbMOMNo);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.checkedListFormulano);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtISODocumentNo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtSHEAcceptedby);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUPAcceptedby);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtIQAcceptedby);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtProductDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.DtpUPAcceptedDate);
            this.groupBox1.Controls.Add(this.DtpIQDate);
            this.groupBox1.Controls.Add(this.DtpSHEAcceptedDate);
            this.groupBox1.Controls.Add(this.txtReferenceDoc);
            this.groupBox1.Controls.Add(this.txtIQPreparedby);
            this.groupBox1.Controls.Add(this.txtBatchSize);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1043, 579);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtMomNo
            // 
            this.txtMomNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMomNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMomNo.Location = new System.Drawing.Point(284, 14);
            this.txtMomNo.Name = "txtMomNo";
            this.txtMomNo.Size = new System.Drawing.Size(318, 23);
            this.txtMomNo.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(56, 46);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(59, 16);
            this.lblSearch.TabIndex = 57;
            this.lblSearch.Text = "Search ";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(284, 46);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(199, 23);
            this.txtSearch.TabIndex = 56;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ChkSHE
            // 
            this.ChkSHE.AutoSize = true;
            this.ChkSHE.Enabled = false;
            this.ChkSHE.Location = new System.Drawing.Point(41, 368);
            this.ChkSHE.Name = "ChkSHE";
            this.ChkSHE.Size = new System.Drawing.Size(15, 14);
            this.ChkSHE.TabIndex = 55;
            this.ChkSHE.UseVisualStyleBackColor = true;
            this.ChkSHE.CheckedChanged += new System.EventHandler(this.ChkSHE_CheckedChanged);
            // 
            // ChkUp
            // 
            this.ChkUp.AutoSize = true;
            this.ChkUp.Enabled = false;
            this.ChkUp.Location = new System.Drawing.Point(41, 335);
            this.ChkUp.Name = "ChkUp";
            this.ChkUp.Size = new System.Drawing.Size(15, 14);
            this.ChkUp.TabIndex = 54;
            this.ChkUp.UseVisualStyleBackColor = true;
            this.ChkUp.CheckedChanged += new System.EventHandler(this.ChkUp_CheckedChanged);
            // 
            // ChkIndestrial
            // 
            this.ChkIndestrial.AutoSize = true;
            this.ChkIndestrial.Enabled = false;
            this.ChkIndestrial.Location = new System.Drawing.Point(41, 302);
            this.ChkIndestrial.Name = "ChkIndestrial";
            this.ChkIndestrial.Size = new System.Drawing.Size(15, 14);
            this.ChkIndestrial.TabIndex = 53;
            this.ChkIndestrial.UseVisualStyleBackColor = true;
            this.ChkIndestrial.CheckedChanged += new System.EventHandler(this.ChkIndestrial_CheckedChanged);
            // 
            // btnnext
            // 
            this.btnnext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnext.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnext.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnnext.Location = new System.Drawing.Point(553, 462);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(77, 28);
            this.btnnext.TabIndex = 16;
            this.btnnext.Text = "Next";
            this.btnnext.UseVisualStyleBackColor = false;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // cmbMOMNo
            // 
            this.cmbMOMNo.FormattingEnabled = true;
            this.cmbMOMNo.Location = new System.Drawing.Point(560, 11);
            this.cmbMOMNo.Name = "cmbMOMNo";
            this.cmbMOMNo.Size = new System.Drawing.Size(199, 21);
            this.cmbMOMNo.TabIndex = 0;
            this.cmbMOMNo.Visible = false;
            this.cmbMOMNo.SelectionChangeCommitted += new System.EventHandler(this.cmbMOMNo_SelectionChangeCommitted);
            this.cmbMOMNo.SelectedIndexChanged += new System.EventHandler(this.cmbMOMNo_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.cheklistVessel);
            this.panel4.Controls.Add(this.checkedListAnnexTank);
            this.panel4.Location = new System.Drawing.Point(505, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(460, 151);
            this.panel4.TabIndex = 52;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(239, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 16);
            this.label17.TabIndex = 53;
            this.label17.Text = "Annex Tank";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 16);
            this.label13.TabIndex = 51;
            this.label13.Text = "Vessel";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(159, 16);
            this.label16.TabIndex = 48;
            this.label16.Text = "Equipments to be used";
            // 
            // cheklistVessel
            // 
            this.cheklistVessel.FormattingEnabled = true;
            this.cheklistVessel.Location = new System.Drawing.Point(6, 38);
            this.cheklistVessel.Name = "cheklistVessel";
            this.cheklistVessel.Size = new System.Drawing.Size(212, 109);
            this.cheklistVessel.TabIndex = 2;
            // 
            // checkedListAnnexTank
            // 
            this.checkedListAnnexTank.FormattingEnabled = true;
            this.checkedListAnnexTank.Location = new System.Drawing.Point(233, 38);
            this.checkedListAnnexTank.Name = "checkedListAnnexTank";
            this.checkedListAnnexTank.Size = new System.Drawing.Size(209, 109);
            this.checkedListAnnexTank.TabIndex = 3;
            // 
            // checkedListFormulano
            // 
            this.checkedListFormulano.FormattingEnabled = true;
            this.checkedListFormulano.Location = new System.Drawing.Point(284, 72);
            this.checkedListFormulano.Name = "checkedListFormulano";
            this.checkedListFormulano.Size = new System.Drawing.Size(199, 109);
            this.checkedListFormulano.TabIndex = 1;
            this.checkedListFormulano.SelectedIndexChanged += new System.EventHandler(this.checkedListFormulano_SelectedIndexChanged);
            this.checkedListFormulano.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListFormulano_ItemCheck);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(56, 366);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(150, 16);
            this.label25.TabIndex = 20;
            this.label25.Text = "S.H.E. - Accepted By";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Location = new System.Drawing.Point(3, 646);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(774, 61);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(141, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save &As";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Location = new System.Drawing.Point(395, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "&Delete";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Location = new System.Drawing.Point(268, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 28);
            this.button3.TabIndex = 2;
            this.button3.Text = "&Modify";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button4.Location = new System.Drawing.Point(14, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 28);
            this.button4.TabIndex = 0;
            this.button4.Text = "&Reset";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button5.Location = new System.Drawing.Point(649, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(111, 28);
            this.button5.TabIndex = 5;
            this.button5.Text = "E&xit";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button6.Location = new System.Drawing.Point(522, 20);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(111, 28);
            this.button6.TabIndex = 4;
            this.button6.Text = "&Save";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReason.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.Location = new System.Drawing.Point(284, 466);
            this.txtReason.MaxLength = 100;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(164, 23);
            this.txtReason.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formula No";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(56, 470);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 16);
            this.label14.TabIndex = 44;
            this.label14.Text = "Reason for Issue";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label6.Location = new System.Drawing.Point(56, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 38;
            this.label6.Text = "MOM No";
            // 
            // txtISODocumentNo
            // 
            this.txtISODocumentNo.AcceptsReturn = true;
            this.txtISODocumentNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtISODocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtISODocumentNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtISODocumentNo.Location = new System.Drawing.Point(284, 398);
            this.txtISODocumentNo.MaxLength = 30;
            this.txtISODocumentNo.Name = "txtISODocumentNo";
            this.txtISODocumentNo.Size = new System.Drawing.Size(164, 23);
            this.txtISODocumentNo.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(623, 366);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(170, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "S.H.E. - Accepted Date ";
            // 
            // txtSHEAcceptedby
            // 
            this.txtSHEAcceptedby.AcceptsReturn = true;
            this.txtSHEAcceptedby.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSHEAcceptedby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSHEAcceptedby.Enabled = false;
            this.txtSHEAcceptedby.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSHEAcceptedby.Location = new System.Drawing.Point(284, 366);
            this.txtSHEAcceptedby.MaxLength = 100;
            this.txtSHEAcceptedby.Multiline = true;
            this.txtSHEAcceptedby.Name = "txtSHEAcceptedby";
            this.txtSHEAcceptedby.Size = new System.Drawing.Size(259, 20);
            this.txtSHEAcceptedby.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(623, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 16);
            this.label5.TabIndex = 34;
            this.label5.Text = "U.P. - Accepted Date";
            // 
            // txtUPAcceptedby
            // 
            this.txtUPAcceptedby.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUPAcceptedby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUPAcceptedby.Enabled = false;
            this.txtUPAcceptedby.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUPAcceptedby.Location = new System.Drawing.Point(284, 335);
            this.txtUPAcceptedby.MaxLength = 100;
            this.txtUPAcceptedby.Multiline = true;
            this.txtUPAcceptedby.Name = "txtUPAcceptedby";
            this.txtUPAcceptedby.Size = new System.Drawing.Size(259, 20);
            this.txtUPAcceptedby.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(57, 332);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 16);
            this.label10.TabIndex = 32;
            this.label10.Text = "U.P. - Accepted By";
            // 
            // txtIQAcceptedby
            // 
            this.txtIQAcceptedby.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtIQAcceptedby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIQAcceptedby.Enabled = false;
            this.txtIQAcceptedby.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIQAcceptedby.Location = new System.Drawing.Point(284, 298);
            this.txtIQAcceptedby.MaxLength = 100;
            this.txtIQAcceptedby.Multiline = true;
            this.txtIQAcceptedby.Name = "txtIQAcceptedby";
            this.txtIQAcceptedby.Size = new System.Drawing.Size(259, 20);
            this.txtIQAcceptedby.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(623, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 16);
            this.label9.TabIndex = 30;
            this.label9.Text = "Industrial Quality –Date ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(56, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(222, 32);
            this.label8.TabIndex = 29;
            this.label8.Text = "Industrial Quality – Accepted By\r\n ";
            // 
            // txtProductDescription
            // 
            this.txtProductDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtProductDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductDescription.Location = new System.Drawing.Point(284, 220);
            this.txtProductDescription.MaxLength = 250;
            this.txtProductDescription.Multiline = true;
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.Size = new System.Drawing.Size(259, 39);
            this.txtProductDescription.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Batch Size ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Product Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Industrial Quality – Prepared By ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Reference Document";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(57, 400);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(120, 16);
            this.label23.TabIndex = 14;
            this.label23.Text = "ISODocument No";
            // 
            // DtpUPAcceptedDate
            // 
            this.DtpUPAcceptedDate.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpUPAcceptedDate.Checked = false;
            this.DtpUPAcceptedDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpUPAcceptedDate.Enabled = false;
            this.DtpUPAcceptedDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpUPAcceptedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpUPAcceptedDate.Location = new System.Drawing.Point(804, 325);
            this.DtpUPAcceptedDate.Name = "DtpUPAcceptedDate";
            this.DtpUPAcceptedDate.ShowCheckBox = true;
            this.DtpUPAcceptedDate.Size = new System.Drawing.Size(143, 23);
            this.DtpUPAcceptedDate.TabIndex = 11;
            this.DtpUPAcceptedDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // DtpIQDate
            // 
            this.DtpIQDate.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpIQDate.Checked = false;
            this.DtpIQDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpIQDate.Enabled = false;
            this.DtpIQDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpIQDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpIQDate.Location = new System.Drawing.Point(804, 293);
            this.DtpIQDate.Name = "DtpIQDate";
            this.DtpIQDate.ShowCheckBox = true;
            this.DtpIQDate.Size = new System.Drawing.Size(143, 23);
            this.DtpIQDate.TabIndex = 8;
            this.DtpIQDate.Value = new System.DateTime(2010, 7, 12, 0, 0, 0, 0);
            // 
            // DtpSHEAcceptedDate
            // 
            this.DtpSHEAcceptedDate.CalendarFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSHEAcceptedDate.Checked = false;
            this.DtpSHEAcceptedDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpSHEAcceptedDate.Enabled = false;
            this.DtpSHEAcceptedDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpSHEAcceptedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpSHEAcceptedDate.Location = new System.Drawing.Point(804, 359);
            this.DtpSHEAcceptedDate.Name = "DtpSHEAcceptedDate";
            this.DtpSHEAcceptedDate.ShowCheckBox = true;
            this.DtpSHEAcceptedDate.Size = new System.Drawing.Size(143, 23);
            this.DtpSHEAcceptedDate.TabIndex = 12;
            this.DtpSHEAcceptedDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // txtReferenceDoc
            // 
            this.txtReferenceDoc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReferenceDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferenceDoc.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceDoc.Location = new System.Drawing.Point(284, 433);
            this.txtReferenceDoc.MaxLength = 100;
            this.txtReferenceDoc.Name = "txtReferenceDoc";
            this.txtReferenceDoc.Size = new System.Drawing.Size(259, 23);
            this.txtReferenceDoc.TabIndex = 14;
            // 
            // txtIQPreparedby
            // 
            this.txtIQPreparedby.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtIQPreparedby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIQPreparedby.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIQPreparedby.Location = new System.Drawing.Point(284, 266);
            this.txtIQPreparedby.MaxLength = 100;
            this.txtIQPreparedby.Name = "txtIQPreparedby";
            this.txtIQPreparedby.Size = new System.Drawing.Size(259, 23);
            this.txtIQPreparedby.TabIndex = 6;
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBatchSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBatchSize.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchSize.Location = new System.Drawing.Point(284, 190);
            this.txtBatchSize.MaxLength = 250;
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.Size = new System.Drawing.Size(199, 23);
            this.txtBatchSize.TabIndex = 4;
            // 
            // MOMPorcess
            // 
            this.MOMPorcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.MOMPorcess.Controls.Add(this.btnDeleteProcess);
            this.MOMPorcess.Controls.Add(this.kaireeHTMLEditor1);
            this.MOMPorcess.Controls.Add(this.reset);
            this.MOMPorcess.Controls.Add(this.btcancel);
            this.MOMPorcess.Controls.Add(this.lblDetailID);
            this.MOMPorcess.Controls.Add(this.lblisnew);
            this.MOMPorcess.Controls.Add(this.lblrowupdateID);
            this.MOMPorcess.Controls.Add(this.lblisupdate);
            this.MOMPorcess.Controls.Add(this.dataGridView1);
            this.MOMPorcess.Controls.Add(this.txtPrintSquenceNo);
            this.MOMPorcess.Controls.Add(this.txtSrNo);
            this.MOMPorcess.Controls.Add(this.label35);
            this.MOMPorcess.Controls.Add(this.label15);
            this.MOMPorcess.Controls.Add(this.btnadd);
            this.MOMPorcess.Controls.Add(this.cmbVaC);
            this.MOMPorcess.Controls.Add(this.label12);
            this.MOMPorcess.Controls.Add(this.btnPrevioustab2);
            this.MOMPorcess.Controls.Add(this.btntab2next);
            this.MOMPorcess.Controls.Add(this.panel8);
            this.MOMPorcess.Controls.Add(this.panel5);
            this.MOMPorcess.Controls.Add(this.txtprocessdesc);
            this.MOMPorcess.Controls.Add(this.label31);
            this.MOMPorcess.Controls.Add(this.label30);
            this.MOMPorcess.Controls.Add(this.label29);
            this.MOMPorcess.Controls.Add(this.label28);
            this.MOMPorcess.Controls.Add(this.label27);
            this.MOMPorcess.Controls.Add(this.cmbemulsifer);
            this.MOMPorcess.Controls.Add(this.cmbImpeller);
            this.MOMPorcess.Controls.Add(this.cmbScarpper);
            this.MOMPorcess.Controls.Add(this.cmbdesc);
            this.MOMPorcess.Location = new System.Drawing.Point(4, 22);
            this.MOMPorcess.Name = "MOMPorcess";
            this.MOMPorcess.Padding = new System.Windows.Forms.Padding(3);
            this.MOMPorcess.Size = new System.Drawing.Size(1057, 586);
            this.MOMPorcess.TabIndex = 1;
            this.MOMPorcess.Text = "MOMPorcess";
            this.MOMPorcess.UseVisualStyleBackColor = true;
            this.MOMPorcess.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnDeleteProcess
            // 
            this.btnDeleteProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnDeleteProcess.Enabled = false;
            this.btnDeleteProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProcess.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProcess.ForeColor = System.Drawing.Color.White;
            this.btnDeleteProcess.Location = new System.Drawing.Point(519, 304);
            this.btnDeleteProcess.Name = "btnDeleteProcess";
            this.btnDeleteProcess.Size = new System.Drawing.Size(73, 27);
            this.btnDeleteProcess.TabIndex = 28;
            this.btnDeleteProcess.Text = "Delete";
            this.btnDeleteProcess.UseVisualStyleBackColor = false;
            this.btnDeleteProcess.Click += new System.EventHandler(this.btnDeleteProcess_Click);
            // 
            // kaireeHTMLEditor1
            // 
            this.kaireeHTMLEditor1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kaireeHTMLEditor1.Location = new System.Drawing.Point(356, 22);
            this.kaireeHTMLEditor1.Name = "kaireeHTMLEditor1";
            this.kaireeHTMLEditor1.Size = new System.Drawing.Size(598, 197);
            this.kaireeHTMLEditor1.TabIndex = 27;
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.reset.Location = new System.Drawing.Point(493, 535);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(63, 27);
            this.reset.TabIndex = 15;
            this.reset.Text = "&Reset ";
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // btcancel
            // 
            this.btcancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btcancel.Enabled = false;
            this.btcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btcancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btcancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btcancel.Location = new System.Drawing.Point(441, 304);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(72, 27);
            this.btcancel.TabIndex = 11;
            this.btcancel.Text = "&Cancel";
            this.btcancel.UseVisualStyleBackColor = false;
            this.btcancel.Click += new System.EventHandler(this.btcancle_Click);
            // 
            // lblDetailID
            // 
            this.lblDetailID.AutoSize = true;
            this.lblDetailID.Location = new System.Drawing.Point(438, 333);
            this.lblDetailID.Name = "lblDetailID";
            this.lblDetailID.Size = new System.Drawing.Size(13, 13);
            this.lblDetailID.TabIndex = 26;
            this.lblDetailID.Text = "0";
            this.lblDetailID.Visible = false;
            // 
            // lblisnew
            // 
            this.lblisnew.AutoSize = true;
            this.lblisnew.Location = new System.Drawing.Point(417, 333);
            this.lblisnew.Name = "lblisnew";
            this.lblisnew.Size = new System.Drawing.Size(13, 13);
            this.lblisnew.TabIndex = 26;
            this.lblisnew.Text = "0";
            this.lblisnew.Visible = false;
            // 
            // lblrowupdateID
            // 
            this.lblrowupdateID.AutoSize = true;
            this.lblrowupdateID.Location = new System.Drawing.Point(398, 333);
            this.lblrowupdateID.Name = "lblrowupdateID";
            this.lblrowupdateID.Size = new System.Drawing.Size(13, 13);
            this.lblrowupdateID.TabIndex = 25;
            this.lblrowupdateID.Text = "0";
            this.lblrowupdateID.Visible = false;
            // 
            // lblisupdate
            // 
            this.lblisupdate.AutoSize = true;
            this.lblisupdate.Location = new System.Drawing.Point(379, 333);
            this.lblisupdate.Name = "lblisupdate";
            this.lblisupdate.Size = new System.Drawing.Size(13, 13);
            this.lblisupdate.TabIndex = 24;
            this.lblisupdate.Text = "0";
            this.lblisupdate.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PrintSequenceNo,
            this.htmlProcessDesc,
            this.IsNoteProSubPro,
            this.SerialNo,
            this.ProcessDesc,
            this.Symb,
            this.Accsessories,
            this.Scrapper,
            this.Impeller,
            this.Emulsifer,
            this.Vac,
            this.Isupdate,
            this.DetailID,
            this.dummysrno});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(9, 352);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(1048, 177);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // PrintSequenceNo
            // 
            this.PrintSequenceNo.DataPropertyName = "PrintSequenceNo";
            this.PrintSequenceNo.HeaderText = "PrintSequenceNo";
            this.PrintSequenceNo.Name = "PrintSequenceNo";
            this.PrintSequenceNo.ReadOnly = true;
            // 
            // htmlProcessDesc
            // 
            this.htmlProcessDesc.DataPropertyName = "htmlProcessDesc";
            this.htmlProcessDesc.HeaderText = "htmlProcessDesc";
            this.htmlProcessDesc.Name = "htmlProcessDesc";
            this.htmlProcessDesc.ReadOnly = true;
            this.htmlProcessDesc.Visible = false;
            // 
            // IsNoteProSubPro
            // 
            this.IsNoteProSubPro.DataPropertyName = "isNoteProSubPro";
            this.IsNoteProSubPro.HeaderText = "IsNoteProSubPro";
            this.IsNoteProSubPro.Name = "IsNoteProSubPro";
            this.IsNoteProSubPro.ReadOnly = true;
            // 
            // SerialNo
            // 
            this.SerialNo.DataPropertyName = "SrNo";
            this.SerialNo.HeaderText = "SrNo";
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.ReadOnly = true;
            // 
            // ProcessDesc
            // 
            this.ProcessDesc.DataPropertyName = "ProcessDesc";
            this.ProcessDesc.HeaderText = "Process Description ";
            this.ProcessDesc.Name = "ProcessDesc";
            this.ProcessDesc.ReadOnly = true;
            this.ProcessDesc.ToolTipText = "Process Description ";
            // 
            // Symb
            // 
            this.Symb.DataPropertyName = "Symb";
            this.Symb.HeaderText = "Safety-Symbols";
            this.Symb.Name = "Symb";
            this.Symb.ReadOnly = true;
            // 
            // Accsessories
            // 
            this.Accsessories.DataPropertyName = "Accsessories";
            this.Accsessories.HeaderText = "Accsessories";
            this.Accsessories.Name = "Accsessories";
            this.Accsessories.ReadOnly = true;
            // 
            // Scrapper
            // 
            this.Scrapper.DataPropertyName = "Scrapper";
            this.Scrapper.HeaderText = "Scrapper";
            this.Scrapper.Name = "Scrapper";
            this.Scrapper.ReadOnly = true;
            // 
            // Impeller
            // 
            this.Impeller.DataPropertyName = "Impeller";
            this.Impeller.HeaderText = "Impeller";
            this.Impeller.Name = "Impeller";
            this.Impeller.ReadOnly = true;
            // 
            // Emulsifer
            // 
            this.Emulsifer.DataPropertyName = "Emulsifer";
            this.Emulsifer.HeaderText = "Emulsifer";
            this.Emulsifer.Name = "Emulsifer";
            this.Emulsifer.ReadOnly = true;
            // 
            // Vac
            // 
            this.Vac.DataPropertyName = "Vac";
            this.Vac.HeaderText = "Vac";
            this.Vac.Name = "Vac";
            this.Vac.ReadOnly = true;
            // 
            // Isupdate
            // 
            this.Isupdate.DataPropertyName = "Isupdate";
            this.Isupdate.HeaderText = "Isupdate";
            this.Isupdate.Name = "Isupdate";
            this.Isupdate.ReadOnly = true;
            this.Isupdate.Visible = false;
            // 
            // DetailID
            // 
            this.DetailID.DataPropertyName = "DetailID";
            this.DetailID.HeaderText = "DetailID";
            this.DetailID.Name = "DetailID";
            this.DetailID.ReadOnly = true;
            // 
            // dummysrno
            // 
            this.dummysrno.DataPropertyName = "dummysrno";
            this.dummysrno.HeaderText = "dummysrno";
            this.dummysrno.Name = "dummysrno";
            this.dummysrno.ReadOnly = true;
            this.dummysrno.Visible = false;
            // 
            // txtPrintSquenceNo
            // 
            this.txtPrintSquenceNo.Location = new System.Drawing.Point(194, 76);
            this.txtPrintSquenceNo.Name = "txtPrintSquenceNo";
            this.txtPrintSquenceNo.Size = new System.Drawing.Size(130, 20);
            this.txtPrintSquenceNo.TabIndex = 2;
            // 
            // txtSrNo
            // 
            this.txtSrNo.Location = new System.Drawing.Point(194, 42);
            this.txtSrNo.Name = "txtSrNo";
            this.txtSrNo.Size = new System.Drawing.Size(130, 20);
            this.txtSrNo.TabIndex = 1;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label35.Location = new System.Drawing.Point(118, 46);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(44, 16);
            this.label35.TabIndex = 20;
            this.label35.Text = "SrNo.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label15.Location = new System.Drawing.Point(68, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 16);
            this.label15.TabIndex = 19;
            this.label15.Text = "PrintSequenceNo";
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnadd.Location = new System.Drawing.Point(361, 304);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(74, 27);
            this.btnadd.TabIndex = 10;
            this.btnadd.Text = "&Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // cmbVaC
            // 
            this.cmbVaC.FormattingEnabled = true;
            this.cmbVaC.Location = new System.Drawing.Point(792, 277);
            this.cmbVaC.Name = "cmbVaC";
            this.cmbVaC.Size = new System.Drawing.Size(129, 21);
            this.cmbVaC.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label12.Location = new System.Drawing.Point(799, 249);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 16);
            this.label12.TabIndex = 14;
            this.label12.Text = "Vac";
            // 
            // btnPrevioustab2
            // 
            this.btnPrevioustab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPrevioustab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevioustab2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevioustab2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrevioustab2.Location = new System.Drawing.Point(327, 535);
            this.btnPrevioustab2.Name = "btnPrevioustab2";
            this.btnPrevioustab2.Size = new System.Drawing.Size(84, 27);
            this.btnPrevioustab2.TabIndex = 14;
            this.btnPrevioustab2.Text = "&Previous ";
            this.btnPrevioustab2.UseVisualStyleBackColor = false;
            this.btnPrevioustab2.Click += new System.EventHandler(this.btnPrevioustab2_Click);
            // 
            // btntab2next
            // 
            this.btntab2next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btntab2next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntab2next.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntab2next.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btntab2next.Location = new System.Drawing.Point(417, 535);
            this.btntab2next.Name = "btntab2next";
            this.btntab2next.Size = new System.Drawing.Size(67, 27);
            this.btntab2next.TabIndex = 13;
            this.btntab2next.Text = "&Next";
            this.btntab2next.UseVisualStyleBackColor = false;
            this.btntab2next.Click += new System.EventHandler(this.btntab2next_Click_1);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.checklistAccessory);
            this.panel8.Controls.Add(this.label34);
            this.panel8.Location = new System.Drawing.Point(168, 115);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(161, 231);
            this.panel8.TabIndex = 11;
            // 
            // checklistAccessory
            // 
            this.checklistAccessory.FormattingEnabled = true;
            this.checklistAccessory.Location = new System.Drawing.Point(3, 19);
            this.checklistAccessory.Name = "checklistAccessory";
            this.checklistAccessory.Size = new System.Drawing.Size(149, 199);
            this.checklistAccessory.TabIndex = 4;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(3, 1);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(78, 15);
            this.label34.TabIndex = 12;
            this.label34.Text = "Accsessories";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.checklistSafetysymbol);
            this.panel5.Controls.Add(this.label32);
            this.panel5.Location = new System.Drawing.Point(6, 115);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(156, 231);
            this.panel5.TabIndex = 10;
            // 
            // checklistSafetysymbol
            // 
            this.checklistSafetysymbol.FormattingEnabled = true;
            this.checklistSafetysymbol.Location = new System.Drawing.Point(3, 19);
            this.checklistSafetysymbol.Name = "checklistSafetysymbol";
            this.checklistSafetysymbol.Size = new System.Drawing.Size(141, 199);
            this.checklistSafetysymbol.TabIndex = 3;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label32.Location = new System.Drawing.Point(3, 4);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(113, 16);
            this.label32.TabIndex = 11;
            this.label32.Text = "Safety-Symbols";
            // 
            // txtprocessdesc
            // 
            this.txtprocessdesc.Location = new System.Drawing.Point(361, 57);
            this.txtprocessdesc.Multiline = true;
            this.txtprocessdesc.Name = "txtprocessdesc";
            this.txtprocessdesc.Size = new System.Drawing.Size(425, 74);
            this.txtprocessdesc.TabIndex = 9;
            this.txtprocessdesc.Visible = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label31.Location = new System.Drawing.Point(591, 3);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(142, 16);
            this.label31.TabIndex = 8;
            this.label31.Text = "Process Description ";
            this.label31.Click += new System.EventHandler(this.label31_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label30.Location = new System.Drawing.Point(647, 249);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(69, 16);
            this.label30.TabIndex = 7;
            this.label30.Text = "Emulsifier";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label29.Location = new System.Drawing.Point(503, 249);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(59, 16);
            this.label29.TabIndex = 6;
            this.label29.Text = "Impeller";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label28.Location = new System.Drawing.Point(358, 249);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(64, 16);
            this.label28.TabIndex = 5;
            this.label28.Text = "Srapper ";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label27.Location = new System.Drawing.Point(3, 15);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(185, 16);
            this.label27.TabIndex = 4;
            this.label27.Text = "Note/Process/Sub-Process";
            // 
            // cmbemulsifer
            // 
            this.cmbemulsifer.FormattingEnabled = true;
            this.cmbemulsifer.Location = new System.Drawing.Point(650, 277);
            this.cmbemulsifer.Name = "cmbemulsifer";
            this.cmbemulsifer.Size = new System.Drawing.Size(136, 21);
            this.cmbemulsifer.TabIndex = 8;
            // 
            // cmbImpeller
            // 
            this.cmbImpeller.FormattingEnabled = true;
            this.cmbImpeller.Location = new System.Drawing.Point(506, 277);
            this.cmbImpeller.Name = "cmbImpeller";
            this.cmbImpeller.Size = new System.Drawing.Size(138, 21);
            this.cmbImpeller.TabIndex = 7;
            // 
            // cmbScarpper
            // 
            this.cmbScarpper.FormattingEnabled = true;
            this.cmbScarpper.Location = new System.Drawing.Point(361, 277);
            this.cmbScarpper.Name = "cmbScarpper";
            this.cmbScarpper.Size = new System.Drawing.Size(139, 21);
            this.cmbScarpper.TabIndex = 6;
            this.cmbScarpper.SelectedIndexChanged += new System.EventHandler(this.cmbScarpper_SelectedIndexChanged);
            // 
            // cmbdesc
            // 
            this.cmbdesc.FormattingEnabled = true;
            this.cmbdesc.Items.AddRange(new object[] {
            "Note",
            "Process",
            "Sub-Process"});
            this.cmbdesc.Location = new System.Drawing.Point(194, 15);
            this.cmbdesc.Name = "cmbdesc";
            this.cmbdesc.Size = new System.Drawing.Size(156, 21);
            this.cmbdesc.TabIndex = 0;
            this.cmbdesc.SelectionChangeCommitted += new System.EventHandler(this.cmbdesc_SelectionChangeCommitted);
            // 
            // MOMFooter
            // 
            this.MOMFooter.Controls.Add(this.panel6);
            this.MOMFooter.Location = new System.Drawing.Point(4, 22);
            this.MOMFooter.Name = "MOMFooter";
            this.MOMFooter.Padding = new System.Windows.Forms.Padding(3);
            this.MOMFooter.Size = new System.Drawing.Size(1057, 586);
            this.MOMFooter.TabIndex = 2;
            this.MOMFooter.Text = "MOMFooter";
            this.MOMFooter.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1051, 580);
            this.panel6.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1049, 10);
            this.panel7.TabIndex = 42;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, -37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1049, 615);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1049, 615);
            this.panel3.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.txtAdjustmentquantity);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Location = new System.Drawing.Point(3, 53);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(959, 447);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label26.Location = new System.Drawing.Point(7, 346);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(171, 18);
            this.label26.TabIndex = 13;
            this.label26.Text = "STORAGE TANK NO.";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label24.Location = new System.Drawing.Point(3, 293);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(191, 18);
            this.label24.TabIndex = 12;
            this.label24.Text = "BATCH TRANSFERRED";
            this.label24.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(7, 240);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(149, 18);
            this.label22.TabIndex = 11;
            this.label22.Text = "BATCH FINISHED ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(7, 198);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(144, 18);
            this.label21.TabIndex = 10;
            this.label21.Text = "BATCH STARTED";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(699, 156);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 18);
            this.label20.TabIndex = 9;
            this.label20.Text = "BY";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(527, 156);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 18);
            this.label19.TabIndex = 8;
            this.label19.Text = "ON(DATE)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(374, 156);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 18);
            this.label18.TabIndex = 7;
            this.label18.Text = "AT(TIME)";
            // 
            // txtAdjustmentquantity
            // 
            this.txtAdjustmentquantity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAdjustmentquantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdjustmentquantity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdjustmentquantity.Location = new System.Drawing.Point(10, 51);
            this.txtAdjustmentquantity.MaxLength = 250;
            this.txtAdjustmentquantity.Multiline = true;
            this.txtAdjustmentquantity.Name = "txtAdjustmentquantity";
            this.txtAdjustmentquantity.Size = new System.Drawing.Size(454, 89);
            this.txtAdjustmentquantity.TabIndex = 6;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(7, 19);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(143, 16);
            this.label33.TabIndex = 4;
            this.label33.Text = "Adjustment quantity";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPrevioustab3);
            this.groupBox4.Controls.Add(this.btexit);
            this.groupBox4.Controls.Add(this.btnsave);
            this.groupBox4.Location = new System.Drawing.Point(264, 506);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 53);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // btnPrevioustab3
            // 
            this.btnPrevioustab3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPrevioustab3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevioustab3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevioustab3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrevioustab3.Location = new System.Drawing.Point(6, 19);
            this.btnPrevioustab3.Name = "btnPrevioustab3";
            this.btnPrevioustab3.Size = new System.Drawing.Size(80, 27);
            this.btnPrevioustab3.TabIndex = 14;
            this.btnPrevioustab3.Text = "&Previous ";
            this.btnPrevioustab3.UseVisualStyleBackColor = false;
            this.btnPrevioustab3.Click += new System.EventHandler(this.btnPrevioustab3_Click_1);
            // 
            // btexit
            // 
            this.btexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btexit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btexit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btexit.Location = new System.Drawing.Point(240, 19);
            this.btexit.Name = "btexit";
            this.btexit.Size = new System.Drawing.Size(94, 28);
            this.btexit.TabIndex = 5;
            this.btexit.Text = "E&xit";
            this.btexit.UseVisualStyleBackColor = false;
            this.btexit.Click += new System.EventHandler(this.btexit_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnsave.Location = new System.Drawing.Point(103, 19);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(111, 28);
            this.btnsave.TabIndex = 4;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click_1);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(1257, 643);
            this.panelOuter.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1255, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(1255, 30);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(37, 27);
            this.toolStripLabel1.Text = "MOM";
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
            this.panelBottom.Location = new System.Drawing.Point(0, 26);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1255, 615);
            this.panelBottom.TabIndex = 0;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button7.Location = new System.Drawing.Point(141, 21);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(111, 28);
            this.button7.TabIndex = 1;
            this.button7.Text = "Save &As";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button8.Enabled = false;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button8.Location = new System.Drawing.Point(395, 21);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(111, 28);
            this.button8.TabIndex = 3;
            this.button8.Text = "&Delete";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button9.Location = new System.Drawing.Point(268, 20);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(111, 28);
            this.button9.TabIndex = 2;
            this.button9.Text = "&Modify";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button10.Location = new System.Drawing.Point(14, 20);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(111, 28);
            this.button10.TabIndex = 0;
            this.button10.Text = "&Reset";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button13.Location = new System.Drawing.Point(649, 20);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(111, 28);
            this.button13.TabIndex = 5;
            this.button13.Text = "E&xit";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button14.Location = new System.Drawing.Point(522, 20);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(111, 28);
            this.button14.TabIndex = 4;
            this.button14.Text = "&Save";
            this.button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button15.Location = new System.Drawing.Point(141, 21);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(111, 28);
            this.button15.TabIndex = 1;
            this.button15.Text = "Save &As";
            this.button15.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button16.Enabled = false;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button16.Location = new System.Drawing.Point(395, 21);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(111, 28);
            this.button16.TabIndex = 3;
            this.button16.Text = "&Delete";
            this.button16.UseVisualStyleBackColor = false;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button17.Location = new System.Drawing.Point(268, 20);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(111, 28);
            this.button17.TabIndex = 2;
            this.button17.Text = "&Modify";
            this.button17.UseVisualStyleBackColor = false;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button18.Location = new System.Drawing.Point(14, 20);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(111, 28);
            this.button18.TabIndex = 0;
            this.button18.Text = "&Reset";
            this.button18.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button19.Location = new System.Drawing.Point(649, 20);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(111, 28);
            this.button19.TabIndex = 5;
            this.button19.Text = "E&xit";
            this.button19.UseVisualStyleBackColor = false;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button20.Location = new System.Drawing.Point(522, 20);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(111, 28);
            this.button20.TabIndex = 4;
            this.button20.Text = "&Save";
            this.button20.UseVisualStyleBackColor = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PrintSequenceNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "TestNo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SrNo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Identification Test";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ProcessDesc";
            this.dataGridViewTextBoxColumn3.HeaderText = "Min";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Process Description ";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Symb";
            this.dataGridViewTextBoxColumn4.HeaderText = "Max";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.ToolTipText = "Process Description ";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Accsessories";
            this.dataGridViewTextBoxColumn5.HeaderText = "TestNo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ToolTipText = "Process Description ";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Scrapper";
            this.dataGridViewTextBoxColumn6.HeaderText = "Control Test";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 250;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Impeller";
            this.dataGridViewTextBoxColumn7.HeaderText = "Min";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Emulsifer";
            this.dataGridViewTextBoxColumn8.HeaderText = "Max";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Vac";
            this.dataGridViewTextBoxColumn9.HeaderText = "TestNo";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Vac";
            this.dataGridViewTextBoxColumn10.HeaderText = "Identification Test";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 250;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Isupdate";
            this.dataGridViewTextBoxColumn11.HeaderText = "Min";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Isupdate";
            this.dataGridViewTextBoxColumn12.HeaderText = "Max";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "DetailID";
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
            // FrmMOMMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1257, 643);
            this.Controls.Add(this.panelOuter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMOMMaster";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOM Master";
            this.Load += new System.EventHandler(this.FrmFormulaMaster_Load);
            this.groupBox2.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelFill.PerformLayout();
            this.tabMom.ResumeLayout(false);
            this.MOMtab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.MOMPorcess.ResumeLayout(false);
            this.MOMPorcess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.MOMFooter.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveAsNew;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnModify;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
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
        private System.Windows.Forms.TabControl tabMom;
        private System.Windows.Forms.TabPage MOMtab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtISODocumentNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSHEAcceptedby;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUPAcceptedby;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIQAcceptedby;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtProductDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DateTimePicker DtpUPAcceptedDate;
        private System.Windows.Forms.DateTimePicker DtpIQDate;
        private System.Windows.Forms.DateTimePicker DtpSHEAcceptedDate;
        private System.Windows.Forms.TextBox txtReferenceDoc;
        private System.Windows.Forms.TextBox txtIQPreparedby;
        private System.Windows.Forms.TextBox txtBatchSize;
        private System.Windows.Forms.TabPage MOMPorcess;
        private System.Windows.Forms.TabPage MOMFooter;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtAdjustmentquantity;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckedListBox checkedListFormulano;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckedListBox checkedListAnnexTank;
        private System.Windows.Forms.CheckedListBox cheklistVessel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbMOMNo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cmbemulsifer;
        private System.Windows.Forms.ComboBox cmbImpeller;
        private System.Windows.Forms.ComboBox cmbScarpper;
        private System.Windows.Forms.ComboBox cmbdesc;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckedListBox checklistSafetysymbol;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtprocessdesc;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckedListBox checklistAccessory;
        private System.Windows.Forms.Button btntab2next;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btexit;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnPrevioustab3;
        private System.Windows.Forms.Button btnPrevioustab2;
        private System.Windows.Forms.ComboBox cmbVaC;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtPrintSquenceNo;
        private System.Windows.Forms.TextBox txtSrNo;
        private System.Windows.Forms.Label lblisupdate;
        private System.Windows.Forms.Label lblrowupdateID;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Button btcancel;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Label lblisnew;
        private Kairee.Editor.KaireeHTMLEditor kaireeHTMLEditor1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDeleteProcess;
        private System.Windows.Forms.Label lblDetailID;
        private System.Windows.Forms.CheckBox ChkSHE;
        private System.Windows.Forms.CheckBox ChkUp;
        private System.Windows.Forms.CheckBox ChkIndestrial;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtSerachMom;
        private System.Windows.Forms.ListBox List;
        private System.Windows.Forms.TextBox txtMomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintSequenceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn htmlProcessDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsNoteProSubPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcessDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accsessories;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scrapper;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impeller;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emulsifer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Isupdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dummysrno;
    }
}