using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade.Transactions;

namespace QTMS.Reports_Forms
{
    public partial class FrmReagentPrintLabel : Form
    {
        public string rptName;
        public long transid;
        public DataTable dt = new DataTable();

        public FrmReagentPrintLabel()
        {
            InitializeComponent();
        }

        public FrmReagentPrintLabel(string RptName,long TransID )
        {
            this.rptName = RptName;
            this.transid = TransID;  
            InitializeComponent();
        }

        private void FrmReagentPrintLabel_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                toolStrip1.Items.Add(rptName);
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

                Reports.ReagentLabel_Report ReagentLabel = new QTMS.Reports.ReagentLabel_Report();

                DataSet Ds = new ReagentTransaction_Class().ReagentPrintLabel_Report(transid);

                if (Ds.Tables[0].Rows.Count > 0)
                {
                    ReagentLabel.SetDataSource(Ds.Tables[0]);
                    ReportViewer.ReportSource = ReagentLabel;
                    ReportViewer.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}