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
    public partial class FrmPMDefectNote : Form
    {
        public FrmPMDefectNote()
        {
            InitializeComponent();
        }
        #region Variables
        Comman_Class Comman_Class_obj = new Comman_Class();
        PMTransaction_Class PMTransaction_Class_obj = new PMTransaction_Class();
        UserData UserDataObj = new UserData();
        GroupMaster_Class GroupMaster_Class_Obj = new GroupMaster_Class();
        Int64 PmSupplierCOCID = 0;
        #endregion

        private static FrmPMDefectNote frmPMDefectNote_Obj = null;

        public static FrmPMDefectNote GetInstance()
        {
            if (frmPMDefectNote_Obj == null)
            {
                frmPMDefectNote_Obj = new Transactions.FrmPMDefectNote();
            }
            return frmPMDefectNote_Obj;
        }

        private void FrmPMDefectNote_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_PMCode();
            BindLineNo();
            BindUserList();
            Bind_GroupNames();
            BtnReset_Click(sender, e);
        }

        public void Bind_PMCode()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = PMTransaction_Class_obj.Select_View_PendingPMDefectNote();
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
                grpUserMail.Enabled = true;
                btnSend.Enabled = true;
                cmbPlantLotNo.Text = "--Select--";
                resetall();

                if (cmbPMCode.SelectedValue.ToString() != null && cmbPMCode.SelectedValue.ToString() != "")
                {
                    DataSet ds = new DataSet();
                    PMTransaction_Class_obj.pmcodeid = Convert.ToInt64(cmbPMCode.SelectedValue);
                    ds = PMTransaction_Class_obj.Select_View_PendingPMDefectNote_PMCodeID();
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
            catch
            {
                throw;
            }
        }

        private void BindLineNo()
        {
            try
            {
                DataGridViewComboBoxColumn DataGridViewComboBoxColumnObj;
                DataGridViewComboBoxColumnObj = (DataGridViewComboBoxColumn)(dgDefect.Columns["LineNumber"]);

                LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
                DataSet ds = new DataSet();
                ds = LineMaster_Class_Obj.Select_LineMaster();
                DataRow dr;
                dr = ds.Tables[0].NewRow();
                dr["LineDesc"] = "--Select--";
                dr["LNo"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                DataGridViewComboBoxColumnObj.DataSource = ds.Tables[0];
                DataGridViewComboBoxColumnObj.DisplayMember = "LineDesc";
                //DataGridViewComboBoxColumnObj.ValueMember = "LNo";               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cmbPlantLotNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PmSupplierCOCID = 0;
                resetall();
                if (cmbPlantLotNo.SelectedValue.ToString() != null && cmbPlantLotNo.SelectedValue.ToString() != "")
                {
                    DataSet ds = new DataSet();
                    DataSet dsDefect = new DataSet();
                    PMTransaction_Class_obj.pmtestid = Convert.ToInt64(cmbPlantLotNo.SelectedValue);
                    ds = PMTransaction_Class_obj.Select_View_PendingPMDefectNote_PMTestID();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        PmSupplierCOCID = Convert.ToInt64(ds.Tables[0].Rows[0]["PMSupplierCOCID"].ToString());
                        txtDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMDescription"]);
                        txtSupplier.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMSupplierName"]);
                        DtpAcceptedDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["AcceptedDate"]);
                        txtCOC.Text = Convert.ToString(ds.Tables[0].Rows[0]["COCApplicable"]);
                        txtQuantity.Text = Convert.ToString(ds.Tables[0].Rows[0]["Quantity"]);

                        PMTransaction_Class_obj.pmtransid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMTransID"]); //Use this PMTransID to send mail to the user
                        PMTransaction_Class_obj.pmchangeid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMChangeID"]);
                        PMTransaction_Class_obj.status = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                        PMTransaction_Class_obj.actualstatus = Convert.ToString(ds.Tables[0].Rows[0]["ActualStatus"]);
                        PMTransaction_Class_obj.rejectcomment = Convert.ToString(ds.Tables[0].Rows[0]["RejectComment"]);


                        if (ds.Tables[0].Rows[0]["LotReturn"].ToString() == "1")
                            ChkLotReturn.Checked = true;
                        else
                            ChkLotReturn.Checked = false;
                        if (ds.Tables[0].Rows[0]["OnlineSorted"].ToString() == "1")
                            ChkOnlineSorted.Checked = true;
                        else
                            ChkOnlineSorted.Checked = false;
                        if (ds.Tables[0].Rows[0]["LotComsumption"].ToString() == "1")
                            ChkLotComsumption.Checked = true;
                        else
                            ChkLotComsumption.Checked = false;

                        txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

                        if (ds.Tables[0].Rows[0]["PartlyQuantity"].ToString() == "0")
                            txtPartlyQuantity.Text = "";
                        else
                            txtPartlyQuantity.Text = ds.Tables[0].Rows[0]["PartlyQuantity"].ToString();

                        if (ds.Tables[0].Rows[0]["Complete"].ToString() == "1")
                            RdoComplete.Checked = true;
                        else
                            RdoComplete.Checked = false;
                        if (ds.Tables[0].Rows[0]["Partly"].ToString() == "1")
                            RdoPartly.Checked = true;
                        else
                            RdoPartly.Checked = false;

                        // dsDefect = PMTransaction_Class_obj.Select_PMDefect_PMTestID();// Old Logic
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
                                //
                                PMTransaction_Class_obj.pmtestid = Convert.ToInt64(cmbPlantLotNo.SelectedValue);
                                DataSet dsDefStatus = PMTransaction_Class_obj.Select_tblSupplierCorrectiveNote_DefectStatus();
                                int icount = dsDefStatus.Tables[0].Rows.Count;
                                if (dsDefStatus.Tables[0].Rows.Count > 0)
                                {
                                    //if (dsDefStatus.Tables[0].Rows[icount - 1][0].ToString() == "O")
                                    //    dgDefect["DefectStatus", d].Value = "Open";
                                    if (dsDefStatus.Tables[0].Rows[icount - 1][0].ToString() == "C")
                                        dgDefect["DefectStatus", d].Value = "Close";
                                }
                                else
                                {
                                    if (Convert.ToString(dsDefect.Tables[0].Rows[d]["DefectStatus"]) == "O")
                                    {
                                        dgDefect["DefectStatus", d].Value = "Open";
                                        dgDefect.Rows[d].ReadOnly = false; // New Change If Defect Status is open then it is allowed to Update 
                                    }
                                    else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["DefectStatus"]) == "C")
                                    {
                                        dgDefect["DefectStatus", d].Value = "Close";
                                        dgDefect.Rows[d].ReadOnly = true; // New Change If Defect Status is open then it is not allowed to Update the record
                                    }
                                }
                                //

                                if (dsDefect.Tables[0].Rows[d]["LNo"].ToString() != "")
                                    dgDefect["LineNumber", d].Value = Convert.ToString(dsDefect.Tables[0].Rows[d]["LNo"]);
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

        public void resetall()
        {
            PmSupplierCOCID = 0;
            txtDesc.Text = "";
            txtSupplier.Text = "";
            DtpAcceptedDate.Value = Comman_Class_obj.Select_ServerDate();
            DtpInspDate.Value = Comman_Class_obj.Select_ServerDate();
            txtCOC.Text = "";
            txtQuantity.Text = "";

            cmbDefectObserved.SelectedIndex = 0;
            txtNoOfDefect.Enabled = false;
            txtNoOfDefect.Text = "";
            dgDefect.AllowUserToAddRows = false;
            dgDefect.Rows.Clear();
            dgDefect.Columns["ActionTaken"].DataPropertyName = "--Select--";

            ChkLotReturn.Checked = false;
            ChkLotComsumption.Checked = false;
            ChkOnlineSorted.Checked = false;
            RdoPartly.Checked = false;
            RdoComplete.Checked = false;
            txtRemark.Text = "";
            txtPartlyQuantity.Text = "";

            RdoComplete.Visible = false;
            RdoPartly.Visible = false;
            txtPartlyQuantity.Visible = false;
            lblQuantity.Visible = false;
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

                //PMTransaction_Class_obj.status
                //PMTransaction_Class_obj.actualstatus  
                //PMTransaction_Class_obj.rejectcomment

                PMTransaction_Class_obj.currentflag = 1;
                PMTransaction_Class_obj.fromAnalysisReanalysis = 2; // This Flag shows records only in modification                                       
                PMTransaction_Class_obj.loginid = FrmMain.LoginID;

                PMTransaction_Class_obj.pmchangeid = PMTransaction_Class_obj.Insert_PMStatus();

                #region adding record fot lot & remark //02-09-2017 Avinash S

                if (ChkLotReturn.Checked)
                {
                    PMTransaction_Class_obj.lotreturn = 1;
                    if (RdoComplete.Checked)
                        PMTransaction_Class_obj.complete = 1;
                    else
                        PMTransaction_Class_obj.complete = 0;
                    if (RdoPartly.Checked)
                    {
                        PMTransaction_Class_obj.partly = 1;
                        PMTransaction_Class_obj.partlyquantity = Convert.ToInt64(txtPartlyQuantity.Text.Trim());
                    }
                    else
                    {
                        PMTransaction_Class_obj.partly = 0;
                        PMTransaction_Class_obj.partlyquantity = 0;
                    }
                }
                else
                {
                    PMTransaction_Class_obj.lotreturn = 0;
                    PMTransaction_Class_obj.complete = 0;
                    PMTransaction_Class_obj.partly = 0;
                    PMTransaction_Class_obj.partlyquantity = 0;
                }
                if (ChkOnlineSorted.Checked)
                    PMTransaction_Class_obj.onlinesorted = 1;
                else
                    PMTransaction_Class_obj.onlinesorted = 0;
                if (ChkLotComsumption.Checked)
                    PMTransaction_Class_obj.lotcomsumption = 1;
                else
                    PMTransaction_Class_obj.lotcomsumption = 0;

                PMTransaction_Class_obj.remark = txtRemark.Text.Trim();

                PMTransaction_Class_obj.Insert_Update_tblPMDefectRemark();

                #endregion

                if (PMTransaction_Class_obj.pmchangeid != 0)
                {
                    //----------Inser Defect
                    // If accept Automatically close the defect status
                    //if (PMTransaction_Class_obj.status == "A")
                    //{
                    //    for (int d = 0; d < dgDefect.Rows.Count; d++)
                    //    {
                    //        if (!dgDefect.Rows[d].IsNewRow)
                    //        {
                    //            dgDefect["DefectStatus", d].Value = "Close";
                    //        }
                    //    }
                    //}
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

                            PMTransaction_Class_obj.lineNumber = Convert.ToString(dgDefect["LineNumber", d].Value);

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
                }

                //if (MessageBox.Show("Record saved successfully Do you want to send mail?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
                //{
                //    grpUserMail.Enabled = true;
                //    btnSend.Enabled = true;
                //    BindUserList();

                //}
                PMTransaction_Class_obj.cocapplicable = txtCOC.Text;
                if (GlobalVariables.City.ToLower() == "pune")
                {
                    if (PMTransaction_Class_obj.cocapplicable == "N")
                    {
                        bool ChangeCOC = false; DataSet ds = new DataSet();
                        PMTransaction_Class_obj.pmsupplcocid = PmSupplierCOCID;
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
                //for (int d = 0; d < dgDefect.Rows.Count; d++)
                //{
                //    if (!dgDefect.Rows[d].IsNewRow)
                //    {
                //        dgDefect["Status", d].Value = "Open";
                //    }
                //}
            }
            else
            {
                dgDefect.AllowUserToAddRows = true;
                txtNoOfDefect.Enabled = true;
            }
        }

        private void dgDefect_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int d = 0; d < dgDefect.Rows.Count; d++)
                {
                    if (!dgDefect.Rows[d].IsNewRow)
                    {
                        if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                        {
                            //dgDefect.CurrentRow.Cells["DefectStatus"].Value = "Open";
                            dgDefect.CurrentRow.Cells["ActionTaken"].Value = "Other";
                            //dgDefect.CurrentRow.Cells["LineNumber"].Value = "--Select--";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgDefect_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        private void BindUserList()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = UserDataObj.Show_AllUser();

                chkLstUserName.DataSource = Dt;
                chkLstUserName.DisplayMember = "UserName";
                chkLstUserName.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        public void Bind_GroupNames()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = GroupMaster_Class_Obj.Select_tblSoftwareUserGroup();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    chkLstGroupName.DataSource = ds.Tables[0];
                    chkLstGroupName.DisplayMember = "GroupName";
                    chkLstGroupName.ValueMember = "GroupID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    BtnSave_Click(sender, e);
                    DataTable Dt = new DataTable();
                    string username = String.Empty;

                    foreach (DataRowView userId in chkLstUserName.CheckedItems)
                    {
                        UserDataObj.userid = Convert.ToInt32(userId[0]);
                        Dt = UserDataObj.Show_SelectedUser();
                        if (Dt.Rows.Count > 0)
                        {
                            username += Convert.ToString(Dt.Rows[0]["UserMailID"]) + ",";
                        }
                    }
                    DataTable dtGruop = new DataTable();
                    DataTable dtUser = new DataTable();
                    foreach (DataRowView grpID in chkLstGroupName.CheckedItems)
                    {
                        UserDataObj.groupID = Convert.ToInt32(grpID[0]);
                        dtGruop = UserDataObj.Select_SoftwareUserGroupRelation();
                        foreach (DataRow dr in dtGruop.Rows)
                        {
                            UserDataObj.userid = Convert.ToInt32(dr["UserID"]);
                            dtUser = UserDataObj.Show_SelectedUser();
                            if (dtUser.Rows.Count > 0)
                            {
                                username += Convert.ToString(dtUser.Rows[0]["UserMailID"]) + ",";
                            }
                        }

                    }
                    username = username.TrimEnd(new char[] { ',' });
                    if (username == "")
                    {
                        MessageBox.Show("User Mail ID does not exist");
                        return;
                    }
                    //else
                    //{
                    //    username = username.TrimEnd(new char[] { ',' });
                    //}
                    QTMS.Reports_Forms.FrmPM_Note obj = new QTMS.Reports_Forms.FrmPM_Note("DefectNote_PM");
                    obj.ShowDefectNoteReport(PMTransaction_Class_obj.pmtransid, username);
                    MessageBox.Show("Mail sent sucessfully!");
                    btnSend.Enabled = false;
                    //grpUserMail.Enabled = false;
                    for (int i = 0; i < chkLstUserName.Items.Count; i++)
                    {
                        chkLstUserName.SetItemChecked(i, false);
                    }
                    for (int i = 0; i < chkLstGroupName.Items.Count; i++)
                    {
                        chkLstGroupName.SetItemChecked(i, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsValid()
        {
            if (cmbPMCode.SelectedValue == null || cmbPMCode.Text == "--Select--")
            {
                MessageBox.Show("Please Select PMCode", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                cmbPMCode.Focus();
                return false;
            }
            if (cmbPlantLotNo.SelectedValue == null || cmbPlantLotNo.Text == "--Select--")
            {
                MessageBox.Show("Please Select PlantLotNo", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                cmbPlantLotNo.Focus();
                return false;
            }
            if (cmbDefectObserved.SelectedIndex == 0 || cmbDefectObserved.Text == "--Select--")
            {
                MessageBox.Show("Please Select Defect Observed", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                cmbDefectObserved.Focus();
                return false;
            }
            if (cmbDefectObserved.SelectedIndex == 2 && txtNoOfDefect.Text.Trim() == "")
            {
                MessageBox.Show("Please enter No of Defects", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtNoOfDefect.Focus();
                return false;
            }
            if (chkLstUserName.CheckedItems.Count <= 0 && chkLstGroupName.CheckedItems.Count <= 0)
            {
                MessageBox.Show("Please checked atleast one User names or Group name in Listbox. ", "PM Defect Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void ChkLotReturn_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkLotReturn.Checked == true)
            {
                RdoComplete.Visible = true;
                RdoPartly.Visible = true;
            }
            else
            {
                RdoComplete.Visible = false;
                RdoPartly.Visible = false;

                RdoComplete.Checked = false;
                RdoPartly.Checked = false;
            }
        }

        private void RdoPartly_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoPartly.Checked == true)
            {
                lblQuantity.Visible = true;
                txtPartlyQuantity.Visible = true;
            }
            else
            {
                lblQuantity.Visible = false;
                txtPartlyQuantity.Visible = false;
                txtPartlyQuantity.Text = "";
            }
        }

        private void txtPartlyQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

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




    }


}