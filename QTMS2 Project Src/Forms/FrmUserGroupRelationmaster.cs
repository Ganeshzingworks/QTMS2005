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
    public partial class FrmUserGroupRelationmaster : System.Windows.Forms.Form
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_Activities;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnDelete;
        private Label label_Categories;
        private Panel panelOuter;
        private Panel panelFill;
        private Panel panelTop;
        private ToolStrip toolStrip_OEE;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton toolStripButtonClose;
        private CheckedListBox ChkLstUserNames;
        private ComboBox cmbGroupNames;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmUserGroupRelationmaster()
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

            FrmUserGroupRelationmaster_Obj = null;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbGroupNames = new System.Windows.Forms.ComboBox();
            this.ChkLstUserNames = new System.Windows.Forms.CheckedListBox();
            this.label_Categories = new System.Windows.Forms.Label();
            this.label_Activities = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.cmbGroupNames);
            this.groupBox1.Controls.Add(this.ChkLstUserNames);
            this.groupBox1.Controls.Add(this.label_Categories);
            this.groupBox1.Controls.Add(this.label_Activities);
            this.groupBox1.Location = new System.Drawing.Point(14, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbGroupNames
            // 
            this.cmbGroupNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupNames.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGroupNames.FormattingEnabled = true;
            this.cmbGroupNames.Location = new System.Drawing.Point(163, 26);
            this.cmbGroupNames.Name = "cmbGroupNames";
            this.cmbGroupNames.Size = new System.Drawing.Size(280, 22);
            this.cmbGroupNames.TabIndex = 12;
            this.cmbGroupNames.SelectionChangeCommitted += new System.EventHandler(this.cmbGroupNames_SelectionChangeCommitted);
            // 
            // ChkLstUserNames
            // 
            this.ChkLstUserNames.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ChkLstUserNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChkLstUserNames.CheckOnClick = true;
            this.ChkLstUserNames.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkLstUserNames.Location = new System.Drawing.Point(163, 66);
            this.ChkLstUserNames.Name = "ChkLstUserNames";
            this.ChkLstUserNames.Size = new System.Drawing.Size(280, 164);
            this.ChkLstUserNames.TabIndex = 11;
            // 
            // label_Categories
            // 
            this.label_Categories.AutoSize = true;
            this.label_Categories.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Categories.Location = new System.Drawing.Point(12, 28);
            this.label_Categories.Name = "label_Categories";
            this.label_Categories.Size = new System.Drawing.Size(145, 16);
            this.label_Categories.TabIndex = 8;
            this.label_Categories.Text = "Select Group Name :";
            // 
            // label_Activities
            // 
            this.label_Activities.AutoSize = true;
            this.label_Activities.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Activities.Location = new System.Drawing.Point(32, 66);
            this.label_Activities.Name = "label_Activities";
            this.label_Activities.Size = new System.Drawing.Size(96, 16);
            this.label_Activities.TabIndex = 3;
            this.label_Activities.Text = "User Names :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BtnDelete);
            this.groupBox2.Controls.Add(this.BtnReset);
            this.groupBox2.Controls.Add(this.BtnExit);
            this.groupBox2.Controls.Add(this.BtnSave);
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
            this.BtnDelete.Location = new System.Drawing.Point(507, 17);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(74, 27);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.Text = "&Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Visible = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(129, 17);
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
            this.BtnExit.Location = new System.Drawing.Point(358, 17);
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
            this.BtnSave.Location = new System.Drawing.Point(243, 17);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(95, 27);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "&Set Relations";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelFill);
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(619, 357);
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
            this.panelTop.Size = new System.Drawing.Size(617, 30);
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
            this.toolStrip_OEE.Size = new System.Drawing.Size(617, 30);
            this.toolStrip_OEE.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(165, 27);
            this.toolStripLabel1.Text = "User Group Relation Master";
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
            // FrmUserGroupRelationmaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(619, 357);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserGroupRelationmaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Group Relation Master";
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
        GroupMaster_Class GroupMaster_Class_Obj = new GroupMaster_Class();
        UserData UserDataObj = new UserData();
        #endregion
        

        private static Forms.FrmUserGroupRelationmaster FrmUserGroupRelationmaster_Obj = null;
        public static Forms.FrmUserGroupRelationmaster GetInstance()
        {
            if (FrmUserGroupRelationmaster_Obj == null)
            {
                FrmUserGroupRelationmaster_Obj = new Forms.FrmUserGroupRelationmaster();
            }
            return FrmUserGroupRelationmaster_Obj;
        }

        private void FrmTestMaster_Load(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_UserNames();
            Bind_GroupNames();            
        }
        public void Bind_UserNames()
        {
            try
            {
                //DataRow dr;
                DataTable dt = new DataTable();
                dt = UserDataObj.Show_AllUser();
                //dr = ds.Tables[0].NewRow();
                //dr["UserName"] = "--Select--";
                //dr["UserID"] = "0";
                //ds.Tables[0].Rows.InsertAt(dr, 0);

                if (dt.Rows.Count > 0)
                {
                    ChkLstUserNames.DataSource = dt;
                    ChkLstUserNames.DisplayMember = "UserName";
                    ChkLstUserNames.ValueMember = "UserID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_GroupNames()
        {
            try
            {
                DataRow dr;
                DataTable Dt = new DataTable();
                DataSet ds = new DataSet();
                ds = GroupMaster_Class_Obj.Select_tblSoftwareUserGroup();
                Dt = ds.Tables[0];
                dr = Dt.NewRow();
                dr["GroupName"] = "--Select--";
                dr["GroupID"] = "0";
                Dt.Rows.InsertAt(dr, 0);
                if (Dt.Rows.Count > 0)
                {
                    cmbGroupNames.DataSource = Dt;
                    cmbGroupNames.DisplayMember = "GroupName";
                    cmbGroupNames.ValueMember = "GroupID";
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
            for (int i = 0; i < ChkLstUserNames.Items.Count; i++)
            {
                ChkLstUserNames.SetItemChecked(i, false);
            }
            ChkLstUserNames.SetItemChecked(ChkLstUserNames.SelectedIndex, true);
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
                    UserDataObj.groupID = Convert.ToInt32(cmbGroupNames.SelectedValue);
                    DeleteCategory();
                    for (int i = 0; i < ChkLstUserNames.Items.Count; i++)
                    {                       
                        if (ChkLstUserNames.GetItemChecked(i) == true)
                        {
                            ChkLstUserNames.SetSelected(i, true);
                            int userID = Convert.ToInt32(ChkLstUserNames.SelectedValue);
                            UserDataObj.userid = userID;
                            UserDataObj.Insert_SoftwareUserGroupRelation();
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
                 if (cmbGroupNames.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Group Name ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbGroupNames.Focus();
                    return false ;
                }
                if (ChkLstUserNames.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please Select Atleast User name ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ChkLstUserNames.Focus();
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
                cmbGroupNames.SelectedIndex = 0;
                ResetAllUserNames();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetAllUserNames()
        {
            try
            {
                for (int i = 0; i < ChkLstUserNames.Items.Count; i++)
                {
                    ChkLstUserNames.SetItemChecked(i, false);
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
                UserDataObj.groupID = Convert.ToInt32(cmbGroupNames.SelectedValue);
                UserDataObj.Delete_SoftwareUserGroupRelation();
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
                if (cmbGroupNames.SelectedIndex != 0)
                {
                    DeleteCategory();
                    MessageBox.Show("Relations Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Please select Group Name");
                    cmbGroupNames.Focus();
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

        private void cmbGroupNames_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable Dt = new DataTable();
                UserDataObj.groupID = Convert.ToInt32(cmbGroupNames.SelectedValue);
                Dt = UserDataObj.Select_SoftwareUserGroupRelation();

                ResetAllUserNames();

                foreach (DataRow dr in Dt.Rows)
                {
                    for (int i = 0; i < ChkLstUserNames.Items.Count; i++)
                    {
                        object Items = ChkLstUserNames.Items[i];
                        if (Convert.ToInt64((((System.Data.DataRowView)(Items)).Row.ItemArray[0])) == Convert.ToInt64(dr["UserID"]))
                        {
                            ChkLstUserNames.SetItemChecked(i, true);
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
