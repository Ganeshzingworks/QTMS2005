namespace QTMS.Transactions
{
    partial class FrmStabilityTestConfiguration
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
            frmStabilityTestConfiguration_Obj = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelFill = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBoxTest = new System.Windows.Forms.GroupBox();
            this.DtpCompletedDate = new System.Windows.Forms.DateTimePicker();
            this.DtpInspectedDate = new System.Windows.Forms.DateTimePicker();
            this.txtMfgWoNo = new System.Windows.Forms.TextBox();
            this.txtTechnicalFamily = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtpWeekDate = new System.Windows.Forms.DateTimePicker();
            this.lbCurrentDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbFormulaNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBoxTest.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonClose});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(747, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(162, 22);
            this.toolStripLabel1.Text = "Stability Test Configuration";
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonClose.BackColor = System.Drawing.Color.White;
            this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClose.Image = global::QTMS.Properties.Resources.cancel;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // panelFill
            // 
            this.panelFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.panelFill.Controls.Add(this.groupBox5);
            this.panelFill.Controls.Add(this.groupBoxTest);
            this.panelFill.Controls.Add(this.groupBox1);
            this.panelFill.Location = new System.Drawing.Point(12, 29);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(726, 386);
            this.panelFill.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox5.Controls.Add(this.BtnReset);
            this.groupBox5.Controls.Add(this.BtnExit);
            this.groupBox5.Controls.Add(this.BtnSave);
            this.groupBox5.Location = new System.Drawing.Point(18, 306);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(690, 50);
            this.groupBox5.TabIndex = 39;
            this.groupBox5.TabStop = false;
            // 
            // BtnReset
            // 
            this.BtnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReset.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnReset.Location = new System.Drawing.Point(130, 14);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(112, 28);
            this.BtnReset.TabIndex = 1;
            this.BtnReset.Text = "&Reset";
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnExit.Location = new System.Drawing.Point(451, 14);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(112, 28);
            this.BtnExit.TabIndex = 2;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(160)))));
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSave.Location = new System.Drawing.Point(288, 14);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(112, 28);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "&Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBoxTest
            // 
            this.groupBoxTest.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxTest.Controls.Add(this.DtpCompletedDate);
            this.groupBoxTest.Controls.Add(this.DtpInspectedDate);
            this.groupBoxTest.Controls.Add(this.txtMfgWoNo);
            this.groupBoxTest.Controls.Add(this.txtTechnicalFamily);
            this.groupBoxTest.Controls.Add(this.txtDescription);
            this.groupBoxTest.Controls.Add(this.label6);
            this.groupBoxTest.Controls.Add(this.label5);
            this.groupBoxTest.Controls.Add(this.label4);
            this.groupBoxTest.Controls.Add(this.label3);
            this.groupBoxTest.Controls.Add(this.label2);
            this.groupBoxTest.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTest.Location = new System.Drawing.Point(17, 82);
            this.groupBoxTest.Name = "groupBoxTest";
            this.groupBoxTest.Size = new System.Drawing.Size(691, 213);
            this.groupBoxTest.TabIndex = 5;
            this.groupBoxTest.TabStop = false;
            // 
            // DtpCompletedDate
            // 
            this.DtpCompletedDate.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.DtpCompletedDate.CalendarTitleForeColor = System.Drawing.Color.WhiteSmoke;
            this.DtpCompletedDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpCompletedDate.Enabled = false;
            this.DtpCompletedDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpCompletedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpCompletedDate.Location = new System.Drawing.Point(510, 75);
            this.DtpCompletedDate.Name = "DtpCompletedDate";
            this.DtpCompletedDate.Size = new System.Drawing.Size(124, 23);
            this.DtpCompletedDate.TabIndex = 30;
            this.DtpCompletedDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // DtpInspectedDate
            // 
            this.DtpInspectedDate.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.DtpInspectedDate.CalendarTitleForeColor = System.Drawing.Color.WhiteSmoke;
            this.DtpInspectedDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpInspectedDate.Enabled = false;
            this.DtpInspectedDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpInspectedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpInspectedDate.Location = new System.Drawing.Point(510, 23);
            this.DtpInspectedDate.Name = "DtpInspectedDate";
            this.DtpInspectedDate.Size = new System.Drawing.Size(124, 23);
            this.DtpInspectedDate.TabIndex = 29;
            this.DtpInspectedDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // txtMfgWoNo
            // 
            this.txtMfgWoNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMfgWoNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMfgWoNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMfgWoNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMfgWoNo.Location = new System.Drawing.Point(158, 26);
            this.txtMfgWoNo.MaxLength = 12;
            this.txtMfgWoNo.Name = "txtMfgWoNo";
            this.txtMfgWoNo.ReadOnly = true;
            this.txtMfgWoNo.Size = new System.Drawing.Size(198, 23);
            this.txtMfgWoNo.TabIndex = 17;
            // 
            // txtTechnicalFamily
            // 
            this.txtTechnicalFamily.BackColor = System.Drawing.SystemColors.Control;
            this.txtTechnicalFamily.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTechnicalFamily.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTechnicalFamily.Location = new System.Drawing.Point(158, 131);
            this.txtTechnicalFamily.Name = "txtTechnicalFamily";
            this.txtTechnicalFamily.ReadOnly = true;
            this.txtTechnicalFamily.Size = new System.Drawing.Size(199, 23);
            this.txtTechnicalFamily.TabIndex = 16;
            this.txtTechnicalFamily.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(157, 80);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(199, 23);
            this.txtDescription.TabIndex = 15;
            this.txtDescription.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(384, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Completed Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(383, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Inspected Date :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Technical Family :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mfg Wo. no. :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.DtpWeekDate);
            this.groupBox1.Controls.Add(this.lbCurrentDate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.CmbFormulaNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // DtpWeekDate
            // 
            this.DtpWeekDate.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.DtpWeekDate.CalendarTitleForeColor = System.Drawing.Color.WhiteSmoke;
            this.DtpWeekDate.CustomFormat = "dd-MMM-yyyy";
            this.DtpWeekDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpWeekDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpWeekDate.Location = new System.Drawing.Point(459, 18);
            this.DtpWeekDate.Name = "DtpWeekDate";
            this.DtpWeekDate.Size = new System.Drawing.Size(124, 23);
            this.DtpWeekDate.TabIndex = 28;
            this.DtpWeekDate.Value = new System.DateTime(2007, 11, 2, 0, 0, 0, 0);
            // 
            // lbCurrentDate
            // 
            this.lbCurrentDate.AutoSize = true;
            this.lbCurrentDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentDate.Location = new System.Drawing.Point(483, 23);
            this.lbCurrentDate.Name = "lbCurrentDate";
            this.lbCurrentDate.Size = new System.Drawing.Size(0, 16);
            this.lbCurrentDate.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(364, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Week 1 Date:";
            // 
            // CmbFormulaNo
            // 
            this.CmbFormulaNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbFormulaNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFormulaNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CmbFormulaNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFormulaNo.FormattingEnabled = true;
            this.CmbFormulaNo.Items.AddRange(new object[] {
            "select"});
            this.CmbFormulaNo.Location = new System.Drawing.Point(120, 14);
            this.CmbFormulaNo.Name = "CmbFormulaNo";
            this.CmbFormulaNo.Size = new System.Drawing.Size(183, 24);
            this.CmbFormulaNo.TabIndex = 1;
            this.CmbFormulaNo.SelectionChangeCommitted += new System.EventHandler(this.CmbFormulaNo_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Formula No";
            // 
            // FrmStabilityTestConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 428);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStabilityTestConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmStabilityTestConfiguration";
            this.Load += new System.EventHandler(this.FrmStabilityTestConfiguration_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelFill.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBoxTest.ResumeLayout(false);
            this.groupBoxTest.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.GroupBox groupBoxTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker DtpWeekDate;
        private System.Windows.Forms.Label lbCurrentDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbFormulaNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTechnicalFamily;
        private System.Windows.Forms.DateTimePicker DtpCompletedDate;
        private System.Windows.Forms.DateTimePicker DtpInspectedDate;
        private System.Windows.Forms.TextBox txtMfgWoNo;
    }
}