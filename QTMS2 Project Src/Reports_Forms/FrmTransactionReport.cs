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
using BusinessFacade;


namespace QTMS.Reports_Forms
{
    public partial class FrmTransactionReport : Form
    {
        public string rptName;
        
        public FrmTransactionReport(string RptName)
        {
            this.rptName = RptName;            
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            //Painter.Paint(this);

            //toolStrip1.Items.Add(rptName);
            //toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);          
        } 
        
        
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        Reports.RMTransaction_Report RMTransaction = new QTMS.Reports.RMTransaction_Report();
        # endregion

       



        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {                          
                
                DataSet ds = new DataSet();           

                
                if (CmbType.Text.Trim() == "")
                {
                    MessageBox.Show("Please select Type...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

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

                if (CmbType.Text.Trim() == "ALL")
                    Report_Class_Obj.status = "ALL";
                else if (CmbType.Text.Trim() == "Accepted")
                    Report_Class_Obj.status = "A";
                else if (CmbType.Text.Trim() == "Rejected")
                    Report_Class_Obj.status = "R";
                else if (CmbType.Text.Trim() == "AWD")
                    Report_Class_Obj.status = "D";
                else if (CmbType.Text.Trim() == "Send Back To Supplier")
                    Report_Class_Obj.status = "S";
                else if (CmbType.Text.Trim() == "Hold")
                    Report_Class_Obj.status = "H";
                else
                    Report_Class_Obj.status = "ALL";

                
                ds = Report_Class_Obj.Select_RMTransaction_Reports();

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

                    RMTransaction.SetDataSource(ds.Tables[0]);

                    ReportViewer.ParameterFieldInfo = param1Fields;
                    ReportViewer.ReportSource = RMTransaction;
                    ReportViewer.Show();                  
                }
                else
                {
                    MessageBox.Show("Sorry Record Not Found...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ReportViewer.ReportSource = null;
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

        private void FrmTransactionReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            CmbType.SelectedIndex = 0;
        }    
       
    }
}