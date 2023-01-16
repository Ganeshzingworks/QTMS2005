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
    public partial class FRM_RM_CodeReport2 : Form
    {
        public FRM_RM_CodeReport2()
        {
            InitializeComponent();
        }

        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        Reports.RM_CodeReport RM_CodeReportRpt_Obj = new QTMS.Reports.RM_CodeReport();

        private void FRM_RM_CodeReport2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            Bind_Details();
        }

        private void Bind_Details()
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

        private void toolStripButtonClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void BtnShow_Click(object sender, System.EventArgs e)
        {
            try
            {
               // ReportViewer.RefreshReport();
                if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select RMCode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DtpDateFrom.Checked)
                {
                    MessageBox.Show("Please select the From Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
                if (!DtpDateTo.Checked)
                {
                    MessageBox.Show("Please select the to Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataSet ds = new DataSet();
                Report_Class_Obj.rmcodeid = Convert.ToInt32(cmbDetails.SelectedValue);
                Report_Class_Obj.fromdate = DtpDateFrom.Value.ToShortDateString();
                Report_Class_Obj.todate = DtpDateTo.Value.ToShortDateString();
                ds = Report_Class_Obj.Select_View_RMCodeHistory_Report2();
                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("No record found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReportViewer.ReportSource = null;
                    return;
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No record found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReportViewer.ReportSource = null;
                    return;
                }
                #region Set Paramter

                //RM_AlignmentRpt_Obj.SetParameterValue("CompanyName", GlobalVariables.companyName);
                //RM_AlignmentRpt_Obj.SetParameterValue("CompanyAddress", GlobalVariables.companyAddress);
                //RM_AlignmentRpt_Obj.SetParameterValue("FromDate", DtpDateFrom.Value.ToShortDateString());
                //RM_AlignmentRpt_Obj.SetParameterValue("ToDate", DtpDateTo.Value.ToShortDateString());


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
                #endregion

                RM_CodeReportRpt_Obj.SetDataSource(ds.Tables[0]);
                ReportViewer.ReportSource = RM_CodeReportRpt_Obj;
                ReportViewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}