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
using QTMS.Forms;

namespace QTMS.Transactions
{
    public partial class FrmRSManagement : Form
    {

        public FrmRSManagement()
        {
            InitializeComponent();
        }
        #region Variables
        Comman_Class Comman_Class_obj = new Comman_Class();
        RSMgmtTransaction_Class RSMgmtTransaction_Class_obj = new RSMgmtTransaction_Class(); 
        PMTransaction_Class PMTransaction_Class_obj = new PMTransaction_Class();
        #endregion

        private static FrmRSManagement frmRSManagement_Obj = null;
        public static FrmRSManagement GetInstance()
        {
            if (frmRSManagement_Obj == null)
            {
                frmRSManagement_Obj = new Transactions.FrmRSManagement();
            }
            return frmRSManagement_Obj;
        }

        private void FrmRSManagement_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            DtpValidityDate.Value = DtpReceivingDate.Value.AddYears(1).AddDays(-1);
            Bind_FormulaNo();
            Bind_Country();
            Bind_RefLocation();
            BtnReset_Click(sender, e);
        }

        public void resetall()
        {
            cmbFormulaNo.SelectedValue = 0;
            cmbWSmfgwo.DataSource = null;
            txtDesc.Text = "";
            txtFIFormulaNo.Text = "";
            txtMfgWo.Text = "";
            txtPFLot.Text = "";
            dgWSDetails.Rows.Clear();
          
            //cmbCountry.SelectedValue = 0;
            //cmbRefLocation.SelectedValue = 0;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //cmbFormulaNo.Text = "--Select--";            
            resetall();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connectionstring"]);

            try
            {

                if (IsValid())
                {
                    RSMgmtTransaction_Class_obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                    RSMgmtTransaction_Class_obj.formulano = txtFIFormulaNo.Text.Trim();
                    RSMgmtTransaction_Class_obj.mfgwo = txtMfgWo.Text.Trim();
                    RSMgmtTransaction_Class_obj.receivingdate = DtpReceivingDate.Value;
                    RSMgmtTransaction_Class_obj.countryid = Convert.ToInt64(cmbCountry.SelectedValue);
                    RSMgmtTransaction_Class_obj.pflot = txtPFLot.Text.Trim();
                    RSMgmtTransaction_Class_obj.validitydate = DtpValidityDate.Value;

                    // Using SQL TRansaction for commit & rollback
                    con.Open();

                    RSMgmtTransaction_Class_obj.trans = con.BeginTransaction();

                    //RSMgmtTransaction_Class_obj.locid = Convert.ToInt64(cmbRefLocation.SelectedValue);
                    RSMgmtTransaction_Class_obj.rsid = RSMgmtTransaction_Class_obj.Insert_tblRSDetails_tblRSFirstIndRun_fno(); // Insert values in tblRSDetails & tblRSFirstIndRun & get rsid
                    if (RSMgmtTransaction_Class_obj.rsid != 0)
                    {
                        for (int i = 0; i < dgWSDetails.Rows.Count; i++)
                        {
                            if (dgWSDetails["WSID", i].Value == null)
                            {
                                RSMgmtTransaction_Class_obj.fmid = Convert.ToInt64(dgWSDetails["FMID", i].Value);
                                RSMgmtTransaction_Class_obj.wsvaliditydate = Convert.ToDateTime(dgWSDetails["ValidityDate", i].Value);
                                RSMgmtTransaction_Class_obj.locid =  Convert.ToInt64(dgWSDetails["LocID", i].Value);
                                RSMgmtTransaction_Class_obj.Insert_tblRSWorkingStandardDetails();
                            }
                        }
                        if (dgWSDetails.Rows.Count > 0)
                        {
                            // update Reference date = validity date in tbl bulk master 
                            RSMgmtTransaction_Class_obj.validitydate = Convert.ToDateTime(dgWSDetails["ValidityDate", dgWSDetails.Rows.Count - 1].Value); // assign last validity date 
                            RSMgmtTransaction_Class_obj.Update_tblBulkMaster_FNo();
                        }
                        MessageBox.Show("Record saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    RSMgmtTransaction_Class_obj.trans.Commit();
                    BtnReset_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                RSMgmtTransaction_Class_obj.trans.Rollback();
                MessageBox.Show(ex.Message);
                BtnReset_Click(sender, e);
            }
            finally
            {
                con.Close();
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Bind_FormulaNo()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = RSMgmtTransaction_Class_obj.select_TblBulkMaster();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        public void Bind_Country()
        {
            try
            {
                CountryMaster_Class CountryMaster_Class_obj = new CountryMaster_Class();
                DataTable Dt = new DataTable();
                Dt = CountryMaster_Class_obj.Select_CountryMaster();

                cmbCountry.DataSource = Dt;
                cmbCountry.DisplayMember = "Country";
                cmbCountry.ValueMember = "CountryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        public void Bind_RefLocation()
        {
            try
            {
                LocationMaster_Class LocationMaster_Class_obj = new LocationMaster_Class();
                DataTable Dt = new DataTable();
                Dt = LocationMaster_Class_obj.Select_LocationMaster();

                cmbRefLocation.DataSource = Dt;
                cmbRefLocation.DisplayMember = "Location";
                cmbRefLocation.ValueMember = "LocID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        private void cmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbWSmfgwo.DataSource = null;
                txtDesc.Text = "";
                txtFIFormulaNo.Text = "";
                txtMfgWo.Text = "";
                txtPFLot.Text = "";
                dgWSDetails.Rows.Clear();
                if (cmbFormulaNo.SelectedValue != null && Convert.ToString(cmbFormulaNo.SelectedValue) != "0")
                {
                    DataSet ds = new DataSet();
                    RSMgmtTransaction_Class_obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                    ds = RSMgmtTransaction_Class_obj.select_tblBulkMaster_FNo();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);
                    }

                    BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
                    ds = null;
                    BulktestDetailstransaction_Class_Qbj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                    ds = BulktestDetailstransaction_Class_Qbj.Select_tblTransFM_MfgWo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cmbWSmfgwo.DataSource = ds.Tables[0];
                        cmbWSmfgwo.DisplayMember = "MfgWo";
                        cmbWSmfgwo.ValueMember = "FMID";
                    }
                    else
                    {
                        cmbWSmfgwo.DataSource = null;
                    }
                    Select_RSDetails();//check first industrial run & working standard details data exist if exist then show data
                }
                else
                {
                    cmbWSmfgwo.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Select_RSDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                RSMgmtTransaction_Class_obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                ds = RSMgmtTransaction_Class_obj.Select_RSMgmtDetails_Fno();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFIFormulaNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FormulaNo"]);
                    txtMfgWo.Text = Convert.ToString(ds.Tables[0].Rows[0]["MfgWo"]);
                    DtpReceivingDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReceivingDate"]);
                    cmbCountry.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["CountryID"]);
                    txtPFLot.Text = Convert.ToString(ds.Tables[0].Rows[0]["PFLot"]);
                    //cmbRefLocation.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["LocID"]);
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        dgWSDetails.Rows.Add();
                        dgWSDetails["WSID", dgWSDetails.Rows.Count - 1].Value = Convert.ToString(dr["WSID"]);
                        dgWSDetails["FormulaNo", dgWSDetails.Rows.Count - 1].Value = Convert.ToString(dr["FormulaNo"]);
                        dgWSDetails["MfgWo", dgWSDetails.Rows.Count - 1].Value = Convert.ToString(dr["MfgWo"]);
                        dgWSDetails["RefLocation", dgWSDetails.Rows.Count - 1].Value = Convert.ToString(dr["Location"]);//cmbRefLocation.Text.Trim();
                        dgWSDetails["ValidityDate", dgWSDetails.Rows.Count - 1].Value = Convert.ToDateTime(dr["ValidityDate"]).ToShortDateString();
                        dgWSDetails["AnalysisReport", dgWSDetails.Rows.Count - 1].Value = "Analysis Report";
                        dgWSDetails["Delete", dgWSDetails.Rows.Count - 1].Value = "Delete";
                        dgWSDetails["FMID", dgWSDetails.Rows.Count - 1].Value = Convert.ToString(dr["FMID"]);
                        dgWSDetails["LocID", dgWSDetails.Rows.Count - 1].Value = Convert.ToString(dr["LocID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void DtpReceivingDate_ValueChanged(object sender, EventArgs e)
        {
            DtpValidityDate.Value = DtpReceivingDate.Value.AddYears(1).AddDays(-1);
        }

        private void cmbWSmfgwo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    DataSet ds = new DataSet();
            //    BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
            //    BulktestDetailstransaction_Class_Qbj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
            //    BulktestDetailstransaction_Class_Qbj.mfgwo = cmbWSmfgwo.Text.Trim();
            //    ds = BulktestDetailstransaction_Class_Qbj.Select_tblBulkTestTransaction_FNo_MfgWo();
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        DtpWSValidityDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ValidDate"]);
            //    }
                 
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    //throw;
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    if (cmbWSmfgwo.SelectedValue == null || cmbWSmfgwo.SelectedValue.ToString() == "")
                    {
                        MessageBox.Show("Select manufacturing work order...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        cmbWSmfgwo.Focus();
                    }
                    else
                    {
                        for (int i = 0; i < dgWSDetails.Rows.Count; i++)
                        {
                            //ckech whether tank already exists
                            if (dgWSDetails["MfgWo", i].Value != null)
                            {
                                if (dgWSDetails["MfgWo", i].Value.ToString() == cmbWSmfgwo.Text.Trim())
                                {
                                    MessageBox.Show("This mfgwo already Exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                                    cmbWSmfgwo.Focus();
                                    return;
                                }
                            }
                        }
                        dgWSDetails.Rows.Add();
                        dgWSDetails["FormulaNo", dgWSDetails.Rows.Count - 1].Value = cmbFormulaNo.Text.Trim();
                        dgWSDetails["MfgWo", dgWSDetails.Rows.Count - 1].Value = cmbWSmfgwo.Text.Trim();
                        dgWSDetails["RefLocation", dgWSDetails.Rows.Count - 1].Value = cmbRefLocation.Text.Trim();
                        dgWSDetails["ValidityDate", dgWSDetails.Rows.Count - 1].Value = DtpWSValidityDate.Value.ToString();
                        dgWSDetails["AnalysisReport", dgWSDetails.Rows.Count - 1].Value = "Analysis Report";
                        dgWSDetails["Delete", dgWSDetails.Rows.Count - 1].Value = "Delete";
                        dgWSDetails["FMID", dgWSDetails.Rows.Count - 1].Value = Convert.ToString(cmbWSmfgwo.SelectedValue);
                        dgWSDetails["LocID", dgWSDetails.Rows.Count - 1].Value = Convert.ToString(cmbRefLocation.SelectedValue);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        private bool IsValid()
        {
            if (cmbFormulaNo.Text.Trim() == "--Select--" || cmbFormulaNo.SelectedValue == null)
            {
                MessageBox.Show("Select Formula...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                cmbFormulaNo.Focus();
                return false;
            }
            //if (cmbWSmfgwo.SelectedValue == null || cmbWSmfgwo.SelectedValue.ToString() == "")
            //{
            //    MessageBox.Show("Select manufacturing work order...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
            //    cmbWSmfgwo.Focus();
            //    return false;
            //}
            if (txtFIFormulaNo.Text.Trim() == "")
            {
                MessageBox.Show("Enter Formula...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtFIFormulaNo.Focus();
                return false;
            }
            if (txtMfgWo.Text.Trim() == "")
            {
                MessageBox.Show("Enter mfgwo ", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtMfgWo.Focus();
                return false;
            }
            if (DtpReceivingDate.Value == null)
            {
                //MessageBox.Show("Please enter date", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                MessageBox.Show("Please enter date", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                DtpReceivingDate.Focus();
                return false;                
            }
            if (cmbCountry.SelectedValue == null || cmbCountry.Text.Trim() == "")
            {
                MessageBox.Show("Select Country...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                cmbCountry.Focus();
                return false;
            }
            if (cmbRefLocation.SelectedValue.ToString() == null || cmbRefLocation.Text.Trim() == "")
            {
                MessageBox.Show("Select Reference Location...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                cmbRefLocation.Focus();
                return false;
            }
            if (txtPFLot.Text.Trim() == "")
            {
                MessageBox.Show("Enter PF Lot Number...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                txtPFLot.Focus();
                return false;
            }

            return true;
        }

        private void dgWSDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    //long fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                    //long fmid = Convert.ToInt64(dgWSDetails.CurrentRow.Cells["FMID"].Value);
                    //int locid = Convert.ToInt32(dgWSDetails.CurrentRow.Cells["LocID"].Value);
                    //DateTime dt = Convert.ToDateTime(dgWSDetails.CurrentRow.Cells["ValidityDate"].Value);
                    //FrmRSWorkingStandardDetails frm = new FrmRSWorkingStandardDetails(fno,fmid,locid,dt);
                    //frm.ShowDialog();
                }
                if (e.ColumnIndex == 5)
                {
                    long fmid = Convert.ToInt64(dgWSDetails.CurrentRow.Cells["FMID"].Value);
                    
                    QTMS.Reports_Forms.FrmRefAnalysis_Report frm = new QTMS.Reports_Forms.FrmRefAnalysis_Report("BulkAnalysis",fmid);
                    frm.ShowDialog();
                }
                if (e.ColumnIndex == 6)
                {
                    if (MessageBox.Show("Do you really want to delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (dgWSDetails.CurrentRow.Cells["WSID"].Value != null)
                        {
                            RSMgmtTransaction_Class_obj.wsid = Convert.ToInt64(dgWSDetails.CurrentRow.Cells["WSID"].Value);
                            bool b = RSMgmtTransaction_Class_obj.Delete_RSWorkingStanardDetails();
                            if (b == true)
                            {
                                MessageBox.Show("Record removed successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                                cmbFormulaNo_SelectionChangeCommitted(sender, e);
                            }
                        }
                        else
                            dgWSDetails.RowCount = dgWSDetails.RowCount - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void cmbWSmfgwo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
                BulktestDetailstransaction_Class_Qbj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                BulktestDetailstransaction_Class_Qbj.mfgwo = cmbWSmfgwo.Text.Trim();
                ds = BulktestDetailstransaction_Class_Qbj.Select_tblBulkTestTransaction_FNo_MfgWo();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DtpWSValidityDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspDate"]).AddYears(1).AddDays(-1);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }


    }


}