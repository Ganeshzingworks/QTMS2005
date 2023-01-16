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
    public partial class FrmConsumerComplaintTransaction : System.Windows.Forms.Form
    {
        public FrmConsumerComplaintTransaction()
        {           
            InitializeComponent();            
        }

        #region Variables
        BusinessFacade.FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new BusinessFacade.FormulaNoMaster_Class();
        BusinessFacade.PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new BusinessFacade.PackingFamilyMaster_Class(); 
        BusinessFacade.Transactions.Comman_Class Comman_Class_obj = new Comman_Class();
        BusinessFacade.Transactions.ConsumerComplaint_Class ConsumerComplaint_Class_obj = new ConsumerComplaint_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class(); 
        #endregion

        private static FrmConsumerComplaintTransaction frmConsumerComplaintTransaction_Obj = null;
        public static FrmConsumerComplaintTransaction GetInstance()
        {
            if (frmConsumerComplaintTransaction_Obj == null)
            {
                frmConsumerComplaintTransaction_Obj = new Transactions.FrmConsumerComplaintTransaction();
            }
            return frmConsumerComplaintTransaction_Obj;
        }

        private void FrmConsumerComplaintTransaction_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_ComplaintCategory();
            Bind_FormulaNo();
            Bind_PackingFamily();
            Bind_InspectedBy();
            btnReset_Click(sender, e);
        }

        public void Bind_ComplaintCategory()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ConsumerComplaint_Class_obj.Select_ComplaintCategory();
                DataRow dr = ds.Tables[0].NewRow();
                dr["CategoryName"] = "--Select--";
                dr["CategoryID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbCategoryComplaint.DataSource = ds.Tables[0];
                    cmbCategoryComplaint.DisplayMember = "CategoryName";
                    cmbCategoryComplaint.ValueMember = "CategoryID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_FormulaNo()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = FormulaNoMaster_Class_Obj.Select_TblBulkMaster();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbFormulaNo.DataSource = ds.Tables[0];
                cmbFormulaNo.DisplayMember = "FormulaNo";
                cmbFormulaNo.ValueMember = "FNo";
            }
        }

        public void Bind_PackingFamily()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster();
            dr = ds.Tables[0].NewRow();
            dr["TechFamDesc"] = "--Select--";
            dr["PKGTechNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbPackingFamily.DataSource = ds.Tables[0];
                cmbPackingFamily.DisplayMember = "TechFamDesc";
                cmbPackingFamily.ValueMember = "PKGTechNo";
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtComplaintRefNo.Text = "";            
            reset();
        }

        public void reset()
        {
            DtpTrackCode.Value = Comman_Class_obj.Select_ServerDate();
            DtpTrackCode.Checked = false;
            txtBatchCode.Text = "";
            DtpDate.Value = Comman_Class_obj.Select_ServerDate();
            txtComplaintDetails.Text = "";
            cmbCategoryComplaint.Text = "--Select--";            
            cmbFormulaNo.Text = "--Select--";
            cmbPackingFamily.Text = "--Select--";
            txtFillVolume.Text = "";           
            dgOldTest.DataSource = null;
            dgComments.Rows.Clear();
            dgSteps.Rows.Clear();
            dgTest.Columns.Clear();
            txtRootCause.Text = "";
            RdoConformity.Checked = true;
            txtOtherComments.Text = "";
            cmbInspectedBy.Text = "--Select--";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbFormulaNo.SelectedValue != null && cmbFormulaNo.Text != "--Select--")
            {
                if(!dgTest.Columns.Contains(cmbFormulaNo.SelectedValue.ToString()))
                {
                    if (MessageBox.Show(cmbFormulaNo.Text +"?", "Add Formula", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        dgTest.Columns.Add(cmbFormulaNo.SelectedValue.ToString(), cmbFormulaNo.Text);
                        dgTest.Columns[cmbFormulaNo.SelectedValue.ToString()].Width = 100;
                        dgTest.Columns[cmbFormulaNo.SelectedValue.ToString()].ReadOnly = true;
                        dgTest[cmbFormulaNo.SelectedValue.ToString(), 0].Value = "";
                    }
                }
            }
        }

       

        private void txtComplaintRefNo_Leave(object sender, EventArgs e)
        {
            reset();
            if (txtComplaintRefNo.Text.Trim() != "")
            {
                ConsumerComplaint_Class_obj.complaintrefno = txtComplaintRefNo.Text.Trim();

                DataSet details = new DataSet();
                details = ConsumerComplaint_Class_obj.Select_tblComplaintTransaction_Details();
                if (details.Tables[0].Rows.Count > 0)
                {
                    ConsumerComplaint_Class_obj.transid = Convert.ToInt64(details.Tables[0].Rows[0]["TransID"]);

                    DtpTrackCode.Value = Convert.ToDateTime(details.Tables[0].Rows[0]["TrackCode"]);
                    txtBatchCode.Text = Convert.ToString(details.Tables[0].Rows[0]["BatchNo"]);
                    DtpDate.Value = Convert.ToDateTime(details.Tables[0].Rows[0]["InspDate"]); 
                    txtComplaintDetails.Text = Convert.ToString(details.Tables[0].Rows[0]["ComplaintDetail"]);
                    cmbCategoryComplaint.SelectedValue = Convert.ToInt64(details.Tables[0].Rows[0]["CategoryID"]);
                    cmbPackingFamily.SelectedValue = Convert.ToInt64(details.Tables[0].Rows[0]["PKGTechNo"]);
                    txtFillVolume.Text = Convert.ToString(details.Tables[0].Rows[0]["FillVolume"]);
                    txtRootCause.Text = Convert.ToString(details.Tables[0].Rows[0]["RootCause"]);

                    if (Convert.ToString(details.Tables[0].Rows[0]["Status"]) == "C")
                    {
                        RdoConformity.Checked = true;
                    }
                    else if (Convert.ToString(details.Tables[0].Rows[0]["Status"]) == "N")
                    {
                        RdoNonConformity.Checked = true;
                    }
                    else if (Convert.ToString(details.Tables[0].Rows[0]["Status"]) == "N")
                    {
                        RdoOther.Checked = true;
                    }

                    txtOtherComments.Text = Convert.ToString(details.Tables[0].Rows[0]["Comments"]);

                    if (details.Tables[0].Rows[0]["InspectedBy"] is System.DBNull)
                    {
                        cmbInspectedBy.SelectedValue = 0;
                    }
                    else
                    {
                        cmbInspectedBy.SelectedValue = Convert.ToInt64(details.Tables[0].Rows[0]["InspectedBy"]);
                    }

                    DataSet dsHistory = new DataSet();
                    dsHistory = ConsumerComplaint_Class_obj.Select_View_FGBulkTestDetails_TransID();
                    dgOldTest.DataSource = dsHistory.Tables[0];
                    foreach (DataGridViewRow dr in dgOldTest.Rows)
                    {
                        dr.Cells["Mark"].Value = true;
                    }

                    DataSet ds = new DataSet();
                    DataSet dsFNo;
                    ds = ConsumerComplaint_Class_obj.Select_tblComplaintObs_Formulas();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (!dgTest.Columns.Contains(ds.Tables[0].Rows[i]["FNo"].ToString()))
                            {
                                dgTest.Columns.Add(ds.Tables[0].Rows[i]["FNo"].ToString(), ds.Tables[0].Rows[i]["FormulaNo"].ToString());
                                dgTest.Columns[ds.Tables[0].Rows[i]["FNo"].ToString()].Width = 100;
                                dgTest.Columns[ds.Tables[0].Rows[i]["FNo"].ToString()].ReadOnly = true;

                                dsFNo = new DataSet();
                                ConsumerComplaint_Class_obj.fno = Convert.ToInt64(ds.Tables[0].Rows[i]["FNo"].ToString());
                                dsFNo = ConsumerComplaint_Class_obj.Select_tblComplaintPhyCheTestMethodDetails_Done();
                                if (dsFNo.Tables[0].Rows.Count > 0)
                                {
                                    dgTest[ds.Tables[0].Rows[i]["FNo"].ToString(), 0].Value = "Done";
                                }
                                else
                                {
                                    dgTest[ds.Tables[0].Rows[i]["FNo"].ToString(), 0].Value = "";
                                }
                            }
                        }
                    }

                    DataSet dsC = new DataSet();
                    dsC = ConsumerComplaint_Class_obj.Select_tblComplaintPackingObs();
                    if (dsC.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsC.Tables[0].Rows.Count; i++)
                        {
                            dgComments.Rows.Add();
                            dgComments["CommentsName", dgComments.Rows.Count - 2].Value = dsC.Tables[0].Rows[i]["PackingComments"].ToString();
                        }
                    }

                    DataSet dsS = new DataSet();
                    dsS = ConsumerComplaint_Class_obj.Select_tblComplaintInvestigation();
                    if (dsS.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsS.Tables[0].Rows.Count; i++)
                        {
                            dgSteps.Rows.Add();
                            dgSteps["Step", dgSteps.Rows.Count - 2].Value = dsS.Tables[0].Rows[i]["Step"].ToString();
                        }
                    }

                }                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {                
                if (txtComplaintRefNo.Text == "")
                {
                    MessageBox.Show("Please Enter the Complaint No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtComplaintRefNo.Focus();
                    return;
                }
                if (cmbCategoryComplaint.SelectedValue == null || cmbCategoryComplaint.Text == "--Select--")
                {
                    MessageBox.Show("Please Select the Complaint Category", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCategoryComplaint.Focus();
                    return;
                }
                if (txtBatchCode.Text == "")
                {
                    MessageBox.Show("Please Enter Batch Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchCode.Focus();
                    return;
                }
                if (DtpTrackCode.Checked == false)
                {
                    MessageBox.Show("Please Select Track Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DtpTrackCode.Focus();
                    return;
                }
                if (cmbPackingFamily.SelectedValue == null || cmbPackingFamily.Text == "--Select--")
                {
                    MessageBox.Show("Please Select the Packing Family", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPackingFamily.Focus();
                    return;
                }
                if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbInspectedBy.Focus();
                    return;
                }

                if (RdoConformity.Checked == false && RdoNonConformity.Checked == false && RdoOther.Checked == false)
                {
                    MessageBox.Show("Please Select Status", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (RdoConformity.Checked == true)
                {
                    if (MessageBox.Show("CONFORMITY ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoNonConformity.Checked == true)
                {
                    if (MessageBox.Show("NON-CONFORMITY ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoOther.Checked == true)
                {
                    if (MessageBox.Show("OTHER ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }

                ConsumerComplaint_Class_obj.complaintrefno = txtComplaintRefNo.Text.Trim();
                ConsumerComplaint_Class_obj.complaintdetail = txtComplaintDetails.Text.ToString();
                ConsumerComplaint_Class_obj.categoryid = Convert.ToInt32(cmbCategoryComplaint.SelectedValue);
                
                ConsumerComplaint_Class_obj.trackcode = DtpTrackCode.Value.ToShortDateString();
                ConsumerComplaint_Class_obj.batchno = txtBatchCode.Text.ToString();                
                ConsumerComplaint_Class_obj.pkgtechno = Convert.ToInt64(cmbPackingFamily.SelectedValue);
                ConsumerComplaint_Class_obj.fillvolume = txtFillVolume.Text.Trim();
                ConsumerComplaint_Class_obj.inspdate = DtpDate.Value.ToShortDateString();

                ConsumerComplaint_Class_obj.rootcause = txtRootCause.Text.Trim();

                if (RdoConformity.Checked == true)
                {
                    ConsumerComplaint_Class_obj.status = Convert.ToChar("C");
                }
                else if (RdoNonConformity.Checked == true)
                {
                    ConsumerComplaint_Class_obj.status = Convert.ToChar("N");
                }
                else if (RdoOther.Checked == true)
                {
                    ConsumerComplaint_Class_obj.status = Convert.ToChar("O");
                }
                
                ConsumerComplaint_Class_obj.comments = txtOtherComments.Text.ToString();

                ConsumerComplaint_Class_obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                ConsumerComplaint_Class_obj.loginid = FrmMain.LoginID;

                DataSet ds = new DataSet();
                ds=ConsumerComplaint_Class_obj.SELECT_ComplaintTransaction();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ConsumerComplaint_Class_obj.transid = Convert.ToInt64(ds.Tables[0].Rows[0]["TransID"].ToString());
                    ConsumerComplaint_Class_obj.update_tblComplaintTransaction();
                }
                else
                {
                    ConsumerComplaint_Class_obj.transid = ConsumerComplaint_Class_obj.Insert_tblComplaintTransaction();
                }

                //---- insert formulas -------------------------------------
                for (int i = 0; i < dgTest.Columns.Count; i++)
                {
                    ConsumerComplaint_Class_obj.fno = Convert.ToInt64(dgTest.Columns[i].Name);

                    DataSet dsObs = new DataSet();
                    dsObs = ConsumerComplaint_Class_obj.Select_tblComplaintObs_TransID_FNo();
                    if (dsObs.Tables[0].Rows.Count > 0)
                    {
                        ConsumerComplaint_Class_obj.obsid = Convert.ToInt64(dsObs.Tables[0].Rows[0]["ObsID"]);
                    }
                    else
                    {
                        ConsumerComplaint_Class_obj.obsid = ConsumerComplaint_Class_obj.Insert_ComplaintObs();
                    }
                }

                // ---------- delete previous History Linking ---------------
                ConsumerComplaint_Class_obj.Delete_tblComplaintHistory();

                // ---------- insert History Linking -----------------------------------
                for (int i = 0; i < dgOldTest.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgOldTest["Mark", i].Value) == true)
                    {
                        ConsumerComplaint_Class_obj.fgphycheno = Convert.ToInt64(dgOldTest["FGPhyCheNo", i].Value);
                        ConsumerComplaint_Class_obj.Insert_tblComplaintHistory();
                    }
                }


                // ---------- delete previous packing observations ---------------
                ConsumerComplaint_Class_obj.Delete_tblComplaintPackingObs();

                // ---------- insert packing observations ---------------
                for (int i = 0; i < dgComments.Rows.Count; i++)
                {
                    if (dgComments["CommentsName", i].Value != null && dgComments["CommentsName", i].Value.ToString().Trim() != "")
                    {
                        ConsumerComplaint_Class_obj.packingcomments = dgComments["CommentsName", i].Value.ToString();
                        ConsumerComplaint_Class_obj.Insert_ComplaintPackingObs();
                    }
                }

                // ---------- delete previous Investigation steps ---------------
                ConsumerComplaint_Class_obj.Delete_tblComplaintInvestigation();

                for (int i = 0; i < dgSteps.Rows.Count; i++)
                {
                    if (dgSteps["Step", i].Value != null && dgSteps["Step", i].Value.ToString().Trim() != "")
                    {
                        ConsumerComplaint_Class_obj.step = dgSteps["Step", i].Value.ToString();
                        ConsumerComplaint_Class_obj.Insert_tblComplaintInvestigation();
                    }
                }

                MessageBox.Show("Record Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReset_Click(sender, e);
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
                    if (txtComplaintRefNo.Text == "")
                    {
                        MessageBox.Show("Please Enter the Complaint No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtComplaintRefNo.Focus();
                        return;
                    }
                    if (DtpTrackCode.Checked == false)
                    {
                        MessageBox.Show("Please Select Track Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DtpTrackCode.Focus();
                        return;
                    }
                    if (txtBatchCode.Text == "")
                    {
                        MessageBox.Show("Please Enter Batch Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBatchCode.Focus();
                        return;
                    }                    
                    if (cmbPackingFamily.SelectedValue == null || cmbPackingFamily.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select the Packing Family", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbPackingFamily.Focus();
                        return;
                    }
                    if (cmbCategoryComplaint.SelectedValue == null || cmbCategoryComplaint.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select the Complaint Category", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbCategoryComplaint.Focus();
                        return;
                    }
                    if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbInspectedBy.Focus();
                        return;
                    }
                    ConsumerComplaint_Class_obj.complaintrefno = txtComplaintRefNo.Text.Trim();
                    ConsumerComplaint_Class_obj.complaintdetail = txtComplaintDetails.Text.ToString();
                    ConsumerComplaint_Class_obj.categoryid = Convert.ToInt32(cmbCategoryComplaint.SelectedValue);

                    ConsumerComplaint_Class_obj.trackcode = DtpTrackCode.Value.ToShortDateString();
                    ConsumerComplaint_Class_obj.batchno = txtBatchCode.Text.ToString();
                    ConsumerComplaint_Class_obj.pkgtechno = Convert.ToInt64(cmbPackingFamily.SelectedValue);
                    ConsumerComplaint_Class_obj.fillvolume = txtFillVolume.Text.Trim();
                    ConsumerComplaint_Class_obj.inspdate = DtpDate.Value.ToShortDateString();

                    ConsumerComplaint_Class_obj.rootcause = txtRootCause.Text.Trim();

                    if (RdoConformity.Checked == true)
                    {
                        ConsumerComplaint_Class_obj.status = Convert.ToChar("C");
                    }
                    else if (RdoNonConformity.Checked == true)
                    {
                        ConsumerComplaint_Class_obj.status = Convert.ToChar("N");
                    }
                    else if (RdoOther.Checked == true)
                    {
                        ConsumerComplaint_Class_obj.status = Convert.ToChar("O");
                    }

                    ConsumerComplaint_Class_obj.comments = txtOtherComments.Text.ToString();

                    ConsumerComplaint_Class_obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                    ConsumerComplaint_Class_obj.loginid = FrmMain.LoginID;

                    DataSet ds = new DataSet();
                    ds = ConsumerComplaint_Class_obj.SELECT_ComplaintTransaction();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ConsumerComplaint_Class_obj.transid = Convert.ToInt64(ds.Tables[0].Rows[0]["TransID"].ToString());
                        ConsumerComplaint_Class_obj.update_tblComplaintTransaction();
                    }
                    else
                    {
                        ConsumerComplaint_Class_obj.transid = ConsumerComplaint_Class_obj.Insert_tblComplaintTransaction();
                    }

                    ConsumerComplaint_Class_obj.fno = Convert.ToInt64(dgTest.Columns[e.ColumnIndex].Name);

                    DataSet dsObs = new DataSet();
                    dsObs = ConsumerComplaint_Class_obj.Select_tblComplaintObs_TransID_FNo();
                    if (dsObs.Tables[0].Rows.Count > 0)
                    {
                        ConsumerComplaint_Class_obj.obsid = Convert.ToInt64(dsObs.Tables[0].Rows[0]["ObsID"]);
                    }
                    else
                    {
                        ConsumerComplaint_Class_obj.obsid = ConsumerComplaint_Class_obj.Insert_ComplaintObs();
                    }
                    
                    FrmConsumerComplaintTest.Detail detail_Obj = new FrmConsumerComplaintTest.Detail();
 
                    if (dgTest[e.ColumnIndex, 0].Value.ToString() == "Done")
                    {
                        detail_Obj.Done = 'Y';
                    }
                    else
                    {
                        detail_Obj.Done = 'N';
                    }

                    detail_Obj.D_OdsID = ConsumerComplaint_Class_obj.obsid; 
                    detail_Obj.D_FNo = ConsumerComplaint_Class_obj.fno;
                    
                    FrmConsumerComplaintTest frm = new FrmConsumerComplaintTest(detail_Obj);
                    frm.ShowDialog();

                    DataSet dsDone = new DataSet();
                    dsDone = ConsumerComplaint_Class_obj.Select_tblComplaintPhysicoChemicalTestMethodDetails_ObsID();
                    if (dsDone.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, 0].Value = "Done";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtComplaintRefNo.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Complaint Ref No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtComplaintRefNo.Focus();
                    return;
                }
                if (DtpTrackCode.Checked == false)
                {
                    MessageBox.Show("Please Select TrackCode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DtpTrackCode.Focus();
                    return;
                }
                if (txtBatchCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Batch No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchCode.Focus();
                    return;
                }

                ConsumerComplaint_Class_obj.complaintrefno = txtComplaintRefNo.Text.ToString();
                ConsumerComplaint_Class_obj.trackcode = Convert.ToString(DtpTrackCode.Value.ToShortDateString());
                ConsumerComplaint_Class_obj.batchno = txtBatchCode.Text.Trim();

                if (MessageBox.Show("Are You sure want to delete the transaction?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    bool b = ConsumerComplaint_Class_obj.Delete_tblComplaintTransaction();
                    if (b == true)
                    {
                        MessageBox.Show("Record deleted Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnReset_Click(sender, e);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry you Can't Delete this Record", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBatchCode.Text.Trim() != "")
                {
                    DataSet ds = new DataSet();
                    ConsumerComplaint_Class_obj.batchnosearch = Convert.ToString(txtBatchCode.Text.Trim());
                    ds = ConsumerComplaint_Class_obj.Select_View_FGBulkTestDetails_BatchCode();
                    dgOldTest.DataSource = ds.Tables[0];                                          
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgOldTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex != dgOldTest.Columns["Test"].Index)
                {
                    return;
                }
                else
                {                    
                    FrmConsumerComplaintHistoryTest.DetailHistory detailHistory_Obj = new FrmConsumerComplaintHistoryTest.DetailHistory();
                    detailHistory_Obj.D_FGPhyCheNo = Convert.ToInt64(dgOldTest["FGPhyCheNo", e.RowIndex].Value);

                    FrmConsumerComplaintHistoryTest frm = new FrmConsumerComplaintHistoryTest(detailHistory_Obj);
                    frm.ShowDialog();
                }
            }
            catch 
            {
                throw;
            }
        }

       

        

       

       
    }
}