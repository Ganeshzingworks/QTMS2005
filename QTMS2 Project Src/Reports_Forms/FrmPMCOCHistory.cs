using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade.Transactions;
using QTMS.Reports;
using CrystalDecisions.Shared;

namespace QTMS.Reports_Forms
{
    public partial class FrmPMCOCHistory : Form
    {

        public string rptName;
        public FrmPMCOCHistory(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();            
        }

        PMTransaction_Class PMTransaction_Class_obj1 = new PMTransaction_Class();
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();

        private void FrmPMCOCHistory_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            
            Bind_Details();

            CmbDetails.Focus();
        }

        private void Bind_Details()
        {

            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                //ds = PMTransaction_Class_obj1.Select_PMCodeMaster_PMSupplierMaster_PMSupplierCOC();
                ds = PMTransaction_Class_obj1.Select_PMCodeMaster_PMSupplierMaster_PMSupplierCOC_Report();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["PMSupplierCOCID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                CmbDetails.DataSource = ds.Tables[0];
                CmbDetails.DisplayMember = "Details";
                CmbDetails.ValueMember = "PMSupplierCOCID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet ds = new DataSet();

                long PMsuppliercocid = Convert.ToInt64(CmbDetails.SelectedValue);
                Report_Class_Obj.pmsuppliercoid = PMsuppliercocid;
                DataSet dsPMTrans = Report_Class_Obj.STP_Select_View_PM_Analysis_Report_SupplierCOCID();
                //DataSet dsPMAnaRpt = new DataSet();
                //if(dsPMTrans.Tables[0].Rows.Count>0)
                //{
                //Report_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                //Report_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                //Report_Class_Obj.pmtransid = Convert.ToInt64(dsPMTrans.Tables[0].Rows[0][0]);
                //Report_Class_Obj.fromAnalysisReanalysis = Convert.ToInt32(dsPMTrans.Tables[0].Rows[0][1]);
                //dsPMAnaRpt = Report_Class_Obj.Select_View_PM_Analysis_Report();
                //}

                ds = PMTransaction_Class_obj1.GenerateCOCHistory_Report(PMsuppliercocid);
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


                    PMCOCHistory_Report objPMCOCHistory_Report = new PMCOCHistory_Report();
                    objPMCOCHistory_Report.SetDataSource(ds.Tables[0]);
                    if (dsPMTrans.Tables[0].Rows.Count > 0)
                    {
                        objPMCOCHistory_Report.Subreports["AnalysisReport"].SetDataSource(dsPMTrans.Tables[0]);
                    }                   
                    ReportViewer.ParameterFieldInfo = param1Fields;
                    ReportViewer.ReportSource = objPMCOCHistory_Report;
                    ReportViewer.Show();
                }
                else
                {
                    ReportViewer.ReportSource = null;
                    MessageBox.Show("Sorry No data found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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