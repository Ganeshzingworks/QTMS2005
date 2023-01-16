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
    public partial class FrmTestMethodMaster_Report : Form
    {
        public FrmTestMethodMaster_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles

        string rptName;
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        Reports.TestMethodMaster_Report TestMethodMaster = new QTMS.Reports.TestMethodMaster_Report();        
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
            ds = Report_Class_Obj.SELECT_FormulaNo_tblBulkMaster();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--All--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbDetails.DataSource = ds.Tables[0];
            cmbDetails.DisplayMember = "FormulaNo";
            cmbDetails.ValueMember = "FNo";
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula No...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbDetails.Focus();
                    return;
                }

                //if (cmbMfgWo.SelectedValue == null)
                //{
                //    MessageBox.Show("Select MfgWo...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    cmbMfgWo.Focus();
                //    return;
                //}
                pictureBox1.Visible = true;
                DataSet ds = new DataSet();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                DataTable dt4 = new DataTable();
                //DataTable dt5 = new DataTable();
                //DataTable dt6 = new DataTable();

                Report_Class_Obj.fno = Convert.ToInt32(cmbDetails.SelectedValue);

                switch (rptName)
                {
                    case "TestMethodMasterReport":

                        ds = Report_Class_Obj.SELECT_View_TestMethodMaster_Report();
                        dt1 = Report_Class_Obj.SELECT_View_BulkPhysicochemicalTestMethodMaster_Report();
                        dt2 = Report_Class_Obj.SELECT_View_LineTestMethodMaster_Report();
                        dt3 = Report_Class_Obj.SELECT_View_FGPhysicochemicalTestMethodMaster_Report();
                        dt4 = Report_Class_Obj.SELECT_View_PreservativeMethodMaster_Report();
                        //dt5 = Report_Class_Obj.SELECT_View_FDAPhysicochemicalTestMethodMaster_Report();
                        //dt6 = Report_Class_Obj.SELECT_View_FDAPreservativeTestMethodMaster_Report();

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
                        case "TestMethodMasterReport":

                            TestMethodMaster.SetDataSource(ds.Tables[0]);
                            TestMethodMaster.Subreports["BulkPhysicochemicalTestMethodMaster_Report"].SetDataSource(dt1);
                            TestMethodMaster.Subreports["LineTestMethodMaster_Report"].SetDataSource(dt2);
                            TestMethodMaster.Subreports["FGPhysicochemicalTestMethodMaster_Report"].SetDataSource(dt3);
                            TestMethodMaster.Subreports["PreservativeMethodMaster_Report"].SetDataSource(dt4);
                            //TestMethodMaster.Subreports["FDAPhysicochemicalTestMethodMaster_Report"].SetDataSource(dt5);
                            //TestMethodMaster.Subreports["FDAPreservativeTestMethodMaster_Report"].SetDataSource(dt6);
                            ReportViewer.ReportSource = TestMethodMaster;
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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
            //    if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "")
            //    {
            //        DataRow dr;
            //        DataSet ds = new DataSet();
            //        BulktestDetailstransaction_Class_Qbj.fno = Convert.ToInt64(cmbDetails.SelectedValue);
            //        ds = BulktestDetailstransaction_Class_Qbj.Select_tblTransFM_MfgWo();
            //        dr = ds.Tables[0].NewRow();
            //        dr["MfgWo"] = "--ALL--";
            //        dr["FMID"] = "0";
            //        ds.Tables[0].Rows.InsertAt(dr, 0);
            //        cmbMfgWo.DataSource = ds.Tables[0];
            //        cmbMfgWo.DisplayMember = "MfgWo";
            //        cmbMfgWo.ValueMember = "FMID"; 
            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}        
        }
    }
}