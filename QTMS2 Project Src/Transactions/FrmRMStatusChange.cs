using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using BusinessFacade.Transactions;
using QTMS.Tools;

namespace QTMS.Transactions
{
    public partial class FrmRMStatusChange : System.Windows.Forms.Form
    {
        public FrmRMStatusChange()
        {
            
            InitializeComponent();
        }
        #region Variables
       
        Comman_Class Comman_Class_obj = new Comman_Class();
        RMStatusChange_Class RMStatusChange_Class_obj = new RMStatusChange_Class();
        #endregion

        private static FrmRMStatusChange frmRMStatusChange_Obj = null;
        public static FrmRMStatusChange GetInstance()
        {
            if (frmRMStatusChange_Obj == null)
            {
                frmRMStatusChange_Obj = new Transactions.FrmRMStatusChange();
            }
            return frmRMStatusChange_Obj;
        }

        private void FrmRMStatusChange_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            dtpRMStatusChangeFromDate.Value = Comman_Class_obj.Select_ServerDate();
            dtpRMStatusChangeToDate.Value = dtpRMStatusChangeFromDate.Value;                    
        }       
        private void BtnRMStatusExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Bind_RMCode()
        {
            try
            {                
                DataRow dr;
                DataSet ds = new DataSet();
                RMStatusChange_Class_obj.fromdate = dtpRMStatusChangeFromDate.Value.ToShortDateString();
                RMStatusChange_Class_obj.todate = dtpRMStatusChangeToDate.Value.ToShortDateString();                
                ds = RMStatusChange_Class_obj.Select_RMDetails_RMCodeMaster_InspDate();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["RMTransID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);               
                cmbRMStatusChangeRMCode.DataSource = ds.Tables[0];
                cmbRMStatusChangeRMCode.DisplayMember = "Details";
                cmbRMStatusChangeRMCode.ValueMember = "RMTransID";
            
                ResetAllRMStatusChageFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private void dtpRMStatusChangeFromDate_ValueChanged(object sender, EventArgs e)
        {
            Bind_RMCode();
        }

        private void dtpRMStatusChangeToDate_ValueChanged(object sender, EventArgs e)
        {
            Bind_RMCode();
        }

        private void cmbRMStatusChangeRMCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                if (cmbRMStatusChangeRMCode.SelectedValue != null && cmbRMStatusChangeRMCode.SelectedValue.ToString() != "")
                {

                    RMStatusChange_Class_obj.rmtransid = Convert.ToInt64(cmbRMStatusChangeRMCode.SelectedValue.ToString());
                    ds = RMStatusChange_Class_obj.Select_RMSampling_RMSupplierMaster_RMTransID();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //txtRMStatusChangePlantLotNo.Text = ds.Tables[0].Rows[0]["PlantLotNo"].ToString();
                        //txtRMStatusChangeSupplierName.Text = ds.Tables[0].Rows[0]["RMSupplierName"].ToString();
                        txtRMStatusChallanNo.Text = ds.Tables[0].Rows[0]["ChallanNo"].ToString();
                        txtRMStatusChangeQuantityReceived.Text = ds.Tables[0].Rows[0]["QuantityReceived"].ToString();
                    }
                }
                else
                {
                    //txtRMStatusChangePlantLotNo.Text = "";
                    //txtRMStatusChangeSupplierName.Text = "";
                    return;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            
        }

        private void BtnRMStatusReset_Click(object sender, EventArgs e)
        {
            dtpRMStatusChangeFromDate.Value = Comman_Class_obj.Select_ServerDate();
            dtpRMStatusChangeToDate.Value = Comman_Class_obj.Select_ServerDate();
            Bind_RMCode();
            ResetAllRMStatusChageFields();

        }
        public void ResetAllRMStatusChageFields()
        {
           
            //txtRMStatusChangeSupplierName.Text = "";
            //txtRMStatusChangePlantLotNo.Text = "";
            txtRMStatusChallanNo.Text = "";
            txtRMStatusChangeQuantityReceived.Text = "";
            RDoRMStatusAccept.Checked = false;
            RdoRMStatusReject.Checked = false;
            RdoRMStatusChangeAWD.Checked = false;
            RdoRmStatusSenttoSupplier.Checked = false;
            txtRMStatusChangeNonConReason.Text = "";
            txtRMStatusChangeAcceptedQuantity.Text = "";
            txtRMStatusChangeComments.Text = "";
        }

        private void BtnRMStatusSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();

                if (cmbRMStatusChangeRMCode.SelectedValue == null)
                {
                    MessageBox.Show("Please Select Proper Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cmbRMStatusChangeRMCode.Text == "--Select--" || cmbRMStatusChangeRMCode.Text == "")
                {
                    MessageBox.Show("Please Select Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (RDoRMStatusAccept.Checked == false && RdoRMStatusReject.Checked == false && RdoRmStatusSenttoSupplier.Checked == false && RdoRMStatusChangeAWD.Checked == false)
                {
                    MessageBox.Show("Please Select Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtRMStatusChangeAcceptedQuantity.Text == "")
                {
                    MessageBox.Show("Please Enter Accepted Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                RMStatusChange_Class_obj.rmtransid = Convert.ToInt64(cmbRMStatusChangeRMCode.SelectedValue.ToString());
                RMStatusChange_Class_obj.nonconreason = txtRMStatusChangeNonConReason.Text.ToString();
                RMStatusChange_Class_obj.changedate = Comman_Class_obj.Select_ServerDate().ToShortDateString();
                RMStatusChange_Class_obj.acceptedquantity = Convert.ToInt64(txtRMStatusChangeAcceptedQuantity.Text.ToString());

                if (RDoRMStatusAccept.Checked == true)
                {
                    RMStatusChange_Class_obj.status = Convert.ToChar("A");
                }
                else if (RdoRMStatusReject.Checked == true)
                {
                    RMStatusChange_Class_obj.status = Convert.ToChar("R");
                }
                else if (RdoRMStatusChangeAWD.Checked == true)
                {
                    RMStatusChange_Class_obj.status = Convert.ToChar("D");
                }
                else if (RdoRmStatusSenttoSupplier.Checked == true)
                {
                    RMStatusChange_Class_obj.status = Convert.ToChar("S");
                }

                RMStatusChange_Class_obj.comment = txtRMStatusChangeComments.Text.ToString();
                RMStatusChange_Class_obj.loginid = FrmMain.LoginID;
                bool b = RMStatusChange_Class_obj.Insert_RMStatus();
                if (b == true)
                {
                    MessageBox.Show("Status Changed Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnRMStatusReset_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtRMStatusChangeAcceptedQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

              e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

              e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

              
    }
}







































