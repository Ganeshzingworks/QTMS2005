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
    public partial class Report_TDB : Form
    {
        public string rptName;

        public Report_TDB(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.SubContractor_Class.Report_SubContractor Report_SubContractor_Obj = new BusinessFacade.SubContractor_Class.Report_SubContractor();
        # endregion

        private void FrmReport_TDB_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;            

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
            rptName = "Global_FG_TDB";
            Painter.Paint(this);
        }            

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Visible = true;

                DataSet dsBulkTDB_Report_SubContract = new DataSet();
                if (DtpDateFrom.Checked == true)
                {
                    System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;
                    String fromdate = Convert.ToDateTime(DtpDateFrom.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");
                    Report_SubContractor_Obj.fromdate = fromdate;
                }
                else
                {
                    Report_SubContractor_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpDateTo.Checked == true)
                {
                    System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;
                    String todate = Convert.ToDateTime(DtpDateTo.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");
                    Report_SubContractor_Obj.todate = todate;
                    //                    Report_Class_Obj.todate = DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    Report_SubContractor_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }

                dsBulkTDB_Report_SubContract = Report_SubContractor_Obj.Select_VIEW_BulkTDB_Report_SubContract();

                if (dsBulkTDB_Report_SubContract.Tables[0].Rows.Count > 0)
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
                   
                    param1Fields.Add(FromDate);
                    param1Fields.Add(ToDate);
                    ReportViewer.ParameterFieldInfo = param1Fields;

                    QTMS.SubContracttor_Report.GlobalFGTDB_Report_Test GlobalFGTDB = new QTMS.SubContracttor_Report.GlobalFGTDB_Report_Test();
                    GlobalFGTDB.SetDataSource(dsBulkTDB_Report_SubContract.Tables[0]);
                    ReportViewer.ReportSource = GlobalFGTDB;
                    ReportViewer.Show();

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