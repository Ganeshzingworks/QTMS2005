using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace QTMS.Viewer
{
    public partial class ucImageViewer : UserControl
    {
        private string DocumentPath = String.Empty;
        public ucImageViewer(string docPath)
        {
            DocumentPath = docPath;
            InitializeComponent();
            InitializePicture(DocumentPath);
           // Painter.Paint(this);
        }

        private int PageCount = 0;
        private int CurrentPage = 0;
        
        public void InitializePicture(string docPath)
        {
            this.pbViewer.Image = Image.FromFile(docPath,true);
            PageCount = this.pbViewer.Image.GetFrameCount(FrameDimension.Page);
            CurrentPage = 0;
            tBoxTitle.Text = docPath.Substring(docPath.LastIndexOf("\\") + 1, (docPath.Length-1) - docPath.LastIndexOf("\\"));
            LoadImage();          
            this.pbViewer.SizeMode = PictureBoxSizeMode.StretchImage;
            pbViewer.Height= 775;
            pbViewer.Width = 750;
            //Painter.Paint(this);
        }

        private void LoadImage()
        {
            this.pbViewer.Image.SelectActiveFrame(FrameDimension.Page, CurrentPage);
            this.pbViewer.Refresh();
            
            tPageNumber.Text = Convert.ToString((CurrentPage + 1));
            CheckButtonAccessibility();
        }
        
        private void CheckButtonAccessibility()
        {
            if (PageCount == 1)
            {
                tNext.Enabled = false;
                tPrev.Enabled = false;
                tPageNumber.Enabled = false;
            }
            else
            {
                if (CurrentPage + 1 >= PageCount)
                {
                    tNext.Enabled = false;
                    tPrev.Enabled = true;
                }
                else if (CurrentPage - 1 < 0)
                {
                    tPrev.Enabled = false;
                    tNext.Enabled = true;
                }
                else
                {
                    tPrev.Enabled = true;
                    tNext.Enabled = true;
                }
            }
        }
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            pbViewer.Height += 25;
            pbViewer.Width += 25;
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (pbViewer.Height > 25)
            {
                pbViewer.Height -= 25;
            }
            if (pbViewer.Width > 25)
            {
                pbViewer.Width -= 25;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            CheckButtonAccessibility();
            LoadImage();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            CheckButtonAccessibility();
            LoadImage();
        }

        private void txtPageNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 9 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                if (tPageNumber.Text != "")
                {
                    if (PageCount == 1)
                    {
                        CurrentPage = 0;
                    }
                    else if (PageCount > 1)
                    {


                        int pageNo = Convert.ToInt32(tPageNumber.Text);
                        if (pageNo > 0 && pageNo <= PageCount)
                        {
                            CurrentPage = pageNo - 1;
                        }
                        else
                        {
                            CurrentPage = PageCount - 1;
                        }
                    }
                    CheckButtonAccessibility();
                    LoadImage();
                }
                else
                {
                    MessageBox.Show("Enter a page number between 1 and " + PageCount, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tZoomIn_Click(object sender, EventArgs e)
        {
            pbViewer.Height += 25;
            pbViewer.Width += 25;
        }

        private void tZoomOut_Click(object sender, EventArgs e)
        {
            if (pbViewer.Height > 25)
            {
                pbViewer.Height -= 25;
            }
            if (pbViewer.Width > 25)
            {
                pbViewer.Width -= 25;
            }
        }

        private void tPrev_Click(object sender, EventArgs e)
        {
            CurrentPage--;
            CheckButtonAccessibility();
            LoadImage();
        }

        private void tNext_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            CheckButtonAccessibility();
            LoadImage();
        }

        private void tPageNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 9 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 13)
            {
                if (tPageNumber.Text != "")
                {
                    if (PageCount == 1)
                    {
                        CurrentPage = 0;
                    }
                    else if (PageCount > 1)
                    {


                        int pageNo = Convert.ToInt32(tPageNumber.Text);
                        if (pageNo > 0 && pageNo <= PageCount)
                        {
                            CurrentPage = pageNo - 1;
                        }
                        else
                        {
                            CurrentPage = PageCount - 1;
                        }
                    }
                    CheckButtonAccessibility();
                    LoadImage();
                }
                else
                {
                    MessageBox.Show("Enter a page number between 1 and " + PageCount, "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void tClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            //PrintManager pManager = new PrintManager();
            //pManager.DocumentType = 1;
            //pManager.PrintDocName = DocumentPath;
            //pManager.PrintImage();
        }

        

       
    }
}
