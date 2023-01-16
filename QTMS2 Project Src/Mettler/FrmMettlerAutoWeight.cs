using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using BusinessFacade;
using QTMS.Tools;
using System.Text.RegularExpressions;

namespace QTMS.Mettler
{
    public partial class FrmMettlerAutoWeight : Form
    {
        private static SerialPort mySerialPort_2 = new SerialPort("COM2");
        public FrmMettlerAutoWeight()
        {
            InitializeComponent();

            mySerialPort_2.BaudRate = 9600;// 4800;//9600;
            mySerialPort_2.Parity = Parity.None;
            mySerialPort_2.StopBits = StopBits.One;
            mySerialPort_2.DataBits = 8;
            mySerialPort_2.DtrEnable = true;
            mySerialPort_2.RtsEnable = true;
            mySerialPort_2.ReadTimeout = 500;
            mySerialPort_2.WriteTimeout = 500;
            mySerialPort_2.Handshake = Handshake.None;
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

        private delegate void SetTextDeleg(string text);

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            mySerialPort_2.Close();
            this.Close();
        }

        private void FrmMettlerAutoWeight_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            DtpTrackCode.Value = Comman_Class_Obj.Select_ServerDate();
            dgCurrent.AutoGenerateColumns = false;

            GetTimeIntervals();
            Bind_LineNo();
            Bind_FGCode();

            PnlGreen1.BackColor = PnlGreen2.BackColor = Color.Green;
            PnlRed1.BackColor = PnlRed2.BackColor = Color.Red;
            PnlYellow1.BackColor = PnlYellow2.BackColor = PnlYellow3.BackColor = Color.Yellow;

            try
            {
                if (mySerialPort_2.IsOpen != true)
                    mySerialPort_2.Open();
                else
                {
                    mySerialPort_2.Close();
                    mySerialPort_2.Open();
                }
            }
            catch (Exception ex)
            {

            }

            mySerialPort_2.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs args)
        {
            SerialPort sp = (SerialPort)sender;
            if (sp.PortName == mySerialPort_2.PortName)
            {
                string data = mySerialPort_2.ReadLine();
                this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
            }
            //  MessageBox.Show("received: " + text);
        }
        private void si_DataReceived(string data)
        {

            string st = Regex.Replace(data, "[^-?\\d+\\.]", "");

            if (st == "" || st == "0.0")
            {
                MessageBox.Show("Weight on mettler device.");
                return;
            }

            string ProductWeight = "";
            ProductWeight = st;

            string TareWeight = lblTareWeight.Text;
            TareWeight = TareWeight.Replace("Tare Weight :- ", "");

            string ReadingTime = Comman_Class_Obj.Select_ServerDate().ToString("hh:mm tt");

            Mettler_Class_Obj.weight = ProductWeight;
            Mettler_Class_Obj.bulkweight = Convert.ToString((Convert.ToDouble(ProductWeight)) - (Convert.ToDouble(TareWeight)));
            Mettler_Class_Obj.weighttime = ReadingTime;
            Mettler_Class_Obj.createdby = FrmMain.LoginID;
            Mettler_Class_Obj.mettlertime = CmbTime.Text;

            Mettler_Class_Obj.Insert_tblMettlerWeight();

            GetMettlerWeightCurrentGrid();
            if (dgCurrent.Rows.Count >= SetOfSample)
                GetMINMAXAVG_StandardVariance();

            CmbTime.Enabled = false;
            CmbFgCode.Enabled = false;
            CmbLineNo.Enabled = false;
            DtpTrackCode.Enabled = false;
            CmbFormulaNo.Enabled = false;

        }

        public void GetMettlerWeightCurrentGrid()
        {
            DataSet ds = new DataSet();
            ds = Mettler_Class_Obj.Select_tblMettlerWeight();

            dgCurrent.DataSource = ds.Tables[0];
        }

        public void GetMINMAXAVG_StandardVariance()
        {
            try
            {


                DataSet dsMINMAXAVG = new DataSet();
                dsMINMAXAVG = Mettler_Class_Obj.Select_tblMettlerWeight_MINMAXAVG();
                if (dsMINMAXAVG.Tables[0].Rows.Count > 0)
                {
                    txtMin.Text = dsMINMAXAVG.Tables[0].Rows[0]["MIN"].ToString();
                    txtMax.Text = dsMINMAXAVG.Tables[0].Rows[0]["MAX"].ToString();
                    txtAvg.Text = dsMINMAXAVG.Tables[0].Rows[0]["AVG"].ToString();
                    txtR.Text = dsMINMAXAVG.Tables[0].Rows[0]["R"].ToString();
                }

                DataSet dsStandardVariance = new DataSet();
                dsStandardVariance = Mettler_Class_Obj.Select_tblMettlerWeight_StandardVariance();
                if (dsStandardVariance.Tables[0].Rows.Count > 0)
                {
                    //txtMean.Text = dsStandardVariance.Tables[0].Rows[0]["Mean"].ToString();
                    double val = Math.Round(Convert.ToDouble(dsStandardVariance.Tables[0].Rows[0]["Standard Variance"].ToString()), 1);
                    //txtSV.Text = (Math.Round(Convert.ToDouble(dsStandardVariance.Tables[0].Rows[0]["Standard Variance"].ToString())));  
                    txtSV.Text = Convert.ToString(val);
                }

                double Avg = Convert.ToDouble(txtAvg.Text);
                double Target = Convert.ToDouble(lblAverageTarget.Text);

                double GAP = Math.Round((Avg - Target), 1);
                txtGAP.Text = Convert.ToString(GAP);


                Insert_Update_MettlerAverageInfo();

                if (Avg >= Convert.ToDouble(lblAverageLCL.Text) && Avg <= Convert.ToDouble(lblAverageUCL.Text))//Green Zone
                { }
                else if (Avg >= Convert.ToDouble(lblAverageLSL.Text) && Avg < Convert.ToDouble(lblAverageLCL.Text))//Yellow Zone 
                {
                    MessageBox.Show("Please bring line in green zone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Avg > Convert.ToDouble(lblAverageUCL.Text) && Avg <= Convert.ToDouble(lblAverageUSL.Text))//Yellow Zone 
                {
                    MessageBox.Show("Please bring line in green zone.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Avg > Convert.ToDouble(lblAverageUSL.Text))//Red Zone 
                {
                    MessageBox.Show("Stop the line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Avg < Convert.ToDouble(lblAverageLSL.Text))//Red Zone 
                {
                    MessageBox.Show("Stop the line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (GAP > Convert.ToDouble(lblDispersionUCL.Text))
                {
                    DataTable dt = Mettler_Class_Obj.Select_tblMettlerAverage_DISPERSIONREMARK();
                    if (dt.Rows.Count > 0)
                    {
                        txtDispersionReason.Text = dt.Rows[0]["DISPERSIONREMARK"].ToString();
                    }
                    pnlDispersion.Visible = true;
                    txtDispersionReason.Focus();
                }
            }
            catch (Exception ex)
            {


            }
        }

        public void Insert_Update_MettlerAverageInfo()
        {
            Mettler_Class_Obj.average = txtAvg.Text.Trim();
            Mettler_Class_Obj.stddev = txtSV.Text.Trim();
            Mettler_Class_Obj.m_max = txtMax.Text.Trim();
            Mettler_Class_Obj.m_min = txtMin.Text.Trim();
            Mettler_Class_Obj.dispersion = txtR.Text.Trim();
            Mettler_Class_Obj.gap = txtGAP.Text.Trim();
            Mettler_Class_Obj.manualentry = 0;
            Mettler_Class_Obj.createdby = FrmMain.LoginID;

            Mettler_Class_Obj.Insert_Update_tblMettlerAverage_ByAutoEntry();
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
            lbltype.Visible = false;
            lbltype.Text = "";
            txtCurrentWeight.Text = "";
            CmbTime.Text = "12:00 AM";

            ApplicationFlag = false;
            CmbTime.Enabled = true;

            dgCurrent.DataSource = null;
            txtAvg.Text = txtMax.Text = txtMin.Text = txtR.Text = txtSV.Text = txtGAP.Text = "";

            if (mySerialPort_2.IsOpen == true)
                mySerialPort_2.Close();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbLineNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable dtLine = new DataTable();
                Mettler_Class_Obj.lno = Convert.ToInt64(CmbLineNo.SelectedValue);
                dtLine = LineMaster_Class_Obj.Select_tblLineMaster_ByLNo(Mettler_Class_Obj.lno);
                if (dtLine.Rows.Count > 0)
                {
                    if (dtLine.Rows[0]["SetofSample"].ToString() == "")
                        SetOfSample = 0;
                    else
                        SetOfSample = Convert.ToInt32(dtLine.Rows[0]["SetofSample"].ToString());
                }
                CmbFormulaNo_SelectionChangeCommitted(sender, e);
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

            DataSet ds = new DataSet();
            ds = Mettler_Class_Obj.Select_tblMettlerWeight();
            if (ds.Tables[0].Rows.Count > 0)
                dgCurrent.DataSource = ds.Tables[0];
            else
            {
                dgCurrent.DataSource = null;
                txtAvg.Text = txtMax.Text = txtMin.Text = txtR.Text = txtSV.Text = txtGAP.Text = "";
                //DgvPrevious.Rows.Clear();
                if (CheckManualExists())
                {
                    DialogResult dialogResult = MessageBox.Show("Record allready exists by manual entry. \r\nDo you want add new record ?", "Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                }
            }

            if (dgCurrent.Rows.Count >= SetOfSample)
                GetMINMAXAVG_StandardVariance();

        }

        public bool CheckManualExists()
        {
            DataTable Dt = Mettler_Class_Obj.Select_tblMettlerAverage_ManualExists();
            if (Dt.Rows.Count > 0)
            {
                //txtAvg.Text = Dt.Rows[0]["AVERAGE"].ToString();
                //txtSV.Text = Dt.Rows[0]["STDDEV"].ToString();
                //txtMax.Text = Dt.Rows[0]["M_MAX"].ToString();
                //txtMin.Text = Dt.Rows[0]["M_MIN"].ToString();
                //txtR.Text = Dt.Rows[0]["DISPERSION"].ToString();
                //txtGAP.Text = Dt.Rows[0]["GAP"].ToString();

                return true;
            }
            else
                return false;
        }

        private void CmbTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbFormulaNo_SelectionChangeCommitted(sender, e);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            mySerialPort_2.Close();
            this.Close();
        }

        private void toolStripPnlDispersionBtnClose_Click(object sender, EventArgs e)
        {
            pnlDispersion.Visible = false;
            txtDispersionReason.Text = string.Empty;
            btnGetWeight.Focus();
        }

        private void BtnDispersionSave_Click(object sender, EventArgs e)
        {
            try
            {
                Mettler_Class_Obj.dispersionremark = txtDispersionReason.Text.Trim();
                Mettler_Class_Obj.manualentry = 0;
                Mettler_Class_Obj.Update_tblMettlerAverage_DISPERSIONREMARK();

                pnlDispersion.Visible = false;
                txtDispersionReason.Text = string.Empty;
                btnGetWeight.Focus();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnGetWeight_Click(object sender, EventArgs e)
        {
            if (Mettler_Class_Obj.mettlerid != 0)
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

                ApplicationFlag = true;

                #region live application
                if (mySerialPort_2.IsOpen != true)
                    mySerialPort_2.Open();
                mySerialPort_2.Write("SI\r\n");
                #endregion

                #region for local application

                //string ProductWeight = "";
                ////For local because we dont have mettler device
                //ProductWeight = (new Random().Next(10000) / 18.2).ToString("f2");

                ////lblTareWeight.Text = "Tare Weight :- "
                //string TareWeight = lblTareWeight.Text;
                //TareWeight = TareWeight.Replace("Tare Weight :- ", "");

                //string ReadingTime = Comman_Class_Obj.Select_ServerDate().ToString("hh:mm tt");

                //Mettler_Class_Obj.weight = ProductWeight;
                //Mettler_Class_Obj.bulkweight = Convert.ToString((Convert.ToDouble(ProductWeight)) - (Convert.ToDouble(TareWeight)));
                //Mettler_Class_Obj.weighttime = ReadingTime;
                //Mettler_Class_Obj.createdby = FrmMain.LoginID;
                //Mettler_Class_Obj.mettlertime = CmbTime.Text;

                //Mettler_Class_Obj.Insert_tblMettlerWeight();

                //GetMettlerWeightCurrentGrid();
                //if (dgCurrent.Rows.Count >= SetOfSample)
                //    GetMINMAXAVG_StandardVariance();

                //CmbTime.Enabled = false;
                //CmbFgCode.Enabled = false;
                //CmbLineNo.Enabled = false;
                //DtpTrackCode.Enabled = false;
                //CmbFormulaNo.Enabled = false;

                #endregion
            }
        }

        private void dgCurrent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Delete this record ?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Mettler_Class_Obj.weightid = Convert.ToInt64(dgCurrent.Rows[e.RowIndex].Cells["WeightIDCurrent"].Value.ToString());
                    bool result = Mettler_Class_Obj.Delet_tblMettlerWeight_ByWeightID();
                    if (result)
                    {
                        DataSet ds = new DataSet();
                        ds = Mettler_Class_Obj.Select_tblMettlerWeight();
                        dgCurrent.DataSource = ds.Tables[0];

                        GetMINMAXAVG_StandardVariance();
                    }
                }
            }
        }

        private void DtpTrackCode_ValueChanged(object sender, EventArgs e)
        {
            CmbFormulaNo.SelectedValue = 0;
        }

        //private void DtpTrackCode_ValueChanged(object sender, EventArgs e)
        //{
        //    CmbFormulaNo_SelectionChangeCommitted(sender, e);
        //}

        

    }
}