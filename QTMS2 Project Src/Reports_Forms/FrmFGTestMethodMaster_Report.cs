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
    public partial class FrmFGTestMethodMaster_Report : Form
    {
        public FrmFGTestMethodMaster_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles

        string rptName;
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new BusinessFacade.PackingFamilyMaster_Class();
        Reports.FGTestMethodMaster_Report FGTestMethodMaster = new QTMS.Reports.FGTestMethodMaster_Report();
        
        # endregion

        private void FrmFGTestMethodMaster_Report_Load(object sender, EventArgs e)
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
            ds = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster(); 
            dr = ds.Tables[0].NewRow();
            dr["TechFamDesc"] = "--Select--";
            dr["PKGTechNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbDetails.DataSource = ds.Tables[0];
            cmbDetails.DisplayMember = "TechFamDesc";
            cmbDetails.ValueMember = "PKGTechNo";
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Packing Family..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                pictureBox1.Visible = true;
                DataSet ds = new DataSet();                

                Report_Class_Obj.pkgtechno = Convert.ToInt32(cmbDetails.SelectedValue);

                switch (rptName)
                {
                    case "FGTestMethodMasterReport":

                        ds = Report_Class_Obj.SELECT_View_FGTestMethodMaster_Report();
                        
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
                        case "FGTestMethodMasterReport":

                            FGTestMethodMaster.SetDataSource(ds.Tables[0]);                            
                            ReportViewer.ReportSource = FGTestMethodMaster;
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