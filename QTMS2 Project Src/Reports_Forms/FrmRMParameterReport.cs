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
    public partial class FrmRMParameterReport : Form
    {
        public string rptName;
        
        public FrmRMParameterReport(string RptName)
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
        Reports.RMParameter_Report RMParameter = new QTMS.Reports.RMParameter_Report();
        RMParaMaster_Class RMParaMaster_Class_Obj = new RMParaMaster_Class();
        # endregion      
        
        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {                          
                
                DataSet ds = new DataSet();           

                
                if (CmbParameterName.Text.Trim() == "-- Select --")
                {
                    MessageBox.Show("Please select Parameter...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                Report_Class_Obj.paraNo = Convert.ToInt32(CmbParameterName.SelectedValue);
                ds = Report_Class_Obj.Select_RMParameter_Reports();

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

                    RMParameter.SetDataSource(ds.Tables[0]);

                    ReportViewer.ParameterFieldInfo = param1Fields;
                    ReportViewer.ReportSource = RMParameter;
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

        private void FrmRMParameterReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            Bind_Parameter();
        }

        public void Bind_Parameter()
        {
            DataSet ds = new DataSet();
            ds = RMParaMaster_Class_Obj.Select_ParaMaster();

            DataRow dr;
            dr = ds.Tables[0].NewRow();
            dr["ParaName"] = "-- Select --";
            dr["ParaNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr,0);

            if (ds.Tables[0].Rows.Count >= 0)
            {
                CmbParameterName.DataSource = ds.Tables[0];
                CmbParameterName.DisplayMember = "ParaName";
                CmbParameterName.ValueMember = "ParaNo";

            }
        }
       
    }
}