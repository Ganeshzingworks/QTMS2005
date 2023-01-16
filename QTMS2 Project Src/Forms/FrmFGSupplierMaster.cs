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

namespace QTMS.Forms
{
    public partial class FrmFGSupplierMaster : System.Windows.Forms.Form
    {

        public FrmFGSupplierMaster()
        {
            InitializeComponent();
        }

        DataSet dsList = new DataSet();
        #region Variables
        int rownumber = -1;
        FGSupplierMaster FGSupplierMaster_Class_obj = new FGSupplierMaster();
        bool modify = false;

        #region Avinash S 06-08-2014
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        #endregion

        #endregion

        private static FrmFGSupplierMaster frmFGSupplierMaster_Obj = null;
        public static FrmFGSupplierMaster GetInstance()
        {
            if (frmFGSupplierMaster_Obj == null)
            {
                frmFGSupplierMaster_Obj = new Forms.FrmFGSupplierMaster();
            }
            return frmFGSupplierMaster_Obj;
        }


        private void FrmPMSupplierMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            Bind_List();

            Bind_ComboFG();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtPMSupplierName.Text = "";
            txtSupplierMailID.Text = "";
            modify = false;
            btnDelete.Enabled = false;
            ChkMicro.Enabled = true;
            ChkPacking.Enabled = true;
            ChkPhysicochemical.Enabled = true;
            rdbFGMark.Checked = true;
            
            dgPMMaster.Rows.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPMSupplierName.Text.Trim()))
                {
                    MessageBox.Show("Enter SubContractor Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSupplierName.Focus();
                    return;

                }
                if (!string.IsNullOrEmpty(txtSupplierMailID.Text.Trim()))
                {
                    if (CheckValidMail.IsEmailValid(txtSupplierMailID.Text.Trim()) == false)
                    {
                        MessageBox.Show("Please Enter Valid SubContractor Mail ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSupplierMailID.Focus();
                        return;
                    }
                }
                if (modify == false)
                {
                    FGSupplierMaster_Class_obj.FGSupplierName = txtPMSupplierName.Text.ToString();
                    bool chkSupplier = FGSupplierMaster_Class_obj.CheckSupplierExistance;
                    if (!chkSupplier)
                    {
                        FGSupplierMaster_Class_obj.Email = txtSupplierMailID.Text.Trim();
                        bool b = FGSupplierMaster_Class_obj.Insert_FGSupplierMaster();
                        if (b == true)
                        {
                            DataSet ds = new DataSet();
                            ds = FGSupplierMaster_Class_obj.Select_FGSubContractorID();
                            FGSupplierMaster_Class_obj.FGSupplierId = Convert.ToInt64(ds.Tables[0].Rows[0]["FGSupplierId"]);
                            FGSupplierMaster_Class_obj.CreatedBy = FrmMain.LoginID;

                            //Remove delete log as discussion Harpreet 30-05-2018
                            //bool res = FGSupplierMaster_Class_obj.Delete_FGSubContactorMaster();

                            foreach (DataGridViewRow row in dgPMMaster.Rows)
                            {
                                FGSupplierMaster_Class_obj.FGNo = Convert.ToInt64(row.Cells["FGNo"].Value);
                                FGSupplierMaster_Class_obj.FGCode = row.Cells["FGCode"].Value.ToString();
                                FGSupplierMaster_Class_obj.COC = row.Cells["ValPMCOC"].Value.ToString();
                                FGSupplierMaster_Class_obj.Packing = Convert.ToBoolean(row.Cells["Packing"].Value);
                                FGSupplierMaster_Class_obj.Micro = Convert.ToBoolean(row.Cells["Micro"].Value);
                                FGSupplierMaster_Class_obj.Physicochemical = Convert.ToBoolean(row.Cells["physicochemical"].Value);
                                FGSupplierMaster_Class_obj.NoofLots = row.Cells["ValPMNoofLots"].Value.ToString();
                                FGSupplierMaster_Class_obj.ActualLots = row.Cells["ActualLots"].Value.ToString();
                                FGSupplierMaster_Class_obj.Mark = row.Cells["Mark"].Value.ToString();

                                FGSupplierMaster_Class_obj.Insert_FGSubContactorMaster();
                            }

                            MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnReset_Click(sender, e);
                            dgPMMaster.Rows.Clear();
                            Bind_List();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Same SubContractor Already Exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPMSupplierName.Text = "";
                    }
                }
                else
                {
                    if (txtPMSupplierName.Text.ToString() == "")
                    {
                        MessageBox.Show("SubContractor Name cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPMSupplierName.Focus();
                        return;
                    }
                    FGSupplierMaster_Class_obj.FGSupplierId = Convert.ToInt64(List.SelectedValue.ToString());
                    FGSupplierMaster_Class_obj.FGSupplierName = txtPMSupplierName.Text.Trim();
                    FGSupplierMaster_Class_obj.Email = txtSupplierMailID.Text.Trim();// Add supplier mail ID
                    FGSupplierMaster_Class_obj.CreatedBy = FrmMain.LoginID;

                    bool b1 = FGSupplierMaster_Class_obj.Update_FGSupplierMaster();
                    if (b1 == true)
                    {
                        //Remove delete log as discussion Harpreet 30-05-2018
                       // bool res = FGSupplierMaster_Class_obj.Delete_FGSubContactorMaster();
                        foreach (DataGridViewRow row in dgPMMaster.Rows)
                        {
                            FGSupplierMaster_Class_obj.FGNo = Convert.ToInt64(row.Cells["FGNo"].Value);
                            FGSupplierMaster_Class_obj.FGCode = row.Cells["FGCode"].Value.ToString();
                            FGSupplierMaster_Class_obj.COC = row.Cells["ValPMCOC"].Value.ToString();
                            FGSupplierMaster_Class_obj.Packing = Convert.ToBoolean(row.Cells["Packing"].Value);
                            FGSupplierMaster_Class_obj.Micro = Convert.ToBoolean(row.Cells["Micro"].Value);
                            FGSupplierMaster_Class_obj.Physicochemical = Convert.ToBoolean(row.Cells["physicochemical"].Value);
                            FGSupplierMaster_Class_obj.NoofLots = row.Cells["ValPMNoofLots"].Value.ToString();
                            FGSupplierMaster_Class_obj.ActualLots = row.Cells["ActualLots"].Value.ToString();
                            FGSupplierMaster_Class_obj.Mark = Convert.ToString( row.Cells["Mark"].Value);

                            FGSupplierMaster_Class_obj.Insert_FGSubContactorMaster();
                        }

                        MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bind_List();
                        modify = false;
                        btnReset_Click(sender, e);
                        dgPMMaster.Rows.Clear();
                    }

                }

            }
            catch
            {
                MessageBox.Show("Same SubContractor Already Exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPMSupplierName.Text = "";
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            List_DoubleClick(sender, e);
            modify = true;
        }

        public void Bind_List()
        {
            try
            {
                dsList = FGSupplierMaster_Class_obj.Select_FGSupplierMaster();

                if (dsList.Tables[0].Rows.Count >= 0)
                {
                    List.DataSource = dsList.Tables[0];
                    List.DisplayMember = "FGSupplierName";
                    List.ValueMember = "FGSupplierId";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {

            // txtSearch.Text = Convert.ToString(List.Text);
            //  btnReset_Click(sender, e);
            DataSet ds = new DataSet();
            FGSupplierMaster_Class_obj.FGSupplierId = Convert.ToInt64(List.SelectedValue);
            ds = FGSupplierMaster_Class_obj.Select_FGSupplierMaster_FGSupplierID();
            txtPMSupplierName.Text = List.Text.ToString();
            txtSupplierMailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["FGEmail"]);
            //if (ds.Tables[0].Rows[0]["AuditConducted"].ToString() != "")
            //{
            //    dtpPMAuditDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["AuditConducted"].ToString());
            //}
            //if (ds.Tables[0].Rows[0]["PMSupplierMail"].ToString() != "")
            //{
            //    txtSupplierMailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMSupplierMail"].ToString());
            //}

            #region Avinash S
            dgPMMaster.Rows.Clear();

            DataSet ds_FG = new DataSet();
            ds_FG = FGSupplierMaster_Class_obj.Select_TblFG_SubContracter_FGSupplierID();

            for (int i = 0; i < ds_FG.Tables[0].Rows.Count; i++)
            {
                dgPMMaster.Rows.Add();
                dgPMMaster["FGNo", dgPMMaster.Rows.Count - 1].Value = ds_FG.Tables[0].Rows[i]["FGNo"].ToString();
                dgPMMaster["FGCode", dgPMMaster.Rows.Count - 1].Value = ds_FG.Tables[0].Rows[i]["FGCode"].ToString();
                dgPMMaster["ValPMCOC", dgPMMaster.Rows.Count - 1].Value = ds_FG.Tables[0].Rows[i]["COC"].ToString();
                dgPMMaster["Packing", dgPMMaster.Rows.Count - 1].Value = Convert.ToBoolean(ds_FG.Tables[0].Rows[i]["Packing"]);
                dgPMMaster["Micro", dgPMMaster.Rows.Count - 1].Value = Convert.ToBoolean(ds_FG.Tables[0].Rows[i]["Micro"]);
                dgPMMaster["physicochemical", dgPMMaster.Rows.Count - 1].Value = Convert.ToBoolean(ds_FG.Tables[0].Rows[i]["Physicochemical"]);
                dgPMMaster["ValPMNoofLots", dgPMMaster.Rows.Count - 1].Value = ds_FG.Tables[0].Rows[i]["NoofLots"].ToString();
                dgPMMaster["ActualLots", dgPMMaster.Rows.Count - 1].Value = ds_FG.Tables[0].Rows[i]["ActualLots"].ToString();

                dgPMMaster["Mark", dgPMMaster.Rows.Count - 1].Value = ds_FG.Tables[0].Rows[i]["Mark"].ToString();
            }



            #endregion


            modify = true;
            btnDelete.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                FGSupplierMaster_Class_obj.FGSupplierId = Convert.ToInt64(List.SelectedValue);

                if (FGSupplierMaster_Class_obj.FGSupplierId > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = FGSupplierMaster_Class_obj.CheckIn_tblBulkTestTransaction();
                        if (b)
                        {
                            MessageBox.Show("Record Cannot Be Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            bool deleteStatus = FGSupplierMaster_Class_obj.Delete_FGSupplier();
                            if (deleteStatus)
                            {
                                MessageBox.Show("Record deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        btnReset_Click(sender, e);
                        Bind_List();
                        modify = false;
                        btnDelete.Enabled = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Record Cannot Be Deleted", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPMSupplierName_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtPMSupplierName.Text = textInfo.ToTitleCase(txtPMSupplierName.Text.Trim());
            txtSupplierMailID.Focus();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "FGSupplierName like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "FGSupplierName";
            List.ValueMember = "FGSupplierId";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSearch.Text = Convert.ToString(List.Text);
                //  btnReset_Click(sender, e);
                //DataSet ds = new DataSet();
                //FGSupplierMaster_Class_obj.pmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
                //ds = FGSupplierMaster_Class_obj.Select_PMSupplierMaster_PMSupplierID();
                //txtPMSupplierName.Text = List.Text.ToString();
                //if (ds.Tables[0].Rows[0]["AuditConducted"].ToString() != "")
                //{
                //    dtpPMAuditDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["AuditConducted"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["PMSupplierMail"].ToString() != "")
                //{
                //    txtSupplierMailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMSupplierMail"].ToString());
                //}

                DataSet ds = new DataSet();
                FGSupplierMaster_Class_obj.FGSupplierId = Convert.ToInt64(List.SelectedValue);
                ds = FGSupplierMaster_Class_obj.Select_FGSupplierMaster_FGSupplierID();
                txtPMSupplierName.Text = List.Text.ToString();
                txtSupplierMailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["FGEmail"]);
                modify = true;
                btnDelete.Enabled = true;
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
            if (e.KeyChar == 13)
            {
                txtSearch.Text = Convert.ToString(List.Text);
                //  btnReset_Click(sender, e);
                //DataSet ds = new DataSet();
                //FGSupplierMaster_Class_obj.pmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
                //ds = FGSupplierMaster_Class_obj.Select_PMSupplierMaster_PMSupplierID();
                //txtPMSupplierName.Text = List.Text.ToString();
                //if (ds.Tables[0].Rows[0]["AuditConducted"].ToString() != "")
                //{
                //    dtpPMAuditDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["AuditConducted"].ToString());
                //}
                //if (ds.Tables[0].Rows[0]["PMSupplierMail"].ToString() != "")
                //{
                //    txtSupplierMailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMSupplierMail"].ToString());
                //}

                DataSet ds = new DataSet();
                FGSupplierMaster_Class_obj.FGSupplierId = Convert.ToInt64(List.SelectedValue);
                ds = FGSupplierMaster_Class_obj.Select_FGSupplierMaster_FGSupplierID();
                txtPMSupplierName.Text = List.Text.ToString();
                txtSupplierMailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["FGEmail"]);
                modify = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                FGSupplierMaster objPMSupplierMaster_Class = new FGSupplierMaster();
                DataSet ds = new DataSet();
                ds = objPMSupplierMaster_Class.Select_FGSupplierMaster();

                ExportToExcel objExport = new ExportToExcel();
                objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Avinash S 06-08-2014

        public void Bind_ComboFG()
        {

            try
            {
                DataSet Ds = new DataSet();
                DataRow dr;
                Ds = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster();
                dr = Ds.Tables[0].NewRow();
                dr["FGCode"] = "--Select--";
                Ds.Tables[0].Rows.InsertAt(dr, 0);
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    CmbFGCode.DataSource = Ds.Tables[0];
                    CmbFGCode.DisplayMember = "FGCode";
                    CmbFGCode.ValueMember = "FGNo";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        private void btnFormulaAdd_Click(object sender, EventArgs e)
        {
            
            if (rownumber != -1)
            {
                if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    for (int i = 0; i <= dgPMMaster.Rows.Count - 1; i++)
                    {
                        if (dgPMMaster["FGNo", i].Value.ToString() == CmbFGCode.SelectedValue.ToString())
                        {
                            dgPMMaster["FGNo", i].Value = CmbFGCode.SelectedValue.ToString();
                            dgPMMaster["FGCode", i].Value = CmbFGCode.Text;
                            dgPMMaster["ValPMCOC", i].Value = cmbPMCOC.Text;
                            dgPMMaster["Packing", i].Value = ChkPacking.Checked;
                            dgPMMaster["Micro", i].Value = ChkMicro.Checked;
                            dgPMMaster["physicochemical", i].Value = ChkPhysicochemical.Checked;
                            dgPMMaster["ValPMNoofLots", i].Value = txtPMNumberOfLots.Text;
                            dgPMMaster["ActualLots", i].Value = txtActualLots.Text;

                            if (rdbFGMark.Checked == true)
                                dgPMMaster["Mark", i].Value = "FG";
                            if (rdbSFMark.Checked == true)
                                dgPMMaster["Mark", i].Value = "sf";
                        }
                    }
                }
                btnFormulaReset_Click(sender, e);
                return;
            }
            else
            {
                if (CmbFGCode.Text == "--Select--" || CmbFGCode.Text == "")
                {
                    MessageBox.Show("Please Select FG Code ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgPMMaster.Rows.Add();
                dgPMMaster["FGNo", dgPMMaster.Rows.Count - 1].Value = CmbFGCode.SelectedValue.ToString();
                dgPMMaster["FGCode", dgPMMaster.Rows.Count - 1].Value = CmbFGCode.Text;
                dgPMMaster["ValPMCOC", dgPMMaster.Rows.Count - 1].Value = cmbPMCOC.Text;
                dgPMMaster["Packing", dgPMMaster.Rows.Count - 1].Value = ChkPacking.Checked;
                dgPMMaster["Micro", dgPMMaster.Rows.Count - 1].Value = ChkMicro.Checked;
                dgPMMaster["physicochemical", dgPMMaster.Rows.Count - 1].Value = ChkPhysicochemical.Checked;
                dgPMMaster["ValPMNoofLots", dgPMMaster.Rows.Count - 1].Value = txtPMNumberOfLots.Text;
                dgPMMaster["ActualLots", dgPMMaster.Rows.Count - 1].Value = txtActualLots.Text;

                if(rdbFGMark.Checked==true)
                    dgPMMaster["Mark", dgPMMaster.Rows.Count - 1].Value = "FG";
                if (rdbSFMark.Checked == true)
                    dgPMMaster["Mark", dgPMMaster.Rows.Count - 1].Value = "sf";
            }
            btnFormulaReset_Click(sender, e);
        }

        private void btnFormulaDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPMMaster.SelectedRows != null && dgPMMaster.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgPMMaster.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This FG Code..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            dgPMMaster.Rows.Remove(dgPMMaster.SelectedRows[i]);
                        }
                    }
                    //btnFGReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Please Select FG Code From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgPMMaster.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbPMCOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFGCode.SelectedValue == "0")
            {
                MessageBox.Show("Please Select FG Code ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbPMCOC.Text == "Yes")
            {
                ChkMicro.Enabled = true;
                ChkPacking.Enabled = true;
                ChkPhysicochemical.Enabled = true;

                bool resmicro;
                FGSupplierMaster_Class_obj.FGNo = Convert.ToInt32(CmbFGCode.SelectedValue);
                resmicro = FGSupplierMaster_Class_obj.Select_SPT_CheckMicroTest();
                if (resmicro == true)
                {
                    ChkMicro.Enabled = true;
                }
                else
                {
                    ChkMicro.Enabled = false;
                    ChkMicro.Checked = false;
                }
            }
            else
            {
                ChkMicro.Enabled = false;
                ChkPacking.Enabled = false;
                ChkPhysicochemical.Enabled = false;

                ChkMicro.Checked = false;
                ChkPacking.Checked = false;
                ChkPhysicochemical.Checked = false;
            }

            

        }

        private void dgPMMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPMMaster.Rows.Count > 0)
            {
                if (dgPMMaster.Rows[e.RowIndex].Cells["FGNo"].Value != null)
                {
                    CmbFGCode.SelectedValue = dgPMMaster["FGNo", e.RowIndex].Value.ToString();
                    cmbPMCOC.Text = dgPMMaster["ValPMCOC", e.RowIndex].Value.ToString();
                    ChkMicro.Checked = Convert.ToBoolean(dgPMMaster["Micro", e.RowIndex].Value);
                    ChkPacking.Checked = Convert.ToBoolean(dgPMMaster["Packing", e.RowIndex].Value);
                    ChkPhysicochemical.Checked = Convert.ToBoolean(dgPMMaster["physicochemical", e.RowIndex].Value);
                    txtActualLots.Text = dgPMMaster["ActualLots", e.RowIndex].Value.ToString();
                    txtPMNumberOfLots.Text = dgPMMaster["ValPMNoofLots", e.RowIndex].Value.ToString();

                    if (dgPMMaster["Mark", e.RowIndex].Value.ToString().ToLower() == "sf")
                        rdbSFMark.Checked = true;
                    if (dgPMMaster["Mark", e.RowIndex].Value.ToString().ToLower() == "fg")
                        rdbFGMark.Checked = true;

                    rownumber = e.RowIndex;
                }
            }
        }

        private void btnFormulaReset_Click(object sender, EventArgs e)
        {
            CmbFGCode.SelectedValue = 0;
            cmbPMCOC.SelectedText = "";
            ChkMicro.Checked = false;
            ChkPacking.Checked = false;
            ChkPhysicochemical.Checked = false;
            txtPMNumberOfLots.Text = "";
            txtActualLots.Text = "";
            cmbPMCOC_SelectedIndexChanged(sender, e);
            rownumber = -1;

            //rdbSFMark.Checked = false;
            //rdbFGMark.Checked = false;
        }

       
    }
}