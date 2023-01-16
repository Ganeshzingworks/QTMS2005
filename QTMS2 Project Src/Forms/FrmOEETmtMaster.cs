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

namespace QTMS.Forms
{
    /// <summary>
    /// Summary description for FrmTestMaster.
    /// </summary>
    public partial class FrmOEETmtMaster : System.Windows.Forms.Form
    {
        DataTable DtList = new DataTable();

        private Panel panelOuter;
        private Panel panelbottom;
        private Panel panelTop;
        private ToolStrip toolStrip_OEE;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButtonClose;
        private GroupBox groupBox2;
        private Button BtnDelete;
        private Button BtnModify;
        private Button BtnReset;
        private Button BtnExit;
        private Button BtnSave;
        private GroupBox groupBox1;
        private Label label_BatchSize;
        private TextBox txtBatchSize;
        private ListBox LstBulkFamily;
        private TextBox txtTMT;
        private Label label1;
        private ComboBox cmbBulkFamily;
        private Label label3;
        private Label label2;
        private Label lblSearch;
        private TextBox txtSearch;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmOEETmtMaster()
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

            frmOEETmtMaster_Obj = null;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip_OEE = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelbottom = new System.Windows.Forms.Panel();
            this.LstBulkFamily = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBulkFamily = new System.Windows.Forms.ComboBox();
            this.txtTMT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.label_BatchSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip_OEE.SuspendLayout();
            this.panelbottom.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.panelOuter.Size = new System.Drawing.Size(786, 322);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip_OEE);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(784, 30);
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
            this.toolStrip_OEE.Size = new System.Drawing.Size(784, 30);
            this.toolStrip_OEE.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(104, 27);
            this.toolStripLabel1.Text = "OEE TMT Master";
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
            // panelbottom
            // 
            this.panelbottom.Controls.Add(this.lblSearch);
            this.panelbottom.Controls.Add(this.txtSearch);
            this.panelbottom.Controls.Add(this.LstBulkFamily);
            this.panelbottom.Controls.Add(this.groupBox2);
            this.panelbottom.Controls.Add(this.groupBox1);
            this.panelbottom.Controls.Add(this.label2);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottom.Location = new System.Drawing.Point(0, 0);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(784, 320);
            this.panelbottom.TabIndex = 0;
            // 
            // LstBulkFamily
            // 
            this.LstBulkFamily.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LstBulkFamily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstBulkFamily.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstBulkFamily.ItemHeight = 16;
            this.LstBulkFamily.Location = new System.Drawing.Point(11, 108);
            this.LstBulkFamily.Name = "LstBulkFamily";
            this.LstBulkFamily.Size = new System.Drawing.Size(262, 194);
            this.LstBulkFamily.TabIndex = 13;
            this.LstBulkFamily.DoubleClick += new System.EventHandler(this.LstFamily_DoubleClick);
            this.LstBulkFamily.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstBulkFamily_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnModify);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(279, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 60);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(196, 17);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(80, 27);
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
            this.BtnModify.Location = new System.Drawing.Point(110, 17);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(80, 27);
            this.BtnModify.TabIndex = 6;
            this.BtnModify.Text = "&Modify";
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(26, 17);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(76, 27);
            this.BtnReset.TabIndex = 5;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(368, 17);
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
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(282, 17);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(80, 27);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmbBulkFamily);
            this.groupBox1.Controls.Add(this.txtTMT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBatchSize);
            this.groupBox1.Controls.Add(this.label_BatchSize);
            this.groupBox1.Location = new System.Drawing.Point(279, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 181);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // cmbBulkFamily
            // 
            this.cmbBulkFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBulkFamily.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBulkFamily.FormattingEnabled = true;
            this.cmbBulkFamily.Location = new System.Drawing.Point(226, 23);
            this.cmbBulkFamily.Name = "cmbBulkFamily";
            this.cmbBulkFamily.Size = new System.Drawing.Size(232, 24);
            this.cmbBulkFamily.TabIndex = 13;
            // 
            // txtTMT
            // 
            this.txtTMT.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.txtTMT.Location = new System.Drawing.Point(226, 102);
            this.txtTMT.Name = "txtTMT";
            this.txtTMT.Size = new System.Drawing.Size(232, 23);
            this.txtTMT.TabIndex = 12;
            this.txtTMT.Leave += new System.EventHandler(this.txtActivity_Leave);
            this.txtTMT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchSize_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = " TMT\r\n (Target Manufacturing Time in minutes)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(134, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bulk Family";
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.txtBatchSize.Location = new System.Drawing.Point(226, 63);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.Size = new System.Drawing.Size(232, 23);
            this.txtBatchSize.TabIndex = 12;
            this.txtBatchSize.Leave += new System.EventHandler(this.txtActivity_Leave);
            this.txtBatchSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchSize_KeyPress);
            // 
            // label_BatchSize
            // 
            this.label_BatchSize.AutoSize = true;
            this.label_BatchSize.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BatchSize.Location = new System.Drawing.Point(103, 66);
            this.label_BatchSize.Name = "label_BatchSize";
            this.label_BatchSize.Size = new System.Drawing.Size(111, 16);
            this.label_BatchSize.TabIndex = 3;
            this.label_BatchSize.Text = "Batch Size (Kg)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "BulkFamily_BatchSize";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 74);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 28;
            this.lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(67, 71);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(206, 20);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // FrmOEETmtMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(786, 322);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOEETmtMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OEE TMT Master";
            this.Load += new System.EventHandler(this.FrmOEEActivityMaster_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip_OEE.ResumeLayout(false);
            this.toolStrip_OEE.PerformLayout();
            this.panelbottom.ResumeLayout(false);
            this.panelbottom.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        # region Varibles
        BusinessFacade.Transactions.OEETransactionTest_Class OEETransactionTest_Class_Obj = new BusinessFacade.Transactions.OEETransactionTest_Class();
        bool Modify = false;
        #endregion

        private static Forms.FrmOEETmtMaster frmOEETmtMaster_Obj = null;
        public static Forms.FrmOEETmtMaster GetInstance()
        {
            if (frmOEETmtMaster_Obj == null)
            {
                frmOEETmtMaster_Obj = new Forms.FrmOEETmtMaster();
            }
            return frmOEETmtMaster_Obj;
        }

        private void FrmOEEActivityMaster_Load(object sender, System.EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                Painter.Paint(this);
                Bind_Family();
                Bind_TMTFamilyMaster();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bind_TMTFamilyMaster()
        {
            try
            {
               
                DtList = OEETransactionTest_Class_Obj.Select_OEETechFamTMTMaster(true);
                if (DtList.Rows.Count > 0)
                {
                    LstBulkFamily.DataSource = DtList;
                    LstBulkFamily.DisplayMember = "FamilyDesc";
                    LstBulkFamily.ValueMember = "TMTFamilyNo"; 
                }
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public void Bind_Family()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
                ds = BulkFamilyMaster_Class_Obj.Select_BulkFamilyMaster();

                dr = ds.Tables[0].NewRow();
                dr["FamilyDesc"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbBulkFamily.DataSource = ds.Tables[0];
                    cmbBulkFamily.DisplayMember = "FamilyDesc";
                    cmbBulkFamily.ValueMember = "TechFamNo";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }                           

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_Family();
            txtSearch.Text="";
            LstBulkFamily.ClearSelected();
            cmbBulkFamily.SelectedIndex = 0;
            txtBatchSize.Clear();
            txtTMT.Clear();
            txtBatchSize.Focus();
            OEETransactionTest_Class_Obj.techFamNo = 0;
            OEETransactionTest_Class_Obj.tmtfamilyno = 0;
            BtnDelete.Enabled = false;
            Modify = false;
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            Modify = true;
            LstFamily_DoubleClick(sender, e);
        }       

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    OEETransactionTest_Class_Obj.techFamNo= Convert.ToInt64(cmbBulkFamily.SelectedValue);
                    OEETransactionTest_Class_Obj.batchsize = Convert.ToInt64(txtBatchSize.Text.Trim());
                    OEETransactionTest_Class_Obj.targetmtime = Convert.ToInt64(txtTMT.Text.Trim());

                    if (Modify)
                    {
                        if (OEETransactionTest_Class_Obj.tmtfamilyno != 0)
                        {
                            OEETransactionTest_Class_Obj.Update_OEETechFamTMTMaster();
                            MessageBox.Show("Updated Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Please Select Record To Update");
                        }
                    }
                    else
                    {
                        OEETransactionTest_Class_Obj.Insert_OEETechFamTMTMaster();
                        MessageBox.Show("Saved Successfully");
                    }
                    BtnReset_Click(sender, e);
                    Bind_TMTFamilyMaster();
                }
            }              

            catch(System.Data.SqlClient.SqlException ex)
            {
                if (((System.Runtime.InteropServices.ExternalException)(ex)).ErrorCode == -2146232060)
                {
                    MessageBox.Show("This family name and batch is already present");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsValid()
        {
            try
            {
                if (cmbBulkFamily.Text== "Select")
                {
                    MessageBox.Show("Please Enter Family Name");
                    cmbBulkFamily.Focus();
                    return false;
                }
                
                if (txtBatchSize.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Batch Size");
                    txtBatchSize.Focus();
                    return false;
                }             
                
                if (txtTMT.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter TMT");
                    txtTMT.Focus();
                    return false;
                }                
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (OEETransactionTest_Class_Obj.tmtfamilyno!= 0)
                    {
                        OEETransactionTest_Class_Obj.Delete_OEETechFamTMTMaster();
                        MessageBox.Show("Deleted Successfully");
                        BtnReset_Click(sender, e);
                        Bind_TMTFamilyMaster();
                    }
                    else
                    {
                        MessageBox.Show("Please select record to delete");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtActivity_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtBatchSize.Text = textInfo.ToTitleCase(txtBatchSize.Text);
        }

        private void LstFamily_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = Convert.ToString(LstBulkFamily.Text);
                OEETransactionTest_Class_Obj.tmtfamilyno= Convert.ToInt64(LstBulkFamily.SelectedValue.ToString());

                LoadData();

                BtnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt=OEETransactionTest_Class_Obj.Select_OEETechFamTMTMaster(false);
                cmbBulkFamily.SelectedValue=Convert.ToInt64(Dt.Rows[0]["TechFamNo"]);
                txtBatchSize.Text = Convert.ToString(Dt.Rows[0]["BatchSize"]);
                txtTMT.Text = Convert.ToString(Dt.Rows[0]["TargetMTime"]);
            }
            catch (Exception)
            {
              throw;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBatchSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= (48) & e.KeyChar <= (57)) | e.KeyChar == (8)))
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            DtList.DefaultView.RowFilter = "FamilyDesc like  '" + searchString + "%'";
            LstBulkFamily.DataSource = DtList;

            LstBulkFamily.DisplayMember = "FamilyDesc";
            LstBulkFamily.ValueMember = "TMTFamilyNo"; 
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                try
                {
                    txtSearch.Text = Convert.ToString(LstBulkFamily.Text);
                    OEETransactionTest_Class_Obj.tmtfamilyno = Convert.ToInt64(LstBulkFamily.SelectedValue.ToString());

                    LoadData();

                    BtnDelete.Enabled = true;
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
                    LstBulkFamily.Select();
                    LstBulkFamily.SelectedIndex = LstBulkFamily.SelectedIndex + 1;
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
                    LstBulkFamily.Select();
                    LstBulkFamily.SelectedIndex = LstBulkFamily.SelectedIndex - 1;
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

        private void LstBulkFamily_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    txtSearch.Text = Convert.ToString(LstBulkFamily.Text);
                    OEETransactionTest_Class_Obj.tmtfamilyno = Convert.ToInt64(LstBulkFamily.SelectedValue.ToString());

                    LoadData();

                    BtnDelete.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }       

                     

    }
}
