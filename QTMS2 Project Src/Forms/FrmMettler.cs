using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade.Transactions;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;
using BusinessFacade;

namespace QTMS.Forms
{
    public partial class FrmMettler : Form
    {
        private static SerialPort mySerialPort_2 = new SerialPort("COM2");
        public FrmMettler()
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

        void mySerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {

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

        private delegate void SetTextDeleg(string text);

        private void FrmMettler_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            DtpDate.Value = Comman_Class_Obj.Select_ServerDate();
            Bind_Details();
            GetTimeIntervals();
            dgCurrent.AutoGenerateColumns = false;


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
            cmbDetails.Enabled = false;
            CmbFormulaNo.Enabled = false;

        }
        private void DoUpdate(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            MessageBox.Show(mySerialPort_2.ReadExisting());
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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            mySerialPort_2.Close();
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            lbltype.Visible = false;
            lbltype.Text = "";
            //lblTareWeight.Text = "";
            //lblTareWeight.Visible = false;
            //cmbDetails.SelectedValue = 0;
            //CmbFormulaNo.SelectedValue = 0;
            txtCurrentWeight.Text = "";
            CmbTime.Text = "12:00 AM";

            ApplicationFlag = false;
            CmbTime.Enabled = true;
            //cmbDetails.Enabled = true;
            //CmbFormulaNo.Enabled = true;

            //Mettler_Class_Obj.mettlerid = 0;

            //DataSet ds = new DataSet();
            //ds = Mettler_Class_Obj.Select_tblMettlerWeight();
            //dgCurrent.DataSource = ds.Tables[0];
            //DgvPrevious.DataSource = ds.Tables[0];

            dgCurrent.DataSource = null;
            txtAvg.Text = txtMax.Text = txtMin.Text = txtR.Text = txtSV.Text = "";

            if (mySerialPort_2.IsOpen == true)
                mySerialPort_2.Close();
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //BtnReset_Click(sender, e);
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

                    DataTable dtLine = new DataTable();
                    dtLine = LineMaster_Class_Obj.Select_tblLineMaster_ByLNo(SPCMaster_Class_Obj.lno);
                    if (dtLine.Rows.Count > 0)
                    {
                        if (dtLine.Rows[0]["SetofSample"].ToString() == "")
                            SetOfSample = 0;
                        else
                            SetOfSample = Convert.ToInt32(dtLine.Rows[0]["SetofSample"].ToString());
                    }
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

            }

        }

        int Srno = 0;
        public void AddRecord()
        {
            Thread.Sleep(500);

            double chk = Convert.ToDouble(txtCurrentWeight.Text);

            if (chk > 2.0)
            {

                Srno++;
                DataGridViewRow dr = new DataGridViewRow();
                dr.CreateCells(dgCurrent);  //
                dr.Cells[0].Value = Srno;
                dr.Cells[1].Value = txtCurrentWeight.Text;
                dr.Cells[2].Value = "Delete";
                dgCurrent.Rows.Insert(0, dr);

                //dgCurrent.Rows.Add();
                //dgCurrent["no", dgCurrent.Rows.Count - 1].Value = Srno;
                //dgCurrent["Weight", dgCurrent.Rows.Count - 1].Value = txtCurrentWeight.Text;

            }


            txtCurrentWeight.Text = string.Empty;
            Thread.Sleep(500);
            // timer1.Start();

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (Mettler_Class_Obj.mettlerid != 0)
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

                ApplicationFlag = true;

                //for live application 
                if (mySerialPort_2.IsOpen != true)
                    mySerialPort_2.Open();
                mySerialPort_2.Write("SI\r\n");


                //for local application

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
                //cmbDetails.Enabled = false;
                //CmbFormulaNo.Enabled = false;
            }







        }

        private void dgCurrent_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void BtnSave_Click(object sender, EventArgs e)
        {

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

            DataSet ds = new DataSet();
            ds = Mettler_Class_Obj.Select_tblMettlerWeight();
            if (ds.Tables[0].Rows.Count > 0)
                dgCurrent.DataSource = ds.Tables[0];
            else
            {
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


        public void GetMettlerWeightCurrentGrid()
        {
            DataSet ds = new DataSet();
            ds = Mettler_Class_Obj.Select_tblMettlerWeight();

            dgCurrent.DataSource = ds.Tables[0];
        }


        private void CmbTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbFormulaNo_SelectionChangeCommitted(sender, e);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            //mySerialPort_2.Dispose();
            mySerialPort_2.Close();
            //mySerialPort_2.
            this.Close();
        }
        bool TareWeightflg = false;
        private void btnTareWeight_Click(object sender, EventArgs e)
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
            if (mySerialPort_2.IsOpen != true)
                mySerialPort_2.Open();
            ApplicationFlag = true;
            TareWeightflg = true;
            mySerialPort_2.Write("SI\r\n");


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

        private void FrmMettler_FormClosing(object sender, FormClosingEventArgs e)
        {
            mySerialPort_2.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
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
    }
}