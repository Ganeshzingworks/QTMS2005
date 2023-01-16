using System;
using System.Collections.Generic;
using System.Collections;
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
using BusinessFacade.Scoop_Class;
using QTMS.U_Control;
using QTMS.Transactions;

namespace QTMS.Scoop
{
    public partial class frmScoopUPTest : Form
    {
        #region Variable


        public string time, actualTimeOfSampling;

        public int LineId;
        public Int64 FgCodeID, samplingPointId;
        public string SamplingPoint;
        public Int64 UPSamplingPontTestID;
        public DateTime timeBreif;
        // Int64 UPTestAtSamplingPointID;

        DataSet DsTest;
        public DataGridView dgtemp, dgdefectcnt;
        public int rowindex;
        public int index;
        public bool recordExistsAlready = false;

        public bool Defect = false; //<------------------------------------------------  TO CHECK IF DEFECT OCCURD 
        public bool prePending = false; //<--------------------------------------------  TO CHECKIF PRIVIOUS TEST IS PENDING
        public bool UPTestAtSamplingPointSaved = false; //<----------------------------  TO CHECKIF DATA SAVED ONCE  
        public bool newAddedToExisting = false; //<------------------------------------  TO CHECK IF ROW STARTED TO ADD INEXISTING RECORD IN SAMPLING GRIDS
        // enum DefectCountGridIndex {AQLZ,AQLC,AQLM,AQLM1}
        #endregion

        #region SCOOP VARIAVBLE

        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        UPTestAtSamplingPoint_Class UPTestAtSamplingPoint_Class_Obj = new UPTestAtSamplingPoint_Class();
        UPTestAtSamplingPoint_Class UPTestAtSamplingPoint_Class_Obj1 = new UPTestAtSamplingPoint_Class();
        UPTestSamplingPoint_Class UpTstSamplPnt_Obj = new UPTestSamplingPoint_Class();
        SCOOPTestMethodMaster_Class SCOOPTestMethodMaster_Class_Obj = new SCOOPTestMethodMaster_Class();
        public FrmScoopUP up_here_Obj;
        UPdefect_Class UPdefect_Class_Obj;
        frmScoopUPAuthority frmScoopUPAuthority_hare_Obj;
        frmScoopQualityAuthority frmScoopQualityAuthority_Here_Obj; UPMaster_Class UpMaster_Class_Obj = new UPMaster_Class();

        UC_SamplingGrid uc_Grid;
        #endregion

        //<=========================== CONSTRUCTOR =========================>//
        #region Constructor

        public frmScoopUPTest(FrmScoopUP frm, UC_SamplingGrid ucgrid)
        {
            InitializeComponent();
            up_here_Obj = frm;
            uc_Grid = ucgrid;
        }

        public frmScoopUPTest(frmScoopUPAuthority frm, UC_SamplingGrid ucgrid)
        {
            InitializeComponent();
            frmScoopUPAuthority_hare_Obj = frm;
            uc_Grid = ucgrid;
        }

        public frmScoopUPTest(frmScoopQualityAuthority frm, UC_SamplingGrid ucgrid)
        {
            InitializeComponent();
            frmScoopQualityAuthority_Here_Obj = frm;
            uc_Grid = ucgrid;
        }

        #region CONSTRUCTORE FOR LIST
        //public frmScoopUPTest(FrmScoopUP frm, List<UPTestAtSamplingPoint_Class> CachObjLst, DataGridView dg)
        // {
        //     InitializeComponent();
        //     up_here_Obj = frm;
        //     dgtemp = dg;
        //    CachObjListHere=CachObjLst;
        // }
        #endregion
        //<===================================================================>//
        #endregion

        public List<UPdefect_Class> list_UpDefect_Obj = new List<UPdefect_Class>();

        List<int> LstDefaultAql = new List<int>();
        List<int> LstDefaultAqlC = new List<int>();
        List<int> LstDefultAqlZ = new List<int>();
        List<int> LstDefaultAqlM = new List<int>();
        List<int> LstDefaultAqlM1 = new List<int>();

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScoopUPAuthorizationFirst_Load(object sender, EventArgs e)
        {
            try
            {
                Painter.Paint(this);
                txtTime.Text = time;
                txtActualTimeOfSamplingPoint.Text = actualTimeOfSampling;
                Load_Grid();
                //chkContinuetest.Visible = false;

                if (frmScoopUPAuthority_hare_Obj != null || frmScoopQualityAuthority_Here_Obj != null)
                {
                    btnSave.Text = "Approved";
                    if (chkLastSample.Checked == true)
                        lnkresume.Visible = true;
                }
            }
            catch
            {

            }
        }

        private void Load_Grid()
        {
            try
            {

                if (DsTest == null)
                {
                    DsTest = new DataSet();
                }
                else
                {
                    DsTest.Clear();
                }

                #region CODE FOR LIST
                //if (CachObjListHere.Count > 0)//<======================== CODE TO CHECK IF DATA IS IN CACH AND LOAD GRID ===========>
                //{
                //    string def = "";
                //    foreach (UPTestAtSamplingPoint_Class obj in CachObjListHere)
                //    {
                //        def = obj.defect ? "Yes" : "No";
                //        dgvTest.Rows.Add(obj.testName, obj.testno, obj.aqlz, obj.aqlc, obj.aqlm, obj.aqlm1, def);
                //        dgvTest.Rows[dgvTest.RowCount - 1].Tag = obj.uptestAtsamplingPointId;
                //        txtActualTimeOfSamplingPoint.Text = obj.expectedtime;
                //        txtTime.Text = obj.time;
                //    }
                //    if (dgtemp.Rows[rowindex].Cells[0].Value.ToString().Contains("Last"))
                //    {
                //        chkLastSample.Checked = true;
                //    }
                //    return;
                //}
                #endregion

                if (recordExistsAlready)//&& !newAddedToExisting)//<======================== IF RECORDS EXISTS IN DATABSE ================================>     
                {
                    UPTestAtSamplingPoint_Class_Obj1.time = time;
                    UPTestAtSamplingPoint_Class_Obj1.uptestsamplingpointid = UPSamplingPontTestID;
                    UPTestAtSamplingPoint_Class_Obj1.expectedtime = actualTimeOfSampling;
                    UPTestAtSamplingPoint_Class_Obj1.timeBrief = timeBreif;

                    txtActualTimeOfSamplingPoint.Text = actualTimeOfSampling;
                    DsTest = UPTestAtSamplingPoint_Class_Obj1.Select_tblUPTestAtSAmplingPointByTime();
                    string def = "No";
                    foreach (DataRow dr in DsTest.Tables[0].Rows)
                    {
                        if (dr["Defect"].ToString().Contains("Defect"))
                        {
                            def = "Yes";
                        }
                        else
                        {
                            def = "No";
                        }
                        dgvTest.Rows.Add(dr["Status"].ToString(), dr["AnalysisType"].ToString(), dr["TestName"].ToString(), dr["TestNo"].ToString(), dr["AQL"].ToString(),
                        dr["AQLZ"].ToString(), dr["AQLC"].ToString(), dr["AQLM"].ToString(), dr["AQLM1"].ToString(), def, dr["Normal"].ToString(),
                        dr["Reinforce"].ToString(), dr["MTID"].ToString(), "", dr["TorqueMin"].ToString(), dr["TorqueMax"].ToString());
                        //dr["WATransID"].ToString()
                        //dgvTest.Rows.Add(dr["TestName"].ToString(), dr["TestNo"].ToString(), dr["AQL"].ToString(),dr["AQLZ"].ToString(), dr["AQLC"].ToString(), dr["AQLM"].ToString(), dr["AQLM1"].ToString(), def);
                        dgvTest.Rows[dgvTest.RowCount - 1].Tag = dr["UPTestAtSamplingPointID"].ToString();
                        dgvTest.Rows[dgvTest.RowCount - 1].ReadOnly = true;
                    }
                    if (frmScoopUPAuthority_hare_Obj != null && DsTest.Tables[0].Rows[0]["upAuthorityRemark"] != DBNull.Value)
                    {
                        chkContinuetest.Checked = Convert.ToBoolean(DsTest.Tables[0].Rows[0]["upAuthorityRemark"].ToString());
                        if (chkContinuetest.Checked)
                        {
                            chkContinuetest.Enabled = false;
                        }
                    }
                    if (frmScoopQualityAuthority_Here_Obj != null && DsTest.Tables[0].Rows[0]["QualityAuthorityRemark"] != DBNull.Value)
                    {
                        chkContinuetest.Checked = Convert.ToBoolean(DsTest.Tables[0].Rows[0]["QualityAuthorityRemark"].ToString());
                        if (chkContinuetest.Checked)
                        {
                            chkContinuetest.Enabled = false;
                        }
                    }

                    if (DsTest.Tables[0].Rows[0]["AnalysisType"].ToString() == "")
                    {
                        for (int a1 = 0; a1 < dgvTest.Rows.Count ; a1++)
                        {
                            dgvTest.Rows[a1].Cells["WA"].ReadOnly = true;
                            dgvTest.Rows[a1].Cells["AnalysisType"].ReadOnly = true;

                        }
                    }

                    #region Avinash 22-07-2014
                    for (int a = 0; a < DsTest.Tables[0].Rows.Count; a++)
                    {
                        if (Convert.ToBoolean(DsTest.Tables[0].Rows[a]["Defect"].ToString()) == true)
                        {
                            lblUPStatus.Visible = true;
                            lblUPAuthority.Visible = true;
                            lblQualityStatus.Visible = true;
                            lblQualityAuthority.Visible = true;
                            if (Convert.ToBoolean(DsTest.Tables[0].Rows[0]["upAuthorityRemark"].ToString()) == true)
                            {
                                lblUPStatus.Text = "Done";
                                lblUPStatus.ForeColor = Color.Green;
                            }
                            else
                            {
                                lblUPStatus.Text = "Not Done";
                                lblUPStatus.ForeColor = Color.Red;
                            }
                            if (Convert.ToBoolean(DsTest.Tables[0].Rows[0]["QualityAuthorityRemark"].ToString()) == true)
                            {
                                lblQualityStatus.Text = "Done";
                                lblQualityStatus.ForeColor = Color.Green;
                            }
                            else
                            {
                                lblQualityStatus.Text = "Not Done";
                                lblQualityStatus.ForeColor = Color.Red;
                            }
                            return;
                        }
                        else
                        {
                            lblUPStatus.Visible = false;
                            lblUPAuthority.Visible = false;
                            lblQualityStatus.Visible = false;
                            lblQualityAuthority.Visible = false;
                        }
                    }
                    #endregion
                }
                else //============================================= IF RECORD NOT IN DATABSE  ========================================>
                {

                    UPTestAtSamplingPoint_Class upTestAtSamplingPoint_Obj = new UPTestAtSamplingPoint_Class();
                    upTestAtSamplingPoint_Obj.uptestsamplingpointid = UPSamplingPontTestID;
                    DsTest = upTestAtSamplingPoint_Obj.Select_Select_Scoop_TEstMethods();

                    //SCOOPTestMethodMaster_Class_Obj.fgNo = FgCodeID;
                    //SCOOPTestMethodMaster_Class_Obj.lno = LineId;
                    //SCOOPTestMethodMaster_Class_Obj.samplingPointId = samplingPointId;
                    //DsTest = SCOOPTestMethodMaster_Class_Obj.select_TestForSamplPoint_tblSCOOPtestMethodMaster();

                    foreach (DataRow dr in DsTest.Tables[0].Rows)
                    {
                        dgvTest.Rows.Add(dr["Status"].ToString(), dr["AnalysisType"].ToString(), dr["TestName"].ToString(), dr["TestNo"].ToString(), 0, 0, 0, 0, 0, "No",
                                        dr["Normal"].ToString(), dr["Reinforce"].ToString(), dr["MTID"].ToString(), "", dr["TorqueMin"].ToString(), dr["TorqueMax"].ToString());
                        //dr["WATransID"].ToString()
                        dgvTest.Rows[dgvTest.RowCount - 1].Cells["AQL"].Tag = Convert.ToInt32(dr["AQL"].ToString());
                        dgvTest.Rows[dgvTest.RowCount - 1].Cells["AQLC"].Tag = Convert.ToInt32(dr["AQLC"].ToString());
                        dgvTest.Rows[dgvTest.RowCount - 1].Cells["AQLZ"].Tag = Convert.ToInt32(dr["AQLZ"].ToString());
                        dgvTest.Rows[dgvTest.RowCount - 1].Cells["AQLM"].Tag = Convert.ToInt32(dr["AQLM"].ToString());
                        dgvTest.Rows[dgvTest.RowCount - 1].Cells["AQLM1"].Tag = Convert.ToInt32(dr["AQLM1"].ToString());

                        //Commit by Avinash S
                        //dgvTest.Rows[dgvTest.RowCount - 1].Cells[2].Tag = Convert.ToInt32(dr["AQL"].ToString());
                        //dgvTest.Rows[dgvTest.RowCount - 1].Cells[3].Tag = Convert.ToInt32(dr["AQLC"].ToString());
                        //dgvTest.Rows[dgvTest.RowCount - 1].Cells[4].Tag = Convert.ToInt32(dr["AQLZ"].ToString());
                        //dgvTest.Rows[dgvTest.RowCount - 1].Cells[5].Tag = Convert.ToInt32(dr["AQLM"].ToString());
                        //dgvTest.Rows[dgvTest.RowCount - 1].Cells[6].Tag = Convert.ToInt32(dr["AQLM1"].ToString());
                    }

                    /*if (DsTest.Tables[0].Rows[0]["AnalysisType"].ToString() == "")
                    {
                        for (int a1 = 0; a1 < dgvTest.Rows.Count ; a1++)
                        {
                            dgvTest.Rows[a1].Cells["WA"].ReadOnly = true;
                            dgvTest.Rows[a1].Cells["AnalysisType"].ReadOnly = true;

                        }
                    }*/

                    #region Avinash 22-07-2014

                    lblUPStatus.Visible = false;
                    lblUPAuthority.Visible = false;
                    lblQualityStatus.Visible = false;
                    lblQualityAuthority.Visible = false;

                    #endregion
                }
            }
            catch
            {
                throw;
            }
        }

        int CellPreVal;

        private void dgvTest_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (dgvTest.CurrentCell.OwningColumn.Name == "WA" || dgvTest.CurrentCell.OwningColumn.Name == "AnalysisType")
                    return;
                if (dgvTest.CurrentCell.OwningColumn.Name != "Test")
                {
                    CellPreVal = Convert.ToInt32(dgvTest.CurrentCell.Tag.ToString());
                }
            }
            catch (Exception ex)
            { }
        }

        public bool canceled = false; bool valid = false;

        private void dgvTest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region CODE FOR LIST(MASTER FIRSDT AND THEN SLAVE CONCEPT)
                //if (CachObjListHere.Count > 0)
                //{
                //    CheckExistsinCach_DefectObj(dgvTest.CurrentCell);
                //    if (!CheckExistsinCach_Defect && Convert.ToInt32(dgvTest.CurrentCell.Value.ToString()) > CellPreVal)
                //    {
                //        frmUPDefect frm = new frmUPDefect(this);
                //        frm.UPTestAtSamplingPointID = Convert.ToInt64(dgvTest.CurrentRow.Tag.ToString());
                //        frm.rowindex = dgvTest.CurrentRow.Index;
                //        frm.RecordExistinCach_UPTestAtSamplingPoint = true;
                //        frm.RecordExistinCach_Defect = false;
                //        frm.AQLlevel = dgvTest.CurrentCell.OwningColumn.Name;
                //        frm.ShowDialog();
                //        if (canceled)
                //        {
                //            dgvTest.CurrentCell.Value = CellPreVal;
                //        }
                //        else
                //        {
                //            dgvTest.CurrentCell.Style.BackColor = Color.Gray;
                //        }
                //        return;
                //    }

                //    return;
                //}

                #endregion

                if (dgvTest.CurrentCell.OwningColumn.Name == "WA" || dgvTest.CurrentCell.OwningColumn.Name == "AnalysisType")
                    return;

                if (dgvTest.CurrentCell.Value == null)
                {
                    dgvTest.CurrentCell.Value = CellPreVal;
                    return;
                }
                if (valid && !recordExistsAlready)
                {
                    if (dgvTest.CurrentCell.OwningColumn.Name != "AQLM1")
                    {

                        if (Convert.ToInt32(dgvTest.CurrentCell.Value.ToString()) > CellPreVal)
                        {

                            frmUPDefect frm = new frmUPDefect(this);

                            frm.rowindex = dgvTest.CurrentRow.Index;
                            frm.AQLlevel = dgvTest.CurrentCell.OwningColumn.Name;
                            frm.UPTestAtsamplingpointSaved = UPTestAtSamplingPointSaved;
                            frm.ShowDialog();

                            if (canceled)
                            {
                                dgvTest.CurrentCell.Value = CellPreVal;
                            }
                            else
                            {
                                dgvTest.CurrentCell.Style.BackColor = Color.AliceBlue;
                                dgvTest.CurrentCell.ReadOnly = true;
                                if (UPTestAtSamplingPointSaved)
                                {
                                    Update_UPTestAtSamplingpoint(dgvTest.Rows[e.RowIndex]);
                                }
                            }
                        }
                    }
                    else
                    {
                        frmUPDefect frm = new frmUPDefect(this);

                        frm.rowindex = dgvTest.CurrentRow.Index;
                        frm.AQLlevel = dgvTest.CurrentCell.OwningColumn.Name;
                        frm.UPTestAtsamplingpointSaved = UPTestAtSamplingPointSaved;
                        frm.ShowDialog();

                        if (canceled)
                        {
                           // dgvTest.CurrentCell.Value = CellPreVal;
                        }
                        else
                        {
                            dgvTest.CurrentCell.Style.BackColor = Color.AliceBlue;
                            dgvTest.CurrentCell.ReadOnly = true;
                            if (UPTestAtSamplingPointSaved)
                            {
                                Update_UPTestAtSamplingpoint(dgvTest.Rows[e.RowIndex]);
                            }
                        }
                    }
                }
                if (recordExistsAlready && newAddedToExisting)
                {
                    if (dgvTest.CurrentCell.OwningColumn.Name != "AQLM1")
                    {

                        if (Convert.ToInt32(dgvTest.CurrentCell.Value.ToString()) > CellPreVal)
                        {

                            frmUPDefect frm = new frmUPDefect(this);

                            frm.rowindex = dgvTest.CurrentRow.Index;
                            frm.AQLlevel = dgvTest.CurrentCell.OwningColumn.Name;
                            frm.UPTestAtsamplingpointSaved = UPTestAtSamplingPointSaved;
                            frm.ShowDialog();

                            if (canceled)
                            {
                                dgvTest.CurrentCell.Value = CellPreVal;
                            }
                            else
                            {
                                dgvTest.CurrentCell.Style.BackColor = Color.AliceBlue;
                                dgvTest.CurrentCell.ReadOnly = true;
                                if (UPTestAtSamplingPointSaved)
                                {
                                    Update_UPTestAtSamplingpoint(dgvTest.Rows[e.RowIndex]);
                                }
                            }
                        }
                    }
                    else
                    {
                        frmUPDefect frm = new frmUPDefect(this);

                        frm.rowindex = dgvTest.CurrentRow.Index;
                        frm.AQLlevel = dgvTest.CurrentCell.OwningColumn.Name;
                        frm.UPTestAtsamplingpointSaved = UPTestAtSamplingPointSaved;
                        frm.ShowDialog();

                        if (canceled)
                        {
                            //dgvTest.CurrentCell.Value = CellPreVal;
                        }
                        else
                        {
                            dgvTest.CurrentCell.Style.BackColor = Color.AliceBlue;
                            dgvTest.CurrentCell.ReadOnly = true;
                            if (UPTestAtSamplingPointSaved)
                            {
                                Update_UPTestAtSamplingpoint(dgvTest.Rows[e.RowIndex]);
                            }
                        }
                    }

                }
                int index = dgvTest.CurrentRow.Index;
                if (dgvTest.CurrentCell.OwningColumn.Name == "AQL")
                {
                    if (dgvTest.CurrentCell.Value.ToString() != "0")
                    {
                        dgvTest.Rows[index].Cells["AQLZ"].ReadOnly = true;
                        dgvTest.Rows[index].Cells["AQLC"].ReadOnly = true;
                        dgvTest.Rows[index].Cells["AQLM"].ReadOnly = true;
                        dgvTest.Rows[index].Cells["AQLM1"].ReadOnly = true;

                        dgvTest.Rows[index].Cells["AQLZ"].Style.BackColor = System.Drawing.Color.Gray;
                        dgvTest.Rows[index].Cells["AQLC"].Style.BackColor = System.Drawing.Color.Gray;
                        dgvTest.Rows[index].Cells["AQLM"].Style.BackColor = System.Drawing.Color.Gray;
                        dgvTest.Rows[index].Cells["AQLM1"].Style.BackColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        dgvTest.Rows[index].Cells["AQLZ"].ReadOnly = false;
                        dgvTest.Rows[index].Cells["AQLC"].ReadOnly = false;
                        dgvTest.Rows[index].Cells["AQLM"].ReadOnly = false;
                        dgvTest.Rows[index].Cells["AQLM1"].ReadOnly = false;

                        dgvTest.Rows[index].Cells["AQLZ"].Style.BackColor = System.Drawing.Color.White;
                        dgvTest.Rows[index].Cells["AQLC"].Style.BackColor = System.Drawing.Color.White;
                        dgvTest.Rows[index].Cells["AQLM"].Style.BackColor = System.Drawing.Color.White;
                        dgvTest.Rows[index].Cells["AQLM1"].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
            catch
            {

            }
        }

        bool eventcreated = false;

        private void dgvTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!eventcreated)
            {
                e.Control.KeyPress += new KeyPressEventHandler(dgvTest_KeyPress);
                eventcreated = true;
            }
        }

        //==================================== CODE TO CHEK IF ONLY DIGITS ARE ENTERED ========================================//

        private void dgvTest_KeyPress(object O, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = false;
                if (dgvTest.CurrentCell.OwningColumn.Name != "Test")
                {

                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                    {
                        MessageBox.Show("Pleas enter digits only.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Handled = true;
                        valid = false;
                    }
                    else
                    {

                        valid = true;

                    }
                }
            }
            catch
            {


            }
        }
        List<int> lstAQLVal = new List<int>();
        List<int> lstAQLCVal = new List<int>();
        List<int> lstAqlZVal = new List<int>();
        List<int> lstAqlMVal = new List<int>();
        List<int> lstAqlM1Val = new List<int>();

        bool minorYellow = false;
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (recordExistsAlready)//&& ! newAddedToExisting)
                {
                    if (list_UpDefect_Obj.Count > 0)
                    {
                        foreach (UPdefect_Class Obj in list_UpDefect_Obj)
                        {
                            int ind = (int)Obj.uptestatsamplingpointid;
                            Obj.uptestatsamplingpointid = Convert.ToInt64(dgvTest.Rows[ind].Tag.ToString());
                            Obj.insert_tblUPTestDefect();

                        }
                        MessageBox.Show(" Saved successfully..", "Mesaage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //if (chkContinuetest.Checked && frmScoopUPAuthority_hare_Obj != null)
                    if (frmScoopUPAuthority_hare_Obj != null)
                    {
                        chkContinuetest.Checked = true;
                        UpdateUPAuthorityRemark();
                        MessageBox.Show(" Line has been approved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;

                    }
                    //if (chkContinuetest.Checked && frmScoopQualityAuthority_Here_Obj != null)
                    if (frmScoopQualityAuthority_Here_Obj != null)
                    {
                        chkContinuetest.Checked = true;
                        UpdateQualityAuthorityRemark();
                        MessageBox.Show(" Line has been approved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }
                    //<---------------------------------- DO NOT EXECUTE SAVE CODE WHEN RECORD EXISTS ALREADY IN DATABASE
                    this.Close();
                    return;
                }


                if (!UPTestAtSamplingPointSaved)
                {
                    Save_UPTestAtSamplingpoint();
                }
                // int aqlzcnt = 0, aqlccnt = 0, aqlmcnt = 0, aqlm1cnt = 0;
                if (list_UpDefect_Obj.Count > 0)
                {
                    foreach (UPdefect_Class Obj in list_UpDefect_Obj)
                    {
                        int ind = (int)Obj.uptestatsamplingpointid;
                        Obj.uptestatsamplingpointid = Convert.ToInt64(dgvTest.Rows[ind].Tag.ToString());
                        Obj.insert_tblUPTestDefect();

                    }

                }


                foreach (DataGridViewRow dgrw in dgvTest.Rows)
                {
                    //lstAQLCVal.Add(Convert.ToInt32(dgrw.Cells["AQLC"].Value.ToString()) > LstDefaultAqlC[dgrw.Index] ? Convert.ToInt32(dgrw.Cells["AQLC"].Value.ToString()) : 0);
                    //lstAqlZVal.Add(Convert.ToInt32(dgrw.Cells["AQLZ"].Value.ToString()) > LstDefultAqlZ[dgrw.Index] ? Convert.ToInt32(dgrw.Cells["AQLZ"].Value.ToString()) : 0);
                    //lstAqlMVal.Add(Convert.ToInt32(dgrw.Cells["AQLM"].Value.ToString()) > LstDefaultAqlM[dgrw.Index] ? Convert.ToInt32(dgrw.Cells["AQLM"].Value.ToString()) : 0);
                    //lstAqlM1Val.Add(Convert.ToInt32(dgrw.Cells["AQLM1"].Value.ToString()) > LstDefaultAqlM1[dgrw.Index] ? Convert.ToInt32(dgrw.Cells["AQLM1"].Value.ToString()) : 0);     
                    lstAQLVal.Add(Convert.ToInt32(dgrw.Cells["AQL"].Value.ToString()) > 0 ? Convert.ToInt32(dgrw.Cells["AQL"].Value.ToString()) : 0);
                    lstAQLCVal.Add(Convert.ToInt32(dgrw.Cells["AQLC"].Value.ToString()) > 0 ? Convert.ToInt32(dgrw.Cells["AQLC"].Value.ToString()) : 0);
                    lstAqlZVal.Add(Convert.ToInt32(dgrw.Cells["AQLZ"].Value.ToString()) > 0 ? Convert.ToInt32(dgrw.Cells["AQLZ"].Value.ToString()) : 0);
                    lstAqlMVal.Add(Convert.ToInt32(dgrw.Cells["AQLM"].Value.ToString()) > 0 ? Convert.ToInt32(dgrw.Cells["AQLM"].Value.ToString()) : 0);
                    lstAqlM1Val.Add(Convert.ToInt32(dgrw.Cells["AQLM1"].Value.ToString()) > 0 ? Convert.ToInt32(dgrw.Cells["AQLM1"].Value.ToString()) : 0);
                    if (!minorYellow)
                    {
                        minorYellow = Convert.ToInt32(dgrw.Cells["AQLM1"].Value.ToString()) > 0 ? true : false;
                    }
                }
                lstAQLVal.Sort();
                lstAQLCVal.Sort();
                lstAqlZVal.Sort();
                lstAqlMVal.Sort();
                lstAqlM1Val.Sort();

                //Update by Avinash S 15-07-2014

                uc_Grid.dgDefectCount.Rows[0].Cells[1].Value = Convert.ToInt32(uc_Grid.dgDefectCount.Rows[0].Cells[1].Value.ToString()) + lstAQLVal[lstAQLVal.Count - 1];
                uc_Grid.dgDefectCount.Rows[1].Cells[1].Value = Convert.ToInt32(uc_Grid.dgDefectCount.Rows[1].Cells[1].Value.ToString()) + lstAqlZVal[lstAqlZVal.Count - 1];
                uc_Grid.dgDefectCount.Rows[2].Cells[1].Value = Convert.ToInt32(uc_Grid.dgDefectCount.Rows[2].Cells[1].Value.ToString()) + lstAQLCVal[lstAQLCVal.Count - 1];
                uc_Grid.dgDefectCount.Rows[3].Cells[1].Value = Convert.ToInt32(uc_Grid.dgDefectCount.Rows[3].Cells[1].Value.ToString()) + lstAqlMVal[lstAqlMVal.Count - 1];
                uc_Grid.dgDefectCount.Rows[4].Cells[1].Value = Convert.ToInt32(uc_Grid.dgDefectCount.Rows[4].Cells[1].Value.ToString()) + lstAqlM1Val[lstAqlM1Val.Count - 1];

                MessageBox.Show(" Saved successfully..", "Mesaage", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //uc_Grid.dgSamplingPoint.Rows[rowindex].Cells[0].Value = uc_Grid.dgSamplingPoint.Rows[rowindex].Cells[0].Value.ToString().Substring(0, uc_Grid.dgSamplingPoint.Rows[rowindex].Cells[0].Value.ToString().LastIndexOf('M') + 1);

                if (Defect == true)
                {

                    // uc_Grid.SetSamplingGridRow("Defect", timeBreif.ToString("t"), rowindex, timeBreif);
                    uc_Grid.SetSamplingGridRow("Defect", txtTime.Text, rowindex, timeBreif);
                    uc_Grid.BroadCastDefect();

                    up_here_Obj.expectedTimeOfDefectTest = actualTimeOfSampling;
                    up_here_Obj.timeOfDefectTest = time;


                }
                else if (chkLastSample.Checked)
                {
                    //uc_Grid.SetSamplingGridRow("Last", UpMaster_Class_Obj.GetCurrentTime().ToString("t"), rowindex, timeBreif);
                    uc_Grid.SetSamplingGridRow("Last", txtTime.Text, rowindex, timeBreif);
                }
                else
                {


                    if (!minorYellow)
                    {
                        // uc_Grid.SetSamplingGridRow("OK", UpMaster_Class_Obj.GetCurrentTime().ToString("t"), rowindex, timeBreif);
                        uc_Grid.SetSamplingGridRow("OK", txtTime.Text, rowindex, timeBreif);

                    }
                    else
                    {
                        //uc_Grid.SetSamplingGridRow("MinorDefect", UpMaster_Class_Obj.GetCurrentTime().ToString("t"), rowindex, timeBreif);
                        uc_Grid.SetSamplingGridRow("MinorDefect", txtTime.Text, rowindex, timeBreif);

                    }

                    //---------- if defect occured at any point dont alow to add further ----------
                    if (!UC_SamplingGrid.defectOccuredAtOneEnd)
                    {
                        // uc_Grid.Add_SamplingRow((UpMaster_Class_Obj.GetCurrentTime().AddMinutes((int)uc_Grid.frequency)).ToString("t"), UpMaster_Class_Obj.GetCurrentTime().ToString("t"));
                        uc_Grid.Add_SamplingRow();
                    }
                }
            }
            catch
            {
                throw;
            }
            this.Close();
        }

        private void dgvTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region code first master then slave
                //if (CachObjListHere.Count > 0)
                //{
                //    CheckExistsinCach_DefectObj(dgvTest.CurrentCell);
                //    if (CheckExistsinCach_Defect)
                //    {
                //        frmUPDefect frm = new frmUPDefect(this, UPdefect_Class_Obj);
                //        frm.RecordExistinCach_UPTestAtSamplingPoint = true;
                //        frm.RecordExistinCach_Defect = true;
                //        frm.ShowDialog();
                //        if (canceled)
                //        {
                //            dgvTest.CurrentCell.Value = CellPreVal;
                //        }
                //        else
                //        {
                //            dgvTest.CurrentCell.Style.BackColor = Color.Gray;
                //        }
                //    }

                //    return;
                //}
                #endregion

                

                if (e.ColumnIndex == dgvTest.Columns["WA"].Index)
                {
                    if (dgvTest["AnalysisType", e.RowIndex].Value.ToString() == "")
                        return;

                    FrmWA.Weighing weighing = new FrmWA.Weighing();                   
                    weighing.WA_Reason = 'L';                   
                    weighing.WA_ObsCnt = Convert.ToInt32(dgvTest["Normal", e.RowIndex].Value.ToString());
                    weighing.WA_AnalysisType = dgvTest["AnalysisType", e.RowIndex].Value.ToString();
                    if (dgvTest["TorqueMin", e.RowIndex].Value.ToString() == "")
                        weighing.WA_TorqueMin = "0";
                    else
                        weighing.WA_TorqueMin = dgvTest["TorqueMin", e.RowIndex].Value.ToString();
                    if (dgvTest["TorqueMax", e.RowIndex].Value.ToString() == "")
                        weighing.WA_TorqueMax = "0";
                    else
                        weighing.WA_TorqueMax = dgvTest["TorqueMin", e.RowIndex].Value.ToString();
                    weighing.WA_uptestsamplingpointid = UPSamplingPontTestID;
                    weighing.WA_FormName = "Scoop";
                    weighing.MTID = Convert.ToInt32(dgvTest["MTID", e.RowIndex].Value.ToString());

                    weighing.TestNo = Convert.ToInt32(dgvTest["TestNo", e.RowIndex].Value.ToString());
                    weighing.TimeBrief = timeBreif;

                    FrmWA frm = new FrmWA(weighing);
                    frm.ShowDialog();

                    DataSet dsdone = new DataSet();

                    FinishedGoodTest_Class_Obj.upsamplingpointid = UPSamplingPontTestID;
                    FinishedGoodTest_Class_Obj.mtid = Convert.ToInt32(dgvTest["MTID", e.RowIndex].Value.ToString());

                    FinishedGoodTest_Class_Obj.testno = weighing.TestNo;
                    FinishedGoodTest_Class_Obj.timebrief = weighing.TimeBrief;
                    dsdone = FinishedGoodTest_Class_Obj.Select_tblWAStatus_Scoop_StatusID();
                    if (dsdone.Tables[0].Rows.Count > 0)
                        dgvTest["WA", e.RowIndex].Value = dsdone.Tables[0].Rows[0]["Status"].ToString();

                    txtTime.Focus();
                    //return;
                }

                else if (recordExistsAlready && e.ColumnIndex == dgvTest.Columns["WA"].Index || e.ColumnIndex == dgvTest.Columns["AQL"].Index || e.ColumnIndex == dgvTest.Columns["AQLZ"].Index || e.ColumnIndex == dgvTest.Columns["AQLC"].Index || e.ColumnIndex == dgvTest.Columns["AQLM"].Index || e.ColumnIndex == dgvTest.Columns["AQLM1"].Index)
                //if (recordExistsAlready && dgvTest.CurrentRow.Index > -1)
                {
                    frmUPDefect frm = new frmUPDefect(this);
                    frm.recordexist = true;
                    frm.UPTestAtSamplingPointID = Convert.ToInt64(dgvTest.CurrentRow.Tag.ToString());
                    frm.AQLlevel = dgvTest.CurrentCell.OwningColumn.Name;


                    //if (dgvTest.CurrentCell.OwningColumn.Name != "AQLM1" && dgvTest.CurrentCell.Value.ToString() == "0")
                    //{
                    //    return;
                    //}
                    //if (dgvTest.CurrentCell.OwningColumn.Name == "AQLM1" && dgvTest.CurrentCell.Value.ToString() == "3")
                    //{
                    //    return;
                    //}
                    //if (dgvTest.CurrentCell.OwningColumn.Name == "AQLM1" && dgvTest.CurrentCell.Value.ToString() == "2")
                    //{
                    //    return;
                    //}

                    frm.ShowDialog();
                }
            }
            catch
            {

            }
        }

        #region code master first then slave
        //bool CheckExistsinCach_Defect=false;

        //private void CheckExistsinCach_DefectObj(DataGridViewCell cl)
        //{
        //    try
        //    {
        //        UPdefect_Class_Obj = null;
        //        CheckExistsinCach_Defect = false;
        //        UPdefect_Class_Obj = up_here_Obj.UPdefect_Class_ObjList.Find(p => p.uptestatsamplingpointid == Convert.ToInt64(cl.OwningRow.Tag.ToString()) && p.aqllevel == cl.OwningColumn.Name);
        //        if (UPdefect_Class_Obj != null)
        //        {
        //            CheckExistsinCach_Defect = true;
        //            return;
        //        }
        //        if (updefect_Class_ObjList.Count > 0)
        //        {
        //            UPdefect_Class_Obj = updefect_Class_ObjList.Find(p => p.uptestatsamplingpointid == Convert.ToInt64(cl.OwningRow.Tag.ToString()) && p.aqllevel == cl.OwningColumn.Name);
        //            if (UPdefect_Class_Obj != null)
        //            {
        //                CheckExistsinCach_Defect = true;

        //            }
        //        }
        //    }
        //    catch
        //    { 

        //    }

        //}
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            canceled = true;
        }

        public void Save_UPTestAtSamplingpoint() //<------------------------------------------------------------- FUNCTION TO SAVE UPTETSTATSAMPLINGPOINT
         {
            try
            {
                UPTestAtSamplingPointSaved = false;
                foreach (DataGridViewRow dr in dgvTest.Rows)
                {
                    UPTestAtSamplingPoint_Class_Obj.testName = dr.Cells["Test"].Value.ToString();
                    UPTestAtSamplingPoint_Class_Obj.testno = Convert.ToInt32(dr.Cells["TestNo"].Value.ToString());
                    UPTestAtSamplingPoint_Class_Obj.time = txtTime.Text;
                    UPTestAtSamplingPoint_Class_Obj.uptestsamplingpointid = UPSamplingPontTestID;
                    UPTestAtSamplingPoint_Class_Obj.isLast = chkLastSample.Checked ? true : false;
                    UPTestAtSamplingPoint_Class_Obj.expectedtime = txtActualTimeOfSamplingPoint.Text;
                    UPTestAtSamplingPoint_Class_Obj.defect = dr.Cells["TestDefect"].Value.ToString() == "Yes" ? true : false;
                    UPTestAtSamplingPoint_Class_Obj.aqlz = Convert.ToInt32(dr.Cells["AQLZ"].Value.ToString());
                    UPTestAtSamplingPoint_Class_Obj.aqlc = Convert.ToInt32(dr.Cells["AQLC"].Value.ToString());
                    UPTestAtSamplingPoint_Class_Obj.aqlm = Convert.ToInt32(dr.Cells["AQLM"].Value.ToString());
                    UPTestAtSamplingPoint_Class_Obj.aqlm1 = Convert.ToInt32(dr.Cells["AQLM1"].Value.ToString());
                    UPTestAtSamplingPoint_Class_Obj.notdone = false;
                    UPTestAtSamplingPoint_Class_Obj.timeBrief = timeBreif;
                    UPTestAtSamplingPoint_Class_Obj.aql = Convert.ToInt32(dr.Cells["AQL"].Value.ToString());
                    UPTestAtSamplingPoint_Class_Obj.insert_tblUPTestAtSAmplingPoint();
                    dr.Tag = UPTestAtSamplingPoint_Class_Obj.GetLastAdded_tblUPTestAtSAmplingPoint();
                }
                UPTestAtSamplingPointSaved = true;
            }
            catch
            {

            }
        }

        public void Update_UPTestAtSamplingpoint(DataGridViewRow dr)//<------------------------------------------ FUNCTION TO UPDATE UPTETSTATSAMPLINGPOINT
        {
            try
            {
                UPTestAtSamplingPoint_Class_Obj.uptestAtsamplingPointId = Convert.ToInt64(dr.Tag.ToString());
                UPTestAtSamplingPoint_Class_Obj.aqlc = Convert.ToInt32(dr.Cells["AQLC"].Value.ToString());
                UPTestAtSamplingPoint_Class_Obj.aqlm = Convert.ToInt32(dr.Cells["AQLM"].Value.ToString());
                UPTestAtSamplingPoint_Class_Obj.aqlm1 = Convert.ToInt32(dr.Cells["AQLM1"].Value.ToString());
                UPTestAtSamplingPoint_Class_Obj.aqlz = Convert.ToInt32(dr.Cells["AQLZ"].Value.ToString());
                UPTestAtSamplingPoint_Class_Obj.defect = dr.Cells["TestDefect"].Value.ToString() == "Yes" ? true : false;
                UPTestAtSamplingPoint_Class_Obj.aql = Convert.ToInt32(dr.Cells["AQL"].Value.ToString());
                UPTestAtSamplingPoint_Class_Obj.Update_tblUPTestAtSAmplingPoint_OneAtTime();
            }
            catch
            {

            }

        }

        private void UpdateUPAuthorityRemark()
        {
            try
            {
                UPTestAtSamplingPoint_Class_Obj.upauthorityremark = true;
                UPTestAtSamplingPoint_Class_Obj.time = time;
                UPTestAtSamplingPoint_Class_Obj.expectedtime = actualTimeOfSampling;
                UPTestAtSamplingPoint_Class_Obj.uptestsamplingpointid = UPSamplingPontTestID;
                UPTestAtSamplingPoint_Class_Obj.Update_UpAuthorityRemark_tblUPTestAtSAmplingPoint();
            }
            catch
            {
                throw;
            }

        }

        private void UpdateQualityAuthorityRemark()
        {

            try
            {
                UPTestAtSamplingPoint_Class_Obj.qualityAuthorityremark = true;
                UPTestAtSamplingPoint_Class_Obj.time = time;
                UPTestAtSamplingPoint_Class_Obj.expectedtime = actualTimeOfSampling;
                UPTestAtSamplingPoint_Class_Obj.uptestsamplingpointid = UPSamplingPontTestID;
                UPTestAtSamplingPoint_Class_Obj.Update_QualityAuthorityRemark_tblUPTestAtSAmplingPoint();
            }
            catch
            {
                throw;
            }
        }

        private void dgvTest_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblresume_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlResume.Visible = true;
            txtResume.Focus();
        }

        private void BtnResumeCancel_Click(object sender, EventArgs e)
        {
            pnlResume.Visible = false;
            txtResume.Text = "";
        }

        private void BtnsaveResume_Click(object sender, EventArgs e)
        {
            UPTestAtSamplingPoint_Class_Obj.loginid = FrmMain.LoginID;
            UPTestAtSamplingPoint_Class_Obj.ResumeDescription = txtResume.Text;
            UPTestAtSamplingPoint_Class_Obj.time = time;
            UPTestAtSamplingPoint_Class_Obj.expectedtime = actualTimeOfSampling;
            UPTestAtSamplingPoint_Class_Obj.uptestsamplingpointid = UPSamplingPontTestID;
            UPTestAtSamplingPoint_Class_Obj.Update_ResumeLastSample();

            chkLastSample.Checked = false;
            txtResume.Text = "";
            MessageBox.Show(" Line has been resume.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

            pnlResume.Visible = false;
        }


    }
}
