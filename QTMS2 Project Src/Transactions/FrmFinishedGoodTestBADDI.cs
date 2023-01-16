

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
using System.Configuration;
using System.IO;

namespace QTMS.Transactions
{
    public partial class FrmFinishedGoodTestBADDI : Form
    {
        ComboBox cmbDetails = new ComboBox();

        public FrmFinishedGoodTestBADDI()
        {
            InitializeComponent();
        }

        #region variables
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        DateTime Today;

        BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class FinishedGoodTest_SubContract_Class_Obj =
            new BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class();
        FGGlobalFamilyMaster_Class FGGlobalFamilyMaster_Class_Obj = new FGGlobalFamilyMaster_Class();
        PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new PackingFamilyMaster_Class();
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        RetainerLocation_Class RetainerLocation_Class_Obj = new RetainerLocation_Class();

        Boolean Flg_Save = false;

        #endregion

        //get the active instance of the form
        private static FrmFinishedGoodTestBADDI frmFinishedGoodTest_Obj = null;
        public static FrmFinishedGoodTestBADDI GetInstance()
        {
            if (frmFinishedGoodTest_Obj == null)
            {
                frmFinishedGoodTest_Obj = new FrmFinishedGoodTestBADDI();
            }
            return frmFinishedGoodTest_Obj;
        }

        /// <summary>
        /// Form load method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFinishedGoodTest_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_FGCode_Details();
            //Bind_FGSupplier();
            Bind_Location();
            //Bind_FGGlobalFamily();
            //Bind_TechnicalFamily();


            //DtpDate.Value = Comman_Class_Obj.Select_ServerDate();
            //Bind_Details();
            Bind_InspectedBy();
            //cmbDetails.Focus();
            Today = Comman_Class_Obj.Select_ServerDate();
            string dt = Today.Year.ToString();


            DtpDateOfValidation.Value = Today;
            DtpFillDate.Value = Today;
            DtpInspDate.Value = Today;
            DtpTrackCode.Value = Today;
            dtpdecisionDate.Value = Today;

            txtMfgWoNo.Text = "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0';
            cmbFormulaType.Text = "--Select--";
            CmbFormulaNo.Text = "--Select--";
        }

        //Binds the pending Finished good details those entered in 
        public void Bind_FGCode_Details()
        {
            //try
            //{
            DataSet ds = new DataSet();
            DataRow dr;
            ds = FinishedGoodTest_SubContract_Class_Obj.Select_FinishedGoodDetails_SubContract();
            dr = ds.Tables[0].NewRow();
            dr["FGCode"] = "--Select--";
            dr["FGNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            CmbFgCode.DataSource = ds.Tables[0];
            CmbFgCode.DisplayMember = "FGCode";
            CmbFgCode.ValueMember = "FGNo";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void Bind_FGSupplier()
        {
            try
            {
                FinishedGoodTest_SubContract_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                DataSet dsList = FinishedGoodTest_SubContract_Class_Obj.SELECT_SUPPLIER_SubContract_FGNo();

                //FGSupplierMaster FGSupplierMaster_Class_obj = new FGSupplierMaster();
                //DataSet dsList = FGSupplierMaster_Class_obj.Select_FGSupplierMaster();
                DataRow dr = dsList.Tables[0].NewRow();
                dr["FGSupplierId"] = "0";
                dr["FGSupplierName"] = "--Select--";
                dsList.Tables[0].Rows.InsertAt(dr, 0);
                if (dsList.Tables[0].Rows.Count >= 0)
                {
                    cmbSupplier.DataSource = dsList.Tables[0];
                    cmbSupplier.DisplayMember = "FGSupplierName";
                    cmbSupplier.ValueMember = "FGSupplierId";

                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Record Not Found");
            }
        }
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

        //public void Bind_FGGlobalFamily()
        //{
        //    DataSet ds = new DataSet();
        //    DataRow dr;
        //    ds = FGGlobalFamilyMaster_Class_Obj.Select_FGGlobalFamilyMaster();
        //    dr = ds.Tables[0].NewRow();
        //    dr["FGGlobalFamilyName"] = "--Select--";
        //    dr["FGGlobalFamilyID"] = "0";
        //    ds.Tables[0].Rows.InsertAt(dr, 0);

        //    CmbFGGlobalFamily.DataSource = ds.Tables[0];
        //    CmbFGGlobalFamily.DisplayMember = "FGGlobalFamilyName";
        //    CmbFGGlobalFamily.ValueMember = "FGGlobalFamilyID";
        //}

        //public void Bind_TechnicalFamily()
        //{

        //    DataSet ds = new DataSet();
        //    DataRow dr;
        //    ds = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster();
        //    dr = ds.Tables[0].NewRow();
        //    dr["TechFamDesc"] = "--Select--";
        //    ds.Tables[0].Rows.InsertAt(dr, 0);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        CmbTechnicalFamily.DataSource = ds.Tables[0];
        //        CmbTechnicalFamily.DisplayMember = "TechFamDesc";
        //        CmbTechnicalFamily.ValueMember = "PKGTechNo";
        //    }
        //}


        /// <summary>
        /// binds the user
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


        //private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        BtnReset_Click(sender, e);
        //        if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "" && cmbDetails.SelectedIndex != 0)
        //        {
        //            FinishedGoodTest_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);

        //            //Select FGdetails from fgno 
        //            DataSet dsFG = new DataSet();
        //            dsFG = FinishedGoodTest_Class_Obj.Select_FinishedGood_FGDetails();
        //            if (dsFG.Tables[0].Rows.Count > 0)
        //            {
        //                txtFGDesc.Text = dsFG.Tables[0].Rows[0]["FGDesc"].ToString();
        //                txtPkgFamily.Text = dsFG.Tables[0].Rows[0]["TechFamDesc"].ToString();
        //                FinishedGoodTest_Class_Obj.fgno = Convert.ToInt64(dsFG.Tables[0].Rows[0]["FGNo"]);
        //                FinishedGoodTest_Class_Obj.pkgtechno = Convert.ToInt64(dsFG.Tables[0].Rows[0]["PKGTechNo"]);
        //                FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dsFG.Tables[0].Rows[0]["LNoFG"]);

        //                //get the current version no which need to dislay on report
        //                if (dsFG.Tables[0].Rows[0]["VersionNo"] is System.DBNull)
        //                {
        //                    FinishedGoodTest_Class_Obj.versionno = "";
        //                }
        //                else
        //                {
        //                    FinishedGoodTest_Class_Obj.versionno = dsFG.Tables[0].Rows[0]["VersionNo"].ToString();
        //                }
        //            }
        //            // for checking option launches for FGcode whose transaction already done
        //            if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "0")
        //            {
        //                if (cmbDetails.SelectedValue != DBNull.Value)
        //                {
        //                    DataSet dsPkg = FinishedGoodTest_Class_Obj.STP_SELECT_FGNo_FMID_PkgSamp();
        //                    if (dsPkg.Tables[0].Rows.Count > 0)
        //                    {
        //                        RdoLaunch.Checked = false;
        //                    }
        //                    else
        //                    {
        //                        RdoLaunch.Checked = true;
        //                    }
        //                }
        //            }
        //            //Check the current date with reference date from formula master
        //            //formula will expire after 1 year from the reference date
        //            //It will start promting message 1 month before reference date

        //            // If validity data already exist show by database else show valdity one year greater than track code
        //            FGRefMgmtTransaction FGRefMgmtTransaction_obj = new FGRefMgmtTransaction();
        //            DataTable dt = new DataTable();
        //            FGRefMgmtTransaction_obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
        //            FGRefMgmtTransaction_obj.fgno = FGRefMgmtTransaction_obj.Select_FGNO_FGTLFID_FGRegMgt();
        //            dt = FGRefMgmtTransaction_obj.Select_FGRefMgmtTransactionFGCode();

        //            if (dt.Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in dt.Rows)
        //                {
        //                    if (Comman_Class_Obj.Select_ServerDate() >= Convert.ToDateTime(dr["ValidityDate"]))
        //                    {
        //                        MessageBox.Show("FG Code Expired on" + Convert.ToDateTime(dr["ValidityDate"]).ToString("dd/MMM/yyyy"), "Finished Good Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        cmbDetails.Focus();
        //                        cmbDetails.SelectedValue = 0;
        //                        return;
        //                    }
        //                    else if (Comman_Class_Obj.Select_ServerDate() < Convert.ToDateTime(dr["ValidityDate"]).AddDays(-15))
        //                    {

        //                    }
        //                    else
        //                    {
        //                        //lblMessage.Text = "This formula will Expire on " + Convert.ToString(Convert.ToDateTime(ds.Tables[0].Rows[0]["ReferenceDate"]).AddMonths(12).ToShortDateString());
        //                        NotifyWindow nw = new NotifyWindow("FG Code Expiry", Convert.ToDateTime(dr["ValidityDate"]).ToString("dd/MMM/yyyy"));
        //                        nw.Notify();
        //                    }
        //                }
        //            }



        //            //Select Bulk & Packing Details 
        //            DataSet dsPkgBulk = new DataSet();
        //            dsPkgBulk = FinishedGoodTest_Class_Obj.Select_FinishedGood_PackingBulkTestDetails();
        //            for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)
        //            {
        //                //dgKit.Rows.Add();
        //                //dgKit["TLFID", i].Value = dsPkgBulk.Tables[0].Rows[i]["TLFID"].ToString();
        //                //dgKit["FNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString();
        //                //dgKit["FormulaNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString();
        //                //dgKit["MfgWo", i].Value = dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();
        //                //dgKit["FGNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FGNo"].ToString();
        //                //dgKit["FGCode", i].Value = dsPkgBulk.Tables[0].Rows[i]["FGCode"].ToString();
        //                //dgKit["TrackCode", i].Value = Convert.ToDateTime(dsPkgBulk.Tables[0].Rows[i]["TrackCode"]).ToShortDateString();
        //                //dgKit["LineDesc", i].Value = dsPkgBulk.Tables[0].Rows[i]["LineDesc"].ToString();
        //                //LineSamplePackingDetails_Class objLineSamplePackingDetails_Class = new LineSamplePackingDetails_Class();
        //                //objLineSamplePackingDetails_Class.tlfid = Convert.ToInt32(dsPkgBulk.Tables[0].Rows[i]["TLFID"]);
        //                //DataSet dsFGTLF = objLineSamplePackingDetails_Class.Select_ModificationLinePackingDetails_Details();
        //                //if (dsFGTLF != null)
        //                //{
        //                //    if (dsFGTLF.Tables.Count > 0)
        //                //    {
        //                //        if (dsFGTLF.Tables[0].Rows.Count > 0)
        //                //        {
        //                //            dgKit["PkgWO", i].Value = dsFGTLF.Tables[0].Rows[0]["PkgWO"].ToString();
        //                //        }
        //                //    }
        //                //}
        //                ////dgKit["PkgWO", i].Value = dsPkgBulk.Tables[0].Rows[i]["PkgWOFG"].ToString();
        //                //dgKit["FillDate", i].Value = Convert.ToDateTime(dsPkgBulk.Tables[0].Rows[i]["FillDateFG"]).ToShortDateString();
        //                //dgKit["Price", i].Value = dsPkgBulk.Tables[0].Rows[i]["PriceFG"].ToString();
        //                //dgKit["specification", i].Value = dsPkgBulk.Tables[0].Rows[i]["specificationFG"].ToString();
        //                //dgKit["Status", i].Value = dsPkgBulk.Tables[0].Rows[i]["Status"].ToString();
        //            }

        //            //Display unit PackSize and Weight
        //            DataSet dsUnit;
        //            //for (int i = 0; i < dgKit.Rows.Count; i++)
        //            //{
        //            //    dsUnit = new DataSet();
        //            //    FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
        //            //    dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
        //            //    if (dsUnit.Tables[0].Rows.Count > 0)
        //            //    {
        //            //        if (dsUnit.Tables[0].Rows[0]["PackSize"] is DBNull)
        //            //        {

        //            //        }
        //            //        else
        //            //        {
        //            //            dgKit["PackSize", i].Value = dsUnit.Tables[0].Rows[0]["PackSize"].ToString();
        //            //        }

        //            //        if (dsUnit.Tables[0].Rows[0]["Weight"] is DBNull)
        //            //        {

        //            //        }
        //            //        else
        //            //        {
        //            //            dgKit["Weight", i].Value = dsUnit.Tables[0].Rows[0]["Weight"].ToString();
        //            //        }
        //            //    }
        //            //}


        //            //Add column in dgTest for Packing
        //            dgTest.Columns.Add("Packing", "Packing");
        //            dgTest.Columns["Packing"].Width = 100;
        //            dgTest.Columns["Packing"].ReadOnly = true;

        //            //Select PkgStatus from fgno,fno,trackcode,lno and display into packing cell 
        //            DataSet ds1 = new DataSet();
        //            ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPackingDetails_PkgStatus();
        //            if (ds1.Tables[0].Rows.Count > 0)
        //            {
        //                dgTest["packing", 0].Value = ds1.Tables[0].Rows[0]["PkgStatus"].ToString();
        //                FinishedGoodTest_Class_Obj.quantity = Convert.ToInt32(ds1.Tables[0].Rows[0]["Quantity"]);
        //            }
        //            else
        //            {
        //                dgTest["packing", 0].Value = "";
        //                FinishedGoodTest_Class_Obj.quantity = 0;
        //            }

        //            //add columns in dgTest depends on no of MfgWo
        //            for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)
        //            {
        //                //Check whether the column exists 
        //                if (dgTest.Columns.Contains(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()) == false)
        //                {
        //                    dgTest.Columns.Add(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString() + "\n" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString());
        //                    dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].Width = 100;
        //                    dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].ReadOnly = true;

        //                    FinishedGoodTest_Class_Obj.fno = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[i]["FNo"]);
        //                    FinishedGoodTest_Class_Obj.mfgwo = dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();

        //                    DataSet ds2 = new DataSet();
        //                    //Select PhyCheStatus from fgno,fno,trackcode,lno, mfgwo and display into cell
        //                    ds2 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus();
        //                    if (ds2.Tables[0].Rows.Count > 0)
        //                    {
        //                        dgTest[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), 0].Value = ds2.Tables[0].Rows[0]["PhyCheStatus"].ToString();
        //                    }
        //                    else
        //                    {
        //                        dgTest[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), 0].Value = "";
        //                    }
        //                }
        //            }

        //            //GET CONTROL TYPE FROM STP_Decide_ControlType STORED PROCEDURE
        //            //2/5 LOGIC
        //            txtControltype.Text = FinishedGoodTest_Class_Obj.Decide_ControlType_FG();
        //            FinishedGoodTest_Class_Obj.type = txtControltype.Text.Trim();

        //        }
        //        else
        //            RdoLaunch.Checked = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        /// <summary>
        /// resets the controls on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            //cmbDetails.Text = "--Select--";
            lstMfgWo.Items.Clear();
            CmbFgCode.SelectedValue = 0;
            CmbFormulaNo.SelectedValue = 0;
            ChkKit.Checked = false;
            ChkSF.Checked = false;
            txtFGDesc.Text = "";
            txtFGGlobalFamily.Text = "";
            txtFGTechnicalFamily.Text = "";
            cmbSupplier.SelectedValue = 0;
            txtBatchSize.Text = "";
            txtMfgWoNo.Text = "";
            DtpDateOfValidation.Value = Today;
            txtNorms.Text = "";
            txtDescription.Text = "";
            txtTechnicalFamily.Text = "";
            dtpdecisionDate.Value = Today;
            cmbFormulaType.Text = "--Select--";
            txtBatchCode.Text = "";
            txtFillVolume.Text = "";
            txtPrice.Text = "";
            txtSpecification.Text = "";
            DtpTrackCode.Value = Today;
            DtpFillDate.Value = Today;
            DtpInspDate.Value = Today;
            cmbLocation.Text = "--Select--";
            txtMfgWoNo.Text = "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0';


            txtFGDesc.Text = "";
            txtPkgFamily.Text = "";

            //    dgKit.Rows.Clear();
            dgTest.Columns.Clear();

            RdoAccepted.Checked = true;
            txtComment.Text = "";
            RdoBpc.Checked = false;
            RdoNonBpc.Checked = false;
            txtComment_NonBpc.Text = "";
            cmbInspectedBy.Text = "--Select--";
            RdoRegular.Checked = false;
            RdoLaunch.Checked = false;
            RdoPriceChange.Checked = false;
            RdoRenovation.Checked = false;
            RdoArtWorkChange.Checked = false;

            ChkReject.Visible = false;
            for (int i = 0; i < ChkReject.Items.Count; i++)
            {
                if (ChkReject.GetItemChecked(i) == true)
                {
                    ChkReject.SetItemChecked(i, false);
                }
            }
            lblNoOfDefets.Visible = false;
            txtNoOfDefects.Visible = false;
            txtNoOfDefects.Text = "";
            lblNoOfSamples.Visible = false;
            txtNoOfSamples.Visible = false;
            txtNoOfSamples.Text = "";

            cmbDetails.Focus();
            lblcoc.Text = "";
            ChkFinishedProduct.Checked = false;
            ChkSemiFinished.Checked = false;
            ChkWip.Checked = false;
            ChkAOCPending.Checked = false;
            txtAOCPending.Text = "";
            txtSemiFinished.Text = "";
        }

        /// <summary>
        /// close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// saves the finished good transaction details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbFormulaType.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Formula Type", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("please select Details", "Message");
                    return;
                }
                else
                {
                    if (GlobalVariables.City == "BADDI")
                    {
                        if (cmbLocation.SelectedValue == null || cmbLocation.Text == "--Select--")
                        {
                            MessageBox.Show("Please Select Retainer Location", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbLocation.Focus();
                            return;
                        }
                    }

                    //FinishedGoodTest_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                    //FinishedGoodTest_Class_Obj.cnt = 0;
                    //int icount = FinishedGoodTest_Class_Obj.Select_ValidityDate_FGCode();
                    //if (icount == 0)
                    //{
                    //Can't ACCEPT if any pack/phyche contains 'R'

                    for (int i = 0; i < dgTest.Columns.Count; i++)
                    {
                        if (dgTest[i, 0].Value == null)
                        {
                            MessageBox.Show("Please Enter Test Details.......", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }


                    bool R = false;

                    for (int i = 0; i < dgTest.Columns.Count; i++)
                    {
                        if (dgTest[i, 0].Value.ToString() == "R")
                        {
                            R = true;
                            break;
                        }

                    }
                    if (RdoAccepted.Checked == true && R == true)
                    {
                        MessageBox.Show("Sorry can't ACCEPT..!\n\nSome tests are rejected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RdoRejected.Focus();
                        return;
                    }
                    bool H = false;
                    for (int i = 0; i < dgTest.Columns.Count; i++)
                    {
                        if (dgTest[i, 0].Value.ToString() == "H")
                        {
                            H = true;
                            break;
                        }
                    }
                    if ((RdoAccepted.Checked == true || RdoRejected.Checked == true || RdoAWD.Checked == true || RdoTreatment.Checked == true) && H == true)
                    {
                        MessageBox.Show("Sorry can't ACCEPT..!\n\nSome tests are Hold", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RdoHold.Focus();
                        return;
                    }
                    if (RdoRejected.Checked && ChkReject.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Select Type for Reject.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChkReject.Focus();
                        return;
                    }

                    if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbInspectedBy.Focus();
                        return;
                    }
                    if (RdoNonBpc.Checked != true && RdoBpc.Checked != true)
                    {
                        MessageBox.Show("Select BPC/NonBPC", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (RdoNonBpc.Checked && txtComment_NonBpc.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Please Enter Comment For NonBPC", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (RdoRegular.Checked != true && RdoLaunch.Checked != true && RdoPriceChange.Checked != true && RdoArtWorkChange.Checked != true && RdoRenovation.Checked != true)
                    {
                        MessageBox.Show("Select Regular/Launch", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (RdoAccepted.Checked == true)
                    {
                        if (dgTest.Rows.Count > 0)
                        {
                            for (int i = 0; i < dgTest.Rows[0].Cells.Count; i++)
                            {
                                if (dgTest.Rows[0].Cells[i].Value.ToString().Trim() != "A")
                                {
                                    MessageBox.Show("All test must be accepted for");
                                    return;
                                }
                            }
                        }
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
                    if (RdoHold.Checked == true)
                    {
                        if (MessageBox.Show("HOLD ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoRegular.Checked == true)
                    {
                        if (MessageBox.Show("Regular ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoLaunch.Checked == true)
                    {
                        if (MessageBox.Show("Launch ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoPriceChange.Checked == true)
                    {
                        if (MessageBox.Show("Price Change ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoArtWorkChange.Checked == true)
                    {
                        if (MessageBox.Show("Art Work Change ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoRenovation.Checked == true)
                    {
                        if (MessageBox.Show("Renovation ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }

                    Flg_Save = true;

                    //----- Commented as per Nilesh's suggestion-----------

                    //if (RdoHold.Checked != true && FrmMain.UserType == 'N')
                    //{
                    //    MessageBox.Show("Sorry..\n\nYou can only HOLD the record", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}

                    //Insert unit details
                    DataSet dsUnit;
                    //for (int i = 0; i < dgKit.Rows.Count; i++)
                    //{
                    //    dsUnit = new DataSet();
                    //    FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                    //    FinishedGoodTest_Class_Obj.packsize = Convert.ToInt32(dgKit["PackSize", i].Value);
                    //    FinishedGoodTest_Class_Obj.weight = Convert.ToDouble(dgKit["Weight", i].Value);
                    //    dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                    //    if (dsUnit.Tables[0].Rows.Count > 0)
                    //    {
                    //        FinishedGoodTest_Class_Obj.Update_tblFinishedGoodUnitDetails();
                    //    }
                    //    else
                    //    {
                    //        FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodUnitDetails();
                    //    }
                    //}

                    FinishedGoodTest_SubContract_Class_Obj.testdate = Convert.ToString(dtpdecisionDate.Value);

                    if (RdoAccepted.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.status = "A";
                    }
                    else if (RdoHold.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.status = "H";
                    }
                    else if (RdoRejected.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.status = "R";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.status = "A";
                    }
                    else if (RdoTreatment.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.status = "R";
                    }


                    //------Actual Status------

                    if (RdoAccepted.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.actualstatus = "A";
                    }
                    else if (RdoHold.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.actualstatus = "H";
                    }
                    else if (RdoRejected.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.actualstatus = "R";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.actualstatus = "D";
                    }
                    else if (RdoTreatment.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.actualstatus = "T";
                    }

                    FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("N/A");
                    for (int i = 0; i < ChkReject.Items.Count; i++)
                    {
                        if (ChkReject.GetItemChecked(i) == true)
                        {
                            if (i == 0)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("ZD");
                                break;
                            }
                            else if (i == 1)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("ZN");
                                break;
                            }
                            else if (i == 2)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("Critical");
                                break;
                            }
                            else if (i == 3)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("Major");
                                break;
                            }
                            else if (i == 4)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("Minor");
                                break;
                            }
                            else if (i == 5)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("Bulk");
                                break;
                            }
                            else if (i == 6)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.rejectcomment = Convert.ToString("Other");
                                break;
                            }
                        }
                    }

                    if (txtNoOfDefects.Text.Trim() != "")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.noofdefects = Convert.ToInt32(txtNoOfDefects.Text.Trim());
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.noofdefects = 0;
                    }

                    if (txtNoOfSamples.Text.Trim() != "")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.noofsamples = Convert.ToInt32(txtNoOfSamples.Text.Trim());
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.noofsamples = 0;
                    }

                    FinishedGoodTest_SubContract_Class_Obj.Comment = txtComment.Text.Trim();
                    if (RdoBpc.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.decision = "B";
                        FinishedGoodTest_SubContract_Class_Obj.nonbpccomment = "";
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.decision = "N";
                        FinishedGoodTest_SubContract_Class_Obj.nonbpccomment = txtComment_NonBpc.Text;
                    }


                    if (RdoLaunch.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.catagory = "Launch";
                    }
                    else if (RdoPriceChange.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.catagory = "PriceChange";
                    }
                    else if (RdoArtWorkChange.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.catagory = "ArtWorkChange";
                    }
                    else if (RdoRenovation.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.catagory = "Renovation";
                    }
                    else if (RdoRegular.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.catagory = "N/A";
                    }

                    //this Flag describes that this is current record for this FGTLFID 
                    //IF any record get treatmented in treatment screen then new record added in tblFinishedGoodTestDetails which is currentflag =1 
                    //then for old record current flag is 0
                    //If record is for treatment then set currentflag =0
                    if (RdoTreatment.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.currentflag = 0;
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.currentflag = 1;
                    }

                    //this flag shows the record which are under the treatment process
                    //in transaction screen treatmentdone = 0
                    //and treatmentdone = 1 for both old and newly added record in treatment screen                    
                    FinishedGoodTest_SubContract_Class_Obj.treatmentdone = 0;

                    //this flag shows record which is added after treatment 
                    //For transation screen Treatmented = 0
                    //This flag is set for only for record which is added after treatment 
                    //In Treatment screen Treatmented = 1
                    //this flag is used to avoid record while deciding control type  
                    FinishedGoodTest_SubContract_Class_Obj.treatmented = 0;

                    FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                    FinishedGoodTest_SubContract_Class_Obj.loginid = FrmMain.LoginID;

                    FinishedGoodTest_SubContract_Class_Obj.FGSupplierID = Convert.ToInt64(cmbSupplier.SelectedValue);
                    if (txtBMR.Text != "")
                    {
                        string path = ConfigurationManager.AppSettings["BMRPath"].ToString();
                        path = path + "\\" + FinishedGoodTest_SubContract_Class_Obj.filename;

                        if (!File.Exists(path))
                        {
                            //File.Create(path);
                            File.Copy(FinishedGoodTest_SubContract_Class_Obj.filepath, path);
                        }
                        else
                        {
                            File.Delete(path);
                            File.Copy(FinishedGoodTest_SubContract_Class_Obj.filepath, path);
                        }

                        FinishedGoodTest_SubContract_Class_Obj.bmrfilepath = path;
                    }


                    //ControlType
                    //LNo

                    DataSet ds1 = new DataSet();
                    //Select FGTestNo from FGTLFID
                    ds1 = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodDetails_FGTLFID_SubContract();
                    if (ds1.Tables[0].Rows.Count > 0)  // if exists then modify
                    {
                        //update fg transaction details
                        FinishedGoodTest_SubContract_Class_Obj.fgtestno = Convert.ToInt64(ds1.Tables[0].Rows[0]["FGTestNo"]);
                        FinishedGoodTest_SubContract_Class_Obj.Update_tblFinishedGoodTestDetails_SubContract();
                    }
                    else // insert
                    {
                        //insert fg transaction details
                        FinishedGoodTest_SubContract_Class_Obj.fgtestno = FinishedGoodTest_SubContract_Class_Obj.Insert_tblFinishedGoodTestDetails_SubContract();
                    }


                    //update FGDone=1  in tblFGTLF from FGTLFID 
                    if (RdoHold.Checked != true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.fgdone = true;
                        FinishedGoodTest_SubContract_Class_Obj.Update_tblFGTLF_FGDone_SubContract();
                    }


                    string Column2 = CmbFormulaNo.Text + ' ' + txtMfgWoNo.Text;
                    //string[] lstMfgWoNo = txtMfgWoNo.Text.Split(',');

                    //Insert_tblFGTLF(Column2);
                    //for (int s = 0; s < lstMfgWoNo.Length; s++)
                    //{
                    //    string testcolumn = CmbFormulaNo.Text + ' ' + lstMfgWoNo[s].Trim();
                    //    Insert_tblFGTLF(testcolumn, lstMfgWoNo[s].Trim());
                    //}

                    for (int s = 0; s < lstMfgWo.Items.Count; s++)
                    {
                        string testcolumn = CmbFormulaNo.Text + ' ' + lstMfgWo.Items[s].ToString().Trim();
                        Insert_tblFGTLF(testcolumn, lstMfgWo.Items[s].ToString().Trim());

                        FinishedGoodTest_SubContract_Class_Obj.Update_tblTransFMFinishedGoods_SubContract_tblTransTLF_SubContract_Status();

                        Insert_PackingDetails();
                    }


                    

                    MessageBox.Show("Record Saved Successfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Bind_Details();
                    BtnReset_Click(sender, e);
                    //}
                    //else if (icount == 1)
                    //{
                    //    MessageBox.Show("Sorry Validity Date Of this FGCode is Expired", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// checked change event for Non BPC radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoNonBpc_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoNonBpc.Checked == true)
            {
                txtComment_NonBpc.Enabled = true;
                txtComment_NonBpc.Focus();
            }
        }

        /// <summary>
        /// checked change event for BPC radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoBpc_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoBpc.Checked == true)
            {
                txtComment_NonBpc.Text = "";
                txtComment_NonBpc.Enabled = false;
            }
        }

        /// <summary>
        /// checked change event for Rejected radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoRejected_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoRejected.Checked == true)
            {
                RdoAWD.Visible = true;
                RdoTreatment.Visible = true;
                ChkReject.Visible = true;
                lblNoOfDefets.Visible = true;
                txtNoOfDefects.Visible = true;
                lblNoOfSamples.Visible = true;
                txtNoOfSamples.Visible = true;

                //if rejected then NonBPC
                RdoNonBpc.Checked = true;
            }
        }

        /// <summary>
        /// checked change event for accept radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoAccepted_CheckedChanged(object sender, EventArgs e)
        {
            RdoAWD.Visible = false;
            RdoTreatment.Visible = false;
            ChkReject.Visible = false;
            lblNoOfDefets.Visible = false;
            txtNoOfDefects.Visible = false;
            txtNoOfDefects.Text = "";
            lblNoOfSamples.Visible = false;
            txtNoOfSamples.Visible = false;
            txtNoOfSamples.Text = "";

            for (int i = 0; i < ChkReject.Items.Count; i++)
            {
                if (ChkReject.GetItemChecked(i) == true)
                {
                    ChkReject.SetItemChecked(i, false);
                }
            }
        }

        /// <summary>
        /// checked change enevt for Hold radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoHold_CheckedChanged(object sender, EventArgs e)
        {
            RdoAWD.Visible = false;
            RdoTreatment.Visible = false;
            ChkReject.Visible = false;
            lblNoOfDefets.Visible = false;
            txtNoOfDefects.Visible = false;
            txtNoOfDefects.Text = "";
            lblNoOfSamples.Visible = false;
            txtNoOfSamples.Visible = false;
            txtNoOfSamples.Text = "";
            for (int i = 0; i < ChkReject.Items.Count; i++)
            {
                if (ChkReject.GetItemChecked(i) == true)
                {
                    ChkReject.SetItemChecked(i, false);
                }
            }
        }

        /// <summary>
        /// Click event for Reject Check list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (ChkReject.GetItemCheckState(ChkReject.SelectedIndex) == CheckState.Unchecked)
                {
                    ChkReject.SetItemCheckState(ChkReject.SelectedIndex, CheckState.Checked);
                }
                else if (ChkReject.GetItemCheckState(ChkReject.SelectedIndex) == CheckState.Checked)
                {
                    ChkReject.SetItemCheckState(ChkReject.SelectedIndex, CheckState.Unchecked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Item check event for Reject Check list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkReject_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Can select only one item
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < ChkReject.Items.Count; i++)
                {
                    if (e.Index != i)
                    {
                        ChkReject.SetItemChecked(i, false);
                    }
                }
            }
        }

        /// <summary>
        /// Edit control showing event for details grid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgKit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgKit.CurrentCell.ReadOnly == false)
            //{
            //    dgKit.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            //}
        }

        /// <summary>
        /// key press event to enter integer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// key press event for No of Defect text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNoOfDefects_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// key press event for No of sample text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNoOfSamples_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// cell click event for dgTest
        /// opens the pop up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                string header = dgTest.Columns[e.ColumnIndex].HeaderText;
                //if (e.ColumnIndex == dgTest.Columns[0].Index) 
                if (header == "Packing")//Packing
                {
                    FrmFGPackingTest_SubContract.Detail detail_Obj = new FrmFGPackingTest_SubContract.Detail();
                    detail_Obj.D_fgtlfid = FinishedGoodTest_SubContract_Class_Obj.fgtlfid;
                    detail_Obj.D_pkgtechno = FinishedGoodTest_SubContract_Class_Obj.pkgtechno;
                    detail_Obj.D_type = FinishedGoodTest_SubContract_Class_Obj.type;
                    detail_Obj.D_fgno = FinishedGoodTest_SubContract_Class_Obj.fgno;
                    detail_Obj.D_fno = FinishedGoodTest_SubContract_Class_Obj.fno;
                    detail_Obj.D_flagrl = FinishedGoodTest_SubContract_Class_Obj.flagrl;
                    detail_Obj.D_Quantity = FinishedGoodTest_SubContract_Class_Obj.quantity;
                    detail_Obj.D_InspctedBy = FinishedGoodTest_SubContract_Class_Obj.inspectedby;
                    FinishedGoodTest_Class_Obj.fgno = FinishedGoodTest_SubContract_Class_Obj.fgno;
                    detail_Obj.D_COC = FinishedGoodTest_SubContract_Class_Obj.coc;
                    detail_Obj.D_SupploerID = Convert.ToInt32(cmbSupplier.SelectedValue);
                    detail_Obj.D_Supplier = cmbSupplier.Text;
                    detail_Obj.D_FGCode = CmbFgCode.Text;
                    detail_Obj.D_FormulaNo = CmbFormulaNo.Text;
                    detail_Obj.D_Packing = FinishedGoodTest_SubContract_Class_Obj.packing;

                    if (dgTest[e.ColumnIndex, e.RowIndex].Value == null)
                        detail_Obj.D_pkgstatus = "";
                    else
                        detail_Obj.D_pkgstatus = dgTest[e.ColumnIndex, e.RowIndex].Value.ToString();

                    if (dgTest[e.ColumnIndex, e.RowIndex].Value == null || dgTest[e.ColumnIndex, 0].Value.ToString() == "")
                    {
                        detail_Obj.Done = 'N';
                    }
                    else
                    {
                        detail_Obj.Done = 'Y';
                    }

                    //Display FG Packing Test form
                    FrmFGPackingTest_SubContract fmPack = new FrmFGPackingTest_SubContract(detail_Obj);
                    fmPack.ShowDialog();

                    DataSet ds1 = new DataSet();
                    //Select PkgStatus from fgno,trackcode,lno
                    ds1 = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodPackingDetails_PkgStatus_SubContract();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, e.RowIndex].Value = ds1.Tables[0].Rows[0]["PkgStatus"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.quantity = Convert.ToInt32(ds1.Tables[0].Rows[0]["Quantity"]);
                        FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt64(ds1.Tables[0].Rows[0]["InspectedBy"]);
                    }


                }
                else if (header.Contains("Preservative"))
                {
                    string Str = header;
                    Str = Str.Replace("Preservative", "");

                    FinishedGoodTest_SubContract_Class_Obj.mfgwo = Str.Trim();

                    DataSet dsFMID = new DataSet();
                    dsFMID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransFMFinishedGoods_SubContract_FMID();
                    if (dsFMID.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.fmid = Convert.ToInt64(dsFMID.Tables[0].Rows[0]["FMID"]);
                    }

                    FrmPreservativeTestSubContract frmPres = new FrmPreservativeTestSubContract(FinishedGoodTest_SubContract_Class_Obj.fmid, FinishedGoodTest_SubContract_Class_Obj.coc, FinishedGoodTest_SubContract_Class_Obj.physicochemical);
                    frmPres.ShowDialog();

                    DataSet ds2 = new DataSet();
                    ds2 = FinishedGoodTest_SubContract_Class_Obj.Select_tblPreservativetest_SubContract_Status();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, e.RowIndex].Value = ds2.Tables[0].Rows[0]["Status"].ToString();
                    }
                }
                else if (header.Contains("Micro"))
                {
                    string Str = header;
                    Str = Str.Replace("Micro", "");

                    FinishedGoodTest_SubContract_Class_Obj.mfgwo = Str.Trim();

                    DataSet dsFMID = new DataSet();
                    dsFMID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransFMFinishedGoods_SubContract_FMID();
                    if (dsFMID.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.fmid = Convert.ToInt64(dsFMID.Tables[0].Rows[0]["FMID"]);
                    }

                    DataSet dsTLFID = new DataSet();
                    dsTLFID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransTLF_SubContract_TLFID();
                    if (dsTLFID.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.TLFID = Convert.ToInt64(dsTLFID.Tables[0].Rows[0]["TLFID"]);
                    }

                    FrmMicrobiologyTest_SubContract frmMicro = new FrmMicrobiologyTest_SubContract(FinishedGoodTest_SubContract_Class_Obj.TLFID, FinishedGoodTest_SubContract_Class_Obj.micro);
                    frmMicro.ShowDialog();

                    DataSet ds2 = new DataSet();
                    ds2 = FinishedGoodTest_SubContract_Class_Obj.Select_tblMicrobiologytest_SubContract_Status();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, e.RowIndex].Value = ds2.Tables[0].Rows[0]["Status"].ToString();
                    }
                }
                else //if (e.ColumnIndex > 0)   //Physico-Chemical
                {
                    string Str = header;
                    Str = Str.Replace(CmbFormulaNo.Text, "");

                    FrmFGPhysicoChemicalTest_SubContract.Detail detail_Obj = new FrmFGPhysicoChemicalTest_SubContract.Detail();
                    detail_Obj.D_fgtlfid = FinishedGoodTest_SubContract_Class_Obj.fgtlfid;
                    detail_Obj.D_fno = FinishedGoodTest_SubContract_Class_Obj.fno;
                    detail_Obj.D_pkgtechno = FinishedGoodTest_SubContract_Class_Obj.pkgtechno;
                    detail_Obj.D_type = FinishedGoodTest_SubContract_Class_Obj.type;
                    detail_Obj.D_COC = FinishedGoodTest_SubContract_Class_Obj.coc;
                    //detail_Obj.D_fmid = FinishedGoodTest_SubContract_Class_Obj.fmid;

                    FinishedGoodTest_SubContract_Class_Obj.mfgwo = Str.Trim();

                    DataSet dsFMID = new DataSet();
                    dsFMID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransFMFinishedGoods_SubContract_FMID();
                    if (dsFMID.Tables[0].Rows.Count > 0)
                    {
                        detail_Obj.D_fmid = Convert.ToInt64(dsFMID.Tables[0].Rows[0]["FMID"]);
                        FinishedGoodTest_SubContract_Class_Obj.fmid = detail_Obj.D_fmid;
                    }


                    detail_Obj.D_inspectedby = FinishedGoodTest_SubContract_Class_Obj.inspectedby;
                    detail_Obj.D_SupplierID = FinishedGoodTest_SubContract_Class_Obj.FGSupplierID;
                    detail_Obj.D_physicochemical = FinishedGoodTest_SubContract_Class_Obj.physicochemical;

                    if (dgTest[e.ColumnIndex, e.RowIndex].Value == null || dgTest[e.ColumnIndex, 0].Value.ToString() == "")
                        detail_Obj.D_phychestatus = "";
                    else
                        detail_Obj.D_phychestatus = dgTest[e.ColumnIndex, e.RowIndex].Value.ToString();

                    if (dgTest[e.ColumnIndex, e.RowIndex].Value == null || dgTest[e.ColumnIndex, 0].Value.ToString() == "")
                    {
                        detail_Obj.Done = 'N';
                    }
                    else
                    {
                        detail_Obj.Done = 'Y';
                    }
                    detail_Obj.D_FormulaNo = CmbFormulaNo.Text;
                    detail_Obj.D_fno = FinishedGoodTest_SubContract_Class_Obj.fno;
                    detail_Obj.D_mfgwo = FinishedGoodTest_SubContract_Class_Obj.mfgwo;

                    //Display FG Physico-Chemical Test form
                    FrmFGPhysicoChemicalTest_SubContract fmPhy = new FrmFGPhysicoChemicalTest_SubContract(detail_Obj);
                    fmPhy.ShowDialog();

                    DataSet PhyCheStatus = new DataSet();
                    PhyCheStatus = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus_SubContract();
                    if (PhyCheStatus.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, e.RowIndex].Value = PhyCheStatus.Tables[0].Rows[0]["PhyCheStatus"].ToString();
                        //FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt64(PhyCheStatus.Tables[0].Rows[0]["InspectedBy"]);
                    }

                    //DataSet ds1 = new DataSet();
                    ////Select PhyCheStatus from fgno,fno,trackcode,lno
                    //ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus();
                    //if (ds1.Tables[0].Rows.Count > 0)
                    //{
                    //    dgTest[e.ColumnIndex, e.RowIndex].Value = ds1.Tables[0].Rows[0]["PhyCheStatus"].ToString();
                    //}

                }
            }

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }


        private void CmbFgCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                txtFGDesc.Text = "";
                txtFGGlobalFamily.Text = "";
                txtFGTechnicalFamily.Text = "";
                txtDescription.Text = "";
                txtTechnicalFamily.Text = "";

                dgTest.Rows.Clear();
                CmbFormulaNo.Text = "--Select--";
                cmbSupplier.Text = "--Select--";
                lblcoc.Text = "";

                if (CmbFgCode.SelectedValue != null && Convert.ToString(CmbFgCode.SelectedValue) != "0")
                {
                    //Reset();
                    DataSet ds = new DataSet();
                    //FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue.ToString());
                    FinishedGoodTest_SubContract_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue.ToString());
                    ds = FinishedGoodTest_SubContract_Class_Obj.SELECT_FinishedGood_SubContract_FGNo();

                    txtFGDesc.Text = ds.Tables[0].Rows[0]["FGDesc"].ToString();
                    txtFGTechnicalFamily.Text = ds.Tables[0].Rows[0]["TechFamDesc"].ToString();
                    txtFGGlobalFamily.Text = ds.Tables[0].Rows[0]["FGGlobalFamilyName"].ToString();
                    FinishedGoodTest_SubContract_Class_Obj.pkgtechno = Convert.ToInt64(ds.Tables[0].Rows[0]["PKGTechNo"]);

                    //PackingFamilyMaster_Class_Obj.pkgtechno = Convert.ToInt64(ds.Tables[0].Rows[0]["PKGTechNo"]);                
                    //CmbTechnicalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["PkgTechNo"]);
                    //if (ds.Tables[0].Rows[0]["FGGlobalFamilyID"] is System.DBNull)
                    //{
                    //    CmbFGGlobalFamily.SelectedValue = 0;
                    //}
                    //else
                    //{
                    //    CmbFGGlobalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["FGGlobalFamilyID"]);
                    //}
                    Bind_FormulaNumber();
                    Bind_FGSupplier();


                    /*DataSet dsPkgBulk = new DataSet();
                    dsPkgBulk = FinishedGoodTest_Class_Obj.Select_FinishedGood_PackingBulkTestDetails();


                    //Add column in dgTest for Packing
                    dgTest.Columns.Add("Packing", "Packing");
                    dgTest.Columns["Packing"].Width = 100;
                    dgTest.Columns["Packing"].ReadOnly = true;

                    //Select PkgStatus from fgno,fno,trackcode,lno and display into packing cell 
                    DataSet ds1 = new DataSet();
                    ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPackingDetails_PkgStatus();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dgTest["packing", 0].Value = ds1.Tables[0].Rows[0]["PkgStatus"].ToString();
                        FinishedGoodTest_Class_Obj.quantity = Convert.ToInt32(ds1.Tables[0].Rows[0]["Quantity"]);
                    }
                    else
                    {
                        dgTest["packing", 0].Value = "";
                        FinishedGoodTest_Class_Obj.quantity = 0;
                    }

                    //add columns in dgTest depends on no of MfgWo
                    for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)
                    {
                        //Check whether the column exists 
                        if (dgTest.Columns.Contains(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()) == false)
                        {
                            dgTest.Columns.Add(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString() + "\n" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString());
                            dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].Width = 100;
                            dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].ReadOnly = true;

                            FinishedGoodTest_Class_Obj.fno = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[i]["FNo"]);
                            FinishedGoodTest_Class_Obj.mfgwo = dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();

                            DataSet ds2 = new DataSet();
                            //Select PhyCheStatus from fgno,fno,trackcode,lno, mfgwo and display into cell
                            ds2 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus();
                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                dgTest[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), 0].Value = ds2.Tables[0].Rows[0]["PhyCheStatus"].ToString();
                            }
                            else
                            {
                                dgTest[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), 0].Value = "";
                            }
                        }
                    }


                    */

                    DataSet dsF = new DataSet();
                    FinishedGoodTest_SubContract_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                    dsF = FinishedGoodTest_SubContract_Class_Obj.Select_SubContract_FlagRL();
                    if (dsF.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.flagrl = 'R';
                        NotifyWindow nw = new NotifyWindow("Regular", Convert.ToString(ds.Tables[0].Rows[0]["FGCode"]));
                        nw.Notify();
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.flagrl = 'L';
                        NotifyWindow nw = new NotifyWindow("New Launch", Convert.ToString(ds.Tables[0].Rows[0]["FGCode"]));
                        nw.Notify();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_FormulaNumber()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            FinishedGoodTest_SubContract_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue.ToString());
            ds = FinishedGoodTest_SubContract_Class_Obj.SELECT_FormulaNumber_SubContract_FGNo();

            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            CmbFormulaNo.DataSource = ds.Tables[0];
            CmbFormulaNo.DisplayMember = "FormulaNo";
            CmbFormulaNo.ValueMember = "FNo";
        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            txtTechnicalFamily.Text = "";
            lblcoc.Text = "";

            dgTest.Rows.Clear();
            if (CmbFormulaNo.SelectedValue != null && Convert.ToString(CmbFormulaNo.SelectedValue) != "0")
            {
                //Get the details of the formula
                DataSet ds = new DataSet();
                FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                FinishedGoodTest_SubContract_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                ds = FormulaNoMaster_Class_Obj.SELECT_TblBulkMaster_tblblkfamilyMaster();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);
                    //txtNoofBatches.Text = Convert.ToString(ds.Tables[0].Rows[0]["noofbatches"]);
                    txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);
                }
            }
        }

        private void txtMfgWoNo_Leave(object sender, EventArgs e)
        {
            if (CmbFormulaNo.SelectedIndex == 0 || CmbFormulaNo.Text == "--Select--")
            {
                MessageBox.Show("please select Formula No.", "Message");
                return;
            }
            if (cmbSupplier.SelectedIndex == 0 || cmbSupplier.Text == "--Select--")
            {
                MessageBox.Show("please select Supplier.", "Message");
                return;
            }


            FinishedGoodTest_SubContract_Class_Obj.FGSupplierID = Convert.ToInt64(cmbSupplier.SelectedValue);
            DataSet ds = new DataSet();
            ds = FinishedGoodTest_SubContract_Class_Obj.Select_MicroPhysicochemical_SubContract();

            if (ds.Tables[0].Rows.Count > 0)
            {
                FinishedGoodTest_SubContract_Class_Obj.coc = ds.Tables[0].Rows[0]["COC"].ToString();
                FinishedGoodTest_SubContract_Class_Obj.micro = Convert.ToBoolean(ds.Tables[0].Rows[0]["Micro"]);
                FinishedGoodTest_SubContract_Class_Obj.physicochemical = Convert.ToBoolean(ds.Tables[0].Rows[0]["Physicochemical"]);
                FinishedGoodTest_SubContract_Class_Obj.packing = Convert.ToBoolean(ds.Tables[0].Rows[0]["Packing"]);
            }

            dgTest.Rows.Clear();
            dgTest.Columns.Clear();

            string Column2 = CmbFormulaNo.Text + ' ' + txtMfgWoNo.Text;

            //string[] lstMfgWoNo = txtMfgWoNo.Text.Split(',');

            DataSet ds_Formula = new DataSet();
            FinishedGoodTest_SubContract_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
            ds_Formula = FinishedGoodTest_SubContract_Class_Obj.Select_CheckPreservativeTest();

            if (FinishedGoodTest_SubContract_Class_Obj.coc != "Yes")
            {
                //Add column in dgTest for Packing
                dgTest.Columns.Add("Packing", "Packing");
                dgTest.Columns["Packing"].Width = 100;
                dgTest.Columns["Packing"].ReadOnly = true;

                //Add column in dgTest for Physicochemical
                dgTest.Columns.Add(Column2, Column2);
                dgTest.Columns[Column2].Width = 120;
                dgTest.Columns[Column2].ReadOnly = true;

                ////for (int s = 0; s < lstMfgWoNo.Length; s++)
                ////{
                ////    string testcolumn = CmbFormulaNo.Text + ' ' + lstMfgWoNo[s].Trim();
                ////    dgTest.Columns.Add(testcolumn, testcolumn);
                ////    dgTest.Columns[testcolumn].Width = 120;
                ////    dgTest.Columns[testcolumn].ReadOnly = true;
                ////}


                if (ds_Formula.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["PreservativeTest"]) == true)
                    {
                        dgTest.Columns.Add("Preservative", "Preservative");
                        dgTest.Columns["Preservative"].Width = 80;
                        dgTest.Columns["Preservative"].ReadOnly = true;
                    }
                    if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["MicrobiologyTest"]) == true)
                    {
                        dgTest.Columns.Add("Micro", "Micro");
                        dgTest.Columns["Micro"].Width = 80;
                        dgTest.Columns["Micro"].ReadOnly = true;
                    }
                }
            }
            else
            {
                //if (FinishedGoodTest_SubContract_Class_Obj.packing == true)
                {
                    dgTest.Columns.Add("Packing", "Packing");
                    dgTest.Columns["Packing"].Width = 100;
                    dgTest.Columns["Packing"].ReadOnly = true;
                }
                //if (FinishedGoodTest_SubContract_Class_Obj.physicochemical == true)
                {
                    dgTest.Columns.Add(Column2, Column2);
                    dgTest.Columns[Column2].Width = 120;
                    dgTest.Columns[Column2].ReadOnly = true;

                    ////for (int s = 0; s < lstMfgWoNo.Length; s++)
                    ////{
                    ////    string testcolumn = CmbFormulaNo.Text + ' ' + lstMfgWoNo[s].Trim();
                    ////    dgTest.Columns.Add(testcolumn, testcolumn);
                    ////    dgTest.Columns[testcolumn].Width = 120;
                    ////    dgTest.Columns[testcolumn].ReadOnly = true;
                    ////}
                }

                if (ds_Formula.Tables[0].Rows.Count > 0)
                {
                    //if (FinishedGoodTest_SubContract_Class_Obj.physicochemical == true)
                    {
                        if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["PreservativeTest"]) == true)
                        {
                            dgTest.Columns.Add("Preservative", "Preservative");
                            dgTest.Columns["Preservative"].Width = 80;
                            dgTest.Columns["Preservative"].ReadOnly = true;
                        }
                    }

                    if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["MicrobiologyTest"]) == true)
                    {
                        dgTest.Columns.Add("Micro", "Micro");
                        dgTest.Columns["Micro"].Width = 80;
                        dgTest.Columns["Micro"].ReadOnly = true;
                    }
                }

                //if (FinishedGoodTest_SubContract_Class_Obj.micro == true)
                //{
                //    dgTest.Columns.Add("Micro", "Micro");
                //    dgTest.Columns["Micro"].Width = 80;
                //    dgTest.Columns["Micro"].ReadOnly = true;
                //}
            }






            /* 
             if (pres == true)
             {
                 dgTest.Columns.Add("Preservative", "Preservative");
                 dgTest.Columns["Preservative"].Width = 80;
                 dgTest.Columns["Preservative"].ReadOnly = true;
             }

             if (FinishedGoodTest_SubContract_Class_Obj.micro == true)
             {
                 dgTest.Columns.Add("Micro","Micro");
                 dgTest.Columns["Micro"].Width = 80;
                 dgTest.Columns["Micro"].ReadOnly = true;
             }
             if (FinishedGoodTest_SubContract_Class_Obj.physicochemical == true)
             {
                 //dgTest.Columns.Add("Physicochemical", "Physicochemical");
                 //dgTest.Columns["Physicochemical"].Width = 120;
                 //dgTest.Columns["Physicochemical"].ReadOnly = true;

                 dgTest.Columns.Add(Column2, Column2);
                 dgTest.Columns[Column2].Width = 120;
                 dgTest.Columns[Column2].ReadOnly = true;
             }
             */

            //Insert_tblFGTLF(Column2);

            ////for (int s = 0; s < lstMfgWoNo.Length; s++)
            ////{
            ////    string testcolumn = CmbFormulaNo.Text + ' ' + lstMfgWoNo[s].Trim();
            ////    Insert_tblFGTLF(testcolumn, lstMfgWoNo[s].Trim());
            ////}

            FinishedGoodTest_SubContract_Class_Obj.type = FinishedGoodTest_SubContract_Class_Obj.Decide_ControlType_FG_SubContract();
        }

        public void Insert_tblFGTLF(string test, string MfgWo)
        //public void Insert_tblFGTLF(string test)
        {
            FinishedGoodTest_SubContract_Class_Obj.trackcode = DtpTrackCode.Value.ToShortDateString();
            FinishedGoodTest_SubContract_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
            FinishedGoodTest_SubContract_Class_Obj.filldate = DtpFillDate.Value.ToShortDateString();
            //FinishedGoodTest_SubContract_Class_Obj.pkgwo = txtPkgWoNo.Text.Trim();
            FinishedGoodTest_SubContract_Class_Obj.price = txtPrice.Text.Trim();
            FinishedGoodTest_SubContract_Class_Obj.Specification = txtSpecification.Text.Trim();
            if (ChkAOCPending.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.aocPend = Convert.ToChar("Y");
                FinishedGoodTest_SubContract_Class_Obj.commentsaoc = txtAOCPending.Text.Trim();
            }
            else
            {
                FinishedGoodTest_SubContract_Class_Obj.aocPend = Convert.ToChar("N");
                FinishedGoodTest_SubContract_Class_Obj.commentsaoc = "";
            }
            FinishedGoodTest_SubContract_Class_Obj.batchno = txtBatchCode.Text.Trim();
            FinishedGoodTest_SubContract_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
            //FinishedGoodTest_SubContract_Class_Obj.mfgwo = txtMfgWoNo.Text.Trim();
            FinishedGoodTest_SubContract_Class_Obj.mfgwo = MfgWo;
            FinishedGoodTest_SubContract_Class_Obj.FGSupplierID = Convert.ToInt64(cmbSupplier.SelectedValue);
            if (ChkSemiFinished.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.seminished = Convert.ToChar("Y");
                FinishedGoodTest_SubContract_Class_Obj.commentsssf = txtSemiFinished.Text.Trim();
            }
            else
            {
                FinishedGoodTest_SubContract_Class_Obj.seminished = Convert.ToChar("N");
                FinishedGoodTest_SubContract_Class_Obj.commentsssf = "";
            }
            if (ChkWip.Checked == true)
                FinishedGoodTest_SubContract_Class_Obj.wip = Convert.ToChar("Y");
            else
                FinishedGoodTest_SubContract_Class_Obj.wip = Convert.ToChar("N");
            if (ChkFinishedProduct.Checked == true)
                FinishedGoodTest_SubContract_Class_Obj.finishedproduct = Convert.ToChar("Y");
            else
                FinishedGoodTest_SubContract_Class_Obj.finishedproduct = Convert.ToChar("N");

            //check whether combination of TrackCode,LNo,FGNo already exists in tblFGTLF 
            DataSet dsFGTLFID = new DataSet();
            dsFGTLFID = FinishedGoodTest_SubContract_Class_Obj.Select_tblFGTLF_SubContract_FGTLFID();
            if (dsFGTLFID.Tables[0].Rows.Count > 0)
            {
                FinishedGoodTest_SubContract_Class_Obj.fgtlfid = Convert.ToInt64(dsFGTLFID.Tables[0].Rows[0]["FGTLFID"]);
                FinishedGoodTest_SubContract_Class_Obj.Update_tblFGTLF_SubContract();
                DataSet ds1 = new DataSet();
                //Select PkgStatus from fgno,trackcode,lno
                ds1 = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodPackingDetails_PkgStatus_SubContract();
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    dgTest[0, 0].Value = ds1.Tables[0].Rows[0]["PkgStatus"].ToString();
                    FinishedGoodTest_SubContract_Class_Obj.quantity = Convert.ToInt32(ds1.Tables[0].Rows[0]["Quantity"]);
                    FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt64(ds1.Tables[0].Rows[0]["InspectedBy"]);
                }
                else
                {
                    FinishedGoodTest_SubContract_Class_Obj.quantity = 0;
                    FinishedGoodTest_SubContract_Class_Obj.inspectedby = 0;
                }
            }
            else
            {
                //Insert trackCode, Line No and FGCode into FGTLF Master 
                FinishedGoodTest_SubContract_Class_Obj.fgtlfid = FinishedGoodTest_SubContract_Class_Obj.Insert_tblFGTLF_SubContract();

                FinishedGoodTest_SubContract_Class_Obj.quantity = 0;
                FinishedGoodTest_SubContract_Class_Obj.inspectedby = 0;
            }

            DataSet dsFMID = new DataSet();
            dsFMID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransFMFinishedGoods_SubContract_FMID();
            if (dsFMID.Tables[0].Rows.Count > 0)
            {
                FinishedGoodTest_SubContract_Class_Obj.fmid = Convert.ToInt64(dsFMID.Tables[0].Rows[0]["FMID"]);

                DataSet PhyCheStatus = new DataSet();
                PhyCheStatus = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus_SubContract();
                if (PhyCheStatus.Tables[0].Rows.Count > 0)
                {
                    dgTest[test, 0].Value = PhyCheStatus.Tables[0].Rows[0]["PhyCheStatus"].ToString();
                    FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt64(PhyCheStatus.Tables[0].Rows[0]["InspectedBy"]);
                }
            }
            else
                FinishedGoodTest_SubContract_Class_Obj.fmid = FinishedGoodTest_SubContract_Class_Obj.Insert_tblTransFMFinishedGoods_SubContract();



            //Insert For tblTransTLF_SubContract (Microbiology Test)
            DataSet dsTLFID = new DataSet();
            dsTLFID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransTLF_SubContract_TLFID();
            if (dsTLFID.Tables[0].Rows.Count > 0)
            {
                FinishedGoodTest_SubContract_Class_Obj.TLFID = Convert.ToInt64(dsTLFID.Tables[0].Rows[0]["TLFID"]);
                FinishedGoodTest_SubContract_Class_Obj.sf = ChkSF.Checked;
                FinishedGoodTest_SubContract_Class_Obj.kit = ChkKit.Checked;
                FinishedGoodTest_SubContract_Class_Obj.Update_tblTransTLF_SubContract();

                DataSet ds2 = new DataSet();
                ds2 = FinishedGoodTest_SubContract_Class_Obj.Select_tblMicrobiologytest_SubContract_Status();
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    dgTest["Micro " + MfgWo, 0].Value = ds2.Tables[0].Rows[0]["Status"].ToString();
                }
            }
            else
                FinishedGoodTest_SubContract_Class_Obj.TLFID = FinishedGoodTest_SubContract_Class_Obj.Insert_tblTransTLF_SubContract();



            DataSet dsPres = new DataSet();
            dsPres = FinishedGoodTest_SubContract_Class_Obj.Select_tblPreservativetest_SubContract_Status();
            if (dsPres.Tables[0].Rows.Count > 0)
            {
                dgTest["Preservative " + MfgWo, 0].Value = dsPres.Tables[0].Rows[0]["Status"].ToString();
            }

            if (Flg_Save == false)
            {
                //FillReturnIF_FinisgedGoodDone();
            }


        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            string fileName = "", filePath = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                FinishedGoodTest_SubContract_Class_Obj.filepath = openFileDialog1.FileName;
                FinishedGoodTest_SubContract_Class_Obj.filename = System.IO.Path.GetFileName(FinishedGoodTest_SubContract_Class_Obj.filepath);
                txtBMR.Text = FinishedGoodTest_SubContract_Class_Obj.filename;
            }


        }

        private void Insert_PackingDetails()
        {
            FinishedGoodTest_SubContract_Class_Obj.TLFID = FinishedGoodTest_SubContract_Class_Obj.TLFID;

            FinishedGoodTest_SubContract_Class_Obj.batchno = txtBatchCode.Text.Trim();
            FinishedGoodTest_SubContract_Class_Obj.fillvolume = txtFillVolume.Text.Trim();
            //FinishedGoodTest_SubContract_Class_Obj.pkgwo = txtPkgWoNo.Text.Trim();
            FinishedGoodTest_SubContract_Class_Obj.price = txtPrice.Text.Trim();
            FinishedGoodTest_SubContract_Class_Obj.Specification = txtSpecification.Text.Trim();
            FinishedGoodTest_SubContract_Class_Obj.filldate = DtpFillDate.Value.ToShortDateString();
            FinishedGoodTest_SubContract_Class_Obj.inspdate = DtpInspDate.Value.ToShortDateString();

            if (ChkSemiFinished.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.proddecsf = Convert.ToChar("Y");
                FinishedGoodTest_SubContract_Class_Obj.commentssf = txtSemiFinished.Text.Trim();
            }
            else
            {
                FinishedGoodTest_SubContract_Class_Obj.proddecsf = Convert.ToChar("N");
                FinishedGoodTest_SubContract_Class_Obj.commentssf = "";
            }
            if (ChkAOCPending.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.aocPend = Convert.ToChar("Y");
                FinishedGoodTest_SubContract_Class_Obj.commentsaoc = txtAOCPending.Text.Trim();
            }
            else
            {
                FinishedGoodTest_SubContract_Class_Obj.aocPend = Convert.ToChar("N");
                FinishedGoodTest_SubContract_Class_Obj.commentsaoc = "";
            }

            if (ChkWip.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.proddecwip = Convert.ToChar("Y");
            }
            else
            {
                FinishedGoodTest_SubContract_Class_Obj.proddecwip = Convert.ToChar("N");
            }

            if (ChkFinishedProduct.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.proddecfp = Convert.ToChar("Y");
            }
            else
            {
                FinishedGoodTest_SubContract_Class_Obj.proddecfp = Convert.ToChar("N");
            }

            if (RdoAccepted.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.packingstatus = Convert.ToChar("A");
            }
            if (RdoRejected.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.packingstatus = Convert.ToChar("R");
            }

            FinishedGoodTest_SubContract_Class_Obj.comments = txtComment.Text.Trim();

            FinishedGoodTest_SubContract_Class_Obj.locationid = Convert.ToInt64(cmbLocation.SelectedValue);

            FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

            FinishedGoodTest_SubContract_Class_Obj.loginid = FrmMain.LoginID;
            //Remove for create logic kit mapping in regluar fg 02-08-2017
            //if (ChkKit.Checked == false && ChkSF.Checked == false)
            {
                FinishedGoodTest_SubContract_Class_Obj.fgtlfid = FinishedGoodTest_SubContract_Class_Obj.fgtlfid;
                FinishedGoodTest_SubContract_Class_Obj.TLFID = FinishedGoodTest_SubContract_Class_Obj.TLFID;
                FinishedGoodTest_SubContract_Class_Obj.Insert_tblLinkTLF_SubContract();
            }
            FinishedGoodTest_SubContract_Class_Obj.formulatype = cmbFormulaType.Text;

            //insert line packing details
            bool b = FinishedGoodTest_SubContract_Class_Obj.Insert_tblPkgSamp_SubContract();

        }


        private void FillReturnIF_FinisgedGoodDone()
        {
            DataSet ds = new DataSet();
            FinishedGoodTest_SubContract_Class_Obj.fgtlfid = FinishedGoodTest_SubContract_Class_Obj.fgtlfid;
            ds = FinishedGoodTest_SubContract_Class_Obj.Select_ModificationFinishedGoodDetails_Details_SubContract();
            if (ds.Tables[0].Rows.Count > 0)
            {

                MessageBox.Show("Record Allready Exists....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset_Control();


                //txtControltype.Text = ds.Tables[0].Rows[0]["ControlType"].ToString();
                //FinishedGoodTest_SubContract_Class_Obj.type = txtControltype.Text.Trim();

                //DtpDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["TestDate"]);

                /* if (ds.Tables[0].Rows[0]["ActualStatus"].ToString() == "A")
                 {
                     RdoAccepted.Checked = true;
                 }
                 else if (ds.Tables[0].Rows[0]["ActualStatus"].ToString() == "H")
                 {
                     RdoHold.Checked = true;
                 }
                 else if (ds.Tables[0].Rows[0]["ActualStatus"].ToString() == "R")
                 {
                     RdoRejected.Checked = true;
                     ChkReject.Visible = true;
                 }
                 else if (ds.Tables[0].Rows[0]["ActualStatus"].ToString() == "D")
                 {
                     RdoAWD.Checked = true;
                 }
                 else if (ds.Tables[0].Rows[0]["ActualStatus"].ToString() == "T")
                 {
                     RdoTreatment.Checked = true;
                 }

                 cmbInspectedBy.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["InspectedBy"]);

                 if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "ZD")
                 {
                     ChkReject.SetItemChecked(0, true);
                 }
                 else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "ZN")
                 {
                     ChkReject.SetItemChecked(1, true);
                 }
                 else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "Critical")
                 {
                     ChkReject.SetItemChecked(2, true);
                 }
                 else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "Major")
                 {
                     ChkReject.SetItemChecked(3, true);
                 }
                 else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "Minor")
                 {
                     ChkReject.SetItemChecked(4, true);
                 }
                 else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "Bulk")
                 {
                     ChkReject.SetItemChecked(5, true);
                 }
                 else if (ds.Tables[0].Rows[0]["RejectComment"].ToString() == "Other")
                 {
                     ChkReject.SetItemChecked(6, true);
                 }



                 if (ds.Tables[0].Rows[0]["NoOfDefects"] is System.DBNull || ds.Tables[0].Rows[0]["NoOfDefects"].ToString() == "0")
                 {
                     txtNoOfDefects.Text = "";
                 }
                 else
                 {
                     txtNoOfDefects.Text = ds.Tables[0].Rows[0]["NoOfDefects"].ToString();
                 }

                 if (ds.Tables[0].Rows[0]["NoOfSamples"] is System.DBNull || ds.Tables[0].Rows[0]["NoOfSamples"].ToString() == "0")
                 {
                     txtNoOfSamples.Text = "";
                 }
                 else
                 {
                     txtNoOfSamples.Text = ds.Tables[0].Rows[0]["NoOfSamples"].ToString();
                 }

                 txtComment.Text = ds.Tables[0].Rows[0]["comment"].ToString();

                 if (ds.Tables[0].Rows[0]["Decision"].ToString().Trim() == "B")
                 {
                     RdoBpc.Checked = true;
                 }
                 else if (ds.Tables[0].Rows[0]["Decision"].ToString().Trim() == "N")
                 {
                     RdoNonBpc.Checked = true;
                 }

                 txtComment_NonBpc.Text = ds.Tables[0].Rows[0]["NonBPCComment"].ToString();

                 if (ds.Tables[0].Rows[0]["Catagory"].ToString() == "Launch")
                 {
                     RdoLaunch.Checked = true;
                 }
                 else if (ds.Tables[0].Rows[0]["Catagory"].ToString() == "PriceChange")
                 {
                     RdoPriceChange.Checked = true;
                 }
                 else if (ds.Tables[0].Rows[0]["Catagory"].ToString() == "ArtWorkChange")
                 {
                     RdoArtWorkChange.Checked = true;
                 }
                 else if (ds.Tables[0].Rows[0]["Catagory"].ToString() == "Renovation")
                 {
                     RdoRenovation.Checked = true;
                 }
                 else if (ds.Tables[0].Rows[0]["Catagory"].ToString() == "N/A")
                 {
                     RdoRegular.Checked = true;
                 }
                 if (ds.Tables[0].Rows[0]["BMRFilepath"] is System.DBNull || ds.Tables[0].Rows[0]["BMRFilepath"].ToString() == "")
                 {

                 }
                 else
                 {
                     FinishedGoodTest_SubContract_Class_Obj.bmrfilepath = ds.Tables[0].Rows[0]["BMRFilepath"].ToString();
                     FinishedGoodTest_SubContract_Class_Obj.filename = System.IO.Path.GetFileName(FinishedGoodTest_SubContract_Class_Obj.bmrfilepath);
                     txtBMR.Text = FinishedGoodTest_SubContract_Class_Obj.filename;
                 }
                 */
            }
        }

        public void Reset_Control()
        {
            CmbFgCode.SelectedValue = 0;
            CmbFormulaNo.SelectedValue = 0;
            ChkKit.Checked = false;
            ChkSF.Checked = false;
            txtFGDesc.Text = "";
            txtFGGlobalFamily.Text = "";
            txtFGTechnicalFamily.Text = "";
            cmbSupplier.SelectedValue = 0;
            txtBatchSize.Text = "";
            txtMfgWoNo.Text = "";
            DtpDateOfValidation.Value = Today;
            txtNorms.Text = "";
            txtDescription.Text = "";
            txtTechnicalFamily.Text = "";
            dtpdecisionDate.Value = Today;
            cmbFormulaType.Text = "--Select--";
            txtBatchCode.Text = "";
            txtFillVolume.Text = "";
            txtPrice.Text = "";
            txtSpecification.Text = "";
            DtpTrackCode.Value = Today;
            DtpFillDate.Value = Today;
            DtpInspDate.Value = Today;
            cmbLocation.Text = "--Select--";
            txtMfgWoNo.Text = "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0';


            txtFGDesc.Text = "";
            txtPkgFamily.Text = "";

            //    dgKit.Rows.Clear();
            dgTest.Columns.Clear();

            RdoAccepted.Checked = true;
            txtComment.Text = "";
            RdoBpc.Checked = false;
            RdoNonBpc.Checked = false;
            txtComment_NonBpc.Text = "";
            cmbInspectedBy.Text = "--Select--";
            RdoRegular.Checked = false;
            RdoLaunch.Checked = false;
            RdoPriceChange.Checked = false;
            RdoRenovation.Checked = false;
            RdoArtWorkChange.Checked = false;

            ChkReject.Visible = false;
            for (int i = 0; i < ChkReject.Items.Count; i++)
            {
                if (ChkReject.GetItemChecked(i) == true)
                {
                    ChkReject.SetItemChecked(i, false);
                }
            }
            lblNoOfDefets.Visible = false;
            txtNoOfDefects.Visible = false;
            txtNoOfDefects.Text = "";
            lblNoOfSamples.Visible = false;
            txtNoOfSamples.Visible = false;
            txtNoOfSamples.Text = "";

            cmbDetails.Focus();
            lblcoc.Text = "";
            ChkFinishedProduct.Checked = false;
            ChkSemiFinished.Checked = false;
            ChkWip.Checked = false;
            ChkAOCPending.Checked = false;
            txtAOCPending.Text = "";
            txtSemiFinished.Text = "";
        }


        private void cmbSupplier_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FinishedGoodTest_SubContract_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
            FinishedGoodTest_SubContract_Class_Obj.FGSupplierID = Convert.ToInt64(cmbSupplier.SelectedValue);

            DataSet ds = new DataSet();
            ds = FinishedGoodTest_SubContract_Class_Obj.Select_COC_Subcontractor();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["COC"].ToString() == "Yes")
                {
                    lblcoc.ForeColor = Color.Red;
                    lblcoc.Text = "COC Applicable";
                    lblcoc.Visible = true;
                }
                else
                {
                    lblcoc.Text = "";
                    lblcoc.Visible = false;
                }
            }
            else
            {
                lblcoc.Text = "";
                lblcoc.Visible = false;
            }
        }

        private void btnAddMfgWo_Click(object sender, EventArgs e)
        {
            if (lstMfgWo.Items.Count == 0)
                lstMfgWo.Items.Add(txtMfgWoNo.Text.Trim());
            else
            {
                for (int s = 0; s < lstMfgWo.Items.Count; s++)
                {
                    if (txtMfgWoNo.Text.Trim() == lstMfgWo.Items[s].ToString().Trim())
                    {
                        MessageBox.Show("MfgWo allready exist.", "Message");
                        txtMfgWoNo.Text = "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0';
                        return;
                    }
                }
                lstMfgWo.Items.Add(txtMfgWoNo.Text.Trim());
            }


            txtMfgWoNo.Text = "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0';
        }

        private void btnGenerateTest_Click(object sender, EventArgs e)
        {
            if (CmbFormulaNo.SelectedIndex == 0 || CmbFormulaNo.Text == "--Select--")
            {
                MessageBox.Show("please select Formula No.", "Message");
                return;
            }
            if (cmbSupplier.SelectedIndex == 0 || cmbSupplier.Text == "--Select--")
            {
                MessageBox.Show("please select Supplier.", "Message");
                return;
            }
            if (lstMfgWo.Items.Count == 0)
            {
                MessageBox.Show("please add MfgWo.", "Message");
                return;
            }

            FinishedGoodTest_SubContract_Class_Obj.FGSupplierID = Convert.ToInt64(cmbSupplier.SelectedValue);
            DataSet ds = new DataSet();
            ds = FinishedGoodTest_SubContract_Class_Obj.Select_MicroPhysicochemical_SubContract();

            if (ds.Tables[0].Rows.Count > 0)
            {
                FinishedGoodTest_SubContract_Class_Obj.coc = ds.Tables[0].Rows[0]["COC"].ToString();
                FinishedGoodTest_SubContract_Class_Obj.micro = Convert.ToBoolean(ds.Tables[0].Rows[0]["Micro"]);
                FinishedGoodTest_SubContract_Class_Obj.physicochemical = Convert.ToBoolean(ds.Tables[0].Rows[0]["Physicochemical"]);
                FinishedGoodTest_SubContract_Class_Obj.packing = Convert.ToBoolean(ds.Tables[0].Rows[0]["Packing"]);
            }

            dgTest.Rows.Clear();
            dgTest.Columns.Clear();

            string testcolumn = "";

            DataSet ds_Formula = new DataSet();
            FinishedGoodTest_SubContract_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
            ds_Formula = FinishedGoodTest_SubContract_Class_Obj.Select_CheckPreservativeTest();

            if (FinishedGoodTest_SubContract_Class_Obj.coc != "Yes")
            {
                //Add column in dgTest for Packing
                dgTest.Columns.Add("Packing", "Packing");
                dgTest.Columns["Packing"].Width = 100;
                dgTest.Columns["Packing"].ReadOnly = true;

                for (int s = 0; s < lstMfgWo.Items.Count; s++)
                {
                    testcolumn = CmbFormulaNo.Text + ' ' + lstMfgWo.Items[s].ToString().Trim();
                    dgTest.Columns.Add(testcolumn, testcolumn);
                    dgTest.Columns[testcolumn].Width = 120;
                    dgTest.Columns[testcolumn].ReadOnly = true;

                    if (ds_Formula.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["PreservativeTest"]) == true)
                        {
                            dgTest.Columns.Add("Preservative " + lstMfgWo.Items[s].ToString().Trim(), "Preservative " + lstMfgWo.Items[s].ToString().Trim());
                            dgTest.Columns["Preservative " + lstMfgWo.Items[s].ToString().Trim()].Width = 80;
                            dgTest.Columns["Preservative " + lstMfgWo.Items[s].ToString().Trim()].ReadOnly = true;
                        }
                        if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["MicrobiologyTest"]) == true)
                        {
                            dgTest.Columns.Add("Micro " + lstMfgWo.Items[s].ToString().Trim(), "Micro " + lstMfgWo.Items[s].ToString().Trim());
                            dgTest.Columns["Micro " + lstMfgWo.Items[s].ToString().Trim()].Width = 80;
                            dgTest.Columns["Micro " + lstMfgWo.Items[s].ToString().Trim()].ReadOnly = true;
                        }
                    }
                }
            }
            else
            {

                dgTest.Columns.Add("Packing", "Packing");
                dgTest.Columns["Packing"].Width = 100;
                dgTest.Columns["Packing"].ReadOnly = true;

                for (int s = 0; s < lstMfgWo.Items.Count; s++)
                {
                    testcolumn = CmbFormulaNo.Text + ' ' + lstMfgWo.Items[s].ToString().Trim();
                    dgTest.Columns.Add(testcolumn, testcolumn);
                    dgTest.Columns[testcolumn].Width = 120;
                    dgTest.Columns[testcolumn].ReadOnly = true;

                    if (ds_Formula.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["PreservativeTest"]) == true)
                        {
                            dgTest.Columns.Add("Preservative " + lstMfgWo.Items[s].ToString().Trim(), "Preservative " + lstMfgWo.Items[s].ToString().Trim());
                            dgTest.Columns["Preservative " + lstMfgWo.Items[s].ToString().Trim()].Width = 80;
                            dgTest.Columns["Preservative " + lstMfgWo.Items[s].ToString().Trim()].ReadOnly = true;
                        }

                        if (Convert.ToBoolean(ds_Formula.Tables[0].Rows[0]["MicrobiologyTest"]) == true)
                        {
                            dgTest.Columns.Add("Micro " + lstMfgWo.Items[s].ToString().Trim(), "Micro " + lstMfgWo.Items[s].ToString().Trim());
                            dgTest.Columns["Micro " + lstMfgWo.Items[s].ToString().Trim()].Width = 80;
                            dgTest.Columns["Micro " + lstMfgWo.Items[s].ToString().Trim()].ReadOnly = true;
                        }
                    }
                }
            }

            for (int s = 0; s < lstMfgWo.Items.Count; s++)
            {
                testcolumn = CmbFormulaNo.Text + ' ' + lstMfgWo.Items[s].ToString().Trim();
                Insert_tblFGTLF(testcolumn, lstMfgWo.Items[s].ToString().Trim());
            }

            FinishedGoodTest_SubContract_Class_Obj.type = FinishedGoodTest_SubContract_Class_Obj.Decide_ControlType_FG_SubContract();
        }
    }
}