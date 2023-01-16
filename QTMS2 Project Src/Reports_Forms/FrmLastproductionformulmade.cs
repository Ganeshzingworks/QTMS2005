using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using QTMS.Tools;

namespace QTMS.Reports_Forms
{
    public partial class FrmLastproductionformulmade : Form
    {
        public FrmLastproductionformulmade()
        {
            InitializeComponent();
        }
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        Reports.Made_LastProduction_Formula LastProductionFormulaReport = new QTMS.Reports.Made_LastProduction_Formula();
        private void FrmLastproductionformulmade_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);


            DataSet ds = new DataSet();
            ds = Report_Class_Obj.Select_Made_LastProduction_Formula();

            if (ds.Tables[0].Rows.Count > 0)
            {

                ParameterFields ParaFields = new ParameterFields();

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


                LastProductionFormulaReport.SetDataSource(ds.Tables[0]);
                ReportViewer.ReportSource = LastProductionFormulaReport;
                ReportViewer.Show();
            }
            else
            {
                MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}