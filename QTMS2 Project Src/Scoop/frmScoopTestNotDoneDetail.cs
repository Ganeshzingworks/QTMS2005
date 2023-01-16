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
using QTMS.U_Control;
using BusinessFacade.Transactions;
using BusinessFacade.Scoop_Class;

namespace QTMS.Scoop
{
    public partial class frmScoopTestNotDoneDetail : Form
    {

        #region variables
        /// <summary>
        /// UPSamplingPontTestID store Current UPSamplingPontTestID from tblUPTestAtSamplingPoint
        /// </summary>
        public Int64 UPSamplingPontTestID;
        public string time, ExpectedTime;
        FrmScoopUP frmScoopUpObjHere;
        DataGridView UpTestGrid;
        int frequency;
        DataTable DtFrequency;
        UC_SamplingGrid uc_grid;
        #endregion

       #region ClassVariables
        UPTestAtSamplingPoint_Class UPTestAtSamplingPoint_Class_Obj = new UPTestAtSamplingPoint_Class();
        UPMaster_Class upMasterClass_obj = new UPMaster_Class();
       #endregion

        public frmScoopTestNotDoneDetail()
        {
            InitializeComponent();
        }

        public frmScoopTestNotDoneDetail(UC_SamplingGrid ucgrid)
        {
            InitializeComponent();
            uc_grid = ucgrid;
            DateTime dt = Class_ScoopProcess.GetCurrentTime();
        }

        public frmScoopTestNotDoneDetail(DataGridView  dg,int freq,DataTable  dt)
        {
            InitializeComponent();
            UpTestGrid = dg;
            frequency = freq;
            DtFrequency = dt;
        }
        /// <summary>
        /// Store UPTestAtSamplingPointID Test Id from tblUPTestAtSamplingPoint
        /// </summary>
        private int _UPTestAtSamplingPointID;

        public int UPTestAtSamplingPointID
        {
            get { return _UPTestAtSamplingPointID; }
            set { _UPTestAtSamplingPointID = value; }
        }
	

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScoopTestNotDoneDetail_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            BindNotDoneDesc();
        }

        private void BindNotDoneDesc()
        {
            try
            {
                UPTestAtSamplingPoint_Class_Obj.time = time;
                UPTestAtSamplingPoint_Class_Obj.uptestsamplingpointid = UPSamplingPontTestID;
                UPTestAtSamplingPoint_Class_Obj.expectedtime = ExpectedTime;

                DataSet DS = new DataSet();
                DS = UPTestAtSamplingPoint_Class_Obj.Select_NotDoneDesc();
                txtNotDoneReason.Text = DS.Tables[0].Rows[0]["NotDoneDescription"].ToString();
                if (DS.Tables[0].Rows[0]["NotDoneDescription"].ToString() != "")
                {
                    txtNotDoneReason.ReadOnly = true;
                    UPTestAtSamplingPoint_Class objUPTest = new UPTestAtSamplingPoint_Class();
                    objUPTest.time = time;
                    objUPTest.expectedtime = ExpectedTime;
                    objUPTest.uptestsamplingpointid = UPSamplingPontTestID;
                    objUPTest.notDoneDesc = txtNotDoneReason.Text;
                    UPTestAtSamplingPointID = objUPTest.getUPTestAtSamplingPointID();
                    if (uc_grid.currentUPAuthorityFrm != null)
                    {
                        if (objUPTest.ApproveUpPMNotDone!=null)
                        {
                            chkContinuetest.Checked = objUPTest.ApproveUpPMNotDone.Value;
                        }
                    }
                    if (uc_grid.currentQualityAutorityFrm != null)
                    {
                        if (objUPTest.ApproveQualityPMNotDone!=null)
                        {
                            chkContinuetest.Checked = objUPTest.ApproveQualityPMNotDone.Value;
                        }
                    }
                }
                else
                {
                    UPTestAtSamplingPoint_Class objUPTest = new UPTestAtSamplingPoint_Class();
                    objUPTest.time = time;
                    objUPTest.expectedtime = ExpectedTime;
                    objUPTest.uptestsamplingpointid = UPSamplingPontTestID;
                    objUPTest.notDoneDesc = txtNotDoneReason.Text;
                    UPTestAtSamplingPointID = objUPTest.getUPTestAtSamplingPointID();
                    if (uc_grid.currentUPAuthorityFrm != null)
                    {
                        if (objUPTest.ApproveUpPMNotDone != null)
                        {
                            chkContinuetest.Checked = objUPTest.ApproveQualityPMNotDone.Value;
                        }
                    }
                    if (uc_grid.currentQualityAutorityFrm != null)
                    {
                        if (objUPTest.ApproveQualityPMNotDone != null)
                        {
                            chkContinuetest.Checked = objUPTest.ApproveQualityPMNotDone.Value;
                        }
                    }
                }
                txtActualTimeOfSamplingPoint.Text = ExpectedTime;
            }
            catch
            {
                throw;
            }
        }

        private void UpdateNotDoneDesc()
        {
            try
            {
                if (txtNotDoneReason.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Please enter the description.");
                   return;
                }
                if (txtNotDoneReason.Text.Length < 15)
                {
                    MessageBox.Show("Please enter at least 15 characters description.");
                    return;
                }
               
                    UPTestAtSamplingPoint_Class_Obj.time = time;
                    UPTestAtSamplingPoint_Class_Obj.expectedtime = ExpectedTime;
                    UPTestAtSamplingPoint_Class_Obj.notDoneDesc = txtNotDoneReason.Text;
                    UPTestAtSamplingPoint_Class_Obj.ApproveUpPMNotDone = true;
                    UPTestAtSamplingPoint_Class_Obj.uptestsamplingpointid = UPTestAtSamplingPointID;
                    bool b1 = UPTestAtSamplingPoint_Class_Obj.Update_NotDoneDescAfterUPApproval();

                    UPTestAtSamplingPoint_Class_Obj.time = time;
                    UPTestAtSamplingPoint_Class_Obj.expectedtime = ExpectedTime;
                    UPTestAtSamplingPoint_Class_Obj.notDoneDesc = txtNotDoneReason.Text;
                    UPTestAtSamplingPoint_Class_Obj.ApproveQualityPMNotDone = true;
                    UPTestAtSamplingPoint_Class_Obj.uptestsamplingpointid = UPTestAtSamplingPointID;
                    bool b = UPTestAtSamplingPoint_Class_Obj.Update_NotDoneDescAfterQualityApproval();

                    if (b)
                    {

                        // here Check Current Time - Expected Time > 
                        MessageBox.Show("Description saved .", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (uc_grid != null && !UC_SamplingGrid.defectOccuredAtOneEnd)
                        {
                            DateTime dt = Class_ScoopProcess.GetCurrentTime();
                            TimeSpan ts = dt.TimeOfDay;
                            TimeSpan ts1 = uc_grid.sheduledTime.TimeOfDay;
                            TimeSpan res = ts.Subtract(ts1);
                            int hr = res.Hours;
                            int minutes = res.Minutes;
                            if (hr == 0)
                            {
                                if (minutes < 20)
                                {
                                    uc_grid.Add_SamplingRow();
                                }
                            }
                        }
                    }


                


                #region Commited by Avinash 14-07-2014

                ////if (!txtNotDoneReason.ReadOnly)
                ////{
                ////    UPTestAtSamplingPoint_Class_Obj.time = time;
                ////    UPTestAtSamplingPoint_Class_Obj.uptestsamplingpointid = UPSamplingPontTestID;
                ////    UPTestAtSamplingPoint_Class_Obj.expectedtime = ExpectedTime;
                ////    UPTestAtSamplingPoint_Class_Obj.notDoneDesc = txtNotDoneReason.Text;
                ////    bool b = UPTestAtSamplingPoint_Class_Obj.Update_NotDoneDesc();
                ////    if (b)
                ////    {
                ////        // here Check Current Time - Expected Time > 
                ////        MessageBox.Show("Description saved .", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ////        if (uc_grid != null && !UC_SamplingGrid.defectOccuredAtOneEnd)
                ////        {
                ////            DateTime dt = Class_ScoopProcess.GetCurrentTime();
                ////            TimeSpan ts = dt.TimeOfDay;
                ////            TimeSpan ts1 = uc_grid.sheduledTime.TimeOfDay;
                ////            TimeSpan res = ts.Subtract(ts1);
                ////            int hr = res.Hours;
                ////            int minutes = res.Minutes;
                ////            if (hr == 0)
                ////            {
                ////                if (minutes < 20)
                ////                {
                ////                    uc_grid.Add_SamplingRow();
                ////                }
                ////            }
                ////        }
                ////    }
                ////}
                ////else
                ////{
                ////    //if (uc_grid != null && !UC_SamplingGrid.defectOccuredAtOneEnd)
                ////    //{
                ////    //    if (UC_SamplingGrid.PMNotDoneTimeExided)
                ////    //    {
                ////    //        uc_grid.Add_SamplingRow();
                ////    //    }
                ////    //}
                ////    if (uc_grid.currentUPAuthorityFrm != null)
                ////    {
                ////        UPTestAtSamplingPoint_Class_Obj.time = time;
                ////        UPTestAtSamplingPoint_Class_Obj.expectedtime = ExpectedTime;
                ////        UPTestAtSamplingPoint_Class_Obj.notDoneDesc = txtNotDoneReason.Text;
                ////        if (chkContinuetest.Checked)
                ////        {
                ////            UPTestAtSamplingPoint_Class_Obj.ApproveUpPMNotDone = true;
                ////        }
                ////        else
                ////        {
                ////            UPTestAtSamplingPoint_Class_Obj.ApproveUpPMNotDone = true;
                ////        }
                ////        if (uc_grid.currentUPAuthorityFrm.pnlTestGrid.Controls.Count > 0)
                ////        {
                ////            //foreach (UC_SamplingGrid var in uc_grid.currentUPAuthorityFrm.pnlTestGrid.Controls)
                ////            {
                ////                UPTestAtSamplingPoint_Class_Obj.uptestsamplingpointid = UPTestAtSamplingPointID;
                ////                bool b = UPTestAtSamplingPoint_Class_Obj.Update_NotDoneDescAfterUPApproval();
                ////            }
                ////        }
                ////    }
                ////    if (uc_grid.currentQualityAutorityFrm != null)
                ////    {
                ////        UPTestAtSamplingPoint_Class_Obj.time = time;
                ////        //UPTestAtSamplingPoint_Class_Obj.uptestsamplingpointid = UPSamplingPontTestID;
                ////        UPTestAtSamplingPoint_Class_Obj.expectedtime = ExpectedTime;
                ////        UPTestAtSamplingPoint_Class_Obj.notDoneDesc = txtNotDoneReason.Text;
                ////        if (chkContinuetest.Checked)
                ////        {
                ////            UPTestAtSamplingPoint_Class_Obj.ApproveQualityPMNotDone = true;
                ////        }
                ////        else
                ////        {
                ////            UPTestAtSamplingPoint_Class_Obj.ApproveQualityPMNotDone = true;
                ////        }
                ////        if (uc_grid.currentQualityAutorityFrm.pnlTestGrid.Controls.Count > 0)
                ////        {
                ////            //foreach (UC_SamplingGrid var in uc_grid.currentQualityAutorityFrm.pnlTestGrid.Controls)
                ////            {
                ////                UPTestAtSamplingPoint_Class_Obj.uptestsamplingpointid = UPTestAtSamplingPointID;
                ////                bool b = UPTestAtSamplingPoint_Class_Obj.Update_NotDoneDescAfterQualityApproval();
                ////            }
                ////        }
                ////    }

                ////}

                #endregion
            }
            catch
            {
                throw;
            }
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNotDoneReason.ReadOnly != true)
                UpdateNotDoneDesc();
            else
                this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNotDoneReason_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                btnSave.Focus();
            }
        }
    }
}
