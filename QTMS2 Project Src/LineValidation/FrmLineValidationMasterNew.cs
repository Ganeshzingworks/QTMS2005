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
    public partial class FrmLineValidationMasterNew : Form
    {
        private DateTimePicker cellDateTimePicker = new DateTimePicker();
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        LayoutLineValidationMaster_Class LayoutLineValidationMaster_Class_Obj = new LayoutLineValidationMaster_Class();
        List<LayoutLineValidationMaster_Class> ListLayoutLineValidationMaster_Class = new List<LayoutLineValidationMaster_Class>();
        public FrmLineValidationMasterNew()
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

        private void FrmLineValidationMasterNew_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                this.cellDateTimePicker.CustomFormat = "dd-MMM-yyyy";
                this.cellDateTimePicker.Format = DateTimePickerFormat.Custom;
                LayoutLineValidationMaster_Class_Obj.loginuser = FrmMain.LoginID;
                BindLineTransactionMaster(); 
                Painter.Paint(this);
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        private void BindLineTransactionMaster()
        { 
            ListLayoutLineValidationMaster_Class = new List<LayoutLineValidationMaster_Class>();
            DataSet ds = LayoutLineValidationMaster_Class_Obj.Select_LayoutLineValidationMaster();
            if (ds.Tables.Count > 0) 
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int index = 1;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        LayoutLineValidationMaster_Class Obj = new LayoutLineValidationMaster_Class();
                        if (index == 1)
                        {
                            txtSTCMin.Text = Convert.ToString(item["MinVal"]);
                            lblCpKSTC.Text = txtSTCMin.Text;
                        }
                        else if (index == 2)
                        {
                            txtSTDMin.Text = Convert.ToString(item["MinVal"]);
                            lblCpKSTD.Text = txtSTDMin.Text; 
                        }
                        else if (index == 3)
                        {
                            txtLTCMin.Text = Convert.ToString(item["MinVal"]);
                            lblPpKLTC.Text = txtLTCMin.Text;
                        }
                        else if (index == 4)
                        {
                            txtLTDMin.Text = Convert.ToString(item["MinVal"]);
                            lblPpKLTD.Text = txtLTDMin.Text;
                        }
                        else
                        {
                            MessageBox.Show("getting wrong", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Obj.validTo = Convert.ToDateTime(item["ValidFrom"]);
                        Obj.validTo = Convert.ToDateTime(item["ValidTo"]);

                        Obj.minValue = Convert.ToString(item["MinVal"]);
                        Obj.maxValue = Convert.ToString(item["MaxVal"]);
                        Obj.value = Convert.ToString(item["Value"]);
                        Obj.name = Convert.ToString(item["Name"]);
                        Obj.parameter = Convert.ToString(item["Parameter"]);
                        Obj.id = Convert.ToInt64(item["Id"]);
                        Obj.validFrom = Convert.ToDateTime(item["ValidFrom"]);

                        index++;
                        ListLayoutLineValidationMaster_Class.Add(Obj);
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

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private bool IsValid()
        {
            if (string.IsNullOrEmpty(txtSTCMin.Text.Trim()))
            {
                MessageBox.Show("Please enter min value of short term colorant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSTCMin.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSTDMin.Text.Trim()))
            {
                MessageBox.Show("Please enter min value of short term developer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSTDMin.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLTCMin.Text.Trim()))
            {
                MessageBox.Show("Please enter min value of long term colorant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLTCMin.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLTDMin.Text.Trim()))
            {
                MessageBox.Show("Please enter min value of long term developer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLTDMin.Focus();
                return false;
            }
            return true;
        }

        private void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            cellDateTimePicker.Visible = false;
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {

            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
        }

        private static FrmLineValidationMasterNew frm = null;
        public static FrmLineValidationMasterNew GetInstance()
        {
            if (frm == null)
            {
                frm = new FrmLineValidationMasterNew();
            }
            return frm;
        }

        private void txtSTCMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSTCMin.Text.Trim()))
                {
                    Convert.ToDecimal(txtSTCMin.Text);
                    lblCpKSTC.Text = txtSTCMin.Text.Trim();
                }
                else
                {
                    lblCpKSTC.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSTCMin.Text = string.Empty;
                txtSTCMin.Focus();
                return;
            }
        }

        private void txtSTCMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSTDMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSTDMin.Text.Trim()))
                {
                    Convert.ToDecimal(txtSTDMin.Text);
                    lblCpKSTD.Text = txtSTDMin.Text.Trim();
                }
                else
                {
                    lblCpKSTD.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(txtSTCMin.Text.Trim()))
                    MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSTDMin.Text = string.Empty;
                txtSTDMin.Focus();
                return;
            }
        }

        private void txtSTDMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLTCMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLTCMin.Text.Trim()))
                {
                    Convert.ToDecimal(txtLTCMin.Text);
                    lblPpKLTC.Text = txtLTCMin.Text.Trim();
                }
                else
                {
                    lblPpKLTC.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLTCMin.Text = string.Empty;
                txtLTCMin.Focus();
                return;
            }
        }

        private void txtLTCMax_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLTDMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLTDMin.Text.Trim()))
                {
                    Convert.ToDecimal(txtLTDMin.Text);
                    lblPpKLTD.Text = txtLTDMin.Text.Trim();
                }
                else
                {
                    lblPpKLTD.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLTDMin.Text = string.Empty;
                txtLTDMin.Focus();
                return;
            }
        }

        private void txtLTDMax_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
