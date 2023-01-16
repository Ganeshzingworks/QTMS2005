using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QTMS.Transactions
{
    public partial class frmHourWiseActivity : Form
    {
        public string Value = "6-7";
        public int LineActivityId;
        private DateTime dtFromTime, dtToTime;
        private long LineHrsID, detailID;
        private string colFromName, colToName;
        private int colFromNumber, colToNumber, shiftID;
        private double producedUnits, lineSpeed;


        public frmHourWiseActivity()
        {
            InitializeComponent();
        }
        public frmHourWiseActivity(string value, int lineNo, long detailID, DateTime transDate, int mod, int shiftId, long fgNo, double lineSpeed)
        {
            this.Value = value;
            LineOEETransaction_Obj.lno = lineNo;
            LineOEETransaction_Obj.transDate = transDate;
            LineOEETransaction_Obj.detailID = detailID;
            this.detailID = LineOEETransaction_Obj.detailID;
            LineOEETransaction_Obj.mod = mod;
            LineOEETransaction_Obj.shiftID = shiftId;
            this.shiftID = LineOEETransaction_Obj.shiftID;
            LineOEETransaction_Obj.fgno = fgNo;
            LineOEETransaction_Obj.lineSpeed = this.lineSpeed = lineSpeed;
            InitializeComponent();
        }
        #region Variable
        FrmPMTransaction frmPMTrans = new FrmPMTransaction();
        BusinessFacade.Transactions.LineOEETransaction LineOEETransaction_Obj = new BusinessFacade.Transactions.LineOEETransaction();
        #endregion


        private void frmHourWiseActivity_Load(object sender, EventArgs e)
        {
            //BindGrid3(Value);
            BindDataToGrid();
        }

        private void BindDataToGrid()
        {
            #region For Binding Data
            DataTable dt = new DataTable();
            DataTable dtComment = new DataTable();
            string[] shift_hrs = Value.ToString().Replace("-", ":").Split(':');
            string fromTime = Convert.ToString(shift_hrs[0] + ":05");
            string toTime = Convert.ToString(shift_hrs[1] + ":00");
            DateTime dtts = Convert.ToDateTime(LineOEETransaction_Obj.transDate);


            if (shiftID == 3)
            {
                //DateTime dt1 = Convert.ToDateTime(toTime);
                if (toTime == "24:00")
                {
                    toTime = "00:00";
                }
                DateTime dt1 = Convert.ToDateTime(toTime);

                string strDateToTime = Convert.ToString(dt1);
                //Check AM for add new date of third shift
                if (strDateToTime.Contains("AM"))
                    this.dtToTime = (Convert.ToDateTime(toTime)).AddDays(1);
                else
                    this.dtToTime = Convert.ToDateTime(toTime);

                //if (toTime == "24:00")
                //{
                //    string strDateToTime = Convert.ToDateTime(dtts).ToString("yyyy-MMM-dd ");
                //    this.dtToTime = DateTime.Parse(strDateToTime + "00:00").AddDays(1);
                //}
                //else
                //{

                //    string strDateToTime = Convert.ToDateTime(dtts).ToString("yyyy-MMM-dd ");
                //    dtToTime = DateTime.Parse(strDateToTime + toTime);

                //    //Check AM for add new date of third shift
                //    if (dtToTime.ToString().Contains("AM"))
                //        this.dtToTime = (Convert.ToDateTime(dtToTime)).AddDays(1);
                //    else
                //        this.dtToTime = Convert.ToDateTime(dtToTime);
                //}



                DateTime dt2 = Convert.ToDateTime(fromTime);
                string strDateFromTime = Convert.ToString(dt2);
                if (strDateFromTime.Contains("AM"))
                    this.dtFromTime = (Convert.ToDateTime(fromTime)).AddDays(1);
                else
                    this.dtFromTime = Convert.ToDateTime(fromTime);

                //string strDate = Convert.ToDateTime(dtts).ToString("yyyy-MMM-dd ");
                //dtFromTime = DateTime.Parse(strDate + fromTime);

                //if (dtFromTime.ToString().Contains("AM"))
                //    this.dtFromTime = (Convert.ToDateTime(dtFromTime)).AddDays(1);
                //else
                //    this.dtFromTime = Convert.ToDateTime(dtFromTime);
            }
            else
            {
                this.dtFromTime = Convert.ToDateTime(fromTime);
                this.dtToTime = Convert.ToDateTime(toTime);
               // string st = Convert.ToDateTime(dtts).ToString("yyyy-MMM-dd ");
               // this.dtFromTime = DateTime.Parse(st + fromTime);
               // this.dtToTime = DateTime.Parse(st + toTime); 
            }

            LineOEETransaction_Obj.fromTime = dtFromTime;
            LineOEETransaction_Obj.toTime = dtToTime;


            dt = LineOEETransaction_Obj.Get_LineOEEHrsID_tblLineOEEHrs();
            LineOEETransaction_Obj.lineHrsId = Convert.ToInt64(dt.Rows[0]["LineHrsID"]);
            LineOEETransaction_Obj.producedUnits = Convert.ToDouble(dt.Rows[0]["ProducedUnits"]);
            LineHrsID = LineOEETransaction_Obj.lineHrsId;
            producedUnits = LineOEETransaction_Obj.producedUnits;

            dt = LineOEETransaction_Obj.Select_LineOEEDetails();
            if (dt.Rows.Count > 0)
            {

                BindGrid3(Value);

                dtComment = LineOEETransaction_Obj.Select_LineOEEComment();
                foreach (DataRow dr in dtComment.Rows)
                {
                    //LineOEETransaction_Obj.fromTime =Convert.ToDateTime(dr["FromTime"]);
                    //LineOEETransaction_Obj.toTime =Convert.ToDateTime( dr["ToTime"]);
                    LineOEETransaction_Obj.activityID = Convert.ToInt32(dr["LineActivityID"]);
                    string colFName = String.Format("{0:t}", dr["FromTime"]);
                    string colTName = String.Format("{0:t}", dr["ToTime"]);

                    int colFNumber = Convert.ToInt32(dr["colFromNumber"]);
                    int colTNumber = Convert.ToInt32(dr["colToNumber"]);
                    int rowNumber = Convert.ToInt32(dr["LineActivityID"]);

                    for (int i = colFNumber; i <= colTNumber; i++)
                    {
                        if (rowNumber == 2)
                        {
                            dgLineOEEActivity[i, rowNumber - 1].Style.BackColor = Color.GreenYellow;
                            dgLineOEEActivity[i, 0].Value = Convert.ToString(dr["MOD"]);
                        }
                        else
                        {
                            dgLineOEEActivity[i, rowNumber - 1].Style.BackColor = Color.Red;
                            dgLineOEEActivity[i, rowNumber - 1].Value = Convert.ToString(dr["CommentDesc"]);
                            dgLineOEEActivity[i, rowNumber - 1].ToolTipText = Convert.ToString(dr["CommentDesc"]);
                            dgLineOEEActivity[i, rowNumber - 1].Selected = false;
                            dgLineOEEActivity[i, 0].Value = Convert.ToString(dr["MOD"]);
                        }

                    }
                    //dgLineOEEActivity[LineOEETransaction_Obj.fromTime, LineOEETransaction_Obj.activityID].Style.BackColor = Color.Red;
                }
                if (dtComment.Rows.Count > 0)
                {
                    string selectCommand = "Max(LineActivityID)";
                    int lineID = Convert.ToInt32((object)dtComment.Compute(selectCommand, string.Empty));
                    string selectCommand1 = "Max(colToNumber)";
                    int colNum = Convert.ToInt32((object)dtComment.Compute(selectCommand1, string.Empty));
                    dgLineOEEActivity.CurrentCell = dgLineOEEActivity.Rows[lineID - 1].Cells[colNum];
                    dgLineOEEActivity.ClearSelection();
                }
            }
            else
            {
                //txtFormNumber.Text = "0";
                //txtProducedUnits.Text = "0";//comment by rohan
                BindGrid3(Value);
            }
            // Lable name of produced unit
            //ProducedUnitShiftWise();//comment by rohan
            #endregion
        }

        private void BindGrid3(string str)
        {
            try
            {
                dgLineOEEActivity.Rows.Clear();
                //dgLineOEEActivity.DataSource = null;
                dgLineOEEActivity.Columns.Clear();
                int min = 0, hrs = 0;
                string hrUnit = "", Selected_shift = "";
                string[] shift_hrs;
                min = 5;

                //
                Selected_shift = str.ToString();
                Selected_shift = Selected_shift.Replace("-", ":");
                shift_hrs = Selected_shift.Split(':');
                hrs = Convert.ToInt32(shift_hrs[0].ToString());


                for (int i = 0; i <= 13; i++)
                {
                    DataGridViewColumn newCol = new DataGridViewColumn();

                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    newCol.CellTemplate = cell;

                    if (i == 0)
                    {
                        newCol.HeaderText = "Activity Name";

                        newCol.Name = "ActivityName";
                        newCol.Visible = true;
                        newCol.Width = 200;
                        newCol.ReadOnly = true;
                        newCol.Frozen = true;
                    }
                    else if (i == 13)
                    {
                        newCol.HeaderText = "Activity ID";
                        newCol.Name = "LineActivityID";
                        newCol.ReadOnly = true;
                        newCol.Visible = false;
                        newCol.Width = 100;
                    }
                    else
                    {
                        if (min > 55)
                        {
                            min = 0;
                            hrs = hrs + 1;
                            if (hrs >= 12 && hrs <= 24)
                                hrUnit = "PM";
                            else
                                hrUnit = "AM";

                            newCol.HeaderText = Convert.ToString(hrs + ":" + "0" + min);// + "" + hrUnit);
                            newCol.Name = "";
                            newCol.ReadOnly = true;
                            newCol.Visible = true;
                            newCol.Width = 50;
                            min = 5;
                            //newCol.DividerWidth = 5;

                            //if (((hrs-1) % 2) == 0)
                            //    newCol.DefaultCellStyle.BackColor = Color.Orange;
                            //else
                            //    newCol.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else
                        {
                            if (hrs > 23) // If hours are greater than 23 then assign hrs value to 1
                                hrs = 0;
                            if (hrs >= 12 && hrs <= 24)
                                hrUnit = "PM";
                            else
                                hrUnit = "AM";

                            if (min == 5)
                                newCol.HeaderText = Convert.ToString(hrs + ":" + "0" + (min));// + "" + hrUnit);
                            else
                                newCol.HeaderText = Convert.ToString(hrs + ":" + (min));// + "" + hrUnit);
                            newCol.Name = "";
                            newCol.Visible = true;
                            newCol.ReadOnly = true;
                            newCol.Width = 50;
                            min = min + 5;

                            //if ((hrs % 2) == 0)
                            //    newCol.DefaultCellStyle.BackColor = Color.Orange;
                            //else
                            //    newCol.DefaultCellStyle.BackColor = Color.Yellow;

                        }

                    }
                    dgLineOEEActivity.Columns.Add(newCol);

                }
                DataTable dt = new DataTable();

                dt = LineOEETransaction_Obj.SelectLineOEEActivityMaster();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgLineOEEActivity.Rows.Add();
                        dgLineOEEActivity["ActivityName", i].Value = Convert.ToString(dt.Rows[i]["ActivityName"]);
                        dgLineOEEActivity["LineActivityID", i].Value = Convert.ToString(dt.Rows[i]["LineActivityID"]);
                    }
                }

                //if (txtSTDMOD.Text.Trim() != "")
                //{
                //    for (int i = 0; i < dgLineOEEActivity.Columns.Count - 2; i++)
                //    {
                //        dgLineOEEActivity[i + 1, 0].Value = txtSTDMOD.Text.Trim();

                //    }
                //    for (int i = 0; i < dgLineOEEActivity.Rows.Count - 1; i++)
                //    {
                //        dgLineOEEActivity.Rows[i + 1].ReadOnly = true;
                //    }
                //}
                if (LineOEETransaction_Obj.mod != 0)
                {
                    for (int i = 0; i < dgLineOEEActivity.Columns.Count - 2; i++)
                    {
                        dgLineOEEActivity[i + 1, 0].Value = LineOEETransaction_Obj.mod;

                    }
                    for (int i = 0; i < dgLineOEEActivity.Rows.Count - 1; i++)
                    {
                        dgLineOEEActivity.Rows[i + 1].ReadOnly = true;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int empCount = 0;
            for (int i = 1; i < dgLineOEEActivity.Columns.Count - 1; i++)
            {
                empCount = 0;
                for (int j = 1; j < dgLineOEEActivity.Rows.Count; j++)
                {
                    if (dgLineOEEActivity[i, j].Style.BackColor == Color.GreenYellow || dgLineOEEActivity[i, j].Style.BackColor == Color.Red)
                    {
                        empCount = 0;
                        break;
                    }
                    empCount++;
                }
                if (empCount == 7)
                {
                    break;
                }
            }


            double count = 0;
            for (int i = 0; i < dgLineOEEActivity.Columns.Count - 1; i++)
            {
                //string s=Convert.ToString(dgLineOEEActivity[i + 2, 1].Style.BackColor.Name);// == Color.GreenYellow
                if (dgLineOEEActivity[i, 1].Style.BackColor == Color.GreenYellow)
                {
                    count += 5;
                }
            }
            double ActualPU = Convert.ToDouble(count * lineSpeed);
            if (ActualPU != producedUnits)
            {
                if (MessageBox.Show("Produced units and actual produced units are not matched.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (empCount == 7)
                    {
                        MessageBox.Show("Fill Remaining Minutes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                if (empCount == 7)
                {
                    MessageBox.Show("Fill Remaining Minutes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void dgLineOEEActivity_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgLineOEEActivity_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;
            int b = e.ColumnIndex;
        }

        private void dgLineOEEActivity_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            colFromName = Convert.ToString(dgLineOEEActivity.Columns[e.ColumnIndex].HeaderText);
            if (colFromName == "24:00")
                colFromName = "00:00";
            colFromNumber = Convert.ToInt32(e.ColumnIndex);
            gridcolFromNumber = colFromNumber;
        }

        private void dgLineOEEActivity_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgLineOEEActivity_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex != -1 && e.ColumnIndex != -1)
            //{
            //    if (dgLineOEEActivity[e.ColumnIndex, e.RowIndex].Style.BackColor == Color.Red)
            //    {
            //        //dgLineOEEActivity[e.ColumnIndex, e.RowIndex].ToolTipText = "Comment";
            //    }
            //}
        }



        // Check already exist all data other than fg
        int gridcolFromNumber, gridcolToNumber = 0;

        string fgName, lineName, shiftName, transDate, colToTime = "";
        private bool CheckExistLineNumberDate()
        {

            //LineOEETransaction_Obj.lno = Convert.ToInt32(frmPMTrans.cmbLineNo.SelectedValue);
            //LineOEETransaction_Obj.transDate = frmPMTrans.dtpTransDate.Value;
            //LineOEETransaction_Obj.shiftID = Convert.ToInt32(frmPMTrans.cmbShift.SelectedValue);

            //DataTable dtCheckFG = new DataTable();
            //dtCheckFG = LineOEETransaction_Obj.Select_LineOEEDetails_Lno_TransDate_Shift();
            //dgLineOEEActivity.Enabled = true;
            //// code check for fg change but all available
            //foreach (DataRow drCheck in dtCheckFG.Rows)
            //{
            //    if (Convert.ToInt64(cmbFGCode.SelectedValue) != Convert.ToInt64(drCheck["FGNo"]))
            //    {
            //        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
            //        DataSet ds = new DataSet();
            //        FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(drCheck["FGNo"]);
            //        ds = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFgMaster_FGNo();
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            fgName = Convert.ToString(ds.Tables[0].Rows[0]["FGCode"]);
            //        }

            //        lineName = Convert.ToString(cmbLineNo.Text);
            //        shiftName = Convert.ToString(cmbShift.Text);
            //        shiftName = shiftName.Substring(0, 6);
            //        transDate = Convert.ToString(dtpTransDate.Text);
            //        DataTable dtCheckMax = new DataTable();
            //        LineOEETransaction_Obj.detailID = Convert.ToInt64(drCheck["DetailID"]);
            //        dtCheckMax = LineOEETransaction_Obj.Select_LineOEEComment();

            //        if (dtCheckMax.Rows.Count > 0)
            //        {
            //            int colToNumberCheckMax, colFromNumberCheckMin = 0;
            //            string selectCmd = "Min(colFromNumber)";
            //            colFromNumberCheckMin = Convert.ToInt32((object)dtCheckMax.Compute(selectCmd, string.Empty));

            //            string selectCommand1 = "Max(colToNumber)";
            //            colToNumberCheckMax = Convert.ToInt32((object)dtCheckMax.Compute(selectCommand1, string.Empty));

            //            if (gridcolFromNumber >= colFromNumberCheckMin && gridcolFromNumber <= colToNumberCheckMax || gridcolToNumber >= colFromNumberCheckMin && gridcolToNumber <= colToNumberCheckMax)
            //            {
            //                //dgLineOEEActivity.Enabled = false;
            //                txtFormNumber.Enabled = true;
            //                //txtFormNumber.Text = "0";
            //                //txtFormNumber.Focus();                                  

            //                string selectCommand = "Max(LineActivityID)";
            //                int lineID = Convert.ToInt32((object)dtCheckMax.Compute(selectCommand, string.Empty));

            //                dgLineOEEActivity.CurrentCell = dgLineOEEActivity.Rows[lineID - 1].Cells[colToNumberCheckMax];
            //                dgLineOEEActivity.ClearSelection();
            //                if (colToNumberCheckMax == 96)
            //                    colToTime = Convert.ToString(dgLineOEEActivity.Columns[colToNumberCheckMax].HeaderText);
            //                else
            //                    colToTime = Convert.ToString(dgLineOEEActivity.Columns[colToNumberCheckMax + 1].HeaderText);
            //                return true;
            //            }
            //        }

            //    }
            //}
            return false;
        }




        private void dgLineOEEActivity_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex > 0)
            {
                try
                {
                    gridcolToNumber = Convert.ToInt32(e.ColumnIndex);
                    // Check Form no exist                        
                    DataTable dtFormNo = new DataTable();
                    dtFormNo = LineOEETransaction_Obj.Select_LineOEEDetails_FormNumber();
                    colToName = Convert.ToString(dgLineOEEActivity.Columns[e.ColumnIndex].HeaderText);

                    if (colToName == "24:00")
                        colToName = "00:00";
                    colToNumber = Convert.ToInt32(e.ColumnIndex);
                    shiftID = Convert.ToInt32(LineOEETransaction_Obj.shiftID);
                    if (colToNumber < colFromNumber)
                    {
                        colToNumber = colFromNumber;
                        colFromNumber = e.ColumnIndex;
                        colToName = colFromName;
                        colFromName = Convert.ToString(dgLineOEEActivity.Columns[e.ColumnIndex].HeaderText);
                    }

                    string actID = Convert.ToString(dgLineOEEActivity["LineActivityID", e.RowIndex].Value);
                    string actName = Convert.ToString(dgLineOEEActivity[0, e.RowIndex].Value);
                    int Mod = Convert.ToInt32(dgLineOEEActivity[e.ColumnIndex, 0].Value);

                    FrmLineOEETransactionComments objLineOEE = new FrmLineOEETransactionComments(actName, Convert.ToInt32(actID), colFromName, colToName, LineOEETransaction_Obj.detailID, Convert.ToInt32(Mod), colFromNumber, colToNumber, shiftID, Convert.ToInt32(LineOEETransaction_Obj.lno), LineHrsID, LineOEETransaction_Obj.transDate);
                    objLineOEE.ShowDialog();
                    frmHourWiseActivity_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgLineOEEActivity_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dgLineOEEActivity_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            LineOEETransaction_Obj.detailID = detailID;
            dt = LineOEETransaction_Obj.Select_LineOEEDetails_LineOEEComments();
            if (dt.Rows.Count > 0)
            {
                if (MessageBox.Show("Delete All Comments ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    bool flag;
                    flag = LineOEETransaction_Obj.Delete_LineOEEComment_DetailID_LineHrsID();
                    if (flag == true)
                    {
                        MessageBox.Show("Record clear successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            BindGrid3(Value);

        }

    }
}