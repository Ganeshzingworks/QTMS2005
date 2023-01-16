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
	public class FrmFGTestMaster : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox LstTest;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTestDescription;
		private System.Windows.Forms.Button BtnSave;
		# region Varibles
        
        FGTestMaster_Class FGTestMaster_Class_Obj = new FGTestMaster_Class();
        bool Modify=false;
		# endregion
		private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnReset;
		private System.Windows.Forms.Button BtnDelete;
        private TextBox txtTestName;
        private Label label2;
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

		public FrmFGTestMaster()
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
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTestDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LstTest = new System.Windows.Forms.ListBox();
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
            this.groupBox1.Controls.Add(this.txtTestName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTestDescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(208, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtTestName
            // 
            this.txtTestName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTestName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestName.Location = new System.Drawing.Point(161, 21);
            this.txtTestName.MaxLength = 50;
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(280, 22);
            this.txtTestName.TabIndex = 0;
            this.txtTestName.Leave += new System.EventHandler(this.txtTestName_Leave);
            this.txtTestName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTestName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Test Name";
            // 
            // txtTestDescription
            // 
            this.txtTestDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTestDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTestDescription.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestDescription.Location = new System.Drawing.Point(161, 55);
            this.txtTestDescription.MaxLength = 200;
            this.txtTestDescription.Name = "txtTestDescription";
            this.txtTestDescription.Size = new System.Drawing.Size(280, 22);
            this.txtTestDescription.TabIndex = 1;
            this.txtTestDescription.Leave += new System.EventHandler(this.txtTestDescription_Leave);
            this.txtTestDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTestDescription_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Description";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(208, 138);
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
            this.BtnDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(216, 20);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(80, 27);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(117, 19);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(80, 27);
            this.BtnReset.TabIndex = 1;
            this.BtnReset.Text = "&Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(408, 19);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(80, 27);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(312, 19);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(80, 27);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LstTest
            // 
            this.LstTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LstTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstTest.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstTest.ItemHeight = 16;
            this.LstTest.Location = new System.Drawing.Point(12, 13);
            this.LstTest.Name = "LstTest";
            this.LstTest.Size = new System.Drawing.Size(178, 258);
            this.LstTest.TabIndex = 2;
            this.LstTest.SelectedIndexChanged += new System.EventHandler(this.LstTest_SelectedIndexChanged);
            this.LstTest.DoubleClick += new System.EventHandler(this.LstTest_DoubleClick);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(735, 323);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(733, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(733, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 27);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFill);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 36);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(733, 285);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.LstTest);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(733, 285);
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
            // FrmFGTestMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(735, 323);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFGTestMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F G Test Master";
            this.Load += new System.EventHandler(this.FrmTestMaster_Load);
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
            this.ResumeLayout(false);

		}
		#endregion

		private void FrmTestMaster_Load(object sender, System.EventArgs e)
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
				DataSet ds=new DataSet();
                ds = FGTestMaster_Class_Obj.Select_TestMaster();
				if(ds.Tables[0].Rows.Count>0)
				{
					LstTest.DataSource=ds.Tables[0];
                    LstTest.DisplayMember = "TestName";
                    LstTest.ValueMember = "TestNo";
					
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
				if(txtTestName.Text.Trim()=="")
				{
					MessageBox.Show("Enter Test Name","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
					txtTestName.Focus();
					return;

				}
				if(Modify==false)
				{
                    FGTestMaster_Class_Obj.testname = txtTestName.Text.Trim();
                    FGTestMaster_Class_Obj.testdesc = txtTestDescription.Text.Trim();
                    bool b = FGTestMaster_Class_Obj.Insert_TestMaster();
					if(b==true)
					{
						MessageBox.Show("Record Saved Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
						txtTestDescription.Text="";
						txtTestDescription.Focus();
						Bind_List();
                        BtnReset_Click(sender, e);
					}
				}
				else
				{
                    FGTestMaster_Class_Obj.testname = txtTestName.Text.Trim(); ;
                    FGTestMaster_Class_Obj.testdesc = txtTestDescription.Text.Trim(); ;
                    FGTestMaster_Class_Obj.testno = Convert.ToInt32(LstTest.SelectedValue.ToString());
                    if (FGTestMaster_Class_Obj.testno == 0)
					{
						MessageBox.Show("Select Record From List","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}
                    bool b = FGTestMaster_Class_Obj.Update_TestMaster();
					if(b==true)
					{
						MessageBox.Show("Record Update Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
						txtTestDescription.Text="";
						txtTestDescription.Focus();
						Bind_List();
						Modify=false;
                        BtnReset_Click(sender, e);
					}
				}
			}
			catch
			{
				
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTestName.Focus();
                Modify = false;
			}
		}

		private void LstTest_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void LstTest_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
                Modify = true;
                BtnDelete.Enabled = true;
                DataSet ds=new DataSet();
                FGTestMaster_Class_Obj.testno = Convert.ToInt32(LstTest.SelectedValue.ToString());
                ds = FGTestMaster_Class_Obj.Select_TestMaster_TestNo();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTestName.Text = Convert.ToString(ds.Tables[0].Rows[0]["TestName"]);
                    txtTestDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["TestDesc"]);
                }
                			

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
            txtTestName.Text = "";
            txtTestDescription.Text="";
            txtTestName.Focus();
            Modify = false;
		}

	

		private void BtnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				FGTestMaster_Class_Obj.testno = Convert.ToInt32(LstTest.SelectedValue.ToString());
                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool b = FGTestMaster_Class_Obj.Delete_TestMaster();
                    if (b == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTestDescription.Text = "";
                        txtTestDescription.Focus();
                        BtnDelete.Enabled = false;
                        Bind_List();
                        BtnReset_Click(sender, e);
                    }
                }
			}
			catch
			{
				//MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry You Can't delete this record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTestName.Focus();
                Modify = false;
			}
		}

        private void txtTestName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    if (e.KeyChar != Convert.ToChar(8))
            //    {
            //        if (((e.KeyChar >= Convert.ToChar(48)) && (e.KeyChar <= Convert.ToChar(57))) || (e.KeyChar >= Convert.ToChar(65)) && (e.KeyChar <= Convert.ToChar(90)) || (e.KeyChar >= Convert.ToChar(97)) && (e.KeyChar <= Convert.ToChar(122)))
            //        {

            //        }
            //        else
            //        {
            //            e.Handled = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtTestDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    if (e.KeyChar != Convert.ToChar(8))
            //    {
            //        if (((e.KeyChar >= Convert.ToChar(48)) && (e.KeyChar <= Convert.ToChar(57))) || (e.KeyChar >= Convert.ToChar(65)) && (e.KeyChar <= Convert.ToChar(90)) || (e.KeyChar >= Convert.ToChar(97)) && (e.KeyChar <= Convert.ToChar(122)))
            //        {

            //        }
            //        else
            //        {
            //            e.Handled = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtTestName_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtTestName.Text = textInfo.ToTitleCase(txtTestName.Text);	
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
	}
}
