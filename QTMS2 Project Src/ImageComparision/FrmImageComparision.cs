using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using System.Security.Cryptography;

namespace QTMS.ImageComparision
{
    public partial class FrmImageComparision : Form
    {
        public FrmImageComparision()
        {
            InitializeComponent();
        }

        private void FrmImageComparision_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            try
            {
                Uri url = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ImageComparisonUrl"]+ "?uid=" + GlobalVariables.uid + "&uname=" + GlobalVariables.uname + "&pwd=" + GlobalVariables.pwd) ;
                
                wbImageComparision.Navigate(url);

                string str = DecryptString(GlobalVariables.pwd, "kairee");
                //wbImageComparision.Url =new Uri( System.Configuration.ConfigurationSettings.AppSettings["ImageComparisonUrl"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        public static string DecryptString(string strText, string key)
        {
            try
            {
                byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(key));
                TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
                provider.Key = buffer;
                provider.Mode = CipherMode.ECB;
                byte[] inputBuffer = Convert.FromBase64String(strText);
                return Encoding.ASCII.GetString(provider.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
 
        private void wbImageComparision_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            wbImageComparision.Document.GetElementById("ctl00_ContentPlaceHolder1_txtEmail").InnerText = "";
            wbImageComparision.Document.GetElementById("ctl00_ContentPlaceHolder1_txtPassword").InnerText = "";
            wbImageComparision.Document.GetElementById("ctl00_ContentPlaceHolder1_txtEmail").Focus();
            string submit = "admin" + "{Tab}" + "admin" + "{Enter}";
            SendKeys.Flush();
            SendKeys.SendWait(submit);
            SendKeys.Flush();
            //HtmlElement he = wbImageComparision.Document.GetElementById("ctl00_ContentPlaceHolder1_btnLogin");
            //he.InvokeMember("onclick='javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(\"ctl00$ContentPlaceHolder1$btnLogin\", \"\", true, \"Login\", \"\", false, false))'");
        }

        private void wbImageComparision_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            string str = wbImageComparision.Url.ToString();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}