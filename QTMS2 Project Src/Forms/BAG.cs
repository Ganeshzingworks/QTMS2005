using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using QTMS.Tools;
using System.Net;
using System.IO;
using System.Collections;

namespace QTMS.Forms
{
    public partial class BAG : System.Windows.Forms.Form
    {
        public BAG()
        {
            InitializeComponent();
        }
        #region Variables
        PMPeriodicTestMaster_Class PMPeriodicTestMaster_Class_obj = new PMPeriodicTestMaster_Class();
        PMMaster_Class PMMaster_Class_obj = new PMMaster_Class();
        PMTestMaster_Class PMTestMaster_Class_obj = new PMTestMaster_Class();
        DimensionParameter_Class DimensionParameter_Class_Obj = new DimensionParameter_Class();
        bool modify = false;
        bool supplieradd = false;
        #endregion
        DataSet dsList = new DataSet();
        bool isDoubleClick = false;
        BusinessFacade.Transactions.PMTransaction_Class PMTransaction_Class_obj = new BusinessFacade.Transactions.PMTransaction_Class();
        private static BAG frmPMMaster_Obj = null;
        public static BAG GetInstance()
        {
            if (frmPMMaster_Obj == null)
            {
                frmPMMaster_Obj = new Forms.BAG();
            }
            return frmPMMaster_Obj;
        }



        private void btnPMExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPMMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            Bind_Family();
        }


        public void Bind_Family()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = PMMaster_Class_obj.Select_PMFamilyMaster();
                dr = ds.Tables[0].NewRow();
                dr["PMFamilyName"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                CmbPMFamily.DataSource = ds.Tables[0];
                CmbPMFamily.DisplayMember = "PMFamilyName";
                CmbPMFamily.ValueMember = "PMFamilyID";


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






        private void btnPMSave_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Cannot Insert Duplicate Records", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }



        BAGPMCode objBag = null;
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbPMFamily_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbPMCode.DataSource = null;
            if (!Convert.IsDBNull(CmbPMFamily.SelectedValue))
            {
                DataRow dr;
                objBag = new BAGPMCode();
                DataSet ds = new DataSet();
                objBag.pmfamilyid = Convert.ToInt64(CmbPMFamily.SelectedValue);
                ds = objBag.Select_PMMaster_PMFamilyID();
                dr = ds.Tables[0].NewRow();
                dr["PMCode"] = "-- Select --";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cmbPMCode.DataSource = ds.Tables[0];
                cmbPMCode.DisplayMember = "PMCode";
                cmbPMCode.ValueMember = "PMCodeID";
            }
            else if (CmbPMFamily.Text == "--Select--")
            {

            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "PDF File (*.pdf)|*.pdf";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    txtFileName.Text = openFileDialog1.FileName.Trim();
                    //fileName = Path.GetFileName(openFileDialog1.FileName);
                    btnUpload.Enabled = true;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool Valid()
        {
            if (Convert.ToInt32(CmbPMFamily.SelectedValue) <= 0 || CmbPMFamily.SelectedValue == null)
            {
                MessageBox.Show("Please select the Family Name ", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CmbPMFamily.Focus();
                return false;
            }
            else if (Convert.ToInt64(cmbPMCode.SelectedValue) <= 0 || cmbPMCode.SelectedValue == null)
            {
                MessageBox.Show("Please select the PM Code", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbPMCode.Focus();
                return false;
            }
            else if (txtFileName.Text == string.Empty)
            {
                MessageBox.Show("Please select the File ", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFileName.Focus();
                return false;
            }

            return true;
        }
        string filePath = string.Empty;
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                string filename = txtFileName.Text.Trim().Substring(txtFileName.Text.Trim().LastIndexOf("\\") + 1);

                if (filePath.Trim().ToUpper() == txtFileName.Text.Trim().ToUpper())
                {
                    MessageBox.Show("Please select the File", "Message Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFileName.Clear();
                    return;

                }
                else
                {
                    UploadBAGFile(filename);
                    txtFileName.Text = "";
                    txtDesc.Text = "";
                    cmbPMCode_SelectionChangeCommitted(sender, e);

                }
            }
        }

        public bool Is_File_Exist(string DocumentName)
        {

            List<string> result = new List<string>();
            result = DirectoryListing();
            if (result.Contains(DocumentName))
            { return true; }
            else
            { return false; }
        }
        BasicFTPClient MyClient = new BasicFTPClient();
        public List<string> DirectoryListing()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(MyClient.BuildServerUri(GlobalVariables.FTPDirectory + "/" + Convert.ToString(CmbPMFamily.Text) + "/" + GlobalVariables.CurrentFolder));
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(GlobalVariables.FTPUsername, GlobalVariables.FTPPassword);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            List<string> result = new List<string>();

            while (!reader.EndOfStream)
            {
                result.Add(reader.ReadLine());
            }

            reader.Close();
            response.Close();
            return result;
        }
        private void MakeDir(string dirName)
        {
            FtpWebResponse response = null;
            Stream ftpStream = null;
            try
            {
                FtpWebRequest reqFTP;
                string[] Files = GetFileList();
                ArrayList arrDirectories = new ArrayList();
                if (Files != null)
                {
                    foreach (string dir in Files)
                    {
                        arrDirectories.Add(dir);
                    }
                }
                if (!arrDirectories.Contains(dirName))
                {
                    // dirName = name of the directory to create.
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + GlobalVariables.FTPHost + "/" + GlobalVariables.FTPDirectory + "/" + dirName));
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                    reqFTP.UseBinary = true;
                    reqFTP.KeepAlive = false;
                    reqFTP.Proxy = null;
                    reqFTP.Credentials = new NetworkCredential(GlobalVariables.FTPUsername, GlobalVariables.FTPPassword);
                    response = (FtpWebResponse)reqFTP.GetResponse();
                    ftpStream = response.GetResponseStream();
                }
            }
            catch (Exception ex)
            {
                if (ftpStream != null)
                {
                    ftpStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
        }
        public string[] GetFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + GlobalVariables.FTPHost + "/" + GlobalVariables.FTPDirectory + "/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(GlobalVariables.FTPUsername, GlobalVariables.FTPPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                downloadFiles = null;
                return downloadFiles;
            }
        }


        private void MakeSubDir(string dirName)
        {
            FtpWebResponse response = null;
            Stream ftpStream = null;
            try
            {
                FtpWebRequest reqFTP;
                string[] Files = GetFileList();
                ArrayList arrDirectories = new ArrayList();
                if (Files != null)
                {
                    foreach (string dir in Files)
                    {
                        arrDirectories.Add(dir);
                    }
                }
                if (!arrDirectories.Contains(dirName))
                {
                    // dirName = name of the directory to create.
                    reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + GlobalVariables.FTPHost + "/" + GlobalVariables.FTPDirectory + "/" + "/" + Convert.ToString(CmbPMFamily.Text) + "/" + dirName));
                    reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                    reqFTP.UseBinary = true;
                    reqFTP.KeepAlive = false;
                    reqFTP.Proxy = null;
                    reqFTP.Credentials = new NetworkCredential(GlobalVariables.FTPUsername, GlobalVariables.FTPPassword);
                    response = (FtpWebResponse)reqFTP.GetResponse();
                    ftpStream = response.GetResponseStream();
                }
            }
            catch (Exception ex)
            {
                if (ftpStream != null)
                {
                    ftpStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
        }


        public string[] GetSubFileList()
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            WebResponse response = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + GlobalVariables.FTPHost + "/" + GlobalVariables.FTPDirectory + "/" + Convert.ToString(CmbPMFamily.Text) + "/"));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(GlobalVariables.FTPUsername, GlobalVariables.FTPPassword);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                response = reqFTP.GetResponse();
                reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                downloadFiles = null;
                return downloadFiles;
            }
        }

        private void UploadBAGFile(string filename)
        {
            try
            {
                GlobalVariables.CurrentFolder = Convert.ToString(CmbPMFamily.Text.Trim());
                MakeDir(GlobalVariables.CurrentFolder);
                GlobalVariables.CurrentFolder = Convert.ToString(cmbPMCode.Text.Trim());
                MakeSubDir(GlobalVariables.CurrentFolder);
                if (!Is_File_Exist(filename))
                {
                    if (filePath != string.Empty)
                        MyClient.DeleteFile(filePath);//delete image already uploaded for that certifacte

                    MyClient.UploadFile(GlobalVariables.FTPDirectory + "\\" + Convert.ToString(CmbPMFamily.Text) + "\\" + GlobalVariables.CurrentFolder + "\\" + filename, txtFileName.Text.Trim());
                    BAGPMCode objBAGPMCode = new BAGPMCode();
                    if (objBAGPMCode.Insert_Upload_BagFile(Convert.ToInt64(cmbPMCode.SelectedValue), DateTime.Now, Convert.ToString(GlobalVariables.FTPDirectory + "\\" + Convert.ToString(CmbPMFamily.Text) + "\\" + GlobalVariables.CurrentFolder + "\\" + filename), filename, txtDesc.Text, 1,FrmMain.LoginID))
                    {
                        MessageBox.Show("File uploaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {

                        MessageBox.Show("Certificate not uploaded ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }   
                }
                else
                {
                    //if (GlobalVariables.utypeid == 1)
                    //{
                    if (MessageBox.Show("Certificate image with same name is already Exist. Are you sure you want to Add ?", "Confirm Replace", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string sFilename = Path.GetFileName(txtFileName.Text);
                        int file_append = 0;
                        while (Is_File_Exist(sFilename))
                        {
                            file_append++;
                            sFilename = System.IO.Path.GetFileNameWithoutExtension(filename)+ "_" + file_append.ToString() + ".pdf";

                        }

                        MyClient.UploadFile(GlobalVariables.FTPDirectory + "\\" + Convert.ToString(CmbPMFamily.Text) + "\\" + GlobalVariables.CurrentFolder + "\\" + sFilename, txtFileName.Text.Trim());
                        BAGPMCode objBAGPMCode = new BAGPMCode();
                        if (objBAGPMCode.Insert_Upload_BagFile(Convert.ToInt64(cmbPMCode.SelectedValue), DateTime.Now, Convert.ToString(GlobalVariables.FTPDirectory + "\\" + Convert.ToString(CmbPMFamily.Text) + "\\" + GlobalVariables.CurrentFolder + "\\" + sFilename), sFilename, txtDesc.Text, 1, FrmMain.LoginID))
                        {
                            MessageBox.Show("Certificate uploaded successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Certificate not uploaded ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //}                     
                    //else
                    //{
                    //    MessageBox.Show("Bag File with same name is already uploaded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                    //}
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //private string SaveFile(string fileName)
        //{
        //    try
        //    {
        //        int nFileLen = fileName.Length;
        //        string sFilename = "";

        //        string Extension = System.IO.Path.GetExtension(fileName);
        //        if (fileName != null)
        //        {
        //            if (nFileLen == 0)
        //            { return "FILE IS EMPTY"; }



        //            // Read file into a data stream
        //            byte[] myData = new Byte[nFileLen];
        //           // myFile.InputStream.Read(myData, 0, nFileLen);
        //            // Make sure a duplicate file doesn’t exist.  If it does, keep on appending an incremental numeric until it is unique
        //            sFilename = fileName;
        //            int file_append = 0;
        //            while (System.IO.File.Exists(Server.MapPath(sSavePath + sFilename)))
        //            {
        //                file_append++;
        //                sFilename = System.IO.Path.GetFileNameWithoutExtension(myFile.FileName) + file_append.ToString() + Extension;

        //            }
        //            // Save the stream to disk
        //            System.IO.FileStream newFile = new System.IO.FileStream(Server.MapPath(sSavePath + sFilename), System.IO.FileMode.Create);
        //            newFile.Write(myData, 0, myData.Length);
        //            newFile.Close();
        //            return sFilename;

        //        }
        //        else
        //            return "CORRUPT FILE";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "ERROR WHILE SAVING FILE";
        //    }
        //} 
        private void cmbPMCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //dgBagFile.DataSource = null;               

                if (!Convert.IsDBNull(cmbPMCode.SelectedValue))
                {
                    if (dgBagFile.Columns["BagID"] != null)
                        dgBagFile.Columns["BagID"].Visible = false;
                    if (dgBagFile.Columns["PMCodeID"] != null)
                        dgBagFile.Columns["PMCodeID"].Visible = false;
                    if (dgBagFile.Columns["ImagePath"] != null)
                        dgBagFile.Columns["ImagePath"].Visible = false;
                    if (dgBagFile.Columns["Active"] != null)
                        dgBagFile.Columns["Active"].Visible = false;
                    BAGPMCode objBagPMCode = new BAGPMCode();
                    objBagPMCode.pmcodeId = Convert.ToInt64(cmbPMCode.SelectedValue);
                    DataSet ds = new DataSet();
                    ds = objBagPMCode.Select_BAGUpload_Files_PMCodeID();
                    dgBagFile.DataSource = ds.Tables[0];
                    //cmbFileNames.ValueMember = "BagID";
                    //cmbFileNames.DisplayMember = "FileName";

                }
                else
                {
                    BAGPMCode objBagPMCode = new BAGPMCode();
                    objBagPMCode.pmcodeId = 0;
                    DataSet ds = new DataSet();
                    ds = objBagPMCode.Select_BAGUpload_Files_PMCodeID();
                    dgBagFile.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgBagFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (MessageBox.Show("Do you really want to delete?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (dgBagFile.CurrentRow.Cells["BagID"].Value != null)
                    {
                        BAGPMCode objBAGPMCode = new BAGPMCode();
                        objBAGPMCode.bagid = Convert.ToInt64(dgBagFile.CurrentRow.Cells["BagID"].Value);
                        bool b = objBAGPMCode.Delete_BAGUpload_BagID();
                        if (b == true)
                        {
                            MessageBox.Show("Record removed successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                            cmbPMCode_SelectionChangeCommitted(sender, e);
                        }
                    }
                }
            }
        }
    }
}