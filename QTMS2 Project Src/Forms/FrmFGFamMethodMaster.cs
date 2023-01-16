using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BusinessFacade;
using QTMS.Tools;

namespace QTMS.Forms
{
	/// <summary>
	/// Summary description for FrmTestMaster.
	/// </summary>
	public class FrmFgFamMethodMaster : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BtnSave;
		# region Varibles

            FgFamilyMethodMaster_Class FgFamilyMethodMaster_Class_Obj = new FgFamilyMethodMaster_Class();
            FGTestMaster_Class FGTestMaster_Class_Obj = new FGTestMaster_Class();
            TestMaster_Class TestMaster_Class_Obj=new TestMaster_Class();
			BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj=new BulkFamilyMaster_Class();
            PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new PackingFamilyMaster_Class();
			bool Modify=false;
		#endregion
		private System.Windows.Forms.Button BtnExit;
		private System.Windows.Forms.Button BtnReset;
		private System.Windows.Forms.Button BtnModify;
        private System.Windows.Forms.Button BtnDelete;
		private System.Windows.Forms.CheckedListBox ChkTest;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox List;
        private ComboBox txtTechnicalFamily;
        private Panel panelOuter;
        private Panel panelBottom;
        private Panel panelTop;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private Panel panelFill;
        private ToolStripButton toolStripButtonClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmFgFamMethodMaster()
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
            FrmFgFamMethodMaster_Obj = null;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTechnicalFamily = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkTest = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.List = new System.Windows.Forms.ListBox();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
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
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtTechnicalFamily);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ChkTest);
            this.groupBox1.Location = new System.Drawing.Point(215, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtTechnicalFamily
            // 
            this.txtTechnicalFamily.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTechnicalFamily.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTechnicalFamily.FormattingEnabled = true;
            this.txtTechnicalFamily.Location = new System.Drawing.Point(200, 40);
            this.txtTechnicalFamily.Name = "txtTechnicalFamily";
            this.txtTechnicalFamily.Size = new System.Drawing.Size(280, 24);
            this.txtTechnicalFamily.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Applicable Test";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Technical Family";
            // 
            // ChkTest
            // 
            this.ChkTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ChkTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChkTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkTest.Location = new System.Drawing.Point(200, 80);
            this.ChkTest.Name = "ChkTest";
            this.ChkTest.Size = new System.Drawing.Size(280, 56);
            this.ChkTest.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnModify);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(215, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(216, 25);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(80, 28);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModify.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModify.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnModify.Location = new System.Drawing.Point(125, 24);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(80, 28);
            this.BtnModify.TabIndex = 6;
            this.BtnModify.Text = "&Modify";
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(30, 24);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(80, 28);
            this.BtnReset.TabIndex = 5;
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
            this.BtnExit.Location = new System.Drawing.Point(408, 24);
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
            this.BtnSave.Location = new System.Drawing.Point(312, 24);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(80, 28);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.Color.WhiteSmoke;
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.List.Enabled = false;
            this.List.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.ItemHeight = 16;
            this.List.Location = new System.Drawing.Point(19, 15);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(178, 274);
            this.List.TabIndex = 2;
            this.List.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
            this.List.DoubleClick += new System.EventHandler(this.LstTest_DoubleClick);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(748, 333);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(746, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(746, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(157, 27);
            this.toolStripLabel1.Text = "F G Family Method Master";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFill);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 31);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(746, 300);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.List);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(746, 300);
            this.panelFill.TabIndex = 43;
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
            // FrmFgFamMethodMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(748, 333);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFgFamMethodMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F G Family Method Master";
            this.Load += new System.EventHandler(this.FrmFgFamMethodMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private static FrmFgFamMethodMaster FrmFgFamMethodMaster_Obj = null;
        public static FrmFgFamMethodMaster GetInstance()
        {
            if (FrmFgFamMethodMaster_Obj == null)
            {
                FrmFgFamMethodMaster_Obj = new FrmFgFamMethodMaster();
            }
            return FrmFgFamMethodMaster_Obj;
        }

        private void FrmFgFamMethodMaster_Load(object sender, System.EventArgs e)
		{
            try
            {
                this.WindowState = FormWindowState.Normal;
                Painter.Paint(this);


                txtTechnicalFamily.Focus();
                Bind_CHKTestList();
                Bind_Combo();
                Bind_List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
		}
        public void Bind_Combo()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster();
                dr = ds.Tables[0].NewRow();
                dr["TechFamDesc"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTechnicalFamily.DataSource = ds.Tables[0];
                    txtTechnicalFamily.DisplayMember = "TechFamDesc";
                    txtTechnicalFamily.ValueMember = "PKGTechNo";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        public void Bind_List()
		{
            try
            {
                DataSet ds = new DataSet();
                ds = FgFamilyMethodMaster_Class_Obj.Select_FGFamilyMethodMaster();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List.DataSource = ds.Tables[0];
                    List.DisplayMember = "TechFamDesc";
                    List.ValueMember = "PKGTechNo";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
		}
		public void Bind_CHKTestList()
		{
			try
			{
                DataSet ds = new DataSet();
                ds = FGTestMaster_Class_Obj.Select_TestMaster();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ChkTest.DataSource = ds.Tables[0];
                    ChkTest.DisplayMember = "Test";
                    ChkTest.ValueMember = "TestNo";


                }
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
				if(txtTechnicalFamily.Text=="--Select--")
				{
					MessageBox.Show("Enter Family Name","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
					txtTechnicalFamily.Focus();
					return;

				}
                bool z = false;
                for (int i = 0; i < ChkTest.Items.Count; i++)
                {
                    if (ChkTest.GetItemChecked(i) == true)
                    {
                        z = true;
                        break;
                    }

                }
                if (z== false)
                {
                    MessageBox.Show("Select Test", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ChkTest.Focus();
                    return;

                }
				if(Modify==false)
				{
                    bool b=false;
                    for (int i = 0; i < ChkTest.Items.Count; i++)
                    {
                        if (ChkTest.GetItemChecked(i) == true)
                        {
                            ChkTest.SetSelected(i, true);
                            int obj = Convert.ToInt32(ChkTest.SelectedValue);
                            FgFamilyMethodMaster_Class_Obj.pkgtechno = Convert.ToInt32(txtTechnicalFamily.SelectedValue);
                            FgFamilyMethodMaster_Class_Obj.methodno = obj;
                            b = FgFamilyMethodMaster_Class_Obj.Insert_FGFamilyMethodMaster();
                        }

                    }
                    
					if(b==true)
					{
						for (int i = 0; i < ChkTest.Items.Count; i++)
                        {
                            if (ChkTest.GetItemChecked(i) == true)
                            {
                                ChkTest.SetItemChecked(i, false);
                            }
                        }
						txtTechnicalFamily.Text="";
						txtTechnicalFamily.Focus();
						Bind_List();
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
				{
					
					FgFamilyMethodMaster_Class_Obj.pkgtechno = Convert.ToInt32(List.SelectedValue.ToString());
                    if (FgFamilyMethodMaster_Class_Obj.pkgtechno == 0)
					{
						MessageBox.Show("Select Record From List","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}


                    // first delete recordes from tblFGFamilyMethodMaster
                    FgFamilyMethodMaster_Class_Obj.Delete_FGFamilyMethodMaster();
                    // Now Insert In tblFGFamilyMethodMaster
                    bool b = false;
                    for (int i = 0; i < ChkTest.Items.Count; i++)
                    {
                        if (ChkTest.GetItemChecked(i) == true)
                        {
                            ChkTest.SetSelected(i, true);
                            int obj = Convert.ToInt32(ChkTest.SelectedValue);
                            FgFamilyMethodMaster_Class_Obj.pkgtechno = Convert.ToInt32(txtTechnicalFamily.SelectedValue);
                            FgFamilyMethodMaster_Class_Obj.methodno = obj;
                            b = FgFamilyMethodMaster_Class_Obj.Insert_FGFamilyMethodMaster();
                        }

                    }
						txtTechnicalFamily.Text = "";
						txtTechnicalFamily.Focus();
						Bind_Combo();
						List.Enabled=false;
						Modify=false;
                        for (int i = 0; i < ChkTest.Items.Count; i++)
                        {
                            if (ChkTest.GetItemChecked(i) == true)
                            {
                                ChkTest.SetItemChecked(i, false);
                            }
                        }
                        MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
					
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		

		private void LstTest_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
                for (int i = 0; i < ChkTest.Items.Count; i++)
                {
                    if (ChkTest.GetItemChecked(i) == true)
                    {
                        ChkTest.SetItemChecked(i, false);
                    }
                }
                DataSet ds=new DataSet();
				FgFamilyMethodMaster_Class_Obj.pkgtechno = Convert.ToInt32(List.SelectedValue.ToString());
                txtTechnicalFamily.Text = List.Text;
                ds = FgFamilyMethodMaster_Class_Obj.Select_FGFamilyMethodMaster_PkgNo();
				if(ds.Tables[0].Rows.Count > 0)
				{
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        for (int j = 0; j < ChkTest.Items.Count; j++)
                        {
                            if (ds.Tables[0].Rows[i][0].ToString() == ChkTest.GetItemText(ChkTest.Items[j]))
                            {
                                ChkTest.SetItemChecked(j, true);
                                break;
                            }
                        }
                    }

				}

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			txtTechnicalFamily.Text="";
			txtTechnicalFamily.Focus();
            for (int i = 0; i < ChkTest.Items.Count; i++)
            {
                if (ChkTest.GetItemChecked(i) == true)
                {
                    ChkTest.SetItemChecked(i, false);
                }
            }
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
				FgFamilyMethodMaster_Class_Obj.pkgtechno = Convert.ToInt32(List.SelectedValue.ToString());
                bool b = FgFamilyMethodMaster_Class_Obj.Delete_FGFamilyMethodMaster();
				if(b==true)
				{
					MessageBox.Show("Record Deleted Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
					txtTechnicalFamily.Text="";
					txtTechnicalFamily.Focus();
					BtnDelete.Enabled=false;
					Bind_List();
					List.Enabled=false;
                    for (int i = 0; i < ChkTest.Items.Count; i++)
                    {
                        if (ChkTest.GetItemChecked(i) == true)
                        {
                            ChkTest.SetItemChecked(i, false);
                        }
                    }
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
	}
}
