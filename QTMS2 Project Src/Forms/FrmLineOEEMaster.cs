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
    public partial class FrmLineOEEMaster : System.Windows.Forms.Form
    {
        private Panel panelOuter;
        private Panel panelbottom;
        private Panel panelTop;
        private ToolStrip toolStrip_OEE;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButtonClose;
        private GroupBox groupBox2;
        private Button BtnDelete;
        private Button BtnReset;
        private Button BtnExit;
        private GroupBox groupBox1;
        private TextBox txtSTDMOD;
        private Label label5;
        private TextBox txtLineSpeed;
        private Label label4;
        private ComboBox cmbLineNo;
        private ComboBox cmbFGCode;
        private Label label3;
        private Label label2;
        private Button btnAdd;
        private DataGridView dgLineOEEMaster;
        private DataGridViewTextBoxColumn FGNo;
        private DataGridViewTextBoxColumn LNo;
        private DataGridViewTextBoxColumn FGCode;
        private DataGridViewTextBoxColumn LineNo;
        private DataGridViewTextBoxColumn StandardMOD;
        private DataGridViewTextBoxColumn LineSpeed;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmLineOEEMaster()
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

            FrmLineOEEActivityMaster_Obj = null;
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
            this.panelbottom = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.dgLineOEEMaster = new System.Windows.Forms.DataGridView();
            this.FGNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StandardMOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSTDMOD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLineSpeed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLineNo = new System.Windows.Forms.ComboBox();
            this.cmbFGCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnExit = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip_OEE.SuspendLayout();
            this.panelbottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLineOEEMaster)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.panelOuter.Size = new System.Drawing.Size(671, 415);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip_OEE);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(669, 30);
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
            this.toolStrip_OEE.Size = new System.Drawing.Size(669, 30);
            this.toolStrip_OEE.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(105, 27);
            this.toolStripLabel1.Text = "Line OEE  Master";
            // 
            // panelbottom
            // 
            this.panelbottom.Controls.Add(this.groupBox1);
            this.panelbottom.Controls.Add(this.groupBox2);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelbottom.Location = new System.Drawing.Point(0, 0);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(669, 413);
            this.panelbottom.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.BtnDelete);
            this.groupBox1.Controls.Add(this.BtnReset);
            this.groupBox1.Controls.Add(this.dgLineOEEMaster);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtSTDMOD);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLineSpeed);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbLineNo);
            this.groupBox1.Controls.Add(this.cmbFGCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Location = new System.Drawing.Point(11, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(653, 310);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(492, 79);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(67, 27);
            this.BtnDelete.TabIndex = 5;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(418, 79);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(68, 27);
            this.BtnReset.TabIndex = 6;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // dgLineOEEMaster
            // 
            this.dgLineOEEMaster.AllowUserToAddRows = false;
            this.dgLineOEEMaster.AllowUserToDeleteRows = false;
            this.dgLineOEEMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLineOEEMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FGNo,
            this.LNo,
            this.FGCode,
            this.LineNo,
            this.StandardMOD,
            this.LineSpeed});
            this.dgLineOEEMaster.Location = new System.Drawing.Point(16, 119);
            this.dgLineOEEMaster.MultiSelect = false;
            this.dgLineOEEMaster.Name = "dgLineOEEMaster";
            this.dgLineOEEMaster.Size = new System.Drawing.Size(629, 183);
            this.dgLineOEEMaster.TabIndex = 7;
            this.dgLineOEEMaster.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLineOEEMaster_RowEnter);
            this.dgLineOEEMaster.Click += new System.EventHandler(this.dgLineOEEMaster_Click);
            // 
            // FGNo
            // 
            this.FGNo.HeaderText = "FGNo";
            this.FGNo.Name = "FGNo";
            this.FGNo.Visible = false;
            this.FGNo.Width = 15;
            // 
            // LNo
            // 
            this.LNo.HeaderText = "LNo";
            this.LNo.Name = "LNo";
            this.LNo.Visible = false;
            this.LNo.Width = 15;
            // 
            // FGCode
            // 
            this.FGCode.HeaderText = "FG Code";
            this.FGCode.Name = "FGCode";
            this.FGCode.Width = 200;
            // 
            // LineNo
            // 
            this.LineNo.HeaderText = "Line Number";
            this.LineNo.Name = "LineNo";
            this.LineNo.Width = 150;
            // 
            // StandardMOD
            // 
            this.StandardMOD.HeaderText = "Std MOD";
            this.StandardMOD.Name = "StandardMOD";
            // 
            // LineSpeed
            // 
            this.LineSpeed.HeaderText = "Line Speed";
            this.LineSpeed.Name = "LineSpeed";
            this.LineSpeed.Width = 120;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(565, 79);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 27);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSTDMOD
            // 
            this.txtSTDMOD.Location = new System.Drawing.Point(451, 45);
            this.txtSTDMOD.Name = "txtSTDMOD";
            this.txtSTDMOD.Size = new System.Drawing.Size(91, 23);
            this.txtSTDMOD.TabIndex = 2;
            this.txtSTDMOD.Text = "0";
            this.txtSTDMOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSTDMOD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSTDMOD_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(447, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Std. MOD :";
            // 
            // txtLineSpeed
            // 
            this.txtLineSpeed.Location = new System.Drawing.Point(552, 45);
            this.txtLineSpeed.Name = "txtLineSpeed";
            this.txtLineSpeed.Size = new System.Drawing.Size(88, 23);
            this.txtLineSpeed.TabIndex = 3;
            this.txtLineSpeed.Text = "0";
            this.txtLineSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLineSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLineSpeed_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(549, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Line Speed :";
            // 
            // cmbLineNo
            // 
            this.cmbLineNo.FormattingEnabled = true;
            this.cmbLineNo.Location = new System.Drawing.Point(258, 45);
            this.cmbLineNo.Name = "cmbLineNo";
            this.cmbLineNo.Size = new System.Drawing.Size(187, 24);
            this.cmbLineNo.TabIndex = 1;
            this.cmbLineNo.SelectionChangeCommitted += new System.EventHandler(this.cmbLineNo_SelectionChangeCommitted);
            // 
            // cmbFGCode
            // 
            this.cmbFGCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFGCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFGCode.FormattingEnabled = true;
            this.cmbFGCode.Location = new System.Drawing.Point(19, 45);
            this.cmbFGCode.Name = "cmbFGCode";
            this.cmbFGCode.Size = new System.Drawing.Size(231, 24);
            this.cmbFGCode.TabIndex = 1;
            this.cmbFGCode.SelectionChangeCommitted += new System.EventHandler(this.cmbFGCode_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Line No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "FG Code :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 350);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(653, 60);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(286, 17);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(80, 27);
            this.BtnExit.TabIndex = 0;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "FGNo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 15;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "LNo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 15;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "FG Code";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Line Number";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Std MOD";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Line Speed";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 120;
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
            // FrmLineOEEMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(671, 415);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLineOEEMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Line OEE  Master";
            this.Load += new System.EventHandler(this.FrmLineOEEActivityMaster_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip_OEE.ResumeLayout(false);
            this.toolStrip_OEE.PerformLayout();
            this.panelbottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgLineOEEMaster)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        # region Varibles
        BusinessFacade.Transactions.LineOEETransaction lineOEETransaction_Class_Obj = new BusinessFacade.Transactions.LineOEETransaction();
        bool Modify = false;
        #endregion

        private static Forms.FrmLineOEEMaster FrmLineOEEActivityMaster_Obj = null;
        public static Forms.FrmLineOEEMaster GetInstance()
        {
            if (FrmLineOEEActivityMaster_Obj == null)
            {
                FrmLineOEEActivityMaster_Obj = new Forms.FrmLineOEEMaster();
            }
            return FrmLineOEEActivityMaster_Obj;
        }

        private void FrmLineOEEActivityMaster_Load(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            BindFGCode();
            BindLineNo();                 

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

        private void LstActivities_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                
                //lineOEETransaction_Class_Obj.activityID = Convert.ToInt32(LstFGCodeLineNo.SelectedValue.ToString());

                
                //BtnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {            
            //cmbFGCode.SelectedIndex = 0;
            cmbLineNo.SelectedIndex = 0;
            txtSTDMOD.Text = "0";
            txtLineSpeed.Text = "0";
            BtnDelete.Enabled = false;
            Modify = false;
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            Modify = true;            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                //for (int i = 0; i < dgLineOEEMaster.Rows.Count; i++)
                //{
                //    lineOEETransaction_Class_Obj.fgno = Convert.ToInt64(dgLineOEEMaster["FGNo", i].Value);
                //    lineOEETransaction_Class_Obj.lno = Convert.ToInt32(dgLineOEEMaster["LNo", i].Value);
                //    lineOEETransaction_Class_Obj.mod = Convert.ToInt32(dgLineOEEMaster["StandardMOD", i].Value);
                //    lineOEETransaction_Class_Obj.lineSpeed = Convert.ToInt32(dgLineOEEMaster["LineSpeed", i].Value);

                //    bool flag = lineOEETransaction_Class_Obj.Insert_LineOEEMaster();
                //    if (flag == true)
                //        MessageBox.Show("Saved Successfully");
                //}


                if (IsValid())
                {

                    if (Modify)
                    {
                        lineOEETransaction_Class_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                        lineOEETransaction_Class_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                        lineOEETransaction_Class_Obj.mod = Convert.ToInt32(txtSTDMOD.Text);
                        lineOEETransaction_Class_Obj.lineSpeed = Convert.ToInt32(txtLineSpeed.Text);
                        bool flag = lineOEETransaction_Class_Obj.Update_LineOEEMaster();
                        if (flag == true)
                            MessageBox.Show("Updated Successfully");
                    }
                    else
                    {                        
                        bool flag = lineOEETransaction_Class_Obj.Insert_LineOEEMaster();
                        if (flag == true)
                            MessageBox.Show("Saved Successfully");
                    }
                    BtnReset_Click(sender, e);
                    //Bind_Activity();
                }
            }              

            catch(System.Data.SqlClient.SqlException ex)
            {
                if (((System.Runtime.InteropServices.ExternalException)(ex)).ErrorCode == -2146232060)
                {
                    MessageBox.Show("This activity name is already present");
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
                if (txtSTDMOD.Text.Trim() == "0")
                {
                    MessageBox.Show("Please enter mod", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSTDMOD.Focus();
                    return false;
                }
                if (txtLineSpeed.Text.Trim() == "0")
                {
                    MessageBox.Show("Please enter Line Speed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLineSpeed.Focus();
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
                if (dgLineOEEMaster.SelectedRows != null && dgLineOEEMaster.SelectedRows.Count != 0)
                {

                    for (int i = 0; i < dgLineOEEMaster.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            lineOEETransaction_Class_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                            lineOEETransaction_Class_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                            bool flag = lineOEETransaction_Class_Obj.Delete_LineOEEMaster();

                            
                            cmbLineNo_SelectionChangeCommitted(sender, e);
                            BtnReset_Click(sender, e);
                            //if (flag == true)
                            //    MessageBox.Show("Record deleted Successfully");

                        }
                    }
                }                    

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbLineNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                BtnDelete.Enabled = false;
                if (cmbFGCode.Text.Trim() == "--Select--")
                {
                    MessageBox.Show("Please select FG Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbFGCode.Focus();
                    return;
                }
                DataTable dt = new DataTable();

                lineOEETransaction_Class_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                lineOEETransaction_Class_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                dt = lineOEETransaction_Class_Obj.Select_LineOEEMaster();
                if (dt.Rows.Count > 0)
                {
                    txtSTDMOD.Text = Convert.ToString(dt.Rows[0]["StandardMOD"]);
                    txtLineSpeed.Text = Convert.ToString(dt.Rows[0]["LineSpeed"]);
                    //BtnDelete.Enabled = true;
                }
                else
                {
                    txtSTDMOD.Text = "0";
                    txtLineSpeed.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    for (int i = 0; i < dgLineOEEMaster.Rows.Count; i++)
                    {
                        if ((dgLineOEEMaster["FGNo", i].Value.ToString() == cmbFGCode.SelectedValue.ToString()) && (dgLineOEEMaster["LNo", i].Value.ToString() == cmbLineNo.SelectedValue.ToString()))
                        {
                            if (MessageBox.Show("This Record already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                            {
                                lineOEETransaction_Class_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                                lineOEETransaction_Class_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                                lineOEETransaction_Class_Obj.mod = Convert.ToInt32(txtSTDMOD.Text);
                                lineOEETransaction_Class_Obj.lineSpeed = Convert.ToInt32(txtLineSpeed.Text);
                                bool flag = lineOEETransaction_Class_Obj.Update_LineOEEMaster();

                                BtnReset_Click(sender, e);
                                cmbFGCode_SelectionChangeCommitted(sender, e);

                                return;
                                //if (flag == true)
                                //    MessageBox.Show("Record Updated Successfully");
                            }
                        }
                    }

                    lineOEETransaction_Class_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                    lineOEETransaction_Class_Obj.lno = Convert.ToInt32(cmbLineNo.SelectedValue);
                    lineOEETransaction_Class_Obj.mod = Convert.ToInt32(txtSTDMOD.Text);
                    lineOEETransaction_Class_Obj.lineSpeed = Convert.ToInt32(txtLineSpeed.Text);
                    bool flg = lineOEETransaction_Class_Obj.Insert_LineOEEMaster();

                    BtnReset_Click(sender, e);
                    cmbFGCode_SelectionChangeCommitted(sender, e);
                           

                    //dgLineOEEMaster.Rows.Add();
                    //dgLineOEEMaster["FGNo", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(cmbFGCode.SelectedValue);
                    //dgLineOEEMaster["LNo", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(cmbLineNo.SelectedValue);
                    //dgLineOEEMaster["FGCode", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(cmbFGCode.Text);
                    //dgLineOEEMaster["LineNo", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(cmbLineNo.Text);
                    //dgLineOEEMaster["StandardMOD", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(txtSTDMOD.Text);
                    //dgLineOEEMaster["LineSpeed", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(txtLineSpeed.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        }

        private void txtLineSpeed_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void dgLineOEEMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgLineOEEMaster.Rows.Count > 0)
                {
                    
                    if (dgLineOEEMaster.Rows[e.RowIndex].Cells["FGNo"].Value != null)
                    {
                        cmbFGCode.SelectedValue = dgLineOEEMaster["FGNo", e.RowIndex].Value;
                    }
                    if (dgLineOEEMaster.Rows[e.RowIndex].Cells["LNo"].Value != null)
                    {
                        cmbLineNo.SelectedValue = dgLineOEEMaster["LNo", e.RowIndex].Value;
                    }
                    if (dgLineOEEMaster.Rows[e.RowIndex].Cells["StandardMOD"].Value != null)
                    {
                        txtSTDMOD.Text = dgLineOEEMaster["StandardMOD", e.RowIndex].Value.ToString();
                    }
                    if (dgLineOEEMaster.Rows[e.RowIndex].Cells["LineSpeed"].Value != null)
                    {
                        txtLineSpeed.Text = dgLineOEEMaster["LineSpeed", e.RowIndex].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void cmbFGCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                BtnDelete.Enabled = false;
                dgLineOEEMaster.Rows.Clear();
                lineOEETransaction_Class_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                DataTable dt = new DataTable();
                dt = lineOEETransaction_Class_Obj.Select_LineOEEMaster_FGNo();

                foreach (DataRow dr in dt.Rows)
                {
                    dgLineOEEMaster.Rows.Add();
                    dgLineOEEMaster["FGNo", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(dr["FGNo"]);
                    dgLineOEEMaster["LNo", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(dr["LNo"]);
                    dgLineOEEMaster["FGCode", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(dr["FGCode"]);
                    dgLineOEEMaster["LineNo", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(dr["LineDesc"]);
                    dgLineOEEMaster["StandardMOD", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(dr["StandardMOD"]);
                    dgLineOEEMaster["LineSpeed", dgLineOEEMaster.Rows.Count - 1].Value = Convert.ToString(dr["LineSpeed"]);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgLineOEEMaster_Click(object sender, EventArgs e)
        {
            BtnDelete.Enabled = true;
        }    

       
      

    }
}
