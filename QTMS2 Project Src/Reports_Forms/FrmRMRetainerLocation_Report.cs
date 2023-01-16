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
    public partial class FrmRMRetainerLocation_Report : Form
    {
        public FrmRMRetainerLocation_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        string rptName;
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();

        Reports.RMRetainerLocation_Report RMRetainerLocation = new QTMS.Reports.RMRetainerLocation_Report();
        # endregion

        private void FrmRM_Analysis_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      

            Bind_Details();
        }

        public void Bind_Details()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                RetainerLocation_Class RetainerLocation_Class_Obj = new RetainerLocation_Class();
                ds = RetainerLocation_Class_Obj.Select_RMRetainerLocation();
                dr = ds.Tables[0].NewRow();
                dr["Location"] = "ALL";
                dr["LocationID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr,0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Location";
                cmbDetails.ValueMember = "LocationID";      
                   
               
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
                if (cmbDetails.SelectedValue == null )
                {
                    MessageBox.Show("Please Select RMCode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = new DataTable();
                
                Report_Class_Obj.LocationID = Convert.ToInt32(cmbDetails.SelectedValue);

                switch (rptName)
                {
                    case "RMRetainerLocation_Report":
                        dt = Report_Class_Obj.Select_RMRetainerLocation_Report();                        
                        break;
                }
                if (dt.Rows.Count > 0)
                {
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

                    ReportViewer.ParameterFieldInfo = ParaFields;
                    switch (rptName)
                    {
                        case "RMRetainerLocation_Report":

                            RMRetainerLocation.SetDataSource(dt);
                            ReportViewer.ReportSource = RMRetainerLocation;
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