/********************************************************
*Author: Vijay Tomake
*Date: 
*Description: Transaction form to enter finished good details
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

namespace QTMS.Transactions
{
    public partial class FrmFinishedGoodTest : Form
    {

        public FrmFinishedGoodTest()
        {
            InitializeComponent();
        }

        #region variables
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        RetainerLocation_Class RetainerLocation_Class_Obj = new RetainerLocation_Class();
        FGDecleration_Class FGDecleration_Class_Obj = new FGDecleration_Class(); 
        #endregion

        //get the active instance of the form
        private static FrmFinishedGoodTest frmFinishedGoodTest_Obj = null;
        public static FrmFinishedGoodTest GetInstance()
        {
            if (frmFinishedGoodTest_Obj == null)
            {
                frmFinishedGoodTest_Obj = new FrmFinishedGoodTest();
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


            DtpDate.Value = Comman_Class_Obj.Select_ServerDate();
            Bind_Details();
            Bind_InspectedBy();
            Bind_VerifiedBy();
            cmbDetails.Focus();
            Bind_Location();

            if (GlobalVariables.City == "BADDI")
            {
                lblLocation.Visible = true;
                cmbLocation.Visible = true;
                lblkitcode.Visible = true;
                lbltubes.Visible = true;
                cmbTubes.Visible = true;
                txtkitcode.Visible = true;

                lblbottles.Visible = true;
                lblkits.Visible = true;
                cmbBottles.Visible = true;
                cmbKits.Visible = true;
            }
            else
            {
                lblLocation.Visible = false;
                cmbLocation.Visible = false;
                lblkitcode.Visible = false;
                lbltubes.Visible = false;
                cmbTubes.Visible = false;
                txtkitcode.Visible = false;

                lblbottles.Visible = false;
                lblkits.Visible = false;
                cmbBottles.Visible = false;
                cmbKits.Visible = false;
            }

            cmbTubes.Text = "0";
            cmbKits.Text = "0";
            cmbBottles.Text = "0";
            CmbDeclerationType.Text = "<--Select-->";
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

        //Binds the pending Finished good details those entered in 
        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = FinishedGoodTest_Class_Obj.Select_PendingFinishedGoodDetails();
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
        /// Selection change commited event for Details combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                BtnReset_Click(sender, e);
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
                                RdoLaunch.Checked = false;
                            }
                            else
                            {
                                RdoLaunch.Checked = true;
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
                        dgKit["Subcontractor", i].Value = dsPkgBulk.Tables[0].Rows[i]["Subcontractor"].ToString();
                        if (dsPkgBulk.Tables[0].Rows[i]["Subcontractor"].ToString() == "1")
                        {
                            dgKit["PkgWO", i].Value = dsPkgBulk.Tables[0].Rows[i]["PkgWOFG"].ToString();
                        }
                        else
                        {
                            LineSamplePackingDetails_Class objLineSamplePackingDetails_Class = new LineSamplePackingDetails_Class();
                            objLineSamplePackingDetails_Class.tlfid = Convert.ToInt32(dsPkgBulk.Tables[0].Rows[i]["TLFID"]);
                            DataSet dsFGTLF = objLineSamplePackingDetails_Class.Select_ModificationLinePackingDetails_Details();
                            if (dsFGTLF != null)
                            {
                                if (dsFGTLF.Tables.Count > 0)
                                {
                                    if (dsFGTLF.Tables[0].Rows.Count > 0)
                                    {
                                        dgKit["PkgWO", i].Value = dsFGTLF.Tables[0].Rows[0]["PkgWO"].ToString();
                                    }
                                }
                            }
                        }
                        //dgKit["PkgWO", i].Value = dsPkgBulk.Tables[0].Rows[i]["PkgWOFG"].ToString();
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
                            //dgTest.Columns.Add(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString() + "\n" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString());
                            //dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].Width = 100;
                            //dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].ReadOnly = true;

                            if (dsPkgBulk.Tables[0].Rows[i]["Subcontractor"].ToString() == "1")
                            {
                                dgTest.Columns.Add(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString() + "- Subcontractor -" + dsPkgBulk.Tables[0].Rows[i]["TLFID"].ToString(), dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString() + "\n" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString());
                                dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString() + "- Subcontractor -" + dsPkgBulk.Tables[0].Rows[i]["TLFID"].ToString()].Width = 100;
                                dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString() + "- Subcontractor -" + dsPkgBulk.Tables[0].Rows[i]["TLFID"].ToString()].ReadOnly = true;

                                dgTest[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString() + "- Subcontractor -" + dsPkgBulk.Tables[0].Rows[i]["TLFID"].ToString(), 0].Value = "A";
                            }
                            else
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
                    }

                    //GET CONTROL TYPE FROM STP_Decide_ControlType STORED PROCEDURE
                    //2/5 LOGIC
                    txtControltype.Text = FinishedGoodTest_Class_Obj.Decide_ControlType_FG();
                    FinishedGoodTest_Class_Obj.type = txtControltype.Text.Trim();

                }
                else
                    RdoLaunch.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// resets the controls on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            //cmbDetails.Text = "--Select--";
            txtFGDesc.Text = "";
            txtPkgFamily.Text = "";
            txtControltype.Text = "";
            dgKit.Rows.Clear();
            dgTest.Columns.Clear();

            RdoAccepted.Checked = true;
            txtComment.Text = "";
            RdoBpc.Checked = false;
            RdoNonBpc.Checked = false;
            txtComment_NonBpc.Text = "";
            cmbInspectedBy.Text = "--Select--";
            cmbVerifiedBy.Text = "--Select--";
            RdoRegular.Checked = false;
            RdoLaunch.Checked = false;
            RdoPriceChange.Checked = false;
            RdoRenovation.Checked = false;
            RdoArtWorkChange.Checked = false;
            cmbLocation.Text = "--Select--";
            cmbTubes.Text = "0";
            cmbKits.Text = "0";
            cmbBottles.Text = "0";
            txtkitcode.Text = "";

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
            dgDecleratioLot.Rows.Clear();

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
                    if (cmbVerifiedBy.SelectedValue == null || cmbVerifiedBy.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select Verified By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbVerifiedBy.Focus();
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
                        for (int i = 0; i < dgTest.Rows[0].Cells.Count; i++)
                        {
                            if (dgTest.Rows[0].Cells[i].Value.ToString().Trim() != "A")
                            {
                                MessageBox.Show("All test must be accepted for");
                                return;
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
                    //----- Commented as per Nilesh's suggestion-----------

                    //if (RdoHold.Checked != true && FrmMain.UserType == 'N')
                    //{
                    //    MessageBox.Show("Sorry..\n\nYou can only HOLD the record", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}

                    //Insert unit details
                    DataSet dsUnit;
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        dsUnit = new DataSet();
                        FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                        FinishedGoodTest_Class_Obj.packsize = Convert.ToInt32(dgKit["PackSize", i].Value);
                        FinishedGoodTest_Class_Obj.weight = Convert.ToDouble(dgKit["Weight", i].Value);
                        dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                        if (dsUnit.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_Class_Obj.Update_tblFinishedGoodUnitDetails();
                        }
                        else
                        {
                            FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodUnitDetails();
                        }

                        if (GlobalVariables.City == "BADDI")
                        {
                            FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                            FinishedGoodTest_Class_Obj.locationid = Convert.ToInt64(cmbLocation.SelectedValue);
                            //FinishedGoodTest_Class_Obj._quantity = cmbTubes.Text;
                            FinishedGoodTest_Class_Obj.kitcode = txtkitcode.Text;
                            FinishedGoodTest_Class_Obj.tubes = Convert.ToInt32(cmbTubes.Text);
                            FinishedGoodTest_Class_Obj.kits = Convert.ToInt32(cmbKits.Text);
                            FinishedGoodTest_Class_Obj.bottles = Convert.ToInt32(cmbBottles.Text);

                            FinishedGoodTest_Class_Obj.Update_tblPkgSamp();
                        }
                    }

                    FinishedGoodTest_Class_Obj.testdate = Convert.ToString(DtpDate.Value);

                    if (RdoAccepted.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.status = "A";
                    }
                    else if (RdoHold.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.status = "H";
                    }
                    else if (RdoRejected.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.status = "R";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.status = "A";
                    }
                    else if (RdoTreatment.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.status = "R";
                    }


                    //------Actual Status------

                    if (RdoAccepted.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.actualstatus = "A";
                    }
                    else if (RdoHold.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.actualstatus = "H";
                    }
                    else if (RdoRejected.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.actualstatus = "R";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.actualstatus = "D";
                    }
                    else if (RdoTreatment.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.actualstatus = "T";
                    }

                    FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("N/A");
                    for (int i = 0; i < ChkReject.Items.Count; i++)
                    {
                        if (ChkReject.GetItemChecked(i) == true)
                        {
                            if (i == 0)
                            {
                                FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("ZD");
                                break;
                            }
                            else if (i == 1)
                            {
                                FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("ZN");
                                break;
                            }
                            else if (i == 2)
                            {
                                FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Critical");
                                break;
                            }
                            else if (i == 3)
                            {
                                FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Major");
                                break;
                            }
                            else if (i == 4)
                            {
                                FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Minor");
                                break;
                            }
                            else if (i == 5)
                            {
                                FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Bulk");
                                break;
                            }
                            else if (i == 6)
                            {
                                FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Other");
                                break;
                            }
                        }
                    }

                    if (txtNoOfDefects.Text.Trim() != "")
                    {
                        FinishedGoodTest_Class_Obj.noofdefects = Convert.ToInt32(txtNoOfDefects.Text.Trim());
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.noofdefects = 0;
                    }

                    if (txtNoOfSamples.Text.Trim() != "")
                    {
                        FinishedGoodTest_Class_Obj.noofsamples = Convert.ToInt32(txtNoOfSamples.Text.Trim());
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.noofsamples = 0;
                    }

                    FinishedGoodTest_Class_Obj.Comment = txtComment.Text.Trim();
                    if (RdoBpc.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.decision = "B";
                        FinishedGoodTest_Class_Obj.nonbpccomment = "";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.decision = "N";
                        FinishedGoodTest_Class_Obj.nonbpccomment = txtComment_NonBpc.Text;
                    }


                    if (RdoLaunch.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.catagory = "Launch";
                    }
                    else if (RdoPriceChange.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.catagory = "PriceChange";
                    }
                    else if (RdoArtWorkChange.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.catagory = "ArtWorkChange";
                    }
                    else if (RdoRenovation.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.catagory = "Renovation";
                    }
                    else if (RdoRegular.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.catagory = "N/A";
                    }

                    //this Flag describes that this is current record for this FGTLFID 
                    //IF any record get treatmented in treatment screen then new record added in tblFinishedGoodTestDetails which is currentflag =1 
                    //then for old record current flag is 0
                    //If record is for treatment then set currentflag =0
                    if (RdoTreatment.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.currentflag = 0;
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.currentflag = 1;
                    }

                    //this flag shows the record which are under the treatment process
                    //in transaction screen treatmentdone = 0
                    //and treatmentdone = 1 for both old and newly added record in treatment screen                    
                    FinishedGoodTest_Class_Obj.treatmentdone = 0;

                    //this flag shows record which is added after treatment 
                    //For transation screen Treatmented = 0
                    //This flag is set for only for record which is added after treatment 
                    //In Treatment screen Treatmented = 1
                    //this flag is used to avoid record while deciding control type  
                    FinishedGoodTest_Class_Obj.treatmented = 0;

                    FinishedGoodTest_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);
                    FinishedGoodTest_Class_Obj.verifiedby = Convert.ToInt32(cmbVerifiedBy.SelectedValue);

                    FinishedGoodTest_Class_Obj.loginid = FrmMain.LoginID;

                    //ControlType
                    //LNo

                    DataSet ds1 = new DataSet();
                    //Select FGTestNo from FGTLFID
                    ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodDetails_FGTLFID();
                    if (ds1.Tables[0].Rows.Count > 0)  // if exists then modify
                    {
                        //update fg transaction details
                        FinishedGoodTest_Class_Obj.fgtestno = Convert.ToInt64(ds1.Tables[0].Rows[0]["FGTestNo"]);
                        FinishedGoodTest_Class_Obj.Update_tblFinishedGoodTestDetails();
                    }
                    else // insert
                    {
                        //insert fg transaction details
                        FinishedGoodTest_Class_Obj.fgtestno = FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodTestDetails();
                    }


                    //update FGDone=1  in tblFGTLF from FGTLFID 
                    if (RdoHold.Checked != true)
                    {
                        FinishedGoodTest_Class_Obj.fgdone = true;
                        FinishedGoodTest_Class_Obj.Update_tblFGTLF_FGDone();
                    }

                    #region Add Decleration Lot No.
                    for (int i = 0; i < dgDecleratioLot.Rows.Count; i++)
                    {
                        FGDecleration_Class_Obj.fgtlfid = FinishedGoodTest_Class_Obj.fgtlfid;
                        FGDecleration_Class_Obj.declerationlotno = Convert.ToString(dgDecleratioLot[0, i].Value);
                        FGDecleration_Class_Obj.qty = Convert.ToString(dgDecleratioLot[1, i].Value);
                        FGDecleration_Class_Obj.declerationtype = Convert.ToString(dgDecleratioLot[2, i].Value);
                        FGDecleration_Class_Obj.active = 1;
                        FGDecleration_Class_Obj.createdby = FrmMain.LoginID;
                        FGDecleration_Class_Obj.Insert_tblFGDecleration();
                    }
                    #endregion

                        MessageBox.Show("Record Saved Successfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Bind_Details();
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
                txtComment_NonBpc.BackColor = Color.White;
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
                txtComment_NonBpc.BackColor = Color.FromArgb(242, 246, 252);
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
            if (dgKit.CurrentCell.ReadOnly == false)
            {
                dgKit.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
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
                //if (dgTest[e.ColumnIndex, e.RowIndex].Value != null)
                //{
                //    MessageBox.Show("Testing already Done...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                //    return;
                //}

                if (e.ColumnIndex == dgTest.Columns[0].Index)    //Packing
                {
                    FrmFGPackingTest.Detail detail_Obj = new FrmFGPackingTest.Detail();
                    detail_Obj.D_fgtlfid = FinishedGoodTest_Class_Obj.fgtlfid;
                    detail_Obj.D_pkgtechno = FinishedGoodTest_Class_Obj.pkgtechno;
                    detail_Obj.D_type = FinishedGoodTest_Class_Obj.type;
                    detail_Obj.D_fgno = FinishedGoodTest_Class_Obj.fgno;

                    detail_Obj.D_Quantity = FinishedGoodTest_Class_Obj.quantity;
                    detail_Obj.D_pkgstatus = dgTest[e.ColumnIndex, e.RowIndex].Value.ToString();





                    if (dgTest[e.ColumnIndex, 0].Value.ToString() == "")
                    {
                        detail_Obj.Done = 'N';
                    }
                    else
                    {
                        detail_Obj.Done = 'Y';
                    }

                    //Quantity = sum of all components packsize
                    int sum = 0;
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        sum = sum + Convert.ToInt32(dgKit["PackSize", i].Value);
                    }
                    if (FinishedGoodTest_Class_Obj.quantity == 0)
                        detail_Obj.D_Quantity = sum;

                    //Insert unit details
                    DataSet dsUnit;
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        if (dgKit["Subcontractor", i].Value.ToString() == "1")
                        { }
                        else
                        {
                            dsUnit = new DataSet();
                            FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                            FinishedGoodTest_Class_Obj.packsize = Convert.ToInt32(dgKit["PackSize", i].Value);
                            FinishedGoodTest_Class_Obj.weight = Convert.ToDouble(dgKit["Weight", i].Value);
                            dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                            if (dsUnit.Tables[0].Rows.Count > 0)
                            {
                                //update Fg unit details
                                FinishedGoodTest_Class_Obj.Update_tblFinishedGoodUnitDetails();
                            }
                            else
                            {
                                //insert fg unit details
                                FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodUnitDetails();
                            }
                        }
                    }

                    //Display FG Packing Test form
                    FrmFGPackingTest fmPack = new FrmFGPackingTest(detail_Obj);
                    fmPack.ShowDialog();

                    DataSet ds1 = new DataSet();
                    //Select PkgStatus from fgno,trackcode,lno
                    ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPackingDetails_PkgStatus();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, e.RowIndex].Value = ds1.Tables[0].Rows[0]["PkgStatus"].ToString();
                    }


                }
                else if (e.ColumnIndex > 0)   //Physico-Chemical
                {
                    string getColumnName = dgTest.Columns[e.ColumnIndex].Name;
                    if (getColumnName.Contains("Subcontractor"))
                    {
                        BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class FinishedGoodTest_SubContract_Class_Obj = new BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class();

                        string[] Formula = dgTest.Columns[e.ColumnIndex].HeaderText.Split('\n');


                        string[] Name = dgTest.Columns[e.ColumnIndex].Name.Split('-');
                        //Get FNo from column name 
                        FinishedGoodTest_Class_Obj.fno = Convert.ToInt64(Name[0]);
                        //Get MfgWo from column name
                        FinishedGoodTest_Class_Obj.mfgwo = Name[1];

                        FrmFGPhysicoChemicalTest_SubContract.Detail detail_Obj = new FrmFGPhysicoChemicalTest_SubContract.Detail();

                        FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(Name[3]);
                        DataSet ds1 = new DataSet();
                        //Select PkgStatus from fgno,trackcode,lno
                        ds1 = FinishedGoodTest_Class_Obj.Select_PhysicoChemical_Subcontractor_RegularFG();
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            detail_Obj.D_fgtlfid = Convert.ToInt64(ds1.Tables[0].Rows[0]["FGTLFID"].ToString());
                            detail_Obj.D_fmid = Convert.ToInt64(ds1.Tables[0].Rows[0]["FMID"].ToString());
                            detail_Obj.D_inspectedby = Convert.ToInt64(ds1.Tables[0].Rows[0]["InspectedBy"].ToString());
                        }



                       
                        // FinishedGoodTest_SubContract_Class_Obj.fgtlfid;
                        detail_Obj.D_fno = FinishedGoodTest_SubContract_Class_Obj.fno;
                        detail_Obj.D_pkgtechno = FinishedGoodTest_SubContract_Class_Obj.pkgtechno;
                        //detail_Obj.D_type = FinishedGoodTest_SubContract_Class_Obj.type;
                        detail_Obj.D_COC = FinishedGoodTest_SubContract_Class_Obj.coc;
                        //detail_Obj.D_fmid = FinishedGoodTest_SubContract_Class_Obj.fmid;
                        //detail_Obj.D_inspectedby = FinishedGoodTest_SubContract_Class_Obj.inspectedby;
                        detail_Obj.D_SupplierID = FinishedGoodTest_SubContract_Class_Obj.FGSupplierID;
                        detail_Obj.D_physicochemical = FinishedGoodTest_SubContract_Class_Obj.physicochemical;

                        FinishedGoodTest_SubContract_Class_Obj.mfgwo = FinishedGoodTest_Class_Obj.mfgwo;
                        detail_Obj.D_type = "Regular";

                        ////DataSet dsFMID = new DataSet();
                        ////dsFMID = FinishedGoodTest_SubContract_Class_Obj.Select_tblTransFMFinishedGoods_SubContract_FMID();
                        ////if (dsFMID.Tables[0].Rows.Count > 0)
                        ////{
                       // Convert.ToInt64(dsFMID.Tables[0].Rows[0]["FMID"]);
                        ////}



                        detail_Obj.D_phychestatus = "A";


                        detail_Obj.Done = 'Y';

                        detail_Obj.D_FormulaNo = Formula[0]; //Convert.ToString(FinishedGoodTest_Class_Obj.fno);
                        detail_Obj.D_fno = FinishedGoodTest_Class_Obj.fno;
                        detail_Obj.D_mfgwo = FinishedGoodTest_Class_Obj.mfgwo;

                        //Display FG Physico-Chemical Test form
                        FrmFGPhysicoChemicalTest_SubContract fmPhy = new FrmFGPhysicoChemicalTest_SubContract(detail_Obj);
                        fmPhy.ShowDialog();
                    }
                    else
                    {
                        FrmFGPhysicoChemicalTest.Detail detail_Obj = new FrmFGPhysicoChemicalTest.Detail();
                        detail_Obj.D_fgtlfid = FinishedGoodTest_Class_Obj.fgtlfid;
                        detail_Obj.D_fno = FinishedGoodTest_Class_Obj.fno;
                        detail_Obj.D_pkgtechno = FinishedGoodTest_Class_Obj.pkgtechno;
                        detail_Obj.D_type = FinishedGoodTest_Class_Obj.type;
                        detail_Obj.D_phychestatus = dgTest[e.ColumnIndex, e.RowIndex].Value.ToString();

                        if (dgTest[e.ColumnIndex, 0].Value.ToString() == "")
                        {
                            detail_Obj.Done = 'N';
                        }
                        else
                        {
                            detail_Obj.Done = 'Y';
                        }


                        //Insert unit details
                        DataSet dsUnit;
                        for (int i = 0; i < dgKit.Rows.Count; i++)
                        {
                            if (dgKit["Subcontractor", i].Value.ToString() == "1")
                            { }
                            else
                            {
                                dsUnit = new DataSet();
                                FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                                FinishedGoodTest_Class_Obj.packsize = Convert.ToInt32(dgKit["PackSize", i].Value);
                                FinishedGoodTest_Class_Obj.weight = Convert.ToDouble(dgKit["Weight", i].Value);
                                dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                                if (dsUnit.Tables[0].Rows.Count > 0)
                                {
                                    //update Fg unit details
                                    FinishedGoodTest_Class_Obj.Update_tblFinishedGoodUnitDetails();
                                }
                                else
                                {
                                    //insert Fg unit details
                                    FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodUnitDetails();
                                }
                            }
                        }

                        string[] Formula = dgTest.Columns[e.ColumnIndex].HeaderText.Split('\n');
                        detail_Obj.D_FormulaNo = Formula[0];

                        string[] Name = dgTest.Columns[e.ColumnIndex].Name.Split('-');
                        //Get FNo from column name 
                        FinishedGoodTest_Class_Obj.fno = Convert.ToInt64(Name[0]);
                        //Get MfgWo from column name
                        FinishedGoodTest_Class_Obj.mfgwo = Name[1];

                        detail_Obj.D_fno = FinishedGoodTest_Class_Obj.fno;
                        detail_Obj.D_mfgwo = FinishedGoodTest_Class_Obj.mfgwo;

                        //Display FG Physico-Chemical Test form
                        FrmFGPhysicoChemicalTest fmPhy = new FrmFGPhysicoChemicalTest(detail_Obj);
                        fmPhy.ShowDialog();

                        DataSet ds1 = new DataSet();
                        //Select PhyCheStatus from fgno,fno,trackcode,lno
                        ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus();
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            dgTest[e.ColumnIndex, e.RowIndex].Value = ds1.Tables[0].Rows[0]["PhyCheStatus"].ToString();
                        }
                    }
                }
            }

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeclerationlotno.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Enter Decleration Lot No.");
                    txtDeclerationlotno.Focus();
                    return;
                }
                if (txtQty.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Enter Quantity.");
                    txtQty.Focus();
                    return;
                }
                if (CmbDeclerationType.Text.Trim() == "<--Select-->")
                {
                    MessageBox.Show("Select Decleration");
                    CmbDeclerationType.Focus();
                    return;
                }

                dgDecleratioLot.Rows.Add();
                int i = dgDecleratioLot.Rows.Count-1;
                dgDecleratioLot[0, i].Value = txtDeclerationlotno.Text.Trim();
                dgDecleratioLot[1, i].Value = txtQty.Text.Trim();
                dgDecleratioLot[2, i].Value = CmbDeclerationType.Text.Trim();

                txtDeclerationlotno.Text = txtQty.Text = string.Empty;
                CmbDeclerationType.Text = "<--Select-->";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnDecReset_Click(object sender, EventArgs e)
        {
            dgDecleratioLot.Rows.Clear();
        }
    }
}