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
using BusinessFacade.Transactions;
using System.Data.SqlClient;

namespace QTMS.Reports_Forms
{
    public partial class FrmLastProductionFormulaReport : Form
    {
       
        public DataTable dt = new DataTable();

        public FrmLastProductionFormulaReport()
        {            
            InitializeComponent();
        }

        private void FrmLastProductionFormulaReport_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                toolStrip1.Items.Add("Last Production Formula Report");
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connectionstring"]);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 0;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "STP_Select_FormulaReport_LastProduction";
                cmd.Connection = con;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpt.Fill(ds);


                Reports.LastProductionFormulaReport LastProductionFormulaReport_Obj = new QTMS.Reports.LastProductionFormulaReport();
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

                    LastProductionFormulaReport_Obj.SetDataSource(ds.Tables[0]);

                    ReportViewer.ReportSource = LastProductionFormulaReport_Obj;
                    ReportViewer.Show();
                }
                else
                {
                    ReportViewer.ReportSource = null;
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