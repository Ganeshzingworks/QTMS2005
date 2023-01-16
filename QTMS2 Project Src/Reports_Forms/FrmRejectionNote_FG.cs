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
using BusinessFacade.Transactions;
using System.IO;
using System.Net.Mail;
using System.Collections;


namespace QTMS.Reports_Forms
{
    public partial class FrmRejectionNote_FG : Form
    {
        public string rptName;

        public FrmRejectionNote_FG(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        Report_Class Report_Class_Obj = new Report_Class();
        UserData UserDataObj = new UserData();
        ReportDocument cryRpt;
        ArrayList lstReason = new ArrayList();

        string fgDesc, lineDesc, fgCode, BatchNoFG, Qty, fillDateFg = string.Empty;

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
        private void BindUserList()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = UserDataObj.Show_AllUser();

                chkLstUserName.DataSource = Dt;
                chkLstUserName.DisplayMember = "UserName";
                chkLstUserName.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = Report_Class_Obj.Select_RejectionNote_FG_Details();
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
                Reports.RejectionNote_FG RejectionNote_FG = new QTMS.Reports.RejectionNote_FG();

                DataSet ds = new DataSet();
                
                if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details...!", "Message");
                    return;
                }
                pictureBox1.Visible = true;
                Report_Class_Obj.fgtestno = Convert.ToInt64(cmbDetails.SelectedValue);

                switch (rptName)
                {
                    case "RejectionNote_FG":
                        ds = Report_Class_Obj.Select_View_RejectionNote_FG();
                        break;
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    switch (rptName)
                    {
                        case "RejectionNote_FG":

                            ParameterFields ParaFields = new ParameterFields();

                            ParameterField ParaTo = new ParameterField();
                            ParameterDiscreteValue ToDiscrete = new ParameterDiscreteValue();
                            ParaTo.Name = "To";
                            ToDiscrete.Value = txtTo.Text.Trim();
                            ParaTo.CurrentValues.Add(ToDiscrete);
                            ParaFields.Add(ParaTo);

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

                            string Formate = "";
                            if (GlobalVariables.City == "BADDI")
                                Formate = "Q82F-202-09-08";
                            else
                                Formate = "Q5F-202-07-08";

                            ParameterField FGRej_Formate = new ParameterField();
                            ParameterDiscreteValue FGRej_FormateDescrete = new ParameterDiscreteValue();
                            FGRej_Formate.Name = "FGRej_Formate";
                            FGRej_FormateDescrete.Value = Formate;
                            FGRej_Formate.CurrentValues.Add(FGRej_FormateDescrete);
                            ParaFields.Add(FGRej_Formate);

                            #endregion

                            ReportViewer.ParameterFieldInfo = ParaFields;

                            RejectionNote_FG.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = RejectionNote_FG;
                            ReportViewer.Show();

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                lstReason.Clear();
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    fgDesc = Convert.ToString(dr["FGDesc"]);
                                    lineDesc = Convert.ToString(dr["LineDesc"]);
                                    fgCode = Convert.ToString(dr["FGCode"]);
                                    BatchNoFG = Convert.ToString(dr["BatchNoFG"]);
                                    Qty = Convert.ToString(dr["Quantity"]);
                                    fillDateFg = Convert.ToString(dr["FillDateFG"]);
                                    lstReason.Add(dr["comment"]);
                                }

                                // Show user list in Checklist box to send mail to user ID
                                lblMailTo.Visible = true;
                                chkLstUserName.Visible = true;
                                BindUserList();
                                #region Send Mail report settings
                                // added on 21 DEc 2010 by Sanjiv Shinde

                                //Create the report object here and assign the rpt file object to this report document
                                cryRpt = new ReportDocument();
                                cryRpt = RejectionNote_FG;

                                //add the all parameters to newly created report document
                                cryRpt.SetParameterValue("CompanyName", GlobalVariables.companyName);
                                cryRpt.SetParameterValue("CompanyAddress", GlobalVariables.companyAddress);
                                cryRpt.SetParameterValue("To", txtTo.Text.Trim());
                                btnSendMail.Visible = true;
                                #endregion
                            }
                            else
                            {
                                lblMailTo.Visible = false;
                                chkLstUserName.Visible = false;
                                btnSendMail.Visible = false;
                            }

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

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                //User Mail Address 
                DataTable Dt = new DataTable();
                UserDataObj.userid = Convert.ToInt32(FrmMain.LoginID);
                Dt = UserDataObj.Show_SelectedUser();

                if (Dt.Rows.Count > 0)
                {
                    UserDataObj.userMailID = Convert.ToString(Dt.Rows[0]["UserMailID"]);
                }
                else
                {
                    MessageBox.Show("User Mail ID not exist");
                    return;
                }

                string strUserName = String.Empty;
                int cnt,cntUser = 0;
                cnt = chkLstUserName.CheckedItems.Count;
                foreach (DataRowView userId in chkLstUserName.CheckedItems)
                {
                  
                    cntUser++;
                    UserDataObj.userid = Convert.ToInt32(userId[0]);
                    Dt = UserDataObj.Show_SelectedUser();
                    if (Dt.Rows.Count > 0)
                    {
                        strUserName += Convert.ToString(Dt.Rows[0]["UserMailID"]) + ",";            
                            
                    }

                    
                }

                strUserName = strUserName.TrimEnd(new char[] { ',' });
                
               
                //create the memory stream object for report document
                MemoryStream oStream;

                oStream = (MemoryStream)cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

                //reportDocument is the crystal report document object

                MailMessage email = new MailMessage();

                email.From = new MailAddress(UserDataObj.userMailID);

                email.To.Add(strUserName);

                //if (BusinessFacade.CheckValidMail.IsEmailValid(txtCC.Text.Trim()))
                //    email.CC.Add(txtCC.Text.Trim());

                email.Subject = "FG Rejection Note";

                string htmlString = string.Empty;

                htmlString = "Dear Sir/Madam,</br></br> Reasons for rejections </br></br>   <table border = 1 cellspacing = 5 > <tr><td><b>PRODUCT :</b></td><td>" + fgDesc + " </td><td><b>LINE NO :</b></td><td>" + lineDesc + "</td></tr><tr><td ><b>FG CODE :</b></td><td>" + fgCode + "</td><td><b>Batch No FG :</b></td><td>" + BatchNoFG + "</td></tr><tr><td><b>QUANTITY :</b></td><td>" + Qty + "</td><td ><b>PKD. ON :</b></td><td>" + fillDateFg + "</td></tr></table> </br></br>";

                htmlString += "<table  border = 1 cellspacing = 5 > <tr><td>No</td> <td>Reasons</td></tr> ";
                for (int i = 0; i < lstReason.Count; i++)
                {
                    htmlString += "<tr><td>" + Convert.ToString(i + 1) + " </td><td>" + lstReason[i].ToString() + "</td></tr>";
                }
                htmlString += "</table>";
                // htmlString = htmlString.TrimEnd(new char[]{','});
                email.Body = htmlString;//  "<b>FG has been rejected due to [Reason]";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.High;

                email.Attachments.Add(new System.Net.Mail.Attachment(oStream, "FG Reject Note.pdf"));

                //create the SMTP client object and assign the all details here

                System.Net.Configuration.SmtpSection smtpSettings = (System.Net.Configuration.SmtpSection)System.Configuration.ConfigurationSettings.GetConfig("system.net/mailSettings/smtp");
                SmtpClient smtpClient = new SmtpClient();
                // smtpClient.Host = Convert.ToString("mail.kairee.in");

                smtpClient.Host = smtpSettings.Network.Host;

                smtpClient.Send(email);
                MessageBox.Show("Mail sent sucessfully!");
                for (int i = 0; i < chkLstUserName.Items.Count; i++)
                {
                    chkLstUserName.SetItemChecked(i, false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


    }
}