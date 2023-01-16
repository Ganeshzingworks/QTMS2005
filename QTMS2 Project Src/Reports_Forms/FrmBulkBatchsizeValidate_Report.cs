using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using CrystalDecisions.Shared;
using System.IO;
using System.Management;
using System.Reflection;

namespace QTMS.Reports_Forms
{
    public partial class FrmBulkBatchsizeValidate_Report : Form
    {
        public FrmBulkBatchsizeValidate_Report()
        {
            InitializeComponent();
        }
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        private void FrmBulkBatchsizeValidate_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            CmbFormulaType.Text = "<--Select-->";
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {

            



            if (CmbFormulaType.Text == "<--Select-->")
            {
                MessageBox.Show("Select Formula Type...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CmbFormulaType.Focus();
                return;
            }


            if (DtpDateFrom.Checked == true)
            {
                System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

                String fromdate = Convert.ToDateTime(DtpDateFrom.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");

                Report_Class_Obj.fromdate = fromdate;
            }
            else
            {
                Report_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
            }

            if (DtpDateTo.Checked == true)
            {

                System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

                String todate = Convert.ToDateTime(DtpDateTo.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");

                Report_Class_Obj.todate = todate;
                //                    Report_Class_Obj.todate = DtpDateTo.Value.ToShortDateString();
            }
            else
            {
                Report_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
            }

            pictureBox1.Visible = true;
            DataSet ds = new DataSet();

            Report_Class_Obj.formulatype = CmbFormulaType.Text;

            ds = Report_Class_Obj.Select_Bulk_ValidatedNonValidated();
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
                ParaFields.Add(FromDate);
                ParaFields.Add(ToDate);

                ParameterField FormulaType = new ParameterField();
                ParameterDiscreteValue FormulaTypeDescrete = new ParameterDiscreteValue();
                FormulaType.Name = "FormulaType";
                FormulaTypeDescrete.Value = CmbFormulaType.Text;
                FormulaType.CurrentValues.Add(FormulaTypeDescrete);
                ParaFields.Add(FormulaType);


                ReportViewer.ParameterFieldInfo = ParaFields;

                Reports.BulkValidateNonValidate FinishedGoodTest = null;

                FinishedGoodTest = new QTMS.Reports.BulkValidateNonValidate();
                FinishedGoodTest.SetDataSource(ds.Tables[0]);
                ReportViewer.ReportSource = FinishedGoodTest;
                ReportViewer.Show();
            }
            else
            {
                pictureBox1.Visible = false;
                MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            pictureBox1.Visible = false;
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}