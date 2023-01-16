namespace QTMS.Reports_Forms
{
    partial class LabelValidity
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn11 = new System.Windows.Forms.Button();
            this.btn12 = new System.Windows.Forms.Button();
            this.btn21 = new System.Windows.Forms.Button();
            this.btn22 = new System.Windows.Forms.Button();
            this.btn31 = new System.Windows.Forms.Button();
            this.btn32 = new System.Windows.Forms.Button();
            this.ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonClose});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(970, 25);
            this.toolStrip1.TabIndex = 41;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.ReportViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 527);
            this.panel1.TabIndex = 43;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btn11, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn12, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn21, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn22, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn31, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn32, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 150);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // btn11
            // 
            this.btn11.BackColor = System.Drawing.Color.White;
            this.btn11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btn11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn11.Location = new System.Drawing.Point(3, 3);
            this.btn11.Name = "btn11";
            this.btn11.Size = new System.Drawing.Size(69, 44);
            this.btn11.TabIndex = 0;
            this.btn11.UseVisualStyleBackColor = false;
            this.btn11.Click += new System.EventHandler(this.btn11_Click);
            // 
            // btn12
            // 
            this.btn12.BackColor = System.Drawing.Color.White;
            this.btn12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btn12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn12.Location = new System.Drawing.Point(78, 3);
            this.btn12.Name = "btn12";
            this.btn12.Size = new System.Drawing.Size(69, 44);
            this.btn12.TabIndex = 1;
            this.btn12.UseVisualStyleBackColor = false;
            this.btn12.Click += new System.EventHandler(this.btn12_Click);
            // 
            // btn21
            // 
            this.btn21.BackColor = System.Drawing.Color.White;
            this.btn21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn21.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btn21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn21.Location = new System.Drawing.Point(3, 53);
            this.btn21.Name = "btn21";
            this.btn21.Size = new System.Drawing.Size(69, 44);
            this.btn21.TabIndex = 2;
            this.btn21.UseVisualStyleBackColor = false;
            this.btn21.Click += new System.EventHandler(this.btn21_Click);
            // 
            // btn22
            // 
            this.btn22.BackColor = System.Drawing.Color.White;
            this.btn22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn22.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btn22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn22.Location = new System.Drawing.Point(78, 53);
            this.btn22.Name = "btn22";
            this.btn22.Size = new System.Drawing.Size(69, 44);
            this.btn22.TabIndex = 3;
            this.btn22.UseVisualStyleBackColor = false;
            this.btn22.Click += new System.EventHandler(this.btn22_Click);
            // 
            // btn31
            // 
            this.btn31.BackColor = System.Drawing.Color.White;
            this.btn31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn31.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btn31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn31.Location = new System.Drawing.Point(3, 103);
            this.btn31.Name = "btn31";
            this.btn31.Size = new System.Drawing.Size(69, 44);
            this.btn31.TabIndex = 4;
            this.btn31.UseVisualStyleBackColor = false;
            this.btn31.Click += new System.EventHandler(this.btn31_Click);
            // 
            // btn32
            // 
            this.btn32.BackColor = System.Drawing.Color.White;
            this.btn32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn32.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn32.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btn32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn32.Location = new System.Drawing.Point(78, 103);
            this.btn32.Name = "btn32";
            this.btn32.Size = new System.Drawing.Size(69, 44);
            this.btn32.TabIndex = 5;
            this.btn32.UseVisualStyleBackColor = false;
            this.btn32.Click += new System.EventHandler(this.btn32_Click);
            // 
            // ReportViewer
            // 
            this.ReportViewer.ActiveViewIndex = -1;
            this.ReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportViewer.AutoScroll = true;
            this.ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewer.DisplayGroupTree = false;
            this.ReportViewer.Location = new System.Drawing.Point(178, 0);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.SelectionFormula = "";
            this.ReportViewer.ShowGotoPageButton = false;
            this.ReportViewer.ShowGroupTreeButton = false;
            this.ReportViewer.ShowRefreshButton = false;
            this.ReportViewer.ShowTextSearchButton = false;
            this.ReportViewer.ShowZoomButton = false;
            this.ReportViewer.Size = new System.Drawing.Size(789, 527);
            this.ReportViewer.TabIndex = 43;
            this.ReportViewer.ViewTimeSelectionFormula = "";
            // 
            // LabelValidity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 552);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LabelValidity";
            this.Text = "LabelValidity";
            this.Load += new System.EventHandler(this.LabelValidity_Load);
            this.Click += new System.EventHandler(this.LabelValidity_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn11;
        private System.Windows.Forms.Button btn12;
        private System.Windows.Forms.Button btn21;
        private System.Windows.Forms.Button btn22;
        private System.Windows.Forms.Button btn31;
        private System.Windows.Forms.Button btn32;


    }
}