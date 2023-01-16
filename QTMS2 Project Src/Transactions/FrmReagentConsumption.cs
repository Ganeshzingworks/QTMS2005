using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade.Transactions;

namespace QTMS.Transactions
{
    public partial class FrmReagentConsumption : Form  //FrmReagentConsumption
    {
        #region Variables
        ReagentConsumption_Class ReagentConsumption_Class_obj = new ReagentConsumption_Class();
        ReagentTransaction_Class ReagentTransaction_Class_obj = new ReagentTransaction_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        #endregion 

        public FrmReagentConsumption()
        {
            InitializeComponent();
        }
        private static FrmReagentConsumption FrmReagentConsumption_Obj = null;
        internal static FrmReagentConsumption GetInstance()
        {
            if (FrmReagentConsumption_Obj == null)
            {
                FrmReagentConsumption_Obj = new Transactions.FrmReagentConsumption();
            }
            return FrmReagentConsumption_Obj;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReagentMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_Details();
            Bind_InspectedBy();
            //bind_RACode();
            lblValidityFlag.ForeColor = Color.Red;
        }

        public void Bind_Details()
        {
            CmbDetails.BeginUpdate();
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                //those for which Kitflag is 1 
                ds = ReagentTransaction_Class_obj.Select_ConsumptionReagentTransaction();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                CmbDetails.DataSource = ds.Tables[0];
                CmbDetails.DisplayMember = "Details";
                CmbDetails.ValueMember = "ReagentTransID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CmbDetails.EndUpdate();
            }
        }
        public void Bind_InspectedBy()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = UserManagement_Class_Obj.Select_AllUser();
            dr = ds.Tables[0].NewRow();
            dr["UserName"] = "--Select--";
            dr["UserID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbInspectedBy.DataSource = ds.Tables[0];
                cmbInspectedBy.DisplayMember = "UserName";
                cmbInspectedBy.ValueMember = "UserID";
            }
        }

      

      

      
        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (CmbDetails.SelectedValue == null || CmbDetails.Text == "--Select--")
            {
                MessageBox.Show("Select Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CmbDetails.Focus();
                return;
            }
            if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
            {
                MessageBox.Show("Select InspectedBy", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbInspectedBy.Focus();
                return;
            }
            if (ReagentConsumption_Class_obj.reagentbottleid == 0)
            {
                MessageBox.Show("Select Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CmbDetails.Focus();
                return;
            }

            ReagentConsumption_Class_obj.inspectedby = Convert.ToInt64(cmbInspectedBy.SelectedValue);
            ReagentConsumption_Class_obj.loginid = FrmMain.LoginID;

            bool status = ReagentConsumption_Class_obj.Update_tblReagentBottle_IsConsume();

            if (status == true)
            {
                string[] tokens = lblBottelJarNo.Text.Split('/');

                MessageBox.Show("Bottle No. '" + tokens[0].ToString() + "' is Consumed !");
                // bind_RACode();
                BtnReset_Click(sender, e);
            }

            
            
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {

            Bind_Details();
            lblBottelJarNo.Text = "";
            ReagentConsumption_Class_obj.reagentbottleid = 0;
            cmbInspectedBy.SelectedIndex = 0;
        }

        private void dtpConsumptionDate_Leave(object sender, EventArgs e)
        {
           //

        }

        private void CmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (CmbDetails.SelectedValue != null && CmbDetails.SelectedValue.ToString() != "")
                {
                    ReagentConsumption_Class_obj.reagenttransid = Convert.ToInt64(CmbDetails.SelectedValue);
                    DataSet ds = new DataSet();
                    ds = ReagentConsumption_Class_obj.Select_ConsumptionBottle();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblBottelJarNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Bottle"].ToString());
                        ReagentConsumption_Class_obj.reagentbottleid = Convert.ToInt64(ds.Tables[0].Rows[0]["ReagentBottleID"].ToString());
                        if (Convert.ToString(ds.Tables[0].Rows[0]["ValidityFlag"].ToString()) == "1")
                            lblValidityFlag.Visible = true;
                        else
                            lblValidityFlag.Visible = false;
                    }
                    else
                    {
                        lblBottelJarNo.Text = "";
                        ReagentConsumption_Class_obj.reagentbottleid = 0;
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