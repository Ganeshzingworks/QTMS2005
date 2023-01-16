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
    public partial class FrmLineSamplingModification : Form
    {
        
        public FrmLineSamplingModification()
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
        # endregion

        private static FrmLineSamplingModification frmLineSamplingModification_Obj = null;
        public static FrmLineSamplingModification GetInstance()
        {
            if (frmLineSamplingModification_Obj == null)
            {
                frmLineSamplingModification_Obj = new FrmLineSamplingModification();
            }
            return frmLineSamplingModification_Obj;
        }

        private void FrmLineSamplingModification_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            LoadStatus = "Load";
            DtpTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpFrom.Value = DtpTo.Value.AddDays(-5);

            Bind_Details();
            Bind_Tank();
            Bind_InspectedBy();
            Bind_VerifiedBy();
            CmbDetails.Focus();
            LoadStatus = "LoadComplete";
            DtpFillDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpLSD.Value = Comman_Class_Obj.Select_ServerDate();
            LineSampleDetails_Class_Obj.tlfid = 0;
        }
        private string _LoadStatus;

        public string LoadStatus
        {
            get { return _LoadStatus; }
            set { _LoadStatus = value; }
        }
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

        public void Bind_Details()
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

            DataSet ds = new DataSet();
            DataRow dr;
            ds = LineSampleDetails_Class_Obj.Select_ModificationLineSampleDetailsforDropDown();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            dr["LineSampleNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbDetails.DataSource = ds.Tables[0];
                CmbDetails.ValueMember = "LineSampleNo";
                CmbDetails.DisplayMember = "Details";
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

        private void CmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                reset();
                if (CmbDetails.SelectedValue != null && CmbDetails.SelectedValue.ToString() != "")
                {
                    DataSet ds = new DataSet();
                    LineSampleDetails_Class_Obj.linesampleno = Convert.ToInt64(CmbDetails.SelectedValue);
                    ds = LineSampleDetails_Class_Obj.Select_ModificationLineSampleDetails_Details();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        LineSampleDetails_Class_Obj.tlfid = Convert.ToInt64(ds.Tables[0].Rows[0]["TLFID"]);

                        txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["BulkDesc"]);
                        txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);                                                
                        txtBatchCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["BatchNo"]);
                        txtLineNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["LineDesc"]);
                        txtFillVolume.Text = Convert.ToString(ds.Tables[0].Rows[0]["FillVolume"]);

                        DtpInspDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspDate"]);
                        DtpFillDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["FillDate"]);

                        if (ds.Tables[0].Rows[0]["Status"].ToString() == "A")
                        {
                            RdoAccepted.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "R")
                        {
                            RdoRejected.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "H")
                        {
                            RdoHold.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "D")
                        {
                            RdoAcceptedwithDerrogation.Checked = true;
                        }

                        txtComment_Accepted.Text = ds.Tables[0].Rows[0]["Comments"].ToString();

                        cmbInspectedBy.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["InspectedBy"]);
                        if (ds.Tables[0].Rows[0]["VerifiedBy"].ToString()!="")
                            cmbVerifiedBy.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["VerifiedBy"]);

                        //DtpLSD.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["LSD"]);
                        //txtCMW.Text = ds.Tables[0].Rows[0]["CMW"].ToString();
                        //txtCST.Text = ds.Tables[0].Rows[0]["CST"].ToString();


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

                        LstTank.DataSource = ds_Tank.Tables[0];
                        LstTank.DisplayMember = ds_Tank.Tables[0].Columns["TkDesc"].ToString();

                        //-------------Display Tank Details that are already filled
                        dataGridView.Rows.Clear();
                        DataSet dsTk = new DataSet();

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (dataGridView.Rows[i].Selected == true)
                    {
                        dataGridView.Rows.RemoveAt(i);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbDetails.Focus();
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


                ////for (int i = 0; i < dataGridView.Rows.Count; i++)
                ////{
                ////    LineSampleDetails_Class_Obj.tankno = Convert.ToInt32(dataGridView["TankNo", i].Value);
                ////    LineSampleDetails_Class_Obj.cmw = Convert.ToString(dataGridView["CMW", i].Value);
                ////    LineSampleDetails_Class_Obj.cst = Convert.ToString(dataGridView["CST", i].Value);
                ////    //string st = Convert.ToString(dataGridView["LSD", i].Value);

                ////    DateTimeFormatInfo usDtfi = new CultureInfo("en-IN", false).DateTimeFormat;
                ////    LineSampleDetails_Class_Obj.lsd = DateTime.Parse(Convert.ToString(dataGridView["LSD", i].Value), usDtfi);

                ////    //DateTime DT = new DateTime();
                ////    //DT = Convert.ToDateTime(dataGridView["LSD", i].Value);
                ////    ////LineSampleDetails_Class_Obj.lsd = Convert.ToString(dataGridView["LSD", i].Value);
                ////    //LineSampleDetails_Class_Obj.lsd = DT.ToShortDateString();

                ////    bool a = LineSampleDetails_Class_Obj.Insert_Update_tblFillTankSamp();
                ////}


                //LineSampleDetails_Class_Obj.tlfid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                LineSampleDetails_Class_Obj.inspdate = DtpInspDate.Value.ToShortDateString();

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
                LineSampleDetails_Class_Obj.cmw = txtCMW.Text;
                LineSampleDetails_Class_Obj.cst = txtCST.Text;

                LineSampleDetails_Class_Obj.loginid = FrmMain.LoginID;

                DataSet ds = new DataSet();
                ds = LineSampleDetails_Class_Obj.Select_tblFillSamp_TLFID();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    bool a = LineSampleDetails_Class_Obj.Update_tblFillSamp();
                }
                else
                {
                    bool b = LineSampleDetails_Class_Obj.INSERT_tblFillSample();

                }

                MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BtnReset_Click(sender, e);
                Bind_Details();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if ((CmbDetails.Text == "--Select--" || CmbDetails.SelectedValue == null || CmbDetails.SelectedValue.ToString() == ""))
                {
                    MessageBox.Show("Please Select Details ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbDetails.Focus();
                    return;
                }

                if (MessageBox.Show("Are you sure want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    bool b = LineSampleDetails_Class_Obj.Delete_tblFillTankSamp();
                    if (b == true)
                    {
                        bool b1 = LineSampleDetails_Class_Obj.Delete_tblFillSamp();
                        if (b1 == true)
                        {
                            LineSampleDetails_Class_Obj.linesampdone = false;
                            bool b2 = LineSampleDetails_Class_Obj.Update_tblTransTLF_LineSampDone();

                            MessageBox.Show("Record Deleted Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Bind_Details();
                            BtnReset_Click(sender, e);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Cant Delete This Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                CmbDetails.Text = "--Select--";
                reset();
                CmbDetails.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void reset()
        {
            txtTechnicalFamily.Text = "";
            txtComment_Accepted.Text = "";
            txtBatchCode.Text = "";            
            txtDescription.Text = "";
            DtpFillDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
            dataGridView.Rows.Clear();           

            DataTable dt = new DataTable();
            LstTank.DataSource = dt;


            RdoAccepted.Checked = true;
            txtFillVolume.Text = "";

            txtLineNo.Text = "";
            cmbVerifiedBy.Text = "--Select--";
            cmbInspectedBy.Text = "--Select--";

            txtCST.Text = "";
            txtCMW.Text = "";
            DtpLSD.Value = Comman_Class_Obj.Select_ServerDate();
        }


        private void txtPHLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only 0-9 and dot(.) allowed
            if ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 46))
            {
                if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
                {

                }
                else
                { e.Handled = true; }
            }
        }

        private void txtH2O2Level_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only 0-9 and dot(.) allowed
            if ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 46))
            {
                if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
                {

                }
                else
                { e.Handled = true; }
            }
        }

        private void txtDyeTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only 0-9 and dot(.) allowed
            if ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 46))
            {
                if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
                {

                }
                else
                { e.Handled = true; }
            }
        }


        private void txtBatchCode_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtBatchCode.Text = textInfo.ToTitleCase(txtBatchCode.Text);
        }

        private void RdoAcceptedwithDerrogation_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoAcceptedwithDerrogation.Checked == true)
            {
                txtComment_Accepted.Enabled = true;                
            }
            else if (RdoAcceptedwithDerrogation.Checked == false)
            {
                txtComment_Accepted.Enabled = false;
                txtComment_Accepted.Text = "";
            }
        }

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
                    Line_Obj.L_tlfid = LineSampleDetails_Class_Obj.tlfid;
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

                    if (dataGridView[e.ColumnIndex, e.RowIndex].Value == null || dataGridView[e.ColumnIndex, e.RowIndex].Value == "")
                    {
                        Line_Obj.Done = 'N';
                    }
                    else
                    {
                        Line_Obj.Done = 'Y';
                    }

                    //FrmLineTest fm = new FrmLineTest(LineTesting_Class_Obj.fno, LineTesting_Class_Obj.tlfid, LineTesting_Class_Obj.tankno,LineTesting_Class_Obj.sampletestdesc);                    
                    FrmLineTest fm = new FrmLineTest(Line_Obj);
                    fm.ShowDialog();

                    LineTesting_Class_Obj.tlfid = LineSampleDetails_Class_Obj.tlfid;
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
                //dataGridView["LSD", dataGridView.Rows.Count - 1].Value = Comman_Class_Obj.Select_ServerDate().ToString("dd-MM-yyyy");
                //dataGridView.Columns[10].DefaultCellStyle.Format = "dd-MM-yyyy";
                CmbTank.Text = "--Select--";
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMFgwo_Leave(object sender, EventArgs e)
        {
            if (txtMFgwo.Text.Length > 5)
            {
                Show_MfgWo();
            }   
        }
        private void Show_MfgWo()
        {
            try
            {
               
                //if (txtMFgwo.Text.StartsWith("B5"))
                //    txtMFgwo.Text = txtMFgwo.Text.Replace("B5", "");
                //LineSampleDetails_Class_Obj.mfgwo = Convert.ToString("%" + txtMFgwo.Text.Replace("B5", ""));
                
                if (txtMFgwo.Text.Length>=5)
                    LineSampleDetails_Class_Obj.mfgwo = Convert.ToString("%" + txtMFgwo.Text.Substring(txtMFgwo.Text.Length - 5));
                else
                    LineSampleDetails_Class_Obj.mfgwo = Convert.ToString("%" + txtMFgwo.Text.Trim());
                DataRow dr;
                DataTable dt = new DataTable();
                dt = LineSampleDetails_Class_Obj.Select_ModificationLineSampleDetails_Mfgwo();
                dr = dt.NewRow();
                dr["Details"] = "--Select--";
                dr["LineSampleNo"] = "0";
                dt.Rows.InsertAt(dr, 0);
                if (dt.Rows.Count > 0)
                {
                    CmbDetails.DataSource = dt;
                    CmbDetails.ValueMember = "LineSampleNo";
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
            //}
            Show_MfgWo();
            CmbDetails.Focus();
        }

        private void DtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMFgwo.Text.Trim() != "")
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
                    if (!string.IsNullOrEmpty(LoadStatus))
                    {
                        if (LoadStatus.Equals("LoadComplete"))
                        {
                            Bind_Details();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void DtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMFgwo.Text.Trim() != "")
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
                    if (!string.IsNullOrEmpty(LoadStatus))
                    {
                        if (LoadStatus.Equals("LoadComplete"))
                        {
                            Bind_Details();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
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