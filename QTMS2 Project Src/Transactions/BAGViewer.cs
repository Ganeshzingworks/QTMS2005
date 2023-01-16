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
using QTMS.Viewer;

namespace QTMS.Transactions
{
    public partial class BAGViewer : System.Windows.Forms.Form
    {
        public BAGViewer()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("PDF viewer is not installed on this computer. Kindly install the PDF Viewer from the \\INCORPFAAPPSRV\\Aryan\\QTMSLIVE\\Acrobat Reader\\ location ");
            }
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
        private static BAGViewer frmPMMaster_Obj = null;
        public static BAGViewer GetInstance()
        {
            if (frmPMMaster_Obj == null)
            {
                frmPMMaster_Obj = new Transactions.BAGViewer();
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
            if ((CmbPMFamily.SelectedValue.ToString() != null) && (CmbPMFamily.SelectedValue.ToString() != ""))
            {
                DataRow dr;
                objBag = new BAGPMCode();
                DataSet ds = new DataSet();
                objBag.pmfamilyid = Convert.ToInt64(CmbPMFamily.SelectedValue);
                ds = objBag.Select_PMMaster_PMFamilyID();
                dr = ds.Tables[0].NewRow();
                dr["PMCode"] = "--Select--";
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
            else if (Convert.ToInt64(cmbPMCode.SelectedValue) <=0 || cmbPMCode.SelectedValue == null)
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

                //if (GlobalVariables.utypeid == 1)
                //{
                    if (filePath.Trim().ToUpper() == txtFileName.Text.Trim().ToUpper())
                    {
                        MessageBox.Show("Please select the File", "Message Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFileName.Clear();
                        return;

                    }
                    else
                    {
                        UploadBAGFile(filename);
                    }
                //}
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
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(MyClient.BuildServerUri(GlobalVariables.FTPDirectory + "/" + Convert.ToString(CmbPMFamily.Text)+"/" + GlobalVariables.CurrentFolder));
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
                    //if (GlobalVariables.utypeid == 1)
                    //{   
                      if(filePath!=string.Empty)  
                        MyClient.DeleteFile(filePath);//delete image already uploaded for that certifacte
                    //}
                    MyClient.UploadFile(GlobalVariables.FTPDirectory + "\\" +Convert.ToString(CmbPMFamily.Text)+"\\"+ GlobalVariables.CurrentFolder + "\\" + filename, txtFileName.Text.Trim());
                    BAGPMCode objBAGPMCode = new BAGPMCode();
                    if (objBAGPMCode.Insert_Upload_BagFile(Convert.ToInt64(cmbPMCode.SelectedValue), DateTime.Now,Convert.ToString(GlobalVariables.FTPDirectory + "\\" +Convert.ToString(CmbPMFamily.Text)+"\\"+ GlobalVariables.CurrentFolder + "\\" + filename),filename,txtDesc.Text, 1))
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
                        if(MessageBox.Show("Certificate image with same name is already Exist. Are you sure you want to Replace ?", "Confirm Replace", MessageBoxButtons.YesNo) == DialogResult.Yes) 
                        {
                         
                                MyClient.UploadFile(GlobalVariables.FTPDirectory + "\\" + GlobalVariables.CurrentFolder + "\\" + filename, txtFileName.Text.Trim());
                                BAGPMCode objBAGPMCode = new BAGPMCode();
                                if (objBAGPMCode.Insert_Upload_BagFile(Convert.ToInt64(cmbPMCode.SelectedValue), DateTime.Now,Convert.ToString(GlobalVariables.FTPDirectory + "\\" + GlobalVariables.CurrentFolder + "\\" + filename), filename,txtDesc.Text, 1))
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

        private void cmbPMCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbFileNames.DataSource = null;
            if (!Convert.IsDBNull(cmbPMCode.SelectedValue))
            {
                BAGPMCode objBagPMCode = new BAGPMCode();
                objBagPMCode.pmcodeId = Convert.ToInt64(cmbPMCode.SelectedValue);
                DataSet ds = new DataSet();
                ds = objBagPMCode.Select_BAGUpload_PMCodeID();
                cmbFileNames.DataSource = ds.Tables[0];
                cmbFileNames.ValueMember = "BagID";
                cmbFileNames.DisplayMember = "FileName";

                if (ds.Tables[0].Rows.Count > 0)
                    cmbFileNames_SelectionChangeCommitted(sender, e);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {

                pnlImageViewer.Visible = true;
                if (Directory.Exists(Application.StartupPath + "\\BAGViewer"))
                {
                    Directory.Delete(Application.StartupPath + "\\BAGViewer", true);
                }
                //Download the file in ImageViewer Folder to display in Viewer

                BAGPMCode objBagPMCode = new BAGPMCode();
                objBagPMCode.bagid = Convert.ToInt64(cmbFileNames.SelectedValue);
                DataSet ds = new DataSet();
                ds = objBagPMCode.Select_BAGUpload_BagID();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    filePath = Convert.ToString(dr["ImagePath"]);                    
                }

                string filename = filePath;

                string checkfile = filename.Substring(filename.LastIndexOf("\\") + 1);
                // DownloadedPath = Application.StartupPath + "\\Temp";

                if (!Directory.Exists(Application.StartupPath + "\\BAGViewer"))
                    Directory.CreateDirectory(Application.StartupPath + "\\BAGViewer");
                MyClient.DownloadFile(filename, Application.StartupPath + "\\BAGViewer" + "\\" + checkfile);


                ///Check the file is downloaded into temp folder(ImageViewer)
                if (File.Exists(Application.StartupPath + "\\BAGViewer" + "\\" + checkfile))
                {
                    ShowImageViewer(Application.StartupPath + "\\BAGViewer" + "\\" + checkfile);
                }
                else
                {
                    MessageBox.Show("File not found to display", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }

            catch (WebException ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        ucImageViewer imgViewer = null;
        public void ShowImageViewer(string DocPath)
        {
            try
            {
                try
                {

                    axAcroPDF1.LoadFile(DocPath);
                    //if (imgViewer != null && imgViewer.IsDisposed != true)
                    //{
                    //    imgViewer.Dispose();
                        
                    //}
                    //GC.Collect();

                    //imgViewer = new ucImageViewer(DocPath);
                    //imgViewer.Parent = this.pnlImageViewer;
                    //this.pnlImageViewer.Controls.Add(imgViewer);
                    //imgViewer.Dock = System.Windows.Forms.DockStyle.Fill;
                    //imgViewer.MinimumSize = new System.Drawing.Size(20, 20);
                    //imgViewer.Name = "Image Viewer";
                    //imgViewer.Size = new System.Drawing.Size(831, 282);//577
                    //imgViewer.TabIndex = 0;
                    //imgViewer.AccessibleName = "ImageViewer";
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }


        }

        private void cmbFileNames_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!Convert.IsDBNull(cmbFileNames.SelectedValue))
            {
                BAGPMCode objBagPMCode = new BAGPMCode();
                objBagPMCode.bagid = Convert.ToInt64(cmbFileNames.SelectedValue);
                DataSet ds = new DataSet();
                ds = objBagPMCode.Select_BAGUpload_BagID();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txtDesc.Text = Convert.ToString(dr["Description"]);
                }
            }
        }
    }
}