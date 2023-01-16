using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QTMS.Forms
{
    public partial class FrmLineOEESetting : Form
    {
        public FrmLineOEESetting()
        {
            InitializeComponent();
        }
        BusinessFacade.Transactions.LineOEETransaction LineOEETransaction_Obj = new BusinessFacade.Transactions.LineOEETransaction();
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtMesStd.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Value.");
                txtMesStd.Focus();
                return;
            }

            LineOEETransaction_Obj.MESSTDTIME = Convert.ToDouble(txtMesStd.Text.Trim());
            LineOEETransaction_Obj.FLAG = "Save";
            LineOEETransaction_Obj.Insert_LineOEE_Setting();
        }

        private void FrmLineOEESetting_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = LineOEETransaction_Obj.Select_LineOEE_Setting();
            if (dt.Rows.Count > 0)
            {
                txtMesStd.Text = dt.Rows[0][0].ToString();

                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    dgLineOEE.Rows.Add();
                //    dgLineOEE["ActivityName", i].Value = Convert.ToString(dt.Rows[i]["ActivityName"]);
                //    dgLineOEE["LineActivityID", i].Value = Convert.ToString(dt.Rows[i]["LineActivityID"]);
                //}
            }
        }

        private void txtMesStd_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only 0-9 and dot(.) allowed
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }      
        }
    }
}