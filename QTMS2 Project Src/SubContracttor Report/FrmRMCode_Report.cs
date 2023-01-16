using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using CrystalDecisions.Shared;
using BusinessFacade;

namespace QTMS.SubContracttor_Report
{
    public partial class FrmRMCode_Report : Form
    {
        public string rptName;

        public FrmRMCode_Report()
        {
            InitializeComponent();
        }

        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();

        BusinessFacade.SubContractor_Class.Report_SubContractor Report_SubContractor_Obj = new BusinessFacade.SubContractor_Class.Report_SubContractor();
        # endregion

        private void FrmRMCode_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; 
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
            cmbHalal.SelectedIndex = 0;
            Bind_List();
            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        }

        public void Bind_List()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = new RMCodeMaster_Class().Select_RMCodeMaster();
                dr = ds.Tables[0].NewRow();
                dr["RMCode"] = "--Select All--";
                dr["RMCodeID"] = 0;
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbRMCode.DataSource = ds.Tables[0];
                cmbRMCode.DisplayMember = "RMCode";
                cmbRMCode.ValueMember = "RMCodeID";
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
                Reports.RMCodeReport RMCodeReport = new QTMS.Reports.RMCodeReport();
              
                DataSet DsRMCode = new DataSet();
                DataTable dt = new DataTable(); 

                //if (cmbHalal.SelectedIndex == 0 || cmbRMCode.Text == "--Select--")
                //{
                //    MessageBox.Show("Please Select Halal !", "Message");
                //    return;
                //}
                pictureBox1.Visible = true;

                #region CompanyName and Address
                ParameterFields param1Fields = new ParameterFields();
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
                long RMCode = 0;
                string halal = string.Empty;
                if (cmbHalal.SelectedIndex != 0)
                    halal = cmbHalal.Text;

                RMCode = Convert.ToInt64(cmbRMCode.SelectedValue);           
                DsRMCode = new RMCodeMaster_Class().RMCodeReport(RMCode, halal);
                RMCodeReport.SetDataSource(DsRMCode.Tables[0]);
                ReportViewer.ReportSource = RMCodeReport;
                ReportViewer.Show();
                pictureBox1.Visible = false;
            }
            catch (Exception ex)
            {
                pictureBox1.Visible = false;
                MessageBox.Show(ex.Message);
            }
        }
           
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}