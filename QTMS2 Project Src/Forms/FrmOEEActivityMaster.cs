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
    public partial class FrmOEEActivityMaster : System.Windows.Forms.Form
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
        private Label label_Activities;
        private TextBox txtActivity;
        private ListBox LstActivities;
        private CheckBox chkLastActivity;
        private CheckBox ChkKgs;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmOEEActivityMaster()
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

            frmOEEActivityMaster_Obj = null;
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
            this.LstActivities = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLastActivity = new System.Windows.Forms.CheckBox();
            this.txtActivity = new System.Windows.Forms.TextBox();
            this.label_Activities = new System.Windows.Forms.Label();
            this.ChkKgs = new System.Windows.Forms.CheckBox();
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
            this.panelOuter.Size = new System.Drawing.Size(755, 296);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip_OEE);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(753, 30);
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
            this.toolStrip_OEE.Size = new System.Drawing.Size(753, 30);
            this.toolStrip_OEE.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(118, 27);
            this.toolStripLabel1.Text = "OEE Activity Master";
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
            this.panelbottom.Controls.Add(this.LstActivities);
            this.panelbottom.Controls.Add(this.groupBox2);
            this.panelbottom.Controls.Add(this.groupBox1);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottom.Location = new System.Drawing.Point(0, 0);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(753, 294);
            this.panelbottom.TabIndex = 0;
            // 
            // LstActivities
            // 
            this.LstActivities.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LstActivities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstActivities.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstActivities.ItemHeight = 16;
            this.LstActivities.Location = new System.Drawing.Point(11, 41);
            this.LstActivities.Name = "LstActivities";
            this.LstActivities.Size = new System.Drawing.Size(251, 242);
            this.LstActivities.TabIndex = 13;
            this.LstActivities.DoubleClick += new System.EventHandler(this.LstActivities_DoubleClick);
            this.LstActivities.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstActivities_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnModify);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Location = new System.Drawing.Point(279, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 60);
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
            this.BtnDelete.Location = new System.Drawing.Point(194, 17);
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
            this.BtnModify.Location = new System.Drawing.Point(108, 17);
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
            this.BtnReset.Location = new System.Drawing.Point(24, 17);
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
            this.BtnExit.Location = new System.Drawing.Point(366, 16);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(80, 27);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click_1);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(280, 17);
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
            this.groupBox1.Controls.Add(this.ChkKgs);
            this.groupBox1.Controls.Add(this.chkLastActivity);
            this.groupBox1.Controls.Add(this.txtActivity);
            this.groupBox1.Controls.Add(this.label_Activities);
            this.groupBox1.Location = new System.Drawing.Point(279, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 181);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // chkLastActivity
            // 
            this.chkLastActivity.AutoSize = true;
            this.chkLastActivity.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.chkLastActivity.Location = new System.Drawing.Point(128, 86);
            this.chkLastActivity.Name = "chkLastActivity";
            this.chkLastActivity.Size = new System.Drawing.Size(160, 20);
            this.chkLastActivity.TabIndex = 13;
            this.chkLastActivity.Text = "Set As Last Activity";
            this.chkLastActivity.UseVisualStyleBackColor = true;
            // 
            // txtActivity
            // 
            this.txtActivity.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.txtActivity.Location = new System.Drawing.Point(128, 58);
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.Size = new System.Drawing.Size(232, 23);
            this.txtActivity.TabIndex = 12;
            this.txtActivity.Leave += new System.EventHandler(this.txtActivity_Leave);
            // 
            // label_Activities
            // 
            this.label_Activities.AutoSize = true;
            this.label_Activities.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Activities.Location = new System.Drawing.Point(50, 61);
            this.label_Activities.Name = "label_Activities";
            this.label_Activities.Size = new System.Drawing.Size(59, 16);
            this.label_Activities.TabIndex = 3;
            this.label_Activities.Text = "Activity";
            // 
            // ChkKgs
            // 
            this.ChkKgs.AutoSize = true;
            this.ChkKgs.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.ChkKgs.Location = new System.Drawing.Point(128, 112);
            this.ChkKgs.Name = "ChkKgs";
            this.ChkKgs.Size = new System.Drawing.Size(50, 20);
            this.ChkKgs.TabIndex = 14;
            this.ChkKgs.Text = "Kgs";
            this.ChkKgs.UseVisualStyleBackColor = true;
            // 
            // FrmOEEActivityMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(755, 296);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOEEActivityMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OEE Activity Master";
            this.Load += new System.EventHandler(this.FrmOEEActivityMaster_Load);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip_OEE.ResumeLayout(false);
            this.toolStrip_OEE.PerformLayout();
            this.panelbottom.ResumeLayout(false);
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

        private static Forms.FrmOEEActivityMaster frmOEEActivityMaster_Obj = null;
        public static Forms.FrmOEEActivityMaster GetInstance()
        {
            if (frmOEEActivityMaster_Obj == null)
            {
                frmOEEActivityMaster_Obj = new Forms.FrmOEEActivityMaster();
            }
            return frmOEEActivityMaster_Obj;
        }

        private void FrmOEEActivityMaster_Load(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_Activity();           

        }

        public void Bind_Activity()
        {
            try
            {
               
                DtList = OEETransactionTest_Class_Obj.Select_tblOEEActivityMaster();
                if (DtList.Rows.Count > 0)
                {
                    LstActivities.DataSource = DtList;
                    LstActivities.ValueMember = "ActivityId";
                    LstActivities.DisplayMember = "Activity";
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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LstActivities_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               // txtSearch.Text = Convert.ToString(LstActivities.Text);
                txtActivity.Text = LstActivities.Text.ToString();
                OEETransactionTest_Class_Obj.activityid = Convert.ToInt64(LstActivities.SelectedValue.ToString());

             
                long LastActivityId=OEETransactionTest_Class_Obj.Select_tblOEEActivityMaster_LastActivity();

                if (Convert.ToInt64(LstActivities.SelectedValue.ToString()) == LastActivityId)
                {
                    chkLastActivity.Checked = true;
                    chkLastActivity.Enabled = true;
                }
                else if (LastActivityId == 0)
                {
                    chkLastActivity.Checked = false;
                    chkLastActivity.Enabled = true;
                }
                else
                {
                    chkLastActivity.Checked = false;
                    chkLastActivity.Enabled = false;
                }

                DataTable dt = OEETransactionTest_Class_Obj.Select_tblOEEActivityMaster_ByActivityID();
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Kgs"].ToString() == "1")
                        ChkKgs.Checked = true;
                    else
                        ChkKgs.Checked = false;
                }

                BtnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //Bind_Activity();
            //txtSearch.Text = "";
            LstActivities.ClearSelected();
            txtActivity.Text = "";
            txtActivity.Focus();
            OEETransactionTest_Class_Obj.activityid = 0;
            chkLastActivity.Checked = false;
            chkLastActivity.Enabled = false;
            BtnDelete.Enabled = false;
            Modify = false;
            ChkKgs.Checked = false;
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            Modify = true;
            LstActivities_DoubleClick(sender, e);
        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    OEETransactionTest_Class_Obj.activityName = txtActivity.Text;
                    OEETransactionTest_Class_Obj.lastActivity = chkLastActivity.Checked;
                    if (ChkKgs.Checked == true)
                        OEETransactionTest_Class_Obj.kgs = 1;
                    else
                        OEETransactionTest_Class_Obj.kgs = 0;
                    if (Modify)
                    {
                        OEETransactionTest_Class_Obj.Update_OEEMFGActivityMaster();
                        MessageBox.Show("Updated Successfully");
                    }
                    else
                    {
                        OEETransactionTest_Class_Obj.Insert_OEEMFGActivityMaster();
                        MessageBox.Show("Saved Successfully"); 
                    }
                    BtnReset_Click(sender, e);
                    Bind_Activity();
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
                if (txtActivity.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Activity");
                    txtActivity.Focus();
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
                    if (OEETransactionTest_Class_Obj.activityid != 0)
                    {
                        OEETransactionTest_Class_Obj.Delete_OEEActivityMaster();
                        MessageBox.Show("Deleted Successfully");
                        BtnReset_Click(sender, e);
                        Bind_Activity();
                    }
                    else
                    {
                        MessageBox.Show("Please select activity to delete");
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
            txtActivity.Text = textInfo.ToTitleCase(txtActivity.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //string searchString = txtSearch.Text;
            //DtList.DefaultView.RowFilter = "ActivityId like  '" + searchString + "%'";
            //LstActivities.DataSource =DtList;

            //LstActivities.ValueMember = "ActivityId";
            //LstActivities.DisplayMember = "Activity";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    try
            //    {
            //        txtSearch.Text = Convert.ToString(LstActivities.Text);
            //        txtActivity.Text = LstActivities.Text.ToString();
            //        OEETransactionTest_Class_Obj.activityid = Convert.ToInt64(LstActivities.SelectedValue.ToString());

            //        long LastActivityId = OEETransactionTest_Class_Obj.Select_tblOEEActivityMaster_LastActivity();

            //        if (Convert.ToInt64(LstActivities.SelectedValue.ToString()) == LastActivityId)
            //        {
            //            chkLastActivity.Checked = true;
            //            chkLastActivity.Enabled = true;
            //        }
            //        else if (LastActivityId == 0)
            //        {
            //            chkLastActivity.Checked = false;
            //            chkLastActivity.Enabled = true;
            //        }
            //        else
            //        {
            //            chkLastActivity.Checked = false;
            //            chkLastActivity.Enabled = false;
            //        }
            //        BtnDelete.Enabled = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{

            //    if (e.KeyCode == Keys.Down)
            //    {
            //        LstActivities.Select();
            //        LstActivities.SelectedIndex = LstActivities.SelectedIndex + 1;
            //    }
            //}
            //catch (ArgumentOutOfRangeException exAOR)
            //{

            //    MessageBox.Show("This is last item", "QTMS");
            //    //   MessageBox.Show("This is last item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{

            //    if (e.KeyCode == Keys.Up)
            //    {
            //        LstActivities.Select();
            //        LstActivities.SelectedIndex = LstActivities.SelectedIndex - 1;
            //    }
            //}
            //catch (ArgumentOutOfRangeException exAOR)
            //{
            //    //  MessageBox.Show("This is last item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    MessageBox.Show("This is last item", "QTMS");
            //}
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
           // txtSearch.SelectAll();
        }

        private void LstActivities_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    try
            //    {
            //        txtSearch.Text = Convert.ToString(LstActivities.Text);
            //        txtActivity.Text = LstActivities.Text.ToString();
            //        OEETransactionTest_Class_Obj.activityid = Convert.ToInt64(LstActivities.SelectedValue.ToString());

            //        long LastActivityId = OEETransactionTest_Class_Obj.Select_tblOEEActivityMaster_LastActivity();

            //        if (Convert.ToInt64(LstActivities.SelectedValue.ToString()) == LastActivityId)
            //        {
            //            chkLastActivity.Checked = true;
            //            chkLastActivity.Enabled = true;
            //        }
            //        else if (LastActivityId == 0)
            //        {
            //            chkLastActivity.Checked = false;
            //            chkLastActivity.Enabled = true;
            //        }
            //        else
            //        {
            //            chkLastActivity.Checked = false;
            //            chkLastActivity.Enabled = false;
            //        }
            //        BtnDelete.Enabled = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }          

    }
}
