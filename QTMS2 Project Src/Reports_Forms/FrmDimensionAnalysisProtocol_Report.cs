using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QTMS.Tools;

namespace QTMS.Reports_Forms
{
    public partial class FrmDimensionAnalysisProtocol_Report : Form
    {
        public string rptName;
        public DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        DimensionParameter_Class DimensionParameter_Class_obj = new DimensionParameter_Class();
        BusinessFacade.Transactions.DimensionParaTransaction_Class DimensionParaTransaction_Class_obj = new BusinessFacade.Transactions.DimensionParaTransaction_Class();
        long PMTestNo, sizeQuantity;

        public FrmDimensionAnalysisProtocol_Report(long PMTestNo, long Quantity)
        {
            this.PMTestNo = PMTestNo;
            this.sizeQuantity = Quantity;
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
            {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                toolStrip1.Items.Add(rptName);
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
                //DimensionParameter_Class_obj.quantity = this.sizeQuantity;
                DimensionParameter_Class_obj.testNo = this.PMTestNo;

                DataTable dt = new DataTable();
                dt = DimensionParameter_Class_obj.STP_Select_DimensionObs_TestNo();
                Reports.DimensionAnalysisProtocol_Report DimensionAnalysisProtocol = new QTMS.Reports.DimensionAnalysisProtocol_Report();

                if (dt.Rows.Count > 0)
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

                    DimensionAnalysisProtocol.SetDataSource(dt);
                    ReportViewer.ReportSource = DimensionAnalysisProtocol;
                    ReportViewer.Show();
                }
                else
                {
                    MessageBox.Show("Sorry No record found!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

    }
}