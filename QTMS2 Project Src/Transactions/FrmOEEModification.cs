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
    public partial class FrmOEEModification : Form
    {
       // Gantt.GanttChart GanttChart1 = new Gantt.GanttChart(); 

        public FrmOEEModification()
        {
            InitializeComponent();
        }

        # region Varibles
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.OEETransactionTest_Class OEETransactionTest_Class_Obj = new BusinessFacade.Transactions.OEETransactionTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        bool Modify = false;
        # endregion

        private static FrmOEEModification frmOEEModification_Obj = null;
        public static FrmOEEModification GetInstance()
        {
            if (frmOEEModification_Obj == null)
            {
                frmOEEModification_Obj = new FrmOEEModification();
            }
            return frmOEEModification_Obj;
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
                //Uncomment this line if you need all activity including soft deleted
                //DataTable Dt = OEETransactionTest_Class_Obj.Select_tblOEEActivityMaster_All();
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
                    
                    //Uncomment this line if you need all activity including soft deleted
                    //DataTable DtGrid = OEETransactionTest_Class_Obj.Select_tblOEEActivityMaster_All();
                    
                    DataTable DtGrid = OEETransactionTest_Class_Obj.Select_tblOEEActivityMaster();
                    DataGridViewComboBoxColumn DataGridViewComboBoxColumnObj;
                    DataGridViewComboBoxColumnObj = (DataGridViewComboBoxColumn)(DgActivity.Columns[5]);

                   
                    DataGridViewComboBoxColumnObj.DisplayMember = "Activity";
                    DataGridViewComboBoxColumnObj.ValueMember = "ActivityID"; 
                    DataGridViewComboBoxColumnObj.DataSource = DtGrid ;                  
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
            RdoOpen.Checked = false;
            RdoClose.Checked = false;
        }
        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Reset_MinMaxDate();
                reset();
                if (cmbDetails.SelectedValue.ToString() != "0")
                {
                    DataTable Dt = new DataTable();
                    OEETransactionTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                    Dt = OEETransactionTest_Class_Obj.STP_Select_tblBulTestTransaction().Tables[0];
                    if (Dt.Rows.Count > 0)
                    {
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
                        DtpStartTime.Value = DateTime.Parse(DtpStartedOn.Value.ToShortDateString() + " " + DateTimeObj.ToLongTimeString());
                        DtpEndTime.Value = DateTime.Parse(DtpStartedOn.Value.ToShortDateString() + " " + DateTimeObj.ToLongTimeString());
                        
                        txtDesc.Text = Convert.ToString(Dt.Rows[0]["BulkDesc"]);
                        txtVessel.Text = Convert.ToString(Dt.Rows[0]["VslDesc"]);
                        txtTechFamily.Text = Convert.ToString(Dt.Rows[0]["FamilyDesc"]);
                        txtBatchSize.Text = Convert.ToString(Dt.Rows[0]["BatchSize"]);

                        OEETransactionTest_Class_Obj.techFamNo = Convert.ToInt64(Dt.Rows[0]["TechFamNo"]);
                        OEETransactionTest_Class_Obj.batchsize = Convert.ToInt64(txtBatchSize.Text);

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

                DtpStartTime.MaxDate = OEETransactionTest_Class_Obj.Select_OEEActivityDetails_MaxEndTime();
                if (DtpStartTime.MaxDate!=Convert.ToDateTime("31-Dec-2030"))//This date is explicitly set 
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
                DtpStartTime.Enabled = false;
            }
            catch (Exception ex)
            {
                
                throw ex ;
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

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DgActivity.Rows.Clear();
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DgActivity.Rows.Add();
                    DgActivity["MAID", i].Value = Convert.ToString(ds.Tables[0].Rows[i]["MAID"]);
                    DgActivity["FMID", i].Value = Convert.ToString(ds.Tables[0].Rows[i]["FMID"]);
                    //DgActivity["OPeratorID", i].Value = Convert.ToString(ds.Tables[0].Rows[i]["OSID"]);
                    DgActivity["Activity", i].Value = Convert.ToInt64(ds.Tables[0].Rows[i]["ActivityID"]);
                    DgActivity["Operator", i].Value = Convert.ToInt32(ds.Tables[0].Rows[i]["UserId"]);
                    DgActivity["Shift", i].Value = Convert.ToString(ds.Tables[0].Rows[i]["ShiftName"]);
                    DgActivity["StartTime", i].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["StartTime"]).ToString("dd-MMM-yyyy HH:mm:ss");
                    DgActivity["EndTime", i].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["EndTime"]).ToString("dd-MMM-yyyy HH:mm:ss");
                    DgActivity["Comment", i].Value = Convert.ToString(ds.Tables[0].Rows[i]["Comment"]);
                    DgActivity.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }        

        private bool IsValid()
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
            if (DtpStartTime.Value >= DtpEndTime.Value)
            {
                MessageBox.Show("EndTime should be greater than StartTime", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                DtpStartTime.Focus();
                return false;
            }
            return true;
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

                    OEETransactionTest_Class_Obj.comment = txtComment.Text;
                    ////OEETransactionTest_Class_Obj.osid = Convert.ToInt64(dgOperator["OSID", dgOperator.Rows.Count - 1].Value);
                    OEETransactionTest_Class_Obj.operatorid = Convert.ToInt32(cmbOperator.SelectedValue);
                    OEETransactionTest_Class_Obj.shiftid = Convert.ToInt64(cmbShift.SelectedValue);
                    
                    //If delete all record logic cancel , then update each seperate record.
                    //OEETransactionTest_Class_Obj.Update_tblOEEMFGActivityDetail();

                    OEETransactionTest_Class_Obj.maid = OEETransactionTest_Class_Obj.Insert_tblOEEMFGActivityDetail();

                    Bind_ActivityDetails();
                    Set_EndTime();
                    cmbActivity.Text = "--Select--";
                    txtComment.Text = "";
                }
            }
            catch(Exception ex)
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
            if (RdoOpen.Checked == false && RdoClose.Checked == false)
            {
                MessageBox.Show("Select Open/Close", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                RdoOpen.Focus();
                return false;
            }

            OEETransactionTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
            if (RdoOpen.Checked == true)
            {
                OEETransactionTest_Class_Obj.status = "O";
            }
            else if (RdoClose.Checked == true)
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
                if (cmbDetails.Text != "--Select--")
                {
                    //Get data to diaply on protocol
                    DataSet ds = new DataSet();
                    OEETransactionTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                    ds = OEETransactionTest_Class_Obj.STP_Select_tblBulTestTransaction_OEEProtocol();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Open form to display report
                        QTMS.Reports_Forms.FrmOEEProtocol pro = new QTMS.Reports_Forms.FrmOEEProtocol("OEE Protocol", ds.Tables[0]);//, cmbDetails.Text.Trim());
                        pro.UsedFor = "Protocol";
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

        private void linkLblActivityGraph_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (cmbDetails.Text != "--Select--")
                {
                    //Get data to diaply on protocol
                    DataTable Dt= new DataTable();
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

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    cmbDetails.Focus();
                }
                else
                {
                    if (MessageBox.Show("Do you want to delete all records for seleced details?", "Confirm Delete!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        OEETransactionTest_Class_Obj.fmid = Convert.ToInt64(cmbDetails.SelectedValue);
                        OEETransactionTest_Class_Obj.Delete_OEEActivityDetails();
                        MessageBox.Show("All Records Are Deleted!");
                        BtnReset_Click(sender, e);
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }           
    }
}