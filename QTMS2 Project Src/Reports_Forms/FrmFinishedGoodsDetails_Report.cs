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
    public partial class FrmFinishedGoodsDetails_Report : Form
    {
        public string rptName;

        public FrmFinishedGoodsDetails_Report(string RptName)
        {
            this.rptName = RptName;            
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();   
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        # endregion

        private void FrmFGAnalysisReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
            if (rptName == "FGMaster_Report")
                label1.Text = "FG Code ";
            if (rptName == "FormulaMaster_Report")
                label1.Text = "Formula ";
    
            Bind_Details();
            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();            
        }

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                if (rptName == "FGMaster_Report")
                {
                    ds = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster();
                    dr = ds.Tables[0].NewRow();
                    dr["FGCode"] = "--ALL--";
                    dr["FGNo"] = "0";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    cmbDetails.DataSource = ds.Tables[0];
                    cmbDetails.DisplayMember = "FGCode";
                    cmbDetails.ValueMember = "FGNo";
                }
                if (rptName == "FormulaMaster_Report")
                {
                    ds = FormulaNoMaster_Class_Obj.Select_TblBulkMaster();
                    dr = ds.Tables[0].NewRow();
                    dr["FormulaNo"] = "--ALL--";
                    dr["FNo"] = "0";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    cmbDetails.DataSource = ds.Tables[0];
                    cmbDetails.DisplayMember = "FormulaNo";
                    cmbDetails.ValueMember = "FNo";
                }
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
                Reports.FinishedGoodDetails_Report FGAnalysis = new QTMS.Reports.FinishedGoodDetails_Report();
                Reports.FormulaMaster_Report FormulaMaster = new QTMS.Reports.FormulaMaster_Report();

                DataSet ds = new DataSet();
              
                pictureBox1.Visible = true;
                Report_Class_Obj.fgno = Convert.ToInt64(cmbDetails.SelectedValue);
                Report_Class_Obj.fno = Convert.ToInt64(cmbDetails.SelectedValue);

                switch (rptName)
                {
                    case "FGMaster_Report":
                        ds = Report_Class_Obj.Select_View_FinishedGoodDetails_Report();
                       
                        break;
                    case "FormulaMaster_Report":
                        ds = Report_Class_Obj.Select_View_FormulaMasterDetails_Report();

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
                        case "FGMaster_Report":                           

                            FGAnalysis.SetDataSource(ds.Tables[0]);
                           
                            ReportViewer.ReportSource = FGAnalysis;
                            ReportViewer.Show();
                            break;
                        case "FormulaMaster_Report":

                            FormulaMaster.SetDataSource(ds.Tables[0]);

                            ReportViewer.ReportSource = FormulaMaster;
                            ReportViewer.Show();
                            break; 
                    }
                }
                else
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Sorry Record Not Found...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void txtProtocolNo_Leave(object sender, EventArgs e)
        {
           
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