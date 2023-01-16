using BusinessFacade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QTMS.Tools;

namespace QTMS.OOS
{
    public partial class FrmOOSDetails : Form
    {
        public FrmOOSDetails(FrmOOSDetails.Detail Detail)
        {
            InitializeComponent();
            OOS_Obj.batchnumber = Detail.D_batchnumber;
            OOS_Obj.fno = Detail.D_fno;
            OOS_Obj.bulkmethodno = Detail.D_bulkmethodno;
            OOS_Obj.productname = Detail.D_productname;
            OOS_Obj.mfgwo = Detail.D_mfgwo;
            OOS_Obj.testname = Detail.D_testname;
            OOS_Obj.formname = Detail.D_formname;
            OOS_Obj.tankno = Detail.D_tankno;
        }

        public class Detail
        {
            public long D_bulkmethodno;
            public long D_fno;
            public string D_productname;
            public string D_mfgwo;
            public string D_batchnumber;
            public string D_testname;
            public string D_formname;
            public int D_tankno;
        }

        #region Varibles

        BusinessFacade.Transactions.OOS OOS_Obj = new BusinessFacade.Transactions.OOS();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();


        DataSet dsOOSDetails = new DataSet();
        #endregion

        private static FrmOOSDetails frmFormulaNoMaster_Obj = null;
        //public static FrmOOSDetails GetInstance()
        //{
        //    if (frmFormulaNoMaster_Obj == null)
        //    {
        //        frmFormulaNoMaster_Obj = new FrmOOSDetails();
        //    }
        //    return frmFormulaNoMaster_Obj;
        //}

        private void btntab2next_Click(object sender, EventArgs e)
        {

            tabOOS.SelectedIndex = tabOOS.SelectedIndex + 1;

        }

        private void btnPrevioustab3_Click(object sender, EventArgs e)
        {
            tabOOS.SelectedIndex = tabOOS.SelectedIndex - 1;
        }

        private void btnPrevioustab3_Click_1(object sender, EventArgs e)
        {
            tabOOS.TabPages.Add(LaboratoryInvestigationtab);

            tabOOS.TabPages.Remove(LabErrortab);
            tabOOS.TabPages.Remove(OOSDetailstab);
            tabOOS.SelectedTab = LaboratoryInvestigationtab;
            //tabMom.SelectedIndex = tabMom.SelectedIndex - 1;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrevioustab2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnSaveOOSDetails_Click(object sender, EventArgs e)
        {
            //if (cmbAnalystBy_OOS_Details.SelectedValue == "0")
            if (cmbAnalystBy_OOS_Details.SelectedIndex == 0 || cmbAnalystBy_OOS_Details.Text == "--Select--")
            {
                MessageBox.Show("Select Analyst incharge.");
                cmbAnalystBy_OOS_Details.Focus();
                return;
            }


            OOS_Obj.createdby = FrmMain.LoginID;
            OOS_Obj.occurencedate = dtpOccurrenceDate.Value.ToShortDateString();
            OOS_Obj.testresultsummary = txttestresultsummary.Text;
            OOS_Obj.analystincharge = Convert.ToInt64(cmbAnalystBy_OOS_Details.SelectedValue);

            bool res = false;
            if (OOS_Obj.formname == "Bulk")
                res = OOS_Obj.Insert_Update_tblOOS_Bulk();
            else if (OOS_Obj.formname == "FG")
                res = OOS_Obj.Insert_Update_tblOOS_FG();

            if (res)
                MessageBox.Show("Record Saved Successfully.");


            if (OOS_Obj.formname == "Bulk")
                dsOOSDetails = OOS_Obj.Select_tblOOS_Bulk();
            else if (OOS_Obj.formname == "FG")
                dsOOSDetails = OOS_Obj.Select_tblOOS_FG();



            if (dsOOSDetails.Tables[0].Rows.Count > 0)
            {
                OOS_Obj.oosid = Convert.ToInt64(dsOOSDetails.Tables[0].Rows[0]["OOSid"]);
                txtOOSInvestigationRequestNo.Text = dsOOSDetails.Tables[0].Rows[0]["OOSRequestNo"].ToString();
                dtpOccurrenceDate.Value = Convert.ToDateTime(dsOOSDetails.Tables[0].Rows[0]["OccurenceDate"]);
                cmbAnalystBy_OOS_Details.SelectedValue = Convert.ToInt32(dsOOSDetails.Tables[0].Rows[0]["AnalystIncharge"]);
                txttestresultsummary.Text = dsOOSDetails.Tables[0].Rows[0]["TestResultSummary"].ToString();
            }
        }

        private void btnnextOOSDetails_Click(object sender, EventArgs e)
        {
            tabOOS.SelectedIndex = tabOOS.SelectedIndex + 1;
        }

        private void btnResamplingPrev_Click(object sender, EventArgs e)
        {
            tabOOS.SelectedIndex = tabOOS.SelectedIndex - 1;
        }

        private void btnResamplingSave_Click(object sender, EventArgs e)
        {
            if (OOS_Obj.oosid == null || OOS_Obj.oosid == 0)
            {
                MessageBox.Show("Please Saved OOS Detail Tab First.");
                tabOOS.SelectedIndex = 0;
                return;
            }
            if (rdoReAnalysisNo.Checked == true)
            {
                MessageBox.Show("You cant save record, please select 'YES' Re Analysis first.");
                tabOOS.SelectedIndex = 1;
                return;
            }
            if (cmbReSamplingHeadQualityControl.SelectedIndex == 0 || cmbReSamplingHeadQualityControl.Text == "--Select--")
            {
                MessageBox.Show("Select Head Quality Control.");
                cmbReSamplingHeadQualityControl.Focus();
                return;
            }

            if (rbtReSamplingYes.Checked == true)
                OOS_Obj.resample = "Yes";
            else
                OOS_Obj.resample = "No";

            OOS_Obj.result1 = txtReSamplingResultsForRetestingResult1.Text.Trim();
            OOS_Obj.result2 = txtReSamplingResultsForRetestingResult2.Text.Trim();
            OOS_Obj.average = txtReSamplingResultsForRetestingResult1Average1_2.Text.Trim();
            OOS_Obj.repeatability = txtReSamplingResultsForRetestingRepeatabilityNMT.Text.Trim();
            OOS_Obj.qcanalyst = Convert.ToInt64(cmbReSamplingQCAnalystName.SelectedValue);
            OOS_Obj.completionDate = dtpReSamplingCompletionDate.Value.ToShortDateString();
            OOS_Obj.conclusion = txtReSamplingConclusion.Text.Trim();
            OOS_Obj.simulating = txtReSamplingSimulationTestingConclusion.Text.Trim();
            OOS_Obj.resonResult1 = txtReSamplingRetest1.Text.Trim();
            OOS_Obj.resonResult2 = txtReSamplingRetest2.Text.Trim();
            OOS_Obj.resonaverage = txtReSamplingAverage.Text.Trim();
            OOS_Obj.resonrepeatability = txtReSamplingRepeatability.Text.Trim();
            OOS_Obj.finalremark = txtReSamplingQualityControlHeadFinaleRemark.Text.Trim();
            OOS_Obj.oosvalid = cmbReSamplingOOSValidInvalid.Text;
            OOS_Obj.proceed = cmbReSamplingProceedformanufacturingInvestment.Text;
            OOS_Obj.headqualitycontrol = Convert.ToInt64(cmbReSamplingHeadQualityControl.SelectedValue);
            OOS_Obj.resoncompletiondate = dtpReSamplingSimulationCompletionDate.Value.ToShortDateString();
            OOS_Obj.createdby = FrmMain.LoginID;

            bool res = OOS_Obj.Insert_Update_tblOOS_Resampling();

            if (res)
                MessageBox.Show("Record Saved Successfully.");
        }

        private void btnResamplingExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOOSDetails_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            label2.ForeColor = label8.ForeColor = Color.Red;

            txtProductName.Text = OOS_Obj.productname;
            txtTestName.Text = OOS_Obj.testname;
            txtBatchNumber.Text = OOS_Obj.batchnumber;

            cmbLabErrorConclusion.Text = "Select";

            cmbReSamplingOOSValidInvalid.Text = "Select";
            cmbReSamplingProceedformanufacturingInvestment.Text = "Select";

            Bind_AnalystBy_OOS_Details();
            Bind_LabErrorAnalystBy();
            Bind_ReSamplingQCAnalystName();
            Bind_ReSamplingHeadControl();
            Bind_MIUPManager();
            Bind_MIProcessExpert();
            Bind_MIQualityHead();

            // Set Current Date
            dtpOccurrenceDate.Value = Comman_Class_Obj.Select_ServerDate();
            dtpReSamplingCompletionDate.Value = dtpOccurrenceDate.Value;
            dtpReSamplingSimulationCompletionDate.Value = dtpOccurrenceDate.Value;
            dtpComplationdate.Value = dtpOccurrenceDate.Value;
            dtpMICompletionDate.Value = dtpOccurrenceDate.Value;

            BindLabErrorGrid();

            if (OOS_Obj.formname == "Bulk")
                dsOOSDetails = OOS_Obj.Select_tblOOS_Bulk();
            else if (OOS_Obj.formname == "FG")
                dsOOSDetails = OOS_Obj.Select_tblOOS_FG();

            if (dsOOSDetails.Tables[0].Rows.Count > 0)
            {
                OOS_Obj.oosid = Convert.ToInt64(dsOOSDetails.Tables[0].Rows[0]["OOSid"]);
                txtOOSInvestigationRequestNo.Text = dsOOSDetails.Tables[0].Rows[0]["OOSRequestNo"].ToString();
                dtpOccurrenceDate.Value = Convert.ToDateTime(dsOOSDetails.Tables[0].Rows[0]["OccurenceDate"]);
                cmbAnalystBy_OOS_Details.SelectedValue = Convert.ToInt32(dsOOSDetails.Tables[0].Rows[0]["AnalystIncharge"]);
                txttestresultsummary.Text = dsOOSDetails.Tables[0].Rows[0]["TestResultSummary"].ToString();

                Bind_laboratoryinvestigation_Information();
                Bind_LabErrorDetails_Information();
                Bind_ManufacturingInvestigation_Information();

                laberrorresult();
                ReSamplingResults();
                ReSamplingRetestResults();
                laboratoryinvestigationresult();
                laboratoryinvestigationinitialresult();
            }


            // 159, 197, 208

            //tabOOS.SelectedTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            //tabOOS.TabPages[0].BackColor = Color.Red;

        }

        public void Bind_AnalystBy_OOS_Details()
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
                cmbAnalystBy_OOS_Details.DataSource = ds.Tables[0];
                cmbAnalystBy_OOS_Details.DisplayMember = "UserName";
                cmbAnalystBy_OOS_Details.ValueMember = "UserID";
            }
        }

        public void Bind_LabErrorAnalystBy()
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
                cmbLabErrorQCAnalystName.DataSource = ds.Tables[0];
                cmbLabErrorQCAnalystName.DisplayMember = "UserName";
                cmbLabErrorQCAnalystName.ValueMember = "UserID";
            }
        }

        public void Bind_ReSamplingHeadControl()
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
                cmbReSamplingHeadQualityControl.DataSource = ds.Tables[0];
                cmbReSamplingHeadQualityControl.DisplayMember = "UserName";
                cmbReSamplingHeadQualityControl.ValueMember = "UserID";
            }
        }

        public void Bind_ReSamplingQCAnalystName()
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
                cmbReSamplingQCAnalystName.DataSource = ds.Tables[0];
                cmbReSamplingQCAnalystName.DisplayMember = "UserName";
                cmbReSamplingQCAnalystName.ValueMember = "UserID";
            }
        }

        public void Bind_MIUPManager()
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
                cmbMIUpmanager.DataSource = ds.Tables[0];
                cmbMIUpmanager.DisplayMember = "UserName";
                cmbMIUpmanager.ValueMember = "UserID";
            }
        }

        public void Bind_MIProcessExpert()
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
                cmbMIProcessExpert.DataSource = ds.Tables[0];
                cmbMIProcessExpert.DisplayMember = "UserName";
                cmbMIProcessExpert.ValueMember = "UserID";
            }
        }

        public void Bind_MIQualityHead()
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
                cmbMIQualityHead.DataSource = ds.Tables[0];
                cmbMIQualityHead.DisplayMember = "UserName";
                cmbMIQualityHead.ValueMember = "UserID";
            }
        }


        private void BindLabErrorGrid()
        {
            BindFirstGridOfLabError();
            BindSecondGridOfLabError();
            BindThirdGridOfLabError();
            // BindFourthGridOfLabError();  Cjromotography grid
            BindFiftGridOfLabError();
            BindMIGrid();
        }

        private void BindFirstGridOfLabError()
        {
            //dgv1.DataSource = null;
            dgv1.AutoGenerateColumns = false;
            DataGridViewRow dr1 = new DataGridViewRow();
            dr1.CreateCells(dgv1);  //
            dr1.Cells[0].Value = "1";
            dr1.Cells[1].Value = "Any Error In Calculation";
            dr1.Cells[2].Value = "Select";
            dgv1.Rows.Add(dr1);
            DataGridViewRow dr2 = new DataGridViewRow();
            dr2.CreateCells(dgv1);  //
            dr2.Cells[0].Value = "2";
            dr2.Cells[1].Value = "Any abnormality observed during testing";
            dr2.Cells[2].Value = "Select";
            dgv1.Rows.Add(dr2);
            DataGridViewRow dr3 = new DataGridViewRow();
            dr3.CreateCells(dgv1);  //
            dr3.Cells[0].Value = "3";
            dr3.Cells[1].Value = "Was the method discussed with analyst";
            dr3.Cells[2].Value = "Select";
            dgv1.Rows.Add(dr3);
            DataGridViewRow dr4 = new DataGridViewRow();
            dr4.CreateCells(dgv1);  //
            dr4.Cells[0].Value = "4";
            dr4.Cells[1].Value = "Correct analytical method used";
            dr4.Cells[2].Value = "Select";
            dgv1.Rows.Add(dr4);
            DataGridViewRow dr5 = new DataGridViewRow();
            dr5.CreateCells(dgv1);  //
            dr5.Cells[0].Value = "5";
            dr5.Cells[1].Value = "Analyst was trained to perform the test";
            dr5.Cells[2].Value = "Select";
            dgv1.Rows.Add(dr5);
            DataGridViewRow dr6 = new DataGridViewRow();
            dr6.CreateCells(dgv1);  //
            dr6.Cells[0].Value = "6";
            dr6.Cells[1].Value = "Correct glassware used for dilutions";
            dr6.Cells[2].Value = "Select";
            dgv1.Rows.Add(dr6);
            DataGridViewRow dr7 = new DataGridViewRow();
            dr7.CreateCells(dgv1);  //
            dr7.Cells[0].Value = "7";
            dr7.Cells[1].Value = "Glassware was properly cleaned";
            dr7.Cells[2].Value = "Select";
            dgv1.Rows.Add(dr7);
            DataGridViewRow dr8 = new DataGridViewRow();
            dr8.CreateCells(dgv1);  //
            dr8.Cells[0].Value = "8";
            dr8.Cells[1].Value = "Instruments used are qualified";
            dr8.Cells[2].Value = "Select";
            dgv1.Rows.Add(dr8);
            DataGridViewRow dr9 = new DataGridViewRow();
            dr9.CreateCells(dgv1);  //
            dr9.Cells[0].Value = "9";
            dr9.Cells[1].Value = "Instruments used within calibration validity period";
            dr9.Cells[2].Value = "Select";
            dgv1.Rows.Add(dr9);

            dgv1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }

        private void BindSecondGridOfLabError()
        {
            //dgv2.DataSource = null;
            dgv2.AutoGenerateColumns = false;
            DataGridViewRow dr1 = new DataGridViewRow();
            dr1.CreateCells(dgv2);  //
            dr1.Cells[0].Value = "10";
            dr1.Cells[1].Value = "Instrument set up & operation as per standard operating procedure.";
            dr1.Cells[2].Value = "Select";
            dgv2.Rows.Add(dr1);
            DataGridViewRow dr2 = new DataGridViewRow();
            dr2.CreateCells(dgv2);  //
            dr2.Cells[0].Value = "11";
            dr2.Cells[1].Value = "Correct electrode used";
            dr2.Cells[2].Value = "Select";
            dgv2.Rows.Add(dr2);
            DataGridViewRow dr3 = new DataGridViewRow();
            dr3.CreateCells(dgv2);  //
            dr3.Cells[0].Value = "12";
            dr3.Cells[1].Value = "Solution inside electrode is correct";
            dr3.Cells[2].Value = "Select";
            dgv2.Rows.Add(dr3);
            DataGridViewRow dr4 = new DataGridViewRow();
            dr4.CreateCells(dgv2);  //
            dr4.Cells[0].Value = "13";
            dr4.Cells[1].Value = "Blank reading is similar as earlier";
            dr4.Cells[2].Value = "Select";
            dgv2.Rows.Add(dr4);
            DataGridViewRow dr5 = new DataGridViewRow();
            dr5.CreateCells(dgv2);  //
            dr5.Cells[0].Value = "14";
            dr5.Cells[1].Value = "Any unusual trend in autotitrator graph";
            dr5.Cells[2].Value = "Select";
            dgv2.Rows.Add(dr5);
            DataGridViewRow dr6 = new DataGridViewRow();
            dr6.CreateCells(dgv2);  //
            dr6.Cells[0].Value = "15";
            dr6.Cells[1].Value = "Use of appropriate grade of chemicals and reagents within validity period";
            dr6.Cells[2].Value = "Select";
            dgv2.Rows.Add(dr6);
            DataGridViewRow dr7 = new DataGridViewRow();
            dr7.CreateCells(dgv2);  //
            dr7.Cells[0].Value = "16";
            dr7.Cells[1].Value = "Water used is same as specified in the method";
            dr7.Cells[2].Value = "Select";
            dgv2.Rows.Add(dr7);
            DataGridViewRow dr8 = new DataGridViewRow();
            dr8.CreateCells(dgv2);  //
            dr8.Cells[0].Value = "17";
            dr8.Cells[1].Value = "Correct normality, molarity of volumetric solutions used";
            dr8.Cells[2].Value = "Select";
            dgv2.Rows.Add(dr8);

            dgv2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }

        private void BindThirdGridOfLabError()
        {
            //dgv3.DataSource = null;
            dgv3.AutoGenerateColumns = false;
            DataGridViewRow dr1 = new DataGridViewRow();
            dr1.CreateCells(dgv3);  //
            dr1.Cells[0].Value = "18";
            dr1.Cells[1].Value = "Leakage Observed in case of Buchi apparatus.";
            dr1.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr1);
            DataGridViewRow dr2 = new DataGridViewRow();
            dr2.CreateCells(dgv3);  //
            dr2.Cells[0].Value = "19";
            dr2.Cells[1].Value = "The buchi apparatus is properly dipped in collecting solution";
            dr2.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr2);
            DataGridViewRow dr3 = new DataGridViewRow();
            dr3.CreateCells(dgv3);  //
            dr3.Cells[0].Value = "20";
            dr3.Cells[1].Value = "In case of viscometer check viscosity of water using Spindle M1. It should be 29.5+_1 UD at 20 Degree.";
            dr3.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr3);
            DataGridViewRow dr4 = new DataGridViewRow();
            dr4.CreateCells(dgv3);  //
            dr4.Cells[0].Value = "21";
            dr4.Cells[1].Value = "Sample and standard preparation is done as per test method";
            dr4.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr4);
            DataGridViewRow dr5 = new DataGridViewRow();
            dr5.CreateCells(dgv3);  //
            dr5.Cells[0].Value = "22";
            dr5.Cells[1].Value = "Is any weighing error identified";
            dr5.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr5);
            DataGridViewRow dr6 = new DataGridViewRow();
            dr6.CreateCells(dgv3);  //
            dr6.Cells[0].Value = "23";
            dr6.Cells[1].Value = "Is sample properly shaken/sonicated/ warmed as per the test";
            dr6.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr6);
            DataGridViewRow dr7 = new DataGridViewRow();
            dr7.CreateCells(dgv3);  //
            dr7.Cells[0].Value = "24";
            dr7.Cells[1].Value = "Any noticeable error is noticed between standard and sample preparation.";
            dr7.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr7);
            DataGridViewRow dr8 = new DataGridViewRow();
            dr8.CreateCells(dgv3);  //
            dr8.Cells[0].Value = "25";
            dr8.Cells[1].Value = "Are the sample and standard stored under same environment before testing";
            dr8.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr8);
            DataGridViewRow dr9 = new DataGridViewRow();
            dr9.CreateCells(dgv3);  //
            dr9.Cells[0].Value = "26";
            dr9.Cells[1].Value = "Any error in Transcription";
            dr9.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr9);

            #region remove Chromotography grid

            DataGridViewRow dr10 = new DataGridViewRow();
            dr10.CreateCells(dgv3);  //
            dr10.Cells[0].Value = "27";
            dr10.Cells[1].Value = "Correct column used";
            dr10.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr10);
            DataGridViewRow dr11 = new DataGridViewRow();
            dr11.CreateCells(dgv3);  //
            dr11.Cells[0].Value = "28";
            dr11.Cells[1].Value = "Any leakage noticed from column";
            dr11.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr11);
            DataGridViewRow dr12 = new DataGridViewRow();
            dr12.CreateCells(dgv3);  //
            dr12.Cells[0].Value = "29";
            dr12.Cells[1].Value = "Correct instrument parameters are used? Like flow rate injection volume";
            dr12.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr12);
            DataGridViewRow dr13 = new DataGridViewRow();
            dr13.CreateCells(dgv3);  //
            dr13.Cells[0].Value = "30";
            dr13.Cells[1].Value = "Mobile phase preparation is used as per standard method.";
            dr13.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr13);
            DataGridViewRow dr14 = new DataGridViewRow();
            dr14.CreateCells(dgv3);  //
            dr14.Cells[0].Value = "31";
            dr14.Cells[1].Value = "Systems suitability criteria met during testing";
            dr14.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr14);

            DataGridViewRow dr15 = new DataGridViewRow();
            dr15.CreateCells(dgv3);  //
            dr15.Cells[0].Value = "32";
            dr15.Cells[1].Value = "Other Findings";
            dr15.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr15);
            DataGridViewRow dr16 = new DataGridViewRow();
            dr16.CreateCells(dgv3);  //
            dr16.Cells[0].Value = "33";
            dr16.Cells[1].Value = "Was similar OOS reported for same product";
            dr16.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr16);
            DataGridViewRow dr17 = new DataGridViewRow();
            dr17.CreateCells(dgv3);  //
            dr17.Cells[0].Value = "34";
            dr17.Cells[1].Value = "Laboratory error identified? if yes please specify ";
            dr17.Cells[2].Value = "Select";
            dgv3.Rows.Add(dr17);

            #endregion

            dgv3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }

        private void BindFourthGridOfLabError()
        {
            //////dgv4.DataSource = null;
            ////dgv4.AutoGenerateColumns = false;
            ////DataGridViewRow dr1 = new DataGridViewRow();
            ////dr1.CreateCells(dgv4);  //
            ////dr1.Cells[0].Value = "1";
            ////dr1.Cells[1].Value = "Correct column used";
            ////dr1.Cells[2].Value = "Select";
            ////dgv4.Rows.Add(dr1);
            ////DataGridViewRow dr2 = new DataGridViewRow();
            ////dr2.CreateCells(dgv4);  //
            ////dr2.Cells[0].Value = "2";
            ////dr2.Cells[1].Value = "Any leakage noticed from column";
            ////dr2.Cells[2].Value = "Select";
            ////dgv4.Rows.Add(dr2);
            ////DataGridViewRow dr3 = new DataGridViewRow();
            ////dr3.CreateCells(dgv4);  //
            ////dr3.Cells[0].Value = "3";
            ////dr3.Cells[1].Value = "Correct instrument parameters are used? Like flow rate injection volume";
            ////dr3.Cells[2].Value = "Select";
            ////dgv4.Rows.Add(dr3);
            ////DataGridViewRow dr4 = new DataGridViewRow();
            ////dr4.CreateCells(dgv4);  //
            ////dr4.Cells[0].Value = "4";
            ////dr4.Cells[1].Value = "Mobile phase preparation is used as per standard method.";
            ////dr4.Cells[2].Value = "Select";
            ////dgv4.Rows.Add(dr4);
            ////DataGridViewRow dr5 = new DataGridViewRow();
            ////dr5.CreateCells(dgv4);  //
            ////dr5.Cells[0].Value = "5";
            ////dr5.Cells[1].Value = "Systems suitability criteria met during testing";
            ////dr5.Cells[2].Value = "Select";
            ////dgv4.Rows.Add(dr5);
            /*
            DataGridViewRow dr6 = new DataGridViewRow();
            dr6.CreateCells(dgv4);  //
            dr6.Cells[0].Value = "6";
            dr6.Cells[1].Value = "Other Findings";
            dr6.Cells[2].Value = "Select";
            dgv4.Rows.Add(dr6);
            DataGridViewRow dr7 = new DataGridViewRow();
            dr7.CreateCells(dgv4);  //
            dr7.Cells[0].Value = "7";
            dr7.Cells[1].Value = "Was similar OOS reported for same product";
            dr7.Cells[2].Value = "Select";
            dgv4.Rows.Add(dr7);
            DataGridViewRow dr8 = new DataGridViewRow();
            dr8.CreateCells(dgv4);  //
            dr8.Cells[0].Value = "8";
            dr8.Cells[1].Value = "Laboratory error identified? if yes please specify ";
            dr8.Cells[2].Value = "Select";
            dgv4.Rows.Add(dr8);
            */
            dgv4.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }

        private void BindFiftGridOfLabError()
        {
            //dgv5.DataSource = null;
            dgv5.AutoGenerateColumns = false;
            DataGridViewRow dr1 = new DataGridViewRow();
            dr1.CreateCells(dgv5);  //
            dr1.Cells[0].Value = "1";
            dr1.Cells[1].Value = "Retesting of same sample by the original analyst in duplicate";
            dr1.Cells[2].Value = "Select";
            dgv5.Rows.Add(dr1);
            DataGridViewRow dr2 = new DataGridViewRow();
            dr2.CreateCells(dgv5);  //
            dr2.Cells[0].Value = "2";
            dr2.Cells[1].Value = "Correction in documents";
            dr2.Cells[2].Value = "Select";
            dgv5.Rows.Add(dr2);

            ////DataGridViewRow dr6 = new DataGridViewRow();
            ////dr6.CreateCells(dgv5);  //
            ////dr6.Cells[0].Value = "3";
            ////dr6.Cells[1].Value = "Other Findings";
            ////dr6.Cells[2].Value = "Select";
            ////dgv5.Rows.Add(dr6);
            ////DataGridViewRow dr7 = new DataGridViewRow();
            ////dr7.CreateCells(dgv5);  //
            ////dr7.Cells[0].Value = "4";
            ////dr7.Cells[1].Value = "Was similar OOS reported for same product";
            ////dr7.Cells[2].Value = "Select";
            ////dgv5.Rows.Add(dr7);
            ////DataGridViewRow dr8 = new DataGridViewRow();
            ////dr8.CreateCells(dgv5);  //
            ////dr8.Cells[0].Value = "5";
            ////dr8.Cells[1].Value = "Laboratory error identified? if yes please specify ";
            ////dr8.Cells[2].Value = "Select";
            ////dgv5.Rows.Add(dr8);

            dgv5.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv5.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }

        private void BindMIGrid()
        {
            //dgv1.DataSource = null;
            dgvMI.AutoGenerateColumns = false;
            DataGridViewRow dr1 = new DataGridViewRow();
            dr1.CreateCells(dgvMI);  //
            dr1.Cells[0].Value = "1";
            dr1.Cells[1].Value = "Correct method of manufacturing was used?";
            dr1.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr1);
            DataGridViewRow dr2 = new DataGridViewRow();
            dr2.CreateCells(dgvMI);  //
            dr2.Cells[0].Value = "2";
            dr2.Cells[1].Value = "The dispensing labels on empty poly bags are correct?";
            dr2.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr2);
            DataGridViewRow dr3 = new DataGridViewRow();
            dr3.CreateCells(dgvMI);  //
            dr3.Cells[0].Value = "3";
            dr3.Cells[1].Value = "Correct quantities of required grade of starting materials were used in manufacturing?";
            dr3.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr3);
            DataGridViewRow dr4 = new DataGridViewRow();
            dr4.CreateCells(dgvMI);  //
            dr4.Cells[0].Value = "4";
            dr4.Cells[1].Value = "QC approved raw materials were used in manufacturing.";
            dr4.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr4);
            DataGridViewRow dr5 = new DataGridViewRow();
            dr5.CreateCells(dgvMI);  //
            dr5.Cells[0].Value = "5";
            dr5.Cells[1].Value = "Were the same lots of RM used in other batches of bulk. If yes what is the status of those batches";
            dr5.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr5);
            DataGridViewRow dr6 = new DataGridViewRow();
            dr6.CreateCells(dgvMI);  //
            dr6.Cells[0].Value = "6";
            dr6.Cells[1].Value = "The RMs were stored properly as per recommended storage conditions.";
            dr6.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr6);
            DataGridViewRow dr7 = new DataGridViewRow();
            dr7.CreateCells(dgvMI);  //
            dr7.Cells[0].Value = "7";
            dr7.Cells[1].Value = "Weighing balances used in dispensing/verification were calibrated.";
            dr7.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr7);
            DataGridViewRow dr8 = new DataGridViewRow();
            dr8.CreateCells(dgvMI);  //
            dr8.Cells[0].Value = "8";
            dr8.Cells[1].Value = "Method of manufacturing was validated?";
            dr8.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr8);
            DataGridViewRow dr9 = new DataGridViewRow();
            dr9.CreateCells(dgvMI);  //
            dr9.Cells[0].Value = "9";
            dr9.Cells[1].Value = "The processing steps were followed in correct sequence as per method of manufacturing.";
            dr9.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr9);

            DataGridViewRow dr10 = new DataGridViewRow();
            dr10.CreateCells(dgvMI);  //
            dr10.Cells[0].Value = "10";
            dr10.Cells[1].Value = "All the processing parameters were within the   range specified in method of manufacturing.";
            dr10.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr10);
            DataGridViewRow dr11 = new DataGridViewRow();
            dr11.CreateCells(dgvMI);  //
            dr11.Cells[0].Value = "11";
            dr11.Cells[1].Value = "The manufacturing operator was trained.";
            dr11.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr11);
            DataGridViewRow dr12 = new DataGridViewRow();
            dr12.CreateCells(dgvMI);  //
            dr12.Cells[0].Value = "12";
            dr12.Cells[1].Value = "In which shift the batch was manufactured?";
            //dr12.Cells[2].v.Items.AddRange(new string[] { "Select", "Dane", "Dodge", "Door" });

            dr12.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr12);
            DataGridViewRow dr13 = new DataGridViewRow();
            dr13.CreateCells(dgvMI);  //
            dr13.Cells[0].Value = "13";
            dr13.Cells[1].Value = "Environmental conditions during manufacturing were as per the limits.";
            dr13.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr13);
            DataGridViewRow dr14 = new DataGridViewRow();
            dr14.CreateCells(dgvMI);  //
            dr14.Cells[0].Value = "14";
            dr14.Cells[1].Value = "Any deviation from the manufacturing process?";
            dr14.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr14);
            DataGridViewRow dr15 = new DataGridViewRow();
            dr15.CreateCells(dgvMI);  //
            dr15.Cells[0].Value = "15";
            dr15.Cells[1].Value = "All the monitoring equipment used in the  processing were calibrated?";
            dr15.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr15);
            DataGridViewRow dr16 = new DataGridViewRow();
            dr16.CreateCells(dgvMI);  //
            dr16.Cells[0].Value = "16";
            dr16.Cells[1].Value = "All the processing equipment were maintained as per Preventive maintenance schedule?";
            dr16.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr16);
            DataGridViewRow dr17 = new DataGridViewRow();
            dr17.CreateCells(dgvMI);  //
            dr17.Cells[0].Value = "17";
            dr17.Cells[1].Value = "Any malfunctioning of equipment or breakdowns during processing?";
            dr17.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr17);
            DataGridViewRow dr18 = new DataGridViewRow();
            dr18.CreateCells(dgvMI);  //
            dr18.Cells[0].Value = "18";
            dr18.Cells[1].Value = "Any failure of utilities (like power,water,com pressed air,steam etc.) associated with the process?";
            dr18.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr18);
            DataGridViewRow dr19 = new DataGridViewRow();
            dr19.CreateCells(dgvMI);  //
            dr19.Cells[0].Value = "19";
            dr19.Cells[1].Value = "All the in-process checks were performed as per the defined frequency and the results were within acceptance criteria?";
            dr19.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr19);
            DataGridViewRow dr20 = new DataGridViewRow();
            dr20.CreateCells(dgvMI);  //
            dr20.Cells[0].Value = "20";
            dr20.Cells[1].Value = "Any significant observation noted during batch Manufacture?";
            dr20.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr20);
            DataGridViewRow dr21 = new DataGridViewRow();
            dr21.CreateCells(dgvMI);  //
            dr21.Cells[0].Value = "21";
            dr21.Cells[1].Value = "Any other findings (e.g. from review of trend data of previous batches,observations noted during follow up batches etc.) Additional pages can be used for other analysis.";
            dr21.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr21);
            DataGridViewRow dr22 = new DataGridViewRow();
            dr22.CreateCells(dgvMI);  //
            dr22.Cells[0].Value = "22";
            dr22.Cells[1].Value = "Manufacturing error identified Yes/ NO. If yes,describe the error.";
            dr22.Cells[2].Value = "Select";
            dgvMI.Rows.Add(dr22);

            dgvMI.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvMI.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;


            foreach (DataGridViewRow row in dgvMI.Rows)
            {
                if (row.Index == 11)
                {
                    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)(row.Cells[2]);
                    cell.DataSource = new string[] { "Select", "A", "B", "C", "G" };
                }
            }
        }

        private void btnNextLaboratorytab_Click(object sender, EventArgs e)
        {
            if (rdoLabErrorYes.Checked == true)
                tabOOS.SelectedIndex = tabOOS.SelectedIndex + 1;
            else if (rdoReAnalysisYes.Checked == true)
                tabOOS.SelectedIndex = tabOOS.SelectedIndex + 2;
            else
                MessageBox.Show("You cant go to next tab");
        }

        private void btnPrevLaboratorytab_Click(object sender, EventArgs e)
        {
            tabOOS.SelectedIndex = tabOOS.SelectedIndex - 1;
        }

        private void btnLabErrorNext_Click(object sender, EventArgs e)
        {
            tabOOS.SelectedIndex = tabOOS.SelectedIndex + 1;
        }

        private void btnLabErrorPrev_Click(object sender, EventArgs e)
        {
            tabOOS.SelectedIndex = tabOOS.SelectedIndex - 1;
        }

        private void btnResamplingNext_Click(object sender, EventArgs e)
        {
            if (cmbReSamplingProceedformanufacturingInvestment.Text == "Yes")
                tabOOS.SelectedIndex = tabOOS.SelectedIndex + 1;
            else
            {
                MessageBox.Show("You don't have persimmsion to go next tab. Please select Proceed for manufacturing to 'Yes'.");
                cmbReSamplingProceedformanufacturingInvestment.Focus();
            }
        }

        private void btnSaveLaboratorytab_Click(object sender, EventArgs e)
        {
            if (OOS_Obj.oosid == null || OOS_Obj.oosid == 0)
            {
                MessageBox.Show("Please Saved OOS Detail Tab First.");
                tabOOS.SelectedIndex = 0;
                return;
            }

            OOS_Obj.smaplebatchno = txtReferenceSampleBatchNo.Text.Trim();
            OOS_Obj.sampleinitialresult = txtReferenceSampleInitialResult.Text.Trim();
            OOS_Obj.laboratoryinvestigationresult = txtNMTResult.Text.Trim();
            OOS_Obj.laboratoryinvestigationresult1 = txtResult1.Text.Trim();
            OOS_Obj.laboratoryinvestigationresult2 = txtResult2.Text.Trim();
            OOS_Obj.laboratoryinvestigationaverage1and2 = txtAverageOf1_2.Text.Trim();
            OOS_Obj.laboratoryinvestigationrepeatability = txtRepeatability.Text.Trim();
            OOS_Obj.laboratoryinvestigationdiffrence = txtDifferenceNMTResult.Text.Trim();
            OOS_Obj.laboratoryinvestigationinitialresult = txtInitialResult.Text.Trim();
            OOS_Obj.laboratoryinvestigationreanalysisresult = txtRe_AnalysisResult.Text.Trim();
            OOS_Obj.laboratoryinvestigationreproducibility = txtReproducibility.Text.Trim();
            OOS_Obj.laboratoryinvestigationconclusion = txtLaboratoryConclusion.Text.Trim();
            OOS_Obj.createdby = FrmMain.LoginID;
            if (rdoReAnalysisYes.Checked == true)
                OOS_Obj.reanalysis = "Yes";
            if (rdoReAnalysisNo.Checked == true)
                OOS_Obj.reanalysis = "No";

            if (rdoLabErrorYes.Checked == true)
                OOS_Obj.laberror = "Yes";
            if (rdoLabErrorNo.Checked == true)
                OOS_Obj.laberror = "No";

            bool res = OOS_Obj.Insert_Update_tblOOS_LaboratoryInvestigation();

            if (res)
                MessageBox.Show("Record Saved Successfully.");
        }

        private void txtResult1_Leave(object sender, EventArgs e)
        {
            if (txtResult1.Text == "")
            {
                return;
            }
            if (txtReferenceSampleInitialResult.Text == "")
            {
                MessageBox.Show("Please Enter Reference Sample Initial Result :");
                txtResult1.Text = "";
                txtReferenceSampleInitialResult.Focus();
                return;
            }
            laboratoryinvestigationresult();
        }

        private void txtResult2_Leave(object sender, EventArgs e)
        {
            laboratoryinvestigationresult();
        }

        public void laboratoryinvestigationresult()
        {
            if (txtResult1.Text.Trim() != "" && txtResult2.Text.Trim() != "")
            {
                double Min = 0.0, Max = 0.0;
                double num1 = Convert.ToDouble(txtResult1.Text.Trim());
                double num2 = Convert.ToDouble(txtResult2.Text.Trim());
                double Average = 0.0, Repeatability = 0.0;

                if (num1 > num2)
                {
                    Max = num1;
                    Min = num2;
                }
                else
                {
                    Max = num2;
                    Min = num1;
                }

                Average = ((Min + Max) / 2);
                txtRe_AnalysisResult.Text = txtAverageOf1_2.Text = Average.ToString("f2");

                Repeatability = ((Max - Min) * 100) / Min;
                if (Repeatability <= 1.3)
                    txtRepeatability.BackColor = Color.LightGreen;
                else
                    txtRepeatability.BackColor = Color.Red;
                txtRepeatability.Text = Repeatability.ToString("f2");

                laboratoryinvestigationinitialresult();
            }
        }

        private void txtInitialResult_Leave(object sender, EventArgs e)
        {
            laboratoryinvestigationinitialresult();
        }

        private void txtRe_AnalysisResult_Leave(object sender, EventArgs e)
        {
            laboratoryinvestigationinitialresult();
        }

        public void laboratoryinvestigationinitialresult()
        {
            if (txtInitialResult.Text.Trim() != "" && txtRe_AnalysisResult.Text.Trim() != "")
            {
                double Min = 0.0, Max = 0.0;
                double num1 = Convert.ToDouble(txtInitialResult.Text.Trim());
                double num2 = Convert.ToDouble(txtRe_AnalysisResult.Text.Trim());
                double Average = 0.0, Repeatability = 0.0;

                if (num1 > num2)
                {
                    Max = num1;
                    Min = num2;
                }
                else
                {
                    Max = num2;
                    Min = num1;
                }

                //Average = ((Min + Max) / 2);
                //txtAverageOf1_2.Text = Average.ToString("f2");

                Repeatability = ((Max - Min) * 100) / Min;
                if (Repeatability <= 1.5)
                    txtReproducibility.BackColor = Color.LightGreen;
                else
                    txtReproducibility.BackColor = Color.Red;
                txtReproducibility.Text = Repeatability.ToString("f2");
            }
        }

        public void Bind_laboratoryinvestigation_Information()
        {
            DataSet dslaboratoryinvestigation = new DataSet();
            dslaboratoryinvestigation = OOS_Obj.Select_tblOOS_LaboratoryInvestigation();
            if (dslaboratoryinvestigation.Tables[0].Rows.Count > 0)
            {
                txtReferenceSampleBatchNo.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["SmapleBatchno"].ToString();
                txtReferenceSampleInitialResult.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["SampleInitialResult"].ToString();
                txtNMTResult.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["LaboratoryInvestigationResult"].ToString();
                txtResult1.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["LaboratoryInvestigationResult1"].ToString();
                txtResult2.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["LaboratoryInvestigationResult2"].ToString();
                txtAverageOf1_2.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["LaboratoryInvestigationAverage1and2"].ToString();
                txtRepeatability.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["LaboratoryInvestigationRepeatability"].ToString();
                txtDifferenceNMTResult.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["LaboratoryInvestigationDiffrence"].ToString();
                txtInitialResult.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["LaboratoryInvestigationInitialResult"].ToString();
                txtRe_AnalysisResult.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["LaboratoryInvestigationReAnalysisResult"].ToString();
                txtReproducibility.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["LaboratoryInvestigationReProducibility"].ToString();
                txtLaboratoryConclusion.Text = dslaboratoryinvestigation.Tables[0].Rows[0]["LaboratoryInvestigationConclusion"].ToString();
                if (dslaboratoryinvestigation.Tables[0].Rows[0]["Reanalysis"].ToString() == "Yes")
                    rdoReAnalysisYes.Checked = true;
                else
                    rdoReAnalysisNo.Checked = true;
                if (dslaboratoryinvestigation.Tables[0].Rows[0]["Laberror"].ToString() == "Yes")
                    rdoLabErrorYes.Checked = true;
                else
                    rdoLabErrorNo.Checked = true;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLabErrorExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLabErrorSave_Click(object sender, EventArgs e)
        {
            if (OOS_Obj.oosid == null || OOS_Obj.oosid == 0)
            {
                MessageBox.Show("Please Saved OOS Detail Tab First.");
                tabOOS.SelectedIndex = 0;
                return;
            }
            if (rdoLabErrorNo.Checked == true)
            {
                MessageBox.Show("You cant save record, please select 'YES' laberror first.");
                tabOOS.SelectedIndex = 1;
                return;
            }
            if (cmbLabErrorQCAnalystName.SelectedIndex == 0 || cmbLabErrorQCAnalystName.Text == "--Select--")
            {
                MessageBox.Show("Select QC Analyst.");
                cmbLabErrorQCAnalystName.Focus();
                return;
            }


            OOS_Obj.Delete_tblOOS_LabDetails();

            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                OOS_Obj.srno = Convert.ToInt32(dgv1[0, i].Value);
                OOS_Obj.parameters = dgv1[1, i].Value.ToString();
                OOS_Obj.observations = dgv1[2, i].Value.ToString();
                OOS_Obj.comments = Convert.ToString(dgv1[3, i].Value);

                bool res = OOS_Obj.Insert_tblOOS_LabDetails();
                if (i == 8)
                {
                    if (OOS_Obj.observations == "Yes")
                    {
                        DataSet DSInstrments = new DataSet();
                        DSInstrments = OOS_Obj.Select_LabDetailsID_tblOOS_LabDetails();
                        if (DSInstrments.Tables[0].Rows.Count > 0)
                        {
                            OOS_Obj.labdetailsid = Convert.ToInt64(DSInstrments.Tables[0].Rows[0]["LabDetailsID"]);
                            for (int ins = 0; ins < dgvInstruments.Rows.Count - 1; ins++)
                            {
                                OOS_Obj.instrumentused = Convert.ToString(dgvInstruments[0, ins].Value);
                                OOS_Obj.calibrationdue = dgvInstruments[1, ins].Value.ToString();

                                bool r = OOS_Obj.Insert_tblOOS_LabError_Instruments();
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                OOS_Obj.srno = Convert.ToInt32(dgv2[0, i].Value);
                OOS_Obj.parameters = dgv2[1, i].Value.ToString();
                OOS_Obj.observations = dgv2[2, i].Value.ToString();
                OOS_Obj.comments = Convert.ToString(dgv2[3, i].Value);

                bool res = OOS_Obj.Insert_tblOOS_LabDetails();

                if (i == 7)
                {
                    if (OOS_Obj.observations == "Yes")
                    {
                        DataSet DSInstrments = new DataSet();
                        DSInstrments = OOS_Obj.Select_LabDetailsID_tblOOS_LabDetails();
                        if (DSInstrments.Tables[0].Rows.Count > 0)
                        {
                            OOS_Obj.labdetailsid = Convert.ToInt64(DSInstrments.Tables[0].Rows[0]["LabDetailsID"]);
                            for (int ins = 0; ins < dgvSolution.Rows.Count - 1; ins++)
                            {
                                OOS_Obj.solutionused = Convert.ToString(dgvSolution[0, ins].Value);
                                OOS_Obj.validuptodate = dgvSolution[1, ins].Value.ToString();
                                OOS_Obj.strength = Convert.ToString(dgvSolution[2, ins].Value);

                                bool r = OOS_Obj.STP_Insert_tblOOS_LabError_Solution();
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < dgv3.Rows.Count; i++)
            {
                OOS_Obj.srno = Convert.ToInt32(dgv3[0, i].Value);
                OOS_Obj.parameters = dgv3[1, i].Value.ToString();
                OOS_Obj.observations = dgv3[2, i].Value.ToString();
                OOS_Obj.comments = Convert.ToString(dgv3[3, i].Value);

                bool res = OOS_Obj.Insert_tblOOS_LabDetails();
            }

            for (int i = 0; i < dgv4.Rows.Count; i++)
            {
                OOS_Obj.parameters = dgv4[1, i].Value.ToString();
                OOS_Obj.observations = dgv4[2, i].Value.ToString();
                OOS_Obj.comments = Convert.ToString(dgv4[3, i].Value);

                bool res = OOS_Obj.Insert_tblOOS_Chromatography();
            }

            for (int i = 0; i < dgv5.Rows.Count; i++)
            {
                OOS_Obj.parameters = dgv5[1, i].Value.ToString();
                OOS_Obj.observations = dgv5[2, i].Value.ToString();
                OOS_Obj.comments = Convert.ToString(dgv5[3, i].Value);

                bool res = OOS_Obj.Insert_tblOOS_LabErrorIdentified();
            }

            OOS_Obj.result1 = txtLabErrorResult1.Text.Trim();
            OOS_Obj.result2 = txtLabErrorResult2.Text.Trim();
            OOS_Obj.average = txtLabErrorAverage.Text.Trim();
            OOS_Obj.repeatability = txtLabErrorRepeatability.Text.Trim();
            OOS_Obj.conculsion = cmbLabErrorConclusion.Text;
            OOS_Obj.createdby = FrmMain.LoginID;
            OOS_Obj.completionDate = dtpComplationdate.Value.ToShortDateString();
            OOS_Obj.qcanalyst = Convert.ToInt64(cmbLabErrorQCAnalystName.SelectedValue);
            bool result = OOS_Obj.Insert_Update_tblOOS_LabError();

            if (result)
                MessageBox.Show("Record Saved Successfully.");
        }

        public void Bind_LabErrorDetails_Information()
        {
            DataSet dsLabErrorDetails = new DataSet();
            dsLabErrorDetails = OOS_Obj.Select_tblOOS_LabDetails();
            if (dsLabErrorDetails.Tables[0].Rows.Count > 0)
            {
                //dgv1[2, 0].Value = "Yes";
                //dgv1[3, 0].Value = "123";
                int no = 0;
                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    dgv1[2, i].Value = dsLabErrorDetails.Tables[0].Rows[no]["Observations"].ToString();
                    dgv1[3, i].Value = dsLabErrorDetails.Tables[0].Rows[no]["Comments"].ToString();
                    no++;
                }
                for (int i = 0; i < dgv2.Rows.Count; i++)
                {
                    dgv2[2, i].Value = dsLabErrorDetails.Tables[0].Rows[no]["Observations"].ToString();
                    dgv2[3, i].Value = dsLabErrorDetails.Tables[0].Rows[no]["Comments"].ToString();
                    no++;
                }
                for (int i = 0; i < dgv3.Rows.Count; i++)
                {
                    dgv3[2, i].Value = dsLabErrorDetails.Tables[0].Rows[no]["Observations"].ToString();
                    dgv3[3, i].Value = dsLabErrorDetails.Tables[0].Rows[no]["Comments"].ToString();
                    no++;
                }

                if (dsLabErrorDetails.Tables[0].Rows[33]["Observations"].ToString() == "Yes")
                {
                    txtLabErrorResult1.Enabled = true;
                    txtLabErrorResult2.Enabled = true;


                    lblretest1.Visible = true;
                    lblretest2.Visible = true;
                    lblretestAvg.Visible = true;
                    lblretestrepeatability.Visible = true;
                    txtLabErrorResult1.Visible = true;
                    txtLabErrorResult2.Visible = true;
                    txtLabErrorAverage.Visible = true;
                    txtLabErrorRepeatability.Visible = true;
                }

            }
            if (dsLabErrorDetails.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < dgv4.Rows.Count; i++)
                {
                    dgv4[2, i].Value = dsLabErrorDetails.Tables[1].Rows[i]["Observations"].ToString();
                    dgv4[3, i].Value = dsLabErrorDetails.Tables[1].Rows[i]["Comments"].ToString();
                }
            }
            if (dsLabErrorDetails.Tables[2].Rows.Count > 0)
            {
                for (int i = 0; i < dgv5.Rows.Count; i++)
                {
                    dgv5[2, i].Value = dsLabErrorDetails.Tables[2].Rows[i]["Observations"].ToString();
                    dgv5[3, i].Value = dsLabErrorDetails.Tables[2].Rows[i]["Comments"].ToString();
                }
            }
            if (dsLabErrorDetails.Tables[3].Rows.Count > 0)
            {
                txtLabErrorResult1.Text = dsLabErrorDetails.Tables[3].Rows[0]["Result1"].ToString();
                txtLabErrorResult2.Text = dsLabErrorDetails.Tables[3].Rows[0]["Result2"].ToString();
                txtLabErrorAverage.Text = dsLabErrorDetails.Tables[3].Rows[0]["Average"].ToString();
                txtLabErrorRepeatability.Text = dsLabErrorDetails.Tables[3].Rows[0]["Repeatability"].ToString();
                cmbLabErrorConclusion.Text = dsLabErrorDetails.Tables[3].Rows[0]["Conculsion"].ToString();
                cmbLabErrorQCAnalystName.SelectedValue = Convert.ToInt64(dsLabErrorDetails.Tables[3].Rows[0]["QCAnalyst"]);
                dtpComplationdate.Value = Convert.ToDateTime(dsLabErrorDetails.Tables[3].Rows[0]["CompletionDate"]);
            }

            if (dsLabErrorDetails.Tables[4].Rows.Count > 0)
            {
                if (dsLabErrorDetails.Tables[4].Rows[0]["ReSample"].ToString() == "Yes")
                    rbtReSamplingYes.Checked = true;
                if (dsLabErrorDetails.Tables[4].Rows[0]["ReSample"].ToString() == "No")
                    rbtReSamplingNo.Checked = true;

                txtReSamplingResultsForRetestingResult1.Text = dsLabErrorDetails.Tables[4].Rows[0]["Result1"].ToString();
                txtReSamplingResultsForRetestingResult2.Text = dsLabErrorDetails.Tables[4].Rows[0]["Result2"].ToString();
                txtReSamplingResultsForRetestingResult1Average1_2.Text = dsLabErrorDetails.Tables[4].Rows[0]["Average"].ToString();
                txtReSamplingResultsForRetestingRepeatabilityNMT.Text = dsLabErrorDetails.Tables[4].Rows[0]["Repeatablity"].ToString();
                cmbReSamplingQCAnalystName.SelectedValue = Convert.ToInt64(dsLabErrorDetails.Tables[4].Rows[0]["QCAnalyst"]);
                dtpReSamplingCompletionDate.Value = Convert.ToDateTime(dsLabErrorDetails.Tables[4].Rows[0]["CompletionDate"]);
                txtReSamplingConclusion.Text = dsLabErrorDetails.Tables[4].Rows[0]["Conclusion"].ToString();
                txtReSamplingSimulationTestingConclusion.Text = dsLabErrorDetails.Tables[4].Rows[0]["Simulating"].ToString();
                txtReSamplingRetest1.Text = dsLabErrorDetails.Tables[4].Rows[0]["ResonResult1"].ToString();
                txtReSamplingRetest2.Text = dsLabErrorDetails.Tables[4].Rows[0]["ResonResult2"].ToString();
                txtReSamplingAverage.Text = dsLabErrorDetails.Tables[4].Rows[0]["ResonAverage"].ToString();
                txtReSamplingRepeatability.Text = dsLabErrorDetails.Tables[4].Rows[0]["ResonRepeatability"].ToString();
                txtReSamplingQualityControlHeadFinaleRemark.Text = dsLabErrorDetails.Tables[4].Rows[0]["FinalRemark"].ToString();
                cmbReSamplingOOSValidInvalid.Text = dsLabErrorDetails.Tables[4].Rows[0]["OOSValid"].ToString();
                cmbReSamplingProceedformanufacturingInvestment.Text = dsLabErrorDetails.Tables[4].Rows[0]["Proceed"].ToString();
                cmbReSamplingHeadQualityControl.SelectedValue = Convert.ToInt64(dsLabErrorDetails.Tables[4].Rows[0]["HeadQualityControl"]);
                dtpReSamplingSimulationCompletionDate.Value = Convert.ToDateTime(dsLabErrorDetails.Tables[4].Rows[0]["ResonCompletionDate"]);

            }
            if (dsLabErrorDetails.Tables[5].Rows.Count > 0)
            {
                for (int i = 0; i < dsLabErrorDetails.Tables[5].Rows.Count; i++)
                {
                    dgvInstruments.Rows.Add();
                    dgvInstruments[0, i].Value = dsLabErrorDetails.Tables[5].Rows[i]["InstrumentUsed"].ToString();
                    dgvInstruments[1, i].Value = Convert.ToDateTime(dsLabErrorDetails.Tables[5].Rows[i]["CalibrationDue"]);//.ToString();

                }
            }
            if (dsLabErrorDetails.Tables[6].Rows.Count > 0)
            {
                for (int i = 0; i < dsLabErrorDetails.Tables[6].Rows.Count; i++)
                {
                    dgvSolution.Rows.Add();
                    dgvSolution[0, i].Value = dsLabErrorDetails.Tables[6].Rows[i]["SolutionUsed"].ToString();
                    dgvSolution[1, i].Value = Convert.ToDateTime(dsLabErrorDetails.Tables[6].Rows[i]["ValidUptoDate"]);//.ToString();
                    dgvSolution[2, i].Value = dsLabErrorDetails.Tables[6].Rows[i]["Strength"].ToString();

                }
            }

        }

        public void laberrorresult()
        {
            if (txtLabErrorResult1.Text.Trim() != "" && txtLabErrorResult2.Text.Trim() != "")
            {
                double Min = 0.0, Max = 0.0;
                double num1 = Convert.ToDouble(txtLabErrorResult1.Text.Trim());
                double num2 = Convert.ToDouble(txtLabErrorResult2.Text.Trim());
                double Average = 0.0, Repeatability = 0.0;

                if (num1 > num2)
                {
                    Max = num1;
                    Min = num2;
                }
                else
                {
                    Max = num2;
                    Min = num1;
                }

                Average = ((Min + Max) / 2);
                txtLabErrorAverage.Text = Average.ToString("f2");

                Repeatability = ((Max - Min) * 100) / Min;

                if (Repeatability <= 1.3)
                    txtLabErrorRepeatability.BackColor = Color.LightGreen;
                else
                    txtLabErrorRepeatability.BackColor = Color.Red;

                txtLabErrorRepeatability.Text = Repeatability.ToString("f2");
            }
        }

        private void txtLabErrorResult1_Leave(object sender, EventArgs e)
        {
            laberrorresult();
        }

        private void txtLabErrorResult2_Leave(object sender, EventArgs e)
        {
            laberrorresult();
        }

        public void ReSamplingResults()
        {
            if (txtReSamplingResultsForRetestingResult1.Text.Trim() != "" && txtReSamplingResultsForRetestingResult2.Text.Trim() != "")
            {
                double Min = 0.0, Max = 0.0;
                double num1 = Convert.ToDouble(txtReSamplingResultsForRetestingResult1.Text.Trim());
                double num2 = Convert.ToDouble(txtReSamplingResultsForRetestingResult2.Text.Trim());
                double Average = 0.0, Repeatability = 0.0;

                if (num1 > num2)
                {
                    Max = num1;
                    Min = num2;
                }
                else
                {
                    Max = num2;
                    Min = num1;
                }

                Average = ((Min + Max) / 2);
                txtReSamplingResultsForRetestingResult1Average1_2.Text = Average.ToString("f2");

                Repeatability = ((Max - Min) * 100) / Min;

                if (Repeatability <= 1.3)
                    txtReSamplingResultsForRetestingRepeatabilityNMT.BackColor = Color.LightGreen;
                else
                    txtReSamplingResultsForRetestingRepeatabilityNMT.BackColor = Color.Red;

                txtReSamplingResultsForRetestingRepeatabilityNMT.Text = Repeatability.ToString("f2");
            }
        }

        public void ReSamplingRetestResults()
        {
            if (txtReSamplingRetest1.Text.Trim() != "" && txtReSamplingRetest2.Text.Trim() != "")
            {
                double Min = 0.0, Max = 0.0;
                double num1 = Convert.ToDouble(txtReSamplingRetest1.Text.Trim());
                double num2 = Convert.ToDouble(txtReSamplingRetest2.Text.Trim());
                double Average = 0.0, Repeatability = 0.0;

                if (num1 > num2)
                {
                    Max = num1;
                    Min = num2;
                }
                else
                {
                    Max = num2;
                    Min = num1;
                }

                Average = ((Min + Max) / 2);
                txtReSamplingAverage.Text = Average.ToString("f2");

                Repeatability = ((Max - Min) * 100) / Min;

                if (Repeatability <= 1.3)
                    txtReSamplingRepeatability.BackColor = Color.LightGreen;
                else
                    txtReSamplingRepeatability.BackColor = Color.Red;

                txtReSamplingRepeatability.Text = Repeatability.ToString("f2");
            }
        }

        private void txtReSamplingResultsForRetestingResult1_Leave(object sender, EventArgs e)
        {
            ReSamplingResults();
        }

        private void txtReSamplingResultsForRetestingResult2_Leave(object sender, EventArgs e)
        {
            ReSamplingResults();
        }

        private void txtReSamplingRetest1_Leave(object sender, EventArgs e)
        {
            ReSamplingRetestResults();
        }

        private void txtReSamplingRetest2_Leave(object sender, EventArgs e)
        {
            ReSamplingRetestResults();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 8)
            {
                if (e.ColumnIndex == 2)
                {

                    //MessageBox.Show (dgv1[e.ColumnIndex, e.RowIndex].Value.ToString());
                    //if (dgv1[e.ColumnIndex, e.RowIndex].Value.ToString() == "Yes")
                    //{

                    //}
                }

            }
        }
        DataGridViewCell currentCell;
        DataGridViewRow currentRow;
        string check = "";
        private void dgv1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                check = "";
                currentCell = this.dgv1.CurrentCell;
                currentRow = this.dgv1.CurrentRow;
                if (currentCell.RowIndex == 8)
                {
                    if (currentCell.ColumnIndex == 2)
                    {

                        //MessageBox.Show(dgv1[currentCell.ColumnIndex, currentCell.RowIndex].Value.ToString());
                        check = "popupddl";
                        ((ComboBox)e.Control).SelectionChangeCommitted -= new EventHandler(cboDgvHardware_SelectionChanged);
                        ((ComboBox)e.Control).SelectionChangeCommitted += new EventHandler(cboDgvHardware_SelectionChanged);
                    }
                }


            }
        }

        private void cboDgvHardware_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (check == "popupddl")
                {
                    // string result is the selected text of the combo box
                    // int row is the row index that the selected combo box lives
                    string result = ((ComboBox)sender).SelectedItem.ToString();
                    // int row = ????
                    if (result == "Yes")
                    {
                        pnlInstruments.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            { }
        }

        private void btnpnlInstrumentsClose_Click(object sender, EventArgs e)
        {
            pnlInstruments.Visible = false;
        }

        private void btnSolutionClose_Click(object sender, EventArgs e)
        {
            pnlSolution.Visible = false;
        }

        private void dgv2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                check = "";
                currentCell = this.dgv2.CurrentCell;
                currentRow = this.dgv2.CurrentRow;
                if (currentCell.RowIndex == 7)
                {
                    if (currentCell.ColumnIndex == 2)
                    {

                        //MessageBox.Show(dgv1[currentCell.ColumnIndex, currentCell.RowIndex].Value.ToString());
                        check = "popupddl2";
                        ((ComboBox)e.Control).SelectionChangeCommitted -= new EventHandler(CmbDgvHardware_SelectionChanged);
                        ((ComboBox)e.Control).SelectionChangeCommitted += new EventHandler(CmbDgvHardware_SelectionChanged);
                    }
                }


            }
        }

        private void CmbDgvHardware_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (check == "popupddl2")
                {
                    // string result is the selected text of the combo box
                    // int row is the row index that the selected combo box lives
                    string result = ((ComboBox)sender).SelectedItem.ToString();
                    // int row = ????
                    if (result == "Yes")
                    {
                        pnlSolution.Visible = true;
                    }

                }
            }
            catch (Exception ex)
            { }
        }

        private void btnMIExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMISave_Click(object sender, EventArgs e)
        {
            if (OOS_Obj.oosid == null || OOS_Obj.oosid == 0)
            {
                MessageBox.Show("Please Saved OOS Detail Tab First.");
                tabOOS.SelectedIndex = 0;
                return;
            }
            if (cmbReSamplingProceedformanufacturingInvestment.Text != "Yes")
            {
                MessageBox.Show("Please select Proceed for manufacturing Investment is :- 'Yes'");
                tabOOS.SelectedIndex = -1;
                cmbReSamplingProceedformanufacturingInvestment.Focus();
                return;
            }
            for (int i = 0; i < dgvMI.Rows.Count; i++)
            {
                OOS_Obj.srno = Convert.ToInt32(dgvMI[0, i].Value);
                OOS_Obj.parameters = dgvMI[1, i].Value.ToString();
                OOS_Obj.observations = dgvMI[2, i].Value.ToString();
                OOS_Obj.comments = Convert.ToString(dgvMI[3, i].Value);

                bool res = OOS_Obj.Insert_Update_tblOOS_MI_Parameters();
            }

            OOS_Obj.summary = txtMISummary.Text.Trim();
            OOS_Obj.finaldecision = txtMIFinal.Text.Trim();
            OOS_Obj.upmanager = Convert.ToInt64(cmbMIUpmanager.SelectedValue);
            OOS_Obj.processexpert = Convert.ToInt64(cmbMIProcessExpert.SelectedValue);
            OOS_Obj.qualityhead = Convert.ToInt64(cmbMIQualityHead.SelectedValue);
            OOS_Obj.completionDate = dtpMICompletionDate.Value.ToShortDateString();
            OOS_Obj.createdby = FrmMain.LoginID;

            bool Result = OOS_Obj.Insert_Update_tblOOS_MIDetails();

            if (Result)
                MessageBox.Show("Record Saved Successfully.");

        }

        private void txtNMTResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtResult1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtResult2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDifferenceNMTResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtInitialResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtRe_AnalysisResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtLabErrorResult1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtLabErrorResult2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtReSamplingResultsForRetestingResult1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtReSamplingResultsForRetestingResult2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtReSamplingRetest1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtReSamplingRetest2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        public void Bind_ManufacturingInvestigation_Information()
        {
            DataSet dsMIDetails = new DataSet();
            dsMIDetails = OOS_Obj.Select_tblOOS_MIDetails();
            if (dsMIDetails.Tables[0].Rows.Count > 0)
            {
                txtMISummary.Text = dsMIDetails.Tables[0].Rows[0]["Summary"].ToString();
                txtMIFinal.Text = dsMIDetails.Tables[0].Rows[0]["FinalDecision"].ToString();
                cmbMIProcessExpert.SelectedValue = Convert.ToInt64(dsMIDetails.Tables[0].Rows[0]["ProcessExpert"]);
                cmbMIQualityHead.SelectedValue = Convert.ToInt64(dsMIDetails.Tables[0].Rows[0]["QualityHead"]);
                cmbMIUpmanager.SelectedValue = Convert.ToInt64(dsMIDetails.Tables[0].Rows[0]["UpManager"]);
                dtpMICompletionDate.Value = Convert.ToDateTime(dsMIDetails.Tables[0].Rows[0]["CompletionDate"]);
            }
            if (dsMIDetails.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < dgvMI.Rows.Count; i++)
                {
                    dgvMI[2, i].Value = dsMIDetails.Tables[1].Rows[i]["Observation"].ToString();
                    dgvMI[3, i].Value = dsMIDetails.Tables[1].Rows[i]["Comments"].ToString();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (OOS_Obj.oosid == null || OOS_Obj.oosid == 0)
            {
                MessageBox.Show("Please Saved OOS Detail Tab First.");
                tabOOS.SelectedIndex = 0;
                return;
            }

            FrmOOSReport frm = new FrmOOSReport("OOS Report", OOS_Obj.oosid);
            //frm.MdiParent = this;
            frm.Show();
        }

        private void btnMIPrev_Click(object sender, EventArgs e)
        {
            tabOOS.SelectedIndex = tabOOS.SelectedIndex - 1;
        }

        private void tabOOS_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                //This line of code will help you to change the apperance like size,name,style.
                Font f;
                //For background color
                Brush backBrush;
                //For forground color
                Brush foreBrush;

                //This construct will hell you to deside which tab page have current focus
                //to change the style.
                if (e.Index == this.tabOOS.SelectedIndex)
                {
                    //This line of code will help you to change the apperance like size,name,style.
                    //f = new Font(e.Font, FontStyle.Bold | FontStyle.Bold);
                    //f = new Font(e.Font, FontStyle.Bold);
                    f = new Font(e.Font, FontStyle.Regular);

                    //backBrush = new System.Drawing.SolidBrush(Color.DarkGray);
                    backBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208))))));
                    foreBrush = Brushes.White;
                }
                else
                {
                    f = e.Font;
                    backBrush = new SolidBrush(e.BackColor);
                    foreBrush = new SolidBrush(e.ForeColor);
                }

                //To set the alignment of the caption.
                string tabName = this.tabOOS.TabPages[e.Index].Text;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;

                //Thsi will help you to fill the interior portion of
                //selected tabpage.
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                Rectangle r = e.Bounds;
                r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
                e.Graphics.DrawString(tabName, f, foreBrush, r, sf);

                sf.Dispose();
                if (e.Index == this.tabOOS.SelectedIndex)
                {
                    f.Dispose();
                    backBrush.Dispose();
                }
                else
                {
                    backBrush.Dispose();
                    foreBrush.Dispose();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void txtNMTResult_Leave(object sender, EventArgs e)
        {

        }

        private void txtReferenceSampleInitialResult_Leave(object sender, EventArgs e)
        {
            txtInitialResult.Text = txtReferenceSampleInitialResult.Text;
        }

        private void txtReferenceSampleInitialResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dgv5_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                check = "";
                currentCell = this.dgv3.CurrentCell;
                currentRow = this.dgv3.CurrentRow;
                if (currentCell.RowIndex == 16)
                {
                    if (currentCell.ColumnIndex == 2)
                    {

                        //MessageBox.Show(dgv1[currentCell.ColumnIndex, currentCell.RowIndex].Value.ToString());
                        check = "popupddl5";
                        ((ComboBox)e.Control).SelectionChangeCommitted -= new EventHandler(CmbDgv5Hardware_SelectionChanged);
                        ((ComboBox)e.Control).SelectionChangeCommitted += new EventHandler(CmbDgv5Hardware_SelectionChanged);
                    }
                }


            }
        }

        private void CmbDgv5Hardware_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (check == "popupddl5")
                {
                    // string result is the selected text of the combo box
                    // int row is the row index that the selected combo box lives
                    string result = ((ComboBox)sender).SelectedItem.ToString();
                    // int row = ????
                    if (result == "Yes")
                    {
                        txtLabErrorResult1.Enabled = true;
                        txtLabErrorResult2.Enabled = true;


                        lblretest1.Visible = true;
                        lblretest2.Visible = true;
                        lblretestAvg.Visible = true;
                        lblretestrepeatability.Visible = true;
                        txtLabErrorResult1.Visible = true;
                        txtLabErrorResult2.Visible = true;
                        txtLabErrorAverage.Visible = true;
                        txtLabErrorRepeatability.Visible = true;
                    }
                    else
                    {
                        txtLabErrorResult1.Enabled = false;
                        txtLabErrorResult2.Enabled = false;

                        lblretest1.Visible = false;
                        lblretest2.Visible = false;
                        lblretestAvg.Visible = false;
                        lblretestrepeatability.Visible = false;
                        txtLabErrorResult1.Visible = false;
                        txtLabErrorResult2.Visible = false;
                        txtLabErrorAverage.Visible = false;
                        txtLabErrorRepeatability.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void rbtReSamplingNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtReSamplingNo.Checked == true)
            {
                txtReSamplingSimulationTestingConclusion.Enabled = false;
                txtReSamplingRetest1.Enabled = false;
                txtReSamplingRetest2.Enabled = false;

                grpSimulation.Visible = false;
                lblSimlutiontestingConclusion.Visible = false;
                txtReSamplingSimulationTestingConclusion.Visible = false;
            }
        }

        private void rbtReSamplingYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtReSamplingYes.Checked == true)
            {
                txtReSamplingSimulationTestingConclusion.Enabled = true;
                txtReSamplingRetest1.Enabled = true;
                txtReSamplingRetest2.Enabled = true;

                grpSimulation.Visible = true;
                lblSimlutiontestingConclusion.Visible = true;
                txtReSamplingSimulationTestingConclusion.Visible = true;
            }
        }
    }



}
