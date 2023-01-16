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
    public partial class FrmFGRefSampleMgmtReport : Form
    {
        public string rptName;

        public FrmFGRefSampleMgmtReport(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
        BusinessFacade.FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new BusinessFacade.FormulaNoMaster_Class();

        Reports.FG_RefSampleMgmt FGRefSamleMgmt = new QTMS.Reports.FG_RefSampleMgmt();
        //Reports.ATestReport FGRefSamleMgmt = new QTMS.Reports.ATestReport();
        # endregion

        private void FrmFGRefSampleMgmtReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();            
            Bind_Formula();
            
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

              

                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                
                Report_Class_Obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
               
                switch (rptName)
                {
                    case "FG RSMgmt Detail Report":
                        ds = Report_Class_Obj.Select_RSMgmtDetails_Fno_Report();

                        ds1 = Report_Class_Obj.Select_Bulk_Analysis_Report();
                        break;
                }


                if (ds.Tables[0].Rows.Count > 0)
                {                  

                    switch (rptName)
                    {
                        case "FG RSMgmt Detail Report":

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

                            FGRefSamleMgmt.SetDataSource(ds.Tables[0]);
                            FGRefSamleMgmt.Subreports["Analysis_Report"].SetDataSource(ds1.Tables[0]);
                            ReportViewer.ReportSource = FGRefSamleMgmt;
                            ReportViewer.ShowGroupTreeButton = false;
                            ReportViewer.DisplayGroupTree = false;
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