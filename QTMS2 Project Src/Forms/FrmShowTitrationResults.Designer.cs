namespace QTMS.Forms
{
    partial class FrmShowTitrationResults
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panelFill = new System.Windows.Forms.Panel();
            this.groupBoxReadings = new System.Windows.Forms.GroupBox();
            this.dgReadings = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.groupBoxReadings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReadings)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(661, 25);
            this.toolStrip1.TabIndex = 41;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(95, 22);
            this.toolStripLabel1.Text = "Titration Result";
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
            this.panelFill.Controls.Add(this.groupBoxReadings);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 25);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(661, 371);
            this.panelFill.TabIndex = 42;
            // 
            // groupBoxReadings
            // 
            this.groupBoxReadings.Controls.Add(this.dgReadings);
            this.groupBoxReadings.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxReadings.Location = new System.Drawing.Point(3, 0);
            this.groupBoxReadings.Name = "groupBoxReadings";
            this.groupBoxReadings.Size = new System.Drawing.Size(659, 370);
            this.groupBoxReadings.TabIndex = 1;
            this.groupBoxReadings.TabStop = false;
            // 
            // dgReadings
            // 
            this.dgReadings.AllowUserToAddRows = false;
            this.dgReadings.AllowUserToDeleteRows = false;
            this.dgReadings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgReadings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(197)))), ((int)(((byte)(208)))));
            this.dgReadings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgReadings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgReadings.Location = new System.Drawing.Point(0, 0);
            this.dgReadings.MultiSelect = false;
            this.dgReadings.Name = "dgReadings";
            this.dgReadings.ReadOnly = true;
            this.dgReadings.RowHeadersVisible = false;
            this.dgReadings.Size = new System.Drawing.Size(659, 368);
            this.dgReadings.TabIndex = 43;
            this.dgReadings.TabStop = false;
            // 
            // FrmShowTitrationResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 396);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmShowTitrationResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Titration Results";
            this.Load += new System.EventHandler(this.FrmShowTitrationResults_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelFill.ResumeLayout(false);
            this.groupBoxReadings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgReadings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.GroupBox groupBoxReadings;
        private System.Windows.Forms.DataGridView dgReadings;
    }
}