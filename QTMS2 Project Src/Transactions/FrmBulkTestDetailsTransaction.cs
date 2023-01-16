/********************************************************
*Author: Vijay Tomake
*Date: 
*Description: Transaction form to enter bulk test details 
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QTMS.Tools;
using QTMS.OOS;

namespace QTMS.Transactions
{
    public partial class FrmBulkTestDetailsTransaction : Form
    {
        public FrmBulkTestDetailsTransaction()
        {
            InitializeComponent();
        }

        #region Varibles

        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Obj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        VesselMaster_Class VesselMaster_Class_Obj = new VesselMaster_Class();
        TankMaster_Class TankMaster_Class_Obj = new TankMaster_Class();
        InstrumentMaster_Class InstrumentMaster_Class_Obj = new InstrumentMaster_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        DataSet dsTankDetails = new DataSet();
        DateTime Today;

        BusinessFacade.Transactions.OOS OOS_Obj = new BusinessFacade.Transactions.OOS();

        #endregion

        /// <summary>
        /// get the active instance of the form
        /// </summary>
        private static FrmBulkTestDetailsTransaction frmBulkTestDetailsTransaction_Obj = null;
        public static FrmBulkTestDetailsTransaction GetInstance()
        {
            if (frmBulkTestDetailsTransaction_Obj == null)
            {
                frmBulkTestDetailsTransaction_Obj = new FrmBulkTestDetailsTransaction();
            }
            return frmBulkTestDetailsTransaction_Obj;
        }

        /// <summary>
        /// Form load method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBulkTestDetailsTransaction_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CmbFormulaNo.DroppedDown = false;
            cmbSupplier.DroppedDown = false;
            Painter.Paint(this);

            Bind_FormulaNo();
            Bind_Vessel();
            Bind_Tank();
            Bind_InspectedBy();
            Bind_VerifiedBy();
            Bind_Manufacturer();
            // Set Current Date
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateOfValidation.Value = DtpInspDate.Value;
            DtpStartedOn.Value = DtpInspDate.Value;
            DtpCompletedOn.Value = DtpInspDate.Value;

            CmbFormulaNo.Focus();
            cmbFormulaType.Text = "--Select--";
            cmbFA.Text = "N/A";

            BulktestDetailstransaction_Class_Obj.fno = 0;

            Today = Comman_Class_Obj.Select_ServerDate();
            BtnReset_Click(sender, e);
        }

        private void Bind_Manufacturer()
        {
            try
            {
                LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
                DataSet ds = LineMaster_Class_Obj.Select_Manufacturer();
                DataRow dr1 = ds.Tables[0].NewRow();
                dr1["ManufacturedById"] = "0";
                dr1["ManufacturerName"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr1, 0);

                DataRow dr = ds.Tables[0].NewRow();
                dr["ManufacturedById"] = ds.Tables[0].Rows.Count;
                dr["ManufacturerName"] = "SubContractor";
                ds.Tables[0].Rows.InsertAt(dr, ds.Tables[0].Rows.Count);
                cmbManufactured.DataSource = ds.Tables[0];
                cmbManufactured.DisplayMember = "ManufacturerName";
                cmbManufactured.ValueMember = "ManufacturedById";
            }
            catch (Exception)
            {
                MessageBox.Show("Record Not Found");
            }

        }



        /// <summary>
        /// binds tanks to combobox from tank master 
        /// </summary>
        public void Bind_Tank()
        {
            DataSet ds = new DataSet();
            ds = TankMaster_Class_Obj.Select_TankMaster();
            dsTankDetails = ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                ChkTankNo.DataSource = ds.Tables[0];
                ChkTankNo.DisplayMember = "TkDesc";
                ChkTankNo.ValueMember = "TankNo";
            }
        }

        /// <summary>
        /// binds vessels to combobox from vessel master
        /// </summary>
        public void Bind_Vessel()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = VesselMaster_Class_Obj.Select_tblVesselMaster();
            dr = ds.Tables[0].NewRow();
            dr["VslDesc"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbVesselNo.DataSource = ds.Tables[0];
                CmbVesselNo.DisplayMember = "VslDesc";
                CmbVesselNo.ValueMember = "VesselNo";
            }
        }

        /// <summary>
        /// binds formulano to combobox from formula master
        /// </summary>
        public void Bind_FormulaNo()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = FormulaNoMaster_Class_Obj.SELECT_TblBulkMaster_Active();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbFormulaNo.DataSource = ds.Tables[0];
                CmbFormulaNo.ValueMember = "FNo";
                CmbFormulaNo.DisplayMember = "FormulaNo";
            }

        }

        /// <summary>
        /// bind users to combobox from user master
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

                //cmbVerifiedBy.DataSource = ds.Tables[0];
                //cmbVerifiedBy.DisplayMember = "UserName";
                //cmbVerifiedBy.ValueMember = "UserID";
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
                //cmbInspectedBy.DataSource = ds.Tables[0];
                //cmbInspectedBy.DisplayMember = "UserName";
                //cmbInspectedBy.ValueMember = "UserID";

                cmbVerifiedBy.DataSource = ds.Tables[0];
                cmbVerifiedBy.DisplayMember = "UserName";
                cmbVerifiedBy.ValueMember = "UserID";
            }
        }

        /// <summary>
        /// Reset all the controls on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            CmbFormulaNo.Text = "--Select--";
            txtDescription.Text = "";
            txtMfgWoNo.Text = "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0';
            txtTechnicalFamily.Text = "";
            cmbFormulaType.Enabled = true;
            cmbFormulaType.Text = "--Select--";
            dgTest.Rows.Clear();
            dgTestCon.Rows.Clear();

            reset();
            cmbManufactured_SelectionChangeCommitted(sender, e);
            //CmbFormulaNo.Focus();
            CmbFormulaNo.Focus();
            txtSearch.Text = "";
        }

        /// <summary>
        /// reset all the controls on the form
        /// </summary>
        public void reset()
        {
            rbDWPNo.Checked = true;
            CmbVesselNo.Text = "--Select--";
            txtSerialNo.Text = "";
            txtBatchSize.Text = "";
            txtComment_Accepted.Text = "";
            txtComment_NonBpc.Text = "";
            txtNoofBatches.Text = "";
            cmbManufactured.SelectedIndex = 0;
            cmbManufactured.SelectedIndex = 0;
            //txtSupplier.Text = "";
            cmbFA.Text = "N/A";
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateOfValidation.Value = DtpInspDate.Value;
            DtpStartedOn.Value = DtpInspDate.Value;
            DtpCompletedOn.Value = DtpInspDate.Value;
            txtExtLabReportNo.Text = "";
            txtExtLabReportNo.Enabled = true;
            txtExtLabReportNo.BackColor = Color.WhiteSmoke;
            for (int i = 0; i < ChkTankNo.Items.Count; i++)
            {
                if (ChkTankNo.GetItemChecked(i) == true)
                {
                    ChkTankNo.SetItemChecked(i, false);

                }
            }
            RdoRegularProduct.Enabled = true;
            RdoNewLaunch.Enabled = true;
            RdoRegularProduct.Checked = false;
            RdoNewLaunch.Checked = true;
            RdoBpc.Checked = false;
            RdoIQ.Checked = false;
            //RdoNonBpc.Checked = false;
            RdoHold.Checked = true;
            chkSubContract.Checked = false;
            cmbInspectedBy.Text = "--Select--";
            cmbVerifiedBy.Text = "--Select--";
        }

        /// <summary>
        /// close the appplication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Selection change event for frmula combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtDescription.Text = "";
            txtNoofBatches.Text = "";
            txtTechnicalFamily.Text = "";

            dgTest.Rows.Clear();
            dgTestCon.Rows.Clear();

            cmbFormulaType.Text = "--Select--";
            cmbFormulaType.Enabled = true;

            if (CmbFormulaNo.SelectedValue != null && Convert.ToString(CmbFormulaNo.SelectedValue) != "0")
            {
                //Get the details of the formula
                DataSet ds = new DataSet();
                FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                ds = FormulaNoMaster_Class_Obj.SELECT_TblBulkMaster_tblblkfamilyMaster();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);
                    //txtNoofBatches.Text = Convert.ToString(ds.Tables[0].Rows[0]["noofbatches"]);
                    txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);
                    txtFilCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["FilCode"]);
                    if (Convert.ToInt16(ds.Tables[0].Rows[0]["Microbiologytest"]) == 1)
                    {
                        //txtNorms.Visible =
                        txtBacterialCount.Visible = txtFungalCount.Visible= true;
                        txtNorms.Text = Convert.ToString(ds.Tables[0].Rows[0]["Norms"]);
                        txtBacterialCount.Text = Convert.ToString(ds.Tables[0].Rows[0]["BacterialCount"]);
                        txtFungalCount.Text = Convert.ToString(ds.Tables[0].Rows[0]["FungalCount"]);
                        //labelNorms.Visible = 
                        lblBacterialCount.Visible = lblFungalCount.Visible= true;
                    }
                    else
                    {
                        txtNorms.Visible = txtBacterialCount.Visible = txtFungalCount.Visible = false;
                        txtNorms.Text = txtBacterialCount.Text = txtFungalCount.Text = "";
                    }
                    if (Convert.ToInt16(ds.Tables[0].Rows[0]["ExtLabReport"]) == 1)
                    {
                        txtExtLabReportNo.Enabled = true;
                        txtExtLabReportNo.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        txtExtLabReportNo.Enabled = false;
                        txtExtLabReportNo.BackColor = Color.FromName("Control");
                    }

                    //Check the current date with reference date from formula master
                    //formula will expire after 1 year from the reference date
                    //It will start promting message 1 month before reference date
                    if (Comman_Class_Obj.Select_ServerDate() < Convert.ToDateTime(ds.Tables[0].Rows[0]["ReferenceDate"]).AddMonths(11))
                    {

                    }
                    else
                    {
                        //lblMessage.Text = "This formula will Expire on " + Convert.ToString(Convert.ToDateTime(ds.Tables[0].Rows[0]["ReferenceDate"]).AddMonths(12).ToShortDateString());
                        NotifyWindow nw = new NotifyWindow("Formula Expiry", Convert.ToDateTime(ds.Tables[0].Rows[0]["ReferenceDate"]).AddMonths(12).ToString("dd/MMM/yyyy"));
                        nw.Notify();
                    }

                    //if (ds.Tables[0].Rows[0]["FType"].ToString() == "Validated")
                    //{
                    //    cmbFormulaType.Enabled = false;
                    //    cmbFormulaType.Text = "Validated";
                    //}
                    //else if (ds.Tables[0].Rows[0]["FType"].ToString() == "NonValidated")
                    //{
                    //    cmbFormulaType.Enabled = false;
                    //    cmbFormulaType.Text = "NonValidated";
                    //}
                    //else
                    //{
                    //    cmbFormulaType.Enabled = true;
                    //    cmbFormulaType.Text = "--Select--";
                    //}
                }



                //New Launch for first transaction of newly added formula
                DataSet dsF = new DataSet();
                BulktestDetailstransaction_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                dsF = BulktestDetailstransaction_Class_Obj.Select_tblTransFM_FNo();
                if (dsF.Tables[0].Rows.Count > 0)
                {
                    RdoRegularProduct.Enabled = true;
                    RdoNewLaunch.Enabled = false;
                    RdoNewLaunch.Checked = false;
                    RdoRegularProduct.Checked = true;
                }
                else
                {
                    RdoRegularProduct.Enabled = false;
                    RdoNewLaunch.Enabled = true;
                    RdoNewLaunch.Checked = true;
                    RdoRegularProduct.Checked = false;

                    cmbFormulaType.Text = "NonValidated";
                    cmbFormulaType.Enabled = false;
                    NewLaunch_Test(Convert.ToString(ds.Tables[0].Rows[0]["Fno"]));

                    NotifyWindow nw = new NotifyWindow("New Launch", Convert.ToString(ds.Tables[0].Rows[0]["FormulaNo"]));
                    nw.Notify();
                }

                //test
                //NotifyWindow nw1 = new NotifyWindow("New Launch", Convert.ToString(ds.Tables[0].Rows[0]["FormulaNo"]));
                //nw1.Notify();
            }
            else
            {
                labelNorms.Visible = lblBacterialCount.Visible = lblFungalCount.Visible = false;
                txtNorms.Visible = txtBacterialCount.Visible = txtFungalCount.Visible = false;
                txtNorms.Text = txtBacterialCount.Text = txtFungalCount.Text = "";
            }
        }

        /// <summary>
        /// Selection change commited event for formula type combo box  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFormulaType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dgTest.Rows.Clear();
                dgTestCon.Rows.Clear();



                txtMfgWoNo.Text = "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0';

                if (CmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Enter Proper Formula No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CmbFormulaNo.Focus();
                    return;
                }

                if (cmbFormulaType.Text == "--Select--")
                {
                    //MessageBox.Show("Select Formula Type", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbFormulaType.Focus();
                    return;
                }

                //Dispaly tests applicable to Formula from formula master 
                DataSet ds = new DataSet();
                if (CmbFormulaNo.SelectedValue != null)
                {
                    FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                    FormulaNoMaster_Class_Obj.formulatype = cmbFormulaType.Text;
                    ds = FormulaNoMaster_Class_Obj.SELECT_tblBulkPhysicochemicalTestMethodMaster_FNo_FormulaType();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                            {
                                dgTest.Rows.Add();
                                dgTest["BulkMethodNo", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["BulkMethodNo"].ToString();
                                dgTest["Test", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Test"].ToString();
                                dgTest["Min", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgTest["Max", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();

                            }
                            if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                            {
                                dgTestCon.Rows.Add();
                                dgTestCon["BulkMethodNoCon", dgTestCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["BulkMethodNo"].ToString();
                                dgTestCon["TestCon", dgTestCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Test"].ToString();
                                dgTestCon["MinCon", dgTestCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgTestCon["MaxCon", dgTestCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                            }

                            //Instrument caliberation
                            //Instruments are linked to test in Instrument master
                            //If due date for perticular instrument is ahead in 1 mothe then it will display message  
                            DataSet dsI = new DataSet();
                            InstrumentMaster_Class_Obj.testno = Convert.ToInt64(ds.Tables[0].Rows[i]["TestNo"]);
                            dsI = InstrumentMaster_Class_Obj.Select_tblInstrument_TestMaster_TestNo();
                            if (dsI.Tables[0].Rows.Count > 0)
                            {
                                for (int c = 0; c < dsI.Tables[0].Rows.Count; c++)
                                {
                                    if (dsI.Tables[0].Rows[c]["DueDate"] is System.DBNull)
                                    {

                                    }
                                    else
                                    {
                                        if (Comman_Class_Obj.Select_ServerDate().AddMonths(1) > Convert.ToDateTime(dsI.Tables[0].Rows[c]["DueDate"]))
                                        {
                                            //MessageBox.Show(dsI.Tables[0].Rows[c]["Instrument"].ToString(), "Caliber Instrument", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            NotifyWindow nw = new NotifyWindow("Caliber Instrument", dsI.Tables[0].Rows[c]["Instrument"].ToString());
                                            nw.Notify();
                                        }
                                    }
                                }
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

        /// <summary>
        /// leave enent for MfgWo text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMfgWoNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (CmbFormulaNo.Text == "--Select--" || CmbFormulaNo.SelectedValue == null || CmbFormulaNo.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Enter Proper Formula No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CmbFormulaNo.Focus();
                    return;
                }

                if (cmbFormulaType.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula Type", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbFormulaType.Focus();
                    return;
                }

                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                txtMfgWoNo.Text = textInfo.ToTitleCase(txtMfgWoNo.Text);

                //if (txtMfgWoNo.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter MfgWO No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    txtMfgWoNo.Focus();
                //    return;
                //}


                BulktestDetailstransaction_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString()); ;
                BulktestDetailstransaction_Class_Obj.mfgwo = txtMfgWoNo.Text.Trim();

                //If formula and MfgWo is already exists then display previous entries
                DataSet dsDetails = new DataSet();
                dsDetails = BulktestDetailstransaction_Class_Obj.Select_tblBulkTestTransaction_FNo_MfgWo();
                if (dsDetails.Tables[0].Rows.Count > 0)
                {
                    reset();

                    BulktestDetailstransaction_Class_Obj.fmid = Convert.ToInt64(dsDetails.Tables[0].Rows[0]["FMID"]);

                    txtNoofBatches.Text = dsDetails.Tables[0].Rows[0]["NoBatches"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(dsDetails.Tables[0].Rows[0]["Supplier"])))
                    {
                        if (Convert.ToString(dsDetails.Tables[0].Rows[0]["Supplier"]).Equals("UP1", StringComparison.CurrentCultureIgnoreCase))
                        {
                            cmbManufactured.SelectedIndex = 1;

                        }
                        else if (Convert.ToString(dsDetails.Tables[0].Rows[0]["Supplier"]).Equals("UP2", StringComparison.CurrentCultureIgnoreCase))
                        {
                            cmbManufactured.SelectedIndex = 2;
                        }
                        else
                        {
                            if (dsDetails.Tables[0].Rows[0]["FGSupplierId"] is DBNull)
                            {
                                //DtpStartedOn.Value = Comman_Class_Obj.Select_ServerDate();
                            }
                            else
                            {

                                cmbManufactured.SelectedIndex = 3;
                                cmbManufactured_SelectionChangeCommitted(sender, e);
                                int FGSupplierId = Convert.ToInt32(dsDetails.Tables[0].Rows[0]["FGSupplierId"]);
                                if (FGSupplierId > 0)
                                {
                                    DataSet dsSupplierName = new DataSet();
                                    dsSupplierName = BulktestDetailstransaction_Class_Obj.Select_FGSupplier_By_SupplierID(FGSupplierId);
                                    if (dsSupplierName.Tables.Count > 0)
                                    {
                                        if (dsSupplierName.Tables[0].Rows.Count > 0)
                                        {
                                            if (dsSupplierName.Tables[0].Rows[0]["FGSupplierName"] is DBNull)
                                            {
                                                //DtpStartedOn.Value = Comman_Class_Obj.Select_ServerDate();
                                            }
                                            else
                                            {
                                                cmbSupplier.SelectedText = Convert.ToString(dsSupplierName.Tables[0].Rows[0]["FGSupplierName"]);
                                                cmbSupplier.Text = Convert.ToString(dsSupplierName.Tables[0].Rows[0]["FGSupplierName"]);
                                            }
                                        }
                                    }
                                }


                                //if (cmbSupplier.Items.Count > 0)
                                //{
                                //    cmbSupplier.Text = Convert.ToString(dsDetails.Tables[0].Rows[0]["Supplier"]);
                                //}
                            }

                        }
                    }
                    //txtSupplier.Text = dsDetails.Tables[0].Rows[0]["Supplier"].ToString();
                    CmbVesselNo.SelectedValue = Convert.ToInt32(dsDetails.Tables[0].Rows[0]["VesselNo"]);
                    txtSerialNo.Text = dsDetails.Tables[0].Rows[0]["SerialNo"].ToString();
                    txtBatchSize.Text = dsDetails.Tables[0].Rows[0]["BatchSize"].ToString();
                    DtpInspDate.Value = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["InspDate"].ToString());

                    if (dsDetails.Tables[0].Rows[0]["StartedOn"] is DBNull)
                    {
                        DtpStartedOn.Value = Comman_Class_Obj.Select_ServerDate();
                    }
                    else
                    {
                        DtpStartedOn.Value = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["StartedOn"].ToString());
                    }
                    if (dsDetails.Tables[0].Rows[0]["CompletedOn"] is DBNull)
                    {
                        DtpCompletedOn.Value = Comman_Class_Obj.Select_ServerDate();
                    }
                    else
                    {
                        DtpCompletedOn.Value = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["CompletedOn"].ToString());
                    }

                    if (dsDetails.Tables[0].Rows[0]["ExtLabReportNo"] is DBNull)
                    {
                        txtExtLabReportNo.Text = "";
                    }
                    else
                    {
                        txtExtLabReportNo.Text = dsDetails.Tables[0].Rows[0]["ExtLabReportNo"].ToString();
                    }

                    if (dsDetails.Tables[0].Rows[0]["FlagRL"].ToString() == "R")
                    {
                        RdoRegularProduct.Checked = true;
                    }
                    else if (dsDetails.Tables[0].Rows[0]["FlagRL"].ToString() == "L")
                    {
                        RdoNewLaunch.Checked = true;
                    }
                    DtpDateOfValidation.Value = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["ValidDate"].ToString());

                    if (dsDetails.Tables[0].Rows[0]["FormulationApproved"].ToString() == "N")
                    {
                        cmbFA.Text = "N/A";
                    }
                    else if (dsDetails.Tables[0].Rows[0]["FormulationApproved"].ToString() == "Y")
                    {
                        cmbFA.Text = "Yes";
                    }
                    else if (dsDetails.Tables[0].Rows[0]["FormulationApproved"].ToString() == "R")
                    {
                        cmbFA.Text = "Reject";
                    }
                    else if (dsDetails.Tables[0].Rows[0]["FormulationApproved"].ToString() == "P")
                    {
                        cmbFA.Text = "Pending";
                    }

                    if (Convert.ToInt32(dsDetails.Tables[0].Rows[0]["SubContract"]) == 1)
                    {
                        chkSubContract.Checked = true;
                    }
                    else
                    {
                        chkSubContract.Checked = false;
                    }
                    if (Convert.ToString(dsDetails.Tables[0].Rows[0]["dwp"]) == "" || Convert.ToInt32(dsDetails.Tables[0].Rows[0]["dwp"]) == 0)
                    {
                        rbDWPNo.Checked = true;
                    }
                    else
                    {
                        rbDWPYes.Checked = true;
                    }

                    cmbInspectedBy.SelectedValue = Convert.ToInt32(dsDetails.Tables[0].Rows[0]["InspectedBy"]);
                    if (dsDetails.Tables[0].Rows[0]["VerifiedBy"].ToString() != "")
                        cmbVerifiedBy.SelectedValue = Convert.ToInt32(dsDetails.Tables[0].Rows[0]["VerifiedBy"]);
                }
                else
                {
                    //No of batches
                    //Calculated from the fno only
                    long cnt = BulktestDetailstransaction_Class_Obj.Select_tblBulktesttransaction_NoBatches();
                    cnt = cnt + 1;
                    txtNoofBatches.Text = Convert.ToString(cnt);
                }

                //display the assigned tanks
                DataSet ds2 = new DataSet();
                ds2 = BulktestDetailstransaction_Class_Obj.Select_tblBulktankDetails_FNo_MfgWo();
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ChkTankNo.Items.Count; j++)
                    {
                        if (ds2.Tables[0].Rows[i]["TkDesc"].ToString() == ChkTankNo.GetItemText(ChkTankNo.Items[j]))
                        {
                            ChkTankNo.SetItemChecked(j, true);
                            break;
                        }
                    }
                }

                //IF details already filled then display
                DataSet ds;
                for (int i = 0; i < dgTest.Rows.Count; i++)
                {
                    ds = new DataSet();
                    //FNo
                    //MfgWo
                    BulktestDetailstransaction_Class_Obj.bulkmethodno = Convert.ToInt64(dgTest["BulkMethodNo", i].Value);
                    ds = BulktestDetailstransaction_Class_Obj.Select_tblBulkPhysicochemicalTestMethodDetails();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgTest["InitialValue", i].Value = ds.Tables[0].Rows[0]["InitialValue"].ToString();
                        dgTest["FinalValue", i].Value = ds.Tables[0].Rows[0]["FinalValue"].ToString();
                        dgTest["Reading", i].Value = ds.Tables[0].Rows[0]["NormsReading"].ToString();
                    }
                }
                for (int i = 0; i < dgTestCon.Rows.Count; i++)
                {
                    ds = new DataSet();
                    //FNo
                    //MfgWo
                    BulktestDetailstransaction_Class_Obj.bulkmethodno = Convert.ToInt64(dgTestCon["BulkMethodNoCon", i].Value);
                    ds = BulktestDetailstransaction_Class_Obj.Select_tblBulkPhysicochemicalTestMethodDetails();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgTestCon["InitialValueCon", i].Value = ds.Tables[0].Rows[0]["InitialValue"].ToString();
                        dgTestCon["FinalValueCon", i].Value = ds.Tables[0].Rows[0]["FinalValue"].ToString();
                        dgTestCon["ReadingCon", i].Value = ds.Tables[0].Rows[0]["NormsReading"].ToString();
                    }
                }

                // txtSupplier.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Saves the bulk details 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (CmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbFormulaNo.Focus();
                    return;
                }
                if (BulktestDetailstransaction_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Select Record From List", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbFormulaNo.Focus();
                    return;
                }
                else if (txtMfgWoNo.Text.Trim() == "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0')
                {
                    MessageBox.Show("Enter Workorder No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMfgWoNo.Focus();
                    return;
                }
                else if (txtNoofBatches.Text.Trim() == "")
                {
                    MessageBox.Show("No of batches not ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMfgWoNo.Focus();
                    return;
                }
                else if (cmbFormulaType.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula Type", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbFormulaType.Focus();
                    return;
                }
                else if (CmbVesselNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Vessel No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbVesselNo.Focus();
                    return;
                }
                if (txtBatchSize.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Batch Size", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBatchSize.Focus();
                    return;
                }
                if (RdoHold.Checked != true)
                {
                    if (RdoNewLaunch.Checked != true && RdoRegularProduct.Checked != true)
                    {
                        MessageBox.Show("Select Regular/NewLaunch", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (RdoHold.Checked != true)
                {
                    if (RdoNonBpc.Checked != true && RdoBpc.Checked != true && RdoIQ.Checked != true)
                    {
                        MessageBox.Show("Select IQ follow up/BPC/NonBPC", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (RdoNonBpc.Checked == true)
                {
                    if (txtComment_NonBpc.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter Non BPC Comment", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtComment_NonBpc.Focus();
                        return;
                    }
                }
                if (RdoAccepted.Checked == false && RdoRejected.Checked == false && RdoAcceptedwithDerrogation.Checked == false && RdoHold.Checked == false)
                {
                    MessageBox.Show("Please Select Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (RdoAcceptedwithDerrogation.Checked == true)
                {
                    if (txtComment_Accepted.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter Derrogation Comment", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtComment_Accepted.Focus();
                        return;
                    }
                }
                if (RdoRejected.Checked == true)
                {
                    if (txtComment_Accepted.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter Reject Comment", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtComment_Accepted.Focus();
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
                if (RdoHold.Checked != true)
                {
                    bool c = false;
                    for (int i = 0; i < ChkTankNo.Items.Count; i++)
                    {
                        if (ChkTankNo.GetItemChecked(i) == true)
                        {
                            c = true;

                            break;
                        }
                    }
                    if (c == false)
                    {
                        MessageBox.Show("Select Tank No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ChkTankNo.Focus();
                        return;
                    }
                }

                if (RdoNewLaunch.Checked == true)
                {
                    if (MessageBox.Show("New Launch ?", "Regular/Launch", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoRegularProduct.Checked == true)
                {
                    if (MessageBox.Show("Regular ?", "Regular/Launch", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (rbDWPYes.Checked != true && rbDWPNo.Checked != true)
                {
                    MessageBox.Show("Select DWP", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rbDWPNo.Focus();
                    return;
                }
                //if record is not on hold
                //all the readings are compulsory 
                if (RdoHold.Checked != true)
                {
                    for (int i = 0; i < dgTest.Rows.Count; i++)
                    {
                        if (dgTest["Reading", i].Value == null || dgTest["Reading", i].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Fill all the Identification Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgTest.Focus();
                            return;
                        }
                    }
                    for (int i = 0; i < dgTestCon.Rows.Count; i++)
                    {
                        if (dgTestCon["ReadingCon", i].Value == null || dgTestCon["ReadingCon", i].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Fill all the Control Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgTestCon.Focus();
                            return;
                        }
                    }
                }
                if (RdoBpc.Checked == true)
                {
                    if (MessageBox.Show("BPC ?", "BPC/NonBPC", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoNonBpc.Checked == true)
                {
                    if (MessageBox.Show("Non BPC ?", "BPC/NonBPC", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoIQ.Checked == true)
                {
                    if (MessageBox.Show("IQ follow up ?", "BPC/NonBPC", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
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
                if (RdoAcceptedwithDerrogation.Checked == true)
                {
                    if (MessageBox.Show("ACCEPT WITH DERROGATION ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (cmbManufactured.SelectedIndex == 0)
                {
                    MessageBox.Show("Select Manufactured By", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbManufactured.Focus();
                    return;
                }
                else
                {
                    if (!string.IsNullOrEmpty(cmbManufactured.Text))
                    {
                        if (cmbManufactured.Text.Equals("SubContractor", StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (cmbSupplier.SelectedIndex == 0)
                            {
                                MessageBox.Show("Select Sub Contractor", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cmbSupplier.Focus();
                                return;
                            }
                        }
                    }
                }
                if (RdoHold.Checked == true)
                {
                    if (MessageBox.Show("HOLD ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }

                //Normal user doesn't have the access to accept to reject the record
                //if (RdoHold.Checked != true && FrmMain.UserType == 'N')
                //{
                //    MessageBox.Show("Sorry..\n\nYou can only HOLD the record", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;                    
                //}




                BulktestDetailstransaction_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                BulktestDetailstransaction_Class_Obj.mfgwo = txtMfgWoNo.Text.Trim();

                //if the bulk is supplied by the subcontractor then this flag is set 
                if (chkSubContract.Checked == true)
                {
                    BulktestDetailstransaction_Class_Obj.subcontract = 1;
                }
                else
                {
                    BulktestDetailstransaction_Class_Obj.subcontract = 0;
                }

                //Chech record for same formula no and mfgwo exists in tblTransFM 
                DataSet ds = new DataSet();
                BulktestDetailstransaction_Class_Obj.fmid = 0;
                BulktestDetailstransaction_Class_Obj.fmid = BulktestDetailstransaction_Class_Obj.SELECT_tblTransFM_FNo_MfgWo();
                if (BulktestDetailstransaction_Class_Obj.fmid != 0)
                {
                    if (MessageBox.Show("Record for this Formula No and MfgWo already exists...!\n\n Update ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        txtMfgWoNo.Focus();
                        return;
                    }

                }
                else
                {
                    // insert FNo and MfgWo into tblFM 
                    BulktestDetailstransaction_Class_Obj.fmid = BulktestDetailstransaction_Class_Obj.INSERT_tblTransFM_FNo_MfgWo();
                }


                BulktestDetailstransaction_Class_Obj.formulatype = cmbFormulaType.Text;
                BulktestDetailstransaction_Class_Obj.Inspdate = DtpInspDate.Value.ToShortDateString();
                BulktestDetailstransaction_Class_Obj.vesselno = Convert.ToInt32(CmbVesselNo.SelectedValue);
                BulktestDetailstransaction_Class_Obj.supplier = cmbManufactured.Text.Trim();

                BulktestDetailstransaction_Class_Obj.ManufacturedById = Convert.ToInt32(cmbManufactured.SelectedValue);
                if (cmbSupplier.SelectedIndex > 0)
                {
                    BulktestDetailstransaction_Class_Obj.FGSupplierId = Convert.ToInt64(cmbSupplier.SelectedValue);
                }

                //txtSupplier.Text.Trim();
                BulktestDetailstransaction_Class_Obj.startedon = DtpStartedOn.Value.ToShortDateString();
                BulktestDetailstransaction_Class_Obj.completedon = DtpCompletedOn.Value.ToShortDateString();
                BulktestDetailstransaction_Class_Obj.extlabreportno = txtExtLabReportNo.Text.Trim();
                BulktestDetailstransaction_Class_Obj.micronorms = txtNorms.Text.Trim();
                if (txtNoofBatches.Text == "")
                {
                    BulktestDetailstransaction_Class_Obj.noofbatches = 0;
                }
                else
                {
                    BulktestDetailstransaction_Class_Obj.noofbatches = Convert.ToInt32(txtNoofBatches.Text);
                }
                if (txtBatchSize.Text == "")
                {
                    BulktestDetailstransaction_Class_Obj.batchsize = 0;
                }
                else
                {
                    BulktestDetailstransaction_Class_Obj.batchsize = Convert.ToInt32(txtBatchSize.Text);
                }

                //chnaged by sanjiv on 7-May-2014 for adding DWP
                if (rbDWPYes.Checked == true)
                {
                    BulktestDetailstransaction_Class_Obj.dwp = true;
                }
                if (rbDWPNo.Checked == true)
                {
                    BulktestDetailstransaction_Class_Obj.dwp = false;
                }
                BulktestDetailstransaction_Class_Obj.serialno = txtSerialNo.Text.Trim();
                BulktestDetailstransaction_Class_Obj.validdate = DtpDateOfValidation.Value.ToShortDateString();
                if (RdoRegularProduct.Checked == true)
                {
                    BulktestDetailstransaction_Class_Obj.flagrl = Convert.ToChar("R");

                }
                else
                {
                    BulktestDetailstransaction_Class_Obj.flagrl = Convert.ToChar("L");
                }

                if (cmbFA.Text == "N/A")
                {
                    BulktestDetailstransaction_Class_Obj.fa = Convert.ToChar("N");
                }
                else if (cmbFA.Text == "Yes")
                {
                    BulktestDetailstransaction_Class_Obj.fa = Convert.ToChar("Y");
                }
                else if (cmbFA.Text == "Reject")
                {
                    BulktestDetailstransaction_Class_Obj.fa = Convert.ToChar("R");
                }
                else if (cmbFA.Text == "Pending")
                {
                    BulktestDetailstransaction_Class_Obj.fa = Convert.ToChar("P");
                }

                if (RdoBpc.Checked == true)
                {
                    BulktestDetailstransaction_Class_Obj.bpcnonbpc = Convert.ToChar("B");
                    BulktestDetailstransaction_Class_Obj.nonbpccomment = "";
                }
                else if (RdoIQ.Checked == true)
                {
                    BulktestDetailstransaction_Class_Obj.bpcnonbpc = Convert.ToChar("I");
                    BulktestDetailstransaction_Class_Obj.nonbpccomment = "";
                }
                else
                {
                    BulktestDetailstransaction_Class_Obj.bpcnonbpc = Convert.ToChar("N");
                    BulktestDetailstransaction_Class_Obj.nonbpccomment = txtComment_NonBpc.Text;
                }
                if (RdoAccepted.Checked == true)
                {
                    BulktestDetailstransaction_Class_Obj.status = Convert.ToChar("A");
                }
                else if (RdoAcceptedwithDerrogation.Checked == true)
                {
                    BulktestDetailstransaction_Class_Obj.status = Convert.ToChar("D");
                    BulktestDetailstransaction_Class_Obj.comments = txtComment_Accepted.Text;
                }
                else if (RdoRejected.Checked == true)
                {
                    BulktestDetailstransaction_Class_Obj.status = Convert.ToChar("R");
                    BulktestDetailstransaction_Class_Obj.comments = txtComment_Accepted.Text;
                }
                else if (RdoHold.Checked == true)
                {
                    BulktestDetailstransaction_Class_Obj.status = Convert.ToChar("H");
                }

                BulktestDetailstransaction_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);
                BulktestDetailstransaction_Class_Obj.verifiedby = Convert.ToInt32(cmbVerifiedBy.SelectedValue);

                BulktestDetailstransaction_Class_Obj.loginid = FrmMain.LoginID;

                DataSet dsFMID = new DataSet();
                dsFMID = BulktestDetailstransaction_Class_Obj.Select_tblBulkTestTransaction_FMID();
                if (dsFMID.Tables[0].Rows.Count > 0)
                {
                    BulktestDetailstransaction_Class_Obj.bulkno = Convert.ToInt64(dsFMID.Tables[0].Rows[0]["BulkNo"]);
                    //update the transaction details
                    BulktestDetailstransaction_Class_Obj.Update_tblBulkTestDetailstransaction();
                }
                else
                {
                    //inserts the transaction details
                    BulktestDetailstransaction_Class_Obj.bulkno = BulktestDetailstransaction_Class_Obj.Insert_tblBulkTestDetailstransaction();
                }

                if (BulktestDetailstransaction_Class_Obj.fmid != 0)
                {
                    DataSet dsTank;

                    // Tank Details  Record saved in tblBulktankdetails
                    for (int i = 0; i < ChkTankNo.Items.Count; i++)
                    {
                        if (ChkTankNo.GetItemChecked(i) == true)
                        {
                            ChkTankNo.SetSelected(i, true);
                            int obj = Convert.ToInt32(ChkTankNo.SelectedValue);
                            BulktestDetailstransaction_Class_Obj.tankno = obj;
                            dsTank = new DataSet();
                            dsTank = BulktestDetailstransaction_Class_Obj.Select_tblBulkTankDetails_FMID_TankNo();
                            //if tank details not exists then add
                            if (dsTank.Tables[0].Rows.Count == 0)
                            {
                                // insert in table
                                BulktestDetailstransaction_Class_Obj.INSERT_tblBulktankdetails();
                            }
                        }
                    }

                    //Delete previous already added details
                    BulktestDetailstransaction_Class_Obj.Delete_tblBulkPhysicochemicalTestMethodDetails_FMID();

                    //Test details Record saved in tblBulkPhysicochemicalTestMethodDetails
                    for (int i = 0; i < dgTest.Rows.Count; i++)
                    {
                        BulktestDetailstransaction_Class_Obj.bulkmethodno = Convert.ToInt64(dgTest["BulkMethodNo", i].Value);
                        if (dgTest["Min", i].Value == null)
                        {
                            BulktestDetailstransaction_Class_Obj.normmin = "";
                        }
                        else
                        {
                            BulktestDetailstransaction_Class_Obj.normmin = dgTest["Min", i].Value.ToString();
                        }

                        if (dgTest["Max", i].Value == null)
                        {
                            BulktestDetailstransaction_Class_Obj.normmax = "";
                        }
                        else
                        {
                            BulktestDetailstransaction_Class_Obj.normmax = dgTest["Max", i].Value.ToString();
                        }
                        if (dgTest["InitialValue", i].Value == null)
                        {
                            BulktestDetailstransaction_Class_Obj.initialvalue = "";
                        }
                        else
                        {
                            BulktestDetailstransaction_Class_Obj.initialvalue = dgTest["InitialValue", i].Value.ToString();
                        }

                        if (dgTest["FinalValue", i].Value == null)
                        {
                            BulktestDetailstransaction_Class_Obj.finalvalue = "";
                        }
                        else
                        {
                            BulktestDetailstransaction_Class_Obj.finalvalue = dgTest["FinalValue", i].Value.ToString();
                        }

                        if (dgTest["Reading", i].Value == null)
                        {
                            BulktestDetailstransaction_Class_Obj.reading = "";
                        }
                        else
                        {
                            BulktestDetailstransaction_Class_Obj.reading = dgTest["Reading", i].Value.ToString();
                        }

                        // inserts the initial/final values and readings in method details table
                        BulktestDetailstransaction_Class_Obj.INSERT_tblBulkPhysicochemicalTestMethodDetails();
                    }
                    for (int i = 0; i < dgTestCon.Rows.Count; i++)
                    {
                        BulktestDetailstransaction_Class_Obj.bulkmethodno = Convert.ToInt64(dgTestCon["BulkMethodNoCon", i].Value);
                        if (dgTestCon["MinCon", i].Value == null)
                        {
                            BulktestDetailstransaction_Class_Obj.normmin = "";
                        }
                        else
                        {
                            BulktestDetailstransaction_Class_Obj.normmin = dgTestCon["MinCon", i].Value.ToString();
                        }

                        if (dgTestCon["MaxCon", i].Value == null)
                        {
                            BulktestDetailstransaction_Class_Obj.normmax = "";
                        }
                        else
                        {
                            BulktestDetailstransaction_Class_Obj.normmax = dgTestCon["MaxCon", i].Value.ToString();
                        }
                        if (dgTestCon["InitialValueCon", i].Value == null)
                        {
                            BulktestDetailstransaction_Class_Obj.initialvalue = "";
                        }
                        else
                        {
                            BulktestDetailstransaction_Class_Obj.initialvalue = dgTestCon["InitialValueCon", i].Value.ToString();
                        }

                        if (dgTestCon["FinalValueCon", i].Value == null)
                        {
                            BulktestDetailstransaction_Class_Obj.finalvalue = "";
                        }
                        else
                        {
                            BulktestDetailstransaction_Class_Obj.finalvalue = dgTestCon["FinalValueCon", i].Value.ToString();
                        }

                        if (dgTestCon["ReadingCon", i].Value == null)
                        {
                            BulktestDetailstransaction_Class_Obj.reading = "";
                        }
                        else
                        {
                            BulktestDetailstransaction_Class_Obj.reading = dgTestCon["ReadingCon", i].Value.ToString();
                        }

                        // inserts the initial/final values and readings in method details table
                        BulktestDetailstransaction_Class_Obj.INSERT_tblBulkPhysicochemicalTestMethodDetails();
                    }

                    if (MessageBox.Show("Record Saved Successfully\n\nPrint Protocol?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        //display protocol
                        btnProtocol_Click(sender, e);
                    }
                    BtnReset_Click(sender, e);
                    CmbFormulaNo.Focus();
                    lstTankDesc.Clear();
                    Bind_Tank();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// leave event for NonBpc comment textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtComment_NonBpc_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtComment_NonBpc.Text = textInfo.ToTitleCase(txtComment_NonBpc.Text);
        }

        /// <summary>
        /// leave event for Commnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtComment_Accepted_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtComment_Accepted.Text = textInfo.ToTitleCase(txtComment_Accepted.Text);
        }

        /// <summary>
        /// key press event for batch size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBatchSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only 0-9 and dot(.) allowed
            if ((Convert.ToInt32(e.KeyChar) != 8))
            {
                if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
                {

                }
                else
                { e.Handled = true; }
            }
        }

        /// <summary>
        /// Checked change event for Non BPC radio button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoNonBpc_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoNonBpc.Checked == true)
            {
                txtComment_NonBpc.Enabled = true;
                //txtComment_NonBpc.Focus();
                txtComment_NonBpc.BackColor = Color.White;
            }
            else if (RdoNonBpc.Checked == false)
            {
                txtComment_NonBpc.Enabled = false;
                txtComment_NonBpc.Text = "";
                txtComment_NonBpc.BackColor = Color.FromArgb(242, 246, 252);
            }
        }

        /// <summary>
        /// checked change event for AWD radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoAcceptedwithDerrogation_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoAcceptedwithDerrogation.Checked == true)
            {
                txtComment_Accepted.Enabled = true;
                //txtComment_Accepted.Focus();
                txtComment_Accepted.BackColor = Color.White;
            }
            //else if (RdoAcceptedwithDerrogation.Checked == false)
            //{
            //    txtComment_Accepted.Enabled = false;
            //    txtComment_Accepted.Text = "";
            //}
        }

        /// <summary>
        /// Edit control showing event for Identification Test grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgTest.CurrentCell.RowIndex < 0
                || (dgTest.CurrentCell.ColumnIndex != dgTest.Columns["Reading"].Index && dgTest.CurrentCell.ColumnIndex != dgTest.Columns["InitialValue"].Index && dgTest.CurrentCell.ColumnIndex != dgTest.Columns["FinalValue"].Index))
            {
                return;
            }
            else if (dgTest.CurrentCell.ColumnIndex == dgTest.Columns["Reading"].Index || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["InitialValue"].Index || dgTest.CurrentCell.ColumnIndex == dgTest.Columns["FinalValue"].Index)
            {
                dgTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        /// <summary>
        /// Edit control showing event for Control test grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTestCon_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgTestCon.CurrentCell.RowIndex < 0
                || (dgTestCon.CurrentCell.ColumnIndex != dgTestCon.Columns["ReadingCon"].Index && dgTestCon.CurrentCell.ColumnIndex != dgTestCon.Columns["InitialValueCon"].Index && dgTestCon.CurrentCell.ColumnIndex != dgTestCon.Columns["FinalValueCon"].Index))
            {
                return;
            }
            else if (dgTestCon.CurrentCell.ColumnIndex == dgTestCon.Columns["ReadingCon"].Index || dgTestCon.CurrentCell.ColumnIndex == dgTestCon.Columns["InitialValueCon"].Index || dgTestCon.CurrentCell.ColumnIndex == dgTestCon.Columns["InitialValueCon"].Index)
            {
                dgTestCon.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        /// <summary>
        /// Key press event for Readings  
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
        /// Key press event for MfgWo textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMfgWoNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(32))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Display protocol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProtocol_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbFormulaNo.Focus();
                    return;
                }
                if (BulktestDetailstransaction_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Select Record From List", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbFormulaNo.Focus();
                    return;
                }
                else if (cmbFormulaType.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFormulaType.Focus();
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

                string ProtocolNo = "";
                if (BulktestDetailstransaction_Class_Obj.fmid != 0)
                {
                    ProtocolNo = "BLK" + BulktestDetailstransaction_Class_Obj.fmid.ToString().PadLeft(6, '0');
                }

                //Get data to diaply on protocol
                DataSet ds = new DataSet();
                BulktestDetailstransaction_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                BulktestDetailstransaction_Class_Obj.formulatype = cmbFormulaType.Text;
                ds = BulktestDetailstransaction_Class_Obj.Select_VIEW_Protocol_Bulk();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Open form to display report
                    //send the DWP value
                    String DWP = (rbDWPYes.Checked == true ? "Yes" : "No");
                    QTMS.Reports_Forms.FrmProtocol pro = new QTMS.Reports_Forms.FrmProtocol("Bulk Protocol", ds.Tables[0], txtMfgWoNo.Text.Trim(), DtpCompletedOn.Value.ToShortDateString(), (cmbManufactured.Text.Trim() == "SubContractor" ? cmbSupplier.Text : cmbManufactured.Text.Trim()), txtBatchSize.Text.Trim(), DtpInspDate.Value.ToShortDateString(), ProtocolNo, cmbInspectedBy.Text.Trim(), cmbVerifiedBy.Text.Trim(), DWP);
                    pro.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checked change event for Regular product radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoRegularProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoRegularProduct.Checked == true)
            {
                cmbFA.Text = "N/A";
            }
        }

        /// <summary>
        /// Cell validating event for Test gris
        /// Reading cell becomes red if reading value is out of norms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                       // if (GlobalVariables.City == "BADDI")
                            OOS_Begin(dgTest["BulkMethodNo", dgTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgTest["Test", dgTest.CurrentCell.RowIndex].Value.ToString().Trim());
                        return;
                    }

                    if (dgTest["Max", dgTest.CurrentCell.RowIndex].Value != null && dgTest["Max", dgTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgTest["Max", dgTest.CurrentCell.RowIndex].Value))
                        {
                            dgTest.CurrentCell.Style.BackColor = Color.Red;
                           // if (GlobalVariables.City == "BADDI")
                                OOS_Begin(dgTest["BulkMethodNo", dgTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgTest["Test", dgTest.CurrentCell.RowIndex].Value.ToString().Trim());
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
                           // if (GlobalVariables.City == "BADDI")
                                OOS_Begin(dgTest["BulkMethodNo", dgTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgTest["Test", dgTest.CurrentCell.RowIndex].Value.ToString().Trim());
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

        /// <summary>
        /// Cell validating event for Test gris
        /// Reading cell becomes red if reading value is out of norms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTestCon_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgTestCon.Columns["ReadingCon"].Index)
            {
                return;
            }
            else
            {
                if (dgTestCon.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgTestCon["MaxCon", dgTestCon.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgTestCon["MinCon", dgTestCon.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgTestCon.CurrentCell.Style.BackColor = Color.Red;
                       // if (GlobalVariables.City == "BADDI")
                            OOS_Begin(dgTestCon["BulkMethodNoCon", dgTestCon.CurrentCell.RowIndex].Value.ToString().Trim(), dgTestCon["TestCon", dgTestCon.CurrentCell.RowIndex].Value.ToString().Trim());
                        return;
                    }

                    if (dgTestCon["MaxCon", dgTestCon.CurrentCell.RowIndex].Value != null && dgTestCon["MaxCon", dgTestCon.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgTestCon.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgTestCon["MaxCon", dgTestCon.CurrentCell.RowIndex].Value))
                        {
                            dgTestCon.CurrentCell.Style.BackColor = Color.Red;
                           // if (GlobalVariables.City == "BADDI")
                                OOS_Begin(dgTestCon["BulkMethodNoCon", dgTestCon.CurrentCell.RowIndex].Value.ToString().Trim(), dgTestCon["TestCon", dgTestCon.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dgTestCon.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgTestCon["MinCon", dgTestCon.CurrentCell.RowIndex].Value != null && dgTestCon["MinCon", dgTestCon.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgTestCon.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgTestCon["MinCon", dgTestCon.CurrentCell.RowIndex].Value))
                        {
                            dgTestCon.CurrentCell.Style.BackColor = Color.Red;
                           // if (GlobalVariables.City == "BADDI")
                                OOS_Begin(dgTestCon["BulkMethodNoCon", dgTestCon.CurrentCell.RowIndex].Value.ToString().Trim(), dgTestCon["TestCon", dgTestCon.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dgTestCon.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dgTestCon.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        /// <summary>
        /// Cell validate enevt for test grid
        /// If Reading value is out of norm then record should be rejected
        /// Rejected Radio button should be checked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                for (int i = 0; i < dgTestCon.Rows.Count; i++)
                {
                    if (dgTestCon["ReadingCon", i].Style.BackColor == Color.Red)
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

        /// <summary>
        /// Cell validate enevt for test grid
        /// If Reading value is out of norm then record should be rejected
        /// Rejected Radio button should be checked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTestCon_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgTestCon.Columns["ReadingCon"].Index)
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

                for (int i = 0; i < dgTestCon.Rows.Count; i++)
                {
                    if (dgTestCon["ReadingCon", i].Style.BackColor == Color.Red)
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

        /// <summary>
        /// leave evenmt for protocol no text box
        /// get the FMID from protocol no and display the readings according to that
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProtocolNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtProtocolNo.Text.Trim() != "")
                {
                    BtnReset_Click(sender, e);

                    if (txtProtocolNo.Text.StartsWith("BLK"))
                    {
                        int i = 0;
                        if (Int32.TryParse(txtProtocolNo.Text.Remove(0, 3), out i))
                        {
                            //display the bulk test details
                            BulktestDetailstransaction_Class_Obj.fmid = Convert.ToInt64(i);
                            DataSet ds = new DataSet();
                            ds = BulktestDetailstransaction_Class_Obj.Select_BulkTestDetail_ProtocolNo();
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                CmbFormulaNo.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["FNo"]);
                                CmbFormulaNo_SelectionChangeCommitted(sender, e);

                                cmbFormulaType.Text = Convert.ToString(ds.Tables[0].Rows[0]["FormulaType"]);

                                cmbFormulaType_SelectionChangeCommitted(sender, e);


                                txtMfgWoNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["MfgWo"]);
                                if (Convert.ToString(ds.Tables[0].Rows[0]["dwp"]) == null || Convert.ToString(ds.Tables[0].Rows[0]["dwp"]) == "0")
                                {
                                    rbDWPNo.Checked = true;
                                }
                                else
                                {
                                    rbDWPYes.Checked = true;
                                }
                                txtMfgWoNo_Leave(sender, e);

                                if (ds.Tables[0].Rows[0]["BPCNONBPC"].ToString() == "B")
                                    RdoBpc.Checked = true;
                                else if (ds.Tables[0].Rows[0]["BPCNONBPC"].ToString() == "N")
                                    RdoNonBpc.Checked = true;
                                else if (ds.Tables[0].Rows[0]["BPCNONBPC"].ToString() == "I")
                                    RdoIQ.Checked = true;

                                txtComment_NonBpc.Text = ds.Tables[0].Rows[0]["NonBPCcmts"].ToString();

                                if (ds.Tables[0].Rows[0]["Status"].ToString() == "H")
                                    RdoHold.Checked = true;
                                else
                                    RdoHold.Enabled = false;

                                if (ds.Tables[0].Rows[0]["Status"].ToString() == "A")
                                    RdoAccepted.Checked = true;
                                else if (ds.Tables[0].Rows[0]["Status"].ToString() == "R")
                                    RdoRejected.Checked = true;
                                else if (ds.Tables[0].Rows[0]["Status"].ToString() == "D")
                                    RdoAcceptedwithDerrogation.Checked = true;

                                txtComment_Accepted.Text = ds.Tables[0].Rows[0]["Comments"].ToString();

                                RdoRegularProduct.Enabled = RdoNewLaunch.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// key press event for Protocol no text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtProtocolNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtProtocolNo_Leave(sender, e);
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMfgWoNo_TextChanged(object sender, EventArgs e)
        {
            txtSerialNo.Text = txtMfgWoNo.Text;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsTankDetails.Tables[0].DefaultView.RowFilter = "TkDesc like  '" + searchString + "%'";
            ChkTankNo.DataSource = dsTankDetails.Tables[0];

            ChkTankNo.DisplayMember = "TkDesc";
            ChkTankNo.ValueMember = "TankNo";

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                if (lstTankDesc.Count > 0)
                {
                    for (int i = 0; i < ChkTankNo.Items.Count; i++)
                    {
                        foreach (string var in lstTankDesc)
                        {
                            RestrictAtListIteration = true;
                            if (var.Equals(Convert.ToString(ChkTankNo.GetItemText(ChkTankNo.Items[i])), StringComparison.CurrentCultureIgnoreCase))
                            {
                                ChkTankNo.SetItemCheckState(i, CheckState.Checked);
                                //ChkTankNo.SetSelected(i, true);
                            }
                        }
                    }
                    RestrictAtListIteration = false;
                }
            }

        }
        /// <summary>
        /// RestrictAtListIteration this flag is used on 
        /// txtSearch_TextChanged to restrict ChkTankNo_ItemCheck event
        /// </summary>
        bool RestrictAtListIteration = false;
        List<string> lstTankDesc = new List<string>();
        private void ChkTankNo_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!RestrictAtListIteration)
            {
                if (Convert.ToBoolean(e.NewValue))
                {
                    lstTankDesc.Add(ChkTankNo.Text);
                }
                else
                {
                    lstTankDesc.Remove(ChkTankNo.Text);
                }
            }
        }

        private void cmbManufactured_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbManufactured.SelectedIndex == 3) // for subcontractor    
                {
                    lblSupplier.Visible = true;
                    cmbSupplier.Visible = true;
                    Bind_FGSupplier();
                    chkSubContract.Checked = true;
                    chkSubContract.Enabled = false;

                }
                else
                {
                    lblSupplier.Visible = false;
                    cmbSupplier.Visible = false;
                    chkSubContract.Checked = false;
                    chkSubContract.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Record Not Found");
            }
        }

        private void Bind_FGSupplier()
        {
            try
            {
                FGSupplierMaster FGSupplierMaster_Class_obj = new FGSupplierMaster();
                DataSet dsList = FGSupplierMaster_Class_obj.Select_FGSupplierMaster();
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
                MessageBox.Show("Record Not Found");
            }
        }


        #region FillTestGrid if new Launch 30-Sep-2014 Avinash S

        public void NewLaunch_Test(string fno)
        {
            //Dispaly tests applicable to Formula from formula master 
            DataSet ds = new DataSet();
            if (fno != null)
            {
                FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(fno);
                FormulaNoMaster_Class_Obj.formulatype = cmbFormulaType.Text;
                ds = FormulaNoMaster_Class_Obj.SELECT_tblBulkPhysicochemicalTestMethodMaster_FNo_FormulaType();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                        {
                            dgTest.Rows.Add();
                            dgTest["BulkMethodNo", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["BulkMethodNo"].ToString();
                            dgTest["Test", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Test"].ToString();
                            dgTest["Min", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgTest["Max", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();

                        }
                        if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                        {
                            dgTestCon.Rows.Add();
                            dgTestCon["BulkMethodNoCon", dgTestCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["BulkMethodNo"].ToString();
                            dgTestCon["TestCon", dgTestCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Test"].ToString();
                            dgTestCon["MinCon", dgTestCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgTestCon["MaxCon", dgTestCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                        }

                        //Instrument caliberation
                        //Instruments are linked to test in Instrument master
                        //If due date for perticular instrument is ahead in 1 mothe then it will display message  
                        DataSet dsI = new DataSet();
                        InstrumentMaster_Class_Obj.testno = Convert.ToInt64(ds.Tables[0].Rows[i]["TestNo"]);
                        dsI = InstrumentMaster_Class_Obj.Select_tblInstrument_TestMaster_TestNo();
                        if (dsI.Tables[0].Rows.Count > 0)
                        {
                            for (int c = 0; c < dsI.Tables[0].Rows.Count; c++)
                            {
                                if (dsI.Tables[0].Rows[c]["DueDate"] is System.DBNull)
                                {

                                }
                                else
                                {
                                    if (Comman_Class_Obj.Select_ServerDate().AddMonths(1) > Convert.ToDateTime(dsI.Tables[0].Rows[c]["DueDate"]))
                                    {
                                        //MessageBox.Show(dsI.Tables[0].Rows[c]["Instrument"].ToString(), "Caliber Instrument", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        NotifyWindow nw = new NotifyWindow("Caliber Instrument", dsI.Tables[0].Rows[c]["Instrument"].ToString());
                                        nw.Notify();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        private void RdoRejected_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoRejected.Checked == true)
            {
                txtComment_Accepted.Enabled = true;
                //txtComment_Accepted.Focus();
                txtComment_Accepted.BackColor = Color.White;
            }
        }

        private void RdoAccepted_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoAccepted.Checked == true)
            {
                txtComment_Accepted.Enabled = false;
                txtComment_Accepted.Text = "";
                txtComment_Accepted.BackColor = Color.FromArgb(242, 246, 252);
            }
        }

        private void OOS_Begin(string BulkMethodNo, string testname)
        {

            FrmOOSDetails.Detail detail_Obj = new FrmOOSDetails.Detail();

            detail_Obj.D_formname = "Bulk";
            detail_Obj.D_productname = txtDescription.Text.Trim();
            detail_Obj.D_mfgwo = txtMfgWoNo.Text.Trim();
            detail_Obj.D_bulkmethodno = Convert.ToInt64(BulkMethodNo);
            detail_Obj.D_testname = testname;
            detail_Obj.D_fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
            if (txtMfgWoNo.Text.StartsWith("WO") && txtMfgWoNo.Text.Length == 12)
            {
                detail_Obj.D_batchnumber = "B82" + txtMfgWoNo.Text.Substring(txtMfgWoNo.Text.Length - 5);
            }

            FrmOOSDetails frmOOS = new FrmOOSDetails(detail_Obj);
            frmOOS.ShowDialog();

        }
    }
}