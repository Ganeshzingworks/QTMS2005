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
    public partial class FrmLotDossierReport : Form
    {
        public string rptName;
        public bool rptDisplayed = false;
        Int64? UPId;
        BusinessFacade.Scoop_Class.UPMaster_Class UPMaster_Class_Obj = new BusinessFacade.Scoop_Class.UPMaster_Class();

        public FrmLotDossierReport(string RptName)
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
            Bind_InspectedBy();
            reset();
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
                //cmbDetails.DataSource = ds.Tables[0];
                //cmbDetails.DisplayMember = "Details";
                //cmbDetails.ValueMember = "FGTestNo";

                cmbDetails.ValueMember = "FGTestNo";
                cmbDetails.DisplayMember = "Details";
                cmbDetails.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_InspectedBy()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = UserManagement_Class_Obj.Select_AllUser();
            dr = ds.Tables[0].NewRow();
            dr["UserName"] = "--Select--";
            dr["UserID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbInspectedBy.ValueMember = "UserID";
                cmbInspectedBy.DisplayMember = "UserName";
                cmbInspectedBy.DataSource = ds.Tables[0];
            }
        }

        public void reset()
        {
            cmbRelease.Text = "Yes";
            RdoAccept.Checked = false;
            RdoReject.Checked = false;
            DtpDateOfRelease.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateOfRelease.Checked = false;  
            cmbInspectedBy.Text = "--Select--";
            txtCommnet.Text = "";
            rptDisplayed = false;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                //Reports.LotDossierReport LotDossier = new QTMS.Reports.LotDossierReport();          
                Reports.LotDossierReport_2New LotDossier = new QTMS.Reports.LotDossierReport_2New();
                Reports.LotDossierReport_2New_Baddi LotDossier_Baddi = new QTMS.Reports.LotDossierReport_2New_Baddi();    
                Reports.LotDossierDetail_Report LotDossierDetail = new QTMS.Reports.LotDossierDetail_Report();

                DataSet ds = new DataSet();

                if (cmbDetails.Text == "--Select--" && DtpDateFrom.Checked == false && DtpDateTo.Checked == false)
                {
                    MessageBox.Show("Please Select Details or date...!", "Message");
                    return;
                }

                if (cmbDetails.Text == "--Select--")
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
                pictureBox1.Visible = true;
                switch (rptName)
                {
                    case "LotDossier":
                        //ds = Report_Class_Obj.Select_VIEW_LotDossier_Report_2();
                        ds = Report_Class_Obj.Select_VIEW_LotDossier_Report_2NEW();

                        DataSet dsCnt = new DataSet();
                        dsCnt = Report_Class_Obj.Select_tblLinkTLF_FGTestNo();

                        if (ds.Tables[0].Rows.Count != dsCnt.Tables[0].Rows.Count)
                        {
                            MessageBox.Show("Some tests are pending...!\nPlease check in PreLot Dossier", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            rptDisplayed = false;
                            pictureBox1.Visible = false;
                            return;
                        }
                        else
                        {
                            rptDisplayed = true;
                        }

                        if (ds.Tables.Count>0)
                        {
                            if (ds.Tables[0].Rows.Count>0)
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["UPID"])))
                                {
                                    UPId = Convert.ToInt64(ds.Tables[0].Rows[0]["UPID"]);
                                }
                                else
                                {
                                    UPId = 0;
                                }
                               
                                if (ds.Tables[0].Rows[0]["Status"] is DBNull)
                                {
                                    
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Status"])))
                                    {
                                        if (Convert.ToString(ds.Tables[0].Rows[0]["Status"]) == "A")
                                        {
                                            RdoAccept.Checked = true;
                                        }
                                        else
                                        {
                                            RdoReject.Checked = true;
                                        }
                                    }
                                }
                                if (ds.Tables[0].Rows[0]["ReleasedBy"] is DBNull)
                                {

                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["ReleasedBy"])))
                                    {
                                        cmbInspectedBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReleasedBy"]);
                                    }
                                }
                                if (ds.Tables[0].Rows[0]["Comment"] is DBNull)
                                {

                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Comment"])))
                                    {
                                        txtCommnet.Text = Convert.ToString(ds.Tables[0].Rows[0]["Comment"]);
                                    }
                                }
                                if (ds.Tables[0].Rows[0]["DateOfRelease"] is DBNull)
                                {

                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DateOfRelease"])))
                                    {
                                        DtpDateOfRelease.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfRelease"]);
                                    }
                                }

                            }
                        }
                        

                        break;

                    case "LotDossierDetail":
                        //----- same as above --------
                        ds = Report_Class_Obj.Select_VIEW_LotDossier_Report_2();
                        UPId = 0;
                        DataSet dsCnt1 = new DataSet();
                        dsCnt1 = Report_Class_Obj.Select_tblLinkTLF_FGTestNo();

                        if (ds.Tables[0].Rows.Count != dsCnt1.Tables[0].Rows.Count)
                        {
                            MessageBox.Show("Some tests are pending...!\nPlease check in PreLot Dossier", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            rptDisplayed = false;
                            return;
                        }
                        else
                        {
                            rptDisplayed = true;
                        }

                        break;
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["UPID"])))
                    //{
                    //    UPId = Convert.ToInt64(ds.Tables[0].Rows[0]["UPID"]);
                    //}
                    //else
                    //{
                       //UPId = 0;
                    //}

                    

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
                        case "LotDossier":
                            if (GlobalVariables.City == "BADDI")
                            {
                                LotDossier_Baddi.SetDataSource(ds.Tables[0]);
                                ReportViewer.ReportSource = LotDossier_Baddi;
                                ReportViewer.Show();
                            }
                            else
                            {
                                LotDossier.SetDataSource(ds.Tables[0]);
                                ReportViewer.ReportSource = LotDossier;
                                ReportViewer.Show();
                            }
                            break;

                        case "LotDossierDetail":

                            LotDossierDetail.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = LotDossierDetail;
                            ReportViewer.Show();
                            break;
                    }

                    pictureBox1.Visible = false;
                }
                else
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Sorry Record Not Found...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

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
                reset();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--All--")
            {
                MessageBox.Show("Please Select Details...!", "Message");
                cmbDetails.Focus();
                return;
            }
            if (rptDisplayed == false)
            {
                MessageBox.Show("Report not displayed...!", "Message");                
                return;
            }
            if (RdoAccept.Checked == false && RdoReject.Checked == false)
            {
                MessageBox.Show("Please Select Status...!", "Message");
                return;
            }
            if (DtpDateOfRelease.Checked == false)
            {
                MessageBox.Show("Please Select Date of Release...!", "Message");
                DtpDateOfRelease.Focus();
                return;
            }
            if (cmbInspectedBy.Text == "--Select--")
            {
                MessageBox.Show("Please Inspected By...!", "Message");
                cmbInspectedBy.Focus();
                return;
            }

            LotDossier_Class_Obj.fgtestno = Convert.ToInt64(cmbDetails.SelectedValue);

            if (cmbRelease.Text == "Yes")
            {
                LotDossier_Class_Obj.release = 'Y';
            }
            else if (cmbRelease.Text == "No")
            {
                LotDossier_Class_Obj.release = 'N';
            }

            if (RdoAccept.Checked == true)
            {
                LotDossier_Class_Obj.status = 'A';
            }
            else if (RdoReject.Checked == true)
            {
                LotDossier_Class_Obj.status = 'R';
            }

            LotDossier_Class_Obj.dateofrelease = DtpDateOfRelease.Value.ToShortDateString();

            LotDossier_Class_Obj.comment = txtCommnet.Text.Trim();
            LotDossier_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

            DataSet ds = new DataSet();
            ds = LotDossier_Class_Obj.Select_tblLotDossier_FGTestNo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                LotDossier_Class_Obj.Update_tblLotDossier();
            }
            else
            {
                LotDossier_Class_Obj.Insert_tblLotDossier();
            }

            if (UPId != 0)
            {
                UPMaster_Class_Obj.upid = (Int64)UPId;
                UPMaster_Class_Obj.finalComment = txtCommnet.Text.Trim();
                UPMaster_Class_Obj.finalStatus = LotDossier_Class_Obj.status;
                UPMaster_Class_Obj.finalInspectedBy = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                UPMaster_Class_Obj.Update_UPMasterFinal();
            }

            MessageBox.Show("Lot Dossier Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            BtnShow_Click(sender, e);
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
       

        
    }
}