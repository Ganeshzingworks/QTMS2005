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
using BusinessFacade.Scoop_Class;

namespace QTMS.Scoop.ReportForms
{
    public partial class FrmFGAnalysis_Report : Form
    {

        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        Scoop_Report_Class scoopReport_Obj=new Scoop_Report_Class();
        # endregion

        public FrmFGAnalysis_Report()
        {
            InitializeComponent();
        }

        private void FrmFGAnalysis_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            Bind_Details();

        }

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = scoopReport_Obj.Select_tblFGTLF_Details_Scoop();
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
           
            if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
            {
                MessageBox.Show("Please Select Details...!", "Message");
                return;
            }

            Report.FG_Analysis_Report rpt = new QTMS.Scoop.Report.FG_Analysis_Report();
            //Report.FG_Analysis_Transaction_Report rpt = new QTMS.Scoop.Report.FG_Analysis_Transaction_Report();

            scoopReport_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
            DataSet ds_FGdetail = new DataSet();

            ds_FGdetail = scoopReport_Obj.Select_View_FG_AnalysisReport_Scoop();

            if (ds_FGdetail.Tables.Count > 0)
            {
                if (ds_FGdetail.Tables[0].Rows.Count > 0)
                {                  
                    pictureBox1.Visible = true;

                    string scoopProtocol = "SCOOP " + Convert.ToString(ds_FGdetail.Tables[0].Rows[0]["UPID"]).PadLeft(6, '0');
                    scoopReport_Obj.upid = Convert.ToInt64(ds_FGdetail.Tables[0].Rows[0]["UPID"]);
                    
                    DataSet dsSubrprt = new DataSet();
                    DataSet dsSubrprt2 = new DataSet();
                    DataSet dsSubrprt3 = new DataSet();
                    DataSet dsSubrprt4 = new DataSet();
                    DataSet dsSubrprt5 = new DataSet();


                    //dsSubrprt = scoopReport_Obj.Select_VIew_FG_Analysis_SamplingTest_Report_1();
                    dsSubrprt = scoopReport_Obj.Select_VIew_FG_Analysis_SamplingTest_Report();
                    dsSubrprt2 = scoopReport_Obj.Select_VIew_FG_Analysis_SamplingYellowTest_Report();
                    dsSubrprt3 = scoopReport_Obj.Select_VIew_FG_Analysis_SamplingRedTest_Report();
                    dsSubrprt4 = scoopReport_Obj.Select_VIew_FG_Analysis_SamplingGreenTest_Report();
                    dsSubrprt5 = scoopReport_Obj.Select_VIew_FG_Analysis_OBS_Report();

                    #region CompanyName and Address

                    ParameterFields param1Fields = new ParameterFields();


                    ParameterField CompanyName = new ParameterField();
                    ParameterDiscreteValue CompanyNameDescrete = new ParameterDiscreteValue();
                    CompanyName.Name = "CompanyName";
                    CompanyNameDescrete.Value = GlobalVariables.companyName;
                    CompanyName.CurrentValues.Add(CompanyNameDescrete);
                    param1Fields.Add(CompanyName);

                    ParameterField UserLogedIn = new ParameterField();
                    ParameterDiscreteValue UserLogedInDescrete = new ParameterDiscreteValue();
                    UserLogedIn.Name = "UserLogedIn";
                    UserLogedInDescrete.Value = GlobalVariables.uname;
                    UserLogedIn.CurrentValues.Add(UserLogedInDescrete);
                    param1Fields.Add(UserLogedIn);

                    ParameterField CompanyAddress = new ParameterField();////UserLogedIn
                    ParameterDiscreteValue CompanyAddressDescrete = new ParameterDiscreteValue();
                    CompanyAddress.Name = "CompanyAddress";
                    CompanyAddressDescrete.Value = GlobalVariables.companyAddress;
                    CompanyAddress.CurrentValues.Add(CompanyAddressDescrete);
                    param1Fields.Add(CompanyAddress);

                    #endregion

                    ParameterField ParaProtocolNo = new ParameterField();
                    ParameterDiscreteValue ProtocolNoDiscrete = new ParameterDiscreteValue();
                    ParaProtocolNo.Name = "ProtocolNo";
                    ProtocolNoDiscrete.Value = scoopProtocol;
                    ParaProtocolNo.CurrentValues.Add(ProtocolNoDiscrete);
                    param1Fields.Add(ParaProtocolNo);


                    rpt.SetDataSource(ds_FGdetail.Tables[0]);

                    //rpt.Database.Tables[0].SetDataSource(ds_FGdetail.Tables[0]);
                    rpt.Subreports["SCOOP_SamplingPointTest_Report"].SetDataSource(dsSubrprt.Tables[0]);
                    //rpt.Subreports["Sampling_Transaction.rpt"].SetDataSource(dsSubrprt.Tables[0]);


                    rpt.Subreports["YELLOW"].SetDataSource(dsSubrprt2.Tables[0]);
                    rpt.Subreports["RED"].SetDataSource(dsSubrprt3.Tables[0]);
                    rpt.Subreports["GREEN"].SetDataSource(dsSubrprt4.Tables[0]);
                    rpt.Subreports["Obeservation.rpt"].SetDataSource(dsSubrprt5.Tables[0]);
                   

                    ReportViewer.ParameterFieldInfo = param1Fields;
                    ReportViewer.ReportSource = rpt;
                    ReportViewer.Show();

                    pictureBox1.Visible = false;
                }
                else
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("No record available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                pictureBox1.Visible = false;
                MessageBox.Show("No record available", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
          

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}