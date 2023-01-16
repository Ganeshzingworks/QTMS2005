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

namespace QTMS.Reports_Forms
{
    public partial class FrmOEEDetailProcessReport : Form
    {
        public string rptName;
        private string strMsg;

        public FrmOEEDetailProcessReport()
        {                
            InitializeComponent();
        }
        # region Varibles
         BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.OEEDetailProcessingReport OEEDetailProcessingReport_Obj = new BusinessFacade.Transactions.OEEDetailProcessingReport();
        DateTime date = new DateTime();
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

        private void FrmOEEDetailProcessReport_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
           
            Painter.Paint(this);
            
            //toolStrip1.Items.Add(rptName);
            //toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 100;

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            date = Comman_Class_Obj.Select_ServerDate();
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
                    OEEDetailProcessingReport_Obj.startdate = DtpDateFrom.Value.ToShortDateString();
                }
                else
                {
                    OEEDetailProcessingReport_Obj.startdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpDateTo.Checked == true)
                {
                    OEEDetailProcessingReport_Obj.enddate = DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    OEEDetailProcessingReport_Obj.enddate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }
                if (txtPath.Text == "")
                {
                    MessageBox.Show("Select Export Path", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPath.Focus();
                    return false;
                }
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
                dt = OEEDetailProcessingReport_Obj.Select_Report_OEEMFGActivityDetails_Analysis();
                excelFolderPath = txtPath.Text + "\\" + todaysdate.Replace("/", "_").Replace(":", "_").Replace(" ", "_");
                excelFileName = txtPath.Text + "\\" + todaysdate.Replace("/", "_").Replace(":", "_").Replace(" ", "_") + "\\" + "OEE" + todaysdate.Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".xls";
                //progressBar1.Maximum = dt.Rows.Count + 15;
                //Creating  Directory if not Exists.
                if (!Directory.Exists(excelFolderPath))
                {
                    Directory.CreateDirectory(excelFolderPath);

                }
                if (dt.Rows.Count > 0)
                {

                    CreateExcelFile(excelFolderPath, excelFileName, dt);
                    //if (!bkgWorkerExcel.IsBusy)
                    //{
                    //    bkgWorkerExcel.RunWorkerAsync();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Previous Process Is Not Completed Yet....\n\n  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //while (bkgWorkerExcel.IsBusy)
                    //{
                    //    Application.DoEvents();
                    //}
                }
                //btnGenerateExcel.Enabled = true;    
                 
                
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        private void CreateExcelFile(string efolderPath,string eFile, DataTable dtExcel)
        {
            try
            {
                if (!File.Exists(eFile))
                {
                    application = new Excel.ApplicationClass();

                    workbook = application.Workbooks.Add(Type.Missing);
                    worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];
                    //Headers
                    CreateHeaders(4, 4, "PRODUCTION", "D4", "D4", 0, "PeachPuff", true, 20);
                    CreateHeaders(4, 5, "MANUFACTURING TIME", "E4", "P4", 0, "PeachPuff", true, 20);
                    CreateHeaders(4, 17, "CHANGE-OVER TIME", "Q4", "V4", 0, "PeachPuff", true, 20);
                    CreateHeaders(4, 23, "BREAKDOWN TIME", "W4", "W4", 0, "PeachPuff", true, 20);
                    CreateHeaders(4, 24, "PROCESSING TIME", "X4", "AC4", 0, "PeachPuff", true, 20);
                    CreateHeaders(4, 30, "OCCUPATION TIME", "AD4", "AD4", 0, "PeachPuff", true, 20);
                    CreateHeaders(4, 31, "Manufacturing UR (%)", "AE4", "AE4", 0, "PeachPuff", true, 20);
                    CreateHeaders(4, 32, "Processing UR (%)", "AF4", "AF4", 0, "PeachPuff", true, 20);
                    CreateHeaders(4, 33, "OEE UR (%)", "AG4", "AG4", 0, "PeachPuff", true, 20);
                    CreateHeaders(5, 5, "SMT", "E5", "J5", 0, "PeachPuff", true, 20);
                    CreateHeaders(5, 11, "Number of Batches", "K5", "P5", 0, "PeachPuff", true, 20);
                    // Sub Headers
                    CreateHeaders(6, 1, "Vessel Name", "A6", "A6", 0, "GRAY", true, 20);
                    CreateHeaders(6, 2, "Family Name", "B6", "B6", 0, "GRAY", true, 35);
                    CreateHeaders(6, 3, "", "C6", "C6", 0, "GRAY", true, 2);
                    CreateHeaders(6, 4, "Tons produced(T.)", "D6", "D6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 5, "251 - 500 kg", "E6", "E6", 0, "GRAY", true, 18); // SMT
                    CreateHeaders(6, 6, "501 - 1500 kg", "F6", "F6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 7, "1501 - 2500 kg", "G6", "G6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 8, "2501 - 5000 kg", "H6", "H6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 9, "5001 - 10000 kg", "I6", "I6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 10, "10001 - 20000 kg", "J6", "J6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 11, "251 - 500 kg", "K6", "K6", 0, "GRAY", true, 18); //Number of batch
                    CreateHeaders(6, 12, "501 - 1500 kg", "L6", "L6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 13, "1501 - 2500 kg", "M6", "M6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 14, "2501 - 5000 kg", "N6", "N6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 15, "5001 - 10000 kg", "O6", "O6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 16, "10001 - 20000 kg", "P6", "P6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 17, "251 - 500 kg", "Q6", "Q6", 0, "GRAY", true, 18); // Total change-over time (minutes)
                    CreateHeaders(6, 18, "501 - 1500 kg", "R6", "R6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 19, "1501 - 2500 kg", "S6", "S6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 20, "2501 - 5000 kg", "T6", "T6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 21, "5001 - 10000 kg", "U6", "U6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 22, "10001 - 20000 kg", "V6", "V6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 23, "Total Breakdown time (minutes)", "W6", "W6", 0, "GRAY", true, 30); // Breakdown Time
                    CreateHeaders(6, 24, "251 - 500 kg", "X6", "X6", 0, "GRAY", true, 18); // PROCESSING TIME
                    CreateHeaders(6, 25, "501 - 1500 kg", "Y6", "Y6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 26, "1501 - 2500 kg", "Z6", "Z6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 27, "2501 - 5000 kg", "AA6", "AA6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 28, "5001 - 10000 kg", "AB6", "AB6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 29, "10001 - 20000 kg", "AC6", "AC6", 0, "GRAY", true, 18);
                    CreateHeaders(6, 30, "OCCUPATION TIME", "AD6", "AD6", 0, "GRAY", true, 20); // Occupation Time
                    CreateHeaders(6, 31, "108.9%", "AE6", "AE6", 0, "GRAY", true, 20); // Occupation Time
                    CreateHeaders(6, 32, "72.8%", "AF6", "AF6", 0, "GRAY", true, 20); // Occupation Time
                    CreateHeaders(6, 33, "72.4%", "AG6", "AG6", 0, "GRAY", true, 20); // Occupation Time

                    //worksheet.Cells[6, 1] = "Vessel Name";
                    //worksheet.Cells[1, 2] = "agent_id";
                    //worksheet.Cells[6, 2] = "Family Name";
                    //worksheet.Cells[6, 3] = "Tons produced(T.)";
                    
                    for (int row = 0; row < dtExcel.Rows.Count; row++)
                    {
                        //progressBar1.Value++;
                        //bkgWorkerExcel.ReportProgress((int)((float)row+1/(float)dtExcel.Rows.Count*100));
                        worksheet.Cells[row + 7, 1] = dtExcel.Rows[row]["vesseldesc"].ToString();

                        workSheet_range = worksheet.get_Range("A" + (row + 7), "A6");
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        //worksheet.Cells[row + 2, 2] = agent_id;
                        worksheet.Cells[row + 7, 2] = dtExcel.Rows[row]["techfamilyname"].ToString();
                        workSheet_range = worksheet.get_Range("B" + (row + 7), "B6");
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        worksheet.Cells[row + 7, 2] = dtExcel.Rows[row]["techfamilyname"].ToString();

                        //worksheet.Cells[row + 7, 3] = ".";
                        workSheet_range = worksheet.get_Range("C" + (row + 7), "C6");
                        workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();

                        if (Convert.ToString(dtExcel.Rows[row]["tonsProduced"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 4] = dtExcel.Rows[row]["tonsProduced"].ToString(); // TONS PRODUCED
                            workSheet_range = worksheet.get_Range("D" + (row + 7), "D6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("D" + (row + 7), "D6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["SMT251to500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 5] = Convert.ToString(dtExcel.Rows[row]["SMT251to500kg"].ToString());// SMT
                            workSheet_range = worksheet.get_Range("E" + (row + 7), "E6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("E" + (row + 7), "E6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["SMT501to1500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 6] = dtExcel.Rows[row]["SMT501to1500kg"].ToString();
                            workSheet_range = worksheet.get_Range("F" + (row + 7), "F6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("F" + (row + 7), "F6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }

                        if (Convert.ToString(dtExcel.Rows[row]["SMT1501to2500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 7] = dtExcel.Rows[row]["SMT1501to2500kg"].ToString();
                            workSheet_range = worksheet.get_Range("G" + (row + 7), "G6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("G" + (row + 7), "G6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }

                        if (Convert.ToString(dtExcel.Rows[row]["SMT2501to5000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 8] = dtExcel.Rows[row]["SMT2501to5000kg"].ToString();
                            workSheet_range = worksheet.get_Range("H" + (row + 7), "H6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("H" + (row + 7), "H6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }

                        if (Convert.ToString(dtExcel.Rows[row]["SMT5001to10000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 9] = dtExcel.Rows[row]["SMT5001to10000kg"].ToString();
                            workSheet_range = worksheet.get_Range("I" + (row + 7), "I6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("I" + (row + 7), "I6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }

                        if (Convert.ToString(dtExcel.Rows[row]["SMT10001to20000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 10] = dtExcel.Rows[row]["SMT10001to20000kg"].ToString();
                            workSheet_range = worksheet.get_Range("J" + (row + 7), "J6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("J" + (row + 7), "J6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Batch251to500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 11] = dtExcel.Rows[row]["Batch251to500kg"].ToString();// Numbers Of Batch
                            workSheet_range = worksheet.get_Range("K" + (row + 7), "K6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("K" + (row + 7), "K6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }

                        if (Convert.ToString(dtExcel.Rows[row]["Batch501to1500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 12] = dtExcel.Rows[row]["Batch501to1500kg"].ToString();
                            workSheet_range = worksheet.get_Range("L" + (row + 7), "L6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("L" + (row + 7), "L6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Batch1501to2500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 13] = dtExcel.Rows[row]["Batch1501to2500kg"].ToString();
                            workSheet_range = worksheet.get_Range("M" + (row + 7), "M6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("M" + (row + 7), "M6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Batch2501to5000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 14] = dtExcel.Rows[row]["Batch2501to5000kg"].ToString();
                            workSheet_range = worksheet.get_Range("N" + (row + 7), "N6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("N" + (row + 7), "N6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Batch5001to10000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 15] = dtExcel.Rows[row]["Batch5001to10000kg"].ToString();
                            workSheet_range = worksheet.get_Range("O" + (row + 7), "O6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("O" + (row + 7), "O6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Batch10001to20000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 16] = dtExcel.Rows[row]["Batch10001to20000kg"].ToString();
                            workSheet_range = worksheet.get_Range("P" + (row + 7), "P6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("P" + (row + 7), "P6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();                            
                        }

                        if (Convert.ToString(dtExcel.Rows[row]["Change251to500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 17] = dtExcel.Rows[row]["Change251to500kg"].ToString();// CHANGE-OVER TIME
                            workSheet_range = worksheet.get_Range("Q" + (row + 7), "Q6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("Q" + (row + 7), "Q6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Change501to1500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 18] = dtExcel.Rows[row]["Change501to1500kg"].ToString();
                            workSheet_range = worksheet.get_Range("R" + (row + 7), "R6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("R" + (row + 7), "R6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Change1501to2500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 19] = dtExcel.Rows[row]["Change1501to2500kg"].ToString();
                            workSheet_range = worksheet.get_Range("S" + (row + 7), "S6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("S" + (row + 7), "S6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Change2501to5000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 20] = dtExcel.Rows[row]["Change2501to5000kg"].ToString();
                            workSheet_range = worksheet.get_Range("T" + (row + 7), "T6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("T" + (row + 7), "T6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Change5001to10000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 21] = dtExcel.Rows[row]["Change5001to10000kg"].ToString();
                            workSheet_range = worksheet.get_Range("U" + (row + 7), "U6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("U" + (row + 7), "U6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Change10001to20000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 22] = dtExcel.Rows[row]["Change10001to20000kg"].ToString();
                            workSheet_range = worksheet.get_Range("V" + (row + 7), "V6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("V" + (row + 7), "V6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["breakdownTime"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 23] = dtExcel.Rows[row]["breakdownTime"].ToString(); // BREAKDOWN TIME
                            workSheet_range = worksheet.get_Range("W" + (row + 7), "W6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("W" + (row + 7), "W6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Process251to500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 24] = dtExcel.Rows[row]["Process251to500kg"].ToString();// PROCESSING TIME
                            workSheet_range = worksheet.get_Range("X" + (row + 7), "X6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("X" + (row + 7), "X6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Process501to1500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 25] = dtExcel.Rows[row]["Process501to1500kg"].ToString();
                            workSheet_range = worksheet.get_Range("Y" + (row + 7), "Y6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("Y" + (row + 7), "Y6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Process1501to2500kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 26] = dtExcel.Rows[row]["Process1501to2500kg"].ToString();
                            workSheet_range = worksheet.get_Range("Z" + (row + 7), "Z6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("Z" + (row + 7), "Z6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Process2501to5000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 27] = dtExcel.Rows[row]["Process2501to5000kg"].ToString();
                            workSheet_range = worksheet.get_Range("AA" + (row + 7), "AA6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("AA" + (row + 7), "AA6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Process5001to10000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 28] = dtExcel.Rows[row]["Process5001to10000kg"].ToString();
                            workSheet_range = worksheet.get_Range("AB" + (row + 7), "AB6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("AB" + (row + 7), "AB6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["Process10001to20000kg"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 29] = dtExcel.Rows[row]["Process10001to20000kg"].ToString();
                            workSheet_range = worksheet.get_Range("AC" + (row + 7), "AC6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("AC" + (row + 7), "AC6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["occupationTime"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 30] = dtExcel.Rows[row]["occupationTime"].ToString();
                            workSheet_range = worksheet.get_Range("AD" + (row + 7), "AD6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("AD" + (row + 7), "AD6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["ManufacturingUR"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 31] = dtExcel.Rows[row]["ManufacturingUR"].ToString();
                            workSheet_range = worksheet.get_Range("AE" + (row + 7), "AE6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("AE" + (row + 7), "AE6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["ProcessingUR"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 32] = dtExcel.Rows[row]["ProcessingUR"].ToString();
                            workSheet_range = worksheet.get_Range("AF" + (row + 7), "AF6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("AF" + (row + 7), "AF6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        if (Convert.ToString(dtExcel.Rows[row]["OEEPercent"]) != "0.000")
                        {
                            worksheet.Cells[row + 7, 33] = dtExcel.Rows[row]["OEEPercent"].ToString();
                            workSheet_range = worksheet.get_Range("AG" + (row + 7), "AG6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        else
                        {
                            workSheet_range = worksheet.get_Range("AG" + (row + 7), "AG6");
                            workSheet_range.Borders.Color = System.Drawing.Color.Black.ToArgb();
                        }
                        
                    }
                    //SAVE WORKBOOK AT EXPORT PATH
                    workbook.SaveAs(eFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    application.Workbooks.Close();

                    application.Quit();
                    releaseObject(workbook);
                    releaseObject(worksheet);
                    releaseObject(application);
                    efolderPath = null;
                }
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
        private void CreateHeaders(int row, int col,string hText,string cell1, string cell2,int mergeColumn,string b, bool font , int size)
        {
            try
            {
                worksheet.Cells[row, col] = hText;
               
                workSheet_range = worksheet.get_Range(cell1,cell2);
                workSheet_range.Merge(mergeColumn);
                

                switch (b)
                {
                    case "YELLOW":
                        workSheet_range.Interior.Color = System.Drawing.Color.Yellow.ToArgb();
                        break;
                    case "GRAY":
                        workSheet_range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
                        break;
                    case "GAINSBORO":
                        workSheet_range.Interior.Color = System.Drawing.Color.Gainsboro.ToArgb();
                        break;
                    case "Turquoise":
                        workSheet_range.Interior.Color = System.Drawing.Color.Turquoise.ToArgb();
                        break;
                    case "PeachPuff":
                        workSheet_range.Interior.Color = System.Drawing.Color.PeachPuff.ToArgb();
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

            strMsg = "Excel Created Successfully";
            
            toolStripProgressBar1.Value = 100;

            bkgWorkerExcel.Dispose();
            btnGenerateExcel.Enabled = true;
            timer1.Stop();
            MessageBox.Show(strMsg);
            txtPath.Text = "";
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
            toolStripProgressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now.Subtract(date);
            string sTime = " ..." + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00") +":" + ts.Milliseconds.ToString("000");
            toolStripStatusLabelTime.Text = sTime;
            if (toolStripProgressBar1.Value == toolStripProgressBar1.Maximum)
            {
                toolStripProgressBar1.Value = 0;
            }
            toolStripProgressBar1.PerformStep();
        }

      
    }
}