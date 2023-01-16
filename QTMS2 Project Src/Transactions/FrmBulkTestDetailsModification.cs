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
    public partial class FrmBulkTestDetailsModification : Form
    {
        public FrmBulkTestDetailsModification()
        {
            InitializeComponent();
        }
        #region Varibles

        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Obj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();

        //FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        VesselMaster_Class VesselMaster_Class_Obj = new VesselMaster_Class();
        TankMaster_Class TankMaster_Class_Obj = new TankMaster_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        DataSet dsTankDetails = new DataSet();
        #endregion

        private static FrmBulkTestDetailsModification frmBulkTestDetailsModification_Obj = null;
        public static FrmBulkTestDetailsModification GetInstance()
        {
            if (frmBulkTestDetailsModification_Obj == null)
            {
                frmBulkTestDetailsModification_Obj = new FrmBulkTestDetailsModification();
            }
            return frmBulkTestDetailsModification_Obj;
        }

        private void FrmBulkTestDetailsModification_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //CmbFormulaNo.DroppedDown = false;
            cmbSupplier.DroppedDown = false;

            Painter.Paint(this);

            Bind_Details();
            Bind_Vessel();
            Bind_Tank();
            Bind_InspectedBy();
            Bind_Manufacturer();
            Bind_FGSupplier();
            Bind_VerifiedBy();
            // Set Current Date
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateOfValidation.Value = Comman_Class_Obj.Select_ServerDate();
            DtpStartedOn.Value = DtpInspDate.Value;
            DtpCompletedOn.Value = DtpInspDate.Value;

            cmbDetails.Focus();
            txtFormulaType.Text = "";
            cmbFA.Text = "N/A";
            BulktestDetailstransaction_Class_Obj.fno = 0;

            RdoRegularProduct.Enabled = RdoNewLaunch.Enabled = false;
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

        public void Bind_Details()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = BulktestDetailstransaction_Class_Obj.Select_ModificationBulkTestDetails();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            dr["BulkNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.ValueMember = "BulkNo";
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
        private void BtnReset_Click(object sender, EventArgs e)
        {
            cmbDetails.Text = "--Select--";
            reset();
            cmbDetails.Focus();
            cmbManufactured_SelectionChangeCommitted(sender, e);
        }

        public void reset()
        {
            txtSearch.Text = "";
            rbDWPNo.Checked = true;
            txtDescription.Text = "";
            txtTechnicalFamily.Text = "";
            txtFormulaType.Text = "";
            CmbVesselNo.Text = "--Select--";
            txtSerialNo.Text = "";
            txtBatchSize.Text = "";
            txtComment_Accepted.Text = "";
            txtComment_NonBpc.Text = "";
            txtNoofBatches.Text = "";
            cmbManufactured.SelectedIndex = 0;

            //txtSupplier.Text = "";
            cmbFA.Text = "N/A";
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateOfValidation.Value = Comman_Class_Obj.Select_ServerDate();
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

            dgTest.Rows.Clear();
            dgTestCon.Rows.Clear();

            RdoRegularProduct.Checked = true;
            RdoBpc.Checked = true;
            RdoAccepted.Checked = true;
            chkSubContract.Checked = false;
            cmbInspectedBy.Text = "--Select--";
            cmbVerifiedBy.Text = "--Select--";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                reset();

                if (cmbDetails.SelectedValue is DBNull)
                {
                    labelNorms.Visible = false;
                    txtNorms.Visible = false;
                    txtNorms.Text = "";
                }
                else
                {
                    DataSet ds = new DataSet();
                    BulktestDetailstransaction_Class_Obj.bulkno = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                    ds = BulktestDetailstransaction_Class_Obj.Select_ModificationBulkTestDetails_Details();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        BulktestDetailstransaction_Class_Obj.fmid = Convert.ToInt64(ds.Tables[0].Rows[0]["FMID"]);

                        txtFormulaType.Text = ds.Tables[0].Rows[0]["FormulaType"].ToString();
                        txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);
                        txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);
                        txtNoofBatches.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoBatches"]);
                        txtFilCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["filcode"]);
                        if (Convert.ToString(ds.Tables[0].Rows[0]["dwp"]) == "" || Convert.ToString(ds.Tables[0].Rows[0]["dwp"]) == "0")
                        {
                            rbDWPNo.Checked = true;
                        }
                        else
                        {
                            rbDWPYes.Checked = true;
                        }
                        if (ds.Tables[0].Rows[0]["Supplier"] is DBNull)
                        {

                        }
                        else
                        {
                            if (ds.Tables[0].Rows[0]["Supplier"].ToString().ToUpper().Contains("UP"))
                            {
                                cmbManufactured.Text = ds.Tables[0].Rows[0]["Supplier"].ToString();
                            }
                            else
                            {
                                cmbManufactured.Text = "SubContractor";
                                cmbSupplier.Text = ds.Tables[0].Rows[0]["FGSupplierName"].ToString();

                            }
                        }
                        cmbManufactured_SelectionChangeCommitted(sender, e);
                        CmbVesselNo.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["VesselNo"]);
                        txtSerialNo.Text = ds.Tables[0].Rows[0]["SerialNo"].ToString();
                        txtBatchSize.Text = ds.Tables[0].Rows[0]["BatchSize"].ToString();
                        DtpInspDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspDate"]);
                        if (Convert.ToInt16(ds.Tables[0].Rows[0]["Microbiologytest"]) == 1)
                        {
                            txtNorms.Visible = true;
                            txtNorms.Text = Convert.ToString(ds.Tables[0].Rows[0]["MicroNorms"]);
                            labelNorms.Visible = true;
                        }
                        else
                        {
                            txtNorms.Visible = false;
                            txtNorms.Text = "";
                        }
                        if (ds.Tables[0].Rows[0]["StartedOn"] is DBNull)
                        {
                            DtpStartedOn.Value = Comman_Class_Obj.Select_ServerDate();
                        }
                        else
                        {
                            DtpStartedOn.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartedOn"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["CompletedOn"] is DBNull)
                        {
                            DtpCompletedOn.Value = Comman_Class_Obj.Select_ServerDate();
                        }
                        else
                        {
                            DtpCompletedOn.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CompletedOn"].ToString());
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

                        if (ds.Tables[0].Rows[0]["ExtLabReportNo"] is DBNull)
                        {
                            txtExtLabReportNo.Text = "";
                        }
                        else
                        {
                            txtExtLabReportNo.Text = ds.Tables[0].Rows[0]["ExtLabReportNo"].ToString();
                        }


                        BulktestDetailstransaction_Class_Obj.fno = Convert.ToInt64(ds.Tables[0].Rows[0]["FNo"].ToString());
                        BulktestDetailstransaction_Class_Obj.mfgwo = ds.Tables[0].Rows[0]["MfgWo"].ToString();

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

                        if (ds.Tables[0].Rows[0]["FlagRL"].ToString() == "R")
                        {
                            RdoRegularProduct.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["FlagRL"].ToString() == "L")
                        {
                            RdoNewLaunch.Checked = true;
                        }
                        DtpDateOfValidation.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ValidDate"].ToString());

                        if (ds.Tables[0].Rows[0]["FormulationApproved"].ToString() == "N")
                        {
                            cmbFA.Text = "N/A";
                        }
                        else if (ds.Tables[0].Rows[0]["FormulationApproved"].ToString() == "Y")
                        {
                            cmbFA.Text = "Yes";
                        }
                        else if (ds.Tables[0].Rows[0]["FormulationApproved"].ToString() == "R")
                        {
                            cmbFA.Text = "Reject";
                        }
                        else if (ds.Tables[0].Rows[0]["FormulationApproved"].ToString() == "P")
                        {
                            cmbFA.Text = "Pending";
                        }

                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["SubContract"]) == 1)
                        {
                            chkSubContract.Checked = true;
                        }
                        else
                        {
                            chkSubContract.Checked = false;
                        }

                        if (ds.Tables[0].Rows[0]["BPCNONBPC"].ToString() == "B")
                        {
                            RdoBpc.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["BPCNONBPC"].ToString() == "N")
                        {
                            RdoNonBpc.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["BPCNONBPC"].ToString() == "I")
                        {
                            RdoIQ.Checked = true;
                        }
                        txtComment_NonBpc.Text = ds.Tables[0].Rows[0]["NonBPCcmts"].ToString();

                        if (ds.Tables[0].Rows[0]["Status"].ToString() == "A")
                        {
                            RdoAccepted.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "R")
                        {
                            RdoRejected.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "D")
                        {
                            RdoAcceptedwithDerrogation.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "H")
                        {
                            RdoHold.Checked = true;
                        }
                        txtComment_Accepted.Text = ds.Tables[0].Rows[0]["Comments"].ToString();

                        cmbInspectedBy.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["InspectedBy"]);
                        if (ds.Tables[0].Rows[0]["VerifiedBy"].ToString() != "")
                            cmbVerifiedBy.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["VerifiedBy"]);

                        #region Save norms from transaction
                        DataSet dsTest = new DataSet();
                        //FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(ds.Tables[0].Rows[0]["FNo"].ToString());
                        //FormulaNoMaster_Class_Obj.formulatype = ds.Tables[0].Rows[0]["FormulaType"].ToString();                        
                        dsTest = BulktestDetailstransaction_Class_Obj.SELECT_tblBulkPhysicochemicalTestMethodDetails_Norms_FMID();
                        if (dsTest.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsTest.Tables[0].Rows.Count; i++)
                            {
                                if (dsTest.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                                {
                                    dgTest.Rows.Add();
                                    dgTest["BulkMethodNo", dgTest.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["BulkMethodNo"].ToString();
                                    dgTest["Test", dgTest.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["Test"].ToString();
                                    dgTest["Min", dgTest.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgTest["Max", dgTest.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMax"].ToString();
                                    dgTest["InitialValue", dgTest.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["InitialValue"].ToString();
                                    dgTest["FinalValue", dgTest.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["FinalValue"].ToString();
                                    dgTest["Reading", dgTest.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsReading"].ToString();
                                }
                                if (dsTest.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                                {
                                    dgTestCon.Rows.Add();
                                    dgTestCon["BulkMethodNoCon", dgTestCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["BulkMethodNo"].ToString();
                                    dgTestCon["TestCon", dgTestCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["Test"].ToString();
                                    dgTestCon["MinCon", dgTestCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgTestCon["MaxCon", dgTestCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMax"].ToString();
                                    dgTestCon["InitialValueCon", dgTestCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["InitialValue"].ToString();
                                    dgTestCon["FinalValueCon", dgTestCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["FinalValue"].ToString();
                                    dgTestCon["ReadingCon", dgTestCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsReading"].ToString();
                                }
                            }
                        }
                        #endregion



                        #region Old Code
                        ////-----display tests in grid-------------

                        //DataSet dsTest = new DataSet();
                        ////FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(ds.Tables[0].Rows[0]["FNo"].ToString());
                        ////FormulaNoMaster_Class_Obj.formulatype = ds.Tables[0].Rows[0]["FormulaType"].ToString();                        
                        //dsTest = BulktestDetailstransaction_Class_Obj.SELECT_tblBulkPhysicochemicalTestMethodDetails_FMID();
                        //if (dsTest.Tables[0].Rows.Count > 0)
                        //{
                        //    for (int i = 0; i < dsTest.Tables[0].Rows.Count; i++)
                        //    {
                        //        if (dsTest.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                        //        {
                        //            dgTest.Rows.Add();
                        //            dgTest["BulkMethodNo", dgTest.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["BulkMethodNo"].ToString();
                        //            dgTest["Test", dgTest.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["Test"].ToString();
                        //            dgTest["Min", dgTest.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMin"].ToString();
                        //            dgTest["Max", dgTest.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMax"].ToString();

                        //        }
                        //        if (dsTest.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                        //        {
                        //            dgTestCon.Rows.Add();
                        //            dgTestCon["BulkMethodNoCon", dgTestCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["BulkMethodNo"].ToString();
                        //            dgTestCon["TestCon", dgTestCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["Test"].ToString();
                        //            dgTestCon["MinCon", dgTestCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMin"].ToString();
                        //            dgTestCon["MaxCon", dgTestCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMax"].ToString();
                        //        }
                        //    }
                        //}


                        ////IF details already filled then display

                        //DataSet ds1;
                        //for (int i = 0; i < dgTest.Rows.Count; i++)
                        //{
                        //    ds1 = new DataSet();
                        //    //FNo
                        //    //MfgWo
                        //    BulktestDetailstransaction_Class_Obj.bulkmethodno = Convert.ToInt64(dgTest["BulkMethodNo", i].Value);
                        //    ds1 = BulktestDetailstransaction_Class_Obj.Select_tblBulkPhysicochemicalTestMethodDetails();
                        //    if (ds1.Tables[0].Rows.Count > 0)
                        //    {
                        //        dgTest["InitialValue", i].Value = ds1.Tables[0].Rows[0]["InitialValue"].ToString();
                        //        dgTest["FinalValue", i].Value = ds1.Tables[0].Rows[0]["FinalValue"].ToString();
                        //        dgTest["Reading", i].Value = ds1.Tables[0].Rows[0]["NormsReading"].ToString();
                        //    }
                        //}
                        //for (int i = 0; i < dgTestCon.Rows.Count; i++)
                        //{
                        //    ds1 = new DataSet();
                        //    //FNo
                        //    //MfgWo
                        //    BulktestDetailstransaction_Class_Obj.bulkmethodno = Convert.ToInt64(dgTestCon["BulkMethodNoCon", i].Value);
                        //    ds1 = BulktestDetailstransaction_Class_Obj.Select_tblBulkPhysicochemicalTestMethodDetails();
                        //    if (ds.Tables[0].Rows.Count > 0)
                        //    {
                        //        dgTestCon["InitialValueCon", i].Value = ds1.Tables[0].Rows[0]["InitialValue"].ToString();
                        //        dgTestCon["FinalValueCon", i].Value = ds1.Tables[0].Rows[0]["FinalValue"].ToString();
                        //        dgTestCon["ReadingCon", i].Value = ds1.Tables[0].Rows[0]["NormsReading"].ToString();
                        //    }
                        //}
                        #endregion
                    }
                    else
                    {
                        labelNorms.Visible = false;
                        txtNorms.Visible = false;
                        txtNorms.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details ...!", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDetails.Focus();
                    return;
                }

                if (BulktestDetailstransaction_Class_Obj.bulkno == 0)
                {
                    MessageBox.Show("Select Details ...!", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDetails.Focus();
                    return;
                }

                if (CmbVesselNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Vessel No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbVesselNo.Focus();
                    return;
                }

                if (RdoAccepted.Checked == false && RdoRejected.Checked == false && RdoAcceptedwithDerrogation.Checked == false && RdoHold.Checked == false)
                {
                    MessageBox.Show("Please Select Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
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
                //if (txtActuallyDensity.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter Density", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtActuallyDensity.Focus();
                //    return;
                //}
                if (txtBatchSize.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Batch Size", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBatchSize.Focus();
                    return;
                }
                if (cmbVerifiedBy.SelectedValue == null || cmbVerifiedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Verified By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVerifiedBy.Focus();
                    return;
                }
                if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbInspectedBy.Focus();
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
                        MessageBox.Show("Select Tank No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ChkTankNo.Focus();
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
                if (RdoHold.Checked == true)
                {
                    if (MessageBox.Show("HOLD ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                //if (RdoHold.Checked != true && FrmMain.UserType == 'N')
                //{
                //    MessageBox.Show("Sorry..\n\nYou can only HOLD the record", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}

                if (chkSubContract.Checked == true)
                {
                    BulktestDetailstransaction_Class_Obj.subcontract = 1;
                }
                else
                {
                    BulktestDetailstransaction_Class_Obj.subcontract = 0;
                }

                BulktestDetailstransaction_Class_Obj.formulatype = txtFormulaType.Text;
                BulktestDetailstransaction_Class_Obj.Inspdate = DtpInspDate.Value.ToShortDateString();
                BulktestDetailstransaction_Class_Obj.vesselno = Convert.ToInt32(CmbVesselNo.SelectedValue);
                BulktestDetailstransaction_Class_Obj.supplier = cmbManufactured.Text.Trim();
                BulktestDetailstransaction_Class_Obj.startedon = DtpStartedOn.Value.ToShortDateString();
                BulktestDetailstransaction_Class_Obj.completedon = DtpCompletedOn.Value.ToShortDateString();
                BulktestDetailstransaction_Class_Obj.extlabreportno = txtExtLabReportNo.Text.Trim();
                BulktestDetailstransaction_Class_Obj.micronorms = txtNorms.Text.Trim();// Show transaction screen saved micro norms
                if (cmbSupplier.SelectedIndex > 0)
                {
                    BulktestDetailstransaction_Class_Obj.FGSupplierId = Convert.ToInt64(cmbSupplier.SelectedValue);
                }

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
                    BulktestDetailstransaction_Class_Obj.comments = "";
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

                    BulktestDetailstransaction_Class_Obj.Update_tblBulkTestDetailstransaction();
                }
                else
                {
                    BulktestDetailstransaction_Class_Obj.bulkno = BulktestDetailstransaction_Class_Obj.Insert_tblBulkTestDetailstransaction();
                }

                if (BulktestDetailstransaction_Class_Obj.fmid != 0)
                {

                    BulktestDetailstransaction_Class_Obj.Update_tblTransFM();
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
                        BulktestDetailstransaction_Class_Obj.INSERT_tblBulkPhysicochemicalTestMethodDetails();
                    }

                    MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                    cmbDetails.Focus();
                    lstTankDesc.Clear();
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
                if ((cmbDetails.Text == "--Select--" || cmbDetails.SelectedValue == null || cmbDetails.SelectedValue.ToString() == ""))
                {
                    MessageBox.Show("Please Select Details ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                    return;
                }

                if (MessageBox.Show("Are You sure want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {

                    bool b = BulktestDetailstransaction_Class_Obj.Delete_tblTransFM();
                    if (b == true)
                    {
                        MessageBox.Show("Record deleted Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bind_Details();
                        BtnReset_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry you Can't Delete this Record", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtComment_NonBpc_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtComment_NonBpc.Text = textInfo.ToTitleCase(txtComment_NonBpc.Text);
        }

        private void txtComment_Accepted_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtComment_Accepted.Text = textInfo.ToTitleCase(txtComment_Accepted.Text);
        }


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

        private void RdoNonBpc_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoNonBpc.Checked == true)
            {
                txtComment_NonBpc.Enabled = true;
                txtComment_NonBpc.BackColor = Color.White;
            }
            else if (RdoNonBpc.Checked == false)
            {
                txtComment_NonBpc.Enabled = false;
                txtComment_NonBpc.Text = "";
                txtComment_NonBpc.BackColor = Color.FromArgb(242, 246, 252);
            }
        }

        private void RdoAcceptedwithDerrogation_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoAcceptedwithDerrogation.Checked == true)
            {
                txtComment_Accepted.Enabled = true;
                txtComment_Accepted.BackColor = Color.White;
            }
            //else if (RdoAcceptedwithDerrogation.Checked == false)
            //{
            //    txtComment_Accepted.Enabled = false;
            //    txtComment_Accepted.Text = "";
            //}
        }

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

        private void RdoRegularProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoRegularProduct.Checked == true)
            {
                cmbFA.Text = "N/A";
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
                        if (GlobalVariables.City == "BADDI")
                            OOS_Begin(dgTest["BulkMethodNo", dgTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgTest["Test", dgTest.CurrentCell.RowIndex].Value.ToString().Trim());
                        return;
                    }

                    if (dgTest["Max", dgTest.CurrentCell.RowIndex].Value != null && dgTest["Max", dgTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgTest["Max", dgTest.CurrentCell.RowIndex].Value))
                        {
                            dgTest.CurrentCell.Style.BackColor = Color.Red;
                            if (GlobalVariables.City == "BADDI")
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
                            if (GlobalVariables.City == "BADDI")
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
                        if (GlobalVariables.City == "BADDI")
                            OOS_Begin(dgTestCon["BulkMethodNoCon", dgTestCon.CurrentCell.RowIndex].Value.ToString().Trim(), dgTestCon["TestCon", dgTestCon.CurrentCell.RowIndex].Value.ToString().Trim());
                        return;
                    }

                    if (dgTestCon["MaxCon", dgTestCon.CurrentCell.RowIndex].Value != null && dgTestCon["MaxCon", dgTestCon.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgTestCon.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgTestCon["MaxCon", dgTestCon.CurrentCell.RowIndex].Value))
                        {
                            dgTestCon.CurrentCell.Style.BackColor = Color.Red;
                            if (GlobalVariables.City == "BADDI")
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
                            if (GlobalVariables.City == "BADDI")
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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbManufactured_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbManufactured.SelectedIndex == 3) // for subcontractor    
                {
                    lblSupplier.Visible = true;
                    cmbSupplier.Visible = true;
                    // Bind_FGSupplier();
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
            detail_Obj.D_mfgwo = BulktestDetailstransaction_Class_Obj.mfgwo;
            detail_Obj.D_bulkmethodno = Convert.ToInt64(BulkMethodNo);
            detail_Obj.D_testname = testname;
            detail_Obj.D_fno = BulktestDetailstransaction_Class_Obj.fno;
            if (BulktestDetailstransaction_Class_Obj.mfgwo.StartsWith("WO") && BulktestDetailstransaction_Class_Obj.mfgwo.Length == 12)
            {
                detail_Obj.D_batchnumber = "B82" + BulktestDetailstransaction_Class_Obj.mfgwo.Substring(BulktestDetailstransaction_Class_Obj.mfgwo.Length - 5);
            }

            FrmOOSDetails frmOOS = new FrmOOSDetails(detail_Obj);
            frmOOS.ShowDialog();

        }



    }
}