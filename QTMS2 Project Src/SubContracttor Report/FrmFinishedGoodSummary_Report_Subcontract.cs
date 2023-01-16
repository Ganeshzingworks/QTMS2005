using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using CrystalDecisions.Shared;

namespace QTMS.SubContracttor_Report
{
    public partial class FrmFinishedGoodSummary_Report_Subcontract : Form
    {
        public string rptName;
        public FrmFinishedGoodSummary_Report_Subcontract(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();

        BusinessFacade.SubContractor_Class.Report_SubContractor Report_SubContractor_Obj = new BusinessFacade.SubContractor_Class.Report_SubContractor();
        # endregion
        SubContracttor_Report.FinishedGoodSummary_Report_Subcontractor Retainer_Location = null;   
        private void FrmFGRetainerSampleLocation_Report_Subcontract_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);


            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
            //Bind_FGCode();
        }

        public void Bind_FGCode()
        {
            //DataRow dr;
            //DataSet ds = new DataSet();
            //ds = Report_SubContractor_Obj.Select_FGCode_RetainerLocation();
            //dr = ds.Tables[0].NewRow();
            //dr["FGCode"] = "--ALL--";
            //dr["FGTLFID"] = "0";
            //ds.Tables[0].Rows.InsertAt(dr, 0);
            //cmbFGCode.DataSource = ds.Tables[0];
            //cmbFGCode.DisplayMember = "FGCode";
            //cmbFGCode.ValueMember = "FGTLFID";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                //if (cmbFGCode.SelectedValue == null || cmbFGCode.Text == "--Select--")
                //{
                //    MessageBox.Show("Select Formula No...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    cmbFGCode.Focus();
                //    return;
                //}

                //if (cmbMfgWo.SelectedValue == null)
                //{
                //    MessageBox.Show("Select MfgWo...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    cmbMfgWo.Focus();
                //    return;
                //}
                pictureBox1.Visible = true;
                DataSet FGSummaryReport = new DataSet();

                if (DtpDateFrom.Checked == true)
                {
                    Report_SubContractor_Obj.fromdate = DtpDateFrom.Value.ToShortDateString();
                }
                else
                {
                    Report_SubContractor_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpDateTo.Checked == true)
                {
                    Report_SubContractor_Obj.todate = DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    Report_SubContractor_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }
                

                switch (rptName)
                {
                    case "FinishedGoodSummary Report":
                        FGSummaryReport = Report_SubContractor_Obj.Select_FinishedGoodSummary_Subcontractor_Report();
                        break;
                }


                if (FGSummaryReport.Tables[0].Rows.Count > 0)
                {
                    ParameterFields param1Fields = new ParameterFields();
                    ParameterField FromDate = new ParameterField();
                    ParameterField ToDate = new ParameterField();
                    ParameterDiscreteValue FromDateDescrete = new ParameterDiscreteValue();
                    ParameterDiscreteValue ToDateDescrete = new ParameterDiscreteValue();
                    FromDate.Name = "FromDate";
                    if (DtpDateFrom.Checked == true)
                    {
                        FromDateDescrete.Value = DtpDateFrom.Value.ToShortDateString();
                    }
                    else
                    {
                        FromDateDescrete.Value = "";
                    }
                    FromDate.CurrentValues.Add(FromDateDescrete);

                    ToDate.Name = "ToDate";
                    if (DtpDateTo.Checked == true)
                    {
                        ToDateDescrete.Value = DtpDateTo.Value.ToShortDateString();
                    }
                    else
                    {
                        ToDateDescrete.Value = "";
                    }
                    ToDate.CurrentValues.Add(ToDateDescrete);

                    param1Fields.Add(FromDate);
                    param1Fields.Add(ToDate);

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
                        case "FinishedGoodSummary Report":
                            Retainer_Location = new QTMS.SubContracttor_Report.FinishedGoodSummary_Report_Subcontractor();
                            Retainer_Location.SetDataSource(FGSummaryReport.Tables[0]);
                            ReportViewer.ReportSource = Retainer_Location;
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
    }
}