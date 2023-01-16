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
    public partial class FrmPMTreatment : Form
    {
        public FrmPMTreatment()
        {
            
            InitializeComponent();
        }
        #region Variables
        
        //PMTreatment_Class PMTreatment_Class_obj = new PMTreatment_Class();
        PMTransaction_Class PMTransaction_Class_obj = new PMTransaction_Class();
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();        
        #endregion

        private static FrmPMTreatment frmPMTreatment_Obj = null;
        public static FrmPMTreatment GetInstance()
        {
            if (frmPMTreatment_Obj == null)
            {
                frmPMTreatment_Obj = new Transactions.FrmPMTreatment();
            }
            return frmPMTreatment_Obj;
        }

       
        private void FrmPMTreatment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
            cmbDetectObserved.SelectedIndex = 0;
            Bind_Details();            
            dgAllTests.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
        }

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;

                ds = PMTransaction_Class_obj.Select_PendingPMTreatmentDetails();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbPMTreatmentDetails.DataSource = ds.Tables[0];
                cmbPMTreatmentDetails.DisplayMember = "Details";
                cmbPMTreatmentDetails.ValueMember = "PMTransID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void cmbPMTreatmentDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                resetall();
                if (cmbPMTreatmentDetails.SelectedValue != null && cmbPMTreatmentDetails.SelectedValue.ToString() != "")
                {
                    DataSet ds = new DataSet();
                    PMTransaction_Class_obj.pmtransid = Convert.ToInt64(cmbPMTreatmentDetails.SelectedValue.ToString());
                    ds = PMTransaction_Class_obj.Select_PMTreatmentDetails();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMSupplierCOCID"].ToString());
                        PMTransaction_Class_obj.pmfamilyid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMFamilyID"].ToString());
                        PMTransaction_Class_obj.type = ds.Tables[0].Rows[0]["ControlType"].ToString();

                        txtControlType.Text = ds.Tables[0].Rows[0]["ControlType"].ToString();
                        txtRejectComment.Text = ds.Tables[0].Rows[0]["RejectComment"].ToString(); 
                    }

                }
                else
                {
                    MessageBox.Show("Please Select PM Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void RdoPMTransactionNo_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoPMTransactionNo.Checked == true)
            {
                dgAllTests.Rows.Clear();                
                txtPMTreatmentQty.Enabled = false;
                txtPMTreatmentQty.Text = "";                
            }
        }

        private void RdoPMTreatmentYes_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoPMTreatmentYes.Checked == true)
            {                          
                txtPMTreatmentQty.Enabled = true;                
            }
        }

        private void txtPMTreatmentQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    dgAllTests.Rows.Clear();

                    if (cmbPMTreatmentDetails.Text == "--Select--" || cmbPMTreatmentDetails.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please Select Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (txtPMTreatmentQty.Text == "")
                    {
                        MessageBox.Show("Please Enter Quantity", "Warning");
                        txtPMTreatmentQty.Focus();
                        return;
                    }

                    PMTransaction_Class_obj.pmtransid = Convert.ToInt64(cmbPMTreatmentDetails.SelectedValue.ToString());

                    FillTestGrid();
                    dgAllTests.Focus();
                }
                else if (Convert.ToInt32(e.KeyChar) != 8)
                {
                    if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
                    {

                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPMTreatmentExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPMTreatmentSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPMTreatmentDetails.Text == "--Select--" || cmbPMTreatmentDetails.Text == "")
                {
                    MessageBox.Show("Please Select Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPMTreatmentDetails.Focus();
                    return;
                }
                if (RdoPMTreatmentYes.Checked == false && RdoPMTransactionNo.Checked == false)
                {
                    MessageBox.Show("Please Select Treatment Done", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }                
                
                if (txtPMTreatmentQty.Text == "")
                {
                    PMTransaction_Class_obj.quantity = 0;
                }
                else
                {
                    PMTransaction_Class_obj.quantity = Convert.ToInt64(txtPMTreatmentQty.Text.ToString());
                }

                PMTransaction_Class_obj.inspdate = Convert.ToString(DtpInspDate.Value);
                
                PMTransaction_Class_obj.currentflag = 1;

                PMTransaction_Class_obj.treatmentdone = 1;

                PMTransaction_Class_obj.treatmented = 1;
                
                PMTransaction_Class_obj.loginid = FrmMain.LoginID;

                PMTransaction_Class_obj.pmtestid=0;
                PMTransaction_Class_obj.pmtestid = PMTransaction_Class_obj.Insert_PMTest();

                //Make TreatementDone = 1 of all records (old + new) using PMTransID
                PMTransaction_Class_obj.Update_tblPMTest_TreatmentDone();

                if (PMTransaction_Class_obj.pmtestid != 0)
                {                   

                    if (cmbDetectObserved.SelectedIndex == 1)
                    {
                        PMTransaction_Class_obj.defectobserved = Convert.ToString("N");
                    }
                    else if (cmbDetectObserved.SelectedIndex == 2)
                    {
                        PMTransaction_Class_obj.defectobserved = Convert.ToString("Y");
                    }
                    else
                    {
                        PMTransaction_Class_obj.defectobserved = Convert.ToString("");
                    }

                    PMTransaction_Class_obj.defectcomment = txtDefectComment.Text.ToString().Trim();
                    PMTransaction_Class_obj.defectquantity = txtDefectQuantity.Text.Trim();

                    if (txtNoOfDefect.Text.Trim() != "")
                    {
                        PMTransaction_Class_obj.noofdefect = Convert.ToInt32(txtNoOfDefect.Text.Trim());
                    }
                    else
                    {
                        PMTransaction_Class_obj.noofdefect = 0;
                    }
                    PMTransaction_Class_obj.qualitydecision = txtDefect.Text.Trim();

                    if (RdoAccept.Checked == true)
                    {
                        PMTransaction_Class_obj.status = "A";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        PMTransaction_Class_obj.status = "A";
                    }
                    else if (RdoReject.Checked == true)
                    {
                        PMTransaction_Class_obj.status = "R";
                    }
                    else if (RdoTreatment.Checked == true)
                    {
                        PMTransaction_Class_obj.status = "R";
                    }
                    else if (RdoSendBackToSupplier.Checked == true)
                    {
                        PMTransaction_Class_obj.status = "R";
                    }

                    //--------Actual Status-------

                    if (RdoAccept.Checked == true)
                    {
                        PMTransaction_Class_obj.actualstatus = "A";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        PMTransaction_Class_obj.actualstatus = "D";
                    }
                    else if (RdoReject.Checked == true)
                    {
                        PMTransaction_Class_obj.actualstatus = "R";
                    }
                    else if (RdoTreatment.Checked == true)
                    {
                        PMTransaction_Class_obj.actualstatus = "T";
                    }
                    else if (RdoSendBackToSupplier.Checked == true)
                    {
                        PMTransaction_Class_obj.actualstatus = "S";
                    }

                    PMTransaction_Class_obj.rejectcomment = Convert.ToString("N/A");
                    for (int i = 0; i < chkRejectComments.Items.Count; i++)
                    {
                        if (chkRejectComments.GetItemChecked(i) == true)
                        {
                            if (i == 0)
                            {
                                PMTransaction_Class_obj.rejectcomment = Convert.ToString("BOR");
                                break;
                            }
                            else if (i == 1)
                            {
                                PMTransaction_Class_obj.rejectcomment = Convert.ToString("BOF");
                                break;
                            }
                            else if (i == 2)
                            {
                                PMTransaction_Class_obj.rejectcomment = Convert.ToString("COC");
                                break;
                            }
                        }
                    }


                    PMTransaction_Class_obj.currentflag = 1;

                    // ChangedStatus = 1 for record added in tblPMStatus in status change and treatment
                    PMTransaction_Class_obj.changedstatus = 1;

                    PMTransaction_Class_obj.loginid = FrmMain.LoginID;

                    PMTransaction_Class_obj.Insert_PMStatus_Treatment();
                

                    for (int i = 0; i < dgAllTests.Rows.Count; i++)
                    {
                        //FinishedGoodTest_Class_Obj.pkgtechno = 
                        PMTransaction_Class_obj.testname = dgAllTests["TestMethod", i].Value.ToString();
                        PMTransaction_Class_obj.inspectionmethod = dgAllTests["InspectionMethod", i].Value.ToString();
                        PMTransaction_Class_obj.frequency = dgAllTests["Frequency", i].Value.ToString();
                        //FinishedGoodTest_Class_Obj.type 
                        PMTransaction_Class_obj.lotsize = dgAllTests["LotSize", i].Value.ToString();

                        PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                        if (dgAllTests["SampleSizeReading", i].Value.ToString() == "")
                        {
                            PMTransaction_Class_obj.samplesizereading = 0;
                        }
                        else
                        {
                            PMTransaction_Class_obj.samplesizereading = Convert.ToInt32(dgAllTests["SampleSizeReading", i].Value);
                        }
                        PMTransaction_Class_obj.aqlreading = dgAllTests["AQLReading", i].Value.ToString();
                        PMTransaction_Class_obj.aqlzreading = dgAllTests["AQLZReading", i].Value.ToString();
                        PMTransaction_Class_obj.aqlcreading = dgAllTests["AQLCReading", i].Value.ToString();
                        PMTransaction_Class_obj.aqlmreading = dgAllTests["AQLMReading", i].Value.ToString();
                        PMTransaction_Class_obj.aqlm1reading = dgAllTests["AQLM1Reading", i].Value.ToString();

                        PMTransaction_Class_obj.Insert_tblPMFGTestMethodDetails();                        
                    }
                }
                MessageBox.Show("Record Saved Successfully..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnPMTreatmentReset_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void FillTestGrid()
        {
            try
            {
                if (txtPMTreatmentQty.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Warning");
                    txtPMTreatmentQty.Focus();
                    return;
                }

                if ((Convert.ToInt64(txtPMTreatmentQty.Text) < 501))
                {
                    MessageBox.Show("Quantity Less Than 501", "Warning");
                    txtPMTreatmentQty.Text = "";
                    txtPMTreatmentQty.Focus();
                    return;
                }
                else if ((Convert.ToInt64(txtPMTreatmentQty.Text) >= 501) && (Convert.ToInt64(txtPMTreatmentQty.Text) <= 1200))
                {
                    PMTransaction_Class_obj.lotsize = "501-1200";
                }
                else if ((Convert.ToInt64(txtPMTreatmentQty.Text) >= 1201) && (Convert.ToInt64(txtPMTreatmentQty.Text) <= 3200))
                {
                    PMTransaction_Class_obj.lotsize = "1201-3200";
                }
                else if ((Convert.ToInt64(txtPMTreatmentQty.Text) >= 3201) && (Convert.ToInt64(txtPMTreatmentQty.Text) <= 10000))
                {
                    PMTransaction_Class_obj.lotsize = "3201-10000";
                }
                else if ((Convert.ToInt64(txtPMTreatmentQty.Text) >= 10001) && (Convert.ToInt64(txtPMTreatmentQty.Text) <= 35000))
                {
                    PMTransaction_Class_obj.lotsize = "10001-35000";
                }
                else if ((Convert.ToInt64(txtPMTreatmentQty.Text) >= 35001) && (Convert.ToInt64(txtPMTreatmentQty.Text) <= 150000))
                {
                    PMTransaction_Class_obj.lotsize = "35001-150000";
                }
                else if ((Convert.ToInt64(txtPMTreatmentQty.Text) >= 150001) && (Convert.ToInt64(txtPMTreatmentQty.Text) <= 5000000))
                {
                    PMTransaction_Class_obj.lotsize = "150001-5000000";
                }
                else
                {
                    MessageBox.Show("Quantity greater Than 5000000", "Warning");
                    txtPMTreatmentQty.Text = "";
                    txtPMTreatmentQty.Focus();
                    return;
                }


                //only systematic testing is done regularly
                //Periodic testing is done once a year

                PMTransaction_Class_obj.frequency = "Systematic";

                DataSet ds = new DataSet();
                DataSet dsInspMethod = new DataSet();
                DataSet dsAll = new DataSet();

                ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgAllTests.Rows.Add();

                        dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                        PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value.ToString();
                        dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();

                        DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                        combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                        for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                        {
                            combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                        }
                        dgAllTests.Rows[i].Cells["InspectionMethod"] = combo;

                        DataSet dsReading;
                        for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                        {
                            dsReading = new DataSet();
                            PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row][0].ToString();
                            PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                            combo.Value = dsInspMethod.Tables[0].Rows[row][0].ToString();
                            dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                            DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);
                        }
                    }
                }






                 //ds = PMTreatment_Class_obj.Select_PMFGTestMethodMaster_PMSupplierCOCID_LotSize();
                 //if (ds.Tables[0].Rows.Count > 0)
                 //{
                 //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                 //    {
                         
                 //            dgAllTests.Rows.Add();
                         
                 //            dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                 //            PMTreatment_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value.ToString();
                 //            dsInspMethod = PMTreatment_Class_obj.Select_PMFGTestMethodMaster_PMSupplierCOCID_LotSize_InspectionMethod();

                 //            DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                 //            combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                 //            for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                 //            {
                 //                combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                 //            }
                 //            dgAllTests.Rows[i].Cells["InspectionMethod"] = combo;
                 //            DataSet dsReading;
                 //            for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                 //            {
                 //                dsReading = new DataSet();
                 //                PMTreatment_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row][0].ToString();
                 //                PMTreatment_Class_obj.fgmethodno = PMTreatment_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();
                 //                combo.Value = dsInspMethod.Tables[0].Rows[row][0].ToString();
                 //                dsAll = PMTreatment_Class_obj.Select_PMFGTestMethodMaster_All();
                 //                DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);

                 //            }
                         

                 //    }
                 //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayDataGridView_All(DataSet dsAll, int rowIndex)
        {

            if (dsAll.Tables[0].Rows.Count > 0)
            {

                dgAllTests["Frequency", rowIndex].Value = dsAll.Tables[0].Rows[0]["frequency"];

                dgAllTests["LotSize", rowIndex].Value = dsAll.Tables[0].Rows[0]["lotsize"];

                dgAllTests["SampleSizeStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["samplesize"];

                //Set to blank
                dgAllTests["SampleSizeReading", rowIndex].Value = "";

                //dataGridView 5 --> editable for sample size reading                        


                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aql"]) == "")
                {
                    dgAllTests["AQLStandard", rowIndex].Value = "N/A";
                    dgAllTests["AQLReading", rowIndex].Value = "N/A";

                    dgAllTests["AQLReading", rowIndex].ReadOnly = true;
                    dgAllTests["AQLReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTests["AQLStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aql"];
                    dgAllTests["AQLReading", rowIndex].Value = "";

                    dgAllTests["AQLReading", rowIndex].ReadOnly = false;
                    dgAllTests["AQLReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlz"]) == "")
                {
                    dgAllTests["AQLzStandard", rowIndex].Value = "N/A";
                    dgAllTests["AQLzReading", rowIndex].Value = "N/A";

                    dgAllTests["AQLzReading", rowIndex].ReadOnly = true;
                    dgAllTests["AQLzReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTests["AQLzStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlz"];
                    dgAllTests["AQLzReading", rowIndex].Value = "";

                    dgAllTests["AQLzReading", rowIndex].ReadOnly = false;
                    dgAllTests["AQLzReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlc"]) == "")
                {
                    dgAllTests["AQLcStandard", rowIndex].Value = "N/A";
                    dgAllTests["AQLcReading", rowIndex].Value = "N/A";

                    dgAllTests["AQLcReading", rowIndex].ReadOnly = true;
                    dgAllTests["AQLcReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTests["AQLcStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlc"];
                    dgAllTests["AQLcReading", rowIndex].Value = "";

                    dgAllTests["AQLcReading", rowIndex].ReadOnly = false;
                    dgAllTests["AQLcReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm"]) == "")
                {
                    dgAllTests["AQLMStandard", rowIndex].Value = "N/A";
                    dgAllTests["AQLMReading", rowIndex].Value = "N/A";

                    dgAllTests["AQLMReading", rowIndex].ReadOnly = true;
                    dgAllTests["AQLMReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTests["AQLMStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm"];
                    dgAllTests["AQLMReading", rowIndex].Value = "";

                    dgAllTests["AQLMReading", rowIndex].ReadOnly = false;
                    dgAllTests["AQLMReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm1"]) == "")
                {
                    dgAllTests["AQLM1Standard", rowIndex].Value = "N/A";
                    dgAllTests["AQLM1Reading", rowIndex].Value = "N/A";

                    dgAllTests["AQLM1Reading", rowIndex].ReadOnly = true;
                    dgAllTests["AQLM1Reading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTests["AQLM1Standard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm1"];
                    dgAllTests["AQLM1Reading", rowIndex].Value = "";

                    dgAllTests["AQLM1Reading", rowIndex].ReadOnly = false;
                    dgAllTests["AQLM1Reading", rowIndex].Style.BackColor = Color.White;
                }
            }
        }

        private void dgAllTests_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 46))
            {
                if ((Convert.ToInt32(e.KeyChar) < 48) || (Convert.ToInt32(e.KeyChar) > 57))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        #region "dataGridView_EditingControlShowing"
        ComboBox cmb;

        private void dgAllTests_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgAllTests.CurrentCell.RowIndex < 0
              || (dgAllTests.CurrentCell.ColumnIndex != dgAllTests.Columns["InspectionMethod"].Index
                   && dgAllTests.CurrentCell.ReadOnly == true))
            {
                return;
            }
            else if (dgAllTests.CurrentCell.ColumnIndex == dgAllTests.Columns["InspectionMethod"].Index)
            {
                cmb = e.Control as ComboBox;
                cmb.Text = e.Control.Text;
                cmb.TextChanged += new EventHandler(cmb_TextChanged);
                return;
            }
            else if (dgAllTests.CurrentCell.ReadOnly == false)
            {

                dgAllTests.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }

        }
        #endregion
        
        public void cmb_TextChanged(object sender, EventArgs e)
        {
            if (dgAllTests.CurrentCell.RowIndex < 0 || dgAllTests.CurrentCell.ColumnIndex != dgAllTests.Columns["InspectionMethod"].Index || cmb.Text == "")
            {
                return;
            }
            else
            {

                DataSet dsAll = new DataSet();

                PMTransaction_Class_obj.inspectionmethod = cmb.Text; //dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells["InspectionMethod"].Value.ToString();
                PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.CurrentCell.RowIndex].Value.ToString();
                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                DisplayDataGridView_All(dsAll, dgAllTests.CurrentCell.RowIndex);
            }
        }
        
        void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {

            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

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

        private void BtnPMTreatmentReset_Click(object sender, EventArgs e)
        {
            Bind_Details();
            cmbPMTreatmentDetails.Text = "--Select--";
            resetall();
        }

        public void resetall()
        {
            txtRejectComment.Text = "";
            txtControlType.Text = "";
            cmbDetectObserved.SelectedIndex = 0;
            txtDefectComment.Text = "";
            txtDefectQuantity.Text = "";
            txtNoOfDefect.Text = "";
            txtDefect.Text = ""; 
            RdoPMTreatmentYes.Checked = true;            
            RdoPMTransactionNo.Checked = false;
            txtPMTreatmentQty.Text = "";            
            dgAllTests.Rows.Clear();
            RdoAccept.Checked = true;
        }

        private void RdoAccept_CheckedChanged(object sender, EventArgs e)
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

        private void RdoReject_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoReject.Checked == true)
            {
                RdoAWD.Visible = true;
                RdoTreatment.Visible = true;
                chkRejectComments.Visible = true;
            }
        }

        private void RdoSendBackToSupplier_CheckedChanged(object sender, EventArgs e)
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

        private void chkRejectComments_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Can select only one item
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

        private void chkRejectComments_Click(object sender, EventArgs e)
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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

         
        
    }
}