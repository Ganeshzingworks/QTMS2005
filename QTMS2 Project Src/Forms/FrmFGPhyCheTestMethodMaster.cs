using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessFacade;
using QTMS.Tools;
using System.Configuration;


namespace QTMS.Forms
{
    public partial class FrmFGPhyCheTestMethodMaster : Form
    {
        DataSet dsList = new DataSet();
        public FrmFGPhyCheTestMethodMaster()
        {
            InitializeComponent();
        }
        # region Varibles
        public bool Modify = false;
        public bool SaveAs = false;
        TestMaster_Class TestMaster_Class_Obj = new TestMaster_Class();
        FGPhyCheTestMethodMaster_Class FGPhyCheTestMethodMaster_Class_Obj = new FGPhyCheTestMethodMaster_Class();
        # endregion

        private static FrmFGPhyCheTestMethodMaster frmFGPhyCheTestMethodMaster_Obj = null;
        public static FrmFGPhyCheTestMethodMaster GetInstance()
        {
            if (frmFGPhyCheTestMethodMaster_Obj == null)
            {
                frmFGPhyCheTestMethodMaster_Obj = new FrmFGPhyCheTestMethodMaster();
            }
            return frmFGPhyCheTestMethodMaster_Obj;
        }

        private void FrmFGPhyCheTestMethodMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_FormulaNo();
            Bind_List();
            Bind_IdentificationTest();
            Bind_ControlTest();
            FGPhyCheTestMethodMaster_Class_Obj.fno = 0;
        }
        public void Bind_FormulaNo()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = FGPhyCheTestMethodMaster_Class_Obj.SELECT_FormulaNo_FGPhyChe();
                dr = ds.Tables[0].NewRow();
                dr["FormulaNo"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                CmbFormulaNo.DataSource = ds.Tables[0];
                CmbFormulaNo.DisplayMember = "FormulaNo";
                CmbFormulaNo.ValueMember = "FNo";

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

                dsList = FGPhyCheTestMethodMaster_Class_Obj.SELECT_tblFGPhysicochemicalTestMethodMaster_tblBulkMaster();
                List.DataSource = dsList.Tables[0];
                List.DisplayMember = "FormulaNo";
                List.ValueMember = "FNo";

                cmbFormulaNoSaveAs.DataSource = dsList.Tables[0];
                cmbFormulaNoSaveAs.DisplayMember = "FormulaNo";
                cmbFormulaNoSaveAs.ValueMember = "FNo";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_IdentificationTest()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = TestMaster_Class_Obj.Select_tbltestmaster_IdentificationTest();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbFGIdTest.DataSource = ds.Tables[0];
                cmbFGIdTest.DisplayMember = "Details";
                cmbFGIdTest.ValueMember = "TestNo";
            }
        }
        public void Bind_ControlTest()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = TestMaster_Class_Obj.Select_tbltestmaster_ControlTest();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbFGConTest.DataSource = ds.Tables[0];
                cmbFGConTest.DisplayMember = "Details";
                cmbFGConTest.ValueMember = "TestNo";
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            CmbFormulaNo.Text = "--Select--";
            dgFGId.Rows.Clear();
            dgFGCon.Rows.Clear();
            btnFGIdReset_Click(sender, e);
            btnFGConReset_Click(sender, e);
            CmbFormulaNo.Focus();
            Bind_List();
            Bind_FormulaNo();
            Modify = false;
            SaveAs = false;
            BtnDelete.Enabled = false;
            groupBoxSaveAs.Visible = false;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //txtSearch.Text = Convert.ToString(List.Text);
                //Modify = true;
                BtnDelete.Enabled = true;
                //BtnReset_Click(sender,e);
                dgFGId.Rows.Clear();
                dgFGCon.Rows.Clear();

                if (List.SelectedValue != null)
                {
                    DataSet ds = new DataSet();
                    FGPhyCheTestMethodMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                    CmbFormulaNo.Text = List.Text;
                    ds = FGPhyCheTestMethodMaster_Class_Obj.SELECT_tblFGPhysicochemicalTestMethodMaster_tblBulkMaster_tblTestMaster();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        CmbFormulaNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FormulaNo"]);

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                            {
                                dgFGId.Rows.Add();
                                dgFGId["FGIdTestNo", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                                dgFGId["FGIdTest", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Details"].ToString();
                                dgFGId["FGIdMin", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgFGId["FGIdMax", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                                dgFGId["MethodName", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MethodName"].ToString();
                            }
                            else if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                            {
                                dgFGCon.Rows.Add();
                                dgFGCon["FGConTestNo", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                                dgFGCon["FGConTest", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Details"].ToString();
                                dgFGCon["FGConMin", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgFGCon["FGConMax", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                                dgFGCon["MethodCName", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MethodName"].ToString();

                            }
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

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (FGPhyCheTestMethodMaster_Class_Obj.fno == 0 || CmbFormulaNo.SelectedValue == null || CmbFormulaNo.Text == "")
                {
                    MessageBox.Show("Please Select Formula from List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }


                if (MessageBox.Show("Delete All Tests for this Formula ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FGPhyCheTestMethodMaster_Class_Obj.del = 1;

                    //FGPhyCheTestMethodMaster_Class_Obj.Delete_tblFGPhysicochemicalTestMethodMaster();
                    FGPhyCheTestMethodMaster_Class_Obj.Update_tblFGPhysicochemicalTestMethodMaster_FNo_Del();

                    MessageBox.Show("Record Deleted Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BtnDelete.Enabled = false;
                    BtnReset_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void txtFGIdMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtFGIdMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtFGConMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtFGConMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void dgFGId_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgFGId.Rows.Count > 0)
            {
                if (dgFGId.Rows[e.RowIndex].Cells["FGIdTest"].Value != null)
                {
                    cmbFGIdTest.Text = dgFGId["FGIdTest", e.RowIndex].Value.ToString();
                }
                if (dgFGId.Rows[e.RowIndex].Cells["FGIdMin"].Value != null)
                {
                    txtFGIdMin.Text = dgFGId["FGIdMin", e.RowIndex].Value.ToString();
                }
                if (dgFGId.Rows[e.RowIndex].Cells["FGIdMax"].Value != null)
                {
                    txtFGIdMax.Text = dgFGId["FGIdMax", e.RowIndex].Value.ToString();
                }
                if (dgFGId.Rows[e.RowIndex].Cells["FGIdMax"].Value != null)
                {
                    txtMethodName.Text = dgFGId["MethodName", e.RowIndex].Value.ToString();
                }
            }
        }
        private void btnFGIdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FGPhyCheTestMethodMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula from List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (cmbFGIdTest.Text == "--Select--")
                {
                    MessageBox.Show("Select Test", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbFGIdTest.Focus();
                    return;
                }
                //if (txtFGIdMin.Text == "")
                //{
                //    MessageBox.Show("Select Min", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtFGIdMin.Focus();
                //    return;
                //}
                //if (txtFGIdMax.Text == "")
                //{
                //    MessageBox.Show("Select Max", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtFGIdMax.Focus();
                //    return;
                //}

                for (int i = 0; i < dgFGId.Rows.Count; i++)
                {
                    if (dgFGId["FGIdTestNo", i].Value.ToString() == cmbFGIdTest.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FGPhyCheTestMethodMaster_Class_Obj.testno = Convert.ToInt32(cmbFGIdTest.SelectedValue.ToString());
                            FGPhyCheTestMethodMaster_Class_Obj.min = Convert.ToString(txtFGIdMin.Text);
                            FGPhyCheTestMethodMaster_Class_Obj.max = Convert.ToString(txtFGIdMax.Text);
                            FGPhyCheTestMethodMaster_Class_Obj.methodname = Convert.ToString(txtMethodName.Text);

                            FGPhyCheTestMethodMaster_Class_Obj.Update_tblFGPhysicochemicalTestMethodMaster();

                            dgFGId["FGIdMin", i].Value = txtFGIdMin.Text;
                            dgFGId["FGIdMax", i].Value = txtFGIdMax.Text;
                            dgFGId["MethodName", i].Value = txtMethodName.Text;
                        }

                        btnFGIdReset_Click(sender, e);
                        Bind_List();
                        //Bind_FormulaNo();
                        return;
                    }
                }

                dgFGId.Rows.Add();
                dgFGId["FGIdTestNo", dgFGId.Rows.Count - 1].Value = cmbFGIdTest.SelectedValue.ToString();
                dgFGId["FGIdTest", dgFGId.Rows.Count - 1].Value = cmbFGIdTest.Text;
                dgFGId["FGIdMin", dgFGId.Rows.Count - 1].Value = txtFGIdMin.Text;
                dgFGId["FGIdMax", dgFGId.Rows.Count - 1].Value = txtFGIdMax.Text;
                dgFGId["MethodName", dgFGId.Rows.Count - 1].Value = txtMethodName.Text;

                FGPhyCheTestMethodMaster_Class_Obj.testno = Convert.ToInt32(cmbFGIdTest.SelectedValue.ToString());
                FGPhyCheTestMethodMaster_Class_Obj.min = Convert.ToString(txtFGIdMin.Text);
                FGPhyCheTestMethodMaster_Class_Obj.max = Convert.ToString(txtFGIdMax.Text);
                FGPhyCheTestMethodMaster_Class_Obj.methodname = Convert.ToString(txtMethodName.Text);

                //FGPhyCheTestMethodMaster_Class_Obj.Insert_tblFGPhysicochemicalTestMethodMaster();
                FGPhyCheTestMethodMaster_Class_Obj.Insert_tblFGPhysicochemicalTestMethodMasterLABX();
                btnFGIdReset_Click(sender, e);
                Bind_List();
                //Bind_FormulaNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFGIdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (FGPhyCheTestMethodMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (dgFGId.SelectedRows != null && dgFGId.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgFGId.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FGPhyCheTestMethodMaster_Class_Obj.del = 1;

                            //FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                            FGPhyCheTestMethodMaster_Class_Obj.testno = Convert.ToInt32(dgFGId["FGIdTestNo", dgFGId.SelectedRows[i].Index].Value);
                            //FGPhyCheTestMethodMaster_Class_Obj.DELETE_tblFGPhysicochemicalTestMethodMaster_TestNo();
                            FGPhyCheTestMethodMaster_Class_Obj.Update_tblFGPhysicochemicalTestMethodMaster_Del();

                            dgFGId.Rows.Remove(dgFGId.SelectedRows[i]);
                        }
                    }

                    btnFGIdReset_Click(sender, e);
                    //Bind_FormulaNo();
                    Bind_List();
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgFGId.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can't Delete this Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgFGId.Rows.Clear();
            dgFGCon.Rows.Clear();

            if (CmbFormulaNo.SelectedValue.ToString() != null && CmbFormulaNo.SelectedValue.ToString() != "")
            {

                FGPhyCheTestMethodMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());

                //Select Formula in list same as formula in combo                
                List.SelectedValue = Convert.ToInt32(CmbFormulaNo.SelectedValue.ToString());

                DataSet ds = new DataSet();

                ds = FGPhyCheTestMethodMaster_Class_Obj.SELECT_tblFGPhysicochemicalTestMethodMaster_tblBulkMaster_tblTestMaster();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                        {
                            dgFGId.Rows.Add();
                            dgFGId["FGIdTestNo", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                            dgFGId["FGIdTest", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Details"].ToString();
                            dgFGId["FGIdMin", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgFGId["FGIdMax", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgFGId["MethodName", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MethodName"].ToString();

                        }
                        else if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                        {
                            dgFGCon.Rows.Add();
                            dgFGCon["FGConTestNo", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                            dgFGCon["FGConTest", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Details"].ToString();
                            dgFGCon["FGConMin", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgFGCon["FGConMax", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgFGCon["MethodCName", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MethodName"].ToString();

                        }
                    }
                }

            }
        }

        private void btnFGIdReset_Click(object sender, EventArgs e)
        {
            cmbFGIdTest.Text = "--Select--";
            txtFGIdMin.Text = "";
            txtFGIdMax.Text = "";
            txtMethodName.Text = "";
            cmbFGIdTest.Focus();
        }

        private void dgFGCon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgFGCon.Rows.Count > 0)
            {
                if (dgFGCon.Rows[e.RowIndex].Cells["FGConTest"].Value != null)
                {
                    cmbFGConTest.Text = dgFGCon["FGConTest", e.RowIndex].Value.ToString();
                }
                if (dgFGCon.Rows[e.RowIndex].Cells["FGConMin"].Value != null)
                {
                    txtFGConMin.Text = dgFGCon["FGConMin", e.RowIndex].Value.ToString();
                }
                if (dgFGCon.Rows[e.RowIndex].Cells["FGConMax"].Value != null)
                {
                    txtFGConMax.Text = dgFGCon["FGConMax", e.RowIndex].Value.ToString();
                }
                if (dgFGCon.Rows[e.RowIndex].Cells["MethodCName"].Value != null)
                {
                    txtMethodName.Text = dgFGCon["MethodCName", e.RowIndex].Value.ToString();
                }
            }
        }

        private void btnFGConAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FGPhyCheTestMethodMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula from List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (cmbFGConTest.Text == "--Select--")
                {
                    MessageBox.Show("Select Test", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbFGConTest.Focus();
                    return;
                }
                //if (txtFGConMin.Text == "")
                //{
                //    MessageBox.Show("Select Min", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtFGConMin.Focus();
                //    return;
                //}
                //if (txtFGConMax.Text == "")
                //{
                //    MessageBox.Show("Select Max", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtFGConMax.Focus();
                //    return;
                //}

                for (int i = 0; i < dgFGCon.Rows.Count; i++)
                {
                    if (dgFGCon["FGConTestNo", i].Value.ToString() == cmbFGConTest.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FGPhyCheTestMethodMaster_Class_Obj.testno = Convert.ToInt32(cmbFGConTest.SelectedValue.ToString());
                            FGPhyCheTestMethodMaster_Class_Obj.min = Convert.ToString(txtFGConMin.Text);
                            FGPhyCheTestMethodMaster_Class_Obj.max = Convert.ToString(txtFGConMax.Text);
                            FGPhyCheTestMethodMaster_Class_Obj.methodname = Convert.ToString(txtCMethodName.Text);

                            FGPhyCheTestMethodMaster_Class_Obj.Update_tblFGPhysicochemicalTestMethodMaster();

                            dgFGCon["FGConMin", i].Value = txtFGConMin.Text;
                            dgFGCon["FGConMax", i].Value = txtFGConMax.Text;
                            dgFGCon["MethodCName", i].Value = txtCMethodName.Text;
                        }

                        btnFGConReset_Click(sender, e);
                        Bind_List();
                        //Bind_FormulaNo();
                        return;
                    }
                }

                dgFGCon.Rows.Add();
                dgFGCon["FGConTestNo", dgFGCon.Rows.Count - 1].Value = cmbFGConTest.SelectedValue.ToString();
                dgFGCon["FGConTest", dgFGCon.Rows.Count - 1].Value = cmbFGConTest.Text;
                dgFGCon["FGConMin", dgFGCon.Rows.Count - 1].Value = txtFGConMin.Text;
                dgFGCon["FGConMax", dgFGCon.Rows.Count - 1].Value = txtFGConMax.Text;
                dgFGCon["MethodCName", dgFGCon.Rows.Count - 1].Value = txtCMethodName.Text;

                FGPhyCheTestMethodMaster_Class_Obj.testno = Convert.ToInt32(cmbFGConTest.SelectedValue.ToString());
                FGPhyCheTestMethodMaster_Class_Obj.min = Convert.ToString(txtFGConMin.Text);
                FGPhyCheTestMethodMaster_Class_Obj.max = Convert.ToString(txtFGConMax.Text);
                FGPhyCheTestMethodMaster_Class_Obj.methodname = Convert.ToString(txtCMethodName.Text);

                //FGPhyCheTestMethodMaster_Class_Obj.Insert_tblFGPhysicochemicalTestMethodMaster();
                FGPhyCheTestMethodMaster_Class_Obj.Insert_tblFGPhysicochemicalTestMethodMasterLABX();

                btnFGConReset_Click(sender, e);
                Bind_List();
                //Bind_FormulaNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFGConDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (FGPhyCheTestMethodMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (dgFGCon.SelectedRows != null && dgFGCon.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgFGCon.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FGPhyCheTestMethodMaster_Class_Obj.del = 1;

                            //FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                            FGPhyCheTestMethodMaster_Class_Obj.testno = Convert.ToInt32(dgFGCon["FGConTestNo", dgFGCon.SelectedRows[i].Index].Value);
                            //FGPhyCheTestMethodMaster_Class_Obj.DELETE_tblFGPhysicochemicalTestMethodMaster_TestNo();
                            FGPhyCheTestMethodMaster_Class_Obj.Update_tblFGPhysicochemicalTestMethodMaster_Del();

                            dgFGCon.Rows.Remove(dgFGCon.SelectedRows[i]);
                        }
                    }

                    btnFGConReset_Click(sender, e);
                    //Bind_FormulaNo();
                    Bind_List();
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgFGCon.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can't Delete this Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFGConReset_Click(object sender, EventArgs e)
        {
            cmbFGConTest.Text = "--Select--";
            txtFGConMin.Text = "";
            txtFGConMax.Text = "";
            txtCMethodName.Text = "";
            cmbFGConTest.Focus();
        }

        private void btnSaveAsNew_Click(object sender, EventArgs e)
        {
            List.Enabled = true;
            SaveAs = true;
            //List_DoubleClick(sender, e);
            MessageBox.Show("kindly Select Formula No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            groupBoxSaveAs.Visible = true;
            cmbFormulaNoSaveAs.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CmbFormulaNo.SelectedValue == null || CmbFormulaNo.Text == "--Select--")
            {
                MessageBox.Show("Please Select FormulaNo..!", "Message");
                CmbFormulaNo.Focus();
                return;
            }

            if (cmbFormulaNoSaveAs.SelectedValue == null)
            {
                MessageBox.Show("Please Select FormulaNo..!", "Message");
                cmbFormulaNoSaveAs.Focus();
                return;
            }


            if (MessageBox.Show("Do you want to copy all norms from   \n\n FormulaNo  " + cmbFormulaNoSaveAs.Text + "  to  " + CmbFormulaNo.Text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FGPhyCheTestMethodMaster_Class_Obj.fno = Convert.ToInt64(cmbFormulaNoSaveAs.SelectedValue.ToString());

                DataSet ds = new DataSet();

                ds = FGPhyCheTestMethodMaster_Class_Obj.SELECT_tblFGPhysicochemicalTestMethodMaster_tblBulkMaster_tblTestMaster();

                FGPhyCheTestMethodMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());

                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    if (ds.Tables[0].Rows[r]["TestType"].ToString() == "Identification")
                    {
                        bool m = false;
                        for (int i = 0; i < dgFGId.Rows.Count; i++)
                        {
                            if (dgFGId["FGIdTestNo", i].Value.ToString() == ds.Tables[0].Rows[r]["TestNo"].ToString())
                            {
                                FGPhyCheTestMethodMaster_Class_Obj.testno = Convert.ToInt32(ds.Tables[0].Rows[r]["TestNo"].ToString());
                                FGPhyCheTestMethodMaster_Class_Obj.min = Convert.ToString(ds.Tables[0].Rows[r]["NormsMin"].ToString());
                                FGPhyCheTestMethodMaster_Class_Obj.max = Convert.ToString(ds.Tables[0].Rows[r]["NormsMax"].ToString());
                                FGPhyCheTestMethodMaster_Class_Obj.methodname = Convert.ToString(ds.Tables[0].Rows[r]["MethodName"].ToString());

                                FGPhyCheTestMethodMaster_Class_Obj.Update_tblFGPhysicochemicalTestMethodMaster();

                                dgFGId["FGIdMin", i].Value = ds.Tables[0].Rows[r]["NormsMin"].ToString();
                                dgFGId["FGIdMax", i].Value = ds.Tables[0].Rows[r]["NormsMax"].ToString();
                                dgFGId["MethodName", i].Value = ds.Tables[0].Rows[r]["MethodName"].ToString();

                                m = true;
                                break;
                            }
                        }

                        if (m == false)
                        {
                            dgFGId.Rows.Add();
                            dgFGId["FGIdTestNo", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[r]["TestNo"].ToString();
                            dgFGId["FGIdTest", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[r]["Details"].ToString();
                            dgFGId["FGIdMin", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[r]["NormsMin"].ToString();
                            dgFGId["FGIdMax", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[r]["NormsMax"].ToString();
                            dgFGId["MethodName", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[r]["MethodName"].ToString();


                            FGPhyCheTestMethodMaster_Class_Obj.testno = Convert.ToInt32(ds.Tables[0].Rows[r]["TestNo"].ToString());
                            FGPhyCheTestMethodMaster_Class_Obj.min = Convert.ToString(ds.Tables[0].Rows[r]["NormsMin"].ToString());
                            FGPhyCheTestMethodMaster_Class_Obj.max = Convert.ToString(ds.Tables[0].Rows[r]["NormsMax"].ToString());
                            FGPhyCheTestMethodMaster_Class_Obj.methodname = Convert.ToString(ds.Tables[0].Rows[r]["MethodName"].ToString());

                            //FGPhyCheTestMethodMaster_Class_Obj.Insert_tblFGPhysicochemicalTestMethodMaster();
                            FGPhyCheTestMethodMaster_Class_Obj.Insert_tblFGPhysicochemicalTestMethodMasterLABX();
                        }

                    }
                    else if (ds.Tables[0].Rows[r]["TestType"].ToString() == "Control")
                    {
                        bool m = false;
                        for (int i = 0; i < dgFGCon.Rows.Count; i++)
                        {
                            if (dgFGCon["FGConTestNo", i].Value.ToString() == ds.Tables[0].Rows[r]["TestNo"].ToString())
                            {

                                FGPhyCheTestMethodMaster_Class_Obj.testno = Convert.ToInt32(ds.Tables[0].Rows[r]["TestNo"].ToString());
                                FGPhyCheTestMethodMaster_Class_Obj.min = Convert.ToString(ds.Tables[0].Rows[r]["NormsMin"].ToString());
                                FGPhyCheTestMethodMaster_Class_Obj.max = Convert.ToString(ds.Tables[0].Rows[r]["NormsMax"].ToString());
                                FGPhyCheTestMethodMaster_Class_Obj.methodname = Convert.ToString(ds.Tables[0].Rows[r]["MethodName"].ToString());


                                FGPhyCheTestMethodMaster_Class_Obj.Update_tblFGPhysicochemicalTestMethodMaster();

                                dgFGCon["FGConMin", i].Value = ds.Tables[0].Rows[r]["NormsMin"].ToString();
                                dgFGCon["FGConMax", i].Value = ds.Tables[0].Rows[r]["NormsMax"].ToString();
                                dgFGCon["MethodCName", i].Value = ds.Tables[0].Rows[r]["MethodName"].ToString();

                                m = true;
                                break;
                            }
                        }

                        if (m == false)
                        {
                            dgFGCon.Rows.Add();
                            dgFGCon["FGConTestNo", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[r]["TestNo"].ToString();
                            dgFGCon["FGConTest", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[r]["Details"].ToString();
                            dgFGCon["FGConMin", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[r]["NormsMin"].ToString();
                            dgFGCon["FGConMax", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[r]["NormsMax"].ToString();
                            dgFGCon["MethodCName", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[r]["MethodCName"].ToString();


                            FGPhyCheTestMethodMaster_Class_Obj.testno = Convert.ToInt32(ds.Tables[0].Rows[r]["TestNo"].ToString());
                            FGPhyCheTestMethodMaster_Class_Obj.min = Convert.ToString(ds.Tables[0].Rows[r]["NormsMin"].ToString());
                            FGPhyCheTestMethodMaster_Class_Obj.max = Convert.ToString(ds.Tables[0].Rows[r]["NormsMax"].ToString());
                            FGPhyCheTestMethodMaster_Class_Obj.methodname = Convert.ToString(ds.Tables[0].Rows[r]["MethodName"].ToString());

                            //FGPhyCheTestMethodMaster_Class_Obj.Insert_tblFGPhysicochemicalTestMethodMaster();
                            FGPhyCheTestMethodMaster_Class_Obj.Insert_tblFGPhysicochemicalTestMethodMaster();

                        }
                    }

                }

            }

            btnFGConReset_Click(sender, e);
            btnFGIdReset_Click(sender, e);
            Bind_List();
            //Bind_FormulaNo();

            SaveAs = false;
            groupBoxSaveAs.Visible = false;
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = " FormulaNo like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "FormulaNo";
            List.ValueMember = "FNo";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    //Modify = true;
                    BtnDelete.Enabled = true;
                    //BtnReset_Click(sender,e);
                    dgFGId.Rows.Clear();
                    dgFGCon.Rows.Clear();

                    if (List.SelectedValue != null)
                    {
                        DataSet ds = new DataSet();
                        FGPhyCheTestMethodMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                        CmbFormulaNo.Text = List.Text;
                        ds = FGPhyCheTestMethodMaster_Class_Obj.SELECT_tblFGPhysicochemicalTestMethodMaster_tblBulkMaster_tblTestMaster();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            CmbFormulaNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FormulaNo"]);

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                                {
                                    dgFGId.Rows.Add();
                                    dgFGId["FGIdTestNo", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                                    dgFGId["FGIdTest", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Details"].ToString();
                                    dgFGId["FGIdMin", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgFGId["FGIdMax", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                                    dgFGId["MethodName", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MethodName"].ToString();
                                }
                                else if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                                {
                                    dgFGCon.Rows.Add();
                                    dgFGCon["FGConTestNo", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                                    dgFGCon["FGConTest", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Details"].ToString();
                                    dgFGCon["FGConMin", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgFGCon["MethodCName", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MethodName"].ToString();
                                }
                            }
                        }
                        BtnDelete.Enabled = true;
                    }
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
                    //Modify = true;
                    BtnDelete.Enabled = true;
                    //BtnReset_Click(sender,e);
                    dgFGId.Rows.Clear();
                    dgFGCon.Rows.Clear();

                    if (List.SelectedValue != null)
                    {
                        DataSet ds = new DataSet();
                        FGPhyCheTestMethodMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                        CmbFormulaNo.Text = List.Text;
                        ds = FGPhyCheTestMethodMaster_Class_Obj.SELECT_tblFGPhysicochemicalTestMethodMaster_tblBulkMaster_tblTestMaster();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            CmbFormulaNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FormulaNo"]);

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                                {
                                    dgFGId.Rows.Add();
                                    dgFGId["FGIdTestNo", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                                    dgFGId["FGIdTest", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Details"].ToString();
                                    dgFGId["FGIdMin", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgFGId["FGIdMax", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                                    dgFGId["MethodName", dgFGId.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MethodName"].ToString();
                                }
                                else if (ds.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                                {
                                    dgFGCon.Rows.Add();
                                    dgFGCon["FGConTestNo", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                                    dgFGCon["FGConTest", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Details"].ToString();
                                    dgFGCon["FGConMin", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgFGCon["FGConMax", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                                    dgFGCon["MethodCName", dgFGCon.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MethodName"].ToString();

                                }
                            }
                        }
                        BtnDelete.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            //FrmShowTitrationResults objFrm = new FrmShowTitrationResults();
            //objFrm.Show();
        }
    }
}