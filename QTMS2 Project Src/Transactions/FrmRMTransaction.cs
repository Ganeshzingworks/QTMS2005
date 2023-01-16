using System;
using System.IO;
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
    public partial class FrmRMTransaction : Form
    {
        public FrmRMTransaction()
        {

            InitializeComponent();
        }

        #region Variables
        BusinessFacade.RMCodeMaster_Class RMCodeMaster_Class_Obj = new RMCodeMaster_Class();

        BusinessFacade.Transactions.RMTransaction_Class RMTransaction_Class_obj = new RMTransaction_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_obj = new Comman_Class();

        int cntLocation = 0;
        #endregion

        private static FrmRMTransaction frmRMTransaction_Obj = null;

        public static FrmRMTransaction GetInstance()
        {
            if (frmRMTransaction_Obj == null)
            {
                frmRMTransaction_Obj = new Transactions.FrmRMTransaction();
            }
            return frmRMTransaction_Obj;
        }

        private void FrmRMTransaction_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_RMCode();
            Bind_Location();
            reset();
            //Set previous record location ID
            ShowLastLocationID_RmDetailID();
        }

        public void Bind_RMCode()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = RMCodeMaster_Class_Obj.Select_RMCodeMaster();
                DataRow dr = ds.Tables[0].NewRow();
                dr["RMCode"] = "--Select--";
                dr["RMCodeId"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbRMCode.DataSource = ds.Tables[0];
                    cmbRMCode.DisplayMember = "RMCode";
                    cmbRMCode.ValueMember = "RMCodeID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_Location()
        {
            try
            {
                DataSet ds = new DataSet();
                RetainerLocation_Class RetainerLocation_Class_Obj = new RetainerLocation_Class();
                ds = RetainerLocation_Class_Obj.Select_RMRetainerLocation();

                DataRow dr = ds.Tables[0].NewRow();
                dr["Location"] = "--Select--";
                dr["LocationId"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbLocation.DataSource = ds.Tables[0];
                    cmbLocation.DisplayMember = "Location";
                    cmbLocation.ValueMember = "LocationID";
                }
                cntLocation = ds.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            reset();
            txtProtocolNo.Text = "";
          
        }

        public void reset()
        {
            dtpInspDate.Value = Comman_Class_obj.Select_ServerDate();
            dtpAcceptedDate.Value = dtpInspDate.Value;
            cmbSupplier.Text = "--Select--";
            txtPlantLotNo.Text = "";
            txtAgentName.Text = "";
            cmbTypeOfControl.Text = "Reduced Control";
            txtQuantityReceived.Text = ""; 
            lblIsAligned.Text = "";
            lblMsgFull.Text = "";

            txtQuantitySampled.Text = "";
            txtActualNoSegments.Text = "";
            txtNoOfSegments.Text = "";
            lblMsgSampling.Text = "";

            dtpReceiptDate.Value = dtpInspDate.Value;
            txtSupplierLotNo.Text = "";
            dtpDateOfValidity.Value = dtpInspDate.Value;
            txtMRR.Text = "";
            cmbConfirmation.SelectedIndex = 0;
            txtChallanNo.Text = "";
            cmbSupplierReportReceived.SelectedIndex = 0;
            cmbFirstRMReception.SelectedIndex = 0;
            cmbLocation.Text = "--Select--";
            //cmbLocation.SelectedIndex = cntLocation - 1;

            dgTest.Rows.Clear();
            dgTest.Columns.Clear();

            RdoHold.Checked = true;
            RdoAccept.Checked = false;
            RdoAWD.Checked = false;
            RdoReject.Checked = false;
            RdoSentToSupplier.Checked = false;

            chkLabelForRetainer.Checked = false;
            RdoPositive.Checked = false;
            RdoNegative.Checked = false;

            dtpManufacturingDate.CustomFormat = " ";


            ///*Created by : [Manish k]
            txtPlantLotNo.Enabled = true; 
        }

        private void ShowLastLocationID_RmDetailID()
        {
            try
            {
                DataSet dsLocID = new DataSet();
                dsLocID = RMTransaction_Class_obj.Select_RMDetails_LocationID();
                if (dsLocID.Tables[0].Rows.Count > 0)
                {
                    cmbLocation.SelectedValue = dsLocID.Tables[0].Rows[0][0];
                }
                else
                {
                    cmbLocation.SelectedIndex = cntLocation - 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        DataSet DSRMCode;

        private void cmbRMCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbRMCode.SelectedValue != null && cmbRMCode.SelectedValue.ToString() != "")
                {
                    reset();
                    lblIsAligned.Text = "";
                    //Set previous record location ID
                    ShowLastLocationID_RmDetailID();
                    //DataSet ds = new DataSet();
                    DSRMCode = new DataSet();
                    RMTransaction_Class_obj.rmcodeid = Convert.ToInt64(cmbRMCode.SelectedValue.ToString());
                    //ds = RMTransaction_Class_obj.Select_RMSupplierAgentMaster_RMSupplierMaster_RMCodeID();
                    DSRMCode = RMTransaction_Class_obj.Select_RMSupplierAgentMaster_RMSupplierMaster_RMCodeID();
                    DataRow dr = DSRMCode.Tables[0].NewRow();
                    dr["RMSupplierName"] = "--Select--";
                    dr["RMSupplierAgentID"] = "0";// "0";
                    DSRMCode.Tables[0].Rows.InsertAt(dr, 0);
                    if (DSRMCode.Tables[0].Rows.Count > 0)
                    {
                        cmbSupplier.DataSource = DSRMCode.Tables[0];
                        cmbSupplier.DisplayMember = "RMSupplierName";
                        cmbSupplier.ValueMember = "RMSupplierAgentID";
                    }

                    //Micro
                    DataSet dsMicro = new DataSet();
                    dsMicro = RMTransaction_Class_obj.Select_tblRMCodeMaster_Micro_RMCodeID();
                    if (dsMicro.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt16(dsMicro.Tables[0].Rows[0]["MicrobiologyTest"]) == 1)
                        {
                            labelMicro.Enabled = true;
                            RdoPositive.Enabled = true;
                            RdoNegative.Enabled = true;
                        }
                        else
                        {
                            labelMicro.Enabled = false;
                            RdoPositive.Enabled = false;
                            RdoNegative.Enabled = false;
                        }
                    }

                    ////Test already Done
                    //if (cmbRMCode.SelectedValue != null && cmbRMCode.Text != "--Select--" && cmbSupplier.SelectedValue != null && cmbSupplier.Text != "--Select--" )
                    //{
                    //    cmbTypeOfControl_SelectionChangeCommitted(sender, e);
                    //}                     
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbTypeOfControl_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dgTest.Rows.Clear();
                dgTest.Columns.Clear();

                if (txtProtocolNo.Text.Trim() != "" && txtProtocolNo.Text.StartsWith("RM"))
                {
                    int i = 0;
                    if (Int32.TryParse(txtProtocolNo.Text.Remove(0, 2), out i))
                    {
                        RMTransaction_Class_obj.rmsamplingid = Convert.ToInt64(i);
                    }

                    DataSet dsSamp = new DataSet();
                    dsSamp = RMTransaction_Class_obj.Select_tblRMSampling_ProtocolNo();
                    if (dsSamp.Tables[0].Rows.Count > 0)
                    {
                        RMTransaction_Class_obj.rmcodeid = Convert.ToInt64(dsSamp.Tables[0].Rows[0]["RMCodeID"]);
                        RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(dsSamp.Tables[0].Rows[0]["RMSupplierID"]);
                        RMTransaction_Class_obj.plantlotno = dsSamp.Tables[0].Rows[0]["PlantLotNo"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Record for " + txtProtocolNo.Text.Trim() + "not exists..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtProtocolNo.Focus();
                        return;
                    }
                }
                else
                {

                    if (cmbRMCode.SelectedValue != null)
                    {
                        RMTransaction_Class_obj.rmcodeid = Convert.ToInt64(cmbRMCode.SelectedValue);
                    }
                    else
                    {
                        RMTransaction_Class_obj.rmcodeid = 0;
                    }
                    if (cmbSupplier.SelectedValue != null)
                    {
                        if (cmbSupplier.SelectedValue.ToString() == "-1")
                        {
                            RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(dsProtocol.Tables[0].Rows[0]["RMSupplierID"].ToString());
                        }
                        if (cmbSupplier.SelectedValue.ToString() != "-1" && cmbSupplier.Text != "--Select--")
                        {
                            DataRow[] DtRowAgent = DSRMCode.Tables[0].Select("RMSupplierAgentID=" + Convert.ToInt64(cmbSupplier.SelectedValue.ToString()) + "");
                            RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(DtRowAgent[0]["RMSupplierID"].ToString());
                        }
                    }
                    else
                    {
                        RMTransaction_Class_obj.rmsupplierid = 0;
                    }
                    RMTransaction_Class_obj.plantlotno = txtPlantLotNo.Text.Trim();
                }

                RMTransaction_Class_obj.isvalidityexpanded = false;
                //// Search Depends on Type of Controls thats why Test the Type of Control
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

                        txtQuantityReceived.Text = dsRI.Tables[0].Rows[0]["QuantityReceived"].ToString();
                        txtQuantitySampled.Text = dsRI.Tables[0].Rows[0]["QuantitySampled"].ToString();
                        txtActualNoSegments.Text = dsRI.Tables[0].Rows[0]["ActualNoOfSegments"].ToString();
                        txtNoOfSegments.Text = dsRI.Tables[0].Rows[0]["NoOfSegments"].ToString();
                    }
                    else
                    {
                        dgTest["Identification", 0].Value = "";
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

                        txtQuantityReceived.Text = dsFC.Tables[0].Rows[0]["QuantityReceived"].ToString();
                        txtQuantitySampled.Text = dsFC.Tables[0].Rows[0]["QuantitySampled"].ToString();
                        txtActualNoSegments.Text = dsFC.Tables[0].Rows[0]["ActualNoOfSegments"].ToString();
                        txtNoOfSegments.Text = dsFC.Tables[0].Rows[0]["NoOfSegments"].ToString();
                    }
                    else
                    {
                        dgTest["Control", 0].Value = "";
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

                        txtQuantityReceived.Text = dsFI.Tables[0].Rows[0]["QuantityReceived"].ToString();
                        txtQuantitySampled.Text = dsFI.Tables[0].Rows[0]["QuantitySampled"].ToString();
                        txtActualNoSegments.Text = dsFI.Tables[0].Rows[0]["ActualNoOfSegments"].ToString();
                        txtNoOfSegments.Text = dsFI.Tables[0].Rows[0]["NoOfSegments"].ToString();
                    }
                    else
                    {
                        dgTest["Identification", 0].Value = "";
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

                        txtQuantityReceived.Text = dsFC.Tables[0].Rows[0]["QuantityReceived"].ToString();
                        txtQuantitySampled.Text = dsFC.Tables[0].Rows[0]["QuantitySampled"].ToString();
                        txtActualNoSegments.Text = dsFC.Tables[0].Rows[0]["ActualNoOfSegments"].ToString();
                        txtNoOfSegments.Text = dsFC.Tables[0].Rows[0]["NoOfSegments"].ToString();
                    }
                    else
                    {
                        dgTest["Control", 0].Value = "";
                    }
                }

                //-------- Display All details -----------------

                DataSet dsDetails = new DataSet();
                dsDetails = RMTransaction_Class_obj.Select_RMDetails();
                if (dsDetails.Tables[0].Rows.Count > 0)
                {
                    dtpInspDate.Value = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["InspDate"]);
                    dtpAcceptedDate.Value = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["AcceptedDate"]);
                    txtAgentName.Text = dsDetails.Tables[0].Rows[0]["AgentName"].ToString();
                    txtQuantityReceived.Text = dsDetails.Tables[0].Rows[0]["QuantityReceived"].ToString();
                    txtQuantitySampled.Text = dsDetails.Tables[0].Rows[0]["QuantitySampled"].ToString();
                    txtActualNoSegments.Text = dsDetails.Tables[0].Rows[0]["ActualNoOfSegments"].ToString();
                    txtNoOfSegments.Text = dsDetails.Tables[0].Rows[0]["NoOfSegments"].ToString();

                    dtpReceiptDate.Value = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["ReceiptDate"]);
                    txtSupplierLotNo.Text = dsDetails.Tables[0].Rows[0]["SupplierLotNo"].ToString();
                    dtpDateOfValidity.Value = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["ValidityDate"]);
                    if (dsDetails.Tables[0].Rows[0]["ManufacturinDate"].ToString() != "")
                    {
                        dtpManufacturingDate.CustomFormat = "dd-MMM-yyyy";
                        dtpManufacturingDate.Value = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["ManufacturinDate"]);
                    }
                    else
                        dtpManufacturingDate.CustomFormat = " ";

                    txtMRR.Text = dsDetails.Tables[0].Rows[0]["MRR"].ToString();
                    cmbLocation.Text = Convert.ToString(dsDetails.Tables[0].Rows[0]["location"]);
                    if (dsDetails.Tables[0].Rows[0]["SRC"].ToString() == "Y")
                    {
                        cmbConfirmation.Text = "Yes";
                    }
                    else if (dsDetails.Tables[0].Rows[0]["SRC"].ToString() == "N")
                    {
                        cmbConfirmation.Text = "No";
                    }

                    if (dsDetails.Tables[0].Rows[0]["FirstRMReception"].ToString() == "Y")
                    {
                        cmbFirstRMReception.Text = "Yes";
                    }
                    else if (dsDetails.Tables[0].Rows[0]["FirstRMReception"].ToString() == "N")
                    {
                        cmbFirstRMReception.Text = "No";
                    }

                    txtChallanNo.Text = dsDetails.Tables[0].Rows[0]["ChallanNo"].ToString();

                    if (dsDetails.Tables[0].Rows[0]["SRR"].ToString() == "Y")
                    {
                        cmbSupplierReportReceived.Text = "Yes";
                    }
                    else if (dsDetails.Tables[0].Rows[0]["SRR"].ToString() == "N")
                    {
                        cmbSupplierReportReceived.Text = "No";
                    }

                    if (Convert.ToString(dsDetails.Tables[0].Rows[0]["MicroStatus"]).Equals("+"))
                    {
                        RdoPositive.Checked = true;
                    }
                    else if (dsDetails.Tables[0].Rows[0]["MicroStatus"].ToString() == "-")
                    {
                        RdoNegative.Checked = true;
                    }
                    else
                    {
                        RdoPositive.Checked = false;
                        RdoNegative.Checked = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbTypeOfControl_Leave(object sender, EventArgs e)
        {
            cmbTypeOfControl_SelectionChangeCommitted(sender, e);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValid()
        {
            if (txtProtocolNo.Text.Trim() != "" && txtProtocolNo.Text.StartsWith("RM"))
            {
                if (MessageBox.Show("Continue with Protocol No\n\n" + txtProtocolNo.Text.Trim(), "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    txtProtocolNo.Focus();
                    return false;
                }
            }

            if (cmbRMCode.SelectedValue == null || cmbRMCode.Text == "--Select--")
            {
                MessageBox.Show("Please Select RMCode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbRMCode.Focus();
                return false;
            }
            if (cmbSupplier.SelectedValue == null || cmbSupplier.Text == "--Select--")
            {
                MessageBox.Show("Please Select Supplier", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSupplier.Focus();
                return false;
            }
            if (txtPlantLotNo.Text == "")
            {
                MessageBox.Show("Please Enter Plant Lot No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPlantLotNo.Focus();
                return false;
            }
            if (cmbLocation.Text == "--Select--")
            {
                MessageBox.Show("Please Select Retainer Location");
                cmbLocation.Focus();
                return false;
            }
            if (cmbTypeOfControl.Text == "--Select--")
            {
                MessageBox.Show("Please Select Type of Control", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbTypeOfControl.Focus();
                return false;
            }
            if (txtQuantityReceived.Text == "")
            {
                MessageBox.Show("Please Enter Quantity received", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantityReceived.Focus();
                return false;
            }
            if (txtQuantitySampled.Text == "")
            {
                MessageBox.Show("Please Enter Quantity Sampled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantitySampled.Focus();
                return false;
            }
            if (txtActualNoSegments.Text == "")
            {
                MessageBox.Show("Please Enter Actual Segments", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtActualNoSegments.Focus();
                return false;
            }
            if (txtNoOfSegments.Text == "")
            {
                MessageBox.Show("Please Enter No of Segments", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNoOfSegments.Focus();
                return false;
            }
            if (dgTest.Rows.Count == 0)
            {
                MessageBox.Show("No tests avaible..!\nPlease select type of control", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbTypeOfControl.Focus();
                return false;
            }
            if (RdoAccept.Checked == false && RdoReject.Checked == false && RdoSentToSupplier.Checked == false && RdoAWD.Checked == false && RdoHold.Checked == false)
            {
                MessageBox.Show("Select Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (RdoAccept.Checked == true)
            {
                if (MessageBox.Show("ACCEPT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    return false;
                }
            }
            if (RdoReject.Checked == true)
            {
                if (MessageBox.Show("REJECT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    return false;
                }
            }
            if (RdoAWD.Checked == true)
            {
                if (MessageBox.Show("ACCEPT WITH DERROGATION ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    return false;
                }
            }
            if (RdoSentToSupplier.Checked == true)
            {
                if (MessageBox.Show("SEND BACK TO SUPPLIER?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    return false;
                }
            }
            if (RdoHold.Checked == true)
            {
                if (MessageBox.Show("HOLD?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    return false;
                }
            }
            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {

                    //--------------- INSERT SAMPLING DETAILS -----------------------------------------------
                    if (cmbSupplier.SelectedValue.ToString() == "-1")
                    {
                        RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(dsProtocol.Tables[0].Rows[0]["RMSupplierID"].ToString());
                    }
                    if (cmbSupplier.SelectedValue.ToString() != "-1")
                    {
                        DataRow[] DtRowAgent = DSRMCode.Tables[0].Select("RMSupplierAgentID=" + Convert.ToInt64(cmbSupplier.SelectedValue.ToString()) + "");
                        RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(DtRowAgent[0]["RMSupplierID"].ToString());
                    }
                    RMTransaction_Class_obj.rmcodeid = Convert.ToInt64(cmbRMCode.SelectedValue.ToString());
                   // RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(DtRowAgent[0]["RMSupplierID"].ToString()); //Convert.ToInt64(cmbSupplier.SelectedValue.ToString());
                    RMTransaction_Class_obj.plantlotno = txtPlantLotNo.Text.Trim();
                    RMTransaction_Class_obj.quantityreceived = txtQuantityReceived.Text.ToString();
                    RMTransaction_Class_obj.quantitysampled = txtQuantitySampled.Text.ToString();
                    RMTransaction_Class_obj.actualnoofsegments = Convert.ToInt32(txtActualNoSegments.Text.ToString());
                    RMTransaction_Class_obj.noofsegments = Convert.ToInt32(txtNoOfSegments.Text.ToString());
                    RMTransaction_Class_obj.rmtransdone = true;
                    RMTransaction_Class_obj.isvalidityexpanded = false;
                    RMTransaction_Class_obj.isAligned = lblIsAligned.Text;
                    RMTransaction_Class_obj.halal = lblHalal.Text;
                    RMTransaction_Class_obj.plantOrigin = lblplantOrigin.Text;
                    RMTransaction_Class_obj.countryoforigin = lblCountryOfOrigin.Text;
                    RMTransaction_Class_obj.tradename = lblTradeName.Text;
                    Insert_Sampling();


                    //DataSet ds2 = new DataSet();
                    //ds2 = RMTransaction_Class_obj.Select_RMSampling_ForDuplicate();

                    //if (ds2.Tables[0].Rows.Count > 0)
                    //{
                    //    RMTransaction_Class_obj.rmsamplingid = Convert.ToInt64(ds2.Tables[0].Rows[0]["RMSamplingID"]);
                    //    bool b = RMTransaction_Class_obj.Update_RMSampling();
                    //}
                    //else
                    //{
                    //    RMTransaction_Class_obj.rmsamplingid = RMTransaction_Class_obj.Insert_RMSampling();
                    //}

                    //------------------- INSERT TRANSACTION DETAILS --------------------------------------

                    if (cmbTypeOfControl.Text == "Reduced Control")
                    {
                        RMTransaction_Class_obj.methodtype = 'R';
                    }
                    else if (cmbTypeOfControl.Text == "Full Control")
                    {
                        RMTransaction_Class_obj.methodtype = 'F';
                    }


                    if (chkSubcontract.Checked)
                    {
                        RMTransaction_Class_obj.subContract = true;
                    }
                    else
                    {
                        RMTransaction_Class_obj.subContract = false;
                    
                    }
                    RMTransaction_Class_obj.validitydate = dtpDateOfValidity.Value.ToShortDateString();
                    if (dtpManufacturingDate.Text.Trim() != "")
                        RMTransaction_Class_obj.mfgDate = Convert.ToDateTime(dtpManufacturingDate.Value.ToShortDateString());

                    RMTransaction_Class_obj.remainingquantity = 0;
                    RMTransaction_Class_obj.currentflagtrans = true;
                    RMTransaction_Class_obj.loginid = FrmMain.LoginID;

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

                    //----------------- INSERT DETAILS ---------------------------------------------

                    RMTransaction_Class_obj.inspdate = dtpInspDate.Value.ToShortDateString();
                    RMTransaction_Class_obj.accepteddate = dtpAcceptedDate.Value.ToShortDateString();
                    RMTransaction_Class_obj.agentname = txtAgentName.Text.Trim();
                    RMTransaction_Class_obj.receiptdate = dtpReceiptDate.Value.ToShortDateString();
                    RMTransaction_Class_obj.supplierlotno = txtSupplierLotNo.Text.ToString();

                    RMTransaction_Class_obj.mrr = txtMRR.Text.ToString();
                    if (cmbConfirmation.Text == "Yes")
                    {
                        RMTransaction_Class_obj.src = 'Y';
                    }
                    else
                    {
                        RMTransaction_Class_obj.src = 'N';
                    }
                    RMTransaction_Class_obj.challanno = txtChallanNo.Text.ToString();
                    if (cmbSupplierReportReceived.Text == "Yes")
                    {
                        RMTransaction_Class_obj.srr = 'Y';
                    }
                    else
                    {
                        RMTransaction_Class_obj.srr = 'N';
                    }

                    if (cmbFirstRMReception.Text == "No")
                    {
                        RMTransaction_Class_obj.firstrmreception = 'N';
                    }
                    else
                    {
                        RMTransaction_Class_obj.firstrmreception = 'Y';
                    }

                    RMTransaction_Class_obj.locationID = Convert.ToInt64(cmbLocation.SelectedValue);

                    //// This code only for old RM Codes if location ID is 0 then problem to insert record in tblRMDetails so by deafualt location is 0000 means location ID is 24
                    //if (RMTransaction_Class_obj.locationID == 0)
                    //    RMTransaction_Class_obj.locationID = 24;


                    if (chkLabelForRetainer.Checked == true)
                    {
                        RMTransaction_Class_obj.labelforretainer = 'Y';
                    }
                    else
                    {
                        RMTransaction_Class_obj.labelforretainer = 'N';
                    }
                    if (cmbConfirmation.Text == "Yes")
                    {
                        RMTransaction_Class_obj.src = Convert.ToChar("Y");
                    }
                    else if (cmbConfirmation.Text == "No")
                    {
                        RMTransaction_Class_obj.src = Convert.ToChar("N");
                    }

                    if (RdoPositive.Checked == true)
                    {
                        RMTransaction_Class_obj.microstatus = "+";
                    }
                    else if (RdoNegative.Checked == true)
                    {
                        RMTransaction_Class_obj.microstatus = "-";
                    }
                    else
                    {
                        RMTransaction_Class_obj.microstatus = null;
                    }

                    DataSet ds4 = new DataSet();
                    ds4 = RMTransaction_Class_obj.Select_tblRMDetails_RMSamplingID();

                    if (ds4.Tables[0].Rows.Count > 0)
                    {
                        RMTransaction_Class_obj.rmdetailid = Convert.ToInt64(ds4.Tables[0].Rows[0]["RMDetailID"]);
                        RMTransaction_Class_obj.Update_RMDetails();
                    }
                    else
                    {
                        RMTransaction_Class_obj.Insert_RMDetails();
                    }

                    //----------------- INSERT STATUS DETAILS----------------------

                    if (RdoAccept.Checked == true)
                    {
                        RMTransaction_Class_obj.status = Convert.ToChar("A");
                    }
                    else if (RdoReject.Checked == true)
                    {
                        RMTransaction_Class_obj.status = Convert.ToChar("R");
                        RMTransaction_Class_obj.rejectdescription = txtRejectDescription.Text.Trim();
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        RMTransaction_Class_obj.status = Convert.ToChar("D");
                    }
                    else if (RdoSentToSupplier.Checked == true)
                    {
                        RMTransaction_Class_obj.status = Convert.ToChar("S");
                    }
                    else if (RdoHold.Checked == true)
                    {
                        RMTransaction_Class_obj.status = Convert.ToChar("H");
                    }
                 

                    RMTransaction_Class_obj.nonconreason = "";
                    RMTransaction_Class_obj.acceptedquantity = 0;
                    RMTransaction_Class_obj.comment = "";
                    RMTransaction_Class_obj.currentflagstatus = true;
                    RMTransaction_Class_obj.loginid = FrmMain.LoginID;


                    DataSet ds5 = new DataSet();
                    ds5 = RMTransaction_Class_obj.Select_tblRMStatus_RMTransID();
                    if (ds5.Tables[0].Rows.Count > 0)
                    {
                        RMTransaction_Class_obj.statusid = Convert.ToInt64(ds5.Tables[0].Rows[0]["StatusID"]);
                        RMTransaction_Class_obj.Update_RMStatus();
                    }
                    else
                    {
                        RMTransaction_Class_obj.Insert_RMStatus();
                    }

                    if (MessageBox.Show("Record Saved Successfully\n\nPrint Protocol?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        BtnRMProtocol_Click(sender, e);
                    }

                    reset();
                    txtProtocolNo.Text = "";
                    alterPlantNO = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Insert_Sampling()
        {
            if (txtProtocolNo.Text.Trim() != "" && txtProtocolNo.Text.StartsWith("RM"))
            {
                int i = 0;
                if (Int32.TryParse(txtProtocolNo.Text.Remove(0, 2), out i))
                {
                    RMTransaction_Class_obj.rmsamplingid = Convert.ToInt64(i);
                }

                DataSet dsSamp = new DataSet();
                dsSamp = RMTransaction_Class_obj.Select_tblRMSampling_ProtocolNo();
                if (dsSamp.Tables[0].Rows.Count > 0)
                {
                    bool update = false;
                    if (Convert.ToInt64(cmbRMCode.SelectedValue) != Convert.ToInt64(dsSamp.Tables[0].Rows[0]["RMCodeID"]))
                    {
                        if (MessageBox.Show("Modify RMCode", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            cmbRMCode.Focus();
                            return;
                        }
                        else
                        {
                            update = true;
                        }
                    }
                    if (cmbSupplier.SelectedValue.ToString() != "-1") //||
                    {
                        Int64 RMSamplingId = 0;
                        DataRow [] dtr=DSRMCode.Tables[0].Select("RMSupplierAgentID=" + Convert.ToInt64(cmbSupplier.SelectedValue) + "");
                        if (dtr.Length > 0)
                        {
                           RMSamplingId = Convert.ToInt64(dtr[0]["RMSupplierID"].ToString());// Convert.ToInt64(((DataRow[])(DSRMCode.Tables[0].Select("RMSupplierAgentID=" + Convert.ToInt64(cmbSupplier.SelectedValue) + "")))[0]["RMSupplierID"].ToString());
                           if (RMSamplingId != Convert.ToInt64(dsSamp.Tables[0].Rows[0]["RMSupplierID"]))//)
                           {
                               if (MessageBox.Show("Modify Supplier", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                               {
                                   cmbSupplier.Focus();
                                   return;
                               }
                               else
                               {
                                   update = true;
                               }
                           }
                        }
                       
                    }
                    if (txtPlantLotNo.Text.Trim() != dsSamp.Tables[0].Rows[0]["PlantLotNo"].ToString())
                    {
                        if (MessageBox.Show("Modify PlantLotNo", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            txtPlantLotNo.Focus();
                            return;
                        }
                        else
                        {
                            update = true;
                        }
                    }

                    if (update == true)
                    {
                        DataSet ds2 = new DataSet();
                        ds2 = RMTransaction_Class_obj.Select_RMSampling_ForDuplicate();

                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            RMTransaction_Class_obj.rmsamplingid = Convert.ToInt64(ds2.Tables[0].Rows[0]["RMSamplingID"]);
                            MessageBox.Show("Record for this RMCode, Supplier, PlantLotNo already exists..!" + "\n\nRM" + RMTransaction_Class_obj.rmsamplingid.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        else
                        {
                            bool b = RMTransaction_Class_obj.Update_RMSampling();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Record for " + txtProtocolNo.Text.Trim() + "not exists..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtProtocolNo.Focus();
                    return;
                }
            }
            else
            {
                DataSet ds2 = new DataSet();
                ds2 = RMTransaction_Class_obj.Select_RMSampling_ForDuplicate();

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    RMTransaction_Class_obj.rmsamplingid = Convert.ToInt64(ds2.Tables[0].Rows[0]["RMSamplingID"]);
                    //MessageBox.Show("Record for this RMCode, Supplier, PlantLotNo already exists..!" + "\n\nRM" + RMTransaction_Class_obj.rmsamplingid.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //txtProtocolNo.Focus();
                    return;
                }
                else
                {
                    RMTransaction_Class_obj.rmsamplingid = RMTransaction_Class_obj.Insert_RMSampling();
                }
            }


            ///*Created by : [Manish k]
            txtPlantLotNo.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRMCode.Text == "--Select--")
                {
                    MessageBox.Show("Please Select RM Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbRMCode.Focus();
                    return;
                }
                if (cmbSupplier.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Supplier", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSupplier.Focus();
                    return;
                }
                if (txtPlantLotNo.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Plant Lot No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPlantLotNo.Focus();
                    return;
                }
                if (cmbSupplier.SelectedValue.ToString() == "-1")
                {
                    RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(dsProtocol.Tables[0].Rows[0]["RMSupplierID"].ToString());
                }
                if (cmbSupplier.SelectedValue.ToString() != "-1")
                {
                    DataRow[] DtRowAgent = DSRMCode.Tables[0].Select("RMSupplierAgentID=" + Convert.ToInt64(cmbSupplier.SelectedValue.ToString()) + "");
                    RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(DtRowAgent[0]["RMSupplierID"].ToString());
                }
                RMTransaction_Class_obj.rmcodeid = Convert.ToInt64(cmbRMCode.SelectedValue.ToString());
               // RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(DtRowAgent[0]["RMSupplierID"].ToString());//Convert.ToInt64(cmbSupplier.SelectedValue.ToString());
                RMTransaction_Class_obj.plantlotno = txtPlantLotNo.Text.Trim();

                if (MessageBox.Show("Are You sure want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    bool b = RMTransaction_Class_obj.Delete_tblRMSampling();
                    if (b == true)
                    {
                        MessageBox.Show("Record deleted Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }
                txtProtocolNo.Text = "";
            }
            catch
            {
                MessageBox.Show("Sorry you Can't Delete this Record", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRMProtocol_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRMCode.SelectedValue == null || cmbRMCode.Text == "--Select--")
                {
                    MessageBox.Show("Please Select RMCode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbRMCode.Focus();
                    return;
                }
                if (cmbSupplier.SelectedValue == null || cmbSupplier.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Supplier", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbSupplier.Focus();
                    return;
                }
                if (txtPlantLotNo.Text == "")
                {
                    MessageBox.Show("Please Enter Plant Lot No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPlantLotNo.Focus();
                    return;
                }
                if (txtQuantityReceived.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity received", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantityReceived.Focus();
                    return;
                }
                if (txtQuantitySampled.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity Sampled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQuantitySampled.Focus();
                    return;
                }
                if (txtActualNoSegments.Text == "")
                {
                    MessageBox.Show("Please Enter Actual Segments", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtActualNoSegments.Focus();
                    return;
                }
                if (txtNoOfSegments.Text == "")
                {
                    MessageBox.Show("Please Enter No of Segments", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNoOfSegments.Focus();
                    return;
                }
                if (dgTest.Rows.Count == 0)
                {
                    MessageBox.Show("No tests avaible..!\nPlease select type of control", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbTypeOfControl.Focus();
                    return;
                }
                //if (cmbLocation.Text == "--Select--")
                //{
                //    MessageBox.Show("Please Select Retainer Location");
                //    cmbLocation.Focus();
                //    return;
                //}
                //--------------- INSERT SAMPLING DETAILS -----------------------------------------------
                 if (cmbSupplier.SelectedValue.ToString() == "-1")
                {
                    RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(dsProtocol.Tables[0].Rows[0]["RMSupplierID"].ToString());
                }
                if (cmbSupplier.SelectedValue.ToString() != "-1")
                {
                    DataRow[] DtRowAgent = DSRMCode.Tables[0].Select("RMSupplierAgentID=" + Convert.ToInt64(cmbSupplier.SelectedValue.ToString()) + "");
                    RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(DtRowAgent[0]["RMSupplierID"].ToString());
                }//
                RMTransaction_Class_obj.rmcodeid = Convert.ToInt64(cmbRMCode.SelectedValue.ToString());
                RMTransaction_Class_obj.plantlotno = txtPlantLotNo.Text.Trim();
                RMTransaction_Class_obj.quantityreceived = txtQuantityReceived.Text.ToString();
                RMTransaction_Class_obj.quantitysampled = txtQuantitySampled.Text.ToString();
                RMTransaction_Class_obj.actualnoofsegments = Convert.ToInt32(txtActualNoSegments.Text.ToString());
                RMTransaction_Class_obj.noofsegments = Convert.ToInt32(txtNoOfSegments.Text.ToString());
                RMTransaction_Class_obj.rmtransdone = true;
                RMTransaction_Class_obj.isvalidityexpanded = false;
                RMTransaction_Class_obj.locationID = Convert.ToInt64(cmbLocation.SelectedValue);
                RMTransaction_Class_obj.isAligned = lblIsAligned.Text;
                RMTransaction_Class_obj.halal = lblHalal.Text;
                RMTransaction_Class_obj.plantOrigin = lblplantOrigin.Text;
                RMTransaction_Class_obj.countryoforigin = lblCountryOfOrigin.Text;
                RMTransaction_Class_obj.tradename = lblTradeName.Text;
                Insert_Sampling();

                //DataSet ds2 = new DataSet();
                //ds2 = RMTransaction_Class_obj.Select_RMSampling_ForDuplicate();

                //if (ds2.Tables[0].Rows.Count > 0)
                //{
                //    RMTransaction_Class_obj.rmsamplingid = Convert.ToInt64(ds2.Tables[0].Rows[0]["RMSamplingID"]);
                //    bool b = RMTransaction_Class_obj.Update_RMSampling();
                //}
                //else
                //{
                //    RMTransaction_Class_obj.rmsamplingid = RMTransaction_Class_obj.Insert_RMSampling();
                //}

                //------------------- INSERT TRANSACTION DETAILS --------------------------------------

                if (cmbTypeOfControl.Text == "Reduced Control")
                {
                    RMTransaction_Class_obj.methodtype = 'R';
                }
                else if (cmbTypeOfControl.Text == "Full Control")
                {
                    RMTransaction_Class_obj.methodtype = 'F';
                }

                if (chkSubcontract.Checked)
                {
                    RMTransaction_Class_obj.subContract = true;
                }
                else
                {
                    RMTransaction_Class_obj.subContract = false;

                }

                RMTransaction_Class_obj.validitydate = dtpDateOfValidity.Value.ToShortDateString();
                //RMTransaction_Class_obj.mfgDate = Convert.ToDateTime(dtpManufacturingDate.Value.ToShortDateString());

                RMTransaction_Class_obj.remainingquantity = 0;
                RMTransaction_Class_obj.currentflagtrans = true;
                RMTransaction_Class_obj.loginid = FrmMain.LoginID;

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

                //----------------- INSERT DETAILS ---------------------------------------------

                RMTransaction_Class_obj.inspdate = dtpInspDate.Value.ToShortDateString();
                RMTransaction_Class_obj.accepteddate = dtpAcceptedDate.Value.ToShortDateString();
                RMTransaction_Class_obj.agentname = txtAgentName.Text.Trim();
                RMTransaction_Class_obj.receiptdate = dtpReceiptDate.Value.ToShortDateString();
                RMTransaction_Class_obj.supplierlotno = txtSupplierLotNo.Text.ToString();

                RMTransaction_Class_obj.mrr = txtMRR.Text.ToString();
                if (cmbConfirmation.Text == "Yes")
                {
                    RMTransaction_Class_obj.src = 'Y';
                }
                else
                {
                    RMTransaction_Class_obj.src = 'N';
                }
                RMTransaction_Class_obj.challanno = txtChallanNo.Text.ToString();
                if (cmbSupplierReportReceived.Text == "Yes")
                {
                    RMTransaction_Class_obj.srr = 'Y';
                }
                else
                {
                    RMTransaction_Class_obj.srr = 'N';
                }
                if (cmbFirstRMReception.Text == "No")
                {
                    RMTransaction_Class_obj.firstrmreception = 'N';
                }
                else
                {
                    RMTransaction_Class_obj.firstrmreception = 'Y';
                }
                if (chkLabelForRetainer.Checked == true)
                {
                    RMTransaction_Class_obj.labelforretainer = 'Y';
                }
                else
                {
                    RMTransaction_Class_obj.labelforretainer = 'N';
                }
                if (cmbConfirmation.Text == "Yes")
                {
                    RMTransaction_Class_obj.src = Convert.ToChar("Y");
                }
                else if (cmbConfirmation.Text == "No")
                {
                    RMTransaction_Class_obj.src = Convert.ToChar("N");
                }

                string MicroStatus = "";

                if (RdoPositive.Checked == true)
                {
                    RMTransaction_Class_obj.microstatus = "+";
                    MicroStatus = "+ve";
                }
                else if (RdoNegative.Checked == true)
                {
                    RMTransaction_Class_obj.microstatus = "-";
                    MicroStatus = "-ve";
                }
                else
                {
                    RMTransaction_Class_obj.microstatus = null;
                    MicroStatus = "";
                }

                DataSet ds4 = new DataSet();
                ds4 = RMTransaction_Class_obj.Select_tblRMDetails_RMSamplingID();
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    RMTransaction_Class_obj.rmdetailid = Convert.ToInt64(ds4.Tables[0].Rows[0]["RMDetailID"]);
                    RMTransaction_Class_obj.Update_RMDetails();
                }
                else
                {
                    RMTransaction_Class_obj.Insert_RMDetails();
                }

                //Set protocol No
                string ProtocolNo = "";
                if (RMTransaction_Class_obj.rmsamplingid != 0)
                {
                    ProtocolNo = "RM" + RMTransaction_Class_obj.rmsamplingid.ToString().PadLeft(6, '0');
                }

                //Get data for same supplier and SupplierLotNo
                DataSet dsSpl = new DataSet();
                dsSpl = RMTransaction_Class_obj.Select_View_RMProtocol_Supplier_Report();

                //Get test data for Protocol
                DataSet ds = new DataSet();
                RMTransaction_Class_obj.rmcodeid = Convert.ToInt64(cmbRMCode.SelectedValue.ToString());
                if (cmbTypeOfControl.Text == "Reduced Control")
                {
                    RMTransaction_Class_obj.testtype = "Identification";
                    if (dgTest["Identification", 0].Value.ToString() == "Done")
                    {
                        ds = RMTransaction_Class_obj.Select_View_RMProtocol_Done_Report_TestType();
                    }
                    else
                    {
                        ds = RMTransaction_Class_obj.Select_View_RMProtocol_Report_TestType();
                    }
                }
                else if (cmbTypeOfControl.Text == "Full Control")
                {
                    if (dgTest["Identification", 0].Value.ToString() == "Done" || dgTest["Control", 0].Value.ToString() == "Done")
                    {
                        ds = RMTransaction_Class_obj.Select_View_RMProtocol_Done_Report();
                    }
                    else
                    {
                        ds = RMTransaction_Class_obj.Select_View_RMProtocol_Report();
                    }
                }


                //Open PopUp
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string Allign = String.Empty;
                    if (!string.IsNullOrEmpty(lblIsAligned.Text))
                    {
                        if (lblIsAligned.Text.Equals("Aligned",StringComparison.CurrentCultureIgnoreCase))
                        {
                            Allign = "Alligned";
                        }
                        else
                        {
                            Allign = "NotAlligned";
                        }
                    }
                    else
                    {
                        Allign = "NotAlligned";
                    }
                    QTMS.Reports_Forms.FrmRMProtocol pro = new QTMS.Reports_Forms.FrmRMProtocol("RMProtocol", ds.Tables[0], dsSpl.Tables[0], cmbSupplier.Text, txtPlantLotNo.Text, txtSupplierLotNo.Text.Trim(), cmbTypeOfControl.Text.Trim(), dtpDateOfValidity.Value.ToShortDateString(), dtpReceiptDate.Value.ToShortDateString(), txtQuantityReceived.Text.Trim(), txtQuantitySampled.Text.Trim(), txtActualNoSegments.Text.Trim(), txtNoOfSegments.Text.Trim(), ProtocolNo, MicroStatus, dtpInspDate.Value.ToShortDateString(), txtAgentName.Text.Trim(), Convert.ToString(cmbLocation.Text),Allign);
                    pro.Show();
                }
                else
                {
                    MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                txtProtocolNo.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (cmbRMCode.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRMCode.Focus();
                    return;
                }
                if (txtPlantLotNo.Text == "")
                {
                    MessageBox.Show("Please Enter Plant Lot No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPlantLotNo.Focus();
                    return;
                }


                DataTable dt = new DataTable();
                dt.Columns.Add("RMCode");
                dt.Columns.Add("PlantLotNo");
                dt.Columns.Add("ReceiptDate");
                dt.Columns.Add("DisposalDate");
                dt.Columns.Add("SafetyImage1", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage2", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage3", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage4", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage5", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage6", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage7", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage8", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage9", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage10", System.Type.GetType("System.Byte[]"));

                dt.Columns.Add("AccessImage1", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage2", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage3", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage4", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage5", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage6", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage7", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage8", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage9", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage10", System.Type.GetType("System.Byte[]"));
                //dt.Columns.Add("SafetySymbol2", "System.Byte[]".GetType());
                DataSet ds = new DataSet();
                RMTransaction_Class_obj.rmcodeid = Convert.ToInt64(cmbRMCode.SelectedValue.ToString());
                ds = RMTransaction_Class_obj.Select_SefetySymbol_RmCodeID();

                DataRow dr;
                dr = dt.NewRow();
                dr["RMCode"] = cmbRMCode.Text.Trim();
                dr["PlantLotNo"] = txtPlantLotNo.Text.Trim();
                dr["ReceiptDate"] = dtpReceiptDate.Value.ToShortDateString();
                //dr["DisposalDate"] = dtpDateOfValidity.Value.ToShortDateString();
                dr["DisposalDate"] = dtpReceiptDate.Value.AddYears(4).ToShortDateString();
                //byte[] b = dr1["SymImage"]; 
                Image Img = global::QTMS.Properties.Resources.white;

                string SafetyImageName = "";
                //DataTable ImgDt = new DataTable();
                //ImgDt = RMTransaction_Class_obj.Select_RMSAWhiteImage();
                int MaxLoopCount = ds.Tables[0].Rows.Count;//Maintain loop for maximum of 10 Safety images
                if (MaxLoopCount > 9)
                    MaxLoopCount = 9;
                else
                {
                    for (int j = MaxLoopCount + 1; j <= 9; j++)
                    {

                        byte[] data = null;
                        MemoryStream ms = new MemoryStream();
                        Img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        data = ms.ToArray();
                        ms.Close();
                        SafetyImageName = "SafetyImage" + j.ToString();
                        dr[SafetyImageName] = data;//(byte[])(ImgDt.Rows[0]["SAWImg"]);
                        //if (ImgDt.Rows.Count > 0)
                        //{
                        //    SafetyImageName = "SafetyImage" + j.ToString();
                        //    dr[SafetyImageName] = (byte[])(ImgDt.Rows[0]["SAWImg"]);
                        //}


                    }
                }
                for (int i = 1; i <= MaxLoopCount; i++)
                {
                    SafetyImageName = "SafetyImage" + i.ToString();
                    dr[SafetyImageName] = (byte[])(ds.Tables[0].Rows[i - 1]["SymImage"]);
                }

                MaxLoopCount = ds.Tables[1].Rows.Count;//Maintain loop for maximum of 10 Accessories images
                if (MaxLoopCount > 9)
                    MaxLoopCount = 9;
                else
                {
                    for (int j = MaxLoopCount + 1; j <= 9; j++)
                    {
                        byte[] data = null;
                        //Image Img = global::QTMS.Properties.Resources.white;
                        MemoryStream ms = new MemoryStream();
                        Img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        data = ms.ToArray();

                        SafetyImageName = "AccessImage" + j.ToString();
                        dr[SafetyImageName] = data;
                        //SafetyImageName = "AccessImage" + j.ToString();

                        //byte[] data = null;

                        ////Use FileInfo to get file size
                        //FileInfo fInfo = new FileInfo(sPath);

                        //long numBytes = fInfo.Length;

                        //// Open fileStream to read file
                        //FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

                        //// Use BinaryReader to read the data into bytearray
                        //BinaryReader br = new BinaryReader(fStream);

                        //data = br.ReadBytes((int)numBytes);

                        //dr[SafetyImageName] = data;//(byte[])(ImgDt.Rows[0]["SAWImg"]);
                        //if (ImgDt.Rows.Count > 0)
                        //{
                        //    SafetyImageName = "AccessImage" + j.ToString();
                        //    dr[SafetyImageName] = (byte[])(ImgDt.Rows[0]["SAWImg"]);
                        //}
                    }
                }
                for (int i = 1; i <= MaxLoopCount; i++)
                {
                    SafetyImageName = "AccessImage" + i.ToString();
                    dr[SafetyImageName] = (byte[])(ds.Tables[1].Rows[i - 1]["SymImage"]);
                }


                dt.Rows.Add(dr);

                QTMS.Reports_Forms.FrmRetainerLabel frm = new QTMS.Reports_Forms.FrmRetainerLabel(dt);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtActualNoSegments_Leave(object sender, EventArgs e)
        {
            try
            {
                txtNoOfSegments.Text = "";
                lblMsgSampling.Text = "";
                lblMsgSampling.Visible = false;

                if (txtQuantitySampled.Text != "" && txtActualNoSegments.Text != "")
                {

                    lblMsgSampling.Visible = true;
                    double NoOfSegments;
                    NoOfSegments = Convert.ToDouble(txtActualNoSegments.Text.ToString());
                    double real = Math.Sqrt(NoOfSegments);
                    double fraction = real - Math.Floor(real);
                    if (fraction <= 0.5)
                    {
                        txtNoOfSegments.Text = Convert.ToString(Math.Floor(real) + 1);
                    }
                    else
                    {
                        txtNoOfSegments.Text = Convert.ToString(Math.Ceiling(real) + 1);
                    }
                    lblMsgSampling.Text = txtQuantitySampled.Text + "  " + "Samples Collected from" + "  " + txtNoOfSegments.Text + "  " + "Segments";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQuantitySampled_Leave(object sender, EventArgs e)
        {
            txtActualNoSegments_Leave(sender, e);
        }

        private void txtActualNoSegments_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void txtQuantitySampled_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void txtNoOfSegments_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void txtQuantityReceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void dgTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == 0)
                {
                    if (cmbRMCode.SelectedValue == null || cmbRMCode.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select RMCode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbRMCode.Focus();
                        return;
                    }
                    if (cmbSupplier.SelectedValue == null || cmbSupplier.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select Supplier", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbSupplier.Focus();
                        return;
                    }
                    if (txtPlantLotNo.Text == "")
                    {
                        MessageBox.Show("Please Enter Plant Lot No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPlantLotNo.Focus();
                        return;
                    }
                    if (txtQuantityReceived.Text == "")
                    {
                        MessageBox.Show("Please Enter Quantity received", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantityReceived.Focus();
                        return;
                    }
                    if (txtQuantitySampled.Text == "")
                    {
                        MessageBox.Show("Please Enter Quantity Sampled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantitySampled.Focus();
                        return;
                    }
                    if (txtActualNoSegments.Text == "")
                    {
                        MessageBox.Show("Please Enter Actual Segments", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtActualNoSegments.Focus();
                        return;
                    }
                    if (txtNoOfSegments.Text == "")
                    {
                        MessageBox.Show("Please Enter No of Segments", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNoOfSegments.Focus();
                        return;
                    }
                    if (cmbLocation.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select Retainer Location");
                        cmbLocation.Focus();
                        return;
                    }

                    //--------------- INSERT SAMPLING DETAILS -----------------------------------------------
                    if (cmbSupplier.SelectedValue.ToString() == "-1")
                    {
                        RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(dsProtocol.Tables[0].Rows[0]["RMSupplierID"].ToString());
                    }
                    if (cmbSupplier.SelectedValue.ToString() != "-1")
                    {
                        DataRow[] DtRowAgent = DSRMCode.Tables[0].Select("RMSupplierAgentID=" + Convert.ToInt64(cmbSupplier.SelectedValue.ToString()) + "");
                        RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(DtRowAgent[0]["RMSupplierID"].ToString());
                    }//
                    RMTransaction_Class_obj.rmcodeid = Convert.ToInt64(cmbRMCode.SelectedValue.ToString());
                    //Convert.ToInt64(cmbSupplier.SelectedValue.ToString());
                    RMTransaction_Class_obj.plantlotno = txtPlantLotNo.Text.Trim();
                    RMTransaction_Class_obj.quantityreceived = txtQuantityReceived.Text.ToString();
                    RMTransaction_Class_obj.quantitysampled = txtQuantitySampled.Text.ToString();
                    RMTransaction_Class_obj.actualnoofsegments = Convert.ToInt32(txtActualNoSegments.Text.ToString());
                    RMTransaction_Class_obj.noofsegments = Convert.ToInt32(txtNoOfSegments.Text.ToString());
                    //Change this flag to true (Ganesh 18 Oct 2011) Old flag is false changed to true
                    RMTransaction_Class_obj.rmtransdone = true;
                    RMTransaction_Class_obj.isvalidityexpanded = false;
                    RMTransaction_Class_obj.isAligned = lblIsAligned.Text;
                    RMTransaction_Class_obj.halal = lblHalal.Text;
                    RMTransaction_Class_obj.plantOrigin = lblplantOrigin.Text;
                    RMTransaction_Class_obj.countryoforigin = lblCountryOfOrigin.Text;
                    RMTransaction_Class_obj.tradename = lblTradeName.Text;
                    Insert_Sampling();

                    //DataSet ds2 = new DataSet();
                    //ds2 = RMTransaction_Class_obj.Select_RMSampling_ForDuplicate();

                    //if (ds2.Tables[0].Rows.Count > 0)
                    //{
                    //    RMTransaction_Class_obj.rmsamplingid = Convert.ToInt64(ds2.Tables[0].Rows[0]["RMSamplingID"]);
                    //    bool b = RMTransaction_Class_obj.Update_RMSampling();                     
                    //}
                    //else
                    //{
                    //    RMTransaction_Class_obj.rmsamplingid = RMTransaction_Class_obj.Insert_RMSampling();
                    //}

                    //------------------- INSERT TRANSACTION DETAILS --------------------------------------

                    if (cmbTypeOfControl.Text == "Reduced Control")
                    {
                        RMTransaction_Class_obj.methodtype = 'R';
                    }
                    else if (cmbTypeOfControl.Text == "Full Control")
                    {
                        RMTransaction_Class_obj.methodtype = 'F';
                    }

                    RMTransaction_Class_obj.validitydate = dtpDateOfValidity.Value.ToShortDateString();

                    if (dtpManufacturingDate.Text.Trim() != "")
                        RMTransaction_Class_obj.mfgDate = Convert.ToDateTime(dtpManufacturingDate.Value.ToShortDateString());

                    if (chkSubcontract.Checked)
                    {
                        RMTransaction_Class_obj.subContract = true;
                    }
                    else
                    {

                        RMTransaction_Class_obj.subContract = false;
                    }

                    RMTransaction_Class_obj.remainingquantity = 0;
                    RMTransaction_Class_obj.currentflagtrans = true;
                    RMTransaction_Class_obj.loginid = FrmMain.LoginID;

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

                    //----------------- INSERT DETAILS ---------------------------------------------

                    RMTransaction_Class_obj.inspdate = dtpInspDate.Value.ToShortDateString();
                    RMTransaction_Class_obj.accepteddate = dtpAcceptedDate.Value.ToShortDateString();
                    RMTransaction_Class_obj.agentname = txtAgentName.Text.Trim();
                    RMTransaction_Class_obj.receiptdate = dtpReceiptDate.Value.ToShortDateString();
                    RMTransaction_Class_obj.supplierlotno = txtSupplierLotNo.Text.ToString();
                    RMTransaction_Class_obj.locationID = Convert.ToInt64(cmbLocation.SelectedValue);
                    RMTransaction_Class_obj.mrr = txtMRR.Text.ToString();
                    if (cmbConfirmation.Text == "Yes")
                    {
                        RMTransaction_Class_obj.src = 'Y';
                    }
                    else
                    {
                        RMTransaction_Class_obj.src = 'N';
                    }
                    RMTransaction_Class_obj.challanno = txtChallanNo.Text.ToString();
                    if (cmbSupplierReportReceived.Text == "Yes")
                    {
                        RMTransaction_Class_obj.srr = 'Y';
                    }
                    else
                    {
                        RMTransaction_Class_obj.srr = 'N';
                    }
                    if (cmbFirstRMReception.Text == "No")
                    {
                        RMTransaction_Class_obj.firstrmreception = 'N';
                    }
                    else
                    {
                        RMTransaction_Class_obj.firstrmreception = 'Y';
                    }
                    if (chkLabelForRetainer.Checked == true)
                    {
                        RMTransaction_Class_obj.labelforretainer = 'Y';
                    }
                    else
                    {
                        RMTransaction_Class_obj.labelforretainer = 'N';
                    }
                    if (cmbConfirmation.Text == "Yes")
                    {
                        RMTransaction_Class_obj.src = Convert.ToChar("Y");
                    }
                    else if (cmbConfirmation.Text == "No")
                    {
                        RMTransaction_Class_obj.src = Convert.ToChar("N");
                    }

                    if (RdoPositive.Checked == true)
                    {
                        RMTransaction_Class_obj.microstatus = "+";
                    }
                    else if (RdoNegative.Checked == true)
                    {
                        RMTransaction_Class_obj.microstatus = "-";
                    }
                    else
                    {
                        RMTransaction_Class_obj.microstatus = null;
                    }

                    DataSet ds4 = new DataSet();
                    ds4 = RMTransaction_Class_obj.Select_tblRMDetails_RMSamplingID();
                    if (ds4.Tables[0].Rows.Count > 0)
                    {
                        RMTransaction_Class_obj.rmdetailid = Convert.ToInt64(ds4.Tables[0].Rows[0]["RMDetailID"]);
                        RMTransaction_Class_obj.Update_RMDetails();
                    }
                    else
                    {
                        RMTransaction_Class_obj.Insert_RMDetails();
                    }

                    //-------------------------- OPEN POPUP WINDOW --------------------


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

                        if (dgTest[e.ColumnIndex, 0].Value.ToString() == "Done")
                        {
                            detail_Obj.Done = 'Y';
                        }
                        else
                        {
                            detail_Obj.Done = 'N';
                        }

                        FrmRMTransactionTest frmrmtransactiontest = new FrmRMTransactionTest(detail_Obj);
                        if (!string.IsNullOrEmpty(lblIsAligned.Text.Trim()))
                        {
                            if (lblIsAligned.Text.Trim().Equals("Aligned", StringComparison.CurrentCultureIgnoreCase))
                            {
                                frmrmtransactiontest.IsAlligned = true;
                            }                           
                        }
                        else
                        {
                            frmrmtransactiontest.IsAlligned = false;
                        }
                        
                        frmrmtransactiontest.TypeofControl = cmbTypeOfControl.Text;
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

                        if (dgTest[e.ColumnIndex, 0].Value.ToString() == "Done")
                        {
                            detail_Obj.Done = 'Y';
                        }
                        else
                        {
                            detail_Obj.Done = 'N';
                        }

                        FrmRMTransactionTest frmrmtransactiontest = new FrmRMTransactionTest(detail_Obj);
                        if (!string.IsNullOrEmpty(lblIsAligned.Text.Trim()))
                        {
                            if (lblIsAligned.Text.Trim().Equals("Aligned", StringComparison.CurrentCultureIgnoreCase))
                            {
                                frmrmtransactiontest.IsAlligned = true;
                            }
                        }
                        else
                        {
                            frmrmtransactiontest.IsAlligned = false;
                        }

                        frmrmtransactiontest.TypeofControl = cmbTypeOfControl.Text;
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        delegate void Del();
        private void cmbSupplier_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ////Test already Done
            //if (cmbRMCode.SelectedValue != null && cmbRMCode.Text != "--Select--" && cmbSupplier.SelectedValue != null && cmbSupplier.Text != "--Select--" )
            //{
            //    cmbTypeOfControl_SelectionChangeCommitted(sender, e);
            //}

            //Full Control testing Done  
            if (cmbSupplier.SelectedValue.ToString() == "-1")
            {   int i=0;
              Int32.TryParse(txtProtocolNo.Text.Remove(0, 2), out i);
              DataSet ds2 = new DataSet();
              RMTransaction_Class_obj.rmsamplingid = Convert.ToInt64(i);
              ds2 = RMTransaction_Class_obj.Select_RMAlignment_Protocol();
              txtAgentName.Text = ds2.Tables[0].Rows[0]["AgentName"].ToString();
                lblIsAligned.ForeColor = Color.Blue;
                lblHalal.ForeColor = Color.Red;
                lblplantOrigin.ForeColor = Color.Red;
                lblCountryOfOrigin.ForeColor = Color.Red;
                lblIsAligned.Font = new Font("Verdana", 9, FontStyle.Bold);
                lblIsAligned.Text = ds2.Tables[0].Rows[0]["IsAligned"].ToString();
        
                /// This Del d = delegate() Annonymous Function Perfrom 
                /// If aligned-Type of Control Aligned,FullControl,Redused
                ///If Non-aligned-  Non-Aligned,FullControl,Redused

                //Del d = delegate()
                //{
                //    if (!string.IsNullOrEmpty(ds2.Tables[0].Rows[0]["IsAligned"].ToString()))
                //    {
                //        cmbTypeOfControl.Items.Clear();
                //        cmbTypeOfControl.Items.Add("Reduced Control");
                //        cmbTypeOfControl.Items.Add("Full Control");
                //        cmbTypeOfControl.Items.Add("Alligned");
                //    }
                //    else
                //    {
                //        cmbTypeOfControl.Items.Clear();
                //        cmbTypeOfControl.Items.Add("Reduced Control");
                //        cmbTypeOfControl.Items.Add("Full Control");
                //        cmbTypeOfControl.Items.Add("NotAlligned");
                //    }
                //};
                //d.Invoke();
                
                RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(dsProtocol.Tables[0].Rows[0]["RMSupplierID"].ToString());
            }
            if (cmbSupplier.SelectedValue.ToString() != "-1")
            {
                DataRow[] DtRowAgent = DSRMCode.Tables[0].Select("RMSupplierAgentID=" + Convert.ToInt64(cmbSupplier.SelectedValue.ToString()) + "");
                txtAgentName.Text = DtRowAgent[0]["RMAgentName"].ToString();
                lblIsAligned.ForeColor = Color.Blue;
                lblHalal.ForeColor = Color.Red;
                lblplantOrigin.ForeColor = Color.Red;
                lblCountryOfOrigin.ForeColor = Color.Red;
                lblIsAligned.Font = new Font("Verdana", 9, FontStyle.Bold);
                lblIsAligned.Text = DtRowAgent[0]["IsAligned"].ToString();
                lblHalal.Text =DtRowAgent[0]["Halal"].ToString();
                lblplantOrigin.Text = DtRowAgent[0]["plantOrigin"].ToString();
                lblCountryOfOrigin.Text = DtRowAgent[0]["countryoforigin"].ToString();
                lblTradeName.Text = DtRowAgent[0]["TradeName"].ToString();


                /// This Del d = delegate() Annonymous Function Perfrom 
                /// If aligned-Type of Control Aligned,FullControl,Redused
                ///If Non-aligned-  Non-Aligned,FullControl,Redused
                //Del d = delegate()
                //{
                //    if (!string.IsNullOrEmpty(DtRowAgent[0]["IsAligned"].ToString()))
                //    {
                //        cmbTypeOfControl.Items.Clear();
                //        cmbTypeOfControl.Items.Add("Reduced Control");
                //        cmbTypeOfControl.Items.Add("Full Control");
                //        cmbTypeOfControl.Items.Add("Alligned");
                //    }
                //    else
                //    {
                //        cmbTypeOfControl.Items.Clear();
                //        cmbTypeOfControl.Items.Add("Reduced Control");
                //        cmbTypeOfControl.Items.Add("Full Control");
                //        cmbTypeOfControl.Items.Add("NotAlligned");
                //    }
                //};
                //d.Invoke();
                if (DtRowAgent[0]["RMSupplierID"].ToString() != "")
                    RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(DtRowAgent[0]["RMSupplierID"].ToString());
            }//
         
            RMTransaction_Class_obj.rmcodeid = Convert.ToInt64(cmbRMCode.SelectedValue);
            //if (DtRowAgent[0]["RMSupplierID"].ToString() != "")
            //    RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(DtRowAgent[0]["RMSupplierID"].ToString());//Convert.ToInt64(cmbSupplier.SelectedValue);
            DataSet ds = new DataSet();
            ds = RMTransaction_Class_obj.Select_FullControlTestingDone_tblRMSampling();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMsgFull.Text = "";
            }
            else
            {
                lblMsgFull.Text = "Full Control Testing is NOT DONE in this year";
            }
        }

        private void txtPlantLotNo_Leave(object sender, EventArgs e)
        {
            ////Test already Done
            //if (cmbRMCode.SelectedValue != null && cmbRMCode.Text != "--Select--" && cmbSupplier.SelectedValue != null && cmbSupplier.Text != "--Select--")
            //{
            //    cmbTypeOfControl_SelectionChangeCommitted(sender, e);
            //}
            RMTransaction_Class_obj.plantlotno = txtPlantLotNo.Text.Trim();
            if (alterPlantNO == "")
            {
                if (RMTransaction_Class_obj.Get_If_LotNoExists())
                {
                    MessageBox.Show("This lot number exists already.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPlantLotNo.Text = string.Empty;
                    txtPlantLotNo.Focus();
                }
            
            }
            if (alterPlantNO!="")
            {
                if (txtPlantLotNo.Text.Trim()!= alterPlantNO)
                {
                    if (RMTransaction_Class_obj.Get_If_LotNoExists())
                    {
                        MessageBox.Show("This lot number exists already.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPlantLotNo.Text = string.Empty;
                        txtPlantLotNo.Focus();
                    }
                } 
            }

        }

        bool EditProtocolNo = false; DataSet dsProtocol;
        string alterPlantNO = "";
        private void txtProtocolNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProtocolNo.Text.Trim() != "")
                {
                    cmbRMCode.Text = "--Select--";
                    reset();
                    string ProtoSupplier = "";
                    DataSet ds = new DataSet();
                    if (txtProtocolNo.Text.StartsWith("RM"))
                    {
                        int i = 0;
                        if (Int32.TryParse(txtProtocolNo.Text.Remove(0, 2), out i))
                        {
                            RMTransaction_Class_obj.rmsamplingid = Convert.ToInt64(i);
                            //DataSet ds = new DataSet();
                            dsProtocol = new DataSet();
                            dsProtocol = RMTransaction_Class_obj.Select_tblRMSampling_ProtocolNo();
                            if (dsProtocol.Tables[0].Rows.Count > 0)
                            {
                                cmbRMCode.SelectedValue = Convert.ToInt64(dsProtocol.Tables[0].Rows[0]["RMCodeID"]);
                                EditProtocolNo = true;
                                cmbRMCode_SelectionChangeCommitted(sender, e);

                                DataRow[] DtRowAgent = DSRMCode.Tables[0].Select("RMSupplierID=" + Convert.ToInt64(dsProtocol.Tables[0].Rows[0]["RMSupplierID"].ToString()) + "");
                                //cmbSupplier.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["RMSupplierID"]);
                                ds = RMTransaction_Class_obj.Select_RMAlignment_Protocol();
                                lblIsAligned.ForeColor = Color.Blue;
                                lblHalal.ForeColor = Color.Red;
                                lblplantOrigin.ForeColor = Color.Red;
                                lblCountryOfOrigin.ForeColor = Color.Red;
                                lblIsAligned.Font = new Font("Verdana", 9, FontStyle.Bold);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    lblIsAligned.Text = ds.Tables[0].Rows[0]["IsAligned"].ToString();
                                    /// This Del d = delegate() Annonymous Function Perfrom 
                                    /// If aligned-Type of Control Aligned,FullControl,Redused
                                    ///If Non-aligned-  Non-Aligned,FullControl,Redused
                                    //Del d = delegate()
                                    //{
                                    //    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["IsAligned"].ToString()))
                                    //    {
                                    //        cmbTypeOfControl.Items.Clear();
                                    //        cmbTypeOfControl.Items.Add("Reduced Control");
                                    //        cmbTypeOfControl.Items.Add("Full Control");
                                    //        cmbTypeOfControl.Items.Add("Alligned");
                                    //    }
                                    //    else
                                    //    {
                                    //        cmbTypeOfControl.Items.Clear();
                                    //        cmbTypeOfControl.Items.Add("Reduced Control");
                                    //        cmbTypeOfControl.Items.Add("Full Control");
                                    //        cmbTypeOfControl.Items.Add("NotAlligned");
                                    //    }
                                    //};
                                    //d.Invoke();
                                }
                                if (DtRowAgent.Length == 0)
                                {
                                    RMTransaction_Class_obj.rmsupplierid = Convert.ToInt64(dsProtocol.Tables[0].Rows[0]["RMSupplierID"].ToString());
                                    ProtoSupplier = RMTransaction_Class_obj.Select_RMSupplier_SupplierID();
                                    ds = RMTransaction_Class_obj.Select_RMAlignment_Protocol();
                                    if (ProtoSupplier != "NoRec")
                                    {
                                        DataRow dr = DSRMCode.Tables[0].NewRow();
                                        dr["RMSupplierName"] = ProtoSupplier;
                                        dr["RMSupplierAgentID"] ="-1";
                                        dr["IsAligned"] = ds.Tables[0].Rows[0]["IsAligned"].ToString();
                                        dr["RMAgentName"] = ds.Tables[0].Rows[0]["AgentName"].ToString();
                                        DSRMCode.Tables[0].Rows.InsertAt(dr, 1);
                                        cmbSupplier.SelectedIndex = 1;
                                        
                                    }
                                   
                                }
                                else
                                {
                                    cmbSupplier.SelectedValue = Convert.ToInt64(DtRowAgent[0]["RMSupplierAgentID"].ToString());

                                }

                              //  lblIsAligned.Text=

                                txtPlantLotNo.Text = Convert.ToString(dsProtocol.Tables[0].Rows[0]["PlantLotNo"]);
                                alterPlantNO = Convert.ToString(dsProtocol.Tables[0].Rows[0]["PlantLotNo"]);
                                if (Convert.ToString(dsProtocol.Tables[0].Rows[0]["MethodType"]) == "R")
                                {
                                    cmbTypeOfControl.Text = "Reduced Control";
                                }
                                else if (Convert.ToString(dsProtocol.Tables[0].Rows[0]["MethodType"]) == "F")
                                {
                                    cmbTypeOfControl.Text = "Full Control";
                                }

                                cmbTypeOfControl_SelectionChangeCommitted(sender, e);

                                // following code for show status from tables
                                DataTable dt = new DataTable();
                                dt = RMTransaction_Class_obj.Select_tblRMSampling_tblRMTransaction_tblRMStatus_RMSamplingID();
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (Convert.ToString(dr["Status"]) == "A")
                                    {
                                        RdoAccept.Checked = true;
                                    }
                                    else if (Convert.ToString(dr["Status"]) == "R")
                                    {
                                        RdoReject.Checked = true;
                                    }
                                    else if (Convert.ToString(dr["Status"]) == "D")
                                    {
                                        RdoAWD.Checked = true;
                                    }
                                    else if (Convert.ToString(dr["Status"]) == "S")
                                    {
                                        RdoSentToSupplier.Checked = true;
                                    }
                                    else if (Convert.ToString(dr["Status"]) == "H")
                                    {
                                        RdoHold.Checked = true;
                                    }

                                    //********************** code for subcontract *************

                                    if (dr["SubContract"] != DBNull.Value)
                                    {
                                        chkSubcontract.Checked = (bool)dr["SubContract"];
                                    }
                                    else
                                    {
                                        chkSubcontract.Checked = false;
                                    }

                                }
                            }
                        }
                      
                    }

                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtProtocolNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtProtocolNo_Leave(sender, e);
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpReceiptDate_ValueChanged(object sender, EventArgs e)
        {
            dtpDisposalDate.Value = dtpReceiptDate.Value.AddYears(4).AddDays(-1);
        }

        private void dtpManufacturingDate_ValueChanged(object sender, EventArgs e)
        {
            dtpManufacturingDate.CustomFormat = "dd-MMM-yyyy";
        }

        private void txtNoOfSegments_TextChanged(object sender, EventArgs e)
        {
            int ln=0;
            ln = txtNoOfSegments.Text.Length;
            if (ln > 5)
            {
                MessageBox.Show("This much larger value can't be accepted.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNoOfSegments.Text = string.Empty;
                txtActualNoSegments.Focus();
            }
           
        }

        private void btnPrintValidity_Click(object sender, EventArgs e)
        {
            

            if (!string.IsNullOrEmpty(cmbRMCode.Text)
                && ! string.IsNullOrEmpty(txtPlantLotNo.Text.Trim())
                && !string.IsNullOrEmpty(dtpReceiptDate.Value.ToShortDateString()))
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("RMCode");
                dt.Columns.Add("PlantLotNo");
                dt.Columns.Add("ReceiptDate");
                dt.Columns.Add("DisposalDate");
                dt.Columns.Add("SafetyImage1", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage2", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage3", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage4", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage5", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage6", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage7", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage8", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage9", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("SafetyImage10", System.Type.GetType("System.Byte[]"));

                dt.Columns.Add("AccessImage1", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage2", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage3", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage4", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage5", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage6", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage7", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage8", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage9", System.Type.GetType("System.Byte[]"));
                dt.Columns.Add("AccessImage10", System.Type.GetType("System.Byte[]"));

                DataRow dr;
                dr = dt.NewRow();
                dr["RMCode"] = cmbRMCode.Text.Trim();
                dr["PlantLotNo"] = txtPlantLotNo.Text.Trim();
                dr["ReceiptDate"] = dtpReceiptDate.Value.ToShortDateString();
                dr["DisposalDate"] = dtpManufacturingDate.Value.ToShortDateString();
                dt.Rows.Add(dr);
                QTMS.Reports_Forms.LabelValidity frm = new QTMS.Reports_Forms.LabelValidity(dt);
                frm.Show();

            }
            else
            {
                MessageBox.Show("Please Fill RM Code, Plant Lot No and ");
            }
        }

        private void RdoReject_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoReject.Checked)
            {
                lblReject.Visible = txtRejectDescription.Visible = true;
                //txtRejectDescription.Focus();
            }
            else
                lblReject.Visible = txtRejectDescription.Visible = false;

        }      


    }
}