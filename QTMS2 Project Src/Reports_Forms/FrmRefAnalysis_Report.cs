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


namespace QTMS.Reports_Forms
{
    public partial class FrmRefAnalysis_Report : Form
    {
        public string rptName;
        public long fmid;
        public int rmsamplingid;

        public FrmRefAnalysis_Report(string RptName,long FMID)
        {
            this.rptName = RptName;
            this.fmid = FMID;
            InitializeComponent();
        }
        public FrmRefAnalysis_Report(string RptName, int RMSamplingID)
        {
            this.rptName = RptName;
            this.rmsamplingid = RMSamplingID;
            InitializeComponent();
        }
        # region Varibles

        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();

        Reports.Bulk_Analysis_Report Bulk_Analysis = new QTMS.Reports.Bulk_Analysis_Report();
        Reports.RM_Analysis_Report RM_Analysis = new QTMS.Reports.RM_Analysis_Report();
        # endregion

        private void FrmRefAnalysis_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
            switch (rptName)
            {
                case "BulkAnalysis":
                    Report_Class_Obj.fmid = fmid;
                    DataSet ds = new DataSet();
                    ds = Report_Class_Obj.Select_VIEW_Bulk_Analysis_Report();

                    string ProtocolNo = "BLK" + Convert.ToString(Report_Class_Obj.fmid).PadLeft(6, '0');

                    toolStrip1.Items.Add(rptName);
                    toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

                    ParameterFields ParaFields = new ParameterFields();

                    ParameterField ParaProtocolNo = new ParameterField();
                    ParameterDiscreteValue ProtocolNoDiscrete = new ParameterDiscreteValue();
                    ParaProtocolNo.Name = "ProtocolNo";
                    ProtocolNoDiscrete.Value = ProtocolNo;
                    ParaProtocolNo.CurrentValues.Add(ProtocolNoDiscrete);
                    ParaFields.Add(ParaProtocolNo);

                    #region CompanyName and Address
                    ParameterField CompanyName = new ParameterField();
                    ParameterDiscreteValue CompanyNameDescrete = new ParameterDiscreteValue();
                    CompanyName.Name = "CompanyName";
                    CompanyNameDescrete.Value = GlobalVariables.companyName;
                    CompanyName.CurrentValues.Add(CompanyNameDescrete);
                    ParaFields.Add(CompanyName);

                    ParameterField CompanyAddress = new ParameterField();
                    ParameterDiscreteValue CompanyAddressDescrete = new ParameterDiscreteValue();
                    CompanyAddress.Name = "CompanyAddress";
                    CompanyAddressDescrete.Value = GlobalVariables.companyAddress;
                    CompanyAddress.CurrentValues.Add(CompanyAddressDescrete);
                    ParaFields.Add(CompanyAddress);
                    #endregion

                    ReportViewer.ParameterFieldInfo = ParaFields;

                    Bulk_Analysis.SetDataSource(ds.Tables[0]);
                    ReportViewer.ReportSource = Bulk_Analysis;
                    ReportViewer.ShowGroupTreeButton = false;
                    ReportViewer.DisplayGroupTree = false;
                    ReportViewer.Show();
                    break;
                case "RM_Analysis":
                    DataTable dt1 = new DataTable();
                    DataSet dsRM = new DataSet();
                    Report_Class_Obj.rmsamplingid = rmsamplingid;

                    string RMProtocolNo = "RM" + Convert.ToString(Report_Class_Obj.rmsamplingid).PadLeft(6, '0');

                    toolStrip1.Items.Add(rptName);
                    toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

                    dsRM = Report_Class_Obj.Select_View_RM_Analysis_Report();
                    dt1 = Report_Class_Obj.Select_View_RM_Analysis_Phy_Report();

                    ParameterFields RMParaFields = new ParameterFields();
                    ParameterField RMParaProtocolNo = new ParameterField();
                    ParameterDiscreteValue RMProtocolNoDiscrete = new ParameterDiscreteValue();
                    RMParaProtocolNo.Name = "ProtocolNo";
                    RMProtocolNoDiscrete.Value = RMProtocolNo;
                    RMParaProtocolNo.CurrentValues.Add(RMProtocolNoDiscrete);
                    RMParaFields.Add(RMParaProtocolNo);

                    #region CompanyName and Address
                    ParameterField RMCompanyName = new ParameterField();
                    ParameterDiscreteValue RMCompanyNameDescrete = new ParameterDiscreteValue();
                    RMCompanyName.Name = "CompanyName";
                    RMCompanyNameDescrete.Value = GlobalVariables.companyName;
                    RMCompanyName.CurrentValues.Add(RMCompanyNameDescrete);
                    RMParaFields.Add(RMCompanyName);

                    ParameterField RMCompanyAddress = new ParameterField();
                    ParameterDiscreteValue RMCompanyAddressDescrete = new ParameterDiscreteValue();
                    RMCompanyAddress.Name = "CompanyAddress";
                    RMCompanyAddressDescrete.Value = GlobalVariables.companyAddress;
                    RMCompanyAddress.CurrentValues.Add(RMCompanyAddressDescrete);
                    RMParaFields.Add(RMCompanyAddress);
                    #endregion

                    ReportViewer.ParameterFieldInfo = RMParaFields;

                    RM_Analysis.SetDataSource(dsRM.Tables[0]);
                    RM_Analysis.Subreports[0].SetDataSource(dt1);
                    ReportViewer.ReportSource = RM_Analysis;
                    ReportViewer.ShowGroupTreeButton = false;
                    ReportViewer.DisplayGroupTree = false;
                    ReportViewer.Show();
                    break;
            }
            
            

            
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
       

    }
}