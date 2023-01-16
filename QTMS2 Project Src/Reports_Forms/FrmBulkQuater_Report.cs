using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using CrystalDecisions.Shared;

namespace QTMS.Reports_Forms
{
    public partial class FrmBulkQuater_Report : Form
    {
        public FrmBulkQuater_Report()
        {
            InitializeComponent();
        }
        BusinessFacade.Transactions.Report_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.Report_Class();

        private void FrmBulkQuater_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            dtpDate.Value = DateTime.Now;
            cmbTest.Text = "<--Select-->";
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            if (cmbTest.Text == "<--Select-->")
            {
                MessageBox.Show("Select Quater !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbTest.Focus();
                return;
            }
            string SatrtDate = "", EndDate = "";
            string year = dtpDate.Value.Year.ToString();

            if (cmbTest.Text == "Quater - 1")
            {
                SatrtDate = "01/01/" + year;
                EndDate = "03/31/" + year;
            }
            else if (cmbTest.Text == "Quater - 2")
            {
                SatrtDate = "04/01/" + year;
                EndDate = "06/30/" + year;
            }
            else if (cmbTest.Text == "Quater - 3")
            {
                SatrtDate = "07/01/" + year;
                EndDate = "09/30/" + year;
            }
            else if (cmbTest.Text == "Quater - 4")
            {
                SatrtDate = "10/01/" + year;
                EndDate = "12/31/" + year;
            }

            BulktestDetailstransaction_Class_Qbj.fromdate = SatrtDate;
            BulktestDetailstransaction_Class_Qbj.todate = EndDate;

            DataSet Ds = new DataSet();
            Ds = BulktestDetailstransaction_Class_Qbj.Select_Bulk_BatchCode_Report();

            Reports.BulkQuater_Report BulkQuater_Report = new QTMS.Reports.BulkQuater_Report();
            if (Ds.Tables[0].Rows.Count > 0)
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

                ParameterField FromDate = new ParameterField();
                ParameterField ToDate = new ParameterField();
                ParameterDiscreteValue FromDateDescrete = new ParameterDiscreteValue();
                ParameterDiscreteValue ToDateDescrete = new ParameterDiscreteValue();
                FromDate.Name = "FromDate";
                FromDateDescrete.Value = SatrtDate;
                FromDate.CurrentValues.Add(FromDateDescrete);

                ToDate.Name = "ToDate";
                ToDateDescrete.Value = EndDate;
                ToDate.CurrentValues.Add(ToDateDescrete);

                ParaFields.Add(FromDate);
                ParaFields.Add(ToDate);

                ReportViewer.ParameterFieldInfo = ParaFields;



                BulkQuater_Report.SetDataSource(Ds.Tables[0]);
                ReportViewer.ReportSource = BulkQuater_Report;
                ReportViewer.Show();



            }
        }
    }
}