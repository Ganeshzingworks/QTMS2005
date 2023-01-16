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
    public partial class FrmComplaint_TDB_Report : Form
    {
        public string rptName;
        public bool rptDisplayed = false;

        public FrmComplaint_TDB_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        # endregion


        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.Complaint_TDB_Report Complaint_TDB = new QTMS.Reports.Complaint_TDB_Report();
                DataSet ds = new DataSet();

                if (DtpDateFrom.Checked == true)
                {
                    Report_Class_Obj.fromdate = DtpDateFrom.Value.ToShortDateString();
                }
                else
                {
                    Report_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpDateTo.Checked == true)
                {
                    Report_Class_Obj.todate = DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    Report_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }


                switch (rptName)
                {
                    case "Complaint_TDB":
                        ds = Report_Class_Obj.Select_View_Complaint_TDB_Report();

                        break;
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ParameterFields param1Fields = new ParameterFields();

                    ParameterField FromDate = new ParameterField();
                    ParameterDiscreteValue FromDateDescrete = new ParameterDiscreteValue();
                    FromDate.Name = "FromDate";
                    FromDateDescrete.Value = DtpDateFrom.Value.ToShortDateString();
                    FromDate.CurrentValues.Add(FromDateDescrete);
                    param1Fields.Add(FromDate);

                    ParameterField ToDate = new ParameterField();
                    ParameterDiscreteValue ToDateDescrete = new ParameterDiscreteValue();
                    ToDate.Name = "ToDate";
                    ToDateDescrete.Value = DtpDateTo.Value.ToShortDateString();
                    ToDate.CurrentValues.Add(ToDateDescrete);
                    param1Fields.Add(ToDate);

                    ParameterField To = new ParameterField();
                    ParameterDiscreteValue ToDescrete = new ParameterDiscreteValue();
                    To.Name = "To";
                    ToDescrete.Value = txtTo.Text.Trim();
                    To.CurrentValues.Add(ToDescrete);
                    param1Fields.Add(To);

                    ParameterField CC = new ParameterField();
                    ParameterDiscreteValue CCDescrete = new ParameterDiscreteValue();
                    CC.Name = "CC";
                    CCDescrete.Value = txtCC.Text.Trim();
                    CC.CurrentValues.Add(CCDescrete);
                    param1Fields.Add(CC);

                    ParameterField FI = new ParameterField();
                    ParameterDiscreteValue FIDescrete = new ParameterDiscreteValue();
                    FI.Name = "FI";
                    FIDescrete.Value = txtFI.Text.Trim();
                    FI.CurrentValues.Add(FIDescrete);
                    param1Fields.Add(FI);

                    ReportViewer.ParameterFieldInfo = param1Fields;

                    switch (rptName)
                    {
                        case "Complaint_TDB":

                            Complaint_TDB.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = Complaint_TDB;
                            ReportViewer.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Sorry Record Not Found...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void FrmComplaint_TDB_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);


            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = DtpDateFrom.Value;
        }
    }
}