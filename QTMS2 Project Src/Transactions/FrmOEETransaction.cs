using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
//using Gantt;
using System.Data.SqlClient;

namespace QTMS.Transactions
{
    public partial class FrmOEETransaction : Form
    {
        // Gantt.GanttChart GanttChart1 = new Gantt.GanttChart(); 

        public FrmOEETransaction()
        {
            InitializeComponent();
        }

        # region Varibles
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.OEETransactionTest_Class OEETransactionTest_Class_Obj = new BusinessFacade.Transactions.OEETransactionTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        bool Modify = false;
        # endregion

        private static FrmOEETransaction frmOEETransaction_Obj = null;
        public static FrmOEETransaction GetInstance()
        {
            if (frmOEETransaction_Obj == null)
            {
                frmOEETransaction_Obj = new FrmOEETransaction();
            }
            return frmOEETransaction_Obj;
        }

        private void FrmOEETransaction_Load(object sender, EventArgs e)
        {
            try
            {

                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                Bind_Details();
                Bind_Activity();
                Bind_Operator();
                Bind_Shift();
                BtnReset_Click(sender, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_Details()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = OEETransactionTest_Class_Obj.Select_OEEBulkTestDetails();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            dr["FMID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {

                cmbDetails.ValueMember = "FMID";
                cmbDetails.DisplayMember = "Details"; cmbDetails.DataSource = ds.Tables[0];
            }
        }

        private void Bind_Activity()
        {
            try
            {
                DataTable Dt = OEETransactionTest_Class_Obj.Select_tblOEEActivityMaster();
                DataRow dr;
                dr = Dt.NewRow();
                dr["Activity"] = "--Select--";
                dr["ActivityID"] = "0";
                Dt.Rows.InsertAt(dr, 0);
                if (Dt.Rows.Count > 0)
                {
                    //Bind to cmb under shift details 

                    cmbActivity.DisplayMember = "Activity";
                    cmbActivity.ValueMember = "ActivityID";
                    cmbActivity.DataSource = Dt;
                    //Bind to grid column under activity details 
                    DataTable DtGrid = OEETransactionTest_Class_Obj.Select_tblOEEActivityMaster();
                    DataGridViewComboBoxColumn DataGridViewComboBoxColumnObj;
                    DataGridViewComboBoxColumnObj = (DataGridViewComboBoxColumn)(DgActivity.Columns[5]);


                    DataGridViewComboBoxColumnObj.DisplayMember = "Activity";
                    DataGridViewComboBoxColumnObj.ValueMember = "ActivityID";
                    DataGridViewComboBoxColumnObj.DataSource = DtGrid;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        //private void Bind_Activity()
        //{
        //    try
        //    {
        //        DataGridViewComboBoxColumn DataGridViewComboBoxColumnObj;
        //        //DataGridViewComboBoxColumnObj = (DataGridViewComboBoxColumn)(dgPkgDesc.Columns[0]);
        //        DataTable DtNatureRef = new DataTable();
        //        DataRow dr;
        //        //DtNatureRef = CompatibilityMaster_Class_Obj.SELECT_tblCompatAcNatureMaster();

        //        dr = DtNatureRef.NewRow();
        //        dr["AcNatureNo"] = "0";
        //        dr["AcNatureRef"] = "--Select--";
        //        DtNatureRef.Rows.InsertAt(dr, 0);

        //        if (DtNatureRef.Rows.Count > 0)
        //        {
        //            //DataGridViewComboBoxColumnObj.DataSource = DtNatureRef;
        //            //DataGridViewComboBoxColumnObj.ValueMember = "AcNatureNo";
        //            //DataGridViewComboBoxColumnObj.DisplayMember = "AcNatureRef";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public void Bind_Operator()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = UserManagement_Class_Obj.Select_Operator();
            dr = ds.Tables[0].NewRow();
            dr["UserName"] = "--Select--";
            dr["UserID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbOperator.DataSource = ds.Tables[0];
                cmbOperator.DisplayMember = "UserName";
                cmbOperator.ValueMember = "UserID";

                //Bind to grid column under activity details 
                DataTable DtGrid = UserManagement_Class_Obj.Select_Operator().Tables[0];
                DataGridViewComboBoxColumn DataGridViewComboBoxColumnObj;
                DataGridViewComboBoxColumnObj = (DataGridViewComboBoxColumn)(DgActivity.Columns[3]);


                DataGridViewComboBoxColumnObj.DisplayMember = "UserName";
                DataGridViewComboBoxColumnObj.ValueMember = "UserID";
                DataGridViewComboBoxColumnObj.DataSource = DtGrid;
            }
        }

        void DataGridViewComboBoxColumnObj_Disposed(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
            MessageBox.Show("Combobox event called");
        }

        public void Bind_Shift()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = OEETransactionTest_Class_Obj.Select_tblOEEShiftMaster();
            dr = ds.Tables[0].NewRow();
            dr["ShiftDetails"] = "--Select--";
            dr["ShiftID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbShift.DataSource = ds.Tables[0];
                cmbShift.DisplayMember = "ShiftDetails";
                cmbShift.ValueMember = "ShiftID";

                //Bind to grid column under activity details 
                //DataTable DtGrid = OEETransactionTest_Class_Obj.Select_tblOEEShiftMaster().Tables[0];
                //DataGridViewComboBoxColumn DataGridViewComboBoxColumnObj;
                //DataGridViewComboBoxColumnObj = (DataGridViewComboBoxColumn)(DgActivity.Columns[4]);

                //DataGridViewComboBoxColumnObj.DisplayMember = "ShiftDetails";
                //DataGridViewComboBoxColumnObj.ValueMember = "ShiftID";
                //DataGridViewComboBoxColumnObj.DataSource = DtGrid;
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            cmbDetails.Text = "--Select--";
            reset();
        }

        private void reset()
        {
            txtDesc.Text = "";
            txtVessel.Text = "";
            txtRecipeNorecipe.Text = "";
            txtTechFamily.Clear();
            txtBatchSize.Clear();
            txtTMT.Clear();
            txtTMT.BackColor = SystemColors.Control;
            DtpStartedOn.Value = Comman_Class_Obj.Select_ServerDate();
            cmbOperator.Text = "--Select--";
            cmbShift.Text = "--Select--";
            cmbActivity.Text = "--Select--";
            DgActivity.Rows.Clear();
            chkOverlap.Checked = false;
            DtpStartTime.Enabled = false;
            Reset_MinMaxDate();
            DtpStartTime.Value = DtpStartedOn.Value;
            DtpEndTime.Value = DtpStartedOn.Value;
            txtComment.Text = "";
            chkClose.Checked = false;
        }
        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                BtnAdd.Text = "Add";
                Reset_MinMaxDate();
                reset();
                if (cmbDetails.SelectedValue.ToString() != "0")
                {
                    DataTable Dt = new DataTable();
                    OEETransactionTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                    Dt = OEETransactionTest_Class_Obj.STP_Select_tblBulTestTransaction().Tables[0];
                    if (Dt.Rows.Count > 0)
                    {

                        OEEAct_CatRelationObj.vesselno = Convert.ToInt64(Dt.Rows[0]["VesselNo"]);
                        OEEAct_CatRelationObj.techfamno = Convert.ToInt64(Dt.Rows[0]["TechFamNo"]);

                        if (Dt.Rows[0]["StartedOn"] is DBNull)
                        {
                            DtpStartedOn.Enabled = true;
                        }
                        else
                        {
                            DtpStartedOn.Value = Convert.ToDateTime(Dt.Rows[0]["StartedOn"]);
                            DtpStartedOn.Enabled = false;
                        }
                        DateTime DateTimeObj = Comman_Class_Obj.Select_ServerDate();
                        DtpStartTime.Value = DateTime.Parse(DtpStartedOn.Value.ToShortDateString());// + " " + DateTimeObj.ToLongTimeString());
                        DtpEndTime.Value = DateTime.Parse(DtpStartedOn.Value.ToShortDateString());// + " " + DateTimeObj.ToLongTimeString());

                        txtDesc.Text = Convert.ToString(Dt.Rows[0]["BulkDesc"]);
                        txtVessel.Text = Convert.ToString(Dt.Rows[0]["VslDesc"]);
                        txtTechFamily.Text = Convert.ToString(Dt.Rows[0]["FamilyDesc"]);
                        txtBatchSize.Text = Convert.ToString(Dt.Rows[0]["BatchSize"]);

                        OEETransactionTest_Class_Obj.techFamNo = Convert.ToInt64(Dt.Rows[0]["TechFamNo"]);
                        OEETransactionTest_Class_Obj.batchsize = Convert.ToInt64(txtBatchSize.Text);


                        DataSet ds_Receipe = new DataSet();
                        ds_Receipe = OEETransactionTest_Class_Obj.Select_tblOEEMFGDetails();
                        if (ds_Receipe.Tables[0].Rows.Count > 0)
                        {
                            txtRecipeNorecipe.Text = ds_Receipe.Tables[0].Rows[0]["Recipe"].ToString();
                        }

                        long TMT = OEETransactionTest_Class_Obj.Select_OEETechFamTMTMaster_TMT();
                        if (TMT == 0)
                        {
                            MessageBox.Show("TMT (Target Manufacturing Time) not entered for this batch size and family");
                            txtTMT.BackColor = Color.Red;
                        }
                        else
                        {
                            txtTMT.Text = TMT.ToString();
                        }

                    }
                    DtpStartTime.Enabled = true;
                    //Bind_OperatorDetails();
                    Bind_ActivityDetails();
                    Set_EndTime();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Set_EndTime()
        {
            try
            {
                OEETransactionTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                try
                {
                    bool checkfirstactivity = false;
                    for (int i = 0; i < DgActivity.Rows.Count - 1; i++)
                    {
                        if (DgActivity["StartTime", i].Value.ToString() != "")
                        {
                            checkfirstactivity = true;
                            break;
                        }

                    }

                    if (checkfirstactivity == false)
                        return;
                }
                catch (Exception ex)
                { }

                DtpStartTime.MaxDate = OEETransactionTest_Class_Obj.Select_OEEActivityDetails_MaxEndTime();
                if (DtpStartTime.MaxDate != Convert.ToDateTime("31-Dec-2030"))//This date is explicitly set 
                {
                    DtpStartTime.Value = DtpStartTime.MaxDate;
                    DtpEndTime.MinDate = DtpStartTime.Value;
                    DtpEndTime.Value = DtpStartTime.Value;
                }
                else
                {
                    Reset_MinMaxDate();
                }
                chkOverlap.Checked = false;
                //DtpStartTime.Enabled = false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void Reset_MinMaxDate()
        {
            DtpStartTime.MaxDate = Convert.ToDateTime("12/31/9998");
            DtpEndTime.MinDate = Convert.ToDateTime("1/1/1753");
        }

        private void Bind_ActivityDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = OEETransactionTest_Class_Obj.Select_OEEActivityDetails();

                DgActivity.Rows.Clear();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DgActivity.Rows.Add();
                    DgActivity["MAID", i].Value = Convert.ToString(ds.Tables[0].Rows[i]["MAID"]);
                    DgActivity["FMID", i].Value = Convert.ToString(ds.Tables[0].Rows[i]["FMID"]);
                    //DgActivity["OPeratorID", i].Value = Convert.ToString(ds.Tables[0].Rows[i]["OSID"]);
                    DgActivity["Activity", i].Value = Convert.ToInt64(ds.Tables[0].Rows[i]["ActivityID"]);
                    DgActivity["Operator", i].Value = Convert.ToInt32(ds.Tables[0].Rows[i]["UserId"]);
                    DgActivity["Shift", i].Value = Convert.ToString(ds.Tables[0].Rows[i]["ShiftName"]);

                    if (Convert.ToString(ds.Tables[0].Rows[i]["KgsValue"]) != "")
                    {
                        DgActivity["StartTime", i].Value = "";
                        DgActivity["EndTime", i].Value = "";

                        DgActivity["TimeDiff", i].Value = Convert.ToString(ds.Tables[0].Rows[i]["KgsValue"]);
                    }
                    else
                    {
                        DgActivity["StartTime", i].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["StartTime"]).ToString("dd-MMM-yyyy HH:mm:ss");
                        DgActivity["EndTime", i].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["EndTime"]).ToString("dd-MMM-yyyy HH:mm:ss");
                        //Add new column Time Difference
                        TimeSpan timeDiff = (Convert.ToDateTime(ds.Tables[0].Rows[i]["EndTime"]) - Convert.ToDateTime(ds.Tables[0].Rows[i]["StartTime"]));
                        // string diff = new DateTime(timeDiff.Ticks).ToString("HH:mm:ss");
                        string diff = Convert.ToString(((timeDiff.Days * 24 * 60) + (timeDiff.Hours * 60) + (timeDiff.Minutes)) + ":" + (timeDiff.Seconds));
                        DgActivity["TimeDiff", i].Value = diff;
                    }
                    DgActivity["Comment", i].Value = Convert.ToString(ds.Tables[0].Rows[i]["Comment"]);
                    DgActivity.ClearSelection();
                    DtpStartTime.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool IsValid()
        {
            try
            {
                if (cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    cmbDetails.Focus();
                    return false;
                }
                //if (dgOperator.Rows.Count == 0)
                //{
                //    MessageBox.Show("Please add Operator", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                //    cmbOperator.Focus();
                //    return false;
                //}
                if (cmbActivity.Text == "--Select--")
                {
                    MessageBox.Show("Select Activity", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    cmbActivity.Focus();
                    return false;
                }
                if (txtKgs.Enabled == true)
                {
                    if (txtKgs.Text == "")
                    {
                        MessageBox.Show("Enter Kgs Value", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        txtKgs.Focus();
                        return false;
                    }
                }
                else
                {
                    if (DtpStartTime.Value >= DtpEndTime.Value)
                    {
                        MessageBox.Show("EndTime should be greater than StartTime", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        DtpStartTime.Focus();
                        return false;
                    }
                    if (BtnAdd.Text == "Add")
                    {
                        if (!ShiftAndStartValidation())
                        {
                            MessageBox.Show("This start time is not valid for selected shift");
                            DtpStartTime.Focus();
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ShiftAndStartValidation()
        {
            try
            {
                int min = (DtpStartTime.Value.Hour * 60) + DtpStartTime.Value.Minute;//Start time
                string[] str = cmbShift.Text.Split(Convert.ToChar(" "));
                int ShiftStart = Convert.ToDateTime(str[1]).Hour * 60;
                int ShiftEnd = Convert.ToDateTime(str[2]).Hour * 60;
                if (ShiftStart < ShiftEnd) //normal timmings 
                {
                    if (min >= ShiftStart && min < ShiftEnd)
                        return true;
                    else
                        return false;
                }
                else //Shiftend less than shift start
                {
                    if (min >= ShiftStart && min < (24 * 60)) //check before morning 12
                        return true;
                    else if (min >= 0 && min < ShiftEnd)//Check after morning 12
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {

                    OEETransactionTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                    OEETransactionTest_Class_Obj.activityid = Convert.ToInt32(cmbActivity.SelectedValue);

                    //OEETransactionTest_Class_Obj.starttime = DateTime.Parse(DtpDate.Value.ToShortDateString() + " " + DtpStartTime.Value.ToLongTimeString());
                    //OEETransactionTest_Class_Obj.endtime = DateTime.Parse(DtpDate.Value.ToShortDateString() + " " + DtpEndTime.Value.ToLongTimeString());

                    OEETransactionTest_Class_Obj.starttime = DtpStartTime.Value;
                    OEETransactionTest_Class_Obj.endtime = DtpEndTime.Value;

                    if (txtKgs.Enabled == true)
                    {
                        string tmp = OEETransactionTest_Class_Obj.starttime.ToString();
                        tmp = tmp.Replace("12:00:00 AM", "6:00:00 AM");

                        OEETransactionTest_Class_Obj.starttime = OEETransactionTest_Class_Obj.endtime = Convert.ToDateTime(tmp);
                    }
                    //06/12/2017 12:00:00 AM
                    //05/20/2017 6:00:00 AM

                    OEETransactionTest_Class_Obj.comment = txtComment.Text;
                    ////OEETransactionTest_Class_Obj.osid = Convert.ToInt64(dgOperator["OSID", dgOperator.Rows.Count - 1].Value);
                    OEETransactionTest_Class_Obj.operatorid = Convert.ToInt32(cmbOperator.SelectedValue);
                    OEETransactionTest_Class_Obj.shiftid = Convert.ToInt64(cmbShift.SelectedValue);
                    OEETransactionTest_Class_Obj.kgsvalue = Convert.ToString(txtKgs.Text);
                    if (BtnAdd.Text == "Add")
                        OEETransactionTest_Class_Obj.maid = OEETransactionTest_Class_Obj.Insert_tblOEEMFGActivityDetail();
                    else if (BtnAdd.Text == "Update")
                        OEETransactionTest_Class_Obj.Update_tblOEEMFGActivityDetail();
                    BtnAdd.Text = "Add";


                    Bind_ActivityDetails();
                    Set_EndTime();
                    cmbActivity.Text = "--Select--";
                    txtComment.Text = "";
                    txtKgs.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidForStatus()
        {
            if (cmbDetails.Text == "--Select--")
            {
                MessageBox.Show("Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                cmbDetails.Focus();
                return false;
            }
            //if (RdoOpen.Checked == false && RdoClose.Checked == false)
            //{
            //    MessageBox.Show("Select Open/Close", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
            //    RdoOpen.Focus();
            //    return false;
            //}

            OEETransactionTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
            if (chkClose.Checked == false)
            {
                OEETransactionTest_Class_Obj.status = "O";
            }
            else if (chkClose.Checked == true)
            {
                OEETransactionTest_Class_Obj.status = "C";
                //For this condition last activity must be a closing activity (ie LastActivity flag should be true)
                if (OEETransactionTest_Class_Obj.Select_OEEActivityDetails_ValidClosing())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Last activity must be a closing activity");
                    return false;
                }
            }
            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidForStatus())
                {
                    OEETransactionTest_Class_Obj.recipe = txtRecipeNorecipe.Text.Trim();

                    DataSet ds = new DataSet();
                    ds = OEETransactionTest_Class_Obj.Select_tblOEEMFGDetails();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        OEETransactionTest_Class_Obj.Update_tblOEEMFGDetails();
                    }
                    else
                    {
                        OEETransactionTest_Class_Obj.Insert_tblOEEMFGDetails();
                    }

                    MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    BtnReset_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void chkOverlap_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOverlap.Checked == true)
            {
                DtpStartTime.Enabled = true;
            }
            else if (chkOverlap.Checked == false)
            {
                DtpStartTime.Enabled = false;
            }
        }

        private void btnProtocol_Click(object sender, EventArgs e)
        {
            try
            {
                //Get data to diaply on protocol
                DataSet ds = new DataSet();
                OEETransactionTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                //ds = OEETransactionTest_Class_Obj.STP_Select_tblBulTestTransaction_OEEProtocol();
                //Add Columns
                DataTable dt = new DataTable();

                dt.Columns.Add("ActivityID");
                dt.Columns.Add("Activity");
                dt.Columns.Add("Active");
                dt.Columns.Add("LastActivity");
                dt.Columns.Add("StartedOn");
                dt.Columns.Add("VesselNo");
                dt.Columns.Add("VslDesc");
                dt.Columns.Add("BulkDesc");

                //ADD Rows
                //dt.Rows.Add();
                DataRow dr;

                dr = dt.NewRow();
                dr["ActivityID"] = "1";
                dr["Activity"] = "Manufacturing - 1";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "2";
                dr["Activity"] = "Manufacturing - 2";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "3";
                dr["Activity"] = "Inspection";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "4";
                dr["Activity"] = "Adjustment - 1";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "5";
                dr["Activity"] = "Inspection - 1";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "6";
                dr["Activity"] = "Adjustment - 2";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "7";
                dr["Activity"] = "Inspection - 2";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "8";
                dr["Activity"] = "Transfer";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "9";
                dr["Activity"] = "Tank Waiting - 1";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "10";
                dr["Activity"] = "Transfer - 1";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "11";
                dr["Activity"] = "Tank Waiting -  2";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "12";
                dr["Activity"] = "Transfer - 2";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "13";
                dr["Activity"] = "C.I.P.";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "14";
                dr["Activity"] = "S.I.P.";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "15";
                dr["Activity"] = "TEA / LUNCH";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "16";
                dr["Activity"] = "Other Waiting";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "17";
                dr["Activity"] = "Other Waiting";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "18";
                dr["Activity"] = "Other Waiting";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "19";
                dr["Activity"] = "RM WAITING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["ActivityID"] = "20";
                dr["Activity"] = "Breakdown";
                dt.Rows.Add(dr);



                if (dt.Rows.Count > 0)
                {

                    //Open form to display report
                    QTMS.Reports_Forms.FrmOEEProtocol pro = new QTMS.Reports_Forms.FrmOEEProtocol("OEE Protocol", dt);//, cmbDetails.Text.Trim());
                    pro.UsedFor = "Protocol";
                    pro.ShowDialog();
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

        private void linkLblActivityGraph_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (cmbDetails.Text != "--Select--")
                {
                    //Get data to diaply on protocol
                    DataTable Dt = new DataTable();
                    OEETransactionTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                    Dt = OEETransactionTest_Class_Obj.Select_OEEMFGActivityDetails_Graph();
                    if (Dt.Rows.Count > 0)
                    {
                        //Open form to display report
                        QTMS.Reports_Forms.FrmOEEProtocol pro = new QTMS.Reports_Forms.FrmOEEProtocol("OEE Protocol", Dt);//,cmbDetails.Text.Trim());
                        pro.UsedFor = "Graph";
                        pro.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select details");
                    cmbDetails.Focus();
                }
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
                if (DgActivity.RowCount > 1)
                {
                    OEETransactionTest_Class_Obj.maid = Convert.ToInt64(DgActivity["MAID", DgActivity.RowCount - 2].Value);
                    OEETransactionTest_Class_Obj.Delete_OEEActivityDetails_MAID();

                    Bind_ActivityDetails();
                    Set_EndTime();
                    cmbActivity.Text = "--Select--";
                    txtComment.Text = "";
                }
                else
                {
                    MessageBox.Show("There is no record to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbActivity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OEETransactionTest_Class_Obj.activityid = Convert.ToInt64(cmbActivity.SelectedValue);
            DataTable dt = OEETransactionTest_Class_Obj.Select_tblOEEActivityMaster_ByActivityID();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Kgs"].ToString() == "1")
                {
                    chkOverlap.Enabled = false;
                    DtpStartTime.Enabled = false;
                    DtpEndTime.Enabled = false;
                    txtKgs.Enabled = true;
                    txtKgs.BackColor = SystemColors.Window;
                }
                else
                {
                    chkOverlap.Enabled = true;
                    DtpStartTime.Enabled = true;
                    DtpEndTime.Enabled = true;
                    txtKgs.Enabled = false;
                    txtKgs.Text = "";
                    txtKgs.BackColor = SystemColors.Control;
                }
            }
            if (BtnAdd.Text == "Add")
                Set_EndTime();
        }

        private void txtKgs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void DgActivity_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    OEETransactionTest_Class_Obj.maid = Convert.ToInt64(DgActivity.Rows[e.RowIndex].Cells["MAID"].Value);
                    OEETransactionTest_Class_Obj.fmid = Convert.ToInt64(DgActivity.Rows[e.RowIndex].Cells["FMID"].Value);
                    //OEETransactionTest_Class_Obj.operatorid = Convert.ToInt64(DgActivity.Rows[e.RowIndex].Cells["Operator"].Value);
                    string operatorname = DgActivity.Rows[e.RowIndex].Cells["Operator"].Value.ToString();
                    cmbOperator.SelectedValue = operatorname;
                    //string shift = DgActivity.Rows[e.RowIndex].Cells["Shift"].Value.ToString();
                    //cmbShift.Text = shift;
                    string activity = DgActivity.Rows[e.RowIndex].Cells["Activity"].Value.ToString();
                    cmbActivity.SelectedValue = activity;
                    DataSet ds = new DataSet();
                    ds = OEETransactionTest_Class_Obj.Select_OEEActivityDetails_MAID();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        txtKgs.Text = Convert.ToString(ds.Tables[0].Rows[i]["KgsValue"]);
                        cmbShift.SelectedValue = ds.Tables[0].Rows[i]["ShiftID"].ToString();
                        //DtpStartTime.Enabled = false;
                        DtpEndTime.Enabled = false;
                        txtKgs.Enabled = true;
                        txtKgs.BackColor = SystemColors.Window;
                    }
                    if (txtKgs.Text == "")
                    {
                        txtKgs.Enabled = false;
                        txtKgs.Text = "";
                        txtKgs.BackColor = SystemColors.Control;

                        DtpStartTime.Value = Convert.ToDateTime(DgActivity.Rows[e.RowIndex].Cells["StartTime"].Value);

                        DtpEndTime.MinDate = DtpStartTime.Value;
                        DtpEndTime.Value = DtpStartTime.Value;

                        DtpEndTime.Value = Convert.ToDateTime(DgActivity.Rows[e.RowIndex].Cells["EndTime"].Value);

                        DtpEndTime.Enabled = true;
                    }
                    txtComment.Text = DgActivity.Rows[e.RowIndex].Cells["Comment"].Value.ToString();

                    BtnAdd.Text = "Update";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnGridReset_Click(object sender, EventArgs e)
        {
            cmbActivity.SelectedValue = "0";
            cmbOperator.SelectedValue = "0";
            cmbShift.Text = "--Select--";
            Set_EndTime();
            txtKgs.Text = "";
            BtnAdd.Text = "Add";
        }

        BusinessFacade.Transactions.OEEAct_CatRelation OEEAct_CatRelationObj = new BusinessFacade.Transactions.OEEAct_CatRelation();
        private void BtnPUR_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Get all FMID wise records.
            try
            {
                OEEAct_CatRelationObj.StartDate = DtpStartedOn.Value.ToShortDateString();
                DataTable Dt = new DataTable();
                Dt = OEEAct_CatRelationObj.Select_Report_OEEMFGActivityDetails_Analysis2__DailyPUR();

                if (Dt.Rows.Count > 0)
                {
                    DataTable DtActivity = new DataTable();
                    //Get list of active activities from tbl activity master
                    DtActivity = OEEAct_CatRelationObj.Select_ActivityMaster();

                    //Add Activities as columnname to each FMID wise records from detail tbl
                    for (int i = 0; i < DtActivity.Rows.Count; i++)
                    {
                        if (Dt.Columns.Contains(DtActivity.Rows[i][0].ToString().Trim()))
                        {
                        }
                        else//Activity not in detail tbl but in activity master
                        {
                            Dt.Columns.Add(DtActivity.Rows[i][0].ToString().Trim(), "System.Int64".GetType());
                        }
                    }

                    //Set time for each FMID and activity compbination
                    for (int i = 0; i < Dt.Rows.Count; i++)//loop for FMID
                    {
                        OEEAct_CatRelationObj.fmid = Convert.ToInt64(Dt.Rows[i]["FMID"]);
                        for (int j = 0; j < DtActivity.Rows.Count; j++)//loop for activities
                        {
                            OEEAct_CatRelationObj.Activity = DtActivity.Rows[j][0].ToString().Trim();
                            //Get sum of time and set as details
                            Dt.Rows[i][OEEAct_CatRelationObj.Activity] = OEEAct_CatRelationObj.Get_OEEMFGActivityDetails_ActivityTime();
                        }
                    }

                    #region Category wise calculations
                    if (Dt.Columns.Contains("Total waitaing") || Dt.Columns.Contains("total Manufacturing time") || Dt.Columns.Contains("Std Processing Time") || Dt.Columns.Contains("Processing time") || Dt.Columns.Contains("total Occupation time"))
                    {

                    }
                    else
                    {
                        Dt.Columns.Add("Total waitaing", "System.Int64".GetType());
                        Dt.Columns.Add("total Manufacturing time", "System.Int64".GetType());
                        Dt.Columns.Add("Std Processing Time", "System.Int64".GetType());//from TechFamTMTmaster
                        Dt.Columns.Add("Processing time", "System.Int64".GetType());
                        Dt.Columns.Add("total Occupation time", "System.Int64".GetType());
                    }
                    DataTable DtCategories = new DataTable();
                    DtCategories = OEEAct_CatRelationObj.Select_OEECategoryMaster();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        BusinessFacade.Transactions.OEETransactionTest_Class OEETransactionTest_Class_Obj = new BusinessFacade.Transactions.OEETransactionTest_Class();
                        OEEAct_CatRelationObj.fmid = Convert.ToInt64(Dt.Rows[i]["FMID"]);

                        //Waiting time 
                        OEEAct_CatRelationObj.Category = DtCategories.Rows[3][1].ToString().Trim();
                        Dt.Rows[i]["Total waitaing"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();

                        //TManufacrng Time
                        OEEAct_CatRelationObj.Category = DtCategories.Rows[0][1].ToString().Trim();
                        Dt.Rows[i]["total Manufacturing time"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();

                        //Std time //from TechFamTMTmaster
                        OEETransactionTest_Class_Obj.techFamNo = Convert.ToInt64(Dt.Rows[i]["TechFamNo"]);
                        OEETransactionTest_Class_Obj.batchsize = Convert.ToInt64(Dt.Rows[i]["BatchSize"]);

                        Dt.Rows[i]["Std Processing Time"] = OEETransactionTest_Class_Obj.Select_OEETechFamTMTMaster_TMT();

                        //TPT
                        OEEAct_CatRelationObj.Category = DtCategories.Rows[1][1].ToString().Trim();
                        Dt.Rows[i]["Processing time"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();

                        //TOT
                        OEEAct_CatRelationObj.Category = DtCategories.Rows[2][1].ToString().Trim();
                        Dt.Rows[i]["total Occupation time"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();
                    }
                    #endregion
                }

                int Manufacturing = 0, Inspection = 0, Transfer = 0, CIP = 0;
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    if (OEETransactionTest_Class_Obj.fmid == Convert.ToInt64(Dt.Rows[i]["FMID"]))
                    {
                        Manufacturing = Manufacturing + Convert.ToInt32(Dt.Rows[i]["Manufacturing"]);
                        Inspection = Inspection + Convert.ToInt32(Dt.Rows[i]["Inspection"]);
                        Transfer = Transfer + Convert.ToInt32(Dt.Rows[i]["Transfer"]);
                        CIP = CIP + Convert.ToInt32(Dt.Rows[i]["CIP"]);
                    }
                }
                if ((Manufacturing + Inspection + Transfer + CIP) != 0)
                {

                    double SMT = Convert.ToDouble(txtTMT.Text);
                    double MITC = Convert.ToDouble(Manufacturing + Inspection + Transfer + CIP);
                    double PUR = Convert.ToDouble(SMT / MITC)*100;

                    lblPur.ForeColor = Color.Red;
                    lblPur.Text = "PUR(%) : " + PUR.ToString("f2");
                }
                else
                { lblPur.Text = ""; }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Arrow;
                throw;
            }

        }
    }
}