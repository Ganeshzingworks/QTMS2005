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
    public partial class FrmFDAMaster : System.Windows.Forms.Form
    {
        public FrmFDAMaster()
        {
            InitializeComponent();
        }
        # region Varibles
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();       
        BusinessFacade.Transactions.FDAMaster_Class FDAMaster_Class_obj = new BusinessFacade.Transactions.FDAMaster_Class();
        # endregion

        DataSet dsList = new DataSet();

        private static FrmFDAMaster frmFDAMaster_Obj = null;
        public static FrmFDAMaster GetInstance()
        {
            if (frmFDAMaster_Obj == null)
            {
                frmFDAMaster_Obj = new Forms.FrmFDAMaster();
            }
            return frmFDAMaster_Obj;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text="";
            CmbFormulaNo.Text = "--Select--";
            dgValCon.Rows.Clear();
            CmbFormulaNo.Focus();
            btnValConReset_Click(sender,e);
            btnValIdentificationReset_Click(sender, e);
            btnPreservativeReset_Click(sender, e);
            dgValCon.Rows.Clear();
            dgValIdentification.Rows.Clear();
            dgValPreservative.Rows.Clear();
            txtMicroBiologyTests.Text = "";
            txtPreservativeTests.Text = "";
            Bind_List();
            Bind_FormulaNo();
            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmFDAMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_FormulaNo();
            Bind_List();
            Bind_ControlTest();
            Bind_IdentificationTest();
            Bind_PresTest();
        }

        public void Bind_FormulaNo()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = FDAMaster_Class_obj.SELECT_FormulaNo_tblBulkMaster();
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
        public void Bind_PresTest()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = FDAMaster_Class_obj.STP_Select_tblPreservativeMaster();
                dr = ds.Tables[0].NewRow();
                dr["PresType"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                cmbValPreservativeTest.DataSource = ds.Tables[0];
                cmbValPreservativeTest.DisplayMember = "PresType";
                cmbValPreservativeTest.ValueMember = "Prsno";
                //}
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
            ds = FDAMaster_Class_obj.Select_tbltestmaster_IdentificationTest();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbValIdentificationTest.DataSource = ds.Tables[0];
                cmbValIdentificationTest.DisplayMember = "Details";
                cmbValIdentificationTest.ValueMember = "TestNo";

               
            }
        }
        public void Bind_ControlTest()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = FDAMaster_Class_obj.Select_tbltestmaster_ControlTest();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbValConTest.DataSource = ds.Tables[0];
                cmbValConTest.DisplayMember = "Details";
                cmbValConTest.ValueMember = "TestNo";

               
            }
        } 
        public void Bind_List()
        {
           
            dsList = FDAMaster_Class_obj.SELECT_FormulaNo_tblFDAPhysicochemicalTestMethodMaster_tblFDAPreservativeTestMethodMaster();
            if (dsList.Tables[0].Rows.Count > 0)
            {
                List.DataSource = dsList.Tables[0];
                List.DisplayMember = "FormulaNo";
                List.ValueMember = "FNo";

            }
            else
            {
                List.DataSource = dsList.Tables[0];
                List.DisplayMember = "FormulaNo";
                List.ValueMember = "FNo";
            }

            
        }

        private void btnValConAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FDAMaster_Class_obj.fno == 0 || CmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Formula", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    List.Focus();
                    return;
                }

                if (cmbValConTest.Text == "--Select--")
                {
                    MessageBox.Show("Select Test", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbValConTest.Focus();
                    return;
                }
                //if (txtValConMin.Text == "")
                //{
                //    MessageBox.Show("Select Min", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtValIdentificationMin.Focus();
                //    return;
                //}
                //if (txtValConMax.Text == "")
                //{
                //    MessageBox.Show("Select Max", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtValIdentificationMax.Focus();
                //    return;
                //}

                for (int i = 0; i < dgValCon.Rows.Count; i++)
                {
                    if (dgValCon["ValConTestNo", i].Value.ToString() == cmbValConTest.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FDAMaster_Class_obj.testno = Convert.ToInt32(cmbValConTest.SelectedValue.ToString());
                            FDAMaster_Class_obj.min = Convert.ToString(txtValConMin.Text);
                            FDAMaster_Class_obj.max = Convert.ToString(txtValConMax.Text);
                            //FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("Control");

                            FDAMaster_Class_obj.Update_tblFDAPhysicochemicalTestMethodMaster();

                            dgValCon["ValConMin", i].Value = txtValConMin.Text;
                            dgValCon["ValConMax", i].Value = txtValConMax.Text;
                        }

                        btnValConReset_Click(sender, e);

                        Bind_List();
                       
                        return;
                    }
                }

                dgValCon.Rows.Add();
                dgValCon["ValConTestNo", dgValCon.Rows.Count - 1].Value = cmbValConTest.SelectedValue.ToString();
                dgValCon["ValControlTest", dgValCon.Rows.Count - 1].Value = cmbValConTest.Text;
                dgValCon["ValConMin", dgValCon.Rows.Count - 1].Value = txtValConMin.Text;
                dgValCon["ValConMax", dgValCon.Rows.Count - 1].Value = txtValConMax.Text;

                FDAMaster_Class_obj.testno = Convert.ToInt32(cmbValConTest.SelectedValue.ToString());
                FDAMaster_Class_obj.min = Convert.ToString(txtValConMin.Text);
                FDAMaster_Class_obj.max = Convert.ToString(txtValConMax.Text);
                //FDAMaster_Class_obj.formulatype = Convert.ToString("Control");

                FDAMaster_Class_obj.Insert_tblFDAPhysicochemicalTestMethodMaster();
                btnValConReset_Click(sender, e);

                Bind_List();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {

            dgValCon.Rows.Clear();
            dgValIdentification.Rows.Clear();
            dgValPreservative.Rows.Clear();

            if (CmbFormulaNo.SelectedValue.ToString() != null && CmbFormulaNo.SelectedValue.ToString() != "")
            {

                             
                DataSet dsFDAPhysicoChemical = new DataSet();
                FDAMaster_Class_obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                DataSet dsfno = new DataSet();
                dsfno = FDAMaster_Class_obj.Select_tblBulkMaster_FNo();
                if (Convert.ToInt16(dsfno.Tables[0].Rows[0]["PreservativeTest"].ToString()) == 1)
                {
                    txtPreservativeTests.Text = "Applicable";
                }
                else
                {
                    txtPreservativeTests.Text="N/A";
                }

                if (Convert.ToInt16(dsfno.Tables[0].Rows[0]["MicrobiologyTest"].ToString()) == 1)
                {
                    txtMicroBiologyTests.Text = "Applicable";
                }
                else
                {
                    txtMicroBiologyTests.Text = "N/A";
                }

                dsFDAPhysicoChemical = FDAMaster_Class_obj.SELECT_tblFDAPhysicoChemicalTestMethodMaster_FNo();
                if (dsFDAPhysicoChemical.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsFDAPhysicoChemical.Tables[0].Rows.Count; i++)
                    {
                        if (dsFDAPhysicoChemical.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                        {
                            dgValCon.Rows.Add();
                            dgValCon["ValConTestNo", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["TestNo"].ToString();
                            dgValCon["ValControlTest", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["Details"].ToString();
                            dgValCon["ValConMin", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgValCon["ValConMax", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["NormsMax"].ToString();
                        }
                    }
                }

                DataSet dsFDAPhysicoChemicalIdentification = new DataSet();
                FDAMaster_Class_obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                dsFDAPhysicoChemicalIdentification = FDAMaster_Class_obj.SELECT_tblFDAPhysicoChemicalTestMethodMaster_FNo();
                if (dsFDAPhysicoChemicalIdentification.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsFDAPhysicoChemicalIdentification.Tables[0].Rows.Count; i++)
                    {
                        if (dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                        {
                            dgValIdentification.Rows.Add();
                            dgValIdentification["ValIdentificationTestNo", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["TestNo"].ToString();
                            dgValIdentification["ValIdentificationTest", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["Details"].ToString();
                            dgValIdentification["ValIdentificationMin", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgValIdentification["ValIdentificationMax", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["NormsMax"].ToString();
                        }
                    }
                }

                DataSet dsFDAPreservative = new DataSet();
                FDAMaster_Class_obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                dsFDAPreservative = FDAMaster_Class_obj.SELECT_tblFDAPreservativeTestMethodMaster_FNo();
                if (dsFDAPreservative.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsFDAPreservative.Tables[0].Rows.Count; i++)
                    {

                        dgValPreservative.Rows.Add();
                        dgValPreservative["ValPreservativeTestNo", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["Prsno"].ToString();
                        dgValPreservative["ValPreservativeTest", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["PresType"].ToString();
                        dgValPreservative["ValPreservativeMin", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgValPreservative["ValPreservativeMax", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["NormsMax"].ToString();

                    }
                }

          
            }
            
        }

        private void btnValConDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (FDAMaster_Class_obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    List.Focus();
                    return;
                }

                if (dgValCon.SelectedRows != null && dgValCon.SelectedRows.Count != 0)
                {

                    for (int i = 0; i < dgValCon.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {

                            //FDAMaster_Class_obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                            FDAMaster_Class_obj.testno = Convert.ToInt32(dgValCon["ValConTestNo", dgValCon.SelectedRows[i].Index].Value);
            
                            FDAMaster_Class_obj.Delete_tblFDAPhysicochemicalTestMethodMaster();

                            dgValCon.Rows.Remove(dgValCon.SelectedRows[i]);
                        }
                    }

                    btnValConReset_Click(sender, e);
                    Bind_List();
                


                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgValCon.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can't Delete this Record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnValConReset_Click(object sender, EventArgs e)
        {
            cmbValConTest.Text = "--Select--";
            txtValConMin.Text = "";
            txtValConMax.Text = "";
            cmbValConTest.Focus();
        }

        private void btnValIdentificationAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FDAMaster_Class_obj.fno == 0 || CmbFormulaNo.Text == "--Select--")
            {
                MessageBox.Show("Please Select Formula", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                List.Focus();
                return;
            }

            if (cmbValIdentificationTest.Text == "--Select--")
            {
                MessageBox.Show("Select Test", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbValIdentificationTest.Focus();
                return;
            }
            //if (txtValIdentificationMin.Text == "")
            //{
            //    MessageBox.Show("Select Min", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtValIdentificationMin.Focus();
            //    return;
            //}
            //if (txtValIdentificationMax.Text == "")
            //{
            //    MessageBox.Show("Select Max", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtValIdentificationMax.Focus();
            //    return;
            //}

            for (int i = 0; i < dgValIdentification.Rows.Count; i++)
            {
                if (dgValIdentification["ValIdentificationTestNo", i].Value.ToString() == cmbValIdentificationTest.SelectedValue.ToString())
                {
                    if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        FDAMaster_Class_obj.testno = Convert.ToInt32(cmbValIdentificationTest.SelectedValue.ToString());
                        FDAMaster_Class_obj.min = Convert.ToString(txtValIdentificationMin.Text);
                        FDAMaster_Class_obj.max = Convert.ToString(txtValIdentificationMax.Text);
                        //FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("Control");

                        FDAMaster_Class_obj.Update_tblFDAPhysicochemicalTestMethodMaster();

                        dgValIdentification["ValIdentificationMin", i].Value = txtValIdentificationMin.Text;
                        dgValIdentification["ValIdentificationMax", i].Value = txtValIdentificationMax.Text;
                    }

                    btnValIdentificationReset_Click(sender, e);

                    Bind_List();
                   
                    return;
                }
            }

            dgValIdentification.Rows.Add();
            dgValIdentification["ValIdentificationTestNo", dgValIdentification.Rows.Count - 1].Value = cmbValIdentificationTest.SelectedValue.ToString();
            dgValIdentification["ValIdentificationTest", dgValIdentification.Rows.Count - 1].Value = cmbValIdentificationTest.Text;
            dgValIdentification["ValIdentificationMin", dgValIdentification.Rows.Count - 1].Value = txtValIdentificationMin.Text;
            dgValIdentification["ValIdentificationMax", dgValIdentification.Rows.Count - 1].Value = txtValIdentificationMax.Text;

            FDAMaster_Class_obj.testno = Convert.ToInt32(cmbValIdentificationTest.SelectedValue.ToString());
            FDAMaster_Class_obj.min = Convert.ToString(txtValIdentificationMin.Text);
            FDAMaster_Class_obj.max = Convert.ToString(txtValIdentificationMax.Text);
            //FDAMaster_Class_obj.formulatype = Convert.ToString("Control");

            FDAMaster_Class_obj.Insert_tblFDAPhysicochemicalTestMethodMaster();
            btnValIdentificationReset_Click(sender, e);
            Bind_List();
           
            }

                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnValIdentificationDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (FDAMaster_Class_obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    List.Focus();
                    return;
                }

                if (dgValIdentification.SelectedRows != null && dgValIdentification.SelectedRows.Count != 0)
                {

                    for (int i = 0; i < dgValIdentification.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {

                            FDAMaster_Class_obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                            FDAMaster_Class_obj.testno = Convert.ToInt32(dgValIdentification["ValIdentificationTestNo", dgValIdentification.SelectedRows[i].Index].Value);

                            FDAMaster_Class_obj.Delete_tblFDAPhysicochemicalTestMethodMaster();

                            dgValIdentification.Rows.Remove(dgValIdentification.SelectedRows[i]);
                        }
                    }

                    btnValIdentificationReset_Click(sender, e);
                    Bind_List();
                    
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgValIdentification.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can't Delete this Record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnValIdentificationReset_Click(object sender, EventArgs e)
        {
            cmbValIdentificationTest.Text = "--Select--";
            txtValIdentificationMin.Text = "";
            txtValIdentificationMax.Text = "";
            cmbValIdentificationTest.Focus();
        }

        private void btnPreservativeAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (FDAMaster_Class_obj.fno == 0 || CmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Formula", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    List.Focus();
                    return;
                }

                if (cmbValPreservativeTest.Text == "--Select--")
                {
                    MessageBox.Show("Select Test", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbValPreservativeTest.Focus();
                    return;
                }

               
                //if (txtValPreservativeMin.Text == "")
                //{
                //    MessageBox.Show("Select Min", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtValPreservativeMin.Focus();
                //    return;
                //}
                //if (txtValPreservativeMax.Text == "")
                //{
                //    MessageBox.Show("Select Max", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtValPreservativeMax.Focus();
                //    return;
                //}
                if (txtPreservativeTests.Text=="N/A")
                {
                    MessageBox.Show("Preservative Tests are not Applicable for this Formula", "Message", MessageBoxButtons.OK , MessageBoxIcon.Information);
                    return;
                }

                for (int i = 0; i < dgValPreservative.Rows.Count; i++)
                {
                    if (dgValPreservative["ValPreservativeTestNo", i].Value.ToString() == cmbValPreservativeTest.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            FDAMaster_Class_obj.testno = Convert.ToInt32(cmbValPreservativeTest.SelectedValue.ToString());
                            FDAMaster_Class_obj.min = Convert.ToString(txtValPreservativeMin.Text);
                            FDAMaster_Class_obj.max = Convert.ToString(txtValPreservativeMax.Text);
                            //FormulaNoMaster_Class_Obj.formulatype = Convert.ToString("Control");

                            FDAMaster_Class_obj.Update_tblFDAPreservativeTestMethodMaster();

                            dgValPreservative["ValPreservativeMin", i].Value = txtValPreservativeMin.Text;
                            dgValPreservative["ValPreservativeMax", i].Value = txtValPreservativeMax.Text;
                        }

                        btnPreservativeReset_Click(sender, e);
                        Bind_List();
                      
                        return;
                    }
                }

                dgValPreservative.Rows.Add();
                dgValPreservative["ValPreservativeTestNo", dgValPreservative.Rows.Count - 1].Value = cmbValPreservativeTest.SelectedValue.ToString();
                dgValPreservative["ValPreservativeTest", dgValPreservative.Rows.Count - 1].Value = cmbValPreservativeTest.Text;
                dgValPreservative["ValPreservativeMin", dgValPreservative.Rows.Count - 1].Value = txtValPreservativeMin.Text;
                dgValPreservative["ValPreservativeMax", dgValPreservative.Rows.Count - 1].Value = txtValPreservativeMax.Text;

                FDAMaster_Class_obj.testno = Convert.ToInt32(cmbValPreservativeTest.SelectedValue.ToString());
                FDAMaster_Class_obj.min = Convert.ToString(txtValPreservativeMin.Text);
                FDAMaster_Class_obj.max = Convert.ToString(txtValPreservativeMax.Text);
                

                FDAMaster_Class_obj.Insert_tblFDAPreservativeTestMethodMaster();
                btnPreservativeReset_Click(sender, e);
                Bind_List();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPreservativeDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (FDAMaster_Class_obj.fno == 0 )
                {
                    MessageBox.Show("Please Select Formula", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    List.Focus();
                    return;
                }

                if (dgValPreservative.SelectedRows != null && dgValPreservative.SelectedRows.Count != 0)
                {

                    for (int i = 0; i < dgValPreservative.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {

                            FDAMaster_Class_obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                            FDAMaster_Class_obj.testno = Convert.ToInt32(dgValPreservative["ValPreservativeTestNo", dgValPreservative.SelectedRows[i].Index].Value);

                            FDAMaster_Class_obj.Delete_tblFDAPreservativeTestMethodMaster();

                            dgValPreservative.Rows.Remove(dgValPreservative.SelectedRows[i]);
                        }
                    }

                    btnPreservativeReset_Click(sender, e);
                    Bind_List();
                   
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgValPreservative.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can't Delete this Record", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnPreservativeReset_Click(object sender, EventArgs e)
        {
            cmbValPreservativeTest.Text = "--Select--";
            txtValPreservativeMin.Text = "";
            txtValPreservativeMax.Text = "";
            cmbValPreservativeTest.Focus();
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
              // txtSearch.Text = Convert.ToString(List.Text);
                btnPreservativeReset_Click(sender, e);
                btnValConReset_Click(sender, e);
                btnValIdentificationReset_Click(sender, e);
                if (List.SelectedValue != null)
                {
                    BtnDeleteFormula.Enabled = true;
                    CmbFormulaNo.Text = List.Text;
                    dgValCon.Rows.Clear();
                    dgValIdentification.Rows.Clear();
                    dgValPreservative.Rows.Clear();

                   
                    DataSet dsFDAPhysicoChemical = new DataSet();
                    FDAMaster_Class_obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                    DataSet dsfno = new DataSet();
                    dsfno = FDAMaster_Class_obj.Select_tblBulkMaster_FNo();
                    if (Convert.ToInt16(dsfno.Tables[0].Rows[0]["PreservativeTest"].ToString()) == 1)
                    {
                        txtPreservativeTests.Text = "Applicable";
                    }
                    else
                    {
                        txtPreservativeTests.Text = "N/A";
                    }

                    if (Convert.ToInt16(dsfno.Tables[0].Rows[0]["MicrobiologyTest"].ToString()) == 1)
                    {
                        txtMicroBiologyTests.Text = "Applicable";
                    }
                    else
                    {
                        txtMicroBiologyTests.Text = "N/A";
                    }
                    dsFDAPhysicoChemical = FDAMaster_Class_obj.SELECT_tblFDAPhysicoChemicalTestMethodMaster_FNo();
                    if (dsFDAPhysicoChemical.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsFDAPhysicoChemical.Tables[0].Rows.Count; i++)
                        {
                            if (dsFDAPhysicoChemical.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                            {
                                dgValCon.Rows.Add();
                                dgValCon["ValConTestNo", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["TestNo"].ToString();
                                dgValCon["ValControlTest", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["Details"].ToString();
                                dgValCon["ValConMin", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgValCon["ValConMax", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["NormsMax"].ToString();
                            }
                        }
                    }

                    DataSet dsFDAPhysicoChemicalIdentification = new DataSet();
                    FDAMaster_Class_obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                    dsFDAPhysicoChemicalIdentification = FDAMaster_Class_obj.SELECT_tblFDAPhysicoChemicalTestMethodMaster_FNo();
                    if (dsFDAPhysicoChemicalIdentification.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsFDAPhysicoChemicalIdentification.Tables[0].Rows.Count; i++)
                        {
                            if (dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                            {
                                dgValIdentification.Rows.Add();
                                dgValIdentification["ValIdentificationTestNo", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["TestNo"].ToString();
                                dgValIdentification["ValIdentificationTest", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["Details"].ToString();
                                dgValIdentification["ValIdentificationMin", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgValIdentification["ValIdentificationMax", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["NormsMax"].ToString();
                            }
                        }
                    }

                    DataSet dsFDAPreservative = new DataSet();
                    FDAMaster_Class_obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                    dsFDAPreservative = FDAMaster_Class_obj.SELECT_tblFDAPreservativeTestMethodMaster_FNo();
                    if (dsFDAPreservative.Tables[0].Rows.Count == 0)
                    {
                        
                    }
                    if (dsFDAPreservative.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsFDAPreservative.Tables[0].Rows.Count; i++)
                        {

                            dgValPreservative.Rows.Add();
                            dgValPreservative["ValPreservativeTestNo", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["Prsno"].ToString();
                            dgValPreservative["ValPreservativeTest", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["PresType"].ToString();
                            dgValPreservative["ValPreservativeMin", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgValPreservative["ValPreservativeMax", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["NormsMax"].ToString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDeleteFormula_Click(object sender, EventArgs e)
        {
            try
            {
                if (FDAMaster_Class_obj.fno == 0 )
                {
                    MessageBox.Show("Please Select Formula from List", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    List.Focus();
                    return;
                }

                if (CmbFormulaNo.Text != "--Select--")
                {
                    if (MessageBox.Show("Delete All Tests for this Formula ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FDAMaster_Class_obj.Delete_tblFDAPhysicochemicalTestMethodMaster_tblFDAPreservativeTestMethodMaster();

                        MessageBox.Show("Record Deleted Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Bind_List();
                        BtnReset_Click(sender, e);
                        BtnDeleteFormula.Enabled = false;


                    }
                }
            }
            catch 
            {
                MessageBox.Show("Cannot Delete this Record","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void dgValPreservative_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgValPreservative.Rows.Count > 0)
            {
                if (dgValPreservative.Rows[e.RowIndex].Cells["ValPreservativeTest"].Value != null)
                {
                    cmbValPreservativeTest.Text = dgValPreservative["ValPreservativeTest", e.RowIndex].Value.ToString();
                }
                if (dgValPreservative.Rows[e.RowIndex].Cells["ValPreservativeMin"].Value != null)
                {
                    txtValPreservativeMin.Text = dgValPreservative["ValPreservativeMin", e.RowIndex].Value.ToString();
                }
                if (dgValPreservative.Rows[e.RowIndex].Cells["ValPreservativeMax"].Value != null)
                {
                    txtValPreservativeMax.Text = dgValPreservative["ValPreservativeMax", e.RowIndex].Value.ToString();
                }
            }
        }

        private void dgValIdentification_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgValIdentification.Rows.Count > 0)
            {
                if (dgValIdentification.Rows[e.RowIndex].Cells["ValIdentificationTest"].Value != null)
                {
                    cmbValIdentificationTest.Text = dgValIdentification["ValIdentificationTest", e.RowIndex].Value.ToString();
                }
                if (dgValIdentification.Rows[e.RowIndex].Cells["ValIdentificationMin"].Value != null)
                {
                    txtValIdentificationMin.Text = dgValIdentification["ValIdentificationMin", e.RowIndex].Value.ToString();
                }
                if (dgValIdentification.Rows[e.RowIndex].Cells["ValIdentificationMax"].Value != null)
                {
                    txtValIdentificationMax.Text = dgValIdentification["ValIdentificationMax", e.RowIndex].Value.ToString();
                }
            }
        }

        private void dgValCon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (dgValCon.Rows.Count > 0)
            {
                if (dgValCon.Rows[e.RowIndex].Cells["ValControlTest"].Value != null)
                {
                    cmbValConTest.Text = dgValCon["ValControlTest", e.RowIndex].Value.ToString();
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

        private void txtValConMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtValConMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtValIdentificationMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtValIdentificationMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtValPreservativeMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtValPreservativeMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "FormulaNo like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "FormulaNo";
            List.ValueMember = "FNo";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    btnPreservativeReset_Click(sender, e);
                    btnValConReset_Click(sender, e);
                    btnValIdentificationReset_Click(sender, e);
                    if (List.SelectedValue != null)
                    {
                        BtnDeleteFormula.Enabled = true;
                        CmbFormulaNo.Text = List.Text;
                        dgValCon.Rows.Clear();
                        dgValIdentification.Rows.Clear();
                        dgValPreservative.Rows.Clear();


                        DataSet dsFDAPhysicoChemical = new DataSet();
                        FDAMaster_Class_obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                        DataSet dsfno = new DataSet();
                        dsfno = FDAMaster_Class_obj.Select_tblBulkMaster_FNo();
                        if (Convert.ToInt16(dsfno.Tables[0].Rows[0]["PreservativeTest"].ToString()) == 1)
                        {
                            txtPreservativeTests.Text = "Applicable";
                        }
                        else
                        {
                            txtPreservativeTests.Text = "N/A";
                        }

                        if (Convert.ToInt16(dsfno.Tables[0].Rows[0]["MicrobiologyTest"].ToString()) == 1)
                        {
                            txtMicroBiologyTests.Text = "Applicable";
                        }
                        else
                        {
                            txtMicroBiologyTests.Text = "N/A";
                        }
                        dsFDAPhysicoChemical = FDAMaster_Class_obj.SELECT_tblFDAPhysicoChemicalTestMethodMaster_FNo();
                        if (dsFDAPhysicoChemical.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFDAPhysicoChemical.Tables[0].Rows.Count; i++)
                            {
                                if (dsFDAPhysicoChemical.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                                {
                                    dgValCon.Rows.Add();
                                    dgValCon["ValConTestNo", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["TestNo"].ToString();
                                    dgValCon["ValControlTest", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["Details"].ToString();
                                    dgValCon["ValConMin", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgValCon["ValConMax", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["NormsMax"].ToString();
                                }
                            }
                        }

                        DataSet dsFDAPhysicoChemicalIdentification = new DataSet();
                        FDAMaster_Class_obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                        dsFDAPhysicoChemicalIdentification = FDAMaster_Class_obj.SELECT_tblFDAPhysicoChemicalTestMethodMaster_FNo();
                        if (dsFDAPhysicoChemicalIdentification.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFDAPhysicoChemicalIdentification.Tables[0].Rows.Count; i++)
                            {
                                if (dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                                {
                                    dgValIdentification.Rows.Add();
                                    dgValIdentification["ValIdentificationTestNo", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["TestNo"].ToString();
                                    dgValIdentification["ValIdentificationTest", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["Details"].ToString();
                                    dgValIdentification["ValIdentificationMin", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgValIdentification["ValIdentificationMax", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["NormsMax"].ToString();
                                }
                            }
                        }

                        DataSet dsFDAPreservative = new DataSet();
                        FDAMaster_Class_obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                        dsFDAPreservative = FDAMaster_Class_obj.SELECT_tblFDAPreservativeTestMethodMaster_FNo();
                        if (dsFDAPreservative.Tables[0].Rows.Count == 0)
                        {

                        }
                        if (dsFDAPreservative.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFDAPreservative.Tables[0].Rows.Count; i++)
                            {

                                dgValPreservative.Rows.Add();
                                dgValPreservative["ValPreservativeTestNo", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["Prsno"].ToString();
                                dgValPreservative["ValPreservativeTest", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["PresType"].ToString();
                                dgValPreservative["ValPreservativeMin", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgValPreservative["ValPreservativeMax", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["NormsMax"].ToString();

                            }
                        }
                    }
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
                    btnPreservativeReset_Click(sender, e);
                    btnValConReset_Click(sender, e);
                    btnValIdentificationReset_Click(sender, e);
                    if (List.SelectedValue != null)
                    {
                        BtnDeleteFormula.Enabled = true;
                        CmbFormulaNo.Text = List.Text;
                        dgValCon.Rows.Clear();
                        dgValIdentification.Rows.Clear();
                        dgValPreservative.Rows.Clear();


                        DataSet dsFDAPhysicoChemical = new DataSet();
                        FDAMaster_Class_obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                        DataSet dsfno = new DataSet();
                        dsfno = FDAMaster_Class_obj.Select_tblBulkMaster_FNo();
                        if (Convert.ToInt16(dsfno.Tables[0].Rows[0]["PreservativeTest"].ToString()) == 1)
                        {
                            txtPreservativeTests.Text = "Applicable";
                        }
                        else
                        {
                            txtPreservativeTests.Text = "N/A";
                        }

                        if (Convert.ToInt16(dsfno.Tables[0].Rows[0]["MicrobiologyTest"].ToString()) == 1)
                        {
                            txtMicroBiologyTests.Text = "Applicable";
                        }
                        else
                        {
                            txtMicroBiologyTests.Text = "N/A";
                        }
                        dsFDAPhysicoChemical = FDAMaster_Class_obj.SELECT_tblFDAPhysicoChemicalTestMethodMaster_FNo();
                        if (dsFDAPhysicoChemical.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFDAPhysicoChemical.Tables[0].Rows.Count; i++)
                            {
                                if (dsFDAPhysicoChemical.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                                {
                                    dgValCon.Rows.Add();
                                    dgValCon["ValConTestNo", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["TestNo"].ToString();
                                    dgValCon["ValControlTest", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["Details"].ToString();
                                    dgValCon["ValConMin", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgValCon["ValConMax", dgValCon.Rows.Count - 1].Value = dsFDAPhysicoChemical.Tables[0].Rows[i]["NormsMax"].ToString();
                                }
                            }
                        }

                        DataSet dsFDAPhysicoChemicalIdentification = new DataSet();
                        FDAMaster_Class_obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                        dsFDAPhysicoChemicalIdentification = FDAMaster_Class_obj.SELECT_tblFDAPhysicoChemicalTestMethodMaster_FNo();
                        if (dsFDAPhysicoChemicalIdentification.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFDAPhysicoChemicalIdentification.Tables[0].Rows.Count; i++)
                            {
                                if (dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                                {
                                    dgValIdentification.Rows.Add();
                                    dgValIdentification["ValIdentificationTestNo", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["TestNo"].ToString();
                                    dgValIdentification["ValIdentificationTest", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["Details"].ToString();
                                    dgValIdentification["ValIdentificationMin", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["NormsMin"].ToString();
                                    dgValIdentification["ValIdentificationMax", dgValIdentification.Rows.Count - 1].Value = dsFDAPhysicoChemicalIdentification.Tables[0].Rows[i]["NormsMax"].ToString();
                                }
                            }
                        }

                        DataSet dsFDAPreservative = new DataSet();
                        FDAMaster_Class_obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                        dsFDAPreservative = FDAMaster_Class_obj.SELECT_tblFDAPreservativeTestMethodMaster_FNo();
                        if (dsFDAPreservative.Tables[0].Rows.Count == 0)
                        {

                        }
                        if (dsFDAPreservative.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsFDAPreservative.Tables[0].Rows.Count; i++)
                            {

                                dgValPreservative.Rows.Add();
                                dgValPreservative["ValPreservativeTestNo", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["Prsno"].ToString();
                                dgValPreservative["ValPreservativeTest", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["PresType"].ToString();
                                dgValPreservative["ValPreservativeMin", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgValPreservative["ValPreservativeMax", dgValPreservative.Rows.Count - 1].Value = dsFDAPreservative.Tables[0].Rows[i]["NormsMax"].ToString();

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

             
        
    }
}