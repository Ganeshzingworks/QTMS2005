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
    public partial class FrmLotDossierReportSF : Form
    {
        public string rptName;
        public bool rptDisplayed = false;

        public FrmLotDossierReportSF(string RptName)
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

        private void FrmLotDossierReportSF_Load(object sender, EventArgs e)
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
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "FGTestNo";
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
                cmbInspectedBy.DataSource = ds.Tables[0];
                cmbInspectedBy.DisplayMember = "UserName";
                cmbInspectedBy.ValueMember = "UserID";
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
                Reports.LotDossierReport LotDossier = new QTMS.Reports.LotDossierReport();
                Reports.LotDossierDetail_Report LotDossierDetail = new QTMS.Reports.LotDossierDetail_Report();

                DataSet ds = new DataSet();

                if (cmbDetails.Text == "--Select--" )
                {
                    MessageBox.Show("Please Select Details...!", "Message");
                    return;
                }

                Report_Class_Obj.fgtestno = Convert.ToInt64(cmbDetails.SelectedValue);
                         


                switch (rptName)
                {
                    case "LotDossier":
                        ds = Report_Class_Obj.Select_VIEW_LotDossier_Report_SF();

                        DataSet dsCnt = new DataSet();
                        dsCnt = Report_Class_Obj.Select_tblLinkTLF_FGTestNo();

                        if (ds.Tables[0].Rows.Count != dsCnt.Tables[0].Rows.Count)
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

                    case "LotDossierDetail":
                        //----- same as above --------
                        ds = Report_Class_Obj.Select_VIEW_LotDossier_Report_2();

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
                    ParameterFields param1Fields = new ParameterFields();
                    ParameterField ProtocolNo = new ParameterField();
                    ParameterDiscreteValue ProtocolNoDescrete = new ParameterDiscreteValue();
                    ProtocolNo.Name = "ProtocolNo";
                    ProtocolNoDescrete.Value = txtProtocolNo.Text.Trim();
                    ProtocolNo.CurrentValues.Add(ProtocolNoDescrete);

                    param1Fields.Add(ProtocolNo);
                    ReportViewer.ParameterFieldInfo = param1Fields;

                    switch (rptName)
                    {
                        case "LotDossier":

                            LotDossier.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = LotDossier;
                            ReportViewer.Show();
                            break;

                        case "LotDossierDetail":

                            LotDossierDetail.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = LotDossierDetail;
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

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtProtocolNo.Text = "";
            if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "0")
            {
                reset();

                txtProtocolNo.Text = "LOT" + cmbDetails.SelectedValue.ToString().PadLeft(6, '0');
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

            MessageBox.Show("Lot Dossier Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            BtnShow_Click(sender, e);
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}