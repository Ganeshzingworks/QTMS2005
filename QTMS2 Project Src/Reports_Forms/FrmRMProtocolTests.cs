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
    public partial class FrmRMProtocolTests : Form
    {
        public string MethodType;
        public DataTable dt = new DataTable();
        public DataTable dtpres = new DataTable();
        
        public FrmRMProtocolTests(string MethodType, DataTable dt, DataTable dtpres)
        {

            this.MethodType = MethodType;
            this.dt = dt;
            this.dtpres = dtpres;

            InitializeComponent();

        }

        private void FrmRMProtocolTests_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

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
                if (this.MethodType == "R" || this.MethodType == "F")
                {
                    Reports.RMProtocol_Phy_Report RMProtocolPhy = new QTMS.Reports.RMProtocol_Phy_Report();

                    RMProtocolPhy.SetDataSource(dt);
                    RMProtocolPhy.Subreports["RMProtocol_Pres_Report"].SetDataSource(dtpres);
                    ReportViewer.ReportSource = RMProtocolPhy;
                    ReportViewer.Show();
                }
                else if (this.MethodType == "D")
                {
                    Reports.RMProtocol_FDA_Report RMProtocolFDA = new QTMS.Reports.RMProtocol_FDA_Report();
                    RMProtocolFDA.SetDataSource(dt);
                    RMProtocolFDA.Subreports["RMProtocol_FDA_Pres_Report"].SetDataSource(dtpres);
                    ReportViewer.ReportSource = RMProtocolFDA;
                    ReportViewer.Show();
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