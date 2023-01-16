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
	public class FrmBulkTechnicalFamilyMaster : System.Windows.Forms.Form
	{
        DataSet dsList = new DataSet();

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BtnSave;
		# region Varibles
			TestMaster_Class TestMaster_Class_Obj=new TestMaster_Class();
			BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj=new BulkFamilyMaster_Class();
			bool Modify=false;
		#endregion
		private System.Windows.Forms.Button BtnExit;
		private System.Windows.Forms.Button BtnReset;
		private System.Windows.Forms.Button BtnModify;
		private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.TextBox txtTechnicalFamily;
        private System.Windows.Forms.ListBox List;
        private Panel panelFill;
        private Panel panelOuter;
        private Panel panelTop;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private Panel panelBottom;
        private ToolStripButton toolStripButtonClose;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnExport;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmBulkTechnicalFamilyMaster()
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
            frmBulkTechnicalFamilyMaster_Obj = null;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBulkTechnicalFamilyMaster));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTechnicalFamily = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
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
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.txtTechnicalFamily);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(240, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtTechnicalFamily
            // 
            this.txtTechnicalFamily.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTechnicalFamily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTechnicalFamily.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTechnicalFamily.Location = new System.Drawing.Point(148, 86);
            this.txtTechnicalFamily.MaxLength = 50;
            this.txtTechnicalFamily.Name = "txtTechnicalFamily";
            this.txtTechnicalFamily.Size = new System.Drawing.Size(280, 22);
            this.txtTechnicalFamily.TabIndex = 4;
            this.txtTechnicalFamily.Leave += new System.EventHandler(this.txtTechnicalFamily_Leave);
            this.txtTechnicalFamily.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTechnicalFamily_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Technical Family";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExport.Location = new System.Drawing.Point(299, 16);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(70, 26);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnModify);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(240, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(151, 16);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(67, 26);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModify.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnModify.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnModify.Location = new System.Drawing.Point(75, 16);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(70, 26);
            this.BtnModify.TabIndex = 6;
            this.BtnModify.Text = "&Modify";
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnReset.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(9, 16);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(60, 26);
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
            this.BtnExit.Location = new System.Drawing.Point(375, 16);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(53, 26);
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
            this.BtnSave.Location = new System.Drawing.Point(224, 16);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(69, 26);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.Color.WhiteSmoke;
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.List.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.ItemHeight = 16;
            this.List.Location = new System.Drawing.Point(11, 71);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(219, 210);
            this.List.TabIndex = 2;
            this.List.DoubleClick += new System.EventHandler(this.LstTest_DoubleClick);
            this.List.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.List_KeyPress);
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
            this.panelFill.Size = new System.Drawing.Size(690, 300);
            this.panelFill.TabIndex = 5;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(8, 17);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 8;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(11, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(219, 23);
            this.txtSearch.TabIndex = 7;
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
            this.panelOuter.Size = new System.Drawing.Size(692, 333);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(690, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(690, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(198, 27);
            this.toolStripLabel1.Text = "Bulk Technical Family Master";
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
            this.panelBottom.Location = new System.Drawing.Point(0, 31);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(690, 300);
            this.panelBottom.TabIndex = 3;
            // 
            // FrmBulkTechnicalFamilyMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(692, 333);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBulkTechnicalFamilyMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bulk Technical Family Master";
            this.Load += new System.EventHandler(this.FrmTestMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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

        private static Forms.FrmBulkTechnicalFamilyMaster frmBulkTechnicalFamilyMaster_Obj = null;
        public static Forms.FrmBulkTechnicalFamilyMaster GetInstance()
        {
            if (frmBulkTechnicalFamilyMaster_Obj == null)
            {
                frmBulkTechnicalFamilyMaster_Obj = new Forms.FrmBulkTechnicalFamilyMaster();
            }
            return frmBulkTechnicalFamilyMaster_Obj;
        }

		private void FrmTestMaster_Load(object sender, System.EventArgs e)
		{
            Painter.Paint(this);

            this.WindowState = FormWindowState.Normal;
            txtTechnicalFamily.Focus();			
			Bind_List();
		}
		public void Bind_List()
		{
			
			dsList=BulkFamilyMaster_Class_Obj.Select_BulkFamilyMaster();
            List.DataSource = dsList.Tables[0];
			List.DisplayMember="FamilyDesc";
			List.ValueMember="TechFamNo";
		}
		

		private void BtnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(txtTechnicalFamily.Text.Trim()=="")
				{
					MessageBox.Show("Enter Family Name","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
					txtTechnicalFamily.Focus();
					return;

				}             
               
				if(Modify==false)
				{
					BulkFamilyMaster_Class_Obj.familyname=txtTechnicalFamily.Text;
					bool b=BulkFamilyMaster_Class_Obj.Insert_BulkFamilyMaster();
					if(b==true)
					{	
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTechnicalFamily.Text = "";
                        txtTechnicalFamily.Focus();
                        Bind_List();
					}
				}
				else
				{
					BulkFamilyMaster_Class_Obj.familyname = txtTechnicalFamily.Text.Trim();
					BulkFamilyMaster_Class_Obj.familyno = Convert.ToInt64(List.SelectedValue.ToString());
                    if (BulkFamilyMaster_Class_Obj.familyno == 0)
					{
						MessageBox.Show("Select Record From List","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
                    bool b = BulkFamilyMaster_Class_Obj.Update_tblblkfamilyMaster();
					if(b == true)
					{    
                        MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTechnicalFamily.Text = "";
                        txtTechnicalFamily.Focus();
                        Bind_List();

                        Modify = false;
					}
				}
			}
			catch
			{
				//MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTechnicalFamily.Focus();
			}
		}
        		

		private void LstTest_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
               // txtSearch.Text = Convert.ToString(List.Text);
                Modify = true;
                BtnDelete.Enabled = true;
                
                DataSet ds=new DataSet();
				BulkFamilyMaster_Class_Obj.familyno = Convert.ToInt64(List.SelectedValue.ToString());
                txtTechnicalFamily.Text = List.Text;
                //ds = BulkFamilyMaster_Class_Obj.Select_From_tblBlkTestMaster_By_FamilyNo();
				
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
			txtTechnicalFamily.Text="";
			txtTechnicalFamily.Focus();
            Modify = false;
		}

		private void BtnModify_Click(object sender, System.EventArgs e)
		{
			List.Enabled=true;
			Modify=true;
			LstTest_DoubleClick(sender,e);
			BtnDelete.Enabled =true;
		}

		private void BtnDelete_Click(object sender, System.EventArgs e)
		{
            try
            {
                
                    if (BulkFamilyMaster_Class_Obj.familyno != 0)
                    {
                        if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            BulkFamilyMaster_Class_Obj.familyno = Convert.ToInt64(List.SelectedValue.ToString());
                            bool b = BulkFamilyMaster_Class_Obj.Delete_tblblkfamilyMaster();
                            if (b == true)
                            {
                                MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtTechnicalFamily.Text = "";
                                txtTechnicalFamily.Focus();
                                BtnDelete.Enabled = false;
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

        private void txtTechnicalFamily_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTechnicalFamily_Leave(object sender, EventArgs e)
        {

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtTechnicalFamily.Text = textInfo.ToTitleCase(txtTechnicalFamily.Text);	

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "FamilyDesc like  '" + searchString + "%'  ";

            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "FamilyDesc";
            List.ValueMember = "TechFamNo";	
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    Modify = true;
                    BtnDelete.Enabled = true;

                    DataSet ds = new DataSet();
                    BulkFamilyMaster_Class_Obj.familyno = Convert.ToInt64(List.SelectedValue.ToString());
                    txtTechnicalFamily.Text = List.Text;
                    //ds = BulkFamilyMaster_Class_Obj.Select_From_tblBlkTestMaster_By_FamilyNo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                MessageBox.Show("This is last item", "QTMS");
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
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void List_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    Modify = true;
                    BtnDelete.Enabled = true;

                    //DataSet dsList = new DataSet();
                    BulkFamilyMaster_Class_Obj.familyno = Convert.ToInt64(List.SelectedValue.ToString());
                    txtTechnicalFamily.Text = List.Text;
                    //ds = BulkFamilyMaster_Class_Obj.Select_From_tblBlkTestMaster_By_FamilyNo();
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
                BulkFamilyMaster_Class objBulkFamilyMaster_Class = new BulkFamilyMaster_Class ();
                DataSet ds = new DataSet();
                ds = objBulkFamilyMaster_Class.Select_All_Record_tblblkfamilyMaster();

                ExportToExcel objExport = new ExportToExcel();
                objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        

       

        //bool checkFlag;
        //private void ChkTest_SelectedIndexChanged(object sender, EventArgs e)
        //{           
        //    try
        //    {
        //        if(e.Index == 0 && e.NewValue == CheckState.Checked)
        //        {
        //            if (ChkTest.SelectedItem.ToString() == "All")
        //            {
        //                checkFlag = true;  // Declare 'checkFlag' Globally and set its value to 'false'
        //                for (int i = 1; i < ChkTest.Items.Count; i++)
        //                {
        //                    ChkTest.SetItemCheckState(i, CheckState.Indeterminate);
        //                }
        //                checkFlag = false;
        //            }
        //        }
        //        else if (ChkTest.GetItemCheckState(0) == CheckState.Checked)
        //        {
        //            if(e.Index != 0 && checkFlag == false)
        //            {
        //                if(e.CurrentValue == CheckState.Indeterminate)
        //                {
        //                    e.NewValue = e.CurrentValue;
        //                }
        //            }
        //            else if(e.Index == 0)
        //            {
        //                checkFlag = true;
        //                for (int i = 1; i < ChkTest.Items.Count; i++)
        //                {
        //                    ChkTest.SetItemCheckState(i, CheckState.Unchecked);
        //                }
        //                checkFlag = false;
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        
        //}


        //private void ChkTest_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ChkTest.GetItemCheckState(ChkTest.SelectedIndex) == CheckState.Unchecked)
        //    {
        //        ChkTest.SetItemCheckState(ChkTest.SelectedIndex, CheckState.Checked);
        //    }
        //    else if (ChkTest.GetItemCheckState(ChkTest.SelectedIndex) == CheckState.Checked)
        //    {
        //        ChkTest.SetItemCheckState(ChkTest.SelectedIndex, CheckState.Unchecked);
        //    }
        //}

        

        //private void ChkTest_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    if (ChkTest.GetItemCheckState(ChkTest.SelectedIndex) == )
        //    {
        //        ChkTest.SetItemChecked(ChkTest.SelectedIndex, true);
        //    }
        //    else if (ChkTest.GetItemCheckState(ChkTest.SelectedIndex) == CheckState.Checked)
        //    {
        //        ChkTest.SetItemCheckState(ChkTest.SelectedIndex, CheckState.Unchecked);
        //    }
        //}

      

        //private void ChkTest_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    if (ChkTest.GetItemCheckState(ChkTest.SelectedIndex) == CheckState.Unchecked)
        //    {
        //        ChkTest.SetItemCheckState(ChkTest.SelectedIndex, CheckState.Checked);
        //    }
        //    else if (ChkTest.GetItemCheckState(ChkTest.SelectedIndex) == CheckState.Checked)
        //    {
        //        ChkTest.SetItemCheckState(ChkTest.SelectedIndex, CheckState.Unchecked);
        //    }
        //}     
	}
}
