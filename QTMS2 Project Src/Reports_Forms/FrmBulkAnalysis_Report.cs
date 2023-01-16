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
    public partial class FrmBulkAnalysis_Report : Form
    {
        public string rptName;

        public FrmBulkAnalysis_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();

        Reports.Bulk_Analysis_Report Bulk_Analysis = new QTMS.Reports.Bulk_Analysis_Report();
        # endregion

        private void FrmReport_Bulk_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            Bind_Details();
        }

        public void Bind_Details()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = Report_Class_Obj.Select_BulkAnalysis_Report();
            dr = ds.Tables[0].NewRow();           
            dr["Details"] = "--Select--";
            dr["FMID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbDetails.DataSource = ds.Tables[0];
            cmbDetails.DisplayMember = "Details";
            cmbDetails.ValueMember = "FMID";            
        }
              

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details...!", "Message");
                    return;
                }
                pictureBox1.Visible = true;
                DataSet ds = new DataSet();                

                Report_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);

                string ProtocolNo = "BLK" + cmbDetails.SelectedValue.ToString().PadLeft(6, '0'); 

                switch (rptName)
                {
                    case "BulkAnalysis":
                        ds = Report_Class_Obj.Select_VIEW_Bulk_Analysis_Report();

                        break;                   
                }


                if (ds.Tables[0].Rows.Count > 0)
                {                    
                    switch (rptName)
                    {
                        case "BulkAnalysis":
                            //rpt.SetDatabaseLogon("qtmsdb", "qtmsdb", "soft2", "qtms");

                            ParameterFields ParaFields = new ParameterFields();

                            ParameterField ParaProtocolNo = new ParameterField();
                            ParameterDiscreteValue ProtocolNoDiscrete = new ParameterDiscreteValue();
                            ParaProtocolNo.Name = "ProtocolNo";
                            ProtocolNoDiscrete.Value = ProtocolNo;
                            ParaProtocolNo.CurrentValues.Add(ProtocolNoDiscrete);
                            ParaFields.Add(ParaProtocolNo);

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

                            Bulk_Analysis.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = Bulk_Analysis;
                            ReportViewer.ShowGroupTreeButton = false;
                            ReportViewer.DisplayGroupTree = false;
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

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtProtocolNo.Text = "";
            if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "0")
            {
                txtProtocolNo.Text = "BLK" + cmbDetails.SelectedValue.ToString().PadLeft(6, '0');
            }
        }

        private void txtProtocolNo_Leave(object sender, EventArgs e)
        {
            cmbDetails.SelectedValue = 0;
            if (txtProtocolNo.Text.Trim() != "")
            {
                if (txtProtocolNo.Text.StartsWith("BLK"))
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