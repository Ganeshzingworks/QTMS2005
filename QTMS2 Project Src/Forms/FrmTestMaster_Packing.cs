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
    public class FrmTestMaster_Packing : System.Windows.Forms.Form
    {
        DataSet dsLstTest = new DataSet();

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox LstTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnModify;
        private System.Windows.Forms.Button BtnDelete;
        private TextBox txtDescription;
        private Label label3;
        private Label label4;
        private CheckedListBox ChkLstWA;
        private Panel panelOuter;
        private Panel panelbottom;
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

        public FrmTestMaster_Packing()
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

            frmTestMaster_Packing_Obj = null;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkLstWA = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LstTest = new System.Windows.Forms.ListBox();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelbottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelbottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.ChkLstWA);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTestName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(296, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ChkLstWA
            // 
            this.ChkLstWA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ChkLstWA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChkLstWA.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkLstWA.FormattingEnabled = true;
            this.ChkLstWA.Location = new System.Drawing.Point(149, 112);
            this.ChkLstWA.Name = "ChkLstWA";
            this.ChkLstWA.Size = new System.Drawing.Size(280, 56);
            this.ChkLstWA.TabIndex = 9;
            this.ChkLstWA.Click += new System.EventHandler(this.ChkLstWA_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Weighing Analysis";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(149, 67);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(280, 23);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.Leave += new System.EventHandler(this.txtTestDescription_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description";
            // 
            // txtTestName
            // 
            this.txtTestName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTestName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestName.Location = new System.Drawing.Point(149, 23);
            this.txtTestName.MaxLength = 50;
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(280, 23);
            this.txtTestName.TabIndex = 4;
            this.txtTestName.Leave += new System.EventHandler(this.txtTestName_Leave);
            this.txtTestName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTestDescription_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Test Name";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExport.Location = new System.Drawing.Point(300, 17);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 26);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnModify);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(296, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 60);
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
            this.BtnDelete.Location = new System.Drawing.Point(159, 17);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(71, 26);
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
            this.BtnModify.Location = new System.Drawing.Point(78, 17);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(75, 26);
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
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(6, 17);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(66, 26);
            this.BtnReset.TabIndex = 5;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(381, 17);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(48, 26);
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
            this.BtnSave.Location = new System.Drawing.Point(236, 17);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(58, 26);
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
            this.LstTest.Location = new System.Drawing.Point(26, 66);
            this.LstTest.Name = "LstTest";
            this.LstTest.Size = new System.Drawing.Size(255, 210);
            this.LstTest.TabIndex = 2;
            this.LstTest.SelectedIndexChanged += new System.EventHandler(this.LstTest_SelectedIndexChanged);
            this.LstTest.DoubleClick += new System.EventHandler(this.LstTest_DoubleClick);
            this.LstTest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstTest_KeyPress);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelbottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(772, 333);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(770, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(770, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(123, 27);
            this.toolStripLabel1.Text = "Packing Test Master";
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
            this.panelbottom.Controls.Add(this.panelFill);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelbottom.Location = new System.Drawing.Point(0, 33);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(770, 298);
            this.panelbottom.TabIndex = 0;
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
            this.panelFill.Size = new System.Drawing.Size(770, 298);
            this.panelFill.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(23, 16);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(26, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(255, 23);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // FrmTestMaster_Packing
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(772, 333);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTestMaster_Packing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Packing Test Master";
            this.Load += new System.EventHandler(this.FrmTestMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelbottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelFill.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        # region Varibles
        TestMaster_Class TestMaster_Class_Obj = new TestMaster_Class();
        bool Modify = false;
        #endregion

        private static Forms.FrmTestMaster_Packing frmTestMaster_Packing_Obj = null;
        public static Forms.FrmTestMaster_Packing GetInstance()
        {
            if (frmTestMaster_Packing_Obj == null)
            {
                frmTestMaster_Packing_Obj = new Forms.FrmTestMaster_Packing();
            }
            return frmTestMaster_Packing_Obj;
        }

        private void FrmTestMaster_Load(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            txtTestName.Focus();
            Bind_List();
            Bind_WA();
        }
        public void Bind_List()
        {
            try
            {

                dsLstTest = TestMaster_Class_Obj.Select_TestMaster();
                if (dsLstTest.Tables[0].Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = dsLstTest.Tables[0].DefaultView;
                    dv.RowFilter = "TestType='Packing'";
                    LstTest.DataSource = dv;
                    LstTest.DisplayMember = "TestName";
                    LstTest.ValueMember = "TestNo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_WA()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = TestMaster_Class_Obj.Select_tblWAType();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ChkLstWA.DataSource = ds.Tables[0];
                    ChkLstWA.DisplayMember = "AnalysisType";
                    ChkLstWA.ValueMember = "TypeID";
                }
            }
            catch (Exception ex)
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
                if (txtTestName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Test Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTestName.Focus();
                    return;

                }                
                if (Modify == false)
                {
                    TestMaster_Class_Obj.testname = txtTestName.Text.Trim();
                    TestMaster_Class_Obj.testdesc = txtDescription.Text.Trim();                    
                    TestMaster_Class_Obj.testtype = Convert.ToString("Packing");                    

                    TestMaster_Class_Obj.testno = TestMaster_Class_Obj.Insert_TestMaster();
                    if (TestMaster_Class_Obj.testno != 0)
                    {
                        for (int i = 0; i < ChkLstWA.Items.Count; i++)
                        {
                            if (ChkLstWA.GetItemChecked(i) == true)
                            {
                                ChkLstWA.SetSelected(i, true);
                                int obj = Convert.ToInt32(ChkLstWA.SelectedValue);
                                TestMaster_Class_Obj.typeid = obj;
                                TestMaster_Class_Obj.Insert_tblWAMethodType();
                            }
                        }

                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                    }
                }
                else
                {
                    TestMaster_Class_Obj.testname = txtTestName.Text.Trim();
                    TestMaster_Class_Obj.testdesc = txtDescription.Text.Trim();                    
                    TestMaster_Class_Obj.testtype = Convert.ToString("Packing");
                    
                    TestMaster_Class_Obj.testno = Convert.ToInt64(LstTest.SelectedValue.ToString());

                    if (TestMaster_Class_Obj.testno == 0)
                    {
                        MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataSet ds;
                    bool b = TestMaster_Class_Obj.Update_TestMaster();
                    if (b == true)
                    {
                        for (int i = 0; i < ChkLstWA.Items.Count; i++)
                        {
                            if (ChkLstWA.GetItemChecked(i) == true)
                            {
                                ChkLstWA.SetSelected(i, true);
                                int obj = Convert.ToInt32(ChkLstWA.SelectedValue);
                                TestMaster_Class_Obj.typeid = obj;

                                ds = new DataSet();
                                ds = TestMaster_Class_Obj.Select_tblWAMethodType_TestNo_TypeID();
                                if (ds.Tables[0].Rows.Count > 0)
                                {

                                }
                                else
                                {
                                    TestMaster_Class_Obj.Insert_tblWAMethodType();
                                }
                            }
                            if (ChkLstWA.GetItemChecked(i) == false)
                            {
                                ChkLstWA.SetSelected(i, true);
                                int obj = Convert.ToInt32(ChkLstWA.SelectedValue);
                                TestMaster_Class_Obj.typeid = obj;

                                TestMaster_Class_Obj.Delete_tblWAMethodType_TestNo_TypeID();                                    
                            }
                        }

                        MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);

                        Modify = false;
                    }
                }
            }
            catch(Exception ex)
            {
                if (ex.Message == "Violation of UNIQUE KEY constraint 'IX_tblFgTestDescMaster'. Cannot insert duplicate key in object 'tblTestMaster'.\r\nThe statement has been terminated.")
                {
                    MessageBox.Show("Test already exists..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    throw ex;
                }
                txtTestName.Focus();
                //MessageBox.Show(ex.Message);
            }
        }

        private void LstTest_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void LstTest_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                for (int i = 0; i < ChkLstWA.Items.Count; i++)
                {
                    ChkLstWA.SetItemChecked(i, false);
                }

                Modify = true;
                DataSet ds = new DataSet();
                TestMaster_Class_Obj.testno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                ds = TestMaster_Class_Obj.Select_TestMaster_TestNo();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //txtSearch.Text = Convert.ToString(LstTest.Text);
                    txtTestName.Text = ds.Tables[0].Rows[0]["TestName"].ToString();
                    txtDescription.Text = ds.Tables[0].Rows[0]["TestDesc"].ToString();                    
                    BtnDelete.Enabled = true;

                    DataSet ds1 = new DataSet();
                    ds1 = TestMaster_Class_Obj.Select_tblWAMethodType_TestNo();
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        for (int j = 0; j < ChkLstWA.Items.Count; j++)
                        {
                            if (ds1.Tables[0].Rows[i]["AnalysisType"].ToString() == ChkLstWA.GetItemText(ChkLstWA.Items[j]))
                            {
                                ChkLstWA.SetItemChecked(j, true);
                                break;
                            }
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, System.EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtTestName.Text = "";
            txtDescription.Text = "";
            txtTestName.Focus();
            BtnDelete.Enabled = false;
            Modify = false;

            for (int i = 0; i < ChkLstWA.Items.Count; i++)
            {
                ChkLstWA.SetItemChecked(i, false);
            }
        }

        private void BtnModify_Click(object sender, System.EventArgs e)
        {
            LstTest.Enabled = true;
            Modify = true;
            LstTest_DoubleClick(sender, e);
            BtnDelete.Enabled = true;

            
        }

        private void BtnDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (TestMaster_Class_Obj.testno != 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        TestMaster_Class_Obj.testno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                        bool b = TestMaster_Class_Obj.Delete_TestMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTestName.Text = "";
                            txtDescription.Text = "";
                            txtTestName.Focus();
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

        private void txtTestDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            txtDescription.Text = textInfo.ToTitleCase(txtDescription.Text);
        }

        private void txtTestName_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtTestName.Text = textInfo.ToTitleCase(txtTestName.Text);
        }

        private void ChkLstWA_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkLstWA.Items.Count; i++)
            {
                ChkLstWA.SetItemChecked(i, false);
            }
            ChkLstWA.SetItemChecked(ChkLstWA.SelectedIndex, true);
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsLstTest.Tables[0].DefaultView.RowFilter = "TestName like  '" + searchString + "%' and TestType = 'Packing' ";
            LstTest.DataSource = dsLstTest.Tables[0];

            LstTest.DisplayMember = "TestName";
            LstTest.ValueMember = "TestNo";		
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    for (int i = 0; i < ChkLstWA.Items.Count; i++)
                    {
                        ChkLstWA.SetItemChecked(i, false);
                    }

                    Modify = true;
                    DataSet ds = new DataSet();
                    TestMaster_Class_Obj.testno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                    ds = TestMaster_Class_Obj.Select_TestMaster_TestNo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtSearch.Text = Convert.ToString(LstTest.Text);
                        txtTestName.Text = ds.Tables[0].Rows[0]["TestName"].ToString();
                        txtDescription.Text = ds.Tables[0].Rows[0]["TestDesc"].ToString();
                        BtnDelete.Enabled = true;

                        DataSet ds1 = new DataSet();
                        ds1 = TestMaster_Class_Obj.Select_tblWAMethodType_TestNo();
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < ChkLstWA.Items.Count; j++)
                            {
                                if (ds1.Tables[0].Rows[i]["AnalysisType"].ToString() == ChkLstWA.GetItemText(ChkLstWA.Items[j]))
                                {
                                    ChkLstWA.SetItemChecked(j, true);
                                    break;
                                }
                            }
                        }
                    }
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
            }}
            catch(ArgumentOutOfRangeException exAOR)
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

        private void LstTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    for (int i = 0; i < ChkLstWA.Items.Count; i++)
                    {
                        ChkLstWA.SetItemChecked(i, false);
                    }

                    Modify = true;
                    DataSet ds = new DataSet();
                    TestMaster_Class_Obj.testno = Convert.ToInt64(LstTest.SelectedValue.ToString());
                    ds = TestMaster_Class_Obj.Select_TestMaster_TestNo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtSearch.Text = Convert.ToString(LstTest.Text);
                        txtTestName.Text = ds.Tables[0].Rows[0]["TestName"].ToString();
                        txtDescription.Text = ds.Tables[0].Rows[0]["TestDesc"].ToString();
                        BtnDelete.Enabled = true;

                        DataSet ds1 = new DataSet();
                        ds1 = TestMaster_Class_Obj.Select_tblWAMethodType_TestNo();
                        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < ChkLstWA.Items.Count; j++)
                            {
                                if (ds1.Tables[0].Rows[i]["AnalysisType"].ToString() == ChkLstWA.GetItemText(ChkLstWA.Items[j]))
                                {
                                    ChkLstWA.SetItemChecked(j, true);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                TestMaster_Class objTestMaster_Class = new TestMaster_Class();
                DataSet ds = new DataSet();
               ds = objTestMaster_Class.Select_All_Record_tblTestMaster();
                ExportToExcel objExport = new ExportToExcel();
                objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
