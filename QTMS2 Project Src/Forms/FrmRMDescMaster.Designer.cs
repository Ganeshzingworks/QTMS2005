namespace QTMS.Forms
{
    partial class FrmRMDescMaster
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
            frmRMDescMaster_Obj = null;
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
            this.List = new System.Windows.Forms.ListBox();
            this.BtnExit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Para = new System.Windows.Forms.Label();
            this.btnDescModify = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.CmbParameterName = new System.Windows.Forms.ComboBox();
            this.btnDescReset = new System.Windows.Forms.Button();
            this.btnDescDelete = new System.Windows.Forms.Button();
            this.btnDescAdd = new System.Windows.Forms.Button();
            this.dgRMDesc = new System.Windows.Forms.DataGridView();
            this.DescNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label22 = new System.Windows.Forms.Label();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRMDesc)).BeginInit();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // List
            // 
            this.List.BackColor = System.Drawing.Color.WhiteSmoke;
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.List.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.ItemHeight = 16;
            this.List.Location = new System.Drawing.Point(15, 58);
            this.List.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(207, 290);
            this.List.TabIndex = 2;
            this.List.DoubleClick += new System.EventHandler(this.List_DoubleClick);
            this.List.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.List_KeyPress);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(364, 105);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(70, 26);
            this.BtnExit.TabIndex = 8;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Para);
            this.groupBox3.Controls.Add(this.btnDescModify);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.CmbParameterName);
            this.groupBox3.Controls.Add(this.BtnExit);
            this.groupBox3.Controls.Add(this.btnDescReset);
            this.groupBox3.Controls.Add(this.btnDescDelete);
            this.groupBox3.Controls.Add(this.btnDescAdd);
            this.groupBox3.Controls.Add(this.dgRMDesc);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Location = new System.Drawing.Point(244, 10);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(506, 338);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // Para
            // 
            this.Para.AutoSize = true;
            this.Para.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Para.Location = new System.Drawing.Point(25, 28);
            this.Para.Name = "Para";
            this.Para.Size = new System.Drawing.Size(75, 16);
            this.Para.TabIndex = 0;
            this.Para.Text = "Parameter";
            // 
            // btnDescModify
            // 
            this.btnDescModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnDescModify.Enabled = false;
            this.btnDescModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescModify.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescModify.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescModify.Location = new System.Drawing.Point(218, 105);
            this.btnDescModify.Name = "btnDescModify";
            this.btnDescModify.Size = new System.Drawing.Size(70, 26);
            this.btnDescModify.TabIndex = 6;
            this.btnDescModify.Text = "Modify";
            this.btnDescModify.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDescModify.UseVisualStyleBackColor = false;
            this.btnDescModify.Click += new System.EventHandler(this.btnDescModify_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(120, 65);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(362, 23);
            this.txtDescription.TabIndex = 3;
            // 
            // CmbParameterName
            // 
            this.CmbParameterName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbParameterName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbParameterName.FormattingEnabled = true;
            this.CmbParameterName.Location = new System.Drawing.Point(120, 24);
            this.CmbParameterName.Name = "CmbParameterName";
            this.CmbParameterName.Size = new System.Drawing.Size(362, 24);
            this.CmbParameterName.TabIndex = 1;
            this.CmbParameterName.SelectionChangeCommitted += new System.EventHandler(this.CmbParameterName_SelectionChangeCommitted);
            // 
            // btnDescReset
            // 
            this.btnDescReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnDescReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescReset.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescReset.Location = new System.Drawing.Point(72, 105);
            this.btnDescReset.Name = "btnDescReset";
            this.btnDescReset.Size = new System.Drawing.Size(70, 26);
            this.btnDescReset.TabIndex = 4;
            this.btnDescReset.Text = "Reset ";
            this.btnDescReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDescReset.UseVisualStyleBackColor = false;
            this.btnDescReset.Click += new System.EventHandler(this.btnDescReset_Click);
            // 
            // btnDescDelete
            // 
            this.btnDescDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnDescDelete.Enabled = false;
            this.btnDescDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescDelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescDelete.Location = new System.Drawing.Point(145, 105);
            this.btnDescDelete.Name = "btnDescDelete";
            this.btnDescDelete.Size = new System.Drawing.Size(70, 26);
            this.btnDescDelete.TabIndex = 5;
            this.btnDescDelete.Text = "Delete";
            this.btnDescDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDescDelete.UseVisualStyleBackColor = false;
            this.btnDescDelete.Click += new System.EventHandler(this.btnDescDelete_Click);
            // 
            // btnDescAdd
            // 
            this.btnDescAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.btnDescAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescAdd.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescAdd.Location = new System.Drawing.Point(291, 105);
            this.btnDescAdd.Name = "btnDescAdd";
            this.btnDescAdd.Size = new System.Drawing.Size(70, 26);
            this.btnDescAdd.TabIndex = 7;
            this.btnDescAdd.Text = "Add ";
            this.btnDescAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDescAdd.UseVisualStyleBackColor = false;
            this.btnDescAdd.Click += new System.EventHandler(this.btnDescAdd_Click);
            // 
            // dgRMDesc
            // 
            this.dgRMDesc.AllowUserToAddRows = false;
            this.dgRMDesc.AllowUserToResizeColumns = false;
            this.dgRMDesc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgRMDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRMDesc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgRMDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRMDesc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DescNo,
            this.DescName});
            this.dgRMDesc.Location = new System.Drawing.Point(68, 153);
            this.dgRMDesc.MultiSelect = false;
            this.dgRMDesc.Name = "dgRMDesc";
            this.dgRMDesc.RowHeadersWidth = 20;
            this.dgRMDesc.Size = new System.Drawing.Size(386, 161);
            this.dgRMDesc.TabIndex = 9;
            this.dgRMDesc.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPres_RowEnter);
            // 
            // DescNo
            // 
            this.DescNo.HeaderText = "DescNo";
            this.DescNo.Name = "DescNo";
            this.DescNo.ReadOnly = true;
            this.DescNo.Visible = false;
            // 
            // DescName
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescName.DefaultCellStyle = dataGridViewCellStyle2;
            this.DescName.HeaderText = "Description";
            this.DescName.Name = "DescName";
            this.DescName.ReadOnly = true;
            this.DescName.Width = 350;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(25, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 16);
            this.label22.TabIndex = 2;
            this.label22.Text = "Description ";
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(766, 394);
            this.panelOuter.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(764, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(764, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(209, 27);
            this.toolStripLabel1.Text = "RM Parameter - Description Master";
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
            this.panelBottom.Size = new System.Drawing.Size(764, 359);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.groupBox3);
            this.panelFill.Controls.Add(this.List);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(764, 359);
            this.panelFill.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(20, 10);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 10;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(15, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(207, 23);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // FrmRMDescMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(766, 394);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmRMDescMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RM Parameter - Description Master";
            this.Load += new System.EventHandler(this.FrmRMDescMaster_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRMDesc)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDescReset;
        private System.Windows.Forms.Button btnDescDelete;
        private System.Windows.Forms.Button btnDescAdd;
        private System.Windows.Forms.DataGridView dgRMDesc;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.ComboBox CmbParameterName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnDescModify;
        private System.Windows.Forms.Label Para;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescName;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}