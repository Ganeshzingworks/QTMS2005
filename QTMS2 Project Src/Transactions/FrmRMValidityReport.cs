using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade.Transactions;
using QTMS.Tools;

namespace QTMS.Transactions
{
    public partial class FrmRMValidityReport : System.Windows.Forms.Form
    {
        public FrmRMValidityReport()
        {
            
            InitializeComponent();
        }
        #region Variables
       
        Comman_Class Comman_Class_obj = new Comman_Class();
        BusinessFacade.Transactions.RMTransaction_Class RMTransaction_Class_obj = new RMTransaction_Class();
        DateTime ValidityDate;
       
        #endregion

        private static FrmRMValidityReport frmRMValidityReport_Obj = null;
        public static FrmRMValidityReport GetInstance()
        {
            if (frmRMValidityReport_Obj == null)
            {
                frmRMValidityReport_Obj = new Transactions.FrmRMValidityReport();
            }
            return frmRMValidityReport_Obj;
        }
        
        private void FrmRMValidityReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            BtnRMVRReset_Click(sender, e);      
        }

        private void dtpRMVRToDate_ValueChanged(object sender, EventArgs e)
        {
            Bind_Details();
        }

        private void dtpRMVRFromDate_ValueChanged(object sender, EventArgs e)
        {
            Bind_Details();
        }

        public void Bind_Details()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                RMTransaction_Class_obj.fromdate = dtpRMVRFromDate.Value.ToShortDateString();
                RMTransaction_Class_obj.todate = dtpRMVRToDate.Value.ToShortDateString();
                ds = RMTransaction_Class_obj.Select_RMDetails_RMCodeMaster_InspDate();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "RMSamplingID";
                
                ResetAllRMVRFields();              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ResetAllRMVRFields();
                DataSet ds = new DataSet();
                if ((cmbDetails.SelectedValue.ToString() != null) && (cmbDetails.SelectedValue.ToString() != ""))
                {

                    RMTransaction_Class_obj.rmsamplingid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                    ds = RMTransaction_Class_obj.Select_RMSampling_RMSupplierMaster_RMDetails_RMStatus_RMTransaction_RMSamplingID();
                    
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ValidityDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ValidityDate"]);

                        RMTransaction_Class_obj.rmcodeid =Convert.ToInt64(ds.Tables[0].Rows[0]["RMCodeID"]);
                        RMTransaction_Class_obj.rmsupplierid =Convert.ToInt64(ds.Tables[0].Rows[0]["RMSupplierID"]);
                        RMTransaction_Class_obj.plantlotno = ds.Tables[0].Rows[0]["PlantLotNo"].ToString();

                        txtRMVRAcceptedQuantity.Text = ds.Tables[0].Rows[0]["AcceptedQuantity"].ToString();
                        //txtRMVRChallanNo.Text = ds.Tables[0].Rows[0]["ChallanNo"].ToString();
                        //txtRMVRPlantLotNo.Text = ds.Tables[0].Rows[0]["PlantLotNo"].ToString();
                        txtRMVRQuantityReceived.Text = ds.Tables[0].Rows[0]["QuantityReceived"].ToString();
                        txtRMVRReaminingQuantity.Text=ds.Tables[0].Rows[0]["RemainingQuantity"].ToString();
                        if (ds.Tables[0].Rows[0]["SubContract"] != DBNull.Value)
                        {
                            chkSubcontract.Checked = (bool)ds.Tables[0].Rows[0]["SubContract"];
                        }
                        else
                        {

                            chkSubcontract.Checked = false;
                        }
                    }

                    cmbTypeOfControl_SelectionChangeCommitted(sender, e);
                }
                else
                {
                    ResetAllRMVRFields();
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbTypeOfControl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "")
                {
                    dgTest.Rows.Clear();
                    dgTest.Columns.Clear();

                    RMTransaction_Class_obj.isvalidityexpanded = true;

                    if (cmbTypeOfControl.Text == "Reduced Control")
                    {
                        RMTransaction_Class_obj.methodtype = 'R';

                        dgTest.Columns.Add("Identification", "Identification");
                        dgTest.Columns["Identification"].Width = 150;
                        dgTest.Columns["Identification"].ReadOnly = true;

                        DataSet dsRI = new DataSet();
                        RMTransaction_Class_obj.testtype = "Identification";
                        dsRI = RMTransaction_Class_obj.Select_tblRMPhysicochemicalTestMethodDetails_MethodType_TestType();
                        if (dsRI.Tables[0].Rows.Count > 0)
                        {
                            dgTest["Identification", 0].Value = "Done";
                        }

                    }
                    else if (cmbTypeOfControl.Text == "Full Control")
                    {
                        RMTransaction_Class_obj.methodtype = 'F';

                        dgTest.Columns.Add("Identification", "Identification");
                        dgTest.Columns["Identification"].Width = 150;
                        dgTest.Columns["Identification"].ReadOnly = true;

                        DataSet dsFI = new DataSet();
                        RMTransaction_Class_obj.testtype = "Identification";
                        dsFI = RMTransaction_Class_obj.Select_tblRMPhysicochemicalTestMethodDetails_MethodType_TestType();
                        if (dsFI.Tables[0].Rows.Count > 0)
                        {
                            dgTest["Identification", 0].Value = "Done";
                        }

                        dgTest.Columns.Add("Control", "Control");
                        dgTest.Columns["Control"].Width = 150;
                        dgTest.Columns["Control"].ReadOnly = true;

                        DataSet dsFC = new DataSet();
                        RMTransaction_Class_obj.testtype = "Control";
                        dsFC = RMTransaction_Class_obj.Select_tblRMPhysicochemicalTestMethodDetails_MethodType_TestType();
                        if (dsFC.Tables[0].Rows.Count > 0)
                        {
                            dgTest["Control", 0].Value = "Done";
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRMVRExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ResetAllRMVRFields()
        {
            txtRMVRAcceptedQuantity.Text = "";
            //txtRMVRChallanNo.Text = "";         
            txtRMVRQuantityReceived.Text = "";
            txtRMVRReaminingQuantity.Text = "";



            RdoRMValidityAccept.Checked = false;
            RdoRmValidityAWD.Checked = false;
            RdoRMValidityReject.Checked = false;
            RdoRmValiditySenttoSupplier.Checked = false;            
        }

        private void BtnRMVRReset_Click(object sender, EventArgs e)
        {
            dtpRMVRFromDate.Value = Comman_Class_obj.Select_ServerDate();
            dtpRMVRToDate.Value = Comman_Class_obj.Select_ServerDate();
            dtpRMVRValidityExpanded.Value = Comman_Class_obj.Select_ServerDate();
            cmbTypeOfControl.Text = "Reduced Control";
            dgTest.Rows.Clear();
            chkSubcontract.Checked = false;
            dgTest.Columns.Clear();
            Bind_Details();
            ResetAllRMVRFields();
        }

        private void BtnRMVRSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cmbDetails.SelectedValue.ToString() != null) && (cmbDetails.SelectedValue.ToString() != ""))
                {
                    DateTime TodayDate = Comman_Class_obj.Select_ServerDate();

                    RMTransaction_Class_obj.rmsamplingid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());

                    if (txtRMVRReaminingQuantity.Text == "")
                    {
                        RMTransaction_Class_obj.remainingquantity = 0;
                    }
                    else
                    {
                        RMTransaction_Class_obj.remainingquantity = Convert.ToInt64(txtRMVRReaminingQuantity.Text.ToString().Trim());
                    }

                    if (RdoRMValidityAccept.Checked == false && RdoRMValidityReject.Checked == false && RdoRmValidityAWD.Checked == false && RdoRmValiditySenttoSupplier.Checked == false)
                    {
                        MessageBox.Show("Please Select Status", "Message" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (RdoRMValidityAccept.Checked == true)
                    {
                        if (MessageBox.Show("ACCEPT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }

                    if (RdoRMValidityReject.Checked == true)
                    {
                        if (MessageBox.Show("REJECT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }

                    if (RdoRmValidityAWD.Checked == true)
                    {
                        if (MessageBox.Show("ACCEPT WITH DERROGATION ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }

                    if (RdoRmValiditySenttoSupplier.Checked == true)
                    {
                        if (MessageBox.Show("SEND BACK TO SUPPLIER?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    
                    if (RdoRMValidityAccept.Checked == true)
                    {
                        RMTransaction_Class_obj.status = Convert.ToChar("A");
                    }
                    else if (RdoRMValidityReject.Checked == true)
                    {
                        RMTransaction_Class_obj.status = Convert.ToChar("R");
                    }
                    else if (RdoRmValidityAWD.Checked == true)
                    {
                        RMTransaction_Class_obj.status = Convert.ToChar("D");

                    }
                    else if (RdoRmValiditySenttoSupplier.Checked == true)
                    {
                        RMTransaction_Class_obj.status = Convert.ToChar("S");
                    }
                    if (chkSubcontract.Checked)
                    {
                        RMTransaction_Class_obj.subContract = true;
                    }
                    else
                    {
                        RMTransaction_Class_obj.subContract = false;
                    }

                    RMTransaction_Class_obj.validitydate = dtpRMVRValidityExpanded.Value.ToShortDateString();
                    RMTransaction_Class_obj.rmtransdone = true;
                    RMTransaction_Class_obj.currentflagtrans = true;
                    RMTransaction_Class_obj.currentflagstatus = true;
                    RMTransaction_Class_obj.loginid = FrmMain.LoginID;
                    RMTransaction_Class_obj.isvalidityexpanded = true;

                    DataSet ds3 = new DataSet();
                    ds3 = RMTransaction_Class_obj.Select_RMTransaction_RMSamplingID();
                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        RMTransaction_Class_obj.rmtransid = Convert.ToInt64(ds3.Tables[0].Rows[0]["RMtransID"]);
                        RMTransaction_Class_obj.Update_RMTransaction();
                    }
                    else
                    {
                        RMTransaction_Class_obj.rmtransid = RMTransaction_Class_obj.Insert_RMTransaction();
                    }

                    RMTransaction_Class_obj.Update_tblRMTransaction_IsValidityExpanded();

                    RMTransaction_Class_obj.Insert_RMStatus();

                    MessageBox.Show("Record Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnRMVRReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Please Select Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == 0)
                {

                    if(MessageBox.Show("Sure to Expand Validity?", "Quesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                        {
                            MessageBox.Show("Please Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbDetails.Focus();
                            return;
                        }

                        //------------------- INSERT TRANSACTION DETAILS --------------------------------------

                        if (cmbTypeOfControl.Text == "Reduced Control")
                        {
                            RMTransaction_Class_obj.methodtype = 'R';
                        }
                        else if (cmbTypeOfControl.Text == "Full Control")
                        {
                            RMTransaction_Class_obj.methodtype = 'F';
                        }

                        RMTransaction_Class_obj.validitydate = dtpRMVRValidityExpanded.Value.ToShortDateString();
                        if (txtRMVRReaminingQuantity.Text == "")
                        {
                            RMTransaction_Class_obj.remainingquantity = 0;
                        }
                        else
                        {
                            RMTransaction_Class_obj.remainingquantity = Convert.ToInt64(txtRMVRReaminingQuantity.Text.ToString().Trim());
                        }
                        if (chkSubcontract.Checked)
                        {
                            RMTransaction_Class_obj.subContract = true;
                        }
                        else
                        {
                            RMTransaction_Class_obj.subContract = false;
                        }

                        RMTransaction_Class_obj.currentflagtrans = true;
                        RMTransaction_Class_obj.loginid = FrmMain.LoginID;
                        RMTransaction_Class_obj.rmtransdone = true;
                        RMTransaction_Class_obj.isvalidityexpanded = true;

                        DataSet ds3 = new DataSet();
                        ds3 = RMTransaction_Class_obj.Select_RMTransaction_RMSamplingID();
                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            RMTransaction_Class_obj.rmtransid = Convert.ToInt64(ds3.Tables[0].Rows[0]["RMtransID"]);
                            RMTransaction_Class_obj.Update_RMTransaction();
                        }
                        else
                        {
                            RMTransaction_Class_obj.rmtransid = RMTransaction_Class_obj.Insert_RMTransaction();
                        }

                        RMTransaction_Class_obj.Update_tblRMTransaction_IsValidityExpanded();

                        FrmRMTransactionTest.Detail detail_Obj = new FrmRMTransactionTest.Detail();
                        detail_Obj.RMCodeID = RMTransaction_Class_obj.rmcodeid;
                        detail_Obj.RMTransID = RMTransaction_Class_obj.rmtransid;
                        if (cmbTypeOfControl.Text == "Reduced Control")
                        {
                            detail_Obj.MethodType = 'R';
                            RMTransaction_Class_obj.methodtype = 'R';
                        }
                        else if (cmbTypeOfControl.Text == "Full Control")
                        {
                            detail_Obj.MethodType = 'F';
                            RMTransaction_Class_obj.methodtype = 'F';
                        }
                        if (e.ColumnIndex == dgTest.Columns[0].Index)    //Identification
                        {
                            detail_Obj.TestType = "Identification";

                            if (dgTest[e.ColumnIndex, 0].Value == "Done")
                            {
                                detail_Obj.Done = 'Y';
                            }
                            else
                            {
                                detail_Obj.Done = 'N';
                            }

                            FrmRMTransactionTest frmrmtransactiontest = new FrmRMTransactionTest(detail_Obj);
                            frmrmtransactiontest.TypeofTest = "Identification";
                            frmrmtransactiontest.ShowDialog();

                            DataSet dsFI = new DataSet();
                            RMTransaction_Class_obj.testtype = "Identification";
                            dsFI = RMTransaction_Class_obj.Select_tblRMPhysicochemicalTestMethodDetails_MethodType_TestType();
                            if (dsFI.Tables[0].Rows.Count > 0)
                            {
                                dgTest["Identification", 0].Value = "Done";
                            }

                        }
                        else if (e.ColumnIndex == dgTest.Columns[1].Index)  //Control
                        {
                            detail_Obj.TestType = "Control";

                            if (dgTest[e.ColumnIndex, 0].Value == "Done")
                            {
                                detail_Obj.Done = 'Y';
                            }
                            else
                            {
                                detail_Obj.Done = 'N';
                            }

                            FrmRMTransactionTest frmrmtransactiontest = new FrmRMTransactionTest(detail_Obj);
                            frmrmtransactiontest.TypeofTest = "Control";
                            frmrmtransactiontest.ShowDialog();

                            DataSet dsFC = new DataSet();
                            RMTransaction_Class_obj.testtype = "Control";
                            dsFC = RMTransaction_Class_obj.Select_tblRMPhysicochemicalTestMethodDetails_MethodType_TestType();
                            if (dsFC.Tables[0].Rows.Count > 0)
                            {
                                dgTest["Control", 0].Value = "Done";
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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkSubcontract_CheckedChanged(object sender, EventArgs e)
        {

        }

        
        
       
        }
    }
