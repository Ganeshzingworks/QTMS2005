using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;
using BusinessFacade.Transactions;

namespace QTMS.Forms
{
    public partial class FrmMettlerManualWeight : Form
    {
        public FrmMettlerManualWeight()
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
        long FGNo = 0, LNo = 0;
        int SetOfSample = 0;
        bool ApplicationFlag = false;
        #endregion

        private void FrmMettlerManualWeight_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            DtpDate.Value = Comman_Class_Obj.Select_ServerDate();
            Bind_Details();
            GetTimeIntervals();

            PnlGreen1.BackColor = PnlGreen2.BackColor = Color.Green;
            PnlRed1.BackColor = PnlRed2.BackColor = Color.Red;
            PnlYellow1.BackColor = PnlYellow2.BackColor = PnlYellow3.BackColor = Color.Yellow;
        }

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = FinishedGoodTest_Class_Obj.Select_PendingFinishedGoodDetails();
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

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtAvg.Text = txtMax.Text = txtMin.Text = txtR.Text = txtSV.Text = "";
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "" && cmbDetails.SelectedIndex != 0)
            {
                FinishedGoodTest_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);


                DataSet dsPkgBulk = new DataSet();
                dsPkgBulk = FinishedGoodTest_Class_Obj.Select_FinishedGood_PackingBulkTestDetails();
                if (dsPkgBulk.Tables[0].Rows.Count > 0)
                {
                    Bind_FormulaNo(dsPkgBulk);
                }

                DataTable dt = new DataTable();
                dt = SPCMaster_Class_Obj.Select_tblMettlerSPCMaster_ByID(FinishedGoodTest_Class_Obj.fgtlfid);
                if (dt.Rows.Count > 0)
                {
                    SPCMaster_Class_Obj.fgno = FGNo = Convert.ToInt64(dt.Rows[0]["FGNoFG"].ToString());
                    SPCMaster_Class_Obj.lno = LNo = Convert.ToInt64(dt.Rows[0]["LNoFG"].ToString());

                    //DataTable dtLine = new DataTable();
                    //dtLine = LineMaster_Class_Obj.Select_tblLineMaster_ByLNo(SPCMaster_Class_Obj.lno);
                    //if (dtLine.Rows.Count > 0)
                    //{
                    //    if (dtLine.Rows[0]["SetofSample"].ToString() == "")
                    //        SetOfSample = 0;
                    //    else
                    //        SetOfSample = Convert.ToInt32(dtLine.Rows[0]["SetofSample"].ToString());
                    //}
                }

                lblAverageUSL.Text = lblAverageUCL.Text = lblAverageUpperTol.Text = lblAverageLSL.Text = lblAverageLCL.Text = lblAverageLowerTol.Text = lblAverageTarget.Text = lblDispersionTarget.Text = lblDispersionUCL.Text = "0";
            }
        }

        public void Bind_FormulaNo(DataSet DsFormula)
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = DsFormula;
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbFormulaNo.DataSource = ds.Tables[0];
                CmbFormulaNo.ValueMember = "FNo";
                CmbFormulaNo.DisplayMember = "FormulaNo";
            }

        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbFormulaNo.SelectedValue != null && CmbFormulaNo.SelectedValue.ToString() != "" && CmbFormulaNo.SelectedIndex != 0)
            {
                //FGRefMgmtTransaction FGRefMgmtTransaction_obj = new FGRefMgmtTransaction();
                //DataTable dt = new DataTable();
                //FGRefMgmtTransaction_obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                //FGRefMgmtTransaction_obj.fgno = FGRefMgmtTransaction_obj.Select_FGNO_FGTLFID_FGRegMgt();


                FGRefMgmtTransaction FGRefMgmtTransaction_obj = new FGRefMgmtTransaction();
                DataTable dt = new DataTable();
                FGRefMgmtTransaction_obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                FGRefMgmtTransaction_obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);

                if (Convert.ToInt64(cmbDetails.SelectedValue) == 0)
                {
                    MessageBox.Show("Select Details.");
                    cmbDetails.Focus();
                    return;
                }

                dt = FGRefMgmtTransaction_obj.Select_Type_FGTLFID_Fno();
                lbltype.Text = dt.Rows[0][0].ToString();
                lbltype.ForeColor = Color.Red;
                lbltype.Visible = true;

                SPCMaster_Class_Obj.fno = FGRefMgmtTransaction_obj.fno;
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
            Mettler_Class_Obj.mettlerdate = DtpDate.Value.ToShortDateString();
            Mettler_Class_Obj.mettlertime = CmbTime.Text;
            Mettler_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
            Mettler_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);

            DataSet dsMettler = new DataSet();
            dsMettler = Mettler_Class_Obj.Select_tblMettler();
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

        private void CmbTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbFormulaNo_SelectionChangeCommitted(sender, e);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click_1(object sender, EventArgs e)
        {
            lbltype.Visible = false;
            lbltype.Text = "";
            txtCurrentWeight.Text = "";
            CmbTime.Text = "12:00 AM";
            Mettler_Class_Obj.mettlerid = 0;
            cmbDetails.SelectedIndex = 0;
            CmbFormulaNo.SelectedIndex = 0;
            lblTareWeight.Text = "";
            lblAverageUSL.Text = lblAverageUCL.Text = lblAverageUpperTol.Text = lblAverageLSL.Text = lblAverageLCL.Text = lblAverageLowerTol.Text = lblAverageTarget.Text = lblDispersionTarget.Text = lblDispersionUCL.Text = "0";
            txtAvg.Text = txtSV.Text = txtMax.Text = txtMin.Text = txtR.Text = txtGAP.Text = string.Empty;
        }

        private void txtAvg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(cmbDetails.SelectedValue) == 0)
            {
                MessageBox.Show("Select Details.");
                cmbDetails.Focus();
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
                   BtnReset_Click_1(sender, e);
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txtAvg_Leave(object sender, EventArgs e)
        {
            GetDispersionandGAP();
        }
    }
}