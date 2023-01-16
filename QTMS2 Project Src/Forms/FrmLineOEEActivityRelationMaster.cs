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
using BusinessFacade.Transactions;

namespace QTMS.Forms
{
    /// <summary>
    /// Summary description for FrmTestMaster.
    /// </summary>
    public partial class FrmLineOEEActivityRelationMaster : System.Windows.Forms.Form
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_Activities;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnModify;
        private System.Windows.Forms.Button BtnDelete;
        private Label label_Categories;
        private Panel panelOuter;
        private Panel panelFill;
        private Panel panelTop;
        private ToolStrip toolStrip_OEE;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButtonClose;
        private CheckedListBox ChkLstActivity;
        private ComboBox cmb_Categories;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmLineOEEActivityRelationMaster()
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

            frmAct_CatRelation_Obj = null;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_Categories = new System.Windows.Forms.ComboBox();
            this.ChkLstActivity = new System.Windows.Forms.CheckedListBox();
            this.label_Categories = new System.Windows.Forms.Label();
            this.label_Activities = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnModify = new System.Windows.Forms.Button();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip_OEE = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip_OEE.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cmb_Categories);
            this.groupBox1.Controls.Add(this.ChkLstActivity);
            this.groupBox1.Controls.Add(this.label_Categories);
            this.groupBox1.Controls.Add(this.label_Activities);
            this.groupBox1.Location = new System.Drawing.Point(14, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmb_Categories
            // 
            this.cmb_Categories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Categories.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Categories.FormattingEnabled = true;
            this.cmb_Categories.Location = new System.Drawing.Point(163, 26);
            this.cmb_Categories.Name = "cmb_Categories";
            this.cmb_Categories.Size = new System.Drawing.Size(280, 22);
            this.cmb_Categories.TabIndex = 12;
            this.cmb_Categories.SelectionChangeCommitted += new System.EventHandler(this.cmb_Categories_SelectionChangeCommitted);
            this.cmb_Categories.SelectedIndexChanged += new System.EventHandler(this.cmb_Categories_SelectedIndexChanged);
            // 
            // ChkLstActivity
            // 
            this.ChkLstActivity.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ChkLstActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChkLstActivity.CheckOnClick = true;
            this.ChkLstActivity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkLstActivity.Location = new System.Drawing.Point(163, 66);
            this.ChkLstActivity.Name = "ChkLstActivity";
            this.ChkLstActivity.Size = new System.Drawing.Size(280, 164);
            this.ChkLstActivity.TabIndex = 11;
            // 
            // label_Categories
            // 
            this.label_Categories.AutoSize = true;
            this.label_Categories.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Categories.Location = new System.Drawing.Point(32, 27);
            this.label_Categories.Name = "label_Categories";
            this.label_Categories.Size = new System.Drawing.Size(125, 16);
            this.label_Categories.TabIndex = 8;
            this.label_Categories.Text = "Select Categories";
            // 
            // label_Activities
            // 
            this.label_Activities.AutoSize = true;
            this.label_Activities.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Activities.Location = new System.Drawing.Point(32, 66);
            this.label_Activities.Name = "label_Activities";
            this.label_Activities.Size = new System.Drawing.Size(59, 16);
            this.label_Activities.TabIndex = 3;
            this.label_Activities.Text = "Activity";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
            this.groupBox2.Controls.Add(this.BtnModify);
            this.groupBox2.Location = new System.Drawing.Point(14, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 60);
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
            this.BtnDelete.Location = new System.Drawing.Point(198, 17);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(95, 27);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(94, 17);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(95, 27);
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
            this.BtnExit.Location = new System.Drawing.Point(406, 17);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(95, 27);
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
            this.BtnSave.Location = new System.Drawing.Point(302, 17);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(95, 27);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "&Set Relations";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModify.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModify.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnModify.Location = new System.Drawing.Point(488, 17);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(80, 27);
            this.BtnModify.TabIndex = 6;
            this.BtnModify.Text = "&Modify";
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Visible = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelFill);
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(613, 351);
            this.panelOuter.TabIndex = 3;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Location = new System.Drawing.Point(0, 33);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(614, 323);
            this.panelFill.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip_OEE);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(611, 30);
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
            this.toolStrip_OEE.Size = new System.Drawing.Size(611, 30);
            this.toolStrip_OEE.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(168, 27);
            this.toolStripLabel1.Text = "OEE Activity Relation Master";
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
            // FrmLineOEEActivityRelationMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(613, 351);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLineOEEActivityRelationMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OEE Activity Relation Master";
            this.Load += new System.EventHandler(this.FrmTestMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip_OEE.ResumeLayout(false);
            this.toolStrip_OEE.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        # region Varibles        
        BusinessFacade.Transactions.OEETransactionTest_Class OEETransactionTest_Class_Obj = new BusinessFacade.Transactions.OEETransactionTest_Class();
        LineOEETransaction LineOEETransaction_obj = new LineOEETransaction();
        #endregion

        private static Forms.FrmLineOEEActivityRelationMaster frmAct_CatRelation_Obj = null;
        public static Forms.FrmLineOEEActivityRelationMaster GetInstance()
        {
            if (frmAct_CatRelation_Obj == null)
            {
                frmAct_CatRelation_Obj = new Forms.FrmLineOEEActivityRelationMaster();
            }
            return frmAct_CatRelation_Obj;
        }

        private void FrmTestMaster_Load(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_Activity();
            Bind_Categories();            
        }
        public void Bind_Activity()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = LineOEETransaction_obj.Select_tblLineOEEActivityMaster_Active();               
                if (Dt.Rows.Count > 0)
                {
                    ChkLstActivity.DataSource = Dt;
                    ChkLstActivity.ValueMember = "LineActivityID";
                    ChkLstActivity.DisplayMember = "ActivityName";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_Categories()
        {
            try
            {
                DataRow dr;
                DataTable Dt = new DataTable();
                Dt = LineOEETransaction_obj.Select_tblLineOEECategoryMaster().Tables[0];
                dr = Dt.NewRow();
                dr["LineOEECategoryName"] = "--Select--";
                dr["LineOEECategoryID"] = "0";
                Dt.Rows.InsertAt(dr, 0);
                if (Dt.Rows.Count > 0)
                {
                    cmb_Categories.DataSource = Dt;
                    cmb_Categories.DisplayMember = "LineOEECategoryName";
                    cmb_Categories.ValueMember = "LineOEECategoryID";
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

        private void ChkLstWA_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ChkLstActivity.Items.Count; i++)
            {
                ChkLstActivity.SetItemChecked(i, false);
            }
            ChkLstActivity.SetItemChecked(ChkLstActivity.SelectedIndex, true);
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    LineOEETransaction_obj.lineoeecategoryid = Convert.ToInt32(cmb_Categories.SelectedValue);
                    DeleteCategory();
                    for (int i = 0; i < ChkLstActivity.Items.Count; i++)
                    {                       
                        if (ChkLstActivity.GetItemChecked(i) == true)
                        {
                            ChkLstActivity.SetSelected(i, true);
                            int ActiId = Convert.ToInt32(ChkLstActivity.SelectedValue);
                            LineOEETransaction_obj.activityID = ActiId;
                            LineOEETransaction_obj.Insert_tblLineOEEActivityCategoryRelation();
                        }
                    }

                    MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsValid()
        {
            try
            {
                 if (cmb_Categories.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Category ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmb_Categories.Focus();
                    return false ;
                }
                if (ChkLstActivity.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please Select Atleast Activity ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ChkLstActivity.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                cmb_Categories.SelectedIndex = 0;
                ResetAllActivities();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetAllActivities()
        {
            try
            {
                for (int i = 0; i < ChkLstActivity.Items.Count; i++)
                {
                    ChkLstActivity.SetItemChecked(i, false);
                }
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }

        void DeleteCategory()
        {
            try
            {
                LineOEETransaction_obj.lineoeecategoryid = Convert.ToInt32(cmb_Categories.SelectedValue);
                LineOEETransaction_obj.Delete_LineOEEActivityCategoryRelation();
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
                if (cmb_Categories.SelectedIndex != 0)
                {
                    DeleteCategory();
                    MessageBox.Show("Relations Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Please select Category");
                    cmb_Categories.Focus();
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            BtnSave_Click(sender, e);
        }

        private void cmb_Categories_SelectedIndexChanged(object sender, EventArgs e)
        {            

        }

        private void cmb_Categories_SelectionChangeCommitted(object sender, EventArgs e)
        
        {
            try
            {
                DataTable Dt = new DataTable();
                LineOEETransaction_obj.lineoeecategoryid = Convert.ToInt32(cmb_Categories.SelectedValue);
                Dt = LineOEETransaction_obj.Select_tblLineOEEActivityCategoryRelation();

                ResetAllActivities();             

                foreach (DataRow dr in Dt.Rows)
                {
                    for (int i = 0; i < ChkLstActivity.Items.Count; i++)
                    {                       
                       object Items = ChkLstActivity.Items[i];
                       if (Convert.ToInt64((((System.Data.DataRowView)(Items)).Row.ItemArray[0])) == Convert.ToInt64(dr["LineActivityID"]))
                       {
                           ChkLstActivity.SetItemChecked(i, true);
                       }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
