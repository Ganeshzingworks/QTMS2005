using GdPicture12;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QTMS.LineValidation
{
    public partial class FrmLineValidationMaster1 : Form
    {
        GdPictureImaging image = new GdPictureImaging();

        GdPicturePDF oGdPicturePDF = new GdPicturePDF();
        GdPictureImaging oGdPictureImaging = new GdPictureImaging();
        public Rectangle selectedrect = new Rectangle();
        List<Rectangle> LocationTextList = new List<Rectangle>();
        private int imageId;

        public FrmLineValidationMaster1()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // result.
            {
                try
                {
                  //  if (!(System.IO.Path.GetExtension(openFileDialog1.FileName) == ".jpg" || System.IO.Path.GetExtension(openFileDialog1.FileName) == ".png" || System.IO.Path.GetExtension(openFileDialog1.FileName) == ".jpeg"))

                    //{
                    //    MessageBox.Show("Please select valid image file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    //else
                    //{
                        //Loading the PDF from a file
                        GdPictureStatus status = oGdPicturePDF.LoadFromFile(openFileDialog1.FileName, false);
                        //checking if the PDF was correctly loaded
                        if (status != GdPictureStatus.OK)
                        {
                            MessageBox.Show("Error: " + status.ToString());
                        }
                        else
                        {
                            LoadPage();
                        }
                    //}
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void LoadPage()
        {

            //oGdPicturePDF.SelectPage(0);
            //Rendering the selected page to an image
            imageId = oGdPicturePDF.RenderPageToGdPictureImage(200, true);
            //checking if the image was rendered successfuly
            if (imageId != 0)
            {
                //saving the image back to file
                GdViewer.DisplayFromGdPictureImage(imageId);
                GdViewer.Zoom = 1.25;//Zoom Size for Graphics Set
                GdViewer.Refresh();
            }
            else
            {
                MessageBox.Show("Error: " + image.GetStat().ToString());
            }
        }

        private void GdViewer_MouseUp(object sender, MouseEventArgs e)
        {
            int LeftArea = 0; int TopArea = 0; int WidthArea = 0; int HeightArea = 0;
            AnnotationManager AnnotationManager = GdViewer.GetAnnotationManager();
           
            GdViewer.GetRectCoordinatesOnDocument(ref LeftArea, ref TopArea, ref WidthArea, ref HeightArea);
                selectedrect.X = LeftArea;
                selectedrect.Y = TopArea;
                selectedrect.Width = WidthArea;
                selectedrect.Height = HeightArea;
                oGdPictureImaging.SetROI(LeftArea, TopArea, WidthArea, HeightArea);
            if (selectedrect.X != 0 || selectedrect.Y != 0 || selectedrect.Width != 0 || selectedrect.Height != 0)
            {
                AnnotationManager.AddEllipseAnnot(Color.Red, selectedrect.X, selectedrect.Y, selectedrect.Width, selectedrect.Height);
                GdViewer.AddEllipseAnnotInteractive(true,true,Color.Red,Color.Black, selectedrect.Width,50);
                GdViewer.AddRectangleHighlighterAnnotInteractive(Color.Red);
                //AnnotationManager.AddRectangleHighlighterAnnot
                PopUp(); 
            }
        }

        private void PopUp()
        {
            panelPopUp.Visible = true;
            //kaireeHTMLEditor1.Text = string.Empty;
        }

        private void FrmLineValidationMaster1_Load(object sender, EventArgs e)
        {
            try
            {
                GdPicture12.LicenseManager oLicenceManager = new GdPicture12.LicenseManager(); //Go to http://evaluation-gdpicture.com to get a 1 month trial key unlocking all features of the toolkit.
                oLicenceManager.RegisterKEY(System.Configuration.ConfigurationManager.AppSettings["GDPictureLicence"].ToString());//Please, replace XXXX by a valid demo or commercial license key.

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnSaveText_Click(object sender, EventArgs e)
        {
            try
            {
                string textofselection = kaireeHTMLEditor1.Text;
                if (selectedrect.X != 0 || selectedrect.Y != 0 || selectedrect.Width != 0 || selectedrect.Height != 0)
                {
                    LocationTextList.Add(selectedrect);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnSelectionArea_Click(object sender, EventArgs e)
        {
            GdViewer.AddEllipseAnnotInteractive(true, true, Color.Red, Color.Black, (float)(0.01), 1);
        }

        private void btnPopUpCancel_Click(object sender, EventArgs e)
        {
            panelPopUp.Visible = false;
           // kaireeHTMLEditor1.Text = string.Empty;
        }
    }

}
