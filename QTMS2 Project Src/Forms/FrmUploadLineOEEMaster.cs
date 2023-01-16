using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using System.Data.OleDb;
using BusinessFacade.Transactions;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using Microsoft.Win32;

namespace QTMS.Forms
{
    public partial class FrmUploadLineOEEMaster : Form
    {
        
        public FrmUploadLineOEEMaster()
        {                
            InitializeComponent();
        }
        # region Varibles
        string fileName = string.Empty;
        string folderName = string.Empty;
        LineOEETransaction LineOEETransaction_obj = new LineOEETransaction();        
        # endregion

        private static Forms.FrmUploadLineOEEMaster FrmUploadLineOEEMaster_Obj = null;
        public static Forms.FrmUploadLineOEEMaster GetInstance()
        {
            if (FrmUploadLineOEEMaster_Obj == null)
            {
                FrmUploadLineOEEMaster_Obj = new Forms.FrmUploadLineOEEMaster();
            }
            return FrmUploadLineOEEMaster_Obj;
        }
      

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUploadLineOEEMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            pnlMatchRecord.Visible = false;
            pnlDuplicateRecord.Visible = false;
            pnlUnmatchedReocrd.Visible = false;
            pnlStatus.Visible = false;
        }
        Excel.Application ExcelObj = null;
        Excel.Workbook theWorkbook = null;
        Excel.Sheets sheets = null;
        Excel.Worksheet worksheet = null;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                //OpenFileDialog dlgFileName = new OpenFileDialog();
                //dlgFileName.Filter = "Microsoft Excel Workbooks (*.xls)|*.xls";
                //if (dlgFileName.ShowDialog() == DialogResult.OK)
                //{
                //    txtFileName.Text = dlgFileName.FileName.Trim();
                //    fileName = Path.GetFileName(dlgFileName.FileName);
                //    btnUpload.Enabled = true;
                //    pnlMatchRecord.Visible = false;
                //    pnlDuplicateRecord.Visible = false;
                //    pnlUnmatchedReocrd.Visible = false;
                //    pnlStatus.Visible = false;

                //    dgMatchRecord.Rows.Clear();
                //    dgMatchRecord.Rows.Clear();
                //    dgMatchRecord.Rows.Clear();
                //    dgMatchRecord.RowCount = 0;
                //    dgUnmatchedRecord.RowCount = 0;
                //    dgDuplicateRecord.RowCount = 0;
                //}
                

                openFileDialog1.Filter = "Microsoft Excel Workbooks (*.xls)|*.xls";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    txtFileName.Text = openFileDialog1.FileName.Trim();
                    fileName = Path.GetFileName(openFileDialog1.FileName);
                    btnUpload.Enabled = true;
                    pnlMatchRecord.Visible = false;
                    pnlDuplicateRecord.Visible = false;
                    pnlUnmatchedReocrd.Visible = false;
                    pnlStatus.Visible = false;

                    dgMatchRecord.Rows.Clear();
                    dgMatchRecord.Rows.Clear();
                    dgMatchRecord.Rows.Clear();
                    dgMatchRecord.RowCount = 0;
                    dgUnmatchedRecord.RowCount = 0;
                    dgDuplicateRecord.RowCount = 0;

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// Reads my test reg key.
        /// </summary>
        public void ReadMyTestRegKey()
        {

            try
            {


                RegistryKey regkey;/* new Microsoft.Win32 Registry Key */
                //set the registery path to change
                String strPath = @"Software\Microsoft\Jet\4.0\Engines\Excel";

                // I have to use CreateSubKey 
                // (create or open it if already exits), 
                // 'cause OpenSubKey open a subKey as read-only

                regkey = Registry.LocalMachine.CreateSubKey(strPath);
                //get the value
                string valname = Convert.ToString(regkey.GetValue("TypeGuessRows"));
                if (Convert.ToInt32(valname) > 0)
                {
                    regkey.SetValue("TypeGuessRows", 0);
                }
                else
                {

                }


                Registry.LocalMachine.Flush();
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                ReadMyTestRegKey();    
                ExcelObj = new Microsoft.Office.Interop.Excel.Application();
                #region Upload excel Avinash S 18 March 2016

                if(File.Exists(Application.StartupPath + "/" + fileName))
                    File.Delete(Application.StartupPath + "/" + fileName);
                
                File.Copy(openFileDialog1.FileName, Application.StartupPath + "/" + fileName);

                #endregion                
                theWorkbook = ExcelObj.Workbooks.Open(openFileDialog1.FileName, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, true, true);
                sheets = theWorkbook.Worksheets;
                worksheet = (Excel.Worksheet)sheets.get_Item(1);
                if (worksheet.Name == "Master")
                {                 
              
                    string excelConnectionString;
                    excelConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;" + "Data Source = '" + fileName + "';" + "Extended Properties = ImportMixedTypes=Text;Excel 8.0;HDR=Yes;IMEX=1;";

                    //excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';";
                    OleDbConnection con = new OleDbConnection(excelConnectionString);

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = "SELECT * FROM [Master$]";
                    OleDbDataAdapter adpt = new OleDbDataAdapter(cmd.CommandText, con);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adpt.Fill(dt);

                    if (CheckLineOEEMasterFormat(dt))
                    {
                        cmd.CommandText = "SELECT FGCODE,YEAR FROM [Master$] GROUP BY FGCODE,YEAR HAVING COUNT(FGCODE) > 1";

                        OleDbDataAdapter adpt1 = new OleDbDataAdapter(cmd.CommandText, con);
                        DataTable dtDuplicate = new DataTable();
                        adpt1.Fill(dtDuplicate);
                        if (dtDuplicate.Rows.Count == 0)
                        {
                            UploadLineOEEMaster(dt);
                            //MessageBox.Show("Line OEE Master Uploaded Successfully","Line OEE",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            //MessageBox.Show("Duplicate Reocrd Exist", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblDuplicate.Text = "Duplicate Reocrd Exist in Excel File";
                            pnlDuplicateRecord.Visible = true;
                            foreach (DataRow dr in dtDuplicate.Rows)
                            {
                                dgDuplicateRecord.Rows.Add();
                                dgDuplicateRecord["DFGCODE", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["FGCODE"]);
                                //dgDuplicateRecord["DFAMILY", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["FAMILY"]);
                                dgDuplicateRecord["DYEAR", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["YEAR"]);
                                //dgDuplicateRecord["DMOD", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["MOD"]);
                                //dgDuplicateRecord["DUST", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["UST"]);
                                //dgDuplicateRecord["DPRODUCTDESCRIPTION", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["PRODUCTDESCRIPTION"]);
                                //dgDuplicateRecord["DLINESPEED", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["LINESPEED"]);
                                //dgDuplicateRecord["DLINENO", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["LINENO"]);
                            }

                        }                        
                    }
                    else
                    {
                        MessageBox.Show("Line OEE Master format is Incorrect", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                
                   
                    

                    txtFileName.Text = "";
                    fileName = "";
                    progressBar1.Value = 0;
                    btnUpload.Enabled = false;
                    btnSave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Worksheet name is not correct. Please change the sheet name as 'Master' ", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                releaseObject(worksheet);
                releaseObject(theWorkbook);
                releaseObject(ExcelObj);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckLineOEEMasterFormat(DataTable dt)
        {
            try
            {

                if (dt.Columns.Count < 8)
                    return false;
                if (dt.Columns[0].Caption != "FGCODE")
                    return false;
                if (dt.Columns[1].Caption != "FAMILY")
                    return false;
                if (dt.Columns[2].Caption != "YEAR")
                    return false;
                if (dt.Columns[3].Caption != "MOD")
                    return false;
                if (dt.Columns[4].Caption != "UST")
                    return false;
                if (dt.Columns[5].Caption != "PRODUCTDESCRIPTION")
                    return false;
                if (dt.Columns[6].Caption != "LINESPEED")
                    return false;
                if (dt.Columns[7].Caption != "LINENO")
                    return false;


                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
        private bool CheckDuplicateFG(DataTable dt)
        {
            try
            {
                DataTable dtDuplicate = dt.DefaultView.ToTable(true, "FGCODE");
                if (dtDuplicate.Rows.Count == dt.Rows.Count)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        private void UploadLineOEEMaster(DataTable dt)
        {
            try
            {
                
                progressBar1.Maximum = dt.Rows.Count;
                progressBar1.Value = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    progressBar1.Value = progressBar1.Value + 1;
                    int cntFGCode = 0;
                    LineOEETransaction_obj.fgCode = Convert.ToString(dr["FGCODE"]);
                    LineOEETransaction_obj.fgdescription = Convert.ToString(dr["PRODUCTDESCRIPTION"]);

                    bool res = LineOEETransaction_obj.Insert_tblLineOEEFGMaster_Uploadexcel();

                    // This function is used to check FG Code exist in our database or Not.
                    cntFGCode = LineOEETransaction_obj.CheckFGCodeExist();
                    if(cntFGCode >0)
                    {
                        pnlStatus.Visible = true;
                        int cntfgcodeYear = 0;
                        LineOEETransaction_obj.year = Convert.ToString(dr["YEAR"]);
                        // This function is used to check FG Code & year exist in our table or Not.
                        cntfgcodeYear = LineOEETransaction_obj.Check_FGCODE_Years_Exist();
                        if (cntfgcodeYear > 0)
                        {
                            pnlDuplicateRecord.Visible = true;
                            dgDuplicateRecord.Rows.Add();
                            dgDuplicateRecord["DFGCODE", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["FGCODE"]);
                            dgDuplicateRecord["DFAMILY", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["FAMILY"]);
                            dgDuplicateRecord["DYEAR", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["YEAR"]);
                            dgDuplicateRecord["DMOD", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["MOD"]);
                            dgDuplicateRecord["DUST", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["UST"]);
                            dgDuplicateRecord["DPRODUCTDESCRIPTION", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["PRODUCTDESCRIPTION"]);
                            dgDuplicateRecord["DLINESPEED", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["LINESPEED"]);
                            dgDuplicateRecord["DLINENO", dgDuplicateRecord.Rows.Count - 1].Value = Convert.ToString(dr["LINENO"]);

                        }
                        else
                        {
                            pnlMatchRecord.Visible = true;
                            dgMatchRecord.Rows.Add();
                            dgMatchRecord["FGCODE", dgMatchRecord.Rows.Count - 1].Value = Convert.ToString(dr["FGCODE"]);
                            dgMatchRecord["FAMILY", dgMatchRecord.Rows.Count - 1].Value = Convert.ToString(dr["FAMILY"]);
                            dgMatchRecord["YEAR", dgMatchRecord.Rows.Count - 1].Value = Convert.ToString(dr["YEAR"]);
                            dgMatchRecord["MOD", dgMatchRecord.Rows.Count - 1].Value = Convert.ToString(dr["MOD"]);
                            dgMatchRecord["UST", dgMatchRecord.Rows.Count - 1].Value = Convert.ToString(dr["UST"]);
                            dgMatchRecord["PRODUCTDESCRIPTION", dgMatchRecord.Rows.Count - 1].Value = Convert.ToString(dr["PRODUCTDESCRIPTION"]);
                            dgMatchRecord["LINESPEED", dgMatchRecord.Rows.Count - 1].Value = Convert.ToString(dr["LINESPEED"]);
                            dgMatchRecord["LINENO", dgMatchRecord.Rows.Count - 1].Value = Convert.ToString(dr["LINENO"]);
                        }
                    }
                    else
                    {
                        pnlUnmatchedReocrd.Visible = true;
                        pnlStatus.Visible = true;
                        dgUnmatchedRecord.Rows.Add();
                        dgUnmatchedRecord["UFGCODE", dgUnmatchedRecord.Rows.Count -1].Value = Convert.ToString(dr["FGCODE"]);
                        dgUnmatchedRecord["UFAMILY", dgUnmatchedRecord.Rows.Count - 1].Value = Convert.ToString(dr["FAMILY"]);
                        dgUnmatchedRecord["UYEAR", dgUnmatchedRecord.Rows.Count - 1].Value = Convert.ToString(dr["YEAR"]);
                        dgUnmatchedRecord["UMOD", dgUnmatchedRecord.Rows.Count - 1].Value = Convert.ToString(dr["MOD"]);
                        dgUnmatchedRecord["UUST", dgUnmatchedRecord.Rows.Count - 1].Value = Convert.ToString(dr["UST"]);
                        dgUnmatchedRecord["UPRODUCTDESCRIPTION", dgUnmatchedRecord.Rows.Count - 1].Value = Convert.ToString(dr["PRODUCTDESCRIPTION"]);
                        dgUnmatchedRecord["ULINESPEED", dgUnmatchedRecord.Rows.Count - 1].Value = Convert.ToString(dr["LINESPEED"]);
                        dgUnmatchedRecord["ULINENO", dgUnmatchedRecord.Rows.Count - 1].Value = Convert.ToString(dr["LINENO"]);

                    }
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int cnt = 0;                
                progressBar1.Value = 0;
                for (int i = 0; i < dgMatchRecord.Rows.Count ; i++)
                {
                    progressBar1.Maximum = dgMatchRecord.Rows.Count;
                    progressBar1.Value = progressBar1.Value + 1;
                    LineOEETransaction_obj.fgCode = Convert.ToString(dgMatchRecord["FGCODE", i].Value);
                    LineOEETransaction_obj.family = Convert.ToString(dgMatchRecord["FAMILY", i].Value);
                    LineOEETransaction_obj.year = Convert.ToString(dgMatchRecord["YEAR", i].Value);
                    LineOEETransaction_obj.modUpload = Convert.ToString(dgMatchRecord["MOD", i].Value);
                    LineOEETransaction_obj.ust = Convert.ToString(dgMatchRecord["UST", i].Value);
                    LineOEETransaction_obj.productDescription = Convert.ToString(dgMatchRecord["PRODUCTDESCRIPTION", i].Value);
                    LineOEETransaction_obj.lineSpeedUpload = Convert.ToString(dgMatchRecord["LINESPEED", i].Value);
                    LineOEETransaction_obj.lineNo = Convert.ToString(dgMatchRecord["LINENO", i].Value);
                    bool flag = LineOEETransaction_obj.Insert_UploadLineOEEMaster();
                    if (flag == true)
                    {
                        cnt = cnt + 1;
                    }
                    
                }
                if (dgDuplicateRecord.Rows.Count > 0)
                {
                    if (MessageBox.Show("No. of Rows " + cnt + " saved successfully. Do you want to update the duplicate record?", "Line OEE", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cnt = 0;
                        for (int i = 0; i < dgDuplicateRecord.Rows.Count; i++)
                        {
                            progressBar1.Maximum = progressBar1.Value + dgDuplicateRecord.Rows.Count;
                            progressBar1.Value = progressBar1.Value + 1;
                            LineOEETransaction_obj.fgCode = Convert.ToString(dgDuplicateRecord["DFGCODE", i].Value);
                            LineOEETransaction_obj.family = Convert.ToString(dgDuplicateRecord["DFAMILY", i].Value);
                            LineOEETransaction_obj.year = Convert.ToString(dgDuplicateRecord["DYEAR", i].Value);
                            LineOEETransaction_obj.modUpload = Convert.ToString(dgDuplicateRecord["DMOD", i].Value);
                            LineOEETransaction_obj.ust = Convert.ToString(dgDuplicateRecord["DUST", i].Value);
                            LineOEETransaction_obj.productDescription = Convert.ToString(dgDuplicateRecord["DPRODUCTDESCRIPTION", i].Value);
                            LineOEETransaction_obj.lineSpeedUpload = Convert.ToString(dgDuplicateRecord["DLINESPEED", i].Value);
                            LineOEETransaction_obj.lineNo = Convert.ToString(dgDuplicateRecord["DLINENO", i].Value);
                            bool flag = LineOEETransaction_obj.Update_UploadLineOEEMaster();
                            if (flag == true)
                            {
                                cnt = cnt + 1;
                            }
                        }
                        MessageBox.Show("No. of Rows " + cnt + " Updated successfully", "Line OEE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                    MessageBox.Show("No. of Rows "+ cnt +" saved successfully","Line OEE",MessageBoxButtons.OK,MessageBoxIcon.Information);

                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFileName.Text = "";
            fileName = "";
            progressBar1.Value = 0;
            btnUpload.Enabled = false;
            
            dgMatchRecord.Rows.Clear();
            dgMatchRecord.Rows.Clear();
            dgMatchRecord.Rows.Clear();
            dgMatchRecord.RowCount = 0;
            dgUnmatchedRecord.RowCount = 0;
            dgDuplicateRecord.RowCount = 0;
            pnlMatchRecord.Visible = false;
            pnlDuplicateRecord.Visible = false;
            pnlUnmatchedReocrd.Visible = false;
            pnlStatus.Visible = false;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
      
    }
}