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
    public partial class FrmRM_Alignment_Report : Form
    {
        public FrmRM_Alignment_Report()
        {
            InitializeComponent();
        }
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        Reports.RM_Alignment_Report RM_AlignmentRpt_Obj = null;
        string Alignement ="";// null;
       // DataSet ds = null;
        private void FrmRM_Alignment_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            cmbAlignment.SelectedIndex = 0;
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAlignment.Text == "--Select--")
                {
                    MessageBox.Show("Please select the Alignment", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                
                RM_AlignmentRpt_Obj = new QTMS.Reports.RM_Alignment_Report();
                Report_Class_Obj.fromdate = DtpDateFrom.Value.ToShortDateString();
                Report_Class_Obj.todate = DtpDateTo.Value.ToShortDateString();
                DataSet ds = new DataSet();
               // ds = Report_Class_Obj.Select_View_RM_Alignment_Report();
                Alignement = cmbAlignment.Text;
                switch (Alignement)
                {
                    case "All":
                        ds = Report_Class_Obj.Select_View_RM_Alignment_Report();
                        break;
                    case "Aligned":
                        ds = Report_Class_Obj.Select_View_RM_Alignment_Report_Aligned();
                        break;
                    case "NotAligned":
                        ds = Report_Class_Obj.Select_View_RM_Alignment_Report_NotAligned();
                        break;
                }

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("No record Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReportViewer.ReportSource = null;
                    return;
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No record Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReportViewer.ReportSource = null;
                    return;
                }
                ds.Tables[0].TableName = "TableALignment";
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

                RM_AlignmentRpt_Obj.SetDataSource(ds);
                ReportViewer.ReportSource = RM_AlignmentRpt_Obj;
                ReportViewer.Show();
                ReportViewer.Refresh();
            }
            catch
            {
                throw;
            }
           
        }

        private void cmbAlignment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (cmbAlignment.Text == "All")
            //{
            //    Alignement = "All";
            //}
            //if (cmbAlignment.Text == "Aligned")
            //{
            //    Alignement = "Aligned";
            //}
            //if (cmbAlignment.Text == "NotAligned")
            //{
            //    Alignement = "NotAligned";
            //}
        }
    }
}