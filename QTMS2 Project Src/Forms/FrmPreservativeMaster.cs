using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmPreservativeMaster : Form
    {
        DataSet dsList = new DataSet();
        public FrmPreservativeMaster()
        {
            InitializeComponent();
        }
        #region Varibles
        PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new PackingFamilyMaster_Class();
        PreservetiveMaster_Class PreservetiveMaster_Class_Obj = new PreservetiveMaster_Class();
        bool Modify = false;
        #endregion

        private static FrmPreservativeMaster frmPreservativeMaster_Obj = null;
        public static FrmPreservativeMaster GetInstance()
        {
            if (frmPreservativeMaster_Obj == null)
            {
                frmPreservativeMaster_Obj = new FrmPreservativeMaster();
            }
            return frmPreservativeMaster_Obj;
        }

        private void FrmPackingFamilyMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);
            txtTechnicalFamily.Focus();
            Bind_List();           
        }
        public void Bind_List()
        {
            dsList = PreservetiveMaster_Class_Obj.STP_Select_tblPreservativeMaster();
            List.DataSource = dsList.Tables[0];
            List.DisplayMember = "PresType";
            List.ValueMember = "Prsno";            
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTechnicalFamily.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Preservative Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    txtTechnicalFamily.Focus();
                    return;
                }

                if (txtPresFormula.Text != "" && EndsWithOperand(txtPresFormula.Text.Trim()) == true)
                {
                    MessageBox.Show("Check formula for last operand", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPresFormula.Focus();
                    return;
                }

                if (Modify == false)
                {
                    PreservetiveMaster_Class_Obj.prestype = txtTechnicalFamily.Text.Trim();
                    PreservetiveMaster_Class_Obj.presformula = txtPresFormula.Text.Trim();
                    bool b = PreservetiveMaster_Class_Obj.Insert_tblPreservativeMaster();
                    if (b == true)
                    {   
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                    }
                }
                else
                {
                    PreservetiveMaster_Class_Obj.prestype = txtTechnicalFamily.Text.Trim();
                    PreservetiveMaster_Class_Obj.presformula = txtPresFormula.Text.Trim();
                    PreservetiveMaster_Class_Obj.prsno = Convert.ToInt32(List.SelectedValue.ToString());
                    if (PreservetiveMaster_Class_Obj.prsno == 0)
                    {
                        MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    bool b = PreservetiveMaster_Class_Obj.Update_tblPreservativeMaster();
                    if (b == true)
                    {
                        MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                    }                    
                }
            }
            catch 
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTechnicalFamily.Focus();
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            List.Enabled = true;
            Modify = true;
            List_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = Convert.ToString(List.Text);
                Modify = true;
                DataSet ds = new DataSet();
                PreservetiveMaster_Class_Obj.prsno = Convert.ToInt32(List.SelectedValue.ToString());
                ds = PreservetiveMaster_Class_Obj.Select_tblPreservativeMaster_Prsno();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTechnicalFamily.Text = List.Text;

                    if (ds.Tables[0].Rows[0]["PresFormula"] is System.DBNull)
                    {
                        txtPresFormula.Text = "";
                    }
                    else
                    {
                        txtPresFormula.Text = ds.Tables[0].Rows[0]["PresFormula"].ToString();
                    }
                }
                BtnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
			{
                PreservetiveMaster_Class_Obj.prsno = Convert.ToInt32(List.SelectedValue.ToString());

                if (PreservetiveMaster_Class_Obj.prsno > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = PreservetiveMaster_Class_Obj.Delete_tblPreservativeMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnReset_Click(sender, e);
                        }
                    }
                }
            }
            catch 
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry You Can't delete this record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTechnicalFamily.Focus();
                Modify = false;
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtTechnicalFamily.Text = "";
            txtPresFormula.Text = "";
            txtTechnicalFamily.Focus();
            Modify = false;
            PreservetiveMaster_Class_Obj.prsno = 0;
            BtnDelete.Enabled = false;
            Bind_List();
        }

        private void txtTechnicalFamily_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtTechnicalFamily.Text = textInfo.ToTitleCase(txtTechnicalFamily.Text);
        }

        private void txtConcentrate_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;         
        }

        private bool EndsWithOperand(string s)
        {
            if (s.EndsWith("+") || s.EndsWith("-") || s.EndsWith("*") || s.EndsWith("/") || s == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool EndsWithDigit(string s)
        {
            if (s.EndsWith("0") || s.EndsWith("1") || s.EndsWith("2") || s.EndsWith("3") || s.EndsWith("4") || s.EndsWith("5") || s.EndsWith("6") || s.EndsWith("7") || s.EndsWith("8") || s.EndsWith("9"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) == false)
            {
                txtPresFormula.Text = txtPresFormula.Text + '+';
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) == false)
            {
                txtPresFormula.Text = txtPresFormula.Text + '-';
            }
        }

        private void btnInto_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) == false)
            {
                txtPresFormula.Text = txtPresFormula.Text + '*';
            }
        }

        private void btnBy_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) == false)
            {
                txtPresFormula.Text = txtPresFormula.Text + '/';
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtPresFormula.Text != "")
            {
                if (EndsWithOperand(txtPresFormula.Text) == true)
                {
                    txtPresFormula.Text = txtPresFormula.Text.Substring(0, txtPresFormula.Text.Length - 1);
                }
                else if (EndsWithDigit(txtPresFormula.Text) == true)
                {
                    txtPresFormula.Text = txtPresFormula.Text.Substring(0, txtPresFormula.Text.Length - 1);
                }
                else
                {
                    txtPresFormula.Text = txtPresFormula.Text.Substring(0, txtPresFormula.Text.Length - 2);
                }                
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) || EndsWithDigit(txtPresFormula.Text))
            {
                txtPresFormula.Text = txtPresFormula.Text + '0';
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) || EndsWithDigit(txtPresFormula.Text))
            {
                txtPresFormula.Text = txtPresFormula.Text + '1';
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) || EndsWithDigit(txtPresFormula.Text))
            {
                txtPresFormula.Text = txtPresFormula.Text + '2';
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) || EndsWithDigit(txtPresFormula.Text))
            {
                txtPresFormula.Text = txtPresFormula.Text + '3';
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) || EndsWithDigit(txtPresFormula.Text))
            {
                txtPresFormula.Text = txtPresFormula.Text + '4';
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) || EndsWithDigit(txtPresFormula.Text))
            {
                txtPresFormula.Text = txtPresFormula.Text + '5';
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) || EndsWithDigit(txtPresFormula.Text))
            {
                txtPresFormula.Text = txtPresFormula.Text + '6';
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) || EndsWithDigit(txtPresFormula.Text))
            {
                txtPresFormula.Text = txtPresFormula.Text + '7';
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) || EndsWithDigit(txtPresFormula.Text))
            {
                txtPresFormula.Text = txtPresFormula.Text + '8';
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) || EndsWithDigit(txtPresFormula.Text))
            {
                txtPresFormula.Text = txtPresFormula.Text + '9';
            }
        }

        private void btnWS_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) == true)
            {
                txtPresFormula.Text = txtPresFormula.Text + "WS";
            }
        }

        private void btnWR_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) == true)
            {
                txtPresFormula.Text = txtPresFormula.Text + "WR";
            }
        }

        private void btnVS_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) == true)
            {
                txtPresFormula.Text = txtPresFormula.Text + "VS";
            }
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) == true)
            {
                txtPresFormula.Text = txtPresFormula.Text + "AC";
            }
        }

        private void btnAS_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) == true)
            {
                txtPresFormula.Text = txtPresFormula.Text + "AS";
            }
        }

        private void btnAR_Click(object sender, EventArgs e)
        {
            if (EndsWithOperand(txtPresFormula.Text) == true)
            {
                txtPresFormula.Text = txtPresFormula.Text + "AR";
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "PresType like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "PresType";
            List.ValueMember = "Prsno";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    Modify = true;
                    DataSet ds = new DataSet();
                    PreservetiveMaster_Class_Obj.prsno = Convert.ToInt32(List.SelectedValue.ToString());
                    ds = PreservetiveMaster_Class_Obj.Select_tblPreservativeMaster_Prsno();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtTechnicalFamily.Text = List.Text;

                        if (ds.Tables[0].Rows[0]["PresFormula"] is System.DBNull)
                        {
                            txtPresFormula.Text = "";
                        }
                        else
                        {
                            txtPresFormula.Text = ds.Tables[0].Rows[0]["PresFormula"].ToString();
                        }
                    }
                    BtnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down)
                {
                    List.Select();
                    List.SelectedIndex = List.SelectedIndex + 1;
                }
            }
            catch (ArgumentOutOfRangeException exAOR)
            {

                MessageBox.Show("This is last item", "QTMS");
                //   MessageBox.Show("This is last item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Up)
                {
                    List.Select();
                    List.SelectedIndex = List.SelectedIndex - 1;
                }
            }
            catch (ArgumentOutOfRangeException exAOR)
            {
                //  MessageBox.Show("This is last item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("This is last item", "QTMS");
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void List_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    Modify = true;
                    DataSet ds = new DataSet();
                    PreservetiveMaster_Class_Obj.prsno = Convert.ToInt32(List.SelectedValue.ToString());
                    ds = PreservetiveMaster_Class_Obj.Select_tblPreservativeMaster_Prsno();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtTechnicalFamily.Text = List.Text;

                        if (ds.Tables[0].Rows[0]["PresFormula"] is System.DBNull)
                        {
                            txtPresFormula.Text = "";
                        }
                        else
                        {
                            txtPresFormula.Text = ds.Tables[0].Rows[0]["PresFormula"].ToString();
                        }
                    }
                    BtnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                PreservetiveMaster_Class objPreservetiveMaster_Class = new PreservetiveMaster_Class();
                DataSet ds = new DataSet();
                ds = objPreservetiveMaster_Class.Select_All_Record_tblPreservativeMaster();

                ExportToExcel objExport = new ExportToExcel();
                objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
       
       
    }
}