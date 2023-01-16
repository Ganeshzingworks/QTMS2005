using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Transactions
{
    public partial class FrmAdjustmentTransaction : Form
    {
        public FrmAdjustmentTransaction()
        {
            InitializeComponent();
        }

        int a = 0;
        bool isedit = false;
        bool isFinalUpdate = false;
        public static int strSrNo = 0;
        public static int PrevRowCount = 0;
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        BusinessFacade.Transactions.AdjustmentTransaction AdjustmentTransaction_Class_obj = new BusinessFacade.Transactions.AdjustmentTransaction();
        DateTime Today;
        # endregion

        private static FrmAdjustmentTransaction frmAdjustmentTransaction_Obj = null;
        public static FrmAdjustmentTransaction GetInstance()
        {
            if (frmAdjustmentTransaction_Obj == null)
            {
                frmAdjustmentTransaction_Obj = new FrmAdjustmentTransaction();
            }
            return frmAdjustmentTransaction_Obj;
        }

        private void FrmAdjustmentTransaction_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            try
            {
                Today = Comman_Class_Obj.Select_ServerDate();
                DtpAdjDate.Value = Comman_Class_Obj.Select_ServerDate();
                //BtnReset_Click(sender, e);
                Bind_FormulaNo();
                if (chkConditioner.Checked == true)
                {

                }
                else if (chkConditioner.Checked == false)
                {
                    Bind_RMDetails();
                    cmbPH.SelectedIndex = 0;
                    cmbPH_SelectionChangeCommitted(sender, e);
                    cmbViscosity.SelectedIndex = 0;
                    cmbViscosity_SelectionChangeCommitted(sender, e);
                }

                GrpBoxPH.Enabled = true;
                GrpBoxViscosity.Enabled = true;
                //dgAdj.Enabled = true;
                chkConditioner.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        public void Bind_FormulaNo()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = FormulaNoMaster_Class_Obj.SELECT_TblBulkMaster_Active();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbFormulaNo.DataSource = ds.Tables[0];
                CmbFormulaNo.ValueMember = "FNo";
                CmbFormulaNo.DisplayMember = "FormulaNo";
            }

        }
        public void Bind_RMDetails()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = AdjustmentTransaction_Class_obj.Select_RMTransaction_RMCode_Supplier_Lotno();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["RMSamplingID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbRMDetails.DataSource = ds.Tables[0];
                cmbRMDetails.DisplayMember = "Details";
                cmbRMDetails.ValueMember = "RMSamplingID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        private bool IsValid()
        {
            if (CmbFormulaNo.Text.ToString() == "--Select--")
            {
                MessageBox.Show("Please select formula", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CmbFormulaNo.Focus();
                return false;
            }
            if (txtMfgWo.Text.Trim() == "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0')
            {
                MessageBox.Show("Enter Workorder No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMfgWo.Focus();
                return false;
            }
            if (txtBatchSize.Text.Trim() == "" || txtBatchSize.Text.Trim() == "0" || Convert.ToInt64(txtBatchSize.Text.Trim()) <= 0)
            {
                MessageBox.Show("Enter Batch Size", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBatchSize.Focus();
                return false;
            }
            if (cmbRMDetails.Text.ToString() == "--Select--")
            {
                MessageBox.Show("Please select RM Code, Supplier & lot no ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRMDetails.Focus();
                return false;
            }
            // if (cmbPHRMCode.Text.ToString() == "--Select--")
            // {
            //     MessageBox.Show("Enter the PH RM Code", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //     cmbPHRMCode.Focus();
            //     return false;
            // }
            //if (cmbVsRMCode.Text.ToString() == "--Select--")
            // {
            //     MessageBox.Show("Enter the Viscosity RM Code", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //     cmbVsRMCode.Focus();
            //     return false;
            // }
            return true;
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                CmbFormulaNo.SelectedIndex = 0;
                txtBatchSize.Text = "0";
                txtBulkDesc.Text = "";
                txtTechnicalFamily.Text = "";
                txtMfgWo.Text = "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0';
                DtpAdjDate.Value = Comman_Class_Obj.Select_ServerDate();
                cmbRMDetails.SelectedIndex = 0;
                txtInitialPHValue.Text = "";
                txtInitialViscosityValue.Text = "";
                cmbPH.SelectedIndex = 0;
                cmbPH_SelectionChangeCommitted(sender, e);
                cmbViscosity.SelectedIndex = 0;
                cmbViscosity_SelectionChangeCommitted(sender, e);
                txtPHCalPercentage.Text = "0";
                txtPHCalQty.Text = "0";
                txtPHObserved.Text = "NA";
                txtVSCalPercentage.Text = "0";
                txtVSCalQty.Text = "0";
                txtViscosityObserved.Text = "NA";
                txtTotalPHPercentage.Text = "0";
                txtTotalPHQty.Text = "0";
                txtTotalVSPercentage.Text = "0";
                txtTotalVSQty.Text = "0";
                dgAdj.Rows.Clear();
                cmbPH.Enabled = true;
                cmbPHRMCode.Enabled = true;
                cmbViscosity.Enabled = true;
                cmbVsRMCode.Enabled = true;
                BtnSave.Enabled = true;
                btnAdd.Enabled = true;
                txtRMTransPH.Text = "";
                txtRMTransViscosity.Text = "";
                txtPHCalPercentage.Enabled = true;
                txtPHObserved.Enabled = true;
                txtViscosityObserved.Enabled = true;
                txtVSFinalObseved.Text = "";
                //dgAdj.Enabled = true;
                cmbRMDetails.Enabled = true;
                isFinalUpdate = false;
                chkConditioner.Checked = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                txtMfgWo.Text = "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0';

                if (CmbFormulaNo.SelectedValue != null && CmbFormulaNo.SelectedValue.ToString() != "")
                {
                    chkConditioner.Enabled = true;
                    //BtnReset_Click(sender, e);
                    txtBatchSize.Text = "0";
                    txtBulkDesc.Text = "";
                    txtTechnicalFamily.Text = "";
                    txtMfgWo.Text = "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0';
                    DtpAdjDate.Value = Comman_Class_Obj.Select_ServerDate();
                    cmbRMDetails.SelectedIndex = 0;
                    txtInitialPHValue.Text = "";
                    txtInitialViscosityValue.Text = "";
                    if (chkConditioner.Checked == true)
                    {
                        cmbRMDetails.Text = "-- NA --";
                        cmbRMDetails.Enabled = false;
                        cmbPH.Enabled = false;
                        cmbViscosity.Enabled = false;
                        cmbPH.Text = "-- NA --";
                        cmbViscosity.Text = "-- NA --";
                        cmbPHRMCode.DataSource = null;
                        cmbPHRMCode.Items.Clear();
                        cmbPHRMCode.Text = "-- NA --";
                        cmbPHRMCode.Items.Add("Mixing");
                        cmbPHRMCode.Items.Add("Emulsification");
                        cmbPHRMCode.Items.Insert(0, "-- NA --");
                        cmbVsRMCode.DataSource = null;
                        cmbVsRMCode.Items.Clear();
                        cmbVsRMCode.Text = "-- NA --";
                        cmbVsRMCode.Items.Add("Mixing");
                        cmbVsRMCode.Items.Add("Emulsification");
                        cmbVsRMCode.Items.Insert(0, "-- NA --");
                        txtPHCalPercentage.Enabled = false;
                        txtVSCalPercentage.Enabled = false;
                    }
                    else if (chkConditioner.Checked == false)
                    {
                        cmbPH.SelectedIndex = 0;
                        cmbPH_SelectionChangeCommitted(sender, e);
                        cmbViscosity.SelectedIndex = 0;
                        cmbViscosity_SelectionChangeCommitted(sender, e);
                    }
                    txtPHCalPercentage.Text = "0";
                    txtPHCalQty.Text = "0";
                    txtPHObserved.Text = "NA";
                    txtVSCalPercentage.Text = "0";
                    txtVSCalQty.Text = "0";
                    txtViscosityObserved.Text = "NA";
                    txtTotalPHPercentage.Text = "0";
                    txtTotalPHQty.Text = "0";
                    txtTotalVSPercentage.Text = "0";
                    txtTotalVSQty.Text = "0";
                    BtnSave.Enabled = true;
                    btnAdd.Enabled = true;
                    DataSet ds = new DataSet();
                    //chkConditioner_CheckedChanged(sender,e);
                    FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                    ds = FormulaNoMaster_Class_Obj.SELECT_TblBulkMaster_tblblkfamilyMaster();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtBulkDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);
                        txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBatchSize_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBatchSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //txtPHCalBatchSize.Text = Convert.ToString(txtBatchSize.Text.Trim());
                //txtVSCalBatchSize.Text = Convert.ToString(txtBatchSize.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void cmbPH_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbPH.SelectedIndex != 0)
                    GrpBoxViscosity.Enabled = false;
                else
                    GrpBoxViscosity.Enabled = true;

                if (chkConditioner.Checked == false)
                {
                    cmbPHRMCode.DataSource = null;
                }
                else
                { }
                if (cmbPH.SelectedIndex == 1)
                    AdjustmentTransaction_Class_obj.phflag = 1;
                else if (cmbPH.SelectedIndex == 2)
                    AdjustmentTransaction_Class_obj.phflag = 0;
                else
                    AdjustmentTransaction_Class_obj.phflag = null;
                DataTable dt = new DataTable();
                dt = AdjustmentTransaction_Class_obj.Select_RMCodeMaster_PHFlag();
                DataRow dr;
                dr = dt.NewRow();
                if (cmbPH.SelectedIndex == 0)
                {
                    dr["RMCode"] = "-- NA --";
                    txtPHCalPercentage.Text = "0";
                    txtPHCalQty.Text = "0";
                    txtPHObserved.Text = "NA";

                }
                else
                    dr["RMCode"] = "--Select--";
                dr["RMCodeID"] = "0";
                dt.Rows.InsertAt(dr, 0);
                cmbPHRMCode.DataSource = dt;
                cmbPHRMCode.DisplayMember = "RMCode";
                cmbPHRMCode.ValueMember = "RMCodeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbViscosity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbViscosity.SelectedIndex != 0)
                    GrpBoxPH.Enabled = false;
                else
                    GrpBoxPH.Enabled = true;

                if (chkConditioner.Checked == false)
                {
                    cmbVsRMCode.DataSource = null;
                }
                else
                { }

                if (cmbViscosity.SelectedIndex == 1)
                    AdjustmentTransaction_Class_obj.viscosityflag = 1;
                else if (cmbViscosity.SelectedIndex == 2)
                    AdjustmentTransaction_Class_obj.viscosityflag = 0;
                else
                    AdjustmentTransaction_Class_obj.viscosityflag = null;
                DataTable dt = new DataTable();
                dt = AdjustmentTransaction_Class_obj.Select_RMCodeMaster_ViscosityFlag();
                DataRow dr;
                dr = dt.NewRow();
                if (cmbViscosity.SelectedIndex == 0)
                {
                    dr["RMCode"] = "-- NA --";
                    txtVSCalPercentage.Text = "0";
                    txtVSCalQty.Text = "0";
                    txtViscosityObserved.Text = "NA";
                }
                else
                    dr["RMCode"] = "--Select--";
                dr["RMCodeID"] = "0";
                dt.Rows.InsertAt(dr, 0);
                cmbVsRMCode.DataSource = dt;
                cmbVsRMCode.DisplayMember = "RMCode";
                cmbVsRMCode.ValueMember = "RMCodeID";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    bool chkflagPH = false;
                    bool chkflagVS = false;
                    for (int i = 0; i < dgAdj.Rows.Count; i++)
                    {
                        if (Convert.ToString(dgAdj["PHRMCode", i].Value) == cmbPHRMCode.Text.Trim())
                        {
                            if ((cmbPHRMCode.Text.Trim() == "Mixing") || (cmbPHRMCode.Text.Trim() == "Mixing"))
                            {
                                chkflagPH = false;
                            }
                            else
                            {
                                chkflagPH = true;
                            }
                        }
                        else if (Convert.ToString(dgAdj["ViscosityRMCode", i].Value) == cmbVsRMCode.Text.Trim())
                        {
                            if ((cmbVsRMCode.Text.Trim() == "Mixing") || (cmbVsRMCode.Text.Trim() == "Mixing"))
                            {
                                chkflagPH = false;
                            }
                            else
                            {
                                chkflagPH = true;
                            }
                        }
                    }
                    //above code prevents the increase or decrease for the same RM code again
                    if (isedit == false)
                    {
                        if (chkflagPH == false && chkflagVS == false)
                        {

                            if (cmbPHRMCode.Text.Trim() == "--Select--" || cmbVsRMCode.Text.Trim() == "--Select--")
                            {
                                MessageBox.Show("Please select RM Code of PH or RM", "Message", MessageBoxButtons.OK);
                                return;
                            }
                            dgAdj.Rows.Add();
                            dgAdj["SrNo", dgAdj.Rows.Count - 1].Value = Convert.ToString(dgAdj.Rows.Count);
                            dgAdj["PH", dgAdj.Rows.Count - 1].Value = Convert.ToString(txtPHObserved.Text.Trim());
                            dgAdj["Viscosity", dgAdj.Rows.Count - 1].Value = Convert.ToString(txtViscosityObserved.Text.Trim());
                            dgAdj["VSPercentage", dgAdj.Rows.Count - 1].Value = Convert.ToString(txtVSCalPercentage.Text.Trim());
                            double VSPercentage = Convert.ToDouble((Convert.ToDouble(txtBatchSize.Text.Trim()) * Convert.ToDouble(txtVSCalPercentage.Text.Trim())) / 100);
                            dgAdj["VSQuantity", dgAdj.Rows.Count - 1].Value = Convert.ToString(VSPercentage);
                            dgAdj["PHPercentage", dgAdj.Rows.Count - 1].Value = Convert.ToString(txtPHCalPercentage.Text.Trim());
                            double PHPercentage = Convert.ToDouble((Convert.ToDouble(txtBatchSize.Text.Trim()) * Convert.ToDouble(txtPHCalPercentage.Text.Trim())) / 100);
                            dgAdj["PHQuantity", dgAdj.Rows.Count - 1].Value = Convert.ToString(PHPercentage);

                            if (cmbPHRMCode.Text.Trim() == "-- NA --")
                            {
                                dgAdj["PHRMCode", dgAdj.Rows.Count - 1].Value = "NA";
                            }
                            else
                            {
                                dgAdj["PHRMCode", dgAdj.Rows.Count - 1].Value = Convert.ToString(cmbPHRMCode.Text.Trim());
                            }
                            if (cmbVsRMCode.Text.Trim() == "-- NA --")
                            {
                                dgAdj["ViscosityRMCode", dgAdj.Rows.Count - 1].Value = "NA";
                            }
                            else
                            {
                                dgAdj["ViscosityRMCode", dgAdj.Rows.Count - 1].Value = Convert.ToString(cmbVsRMCode.Text.Trim());
                            }
                            if (cmbPHRMCode.SelectedValue == null)
                            {
                                dgAdj["RMCodePhVisible", dgAdj.Rows.Count - 1].Value = "0";
                            }
                            else
                            {
                                dgAdj["RMCodePhVisible", dgAdj.Rows.Count - 1].Value = Convert.ToString(cmbPHRMCode.SelectedValue);

                            }
                            if (cmbVsRMCode.SelectedValue == null)
                            {
                                dgAdj["RMCodeVsVisible", dgAdj.Rows.Count - 1].Value = "0";
                            }
                            else
                            {
                                dgAdj["RMCodeVsVisible", dgAdj.Rows.Count - 1].Value = Convert.ToString(cmbVsRMCode.SelectedValue);
                            }

                            if (cmbPH.SelectedIndex == 1)
                            {
                                dgAdj["IncreaseDecrease", dgAdj.Rows.Count - 1].Value = "Increase";
                            }
                            else if (cmbPH.SelectedIndex == 2)
                            {
                                dgAdj["IncreaseDecrease", dgAdj.Rows.Count - 1].Value = "Decrease";
                            }
                            if (cmbViscosity.SelectedIndex == 1)
                            {
                                dgAdj["IncreaseDecrease", dgAdj.Rows.Count - 1].Value = "Increase";
                            }
                            else if (cmbViscosity.SelectedIndex == 2)
                            {
                                dgAdj["IncreaseDecrease", dgAdj.Rows.Count - 1].Value = "Decrease";
                            }

                            dgAdj["PHFlag", dgAdj.Rows.Count - 1].Value = Convert.ToString(cmbPH.SelectedIndex);
                            dgAdj["VsFlag", dgAdj.Rows.Count - 1].Value = Convert.ToString(cmbViscosity.SelectedIndex);


                            txtPHCalPercentage.Text = "0";
                            txtPHCalQty.Text = "0";
                            txtVSCalPercentage.Text = "0";
                            txtVSCalQty.Text = "0";

                            string strFinalPh = txtPHObserved.Text; // beacuse when we reset the value its leave envent fires and changes the final ph values.
                            if (strFinalPh == "NA")
                            {
                                txtPHFinalObseved.Text = "0";
                            }
                            else
                            {
                                txtPHObserved.Text = "NA";
                                txtPHFinalObseved.Text = strFinalPh;
                            }

                            string strFinalViscosity = txtViscosityObserved.Text;

                            if (strFinalViscosity == "NA")
                            {
                                txtVSFinalObseved.Text = "0";
                            }
                            else
                            {
                                txtViscosityObserved.Text = "NA";
                                txtVSFinalObseved.Text = strFinalViscosity;
                            }

                            txtPHRMCode.Text = Convert.ToString(cmbPHRMCode.Text.Trim());
                            txtVsRMCode.Text = Convert.ToString(cmbVsRMCode.Text.Trim());

                            double phPercentTotal = 0, phQtyTotal = 0, vsPercentTotal = 0, vsQtyTotal = 0;
                            for (int i = 0; i < dgAdj.Rows.Count; i++)
                            {
                                phPercentTotal = phPercentTotal + Convert.ToDouble(dgAdj["PHPercentage", i].Value);
                                txtTotalPHPercentage.Text = Convert.ToString(phPercentTotal);
                                phQtyTotal = phQtyTotal + Convert.ToDouble(dgAdj["PHQuantity", i].Value);
                                txtTotalPHQty.Text = Convert.ToString(phQtyTotal);

                                vsPercentTotal = vsPercentTotal + Convert.ToDouble(dgAdj["VSPercentage", i].Value);
                                txtTotalVSPercentage.Text = Convert.ToString(vsPercentTotal);

                                vsQtyTotal = vsQtyTotal + Convert.ToDouble(dgAdj["VSQuantity", i].Value);
                                txtTotalVSQty.Text = Convert.ToString(vsQtyTotal);
                            }
                            txtPHCalPercentage.Focus();
                            GrpBoxPH.Enabled = true;
                            GrpBoxViscosity.Enabled = true;
                            cmbViscosity.SelectedIndex = 0;
                            cmbVsRMCode.DataSource = null;
                            cmbVsRMCode.Text = "-- NA --";
                            cmbPH.SelectedIndex = 0;
                            cmbPHRMCode.DataSource = null;
                            cmbPHRMCode.Text = "-- NA --";
                            txtViscosityObserved.Enabled = true;
                            if (chkConditioner.Checked == true)
                            {
                                cmbViscosity.Enabled = false;
                            }
                            else if (chkConditioner.Checked == false)
                            {
                                cmbViscosity.Enabled = true;
                            }
                            txtPHObserved.Enabled = true;
                        }
                        else if (chkflagPH)
                        {
                            //if (chkConditioner.Checked == true)
                            //{
                            //    MessageBox.Show("Sorry You Can not Increase/Decrease PH of Same RM Code", "Message", MessageBoxButtons.OK);
                            //    return;
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Sorry You Can not Increase/Decrease PH of Same RM Code", "Message", MessageBoxButtons.OK);
                            //    return;

                            //}
                            MessageBox.Show("Sorry You Can not Increase/Decrease PH of Same RM Code", "Message", MessageBoxButtons.OK);
                            return;
                        }
                        else if (chkflagVS)
                        {
                            MessageBox.Show("Sorry You Can not Increase/Decrease Viscosity of Same RM Code", "Message", MessageBoxButtons.OK);
                            return;
                        }
                    }

                    else if (isedit)
                    {
                        if (dgAdj.Rows.Count > 0)
                        {
                            dgAdj["PH", strSrNo].Value = Convert.ToString(txtPHObserved.Text.Trim());
                            dgAdj["Viscosity", strSrNo].Value = Convert.ToString(txtViscosityObserved.Text.Trim());
                        }
                        else
                        {

                        }
                        //if (chkConditioner.Checked == true)
                        //{
                        GrpBoxPH.Enabled = true;
                        txtPHObserved.Enabled = true;
                        GrpBoxViscosity.Enabled = true;
                        cmbPH.SelectedIndex = 0;
                        cmbPH.Enabled = true;
                        cmbPHRMCode.Enabled = true;
                        cmbViscosity.Enabled = true;
                        cmbVsRMCode.Enabled = true;
                        txtPHCalPercentage.Enabled = true;
                        txtPHCalQty.Enabled = true;
                        txtPHCalPercentage.Enabled = true;
                        txtVSCalPercentage.Enabled = true;
                        isedit = false;
                        txtPHCalPercentage.Text = "0";
                        txtPHCalQty.Text = "0";
                        cmbVsRMCode.DataSource = null;
                        cmbVsRMCode.Text = "-- NA --";
                        cmbPH.SelectedIndex = 0;
                        cmbPHRMCode.DataSource = null;
                        cmbPHRMCode.Text = "-- NA --";
                        if (chkConditioner.Checked == true)
                        {
                            cmbViscosity.Enabled = false;
                            cmbPH.Enabled = false;
                            txtPHCalPercentage.Enabled = false;
                            txtVSCalPercentage.Enabled = false;
                        }
                        else if (chkConditioner.Checked == false)
                        {
                            cmbPH.Enabled = true;
                            cmbViscosity.Enabled = true;
                            txtPHCalPercentage.Enabled = true;
                            txtVSCalPercentage.Enabled = true;
                        }
                        string strFinalPh = txtPHObserved.Text; // beacuse when we reset the value its leave envent fires and changes the final ph values.
                        if (strFinalPh == "NA")
                        {
                            txtPHFinalObseved.Text = "0";
                        }
                        else
                        {
                            txtPHObserved.Text = "NA";
                            txtPHFinalObseved.Text = strFinalPh;
                        }

                        string strFinalViscosity = txtViscosityObserved.Text;
                        if (strFinalViscosity == "NA")
                        {
                            txtVSFinalObseved.Text = "0";
                        }
                        else
                        {
                            txtViscosityObserved.Text = "NA";
                            txtVSFinalObseved.Text = strFinalViscosity;
                        }

                        txtVSCalPercentage.Text = "0";
                        txtVSCalQty.Text = "0";

                        txtViscosityObserved.Enabled = true;
                        //}
                        //else
                        //{
                        //    cmbViscosity.Enabled=true;
                        //}
                         btnAdd.Text = "Add";
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void txtInitailViscosityValue_TextChanged(object sender, EventArgs e)
        {
            if (dgAdj.Rows.Count == 1)
            {
                //dgAdj["PH", 0].Value = Convert.ToString(txtInitialPHValue.Text.Trim());
                dgAdj["Viscosity", 0].Value = Convert.ToString(txtInitialViscosityValue.Text.Trim());
            }
        }

        private void txtInitailViscosityValue_Leave(object sender, EventArgs e)
        {
            //if (CmbFormulaNo.Text.ToString() == "--Select--")
            //{
            //    CmbFormulaNo.Focus();
            //    MessageBox.Show("Please select formula", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtInitialViscosityValue.Text = "";
            //    return ;
            //}
            //if (txtMfgWo.Text.Trim() == "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0')
            //{
            //    //txtMfgWo.Focus();
            //    MessageBox.Show("Enter Workorder No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtInitialViscosityValue.Text = "";
            //    //txtMfgWo.Focus();
            //    return ;
            //}
            //if (txtBatchSize.Text.Trim() == "" && txtBatchSize.Text.Trim() == "0")
            //{
            //    MessageBox.Show("Enter Batch Size", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    //txtBatchSize.Focus();
            //    txtInitialViscosityValue.Text = "";
            //    return ;
            //}
            if (cmbRMDetails.Text.ToString() == "--Select--")
            {
                MessageBox.Show("Please select RM Code, Supplier & lot no ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRMDetails.Focus();
                txtInitialViscosityValue.Text = "";
                return;
            }
            //if (txtInitialPHValue.Text.Trim() == "")
            //{
            //    MessageBox.Show("Enter the PH Value", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtInitialPHValue.Focus();
            //    txtInitialViscosityValue.Text = "";
            //    return ;
            //}
            if (txtInitialViscosityValue.Text.Trim() == "")
            {
                MessageBox.Show("Enter the Viscosity Value", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInitialViscosityValue.Focus();
                return;
            }
            if (dgAdj.Rows.Count < 1)
            {
                if (txtInitialPHValue.Text.Trim() != "" && txtInitialViscosityValue.Text.Trim() != "")
                {
                    dgAdj.Rows.Add();
                    dgAdj["SrNo", 0].Value = "1";
                    dgAdj["PH", 0].Value = Convert.ToString(txtInitialPHValue.Text.Trim());
                    dgAdj["Viscosity", 0].Value = Convert.ToString(txtInitialViscosityValue.Text.Trim());
                    dgAdj["VSPercentage", 0].Value = "0";
                    dgAdj["VSQuantity", 0].Value = "0";
                    dgAdj["PHPercentage", 0].Value = "0";
                    dgAdj["PHQuantity", 0].Value = "0";
                }
            }
        }

        private void dgAdj_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 1)
            {
                return;
            }
        }

        private void dgAdj_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgAdj.CurrentCell.RowIndex < 1)
            {

            }
            else if (dgAdj.CurrentCell.ColumnIndex == dgAdj.Columns["PH"].Index)
            {
                dgAdj.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            //if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

            //     e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

            //     e.KeyChar != 9)
            //{

            //    e.Handled = true;

            //}
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtInitialPHValue_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtInitailViscosityValue_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtInitialPHValue_TextChanged(object sender, EventArgs e)
        {
            if (dgAdj.Rows.Count == 1)
            {
                dgAdj["PH", 0].Value = Convert.ToString(txtInitialPHValue.Text.Trim());
                //dgAdj["Viscosity", 0].Value = Convert.ToString(txtInitailViscosityValue.Text.Trim());
            }
        }

        private void txtPHCalPercentage_Leave(object sender, EventArgs e)
        {
            try
            {
                double PHPercentage = Convert.ToDouble((Convert.ToDouble(txtBatchSize.Text.Trim()) * Convert.ToDouble(txtPHCalPercentage.Text.Trim())) / 100);
                txtPHCalQty.Text = Convert.ToString(PHPercentage);
                //txtPHObserved.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void txtVSCalPercentage_Leave(object sender, EventArgs e)
        {
            try
            {
                double VSPercentage = Convert.ToDouble((Convert.ToDouble(txtBatchSize.Text.Trim()) * Convert.ToDouble(txtVSCalPercentage.Text.Trim())) / 100);
                txtVSCalQty.Text = Convert.ToString(VSPercentage);
                //txtViscosityObserved.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    AdjustmentTransaction_Class_obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                    AdjustmentTransaction_Class_obj.mfgwo = txtMfgWo.Text.Trim();
                    AdjustmentTransaction_Class_obj.batchsize = Convert.ToInt32(txtBatchSize.Text.Trim());
                    DataSet ds = new DataSet();
                    ds = AdjustmentTransaction_Class_obj.Select_tblAdjustment_fno_mfgwo_batchsize();
                    AdjustmentTransaction_Class_obj.adjdate = DtpAdjDate.Value;
                    if (chkConditioner.Checked == true)
                    {
                        AdjustmentTransaction_Class_obj.rmsamplingid = null;
                    }
                    else if (chkConditioner.Checked == false)
                    {
                        AdjustmentTransaction_Class_obj.rmsamplingid = Convert.ToInt64(cmbRMDetails.SelectedValue);
                    }
                    AdjustmentTransaction_Class_obj.initialphvalue = Convert.ToDouble(0);//txtInitialPHValue.Text.Trim());
                    AdjustmentTransaction_Class_obj.initialvsvalue = Convert.ToDouble(0);//txtInitialViscosityValue.Text.Trim());

                    if (isFinalUpdate == false) // checks the user updating existing records or not?
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                AdjustmentTransaction_Class_obj.adjid = Convert.ToInt64(dr["AdjID"]);
                                // IF Details exist against existing AdjID (Shampoo history ID) Then delete the existing record related to AdjID
                                bool flag = AdjustmentTransaction_Class_obj.Delete_tblAdjustmentDetails_AdjID();
                            }
                            //MessageBox.Show("This record already Exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                            //return;
                        }
                        else
                        {
                            AdjustmentTransaction_Class_obj.adjid = AdjustmentTransaction_Class_obj.Insert_tblAdjustment();
                        }

                        for (int i = 0; i < dgAdj.Rows.Count; i++)
                        {
                            AdjustmentTransaction_Class_obj.phpercent = Convert.ToDouble(dgAdj["PHPercentage", i].Value);
                            AdjustmentTransaction_Class_obj.phqty = Convert.ToDouble(dgAdj["PHQuantity", i].Value);
                            AdjustmentTransaction_Class_obj.vspercent = Convert.ToDouble(dgAdj["VSPercentage", i].Value);
                            AdjustmentTransaction_Class_obj.vsqty = Convert.ToDouble(dgAdj["VSQuantity", i].Value);
                            //modified by nitint
                            AdjustmentTransaction_Class_obj.phflagincrdecr = Convert.ToInt16(dgAdj["PHFlag", i].Value);
                            //AdjustmentTransaction_Class_obj.phrmcodeupdate = Convert.ToInt32(dgAdj["RMCodePhVisible", i].Value);
                            AdjustmentTransaction_Class_obj.vsflagincrdecr = Convert.ToInt16(dgAdj["VsFlag", i].Value);
                            //AdjustmentTransaction_Class_obj.phvscodeupdate = Convert.ToInt32(dgAdj["RMCodeVsVisible", i].Value);

                            if (chkConditioner.Checked == true)
                            {
                                // set code for Mixing

                                if (Convert.ToString(dgAdj["PHRMCode", i].Value) == "Mixing")
                                {
                                    AdjustmentTransaction_Class_obj.phrmcodeupdate = 1111;// 11 is fixed for Mixing 
                                }
                                else if (Convert.ToString(dgAdj["PHRMCode", i].Value) == "Emulsification")
                                {
                                    AdjustmentTransaction_Class_obj.phrmcodeupdate = 2222; // 12 is fixed for Emulsification
                                }
                                else if (Convert.ToString(dgAdj["PHRMCode", i].Value) == "NA")
                                {
                                    AdjustmentTransaction_Class_obj.phrmcodeupdate = 0; // 12 is fixed for Emulsification
                                }

                                // set code for Emulsification

                                if (Convert.ToString(dgAdj["ViscosityRMCode", i].Value) == "Mixing")
                                {
                                    AdjustmentTransaction_Class_obj.phvscodeupdate = 1111;// 11 is fixed for Mixing ViscosityRMCode
                                }
                                else if (Convert.ToString(dgAdj["ViscosityRMCode", i].Value) == "Emulsification")
                                {
                                    AdjustmentTransaction_Class_obj.phvscodeupdate = 2222; // 12 is fixed for Emulsification
                                }
                                else if (Convert.ToString(dgAdj["ViscosityRMCode", i].Value) == "NA")
                                {
                                    AdjustmentTransaction_Class_obj.phvscodeupdate = 0; // 12 is fixed for Emulsification
                                }
                            }
                            else if (chkConditioner.Checked == false)
                            {
                                AdjustmentTransaction_Class_obj.phrmcodeupdate = Convert.ToInt32(dgAdj["RMCodePhVisible", i].Value);
                                AdjustmentTransaction_Class_obj.phvscodeupdate = Convert.ToInt32(dgAdj["RMCodeVsVisible", i].Value);
                            }
                            string strPH = dgAdj["PH", i].Value.ToString();
                            if (strPH == "NA")
                            {
                                AdjustmentTransaction_Class_obj.phobserved = Convert.ToDouble(0);
                            }
                            else
                            {
                                AdjustmentTransaction_Class_obj.phobserved = Convert.ToDouble(dgAdj["PH", i].Value);
                            }
                            string strVis = dgAdj["Viscosity", i].Value.ToString();
                            if (strVis == "NA")
                            {
                                AdjustmentTransaction_Class_obj.vsobserved = Convert.ToDouble(0);
                            }
                            else
                            {
                                AdjustmentTransaction_Class_obj.vsobserved = Convert.ToDouble(dgAdj["Viscosity", i].Value);
                            }

                            AdjustmentTransaction_Class_obj.Insert_tblAdjustmentDetails_AdjID();
                        }
                        AdjustmentTransaction_Class_obj.totalphpercent = Convert.ToDouble(txtTotalPHPercentage.Text.Trim());
                        AdjustmentTransaction_Class_obj.totalphqty = Convert.ToDouble(txtTotalPHQty.Text.Trim());
                        AdjustmentTransaction_Class_obj.totalvspercent = Convert.ToDouble(txtTotalVSPercentage.Text.Trim());
                        AdjustmentTransaction_Class_obj.totalvsqty = Convert.ToDouble(txtTotalVSQty.Text.Trim());
                        AdjustmentTransaction_Class_obj.phobserved = Convert.ToDouble(txtPHFinalObseved.Text.Trim());
                        AdjustmentTransaction_Class_obj.vsobserved = Convert.ToDouble(txtVSFinalObseved.Text.Trim());
                        AdjustmentTransaction_Class_obj.Update_tblAdjustment_AdjID();
                        PrevRowCount = dgAdj.Rows.Count;
                        MessageBox.Show("Record saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                    }
                    ////////
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                AdjustmentTransaction_Class_obj.adjid = Convert.ToInt64(dr["AdjID"]);
                            }
                        }
                        //if (isedit==true)
                        //{
                        for (int i = 0; i < dgAdj.Rows.Count; i++)
                        {
                            string strPH = dgAdj["PH", i].Value.ToString();
                            if (strPH == "NA")
                            {
                                AdjustmentTransaction_Class_obj.phobserved = Convert.ToDouble(0);
                            }
                            else
                            {
                                AdjustmentTransaction_Class_obj.phobserved = Convert.ToDouble(dgAdj["PH", i].Value);
                            }
                            string strVis = dgAdj["Viscosity", i].Value.ToString();
                            if (strVis == "NA")
                            {
                                AdjustmentTransaction_Class_obj.vsobserved = Convert.ToDouble(0);
                            }
                            else
                            {
                                AdjustmentTransaction_Class_obj.vsobserved = Convert.ToDouble(dgAdj["Viscosity", i].Value);
                            }
                            AdjustmentTransaction_Class_obj.adjdetailsid = Convert.ToInt32(dgAdj["AdjDetailsId", i].Value);
                            AdjustmentTransaction_Class_obj.Update_tblAdjustmentDetails_AdjID();
                        }
                        //}
                        //else if (isedit==false)
                        //{
                        for (int i = 0; i < dgAdj.Rows.Count; i++)
                        {
                            //dgAdj["SrNo", dgAdj.Rows.Count - 1].Value
                            if (dgAdj["AdjDetailsId", i].Value == null)
                            {

                                AdjustmentTransaction_Class_obj.phpercent = Convert.ToDouble(dgAdj["PHPercentage", i].Value);
                                AdjustmentTransaction_Class_obj.phqty = Convert.ToDouble(dgAdj["PHQuantity", i].Value);
                                AdjustmentTransaction_Class_obj.vspercent = Convert.ToDouble(dgAdj["VSPercentage", i].Value);
                                AdjustmentTransaction_Class_obj.vsqty = Convert.ToDouble(dgAdj["VSQuantity", i].Value);
                                //modified by nitint
                                AdjustmentTransaction_Class_obj.phflagincrdecr = Convert.ToInt16(dgAdj["PHFlag", i].Value);
                                AdjustmentTransaction_Class_obj.vsflagincrdecr = Convert.ToInt16(dgAdj["VsFlag", i].Value);

                                if (chkConditioner.Checked == true)
                                {
                                    // set code for Mixing

                                    if (Convert.ToString(dgAdj["PHRMCode", i].Value) == "Mixing")
                                    {
                                        AdjustmentTransaction_Class_obj.phrmcodeupdate = 1111;// 11 is fixed for Mixing 
                                    }
                                    else if (Convert.ToString(dgAdj["PHRMCode", i].Value) == "Emulsification")
                                    {
                                        AdjustmentTransaction_Class_obj.phrmcodeupdate = 2222; // 12 is fixed for Emulsification
                                    }
                                    else if (Convert.ToString(dgAdj["PHRMCode", i].Value) == "NA")
                                    {
                                        AdjustmentTransaction_Class_obj.phrmcodeupdate = 0; // 12 is fixed for Emulsification
                                    }

                                    // set code for Emulsification

                                    if (Convert.ToString(dgAdj["ViscosityRMCode", i].Value) == "Mixing")
                                    {
                                        AdjustmentTransaction_Class_obj.phvscodeupdate = 1111;// 11 is fixed for Mixing ViscosityRMCode
                                    }
                                    else if (Convert.ToString(dgAdj["ViscosityRMCode", i].Value) == "Emulsification")
                                    {
                                        AdjustmentTransaction_Class_obj.phvscodeupdate = 2222; // 12 is fixed for Emulsification
                                    }
                                    else if (Convert.ToString(dgAdj["ViscosityRMCode", i].Value) == "NA")
                                    {
                                        AdjustmentTransaction_Class_obj.phvscodeupdate = 0; // 12 is fixed for Emulsification
                                    }
                                }
                                else if (chkConditioner.Checked == false)
                                {
                                    AdjustmentTransaction_Class_obj.phrmcodeupdate = Convert.ToInt32(dgAdj["RMCodePhVisible", i].Value);
                                    AdjustmentTransaction_Class_obj.phvscodeupdate = Convert.ToInt32(dgAdj["RMCodeVsVisible", i].Value);
                                }


                                string strPH = dgAdj["PH", i].Value.ToString();
                                if (strPH == "NA")
                                {
                                    AdjustmentTransaction_Class_obj.phobserved = Convert.ToDouble(0);
                                }
                                else
                                {
                                    AdjustmentTransaction_Class_obj.phobserved = Convert.ToDouble(dgAdj["PH", i].Value);
                                }
                                string strVis = dgAdj["Viscosity", i].Value.ToString();
                                if (strVis == "NA")
                                {
                                    AdjustmentTransaction_Class_obj.vsobserved = Convert.ToDouble(0);
                                }
                                else
                                {
                                    AdjustmentTransaction_Class_obj.vsobserved = Convert.ToDouble(dgAdj["Viscosity", i].Value);
                                }
                                AdjustmentTransaction_Class_obj.Insert_tblAdjustmentDetails_AdjID();
                            }
                            //else{}
                        }
                        isFinalUpdate = false;
                        MessageBox.Show("Record Updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void txtBatchSize_Leave(object sender, EventArgs e)
        {
            if (chkConditioner.Checked == false)
            {
                bool chkCond = false;
                if (txtBatchSize.Text.Trim() != "")
                {
                    DataSet ds = new DataSet();
                    AdjustmentTransaction_Class_obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                    AdjustmentTransaction_Class_obj.mfgwo = txtMfgWo.Text.Trim();
                    AdjustmentTransaction_Class_obj.batchsize = Convert.ToInt32(txtBatchSize.Text.Trim());
                    ds = AdjustmentTransaction_Class_obj.Select_tblAdjustment_fno_mfgwo_batchsize();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        isFinalUpdate = true;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            dgAdj.Rows.Clear();
                            AdjustmentTransaction_Class_obj.adjid = Convert.ToInt64(dr["AdjID"]);
                            if ((dr["RMSamplingID"]) == DBNull.Value)
                            {
                                //chkConditioner.Checked=true;
                                chkCond = true;
                            }
                            else
                            {
                                cmbRMDetails.SelectedValue = Convert.ToInt64(dr["RMSamplingID"]);
                            }
                            //cmbRMDetails.SelectedValue = Convert.ToInt64(dr["RMSamplingID"]);
                            txtInitialPHValue.Text = Convert.ToString(dr["InitialPHValue"]);
                            txtInitialViscosityValue.Text = Convert.ToString(dr["InitialVSValue"]);
                            DtpAdjDate.Value = Convert.ToDateTime(dr["AdjDate"]);

                            DataTable dt = new DataTable();
                            dt = AdjustmentTransaction_Class_obj.Select_tblAdjustment_AdjID();
                            if (dt.Rows.Count > 0)
                            {
                                //if (dt.Rows.Count > 1)
                                //{
                                //BtnSave.Enabled = false;
                                //btnAdd.Enabled = false;
                                //}
                                //cmbPH.SelectedIndex = Convert.ToInt32(dr["PHFlag"]);
                                //cmbViscosity.SelectedIndex = Convert.ToInt32(dr["VSFlag"]);
                                cmbPH_SelectionChangeCommitted(sender, e);
                                cmbViscosity_SelectionChangeCommitted(sender, e);
                                txtTotalPHPercentage.Text = Convert.ToString(dr["TotalPHPercent"]);
                                txtTotalPHQty.Text = Convert.ToString(dr["TotalPHQty"]);
                                txtTotalVSPercentage.Text = Convert.ToString(dr["TotalVSPercent"]);
                                txtTotalVSQty.Text = Convert.ToString(dr["TotalVSQty"]);
                                txtPHFinalObseved.Text = Convert.ToString(dr["FinalPHValue"]);
                                txtVSFinalObseved.Text = Convert.ToString(dr["FinalVSValue"]);
                                int srNo = 0;
                                foreach (DataRow drAdjId in dt.Rows)
                                {
                                    srNo = srNo + 1;
                                    dgAdj.Rows.Add();
                                    dgAdj["SrNo", dgAdj.Rows.Count - 1].Value = Convert.ToString(srNo);
                                    dgAdj["AdjDetailsId", dgAdj.Rows.Count - 1].Value = Convert.ToString(drAdjId["AdjDetailsId"]);
                                    dgAdj["PHPercentage", dgAdj.Rows.Count - 1].Value = Convert.ToString(drAdjId["PHPercent"]);
                                    dgAdj["PHQuantity", dgAdj.Rows.Count - 1].Value = Convert.ToString(drAdjId["PHQty"]);
                                    dgAdj["VSPercentage", dgAdj.Rows.Count - 1].Value = Convert.ToString(drAdjId["VSPercent"]);
                                    dgAdj["VSQuantity", dgAdj.Rows.Count - 1].Value = Convert.ToString(drAdjId["VSQty"]);
                                    dgAdj["PH", dgAdj.Rows.Count - 1].Value = Convert.ToString(drAdjId["PHObserved"]);
                                    dgAdj["Viscosity", dgAdj.Rows.Count - 1].Value = Convert.ToString(drAdjId["VSObserved"]);
                                    if ((drAdjId["PHFlag"]) != DBNull.Value)
                                        dgAdj["PHFlag", dgAdj.Rows.Count - 1].Value = Convert.ToInt32(drAdjId["PHFlag"]);
                                    if ((drAdjId["VSFlag"]) != DBNull.Value)
                                        dgAdj["VsFlag", dgAdj.Rows.Count - 1].Value = Convert.ToInt32(drAdjId["VSFlag"]);
                                    if ((drAdjId["PHRMCodeID"]) != DBNull.Value)
                                        dgAdj["RMCodePhVisible", dgAdj.Rows.Count - 1].Value = Convert.ToInt32(drAdjId["PHRMCodeID"]);
                                    if ((drAdjId["VSRMCodeID"]) != DBNull.Value)
                                        dgAdj["RMCodeVsVisible", dgAdj.Rows.Count - 1].Value = Convert.ToInt32(drAdjId["VSRMCodeID"]);
                                    if ((drAdjId["PHFlag"]) != DBNull.Value)
                                    {
                                        if (Convert.ToInt32(drAdjId["PHFlag"]) == 1)
                                        {
                                            dgAdj["IncreaseDecrease", dgAdj.Rows.Count - 1].Value = "Increase";
                                        }



                                        else if (Convert.ToInt32(drAdjId["PHFlag"]) == 2)
                                        {
                                            dgAdj["IncreaseDecrease", dgAdj.Rows.Count - 1].Value = "Decrease";
                                        }
                                    }
                                    if ((drAdjId["VsFlag"]) != DBNull.Value)
                                    {
                                        if (Convert.ToInt32(drAdjId["VsFlag"]) == 1)
                                        {
                                            dgAdj["IncreaseDecrease", dgAdj.Rows.Count - 1].Value = "Increase";
                                        }
                                        else if (Convert.ToInt32(drAdjId["VsFlag"]) == 2)
                                        {
                                            dgAdj["IncreaseDecrease", dgAdj.Rows.Count - 1].Value = "Decrease";
                                        }

                                    }

                                    AdjustmentTransaction_Class_obj.phflag = Convert.ToInt16(dgAdj["PHFlag", dgAdj.Rows.Count - 1].Value);
                                    cmbPH.SelectedIndex = Convert.ToInt16(dgAdj["PHFlag", dgAdj.Rows.Count - 1].Value);
                                    AdjustmentTransaction_Class_obj.viscosityflag = Convert.ToInt16(dgAdj["VsFlag", dgAdj.Rows.Count - 1].Value);
                                    cmbViscosity.SelectedIndex = Convert.ToInt16(dgAdj["VsFlag", dgAdj.Rows.Count - 1].Value);

                                    cmbPH_SelectionChangeCommitted(sender, e);
                                    cmbViscosity_SelectionChangeCommitted(sender, e);
                                    //if (chkConditioner.Checked == true)
                                    //{
                                    // the code 1111 and 2222 is decided for mixing and emulsification because these value doesnt have increase/decrease
                                    if (Convert.ToInt32(dgAdj["RMCodePhVisible", dgAdj.Rows.Count - 1].Value) == 1111)
                                    {
                                        dgAdj["PHRMCode", dgAdj.Rows.Count - 1].Value = "Mixing";
                                    }
                                    else if (Convert.ToInt32(dgAdj["RMCodePhVisible", dgAdj.Rows.Count - 1].Value) == 2222)
                                    {
                                        dgAdj["PHRMCode", dgAdj.Rows.Count - 1].Value = "Emulsification";
                                    }
                                    else if (Convert.ToInt32(dgAdj["RMCodePhVisible", dgAdj.Rows.Count - 1].Value) == 0)
                                    {
                                        dgAdj["PHRMCode", dgAdj.Rows.Count - 1].Value = "NA";
                                    }

                                    if (Convert.ToInt32(dgAdj["RMCodeVsVisible", dgAdj.Rows.Count - 1].Value) == 1111)
                                    {
                                        dgAdj["ViscosityRMCode", dgAdj.Rows.Count - 1].Value = "Mixing";
                                    }
                                    else if (Convert.ToInt32(dgAdj["RMCodeVsVisible", dgAdj.Rows.Count - 1].Value) == 2222)
                                    {
                                        dgAdj["ViscosityRMCode", dgAdj.Rows.Count - 1].Value = "Emulsification";
                                    }
                                    else if (Convert.ToInt32(dgAdj["RMCodeVsVisible", dgAdj.Rows.Count - 1].Value) == 0)
                                    {
                                        dgAdj["ViscosityRMCode", dgAdj.Rows.Count - 1].Value = "NA";
                                    }
                                    //else
                                    //{
                                    cmbPHRMCode.SelectedValue = Convert.ToInt32(dgAdj["RMCodePhVisible", dgAdj.Rows.Count - 1].Value);
                                    if (cmbPHRMCode.SelectedValue != null && Convert.ToInt32(cmbPHRMCode.SelectedValue) != 0)
                                    {
                                        if (cmbPHRMCode.Text == "-- NA --")
                                        {
                                            dgAdj["PHRMCode", dgAdj.Rows.Count - 1].Value = "NA";
                                        }
                                        else
                                        {
                                            dgAdj["PHRMCode", dgAdj.Rows.Count - 1].Value = cmbPHRMCode.Text;
                                        }
                                    }
                                    cmbVsRMCode.SelectedValue = Convert.ToInt32(dgAdj["RMCodeVsVisible", dgAdj.Rows.Count - 1].Value);
                                    if (cmbVsRMCode.SelectedValue != null && Convert.ToInt32(cmbVsRMCode.SelectedValue) != 0)
                                    {
                                        if (cmbVsRMCode.Text == "-- NA --")
                                        {
                                            dgAdj["ViscosityRMCode", dgAdj.Rows.Count - 1].Value = "NA";
                                        }
                                        else
                                        {
                                            dgAdj["ViscosityRMCode", dgAdj.Rows.Count - 1].Value = cmbVsRMCode.Text;
                                        }
                                    }
                                }

                                MessageBox.Show("This record already Exists for this Formula number, Work order & Batch Size!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                            }
                        }

                        // MessageBox.Show("This record already Exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        //CmbFormulaNo.Focus();
                        //BtnReset_Click(sender, e);
                        if (chkCond == true)
                        {
                            chkConditioner.Checked = true;
                            cmbRMDetails.Enabled = false;
                            cmbRMDetails.SelectedValue = 0;
                        }
                    }
                }
            }
        }

        private void btnAdjSummaryForSameFormula_Click(object sender, EventArgs e)
        {
            if (CmbFormulaNo.Text.Trim() != "--Select--" && txtBatchSize.Text.Trim() == "0")
            {
                AdjustmentTransaction_Class_obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                Reports_Forms.FrmAdjustmentReport frm = new QTMS.Reports_Forms.FrmAdjustmentReport("Adjustment", AdjustmentTransaction_Class_obj.fno);
                frm.ShowDialog();
            }
            else if (CmbFormulaNo.Text.Trim() != "--Select--" && txtBatchSize.Text.Trim() != "" && txtBatchSize.Text.Trim() != "0")
            {
                Report_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                Report_Class_Obj.batchsize = Convert.ToInt32(txtBatchSize.Text.Trim());
                DataSet ds = new DataSet();
                ds = Report_Class_Obj.Select_tblAdjustment_AdjID_Report();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Reports_Forms.FrmAdjustmentReport frm = new QTMS.Reports_Forms.FrmAdjustmentReport("Adjustment", ds, Report_Class_Obj.fno, Report_Class_Obj.batchsize);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("This record not Exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    //txtBatchSize.Text = "";
                }
            }
            else
            {
                Reports_Forms.FrmAdjustmentReport frm = new QTMS.Reports_Forms.FrmAdjustmentReport("Adjustment");
                frm.ShowDialog();
            }
        }

        private void txtPHObserved_TextChanged(object sender, EventArgs e)
        {
            txtPHFinalObseved.Text = txtPHObserved.Text.Trim();
        }

        private void txtViscosityObserved_TextChanged(object sender, EventArgs e)
        {
            txtVSFinalObseved.Text = txtViscosityObserved.Text.Trim();
        }

        private void cmbRMDetails_Leave(object sender, EventArgs e)
        {
            if (a == 0)
            {
                if (CmbFormulaNo.Text.ToString() == "--Select--")
                {
                    a = 1;
                    MessageBox.Show("Please select formula", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbFormulaNo.Focus();
                    a = 0;
                    return;
                }
                if (txtMfgWo.Text.Trim() == "WO" + Today.Year.ToString().Substring(2) + Today.Day + '0')
                {
                    a = 1;
                    MessageBox.Show("Enter Workorder No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMfgWo.Focus();
                    a = 0;
                    return;
                }
                if (txtBatchSize.Text.Trim() == "" || txtBatchSize.Text.Trim() == "0")
                {
                    a = 1;
                    MessageBox.Show("Enter Batch Size", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBatchSize.Focus();
                    a = 0;
                    return;
                }

            }

        }

        private void txtInitialPHValue_Leave(object sender, EventArgs e)
        {
            if (a == 0)
            {
                if (cmbRMDetails.Text.ToString() == "--Select--")
                {
                    a = 1;
                    MessageBox.Show("Please select RM Code, Supplier & lot no ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRMDetails.Focus();
                    a = 0;
                }
            }
        }

        private void cmbRMDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbRMDetails_Leave(sender, e);
                txtRMTransPH.Text = "";
                txtRMTransViscosity.Text = "";
                DataTable dt = new DataTable();
                AdjustmentTransaction_Class_obj.rmsamplingid = Convert.ToInt64(cmbRMDetails.SelectedValue);
                dt = AdjustmentTransaction_Class_obj.Select_RMSamplingID_AdjustmentHistory_RMSamplingID();
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToString(dr["PHVSFlag"]) == "1")
                        txtRMTransPH.Text = Convert.ToString(dr["NormsReading"]);
                    else if (Convert.ToString(dr["PHVSFlag"]) == "2")
                        txtRMTransViscosity.Text = Convert.ToString(dr["NormsReading"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void dgAdj_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dgv in dgAdj.SelectedRows)
            {
                btnAdd.Text = "Modify";
                if (dgv.Cells["PHFlag"].Value != null)
                    cmbPH.SelectedIndex = Convert.ToInt32(dgv.Cells["PHFlag"].Value.ToString());
                if (dgv.Cells["VsFlag"].Value != null)
                    cmbViscosity.SelectedIndex = Convert.ToInt32(dgv.Cells["VsFlag"].Value.ToString());
                cmbPH_SelectionChangeCommitted(sender, e);
                cmbViscosity_SelectionChangeCommitted(sender, e);
                GrpBoxPH.Enabled = true;
                GrpBoxViscosity.Enabled = true;
                strSrNo = Convert.ToInt32(dgv.Cells["SrNo"].Value.ToString()) - 1;
                txtPHObserved.Text = dgv.Cells["PH"].Value.ToString();
                txtPHCalQty.Text = dgv.Cells["PHQuantity"].Value.ToString();
                txtViscosityObserved.Text = dgv.Cells["Viscosity"].Value.ToString();
                txtPHCalPercentage.Text = dgv.Cells["PHPercentage"].Value.ToString();
                txtVSCalPercentage.Text = dgv.Cells["VSPercentage"].Value.ToString();
                txtVSCalQty.Text = dgv.Cells["VSQuantity"].Value.ToString();

                if (dgv.Cells["RMCodePhVisible"].Value != null)
                    cmbPHRMCode.SelectedValue = Convert.ToInt32(dgv.Cells["RMCodePhVisible"].Value.ToString());// + ".";
                if (dgv.Cells["RMCodeVsVisible"].Value != null)
                    cmbVsRMCode.SelectedValue = Convert.ToInt32(dgv.Cells["RMCodeVsVisible"].Value.ToString());// + ".";

                //cmbPHRMCode.Text = dgv.Cells["PHRMCode"].Value.ToString();// + ".";
                //cmbVsRMCode.Text = dgv.Cells["ViscosityRMCode"].Value.ToString();// + ".";


                if (txtPHObserved.Text == "0" || txtPHObserved.Text == "NA" && txtPHCalQty.Text == "0" && txtPHCalPercentage.Text == "0")
                {
                    txtViscosityObserved.Enabled = true;
                    txtPHObserved.Enabled = false;
                }
                if (txtViscosityObserved.Text == "0" || txtViscosityObserved.Text == "NA" && txtVSCalPercentage.Text == "0" && txtVSCalQty.Text == "0")
                {
                    txtViscosityObserved.Enabled = false;
                    txtPHObserved.Enabled = true;
                }
                if (txtPHObserved.Text == "NA" && txtPHCalQty.Text == "0" && txtPHCalPercentage.Text == "0" && txtViscosityObserved.Text == "NA" && txtVSCalPercentage.Text == "0" && txtVSCalQty.Text == "0")
                {
                    txtViscosityObserved.Enabled = true;
                    txtPHObserved.Enabled = true;
                }
            }
            string strFinalPh = txtPHObserved.Text; // beacuse when we reset the value its leave envent fires and changes the final ph values.
            if (strFinalPh == "NA")
            {
                txtPHFinalObseved.Text = "0";
            }
            else
            {
                txtPHObserved.Text = strFinalPh;
                txtPHFinalObseved.Text = strFinalPh;
            }

            string strFinalViscosity = txtViscosityObserved.Text;

            if (strFinalViscosity == "NA")
            {
                txtVSFinalObseved.Text = "0";
            }
            else
            {
                txtViscosityObserved.Text = strFinalViscosity;
                txtVSFinalObseved.Text = strFinalViscosity;
            }
            cmbPH.Enabled = false;
            cmbPHRMCode.Enabled = false;
            //cmbViscosity.Enabled = true;
            cmbVsRMCode.Enabled = false;
            txtPHCalPercentage.Enabled = false;
            txtPHCalQty.Enabled = false;
            txtPHCalPercentage.Enabled = false;
            txtVSCalPercentage.Enabled = false;
            isedit = true;
            cmbViscosity.Enabled = false;
            if (chkConditioner.Checked == true)
            {
                cmbRMDetails.Text = "-- NA --";
                cmbRMDetails.Enabled = false;
                cmbPH.Enabled = false;
                cmbViscosity.Enabled = false;
                cmbPH.Text = "-- NA --";
                cmbViscosity.Text = "-- NA --";
                cmbPHRMCode.DataSource = null;
                cmbPHRMCode.Text = "-- NA --";
                cmbPHRMCode.Items.Add("Mixing");
                cmbPHRMCode.Items.Add("Emulsification");
                cmbPHRMCode.Items.Insert(0, "-- NA --");
                cmbVsRMCode.DataSource = null;
                cmbVsRMCode.Text = "-- NA --";
                cmbVsRMCode.Items.Add("Mixing");
                cmbVsRMCode.Items.Add("Emulsification");
                cmbVsRMCode.Items.Insert(0, "-- NA --");
                txtPHCalPercentage.Enabled = false;
                txtVSCalPercentage.Enabled = false;
                //txtPHObserved.Text = "";
                //txtViscosityObserved.Text = "";

            }
            else if (chkConditioner.Checked == false)
            {
                //cmbRMDetails.Enabled = true;
                //Bind_RMDetails();
                //cmbPH.SelectedIndex = 0;
                //cmbPH_SelectionChangeCommitted(sender, e);
                //cmbViscosity.SelectedIndex = 0;
                //cmbViscosity_SelectionChangeCommitted(sender, e);
                //txtPHCalPercentage.Enabled = true;
                //txtVSCalPercentage.Enabled = true;
                //cmbPH.Enabled = true;
                //cmbViscosity.Enabled = true;

            }
            //if (chkConditioner.Checked == true)
            //{
            //    cmbViscosity.Enabled = false;
            //}
            //else if (chkConditioner.Checked == false)
            //{
            //    cmbViscosity.Enabled = true;
            //}

        }

        private void txtPHCalPercentage_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtVSCalPercentage_KeyPress(object sender, KeyPressEventArgs e)
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

        private void chkConditioner_CheckedChanged(object sender, EventArgs e)
        {
            if (CmbFormulaNo.Text.ToString() == "--Select--" && chkConditioner.Checked == true)
            {

                //chkConditioner.Checked=false;
                MessageBox.Show("Please select formula", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CmbFormulaNo.Focus();
                //a = 0;
                //return;
            }
            if (chkConditioner.Checked == true)
            {
                cmbRMDetails.Text = "-- NA --";
                cmbRMDetails.Enabled = false;
                cmbPH.Enabled = false;
                cmbViscosity.Enabled = false;
                cmbPH.Text = "-- NA --";
                cmbViscosity.Text = "-- NA --";
                cmbPHRMCode.DataSource = null;
                cmbPHRMCode.Text = "-- NA --";
                cmbPHRMCode.Items.Add("Mixing");
                cmbPHRMCode.Items.Add("Emulsification");
                cmbPHRMCode.Items.Insert(0, "-- NA --");
                cmbVsRMCode.DataSource = null;
                cmbVsRMCode.Text = "-- NA --";
                cmbVsRMCode.Items.Add("Mixing");
                cmbVsRMCode.Items.Add("Emulsification");
                cmbVsRMCode.Items.Insert(0, "-- NA --");
                txtPHCalPercentage.Enabled = false;
                txtVSCalPercentage.Enabled = false;
                //txtPHObserved.Text = "";
                //txtViscosityObserved.Text = "";
                dgAdj.Columns["IncreaseDecrease"].HeaderText = "";

            }
            else if (chkConditioner.Checked == false)
            {
                cmbRMDetails.Enabled = true;
                Bind_RMDetails();
                cmbPH.SelectedIndex = 0;
                cmbPH_SelectionChangeCommitted(sender, e);
                cmbViscosity.SelectedIndex = 0;
                cmbViscosity_SelectionChangeCommitted(sender, e);
                txtPHCalPercentage.Enabled = true;
                txtVSCalPercentage.Enabled = true;
                cmbPH.Enabled = true;
                cmbViscosity.Enabled = true;
                dgAdj.Columns["IncreaseDecrease"].HeaderText = "IncreaseDecrease";

            }
        }

        private void chkConditioner_Leave(object sender, EventArgs e)
        {

        }

        private void cmbPHRMCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (chkConditioner.Checked == true)
            {
                if (cmbPHRMCode.SelectedIndex > 0)
                {
                    cmbVsRMCode.Enabled = false;
                    cmbPHRMCode.Enabled = true;
                    txtPHObserved.Enabled = true;
                    txtViscosityObserved.Enabled = false;
                }
                else if (cmbVsRMCode.SelectedIndex > 0 && cmbPHRMCode.SelectedIndex > 0)
                {
                    cmbPHRMCode.Enabled = true;
                    cmbVsRMCode.Enabled = true;
                    txtPHObserved.Enabled = true;
                    txtViscosityObserved.Enabled = true;
                }
                if (cmbPHRMCode.SelectedIndex == 0)
                {
                    cmbPHRMCode.Enabled = true;
                    cmbVsRMCode.Enabled = true;
                    txtPHObserved.Enabled = true;
                    txtViscosityObserved.Enabled = true;
                    cmbVsRMCode.SelectedIndex = 0;
                }
            }
            else if (chkConditioner.Checked == false)
            {
                cmbVsRMCode.Enabled = true;
                cmbPHRMCode.Enabled = true;
                txtPHObserved.Enabled = true;
                txtViscosityObserved.Enabled = true;
            }
        }

        private void cmbVsRMCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkConditioner.Checked == true)
            {
                if (cmbVsRMCode.SelectedIndex == 0)
                {
                    cmbPHRMCode.Enabled = true;
                    cmbVsRMCode.Enabled = true;
                    txtPHObserved.Enabled = true;
                    txtViscosityObserved.Enabled = true;
                    cmbPHRMCode.SelectedIndex = 0;
                }
                if (cmbVsRMCode.SelectedIndex > 0)
                {
                    cmbPHRMCode.Enabled = false;
                    cmbVsRMCode.Enabled = true;
                    txtPHObserved.Enabled = false;
                    txtViscosityObserved.Enabled = true;
                }
            }
            else if (chkConditioner.Checked == false)
            {
                cmbVsRMCode.Enabled = true;
                cmbPHRMCode.Enabled = true;
                txtPHObserved.Enabled = true;
                txtViscosityObserved.Enabled = true;
            }
        }

        private void btnShowResults_Click(object sender, EventArgs e)
        {
            QTMS.Forms.FrmShowTitrationResults objFrm = new QTMS.Forms.FrmShowTitrationResults();
            objFrm.Show();
        }
    }

}