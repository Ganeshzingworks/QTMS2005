namespace QTMS.Forms
{
    partial class BAG
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbPMFields = new System.Windows.Forms.GroupBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.cmbPMCode = new System.Windows.Forms.ComboBox();
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
            this.dgBagFile = new System.Windows.Forms.DataGridView();
            this.BagID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PMCodeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImagePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadedDate = new QTMS.Tools.CalendarColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPMFields.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBagFile)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPMFields
            // 
            this.gbPMFields.Controls.Add(this.btnUpload);
            this.gbPMFields.Controls.Add(this.btnBrowse);
            this.gbPMFields.Controls.Add(this.label3);
            this.gbPMFields.Controls.Add(this.label2);
            this.gbPMFields.Controls.Add(this.txtDesc);
            this.gbPMFields.Controls.Add(this.txtFileName);
            this.gbPMFields.Controls.Add(this.cmbPMCode);
            this.gbPMFields.Controls.Add(this.label1);
            this.gbPMFields.Controls.Add(this.CmbPMFamily);
            this.gbPMFields.Controls.Add(this.lblPMFamily);
            this.gbPMFields.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPMFields.Location = new System.Drawing.Point(12, 3);
            this.gbPMFields.Name = "gbPMFields";
            this.gbPMFields.Size = new System.Drawing.Size(814, 128);
            this.gbPMFields.TabIndex = 7;
            this.gbPMFields.TabStop = false;
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Location = new System.Drawing.Point(695, 93);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(63, 23);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(695, 58);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "..";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "File Desc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select File :";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(130, 93);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(559, 23);
            this.txtDesc.TabIndex = 4;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(130, 58);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(559, 23);
            this.txtFileName.TabIndex = 2;
            // 
            // cmbPMCode
            // 
            this.cmbPMCode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbPMCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPMCode.FormattingEnabled = true;
            this.cmbPMCode.Location = new System.Drawing.Point(498, 16);
            this.cmbPMCode.Name = "cmbPMCode";
            this.cmbPMCode.Size = new System.Drawing.Size(296, 24);
            this.cmbPMCode.TabIndex = 1;
            this.cmbPMCode.SelectionChangeCommitted += new System.EventHandler(this.cmbPMCode_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(416, 19);
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
            this.CmbPMFamily.Location = new System.Drawing.Point(130, 16);
            this.CmbPMFamily.Name = "CmbPMFamily";
            this.CmbPMFamily.Size = new System.Drawing.Size(262, 24);
            this.CmbPMFamily.TabIndex = 0;
            this.CmbPMFamily.SelectionChangeCommitted += new System.EventHandler(this.CmbPMFamily_SelectionChangeCommitted);
            // 
            // lblPMFamily
            // 
            this.lblPMFamily.AutoSize = true;
            this.lblPMFamily.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMFamily.Location = new System.Drawing.Point(23, 19);
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
            this.panelOuter.Size = new System.Drawing.Size(838, 671);
            this.panelOuter.TabIndex = 43;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(838, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(838, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 27);
            this.toolStripLabel1.Text = "BAG";
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
            this.panelBottom.Size = new System.Drawing.Size(838, 635);
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
            this.panelFill.Size = new System.Drawing.Size(838, 635);
            this.panelFill.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgBagFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 486);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Names";
            // 
            // dgBagFile
            // 
            this.dgBagFile.AllowUserToAddRows = false;
            this.dgBagFile.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgBagFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBagFile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgBagFile.ColumnHeadersHeight = 25;
            this.dgBagFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BagID,
            this.PMCodeID,
            this.FileName,
            this.Description,
            this.ImagePath,
            this.UploadedDate,
            this.Delete,
            this.Active});
            this.dgBagFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBagFile.Location = new System.Drawing.Point(3, 19);
            this.dgBagFile.MultiSelect = false;
            this.dgBagFile.Name = "dgBagFile";
            this.dgBagFile.ReadOnly = true;
            this.dgBagFile.RowHeadersWidth = 20;
            this.dgBagFile.Size = new System.Drawing.Size(808, 464);
            this.dgBagFile.TabIndex = 0;
            this.dgBagFile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgBagFile_CellContentClick);
            // 
            // BagID
            // 
            this.BagID.DataPropertyName = "BagID";
            this.BagID.HeaderText = "BagID";
            this.BagID.Name = "BagID";
            this.BagID.ReadOnly = true;
            this.BagID.Visible = false;
            // 
            // PMCodeID
            // 
            this.PMCodeID.DataPropertyName = "PMCodeID";
            this.PMCodeID.HeaderText = "PMCodeID";
            this.PMCodeID.Name = "PMCodeID";
            this.PMCodeID.ReadOnly = true;
            this.PMCodeID.Visible = false;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 250;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 300;
            // 
            // ImagePath
            // 
            this.ImagePath.DataPropertyName = "ImagePath";
            this.ImagePath.HeaderText = "Image Path";
            this.ImagePath.Name = "ImagePath";
            this.ImagePath.ReadOnly = true;
            this.ImagePath.Visible = false;
            this.ImagePath.Width = 250;
            // 
            // UploadedDate
            // 
            this.UploadedDate.DataPropertyName = "UploadedDate";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.UploadedDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.UploadedDate.HeaderText = "Uploaded Date";
            this.UploadedDate.Name = "UploadedDate";
            this.UploadedDate.ReadOnly = true;
            this.UploadedDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UploadedDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.UploadedDate.Width = 120;
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Delete1";
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Delete";
            this.Delete.Width = 65;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Visible = false;
            // 
            // BAG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(838, 671);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BAG";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BAG";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgBagFile)).EndInit();
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
        private System.Windows.Forms.DataGridView dgBagFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn BagID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PMCodeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImagePath;
        private QTMS.Tools.CalendarColumn UploadedDate;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
    }
}