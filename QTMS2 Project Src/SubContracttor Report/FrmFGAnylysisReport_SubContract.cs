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
    public partial class FrmFGAnylysisReport_SubContract : Form
    {
        public string rptName;

        public FrmFGAnylysisReport_SubContract(string RptName)
        {
            this.rptName = RptName;            
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();

        BusinessFacade.SubContractor_Class.Report_SubContractor Report_SubContractor_Obj = new BusinessFacade.SubContractor_Class.Report_SubContractor();
        # endregion

        private void FrmFGAnylysisReport_SubContract_Load(object sender, EventArgs e)
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
                ds = Report_SubContractor_Obj.Select_tblFGTLF_Details_SubContractor();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["FGTLFID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "FGTLFID";
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
                SubContracttor_Report.FG_Analysis_Report FGAnalysis = new QTMS.SubContracttor_Report.FG_Analysis_Report();
                //SubContracttor_Report.FG_Analysis_Report_231 FGAnalysis = new QTMS.SubContracttor_Report.FG_Analysis_Report_231();
                //Reports.FG_Analysis_Report_2 FGAnalysis = new QTMS.Reports.FG_Analysis_Report_2();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                //DataTable dt1 = new DataTable();
                //DataTable dt2 = new DataTable();
                //DataTable dt3 = new DataTable();

                DataTable dtPhy = new DataTable();
                DataTable dtPack_Loreal = new DataTable();
                DataTable dtPack_Supplier = new DataTable();
                DataTable dtMicro = new DataTable();
                DataTable dtPres_Loreal = new DataTable();
                DataTable dtPres_Supplier = new DataTable();

                if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details...!", "Message");
                    return;
                }
                pictureBox1.Visible = true;
                //Report_Class_Obj.fgtestno = Convert.ToInt64(cmbDetails.SelectedValue);
                Report_SubContractor_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);

                DataTable dtFGTestNo = new DataTable();
                dtFGTestNo = Report_SubContractor_Obj.Select_STP_GET_FGtestNo();
                if (dtFGTestNo.Rows.Count > 0)
                {
                    Report_SubContractor_Obj.fgtestno = Convert.ToInt64(dtFGTestNo.Rows[0][0]);
                }

                switch (rptName)
                {
                    case "FGAnalysis":
                        ds = Report_SubContractor_Obj.Select_VIEW_FG_Analysis_Report_SubContractor();
                        dtPhy = Report_SubContractor_Obj.Select_VIEW_FG_Analysis_Phy_Report_SubContractor();
                        dtPack_Loreal = Report_SubContractor_Obj.Select_VIEW_FG_Analysis_Pack_Report_Loreal_SubContractor();
                        dtPack_Supplier = Report_SubContractor_Obj.Select_VIEW_FG_Analysis_Pack_Report_Supplier_SubContractor();
                        dtMicro = Report_SubContractor_Obj.Select_VIEW_FG_Analysis_MicrobiologyTest_Report_SubContractor();
                        dtPres_Loreal = Report_SubContractor_Obj.Select_VIEW_FG_Preservative_Report_SubContractor_Loreal();
                        dtPres_Supplier = Report_SubContractor_Obj.Select_VIEW_FG_Preservative_Report_SubContractor_Supplier();


                        //dt3 = Report_Class_Obj.Select_VIEW_FG_Analysis_Pres_Report();
                        //DataTable dtSF = new DataTable();

                        //dtSF = Report_Class_Obj.Select_SFFinishedGood();
                        //if (dtSF.Rows.Count > 0)//If this fg is sf then show only Packing test else show all test
                        //{
                        //    dt2 = Report_Class_Obj.Select_VIEW_FG_Analysis_Pack_Report();
                        //}
                        //else
                        //{
                        //    dt1 = Report_Class_Obj.Select_VIEW_FG_Analysis_Phy_Report();
                        //    dt2 = Report_Class_Obj.Select_VIEW_FG_Analysis_Pack_Report();
                        //    dt3 = Report_Class_Obj.Select_VIEW_FG_Analysis_Pres_Report();
                        //}
                        break;                   
                }


                if (ds.Tables[0].Rows.Count > 0)
                {                    
                    switch (rptName)
                    {                 
                        case "FGAnalysis":

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

                            FGAnalysis.SetDataSource(ds.Tables[0]);

                            //FGAnalysis.Subreports[0].SetDataSource(dtPack_Loreal);
                            //FGAnalysis.Subreports[2].SetDataSource(dtPack_Supplier);
                            //FGAnalysis.Subreports[1].SetDataSource(dtPhy);

                            //FGAnalysis.Subreports[0].SetDataSource(dtPack_Loreal);
                            //FGAnalysis.Subreports[1].SetDataSource(dtPack_Supplier);
                            //FGAnalysis.Subreports[2].SetDataSource(dtPhy);

                            FGAnalysis.Subreports["FG_Pack_Loreal.rpt"].SetDataSource(dtPack_Loreal);
                            FGAnalysis.Subreports["FG_Pack_Supplier.rpt"].SetDataSource(dtPack_Supplier);
                            FGAnalysis.Subreports["FG_Analysis_Phy_Report.rpt"].SetDataSource(dtPhy);
                            FGAnalysis.Subreports["FG_Analysis_MicroTest.rpt"].SetDataSource(dtMicro);
                            FGAnalysis.Subreports["FG_Preservative_Loreal.rpt"].SetDataSource(dtPres_Loreal);
                            FGAnalysis.Subreports["FG_Preservative_Supplier.rpt"].SetDataSource(dtPres_Supplier);
                            
                            ReportViewer.ReportSource = FGAnalysis;
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
                txtProtocolNo.Text = "FG" + cmbDetails.SelectedValue.ToString().PadLeft(6, '0');
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