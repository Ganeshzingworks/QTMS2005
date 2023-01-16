using BusinessFacade;
using QTMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QTMS.LineValidation
{
    public partial class FrmLineTransactionRejectionReport : Form
    {
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        LineTransactionRejectionMaster_Class LineTransactionRejectionMaster_Class_Obj = new LineTransactionRejectionMaster_Class();
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        public FrmLineTransactionRejectionReport()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLineTransactionHistory_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                Painter.Paint(this);
                Bind_LineDescription();
                dtpFromDate.Value = dtpToDate.Value = DateTime.Now;
                dtpFromDate.Checked = dtpToDate.Checked = false;
                LineTransactionRejectionMaster_Class_Obj.loginuser = FrmMain.LoginID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void Bind_LineDescription()
        {
            try
            {
                DataSet ds = LayoutLineMaster_Class_Obj.Select_LineMaster();
                DataRow dr = ds.Tables[0].NewRow();
                dr["LNo"] = "0";
                dr["LineDesc"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cbLineDescription.DataSource = ds.Tables[0];
                cbLineDescription.DisplayMember = "LineDesc";
                cbLineDescription.ValueMember = "LNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbLineDescription_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BindLineRejectionGrid()
        {
            if (dtpFromDate.Checked == true)
            {
                Report_Class_Obj.fromDate = dtpFromDate.Value;
            }
            else
            {
                Report_Class_Obj.fromDate = Convert.ToDateTime("1/1/1900 12:00:00 AM");
            }

            if (dtpToDate.Checked == true)
            {
                Report_Class_Obj.toDate = dtpToDate.Value;
            }
            else
            {
                Report_Class_Obj.toDate = Convert.ToDateTime("6/6/2079 11:59:59 PM");
            }
            DataSet ds = LineTransactionRejectionMaster_Class_Obj.Select_LayoutLineTransactionMasterByLineDescriptionIdDate(Convert.ToInt64(cbLineDescription.SelectedValue),Report_Class_Obj.fromDate, Report_Class_Obj.toDate); 
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvLineRejection.DataSource = null;
                    dgvLineRejection.Rows.Clear();
                    int serialno = 1;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        dr1.CreateCells(dgvLineRejection);  //
                        dr1.Cells[0].Value = serialno;
                        dr1.Cells[1].Value = Convert.ToString(item["LineDescriptionName"]);
                        dr1.Cells[2].Value = Convert.ToString(item["RejectionReason"]).Replace("<html><body>", "").Replace("</body></html>", "");
                        dr1.Cells[3].Value = Convert.ToString(item["RCA"]);
                        dr1.Cells[4].Value = Convert.ToString(item["Id"]);
                        dr1.Cells[5].Value = "View";
                        serialno++;
                        dgvLineRejection.Rows.Add(dr1);
                    }
                }
                else
                    BindLineRejectionGridDefault();
            }
            else
                BindLineRejectionGridDefault();
        }

        private void BindLineRejectionGridDefault()
        {
            dgvLineRejection.DataSource = null;
            dgvLineRejection.Rows.Clear();
            MessageBox.Show("Record not exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void dgvLineRejection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                long id = Convert.ToInt64(dgvLineRejection.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                if (DialogResult.OK == new FrmLineTransactionRejectionMaster(id,0).ShowDialog())
                {

                }
            }
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLineDescription.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select line discription", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
                {
                    MessageBox.Show("Please select valid from date to date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    BindLineRejectionGrid();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnAddRejection_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new FrmLineTransactionRejectionMaster(0,0).ShowDialog())
            {
                //FrmLineTransactionRejectionMaster frm = new FrmLineTransactionRejectionMaster(0);
                //frm.Show();
            }

            //Forms.LineValidation.FrmMOMMaster frm = new Forms.LineValidation.FrmMOMMaster();
            //frm.Show();
        }

        private static FrmLineTransactionRejectionReport frm = null;
        public static FrmLineTransactionRejectionReport GetInstance()
        {
            if (frm == null)
            {
                frm = new FrmLineTransactionRejectionReport();
            }
            return frm;
        }
    }
}
