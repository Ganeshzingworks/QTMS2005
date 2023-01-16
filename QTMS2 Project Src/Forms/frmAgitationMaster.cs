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
    /// Summary description for frmAgitationMaster.
    /// </summary>
    public class frmAgitationMaster : System.Windows.Forms.Form
    {
        DataSet dsList = new DataSet();

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Button BtnSave;

        # region Varibles

        AgitationMaster_Class AgitationMaster_Class_Obj = new AgitationMaster_Class();
        bool Modify = false;
        # endregion
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnModify;
        private System.Windows.Forms.Button BtnDelete;
        private Panel panelOuter;
        private Panel panelBottom;
        private Panel panelFill;
        private Panel panelTop;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButtonClose;
        private Label label2;
        private ComboBox cmbAgitation;
        private Label label3;
        private TextBox txtRpm;
        int AgitationNo = 0;
        private ListBox LstAgitation;
        private Label lblSearch;
        private TextBox txtSearch;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmAgitationMaster()
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
            //  frmAgitationMaster_Obj = null;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbAgitation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRpm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.LstAgitation = new System.Windows.Forms.ListBox();
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
            this.groupBox1.Controls.Add(this.cmbAgitation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRpm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(383, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 230);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbAgitation
            // 
            this.cmbAgitation.FormattingEnabled = true;
            this.cmbAgitation.Items.AddRange(new object[] {
            "Scrapper",
            "Impeller",
            "Emulsifier",
            "Vac"});
            this.cmbAgitation.Location = new System.Drawing.Point(283, 147);
            this.cmbAgitation.Name = "cmbAgitation";
            this.cmbAgitation.Size = new System.Drawing.Size(305, 33);
            this.cmbAgitation.TabIndex = 8;
            this.cmbAgitation.SelectionChangeCommitted += new System.EventHandler(this.cmbAgitation_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 38);
            this.label3.TabIndex = 7;
            this.label3.Text = "Agitation Types";
            // 
            // txtRpm
            // 
            this.txtRpm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRpm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRpm.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRpm.Location = new System.Drawing.Point(283, 93);
            this.txtRpm.MaxLength = 50;
            this.txtRpm.Name = "txtRpm";
            this.txtRpm.Size = new System.Drawing.Size(247, 30);
            this.txtRpm.TabIndex = 6;
            this.txtRpm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRpm_KeyPress);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "RPM";
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTime.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.Location = new System.Drawing.Point(283, 34);
            this.txtTime.MaxLength = 50;
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(247, 30);
            this.txtTime.TabIndex = 4;
            this.txtTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTime_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Timefield";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnModify);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(418, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(918, 142);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnDelete.Enabled = false;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDelete.Location = new System.Drawing.Point(311, 51);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(126, 41);
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
            this.BtnModify.Location = new System.Drawing.Point(156, 51);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(125, 41);
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
            this.BtnReset.Location = new System.Drawing.Point(19, 51);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(126, 41);
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
            this.BtnExit.Location = new System.Drawing.Point(597, 51);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(126, 41);
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
            this.BtnSave.Location = new System.Drawing.Point(462, 51);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(126, 41);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(863, 391);
            this.panelOuter.TabIndex = 3;
            this.panelOuter.Paint += new System.Windows.Forms.PaintEventHandler(this.panelOuter_Paint);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(861, 45);
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
            this.toolStrip1.Size = new System.Drawing.Size(861, 45);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(150, 42);
            this.toolStripLabel1.Text = "AgitationMaster";
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonClose.BackColor = System.Drawing.Color.White;
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = global::QTMS.Properties.Resources.cancel;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(23, 42);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFill);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, -67);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(861, 456);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.LstAgitation);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(861, 456);
            this.panelFill.TabIndex = 0;
            this.panelFill.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFill_Paint);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(5, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(98, 25);
            this.lblSearch.TabIndex = 18;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(5, 48);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(369, 31);
            this.txtSearch.TabIndex = 17;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // LstAgitation
            // 
            this.LstAgitation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LstAgitation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstAgitation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstAgitation.ItemHeight = 25;
            this.LstAgitation.Location = new System.Drawing.Point(5, 88);
            this.LstAgitation.Name = "LstAgitation";
            this.LstAgitation.Size = new System.Drawing.Size(369, 302);
            this.LstAgitation.TabIndex = 3;
            this.LstAgitation.DoubleClick += new System.EventHandler(this.LstAgitation_DoubleClick);
            this.LstAgitation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstAgitation_KeyPress);
            // 
            // frmAgitationMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(11, 24);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(863, 391);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgitationMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agitation Master";
            this.Load += new System.EventHandler(this.frmAgitationMaster_Load);
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

        private static frmAgitationMaster frmAgitationMaster_Obj = null;
        public static frmAgitationMaster GetInstance()
        {
            if (frmAgitationMaster_Obj == null)
            {
                frmAgitationMaster_Obj = new frmAgitationMaster();
            }
            return frmAgitationMaster_Obj;
        }

        private void frmAgitationMaster_Load(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            txtTime.Focus();
            cmbAgitation.Text = "";

            Bind_List();
        }

        private void Bind_List()
        {
            try
            {

                dsList = AgitationMaster_Class_Obj.Select_tblAgitationRpm_time();

                LstAgitation.DataSource = dsList.Tables[0];
                // string Agitationdata =  ds.Tables[0].Rows[0]["Timefield"].ToString();
                //Agitationdata = Agitationdata +'('+ ds.Tables[0].Rows[0]["rpm"].ToString()+')';
                LstAgitation.DisplayMember = "Timefield";
                LstAgitation.ValueMember = "Id";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panelFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (txtTime.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Time field ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTime.Text = "";
                    txtTime.Focus();
                    return;

                }

                if (cmbAgitation.Text != "Vac")
                {
                    if (txtRpm.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter RPM field ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtRpm.Text = "";
                        txtRpm.Focus();
                        return;

                    }
                }

                txtTime_Leave(sender, e);
                txtRpm_Leave(sender, e);
                if (Modify == false)
                {
                    AgitationMaster_Class_Obj.timefield = txtTime.Text.Trim();
                    if (txtRpm.Text.Trim() != "")
                    {
                        string rpm = txtRpm.Text.Trim();
                        string rpm1 = "(" + rpm + "rpm" + ")";
                        AgitationMaster_Class_Obj.rpm = rpm1;
                    }
                    else
                        AgitationMaster_Class_Obj.rpm = "";
                    AgitationMaster_Class_Obj.agitationTypes = cmbAgitation.Text;
                    AgitationMaster_Class_Obj.agitationNo = AgitationNo;


                    bool b = AgitationMaster_Class_Obj.Insert_tblAgitationRpm();
                    if (b == true)
                    {
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTime.Text = "";
                        txtRpm.Text = "";
                        txtTime.Focus();
                        Bind_List();

                    }
                }

                else
                {


                    AgitationMaster_Class_Obj.timefield = txtTime.Text.Trim();
                    if (txtRpm.Text.Trim() != "")
                    {
                        string rpm = txtRpm.Text.Trim();

                        string rpm1 = "(" + rpm + "rpm" + ")";

                        AgitationMaster_Class_Obj.rpm = rpm1;
                    }
                    else
                        AgitationMaster_Class_Obj.rpm = "";

                    AgitationMaster_Class_Obj.agitationTypes = cmbAgitation.Text;

                    AgitationMaster_Class_Obj.agitationNo = AgitationNo;

                    AgitationMaster_Class_Obj.id = Convert.ToInt32(LstAgitation.SelectedValue.ToString());

                    if (AgitationMaster_Class_Obj.id == 0)
                    {
                        MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    bool b = AgitationMaster_Class_Obj.Update_tblAnnexTankMaster();
                    if (b == true)
                    {
                        MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTime.Text = "";
                        txtRpm.Text = "";
                        txtTime.Focus();
                        Bind_List();

                        Modify = false;
                    }



                }

            }
            catch
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTime.Focus();
                txtRpm.Text = "";
                txtRpm.Text = "";
            }
        }










        private void txtTime_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtTime.Text = textInfo.ToTitleCase(txtTime.Text);
        }



        private void txtRpm_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtRpm.Text = textInfo.ToTitleCase(txtRpm.Text);
        }

        private void cmbAgitation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbAgitation.SelectedItem.ToString() == "Scrapper")
            {
                AgitationNo = 1;


            }
            else if (cmbAgitation.SelectedItem.ToString() == "Impeller")
            {
                AgitationNo = 2;


            }
            else if (cmbAgitation.SelectedItem.ToString() == "Emulsifier")
            {
                AgitationNo = 3;


            }
            else
            {
                AgitationNo = 4;

            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Only 0-9 and a-z and A-Z allowed
            if (e.KeyChar != Convert.ToChar(8))
            {
                if (((e.KeyChar >= Convert.ToChar(48)) && (e.KeyChar <= Convert.ToChar(57))) || (e.KeyChar >= Convert.ToChar(65)) && (e.KeyChar <= Convert.ToChar(90)) || (e.KeyChar >= Convert.ToChar(97)) && (e.KeyChar <= Convert.ToChar(122)) || ((e.KeyChar == Convert.ToChar(46)) || (e.KeyChar == Convert.ToChar(45))))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtRpm_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Only 0-9 and a-z and A-Z allowed
            if (e.KeyChar != Convert.ToChar(8))
            {
                if (((e.KeyChar >= Convert.ToChar(48)) && (e.KeyChar <= Convert.ToChar(57))) || (e.KeyChar >= Convert.ToChar(65)) && (e.KeyChar <= Convert.ToChar(90)) || (e.KeyChar >= Convert.ToChar(97)) && (e.KeyChar <= Convert.ToChar(122)))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }

        }





        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void LstAgitation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // txtSearch.Text = Convert.ToString(LstAgitation .Text);
                Modify = true;
                DataSet ds = new DataSet();
                AgitationMaster_Class_Obj.id = Convert.ToInt32(LstAgitation.SelectedValue.ToString());
                ds = AgitationMaster_Class_Obj.Select_tblAgitationRpm_id();
                txtTime.Text = ds.Tables[0].Rows[0]["Timefield"].ToString();

                string agition = ds.Tables[0].Rows[0]["rpm"].ToString();
                string agition1 = agition.TrimStart('(');
                string agition2 = agition1.Replace("rpm)", "");
                txtRpm.Text = agition2.ToString();
                cmbAgitation.Text = ds.Tables[0].Rows[0]["AgitationTypes"].ToString();

                BtnDelete.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            LstAgitation.Enabled = true;
            Modify = true;

            LstAgitation_DoubleClick(sender, e);
            txtTime.Focus();
            BtnDelete.Enabled = true;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtTime.Text = "";
            txtTime.Focus();
            txtRpm.Text = "";
            BtnDelete.Enabled = false;
            cmbAgitation.SelectedIndex = 0;
            Modify = false;

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                AgitationMaster_Class_Obj.id = Convert.ToInt32(LstAgitation.SelectedValue.ToString());

                if (AgitationMaster_Class_Obj.id > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = AgitationMaster_Class_Obj.Delete_tblAgitationRpm();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTime.Text = "";
                            txtTime.Focus();
                            txtRpm.Text = "";
                            BtnDelete.Enabled = false;
                            Bind_List();
                            Modify = false;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("sorry You Can't Delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Modify = false;
                txtTime.Text = "";
                txtTime.Focus();
                txtRpm.Text = "";
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "Timefield like  '" + searchString + "%'";
            LstAgitation.DataSource = dsList.Tables[0];

            LstAgitation.DisplayMember = "Timefield";
            LstAgitation.ValueMember = "Id";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    txtSearch.Text = Convert.ToString(LstAgitation.Text);
                    Modify = true;
                    DataSet ds = new DataSet();
                    AgitationMaster_Class_Obj.id = Convert.ToInt32(LstAgitation.SelectedValue.ToString());
                    ds = AgitationMaster_Class_Obj.Select_tblAgitationRpm_id();
                    txtTime.Text = ds.Tables[0].Rows[0]["Timefield"].ToString();

                    string agition = ds.Tables[0].Rows[0]["rpm"].ToString();
                    string agition1 = agition.TrimStart('(');
                    string agition2 = agition1.Replace("rpm)", "");
                    txtRpm.Text = agition2.ToString();
                    cmbAgitation.Text = ds.Tables[0].Rows[0]["AgitationTypes"].ToString();

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
                    LstAgitation.Select();
                    LstAgitation.SelectedIndex = LstAgitation.SelectedIndex + 1;
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
                    LstAgitation.Select();
                    LstAgitation.SelectedIndex = LstAgitation.SelectedIndex - 1;
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

        private void LstAgitation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    txtSearch.Text = Convert.ToString(LstAgitation.Text);
                    Modify = true;
                    DataSet ds = new DataSet();
                    AgitationMaster_Class_Obj.id = Convert.ToInt32(LstAgitation.SelectedValue.ToString());
                    ds = AgitationMaster_Class_Obj.Select_tblAgitationRpm_id();
                    txtTime.Text = ds.Tables[0].Rows[0]["Timefield"].ToString();

                    string agition = ds.Tables[0].Rows[0]["rpm"].ToString();
                    string agition1 = agition.TrimStart('(');
                    string agition2 = agition1.Replace("rpm)", "");
                    txtRpm.Text = agition2.ToString();
                    cmbAgitation.Text = ds.Tables[0].Rows[0]["AgitationTypes"].ToString();

                    BtnDelete.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panelOuter_Paint(object sender, PaintEventArgs e)
        {

        }




    }
}
