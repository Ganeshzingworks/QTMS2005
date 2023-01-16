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
    public partial class FrmLineRejectionHistory : Form
    {
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        LineTransactionRejectionMaster_Class LineTransactionRejectionMaster_Class_Obj = new LineTransactionRejectionMaster_Class();
        private long discriptionId;

        public FrmLineRejectionHistory()
        {
            InitializeComponent();
        }

        public FrmLineRejectionHistory(long discriptionId)
        {
            InitializeComponent();
            this.discriptionId = discriptionId;
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
                if (this.discriptionId != 0)
                {
                    BindLineRejectionGrid();
                    cbLineDescription.SelectedValue = this.discriptionId;
                }
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
            DataSet ds = LineTransactionRejectionMaster_Class_Obj.Select_LayoutLineTransactionMasterByLineDescriptionId(this.discriptionId);
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
                        dr1.Cells[2].Value = Convert.ToString(item["RejectionDate"]);
                        dr1.Cells[3].Value = Convert.ToString(item["RejectionReason"]).Replace("<html><body>", "").Replace("</body></html>", "");
                        dr1.Cells[4].Value = Convert.ToString(item["RCA"]); 
                        dr1.Cells[5].Value = Convert.ToString(item["Id"]);
                        //dr1.Cells[6].Value = "View";
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
            
        }
    }
}
