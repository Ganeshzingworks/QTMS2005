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
    public partial class FrmMicrobiology_Report : Form
    {
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();

        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        # endregion
        public string rptName;
        //Binds the pending Finished good details those entered in 
        public void Bind_Details()
        {
            DateTime dtFromDate = DateTime.Now;
            DateTime dtTodate = DateTime.Now;
            try
            {
                if (DtpDateFrom.Checked == true)
                {
                    dtFromDate =  Convert.ToDateTime(DtpDateFrom.Value.ToShortDateString());
                }
                else
                {
                    dtFromDate = Convert.ToDateTime("1/1/1900 12:00:00 AM");
                }

                if (DtpDateTo.Checked == true)
                {
                    dtTodate = Convert.ToDateTime(DtpDateTo.Value.ToShortDateString()); ;
                }
                else
                {
                    dtTodate = Convert.ToDateTime("6/6/2079 11:59:59 PM");
                }
               
                DataSet ds = new DataSet();
                DataRow dr;
                ds = FinishedGoodTest_Class_Obj.Select_DoneFinishedGoodDetails(dtFromDate,dtTodate);
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--ALL--";
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

        public FrmMicrobiology_Report(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
            Bind_Details();
            if (RptName.Equals("MicrobiologyTDB"))
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
            if (rdbClearDate.Checked == true)
            {
                cmbDetails.Visible = false;
                label12.Visible = false;
            }
            else
            {
                cmbDetails.Visible = true;
                label12.Visible = true;
            }
        }


        private void Bind_ManufacturedBy()
        {
            try
            {
                LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
                DataSet ds = LineMaster_Class_Obj.Select_Manufacturer();
                DataRow dr1 = ds.Tables[0].NewRow();
                dr1["ManufacturedById"] = "0";
                dr1["ManufacturerName"] = "All";
                ds.Tables[0].Rows.InsertAt(dr1, 0);

                //DataRow dr = ds.Tables[0].NewRow();
                //dr["ManufacturedById"] = ds.Tables[0].Rows.Count + 1;
                //dr["ManufacturerName"] = "ALL";
                //ds.Tables[0].Rows.InsertAt(dr, ds.Tables[0].Rows.Count);
                cmbManuBy.DataSource = ds.Tables[0];
                cmbManuBy.DisplayMember = "ManufacturerName";
                cmbManuBy.ValueMember = "ManufacturedById";
            }
            catch (Exception)
            {
                MessageBox.Show("Record Not Found");
            }
        }

        private void FrmLotDossier_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);


            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
            if (this.rptName == "RMMicrobiologyTest")
                rdbTrackCode.Text = "ReceiptDate";
            else
                rdbTrackCode.Text = "TrackCode";

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Visible = true;
                if (rptName.Equals("MicrobiologyTDB"))
                {
                    //if (cmbManuBy.SelectedIndex==0)
                    //{
                    //    MessageBox.Show("Please Select Manufactured On");
                    //    return;
                    //}
                    //else
                    {
                        #region MyRegion
                        Reports.MicrobiologyTest_Report MicrobiologyTest = new QTMS.Reports.MicrobiologyTest_Report();
                        Reports.MicrobiologyTDB_Report MicrobiologyTDB = new QTMS.Reports.MicrobiologyTDB_Report();
                        Reports.MicrobiologySummary_Report MicrobiologySummary = new QTMS.Reports.MicrobiologySummary_Report();
                        Reports.RMMicrobiologyTest_Report RMMicrobiologyTest = new QTMS.Reports.RMMicrobiologyTest_Report();

                        DataSet ds = new DataSet();
                        DataTable dt = new DataTable();
                        DataTable dt1 = new DataTable();
                        DataTable dt2 = new DataTable();
                        DataTable dt3 = new DataTable();


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
                        if (rdbClearDate.Checked == true)
                        {
                            Report_Class_Obj.withdate = "ClearDate";
                        }
                        else
                        {
                            Report_Class_Obj.withdate = "TrackCode";
                        }

                        switch (rptName)
                        {
                            case "MicrobiologyTest":
                                ds = Report_Class_Obj.Select_VIEW_MicrobiologyTest_Reports();
                                break;

                            case "MicrobiologyTDB":
                                ds = Report_Class_Obj.Select_VIEW_MicrobiologyTDB_Reports();
                                break;

                            case "MicrobiologySummary":
                                ds = Report_Class_Obj.Select_VIEW_MicrobiologySummary_Reports();
                                break;
                            case "RMMicrobiologyTest":
                                if (rdbClearDate.Checked == true)
                                {
                                    Report_Class_Obj.withdate = "ClearDate";
                                }
                                else
                                {
                                    Report_Class_Obj.withdate = "ReceiptDate";
                                }
                                ds = Report_Class_Obj.Select_RMMicrobiologyTest_Reports();
                                break;
                        }

                        if (ds.Tables[0].Rows.Count > 0)
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
                            if (rptName.Equals("MicrobiologyTDB"))
                            {
                                ParameterField ManuBy = new ParameterField();
                                ParameterDiscreteValue ManuByDescrete = new ParameterDiscreteValue();
                                ManuBy.Name = "ManufacturedBy";
                                if (Convert.ToInt32(cmbManuBy.SelectedValue) < 3)
                                {
                                    ManuByDescrete.Value = cmbManuBy.Text.Trim();
                                }
                                else
                                {
                                    ManuByDescrete.Value = "";
                                }
                                //ManuByDescrete.Value = cmbManuBy.Text;
                                ManuBy.CurrentValues.Add(ManuByDescrete);
                                param1Fields.Add(ManuBy);
                            }
                            ReportViewer.ParameterFieldInfo = param1Fields;

                            switch (rptName)
                            {
                                case "MicrobiologyTest":

                                    MicrobiologyTest.SetDataSource(ds.Tables[0]);
                                    ReportViewer.ReportSource = MicrobiologyTest;
                                    ReportViewer.Show();
                                    break;

                                case "MicrobiologyTDB":

                                    MicrobiologyTDB.SetDataSource(ds.Tables[0]);
                                    ReportViewer.ReportSource = MicrobiologyTDB;
                                    ReportViewer.Show();
                                    break;

                                case "MicrobiologySummary":

                                    MicrobiologySummary.SetDataSource(ds.Tables[0]);
                                    ReportViewer.ReportSource = MicrobiologySummary;
                                    ReportViewer.Show();
                                    break;
                                case "RMMicrobiologyTest":
                                    RMMicrobiologyTest.SetDataSource(ds.Tables[0]);
                                    ReportViewer.ReportSource = RMMicrobiologyTest;
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
                        #endregion
                    }
                }
                else
                {
                    #region MyRegion
                    Reports.MicrobiologyTest_Report MicrobiologyTest = new QTMS.Reports.MicrobiologyTest_Report();
                    Reports.MicrobiologyTDB_Report MicrobiologyTDB = new QTMS.Reports.MicrobiologyTDB_Report();
                    Reports.MicrobiologySummary_Report MicrobiologySummary = new QTMS.Reports.MicrobiologySummary_Report();
                    Reports.RMMicrobiologyTest_Report RMMicrobiologyTest = new QTMS.Reports.RMMicrobiologyTest_Report();

                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();
                    DataTable dt3 = new DataTable();


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
                    if (rdbClearDate.Checked == true)
                    {
                        Report_Class_Obj.withdate = "ClearDate";
                    }
                    else
                    {
                        Report_Class_Obj.withdate = "TrackCode";
                    }

                    switch (rptName)
                    {
                        case "MicrobiologyTest":
                          //  Report_Class_Obj.fgtlfid = cmbDetails.SelectedValue;
                            //chnaged by sanjiv on 2-Jun-2014 for getting tlfid. split cmbDetails.SelectedValue by $ and first part is FGTLFID and second part is TLFid
                            if (Convert.ToString(cmbDetails.SelectedValue) == "0")
                            {
                                Report_Class_Obj.tlfid = 0;
                            }
                            else
                            {
                                String[] tlfid = Convert.ToString(cmbDetails.SelectedValue).Split(new char[] { '$' });
                                Report_Class_Obj.tlfid = Convert.ToInt32(tlfid[1]);
                            }
                            ds = Report_Class_Obj.Select_VIEW_MicrobiologyTest_Reports();
                            break;

                        case "MicrobiologyTDB":
                            ds = Report_Class_Obj.Select_VIEW_MicrobiologyTDB_Reports();
                            break;

                        case "MicrobiologySummary":
                            ds = Report_Class_Obj.Select_VIEW_MicrobiologySummary_Reports();
                            break;
                        case "RMMicrobiologyTest":
                            if (rdbClearDate.Checked == true)
                            {
                                Report_Class_Obj.withdate = "ClearDate";
                            }
                            else
                            {
                                Report_Class_Obj.withdate = "ReceiptDate";
                            }
                            ds = Report_Class_Obj.Select_RMMicrobiologyTest_Reports();
                            break;
                    }

                    if (ds.Tables[0].Rows.Count > 0)
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
                        if (rptName.Equals("MicrobiologyTDB"))
                        {
                            ParameterField ManuBy = new ParameterField();
                            ParameterDiscreteValue ManuByDescrete = new ParameterDiscreteValue();
                            ManuBy.Name = "ManufacturedBy";
                            if (Convert.ToInt32(cmbManuBy.SelectedValue) < 3)
                            {
                                ManuByDescrete.Value = cmbManuBy.Text.Trim();
                            }
                            else
                            {
                                ManuByDescrete.Value = "";
                            }
                            //ManuByDescrete.Value = cmbManuBy.Text;
                            ManuBy.CurrentValues.Add(ManuByDescrete);
                            param1Fields.Add(ManuBy);
                        }
                        ReportViewer.ParameterFieldInfo = param1Fields;

                        switch (rptName)
                        {
                            case "MicrobiologyTest":

                                MicrobiologyTest.SetDataSource(ds.Tables[0]);
                                ReportViewer.ReportSource = MicrobiologyTest;
                                ReportViewer.Show();
                                break;

                            case "MicrobiologyTDB":

                                MicrobiologyTDB.SetDataSource(ds.Tables[0]);
                                ReportViewer.ReportSource = MicrobiologyTDB;
                                ReportViewer.Show();
                                break;

                            case "MicrobiologySummary":

                                MicrobiologySummary.SetDataSource(ds.Tables[0]);
                                ReportViewer.ReportSource = MicrobiologySummary;
                                ReportViewer.Show();
                                break;
                            case "RMMicrobiologyTest":
                                RMMicrobiologyTest.SetDataSource(ds.Tables[0]);
                                ReportViewer.ReportSource = RMMicrobiologyTest;
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
                    #endregion
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

        private void rdbClearDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbClearDate.Checked == true)
            {
                cmbDetails.Visible = false;
                label12.Visible = false;
            }

        }

        private void rdbTrackCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTrackCode.Checked == true)
            {
                cmbDetails.Visible = true;
                label12.Visible = true;
                Bind_Details();
            }

        }

        private void DtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void DtpDateTo_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void DtpDateFrom_CloseUp(object sender, EventArgs e)
        {
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
            if (rdbTrackCode.Checked == true)
            {
                Bind_Details();
            }
        }

        private void DtpDateTo_CloseUp(object sender, EventArgs e)
        {
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
            if (rdbTrackCode.Checked == true)
            {
                Bind_Details();
            }
        }

    }
}