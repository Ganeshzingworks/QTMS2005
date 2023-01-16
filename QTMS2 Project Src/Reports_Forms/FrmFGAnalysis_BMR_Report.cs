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
    public partial class FrmFGAnalysis_BMR_Report : Form
    {
        public string rptName;

        public FrmFGAnalysis_BMR_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        # endregion

        private void FrmFGAnalysisReport_Load(object sender, EventArgs e)
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
                ds = Report_Class_Obj.Select_tblFGTLF_Details();
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
                Reports.FG_Analysis_BMR_Report FGAnalysisBMR = new QTMS.Reports.FG_Analysis_BMR_Report();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();

                if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details...!", "Message");
                    return;
                }

                if (cmbFM.SelectedValue == null || cmbFM.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Formula-MfgWo...!", "Message");
                    return;
                }
                pictureBox1.Visible = true;
                Report_Class_Obj.fgtestno = Convert.ToInt64(cmbDetails.SelectedValue);

                Report_Class_Obj.fmid = Convert.ToInt64(cmbFM.SelectedValue);

                switch (rptName)
                {
                    case "FGAnalysisBMR":
                        ds = Report_Class_Obj.Select_VIEW_FG_Analysis_Report_BMR();
                        dt1 = Report_Class_Obj.Select_VIEW_FG_Analysis_Phy_Report_BMR();
                        dt2 = Report_Class_Obj.Select_VIEW_FG_Analysis_Pack_Report();
                        dt3 = Report_Class_Obj.Select_VIEW_FG_Analysis_Pres_Report_BMR();
                        break;
                }


                if (ds.Tables[0].Rows.Count > 0)
                {
                    switch (rptName)
                    {
                        case "FGAnalysisBMR":

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
                            #endregion


                            ReportViewer.ParameterFieldInfo = param1Fields;

                            FGAnalysisBMR.SetDataSource(ds.Tables[0]);
                            FGAnalysisBMR.Subreports[0].SetDataSource(dt2);
                            FGAnalysisBMR.Subreports[1].SetDataSource(dt1);
                            FGAnalysisBMR.Subreports[2].SetDataSource(dt3);
                            ReportViewer.ReportSource = FGAnalysisBMR;
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

        private void Bind_FM()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = Report_Class_Obj.Select_VIEW_FG_Analysis_Report_FM();
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
            if (cmbDetails.SelectedValue != null)
            {
                txtProtocolNo.Text = "FG" + cmbDetails.SelectedValue.ToString().PadLeft(6, '0');
                Report_Class_Obj.fgtestno = Convert.ToInt64(cmbDetails.SelectedValue);
                Bind_FM();
            }
        }

        private void txtProtocolNo_Leave(object sender, EventArgs e)
        {
            cmbDetails.SelectedValue = 0;
            if (txtProtocolNo.Text.Trim() != "")
            {
                if (txtProtocolNo.Text.StartsWith("FG"))
                {
                    int i = 0;
                    if (Int32.TryParse(txtProtocolNo.Text.Remove(0, 2), out i))
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