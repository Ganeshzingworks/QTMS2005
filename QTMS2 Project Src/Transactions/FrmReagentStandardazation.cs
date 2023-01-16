using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade.Transactions;

namespace QTMS.Transactions
{
    public partial class FrmReagentStandardazation : Form
    {

        #region  Variables

        ReagentStandardization_Class ReagentStandardization_Class_obj = new ReagentStandardization_Class();

        #endregion

        public FrmReagentStandardazation()
        {
            InitializeComponent();
        }
        private static FrmReagentStandardazation FrmReagentStandardazation_Obj = null;
        internal static FrmReagentStandardazation GetInstance()
        {
            if (FrmReagentStandardazation_Obj == null)
            {
                FrmReagentStandardazation_Obj = new Transactions.FrmReagentStandardazation();
            }
            return FrmReagentStandardazation_Obj;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void FrmReagentMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);
            bind_RACode();

        }

        private void bind_RACode()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = ReagentStandardization_Class_obj.Select_RACode();
                dr = ds.Tables[0].NewRow();
                dr["RACode"] = "--Select--";
                dr["ReagentID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);


                cmbRACode.DataSource = ds.Tables[0];
                cmbRACode.DisplayMember = "RACode";
                cmbRACode.ValueMember = "ReagentID";


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPMExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblJar_Click(object sender, EventArgs e)
        {

        }

        private void cmbRACode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbRACode.SelectedValue != null && cmbRACode.SelectedValue.ToString() != "")
                {
                    ReagentStandardization_Class_obj.reagentid  = Convert.ToInt32(cmbRACode.SelectedValue.ToString());
                    DataSet ds = new DataSet();
                    DataRow dr;
                    ds = ReagentStandardization_Class_obj.Select_LotNo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dr = ds.Tables[0].NewRow();
                        dr["ReagentLotNo"] = "--Select--";
                        dr["ReagentTransID"] = "0";
                        ds.Tables[0].Rows.InsertAt(dr, 0);

                        cmbLot.DataSource = ds.Tables[0];
                        cmbLot.DisplayMember = "ReagentLotNo";
                        cmbLot.ValueMember = "ReagentTransID";

                     //   lblNormalityUnit.Text = ds.Tables[0].Rows[0]["NormalityUnit"].ToString();
 
                    }
                    else
                    {
                        //DataRow dr;
                        //dr = ds.Tables[0].NewRow();
                        //dr["ReagentLotNo"] = "--Select--";
                        //dr["ReagentTransID"] = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           // supplieradd = true;
            if (cmbRACode.SelectedValue == null || cmbRACode.Text == "--Select--")
            {
                MessageBox.Show("Select RACode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRACode.Focus();
                return;
            }
            if (cmbLot.SelectedValue == null || cmbLot.Text == "--Select--")
            {
                MessageBox.Show("Select Lot No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLot.Focus();
                return;

            }
            if (cmbJar.SelectedValue == null || cmbJar.Text == "--Select--")
            {
                MessageBox.Show("Select Bottle/Jar", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbJar.Focus();
                return;
            }
           
           
            if (dtpTransDate.Checked == false)
            {
                MessageBox.Show("Enter Standardazation Date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTransDate.Focus();
                return;

            }
           
            if (dtpValidityDate.Checked == false )
            {
                MessageBox.Show("Enter Validity Date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpValidityDate.Focus();
                return;

            }
            if (txtStdNormality.Text.Trim() == "")
            {
                MessageBox.Show("Enter Standard Normality", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStdNormality.Focus();
                return;

            }

            for (int i = 0; i < dgvReagentStd.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvReagentStd["ReagentBottleNo", i].Value.ToString()) == Convert.ToInt32(cmbJar.Text) )
                {
                //    MessageBox.Show("Duplicate Record");
                //    return;
                //}
                //else 
                //{
                    if (MessageBox.Show("This already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {

                        dgvReagentStd["ReagentID", i].Value = cmbRACode.SelectedValue.ToString();
                        dgvReagentStd["ReagentTransID", i].Value = cmbLot.SelectedValue.ToString();
                        dgvReagentStd["ReagentBottleNo", i].Value = cmbJar.Text;
                        dgvReagentStd["StdDate", i].Value = dtpTransDate.Text;
                        dgvReagentStd["NormalityUnit", i].Value = txtStdNormality.Text;
                        dgvReagentStd["ValidityDate", i].Value = dtpValidityDate.Text;

                    }
                    return;
                }
            }
            dgvReagentStd.Rows.Add();
            dgvReagentStd["ReagentID", dgvReagentStd.Rows.Count - 1].Value = cmbRACode.SelectedValue.ToString();
            dgvReagentStd["ReagentTransID", dgvReagentStd.Rows.Count - 1].Value = cmbLot.SelectedValue.ToString();
            dgvReagentStd["ReagentBottleNo", dgvReagentStd.Rows.Count - 1].Value = cmbJar.Text;
            dgvReagentStd["StdDate", dgvReagentStd.Rows.Count - 1].Value = dtpTransDate.Text;
            dgvReagentStd["NormalityUnit", dgvReagentStd.Rows.Count - 1].Value = txtStdNormality.Text;
            dgvReagentStd["ValidityDate", dgvReagentStd.Rows.Count - 1].Value = dtpValidityDate.Text;

            //reset
            BtnReset_Click(  sender,   e);
            
 
        }

        private void btnPMSave_Click(object sender, EventArgs e)
        {
            if (dgvReagentStd.Rows.Count<=0)
            {
                MessageBox.Show("Please add Bottle/Jar details to Standardise ! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ReagentStandardization_Class_obj.loginid = FrmMain.LoginID;
            bool status=false ;
            for (int i = 0; i < dgvReagentStd.Rows.Count; i++ )
            {
             
                    ReagentStandardization_Class_obj.reagentid = Convert.ToInt32(dgvReagentStd["ReagentID", i].Value.ToString());
                    ReagentStandardization_Class_obj.reagenttransid = Convert.ToInt32(dgvReagentStd["ReagentTransID", i].Value.ToString());
                    ReagentStandardization_Class_obj.reagentbottleno =Convert.ToInt32( dgvReagentStd["ReagentBottleNo", i].Value.ToString());
                    ReagentStandardization_Class_obj.stddate = Convert.ToDateTime (dgvReagentStd["StdDate", i].Value.ToString());
                    ReagentStandardization_Class_obj.normalityunit = Convert.ToInt32( dgvReagentStd["NormalityUnit", i].Value.ToString());
                    ReagentStandardization_Class_obj.validitydate = Convert.ToDateTime (dgvReagentStd["ValidityDate", i].Value.ToString());

                     status = ReagentStandardization_Class_obj.Insert_tblReagentStandardization();

                // update tblReagentBottle set its standardise bottle status =1
                   ReagentStandardization_Class_obj.Update_tblReagentBottle();

                

            }
                if(status==true )
                     {
                         MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         btnStdReset_Click(sender, e);
                     }
        }

        private void cmbLot_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbRACode.SelectedValue != null && cmbRACode.SelectedValue.ToString() != "")
                {
                    ReagentStandardization_Class_obj.reagenttransid = Convert.ToInt32(cmbLot.SelectedValue.ToString());
                    DataSet ds = new DataSet();
                  //  DataRow dr;
                    ds = ReagentStandardization_Class_obj.Select_BottleNos();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblNormalityUnit.Text = ds.Tables[0].Rows[0]["NormalityUnit"].ToString();
                        ReagentStandardization_Class_obj.receivedate = Convert.ToDateTime( ds.Tables[0].Rows[0]["ReceiveDate"]);

                        //dr = ds.Tables[0].NewRow();
                        //dr["BottleNo"] = "0";
                        //dr["ReagentBottleID"] = "0";
                        //ds.Tables[0].Rows.InsertAt(dr, 0);

                        cmbJar.DataSource = ds.Tables[0];
                        cmbJar.DisplayMember = "BottleNo";
                        cmbJar.ValueMember = "ReagentBottleID";


                    }
                    else
                    { 
                        ds =null;
                    cmbJar.DataSource = ds;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            bind_RACode();
            cmbLot.DataSource = null;
            cmbJar.DataSource = null;
            dtpTransDate.Text = "";
            dtpValidityDate.Text = "";
            txtStdNormality.Text = "";

        }

        private void btnStdReset_Click(object sender, EventArgs e)
        {

            bind_RACode();
            cmbLot.DataSource = null;
            cmbJar.DataSource = null;
            dtpTransDate.Text = "";
            dtpValidityDate.Text = "";
            txtStdNormality.Text = "";
            
            //DataSet ds = new DataSet();
            //ds = null;
             dgvReagentStd.Rows.Clear();
            
        }

        private void txtStdNormality_Leave(object sender, EventArgs e)
        {
            if (txtStdNormality.Text != "" && Convert.ToDouble(txtStdNormality.Text) > 10)
            {
                MessageBox.Show("Normality unit must be between 0 to 10", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtStdNormality_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                  e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
            //if (e.KeyChar ==46)
            //{
            //    e.Handled = false ;
            //}
        }

        private void dtpTransDate_Leave(object sender, EventArgs e)
        {
            if (dtpTransDate.Checked==true )
            {
                 // Standar. date should not be less than Receive Date and not greater than today
            if (ReagentStandardization_Class_obj.receivedate > Convert.ToDateTime(dtpTransDate.Text))
            {
                MessageBox.Show("Standardazation Date must be greater than '" + ReagentStandardization_Class_obj.receivedate.ToString("dd-MMM-yyyy") + "' (Receive Date)! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpTransDate.Checked = false;
                dtpTransDate.Focus();
               // return;
            }
            }
        }

        private void dtpValidityDate_Leave(object sender, EventArgs e)
        {
            if (dtpValidityDate.Checked ==true )
            {
                     // not greater than today
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(dtpValidityDate.Text);
                if ( DateTime.Now.Date >= dt  )
                {
                    MessageBox.Show("Validity Date must be greater than current date! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  dtpValidityDate.Checked = false;
                  dtpValidityDate.Focus();

                }
            }
        }
    }
}

 