using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmPMCodeMaster : System.Windows.Forms.Form
    {

        public FrmPMCodeMaster()
        {
            InitializeComponent();
        }

        #region Variables
        PMPeriodicTestMaster_Class PMPeriodicTestMaster_Class_obj = new PMPeriodicTestMaster_Class();
        PMMaster_Class PMMaster_Class_obj = new PMMaster_Class();
        PMTestMaster_Class PMTestMaster_Class_obj = new PMTestMaster_Class();
        DimensionParameter_Class DimensionParameter_Class_Obj = new DimensionParameter_Class();
        bool modify = false;
        bool supplieradd = false;
        #endregion

        DataSet dsList = new DataSet();
        bool isDoubleClick = false;
        BusinessFacade.Transactions.PMTransaction_Class PMTransaction_Class_obj = new BusinessFacade.Transactions.PMTransaction_Class();
        private static FrmPMCodeMaster frmPMMaster_Obj = null;

        public static FrmPMCodeMaster GetInstance()
        {
            if (frmPMMaster_Obj == null)
            {
                frmPMMaster_Obj = new Forms.FrmPMCodeMaster();
            }
            return frmPMMaster_Obj;
        }

        private void btnPMExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPMMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            cmbPMCOC.SelectedIndex = 0;
            Bind_List();
            Bind_Family();
            Bind_Supplier();
            btnPMDelete.Enabled = false;
        }

        public void Bind_List()
        {

            dsList = PMMaster_Class_obj.Select_PMMaster();
            if (dsList.Tables[0].Rows.Count > 0)
            {
                List.DataSource = dsList.Tables[0];
                List.DisplayMember = "PMCode";
                List.ValueMember = "PMCodeID";

            }
            else
            {
                List.DataSource = dsList.Tables[0];
                List.DisplayMember = "PMCode";
                List.ValueMember = "PMCodeID";
            }


        }

        public void Bind_Family()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = PMMaster_Class_obj.Select_PMFamilyMaster();
                dr = ds.Tables[0].NewRow();
                dr["PMFamilyName"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                CmbPMFamily.DataSource = ds.Tables[0];
                CmbPMFamily.DisplayMember = "PMFamilyName";
                CmbPMFamily.ValueMember = "PMFamilyID";


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_Supplier()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = PMMaster_Class_obj.Select_PMSupplierMaster();
                dr = ds.Tables[0].NewRow();
                dr["PMSupplierName"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cmbPMSupplierName.DataSource = ds.Tables[0];
                cmbPMSupplierName.DisplayMember = "PMSupplierName";
                cmbPMSupplierName.ValueMember = "PMSupplierID";


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPMSupplierCOCAdd_Click(object sender, EventArgs e)
        {

            supplieradd = true;
            if (txtPMCode.Text.ToString() == "")
            {
                MessageBox.Show("Please Enter Packaging Material Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbPMSupplierName.Text == "--Select--")
            {
                MessageBox.Show("Please Select Supplier Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < dgPMMaster.Rows.Count; i++)
            {
                if (dgPMMaster["ValPMSupplierNo", i].Value.ToString() == cmbPMSupplierName.SelectedValue.ToString())
                {
                    if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        dgPMMaster["ValPMSupplierNo", i].Value = cmbPMSupplierName.SelectedValue.ToString();
                        dgPMMaster["ValPMSupplierName", i].Value = cmbPMSupplierName.Text;
                        if (cmbPMCOC.Text == "No")
                        {
                            dgPMMaster["ValPMCOC", i].Value = Convert.ToChar("N");
                        }
                        else
                        {

                            dgPMMaster["ValPMCOC", i].Value = Convert.ToChar("Y");
                        }
                        dgPMMaster["ValPMNoofLots", i].Value = txtPMNumberOfLots.Text;

                    }
                    return;
                }
            }
            dgPMMaster.Rows.Add();
            dgPMMaster["ValPMSupplierNo", dgPMMaster.Rows.Count - 1].Value = cmbPMSupplierName.SelectedValue.ToString();
            dgPMMaster["ValPMSupplierName", dgPMMaster.Rows.Count - 1].Value = cmbPMSupplierName.Text;
            if (cmbPMCOC.Text == "No")
            {
                dgPMMaster["ValPMCOC", dgPMMaster.Rows.Count - 1].Value = Convert.ToChar("N");
            }
            else
            {

                dgPMMaster["ValPMCOC", dgPMMaster.Rows.Count - 1].Value = Convert.ToChar("Y");
            }
            dgPMMaster["ValPMNoofLots", dgPMMaster.Rows.Count - 1].Value = txtPMNumberOfLots.Text;

        }

        private void btnPMSupplierCOCReset_Click(object sender, EventArgs e)
        {

            cmbPMSupplierName.SelectedIndex = 0;
            txtPMNumberOfLots.Text = "";
            cmbPMCOC.SelectedIndex = 0;

        }

        private void btnPMSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();

                if (txtPMCode.Text.ToString() == "")
                {
                    MessageBox.Show("Please Enter PM Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtPMDescription.Text.ToString() == "")
                {
                    MessageBox.Show("Please Enter PM Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgPMMaster.Rows.Count == 0)
                {
                    MessageBox.Show("Please Fill All Details Associated with Supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CmbPMFamily.Text == "--Select--")
                {
                    MessageBox.Show("Please Select the Family Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                bool flag = false;
                PMMaster_Class_obj.pmcode = txtPMCode.Text.ToString();
                PMMaster_Class_obj.pmdescription = txtPMDescription.Text.ToString();
                PMMaster_Class_obj.pmfamilyid = Convert.ToInt64(CmbPMFamily.SelectedValue.ToString());
                PMMaster_Class_obj.createdby = FrmMain.LoginID;
                PMMaster_Class_obj.modifiedby = FrmMain.LoginID;
                DimensionParameter_Class_Obj.createdby = FrmMain.LoginID;
                DimensionParameter_Class_Obj.modifiedby = FrmMain.LoginID;
                if (modify == false)
                {
                    long PMCodeID = PMMaster_Class_obj.Insert_PMCodeMaster();
                    //PMMaster_Class_obj.pmcode = txtPMCode.Text.Trim().ToString();
                    //ds = PMMaster_Class_obj.Select_PMMaster_PMCode();
                    for (int i = 0; i < dgPMMaster.Rows.Count; i++)
                    {
                        PMMaster_Class_obj.pmcodeid = PMCodeID;//Convert.ToInt64(ds.Tables[0].Rows[0]["PMCodeID"]);
                        PMMaster_Class_obj.pmsupplierid = Convert.ToInt64(dgPMMaster["ValPMSupplierNo", i].Value);
                        PMMaster_Class_obj.cocapplicable = Convert.ToChar(dgPMMaster["ValPMCOC", i].Value);
                        PMMaster_Class_obj.nooflots = Convert.ToInt64(dgPMMaster["ValPMNoofLots", i].Value.ToString() == "" ? "0" : dgPMMaster["ValPMNoofLots", i].Value.ToString());

                        PMMaster_Class_obj.Insert_PMSupplierCOC();
                    }
                    foreach (DataGridViewRow row in dgPMPeriodicTest.Rows)
                    {
                        if (row.Cells["Mark"].Value != null && Convert.ToInt32(row.Cells["Mark"].Value) == 1)
                        {
                            PMMaster_Class_obj.pmcodeid = PMCodeID;
                            PMMaster_Class_obj.pmtestno = Convert.ToInt64(row.Cells["ValPMTestNo"].Value);
                            PMMaster_Class_obj.Insert_tblPMCodeFamilyTestRelation();
                        }

                    }

                    foreach (DimensionParameter_Class obj in GlobalVariables.lstDimensionNorm)
                    {

                        DimensionParameter_Class_Obj.pmCodeID = PMCodeID;
                        DimensionParameter_Class_Obj.pmfamilyid = obj.pmfamilyid;
                        DimensionParameter_Class_Obj.testNo = obj.testNo;
                        DimensionParameter_Class_Obj.dimensionParaID = obj.dimensionParaID;
                        DimensionParameter_Class_Obj.normsMin = obj.normsMin;
                        DimensionParameter_Class_Obj.normsMax = obj.normsMax;
                        //Check Exist norms in table tblPMFamilyDimensionMethodMaster 
                        DataTable dt = new DataTable();
                        dt = DimensionParameter_Class_Obj.Select_DimensionParaRelation_PMFamilyIDTestNodimensionParaID();
                        if (dt.Rows.Count > 0)
                            flag = DimensionParameter_Class_Obj.Update_PMFamilyDimensionMethodMaster();
                        else
                            flag = DimensionParameter_Class_Obj.Insert_PMFamilyDimensionMethodMaster();
                    }
                    if (PMCodeID > 0)
                    {
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bind_List();
                        btnPMReset_Click(sender, e);
                        isDoubleClick = false;

                    }
                }
                else
                {
                    bool b1 = PMMaster_Class_obj.Update_PMMaster();
                    //bool b2 = PMMaster_Class_obj.Delete_PMSupplierCOC();

                    for (int i = 0; i < dgPMMaster.Rows.Count; i++)
                    {
                        PMMaster_Class_obj.pmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                        PMMaster_Class_obj.pmsupplierid = Convert.ToInt64(dgPMMaster["ValPMSupplierNo", i].Value);
                        PMMaster_Class_obj.cocapplicable = Convert.ToChar(dgPMMaster["ValPMCOC", i].Value);
                        PMMaster_Class_obj.nooflots = Convert.ToInt64(dgPMMaster["ValPMNoofLots", i].Value.ToString() == "" ? "0" : dgPMMaster["ValPMNoofLots", i].Value.ToString()); ;

                        PMMaster_Class_obj.Insert_PMSupplierCOC();
                    }
                    PMMaster_Class_obj.Delete_tblPMCodeFamilyTestRelation_PMCodeID();// First Delete All record from tblPMCodeFamilyTestRelation related to PMCodeID then add new related PMCodeID
                    foreach (DataGridViewRow row in dgPMPeriodicTest.Rows)
                    {
                        if (row.Cells["Mark"].Value != null && Convert.ToInt32(row.Cells["Mark"].Value) == 1)
                        {
                            PMMaster_Class_obj.pmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                            PMMaster_Class_obj.pmtestno = Convert.ToInt64(row.Cells["ValPMTestNo"].Value);
                            PMMaster_Class_obj.Insert_tblPMCodeFamilyTestRelation();
                        }

                    }

                    foreach (DimensionParameter_Class obj in GlobalVariables.lstDimensionNorm)
                    {
                        DimensionParameter_Class_Obj.pmCodeID = Convert.ToInt64(List.SelectedValue.ToString());
                        DimensionParameter_Class_Obj.pmfamilyid = obj.pmfamilyid;
                        DimensionParameter_Class_Obj.testNo = obj.testNo;
                        DimensionParameter_Class_Obj.dimensionParaID = obj.dimensionParaID;
                        DimensionParameter_Class_Obj.normsMin = obj.normsMin;
                        DimensionParameter_Class_Obj.normsMax = obj.normsMax;
                        //Check Exist norms in table tblPMFamilyDimensionMethodMaster 
                        DataTable dt = new DataTable();
                        dt = DimensionParameter_Class_Obj.Select_DimensionParaRelation_PMFamilyIDTestNodimensionParaID();
                        if (dt.Rows.Count > 0)
                            flag = DimensionParameter_Class_Obj.Update_PMFamilyDimensionMethodMaster();
                        else
                            flag = DimensionParameter_Class_Obj.Insert_PMFamilyDimensionMethodMaster();
                    }

                    if (b1 == true)
                    {
                        MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bind_List();
                        btnPMReset_Click(sender, e);
                        isDoubleClick = false;

                    }
                }
                GlobalVariables.lstDimensionNorm.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Cannot Insert Duplicate Records", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnPMSupplierCOCDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgPMMaster.SelectedRows != null && dgPMMaster.SelectedRows.Count != 0)
                {

                    for (int i = 0; i < dgPMMaster.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {

                            PMMaster_Class_obj.pmsupplierid = Convert.ToInt64(dgPMMaster["ValPMSupplierNo", dgPMMaster.SelectedRows[i].Index].Value);
                            bool b = PMMaster_Class_obj.Delete_PMSupplierCOC();
                            dgPMMaster.Rows.Remove(dgPMMaster.SelectedRows[i]);
                        }
                    }
                }
                btnPMDelete.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Cannot Delete this Records", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPMReset_Click(object sender, EventArgs e)
        {
            isDoubleClick = false;
            Bind_List();
            txtSearch.Text = "";
            txtPMCode.Text = "";
            txtPMDescription.Text = "";
            CmbPMFamily.SelectedIndex = 0;
            cmbPMSupplierName.SelectedIndex = 0;
            txtPMNumberOfLots.Text = "";
            cmbPMCOC.SelectedIndex = 0;
            dgPMMaster.Rows.Clear();
            modify = false;
            btnPMSupplierCOCReset_Click(sender, e);
            if (CmbPMFamily.Text == "--Select--")
            {
                dgPMPeriodicTest.Rows.Clear();
            }

        }

        private void btnPMDelete_Click(object sender, EventArgs e)
        {
            try
            {
                PMMaster_Class_obj.pmcode = txtPMCode.Text.ToString();
                if (txtPMCode.Text == "")
                {
                    MessageBox.Show("Enter PM Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Are You Sure To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool b = PMMaster_Class_obj.Delete_PMSupplierCOC_PMCodeMaster();

                    if (b == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnPMReset_Click(sender, e);
                        Bind_List();
                    }
                }
                btnPMDelete.Enabled = false;

            }
            catch
            {
                MessageBox.Show("Cannot Delete this Record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnPMModify_Click(object sender, EventArgs e)
        {
            modify = true;
            btnPMSave.Enabled = true;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                //calculate Total no of lots per PMcode
                PMMaster_Class_obj.pmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                btnPMSave.Enabled = false;
                btnPMSupplierCOCReset_Click(sender, e);
                isDoubleClick = true;
                // btnPMReset_Click(sender, e);
                txtPMCode.Text = List.Text.ToString();
                DataSet ds = new DataSet();
                PMMaster_Class_obj.pmcode = List.Text.ToString();

                ds = PMMaster_Class_obj.Select_PMCodeMaster__PMSupplierMaster_PMCode();
                txtPMDescription.Text = ds.Tables[0].Rows[0]["PMDescription"].ToString();
                CmbPMFamily.Text = ds.Tables[0].Rows[0]["PMFamilyName"].ToString();
                CmbPMFamily_SelectionChangeCommitted(sender, e);//Show all test related to PM Family
                dgPMMaster.Rows.Clear();
                DataSet ds2 = new DataSet();
                ds2 = PMMaster_Class_obj.Select_PMCodeMaster_PMSupplierCOC_PMSupplierMaster_PMCode();
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        dgPMMaster.Rows.Add();
                        dgPMMaster["ValPMNoofLots", i].Value = ds2.Tables[0].Rows[i]["NoOfLots"].ToString();
                        dgPMMaster["ValPMCOC", i].Value = ds2.Tables[0].Rows[i]["COCApplicable"].ToString();
                        dgPMMaster["ValPMSupplierName", i].Value = ds2.Tables[0].Rows[i]["PMSupplierName"].ToString();
                        dgPMMaster["ValPMSupplierNo", i].Value = Convert.ToInt64(ds2.Tables[0].Rows[i]["PMSupplierID"].ToString());
                    }
                }
                DataTable Dt = new DataTable();
                Dt = PMMaster_Class_obj.Select_tblPMCodeFamilyTestRelation_PMCodeID();
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dgPMPeriodicTest.Rows.Count; j++)
                    {
                        if ((Convert.ToInt64(Dt.Rows[i]["TestNo"]) == Convert.ToInt64(dgPMPeriodicTest["ValPMTestNo", j].Value)))// && (Convert.ToString(Dt.Rows[i]["TestNo"]) == Convert.ToString(dgPMPeriodicTest["ValPMTestNo", j].Value)))
                            dgPMPeriodicTest["Mark", j].Value = 1;
                    }
                }
                btnPMDelete.Enabled = true;
                long icount = PMMaster_Class_obj.Select_PMNoOfLots(); //PMMaster_Class_obj.Select_NoOfLots_PMSupplierCOC();
                //icount = icount + 1;
                txtTotalNoOfLots.Text = Convert.ToString(icount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgPMMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPMMaster.Rows.Count > 0)
            {
                if (dgPMMaster.Rows[e.RowIndex].Cells["ValPMSupplierName"].Value != null)
                {
                    cmbPMSupplierName.Text = dgPMMaster["ValPMSupplierName", e.RowIndex].Value.ToString();
                }
                if (dgPMMaster.Rows[e.RowIndex].Cells["ValPMCOC"].Value != null)
                {
                    if (dgPMMaster["ValPMCOC", e.RowIndex].Value.ToString() == "Y")
                    {
                        cmbPMCOC.Text = "Yes";
                    }
                    else if (dgPMMaster["ValPMCOC", e.RowIndex].Value.ToString() == "N")
                    {
                        cmbPMCOC.Text = "No";
                    }

                }
                if (dgPMMaster.Rows[e.RowIndex].Cells["ValPMNoofLots"].Value != null)
                {
                    txtPMNumberOfLots.Text = dgPMMaster["ValPMNoofLots", e.RowIndex].Value.ToString();
                }
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbPMFamily_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((CmbPMFamily.SelectedValue.ToString() != null) && (CmbPMFamily.SelectedValue.ToString() != ""))
            {

                //int i = Convert.ToInt32(CmbPackingTechnicalFamily.SelectedValue.ToString());
                PMPeriodicTestMaster_Class_obj.pmfamilyid = Convert.ToInt64(CmbPMFamily.SelectedValue.ToString());

                Fill_dgPMPeriodicTest();


            }
            else if (CmbPMFamily.Text == "--Select--")
            {
                dgPMPeriodicTest.Rows.Clear();
            }
        }

        public void Fill_dgPMPeriodicTest()
        {
            dgPMPeriodicTest.Rows.Clear();
            DataSet ds = new DataSet();
            ds = PMPeriodicTestMaster_Class_obj.Select_PMFGTestMethodMaster_PMFamilyID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgPMPeriodicTest.Rows.Add();
                    dgPMPeriodicTest["ValPMTestNo", i].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                    dgPMPeriodicTest["ValPMTestMethod", i].Value = ds.Tables[0].Rows[i]["TestName"].ToString();
                    dgPMPeriodicTest["ValPMFrequency", i].Value = ds.Tables[0].Rows[i]["Frequency"].ToString();
                    //if (ds.Tables[0].Rows[i]["DimensionTest"].ToString() != "")
                    //{
                    //    if (Convert.ToBoolean(ds.Tables[0].Rows[i]["DimensionTest"]) == true)
                    //        dgPMPeriodicTest["DimensionTest", i].Value = "Test Applicable";
                    //    else
                    //        dgPMPeriodicTest["DimensionTest", i].Value = "Test Not Applicable";                     
                    //}
                    //else
                    //{
                    //    dgPMPeriodicTest["DimensionTest", i].Value = "Test Not Applicable";
                    //}

                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "PMCode like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "PMCode";
            List.ValueMember = "PMCodeID";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    //  btnPMReset_Click(sender, e);
                    txtPMCode.Text = List.Text.ToString();
                    DataSet ds = new DataSet();
                    PMMaster_Class_obj.pmcode = List.Text.ToString();
                    PMMaster_Class_obj.pmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                    ds = PMMaster_Class_obj.Select_PMCodeMaster__PMSupplierMaster_PMCode();
                    txtPMDescription.Text = ds.Tables[0].Rows[0]["PMDescription"].ToString();
                    CmbPMFamily.Text = ds.Tables[0].Rows[0]["PMFamilyName"].ToString();
                    CmbPMFamily_SelectionChangeCommitted(sender, e);//Show all test related to PM Family
                    dgPMMaster.Rows.Clear();
                    DataSet ds2 = new DataSet();
                    ds2 = PMMaster_Class_obj.Select_PMCodeMaster_PMSupplierCOC_PMSupplierMaster_PMCode();
                    if (ds2.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                        {
                            dgPMMaster.Rows.Add();
                            dgPMMaster["ValPMNoofLots", i].Value = ds2.Tables[0].Rows[i]["NoOfLots"].ToString();
                            dgPMMaster["ValPMCOC", i].Value = ds2.Tables[0].Rows[i]["COCApplicable"].ToString();
                            dgPMMaster["ValPMSupplierName", i].Value = ds2.Tables[0].Rows[i]["PMSupplierName"].ToString();
                            dgPMMaster["ValPMSupplierNo", i].Value = Convert.ToInt64(ds2.Tables[0].Rows[i]["PMSupplierID"].ToString());
                        }
                    }
                    DataTable Dt = new DataTable();
                    Dt = PMMaster_Class_obj.Select_tblPMCodeFamilyTestRelation_PMCodeID();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgPMPeriodicTest.Rows.Count; j++)
                        {
                            if ((Convert.ToInt64(Dt.Rows[i]["TestNo"]) == Convert.ToInt64(dgPMPeriodicTest["ValPMTestNo", j].Value)))// && (Convert.ToString(Dt.Rows[i]["TestNo"]) == Convert.ToString(dgPMPeriodicTest["ValPMTestNo", j].Value)))
                                dgPMPeriodicTest["Mark", j].Value = 1;
                        }
                    }
                    btnPMDelete.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                try
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    //  btnPMReset_Click(sender, e);
                    txtPMCode.Text = List.Text.ToString();
                    DataSet ds = new DataSet();
                    PMMaster_Class_obj.pmcode = List.Text.ToString();
                    PMMaster_Class_obj.pmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                    ds = PMMaster_Class_obj.Select_PMCodeMaster__PMSupplierMaster_PMCode();
                    txtPMDescription.Text = ds.Tables[0].Rows[0]["PMDescription"].ToString();
                    CmbPMFamily.Text = ds.Tables[0].Rows[0]["PMFamilyName"].ToString();
                    CmbPMFamily_SelectionChangeCommitted(sender, e);//Show all test related to PM Family
                    dgPMMaster.Rows.Clear();
                    DataSet ds2 = new DataSet();
                    ds2 = PMMaster_Class_obj.Select_PMCodeMaster_PMSupplierCOC_PMSupplierMaster_PMCode();
                    if (ds2.Tables[0].Rows.Count != 0)
                    {
                        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                        {
                            dgPMMaster.Rows.Add();
                            dgPMMaster["ValPMNoofLots", i].Value = ds2.Tables[0].Rows[i]["NoOfLots"].ToString();
                            dgPMMaster["ValPMCOC", i].Value = ds2.Tables[0].Rows[i]["COCApplicable"].ToString();
                            dgPMMaster["ValPMSupplierName", i].Value = ds2.Tables[0].Rows[i]["PMSupplierName"].ToString();
                            dgPMMaster["ValPMSupplierNo", i].Value = Convert.ToInt64(ds2.Tables[0].Rows[i]["PMSupplierID"].ToString());
                        }
                    }
                    DataTable Dt = new DataTable();
                    Dt = PMMaster_Class_obj.Select_tblPMCodeFamilyTestRelation_PMCodeID();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgPMPeriodicTest.Rows.Count; j++)
                        {
                            if ((Convert.ToInt64(Dt.Rows[i]["TestNo"]) == Convert.ToInt64(dgPMPeriodicTest["ValPMTestNo", j].Value)))// && (Convert.ToString(Dt.Rows[i]["TestNo"]) == Convert.ToString(dgPMPeriodicTest["ValPMTestNo", j].Value)))
                                dgPMPeriodicTest["Mark", j].Value = 1;
                        }
                    }
                    btnPMDelete.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                PMMaster_Class objPMMaster_Class = new PMMaster_Class();
                DataSet ds = new DataSet();
                ds = objPMMaster_Class.Select_All_Record_tblPMCodeMaster();

                ExportToExcel objExport = new ExportToExcel();
                objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgPMPeriodicTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgPMPeriodicTest.Columns["ValPMTestMethod"].Index)
                {
                    if ((dgPMPeriodicTest.CurrentRow.Cells["Mark"].Value != null) && (Convert.ToInt32(dgPMPeriodicTest.CurrentRow.Cells["Mark"].Value) == 1))
                    {
                        DataSet ds = new DataSet();
                        long pmFamilyID, PMCodeID = 0;
                        PMTestMaster_Class_obj.testno = Convert.ToInt64(dgPMPeriodicTest["ValPMTestNo", e.RowIndex].Value);
                        ds = PMTestMaster_Class_obj.Select_PMFGTestMaster_TestNo();


                        if (ds.Tables[0].Rows[0]["DimensionTest"].ToString() != "")
                        {
                            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["DimensionTest"]) == true)
                            {


                                if (CmbPMFamily.SelectedValue != null)
                                    pmFamilyID = Convert.ToInt64(CmbPMFamily.SelectedValue);
                                else
                                    pmFamilyID = 0;
                                if (List.SelectedValue != null && isDoubleClick)
                                {
                                    PMCodeID = Convert.ToInt64(List.SelectedValue);
                                    FrmDimension obj = new FrmDimension(PMCodeID, pmFamilyID, PMTestMaster_Class_obj.testno);
                                    obj.ShowDialog();
                                }
                                else
                                {
                                    FrmDimension obj = new FrmDimension(pmFamilyID, PMTestMaster_Class_obj.testno);
                                    obj.ShowDialog();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Dimension Test Not applicable", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Dimension Test Not applicable", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else //Check this test is applicable for the corresponding PM Code
                    {
                        MessageBox.Show("This Test is not applicable for entered PM Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbPMSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isDoubleClick == true)
            {
                PMMaster_Class_obj.pmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                if (cmbPMSupplierName.SelectedIndex != 0)
                    //PMMaster_Class_obj.pmsuppliecoid = Convert.ToInt64(cmbPMSupplierName.SelectedValue);
                    PMMaster_Class_obj.pmsupplierid = Convert.ToInt64(cmbPMSupplierName.SelectedValue);
                DataSet dsNoOfLots = PMMaster_Class_obj.STP_tblPMTransaction_NoOfLots_SupplierCOC_2();// PMMaster_Class_obj.STP_tblPMTransaction_NoOfLots_SupplierCOC();
                if (dsNoOfLots.Tables[0].Rows.Count > 0)
                {
                    txtPMNumberOfLots.Text = dsNoOfLots.Tables[0].Rows[0]["NoOfLots"].ToString();
                }
                else
                {
                    txtPMNumberOfLots.Text = "";
                }
            }
        }

        private void dgPMPeriodicTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}