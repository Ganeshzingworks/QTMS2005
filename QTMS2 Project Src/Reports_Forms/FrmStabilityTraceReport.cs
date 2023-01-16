using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;
using System.Text.RegularExpressions;

namespace QTMS.Reports_Forms
{
    public partial class FrmStabilityTraceReport : Form
    {
        public FrmStabilityTraceReport()
        {
            InitializeComponent();
            //this.rptName = "Stability Trace Report Email";
        }

        SatbilityTest_Class SatbilityTest_Class_Obj = new BusinessFacade.SatbilityTest_Class();

        private void FrmStabilityTraceReport_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            Bind_FormulaNo();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Bind_FormulaNo()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = SatbilityTest_Class_Obj.SELECT_StabilityTrace_BindFormula();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FMID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbFormulaNo.DataSource = ds.Tables[0];
            cmbFormulaNo.DisplayMember = "FormulaNo";
            cmbFormulaNo.ValueMember = "FMID";
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            if (cmbFormulaNo.SelectedValue == null || cmbFormulaNo.Text == "--Select--")
            {
                MessageBox.Show("Please Select Formula No..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbFormulaNo.Focus();
                return;
            }
            if (txtemailids.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please add email id", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailid.Focus();
                return;
            }

            try
            {
                int fmid = Convert.ToInt32(cmbFormulaNo.SelectedValue);
                bool res = SatbilityTest_Class_Obj.Send_Email_StabilityTrace(fmid, txtemailids.Text.Trim());
                MessageBox.Show("Stability Trace report send Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtEmailid.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter email id", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailid.Focus();
                return;
            }
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            bool isValid = regex.IsMatch(txtEmailid.Text.Trim());
            if (!isValid)
            {
                //MessageBox.Show("Invalid Email.");
                MessageBox.Show("Invalid Email.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailid.Focus();
                return;
            }

            if (txtemailids.Text.Trim() == string.Empty)
                txtemailids.Text = txtEmailid.Text.Trim();
            else
                txtemailids.Text = txtemailids.Text.Trim() + "," + txtEmailid.Text.Trim();

            txtEmailid.Text = "";
        }
    }
}