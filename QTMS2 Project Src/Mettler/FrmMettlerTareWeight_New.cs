using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using QTMS.Tools;
using System.Text.RegularExpressions;
using BusinessFacade;

namespace QTMS.Mettler
{
    public partial class FrmMettlerTareWeight_New : Form
    {
        private static SerialPort mySerialPort = new SerialPort("COM2");
        public FrmMettlerTareWeight_New()
        {
            InitializeComponent();

            mySerialPort.BaudRate = 9600;// 4800;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.DtrEnable = true;
            mySerialPort.RtsEnable = true;
            mySerialPort.ReadTimeout = 500;
            mySerialPort.WriteTimeout = 500;
            mySerialPort.Handshake = Handshake.None;    
        }

        #region variables
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        BusinessFacade.Mettler_Class Mettler_Class_Obj = new BusinessFacade.Mettler_Class();
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        bool ApplicationFlag = false;
        #endregion

        private delegate void SetTextDeleg(string text);

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            mySerialPort.Close();
            this.Close();
        }

        private void FrmMettlerTareWeight_New_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            DtpTrackCode.Value = Comman_Class_Obj.Select_ServerDate();
            //Bind_Details();
            GetTimeIntervals();

            Bind_LineNo();
            Bind_FGCode();

            lblTareWeight.ForeColor = Color.Red;
            lblTareWeight.Visible = true;

            try
            {
                if (mySerialPort.IsOpen != true)
                    mySerialPort.Open();
                else
                {
                    mySerialPort.Close();
                    mySerialPort.Open();
                }
            }
            catch (Exception ex)
            {

            }
            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs args)
        {
            SerialPort sp = (SerialPort)sender;
            if (sp.PortName == mySerialPort.PortName)
            {
                string data = mySerialPort.ReadLine();
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

            int rowId = dgCurrent.Rows.Add();

            // Grab the new row!
            DataGridViewRow row = dgCurrent.Rows[rowId];

            // Add the data
            row.Cells["no"].Value = (rowId + 1);
            row.Cells["Weight"].Value = st.Trim();
            row.Cells["Time"].Value = Comman_Class_Obj.Select_ServerDate().ToString("hh:mm tt");

            GetAverage();

            dgCurrent.FirstDisplayedScrollingRowIndex = dgCurrent.RowCount - 1;
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

        private void btnTareWeight_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(CmbFgCode.SelectedValue) == 0)
            {
                MessageBox.Show("Select FG Code");
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

            #region live application

            if (mySerialPort.IsOpen != true)
                mySerialPort.Open();

            mySerialPort.Write("SI\r\n");

            #endregion

            #region local application

            //string st = "";
            ////For local because we dont have mettler device
            //st = (new Random().Next(10000) / 58.2).ToString("f2");

            //int rowId = dgCurrent.Rows.Add();

            //// Grab the new row!
            //DataGridViewRow row = dgCurrent.Rows[rowId];

            //// Add the data
            //row.Cells["no"].Value = (rowId + 1);
            //row.Cells["Weight"].Value = st.Trim();
            //row.Cells["Time"].Value = Comman_Class_Obj.Select_ServerDate().ToString("hh:mm tt");

            //GetAverage();

            //dgCurrent.FirstDisplayedScrollingRowIndex = dgCurrent.RowCount - 1;

            #endregion
        }

        public void GetAverage()
        {
            double value = 0.0;
            for (int i = 0; i < dgCurrent.Rows.Count; i++)
                value = value + Convert.ToDouble(dgCurrent.Rows[i].Cells["Weight"].Value);

            double Avg = 0.0;

            Avg = value / (dgCurrent.Rows.Count);
            lblTareWeight.Text = "Avg : " + Avg.ToString("f2");

        }

        private void dgCurrent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Delete this record ?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dgCurrent.Rows.RemoveAt(e.RowIndex);
                    GetAverage();

                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            mySerialPort.Close();
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(CmbFgCode.SelectedValue) == 0)
            {
                MessageBox.Show("Select FG Code");
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

            Mettler_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
            Mettler_Class_Obj.trackcode = DtpTrackCode.Value.ToString();
            Mettler_Class_Obj.lno = Convert.ToInt64(CmbLineNo.SelectedValue);
            Mettler_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
            //Mettler_Class_Obj.mettlerdate = DtpDate.Value.ToString();
            Mettler_Class_Obj.mettlertime = CmbTime.Text;
            Mettler_Class_Obj.createdby = Convert.ToInt64(FrmMain.LoginID);

            string TareWeight = lblTareWeight.Text;
            TareWeight = TareWeight.Replace("Avg : ", "");

            Mettler_Class_Obj.tareweight = TareWeight;

            #region Check record exiest
            DataSet ds = new DataSet();
            ds = Mettler_Class_Obj.Select_tblMettler_New();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Record exists do you want new tare weight ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.Yes))
                {
                    lblTareWeight.Text = "Avg : ";
                    long id = Convert.ToInt64(ds.Tables[0].Rows[0][0]);
                    Mettler_Class_Obj.DeActive_tblMettler(id);
                }
                else
                {
                    this.Close();
                    return;
                }
            }
            #endregion 


            Mettler_Class_Obj.mettlerid = Mettler_Class_Obj.Insert_tblMettler_New();

            for (int i = 0; i < dgCurrent.Rows.Count; i++)
            {
                Mettler_Class_Obj.tareweight = Convert.ToString(dgCurrent.Rows[i].Cells["Weight"].Value);
                Mettler_Class_Obj.tareweighttime = Convert.ToString(dgCurrent.Rows[i].Cells["Time"].Value);
                bool res = Mettler_Class_Obj.Insert_tblMettlerTareWeight();
            }

            MessageBox.Show("Tare Weight Saved Successfully.");

            if (mySerialPort.IsOpen == true)
                mySerialPort.Close();
            //mySerialPort.Dispose();
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            lbltype.Visible = false;
            lbltype.Text = "";
            lblTareWeight.Text = "";
            //lblTareWeight.Visible = false;
            CmbFgCode.SelectedValue = 0;
            CmbLineNo.SelectedValue = 0;
            CmbFormulaNo.SelectedValue = 0;

            CmbTime.Text = "12:00 AM";

            ApplicationFlag = false;
            CmbTime.Enabled = true;
            CmbFgCode.Enabled = true;
            CmbFormulaNo.Enabled = true;

            Mettler_Class_Obj.mettlerid = 0;



            dgCurrent.Rows.Clear();// = null;
            //txtAvg.Text = txtMax.Text = txtMin.Text = txtR.Text = txtSV.Text = "";

            if (mySerialPort.IsOpen == true)
                mySerialPort.Close();
        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}