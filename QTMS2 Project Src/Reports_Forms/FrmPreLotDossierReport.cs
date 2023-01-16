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
    public partial class FrmPreLotDossierReport : Form
    {
        public string rptName;

        public FrmPreLotDossierReport(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        # endregion

        private void FrmPreLotDossierReport_Load(object sender, EventArgs e)
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
                ds = Report_Class_Obj.Select_tblFGTLF_PreDetails();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                //cmbDetails.DataSource = ds.Tables[0];
                //cmbDetails.DisplayMember = "Details";
                //cmbDetails.ValueMember = "DetailsNo";

                cmbDetails.ValueMember = "DetailsNo";
                cmbDetails.DisplayMember = "Details";
                cmbDetails.DataSource = ds.Tables[0];
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
                pictureBox1.Visible = true;
                //Reports.PreLotDossier_Report PreLotDossier = new QTMS.Reports.PreLotDossier_Report();
                Reports.PreLotDossier_Report2 PreLotDossier = new QTMS.Reports.PreLotDossier_Report2();
                Reports.PreLotDossier_Report2_Baddi PreLotDossier_Baddi = new QTMS.Reports.PreLotDossier_Report2_Baddi();

                DataSet ds = new DataSet();

                if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details...!", "Message");
                    pictureBox1.Visible = false;
                    return;
                }

                Report_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);

                switch (rptName)
                {
                    case "PreLotDossier":
                        //ds = Report_Class_Obj.Select_VIEW_PreLotDossier_Report();
                        ds = Report_Class_Obj.Select_VIEW_PreLotDossier_Report2();
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
                        case "PreLotDossier":
                            if (GlobalVariables.City == "BADDI")
                            {
                                ds.Tables[0].DefaultView.Sort = "linestaus";
                                PreLotDossier_Baddi.SetDataSource(ds.Tables[0].DefaultView.ToTable());
                                ReportViewer.ReportSource = PreLotDossier_Baddi;
                                ReportViewer.Show();
                            }
                            else
                            {
                                PreLotDossier.SetDataSource(ds.Tables[0]);
                                ReportViewer.ReportSource = PreLotDossier;
                                ReportViewer.Show();

                            }
                            break;
                    }
                    pictureBox1.Visible = false;
                }
                else
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Sorry Record Not Found...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                pictureBox1.Visible = false;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}