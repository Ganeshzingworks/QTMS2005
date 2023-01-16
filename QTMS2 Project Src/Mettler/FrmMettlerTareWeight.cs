using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using QTMS.Tools;
using BusinessFacade.Transactions;
using System.Text.RegularExpressions;

namespace QTMS.Mettler
{
    public partial class FrmMettlerTareWeight : Form
    {
        private static SerialPort mySerialPort = new SerialPort("COM2");
        public FrmMettlerTareWeight()
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
        bool ApplicationFlag = false;
        #endregion

        private delegate void SetTextDeleg(string text);
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            mySerialPort.Close();
            this.Close();
        }

        private void FrmMettlerTareWeight_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            DtpDate.Value = Comman_Class_Obj.Select_ServerDate();
            Bind_Details();
            GetTimeIntervals();

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
            }
        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbFormulaNo.SelectedValue != null && CmbFormulaNo.SelectedValue.ToString() != "" && CmbFormulaNo.SelectedIndex != 0)
            {
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

                CheckRecordExiest();

            }
        }

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

            //for live application 
            if (mySerialPort.IsOpen != true)
                mySerialPort.Open();

            mySerialPort.Write("SI\r\n");
            ////mySerialPort.Write("W1");

            //for local application

            ////string st = "";
            //////For local because we dont have mettler device
            ////st = (new Random().Next(10000) / 58.2).ToString("f2");

            ////int rowId = dgCurrent.Rows.Add();

            ////// Grab the new row!
            ////DataGridViewRow row = dgCurrent.Rows[rowId];

            ////// Add the data
            ////row.Cells["no"].Value = (rowId + 1);
            ////row.Cells["Weight"].Value = st.Trim();
            ////row.Cells["Time"].Value = Comman_Class_Obj.Select_ServerDate().ToString("hh:mm tt");

            ////GetAverage();

            ////dgCurrent.FirstDisplayedScrollingRowIndex = dgCurrent.RowCount - 1;
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

            Mettler_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
            Mettler_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
            Mettler_Class_Obj.mettlerdate = DtpDate.Value.ToString();
            Mettler_Class_Obj.mettlertime = CmbTime.Text;
            Mettler_Class_Obj.createdby = Convert.ToInt64(FrmMain.LoginID);

            string TareWeight = lblTareWeight.Text;
            TareWeight = TareWeight.Replace("Avg : ", "");

            Mettler_Class_Obj.tareweight = TareWeight;

            Mettler_Class_Obj.mettlerid = Mettler_Class_Obj.Insert_tblMettler();

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

        public void CheckRecordExiest()
        {
            Mettler_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
            Mettler_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
            Mettler_Class_Obj.mettlerdate = DtpDate.Value.ToString();
            Mettler_Class_Obj.mettlertime = CmbTime.Text;
            Mettler_Class_Obj.createdby = Convert.ToInt64(FrmMain.LoginID);

            DataSet ds = new DataSet();
            ds = Mettler_Class_Obj.Select_tblMettler();
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
                }
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            lbltype.Visible = false;
            lbltype.Text = "";
            lblTareWeight.Text = "";
            //lblTareWeight.Visible = false;
            cmbDetails.SelectedValue = 0;
            CmbFormulaNo.SelectedValue = 0;

            CmbTime.Text = "12:00 AM";

            ApplicationFlag = false;
            CmbTime.Enabled = true;
            cmbDetails.Enabled = true;
            CmbFormulaNo.Enabled = true;

            Mettler_Class_Obj.mettlerid = 0;



            dgCurrent.Rows.Clear();// = null;
            //txtAvg.Text = txtMax.Text = txtMin.Text = txtR.Text = txtSV.Text = "";

            if (mySerialPort.IsOpen == true)
                mySerialPort.Close();
        }

        private void FrmMettlerTareWeight_FormClosing(object sender, FormClosingEventArgs e)
        {
            mySerialPort.DataReceived -= new SerialDataReceivedEventHandler(port_DataReceived);
        }
    }
}