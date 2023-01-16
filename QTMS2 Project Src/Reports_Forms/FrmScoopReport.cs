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
using QTMS.Scoop.Report;
using BusinessFacade;


namespace QTMS.Reports_Forms
{
    public partial class FrmScoopReport : Form
    {
        public string rptName;

        BusinessFacade.Scoop_Class.Scoop_Report_Class Scoop_Report_Class_Obj = new BusinessFacade.Scoop_Class.Scoop_Report_Class();
        public FrmScoopReport(string RptName)
        {
            InitializeComponent();
            this.rptName = RptName;
        }

        private void FrmScoopReport_Load(object sender, EventArgs e)
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

            this.ReportViewer.RefreshReport();
            if (rptName.Equals("GlobalFGTDB") || rptName.Equals("FGLineTDB"))
            {
                lblManuby.Visible = true;
                cmbManuBy.Visible = true;
                Bind_ManufacturedBy();
            }
            else
            {
                lblManuby.Visible = false;
                cmbManuBy.Visible = false;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Bind_ManufacturedBy()
        {
            try
            {
                LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
                DataSet ds = LineMaster_Class_Obj.Select_Manufacturer();
                DataRow dr1 = ds.Tables[0].NewRow();
                dr1["ManufacturedById"] = "0";
                dr1["ManufacturerName"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr1, 0);

                DataRow dr = ds.Tables[0].NewRow();
                dr["ManufacturedById"] = ds.Tables[0].Rows.Count + 1;
                dr["ManufacturerName"] = "ALL";
                ds.Tables[0].Rows.InsertAt(dr, ds.Tables[0].Rows.Count);
                cmbManuBy.DataSource = ds.Tables[0];
                cmbManuBy.DisplayMember = "ManufacturerName";
                cmbManuBy.ValueMember = "ManufacturedById";
            }
            catch (Exception)
            {
                MessageBox.Show("Record Not Found");
            }
        }
        private void BtnShow_Click(object sender, EventArgs e)
        {
            if (cmbManuBy.SelectedIndex>0)
            {
                pictureBox1.Visible = true;
                Scoop_FG_TDB_Report ScoopFgTDB_rpt_Obj = null;// new QTMS.Reports.Scoop_FG_TDB_Report();
                Scoop_FGLine_Detail_TDB_Report Scoop_FGLine_Detail_TDB_Rpt_Obj = null;
                DataSet ds = new DataSet();
                if (DtpDateFrom.Checked == true)
                {
                    System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

                    String fromdate = Convert.ToDateTime(DtpDateFrom.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");
                    Scoop_Report_Class_Obj.fromdate = fromdate + " 12:00:00 AM";
                }
                else
                {
                    Scoop_Report_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpDateTo.Checked == true)
                {

                    System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

                    String todate = Convert.ToDateTime(DtpDateTo.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");

                    Scoop_Report_Class_Obj.todate = todate +" 11:59:59 PM";

                }
                else
                {
                    Scoop_Report_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }
                Scoop_Report_Class_Obj.MfgById = Convert.ToInt32(cmbManuBy.SelectedValue);
                switch (rptName)
                {
                    case "GlobalFGTDB":
                        ds = Scoop_Report_Class_Obj.SElect_VIEW_Global_FG_TDB_Report_Scoop();
                        break;

                    case "FGLineTDB":
                        ds = Scoop_Report_Class_Obj.SElect_VIEW_Global_FG_TDB_Report_Scoop();
                        break;
                }

                if (ds.Tables[0].Rows.Count > 0)
                {

                    switch (rptName)
                    {

                        case "GlobalFGTDB":
                            ScoopFgTDB_rpt_Obj = new Scoop_FG_TDB_Report();
                            ScoopFgTDB_rpt_Obj.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = ScoopFgTDB_rpt_Obj;
                            ScoopFgTDB_rpt_Obj.SetParameterValue("FromDate", DtpDateFrom.Value.ToShortDateString());
                            ScoopFgTDB_rpt_Obj.SetParameterValue("ToDate", DtpDateTo.Value.ToShortDateString());
                            ScoopFgTDB_rpt_Obj.SetParameterValue("CompanyName", GlobalVariables.companyName);
                            ScoopFgTDB_rpt_Obj.SetParameterValue("CompanyAddress", GlobalVariables.companyAddress);
                            ScoopFgTDB_rpt_Obj.SetParameterValue("ManufacturedBy", cmbManuBy.Text.Trim());
                            ReportViewer.Show();
                            break;

                        case "FGLineTDB":
                            Scoop_FGLine_Detail_TDB_Rpt_Obj = new Scoop_FGLine_Detail_TDB_Report();
                            Scoop_FGLine_Detail_TDB_Rpt_Obj.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = Scoop_FGLine_Detail_TDB_Rpt_Obj;
                            Scoop_FGLine_Detail_TDB_Rpt_Obj.SetParameterValue("FromDate", DtpDateFrom.Value.ToShortDateString());
                            Scoop_FGLine_Detail_TDB_Rpt_Obj.SetParameterValue("ToDate", DtpDateTo.Value.ToShortDateString());
                            Scoop_FGLine_Detail_TDB_Rpt_Obj.SetParameterValue("CompanyName", GlobalVariables.companyName);
                            Scoop_FGLine_Detail_TDB_Rpt_Obj.SetParameterValue("CompanyAddress", GlobalVariables.companyAddress);

                            ReportViewer.Show();
                            break;
                    }
                }
                else
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Record Not Found");
                }
                pictureBox1.Visible = false;
            }
            else
            {
                pictureBox1.Visible = false;
                MessageBox.Show("Please Select Manfactured By");
            }
        }
    }
}