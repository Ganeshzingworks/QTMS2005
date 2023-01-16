using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

using QTMS.Reports;

namespace QTMS.Transactions
{
    /// <summary>
    /// By Vijay Chavan 05-02-2021 
    /// </summary>

    public partial class FrmStabilityTest : Form
    {
        public FrmStabilityTest()
        {
            InitializeComponent();
        }

        #region Varibles
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        SatbilityTest_Class SatbilityTest_Class_Obj = new SatbilityTest_Class();

        //BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Obj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
        //BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        //VesselMaster_Class VesselMaster_Class_Obj = new VesselMaster_Class();
        //TankMaster_Class TankMaster_Class_Obj = new TankMaster_Class();
        //InstrumentMaster_Class InstrumentMaster_Class_Obj = new InstrumentMaster_Class();
        //BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        //DataSet dsTankDetails = new DataSet();
        //DateTime Today;
        //BusinessFacade.Transactions.OOS OOS_Obj = new BusinessFacade.Transactions.OOS();

        bool EditGridViewWeek1 = false;
        bool EditGridViewWeek2 = false;
        bool EditGridViewMonth1 = false;
        bool EditGridViewMonth2 = false;

        #endregion


        private static FrmStabilityTest frmStabilityTest_Obj = null;
        public static FrmStabilityTest GetInstance()
        {
            if (frmStabilityTest_Obj == null)
            {
                frmStabilityTest_Obj = new FrmStabilityTest();
            }
            return frmStabilityTest_Obj;
        }

        /// <summary>
        /// Form load method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStabilityTest_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            // lbCurrentDate.Text = Comman_Class_Obj.Select_ServerDate().ToString("dd-MM-yyyy");
            DtpCurrentDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpLunchDate.Value = Comman_Class_Obj.Select_ServerDate();
            Bind_FormulaNo();

            BtnWeek1.Enabled = false;
            BtnWeek2.Enabled = false;
            BtnMonth1.Enabled = false;
            BtnMonth2.Enabled = false;
            this.ReportViewer.RefreshReport();
        }

        public void Bind_FormulaNo()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = SatbilityTest_Class_Obj.SELECT_StabilityReminder_FormulaNo_Active();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            // dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbFormulaNo.DataSource = ds.Tables[0];
                CmbFormulaNo.ValueMember = "FNo";
                CmbFormulaNo.DisplayMember = "FormulaNo";
            }

        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dgTest.Rows.Clear();
                dgTestCon.Rows.Clear();
                dgAmbientIdTest.Rows.Clear();
                dgAmbientConTest.Rows.Clear();
                dg45DegreeIdTest.Rows.Clear();
                dg45DegreeConTest.Rows.Clear();
                dg4DegreeIdTest.Rows.Clear();
                dg4DegreeConTest.Rows.Clear();

                dgAmbientIdTest.ReadOnly = false;
                dgAmbientConTest.ReadOnly = false;
                dg45DegreeIdTest.ReadOnly = false;
                dg45DegreeConTest.ReadOnly = false;
                dg4DegreeIdTest.ReadOnly = false;
                dg4DegreeConTest.ReadOnly = false;
                BtnSave.Enabled = true;

                EditGridViewWeek1 = false;
                EditGridViewWeek2 = false;
                EditGridViewMonth1 = false;
                EditGridViewMonth2 = false;

                if (CmbFormulaNo.SelectedValue.ToString() != null && CmbFormulaNo.SelectedValue.ToString() != "")
                {
                    DataSet ds = new DataSet();
                    SatbilityTest_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                    ds = SatbilityTest_Class_Obj.SELECT_StabilityReminder_Active();

                    if (ds.Tables[0].Rows[0]["CreatedOn"] is System.DBNull)
                    {  
                        DtpLunchDate.Value = Comman_Class_Obj.Select_ServerDate();  
                    }
                    else
                    {
                        DtpLunchDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"]);                   
                    }
                  //  DtpLunchDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedOn"].ToString());
                    txtDescription.Text = ds.Tables[0].Rows[0]["BulkDesc"].ToString();
                    lbBatch.Text = ds.Tables[0].Rows[0]["NoBatches"].ToString();
                    lbTest.Text = ds.Tables[0].Rows[0]["PendingFor"].ToString();

                    DataSet dsTest = new DataSet();
                    // SatbilityTest_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                    SatbilityTest_Class_Obj.fmid = Convert.ToInt64(ds.Tables[0].Rows[0]["FMID"].ToString());
                    dsTest = SatbilityTest_Class_Obj.SELECT_tblBulkPhysicochemicalTestMethodDetails_ForSatbilityTest_FMID();
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

                    if (ds.Tables[0].Rows[0]["PendingFor"].ToString() == "Week 1")
                    {
                        EditGridViewWeek1 = true;
                        BtnWeek1.Enabled = true;
                        BtnWeek2.Enabled = false;
                        BtnMonth1.Enabled = false;
                        BtnMonth2.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["PendingFor"].ToString() == "Week 2")
                    {
                        EditGridViewWeek2 = true;
                        BtnWeek1.Enabled = true;
                        BtnWeek2.Enabled = true;
                        BtnMonth1.Enabled = false;
                        BtnMonth2.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["PendingFor"].ToString() == "Month 1")
                    {
                        EditGridViewMonth1 = true;
                        BtnWeek1.Enabled = true;
                        BtnWeek2.Enabled = true;
                        BtnMonth1.Enabled = true;
                        BtnMonth2.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["PendingFor"].ToString() == "Month 2")
                    {
                        EditGridViewMonth2 = true;
                        BtnWeek1.Enabled = true;
                        BtnWeek2.Enabled = true;
                        BtnMonth1.Enabled = true;
                        BtnMonth2.Enabled = true;
                    }


                    if (ds.Tables[0].Rows[0]["Completed"].ToString() == "0")
                    {
                        //BtnSave.Enabled = false;
                        if (ds.Tables[0].Rows[0]["PendingFor"].ToString() == "Week 1")
                        {
                            BtnWeek1.Enabled = false;
                            BtnWeek2.Enabled = false;
                            BtnMonth1.Enabled = false;
                            BtnMonth2.Enabled = false;
                        }
                        if (ds.Tables[0].Rows[0]["PendingFor"].ToString() == "Week 2")
                        {
                            BtnWeek1.Enabled = true;
                            BtnWeek2.Enabled = false;
                            BtnMonth1.Enabled = false;
                            BtnMonth2.Enabled = false;
                        }
                        if (ds.Tables[0].Rows[0]["PendingFor"].ToString() == "Month 1")
                        {
                            BtnWeek1.Enabled = true;
                            BtnWeek2.Enabled = true;
                            BtnMonth1.Enabled = false;
                            BtnMonth2.Enabled = false;
                        }
                        if (ds.Tables[0].Rows[0]["PendingFor"].ToString() == "Month 2")
                        {
                            BtnWeek1.Enabled = true;
                            BtnWeek2.Enabled = true;
                            BtnMonth1.Enabled = true;
                            BtnMonth2.Enabled = false;
                        }
                    }
                    //else
                    //{
                    //    BtnSave.Enabled = false;
                    //    BtnModify.Enabled = true;
                    //}


                    if (ds.Tables[0].Rows[0]["Completed"].ToString() == "1")
                    {
                        SatbilityTest_Class_Obj.completedday = ds.Tables[0].Rows[0]["PendingFor"].ToString();
                        DataSet dsStability = new DataSet();
                        dsStability = SatbilityTest_Class_Obj.STP_SELECT_StabilityTest_History();

                        if (dsStability.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < dsStability.Tables[0].Rows.Count; i++)
                            {
                                // Test For Ambient ReadingType
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "1")
                                {
                                    dgAmbientIdTest.Rows.Add();
                                    dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dgAmbientIdTest["AmbientMin", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgAmbientIdTest["AmbientMax", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                                    dgAmbientIdTest["AmbientReading", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                                    dgAmbientIdTest["AmbientRemark", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Remark"];


                                }
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "1")
                                {
                                    dgAmbientConTest.Rows.Add();
                                    dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dgAmbientConTest["AmbientTestCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dgAmbientConTest["AmbientMinCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgAmbientConTest["AmbientMaxCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                                    dgAmbientConTest["AmbientReadingCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                                    dgAmbientConTest["AmbientRemarkCon", dgAmbientConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                                }
                                //Test For 45 Degree 
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "2")
                                {
                                    dg45DegreeIdTest.Rows.Add();
                                    dg45DegreeIdTest["FGPhyMethodNo45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dg45DegreeIdTest["IdentificationTest45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dg45DegreeIdTest["Min45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dg45DegreeIdTest["Max45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                                    dg45DegreeIdTest["Reading45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                                    dg45DegreeIdTest["Remark45", dg45DegreeIdTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                                }
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "2")
                                {
                                    dg45DegreeConTest.Rows.Add();
                                    dg45DegreeConTest["FGPhyMethodNo45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dg45DegreeConTest["Test45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dg45DegreeConTest["Min45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dg45DegreeConTest["Max45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                                    dg45DegreeConTest["Reading45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                                    dg45DegreeConTest["Remark45Con", dg45DegreeConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                                }
                                //Test For 4 Degree 
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "3")
                                {
                                    dg4DegreeIdTest.Rows.Add();
                                    dg4DegreeIdTest["FGPhyMethodNo4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dg4DegreeIdTest["IdentificationTest4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dg4DegreeIdTest["Min4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dg4DegreeIdTest["Max4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                                    dg4DegreeIdTest["Reading4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                                    dg4DegreeIdTest["Remark4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                                }
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "3")
                                {
                                    dg4DegreeConTest.Rows.Add();
                                    dg4DegreeConTest["FGPhyMethodNo4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dg4DegreeConTest["Test4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dg4DegreeConTest["Min4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dg4DegreeConTest["Max4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                                    dg4DegreeConTest["Reading4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                                    dg4DegreeConTest["Remark4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                                }
                            }
                        }

                    }
                    else
                    {
                        DataSet dsStability = new DataSet();
                        // FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                        dsStability = SatbilityTest_Class_Obj.SELECT_tblFGPhysicochemicalTestMethodMaster_FNo_StabilityTest();
                        if (dsStability.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < dsStability.Tables[0].Rows.Count; i++)
                            {
                                // Test For Ambient
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                                {
                                    dgAmbientIdTest.Rows.Add();
                                    dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dgAmbientIdTest["AmbientMin", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgAmbientIdTest["AmbientMax", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();

                                }
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                                {
                                    dgAmbientConTest.Rows.Add();
                                    dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dgAmbientConTest["AmbientTestCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dgAmbientConTest["AmbientMinCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgAmbientConTest["AmbientMaxCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                                }
                                //Test For 45 Degree 
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                                {
                                    dg45DegreeIdTest.Rows.Add();
                                    dg45DegreeIdTest["FGPhyMethodNo45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dg45DegreeIdTest["IdentificationTest45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dg45DegreeIdTest["Min45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dg45DegreeIdTest["Max45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();

                                }
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                                {
                                    dg45DegreeConTest.Rows.Add();
                                    dg45DegreeConTest["FGPhyMethodNo45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dg45DegreeConTest["Test45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dg45DegreeConTest["Min45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dg45DegreeConTest["Max45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                                }
                                //Test For 4 Degree 
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                                {
                                    dg4DegreeIdTest.Rows.Add();
                                    dg4DegreeIdTest["FGPhyMethodNo4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dg4DegreeIdTest["IdentificationTest4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dg4DegreeIdTest["Min4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dg4DegreeIdTest["Max4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();

                                }
                                if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                                {
                                    dg4DegreeConTest.Rows.Add();
                                    dg4DegreeConTest["FGPhyMethodNo4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                                    dg4DegreeConTest["Test4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                                    dg4DegreeConTest["Min4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dg4DegreeConTest["Max4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                                }
                            }
                        }

                    }

                 // Reading cell becomes red if reading value is out of norms
                    CheckReadingValue();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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

                for (int i = 0; i < dgAmbientIdTest.Rows.Count; i++)
                {
                    if (dgAmbientIdTest["AmbientReading", i].Value == null || dgAmbientIdTest["AmbientReading", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the Ambient Identification Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgAmbientIdTest.Focus();
                        return;
                    }

                    string cellValue = dgAmbientIdTest["AmbientReading", i].Value.ToString();
                    decimal cellNumericValue;
                    if (!decimal.TryParse(cellValue, out cellNumericValue))
                    {
                        MessageBox.Show("Please Enter Number of Ambient Identification Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgAmbientIdTest.Focus();
                        return;
                    }
                }

                for (int i = 0; i < dgAmbientConTest.Rows.Count; i++)
                {
                    if (dgAmbientConTest["AmbientReadingCon", i].Value == null || dgAmbientConTest["AmbientReadingCon", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the Ambient Control Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgAmbientConTest.Focus();
                        return;
                    }

                    string cellValue = dgAmbientConTest["AmbientReadingCon", i].Value.ToString();
                    decimal cellNumericValue;
                    if (!decimal.TryParse(cellValue, out cellNumericValue))
                    {
                        MessageBox.Show("Please Enter Number of Ambient Control Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgAmbientConTest.Focus();
                        return;
                    }
                }

                for (int i = 0; i < dg45DegreeIdTest.Rows.Count; i++)
                {
                    if (dg45DegreeIdTest["Reading45", i].Value == null || dg45DegreeIdTest["Reading45", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the 45 Degree Identification Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dg45DegreeIdTest.Focus();
                        return;
                    }

                    string cellValue = dg45DegreeIdTest["Reading45", i].Value.ToString();
                    decimal cellNumericValue;
                    if (!decimal.TryParse(cellValue, out cellNumericValue))
                    {
                        MessageBox.Show("Please Enter Number of 45 Degree Identification Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dg45DegreeIdTest.Focus();
                        return;
                    }

                }
                for (int i = 0; i < dg45DegreeConTest.Rows.Count; i++)
                {
                    if (dg45DegreeConTest["Reading45Con", i].Value == null || dg45DegreeConTest["Reading45Con", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the 45 Degree Control Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dg45DegreeConTest.Focus();
                        return;
                    }

                    string cellValue = dg45DegreeConTest["Reading45Con", i].Value.ToString();
                    decimal cellNumericValue;
                    if (!decimal.TryParse(cellValue, out cellNumericValue))
                    {
                        MessageBox.Show("Please Enter Number of 45 Degree Control Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dg45DegreeConTest.Focus();
                        return;
                    }
                }

                for (int i = 0; i < dg4DegreeIdTest.Rows.Count; i++)
                {
                    if (dg4DegreeIdTest["Reading4Degree", i].Value == null || dg4DegreeIdTest["Reading4Degree", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the 4 Degree Identification Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dg4DegreeIdTest.Focus();
                        return;
                    }

                    string cellValue = dg4DegreeIdTest["Reading4Degree", i].Value.ToString();
                    decimal cellNumericValue;
                    if (!decimal.TryParse(cellValue, out cellNumericValue))
                    {
                        MessageBox.Show("Please Enter Number of 4 Degree Identification Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dg4DegreeIdTest.Focus();
                        return;
                    }
                }
                for (int i = 0; i < dg4DegreeConTest.Rows.Count; i++)
                {
                    if (dg4DegreeConTest["Reading4DegreeCon", i].Value == null || dg4DegreeConTest["Reading4DegreeCon", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the 4 Degree Control Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dg4DegreeConTest.Focus();
                        return;
                    }

                    string cellValue = dg4DegreeConTest["Reading4DegreeCon", i].Value.ToString();
                    decimal cellNumericValue;
                    if (!decimal.TryParse(cellValue, out cellNumericValue))
                    {
                        MessageBox.Show("Please Enter Number of 4 Degree Control Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dg4DegreeConTest.Focus();
                        return;
                    }
                }

                DataSet dsFno = new DataSet();
                SatbilityTest_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                dsFno = SatbilityTest_Class_Obj.SELECT_StabilityReminder_Active();
                SatbilityTest_Class_Obj.completedday = dsFno.Tables[0].Rows[0]["PendingFor"].ToString();
                SatbilityTest_Class_Obj.filename = dsFno.Tables[0].Rows[0]["FileName"].ToString();

                DataSet dsFMID = new DataSet();
                SatbilityTest_Class_Obj.fmid = Convert.ToInt64(dsFno.Tables[0].Rows[0]["FMID"].ToString());
                dsFMID = SatbilityTest_Class_Obj.SELECT_StabilityTest_For_Update();
                if (dsFMID.Tables[0].Rows.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("Record for this Formula No and Test already exists...!\n\n Update ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        //Test details Record Update in tblStability Test Details
                        for (int i = 0; i < dgAmbientIdTest.Rows.Count; i++)
                        {
                            SatbilityTest_Class_Obj.readingtype = "1";
                            SatbilityTest_Class_Obj.testtype = "Identification";
                            SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dgAmbientIdTest["FGPhyMethodNo", i].Value);

                            SatbilityTest_Class_Obj.normmin = dgAmbientIdTest["AmbientMin", i].Value.ToString();
                            SatbilityTest_Class_Obj.normmax = dgAmbientIdTest["AmbientMax", i].Value.ToString();
                            SatbilityTest_Class_Obj.reading = dgAmbientIdTest["AmbientReading", i].Value.ToString();
                            SatbilityTest_Class_Obj.remark = dgAmbientIdTest["AmbientRemark", i].Value.ToString();

                            // Update the initial/final values and readings in method details table
                            SatbilityTest_Class_Obj.Update_tblStabilityTestDetails();
                        }
                        for (int i = 0; i < dgAmbientConTest.Rows.Count; i++)
                        {
                            //SatbilityTest_Class_Obj.testtype = "";
                            SatbilityTest_Class_Obj.testtype = "Control";
                            SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dgAmbientConTest["FGPhyMethodNoCon", i].Value);

                            SatbilityTest_Class_Obj.normmin = dgAmbientConTest["AmbientMinCon", i].Value.ToString();
                            SatbilityTest_Class_Obj.normmax = dgAmbientConTest["AmbientMaxCon", i].Value.ToString();
                            SatbilityTest_Class_Obj.reading = dgAmbientConTest["AmbientReadingCon", i].Value.ToString();
                            SatbilityTest_Class_Obj.remark = dgAmbientConTest["AmbientRemarkCon", i].Value.ToString();

                            // Update the initial/final values and readings in method details table
                            SatbilityTest_Class_Obj.Update_tblStabilityTestDetails();
                        }

                        //45 Degree Record Save in Stability Test Details
                        for (int i = 0; i < dg45DegreeIdTest.Rows.Count; i++)
                        {
                            SatbilityTest_Class_Obj.readingtype = "2";
                            SatbilityTest_Class_Obj.testtype = "Identification";
                            SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dg45DegreeIdTest["FGPhyMethodNo45", i].Value);

                            SatbilityTest_Class_Obj.normmin = dg45DegreeIdTest["Min45", i].Value.ToString();
                            SatbilityTest_Class_Obj.normmax = dg45DegreeIdTest["Max45", i].Value.ToString();
                            SatbilityTest_Class_Obj.reading = dg45DegreeIdTest["Reading45", i].Value.ToString();
                            SatbilityTest_Class_Obj.remark = dg45DegreeIdTest["Remark45", i].Value.ToString();

                            // Update the initial/final values and readings in method details table
                            SatbilityTest_Class_Obj.Update_tblStabilityTestDetails();
                        }
                        for (int i = 0; i < dg45DegreeConTest.Rows.Count; i++)
                        {
                            //SatbilityTest_Class_Obj.testtype = "";
                            SatbilityTest_Class_Obj.testtype = "Control";
                            SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dg45DegreeConTest["FGPhyMethodNo45Con", i].Value);

                            SatbilityTest_Class_Obj.normmin = dg45DegreeConTest["Min45Con", i].Value.ToString();
                            SatbilityTest_Class_Obj.normmax = dg45DegreeConTest["Max45Con", i].Value.ToString();
                            SatbilityTest_Class_Obj.reading = dg45DegreeConTest["Reading45Con", i].Value.ToString();
                            SatbilityTest_Class_Obj.remark = dg45DegreeConTest["Remark45Con", i].Value.ToString();

                            // Update the initial/final values and readings in method details table
                            SatbilityTest_Class_Obj.Update_tblStabilityTestDetails();
                        }



                        //4 Degree Record Save in Stability Test Details
                        for (int i = 0; i < dg4DegreeIdTest.Rows.Count; i++)
                        {
                            SatbilityTest_Class_Obj.readingtype = "3";
                            SatbilityTest_Class_Obj.testtype = "Identification";
                            SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dg4DegreeIdTest["FGPhyMethodNo4Degree", i].Value);

                            SatbilityTest_Class_Obj.normmin = dg4DegreeIdTest["Min4Degree", i].Value.ToString();
                            SatbilityTest_Class_Obj.normmax = dg4DegreeIdTest["Max4Degree", i].Value.ToString();
                            SatbilityTest_Class_Obj.reading = dg4DegreeIdTest["Reading4Degree", i].Value.ToString();
                            SatbilityTest_Class_Obj.remark = dg4DegreeIdTest["Remark4Degree", i].Value.ToString();

                            // Update the initial/final values and readings in method details table
                            SatbilityTest_Class_Obj.Update_tblStabilityTestDetails();
                        }
                        for (int i = 0; i < dg4DegreeConTest.Rows.Count; i++)
                        {
                            //SatbilityTest_Class_Obj.testtype = "";
                            SatbilityTest_Class_Obj.testtype = "Control";
                            SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dg4DegreeConTest["FGPhyMethodNo4DegreeCon", i].Value);

                            SatbilityTest_Class_Obj.normmin = dg4DegreeConTest["Min4DegreeCon", i].Value.ToString();
                            SatbilityTest_Class_Obj.normmax = dg4DegreeConTest["Max4DegreeCon", i].Value.ToString();
                            SatbilityTest_Class_Obj.reading = dg4DegreeConTest["Reading4DegreeCon", i].Value.ToString();
                            SatbilityTest_Class_Obj.remark = dg4DegreeConTest["Remark4DegreeCon", i].Value.ToString();

                            // Update the initial/final values and readings in method details table
                            SatbilityTest_Class_Obj.Update_tblStabilityTestDetails();
                        }

                        bool fileExist = true;
                        SaveExportPdfFile(fileExist);

                        MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                    }
                }
                else
                {
                    //Test details Record saved in tblStability Test Details
                    for (int i = 0; i < dgAmbientIdTest.Rows.Count; i++)
                    {
                        SatbilityTest_Class_Obj.readingtype = "1";
                        SatbilityTest_Class_Obj.testtype = "Identification";
                        SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dgAmbientIdTest["FGPhyMethodNo", i].Value);
                        if (dgAmbientIdTest["AmbientMin", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmin = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmin = dgAmbientIdTest["AmbientMin", i].Value.ToString();
                        }

                        if (dgAmbientIdTest["AmbientMax", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmax = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmax = dgAmbientIdTest["AmbientMax", i].Value.ToString();
                        }
                        if (dgAmbientIdTest["AmbientReading", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.reading = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.reading = dgAmbientIdTest["AmbientReading", i].Value.ToString();
                        }
                        if (dgAmbientIdTest["AmbientRemark", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.remark = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.remark = dgAmbientIdTest["AmbientRemark", i].Value.ToString();
                        }

                        // inserts the initial/final values and readings in method details table
                        SatbilityTest_Class_Obj.INSERT_tblStabilityTestDetails();
                    }
                    for (int i = 0; i < dgAmbientConTest.Rows.Count; i++)
                    {
                        //SatbilityTest_Class_Obj.testtype = "";
                        SatbilityTest_Class_Obj.testtype = "Control";
                        SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dgAmbientConTest["FGPhyMethodNoCon", i].Value);
                        if (dgAmbientConTest["AmbientMinCon", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmin = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmin = dgAmbientConTest["AmbientMinCon", i].Value.ToString();
                        }

                        if (dgAmbientConTest["AmbientMaxCon", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmax = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmax = dgAmbientConTest["AmbientMaxCon", i].Value.ToString();
                        }
                        if (dgAmbientConTest["AmbientReadingCon", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.reading = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.reading = dgAmbientConTest["AmbientReadingCon", i].Value.ToString();
                        }
                        if (dgAmbientConTest["AmbientRemarkCon", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.remark = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.remark = dgAmbientConTest["AmbientRemarkCon", i].Value.ToString();
                        }
                        // inserts the initial/final values and readings in method details table
                        SatbilityTest_Class_Obj.INSERT_tblStabilityTestDetails();
                    }

                    //45 Degree Record Save in Stability Test Details
                    for (int i = 0; i < dg45DegreeIdTest.Rows.Count; i++)
                    {
                        SatbilityTest_Class_Obj.readingtype = "2";
                        SatbilityTest_Class_Obj.testtype = "Identification";
                        SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dg45DegreeIdTest["FGPhyMethodNo45", i].Value);
                        if (dg45DegreeIdTest["Min45", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmin = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmin = dg45DegreeIdTest["Min45", i].Value.ToString();
                        }

                        if (dg45DegreeIdTest["Max45", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmax = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmax = dg45DegreeIdTest["Max45", i].Value.ToString();
                        }
                        if (dg45DegreeIdTest["Reading45", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.reading = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.reading = dg45DegreeIdTest["Reading45", i].Value.ToString();
                        }
                        if (dg45DegreeIdTest["Remark45", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.remark = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.remark = dg45DegreeIdTest["Remark45", i].Value.ToString();
                        }

                        // inserts the initial/final values and readings in method details table
                        SatbilityTest_Class_Obj.INSERT_tblStabilityTestDetails();
                    }
                    for (int i = 0; i < dg45DegreeConTest.Rows.Count; i++)
                    {
                        //SatbilityTest_Class_Obj.testtype = "";
                        SatbilityTest_Class_Obj.testtype = "Control";
                        SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dg45DegreeConTest["FGPhyMethodNo45Con", i].Value);
                        if (dg45DegreeConTest["Min45Con", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmin = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmin = dg45DegreeConTest["Min45Con", i].Value.ToString();
                        }

                        if (dg45DegreeConTest["Max45Con", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmax = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmax = dg45DegreeConTest["Max45Con", i].Value.ToString();
                        }
                        if (dg45DegreeConTest["Reading45Con", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.reading = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.reading = dg45DegreeConTest["Reading45Con", i].Value.ToString();
                        }
                        if (dg45DegreeConTest["Remark45Con", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.remark = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.remark = dg45DegreeConTest["Remark45Con", i].Value.ToString();
                        }
                        // inserts the initial/final values and readings in method details table
                        SatbilityTest_Class_Obj.INSERT_tblStabilityTestDetails();
                    }



                    //4 Degree Record Save in Stability Test Details
                    for (int i = 0; i < dg4DegreeIdTest.Rows.Count; i++)
                    {
                        SatbilityTest_Class_Obj.readingtype = "3";
                        SatbilityTest_Class_Obj.testtype = "Identification";
                        SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dg4DegreeIdTest["FGPhyMethodNo4Degree", i].Value);
                        if (dg4DegreeIdTest["Min4Degree", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmin = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmin = dg4DegreeIdTest["Min4Degree", i].Value.ToString();
                        }

                        if (dg4DegreeIdTest["Max4Degree", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmax = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmax = dg4DegreeIdTest["Max4Degree", i].Value.ToString();
                        }
                        if (dg4DegreeIdTest["Reading4Degree", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.reading = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.reading = dg4DegreeIdTest["Reading4Degree", i].Value.ToString();
                        }
                        if (dg4DegreeIdTest["Remark4Degree", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.remark = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.remark = dg4DegreeIdTest["Remark4Degree", i].Value.ToString();
                        }

                        // inserts the initial/final values and readings in method details table
                        SatbilityTest_Class_Obj.INSERT_tblStabilityTestDetails();
                    }
                    for (int i = 0; i < dg4DegreeConTest.Rows.Count; i++)
                    {
                        //SatbilityTest_Class_Obj.testtype = "";
                        SatbilityTest_Class_Obj.testtype = "Control";
                        SatbilityTest_Class_Obj.fgphymethodno = Convert.ToInt64(dg4DegreeConTest["FGPhyMethodNo4DegreeCon", i].Value);
                        if (dg4DegreeConTest["Min4DegreeCon", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmin = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmin = dg4DegreeConTest["Min4DegreeCon", i].Value.ToString();
                        }

                        if (dg4DegreeConTest["Max4DegreeCon", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.normmax = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.normmax = dg4DegreeConTest["Max4DegreeCon", i].Value.ToString();
                        }
                        if (dg4DegreeConTest["Reading4DegreeCon", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.reading = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.reading = dg4DegreeConTest["Reading4DegreeCon", i].Value.ToString();
                        }
                        if (dg4DegreeConTest["Remark4DegreeCon", i].Value == null)
                        {
                            SatbilityTest_Class_Obj.remark = "";
                        }
                        else
                        {
                            SatbilityTest_Class_Obj.remark = dg4DegreeConTest["Remark4DegreeCon", i].Value.ToString();
                        }
                        // inserts the initial/final values and readings in method details table
                        SatbilityTest_Class_Obj.INSERT_tblStabilityTestDetails();
                    }

                    if (SatbilityTest_Class_Obj.completedday == "Month 2")
                    {
                        bool fileExist = false;
                        SaveExportPdfFile(fileExist);
                    }
                    else
                    {
                        SatbilityTest_Class_Obj.STP_Update_tblStabilityTestReminder();
                    }

                    MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Edit control showing event for Control test grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //  private void dgAmbientConTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
       // {
            //if (dgAmbientConTest.CurrentCell.RowIndex < 0
            //    || (dgAmbientConTest.CurrentCell.ColumnIndex != dgAmbientConTest.Columns["AmbientReadingCon"].Index))
            //{
            //    return;
            //}
            //else if (dgAmbientConTest.CurrentCell.ColumnIndex == dgAmbientConTest.Columns["AmbientReadingCon"].Index)
            //{
            //    dgAmbientConTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            //}
       // }

        /// <summary>
        /// Edit control showing event for Identification Test grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         // private void dgAmbientIdTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
         // {
            //if (dgAmbientIdTest.CurrentCell.RowIndex < 0 || (dgAmbientIdTest.CurrentCell.ColumnIndex != dgAmbientIdTest.Columns["AmbientReading"].Index))
            //{
            //    return;
            //}

            //else 
           // if (dgAmbientIdTest.CurrentCell.ColumnIndex == dgAmbientIdTest.Columns["AmbientReading"].Index)
           // {
                //dgAmbientIdTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);

                ////TextBox tb = e.Control as TextBox;
                ////if (tb != null)
                ////{
                ////    tb.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
                ////}

                
          //  }
        //}

        /// <summary>
        /// Edit control showing event for Identification Test grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       // private void dg45DegreeIdTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
       // {
            //if (dg45DegreeIdTest.CurrentCell.RowIndex < 0
            //    || (dg45DegreeIdTest.CurrentCell.ColumnIndex != dg45DegreeIdTest.Columns["Reading45"].Index))
            //{
            //    return;
            //}
            //else if (dg45DegreeIdTest.CurrentCell.ColumnIndex == dg45DegreeIdTest.Columns["Reading45"].Index)
            //{
            //    dg45DegreeIdTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            //}
       // }

        /// <summary>
        /// Edit control showing event for Control test grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       // private void dg45DegreeConTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
       // {
            //if (dg45DegreeConTest.CurrentCell.RowIndex < 0
            //    || (dg45DegreeConTest.CurrentCell.ColumnIndex != dg45DegreeConTest.Columns["Reading45Con"].Index))
            //{
            //    return;
            //}
            //else if (dg45DegreeConTest.CurrentCell.ColumnIndex == dg45DegreeConTest.Columns["Reading45Con"].Index)
            //{
            //    dg45DegreeConTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            //}
       // }

        /// <summary>
        /// Edit control showing event for Identification Test grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       // private void dg4DegreeIdTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
       // {
            //if (dg4DegreeIdTest.CurrentCell.RowIndex < 0
            //    || (dg4DegreeIdTest.CurrentCell.ColumnIndex != dg4DegreeIdTest.Columns["Reading4Degree"].Index))
            //{
            //    return;
            //}
            //else if (dg4DegreeIdTest.CurrentCell.ColumnIndex == dg4DegreeIdTest.Columns["Reading4Degree"].Index)
            //{
            //    dg4DegreeIdTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            //}
       // }

        /// <summary>
        /// Edit control showing event for Control test grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       // private void dg4DegreeConTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
       // {
            //if (dg4DegreeConTest.CurrentCell.RowIndex < 0
            //    || (dg4DegreeConTest.CurrentCell.ColumnIndex != dg4DegreeConTest.Columns["Reading4DegreeCon"].Index))
            //{
            //    return;
            //}
            //else if (dg4DegreeConTest.CurrentCell.ColumnIndex == dg4DegreeConTest.Columns["Reading4DegreeCon"].Index)
            //{
            //    dg4DegreeConTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            //}
       // }

        /// <summary>
        /// Key press event for Readings  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //only allow 0 to 9, backspace, comma, period, enter and tab


        //    //if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) != true)
        //    //{
        //    //    e.Handled = true;
        //    //}


        //    if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

        //         e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

        //         e.KeyChar != 9)
        //    {
        //        e.Handled = true;
        //    }


        //}








        /// <summary>
        /// Cell validating event for Test gris
        /// Reading cell becomes red if reading value is out of norms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAmbientIdTest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgAmbientIdTest.Columns["AmbientReading"].Index)
            {
                return;
            }
            else
            {
                decimal i;

                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                   
                        //e.Cancel = true;
                        MessageBox.Show("Please Enter Number");
                       
                        return;
                }
                else
                {
                    // the input is numeric 
                }

                if (dgAmbientIdTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgAmbientIdTest["AmbientMax", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgAmbientIdTest["AmbientMin", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgAmbientIdTest.CurrentCell.Style.BackColor = Color.Red;
                        // if (GlobalVariables.City == "BADDI")
                        // OOS_Begin(dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientIdTest["IdentificationTest", dgTest.CurrentCell.RowIndex].Value.ToString().Trim());
                        return;
                    }

                    if (dgAmbientIdTest["AmbientMax", dgAmbientIdTest.CurrentCell.RowIndex].Value != null && dgAmbientIdTest["AmbientMax", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgAmbientIdTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgAmbientIdTest["AmbientMax", dgAmbientIdTest.CurrentCell.RowIndex].Value))
                        {
                            dgAmbientIdTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            // OOS_Begin(dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dgAmbientIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgAmbientIdTest["AmbientMin", dgAmbientIdTest.CurrentCell.RowIndex].Value != null && dgAmbientIdTest["AmbientMin", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgAmbientIdTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgAmbientIdTest["AmbientMin", dgAmbientIdTest.CurrentCell.RowIndex].Value))
                        {
                            dgAmbientIdTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            // OOS_Begin(dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dgAmbientIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dgAmbientIdTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        /// <summary>
        /// Cell validating event for Test gris
        /// Reading cell becomes red if reading value is out of norms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAmbientConTest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgAmbientConTest.Columns["AmbientReadingCon"].Index)
            {
                return;
            }
            else
            {
                decimal i;

                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                   // e.Cancel = true;
                    MessageBox.Show("Please Enter Number");
                    return;
                }

                if (dgAmbientConTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgAmbientConTest["AmbientMaxCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgAmbientConTest["AmbientMinCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgAmbientConTest.CurrentCell.Style.BackColor = Color.Red;
                        // if (GlobalVariables.City == "BADDI")
                        // OOS_Begin(dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientConTest["AmbientTestCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim());
                        return;
                    }

                    if (dgAmbientConTest["AmbientMaxCon", dgAmbientConTest.CurrentCell.RowIndex].Value != null && dgAmbientConTest["AmbientMaxCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgAmbientConTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgAmbientConTest["AmbientMaxCon", dgAmbientConTest.CurrentCell.RowIndex].Value))
                        {
                            dgAmbientConTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            //OOS_Begin(dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientConTest["AmbientTestCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dgAmbientConTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgAmbientConTest["AmbientMinCon", dgAmbientConTest.CurrentCell.RowIndex].Value != null && dgAmbientConTest["AmbientMinCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgAmbientConTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgAmbientConTest["AmbientMinCon", dgAmbientConTest.CurrentCell.RowIndex].Value))
                        {
                            dgAmbientConTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            // OOS_Begin(dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientConTest["AmbientTestCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dgAmbientConTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dgAmbientConTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        /// <summary>
        /// Cell validating event for Test gris
        /// Reading cell becomes red if reading value is out of norms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dg45DegreeIdTest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dg45DegreeIdTest.Columns["Reading45"].Index)
            {
                return;
            }
            else
            {
                decimal i;

                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                   // e.Cancel = true;
                    MessageBox.Show("Please Enter Number");
                    return;
                }

                if (dg45DegreeIdTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dg45DegreeIdTest["Max45", dg45DegreeIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dg45DegreeIdTest["Min45", dg45DegreeIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dg45DegreeIdTest.CurrentCell.Style.BackColor = Color.Red;
                        // if (GlobalVariables.City == "BADDI")
                        // OOS_Begin(dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientIdTest["IdentificationTest", dgTest.CurrentCell.RowIndex].Value.ToString().Trim());
                        return;
                    }

                    if (dg45DegreeIdTest["Max45", dg45DegreeIdTest.CurrentCell.RowIndex].Value != null && dg45DegreeIdTest["Max45", dg45DegreeIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg45DegreeIdTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dg45DegreeIdTest["Max45", dg45DegreeIdTest.CurrentCell.RowIndex].Value))
                        {
                            dg45DegreeIdTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            // OOS_Begin(dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dg45DegreeIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dg45DegreeIdTest["Min45", dg45DegreeIdTest.CurrentCell.RowIndex].Value != null && dg45DegreeIdTest["Min45", dg45DegreeIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg45DegreeIdTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dg45DegreeIdTest["Min45", dg45DegreeIdTest.CurrentCell.RowIndex].Value))
                        {
                            dg45DegreeIdTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            // OOS_Begin(dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dg45DegreeIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dg45DegreeIdTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        /// <summary>
        /// Cell validating event for Test gris
        /// Reading cell becomes red if reading value is out of norms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dg45DegreeConTest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dg45DegreeConTest.Columns["Reading45Con"].Index)
            {
                return;
            }
            else
            {
                decimal i;

                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                   // e.Cancel = true;
                    MessageBox.Show("Please Enter Number");
                    return;
                }

                if (dg45DegreeConTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dg45DegreeConTest["Max45Con", dg45DegreeConTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dg45DegreeConTest["Min45Con", dg45DegreeConTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dg45DegreeConTest.CurrentCell.Style.BackColor = Color.Red;
                        // if (GlobalVariables.City == "BADDI")
                        // OOS_Begin(dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientConTest["AmbientTestCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim());
                        return;
                    }

                    if (dg45DegreeConTest["Max45Con", dg45DegreeConTest.CurrentCell.RowIndex].Value != null && dg45DegreeConTest["Max45Con", dg45DegreeConTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg45DegreeConTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dg45DegreeConTest["Max45Con", dg45DegreeConTest.CurrentCell.RowIndex].Value))
                        {
                            dg45DegreeConTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            //OOS_Begin(dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientConTest["AmbientTestCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dg45DegreeConTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dg45DegreeConTest["Min45Con", dg45DegreeConTest.CurrentCell.RowIndex].Value != null && dg45DegreeConTest["Min45Con", dg45DegreeConTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg45DegreeConTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dg45DegreeConTest["Min45Con", dg45DegreeConTest.CurrentCell.RowIndex].Value))
                        {
                            dg45DegreeConTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            // OOS_Begin(dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientConTest["AmbientTestCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dg45DegreeConTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dg45DegreeConTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        /// <summary>
        /// Cell validating event for Test gris
        /// Reading cell becomes red if reading value is out of norms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dg4DegreeIdTest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dg4DegreeIdTest.Columns["Reading4Degree"].Index)
            {
                return;
            }
            else
            {
                decimal i;

                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                   // e.Cancel = true;
                    MessageBox.Show("Please Enter Number");
                    return;
                }

                if (dg4DegreeIdTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dg4DegreeIdTest["Max4Degree", dg4DegreeIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dg4DegreeIdTest["Min4Degree", dg4DegreeIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dg4DegreeIdTest.CurrentCell.Style.BackColor = Color.Red;
                        // if (GlobalVariables.City == "BADDI")
                        // OOS_Begin(dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientIdTest["IdentificationTest", dgTest.CurrentCell.RowIndex].Value.ToString().Trim());
                        return;
                    }

                    if (dg4DegreeIdTest["Max4Degree", dg4DegreeIdTest.CurrentCell.RowIndex].Value != null && dg4DegreeIdTest["Max4Degree", dg4DegreeIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg4DegreeIdTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dg4DegreeIdTest["Max4Degree", dg4DegreeIdTest.CurrentCell.RowIndex].Value))
                        {
                            dg4DegreeIdTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            // OOS_Begin(dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dg4DegreeIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dg4DegreeIdTest["Min4Degree", dg4DegreeIdTest.CurrentCell.RowIndex].Value != null && dg4DegreeIdTest["Min4Degree", dg4DegreeIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg4DegreeIdTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dg4DegreeIdTest["Min4Degree", dg4DegreeIdTest.CurrentCell.RowIndex].Value))
                        {
                            dg4DegreeIdTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            // OOS_Begin(dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dg4DegreeIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dg4DegreeIdTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        /// <summary>
        /// Cell validating event for Test gris
        /// Reading cell becomes red if reading value is out of norms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dg4DegreeConTest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dg4DegreeConTest.Columns["Reading4DegreeCon"].Index)
            {
                return;
            }
            else
            {
                decimal i;

                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                   // e.Cancel = true;
                    MessageBox.Show("Please Enter Number");
                    return;
                }

                if (dg4DegreeConTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dg4DegreeConTest["Max4DegreeCon", dg4DegreeConTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dg4DegreeConTest["Min4DegreeCon", dg4DegreeConTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dg4DegreeConTest.CurrentCell.Style.BackColor = Color.Red;
                        // if (GlobalVariables.City == "BADDI")
                        // OOS_Begin(dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientConTest["AmbientTestCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim());
                        return;
                    }

                    if (dg4DegreeConTest["Max4DegreeCon", dg4DegreeConTest.CurrentCell.RowIndex].Value != null && dg4DegreeConTest["Max4DegreeCon", dg4DegreeConTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg4DegreeConTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dg4DegreeConTest["Max4DegreeCon", dg4DegreeConTest.CurrentCell.RowIndex].Value))
                        {
                            dg4DegreeConTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            //OOS_Begin(dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientConTest["AmbientTestCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dg4DegreeConTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dg4DegreeConTest["Min4DegreeCon", dg4DegreeConTest.CurrentCell.RowIndex].Value != null && dg4DegreeConTest["Min4DegreeCon", dg4DegreeConTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg4DegreeConTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dg4DegreeConTest["Min4DegreeCon", dg4DegreeConTest.CurrentCell.RowIndex].Value))
                        {
                            dg4DegreeConTest.CurrentCell.Style.BackColor = Color.Red;
                            // if (GlobalVariables.City == "BADDI")
                            // OOS_Begin(dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgAmbientConTest["AmbientTestCon", dgAmbientConTest.CurrentCell.RowIndex].Value.ToString().Trim());
                            return;
                        }
                        else
                        {
                            dg4DegreeConTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dg4DegreeConTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }


        private void BtnReset_Click(object sender, EventArgs e)
        {
            CmbFormulaNo.Text = "--Select--";
            txtDescription.Text = "";
            lbBatch.Text = "";
            lbTest.Text = "";
            DtpLunchDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpCurrentDate.Value = Comman_Class_Obj.Select_ServerDate();
            dgTest.Rows.Clear();
            dgTestCon.Rows.Clear();
            dgAmbientIdTest.Rows.Clear();
            dgAmbientConTest.Rows.Clear();
            dg45DegreeIdTest.Rows.Clear();
            dg45DegreeConTest.Rows.Clear();
            dg4DegreeIdTest.Rows.Clear();
            dg4DegreeConTest.Rows.Clear();
            CmbFormulaNo.Focus();
            BtnSave.Enabled = true;

            BtnWeek1.Enabled = false;
            BtnWeek2.Enabled = false;
            BtnMonth1.Enabled = false;
            BtnMonth2.Enabled = false;
        }
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnWeek1_Click(object sender, EventArgs e)
        {
            try
            {
                dgAmbientIdTest.Rows.Clear();
                dgAmbientConTest.Rows.Clear();
                dg45DegreeIdTest.Rows.Clear();
                dg45DegreeConTest.Rows.Clear();
                dg4DegreeIdTest.Rows.Clear();
                dg4DegreeConTest.Rows.Clear();
                dgAmbientIdTest.ReadOnly = false;
                dgAmbientConTest.ReadOnly = false;
                dg45DegreeIdTest.ReadOnly = false;
                dg45DegreeConTest.ReadOnly = false;
                dg4DegreeIdTest.ReadOnly = false;
                dg4DegreeConTest.ReadOnly = false;
                BtnSave.Enabled = true;

                DataSet ds = new DataSet();
                SatbilityTest_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                SatbilityTest_Class_Obj.completedday = "Week 1";
                DataSet dsStability = new DataSet();
                dsStability = SatbilityTest_Class_Obj.STP_SELECT_StabilityTest_History();

                
                DataSet dslist = new DataSet();
                SatbilityTest_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                dslist = SatbilityTest_Class_Obj.SELECT_StabilityReminder_Active();

                if (EditGridViewWeek1 == false)
                {
                    BtnSave.Enabled = false;
                    dgAmbientIdTest.ReadOnly = true;
                    dgAmbientConTest.ReadOnly = true;
                    dg45DegreeIdTest.ReadOnly = true;
                    dg45DegreeConTest.ReadOnly = true;
                    dg4DegreeIdTest.ReadOnly = true;
                    dg4DegreeConTest.ReadOnly = true;

                }
                if (dsStability.Tables[0].Rows.Count > 0)
                {
                    lbTest.Text = dsStability.Tables[0].Rows[0]["CompletedDay"].ToString();
                    for (int i = 0; i < dsStability.Tables[0].Rows.Count; i++)
                    {
                        // Test For Ambient ReadingType
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "1")
                        {
                            dgAmbientIdTest.Rows.Add();
                            dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dgAmbientIdTest["AmbientMin", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgAmbientIdTest["AmbientMax", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgAmbientIdTest["AmbientReading", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dgAmbientIdTest["AmbientRemark", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Remark"];


                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "1")
                        {
                            dgAmbientConTest.Rows.Add();
                            dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dgAmbientConTest["AmbientTestCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dgAmbientConTest["AmbientMinCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgAmbientConTest["AmbientMaxCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgAmbientConTest["AmbientReadingCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dgAmbientConTest["AmbientRemarkCon", dgAmbientConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        //Test For 45 Degree 
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "2")
                        {
                            dg45DegreeIdTest.Rows.Add();
                            dg45DegreeIdTest["FGPhyMethodNo45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg45DegreeIdTest["IdentificationTest45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg45DegreeIdTest["Min45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg45DegreeIdTest["Max45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg45DegreeIdTest["Reading45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg45DegreeIdTest["Remark45", dg45DegreeIdTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "2")
                        {
                            dg45DegreeConTest.Rows.Add();
                            dg45DegreeConTest["FGPhyMethodNo45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg45DegreeConTest["Test45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg45DegreeConTest["Min45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg45DegreeConTest["Max45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg45DegreeConTest["Reading45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg45DegreeConTest["Remark45Con", dg45DegreeConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        //Test For 4 Degree 
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "3")
                        {
                            dg4DegreeIdTest.Rows.Add();
                            dg4DegreeIdTest["FGPhyMethodNo4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg4DegreeIdTest["IdentificationTest4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg4DegreeIdTest["Min4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg4DegreeIdTest["Max4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg4DegreeIdTest["Reading4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg4DegreeIdTest["Remark4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "3")
                        {
                            dg4DegreeConTest.Rows.Add();
                            dg4DegreeConTest["FGPhyMethodNo4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg4DegreeConTest["Test4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg4DegreeConTest["Min4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg4DegreeConTest["Max4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg4DegreeConTest["Reading4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg4DegreeConTest["Remark4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }

                    }

                    // Reading cell becomes red if reading value is out of norms
                    CheckReadingValue();
                }
                else
                {
                    MessageBox.Show("User Not Enter Week 1 Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                }
                
                  
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnWeek2_Click(object sender, EventArgs e)
        {
            try
            {
                dgAmbientIdTest.Rows.Clear();
                dgAmbientConTest.Rows.Clear();
                dg45DegreeIdTest.Rows.Clear();
                dg45DegreeConTest.Rows.Clear();
                dg4DegreeIdTest.Rows.Clear();
                dg4DegreeConTest.Rows.Clear();
                dgAmbientIdTest.ReadOnly = false;
                dgAmbientConTest.ReadOnly = false;
                dg45DegreeIdTest.ReadOnly = false;
                dg45DegreeConTest.ReadOnly = false;
                dg4DegreeIdTest.ReadOnly = false;
                dg4DegreeConTest.ReadOnly = false;
                BtnSave.Enabled = true;

                DataSet ds = new DataSet();
                SatbilityTest_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                SatbilityTest_Class_Obj.completedday = "Week 2";
                DataSet dsStability = new DataSet();
                dsStability = SatbilityTest_Class_Obj.STP_SELECT_StabilityTest_History();
                

                if (EditGridViewWeek2 == false)
                {
                    BtnSave.Enabled = false;
                    dgAmbientIdTest.ReadOnly = true;
                    dgAmbientConTest.ReadOnly = true;
                    dg45DegreeIdTest.ReadOnly = true;
                    dg45DegreeConTest.ReadOnly = true;
                    dg4DegreeIdTest.ReadOnly = true;
                    dg4DegreeConTest.ReadOnly = true;

                }
                if (dsStability.Tables[0].Rows.Count > 0)
                {
                    lbTest.Text = dsStability.Tables[0].Rows[0]["CompletedDay"].ToString();
                    for (int i = 0; i < dsStability.Tables[0].Rows.Count; i++)
                    {
                        // Test For Ambient ReadingType
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "1")
                        {
                            dgAmbientIdTest.Rows.Add();
                            dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dgAmbientIdTest["AmbientMin", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgAmbientIdTest["AmbientMax", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgAmbientIdTest["AmbientReading", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dgAmbientIdTest["AmbientRemark", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Remark"];


                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "1")
                        {
                            dgAmbientConTest.Rows.Add();
                            dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dgAmbientConTest["AmbientTestCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dgAmbientConTest["AmbientMinCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgAmbientConTest["AmbientMaxCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgAmbientConTest["AmbientReadingCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dgAmbientConTest["AmbientRemarkCon", dgAmbientConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        //Test For 45 Degree 
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "2")
                        {
                            dg45DegreeIdTest.Rows.Add();
                            dg45DegreeIdTest["FGPhyMethodNo45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg45DegreeIdTest["IdentificationTest45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg45DegreeIdTest["Min45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg45DegreeIdTest["Max45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg45DegreeIdTest["Reading45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg45DegreeIdTest["Remark45", dg45DegreeIdTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "2")
                        {
                            dg45DegreeConTest.Rows.Add();
                            dg45DegreeConTest["FGPhyMethodNo45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg45DegreeConTest["Test45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg45DegreeConTest["Min45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg45DegreeConTest["Max45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg45DegreeConTest["Reading45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg45DegreeConTest["Remark45Con", dg45DegreeConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        //Test For 4 Degree 
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "3")
                        {
                            dg4DegreeIdTest.Rows.Add();
                            dg4DegreeIdTest["FGPhyMethodNo4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg4DegreeIdTest["IdentificationTest4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg4DegreeIdTest["Min4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg4DegreeIdTest["Max4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg4DegreeIdTest["Reading4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg4DegreeIdTest["Remark4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "3")
                        {
                            dg4DegreeConTest.Rows.Add();
                            dg4DegreeConTest["FGPhyMethodNo4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg4DegreeConTest["Test4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg4DegreeConTest["Min4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg4DegreeConTest["Max4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg4DegreeConTest["Reading4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg4DegreeConTest["Remark4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                    }

                    // Reading cell becomes red if reading value is out of norms
                    CheckReadingValue();
                }
                else 
                {
                    MessageBox.Show("User Not Enter Week 2 Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                }
            

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnMonth1_Click(object sender, EventArgs e)
        {
            try
            {
                dgAmbientIdTest.Rows.Clear();
                dgAmbientConTest.Rows.Clear();
                dg45DegreeIdTest.Rows.Clear();
                dg45DegreeConTest.Rows.Clear();
                dg4DegreeIdTest.Rows.Clear();
                dg4DegreeConTest.Rows.Clear();
                dgAmbientIdTest.ReadOnly = false;
                dgAmbientConTest.ReadOnly = false;
                dg45DegreeIdTest.ReadOnly = false;
                dg45DegreeConTest.ReadOnly = false;
                dg4DegreeIdTest.ReadOnly = false;
                dg4DegreeConTest.ReadOnly = false;
                BtnSave.Enabled = true;

                DataSet ds = new DataSet();
                SatbilityTest_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                SatbilityTest_Class_Obj.completedday = "Month 1";
                DataSet dsStability = new DataSet();
                dsStability = SatbilityTest_Class_Obj.STP_SELECT_StabilityTest_History();
                

                if (EditGridViewMonth1 == false)
                {
                    BtnSave.Enabled = false;
                    dgAmbientIdTest.ReadOnly = true;
                    dgAmbientConTest.ReadOnly = true;
                    dg45DegreeIdTest.ReadOnly = true;
                    dg45DegreeConTest.ReadOnly = true;
                    dg4DegreeIdTest.ReadOnly = true;
                    dg4DegreeConTest.ReadOnly = true;

                }

                if (dsStability.Tables[0].Rows.Count > 0)
                {
                    lbTest.Text = dsStability.Tables[0].Rows[0]["CompletedDay"].ToString();
                    for (int i = 0; i < dsStability.Tables[0].Rows.Count; i++)
                    {
                        // Test For Ambient ReadingType
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "1")
                        {
                            dgAmbientIdTest.Rows.Add();
                            dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dgAmbientIdTest["AmbientMin", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgAmbientIdTest["AmbientMax", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgAmbientIdTest["AmbientReading", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dgAmbientIdTest["AmbientRemark", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Remark"];


                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "1")
                        {
                            dgAmbientConTest.Rows.Add();
                            dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dgAmbientConTest["AmbientTestCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dgAmbientConTest["AmbientMinCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgAmbientConTest["AmbientMaxCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgAmbientConTest["AmbientReadingCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dgAmbientConTest["AmbientRemarkCon", dgAmbientConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        //Test For 45 Degree 
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "2")
                        {
                            dg45DegreeIdTest.Rows.Add();
                            dg45DegreeIdTest["FGPhyMethodNo45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg45DegreeIdTest["IdentificationTest45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg45DegreeIdTest["Min45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg45DegreeIdTest["Max45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg45DegreeIdTest["Reading45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg45DegreeIdTest["Remark45", dg45DegreeIdTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "2")
                        {
                            dg45DegreeConTest.Rows.Add();
                            dg45DegreeConTest["FGPhyMethodNo45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg45DegreeConTest["Test45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg45DegreeConTest["Min45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg45DegreeConTest["Max45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg45DegreeConTest["Reading45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg45DegreeConTest["Remark45Con", dg45DegreeConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        //Test For 4 Degree 
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "3")
                        {
                            dg4DegreeIdTest.Rows.Add();
                            dg4DegreeIdTest["FGPhyMethodNo4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg4DegreeIdTest["IdentificationTest4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg4DegreeIdTest["Min4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg4DegreeIdTest["Max4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg4DegreeIdTest["Reading4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg4DegreeIdTest["Remark4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "3")
                        {
                            dg4DegreeConTest.Rows.Add();
                            dg4DegreeConTest["FGPhyMethodNo4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg4DegreeConTest["Test4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg4DegreeConTest["Min4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg4DegreeConTest["Max4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg4DegreeConTest["Reading4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg4DegreeConTest["Remark4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                    }

                    // Reading cell becomes red if reading value is out of norms
                    CheckReadingValue();
                }
                else
                {
                    MessageBox.Show("User Not Enter Month 1 Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                }

              

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void BtnMonth2_Click(object sender, EventArgs e)
        {
            try
            {
                dgAmbientIdTest.Rows.Clear();
                dgAmbientConTest.Rows.Clear();
                dg45DegreeIdTest.Rows.Clear();
                dg45DegreeConTest.Rows.Clear();
                dg4DegreeIdTest.Rows.Clear();
                dg4DegreeConTest.Rows.Clear();
                dgAmbientIdTest.ReadOnly = false;
                dgAmbientConTest.ReadOnly = false;
                dg45DegreeIdTest.ReadOnly = false;
                dg45DegreeConTest.ReadOnly = false;
                dg4DegreeIdTest.ReadOnly = false;
                dg4DegreeConTest.ReadOnly = false;
                BtnSave.Enabled = true;

                DataSet ds = new DataSet();
                SatbilityTest_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                SatbilityTest_Class_Obj.completedday = "Month 2";
                DataSet dsStability = new DataSet();
                dsStability = SatbilityTest_Class_Obj.STP_SELECT_StabilityTest_History();
                

                if (EditGridViewMonth2 == false)
                {
                    BtnSave.Enabled = false;
                    dgAmbientIdTest.ReadOnly = true;
                    dgAmbientConTest.ReadOnly = true;
                    dg45DegreeIdTest.ReadOnly = true;
                    dg45DegreeConTest.ReadOnly = true;
                    dg4DegreeIdTest.ReadOnly = true;
                    dg4DegreeConTest.ReadOnly = true;

                }
                if (dsStability.Tables[0].Rows.Count > 0)
                {
                    lbTest.Text = dsStability.Tables[0].Rows[0]["CompletedDay"].ToString();
                    for (int i = 0; i < dsStability.Tables[0].Rows.Count; i++)
                    {
                        // Test For Ambient ReadingType
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "1")
                        {
                            dgAmbientIdTest.Rows.Add();
                            dgAmbientIdTest["FGPhyMethodNo", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dgAmbientIdTest["IdentificationTest", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dgAmbientIdTest["AmbientMin", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgAmbientIdTest["AmbientMax", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgAmbientIdTest["AmbientReading", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dgAmbientIdTest["AmbientRemark", dgAmbientIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Remark"];


                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "1")
                        {
                            dgAmbientConTest.Rows.Add();
                            dgAmbientConTest["FGPhyMethodNoCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dgAmbientConTest["AmbientTestCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dgAmbientConTest["AmbientMinCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgAmbientConTest["AmbientMaxCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgAmbientConTest["AmbientReadingCon", dgAmbientConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dgAmbientConTest["AmbientRemarkCon", dgAmbientConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        //Test For 45 Degree 
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "2")
                        {
                            dg45DegreeIdTest.Rows.Add();
                            dg45DegreeIdTest["FGPhyMethodNo45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg45DegreeIdTest["IdentificationTest45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg45DegreeIdTest["Min45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg45DegreeIdTest["Max45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg45DegreeIdTest["Reading45", dg45DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg45DegreeIdTest["Remark45", dg45DegreeIdTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "2")
                        {
                            dg45DegreeConTest.Rows.Add();
                            dg45DegreeConTest["FGPhyMethodNo45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg45DegreeConTest["Test45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg45DegreeConTest["Min45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg45DegreeConTest["Max45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg45DegreeConTest["Reading45Con", dg45DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg45DegreeConTest["Remark45Con", dg45DegreeConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        //Test For 4 Degree 
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Identification" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "3")
                        {
                            dg4DegreeIdTest.Rows.Add();
                            dg4DegreeIdTest["FGPhyMethodNo4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg4DegreeIdTest["IdentificationTest4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg4DegreeIdTest["Min4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg4DegreeIdTest["Max4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg4DegreeIdTest["Reading4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg4DegreeIdTest["Remark4Degree", dg4DegreeIdTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                        if (dsStability.Tables[0].Rows[i]["TestType"].ToString() == "Control" && dsStability.Tables[0].Rows[i]["ReadingType"].ToString() == "3")
                        {
                            dg4DegreeConTest.Rows.Add();
                            dg4DegreeConTest["FGPhyMethodNo4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dg4DegreeConTest["Test4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["Test"].ToString();
                            dg4DegreeConTest["Min4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMin"].ToString();
                            dg4DegreeConTest["Max4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsMax"].ToString();
                            dg4DegreeConTest["Reading4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = dsStability.Tables[0].Rows[i]["NormsReading"].ToString();
                            dg4DegreeConTest["Remark4DegreeCon", dg4DegreeConTest.Rows.Count - 1].Value = Convert.ToString(dsStability.Tables[0].Rows[i]["Remark"]);
                        }
                    }
                }
                else 
                {
                    MessageBox.Show("User Not Enter Month 2 Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                }

             // Reading cell becomes red if reading value is out of norms
                CheckReadingValue();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void panelFill_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckReadingValue()
        {

            // Reading cell becomes red if reading value is out of norms For Ambient Identification
            for (int i = 0; i < dgAmbientIdTest.Rows.Count; i++)
            {
                if (dgAmbientIdTest["AmbientReading", 0].Value != null)
                {
                    if (dgAmbientIdTest["AmbientMax", i].Value.ToString().Trim() == "" && dgAmbientIdTest["AmbientMin", i].Value.ToString().Trim() == "")
                    {

                        dgAmbientIdTest["AmbientReading", i].Style.BackColor = Color.Red;

                    }

                    if (dgAmbientIdTest["AmbientMax", i].Value != null && dgAmbientIdTest["AmbientMax", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgAmbientIdTest["AmbientReading", i].Value) > Convert.ToDouble(dgAmbientIdTest["AmbientMax", i].Value))
                        {

                            dgAmbientIdTest["AmbientReading", i].Style.BackColor = Color.Red;

                        }

                    }

                    if (dgAmbientIdTest["AmbientMin", i].Value != null && dgAmbientIdTest["AmbientMin", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgAmbientIdTest["AmbientReading", i].Value) < Convert.ToDouble(dgAmbientIdTest["AmbientMin", i].Value))
                        {

                            dgAmbientIdTest["AmbientReading", i].Style.BackColor = Color.Red;

                        }

                    }
                }
                else
                {
                    dgAmbientIdTest.CurrentCell.Style.BackColor = Color.White;
                }
            }

           
            
            for (int i = 0; i < dgAmbientConTest.Rows.Count; i++)
             {
                if (dgAmbientConTest["AmbientReadingCon", 0].Value != null)
                {
                    if (dgAmbientConTest["AmbientMaxCon", i].Value.ToString().Trim() == "" && dgAmbientConTest["AmbientMinCon", i].Value.ToString().Trim() == "")
                    {

                        dgAmbientConTest["AmbientReadingCon", i].Style.BackColor = Color.Red;
                        // return;
                    }

                    if (dgAmbientConTest["AmbientMaxCon", i].Value != null && dgAmbientConTest["AmbientMaxCon", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgAmbientConTest["AmbientReadingCon", i].Value) > Convert.ToDouble(dgAmbientConTest["AmbientMaxCon", i].Value))
                        {
                            dgAmbientConTest["AmbientReadingCon", i].Style.BackColor = Color.Red;
                            // return;
                        }

                    }

                    if (dgAmbientConTest["AmbientMinCon", i].Value != null && dgAmbientConTest["AmbientMinCon", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgAmbientConTest["AmbientReadingCon", i].Value) < Convert.ToDouble(dgAmbientConTest["AmbientMinCon", i].Value))
                        {
                            dgAmbientConTest["AmbientReadingCon", i].Style.BackColor = Color.Red;
                            // return;
                        }

                    }
                }

                else
                {
                    dgAmbientConTest.CurrentCell.Style.BackColor = Color.White;
                }
            }






            // Reading cell becomes red if reading value is out of norms For 45 Degree Identification
            //if (dg45DegreeIdTest["Reading45", 0].Value != null)
            //{
            //    if (dg45DegreeIdTest["Max45", dg45DegreeIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dg45DegreeIdTest["Min45", dg45DegreeIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
            //    {
                  
            //        dg45DegreeIdTest["Reading45", dg45DegreeIdTest.CurrentCell.RowIndex].Style.BackColor = Color.Red;
            //        //return;
            //    }

            //    if (dg45DegreeIdTest["Max45", dg45DegreeIdTest.CurrentCell.RowIndex].Value != null && dg45DegreeIdTest["Max45", dg45DegreeIdTest.CurrentCell.RowIndex].Value.ToString() != "")
            //    {
            //        if (Convert.ToDouble(dg45DegreeIdTest["Reading45", dg45DegreeIdTest.CurrentCell.RowIndex].Value) > Convert.ToDouble(dg45DegreeIdTest["Max45", dg45DegreeIdTest.CurrentCell.RowIndex].Value))
            //        {
            //            dg45DegreeIdTest["Reading45", dg45DegreeIdTest.CurrentCell.RowIndex].Style.BackColor = Color.Red;
            //        }
                   
            //    }

            //    if (dg45DegreeIdTest["Min45", dg45DegreeIdTest.CurrentCell.RowIndex].Value != null && dg45DegreeIdTest["Min45", dg45DegreeIdTest.CurrentCell.RowIndex].Value.ToString() != "")
            //    {
            //        if (Convert.ToDouble(dg45DegreeIdTest["Reading45", dg45DegreeIdTest.CurrentCell.RowIndex].Value) < Convert.ToDouble(dg45DegreeIdTest["Min45", dg45DegreeIdTest.CurrentCell.RowIndex].Value))
            //        {
            //            dg45DegreeIdTest["Reading45", dg45DegreeIdTest.CurrentCell.RowIndex].Style.BackColor = Color.Red;
            //        }
                    
            //    }
            //}
            //else
            //{
            //    dg45DegreeIdTest.CurrentCell.Style.BackColor = Color.White;
            //}


            for (int i = 0; i < dg45DegreeIdTest.Rows.Count; i++)
            {
                if (dg45DegreeIdTest["Reading45", 0].Value != null)
                {
                    if (dg45DegreeIdTest["Max45", i].Value.ToString().Trim() == "" && dg45DegreeIdTest["Min45", i].Value.ToString().Trim() == "")
                    {

                        dg45DegreeIdTest["Reading45", i].Style.BackColor = Color.Red;
                        //return;
                    }

                    if (dg45DegreeIdTest["Max45", i].Value != null && dg45DegreeIdTest["Max45", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg45DegreeIdTest["Reading45", i].Value) > Convert.ToDouble(dg45DegreeIdTest["Max45", i].Value))
                        {
                            dg45DegreeIdTest["Reading45", i].Style.BackColor = Color.Red;
                        }

                    }

                    if (dg45DegreeIdTest["Min45", i].Value != null && dg45DegreeIdTest["Min45", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg45DegreeIdTest["Reading45", i].Value) < Convert.ToDouble(dg45DegreeIdTest["Min45", i].Value))
                        {
                            dg45DegreeIdTest["Reading45", i].Style.BackColor = Color.Red;
                        }

                    }
                }
                else
                {
                    dg45DegreeIdTest.CurrentCell.Style.BackColor = Color.White;
                }
            }

            // Reading cell becomes red if reading value is out of norms For 45 Degree Control
            for (int i = 0; i < dg45DegreeConTest.Rows.Count; i++)
            {
                if (dg45DegreeConTest["Reading45Con", 0].Value != null)
                {
                    if (dg45DegreeConTest["Max45Con", i].Value.ToString().Trim() == "" && dg45DegreeConTest["Min45Con", i].Value.ToString().Trim() == "")
                    {

                        dg45DegreeConTest["Reading45Con", i].Style.BackColor = Color.Red;
                    }

                    if (dg45DegreeConTest["Max45Con", i].Value != null && dg45DegreeConTest["Max45Con", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg45DegreeConTest["Reading45Con", i].Value) > Convert.ToDouble(dg45DegreeConTest["Max45Con", i].Value))
                        {
                            dg45DegreeConTest["Reading45Con", i].Style.BackColor = Color.Red;
                        }

                    }

                    if (dg45DegreeConTest["Min45Con", i].Value != null && dg45DegreeConTest["Min45Con", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg45DegreeConTest["Reading45Con", i].Value) < Convert.ToDouble(dg45DegreeConTest["Min45Con", i].Value))
                        {
                            dg45DegreeConTest["Reading45Con", i].Style.BackColor = Color.Red;
                        }

                    }
                }
                else
                {
                    dg45DegreeConTest.CurrentCell.Style.BackColor = Color.White;
                }
            }
            // Reading cell becomes red if reading value is out of norms For 4 Degree Identification
            for (int i = 0; i < dg4DegreeIdTest.Rows.Count; i++)
            {
                if (dg4DegreeIdTest["Reading4Degree", 0].Value != null)
                {
                    if (dg4DegreeIdTest["Max4Degree", i].Value.ToString().Trim() == "" && dg4DegreeIdTest["Min4Degree", i].Value.ToString().Trim() == "")
                    {
                        dg4DegreeIdTest["Reading4Degree", i].Style.BackColor = Color.Red;
                    }

                    if (dg4DegreeIdTest["Max4Degree", i].Value != null && dg4DegreeIdTest["Max4Degree", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg4DegreeIdTest["Reading4Degree", i].Value) > Convert.ToDouble(dg4DegreeIdTest["Max4Degree", i].Value))
                        {
                            dg4DegreeIdTest["Reading4Degree", i].Style.BackColor = Color.Red;
                        }

                    }

                    if (dg4DegreeIdTest["Min4Degree", i].Value != null && dg4DegreeIdTest["Min4Degree", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg4DegreeIdTest["Reading4Degree", i].Value) < Convert.ToDouble(dg4DegreeIdTest["Min4Degree", i].Value))
                        {
                            dg4DegreeIdTest["Reading4Degree", i].Style.BackColor = Color.Red;
                        }

                    }
                }
                else
                {
                    dg4DegreeIdTest.CurrentCell.Style.BackColor = Color.White;
                }
            }
            // Reading cell becomes red if reading value is out of norms For 4 Degree Control
            for (int i = 0; i < dg4DegreeConTest.Rows.Count; i++)
            {
                if (dg4DegreeConTest["Reading4DegreeCon", 0].Value != null)
                {
                    if (dg4DegreeConTest["Max4DegreeCon", i].Value.ToString().Trim() == "" && dg4DegreeConTest["Min4DegreeCon", i].Value.ToString().Trim() == "")
                    {
                        dg4DegreeConTest["Reading4DegreeCon", i].Style.BackColor = Color.Red;
                    }

                    if (dg4DegreeConTest["Max4DegreeCon", i].Value != null && dg4DegreeConTest["Max4DegreeCon", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg4DegreeConTest["Reading4DegreeCon", i].Value) > Convert.ToDouble(dg4DegreeConTest["Max4DegreeCon", i].Value))
                        {
                            dg4DegreeConTest["Reading4DegreeCon", i].Style.BackColor = Color.Red;
                        }

                    }

                    if (dg4DegreeConTest["Min4DegreeCon", i].Value != null && dg4DegreeConTest["Min4DegreeCon", i].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dg4DegreeConTest["Reading4DegreeCon", i].Value) < Convert.ToDouble(dg4DegreeConTest["Min4DegreeCon", i].Value))
                        {
                            dg4DegreeConTest["Reading4DegreeCon", i].Style.BackColor = Color.Red;
                        }

                    }
                }
                else
                {
                    dg4DegreeConTest.CurrentCell.Style.BackColor = Color.White;
                }
            }
        }

        private void SaveExportPdfFile(Boolean fileExist)
        {
         try
           {

            if (SatbilityTest_Class_Obj.completedday == "Month 2")
            {
                
                    QTMS.Reports.StabilityTest_Report StabilityTestReport = new QTMS.Reports.StabilityTest_Report();

                   // SatbilityTest_Class_Obj.fmid = Convert.ToInt64(dsFno.Tables[0].Rows[0]["FMID"].ToString());

                    DataSet ds = new DataSet();
                    ds = SatbilityTest_Class_Obj.SELECT_View_StabilityTest_Report();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string FileName = "";
                        StabilityTestReport.SetDataSource(ds.Tables[0]);

                        if (SatbilityTest_Class_Obj.filename != null && SatbilityTest_Class_Obj.filename != "")
                        {
                            FileName = SatbilityTest_Class_Obj.filename;
                        }
                        else
                        {
                            FileName = CmbFormulaNo.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
                            SatbilityTest_Class_Obj.filename = FileName;
                            //SatbilityTest_Class_Obj.filename = filename;
                        }
                        

                        ExportOptions CrExportOptions;
                        DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                        PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                        // CrDiskFileDestinationOptions.DiskFileName = Application.StartupPath+ "\\SampleReport.pdf"; HHmmss
                        CrDiskFileDestinationOptions.DiskFileName = Application.StartupPath + "\\" + FileName;

                        CrExportOptions = StabilityTestReport.ExportOptions;
                        {
                            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                            CrExportOptions.FormatOptions = CrFormatTypeOptions;
                        }
                        StabilityTestReport.SetParameterValue("CompanyName", Convert.ToString(GlobalVariables.companyName));
                        StabilityTestReport.SetParameterValue("CompanyAddress", Convert.ToString(GlobalVariables.companyAddress));
                        StabilityTestReport.Export();

                        string FilePath = System.Configuration.ConfigurationManager.AppSettings["StabilityFile"].ToString();
                        if (!System.IO.Directory.Exists(FilePath))
                            System.IO.Directory.CreateDirectory(FilePath);

                        if (System.IO.File.Exists(FilePath + "\\" + FileName))
                            System.IO.File.Delete(FilePath + "\\" + FileName);

                        System.IO.File.Move(Application.StartupPath + "\\" + FileName, FilePath + "\\" + FileName);

                        if (fileExist == false)
                        {
                            SatbilityTest_Class_Obj.STP_Update_tblStabilityTestReminder();
                        }
                        
                    }
                    else
                    {

                        MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                  }
             }
              catch (Exception ex)
              {
                MessageBox.Show(ex.ToString());
              }
        }
    }
}