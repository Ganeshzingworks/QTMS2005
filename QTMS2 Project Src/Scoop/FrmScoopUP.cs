/********************************************************
*Author:Manish K 
*Date: 
*Description: Transaction form to enter finished good details
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
using BusinessFacade.Scoop_Class;
using BusinessFacade.Transactions;
using System.Collections;
using QTMS.U_Control;

namespace QTMS.Scoop
{
    public partial class FrmScoopUP : Form
    {

        public FrmScoopUP()
        {
            InitializeComponent();
        }

        #region variables


        DataTable dT = new DataTable(); //==========Manish k
        DataSet DSSamplingInfo, DSfgtlFGLne; Int64 FGTLFID2; //=========Manish k

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        public SCOOPTestMethodMaster_Class SCOOPTestMethodMaster_Class_Obj = new SCOOPTestMethodMaster_Class();//=====manish k
        #endregion

        //====================== Manish K=====================================================================================//
        #region ScoopClasses Objects
        UPMaster_Class UPMaster_Class_Obj = new UPMaster_Class();
        UPTestSamplingPoint_Class UPTestSamplingPoint_Class_Obj = new UPTestSamplingPoint_Class();
        UPTestAtSamplingPoint_Class UPTestAtSamplingPoint_Class_obj = new UPTestAtSamplingPoint_Class();
        List<UPTestSamplingPoint_Class> uptestsamplePoint_Class_ObjList = new List<UPTestSamplingPoint_Class>();
        public List<UPTestAtSamplingPoint_Class> UPTestAtSamplingPoint_Class_ObjList = new List<UPTestAtSamplingPoint_Class>();
        public List<UPdefect_Class> UPdefect_Class_ObjList = new List<UPdefect_Class>();

        public bool addedToExisting = false;
        System.Windows.Forms.Timer TimerCheckNotify;
        DataTable tblRunningSamplingGrids;
        DataTable tblDefectCount;
        #endregion
        //===================================================================================================================//


        private static FrmScoopUP FrmScoopUP_Obj = null;//--------Code for Singletonearchitecture

        public static FrmScoopUP GetInstance()
        {
            if (FrmScoopUP_Obj == null)
            {
                FrmScoopUP_Obj = new FrmScoopUP();
            }
            return FrmScoopUP_Obj;
        }

        private void FrmScoopUP_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            DtpDate.Value = Comman_Class_Obj.Select_ServerDate();
            Bind_Details();
            cmbDetails.Focus();
        }

        //Binds the pending Finished good details those entered in 
        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = FinishedGoodTest_Class_Obj.Select_PendingFinishedGoodDetailsUP();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["FGTLFID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "FGTLFID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                // BtnReset_Click(sender, e);

                ResetAll();
                //================manish k=============================================//
                dT = (DataTable)cmbDetails.DataSource;
                DataRow[] dR = dT.Select("FGTLFID=" + cmbDetails.SelectedValue + "");

                FinishedGoodTest_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                DataSet dsline = new DataSet();
                dsline = FinishedGoodTest_Class_Obj.Select_ScoopLineStart();
                if (dsline.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dsline.Tables[0].Rows[0]["KitFlag"]))
                    {
                        txtLineStarTime.Text = Convert.ToString(dR[0]["KitLineStartTime"]);
                    }
                    else
                    {
                        txtLineStarTime.Text = dsline.Tables[0].Rows[0]["LineStartedTime"].ToString();
                    }
                }
                else
                    txtLineStarTime.Text = Convert.ToString(dR[0]["KitLineStartTime"]);
                /* 
                if (Convert.ToBoolean(dR[0]["KitFlag"]))
                {
                    txtLineStarTime.Text = Convert.ToString(dR[0]["KitLineStartTime"]);
                    //FinishedGoodTest_Class_Obj.FGCode = dR[0]["FGCode"].ToString();
                    //FinishedGoodTest_Class_Obj.trackcode = Convert.ToDateTime(dR[0]["TrackCodeFG"].ToString()).ToShortDateString();
                    
                    //FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dR[0]["LNoFG"].ToString());
                    //FinishedGoodTest_Class_Obj.fgno = Convert.ToInt32(dR[0]["FGNoFG"].ToString());
                    //DataSet ds1 = FinishedGoodTest_Class_Obj.SelectLineStartedDate();
                    //if (ds1.Tables[0].Rows.Count==0)
                    //{
                    //    DataSet ds2 = FinishedGoodTest_Class_Obj.SelectLineStartedDatefromFGNonadTodayDate(Convert.ToDateTime(DateTime.Now.Date.ToShortDateString()), Convert.ToDateTime(DateTime.Now.Date.AddDays(1).ToShortDateString()));
                    //    txtLineStarTime.Text = Convert.ToString(ds2.Tables[0].Rows[0]["LineStartedTime"]);
                    //}
                    //else
                    //{
                    //    txtLineStarTime.Text =Convert.ToString(ds1.Tables[0].Rows[0]["LineStartedTime"]);
                    //}
                    //
                }
                else
                {
                    txtLineStarTime.Text = dR[0]["LineStartedTime"].ToString();
                }
                 * */
                //DateTime LneStrtTme = new DateTime();
                //if (string.IsNullOrEmpty(txtLineStarTime.Text.Trim()))
                //{
                //    txtLineStarTime.Text = Convert.ToString(DateTime.Now.ToShortDateString());
                //}

                masterSaved = false;
                FGTLFID2 = Convert.ToInt64(dR[0]["FGTLFID"].ToString());
                //=====================================================================//

                //Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "" && cmbDetails.SelectedIndex != 0)
                {
                    FinishedGoodTest_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);

                    //Select FGdetails from fgno 
                    DataSet dsFG = new DataSet();
                    dsFG = FinishedGoodTest_Class_Obj.Select_FinishedGood_FGDetails();
                    if (dsFG.Tables[0].Rows.Count > 0)
                    {
                        txtFGDesc.Text = dsFG.Tables[0].Rows[0]["FGDesc"].ToString();
                        txtPkgFamily.Text = dsFG.Tables[0].Rows[0]["TechFamDesc"].ToString();
                        FinishedGoodTest_Class_Obj.fgno = Convert.ToInt64(dsFG.Tables[0].Rows[0]["FGNo"]);
                        FinishedGoodTest_Class_Obj.pkgtechno = Convert.ToInt64(dsFG.Tables[0].Rows[0]["PKGTechNo"]);
                        FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dsFG.Tables[0].Rows[0]["LNoFG"]);
                        //get the current version no which need to dislay on report
                        if (dsFG.Tables[0].Rows[0]["VersionNo"] is System.DBNull)
                        {
                            FinishedGoodTest_Class_Obj.versionno = "";
                        }
                        else
                        {
                            FinishedGoodTest_Class_Obj.versionno = dsFG.Tables[0].Rows[0]["VersionNo"].ToString();
                        }
                    }
                    // for checking option launches for FGcode whose transaction already done
                    if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "0")
                    {
                        if (cmbDetails.SelectedValue != DBNull.Value)
                        {
                            DataSet dsPkg = FinishedGoodTest_Class_Obj.STP_SELECT_FGNo_FMID_PkgSamp();
                            if (dsPkg.Tables[0].Rows.Count > 0)
                            {
                                // RdoLaunch.Checked = false;
                            }
                            else
                            {
                                // RdoLaunch.Checked = true;
                            }
                        }
                    }
                    //Check the current date with reference date from formula master
                    //formula will expire after 1 year from the reference date
                    //It will start promting message 1 month before reference date

                    // If validity data already exist show by database else show valdity one year greater than track code
                    FGRefMgmtTransaction FGRefMgmtTransaction_obj = new FGRefMgmtTransaction();
                    DataTable dt = new DataTable();
                    FGRefMgmtTransaction_obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                    FGRefMgmtTransaction_obj.fgno = FGRefMgmtTransaction_obj.Select_FGNO_FGTLFID_FGRegMgt();
                    dt = FGRefMgmtTransaction_obj.Select_FGRefMgmtTransactionFGCode();

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (Comman_Class_Obj.Select_ServerDate() >= Convert.ToDateTime(dr["ValidityDate"]))
                            {
                                MessageBox.Show("FG Code Expired on" + Convert.ToDateTime(dr["ValidityDate"]).ToString("dd/MMM/yyyy"), "Finished Good Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmbDetails.Focus();
                                cmbDetails.SelectedValue = 0;
                                return;
                            }
                            else if (Comman_Class_Obj.Select_ServerDate() < Convert.ToDateTime(dr["ValidityDate"]).AddDays(-15))
                            {

                            }
                            else
                            {
                                //lblMessage.Text = "This formula will Expire on " + Convert.ToString(Convert.ToDateTime(ds.Tables[0].Rows[0]["ReferenceDate"]).AddMonths(12).ToShortDateString());
                                NotifyWindow nw = new NotifyWindow("FG Code Expiry", Convert.ToDateTime(dr["ValidityDate"]).ToString("dd/MMM/yyyy"));
                                nw.Notify();
                            }
                        }
                    }



                    //Select Bulk & Packing Details 
                    DataSet dsPkgBulk = new DataSet();
                    dsPkgBulk = FinishedGoodTest_Class_Obj.Select_FinishedGood_PackingBulkTestDetails();
                    for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)
                    {
                        dgKit.Rows.Add();
                        dgKit["TLFID", i].Value = dsPkgBulk.Tables[0].Rows[i]["TLFID"].ToString();
                        dgKit["FNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString();
                        dgKit["FormulaNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString();
                        dgKit["MfgWo", i].Value = dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();
                        dgKit["FGNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FGNo"].ToString();
                        dgKit["FGCode", i].Value = dsPkgBulk.Tables[0].Rows[i]["FGCode"].ToString();
                        dgKit["TrackCode", i].Value = Convert.ToDateTime(dsPkgBulk.Tables[0].Rows[i]["TrackCode"]).ToShortDateString();
                        dgKit["LineDesc", i].Value = dsPkgBulk.Tables[0].Rows[i]["LineDesc"].ToString();
                        LineSamplePackingDetails_Class objLineSamplePackingDetails_Class = new LineSamplePackingDetails_Class();
                        objLineSamplePackingDetails_Class.tlfid = Convert.ToInt32(dsPkgBulk.Tables[0].Rows[i]["TLFID"]);
                        DataSet dsFGTLF = objLineSamplePackingDetails_Class.Select_ModificationLinePackingDetails_Details();
                        if (dsFGTLF != null)
                        {
                            if (dsFGTLF.Tables.Count > 0)
                            {
                                if (dsFGTLF.Tables[0].Rows.Count > 0)
                                {
                                    dgKit["PkgWO", i].Value = dsFGTLF.Tables[0].Rows[0]["PkgWO"].ToString();
                                }
                            }
                        }
                        //dgKit["PkgWO", i].Value = dsPkgBulk.Tables[0].Rows[i]["PkgWOFG"].ToString();
                        dgKit["FillDate", i].Value = Convert.ToDateTime(dsPkgBulk.Tables[0].Rows[i]["FillDateFG"]).ToShortDateString();
                        dgKit["Price", i].Value = dsPkgBulk.Tables[0].Rows[i]["PriceFG"].ToString();
                        dgKit["specification", i].Value = dsPkgBulk.Tables[0].Rows[i]["specificationFG"].ToString();
                        dgKit["Status", i].Value = dsPkgBulk.Tables[0].Rows[i]["Status"].ToString();
                    }

                    //Display unit PackSize and Weight
                    DataSet dsUnit;
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        dsUnit = new DataSet();
                        FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                        dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                        if (dsUnit.Tables[0].Rows.Count > 0)
                        {
                            if (dsUnit.Tables[0].Rows[0]["PackSize"] is DBNull)
                            {

                            }
                            else
                            {
                                dgKit["PackSize", i].Value = dsUnit.Tables[0].Rows[0]["PackSize"].ToString();
                            }

                            if (dsUnit.Tables[0].Rows[0]["Weight"] is DBNull)
                            {

                            }
                            else
                            {
                                dgKit["Weight", i].Value = dsUnit.Tables[0].Rows[0]["Weight"].ToString();
                            }
                        }
                    }

                    #region dgTestPrivious(Finished good test)
                    ////Add column in dgTest for Packing
                    //dgTest.Columns.Add("Packing", "Packing");
                    //dgTest.Columns["Packing"].Width = 100;
                    //dgTest.Columns["Packing"].ReadOnly = true;

                    ////Select PkgStatus from fgno,fno,trackcode,lno and display into packing cell 
                    //DataSet ds1 = new DataSet();
                    //ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPackingDetails_PkgStatus();
                    //if (ds1.Tables[0].Rows.Count > 0)
                    //{
                    //    dgTest["packing", 0].Value = ds1.Tables[0].Rows[0]["PkgStatus"].ToString();
                    //    FinishedGoodTest_Class_Obj.quantity = Convert.ToInt32(ds1.Tables[0].Rows[0]["Quantity"]);
                    //}
                    //else
                    //{
                    //    dgTest["packing", 0].Value = "";
                    //    FinishedGoodTest_Class_Obj.quantity = 0;
                    //}


                    ////add columns in dgTest depends on no of MfgWo
                    //for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)
                    //{
                    //    //Check whether the column exists 
                    //    if (dgTest.Columns.Contains(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()) == false)
                    //    {
                    //        dgTest.Columns.Add(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString() + "\n" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString());
                    //        dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].Width = 100;
                    //        dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].ReadOnly = true;

                    //        FinishedGoodTest_Class_Obj.fno = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[i]["FNo"]);
                    //        FinishedGoodTest_Class_Obj.mfgwo = dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();

                    //        DataSet ds2 = new DataSet();
                    //        //Select PhyCheStatus from fgno,fno,trackcode,lno, mfgwo and display into cell
                    //        ds2 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus();
                    //        if (ds2.Tables[0].Rows.Count > 0)
                    //        {
                    //            dgTest[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), 0].Value = ds2.Tables[0].Rows[0]["PhyCheStatus"].ToString();
                    //        }
                    //        else
                    //        {
                    //            dgTest[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), 0].Value = "";
                    //        }
                    //    }

                    //}
                    #endregion

                    //========================== manish k===========================//
                    Reset_SamplingGrid();
                    Get_SamplingPoint();

                    //=============================================================//


                    txtControltype.Text = FinishedGoodTest_Class_Obj.Decide_ControlType_FG();
                    FinishedGoodTest_Class_Obj.type = txtControltype.Text.Trim();

                }
                GrpBoxTst.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //=============== manish k ===============//

        DataSet DSgridrow = new DataSet();  //<----------- CONTAINS RECORD OF SAVED ROWS (TIME,DEFECT,LAST) FOR THE SELECTED LINE IF EXISTSALREADY

        //========= now =====================

        private void Get_SamplingPoint()   //<------------ FUNCTION TO GENERATE SAMPLING POINT GRIDS FOR SELECTED LINE
        {
            try
            {


                // =================== FLUSH EXISTING RECORDS ===================================//

                if (DSSamplingInfo != null) //<--------- DSsampmlingPoint DATASET 
                {
                    DSSamplingInfo.Clear();
                }
                else
                {
                    DSSamplingInfo = new DataSet();
                }

                if (DSfgtlFGLne != null) //<------------ DSfgtlFGLine DATASET
                {
                    DSfgtlFGLne.Clear();
                }
                else
                {
                    DSfgtlFGLne = new DataSet();
                }

                if (RecordExistDs != null)
                {
                    RecordExistDs = null;
                }

                if (DT_DefectLog.Rows.Count > 0) //<--------------------------- CLEAR THE DEFECTTEST LOGS
                {
                    DT_DefectLog.Clear();
                }


                if (tblRunningSamplingGrids == null)
                {
                    tblRunningSamplingGrids = new DataTable();
                    tblRunningSamplingGrids.Columns.Add("UC_Grid", typeof(UC_SamplingGrid));
                }
                else
                {
                    tblRunningSamplingGrids.Clear();
                }

                if (tblDefectCount == null)
                {

                    tblDefectCount = new DataTable();
                }
                else
                {
                    tblDefectCount.Clear();

                }

                StopTimers();


                //=====================================================================================================================//

                FinishedGoodTest_Class_Obj.fgtlfid = FGTLFID2;
                DSfgtlFGLne = FinishedGoodTest_Class_Obj.Select_selectFgLine_tblFGTLF();

                SCOOPTestMethodMaster_Class_Obj.fgNo = Convert.ToInt64(DSfgtlFGLne.Tables[0].Rows[0]["FGNoFG"].ToString());
                SCOOPTestMethodMaster_Class_Obj.lno = Convert.ToInt32(DSfgtlFGLne.Tables[0].Rows[0]["LNoFG"].ToString());

                DSSamplingInfo = SCOOPTestMethodMaster_Class_Obj.select_STP_Select_NoSampleForFGLine();

                int left = pnlTestGrid.Left + 5;

                DateTime LneStrtTme = new DateTime();
                if (string.IsNullOrEmpty(txtLineStarTime.Text.Trim()))
                {
                    UPMaster_Class_Obj.linestarttime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                    LneStrtTme = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                }
                else
                {
                    UPMaster_Class_Obj.linestarttime = Convert.ToDateTime(txtLineStarTime.Text);
                    LneStrtTme = Convert.ToDateTime(txtLineStarTime.Text);
                }

                string strttme = LneStrtTme.ToString("t");

                if (!Record_Exists())
                {
                    #region GENERATE SAMPLING GRID FOR NEW TEST

                    if (DSSamplingInfo.Tables[0].Rows.Count > 0)
                    {
                        //txtLineStarTime.Text = Convert.ToString(DateTime.Now);
                        foreach (DataRow dr in DSSamplingInfo.Tables[0].Rows)
                        {
                            UC_SamplingGrid uc_grid = null;
                            //---create sampling test grid(user control)----//
                            if (!string.IsNullOrEmpty(txtLineStarTime.Text.Trim()))
                            {
                                uc_grid = new UC_SamplingGrid(this, Convert.ToDateTime(txtLineStarTime.Text));
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(LneStrtTme)))
                                {
                                    uc_grid = new UC_SamplingGrid(this, Convert.ToDateTime(LneStrtTme));
                                    txtLineStarTime.Text = Convert.ToString(LneStrtTme);
                                }
                            }


                            //----set properties--------------------------//
                            uc_grid.samplingPoint = dr["SamplingPointName"].ToString();
                            uc_grid.frequency = Convert.ToInt32(dr["Frequency"].ToString());
                            uc_grid.samplingPointId = Convert.ToInt64(dr["SamplingPointId"].ToString());
                            uc_grid.setDefectBrodcostFalse();
                            //------------- set location ---------------//
                            uc_grid.Top = 0;
                            uc_grid.Left = left;
                            left = uc_grid.Right + 5;

                            //----------- add to This Form------------------//
                            uc_grid.dgSamplingPoint.Rows.Add(strttme, strttme);
                            pnlTestGrid.Controls.Add(uc_grid);

                            tblRunningSamplingGrids.Rows.Add(uc_grid);
                            //-------------check proces start time if it is exided than 15 minut-------//

                        }
                        if (string.IsNullOrEmpty(txtLineStarTime.Text.Trim()))
                        {
                            txtLineStarTime.Text = DateTime.Now.ToShortDateString();
                        }
                        //------------------ code to check time exided ------------------------------//
                        if (txtLineStarTime.Text != "")
                        {
                            timeleft = Class_ScoopProcess.TimeLeft_AfterLineStart(Convert.ToDateTime(txtLineStarTime.Text));
                            foreach (DataRow dr in tblRunningSamplingGrids.Rows)
                            {
                                if (timeleft == 0)
                                {

                                    ((UC_SamplingGrid)dr[0]).SetSamplingGridRow("NotDone", (Convert.ToDateTime(txtLineStarTime.Text).AddMinutes(15)).ToString("t"));
                                    Save_NotDoneTest((UC_SamplingGrid)dr[0]);
                                }
                                else
                                {
                                    ((UC_SamplingGrid)dr[0]).timeleft = timeleft;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Line Start time is not avialable", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        start_Timer(); //<-----------------------------------------------------------  STARTS THE TIME TO START ADDING ROWS
                    }

                    #endregion
                }
                else
                {

                    #region  GENERATE SAMPLING GRID FOR EXISTING TEST RECORD IN DATABSE

                    bool lastrowDefect = false;

                    List<DateTime> DefctTimeLog = new List<DateTime>();

                    foreach (DataRow dr in RecordExistDs.Tables[0].Rows) //<-------------------------- RECORD EXIST DS CONTAINS ALL THE SAVED SAMPLING POINTS FOR THE DETAILS
                    {
                        //---create sampling test grid(user control)----//
                        UC_SamplingGrid uc_grid = new UC_SamplingGrid(this, Convert.ToDateTime(txtLineStarTime.Text));

                        //----set properties--------------------------//
                        uc_grid.samplingPoint = dr["SamplingPointName"].ToString();
                        uc_grid.frequency = Convert.ToInt32(dr["Frequency"].ToString());
                        uc_grid.samplingPointId = Convert.ToInt64(dr["SampleID"].ToString());
                        uc_grid.upTestSamplingId = Convert.ToInt64(dr["UPSamplingPontTestID"].ToString());
                        uc_grid.setDefectBrodcostFalse();
                        //------------- set location ---------------//
                        uc_grid.Top = 0;
                        uc_grid.Left = left;
                        left = uc_grid.Right + 5;

                        pnlTestGrid.Controls.Add(uc_grid);
                        tblRunningSamplingGrids.Rows.Add(uc_grid);


                        int Zcount = 0, Ccount = 0, Mcount = 0, M1count = 0, DCount = 0;
                        UPTestAtSamplingPoint_Class_obj.uptestsamplingpointid = Convert.ToInt64(dr["UPSamplingPontTestID"].ToString());
                        tblDefectCount = UPTestAtSamplingPoint_Class_obj.Get_DEfectCount2().Tables[0];// UPTestSamplingPoint_Class_Obj.Get_DefectCount();
                        foreach (DataRow drdfct in tblDefectCount.Rows)
                        {
                            DCount += (int)drdfct["AQLMx"];
                            Zcount += (int)drdfct["AQLZMx"];
                            Ccount += (int)drdfct["AQLCMx"];
                            Mcount += (int)drdfct["AQLMMx"];
                            M1count += (int)drdfct["AQLM1Mx"];

                        }
                        uc_grid.setDefectCount(0, DCount.ToString());
                        uc_grid.setDefectCount(1, Zcount.ToString());
                        uc_grid.setDefectCount(2, Ccount.ToString());
                        uc_grid.setDefectCount(3, Mcount.ToString());
                        uc_grid.setDefectCount(4, M1count.ToString());

                        if (DSgridrow != null) //<--------------------------------------------------------------------------- DSgridrow CONTAINS ROWS FOR THE THAT SAMPLING GRIDS
                        {
                            DSgridrow.Clear();
                        }
                        UPTestAtSamplingPoint_Class_obj.uptestsamplingpointid = Convert.ToInt64(dr["UPSamplingPontTestID"].ToString());

                        DSgridrow = UPTestAtSamplingPoint_Class_obj.Select_SelectSamplingRow_tblUPTestAtSAmplingPoint();

                        if (DSgridrow.Tables[0].Rows.Count == 0)
                        {

                        }
                        foreach (DataRow dr2 in DSgridrow.Tables[0].Rows)
                        {
                            if (dr2["Resume"].ToString().Contains("Resume"))
                            {
                                // uc_grid.Add_SamplingRow(dr2["Resume"].ToString(), dr2["ExpectedTime"].ToString());
                                uc_grid.Add_SamplingRow(dr2["time"].ToString(), dr2["ExpectedTime"].ToString());
                                //uc_grid.SetSamplingGridRow("Resume", dr2["Resume"].ToString(), Convert.ToDateTime(dr2["TimeBrief"].ToString()));
                                uc_grid.SetSamplingGridRow("Resume", dr2["time"].ToString(), Convert.ToDateTime(dr2["TimeBrief"].ToString()));
                            }

                            else if (dr2["Last"].ToString().Contains("Last"))
                            {
                                uc_grid.Add_SamplingRow(dr2["Last"].ToString(), dr2["ExpectedTime"].ToString());
                                uc_grid.SetSamplingGridRow("Last", dr2["Last"].ToString(), Convert.ToDateTime(dr2["TimeBrief"].ToString()));

                            }
                            else if (dr2["GridRow"].ToString().Contains("Defect"))
                            {
                                uc_grid.Add_SamplingRow(dr2["GridRow"].ToString(), dr2["ExpectedTime"].ToString());
                                uc_grid.SetSamplingGridRow("Defect", dr2["GridRow"].ToString(), Convert.ToDateTime(dr2["TimeBrief"].ToString()));
                            }
                            else if (dr2["NotDone"].ToString().Contains("NotDone"))
                            {
                                uc_grid.Add_SamplingRow(dr2["time"].ToString(), dr2["ExpectedTime"].ToString());
                                uc_grid.SetSamplingGridRow("NotDone", dr2["time"].ToString(), Convert.ToDateTime(dr2["TimeBrief"].ToString()));
                            }
                            else
                            {
                                string type = dr2["Yellow"].ToString().Contains("Yellow") ? "MinorDefect" : "OK";
                                uc_grid.Add_SamplingRow(dr2["time"].ToString(), dr2["ExpectedTime"].ToString());
                                uc_grid.SetSamplingGridRow(type, dr2["time"].ToString(), Convert.ToDateTime(dr2["TimeBrief"].ToString()));
                            }

                        }
                        if (uc_grid.dgSamplingPoint.RowCount > 0)
                        {
                            lastrowDefect = uc_grid.dgSamplingPoint.Rows[uc_grid.dgSamplingPoint.RowCount - 1].Cells[0].Value.ToString().Contains("Defect") ? true : false;
                            if (lastrowDefect)
                            {
                                DefctTimeLog.Add(Convert.ToDateTime(uc_grid.dgSamplingPoint.Rows[uc_grid.dgSamplingPoint.RowCount - 1].Tag.ToString()));
                            }
                        }

                    }

                    #endregion

                    if (Is_Today()) //........<------------------------------------------------------------------- IS TODAY FUNCTION CHECKS IF EXISTED RECORD IS OF TODAY
                    {

                        #region is today
                        //PMNotDoneExided=tblRunningSamplingGrids.Rows.Count * 10;
                        foreach (DataRow dr in tblRunningSamplingGrids.Rows)
                        {
                            UC_SamplingGrid ucgrid = (UC_SamplingGrid)dr[0];
                            DefctTimeLog.Sort(DateTime.Compare);
                            DefctTimeLog.Reverse();

                            string sheduledatOnly = Class_ScoopProcess.GetCurrentTime().ToString("d");//System.DateTime.Today.ToString("d");
                            //sheduledatOnly = sheduledatOnly + " " + ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Cells[1].Value.ToString();
                            if (ucgrid.dgSamplingPoint.Rows.Count > 0)
                            {
                                sheduledatOnly = sheduledatOnly + " " + ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Cells[1].Value.ToString();
                                DateTime sheduledTime = Convert.ToDateTime(sheduledatOnly);

                                ucgrid.sheduledTime = sheduledTime;
                            }


                            //------------ if samplig grid has no row -----
                            if (ucgrid.dgSamplingPoint.RowCount == 0)
                            {
                                ucgrid.Add_SamplingRow(Convert.ToDateTime(txtLineStarTime.Text).ToString("t"), Convert.ToDateTime(txtLineStarTime.Text).ToString("t"));
                                timeleft = Class_ScoopProcess.TimeLeft_AfterLineStart(Convert.ToDateTime(txtLineStarTime.Text));
                                if (timeleft == 0)
                                {
                                    ucgrid.SetSamplingGridRow("NotDone", (Convert.ToDateTime(txtLineStarTime.Text).AddMinutes(15)).ToString("t"));
                                    Save_NotDoneTest(ucgrid);
                                }
                                else
                                {
                                    ucgrid.timeleft = timeleft;
                                }

                            }

                            //------------- if last SamplingGridRow is not Done ------------
                            if (ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Cells[0].Value.ToString().Contains("NotDone"))
                            {

                                UPTestAtSamplingPoint_Class UPTestAtSamplingPoint_Class_Obj2 = new UPTestAtSamplingPoint_Class();
                                UPTestAtSamplingPoint_Class_Obj2.time = ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Cells[0].Value.ToString().Substring(0, ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Cells[0].Value.ToString().LastIndexOf('M') + 1);
                                UPTestAtSamplingPoint_Class_Obj2.uptestsamplingpointid = ucgrid.upTestSamplingId;
                                UPTestAtSamplingPoint_Class_Obj2.expectedtime = ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Cells[1].Value.ToString();
                                DataSet DS = new DataSet();
                                DS = UPTestAtSamplingPoint_Class_Obj2.Select_NotDoneDesc();
                                if (DS.Tables[0].Rows.Count == 0)
                                {
                                    string[] arr = ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.Rows.Count - 1].Cells[0].Value.ToString().Split('-');
                                    ucgrid.Add_SamplingRow((Convert.ToDateTime((arr[0])).AddMinutes((int)ucgrid.frequency)).ToString("t"), ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.Rows.Count - 1].Cells[0].Value.ToString());
                                    TimeSpan tmspn = new TimeSpan();
                                    string[] arr1 = (ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.Rows.Count - 2].Cells[0].Value.ToString().Split('-'));
                                    tmspn = Convert.ToDateTime(arr1[0]).Subtract(UPMaster_Class_Obj.GetCurrentTime());
                                    timeleft = Convert.ToInt32(tmspn.TotalMinutes.ToString().Substring(0, tmspn.TotalMinutes.ToString().LastIndexOf('.')));
                                    if (timeleft <= 0)
                                    {
                                        ucgrid.timeleft = 1;
                                    }
                                    else
                                    {
                                        ucgrid.timeleft = timeleft;
                                    }
                                }
                            }

                            //---------------- if last SamplingGridRow is defect --------------------

                            if (ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Cells[0].Value.ToString().Contains("Defect"))
                            {
                                ucgrid.timeleft = 0;
                                ucgrid.BroadCastDefect();
                            }

                            //--------------- if last SamplingGridRow is OK -----------

                            #region //--------------- if last SamplingGridRow is OK -----------
                            if (ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Cells[0].Value.ToString().Contains("OK") || ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Cells[0].Value.ToString().Contains("Resume"))
                            {
                                if (DefctTimeLog.Count > 0)
                                {

                                    foreach (DateTime dtm in DefctTimeLog)
                                    {
                                        int vl = DateTime.Compare(Convert.ToDateTime(ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Tag.ToString()), dtm);
                                        if (vl < 0)
                                        {
                                            int vl2 = DateTime.Compare(Convert.ToDateTime(ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Tag.ToString()).AddMinutes((int)ucgrid.frequency + 10), Class_ScoopProcess.GetCurrentTime());

                                            if (vl2 <= 0)
                                            {
                                                //---Not in 'Frequency+10' Rang
                                                ucgrid.Add_SamplingRow();
                                                ucgrid.SetSamplingGridRow("NotDone", Convert.ToDateTime(ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 2].Tag.ToString()).AddMinutes((int)ucgrid.frequency + 10).ToString("t"));
                                                Save_NotDoneTest(ucgrid);
                                            }
                                            else
                                            {
                                                //---in 'Frequency+10' Range
                                                ucgrid.Add_SamplingRow();
                                                TimeSpan tmspn = new TimeSpan();

                                                tmspn = (Convert.ToDateTime((ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 2].Tag.ToString())).Subtract(UPMaster_Class_Obj.GetCurrentTime()));
                                                timeleft = Convert.ToInt32(tmspn.TotalMinutes.ToString().Substring(0, tmspn.TotalMinutes.ToString().LastIndexOf('.')));
                                                if (timeleft <= 0)
                                                {
                                                    ucgrid.timeleft = 1;
                                                }
                                                else
                                                {
                                                    ucgrid.timeleft = timeleft;
                                                }
                                            }

                                            break;
                                        }

                                    }
                                }
                                else
                                {

                                    int vl = DateTime.Compare(Convert.ToDateTime(ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1].Tag.ToString()).AddMinutes((int)ucgrid.frequency + 10), Class_ScoopProcess.GetCurrentTime());

                                    if (vl <= 0)
                                    {
                                        //---Not in 'Frequency+10' Rang
                                        ucgrid.Add_SamplingRow();
                                        ucgrid.SetSamplingGridRow("NotDone", Convert.ToDateTime(ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 2].Tag.ToString()).AddMinutes((int)ucgrid.frequency + 10).ToString("t"));
                                        Save_NotDoneTest(ucgrid);
                                    }
                                    else
                                    {
                                        //---in 'Frequency+10' Range
                                        ucgrid.Add_SamplingRow();
                                        TimeSpan tmspn = new TimeSpan();

                                        tmspn = (Convert.ToDateTime((ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 2].Tag.ToString())).Subtract(UPMaster_Class_Obj.GetCurrentTime()));
                                        timeleft = -Convert.ToInt32(tmspn.TotalMinutes.ToString().Substring(0, tmspn.TotalMinutes.ToString().LastIndexOf('.')));

                                        #region code updated by Avinash S Not done issue

                                        //if (timeleft <= 0)
                                        //{
                                        //    ucgrid.timeleft = 1;
                                        //}
                                        //else
                                        //{
                                        //    ucgrid.timeleft = timeleft;
                                        //}

                                        if (timeleft >= ucgrid.frequency + 10)
                                            ucgrid.timeleft = 1;
                                        else
                                            ucgrid.timeleft = ((int)(ucgrid.frequency) + 10) - timeleft;
                                        #endregion
                                    }


                                }

                            }
                            #endregion


                        }

                        #endregion

                        // Check Last Row check last row was defected or not 
                        //then check islast flag in db and then chek UP and Quality authority remark
                        // then add new row end of grid 
                        //bool chkDefect = false;
                        UPTestAtSamplingPoint_Class UPTestAtSamplingPoint_Class_Obj23 = new UPTestAtSamplingPoint_Class();
                        if (pnlTestGrid.Controls.Count > 0)
                        {
                            foreach (Control var in pnlTestGrid.Controls)
                            {
                                UC_SamplingGrid objGrid = (UC_SamplingGrid)var;
                                foreach (Control cCnt in var.Controls)
                                {
                                    DataGridView grd = (DataGridView)cCnt;
                                    if (grd.Name.Equals("dgSamplingPoint"))
                                    {
                                        //Check last Row was defected or not
                                        if (grd.Rows.Count > 0)
                                        {
                                            DataGridViewRow row = grd.Rows[grd.Rows.Count - 1];
                                            UPTestAtSamplingPoint_Class_Obj23.uptestsamplingpointid = objGrid.upTestSamplingId;//Convert.ToInt32(grd.Rows[grd.RowCount - 1].Cells[0].Value.ToString());
                                            UPTestAtSamplingPoint_Class_Obj23.time = Convert.ToString(row.Cells[0].Value);
                                            if (UPTestAtSamplingPoint_Class_Obj23.time.Contains("NotDone"))
                                            {
                                                string[] arr = (UPTestAtSamplingPoint_Class_Obj23.time.Split('-'));
                                                UPTestAtSamplingPoint_Class_Obj23.time = arr[0];
                                            }
                                            // Check Last was defected or not
                                            if (row.DefaultCellStyle.BackColor == Color.Red)
                                            {
                                                //chkDefect = true;                                                
                                                if (UPTestAtSamplingPoint_Class_Obj23.CheckIsLastWasDone() == 0)
                                                {
                                                    if (objGrid.TestContinueApproved())
                                                    {
                                                        objGrid.AddRowAfterApproval();
                                                        objGrid.defectOccuredHere = false;
                                                        UC_SamplingGrid.defectOccuredAtOneEnd = false;
                                                    }
                                                }
                                                //break;
                                            }
                                            else if (row.DefaultCellStyle.BackColor == Color.Yellow || row.DefaultCellStyle.BackColor == Color.Green)
                                            {
                                                if (UPTestAtSamplingPoint_Class_Obj23.CheckIsLastWasDone() == 0)
                                                {
                                                    objGrid.AddRowAfterApproval();
                                                }
                                            }
                                            else if (row.DefaultCellStyle.BackColor == Color.Orange)
                                            {
                                                if (UPTestAtSamplingPoint_Class_Obj23.CheckPMNotDone() > 0)
                                                {
                                                    //int ii=Convert.ToInt32(objGrid.Te);
                                                    DateTime dt = Class_ScoopProcess.GetCurrentTime();
                                                    TimeSpan ts = dt.TimeOfDay;
                                                    TimeSpan ts1 = objGrid.sheduledTime.TimeOfDay;
                                                    TimeSpan res = ts.Subtract(ts1);
                                                    int hr = res.Hours;
                                                    int minutes = res.Minutes;
                                                    if (hr == 0)
                                                    {
                                                        if (minutes < 20)
                                                        {
                                                            if (UPTestAtSamplingPoint_Class_Obj23.CheckUPApproval() > 0)
                                                            {
                                                                if (UPTestAtSamplingPoint_Class_Obj23.CheckQualityApproval() > 0)
                                                                {
                                                                    objGrid.AddRowAfterApproval();
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (UPTestAtSamplingPoint_Class_Obj23.CheckUPApproval() > 0)
                                                            {
                                                                if (UPTestAtSamplingPoint_Class_Obj23.CheckQualityApproval() > 0)
                                                                {
                                                                    objGrid.AddRowAfterApproval();
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (UPTestAtSamplingPoint_Class_Obj23.CheckUPApproval() > 0)
                                                        {
                                                            if (UPTestAtSamplingPoint_Class_Obj23.CheckQualityApproval() > 0)
                                                            {
                                                                objGrid.AddRowAfterApproval();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {

                        }

                        start_Timer();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Get_SamplingPoint" + ex.Message);
            }

        }

        private void Reset_SamplingGrid()
        {
            if (pnlTestGrid.Controls.Count > 0)
            {
                pnlTestGrid.Controls.Clear();
            }

        }

        System.Windows.Forms.Timer tmr;

        private void start_Timer()
        {
            try
            {
                if (tmr == null)
                {
                    tmr = new System.Windows.Forms.Timer();
                    tmr.Interval = 60000;
                    tmr.Tick += new EventHandler(tmr_Tick);
                }

                tmr.Start();
            }
            catch
            {

            }
        }

        //int _PMNotDoneExided;
        private int _PMNotDoneExided = 0;

        public int PMNotDoneExided
        {
            get { return _PMNotDoneExided; }
            set { _PMNotDoneExided = value; }
        }


        private void tmr_Tick(object o, EventArgs e)
        {
            try
            {


                DateTime time = UPMaster_Class_Obj.GetCurrentTime();

                #region UserControlConcept
                if (tblRunningSamplingGrids.Rows.Count == 0)
                {
                    return;
                }
                foreach (DataRow dr in tblRunningSamplingGrids.Rows)
                {
                    UC_SamplingGrid ucGrid = (UC_SamplingGrid)dr[0];
                    if (ucGrid.timeleft == 1)
                    {
                        ucGrid.SetSamplingGridRow("NotDone", time.ToString("t"));
                        //PMNotDoneExided=tblRunningSamplingGrids.Rows.Count*10;                                 
                        Save_NotDoneTest(ucGrid);
                    }
                    if (ucGrid.timeleft > 0)
                    {
                        ucGrid.timeleft = ucGrid.timeleft - 1;
                    }
                    //if (PMNotDoneExided > 0)
                    //{
                    //    PMNotDoneExided--;
                    //}
                    //if (PMNotDoneExided == 1)
                    //{
                    //    UC_SamplingGrid.PMNotDoneTimeExided = true;
                    //}
                }

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + "InTimer");
            }

        }

        int timeleft = 0;

        DataTable DT_DefectLog = new DataTable(); //<---------------------------------------------------------------------------------- this table keeps the record of defect occured (datagrid,gridrow)

        bool TimerCheckNotifyStarted = false;

        public string timeOfDefectTest;

        public string expectedTimeOfDefectTest;

        public Int64 DefectUpTestAtsampingPoint;


        //..............can be deleted and of no use
        private void dg_CellValueChanged(object sender, DataGridViewCellEventArgs e) //<-------------------------------------------------  this event mainly to add defect row and grid to defect log table and to start notificatin timer
        {
            try
            {
                DataGridView dg = (DataGridView)sender;

                if (DT_DefectLog.Columns.Count == 0)
                {
                    DT_DefectLog.Columns.Add("SamplingGrid", typeof(DataGridView));
                    DT_DefectLog.Columns.Add("RowIndex", typeof(int));
                    DT_DefectLog.Columns.Add("Time", typeof(string));
                    DT_DefectLog.Columns.Add("ExpectedTime", typeof(string));
                }
                if (dg.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Defect"))
                {

                    DT_DefectLog.Rows.Add(dg, e.RowIndex, dg.Rows[e.RowIndex].Cells[0].Value.ToString().Substring(0, dg.Rows[e.RowIndex].Cells[0].Value.ToString().LastIndexOf('M') + 1), dg.Rows[e.RowIndex].Cells[1].Value.ToString().Substring(0, dg.Rows[e.RowIndex].Cells[1].Value.ToString().LastIndexOf('M') + 1));
                    if (!TimerCheckNotifyStarted)
                    {
                        TimerCheckNotifyStarted = true;
                        TimerCheckNotify.Interval = 40000;
                        TimerCheckNotify.Tick += new EventHandler(TimerCheckNotify_Tick);
                        TimerCheckNotify.Start();
                    }

                }
            }
            catch
            {
                throw;
            }


        }

        public void startNotifyTimer()
        {

            if (TimerCheckNotify == null)
            {
                TimerCheckNotify = new System.Windows.Forms.Timer();
                TimerCheckNotifyStarted = true;
                TimerCheckNotify.Interval = 40000;
                TimerCheckNotify.Tick += new EventHandler(TimerCheckNotify_Tick);
                TimerCheckNotify.Start();
            }

        }

        private void TimerCheckNotify_Tick(object sender, EventArgs e)//<----------------------------------------------------------------- here the event checks if the added defects rows was aproved to further test and if it was then add
        {                                                                                                                                //next iommediate row and remove defect row from defect log table
            try
            {
                TimerCheckNotifyStarted = true;
                if (!UC_SamplingGrid.defectOccuredAtOneEnd)
                {
                    return;
                }
                bool flg = true;
                foreach (DataRow dr in tblRunningSamplingGrids.Rows)
                {
                    UC_SamplingGrid ucgrid = (UC_SamplingGrid)dr[0];
                    if (ucgrid.defectOccuredHere)
                    {
                        flg = false;
                        if (ucgrid.TestContinueApproved())
                        {
                            ucgrid.defectOccuredHere = false;
                            flg = true;
                        }
                    }

                }
                if (flg == true)
                {
                    UC_SamplingGrid.defectOccuredAtOneEnd = false;
                    foreach (DataRow dr in tblRunningSamplingGrids.Rows)
                    {
                        ((UC_SamplingGrid)dr[0]).AddRowAfterApproval();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "In Notify Timer");
            }
        }

        private bool Is_Today() //<------------------------------------------------------------------------------------------------------- Check if line started today
        {
            DateTime dt = Convert.ToDateTime(txtLineStarTime.Text);

            if ((dt.Subtract(UPMaster_Class_Obj.GetCurrentTime()).Days == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void FrmScoopUP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TimerCheckNotify != null)
            {
                TimerCheckNotify.Stop();
                TimerCheckNotify.Dispose();
            }

            if (tmr != null)
            {
                tmr.Stop();
                tmr.Dispose();
            }

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //cmbDetails.Text = "--Select--";
            txtFGDesc.Text = "";
            txtPkgFamily.Text = "";
            txtControltype.Text = "";
            dgKit.Rows.Clear();
            cmbDetails.SelectedIndex = 0;
            cmbDetails.Focus();
            //====================Manish K =====================================//

            Reset_SamplingGrid();

        }

        private void ResetAll()
        {
            txtFGDesc.Text = "";
            txtPkgFamily.Text = "";
            txtControltype.Text = "";
            dgKit.Rows.Clear();
            //====================Manish K =====================================//
            Reset_SamplingGrid();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (tmr != null)
            {
                tmr.Stop();
                tmr.Dispose();
            }
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region Privious NONSCOOP CODE
                //if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
                //{
                //    MessageBox.Show("please select Details", "Message");
                //    return;
                //}
                //else
                //{
                //    //FinishedGoodTest_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                //    //FinishedGoodTest_Class_Obj.cnt = 0;
                //    //int icount = FinishedGoodTest_Class_Obj.Select_ValidityDate_FGCode();
                //    //if (icount == 0)
                //    //{
                //        //Can't ACCEPT if any pack/phyche contains 'R'
                //        bool R = false;

                //        for (int i = 0; i < dgTest.Columns.Count; i++)
                //        {
                //            if (dgTest[i, 0].Value.ToString() == "R")
                //            {
                //                R = true;
                //                break;
                //            }

                //        }
                //        if (RdoAccepted.Checked == true && R == true)
                //        {
                //            MessageBox.Show("Sorry can't ACCEPT..!\n\nSome tests are rejected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            RdoRejected.Focus();
                //            return;
                //        }
                //        bool H = false;
                //        for (int i = 0; i < dgTest.Columns.Count; i++)
                //        {
                //            if (dgTest[i, 0].Value.ToString() == "H")
                //            {
                //                H = true;
                //                break;
                //            }
                //        }
                //        if ((RdoAccepted.Checked == true || RdoRejected.Checked == true || RdoAWD.Checked == true || RdoTreatment.Checked == true) && H == true)
                //        {
                //            MessageBox.Show("Sorry can't ACCEPT..!\n\nSome tests are Hold", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            RdoHold.Focus();
                //            return;
                //        }
                //        if (RdoRejected.Checked && ChkReject.CheckedItems.Count == 0)
                //        {
                //            MessageBox.Show("Select Type for Reject.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            ChkReject.Focus();
                //            return;
                //        }

                //        if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                //        {
                //            MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            cmbInspectedBy.Focus();
                //            return;
                //        }
                //        if (RdoNonBpc.Checked != true && RdoBpc.Checked != true)
                //        {
                //            MessageBox.Show("Select BPC/NonBPC", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            return;
                //        }
                //        if (RdoNonBpc.Checked && txtComment_NonBpc.Text.Trim().Length == 0)
                //        {
                //            MessageBox.Show("Please Enter Comment For NonBPC", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            return;
                //        }
                //        if (RdoRegular.Checked != true && RdoLaunch.Checked != true && RdoPriceChange.Checked != true && RdoArtWorkChange.Checked != true && RdoRenovation.Checked != true)
                //        {
                //            MessageBox.Show("Select Regular/Launch", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            return;
                //        }

                //        if (RdoAccepted.Checked == true)
                //        {
                //            for (int i = 0; i < dgTest.Rows[0].Cells.Count; i++)
                //            {
                //                if (dgTest.Rows[0].Cells[i].Value.ToString().Trim() != "A")
                //                {
                //                    MessageBox.Show("All test must be accepted for");
                //                    return;
                //                }
                //            }
                //            if (MessageBox.Show("ACCEPT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                //            {
                //                return;
                //            }
                //        }
                //        if (RdoRejected.Checked == true)
                //        {
                //            if (MessageBox.Show("REJECT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                //            {
                //                return;
                //            }
                //        }
                //        if (RdoAWD.Checked == true)
                //        {
                //            if (MessageBox.Show("ACCEPT WITH DERROGATION ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                //            {
                //                return;
                //            }
                //        }
                //        if (RdoTreatment.Checked == true)
                //        {
                //            if (MessageBox.Show("TREATEMENT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                //            {
                //                return;
                //            }
                //        }
                //        if (RdoHold.Checked == true)
                //        {
                //            if (MessageBox.Show("HOLD ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                //            {
                //                return;
                //            }
                //        }
                //        if (RdoRegular.Checked == true)
                //        {
                //            if (MessageBox.Show("Regular ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                //            {
                //                return;
                //            }
                //        }
                //        if (RdoLaunch.Checked == true)
                //        {
                //            if (MessageBox.Show("Launch ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                //            {
                //                return;
                //            }
                //        }
                //        if (RdoPriceChange.Checked == true)
                //        {
                //            if (MessageBox.Show("Price Change ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                //            {
                //                return;
                //            }
                //        }
                //        if (RdoArtWorkChange.Checked == true)
                //        {
                //            if (MessageBox.Show("Art Work Change ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                //            {
                //                return;
                //            }
                //        }
                //        if (RdoRenovation.Checked == true)
                //        {
                //            if (MessageBox.Show("Renovation ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                //            {
                //                return;
                //            }
                //        }
                //        //----- Commented as per Nilesh's suggestion-----------

                //        //if (RdoHold.Checked != true && FrmMain.UserType == 'N')
                //        //{
                //        //    MessageBox.Show("Sorry..\n\nYou can only HOLD the record", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        //    return;
                //        //}

                //        //Insert unit details
                //        DataSet dsUnit;
                //        for (int i = 0; i < dgKit.Rows.Count; i++)
                //        {
                //            dsUnit = new DataSet();
                //            FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                //            FinishedGoodTest_Class_Obj.packsize = Convert.ToInt32(dgKit["PackSize", i].Value);
                //            FinishedGoodTest_Class_Obj.weight = Convert.ToDouble(dgKit["Weight", i].Value);
                //            dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                //            if (dsUnit.Tables[0].Rows.Count > 0)
                //            {
                //                FinishedGoodTest_Class_Obj.Update_tblFinishedGoodUnitDetails();
                //            }
                //            else
                //            {
                //                FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodUnitDetails();
                //            }
                //        }

                //        FinishedGoodTest_Class_Obj.testdate = Convert.ToString(DtpDate.Value);

                //        if (RdoAccepted.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.status = "A";
                //        }
                //        else if (RdoHold.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.status = "H";
                //        }
                //        else if (RdoRejected.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.status = "R";
                //        }
                //        else if (RdoAWD.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.status = "A";
                //        }
                //        else if (RdoTreatment.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.status = "R";
                //        }

                //        //------Actual Status------

                //        if (RdoAccepted.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.actualstatus = "A";
                //        }
                //        else if (RdoHold.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.actualstatus = "H";
                //        }
                //        else if (RdoRejected.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.actualstatus = "R";
                //        }
                //        else if (RdoAWD.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.actualstatus = "D";
                //        }
                //        else if (RdoTreatment.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.actualstatus = "T";
                //        }

                //        FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("N/A");
                //        for (int i = 0; i < ChkReject.Items.Count; i++)
                //        {
                //            if (ChkReject.GetItemChecked(i) == true)
                //            {
                //                if (i == 0)
                //                {
                //                    FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("ZD");
                //                    break;
                //                }
                //                else if (i == 1)
                //                {
                //                    FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("ZN");
                //                    break;
                //                }
                //                else if (i == 2)
                //                {
                //                    FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Critical");
                //                    break;
                //                }
                //                else if (i == 3)
                //                {
                //                    FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Major");
                //                    break;
                //                }
                //                else if (i == 4)
                //                {
                //                    FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Minor");
                //                    break;
                //                }
                //                else if (i == 5)
                //                {
                //                    FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Bulk");
                //                    break;
                //                }
                //                else if (i == 6)
                //                {
                //                    FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Other");
                //                    break;
                //                }
                //            }
                //        }

                //        if (txtNoOfDefects.Text.Trim() != "")
                //        {
                //            FinishedGoodTest_Class_Obj.noofdefects = Convert.ToInt32(txtNoOfDefects.Text.Trim());
                //        }
                //        else
                //        {
                //            FinishedGoodTest_Class_Obj.noofdefects = 0;
                //        }

                //        if (txtNoOfSamples.Text.Trim() != "")
                //        {
                //            FinishedGoodTest_Class_Obj.noofsamples = Convert.ToInt32(txtNoOfSamples.Text.Trim());
                //        }
                //        else
                //        {
                //            FinishedGoodTest_Class_Obj.noofsamples = 0;
                //        }

                //        FinishedGoodTest_Class_Obj.Comment = txtComment.Text.Trim();
                //        if (RdoBpc.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.decision = "B";
                //            FinishedGoodTest_Class_Obj.nonbpccomment = "";
                //        }
                //        else
                //        {
                //            FinishedGoodTest_Class_Obj.decision = "N";
                //            FinishedGoodTest_Class_Obj.nonbpccomment = txtComment_NonBpc.Text;
                //        }
                //        if (RdoLaunch.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.catagory = "Launch";
                //        }
                //        else if (RdoPriceChange.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.catagory = "PriceChange";
                //        }
                //        else if (RdoArtWorkChange.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.catagory = "ArtWorkChange";
                //        }
                //        else if (RdoRenovation.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.catagory = "Renovation";
                //        }
                //        else if (RdoRegular.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.catagory = "N/A";
                //        }
                //        //this Flag describes that this is current record for this FGTLFID 
                //        //IF any record get treatmented in treatment screen then new record added in tblFinishedGoodTestDetails which is currentflag =1 
                //        //then for old record current flag is 0
                //        //If record is for treatment then set currentflag =0
                //        if (RdoTreatment.Checked == true)
                //        {
                //            FinishedGoodTest_Class_Obj.currentflag = 0;
                //        }
                //        else
                //        {
                //            FinishedGoodTest_Class_Obj.currentflag = 1;
                //        }
                //        //this flag shows the record which are under the treatment process
                //        //in transaction screen treatmentdone = 0
                //        //and treatmentdone = 1 for both old and newly added record in treatment screen                    
                //        FinishedGoodTest_Class_Obj.treatmentdone = 0;
                //        //this flag shows record which is added after treatment 
                //        //For transation screen Treatmented = 0
                //        //This flag is set for only for record which is added after treatment 
                //        //In Treatment screen Treatmented = 1
                //        //this flag is used to avoid record while deciding control type  
                //        FinishedGoodTest_Class_Obj.treatmented = 0;

                //        FinishedGoodTest_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                //        FinishedGoodTest_Class_Obj.loginid = FrmMain.LoginID;

                //        //ControlType
                //        //LNo

                //        DataSet ds1 = new DataSet();
                //        //Select FGTestNo from FGTLFID
                //        ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodDetails_FGTLFID();
                //        if (ds1.Tables[0].Rows.Count > 0)  // if exists then modify
                //        {
                //            //update fg transaction details
                //            FinishedGoodTest_Class_Obj.fgtestno = Convert.ToInt64(ds1.Tables[0].Rows[0]["FGTestNo"]);
                //            FinishedGoodTest_Class_Obj.Update_tblFinishedGoodTestDetails();
                //        }
                //        else // insert
                //        {
                //            //insert fg transaction details
                //            FinishedGoodTest_Class_Obj.fgtestno = FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodTestDetails();
                //        }


                //        //update FGDone=1  in tblFGTLF from FGTLFID 
                //        if (RdoHold.Checked != true)
                //        {
                //            FinishedGoodTest_Class_Obj.fgdone = true;
                //            FinishedGoodTest_Class_Obj.Update_tblFGTLF_FGDone();
                //        }

                //        MessageBox.Show("Record Saved Successfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        Bind_Details();
                //        BtnReset_Click(sender, e);
                //    //}
                //    //else if (icount == 1)
                //    //{
                //    //    MessageBox.Show("Sorry Validity Date Of this FGCode is Expired", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //}
                //}
                #endregion

                //============================================= CODE FOR SCOOP MANISH K ================================================//

                if (RecordExistAlready)//<----------DONT EXECUTE SAVE WHEN RECORDS ALEREADY EXISTS
                {
                    MessageBox.Show("Record saved..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;
                    BtnReset_Click(sender, e);
                    //tmr.Stop();
                    cmbDetails.SelectedIndex = 0;
                    //if (pnlTestGrid.Controls.Count > 0)
                    //{
                    //    pnlTestGrid.Controls.Clear();
                    //}
                    //dgKit.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Record saved..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BtnReset_Click(sender, e);
                    //tmr.Stop();
                    cmbDetails.SelectedIndex = 0;
                    //if (pnlTestGrid.Controls.Count > 0)
                    //{
                    //    pnlTestGrid.Controls.Clear();
                    //}
                    //dgKit.DataSource = null;
                }
                //ResetAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            if (tmr != null)
            {
                tmr.Stop();
                tmr.Dispose();
                Reset_SamplingGrid();
            }
            this.Close();
        }


        #region Funcions_ProcessScoopData

        DataSet RecordExistDs;
        public bool RecordExistAlready;

        private bool Record_Exists() //<--------------------------------------------------------------- if UPMASTER SAVED FOR THE PERTICULARE FGTLFID BEFORE
        {
            try
            {
                RecordExistAlready = false;
                RecordExistDs = new DataSet();
                UPMaster_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                if (txtLineStarTime.Text == "")
                {
                    UPMaster_Class_Obj.linestarttime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                    // LneStrtTme = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                }
                else
                {
                    UPMaster_Class_Obj.linestarttime = Convert.ToDateTime(txtLineStarTime.Text);
                    //LneStrtTme = Convert.ToDateTime(txtLineStarTime.Text);
                }

                RecordExistDs = UPMaster_Class_Obj.Select_GetSamplingPoints_tblUpTestMasterFGTLF();

                if (RecordExistDs.Tables[0].Rows.Count > 0)
                {
                    RecordExistAlready = true;
                    masterSaved = true;
                    return true;

                }
                else
                {
                    RecordExistAlready = false;
                    masterSaved = false;
                    return false;

                }

            }
            catch
            {
                RecordExistAlready = false;
                throw;
            }

        }

        public bool masterSaved = false;

        public void SaveUPMaster() //<---------------------------------------------------------------- FUNCTION TO SAVE MASTER 
        {
            try
            {
                UPMaster_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                UPMaster_Class_Obj.linestarttime = Convert.ToDateTime(txtLineStarTime.Text);
                UPMaster_Class_Obj.controlType = Convert.ToString(txtControltype.Text);
                UPMaster_Class_Obj.Insert_tblUpTestMaster();
                masterSaved = true;
            }
            catch
            {

            }
        }

        public void Save_UPTestSamplingPoint()
        {
            try
            {
                foreach (DataRow dr in tblRunningSamplingGrids.Rows)
                {
                    UC_SamplingGrid ucgrid = (UC_SamplingGrid)dr[0];
                    UPTestSamplingPoint_Class_Obj.upid = UPMaster_Class_Obj.GetLastAdded_tblUpTestMaster();
                    UPTestSamplingPoint_Class_Obj.sampleid = ucgrid.samplingPointId;
                    UPTestSamplingPoint_Class_Obj.starttime = Convert.ToDateTime(txtLineStarTime.Text);
                    UPTestSamplingPoint_Class_Obj.frequency = (int)ucgrid.frequency;
                    UPTestSamplingPoint_Class_Obj.Insert_tblUPTestSamplingPoints();
                    ucgrid.upTestSamplingId = UPTestSamplingPoint_Class_Obj.GetLastAdded_tblUPTestSamplingPoints();
                    Save_ScoopTestMethodAgainstSamplingPoint(ucgrid.upTestSamplingId, ucgrid.samplingPointId);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Save_ScoopTestMethodAgainstSamplingPoint(Int64 UPSamplingPointTestID, Int64 samplingPointId)
        {

            //SCOOPTestMethodMaster_Class_Obj.fgNo = FgCodeID;
            //SCOOPTestMethodMaster_Class_Obj.lno = LineId;
            SCOOPTestMethodMaster_Class_Obj.samplingPointId = samplingPointId;
            UPTestAtSamplingPoint_Class upTestatsamplingPoint_Obj = new UPTestAtSamplingPoint_Class();
            DataSet DsTest = SCOOPTestMethodMaster_Class_Obj.select_TestForSamplPoint_tblSCOOPtestMethodMaster();

            foreach (DataRow dr in DsTest.Tables[0].Rows)
            {
                upTestatsamplingPoint_Obj.uptestsamplingpointid = UPSamplingPointTestID;
                upTestatsamplingPoint_Obj.sCPTestMethodID = Convert.ToInt64(dr["SCPTestMethodID"]);
                upTestatsamplingPoint_Obj.Insert_tblScpTstMethod_SamplingPt_Rltn();
            }

        }

        public void Save_UPTestSamplingPoint(UC_SamplingGrid ucgrid) //<-------------------------------------- FUNCTION TO SAVE UPTESTSAMPLINGPOINT
        {
            try
            {
                UPTestSamplingPoint_Class_Obj.upid = UPMaster_Class_Obj.GetLastAdded_tblUpTestMaster();
                UPTestSamplingPoint_Class_Obj.sampleid = ucgrid.samplingPointId;
                UPTestSamplingPoint_Class_Obj.starttime = Convert.ToDateTime(txtLineStarTime.Text);
                UPTestSamplingPoint_Class_Obj.frequency = (int)ucgrid.frequency;
                UPTestSamplingPoint_Class_Obj.Insert_tblUPTestSamplingPoints();
                ucgrid.upTestSamplingId = UPTestSamplingPoint_Class_Obj.GetLastAdded_tblUPTestSamplingPoints();
                Save_ScoopTestMethodAgainstSamplingPoint(ucgrid.upTestSamplingId, ucgrid.samplingPointId);
            }
            catch
            {
                throw;
            }
        }

        private void Save_NotDoneTest(UC_SamplingGrid ucgrid)
        {
            try
            {
                if (!masterSaved)
                {
                    SaveUPMaster();
                    Save_UPTestSamplingPoint();
                }

                //SCOOPTestMethodMaster_Class_Obj.samplingPointId = ucgrid.samplingPointId;
                //DataSet ds = SCOOPTestMethodMaster_Class_Obj.select_TestForSamplPoint_tblSCOOPtestMethodMaster();
                DateTime timebrf;
                timebrf = UPMaster_Class_Obj.GetCurrentTime(); //System.DateTime.Now;
                DataGridViewRow dr = ucgrid.dgSamplingPoint.Rows[ucgrid.dgSamplingPoint.RowCount - 1];

                UPTestAtSamplingPoint_Class_obj.time = dr.Cells[0].Value.ToString().Substring(0, dr.Cells[0].Value.ToString().LastIndexOf('M') + 1); //System.DateTime.Now.ToString("t");
                UPTestAtSamplingPoint_Class_obj.expectedtime = dr.Cells[1].Value.ToString().Substring(0, dr.Cells[1].Value.ToString().LastIndexOf('M') + 1);
                UPTestAtSamplingPoint_Class_obj.timeBrief = timebrf;
                UPTestAtSamplingPoint_Class_obj.uptestsamplingpointid = ucgrid.upTestSamplingId;



                DataSet ds = UPTestAtSamplingPoint_Class_obj.Select_Select_Scoop_TEstMethods();

                foreach (DataRow dtr in ds.Tables[0].Rows)
                {
                    UPTestAtSamplingPoint_Class_obj.aqlc = 0; //Convert.ToInt32(dtr["AQLC"].ToString());
                    UPTestAtSamplingPoint_Class_obj.aqlm = 0; //Convert.ToInt32(dtr["AQLM"].ToString());
                    UPTestAtSamplingPoint_Class_obj.aqlm1 = 0; //Convert.ToInt32(dtr["AQLM1"].ToString());
                    UPTestAtSamplingPoint_Class_obj.aqlz = 0; //Convert.ToInt32(dtr["AQLZ"].ToString());
                    UPTestAtSamplingPoint_Class_obj.defect = false;
                    UPTestAtSamplingPoint_Class_obj.isLast = false;
                    UPTestAtSamplingPoint_Class_obj.notdone = true;
                    UPTestAtSamplingPoint_Class_obj.testName = dtr["TestName"].ToString();
                    UPTestAtSamplingPoint_Class_obj.testno = Convert.ToInt32(dtr["TestNo"].ToString());
                    UPTestAtSamplingPoint_Class_obj.insert_tblUPTestAtSAmplingPoint();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void StopTimers()
        {
            if (tmr != null)
            {
                tmr.Stop();
            }
            if (TimerCheckNotify != null)
            {
                TimerCheckNotify.Stop();

            }

        }

        #endregion
    }
}
