using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using QTMS.Tools;
using CrystalDecisions.Shared;

namespace QTMS.Reports_Forms
{
    public partial class FrmTankSelectionReport : Form
    {
        public string rptName;

        public FrmTankSelectionReport(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        TankMaster_Class Obj = new TankMaster_Class();
        # endregion
        private void FrmTankSelectionReport_Load(object sender, EventArgs e)
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
                ds = Obj.GetDetails_TankSelection();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "Details";
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

        private void BtnShow_Click(object sender, EventArgs e)
        {
            Reports.TankSelection_Report TankReport = new QTMS.Reports.TankSelection_Report();
            DataSet ds = new DataSet();
            if (cmbDetails.Text == "--Select--")
            {
                MessageBox.Show("Please Select Details...!", "Message");
                return;
            }

            pictureBox1.Visible = true;
            Obj.details = Convert.ToString(cmbDetails.SelectedValue);
            ds = Obj.Select_TankDetails();

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

                ReportViewer.ParameterFieldInfo = param1Fields;

                TankReport.SetDataSource(ds.Tables[0]);

                ReportViewer.ReportSource = TankReport;
                ReportViewer.Show();
            }
            else
            {
                pictureBox1.Visible = false;
                MessageBox.Show("Sorry Record Not Found...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            pictureBox1.Visible = false;
        }
    }
}