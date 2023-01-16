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
    public partial class FrmPMReanalysis : Form
    {
        public FrmPMReanalysis()
        {
            InitializeComponent();
        }
        #region Variables
        Comman_Class Comman_Class_obj = new Comman_Class();
        PMTransaction_Class PMTransaction_Class_obj = new PMTransaction_Class();
        PMMaster_Class PMMaster_Class_obj = new PMMaster_Class();

        #endregion

        private static FrmPMReanalysis frmPMReanalysis_Obj = null;

        public static FrmPMReanalysis GetInstance()
        {
            if (frmPMReanalysis_Obj == null)
            {
                frmPMReanalysis_Obj = new Transactions.FrmPMReanalysis();
            }
            return frmPMReanalysis_Obj;
        }

        private void FrmPMReanalysis_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            Bind_PMCode();
            BtnReset_Click(sender, e);
        }

        public void Bind_PMCode()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = PMTransaction_Class_obj.Select_View_PendingPMReanalysis();
                dr = ds.Tables[0].NewRow();
                dr["PMCode"] = "--Select--";
                dr["PMCodeID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbPMCode.DataSource = ds.Tables[0];
                cmbPMCode.DisplayMember = "PMCode";
                cmbPMCode.ValueMember = "PMCodeID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbPMCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbPlantLotNo.Text = "--Select--";
                resetall();

                if (cmbPMCode.SelectedValue.ToString() != null && cmbPMCode.SelectedValue.ToString() != "")
                {
                    DataSet ds = new DataSet();
                    PMTransaction_Class_obj.pmcodeid = Convert.ToInt64(cmbPMCode.SelectedValue);
                    ds = PMTransaction_Class_obj.Select_View_PendingPMReanalysis_PMCodeID();
                    DataRow dr;
                    dr = ds.Tables[0].NewRow();
                    dr["PlantLotNo"] = "--Select--";
                    dr["PMTestID"] = "0";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    cmbPlantLotNo.DataSource = ds.Tables[0];
                    cmbPlantLotNo.DisplayMember = "PlantLotNo";
                    cmbPlantLotNo.ValueMember = "PMTestID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbPlantLotNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                resetall();
                if (cmbPlantLotNo.SelectedValue.ToString() != null && cmbPlantLotNo.SelectedValue.ToString() != "")
                {
                    DataSet ds = new DataSet();
                    DataSet dsDefect = new DataSet();
                    PMTransaction_Class_obj.pmtestid = Convert.ToInt64(cmbPlantLotNo.SelectedValue);
                    ds = PMTransaction_Class_obj.Select_View_PendingPMReanalysis_PMTestID();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMDescription"]);
                        txtSupplier.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMSupplierName"]);
                        DtpAcceptedDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["AcceptedDate"]);
                        txtCOC.Text = Convert.ToString(ds.Tables[0].Rows[0]["COCApplicable"]);
                        txtQuantity.Text = Convert.ToString(ds.Tables[0].Rows[0]["Quantity"]);

                        PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMSupplierCOCID"]);
                        PMTransaction_Class_obj.pmfamilyid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMFamilyID"]);
                        PMTransaction_Class_obj.cocapplicable = Convert.ToString(ds.Tables[0].Rows[0]["COCApplicable"]);
                        PMTransaction_Class_obj.cocfrequency = Convert.ToChar(ds.Tables[0].Rows[0]["COCFrequency"]);
                        PMTransaction_Class_obj.type = ds.Tables[0].Rows[0]["ControlType"].ToString();

                        // dsDefect = PMTransaction_Class_obj.Select_PMDefect_PMTestID();//Old Logic
                        dsDefect = PMTransaction_Class_obj.Select_PMDefect_PMTestID_FromReanalysis();
                        if (dsDefect.Tables[0].Rows.Count > 0)
                        {
                            for (int d = 0; d < dsDefect.Tables[0].Rows.Count; d++)
                            {
                                dgDefect.Rows.Add();
                                //dgDefect.Rows[d].ReadOnly = true;
                                dgDefect.Rows[d].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.LightGray);

                                dgDefect["PMDefectID", d].Value = Convert.ToString(dsDefect.Tables[0].Rows[d]["PMDefectID"]);
                                dgDefect["DefectComment", d].Value = Convert.ToString(dsDefect.Tables[0].Rows[d]["DefectComment"]);
                                dgDefect["DefectQuantity", d].Value = Convert.ToString(dsDefect.Tables[0].Rows[d]["DefectQuantity"]);

                                if (Convert.ToString(dsDefect.Tables[0].Rows[d]["ActionTaken"]) == "Q")
                                    dgDefect["ActionTaken", d].Value = "Line Stopped : Requested QC to check";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["ActionTaken"]) == "R")
                                    dgDefect["ActionTaken", d].Value = "Line Stopped : Material returned to store";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["ActionTaken"]) == "S")
                                    dgDefect["ActionTaken", d].Value = "On Line Sorting";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["ActionTaken"]) == "A")
                                    dgDefect["ActionTaken", d].Value = "On Line Adjustment";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["ActionTaken"]) == "O")
                                    dgDefect["ActionTaken", d].Value = "Other";

                                dgDefect["QualityDecision", d].Value = Convert.ToString(dsDefect.Tables[0].Rows[d]["QualityDecision"]);


                                PMTransaction_Class_obj.pmtestid = Convert.ToInt64(cmbPlantLotNo.SelectedValue);
                                DataSet dsDefStatus = PMTransaction_Class_obj.Select_tblSupplierCorrectiveNote_DefectStatus();
                                int icount = dsDefStatus.Tables[0].Rows.Count;
                                if (dsDefStatus.Tables[0].Rows.Count > 0)
                                {
                                    //if (dsDefStatus.Tables[0].Rows[icount-1][0].ToString() == "O")
                                    //    dgDefect["DefectStatus", d].Value = "Open";
                                    if (dsDefStatus.Tables[0].Rows[icount - 1][0].ToString() == "C")
                                        dgDefect["DefectStatus", d].Value = "Close";
                                }
                                else
                                {
                                    if (Convert.ToString(dsDefect.Tables[0].Rows[d]["DefectStatus"]) == "O")
                                        dgDefect["DefectStatus", d].Value = "Open";
                                    else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["DefectStatus"]) == "C")

                                        dgDefect["DefectStatus", d].Value = "Close";
                                }
                            }
                        }

                        PMTransaction_Class_obj.pmchangeid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMChangeID"]);
                        PMTransaction_Class_obj.status = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                        PMTransaction_Class_obj.actualstatus = Convert.ToString(ds.Tables[0].Rows[0]["ActualStatus"]);
                        PMTransaction_Class_obj.rejectcomment = Convert.ToString(ds.Tables[0].Rows[0]["RejectComment"]);

                        if (Convert.ToChar(ds.Tables[0].Rows[0]["ActualStatus"]) == 'A')
                            RdoAccept.Checked = true;
                        else if (Convert.ToChar(ds.Tables[0].Rows[0]["ActualStatus"]) == 'R')
                            RdoReject.Checked = true;
                        else if (Convert.ToChar(ds.Tables[0].Rows[0]["ActualStatus"]) == 'D')
                            RdoAWD.Checked = true;
                        else if (Convert.ToChar(ds.Tables[0].Rows[0]["ActualStatus"]) == 'T')
                            RdoTreatment.Checked = true;
                        else if (Convert.ToChar(ds.Tables[0].Rows[0]["ActualStatus"]) == 'S')
                            RdoSendBackToSupplier.Checked = true;

                        if (Convert.ToString(ds.Tables[0].Rows[0]["RejectComment"]) == "BOR")
                            chkRejectComments.SetItemChecked(0, true);
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["RejectComment"]) == "BOF")
                            chkRejectComments.SetItemChecked(1, true);
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["RejectComment"]) == "COC")
                            chkRejectComments.SetItemChecked(2, true);


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void resetall()
        {
            txtDesc.Text = "";
            txtSupplier.Text = "";
            DtpAcceptedDate.Value = Comman_Class_obj.Select_ServerDate();
            DtpInspDate.Value = Comman_Class_obj.Select_ServerDate();
            txtCOC.Text = "";
            txtQuantity.Text = "";

            cmbDefectObserved.SelectedIndex = 0;
            txtNoOfDefect.Enabled = false;
            txtNoOfDefect.Text = "";
            dgDefect.Rows.Clear();
            dgDefect.Columns["ActionTaken"].DataPropertyName = "--Select--";

            RdoNo.Checked = true;

            //RdoLaunch.Checked = true;
            for (int i = 0; i < chkRejectComments.Items.Count; i++)
            {
                if (chkRejectComments.GetItemChecked(i) == true)
                {
                    chkRejectComments.SetItemChecked(i, false);
                }
            }
            RdoAccept.Checked = true;
            RdoAWD.Checked = false;
            RdoTreatment.Checked = false;
            RdoSendBackToSupplier.Checked = false;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            cmbPMCode.Text = "--Select--";
            cmbPlantLotNo.Text = "--Select--";
            resetall();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPMCode.SelectedValue == null || cmbPMCode.Text == "--Select--")
                {
                    MessageBox.Show("Please Select PMCode", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    cmbPMCode.Focus();
                    return;
                }
                if (cmbPlantLotNo.SelectedValue == null || cmbPlantLotNo.Text == "--Select--")
                {
                    MessageBox.Show("Please Select PlantLotNo", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    cmbPlantLotNo.Focus();
                    return;
                }
                if (cmbDefectObserved.SelectedIndex == 0 || cmbDefectObserved.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Defect Observed", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    cmbDefectObserved.Focus();
                    return;
                }
                if (cmbDefectObserved.SelectedIndex == 2 && txtNoOfDefect.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter No of Defects", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    txtNoOfDefect.Focus();
                    return;
                }
                if (cmbDefectObserved.SelectedItem.ToString() == "Yes")
                {
                    for (int d = 0; d < dgDefect.Rows.Count; d++)
                    {
                        if (!dgDefect.Rows[d].IsNewRow)
                        {
                            if (Convert.ToString(dgDefect["DefectComment", d].Value) == "")
                            {
                                MessageBox.Show("Enter Defect Comment", "Defect", MessageBoxButtons.OK, MessageBoxIcon.None);
                                dgDefect["DefectCommnet", d].Selected = true;
                                return;
                            }
                            if (Convert.ToString(dgDefect["DefectQuantity", d].Value) == "")
                            {
                                MessageBox.Show("Enter Defect Quantity", "Defect", MessageBoxButtons.OK, MessageBoxIcon.None);
                                dgDefect["DefectQuantity", d].Selected = true;
                                return;
                            }
                            if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "")
                            {
                                MessageBox.Show("Enter Defect ActionTaken", "Defect", MessageBoxButtons.OK, MessageBoxIcon.None);
                                dgDefect["ActionTaken", d].Selected = true;
                                return;
                            }
                            if (Convert.ToString(dgDefect["DefectStatus", d].Value) == "")
                            {
                                MessageBox.Show("Enter Defect Status", "Defect", MessageBoxButtons.OK, MessageBoxIcon.None);
                                dgDefect["DefectStatus", d].Selected = true;
                                return;
                            }
                        }
                    }
                }
                if (RdoAccept.Checked == false && RdoReject.Checked == false && RdoSendBackToSupplier.Checked == false && RdoAWD.Checked == false && RdoTreatment.Checked == false)
                {
                    MessageBox.Show("Please Select Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (RdoAccept.Checked == true)
                {
                    if (MessageBox.Show("ACCEPT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoReject.Checked == true)
                {
                    if (MessageBox.Show("REJECT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoAWD.Checked == true)
                {
                    if (MessageBox.Show("ACCEPT WITH DERROGATION ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoTreatment.Checked == true)
                {
                    if (MessageBox.Show("TREATEMENT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoSendBackToSupplier.Checked == true)
                {
                    if (MessageBox.Show("SEND BACK TO SUPPLIER ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }

                PMTransaction_Class_obj.inspdate = DtpInspDate.Value.ToShortDateString();

                if (cmbDefectObserved.SelectedIndex == 1)
                    PMTransaction_Class_obj.defectobserved = Convert.ToString("N");
                else if (cmbDefectObserved.SelectedIndex == 2)
                    PMTransaction_Class_obj.defectobserved = Convert.ToString("Y");
                else
                    PMTransaction_Class_obj.defectobserved = Convert.ToString("");

                if (txtNoOfDefect.Text.Trim() != "")
                    PMTransaction_Class_obj.noofdefect = Convert.ToInt32(txtNoOfDefect.Text.Trim());
                else
                    PMTransaction_Class_obj.noofdefect = 0;

                if (RdoAccept.Checked == true)
                    PMTransaction_Class_obj.status = "A";
                else if (RdoAWD.Checked == true)
                    PMTransaction_Class_obj.status = "A";
                else if (RdoReject.Checked == true)
                    PMTransaction_Class_obj.status = "R";
                else if (RdoTreatment.Checked == true)
                    PMTransaction_Class_obj.status = "R";
                else if (RdoSendBackToSupplier.Checked == true)
                    PMTransaction_Class_obj.status = "R";

                //--------Actual Status-------
                if (RdoAccept.Checked == true)
                    PMTransaction_Class_obj.actualstatus = "A";
                else if (RdoAWD.Checked == true)
                    PMTransaction_Class_obj.actualstatus = "D";
                else if (RdoReject.Checked == true)
                    PMTransaction_Class_obj.actualstatus = "R";
                else if (RdoTreatment.Checked == true)
                    PMTransaction_Class_obj.actualstatus = "T";
                else if (RdoSendBackToSupplier.Checked == true)
                    PMTransaction_Class_obj.actualstatus = "S";

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
                PMTransaction_Class_obj.fromAnalysisReanalysis = 2; // This Flag shows records only in Reanalysis
                PMTransaction_Class_obj.loginid = FrmMain.LoginID;

                //DataSet dsChangeId = PMTransaction_Class_obj.Select_PMChangeId_PMStatus();
                //if(dsChangeId.Tables[0].Rows.Count>0)
                //{
                //    PMTransaction_Class_obj.pmchangeid= Convert.ToInt64(dsChangeId.Tables[0].Rows[0]["PMChangeId"]);
                //    PMTransaction_Class_obj.Update_tblPMStatus();
                //}
                PMTransaction_Class_obj.pmchangeid = PMTransaction_Class_obj.Insert_PMStatus();

                //IF Lot Rejected then update cocapplicable to 'N' for that PMCode and Supplier
                if (PMTransaction_Class_obj.cocapplicable == "Y" && PMTransaction_Class_obj.status == "R")
                {
                    if (MessageBox.Show("Lot is rejected.\nRemove from COC?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        //PMTransaction_Class_obj.pmsuppliercocid 
                        PMTransaction_Class_obj.cocapplicable = "N";
                        PMTransaction_Class_obj.Update_tblPMSupplierCOC_COCApplicable();
                    }
                }

                if (PMTransaction_Class_obj.pmchangeid != 0)
                {
                    //----------Inser Defect
                    // If accept Automatically close the defect status
                    if (RdoAccept.Checked == true)
                    {
                        for (int d = 0; d < dgDefect.Rows.Count; d++)
                        {
                            if (!dgDefect.Rows[d].IsNewRow)
                            {
                                dgDefect["DefectStatus", d].Value = "Close";
                            }
                        }
                    }
                    for (int d = 0; d < dgDefect.Rows.Count; d++)
                    {
                        if (!dgDefect.Rows[d].IsNewRow)
                        {
                            PMTransaction_Class_obj.defectcomment = Convert.ToString(dgDefect["DefectComment", d].Value);
                            PMTransaction_Class_obj.defectquantity = Convert.ToString(dgDefect["DefectQuantity", d].Value);

                            if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "Line Stopped : Requested QC to check")
                                PMTransaction_Class_obj.actiontaken = "Q";
                            else if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "Line Stopped : Material returned to store")
                                PMTransaction_Class_obj.actiontaken = "R";
                            else if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "On Line Sorting")
                                PMTransaction_Class_obj.actiontaken = "S";
                            else if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "On Line Adjustment")
                                PMTransaction_Class_obj.actiontaken = "A";
                            else if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "Other")
                                PMTransaction_Class_obj.actiontaken = "O";

                            PMTransaction_Class_obj.qualitydecision = Convert.ToString(dgDefect["QualityDecision", d].Value);

                            if (Convert.ToString(dgDefect["DefectStatus", d].Value) == "Open")
                                PMTransaction_Class_obj.defectstatus = "O";
                            if (Convert.ToString(dgDefect["DefectStatus", d].Value) == "Close")
                                PMTransaction_Class_obj.defectstatus = "C";

                            if (dgDefect["PMDefectID", d].Value == null || Convert.ToString(dgDefect["PMDefectID", d].Value) == "")
                            {
                                PMTransaction_Class_obj.pmdefectid = PMTransaction_Class_obj.Insert_tblPMDefect();
                            }
                            else
                            {
                                PMTransaction_Class_obj.pmdefectid = Convert.ToInt64(dgDefect["PMDefectID", d].Value);
                                PMTransaction_Class_obj.Update_tblPMDefect();
                            }
                        }
                    }


                    //---------Save systematic tests
                    for (int i = 0; i < dgAllTests.Rows.Count; i++)
                    {
                        //FinishedGoodTest_Class_Obj.pkgtechno = 
                        PMTransaction_Class_obj.testname = dgAllTests["TestMethod", i].Value.ToString();
                        PMTransaction_Class_obj.inspectionmethod = dgAllTests["InspectionMethod", i].Value.ToString();
                        PMTransaction_Class_obj.frequency = dgAllTests["Frequency", i].Value.ToString();
                        //FinishedGoodTest_Class_Obj.type 
                        PMTransaction_Class_obj.lotsize = dgAllTests["LotSize", i].Value.ToString();

                        PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                        //Insert standard reading in tblPMFGTestMethoddetails(Transaction level)
                        if (dgAllTests["SampleSizeStandard", i].Value.ToString() == "")
                        {
                            PMTransaction_Class_obj.samplesize = 0;
                        }
                        else
                        {
                            PMTransaction_Class_obj.samplesize = Convert.ToInt32(dgAllTests["SampleSizeStandard", i].Value);
                        }
                        PMTransaction_Class_obj.aql = dgAllTests["AQLStandard", i].Value.ToString();
                        PMTransaction_Class_obj.aqlz = dgAllTests["AQLzStandard", i].Value.ToString();
                        PMTransaction_Class_obj.aqlc = dgAllTests["AQLcStandard", i].Value.ToString();
                        PMTransaction_Class_obj.aqlm = dgAllTests["AQLMStandard", i].Value.ToString();
                        PMTransaction_Class_obj.aqlm1 = dgAllTests["AQLM1Standard", i].Value.ToString();


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
                if (GlobalVariables.City.ToLower() == "pune")
                {
                    if (PMTransaction_Class_obj.cocapplicable == "N")
                    {
                        bool ChangeCOC = false; DataSet ds = new DataSet();
                        ds = PMTransaction_Class_obj.Select_LastTen_DefectObserved();
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {

                            if (ds.Tables[0].Rows.Count == 10)
                            {
                                ChangeCOC = true;
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    if (dr["DefectObserved"].ToString() == "Y")
                                    {
                                        ChangeCOC = false;
                                        break;
                                    }

                                }
                                if (ChangeCOC)
                                {
                                    //PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                                    PMTransaction_Class_obj.cocapplicable = "Y";
                                    PMTransaction_Class_obj.Update_tblPMSupplierCOC_COCApplicable();
                                    PMTransaction_Class_obj.Insert_tblPMCOCHistory();

                                }
                            }
                        }


                    }
                }
                MessageBox.Show("Record saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnReset_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void cmbDefectObserved_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDefectObserved.SelectedItem.ToString() != "Yes")
            {
                foreach (DataGridViewRow dr in dgDefect.Rows)
                {
                    if (dr.Cells["PMDefectID"].Value == null || Convert.ToString(dr.Cells["PMDefectID"].Value) == "")
                        if (!dr.IsNewRow)
                            dgDefect.Rows.Remove(dr);
                }
                dgDefect.AllowUserToAddRows = false;
                txtNoOfDefect.Enabled = false;
                txtNoOfDefect.Text = "";
            }
            else
            {
                dgDefect.AllowUserToAddRows = true;
                txtNoOfDefect.Enabled = true;
            }
        }

        private void RdoAccept_CheckedChanged(object sender, EventArgs e)
        {
            RdoAWD.Visible = false;
            RdoTreatment.Visible = false;
            chkRejectComments.Visible = false;
            RdoSendBackToSupplier.Visible = false;
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
                RdoSendBackToSupplier.Visible = true;
                for (int i = 0; i < chkRejectComments.Items.Count; i++)
                {
                    if (chkRejectComments.Items[i].ToString() == "Blocked on Floor")
                        chkRejectComments.SetItemChecked(i, true);
                }
            }
        }

        private void RdoSendBackToSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoSendBackToSupplier.Checked == true)
            {
                RdoAWD.Visible = true;
                RdoTreatment.Visible = true;
                chkRejectComments.Visible = true;
                RdoSendBackToSupplier.Visible = true;
            }
            //RdoAWD.Visible = false;
            //RdoTreatment.Visible = false;
            //chkRejectComments.Visible = false;
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

        private void FillTestGrid()
        {
            try
            {
                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Warning");
                    txtQuantity.Focus();
                    return;
                }
                else
                {
                    dgAllTests.Rows.Clear();

                    if ((Convert.ToInt64(txtQuantity.Text) < 501))
                    {
                        MessageBox.Show("Quantity Less Than 501", "Warning");
                        txtQuantity.Text = "";
                        txtQuantity.Focus();
                        return;
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 501) && (Convert.ToInt64(txtQuantity.Text) <= 1200))
                    {
                        PMTransaction_Class_obj.lotsize = "501-1200";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 1201) && (Convert.ToInt64(txtQuantity.Text) <= 3200))
                    {
                        PMTransaction_Class_obj.lotsize = "1201-3200";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 3201) && (Convert.ToInt64(txtQuantity.Text) <= 10000))
                    {
                        PMTransaction_Class_obj.lotsize = "3201-10000";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 10001) && (Convert.ToInt64(txtQuantity.Text) <= 35000))
                    {
                        PMTransaction_Class_obj.lotsize = "10001-35000";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 35001) && (Convert.ToInt64(txtQuantity.Text) <= 150000))
                    {
                        PMTransaction_Class_obj.lotsize = "35001-150000";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 150001) && (Convert.ToInt64(txtQuantity.Text) <= 5000000))
                    {
                        PMTransaction_Class_obj.lotsize = "150001-5000000";
                    }
                    else
                    {
                        MessageBox.Show("Quantity greater Than 5000000", "Warning");
                        txtQuantity.Text = "";
                        txtQuantity.Focus();
                        return;
                    }

                    //only systematic testing is done regularly
                    //Periodic testing is done once a year

                    PMTransaction_Class_obj.frequency = "Systematic";



                    DataSet dsInspMethod = new DataSet();
                    DataSet dsAll = new DataSet();
                    DataTable Dt = new DataTable();
                    Dt = PMMaster_Class_obj.Select_tblPMCodeFamilyTestRelation_PMCodeID();

                    if (Dt.Rows.Count > 0)
                    {
                        PMTransaction_Class_obj.pmcodeid = PMMaster_Class_obj.pmcodeid;
                        DataSet ds = new DataSet();
                        ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName_PMCodeID();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dgAllTests.Rows.Add();

                                dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                                PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value.ToString();

                                dgAllTests["TestDesc", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                                dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod_Modification();

                                if (dsInspMethod.Tables[0].Rows.Count <= 0)
                                {
                                    dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();
                                }

                                DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                                combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                                combo.Items.Add(dsInspMethod.Tables[0].Rows[0][0].ToString());
                                //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                                //{
                                //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                                //}
                                dgAllTests.Rows[i].Cells["InspectionMethod"] = combo;

                                DataSet dsReading;
                                dsReading = new DataSet();
                                PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                combo.Value = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All_Modification();
                                //dsAll = PMTransaction_Class_obj.Select_PMFGMethodDetails_PMTransID();
                                //if (dsAll.Tables[0].Rows.Count <= 0)
                                //{
                                //    dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                                //    dsAll.Tables[0].Columns.Add("SampleSizeReading");
                                //    dsAll.Tables[0].Columns.Add("AQLReading");
                                //    dsAll.Tables[0].Columns.Add("AQLZReading");
                                //    dsAll.Tables[0].Columns.Add("AQLCReading");
                                //    dsAll.Tables[0].Columns.Add("AQLMReading");
                                //    dsAll.Tables[0].Columns.Add("AQLM1Reading");
                                //}
                                DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);

                            }
                        }

                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dgAllTests.Rows.Add();

                                dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                                PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value.ToString();

                                dgAllTests["TestDesc", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                                dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod_Modification();

                                if (dsInspMethod.Tables[0].Rows.Count <= 0)
                                {
                                    dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();
                                }

                                DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                                combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                                combo.Items.Add(dsInspMethod.Tables[0].Rows[0][0].ToString());
                                //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                                //{
                                //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                                //}
                                dgAllTests.Rows[i].Cells["InspectionMethod"] = combo;

                                DataSet dsReading;
                                dsReading = new DataSet();
                                PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                combo.Value = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All_Modification();
                                //dsAll = PMTransaction_Class_obj.Select_PMFGMethodDetails_PMTransID();
                                //if (dsAll.Tables[0].Rows.Count <= 0)
                                //{
                                //    dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                                //    dsAll.Tables[0].Columns.Add("SampleSizeReading");
                                //    dsAll.Tables[0].Columns.Add("AQLReading");
                                //    dsAll.Tables[0].Columns.Add("AQLZReading");
                                //    dsAll.Tables[0].Columns.Add("AQLCReading");
                                //    dsAll.Tables[0].Columns.Add("AQLMReading");
                                //    dsAll.Tables[0].Columns.Add("AQLM1Reading");
                                //}
                                DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);

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

        private void DisplayDataGridView_All(DataSet dsAll, int rowIndex)
        {

            if (dsAll.Tables[0].Rows.Count > 0)
            {

                dgAllTests["Frequency", rowIndex].Value = dsAll.Tables[0].Rows[0]["frequency"];

                dgAllTests["LotSize", rowIndex].Value = dsAll.Tables[0].Rows[0]["lotsize"];

                dgAllTests["SampleSizeStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["samplesize"];

                //Set to blank
                if (dsAll.Tables[0].Rows[0]["SampleSizeReading"].ToString() != "")
                    dgAllTests["SampleSizeReading", rowIndex].Value = dsAll.Tables[0].Rows[0]["SampleSizeReading"];
                else
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
                    if (dsAll.Tables[0].Rows[0]["AQLReading"].ToString() != "")
                        dgAllTests["AQLReading", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLReading"];
                    else
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
                    if (dsAll.Tables[0].Rows[0]["AQLZReading"].ToString() != "")
                        dgAllTests["AQLzReading", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLZReading"];
                    else
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
                    if (dsAll.Tables[0].Rows[0]["AQLCReading"].ToString() != "")
                        dgAllTests["AQLcReading", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLCReading"];
                    else
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
                    if (dsAll.Tables[0].Rows[0]["AQLMReading"].ToString() != "")
                        dgAllTests["AQLMReading", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLMReading"];
                    else
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
                    if (dsAll.Tables[0].Rows[0]["AQLM1Reading"].ToString() != "")
                        dgAllTests["AQLM1Reading", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLM1Reading"];
                    else
                        dgAllTests["AQLM1Reading", rowIndex].Value = "";

                    dgAllTests["AQLM1Reading", rowIndex].ReadOnly = false;
                    dgAllTests["AQLM1Reading", rowIndex].Style.BackColor = Color.White;
                }
            }
        }

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

        public void cmb_TextChanged(object sender, EventArgs e)
        {
            if (dgAllTests.CurrentCell.RowIndex < 0 || dgAllTests.CurrentCell.ColumnIndex != dgAllTests.Columns["InspectionMethod"].Index || cmb.Text == "")
            {
                return;
            }
            else
            {

                DataSet dsAll = new DataSet();

                PMTransaction_Class_obj.inspectionmethod = cmb.Text;
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

        private void dgAllTests_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgAllTests.Columns["SampleSizeReading"].Index)
            {
                return;
            }
            else
            {

                if (dgAllTests.CurrentCell.EditedFormattedValue.ToString() != "")
                {
                    if (Convert.ToInt64(dgAllTests.CurrentCell.EditedFormattedValue) < Convert.ToInt64(dgAllTests["SampleSizeStandard", dgAllTests.CurrentCell.RowIndex].Value))
                    {
                        MessageBox.Show("Sample Size Reading is less than Sample Size Standard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        e.Cancel = true;

                    }
                }
            }
        }

        private void RdoYes_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoYes.Checked == true)
            {
                if (MessageBox.Show("Perform Testing ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    PMTransaction_Class_obj.frequency = "Systematic";
                    FillTestGrid();
                    dgAllTests.Focus();
                }
            }
        }

        private void RdoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoNo.Checked == true)
            {
                dgAllTests.Rows.Clear();
            }
        }


    }


}



#region OLD Code
//private void FillTestGrid()
//{
//    try
//    {
//        if (txtQuantity.Text == "")
//        {
//            MessageBox.Show("Please Enter Quantity", "Warning");
//            txtQuantity.Focus();
//            return;
//        }
//        else
//        {
//            dgAllTests.Rows.Clear();

//            if ((Convert.ToInt64(txtQuantity.Text) < 501))
//            {
//                MessageBox.Show("Quantity Less Than 501", "Warning");
//                txtQuantity.Text = "";
//                txtQuantity.Focus();
//                return;
//            }
//            else if ((Convert.ToInt64(txtQuantity.Text) >= 501) && (Convert.ToInt64(txtQuantity.Text) <= 1200))
//            {
//                PMTransaction_Class_obj.lotsize = "501-1200";
//            }
//            else if ((Convert.ToInt64(txtQuantity.Text) >= 1201) && (Convert.ToInt64(txtQuantity.Text) <= 3200))
//            {
//                PMTransaction_Class_obj.lotsize = "1201-3200";
//            }
//            else if ((Convert.ToInt64(txtQuantity.Text) >= 3201) && (Convert.ToInt64(txtQuantity.Text) <= 10000))
//            {
//                PMTransaction_Class_obj.lotsize = "3201-10000";
//            }
//            else if ((Convert.ToInt64(txtQuantity.Text) >= 10001) && (Convert.ToInt64(txtQuantity.Text) <= 35000))
//            {
//                PMTransaction_Class_obj.lotsize = "10001-35000";
//            }
//            else if ((Convert.ToInt64(txtQuantity.Text) >= 35001) && (Convert.ToInt64(txtQuantity.Text) <= 150000))
//            {
//                PMTransaction_Class_obj.lotsize = "35001-150000";
//            }
//            else if ((Convert.ToInt64(txtQuantity.Text) >= 150001) && (Convert.ToInt64(txtQuantity.Text) <= 5000000))
//            {
//                PMTransaction_Class_obj.lotsize = "150001-5000000";
//            }
//            else
//            {
//                MessageBox.Show("Quantity greater Than 5000000", "Warning");
//                txtQuantity.Text = "";
//                txtQuantity.Focus();
//                return;
//            }

//            //only systematic testing is done regularly
//            //Periodic testing is done once a year

//            PMTransaction_Class_obj.frequency = "Systematic";
//            PMMaster_Class_obj.pmcodeid = Convert.ToInt64(cmbPMCode.SelectedValue);
//            DataSet dsInspMethod = new DataSet();
//            DataSet dsAll = new DataSet();
//             DataTable Dt = new DataTable();
//            Dt = PMMaster_Class_obj.Select_tblPMCodeFamilyTestRelation_PMCodeID();

//            if (Dt.Rows.Count > 0)
//            {
//                PMTransaction_Class_obj.pmcodeid = Convert.ToInt64(cmbPMCode.SelectedValue);
//                DataSet ds = new DataSet();
//                ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName_PMCodeID();
//                if (ds.Tables[0].Rows.Count > 0)
//                {
//                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
//                    {
//                        dgAllTests.Rows.Add();

//                        dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
//                        PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value.ToString();

//                        dgAllTests["TestDesc", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

//                        dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();

//                        DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
//                        combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
//                        for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
//                        {
//                            combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
//                        }
//                        dgAllTests.Rows[i].Cells["InspectionMethod"] = combo;

//                        DataSet dsReading;
//                        for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
//                        {
//                            dsReading = new DataSet();
//                            PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row][0].ToString();
//                            PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

//                            combo.Value = dsInspMethod.Tables[0].Rows[row][0].ToString();
//                            dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
//                            DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);
//                        }
//                    }
//                }

//            }
//            else
//            {
//                DataSet ds = new DataSet();
//                ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName();
//                if (ds.Tables[0].Rows.Count > 0)
//                {
//                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
//                    {
//                        dgAllTests.Rows.Add();

//                        dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
//                        PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value.ToString();

//                        dgAllTests["TestDesc", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

//                        dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();

//                        DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
//                        combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
//                        for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
//                        {
//                            combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
//                        }
//                        dgAllTests.Rows[i].Cells["InspectionMethod"] = combo;

//                        DataSet dsReading;
//                        for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
//                        {
//                            dsReading = new DataSet();
//                            PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row][0].ToString();
//                            PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

//                            combo.Value = dsInspMethod.Tables[0].Rows[row][0].ToString();
//                            dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
//                            DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);
//                        }
//                    }
//                }

//            }
//        }

//    }
//    catch (Exception ex)
//    {
//        MessageBox.Show(ex.Message);
//    }
//}
#endregion