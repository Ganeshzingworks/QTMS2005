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
    public partial class FrmRMCode_Report : Form
    {
        public FrmRMCode_Report(string RptName)
        {
            InitializeComponent();
            this.rptName = RptName;

        }
        string rptName;
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.RSMgmtTransaction_Class RSMgmtTransaction_Class_obj = new BusinessFacade.Transactions.RSMgmtTransaction_Class(); 

        Reports.RM_Report RMCodeReport = new QTMS.Reports.RM_Report();
        Reports.RM_RefSampleMgmt RMRefSample = new QTMS.Reports.RM_RefSampleMgmt();
        private void BtnShow_Click(object sender, EventArgs e)
        {
             try
            {
                if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select RMCode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                Report_Class_Obj.rmcodeid = Convert.ToInt32(cmbDetails.SelectedValue);

                switch (rptName)
                {
                    case "RM_Report":
                        ds = Report_Class_Obj.Select_View_RMCodeHistory_Report();                        
                        break;
                    case "RM RSMgmt Detail Report":
                        ds = Report_Class_Obj.Select_RMRSMgmtDetails_RMCodeID_Report();
                        ds1 = Report_Class_Obj.Select_RM_Analysis_Report();
                        break;
                }
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
                    switch (rptName)
                    {
                        case "RM_Report":

                            RMCodeReport.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = RMCodeReport;
                            ReportViewer.Show();
                            break;
                        case "RM RSMgmt Detail Report":
                            RMRefSample.SetDataSource(ds.Tables[0]);
                            RMRefSample.Subreports["RM_Analysis_Report"].SetDataSource(ds1.Tables[0]);
                            ReportViewer.ReportSource = RMRefSample;
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

        private void FrmRMCode_Report_Load(object sender, EventArgs e)
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
            ds = Report_Class_Obj.Select_tblRMCodeMaster();
            dr = ds.Tables[0].NewRow();
            dr["RMCode"] = "--Select--";
            dr["RMCodeID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbDetails.DataSource = ds.Tables[0];
            cmbDetails.DisplayMember = "RMCode";
            cmbDetails.ValueMember = "RMCodeID";
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}