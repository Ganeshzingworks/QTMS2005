using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Transactions
{
    /// <summary>
    /// Summary description for FrmTestMaster.
    /// </summary>
    public partial class FrmLineOEETransaction : System.Windows.Forms.Form
    {
        private Panel panelOuter;
        private Panel panelbottom;
        private Panel panelTop;
        private ToolStrip toolStrip_OEE;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButtonClose;
        private GroupBox groupBox1;
        private DataGridView dgLineOEE;
        private GroupBox groupBox2;
        private Label label1;
        private ComboBox cmbLineNo;
        private ComboBox cmbFGCode;
        private Label label3;
        private Label label2;
        private TextBox txtLineSpeed;
        private Label label4;
        private TextBox txtSTDMOD;
        private Label label5;
        private GroupBox groupBox3;
        private Button btnClose;
        private Button btnSave;
        private Label label6;
        private ComboBox cmbShift;
        private Button btnReset;
        private DateTimePicker dtpTransDate;
        private Label label7;
        private TextBox txtFormNumber;
        private Label lblProducedUnits;
        private Label lblLastShiftProducedUnit;
        private TextBox txtProducedUnits1stShift;
        private TextBox txtProducedUnits;
        private TextBox txtProducedUnitsShift2;
        private Label lblProducedUnitShift2;
        private Button btnClearGird;
        private Button btnEdit;
        private Label label8;
        private TextBox txtPhysicalFormNumber;
        private TextBox txtOpratorName;
        private Label label9;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmLineOEETransaction()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);

            FrmLineOEETransaction_Obj = null;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLineOEETransaction));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip_OEE = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelbottom = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClearGird = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgLineOEE = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOpratorName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtProducedUnits = new System.Windows.Forms.TextBox();
            this.txtProducedUnitsShift2 = new System.Windows.Forms.TextBox();
            this.txtProducedUnits1stShift = new System.Windows.Forms.TextBox();
            this.lblProducedUnits = new System.Windows.Forms.Label();
            this.lblProducedUnitShift2 = new System.Windows.Forms.Label();
            this.lblLastShiftProducedUnit = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpTransDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhysicalFormNumber = new System.Windows.Forms.TextBox();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.txtFormNumber = new System.Windows.Forms.TextBox();
            this.txtSTDMOD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLineSpeed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLineNo = new System.Windows.Forms.ComboBox();
            this.cmbFGCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip_OEE.SuspendLayout();
            this.panelbottom.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLineOEE)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelbottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(932, 536);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip_OEE);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(930, 30);
            this.panelTop.TabIndex = 42;
            // 
            // toolStrip_OEE
            // 
            this.toolStrip_OEE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip_OEE.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonClose});
            this.toolStrip_OEE.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip_OEE.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_OEE.Name = "toolStrip_OEE";
            this.toolStrip_OEE.Size = new System.Drawing.Size(930, 30);
            this.toolStrip_OEE.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(129, 27);
            this.toolStripLabel1.Text = "Line OEE Transaction";
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
            // panelbottom
            // 
            this.panelbottom.Controls.Add(this.groupBox3);
            this.panelbottom.Controls.Add(this.groupBox2);
            this.panelbottom.Controls.Add(this.groupBox1);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelbottom.Location = new System.Drawing.Point(0, 0);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(930, 534);
            this.panelbottom.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnClearGird);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(9, 470);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(906, 54);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(298, 13);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(82, 33);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClearGird
            // 
            this.btnClearGird.Location = new System.Drawing.Point(415, 13);
            this.btnClearGird.Name = "btnClearGird";
            this.btnClearGird.Size = new System.Drawing.Size(90, 33);
            this.btnClearGird.TabIndex = 1;
            this.btnClearGird.Text = "Clear Grid";
            this.btnClearGird.UseVisualStyleBackColor = true;
            this.btnClearGird.Click += new System.EventHandler(this.btnClearGird_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(533, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(984, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 33);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgLineOEE);
            this.groupBox2.Location = new System.Drawing.Point(6, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(909, 287);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shift Hours Details";
            // 
            // dgLineOEE
            // 
            this.dgLineOEE.AllowUserToAddRows = false;
            this.dgLineOEE.AllowUserToDeleteRows = false;
            this.dgLineOEE.AllowUserToResizeColumns = false;
            this.dgLineOEE.AllowUserToResizeRows = false;
            this.dgLineOEE.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgLineOEE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgLineOEE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLineOEE.Location = new System.Drawing.Point(227, 48);
            this.dgLineOEE.Name = "dgLineOEE";
            this.dgLineOEE.RowHeadersVisible = false;
            this.dgLineOEE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgLineOEE.Size = new System.Drawing.Size(455, 190);
            this.dgLineOEE.TabIndex = 43;
            this.dgLineOEE.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLineOEE_CellClick);
            this.dgLineOEE.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgLineOEE_EditingControlShowing);
            this.dgLineOEE.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLineOEE_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOpratorName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.txtProducedUnits);
            this.groupBox1.Controls.Add(this.txtProducedUnitsShift2);
            this.groupBox1.Controls.Add(this.txtProducedUnits1stShift);
            this.groupBox1.Controls.Add(this.lblProducedUnits);
            this.groupBox1.Controls.Add(this.lblProducedUnitShift2);
            this.groupBox1.Controls.Add(this.lblLastShiftProducedUnit);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpTransDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPhysicalFormNumber);
            this.groupBox1.Controls.Add(this.cmbShift);
            this.groupBox1.Controls.Add(this.txtFormNumber);
            this.groupBox1.Controls.Add(this.txtSTDMOD);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLineSpeed);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbLineNo);
            this.groupBox1.Controls.Add(this.cmbFGCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 141);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtOpratorName
            // 
            this.txtOpratorName.Location = new System.Drawing.Point(128, 76);
            this.txtOpratorName.Name = "txtOpratorName";
            this.txtOpratorName.Size = new System.Drawing.Size(339, 23);
            this.txtOpratorName.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 16);
            this.label9.TabIndex = 59;
            this.label9.Text = "Oprator Name";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(832, 105);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(71, 27);
            this.btnEdit.TabIndex = 58;
            this.btnEdit.Text = "Update";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtProducedUnits
            // 
            this.txtProducedUnits.Location = new System.Drawing.Point(842, 44);
            this.txtProducedUnits.Name = "txtProducedUnits";
            this.txtProducedUnits.Size = new System.Drawing.Size(61, 23);
            this.txtProducedUnits.TabIndex = 7;
            this.txtProducedUnits.Text = "0";
            this.txtProducedUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProducedUnits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProducedUnits_KeyPress);
            // 
            // txtProducedUnitsShift2
            // 
            this.txtProducedUnitsShift2.Enabled = false;
            this.txtProducedUnitsShift2.Location = new System.Drawing.Point(546, 110);
            this.txtProducedUnitsShift2.Name = "txtProducedUnitsShift2";
            this.txtProducedUnitsShift2.Size = new System.Drawing.Size(61, 23);
            this.txtProducedUnitsShift2.TabIndex = 57;
            this.txtProducedUnitsShift2.Text = "0";
            this.txtProducedUnitsShift2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProducedUnitsShift2.Visible = false;
            // 
            // txtProducedUnits1stShift
            // 
            this.txtProducedUnits1stShift.Enabled = false;
            this.txtProducedUnits1stShift.Location = new System.Drawing.Point(235, 107);
            this.txtProducedUnits1stShift.Name = "txtProducedUnits1stShift";
            this.txtProducedUnits1stShift.Size = new System.Drawing.Size(61, 23);
            this.txtProducedUnits1stShift.TabIndex = 57;
            this.txtProducedUnits1stShift.Text = "0";
            this.txtProducedUnits1stShift.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProducedUnits1stShift.Visible = false;
            // 
            // lblProducedUnits
            // 
            this.lblProducedUnits.AutoSize = true;
            this.lblProducedUnits.Location = new System.Drawing.Point(676, 47);
            this.lblProducedUnits.Name = "lblProducedUnits";
            this.lblProducedUnits.Size = new System.Drawing.Size(107, 16);
            this.lblProducedUnits.TabIndex = 56;
            this.lblProducedUnits.Text = "Produced Units";
            this.lblProducedUnits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProducedUnitShift2
            // 
            this.lblProducedUnitShift2.AutoSize = true;
            this.lblProducedUnitShift2.Location = new System.Drawing.Point(316, 110);
            this.lblProducedUnitShift2.Name = "lblProducedUnitShift2";
            this.lblProducedUnitShift2.Size = new System.Drawing.Size(156, 16);
            this.lblProducedUnitShift2.TabIndex = 56;
            this.lblProducedUnitShift2.Text = "Produced Units Shift 2";
            this.lblProducedUnitShift2.Visible = false;
            // 
            // lblLastShiftProducedUnit
            // 
            this.lblLastShiftProducedUnit.AutoSize = true;
            this.lblLastShiftProducedUnit.Location = new System.Drawing.Point(6, 110);
            this.lblLastShiftProducedUnit.Name = "lblLastShiftProducedUnit";
            this.lblLastShiftProducedUnit.Size = new System.Drawing.Size(156, 16);
            this.lblLastShiftProducedUnit.TabIndex = 56;
            this.lblLastShiftProducedUnit.Text = "Produced Units Shift 1";
            this.lblLastShiftProducedUnit.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(711, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 55;
            this.label8.Text = "Physical Form No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(488, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 16);
            this.label7.TabIndex = 55;
            this.label7.Text = "System Form No";
            // 
            // dtpTransDate
            // 
            this.dtpTransDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTransDate.Checked = false;
            this.dtpTransDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpTransDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTransDate.Location = new System.Drawing.Point(540, 11);
            this.dtpTransDate.Name = "dtpTransDate";
            this.dtpTransDate.ShowCheckBox = true;
            this.dtpTransDate.Size = new System.Drawing.Size(130, 23);
            this.dtpTransDate.TabIndex = 2;
            this.dtpTransDate.Value = new System.DateTime(2008, 1, 19, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 53;
            this.label6.Text = "Shift";
            // 
            // txtPhysicalFormNumber
            // 
            this.txtPhysicalFormNumber.Location = new System.Drawing.Point(837, 73);
            this.txtPhysicalFormNumber.Name = "txtPhysicalFormNumber";
            this.txtPhysicalFormNumber.Size = new System.Drawing.Size(69, 23);
            this.txtPhysicalFormNumber.TabIndex = 7;
            this.txtPhysicalFormNumber.Text = "0";
            this.txtPhysicalFormNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbShift
            // 
            this.cmbShift.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(75, 43);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(254, 24);
            this.cmbShift.TabIndex = 3;
            this.cmbShift.SelectionChangeCommitted += new System.EventHandler(this.cmbShift_SelectionChangeCommitted);
            this.cmbShift.SelectedValueChanged += new System.EventHandler(this.cmbShift_SelectedValueChanged);
            // 
            // txtFormNumber
            // 
            this.txtFormNumber.Enabled = false;
            this.txtFormNumber.Location = new System.Drawing.Point(610, 77);
            this.txtFormNumber.Name = "txtFormNumber";
            this.txtFormNumber.Size = new System.Drawing.Size(58, 23);
            this.txtFormNumber.TabIndex = 6;
            this.txtFormNumber.Text = "0";
            this.txtFormNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFormNumber.Leave += new System.EventHandler(this.txtFormNumber_Leave);
            this.txtFormNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFormNumber_KeyPress);
            // 
            // txtSTDMOD
            // 
            this.txtSTDMOD.Location = new System.Drawing.Point(466, 44);
            this.txtSTDMOD.Name = "txtSTDMOD";
            this.txtSTDMOD.Size = new System.Drawing.Size(45, 23);
            this.txtSTDMOD.TabIndex = 4;
            this.txtSTDMOD.Text = "0";
            this.txtSTDMOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSTDMOD.TextChanged += new System.EventHandler(this.txtSTDMOD_TextChanged);
            this.txtSTDMOD.Leave += new System.EventHandler(this.txtSTDMOD_Leave);
            this.txtSTDMOD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSTDMOD_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Standard MOD";
            // 
            // txtLineSpeed
            // 
            this.txtLineSpeed.Location = new System.Drawing.Point(622, 44);
            this.txtLineSpeed.Name = "txtLineSpeed";
            this.txtLineSpeed.Size = new System.Drawing.Size(48, 23);
            this.txtLineSpeed.TabIndex = 5;
            this.txtLineSpeed.Text = "0";
            this.txtLineSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLineSpeed.TextChanged += new System.EventHandler(this.txtLineSpeed_TextChanged);
            this.txtLineSpeed.Leave += new System.EventHandler(this.txtLineSpeed_Leave);
            this.txtLineSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLineSpeed_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Line Speed";
            // 
            // cmbLineNo
            // 
            this.cmbLineNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLineNo.FormattingEnabled = true;
            this.cmbLineNo.Location = new System.Drawing.Point(335, 11);
            this.cmbLineNo.Name = "cmbLineNo";
            this.cmbLineNo.Size = new System.Drawing.Size(154, 24);
            this.cmbLineNo.TabIndex = 1;
            this.cmbLineNo.SelectionChangeCommitted += new System.EventHandler(this.cmbLineNo_SelectionChangeCommitted);
            // 
            // cmbFGCode
            // 
            this.cmbFGCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFGCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFGCode.FormattingEnabled = true;
            this.cmbFGCode.Location = new System.Drawing.Point(75, 11);
            this.cmbFGCode.Name = "cmbFGCode";
            this.cmbFGCode.Size = new System.Drawing.Size(192, 24);
            this.cmbFGCode.TabIndex = 0;
            this.cmbFGCode.SelectionChangeCommitted += new System.EventHandler(this.cmbFGCode_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Line No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "FG Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(495, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // FrmLineOEETransaction
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(932, 536);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(941, 519);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.Name = "FrmLineOEETransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Line OEE Transaction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmLineOEETransaction_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip_OEE.ResumeLayout(false);
            this.toolStrip_OEE.PerformLayout();
            this.panelbottom.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgLineOEE)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        # region Varibles
        BusinessFacade.Transactions.OEETransactionTest_Class OEETransactionTest_Class_Obj = new BusinessFacade.Transactions.OEETransactionTest_Class();
        BusinessFacade.Transactions.LineOEETransaction LineOEETransaction_Obj = new BusinessFacade.Transactions.LineOEETransaction();
        bool Modify = false;
        LineOEEMachineMaster_Class LineOEEMachineMaster_Class_Obj = new LineOEEMachineMaster_Class();
        #endregion

        private static Transactions.FrmLineOEETransaction FrmLineOEETransaction_Obj = null;
        public static Transactions.FrmLineOEETransaction GetInstance()
        {
            if (FrmLineOEETransaction_Obj == null)
            {
                FrmLineOEETransaction_Obj = new Transactions.FrmLineOEETransaction();
            }
            return FrmLineOEETransaction_Obj;
        }

        private void FrmLineOEETransaction_Load(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            btnEdit.Visible = false;
            //lblProducedUnits.Text = lblProducedUnits.Text + " Shift 1 :";
            try
            {
                BindFGCode();
                BindLineNo();
                Bind_Shift();
                //BindGrid2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BindFGCode()
        {
            try
            {
                LineOEEFGMaster_Class LineOEEFGMaster_Class_Obj = new LineOEEFGMaster_Class();
                DataSet ds = new DataSet();
                ds = LineOEEFGMaster_Class_Obj.Select_From_tblLineOEEFGMaster();
                DataRow dr;
                dr = ds.Tables[0].NewRow();
                dr["FGCode"] = "--Select--";
                dr["FGNo"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cmbFGCode.DataSource = ds.Tables[0];
                cmbFGCode.DisplayMember = "FGCode";
                cmbFGCode.ValueMember = "FGNo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindLineNo()
        {
            try
            {
                LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
                DataSet ds = new DataSet();
                ds = LineMaster_Class_Obj.Select_LineMaster();
                DataRow dr;
                dr = ds.Tables[0].NewRow();
                dr["LineDesc"] = "--Select--";
                dr["LNo"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cmbLineNo.DataSource = ds.Tables[0];
                cmbLineNo.DisplayMember = "LineDesc";
                cmbLineNo.ValueMember = "LNo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Bind_Shift()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            BusinessFacade.Transactions.OEETransactionTest_Class OEETransactionTest_Class_Obj = new BusinessFacade.Transactions.OEETransactionTest_Class();
            ds = OEETransactionTest_Class_Obj.Select_tblOEEShiftMaster();
            dr = ds.Tables[0].NewRow();
            dr["ShiftDetails"] = "--Select--";
            dr["ShiftID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {

                cmbShift.DisplayMember = "ShiftDetails";
                cmbShift.ValueMember = "ShiftID";
                cmbShift.DataSource = ds.Tables[0];
            }
        }
        private void BindGrid()
        {
            try
            {
                dgLineOEE.Rows.Clear();
                //dgLineOEE.DataSource = null;
                dgLineOEE.Columns.Clear();
                int min = 0, hrs = 0;
                string hrUnit = "", Selected_shift = "";
                string[] shift_hrs;
                min = 5;
                if (Convert.ToInt32(cmbShift.SelectedValue) == 1)
                {
                    Selected_shift = cmbShift.Text;
                    Selected_shift = Selected_shift.Replace("SHIFT1 ", "");
                    shift_hrs = Selected_shift.Split(':');
                    hrs = Convert.ToInt32(shift_hrs[0].ToString());
                }
                else if (Convert.ToInt32(cmbShift.SelectedValue) == 2)
                {
                    Selected_shift = cmbShift.Text;
                    Selected_shift = Selected_shift.Replace("SHIFT2 ", "");
                    shift_hrs = Selected_shift.Split(':');
                    hrs = Convert.ToInt32(shift_hrs[0].ToString());
                }
                else if (Convert.ToInt32(cmbShift.SelectedValue) == 3)
                {
                    Selected_shift = cmbShift.Text;
                    Selected_shift = Selected_shift.Replace("SHIFT3 ", "");
                    shift_hrs = Selected_shift.Split(':');
                    hrs = Convert.ToInt32(shift_hrs[0].ToString());
                }
                else
                    hrs = 6;


                for (int i = 0; i <= 97; i++)
                {
                    DataGridViewColumn newCol = new DataGridViewColumn();

                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    newCol.CellTemplate = cell;

                    if (i == 0)
                    {
                        newCol.HeaderText = "Activity Name";

                        newCol.Name = "ActivityName";
                        newCol.Visible = true;
                        newCol.Width = 200;
                        newCol.ReadOnly = true;
                        newCol.Frozen = true;
                    }
                    else if (i == 97)
                    {
                        newCol.HeaderText = "Activity ID";
                        newCol.Name = "LineActivityID";
                        newCol.ReadOnly = true;
                        newCol.Visible = false;
                        newCol.Width = 100;
                    }
                    else
                    {
                        if (min > 55)
                        {
                            min = 0;
                            hrs = hrs + 1;
                            if (hrs >= 12 && hrs <= 24)
                                hrUnit = "PM";
                            else
                                hrUnit = "AM";

                            newCol.HeaderText = Convert.ToString(hrs + ":" + "0" + min);// + "" + hrUnit);
                            newCol.Name = "";
                            newCol.ReadOnly = true;
                            newCol.Visible = true;
                            newCol.Width = 47;
                            min = 5;
                            newCol.DividerWidth = 5;

                            //if (((hrs-1) % 2) == 0)
                            //    newCol.DefaultCellStyle.BackColor = Color.Orange;
                            //else
                            //    newCol.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else
                        {
                            if (hrs > 23) // If hours are greater than 23 then assign hrs value to 1
                                hrs = 0;
                            if (hrs >= 12 && hrs <= 24)
                                hrUnit = "PM";
                            else
                                hrUnit = "AM";

                            if (min == 5)
                                newCol.HeaderText = Convert.ToString(hrs + ":" + "0" + (min));// + "" + hrUnit);
                            else
                                newCol.HeaderText = Convert.ToString(hrs + ":" + (min));// + "" + hrUnit);
                            newCol.Name = "";
                            newCol.Visible = true;
                            newCol.ReadOnly = true;
                            newCol.Width = 42;
                            min = min + 5;

                            //if ((hrs % 2) == 0)
                            //    newCol.DefaultCellStyle.BackColor = Color.Orange;
                            //else
                            //    newCol.DefaultCellStyle.BackColor = Color.Yellow;

                        }

                    }
                    dgLineOEE.Columns.Add(newCol);

                }
                DataTable dt = new DataTable();

                dt = LineOEETransaction_Obj.SelectLineOEEActivityMaster();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgLineOEE.Rows.Add();
                        dgLineOEE["ActivityName", i].Value = Convert.ToString(dt.Rows[i]["ActivityName"]);
                        dgLineOEE["LineActivityID", i].Value = Convert.ToString(dt.Rows[i]["LineActivityID"]);
                    }
                }

                if (txtSTDMOD.Text.Trim() != "")
                {
                    for (int i = 0; i < dgLineOEE.Columns.Count - 2; i++)
                    {
                        dgLineOEE[i + 1, 0].Value = txtSTDMOD.Text.Trim();

                    }
                    for (int i = 0; i < dgLineOEE.Rows.Count - 1; i++)
                    {
                        dgLineOEE.Rows[i + 1].ReadOnly = true;
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private bool isValid()
        {
            if (cmbFGCode.Text.Trim() == "--Select--")
            {
                MessageBox.Show("Please select FG Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgLineOEE.ClearSelection();
                cmbFGCode.Focus();
                return false;
            }
            if (cmbLineNo.Text.Trim() == "--Select--")
            {
                MessageBox.Show("Please select Line", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgLineOEE.ClearSelection();
                cmbLineNo.Focus();
                return false;
            }
            if (dtpTransDate.Checked == false)
            {
                MessageBox.Show("Please select Transaction Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgLineOEE.ClearSelection();
                dtpTransDate.Focus();
                return false;
            }
            if (txtLineSpeed.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Line Speed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgLineOEE.ClearSelection();
                txtLineSpeed.Focus();
                return false;
            }
            if (txtSTDMOD.Text.Trim() == "0")
            {
                MessageBox.Show("Please enter mod", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgLineOEE.ClearSelection();
                txtSTDMOD.Focus();
                return false;
            }
            if (cmbShift.Text.Trim() == "--Select--")
            {
                MessageBox.Show("Please select Shift ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgLineOEE.ClearSelection();
                cmbShift.Focus();
                return false;
            }
            //if (value == 1)
            //{
            if (txtProducedUnits.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Produced Units", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgLineOEE.ClearSelection();
                txtProducedUnits.Focus();
                return false;
            }
            //}
            //else
            //{
            //    if (txtProducedUnits.Text.Trim() == "0")
            //    {
            //        MessageBox.Show("Please enter Produced Units", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        dgLineOEE.ClearSelection();
            //        txtProducedUnits.Focus();
            //        return false;
            //    }
            //}
            if (txtFormNumber.Text.Trim() == "0")
            {
                MessageBox.Show("Please enter Form Number", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgLineOEE.ClearSelection();
                txtFormNumber.Focus();
                return false;
            }
            if (txtOpratorName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Operator Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgLineOEE.ClearSelection();
                txtOpratorName.Focus();
                return false;
            }

            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbShift_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                //if (Convert.ToString(cmbShift.Text) != "--Select--" && Convert.ToString(cmbShift.Text) != "System.Data.DataRowView" && cmbShift.SelectedValue != null && Convert.ToString(cmbShift.SelectedValue) != "System.Data.DataRowView") //
                //    cmbShift_SelectionChangeCommitted(sender, e);
                //BindGrid();
                if (Convert.ToString(cmbShift.Text) != "--Select--" && cmbShift.SelectedValue != null)
                {
                    //cmbShift_SelectionChangeCommitted(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void dgLineOEE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex>1 && e.ColumnIndex == 1)
            //{
            //    if (e.KeyChar > 58 || e.KeyChar < 49)
            //    {
            //        //MessageBox.Show("Please Enter Number Only", "Error");
            //        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))// && e.KeyChar != '.')
            //        {
            //            e.Handled = true;
            //        }
            //    }
            //}
        }

        // Check already exist all data other than fg
        int gridcolFromNumber, gridcolToNumber = 0;

        string fgName, lineName, shiftName, transDate, colToTime = "";
        private bool CheckExistLineNumberDate()
        {

            LineOEETransaction_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
            LineOEETransaction_Obj.transDate = dtpTransDate.Value;
            LineOEETransaction_Obj.shiftID = Convert.ToInt32(cmbShift.SelectedValue);

            DataTable dtCheckFG = new DataTable();
            dtCheckFG = LineOEETransaction_Obj.Select_LineOEEDetails_Lno_TransDate_Shift();
            dgLineOEE.Enabled = true;
            // code check for fg change but all available
            foreach (DataRow drCheck in dtCheckFG.Rows)
            {
                if (Convert.ToInt64(cmbFGCode.SelectedValue) != Convert.ToInt64(drCheck["FGNo"]))
                {
                    FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
                    DataSet ds = new DataSet();
                    FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(drCheck["FGNo"]);
                    ds = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFgMaster_FGNo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        fgName = Convert.ToString(ds.Tables[0].Rows[0]["FGCode"]);
                    }

                    lineName = Convert.ToString(cmbLineNo.Text);
                    shiftName = Convert.ToString(cmbShift.Text);
                    shiftName = shiftName.Substring(0, 6);
                    transDate = Convert.ToString(dtpTransDate.Text);
                    DataTable dtCheckMax = new DataTable();
                    LineOEETransaction_Obj.detailID = Convert.ToInt64(drCheck["DetailID"]);
                    dtCheckMax = LineOEETransaction_Obj.Select_LineOEEComment();

                    if (dtCheckMax.Rows.Count > 0)
                    {
                        int colToNumberCheckMax, colFromNumberCheckMin = 0;
                        string selectCmd = "Min(colFromNumber)";
                        colFromNumberCheckMin = Convert.ToInt32((object)dtCheckMax.Compute(selectCmd, string.Empty));

                        string selectCommand1 = "Max(colToNumber)";
                        colToNumberCheckMax = Convert.ToInt32((object)dtCheckMax.Compute(selectCommand1, string.Empty));

                        if (gridcolFromNumber >= colFromNumberCheckMin && gridcolFromNumber <= colToNumberCheckMax || gridcolToNumber >= colFromNumberCheckMin && gridcolToNumber <= colToNumberCheckMax)
                        {
                            //dgLineOEE.Enabled = false;
                            txtFormNumber.Enabled = true;
                            //txtFormNumber.Text = "0";
                            //txtFormNumber.Focus();                                  

                            string selectCommand = "Max(LineActivityID)";
                            int lineID = Convert.ToInt32((object)dtCheckMax.Compute(selectCommand, string.Empty));

                            dgLineOEE.CurrentCell = dgLineOEE.Rows[lineID - 1].Cells[colToNumberCheckMax];
                            dgLineOEE.ClearSelection();
                            if (colToNumberCheckMax == 96)
                                colToTime = Convert.ToString(dgLineOEE.Columns[colToNumberCheckMax].HeaderText);
                            else
                                colToTime = Convert.ToString(dgLineOEE.Columns[colToNumberCheckMax + 1].HeaderText);
                            return true;
                        }
                    }

                }
            }
            return false;
        }


        private string colFromName, colToName;
        private int colFromNumber, colToNumber, shiftID;

        private void dgLineOEE_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //str1 = Convert.ToString(e.RowIndex + "," + e.ColumnIndex);
            //MessageBox.Show(e.ColumnIndex);

            //Comment by rohan
            //colFromName = Convert.ToString(dgLineOEE.Columns[e.ColumnIndex].HeaderText);
            //if (colFromName == "24:00")
            //    colFromName = "00:00";
            //colFromNumber = Convert.ToInt32(e.ColumnIndex);
            //gridcolFromNumber = colFromNumber;
        }
        List<int> RowIndexTracker = new List<int>();
        long detailID;
        

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void dgLineOEE_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    //if (e.RowIndex >= 0)
        //    //{
        //    //    if (RowIndexTracker.Contains(e.RowIndex))
        //    //    {
        //    //        RowIndexTracker.Remove(e.RowIndex);
        //    //        dgLineOEE.Rows[e.RowIndex].Selected = false;
        //    //    }
        //    //    else
        //    //    {
        //    //        RowIndexTracker.Add(e.RowIndex);
        //    //    }

        //    //    foreach (int index in RowIndexTracker)
        //    //    {
        //    //        dgLineOEE.Rows[index].Selected = true;
        //    //    }
        //    //}
        //}

        private void txtSTDMOD_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtSTDMOD.Text.Trim() != "")
            //    {
            //        for (int i = 0; i < dgLineOEE.Columns.Count - 2; i++)
            //        {
            //            dgLineOEE[i + 1, 0].Value = txtSTDMOD.Text.Trim();
            //        }
            //    }
            //    else
            //    {
            //        //txtSTDMOD.Text = "0";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    //throw;
            //}
        }

        private void txtSTDMOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only 0-9 
            if (e.KeyChar > 58 || e.KeyChar < 49)
            {
                //MessageBox.Show("Please Enter Number Only", "Error");
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))// && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))// && e.KeyChar != '.')
            //{
            //    e.Handled = true;
            //}
            //if ((sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}      
        }

        private void txtLineSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only 0-9 and dot(.)  not allowed
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))// && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }

        private void dgLineOEE_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

            //if (e.RowIndex != -1 && e.ColumnIndex != -1)
            //{
            //    if (dgLineOEE[e.ColumnIndex, e.RowIndex].Style.BackColor == Color.Red)
            //    {
            //        //dgLineOEE[e.ColumnIndex, e.RowIndex].ToolTipText = "Comment";
            //    }
            //}
        }
        private void Reset()
        {
            txtProducedUnits1stShift.Visible = false;
            lblLastShiftProducedUnit.Visible = false;
            lblProducedUnitShift2.Visible = false;
            txtProducedUnitsShift2.Visible = false;
            dtpTransDate.Checked = false;
            cmbFGCode.SelectedIndex = 0;
            cmbLineNo.SelectedIndex = 0;
            cmbShift.SelectedIndex = 0;
            txtSTDMOD.Text = "0";
            txtLineSpeed.Text = "0";
            txtFormNumber.Text = "0";
            txtProducedUnits.Text = "0";
            txtPhysicalFormNumber.Text = "0";
            txtOpratorName.Text = "";
            //BindGrid();
            dgLineOEE.Rows.Clear();
            dgLineOEE.Columns.Clear();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private bool CheckValid()
        {
            DataTable dt = new DataTable();
            if (cmbFGCode.Text.Trim() == "--Select--")
            {
                MessageBox.Show("Please select FG Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbFGCode.Focus();
                return false;
            }
            if (cmbLineNo.Text.Trim() == "--Select--")
            {
                MessageBox.Show("Please select Line", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbLineNo.Focus();
                return false;
            }
            if (dtpTransDate.Checked == false)
            {
                MessageBox.Show("Please select Transaction Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpTransDate.Focus();
                return false;
            }

            LineOEETransaction_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
            LineOEETransaction_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
            LineOEETransaction_Obj.transDate = dtpTransDate.Value;


            if (Convert.ToInt32(cmbShift.SelectedValue) == 2)
            {


                LineOEETransaction_Obj.shiftID = Convert.ToInt32(1);
                dt = LineOEETransaction_Obj.Select_LineOEEDetails();
                //check is present
                if (dt.Rows.Count > 0)
                {
                    LineOEETransaction_Obj.detailID = Convert.ToInt64(dt.Rows[0]["DetailID"]);
                    dt = LineOEETransaction_Obj.GetProducedUnitsByHours();
                    LineOEETransaction_Obj.detailID = new long();
                    //check is previous shift complete fill or not
                    if (Convert.ToInt32(dt.Rows.Count) == 0 || Convert.ToInt32(dt.Rows.Count) != 8)
                    {
                        dgLineOEE.Rows.Clear();
                        dgLineOEE.Columns.Clear();
                        btnEdit.Visible = false;
                        MessageBox.Show("Please fill previous shift data.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows.Count) == 0)
                    {
                        dgLineOEE.Rows.Clear();
                        dgLineOEE.Columns.Clear();
                        btnEdit.Visible = false;
                        MessageBox.Show("Please fill previous shift data.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

                return true;
            }
            if (Convert.ToInt32(cmbShift.SelectedValue) == 3)
            {
                LineOEETransaction_Obj.shiftID = Convert.ToInt32(2);
                dt = LineOEETransaction_Obj.Select_LineOEEDetails();
                //check is present
                if (dt.Rows.Count > 0)
                {
                    LineOEETransaction_Obj.detailID = Convert.ToInt64(dt.Rows[0]["DetailID"]);
                    dt = LineOEETransaction_Obj.GetProducedUnitsByHours();
                    LineOEETransaction_Obj.detailID = new long();
                    //check is previous shift complete fill or not
                    if (Convert.ToInt32(dt.Rows.Count) == 0 || Convert.ToInt32(dt.Rows.Count) != 8)
                    {
                        dgLineOEE.Rows.Clear();
                        dgLineOEE.Columns.Clear();
                        btnEdit.Visible = false;
                        MessageBox.Show("Please fill previous shift data.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(dt.Rows.Count) == 0)
                    {
                        dgLineOEE.Rows.Clear();
                        dgLineOEE.Columns.Clear();
                        btnEdit.Visible = false;
                        MessageBox.Show("Please fill previous shift data.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                return true;
            }
            return true;
        }
        private void cmbShift_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (CheckValid())
                {
                    txtProducedUnits1stShift.Visible = false;
                    lblLastShiftProducedUnit.Visible = false;
                    lblProducedUnitShift2.Visible = false;
                    txtProducedUnitsShift2.Visible = false;
                    txtSTDMOD.Text = "0";
                    txtLineSpeed.Text = "0";
                    txtFormNumber.Text = "0";
                    txtProducedUnits.Text = "0";
                    txtPhysicalFormNumber.Text = "0";
                    txtOpratorName.Text = "";


                    if (Convert.ToString(cmbShift.Text) != "--Select--") //
                    {
                        LineOEETransaction_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                        LineOEETransaction_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                        LineOEETransaction_Obj.transDate = dtpTransDate.Value;

                        DataTable dtForm = new DataTable();
                        dtForm = LineOEETransaction_Obj.Select_LineOEEDetails_FGNo_Lno_TransDate();
                        if (dtForm.Rows.Count > 0)
                        {
                            txtSTDMOD.Text = Convert.ToString(dtForm.Rows[0]["STDMOD"]);
                            txtLineSpeed.Text = Convert.ToString(dtForm.Rows[0]["LineSpeed"]);
                            txtFormNumber.Text = Convert.ToString(dtForm.Rows[0]["FormNumber"]);
                            txtPhysicalFormNumber.Text = Convert.ToString(dtForm.Rows[0]["PhysicalFormNumber"]);
                            //txtOpratorName.Text = Convert.ToString(dtForm.Rows[0]["Operator"]);
                            //txtProducedUnits.Text = Convert.ToString(dtForm.Rows[0]["ProducedUnit"]);
                            txtFormNumber.Enabled = false;
                            txtProducedUnits.Enabled = true;
                            txtLineSpeed.Enabled = true;
                            btnEdit.Visible = true;
                            detailID = Convert.ToInt64(dtForm.Rows[0]["DetailID"]);//added for demo
                        }
                        else
                        {
                            long formNo = LineOEETransaction_Obj.Select_tblLineOEEDetail_MaxNumber();
                            if (formNo > 0)
                                txtFormNumber.Text = Convert.ToString(formNo);
                            else
                                txtFormNumber.Text = "0";

                            //txtFormNumber.Enabled = true;
                            btnEdit.Visible = false;
                        }

                        LineOEETransaction_Obj.shiftID = Convert.ToInt32(cmbShift.SelectedValue);

                        #region old code
                        //DataTable dtCheckFG = new DataTable();
                        //dtCheckFG = LineOEETransaction_Obj.Select_LineOEEDetails_Lno_TransDate_Shift();
                        //dgLineOEE.Enabled = true;
                        //// code check for fg change but all available
                        //foreach (DataRow drCheck in dtCheckFG.Rows)
                        //{
                        //    if (Convert.ToInt64(cmbFGCode.SelectedValue) != Convert.ToInt64(drCheck["FGNo"]))
                        //    {
                        //        DataTable dtCheckMax = new DataTable();
                        //        LineOEETransaction_Obj.detailID = Convert.ToInt64(drCheck["DetailID"]);
                        //        dtCheckMax = LineOEETransaction_Obj.Select_LineOEEComment();

                        //        if (dtCheckMax.Rows.Count > 0)
                        //        {
                        //            int colToNumberCheckMax = 0;
                        //            string selectCommand1 = "Max(colToNumber)";
                        //            colToNumberCheckMax = Convert.ToInt32((object)dtCheckMax.Compute(selectCommand1, string.Empty));

                        //            if (colToNumberCheckMax == 96)
                        //            {
                        //                MessageBox.Show("Record already exist against Line no, Date & Shift. Please change line no & date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //                cmbFGCode_SelectionChangeCommitted(sender, e);
                        //                cmbFGCode.Focus();
                        //                return;
                        //            }
                        //            else
                        //            {                                   
                        //                //dgLineOEE.Enabled = false;
                        //                txtFormNumber.Enabled = true;
                        //                txtFormNumber.Text = "0";
                        //                //txtFormNumber.Focus();                                  

                        //                string selectCommand = "Max(LineActivityID)";
                        //                int lineID = Convert.ToInt32((object)dtCheckMax.Compute(selectCommand, string.Empty));

                        //                dgLineOEE.CurrentCell = dgLineOEE.Rows[lineID - 1].Cells[colToNumberCheckMax];
                        //                dgLineOEE.ClearSelection();
                        //                return;
                        //            }

                        //        }

                        //    }
                        //}              
                        #endregion
                        #region in use
                        DataTable dt = new DataTable();
                        DataTable dtComment = new DataTable();
                        dt = LineOEETransaction_Obj.Select_LineOEEDetails();
                        if (dt.Rows.Count > 0)
                        {
                            LineOEETransaction_Obj.detailID = Convert.ToInt64(dt.Rows[0]["DetailID"]);
                            txtSTDMOD.Text = Convert.ToString(dt.Rows[0]["STDMOD"]);
                            txtLineSpeed.Text = Convert.ToString(dt.Rows[0]["LineSpeed"]);
                            txtFormNumber.Text = Convert.ToString(dt.Rows[0]["FormNumber"]);
                            txtProducedUnits.Text = Convert.ToString(dt.Rows[0]["ProducedUnit"]);
                            txtOpratorName.Text = Convert.ToString(dt.Rows[0]["Operator"]);
                            BindGrid2();
                        }
                        else
                        {
                            //txtFormNumber.Text = "0";
                            txtProducedUnits.Text = "0";
                            BindGrid2();

                        }
                        // Lable name of produced unit
                        ProducedUnitShiftWise();
                        #endregion
                        #region For Binding Data
                        //DataTable dt = new DataTable();
                        //DataTable dtComment = new DataTable();
                        //dt = LineOEETransaction_Obj.Select_LineOEEDetails();
                        //if (dt.Rows.Count > 0)
                        //{
                        //    BindGrid2();
                        //    LineOEETransaction_Obj.detailID = Convert.ToInt64(dt.Rows[0]["DetailID"]);
                        //    txtSTDMOD.Text = Convert.ToString(dt.Rows[0]["STDMOD"]);
                        //    txtLineSpeed.Text = Convert.ToString(dt.Rows[0]["LineSpeed"]);
                        //    txtFormNumber.Text = Convert.ToString(dt.Rows[0]["FormNumber"]);
                        //    txtProducedUnits.Text = Convert.ToString(dt.Rows[0]["ProducedUnit"]);
                        //    txtOpratorName.Text = Convert.ToString(dt.Rows[0]["Operator"]);

                        //    dtComment = LineOEETransaction_Obj.Select_LineOEEComment();
                        //    foreach (DataRow dr in dtComment.Rows)
                        //    {
                        //        //LineOEETransaction_Obj.fromTime =Convert.ToDateTime(dr["FromTime"]);
                        //        //LineOEETransaction_Obj.toTime =Convert.ToDateTime( dr["ToTime"]);
                        //        LineOEETransaction_Obj.activityID = Convert.ToInt32(dr["LineActivityID"]);
                        //        string colFName = String.Format("{0:t}", dr["FromTime"]); 
                        //        string colTName =String.Format("{0:t}", dr["ToTime"]);

                        //        int colFNumber = Convert.ToInt32(dr["colFromNumber"]);
                        //        int colTNumber = Convert.ToInt32(dr["colToNumber"]);
                        //        int rowNumber = Convert.ToInt32(dr["LineActivityID"]);

                        //        for (int i = colFNumber; i <= colTNumber; i++)
                        //        {
                        //            if (rowNumber == 2)
                        //            {
                        //                dgLineOEE[i, rowNumber - 1].Style.BackColor = Color.GreenYellow;
                        //                dgLineOEE[i, 0].Value = Convert.ToString(dr["MOD"]);
                        //            }
                        //            else
                        //            {
                        //                dgLineOEE[i, rowNumber - 1].Style.BackColor = Color.Red;
                        //                dgLineOEE[i, rowNumber - 1].Value = Convert.ToString(dr["CommentDesc"]);
                        //                dgLineOEE[i, rowNumber - 1].ToolTipText = Convert.ToString(dr["CommentDesc"]);
                        //                dgLineOEE[i, rowNumber - 1].Selected = false;
                        //                dgLineOEE[i, 0].Value = Convert.ToString(dr["MOD"]);
                        //            }

                        //        }
                        //        //dgLineOEE[LineOEETransaction_Obj.fromTime, LineOEETransaction_Obj.activityID].Style.BackColor = Color.Red;
                        //    }
                        //    if (dtComment.Rows.Count > 0)
                        //    {
                        //        string selectCommand = "Max(LineActivityID)";
                        //        int lineID = Convert.ToInt32((object)dtComment.Compute(selectCommand, string.Empty));
                        //        string selectCommand1 = "Max(colToNumber)";
                        //        int colNum = Convert.ToInt32((object)dtComment.Compute(selectCommand1, string.Empty));
                        //        dgLineOEE.CurrentCell = dgLineOEE.Rows[lineID - 1].Cells[colNum];
                        //        dgLineOEE.ClearSelection();
                        //    }
                        //}
                        //else
                        //{
                        //    //txtFormNumber.Text = "0";
                        //    txtProducedUnits.Text = "0";
                        //    BindGrid2();
                        //}
                        //// Lable name of produced unit
                        //ProducedUnitShiftWise();
                        #endregion

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void ProducedUnitShiftWise()
        {
            try
            {
                if (Convert.ToInt32(cmbShift.SelectedValue) == 1)
                {
                    lblProducedUnits.Text = "Produced Units Shift 1 :";
                }
                else if (Convert.ToInt32(cmbShift.SelectedValue) == 2)
                {
                    lblProducedUnits.Text = "Produced Units Shift 2 :";
                    if (CheckValid())
                    {
                        LineOEETransaction_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                        LineOEETransaction_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                        LineOEETransaction_Obj.transDate = dtpTransDate.Value;
                        LineOEETransaction_Obj.shiftID = (Convert.ToInt32(cmbShift.SelectedValue) - 1);
                        DataTable dt1 = new DataTable();

                        dt1 = LineOEETransaction_Obj.Select_LineOEEDetails();
                        if (dt1.Rows.Count > 0)
                        {
                            txtProducedUnits1stShift.Visible = true;
                            lblLastShiftProducedUnit.Visible = true;
                            txtProducedUnits1stShift.Text = Convert.ToString(dt1.Rows[0]["ProducedUnit"]);
                        }
                    }
                }
                else
                {
                    lblProducedUnits.Text = "Produced Units Shift 3 :";
                    if (CheckValid())
                    {

                        LineOEETransaction_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                        LineOEETransaction_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                        LineOEETransaction_Obj.transDate = dtpTransDate.Value;
                        LineOEETransaction_Obj.shiftID = (Convert.ToInt32(cmbShift.SelectedValue) - 1);
                        DataTable dt2 = new DataTable();
                        DataTable dt3 = new DataTable();
                        dt2 = LineOEETransaction_Obj.Select_LineOEEDetails();
                        if (dt2.Rows.Count > 0)
                        {
                            lblProducedUnitShift2.Visible = true;
                            txtProducedUnitsShift2.Visible = true;

                            txtProducedUnitsShift2.Text = Convert.ToString(dt2.Rows[0]["ProducedUnit"]);
                        }

                        LineOEETransaction_Obj.shiftID = (Convert.ToInt32(cmbShift.SelectedValue) - 2);
                        dt3 = LineOEETransaction_Obj.Select_LineOEEDetails();
                        if (dt3.Rows.Count > 0)
                        {
                            txtProducedUnits1stShift.Visible = true;
                            lblLastShiftProducedUnit.Visible = true;
                            txtProducedUnits1stShift.Text = Convert.ToString(dt3.Rows[0]["ProducedUnit"]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void txtSTDMOD_TextChanged(object sender, EventArgs e)
        {
            txtSTDMOD_Leave(sender, e);
        }

        private void cmbLineNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbFGCode.Text.Trim() == "--Select--")
                {
                    MessageBox.Show("Please select FG Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbFGCode.Focus();
                    return;
                }
                txtProducedUnits1stShift.Visible = false;
                lblLastShiftProducedUnit.Visible = false;
                lblProducedUnitShift2.Visible = false;
                txtProducedUnitsShift2.Visible = false;
                dtpTransDate.Checked = false;
                btnEdit.Visible = false;
                cmbShift.SelectedIndex = 0;
                txtSTDMOD.Text = "0";
                txtLineSpeed.Text = "0";
                txtFormNumber.Text = "0";
                txtProducedUnits.Text = "0";
                txtPhysicalFormNumber.Text = "0";
                txtOpratorName.Text = "";
                dgLineOEE.Rows.Clear();
                dgLineOEE.Columns.Clear();
                DataTable dt = new DataTable();
                LineOEETransaction_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                LineOEETransaction_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                dt = LineOEETransaction_Obj.Select_LineOEEMaster();
                if (dt.Rows.Count > 0)
                {
                    txtSTDMOD.Text = Convert.ToString(dt.Rows[0]["StandardMOD"]);
                    txtLineSpeed.Text = Convert.ToString(dt.Rows[0]["LineSpeed"]);
                    if (Convert.ToString(dt.Rows[0]["LineSpeed"]) == "0")
                    {
                        txtLineSpeed.Enabled = true;
                    }
                    else
                    {
                        //txtLineSpeed.Enabled = false;
                    }
                }
                else
                {
                    txtSTDMOD.Text = "0";
                    txtLineSpeed.Text = "0";
                    txtLineSpeed.Enabled = true;

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLineSpeed_TextChanged(object sender, EventArgs e)
        {
            if (txtLineSpeed.Text.Trim() == "0")
            {
                txtLineSpeed.Enabled = true;
            }
            else
            {
                //txtLineSpeed.Enabled = false;
            }
        }

        private void cmbFGCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtProducedUnits1stShift.Visible = false;
            lblLastShiftProducedUnit.Visible = false;
            lblProducedUnitShift2.Visible = false;
            txtProducedUnitsShift2.Visible = false;
            dtpTransDate.Checked = false;
            btnEdit.Visible = false;
            cmbLineNo.SelectedIndex = 0;
            cmbShift.SelectedIndex = 0;
            txtSTDMOD.Text = "0";
            txtLineSpeed.Text = "0";
            txtFormNumber.Text = "0";
            txtProducedUnits.Text = "0";
            txtPhysicalFormNumber.Text = "0";
            txtOpratorName.Text = "";
            dgLineOEE.Rows.Clear();
            dgLineOEE.Columns.Clear();
        }

        private void txtProducedUnits_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only 0-9 and dot(.) not allowed
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))// && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }

        private void txtLineSpeed_Leave(object sender, EventArgs e)
        {
            if (txtLineSpeed.Text.Trim() == "0")
            {
                txtLineSpeed.Enabled = true;
            }
            else
            {
                //txtLineSpeed.Enabled = false;
            }
        }

        private void txtFormNumber_Leave(object sender, EventArgs e)
        {
            try
            {
                if (CheckValid())
                {
                    if (cmbShift.Text.Trim() == "--Select--")
                    {
                        MessageBox.Show("Please select Shift ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgLineOEE.ClearSelection();
                        cmbShift.Focus();
                        return;
                    }
                    if (txtFormNumber.Text.Trim() == "0")
                    {
                        MessageBox.Show("Please enter Form Number", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgLineOEE.ClearSelection();
                        txtFormNumber.Focus();
                        return;
                    }
                    LineOEETransaction_Obj.formNumber = Convert.ToInt64(txtFormNumber.Text.Trim());
                    DataTable dtFormNo = new DataTable();
                    dtFormNo = LineOEETransaction_Obj.Select_LineOEEDetails_FormNumber();

                    foreach (DataRow dr in dtFormNo.Rows)
                    {
                        if ((Convert.ToInt64(cmbFGCode.SelectedValue) == Convert.ToInt64(dr["FGNo"])) && (Convert.ToInt32(cmbLineNo.SelectedValue) == Convert.ToInt32(dr["LNo"])) && (string.Format("{0:d}", dtpTransDate.Value) == string.Format("{0:d}", Convert.ToDateTime(dr["TransDate"]))))
                        {
                            txtFormNumber.Text = Convert.ToString(dr["FormNumber"]);
                            //txtFormNumber.Enabled = false;
                        }
                        else
                        {
                            //txtFormNumber.Enabled = true;                       
                            MessageBox.Show("Form no already exist.Enter new form number", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFormNumber.Text = "0";
                            txtFormNumber.Focus();
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //               throw;
            }
        }

        private void btnClearGird_Click(object sender, EventArgs e)
        {
            if (CheckValid())
            {
                if (Convert.ToString(cmbShift.Text) != "--Select--") //
                {
                    DataTable dt = new DataTable();
                    LineOEETransaction_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                    LineOEETransaction_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                    LineOEETransaction_Obj.transDate = dtpTransDate.Value;
                    LineOEETransaction_Obj.shiftID = Convert.ToInt32(cmbShift.SelectedValue);
                    dt = LineOEETransaction_Obj.Select_LineOEEDetails();
                    if (dt.Rows.Count > 0)
                    {
                        bool flag;
                        LineOEETransaction_Obj.detailID = Convert.ToInt64(dt.Rows[0]["DetailID"]);
                        if (MessageBox.Show("Delete this Shift Record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            flag = LineOEETransaction_Obj.Delete_LineOEEComment_DetailID();
                            if (flag == true)
                            {
                                MessageBox.Show("Record clear successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmbShift_SelectionChangeCommitted(sender, e);
                            }
                        }
                    }
                }
            }
            cmbFGCode.Focus();
        }

        private void txtFormNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only 0-9 and dot(.) allowed
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                LineOEETransaction_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                LineOEETransaction_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                LineOEETransaction_Obj.transDate = dtpTransDate.Value;
                LineOEETransaction_Obj.shiftID = Convert.ToInt32(cmbShift.SelectedValue);
                dt = LineOEETransaction_Obj.Select_LineOEEDetails();
                if (dt.Rows.Count > 0)
                {

                    LineOEETransaction_Obj.detailID = Convert.ToInt64(dt.Rows[0]["DetailID"]);
                    LineOEETransaction_Obj.lineSpeed = Convert.ToDouble(txtLineSpeed.Text.Trim());
                    LineOEETransaction_Obj.producedUnits = Convert.ToDouble(txtProducedUnits.Text.Trim());
                    LineOEETransaction_Obj.physicalFormNumber = Convert.ToString(txtPhysicalFormNumber.Text);
                    LineOEETransaction_Obj.OperatorName = txtOpratorName.Text.Trim();
                    //LineOEETransaction_Obj.MaschineID = Convert.ToInt64(cmbMachineName.SelectedValue);
                    bool flag = LineOEETransaction_Obj.Update_LineOEEDeatails_LineSpeed_ProducedUnit();
                    if (flag == true)
                    {
                        MessageBox.Show("Record Updated successfully", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbShift_SelectionChangeCommitted(sender, e);
                    }
                    else
                        MessageBox.Show("Record Not Updated ", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Bindgrid for Hours shiftwise
        /// </summary>
        private void BindGrid2()
        {
            try
            {
                dgLineOEE.Rows.Clear();
                //dgLineOEE.DataSource = null;
                dgLineOEE.Columns.Clear();

                int min, hrs;
                string hrUnit = "", Selected_shift = "";
                string[] shift_hrs;
                min = 5;
                if (Convert.ToInt32(cmbShift.SelectedValue) == 1)
                {
                    Selected_shift = cmbShift.Text;
                    Selected_shift = Selected_shift.Replace("SHIFT1 ", "");
                    shift_hrs = Selected_shift.Split(':');
                    hrs = Convert.ToInt32(shift_hrs[0].ToString());
                }
                else if (Convert.ToInt32(cmbShift.SelectedValue) == 2)
                {
                    Selected_shift = cmbShift.Text;
                    Selected_shift = Selected_shift.Replace("SHIFT2 ", "");
                    shift_hrs = Selected_shift.Split(':');
                    hrs = Convert.ToInt32(shift_hrs[0].ToString());
                }
                else if (Convert.ToInt32(cmbShift.SelectedValue) == 3)
                {
                    Selected_shift = cmbShift.Text;
                    Selected_shift = Selected_shift.Replace("SHIFT3 ", "");
                    shift_hrs = Selected_shift.Split(':');
                    hrs = Convert.ToInt32(shift_hrs[0].ToString());
                }
                else
                    hrs = 6;


                //hrs = 14;
                //for (int i = 1; i <= 2; i++)
                //{
                //    DataGridViewColumn newCol = new DataGridViewColumn();
                //    DataGridViewCell cell = new DataGridViewTextBoxCell();
                //    newCol.CellTemplate = cell;
                //    dgLineOEE.Columns.Add(newCol);
                //}

                ///Bind data to grid
                DataTable dt = new DataTable();
                int h = hrs;
                int shifthours = 8;
                LineOEETransaction_Obj.shiftID = Convert.ToInt32(cmbShift.SelectedValue);
                dt = LineOEETransaction_Obj.GetProducedUnitsByHours();
                //if (dt.Rows.Count > 0)
                //{
                //dgLineOEE.Columns.Add("Status", "s");

                //Column ShiftHours
                dgLineOEE.Columns.Add("ShiftHrs", "ShiftHours");
                dgLineOEE.Columns["ShiftHrs"].MinimumWidth = 150;
                dgLineOEE.Columns["ShiftHrs"].DefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
                dgLineOEE.Columns["ShiftHrs"].DefaultCellStyle.ForeColor = Color.Black;
                dgLineOEE.Columns["ShiftHrs"].ReadOnly = true;
                //Column Produced Units
                dgLineOEE.Columns.Add("ProducedUnists", "Produced Units");
                dgLineOEE.Columns["ProducedUnists"].MinimumWidth = 150;
                dgLineOEE.Columns["ProducedUnists"].DefaultCellStyle.Font = new Font("Verdana", 10);
                dgLineOEE.Columns["ProducedUnists"].DefaultCellStyle.ForeColor = Color.Black;
                //Column ADD
                DataGridViewButtonColumn AddButton = new DataGridViewButtonColumn();
                AddButton.Name = "ADD";
                AddButton.Text = "Add/Update";
                AddButton.UseColumnTextForButtonValue = true;
                AddButton.Width = 150;
                AddButton.DefaultCellStyle.Font = new Font("Verdana", 10);
                AddButton.DefaultCellStyle.ForeColor = Color.Black;
                AddButton.DefaultCellStyle.BackColor = Color.White;

                if (dgLineOEE.Columns["ADD"] == null)
                {
                    dgLineOEE.Columns.Insert(2, AddButton);
                }
                //dgLineOEE.Columns.Insert(2, AddButton);
                for (int i = 0; i < shifthours; i++)
                {
                    string s = "";
                    if (h > 23)
                    {
                        h = 0;
                        s = h + "-" + (h + 1);
                    }
                    else
                    {
                        s = h + "-" + (h + 1);
                    }

                    if (i < dt.Rows.Count)
                    {
                        dgLineOEE.Rows.Add(Convert.ToString(s), (Convert.ToString(dt.Rows[i]["ProducedUnits"])));
                        //DataGridViewButtonCell btn = (DataGridViewButtonCell)dgLineOEE.Rows[i].Cells["ADD"];
                        //btn.ReadOnly = false;
                        dgLineOEE.Rows[i].Cells["ProducedUnists"].ReadOnly = false;
                        //dgLineOEE.Rows[i].Cells["ADD"].ReadOnly = false;
                    }
                    else
                    {
                        dgLineOEE.Rows.Add(Convert.ToString(s), "", "");
                        dgLineOEE.Rows[i].Cells["ProducedUnists"].ReadOnly = false;
                        //dgLineOEE.Rows[i].Cells["ADD"].ReadOnly = true;
                        //DataGridViewButtonCell btn = (DataGridViewButtonCell)dgLineOEE.Rows[i].Cells["ADD"];
                        //btn.ReadOnly = true;
                    }
                    h += 1;
                    //}
                    dgLineOEE.Columns["ShiftHrs"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgLineOEE.Columns["ShiftHrs"].ReadOnly = true;
                    dgLineOEE.Columns["ProducedUnists"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    //dgLineOEE.Columns["ProducedUnists"].ReadOnly = false;
                    dgLineOEE.Columns["ADD"].SortMode = DataGridViewColumnSortMode.NotSortable;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void BindGrid3(string str)
        {
            try
            {
                dgLineOEE.Rows.Clear();
                //dgLineOEE.DataSource = null;
                dgLineOEE.Columns.Clear();
                int min = 0, hrs = 0;
                string hrUnit = "", Selected_shift = "";
                string[] shift_hrs;
                min = 5;

                //
                Selected_shift = str.ToString();
                Selected_shift = Selected_shift.Replace("-", ":");
                shift_hrs = Selected_shift.Split(':');
                hrs = Convert.ToInt32(shift_hrs[0].ToString());


                for (int i = 0; i <= 13; i++)
                {
                    DataGridViewColumn newCol = new DataGridViewColumn();

                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    newCol.CellTemplate = cell;

                    if (i == 0)
                    {
                        newCol.HeaderText = "Activity Name";

                        newCol.Name = "ActivityName";
                        newCol.Visible = true;
                        newCol.Width = 200;
                        newCol.ReadOnly = true;
                        newCol.Frozen = true;
                    }
                    else if (i == 13)
                    {
                        newCol.HeaderText = "Activity ID";
                        newCol.Name = "LineActivityID";
                        newCol.ReadOnly = true;
                        newCol.Visible = false;
                        newCol.Width = 100;
                    }
                    else
                    {
                        if (min > 55)
                        {
                            min = 0;
                            hrs = hrs + 1;
                            if (hrs >= 12 && hrs <= 24)
                                hrUnit = "PM";
                            else
                                hrUnit = "AM";

                            newCol.HeaderText = Convert.ToString(hrs + ":" + "0" + min);// + "" + hrUnit);
                            newCol.Name = "";
                            newCol.ReadOnly = true;
                            newCol.Visible = true;
                            newCol.Width = 47;
                            min = 5;
                            newCol.DividerWidth = 5;

                            //if (((hrs-1) % 2) == 0)
                            //    newCol.DefaultCellStyle.BackColor = Color.Orange;
                            //else
                            //    newCol.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else
                        {
                            if (hrs > 23) // If hours are greater than 23 then assign hrs value to 1
                                hrs = 0;
                            if (hrs >= 12 && hrs <= 24)
                                hrUnit = "PM";
                            else
                                hrUnit = "AM";

                            if (min == 5)
                                newCol.HeaderText = Convert.ToString(hrs + ":" + "0" + (min));// + "" + hrUnit);
                            else
                                newCol.HeaderText = Convert.ToString(hrs + ":" + (min));// + "" + hrUnit);
                            newCol.Name = "";
                            newCol.Visible = true;
                            newCol.ReadOnly = true;
                            newCol.Width = 42;
                            min = min + 5;

                            //if ((hrs % 2) == 0)
                            //    newCol.DefaultCellStyle.BackColor = Color.Orange;
                            //else
                            //    newCol.DefaultCellStyle.BackColor = Color.Yellow;

                        }

                    }
                    dgLineOEE.Columns.Add(newCol);

                }
                DataTable dt = new DataTable();

                dt = LineOEETransaction_Obj.SelectLineOEEActivityMaster();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgLineOEE.Rows.Add();
                        dgLineOEE["ActivityName", i].Value = Convert.ToString(dt.Rows[i]["ActivityName"]);
                        dgLineOEE["LineActivityID", i].Value = Convert.ToString(dt.Rows[i]["LineActivityID"]);
                    }
                }

                if (txtSTDMOD.Text.Trim() != "")
                {
                    for (int i = 0; i < dgLineOEE.Columns.Count - 2; i++)
                    {
                        dgLineOEE[i + 1, 0].Value = txtSTDMOD.Text.Trim();

                    }
                    for (int i = 0; i < dgLineOEE.Rows.Count - 1; i++)
                    {
                        dgLineOEE.Rows[i + 1].ReadOnly = true;
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private void dgLineOEE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isValid())
            {
                if (validate(sender, e))
                {
                    LineOEETransaction_Obj.lineSpeed = Convert.ToDouble(txtLineSpeed.Text.Trim());
                    LineOEETransaction_Obj.mod = Convert.ToInt32(txtSTDMOD.Text.Trim());
                    LineOEETransaction_Obj.formNumber = Convert.ToInt64(txtFormNumber.Text.Trim());
                    LineOEETransaction_Obj.physicalFormNumber = Convert.ToString(txtPhysicalFormNumber.Text);
                    //LineOEETransaction_Obj.producedUnits = Convert.ToDouble(txtProducedUnits.Text.Trim());
                    LineOEETransaction_Obj.OperatorName = txtOpratorName.Text.Trim();

                    DataTable dt = new DataTable();
                    LineOEETransaction_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                    LineOEETransaction_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                    LineOEETransaction_Obj.transDate = dtpTransDate.Value;
                    LineOEETransaction_Obj.shiftID = Convert.ToInt32(cmbShift.SelectedValue);
                    string value = "";
                    //check if details present
                    dt = LineOEETransaction_Obj.Select_LineOEEDetails();
                    if (dt.Rows.Count > 0)
                    {
                        value = Convert.ToString(dgLineOEE[0, e.RowIndex].Value);
                        LineOEETransaction_Obj.detailID = Convert.ToInt64(dt.Rows[0]["DetailID"]);
                        detailID = LineOEETransaction_Obj.detailID;
                        //frmHourWiseActivity frmHourWiseActivity = new frmHourWiseActivity(value, Convert.ToInt32(cmbLineNo.SelectedValue), Convert.ToInt64(detailID), dtpTransDate.Value, Convert.ToInt32(txtSTDMOD.Text.Trim()), Convert.ToInt32(cmbShift.SelectedValue));
                        //frmHourWiseActivity.ShowDialog();
                    }
                    else
                    {
                        LineOEETransaction_Obj.detailID = LineOEETransaction_Obj.Insert_LineOEEDetails();
                        detailID = LineOEETransaction_Obj.detailID;
                        //object sender, DataGridViewCellEventArgs e
                        value = Convert.ToString(dgLineOEE[0, e.RowIndex].Value);
                        //frmHourWiseActivity frmHourWiseActivity = new frmHourWiseActivity(value, Convert.ToInt32(cmbLineNo.SelectedValue), Convert.ToInt64(detailID), dtpTransDate.Value, Convert.ToInt32(txtSTDMOD.Text.Trim()), Convert.ToInt32(cmbShift.SelectedValue));
                        //frmHourWiseActivity.ShowDialog();
                    }

                    string[] shift_hrs = value.ToString().Replace("-", ":").Split(':');
                    string fromTime = Convert.ToString(shift_hrs[0] + ":05");
                    string toTime = Convert.ToString(shift_hrs[1] + ":00");
                    DateTime dtFromTime, dtToTime;
                    if (Convert.ToInt32(cmbShift.SelectedValue) == 3)
                    {
                        //DateTime dt1 = Convert.ToDateTime(toTime);
                        //DateTime dt1 = Convert.ToDateTime(toTime);

                        //string strDateToTime = Convert.ToString(dt1);
                        ////Check AM for add new date of third shift
                        //if (strDateToTime.Contains("AM"))
                        //    dtToTime = (Convert.ToDateTime(toTime)).AddDays(1);
                        //else
                        //    dtToTime = Convert.ToDateTime(toTime);

                        if (toTime == "24:00")
                        {
                          //  DateTime dt1 = Convert.ToDateTime("00:00");
                            //dtToTime = (Convert.ToDateTime("00:00")).AddDays(1);

                            string strDateToTime = Convert.ToDateTime(dtpTransDate.Value).ToString("yyyy-MMM-dd ");
                            dtToTime = DateTime.Parse(strDateToTime + "00:00").AddDays(1);
                        }
                        else
                        {
                            //DateTime dt1 = Convert.ToDateTime(toTime);
                            //string strDateToTime = Convert.ToString(dt1);
                            ////Check AM for add new date of third shift
                            //if (strDateToTime.Contains("AM"))
                            //    dtToTime = (Convert.ToDateTime(toTime)).AddDays(1);
                            //else
                            //    dtToTime = Convert.ToDateTime(toTime);
                            string strDateToTime = Convert.ToDateTime(dtpTransDate.Value).ToString("yyyy-MMM-dd ");
                            dtToTime = DateTime.Parse(strDateToTime + toTime);

                            //Check AM for add new date of third shift
                            if (dtToTime.ToString().Contains("AM"))
                                dtToTime = (Convert.ToDateTime(dtToTime)).AddDays(1);
                            else
                                dtToTime = Convert.ToDateTime(dtToTime);
                        }


                        //DateTime dt2 = Convert.ToDateTime(fromTime);
                        //string strDateFromTime = Convert.ToString(dt2);
                        //if (strDateFromTime.Contains("AM"))
                        //    dtFromTime = (Convert.ToDateTime(fromTime)).AddDays(1);
                        //else
                        //    dtFromTime = Convert.ToDateTime(fromTime);

                        string strDate = Convert.ToDateTime(dtpTransDate.Value).ToString("yyyy-MMM-dd ");
                        dtFromTime = DateTime.Parse(strDate + fromTime);

                        if (dtFromTime.ToString().Contains("AM"))
                          dtFromTime = (Convert.ToDateTime(dtFromTime)).AddDays(1);
                        else
                          dtFromTime = Convert.ToDateTime(dtFromTime);

                    }
                    else
                    {
                        //dtFromTime = Convert.ToDateTime(fromTime);
                        //dtToTime = Convert.ToDateTime(toTime);
                        string st = Convert.ToDateTime(dtpTransDate.Value).ToString("yyyy-MMM-dd ");
                        dtFromTime = DateTime.Parse(st + fromTime);
                        dtToTime = DateTime.Parse(st + toTime); //Convert.ToDateTime(toTime);
                    }

                    LineOEETransaction_Obj.fromTime = dtFromTime;
                    LineOEETransaction_Obj.toTime = dtToTime;
                    LineOEETransaction_Obj.producedUnits = Convert.ToDouble(dgLineOEE[1, e.RowIndex].Value);
                    //Insert Or Update single hour details
                    LineOEETransaction_Obj.lineHrsId = LineOEETransaction_Obj.Insert_LineOEEHrs();

                    double count = 0;
                    for (int i = 0; i < dgLineOEE.Rows.Count; i++)
                    {
                        count += Convert.ToDouble((dgLineOEE[1, i].Value) == "" ? "0" : (dgLineOEE[1, i].Value));
                    }
                    LineOEETransaction_Obj.producedUnits = Convert.ToDouble(count);

                    //Update ProducedUnit count to wrt detailID
                    bool flag = LineOEETransaction_Obj.Update_LineOEEDeatails_LineSpeed_ProducedUnit();
                    LineOEETransaction_Obj.lineSpeed = Convert.ToDouble(txtLineSpeed.Text.Trim());
                    txtProducedUnits.Text = Convert.ToString(count);

                    frmHourWiseActivity frmHourWiseActivity = new frmHourWiseActivity(value, Convert.ToInt32(cmbLineNo.SelectedValue), Convert.ToInt64(detailID), dtpTransDate.Value, Convert.ToInt32(txtSTDMOD.Text.Trim()), Convert.ToInt32(cmbShift.SelectedValue), Convert.ToInt64(cmbFGCode.SelectedValue), Convert.ToDouble(LineOEETransaction_Obj.lineSpeed));
                    frmHourWiseActivity.ShowDialog();


                    #region parameters
                    //LineOEETransaction_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                    //LineOEETransaction_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                    //LineOEETransaction_Obj.transDate = dtpTransDate.Value;
                    //LineOEETransaction_Obj.lineSpeed = Convert.ToDouble(txtLineSpeed.Text.Trim());
                    //LineOEETransaction_Obj.mod = Convert.ToInt32(txtSTDMOD.Text.Trim());
                    //LineOEETransaction_Obj.shiftID = Convert.ToInt32(cmbShift.SelectedValue);
                    //LineOEETransaction_Obj.formNumber = Convert.ToInt64(txtFormNumber.Text.Trim());
                    //LineOEETransaction_Obj.physicalFormNumber = Convert.ToString(txtPhysicalFormNumber.Text);

                    //LineOEETransaction_Obj.producedUnits = Convert.ToDouble(txtProducedUnits.Text.Trim());
                    //LineOEETransaction_Obj.OperatorName = txtOpratorName.Text.Trim();

                    //detailID = 2926;

                    //U_Control.ucLineOEEShiftHrs objfrmLineOEEActivity = new U_Control.ucLineOEEShiftHrs();
                    //objfrmLineOEEActivity.Show();
                    //BindGrid3(value);
                    #endregion
                }
                else
                {

                }

            }
        }

        private void dgLineOEE_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 58 || e.KeyChar < 49)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))// && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                //if (e.KeyChar == '0' && (sender as TextBox).IndexOf('0') == 0)
                //{
                //    e.Handled = false;
                //}
                if ((sender as TextBox).Text == "" && e.KeyChar == '0')
                {
                    e.Handled = false;
                }
            }
        }

        private bool validate(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0 && e.RowIndex > -1)
            {
                if (e.ColumnIndex == 2 && e.RowIndex == 0)
                {
                    //for first Produced Unit cell
                    string prodUnit = Convert.ToString(dgLineOEE[1, e.RowIndex].Value);
                    if (!string.IsNullOrEmpty(prodUnit) && Convert.ToString(Convert.ToDouble(prodUnit)) != "0")
                    {
                        return true;
                    }
                }
                else
                {
                    //check previous Produced Unit cell
                    string prodUnit = Convert.ToString(dgLineOEE[1, e.RowIndex - 1].Value);
                    if (!string.IsNullOrEmpty(prodUnit))
                    {
                        //check current Produced Unit cell
                        prodUnit = Convert.ToString(dgLineOEE[1, e.RowIndex].Value);
                        if (!string.IsNullOrEmpty(prodUnit) && Convert.ToString(Convert.ToDouble(prodUnit)) != "0")
                        {
                            return true;
                        }
                    }
                }
            }

            MessageBox.Show("Enter produced units or fill the previous hrs data.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }
    }
}
