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
    public partial class FrmReagentLabelReprint_Report : Form
    {
        public FrmReagentLabelReprint_Report()
        {
            InitializeComponent();
        }

        ReagentTransaction_Class ReagentTransaction_Class_obj = new ReagentTransaction_Class();
        private void FrmReagentLabelReprint_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_Details();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Bind_Details()
        {
            CmbDetails.BeginUpdate();
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                
                ds = ReagentTransaction_Class_obj.Select_ConsumptionReagentTransaction();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                CmbDetails.DataSource = ds.Tables[0];
                CmbDetails.DisplayMember = "Details";
                CmbDetails.ValueMember = "ReagentTransID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CmbDetails.EndUpdate();
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbDetails.SelectedValue == null || CmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Select Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbDetails.Focus();
                    return;
                }

                ReagentTransaction_Class_obj.reagenttransid = Convert.ToInt64(CmbDetails.SelectedValue);

                Reports.ReagentLabel_Report ReagentLabel = new QTMS.Reports.ReagentLabel_Report();

                DataSet Ds = new ReagentTransaction_Class().ReagentPrintLabel_Report(ReagentTransaction_Class_obj.reagenttransid);

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
    }
}