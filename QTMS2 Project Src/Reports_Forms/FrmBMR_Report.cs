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
    public partial class FrmBMR_Report : Form
    {
        public string rptName;

        public FrmBMR_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
        BusinessFacade.Transactions.BMRReport_Class BMRReport_Class_Obj = new BusinessFacade.Transactions.BMRReport_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();

        QTMS.Reports.BMRSummary_Report BMRSummary = new QTMS.Reports.BMRSummary_Report();
                       
        # endregion

        private void FrmBMR_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      
            Bind_Details();
            Bind_InspectedBy();
        }

        public void Bind_Details()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = Report_Class_Obj.Select_BulkAnalysis_Report();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            dr["FMID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbDetails.DataSource = ds.Tables[0];
            cmbDetails.DisplayMember = "Details";
            cmbDetails.ValueMember = "FMID";
        }

        public void Bind_InspectedBy()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = UserManagement_Class_Obj.Select_AllUser();
            dr = ds.Tables[0].NewRow();
            dr["UserName"] = "--Select--";
            dr["UserID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbInspectedBy.DataSource = ds.Tables[0];
                cmbInspectedBy.DisplayMember = "UserName";
                cmbInspectedBy.ValueMember = "UserID";
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details...!", "Message");
                    return;
                }
                pictureBox1.Visible = true;
                reset();

                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                DataSet ds3 = new DataSet();

                Report_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
               
                switch (rptName)
                {
                    case "BMR":
                        ds = Report_Class_Obj.Select_View_BMR_Report();
                        //ds1 = Report_Class_Obj.Select_View_BMR_FG_Report();                        
                        ds1 = Report_Class_Obj.Select_VIEW_FG_Analysis_Phy_Report_BMR_Phy();
                        ds2 = Report_Class_Obj.Select_VIEW_Bulk_Analysis_Report();
                        ds3 = Report_Class_Obj.Select_VIEW_FG_Analysis_Pres_Report_BMR_Pres();
                        break;
                }

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

                    switch (rptName)
                    {
                        case "BMR":
                            //rpt.SetDatabaseLogon("qtmsdb", "qtmsdb", "soft2", "qtms");

                            BMRSummary.SetDataSource(ds.Tables[0]);
                            BMRSummary.Subreports["BMR_Phy"].SetDataSource(ds1.Tables[0]);
                            BMRSummary.Subreports["BMR_Bulk"].SetDataSource(ds2.Tables[0]);
                            BMRSummary.Subreports["BMR_Pres"].SetDataSource(ds3.Tables[0]);
                            ReportViewer.ParameterFieldInfo = param1Fields;
                            ReportViewer.ReportSource = BMRSummary;
                            ReportViewer.ShowGroupTreeButton = false;
                            ReportViewer.DisplayGroupTree = false;
                            ReportViewer.Show();
                            break;
                    }
                }
                else
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                pictureBox1.Visible = false;
            }
            catch (Exception ex)
            {
                pictureBox1.Visible = false;
                MessageBox.Show(ex.Message);
            }
        }

        public void reset()
        {
            RdoOpen.Checked = false;
            RdoClose.Checked = false;
            txtCommnet.Text = "";
            cmbInspectedBy.Text = "--Select--";    
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDetails.SelectedValue != null)
            {
                reset();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
            {
                MessageBox.Show("Please Select Details...!", "Message");
                cmbDetails.Focus();
                return;
            }
            if (RdoOpen.Checked == false && RdoClose.Checked == false)
            {
                MessageBox.Show("Please Select Status...!", "Message");               
                return;
            }
            if (cmbInspectedBy.Text == "--Select--")
            {
                MessageBox.Show("Please Inspected By...!", "Message");
                cmbInspectedBy.Focus();
                return;
            }

            BMRReport_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
            if (RdoOpen.Checked == true)
            {
                BMRReport_Class_Obj.status = 'O';
            }
            else if (RdoClose.Checked == true)
            {
                BMRReport_Class_Obj.status = 'C';
            }
            
            BMRReport_Class_Obj.comment = txtCommnet.Text.Trim();
            BMRReport_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

            DataSet ds = new DataSet();            
            ds = BMRReport_Class_Obj.Select_tblBMRReport_FMID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                BMRReport_Class_Obj.Update_tblBMRReport();
            }
            else
            {
                BMRReport_Class_Obj.Insert_tblBMRReport();
            }

            MessageBox.Show("BMR Report Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            BtnShow_Click(sender, e);
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
          
    }
}