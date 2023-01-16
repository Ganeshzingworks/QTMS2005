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
using BusinessFacade;


namespace QTMS.Reports_Forms
{
    public partial class Report : Form
    {
        public string rptName;

        public Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        # endregion

        private void FrmLotDossier_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
            if (rptName == "LinePacking" || rptName == "LineSampling" || rptName == "LineSamplingSummary" || rptName == "FinishedGoodTest" || rptName == "FinishedGoodSummary" || rptName == "FinishedGood_NonBPC")
            {
                rdoNonScoop.Visible = true;
                rdoScoop.Visible = true;
                rdoAll.Visible = true;
                lblManuby.Visible = false;
                cmbManuBy.Visible = false;
            }
            else if(rptName=="GlobalFGTDB")
            {
                lblManuby.Visible = true;
                cmbManuBy.Visible = true;
                Bind_ManufacturedBy();
            }
            else
            {
                lblManuby.Visible = false;
                cmbManuBy.Visible = false;
            }
            Painter.Paint(this);
        }

        private void Bind_ManufacturedBy()
        {
            try
            {
                LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
                DataSet ds = LineMaster_Class_Obj.Select_Manufacturer();
                DataRow dr1 = ds.Tables[0].NewRow();
                dr1["ManufacturedById"] = "3";
                dr1["ManufacturerName"] = "All";
                ds.Tables[0].Rows.InsertAt(dr1, 0);

                //DataRow dr = ds.Tables[0].NewRow();
                //dr["ManufacturedById"] = ds.Tables[0].Rows.Count + 1;
                //dr["ManufacturerName"] = "ALL";
                //ds.Tables[0].Rows.InsertAt(dr, ds.Tables[0].Rows.Count);
                cmbManuBy.DataSource = ds.Tables[0];
                cmbManuBy.DisplayMember = "ManufacturerName";
                cmbManuBy.ValueMember = "ManufacturedById";
            }
            catch (Exception)
            {
                MessageBox.Show("Record Not Found");
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Visible = true;

                Reports.AOC_Report AOC = null;
                Reports.FGDeclerationLot_Report DeclarationLotNo = null;
                QTMS.OOS.RptOOSLog OOSLog = null;
                Reports.PMDue_Report PMDue = null;
                Reports.FinishedGoodDue_Report FGDue = null;
                Reports.RMDue_Report RMDue = null;
                Reports.FinishedGoodTransaction_Report FinishedGoodTest = null;
                //Reports.FinishedGoodTDB_Report FinishedGoodTDB = new QTMS.Reports.FinishedGoodTDB_Report();
                Reports.Global_FG_TDB_Report GlobalFGTDB = null;
                Reports.FG_LineDetails_TDB_Report FG_LineDetails_TDB = null;
                Reports.FillingPackingQuality_Report FillingPackingQuality = null;
                Reports.FinishedGoodSummary_Report FinishedGoodSummary = null;
                Reports.FinishedGood_NonBPC_Report FinishedGood_NonBPC = null;
                Reports.LineSamplingSummary_Report LineSamplingSummary = null;
                Reports.lineSampling1_Report LineSampling = null;
                Reports.LinePacking_Report LinePacking = null;
                Reports.BulkTestDetail_Report BulkTestDetail = null;// new QTMS.Reports.BulkTestDetail_Report();
                Reports.BulkTest_NonBPC_Report BulkTest_NonBPC = null;
                Reports.BulkTransaction_Report BulkTransaction = null;
                Reports.BulkTDB_Report BulkTDB = null;
                Reports.PreservativeTest_Summary_Report PreservativeTest_Summary = null;
                Reports.MicrobiologyTest_Report MicrobiologyTest = null;
                Reports.MicrobiologyTDB_Report MicrobiologyTDB = null;
                Reports.RMTransaction_Report RMTransaction = null;
               // Reports.RM_Family_TDB_Report RMTDB = null;
                Reports.RM_Family_TDB_Report2 RMTDB = null;
                Reports.RM_Supplier_TDB_Report RM_Supplier_TDB = null;
                Reports.RMValidity_Analysis_Report RMValidity_Analysis = null;
                Reports.PMTransaction_Report PMTransaction = null;
                Reports.PMRejection_Detail_Report PMRejection_Detail = null;
                Reports.PMDefectNoteDetail_Report PMDefectNote_Detail = null;
                Reports.PM_TDB_Report PM_TDB = null;
                Reports.PM_Supplier_TDB_Report PM_Supplier_TDB = null;
                Reports.PM_Family_TDB_Report PM_Family_TDB = null;
                Reports.PM_COCList_Report PM_COCList = null;
                Reports.ComplaintSummary_Report ComplaintSummary = null;
                Reports.BMRPreSummary_Report BMRPreSummary = null;
                Reports.RMPending_Report RMPending = null;
                Reports.QStatus_Report QStatus = null;
                Reports.FG_Report FG_Report = null;
                Reports.Bulk_Pending_Report Bulk_Pending = null;
                Reports.FG_Pending_Bulk_Report FGBulk_Pending = null;
                Reports.BulkTest_NewLaunch_Report BulkTest_NewLaunch = null;
                Reports.BulkTest_NonValidated_Report BulkTest_NonValidated = null;
                Reports.PM_NewLaunch_Report PM_NewLaunch = null;
                Reports.PM_SupplierReportReceived_Report PM_SupplierReportReceived = null;
                Reports.Analysis_Summary_Report Analysis_Summary = null;
                Reports.RM_SupplierReportReceived_Report RM_SupplierReportReceived = null;
                Reports.PM_COC_Transaction_Report PM_COC_Transaction = null;
                //Reports.FGRetainerSampleLocation_Report Retainer_Location = null;
                Reports.RSMgmtSummary_Report RSMgmtSummary = null;
                Reports.PMRejection_Detail_Report_New PMDetailsReportNew = null;
                Reports.rptFGRefMgmtSummaryReport FGRefMgmt = null;
                Reports.DestructionSummary_Report Destructed = null;

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();


                if (DtpDateFrom.Checked == true)
                {
                    System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

                    String fromdate = Convert.ToDateTime(DtpDateFrom.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");

                    Report_Class_Obj.fromdate = fromdate;
                }
                else
                {
                    Report_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpDateTo.Checked == true)
                {

                    System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

                    String todate = Convert.ToDateTime(DtpDateTo.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");

                    Report_Class_Obj.todate = todate;
                    //                    Report_Class_Obj.todate = DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    Report_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }
                if (rptName == "GlobalFGTDB")
                {
                    //if (cmbManuBy.SelectedIndex==0)
                    //{
                    //    MessageBox.Show("Please Select Manufactured By", "Warning", MessageBoxButtons.OK);
                    //    cmbManuBy.Focus();
                    //    return;
                    //}
                    //else
                    {
                        Report_Class_Obj.ManufacturedById = Convert.ToInt32(cmbManuBy.SelectedValue);
                    }
                }

                switch (rptName)
                {

                    case "FinishedGoodTest":
                     

                        if (rdoAll.Checked)
                            ds = Report_Class_Obj.Select_VIEW_FinishedGoodTest_Reports();
                        else if (rdoNonScoop.Checked)
                            ds = Report_Class_Obj.Select_NonScoopVIEW_FinishedGoodTest_Reports();
                        else
                            ds = Report_Class_Obj.Select_ScoopVIEW_FinishedGoodTest_Reports();
                        break;


                    case "GlobalFGTDB":
                        ds = Report_Class_Obj.Select_VIEW_Global_FG_TDB_Report();
                        break;

                    case "FG_LineDetails_TDB":
                        ds = Report_Class_Obj.Select_VIEW_FG_LineDetails_TDB_Report();
                        break;

                    case "FillingPackingQuality":
                        ds = Report_Class_Obj.Select_VIEW_Filling_Packing_Quality_Report();
                        break;

                    case "FinishedGoodSummary":
                        ds = Report_Class_Obj.Select_View_FinishedGoodSummary_Report();
                        if (rdoAll.Checked)
                            ds = Report_Class_Obj.Select_View_FinishedGoodSummary_Report();
                        else if (rdoNonScoop.Checked)
                            ds = Report_Class_Obj.Select_NonScoop_View_FinishedGoodSummary_Report();
                        else
                            ds = Report_Class_Obj.Select_Scoop_View_FinishedGoodSummary_Report();
                        break;
                    case "FinishedGood_NonBPC":

                        if (rdoAll.Checked)
                            ds = Report_Class_Obj.Select_View_FinishedGood_NonBPC_Report();
                        else if (rdoNonScoop.Checked)
                            ds = Report_Class_Obj.Select_NonScoop_View_FinishedGood_NonBPC_Report();
                        else
                            ds = Report_Class_Obj.Select_Scoop_View_FinishedGood_NonBPC_Report();
                        break;

                    case "LineSamplingSummary":

                        if (rdoAll.Checked)
                            ds = Report_Class_Obj.Select_VIEW_LineSamplingSummary_Reports();
                        else if (rdoNonScoop.Checked)
                            ds = Report_Class_Obj.Select_NonScoop_VIEW_LineSamplingSummary_Reports();
                        else
                            ds = Report_Class_Obj.Select_Scoop_VIEW_LineSamplingSummary_Reports();
                        break;
                        

                    case "LineSampling":
                        ds = Report_Class_Obj.Select_VIEW_LineSampling_Reports();
                        break;

                    case "LinePacking":
                        if (rdoAll.Checked)
                            ds = Report_Class_Obj.Select_VIEW_LinePacking_Reports();
                        else if (rdoNonScoop.Checked)
                            ds = Report_Class_Obj.Select_NonScoop_VIEW_LinePacking_Reports();
                        else
                            ds = Report_Class_Obj.Select_Scoop_VIEW_LinePacking_Reports();
                        break;

                    case "BulkTestDetail":
                        ds = Report_Class_Obj.Select_VIEW_BulkTestDetailReport();
                        break;

                    case "BulkTest_NonBPC":
                        ds = Report_Class_Obj.Select_View_BulkTest_NonBPC_Report();
                        break;

                    case "BulkTest_NewLaunch":
                        ds = Report_Class_Obj.Select_View_BulkTest_NewLaunch_Report();
                        break;

                    case "BulkTest_NonValidated":
                        ds = Report_Class_Obj.Select_View_BulkTest_NonValidated_Report();
                        break;

                    case "BulkTransaction":
                        ds = Report_Class_Obj.Select_VIEW_BulkTransaction_Report();
                        break;

                    case "BulkTDB":
                        ds = Report_Class_Obj.Select_VIEW_BulkTDB_Report();
                        break;

                    case "PreservativeTest_Summary":
                        ds = Report_Class_Obj.Select_VIEW_PreservativeTest_Reports();
                        break;

                    case "MicrobiologyTest":
                        ds = Report_Class_Obj.Select_VIEW_MicrobiologyTest_Reports();
                        break;

                    case "MicrobiologyTDB":
                        ds = Report_Class_Obj.Select_VIEW_MicrobiologyTDB_Reports();
                        break;

                    case "RMTransaction":
                        ds = Report_Class_Obj.Select_VIEW_RMTransaction_Reports();
                        break;

                    case "RM_SupplierReportReceived":
                        ds = Report_Class_Obj.Select_View_RM_SupplierReportReceived_Report();
                        break;

                    case "RMTDB":
                        ds = Report_Class_Obj.Select_VIEW_RMTDB_Reports();
                        break;

                    case "RM_Supplier_TDB":
                        ds = Report_Class_Obj.Select_VIEW_RM_Supplier_TDB_Report();
                        break;

                    case "RMValidity_Analysis":
                        ds = Report_Class_Obj.Select_View_RMValidity_Analysis_Report();
                        break;

                    case "RMPending":
                        ds = Report_Class_Obj.Select_View_PendingRM_Report();
                        break;

                    case "PMTransaction":
                        ds = Report_Class_Obj.Select_View_PMTransaction_Report();
                        break;

                    case "PM_NewLaunch":
                        ds = Report_Class_Obj.Select_View_PM_NewLaunch_Report();
                        break;

                    case "PM_SupplierReportReceived":
                        ds = Report_Class_Obj.Select_View_PM_SupplierReportReceived_Report();
                        break;

                    case "PMRejection_Detail":
                        ds = Report_Class_Obj.Select_View_PMRejectionDetail_Report_PMStatus();
                        //ds = Report_Class_Obj.Select_View_PMRejectionDetail_Report();
                        break;
                    //
                    case "PMRejection_Detail_Report_New":
                        //ds = Report_Class_Obj.Select_View_PMRejectionDetail_Report_PMStatus();
                        ds = Report_Class_Obj.Select_View_PMRejectionDetail_Report();
                        break;
                    //
                    case "PMDefectNote_Detail":
                        ds = Report_Class_Obj.Select_PMDefectNoteDetail_Report();
                        break;
                    case "PM_TDB":
                        ds = Report_Class_Obj.Select_View_PM_TDB_Report();
                        break;

                    case "PM_Supplier_TDB": // same as PM TDB
                        ds = Report_Class_Obj.Select_View_PM_TDB_Report();
                        break;

                    case "PM_Family_TDB": // same as PM TDB
                        ds = Report_Class_Obj.Select_View_PM_TDB_Report();
                        break;

                    case "PM_COCList":
                        ds = Report_Class_Obj.Select_View_PM_COCList_Report();
                        break;

                    case "PM_COC_Transaction":
                        ds = Report_Class_Obj.Select_View_PM_COC_Transaction_Report();
                        break;

                    case "ComplaintSummary":
                        ds = Report_Class_Obj.Select_View_ComplaintSummary_Report();
                        break;

                    case "BMRPreSummary":
                        ds = Report_Class_Obj.Select_View_BMR_PreSummary_Report();
                        break;

                    case "QStatus":
                        ds = Report_Class_Obj.Select_VIEW_PreLotDossier_Report_QStatus();
                        break;

                    case "FG_Report":
                        ds = Report_Class_Obj.Select_VIEW_LotDossier_Report_FG();
                        break;

                    case "Bulk_Pending":
                        //ds = Report_Class_Obj.Select_VIEW_Pending_Bulk_Report();
                        ds = Report_Class_Obj.Select_VIEW_Pending_FGBulk_Report();
                        break;

                    case "FGBulk_Pending":
                        ds = Report_Class_Obj.Select_VIEW_Pending_FGBulk_Report();
                        break;

                    case "Analysis_Summary":
                        ds = Report_Class_Obj.Select_VIEW_Analysis_Summary_Report();
                        break;
                    case "Retainer Sample Location":
                        ds = Report_Class_Obj.Select_RetainerSampleLocation_Report();
                        break;
                    case "RSMgmt_Summary":
                        ds = Report_Class_Obj.Select_RSMgmtSummary_Reports();
                        break;

                    case "FGMgmt_Summary":
                        ds = Report_Class_Obj.Select_FGRefMgmtTransaction_Reports();
                        break;

                    case "AOC_Report":
                        ds = Report_Class_Obj.Select_AOC_File_Reports();
                        break;

                    case "OOS_Log_Report":
                        ds = Report_Class_Obj.Select_OOS_LogReport();
                        break;

                    case "FinishedGoodDue":
                        ds = Report_Class_Obj.Select_VIEW_FinishedGoodDue_Reports();
                        break;

                    case "RMDue":
                        Report_Class_Obj.status = "ALL";
                        ds = Report_Class_Obj.Select_RMTransaction_Reports();
                        break;
                    case "PMDue":
                        ds = Report_Class_Obj.Select_VIEW_PMDue_Reports();
                        break;
                    case "DestructedLocation":
                        ds = Report_Class_Obj.Select_View_tblLocationDistruction_SummaryReport();
                        break;
                    case "DeclarationLotNo":
                        ds = Report_Class_Obj.Select_FGDecleration_Report();
                        break;
                }


                if (ds.Tables[0].Rows.Count > 0)
                {
                    ParameterFields param1Fields = new ParameterFields();
                    ParameterField FromDate = new ParameterField();
                    ParameterField ToDate = new ParameterField();
                    ParameterDiscreteValue FromDateDescrete = new ParameterDiscreteValue();
                    ParameterDiscreteValue ToDateDescrete = new ParameterDiscreteValue();
                    FromDate.Name = "FromDate";
                    if (DtpDateFrom.Checked == true)
                    {
                        FromDateDescrete.Value = DtpDateFrom.Value.ToShortDateString();
                    }
                    else
                    {
                        FromDateDescrete.Value = "";
                    }
                    FromDate.CurrentValues.Add(FromDateDescrete);

                    ToDate.Name = "ToDate";
                    if (DtpDateTo.Checked == true)
                    {
                        ToDateDescrete.Value = DtpDateTo.Value.ToShortDateString();
                    }
                    else
                    {
                        ToDateDescrete.Value = "";
                    }
                    ToDate.CurrentValues.Add(ToDateDescrete);

                    #region CompanyName and Address
                    ParameterField CompanyName = new ParameterField();
                    ParameterDiscreteValue CompanyNameDescrete = new ParameterDiscreteValue();
                    CompanyName.Name = "CompanyName";
                    CompanyNameDescrete.Value = GlobalVariables.companyName;
                    CompanyName.CurrentValues.Add(CompanyNameDescrete);
                    param1Fields.Add(CompanyName);

                    ParameterField CompanyAddress = new ParameterField();
                    ParameterDiscreteValue CompanyAddressDescrete = new ParameterDiscreteValue();
                    CompanyAddress.Name = "CompanyAddress";
                    CompanyAddressDescrete.Value = GlobalVariables.companyAddress;
                    CompanyAddress.CurrentValues.Add(CompanyAddressDescrete);
                    param1Fields.Add(CompanyAddress);                  

                    #endregion
                    if (rptName.Equals("GlobalFGTDB",StringComparison.CurrentCultureIgnoreCase))
                    {
                        ParameterField ManuBy = new ParameterField();
                        ParameterDiscreteValue ManuByDescrete = new ParameterDiscreteValue();
                        ManuBy.Name = "ManufacturedBy";
                        
                        if (Convert.ToInt32(cmbManuBy.SelectedValue)<3)
                        {
                            ManuByDescrete.Value = cmbManuBy.Text.Trim();    
                        }
                        else
                        {
                            ManuByDescrete.Value = "";
                        }
                        ManuBy.CurrentValues.Add(ManuByDescrete);
                        param1Fields.Add(ManuBy);
                    }
                    param1Fields.Add(FromDate);
                    param1Fields.Add(ToDate);
                    ReportViewer.ParameterFieldInfo = param1Fields;

                    switch (rptName)
                    {

                        case "FinishedGoodTest":
                            FinishedGoodTest = new QTMS.Reports.FinishedGoodTransaction_Report();
                            FinishedGoodTest.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = FinishedGoodTest;
                            ReportViewer.Show();
                            break;


                        case "GlobalFGTDB":
                            GlobalFGTDB = new QTMS.Reports.Global_FG_TDB_Report();
                            GlobalFGTDB.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = GlobalFGTDB;
                            ReportViewer.Show();
                            break;

                        case "FG_LineDetails_TDB":
                            FG_LineDetails_TDB = new QTMS.Reports.FG_LineDetails_TDB_Report();
                            FG_LineDetails_TDB.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = FG_LineDetails_TDB;
                            ReportViewer.Show();
                            break;

                        case "FillingPackingQuality":
                            FillingPackingQuality = new QTMS.Reports.FillingPackingQuality_Report();
                            FillingPackingQuality.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = FillingPackingQuality;
                            ReportViewer.Show();
                            break;

                        case "FinishedGoodSummary":
                            FinishedGoodSummary = new QTMS.Reports.FinishedGoodSummary_Report();
                            FinishedGoodSummary.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = FinishedGoodSummary;
                            ReportViewer.Show();
                            break;

                        case "FinishedGood_NonBPC":
                            FinishedGood_NonBPC = new QTMS.Reports.FinishedGood_NonBPC_Report();
                            FinishedGood_NonBPC.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = FinishedGood_NonBPC;
                            ReportViewer.Show();
                            break;

                        case "LineSamplingSummary":
                            LineSamplingSummary = new QTMS.Reports.LineSamplingSummary_Report();
                            LineSamplingSummary.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = LineSamplingSummary;
                            ReportViewer.Show();
                            break;

                        case "LineSampling":
                            LineSampling = new QTMS.Reports.lineSampling1_Report();
                            LineSampling.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = LineSampling;
                            ReportViewer.Show();
                            break;

                        case "LinePacking":
                            LinePacking = new QTMS.Reports.LinePacking_Report();
                            LinePacking.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = LinePacking;
                            ReportViewer.Show();
                            break;

                        case "BulkTestDetail":
                            BulkTestDetail = new QTMS.Reports.BulkTestDetail_Report();
                            BulkTestDetail.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = BulkTestDetail;
                            ReportViewer.Show();
                            break;

                        case "BulkTest_NonBPC":
                            BulkTest_NonBPC = new QTMS.Reports.BulkTest_NonBPC_Report();
                            BulkTest_NonBPC.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = BulkTest_NonBPC;
                            ReportViewer.Show();
                            break;

                        case "BulkTest_NewLaunch":
                            BulkTest_NewLaunch = new QTMS.Reports.BulkTest_NewLaunch_Report();
                            BulkTest_NewLaunch.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = BulkTest_NewLaunch;
                            ReportViewer.Show();
                            break;

                        case "BulkTest_NonValidated":
                            BulkTest_NonValidated = new QTMS.Reports.BulkTest_NonValidated_Report();
                            BulkTest_NonValidated.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = BulkTest_NonValidated;
                            ReportViewer.Show();
                            break;

                        case "BulkTransaction":
                            BulkTransaction = new QTMS.Reports.BulkTransaction_Report();
                            BulkTransaction.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = BulkTransaction;
                            ReportViewer.Show();
                            break;

                        case "BulkTDB":
                            BulkTDB = new QTMS.Reports.BulkTDB_Report();
                            BulkTDB.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = BulkTDB;
                            ReportViewer.Show();
                            break;

                        case "PreservativeTest_Summary":
                            PreservativeTest_Summary = new QTMS.Reports.PreservativeTest_Summary_Report();
                            PreservativeTest_Summary.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PreservativeTest_Summary;
                            ReportViewer.Show();
                            break;

                        case "MicrobiologyTest":
                            MicrobiologyTest = new QTMS.Reports.MicrobiologyTest_Report();
                            MicrobiologyTest.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = MicrobiologyTest;
                            ReportViewer.Show();
                            break;

                        case "MicrobiologyTDB":
                            MicrobiologyTDB = new QTMS.Reports.MicrobiologyTDB_Report();
                            MicrobiologyTDB.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = MicrobiologyTDB;
                            ReportViewer.Show();
                            break;

                        case "RMTransaction":
                            RMTransaction = new QTMS.Reports.RMTransaction_Report();
                            RMTransaction.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = RMTransaction;
                            ReportViewer.Show();
                            break;

                        case "RM_SupplierReportReceived":
                            RM_SupplierReportReceived = new QTMS.Reports.RM_SupplierReportReceived_Report();
                            RM_SupplierReportReceived.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = RM_SupplierReportReceived;
                            ReportViewer.Show();
                            break;

                        case "RMTDB":
                            RMTDB = new QTMS.Reports.RM_Family_TDB_Report2(); //new QTMS.Reports.RM_Family_TDB_Report();
                            RMTDB.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = RMTDB;
                            ReportViewer.Show();
                            break;

                        case "RM_Supplier_TDB":
                            RM_Supplier_TDB = new QTMS.Reports.RM_Supplier_TDB_Report();
                            RM_Supplier_TDB.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = RM_Supplier_TDB;
                            ReportViewer.Show();
                            break;

                        case "RMValidity_Analysis":
                            RMValidity_Analysis = new QTMS.Reports.RMValidity_Analysis_Report();
                            RMValidity_Analysis.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = RMValidity_Analysis;
                            ReportViewer.Show();
                            break;

                        case "RMPending":
                            RMPending = new QTMS.Reports.RMPending_Report();
                            RMPending.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = RMPending;
                            ReportViewer.Show();
                            break;

                        case "PMTransaction":
                            PMTransaction = new QTMS.Reports.PMTransaction_Report();
                            PMTransaction.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PMTransaction;
                            ReportViewer.Show();
                            break;

                        case "PM_NewLaunch":
                            PM_NewLaunch = new QTMS.Reports.PM_NewLaunch_Report();
                            PM_NewLaunch.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PM_NewLaunch;
                            ReportViewer.Show();
                            break;

                        case "PM_SupplierReportReceived":
                            PM_SupplierReportReceived = new QTMS.Reports.PM_SupplierReportReceived_Report();
                            PM_SupplierReportReceived.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PM_SupplierReportReceived;
                            ReportViewer.Show();
                            break;

                        case "PMRejection_Detail":
                            PMRejection_Detail = new QTMS.Reports.PMRejection_Detail_Report();
                            PMRejection_Detail.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PMRejection_Detail;
                            ReportViewer.Show();
                            break;
                        case "PMDefectNote_Detail":
                            PMDefectNote_Detail = new QTMS.Reports.PMDefectNoteDetail_Report();
                            PMDefectNote_Detail.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PMDefectNote_Detail;
                            ReportViewer.Show();
                            break;
                        //
                        case "PMRejection_Detail_Report_New":
                            PMDetailsReportNew = new QTMS.Reports.PMRejection_Detail_Report_New();
                            PMDetailsReportNew.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PMDetailsReportNew;
                            ReportViewer.Show();
                            break;
                        //
                        case "PM_TDB":
                            PM_TDB = new QTMS.Reports.PM_TDB_Report();
                            PM_TDB.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PM_TDB;
                            ReportViewer.Show();
                            break;

                        case "PM_Supplier_TDB":
                            PM_Supplier_TDB = new QTMS.Reports.PM_Supplier_TDB_Report();
                            PM_Supplier_TDB.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PM_Supplier_TDB;
                            ReportViewer.Show();
                            break;

                        case "PM_Family_TDB":
                            PM_Family_TDB = new QTMS.Reports.PM_Family_TDB_Report();
                            PM_Family_TDB.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PM_Family_TDB;
                            ReportViewer.Show();
                            break;

                        case "PM_COCList":
                            PM_COCList = new QTMS.Reports.PM_COCList_Report();
                            PM_COCList.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PM_COCList;
                            ReportViewer.Show();
                            break;

                        case "PM_COC_Transaction":
                            //Report_Class_Obj.fromAnalysisReanalysis = 0;
                            //DataSet dsPMAnaRpt = Report_Class_Obj.Select_View_PM_Analysis_Report();
                            PM_COC_Transaction = new QTMS.Reports.PM_COC_Transaction_Report();
                            PM_COC_Transaction.SetDataSource(ds.Tables[0]);
                            //if(ds.Tables[0].Rows.Count>0)
                            //{
                            //    PM_COC_Transaction.Subreports["PMAnalysis_Report"].SetDataSource(dsPMAnaRpt.Tables[0]);
                            //}
                            ReportViewer.ReportSource = PM_COC_Transaction;
                            ReportViewer.Show();
                            break;

                        case "ComplaintSummary":
                            ComplaintSummary = new QTMS.Reports.ComplaintSummary_Report();
                            ComplaintSummary.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = ComplaintSummary;
                            ReportViewer.Show();
                            break;

                        case "BMRPreSummary":
                            BMRPreSummary = new QTMS.Reports.BMRPreSummary_Report();
                            BMRPreSummary.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = BMRPreSummary;
                            ReportViewer.Show();
                            break;

                        case "QStatus":
                            QStatus = new QTMS.Reports.QStatus_Report();
                            QStatus.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = QStatus;
                            ReportViewer.Show();
                            break;

                        case "FG_Report":
                            FG_Report = new QTMS.Reports.FG_Report();
                            FG_Report.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = FG_Report;
                            ReportViewer.Show();
                            break;

                        case "Bulk_Pending":
                            Bulk_Pending = new QTMS.Reports.Bulk_Pending_Report();
                            Bulk_Pending.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = Bulk_Pending;
                            ReportViewer.Show();
                            break;

                        case "FGBulk_Pending":
                            FGBulk_Pending = new QTMS.Reports.FG_Pending_Bulk_Report();
                            FGBulk_Pending.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = FGBulk_Pending;
                            ReportViewer.Show();
                            break;

                        case "Analysis_Summary":
                            Analysis_Summary = new QTMS.Reports.Analysis_Summary_Report();
                            Analysis_Summary.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = Analysis_Summary;
                            ReportViewer.Show();
                            break;
                        case "RSMgmt_Summary":
                            RSMgmtSummary = new QTMS.Reports.RSMgmtSummary_Report();
                            RSMgmtSummary.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = RSMgmtSummary;
                            ReportViewer.Show();
                            break;
                        case "FGMgmt_Summary":
                            FGRefMgmt = new QTMS.Reports.rptFGRefMgmtSummaryReport();
                            FGRefMgmt.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = FGRefMgmt;
                            ReportViewer.Show();
                            break;

                        case "AOC_Report":
                            AOC = new QTMS.Reports.AOC_Report();
                            AOC.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = AOC;
                            ReportViewer.Show();
                            break;

                        case "OOS_Log_Report":
                            OOSLog = new QTMS.OOS.RptOOSLog();
                            OOSLog.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = OOSLog;
                            ReportViewer.Show();
                            break;

                        case "FinishedGoodDue":
                            FGDue = new QTMS.Reports.FinishedGoodDue_Report();
                            FGDue.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = FGDue;
                            ReportViewer.Show();
                            break;

                        case "RMDue":
                            RMDue = new QTMS.Reports.RMDue_Report();
                            RMDue.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = RMDue;
                            ReportViewer.Show();
                            break;

                        case "PMDue":
                            PMDue = new QTMS.Reports.PMDue_Report();
                            PMDue.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PMDue;
                            ReportViewer.Show();
                            break;

                        case "DestructedLocation":
                            Destructed = new QTMS.Reports.DestructionSummary_Report();
                            Destructed.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = Destructed;
                            ReportViewer.Show();
                            break;

                        case "DeclarationLotNo":
                            DeclarationLotNo = new QTMS.Reports.FGDeclerationLot_Report();
                            DeclarationLotNo.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = DeclarationLotNo;
                            ReportViewer.Show();
                            break;


                        //case "Retainer Sample Location":
                        //    Retainer_Location = new QTMS.Reports.FGRetainerSampleLocation_Report();
                        //    Retainer_Location.SetDataSource(ds.Tables[0]);
                        //    ReportViewer.ReportSource = Retainer_Location;
                        //    ReportViewer.Show();
                        //    break;
                        //case "OEE Detail Process Report":
                        //    OEEDetailProcessReport = new QTMS.Reports.OEEDetailedProcessing_Report();
                        //    OEEDetailProcessReport.SetDataSource(dt);
                        //    ReportViewer.ReportSource = OEEDetailProcessReport;
                        //    ReportViewer.Show();
                        //    break;
                    }
                    pictureBox1.Visible = false;
                }
                else
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }



            }
            catch (Exception ex)
            {
                pictureBox1.Visible = false;
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}