using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Threading;
using System.Globalization;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmRMCodeMaster : System.Windows.Forms.Form
    {
        DataSet dsList = new DataSet();

        #region Variables
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        RMSupplierMaster_Class RMSupplierMaster_Class_obj = new RMSupplierMaster_Class();
        RMFamilyMaster_Class RMFamilyMaster_Class_obj = new RMFamilyMaster_Class();
        RMCodeMaster_Class RMCodeMaster_Class_obj = new RMCodeMaster_Class();
        BusinessFacade.Transactions.RMTransaction_Class RMTransaction_Class_Obj = new BusinessFacade.Transactions.RMTransaction_Class();
        bool modify = false;
        #endregion

        private static FrmRMCodeMaster frmRMCodeMaster_Obj = null;

        public static FrmRMCodeMaster GetInstance()
        {
            if (frmRMCodeMaster_Obj == null)
            {
                frmRMCodeMaster_Obj = new Forms.FrmRMCodeMaster();
            }
            return frmRMCodeMaster_Obj;
        }

        public FrmRMCodeMaster()
        {
            InitializeComponent();
        }

        private void BtnRMExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRMMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            Bind_RMSupplierMaster();
            Bind_RMFamilyMaster();
            Bind_List();
            Bind_Category();
            DtpCreationDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpModificationDate.Value = DtpCreationDate.Value;
            DtpMicroSpecDate.Value = DtpCreationDate.Value;
            DtpCreationDate.Checked = false;
            DtpModificationDate.Checked = false;
            DtpMicroSpecDate.Checked = false;
            cmbAlignemnt.SelectedIndex = 0;
            cmbHalal.SelectedIndex = 0;
            cmbPlantOrigin.SelectedIndex = 0;

            ChkCategory.HorizontalScrollbar = true;
        }
        public void Bind_RMSupplierMaster()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = RMSupplierMaster_Class_obj.Select_RMSupplierMaster();
                dr = ds.Tables[0].NewRow();
                dr["RMSupplierName"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count >= 0)
                {
                    cmbRMSupplierName.DataSource = ds.Tables[0];
                    cmbRMSupplierName.DisplayMember = "RMSupplierName";
                    cmbRMSupplierName.ValueMember = "RMSupplierID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        DataSet dsRMCategoryDetails = new DataSet();
        public void Bind_Category()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = RMCodeMaster_Class_obj.Select_RMCategory();
                dsRMCategoryDetails = ds;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ChkCategory.DataSource = ds.Tables[0];
                    ChkCategory.DisplayMember = "RMCategory";
                    ChkCategory.ValueMember = "RMCid";
                }

                //dsList = RMCodeMaster_Class_obj.Select_RMCategory();
                //if (dsList.Tables[0].Rows.Count >= 0)
                //{
                //    List.DataSource = dsList.Tables[0];
                //    List.DisplayMember = "RMCode";
                //    List.ValueMember = "RMCodeID";
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Bind_List()
        {
            try
            {

                dsList = RMCodeMaster_Class_obj.Select_RMCodeMaster();
                if (dsList.Tables[0].Rows.Count >= 0)
                {
                    List.DataSource = dsList.Tables[0];
                    List.DisplayMember = "RMCode";
                    List.ValueMember = "RMCodeID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Bind_RMFamilyMaster()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = RMFamilyMaster_Class_obj.Select_RMFamilyMaster();
                dr = ds.Tables[0].NewRow();
                dr["RMFamilyName"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count >= 0)
                {
                    cmbRMFamilyName.DataSource = ds.Tables[0];
                    cmbRMFamilyName.DisplayMember = "RMFamilyName";
                    cmbRMFamilyName.ValueMember = "RMFamilyID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnValRMSupplierAgentAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string PlantOrigin = string.Empty, Halal = string.Empty;
                if (cmbPlantOrigin.SelectedIndex != 0)
                    PlantOrigin = cmbPlantOrigin.Text;
                if (cmbHalal.SelectedIndex != 0)
                    Halal = cmbHalal.Text;
                if (txtRMCode.Text == "")
                {
                    MessageBox.Show("Please Enter RM Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRMCode.Focus();
                    return;
                }

                if (cmbRMSupplierName.Text == "--Select--" || cmbRMSupplierName.SelectedValue == null)
                {
                    MessageBox.Show("Please Select RM Supplier Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRMSupplierName.Focus();
                    return;
                }
                if (cmbAlignemnt.Text == "--Select--")
                {
                    MessageBox.Show("Please select if aligned", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbAlignemnt.Focus();
                    return;
                }

                //if (txtRMAgentName.Text.Trim() == "")
                //{
                //    MessageBox.Show("Please Enter RM Agent", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtRMAgentName.Focus();
                //    return;
                //}

                if (BtnValRMSupplierAgentAdd.Text == "Update")
                {
                    int indx = 0;
                    indx = Convert.ToInt32(BtnValRMSupplierAgentAdd.Tag.ToString());
                    for (int i = 0; i < dgRMSupplierAgent.Rows.Count; i++)
                    {
                        if (dgRMSupplierAgent["ValRMSupplierName", i].Value.ToString() == cmbRMSupplierName.Text && dgRMSupplierAgent["ValRMAgentName", i].Value.ToString() == txtRMAgentName.Text.Trim() && dgRMSupplierAgent["Alignment", i].Value.ToString() == cmbAlignemnt.Text && dgRMSupplierAgent["Halal", i].Value.ToString() == cmbHalal.Text && dgRMSupplierAgent["PlantOrigin", i].Value.ToString() == cmbPlantOrigin.Text && dgRMSupplierAgent["countryoforigin", i].Value.ToString() == txtOrigin.Text)
                        {
                            MessageBox.Show("This record Exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //MessageBox.Show("Record Updated...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbRMSupplierName.Focus();
                            return;
                        }
                    }
                    for (int i = 0; i < dgRMSupplierAgent.Rows.Count; i++)
                    {

                        if (dgRMSupplierAgent["ValRMSupplierName", i].Value.ToString() == cmbRMSupplierName.Text && dgRMSupplierAgent["ValRMAgentName", i].Value.ToString() == txtRMAgentName.Text.Trim() && i != indx)
                        {
                            MessageBox.Show("This Supplier - Agent Already Exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbRMSupplierName.Focus();
                            return;
                        }
                    }

                    dgRMSupplierAgent.Rows[indx].Cells["ValRMSupplierName"].Value = cmbRMSupplierName.Text;
                    dgRMSupplierAgent.Rows[indx].Cells["ValSupplierID"].Value = Convert.ToInt64(cmbRMSupplierName.SelectedValue.ToString());
                    dgRMSupplierAgent.Rows[indx].Cells["Alignment"].Value = cmbAlignemnt.Text;
                    dgRMSupplierAgent.Rows[indx].Cells["ValRMAgentName"].Value = txtRMAgentName.Text;
                    dgRMSupplierAgent.Rows[indx].Cells["NoOFLot"].Value = txtNoOfLots.Text;
                    dgRMSupplierAgent.Rows[indx].Cells["PlantOrigin"].Value = PlantOrigin;
                    dgRMSupplierAgent.Rows[indx].Cells["Halal"].Value = Halal;
                    dgRMSupplierAgent.Rows[indx].Cells["countryoforigin"].Value = txtOrigin.Text;
                    dgRMSupplierAgent.Rows[indx].Cells["Barcode"].Value = txtBarcode.Text;
                    dgRMSupplierAgent.Rows[indx].Cells["TradeName"].Value = txtTradeName.Text;
                }
                else
                {
                    for (int i = 0; i < dgRMSupplierAgent.Rows.Count; i++)
                    {
                        if (dgRMSupplierAgent["ValRMSupplierName", i].Value.ToString() == cmbRMSupplierName.Text && dgRMSupplierAgent["ValRMAgentName", i].Value.ToString() == txtRMAgentName.Text.Trim())
                        {
                            MessageBox.Show("This Supplier - Agent Already Exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbRMSupplierName.Focus();
                            return;
                        }
                    }

                    dgRMSupplierAgent.Rows.Add(Convert.ToInt64(cmbRMSupplierName.SelectedValue.ToString()), cmbRMSupplierName.Text.ToString(), cmbAlignemnt.Text, txtRMAgentName.Text.Trim(), txtNoOfLots.Text, Halal, PlantOrigin, txtOrigin.Text.Trim(), txtBarcode.Text.Trim(), txtTradeName.Text.Trim());
                }
                //dgRMSupplierAgent["ValRMSupplierName", dgRMSupplierAgent.Rows.Count - 1].Value = cmbRMSupplierName.Text.ToString();
                //dgRMSupplierAgent["ValRMAgentName", dgRMSupplierAgent.Rows.Count - 1].Value = txtRMAgentName.Text.Trim();
                //dgRMSupplierAgent["ValSupplierID", dgRMSupplierAgent.Rows.Count - 1].Value = Convert.ToInt64(cmbRMSupplierName.SelectedValue.ToString());
                txtRMAgentName.Text = "";
                txtBarcode.Text = "";
                cmbRMSupplierName.SelectedIndex = 0;
                cmbAlignemnt.SelectedIndex = 0;
                cmbHalal.SelectedIndex = 0;
                txtOrigin.Text = string.Empty;
                cmbPlantOrigin.SelectedIndex = 0;
                txtNoOfLots.Text = "0";
                txtBarcode.Text = "";
                txtTradeName.Text = "";
                BtnValRMSupplierAgentAdd.Text = "&Add";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRMSupplierAgentDelete_Click(object sender, EventArgs e)
        {

            try
            {

                if (dgRMSupplierAgent.SelectedRows != null && dgRMSupplierAgent.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgRMSupplierAgent.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {

                            RMCodeMaster_Class_obj.rmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                            RMCodeMaster_Class_obj.rmsupplierid = Convert.ToInt64(dgRMSupplierAgent["ValSupplierID", dgRMSupplierAgent.SelectedRows[i].Index].Value);
                            RMCodeMaster_Class_obj.rmagentname = txtRMAgentName.Text.ToString().Trim();
                            //bool b = RMCodeMaster_Class_obj.Delete_RMSupplierAgentMaster_RMCodeID_RMSupplierID_RMAgentName();

                            dgRMSupplierAgent.Rows.Remove(dgRMSupplierAgent.SelectedRows[i]);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select Record to Delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Sorry Cannot Delete this Record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnRMReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            Bind_Category();
            txtNoOfLots.Text = "";
            txtSearch.Text = "";
            txtRMCode.Text = "";
            txtRMDescription.Text = "";
            txtRMSpecification.Text = "";
            BtnRMCodeReset_Click(sender, e);
            txtINCIName.Text = "";
            cmbRMFamilyName.SelectedIndex = 0;
            dgRMSupplierAgent.Rows.Clear();
            BtnRMModify.Enabled = false;
            BtnRMDelete.Enabled = false;
            chkFDADone.Checked = false;
            ChkMicrobiologyTest.Checked = false;
            ChkPreservativeTest.Checked = false;
            txtMicroNorms.Visible = false;
            labelNorms.Visible = false;
            DtpCreationDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpModificationDate.Value = DtpCreationDate.Value;
            DtpMicroSpecDate.Value = DtpCreationDate.Value;
            DtpCreationDate.Checked = false;
            DtpModificationDate.Checked = false;
            DtpMicroSpecDate.Checked = false;
            rdBtnPHIncrease.Checked = false;
            rdBtnPHDecrease.Checked = false;
            rdBtnViscosityIncrease.Checked = false;
            rdBtnViscosityDecrease.Checked = false;
            txtRMCodeNoOfLot.Text = "";
            txtNoOfLots.Text = "";
            txtBarcode.Text = "";
            txtTradeName.Text = "";
            modify = false;
            BtnRMSave.Enabled = true;

            for (int i = 0; i < ChkCategory.Items.Count; i++)
            {
                if (ChkCategory.GetItemChecked(i) == true)
                {
                    ChkCategory.SetItemChecked(i, false);

                }
            }
        }

        private void BtnRMSave_Click(object sender, EventArgs e)
        {

            try
            {
                RMCodeMaster_Class_obj.phflag = null;
                RMCodeMaster_Class_obj.viscosityflag = null;
                if (txtRMCode.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Raw Material Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRMCode.Focus();
                    return;
                }
                //if (txtRMDescription.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter Raw Material Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtRMDescription.Focus();
                //    return;
                //}

                if (cmbRMFamilyName.Text.Trim() == "--Select--")
                {
                    MessageBox.Show("Enter Raw Material Family Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRMFamilyName.Focus();
                    return;
                }

                if (cmbRMFamilyName.SelectedValue == null)
                {
                    MessageBox.Show("Please Select Proper RM Family", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRMFamilyName.Focus();
                    return;
                }

                //if (dgRMSupplierAgent.Rows.Count == 0)
                //{
                //    MessageBox.Show("Please Enter Supplier and Agent", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    cmbRMSupplierName.Focus();
                //    txtRMAgentName.Focus();
                //    return;
                //}

                RMCodeMaster_Class_obj.rmcode = txtRMCode.Text.Trim().ToString();
                RMCodeMaster_Class_obj.rmdescription = txtRMDescription.Text.Trim().ToString();
                RMCodeMaster_Class_obj.rminciname = txtINCIName.Text.Trim().ToString();
                RMCodeMaster_Class_obj.rmfamilyid = Convert.ToInt64(cmbRMFamilyName.SelectedValue);
                RMCodeMaster_Class_obj.rmspecification = txtRMSpecification.Text.Trim().ToString();
                RMCodeMaster_Class_obj.x3Barcode = txtX3Barcode.Text.Trim();
                RMCodeMaster_Class_obj.createdby = FrmMain.LoginID;
                RMCodeMaster_Class_obj.modifiedby = FrmMain.LoginID;
                if (ChkMicrobiologyTest.Checked == true)
                {
                    RMCodeMaster_Class_obj.micronorms = txtMicroNorms.Text.Trim();
                }
                else
                {
                    RMCodeMaster_Class_obj.micronorms = "";
                }

                if (DtpCreationDate.Checked == true)
                {
                    RMCodeMaster_Class_obj.creationdate = DtpCreationDate.Value.ToShortDateString();
                }
                else
                {
                    RMCodeMaster_Class_obj.creationdate = null;
                }
                if (DtpModificationDate.Checked == true)
                {
                    RMCodeMaster_Class_obj.modificationdate = DtpModificationDate.Value.ToShortDateString();
                }
                else
                {
                    RMCodeMaster_Class_obj.modificationdate = null;
                }
                if (ChkMicrobiologyTest.Checked == true && DtpMicroSpecDate.Checked == true)
                {
                    RMCodeMaster_Class_obj.microspecdate = DtpMicroSpecDate.Value.ToShortDateString();
                }
                else
                {
                    RMCodeMaster_Class_obj.microspecdate = null;
                }
                if (rdBtnPHIncrease.Checked == true)
                    RMCodeMaster_Class_obj.phflag = 1;
                else if (rdBtnPHDecrease.Checked == true)
                    RMCodeMaster_Class_obj.phflag = 0;
                //else
                //    RMCodeMaster_Class_obj.phflag = DBNull.Value;

                if (rdBtnViscosityIncrease.Checked == true)
                    RMCodeMaster_Class_obj.viscosityflag = 1;
                else if (rdBtnViscosityDecrease.Checked == true)
                    RMCodeMaster_Class_obj.viscosityflag = 0;
                //else
                //    RMCodeMaster_Class_obj.viscosityflag = DBNull.Value;

                if (modify == false)
                {

                    DataSet dscheckforduplicate = new DataSet();
                    RMCodeMaster_Class_obj.rmcode = txtRMCode.Text.Trim().ToString();
                    dscheckforduplicate = RMCodeMaster_Class_obj.Select_RMCodeMaster_RMCodeID();
                    if (dscheckforduplicate.Tables[0].Rows.Count == 0)
                    {
                        bool b = RMCodeMaster_Class_obj.Insert_RMCodeMaster();
                        DataSet ds = new DataSet();

                        ds = RMCodeMaster_Class_obj.Select_RMCodeMaster_RMCodeID();
                        for (int i = 0; i < dgRMSupplierAgent.Rows.Count; i++)
                        {
                            RMCodeMaster_Class_obj.rmcodeid = Convert.ToInt64(ds.Tables[0].Rows[0]["RMCodeID"]);
                            RMCodeMaster_Class_obj.rmagentname = Convert.ToString(dgRMSupplierAgent["ValRMAgentName", i].Value);
                            RMCodeMaster_Class_obj.rmsupplierid = Convert.ToInt64(dgRMSupplierAgent["ValSupplierID", i].Value);
                            RMCodeMaster_Class_obj.isAligned = dgRMSupplierAgent["Alignment", i].Value.ToString();
                            RMCodeMaster_Class_obj.halal = dgRMSupplierAgent["Halal", i].Value.ToString();
                            RMCodeMaster_Class_obj.plantOrigin = dgRMSupplierAgent["PlantOrigin", i].Value.ToString();
                            RMCodeMaster_Class_obj.countryoforigin = dgRMSupplierAgent["countryoforigin", i].Value.ToString();
                            RMCodeMaster_Class_obj.barcode = dgRMSupplierAgent["Barcode", i].Value.ToString();
                            RMCodeMaster_Class_obj.tradename = dgRMSupplierAgent["TradeName", i].Value.ToString();
                            RMCodeMaster_Class_obj.Insert_RMSupplierAgentMaster();
                        }
                        if (ds.Tables[0].Rows.Count > 0)
                            RMCodeMaster_Class_obj.rmcodeid = Convert.ToInt64(ds.Tables[0].Rows[0]["RMCodeID"]);
                        for (int i = 0; i < ChkCategory.Items.Count; i++)
                        {
                            if (ChkCategory.GetItemChecked(i) == true)
                            {
                                ChkCategory.SetSelected(i, true);
                                int obj = Convert.ToInt32(ChkCategory.SelectedValue);
                                RMCodeMaster_Class_obj.rmcategoryid = obj;

                                RMCodeMaster_Class_obj.INSERT_tblRMCodeLinkCategory();

                            }
                        }


                        if (b == true)
                        {
                            MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnRMReset_Click(sender, e);
                            Bind_List();
                            Bind_Category();
                        }
                    }
                    else
                    {
                        MessageBox.Show("RM Code Already Present", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtRMCode.Focus();
                        return;
                    }
                }
                else
                {


                    bool b = RMCodeMaster_Class_obj.Update_RMCodeMaster();
                    RMCodeMaster_Class_obj.rmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                    bool b2 = RMCodeMaster_Class_obj.Delete_RMSupplierAgentMaster_RMCodeID();

                    RMCodeMaster_Class_obj.DELETE_tblRMCodeLinkCategory();
                    for (int i = 0; i < ChkCategory.Items.Count; i++)
                    {
                        if (ChkCategory.GetItemChecked(i) == true)
                        {
                            ChkCategory.SetSelected(i, true);
                            int obj = Convert.ToInt32(ChkCategory.SelectedValue);
                            RMCodeMaster_Class_obj.rmcategoryid = obj;

                            RMCodeMaster_Class_obj.INSERT_tblRMCodeLinkCategory();

                        }
                    }

                    //for (int i = 0; i < dgRMSupplierAgent.Rows.Count; i++)
                    //{

                    //    RMCodeMaster_Class_obj.rmagentname = Convert.ToString(dgRMSupplierAgent["ValRMAgentName", i].Value);
                    //    RMCodeMaster_Class_obj.rmsupplierid = Convert.ToInt64(dgRMSupplierAgent["ValSupplierID", i].Value);
                    //    bool b2 = RMCodeMaster_Class_obj.Delete_RMSupplierAgentMaster_RMCodeID_RMSupplierID_RMAgentName();
                    //    //RMCodeMaster_Class_obj.Insert_RMSupplierAgentMaster();
                    //}
                    for (int i = 0; i < dgRMSupplierAgent.Rows.Count; i++)
                    {

                        RMCodeMaster_Class_obj.rmagentname = Convert.ToString(dgRMSupplierAgent["ValRMAgentName", i].Value);
                        RMCodeMaster_Class_obj.rmsupplierid = Convert.ToInt64(dgRMSupplierAgent["ValSupplierID", i].Value);
                        RMCodeMaster_Class_obj.isAligned = dgRMSupplierAgent["Alignment", i].Value.ToString();
                        RMCodeMaster_Class_obj.halal = dgRMSupplierAgent["Halal", i].Value.ToString();
                        RMCodeMaster_Class_obj.plantOrigin = dgRMSupplierAgent["PlantOrigin", i].Value.ToString();
                        RMCodeMaster_Class_obj.countryoforigin = dgRMSupplierAgent["countryoforigin", i].Value.ToString();
                        RMCodeMaster_Class_obj.barcode = Convert.ToString(dgRMSupplierAgent["Barcode", i].Value);
                        RMCodeMaster_Class_obj.tradename = dgRMSupplierAgent["TradeName", i].Value.ToString();
                        RMCodeMaster_Class_obj.Insert_RMSupplierAgentMaster();
                    }

                    if (b == true)
                    {
                        MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnRMReset_Click(sender, e);
                        modify = false;
                        Bind_List();
                        Bind_Category();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void BtnRMModify_Click(object sender, EventArgs e)
        {
            modify = true;
            BtnRMDelete.Enabled = true;
            BtnRMModify.Enabled = false;
            //List_DoubleClick(sender, e);
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {

            for (int i = 0; i < ChkCategory.Items.Count; i++)
            {
                if (ChkCategory.GetItemChecked(i) == true)
                {
                    ChkCategory.SetItemChecked(i, false);

                }
            }
            // txtSearch.Text = Convert.ToString(List.Text);
            BtnRMModify.Enabled = true;
            BtnRMDelete.Enabled = true;
            dgRMSupplierAgent.Rows.Clear();
            BtnRMCodeReset_Click(sender, e);
            txtRMCode.Text = List.Text.Trim();
            txtNoOfLots.Text = "0";
            cmbAlignemnt.SelectedIndex = 0;
            DataSet ds = new DataSet();
            RMCodeMaster_Class_obj.rmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
            RMTransaction_Class_Obj.rmcodeid = Convert.ToInt64(List.SelectedValue.ToString());

            ds = RMCodeMaster_Class_obj.Select_RMCodeMaster_RMCode();

            txtINCIName.Text = ds.Tables[0].Rows[0]["RMINCIName"].ToString();
            txtRMDescription.Text = ds.Tables[0].Rows[0]["RMDescription"].ToString();
            txtRMSpecification.Text = ds.Tables[0].Rows[0]["RMSpecification"].ToString();
            cmbRMFamilyName.Text = ds.Tables[0].Rows[0]["RMFamilyName"].ToString();
            txtRMCodeNoOfLot.Text = ds.Tables[0].Rows[0]["LotCount"].ToString();
            txtX3Barcode.Text = Convert.ToString(ds.Tables[0].Rows[0]["X3Barcode"]);
            if (Convert.ToString(ds.Tables[0].Rows[0]["PreservativeTest"]) == "" || Convert.ToInt16(ds.Tables[0].Rows[0]["PreservativeTest"]) == 0)
            {
                ChkPreservativeTest.Checked = false;
            }
            else if (Convert.ToInt16(ds.Tables[0].Rows[0]["PreservativeTest"]) == 1)
            {
                ChkPreservativeTest.Checked = true;
            }

            if (Convert.ToString(ds.Tables[0].Rows[0]["MicrobiologyTest"]) == "" || Convert.ToInt16(ds.Tables[0].Rows[0]["MicrobiologyTest"]) == 0)
            {
                ChkMicrobiologyTest.Checked = false;
                labelNorms.Visible = false;
                txtMicroNorms.Visible = false;
                lblMicroSpecDate.Visible = false;
                DtpMicroSpecDate.Visible = false;
                txtMicroNorms.Text = "";
            }
            else if (Convert.ToInt16(ds.Tables[0].Rows[0]["MicrobiologyTest"]) == 1)
            {
                ChkMicrobiologyTest.Checked = true;
                labelNorms.Visible = true;
                txtMicroNorms.Visible = true;
                lblMicroSpecDate.Visible = true;
                DtpMicroSpecDate.Visible = true;
                txtMicroNorms.Text = ds.Tables[0].Rows[0]["MicroNorms"].ToString();

                if (ds.Tables[0].Rows[0]["MicroSpecDate"] is System.DBNull)
                {
                    DtpMicroSpecDate.Value = Comman_Class_Obj.Select_ServerDate();
                    DtpMicroSpecDate.Checked = false;
                }
                else
                {
                    DtpMicroSpecDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["MicroSpecDate"].ToString());
                }
            }


            if (Convert.ToString(ds.Tables[0].Rows[0]["FDADone"]) == "" || Convert.ToInt16(ds.Tables[0].Rows[0]["FDADone"]) == 0)
            {
                chkFDADone.Checked = false;
            }
            else if (Convert.ToInt16(ds.Tables[0].Rows[0]["FDADone"]) == 1)
            {
                chkFDADone.Checked = true;
            }

            if (ds.Tables[0].Rows[0]["CreationDate"] is System.DBNull)
            {
                DtpCreationDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpCreationDate.Checked = false;
            }
            else
            {
                DtpCreationDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreationDate"].ToString());
            }

            if (ds.Tables[0].Rows[0]["ModificationDate"] is System.DBNull)
            {
                DtpModificationDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpModificationDate.Checked = false;
            }
            else
            {
                DtpModificationDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ModificationDate"].ToString());
            }
            if (ds.Tables[0].Rows[0]["PHFlag"] != null && ds.Tables[0].Rows[0]["PHFlag"].ToString() != "")
            {
                if ((Convert.ToInt16(ds.Tables[0].Rows[0]["PHFlag"])) == 1)
                    rdBtnPHIncrease.Checked = true;
                else
                    rdBtnPHDecrease.Checked = true;
            }
            else
            {
                rdBtnPHIncrease.Checked = false;
                rdBtnPHDecrease.Checked = false;
            }
            if (ds.Tables[0].Rows[0]["ViscosityFlag"] != null && ds.Tables[0].Rows[0]["ViscosityFlag"].ToString() != "")
            {
                if ((Convert.ToInt16(ds.Tables[0].Rows[0]["ViscosityFlag"])) == 1)
                    rdBtnViscosityIncrease.Checked = true;
                else
                    rdBtnViscosityIncrease.Checked = true;
            }
            else
            {
                rdBtnViscosityIncrease.Checked = false;
                rdBtnViscosityIncrease.Checked = false;
            }

            DataSet dsforsupplieragent = new DataSet();
            //RMCodeMaster_Class_obj.rmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
            dsforsupplieragent = RMCodeMaster_Class_obj.Select_RMSupplierAgentMaster_RMSupplierMaster_RMCodeID2();
            if (dsforsupplieragent.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsforsupplieragent.Tables[0].Rows)
                {
                    dgRMSupplierAgent.Rows.Add(dr["RMSupplierID"], dr["RMSupplierName"], dr["IsAligned"], dr["RMAgentName"], dr["NO_OF_Lot"], dr["Halal"], dr["plantOrigin"], dr["countryoforigin"], dr["Barcode"], dr["TradeName"]);
                }

            }

            DataSet ds2 = new DataSet();
            ds2 = RMCodeMaster_Class_obj.Select_tblRMCodeLinkCategory_RMCodeID();
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < ChkCategory.Items.Count; j++)
                {
                    if (ds2.Tables[0].Rows[i]["RMCategory"].ToString() == ChkCategory.GetItemText(ChkCategory.Items[j]))
                    {
                        ChkCategory.SetItemChecked(j, true);
                        break;
                    }
                }
            }

            modify = true;

        }

        private void txtRMCode_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar < 65 || e.KeyChar > 90) &&
              (e.KeyChar < 97 || e.KeyChar > 122) && (e.KeyChar != 45) && e.KeyChar != 8 && e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13
              && e.KeyChar != 9)
            {

                e.Handled = true;

            }
            //try
            //{
            //    DataSet ds = new DataSet();
            //    if (e.KeyChar == 13)
            //    {
            //        RMCodeMaster_Class_obj.rmcode = txtRMCode.Text.Trim();
            //        ds = RMCodeMaster_Class_obj.Select_RMCodeMaster_RMCode();
            //        txtINCIName.Text = ds.Tables[0].Rows[0]["RMINCIName"].ToString();
            //        txtRMDescription.Text = ds.Tables[0].Rows[0]["RMDescription"].ToString();
            //        txtRMSpecification.Text = ds.Tables[0].Rows[0]["RMSpecification"].ToString();
            //        cmbRMFamilyName.Text = ds.Tables[0].Rows[0]["RMFamilyName"].ToString();
            //        if (ds.Tables[0].Rows[0]["RMMicro"].ToString() == "A")
            //        {
            //            cmbRMMicro.SelectedIndex = 1;
            //        }
            //        else
            //        {
            //            cmbRMMicro.SelectedIndex = 0;
            //        }
            //        if (ds.Tables[0].Rows[0]["RMType"].ToString() == "L")
            //        {
            //            cmbRMType.SelectedIndex = 0;
            //        }
            //        else
            //        {
            //            cmbRMType.SelectedIndex = 1;
            //        }


            //    }
            //}
            //catch 
            //{
            //    MessageBox.Show("Record not found","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
        }

        private void BtnRMDelete_Click(object sender, EventArgs e)
        {
            try
            {

                RMCodeMaster_Class_obj.rmcodeid = Convert.ToInt64(List.SelectedValue.ToString());

                if (RMCodeMaster_Class_obj.rmcode == "")
                {
                    MessageBox.Show("Please Select RM Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool b = RMCodeMaster_Class_obj.Delete_RMSupplierAgentMaster_RMCodeID();
                    bool b1 = RMCodeMaster_Class_obj.Delete_RMCodeMaster_RMCodeID();

                    if (b1 == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnRMReset_Click(sender, e);
                        Bind_List();
                        BtnRMDelete.Enabled = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Cannot Delete This Record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgRMSupplierAgent_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRMSupplierAgent.Rows.Count > 0)
            {
                if (dgRMSupplierAgent.Rows[e.RowIndex].Cells["ValRMSupplierName"].Value != null)
                {
                    cmbRMSupplierName.Text = dgRMSupplierAgent["ValRMSupplierName", e.RowIndex].Value.ToString();
                }
                if (dgRMSupplierAgent.Rows[e.RowIndex].Cells["ValRMAgentName"].Value != null)
                {
                    txtRMAgentName.Text = dgRMSupplierAgent["ValRMAgentName", e.RowIndex].Value.ToString();
                }

            }
        }

        private void BtnRMCodeReset_Click(object sender, EventArgs e)
        {
            cmbRMSupplierName.Text = "--Select--";
            cmbAlignemnt.SelectedIndex = 0;
            cmbHalal.SelectedIndex = 0;
            cmbPlantOrigin.SelectedIndex = 0;
            txtNoOfLots.Text = "";
            txtBarcode.Text = txtRMAgentName.Text = "";

            txtOrigin.Text = string.Empty;
            BtnValRMSupplierAgentAdd.Text = "&Add";

        }

        //private void txtRMCode_Leave(object sender, EventArgs e)
        //{
        //    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        //    TextInfo textInfo = cultureInfo.TextInfo;
        //    txtRMCode.Text = textInfo.ToTitleCase(txtRMCode.Text);	
        //}

        private void ChkPreservativeTest_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPreservativeTest.CheckState == CheckState.Checked)
            {
                RMCodeMaster_Class_obj.preservativetest = 1;
            }
            if (ChkPreservativeTest.CheckState == CheckState.Unchecked)
            {
                RMCodeMaster_Class_obj.preservativetest = 0;

            }
        }

        private void ChkMicrobiologyTest_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkMicrobiologyTest.CheckState == CheckState.Checked)
            {
                RMCodeMaster_Class_obj.microbiologytest = 1;
                labelNorms.Visible = true;
                txtMicroNorms.Visible = true;
                lblMicroSpecDate.Visible = true;
                DtpMicroSpecDate.Visible = true;
                txtMicroNorms.Focus();
            }
            else if (ChkMicrobiologyTest.CheckState == CheckState.Unchecked)
            {
                RMCodeMaster_Class_obj.microbiologytest = 0;
                labelNorms.Visible = false;
                txtMicroNorms.Visible = false;
                lblMicroSpecDate.Visible = false;
                DtpMicroSpecDate.Visible = false;
                txtMicroNorms.Text = "";
                DtpMicroSpecDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpMicroSpecDate.Checked = false;
            }

        }

        private void chkFDADone_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFDADone.CheckState == CheckState.Checked)
            {
                RMCodeMaster_Class_obj.fdadone = 1;
            }
            if (chkFDADone.CheckState == CheckState.Unchecked)
            {
                RMCodeMaster_Class_obj.fdadone = 0;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "RMCode like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "RMCode";
            List.ValueMember = "RMCodeID";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSearch.Text = Convert.ToString(List.Text);
                BtnRMModify.Enabled = true;
                BtnRMDelete.Enabled = true;
                dgRMSupplierAgent.Rows.Clear();
                BtnRMCodeReset_Click(sender, e);
                txtRMCode.Text = List.Text.Trim();

                DataSet ds = new DataSet();
                RMCodeMaster_Class_obj.rmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                ds = RMCodeMaster_Class_obj.Select_RMCodeMaster_RMCode();
                txtINCIName.Text = ds.Tables[0].Rows[0]["RMINCIName"].ToString();
                txtRMDescription.Text = ds.Tables[0].Rows[0]["RMDescription"].ToString();
                txtRMSpecification.Text = ds.Tables[0].Rows[0]["RMSpecification"].ToString();
                cmbRMFamilyName.Text = ds.Tables[0].Rows[0]["RMFamilyName"].ToString();
                if (Convert.ToString(ds.Tables[0].Rows[0]["PreservativeTest"]) == "" || Convert.ToInt16(ds.Tables[0].Rows[0]["PreservativeTest"]) == 0)
                {
                    ChkPreservativeTest.Checked = false;
                }
                else if (Convert.ToInt16(ds.Tables[0].Rows[0]["PreservativeTest"]) == 1)
                {
                    ChkPreservativeTest.Checked = true;
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["MicrobiologyTest"]) == "" || Convert.ToInt16(ds.Tables[0].Rows[0]["MicrobiologyTest"]) == 0)
                {
                    ChkMicrobiologyTest.Checked = false;
                    labelNorms.Visible = false;
                    txtMicroNorms.Visible = false;
                    lblMicroSpecDate.Visible = false;
                    DtpMicroSpecDate.Visible = false;
                    txtMicroNorms.Text = "";
                }
                else if (Convert.ToInt16(ds.Tables[0].Rows[0]["MicrobiologyTest"]) == 1)
                {
                    ChkMicrobiologyTest.Checked = true;
                    labelNorms.Visible = true;
                    txtMicroNorms.Visible = true;
                    lblMicroSpecDate.Visible = true;
                    DtpMicroSpecDate.Visible = true;
                    txtMicroNorms.Text = ds.Tables[0].Rows[0]["MicroNorms"].ToString();

                    if (ds.Tables[0].Rows[0]["MicroSpecDate"] is System.DBNull)
                    {
                        DtpMicroSpecDate.Value = Comman_Class_Obj.Select_ServerDate();
                        DtpMicroSpecDate.Checked = false;
                    }
                    else
                    {
                        DtpMicroSpecDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["MicroSpecDate"].ToString());
                    }
                }


                if (Convert.ToString(ds.Tables[0].Rows[0]["FDADone"]) == "" || Convert.ToInt16(ds.Tables[0].Rows[0]["FDADone"]) == 0)
                {
                    chkFDADone.Checked = false;
                }
                else if (Convert.ToInt16(ds.Tables[0].Rows[0]["FDADone"]) == 1)
                {
                    chkFDADone.Checked = true;
                }

                if (ds.Tables[0].Rows[0]["CreationDate"] is System.DBNull)
                {
                    DtpCreationDate.Value = Comman_Class_Obj.Select_ServerDate();
                    DtpCreationDate.Checked = false;
                }
                else
                {
                    DtpCreationDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreationDate"].ToString());
                }

                if (ds.Tables[0].Rows[0]["ModificationDate"] is System.DBNull)
                {
                    DtpModificationDate.Value = Comman_Class_Obj.Select_ServerDate();
                    DtpModificationDate.Checked = false;
                }
                else
                {
                    DtpModificationDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ModificationDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PHFlag"] != null && ds.Tables[0].Rows[0]["PHFlag"].ToString() != "")
                {
                    if ((Convert.ToInt16(ds.Tables[0].Rows[0]["PHFlag"])) == 1)
                        rdBtnPHIncrease.Checked = true;
                    else
                        rdBtnPHDecrease.Checked = true;
                }
                else
                {
                    rdBtnPHIncrease.Checked = false;
                    rdBtnPHDecrease.Checked = false;
                }
                if (ds.Tables[0].Rows[0]["ViscosityFlag"] != null && ds.Tables[0].Rows[0]["ViscosityFlag"].ToString() != "")
                {
                    if ((Convert.ToInt16(ds.Tables[0].Rows[0]["ViscosityFlag"])) == 1)
                        rdBtnViscosityIncrease.Checked = true;
                    else
                        rdBtnViscosityIncrease.Checked = true;
                }
                else
                {
                    rdBtnViscosityIncrease.Checked = false;
                    rdBtnViscosityIncrease.Checked = false;
                }

                DataSet dsforsupplieragent = new DataSet();
                //RMCodeMaster_Class_obj.rmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                dsforsupplieragent = RMCodeMaster_Class_obj.Select_RMSupplierAgentMaster_RMSupplierMaster_RMCodeID();
                if (dsforsupplieragent.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dsforsupplieragent.Tables[0].Rows.Count; i++)
                    {
                        dgRMSupplierAgent.Rows.Add();
                        dgRMSupplierAgent["ValRMSupplierName", i].Value = dsforsupplieragent.Tables[0].Rows[i]["RMSupplierName"].ToString();
                        dgRMSupplierAgent["ValRMAgentName", i].Value = dsforsupplieragent.Tables[0].Rows[i]["RMAgentName"].ToString();
                        dgRMSupplierAgent["ValSupplierID", i].Value = Convert.ToInt64(dsforsupplieragent.Tables[0].Rows[i]["RMSupplierID"].ToString());
                    }
                }

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
                BtnRMModify.Enabled = true;
                BtnRMDelete.Enabled = true;
                dgRMSupplierAgent.Rows.Clear();
                BtnRMCodeReset_Click(sender, e);
                txtRMCode.Text = List.Text.Trim();

                DataSet ds = new DataSet();
                RMCodeMaster_Class_obj.rmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                ds = RMCodeMaster_Class_obj.Select_RMCodeMaster_RMCode();
                txtINCIName.Text = ds.Tables[0].Rows[0]["RMINCIName"].ToString();
                txtRMDescription.Text = ds.Tables[0].Rows[0]["RMDescription"].ToString();
                txtRMSpecification.Text = ds.Tables[0].Rows[0]["RMSpecification"].ToString();
                cmbRMFamilyName.Text = ds.Tables[0].Rows[0]["RMFamilyName"].ToString();
                if (Convert.ToString(ds.Tables[0].Rows[0]["PreservativeTest"]) == "" || Convert.ToInt16(ds.Tables[0].Rows[0]["PreservativeTest"]) == 0)
                {
                    ChkPreservativeTest.Checked = false;
                }
                else if (Convert.ToInt16(ds.Tables[0].Rows[0]["PreservativeTest"]) == 1)
                {
                    ChkPreservativeTest.Checked = true;
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["MicrobiologyTest"]) == "" || Convert.ToInt16(ds.Tables[0].Rows[0]["MicrobiologyTest"]) == 0)
                {
                    ChkMicrobiologyTest.Checked = false;
                    labelNorms.Visible = false;
                    txtMicroNorms.Visible = false;
                    lblMicroSpecDate.Visible = false;
                    DtpMicroSpecDate.Visible = false;
                    txtMicroNorms.Text = "";
                }
                else if (Convert.ToInt16(ds.Tables[0].Rows[0]["MicrobiologyTest"]) == 1)
                {
                    ChkMicrobiologyTest.Checked = true;
                    labelNorms.Visible = true;
                    txtMicroNorms.Visible = true;
                    lblMicroSpecDate.Visible = true;
                    DtpMicroSpecDate.Visible = true;
                    txtMicroNorms.Text = ds.Tables[0].Rows[0]["MicroNorms"].ToString();

                    if (ds.Tables[0].Rows[0]["MicroSpecDate"] is System.DBNull)
                    {
                        DtpMicroSpecDate.Value = Comman_Class_Obj.Select_ServerDate();
                        DtpMicroSpecDate.Checked = false;
                    }
                    else
                    {
                        DtpMicroSpecDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["MicroSpecDate"].ToString());
                    }
                }


                if (Convert.ToString(ds.Tables[0].Rows[0]["FDADone"]) == "" || Convert.ToInt16(ds.Tables[0].Rows[0]["FDADone"]) == 0)
                {
                    chkFDADone.Checked = false;
                }
                else if (Convert.ToInt16(ds.Tables[0].Rows[0]["FDADone"]) == 1)
                {
                    chkFDADone.Checked = true;
                }

                if (ds.Tables[0].Rows[0]["CreationDate"] is System.DBNull)
                {
                    DtpCreationDate.Value = Comman_Class_Obj.Select_ServerDate();
                    DtpCreationDate.Checked = false;
                }
                else
                {
                    DtpCreationDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreationDate"].ToString());
                }

                if (ds.Tables[0].Rows[0]["ModificationDate"] is System.DBNull)
                {
                    DtpModificationDate.Value = Comman_Class_Obj.Select_ServerDate();
                    DtpModificationDate.Checked = false;
                }
                else
                {
                    DtpModificationDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ModificationDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PHFlag"] != null && ds.Tables[0].Rows[0]["PHFlag"].ToString() != "")
                {
                    if ((Convert.ToInt16(ds.Tables[0].Rows[0]["PHFlag"])) == 1)
                        rdBtnPHIncrease.Checked = true;
                    else
                        rdBtnPHDecrease.Checked = true;
                }
                else
                {
                    rdBtnPHIncrease.Checked = false;
                    rdBtnPHDecrease.Checked = false;
                }
                if (ds.Tables[0].Rows[0]["ViscosityFlag"] != null && ds.Tables[0].Rows[0]["ViscosityFlag"].ToString() != "")
                {
                    if ((Convert.ToInt16(ds.Tables[0].Rows[0]["ViscosityFlag"])) == 1)
                        rdBtnViscosityIncrease.Checked = true;
                    else
                        rdBtnViscosityIncrease.Checked = true;
                }
                else
                {
                    rdBtnViscosityIncrease.Checked = false;
                    rdBtnViscosityIncrease.Checked = false;
                }

                DataSet dsforsupplieragent = new DataSet();
                //RMCodeMaster_Class_obj.rmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                dsforsupplieragent = RMCodeMaster_Class_obj.Select_RMSupplierAgentMaster_RMSupplierMaster_RMCodeID();
                if (dsforsupplieragent.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dsforsupplieragent.Tables[0].Rows.Count; i++)
                    {
                        dgRMSupplierAgent.Rows.Add();
                        dgRMSupplierAgent["ValRMSupplierName", i].Value = dsforsupplieragent.Tables[0].Rows[i]["RMSupplierName"].ToString();
                        dgRMSupplierAgent["ValRMAgentName", i].Value = dsforsupplieragent.Tables[0].Rows[i]["RMAgentName"].ToString();
                        dgRMSupplierAgent["ValSupplierID", i].Value = Convert.ToInt64(dsforsupplieragent.Tables[0].Rows[i]["RMSupplierID"].ToString());
                    }
                }

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                RMCodeMaster_Class objRMCodeMaster_Class = new RMCodeMaster_Class();
                DataSet ds = new DataSet();
                ds = objRMCodeMaster_Class.Select_All_Record_tblRMCodeMaster();

                ExportToExcel objExport = new ExportToExcel();
                objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbRMSupplierName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbAlignemnt.SelectedIndex = 0;
                txtNoOfLots.Text = "0";
                if (cmbRMSupplierName.SelectedIndex != 0)
                {
                    long x = 0;
                    RMTransaction_Class_Obj.rmsupplierid = Convert.ToInt64(cmbRMSupplierName.SelectedValue.ToString());
                    x = RMTransaction_Class_Obj.Select_NoOFLots();
                    txtNoOfLots.Text = Convert.ToString(x);
                }
            }
            catch
            {
                throw;
            }

        }

        private void dgRMSupplierAgent_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgRMSupplierAgent.CurrentRow.Cells["PlantOrigin"].Value.ToString() == string.Empty)
                    cmbPlantOrigin.SelectedIndex = 0;
                else
                    cmbPlantOrigin.Text = dgRMSupplierAgent.CurrentRow.Cells["PlantOrigin"].Value.ToString();
                if (dgRMSupplierAgent.CurrentRow.Cells["Halal"].Value.ToString() == string.Empty)
                    cmbHalal.SelectedIndex = 0;
                else
                    cmbHalal.Text = dgRMSupplierAgent.CurrentRow.Cells["Halal"].Value.ToString();
                cmbRMSupplierName.SelectedValue = Convert.ToInt64(dgRMSupplierAgent.CurrentRow.Cells["ValSupplierID"].Value.ToString());
                if (dgRMSupplierAgent.CurrentRow.Cells["Alignment"].Value.ToString() == "Aligned" || dgRMSupplierAgent.CurrentRow.Cells["Alignment"].Value.ToString() == "Not Aligned")
                {
                    cmbAlignemnt.SelectedItem = dgRMSupplierAgent.CurrentRow.Cells["Alignment"].Value.ToString();
                }
                txtRMAgentName.Text = dgRMSupplierAgent.CurrentRow.Cells["ValRMAgentName"].Value.ToString();
                txtNoOfLots.Text = dgRMSupplierAgent.CurrentRow.Cells["NoOFLot"].Value.ToString();
                txtOrigin.Text = dgRMSupplierAgent.CurrentRow.Cells["countryoforigin"].Value.ToString();
                txtBarcode.Text = Convert.ToString(dgRMSupplierAgent.CurrentRow.Cells["Barcode"].Value);

                BtnValRMSupplierAgentAdd.Text = "Update";
                BtnValRMSupplierAgentAdd.Tag = e.RowIndex;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void cmbPlantOrigin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}