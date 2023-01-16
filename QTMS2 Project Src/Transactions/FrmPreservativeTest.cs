using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Transactions
{
    public partial class FrmPreservativeTest : Form
    {
        public FrmPreservativeTest()
        {            
            InitializeComponent();
        }

        # region Varibles       
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.PreservativeTest_Class PreservativeTest_Class_Obj = new BusinessFacade.Transactions.PreservativeTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        DateTime currentTime;
        # endregion

        private static FrmPreservativeTest frmPreservativeTest_Obj = null;
        public static FrmPreservativeTest GetInstance()
        {
            if (frmPreservativeTest_Obj == null)
            {
                frmPreservativeTest_Obj = new FrmPreservativeTest();
            }
            return frmPreservativeTest_Obj;
        }
                
        private void FrmPreservativeTest_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_Details();
            Bind_InspectedBy();
            Bind_VerifiedBy();
            cmbDetails.Focus();            
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
        }

        public void Bind_Details()
        {
            DataSet ds = new DataSet();
            DataRow dr;            
            ds = PreservativeTest_Class_Obj.Select_PendingPreservativeDetails();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.ValueMember = "FMID";
                cmbDetails.DisplayMember = "Details";
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

        public void Bind_VerifiedBy()
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

                cmbVerifiedBy.DataSource = ds.Tables[0];
                cmbVerifiedBy.DisplayMember = "UserName";
                cmbVerifiedBy.ValueMember = "UserID";
            }
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "")
                {
                    dgTest.Rows.Clear();

                    DataSet ds = new DataSet();
                    PreservativeTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                    ds = PreservativeTest_Class_Obj.Select_PreservativeDetails_FMID();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["BulkDesc"]);
                        txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);                        
                        //txtNoofBatches.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoBatches"]);

                        // Now Show Preservative in Grid
                        DataSet ds1 = new DataSet();
                        PreservativeTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                        ds1 = PreservativeTest_Class_Obj.SELECT_tblPreservativeMethodMaster_FMID();
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            dgTest.Rows.Clear();
                            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                            {
                                dgTest.Rows.Add();
                                dgTest["PresMethodNo", dgTest.Rows.Count - 1].Value = ds1.Tables[0].Rows[i]["PresMethodNo"].ToString();
                                dgTest["Prsno", dgTest.Rows.Count - 1].Value = ds1.Tables[0].Rows[i]["Prsno"].ToString();
                                dgTest["Test", dgTest.Rows.Count - 1].Value = ds1.Tables[0].Rows[i]["PresType"].ToString();
                                dgTest["Min", dgTest.Rows.Count - 1].Value = ds1.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgTest["Max", dgTest.Rows.Count - 1].Value = ds1.Tables[0].Rows[i]["NormsMax"].ToString();
                                dgTest["PresFormula", dgTest.Rows.Count - 1].Value = ds1.Tables[0].Rows[i]["PresFormula"].ToString();
                            }
                        }

                        //IF details already filled then display
                        DataSet ds2;
                        for (int i = 0; i < dgTest.Rows.Count; i++)
                        {
                            ds2 = new DataSet();
                            PreservativeTest_Class_Obj.presmethodno = Convert.ToInt64(dgTest["PresMethodNo", i].Value);
                            ds2 = PreservativeTest_Class_Obj.Select_tblPreservativeMethodDetails();
                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                dgTest["Min", i].Value = ds2.Tables[0].Rows[0]["NormsMin"].ToString();
                                dgTest["Max", i].Value = ds2.Tables[0].Rows[0]["NormsMax"].ToString();

                                //dgTest["PresFormula", i].Value = ds2.Tables[0].Rows[0]["PresFormula"].ToString();
                                dgTest["WeightSample", i].Value = ds2.Tables[0].Rows[0]["WeightSample"].ToString();
                                dgTest["WeightReference", i].Value = ds2.Tables[0].Rows[0]["WeightReference"].ToString();
                                dgTest["AreaSample", i].Value = ds2.Tables[0].Rows[0]["AreaSample"].ToString();
                                dgTest["AreaReference", i].Value = ds2.Tables[0].Rows[0]["AreaReference"].ToString();
                                dgTest["VolumeSample", i].Value = ds2.Tables[0].Rows[0]["VolumeSample"].ToString();
                                dgTest["AssayConc", i].Value = ds2.Tables[0].Rows[0]["AssayConc"].ToString();

                                dgTest["Reading", i].Value = ds2.Tables[0].Rows[0]["NormsReading"].ToString();
                            }
                        }

                        

                        DataSet ds3 = new DataSet();
                        ds3 = PreservativeTest_Class_Obj.Select_ModificationPreservativeDetails_Details();
                        PreservativeTest_Class_Obj.preservativeno = 0;
                        
                        RdoAccepted.Checked = true;

                        if (ds3.Tables[0].Rows.Count > 0)
                        {
                            PreservativeTest_Class_Obj.preservativeno = Convert.ToInt32(ds3.Tables[0].Rows[0]["PreservativeNo"]);

                            DtpInspDate.Value = Convert.ToDateTime(ds3.Tables[0].Rows[0]["InspDate"]);
                            if (ds3.Tables[0].Rows[0]["Status"].ToString() == "A")
                            {
                                RdoAccepted.Checked = true;
                            }
                            else if (ds3.Tables[0].Rows[0]["Status"].ToString() == "R")
                            {
                                RdoRejected.Checked = true;
                            }
                            else if (ds3.Tables[0].Rows[0]["Status"].ToString() == "D")
                            {
                                RdoAWD.Checked = true;
                            }
                            else if (ds3.Tables[0].Rows[0]["Status"].ToString() == "H")
                            {
                                RdoHold.Checked = true;
                            }
                            txtComment.Text = ds3.Tables[0].Rows[0]["Comments"].ToString();

                            if (ds3.Tables[0].Rows[0]["BPCNONBPC"].ToString() == "B")
                            {
                                RdoBpc.Checked = true;
                            }
                            else if (ds3.Tables[0].Rows[0]["BPCNONBPC"].ToString() == "N")
                            {
                                RdoNonBpc.Checked = true;
                            }
                            txtCommentNonBpc.Text = ds3.Tables[0].Rows[0]["NBPCommts"].ToString();

                            cmbInspectedBy.SelectedValue = Convert.ToInt64(ds3.Tables[0].Rows[0]["InspectedBy"]);
                            cmbVerifiedBy.SelectedValue = Convert.ToInt64(ds3.Tables[0].Rows[0]["VerifiedBy"]); 
                        }
                    }
                }
                else
                {
                    txtDescription.Text = "";
                    txtTechnicalFamily.Text = "";           
                    
                    dgTest.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Select Details", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                    return;
                }
                if (RdoNonBpc.Checked == true)
                {
                    if (txtCommentNonBpc.Text == "")
                    {
                        MessageBox.Show("Enter Non BPC Comment", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCommentNonBpc.Focus();
                        return;
                    }
                }
                if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbInspectedBy.Focus();
                    return;
                }
                if (cmbVerifiedBy.SelectedValue == null || cmbVerifiedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Verified By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVerifiedBy.Focus();
                    return;
                }

                //if record on hold then readings are not compulsory
                if (RdoHold.Checked != true)
                {
                    for (int i = 0; i < dgTest.Rows.Count; i++)
                    {
                        // if validity date expired of current test then reading are not compulsory
                        DataTable dt = new DataTable();
                        PreservativeTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                        PreservativeTest_Class_Obj.presno = Convert.ToInt32(dgTest["Prsno",i].Value);
                        dt = PreservativeTest_Class_Obj.Select_tblHPLCRefMgmt_FMID();
                        currentTime = Comman_Class_Obj.Select_ServerDate();
                        if (dt.Rows.Count > 0)
                        {
                            if (Convert.ToDateTime(dt.Rows[0]["DateOfValidity"]) > Convert.ToDateTime(currentTime.ToShortDateString()))
                            {
                                if (dgTest["Reading", i].Value == null || dgTest["Reading", i].Value.ToString().Trim() == "")
                                {
                                    MessageBox.Show("Fill all the Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgTest.Focus();
                                    return;
                                }
                                if (dgTest["WeightSample", i].Value == null || dgTest["WeightSample", i].Value.ToString().Trim() == "")
                                {
                                    MessageBox.Show("Fill all the Weight Sample", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgTest.Focus();
                                    return;
                                }
                                if (dgTest["WeightReference", i].Value == null || dgTest["WeightReference", i].Value.ToString().Trim() == "")
                                {
                                    MessageBox.Show("Fill all the Weight Reference", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgTest.Focus();
                                    return;
                                }
                                if (dgTest["AreaSample", i].Value == null || dgTest["AreaSample", i].Value.ToString().Trim() == "")
                                {
                                    MessageBox.Show("Fill all the Area Sample", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgTest.Focus();
                                    return;
                                }
                                if (dgTest["AreaReference", i].Value == null || dgTest["AreaReference", i].Value.ToString().Trim() == "")
                                {
                                    MessageBox.Show("Fill all the Area Reference", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgTest.Focus();
                                    return;
                                }
                                if (dgTest["VolumeSample", i].Value == null || dgTest["VolumeSample", i].Value.ToString().Trim() == "")
                                {
                                    MessageBox.Show("Fill all the Volume Sample", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgTest.Focus();
                                    return;
                                }
                                if (dgTest["AssayConc", i].Value == null || dgTest["AssayConc", i].Value.ToString().Trim() == "")
                                {
                                    MessageBox.Show("Fill all the Assay Conc", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgTest.Focus();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (dgTest["Reading", i].Value == null || dgTest["Reading", i].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Fill all the Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgTest.Focus();
                                return;
                            }
                            if (dgTest["WeightSample", i].Value == null || dgTest["WeightSample", i].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Fill all the Weight Sample", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgTest.Focus();
                                return;
                            }
                            if (dgTest["WeightReference", i].Value == null || dgTest["WeightReference", i].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Fill all the Weight Reference", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgTest.Focus();
                                return;
                            }
                            if (dgTest["AreaSample", i].Value == null || dgTest["AreaSample", i].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Fill all the Area Sample", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgTest.Focus();
                                return;
                            }
                            if (dgTest["AreaReference", i].Value == null || dgTest["AreaReference", i].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Fill all the Area Reference", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgTest.Focus();
                                return;
                            }
                            if (dgTest["VolumeSample", i].Value == null || dgTest["VolumeSample", i].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Fill all the Volume Sample", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgTest.Focus();
                                return;
                            }
                            if (dgTest["AssayConc", i].Value == null || dgTest["AssayConc", i].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Fill all the Assay Conc", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgTest.Focus();
                                return;
                            }
                        }

                        
                    }
                }
                if (RdoAccepted.Checked == true)
                {
                    if (MessageBox.Show("ACCEPT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoRejected.Checked == true)
                {
                    if (MessageBox.Show("REJECT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoHold.Checked == true)
                {
                    if (MessageBox.Show("HOLD ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
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
                PreservativeTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                PreservativeTest_Class_Obj.inspdate = DtpInspDate.Value.ToShortDateString();
                if (RdoAccepted.Checked == true)
                {
                    PreservativeTest_Class_Obj.status = Convert.ToChar("A");
                }
                else if (RdoRejected.Checked == true)
                {
                    PreservativeTest_Class_Obj.status = Convert.ToChar("R");
                }
                else if (RdoHold.Checked == true)
                {
                    PreservativeTest_Class_Obj.status = Convert.ToChar("H");
                }
                else if (RdoAWD.Checked == true)
                {
                    PreservativeTest_Class_Obj.status = Convert.ToChar("D");
                }
                PreservativeTest_Class_Obj.comments = txtComment.Text;
                if (RdoNonBpc.Checked == true)
                {
                    PreservativeTest_Class_Obj.bpcnonbpc = Convert.ToChar("N");
                    PreservativeTest_Class_Obj.nbpcomments = txtCommentNonBpc.Text;
                }
                else if (RdoBpc.Checked == true)
                {
                    PreservativeTest_Class_Obj.bpcnonbpc =Convert.ToChar("B");
                    PreservativeTest_Class_Obj.nbpcomments = "";
                }

                PreservativeTest_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);
                PreservativeTest_Class_Obj.verifiedby = Convert.ToInt32(cmbVerifiedBy.SelectedValue);

                PreservativeTest_Class_Obj.loginid = FrmMain.LoginID;

                // Insert in tblPreservative OR update if already Exists for FMID
                bool b = PreservativeTest_Class_Obj.Insert_tblPreservative();

                //Delete previous already added details
                PreservativeTest_Class_Obj.Delete_tblPreservativeMethodDetails_FMID();

                if (b == true)
                {
                    // Now insert record in tblPreservativeMethodDetails
                    for (int i = 0; i < dgTest.Rows.Count; i++)
                    {
                        PreservativeTest_Class_Obj.presmethodno = Convert.ToInt32(dgTest["PresMethodNo", i].Value);

                        if (dgTest["Min", i].Value == null)
                        {
                            PreservativeTest_Class_Obj.normsmin = "";
                        }
                        else
                        {
                            PreservativeTest_Class_Obj.normsmin = dgTest["Min", i].Value.ToString();
                        }
                        if (dgTest["Max", i].Value == null)
                        {
                            PreservativeTest_Class_Obj.normsmax = "";
                        }
                        else
                        {
                            PreservativeTest_Class_Obj.normsmax = dgTest["Max", i].Value.ToString();
                        }
                        if (dgTest["WeightSample", i].Value == null)
                        {
                            PreservativeTest_Class_Obj.weightsample = "";
                        }
                        else
                        {
                            PreservativeTest_Class_Obj.weightsample = dgTest["WeightSample", i].Value.ToString();
                        }
                        if (dgTest["WeightReference", i].Value == null)
                        {
                            PreservativeTest_Class_Obj.weightreference = "";
                        }
                        else
                        {
                            PreservativeTest_Class_Obj.weightreference = dgTest["WeightReference", i].Value.ToString();
                        }
                        if (dgTest["AreaSample", i].Value == null)
                        {
                            PreservativeTest_Class_Obj.areasample = "";
                        }
                        else
                        {
                            PreservativeTest_Class_Obj.areasample = dgTest["AreaSample", i].Value.ToString();
                        }
                        if (dgTest["AreaReference", i].Value == null)
                        {
                            PreservativeTest_Class_Obj.areareference = "";
                        }
                        else
                        {
                            PreservativeTest_Class_Obj.areareference = dgTest["AreaReference", i].Value.ToString();
                        }
                        if (dgTest["VolumeSample", i].Value == null)
                        {
                            PreservativeTest_Class_Obj.volumesample = "";
                        }
                        else
                        {
                            PreservativeTest_Class_Obj.volumesample = dgTest["VolumeSample", i].Value.ToString();
                        }
                        if (dgTest["AssayConc", i].Value == null)
                        {
                            PreservativeTest_Class_Obj.assayconc = "";
                        }
                        else
                        {
                            PreservativeTest_Class_Obj.assayconc = dgTest["AssayConc", i].Value.ToString();
                        }
                        if (dgTest["PresFormula", i].Value == null)
                        {
                            PreservativeTest_Class_Obj.presformula = "";
                        }
                        else
                        {
                            PreservativeTest_Class_Obj.presformula = dgTest["PresFormula", i].Value.ToString();
                        }
                        if (dgTest["Reading", i].Value == null)
                        {
                            PreservativeTest_Class_Obj.reading = "";
                        }
                        else
                        {
                            PreservativeTest_Class_Obj.reading = dgTest["Reading", i].Value.ToString();
                        }
                        PreservativeTest_Class_Obj.Insert_tblPreservativeMethodDetails();
                    }                    
                }                

                if (RdoHold.Checked != true)
                {
                    PreservativeTest_Class_Obj.preservativedone = true;
                    bool s = PreservativeTest_Class_Obj.Update_tblTransFM_PreservativeDone();
                    if (MessageBox.Show("Record Saved Successfully\n\nPrint Protocol?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        //display protocol
                        BtnProtocol_Click(sender, e);
                    }
                }
                else if (RdoHold.Checked == true)
                {
                    if (MessageBox.Show("Record on HOLD\n\nPrint Protocol?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        //display protocol
                        BtnProtocol_Click(sender, e);
                    }
                }
                                
                cmbDetails.Focus();
                Bind_Details();
                BtnReset_Click(sender, e);
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            cmbDetails.Text = "--Select--";
            txtTechnicalFamily.Text = "";
            txtDescription.Text = "";           
            txtComment.Text = "";
            txtCommentNonBpc.Text = "";
            cmbInspectedBy.Text = "--Select--";
            cmbVerifiedBy.Text = "--Select--";
            
            RdoAccepted.Checked = true;
            RdoBpc.Checked = true;
            dgTest.Rows.Clear();
        }

        private void RdoNonBpc_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoNonBpc.Checked == true)
            {
                txtCommentNonBpc.Enabled = true;
                txtCommentNonBpc.Focus();
            }
            else
            {
                txtCommentNonBpc.Enabled = false;
            }

        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtComment.Text = textInfo.ToTitleCase(txtComment.Text);
        }

        private void txtCommentNonBpc_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtCommentNonBpc.Text = textInfo.ToTitleCase(txtCommentNonBpc.Text);
        }

        private void dgTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgTest.CurrentCell.RowIndex < 0
            //    || (dgTest.CurrentCell.ColumnIndex != dgTest.Columns["Reading"].Index))
            //{
            //    return;
            //}
            //else if (dgTest.CurrentCell.ColumnIndex == dgTest.Columns["Reading"].Index)
            //{
            //    dgTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            //}

            if (dgTest.CurrentCell.RowIndex >= 0)
            {
                if (dgTest.CurrentCell.ColumnIndex == dgTest.Columns["Reading"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["WeightSample"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["WeightReference"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["AreaSample"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["AreaReference"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["VolumeSample"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["AssayConc"].Index)
                {
                    dgTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
                }
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

        private void dgTest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgTest.Columns["Reading"].Index)
            {
                return;
            }
            else
            {
                if (dgTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgTest["Max", dgTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgTest["Min", dgTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgTest.CurrentCell.Style.BackColor = Color.Red;
                        return;
                    }

                    if (dgTest["Max", dgTest.CurrentCell.RowIndex].Value != null && dgTest["Max", dgTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgTest["Max", dgTest.CurrentCell.RowIndex].Value))
                        {
                            dgTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgTest["Min", dgTest.CurrentCell.RowIndex].Value != null && dgTest["Min", dgTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgTest["Min", dgTest.CurrentCell.RowIndex].Value))
                        {
                            dgTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dgTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        private void dgTest_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgTest.Columns["Reading"].Index)
            {
                return;
            }
            else
            {
                for (int i = 0; i < dgTest.Rows.Count; i++)
                {
                    if (dgTest["Reading", i].Style.BackColor == Color.Red)
                    {
                        RdoRejected.Checked = true;
                        return;
                    }
                    else
                    {
                        RdoAccepted.Checked = true;
                    }
                }
            }
        }

        private void BtnProtocol_Click(object sender, EventArgs e)
        {          

            try
            {
                if (cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDetails.Focus();
                    return;
                }
                if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbInspectedBy.Focus();
                    return;
                }
                if (cmbVerifiedBy.SelectedValue == null || cmbVerifiedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Verified By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVerifiedBy.Focus();
                    return;
                }

                DataSet ds = new DataSet();
                PreservativeTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                ds = PreservativeTest_Class_Obj.Select_View_PreservativeTest_Protocol_FMID();

                string ProtocolNo = "";
                if (PreservativeTest_Class_Obj.fmid != 0)
                {
                    ProtocolNo = "PR" + PreservativeTest_Class_Obj.fmid.ToString().PadLeft(6, '0');
                }
               
                if (ds.Tables[0].Rows.Count > 0)
                {
                    QTMS.Reports_Forms.FrmPreservativeTestProtocol fm = new QTMS.Reports_Forms.FrmPreservativeTestProtocol(DtpInspDate.Value.ToShortDateString(), ds.Tables[0], ProtocolNo, cmbInspectedBy.Text.Trim(), cmbVerifiedBy.Text.Trim());
                    fm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Record is not Present", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgTest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public static double Evaluate(string expression)
        {
            try
            {
                System.Data.DataTable table = new System.Data.DataTable();
                table.Columns.Add("expression", string.Empty.GetType(), expression);
                System.Data.DataRow row = table.NewRow();
                table.Rows.Add(row);
                return Math.Round(double.Parse((string)row["expression"]), 4);
            }
            catch
            {
                MessageBox.Show("Preservative Formula is not valid..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
        }

        private void dgTest_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgTest.CurrentCell != null && dgTest.CurrentCell.RowIndex >= 0)
            {
                if (dgTest.CurrentCell.ColumnIndex == dgTest.Columns["Reading"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["WeightSample"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["WeightReference"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["AreaSample"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["AreaReference"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["VolumeSample"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["AssayConc"].Index
                         || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["PresFormula"].Index)
                {
                    if (dgTest["PresFormula", dgTest.CurrentCell.RowIndex].Value != null && dgTest["PresFormula", dgTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        string PresValue = dgTest["PresFormula", dgTest.CurrentCell.RowIndex].Value.ToString();

                        if (dgTest["WeightSample", dgTest.CurrentCell.RowIndex].Value != null && dgTest["WeightSample", dgTest.CurrentCell.RowIndex].Value.ToString() != "" &&
                            dgTest["WeightReference", dgTest.CurrentCell.RowIndex].Value != null && dgTest["WeightReference", dgTest.CurrentCell.RowIndex].Value.ToString() != "" &&
                        dgTest["AreaSample", dgTest.CurrentCell.RowIndex].Value != null && dgTest["AreaSample", dgTest.CurrentCell.RowIndex].Value.ToString() != "" &&
                        dgTest["AreaReference", dgTest.CurrentCell.RowIndex].Value != null && dgTest["AreaReference", dgTest.CurrentCell.RowIndex].Value.ToString() != "" &&
                        dgTest["VolumeSample", dgTest.CurrentCell.RowIndex].Value != null && dgTest["VolumeSample", dgTest.CurrentCell.RowIndex].Value.ToString() != "" &&
                        dgTest["AssayConc", dgTest.CurrentCell.RowIndex].Value != null && dgTest["AssayConc", dgTest.CurrentCell.RowIndex].Value.ToString() != "")
                        {

                            PresValue = PresValue.Replace("WS", dgTest["WeightSample", dgTest.CurrentCell.RowIndex].Value.ToString());
                            PresValue = PresValue.Replace("WR", dgTest["WeightReference", dgTest.CurrentCell.RowIndex].Value.ToString());
                            PresValue = PresValue.Replace("AS", dgTest["AreaSample", dgTest.CurrentCell.RowIndex].Value.ToString());
                            PresValue = PresValue.Replace("AR", dgTest["AreaReference", dgTest.CurrentCell.RowIndex].Value.ToString());
                            PresValue = PresValue.Replace("VS", dgTest["VolumeSample", dgTest.CurrentCell.RowIndex].Value.ToString());
                            PresValue = PresValue.Replace("AC", dgTest["AssayConc", dgTest.CurrentCell.RowIndex].Value.ToString());

                            dgTest["Reading", dgTest.CurrentCell.RowIndex].Value = Evaluate(PresValue);
                        }
                    }
                }              

            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check Validity date of tests for particular mfgwo - formula no
            try
            {
                DataTable dt = new DataTable();
                PreservativeTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                PreservativeTest_Class_Obj.presno = Convert.ToInt32(dgTest.CurrentRow.Cells["Prsno"].Value);
                dt = PreservativeTest_Class_Obj.Select_tblHPLCRefMgmt_FMID();
                currentTime = Comman_Class_Obj.Select_ServerDate();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToDateTime(dr["DateOfValidity"]) > Convert.ToDateTime(currentTime.ToShortDateString()))
                        {

                        }
                        else
                        {
                            dgTest.CurrentRow.ReadOnly = true;
                            MessageBox.Show("Validity Date expired of the current test", "Preservative", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgTest[dgTest.CurrentCell.ColumnIndex, dgTest.CurrentCell.RowIndex].Value = "";

                            return;
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