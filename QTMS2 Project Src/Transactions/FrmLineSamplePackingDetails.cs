/********************************************************
*Author: Vijay Tomake
*Date: 
*Description: Transaction form to enter Line packing Details 
*Revision:
********************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Transactions
{
    public partial class FrmLineSamplePackingDetails : Form
    {
        public FrmLineSamplePackingDetails()
        {
            InitializeComponent();
        }
        # region Varibles
        public bool Flag = false;
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.LineSamplePackingDetails_Class LineSamplePackingDetails_Class_Obj = new BusinessFacade.Transactions.LineSamplePackingDetails_Class();
        TankMaster_Class TankMaster_Class_Obj = new TankMaster_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new PackingFamilyMaster_Class();
        FGGlobalFamilyMaster_Class FGGlobalFamilyMaster_Class_Obj = new FGGlobalFamilyMaster_Class();
        RetainerLocation_Class RetainerLocation_Class_Obj = new RetainerLocation_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        # endregion

        /// <summary>
        /// get the active instance of the form
        /// </summary>
        private static FrmLineSamplePackingDetails frmLineSamplePackingDetails_Obj = null;
        public static FrmLineSamplePackingDetails GetInstance()
        {
            if (frmLineSamplePackingDetails_Obj == null)
            {
                frmLineSamplePackingDetails_Obj = new FrmLineSamplePackingDetails();
            }
            return frmLineSamplePackingDetails_Obj;
        }

        /// <summary>
        /// Form load method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLineSamplePackingDetails_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_MfgWo();
            Bind_LineNo();
            Bind_TechFamily();
            Bind_FGGlobalFamily();
            Bind_Location();
            Bind_InspectedBy();
            Bind_VerifiedBy();
            cmbMfgWo.Focus();
            cmbMfgWo.Text = "--Select--";
            CmbTechnicalFamily.Text = "--Select--";
            CmbFGGlobalFamily.Text = "--Select--";
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpTrackCode.Value = Comman_Class_Obj.Select_ServerDate();
            DtpFillDate.Value = Comman_Class_Obj.Select_ServerDate();

            LineSamplePackingDetails_Class_Obj.fmid = 0;

            if (GlobalVariables.City == "BADDI")
            {
                lblLocation.Visible = false;
                cmbLocation.Visible = false;

                lblDeveloper.Visible = lblColorant.Visible = lblFG.Visible = lblOther.Visible = lblSF.Visible = false;
                txtDeveloper.Visible = txtColorant.Visible = txtFG.Visible = txtOther.Visible = txtSF.Visible = false;
            }

        }

        /// <summary>
        /// Bind all the MfgWo entered into bulk test details
        /// </summary>
        public void Bind_MfgWo()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            Flag = false;
            ds = LineSamplePackingDetails_Class_Obj.SELECT_tblFM_MfgWo_FormulaNo();
            dr = ds.Tables[0].NewRow();
            dr["MfgWo"] = "--Select--";
            dr["FMID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbMfgWo.DataSource = ds.Tables[0];
            cmbMfgWo.ValueMember = "FMID";
            cmbMfgWo.DisplayMember = "MfgWo";
        }

        /// <summary>
        /// Bind FGCode from finished good master
        /// </summary>
        public void Bind_FGCode()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = LineSamplePackingDetails_Class_Obj.Select_tblFGMaster_FGCode_FNo();
                dr = ds.Tables[0].NewRow();
                dr["FGCode"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                CmbFgCode.DataSource = ds.Tables[0];
                CmbFgCode.ValueMember = "FGNo";
                CmbFgCode.DisplayMember = "FGCode";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Bind packing tecnical family from packing family master
        /// </summary>
        public void Bind_TechFamily()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster();
            dr = ds.Tables[0].NewRow();
            dr["TechFamDesc"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbTechnicalFamily.DataSource = ds.Tables[0];
                CmbTechnicalFamily.DisplayMember = "TechFamDesc";
                CmbTechnicalFamily.ValueMember = "PKGTechNo";
            }
        }

        /// <summary>
        /// Bind FG Global family from FG Global family master
        /// </summary>
        public void Bind_FGGlobalFamily()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = FGGlobalFamilyMaster_Class_Obj.Select_FGGlobalFamilyMaster();
            dr = ds.Tables[0].NewRow();
            dr["FGGlobalFamilyName"] = "--Select--";
            dr["FGGlobalFamilyID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbFGGlobalFamily.DataSource = ds.Tables[0];
                CmbFGGlobalFamily.DisplayMember = "FGGlobalFamilyName";
                CmbFGGlobalFamily.ValueMember = "FGGlobalFamilyID";
            }
        }

        /// <summary>
        /// Bind Line No from line No master
        /// </summary>
        DataSet Lineds;
        public void Bind_LineNo()
        {
            Lineds = new DataSet();
            DataRow dr;
            Lineds = LineMaster_Class_Obj.Select_LineMaster();
            dr = Lineds.Tables[0].NewRow();
            dr["LineDesc"] = "--Select--";
            Lineds.Tables[0].Rows.InsertAt(dr, 0);

            if (Lineds.Tables[0].Rows.Count > 0)
            {

                CmbLineNo.DataSource = Lineds.Tables[0];
                CmbLineNo.DisplayMember = "LineDesc";
                CmbLineNo.ValueMember = "LNo";
            }
        }

        /// <summary>
        /// Bind retainer location from retainer location master
        /// </summary>
        public void Bind_Location()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = RetainerLocation_Class_Obj.Select_tblRetainerLocation();
            dr = ds.Tables[0].NewRow();
            dr["Location"] = "--Select--";
            dr["LocationID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbLocation.DataSource = ds.Tables[0];
                cmbLocation.DisplayMember = "Location";
                cmbLocation.ValueMember = "LocationID";
            }
        }

        /// <summary>
        /// Bind users from user master
        /// </summary>
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

        /// <summary>
        /// leave event for MfgWo combo box 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMfgWo_Leave(object sender, EventArgs e)
        {
            if (cmbMfgWo.Text == "--Select--" || cmbMfgWo.SelectedValue == null || cmbMfgWo.SelectedValue.ToString() == "")
            {
                if (cmbMfgWo.Text == "")
                {
                    txtFormulaNo.Text = "";
                    txtDescription.Text = "";
                    txtTechnicalFamily.Text = "";
                    cmbMfgWo.Focus();
                }
            }
        }

        /// <summary>
        /// Selection change commited event for MfgWo combo box 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMfgWo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtFormulaNo.Text = "";
            txtDescription.Text = "";
            txtTechnicalFamily.Text = "";
            ChkAOCPending.Checked = false;

            if (cmbMfgWo.SelectedValue != null && cmbMfgWo.SelectedValue.ToString() != "0")
            {
                //Dispaly Details of formulano
                DataSet ds = new DataSet();
                LineSamplePackingDetails_Class_Obj.fmid = Convert.ToInt64(cmbMfgWo.SelectedValue.ToString());
                ds = LineSamplePackingDetails_Class_Obj.Select_PendingLinePackingDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (GlobalVariables.City.ToLower() == "pune")
                    {
                        DataSet Ds = new DataSet();
                        FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(ds.Tables[0].Rows[0]["FNo"]);
                        Ds = FormulaNoMaster_Class_Obj.Select_From_TblBulkMaster_By_FNo();
                        string StrFDExport = Convert.ToString(Ds.Tables[0].Rows[0]["FDAApprovalDateExport"]);
                        string StrFDLocal = Convert.ToString(Ds.Tables[0].Rows[0]["FDAApprovalDate"]);
                        if (StrFDLocal != "" && StrFDExport != "")
                        {
                            DateTime FDADAte = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
                            DateTime FDADAteLocal = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDate"].ToString());
                            if (MessageBox.Show("This Formuala under FDA Local date : " + FDADAteLocal.ToString("dd-MMM-yyyy") + " and FDA Export date : " + FDADAte.ToString("dd-MMM-yyyy") + " Do you want continue with formula. ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                            {
                                //dgFGCode.Rows.Remove(dgFGCode.SelectedRows[i]);
                            }
                            else
                            {
                                cmbMfgWo.Text = "--Select--";
                                return;
                            }
                        }
                        else if (StrFDLocal != "" && StrFDExport == "")
                        {
                            //DateTime FDADAte = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
                            DateTime FDADAteLocal = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDate"].ToString());
                            if (MessageBox.Show("This Formuala under FDA Local date : " + FDADAteLocal.ToString("dd-MMM-yyyy") + " Do you want continue with formula. ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                            {
                                //dgFGCode.Rows.Remove(dgFGCode.SelectedRows[i]);
                            }
                            else
                            {
                                cmbMfgWo.Text = "--Select--";
                                return;
                            }
                        }
                        else if (StrFDLocal == "" && StrFDExport != "")
                        {
                            DateTime FDADAte = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
                            //DateTime FDADAteLocal = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDate"].ToString());
                            if (MessageBox.Show("This Formuala under FDA Export date : " + FDADAte.ToString("dd-MMM-yyyy") + " Do you want continue with formula. ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                            {
                                //dgFGCode.Rows.Remove(dgFGCode.SelectedRows[i]);
                            }
                            else
                            {
                                cmbMfgWo.Text = "--Select--";
                                return;
                            }
                        }
                        ////if (Ds.Tables[0].Rows[0]["FDAApprovalDateExport"] is System.DBNull)
                        ////{ }
                        ////else
                        ////{
                        ////    DateTime FDADAte = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
                        ////    if (MessageBox.Show("This Formuala under FDA Export date : " + FDADAte.ToString("dd-MMM-yyyy") + " Do you want continue with formula. ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        ////    {
                        ////        //dgFGCode.Rows.Remove(dgFGCode.SelectedRows[i]);
                        ////    }
                        ////    else
                        ////    {
                        ////        cmbMfgWo.Text = "--Select--";
                        ////        return;
                        ////    }
                        ////    //DtpFDAApprovalExport.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
                        ////}
                    }


                    txtFormulaNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FormulaNo"]);
                    txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);
                    txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);

                    if (Convert.ToInt16(ds.Tables[0].Rows[0]["MicrobiologyTest"]) == 1)
                    {
                        FinishedGoodMaster_Class_Obj.fgmicro = 1;
                    }
                    else
                    {
                        FinishedGoodMaster_Class_Obj.fgmicro = 0;
                    }
                }

                //Bind FGCode those are applicable to formula
                LineSamplePackingDetails_Class_Obj.fno = Convert.ToInt32(ds.Tables[0].Rows[0]["FNo"]);
                FinishedGoodMaster_Class_Obj.fno = Convert.ToInt32(ds.Tables[0].Rows[0]["FNo"]);
                Bind_FGCode();
            }
            else
            {
                LineSamplePackingDetails_Class_Obj.fno = 0;
                Bind_FGCode();
            }
        }

        private void cmbMfgWo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbMfgWo.Text.StartsWith("WO") && cmbMfgWo.Text.Length == 12)
            {
                txtBatchCode.Text = "B5" + cmbMfgWo.Text.Substring(cmbMfgWo.Text.Length - 5) + "(" + DtpFillDate.Value.Day + "-" + DtpFillDate.Value.Month + "/" + DtpFillDate.Value.Year + ")";
            }
            else
            {
                txtBatchCode.Text = "";
            }
        }

        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Checked change event for SemiFinished Check box
        /// IF semifinished then record should be rejected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkSemiFinished_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSemiFinished.Checked == true)
            {
                txtSemiFinished.Enabled = true;
                txtSemiFinished.Focus();

                //Record cant accepted when it is semifinished
                RdoRejected.Checked = true;
            }
            else if (ChkSemiFinished.Checked == false)
            {
                txtSemiFinished.Enabled = false;
                txtSemiFinished.Text = "";

                RdoAccepted.Checked = true;
            }
        }

        /// <summary>
        /// Checked change event for AOC pending check box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkAOCPending_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAOCPending.Checked == true)
            {
                txtAOCPending.Enabled = true;
                txtAOCPending.Focus();
            }
            else if (ChkAOCPending.Checked == false)
            {
                txtAOCPending.Enabled = false;
                txtAOCPending.Text = "";
            }
        }

        /// <summary>
        /// Save the line Packing details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if ((cmbMfgWo.Text == "--Select--" || cmbMfgWo.SelectedValue == null || cmbMfgWo.SelectedValue.ToString() == ""))
                {
                    MessageBox.Show("Select/Enter MfgWo No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMfgWo.Focus();
                    lblisScoopApplicable.Visible = false;//<---------Scoop msg
                    return;
                }

                if (cmbMfgWo.Text == "--Select--")
                {
                    MessageBox.Show("Select/Enter MfgWo No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbMfgWo.Focus();
                    lblisScoopApplicable.Visible = false;//<---------Scoop msg
                    return;
                }


                if ((CmbFgCode.Text == "--Select--" || CmbFgCode.SelectedValue == null || CmbFgCode.SelectedValue.ToString() == "") && (ChkKit.Checked != true && ChkSF.Checked != true))
                {
                    MessageBox.Show("Select/Enter FG Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbFgCode.Focus();
                    lblisScoopApplicable.Visible = false;//<---------Scoop msg
                    return;
                }


                if (CmbFgCode.Text == "--Select--")
                {
                    MessageBox.Show("Select/Enter FG Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbFgCode.Focus();

                    return;
                }

                if ((ChkKit.Checked == true || ChkSF.Checked == true) && CmbFgCode.Text.Trim() == "")
                {
                    MessageBox.Show("Enter FGCode..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbFgCode.Focus();

                    return;
                }

                if ((ChkKit.Checked == true || ChkSF.Checked == true) && CmbTechnicalFamily.Text == "--Select--")
                {
                    MessageBox.Show("Select Packing Technical Family..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbTechnicalFamily.Focus();

                    return;
                }

                if ((ChkKit.Checked == true || ChkSF.Checked == true) && CmbFGGlobalFamily.Text == "--Select--")
                {
                    MessageBox.Show("Select FG Global Family..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbFGGlobalFamily.Focus();

                    return;
                }

                if (CmbLineNo.Text == "--Select--" || CmbLineNo.SelectedValue == null || CmbLineNo.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Select Line No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbLineNo.Focus();
                    lblisScoopApplicable.Visible = false;//<---------Scoop msg
                    return;
                }

                if (txtBatchCode.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Batch Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchCode.Text = "";
                    txtBatchCode.Focus();

                    return;
                }

                if (txtFillVolume.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Fill Volume", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFillVolume.Text = "";
                    txtFillVolume.Focus();

                    return;
                }

                if (txtPrice.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Price", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrice.Text = "";
                    txtPrice.Focus();
                    return;
                }

                if (txtSpecification.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Specification", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSpecification.Text = "";
                    txtSpecification.Focus();
                    return;
                }

                if (txtPkgWoNo.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Packing Work", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPkgWoNo.Text = "";
                    txtPkgWoNo.Focus();
                    return;
                }

                if ((ChkAOCPending.Checked == false) && (ChkFinishedProduct.Checked == false) && (ChkSemiFinished.Checked == false) && (ChkWip.Checked == false))
                {
                    MessageBox.Show("Select atleast one Product Decleration", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChkSemiFinished.Focus();
                    return;
                }

                if (ChkSemiFinished.Checked == true)
                {
                    if (txtSemiFinished.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter Semi Finished Comment", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSemiFinished.Text = "";
                        txtSemiFinished.Focus();
                        return;
                    }
                }

                if (ChkAOCPending.Checked == true)
                {
                    if (txtAOCPending.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter AOC Pending Comment", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAOCPending.Text = "";
                        txtAOCPending.Focus();
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
                if (MessageBox.Show("Line No : " + CmbLineNo.Text + " ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    return;
                }
                //LineSamplePackingDetails_Class_Obj.trackcode = DtpTrackCode.Value.ToString("dd-MMM-yyyy");
                if (MessageBox.Show("Track Code : " + DtpTrackCode.Value.ToString("dd-MMM-yyyy") + " ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    return;
                }



                //--------- Commented as per Nilesh's suggestion----------

                //if (ChkSemiFinished.Checked == true && RdoAccepted.Checked == true)
                //{
                //    MessageBox.Show("Semifinished Can't Accepted..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    RdoRejected.Checked = true;
                //    RdoRejected.Focus();
                //    return;                    
                //}


                LineSamplePackingDetails_Class_Obj.fmid = Convert.ToInt64(cmbMfgWo.SelectedValue);
                LineSamplePackingDetails_Class_Obj.trackcode = DtpTrackCode.Value.ToShortDateString();
                LineSamplePackingDetails_Class_Obj.lno = Convert.ToInt32(CmbLineNo.SelectedValue);

                if (ChkKit.Checked == true || ChkSF.Checked == true)
                {
                    //------- Insert WIP into FGCode table

                    FinishedGoodMaster_Class_Obj.fgcode = CmbFgCode.Text.Trim();
                    FinishedGoodMaster_Class_Obj.pkgtechno = Convert.ToInt32(CmbTechnicalFamily.SelectedValue);
                    FinishedGoodMaster_Class_Obj.fgglobalfamilyid = Convert.ToInt32(CmbFGGlobalFamily.SelectedValue);
                    FinishedGoodMaster_Class_Obj.fgdesc = "";
                    FinishedGoodMaster_Class_Obj.fillvolume = "";
                    FinishedGoodMaster_Class_Obj.kit = 0;

                    FinishedGoodMaster_Class_Obj.wip = 1;

                    DataSet ds = new DataSet();
                    ds = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster_By_FGCode();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(ds.Tables[0].Rows[0]["FGNo"]);
                    }
                    else
                    {
                        MessageBox.Show("Please add FG Code this FG does not exiest in FG Master.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                        /* Code Comment by avinash because harpreet(QTMS baddi) don't add new FG code from line sample packing if not exiest. Comment Date - 18-Oct-2019*/

                        ////FinishedGoodMaster_Class_Obj.fgno = 0;
                        //////IF FGCode is WIP then insert entry into Finished Good Master
                        ////FinishedGoodMaster_Class_Obj.fgno = FinishedGoodMaster_Class_Obj.Insert_tblFGMaster();
                        ////if (FinishedGoodMaster_Class_Obj.fgno != 0)
                        ////{
                        ////    //FinishedGoodMaster_Class_Obj.fno
                        ////    //FinishedGoodMaster_Class_Obj.fgmicro
                        ////    FinishedGoodMaster_Class_Obj.Insert_tblFG_FormulaMaster();
                        ////}
                    }
                    LineSamplePackingDetails_Class_Obj.fgno = FinishedGoodMaster_Class_Obj.fgno;
                }
                else
                {
                    LineSamplePackingDetails_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                }

                //This flag is set if the entry is for kit element
                if (ChkKit.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.kitflag = 1;
                }
                else
                {
                    LineSamplePackingDetails_Class_Obj.kitflag = 0;
                }


                if (ChkSF.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.sfflag = 1;
                }
                else
                {
                    LineSamplePackingDetails_Class_Obj.sfflag = 0;
                }

                //Check whether combination of FMID, TrackCode, LNo, FGNo Already Exists 
                DataSet dsTLFID = new DataSet();
                dsTLFID = LineSamplePackingDetails_Class_Obj.Select_tblTransTLF_FMTLF();
                if (dsTLFID.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("Record Already Exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                    lblisScoopApplicable.Visible = false;//<---------Scoop msg
                    return;
                }
                else
                {
                    //Insert FMID, trackCode, LineNo ,FGNo in tblTransTLF
                    LineSamplePackingDetails_Class_Obj.tlfid = LineSamplePackingDetails_Class_Obj.Insert_tblTransTLF();
                }

                LineSamplePackingDetails_Class_Obj.batchno = txtBatchCode.Text.Trim();
                LineSamplePackingDetails_Class_Obj.fillvolume = txtFillVolume.Text.Trim();
                LineSamplePackingDetails_Class_Obj.pkgwo = txtPkgWoNo.Text.Trim();
                LineSamplePackingDetails_Class_Obj.price = txtPrice.Text.Trim();
                LineSamplePackingDetails_Class_Obj.Specification = txtSpecification.Text.Trim();
                LineSamplePackingDetails_Class_Obj.filldate = DtpFillDate.Value.ToShortDateString();
                LineSamplePackingDetails_Class_Obj.inspdate = DtpInspDate.Value.ToShortDateString();

                if (ChkSemiFinished.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.proddecsf = Convert.ToChar("Y");
                    LineSamplePackingDetails_Class_Obj.commentssf = txtSemiFinished.Text.Trim();
                }
                else
                {
                    LineSamplePackingDetails_Class_Obj.proddecsf = Convert.ToChar("N");
                    LineSamplePackingDetails_Class_Obj.commentssf = "";
                }

                if (ChkAOCPending.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.aocPend = Convert.ToChar("Y");
                    LineSamplePackingDetails_Class_Obj.commentsaoc = txtAOCPending.Text.Trim();
                }
                else
                {
                    LineSamplePackingDetails_Class_Obj.aocPend = Convert.ToChar("N");
                    LineSamplePackingDetails_Class_Obj.commentsaoc = "";
                }

                if (ChkWip.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.proddecwip = Convert.ToChar("Y");
                }
                else
                {
                    LineSamplePackingDetails_Class_Obj.proddecwip = Convert.ToChar("N");
                }

                if (ChkFinishedProduct.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.proddecfp = Convert.ToChar("Y");
                }
                else
                {
                    LineSamplePackingDetails_Class_Obj.proddecfp = Convert.ToChar("N");
                }

                if (RdoAccepted.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.status = Convert.ToChar("A");
                }
                if (RdoRejected.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.status = Convert.ToChar("R");
                }

                LineSamplePackingDetails_Class_Obj.comments = txtComment.Text.Trim();

                LineSamplePackingDetails_Class_Obj.locationid = Convert.ToInt64(cmbLocation.SelectedValue);

                LineSamplePackingDetails_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);
                LineSamplePackingDetails_Class_Obj.verifiedby = Convert.ToInt32(cmbVerifiedBy.SelectedValue);

                if (GlobalVariables.City == "BADDI")
                {
                    LineSamplePackingDetails_Class_Obj.developer = -1;
                }
                else
                {

                    if (txtDeveloper.Text != "")
                        LineSamplePackingDetails_Class_Obj.developer = Convert.ToInt32(txtDeveloper.Text.Trim());
                    else
                        LineSamplePackingDetails_Class_Obj.developer = 0;
                    if (txtColorant.Text != "")
                        LineSamplePackingDetails_Class_Obj.colorant = Convert.ToInt32(txtColorant.Text.Trim());
                    else
                        LineSamplePackingDetails_Class_Obj.colorant = 0;
                    if (txtSF.Text != "")
                        LineSamplePackingDetails_Class_Obj.sf = Convert.ToInt32(txtSF.Text.Trim());
                    else
                        LineSamplePackingDetails_Class_Obj.sf = 0;
                    if (txtFG.Text != "")
                        LineSamplePackingDetails_Class_Obj.fg = Convert.ToInt32(txtFG.Text.Trim());
                    else
                        LineSamplePackingDetails_Class_Obj.fg = 0;
                    if (txtOther.Text != "")
                        LineSamplePackingDetails_Class_Obj.other = Convert.ToInt32(txtOther.Text.Trim());
                    else
                        LineSamplePackingDetails_Class_Obj.other = 0;
                }
                LineSamplePackingDetails_Class_Obj.loginid = FrmMain.LoginID;

                //LineSamplePackingDetails_Class_Obj.transid = LineSamplePackingDetails_Class_Obj.Autogeneratecode();

                //Only add record in tblFGTLF when its not Kit
                //if its kit it will bind and insert into tblFGTLF in kit screen

                if (ChkKit.Checked == false && ChkSF.Checked == false)
                {
                    //check whether combination of TrackCode,LNo,FGNo already exists in tblFGTLF 
                    DataSet dsFGTLFID = new DataSet();
                    dsFGTLFID = LineSamplePackingDetails_Class_Obj.Select_tblFGTLF_TLF();
                    if (dsFGTLFID.Tables[0].Rows.Count > 0)
                    {
                        LineSamplePackingDetails_Class_Obj.fgtlfid = Convert.ToInt64(dsFGTLFID.Tables[0].Rows[0]["FGTLFID"]);
                    }
                    else
                    {
                        //Insert trackCode, Line No and FGCode into FGTLF Master 
                        LineSamplePackingDetails_Class_Obj.fgtlfid = LineSamplePackingDetails_Class_Obj.Insert_tblFGTLF();
                    }

                    LineSamplePackingDetails_Class_Obj.Insert_tblLinkTLF();
                }

                //insert line packing details
                bool b = LineSamplePackingDetails_Class_Obj.Insert_tblPkgSamp();

                if (b == true)
                {
                    MessageBox.Show("Record Saved Sucessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                    lblisScoopApplicable.Visible = false;//<---------Scoop msg
                    //Bind_FormulaNo();
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Reset the controls on the form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            cmbMfgWo.Text = "--Select--";
            txtFormulaNo.Text = "";
            txtDescription.Text = "";
            txtTechnicalFamily.Text = "";

            ChkKit.Checked = false;
            ChkSF.Checked = false;
            CmbFgCode.Text = "--Select--";
            CmbLineNo.Text = "--Select--";
            CmbTechnicalFamily.Text = "--Select--";
            CmbFGGlobalFamily.Text = "--Select--";
            cmbLocation.Text = "--Select--";
            txtBatchCode.Text = "";
            txtFillVolume.Text = "";
            txtPrice.Text = "";
            txtSpecification.Text = "";
            txtPkgWoNo.Text = "";

            txtDeveloper.Text = txtColorant.Text = txtFG.Text = txtOther.Text = txtSF.Text = "";

            DtpTrackCode.Value = Comman_Class_Obj.Select_ServerDate();
            DtpFillDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();

            ChkSemiFinished.Checked = false;
            ChkAOCPending.Checked = false;
            ChkWip.Checked = false;

            ChkFinishedProduct.Checked = false;
            txtSemiFinished.Text = "";
            txtAOCPending.Text = "";
            txtComment.Text = "";
            cmbInspectedBy.Text = "--Select--";
            cmbVerifiedBy.Text = "--Select--";
            LineSamplePackingDetails_Class_Obj.fno = 0;
            Bind_FGCode();
            lblisScoopApplicable.Visible = false;
            txtFormulaNo.Focus();
        }

        /// <summary>
        /// leave event for Specification text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSpecification_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtSpecification.Text = textInfo.ToTitleCase(txtSpecification.Text);
        }

        /// <summary>
        /// Leave event for Kacking Work order text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPkgWoNo_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtPkgWoNo.Text = textInfo.ToTitleCase(txtPkgWoNo.Text);
        }

        /// <summary>
        /// leave event for Semifinished comment text box 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSemiFinished_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtSemiFinished.Text = textInfo.ToTitleCase(txtSemiFinished.Text);
        }

        /// <summary>
        /// leave event for AOC pending commnet text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAOCPending_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtAOCPending.Text = textInfo.ToTitleCase(txtAOCPending.Text);
        }

        /// <summary>
        /// leave event for comment text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtComment_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtComment.Text = textInfo.ToTitleCase(txtComment.Text);
        }

        /// <summary>
        /// leave event for AOC pending text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAOCPending_Leave_1(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtAOCPending.Text = textInfo.ToTitleCase(txtAOCPending.Text);
        }

        /// <summary>
        /// Checked change event for Sub Contract check box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSubContract_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSubContract.Checked == true)
            //{
            //    BtnReset_Click(sender,e);   

            //    txtFormulaNo.Text = "";
            //    txtFormulaNo.ReadOnly = false;
            //    txtFormulaNo.BackColor = Color.FromName("WhiteSmoke");
            //    txtDescription.Text = "";
            //    txtDescription.ReadOnly = false;
            //    txtDescription.BackColor = Color.FromName("WhiteSmoke");
            //    txtTechnicalFamily.Text = "";
            //    txtTechnicalFamily.ReadOnly = false;
            //    txtTechnicalFamily.BackColor = Color.FromName("WhiteSmoke");
            //    txtActualDensity.Text = "";
            //    txtActualDensity.ReadOnly = false;
            //    txtActualDensity.BackColor = Color.FromName("WhiteSmoke");


            //}
            //else if (chkSubContract.Checked == false)
            //{
            //    txtFormulaNo.ReadOnly = true;
            //    txtFormulaNo.BackColor = Color.FromName("Control");               
            //    txtDescription.ReadOnly = false;
            //    txtDescription.BackColor = Color.FromName("Control");                
            //    txtTechnicalFamily.ReadOnly = false;
            //    txtTechnicalFamily.BackColor = Color.FromName("Control");
            //    txtActualDensity.ReadOnly = false;
            //    txtActualDensity.BackColor = Color.FromName("Control");  
            //}

        }

        /// <summary>
        /// Checked change event for Kit check box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkKit_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkKit.Checked == true)
            {
                lblTechfam.Visible = true;
                CmbTechnicalFamily.Visible = true;

                lblFGGlobalfam.Visible = true;
                CmbFGGlobalFamily.Visible = true;
            }
            else if (ChkKit.Checked == false)
            {
                lblTechfam.Visible = false;
                CmbTechnicalFamily.Visible = false;
                CmbTechnicalFamily.Text = "--Select--";

                lblFGGlobalfam.Visible = false;
                CmbFGGlobalFamily.Visible = false;
                CmbFGGlobalFamily.Text = "--Select--";
            }
        }

        /// <summary>
        /// Checked change event for SF check box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkSF_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSF.Checked == true)
            {
                lblTechfam.Visible = true;
                CmbTechnicalFamily.Visible = true;

                lblFGGlobalfam.Visible = true;
                CmbFGGlobalFamily.Visible = true;
            }
            else if (ChkSF.Checked == false)
            {
                lblTechfam.Visible = false;
                CmbTechnicalFamily.Visible = false;
                CmbTechnicalFamily.Text = "--Select--";

                lblFGGlobalfam.Visible = false;
                CmbFGGlobalFamily.Visible = false;
                CmbFGGlobalFamily.Text = "--Select--";
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbFgCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // for checking option launches for FGcode whose transaction already done
            if (CmbFgCode.SelectedValue != null && CmbFgCode.SelectedValue.ToString() != "0" && CmbFgCode.SelectedIndex != 0)
            {
                if (CmbFgCode.SelectedValue != null)
                    if (CmbFgCode.SelectedValue != DBNull.Value)
                        PackingFamilyMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                //PackingFamilyMaster_Class_Obj.fmid = Convert.ToInt64(cmbMfgWo.SelectedValue);
                DataSet dsPkg = PackingFamilyMaster_Class_Obj.STP_SELECT_FGNo_FMID_PkgSamp();
                if (dsPkg.Tables[0].Rows.Count > 0)
                {
                    ChkAOCPending.Checked = false;
                }
                else
                {
                    ChkAOCPending.Checked = true;
                }
            }
            else
                ChkAOCPending.Checked = false;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the CmbLineNo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CmbLineNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbLineNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToString(CmbLineNo.Text) != "")
            {
                DataRow[] dr = Lineds.Tables[0].Select("LNo=" + Convert.ToInt64(CmbLineNo.SelectedValue.ToString()) + "");
                if (Convert.ToString(dr[0]["ScoopApplicable"]) != "" && Convert.ToBoolean(dr[0]["ScoopApplicable"].ToString()) == true)
                {

                    lblisScoopApplicable.Text = "SCOOP IS APPLICABLE FOR THIS LINE.";
                    lblisScoopApplicable.ForeColor = Color.Red;
                    lblisScoopApplicable.Font = new Font("Times New Roman", 14, FontStyle.Bold);
                    lblisScoopApplicable.Visible = true;
                }
                else
                {

                    lblisScoopApplicable.Visible = false;
                }
            }

        }

        private void txtColorTube_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedValue != null && cmbLocation.SelectedValue.ToString() != "0" && cmbLocation.SelectedIndex != 0)
            {
                RetainerLocation_Class_Obj.locationid = Convert.ToInt64(cmbLocation.SelectedValue);
                DataSet DsTran = new DataSet();
                DsTran = RetainerLocation_Class_Obj.Select_RetainerLocation_TransactionExiest();
                if (DsTran.Tables[0].Rows.Count > 0)
                {
                    DataSet Ds = new DataSet();
                    Ds = RetainerLocation_Class_Obj.Select_RetainerLocation_Destruct();
                    if (Ds.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please Desctruct location !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbLocation.SelectedIndex = 0;
                    }
                }
            }
        }
    }
}