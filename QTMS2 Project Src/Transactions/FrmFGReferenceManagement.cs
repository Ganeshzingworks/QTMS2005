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
    public partial class FrmFGReferenceManagement : Form
    {
        public FrmFGReferenceManagement()
        {
            InitializeComponent();
        }
        #region Variables
        Comman_Class Comman_Class_obj = new Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        FGRefMgmtTransaction FGRefMgmtTransaction_obj = new FGRefMgmtTransaction();
        static bool icheck = false;
        #endregion

        private static FrmFGReferenceManagement FrmFGReferenceManagement_Obj = null;
        public static FrmFGReferenceManagement GetInstance()
        {
            if (FrmFGReferenceManagement_Obj == null)
            {
                FrmFGReferenceManagement_Obj = new Transactions.FrmFGReferenceManagement();
            }
            return FrmFGReferenceManagement_Obj;
        }

        private void FrmFGReferenceManagement_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            Bind_Details();

            // DtpTrackCode.CustomFormat = "";

        }
        //Binds the pending Finished good details those entered in 
        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = FinishedGoodTest_Class_Obj.Select_FGCode_FGRefMgt();
                dr = ds.Tables[0].NewRow();
                dr["FGCode"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "FGCode";
                cmbDetails.ValueMember = "FGNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_TrackCode()
        {
            try
            {
                if (cmbDetails.SelectedValue.ToString() != "" && Convert.ToInt64(cmbDetails.SelectedValue)>0)
                {
                    DataSet ds = new DataSet();
                    DataRow dr;
                    FinishedGoodTest_Class_Obj.fgno = Convert.ToInt64(cmbDetails.SelectedValue);
                    ds = FinishedGoodTest_Class_Obj.Select_TrackCode_FGRefMgt();
                    dr = ds.Tables[0].NewRow();
                    dr["TrackCodeFG"] = "--Select--";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    cmbTrackCode.DataSource = ds.Tables[0];
                    cmbTrackCode.DisplayMember = "TrackCodeFG";
                    cmbTrackCode.ValueMember = "FGTLFID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Reset()
        {
            txtFGDesc.Text = "";
            txtPkgFamily.Text = "";
            txtControltype.Text = "";
            DtpTrackCode.CustomFormat = " ";
            dtpValidityDate.CustomFormat = " ";
        }

        /// <summary>
        /// Selection change commited event for Details combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //Reset();
                if (cmbDetails.SelectedIndex == 0 && cmbDetails.SelectedValue == null)
                { cmbTrackCode.DataSource = null; }
                else
                {
                    Bind_TrackCode();
                    BindGrid();
                    DataSet ds = new DataSet();
                    FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
                    FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                    ds = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFgMaster_FGNo();

                    
                    txtFGDesc.Text = ds.Tables[0].Rows[0]["FGDesc"].ToString();
                    //txtFillVolume.Text = ds.Tables[0].Rows[0]["FillVolume"].ToString();

                    //PackingFamilyMaster_Class_Obj.pkgtechno = Convert.ToInt64(ds.Tables[0].Rows[0]["PKGTechNo"]);
                    //cmbTechnicalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["PkgTechNo"]);

                    //if (ds.Tables[0].Rows[0]["FGGlobalFamilyID"] is System.DBNull)
                    //{
                    //    cmbFGGlobalFamily.SelectedValue = 0;
                    //}
                    //else
                    //{
                    //    cmbFGGlobalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["FGGlobalFamilyID"]);
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BindGrid()
        {
            if (cmbDetails.SelectedValue.ToString() != "" && Convert.ToInt64(cmbDetails.SelectedValue) > 0)
            {
                dgDetails.Rows.Clear();
                if (cmbDetails.SelectedValue != DBNull.Value)
                    FGRefMgmtTransaction_obj.fgno = Convert.ToInt64(cmbDetails.SelectedValue);
                DataTable dtFGRefDetails = FGRefMgmtTransaction_obj.Select_FGRefMgmtTransactionFGCode_Details();
                foreach (DataRow drFGRefId in dtFGRefDetails.Rows)
                {
                    dgDetails.Rows.Add();
                    dgDetails["FGRefMgmtId", dgDetails.Rows.Count - 1].Value = Convert.ToString(drFGRefId["FGRefMgmtId"]);
                    dgDetails["FGNo", dgDetails.Rows.Count - 1].Value = Convert.ToString(drFGRefId["FGNo"]);
                    //cmbDetails.SelectedValue = Convert.ToInt64(dgDetails["FGNo", dgDetails.Rows.Count - 1].Value);
                    //FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
                    //DataSet ds = new DataSet();
                    //FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(cmbDetails.SelectedValue);
                    //ds = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFgMaster_FGNo();

                    dgDetails["FGCode", dgDetails.Rows.Count - 1].Value = Convert.ToString(drFGRefId["FGCode"]);
                    dgDetails["TrackCode", dgDetails.Rows.Count - 1].Value = Convert.ToDateTime(drFGRefId["TrackCodeDate"]).ToString("MM/dd/yyyy");
                    dgDetails["ValidityDate", dgDetails.Rows.Count - 1].Value = Convert.ToDateTime(drFGRefId["ValidityDate"]).ToString("MM/dd/yyyy");
                }
            }
            else
                dgDetails.Rows.Clear();
        }
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
            cmbDetails.SelectedIndex = 0;
            dgDetails.Rows.Clear();
            cmbTrackCode.DataSource = null;

        }
        private bool Valid()
        {
            if (Convert.ToInt64(cmbDetails.SelectedValue) == 0)
            {
                MessageBox.Show("Please Select FGCode - Track Code - Line No", "FG Ref Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbDetails.Focus();
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedIndex != 0 && cmbDetails.SelectedValue != null)
                {
                    if (cmbTrackCode.SelectedIndex != 0 && cmbTrackCode.SelectedValue != null)
                    {
                        if (dgDetails.Rows.Count > 0)
                        {
                            bool flag = false;
                            for (int i = 0; i < dgDetails.Rows.Count; i++)
                            {

                                if (dgDetails["FGRefMgmtId", i].Value == null)
                                {

                                    FGRefMgmtTransaction_obj.fgno = Convert.ToInt64(dgDetails["FGNo", i].Value);
                                    FGRefMgmtTransaction_obj.trackCodeDate = Convert.ToDateTime(dgDetails["TrackCode", i].Value);
                                    FGRefMgmtTransaction_obj.validityDate = Convert.ToDateTime(dgDetails["ValidityDate", i].Value);
                                    flag = FGRefMgmtTransaction_obj.Insert_FGRefMgmtTransactionFGCode();
                                }
                            }
                            if (flag == true)
                            {
                                MessageBox.Show("Record Saved Successfully.", "FG Ref Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnReset_Click(sender, e);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Add Details of FG Code", "FG Ref Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Track Code", "FG Ref Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbTrackCode.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select FG Code", "FG Ref Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DtpTrackCode_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DtpTrackCode.CustomFormat = "dd-MMM-yyyy";
                ////dtpValidityDate.CustomFormat = "dd-MMM-yyyy"; 

                //if (cmbDetails.SelectedValue != DBNull.Value)
                //{

                //}
                //else
                //{
                //    dtpValidityDate.Value = DtpTrackCode.Value.AddYears(1).AddDays(-1);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dtpValidityDate_ValueChanged(object sender, EventArgs e)
        {
            dtpValidityDate.CustomFormat = "dd-MMM-yyyy";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtFGDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTrackCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "" && cmbTrackCode.SelectedIndex != 0)
                {
                    //DtpTrackCode.CustomFormat = "dd-MMM-yyyy";
                    dtpValidityDate.CustomFormat = "dd-MMM-yyyy";
                    FinishedGoodTest_Class_Obj.fgtlfid = Convert.ToInt64(cmbTrackCode.SelectedValue.ToString());

                    //Select FGdetails from fgno 
                    DataSet dsFG = new DataSet();
                    dsFG = FinishedGoodTest_Class_Obj.Select_FinishedGood_FGDetails();
                    if (dsFG.Tables[0].Rows.Count > 0)
                    {
                        txtFGDesc.Text = dsFG.Tables[0].Rows[0]["FGDesc"].ToString();
                        txtPkgFamily.Text = dsFG.Tables[0].Rows[0]["TechFamDesc"].ToString();
                        FinishedGoodTest_Class_Obj.fgno = Convert.ToInt64(dsFG.Tables[0].Rows[0]["FGNo"]);
                        FinishedGoodTest_Class_Obj.pkgtechno = Convert.ToInt64(dsFG.Tables[0].Rows[0]["PKGTechNo"]);
                        FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dsFG.Tables[0].Rows[0]["LNoFG"]);

                        DtpTrackCode.Value = Convert.ToDateTime(dsFG.Tables[0].Rows[0]["TrackCodeFG"]);
                        //get the current version no which need to dislay on report
                        if (dsFG.Tables[0].Rows[0]["VersionNo"] is System.DBNull)
                        {
                            FinishedGoodTest_Class_Obj.versionno = "";
                        }
                        else
                        {
                            FinishedGoodTest_Class_Obj.versionno = dsFG.Tables[0].Rows[0]["VersionNo"].ToString();
                        }
                    }


                    //GET CONTROL TYPE FROM STP_Decide_ControlType STORED PROCEDURE
                    //2/5 LOGIC
                    txtControltype.Text = FinishedGoodTest_Class_Obj.Decide_ControlType_FG();
                    FinishedGoodTest_Class_Obj.type = txtControltype.Text.Trim();


                    // If validity data already exist show by database else show valdity one year greater than track code
                    DataTable dt = new DataTable();
                    FGRefMgmtTransaction_obj.fgno = Convert.ToInt64(cmbDetails.SelectedValue);
                    dt = FGRefMgmtTransaction_obj.Select_FGRefMgmtTransactionFGCode();

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            dtpValidityDate.Value = Convert.ToDateTime(dr["ValidityDate"]);
                        }
                    }
                    else
                    {
                        dtpValidityDate.Value = DtpTrackCode.Value.AddYears(1).AddDays(-1);
                    }

                    //if (icheck == false)
                    //{
                    //    //icheck = true;
                    //    if (cmbDetails.SelectedValue != DBNull.Value)
                    //        FGRefMgmtTransaction_obj.fgno = Convert.ToInt64(cmbDetails.SelectedValue);
                    //    DataTable dtFGRefDetails = FGRefMgmtTransaction_obj.Select_FGRefMgmtTransactionFGCode_Details();
                    //    foreach (DataRow drFGRefId in dtFGRefDetails.Rows)
                    //    {
                    //        dgDetails.Rows.Add();
                    //        //dgDetails["FGRefMgmtId", dgDetails.Rows.Count - 1].Value = Convert.ToString(drFGRefId["FGRefMgmtId"]);
                    //        dgDetails["FGNo", dgDetails.Rows.Count - 1].Value = Convert.ToString(drFGRefId["FGNo"]);
                    //        cmbDetails.SelectedValue = Convert.ToInt64(dgDetails["FGNo", dgDetails.Rows.Count - 1].Value);
                    //        dgDetails["FGCode", dgDetails.Rows.Count - 1].Value = cmbDetails.Text;
                    //        dgDetails["TrackCode", dgDetails.Rows.Count - 1].Value = Convert.ToDateTime(drFGRefId["TrackCodeDate"]).ToString("MM/dd/yyyy");
                    //        dgDetails["ValidityDate", dgDetails.Rows.Count - 1].Value = Convert.ToDateTime(drFGRefId["ValidityDate"]).ToString("MM/dd/yyyy");
                    //    }
                    //    icheck = true;
                    //}
                }
                else
                {
                    //Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbDetails.SelectedIndex != 0 && cmbDetails.SelectedValue != null)
            {
                if (cmbTrackCode.SelectedIndex != 0 && cmbTrackCode.SelectedValue != null)
                {
                    for (int i = 0; i < dgDetails.Rows.Count; i++)
                    {
                        //ckech whether tank already exists
                        if (dgDetails["TrackCode", i].Value != null)
                        {
                            if (dgDetails["TrackCode", i].Value.ToString() == cmbTrackCode.Text.Trim())
                            {
                                MessageBox.Show("This Track Code already Exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                                cmbDetails.Focus();
                                return;
                            }
                        }
                    }


                    //dgDetails.Rows.Clear();
                    //int srNo = 0;
                    dgDetails.Rows.Add();
                    //srNo = srNo + 1;
                    //dgDetails["FGRefMgmtId", dgDetails.Rows.Count - 1].Value = Convert.ToString(srNo);
                    dgDetails["FGNo", dgDetails.Rows.Count - 1].Value = cmbDetails.SelectedValue;
                    dgDetails["FGCode", dgDetails.Rows.Count - 1].Value = cmbDetails.Text;
                    dgDetails["TrackCode", dgDetails.Rows.Count - 1].Value = cmbTrackCode.Text;
                    dgDetails["ValidityDate", dgDetails.Rows.Count - 1].Value = dtpValidityDate.Value.ToString("MM/dd/yyyy");
                    //Reset();
                }
                else
                {
                    MessageBox.Show("Please Select Track Code", "FG Ref Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbTrackCode.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Select FG Code", "FG Ref Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbDetails.Focus();
            }
        }

    }

}