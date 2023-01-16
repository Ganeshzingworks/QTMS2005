using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace QTMS.Reports_Forms
{
    public partial class FrmAgeingTest_Report : Form
    {
        public FrmAgeingTest_Report(string RptName)
        {
           this.rptName = RptName;
            InitializeComponent();
        }
      # region Varibles

        string rptName;
       BusinessFacade.Transactions.AgeingTest_Class AgeingTest_Class_Obj = new BusinessFacade.Transactions.AgeingTest_Class();
       QTMS.Reports.AgeingTest_Report AgeingTestReport = new QTMS.Reports.AgeingTest_Report();
      

        # endregion

        private void AgeingTest_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            QTMS.Tools.Painter.Paint(this);
            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            Bind_FormulaNo();
        }

        public void Bind_FormulaNo()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = AgeingTest_Class_Obj.SELECT_FormulaNo_For_AgeingTest_Report();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FMID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbFormulaNo.DataSource = ds.Tables[0];
            cmbFormulaNo.DisplayMember = "FormulaNo";
            cmbFormulaNo.ValueMember = "FMID";
        }


        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFormulaNo.SelectedValue == null || cmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Formula No..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                pictureBox1.Visible = true;
                DataSet ds = new DataSet();

                AgeingTest_Class_Obj.fmid = Convert.ToInt32(cmbFormulaNo.SelectedValue);

                switch (rptName)
                {
                    case "AgeingTest_Report":

                        ds = AgeingTest_Class_Obj.SELECT_View_AgeingTest_Report();

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
                        case "AgeingTest_Report":

                            AgeingTestReport.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = AgeingTestReport;
                            ReportViewer.Show();
                            break;
                    }
                }
                else
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                pictureBox1.Visible = false;
            }
            catch (Exception ex)
            {
                pictureBox1.Visible = false;
                MessageBox.Show(ex.Message);
            }
        }
    }
}