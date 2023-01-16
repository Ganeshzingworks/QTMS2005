using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QTMS.Tools;


namespace QTMS.Reports_Forms
{
    public partial class FrmRetainerLabel : Form
    {
        public FrmRetainerLabel(DataTable dt)
        {
            this.dt = dt;
            InitializeComponent();
        }

        DataTable dt;
        //Reports.RetainerLabel_A4 rpt = new QTMS.Reports.RetainerLabel_A4();
        Reports.RMRetainerSafetySymbol rpt = new QTMS.Reports.RMRetainerSafetySymbol();
        private void FrmRetainerLabel_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);            

            Display(11);
        }

        private void Display(int loc)
        {
            ParameterFields param1Fields = new ParameterFields();
            ParameterField Location = new ParameterField();
            ParameterDiscreteValue LocationDescrete = new ParameterDiscreteValue();
            Location.Name = "Location";
            LocationDescrete.Value = loc;
            Location.CurrentValues.Add(LocationDescrete);

            param1Fields.Add(Location);
            ReportViewer.ParameterFieldInfo = param1Fields;

            rpt.SetDataSource(dt);
            ReportViewer.ReportSource = rpt;
            ReportViewer.Show();
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            Display(11);
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            Display(12);
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            Display(21);
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            Display(22);
        }

        private void btn31_Click(object sender, EventArgs e)
        {
            Display(31);
        }

        private void btn32_Click(object sender, EventArgs e)
        {
            Display(32);
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}