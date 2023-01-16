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
using System.IO;

namespace QTMS.Forms
{
	/// <summary>
	/// Summary description for FrmTestMaster.
	/// </summary>
	public class FrmSafetySymbol : System.Windows.Forms.Form
	{
        DataTable DtList = new DataTable();

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BtnSave;
		# region Varibles
            SafetySymbol_Class SafetySymbol_Class_obj = new SafetySymbol_Class();
			 //BulkFamilyMaster_Class_Obj=new BulkFamilyMaster_Class();
        string imagePath;
			bool Modify=false;
		#endregion
		private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnReset;
		private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.TextBox txtSafetySymbolName;
        private System.Windows.Forms.ListBox List;
        private Panel panelFill;
        private Panel panelOuter;
        private Panel panelTop;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private Panel panelBottom;
        private ToolStripButton toolStripButtonClose;
        private PictureBox picSafetyImage;
        private Button btnUploadImage;
        private RadioButton rdBtnAccessories;
        private RadioButton rdButtonSafety;
        private Label lblSearch;
        private TextBox txtSearch;
        private TextBox txtSafetySign;
        private Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmSafetySymbol()
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
            FrmSafetySymbol_Obj = null;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBtnAccessories = new System.Windows.Forms.RadioButton();
            this.rdButtonSafety = new System.Windows.Forms.RadioButton();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.picSafetyImage = new System.Windows.Forms.PictureBox();
            this.txtSafetySymbolName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.List = new System.Windows.Forms.ListBox();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.txtSafetySign = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSafetyImage)).BeginInit();
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
            this.groupBox1.Controls.Add(this.txtSafetySign);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rdBtnAccessories);
            this.groupBox1.Controls.Add(this.rdButtonSafety);
            this.groupBox1.Controls.Add(this.btnUploadImage);
            this.groupBox1.Controls.Add(this.picSafetyImage);
            this.groupBox1.Controls.Add(this.txtSafetySymbolName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(240, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 339);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rdBtnAccessories
            // 
            this.rdBtnAccessories.AutoSize = true;
            this.rdBtnAccessories.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnAccessories.Location = new System.Drawing.Point(306, 80);
            this.rdBtnAccessories.Name = "rdBtnAccessories";
            this.rdBtnAccessories.Size = new System.Drawing.Size(98, 20);
            this.rdBtnAccessories.TabIndex = 4;
            this.rdBtnAccessories.Text = "Accessories";
            this.rdBtnAccessories.UseVisualStyleBackColor = true;
            // 
            // rdButtonSafety
            // 
            this.rdButtonSafety.AutoSize = true;
            this.rdButtonSafety.Checked = true;
            this.rdButtonSafety.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdButtonSafety.Location = new System.Drawing.Point(181, 80);
            this.rdButtonSafety.Name = "rdButtonSafety";
            this.rdButtonSafety.Size = new System.Drawing.Size(63, 20);
            this.rdButtonSafety.TabIndex = 4;
            this.rdButtonSafety.TabStop = true;
            this.rdButtonSafety.Text = "Safety";
            this.rdButtonSafety.UseVisualStyleBackColor = true;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUploadImage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.Location = new System.Drawing.Point(49, 107);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(113, 29);
            this.btnUploadImage.TabIndex = 3;
            this.btnUploadImage.Text = "Upload Image";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // picSafetyImage
            // 
            this.picSafetyImage.Location = new System.Drawing.Point(181, 107);
            this.picSafetyImage.Name = "picSafetyImage";
            this.picSafetyImage.Size = new System.Drawing.Size(299, 226);
            this.picSafetyImage.TabIndex = 1;
            this.picSafetyImage.TabStop = false;
            // 
            // txtSafetySymbolName
            // 
            this.txtSafetySymbolName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSafetySymbolName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSafetySymbolName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSafetySymbolName.Location = new System.Drawing.Point(181, 25);
            this.txtSafetySymbolName.MaxLength = 50;
            this.txtSafetySymbolName.Name = "txtSafetySymbolName";
            this.txtSafetySymbolName.Size = new System.Drawing.Size(299, 22);
            this.txtSafetySymbolName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Safety Symbol Name :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(240, 365);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(500, 60);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(166, 16);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(80, 28);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(78, 16);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(80, 28);
            this.BtnReset.TabIndex = 2;
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
            this.BtnExit.Location = new System.Drawing.Point(342, 16);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(80, 28);
            this.BtnExit.TabIndex = 4;
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
            this.BtnSave.Location = new System.Drawing.Point(254, 16);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(80, 28);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.Color.WhiteSmoke;
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.List.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.FormattingEnabled = true;
            this.List.ItemHeight = 16;
            this.List.Location = new System.Drawing.Point(11, 71);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(219, 354);
            this.List.TabIndex = 0;
            this.List.DoubleClick += new System.EventHandler(this.List_DoubleClick);
            this.List.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.List_KeyPress);
            this.List.KeyDown += new System.Windows.Forms.KeyEventHandler(this.List_KeyDown);
            // 
            // panelFill
            // 
            this.panelFill.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.List);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(765, 449);
            this.panelFill.TabIndex = 5;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(11, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(54, 16);
            this.lblSearch.TabIndex = 14;
            this.lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(14, 43);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(216, 23);
            this.txtSearch.TabIndex = 13;
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
            this.panelOuter.Size = new System.Drawing.Size(767, 484);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(765, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(765, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(154, 27);
            this.toolStripLabel1.Text = "Safety Symbol Master";
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
            this.panelBottom.Size = new System.Drawing.Size(765, 449);
            this.panelBottom.TabIndex = 3;
            // 
            // txtSafetySign
            // 
            this.txtSafetySign.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSafetySign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSafetySign.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSafetySign.Location = new System.Drawing.Point(181, 53);
            this.txtSafetySign.MaxLength = 50;
            this.txtSafetySign.Name = "txtSafetySign";
            this.txtSafetySign.Size = new System.Drawing.Size(128, 22);
            this.txtSafetySign.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Safety Sign :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmSafetySymbol
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(767, 484);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSafetySymbol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Safety Symbol Master";
            this.Load += new System.EventHandler(this.FrmSafetySymbol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSafetyImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelFill.PerformLayout();
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private static Forms.FrmSafetySymbol FrmSafetySymbol_Obj = null;
        public static Forms.FrmSafetySymbol GetInstance()
        {
            if (FrmSafetySymbol_Obj  == null)
            {
                FrmSafetySymbol_Obj = new Forms.FrmSafetySymbol();
            }
            return FrmSafetySymbol_Obj;
        }
        public void Bind_List()
        {
            try
            {
               
                DtList = SafetySymbol_Class_obj.Select_SafetySymbol();

                List.DataSource = DtList;
                List.DisplayMember = "SymName";
                List.ValueMember = "SymID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
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

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            //picSafetyImage.Image.Dispose();
            txtSafetySymbolName.Text = "";
            txtSafetySign.Text = "";
            rdButtonSafety.Checked = true;
            picSafetyImage.Image = null;
            txtSafetySymbolName.Focus();
            List.SelectedValue = 0;
            imagePath = null;
            Modify = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSafetySymbolName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Symbol Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSafetySymbolName.Focus();
                    return;
                }
                if (rdButtonSafety.Checked)
                {
                    if (txtSafetySign.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter Safity Sign", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSafetySign.Focus();
                        return;
                    }
                }
                SafetySymbol_Class_obj.createdby = FrmMain.LoginID;
                SafetySymbol_Class_obj.modifiedby = FrmMain.LoginID;
                if (Modify)
                {
                    SafetySymbol_Class_obj.symname = txtSafetySymbolName.Text.Trim();
                    SafetySymbol_Class_obj.safetysign = txtSafetySign.Text.Trim();
                    SafetySymbol_Class_obj.symid = Convert.ToInt32(List.SelectedValue.ToString());
                    SafetySymbol_Class_obj.createdby = FrmMain.LoginID;
                    SafetySymbol_Class_obj.modifiedby = FrmMain.LoginID;
                    if (imagePath != null)
                        SafetySymbol_Class_obj.imagedata = ReadFile(imagePath);
                    else
                    {
                        DataTable Dt = new DataTable();
                        SafetySymbol_Class_obj.symid = Convert.ToInt32(List.SelectedValue.ToString());
                        Dt = SafetySymbol_Class_obj.Select_SafetySymbol_SymID();
                        if (Dt.Rows.Count>0)
                            SafetySymbol_Class_obj.imagedata = (byte[])Dt.Rows[0]["SymImage"];
                    }
                    if(rdButtonSafety.Checked)
                        SafetySymbol_Class_obj.safetyacc = 'S';
                    else
                        SafetySymbol_Class_obj.safetyacc = 'A';

                    if (SafetySymbol_Class_obj.symid == 0)
                    {
                        MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        bool b = SafetySymbol_Class_obj.Update_SafetySymbol();
                        if (b == true)
                        {
                            MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtSafetySymbolName.Text = "";
                            txtSafetySymbolName.Focus();
                            Bind_List();
                            BtnReset_Click(sender, e);
                            Modify = false;
                        }
                    }
                   
                }
                else
                {
                    SafetySymbol_Class_obj.symname = txtSafetySymbolName.Text.Trim();
                    SafetySymbol_Class_obj.safetysign = txtSafetySign.Text.Trim();
                    //SafetySymbol_Class_obj.symid = Convert.ToInt32(List.SelectedValue.ToString());
                    if (imagePath != null)
                        SafetySymbol_Class_obj.imagedata = ReadFile(imagePath);
                    else
                    {
                        byte[] img = null;
                        SafetySymbol_Class_obj.imagedata = img;
                    }
                    if (rdButtonSafety.Checked)
                        SafetySymbol_Class_obj.safetyacc = 'S';
                    else
                        SafetySymbol_Class_obj.safetyacc = 'A';

                    bool b = SafetySymbol_Class_obj.Insert_SafetySymbol();
                    if (b == true)
                    {
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSafetySymbolName.Text = "";
                        txtSafetySymbolName.Focus();
                        BtnReset_Click(sender, e);
                        Bind_List();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtSafetySymbolName.Focus();
                //throw;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (SafetySymbol_Class_obj.symid != 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SafetySymbol_Class_obj.symid = Convert.ToInt32(List.SelectedValue.ToString());
                        bool b = SafetySymbol_Class_obj.Delete_SafetySymbol();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtSafetySymbolName.Text = "";
                            txtSafetySymbolName.Focus();
                            BtnDelete.Enabled = false;
                            BtnReset_Click(sender,e);
                            Bind_List();                            
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Can't delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               // txtSearch.Text = Convert.ToString(List.Text);
                Modify = true;
                BtnDelete.Enabled = true;
                DataTable Dt = new DataTable();
                SafetySymbol_Class_obj.symid = Convert.ToInt32(List.SelectedValue.ToString());
                Dt = SafetySymbol_Class_obj.Select_SafetySymbol_SymID();
                if (Dt.Rows.Count > 0)
                {
                    txtSafetySymbolName.Text = Convert.ToString(Dt.Rows[0]["SymName"]);
                    txtSafetySign.Text = Convert.ToString(Dt.Rows[0]["Safetysign"]);
                    if (Convert.ToString(Dt.Rows[0]["SafetyAcc"]) == "S")
                        rdButtonSafety.Checked = true;
                    else if (Convert.ToString(Dt.Rows[0]["SafetyAcc"]) == "A")
                        rdBtnAccessories.Checked = true;
                    if (picSafetyImage.Image != null)
                    {
                        picSafetyImage.Image.Dispose();
                       
                    }
                    if (Dt.Rows[0]["SymImage"].ToString() != null && Dt.Rows[0]["SymImage"].ToString() != "")
                    {
                        Byte[] img = (byte[])Dt.Rows[0]["SymImage"];
                        MemoryStream ms = new MemoryStream(img);


                        picSafetyImage.Image = Image.FromStream(ms);
                    }
                    //picSafetyImage.Image = Convert.ToByte(Dt.Rows[0]["SymImage"]);
                }
                //txtSafetySymbolName.Text = List.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void List_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue  == 13)
            {
                List_DoubleClick(sender, e);
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            try
            {
                imagePath = null;
                OpenFileDialog FileDialog = new OpenFileDialog();
                FileDialog.Filter = "JPEG Image (*.jpg)|*.jpg|All (*.*)|*.*";
                if (DialogResult.OK == FileDialog.ShowDialog())
                {
                    imagePath = FileDialog.FileName;
                    picSafetyImage.Load(imagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private byte[] ReadFile(string sPath)
        {
            byte[] data = null;

            //Use FileInfo to get file size
            FileInfo fInfo = new FileInfo(sPath);

            long numBytes = fInfo.Length;

            // Open fileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            // Use BinaryReader to read the data into bytearray
            BinaryReader br = new BinaryReader(fStream);

            data = br.ReadBytes((int)numBytes);

            return data;             
        }

        private void FrmSafetySymbol_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            this.WindowState = FormWindowState.Normal;
            txtSafetySymbolName.Focus();
            Bind_List();
            List.SelectedValue = 0;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            DtList.DefaultView.RowFilter = "SymName like  '" + searchString + "%'";
            List.DataSource = DtList ;

            List.DisplayMember = "SymName";
            List.ValueMember = "SymID";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                try
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    Modify = true;
                    BtnDelete.Enabled = true;
                    DataTable Dt = new DataTable();
                    SafetySymbol_Class_obj.symid = Convert.ToInt32(List.SelectedValue.ToString());
                    Dt = SafetySymbol_Class_obj.Select_SafetySymbol_SymID();
                    if (Dt.Rows.Count > 0)
                    {
                        txtSafetySymbolName.Text = Convert.ToString(Dt.Rows[0]["SymName"]);
                        if (Convert.ToString(Dt.Rows[0]["SafetyAcc"]) == "S")
                            rdButtonSafety.Checked = true;
                        else if (Convert.ToString(Dt.Rows[0]["SafetyAcc"]) == "A")
                            rdBtnAccessories.Checked = true;
                        if (picSafetyImage.Image != null)
                        {
                            picSafetyImage.Image.Dispose();

                        }
                        if (Dt.Rows[0]["SymImage"].ToString() != null && Dt.Rows[0]["SymImage"].ToString() != "")
                        {
                            Byte[] img = (byte[])Dt.Rows[0]["SymImage"];
                            MemoryStream ms = new MemoryStream(img);


                            picSafetyImage.Image = Image.FromStream(ms);
                        }
                        //picSafetyImage.Image = Convert.ToByte(Dt.Rows[0]["SymImage"]);
                    }
                    //txtSafetySymbolName.Text = List.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down)
                {
                    List.Select();
                    List.SelectedIndex = List.SelectedIndex + 1;
                }
            }
            catch (ArgumentOutOfRangeException exAOR)
            {

                MessageBox.Show("This is last item", "QTMS");
                //   MessageBox.Show("This is last item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Up)
                {
                    List.Select();
                    List.SelectedIndex = List.SelectedIndex - 1;
                }
            }
            catch (ArgumentOutOfRangeException exAOR)
            {
                //  MessageBox.Show("This is last item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("This is last item", "QTMS");
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void List_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    Modify = true;
                    BtnDelete.Enabled = true;
                    DataTable Dt = new DataTable();
                    SafetySymbol_Class_obj.symid = Convert.ToInt32(List.SelectedValue.ToString());
                    Dt = SafetySymbol_Class_obj.Select_SafetySymbol_SymID();
                    if (Dt.Rows.Count > 0)
                    {
                        txtSafetySymbolName.Text = Convert.ToString(Dt.Rows[0]["SymName"]);
                        if (Convert.ToString(Dt.Rows[0]["SafetyAcc"]) == "S")
                            rdButtonSafety.Checked = true;
                        else if (Convert.ToString(Dt.Rows[0]["SafetyAcc"]) == "A")
                            rdBtnAccessories.Checked = true;
                        if (picSafetyImage.Image != null)
                        {
                            picSafetyImage.Image.Dispose();

                        }
                        if (Dt.Rows[0]["SymImage"].ToString() != null && Dt.Rows[0]["SymImage"].ToString() != "")
                        {
                            Byte[] img = (byte[])Dt.Rows[0]["SymImage"];
                            MemoryStream ms = new MemoryStream(img);


                            picSafetyImage.Image = Image.FromStream(ms);
                        }
                        //picSafetyImage.Image = Convert.ToByte(Dt.Rows[0]["SymImage"]);
                    }
                    //txtSafetySymbolName.Text = List.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

  
	}
}
