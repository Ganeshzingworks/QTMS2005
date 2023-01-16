using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;
using BusinessFacade.Transactions;
using System.Net.Mail;
using System.Configuration;

namespace QTMS.Transactions
{

    public partial class FrmAOCSheet : Form
    {
        DataSet dsList = new DataSet();
        public FrmAOCSheet()
        {
            InitializeComponent();
        }
        # region Varibles
        bool Modify = false;
        public bool SaveAs = false;
        PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new PackingFamilyMaster_Class();
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        FGGlobalFamilyMaster_Class FGGlobalFamilyMaster_Class_Obj = new FGGlobalFamilyMaster_Class();
        AOCSheet_Class AOCSheet_Class_Obj = new AOCSheet_Class();
        FGTestMaster_Class FGTestMaster_Class_Obj = null;
        # endregion

        private static FrmAOCSheet FrmAOCSheet_Obj = null;
        public static FrmAOCSheet GetInstance()
        {
            if (FrmAOCSheet_Obj == null)
            {
                FrmAOCSheet_Obj = new FrmAOCSheet();
            }
            return FrmAOCSheet_Obj;
        }

        private void FrmAOCSheet_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                Painter.Paint(this);

                Bind_FGCode();

                BtnReset_Click(sender, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void Bind_FGCode()
        {


            DataRow dr;
            dsList = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster();
            dr = dsList.Tables[0].NewRow();
            dr["FGCode"] = "--Select--";
            dr["FGNo"] = "0";
            dsList.Tables[0].Rows.InsertAt(dr, 0);

            cmbFGCode.DataSource = dsList.Tables[0];
            cmbFGCode.DisplayMember = "FGCode";
            cmbFGCode.ValueMember = "FGNo";

        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValid()
        {
            if (cmbFGCode.Text.Trim() == "--Select--")
            {
                MessageBox.Show("Select Fg Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFGCode.Text = "";
                cmbFGCode.Focus();
                return false;
            }
            if (CmbFormulaNo.Text.Trim() == "--Select--")
            {
                MessageBox.Show("Select Formula Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbFormulaNo.Text = "";
                CmbFormulaNo.Focus();
                return false;
            }
            if (cmbFGLotNo.Text.Trim() == "--Select--")
            {
                MessageBox.Show("Select Fg Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFGLotNo.Text = "";
                cmbFGLotNo.Focus();
                return false;
            }

            //if (txtFgDesc.Text.Trim() == "")
            //{
            //    MessageBox.Show("Enter Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtFgDesc.Text = "";
            //    txtFgDesc.Focus();
            //    return false;
            //}
            //if (txtFillVolume.Text == "")
            //{
            //    MessageBox.Show("Enter Fill Volume", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtFillVolume.Focus();
            //    return false;
            //}


            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    AOCSheet_Class_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                    AOCSheet_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                    AOCSheet_Class_Obj.fmid = Convert.ToInt64(cmbFGLotNo.SelectedValue);
                    //AOCSheet_Class_Obj.requestDate = (dtpRequestDate.Value.ToShortDateString());
                    //AOCSheet_Class_Obj.clearenceDate = (dtpClearenceDate.Value.ToShortDateString());

                    if (dtpRequestDate.Checked == true)
                    {
                        AOCSheet_Class_Obj.requestDate = dtpRequestDate.Value.ToShortDateString();
                    }
                    else
                    {
                        AOCSheet_Class_Obj.requestDate = null;
                    }
                    if (dtpClearenceDate.Checked == true)
                    {
                        AOCSheet_Class_Obj.clearenceDate = dtpClearenceDate.Value.ToShortDateString();
                    }
                    else
                    {
                        AOCSheet_Class_Obj.clearenceDate = null;
                    }

                    AOCSheet_Class_Obj.comAuthorisation = txtcomAuthorisation.Text.Trim();
                    AOCSheet_Class_Obj.loginid = FrmMain.LoginID;
                    DataSet ds = new DataSet();
                    ds = AOCSheet_Class_Obj.Select_tblAOCSheet_FGNo_FNo_FMID();
                    bool flag = false;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        flag = AOCSheet_Class_Obj.Update_tblAOCSheet();
                        if (flag == true)
                        {
                            MessageBox.Show("Record Updated Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //BtnReset_Click(sender, e);
                        }
                    }
                    else
                    {
                        flag = AOCSheet_Class_Obj.Insert_tblAOCSheet();
                        if (flag == true)
                        {
                            MessageBox.Show("Record Saved Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //BtnReset_Click(sender, e);
                        }
                    }


                    ////QTMS.Reports_Forms.FrmAOCProtocol objProtocol = new QTMS.Reports_Forms.FrmAOCProtocol("AOC Sheet Protocol", Convert.ToInt64(cmbFGCode.SelectedValue), Convert.ToInt64(CmbFormulaNo.SelectedValue), Convert.ToInt64(cmbFGLotNo.SelectedValue));
                    ////objProtocol.Show();
                    ////objProtocol.Close();

                    if (GlobalVariables.City == "BADDI")
                    {
                        AOCSheet_Class AOCSheet_Class_Obj_1 = new AOCSheet_Class();

                        AOCSheet_Class_Obj_1.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                        AOCSheet_Class_Obj_1.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                        AOCSheet_Class_Obj_1.fmid = Convert.ToInt64(cmbFGLotNo.SelectedValue);

                        DataSet ds_1 = new DataSet();
                        ds_1 = AOCSheet_Class_Obj_1.Select_tblAOCSheet_FGNo_FNo_FMID();


                        Reports.Protocol_AOCSheet AOCSheetProtocol = new QTMS.Reports.Protocol_AOCSheet();
                        if (ds_1.Tables[0].Rows.Count > 0)
                        {
                            AOCSheetProtocol.SetDataSource(ds_1.Tables[0]);

                            AOCSheetProtocol.Refresh();
                            //AOCSheetProtocol.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\AOC.pdf");
                            AOCSheetProtocol.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, ConfigurationManager.AppSettings["FGPackingfilepath"].ToString() + "\\AOC.pdf");

                            
                            /*
                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient("smtprelay1-ap.loreal.wans");
                            mail.From = new MailAddress("apandit@in.loreal.com");
                            mail.To.Add("Megha.sharma@Loreal.com");
                            mail.To.Add("Harpreet.kaur2@Loreal.com");
                            mail.Subject = "AOC Form";
                            mail.IsBodyHtml = true;
                            mail.Body = "<table cellpadding='0' cellspacing='0' style='font-family:Verdana; font-size:12px; color:#0b5c89;'> "+ 
                                        "<tr> <td>Dear All</br></br></td>   </tr>  <tr> <td>Please find AOC Form."+
                                        "</br></br></td>  </tr> <tr>  <td>Warm Regards,</br></td>  </tr><tr><td></td></tr> <tr><td></td></tr></table>  " +
                                        "<span style='font-family:Verdana; font-size:13px; color:#000000;'></br></br><b>Note: "+
                                        "This is auto generated email. Please do not reply.</b></span>  </br></br>";
                            string filename = @""+Application.StartupPath + "\\AOC.pdf";
                            mail.Attachments.Add(new Attachment(filename));
                            SmtpServer.Port = 25;
                            SmtpServer.Credentials = new
                            System.Net.NetworkCredential("apandit@in.loreal.com", "Blue@2178");
                            SmtpServer.EnableSsl = false;
                            SmtpServer.Send(mail);
                            */
                        }
                    }
                    BtnReset_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }



        private void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();

        }

        private void Reset()
        {
            SaveAs = false;
            BtnDelete.Enabled = false;
            txtFillVolume.Text = "";
            txtFgDesc.Text = "";
            txtcomAuthorisation.Text = "";
            cmbFGCode.SelectedValue = 0;
            cmbFGLotNo.SelectedValue = 0;
            CmbFormulaNo.SelectedValue = 0;

        }



        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue.ToString());
                if (FinishedGoodMaster_Class_Obj.fgno == 0)
                {
                    MessageBox.Show("Select Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //first delete 

                    MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BtnReset_Click(sender, e);
                    BtnDelete.Enabled = false;
                    Bind_FGCode();
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Can't Delete This Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Modify = false;

            }
        }




        private void txtFgDesc_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtFgDesc.Text = textInfo.ToTitleCase(txtFgDesc.Text);
        }

        private void txtFillVolume_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtFillVolume.Text = textInfo.ToTitleCase(txtFillVolume.Text);
        }


        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmbFGCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                ds = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFgMaster_FGNo();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFgDesc.Text = ds.Tables[0].Rows[0]["FGDesc"].ToString();
                    txtFillVolume.Text = ds.Tables[0].Rows[0]["FillVolume"].ToString();
                }


                DataRow dr;

                DataSet ds2 = new DataSet();
                ds2 = FinishedGoodMaster_Class_Obj.SELECT_tblFgMaster_FormulaNo();
                dr = ds2.Tables[0].NewRow();
                dr["FormulaNo"] = "--Select--";
                dr["FNo"] = "0";
                ds2.Tables[0].Rows.InsertAt(dr, 0);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    CmbFormulaNo.DataSource = ds2.Tables[0];
                    CmbFormulaNo.DisplayMember = "FormulaNo";
                    CmbFormulaNo.ValueMember = "FNo";
                }
                CmbFormulaNo_SelectionChangeCommitted(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRow dr;
            AOCSheet_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
            DataSet ds = new DataSet();
            ds = AOCSheet_Class_Obj.Select_tblTransFM_FNo_GetMfgWo();
            dr = ds.Tables[0].NewRow();
            dr["MfgWo"] = "--Select--";
            dr["FMID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbFGLotNo.DataSource = ds.Tables[0];
                cmbFGLotNo.DisplayMember = "MfgWo";
                cmbFGLotNo.ValueMember = "FMID";
            }
        }

        private void cmbFGLotNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                AOCSheet_Class_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                AOCSheet_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                AOCSheet_Class_Obj.fmid = Convert.ToInt64(cmbFGLotNo.SelectedValue);

                DataSet ds = new DataSet();
                ds = AOCSheet_Class_Obj.Select_tblAOCSheet_FGNo_FNo_FMID();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["RequestDate"] != DBNull.Value)
                        dtpRequestDate.Value = Convert.ToDateTime(dr["RequestDate"]);
                    if (dr["ClearenceDate"] != DBNull.Value)
                        dtpClearenceDate.Value = Convert.ToDateTime(dr["ClearenceDate"]);
                    txtcomAuthorisation.Text = Convert.ToString(dr["CommersializeAuthorisation"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProtocol_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                AOCSheet_Class_Obj.fgno = Convert.ToInt64(cmbFGCode.SelectedValue);
                AOCSheet_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                AOCSheet_Class_Obj.fmid = Convert.ToInt64(cmbFGLotNo.SelectedValue);
                //AOCSheet_Class_Obj.requestDate = Convert.ToDateTime(dtpRequestDate.Value);
                //AOCSheet_Class_Obj.clearenceDate = Convert.ToDateTime(dtpClearenceDate.Value);
                if (dtpRequestDate.Checked == true)
                {
                    AOCSheet_Class_Obj.requestDate = dtpRequestDate.Value.ToShortDateString();
                }
                else
                {
                    AOCSheet_Class_Obj.requestDate = null;
                }
                if (dtpClearenceDate.Checked == true)
                {
                    AOCSheet_Class_Obj.clearenceDate = dtpClearenceDate.Value.ToShortDateString();
                }
                else
                {
                    AOCSheet_Class_Obj.clearenceDate = null;
                }
                AOCSheet_Class_Obj.comAuthorisation = txtcomAuthorisation.Text.Trim();
                AOCSheet_Class_Obj.loginid = FrmMain.LoginID;
                DataSet ds = new DataSet();
                ds = AOCSheet_Class_Obj.Select_tblAOCSheet_FGNo_FNo_FMID();
                bool flag = false;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    flag = AOCSheet_Class_Obj.Update_tblAOCSheet();
                }
                else
                {
                    flag = AOCSheet_Class_Obj.Insert_tblAOCSheet();

                }

                QTMS.Reports_Forms.FrmAOCProtocol objProtocol = new QTMS.Reports_Forms.FrmAOCProtocol("AOC Sheet Protocol", Convert.ToInt64(cmbFGCode.SelectedValue), Convert.ToInt64(CmbFormulaNo.SelectedValue), Convert.ToInt64(cmbFGLotNo.SelectedValue));
                objProtocol.Show();
            }

        }

    }
}