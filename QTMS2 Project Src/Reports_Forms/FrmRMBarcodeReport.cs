using CrystalDecisions.Shared;
using QTMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QTMS.Reports_Forms
{
    public partial class FrmRMBarcodeReport : Form
    {
        public FrmRMBarcodeReport(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        string rptName;
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();

        Reports.RMBarcodeChecker RMBarcodeReport = new QTMS.Reports.RMBarcodeChecker();

        #endregion

        private void FrmRMBarcodeReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            dtpFromDate.Value = dtpToDate.Value = DateTime.Now;
            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
                {
                    MessageBox.Show("Please select valid from date to date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    BindLineTransactionReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindLineTransactionReport()
        {
            try
            {
                ParameterFields param1Fields = new ParameterFields();
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

                ReportViewer.ParameterFieldInfo = param1Fields;
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                ds = Report_Class_Obj.Select_RMBarcodeChecker_Report(dtpFromDate.Value, dtpToDate.Value);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    RMBarcodeReport.SetDataSource(ds.Tables[0]);
                    ReportViewer.ReportSource = RMBarcodeReport;
                    ReportViewer.Show();
                }
                else
                {
                    MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static FrmRMBarcodeReport frm = null;
        public static FrmRMBarcodeReport GetInstance(string RptName)
        {
            if (frm == null)
            {
                frm = new FrmRMBarcodeReport(RptName);
            }
            return frm;
        }
    }
}
