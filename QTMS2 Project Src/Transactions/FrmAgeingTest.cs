using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace QTMS.Transactions
{
    /// <summary>
    /// By Vijay Chavan 25-02-2021 
    /// </summary>
    public partial class FrmAgeingTest : Form
    {
        public FrmAgeingTest()
        {
            InitializeComponent();
        }

        #region Varibles

        BusinessFacade.Transactions.AgeingTest_Class AgeingTest_Class_Obj = new BusinessFacade.Transactions.AgeingTest_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();

        #endregion

        private static FrmAgeingTest frmAgeingTest_Obj = null;
        public static FrmAgeingTest GetInstance()
        {
            if (frmAgeingTest_Obj == null)
            {
                frmAgeingTest_Obj = new FrmAgeingTest();
            }
            return frmAgeingTest_Obj;
        }

        private void FrmAgeingTest_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            QTMS.Tools.Painter.Paint(this);
            DtpCurrentDate.Value = Comman_Class_Obj.Select_ServerDate();
            Bind_FormulaNo();
            Bind_CheckedBy();
            Bind_VerifiedBy();
        }

        public void Bind_FormulaNo()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = AgeingTest_Class_Obj.SELECT_FormulaNo_For_AgeingTest();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbFormulaNo.DataSource = ds.Tables[0];
                CmbFormulaNo.ValueMember = "FNo";
                CmbFormulaNo.DisplayMember = "FormulaNo";
            }

        }

        public void Bind_VerifiedBy()
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
                cmbVerifiedBy.DataSource = ds.Tables[0];
                cmbVerifiedBy.DisplayMember = "UserName";
                cmbVerifiedBy.ValueMember = "UserID";
            }
        }

        public void Bind_CheckedBy()
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
                cmbCheckedBy.DataSource = ds.Tables[0];
                cmbCheckedBy.DisplayMember = "UserName";
                cmbCheckedBy.ValueMember = "UserID";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 if (CmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbFormulaNo.Focus();
                    return;
                }
                for (int i = 0; i < dgLine.Rows.Count; i++)
                {
                    if (dgLine["LineStatus", i].Value == null || dgLine["LineStatus", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the Status of Line Sample Test ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgLine.Focus();
                        return;
                    }
                    //if (dgLine["LineComment", i].Value == null || dgLine["LineComment", i].Value.ToString().Trim() == "")
                    //{
                    //    MessageBox.Show("Fill all the Comment of Line Sample Test ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    dgLine.Focus();
                    //    return;
                    //}
                }

                for (int i = 0; i < dgQPF_MC_1201.Rows.Count; i++)
                {
                    if (dgQPF_MC_1201["Status", i].Value == null || dgQPF_MC_1201["Status", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the Status of QPF_MC_1201 ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgQPF_MC_1201.Focus();
                        return;
                    }
                }
                
                if (txtComment_AgeingResult.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Comment On Ageing Result", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtComment_AgeingResult.Focus();
                    return;
                }
                if (cmbCheckedBy.SelectedValue == null || cmbCheckedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Checked By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbCheckedBy.Focus();
                    return;
                }
                if (cmbVerifiedBy.SelectedValue == null || cmbVerifiedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Verified By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVerifiedBy.Focus();
                    return;
                }

                AgeingTest_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                DataSet dslist = new DataSet();
                dslist = AgeingTest_Class_Obj.SELECT_TransFMDetails_For_AgeingTest();
                if (dslist.Tables[0].Rows.Count > 0)
                {
                    AgeingTest_Class_Obj.fmid = Convert.ToInt64(dslist.Tables[0].Rows[0]["FMID"]);
                    AgeingTest_Class_Obj.filename = Convert.ToString(dslist.Tables[0].Rows[0]["FileName"]);
                }
               
                DataSet dsFMID = new DataSet();
                dsFMID = AgeingTest_Class_Obj.Check_AgeingTest_For_Update();

                // Record Update in tblQPF_MC_AgeingTest
                if (dsFMID.Tables[0].Rows.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("Record for this Formula No and Test already exists...!\n\n Update ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgLine.Rows.Count; i++)
                        {
                            AgeingTest_Class_Obj.testno = Convert.ToInt64(dgLine["LineTestNo", i].Value);

                            AgeingTest_Class_Obj.normsmin = dgLine["LineMin", i].Value.ToString();

                            AgeingTest_Class_Obj.normsmax = dgLine["LineMax", i].Value.ToString();

                            AgeingTest_Class_Obj.status = dgLine["LineStatus", i].Value.ToString();

                            AgeingTest_Class_Obj.comment =Convert.ToString(dgLine["LineComment", i].Value);

                            AgeingTest_Class_Obj.Update_tblAgeingTestDetails();
                        }

                        AgeingTest_Class_Obj.description = dgQPF_MC_1201["Description", 0].Value.ToString();
                        AgeingTest_Class_Obj.qpfstatus = dgQPF_MC_1201["Status", 0].Value.ToString();
                        AgeingTest_Class_Obj.qpfcomment = Convert.ToString(dgQPF_MC_1201["Comment", 0].Value);
                        if (RdoConfirm.Checked == true)
                        {
                            AgeingTest_Class_Obj.confirmation = Convert.ToString("Confirm");
                        }
                        else
                        {
                            AgeingTest_Class_Obj.confirmation = Convert.ToString("NotConfirm");
                        }

                        AgeingTest_Class_Obj.ageingresultcomment = txtComment_AgeingResult.Text;
                        AgeingTest_Class_Obj.checkedby = Convert.ToInt32(cmbCheckedBy.SelectedValue);
                        AgeingTest_Class_Obj.verifiedby = Convert.ToInt32(cmbVerifiedBy.SelectedValue);

                        AgeingTest_Class_Obj.Update_tblQPF_MC_AgeingTestDetails();

                        SavePdfFile();

                        MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                        
                    }
                                }
                else
                {
                        //Test details Record saved in tbl Ageing Test
                        for (int i = 0; i < dgLine.Rows.Count; i++)
                        {
                            AgeingTest_Class_Obj.testno = Convert.ToInt64(dgLine["LineTestNo", i].Value);

                            AgeingTest_Class_Obj.normsmin = dgLine["LineMin", i].Value.ToString();

                            AgeingTest_Class_Obj.normsmax = dgLine["LineMax", i].Value.ToString();

                            AgeingTest_Class_Obj.status = dgLine["LineStatus", i].Value.ToString();

                            AgeingTest_Class_Obj.comment =Convert.ToString(dgLine["LineComment", i].Value);

                            AgeingTest_Class_Obj.INSERT_tblAgeingTestDetails();
                        }

                        AgeingTest_Class_Obj.description = dgQPF_MC_1201["Description", 0].Value.ToString();
                        AgeingTest_Class_Obj.qpfstatus = dgQPF_MC_1201["Status", 0].Value.ToString();
                        AgeingTest_Class_Obj.qpfcomment = Convert.ToString(dgQPF_MC_1201["Comment", 0].Value);
                        if (RdoConfirm.Checked == true)
                        {
                            AgeingTest_Class_Obj.confirmation = Convert.ToString("Confirm");
                        }
                        else
                        {
                            AgeingTest_Class_Obj.confirmation = Convert.ToString("NotConfirm");
                        }

                        AgeingTest_Class_Obj.ageingresultcomment = txtComment_AgeingResult.Text;
                        AgeingTest_Class_Obj.checkedby = Convert.ToInt32(cmbCheckedBy.SelectedValue);
                        AgeingTest_Class_Obj.verifiedby = Convert.ToInt32(cmbVerifiedBy.SelectedValue);

                        AgeingTest_Class_Obj.INSERT_tblQPF_MC_AgeingTestDetails();

                        SavePdfFile();

                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                 }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ClearText();

            if (CmbFormulaNo.SelectedValue == null || CmbFormulaNo.SelectedValue.ToString() == "")
            {
               
                return;
            }
            if (Convert.ToInt32(CmbFormulaNo.SelectedValue) == 0)
            {
                return;
            }

             AgeingTest_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
             DataSet ds = new DataSet();
             ds = AgeingTest_Class_Obj.SELECT_TransFMDetails_For_AgeingTest();
             if (ds.Tables[0].Rows.Count > 0)
             {
                 txtMfgWO_No.Text = Convert.ToString(ds.Tables[0].Rows[0]["MfgWo"]);
                 lbMfgDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["TransDate"]).ToShortDateString();
                 lbFillingDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Fillingdate"]).ToShortDateString();
                 
             }
             if (ds.Tables[0].Rows[0]["ReminderSentOn"] != System.DBNull.Value)
             {
                 if (Comman_Class_Obj.Select_ServerDate().AddDays(-7) > Convert.ToDateTime(ds.Tables[0].Rows[0]["ReminderSentOn"]))
                 {
                     BtnSave.Enabled = false;
                     dgLine.ReadOnly = true;
                     dgQPF_MC_1201.ReadOnly = true;
                     txtComment_AgeingResult.ReadOnly = true;
                     RdoConfirm.Enabled = false;
                     RdoNotComfirm.Enabled = false;
                     cmbVerifiedBy.Enabled = false;
                     cmbCheckedBy.Enabled = false;

                 }
             }
                
              DataSet dsLineTest = new DataSet();
              dsLineTest = AgeingTest_Class_Obj.SELECT_LineSampleTest_For_Update();
              if (dsLineTest.Tables[0].Rows.Count > 0)
              {
                     MessageBox.Show("Record for this Formula No already exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     for (int i = 0; i < dsLineTest.Tables[0].Rows.Count; i++)
                     {
                         dgLine.Rows.Add();
                         dgLine["LineTestNo", dgLine.Rows.Count - 1].Value = dsLineTest.Tables[0].Rows[i]["TestNo"].ToString();
                         dgLine["LineTest", dgLine.Rows.Count - 1].Value = dsLineTest.Tables[0].Rows[i]["Details"].ToString();
                         dgLine["LineMin", dgLine.Rows.Count - 1].Value = dsLineTest.Tables[0].Rows[i]["NormsMin"].ToString();
                         dgLine["LineMax", dgLine.Rows.Count - 1].Value = dsLineTest.Tables[0].Rows[i]["NormsMax"].ToString();
                         dgLine["LineStatus", dgLine.Rows.Count - 1].Value = dsLineTest.Tables[0].Rows[i]["Status"].ToString();
                         dgLine["LineComment", dgLine.Rows.Count - 1].Value = dsLineTest.Tables[0].Rows[i]["Comment"].ToString();
                     }
                     DataSet dsQPF = new DataSet();
                     dsQPF = AgeingTest_Class_Obj.SELECT_tblQPF_MC_AgeingTest_For_Update();
                     dgQPF_MC_1201.Rows.Add();
                     dgQPF_MC_1201["Description", dgQPF_MC_1201.Rows.Count - 1].Value = dsQPF.Tables[0].Rows[0]["Description"].ToString();
                     dgQPF_MC_1201["Status", dgQPF_MC_1201.Rows.Count - 1].Value = dsQPF.Tables[0].Rows[0]["QPFStatus"].ToString();
                     dgQPF_MC_1201["Comment", dgQPF_MC_1201.Rows.Count - 1].Value = dsQPF.Tables[0].Rows[0]["QPFComment"].ToString();

                     if (dsQPF.Tables[0].Rows[0]["Confirmation"].ToString() == "Confirm")
                     {
                         RdoConfirm.Checked = true;
                     }
                     else
                     {
                         RdoNotComfirm.Checked = true;
                     }

                     txtComment_AgeingResult.Text = Convert.ToString(dsQPF.Tables[0].Rows[0]["AgeingResultComment"]);
                     cmbCheckedBy.SelectedValue = Convert.ToInt64(dsQPF.Tables[0].Rows[0]["CheckedBy"]);
                     cmbVerifiedBy.SelectedValue = Convert.ToInt64(dsQPF.Tables[0].Rows[0]["VerifiedBy"]);
              }
              else
              {
                 DataSet dsLine = new DataSet();
                 dsLine = AgeingTest_Class_Obj.SELECT_LineSampleTest_FNo();
                 if (dsLine.Tables[0].Rows.Count > 0)
                 {
                     for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
                     {
                         dgLine.Rows.Add();
                         dgLine["LineTestNo", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["TestNo"].ToString();
                         dgLine["LineTest", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["Details"].ToString();
                         dgLine["LineMin", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["NormsMin"].ToString();
                         dgLine["LineMax", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["NormsMax"].ToString();
                     }
                 }
                 dgQPF_MC_1201.Rows.Add();
                 dgQPF_MC_1201["Description", dgQPF_MC_1201.Rows.Count - 1].Value = "Quality Of Use";
             }
             

        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            dgLine.Rows.Clear();
            dgQPF_MC_1201.Rows.Clear();
            txtMfgWO_No.Text = "";
            lbMfgDate.Text = "";
            lbFillingDate.Text = "";
            CmbFormulaNo.Text = "--Select--";
            txtComment_AgeingResult.Text = "";
            RdoConfirm.Checked = true;
            RdoNotComfirm.Checked = false;
            cmbVerifiedBy.Text = "--Select--";
            cmbCheckedBy.Text = "--Select--";

            BtnSave.Enabled = true;
            dgLine.ReadOnly = false;
            dgQPF_MC_1201.ReadOnly = false;
            txtComment_AgeingResult.ReadOnly = false;
            RdoConfirm.Enabled = true;
            RdoNotComfirm.Enabled = true;
            cmbVerifiedBy.Enabled = true;
            cmbCheckedBy.Enabled = true;
        }

        private void ClearText()
        {
            dgLine.Rows.Clear();
            dgQPF_MC_1201.Rows.Clear();
            txtMfgWO_No.Text = "";
            lbMfgDate.Text = "";
            lbFillingDate.Text = "";
            cmbVerifiedBy.Text = "--Select--";
            cmbCheckedBy.Text = "--Select--";
            txtComment_AgeingResult.Text = "";
            RdoConfirm.Checked = true;

            BtnSave.Enabled = true;
            dgLine.ReadOnly = false;
            dgQPF_MC_1201.ReadOnly = false;
            txtComment_AgeingResult.ReadOnly = false;
            RdoConfirm.Enabled = true;
            RdoNotComfirm.Enabled = true;
            cmbVerifiedBy.Enabled = true;
            cmbCheckedBy.Enabled = true;
        }

        private void SavePdfFile()
        {
            try
            {

                QTMS.Reports.AgeingTest_Report AgeingTestReport = new QTMS.Reports.AgeingTest_Report();

                    DataSet ds = new DataSet();
                    ds = AgeingTest_Class_Obj.SELECT_View_AgeingTest_Report();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string FileName = "";
                        AgeingTestReport.SetDataSource(ds.Tables[0]);

                        if (AgeingTest_Class_Obj.filename != null && AgeingTest_Class_Obj.filename != "")
                        {
                            FileName = AgeingTest_Class_Obj.filename;
                        }
                        else
                        {
                            FileName = CmbFormulaNo.Text + "_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
                            AgeingTest_Class_Obj.filename = FileName;
                            
                        }

                        ExportOptions CrExportOptions;
                        DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                        PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                        // CrDiskFileDestinationOptions.DiskFileName = Application.StartupPath+ "\\SampleReport.pdf"; HHmmss
                        CrDiskFileDestinationOptions.DiskFileName = Application.StartupPath + "\\" + FileName;

                        CrExportOptions = AgeingTestReport.ExportOptions;
                        {
                            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                            CrExportOptions.FormatOptions = CrFormatTypeOptions;
                        }
                        AgeingTestReport.SetParameterValue("CompanyName", Convert.ToString(GlobalVariables.companyName));
                        AgeingTestReport.SetParameterValue("CompanyAddress", Convert.ToString(GlobalVariables.companyAddress));
                        AgeingTestReport.Export();

                        string FilePath = System.Configuration.ConfigurationManager.AppSettings["AgeingFile"].ToString();
                        if (!System.IO.Directory.Exists(FilePath))
                            System.IO.Directory.CreateDirectory(FilePath);

                        if (System.IO.File.Exists(FilePath + "\\" + FileName))
                            System.IO.File.Delete(FilePath + "\\" + FileName);

                        System.IO.File.Move(Application.StartupPath + "\\" + FileName, FilePath + "\\" + FileName);

                        AgeingTest_Class_Obj.STP_Update_tblAgeingTestReminder();
                          
                    }
                    else
                    {

                        MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}