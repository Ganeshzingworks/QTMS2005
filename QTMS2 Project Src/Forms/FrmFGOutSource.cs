using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmFGOutSource : Form
    {
        public FrmFGOutSource()
        {
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.FGOutSource_Class FGOutSource_Class_Obj = new BusinessFacade.FGOutSource_Class();
        # endregion
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFGOutSource_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);
            btnSearch.Focus();

            dtpFromDate.Value = dtpToDate.Value = Comman_Class_Obj.Select_ServerDate();

        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            FrmFGOutSourceAddNew fmPack = new FrmFGOutSourceAddNew(0);
            fmPack.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

            String fromdate = Convert.ToDateTime(dtpFromDate.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");
            FGOutSource_Class_Obj._fromdate = fromdate;

            String todate = Convert.ToDateTime(dtpToDate.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");
            FGOutSource_Class_Obj._todate = todate;

            DataSet Ds = new DataSet();
            Ds = FGOutSource_Class_Obj.Select_tblOutSourceFG();
            dgv.AutoGenerateColumns = false;
            //if (Ds.Tables[0].Rows.Count > 0)
            //{
            dgv.DataSource = Ds.Tables[0];
            //}
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            dtpFromDate.Value = dtpToDate.Value = Comman_Class_Obj.Select_ServerDate();
            dgv.DataSource = null;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string id = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (e.ColumnIndex == 4)//Edit
                    {
                        FrmFGOutSourceAddNew fmPack = new FrmFGOutSourceAddNew(Convert.ToInt64(id));
                        fmPack.ShowDialog();
                    }
                    if (e.ColumnIndex == 5)//Delete
                    {
                        FGOutSource_Class_Obj._OFGID = Convert.ToInt64(id);
                        FGOutSource_Class_Obj.Delete_tblOutSourceFG();
                        dgv.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}