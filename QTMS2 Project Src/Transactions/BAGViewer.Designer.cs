namespace QTMS.Transactions
{
    partial class BAGViewer
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
            frmPMMaster_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAGViewer));
            this.gbPMFields = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.cmbFileNames = new System.Windows.Forms.ComboBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cmbPMCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbPMFamily = new System.Windows.Forms.ComboBox();
            this.lblPMFamily = new System.Windows.Forms.Label();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlImageViewer = new System.Windows.Forms.Panel();           
            this.axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            this.gbPMFields.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlImageViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPMFields
            // 
            this.gbPMFields.Controls.Add(this.label4);
            this.gbPMFields.Controls.Add(this.txtDesc);
            this.gbPMFields.Controls.Add(this.label2);
            this.gbPMFields.Controls.Add(this.btnView);
            this.gbPMFields.Controls.Add(this.btnUpload);
            this.gbPMFields.Controls.Add(this.cmbFileNames);
            this.gbPMFields.Controls.Add(this.txtFileName);
            this.gbPMFields.Controls.Add(this.btnBrowse);
            this.gbPMFields.Controls.Add(this.cmbPMCode);
            this.gbPMFields.Controls.Add(this.label3);
            this.gbPMFields.Controls.Add(this.label1);
            this.gbPMFields.Controls.Add(this.CmbPMFamily);
            this.gbPMFields.Controls.Add(this.lblPMFamily);
            this.gbPMFields.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPMFields.Location = new System.Drawing.Point(12, 3);
            this.gbPMFields.Name = "gbPMFields";
            this.gbPMFields.Size = new System.Drawing.Size(1004, 81);
            this.gbPMFields.TabIndex = 7;
            this.gbPMFields.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "File Desc:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(113, 46);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(559, 23);
            this.txtDesc.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select File :";
            this.label2.Visible = false;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(682, 46);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(63, 23);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Location = new System.Drawing.Point(733, 67);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(63, 23);
            this.btnUpload.TabIndex = 7;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Visible = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // cmbFileNames
            // 
            this.cmbFileNames.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbFileNames.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFileNames.FormattingEnabled = true;
            this.cmbFileNames.Location = new System.Drawing.Point(758, 16);
            this.cmbFileNames.Name = "cmbFileNames";
            this.cmbFileNames.Size = new System.Drawing.Size(240, 24);
            this.cmbFileNames.TabIndex = 2;
            this.cmbFileNames.SelectionChangeCommitted += new System.EventHandler(this.cmbFileNames_SelectionChangeCommitted);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(114, 68);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(559, 23);
            this.txtFileName.TabIndex = 5;
            this.txtFileName.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(683, 67);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Visible = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmbPMCode
            // 
            this.cmbPMCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbPMCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPMCode.FormattingEnabled = true;
            this.cmbPMCode.Location = new System.Drawing.Point(432, 16);
            this.cmbPMCode.Name = "cmbPMCode";
            this.cmbPMCode.Size = new System.Drawing.Size(241, 24);
            this.cmbPMCode.TabIndex = 1;
            this.cmbPMCode.SelectionChangeCommitted += new System.EventHandler(this.cmbPMCode_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label3.Location = new System.Drawing.Point(679, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "File Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(355, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "PM Code :";
            // 
            // CmbPMFamily
            // 
            this.CmbPMFamily.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbPMFamily.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPMFamily.FormattingEnabled = true;
            this.CmbPMFamily.Location = new System.Drawing.Point(113, 16);
            this.CmbPMFamily.Name = "CmbPMFamily";
            this.CmbPMFamily.Size = new System.Drawing.Size(236, 24);
            this.CmbPMFamily.TabIndex = 0;
            this.CmbPMFamily.SelectionChangeCommitted += new System.EventHandler(this.CmbPMFamily_SelectionChangeCommitted);
            // 
            // lblPMFamily
            // 
            this.lblPMFamily.AutoSize = true;
            this.lblPMFamily.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMFamily.Location = new System.Drawing.Point(6, 19);
            this.lblPMFamily.Name = "lblPMFamily";
            this.lblPMFamily.Size = new System.Drawing.Size(101, 16);
            this.lblPMFamily.TabIndex = 5;
            this.lblPMFamily.Text = "Family Name :";
            // 
            // panelOuter
            // 
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(1028, 746);
            this.panelOuter.TabIndex = 43;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1028, 30);
            this.panelTop.TabIndex = 42;
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
            this.toolStrip1.Size = new System.Drawing.Size(1028, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(71, 27);
            this.toolStripLabel1.Text = "BAGViewer";
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
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFill);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 36);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1028, 710);
            this.panelBottom.TabIndex = 43;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Controls.Add(this.gbPMFields);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(1028, 710);
            this.panelFill.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlImageViewer);
            this.groupBox1.Location = new System.Drawing.Point(12, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1013, 615);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Names";
            // 
            // pnlImageViewer
            // 
            this.pnlImageViewer.AutoScroll = true;
            this.pnlImageViewer.Controls.Add(this.axAcroPDF1);
            this.pnlImageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImageViewer.Location = new System.Drawing.Point(3, 19);
            this.pnlImageViewer.Name = "pnlImageViewer";
            this.pnlImageViewer.Size = new System.Drawing.Size(1007, 593);
            this.pnlImageViewer.TabIndex = 85;
            // 
            // axAcroPDF1
            // 
            this.axAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF1.Enabled = true;
            this.axAcroPDF1.Location = new System.Drawing.Point(0, 0);
            this.axAcroPDF1.Name = "axAcroPDF1";
            this.axAcroPDF1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF1.OcxState")));
            this.axAcroPDF1.Size = new System.Drawing.Size(1007, 593);
            this.axAcroPDF1.TabIndex = 0;
            // 
            // BAGViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BAGViewer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BAGViewer";
            this.Load += new System.EventHandler(this.FrmPMMaster_Load);
            this.gbPMFields.ResumeLayout(false);
            this.gbPMFields.PerformLayout();
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnlImageViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPMFields;
        private System.Windows.Forms.Label lblPMFamily;
        private System.Windows.Forms.ComboBox CmbPMFamily;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ComboBox cmbPMCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cmbFileNames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlImageViewer;
       // private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDesc;
    }
}