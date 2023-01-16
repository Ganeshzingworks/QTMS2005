using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QTMS.Tools;
using Excel = Microsoft.Office.Interop.Excel;
using BusinessFacade.Transactions;

namespace QTMS.Reports_Forms
{
    public partial class FrmLineOEEBreackDownReport : Form
    {
        public string rptName;
        private string strMsg;

        public FrmLineOEEBreackDownReport()
        {
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        LineOEETransaction LineOEETransaction_obj = new LineOEETransaction();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        DateTime date = new DateTime();
        bool flgExcel = false;
        # endregion
        Excel.Application application = null;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;
        Excel.Range workSheet_range = null;

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLineOEEBreackDownReport_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 100;

            date = DateTime.Now;//Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
        }

        private bool IsValid()
        {
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
                    LineOEETransaction_obj.startdate = DtpDateFrom.Value.ToShortDateString();

                }
                else
                {
                    //LineOEETransaction_obj.startdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                    MessageBox.Show("Please select the start date", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (DtpDateTo.Checked == true)
                {
                    LineOEETransaction_obj.enddate = DtpDateTo.Value.ToShortDateString();

                }
                else
                {
                    //LineOEETransaction_obj.enddate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                    MessageBox.Show("Please select the end date", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                //if (txtPath.Text == "")
                //{
                //    MessageBox.Show("Select Export Path", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtPath.Focus();
                //    return false;
                //}
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        string todaysdate = "", excelFolderPath = "", excelFileName = "";
        DataTable dt = null;

        private void btnGenerateExcel_Click(object sender, EventArgs e)
        {
            try
            {

                if (IsValid())
                {

                    if (!bkgWorkerExcel.IsBusy)
                    {
                        btnGenerateExcel.Enabled = false;
                        btnExit.Enabled = false;
                        toolStripButtonClose.Enabled = false;
                        bkgWorkerExcel.RunWorkerAsync();
                        timer1.Start();
                        //MessageBox.Show(toolStripLabelMsgName.Text, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void GetOEEProcessData()
        {
            try
            {                
                todaysdate = Convert.ToString(date);
                dt = new DataTable();
                dt = LineOEETransaction_obj.Select_LineOEE_BreackDown_Report();
                
                if (dt.Rows.Count > 0)
                {
                    //                    CreateExcelFile(excelFolderPath, excelFileName, dt);
                    CreateExcelFile(dt);
                    flgExcel = true;
                }
                //btnGenerateExcel.Enabled = true;    
                else
                {
                    flgExcel = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CreateExcelFile(DataTable dtExcel)//(string efolderPath,string eFile, DataTable dtExcel)
        {
            try
            {
                application = new Excel.ApplicationClass();

                workbook = application.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];

                CreateHeaders(2, 1, "Shift", "A2", "A2", 0, "DARK YELLOW", true, 10);                
                CreateHeaders(2, 2, "Form Number", "B2", "B2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 3, "Date", "C2", "C2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 4, "Line No.", "D2", "D2", 0, "DARK YELLOW", true, 10);                
                CreateHeaders(2, 5, "FG Code", "E2", "E2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 6, "QTY", "F2", "F2", 0, "DARK YELLOW", true, 10); // SMT
                CreateHeaders(2, 7, "Line Speed", "G2", "G2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 8, "Machine Name", "H2", "H2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 9, "Breakdown Time in Minutes", "I2", "I2", 0, "LIGHT GREEN", true, 10);

                for (int row = 0; row < dtExcel.Rows.Count; row++)
                {
                    workSheet_range.WrapText = true;

                    worksheet.Cells[row + 3, 1] = dtExcel.Rows[row]["Shift"].ToString();
                    workSheet_range = worksheet.get_Range("A" + (row + 3), "A" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    workSheet_range.Interior.ColorIndex = 36;

                    worksheet.Cells[row + 3, 2] = dtExcel.Rows[row]["FormNumber"].ToString();
                    workSheet_range = worksheet.get_Range("B" + (row + 3), "B" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    workSheet_range.Interior.ColorIndex = 36;

                    worksheet.Cells[row + 3, 3] = string.Format("{0:dd/MM/yyyy}", dtExcel.Rows[row]["TransDate"]).Trim();
                    workSheet_range = worksheet.get_Range("C" + (row + 3), "C" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    workSheet_range.Interior.ColorIndex = 36;

                    worksheet.Cells[row + 3, 4] = dtExcel.Rows[row]["LineDesc"].ToString();
                    workSheet_range = worksheet.get_Range("D" + (row + 3), "D" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    workSheet_range.Interior.ColorIndex = 36;

                    worksheet.Cells[row + 3, 5] = dtExcel.Rows[row]["FGCode"].ToString();
                    workSheet_range = worksheet.get_Range("E" + (row + 3), "E" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    workSheet_range.Interior.ColorIndex = 36;

                    if (Convert.ToString(dtExcel.Rows[row]["ProducedUnit"]) != "0")
                    {
                        worksheet.Cells[row + 3, 6] = Convert.ToString(dtExcel.Rows[row]["ProducedUnit"].ToString());// SMT
                        workSheet_range = worksheet.get_Range("F" + (row + 3), "F" + (row + 3));
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("F" + (row + 3), "F" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["LineSpeed"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 7] = dtExcel.Rows[row]["LineSpeed"].ToString();
                        workSheet_range = worksheet.get_Range("G" + (row + 3), "G" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("G" + (row + 3), "G" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }

                    worksheet.Cells[row + 3, 8] = dtExcel.Rows[row]["MachineName"].ToString();
                    workSheet_range = worksheet.get_Range("H" + (row + 3), "H" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    workSheet_range.Interior.ColorIndex = 36;

                    if (Convert.ToString(dtExcel.Rows[row]["BreakDownTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 9] = dtExcel.Rows[row]["BreakDownTime"].ToString();
                        workSheet_range = worksheet.get_Range("I" + (row + 3), "I" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("I" + (row + 3), "I" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }

                }

               

                //SAVE WORKBOOK AT EXPORT PATH
                //workbook.SaveAs(eFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                application.Visible = true;
                //application.Workbooks.Close();


                releaseObject(workbook);
                releaseObject(worksheet);
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

        private void bkgWorkerExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            if (bkgWorkerExcel.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            GetOEEProcessData();

        }

        private void bkgWorkerExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (flgExcel == true)
                strMsg = "Excel Created Successfully";
            else
                strMsg = " ";

            toolStripProgressBar1.Value = 100;

            bkgWorkerExcel.Dispose();
            //Enable buttons
            btnGenerateExcel.Enabled = true;
            btnExit.Enabled = true;
            toolStripButtonClose.Enabled = true;
            timer1.Stop();
            //MessageBox.Show(strMsg);
            //txtPath.Text = "";
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



    }
}