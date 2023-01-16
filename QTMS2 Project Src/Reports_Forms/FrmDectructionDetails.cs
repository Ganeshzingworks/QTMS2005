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
using BusinessFacade;


namespace QTMS.Reports_Forms
{
    public partial class FrmDectructionDetails : Form
    {
        public string rptName;

        public FrmDectructionDetails(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
        BusinessFacade.FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new BusinessFacade.FormulaNoMaster_Class();

        Reports.DestructionDetails_Report BulkTest = new QTMS.Reports.DestructionDetails_Report();
        # endregion

        private void FrmReport_Bulk_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            DtpTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpFrom.Value = DtpTo.Value.AddDays(-5);

            //Bind_Location();
        }

        public void Bind_Location()
        {
            string fromdate = "", todate = "";
            if (DtpFrom.Checked == true)
            {
                fromdate = DtpFrom.Value.ToShortDateString();
            }
            else
            {
                fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
            }

            if (DtpTo.Checked == true)
            {
                todate = DtpTo.Value.ToShortDateString();
            }
            else
            {
                todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
            }


            DataSet ds = new DataSet();
            DataRow dr;
            ds = new RetainerLocation_Class().Select_tblRetainerLocation_Destruction(fromdate,todate);
            dr = ds.Tables[0].NewRow();
            dr["Location"] = "--Select--";
            dr["LocationID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbLocation.DataSource = ds.Tables[0];
                CmbLocation.DisplayMember = "Location";
                CmbLocation.ValueMember = "LocationID";
            }
        }



        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbLocation.Text == "--Select--")
                {
                    MessageBox.Show("Select location !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    CmbLocation.Focus();
                    return;
                }

                pictureBox1.Visible = true;
                DataSet ds = new DataSet();

                Report_Class_Obj.fno = Convert.ToInt64(CmbLocation.SelectedValue);



                ds = Report_Class_Obj.Select_View_tblLocationDistruction_DetailReport();



                if (ds.Tables[0].Rows.Count > 0)
                {


                    ParameterFields ParaFields = new ParameterFields();

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

                    ParameterField Location = new ParameterField();
                    ParameterDiscreteValue LocationDescrete = new ParameterDiscreteValue();
                    Location.Name = "Location";
                    LocationDescrete.Value = CmbLocation.Text;
                    Location.CurrentValues.Add(LocationDescrete);
                    ParaFields.Add(Location);


                    ReportViewer.ParameterFieldInfo = ParaFields;

                    BulkTest.SetDataSource(ds.Tables[0]);
                    ReportViewer.ReportSource = BulkTest;
                    ReportViewer.ShowGroupTreeButton = false;
                    ReportViewer.DisplayGroupTree = false;
                    ReportViewer.Show();

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

        private void DtpFrom_ValueChanged(object sender, EventArgs e)
        {
            Bind_Location();
        }

        private void DtpTo_ValueChanged(object sender, EventArgs e)
        {
            Bind_Location();
        }






    }
}