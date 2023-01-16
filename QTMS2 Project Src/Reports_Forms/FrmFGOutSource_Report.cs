using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;

namespace QTMS.Reports_Forms
{
    public partial class FrmFGOutSource_Report : Form
    {
        public FrmFGOutSource_Report()
        {
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.FGOutSource_Class FGOutSource_Class_Obj = new BusinessFacade.FGOutSource_Class();
        # endregion
        private void FrmFGOutSource_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);
            btnGenerateReport.Focus();

            dtpFromDate.Value = dtpToDate.Value = Comman_Class_Obj.Select_ServerDate();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataSet Ds = new DataSet();
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            dgv.AutoGenerateColumns = false;
            System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

            String fromdate = Convert.ToDateTime(dtpFromDate.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");
            FGOutSource_Class_Obj._fromdate = fromdate;

            String todate = Convert.ToDateTime(dtpToDate.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");
            FGOutSource_Class_Obj._todate = todate;

           
            Ds = FGOutSource_Class_Obj.Select_tblOutSourceFG_Report();
            dgv.AutoGenerateColumns = false;            
            dgv.DataSource = Ds.Tables[0];
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ExportToExcel objExport = new ExportToExcel();
                objExport.GenerateExcelFile(Ds.Tables[0]);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }
    }
}