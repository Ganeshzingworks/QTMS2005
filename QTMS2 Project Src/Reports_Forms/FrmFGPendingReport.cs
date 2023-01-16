using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QTMS.Tools;
using Excel = Microsoft.Office.Interop.Excel;
using BusinessFacade.Transactions;
using BusinessFacade;


namespace QTMS.Reports_Forms
{
    public partial class FrmFGPendingReport : Form
    {
        public string rptName;
        private string strMsg;

        public FrmFGPendingReport()
        {                
            InitializeComponent();
        }
        # region Varibles       
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        GroupMaster_Class GroupMaster_Class_Obj = new GroupMaster_Class();
        FGPending_Class FGPending_Class_obj = new FGPending_Class();
        # endregion
        
   

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {

        }
        private static FrmFGPendingReport FrmFGPendingReport_Obj = null;
        public static FrmFGPendingReport GetInstance()
        {
            if (FrmFGPendingReport_Obj == null)
            {
                FrmFGPendingReport_Obj = new FrmFGPendingReport();
            }
            return FrmFGPendingReport_Obj;
        }
        private void FrmFGPendingReport_Load(object sender, EventArgs e)
        {
           // this.WindowState = FormWindowState.Normal;
            //object dt = new DateTime();
            //dt = null;
            //dt = DtpDateFrom.Value;
            //DateTime dt = DBNull.Value;
            Painter.Paint(this);
            Bind_GroupNames();

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            ds = FGPending_Class_obj.Select_FGPending();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DtpDateFrom.Value = Convert.ToDateTime(dr["FromDate"]);
                DtpDateTo.Value = Convert.ToDateTime(dr["ToDate"]);
                FGPending_Class_obj.fgPendingID = Convert.ToInt64(dr["FGPendingID"]);
                ds1 = FGPending_Class_obj.Select_FGPendingGroupRelation();
                foreach (DataRow dr1 in ds1.Tables[0].Rows)
                {
                   
                    if (Convert.ToInt32(dr1["Is3daysor6days"]) == 1)
                    {
                        for (int i = 0; i < chkLstGroupName3Days.Items.Count; i++)
                        {
                            object Items = chkLstGroupName3Days.Items[i];
                            if (Convert.ToInt32((((System.Data.DataRowView)(Items)).Row.ItemArray[0])) == Convert.ToInt32(dr1["GroupID"]))
                            {
                                chkLstGroupName3Days.SetItemChecked(i, true);
                            }
                        }
                    }
                    else if (Convert.ToInt32(dr1["Is3daysor6days"]) == 2)
                    {
                        for (int i = 0; i < chkLstGroupName6Days.Items.Count; i++)
                        {
                            object Items = chkLstGroupName6Days.Items[i];
                            if (Convert.ToInt32((((System.Data.DataRowView)(Items)).Row.ItemArray[0])) == Convert.ToInt32(dr1["GroupID"]))
                            {
                                chkLstGroupName6Days.SetItemChecked(i, true);
                            }
                        }
                    }

                }               

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
                    chkLstGroupName3Days.DataSource = ds.Tables[0];
                    chkLstGroupName3Days.DisplayMember = "GroupName";
                    chkLstGroupName3Days.ValueMember = "GroupID";

                    chkLstGroupName6Days.DataSource = ds.Tables[0];
                    chkLstGroupName6Days.DisplayMember = "GroupName";
                    chkLstGroupName6Days.ValueMember = "GroupID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        private bool IsValid()
        {
            try
            {
                if (DtpDateFrom.Checked && DtpDateTo.Checked)
                {
                    if (DtpDateFrom.Value > DtpDateTo.Value)
                    {
                        MessageBox.Show("End date should be gretter than start date.");
                        return false;
                    }
                }

                if (DtpDateFrom.Checked == true)
                {
                    //LineOEETransaction_obj.startdate = DtpDateFrom.Value.ToShortDateString();
                    
                }
                else
                {
                    //LineOEETransaction_obj.startdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                    MessageBox.Show("Please select the start date","Line OEE",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return false;
                }

                if (DtpDateTo.Checked == true)
                {
                    //LineOEETransaction_obj.enddate = DtpDateTo.Value.ToShortDateString();
                  
                }
                else
                {
                    //LineOEETransaction_obj.enddate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                    MessageBox.Show("Please select the end date", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
                }  
                //if (txtPath.Text == "")
                //{
                //    MessageBox.Show("Select Export Path", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtPath.Focus();
                //    return false;
                //}
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DtpDateFrom.Value = DateTime.Now.Date;
            DtpDateTo.Value = DateTime.Now.Date;
            ResetAllUserNames(chkLstGroupName3Days);
            ResetAllUserNames(chkLstGroupName6Days);

        }
        private void ResetAllUserNames(CheckedListBox chkLst)
        {
            try
            {
                for (int i = 0; i < chkLst.Items.Count; i++)
                {
                    chkLst.SetItemChecked(i, false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connectionstring"]);
            con.Open();
            try
            {
                if (IsValid())
                {
                    FGPending_Class_obj.fromDate = DtpDateFrom.Value.Date;
                    FGPending_Class_obj.toDate = DtpDateTo.Value.Date;
                    FGPending_Class_obj.active = true;
                    FGPending_Class_obj.trans = con.BeginTransaction();

                    FGPending_Class_obj.fgPendingID = FGPending_Class_obj.Insert_FGPending();

                    if (FGPending_Class_obj.fgPendingID != 0)
                    {
                        DeleteCategory(FGPending_Class_obj.fgPendingID);
                        for (int i = 0; i < chkLstGroupName3Days.Items.Count; i++)
                        {
                            if (chkLstGroupName3Days.GetItemChecked(i) == true)
                            {
                                chkLstGroupName3Days.SetSelected(i, true);
                                int userID = Convert.ToInt32(chkLstGroupName3Days.SelectedValue);
                                FGPending_Class_obj.groupID = userID;
                                FGPending_Class_obj.is3or6Days = 1;
                                FGPending_Class_obj.Insert_FGPendingGroupRelation();
                            }
                        }
                        for (int i = 0; i < chkLstGroupName6Days.Items.Count; i++)
                        {
                            if (chkLstGroupName6Days.GetItemChecked(i) == true)
                            {
                                chkLstGroupName6Days.SetSelected(i, true);
                                int userID = Convert.ToInt32(chkLstGroupName6Days.SelectedValue);
                                FGPending_Class_obj.groupID = userID;
                                FGPending_Class_obj.is3or6Days = 2;
                                FGPending_Class_obj.Insert_FGPendingGroupRelation();
                            }
                        }
                        DateTime dt6Days;
                        bool flag = false;
                        for (DateTime dt = DtpDateFrom.Value.Date; dt < DtpDateTo.Value.Date; dt.AddDays(3))
                        {
                            dt = dt.AddDays(3);
                            FGPending_Class_obj.days3FG = dt;
                            FGPending_Class_obj.days6FG = dt.AddDays(3);
                            flag = FGPending_Class_obj.Insert_FGPending3DaysOr6Days();
                        }
                    }
                    FGPending_Class_obj.trans.Commit();
                    btnReset_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                FGPending_Class_obj.trans.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
                con.Close();
            }
        }

        private void DeleteCategory(long fgPendingID)
        {
            try
            {
                FGPending_Class_obj.fgPendingID = fgPendingID;
                FGPending_Class_obj.Delete_FGPendingGroupRelation();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}