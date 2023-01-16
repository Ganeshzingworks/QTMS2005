using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QTMS.Tools;
//using Microsoft.ReportingServices.DataExtensions;


namespace QTMS.Reports_Forms
{
    public partial class FrmOEEAnalysis : Form
    {
        public string MfgWo;
        public string FormulaNo;
        private string rptName;
        private DataTable Dt;

        BusinessFacade.Transactions.OEEAct_CatRelation OEEAct_CatRelationObj = new BusinessFacade.Transactions.OEEAct_CatRelation();

        public FrmOEEAnalysis(string rptName)
        {
            this.rptName = rptName;
            InitializeComponent();
        }

        private void FrmProtocol_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                toolStrip1.Items.Add(rptName);
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

                Bind_TechFam();
                Bind_Vessel();
                cmbGroupBy.SelectedIndex = 0;

                rdoDetails.Checked = true;

                //if (rptName == "OEE Analysis Report")
                //{ 

                //}
                //else if (rptName == "OEE Summary Report")
                //{

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Bind_TechFam()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                BusinessFacade.BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BusinessFacade.BulkFamilyMaster_Class();
                ds = BulkFamilyMaster_Class_Obj.Select_BulkFamilyMaster();

                dr = ds.Tables[0].NewRow();
                dr["FamilyDesc"] = "--All--";
                dr["TechFamNo"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cmbTechFamily.DataSource = ds.Tables[0];
                cmbTechFamily.DisplayMember = "FamilyDesc";
                cmbTechFamily.ValueMember = "TechFamNo";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Bind_Vessel()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                BusinessFacade.VesselMaster_Class VesselMaster_Class_Obj = new BusinessFacade.VesselMaster_Class();
                ds = VesselMaster_Class_Obj.Select_tblVesselMaster();

                dr = ds.Tables[0].NewRow();
                dr["VslDesc"] = "--All--";
                dr["VesselNo"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cmbVessel.DataSource = ds.Tables[0];
                cmbVessel.DisplayMember = "VslDesc";
                cmbVessel.ValueMember = "VesselNo";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    pictureBox1.Visible = true;
                    Cursor.Current = Cursors.WaitCursor;
                    //Get all FMID wise records.
                    OEEAct_CatRelationObj.vesselno = Convert.ToInt64(cmbVessel.SelectedValue);
                    OEEAct_CatRelationObj.techfamno = Convert.ToInt64(cmbTechFamily.SelectedValue);
                    OEEAct_CatRelationObj.monthwise = rdoMonthWise.Checked;


                    //////if (rdoMonthWise.Checked)
                    //////{
                    //////    DataTable Dt2 = new DataTable();
                    //////    Dt2 = OEEAct_CatRelationObj.Select_Report_OEEMFGActivityDetails_Analysis();
                    //////    Reports.OEEAnalysisReport_MonthWise ObjReport = new QTMS.Reports.OEEAnalysisReport_MonthWise();
                    //////    ObjReport.SetDataSource(Dt2);
                    //////    ReportViewer.ReportSource = ObjReport;

                    //////    ReportViewer.Show();
                    //////    return;
                    //////}

                    if (rdbDailyPUR.Checked)
                    {
                        Dt = OEEAct_CatRelationObj.Select_Report_OEEMFGActivityDetails_Analysis2__DailyPUR();
                    }
                    else
                        Dt = OEEAct_CatRelationObj.Select_Report_OEEMFGActivityDetails_Analysis2();
                    //The fields taken as Batch size in STP are not considered   
                    //They are just for crystal report convinience
                    if (Dt.Rows.Count > 0)
                    {
                        DataTable DtActivity = new DataTable();
                        //Get list of active activities from tbl activity master
                        DtActivity = OEEAct_CatRelationObj.Select_ActivityMaster();

                        //Add Activities as columnname to each FMID wise records from detail tbl
                        for (int i = 0; i < DtActivity.Rows.Count; i++)
                        {
                            if (Dt.Columns.Contains(DtActivity.Rows[i][0].ToString().Trim()))
                            {
                            }
                            else//Activity not in detail tbl but in activity master
                            {
                                Dt.Columns.Add(DtActivity.Rows[i][0].ToString().Trim(), "System.Int64".GetType());
                            }
                        }

                        //Set time for each FMID and activity compbination
                        for (int i = 0; i < Dt.Rows.Count; i++)//loop for FMID
                        {
                            OEEAct_CatRelationObj.fmid = Convert.ToInt64(Dt.Rows[i]["FMID"]);
                            for (int j = 0; j < DtActivity.Rows.Count; j++)//loop for activities
                            {
                                OEEAct_CatRelationObj.Activity = DtActivity.Rows[j][0].ToString().Trim();
                                //Get sum of time and set as details
                                Dt.Rows[i][OEEAct_CatRelationObj.Activity] = OEEAct_CatRelationObj.Get_OEEMFGActivityDetails_ActivityTime();
                            }
                        }

                        #region Category wise calculations
                        if (Dt.Columns.Contains("Total waitaing") || Dt.Columns.Contains("total Manufacturing time") || Dt.Columns.Contains("Std Processing Time") || Dt.Columns.Contains("Processing time") || Dt.Columns.Contains("total Occupation time"))
                        {

                        }
                        else
                        {
                            Dt.Columns.Add("Total waitaing", "System.Int64".GetType());
                            Dt.Columns.Add("total Manufacturing time", "System.Int64".GetType());
                            Dt.Columns.Add("Std Processing Time", "System.Int64".GetType());//from TechFamTMTmaster
                            Dt.Columns.Add("Processing time", "System.Int64".GetType());
                            Dt.Columns.Add("total Occupation time", "System.Int64".GetType());
                        }
                        DataTable DtCategories = new DataTable();
                        DtCategories = OEEAct_CatRelationObj.Select_OEECategoryMaster();

                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            BusinessFacade.Transactions.OEETransactionTest_Class OEETransactionTest_Class_Obj = new BusinessFacade.Transactions.OEETransactionTest_Class();
                            OEEAct_CatRelationObj.fmid = Convert.ToInt64(Dt.Rows[i]["FMID"]);

                            //Waiting time 
                            OEEAct_CatRelationObj.Category = DtCategories.Rows[3][1].ToString().Trim();
                            Dt.Rows[i]["Total waitaing"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();

                            //TManufacrng Time
                            OEEAct_CatRelationObj.Category = DtCategories.Rows[0][1].ToString().Trim();
                            Dt.Rows[i]["total Manufacturing time"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();

                            //Std time //from TechFamTMTmaster
                            OEETransactionTest_Class_Obj.techFamNo = Convert.ToInt64(Dt.Rows[i]["TechFamNo"]);
                            OEETransactionTest_Class_Obj.batchsize = Convert.ToInt64(Dt.Rows[i]["BatchSize"]);

                            Dt.Rows[i]["Std Processing Time"] = OEETransactionTest_Class_Obj.Select_OEETechFamTMTMaster_TMT();

                            //TPT
                            OEEAct_CatRelationObj.Category = DtCategories.Rows[1][1].ToString().Trim();
                            Dt.Rows[i]["Processing time"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();

                            //TOT
                            OEEAct_CatRelationObj.Category = DtCategories.Rows[2][1].ToString().Trim();
                            Dt.Rows[i]["total Occupation time"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();
                        }
                        #endregion

                        if (rdbDailyPUR.Checked)
                        {
                            ParameterFields param1Fields = new ParameterFields();

                            ParameterField RptDate = new ParameterField();
                            ParameterDiscreteValue RptDateDescrete = new ParameterDiscreteValue();
                            RptDate.Name = "RptDate";
                            RptDateDescrete.Value = Dt.Rows[0]["startedOn"].ToString();
                            RptDate.CurrentValues.Add(RptDateDescrete);
                            param1Fields.Add(RptDate);

                            ParameterField CYear = new ParameterField();
                            ParameterDiscreteValue CYearDescrete = new ParameterDiscreteValue();
                            CYear.Name = "CYear";
                            CYearDescrete.Value = "B" + Dt.Rows[0]["CYear"].ToString();
                            CYear.CurrentValues.Add(CYearDescrete);
                            param1Fields.Add(CYear);

                            ReportViewer.ParameterFieldInfo = param1Fields;
                            //Reports.test OEEAnalysisReportObj = new QTMS.Reports.test();
                            Reports.OEEReportAnalysis_DailyPUR OEEAnalysisReportObj = new QTMS.Reports.OEEReportAnalysis_DailyPUR();

                            OEEAnalysisReportObj.SetDataSource(Dt);
                            ReportViewer.ReportSource = OEEAnalysisReportObj;

                        }
                        else if (rdoDetails.Checked)
                        {
                            //Reports.OEEAnalysisReport OEEAnalysisReportObj = new QTMS.Reports.OEEAnalysisReport();
                            Reports.OEEAnalysisReport2 OEEAnalysisReportObj = new QTMS.Reports.OEEAnalysisReport2();

                            OEEAnalysisReportObj.SetDataSource(Dt);
                            ReportViewer.ReportSource = OEEAnalysisReportObj;

                        }
                        else if (rdoSummary.Checked && cmbGroupBy.SelectedIndex == 1)
                        {
                            // Reports.OEEAnalysisReport_GroupFamily ObjReport = new QTMS.Reports.OEEAnalysisReport_GroupFamily();
                            Reports.OEEAnalysisReport_GroupFamily2 ObjReport = new QTMS.Reports.OEEAnalysisReport_GroupFamily2();
                            //OEEAnalysisReport_GroupFamily2.rpt;
                            ObjReport.SetDataSource(Dt);
                            ReportViewer.ReportSource = ObjReport;
                        }
                        else if (rdoSummary.Checked && cmbGroupBy.SelectedIndex == 2)
                        {
                            //Reports.OEEAnalysisReport_GroupVessel ObjReport = new QTMS.Reports.OEEAnalysisReport_GroupVessel();
                            Reports.OEEAnalysisReport_GroupVessel2 ObjReport = new QTMS.Reports.OEEAnalysisReport_GroupVessel2();
                            ObjReport.SetDataSource(Dt);
                            ReportViewer.ReportSource = ObjReport;
                        }
                        else if (rdoSummary.Checked && cmbGroupBy.SelectedIndex == 3)
                        {
                            //Reports.OEEAnalysisReport_GroupFamilyVessel ObjReport = new QTMS.Reports.OEEAnalysisReport_GroupFamilyVessel();
                            Reports.OEEAnalysisReport_GroupFamilyVessel2 ObjReport = new QTMS.Reports.OEEAnalysisReport_GroupFamilyVessel2();
                            ObjReport.SetDataSource(Dt);
                            ReportViewer.ReportSource = ObjReport;
                        }
                        else if (rdoMonthWise.Checked)
                        {
                            //DataTable Dt2 = new DataTable();
                            // Dt2 = OEEAct_CatRelationObj.Select_Report_OEEMFGActivityDetails_Analysis();
                            //Reports.OEEAnalysisReport_MonthWise ObjReport = new QTMS.Reports.OEEAnalysisReport_MonthWise();
                            Reports.OEEAnalysisReport_MonthWise_New ObjReport = new QTMS.Reports.OEEAnalysisReport_MonthWise_New();



                            ObjReport.SetDataSource(Dt);
                            ReportViewer.ReportSource = ObjReport;
                        }
                        ReportViewer.Show();
                        pictureBox1.Visible = false;
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        pictureBox1.Visible = false;
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("No Record found");
                    }
                }
            }
            catch (Exception ex)
            {
                pictureBox1.Visible = false;
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsValid()
        {
            try
            {
                if (rdbDailyPUR.Checked)
                {
                    if (DtpDateFrom.Checked)
                    {
                        OEEAct_CatRelationObj.StartDate = DtpDateFrom.Value.ToShortDateString();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Please select from date");
                        return false;
                    }
                }
                else if (rdoMonthWise.Checked)//Validation for monthwise report
                {
                    if (DtpDateFrom.Checked && DtpDateTo.Checked)
                    {
                        if (DtpDateFrom.Value.Year != DtpDateTo.Value.Year)
                        {
                            MessageBox.Show("The year for from and to date should be same");
                            DtpDateFrom.Focus();
                            return false;
                        }

                        //if (DtpDateFrom.Value.Month > DtpDateTo.Value.Month)
                        //{
                        //    MessageBox.Show("End month should be gretter than start month");
                        //    DtpDateTo.Focus();
                        //    return false;
                        //}
                        if (DtpDateFrom.Value.Month != DtpDateTo.Value.Month)
                        {
                            MessageBox.Show("End month should be same mounth as start month");
                            DtpDateTo.Focus();
                            return false;
                        }
                        OEEAct_CatRelationObj.StartDate = DtpDateFrom.Value.ToShortDateString();
                        OEEAct_CatRelationObj.EndDate = DtpDateTo.Value.ToShortDateString();
                    }
                    else
                    {
                        MessageBox.Show("Please select both from and to month");
                        return false;
                    }
                    return true;
                }
                else //Validation for details and summary report
                {
                    if (DtpDateFrom.Checked && DtpDateTo.Checked)
                    {
                        if (DtpDateFrom.Value > DtpDateTo.Value)
                        {
                            MessageBox.Show("End date should be gretter than start date.");
                            return false;
                        }
                    }

                    if (DtpDateFrom.Checked == true)
                    {
                        OEEAct_CatRelationObj.StartDate = DtpDateFrom.Value.ToShortDateString();
                    }
                    else
                    {
                        OEEAct_CatRelationObj.StartDate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                    }

                    if (DtpDateTo.Checked == true)
                    {
                        OEEAct_CatRelationObj.EndDate = DtpDateTo.Value.ToShortDateString();
                    }
                    else
                    {
                        OEEAct_CatRelationObj.EndDate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                    }

                    if (rdoSummary.Checked && cmbGroupBy.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please select group by for summary report");
                        cmbGroupBy.Focus();
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void rdoDetails_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDetails.Checked)
            {
                cmbGroupBy.Visible = false;
                lblGroupBy.Visible = false;
                DtpDateFrom.CustomFormat = "dd-MMM-yyyy";
                DtpDateTo.CustomFormat = "dd-MMM-yyyy";
            }
            else if (rdoMonthWise.Checked)
            {
                cmbGroupBy.Visible = false;
                lblGroupBy.Visible = false;
                DtpDateFrom.CustomFormat = "MMM-yyyy";
                DtpDateTo.CustomFormat = "MMM-yyyy";
            }
            else
            {
                cmbGroupBy.Visible = true;
                lblGroupBy.Visible = true;
                DtpDateFrom.CustomFormat = "dd-MMM-yyyy";
                DtpDateTo.CustomFormat = "dd-MMM-yyyy";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbGroupBy.SelectedIndex = 0;
            rdoDetails.Checked = true;
            cmbTechFamily.SelectedIndex = 0;
            cmbVessel.SelectedIndex = 0;
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
        }

        private void rdoSummary_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSummary.Checked)
            {
                cmbGroupBy.Visible = true;
                lblGroupBy.Visible = true;
            }
            else
            {
                cmbGroupBy.Visible = false;
                lblGroupBy.Visible = false;
            }
        }

        private void rdbDailyPUR_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDailyPUR.Checked)
            {
                cmbGroupBy.Visible = false;
                lblGroupBy.Visible = false;
                DtpDateFrom.CustomFormat = "dd-MMM-yyyy";
                DtpDateTo.CustomFormat = "dd-MMM-yyyy";

                label2.Visible = false;
                DtpDateTo.Visible = false;
            }
            else if (rdoDetails.Checked)
            {
                cmbGroupBy.Visible = false;
                lblGroupBy.Visible = false;
                DtpDateFrom.CustomFormat = "dd-MMM-yyyy";
                DtpDateTo.CustomFormat = "dd-MMM-yyyy";

                label2.Visible = true;
                DtpDateTo.Visible = true;
            }
            else if (rdoMonthWise.Checked)
            {
                cmbGroupBy.Visible = false;
                lblGroupBy.Visible = false;
                DtpDateFrom.CustomFormat = "MMM-yyyy";
                DtpDateTo.CustomFormat = "MMM-yyyy";

                label2.Visible = true;
                DtpDateTo.Visible = true;
            }
            else
            {
                cmbGroupBy.Visible = true;
                lblGroupBy.Visible = true;
                DtpDateFrom.CustomFormat = "dd-MMM-yyyy";
                DtpDateTo.CustomFormat = "dd-MMM-yyyy";

                label2.Visible = true;
                DtpDateTo.Visible = true;
            }
        }

        



    }
}