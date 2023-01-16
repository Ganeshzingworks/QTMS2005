using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade.Transactions;
using QTMS.Tools;
using System.IO;
using System.Diagnostics;

namespace QTMS.Transactions
{
    public partial class frmSupplierCorrectiveNote : Form
    {
        public frmSupplierCorrectiveNote()
        {
            InitializeComponent();
        }
        #region Variable
        PMTransaction_Class PMTransaction_Class_obj = new PMTransaction_Class();
        string supFileName, supFileExt = string.Empty;

        #endregion
        private static frmSupplierCorrectiveNote frmSupplierCorrectiveNote_Obj = null;
        public static frmSupplierCorrectiveNote GetInstance()
        {
            if (frmSupplierCorrectiveNote_Obj == null)
            {
                frmSupplierCorrectiveNote_Obj = new Transactions.frmSupplierCorrectiveNote();
            }
            return frmSupplierCorrectiveNote_Obj;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSupplierCorrectiveNote_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_Details();
            //BtnReset_Click(sender, e);
            CmbDetails.Focus();
        }
        public void Bind_Details()
        {
            CmbDetails.BeginUpdate();
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = PMTransaction_Class_obj.Select_ModificationPMDetails();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["PMTransID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                CmbDetails.DataSource = ds.Tables[0];
                CmbDetails.DisplayMember = "Details";
                CmbDetails.ValueMember = "PMTransID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CmbDetails.EndUpdate();
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "txt files (*.txt)|*.txt|Doc File (*.doc)|*.doc|PDF Files (*.pdf)|*.pdf|Html File (*.htm)|*.htm|All files (*.*)|*.*";
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    txtPath.Text = dialog.FileName;

                    supFileName = Path.GetFileName(dialog.FileName);
                    supFileExt = Path.GetExtension(dialog.FileName);
                }
                dialog.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbDetails.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Supplier", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (supFileName == string.Empty || txtPath.Text == "" || supFileName == null)
                {
                    MessageBox.Show("Please select File", "Supplier Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {

                    Serialize(supFileName);
                    txtPath.Text = "";
                    CmbDetails_SelectionChangeCommitted(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Serialize(string fileName)
        {
            try
            {
                FileInfo fi = new FileInfo(fileName);
                FileStream fs = fi.OpenRead();
                //FileUpload1.PostedFile.InputStream.Read()
                //Read all bytes into an array from the specified file.
                int nBytes = (int)fs.Length;
                byte[] ByteArray = new byte[nBytes];
                fs.Read(ByteArray, 0, nBytes);

                fs.Close();
                PMTransaction_Class_obj.pmtransid = Convert.ToInt64(CmbDetails.SelectedValue);
                PMTransaction_Class_obj.fileName = fileName;
                PMTransaction_Class_obj.fileExtension = supFileExt;
                PMTransaction_Class_obj.fileData = ByteArray;
                if (chkClose.Checked == true)
                {
                    PMTransaction_Class_obj.defstatus = 'C';
                }
                else if (chkClose.Checked == false)
                {
                    PMTransaction_Class_obj.defstatus = 'O';
                }
                bool flag = PMTransaction_Class_obj.Insert_PMSupplierCorrectiveNote();

                if (flag == true)
                {
                    MessageBox.Show("File uploaded successfully", "PM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPath.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
            finally
            {

            }

        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            if (lstFiles.Items.Count <= 0)
            {
                MessageBox.Show("There is no file List", "Supplier Corrective Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (lstFiles.SelectedValue == null)
            //{
            //    MessageBox.Show("Please select file", "Supplier Corrective Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            PMTransaction_Class_obj.correctiveNoteID = Convert.ToInt64(lstFiles.SelectedValue);
            DataSet ds = new DataSet();
            ds = PMTransaction_Class_obj.Select_tblSupplierCorrectiveNote_CorrectiveNoteID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                downLoadFile(ds.Tables[0]);
            }

        }

        private void downLoadFile(DataTable dt)
        {
            string sFileName, sFileExtension;

            //For Document
            try
            {
                sFileName = Convert.ToString(dt.Rows[0]["FileName"]);
                sFileExtension = Convert.ToString(dt.Rows[0]["FileType"]);

                //Get image data from DB
                byte[] fileData = (byte[])dt.Rows[0]["FileData"]; ;

                string sTempFileName = Application.StartupPath + "\\" + sFileName;

                if ((fileData != null))
                {
                    //Read image data into a file stream 
                    using (FileStream fs = new FileStream(sFileName, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        fs.Write(fileData, 0, fileData.Length);
                        //Set image variable value using memory stream. 
                        fs.Flush();
                        fs.Close();
                    }

                    Process.Start(sFileName);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                PMTransaction_Class_obj.pmtransid = Convert.ToInt64(CmbDetails.SelectedValue);
                ds = PMTransaction_Class_obj.Select_tblSupplierCorrectiveNote_PMTransID();
                int icount = ds.Tables[0].Rows.Count;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lstFiles.DataSource = ds.Tables[0];
                    lstFiles.DisplayMember = "FileName";
                    lstFiles.ValueMember = "CorrectiveNoteID";
                    if (ds.Tables[0].Rows[icount - 1]["DefectStatus"].ToString() == "C")
                    {
                        chkClose.Checked = true;
                    }
                    else
                    {
                        chkClose.Checked = false;
                    }
                }
                else
                    chkClose.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}