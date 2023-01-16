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
    public partial class FrmWaterAnalysis_Report : Form
    {
        public string rptName;

        public FrmWaterAnalysis_Report(string RptName)
        {
            this.rptName = RptName; 
            InitializeComponent();
        }

        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        Reports.WaterAnalysis_Report WaterAnalysis = new QTMS.Reports.WaterAnalysis_Report();
        Reports.PhysicoChemicalWaterAnalysis PhysicoChemicalWaterAnalysis = new QTMS.Reports.PhysicoChemicalWaterAnalysis();
        string waterAnalysisFormat;
        #endregion

        private void FrmWaterAnalysis_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            DtpDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDate.Checked = false;            
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (DtpDate.Checked != true)
                {
                    MessageBox.Show("Please Select Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataSet ds = new DataSet();
                
                if (DtpDate.Checked == true)
                {
                    Report_Class_Obj.fromdate = DtpDate.Value.ToShortDateString();
                }
                else
                {
                    Report_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }
                waterAnalysisFormat = string.Empty;
                switch (rptName)
                {
                    case "WaterAnalysis":
                        ds = Report_Class_Obj.Select_View_WaterAnalysis_Report();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            string plant="";
                            plant = ds.Tables[0].Rows[0]["Plant"] == DBNull.Value ? "" : ds.Tables[0].Rows[0]["Plant"].ToString()+"/";
                            waterAnalysisFormat = "WA/" + plant + string.Format("{0:yyyy}", DtpDate.Value) + "/" + Convert.ToString(ds.Tables[0].Rows[0]["WANo"]);


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

                            ParameterField WAFormat = new ParameterField();
                            ParameterDiscreteValue WAFormatDescrete = new ParameterDiscreteValue();
                            WAFormat.Name = "WaterAnalysisFormat";
                            WAFormatDescrete.Value = waterAnalysisFormat;
                            WAFormat.CurrentValues.Add(WAFormatDescrete);
                            ParaFields.Add(WAFormat);

                            ReportViewer.ParameterFieldInfo = ParaFields;

                            WaterAnalysis.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = WaterAnalysis;
                            ReportViewer.Show();
                        }
                        else
                        {
                            MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ReportViewer.ReportSource = null;
                            //return;
                        }
                        break;
                    case "PhysicoChemicalWaterAnalysis":
                        DataSet dsPhyChemWA = new DataSet();
                        Report_Class_Obj.phyChemSamplingDate = Convert.ToDateTime(DtpDate.Value.ToShortDateString());
                        dsPhyChemWA = Report_Class_Obj.Select_tblPhysicoChemicalWaterAnalysis_Report();
                        if (dsPhyChemWA.Tables[0].Rows.Count > 0)
                        {
                            waterAnalysisFormat = "511S/" + string.Format("{0:yyyy}", DtpDate.Value) + "/" + Convert.ToString(dsPhyChemWA.Tables[0].Rows[0]["PhyChemWA"]);

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

                            ParameterField WAFormat = new ParameterField();
                            ParameterDiscreteValue WAFormatDescrete = new ParameterDiscreteValue();
                            WAFormat.Name = "WaterAnalysisFormat";
                            WAFormatDescrete.Value = waterAnalysisFormat;
                            WAFormat.CurrentValues.Add(WAFormatDescrete);
                            ParaFields.Add(WAFormat);

                            ReportViewer.ParameterFieldInfo = ParaFields;

                            PhysicoChemicalWaterAnalysis.SetDataSource(dsPhyChemWA.Tables[0]);
                            ReportViewer.ReportSource = PhysicoChemicalWaterAnalysis;
                            ReportViewer.Show();
                        }
                        else
                        {
                            MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ReportViewer.ReportSource = null;                           
                        }
                        break;
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