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
    public partial class FrmRM_Analysis_Report : Form
    {
        public FrmRM_Analysis_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        string rptName;
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();

        Reports.FDA_RM_Analysis_Report FDA_RM_Analysis = new QTMS.Reports.FDA_RM_Analysis_Report();
        Reports.RM_Analysis_Report RM_Analysis = new QTMS.Reports.RM_Analysis_Report();
        Reports.RMValidity_Analysis_Report RMValidity_Analysis = new QTMS.Reports.RMValidity_Analysis_Report(); 
        # endregion

        private void FrmRM_Analysis_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
                       
            Bind_Details();
        }

        public void Bind_Details()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = Report_Class_Obj.Select_RMTransaction_RMAnalysisReport();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            dr["RMSamplingID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbDetails.DataSource = ds.Tables[0];
            cmbDetails.DisplayMember = "Details";
            cmbDetails.ValueMember = "RMSamplingID";
        }


        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Report_Class_Obj.rmsamplingid = Convert.ToInt32(cmbDetails.SelectedValue);

                DataSet ds = new DataSet();
                DataTable dt1 = new DataTable();
                //DataTable dt2 = new DataTable();
                
                switch (rptName)
                {
                    case "RM_Analysis":
                        ds = Report_Class_Obj.Select_View_RM_Analysis_Report();
                        dt1 = Report_Class_Obj.Select_View_RM_Analysis_Phy_Report();
                        //dt2 = Report_Class_Obj.Select_View_RM_Analysis_Pres_Report();

                        break;

                    case "FDA_RM_Analysis":
                        ds = Report_Class_Obj.Select_View_RM_Analysis_Report();
                        dt1 = Report_Class_Obj.Select_View_RM_Analysis_Phy_Report();
                        //dt2 = Report_Class_Obj.Select_View_RM_Analysis_Pres_Report();

                        break;  
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ParameterFields param1Fields = new ParameterFields();
                    ParameterField ProtocolNo = new ParameterField();
                    ParameterDiscreteValue ProtocolNoDescrete = new ParameterDiscreteValue();
                    ProtocolNo.Name = "ProtocolNo";
                    ProtocolNoDescrete.Value = txtProtocolNo.Text.Trim();
                    ProtocolNo.CurrentValues.Add(ProtocolNoDescrete);

                    param1Fields.Add(ProtocolNo);

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
                        case "RM_Analysis":
                            
                            RM_Analysis.SetDataSource(ds.Tables[0]);
                            RM_Analysis.Subreports[0].SetDataSource(dt1);
                            //RM_Analysis.Subreports[1].SetDataSource(dt2);
                            ReportViewer.ReportSource = RM_Analysis;                            
                            ReportViewer.Show();
                            break;

                        case "FDA_RM_Analysis":

                            FDA_RM_Analysis.SetDataSource(ds.Tables[0]);
                            FDA_RM_Analysis.Subreports[0].SetDataSource(dt1);
                            //RM_Analysis.Subreports[1].SetDataSource(dt2);
                            ReportViewer.ReportSource = FDA_RM_Analysis;
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

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            txtProtocolNo.Text = "";
            if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "0")
            {
                txtProtocolNo.Text = "RM" + cmbDetails.SelectedValue.ToString().PadLeft(6, '0');
            }           
        }

        private void txtProtocolNo_Leave(object sender, EventArgs e)
        {
            cmbDetails.SelectedValue = 0;
            if (txtProtocolNo.Text.Trim() != "")
            {
                if (txtProtocolNo.Text.StartsWith("RM"))
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


    }
}