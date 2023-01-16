using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BusinessFacade.Scoop_Class;
using BusinessFacade.Transactions;
using QTMS.Transactions;
using QTMS.Scoop;

namespace QTMS.U_Control
{
    public partial class UC_SamplingGrid : UserControl
    {

        #region Constructor
        private DateTime LineStartTime;
        public UC_SamplingGrid()
        {
            InitializeComponent();
        }

        public frmScoopQualityAuthority currentQualityAutorityFrm = null;
        public UC_SamplingGrid(frmScoopQualityAuthority frm,DateTime lineStrtTme)
        {
            InitializeComponent();
            currentQualityAutorityFrm = frm;
            this.LineStartTime = lineStrtTme;
            this.sheduledTime = lineStrtTme;
        }

        public frmScoopUPAuthority currentUPAuthorityFrm = null;
        public UC_SamplingGrid(frmScoopUPAuthority frm, DateTime lineStrtTme)
        {
            InitializeComponent();
            currentUPAuthorityFrm = frm;
            this.LineStartTime = lineStrtTme;
            this.sheduledTime = lineStrtTme;
        }

        public UC_SamplingGrid(FrmScoopUP frm, DateTime lineStrtTme)
        {
            CurrentUPMasterFormObj = frm;
            InitializeComponent();
            this.LineStartTime = lineStrtTme;
            this.sheduledTime = lineStrtTme;
        }

        #endregion

        #region variable
        FrmScoopUP CurrentUPMasterFormObj;
        UPMaster_Class UPMaster_Class_Obj = new UPMaster_Class();
        UPTestSamplingPoint_Class UPTestSamplingPoint_Class_Obj = new UPTestSamplingPoint_Class();
        UPTestAtSamplingPoint_Class UPTestAtSamplingPoint_Class_obj = new UPTestAtSamplingPoint_Class();
        #endregion

        #region taggedVariable 
        public DateTime lineStartTime
        {
            get { return LineStartTime; }
        }

        private bool StopFurtherTesting;
        public  bool stopFurtherTesting
        {
            get { return StopFurtherTesting;}
            set { StopFurtherTesting = value;}
        }

        private static bool LineStoped;
        public static bool lineStopped
        {
            get { return LineStoped; }
            set { LineStoped = value;}
        }

        private string SamplingPoint;
        public string samplingPoint
        {
            get { return SamplingPoint; }
            set
            {
                SamplingPoint = value;
                if (SamplingPoint != null)
                {

                    this.dgSamplingPoint.Columns[0].HeaderText = SamplingPoint;
                }
            }

        }

        private int? Frequency;
        public int? frequency
        {
            get { return Frequency; }
            set
            {

                Frequency = value;
                if (Frequency != null)
                {
                    this.dgSamplingPoint.Columns[0].HeaderText = this.dgSamplingPoint.Columns[0].HeaderText + ":" + Frequency;
                }
            }

        }

        private Int64 SamplingPointId;
        public Int64 samplingPointId
        {
            get { return SamplingPointId; }
            set { SamplingPointId = value;}
        }

        private Int64 UPTestSamplingId;
        public Int64 upTestSamplingId
        {
            get { return UPTestSamplingId; }
            set { UPTestSamplingId = value; }
        
        }

        private Int64 TestAtSamplingPointId;
        public Int64 testAtSamplingPointId
        {
            get { return TestAtSamplingPointId; }
            set { TestAtSamplingPointId = value;}
        }

        private int TimeLeft;
        public int timeleft
        {
            get { return TimeLeft; }
            set { TimeLeft = value; }

        }

        #region Propertis to handle defect

        private static bool DefectOccuredAtOneEnd;
        public static bool defectOccuredAtOneEnd
        {
            get { return DefectOccuredAtOneEnd; }
            set { DefectOccuredAtOneEnd = value; }
        }

        private static bool _PMNotDoneTimeExided;
        public static bool PMNotDoneTimeExided
        {
            get { return _PMNotDoneTimeExided; }
            set { _PMNotDoneTimeExided = value; }
        }

        private bool HasCurrentRow;
        public bool hasCurrentRow
        {
            get { return HasCurrentRow; }
            set { HasCurrentRow = value;}
        
        }

        private bool DefectOccuredHere;
        public bool defectOccuredHere
        {
            get { return DefectOccuredHere; }
            set { DefectOccuredHere = value;}
        }

        #endregion

        private DateTime SheduledTime;
        public DateTime sheduledTime
        {
            get { return SheduledTime; }
            set { SheduledTime = value; }
        }

        #endregion

        #region Events

        private void UC_SamplingGrid_Load(object sender, EventArgs e)
        {
            //dgDefectCount.Rows.Add("Zero","0");
            //dgDefectCount.Rows.Add("Critical", "0");
            //dgDefectCount.Rows.Add("Major", "0");
            //dgDefectCount.Rows.Add("Minor", "0");

            dgDefectCount.Rows.Add("AQL", "0");
            dgDefectCount.Rows.Add("AQL(Z)", "0");
            dgDefectCount.Rows.Add("AQL(C)", "0");
            dgDefectCount.Rows.Add("AQL(M)", "0");
            dgDefectCount.Rows.Add("AQL(M1)", "0");

            hasCurrentRow = false;
            //defectOccuredAtOneEnd = false;
            DefectOccuredHere = false;
        }

        private void dgSamplingPoint_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) //<-------------------------------------------------------------------- CHECK IF CLICKED ON COLUMN HEADER(TO AVOID EXEPTION)
            {
                return;
            }

            #region Avinash 10-07-2014

            if (dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("NotDone") || dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("OK") || dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Last") || dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Defect"))
            { }
            else
            {
                if (e.RowIndex != 0)
                {
                    string tm = dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Substring(0, dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().LastIndexOf('M') + 1);
                    DateTime MyDateTime;
                    MyDateTime = new DateTime();
                    //MyDateTime = DateTime.ParseExact(tm, "HH:mm tt", null);
                    MyDateTime = DateTime.ParseExact(tm, "h:mm tt", null);

                    DateTime servertime = UPMaster_Class_Obj.GetCurrentTime();
                    DateTime starttime = MyDateTime.AddMinutes(10);
                    DateTime endtime = MyDateTime.AddMinutes(-10);
                    if (servertime <= starttime && servertime >= endtime)
                    {
                        // return;
                    }
                    else
                    {
                        MessageBox.Show("You can't do this time.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            #endregion

            if (CurrentUPMasterFormObj != null)
            {
                if (dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("OK") || dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Last") || dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Defect"))
                {
                    //<------------------- CODE TO OPEN SAVED RECORD IN UPTEST FORM
                    frmScoopUPTest frm = new frmScoopUPTest(CurrentUPMasterFormObj, this);
                    frm.recordExistsAlready = true;
                    frm.chkLastSample.Enabled = true;
                    frm.UPSamplingPontTestID = this.upTestSamplingId;
                    if (dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Last"))
                    {
                        frm.chkLastSample.Checked = true;
                        frm.chkLastSample.Enabled = false;
                    }
                    frm.time = dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Substring(0, dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().LastIndexOf('M') + 1);
                    frm.actualTimeOfSampling = dgSamplingPoint.Rows[e.RowIndex].Cells[1].Value.ToString();
                    frm.timeBreif = Convert.ToDateTime(dgSamplingPoint.Rows[e.RowIndex].Tag.ToString());
                    frm.chkLastSample.Enabled = false;
                    frm.ShowDialog();
                    return;
                }
                else if (dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("NotDone")) //<-------------- CODE TO OPEN NNOT DONE REASONE FORM SAVED NOT SAVED
                {

                    frmScoopTestNotDoneDetail frm = new frmScoopTestNotDoneDetail(this);
                    frm.UPSamplingPontTestID = this.upTestSamplingId;
                    frm.time = dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Substring(0, dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().LastIndexOf('M') + 1);
                    frm.ExpectedTime = dgSamplingPoint.Rows[e.RowIndex].Cells[1].Value.ToString();
                    frm.ShowDialog();

                    if (dgSamplingPoint.Rows.Count-1 == e.RowIndex)
                        AddRowAfterApproval();

                    return;
                }
                else
                {

                    if (!CurrentUPMasterFormObj.RecordExistAlready)
                    {
                        if (!CurrentUPMasterFormObj.masterSaved)
                        {
                            CurrentUPMasterFormObj.SaveUPMaster();
                            CurrentUPMasterFormObj.Save_UPTestSamplingPoint();
                        }
                    }

                    frmScoopUPTest frm = new frmScoopUPTest(CurrentUPMasterFormObj, this);
                    frm.time = UPMaster_Class_Obj.GetCurrentTime().ToString("t");
                    frm.timeBreif = UPMaster_Class_Obj.GetCurrentTime();
                    frm.toolStripLabel1.Text += " " + this.samplingPoint;

                    frm.FgCodeID = CurrentUPMasterFormObj.SCOOPTestMethodMaster_Class_Obj.fgNo;
                    frm.LineId = CurrentUPMasterFormObj.SCOOPTestMethodMaster_Class_Obj.lno;
                    frm.samplingPointId = this.samplingPointId;
                    frm.actualTimeOfSampling = dgSamplingPoint.Rows[e.RowIndex].Cells[1].Value.ToString().Substring(0, dgSamplingPoint.Rows[e.RowIndex].Cells[1].Value.ToString().LastIndexOf('M') + 1);
                    frm.UPSamplingPontTestID = this.upTestSamplingId;
                    frm.rowindex = e.RowIndex;
                    frm.ShowDialog();
                }
            }
            if (currentUPAuthorityFrm != null)
            {

                if (currentUPAuthorityFrm.RecordExistAlready && !dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("NotDone"))
                {

                    frmScoopUPTest frm = new frmScoopUPTest(currentUPAuthorityFrm,this);
                    frm.recordExistsAlready = true;
                    frm.chkLastSample.Enabled = true;
                    if (dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Last"))
                    {
                        frm.chkLastSample.Checked = true;
                        frm.chkLastSample.Enabled = false;
                    }
                    if (dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Defect"))
                    {
                        frm.lblCheckBox.Visible = false;
                        frm.chkLastSample.Visible = false;

                        frm.chkContinuetest.Font = new Font("Verdana", 12, FontStyle.Bold);
                        frm.chkContinuetest.ForeColor = Color.OrangeRed;
                        frm.chkContinuetest.Visible = true;
                    }
                    frm.UPSamplingPontTestID = this.upTestSamplingId;
                    frm.time = dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Substring(0, dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().LastIndexOf('M') + 1);
                    frm.actualTimeOfSampling = dgSamplingPoint.Rows[e.RowIndex].Cells[1].Value.ToString();
                    frm.timeBreif = Convert.ToDateTime(dgSamplingPoint.Rows[e.RowIndex].Tag.ToString());
                    frm.chkLastSample.Enabled = false;
                    frm.ShowDialog();
                    return;
                }
                if (dgSamplingPoint.Rows[e.RowIndex].Cells[0].ReadOnly && dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("NotDone"))//<--***************************
                {

                    frmScoopTestNotDoneDetail frm = new frmScoopTestNotDoneDetail(this);
                    frm.UPSamplingPontTestID = this.upTestSamplingId;
                    frm.time = dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Substring(0, dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().LastIndexOf('M') + 1);
                    frm.ExpectedTime = dgSamplingPoint.Rows[e.RowIndex].Cells[1].Value.ToString();
                    if (CurrentUPMasterFormObj!=null)
                    {
                        frm.chkContinuetest.Visible = false;
                    }
                    else
                    {
                        frm.chkContinuetest.Visible = true;
                    }
                    frm.ShowDialog();
                    return;

                } 
            }

            if (currentQualityAutorityFrm != null)
            {

                if (currentQualityAutorityFrm.RecordExistAlready && !dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("NotDone"))
                {

                    frmScoopUPTest frm = new frmScoopUPTest(currentQualityAutorityFrm, this);
                    frm.recordExistsAlready = true;
                    frm.chkLastSample.Enabled = true;
                    if (dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Last"))
                    {
                        frm.chkLastSample.Checked = true;
                        frm.chkLastSample.Enabled = false;
                    }
                    if (dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("Defect"))
                    {
                        frm.lblCheckBox.Visible = false;
                        frm.chkLastSample.Visible = false;

                        frm.chkContinuetest.Font = new Font("Verdana", 12, FontStyle.Bold);
                        frm.chkContinuetest.ForeColor = Color.OrangeRed;
                        frm.chkContinuetest.Visible = true;
                    }
                    frm.UPSamplingPontTestID = this.upTestSamplingId;
                    frm.time = dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Substring(0, dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().LastIndexOf('M') + 1);
                    frm.actualTimeOfSampling = dgSamplingPoint.Rows[e.RowIndex].Cells[1].Value.ToString();
                    frm.timeBreif = Convert.ToDateTime(dgSamplingPoint.Rows[e.RowIndex].Tag.ToString());
                    frm.chkLastSample.Enabled = false;
                    frm.ShowDialog();
                    return;
                }
                if (dgSamplingPoint.Rows[e.RowIndex].Cells[0].ReadOnly && dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Contains("NotDone"))//<--***************************
                {

                    frmScoopTestNotDoneDetail frm = new frmScoopTestNotDoneDetail(this);
                    frm.UPSamplingPontTestID = this.upTestSamplingId;
                    frm.time = dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().Substring(0, dgSamplingPoint.Rows[e.RowIndex].Cells[0].Value.ToString().LastIndexOf('M') + 1);
                    frm.ExpectedTime = dgSamplingPoint.Rows[e.RowIndex].Cells[1].Value.ToString();
                    if (CurrentUPMasterFormObj != null)
                    {
                        frm.chkContinuetest.Visible = false;
                    }
                    else
                    {
                        frm.chkContinuetest.Visible = true;
                    }
                    frm.ShowDialog();
                    return;

                } 
            
            }
        }

        #endregion

        #region Functions

        public void setDefectCount(int rowindex,string cnt)
        {
            dgDefectCount.Rows[rowindex].Cells[1].Value = cnt;
        }

        public  void Add_SamplingRow(string expectedTime, string sheduledTime)
        {
            dgSamplingPoint.Rows.Add(expectedTime, sheduledTime);
            this.timeleft = (int)frequency + 10;
        }

        public void Add_SamplingRow( )
        {
            this.sheduledTime = sheduledTime.AddMinutes(Convert.ToDouble(this.frequency));//.ToString("t");
            dgSamplingPoint.Rows.Add(sheduledTime.ToString("t"),sheduledTime.ToString("t"));
            this.timeleft = (int)frequency + 10;
        }

        //---------------- SetSamplingGRidRow overloded ----------------
        public  void SetSamplingGridRow(string type,string doneTime,int rwIndx)
        {
            switch (type)
            {
                case "NotDone":

                    SetGridCell("NotDone", Color.Orange, rwIndx, doneTime);
                    break;

                case "Defect":

                    SetGridCell("Defect", Color.Red, rwIndx, doneTime);
                    break;

                case "OK":

                    SetGridCell("OK", Color.Green, rwIndx, doneTime);
                    break;

                case "Last":

                    SetGridCell("Last-Ok", Color.Green, rwIndx, doneTime);
                    break;

                case "MinorDefect":
                    SetGridCell("OK", Color.Yellow, rwIndx, doneTime);
                    break;

                case "Resume":
                    SetGridCell("Resume", Color.Green, rwIndx, doneTime);
                    break;
            }
           
            this.timeleft = 0;
        }

        public void SetSamplingGridRow(string type, string doneTime)
        {
            int rwIndx = dgSamplingPoint.RowCount - 1;
            switch (type)
            {
                case "NotDone":
                    SetGridCell("NotDone", Color.Orange, rwIndx, doneTime);
                    break;

                case "Defect":
                    SetGridCell("Defect", Color.Red, rwIndx, doneTime);
                    break;

                case "OK":
                    SetGridCell("OK", Color.Green, rwIndx, doneTime);
                    break;

                case "Last":
                    SetGridCell("Last-Ok", Color.Green, rwIndx, doneTime);
                    break;

                case "MinorDefect":
                    SetGridCell("OK", Color.Yellow, rwIndx, doneTime);
                    break;

                case "Resume":
                    SetGridCell("Resume", Color.Green, rwIndx, doneTime);
                    break;
            }
           
            this.timeleft = 0;
        }

        public void SetSamplingGridRow(string type, string doneTime,int rwIndx,DateTime brieftime)
        {
            switch (type)
            {
                case "NotDone":
                    SetGridCell("NotDone", Color.Orange, rwIndx, doneTime,brieftime);
                    break;

                case "Defect":
                    SetGridCell("Defect", Color.Red, rwIndx, doneTime, brieftime);
                    break;

                case "OK":
                    SetGridCell("OK", Color.Green, rwIndx, doneTime,brieftime);
                    break;

                case "Last":
                    SetGridCell("Last-Ok", Color.Green, rwIndx, doneTime,brieftime);
                    break;

                case "MinorDefect":
                    SetGridCell("OK", Color.Yellow, rwIndx, doneTime, brieftime);
                    break;

                case "Resume":
                    SetGridCell("Resume", Color.Green, rwIndx, doneTime, brieftime);
                    break;
            }
           
            this.timeleft = 0;
        }

        public void SetSamplingGridRow(string type, string doneTime,DateTime brieftime)
        {
            int rwIndx = dgSamplingPoint.RowCount - 1;
            switch (type)
            {
                case "NotDone":
                    SetGridCell("NotDone", Color.Orange, rwIndx, doneTime, brieftime);
                    break;

                case "Defect":
                    SetGridCell("Defect", Color.Red, rwIndx, doneTime, brieftime);
                    this.DefectOccuredHere = true;
                    UC_SamplingGrid.defectOccuredAtOneEnd = true;
                    break;

                case "OK":
                    SetGridCell("OK", Color.Green, rwIndx, doneTime, brieftime);
                    break;

                case "Last":
                    SetGridCell("Last-Ok", Color.Green, rwIndx, doneTime, brieftime);
                    break;

                case "MinorDefect":
                    SetGridCell("OK", Color.Yellow, rwIndx, doneTime, brieftime);
                    break;

                case "Resume":
                    SetGridCell("Resume", Color.Green, rwIndx, doneTime, brieftime);
                    break;
           
            }
          
            this.timeleft = 0;
        }


        //------------- SetGridCell Overloaded -------------------------
        private void SetGridCell(string textToApend, Color clr, int rowindex,string doneTime)
        {
            dgSamplingPoint.Rows[rowindex].DefaultCellStyle.BackColor = clr;
            dgSamplingPoint.Rows[rowindex].DefaultCellStyle.SelectionBackColor = clr;
            //dgSamplingPoint.Rows[rowindex].Cells[0].Value = doneTime.Substring(0, dgSamplingPoint.Rows[rowindex].Cells[0].Value.ToString().LastIndexOf('M') + 1) + "-" + textToApend;
            dgSamplingPoint.Rows[rowindex].Cells[0].Value = doneTime + "-" + textToApend;
        }

        private void SetGridCell(string textToApend, Color clr, int rowindex, string doneTime,DateTime brieftime)
        {
            dgSamplingPoint.Rows[rowindex].DefaultCellStyle.BackColor = clr;
            dgSamplingPoint.Rows[rowindex].DefaultCellStyle.SelectionBackColor = clr;
            dgSamplingPoint.Rows[rowindex].Cells[0].Value = doneTime + "-" + textToApend; //doneTime.Substring(0, doneTime.LastIndexOf('M') + 1) + "-" + textToApend;// dgSamplingPoint.Rows[rowindex].Cells[0].Value.ToString().LastIndexOf('M') + 1) + "-" + textToApend;
            dgSamplingPoint.Rows[rowindex].Tag = brieftime;
        }


        public void BroadCastDefect()
        {
            if (!UC_SamplingGrid.defectOccuredAtOneEnd)
            {
                UC_SamplingGrid.defectOccuredAtOneEnd = true;
            }
            this.defectOccuredHere = true;
            CurrentUPMasterFormObj.startNotifyTimer();
        }

        public bool TestContinueApproved()
        {
            UPTestAtSamplingPoint_Class_obj.time = dgSamplingPoint.Rows[dgSamplingPoint.RowCount - 1].Cells[0].Value.ToString().Substring(0, dgSamplingPoint.Rows[dgSamplingPoint.RowCount - 1].Cells[0].Value.ToString().LastIndexOf('M') + 1);
            UPTestAtSamplingPoint_Class_obj.expectedtime = dgSamplingPoint.Rows[dgSamplingPoint.RowCount - 1].Cells[1].Value.ToString();
            UPTestAtSamplingPoint_Class_obj.uptestsamplingpointid = this.upTestSamplingId;
            return UPTestAtSamplingPoint_Class_obj.Notify_AuthorityRemark();
        }

        public void AddRowAfterApproval()
        {
            string rowState = dgSamplingPoint.Rows[dgSamplingPoint.RowCount - 1].Cells[0].Value.ToString();
            try
            {
                if (rowState.Contains("Defect"))
                {
                    // this.Add_SamplingRow((UPMaster_Class_Obj.GetCurrentTime().AddMinutes((int)frequency)).ToString("t") + "Immediate", UPMaster_Class_Obj.GetCurrentTime().ToString("t"));
                    sheduledTime = UPMaster_Class_Obj.GetCurrentTime();
                    this.Add_SamplingRow(sheduledTime.ToString("t") + "Immediate", sheduledTime.ToString("t"));
                    return;
                }
                if (rowState.Contains("OK"))
                {
                    //this.Add_SamplingRow((UPMaster_Class_Obj.GetCurrentTime().AddMinutes((int)frequency)).ToString("t") + "Immediate", UPMaster_Class_Obj.GetCurrentTime().ToString("t"));
                    sheduledTime = UPMaster_Class_Obj.GetCurrentTime();
                    this.Add_SamplingRow(sheduledTime.ToString("t") + "Immediate", sheduledTime.ToString("t"));
                    return;
                }
                if (rowState.Contains("NotDone"))
                {

                    UPTestAtSamplingPoint_Class_obj.time = rowState.Substring(0, rowState.LastIndexOf('M') + 1);
                    UPTestAtSamplingPoint_Class_obj.uptestsamplingpointid = this.upTestSamplingId;
                    UPTestAtSamplingPoint_Class_obj.expectedtime = dgSamplingPoint.Rows[dgSamplingPoint.RowCount - 1].Cells[1].Value.ToString();
                    DataSet DS = new DataSet();
                    DS = UPTestAtSamplingPoint_Class_obj.Select_NotDoneDesc();

                    if (DS.Tables[0].Rows[0]["NotDoneDescription"].ToString() != "")
                    {
                        //sheduledTime = Convert.ToDateTime(UPTestAtSamplingPoint_Class_obj.time).AddMinutes(Convert.ToDouble(this.frequency));
                        sheduledTime = UPMaster_Class_Obj.GetCurrentTime();
                        this.Add_SamplingRow(sheduledTime.ToString("t") + "Immediate", sheduledTime.ToString("t"));
                        //this.Add_SamplingRow(sheduledTime.ToString("t"), sheduledTime.ToString("t"));
                        //this.Add_SamplingRow();
                    }
                    return;
                }
            }
            catch
            {
                throw;
            }
        }

        public void setDefectBrodcostFalse()
        {
            UC_SamplingGrid.defectOccuredAtOneEnd = false;
        }

        #endregion

        private void dgSamplingPoint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
