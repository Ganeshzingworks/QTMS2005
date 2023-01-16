using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using System.Data.OleDb;
using System.IO;

namespace QTMS.Forms
{
    public partial class FrmOEEPURUpload : Form
    {
        public FrmOEEPURUpload()
        {
            InitializeComponent();
        }

        BusinessFacade.Transactions.OEETransactionTest_Class OEETransactionTest_Class_Obj = new BusinessFacade.Transactions.OEETransactionTest_Class();

        private void FrmOEEPURUpload_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;

            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();  //create openfileDialog Object
                openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
                openFileDialog1.FilterIndex = 3;

                openFileDialog1.Multiselect = false;        //not allow multiline selection at the file selection level
                openFileDialog1.Title = "Open Text File-R13";   //define the name of openfileDialog
                openFileDialog1.InitialDirectory = @"Desktop"; //define the initial directory

                if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
                {
                    string pathName = openFileDialog1.FileName;
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    DataTable tbContainer = new DataTable();
                    string strConn = string.Empty;
                    string sheetName = fileName;

                    FileInfo file = new FileInfo(pathName);
                    if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
                    string extension = file.Extension;
                    switch (extension)
                    {
                        case ".xls":
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                            break;
                        case ".xlsx":
                            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                            break;
                        default:
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                            break;
                    }
                    OleDbConnection cnnxls = new OleDbConnection(strConn);

                    //OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
                    OleDbDataAdapter oda = new OleDbDataAdapter("select * from [Sheet1$]", cnnxls);
                    oda.Fill(tbContainer);

                    DgPUR.DataSource = tbContainer;

                    //System.Data.DataSet DtSet;

                    //OleDbDataAdapter oda = new OleDbDataAdapter("select * from [Sheet1$]", cnnxls);

                    //oda.TableMappings.Add("Table", "Net-informations.com");
                    //DtSet = new System.Data.DataSet();
                    //oda.Fill(DtSet);
                    //DgPUR.DataSource = DtSet.Tables[0];


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error! " + ex.Message.ToString());
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DgPUR.Rows.Count - 1; i++)
            {
                OEETransactionTest_Class_Obj.cyear = dtpDate.Text;
                OEETransactionTest_Class_Obj.vessel = Convert.ToString(DgPUR.Rows[i].Cells[0].Value.ToString().Trim());
                if (DgPUR.Rows[i].Cells[1].Value.ToString() == "")
                    OEETransactionTest_Class_Obj.byearvalue = 0;
                else
                    OEETransactionTest_Class_Obj.byearvalue = Convert.ToInt32(DgPUR.Rows[i].Cells[1].Value.ToString().Trim());
                if (DgPUR.Rows[i].Cells[2].Value.ToString() == "")
                    OEETransactionTest_Class_Obj.targetcwc = 0;
                else
                    OEETransactionTest_Class_Obj.targetcwc = Convert.ToInt32(DgPUR.Rows[i].Cells[2].Value.ToString().Trim());
                if (DgPUR.Rows[i].Cells[3].Value.ToString() == "")
                    OEETransactionTest_Class_Obj.targetcip = 0;
                else
                    OEETransactionTest_Class_Obj.targetcip = Convert.ToInt32(DgPUR.Rows[i].Cells[3].Value.ToString().Trim());

                OEETransactionTest_Class_Obj.InsertUpdate_tblDailyPURExcelUpload();
            }

            MessageBox.Show("Record Save Successfully.");
        }
    }
}