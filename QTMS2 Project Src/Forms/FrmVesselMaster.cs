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
	public class FrmVesselMaster : System.Windows.Forms.Form
	{

        DataSet dsList = new DataSet();
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox LstTest;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTestDescription;
		private System.Windows.Forms.Button BtnSave;	
		private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnDelete;
        private Panel panelOuter;
        private Panel panelFill;
        private Panel panelBottom;
        private Panel panelTop;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButtonClose;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnExport;
        private TextBox txtSWC;
        private Label label2;
        private TextBox txtVesselSize;
        private Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmVesselMaster()
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
            frmVesselMaster_Obj = null;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSWC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LstTest = new System.Windows.Forms.ListBox();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtVesselSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVesselSize);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSWC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTestDescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(265, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.TextChanged += new System.EventHandler(this.groupBox1_TextChanged);
            // 
            // txtSWC
            // 
            this.txtSWC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSWC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSWC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSWC.Location = new System.Drawing.Point(153, 86);
            this.txtSWC.MaxLength = 50;
            this.txtSWC.Name = "txtSWC";
            this.txtSWC.Size = new System.Drawing.Size(130, 23);
            this.txtSWC.TabIndex = 6;
            this.txtSWC.Text = "0";
            this.txtSWC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSWC_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "SWC";
            // 
            // txtTestDescription
            // 
            this.txtTestDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTestDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTestDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestDescription.Location = new System.Drawing.Point(153, 57);
            this.txtTestDescription.MaxLength = 50;
            this.txtTestDescription.Name = "txtTestDescription";
            this.txtTestDescription.Size = new System.Drawing.Size(280, 23);
            this.txtTestDescription.TabIndex = 4;
            this.txtTestDescription.Leave += new System.EventHandler(this.txtTestDescription_Leave);
            this.txtTestDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTestDescription_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Vessel Description";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(265, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 97);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExport.Location = new System.Drawing.Point(284, 34);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(71, 26);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(106, 34);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(66, 26);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(22, 34);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(61, 26);
            this.BtnReset.TabIndex = 5;
            this.BtnReset.Text = "&Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(372, 34);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(61, 26);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(194, 34);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(67, 26);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LstTest
            // 
            this.LstTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LstTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstTest.ItemHeight = 16;
            this.LstTest.Location = new System.Drawing.Point(19, 70);
            this.LstTest.Name = "LstTest";
            this.LstTest.Size = new System.Drawing.Size(220, 210);
            this.LstTest.TabIndex = 2;
            this.LstTest.SelectedIndexChanged += new System.EventHandler(this.LstTest_SelectedIndexChanged);
            this.LstTest.DoubleClick += new System.EventHandler(this.LstTest_DoubleClick);
            this.LstTest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstTest_KeyPress);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(738, 333);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(736, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(736, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(88, 27);
            this.toolStripLabel1.Text = "Vessel Master";
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
            this.panelBottom.Location = new System.Drawing.Point(0, 28);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(736, 303);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.LstTest);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(736, 303);
            this.panelFill.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(16, 19);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(19, 41);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // txtVesselSize
            // 
            this.txtVesselSize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtVesselSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVesselSize.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVesselSize.Location = new System.Drawing.Point(153, 115);
            this.txtVesselSize.MaxLength = 50;
            this.txtVesselSize.Name = "txtVesselSize";
            this.txtVesselSize.Size = new System.Drawing.Size(130, 23);
            this.txtVesselSize.TabIndex = 8;
            this.txtVesselSize.Text = "0";
            this.txtVesselSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Vessel Size";
            // 
            // FrmVesselMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(738, 333);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVesselMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vessel Master";
            this.Load += new System.EventHandler(this.FrmVesselMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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

        private static FrmVesselMaster frmVesselMaster_Obj = null;
        public static FrmVesselMaster GetInstance()
        {
            if (frmVesselMaster_Obj == null)
            {
                frmVesselMaster_Obj = new FrmVesselMaster();
            }
            return frmVesselMaster_Obj;
        }

        # region Varibles
        VesselMaster_Class VesselMaster_Class_Obj = new VesselMaster_Class();
        TankMaster_Class TankMaster_Class_Obj = new TankMaster_Class();
        bool Modify = false;
        # endregion

		private void FrmVesselMaster_Load(object sender, System.EventArgs e)
		{
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);


			txtTestDescription.Focus();
			Bind_List();
		}
		public void Bind_List()
		{
			try
			{
				
                dsList = VesselMaster_Class_Obj.Select_tblVesselMaster();

                LstTest.DataSource = dsList.Tables[0];
                LstTest.DisplayMember = "VslDesc";
                LstTest.ValueMember = "VesselNo";
					
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void BtnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTestDescription.Text.Trim() =="")
				{
					MessageBox.Show("Enter Line Name","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtTestDescription.Text = "";
                    txtTestDescription.Focus();
					return;

				}
                if (txtSWC.Text.Trim() == "")
                {
                    MessageBox.Show("Enter SWC value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSWC.Text = "0";
                    txtSWC.Focus();
                    return;

                }
                if (txtVesselSize.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Vessel size", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtVesselSize.Text = "0";
                    txtVesselSize.Focus();
                    return;

                }
                txtTestDescription_Leave(sender, e);
				if(Modify==false)
				{
					VesselMaster_Class_Obj.vesselname = txtTestDescription.Text.Trim();
                    VesselMaster_Class_Obj.swc = Convert.ToInt32(txtSWC.Text.Trim());
                    VesselMaster_Class_Obj.vesselsize = Convert.ToInt32(txtVesselSize.Text.Trim());
                    bool b = VesselMaster_Class_Obj.Insert_VesselMaster();
					if(b==true)
					{
						MessageBox.Show("Record Saved Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
						txtTestDescription.Text="";
                        txtSWC.Text = "0";
                        txtVesselSize.Text = "0";
						txtTestDescription.Focus();
						Bind_List();
					}
				}
				else
				{
                    VesselMaster_Class_Obj.vesselname = txtTestDescription.Text.Trim();
                    VesselMaster_Class_Obj.vesselno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                    VesselMaster_Class_Obj.swc = Convert.ToInt32(txtSWC.Text.Trim());
                    VesselMaster_Class_Obj.vesselsize = Convert.ToInt32(txtVesselSize.Text.Trim());
                    if (VesselMaster_Class_Obj.vesselno == 0)
					{
						MessageBox.Show("Select Record From List","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
                    bool b = VesselMaster_Class_Obj.Update_VesselMaster();
					if(b==true)
					{
						MessageBox.Show("Record Update Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
						txtTestDescription.Text="";
                        txtSWC.Text = "0";
                        txtVesselSize.Text = "0";
						txtTestDescription.Focus();
						Bind_List();
						
						Modify=false;
					}
				}
			}
			catch
			{
				//MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTestDescription.Focus();
			}
		}

		private void LstTest_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void LstTest_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
               // txtSearch.Text = Convert.ToString(LstTest.Text);
				//DataSet ds=new DataSet();
				VesselMaster_Class_Obj.vesselno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                DataSet ds = VesselMaster_Class_Obj.Select_tblVesselMaster_By_Vesselno();
                //txtTestDescription.Text = LstTest.Text;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTestDescription.Text = ds.Tables[0].Rows[0]["VslDesc"].ToString();
                    txtSWC.Text = ds.Tables[0].Rows[0]["SWC"].ToString();
                    txtVesselSize.Text = ds.Tables[0].Rows[0]["VesselValue"].ToString();
                }

                BtnDelete.Enabled = true;
                Modify = true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
            Bind_List();
            txtSearch.Text = "";
			txtTestDescription.Text="";
            txtSWC.Text = "0";
            txtVesselSize.Text = "0";
			txtTestDescription.Focus();
            Modify = false;
            BtnDelete.Enabled = false;
		}

		

		private void BtnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				VesselMaster_Class_Obj.vesselno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                
                if (VesselMaster_Class_Obj.vesselno > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = VesselMaster_Class_Obj.Delete_VesselMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTestDescription.Text = "";
                            txtTestDescription.Focus();
                            BtnDelete.Enabled = false;
                            Bind_List();
                            Modify = false;

                        }
                    }
                }
			}
			catch
			{
                MessageBox.Show("Sorry you can't Delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTestDescription.Focus();
                Modify = false;
			}
		}

        private void txtTestDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// Only 0-9 and a-z and A-Z allowed
            //if (e.KeyChar != Convert.ToChar(8))
            //{
            //    if (((e.KeyChar >= Convert.ToChar(48)) && (e.KeyChar <= Convert.ToChar(57))) || (e.KeyChar >= Convert.ToChar(65)) && (e.KeyChar <= Convert.ToChar(90)) || (e.KeyChar >= Convert.ToChar(97)) && (e.KeyChar <= Convert.ToChar(122)))
            //    {

            //    }
            //    else
            //    {
            //        e.Handled = true;
            //    }
            //}
        }

        private void txtTestDescription_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtTestDescription.Text = textInfo.ToTitleCase(txtTestDescription.Text);	

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
                string searchString = txtSearch.Text;
                dsList.Tables[0].DefaultView.RowFilter = "VslDesc like  '" + searchString + "%'";
                LstTest.DataSource = dsList.Tables[0];

                LstTest.DisplayMember = "VslDesc";
                LstTest.ValueMember = "VesselNo";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(LstTest.Text);
                    //DataSet ds=new DataSet();
                    VesselMaster_Class_Obj.vesselno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                    txtTestDescription.Text = LstTest.Text;
                    BtnDelete.Enabled = true;
                    Modify = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down)
                {
                    LstTest.Select();
                    LstTest.SelectedIndex = LstTest.SelectedIndex + 1;
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
                    LstTest.Select();
                    LstTest.SelectedIndex = LstTest.SelectedIndex - 1;
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

        private void LstTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(LstTest.Text);
                    //DataSet ds=new DataSet();
                    VesselMaster_Class_Obj.vesselno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                    txtTestDescription.Text = LstTest.Text;
                    BtnDelete.Enabled = true;
                    Modify = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            try
            {
                VesselMaster_Class objVesselMaster_Class = new VesselMaster_Class();
                DataSet ds = new DataSet();
                ds = objVesselMaster_Class.Select_All_Record_tblVesselMaster();
               
                 ExportToExcel objExport = new ExportToExcel();
                 objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSWC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
	}
}
