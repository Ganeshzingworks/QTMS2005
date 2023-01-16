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
    public partial class FrmRMTestMethodMaster_Report : Form
    {
        public FrmRMTestMethodMaster_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        string rptName;
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();

        Reports.RMTestMethodMaster_Report RMTestMethodMaster = new QTMS.Reports.RMTestMethodMaster_Report();

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
            DataRow dr;
            DataSet ds = new DataSet();
            ds = Report_Class_Obj.Select_tblRMCodeMaster();
            dr = ds.Tables[0].NewRow();
            dr["RMCode"] = "--Select--";
            dr["RMCodeID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbDetails.DataSource = ds.Tables[0];
            cmbDetails.DisplayMember = "RMCode";
            cmbDetails.ValueMember = "RMCodeID";
        }

        
        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select RMCode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet ds = new DataSet();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();

                Report_Class_Obj.rmcodeid = Convert.ToInt32(cmbDetails.SelectedValue);

                switch (rptName)
                {
                    case "RMTestMethodMasterReport":

                        ds = Report_Class_Obj.SELECT_View_RMTestMethodMaster_Report();
                        dt1 = Report_Class_Obj.SELECT_View_RMPhysicochemicalTestMethodMaster_Report();
                        //dt2 = Report_Class_Obj.SELECT_View_RMPreservativeMethodMaster_Report();
                        //dt3 = Report_Class_Obj.SELECT_View_RMFDAPhysicoChemicalTestMethodMaster_Report();
                        //dt4 = Report_Class_Obj.SELECT_View_RMFDAPreservativeMethodMaster_Report();

                        break;


                }
                if (ds.Tables[0].Rows.Count > 0)
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
                        case "RMTestMethodMasterReport":

                            RMTestMethodMaster.SetDataSource(ds.Tables[0]);
                            RMTestMethodMaster.Subreports["RMPhyChe"].SetDataSource(dt1);
                            //RMTestMethodMaster.Subreports["RMPres"].SetDataSource(dt2);
                            //RMTestMethodMaster.Subreports["RMFDAPhyChe"].SetDataSource(dt3);
                            //RMTestMethodMaster.Subreports["RMFDAPres"].SetDataSource(dt4);
                            ReportViewer.ReportSource = RMTestMethodMaster;
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