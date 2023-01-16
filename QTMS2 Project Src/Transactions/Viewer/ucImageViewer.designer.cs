namespace QTMS.Viewer
{
    partial class ucImageViewer
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
          this.pbViewer.Image.Dispose();
            base.Dispose(disposing);
            
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pbViewer = new System.Windows.Forms.PictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.tsToolBox = new System.Windows.Forms.ToolStrip();
            this.tBoxTitle = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tPrev = new System.Windows.Forms.ToolStripButton();
            this.tPageNumber = new System.Windows.Forms.ToolStripTextBox();
            this.tNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.pnlMain.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewer)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.tsToolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.pnlMiddle);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 500);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.AutoScroll = true;
            this.pnlMiddle.BackColor = System.Drawing.Color.White;
            this.pnlMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMiddle.Controls.Add(this.pbViewer);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(10, 25);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(880, 465);
            this.pnlMiddle.TabIndex = 5;
            // 
            // pbViewer
            // 
            this.pbViewer.BackColor = System.Drawing.Color.White;
            this.pbViewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbViewer.Location = new System.Drawing.Point(0, -3);
            this.pbViewer.Name = "pbViewer";
            this.pbViewer.Size = new System.Drawing.Size(500, 525);
            this.pbViewer.TabIndex = 10;
            this.pbViewer.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(890, 25);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(10, 465);
            this.pnlRight.TabIndex = 4;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 25);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(10, 465);
            this.pnlLeft.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 490);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(900, 10);
            this.pnlBottom.TabIndex = 2;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlTop.Controls.Add(this.tsToolBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(900, 25);
            this.pnlTop.TabIndex = 0;
            // 
            // tsToolBox
            // 
            //this.tsToolBox.BackgroundImage = global::CertificateManagementSystem.Properties.Resources.menu_strip;
            this.tsToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsToolBox.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsToolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tBoxTitle,
            this.toolStripSeparator1,
            this.tZoomOut,
            this.tZoomIn,
            this.toolStripSeparator2,
            this.tPrev,
            this.tPageNumber,
            this.tNext,
            this.toolStripSeparator3,
            this.tsbPrint});
            this.tsToolBox.Location = new System.Drawing.Point(0, 0);
            this.tsToolBox.Name = "tsToolBox";
            this.tsToolBox.Size = new System.Drawing.Size(900, 25);
            this.tsToolBox.TabIndex = 0;
            this.tsToolBox.Text = "toolStrip1";
            // 
            // tBoxTitle
            // 
            this.tBoxTitle.AutoSize = false;
            this.tBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxTitle.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tBoxTitle.Name = "tBoxTitle";
            this.tBoxTitle.Size = new System.Drawing.Size(200, 22);
            this.tBoxTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tZoomOut
            // 
            this.tZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.tZoomOut.Image = global::CertificateManagementSystem.Properties.Resources.ZoomOut;
            this.tZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tZoomOut.Name = "tZoomOut";
            this.tZoomOut.Size = new System.Drawing.Size(23, 22);
            this.tZoomOut.Text = "Zoom Out";
            this.tZoomOut.Click += new System.EventHandler(this.tZoomOut_Click);
            // 
            // tZoomIn
            // 
            this.tZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.tZoomIn.Image = global::CertificateManagementSystem.Properties.Resources.ZoomIn;
            this.tZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tZoomIn.Name = "tZoomIn";
            this.tZoomIn.Size = new System.Drawing.Size(23, 22);
            this.tZoomIn.Text = "Zoom In";
            this.tZoomIn.Click += new System.EventHandler(this.tZoomIn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tPrev
            // 
            this.tPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.tPrev.Image = global::CertificateManagementSystem.Properties.Resources.Back;
            this.tPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tPrev.Name = "tPrev";
            this.tPrev.Size = new System.Drawing.Size(23, 22);
            this.tPrev.Text = "Prev";
            this.tPrev.Click += new System.EventHandler(this.tPrev_Click);
            // 
            // tPageNumber
            // 
            this.tPageNumber.AutoSize = false;
            this.tPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tPageNumber.Name = "tPageNumber";
            this.tPageNumber.Size = new System.Drawing.Size(40, 21);
            this.tPageNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tPageNumber_KeyPress);
            // 
            // tNext
            // 
            this.tNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.tNext.Image = global::CertificateManagementSystem.Properties.Resources.Forward;
            this.tNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tNext.Name = "tNext";
            this.tNext.Size = new System.Drawing.Size(23, 22);
            this.tNext.Text = "Next";
            this.tNext.Click += new System.EventHandler(this.tNext_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.tsbPrint.Image = global::CertificateManagementSystem.Properties.Resources.Print;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbPrint.ToolTipText = "Print";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // ucImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.pnlMain);
            this.Name = "ucImageViewer";
            this.Size = new System.Drawing.Size(900, 500);
            this.pnlMain.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbViewer)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.tsToolBox.ResumeLayout(false);
            this.tsToolBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.PictureBox pbViewer;
        private System.Windows.Forms.ToolStrip tsToolBox;
        private System.Windows.Forms.ToolStripLabel tBoxTitle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tZoomIn;
        private System.Windows.Forms.ToolStripButton tZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tPrev;
        private System.Windows.Forms.ToolStripTextBox tPageNumber;
        private System.Windows.Forms.ToolStripButton tNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbPrint;

    }
}