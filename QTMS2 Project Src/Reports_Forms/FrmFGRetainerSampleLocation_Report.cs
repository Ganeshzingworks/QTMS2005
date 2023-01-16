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
    public partial class FrmFGRetainerSampleLocation_Report : Form
    {
        public string rptName;

        public FrmFGRetainerSampleLocation_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
        BusinessFacade.FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new BusinessFacade.FinishedGoodMaster_Class();
        //BusinessFacade.FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new BusinessFacade.FormulaNoMaster_Class();
        Reports.FGRetainerSampleLocation_Report Retainer_Location = null;
        Reports.FGRetainerSampleLocation_Report_Pune Retainer_Location_Pune = null;
        Reports.PendingDestructLocation PendingDestruct_Location = null;
        # endregion

        private void FrmFormulaHistoryReport_Load(object sender, EventArgs e)
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
            //Bind_Formula();
            //Bind_FGCode();         

            if (rptName == "Pending Destructed Location")
            {
                //DtpDateFrom.Visible = 
                DtpDateTo.Visible = label1.Visible = label2.Visible = false;
                DtpDateFrom.Checked = true;
                //Report_Class_Obj.fromdate = DtpDateFrom.Value.ToShortDateString();
            }


            Bind_Location();
        }

        public void Bind_Location()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            if (rptName == "Pending Destructed Location")
                ds = new RetainerLocation_Class().Select_Distruct_tblRetainerLocation_Report(DtpDateFrom.Value);
            else
                ds = new RetainerLocation_Class().Select_tblRetainerLocation_Report();

            dr = ds.Tables[0].NewRow();
            dr["Location"] = "--ALL--";
            dr["LocationID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            CmbLocation.DataSource = ds.Tables[0];
            CmbLocation.DisplayMember = "Location";
            CmbLocation.ValueMember = "LocationID";
        }

        public void Bind_FGCode()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster();
            dr = ds.Tables[0].NewRow();
            dr["FGCode"] = "--ALL--";
            dr["FGNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbFGCode.DataSource = ds.Tables[0];
            cmbFGCode.DisplayMember = "FGCode";
            cmbFGCode.ValueMember = "FGNo";
        }
        public void Bind_Formula()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = BulktestDetailstransaction_Class_Qbj.Select_tblTransFM_tblBulkTestTransaction();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbFGCode.DataSource = ds.Tables[0];
            cmbFGCode.DisplayMember = "FormulaNo";
            cmbFGCode.ValueMember = "FNo";
        }

        private void cmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbFGCode.SelectedValue != null && cmbFGCode.SelectedValue.ToString() != "")
                {
                    DataRow dr;
                    DataSet ds = new DataSet();
                    BulktestDetailstransaction_Class_Qbj.fno = Convert.ToInt64(cmbFGCode.SelectedValue);
                    ds = BulktestDetailstransaction_Class_Qbj.Select_tblTransFM_MfgWo();
                    dr = ds.Tables[0].NewRow();
                    dr["MfgWo"] = "--ALL--";
                    dr["FMID"] = "0";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    cmbMfgWo.DataSource = ds.Tables[0];
                    cmbMfgWo.DisplayMember = "MfgWo";
                    cmbMfgWo.ValueMember = "FMID";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                DataSet ds = new DataSet();

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
                Report_Class_Obj.fgno = Convert.ToInt64(CmbLocation.SelectedValue);
                //Report_Class_Obj.fno = Convert.ToInt64(cmbFGCode.SelectedValue);

                //Report_Class_Obj.fmid = Convert.ToInt64(cmbMfgWo.SelectedValue);

                switch (rptName)
                {
                    case "Retainer Sample Location":
                        ds = Report_Class_Obj.Select_RetainerSampleLocation_Report();
                        break;
                    case "Pending Destructed Location":
                        ds = Report_Class_Obj.Select_PendingDesctructLocation_Report();
                        break;
                }


                if (ds.Tables[0].Rows.Count > 0)
                {
                    ParameterFields param1Fields = new ParameterFields();
                    ParameterField FromDate = new ParameterField();
                    ParameterField ToDate = new ParameterField();
                    ParameterField Distract = new ParameterField();
                    ParameterDiscreteValue FromDateDescrete = new ParameterDiscreteValue();
                    ParameterDiscreteValue ToDateDescrete = new ParameterDiscreteValue();
                    ParameterDiscreteValue DistractDescrete = new ParameterDiscreteValue();
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
                    Distract.Name = "Distract";
                    if (ds.Tables[0].Rows[0]["Distruction"].ToString() == "1")
                        DistractDescrete.Value = "Destructed Location";
                    else
                        DistractDescrete.Value = "";
                    Distract.CurrentValues.Add(DistractDescrete);

                    param1Fields.Add(FromDate);
                    param1Fields.Add(ToDate);
                    param1Fields.Add(Distract);

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
                        case "Retainer Sample Location":
                            if (GlobalVariables.City == "BADDI")
                            {
                                Retainer_Location = new QTMS.Reports.FGRetainerSampleLocation_Report();
                                Retainer_Location.SetDataSource(ds.Tables[0]);
                                ReportViewer.ReportSource = Retainer_Location;
                            }
                            else
                            {
                                Retainer_Location_Pune = new QTMS.Reports.FGRetainerSampleLocation_Report_Pune();
                                Retainer_Location_Pune.SetDataSource(ds.Tables[0]);
                                ReportViewer.ReportSource = Retainer_Location_Pune;
                            }

                            ReportViewer.Show();
                            break;
                        case "Pending Destructed Location":
                            if (GlobalVariables.City == "BADDI")
                            {
                                Retainer_Location = new QTMS.Reports.FGRetainerSampleLocation_Report();
                                Retainer_Location.SetDataSource(ds.Tables[0]);
                                ReportViewer.ReportSource = Retainer_Location;
                            }
                            else
                            {
                                PendingDestruct_Location = new QTMS.Reports.PendingDestructLocation();
                                PendingDestruct_Location.SetDataSource(ds.Tables[0]);
                                ReportViewer.ReportSource = PendingDestruct_Location;
                            }

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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (rptName == "Pending Destructed Location")
                Bind_Location();
        }









    }
}