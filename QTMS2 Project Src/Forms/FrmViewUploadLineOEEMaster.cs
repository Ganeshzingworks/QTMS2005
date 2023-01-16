using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Forms
{
	/// <summary>
	/// Summary description for FrmTestMaster.
	/// </summary>
	public class FrmViewUploadLineOEEMaster : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
		# region Varibles
        LineOEEFGMaster_Class LineOEEFGMaster_Class_obj = new LineOEEFGMaster_Class(); 	
			bool Modify=false;
		#endregion
        private System.Windows.Forms.Button BtnExit;
        private Panel panelFill;
        private Panel panelOuter;
        private Panel panelTop;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private Panel panelBottom;
        private ToolStripButton toolStripButtonClose;
        private Panel panel1;
        private ComboBox cmbFGCode;
        private Panel panel2;
        private Button btnShow;
        private DataGridView dgUploadLineOEE;
        private Button btnSave;
        private Button btnReset;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn FGCODE;
        private DataGridViewTextBoxColumn FAMILY;
        private DataGridViewTextBoxColumn YEARS;
        private DataGridViewTextBoxColumn MOD;
        private DataGridViewTextBoxColumn UST;
        private DataGridViewTextBoxColumn PRODUCTDESCRIPTION;
        private DataGridViewTextBoxColumn LINESPEED;
        private DataGridViewTextBoxColumn LINENOS;
        private DataGridViewTextBoxColumn UploadMasterID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmViewUploadLineOEEMaster()
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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
            FrmViewUploadLineOEEMaster_Obj = null;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgUploadLineOEE = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFGCode = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.panelFill = new System.Windows.Forms.Panel();
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
            this.FGCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAMILY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YEARS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTDESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINESPEED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LINENOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadMasterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUploadLineOEE)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(912, 270);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgUploadLineOEE);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(906, 194);
            this.panel2.TabIndex = 3;
            // 
            // dgUploadLineOEE
            // 
            this.dgUploadLineOEE.AllowUserToAddRows = false;
            this.dgUploadLineOEE.AllowUserToDeleteRows = false;
            this.dgUploadLineOEE.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUploadLineOEE.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgUploadLineOEE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUploadLineOEE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FGCODE,
            this.FAMILY,
            this.YEARS,
            this.MOD,
            this.UST,
            this.PRODUCTDESCRIPTION,
            this.LINESPEED,
            this.LINENOS,
            this.UploadMasterID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgUploadLineOEE.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgUploadLineOEE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUploadLineOEE.Location = new System.Drawing.Point(0, 0);
            this.dgUploadLineOEE.MultiSelect = false;
            this.dgUploadLineOEE.Name = "dgUploadLineOEE";
            this.dgUploadLineOEE.Size = new System.Drawing.Size(906, 194);
            this.dgUploadLineOEE.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbFGCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 48);
            this.panel1.TabIndex = 2;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnShow.Location = new System.Drawing.Point(567, 12);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 28);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "FG Code :";
            // 
            // cmbFGCode
            // 
            this.cmbFGCode.FormattingEnabled = true;
            this.cmbFGCode.Location = new System.Drawing.Point(347, 14);
            this.cmbFGCode.Name = "cmbFGCode";
            this.cmbFGCode.Size = new System.Drawing.Size(188, 24);
            this.cmbFGCode.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Location = new System.Drawing.Point(3, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(912, 48);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReset.Location = new System.Drawing.Point(283, 14);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 28);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Location = new System.Drawing.Point(383, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(480, 14);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 28);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panelFill
            // 
            this.panelFill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(918, 331);
            this.panelFill.TabIndex = 5;
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(920, 366);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(918, 30);
            this.panelTop.TabIndex = 41;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonClose});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(918, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(200, 27);
            this.toolStripLabel1.Text = "View Upload Line OEE Master";
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
            this.panelBottom.Size = new System.Drawing.Size(918, 331);
            this.panelBottom.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FGCODE";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(252)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "FGCODE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FAMILY";
            this.dataGridViewTextBoxColumn2.HeaderText = "FAMILY";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "YEARS";
            this.dataGridViewTextBoxColumn3.HeaderText = "YEARS";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "MOD";
            this.dataGridViewTextBoxColumn4.HeaderText = "MOD";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "UST";
            this.dataGridViewTextBoxColumn5.HeaderText = "UST";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PRODUCTDESCRIPTION";
            this.dataGridViewTextBoxColumn6.HeaderText = "PRODUCT DESC";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 180;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "LINESPEED";
            this.dataGridViewTextBoxColumn7.HeaderText = "LINE SPEED";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 110;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "LINENOS";
            this.dataGridViewTextBoxColumn8.HeaderText = "LINENOS";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "UploadMasterID";
            this.dataGridViewTextBoxColumn9.HeaderText = "UploadMasterID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 20;
            // 
            // FGCODE
            // 
            this.FGCODE.DataPropertyName = "FGCODE";
            this.FGCODE.HeaderText = "FGCODE";
            this.FGCODE.Name = "FGCODE";
            this.FGCODE.Width = 120;
            // 
            // FAMILY
            // 
            this.FAMILY.DataPropertyName = "FAMILY";
            this.FAMILY.HeaderText = "FAMILY";
            this.FAMILY.Name = "FAMILY";
            this.FAMILY.Width = 150;
            // 
            // YEARS
            // 
            this.YEARS.DataPropertyName = "YEARS";
            this.YEARS.HeaderText = "YEARS";
            this.YEARS.Name = "YEARS";
            this.YEARS.Width = 80;
            // 
            // MOD
            // 
            this.MOD.DataPropertyName = "MOD";
            this.MOD.HeaderText = "MOD";
            this.MOD.Name = "MOD";
            this.MOD.Width = 50;
            // 
            // UST
            // 
            this.UST.DataPropertyName = "UST";
            this.UST.HeaderText = "UST";
            this.UST.Name = "UST";
            this.UST.Width = 50;
            // 
            // PRODUCTDESCRIPTION
            // 
            this.PRODUCTDESCRIPTION.DataPropertyName = "PRODUCTDESCRIPTION";
            this.PRODUCTDESCRIPTION.HeaderText = "PRODUCT DESC";
            this.PRODUCTDESCRIPTION.Name = "PRODUCTDESCRIPTION";
            this.PRODUCTDESCRIPTION.Width = 180;
            // 
            // LINESPEED
            // 
            this.LINESPEED.DataPropertyName = "LINESPEED";
            this.LINESPEED.HeaderText = "LINE SPEED";
            this.LINESPEED.Name = "LINESPEED";
            this.LINESPEED.Width = 110;
            // 
            // LINENOS
            // 
            this.LINENOS.DataPropertyName = "LINENOS";
            this.LINENOS.HeaderText = "LINENOS";
            this.LINENOS.Name = "LINENOS";
            this.LINENOS.Width = 120;
            // 
            // UploadMasterID
            // 
            this.UploadMasterID.DataPropertyName = "UploadMasterID";
            this.UploadMasterID.HeaderText = "UploadMasterID";
            this.UploadMasterID.Name = "UploadMasterID";
            this.UploadMasterID.Visible = false;
            this.UploadMasterID.Width = 20;
            // 
            // FrmViewUploadLineOEEMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(920, 366);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmViewUploadLineOEEMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upload Line OEE Master";
            this.Load += new System.EventHandler(this.FrmViewUploadLineOEEMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUploadLineOEE)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private static Forms.FrmViewUploadLineOEEMaster FrmViewUploadLineOEEMaster_Obj = null;
        public static Forms.FrmViewUploadLineOEEMaster GetInstance()
        {
            if (FrmViewUploadLineOEEMaster_Obj  == null)
            {
                FrmViewUploadLineOEEMaster_Obj = new Forms.FrmViewUploadLineOEEMaster();
            }
            return FrmViewUploadLineOEEMaster_Obj;
        }

        private void FrmViewUploadLineOEEMaster_Load(object sender, EventArgs e)
        {
            //Painter.Paint(this);

            this.WindowState = FormWindowState.Normal;

            dgUploadLineOEE.DataSource = null;
            Bind_FGCode();
           
        }

        private void Bind_FGCode()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = LineOEEFGMaster_Class_obj.Select_LineOEEUploadMaster();
                DataRow dr;

                dr = dt.NewRow();
                dr["FGCODE"] = "-- Select --";
                dt.Rows.InsertAt(dr, 0);

                cmbFGCode.DataSource = dt;
                cmbFGCode.DisplayMember = "FGCODE";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                dgUploadLineOEE.DataSource = null;                
                
                if (cmbFGCode.Text == "-- Select --")
                {
                    
                    MessageBox.Show("Please select FG Code", "Line OEE Master", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                DataTable dt = new DataTable();
                LineOEEFGMaster_Class_obj.fgcode = cmbFGCode.Text.Trim();
                dt = LineOEEFGMaster_Class_obj.Select_LineOEEUploadMaster_FGCode();
                if (dt.Rows.Count > 0)
                {
                    dgUploadLineOEE.DataSource = dt;
                    dgUploadLineOEE.Columns["UploadMasterID"].Visible = false;
                    dgUploadLineOEE.Columns["FGCODE"].Width = 120;
                    dgUploadLineOEE.Columns["FAMILY"].Width = 150;
                    dgUploadLineOEE.Columns["YEARS"].Width = 80;
                    dgUploadLineOEE.Columns["MOD"].Width = 50;
                    dgUploadLineOEE.Columns["UST"].Width = 50;
                    dgUploadLineOEE.Columns["PRODUCTDESCRIPTION"].Width = 180;
                    dgUploadLineOEE.Columns["LINESPEED"].Width = 120;
                    dgUploadLineOEE.Columns["LINENOS"].Width = 110;
                    dgUploadLineOEE.Columns["UploadMasterID"].Width = 20;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbFGCode.Text = "-- Select --";
            dgUploadLineOEE.DataSource = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                for (int i = 0; i < dgUploadLineOEE.Rows.Count; i++)
                {
                    LineOEEFGMaster_Class_obj.uploadMasterID = Convert.ToInt64(dgUploadLineOEE["UploadMasterID", i].Value);
                    LineOEEFGMaster_Class_obj.fgcode = Convert.ToString(dgUploadLineOEE["FGCODE", i].Value);
                    LineOEEFGMaster_Class_obj.family = Convert.ToString(dgUploadLineOEE["FAMILY", i].Value);
                    LineOEEFGMaster_Class_obj.years = Convert.ToString(dgUploadLineOEE["YEARS", i].Value);
                    LineOEEFGMaster_Class_obj.mod = Convert.ToString(dgUploadLineOEE["MOD", i].Value);
                    LineOEEFGMaster_Class_obj.ust = Convert.ToString(dgUploadLineOEE["UST", i].Value);
                    LineOEEFGMaster_Class_obj.productDesc = Convert.ToString(dgUploadLineOEE["PRODUCTDESCRIPTION", i].Value);
                    LineOEEFGMaster_Class_obj.lineSpeed = Convert.ToString(dgUploadLineOEE["LINESPEED", i].Value);
                    LineOEEFGMaster_Class_obj.lineNos = Convert.ToString(dgUploadLineOEE["LINENOS", i].Value);
                    flag = LineOEEFGMaster_Class_obj.Update_LineOEEUploadMaster_UploadMasterID();
                    
                }
                //if (flag == true)
                MessageBox.Show("Record Updated successfully", "Upload Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //    MessageBox.Show("Record Not Updated successfully", "Upload Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnReset_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
	}
}
