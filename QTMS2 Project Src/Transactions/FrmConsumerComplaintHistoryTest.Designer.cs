namespace QTMS.Transactions
{
    partial class FrmConsumerComplaintHistoryTest
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgConTest = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgIdTest = new System.Windows.Forms.DataGridView();
            this.panelOuter = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelFill = new System.Windows.Forms.Panel();
            this.FGPhyMethodNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Test = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FGPhyMethodNoCon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestCon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinCon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxCon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReadingCon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConTest)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIdTest)).BeginInit();
            this.panelOuter.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgConTest);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 164);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control Tests";
            // 
            // dgConTest
            // 
            this.dgConTest.AllowUserToAddRows = false;
            this.dgConTest.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgConTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgConTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FGPhyMethodNoCon,
            this.TestCon,
            this.MinCon,
            this.MaxCon,
            this.ReadingCon});
            this.dgConTest.Location = new System.Drawing.Point(21, 19);
            this.dgConTest.MultiSelect = false;
            this.dgConTest.Name = "dgConTest";
            this.dgConTest.RowHeadersVisible = false;
            this.dgConTest.Size = new System.Drawing.Size(508, 127);
            this.dgConTest.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgIdTest);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 154);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identification Tests";
            // 
            // dgIdTest
            // 
            this.dgIdTest.AllowUserToAddRows = false;
            this.dgIdTest.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgIdTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgIdTest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgIdTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIdTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FGPhyMethodNo,
            this.Test,
            this.Min,
            this.Max,
            this.Reading});
            this.dgIdTest.Location = new System.Drawing.Point(21, 17);
            this.dgIdTest.MultiSelect = false;
            this.dgIdTest.Name = "dgIdTest";
            this.dgIdTest.RowHeadersVisible = false;
            this.dgIdTest.Size = new System.Drawing.Size(508, 120);
            this.dgIdTest.TabIndex = 0;
            // 
            // panelOuter
            // 
            this.panelOuter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOuter.Controls.Add(this.panelTop);
            this.panelOuter.Controls.Add(this.panelBottom);
            this.panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOuter.Location = new System.Drawing.Point(0, 0);
            this.panelOuter.Name = "panelOuter";
            this.panelOuter.Size = new System.Drawing.Size(585, 415);
            this.panelOuter.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(583, 30);
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
            this.toolStrip1.Size = new System.Drawing.Size(583, 30);
            this.toolStrip1.TabIndex = 40;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(199, 27);
            this.toolStripLabel1.Text = "Consumer Complaint History Test";
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
            this.panelBottom.Size = new System.Drawing.Size(583, 380);
            this.panelBottom.TabIndex = 0;
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.groupBox2);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(583, 380);
            this.panelFill.TabIndex = 1;
            // 
            // FGPhyMethodNo
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.FGPhyMethodNo.DefaultCellStyle = dataGridViewCellStyle6;
            this.FGPhyMethodNo.Frozen = true;
            this.FGPhyMethodNo.HeaderText = "FGPhyMethodNo";
            this.FGPhyMethodNo.Name = "FGPhyMethodNo";
            this.FGPhyMethodNo.Visible = false;
            // 
            // Test
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Test.DefaultCellStyle = dataGridViewCellStyle7;
            this.Test.Frozen = true;
            this.Test.HeaderText = "Test";
            this.Test.Name = "Test";
            this.Test.ReadOnly = true;
            this.Test.Width = 250;
            // 
            // Min
            // 
            this.Min.Frozen = true;
            this.Min.HeaderText = "Min";
            this.Min.Name = "Min";
            this.Min.ReadOnly = true;
            this.Min.Width = 80;
            // 
            // Max
            // 
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Max.DefaultCellStyle = dataGridViewCellStyle8;
            this.Max.Frozen = true;
            this.Max.HeaderText = "Max";
            this.Max.Name = "Max";
            this.Max.ReadOnly = true;
            this.Max.Width = 80;
            // 
            // Reading
            // 
            this.Reading.HeaderText = "Reading";
            this.Reading.Name = "Reading";
            this.Reading.ReadOnly = true;
            this.Reading.Width = 80;
            // 
            // FGPhyMethodNoCon
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.FGPhyMethodNoCon.DefaultCellStyle = dataGridViewCellStyle2;
            this.FGPhyMethodNoCon.Frozen = true;
            this.FGPhyMethodNoCon.HeaderText = "FGPhyMethodNo";
            this.FGPhyMethodNoCon.Name = "FGPhyMethodNoCon";
            this.FGPhyMethodNoCon.Visible = false;
            // 
            // TestCon
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.TestCon.DefaultCellStyle = dataGridViewCellStyle3;
            this.TestCon.Frozen = true;
            this.TestCon.HeaderText = "Test";
            this.TestCon.Name = "TestCon";
            this.TestCon.ReadOnly = true;
            this.TestCon.Width = 250;
            // 
            // MinCon
            // 
            this.MinCon.Frozen = true;
            this.MinCon.HeaderText = "Min";
            this.MinCon.Name = "MinCon";
            this.MinCon.ReadOnly = true;
            this.MinCon.Width = 80;
            // 
            // MaxCon
            // 
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MaxCon.DefaultCellStyle = dataGridViewCellStyle4;
            this.MaxCon.Frozen = true;
            this.MaxCon.HeaderText = "Max";
            this.MaxCon.Name = "MaxCon";
            this.MaxCon.ReadOnly = true;
            this.MaxCon.Width = 80;
            // 
            // ReadingCon
            // 
            this.ReadingCon.HeaderText = "Reading";
            this.ReadingCon.Name = "ReadingCon";
            this.ReadingCon.ReadOnly = true;
            this.ReadingCon.Width = 80;
            // 
            // FrmConsumerComplaintHistoryTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(585, 415);
            this.Controls.Add(this.panelOuter);
            this.Name = "FrmConsumerComplaintHistoryTest";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumer Complaint History Test";
            this.Load += new System.EventHandler(this.FrmConsumerComplaintTest_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgConTest)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgIdTest)).EndInit();
            this.panelOuter.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgIdTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgConTest;
        private System.Windows.Forms.Panel panelOuter;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGPhyMethodNoCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReadingCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn FGPhyMethodNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Test;
        private System.Windows.Forms.DataGridViewTextBoxColumn Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reading;
    }
}