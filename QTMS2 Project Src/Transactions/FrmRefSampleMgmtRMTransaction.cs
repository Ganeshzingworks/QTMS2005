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
    public partial class FrmRefSampleMgmtRMTransaction : Form
    {
        public FrmRefSampleMgmtRMTransaction()
        {
            InitializeComponent();
        }
        #region Variables
        RMCodeMaster_Class RMCodeMaster_Class_Obj = new RMCodeMaster_Class();
        RSMgmtTransaction_Class RSMgmtTransaction_Class_obj = new RSMgmtTransaction_Class(); 
        #endregion

        private static FrmRefSampleMgmtRMTransaction FrmRefSampleMgmtRMTransaction_Obj = null;
        public static FrmRefSampleMgmtRMTransaction GetInstance()
        {
            if (FrmRefSampleMgmtRMTransaction_Obj == null)
            {
                FrmRefSampleMgmtRMTransaction_Obj = new Transactions.FrmRefSampleMgmtRMTransaction();
            }
            return FrmRefSampleMgmtRMTransaction_Obj;
        }

        private void FrmRefSampleMgmtRMTransaction_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_RMCode();
            Bind_Location();
            BtnReset_Click(sender, e);
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
                    cmbRetainerLocation.DataSource = ds.Tables[0];
                    cmbRetainerLocation.DisplayMember = "Location";
                    cmbRetainerLocation.ValueMember = "LocationID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void resetall()
        {
            cmbRMCode.SelectedValue = 0;
            cmbPlantLotNo.DataSource = null;
            cmbRetainerLocation.SelectedValue = 0;
            dgDetails.Rows.Clear();
            txtDesc.Text = "";
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
            try
            {
                if (IsValid())
                {
                    for (int i = 0; i < dgDetails.Rows.Count; i++)
                    {
                        if (dgDetails["RMWSID", i].Value == null)
                        {
                            RSMgmtTransaction_Class_obj.rmsamplingid = Convert.ToInt32(dgDetails["RMSamplingID", i].Value);
                            RSMgmtTransaction_Class_obj.wsvaliditydate = Convert.ToDateTime(dgDetails["ValidityDate", i].Value);
                            //RSMgmtTransaction_Class_obj.locid = Convert.ToInt64(dgDetails["RetainerLocID", i].Value);
                            RSMgmtTransaction_Class_obj.supplierid = Convert.ToInt32(dgDetails["SupplierID", i].Value);
                            RSMgmtTransaction_Class_obj.Insert_tblRMRSWorkingStandardDetails();
                        }
                    }

                    MessageBox.Show("Record saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BtnReset_Click(sender, e);
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


        private void Select_RMRSDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                RSMgmtTransaction_Class_obj.rmcodeid = Convert.ToInt64(cmbRMCode.SelectedValue);
                dt = RSMgmtTransaction_Class_obj.Select_RMRSMgmtDetails_RMCodeID();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgDetails.Rows.Add();
                        dgDetails["RMWSID", dgDetails.Rows.Count - 1].Value = Convert.ToString(dr["RMWSID"]);
                        dgDetails["RMCode", dgDetails.Rows.Count - 1].Value = Convert.ToString(dr["RMCode"]);
                        dgDetails["SupplierName", dgDetails.Rows.Count - 1].Value = Convert.ToString(dr["RMSupplierName"]);
                        dgDetails["PlantLotNo", dgDetails.Rows.Count - 1].Value = Convert.ToString(dr["PlantLotNo"]);
                        //dgDetails["RetainerLocation", dgDetails.Rows.Count - 1].Value = Convert.ToString(dr["Location"]);
                        dgDetails["ValidityDate", dgDetails.Rows.Count - 1].Value = Convert.ToString(dr["ValidityDate"]);
                        dgDetails["AnalysisReport", dgDetails.Rows.Count - 1].Value = "Analysis Report";
                        dgDetails["Delete", dgDetails.Rows.Count - 1].Value = "Delete";
                        dgDetails["RMSamplingID", dgDetails.Rows.Count - 1].Value = Convert.ToString(dr["RMSamplingID"]);
                        //dgDetails["RetainerLocID", dgDetails.Rows.Count - 1].Value = Convert.ToString(dr["LocationID"]);
                        dgDetails["SupplierID", dgDetails.Rows.Count - 1].Value = Convert.ToString(dr["RMSupplierID"]);

                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

       

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    if (cmbPlantLotNo.SelectedValue == null || cmbPlantLotNo.SelectedValue.ToString() == "")
                    {
                        MessageBox.Show("Select Plant Lot No...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        cmbPlantLotNo.Focus();
                    }
                    else
                    {
                        for (int i = 0; i < dgDetails.Rows.Count; i++)
                        {
                            //ckech whether tank already exists
                            if (dgDetails["PlantLotNo", i].Value != null)
                            {
                                if (dgDetails["PlantLotNo", i].Value.ToString() == cmbPlantLotNo.Text.Trim())
                                {
                                    MessageBox.Show("This Plant Lot No already Exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                                    cmbPlantLotNo.Focus();
                                    return;
                                }
                            }
                        }
                        dgDetails.Rows.Add();
                        dgDetails["RMCode", dgDetails.Rows.Count - 1].Value = cmbRMCode.Text.Trim();
                        dgDetails["SupplierName", dgDetails.Rows.Count - 1].Value = RSMgmtTransaction_Class_obj.suppliername;
                        dgDetails["PlantLotNo", dgDetails.Rows.Count - 1].Value = cmbPlantLotNo.Text.Trim();
                        //dgDetails["RetainerLocation", dgDetails.Rows.Count - 1].Value = cmbRetainerLocation.Text.Trim();
                        dgDetails["ValidityDate", dgDetails.Rows.Count - 1].Value = DtpWSValidityDate.Value.ToString();
                        dgDetails["AnalysisReport", dgDetails.Rows.Count - 1].Value = "Analysis Report";
                        dgDetails["Delete", dgDetails.Rows.Count - 1].Value = "Delete";
                        dgDetails["RMSamplingID", dgDetails.Rows.Count - 1].Value = Convert.ToString(cmbPlantLotNo.SelectedValue);
                        //dgDetails["RetainerLocID", dgDetails.Rows.Count - 1].Value = Convert.ToString(cmbRetainerLocation.SelectedValue);
                        dgDetails["SupplierID", dgDetails.Rows.Count - 1].Value = RSMgmtTransaction_Class_obj.supplierid;
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
            if (cmbRMCode.Text.Trim() == "--Select--" || cmbRMCode.SelectedValue == null)
            {
                MessageBox.Show("Select RM Code...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                cmbRMCode.Focus();
                return false;
            }
            if (cmbPlantLotNo.SelectedValue == null || cmbPlantLotNo.Text.Trim() == "" || cmbPlantLotNo.Text.Trim() == "--Select--")
            {
                MessageBox.Show("Select Plant Lot No...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                cmbPlantLotNo.Focus();
                return false;
            }
            //if (cmbRetainerLocation.Text.Trim() == "--Select--" || cmbRetainerLocation.SelectedValue == null)
            //{
            //    MessageBox.Show("Select Retainer Location...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
            //    cmbRetainerLocation.Focus();
            //    return false;
            //}
            return true;
        }

        private void dgWSDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    
                }
                if (e.ColumnIndex == 6)
                {
                    int rmsamplingid = Convert.ToInt32(dgDetails.CurrentRow.Cells["RMSamplingID"].Value);

                    QTMS.Reports_Forms.FrmRefAnalysis_Report frm = new QTMS.Reports_Forms.FrmRefAnalysis_Report("RM_Analysis", rmsamplingid);
                    frm.ShowDialog();
                }
                if (e.ColumnIndex == 7)
                {
                    if (MessageBox.Show("Do you really want to delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (dgDetails.CurrentRow.Cells["RMWSID"].Value != null)
                        {
                            RSMgmtTransaction_Class_obj.rmwsid = Convert.ToInt64(dgDetails.CurrentRow.Cells["RMWSID"].Value);
                            bool b = RSMgmtTransaction_Class_obj.Delete_RMRSWorkingStanardDetails();
                            if (b == true)
                            {
                                MessageBox.Show("Record removed successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
//                                cmbFormulaNo_SelectionChangeCommitted(sender, e);
                            }
                        }
                        else
                            dgDetails.RowCount = dgDetails.RowCount - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
    

        private void cmbRMCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbPlantLotNo.DataSource = null;
                cmbRetainerLocation.SelectedValue = 0;
                txtDesc.Text = "";
                dgDetails.Rows.Clear();
                if (cmbRMCode.SelectedValue != null)
                {
                    DataTable dt = new DataTable();
                    RSMgmtTransaction_Class_obj.rmcodeid = Convert.ToInt32(cmbRMCode.SelectedValue);
                    dt = RSMgmtTransaction_Class_obj.Select_tblRMCode_RMCodeID();
                    if (dt.Rows.Count > 0)
                        txtDesc.Text = Convert.ToString(dt.Rows[0]["RMINCIName"]);
                    dt = null;
                    dt = RSMgmtTransaction_Class_obj.Select_tblRMSampling_RMCodeID();
                    DataRow dr = dt.NewRow();
                    dr["PlantLotNo"] = "--Select--";
                    dr["RMSamplingID"] = "0";
                    dt.Rows.InsertAt(dr, 0);
                    if (dt.Rows.Count > 0)
                    {
                        cmbPlantLotNo.DataSource = dt;
                        cmbPlantLotNo.DisplayMember = "PlantLotNo";
                        cmbPlantLotNo.ValueMember = "RMSamplingID";
                    }
                    else
                    {
                        cmbPlantLotNo.DataSource = null;
                    }
                    Select_RMRSDetails();//check working standard details data exist if exist then show data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void cmbPlantLotNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbPlantLotNo.SelectedValue != null )
                {
                    DataTable dt = new DataTable();
                    RSMgmtTransaction_Class_obj.rmsamplingid = Convert.ToInt32(cmbPlantLotNo.SelectedValue);
                    dt = RSMgmtTransaction_Class_obj.Select_tblRMDetails_RMSamplingID();
                    if (dt.Rows.Count > 0)
                    {
                        DtpWSValidityDate.Value = Convert.ToDateTime(dt.Rows[0]["ValidityDate"]);//Convert.ToDateTime(dt.Rows[0]["InspDate"]).AddYears(1).AddDays(-1);
                        RSMgmtTransaction_Class_obj.suppliername = Convert.ToString(dt.Rows[0]["RMSupplierName"]);
                        RSMgmtTransaction_Class_obj.supplierid = Convert.ToInt32(dt.Rows[0]["RMSupplierID"]);
                    }
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