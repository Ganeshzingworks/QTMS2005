namespace QTMS.LineValidation
{
    partial class FrmLineLayoutMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            frm = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelbottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.btnSelectionArea = new System.Windows.Forms.Button();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.panelGdPicture = new System.Windows.Forms.Panel();
            this.panelPopUp = new System.Windows.Forms.Panel();
            this.btnPopUpCancel = new System.Windows.Forms.Button();
            this.kaireeHTMLEditor1 = new Kairee.Editor.KaireeHTMLEditor();
            this.btnSaveText = new System.Windows.Forms.Button();
            this.GdViewer = new GdPicture12.GdViewer();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelbottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.gbButtons.SuspendLayout();
            this.panelGdPicture.SuspendLayout();
            this.panelPopUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelOuter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(906, 637);
            this.panel1.TabIndex = 0;
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelbottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(906, 637);
            this.panelOuter.TabIndex = 5;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(904, 30);
            this.panelTop.TabIndex = 44;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonClose});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(904, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 27);
            this.toolStripLabel1.Text = "Line Master";
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonClose.BackColor = System.Drawing.Color.White;
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = global::QTMS.Properties.Resources.cancel;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(23, 27);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // panelbottom
            // 
            this.panelbottom.Controls.Add(this.panelFill);
            this.panelbottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbottom.Location = new System.Drawing.Point(0, 0);
            this.panelbottom.Name = "panelbottom";
            this.panelbottom.Size = new System.Drawing.Size(904, 635);
            this.panelbottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.btnSelectionArea);
            this.panelFill.Controls.Add(this.gbButtons);
            this.panelFill.Controls.Add(this.panelGdPicture);
            this.panelFill.Controls.Add(this.btnBrowse);
            this.panelFill.Location = new System.Drawing.Point(11, 23);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(872, 609);
            this.panelFill.TabIndex = 0;
            // 
            // btnSelectionArea
            // 
            this.btnSelectionArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSelectionArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectionArea.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectionArea.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSelectionArea.Location = new System.Drawing.Point(108, 25);
            this.btnSelectionArea.Name = "btnSelectionArea";
            this.btnSelectionArea.Size = new System.Drawing.Size(132, 28);
            this.btnSelectionArea.TabIndex = 26;
            this.btnSelectionArea.Text = "&Selection Area";
            this.btnSelectionArea.UseVisualStyleBackColor = false;
            this.btnSelectionArea.Click += new System.EventHandler(this.btnSelectionArea_Click);
            // 
            // gbButtons
            // 
            this.gbButtons.Controls.Add(this.BtnSave);
            this.gbButtons.Controls.Add(this.BtnExit);
            this.gbButtons.Location = new System.Drawing.Point(237, 536);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(530, 52);
            this.gbButtons.TabIndex = 23;
            this.gbButtons.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(169, 18);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(77, 28);
            this.BtnSave.TabIndex = 21;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(286, 18);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(79, 28);
            this.BtnExit.TabIndex = 22;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panelGdPicture
            // 
            this.panelGdPicture.Controls.Add(this.panelPopUp);
            this.panelGdPicture.Controls.Add(this.GdViewer);
            this.panelGdPicture.Location = new System.Drawing.Point(3, 59);
            this.panelGdPicture.Name = "panelGdPicture";
            this.panelGdPicture.Size = new System.Drawing.Size(866, 450);
            this.panelGdPicture.TabIndex = 25;
            // 
            // panelPopUp
            // 
            this.panelPopUp.Controls.Add(this.btnPopUpCancel);
            this.panelPopUp.Controls.Add(this.kaireeHTMLEditor1);
            this.panelPopUp.Controls.Add(this.btnSaveText);
            this.panelPopUp.Location = new System.Drawing.Point(164, 129);
            this.panelPopUp.Name = "panelPopUp";
            this.panelPopUp.Size = new System.Drawing.Size(566, 265);
            this.panelPopUp.TabIndex = 25;
            this.panelPopUp.Visible = false;
            // 
            // btnPopUpCancel
            // 
            this.btnPopUpCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPopUpCancel.BackgroundImage = global::QTMS.Properties.Resources.cancel;
            this.btnPopUpCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPopUpCancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPopUpCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPopUpCancel.Location = new System.Drawing.Point(544, 3);
            this.btnPopUpCancel.Name = "btnPopUpCancel";
            this.btnPopUpCancel.Size = new System.Drawing.Size(19, 19);
            this.btnPopUpCancel.TabIndex = 29;
            this.btnPopUpCancel.Text = "&Save";
            this.btnPopUpCancel.UseVisualStyleBackColor = false;
            this.btnPopUpCancel.Click += new System.EventHandler(this.btnPopUpCancel_Click);
            // 
            // kaireeHTMLEditor1
            // 
            this.kaireeHTMLEditor1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.kaireeHTMLEditor1.Location = new System.Drawing.Point(27, 32);
            this.kaireeHTMLEditor1.Name = "kaireeHTMLEditor1";
            this.kaireeHTMLEditor1.Size = new System.Drawing.Size(515, 197);
            this.kaireeHTMLEditor1.TabIndex = 28;
            // 
            // btnSaveText
            // 
            this.btnSaveText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnSaveText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveText.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveText.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSaveText.Location = new System.Drawing.Point(465, 231);
            this.btnSaveText.Name = "btnSaveText";
            this.btnSaveText.Size = new System.Drawing.Size(77, 28);
            this.btnSaveText.TabIndex = 23;
            this.btnSaveText.Text = "&Save";
            this.btnSaveText.UseVisualStyleBackColor = false;
            this.btnSaveText.Click += new System.EventHandler(this.btnSaveText_Click);
            // 
            // GdViewer
            // 
            this.GdViewer.AllowDrop = true;
            this.GdViewer.AllowDropFile = false;
            this.GdViewer.AnimateGIF = false;
            this.GdViewer.AnnotationDropShadow = false;
            this.GdViewer.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.GdViewer.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.GdViewer.BackColor = System.Drawing.Color.Black;
            this.GdViewer.BackgroundImage = null;
            this.GdViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.GdViewer.ContinuousViewMode = true;
            this.GdViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.GdViewer.DisplayQuality = GdPicture12.DisplayQuality.DisplayQualityBicubicHQ;
            this.GdViewer.DisplayQualityAuto = false;
            this.GdViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GdViewer.DocumentAlignment = GdPicture12.ViewerDocumentAlignment.DocumentAlignmentTopCenter;
            this.GdViewer.DocumentPosition = GdPicture12.ViewerDocumentPosition.DocumentPositionTopCenter;
            this.GdViewer.EnabledProgressBar = true;
            this.GdViewer.EnableICM = false;
            this.GdViewer.EnableMenu = true;
            this.GdViewer.EnableMouseWheel = true;
            this.GdViewer.EnableTextSelection = true;
            this.GdViewer.ForceScrollBars = false;
            this.GdViewer.ForceTemporaryModeForImage = false;
            this.GdViewer.ForceTemporaryModeForPDF = false;
            this.GdViewer.ForeColor = System.Drawing.Color.Black;
            this.GdViewer.Gamma = 1F;
            this.GdViewer.HQAnnotationRendering = true;
            this.GdViewer.IgnoreDocumentResolution = false;
            this.GdViewer.KeepDocumentPosition = false;
            this.GdViewer.Location = new System.Drawing.Point(0, 0);
            this.GdViewer.LockViewer = false;
            this.GdViewer.MagnifierHeight = 90;
            this.GdViewer.MagnifierWidth = 160;
            this.GdViewer.MagnifierZoomX = 2F;
            this.GdViewer.MagnifierZoomY = 2F;
            this.GdViewer.MouseButtonForMouseMode = GdPicture12.MouseButton.MouseButtonLeft;
            this.GdViewer.MouseMode = GdPicture12.ViewerMouseMode.MouseModeAreaSelection;
            this.GdViewer.MouseWheelMode = GdPicture12.ViewerMouseWheelMode.MouseWheelModeVerticalScroll;
            this.GdViewer.Name = "GdViewer";
            this.GdViewer.OptimizeDrawingSpeed = true;
            this.GdViewer.PdfDisplayFormField = true;
            this.GdViewer.PdfEnableFileLinks = true;
            this.GdViewer.PdfEnableLinks = true;
            this.GdViewer.PdfIncreaseTextContrast = false;
            this.GdViewer.PdfShowDialogForPassword = true;
            this.GdViewer.PdfShowOpenFileDialogForDecryption = true;
            this.GdViewer.PdfVerifyDigitalCertificates = false;
            this.GdViewer.RectBorderColor = System.Drawing.Color.Black;
            this.GdViewer.RectBorderSize = 1;
            this.GdViewer.RectIsEditable = true;
            this.GdViewer.RegionsAreEditable = true;
            this.GdViewer.ScrollBars = true;
            this.GdViewer.ScrollLargeChange = ((short)(50));
            this.GdViewer.ScrollSmallChange = ((short)(1));
            this.GdViewer.SilentMode = false;
            this.GdViewer.Size = new System.Drawing.Size(866, 450);
            this.GdViewer.TabIndex = 24;
            this.GdViewer.ViewRotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.GdViewer.Zoom = 1D;
            this.GdViewer.ZoomCenterAtMousePosition = false;
            this.GdViewer.ZoomMode = GdPicture12.ViewerZoomMode.ZoomMode100;
            this.GdViewer.ZoomStep = 25;
            this.GdViewer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GdViewer_MouseUp);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBrowse.Location = new System.Drawing.Point(16, 25);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(77, 28);
            this.btnBrowse.TabIndex = 23;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmLineLayoutMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(906, 637);
            this.Controls.Add(this.panel1);
            this.Name = "FrmLineLayoutMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Line Master";
            this.Load += new System.EventHandler(this.FrmLineValidationMaster1_Load);
            this.panel1.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelbottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.gbButtons.ResumeLayout(false);
            this.panelGdPicture.ResumeLayout(false);
            this.panelPopUp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Panel panelbottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.GroupBox gbButtons;
        internal GdPicture12.GdViewer GdViewer;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel panelGdPicture;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panelPopUp;
        private System.Windows.Forms.Button btnSaveText;
        private System.Windows.Forms.Button btnSelectionArea;
        private Kairee.Editor.KaireeHTMLEditor kaireeHTMLEditor1;
        private System.Windows.Forms.Button btnPopUpCancel;
    }
}