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
    public partial class FrmRMControlTypeReport : Form
    {
        public string rptName;
        
        public FrmRMControlTypeReport(string RptName)
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
        Reports.RMControlTypeReport RMControlType = new QTMS.Reports.RMControlTypeReport();
        # endregion     


        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {                          
                
                DataSet ds = new DataSet();           

                
                if (CmbType.Text.Trim() == "-- Select --")
                {
                    MessageBox.Show("Please select Type...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (cmbRMCode.Text.Trim() == "-- Select --")
                {
                    MessageBox.Show("Please select RM Code...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                if (CmbType.Text.Trim() == "Reduced Control")
                    Report_Class_Obj.methodType = 'R';
                else if (CmbType.Text.Trim() == "Full Control")
                    Report_Class_Obj.methodType = 'F';

                Report_Class_Obj.rmcodeid = Convert.ToInt64(cmbRMCode.SelectedValue);

                ds = Report_Class_Obj.Select_RMControlType_Reports();

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

                    RMControlType.SetDataSource(ds.Tables[0]);

                    ReportViewer.ParameterFieldInfo = param1Fields;
                    ReportViewer.ReportSource = RMControlType;
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

        private void FrmRMControlTypeReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            CmbType.SelectedIndex = 0;
            Bind_RMCode();
        }
        public void Bind_RMCode()
        {
            try
            {
                DataSet ds = new DataSet();
                BusinessFacade.RMCodeMaster_Class RMCodeMaster_Class_Obj = new RMCodeMaster_Class();
                ds = RMCodeMaster_Class_Obj.Select_RMCodeMaster();
                DataRow dr = ds.Tables[0].NewRow();
                dr["RMCode"] = "-- Select --";
                dr["RMCodeId"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbRMCode.DataSource = ds.Tables[0];
                    cmbRMCode.DisplayMember = "RMCode";
                    cmbRMCode.ValueMember = "RMCodeID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}