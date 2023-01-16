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
    public partial class FrmPMStatusChange : Form
    {
        public FrmPMStatusChange()
        {
            
            InitializeComponent();
        }
        #region Variables
      
        Comman_Class Comman_Class_obj = new Comman_Class();
        PMStatusChange_Class PMStatusChange_Class_obj = new PMStatusChange_Class();
        #endregion

        private static FrmPMStatusChange frmPMStatusChange_Obj = null;
        public static FrmPMStatusChange GetInstance()
        {
            if (frmPMStatusChange_Obj == null)
            {
                frmPMStatusChange_Obj = new Transactions.FrmPMStatusChange();
            }
            return frmPMStatusChange_Obj;
        }

        private void FrmPMStatusChange_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            dtpPMStatusChangeFromDate.Value = Comman_Class_obj.Select_ServerDate();
            dtpPMStatusChangeToDate.Value = Comman_Class_obj.Select_ServerDate();
            cmbPMStatusChangeDefectObserved.SelectedIndex = 0;        
            
        }       
        

        private void dtpPMStatusChangeFromDate_Leave(object sender, EventArgs e)
        {
            Bind_Details();
        }

        private void dtpPMStatusChangeToDate_Leave(object sender, EventArgs e)
        {
            Bind_Details();
        }

        public void Bind_Details()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                PMStatusChange_Class_obj.fromdate = dtpPMStatusChangeFromDate.Value.ToShortDateString();
                PMStatusChange_Class_obj.todate = dtpPMStatusChangeToDate.Value.ToShortDateString();
                if (dtpPMStatusChangeFromDate.Value > dtpPMStatusChangeToDate.Value)
                {
                    MessageBox.Show("From Date cannot be greater than To date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ds = PMStatusChange_Class_obj.Select_PMTransaction_PMSupplierCOC_PMCodeMaster_InspDate();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbPMStatusChangeDetails.DataSource = ds.Tables[0];
                    cmbPMStatusChangeDetails.DisplayMember = "Details";
                    cmbPMStatusChangeDetails.ValueMember = "PMTransID";
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbPMStatusChangeDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                resetall();
                if (cmbPMStatusChangeDetails.SelectedValue.ToString() != null && cmbPMStatusChangeDetails.SelectedValue.ToString() != "")
                {
                    PMStatusChange_Class_obj.pmtransid = Convert.ToInt64(cmbPMStatusChangeDetails.SelectedValue.ToString());
                    DataSet ds = new DataSet();
                    ds = PMStatusChange_Class_obj.Select_PMSampling_PMDetails_PMTransID();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtPMStatusChangeChallanNo.Text = ds.Tables[0].Rows[0]["ChallanNo"].ToString();
                        txtPMStatusChangeQtyReceived.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
                        PMStatusChange_Class_obj.pmtestid = Convert.ToInt64( ds.Tables[0].Rows[0]["PMTestID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  

        private void BtnPMStatusChangeSave_Click(object sender, EventArgs e)
        {
            try
            {                
                if (cmbPMStatusChangeDetails.SelectedIndex == 0 || cmbPMStatusChangeDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPMStatusChangeDetails.Focus();
                    return;
                }
                else
                {
                    if (cmbPMStatusChangeDefectObserved.SelectedIndex == 0 || cmbPMStatusChangeDefectObserved.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select Whether Defect is Present or not", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbPMStatusChangeDefectObserved.Focus();
                        return;
                    }                   
                   
                    if (RdoAccept.Checked == false && RdoReject.Checked == false && RdoSendBackToSupplier.Checked == false && RdoAWD.Checked == false && RdoTreatment.Checked == false)
                    {
                        MessageBox.Show("Please Select Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    PMStatusChange_Class_obj.pmtransid = Convert.ToInt64(cmbPMStatusChangeDetails.SelectedValue.ToString());
                    
                    if (cmbPMStatusChangeDefectObserved.SelectedIndex == 1)
                    {
                        PMStatusChange_Class_obj.defectobserved = Convert.ToString("N");
                    }
                    else if (cmbPMStatusChangeDefectObserved.SelectedIndex == 2)
                    {
                        PMStatusChange_Class_obj.defectobserved = Convert.ToString("Y");
                    }

                    PMStatusChange_Class_obj.defectsamplequantity = txtPMStatusChangeQtyDefSamples.Text.ToString();
                    
                    PMStatusChange_Class_obj.defectcomment = txtPMStatusDefectComment.Text.ToString();

                    if (txtNoOfDefect.Text.Trim() != "")
                    {
                        PMStatusChange_Class_obj.noofdefect = Convert.ToInt32(txtNoOfDefect.Text.Trim());
                    }
                    else
                    {
                        PMStatusChange_Class_obj.noofdefect = 0;
                    }
                    PMStatusChange_Class_obj.defect = txtDefect.Text.Trim();

                    if (RdoAccept.Checked == true)
                    {
                        PMStatusChange_Class_obj.status = "A";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        PMStatusChange_Class_obj.status = "A";
                    }
                    else if (RdoReject.Checked == true)
                    {
                        PMStatusChange_Class_obj.status = "R";
                    }
                    else if (RdoTreatment.Checked == true)
                    {
                        PMStatusChange_Class_obj.status = "R";
                    }
                    else if (RdoSendBackToSupplier.Checked == true)
                    {
                        PMStatusChange_Class_obj.status = "R";
                    }

                    //----------ActualStatus---------

                    if (RdoAccept.Checked == true)
                    {
                        PMStatusChange_Class_obj.actualstatus = "A";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        PMStatusChange_Class_obj.actualstatus = "D";
                    }
                    else if (RdoReject.Checked == true)
                    {
                        PMStatusChange_Class_obj.actualstatus = "R";
                    }
                    else if (RdoTreatment.Checked == true)
                    {
                        PMStatusChange_Class_obj.actualstatus = "T";
                    }
                    else if (RdoSendBackToSupplier.Checked == true)
                    {
                        PMStatusChange_Class_obj.actualstatus = "S";
                    }

                    
                    PMStatusChange_Class_obj.rejectcomment = Convert.ToString("N/A");
                    for (int i = 0; i < chkRejectComments.Items.Count; i++)
                    {
                        if (chkRejectComments.GetItemChecked(i) == true)
                        {
                            if (i == 0)
                            {
                                PMStatusChange_Class_obj.rejectcomment = Convert.ToString("BOR");
                                break;
                            }
                            else if (i == 1)
                            {
                                PMStatusChange_Class_obj.rejectcomment = Convert.ToString("BOF");
                                break;
                            }
                            else if (i == 2)
                            {
                                PMStatusChange_Class_obj.rejectcomment = Convert.ToString("COC");
                                break;
                            }
                        }
                    }

                    PMStatusChange_Class_obj.closed = 'N';
                    
                    PMStatusChange_Class_obj.currentflag = 1;

                    // ChangedStatus = 1 for record added in tblPMStatus in status change and treatment
                    PMStatusChange_Class_obj.changedstatus = 1;

                    PMStatusChange_Class_obj.loginid = FrmMain.LoginID;

                    bool b=PMStatusChange_Class_obj.Insert_PMStatus();

                    if (RdoTreatment.Checked == true)
                    {
                        PMStatusChange_Class_obj.currentflag = 0;
                    }
                    else
                    {
                        PMStatusChange_Class_obj.currentflag = 1;
                    }

                    //update currentFlag in tblPMTest 
                    if (RdoTreatment.Checked == true)
                    {
                        PMStatusChange_Class_obj.Update_tblPMTest_CurrentFlag();
                    }
                    
                    if (b == true)
                    {
                        MessageBox.Show("Status Changed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnPMStatusChangeReset_Click(sender, e);
                    }

                }                 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPMStatusChangeExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void BtnPMStatusChangeReset_Click(object sender, EventArgs e)
        {
            dtpPMStatusChangeFromDate.Value = Comman_Class_obj.Select_ServerDate();
            dtpPMStatusChangeToDate.Value = Comman_Class_obj.Select_ServerDate();
            cmbPMStatusChangeDetails.Text = "--Select--";
            resetall();
        }

        public void resetall()
        {
            txtPMStatusDefectComment.Text = "";
            txtPMStatusChangeChallanNo.Text = "";
            
            txtPMStatusChangeQtyDefSamples.Text = "";
            txtPMStatusChangeQtyReceived.Text = "";

            txtNoOfDefect.Text = "";
            txtDefect.Text = ""; 

            cmbPMStatusChangeDefectObserved.SelectedIndex = 0;            

            for (int i = 0; i < chkRejectComments.Items.Count; i++)
            {
                if (chkRejectComments.GetItemChecked(i) == true)
                {
                    chkRejectComments.SetItemChecked(i, false);
                }
            }

            RdoAccept.Checked = true;
            RdoReject.Checked = false; 
            RdoAWD.Checked = false;
            RdoTreatment.Checked = false;
            RdoSendBackToSupplier.Checked = false;
        }

        private void RdoPMStatusAccept_CheckedChanged(object sender, EventArgs e)
        {
            RdoAWD.Visible = false;
            RdoTreatment.Visible = false;
            chkRejectComments.Visible = false;
            for (int i = 0; i < chkRejectComments.Items.Count; i++)
            {
                if (chkRejectComments.GetItemChecked(i) == true)
                {
                    chkRejectComments.SetItemChecked(i, false);
                }
            }
        }

        private void RdoPMStatusReject_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoReject.Checked == true)
            {
                RdoAWD.Visible = true;
                RdoTreatment.Visible = true;
                chkRejectComments.Visible = true;
            }
        }

        private void chkPMStatusChangeRejectComments_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < chkRejectComments.Items.Count; i++)
                {
                    if (e.Index != i)
                    {
                        chkRejectComments.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void chkPMStatusChangeRejectComments_Click(object sender, EventArgs e)
        {
            if (chkRejectComments.GetItemCheckState(chkRejectComments.SelectedIndex) == CheckState.Unchecked)
            {
                chkRejectComments.SetItemCheckState(chkRejectComments.SelectedIndex, CheckState.Checked);
            }
            else if (chkRejectComments.GetItemCheckState(chkRejectComments.SelectedIndex) == CheckState.Checked)
            {
                chkRejectComments.SetItemCheckState(chkRejectComments.SelectedIndex, CheckState.Unchecked);
            }
        }

        private void txtNoOfDefect_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
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