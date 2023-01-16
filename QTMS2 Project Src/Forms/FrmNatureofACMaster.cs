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
	public class FrmNatureofACMaster : System.Windows.Forms.Form
	{
        //DataSet dsList = new DataSet();

        CompatibilityMaster_Class CompatibilityMaster_Class_Obj = new BusinessFacade.CompatibilityMaster_Class();
        DataTable DtNatureRef = null;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox LstNature;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNatureDescription;
		private System.Windows.Forms.Button BtnSave;		
		private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnDelete;
        private Panel panelOuter;
        private Panel panelBottom;
        private Panel panelFill;
        private Panel panelTop;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButtonClose;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnExport;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmNatureofACMaster()
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

            FrmNatureofACMaster_Obj = null;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNatureDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LstNature = new System.Windows.Forms.ListBox();
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
            this.groupBox1.Controls.Add(this.txtNatureDescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(212, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtNatureDescription
            // 
            this.txtNatureDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNatureDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNatureDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNatureDescription.Location = new System.Drawing.Point(159, 58);
            this.txtNatureDescription.MaxLength = 50;
            this.txtNatureDescription.Name = "txtNatureDescription";
            this.txtNatureDescription.Size = new System.Drawing.Size(280, 23);
            this.txtNatureDescription.TabIndex = 4;
            this.txtNatureDescription.Leave += new System.EventHandler(this.txtTestDescription_Leave);
            this.txtNatureDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTestDescription_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nature Description";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(212, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExport.Location = new System.Drawing.Point(282, 29);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(70, 26);
            this.btnExport.TabIndex = 7;
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
            this.BtnDelete.Location = new System.Drawing.Point(115, 29);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(67, 26);
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
            this.BtnReset.Location = new System.Drawing.Point(37, 29);
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
            this.BtnExit.Location = new System.Drawing.Point(374, 29);
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
            this.BtnSave.Location = new System.Drawing.Point(202, 29);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(61, 26);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LstNature
            // 
            this.LstNature.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LstNature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstNature.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstNature.ItemHeight = 16;
            this.LstNature.Location = new System.Drawing.Point(16, 63);
            this.LstNature.Name = "LstNature";
            this.LstNature.Size = new System.Drawing.Size(178, 210);
            this.LstNature.TabIndex = 2;
            this.LstNature.DoubleClick += new System.EventHandler(this.LstTest_DoubleClick);
            this.LstNature.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstTest_KeyPress);
            // 
            // panelOuter
            // 
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(700, 320);
            this.panelOuter.TabIndex = 5;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(700, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(700, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(124, 27);
            this.toolStripLabel1.Text = "Nature of AC Master";
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
            this.panelBottom.Size = new System.Drawing.Size(700, 287);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.LstNature);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(700, 287);
            this.panelFill.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(13, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(16, 33);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(178, 23);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // FrmNatureofACMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(700, 320);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNatureofACMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nature of AC Master";
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
            this.panelFill.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private static FrmNatureofACMaster FrmNatureofACMaster_Obj = null;
        public static FrmNatureofACMaster GetInstance()
        {
            if (FrmNatureofACMaster_Obj == null)
            {
                FrmNatureofACMaster_Obj = new FrmNatureofACMaster(); 
            }
            return FrmNatureofACMaster_Obj;
        }

        # region Varibles

        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        bool Modify = false;

        # endregion

		private void FrmTestMaster_Load(object sender, System.EventArgs e)
		{
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

			txtNatureDescription.Focus();
			Bind_List();
		}


		public void Bind_List()
		{
			try
			{
                DtNatureRef = new DataTable();                
                DtNatureRef = CompatibilityMaster_Class_Obj.SELECT_tblCompatAcNatureMaster();
                LstNature.DataSource = DtNatureRef;
                LstNature.DisplayMember = "AcNatureRef";
                LstNature.ValueMember = "AcNatureNo";
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
                if(txtNatureDescription.Text.Trim()=="")
				{
					MessageBox.Show("Enter Line Name","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
					txtNatureDescription.Focus();
					return;

				}
				if(Modify==false)
				{
                    // to insert record set flag 'I'
                    CompatibilityMaster_Class_Obj.strFlag = 'I';
                    CompatibilityMaster_Class_Obj.AcNatureRef = txtNatureDescription.Text.Trim();                    

                    // this method is used for both transaction insert record and update record
                    bool b = CompatibilityMaster_Class_Obj.Insert_Update_NatureofRefMaster();
					if(b==true)
					{
						MessageBox.Show("Record Saved Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Bind_List();
					}
				}
				else
				{

                    // to update record set flag 'U'
                    CompatibilityMaster_Class_Obj.strFlag = 'U';
                    CompatibilityMaster_Class_Obj.AcNatureRef = txtNatureDescription.Text.Trim();
                    CompatibilityMaster_Class_Obj.AcNatureNo = Convert.ToInt32(LstNature.SelectedValue.ToString());                    

                    if (CompatibilityMaster_Class_Obj.AcNatureNo == 0)
					{
						MessageBox.Show("Select Record From List","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
						return;
					}

                    // this method is used for both transaction insert record and update record
                    bool b = CompatibilityMaster_Class_Obj.Insert_Update_NatureofRefMaster();

					if(b==true)
					{
						MessageBox.Show("Record Update Successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);						
					}
				}
                BtnReset_Click(sender, e);
			}
			catch
			{
				//MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		

		private void LstTest_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
                Modify = true;
                //DataSet ds=new DataSet();
				CompatibilityMaster_Class_Obj.AcNatureNo = Convert.ToInt32(LstNature.SelectedValue.ToString());
                txtNatureDescription.Text = LstNature.Text.Trim();
                BtnDelete.Enabled = true;
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
			txtNatureDescription.Text = "";
			txtNatureDescription.Focus();
            BtnDelete.Enabled = false;
            Modify = false;
            Bind_List();
		}

		private void BtnModify_Click(object sender, System.EventArgs e)
		{
			LstNature.Enabled=true;
			Modify=true;
			LstTest_DoubleClick(sender,e);
			BtnDelete.Enabled =true;
		}

		private void BtnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				CompatibilityMaster_Class_Obj.AcNatureNo = Convert.ToInt32(LstNature.SelectedValue.ToString());
                
                if (CompatibilityMaster_Class_Obj.AcNatureNo > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = CompatibilityMaster_Class_Obj.Delete_NatureofACMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnReset_Click(sender, e);
                        }
                    }
                }
			}
			catch
			{
                MessageBox.Show("Sorry You Can't delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void txtTestDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(32))
            {
                e.Handled = true;
            }

            // Only 0-9 and a-z and A-Z allowed
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

            txtNatureDescription.Text = textInfo.ToTitleCase(txtNatureDescription.Text);	
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text.Trim();
            
            DtNatureRef.DefaultView.RowFilter = "AcNatureRef like  '" + searchString + "%'";
            LstNature.DataSource = DtNatureRef;

            LstNature.DisplayMember = "AcNatureRef";
            LstNature.ValueMember = "AcNatureNo";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(LstNature.Text.Trim());
                    Modify = true;
                    CompatibilityMaster_Class_Obj.AcNatureNo = Convert.ToInt32(LstNature.SelectedValue.ToString());
                    txtNatureDescription.Text = LstNature.Text.Trim();
                    BtnDelete.Enabled = true;
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
                    LstNature.Select();
                    LstNature.SelectedIndex = LstNature.SelectedIndex + 1;
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
                LstNature.Select();
                LstNature.SelectedIndex = LstNature.SelectedIndex - 1;
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
                    txtSearch.Text = Convert.ToString(LstNature.Text.Trim());
                    Modify = true;                    
                    CompatibilityMaster_Class_Obj.AcNatureNo = Convert.ToInt32(LstNature.SelectedValue.ToString());
                    txtNatureDescription.Text = LstNature.Text.Trim();
                    BtnDelete.Enabled = true;

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
              DtNatureRef = new DataTable();
              DtNatureRef = CompatibilityMaster_Class_Obj.SELECT_tblCompatAcNatureMaster();              
           
              ExportToExcel objExport = new ExportToExcel();
              objExport.GenerateExcelFile(DtNatureRef);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
	}
}
