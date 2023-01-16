/********************************************************
*Author:Manish K 
*Date: 
*Description: 
*Revision:
********************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;
using BusinessFacade.Transactions;
using BusinessFacade.Scoop_Class;
using System.Collections;

namespace QTMS.Scoop
{
    public partial class FrmFinishedGoodTestUPFinal : Form
    {
        #region variable

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        UPMaster_Class UPMaster_Class_Obj = new UPMaster_Class();
        DataTable dT = new DataTable();
        DataSet DS_UPTestRecord; Int64 FGTLFID2;
        #endregion

        private static FrmFinishedGoodTestUPFinal FrmFinishedGoodTestUPFinal_Obj = null;

        public static FrmFinishedGoodTestUPFinal GetInstance()
        {
            if (FrmFinishedGoodTestUPFinal_Obj == null)
            {
                FrmFinishedGoodTestUPFinal_Obj = new FrmFinishedGoodTestUPFinal();
            }
            return FrmFinishedGoodTestUPFinal_Obj;
        }

        public FrmFinishedGoodTestUPFinal()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFinishedGoodTestUPFinal_Load(object sender, EventArgs e)
        {
            try
            {
                Painter.Paint(this);
                DtpDate.Value = Comman_Class_Obj.Select_ServerDate();
                Bind_Details();
                cmbDetails.Focus();
            }
            catch
            {
                throw;
            }
        }

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = FinishedGoodTest_Class_Obj.Select_PendingFinishedGoodDetailsUP();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["FGTLFID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "FGTLFID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Int64? UPId;
     
        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ResetAll();
                dT = (DataTable)cmbDetails.DataSource;
                //DataRow[] dR = dT.Select("FGTLFID=" + cmbDetails.SelectedValue + "");
                DataRow[] dR = dT.Select("FGTLFID=" + cmbDetails.SelectedValue + "");
                if (Convert.ToBoolean(dR[0]["KitFlag"]))
                {
                    txtLineStarTime.Text = Convert.ToString(dR[0]["KitLineStartTime"]);
                    #region MyRegion
                    //FinishedGoodTest_Class_Obj.FGCode = dR[0]["FGCode"].ToString();
                    //FinishedGoodTest_Class_Obj.trackcode = dR[0]["TrackCodeFG"].ToString();
                    //FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dR[0]["LNoFG"].ToString());
                    //DataSet ds = FinishedGoodTest_Class_Obj.SelectLineStartedDate();
                    //if (ds.Tables.Count > 0)
                    //{
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        txtLineStarTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["LineStartedTime"]);
                    //    }
                    //    else
                    //    {
                    //        DataSet ds2 = FinishedGoodTest_Class_Obj.SelectLineStartedDatefromFGNonadTodayDate(Convert.ToDateTime(DateTime.Now.Date.ToShortDateString()), Convert.ToDateTime(DateTime.Now.Date.AddDays(1).ToShortDateString()));
                    //        if (ds2.Tables[0].Rows.Count>0)
                    //        {
                    //            txtLineStarTime.Text = Convert.ToString(ds2.Tables[0].Rows[0]["LineStartedTime"]);    
                    //        }
                    //        else
                    //        {
                    //            return;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    return;
                    //} 
                    #endregion
                }
                else
                {
                    txtLineStarTime.Text = dR[0]["LineStartedTime"].ToString();
                }
                //txtLineStarTime.Text = dR[0]["LineStartedTime"].ToString();
                FGTLFID2 = Convert.ToInt64(dR[0]["FGTLFID"].ToString());

                if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "" && cmbDetails.SelectedIndex != 0)
                {
                    FinishedGoodTest_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);

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
                    // for checking option launches for FGcode whose transaction already done
                    if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "0")
                    {
                        if (cmbDetails.SelectedValue != DBNull.Value)
                        {
                            DataSet dsPkg = FinishedGoodTest_Class_Obj.STP_SELECT_FGNo_FMID_PkgSamp();
                            if (dsPkg.Tables[0].Rows.Count > 0)
                            {
                                // RdoLaunch.Checked = false;
                            }
                            else
                            {
                                // RdoLaunch.Checked = true;
                            }
                        }
                    }
                    //Check the current date with reference date from formula master
                    //formula will expire after 1 year from the reference date
                    //It will start promting message 1 month before reference date

                    // If validity data already exist show by database else show valdity one year greater than track code
                    FGRefMgmtTransaction FGRefMgmtTransaction_obj = new FGRefMgmtTransaction();
                    DataTable dt = new DataTable();
                    FGRefMgmtTransaction_obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                    FGRefMgmtTransaction_obj.fgno = FGRefMgmtTransaction_obj.Select_FGNO_FGTLFID_FGRegMgt();
                    dt = FGRefMgmtTransaction_obj.Select_FGRefMgmtTransactionFGCode();

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (Comman_Class_Obj.Select_ServerDate() >= Convert.ToDateTime(dr["ValidityDate"]))
                            {
                                MessageBox.Show("FG Code Expired on" + Convert.ToDateTime(dr["ValidityDate"]).ToString("dd/MMM/yyyy"), "Finished Good Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmbDetails.Focus();
                                cmbDetails.SelectedValue = 0;
                                return;
                            }
                            else if (Comman_Class_Obj.Select_ServerDate() < Convert.ToDateTime(dr["ValidityDate"]).AddDays(-15))
                            {

                            }
                            else
                            {
                                //lblMessage.Text = "This formula will Expire on " + Convert.ToString(Convert.ToDateTime(ds.Tables[0].Rows[0]["ReferenceDate"]).AddMonths(12).ToShortDateString());
                                NotifyWindow nw = new NotifyWindow("FG Code Expiry", Convert.ToDateTime(dr["ValidityDate"]).ToString("dd/MMM/yyyy"));
                                nw.Notify();
                            }
                        }
                    }



                    //Select Bulk & Packing Details 
                    DataSet dsPkgBulk = new DataSet();
                    dsPkgBulk = FinishedGoodTest_Class_Obj.Select_FinishedGood_PackingBulkTestDetails();
                    for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)
                    {
                        dgKit.Rows.Add();
                        dgKit["TLFID", i].Value = dsPkgBulk.Tables[0].Rows[i]["TLFID"].ToString();
                        dgKit["FNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString();
                        dgKit["FormulaNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString();
                        dgKit["MfgWo", i].Value = dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();
                        dgKit["FGNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FGNo"].ToString();
                        dgKit["FGCode", i].Value = dsPkgBulk.Tables[0].Rows[i]["FGCode"].ToString();
                        dgKit["TrackCode", i].Value = Convert.ToDateTime(dsPkgBulk.Tables[0].Rows[i]["TrackCode"]).ToShortDateString();
                        dgKit["LineDesc", i].Value = dsPkgBulk.Tables[0].Rows[i]["LineDesc"].ToString();
                        dgKit["PkgWO", i].Value = dsPkgBulk.Tables[0].Rows[i]["PkgWOFG"].ToString();
                        dgKit["FillDate", i].Value = Convert.ToDateTime(dsPkgBulk.Tables[0].Rows[i]["FillDateFG"]).ToShortDateString();
                        dgKit["Price", i].Value = dsPkgBulk.Tables[0].Rows[i]["PriceFG"].ToString();
                        dgKit["specification", i].Value = dsPkgBulk.Tables[0].Rows[i]["specificationFG"].ToString();
                        dgKit["Status", i].Value = dsPkgBulk.Tables[0].Rows[i]["Status"].ToString();
                    }

                    //Display unit PackSize and Weight
                    DataSet dsUnit;
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        dsUnit = new DataSet();
                        FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                        dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                        if (dsUnit.Tables[0].Rows.Count > 0)
                        {
                            if (dsUnit.Tables[0].Rows[0]["PackSize"] is DBNull)
                            {

                            }
                            else
                            {
                                dgKit["PackSize", i].Value = dsUnit.Tables[0].Rows[0]["PackSize"].ToString();
                            }

                            if (dsUnit.Tables[0].Rows[0]["Weight"] is DBNull)
                            {

                            }
                            else
                            {
                                dgKit["Weight", i].Value = dsUnit.Tables[0].Rows[0]["Weight"].ToString();
                            }
                        }
                    }
                    if (DS_UPTestRecord == null)
                    {
                      DS_UPTestRecord = new DataSet();
                    }
                    else
                    {
                        DS_UPTestRecord.Clear();
                    }
                    
                    UPMaster_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                    if (Convert.ToBoolean(dR[0]["KitFlag"]))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dR[0]["KitLineStartTime"])))
                        {
                            txtLineStarTime.Text = Convert.ToString(dR[0]["KitLineStartTime"]);    
                        }
                        else
                        {
                            return;
                        }
                        #region Not In Use Changes Pandurang Kumbhar 29-Jul-2013
                        //FinishedGoodTest_Class_Obj.FGCode = dR[0]["FGCode"].ToString();
                        //FinishedGoodTest_Class_Obj.trackcode = dR[0]["TrackCodeFG"].ToString();
                        //FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dR[0]["LNoFG"].ToString());
                        //DataSet ds = FinishedGoodTest_Class_Obj.SelectLineStartedDate();
                        //if (ds.Tables.Count > 0)
                        //{
                        //    if (ds.Tables[0].Rows.Count > 0)
                        //    {
                        //        txtLineStarTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["LineStartedTime"]);
                        //    }
                        //    else
                        //    {
                        //        DataSet ds2 = FinishedGoodTest_Class_Obj.SelectLineStartedDatefromFGNonadTodayDate(Convert.ToDateTime(DateTime.Now.Date.ToShortDateString()), Convert.ToDateTime(DateTime.Now.Date.AddDays(1).ToShortDateString()));
                        //        if (ds2.Tables[0].Rows.Count > 0)
                        //        {
                        //            txtLineStarTime.Text = Convert.ToString(ds2.Tables[0].Rows[0]["LineStartedTime"]);
                        //        }
                        //        else
                        //        {
                        //            return;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    return;
                        //} 
                        #endregion
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dR[0]["LineStartedTime"].ToString())))
                        {
                            txtLineStarTime.Text = Convert.ToString(dR[0]["LineStartedTime"].ToString());    
                        }
                        else
                        {
                            return;
                        }
                    }
                    if (string.IsNullOrEmpty(txtLineStarTime.Text))
                    {
                        lblQualityStatus.Text = String.Empty;
                        lblUPAuthorityStatus.Text = String.Empty;
                        txtQualityComment.Text = String.Empty;
                        txtUPAuthoritycomment.Text = String.Empty;
                        return;
                    }
                    else
                    {
                        UPMaster_Class_Obj.linestarttime = Convert.ToDateTime(txtLineStarTime.Text);
                        DS_UPTestRecord = UPMaster_Class_Obj.Select_UPMaster();
                        if (DS_UPTestRecord.Tables[0].Rows.Count > 0)
                        {
                            UPId = Convert.ToInt64(DS_UPTestRecord.Tables[0].Rows[0]["UPID"].ToString());
                            if (DS_UPTestRecord.Tables[0].Rows[0]["QualityAuthorityStatus"] == DBNull.Value)
                            {
                                lblQualityStatus.Text = "Not given yet";
                                lblQualityStatus.ForeColor = Color.Red;
                            }
                            else if (DS_UPTestRecord.Tables[0].Rows[0]["QualityAuthorityStatus"].ToString() == "H")
                            {
                                lblQualityStatus.Text = "Hold";
                                lblQualityStatus.ForeColor = Color.Red;
                            }
                            else if (DS_UPTestRecord.Tables[0].Rows[0]["QualityAuthorityStatus"].ToString() == "R")
                            {
                                lblQualityStatus.Text = "Rejected";
                                lblQualityStatus.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblQualityStatus.Text = "Accepted";
                                lblQualityStatus.ForeColor = Color.Red;
                            }
                            #region Change on Dated 2013-07-24
                            //if (DS_UPTestRecord.Tables[0].Rows[0]["UPAuthorityStatus"] == DBNull.Value)
                            //{
                            //    lblUPAuthorityStatus.Text = "Not given yet";
                            //    lblUPAuthorityStatus.ForeColor = Color.Red;
                            //}
                            //else if (DS_UPTestRecord.Tables[0].Rows[0]["UPAuthorityStatus"].ToString() == "H")
                            //{
                            //    lblUPAuthorityStatus.Text = "Hold";
                            //    lblUPAuthorityStatus.ForeColor = Color.Red;
                            //}
                            //else if (DS_UPTestRecord.Tables[0].Rows[0]["UPAuthorityStatus"].ToString() == "R")
                            //{
                            //    lblUPAuthorityStatus.Text = "Rejected";
                            //    lblUPAuthorityStatus.ForeColor = Color.Red;
                            //}
                            //else
                            //{
                            //    lblUPAuthorityStatus.Text = "Accepted";
                            //    lblUPAuthorityStatus.ForeColor = Color.Red;
                            //}
                            //if (DS_UPTestRecord.Tables[0].Rows[0]["UPAuthorityComment"] != DBNull.Value)
                            //{
                            //    txtUPAuthoritycomment.Text = DS_UPTestRecord.Tables[0].Rows[0]["UPAuthorityComment"].ToString();
                            //}

                            #endregion
                            if (DS_UPTestRecord.Tables[0].Rows[0]["QualityAuthorityComment"] != DBNull.Value)
                            {
                                txtQualityComment.Text = DS_UPTestRecord.Tables[0].Rows[0]["QualityAuthorityComment"].ToString();
                            }

                            if (DS_UPTestRecord.Tables[0].Rows[0]["FinalStatus"] == DBNull.Value)
                            {
                                rdoAccepted.Checked = true;
                            }
                            if (DS_UPTestRecord.Tables[0].Rows[0]["FinalStatus"].ToString() == "A")
                            {
                                rdoAccepted.Checked = true;
                            }
                            if (DS_UPTestRecord.Tables[0].Rows[0]["FinalStatus"].ToString() == "H")
                            {
                                rdoHold.Checked = true;
                            }
                            if (DS_UPTestRecord.Tables[0].Rows[0]["FinalStatus"].ToString() == "R")
                            {
                                rdoRejected.Checked = true;
                            }
                            if (DS_UPTestRecord.Tables[0].Rows[0]["FinalComment"] != DBNull.Value)
                            {
                                txtFinalComment.Text = DS_UPTestRecord.Tables[0].Rows[0]["FinalComment"].ToString();
                            }
                        }
                        else
                        {
                            lblQualityStatus.Text = "";
                            lblUPAuthorityStatus.Text = "";
                            MessageBox.Show("There is no record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    
                    //UPMaster_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                    DataSet dsStatus=UPMaster_Class_Obj.Select_tblFinishedGoodTestDetailsStatus();
                    if (dsStatus.Tables.Count > 0)
                    {
                        if (dsStatus.Tables[0].Rows.Count>0)
                        {
                            if (dsStatus.Tables[0].Rows[0]["ActualStatus"] == DBNull.Value)
                            {
                                lblUPAuthorityStatus.Text = "Not given yet";
                                lblUPAuthorityStatus.ForeColor = Color.Red;
                            }
                            else if (dsStatus.Tables[0].Rows[0]["ActualStatus"].ToString() == "H")
                            {
                                lblUPAuthorityStatus.Text = "Hold";
                                lblUPAuthorityStatus.ForeColor = Color.Red;
                            }
                            else if (dsStatus.Tables[0].Rows[0]["ActualStatus"].ToString() == "R")
                            {
                                lblUPAuthorityStatus.Text = "Rejected";
                                lblUPAuthorityStatus.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblUPAuthorityStatus.Text = "Accepted";
                                lblUPAuthorityStatus.ForeColor = Color.Red;
                            }
                            if (dsStatus.Tables[0].Rows[0]["comment"] != DBNull.Value)
                            {
                                txtUPAuthoritycomment.Text = dsStatus.Tables[0].Rows[0]["comment"].ToString();
                            }
                        }
                    }                    
                }
            }
            catch
            {
                throw;
            }

        }

        private void ResetAll()
        {
            try
            {
                txtFGDesc.Text = "";
                txtPkgFamily.Text = "";
                txtControltype.Text = "";
                dgKit.Rows.Clear();
            }
            catch
            {
                throw; 
            }
           
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblQualityStatus.Text == "" && lblUPAuthorityStatus.Text == "")
                {
                    return;
                }
                if (rdoAccepted.Checked)
                {
                    if (lblUPAuthorityStatus.Text == "Accepted" && lblQualityStatus.Text == "Accepted")
                    {
                        UPMaster_Class_Obj.upid = (Int64)UPId;
                        UPMaster_Class_Obj.finalComment = txtFinalComment.Text;
                        UPMaster_Class_Obj.finalStatus = 'A';
                        UPMaster_Class_Obj.finalInspectedBy = Convert.ToInt32(GlobalVariables.uid);
                        UPMaster_Class_Obj.Update_UPMasterFinal();
                        MessageBox.Show("Record Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset_all();
                        return;

                    }
                    else
                    {
                        MessageBox.Show("To accept both authority must accept first","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }

                }
              

                if (rdoAccepted.Checked == true)
                {
                    UPMaster_Class_Obj.finalStatus = 'A';
                }
                else if (rdoHold.Checked == true)
                {
                    UPMaster_Class_Obj.finalStatus = 'H';
                }
                else if (rdoRejected.Checked == true)
                {
                    UPMaster_Class_Obj.finalStatus= 'R';
                }
                if (UPId != null)
                {
                    UPMaster_Class_Obj.upid = (Int64)UPId;
                    UPMaster_Class_Obj.finalComment = txtFinalComment.Text;
                    UPMaster_Class_Obj.finalInspectedBy = Convert.ToInt32(GlobalVariables.uid);
                    UPMaster_Class_Obj.Update_UPMasterFinal();
                    MessageBox.Show("Record Saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset_all();
                }

                
            }
            catch
            {
                throw;
            }
        }
        private void Reset_all()
        {
           
            dgKit.Rows.Clear();
            lblQualityStatus.Text = "";
            lblUPAuthorityStatus.Text = "";

            txtControltype.Text = "";
            txtFGDesc.Text = "";
            txtLineStarTime.Text = "";
            txtPkgFamily.Text = "";

            txtQualityComment.Text = "";
            txtUPAuthoritycomment.Text = "";
            txtFinalComment.Text = "";

            cmbDetails.Focus();
            cmbDetails.SelectedIndex = 0;
           
          
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset_all();
        }
    }
}