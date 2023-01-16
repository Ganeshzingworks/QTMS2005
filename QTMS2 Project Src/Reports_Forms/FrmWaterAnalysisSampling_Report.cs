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
    public partial class FrmWaterAnalysisSampling_Report : Form
    {
        public string rptName;

        public FrmWaterAnalysisSampling_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }

        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.WaterAnalysis_Class WaterAnalysis_Class_Obj = new BusinessFacade.Transactions.WaterAnalysis_Class();
        Reports.WaterAnalysisSampling_Report WaterAnalysisSampling = new QTMS.Reports.WaterAnalysisSampling_Report();
        #endregion

        private void FrmWaterAnalysisSampling_Report_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            //cmbPlant.SelectedIndex = 0;
            Bind_Plant();
            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;            
        }

        public void Bind_Plant()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = WaterAnalysis_Class_Obj.Select_tblPlantMaster();
            dr = ds.Tables[0].NewRow();
            dr["PlantName"] = "--Select--";
            dr["PID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbPlant.DataSource = ds.Tables[0];
                cmbPlant.DisplayMember = "PlantName";
                cmbPlant.ValueMember = "PID";
            }
            DataRow dr1;
            dr1 = ds.Tables[0].NewRow();
            dr1["PlantName"] = "Old";
            dr1["PID"] = "100";
            ds.Tables[0].Rows.Add(dr1);

        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {                
                DataSet ds = new DataSet();

                if (Convert.ToInt64( cmbPlant.SelectedValue) == 0)
                {
                    MessageBox.Show("Please select the plant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    cmbPlant.Focus();
                    return;
                }
              /*
                    switch (cmbPlant.Text)
                    {
                        case "--Select--":
                            MessageBox.Show("Please select the plant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Report_Class_Obj.plantNo = "Old";
                            cmbPlant.Focus();
                            return;
                            //break;
                        case "Old":
                            Report_Class_Obj.plantNo = "Old";
                            break;
                        case "Plant1":
                            Report_Class_Obj.plantNo = "P1";
                            break;
                        case "Plant2":
                            Report_Class_Obj.plantNo = "P2";
                            break;
                        case "Plant3":
                            Report_Class_Obj.plantNo = "P3";
                            break;
                    }
                 
                */
                Report_Class_Obj.plantNo = cmbPlant.Text;

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
                
                              
               // ds = Report_Class_Obj.Select_View_WaterAnalysisSampling_Report();//--commented by manish

                ds = Report_Class_Obj.Select_View_WaterAnalysisSampling_Report2(); //--to show plantwise

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

                    WaterAnalysisSampling.SetDataSource(ds.Tables[0]);
                    ReportViewer.ReportSource = WaterAnalysisSampling;
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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

    }
}