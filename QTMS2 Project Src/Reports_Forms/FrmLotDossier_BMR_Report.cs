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
    public partial class FrmLotDossier_BMR_Report : Form
    {
        public string rptName;

        public FrmLotDossier_BMR_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
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
                dr["Details"] = "--Select--";
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
                Reports.LotDossierBMR_Report LotDossierBMR = new QTMS.Reports.LotDossierBMR_Report();
                
                DataSet ds = new DataSet();

                if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please select Details","Message",MessageBoxButtons.OK,MessageBoxIcon.None);
                    return;
                }
                if (cmbFM.SelectedValue == null || cmbFM.Text == "--Select--")
                {
                    MessageBox.Show("Please select Formula-MfgWo", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    return;
                }

                Report_Class_Obj.fgtestno = Convert.ToInt64(cmbDetails.SelectedValue);

                Report_Class_Obj.fmid = Convert.ToInt64(cmbFM.SelectedValue);
                
                switch (rptName)
                {

                    case "LotDossierBMR":
                        ds = Report_Class_Obj.Select_VIEW_LotDossier_Report_BMR();
                                                
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("Some tests are pending...!\nPlease check in PreLot Dossier", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

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

                    string Formate = "";
                    if (GlobalVariables.City == "BADDI")
                        Formate = "Q82F-202-10-02A";
                    else
                        Formate = "Q5F-202-10-02D";


                    ParameterField LotDossierFormate = new ParameterField();
                    ParameterDiscreteValue LotDossierFormateDescrete = new ParameterDiscreteValue();
                    LotDossierFormate.Name = "LotDossierFormate";
                    LotDossierFormateDescrete.Value = Formate;
                    LotDossierFormate.CurrentValues.Add(LotDossierFormateDescrete);
                    param1Fields.Add(LotDossierFormate);
                    #endregion

                 
                    
                    ReportViewer.ParameterFieldInfo = param1Fields;

                    switch (rptName)
                    {
                        case "LotDossierBMR":

                            LotDossierBMR.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = LotDossierBMR;
                            ReportViewer.Show();
                            break;                                                    
                    }
                }
                else
                {
                    MessageBox.Show("Sorry Record Not Found...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bind_FM()
        {
            DataSet ds = new DataSet();
            DataRow dr;            
            ds = Report_Class_Obj.Select_VIEW_LotDossier_Report_FM();
            dr = ds.Tables[0].NewRow();
            dr["FM"] = "--Select--";
            dr["FMID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbFM.DataSource = ds.Tables[0];
            cmbFM.DisplayMember = "FM";
            cmbFM.ValueMember = "FMID";
        }
        
        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtProtocolNo.Text = "";
            if (cmbDetails.SelectedValue != null )
            {
                txtProtocolNo.Text = "LOT" + cmbDetails.SelectedValue.ToString().PadLeft(6, '0');
                Report_Class_Obj.fgtestno = Convert.ToInt64(cmbDetails.SelectedValue);
                Bind_FM();
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
                    if (Int32.TryParse(txtProtocolNo.Text.Remove(0, 3), out i))
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