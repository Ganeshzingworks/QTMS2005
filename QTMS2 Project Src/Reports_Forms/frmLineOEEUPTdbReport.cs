using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade.Transactions;
using Excel = Microsoft.Office.Interop.Excel;


namespace QTMS.Reports_Forms
{
    public partial class frmLineOEEUPTdbReport : Form
    {
        LineOEETransaction objLineOEETransaction = new LineOEETransaction();
        bool flgExcel = false;
        private string strMsg;
        DateTime date = new DateTime();
        Excel.Application application = null;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;
        Excel.Range workSheet_range = null;
        DataTable dtUpTdb = new DataTable();
        DataTable dtS84bis  = new DataTable();
        DataTable dtS83 = new DataTable();
        DataTable dtS84 = new DataTable();
       

        

        private void frmLineOEEUPTdbReport_Load(object sender, EventArgs e)
        {
           
        }
        public frmLineOEEUPTdbReport()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
      
        }
        
        private void btnGenerateExcel_Click(object sender, EventArgs e)
        {
            try
            {
                 
                if (IsValid())
                {

                    if (!bkgWorkerExcelUPTdb .IsBusy)
                    {
                        btnClose.Enabled = false ;
                        toolStripButtonClose.Enabled = false;
                        btnGenerateExcel.Enabled = false ;

                        bkgWorkerExcelUPTdb.RunWorkerAsync();
                        timer1.Start();
               
                    }
                }
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

        }

        private bool IsValid()
        {
            objLineOEETransaction = new LineOEETransaction();
            try
            {
                if (DtpDateFrom.Checked && DtpDateTo.Checked)
                {
                    if (DtpDateFrom.Value > DtpDateTo.Value)
                    {
                        MessageBox.Show("End date should be gretter than start date.");
                        return false;
                    }
                }

                if (DtpDateFrom.Checked == true)
                {
                    objLineOEETransaction.startdate = DtpDateFrom.Value.ToShortDateString();
                }
                else
                {
                    //LineOEETransaction_obj.startdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                    MessageBox.Show("Please select the start date","Line OEE",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return false;
                }

                if (DtpDateTo.Checked == true)
                {
                    objLineOEETransaction.enddate = DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    //LineOEETransaction_obj.enddate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                    MessageBox.Show("Please select the end date", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (chklstLineOEEReport.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select at least one report", "Line OEE Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
               
                return true;
            }
            catch (Exception)
            {
                throw;
            }
       
        }


        private void bkgWorkerExcelUPTdb_DoWork(object sender, DoWorkEventArgs e)
        {
            if (bkgWorkerExcelUPTdb.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            else
            {

                foreach (object chk in chklstLineOEEReport.CheckedItems)
                {
                     
                     

                        if (chk.ToString() == "UP Tdb Report")
                        {
                            // report for UPTdb
                            //  GetOEEUPTdbProcessData();
                            // select line OEE Up Tdb report in datatable
                            dtUpTdb = objLineOEETransaction.Select_LineOEE_UPTdb_Report();

                        }
                        if (chk.ToString() == "S84 bis Report")
                        {
                            // report for S84bis       
                            // GetOEES84bisProcessData();
                            // select line OEE Up Tdb report in datatable
                            dtS84bis = objLineOEETransaction.Select_LineOEE_S84bis_Report();
                        }
                        if (chk.ToString() == "S83 Report")
                        {
                            // report for S84bis       
                            // GetOEES84bisProcessData();
                            // select line OEE Up Tdb report in datatable
                            dtS83 = objLineOEETransaction.Select_LineOEE_S83_Report();
                        }
                        if (chk.ToString() == "S84 Report")
                        {
                            // report for S84bis       
                            // GetOEES84bisProcessData();
                            // select line OEE Up Tdb report in datatable
                            dtS84 = objLineOEETransaction.Select_LineOEE_S84_Report();
                        }
                    }
                }
           
            if (dtUpTdb.Rows.Count > 0 || dtS84bis.Rows.Count > 0 || dtS83.Rows.Count > 0 || dtS84.Rows.Count>0)
            {
                GenerateExcelFile(dtUpTdb, dtS84bis, dtS83, dtS84);
                flgExcel = true;
                dtUpTdb.Clear();
                dtS84bis.Clear();
                dtS83.Clear();
                dtS84.Clear();
            }
            else
            {

                flgExcel = false;
            }
  
         }



        private void GenerateExcelFile(DataTable dtUpTdb, DataTable dtS84bis, DataTable dtS83, DataTable dtS84)
        {
            try
            {
            application = new Excel.ApplicationClass();
            workbook = application.Workbooks.Add(Type.Missing);
            int cnt = 0;

            if (dtUpTdb.Rows.Count > 0)
            {
                //worksheet = (Excel.Worksheet)workbook.Sheets[++cnt];
                ////worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
                //worksheet.Name = "UPTdb";

                if (cnt == 0)
                {
                    //if only last excel i.e. S84 selected then its position is at 1
                    worksheet = (Excel.Worksheet)workbook.Sheets[++cnt];
                    worksheet.Name = "UPTdb";
                }
                else
                {
                    worksheet = (Excel.Worksheet)workbook.Sheets.Add(Type.Missing, (Excel.Worksheet)workbook.Sheets.get_Item(cnt), Type.Missing, Type.Missing);
                    //---   (Excel.Worksheet)workbook.Sheets.get_Item(3)
                    worksheet.Name = "UPTdb";
                }


                // Headers
                CreateHeaders(1, 1, "Line No.", "A1", "A1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 2, "Time spent on Reference C/O.", "B1", "B1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 3, "No.Of Reference", "C1", "C1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 4, "Time Per Ref. C/O.", "D1", "D1", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(1, 5, "Time Spent On Formula C/O", "E1", "E1", 0, "DARK YELLOW", true, 10); // SMT
                CreateHeaders(1, 6, "No. Of Formula C/O.", "F1", "F1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 7, "Time Per Formula C/O.", "G1", "G1", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(1, 8, "Time Spent On Format C/O", "H1", "H1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 9, "No.Of Format C/O.", "I1", "I1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 10, "Time Per Format C/O", "J1", "J1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 11, "Total C/O. Minutes ", "K1", "K1", 0, "DARK RED", true, 10);
                CreateHeaders(1, 12, "Nominal Speed Time in Minutes", "L1", "L1", 0, "SKY BLUE", true, 10);
                CreateHeaders(1, 13, "Operating Time in Minutes", "M1", "M1", 0, "SKY BLUE", true, 10);
                CreateHeaders(1, 14, "Planned Prod. Time in Minutes", "N1", "N1", 0, "SKY BLUE", true, 10);
                CreateHeaders(1, 15, "Real Speed", "O1", "O1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 16, "Actual Quantity", "P1", "P1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 17, "Waiting Time in Minutes", "Q1", "Q1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 18, "Breakdown Time in Minutes", "R1", "R1", 0, "DARK YELLOW", true, 12);
                CreateHeaders(1, 19, "Mechanicle Time(%)", "S1", "S1", 0, "DARK YELLOW", true, 12);
                CreateHeaders(1, 20, "OEE (GUTR)(%)", "T1", "T1", 0, "DARK YELLOW", true, 10);

                CreateHeaders(1, 21, "Change Over %", "U1", "U1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 22, "Waitings %", "V1", "V1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 23, "Bulk Waiting %", "W1", "W1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 24, "Material Waiting %", "X1", "X1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 25, "PM Defect Loss %", "Y1", "Y1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 26, "Tank Change %", "Z1", "Z1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 27, "Other Waiting %", "AA1", "AA1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 28, "Break down %", "AB1", "AB1", 0, "DARK YELLOW", true, 10);
                CreateHeaders(1, 29, "Micro Stops %", "AC1", "AC1", 0, "DARK YELLOW", true, 10);

                //CreateHeaders(1, 21, "ssss", "U1", "U1", 0, "DARK YELLOW", true, 10);
                //CreateHeaders(1, 22, "sssssss", "V1", "V1", 0, "DARK YELLOW", true, 10);
                //CreateHeaders(1, 23, "ssssss", "W1", "W1", 0, "DARK YELLOW", true, 10);
                //CreateHeaders(1, 24, "sssssss", "X1", "X1", 0, "DARK YELLOW", true, 10);


                for (int row = 0; row < dtUpTdb.Rows.Count; row++)
                {
                    //workSheet_range.NumberFormat = "0.00";
                    workSheet_range.WrapText = true;
                    //progressBar1.Value++;
                    //workSheet_range = worksheet.get_Range("A" + (row + 3), "T" + (row + 3));
                    //workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                    //workSheet_range.NumberFormat = "0.000";
                    //workSheet_range.Font.Color =  System.Drawing.Color.Blue .ToArgb();
                    //workSheet_range.Interior.ColorIndex = 36;
                    //bkgWorkerExcel.ReportProgress((int)((float)row+1/(float)dtExcel.Rows.Count*100));
                   

                    worksheet.Cells[row + 2, 1] = dtUpTdb.Rows[row]["LineNumber"].ToString();
                    worksheet.Cells[row + 2, 2] = dtUpTdb.Rows[row]["TimeSpentOnRef"].ToString();
                    worksheet.Cells[row + 2, 3] = dtUpTdb.Rows[row]["NoOfRef"].ToString();
                    worksheet.Cells[row + 2, 4] = dtUpTdb.Rows[row]["TimePerRef"].ToString();
                    worksheet.Cells[row + 2, 5] = dtUpTdb.Rows[row]["TimeSpentOnFormuls"].ToString();
                    worksheet.Cells[row + 2, 6] = dtUpTdb.Rows[row]["NoOfFormula"].ToString();
                    worksheet.Cells[row + 2, 7] = dtUpTdb.Rows[row]["TimePerFormula"].ToString();
                    worksheet.Cells[row + 2, 8] = dtUpTdb.Rows[row]["TimeSpentOnFormat"].ToString();
                    worksheet.Cells[row + 2, 9] = dtUpTdb.Rows[row]["NumOfFormat"].ToString();
                    worksheet.Cells[row + 2, 10] = dtUpTdb.Rows[row]["TimePerFormat"].ToString();
                    worksheet.Cells[row + 2, 11] = dtUpTdb.Rows[row]["TotalMinutesCO"].ToString();
                    worksheet.Cells[row + 2, 12] = dtUpTdb.Rows[row]["NominalSpeed"].ToString();
                    worksheet.Cells[row + 2, 13] = dtUpTdb.Rows[row]["OperatingSpeedTime"].ToString();
                    worksheet.Cells[row + 2, 14] = dtUpTdb.Rows[row]["PlannedProdTime"].ToString();
                    worksheet.Cells[row + 2, 15] = dtUpTdb.Rows[row]["RealSpeed"].ToString();
                    worksheet.Cells[row + 2, 16] = dtUpTdb.Rows[row]["ActualQuantity"].ToString();
                    worksheet.Cells[row + 2, 17] = dtUpTdb.Rows[row]["WaitingTime"].ToString();
                    worksheet.Cells[row + 2, 18] = dtUpTdb.Rows[row]["BreakDownTime"].ToString();
                    worksheet.Cells[row + 2, 19] = dtUpTdb.Rows[row]["MechanicleTime"].ToString();
                    worksheet.Cells[row + 2, 20] = dtUpTdb.Rows[row]["OEE"].ToString();

                    worksheet.Cells[row + 2, 21] = dtUpTdb.Rows[row]["ChangeOver"].ToString();
                    worksheet.Cells[row + 2, 22] = dtUpTdb.Rows[row]["Waitings"].ToString();
                    worksheet.Cells[row + 2, 23] = dtUpTdb.Rows[row]["BulkWaiting"].ToString();
                    worksheet.Cells[row + 2, 24] = dtUpTdb.Rows[row]["MaterialWaiting"].ToString();
                    worksheet.Cells[row + 2, 25] = dtUpTdb.Rows[row]["PMDefectLoss"].ToString();
                    worksheet.Cells[row + 2, 26] = dtUpTdb.Rows[row]["TankChange"].ToString();
                    worksheet.Cells[row + 2, 27] = dtUpTdb.Rows[row]["OtherWaiting"].ToString();
                    worksheet.Cells[row + 2, 28] = dtUpTdb.Rows[row]["Breakdown"].ToString();
                    worksheet.Cells[row + 2, 29] = dtUpTdb.Rows[row]["MicroStops"].ToString();

                }
                //..
                
            }
                if (dtS84bis.Rows.Count > 0)
                {
                    //worksheet = (Excel.Worksheet)workbook.Sheets[++cnt];
                    //worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(2);
                   //worksheet.Name = "S84bis";

                    if (cnt == 0)
                    {
                        //if only last excel i.e. S84 selected then its position is at 1
                        worksheet = (Excel.Worksheet)workbook.Sheets[++cnt];
                        worksheet.Name = "S84bis";
                    }
                    else
                    {
                        worksheet = (Excel.Worksheet)workbook.Sheets.Add(Type.Missing, (Excel.Worksheet)workbook.Sheets.get_Item(cnt), Type.Missing, Type.Missing);
                        //---   (Excel.Worksheet)workbook.Sheets.get_Item(3)
                        worksheet.Name = "S84bis";
                    }

                    CreateHeaders(1, 1, "Family of Products", "A1", "A1", 0, "LIGHT GREEN", true, 20);
                    CreateHeaders(1, 2, "MOD hours with N-1 UST", "B1", "B1", 0, "LIGHT GREEN", true, 20);
                    CreateHeaders(1, 3, "MOD Hours with N UST", "C1", "C1", 0, "LIGHT GREEN", true, 20);
                    CreateHeaders(1, 4, "MOD Productivity (%)", "D1", "D1", 0, "LIGHT GREEN", true, 20);
 

                    for (int row = 0; row < dtS84bis.Rows.Count; row++)
                    {
                        //workSheet_range.NumberFormat = "0.00";
                        workSheet_range.WrapText = true;

                        if (dtS84bis.Rows[row]["BudgetFamily"].ToString().Trim() == ""  || dtS84bis.Rows[row]["BudgetFamily"].ToString().Trim() == null)
                        {
                            worksheet.Cells[row + 2, 1] = "---";
                        }
                        else
                        {
                            worksheet.Cells[row + 2, 1] = dtS84bis.Rows[row]["BudgetFamily"].ToString();
                        }
                        worksheet.Cells[row + 2, 2] = dtS84bis.Rows[row]["StanderdManhour"].ToString();
                        worksheet.Cells[row + 2, 3] = dtS84bis.Rows[row]["ActualManhour"].ToString();

                        // code for showing color
                        string compare2 = Convert.ToString(dtS84bis.Rows[row]["ModProductivity"]);
                        if (compare2.Contains("-"))
                        {
                            worksheet.Cells[row + 2, 4] = dtS84bis.Rows[row]["ModProductivity"].ToString();
                            workSheet_range = worksheet.get_Range("D" + (row + 2), "D" + (row + 2));
                            workSheet_range.NumberFormat = "0.000";
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 36;
                        }
                        else
                        {
                            worksheet.Cells[row + 2, 4] = dtS84bis.Rows[row]["ModProductivity"].ToString();
                            workSheet_range = worksheet.get_Range("D" + (row + 2), "D" + (row + 2));
                            workSheet_range.NumberFormat = "0.000";
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 2;
                        }

                    }
                }  //..
                if (dtS83.Rows.Count > 0)
                {
                    //worksheet = (Excel.Worksheet)workbook.Sheets[++cnt];
                    //worksheet = (Excel.Worksheet)workbook.Sheets.get_Item(3);

                    if (cnt == 0)
                    {
                        //if only last excel i.e. S84 selected then its position is at 1
                        worksheet = (Excel.Worksheet)workbook.Sheets[++cnt];
                        worksheet.Name = "S83";
                    }
                    else
                    {
                        worksheet = (Excel.Worksheet)workbook.Sheets.Add(Type.Missing, (Excel.Worksheet)workbook.Sheets.get_Item(cnt), Type.Missing, Type.Missing);
                        //---   (Excel.Worksheet)workbook.Sheets.get_Item(3)
                        worksheet.Name = "S83";
                    }


                     //worksheet.Name = "S83";
                    CreateHeaders(1, 1, "Line No.", "A1", "A1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 2, "Actual Production(Units)", "B1", "B1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 3, "Nominal Speed Time in Minutes", "C1", "C1", 0, "LIGHT GREEN", true, 20);
                    CreateHeaders(1, 4, "Operating Time in Minutes", "D1", "D1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 5, "Mechanicle Uptime(%)", "E1", "E1", 0, "LIGHT GREEN", true, 12);
                    CreateHeaders(1, 6, "Actual ProductionSpeed", "F1", "F1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 7, "Real Production Speed", "G1", "G1", 0, "LIGHT GREEN", true, 10);


                    for (int row = 0; row < dtS83.Rows.Count; row++)
                    {
                        //workSheet_range.NumberFormat = "0.00";
                        workSheet_range.WrapText = true;

                        //bkgWorkerExcel.ReportProgress((int)((float)row+1/(float)dtExcel.Rows.Count*100));
                        worksheet.Cells[row + 2, 1] = dtS83.Rows[row]["LineNumber"].ToString();
                        worksheet.Cells[row + 2, 2] = dtS83.Rows[row]["ActualProduction"].ToString();
                        worksheet.Cells[row + 2, 3] = dtS83.Rows[row]["NominalSpeed"].ToString();
                        worksheet.Cells[row + 2, 4] = dtS83.Rows[row]["OperatingSpeedTime"].ToString();
                        worksheet.Cells[row + 2, 5] = dtS83.Rows[row]["MechanicleUptime"].ToString();
                        worksheet.Cells[row + 2, 6] = dtS83.Rows[row]["ActualProductionSpeed"].ToString();
                        worksheet.Cells[row + 2, 7] = dtS83.Rows[row]["RealProductionSpeed"].ToString();
                    }
                }  //..

                if (dtS84.Rows.Count > 0)
                {
                   // worksheet = (Excel.Worksheet)workbook.Sheets[++cnt];
                    if (cnt == 0)
                    {
                        //if only last excel i.e. S84 selected then its position is at 1
                        worksheet = (Excel.Worksheet)workbook.Sheets[++cnt];
                        worksheet.Name = "S84";
                    }
                    else
                    {   
                        worksheet = (Excel.Worksheet)workbook.Sheets.Add(Type.Missing, (Excel.Worksheet)workbook.Sheets.get_Item(cnt), Type.Missing, Type.Missing);
                    //---   (Excel.Worksheet)workbook.Sheets.get_Item(3)
                          worksheet.Name = "S84";
                    }

                    CreateHeaders(1, 1, "Line #", "A1", "A1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 2, "Production Units Needed", "B1", "B1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 3, "MOS Std Hours", "C1", "C1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 4, "MOS Actual Hours", "D1", "D1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 5, "MOS Eff. Variance (%)", "E1", "E1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 6, "MEC STD HRS", "F1", "F1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 7, "MEC STD TIME(Mechanical STD Time)", "G1", "G1", 0, "LIGHT GREEN", true, 10);

                    for (int row = 0; row < dtS84.Rows.Count; row++)
                    {                       
                        workSheet_range.WrapText = true;

                        worksheet.Cells[row + 2, 1] = dtS84.Rows[row]["LineNumber"].ToString();
                        worksheet.Cells[row + 2, 2] = dtS84.Rows[row]["ProducedUnit"].ToString();
                        worksheet.Cells[row + 2, 3] = dtS84.Rows[row]["MODStdHours"].ToString();
                        worksheet.Cells[row + 2, 4] = dtS84.Rows[row]["MODActualHour"].ToString();
                        worksheet.Cells[row + 2, 5] = dtS84.Rows[row]["MODEffVariance"].ToString();
                        worksheet.Cells[row + 2, 6] = dtS84.Rows[row]["MECSTDHRS"].ToString();
                        worksheet.Cells[row + 2, 7] = dtS84.Rows[row]["MECSTDTIME"].ToString();
                        
                        //// code for - MOD Effective Variance
                        //string compare = Convert.ToString(dtS84.Rows[row]["MODEffVariance"]);
                        //if (compare.Contains("-"))
                        //{
                        //    worksheet.Cells[row + 2, 5] = dtS84.Rows[row]["MODEffVariance"].ToString();
                        //    workSheet_range = worksheet.get_Range("G" + (row + 2), "G" + (row + 2));
                        //    workSheet_range.NumberFormat = "0.000";
                        //    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        //    workSheet_range.Interior.ColorIndex = 36;
                        //}
                        //else
                        //{
                        //    worksheet.Cells[row + 2, 5] = dtS84.Rows[row]["MODEffVariance"].ToString();
                        //    workSheet_range = worksheet.get_Range("G" + (row + 2), "G" + (row + 2));
                        //    workSheet_range.NumberFormat = "0.000";
                        //    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        //    workSheet_range.Interior.ColorIndex = 2;
                        //}
                       
                    }


                    /*
                    CreateHeaders(1, 1, "Line #", "A1", "A1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 2, "Production MOD Standerd Hours", "B1", "B1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 3, "Actual Prod Time * MOD Std Workforce", "C1", "C1", 0, "LIGHT GREEN", true, 15);
                    CreateHeaders(1, 4, "MOD Eff. Variance Due to Line Efficiency(%)", "D1", "D1", 0, "LIGHT GREEN", true, 15);
                    CreateHeaders(1, 5, "MOD Std Hours", "E1", "E1", 0, "LIGHT GREEN", true, 15);
                    CreateHeaders(1, 6, "MOD Actual Hours", "F1", "F1", 0, "LIGHT GREEN", true, 10);
                    CreateHeaders(1, 7, "MOD Eff. Variance(%)", "G1", "G1", 0, "LIGHT GREEN", true, 12);

                    for (int row = 0; row < dtS84.Rows.Count; row++)
                    {
                        //workSheet_range.NumberFormat = "0.00";
                        workSheet_range.WrapText = true;

                        worksheet.Cells[row + 2, 1] = dtS84.Rows[row]["LineNumber"].ToString();
                        worksheet.Cells[row + 2, 2] = dtS84.Rows[row]["ProdModStanderdHour"].ToString();
                        worksheet.Cells[row + 2, 3] = dtS84.Rows[row]["ActualProdMODStdWF"].ToString();

                        // code for - MOD Effective Variance Due to Line Efficiency
                        string compare1 = Convert.ToString(dtS84.Rows[row]["MODEffVarianceLineEff"]);
                        if (compare1.Contains("-"))
                        {
                            worksheet.Cells[row + 2, 4] = dtS84.Rows[row]["MODEffVarianceLineEff"].ToString();
                            workSheet_range = worksheet.get_Range("D" + (row + 2), "D" + (row + 2));
                            workSheet_range.NumberFormat = "0.000";
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 36;
                        }
                        else
                        {
                            worksheet.Cells[row + 2, 4] = dtS84.Rows[row]["MODEffVarianceLineEff"].ToString();
                            workSheet_range = worksheet.get_Range("D" + (row + 2), "D" + (row + 2));
                            workSheet_range.NumberFormat = "0.000";
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 2;
                        }

                        worksheet.Cells[row + 2, 5] = dtS84.Rows[row]["MODStdHours"].ToString();
                        worksheet.Cells[row + 2, 6] = dtS84.Rows[row]["MODActualHour"].ToString();

                        // code for - MOD Effective Variance
                        string compare = Convert.ToString (dtS84.Rows[row]["MODEffVariance"]);
                        if ( compare.Contains("-"))
                        {
                            worksheet.Cells[row + 2, 7] = dtS84.Rows[row]["MODEffVariance"].ToString();
                            workSheet_range = worksheet.get_Range("G" + (row + 2), "G" + (row + 2));
                            workSheet_range.NumberFormat = "0.000";
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex =36;
                        }
                        else
                        {
                            worksheet.Cells[row + 2, 7] = dtS84.Rows[row]["MODEffVariance"].ToString();
                            workSheet_range = worksheet.get_Range("G" + (row + 2), "G" + (row + 2));
                            workSheet_range.NumberFormat = "0.000";
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                            workSheet_range.Interior.ColorIndex = 2;
                        }
                       
                    }
                   */
                }  //..
 
             
                
                application.Visible = true;
                
                releaseObject(worksheet);
                releaseObject(workbook);
               
                releaseObject(application);
                //application.Quit();
                //efolderPath = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
               
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void CreateHeaders(int row, int col, string hText, string cell1, string cell2, int mergeColumn, string b, bool font, int size)
        {
            try
            {
                worksheet.Cells[row, col] = hText;
                workSheet_range = worksheet.get_Range(cell1, cell2);
                workSheet_range.Merge(mergeColumn);
                workSheet_range.WrapText = true;


                switch (b)
                {
                    case "DARK YELLOW":
                        workSheet_range.Interior.ColorIndex = 36;
                        break;
                    case "YELLOW":
                        //workSheet_range.Interior.Color = System.Drawing.Color.Yellow.ToArgb();
                        workSheet_range.Interior.ColorIndex = 27; //Color index 45 means Yellow mix color
                        break;
                    case "GRAY":
                        workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
                        break;
                    case "GAINSBORO":
                        workSheet_range.Interior.Color = System.Drawing.Color.Gainsboro.ToArgb();
                        break;
                    case "Turquoise":
                        workSheet_range.Interior.Color = System.Drawing.Color.Turquoise.ToArgb();
                        workSheet_range.Interior.ColorIndex = 8;
                        break;
                    case "AQUA":
                        workSheet_range.Interior.ColorIndex = 42;
                        break;
                    case "PeachPuff":
                        workSheet_range.Interior.Color = System.Drawing.Color.PeachPuff.ToArgb();
                        break;
                    case "TEAL":
                        workSheet_range.Interior.ColorIndex = 14;
                        break;
                    case "GREEN":
                        workSheet_range.Interior.ColorIndex = 10;
                        break;
                    case "LIGHT GREEN":
                        workSheet_range.Interior.ColorIndex = 35;
                        break;
                    case "TAN":
                        workSheet_range.Interior.ColorIndex = 40;            
                        break;
                    case "DARK BLUE":
                        workSheet_range.Interior.ColorIndex = 5;
                        break;
                    case "DARK RED":
                        workSheet_range.Interior.ColorIndex = 3;
                        break;
                    case "SKY BLUE":
                        workSheet_range.Interior.ColorIndex = 33;
                        break;
                    default:
                        //  workSheet_range.Interior.Color = System.Drawing.Color..ToArgb();
                        break;
                }
                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                workSheet_range.Font.Bold = font;
                workSheet_range.ColumnWidth = size;
                workSheet_range.HorizontalAlignment = Excel.Constants.xlCenter;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void bkgWorkerExcelUPTdb_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (flgExcel == true)
                strMsg = "Excel Created Successfully";
            else
                strMsg = " ";

            toolStripProgressBar1.Value = 100;

            bkgWorkerExcelUPTdb .Dispose();
            // Enable buttons
            btnGenerateExcel.Enabled = true;
            btnClose.Enabled = true;
            toolStripButtonClose.Enabled = true ;
            timer1.Stop();
            //MessageBox.Show(strMsg);
            txtPath.Text = "";
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
            toolStripProgressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now.Subtract(date);
            string sTime = "    " + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            toolStripStatusLabelTime.Text = sTime;
            if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
            {
                toolStripProgressBar1.Value = 0;
            }
            toolStripProgressBar1.PerformStep();
        }

       

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

         

       

       
    }
}