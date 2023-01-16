namespace QTMS.Reports_Forms
{
    partial class Method_Of_Manufature
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
            this.rptview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.viewrpt = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // rptview
            // 
            this.rptview.ActiveViewIndex = -1;
            this.rptview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptview.DisplayGroupTree = false;
            this.rptview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptview.Location = new System.Drawing.Point(0, 0);
            this.rptview.Name = "rptview";
            this.rptview.SelectionFormula = "";
            this.rptview.Size = new System.Drawing.Size(1000, 572);
            this.rptview.TabIndex = 0;
            this.rptview.ViewTimeSelectionFormula = "";
            // 
            // viewrpt
            // 
            this.viewrpt.ActiveViewIndex = -1;
            this.viewrpt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewrpt.DisplayGroupTree = false;
            this.viewrpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewrpt.Location = new System.Drawing.Point(0, 0);
            this.viewrpt.Name = "viewrpt";
            this.viewrpt.SelectionFormula = "";
            this.viewrpt.Size = new System.Drawing.Size(873, 266);
            this.viewrpt.TabIndex = 0;
            this.viewrpt.ViewTimeSelectionFormula = "";
            this.viewrpt.Load += new System.EventHandler(this.viewrpt_Load);
            // 
            // Method_Of_Manufature
            // 
            this.ClientSize = new System.Drawing.Size(873, 266);
            this.Controls.Add(this.viewrpt);
            this.Name = "Method_Of_Manufature";
            this.Load += new System.EventHandler(this.Method_Of_Manufature_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptview;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewrpt;
    }
}