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
    public partial class FrmPMTestMethodMaster_Report : Form
    {
        public FrmPMTestMethodMaster_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles

        string rptName;
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.PMFamilyMaster_Class PMFamilyMaster_Class_Obj = new BusinessFacade.PMFamilyMaster_Class();
        Reports.PMTestMethodMaster_Report PMTestMethodMaster = new QTMS.Reports.PMTestMethodMaster_Report();

        # endregion

        private void FrmFGTestMethodMaster_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      

            Bind_Details();
        }

        public void Bind_Details()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = PMFamilyMaster_Class_Obj.Select_PMFamilyMaster();
            dr = ds.Tables[0].NewRow();
            dr["PMFamilyName"] = "--Select--";
            dr["PMFamilyID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbDetails.DataSource = ds.Tables[0];
            cmbDetails.DisplayMember = "PMFamilyName";
            cmbDetails.ValueMember = "PMFamilyID";
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Packing Family..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet ds = new DataSet();

                Report_Class_Obj.pmfamilyid = Convert.ToInt32(cmbDetails.SelectedValue);

                switch (rptName)
                {
                    case "PMTestMethodMasterReport":

                        ds = Report_Class_Obj.SELECT_View_PMTestMethodMaster_Report();

                        break;
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ParameterFields paramFields = new ParameterFields();

                    #region Company Name & Address

                    ParameterField CompanyName = new ParameterField();
                    ParameterDiscreteValue CompanyNameDescrete = new ParameterDiscreteValue();
                    CompanyName.Name = "CompanyName";
                    CompanyNameDescrete.Value = GlobalVariables.companyName;
                    CompanyName.CurrentValues.Add(CompanyNameDescrete);
                    paramFields.Add(CompanyName);

                    ParameterField CompanyAddress = new ParameterField();
                    ParameterDiscreteValue CompanyAddressDiscrete = new ParameterDiscreteValue();
                    CompanyAddress.Name = "CompanyAddress";
                    CompanyAddressDiscrete.Value = GlobalVariables.companyAddress;
                    CompanyAddress.CurrentValues.Add(CompanyAddressDiscrete);
                    paramFields.Add(CompanyAddress);

                    #endregion

                    ReportViewer.ParameterFieldInfo = paramFields;
                    switch (rptName)
                    {
                        case "PMTestMethodMasterReport":

                            PMTestMethodMaster.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = PMTestMethodMaster;
                            ReportViewer.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}