using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;
using BusinessFacade.Transactions;

namespace QTMS.Transactions
{
    public partial class frmHPLCReferenceMgmt : Form
    {
        public frmHPLCReferenceMgmt()
        {
            InitializeComponent();
        }
        #region Variable
        PreservetiveMaster_Class PreservetiveMaster_Class_Obj = new PreservetiveMaster_Class();
        RSMgmtTransaction_Class RSMgmtTransaction_Class_obj = new RSMgmtTransaction_Class();
        HPLCRefMgmt_Class HPLCRefMgmt_Class_obj = new HPLCRefMgmt_Class();
        Comman_Class Comman_Class_Obj = new Comman_Class();
        DateTime currentDate;
        #endregion
        private static frmHPLCReferenceMgmt frmHPLCReferenceMgmt_Obj = null;
        public static frmHPLCReferenceMgmt GetInstance()
        {
            if (frmHPLCReferenceMgmt_Obj == null)
            {
                frmHPLCReferenceMgmt_Obj = new Transactions.frmHPLCReferenceMgmt();
            }
            return frmHPLCReferenceMgmt_Obj;
        }       

        public void Bind_RMCode()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = PreservetiveMaster_Class_Obj.STP_Select_tblPreservativeMaster();
           
                DataRow dr = ds.Tables[0].NewRow();
                dr["PresType"] = "--Select--";
                dr["Prsno"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbRMCode.DataSource = ds.Tables[0];
                    cmbRMCode.DisplayMember = "PresType";
                    cmbRMCode.ValueMember = "Prsno";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpDateOfPreparation.CustomFormat = " ";
            dtpValidityDate.CustomFormat = " ";
            cmbRMCode.SelectedValue = 0;
            dgHPLCRSMgmt.Rows.Clear();
        }

        private void frmHPLCReferenceMgmt_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_RMCode();            
            currentDate = Comman_Class_Obj.Select_ServerDate();
            //dtpValidityDate.Value = dtpDateOfPreparation.Value.AddDays(20);
            btnReset_Click(sender, e);
        }

        private void dtpDateOfPreparation_ValueChanged(object sender, EventArgs e)
        {
            dtpDateOfPreparation.CustomFormat = "dd-MMM-yyyy";
            dtpValidityDate.Value = dtpDateOfPreparation.Value.AddDays(20);
            DataTable dt = new DataTable();
            HPLCRefMgmt_Class_obj.prsno = Convert.ToInt64(cmbRMCode.SelectedValue);
            dt = HPLCRefMgmt_Class_obj.Select_tblHPLCRefMgmt();
            if (dt.Rows.Count <= 0)
            {
                dtpDateOfPreparation.Enabled = true;
                if (dtpDateOfPreparation.Value < Convert.ToDateTime(currentDate.ToShortDateString()).AddDays(-1))
                {
                    MessageBox.Show("Preparation date can't be less than yesterdays date, Please select todays or yesterdays date. ", "HPLC Reference", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpDateOfPreparation.CustomFormat = " ";
                    dtpValidityDate.CustomFormat = " ";
                    return;
                    //dtpDateOfPreparation.Value = currentDate;
                    //dtpDateOfPreparation.Focus();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRMCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void FillGrid()
        {
            try
            {
                dgHPLCRSMgmt.Rows.Clear();
                dtpDateOfPreparation.Value = currentDate;
                DataTable dt = new DataTable();
                HPLCRefMgmt_Class_obj.prsno = Convert.ToInt64(cmbRMCode.SelectedValue);
                dt = HPLCRefMgmt_Class_obj.Select_tblHPLCRefMgmt();

                foreach (DataRow dr in dt.Rows)
                {
                    dgHPLCRSMgmt.Rows.Add();
                    dgHPLCRSMgmt["HPLCRefID", dgHPLCRSMgmt.Rows.Count - 1].Value = Convert.ToString(dr["HPLCRefID"]);
                    dgHPLCRSMgmt["Prsno", dgHPLCRSMgmt.Rows.Count - 1].Value = Convert.ToString(dr["Prsno"]);
                    dgHPLCRSMgmt["PreservativeName", dgHPLCRSMgmt.Rows.Count - 1].Value = Convert.ToString(dr["PresType"]);
                    dgHPLCRSMgmt["DateOfPreparation", dgHPLCRSMgmt.Rows.Count - 1].Value = Convert.ToString(dr["DateOfPreparation"]);
                    dgHPLCRSMgmt["DateOfValidity", dgHPLCRSMgmt.Rows.Count - 1].Value = Convert.ToString(dr["DateOfValidity"]);
                    dgHPLCRSMgmt["LoginID", dgHPLCRSMgmt.Rows.Count - 1].Value = Convert.ToString(dr["LoginID"]);
                    
                    //dtpDateOfPreparation.Value = Convert.ToDateTime(dr["DateOfPreparation"]);
                    //dtpDateOfPreparation.Enabled = false;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    HPLCRefMgmt_Class_obj.dateOfPreparation = Convert.ToDateTime(dtpDateOfPreparation.Value.ToShortDateString());
                    HPLCRefMgmt_Class_obj.dateOfValidation = Convert.ToDateTime(dtpValidityDate.Value.ToShortDateString());
                    HPLCRefMgmt_Class_obj.loginID = FrmMain.LoginID;
                    bool flg = HPLCRefMgmt_Class_obj.Insert_tblHPLCRefMgmt();
                    if (flg == true)
                    {
                        MessageBox.Show("Record Inserted Successfully", "HPLC Reference Mgmt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnReset_Click(sender, e);
                        FillGrid();
                    }

                    //DataTable dt = new DataTable();
                    //HPLCRefMgmt_Class_obj.prsno = Convert.ToInt64(cmbRMCode.SelectedValue);
                    //dt = HPLCRefMgmt_Class_obj.Select_tblHPLCRefMgmt();
                    //if (dt.Rows.Count > 0)
                    //{
                    //    MessageBox.Show("Preservative RM code already exist", "HPLC Reference Mgmt", MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                    //}
                    //else
                    //{
                        
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool IsValid()
        {
            if (cmbRMCode.Text.Trim() == "--Select--" || cmbRMCode.SelectedValue == null)
            {
                MessageBox.Show("Select Preservative RM Code...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                cmbRMCode.Focus();
                return false;
            }
            if (dtpDateOfPreparation.Value < Convert.ToDateTime(currentDate.ToShortDateString()).AddDays(-1) || dtpDateOfPreparation.Text == " ")               
            {
                MessageBox.Show("Please Select preparation date...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                dtpDateOfPreparation.Focus();
                return false;
            }
            return true;
        }
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void dtpValidityDate_ValueChanged(object sender, EventArgs e)
        {
            dtpValidityDate.CustomFormat = "dd-MMM-yyyy";
        }       
  
    }
}