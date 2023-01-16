using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using QTMS.Tools;

namespace QTMS.Mettler
{
    public partial class FrmMettlerManualWeight_New : Form
    {
        public FrmMettlerManualWeight_New()
        {
            InitializeComponent();
        }

        #region variables
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        BusinessFacade.Mettler_Class Mettler_Class_Obj = new BusinessFacade.Mettler_Class();
        SPCMaster_Class SPCMaster_Class_Obj = new SPCMaster_Class();
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        long FGNo = 0, LNo = 0;
        int SetOfSample = 0;
        bool ApplicationFlag = false;
        #endregion

        private void FrmMettlerManualWeight_New_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            DtpTrackCode.Value = Comman_Class_Obj.Select_ServerDate();
            //Bind_Details();
            GetTimeIntervals();
            Bind_LineNo();
            Bind_FGCode();

            PnlGreen1.BackColor = PnlGreen2.BackColor = Color.Green;
            PnlRed1.BackColor = PnlRed2.BackColor = Color.Red;
            PnlYellow1.BackColor = PnlYellow2.BackColor = PnlYellow3.BackColor = Color.Yellow;
        }

        public List<string> GetTimeIntervals()
        {
            List<string> timeIntervals = new List<string>();
            TimeSpan startTime = new TimeSpan(0, 0, 0);
            DateTime startDate = new DateTime(DateTime.MinValue.Ticks); // Date to be used to get shortTime format.
            for (int i = 0; i < 24; i++)
            {
                int minutesToBeAdded = 60 * i;      // Increasing minutes by 30 minutes interval
                TimeSpan timeToBeAdded = new TimeSpan(0, minutesToBeAdded, 0);
                TimeSpan t = startTime.Add(timeToBeAdded);
                DateTime result = startDate + t;
                timeIntervals.Add(result.ToShortTimeString());      // Use Date.ToShortTimeString() method to get the desired format                
            }

            CmbTime.DataSource = timeIntervals;
            //CmbTime.DataBind();

            return timeIntervals;
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Bind Line No from line No master
        /// </summary>
        DataSet Lineds;
        public void Bind_LineNo()
        {
            Lineds = new DataSet();
            DataRow dr;
            Lineds = LineMaster_Class_Obj.Select_LineMaster();
            dr = Lineds.Tables[0].NewRow();
            dr["LineDesc"] = "--Select--";
            dr["LNo"] = "0";
            Lineds.Tables[0].Rows.InsertAt(dr, 0);

            if (Lineds.Tables[0].Rows.Count > 0)
            {

                CmbLineNo.DataSource = Lineds.Tables[0];
                CmbLineNo.DisplayMember = "LineDesc";
                CmbLineNo.ValueMember = "LNo";
            }
        }

        /// <summary>
        /// Bind FG Code from FG Code master
        /// </summary>
        DataSet FGds;
        public void Bind_FGCode()
        {
            FGds = new DataSet();
            DataRow dr;
            FGds = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster();
            dr = FGds.Tables[0].NewRow();
            dr["FGCode"] = "--Select--";
            dr["FGNo"] = "0";
            FGds.Tables[0].Rows.InsertAt(dr, 0);

            if (Lineds.Tables[0].Rows.Count > 0)
            {

                CmbFgCode.DataSource = FGds.Tables[0];
                CmbFgCode.DisplayMember = "FGCode";
                CmbFgCode.ValueMember = "FGNo";
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtAvg.Text = txtMax.Text = txtMin.Text = txtR.Text = txtSV.Text = txtGAP.Text = "";
        }

        private void CmbFgCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataRow dr;
                FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                DataSet ds2 = new DataSet();
                ds2 = FinishedGoodMaster_Class_Obj.SELECT_tblFgMaster_FormulaNo();
                dr = ds2.Tables[0].NewRow();
                dr["FormulaNo"] = "--Select--";
                dr["FNo"] = "0";
                ds2.Tables[0].Rows.InsertAt(dr, 0);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    CmbFormulaNo.DataSource = ds2.Tables[0];
                    CmbFormulaNo.DisplayMember = "FormulaNo";
                    CmbFormulaNo.ValueMember = "FNo";
                }

                lblAverageUSL.Text = lblAverageUCL.Text = lblAverageUpperTol.Text = lblAverageLSL.Text = lblAverageLCL.Text = lblAverageLowerTol.Text = lblAverageTarget.Text = lblDispersionTarget.Text = lblDispersionUCL.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbFormulaNo.SelectedValue != null && CmbFormulaNo.SelectedValue.ToString() != "" && CmbFormulaNo.SelectedIndex != 0)
            {
                if (Convert.ToInt64(CmbFgCode.SelectedValue) == 0)
                {
                    MessageBox.Show("Select Fg Code.");
                    CmbFgCode.Focus();
                    return;
                }
                if (Convert.ToInt64(CmbLineNo.SelectedValue) == 0)
                {
                    MessageBox.Show("Select Line No.");
                    CmbLineNo.Focus();
                    return;
                }

                SPCMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                SPCMaster_Class_Obj.lno = Convert.ToInt64(CmbLineNo.SelectedValue);
                SPCMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                DataTable Dt = SPCMaster_Class_Obj.Select_tblMettlerSPCMaster_Exist();
                if (Dt.Rows.Count > 0)
                {
                    lblAverageUSL.Text = Dt.Rows[0]["AverageUSL"].ToString();
                    lblAverageUCL.Text = Dt.Rows[0]["AverageUCL"].ToString();
                    lblAverageUpperTol.Text = Dt.Rows[0]["AverageUpperTol"].ToString();
                    lblAverageLSL.Text = Dt.Rows[0]["AverageLSL"].ToString();
                    lblAverageLCL.Text = Dt.Rows[0]["AverageLCL"].ToString();
                    lblAverageLowerTol.Text = Dt.Rows[0]["AverageLowerTol"].ToString();
                    lblAverageTarget.Text = Dt.Rows[0]["AverageTarget"].ToString();

                    lblDispersionTarget.Text = Dt.Rows[0]["DispersionTarget"].ToString();
                    lblDispersionUCL.Text = Dt.Rows[0]["DispersionUSL"].ToString();
                }
                else
                {
                    lblAverageUSL.Text = lblAverageUCL.Text = lblAverageUpperTol.Text = lblAverageLSL.Text = lblAverageLCL.Text = lblAverageLowerTol.Text = lblAverageTarget.Text = lblDispersionTarget.Text = lblDispersionUCL.Text = "0";
                }
                GetMettlerWeightPreviousGrid();

                if (CheckManualExists())
                {
                    DialogResult dialogResult = MessageBox.Show("Record allready exists by manual entry. \r\nDo you want add new record ?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                }
                else if (CheckAutoExists())
                {
                    DialogResult dialogResult = MessageBox.Show("Record allready exists by Mettler/auto entry. \r\nDo you want add new record ?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                }
            }
        }

        public void GetMettlerWeightPreviousGrid()
        {
            Mettler_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
            Mettler_Class_Obj.trackcode = DtpTrackCode.Value.ToShortDateString();
            Mettler_Class_Obj.mettlertime = CmbTime.Text;
            Mettler_Class_Obj.lno = Convert.ToInt64(CmbLineNo.SelectedValue);
            Mettler_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);

            DataSet dsMettler = new DataSet();
            dsMettler = Mettler_Class_Obj.Select_tblMettler_New();
            if (dsMettler.Tables[0].Rows.Count > 0)
            {
                Mettler_Class_Obj.mettlerid = Convert.ToInt64(dsMettler.Tables[0].Rows[0]["MettlerID"]);
                if (dsMettler.Tables[0].Rows[0]["TareWeight"].ToString() != "")
                {
                    lblTareWeight.ForeColor = Color.Red;
                    lblTareWeight.Text = "Tare Weight :- " + dsMettler.Tables[0].Rows[0]["TareWeight"].ToString();
                    lblTareWeight.Visible = true;
                }
                else
                {
                    lblTareWeight.Text = "";
                    lblTareWeight.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Tare Weight not exists please do tare weight first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                //Mettler_Class_Obj.mettlerid = 0;
                //lblTareWeight.Text = "";
                //lblTareWeight.Visible = false;
            }



        }

        public bool CheckManualExists()
        {
            DataTable Dt = Mettler_Class_Obj.Select_tblMettlerAverage_ManualExists();
            if (Dt.Rows.Count > 0)
            {
                txtAvg.Text = Dt.Rows[0]["AVERAGE"].ToString();
                txtSV.Text = Dt.Rows[0]["STDDEV"].ToString();
                txtMax.Text = Dt.Rows[0]["M_MAX"].ToString();
                txtMin.Text = Dt.Rows[0]["M_MIN"].ToString();
                txtR.Text = Dt.Rows[0]["DISPERSION"].ToString();
                txtGAP.Text = Dt.Rows[0]["GAP"].ToString();

                return true;
            }
            else
                return false;
        }

        public bool CheckAutoExists()
        {
            DataTable Dt = Mettler_Class_Obj.Select_tblMettlerAverage_AutoExists();
            if (Dt.Rows.Count > 0)
            {
                txtAvg.Text = Dt.Rows[0]["AVERAGE"].ToString();
                txtSV.Text = Dt.Rows[0]["STDDEV"].ToString();
                txtMax.Text = Dt.Rows[0]["M_MAX"].ToString();
                txtMin.Text = Dt.Rows[0]["M_MIN"].ToString();
                txtR.Text = Dt.Rows[0]["DISPERSION"].ToString();
                txtGAP.Text = Dt.Rows[0]["GAP"].ToString();

                return true;
            }
            else
                return false;
        }

        private void CmbLineNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbFormulaNo_SelectionChangeCommitted(sender, e);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(CmbFgCode.SelectedValue) == 0)
            {
                MessageBox.Show("Select FG Code.");
                CmbFgCode.Focus();
                return;
            }
            if (Convert.ToInt64(CmbLineNo.SelectedValue) == 0)
            {
                MessageBox.Show("Select Line No.");
                CmbLineNo.Focus();
                return;
            }
            if (Convert.ToInt64(CmbFormulaNo.SelectedValue) == 0)
            {
                MessageBox.Show("Select FormulaNo.");
                CmbFormulaNo.Focus();
                return;
            }
            if (txtAvg.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter Average value.");
                txtAvg.Focus();
                return;
            }
            if (txtSV.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter STD DEV value.");
                txtSV.Focus();
                return;
            }
            if (txtMax.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter MAX value.");
                txtMax.Focus();
                return;
            }
            if (txtMin.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter MIN value.");
                txtMin.Focus();
                return;
            }


            try
            {
                Mettler_Class_Obj.average = txtAvg.Text.Trim();
                Mettler_Class_Obj.stddev = txtSV.Text.Trim();
                Mettler_Class_Obj.m_max = txtMax.Text.Trim();
                Mettler_Class_Obj.m_min = txtMin.Text.Trim();
                Mettler_Class_Obj.dispersion = txtR.Text.Trim();
                Mettler_Class_Obj.gap = txtGAP.Text.Trim();
                Mettler_Class_Obj.manualentry = 1;
                Mettler_Class_Obj.createdby = FrmMain.LoginID;

                bool Res = Mettler_Class_Obj.Insert_tblMettlerAverage_ByManualEntry();
                if (Res)
                {
                    MessageBox.Show("Record Saved Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAvg_Leave(object sender, EventArgs e)
        {
            GetDispersionandGAP();
        }

        public void GetDispersionandGAP()
        {
            if (txtAvg.Text != string.Empty && txtMax.Text != string.Empty && txtMin.Text != string.Empty && txtSV.Text != string.Empty)
            {
                double max = Convert.ToDouble(txtMax.Text);
                double min = Convert.ToDouble(txtMin.Text);
                double Dis = Math.Round((max - min), 1);
                txtR.Text = Convert.ToString(Dis);


                double Avg = Convert.ToDouble(txtAvg.Text);
                double Target = Convert.ToDouble(lblAverageTarget.Text);
                double GAP = Math.Round((Avg - Target), 1);
                txtGAP.Text = Convert.ToString(GAP);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtpTrackCode_ValueChanged(object sender, EventArgs e)
        {
            CmbFormulaNo.SelectedValue = 0;
        }
    }
}