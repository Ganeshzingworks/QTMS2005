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
    public partial class FrmLineValidationMasterHistory : Form
    {
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        LayoutLineValidationTransaction_Class LayoutLineValidationTransaction_Class_Obj = new LayoutLineValidationTransaction_Class();
        List<LayoutLineValidationTransaction_Class> ListLayoutLineValidationTransaction_Class = new List<LayoutLineValidationTransaction_Class>();
        public FrmLineValidationMasterHistory()
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

        private void FrmLineValidationMasterHistory_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                Bind_LineDescription();
                LayoutLineValidationTransaction_Class_Obj.loginuser = FrmMain.LoginID;
                Painter.Paint(this);
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
            if (cbLineDescription.SelectedIndex > 0)
                BindLineDescriptionTransactionGrid();
            else
                BindLineDescriptionTransactionDefault();
        }

        private void BindLineDescriptionTransaction()
        {
            ListLayoutLineValidationTransaction_Class = new List<LayoutLineValidationTransaction_Class>();
            DataSet ds = LayoutLineValidationTransaction_Class_Obj.Select_LayoutLineTransactionMasterByLineDescriptionId(Convert.ToInt64(cbLineDescription.SelectedValue));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int index = 1;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        LayoutLineValidationTransaction_Class Obj = new LayoutLineValidationTransaction_Class();
                        Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                        Obj.minValue = Convert.ToString(item["MinVal"]);
                        Obj.maxValue = Convert.ToString(item["MaxVal"]);
                        Obj.value = Convert.ToString(item["Value"]);
                        Obj.name = Convert.ToString(item["Name"]);
                        Obj.parameter = Convert.ToString(item["Parameter"]);
                        Obj.id = Convert.ToInt64(item["Id"]);
                        Obj.validFrom = Convert.ToDateTime(item["ValidFrom"]);
                        Obj.validTo = Convert.ToDateTime(item["ValidTo"]);
                        index++;
                        ListLayoutLineValidationTransaction_Class.Add(Obj);
                    }
                }
                else
                    ResetDescriptionTransaction();
            }
            else
                ResetDescriptionTransaction();
        }

        private void ResetDescriptionTransaction()
        {
            EmptyTextBoxes(panelFill);
            ResetDtp();
        }

        private void ResetDtp()
        {
        }

        public static void EmptyTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
            }
        }

        private void BindLineDescriptionTransactionGrid()
        {
            DataSet ds = LayoutLineValidationTransaction_Class_Obj.SelectAll_LayoutLineTransactionMasterByLineDescriptionId(Convert.ToInt64(cbLineDescription.SelectedValue));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvLineDescriptionTransaction.DataSource = null;
                    dgvLineDescriptionTransaction.Rows.Clear();
                    int serialno = 1;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        dr1.CreateCells(dgvLineDescriptionTransaction);  //
                        dr1.Cells[0].Value = serialno;
                        dr1.Cells[1].Value = Convert.ToString(item["Name"]);
                        dr1.Cells[2].Value = Convert.ToString(item["Parameter"]);
                        dr1.Cells[3].Value = Convert.ToString(item["MinVal"]);
                        dr1.Cells[4].Value = Convert.ToString(item["MaxVal"]);
                        dr1.Cells[5].Value = Convert.ToString(item["Value"]);
                        dr1.Cells[6].Value = Convert.ToString(item["ValidFrom"]) != string.Empty ? Convert.ToDateTime(item["ValidFrom"]).ToString("dd-MMM-yyyy") : "";
                        dr1.Cells[7].Value = Convert.ToString(item["ValidTo"]) != string.Empty ? Convert.ToDateTime(item["ValidTo"]).ToString("dd-MMM-yyyy") : "";
                        dr1.Cells[8].Value = Convert.ToString(item["Id"]);
                        dr1.Cells[9].Value = Convert.ToString(item["ValidFrom"]);
                        serialno++;
                        dgvLineDescriptionTransaction.Rows.Add(dr1);
                    }
                }
                else
                    BindLineDescriptionTransactionDefault();
            }
            else
                BindLineDescriptionTransactionDefault();
        }

        private void BindLineDescriptionTransactionDefault()
        {
            dgvLineDescriptionTransaction.DataSource = null;
            dgvLineDescriptionTransaction.Rows.Clear();
            dgvLineDescriptionTransaction.AutoGenerateColumns = false;
            MessageBox.Show("Record not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dgvLineDescriptionTransaction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private static FrmLineValidationMasterHistory frm = null;
        public static FrmLineValidationMasterHistory GetInstance()
        {
            if (frm == null)
            {
                frm = new FrmLineValidationMasterHistory();
            }
            return frm;
        }
    }
}
