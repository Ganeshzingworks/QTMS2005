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
    public partial class FrmBulkTestReport : Form
    {
        public string rptName;

        public FrmBulkTestReport(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
        BusinessFacade.FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new BusinessFacade.FormulaNoMaster_Class();

        Reports.BulkTest_Report BulkTest = new QTMS.Reports.BulkTest_Report();
        # endregion

        private void FrmReport_Bulk_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();            
            Bind_Formula();
            Bind_Test();
        }

        public void Bind_Formula()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = BulktestDetailstransaction_Class_Qbj.Select_tblTransFM_tblBulkTestTransaction();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbFormulaNo.DataSource = ds.Tables[0];
            cmbFormulaNo.DisplayMember = "FormulaNo";
            cmbFormulaNo.ValueMember = "FNo";
        }

        public void Bind_Test()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = BulktestDetailstransaction_Class_Qbj.Select_tbltestmaster_IdentificationTest_ControlTest();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            dr["TestNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbTest.DataSource = ds.Tables[0];
            cmbTest.DisplayMember = "Details";
            cmbTest.ValueMember = "TestNo";
        }             

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula No...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbFormulaNo.Focus();
                    return;
                }                

                if (cmbTest.Text == "--Select--")
                {
                    MessageBox.Show("Select Test...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbFormulaNo.Focus();
                    return;
                }
                pictureBox1.Visible = true;
                DataSet ds = new DataSet();
                
                Report_Class_Obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                Report_Class_Obj.testno = Convert.ToInt32(cmbTest.SelectedValue);

                switch (rptName)
                {
                    case "BulkTest":
                        ds = Report_Class_Obj.Select_VIEW_BulkTest_Report();
                        break;
                }


                if (ds.Tables[0].Rows.Count > 0)
                {                    
                    switch (rptName)
                    {
                        case "BulkTest":

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

                            BulkTest.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = BulkTest;
                            ReportViewer.ShowGroupTreeButton = false;
                            ReportViewer.DisplayGroupTree = false;
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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        




    }
}