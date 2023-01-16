/********************************************************
*Author: Vijay Tomake
*Date: 
*Description: Transaction form to enter Line Sample Details
*Revision:
********************************************************/

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

namespace QTMS.Transactions
{
    public partial class FrmLineSampling : Form
    {

        public FrmLineSampling()
        {
            InitializeComponent();
        }

        # region Varibles
        public bool BindFormulaNo = false;
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Obj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
        TankMaster_Class TankMaster_Class_Obj = new TankMaster_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        BusinessFacade.Transactions.LineSampleDetails_Class LineSampleDetails_Class_Obj = new BusinessFacade.Transactions.LineSampleDetails_Class();
        BusinessFacade.Transactions.LineTesting_Class LineTesting_Class_Obj = new BusinessFacade.Transactions.LineTesting_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();

        DateTime GrdDate = new DateTime();
        # endregion

        /// <summary>
        /// get the active instance of the form 
        /// </summary>
        private static FrmLineSampling frmLineSampling_Obj = null;
        public static FrmLineSampling GetInstance()
        {
            if (frmLineSampling_Obj == null)
            {
                frmLineSampling_Obj = new FrmLineSampling();
            }
            return frmLineSampling_Obj;
        }

        private string _LoadStatus;

        public string LoadStatus
        {
            get { return _LoadStatus; }
            set { _LoadStatus = value; }
        }

        /// <summary>
        /// Form Load method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLineSampling_Load(object sender, EventArgs e)
        {
            //  this.WindowState = FormWindowState.Maximized;
            LoadStatus = "Load";
            Painter.Paint(this);
            //DateTime dt = DateTime.Now;
            GrdDate = Comman_Class_Obj.Select_ServerDate();
            DtpTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpFrom.Value = DtpTo.Value.AddDays(-5);
            Bind_Details();
            LoadStatus = "LoadComplete";
            Bind_Tank();
            Bind_InspectedBy();
            Bind_VerifiedBy();
            CmbDetails.Focus();
            DtpFillDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpLSD.Value = Comman_Class_Obj.Select_ServerDate();
            LineSampleDetails_Class_Obj.tlfid = 0;


        }

        /// <summary>
        /// Value change event of DtpFrom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMFgwo.Text.Trim() == "")
                {
                    if (!string.IsNullOrEmpty(LoadStatus))
                    {
                        if (LoadStatus.Equals("LoadComplete"))
                        {
                            txtMFgwo_Leave(sender, e);
                        }
                    }
                }
                else
                {
                    Bind_Details();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        /// <summary>
        /// value change event of DtpTo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMFgwo.Text.Trim() == "")
                {
                    if (!string.IsNullOrEmpty(LoadStatus))
                    {
                        if (LoadStatus.Equals("LoadComplete"))
                        {
                            txtMFgwo_Leave(sender, e);
                        }
                    }
                }
                else
                {
                    Bind_Details();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        /// <summary>
        /// Bind the details within the from and to range from line packing entries        
        /// </summary>
        public void Bind_Details()
        {
            try
            {
                if (DtpFrom.Checked == true)
                {
                    LineSampleDetails_Class_Obj.fromdate = DtpFrom.Value.ToShortDateString();
                }
                else
                {
                    LineSampleDetails_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpTo.Checked == true)
                {
                    LineSampleDetails_Class_Obj.todate = DtpTo.Value.ToShortDateString();
                }
                else
                {
                    LineSampleDetails_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }

                //Get the pending line sampling entries
                DataSet ds = new DataSet();
                DataRow dr;
                ds = LineSampleDetails_Class_Obj.Select_PendingLineSampleDetails();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CmbDetails.DataSource = ds.Tables[0];
                    CmbDetails.ValueMember = "TLFID";
                    CmbDetails.DisplayMember = "Details";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        /// <summary>
        /// Binds the tank
        /// </summary>
        public void Bind_Tank()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = TankMaster_Class_Obj.Select_TankMaster();
                dr = ds.Tables[0].NewRow();
                dr["TkDesc"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CmbTank.DataSource = ds.Tables[0];
                    CmbTank.DisplayMember = "TkDesc";
                    CmbTank.ValueMember = "TankNo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Binds the user
        /// </summary>
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

        /// <summary>
        /// Selection change event of details combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblIsScoopApplicable.Visible = false;
            if (CmbDetails.SelectedValue != null && CmbDetails.SelectedValue.ToString() != "")
            {
                //get the details from selected TLF entry
                DataSet ds = new DataSet();
                LineSampleDetails_Class_Obj.tlfid = Convert.ToInt64(CmbDetails.SelectedValue);
                ds = LineSampleDetails_Class_Obj.Select_LineSampleDetails_TLFID();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["BulkDesc"]);
                    txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);
                    DtpFillDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["FillDate"]);
                    txtBatchCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["BatchNo"]);
                    txtLineNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["LineDesc"]);
                    txtFillVolume.Text = Convert.ToString(ds.Tables[0].Rows[0]["FillVolume"]);

                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["ScoopApplicable"].ToString()) == true)
                    {
                        lblIsScoopApplicable.Font = new Font("Times New Roman", 14, FontStyle.Bold);
                        lblIsScoopApplicable.ForeColor = Color.Red;
                        lblIsScoopApplicable.Text = "SCOOP IS APPLICABLE FOR THIS LINE.";
                        lblIsScoopApplicable.Visible = true;
                    }
                    else
                    {
                        lblIsScoopApplicable.Visible = false;
                    }

                    //used in Line testing
                    LineTesting_Class_Obj.fno = Convert.ToInt64(ds.Tables[0].Rows[0]["FNo"].ToString());

                    //-------- Display Tanks that are assigned in BulkTest  -----------

                    // Now Show Tank Details On Grid
                    DataSet ds_Tank = new DataSet();
                    LineSampleDetails_Class_Obj.fmid = Convert.ToInt64(ds.Tables[0].Rows[0]["FMID"]);
                    ds_Tank = LineSampleDetails_Class_Obj.Select_TankDetails_FMID();

                    //dataGridView.Rows.Clear();

                    //if (ds_Tank.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i < ds_Tank.Tables[0].Rows.Count; i++)
                    //    {                           

                    //        dataGridView.Rows.Add();
                    //        dataGridView["BulkTankDetailNo", i].Value = Convert.ToString(ds_Tank.Tables[0].Rows[i]["BulkTankDetailNo"]);
                    //        dataGridView["TankNo", i].Value = Convert.ToString(ds_Tank.Tables[0].Rows[i]["tankno"]);
                    //        dataGridView["TankDesc", i].Value = Convert.ToString(ds_Tank.Tables[0].Rows[i]["tkdesc"]);                           
                    //    }
                    //}

                    //Bind the assigned tanks from bulk test to tank ListBox
                    LstTank.DataSource = ds_Tank.Tables[0];
                    LstTank.DisplayMember = ds_Tank.Tables[0].Columns["TkDesc"].ToString();

                    //-------------Display Tank Details that are already filled
                    dataGridView.Rows.Clear();
                    DataSet dsTk = new DataSet();
                    LineSampleDetails_Class_Obj.tlfid = Convert.ToInt64(CmbDetails.SelectedValue);
                    dsTk = LineSampleDetails_Class_Obj.SELECT_tblFillTankSamp_tblTankMaster_TLFID();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsTk.Tables[0].Rows.Count; i++)
                        {
                            dataGridView.Rows.Add();
                            dataGridView["TankNo", i].Value = dsTk.Tables[0].Rows[i]["TankNo"].ToString();
                            dataGridView["TankDesc", i].Value = dsTk.Tables[0].Rows[i]["TkDesc"].ToString();
                            //dataGridView["CMW", i].Value = dsTk.Tables[0].Rows[i]["CMW"].ToString();
                            //dataGridView["CST", i].Value = dsTk.Tables[0].Rows[i]["CST"].ToString();
                            //if (dsTk.Tables[0].Rows[i]["LSD"].ToString() == "")
                            //{
                            //    dataGridView["LSD", dataGridView.Rows.Count - 1].Value = Comman_Class_Obj.Select_ServerDate().ToString("dd-MM-yyyy");
                            //    dataGridView.Columns[10].DefaultCellStyle.Format = "dd-MM-yyyy";
                            //}
                            //else
                            //    dataGridView["LSD", i].Value = dsTk.Tables[0].Rows[i]["LSD"].ToString();
                        }
                    }

                    //---------- Display Results --------------------

                    DataSet ds_Result = new DataSet();
                    LineSampleDetails_Class_Obj.tlfid = Convert.ToInt64(CmbDetails.SelectedValue);
                    ds_Result = LineSampleDetails_Class_Obj.SELECT_tblFillTankSamp_TLFID();
                    if (ds_Result.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_Result.Tables[0].Rows.Count; i++)
                        {
                            for (int d = 0; d < dataGridView.Rows.Count; d++)
                            {
                                if (ds_Result.Tables[0].Rows[i]["TankNo"].ToString() == dataGridView["TankNo", d].Value.ToString())
                                {
                                    if (ds_Result.Tables[0].Rows[i]["SampTestDesc"].ToString() == "SST")
                                    {
                                        dataGridView["SST", d].Value = ds_Result.Tables[0].Rows[i]["SampTestResult"].ToString();
                                    }
                                    if (ds_Result.Tables[0].Rows[i]["SampTestDesc"].ToString() == "Mins30")
                                    {
                                        dataGridView["Mins30", d].Value = ds_Result.Tables[0].Rows[i]["SampTestResult"].ToString();
                                    }
                                    if (ds_Result.Tables[0].Rows[i]["SampTestDesc"].ToString() == "FSD")
                                    {
                                        dataGridView["FSD", d].Value = ds_Result.Tables[0].Rows[i]["SampTestResult"].ToString();
                                    }
                                    if (ds_Result.Tables[0].Rows[i]["SampTestDesc"].ToString() == "EST")
                                    {
                                        dataGridView["EST", d].Value = ds_Result.Tables[0].Rows[i]["SampTestResult"].ToString();
                                    }
                                    if (ds_Result.Tables[0].Rows[i]["SampTestDesc"].ToString() == "Cric1")
                                    {
                                        dataGridView["Cric1", d].Value = ds_Result.Tables[0].Rows[i]["SampTestResult"].ToString();
                                    }
                                    if (ds_Result.Tables[0].Rows[i]["SampTestDesc"].ToString() == "Cric2")
                                    {
                                        dataGridView["Cric2", d].Value = ds_Result.Tables[0].Rows[i]["SampTestResult"].ToString();
                                    }
                                    if (ds_Result.Tables[0].Rows[i]["SampTestDesc"].ToString() == "CMW")
                                    {
                                        dataGridView["CMW", d].Value = ds_Result.Tables[0].Rows[i]["SampTestResult"].ToString();
                                    }
                                    if (ds_Result.Tables[0].Rows[i]["SampTestDesc"].ToString() == "CST")
                                    {
                                        dataGridView["CST", d].Value = ds_Result.Tables[0].Rows[i]["SampTestResult"].ToString();
                                    }
                                    if (ds_Result.Tables[0].Rows[i]["SampTestDesc"].ToString() == "LSD")
                                    {
                                        dataGridView["LSD", d].Value = ds_Result.Tables[0].Rows[i]["SampTestResult"].ToString();
                                    }
                                }
                            }
                        }
                    }

                }
            }
            else
            {
                txtDescription.Text = "";
                txtTechnicalFamily.Text = "";
                DtpFillDate.Value = Comman_Class_Obj.Select_ServerDate();
                txtBatchCode.Text = "";
                txtLineNo.Text = "";
                txtFillVolume.Text = "";
                dataGridView.Rows.Clear();

                DataTable dt = new DataTable();
                LstTank.DataSource = dt;

            }

        }

        /// <summary>
        /// selected index change event of Formula combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbFormulaNo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Saves the line sample details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbDetails.Focus();
                    lblIsScoopApplicable.Visible = false;//<----------Scoop msg
                    return;
                }

                if (RdoAcceptedwithDerrogation.Checked == true)
                {
                    if (txtComment_Accepted.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter Derrogation Comment", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtComment_Accepted.Text = "";
                        txtComment_Accepted.Focus();
                        return;
                    }
                }
                if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbInspectedBy.Focus();
                    return;
                }
                if (cmbVerifiedBy.SelectedValue == null || cmbVerifiedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Verified By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVerifiedBy.Focus();
                    return;
                }

                LineSampleDetails_Class_Obj.tlfid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                LineSampleDetails_Class_Obj.inspdate = DtpInspDate.Value.ToShortDateString();


                ////for (int i = 0; i < dataGridView.Rows.Count; i++)
                ////{
                ////    LineSampleDetails_Class_Obj.tankno = Convert.ToInt32(dataGridView["TankNo", i].Value);
                ////    ////LineSampleDetails_Class_Obj.cmw = Convert.ToString(dataGridView["CMW", i].Value);
                ////    ////LineSampleDetails_Class_Obj.cst = Convert.ToString(dataGridView["CST", i].Value);
                ////    ////string st = Convert.ToString(dataGridView["LSD", i].Value);

                ////    ////DateTimeFormatInfo usDtfi = new CultureInfo("en-IN", false).DateTimeFormat;
                ////    ////LineSampleDetails_Class_Obj.lsd = DateTime.Parse(Convert.ToString(dataGridView["LSD", i].Value), usDtfi);

                ////    //DateTime DT = new DateTime();
                ////    //DT = Convert.ToDateTime(dataGridView["LSD", i].Value);
                ////    ////LineSampleDetails_Class_Obj.lsd = Convert.ToString(dataGridView["LSD", i].Value);
                ////    //LineSampleDetails_Class_Obj.lsd = DT.ToShortDateString();

                ////    bool a = LineSampleDetails_Class_Obj.Insert_Update_tblFillTankSamp();
                ////}


                LineSampleDetails_Class_Obj.comments = "";

                if (RdoAccepted.Checked == true)
                {
                    LineSampleDetails_Class_Obj.status = Convert.ToChar("A");
                }

                else if (RdoAcceptedwithDerrogation.Checked == true)
                {
                    LineSampleDetails_Class_Obj.status = Convert.ToChar("D");
                    LineSampleDetails_Class_Obj.comments = txtComment_Accepted.Text;
                }
                else if (RdoRejected.Checked == true)
                {
                    LineSampleDetails_Class_Obj.status = Convert.ToChar("R");
                }
                else if (RdoHold.Checked == true)
                {
                    LineSampleDetails_Class_Obj.status = Convert.ToChar("H");
                }

                LineSampleDetails_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);
                LineSampleDetails_Class_Obj.verifiedby = Convert.ToInt32(cmbVerifiedBy.SelectedValue);
                //LineSampleDetails_Class_Obj.lsd = DtpLSD.Value.ToShortDateString();
                //LineSampleDetails_Class_Obj.cmw = txtCMW.Text;
                //LineSampleDetails_Class_Obj.cst = txtCST.Text;

                LineSampleDetails_Class_Obj.loginid = FrmMain.LoginID;

                DataSet ds = new DataSet();
                ds = LineSampleDetails_Class_Obj.Select_tblFillSamp_TLFID();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //update line sample transaction details 
                    bool a = LineSampleDetails_Class_Obj.Update_tblFillSamp();
                }
                else
                {
                    //saves line sample transaction details 
                    bool b = LineSampleDetails_Class_Obj.INSERT_tblFillSample();
                }

                MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BtnReset_Click(sender, e);
                lblIsScoopApplicable.Visible = false;//<----------Scoop msg
                Bind_Details();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// resets control on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                CmbDetails.Text = "--Select--";

                txtTechnicalFamily.Text = "";
                txtComment_Accepted.Text = "";
                txtBatchCode.Text = "";
                txtDescription.Text = "";
                dataGridView.Rows.Clear();
                CmbDetails.Focus();

                DataTable dt = new DataTable();
                LstTank.DataSource = dt;


                RdoAccepted.Checked = true;
                txtFillVolume.Text = "";
                cmbInspectedBy.Text = "--Select--";
                cmbVerifiedBy.Text = "--Select--";
                lblIsScoopApplicable.Visible = false;

                txtCST.Text = "";
                txtCMW.Text = "";
                DtpLSD.Value = Comman_Class_Obj.Select_ServerDate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// key press event of Batch Code text box 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBatchCode_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtBatchCode.Text = textInfo.ToTitleCase(txtBatchCode.Text);
        }

        /// <summary>
        /// ckecked change event for AWD radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoAcceptedwithDerrogation_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoAcceptedwithDerrogation.Checked == true)
            {

                txtComment_Accepted.Enabled = true;
                txtComment_Accepted.Focus();
            }
            else
            {

                txtComment_Accepted.Enabled = false;
            }
        }

        /// <summary>
        /// Add tanks to datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CmbTank.Text == "--Select--" || CmbTank.SelectedValue == null || CmbTank.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Select Tank...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                CmbTank.Focus();
                return;
            }
            else
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    //ckech whether tank already exists
                    if (dataGridView["TankNo", i].Value.ToString() == CmbTank.SelectedValue.ToString())
                    {
                        MessageBox.Show("This Tank already Exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        CmbTank.Focus();
                        return;
                    }
                }

                dataGridView.Rows.Add();
                dataGridView["TankNo", dataGridView.Rows.Count - 1].Value = CmbTank.SelectedValue.ToString();
                dataGridView["TankDesc", dataGridView.Rows.Count - 1].Value = CmbTank.Text;
                //dataGridView.Columns[10].DefaultCellStyle.Format = "dd-MM-yyyy";
                //dataGridView["LSD", dataGridView.Rows.Count - 1].Value = Comman_Class_Obj.Select_ServerDate().ToString("dd-MM-yyyy");
                //dataGridView.Columns[10].DefaultCellStyle.Format = "dd-MM-yyyy";
                CmbTank.Text = "--Select--";
            }
        }

        /// <summary>
        /// Cell click event for datagridview
        /// Open the popup for sampling details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                if ((e.RowIndex > -1) && (e.ColumnIndex == dataGridView.Columns["SST"].Index
                                         || e.ColumnIndex == dataGridView.Columns["Mins30"].Index
                                         || e.ColumnIndex == dataGridView.Columns["FSD"].Index
                                         || e.ColumnIndex == dataGridView.Columns["EST"].Index
                                         || e.ColumnIndex == dataGridView.Columns["Cric1"].Index
                                         || e.ColumnIndex == dataGridView.Columns["Cric2"].Index
                                         || e.ColumnIndex == dataGridView.Columns["CMW"].Index
                                         || e.ColumnIndex == dataGridView.Columns["CST"].Index
                                         || e.ColumnIndex == dataGridView.Columns["LSD"].Index))
                {

                    FrmLineTest.Line Line_Obj = new FrmLineTest.Line();
                    Line_Obj.L_fno = LineTesting_Class_Obj.fno;
                    Line_Obj.L_tlfid = Convert.ToInt64(CmbDetails.SelectedValue);
                    Line_Obj.L_tankno = Convert.ToInt64(dataGridView["TankNo", e.RowIndex].Value);

                    if (e.ColumnIndex == dataGridView.Columns["SST"].Index)
                    {
                        Line_Obj.L_samptestdesc = "SST";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["Mins30"].Index)
                    {
                        Line_Obj.L_samptestdesc = "Mins30";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["FSD"].Index)
                    {
                        Line_Obj.L_samptestdesc = "FSD";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["EST"].Index)
                    {
                        Line_Obj.L_samptestdesc = "EST";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["Cric1"].Index)
                    {
                        Line_Obj.L_samptestdesc = "Cric1";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["Cric2"].Index)
                    {
                        Line_Obj.L_samptestdesc = "Cric2";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["CMW"].Index)
                    {
                        Line_Obj.L_samptestdesc = "CMW";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["CST"].Index)
                    {
                        Line_Obj.L_samptestdesc = "CST";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["LSD"].Index)
                    {
                        Line_Obj.L_samptestdesc = "LSD";
                    }

                    if (dataGridView[e.ColumnIndex, e.RowIndex].Value == null || dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() == "")
                    {
                        Line_Obj.Done = 'N';
                    }
                    else
                    {
                        Line_Obj.Done = 'Y';
                    }

                    //open pop up for sampling details                    
                    FrmLineTest fm = new FrmLineTest(Line_Obj);
                    fm.ShowDialog();

                    LineTesting_Class_Obj.tlfid = Convert.ToInt64(CmbDetails.SelectedValue);
                    LineTesting_Class_Obj.tankno = Convert.ToInt64(dataGridView["TankNo", e.RowIndex].Value);
                    if (e.ColumnIndex == dataGridView.Columns["SST"].Index)
                    {
                        LineTesting_Class_Obj.sampletestdesc = "SST";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["Mins30"].Index)
                    {
                        LineTesting_Class_Obj.sampletestdesc = "Mins30";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["FSD"].Index)
                    {
                        LineTesting_Class_Obj.sampletestdesc = "FSD";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["EST"].Index)
                    {
                        LineTesting_Class_Obj.sampletestdesc = "EST";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["Cric1"].Index)
                    {
                        LineTesting_Class_Obj.sampletestdesc = "Cric1";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["Cric2"].Index)
                    {
                        LineTesting_Class_Obj.sampletestdesc = "Cric2";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["CMW"].Index)
                    {
                        LineTesting_Class_Obj.sampletestdesc = "CMW";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["CST"].Index)
                    {
                        LineTesting_Class_Obj.sampletestdesc = "CST";
                    }
                    else if (e.ColumnIndex == dataGridView.Columns["LSD"].Index)
                    {
                        LineTesting_Class_Obj.sampletestdesc = "LSD";
                    }

                    //Select and Display SampTestResult in datadrid
                    DataSet ds = new DataSet();
                    ds = LineTesting_Class_Obj.Select_tblFillTankSamp_FillTankSampNo_SampTestResult();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dataGridView[e.ColumnIndex, e.RowIndex].Value = ds.Tables[0].Rows[0]["SampTestResult"].ToString();
                    }
                }
                ////else if ((e.RowIndex > -1) && (e.ColumnIndex == dataGridView.Columns["LSD"].Index))
                ////{
                ////    //Initialized a new DateTimePicker Control  
                ////    oDateTimePicker = new DateTimePicker();

                ////    //Adding DateTimePicker control into DataGridView   
                ////    dataGridView.Controls.Add(oDateTimePicker);

                ////    // Setting the format (i.e. 2014-10-10)  
                ////    oDateTimePicker.Format = DateTimePickerFormat.Custom;

                ////    oDateTimePicker.CustomFormat = "dd-MM-yyyy";

                ////    oDateTimePicker.MinDate = new DateTime(DtpInspDate.Value.Year, 1, 1);
                ////    oDateTimePicker.MaxDate = new DateTime(DtpInspDate.Value.Year, 12, 31);

                ////    // It returns the retangular area that represents the Display area for a cell  
                ////    Rectangle oRectangle = dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                ////    //Setting area for DateTimePicker Control  
                ////    oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                ////    // Setting Location  
                ////    oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                ////    //// An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                ////    oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                ////    //// An event attached to dateTimePicker Control which is fired when any date is selected  
                ////    oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                ////    // Now make it visible  
                ////    oDateTimePicker.Visible = true;
                ////}
            }
        }
        private DateTimePicker oDateTimePicker;
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMFgwo_Leave(object sender, EventArgs e)
        {
            Show_Mfgwo();
            //if (txtMFgwo.Text.Length > 5)
            //{
            //    Show_Mfgwo();
            //}                       
        }
        private void Show_Mfgwo()
        {
            try
            {
                if (DtpFrom.Checked == true)
                {
                    LineSampleDetails_Class_Obj.fromdate = DtpFrom.Value.ToShortDateString();
                }
                else
                {
                    LineSampleDetails_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpTo.Checked == true)
                {
                    LineSampleDetails_Class_Obj.todate = DtpTo.Value.ToShortDateString();
                }
                else
                {
                    LineSampleDetails_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }
                if (txtMFgwo.Text.Length >= 5)
                    LineSampleDetails_Class_Obj.mfgwo = Convert.ToString("%" + txtMFgwo.Text.Substring(txtMFgwo.Text.Length - 5));
                else
                    LineSampleDetails_Class_Obj.mfgwo = Convert.ToString("%" + txtMFgwo.Text.Trim());


                DataRow dr;
                DataTable dt = new DataTable();
                dt = LineSampleDetails_Class_Obj.Select_LineSampleDetails_Mfgwo();
                dr = dt.NewRow();
                dr["Details"] = "--Select--";
                dt.Rows.InsertAt(dr, 0);
                if (dt.Rows.Count > 0)
                {
                    CmbDetails.DataSource = dt;
                    CmbDetails.ValueMember = "TLFID";
                    CmbDetails.DisplayMember = "Details";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txtMFgwo.Text.Length < 5)
            //{                
            //    MessageBox.Show("Please enter minimum last five digit of MfgWo....");
            // //   return;
            //}
            Show_Mfgwo();
            //   txtMFgwo_Leave(sender,e);
            CmbDetails.Focus();
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dataGridView.CurrentCell.Value = oDateTimePicker.Text.ToString();
            //dgvLineTransaction.Rows[dgvLineTransaction.CurrentCell.RowIndex].Cells[dgvLineTransaction.CurrentCell.ColumnIndex + 1].Value = oDateTimePicker.Value.AddYears(1).ToString("dd-MM-yyyy");
        }
        private void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }



    }
}