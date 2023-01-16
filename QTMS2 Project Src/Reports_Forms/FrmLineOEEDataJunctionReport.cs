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
using BusinessFacade;


namespace QTMS.Reports_Forms
{
    public partial class FrmLineOEEDataJunctionReport : Form
    {
        public string rptName;
        private string strMsg;

        public FrmLineOEEDataJunctionReport()
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

        private void BtnShow_Click(object sender, EventArgs e)
        {

        }
        private static FrmLineOEEDataJunctionReport FrmLineOEEDataJunctionReport_Obj = null;
        public static FrmLineOEEDataJunctionReport GetInstance()
        {
            if (FrmLineOEEDataJunctionReport_Obj == null)
            {
                FrmLineOEEDataJunctionReport_Obj = new FrmLineOEEDataJunctionReport();
            }
            return FrmLineOEEDataJunctionReport_Obj;
        }
        private void FrmLineOEEDataJunctionReport_Load(object sender, EventArgs e)
        {
            // this.WindowState = FormWindowState.Normal;

            Painter.Paint(this);

            //toolStrip1.Items.Add(rptName);
            //toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 100;

            date = DateTime.Now;//Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog ePath = new FolderBrowserDialog();
                if (DialogResult.OK == ePath.ShowDialog())
                {
                    txtPath.Text = ePath.SelectedPath;
                }
                ePath.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                //btnGenerateExcel.Enabled = false;
                //progressBar1.Value = 5;    
                todaysdate = Convert.ToString(date);
                dt = new DataTable();
                dt = LineOEETransaction_obj.Select_LineOEE_DataJunction_Report();
                //excelFolderPath = txtPath.Text + "\\" + todaysdate.Replace("/", "_").Replace(":", "_").Replace(" ", "_");
                //excelFileName = txtPath.Text + "\\" + "Line OEE " + todaysdate.Replace("/", "_").Replace(":", "_").Replace(" ", "_") + "\\" + "Line OEE Data Junction" + todaysdate.Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".xls";
                //progressBar1.Maximum = dt.Rows.Count + 15;
                //Creating  Directory if not Exists.
                //if (!Directory.Exists(excelFolderPath))
                //{
                //    Directory.CreateDirectory(excelFolderPath);

                //}
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

        public void AddExcelVal(int Rowid,int ColumnId,string Value,string Char,string Type,Microsoft.Office.Interop.Excel.Worksheet ex,Excel.Range rng)
        {
            if (Type == "String")
            {
                ex.Cells[Rowid, ColumnId] = Value.ToString();
                rng = ex.get_Range(Char + (Rowid), Char + (Rowid));
                rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
                rng.Interior.ColorIndex = 36;
            }
            else if (Type == "Date") 
            {
                ex.Cells[Rowid, ColumnId] = Convert.ToDateTime( Value).ToString("dd/MM/yyyy").Trim();
                rng = ex.get_Range(Char + (Rowid), Char + (Rowid));
                rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
                rng.Interior.ColorIndex = 36;
                string sd = Convert.ToDateTime(Value).ToString("dd/MM/yyyy").Trim();
            }
            else if (Type == "Units")
            {
                if (Convert.ToString(Value) != "0.000")
                {
                    worksheet.Cells[Rowid, ColumnId] = Convert.ToString(Value);// SMT
                    rng = ex.get_Range(Char + (Rowid), Char + (Rowid));
                    rng.NumberFormat = "0.000";
                    rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng.Interior.ColorIndex = 36;
                }
                else
                {
                    rng = worksheet.get_Range(Char + (Rowid), Char + (Rowid));
                    rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng.Interior.ColorIndex = 36;
                }
            }
            else if (Type == "Line")
            {
                if (Convert.ToString(Value) != "0.000")
                {
                    worksheet.Cells[Rowid, ColumnId] = Value .ToString();
                    rng = worksheet.get_Range(Char + (Rowid),Char + (Rowid));
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                    rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng.Interior.ColorIndex = 36;
                }
                else
                {
                    rng = worksheet.get_Range(Char+ (Rowid),Char + (Rowid));
                    rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng.Interior.ColorIndex = 36;
                }
            }
            else if (Type == "Time")
            {
                if (Convert.ToString(Value) != "0.000")
                {
                    worksheet.Cells[Rowid, ColumnId] = Value.ToString();
                    rng = worksheet.get_Range(Char + (Rowid), Char + (Rowid));
                    rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                    rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng.Interior.ColorIndex = 35;
                }
                else
                {
                    rng = worksheet.get_Range(Char + (Rowid), Char + (Rowid));
                    rng.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    rng.Interior.ColorIndex = 35;
                }
            }

        }

        #region Commented
        //private void CreateExcelFile(DataTable dtExcel)//(string efolderPath,string eFile, DataTable dtExcel)
        //{
        //    try
        //    {
        //        application = new Excel.ApplicationClass();

        //        workbook = application.Workbooks.Add(Type.Missing);
        //        worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];

        //        // Headers
        //        CreateHeaders(2, 1, "Form Number", "A2", "A2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 2, "Date", "B2", "B2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 3, "Line No.", "C2", "C2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 4, "FG Code", "D2", "D2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 5, "QTY", "E2", "E2", 0, "DARK YELLOW", true, 10); // SMT
        //        CreateHeaders(2, 6, "Line Speed", "F2", "F2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 7, "Planned Production Time in Minutes", "G2", "G2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 8, "Planned Production Man Minutes", "H2", "H2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 9, "Breakdown Time in Minutes", "I2", "I2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 10, "Change Over time in Minutes", "J2", "J2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 11, "Format Change Over Count", "K2", "K2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 12, "Formula Change Over Count", "L2", "L2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 13, "Reference Change Over Count", "M2", "M2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 14, "Waiting Time in Minutes", "N2", "N2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 15, "Bulk Delay min.", "O2", "O2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 16, "Material Delay Min.", "P2", "P2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 17, "PM Defect", "Q2", "Q2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 18, "Tank Change Time in Minutes", "R2", "R2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 19, "Other waitings time in minutes", "S2", "S2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 20, "Waiting Time in Man Minutes", "T2", "T2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 21, "Microstops Time in Min.", "U2", "U2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 22, "Product Description", "V2", "V2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 23, "Budgeted Line Speed", "W2", "W2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 24, "UST Last Year", "X2", "X2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 25, "UST Current Year", "Y2", "Y2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 26, "Prod UST Current Year", "Z2", "Z2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 27, "Family", "AA2", "AA2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 28, "Standard Manhour with N-1 Real Std. Time ", "AB2", "AB2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 29, "Actual Manhours", "AC2", "AC2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 30, "MOD Standard Workforce", "AD2", "AD2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 31, "Production MOD standard Time", "AE2", "AE2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 32, "Actual Prod time x MODStd Wrokforce", "AF2", "AF2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 33, "Standard Manhour with N Budget Std Time", "AG2", "AG2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 34, "Planned Production Time in Minutes", "AH2", "AH2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 35, "Nominal speed Time in Minutes", "AI2", "AI2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 36, "Operating Time in Minutes", "AJ2", "AJ2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 37, "Actual Production Speed", "AK2", "AK2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 38, "Productivity", "AL2", "AL2", 0, "DARK YELLOW", true, 13);
        //        CreateHeaders(2, 39, "Mechanical Uptime", "AM2", "AM2", 0, "DARK YELLOW", true, 12);
        //        CreateHeaders(2, 40, "OEE (GUTR)", "AN2", "AN2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 41, "Change Over %", "AO2", "AO2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 42, "Waitings %", "AP2", "AP2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 43, "Bulk Waiting %", "AQ2", "AQ2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 44, "Material Waiting %", "AR2", "AR2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 45, "PM Defect Loss %", "AS2", "AS2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 46, "Tank Change %", "AT2", "AT2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 47, "Other Waiting %", "AU2", "AU2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 48, "Break down %", "AV2", "AV2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 49, "Micro Stops %", "AW2", "AW2", 0, "DARK YELLOW", true, 10);

        //        for (int row = 0; row < dtExcel.Rows.Count; row++)
        //        {
        //            //workSheet_range.NumberFormat = "0.00";
        //            workSheet_range.WrapText = true;
        //            //progressBar1.Value++;
        //            //bkgWorkerExcel.ReportProgress((int)((float)row+1/(float)dtExcel.Rows.Count*100));
        //            worksheet.Cells[row + 3, 1] = dtExcel.Rows[row]["FormNumber"].ToString();
        //            workSheet_range = worksheet.get_Range("A" + (row + 3), "A" + (row + 3));
        //            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //            workSheet_range.Interior.ColorIndex = 36;
        //            //worksheet.Cells[row + 2, 2] = agent_id;
        //            worksheet.Cells[row + 3, 2] = string.Format("{0:dd/MM/yyyy}", dtExcel.Rows[row]["TransDate"]).Trim();
        //            workSheet_range = worksheet.get_Range("B" + (row + 3), "B" + (row + 3));
        //            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //            workSheet_range.Interior.ColorIndex = 36;
        //            //worksheet.Cells[row + 3, 2] = dtExcel.Rows[row]["LineNumber"].ToString();

        //            worksheet.Cells[row + 3, 3] = dtExcel.Rows[row]["LineNumber"].ToString();
        //            workSheet_range = worksheet.get_Range("C" + (row + 3), "C" + (row + 3));
        //            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //            workSheet_range.Interior.ColorIndex = 36;

        //            if (Convert.ToString(dtExcel.Rows[row]["FGCode"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 4] = dtExcel.Rows[row]["FGCode"].ToString(); // TONS PRODUCED
        //                workSheet_range = worksheet.get_Range("D" + (row + 3), "D" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("D" + (row + 3), "D" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ProducedUnit"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 5] = Convert.ToString(dtExcel.Rows[row]["ProducedUnit"].ToString());// SMT
        //                workSheet_range = worksheet.get_Range("E" + (row + 3), "E" + (row + 3));
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("E" + (row + 3), "E" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["LineSpeed"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 6] = dtExcel.Rows[row]["LineSpeed"].ToString();
        //                workSheet_range = worksheet.get_Range("F" + (row + 3), "F" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("F" + (row + 3), "F" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }

        //            if (Convert.ToString(dtExcel.Rows[row]["TotalTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 7] = dtExcel.Rows[row]["TotalTime"].ToString();
        //                workSheet_range = worksheet.get_Range("G" + (row + 3), "G" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("G" + (row + 3), "G" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }

        //            if (Convert.ToString(dtExcel.Rows[row]["MODTotalTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 8] = dtExcel.Rows[row]["MODTotalTime"].ToString();
        //                workSheet_range = worksheet.get_Range("H" + (row + 3), "H" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("H" + (row + 3), "H" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }

        //            if (Convert.ToString(dtExcel.Rows[row]["BreakDownTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 9] = dtExcel.Rows[row]["BreakDownTime"].ToString();
        //                workSheet_range = worksheet.get_Range("I" + (row + 3), "I" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("I" + (row + 3), "I" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ChangeOverTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 10] = dtExcel.Rows[row]["ChangeOverTime"].ToString();// Numbers Of Batch
        //                workSheet_range = worksheet.get_Range("J" + (row + 3), "J" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("J" + (row + 3), "J" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["FormatChangeOver"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 11] = dtExcel.Rows[row]["FormatChangeOver"].ToString();
        //                workSheet_range = worksheet.get_Range("K" + (row + 3), "K" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("K" + (row + 3), "K" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["FormulaChangeOver"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 12] = dtExcel.Rows[row]["FormulaChangeOver"].ToString();
        //                workSheet_range = worksheet.get_Range("L" + (row + 3), "L" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("L" + (row + 3), "L" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ReferenceChangeOver"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 13] = dtExcel.Rows[row]["ReferenceChangeOver"].ToString();
        //                workSheet_range = worksheet.get_Range("M" + (row + 3), "M" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("M" + (row + 3), "M" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["WaitingTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 14] = dtExcel.Rows[row]["WaitingTime"].ToString();
        //                workSheet_range = worksheet.get_Range("N" + (row + 3), "N" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("N" + (row + 3), "N" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["BulkDelayTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 15] = dtExcel.Rows[row]["BulkDelayTime"].ToString();
        //                workSheet_range = worksheet.get_Range("O" + (row + 3), "O" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("O" + (row + 3), "O" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["MaterialDelayTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 16] = dtExcel.Rows[row]["MaterialDelayTime"].ToString();
        //                workSheet_range = worksheet.get_Range("P" + (row + 3), "P" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("P" + (row + 3), "P" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ReworkDuringProd"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 17] = dtExcel.Rows[row]["ReworkDuringProd"].ToString();
        //                workSheet_range = worksheet.get_Range("Q" + (row + 3), "Q" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("Q" + (row + 3), "Q" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["TankChangeTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 18] = dtExcel.Rows[row]["TankChangeTime"].ToString();
        //                workSheet_range = worksheet.get_Range("R" + (row + 3), "R" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("R" + (row + 3), "R" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["OtherWaitingTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 19] = dtExcel.Rows[row]["OtherWaitingTime"].ToString();
        //                workSheet_range = worksheet.get_Range("S" + (row + 3), "S" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("S" + (row + 3), "S" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["WaitingTimeManMin"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 20] = dtExcel.Rows[row]["WaitingTimeManMin"].ToString();// CHANGE-OVER TIME
        //                workSheet_range = worksheet.get_Range("T" + (row + 3), "T" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("T" + (row + 3), "T" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["MicroStopTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 21] = dtExcel.Rows[row]["MicroStopTime"].ToString();
        //                workSheet_range = worksheet.get_Range("U" + (row + 3), "U" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("U" + (row + 3), "U" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["FGDesc"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 22] = dtExcel.Rows[row]["FGDesc"].ToString(); // TONS PRODUCED
        //                workSheet_range = worksheet.get_Range("V" + (row + 3), "V" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("V" + (row + 3), "V" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["BudgetLineSpeed"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 23] = dtExcel.Rows[row]["BudgetLineSpeed"].ToString();
        //                workSheet_range = worksheet.get_Range("W" + (row + 3), "W" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("W" + (row + 3), "W" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["USTLastYear"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 24] = dtExcel.Rows[row]["USTLastYear"].ToString(); // BREAKDOWN TIME
        //                workSheet_range = worksheet.get_Range("X" + (row + 3), "X" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("X" + (row + 3), "X" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["USTCurrentYear"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 25] = dtExcel.Rows[row]["USTCurrentYear"].ToString();// PROCESSING TIME
        //                workSheet_range = worksheet.get_Range("Y" + (row + 3), "Y" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("Y" + (row + 3), "Y" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ProductionUST"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 26] = dtExcel.Rows[row]["ProductionUST"].ToString();
        //                workSheet_range = worksheet.get_Range("Z" + (row + 3), "Z" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("Z" + (row + 3), "Z" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["BudgetFamily"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 27] = dtExcel.Rows[row]["BudgetFamily"].ToString();
        //                workSheet_range = worksheet.get_Range("AA" + (row + 3), "AA" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AA" + (row + 3), "AA" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["STDManHourLastYear"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 28] = dtExcel.Rows[row]["STDManHourLastYear"].ToString();
        //                workSheet_range = worksheet.get_Range("AB" + (row + 3), "AB" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AB" + (row + 3), "AB" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }

        //            if (Convert.ToString(dtExcel.Rows[row]["ActualManHourCurrentYear"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 29] = dtExcel.Rows[row]["ActualManHourCurrentYear"].ToString();
        //                workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["MODSTDWorkForce"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 30] = dtExcel.Rows[row]["MODSTDWorkForce"].ToString();
        //                workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ProdMODSTDTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 31] = dtExcel.Rows[row]["ProdMODSTDTime"].ToString();
        //                workSheet_range = worksheet.get_Range("AE" + (row + 3), "AE" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AE" + (row + 3), "AE" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["APTINTOMODSTDWorkForce"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 32] = dtExcel.Rows[row]["APTINTOMODSTDWorkForce"].ToString();
        //                workSheet_range = worksheet.get_Range("AF" + (row + 3), "AF" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AF" + (row + 3), "AF" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["STDManHourBudgetSTDTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 33] = dtExcel.Rows[row]["STDManHourBudgetSTDTime"].ToString();
        //                workSheet_range = worksheet.get_Range("AG" + (row + 3), "AG" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AG" + (row + 3), "AG" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["PlanProdTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 34] = dtExcel.Rows[row]["PlanProdTime"].ToString();
        //                workSheet_range = worksheet.get_Range("AH" + (row + 3), "AH" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AH" + (row + 3), "AH" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "000.000";
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["NominalSpeedTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 35] = dtExcel.Rows[row]["NominalSpeedTime"].ToString();
        //                workSheet_range = worksheet.get_Range("AI" + (row + 3), "AI" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AI" + (row + 3), "AI" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["OperatingTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 36] = dtExcel.Rows[row]["OperatingTime"].ToString();
        //                workSheet_range = worksheet.get_Range("AJ" + (row + 3), "AJ" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AJ" + (row + 3), "AJ" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ActualProdSpeed"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 37] = dtExcel.Rows[row]["ActualProdSpeed"].ToString();
        //                workSheet_range = worksheet.get_Range("AK" + (row + 3), "AK" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 37] = dtExcel.Rows[row]["ActualProdSpeed"].ToString();
        //                workSheet_range = worksheet.get_Range("AK" + (row + 3), "AK" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["Productivity"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 38] = dtExcel.Rows[row]["Productivity"].ToString();
        //                workSheet_range = worksheet.get_Range("AL" + (row + 3), "AL" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 38] = "Launch";
        //                workSheet_range = worksheet.get_Range("AL" + (row + 3), "AL" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["MechanicalUptime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 39] = dtExcel.Rows[row]["MechanicalUptime"].ToString();
        //                workSheet_range = worksheet.get_Range("AM" + (row + 3), "AM" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 39] = dtExcel.Rows[row]["MechanicalUptime"].ToString();
        //                workSheet_range = worksheet.get_Range("AM" + (row + 3), "AM" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["OEE"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 40] = dtExcel.Rows[row]["OEE"].ToString();
        //                workSheet_range = worksheet.get_Range("AN" + (row + 3), "AN" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 40] = dtExcel.Rows[row]["OEE"].ToString();
        //                workSheet_range = worksheet.get_Range("AN" + (row + 3), "AN" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ChangeOver"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 41] = dtExcel.Rows[row]["ChangeOver"].ToString();
        //                workSheet_range = worksheet.get_Range("AO" + (row + 3), "AO" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 41] = dtExcel.Rows[row]["ChangeOver"].ToString();
        //                workSheet_range = worksheet.get_Range("AO" + (row + 3), "AO" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["Waitings"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 42] = dtExcel.Rows[row]["Waitings"].ToString();
        //                workSheet_range = worksheet.get_Range("AP" + (row + 3), "AP" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 42] = dtExcel.Rows[row]["Waitings"].ToString();
        //                workSheet_range = worksheet.get_Range("AP" + (row + 3), "AP" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["BulkWaiting"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 43] = dtExcel.Rows[row]["BulkWaiting"].ToString();
        //                workSheet_range = worksheet.get_Range("AQ" + (row + 3), "AQ" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 43] = dtExcel.Rows[row]["BulkWaiting"].ToString();
        //                workSheet_range = worksheet.get_Range("AQ" + (row + 3), "AQ" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["MaterialWaiting"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 44] = dtExcel.Rows[row]["MaterialWaiting"].ToString();
        //                workSheet_range = worksheet.get_Range("AR" + (row + 3), "AR" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 44] = dtExcel.Rows[row]["MaterialWaiting"].ToString();
        //                workSheet_range = worksheet.get_Range("AR" + (row + 3), "AR" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["PMDefectLoss"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 45] = dtExcel.Rows[row]["PMDefectLoss"].ToString();
        //                workSheet_range = worksheet.get_Range("AS" + (row + 3), "AS" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 45] = dtExcel.Rows[row]["PMDefectLoss"].ToString();
        //                workSheet_range = worksheet.get_Range("AS" + (row + 3), "AS" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["TankChange"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 46] = dtExcel.Rows[row]["TankChange"].ToString();
        //                workSheet_range = worksheet.get_Range("AT" + (row + 3), "AT" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 46] = dtExcel.Rows[row]["TankChange"].ToString();
        //                workSheet_range = worksheet.get_Range("AT" + (row + 3), "AT" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["OtherWaiting"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 47] = dtExcel.Rows[row]["OtherWaiting"].ToString();
        //                workSheet_range = worksheet.get_Range("AU" + (row + 3), "AU" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 47] = dtExcel.Rows[row]["OtherWaiting"].ToString();
        //                workSheet_range = worksheet.get_Range("AU" + (row + 3), "AU" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["Breakdown"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 48] = dtExcel.Rows[row]["Breakdown"].ToString();
        //                workSheet_range = worksheet.get_Range("AV" + (row + 3), "AV" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 48] = dtExcel.Rows[row]["Breakdown"].ToString();
        //                workSheet_range = worksheet.get_Range("AV" + (row + 3), "AV" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["MicroStops"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 49] = dtExcel.Rows[row]["MicroStops"].ToString();
        //                workSheet_range = worksheet.get_Range("AW" + (row + 3), "AW" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 49] = dtExcel.Rows[row]["MicroStops"].ToString();
        //                workSheet_range = worksheet.get_Range("AW" + (row + 3), "AW" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //        }


        //        #region Comments by avinash for create new excel sheet
        //        /*
        //        // Headers
        //        CreateHeaders(2, 1, "Form Number", "A2", "A2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 2, "Date", "B2", "B2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 3, "Line No.", "C2", "C2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 4, "FG Code", "D2", "D2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 5, "QTY", "E2", "E2", 0, "DARK YELLOW", true, 10); // SMT
        //        CreateHeaders(2, 6, "Line Speed", "F2", "F2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 7, "Planned Production Time in Minutes", "G2", "G2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 8, "Planned Production Man Minutes", "H2", "H2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 9, "Breakdown Time in Minutes", "I2", "I2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 10, "Tank Change Time in Minutes", "J2", "J2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 11, "Change Over time in Minutes", "K2", "K2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 12, "Format Change Over", "L2", "L2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 13, "Formula Change Over", "M2", "M2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 14, "Reference Change Over", "N2", "N2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 15, "Other waitings time in minutes", "O2", "O2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 16, "Waiting Time in Minutes", "P2", "P2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 17, "Waiting Time in Man Minutes", "Q2", "Q2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 18, "Microstops Time in Min.", "R2", "R2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 19, "Microstops Time in Man Min.", "S2", "S2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 20, "Bulk Delay min.", "T2", "T2", 0, "LIGHT GREEN", true, 10);
        //        CreateHeaders(2, 21, "Material Delay Min.", "u2", "U2", 0, "LIGHT GREEN", true, 10);
                
        //        CreateHeaders(2, 22, "Budgeted Line Speed", "V2", "V2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 23, "UST Last Year", "W2", "W2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 24, "UST Current Year", "X2", "X2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 25, "Prod UST Current Year", "Y2", "Y2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 26, "Family", "Z2", "Z2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 27, "Standard Manhour with N-1 Real Std. Time ", "AA2", "AA2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 28, "Actual Manhours", "AB2", "AB2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 29, "MOD Standard Workforce", "AC2", "AC2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 30, "Production MOD standard Time", "AD2", "AD2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 31, "Actual Prod time x MODStd Wrokforce", "AE2", "AE2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 32, "Standard Manhour with N Budget Std Time", "AF2", "AF2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 33, "Planned Production Time in Minutes", "AG2", "AG2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 34, "Nominal speed Time in Minutes", "AH2", "AH2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 35, "Operating Time in Minutes", "AI2", "AI2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 36, "Actual Production Speed", "AJ2", "AJ2", 0, "DARK YELLOW", true, 10);
        //        CreateHeaders(2, 37, "Productivity", "AK2", "AK2", 0, "DARK YELLOW", true, 13);
        //        CreateHeaders(2, 38, "Mechanical Uptime", "AL2", "AL2", 0, "DARK YELLOW", true, 12);
        //        CreateHeaders(2, 39, "OEE (GUTR)", "AM2", "AM2", 0, "DARK YELLOW", true, 10);


        //        //worksheet.Cells[6, 1] = "Vessel Name";
        //        //worksheet.Cells[1, 2] = "agent_id";
        //        //worksheet.Cells[6, 2] = "Family Name";
        //        //worksheet.Cells[6, 3] = "Tons produced(T.)";

        //        for (int row = 0; row < dtExcel.Rows.Count; row++)
        //        {
        //            //workSheet_range.NumberFormat = "0.00";
        //            workSheet_range.WrapText = true;
        //            //progressBar1.Value++;
        //            //bkgWorkerExcel.ReportProgress((int)((float)row+1/(float)dtExcel.Rows.Count*100));
        //            worksheet.Cells[row + 3, 1] = dtExcel.Rows[row]["FormNumber"].ToString();                    
        //            workSheet_range = worksheet.get_Range("A" + (row + 3), "A" + (row + 3));
        //            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //            workSheet_range.Interior.ColorIndex = 36;
        //            //worksheet.Cells[row + 2, 2] = agent_id;
        //            worksheet.Cells[row + 3, 2] = string.Format("{0:dd/MM/yyyy}", dtExcel.Rows[row]["TransDate"]).Trim();
        //            workSheet_range = worksheet.get_Range("B" + (row + 3), "B" + (row + 3));
        //            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //            workSheet_range.Interior.ColorIndex = 36;
        //            //worksheet.Cells[row + 3, 2] = dtExcel.Rows[row]["LineNumber"].ToString();

        //            worksheet.Cells[row + 3, 3] = dtExcel.Rows[row]["LineNumber"].ToString();
        //            workSheet_range = worksheet.get_Range("C" + (row + 3), "C" + (row + 3));
        //            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //            workSheet_range.Interior.ColorIndex = 36;

        //            if (Convert.ToString(dtExcel.Rows[row]["FGCode"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 4] = dtExcel.Rows[row]["FGCode"].ToString(); // TONS PRODUCED
        //                workSheet_range = worksheet.get_Range("D" + (row + 3), "D" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("D" + (row + 3), "D" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ProducedUnit"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 5] = Convert.ToString(dtExcel.Rows[row]["ProducedUnit"].ToString());// SMT
        //                workSheet_range = worksheet.get_Range("E" + (row + 3), "E" + (row + 3));
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("E" + (row + 3), "E" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["LineSpeed"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 6] = dtExcel.Rows[row]["LineSpeed"].ToString();
        //                workSheet_range = worksheet.get_Range("F" + (row + 3), "F" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("F" + (row + 3), "F" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }

        //            if (Convert.ToString(dtExcel.Rows[row]["TotalTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 7] = dtExcel.Rows[row]["TotalTime"].ToString();
        //                workSheet_range = worksheet.get_Range("G" + (row + 3), "G" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("G" + (row + 3), "G" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }

        //            if (Convert.ToString(dtExcel.Rows[row]["MODTotalTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 8] = dtExcel.Rows[row]["MODTotalTime"].ToString();
        //                workSheet_range = worksheet.get_Range("H" + (row + 3), "H" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("H" + (row + 3), "H" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }

        //            if (Convert.ToString(dtExcel.Rows[row]["BreakDownTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 9] = dtExcel.Rows[row]["BreakDownTime"].ToString();
        //                workSheet_range = worksheet.get_Range("I" + (row + 3), "I" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("I" + (row + 3), "I" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }

        //            if (Convert.ToString(dtExcel.Rows[row]["TankChangeTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 10] = dtExcel.Rows[row]["TankChangeTime"].ToString();
        //                workSheet_range = worksheet.get_Range("J" + (row + 3), "J" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("J" + (row + 3), "J" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ChangeOverTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 11] = dtExcel.Rows[row]["ChangeOverTime"].ToString();// Numbers Of Batch
        //                workSheet_range = worksheet.get_Range("K" + (row + 3), "K" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("K" + (row + 3), "K" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }

        //            if (Convert.ToString(dtExcel.Rows[row]["FormatChangeOver"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 12] = dtExcel.Rows[row]["FormatChangeOver"].ToString();                        
        //                workSheet_range = worksheet.get_Range("L" + (row + 3), "L" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("L" + (row + 3), "L" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["FormulaChangeOver"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 13] = dtExcel.Rows[row]["FormulaChangeOver"].ToString();
        //                workSheet_range = worksheet.get_Range("M" + (row + 3), "M" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("M" + (row + 3), "M" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ReferenceChangeOver"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 14] = dtExcel.Rows[row]["ReferenceChangeOver"].ToString();
        //                workSheet_range = worksheet.get_Range("N" + (row + 3), "N" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("N" + (row + 3), "N" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["OtherWaitingTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 15] = dtExcel.Rows[row]["OtherWaitingTime"].ToString();
        //                workSheet_range = worksheet.get_Range("O" + (row + 3), "O" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;                        
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("O" + (row + 3), "O" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["WaitingTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 16] = dtExcel.Rows[row]["WaitingTime"].ToString();
        //                workSheet_range = worksheet.get_Range("P" + (row + 3), "P" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("P" + (row + 3), "P" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }

        //            if (Convert.ToString(dtExcel.Rows[row]["WaitingTimeManMin"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 17] = dtExcel.Rows[row]["WaitingTimeManMin"].ToString();// CHANGE-OVER TIME
        //                workSheet_range = worksheet.get_Range("Q" + (row + 3), "Q" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("Q" + (row + 3), "Q" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["MicroStopTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 18] = dtExcel.Rows[row]["MicroStopTime"].ToString();
        //                workSheet_range = worksheet.get_Range("R" + (row + 3), "R" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;                        
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("R" + (row + 3), "R" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["MODMicroStopTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 19] = dtExcel.Rows[row]["MODMicroStopTime"].ToString();
        //                workSheet_range = worksheet.get_Range("S" + (row + 3), "S" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;                       
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("S" + (row + 3), "S" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "00";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["BulkDelayTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 20] = dtExcel.Rows[row]["BulkDelayTime"].ToString();
        //                workSheet_range = worksheet.get_Range("T" + (row + 3), "T" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("T" + (row + 3), "T" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["MaterialDelayTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 21] = dtExcel.Rows[row]["MaterialDelayTime"].ToString();
        //                workSheet_range = worksheet.get_Range("U" + (row + 3), "U" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("U" + (row + 3), "U" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 35;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["BudgetLineSpeed"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 22] = dtExcel.Rows[row]["BudgetLineSpeed"].ToString();
        //                workSheet_range = worksheet.get_Range("V" + (row + 3), "V" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("V" + (row + 3), "V" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["USTLastYear"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 23] = dtExcel.Rows[row]["USTLastYear"].ToString(); // BREAKDOWN TIME
        //                workSheet_range = worksheet.get_Range("W" + (row + 3), "W" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("W" + (row + 3), "W" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["USTCurrentYear"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 24] = dtExcel.Rows[row]["USTCurrentYear"].ToString();// PROCESSING TIME
        //                workSheet_range = worksheet.get_Range("X" + (row + 3), "X" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("X" + (row + 3), "X" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ProductionUST"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 25] = dtExcel.Rows[row]["ProductionUST"].ToString();
        //                workSheet_range = worksheet.get_Range("Y" + (row + 3), "Y" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("Y" + (row + 3), "Y" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["BudgetFamily"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 26] = dtExcel.Rows[row]["BudgetFamily"].ToString();
        //                workSheet_range = worksheet.get_Range("Z" + (row + 3), "Z" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("Z" + (row + 3), "Z" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["STDManHourLastYear"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 27] = dtExcel.Rows[row]["STDManHourLastYear"].ToString();
        //                workSheet_range = worksheet.get_Range("AA" + (row + 3), "AA" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AA" + (row + 3), "AA" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ActualManHourCurrentYear"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 28] = dtExcel.Rows[row]["ActualManHourCurrentYear"].ToString();
        //                workSheet_range = worksheet.get_Range("AB" + (row + 3), "AB" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AB" + (row + 3), "AB" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["MODSTDWorkForce"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 29] = dtExcel.Rows[row]["MODSTDWorkForce"].ToString();
        //                workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ProdMODSTDTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 30] = dtExcel.Rows[row]["ProdMODSTDTime"].ToString();
        //                workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["APTINTOMODSTDWorkForce"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 31] = dtExcel.Rows[row]["APTINTOMODSTDWorkForce"].ToString();
        //                workSheet_range = worksheet.get_Range("AE" + (row + 3), "AE" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AE" + (row + 3), "AE" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["STDManHourBudgetSTDTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 32] = dtExcel.Rows[row]["STDManHourBudgetSTDTime"].ToString();
        //                workSheet_range = worksheet.get_Range("AF" + (row + 3), "AF" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AF" + (row + 3), "AF" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["PlanProdTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 33] = dtExcel.Rows[row]["PlanProdTime"].ToString();
        //                workSheet_range = worksheet.get_Range("AG" + (row + 3), "AG" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AG" + (row + 3), "AG" + (row + 3));
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "000.000";
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["NominalSpeedTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 34] = dtExcel.Rows[row]["NominalSpeedTime"].ToString();
        //                workSheet_range = worksheet.get_Range("AH" + (row + 3), "AH" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AH" + (row + 3), "AH" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["OperatingTime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 35] = dtExcel.Rows[row]["OperatingTime"].ToString();
        //                workSheet_range = worksheet.get_Range("AI" + (row + 3), "AI" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                workSheet_range = worksheet.get_Range("AI" + (row + 3), "AI" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["ActualProdSpeed"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 36] = dtExcel.Rows[row]["ActualProdSpeed"].ToString();                        
        //                workSheet_range = worksheet.get_Range("AJ" + (row + 3), "AJ" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 36] = dtExcel.Rows[row]["ActualProdSpeed"].ToString();
        //                workSheet_range = worksheet.get_Range("AJ" + (row + 3), "AJ" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["Productivity"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 37] = dtExcel.Rows[row]["Productivity"].ToString();
        //                workSheet_range = worksheet.get_Range("AK" + (row + 3), "AK" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 37] = "Launch";
        //                workSheet_range = worksheet.get_Range("AK" + (row + 3), "AK" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;                        
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["MechanicalUptime"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 38] = dtExcel.Rows[row]["MechanicalUptime"].ToString();
        //                workSheet_range = worksheet.get_Range("AL" + (row + 3), "AL" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 38] = dtExcel.Rows[row]["MechanicalUptime"].ToString();
        //                workSheet_range = worksheet.get_Range("AL" + (row + 3), "AL" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            if (Convert.ToString(dtExcel.Rows[row]["OEE"]) != "0.000")
        //            {
        //                worksheet.Cells[row + 3, 39] = dtExcel.Rows[row]["OEE"].ToString();
        //                workSheet_range = worksheet.get_Range("AM" + (row + 3), "AM" + (row + 3));                       
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
        //            else
        //            {
        //                worksheet.Cells[row + 3, 39] = dtExcel.Rows[row]["OEE"].ToString();
        //                workSheet_range = worksheet.get_Range("AM" + (row + 3), "AM" + (row + 3));
        //                workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
        //                workSheet_range.NumberFormat = "0.000";
        //                workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //                workSheet_range.Interior.ColorIndex = 36;
        //            }
                    
        //        }

        //        */
        //        #endregion



        //        //SAVE WORKBOOK AT EXPORT PATH
        //        //workbook.SaveAs(eFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //        application.Visible = true;
        //        //application.Workbooks.Close();


        //        releaseObject(workbook);
        //        releaseObject(worksheet);
        //        releaseObject(application);
        //        //application.Quit();
        //        //efolderPath = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {

        //    }
        //}
        #endregion


        private void CreateExcelFile(DataTable dtExcel)//(string efolderPath,string eFile, DataTable dtExcel)
        {
            try
            {
                application = new Excel.ApplicationClass();

                workbook = application.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];

                // Headers
                CreateHeaders(2, 1, "Form Number", "A2", "A2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 2, "Date", "B2", "B2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 3, "Line No.", "C2", "C2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 4, "FG Code", "D2", "D2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 5, "QTY", "E2", "E2", 0, "DARK YELLOW", true, 10); // SMT
                CreateHeaders(2, 6, "Line Speed", "F2", "F2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 7, "Planned Production Time in Minutes", "G2", "G2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 8, "Planned Production Man Minutes", "H2", "H2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 9, "Breakdown Time in Minutes", "I2", "I2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 10, "Change Over time in Minutes", "J2", "J2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 11, "Format Change Over Count", "K2", "K2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 12, "Formula Change Over Count", "L2", "L2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 13, "Reference Change Over Count", "M2", "M2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 14, "Waiting Time in Minutes", "N2", "N2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 15, "Bulk Delay min.", "O2", "O2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 16, "Material Delay Min.", "P2", "P2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 17, "PM Defect", "Q2", "Q2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 18, "Tank Change Time in Minutes", "R2", "R2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 19, "Other waitings time in minutes", "S2", "S2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 20, "Waiting Time in Man Minutes", "T2", "T2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 21, "Microstops Time in Min.", "U2", "U2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 22, "Product Description", "V2", "V2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 23, "Budgeted Line Speed", "W2", "W2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 24, "UST Last Year", "X2", "X2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 25, "UST Current Year", "Y2", "Y2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 26, "Prod UST Current Year", "Z2", "Z2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 27, "Family", "AA2", "AA2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 28, "Standard Manhour with N-1 Real Std. Time ", "AB2", "AB2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 29, "Actual Manhours", "AC2", "AC2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 30, "MOD Standard Workforce", "AD2", "AD2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 31, "Production MOD standard Time", "AE2", "AE2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 32, "Actual Prod time x MODStd Wrokforce", "AF2", "AF2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 33, "Standard Manhour with N Budget Std Time", "AG2", "AG2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 34, "Planned Production Time in Minutes", "AH2", "AH2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 35, "Nominal speed Time in Minutes", "AI2", "AI2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 36, "Operating Time in Minutes", "AJ2", "AJ2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 37, "Actual Production Speed", "AK2", "AK2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 38, "Productivity", "AL2", "AL2", 0, "DARK YELLOW", true, 13);
                CreateHeaders(2, 39, "Mechanical Uptime", "AM2", "AM2", 0, "DARK YELLOW", true, 12);
                CreateHeaders(2, 40, "OEE (GUTR)", "AN2", "AN2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 41, "Change Over %", "AO2", "AO2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 42, "Waitings %", "AP2", "AP2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 43, "Bulk Waiting %", "AQ2", "AQ2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 44, "Material Waiting %", "AR2", "AR2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 45, "PM Defect Loss %", "AS2", "AS2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 46, "Tank Change %", "AT2", "AT2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 47, "Other Waiting %", "AU2", "AU2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 48, "Break down %", "AV2", "AV2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 49, "Micro Stops %", "AW2", "AW2", 0, "DARK YELLOW", true, 10);

                for (int row = 0; row < dtExcel.Rows.Count; row++)
                {
                    workSheet_range.WrapText = true;
                    AddExcelVal(row + 3, 1, dtExcel.Rows[row]["FormNumber"].ToString(),"A", "String", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 2, dtExcel.Rows[row]["TransDate"].ToString(), "B", "Date", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 3, dtExcel.Rows[row]["LineNumber"].ToString(),"C", "String", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 4, dtExcel.Rows[row]["FGCode"].ToString(), "D", "String", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 5, dtExcel.Rows[row]["ProducedUnit"].ToString(), "E", "Units", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 6, dtExcel.Rows[row]["LineSpeed"].ToString(), "F", "Line", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 7, dtExcel.Rows[row]["TotalTime"].ToString(), "G", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 8, dtExcel.Rows[row]["MODTotalTime"].ToString(), "H", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 9, dtExcel.Rows[row]["BreakDownTime"].ToString(), "I", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 10, dtExcel.Rows[row]["ChangeOverTime"].ToString(), "J", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 11, dtExcel.Rows[row]["FormatChangeOver"].ToString(), "K", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 12, dtExcel.Rows[row]["FormulaChangeOver"].ToString(), "L", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 13, dtExcel.Rows[row]["ReferenceChangeOver"].ToString(), "M", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 14, dtExcel.Rows[row]["WaitingTime"].ToString(), "N", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 15, dtExcel.Rows[row]["BulkDelayTime"].ToString(), "O", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 16, dtExcel.Rows[row]["MaterialDelayTime"].ToString(), "P", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 17, dtExcel.Rows[row]["ReworkDuringProd"].ToString(), "Q", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 18, dtExcel.Rows[row]["TankChangeTime"].ToString(), "R", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 19, dtExcel.Rows[row]["OtherWaitingTime"].ToString(), "S", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 20, dtExcel.Rows[row]["WaitingTimeManMin"].ToString(), "T", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 21, dtExcel.Rows[row]["MicroStopTime"].ToString(), "U", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 22, dtExcel.Rows[row]["FGDesc"].ToString(), "V", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 23, dtExcel.Rows[row]["BudgetLineSpeed"].ToString(), "W", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 24, dtExcel.Rows[row]["USTLastYear"].ToString(), "X", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 25, dtExcel.Rows[row]["USTCurrentYear"].ToString(), "Y", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 26, dtExcel.Rows[row]["ProductionUST"].ToString(), "Z", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 27, dtExcel.Rows[row]["BudgetFamily"].ToString(), "AA", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 28, dtExcel.Rows[row]["STDManHourLastYear"].ToString(), "AB", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 29, dtExcel.Rows[row]["ActualManHourCurrentYear"].ToString(), "AC", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 30, dtExcel.Rows[row]["MODSTDWorkForce"].ToString(), "AD", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 31, dtExcel.Rows[row]["ProdMODSTDTime"].ToString(), "AE", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 32, dtExcel.Rows[row]["APTINTOMODSTDWorkForce"].ToString(), "AF", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 33, dtExcel.Rows[row]["STDManHourBudgetSTDTime"].ToString(), "AG", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 34, dtExcel.Rows[row]["PlanProdTime"].ToString(), "AH", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 35, dtExcel.Rows[row]["NominalSpeedTime"].ToString(), "AI", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 36, dtExcel.Rows[row]["OperatingTime"].ToString(), "AJ", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 37, dtExcel.Rows[row]["ActualProdSpeed"].ToString(), "AK", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 38, dtExcel.Rows[row]["Productivity"].ToString(), "AL", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 39, dtExcel.Rows[row]["MechanicalUptime"].ToString(), "AM", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 40, dtExcel.Rows[row]["OEE"].ToString(), "AN", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 41, dtExcel.Rows[row]["ChangeOver"].ToString(), "AO", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 42, dtExcel.Rows[row]["Waitings"].ToString(), "AP", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 43, dtExcel.Rows[row]["BulkWaiting"].ToString(), "AQ", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 44, dtExcel.Rows[row]["MaterialWaiting"].ToString(), "AR", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 45, dtExcel.Rows[row]["PMDefectLoss"].ToString(), "AS", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 46, dtExcel.Rows[row]["TankChange"].ToString(), "AT", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 47, dtExcel.Rows[row]["OtherWaiting"].ToString(), "AU", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 48, dtExcel.Rows[row]["Breakdown"].ToString(), "AV", "Time", worksheet, workSheet_range);
                    AddExcelVal(row + 3, 49, dtExcel.Rows[row]["MicroStops"].ToString(), "AW", "Time", worksheet, workSheet_range);
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
            if (rdbDateWise.Checked)
                GetOEEProcessData();
            else if (rdbShiftWise.Checked)
                GetOEEProcessDataShiftWise();
            else if (rdbSummary.Checked)
                GetSummaryData();
            //CreateExcelFile(excelFolderPath, excelFileName, dt);
        }

        private void bkgWorkerExcel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBar1.Value = e.ProgressPercentage;
        }

        private void bkgWorkerExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //bool result = (bool)e.Result;
            //if (result)
            //    //toolStripLabelMsgName.Text = "Excel Created Successfully";
            //else
            //    toolStripLabelMsgName.Text = "Some Problem in Creating File";
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void GetOEEProcessDataShiftWise()
        {
            try
            {                               
                dt = new DataTable();
                dt = LineOEETransaction_obj.Select_LineOEE_DataJunctionShiftWise_Report();
                
                if (dt.Rows.Count > 0)
                {
                    //                    CreateExcelFile(excelFolderPath, excelFileName, dt);
                    CreateExcelFileShiftWise(dt);
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

        private void CreateExcelFileShiftWise(DataTable dtExcel)
        {
            try
            {
                application = new Excel.ApplicationClass();

                workbook = application.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];

                // Headers
                CreateHeaders(2, 1, "Shift", "A2", "A2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 2, "Operator Name", "B2", "B2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 3, "Form Number", "C2", "C2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 4, "Date", "D2", "D2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 5, "Line No.", "E2", "E2", 0, "DARK YELLOW", true, 10);
               // CreateHeaders(2, 6, "Machine Name", "F2", "F2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 6, "FG Code", "F2", "F2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 7, "QTY", "G2", "G2", 0, "DARK YELLOW", true, 10); // SMT
                CreateHeaders(2, 8, "Line Speed", "H2", "H2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 9, "Planned Production Time in Minutes", "I2", "I2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 10, "Planned Production Man Minutes", "J2", "J2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 11, "Breakdown Time in Minutes", "K2", "K2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 12, "Change Over time in Minutes", "L2", "L2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 13, "Format Change Over Count", "M2", "M2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 14, "Formula Change Over Count", "N2", "N2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 15, "Reference Change Over Count", "O2", "O2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 16, "Waiting Time in Minutes", "P2", "P2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 17, "Bulk Delay min.", "Q2", "Q2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 18, "Material Delay Min.", "R2", "R2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 19, "PM Defect", "S2", "S2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 20, "Tank Change Time in Minutes", "T2", "T2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 21, "Other waitings time in minutes", "U2", "U2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 22, "Waiting Time in Man Minutes", "V2", "V2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 23, "Microstops Time in Min.", "W2", "W2", 0, "LIGHT GREEN", true, 10);
                CreateHeaders(2, 24, "Product Description", "X2", "X2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 25, "Budgeted Line Speed", "Y2", "Y2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 26, "UST Last Year", "Z2", "Z2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 27, "UST Current Year", "AA2", "AA2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 28, "Prod UST Current Year", "AB2", "AB2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 29, "Family", "AC2", "AC2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 30, "Standard Manhour with N-1 Real Std. Time ", "AD2", "AD2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 31, "Actual Manhours", "AE2", "AE2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 32, "MOD Standard Workforce", "AF2", "AF2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 33, "Production MOD standard Time", "AG2", "AG2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 34, "Actual Prod time x MODStd Wrokforce", "AH2", "AH2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 35, "Standard Manhour with N Budget Std Time", "AI2", "AI2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 36, "Planned Production Time in Minutes", "AJ2", "AJ2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 37, "Nominal speed Time in Minutes", "AK2", "AK2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 38, "Operating Time in Minutes", "AL2", "AL2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 39, "Actual Production Speed", "AM2", "AM2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 40, "Productivity", "AN2", "AN2", 0, "DARK YELLOW", true, 13);
                CreateHeaders(2, 41, "Mechanical Uptime", "AO2", "AO2", 0, "DARK YELLOW", true, 12);
                CreateHeaders(2, 42, "OEE (GUTR)", "AP2", "AP2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 43, "Change Over %", "AQ2", "AQ2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 44, "Waitings %", "AR2", "AR2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 45, "Bulk Waiting %", "AS2", "AS2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 46, "Material Waiting %", "AT2", "AT2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 47, "PM Defect Loss %", "AU2", "AU2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 48, "Tank Change %", "AV2", "AV2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 49, "Other Waiting %", "AW2", "AW2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 50, "Break down %", "AX2", "AX2", 0, "DARK YELLOW", true, 10);
                CreateHeaders(2, 51, "Micro Stops %", "AY2", "AY2", 0, "DARK YELLOW", true, 10);

                for (int row = 0; row < dtExcel.Rows.Count; row++)
                {
                    //workSheet_range.NumberFormat = "0.00";
                    workSheet_range.WrapText = true;
                    //progressBar1.Value++;

                    worksheet.Cells[row + 3, 1] = dtExcel.Rows[row]["Shift"].ToString();
                    workSheet_range = worksheet.get_Range("A" + (row + 3), "A" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    workSheet_range.Interior.ColorIndex = 36;

                    worksheet.Cells[row + 3, 2] = dtExcel.Rows[row]["OperatorName"].ToString();
                    workSheet_range = worksheet.get_Range("B" + (row + 3), "B" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    workSheet_range.Interior.ColorIndex = 36;


                    //bkgWorkerExcel.ReportProgress((int)((float)row+1/(float)dtExcel.Rows.Count*100));
                    worksheet.Cells[row + 3, 3] = dtExcel.Rows[row]["FormNumber"].ToString();
                    workSheet_range = worksheet.get_Range("C" + (row + 3), "C" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    workSheet_range.Interior.ColorIndex = 36;
                    //worksheet.Cells[row + 2, 2] = agent_id;
                    worksheet.Cells[row + 3, 4] = string.Format("{0:dd/MM/yyyy}", dtExcel.Rows[row]["TransDate"]).Trim();
                    workSheet_range = worksheet.get_Range("D" + (row + 3), "D" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    workSheet_range.Interior.ColorIndex = 36;
                    //worksheet.Cells[row + 3, 2] = dtExcel.Rows[row]["LineNumber"].ToString();

                    worksheet.Cells[row + 3, 5] = dtExcel.Rows[row]["LineNumber"].ToString();
                    workSheet_range = worksheet.get_Range("E" + (row + 3), "E" + (row + 3));
                    workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    workSheet_range.Interior.ColorIndex = 36;

                    ////worksheet.Cells[row + 3, 6] = dtExcel.Rows[row]["MachineName"].ToString();
                    ////workSheet_range = worksheet.get_Range("F" + (row + 3), "F" + (row + 3));
                    ////workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    ////workSheet_range.Interior.ColorIndex = 36;


                    if (Convert.ToString(dtExcel.Rows[row]["FGCode"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 6] = dtExcel.Rows[row]["FGCode"].ToString(); // TONS PRODUCED
                        workSheet_range = worksheet.get_Range("F" + (row + 3), "F" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("F" + (row + 3), "F" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["ProducedUnit"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 7] = Convert.ToString(dtExcel.Rows[row]["ProducedUnit"].ToString());// SMT
                        workSheet_range = worksheet.get_Range("G" + (row + 3), "G" + (row + 3));
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("G" + (row + 3), "G" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["LineSpeed"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 8] = dtExcel.Rows[row]["LineSpeed"].ToString();
                        workSheet_range = worksheet.get_Range("H" + (row + 3), "H" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("H" + (row + 3), "H" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }

                    if (Convert.ToString(dtExcel.Rows[row]["TotalTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 9] = dtExcel.Rows[row]["TotalTime"].ToString();
                        workSheet_range = worksheet.get_Range("I" + (row + 3), "I" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("I" + (row + 3), "I" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }

                    if (Convert.ToString(dtExcel.Rows[row]["MODTotalTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 10] = dtExcel.Rows[row]["MODTotalTime"].ToString();
                        workSheet_range = worksheet.get_Range("J" + (row + 3), "J" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("J" + (row + 3), "J" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }

                    if (Convert.ToString(dtExcel.Rows[row]["BreakDownTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 11] = dtExcel.Rows[row]["BreakDownTime"].ToString();
                        workSheet_range = worksheet.get_Range("K" + (row + 3), "K" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("K" + (row + 3), "K" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["ChangeOverTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 12] = dtExcel.Rows[row]["ChangeOverTime"].ToString();// Numbers Of Batch
                        workSheet_range = worksheet.get_Range("L" + (row + 3), "L" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("L" + (row + 3), "L" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["FormatChangeOver"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 13] = dtExcel.Rows[row]["FormatChangeOver"].ToString();
                        workSheet_range = worksheet.get_Range("M" + (row + 3), "M" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("M" + (row + 3), "M" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["FormulaChangeOver"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 14] = dtExcel.Rows[row]["FormulaChangeOver"].ToString();
                        workSheet_range = worksheet.get_Range("N" + (row + 3), "N" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("N" + (row + 3), "N" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["ReferenceChangeOver"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 15] = dtExcel.Rows[row]["ReferenceChangeOver"].ToString();
                        workSheet_range = worksheet.get_Range("O" + (row + 3), "O" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("O" + (row + 3), "O" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["WaitingTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 16] = dtExcel.Rows[row]["WaitingTime"].ToString();
                        workSheet_range = worksheet.get_Range("P" + (row + 3), "P" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("P" + (row + 3), "P" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["BulkDelayTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 17] = dtExcel.Rows[row]["BulkDelayTime"].ToString();
                        workSheet_range = worksheet.get_Range("Q" + (row + 3), "Q" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("Q" + (row + 3), "Q" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["MaterialDelayTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 18] = dtExcel.Rows[row]["MaterialDelayTime"].ToString();
                        workSheet_range = worksheet.get_Range("R" + (row + 3), "R" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("R" + (row + 3), "R" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["ReworkDuringProd"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 19] = dtExcel.Rows[row]["ReworkDuringProd"].ToString();
                        workSheet_range = worksheet.get_Range("S" + (row + 3), "S" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("S" + (row + 3), "S" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["TankChangeTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 20] = dtExcel.Rows[row]["TankChangeTime"].ToString();
                        workSheet_range = worksheet.get_Range("T" + (row + 3), "T" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("T" + (row + 3), "T" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["OtherWaitingTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 21] = dtExcel.Rows[row]["OtherWaitingTime"].ToString();
                        workSheet_range = worksheet.get_Range("U" + (row + 3), "U" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("U" + (row + 3), "U" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["WaitingTimeManMin"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 22] = dtExcel.Rows[row]["WaitingTimeManMin"].ToString();// CHANGE-OVER TIME
                        workSheet_range = worksheet.get_Range("V" + (row + 3), "V" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("V" + (row + 3), "V" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["MicroStopTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 23] = dtExcel.Rows[row]["MicroStopTime"].ToString();
                        workSheet_range = worksheet.get_Range("W" + (row + 3), "W" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("W" + (row + 3), "W" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 35;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["FGDesc"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 24] = dtExcel.Rows[row]["FGDesc"].ToString(); // TONS PRODUCED
                        workSheet_range = worksheet.get_Range("X" + (row + 3), "X" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("X" + (row + 3), "X" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["BudgetLineSpeed"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 25] = dtExcel.Rows[row]["BudgetLineSpeed"].ToString();
                        workSheet_range = worksheet.get_Range("Y" + (row + 3), "Y" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("Y" + (row + 3), "Y" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["USTLastYear"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 26] = dtExcel.Rows[row]["USTLastYear"].ToString(); // BREAKDOWN TIME
                        workSheet_range = worksheet.get_Range("Z" + (row + 3), "Z" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("Z" + (row + 3), "Z" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["USTCurrentYear"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 27] = dtExcel.Rows[row]["USTCurrentYear"].ToString();// PROCESSING TIME
                        workSheet_range = worksheet.get_Range("AA" + (row + 3), "AA" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AA" + (row + 3), "AA" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["ProductionUST"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 28] = dtExcel.Rows[row]["ProductionUST"].ToString();
                        workSheet_range = worksheet.get_Range("AB" + (row + 3), "AB" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AB" + (row + 3), "AB" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["BudgetFamily"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 29] = dtExcel.Rows[row]["BudgetFamily"].ToString();
                        workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AC" + (row + 3), "AC" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["STDManHourLastYear"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 30] = dtExcel.Rows[row]["STDManHourLastYear"].ToString();
                        workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AD" + (row + 3), "AD" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }

                    if (Convert.ToString(dtExcel.Rows[row]["ActualManHourCurrentYear"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 31] = dtExcel.Rows[row]["ActualManHourCurrentYear"].ToString();
                        workSheet_range = worksheet.get_Range("AE" + (row + 3), "AE" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AE" + (row + 3), "AE" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["MODSTDWorkForce"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 32] = dtExcel.Rows[row]["MODSTDWorkForce"].ToString();
                        workSheet_range = worksheet.get_Range("AF" + (row + 3), "AF" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AF" + (row + 3), "AF" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["ProdMODSTDTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 33] = dtExcel.Rows[row]["ProdMODSTDTime"].ToString();
                        workSheet_range = worksheet.get_Range("AG" + (row + 3), "AG" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AG" + (row + 3), "AG" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["APTINTOMODSTDWorkForce"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 34] = dtExcel.Rows[row]["APTINTOMODSTDWorkForce"].ToString();
                        workSheet_range = worksheet.get_Range("AH" + (row + 3), "AH" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AH" + (row + 3), "AH" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["STDManHourBudgetSTDTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 35] = dtExcel.Rows[row]["STDManHourBudgetSTDTime"].ToString();
                        workSheet_range = worksheet.get_Range("AI" + (row + 3), "AI" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AI" + (row + 3), "AI" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["PlanProdTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 36] = dtExcel.Rows[row]["PlanProdTime"].ToString();
                        workSheet_range = worksheet.get_Range("AJ" + (row + 3), "AJ" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AJ" + (row + 3), "AJ" + (row + 3));
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "000.000";
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["NominalSpeedTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 37] = dtExcel.Rows[row]["NominalSpeedTime"].ToString();
                        workSheet_range = worksheet.get_Range("AK" + (row + 3), "AK" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AK" + (row + 3), "AK" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["OperatingTime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 38] = dtExcel.Rows[row]["OperatingTime"].ToString();
                        workSheet_range = worksheet.get_Range("AL" + (row + 3), "AL" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        workSheet_range = worksheet.get_Range("AL" + (row + 3), "AL" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["ActualProdSpeed"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 39] = dtExcel.Rows[row]["ActualProdSpeed"].ToString();
                        workSheet_range = worksheet.get_Range("AM" + (row + 3), "AM" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 39] = dtExcel.Rows[row]["ActualProdSpeed"].ToString();
                        workSheet_range = worksheet.get_Range("AM" + (row + 3), "AM" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["Productivity"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 40] = dtExcel.Rows[row]["Productivity"].ToString();
                        workSheet_range = worksheet.get_Range("AN" + (row + 3), "AN" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 40] = "Launch";
                        workSheet_range = worksheet.get_Range("AN" + (row + 3), "AN" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["MechanicalUptime"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 41] = dtExcel.Rows[row]["MechanicalUptime"].ToString();
                        workSheet_range = worksheet.get_Range("AO" + (row + 3), "AO" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 41] = dtExcel.Rows[row]["MechanicalUptime"].ToString();
                        workSheet_range = worksheet.get_Range("AO" + (row + 3), "AO" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["OEE"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 42] = dtExcel.Rows[row]["OEE"].ToString();
                        workSheet_range = worksheet.get_Range("AP" + (row + 3), "AP" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 42] = dtExcel.Rows[row]["OEE"].ToString();
                        workSheet_range = worksheet.get_Range("AP" + (row + 3), "AP" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["ChangeOver"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 43] = dtExcel.Rows[row]["ChangeOver"].ToString();
                        workSheet_range = worksheet.get_Range("AQ" + (row + 3), "AQ" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 43] = dtExcel.Rows[row]["ChangeOver"].ToString();
                        workSheet_range = worksheet.get_Range("AQ" + (row + 3), "AQ" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["Waitings"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 44] = dtExcel.Rows[row]["Waitings"].ToString();
                        workSheet_range = worksheet.get_Range("AR" + (row + 3), "AR" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 44] = dtExcel.Rows[row]["Waitings"].ToString();
                        workSheet_range = worksheet.get_Range("AR" + (row + 3), "AR" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["BulkWaiting"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 45] = dtExcel.Rows[row]["BulkWaiting"].ToString();
                        workSheet_range = worksheet.get_Range("AS" + (row + 3), "AS" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 45] = dtExcel.Rows[row]["BulkWaiting"].ToString();
                        workSheet_range = worksheet.get_Range("AS" + (row + 3), "AS" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["MaterialWaiting"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 46] = dtExcel.Rows[row]["MaterialWaiting"].ToString();
                        workSheet_range = worksheet.get_Range("AT" + (row + 3), "AT" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 46] = dtExcel.Rows[row]["MaterialWaiting"].ToString();
                        workSheet_range = worksheet.get_Range("AT" + (row + 3), "AT" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["PMDefectLoss"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 47] = dtExcel.Rows[row]["PMDefectLoss"].ToString();
                        workSheet_range = worksheet.get_Range("AU" + (row + 3), "AU" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 47] = dtExcel.Rows[row]["PMDefectLoss"].ToString();
                        workSheet_range = worksheet.get_Range("AU" + (row + 3), "AU" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["TankChange"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 48] = dtExcel.Rows[row]["TankChange"].ToString();
                        workSheet_range = worksheet.get_Range("AV" + (row + 3), "AV" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 48] = dtExcel.Rows[row]["TankChange"].ToString();
                        workSheet_range = worksheet.get_Range("AV" + (row + 3), "AV" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["OtherWaiting"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 49] = dtExcel.Rows[row]["OtherWaiting"].ToString();
                        workSheet_range = worksheet.get_Range("AW" + (row + 3), "AW" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 49] = dtExcel.Rows[row]["OtherWaiting"].ToString();
                        workSheet_range = worksheet.get_Range("AW" + (row + 3), "AW" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["Breakdown"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 50] = dtExcel.Rows[row]["Breakdown"].ToString();
                        workSheet_range = worksheet.get_Range("AX" + (row + 3), "AX" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 50] = dtExcel.Rows[row]["Breakdown"].ToString();
                        workSheet_range = worksheet.get_Range("AX" + (row + 3), "AX" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    if (Convert.ToString(dtExcel.Rows[row]["MicroStops"]) != "0.000")
                    {
                        worksheet.Cells[row + 3, 51] = dtExcel.Rows[row]["MicroStops"].ToString();
                        workSheet_range = worksheet.get_Range("AY" + (row + 3), "AY" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                    else
                    {
                        worksheet.Cells[row + 3, 51] = dtExcel.Rows[row]["MicroStops"].ToString();
                        workSheet_range = worksheet.get_Range("AY" + (row + 3), "AY" + (row + 3));
                        workSheet_range.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                        workSheet_range.NumberFormat = "0.000";
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        workSheet_range.Interior.ColorIndex = 36;
                    }
                }
                
                application.Visible = true;
                
                releaseObject(workbook);
                releaseObject(worksheet);
                releaseObject(application);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }


        private void GetSummaryData()
        {
            try
            {
                dt = new DataTable();
                dt = LineOEETransaction_obj.Select_LineOEE_DataSummary_Report();

                if (dt.Rows.Count > 0)
                {
                    ExportToExcel objExport = new ExportToExcel();
                    objExport.GenerateExcelFile(dt);
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
    }
}