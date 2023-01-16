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
    public partial class FrmPMCodeDescriptionReport : Form
    {
        public FrmPMCodeDescriptionReport()
        {

            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        QTMS.Reports.PMCodeDescription_Report PMCodeDescription = new QTMS.Reports.PMCodeDescription_Report();
        # endregion


        private void FrmPending_RMReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            toolStrip1.Items.Add("PM Code Description Report");
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
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
                ds = Report_Class_Obj.Select_View_PMCodeDescription_Report();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    PMCodeDescription.SetDataSource(ds.Tables[0]);
                    ReportViewer.ReportSource = PMCodeDescription;
                    ReportViewer.Show();
                }
                else
                    MessageBox.Show("Sorry No Record Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

    }
}