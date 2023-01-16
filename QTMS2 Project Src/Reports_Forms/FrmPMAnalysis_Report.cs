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
    public partial class FrmPMAnalysis_Report : Form
    {
        public FrmPMAnalysis_Report()
        {
           
            InitializeComponent();
        }

        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        Reports.PM_Analysis_Report PM_Analysis = new QTMS.Reports.PM_Analysis_Report();
        #endregion

        private void FrmPMAnalysis_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
                

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
            Bind_Details();
        }

        public void Bind_Details()
        {
            try
            {
                cmbDetails.DataSource = null;
                
                DataSet ds = new DataSet();
                DataRow dr;
                if (rdBtnAll.Checked == true)
                    ds = Report_Class_Obj.Select_PMTransaction_PMAnalysisReport();
                else if (rdBtnPMReanalysis.Checked == true)
                    ds = Report_Class_Obj.Select_PMCode_PMReAnalysisReport();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["PMTransID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "PMTransID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }                
                DataSet ds = new DataSet();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
               
                if (DtpDateFrom.Checked == true)
                {
                    Report_Class_Obj.fromdate = DtpDateFrom.Value.ToShortDateString();
                }
                else
                {
                    Report_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpDateTo.Checked == true)
                {
                    Report_Class_Obj.todate = DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    Report_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }

                Report_Class_Obj.pmtransid = Convert.ToInt64(cmbDetails.SelectedValue);
                if (rdBtnAll.Checked == true)
                    Report_Class_Obj.fromAnalysisReanalysis = 1;
                else if (rdBtnPMReanalysis.Checked == true)
                    Report_Class_Obj.fromAnalysisReanalysis = 2;
                else
                    Report_Class_Obj.fromAnalysisReanalysis = 0;

                ds = Report_Class_Obj.Select_View_PM_Analysis_Report();
                //Report_Class_Obj.pmtestid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMTestID"]);
                dt1 = Report_Class_Obj.Select_View_PM_Analysis_SubReport();
                dt2 = Report_Class_Obj.Select_View_PM_Analysis_DefectReport();
                if (ds.Tables[0].Rows.Count > 0)
                {
                   
                    ParameterFields param1Fields = new ParameterFields();
                    ParameterField FromDate = new ParameterField();
                    ParameterField ToDate = new ParameterField();
                    ParameterField ProtocolNo = new ParameterField(); 

                     
                    ParameterDiscreteValue FromDateDescrete = new ParameterDiscreteValue();
                    ParameterDiscreteValue ToDateDescrete = new ParameterDiscreteValue();
                    ParameterDiscreteValue ProtocolNoDescrete = new ParameterDiscreteValue();


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

                    ProtocolNo.Name = "ProtocolNo";
                    ProtocolNoDescrete.Value = txtProtocolNo.Text.Trim();
                    ProtocolNo.CurrentValues.Add(ProtocolNoDescrete);

                    //use for PM reanalysis report
                    //if (rdBtnPMReanalysis.Checked == true)
                    //{
                    //    ParameterField Reanalysis = new ParameterField();
                    //    ParameterDiscreteValue ReanalysisDiscrete = new ParameterDiscreteValue();
                    //    Reanalysis.Name = "Reanalysis";

                    //    if (rdBtnPMReanalysis.Checked == true)
                    //    {
                    //        ReanalysisDiscrete.Value = Convert.ToString(rdBtnPMReanalysis.Text.Trim());
                    //    }
                    //    else
                    //    {
                    //        ReanalysisDiscrete.Value = "";
                    //    }
                    //    Reanalysis.CurrentValues.Add(ReanalysisDiscrete);
                    //    param1Fields.Add(Reanalysis);
                    //}
                    param1Fields.Add(FromDate);
                    param1Fields.Add(ToDate);
                    param1Fields.Add(ProtocolNo);
                    ReportViewer.ParameterFieldInfo = param1Fields;

                    PM_Analysis.SetDataSource(ds.Tables[0]);
                    PM_Analysis.Subreports["PM_Analysis_SubReport"].SetDataSource(dt1);
                    PM_Analysis.Subreports["PM_Analysis_DefectReport"].SetDataSource(dt2);                    
                    ReportViewer.ReportSource = PM_Analysis;
                    ReportViewer.Show();
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

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtProtocolNo.Text = "";
            if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "0")
            {
                txtProtocolNo.Text = "PM" + cmbDetails.SelectedValue.ToString().PadLeft(6, '0');
            }
        }

        private void txtProtocolNo_Leave(object sender, EventArgs e)
        {
            cmbDetails.SelectedValue = 0;
            if (txtProtocolNo.Text.Trim() != "")
            {
                if (txtProtocolNo.Text.StartsWith("PM"))
                {
                    int i = 0;
                    if (Int32.TryParse(txtProtocolNo.Text.Remove(0, 2), out i))
                    {
                        cmbDetails.SelectedValue = i;
                    }
                }
            }
        }

        private void txtProtocolNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtProtocolNo_Leave(sender, e);
                BtnShow.Focus();
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }  

        private void rdBtnPMReanalysis_Click(object sender, EventArgs e)
        {
            Bind_Details();
        }

        private void rdBtnAll_Click(object sender, EventArgs e)
        {
            Bind_Details();
        }   
       

    }
}