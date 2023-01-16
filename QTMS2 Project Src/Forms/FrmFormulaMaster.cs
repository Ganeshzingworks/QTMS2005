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
    
    public partial class FrmFormulaNoMaster : Form
    {
        DataSet dsBindList = new DataSet();//dataset for binding list
        DataSet dsList = new DataSet();
        DataTable dtList1 = new DataTable();
        DataSet dsLine = new DataSet();
        DataSet dsBulk = new DataSet();

        public FrmFormulaNoMaster()
        {
            InitializeComponent();
        }

        
        # region Varibles
        bool Modify = false;
        bool SaveAs = false;
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();        
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        TestMaster_Class TestMaster_Class_Obj = new TestMaster_Class(); 
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        # endregion

        private static FrmFormulaNoMaster frmFormulaNoMaster_Obj = null;
        public static FrmFormulaNoMaster GetInstance()
        {
            if (frmFormulaNoMaster_Obj == null)
            {
                frmFormulaNoMaster_Obj = new FrmFormulaNoMaster();
            }
            return frmFormulaNoMaster_Obj;
        }

        private void FrmFormulaMaster_Load(object sender, EventArgs e)
        {   
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            cmbFormulaType.Text = "NonValidated";
            cmbFormulaType.Enabled = false;

            DtpOfficializationNo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpReferenceDate.Value = DtpOfficializationNo.Value;
            DtpFDAApproval.Value = DtpModificationDate.Value;                 
            DtpCreationDate.Value = DtpOfficializationNo.Value;
            DtpModificationDate.Value = DtpOfficializationNo.Value;
            DtpOfficializationNo.Checked = false;
            DtpReferenceDate.Checked = false;
            DtpFDAApproval.Checked = false;
            DtpCreationDate.Checked = false;
            DtpModificationDate.Checked = false;
            Bind_List();
            Bind_CmbFormulaNo();
            Bind_Combo();
            Bind_LineTest();
            Bind_IdentificationTest();
            Bind_ControlTest();

            FormulaNoMaster_Class_Obj.fno = 0;
        }

        public void Bind_List()
        {
            dsBindList = FormulaNoMaster_Class_Obj.Select_TblBulkMaster();
            if (dsBindList.Tables[0].Rows.Count > 0)
            {
                List.DataSource = dsBindList.Tables[0];
                List.DisplayMember = "FormulaNo";
                List.ValueMember = "FNo";              
            }
        }

        public void Bind_CmbFormulaNo()
        {
            DataRow dr; 
            DataSet ds = new DataSet();
            ds = FormulaNoMaster_Class_Obj.Select_TblBulkMaster();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {  
                CmbFormulaNo.DataSource = ds.Tables[0];
                CmbFormulaNo.DisplayMember = "FormulaNo";
                CmbFormulaNo.ValueMember = "FNo";
            }
        }       

        public void Bind_Combo()
        {
            DataRow dr; 
            DataSet ds = new DataSet();
            ds = BulkFamilyMaster_Class_Obj.Select_BulkFamilyMaster();
            dr = ds.Tables[0].NewRow();
            dr["FamilyDesc"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbTechnicalFamily.DataSource = ds.Tables[0];
                CmbTechnicalFamily.DisplayMember = "FamilyDesc";
                CmbTechnicalFamily.ValueMember = "TechFamNo";
            }
        }
        public void Bind_LineTest()
        {
            DataSet ds = new DataSet();
            DataRow dr ;
            ds = TestMaster_Class_Obj.Select_tbltestmaster_LineSampleTest();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbLineTest.DataSource = ds.Tables[0];
                cmbLineTest.DisplayMember = "Details";
                cmbLineTest.ValueMember = "TestNo";
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
                cmbNonValIdTest.DataSource = ds.Tables[0];
                cmbNonValIdTest.DisplayMember = "Details";
                cmbNonValIdTest.ValueMember = "TestNo";

                cmbValIdTest.DataSource = ds.Tables[0];
                cmbValIdTest.DisplayMember = "Details";
                cmbValIdTest.ValueMember = "TestNo";
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
                cmbNonValConTest.DataSource = ds.Tables[0];
                cmbNonValConTest.DisplayMember = "Details";
                cmbNonValConTest.ValueMember = "TestNo";

                cmbValConTest.DataSource = ds.Tables[0];
                cmbValConTest.DisplayMember = "Details";
                cmbValConTest.ValueMember = "TestNo";
            }
        }


        private void btnValIdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormulaNoMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (cmbValIdTest.Text == "--Select--")
                {
                    MessageBox.Show("Select Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbValIdTest.Focus();
                    return;
                }
                //if (txtValIdMin.Text == "")
                //{
                //    MessageBox.Show("Select Min", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtValIdMin.Focus();
                //    return;
                //}
                //if (txtValIdMax.Text == "")
                //{
                //    MessageBox.Show("Select Max", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtValIdMax.Focus();
                //    return;
                //}

                for (int i = 0; i < dgValId.Rows.Count; i++)
                {
                    if (dgValId["ValIdTestNo", i].Value.ToString() == cmbValIdTest.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(cmbValIdTest.SelectedValue.ToString());
                            FormulaNoMaster_Class_Obj.min = Convert.ToString(txtValIdMin.Text);
                            FormulaNoMaster_Class_Obj.max = Convert.ToString(txtValIdMax.Text);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("Validated");

                            FormulaNoMaster_Class_Obj.Update_tblBulkPhysicochemicalTestMethodMaster();

                            dgValId["ValIdMin", i].Value = txtValIdMin.Text;
                            dgValId["ValIdMax", i].Value = txtValIdMax.Text;
                        }

                        btnValIdReset_Click(sender, e);
                        return;
                    }
                }

                dgValId.Rows.Add();
                dgValId["ValIdTestNo", dgValId.Rows.Count - 1].Value = cmbValIdTest.SelectedValue.ToString();
                dgValId["ValIdTest", dgValId.Rows.Count - 1].Value = cmbValIdTest.Text;
                dgValId["ValIdMin", dgValId.Rows.Count - 1].Value = txtValIdMin.Text;
                dgValId["ValIdMax", dgValId.Rows.Count - 1].Value = txtValIdMax.Text;

                FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(cmbValIdTest.SelectedValue.ToString());
                FormulaNoMaster_Class_Obj.min = Convert.ToString(txtValIdMin.Text);
                FormulaNoMaster_Class_Obj.max = Convert.ToString(txtValIdMax.Text);
                FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("Validated");

                FormulaNoMaster_Class_Obj.Insert_tblBulkPhysicochemicalTestMethodMaster();

                btnValIdReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnValConAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormulaNoMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (cmbValConTest.Text == "--Select--")
                {
                    MessageBox.Show("Select Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbValConTest.Focus();
                    return;
                }
                //if (txtValConMin.Text == "")
                //{
                //    MessageBox.Show("Select Min", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtValConMin.Focus();
                //    return;
                //}
                //if (txtValConMax.Text == "")
                //{
                //    MessageBox.Show("Select Max", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtValConMax.Focus();
                //    return;
                //}

                for (int i = 0; i < dgValCon.Rows.Count; i++)
                {
                    if (dgValCon["ValConTestNo", i].Value.ToString() == cmbValConTest.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(cmbValConTest.SelectedValue.ToString());
                            FormulaNoMaster_Class_Obj.min = Convert.ToString(txtValConMin.Text);
                            FormulaNoMaster_Class_Obj.max = Convert.ToString(txtValConMax.Text);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("Validated");

                            FormulaNoMaster_Class_Obj.Update_tblBulkPhysicochemicalTestMethodMaster();

                            dgValCon["ValConMin", i].Value = txtValConMin.Text;
                            dgValCon["ValConMax", i].Value = txtValConMax.Text;
                        }

                        btnValConReset_Click(sender, e);
                        return;
                    }
                }

                dgValCon.Rows.Add();
                dgValCon["ValConTestNo", dgValCon.Rows.Count - 1].Value = cmbValConTest.SelectedValue.ToString();
                dgValCon["ValConTest", dgValCon.Rows.Count - 1].Value = cmbValConTest.Text;
                dgValCon["ValConMin", dgValCon.Rows.Count - 1].Value = txtValConMin.Text;
                dgValCon["ValConMax", dgValCon.Rows.Count - 1].Value = txtValConMax.Text;

                FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(cmbValConTest.SelectedValue.ToString());
                FormulaNoMaster_Class_Obj.min = Convert.ToString(txtValConMin.Text);
                FormulaNoMaster_Class_Obj.max = Convert.ToString(txtValConMax.Text);
                FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("Validated");

                FormulaNoMaster_Class_Obj.Insert_tblBulkPhysicochemicalTestMethodMaster();


                btnValConReset_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNonValIdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormulaNoMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (cmbNonValIdTest.Text == "--Select--")
                {
                    MessageBox.Show("Select Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbNonValIdTest.Focus();
                    return;
                }
                //if (txtNonValIdMin.Text == "")
                //{
                //    MessageBox.Show("Select Min", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtNonValIdMin.Focus();
                //    return;
                //}
                //if (txtNonValIdMax.Text == "")
                //{
                //    MessageBox.Show("Select Max", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtNonValIdMax.Focus();
                //    return;
                //}

                for (int i = 0; i < dgNonValId.Rows.Count; i++)
                {
                    if (dgNonValId["NonValIdTestNo", i].Value.ToString() == cmbNonValIdTest.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(cmbValIdTest.SelectedValue.ToString());
                            FormulaNoMaster_Class_Obj.min = Convert.ToString(txtNonValIdMin.Text);
                            FormulaNoMaster_Class_Obj.max = Convert.ToString(txtNonValIdMax.Text);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("NonValidated");

                            FormulaNoMaster_Class_Obj.Update_tblBulkPhysicochemicalTestMethodMaster();

                            dgNonValId["NonValIdMin", i].Value = txtNonValIdMin.Text;
                            dgNonValId["NonValIdMax", i].Value = txtNonValIdMax.Text;
                        }

                        btnNonValIdReset_Click(sender, e);
                        return;
                    }
                }

                dgNonValId.Rows.Add();
                dgNonValId["NonValIdTestNo", dgNonValId.Rows.Count - 1].Value = cmbNonValIdTest.SelectedValue.ToString();
                dgNonValId["NonValIdTest", dgNonValId.Rows.Count - 1].Value = cmbNonValIdTest.Text;
                dgNonValId["NonValIdMin", dgNonValId.Rows.Count - 1].Value = txtNonValIdMin.Text;
                dgNonValId["NonValIdMax", dgNonValId.Rows.Count - 1].Value = txtNonValIdMax.Text;

                FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(cmbNonValIdTest.SelectedValue.ToString());
                FormulaNoMaster_Class_Obj.min = Convert.ToString(txtNonValIdMin.Text);
                FormulaNoMaster_Class_Obj.max = Convert.ToString(txtNonValIdMax.Text);
                FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("NonValidated");

                FormulaNoMaster_Class_Obj.Insert_tblBulkPhysicochemicalTestMethodMaster();

                btnNonValIdReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNonValConAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormulaNoMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (cmbNonValConTest.Text == "--Select--")
                {
                    MessageBox.Show("Select Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbNonValConTest.Focus();
                    return;
                }
                //if (txtNonValConMin.Text == "")
                //{
                //    MessageBox.Show("Select Min", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtNonValConMin.Focus();
                //    return;
                //}
                //if (txtNonValConMax.Text == "")
                //{
                //    MessageBox.Show("Select Max", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtNonValConMax.Focus();
                //    return;
                //}

                for (int i = 0; i < dgNonValCon.Rows.Count; i++)
                {
                    if (dgNonValCon["NonValConTestNo", i].Value.ToString() == cmbNonValConTest.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(cmbNonValConTest.SelectedValue.ToString());
                            FormulaNoMaster_Class_Obj.min = Convert.ToString(txtNonValConMin.Text);
                            FormulaNoMaster_Class_Obj.max = Convert.ToString(txtNonValConMax.Text);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("NonValidated");

                            FormulaNoMaster_Class_Obj.Update_tblBulkPhysicochemicalTestMethodMaster();

                            dgNonValCon["NonValConMin", i].Value = txtNonValConMin.Text;
                            dgNonValCon["NonValConMax", i].Value = txtNonValConMax.Text;
                        }

                        btnNonValConReset_Click(sender, e);
                        return;
                    }
                }

                dgNonValCon.Rows.Add();
                dgNonValCon["NonValConTestNo", dgNonValCon.Rows.Count - 1].Value = cmbNonValConTest.SelectedValue.ToString();
                dgNonValCon["NonValConTest", dgNonValCon.Rows.Count - 1].Value = cmbNonValConTest.Text;
                dgNonValCon["NonValConMin", dgNonValCon.Rows.Count - 1].Value = txtNonValConMin.Text;
                dgNonValCon["NonValConMax", dgNonValCon.Rows.Count - 1].Value = txtNonValConMax.Text;

                FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(cmbNonValConTest.SelectedValue.ToString());
                FormulaNoMaster_Class_Obj.min = Convert.ToString(txtNonValConMin.Text);
                FormulaNoMaster_Class_Obj.max = Convert.ToString(txtNonValConMax.Text);
                FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("NonValidated");

                FormulaNoMaster_Class_Obj.Insert_tblBulkPhysicochemicalTestMethodMaster();

                btnNonValConReset_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLineAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormulaNoMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (cmbLineTest.Text == "--Select--")
                {
                    MessageBox.Show("Select Test", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbLineTest.Focus();
                    return;                    
                }
                //if (txtLineMin.Text == "")
                //{
                //    MessageBox.Show("Select Min", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtLineMin.Focus();
                //    return;
                //}
                //if (txtLineMax.Text == "")
                //{
                //    MessageBox.Show("Select Max", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    txtLineMax.Focus();
                //    return;
                //}

                for (int i = 0; i < dgLine.Rows.Count; i++)
                {
                    if (dgLine["LineTestNo", i].Value.ToString() == cmbLineTest.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(cmbLineTest.SelectedValue.ToString());
                            FormulaNoMaster_Class_Obj.min = Convert.ToString(txtLineMin.Text);
                            FormulaNoMaster_Class_Obj.max = Convert.ToString(txtLineMax.Text);

                            FormulaNoMaster_Class_Obj.Update_tblLineTestMethodMaster();

                            dgLine["LineMin", i].Value = txtLineMin.Text;
                            dgLine["LineMax", i].Value = txtLineMax.Text;
                        }

                        btnLineReset_Click(sender, e);
                        return;
                    }
                }

                    dgLine.Rows.Add();
                dgLine["LineTestNo", dgLine.Rows.Count - 1].Value = cmbLineTest.SelectedValue.ToString();
                dgLine["LineTest", dgLine.Rows.Count - 1 ].Value = cmbLineTest.Text;
                dgLine["LineMin", dgLine.Rows.Count - 1 ].Value = txtLineMin.Text;
                dgLine["LineMax", dgLine.Rows.Count - 1 ].Value = txtLineMax.Text;

                FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(cmbLineTest.SelectedValue.ToString());
                FormulaNoMaster_Class_Obj.min = Convert.ToString(txtLineMin.Text);
                FormulaNoMaster_Class_Obj.max = Convert.ToString(txtLineMax.Text);

                FormulaNoMaster_Class_Obj.Insert_tblLineTestMethodMaster();

                btnLineReset_Click(sender, e);
 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      

        private void btnValIdRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormulaNoMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (dgValId.SelectedRows != null && dgValId.SelectedRows.Count != 0)
                {

                    for (int i = 0; i < dgValId.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FormulaNoMaster_Class_Obj.del = 1;

                            //FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(dgValId["ValIdTestNo", dgValId.SelectedRows[i].Index].Value);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("Validated");
                            //FormulaNoMaster_Class_Obj.Delete_tblBulkPhysicochemicalTestMethodMaster();
                            FormulaNoMaster_Class_Obj.Update_tblBulkPhysicochemicalTestMethodMaster_Del();

                            dgValId.Rows.Remove(dgValId.SelectedRows[i]);
                        }
                    }

                    btnValIdReset_Click(sender,e);
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgValId.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can't Delete this Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnValConRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormulaNoMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (dgValCon.SelectedRows != null && dgValCon.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgValCon.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FormulaNoMaster_Class_Obj.del = 1;

                            //FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(dgValCon["ValConTestNo", dgValCon.SelectedRows[i].Index].Value);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("Validated");
                            //FormulaNoMaster_Class_Obj.Delete_tblBulkPhysicochemicalTestMethodMaster();
                            FormulaNoMaster_Class_Obj.Update_tblBulkPhysicochemicalTestMethodMaster_Del();

                            dgValCon.Rows.Remove(dgValCon.SelectedRows[i]);
                        }
                    }

                    btnValConReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgValCon.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can't Delete this Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNonValIdRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormulaNoMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (dgNonValId.SelectedRows != null && dgNonValId.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgNonValId.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FormulaNoMaster_Class_Obj.del = 1;

                            //FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(dgNonValId["NonValIdTestNo", dgNonValId.SelectedRows[i].Index].Value);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("NonValidated");
                            //FormulaNoMaster_Class_Obj.Delete_tblBulkPhysicochemicalTestMethodMaster();
                            FormulaNoMaster_Class_Obj.Update_tblBulkPhysicochemicalTestMethodMaster_Del();

                            dgNonValId.Rows.Remove(dgNonValId.SelectedRows[i]);
                        }
                    }

                    btnNonValIdReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgNonValId.Focus();
                    return;
                }

            }
            catch
            {
                MessageBox.Show("Can't Delete this Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNonValConRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormulaNoMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (dgNonValCon.SelectedRows != null && dgNonValCon.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgNonValCon.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FormulaNoMaster_Class_Obj.del = 1;

                            //FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(dgNonValCon["NonValConTestNo", dgNonValCon.SelectedRows[i].Index].Value);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("NonValidated");
                            //FormulaNoMaster_Class_Obj.Delete_tblBulkPhysicochemicalTestMethodMaster();
                            FormulaNoMaster_Class_Obj.Update_tblBulkPhysicochemicalTestMethodMaster_Del();
                        
                            dgNonValCon.Rows.Remove(dgNonValCon.SelectedRows[i]);
                        }
                    }

                    btnNonValConReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgNonValCon.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can't Delete this Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLineRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (FormulaNoMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (dgLine.SelectedRows != null && dgLine.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgLine.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FormulaNoMaster_Class_Obj.del = 1;
                           
                            //FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(dgLine["LineTestNo", dgLine.SelectedRows[i].Index].Value);
                            //FormulaNoMaster_Class_Obj.Delete_tblLineTestMethodMaster();
                            FormulaNoMaster_Class_Obj.Update_tblLineTestMethodMaster_Del();
                            
                            dgLine.Rows.Remove(dgLine.SelectedRows[i]);
                        }
                    }

                    btnLineReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgLine.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can't Delete this Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {   
            try
            {
                txtNorms.Text = txtBacterialCount.Text;
                if (CmbFormulaNo.Text.Trim() == "--Select--" || CmbFormulaNo.Text=="")
                {
                    MessageBox.Show("Enter Formula No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbFormulaNo.Focus();
                    return;
                }
                if (txtBulkDescription.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Bulk Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBulkDescription.Focus();
                    return;
                }
                if (txtDensity.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Density", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDensity.Focus();
                    return;
                }
                if (CmbTechnicalFamily.Text.Trim() == "--Select--")
                {
                    MessageBox.Show("Enter Technical Family", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbTechnicalFamily.Focus();
                    return;
                }
                if (DtpReferenceDate.Checked == false)
                {
                    MessageBox.Show("Select Reference Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DtpReferenceDate.Focus();
                    return;
                }

                if (DtpOfficializationNo.Checked == false)
                {
                    MessageBox.Show("Select Officialization Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DtpOfficializationNo.Focus();
                    return;
                }

                if (DtpFDAApproval.Checked == false && DtpFDAApprovalExport.Checked == false)
                {
                    MessageBox.Show("Select FDA Approval Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DtpFDAApproval.Focus();
                    return;
                }
                if (Modify == false)
                {
                    // check formula no is already exist or not
                    FormulaNoMaster_Class_Obj.formulano = CmbFormulaNo.Text.Trim();
                    DataSet ds = new DataSet();
                    ds = FormulaNoMaster_Class_Obj.Select_From_TblBulkMaster_By_FormulaNo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Formula No Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CmbFormulaNo.Focus();
                        return;
                    }

                    if (cmbFormulaType.Text == "Validated")
                    {
                        FormulaNoMaster_Class_Obj.ftype = "Validated";
                    }
                    else if (cmbFormulaType.Text == "NonValidated")
                    {
                        FormulaNoMaster_Class_Obj.ftype = "NonValidated";
                    }                    
                    FormulaNoMaster_Class_Obj.bulkdesc = txtBulkDescription.Text;
                    FormulaNoMaster_Class_Obj.density = Convert.ToDecimal(txtDensity.Text);
                  //chnaged by sanjiv on 6-May-2014 for adding FILCOde
                    FormulaNoMaster_Class_Obj.filcode = txtFILCode.Text.Trim();
                    if (txtNoOfBatches.Text != "")
                    {
                        FormulaNoMaster_Class_Obj.noofbatches = Convert.ToInt32(txtNoOfBatches.Text);
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.noofbatches = 0;
                    }

                    FormulaNoMaster_Class_Obj.techfamno = Convert.ToInt32(CmbTechnicalFamily.SelectedValue);
                    FormulaNoMaster_Class_Obj.officializationno = DtpOfficializationNo.Value.ToShortDateString();
                    FormulaNoMaster_Class_Obj.referencedate = DtpReferenceDate.Value.ToShortDateString();
                    if (DtpFDAApproval.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.fdaapprovaldate = DtpFDAApproval.Value.ToShortDateString();
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.fdaapprovaldate = null;
                    }
                    if (DtpFDAApprovalExport.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.fdaapprovaldateexport = DtpFDAApprovalExport.Value.ToShortDateString();
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.fdaapprovaldateexport = null;
                    }
                    if (DtpCreationDate.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.creationdate = DtpCreationDate.Value.ToShortDateString();
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.creationdate = null;
                    }
                    if (DtpModificationDate.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.modificationdate = DtpModificationDate.Value.ToShortDateString();
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.modificationdate = null;
                    }
                    
                    if (chkDeactive.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.deactive = 1;
                    }
                    else if(chkDeactive.Checked == false)
                    {
                        FormulaNoMaster_Class_Obj.deactive = 0;
                    }
                    
                    if (ChkMicrobiologyTest.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.microbiologytest = 1;
                        FormulaNoMaster_Class_Obj.norms = txtNorms.Text.Trim();
                        FormulaNoMaster_Class_Obj.bacterialcount = txtBacterialCount.Text.Trim();
                        FormulaNoMaster_Class_Obj.fungalcount = txtFungalCount.Text.Trim();
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.microbiologytest = 0;
                    }
                    if (ChkPreservativetest.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.preservativetest = 1;
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.preservativetest = 0;
                    }

                    if (chkExtLabReport.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.extlabreport = 1;
                    }
                    else if (chkExtLabReport.Checked == false)
                    {
                        FormulaNoMaster_Class_Obj.extlabreport = 0;
                    }

                    FormulaNoMaster_Class_Obj.fno = 0;
                    FormulaNoMaster_Class_Obj.createdby = Convert.ToInt32(GlobalVariables.uid);
                    FormulaNoMaster_Class_Obj.fno = FormulaNoMaster_Class_Obj.Insert_BulkMaster();

                    if (SaveAs == true)
                    {
                        // add validated identification tests
                        for (int i = 0; i < dgValId.Rows.Count; i++)
                        {
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(dgValId["ValIdTestNo", i].Value);
                            FormulaNoMaster_Class_Obj.min = Convert.ToString(dgValId["ValIdMin", i].Value);
                            FormulaNoMaster_Class_Obj.max = Convert.ToString(dgValId["ValIdMax", i].Value);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("Validated");

                            FormulaNoMaster_Class_Obj.Insert_tblBulkPhysicochemicalTestMethodMaster();
                        }

                        //add validated control tests
                        for (int i = 0; i < dgValCon.Rows.Count; i++)
                        {
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(dgValCon["ValConTestNo", i].Value);
                            FormulaNoMaster_Class_Obj.min = Convert.ToString(dgValCon["ValConMin", i].Value);
                            FormulaNoMaster_Class_Obj.max = Convert.ToString(dgValCon["ValConMax", i].Value);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("Validated");

                            FormulaNoMaster_Class_Obj.Insert_tblBulkPhysicochemicalTestMethodMaster();
                        }

                        //add non validated identification tests 
                        for (int i = 0; i < dgNonValId.Rows.Count; i++)
                        {
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(dgNonValId["NonValIdTestNo", i].Value);
                            FormulaNoMaster_Class_Obj.min = Convert.ToString(dgNonValId["NonValIdMin", i].Value);
                            FormulaNoMaster_Class_Obj.max = Convert.ToString(dgNonValId["NonValIdMax", i].Value);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("NonValidated");

                            FormulaNoMaster_Class_Obj.Insert_tblBulkPhysicochemicalTestMethodMaster();
                        }

                        //add non validated control tests
                        for (int i = 0; i < dgNonValCon.Rows.Count; i++)
                        {
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(dgNonValCon["NonValConTestNo", i].Value);
                            FormulaNoMaster_Class_Obj.min = Convert.ToString(dgNonValCon["NonValConMin", i].Value);
                            FormulaNoMaster_Class_Obj.max = Convert.ToString(dgNonValCon["NonValConMax", i].Value);
                            FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("NonValidated");

                            FormulaNoMaster_Class_Obj.Insert_tblBulkPhysicochemicalTestMethodMaster();
                        }

                        //add line sample tests 
                        for (int i = 0; i < dgLine.Rows.Count; i++)
                        {
                            FormulaNoMaster_Class_Obj.testno = Convert.ToInt32(dgLine["LineTestNo", i].Value);
                            FormulaNoMaster_Class_Obj.min = Convert.ToString(dgLine["LineMin", i].Value);
                            FormulaNoMaster_Class_Obj.max = Convert.ToString(dgLine["LineMax", i].Value);

                            FormulaNoMaster_Class_Obj.Insert_tblLineTestMethodMaster();
                        }

                        SaveAs = false;
                    }

                    MessageBox.Show("Record Saved Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                  
                }
                else
                {
                    // Update Code
                    FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                    FormulaNoMaster_Class_Obj.formulano = CmbFormulaNo.Text.Trim();
                    if (cmbFormulaType.Text == "Validated")
                    {
                        FormulaNoMaster_Class_Obj.ftype = "Validated";
                    }
                    else if (cmbFormulaType.Text == "NonValidated")
                    {
                        FormulaNoMaster_Class_Obj.ftype = "NonValidated";
                    }  
                    FormulaNoMaster_Class_Obj.bulkdesc = txtBulkDescription.Text;
                    FormulaNoMaster_Class_Obj.density = Convert.ToDecimal(txtDensity.Text);
                    //chnaged by sanjiv on 6-May-2014 for updating FILCOde
                    FormulaNoMaster_Class_Obj.filcode = txtFILCode.Text.Trim();
                    if (txtNoOfBatches.Text != "")
                    {
                        FormulaNoMaster_Class_Obj.noofbatches = Convert.ToInt32(txtNoOfBatches.Text);
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.noofbatches = 0;
                    }
                    FormulaNoMaster_Class_Obj.techfamno = Convert.ToInt32(CmbTechnicalFamily.SelectedValue);
                    FormulaNoMaster_Class_Obj.officializationno = DtpOfficializationNo.Value.ToShortDateString();
                    FormulaNoMaster_Class_Obj.referencedate = DtpReferenceDate.Value.ToShortDateString();
                    if (DtpFDAApproval.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.fdaapprovaldate = DtpFDAApproval.Value.ToShortDateString();
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.fdaapprovaldate = null;
                    }
                    if (DtpFDAApprovalExport.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.fdaapprovaldateexport = DtpFDAApprovalExport.Value.ToShortDateString();
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.fdaapprovaldateexport = null;
                    }
                    if (DtpCreationDate.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.creationdate = DtpCreationDate.Value.ToShortDateString();
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.creationdate = null;
                    }
                    if (DtpModificationDate.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.modificationdate = DtpModificationDate.Value.ToShortDateString();
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.modificationdate = null;
                    }
                    if (chkDeactive.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.deactive = 1;
                    }
                    else if (chkDeactive.Checked == false)
                    {
                        FormulaNoMaster_Class_Obj.deactive = 0;
                    }

                    if (ChkMicrobiologyTest.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.microbiologytest = 1;
                        FormulaNoMaster_Class_Obj.norms = txtNorms.Text.Trim();
                        FormulaNoMaster_Class_Obj.bacterialcount = txtBacterialCount.Text.Trim();
                        FormulaNoMaster_Class_Obj.fungalcount = txtFungalCount.Text.Trim();
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.microbiologytest = 0;
                    }
                    if (ChkPreservativetest.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.preservativetest = 1;
                    }
                    else
                    {
                        FormulaNoMaster_Class_Obj.preservativetest = 0;
                    }

                    if (chkExtLabReport.Checked == true)
                    {
                        FormulaNoMaster_Class_Obj.extlabreport = 1;
                    }
                    else if (chkExtLabReport.Checked == false)
                    {
                        FormulaNoMaster_Class_Obj.extlabreport = 0;
                    }

                    FormulaNoMaster_Class_Obj.createdby = Convert.ToInt32(GlobalVariables.uid);

                    FormulaNoMaster_Class_Obj.Update_BulkMaster();
                    MessageBox.Show("Record Update Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                    Modify = false;
                }
                Bind_List();
                Bind_CmbFormulaNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtNoOfBatches_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only 0-9 allowed
            if (Convert.ToInt32(e.KeyChar)!=8)
            {
                if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
                {

                }
                else
                { e.Handled = true; }
            }
        }

        private void txtDensity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only 0-9 and dot(.) allowed
            if ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 46))
            {
                if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
                {

                }
                else
                { e.Handled = true; }
            }
        }

        private void ChkMicrobiologyTest_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkMicrobiologyTest.CheckState == CheckState.Checked)
            {
                //labelNorms.Visible=
                lblBacterialCount.Visible=lblFungalCount.Visible = true;
                //txtNorms.Visible = 
                txtBacterialCount.Visible=txtFungalCount.Visible = true;
                //txtNorms.Focus();
                txtBacterialCount.Focus();
            }
            if (ChkMicrobiologyTest.CheckState == CheckState.Unchecked)
            {
                labelNorms.Visible = lblBacterialCount.Visible = lblFungalCount.Visible = false;
                txtNorms.Visible = txtBacterialCount.Visible = txtFungalCount.Visible = false;
                txtNorms.Text = txtBacterialCount.Text = txtFungalCount.Text = "";                
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";       
            CmbFormulaNo.Text = "--Select--";
            cmbFormulaType.Text = "Validated";
            txtBulkDescription.Text = "";
            CmbTechnicalFamily.Text = "--Select--";
            txtNoOfBatches.Text = "";
            txtDensity.Text = "";
            txtFILCode.Text = "";
            DtpOfficializationNo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpReferenceDate.Value = DtpOfficializationNo.Value;
            DtpFDAApproval.Value = DtpOfficializationNo.Value;
            DtpFDAApprovalExport.Value = DtpOfficializationNo.Value;
            DtpCreationDate.Value = DtpOfficializationNo.Value;
            DtpModificationDate.Value = DtpOfficializationNo.Value;
            DtpOfficializationNo.Checked = false;
            DtpFDAApproval.Checked = false;
            DtpFDAApprovalExport.Checked = false;
            DtpReferenceDate.Checked = false;
            DtpCreationDate.Checked = false;
            DtpModificationDate.Checked = false;
            ChkMicrobiologyTest.Checked = false;
            txtNorms.Visible = txtBacterialCount.Visible = txtFungalCount.Visible = false;
            labelNorms.Visible = lblBacterialCount.Visible=lblFungalCount.Visible = false;
            ChkPreservativetest.Checked = false;
            chkDeactive.Checked = false;
            chkExtLabReport.Checked = false;
            dgValId.Rows.Clear();
            dgValCon.Rows.Clear();
            dgNonValId.Rows.Clear();
            dgNonValCon.Rows.Clear();
            dgLine.Rows.Clear();
            btnValIdReset_Click(sender,e);
            btnValConReset_Click(sender, e);
            btnNonValIdReset_Click(sender, e);
            btnNonValConReset_Click(sender, e);
            btnLineReset_Click(sender, e);
            DtpReferenceDate.Enabled = true;
            CmbFormulaNo.Focus();
            Modify = false;
            SaveAs = false;
            BtnDelete.Enabled = false;            
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            List.Enabled = true;
            Modify = true;
            List_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }

        private void btnSaveAsNew_Click(object sender, EventArgs e)
        {
            List.Enabled = true;
            SaveAs = true;
            List_DoubleClick(sender, e);
            MessageBox.Show("kindly Change Formula No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            CmbFormulaNo.Focus();
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            //txtSearch.Text = Convert.ToString(List.Text);
            //Modify = true;
            BtnDelete.Enabled = true;
            //BtnReset_Click(sender,e);
            dgValId.Rows.Clear();
            dgValCon.Rows.Clear();
            dgNonValId.Rows.Clear();
            dgNonValCon.Rows.Clear();
            dgLine.Rows.Clear();
           

                 
            FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
            // If assign validity date in ref sample then we cannot update the formula master reference date
            
            dtList1 = FormulaNoMaster_Class_Obj.Select_BulkMaster_RSMgmt_FNo();
            if (dtList1.Rows.Count > 0)
                DtpReferenceDate.Enabled = false;
            else
                DtpReferenceDate.Enabled = true;

            dsList = FormulaNoMaster_Class_Obj.Select_From_TblBulkMaster_By_FNo();
            CmbFormulaNo.Text = List.Text;
            if (Convert.ToString(dsList.Tables[0].Rows[0]["FType"]) == "Validated")
            {
               cmbFormulaType.Text = "Validated";
            }
            else if (Convert.ToString(dsList.Tables[0].Rows[0]["FType"]) == "NonValidated")
            {
                cmbFormulaType.Text = "NonValidated";
            }
            else
            {
                cmbFormulaType.Text = "Validated";
            }
            txtBulkDescription.Text = dsList.Tables[0].Rows[0]["BulkDesc"].ToString();
            CmbTechnicalFamily.SelectedValue = Convert.ToInt64(dsList.Tables[0].Rows[0]["TechFamNo"]);
            txtNoOfBatches.Text = dsList.Tables[0].Rows[0]["NoOfBatches"].ToString();
            txtDensity.Text = dsList.Tables[0].Rows[0]["Density"].ToString();
            txtFILCode.Text = dsList.Tables[0].Rows[0]["FILCode"].ToString();
            if (dsList.Tables[0].Rows[0]["OfficializationNo"] is System.DBNull)
            {
                DtpOfficializationNo.Value = Comman_Class_Obj.Select_ServerDate();
                DtpOfficializationNo.Checked = false;
            }
            else
            {
                DtpOfficializationNo.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["OfficializationNo"].ToString());
            }

            if (dsList.Tables[0].Rows[0]["ReferenceDate"] is System.DBNull)
            {
                DtpReferenceDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpReferenceDate.Checked = false;
            }
            else
            {
                DtpReferenceDate.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["ReferenceDate"].ToString());
            }
            if (dsList.Tables[0].Rows[0]["FDAApprovalDate"] is System.DBNull)
            {
                DtpFDAApproval.Value = Comman_Class_Obj.Select_ServerDate();
                DtpFDAApproval.Checked = false;
            }
            else
            {
                DtpFDAApproval.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["FDAApprovalDate"].ToString());
            }
            if (dsList.Tables[0].Rows[0]["FDAApprovalDateExport"] is System.DBNull)
            {
                DtpFDAApprovalExport.Value = Comman_Class_Obj.Select_ServerDate();
                DtpFDAApprovalExport.Checked = false;
            }
            else
            {
                DtpFDAApprovalExport.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
            }
            if (dsList.Tables[0].Rows[0]["CreationDate"] is System.DBNull)
            {
                DtpCreationDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpCreationDate.Checked = false;
            }
            else
            {
                DtpCreationDate.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["CreationDate"].ToString());
            }

            if (dsList.Tables[0].Rows[0]["ModificationDate"] is System.DBNull)
            {
                DtpModificationDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpModificationDate.Checked = false;
            }
            else
            {
                DtpModificationDate.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["ModificationDate"].ToString());
            }

            if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Deactive"]) == 1)
            {
                chkDeactive.Checked = true;
            }
            else if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Deactive"]) == 0)
            {
                chkDeactive.Checked = false;
            }

            if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Preservativetest"]) == 1)
            {
                ChkPreservativetest.Checked = true;
            }
            else
            {
                ChkPreservativetest.Checked = false;
            }
            if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Microbiologytest"]) == 1)
            {
                ChkMicrobiologyTest.Checked = true;
                //txtNorms.Visible = 
                txtBacterialCount.Visible = txtFungalCount.Visible = true;
                txtNorms.Text = dsList.Tables[0].Rows[0]["Norms"].ToString();
                txtBacterialCount.Text = dsList.Tables[0].Rows[0]["BacterialCount"].ToString();
                txtFungalCount.Text = dsList.Tables[0].Rows[0]["FungalCount"].ToString();
                //labelNorms.Visible = 
                lblBacterialCount.Visible = lblFungalCount.Visible =true;
            }
            else
            {
                ChkMicrobiologyTest.Checked = false;
                txtNorms.Visible = txtBacterialCount.Visible = txtFungalCount.Visible = false;
                txtNorms.Text = txtBacterialCount.Text = txtFungalCount.Text = "";
            }

            if (Convert.ToInt16(dsList.Tables[0].Rows[0]["ExtLabReport"]) == 1)
            {
                chkExtLabReport.Checked = true;
            }
            else if (Convert.ToInt16(dsList.Tables[0].Rows[0]["ExtLabReport"]) == 0)
            {
                chkExtLabReport.Checked = false;
            }

            //-----------To display tests-------------

       
            FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
            dsLine = FormulaNoMaster_Class_Obj.SELECT_tblLineTestMethodMaster_FNo();
            if (dsLine.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
                {
                    dgLine.Rows.Add();
                    dgLine["LineTestNo", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["TestNo"].ToString();
                    dgLine["LineTest", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["Details"].ToString();
                    dgLine["LineMin", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["NormsMin"].ToString();
                    dgLine["LineMax", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["NormsMax"].ToString();
                }
            }
           
            FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
            dsBulk = FormulaNoMaster_Class_Obj.SELECT_tblBulkPhysicochemicalTestMethodMaster_FNo();
            if (dsBulk.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsBulk.Tables[0].Rows.Count; i++)
                {
                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "Validated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                    {
                        dgValId.Rows.Add();
                        dgValId["ValIdTestNo", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgValId["ValIdTest", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgValId["ValIdMin", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgValId["ValIdMax", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }

                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "Validated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                    {
                        dgValCon.Rows.Add();
                        dgValCon["ValConTestNo", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgValCon["ValConTest", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgValCon["ValConMin", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgValCon["ValConMax", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }

                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "NonValidated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                    {
                        dgNonValId.Rows.Add();
                        dgNonValId["NonValIdTestNo", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgNonValId["NonValIdTest", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgNonValId["NonValIdMin", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgNonValId["NonValIdMax", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }

                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "NonValidated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                    {
                        dgNonValCon.Rows.Add();
                        dgNonValCon["NonValConTestNo", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgNonValCon["NonValConTest", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgNonValCon["NonValConMin", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgNonValCon["NonValConMax", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }
                }
            }
            //No of batches
            //Calculated from the fno only
            BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Obj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
            BulktestDetailstransaction_Class_Obj.fno = Convert.ToInt64(List.SelectedValue);
            long cnt = BulktestDetailstransaction_Class_Obj.Select_tblBulktesttransaction_NoBatches();
            // cnt = cnt + 1;
            txtNoOfBatches.Text = Convert.ToString(cnt);

            if (cnt == 0)
                cmbFormulaType.Enabled = false;
            else
                cmbFormulaType.Enabled = true;

            btnValIdReset_Click(sender, e);
            btnValConReset_Click(sender, e);
            btnNonValIdReset_Click(sender, e);
            btnNonValConReset_Click(sender, e);
            btnLineReset_Click(sender, e);

        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbFormulaNo.SelectedValue == null || CmbFormulaNo.SelectedValue.ToString() == "")
            {
                return;
            }
            if (Convert.ToInt32(CmbFormulaNo.SelectedValue) == 0)
            {
                return;
            }

            //Modify = true;
            BtnDelete.Enabled = true;
            //BtnReset_Click(sender,e);
            dgValId.Rows.Clear();
            dgValCon.Rows.Clear();
            dgNonValId.Rows.Clear();
            dgNonValCon.Rows.Clear();
            dgLine.Rows.Clear();

            DataSet ds = new DataSet();
            FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
            // If assign validity date in ref sample then we cannot update the formula master reference date
            DataTable dt = new DataTable();
            dt = FormulaNoMaster_Class_Obj.Select_BulkMaster_RSMgmt_FNo();
            if (dt.Rows.Count > 0)
                DtpReferenceDate.Enabled = false;
            else
                DtpReferenceDate.Enabled = true;

            ds = FormulaNoMaster_Class_Obj.Select_From_TblBulkMaster_By_FNo();
            List.Text = CmbFormulaNo.Text;
            if (Convert.ToString(ds.Tables[0].Rows[0]["FType"]) == "Validated")
            {
                cmbFormulaType.Text = "Validated";
            }
            else if (Convert.ToString(ds.Tables[0].Rows[0]["FType"]) == "NonValidated")
            {
                cmbFormulaType.Text = "NonValidated";
            }
            else
            {
                cmbFormulaType.Text = "Validated";
            } 
            txtBulkDescription.Text = ds.Tables[0].Rows[0]["BulkDesc"].ToString();
            CmbTechnicalFamily.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["TechFamNo"]);
            txtNoOfBatches.Text = ds.Tables[0].Rows[0]["NoOfBatches"].ToString();
            txtDensity.Text = ds.Tables[0].Rows[0]["Density"].ToString();
            if (ds.Tables[0].Rows[0]["OfficializationNo"] is System.DBNull)
            {
                DtpOfficializationNo.Value = Comman_Class_Obj.Select_ServerDate();
                DtpOfficializationNo.Checked = false;
            }
            else
            {
                DtpOfficializationNo.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["OfficializationNo"].ToString());
            }
            if (ds.Tables[0].Rows[0]["ReferenceDate"] is System.DBNull)
            {
                DtpReferenceDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpReferenceDate.Checked = false;
            }
            else
            {
                DtpReferenceDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReferenceDate"].ToString());
            }
            if (ds.Tables[0].Rows[0]["FDAApprovalDate"] is System.DBNull)
            {
                DtpFDAApproval.Value = Comman_Class_Obj.Select_ServerDate();
                DtpFDAApproval.Checked = false;
            }
            else
            {
                DtpFDAApproval.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["FDAApprovalDate"].ToString());
            }
            if (ds.Tables[0].Rows[0]["FDAApprovalDateExport"] is System.DBNull)
            {
                DtpFDAApprovalExport.Value = Comman_Class_Obj.Select_ServerDate();
                DtpFDAApprovalExport.Checked = false;
            }
            else
            {
                DtpFDAApprovalExport.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
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

            if (Convert.ToInt16(ds.Tables[0].Rows[0]["Deactive"]) == 1)
            {
                chkDeactive.Checked = true;
            }
            else if (Convert.ToInt16(ds.Tables[0].Rows[0]["Deactive"]) == 0)
            {
                chkDeactive.Checked = false;
            }

            if (Convert.ToInt16(ds.Tables[0].Rows[0]["Preservativetest"]) == 1)
            {
                ChkPreservativetest.Checked = true;
            }
            else
            {
                ChkPreservativetest.Checked = false;
            }
            if (Convert.ToInt16(ds.Tables[0].Rows[0]["Microbiologytest"]) == 1)
            {
                ChkMicrobiologyTest.Checked = true;
                //txtNorms.Visible = 
                txtBacterialCount.Visible = txtFungalCount.Visible = true;
                txtNorms.Text = ds.Tables[0].Rows[0]["Norms"].ToString();
                txtBacterialCount.Text = dsList.Tables[0].Rows[0]["BacterialCount"].ToString();
                txtFungalCount.Text = dsList.Tables[0].Rows[0]["FungalCount"].ToString();
                //labelNorms.Visible = 
                lblBacterialCount.Visible = lblFungalCount.Visible =true;
            }
            else
            {
                ChkMicrobiologyTest.Checked = false;
                txtNorms.Visible = txtBacterialCount.Visible = txtFungalCount.Visible = false;
                txtNorms.Text = txtBacterialCount.Text = txtFungalCount.Text = "";
            }

            if (Convert.ToInt16(ds.Tables[0].Rows[0]["ExtLabReport"]) == 1)
            {
                chkExtLabReport.Checked = true;
            }
            else if (Convert.ToInt16(ds.Tables[0].Rows[0]["ExtLabReport"]) == 0)
            {
                chkExtLabReport.Checked = false;
            }

            //-----------To display tests-------------

            DataSet dsLine = new DataSet();
            FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
            dsLine = FormulaNoMaster_Class_Obj.SELECT_tblLineTestMethodMaster_FNo();
            if (dsLine.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
                {
                    dgLine.Rows.Add();
                    dgLine["LineTestNo", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["TestNo"].ToString();
                    dgLine["LineTest", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["Details"].ToString();
                    dgLine["LineMin", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["NormsMin"].ToString();
                    dgLine["LineMax", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["NormsMax"].ToString();
                }
            }

            DataSet dsBulk = new DataSet();
            FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
            dsBulk = FormulaNoMaster_Class_Obj.SELECT_tblBulkPhysicochemicalTestMethodMaster_FNo();
            if (dsBulk.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsBulk.Tables[0].Rows.Count; i++)
                {
                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "Validated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                    {
                        dgValId.Rows.Add();
                        dgValId["ValIdTestNo", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgValId["ValIdTest", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgValId["ValIdMin", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgValId["ValIdMax", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }

                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "Validated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                    {
                        dgValCon.Rows.Add();
                        dgValCon["ValConTestNo", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgValCon["ValConTest", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgValCon["ValConMin", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgValCon["ValConMax", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }

                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "NonValidated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                    {
                        dgNonValId.Rows.Add();
                        dgNonValId["NonValIdTestNo", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgNonValId["NonValIdTest", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgNonValId["NonValIdMin", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgNonValId["NonValIdMax", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }

                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "NonValidated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                    {
                        dgNonValCon.Rows.Add();
                        dgNonValCon["NonValConTestNo", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgNonValCon["NonValConTest", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgNonValCon["NonValConMin", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgNonValCon["NonValConMax", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }
                }
            }

            //No of batches
            //Calculated from the fno only
            BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Obj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
            BulktestDetailstransaction_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
            long cnt = BulktestDetailstransaction_Class_Obj.Select_tblBulktesttransaction_NoBatches();
           // cnt = cnt + 1;
            txtNoOfBatches.Text = Convert.ToString(cnt);

            if (cnt == 0)
                cmbFormulaType.Enabled = false;
            else
                cmbFormulaType.Enabled = true;

            btnValIdReset_Click(sender, e);
            btnValConReset_Click(sender, e);
            btnNonValIdReset_Click(sender, e);
            btnNonValConReset_Click(sender, e);
            btnLineReset_Click(sender, e);
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                FormulaNoMaster_Class_Obj.fno =Convert.ToInt64(List.SelectedValue.ToString());
                if (FormulaNoMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Select Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool b = FormulaNoMaster_Class_Obj.Delete_BulkMaster();
                    if (b == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        BtnReset_Click(sender, e);
                        BtnDelete.Enabled = false;
                        Bind_List();
                        Bind_CmbFormulaNo();
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Sorry You Cant Delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

               

        private void txtFormulaNo_Leave(object sender, EventArgs e)
        {

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            CmbFormulaNo.Text = textInfo.ToTitleCase(CmbFormulaNo.Text);	

        }

        private void txtBulkDescription_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtBulkDescription.Text = textInfo.ToTitleCase(txtBulkDescription.Text);        
        }

        private void txtLineMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtLineMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtNonValConMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtNonValConMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtNonValIdMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtNonValIdMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }
        
        private void txtValConMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtValConMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }        

        private void txtValIdMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtValIdMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void CmbFormulaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(32))
            {
                e.Handled = true;
            }
        }

        private void btnValIdReset_Click(object sender, EventArgs e)
        {
            cmbValIdTest.Text = "--Select--";
            txtValIdMin.Text = "";
            txtValIdMax.Text = "";
            cmbValIdTest.Focus();
        }

        private void btnValConReset_Click(object sender, EventArgs e)
        {
            cmbValConTest.Text = "--Select--";
            txtValConMin.Text = "";
            txtValConMax.Text = "";
            cmbValConTest.Focus();
        }

        private void btnNonValIdReset_Click(object sender, EventArgs e)
        {
            cmbNonValIdTest.Text = "--Select--";
            txtNonValIdMin.Text = "";
            txtNonValIdMax.Text = "";
            cmbNonValIdTest.Focus();
        }

        private void btnNonValConReset_Click(object sender, EventArgs e)
        {
            cmbNonValConTest.Text = "--Select--";
            txtNonValConMin.Text = "";
            txtNonValConMax.Text = "";
            cmbNonValConTest.Focus();
        }

        private void btnLineReset_Click(object sender, EventArgs e)
        {
            cmbLineTest.Text = "--Select--";
            txtLineMin.Text = "";
            txtLineMax.Text = "";
            cmbLineTest.Focus();
        }



        private void dgValId_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgValId.Rows.Count > 0)
            {
                if (dgValId.Rows[e.RowIndex].Cells["ValIdTest"].Value != null)
                {
                    cmbValIdTest.Text = dgValId["ValIdTest", e.RowIndex].Value.ToString();
                }
                if (dgValId.Rows[e.RowIndex].Cells["ValIdMin"].Value != null)
                {
                    txtValIdMin.Text = dgValId["ValIdMin", e.RowIndex].Value.ToString();
                }
                if (dgValId.Rows[e.RowIndex].Cells["ValIdMax"].Value != null)
                {
                    txtValIdMax.Text = dgValId["ValIdMax", e.RowIndex].Value.ToString();
                }
            }

        }

        private void dgValCon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgValCon.Rows.Count > 0)
            {
                if (dgValCon.Rows[e.RowIndex].Cells["ValConTest"].Value != null)
                {
                    cmbValConTest.Text = dgValCon["ValConTest", e.RowIndex].Value.ToString();
                }
                if (dgValCon.Rows[e.RowIndex].Cells["ValConMin"].Value != null)
                {
                    txtValConMin.Text = dgValCon["ValConMin", e.RowIndex].Value.ToString();
                }
                if (dgValCon.Rows[e.RowIndex].Cells["ValConMax"].Value != null)
                {
                    txtValConMax.Text = dgValCon["ValConMax", e.RowIndex].Value.ToString();
                }
            }
        }

        private void dgNonValId_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgNonValId.Rows.Count > 0)
            {
                if (dgNonValId.Rows[e.RowIndex].Cells["NonValIdTest"].Value != null)
                {
                    cmbNonValIdTest.Text = dgNonValId["NonValIdTest", e.RowIndex].Value.ToString();
                }
                if (dgNonValId.Rows[e.RowIndex].Cells["NonValIdMin"].Value != null)
                {
                    txtNonValIdMin.Text = dgNonValId["NonValIdMin", e.RowIndex].Value.ToString();
                }
                if (dgNonValId.Rows[e.RowIndex].Cells["NonValIdMax"].Value != null)
                {
                    txtNonValIdMax.Text = dgNonValId["NonValIdMax", e.RowIndex].Value.ToString();
                }
            }
        }

        private void dgNonValCon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgNonValCon.Rows.Count > 0)
            {
                if (dgNonValCon.Rows[e.RowIndex].Cells["NonValConTest"].Value != null)
                {
                    cmbNonValConTest.Text = dgNonValCon["NonValConTest", e.RowIndex].Value.ToString();
                }
                if (dgNonValCon.Rows[e.RowIndex].Cells["NonValConMin"].Value != null)
                {
                    txtNonValConMin.Text = dgNonValCon["NonValConMin", e.RowIndex].Value.ToString();
                }
                if (dgNonValCon.Rows[e.RowIndex].Cells["NonValConMax"].Value != null)
                {
                    txtNonValConMax.Text = dgNonValCon["NonValConMax", e.RowIndex].Value.ToString();
                }
            }
        }

        private void dgLine_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgLine.Rows.Count > 0)
            {
                if (dgLine.Rows[e.RowIndex].Cells["LineTest"].Value != null)
                {
                    cmbLineTest.Text = dgLine["LineTest", e.RowIndex].Value.ToString();
                }
                if (dgLine.Rows[e.RowIndex].Cells["LineMin"].Value != null)
                {
                    txtLineMin.Text = dgLine["LineMin", e.RowIndex].Value.ToString();
                }
                if (dgLine.Rows[e.RowIndex].Cells["LineMax"].Value != null)
                {
                    txtLineMax.Text = dgLine["LineMax", e.RowIndex].Value.ToString();
                }
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsBindList.Tables[0].DefaultView.RowFilter = "FormulaNo like  '" + searchString + "%'";
            List.DataSource = dsBindList.Tables[0];

            List.DisplayMember = "FormulaNo";
            List.ValueMember = "FNo";              
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if(e.KeyChar==13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                     //Modify = true;
            BtnDelete.Enabled = true;
            //BtnReset_Click(sender,e);
            dgValId.Rows.Clear();
            dgValCon.Rows.Clear();
            dgNonValId.Rows.Clear();
            dgNonValCon.Rows.Clear();
            dgLine.Rows.Clear();
           

                 
            FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
            // If assign validity date in ref sample then we cannot update the formula master reference date
            
            dtList1 = FormulaNoMaster_Class_Obj.Select_BulkMaster_RSMgmt_FNo();
            if (dtList1.Rows.Count > 0)
                DtpReferenceDate.Enabled = false;
            else
                DtpReferenceDate.Enabled = true;

            dsList = FormulaNoMaster_Class_Obj.Select_From_TblBulkMaster_By_FNo();
            CmbFormulaNo.Text = List.Text;
            if (Convert.ToString(dsList.Tables[0].Rows[0]["FType"]) == "Validated")
            {
               cmbFormulaType.Text = "Validated";
            }
            else if (Convert.ToString(dsList.Tables[0].Rows[0]["FType"]) == "NonValidated")
            {
                cmbFormulaType.Text = "NonValidated";
            }
            else
            {
                cmbFormulaType.Text = "Validated";
            }
            txtBulkDescription.Text = dsList.Tables[0].Rows[0]["BulkDesc"].ToString();
            CmbTechnicalFamily.SelectedValue = Convert.ToInt64(dsList.Tables[0].Rows[0]["TechFamNo"]);
            txtNoOfBatches.Text = dsList.Tables[0].Rows[0]["NoOfBatches"].ToString();
            txtDensity.Text = dsList.Tables[0].Rows[0]["Density"].ToString();
            if (dsList.Tables[0].Rows[0]["OfficializationNo"] is System.DBNull)
            {
                DtpOfficializationNo.Value = Comman_Class_Obj.Select_ServerDate();
                DtpOfficializationNo.Checked = false;
            }
            else
            {
                DtpOfficializationNo.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["OfficializationNo"].ToString());
            }

            if (dsList.Tables[0].Rows[0]["ReferenceDate"] is System.DBNull)
            {
                DtpReferenceDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpReferenceDate.Checked = false;
            }
            else
            {
                DtpReferenceDate.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["ReferenceDate"].ToString());
            }
            if (dsList.Tables[0].Rows[0]["FDAApprovalDate"] is System.DBNull)
            {
                DtpFDAApproval.Value = Comman_Class_Obj.Select_ServerDate();
                DtpFDAApproval.Checked = false;
            }
            else
            {
                DtpFDAApproval.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["FDAApprovalDate"].ToString());
            }
            if (dsList.Tables[0].Rows[0]["FDAApprovalDateExport"] is System.DBNull)
            {
                DtpFDAApprovalExport.Value = Comman_Class_Obj.Select_ServerDate();
                DtpFDAApprovalExport.Checked = false;
            }
            else
            {
                DtpFDAApprovalExport.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
            }
            if (dsList.Tables[0].Rows[0]["CreationDate"] is System.DBNull)
            {
                DtpCreationDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpCreationDate.Checked = false;
            }
            else
            {
                DtpCreationDate.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["CreationDate"].ToString());
            }

            if (dsList.Tables[0].Rows[0]["ModificationDate"] is System.DBNull)
            {
                DtpModificationDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpModificationDate.Checked = false;
            }
            else
            {
                DtpModificationDate.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["ModificationDate"].ToString());
            }

            if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Deactive"]) == 1)
            {
                chkDeactive.Checked = true;
            }
            else if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Deactive"]) == 0)
            {
                chkDeactive.Checked = false;
            }

            if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Preservativetest"]) == 1)
            {
                ChkPreservativetest.Checked = true;
            }
            else
            {
                ChkPreservativetest.Checked = false;
            }
            if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Microbiologytest"]) == 1)
            {
                ChkMicrobiologyTest.Checked = true;
                //txtNorms.Visible = 
                txtBacterialCount.Visible = txtFungalCount.Visible = true;
                txtNorms.Text = dsList.Tables[0].Rows[0]["Norms"].ToString();
                txtBacterialCount.Text = dsList.Tables[0].Rows[0]["BacterialCount"].ToString();
                txtFungalCount.Text = dsList.Tables[0].Rows[0]["FungalCount"].ToString();
                //labelNorms.Visible = 
                lblBacterialCount.Visible = lblFungalCount.Visible =true;
            }
            else
            {
                ChkMicrobiologyTest.Checked = false;
                txtNorms.Visible = txtBacterialCount.Visible = txtFungalCount.Visible = false;
                txtNorms.Text = txtBacterialCount.Text = txtFungalCount.Text = "";
            }

            if (Convert.ToInt16(dsList.Tables[0].Rows[0]["ExtLabReport"]) == 1)
            {
                chkExtLabReport.Checked = true;
            }
            else if (Convert.ToInt16(dsList.Tables[0].Rows[0]["ExtLabReport"]) == 0)
            {
                chkExtLabReport.Checked = false;
            }

            //-----------To display tests-------------

       
            FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
            dsLine = FormulaNoMaster_Class_Obj.SELECT_tblLineTestMethodMaster_FNo();
            if (dsLine.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
                {
                    dgLine.Rows.Add();
                    dgLine["LineTestNo", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["TestNo"].ToString();
                    dgLine["LineTest", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["Details"].ToString();
                    dgLine["LineMin", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["NormsMin"].ToString();
                    dgLine["LineMax", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["NormsMax"].ToString();
                }
            }
           
            FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
            dsBulk = FormulaNoMaster_Class_Obj.SELECT_tblBulkPhysicochemicalTestMethodMaster_FNo();
            if (dsBulk.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsBulk.Tables[0].Rows.Count; i++)
                {
                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "Validated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                    {
                        dgValId.Rows.Add();
                        dgValId["ValIdTestNo", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgValId["ValIdTest", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgValId["ValIdMin", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgValId["ValIdMax", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }

                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "Validated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                    {
                        dgValCon.Rows.Add();
                        dgValCon["ValConTestNo", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgValCon["ValConTest", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgValCon["ValConMin", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgValCon["ValConMax", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }

                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "NonValidated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                    {
                        dgNonValId.Rows.Add();
                        dgNonValId["NonValIdTestNo", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgNonValId["NonValIdTest", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgNonValId["NonValIdMin", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgNonValId["NonValIdMax", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }

                    if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "NonValidated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                    {
                        dgNonValCon.Rows.Add();
                        dgNonValCon["NonValConTestNo", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                        dgNonValCon["NonValConTest", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                        dgNonValCon["NonValConMin", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgNonValCon["NonValConMax", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                    }
                }
            }
            //No of batches
            //Calculated from the fno only
            BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Obj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
            BulktestDetailstransaction_Class_Obj.fno = Convert.ToInt64(List.SelectedValue);
            long cnt = BulktestDetailstransaction_Class_Obj.Select_tblBulktesttransaction_NoBatches();
            // cnt = cnt + 1;
            txtNoOfBatches.Text = Convert.ToString(cnt);

            btnValIdReset_Click(sender, e);
            btnValConReset_Click(sender, e);
            btnNonValIdReset_Click(sender, e);
            btnNonValConReset_Click(sender, e);
            btnLineReset_Click(sender, e);

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
                    dgValId.Rows.Clear();
                    dgValCon.Rows.Clear();
                    dgNonValId.Rows.Clear();
                    dgNonValCon.Rows.Clear();
                    dgLine.Rows.Clear();



                    FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                    // If assign validity date in ref sample then we cannot update the formula master reference date

                    dtList1 = FormulaNoMaster_Class_Obj.Select_BulkMaster_RSMgmt_FNo();
                    if (dtList1.Rows.Count > 0)
                        DtpReferenceDate.Enabled = false;
                    else
                        DtpReferenceDate.Enabled = true;

                    dsList = FormulaNoMaster_Class_Obj.Select_From_TblBulkMaster_By_FNo();
                    CmbFormulaNo.Text = List.Text;
                    if (Convert.ToString(dsList.Tables[0].Rows[0]["FType"]) == "Validated")
                    {
                        cmbFormulaType.Text = "Validated";
                    }
                    else if (Convert.ToString(dsList.Tables[0].Rows[0]["FType"]) == "NonValidated")
                    {
                        cmbFormulaType.Text = "NonValidated";
                    }
                    else
                    {
                        cmbFormulaType.Text = "Validated";
                    }
                    txtBulkDescription.Text = dsList.Tables[0].Rows[0]["BulkDesc"].ToString();
                    CmbTechnicalFamily.SelectedValue = Convert.ToInt64(dsList.Tables[0].Rows[0]["TechFamNo"]);
                    txtNoOfBatches.Text = dsList.Tables[0].Rows[0]["NoOfBatches"].ToString();
                    txtDensity.Text = dsList.Tables[0].Rows[0]["Density"].ToString();
                    if (dsList.Tables[0].Rows[0]["OfficializationNo"] is System.DBNull)
                    {
                        DtpOfficializationNo.Value = Comman_Class_Obj.Select_ServerDate();
                        DtpOfficializationNo.Checked = false;
                    }
                    else
                    {
                        DtpOfficializationNo.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["OfficializationNo"].ToString());
                    }

                    if (dsList.Tables[0].Rows[0]["ReferenceDate"] is System.DBNull)
                    {
                        DtpReferenceDate.Value = Comman_Class_Obj.Select_ServerDate();
                        DtpReferenceDate.Checked = false;
                    }
                    else
                    {
                        DtpReferenceDate.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["ReferenceDate"].ToString());
                    }
                    if (dsList.Tables[0].Rows[0]["FDAApprovalDate"] is System.DBNull)
                    {
                        DtpFDAApproval.Value = Comman_Class_Obj.Select_ServerDate();
                        DtpFDAApproval.Checked = false;
                    }
                    else
                    {
                        DtpFDAApproval.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["FDAApprovalDate"].ToString());
                    }
                    if (dsList.Tables[0].Rows[0]["FDAApprovalDateExport"] is System.DBNull)
                    {
                        DtpFDAApprovalExport.Value = Comman_Class_Obj.Select_ServerDate();
                        DtpFDAApprovalExport.Checked = false;
                    }
                    else
                    {
                        DtpFDAApprovalExport.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
                    }
                    if (dsList.Tables[0].Rows[0]["CreationDate"] is System.DBNull)
                    {
                        DtpCreationDate.Value = Comman_Class_Obj.Select_ServerDate();
                        DtpCreationDate.Checked = false;
                    }
                    else
                    {
                        DtpCreationDate.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["CreationDate"].ToString());
                    }

                    if (dsList.Tables[0].Rows[0]["ModificationDate"] is System.DBNull)
                    {
                        DtpModificationDate.Value = Comman_Class_Obj.Select_ServerDate();
                        DtpModificationDate.Checked = false;
                    }
                    else
                    {
                        DtpModificationDate.Value = Convert.ToDateTime(dsList.Tables[0].Rows[0]["ModificationDate"].ToString());
                    }

                    if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Deactive"]) == 1)
                    {
                        chkDeactive.Checked = true;
                    }
                    else if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Deactive"]) == 0)
                    {
                        chkDeactive.Checked = false;
                    }

                    if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Preservativetest"]) == 1)
                    {
                        ChkPreservativetest.Checked = true;
                    }
                    else
                    {
                        ChkPreservativetest.Checked = false;
                    }
                    if (Convert.ToInt16(dsList.Tables[0].Rows[0]["Microbiologytest"]) == 1)
                    {
                        ChkMicrobiologyTest.Checked = true;
                        //txtNorms.Visible = 
                        txtBacterialCount.Visible = txtFungalCount.Visible = true;
                        txtNorms.Text = dsList.Tables[0].Rows[0]["Norms"].ToString();
                        txtBacterialCount.Text = dsList.Tables[0].Rows[0]["BacterialCount"].ToString();
                        txtFungalCount.Text = dsList.Tables[0].Rows[0]["FungalCount"].ToString();
                        //labelNorms.Visible = 
                        lblBacterialCount.Visible = lblFungalCount.Visible =true;
                    }
                    else
                    {
                        ChkMicrobiologyTest.Checked = false;
                        txtNorms.Visible = txtBacterialCount.Visible = txtFungalCount.Visible = false;
                        txtNorms.Text = txtBacterialCount.Text = txtFungalCount.Text = "";
                    }

                    if (Convert.ToInt16(dsList.Tables[0].Rows[0]["ExtLabReport"]) == 1)
                    {
                        chkExtLabReport.Checked = true;
                    }
                    else if (Convert.ToInt16(dsList.Tables[0].Rows[0]["ExtLabReport"]) == 0)
                    {
                        chkExtLabReport.Checked = false;
                    }

                    //-----------To display tests-------------


                    FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                    dsLine = FormulaNoMaster_Class_Obj.SELECT_tblLineTestMethodMaster_FNo();
                    if (dsLine.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsLine.Tables[0].Rows.Count; i++)
                        {
                            dgLine.Rows.Add();
                            dgLine["LineTestNo", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["TestNo"].ToString();
                            dgLine["LineTest", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["Details"].ToString();
                            dgLine["LineMin", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgLine["LineMax", dgLine.Rows.Count - 1].Value = dsLine.Tables[0].Rows[i]["NormsMax"].ToString();
                        }
                    }

                    FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                    dsBulk = FormulaNoMaster_Class_Obj.SELECT_tblBulkPhysicochemicalTestMethodMaster_FNo();
                    if (dsBulk.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsBulk.Tables[0].Rows.Count; i++)
                        {
                            if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "Validated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                            {
                                dgValId.Rows.Add();
                                dgValId["ValIdTestNo", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                                dgValId["ValIdTest", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                                dgValId["ValIdMin", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgValId["ValIdMax", dgValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                            }

                            if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "Validated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                            {
                                dgValCon.Rows.Add();
                                dgValCon["ValConTestNo", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                                dgValCon["ValConTest", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                                dgValCon["ValConMin", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgValCon["ValConMax", dgValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                            }

                            if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "NonValidated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                            {
                                dgNonValId.Rows.Add();
                                dgNonValId["NonValIdTestNo", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                                dgNonValId["NonValIdTest", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                                dgNonValId["NonValIdMin", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgNonValId["NonValIdMax", dgNonValId.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                            }

                            if (dsBulk.Tables[0].Rows[i]["FormulaType"].ToString() == "NonValidated" && dsBulk.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                            {
                                dgNonValCon.Rows.Add();
                                dgNonValCon["NonValConTestNo", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["TestNo"].ToString();
                                dgNonValCon["NonValConTest", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["Details"].ToString();
                                dgNonValCon["NonValConMin", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgNonValCon["NonValConMax", dgNonValCon.Rows.Count - 1].Value = dsBulk.Tables[0].Rows[i]["NormsMax"].ToString();
                            }
                        }
                    }
                    //No of batches
                    //Calculated from the fno only
                    BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Obj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
                    BulktestDetailstransaction_Class_Obj.fno = Convert.ToInt64(List.SelectedValue);
                    long cnt = BulktestDetailstransaction_Class_Obj.Select_tblBulktesttransaction_NoBatches();
                    // cnt = cnt + 1;
                    txtNoOfBatches.Text = Convert.ToString(cnt);

                    btnValIdReset_Click(sender, e);
                    btnValConReset_Click(sender, e);
                    btnNonValIdReset_Click(sender, e);
                    btnNonValConReset_Click(sender, e);
                    btnLineReset_Click(sender, e);

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
                FormulaNoMaster_Class objFormulaNoMaster_Class = new FormulaNoMaster_Class();

                DataSet ds = new DataSet();
                ds = objFormulaNoMaster_Class.Select_All_Record_tblLineTestMethodMaster();

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