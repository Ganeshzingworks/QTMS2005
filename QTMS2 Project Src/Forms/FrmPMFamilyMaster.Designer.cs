namespace QTMS.Forms
{
    partial class FrmPMFamilyMaster
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
            frmPMFamilyMaster_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.List = new System.Windows.Forms.ListBox();
            this.gbSupplierName = new System.Windows.Forms.GroupBox();
            this.chkLstParameterName = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPMFamilyCDCVersion = new System.Windows.Forms.TextBox();
            this.lblPMFamilyName = new System.Windows.Forms.Label();
            this.lblPMFamilyCDCVersion = new System.Windows.Forms.Label();
            this.txtPMFamilyName = new System.Windows.Forms.TextBox();
            this.txtPMFamilyCOCFrequency = new System.Windows.Forms.TextBox();
            this.lblPMCOCFrequency = new System.Windows.Forms.Label();
            this.gbButtons = new System.Windows.Forms.GroupBox();
            this.btnPMFamilyModify = new System.Windows.Forms.Button();
            this.btnPMFamilyExit = new System.Windows.Forms.Button();
            this.btnPMFamilySave = new System.Windows.Forms.Button();
            this.btnPMFamilyDelete = new System.Windows.Forms.Button();
            this.btnPMFamilyReset = new System.Windows.Forms.Button();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gbSupplierName.SuspendLayout();
            this.gbButtons.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.FormattingEnabled = true;
            this.List.ItemHeight = 16;
            this.List.Location = new System.Drawing.Point(17, 57);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(184, 292);
            this.List.TabIndex = 2;
            this.List.SelectedIndexChanged += new System.EventHandler(this.List_SelectedIndexChanged);
            this.List.DoubleClick += new System.EventHandler(this.List_DoubleClick);
            this.List.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.List_KeyPress);
            // 
            // gbSupplierName
            // 
            this.gbSupplierName.Controls.Add(this.chkLstParameterName);
            this.gbSupplierName.Controls.Add(this.label2);
            this.gbSupplierName.Controls.Add(this.txtPMFamilyCDCVersion);
            this.gbSupplierName.Controls.Add(this.lblPMFamilyName);
            this.gbSupplierName.Controls.Add(this.lblPMFamilyCDCVersion);
            this.gbSupplierName.Controls.Add(this.txtPMFamilyName);
            this.gbSupplierName.Controls.Add(this.txtPMFamilyCOCFrequency);
            this.gbSupplierName.Controls.Add(this.lblPMCOCFrequency);
            this.gbSupplierName.Location = new System.Drawing.Point(221, 3);
            this.gbSupplierName.Name = "gbSupplierName";
            this.gbSupplierName.Size = new System.Drawing.Size(527, 277);
            this.gbSupplierName.TabIndex = 0;
            this.gbSupplierName.TabStop = false;
            // 
            // chkLstParameterName
            // 
            this.chkLstParameterName.FormattingEnabled = true;
            this.chkLstParameterName.Location = new System.Drawing.Point(39, 132);
            this.chkLstParameterName.Name = "chkLstParameterName";
            this.chkLstParameterName.Size = new System.Drawing.Size(470, 139);
            this.chkLstParameterName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label2.Location = new System.Drawing.Point(36, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 82;
            this.label2.Text = "Parameter Name :";
            // 
            // txtPMFamilyCDCVersion
            // 
            this.txtPMFamilyCDCVersion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMFamilyCDCVersion.Location = new System.Drawing.Point(232, 85);
            this.txtPMFamilyCDCVersion.Name = "txtPMFamilyCDCVersion";
            this.txtPMFamilyCDCVersion.Size = new System.Drawing.Size(277, 23);
            this.txtPMFamilyCDCVersion.TabIndex = 2;
            // 
            // lblPMFamilyName
            // 
            this.lblPMFamilyName.AutoSize = true;
            this.lblPMFamilyName.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMFamilyName.Location = new System.Drawing.Point(36, 24);
            this.lblPMFamilyName.Name = "lblPMFamilyName";
            this.lblPMFamilyName.Size = new System.Drawing.Size(101, 16);
            this.lblPMFamilyName.TabIndex = 0;
            this.lblPMFamilyName.Text = "Family Name :";
            // 
            // lblPMFamilyCDCVersion
            // 
            this.lblPMFamilyCDCVersion.AutoSize = true;
            this.lblPMFamilyCDCVersion.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMFamilyCDCVersion.Location = new System.Drawing.Point(36, 85);
            this.lblPMFamilyCDCVersion.Name = "lblPMFamilyCDCVersion";
            this.lblPMFamilyCDCVersion.Size = new System.Drawing.Size(89, 16);
            this.lblPMFamilyCDCVersion.TabIndex = 4;
            this.lblPMFamilyCDCVersion.Text = "Version No :";
            // 
            // txtPMFamilyName
            // 
            this.txtPMFamilyName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMFamilyName.Location = new System.Drawing.Point(232, 17);
            this.txtPMFamilyName.Name = "txtPMFamilyName";
            this.txtPMFamilyName.Size = new System.Drawing.Size(277, 23);
            this.txtPMFamilyName.TabIndex = 0;
            this.txtPMFamilyName.Leave += new System.EventHandler(this.txtPMFamilyName_Leave);
            // 
            // txtPMFamilyCOCFrequency
            // 
            this.txtPMFamilyCOCFrequency.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMFamilyCOCFrequency.Location = new System.Drawing.Point(232, 51);
            this.txtPMFamilyCOCFrequency.Name = "txtPMFamilyCOCFrequency";
            this.txtPMFamilyCOCFrequency.Size = new System.Drawing.Size(277, 23);
            this.txtPMFamilyCOCFrequency.TabIndex = 1;
            this.txtPMFamilyCOCFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPMFamilyCOCFrequency_KeyPress);
            // 
            // lblPMCOCFrequency
            // 
            this.lblPMCOCFrequency.AutoSize = true;
            this.lblPMCOCFrequency.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.lblPMCOCFrequency.Location = new System.Drawing.Point(36, 54);
            this.lblPMCOCFrequency.Name = "lblPMCOCFrequency";
            this.lblPMCOCFrequency.Size = new System.Drawing.Size(193, 16);
            this.lblPMCOCFrequency.TabIndex = 2;
            this.lblPMCOCFrequency.Text = "COC Frequency For Family :";
            // 
            // gbButtons
            // 
            this.gbButtons.Controls.Add(this.btnPMFamilyModify);
            this.gbButtons.Controls.Add(this.btnPMFamilyExit);
            this.gbButtons.Controls.Add(this.btnPMFamilySave);
            this.gbButtons.Controls.Add(this.btnPMFamilyDelete);
            this.gbButtons.Controls.Add(this.btnPMFamilyReset);
            this.gbButtons.Location = new System.Drawing.Point(221, 286);
            this.gbButtons.Name = "gbButtons";
            this.gbButtons.Size = new System.Drawing.Size(530, 59);
            this.gbButtons.TabIndex = 1;
            this.gbButtons.TabStop = false;
            // 
            // btnPMFamilyModify
            // 
            this.btnPMFamilyModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMFamilyModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMFamilyModify.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMFamilyModify.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMFamilyModify.Location = new System.Drawing.Point(129, 15);
            this.btnPMFamilyModify.Name = "btnPMFamilyModify";
            this.btnPMFamilyModify.Size = new System.Drawing.Size(80, 28);
            this.btnPMFamilyModify.TabIndex = 1;
            this.btnPMFamilyModify.Text = "&Modify";
            this.btnPMFamilyModify.UseVisualStyleBackColor = false;
            this.btnPMFamilyModify.Click += new System.EventHandler(this.btnPMFamilyModify_Click);
            // 
            // btnPMFamilyExit
            // 
            this.btnPMFamilyExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMFamilyExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMFamilyExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMFamilyExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMFamilyExit.Location = new System.Drawing.Point(429, 15);
            this.btnPMFamilyExit.Name = "btnPMFamilyExit";
            this.btnPMFamilyExit.Size = new System.Drawing.Size(80, 28);
            this.btnPMFamilyExit.TabIndex = 4;
            this.btnPMFamilyExit.Text = "&Exit";
            this.btnPMFamilyExit.UseVisualStyleBackColor = false;
            this.btnPMFamilyExit.Click += new System.EventHandler(this.btnPMFamilyExit_Click);
            // 
            // btnPMFamilySave
            // 
            this.btnPMFamilySave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMFamilySave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMFamilySave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMFamilySave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMFamilySave.Location = new System.Drawing.Point(329, 15);
            this.btnPMFamilySave.Name = "btnPMFamilySave";
            this.btnPMFamilySave.Size = new System.Drawing.Size(80, 28);
            this.btnPMFamilySave.TabIndex = 0;
            this.btnPMFamilySave.Text = "&Save";
            this.btnPMFamilySave.UseVisualStyleBackColor = false;
            this.btnPMFamilySave.Click += new System.EventHandler(this.btnPMFamilySave_Click);
            // 
            // btnPMFamilyDelete
            // 
            this.btnPMFamilyDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMFamilyDelete.Enabled = false;
            this.btnPMFamilyDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMFamilyDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMFamilyDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMFamilyDelete.Location = new System.Drawing.Point(229, 15);
            this.btnPMFamilyDelete.Name = "btnPMFamilyDelete";
            this.btnPMFamilyDelete.Size = new System.Drawing.Size(80, 28);
            this.btnPMFamilyDelete.TabIndex = 3;
            this.btnPMFamilyDelete.Text = "&Delete";
            this.btnPMFamilyDelete.UseVisualStyleBackColor = false;
            this.btnPMFamilyDelete.Click += new System.EventHandler(this.btnPMFamilyDelete_Click);
            // 
            // btnPMFamilyReset
            // 
            this.btnPMFamilyReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnPMFamilyReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPMFamilyReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPMFamilyReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPMFamilyReset.Location = new System.Drawing.Point(29, 15);
            this.btnPMFamilyReset.Name = "btnPMFamilyReset";
            this.btnPMFamilyReset.Size = new System.Drawing.Size(80, 28);
            this.btnPMFamilyReset.TabIndex = 2;
            this.btnPMFamilyReset.Text = "&Reset";
            this.btnPMFamilyReset.UseVisualStyleBackColor = false;
            this.btnPMFamilyReset.Click += new System.EventHandler(this.btnPMFamilyReset_Click);
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(764, 391);
            this.panelOuter.TabIndex = 10;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(762, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(762, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(109, 27);
            this.toolStripLabel1.Text = "PM Family Master";
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
            this.panelBottom.Location = new System.Drawing.Point(0, 33);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(762, 356);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.gbButtons);
            this.panelFill.Controls.Add(this.gbSupplierName);
            this.panelFill.Controls.Add(this.List);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(762, 356);
            this.panelFill.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(17, 12);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 18;
            this.lblSearch.Text = "Search :";
            this.lblSearch.Click += new System.EventHandler(this.lblSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(17, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(184, 23);
            this.txtSearch.TabIndex = 17;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // FrmPMFamilyMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(764, 391);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPMFamilyMaster";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PM Family Master";
            this.Load += new System.EventHandler(this.FrmPMFamilyMaster_Load);
            this.gbSupplierName.ResumeLayout(false);
            this.gbSupplierName.PerformLayout();
            this.gbButtons.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelFill.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox List;
        private System.Windows.Forms.GroupBox gbSupplierName;
        private System.Windows.Forms.TextBox txtPMFamilyName;
        private System.Windows.Forms.Label lblPMFamilyName;
        private System.Windows.Forms.Label lblPMCOCFrequency;
        private System.Windows.Forms.TextBox txtPMFamilyCOCFrequency;
        private System.Windows.Forms.Label lblPMFamilyCDCVersion;
        private System.Windows.Forms.TextBox txtPMFamilyCDCVersion;
        private System.Windows.Forms.GroupBox gbButtons;
        private System.Windows.Forms.Button btnPMFamilyModify;
        private System.Windows.Forms.Button btnPMFamilyExit;
        private System.Windows.Forms.Button btnPMFamilySave;
        private System.Windows.Forms.Button btnPMFamilyDelete;
        private System.Windows.Forms.Button btnPMFamilyReset;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckedListBox chkLstParameterName;
        private System.Windows.Forms.Label label2;
    }
}