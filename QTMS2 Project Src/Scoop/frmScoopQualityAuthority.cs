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
using System.Collections;

namespace QTMS.Scoop
{
    public partial class frmScoopQualityAuthority : Form
    {
        #region variables
        DataSet DSDetails;
        Int64 FGTLFID2;
        static bool masterSaved = false;
        public bool RecordExistAlready;
        DataSet RecordExistDs;
        #endregion

        #region Class variables
        UPMaster_Class UPMaster_Class_Obj = new UPMaster_Class();
        static frmScoopQualityAuthority frmQualityAuthorityForScoop_Obj = new frmScoopQualityAuthority();
        FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new FinishedGoodTest_Class();
        UserManagement_Class UserManagement_Class_Obj = new UserManagement_Class();
        #endregion

        public frmScoopQualityAuthority()
        {
            InitializeComponent();
        }

        public static frmScoopQualityAuthority GetInstance()
        {
            if (frmQualityAuthorityForScoop_Obj == null)
            {
                frmQualityAuthorityForScoop_Obj = new frmScoopQualityAuthority();
            }
            return frmQualityAuthorityForScoop_Obj;
        }

        private void frmScoopQualityAuthority_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            Bind_Details();
           // Bind_InspectedBy();
        }

        private void Bind_Details()
        {
            if (DSDetails != null)
            {
                DSDetails.Clear();
            }
            else
            {
                DSDetails = new DataSet();
            }



            //DSDetails = UPMaster_Class_Obj.select_GetPendingDetailsForUpAuthority();
            DSDetails = FinishedGoodTest_Class_Obj.Select_PendingFinishedGoodDetailsUP();
            DataRow dr;//

            dr = DSDetails.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            dr["FGTLFID"] = "0";
            DSDetails.Tables[0].Rows.InsertAt(dr, 0);

            cmbDetails.DisplayMember = "Details";
            cmbDetails.ValueMember = "FGTLFID";
            cmbDetails.DataSource = DSDetails.Tables[0];
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                ResetAll();

                DataRow[] dR = DSDetails.Tables[0].Select("FGTLFID=" + cmbDetails.SelectedValue + "");

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
                    if (!string.IsNullOrEmpty(Convert.ToString(dR[0]["KitLineStartTime"])))
                    {
                        txtLineStarTime.Text = Convert.ToString(dR[0]["KitLineStartTime"]);    
                    }
                    else
                    {
                        return;
                    }
                    //FinishedGoodTest_Class_Obj.FGCode = dR[0]["FGCode"].ToString();
                    //FinishedGoodTest_Class_Obj.trackcode = dR[0]["TrackCodeFG"].ToString();
                    //FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dR[0]["LNoFG"].ToString());
                    //FinishedGoodTest_Class_Obj.fgno = Convert.ToInt32(dR[0]["FGNoFG"].ToString());
                    //DataSet ds=FinishedGoodTest_Class_Obj.SelectLineStartedDate();
                    //if (ds.Tables.Count>0)
                    //{
                    //    if (ds.Tables[0].Rows.Count>0)
                    //    {
                    //        txtLineStarTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["LineStartedTime"]);
                    //    }
                    //    else
                    //    {
                    //        DataSet ds2 = FinishedGoodTest_Class_Obj.SelectLineStartedDatefromFGNonadTodayDate(Convert.ToDateTime(DateTime.Now.Date.ToShortDateString()), Convert.ToDateTime(DateTime.Now.Date.AddDays(1).ToShortDateString()));
                    //        if (ds.Tables[0].Rows.Count > 0)
                    //        {
                    //            txtLineStarTime.Text = Convert.ToString(ds2.Tables[0].Rows[0]["LineStartedTime"]);
                    //        }
                    //        else
                    //        {
                    //            return;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    return;
                    //}
                    //
                }
                else
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dR[0]["LineStartedTime"].ToString())))
                    {
                        txtLineStarTime.Text = Convert.ToString(dR[0]["LineStartedTime"].ToString());    
                    }
                    else
                    {
                        return;
                    }
                }
                 */
                //txtLineStarTime.Text = dR[0]["LineStartedTime"].ToString();
                masterSaved = false;
                FGTLFID2 = Convert.ToInt64(dR[0]["FGTLFID"].ToString());

                if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "" && cmbDetails.SelectedIndex != 0)
                {

                    Bind_ExistedTEstStatus();

                    FinishedGoodTest_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                    DataSet dsFG = new DataSet();
                    dsFG = FinishedGoodTest_Class_Obj.Select_FinishedGood_FGDetails();

                    if (dsFG.Tables[0].Rows.Count > 0)//<-------------------------------------------------------------- FILL ALL THE DETAILS
                    {
                        txtFGDesc.Text = dsFG.Tables[0].Rows[0]["FGDesc"].ToString();
                        txtPkgFamily.Text = dsFG.Tables[0].Rows[0]["TechFamDesc"].ToString();
                        FinishedGoodTest_Class_Obj.fgno = Convert.ToInt64(dsFG.Tables[0].Rows[0]["FGNo"]);
                        FinishedGoodTest_Class_Obj.pkgtechno = Convert.ToInt64(dsFG.Tables[0].Rows[0]["PKGTechNo"]);
                        FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dsFG.Tables[0].Rows[0]["LNoFG"]);
                        txtControltype.Text = FinishedGoodTest_Class_Obj.Decide_ControlType_FG();
                        if (dsFG.Tables[0].Rows[0]["VersionNo"] is System.DBNull)
                        {
                            FinishedGoodTest_Class_Obj.versionno = "";
                        }
                        else
                        {
                            FinishedGoodTest_Class_Obj.versionno = dsFG.Tables[0].Rows[0]["VersionNo"].ToString();
                        }

                    }
                    if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "0")
                    {
                        if (cmbDetails.SelectedValue != DBNull.Value)
                        {
                            DataSet dsPkg = FinishedGoodTest_Class_Obj.STP_SELECT_FGNo_FMID_PkgSamp();
                        }
                    }
                    DataSet dsPkgBulk = new DataSet();
                    dsPkgBulk = FinishedGoodTest_Class_Obj.Select_FinishedGood_PackingBulkTestDetails();

                    for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)//<------------------------------------------- LOAD GRID OF DETAILS
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
                    //---------Code for Display Comment from Up Authority--------------------///
                    // Pandurang Kumbhar 2013-Jul-22 
                    if (!string.IsNullOrEmpty(txtLineStarTime.Text))
                    {
                        UPMaster_Class UPMaster_Class_Obj = new UPMaster_Class();
                        UPMaster_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                        UPMaster_Class_Obj.linestarttime = Convert.ToDateTime(txtLineStarTime.Text);
                        DataSet DS_UPTestRecord = UPMaster_Class_Obj.Select_UPMaster();
                        if (DS_UPTestRecord.Tables[0].Rows.Count > 0)
                        {
                            long UPId = Convert.ToInt64(DS_UPTestRecord.Tables[0].Rows[0]["UPID"].ToString());
                            if (DS_UPTestRecord.Tables[0].Rows[0]["UPAuthorityStatus"] == DBNull.Value)
                            {
                                lblUPAuthorityStatus.Text = "Not given yet";
                                lblUPAuthorityStatus.ForeColor = Color.Red;
                            }
                            else if (DS_UPTestRecord.Tables[0].Rows[0]["UPAuthorityStatus"].ToString() == "H")
                            {
                                lblUPAuthorityStatus.Text = "Hold";
                                lblUPAuthorityStatus.ForeColor = Color.Red;
                            }
                            else if (DS_UPTestRecord.Tables[0].Rows[0]["UPAuthorityStatus"].ToString() == "R")
                            {
                                lblUPAuthorityStatus.Text = "Rejected";
                                lblUPAuthorityStatus.ForeColor = Color.Red;
                            }
                            else
                            {
                                lblUPAuthorityStatus.Text = "Accepted";
                                lblUPAuthorityStatus.ForeColor = Color.Red;
                            }
                            if (DS_UPTestRecord.Tables[0].Rows[0]["UPAuthorityComment"] != DBNull.Value)
                            {
                                txtUPAuthoritycomment.Text = DS_UPTestRecord.Tables[0].Rows[0]["UPAuthorityComment"].ToString();
                            }
                        }
                    }                    

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
                    if (!string.IsNullOrEmpty(txtLineStarTime.Text))
                    {
                        Get_SamplingGrids();    
                    }
                    else
                    {
                        return;
                    }

                }

            }
            catch
            {
                MessageBox.Show("There is no record");

            }
        }

        DataSet DSgridrow = new DataSet();

        UPTestAtSamplingPoint_Class UPTestAtSamplingPoint_Class_obj = new UPTestAtSamplingPoint_Class();
        UPTestSamplingPoint_Class UPTestSamplingPoint_Class_Obj = new UPTestSamplingPoint_Class();
        SCOOPTestMethodMaster_Class SCOOPTestMethodMaster_Class_Obj = new SCOOPTestMethodMaster_Class();
        DataSet DSfgtlFGLne;
        Hashtable indexGridDefectTbl = new Hashtable();

        DataTable tblDefectCount;
        DataTable tblRunningSamplingGrids =null;// new DataTable();

        private void Get_SamplingGrids()
        {
            if (DSfgtlFGLne != null) //<-------------- DSfgtlFGLine DATASET
            {
                DSfgtlFGLne.Clear();
            }
            else
            {
                DSfgtlFGLne = new DataSet();
            }
            if (tblDefectCount != null)
            {
                tblDefectCount.Clear();
            }
            else
            {
                tblDefectCount = new DataTable();

            }
            if (tblRunningSamplingGrids == null)
            {
                tblRunningSamplingGrids = new DataTable();
                tblRunningSamplingGrids.Columns.Add("UC_Grid", typeof(UC_SamplingGrid));
            }
            FinishedGoodTest_Class_Obj.fgtlfid = FGTLFID2;
            DSfgtlFGLne = FinishedGoodTest_Class_Obj.Select_selectFgLine_tblFGTLF();

            SCOOPTestMethodMaster_Class_Obj.fgNo = Convert.ToInt64(DSfgtlFGLne.Tables[0].Rows[0]["FGNoFG"].ToString());
            SCOOPTestMethodMaster_Class_Obj.lno = Convert.ToInt32(DSfgtlFGLne.Tables[0].Rows[0]["LNoFG"].ToString());

            int left = pnlTestGrid.Left + 5;
            
            if (Record_Exists())
            {
               
                foreach (DataRow dr in RecordExistDs.Tables[0].Rows) //<-------------------------- RECORD EXIST DS CONTAINS ALL THE SAVED SAMPLING POINTS FOR THE DETAILS
                {

                    //---create sampling test grid(user control)----//
                    
                    UC_SamplingGrid uc_grid = new UC_SamplingGrid(this,Convert.ToDateTime(txtLineStarTime.Text));

                    //----set properties--------------------------//
                    uc_grid.samplingPoint = dr["SamplingPointName"].ToString();
                    uc_grid.frequency = Convert.ToInt32(dr["Frequency"].ToString());
                    uc_grid.samplingPointId = Convert.ToInt64(dr["SampleID"].ToString());
                    uc_grid.upTestSamplingId = Convert.ToInt64(dr["UPSamplingPontTestID"].ToString());

                    //------------- set location ---------------//
                    uc_grid.Top = 0;
                    uc_grid.Left = left;
                    left = uc_grid.Right + 5;

                    pnlTestGrid.Controls.Add(uc_grid);
                    tblRunningSamplingGrids.Rows.Add(uc_grid);


                    int Zcount = 0, Ccount = 0, Mcount = 0, M1count = 0;
                    UPTestAtSamplingPoint_Class_obj.uptestsamplingpointid = Convert.ToInt64(dr["UPSamplingPontTestID"].ToString());
                    tblDefectCount = UPTestAtSamplingPoint_Class_obj.Get_DEfectCount2().Tables[0];// UPTestSamplingPoint_Class_Obj.Get_DefectCount();
                    foreach (DataRow drdfct in tblDefectCount.Rows)
                    {
                        Zcount += (int)drdfct["AQLZMx"];
                        Ccount += (int)drdfct["AQLCMx"];
                        Mcount += (int)drdfct["AQLMMx"];
                        M1count += (int)drdfct["AQLM1Mx"];

                    }
                    uc_grid.setDefectCount(0, Zcount.ToString());
                    uc_grid.setDefectCount(1, Ccount.ToString());
                    uc_grid.setDefectCount(2, Mcount.ToString());
                    uc_grid.setDefectCount(3, M1count.ToString());

                    if (DSgridrow != null) //<--------------------------------------------------------------------------- DSgridrow CONTAINS ROWS FOR THE THAT SAMPLING GRIDS
                    {
                        DSgridrow.Clear();
                    }
                    UPTestAtSamplingPoint_Class_obj.uptestsamplingpointid = Convert.ToInt64(dr["UPSamplingPontTestID"].ToString());
                    DSgridrow = UPTestAtSamplingPoint_Class_obj.Select_SelectSamplingRow_tblUPTestAtSAmplingPoint();

                    if (DSgridrow.Tables[0].Rows.Count == 0)
                    {

                    }
                    #region Bind Sampling Grid 
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
                    #endregion

                    // Check IsLast was true or false if true then display groupbox3 otherwise hide it
                    // Pandurang Kumbhar 2013-Jul-22
                    if (UPTestAtSamplingPoint_Class_obj.CheckIsLastWasDone()==0)
                    {
                        BtnSave.Visible = false;
                        groupBox3.Visible = false;
                        //groupBox8.Visible = false;
                    }
                    else
                    {
                        BtnSave.Visible = true;
                        groupBox3.Visible = true;
                        //groupBox3.Visible = true;
                    }
                }

            }
        }

        //private void dg_CellMouseDoubleClick(object o, DataGridViewCellMouseEventArgs e)
        //{

        //    DataGridView d = new DataGridView();
        //    d = (DataGridView)o;

        //    //<===== CODE TO CHECK IF RECORD EXIST IN DATABSE ======>// 

        //    if (e.RowIndex < 0)
        //    {
        //        return;
        //    }
        //    if (RecordExistAlready && !d.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("NotDone"))
        //    {
        //        frmScoopUPTest frm = new frmScoopUPTest(this, d);
        //        frm.recordExistsAlready = true;
        //        frm.chkLastSample.Enabled = true;
        //        if (d.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Last"))
        //        {
        //            frm.chkLastSample.Checked = true;
        //            frm.chkLastSample.Enabled = false;
        //        }
        //        if (d.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Defect"))
        //        {
        //            frm.lblCheckBox.Visible = false;
        //            frm.chkLastSample.Visible = false;

        //            frm.chkContinuetest.Font = new Font("Verdana", 12, FontStyle.Bold);
        //            frm.chkContinuetest.ForeColor = Color.OrangeRed;
        //            frm.chkContinuetest.Visible = true;
        //        }
        //        frm.UPSamplingPontTestID = Convert.ToInt64(d.Tag.ToString());
        //        frm.time = d.Rows[e.RowIndex].Cells[0].Value.ToString().Substring(0, d.Rows[e.RowIndex].Cells[0].Value.ToString().LastIndexOf('M') + 1);
        //        frm.actualTimeOfSampling = d.Rows[e.RowIndex].Cells[1].Value.ToString();
        //        frm.timeBreif = Convert.ToDateTime(d.Rows[e.RowIndex].Tag.ToString());
        //        frm.chkLastSample.Enabled = false;
        //        frm.ShowDialog();
        //        return;
        //    }
        //    if (d.Rows[e.RowIndex].Cells[0].ReadOnly && d.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("NotDone"))//<--***************************
        //    {

        //        frmScoopTestNotDoneDetail frm = new frmScoopTestNotDoneDetail();
        //        frm.UPSamplingPontTestID = Convert.ToInt64(d.Tag.ToString());
        //        frm.time = d.Rows[e.RowIndex].Cells[0].Value.ToString().Substring(0, d.Rows[e.RowIndex].Cells[0].Value.ToString().LastIndexOf('M') + 1);
        //        frm.ExpectedTime = d.Rows[e.RowIndex].Cells[1].Value.ToString();
        //        frm.ShowDialog();
        //        return;

        //    }

        //}


        private void ResetAll()
        {
            if (dgKit.RowCount > 0)
            {
                dgKit.Rows.Clear();
            }
            this.pnlTestGrid.Controls.Clear();
            txtFGDesc.Text = "";
            txtPkgFamily.Text = "";
            txtControltype.Text = "";
            txtComment.Text = "";
            RdoAccepted.Checked = true;
            lblUPAuthorityStatus.Text = String.Empty;
            txtUPAuthoritycomment.Text = String.Empty;
            
           // cmbInspectedBy.SelectedValue = 0;

        }

        private bool Record_Exists()
        {
            try
            {
                RecordExistAlready = false;
                RecordExistDs = new DataSet();
                UPMaster_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                if (txtLineStarTime.Text == "")
                {
                    UPMaster_Class_Obj.linestarttime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
                }
                else
                {
                    UPMaster_Class_Obj.linestarttime = Convert.ToDateTime(txtLineStarTime.Text);
                }
                RecordExistDs = UPMaster_Class_Obj.Select_GetSamplingPoints_tblUpTestMasterFGTLF();

                if (RecordExistDs.Tables[0].Rows.Count > 0)
                {
                    RecordExistAlready = true;
                    return true;

                }
                else
                {
                    RecordExistAlready = false;
                    return false;

                }

            }
            catch
            {
                RecordExistAlready = false;
                throw;
            }

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {

            txtFGDesc.Text = "";
            txtPkgFamily.Text = "";
            txtControltype.Text = "";
            cmbDetails.SelectedIndex = 0;
            txtLineStarTime.Text = "";
            cmbDetails.Focus();
            dgKit.Rows.Clear();
            txtUPAuthoritycomment.Text = String.Empty;
            txtComment.Text = String.Empty;
            this.pnlTestGrid.Controls.Clear();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("please select Details", "Message");
                    return;
                }
             
                if (RdoRejected.Checked == true)
                {
                    if (MessageBox.Show("REJECT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoHold.Checked == true)
                {
                    if (MessageBox.Show("HOLD ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }

                if (RdoAccepted.Checked == true)
                {
                    UPMaster_Class_Obj.qualityAuthorityStatus = 'A';
                }
                else if (RdoHold.Checked == true)
                {
                    UPMaster_Class_Obj.qualityAuthorityStatus = 'H';
                }
                else if (RdoRejected.Checked == true)
                {
                    UPMaster_Class_Obj.qualityAuthorityStatus = 'R';
                }

                UPMaster_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                UPMaster_Class_Obj.linestarttime = Convert.ToDateTime(txtLineStarTime.Text);
                UPMaster_Class_Obj.qualityauthorityComment = txtComment.Text;
                UPMaster_Class_Obj.qualityauthorityInspectedById = Convert.ToInt32(GlobalVariables.uid); //Convert.ToInt32(cmbInspectedBy.SelectedValue.ToString());
                bool b = UPMaster_Class_Obj.Update_QualityAuthority();
                if (b)
                {
                    MessageBox.Show("Record saved", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                BtnReset_Click(sender, e);

            }
            catch
            {
                throw;
            }

        }


        private void Bind_ExistedTEstStatus()
        {

            DataSet ds = new DataSet();
            UPMaster_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
            if (txtLineStarTime.Text == "")
            {
                UPMaster_Class_Obj.linestarttime = Convert.ToDateTime("1/1/1753 12:00:00 AM");
            }
            else
            {
                UPMaster_Class_Obj.linestarttime = Convert.ToDateTime(txtLineStarTime.Text);
            }
            ds = UPMaster_Class_Obj.Select_QualityAuthority();
            if (ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            if (ds.Tables[0].Rows[0]["QualityAuthorityComment"] != DBNull.Value)
            {
                txtComment.Text = ds.Tables[0].Rows[0]["QualityAuthorityComment"].ToString();
            }
        
            if (ds.Tables[0].Rows[0]["QualityAuthorityStatus"] != DBNull.Value)
            {
                if (ds.Tables[0].Rows[0]["QualityAuthorityStatus"].ToString() == "A")
                {
                    RdoAccepted.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["QualityAuthorityStatus"].ToString() == "H")
                {
                    RdoHold.Checked = true;
                }
                if (ds.Tables[0].Rows[0]["QualityAuthorityStatus"].ToString() == "R")
                {
                    RdoRejected.Checked = true;
                }

            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      
    }
}
