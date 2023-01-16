namespace QTMS.Forms
{
    partial class FrmPMTestMaster
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
            frmPMTestMaster_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LstTest = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDimensionTest = new System.Windows.Forms.CheckBox();
            this.txtPMDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPMTestName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnPMTestDelete = new System.Windows.Forms.Button();
            this.BtnPMTestModify = new System.Windows.Forms.Button();
            this.BtnPMTestReset = new System.Windows.Forms.Button();
            this.BtnPMTestExit = new System.Windows.Forms.Button();
            this.BtnPMTestSave = new System.Windows.Forms.Button();
            this.panelFill = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LstTest
            // 
            this.LstTest.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LstTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LstTest.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstTest.ItemHeight = 16;
            this.LstTest.Location = new System.Drawing.Point(14, 50);
            this.LstTest.Name = "LstTest";
            this.LstTest.Size = new System.Drawing.Size(255, 226);
            this.LstTest.TabIndex = 2;
            this.LstTest.DoubleClick += new System.EventHandler(this.LstTest_DoubleClick);
            this.LstTest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstTest_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkDimensionTest);
            this.groupBox1.Controls.Add(this.txtPMDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPMTestName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(287, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkDimensionTest
            // 
            this.chkDimensionTest.AutoSize = true;
            this.chkDimensionTest.Location = new System.Drawing.Point(131, 129);
            this.chkDimensionTest.Name = "chkDimensionTest";
            this.chkDimensionTest.Size = new System.Drawing.Size(127, 20);
            this.chkDimensionTest.TabIndex = 2;
            this.chkDimensionTest.Text = "Dimension Test";
            this.chkDimensionTest.UseVisualStyleBackColor = true;
            // 
            // txtPMDescription
            // 
            this.txtPMDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPMDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMDescription.Location = new System.Drawing.Point(131, 87);
            this.txtPMDescription.MaxLength = 200;
            this.txtPMDescription.Name = "txtPMDescription";
            this.txtPMDescription.Size = new System.Drawing.Size(280, 23);
            this.txtPMDescription.TabIndex = 1;
            this.txtPMDescription.Leave += new System.EventHandler(this.txtPMDescription_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description :";
            // 
            // txtPMTestName
            // 
            this.txtPMTestName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPMTestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPMTestName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMTestName.Location = new System.Drawing.Point(131, 43);
            this.txtPMTestName.MaxLength = 50;
            this.txtPMTestName.Name = "txtPMTestName";
            this.txtPMTestName.Size = new System.Drawing.Size(280, 23);
            this.txtPMTestName.TabIndex = 0;
            this.txtPMTestName.Leave += new System.EventHandler(this.txtPMTestName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Test Name :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.BtnPMTestDelete);
            this.groupBox2.Controls.Add(this.BtnPMTestModify);
            this.groupBox2.Controls.Add(this.BtnPMTestReset);
            this.groupBox2.Controls.Add(this.BtnPMTestExit);
            this.groupBox2.Controls.Add(this.BtnPMTestSave);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(287, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // BtnPMTestDelete
            // 
            this.BtnPMTestDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMTestDelete.Enabled = false;
            this.BtnPMTestDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMTestDelete.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMTestDelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMTestDelete.Location = new System.Drawing.Point(183, 17);
            this.BtnPMTestDelete.Name = "BtnPMTestDelete";
            this.BtnPMTestDelete.Size = new System.Drawing.Size(80, 27);
            this.BtnPMTestDelete.TabIndex = 7;
            this.BtnPMTestDelete.Text = "&Delete";
            this.BtnPMTestDelete.UseVisualStyleBackColor = false;
            this.BtnPMTestDelete.Click += new System.EventHandler(this.BtnPMTestDelete_Click);
            // 
            // BtnPMTestModify
            // 
            this.BtnPMTestModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMTestModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMTestModify.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMTestModify.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMTestModify.Location = new System.Drawing.Point(97, 17);
            this.BtnPMTestModify.Name = "BtnPMTestModify";
            this.BtnPMTestModify.Size = new System.Drawing.Size(80, 27);
            this.BtnPMTestModify.TabIndex = 6;
            this.BtnPMTestModify.Text = "&Modify";
            this.BtnPMTestModify.UseVisualStyleBackColor = false;
            this.BtnPMTestModify.Click += new System.EventHandler(this.BtnPMTestModify_Click);
            // 
            // BtnPMTestReset
            // 
            this.BtnPMTestReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMTestReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPMTestReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMTestReset.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMTestReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMTestReset.Location = new System.Drawing.Point(13, 17);
            this.BtnPMTestReset.Name = "BtnPMTestReset";
            this.BtnPMTestReset.Size = new System.Drawing.Size(76, 27);
            this.BtnPMTestReset.TabIndex = 5;
            this.BtnPMTestReset.Text = "Reset";
            this.BtnPMTestReset.UseVisualStyleBackColor = false;
            this.BtnPMTestReset.Click += new System.EventHandler(this.BtnPMTestReset_Click);
            // 
            // BtnPMTestExit
            // 
            this.BtnPMTestExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMTestExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMTestExit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMTestExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMTestExit.Location = new System.Drawing.Point(355, 17);
            this.BtnPMTestExit.Name = "BtnPMTestExit";
            this.BtnPMTestExit.Size = new System.Drawing.Size(80, 27);
            this.BtnPMTestExit.TabIndex = 4;
            this.BtnPMTestExit.Text = "E&xit";
            this.BtnPMTestExit.UseVisualStyleBackColor = false;
            this.BtnPMTestExit.Click += new System.EventHandler(this.BtnPMTestExit_Click);
            // 
            // BtnPMTestSave
            // 
            this.BtnPMTestSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnPMTestSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPMTestSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPMTestSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPMTestSave.Location = new System.Drawing.Point(269, 17);
            this.BtnPMTestSave.Name = "BtnPMTestSave";
            this.BtnPMTestSave.Size = new System.Drawing.Size(80, 27);
            this.BtnPMTestSave.TabIndex = 3;
            this.BtnPMTestSave.Text = "&Save";
            this.BtnPMTestSave.UseVisualStyleBackColor = false;
            this.BtnPMTestSave.Click += new System.EventHandler(this.BtnPMTestSave_Click);
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.lblSearch);
            this.panelFill.Controls.Add(this.txtSearch);
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Controls.Add(this.LstTest);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(749, 288);
            this.panelFill.TabIndex = 7;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(11, 2);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 16);
            this.lblSearch.TabIndex = 18;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(14, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(255, 23);
            this.txtSearch.TabIndex = 17;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseClick);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelFill);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 31);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(749, 288);
            this.panelBottom.TabIndex = 8;
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(751, 321);
            this.panelOuter.TabIndex = 9;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(749, 30);
            this.panelTop.TabIndex = 43;
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
            this.toolStrip1.Size = new System.Drawing.Size(749, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(97, 27);
            this.toolStripLabel1.Text = "PM Test Master";
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
            // FrmPMTestMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(751, 321);
            this.ControlBox = false;
            this.Controls.Add(this.panelOuter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPMTestMaster";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PM Test Master";
            this.Load += new System.EventHandler(this.FrmPMTestMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelFill.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LstTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPMDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPMTestName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnPMTestDelete;
        private System.Windows.Forms.Button BtnPMTestModify;
        private System.Windows.Forms.Button BtnPMTestReset;
        private System.Windows.Forms.Button BtnPMTestExit;
        private System.Windows.Forms.Button BtnPMTestSave;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkDimensionTest;
    }
}