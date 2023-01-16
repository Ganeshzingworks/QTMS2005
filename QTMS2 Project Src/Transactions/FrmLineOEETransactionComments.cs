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

namespace QTMS.Transactions
{
    /// <summary>
    /// Summary description for FrmTestMaster.
    /// </summary>
    public partial class FrmLineOEETransactionComments : System.Windows.Forms.Form
    {
        private Panel panelOuter;
        private Panel panelbottom;
        private Panel panelTop;
        private ToolStrip toolStrip_OEE;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButtonClose;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnClose;
        private Button btnSave;
        private Button btnReset;
        private ComboBox cmbCategory;
        private Label lblCategory;
        private Label lblComment;
        private Label label1;
        private Label label2;
        private TextBox txtComment;
        private DateTimePicker dtpToTime;
        private DateTimePicker dtpFromTime;
        private Label label4;
        private TextBox txtMOD;
        private Button btnDelete;
        private ComboBox CmbMachine;
        private Label lblMachine;
        private TextBox txtActivityName;
        private Label lblActivityName;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmLineOEETransactionComments()
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

            FrmLineOEETransactionComments_Obj = null;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLineOEETransactionComments));
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip_OEE = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelbottom = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtActivityName = new System.Windows.Forms.TextBox();
            this.lblActivityName = new System.Windows.Forms.Label();
            this.CmbMachine = new System.Windows.Forms.ComboBox();
            this.lblMachine = new System.Windows.Forms.Label();
            this.txtMOD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpToTime = new System.Windows.Forms.DateTimePicker();
            this.dtpFromTime = new System.Windows.Forms.DateTimePicker();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip_OEE.SuspendLayout();
            this.panelbottom.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.panelOuter.Size = new System.Drawing.Size(431, 422);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip_OEE);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(429, 30);
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
            this.toolStrip_OEE.Size = new System.Drawing.Size(429, 30);
            this.toolStrip_OEE.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(300, 27);
            this.toolStripLabel1.Text = "Line OEE Transaction Comments";
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonClose.BackColor = System.Drawing.Color.White;
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClose.Image")));
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // panelbottom
            // 
            this.panelbottom.Controls.Add(this.groupBox3);
            this.panelbottom.Controls.Add(this.groupBox2);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelbottom.Location = new System.Drawing.Point(0, 0);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(429, 420);
            this.panelbottom.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(15, 356);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 54);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 15);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(118, 33);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Clear Comment";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(309, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 33);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(219, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 33);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(136, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 33);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtActivityName);
            this.groupBox2.Controls.Add(this.lblActivityName);
            this.groupBox2.Controls.Add(this.CmbMachine);
            this.groupBox2.Controls.Add(this.lblMachine);
            this.groupBox2.Controls.Add(this.txtMOD);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpToTime);
            this.groupBox2.Controls.Add(this.dtpFromTime);
            this.groupBox2.Controls.Add(this.txtComment);
            this.groupBox2.Controls.Add(this.lblComment);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbCategory);
            this.groupBox2.Controls.Add(this.lblCategory);
            this.groupBox2.Location = new System.Drawing.Point(12, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 326);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Activity Details";
            // 
            // txtActivityName
            // 
            this.txtActivityName.Location = new System.Drawing.Point(97, 46);
            this.txtActivityName.Name = "txtActivityName";
            this.txtActivityName.ReadOnly = true;
            this.txtActivityName.Size = new System.Drawing.Size(286, 31);
            this.txtActivityName.TabIndex = 16;
            this.txtActivityName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblActivityName
            // 
            this.lblActivityName.AutoSize = true;
            this.lblActivityName.Location = new System.Drawing.Point(1, 48);
            this.lblActivityName.Name = "lblActivityName";
            this.lblActivityName.Size = new System.Drawing.Size(146, 25);
            this.lblActivityName.TabIndex = 15;
            this.lblActivityName.Text = "ActivityName";
            // 
            // CmbMachine
            // 
            this.CmbMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMachine.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbMachine.FormattingEnabled = true;
            this.CmbMachine.Location = new System.Drawing.Point(97, 144);
            this.CmbMachine.Name = "CmbMachine";
            this.CmbMachine.Size = new System.Drawing.Size(286, 33);
            this.CmbMachine.TabIndex = 14;
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = true;
            this.lblMachine.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMachine.Location = new System.Drawing.Point(32, 147);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(95, 25);
            this.lblMachine.TabIndex = 13;
            this.lblMachine.Text = "Machine";
            // 
            // txtMOD
            // 
            this.txtMOD.Location = new System.Drawing.Point(99, 176);
            this.txtMOD.Name = "txtMOD";
            this.txtMOD.Size = new System.Drawing.Size(120, 31);
            this.txtMOD.TabIndex = 12;
            this.txtMOD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMOD_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "MOD";
            // 
            // dtpToTime
            // 
            this.dtpToTime.Enabled = false;
            this.dtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpToTime.Location = new System.Drawing.Point(254, 113);
            this.dtpToTime.Name = "dtpToTime";
            this.dtpToTime.Size = new System.Drawing.Size(131, 31);
            this.dtpToTime.TabIndex = 10;
            this.dtpToTime.Value = new System.DateTime(2010, 9, 13, 0, 0, 0, 0);
            // 
            // dtpFromTime
            // 
            this.dtpFromTime.Enabled = false;
            this.dtpFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFromTime.Location = new System.Drawing.Point(99, 113);
            this.dtpFromTime.Name = "dtpFromTime";
            this.dtpFromTime.Size = new System.Drawing.Size(120, 31);
            this.dtpFromTime.TabIndex = 9;
            this.dtpFromTime.Value = new System.DateTime(2010, 9, 13, 0, 0, 0, 0);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(99, 206);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(286, 105);
            this.txtComment.TabIndex = 8;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(24, 206);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(109, 25);
            this.lblComment.TabIndex = 7;
            this.lblComment.Text = "Comment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(99, 83);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(286, 33);
            this.cmbCategory.TabIndex = 6;
            this.cmbCategory.SelectionChangeCommitted += new System.EventHandler(this.cmbActivity_SelectionChangeCommitted);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(34, 86);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(103, 25);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Category";
            // 
            // FrmLineOEETransactionComments
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(431, 422);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLineOEETransactionComments";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmLineOEETransactionComments_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip_OEE.ResumeLayout(false);
            this.toolStrip_OEE.PerformLayout();
            this.panelbottom.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        # region Varibles
        BusinessFacade.Transactions.OEETransactionTest_Class OEETransactionTest_Class_Obj = new BusinessFacade.Transactions.OEETransactionTest_Class();
        BusinessFacade.Transactions.LineOEETransaction LineOEETransaction_Obj = new BusinessFacade.Transactions.LineOEETransaction();
        private int lineOEEComActivityID, MOD, colFromNumber, colToNumber, lno;
        private long lineOEEDetailID, lineHrsId;
        private DateTime dtFromTime, dtToTime;
        private string activityName;
        #endregion

        public FrmLineOEETransactionComments(string actName, int lineActivityID, string fromTime, string toTime, long DetailID, int mod, int colFromNumber, int colToNumber, int shiftID, int lno, long lineHrsId,DateTime TransDate)
        {
            //System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

            //this.dtFromTime =Convert.ToDateTime( Convert.ToDateTime(fromTime, enUS).ToString("MM/dd/yyyy"));

            //this.dtToTime =Convert.ToDateTime( Convert.ToDateTime(toTime, enUS).ToString("MM/dd/yyyy"));

            LineOEETransaction_Obj.lineHrsId = lineHrsId;
            this.lineHrsId = LineOEETransaction_Obj.lineHrsId;
            this.activityName = actName;
            this.lineOEEComActivityID = lineActivityID;
            this.lno = lno;

            DateTime dtts = TransDate;

            if (shiftID == 3)
            {
                //DateTime dt1 = Convert.ToDateTime(toTime);
                //DateTime dt1 = Convert.ToDateTime(toTime);

                //string strDateToTime = Convert.ToString(dt1);
                ////Check AM for add new date of third shift
                //if (strDateToTime.Contains("AM"))
                //    this.dtToTime = (Convert.ToDateTime(toTime)).AddDays(1);
                //else
                //    this.dtToTime = Convert.ToDateTime(toTime);

                if (toTime == "24:00")
                {
                 //   DateTime dt1 = Convert.ToDateTime("00:00");
                //    dtToTime = (Convert.ToDateTime("00:00")).AddDays(1);

                    string strDateToTime = Convert.ToDateTime(dtts).ToString("yyyy-MMM-dd ");
                    this.dtToTime = DateTime.Parse(strDateToTime + "00:00").AddDays(1);
                }
                else
                {
                    //DateTime dt1 = Convert.ToDateTime(toTime);
                    //string strDateToTime = Convert.ToString(dt1);
                    string strDateToTime = Convert.ToDateTime(dtts).ToString("yyyy-MMM-dd ");
                    dtToTime = DateTime.Parse(strDateToTime + toTime);

                    //Check AM for add new date of third shift
                    if (dtToTime.ToString().Contains("AM"))
                        this.dtToTime = (Convert.ToDateTime(dtToTime)).AddDays(1);
                    else
                        this.dtToTime = Convert.ToDateTime(dtToTime);
                }


                //DateTime dt2 = Convert.ToDateTime(fromTime);
                //string strDateFromTime = Convert.ToString(dt2);


                string strDate =  Convert.ToDateTime(dtts).ToString("yyyy-MMM-dd ");
                dtFromTime = DateTime.Parse(strDate + fromTime);

                if (dtFromTime.ToString().Contains("AM"))
                    this.dtFromTime = (Convert.ToDateTime(dtFromTime)).AddDays(1);
                else
                    this.dtFromTime = Convert.ToDateTime(dtFromTime);

            }
            else
            {
               // this.dtFromTime = Convert.ToDateTime(fromTime);
               // this.dtToTime = Convert.ToDateTime(toTime);

                string st = Convert.ToDateTime(dtts).ToString("yyyy-MMM-dd ");
                dtFromTime = DateTime.Parse(st + fromTime);
                dtToTime = DateTime.Parse(st + toTime); //Convert.ToDateTime(toTime);
            }
            this.lineOEEDetailID = DetailID;
            this.MOD = mod;
            this.colFromNumber = colFromNumber;
            this.colToNumber = colToNumber;
            //this.dtToTime = this.dtToTime.AddDays(1);  this.dtToTime = (Convert.ToDateTime(toTime)).AddDays(1);
            InitializeComponent();
        }

        private static Transactions.FrmLineOEETransactionComments FrmLineOEETransactionComments_Obj = null;
        public static Transactions.FrmLineOEETransactionComments GetInstance()
        {
            if (FrmLineOEETransactionComments_Obj == null)
            {
                FrmLineOEETransactionComments_Obj = new Transactions.FrmLineOEETransactionComments();
            }
            return FrmLineOEETransactionComments_Obj;
        }

        private void FrmLineOEETransactionComments_Load(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            try
            {
                //BindActivity();
                BindCategory();
                LineOEETransaction_Obj.activityID = lineOEEComActivityID;
                dtpFromTime.Value = dtFromTime;
                dtpToTime.Value = dtToTime;
                txtMOD.Text = Convert.ToString(MOD);
                txtActivityName.Text = Convert.ToString(activityName);

                if (Convert.ToInt32(lineOEEComActivityID) == 2)
                {
                    lblComment.Visible = false;
                    txtComment.Visible = false;
                    CmbMachine.Visible = false;
                    lblMachine.Visible = false;
                    btnReset.Visible = false;
                }
                else
                {
                    lblComment.Visible = true;
                    txtComment.Visible = true;
                    txtComment.Focus();
                    CmbMachine.Visible = true;
                    lblMachine.Visible = true;
                    btnReset.Visible = true;
                }
                //if (Convert.ToInt32(lineOEEComActivityID) == 3)
                //{
                //    lblComment.Visible = false;
                //    txtComment.Visible = false;
                //    btnReset.Visible = false;
                //}
                
                #region machine dropdown for Breakdown activity
                BindMachine();
                #endregion

                DisplayComment();

                DataTable dt = new DataTable();

                //LineOEETransaction_Obj.activityID = Convert.ToInt32(cmbCategory.SelectedValue);
                //LineOEETransaction_Obj.detailID = lineOEEDetailID;
                LineOEETransaction_Obj.categotyId = Convert.ToInt32(cmbCategory.SelectedValue);
                LineOEETransaction_Obj.colFromNumber = this.colFromNumber;
                LineOEETransaction_Obj.colToNumber = this.colToNumber;
                dt = LineOEETransaction_Obj.Select_LineOEEComment_DetailID_LineActivityID();
                if (dt.Rows.Count > 0)
                {
                    btnDelete.Visible = true;
                }
                else
                {
                    btnDelete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        LineOEEMachineMaster_Class LineOEEMachineMaster_Class_Obj = new LineOEEMachineMaster_Class();
        public void BindMachine()
        {
            # region bind machine dropdown
            LineOEEMachineMaster_Class_Obj.Lno = Convert.ToInt64(lno);
            DataTable Dtmachine = LineOEEMachineMaster_Class_Obj.Select_tblLineOEEMachineMaster_ByLno();
            if (Dtmachine.Rows.Count > 0)
            {
                if (Dtmachine.Rows.Count == 1)
                {
                    CmbMachine.DataSource = Dtmachine;
                    CmbMachine.DisplayMember = "MachineName";
                    CmbMachine.ValueMember = "Mid";
                }
                else
                {
                    DataRow dr;
                    dr = Dtmachine.NewRow();
                    dr["MachineName"] = "--Select--";
                    dr["Mid"] = "0";
                    Dtmachine.Rows.InsertAt(dr, 0);

                    if (Dtmachine.Rows.Count > 0)
                    {

                        CmbMachine.DataSource = Dtmachine;
                        CmbMachine.DisplayMember = "MachineName";
                        CmbMachine.ValueMember = "Mid";
                    }
                }
            }
            else
            {
                MessageBox.Show("Please add machine for that line.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Close();//comment by rohan



                ////DataRow dr;
                ////dr = Dtmachine.NewRow();
                ////dr["MachineName"] = "--Select--";
                ////dr["Mid"] = "0";
                ////Dtmachine.Rows.InsertAt(dr, 0);

                ////if (Dtmachine.Rows.Count > 0)
                ////{

                ////    CmbMachine.DataSource = Dtmachine;
                ////    CmbMachine.DisplayMember = "MachineName";
                ////    CmbMachine.ValueMember = "Mid";
                ////}
            }


            #endregion
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindCategory()
        {
            try
            {
                LineOEETransaction_Obj.activityID = lineOEEComActivityID;
                LineOEEFGMaster_Class LineOEEFGMaster_Class_Obj = new LineOEEFGMaster_Class();
                DataSet ds = new DataSet();
                ds = LineOEETransaction_Obj.Get_Category_By_Activity();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr;
                    dr = ds.Tables[0].NewRow();
                    dr["LineOEECategoryName"] = "--Select--";
                    dr["LineOEECategoryID"] = 0;
                    ds.Tables[0].Rows.InsertAt(dr, 0);

                    cmbCategory.DataSource = ds.Tables[0];
                    cmbCategory.DisplayMember = "LineOEECategoryName";
                    cmbCategory.ValueMember = "LineOEECategoryID";
                    cmbCategory.SelectedValue = 0;
                }
                else
                {
                    cmbCategory.Visible = false;
                    lblCategory.Visible = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindActivity()
        {
            try
            {
                DataRow dr;
                DataTable dt = new DataTable();

                dt = LineOEETransaction_Obj.SelectLineOEEActivityMaster();
                dr = dt.NewRow();
                dr["ActivityName"] = "--Select--";
                dr["LineActivityID"] = "0";
                dt.Rows.InsertAt(dr, 0);
                if (dt.Rows.Count > 0)
                {
                    cmbCategory.DataSource = dt;
                    cmbCategory.DisplayMember = "ActivityName";
                    cmbCategory.ValueMember = "LineActivityID";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void DisplayComment()
        {
            try
            {
                DataTable dt = new DataTable();
                LineOEETransaction_Obj.colFromNumber = this.colFromNumber;
                LineOEETransaction_Obj.colToNumber = this.colToNumber;
                LineOEETransaction_Obj.activityID = Convert.ToInt32(lineOEEComActivityID);
                LineOEETransaction_Obj.detailID = lineOEEDetailID;
                LineOEETransaction_Obj.lineHrsId = lineHrsId;
                dt = LineOEETransaction_Obj.Select_LineOEEComment_Comments();
                if (dt.Rows.Count > 0)
                {
                    txtMOD.Text = Convert.ToString(dt.Rows[0]["MOD"]);
                    txtComment.Text = Convert.ToString(dt.Rows[0]["CommentDesc"]);
                    //if (lineOEEComActivityID == 12)
                    //CmbMachine.SelectedValue = Convert.ToInt64(dt.Rows[0]["MachineID"]);
                    //CmbMachine.SelectedValue = Convert.ToString(dt.Rows[0]["MachineID"]);
                    CmbMachine.SelectedValue = string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["MachineID"])) ? "0" : Convert.ToString(dt.Rows[0]["MachineID"]);
                    cmbCategory.SelectedValue = string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["CategoryID"])) ? "0" : Convert.ToString(dt.Rows[0]["CategoryID"]);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LineOEETransaction_Obj.commentDesc = txtComment.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (txtComment.Text == "")
            //{
            //    MessageBox.Show("Please Enter Comment", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            if (txtMOD.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter MOD", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (lineOEEComActivityID == 2 || lineOEEComActivityID == 3)
            {
                LineOEETransaction_Obj.categotyId = Convert.ToInt32(cmbCategory.SelectedValue);
                LineOEETransaction_Obj.MaschineID = Convert.ToInt32(CmbMachine.SelectedValue);
            }
            else
	        {
                if (Convert.ToInt32(cmbCategory.SelectedValue) == 0 && cmbCategory.Visible==true)
                {
                    MessageBox.Show("Please Select Category", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (Convert.ToInt32(CmbMachine.SelectedValue) == 0)
                {
                    MessageBox.Show("Please Select Machine", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
	        }
            bool b;

           if(cmbCategory.SelectedIndex>0)
            LineOEETransaction_Obj.categotyId = Convert.ToInt32(cmbCategory.SelectedValue);
           if(CmbMachine.SelectedIndex>0)
            LineOEETransaction_Obj.MaschineID = Convert.ToInt32(CmbMachine.SelectedValue);

            LineOEETransaction_Obj.fromTime = dtpFromTime.Value;
            LineOEETransaction_Obj.toTime = dtpToTime.Value;
            //LineOEETransaction_Obj.categotyId = Convert.ToInt32(cmbCategory.SelectedValue);
            LineOEETransaction_Obj.detailID = lineOEEDetailID;
            LineOEETransaction_Obj.mod = Convert.ToInt32(txtMOD.Text.Trim());
            LineOEETransaction_Obj.commentDesc = txtComment.Text.Trim();
            LineOEETransaction_Obj.colFromNumber = this.colFromNumber;
            LineOEETransaction_Obj.colToNumber = this.colToNumber;
            b = LineOEETransaction_Obj.Insert_LineOEEComment();
            if (b == true)
            {
                MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtComment.Text = "";
                //txtComment.Focus();
                this.Close();
            }


            #region Old Logic

            //LineOEETransaction_Obj.fromTime = dtpFromTime.Value;
            //LineOEETransaction_Obj.toTime = dtpToTime.Value;

            //LineOEETransaction_Obj.mod = Convert.ToInt32(txtMOD.Text.Trim());
            //LineOEETransaction_Obj.commentDesc = txtComment.Text.Trim();
            //LineOEETransaction_Obj.colFromNumber = this.colFromNumber;
            //LineOEETransaction_Obj.colToNumber = this.colToNumber;
            //b = LineOEETransaction_Obj.Insert_LineOEEComment();
            //if (b == true)
            //{
            //    //MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //txtComment.Text = "";
            //    //txtComment.Focus();
            //    this.Close();
            //}
            // ////This is For Delete Logic
            //if (chkDelete.Checked)
            //{
            //    LineOEETransaction_Obj.fromTime = dtpFromTime.Value;
            //    LineOEETransaction_Obj.toTime = dtpToTime.Value;
            //    LineOEETransaction_Obj.activityID = Convert.ToInt32(cmbActivity.SelectedValue);
            //    LineOEETransaction_Obj.detailID = lineOEEDetailID;
            //    LineOEETransaction_Obj.mod = Convert.ToInt32(txtMOD.Text.Trim());
            //    LineOEETransaction_Obj.commentDesc = txtComment.Text.Trim();
            //    LineOEETransaction_Obj.colFromNumber = this.colFromNumber;
            //    LineOEETransaction_Obj.colToNumber = this.colToNumber;
            //    b = LineOEETransaction_Obj.Delete_LineOEEComment();
            //    if (b == true)
            //    {
            //        //MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtComment.Text = "";
            //        txtComment.Focus();
            //        this.Close();
            //    }
            //}
            //else
            //{

            //    LineOEETransaction_Obj.fromTime = dtpFromTime.Value;
            //    LineOEETransaction_Obj.toTime = dtpToTime.Value;
            //    LineOEETransaction_Obj.activityID = Convert.ToInt32(cmbActivity.SelectedValue);
            //    LineOEETransaction_Obj.detailID = lineOEEDetailID;
            //    LineOEETransaction_Obj.mod = Convert.ToInt32(txtMOD.Text.Trim());
            //    LineOEETransaction_Obj.commentDesc = txtComment.Text.Trim();
            //    LineOEETransaction_Obj.colFromNumber = this.colFromNumber;
            //    LineOEETransaction_Obj.colToNumber = this.colToNumber;
            //    b = LineOEETransaction_Obj.Insert_LineOEEComment();
            //    if (b == true)
            //    {
            //       // MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        txtComment.Text = "";
            //        txtComment.Focus();
            //        this.Close();
            //    }
            //}
            #endregion


        }

        private void txtMOD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 58 || e.KeyChar < 49)
            {
                //MessageBox.Show("Please Enter Number Only", "Error");
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))// && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            //// Only 0-9 and dot(.) allowed
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            //{
            //    e.Handled = true;
            //}
            //if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}      
        }

        private void cmbActivity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ////comment for demo
                //if (Convert.ToInt32(cmbCategory.SelectedValue) == 2)
                //{
                //    lblComment.Visible = false;
                //    txtComment.Visible = false;
                //    btnReset.Visible = false;
                //}
                //else
                //{
                //    lblComment.Visible = true;
                //    txtComment.Visible = true;
                //    txtComment.Focus();
                //    btnReset.Visible = true;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool b;
            LineOEETransaction_Obj.fromTime = dtpFromTime.Value;
            LineOEETransaction_Obj.toTime = dtpToTime.Value;
            LineOEETransaction_Obj.activityID = Convert.ToInt32(lineOEEComActivityID);
            LineOEETransaction_Obj.detailID = lineOEEDetailID;
            LineOEETransaction_Obj.mod = Convert.ToInt32(txtMOD.Text.Trim());
            LineOEETransaction_Obj.commentDesc = txtComment.Text.Trim();
            LineOEETransaction_Obj.colFromNumber = this.colFromNumber;
            LineOEETransaction_Obj.colToNumber = this.colToNumber;
            LineOEETransaction_Obj.categotyId = Convert.ToInt32(cmbCategory.SelectedValue);
            LineOEETransaction_Obj.MaschineID = Convert.ToInt32(CmbMachine.SelectedValue);
            LineOEETransaction_Obj.lineHrsId = lineHrsId;
            b = LineOEETransaction_Obj.Delete_LineOEEComment();
            if (b == true)
            {
                //MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //txtComment.Text = "";
                //txtComment.Focus();
                this.Close();
            }
        }

    }
}
