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
    public partial class FrmComplaintAnalysis_Report : Form
    {
        public string rptName;

        public FrmComplaintAnalysis_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles        
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        # endregion

        private void FrmFGAnalysisReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      
      
            Bind_Details();
            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        }

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = Report_Class_Obj.Select_tblComplaintTransaction_ComplaintRefNo();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "TransID";
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
                Reports.ComplaintAnalysis_Report ComplaintAnalysis = new QTMS.Reports.ComplaintAnalysis_Report();

                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                DataSet ds3 = new DataSet();
                DataSet ds4 = new DataSet();
                DataSet ds5 = new DataSet();
                
                if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details...!", "Message");
                    return;
                }

                Report_Class_Obj.transid = Convert.ToInt64(cmbDetails.SelectedValue);

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
                    case "ComplaintAnalysis":
                        ds = Report_Class_Obj.Select_VIEW_ComplaintAnalysis_Report();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Report_Class_Obj.batchno = ds.Tables[0].Rows[0]["batchNo"].ToString();
                        }
                        else
                        {
                            Report_Class_Obj.batchno = null;
                        }

                        ds1 = Report_Class_Obj.Select_VIEW_ComplaintAnalysis_Packing_Report();
                        ds2 = Report_Class_Obj.Select_VIEW_ComplaintAnalysis_PhyChe_Report();
                        ds3 = Report_Class_Obj.Select_View_ComplaintAnalysis_InvestigationSteps_Report();
                        ds4 = Report_Class_Obj.Select_View_ComplaintAnalysis_BatchNoCnt_Report();
                        //ds5 = Report_Class_Obj.Select_View_ComplaintAnalysis_FormulaNoCnt_Report();

                        //DataTable dt = new DataTable();
                        //dt.Columns.Add("FormulaNo");
                        //dt.Columns.Add("FormulaNoCnt");
                        
                        //DataRow dr;
                        //for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
                        //{
                        //    dr = dt.NewRow();
                        //    dr["FormulaNo"] = ds5.Tables[0].Rows[i]["FormulaNo"].ToString();
                        //    dr["FormulaNoCnt"] = ds5.Tables[0].Rows[i]["FormulaNoCnt"].ToString();
                        //    dt.Rows.InsertAt(dr, i);
                        //}

                        break;
                }


                if (ds.Tables[0].Rows.Count > 0)
                {
                    switch (rptName)
                    {
                        case "ComplaintAnalysis":
                                                        
                            ComplaintAnalysis.SetDataSource(ds.Tables[0]);
                            ComplaintAnalysis.Subreports["ComplaintAnalysis_Packing"].SetDataSource(ds1.Tables[0]);
                            ComplaintAnalysis.Subreports["ComplaintAnalysis_PhyChe"].SetDataSource(ds2.Tables[0]);
                            ComplaintAnalysis.Subreports["ComplaintAnalysis_InvestigationSteps"].SetDataSource(ds3.Tables[0]);
                            ComplaintAnalysis.Subreports["BatchNoCnt"].SetDataSource(ds4.Tables[0]);
                            //ComplaintAnalysis.Subreports["FormulaNoCnt"].SetDataSource(ds5.Tables[0]); 
                            ReportViewer.ReportSource = ComplaintAnalysis;
                            ReportViewer.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Sorry Record Not Found...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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