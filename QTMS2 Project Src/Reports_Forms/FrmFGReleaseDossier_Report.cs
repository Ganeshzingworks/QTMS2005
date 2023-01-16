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
    public partial class FrmFGReleaseDossier_Report : Form
    {
        public string rptName;

        public FrmFGReleaseDossier_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();        
        BusinessFacade.FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new BusinessFacade.FormulaNoMaster_Class();

        Reports.FGReleaseDossier_Report FGReleaseDossier = new QTMS.Reports.FGReleaseDossier_Report();

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        # endregion

        private void FrmFormulaHistoryReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);         
            
            Bind_Formula();
        }

        public void Bind_Formula()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = FormulaNoMaster_Class_Obj.Select_TblBulkMaster();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbFormulaNo.DataSource = ds.Tables[0];
            cmbFormulaNo.DisplayMember = "FormulaNo";
            cmbFormulaNo.ValueMember = "FNo";
        }

        

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFormulaNo.SelectedValue == null || cmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula No...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbFormulaNo.Focus();
                    return;
                }
                pictureBox1.Visible = true;
                Report_Class_Obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);

                switch (rptName)
                {
                    case "FGReleaseDossier":
                        ds = Report_Class_Obj.Select_View_FGReleaseDossier_Report();
                        ds1 = Report_Class_Obj.Select_View_FGReleaseDossierDetails_Report();
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

                    ReportViewer.ParameterFieldInfo = param1Fields;
                    switch (rptName)
                    {
                        case "FGReleaseDossier":
                            FGReleaseDossier.SetDataSource(ds.Tables[0]);
                            FGReleaseDossier.Subreports["FGReleaseDossier_Details_Report"].SetDataSource(ds1.Tables[0]);
                            ReportViewer.ReportSource = FGReleaseDossier;
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









    }
}