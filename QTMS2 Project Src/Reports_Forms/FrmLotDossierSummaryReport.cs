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
    public partial class FrmLotDossierSummaryReport : Form
    {
        public string rptName;
        public bool rptDisplayed = false;

        public FrmLotDossierSummaryReport(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.LotDossier_Class LotDossier_Class_Obj = new BusinessFacade.Transactions.LotDossier_Class();
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        # endregion

        private void FrmLotDossierReport_Load(object sender, EventArgs e)
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
                ds = Report_Class_Obj.Select_tblFGTLF_LotDetails();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--All--";
                dr["FGTestNo"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "FGTestNo";
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
                Reports.LotDossierSummary_Report LotDossierSummary = new QTMS.Reports.LotDossierSummary_Report();
        
                DataSet ds = new DataSet();

                //if (cmbDetails.Text == "--All--" && DtpDateFrom.Checked == false && DtpDateTo.Checked == false)
                //{
                //    MessageBox.Show("Please Select Details or date...!", "Message");
                //    return;
                //}

                if (cmbDetails.Text == "--All--")
                {
                    Report_Class_Obj.fgtestno = 0;
                }
                else
                {
                    Report_Class_Obj.fgtestno = Convert.ToInt64(cmbDetails.SelectedValue);
                }

                if (DtpDateFrom.Checked == true)
                {
                    Report_Class_Obj.fromdate = DtpDateFrom.Value.ToShortDateString();
                }
                else
                {
                    Report_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpDateTo.Checked == true)
                {
                    Report_Class_Obj.todate = DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    Report_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }


                switch (rptName)
                {
                    case "LotDossierSummary":
                        //----- same as above --------
                        ds = Report_Class_Obj.Select_VIEW_LotDossier_Report_2();
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
                    // Added by Sanjiv on 25 March 2010 to add form data and Todate

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

                    // till here
                    ReportViewer.ParameterFieldInfo = param1Fields;

                    switch (rptName)
                    {                        
                        case "LotDossierSummary":
                                                        
                            LotDossierSummary.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = LotDossierSummary;
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
            txtProtocolNo.Text = "";
            if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "0")
            {
                txtProtocolNo.Text = "LOT" + cmbDetails.SelectedValue.ToString().PadLeft(6,'0');
            }
        }

        private void txtProtocolNo_Leave(object sender, EventArgs e)
        {
            cmbDetails.SelectedValue = 0;
            if (txtProtocolNo.Text.Trim() != "")
            {
                if (txtProtocolNo.Text.StartsWith("LOT"))
                {
                    int i = 0;
                    if(Int32.TryParse(txtProtocolNo.Text.Remove(0, 3),out i))
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