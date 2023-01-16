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
using System.IO;
using System.Net.Mail;
using System.Web.UI;
using System.Collections;
using BusinessFacade;

namespace QTMS.Reports_Forms
{
    public partial class FrmPM_Note : Form
    {
        public string rptName;
        ReportDocument cryRpt;
        public FrmPM_Note(string RptName)
        {
            this.rptName = RptName;     
            InitializeComponent();
        }      

        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        Reports.RejectionNote_PM RejectionNote_PM = new QTMS.Reports.RejectionNote_PM();
        Reports.DefectNote_PM DefectNote_PM = new QTMS.Reports.DefectNote_PM();
        BusinessFacade.Transactions.UserData UserDataObj = new BusinessFacade.Transactions.UserData();
        GroupMaster_Class GroupMaster_Class_Obj = new GroupMaster_Class();
        bool flgDefectRejectionNote = false;
        ArrayList lstReason = new ArrayList();

        string PMDesc, PMLotNo, PMCode, challanNo, qty, mrr = string.Empty;

        #endregion

        private void FrmPMAnalysis_Report_Load(object sender, EventArgs e)
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
            if (rptName == "RejectionNote_PM")
            {
                ds = Report_Class_Obj.Select_RejectionNote_PM_Details();
            }
            else if (rptName == "DefectNote_PM")
            {
                ds = Report_Class_Obj.Select_DefectNote_PM_Details();
            }

            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            dr["PMTransID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbDetails.DataSource = ds.Tables[0];
            cmbDetails.DisplayMember = "Details";
            cmbDetails.ValueMember = "PMTransID";
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

        public void Bind_GroupNames()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = GroupMaster_Class_Obj.Select_tblSoftwareUserGroup();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    chkLstGroupName.DataSource = ds.Tables[0];
                    chkLstGroupName.DisplayMember = "GroupName";
                    chkLstGroupName.ValueMember = "GroupID";
                }
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
                if (cmbDetails.SelectedValue == null || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataSet ds = new DataSet();               
                Report_Class_Obj.pmtransid = Convert.ToInt64(cmbDetails.SelectedValue);

                switch (rptName)
                {

                    case "RejectionNote_PM":
                        ds = Report_Class_Obj.Select_View_RejectionNote_PM();                       
                        break;

                    case "DefectNote_PM":
                        ds = Report_Class_Obj.Select_View_DefectNote_PM();
                        break;

                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCC.Visible = false;
                    lblCC.Visible = false;
                    Report_Class_Obj.pmsupplierid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMSupplierID"]);// Get Supplier ID from the above query

                    ParameterFields ParaFields = new ParameterFields();

                    ParameterField ParaTo = new ParameterField();
                    ParameterDiscreteValue ToDiscrete = new ParameterDiscreteValue();
                    ParaTo.Name = "To";
                    ToDiscrete.Value = txtTo.Text.Trim();
                    ParaTo.CurrentValues.Add(ToDiscrete);
                    ParaFields.Add(ParaTo);

                    #region CompanyName and Address , FIName
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

                    // added on 27 Jan 2016 by Avinash S
                    // remove static FI name from report
                    if (rptName == "RejectionNote_PM")
                    {
                        ParameterField FIName = new ParameterField();
                        ParameterDiscreteValue FINameDescrete = new ParameterDiscreteValue();
                        FIName.Name = "FIName";
                        FINameDescrete.Value = GlobalVariables.FIName;
                        FIName.CurrentValues.Add(FINameDescrete);
                        ParaFields.Add(FIName);

                        string Formate = "";
                        if (GlobalVariables.City == "BADDI")
                            Formate = "U82F-202-07-12";
                        else
                            Formate = "U5F-202-07-12";

                        ParameterField PMRej_Formate = new ParameterField();
                        ParameterDiscreteValue PMRej_FormateDescrete = new ParameterDiscreteValue();
                        PMRej_Formate.Name = "PMRej_Formate";
                        PMRej_FormateDescrete.Value = Formate;
                        PMRej_Formate.CurrentValues.Add(PMRej_FormateDescrete);
                        ParaFields.Add(PMRej_Formate);
                    }
                    if (rptName == "DefectNote_PM")
                    {
                        string Formate = "";
                        if (GlobalVariables.City == "BADDI")
                            Formate = "U82F-202-07-12";
                        else
                            Formate = "U5F-202-07-12";

                        ParameterField PMRej_Formate = new ParameterField();
                        ParameterDiscreteValue PMRej_FormateDescrete = new ParameterDiscreteValue();
                        PMRej_Formate.Name = "PMRej_Formate";
                        PMRej_FormateDescrete.Value = Formate;
                        PMRej_Formate.CurrentValues.Add(PMRej_FormateDescrete);
                        ParaFields.Add(PMRej_Formate);
                    }
                    #endregion

                    ReportViewer.ParameterFieldInfo = ParaFields; 
                  
                    switch (rptName)
                    {
                        
                        case "RejectionNote_PM":
                            RejectionNote_PM.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = RejectionNote_PM;
                            ReportViewer.Show();


                              if (ds.Tables[0].Rows.Count > 0)
                              {
                                  lblMailTo.Visible = true;
                                  chkLstUserName.Visible = true;
                                  chkLstGroupName.Visible = true;
                                  BindUserList();
                                  Bind_GroupNames();
                                  lstReason.Clear();
                                  foreach (DataRow dr in ds.Tables[0].Rows)
                                  {
                                      PMDesc = Convert.ToString(dr["PMDescription"]);
                                      PMLotNo = Convert.ToString(dr["PlantLotNo"]);
                                      PMCode = Convert.ToString(dr["PMCode"]);
                                      challanNo = Convert.ToString(dr["ChallanNo"]);
                                      qty = Convert.ToString(dr["Quantity"]);
                                      mrr = Convert.ToString(dr["MRR"]);
                                      lstReason.Add(dr["DefectComment"]);
                                  }
                                  BusinessFacade.PMSupplierMaster_Class PMSupplierMaster_Class_obj = new BusinessFacade.PMSupplierMaster_Class();
                                  DataSet dsMail = new DataSet();
                                  PMSupplierMaster_Class_obj.pmsupplierid = Convert.ToInt64(Report_Class_Obj.pmsupplierid);

                                  dsMail = PMSupplierMaster_Class_obj.Select_PMSupplierMaster_PMSupplierID();

                                  if (dsMail.Tables[0].Rows[0]["PMSupplierMail"].ToString() != "")
                                  {
                                      PMSupplierMaster_Class_obj.supplierMailID = Convert.ToString(dsMail.Tables[0].Rows[0]["PMSupplierMail"].ToString());
                                      txtCC.Text = Convert.ToString(PMSupplierMaster_Class_obj.supplierMailID);
                                  }
                                  else
                                  {
                                      //MessageBox.Show("Supplier Mail ID not exist");                                      
                                  }

                                  #region Send Mail report settings
                                  // added on 21 DEc 2010 by Sanjiv Shinde

                                  //Create the report object here and assign the rpt file object to this report document
                                  cryRpt = new ReportDocument();
                                  cryRpt = RejectionNote_PM;

                                  //add the all parameters to newly created report document
                                  cryRpt.SetParameterValue("CompanyName", GlobalVariables.companyName);
                                  cryRpt.SetParameterValue("CompanyAddress", GlobalVariables.companyAddress);
                                  cryRpt.SetParameterValue("FIName", GlobalVariables.FIName);
                                  cryRpt.SetParameterValue("To", txtTo.Text.Trim());
                                  txtCC.Visible = true;
                                  lblCC.Visible = true;                                  
                                  btnSendMail.Visible = true;
                                  flgDefectRejectionNote = false; // False means show Rejection Note Report
                                  #endregion
                              }
                              else
                              {
                                  txtCC.Visible = false;
                                  lblCC.Visible = false;
                                  lblMailTo.Visible = false;
                                  chkLstUserName.Visible = false;
                                  chkLstGroupName.Visible = false;
                                  btnSendMail.Visible = false;
                              }
                            break;

                        case "DefectNote_PM":
                            DefectNote_PM.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = DefectNote_PM;
                            ReportViewer.Show();
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                // Show user list in Checklist box to send mail to user ID
                                lblMailTo.Visible = true;
                                chkLstUserName.Visible = true;
                                chkLstGroupName.Visible = true;
                                BindUserList();
                                Bind_GroupNames();

                                lstReason.Clear();
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    PMDesc = Convert.ToString(dr["PMDescription"]);
                                    PMLotNo = Convert.ToString(dr["PlantLotNo"]);
                                    PMCode = Convert.ToString(dr["PMCode"]);
                                    challanNo = Convert.ToString(dr["ChallanNo"]);
                                    qty = Convert.ToString(dr["Quantity"]);
                                    mrr = Convert.ToString(dr["MRR"]);
                                    lstReason.Add(dr["DefectComment"]);
                                }
                                
                                #region Send Mail report settings
                                // added on 21 DEc 2010 by Sanjiv Shinde

                                //Create the report object here and assign the rpt file object to this report document
                                cryRpt = new ReportDocument();
                                cryRpt = DefectNote_PM;

                                //add the all parameters to newly created report document
                                cryRpt.SetParameterValue("CompanyName", GlobalVariables.companyName);
                                cryRpt.SetParameterValue("CompanyAddress", GlobalVariables.companyAddress);
                                cryRpt.SetParameterValue("To", txtTo.Text.Trim());
                                btnSendMail.Visible = true;
                                flgDefectRejectionNote = true;//True means show Defect Note Report
                                #endregion
                            }
                            else
                            {
                                lblMailTo.Visible = false;
                                chkLstUserName.Visible = false;
                                chkLstGroupName.Visible = false;
                                btnSendMail.Visible = false;
                            }

                            break;

                    }
                }
                else
                {
                    MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                txtProtocolNo.Text = "PM" + cmbDetails.SelectedValue.ToString().PadLeft(6, '0');
            }
        }

        private void txtProtocolNo_Leave(object sender, EventArgs e)
        {
            cmbDetails.SelectedValue = 0;
            if (txtProtocolNo.Text.Trim() != "")
            {
                if (txtProtocolNo.Text.StartsWith("PM"))
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

        /// add on 21 Dec 2010 by Sanjiv Shinde
        /// <summary>
        /// Handles the Click event of the btnSendMail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
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
                    MessageBox.Show("User Mail ID does not exist current login");
                    return;
                }           
              
                //create the memory stream object for report document
                MemoryStream oStream;
                if (flgDefectRejectionNote) // True means show Defect Note Report
                {
                    SendDefectNoteMail();
                }
                else  // false means show Rejection Note Report
                {
                    // Get supllier mail ID


                    //BusinessFacade.PMSupplierMaster_Class PMSupplierMaster_Class_obj = new BusinessFacade.PMSupplierMaster_Class();
                    //DataSet dsMail = new DataSet();
                    //PMSupplierMaster_Class_obj.pmsupplierid = Convert.ToInt64(Report_Class_Obj.pmsupplierid);

                    //dsMail = PMSupplierMaster_Class_obj.Select_PMSupplierMaster_PMSupplierID();

                    //if (dsMail.Tables[0].Rows[0]["PMSupplierMail"].ToString() != "")
                    //{
                    //    PMSupplierMaster_Class_obj.supplierMailID = Convert.ToString(dsMail.Tables[0].Rows[0]["PMSupplierMail"].ToString());
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Supplier Mail ID not exist");
                    //    return;
                    //}
                    string strUserName = String.Empty;
                    foreach (DataRowView userId in chkLstUserName.CheckedItems)
                    {
                        UserDataObj.userid = Convert.ToInt32(userId[0]);
                        Dt = UserDataObj.Show_SelectedUser();
                        if (Dt.Rows.Count > 0)
                        {
                            strUserName += Convert.ToString(Dt.Rows[0]["UserMailID"]) + ",";
                        }
                    }
                    DataTable dtGruop = new DataTable();
                    DataTable dtUser = new DataTable();
                    foreach (DataRowView grpID in chkLstGroupName.CheckedItems)
                    {
                        UserDataObj.groupID = Convert.ToInt32(grpID[0]);
                        dtGruop = UserDataObj.Select_SoftwareUserGroupRelation();
                        foreach (DataRow dr in dtGruop.Rows)
                        {
                            UserDataObj.userid = Convert.ToInt32(dr["UserID"]);
                            dtUser = UserDataObj.Show_SelectedUser();
                            if (dtUser.Rows.Count > 0)
                            {
                                strUserName += Convert.ToString(dtUser.Rows[0]["UserMailID"]) + ",";
                            }
                        }

                    }
                    strUserName = strUserName.TrimEnd(new char[] { ',' });

                    //if (strUserName == "")
                    //{
                    //    MessageBox.Show("User Mail ID not exist", "PM Defect Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}



                    oStream = (MemoryStream)cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

                    //reportDocument is the crystal report document object

                    MailMessage email = new MailMessage();

                    email.From = new MailAddress(UserDataObj.userMailID);

                    
                    //email.To.Add(PMSupplierMaster_Class_obj.supplierMailID);
                     string[] strSupplierMail;
                     if (txtCC.Text.Trim() != "")
                         strSupplierMail = txtCC.Text.Split(',');
                     else
                     {
                         MessageBox.Show("Please enter supplier mail ID");
                         txtCC.Focus();
                         return;
                     }
                    foreach (string str in strSupplierMail)
                    {
                        if (!BusinessFacade.CheckValidMail.IsEmailValid(str))
                        {
                            MessageBox.Show("Please Check the supplier mail ID");
                            return;
                        }
                    }

                    email.To.Add(txtCC.Text.Trim());

                    if (strUserName != "")
                        email.CC.Add(strUserName);

                    email.Subject = "PM Rejection Note";


                    string htmlString = string.Empty;

                    htmlString = "Dear Sir/Madam,</br></br> Reasons for rejections </br></br>   <table border = 1 cellspacing = 5 > <tr><td><b>ITEM :</b></td><td>" + PMDesc + " </td><td><b>LOT NO :</b></td><td>" + PMLotNo + "</td></tr><tr><td ><b>PM CODE :</b></td><td>" + PMCode + "</td><td><b>CHALLAN :</b></td><td>" + challanNo + "</td></tr><tr><td><b>QUANTITY :</b></td><td>" + qty + "</td><td ><b>MRR NO :</b></td><td>" + mrr + "</td></tr></table> </br></br>";

                    htmlString += "<table  border = 1 cellspacing = 5 > <tr><td>No</td> <td>Reasons</td></tr> ";
                    for (int i = 0; i < lstReason.Count; i++)
                    {
                        htmlString += "<tr><td>" + Convert.ToString(i + 1) + " </td><td>" + lstReason[i].ToString() + "</td></tr>";
                    }
                    htmlString += "</table>";
                    // htmlString = htmlString.TrimEnd(new char[]{','});
                    email.Body = htmlString;// "<b>PM has been rejected due to [Reason]";
                    email.IsBodyHtml = true;
                    email.Priority = MailPriority.High;

                    email.Attachments.Add(new System.Net.Mail.Attachment(oStream, "PM Reject Note.pdf"));

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
                    for (int i = 0; i < chkLstGroupName.Items.Count; i++)
                    {
                        chkLstGroupName.SetItemChecked(i, false);
                    }
                }            


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void SendDefectNoteMail()
        {
            try
            {
                DataTable Dt = new DataTable();
                string strUserName = String.Empty;
                //int cnt, cntUser = 0;               
                foreach (DataRowView userId in chkLstUserName.CheckedItems)
                {                   
                    UserDataObj.userid = Convert.ToInt32(userId[0]);
                    Dt = UserDataObj.Show_SelectedUser();
                    if (Dt.Rows.Count > 0)
                    {
                        strUserName += Convert.ToString(Dt.Rows[0]["UserMailID"]) + ",";
                    }
                }
                DataTable dtGruop = new DataTable();
                DataTable dtUser = new DataTable();
                foreach (DataRowView grpID in chkLstGroupName.CheckedItems)
                {
                    UserDataObj.groupID = Convert.ToInt32(grpID[0]);
                    dtGruop = UserDataObj.Select_SoftwareUserGroupRelation();
                    foreach (DataRow dr in dtGruop.Rows)
                    {
                        UserDataObj.userid = Convert.ToInt32(dr["UserID"]);
                        dtUser = UserDataObj.Show_SelectedUser();
                        if (dtUser.Rows.Count > 0)
                        {
                            strUserName += Convert.ToString(dtUser.Rows[0]["UserMailID"]) + ",";
                        }
                    }

                }
                strUserName = strUserName.TrimEnd(new char[] { ',' });

                if (strUserName == "")
                {
                    MessageBox.Show("User Mail ID not exist","PM Defect Note",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                //else
                //{
                //    strUserName = strUserName.TrimEnd(new char[] { ',' });
                //}

                MemoryStream oStream;
                oStream = (MemoryStream)cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

                //reportDocument is the crystal report document object

                MailMessage email = new MailMessage();

                email.From = new MailAddress(UserDataObj.userMailID);

                email.To.Add(strUserName);

                if (MessageBox.Show("Do you want to send mail to supplier ", "PM Defect Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Get supllier mail ID

                    BusinessFacade.PMSupplierMaster_Class PMSupplierMaster_Class_obj = new BusinessFacade.PMSupplierMaster_Class();
                    DataSet dsMail = new DataSet();
                    PMSupplierMaster_Class_obj.pmsupplierid = Convert.ToInt64(Report_Class_Obj.pmsupplierid);

                    dsMail = PMSupplierMaster_Class_obj.Select_PMSupplierMaster_PMSupplierID();

                    if (dsMail.Tables[0].Rows[0]["PMSupplierMail"].ToString() != "")
                    {
                        PMSupplierMaster_Class_obj.supplierMailID = Convert.ToString(dsMail.Tables[0].Rows[0]["PMSupplierMail"].ToString());
                        if (BusinessFacade.CheckValidMail.IsEmailValid(PMSupplierMaster_Class_obj.supplierMailID))
                            email.CC.Add(PMSupplierMaster_Class_obj.supplierMailID);
                    }               
                }
                email.Subject = "PM Defect Note";

                //StringWriter writer = new StringWriter();
               
                //HtmlTextWriter html = new HtmlTextWriter(writer);
                //html.RenderBeginTag(HtmlTextWriterTag.B);
                //html.WriteEncodedText("PM has been defect due to Following Reason");
                //html.RenderEndTag();
                //for(int i = 0; i< lstReason.Count; i++)
                //{
                //    html.WriteEncodedText(String.Format(Convert.ToString(i+1)+ ") " + lstReason[i].ToString()));
                //}
                //html.WriteBreak();
                //html.RenderBeginTag(HtmlTextWriterTag.P);
                //html.WriteEncodedText("");
                //html.RenderEndTag();
                //html.Flush();

                string htmlString = string.Empty;

                htmlString = "Dear Sir/Madam,</br></br> Details of the defects in PM </br></br>   <table border = 1 cellspacing = 5 > <tr><td><b>ITEM :</b></td><td>" + PMDesc + " </td><td><b>LOT NO :</b></td><td>" + PMLotNo + "</td></tr><tr><td ><b>PM CODE :</b></td><td>" + PMCode + "</td><td><b>CHALLAN :</b></td><td>" + challanNo + "</td></tr><tr><td><b>QUANTITY :</b></td><td>" + qty + "</td><td ><b>MRR NO :</b></td><td>" + mrr + "</td></tr></table> </br></br>";

                htmlString += "<table  border = 1 cellspacing = 5 > <tr><td>No</td> <td>Reasons</td></tr> ";
                for (int i = 0; i < lstReason.Count; i++)
                {
                    htmlString += "<tr><td>" + Convert.ToString(i + 1) + " </td><td>" + lstReason[i].ToString() + "</td></tr>";
                }
                htmlString += "</table>";
               // htmlString = htmlString.TrimEnd(new char[]{','});
                email.Body = htmlString;//"<b>PM has been defect due to [Reason]";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.High;

                email.Attachments.Add(new System.Net.Mail.Attachment(oStream, "PM Defect Note.pdf"));

                //create the SMTP client object and assign the all details here

                System.Net.Configuration.SmtpSection smtpSettings = (System.Net.Configuration.SmtpSection)System.Configuration.ConfigurationSettings.GetConfig("system.net/mailSettings/smtp");
                SmtpClient smtpClient = new SmtpClient();
                // smtpClient.Host = Convert.ToString("mail.kairee.in");

                smtpClient.Host = smtpSettings.Network.Host;
                //smtpClient.EnableSsl = true;
                smtpClient.Send(email);
                MessageBox.Show("Mail sent sucessfully!");
                for (int i = 0; i < chkLstUserName.Items.Count; i++)
                {
                    chkLstUserName.SetItemChecked(i, false);
                }
                for (int i = 0; i < chkLstGroupName.Items.Count; i++)
                {
                    chkLstGroupName.SetItemChecked(i, false);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
       
       // Use this function to send PM defect note pdf from PM Defect Note Form
        public void ShowDefectNoteReport(long PMTransID, string strUserName)
        {
            try
            {
                DataSet ds = new DataSet();


                Report_Class_Obj.pmtransid = PMTransID;

                ds = Report_Class_Obj.Select_View_DefectNote_PM();

                DefectNote_PM.SetDataSource(ds.Tables[0]);
                ReportViewer.ReportSource = DefectNote_PM;
                //ReportViewer.Show();




                if (ds.Tables[0].Rows.Count > 0)
                {

                    lstReason.Clear();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PMDesc = Convert.ToString(dr["PMDescription"]);
                        PMLotNo = Convert.ToString(dr["PlantLotNo"]);
                        PMCode = Convert.ToString(dr["PMCode"]);
                        challanNo = Convert.ToString(dr["ChallanNo"]);
                        qty = Convert.ToString(dr["Quantity"]);
                        mrr = Convert.ToString(dr["MRR"]);
                        lstReason.Add(dr["DefectComment"]);
                    }

                    #region Send Mail report settings
                    // added on 21 DEc 2010 by Sanjiv Shinde

                    //Create the report object here and assign the rpt file object to this report document
                    cryRpt = new ReportDocument();
                    cryRpt = DefectNote_PM;

                    //add the all parameters to newly created report document
                    cryRpt.SetParameterValue("CompanyName", GlobalVariables.companyName);
                    cryRpt.SetParameterValue("CompanyAddress", GlobalVariables.companyAddress);
                    cryRpt.SetParameterValue("To", txtTo.Text.Trim());
                    btnSendMail.Visible = true;
                    flgDefectRejectionNote = true;//True means show Defect Note Report
                    #endregion


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



                    MemoryStream oStream;
                    oStream = (MemoryStream)cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

                    //reportDocument is the crystal report document object

                    MailMessage email = new MailMessage();

                    email.From = new MailAddress(UserDataObj.userMailID);

                    email.To.Add(strUserName);

                    
                    email.Subject = "PM Defect Note";


                    string htmlString = string.Empty;

                    htmlString = "Dear Sir/Madam,</br></br> Details of the defects in PM </br></br>   <table border = 1 cellspacing = 5 > <tr><td><b>ITEM :</b></td><td>" + PMDesc + " </td><td><b>LOT NO :</b></td><td>" + PMLotNo + "</td></tr><tr><td ><b>PM CODE :</b></td><td>" + PMCode + "</td><td><b>CHALLAN :</b></td><td>" + challanNo + "</td></tr><tr><td><b>QUANTITY :</b></td><td>" + qty + "</td><td ><b>MRR NO :</b></td><td>" + mrr + "</td></tr></table> </br></br>";

                    htmlString += "<table  border = 1 cellspacing = 5 > <tr><td>No</td> <td>Reasons</td></tr> ";
                    for (int i = 0; i < lstReason.Count; i++)
                    {
                        htmlString += "<tr><td>" + Convert.ToString(i + 1) + " </td><td>" + lstReason[i].ToString() + "</td></tr>";
                    }
                    htmlString += "</table>";
                    // htmlString = htmlString.TrimEnd(new char[]{','});
                    email.Body = htmlString;//"<b>PM has been defect due to [Reason]";
                    
                    email.IsBodyHtml = true;

                    email.Priority = MailPriority.High;

                    email.Attachments.Add(new System.Net.Mail.Attachment(oStream, "PM Defect Note.pdf"));

                    //create the SMTP client object and assign the all details here

                    System.Net.Configuration.SmtpSection smtpSettings = (System.Net.Configuration.SmtpSection)System.Configuration.ConfigurationSettings.GetConfig("system.net/mailSettings/smtp");
                    SmtpClient smtpClient = new SmtpClient();
                    // smtpClient.Host = Convert.ToString("mail.kairee.in");

                    smtpClient.Host = smtpSettings.Network.Host;

                    smtpClient.Send(email);

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}