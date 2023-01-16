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
    public partial class ComplaintSummary_Report : Form
    {
        public string rptName;

        public ComplaintSummary_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        # endregion

        private void FrmLotDossier_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
            Bind_BatchNo();
            Bind_FormulaNo();
            Bind_Category();

            if (rptName == "ComplaintResponce")
            {
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                cmbBatchCode.Visible = false;
                cmbFormulaNo.Visible = false;
                cmbCategory.Visible = false;
            }

        }

        public void Bind_FormulaNo()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = Report_Class_Obj.Select_View_ComplaintSummary_Report_FormulaNo();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--ALL--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbFormulaNo.DataSource = ds.Tables[0];
            cmbFormulaNo.DisplayMember = "FormulaNo";
            cmbFormulaNo.ValueMember = "FNo";
        }

        public void Bind_BatchNo()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = Report_Class_Obj.Select_View_ComplaintSummary_Report_BatchNo();
            dr = ds.Tables[0].NewRow();
            dr["BatchNo"] = "--ALL--";            
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbBatchCode.DataSource = ds.Tables[0];
            cmbBatchCode.DisplayMember = "BatchNo";            
        }

        public void Bind_Category()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = Report_Class_Obj.Select_View_ComplaintSummary_Report_Category();
            dr = ds.Tables[0].NewRow();
            dr["CategoryName"] = "--ALL--";
            dr["CategoryID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbCategory.DataSource = ds.Tables[0];
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (rptName != "ComplaintResponce")
                {

                    if (cmbCategory.SelectedValue == null || cmbBatchCode.SelectedValue == null || cmbFormulaNo.SelectedValue == null)
                    {
                        return;
                    }
                }

                Reports.ComplaintSummary_Report ComplaintSummary = new QTMS.Reports.ComplaintSummary_Report();
                Reports.ComplaintResponce_Report ComplaintResponce = new QTMS.Reports.ComplaintResponce_Report();
                DataSet ds = new DataSet();
              
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

                Report_Class_Obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                Report_Class_Obj.categoryid = Convert.ToInt64(cmbCategory.SelectedValue);
                if (cmbBatchCode.Text == "--ALL--")
                {
                    Report_Class_Obj.batchno = "0";
                }
                else
                {
                    Report_Class_Obj.batchno = cmbBatchCode.Text.Trim();
                }


                switch (rptName)
                {
                    case "ComplaintSummary":
                        ds = Report_Class_Obj.Select_View_ComplaintSummary_Report();
                        break;
                    case "ComplaintResponce":
                        ds = Report_Class_Obj.Select_View_ComplaintResponce_Report();
                        break;
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
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

                    param1Fields.Add(FromDate);
                    param1Fields.Add(ToDate);
                    
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
                        case "ComplaintSummary":
                            ComplaintSummary.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = ComplaintSummary;
                            ReportViewer.Show();
                            break;
                        case "ComplaintResponce":
                            ComplaintResponce.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = ComplaintResponce;
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