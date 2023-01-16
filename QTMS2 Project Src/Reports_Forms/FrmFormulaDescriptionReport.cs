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
    public partial class FrmFormulaDescriptionReport : Form
    {
        public FrmFormulaDescriptionReport()
        {

            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        QTMS.Reports.FormulaDescription_Report FormulaDescription = new QTMS.Reports.FormulaDescription_Report(); 
        # endregion


        private void FrmPending_RMReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            pictureBox1.Visible = true;
            toolStrip1.Items.Add("Formula Description Report");
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
            try
            {
                DataSet ds = new DataSet();
                ds = Report_Class_Obj.Select_View_FormulaDescription_Report();
                if (ds.Tables[0].Rows.Count > 0)
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

                    FormulaDescription.SetDataSource(ds.Tables[0]);
                    ReportViewer.ReportSource = FormulaDescription;
                    ReportViewer.Show();
                }
                else
                    MessageBox.Show("Sorry No Record Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pictureBox1.Visible = false;

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