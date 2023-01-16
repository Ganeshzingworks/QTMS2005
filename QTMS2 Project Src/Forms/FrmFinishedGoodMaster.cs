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
    
    public partial class FrmFinishedGoodMaster : Form
    {
        DataSet dsList = new DataSet();
        public FrmFinishedGoodMaster()
        {
            InitializeComponent();
        }

        # region Varibles
        bool Modify = false;
        public bool SaveAs = false;
        PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new PackingFamilyMaster_Class();
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        FGGlobalFamilyMaster_Class FGGlobalFamilyMaster_Class_Obj = new FGGlobalFamilyMaster_Class();
        FGTestMaster_Class FGTestMaster_Class_Obj = null;
        # endregion

        private static FrmFinishedGoodMaster frmFinishedGoodMaster_Obj = null;

        public static FrmFinishedGoodMaster GetInstance()
        {
            if(frmFinishedGoodMaster_Obj ==null)
            {
                frmFinishedGoodMaster_Obj = new FrmFinishedGoodMaster();
            }
            return frmFinishedGoodMaster_Obj;
        }

        private void FrmFinishedGoodMaster_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                Painter.Paint(this);

                Bind_List();
                Bind_Combo();
                Bind_FormulaNo();
                Bind_FGGlobalFamily();
                Bind_ComboFG();
                BtnReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_List()
        {
          
            dsList = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster();
            List.DataSource = dsList.Tables[0];
            List.DisplayMember = "FGCode";
            List.ValueMember = "FGNo";
            Bind_FormulaNo();          
        }

        public void Bind_Combo()
        {

            DataSet ds = new DataSet();
            DataRow dr;
            ds = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster();
            dr = ds.Tables[0].NewRow();
            dr["TechFamDesc"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbTechnicalFamily.DataSource = ds.Tables[0];
                cmbTechnicalFamily.DisplayMember = "TechFamDesc";
                cmbTechnicalFamily.ValueMember = "PKGTechNo";
            }
        }

        public void Bind_ComboFG()
        {

            try
            {
                DataTable Dt = new DataTable();
                DataRow dr;
                Dt = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster_SF(0);
                dr = Dt.NewRow();
                dr["FGCode"] = "--Select--";
                Dt.Rows.InsertAt(dr, 0);
                if (Dt.Rows.Count > 0)
                {
                    cmbFgCode.DataSource = Dt;
                    cmbFgCode.DisplayMember = "FGCode";
                    cmbFgCode.ValueMember = "FGNo";
                }
            }
            catch (Exception)
            {
                
                throw;
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
                CmbFormulaNo.DisplayMember = "FormulaNo";
                CmbFormulaNo.ValueMember = "FNo";
            }
        }

        public void Bind_FGGlobalFamily()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = FGGlobalFamilyMaster_Class_Obj.Select_FGGlobalFamilyMaster();
            dr = ds.Tables[0].NewRow();
            dr["FGGlobalFamilyName"] = "--Select--";
            dr["FGGlobalFamilyID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
           
            cmbFGGlobalFamily.DataSource = ds.Tables[0];
            cmbFGGlobalFamily.DisplayMember = "FGGlobalFamilyName";
            cmbFGGlobalFamily.ValueMember = "FGGlobalFamilyID";            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValid()
        {
            if (txtFgCode.Text.Trim() == "")
            {
                MessageBox.Show("Enter Fg Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFgCode.Text = "";
                txtFgCode.Focus();
                return false;
            }
            if (txtFgDesc.Text.Trim() == "")
            {
                MessageBox.Show("Enter Description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFgDesc.Text = "";
                txtFgDesc.Focus();
                return false;
            }
            //if (txtFillVolume.Text == "")
            //{
            //    MessageBox.Show("Enter Fill Volume", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtFillVolume.Focus();
            //    return false;
            //}

            if (cmbFGGlobalFamily.SelectedValue == null || cmbFGGlobalFamily.Text == "--Select--")
            {
                MessageBox.Show("Select FG Global Family", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFGGlobalFamily.Focus();
                return false;
            }
            if (cmbTechnicalFamily.SelectedValue == null || cmbTechnicalFamily.Text == "--Select--")
            {
                MessageBox.Show("Select Technical Family", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTechnicalFamily.Focus();
                return false;
            }
            

            if (chkSemiFinish.Checked)
            {
                if (dgFGCode.Rows.Count < 2)
                {
                    MessageBox.Show("Select Atleast Two FG Codes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFgCode.Focus();
                    return false;
                }
            }
            else
            {
                if (chkKit.Checked != true && dgFormulaNo.Rows.Count > 1)
                {
                    MessageBox.Show("This is not Kit..\n Cann't bind more 1 formula..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgFormulaNo.Focus();
                    return false;
                }
                if (dgFormulaNo.Rows.Count == 0)
                {
                    MessageBox.Show("Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbFormulaNo.Focus();
                    return false;
                }
                if (dgFormulaNo.Rows.Count == 1 && chkKit.Checked)
                {
                    MessageBox.Show("Add More Formula For Saving As A kit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbFormulaNo.Focus();
                    return false;
                } 
            }
            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    if (Modify == false)
                    {
                        #region Common to SF and Kit
                        // check FGCode is already exist or not
                        FinishedGoodMaster_Class_Obj.fgcode = txtFgCode.Text.Trim();
                        DataSet ds = new DataSet();
                        ds = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster_By_FGCode();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("FG Code Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFgCode.Focus();
                            return;
                        }

                        FinishedGoodMaster_Class_Obj.fgdesc = txtFgDesc.Text.Trim();
                        FinishedGoodMaster_Class_Obj.fillvolume = txtFillVolume.Text.Trim();
                        FinishedGoodMaster_Class_Obj.pkgtechno = Convert.ToInt32(cmbTechnicalFamily.SelectedValue);
                        FinishedGoodMaster_Class_Obj.fgglobalfamilyid = Convert.ToInt32(cmbFGGlobalFamily.SelectedValue);
                        FinishedGoodMaster_Class_Obj.wip = 0;


                        if (chkKit.CheckState == CheckState.Checked)
                        {
                            FinishedGoodMaster_Class_Obj.kit = 1;
                        }
                        else if (chkKit.CheckState == CheckState.Unchecked)
                        {
                            FinishedGoodMaster_Class_Obj.kit = 0;
                        }

                        if (chkSemiFinish.Checked)
                            FinishedGoodMaster_Class_Obj.sf = 1;
                        else
                            FinishedGoodMaster_Class_Obj.sf = 0;
                        
                        FinishedGoodMaster_Class_Obj.fgno = 0;
                        FinishedGoodMaster_Class_Obj.createdby=Convert.ToInt32(GlobalVariables.uid);

                        FinishedGoodMaster_Class_Obj.fgno = FinishedGoodMaster_Class_Obj.Insert_tblFGMaster();

                        // update  by virendra  17/06/2010
                        FGTestMaster_Class_Obj.fgno = FinishedGoodMaster_Class_Obj.fgno;
                        FGTestMaster_Class_Obj.Delete_tblFGCodeFamilyTestRelation();
                        FGTestMaster_Class_Obj.Delete_tblFGCodeFamilyTestRelationUP();
                        foreach (DataGridViewRow row in dgTest.Rows)
                        {
                            if (row.Cells["Mark"].Value != null && Convert.ToInt32(row.Cells["Mark"].Value) == 1)
                            {
                                   // dgTest["TestNo", i].Value;
                               // FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(row.Cells["FGMethodNo"].Value);

                                FGTestMaster_Class_Obj.testno = Convert.ToInt64(row.Cells["TestNo"].Value);
                                FGTestMaster_Class_Obj.frequency = Convert.ToString(row.Cells["Fre"].Value);
                                FGTestMaster_Class_Obj.inspectionmethod = Convert.ToString(row.Cells["Ins"].Value);

                                ds = FGTestMaster_Class_Obj.Select_tblFinishGoodDetails_FGMethodNo();

                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(ds.Tables[0].Rows[i]["FGMethodNo"]);
                                    FGTestMaster_Class_Obj.Scoop_Qty = false;
                                    FGTestMaster_Class_Obj.Insert_tblFGCodeFamilyTestRelation();
                                }
                            }
                            if (row.Cells["QualitySCOOP"].Value != null && Convert.ToInt32(row.Cells["QualitySCOOP"].Value) == 1)
                            {
                                // dgTest["TestNo", i].Value;
                                // FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(row.Cells["FGMethodNo"].Value);

                                FGTestMaster_Class_Obj.testno = Convert.ToInt64(row.Cells["TestNo"].Value);
                                FGTestMaster_Class_Obj.frequency = Convert.ToString(row.Cells["Fre"].Value);
                                FGTestMaster_Class_Obj.inspectionmethod = Convert.ToString(row.Cells["Ins"].Value);

                                ////======================Changed Code for Scoop Manish K =============================// 
                                //FGTestMaster_Class_Obj.quality = (bool)row.Cells["Quality"].FormattedValue;
                                //FGTestMaster_Class_Obj.up = (bool)row.Cells["UP"].FormattedValue;
                                ////====================================================================================//

                                ds = FGTestMaster_Class_Obj.Select_tblFinishGoodDetails_FGMethodNo();
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(ds.Tables[0].Rows[i]["FGMethodNo"]);
                                    FGTestMaster_Class_Obj.Scoop_Qty = true;                                    
                                    FGTestMaster_Class_Obj.Insert_tblFGCodeFamilyTestRelation();

                                }


                            }
                            if ((bool)row.Cells["UP"].FormattedValue == true)//<----------------------------- CODE TO SAVE SCOOP RECORDS
                            {

                                FGTestMaster_Class_Obj.testno = Convert.ToInt64(row.Cells["TestNo"].Value);
                                FGTestMaster_Class_Obj.frequency = Convert.ToString(row.Cells["Fre"].Value);
                                FGTestMaster_Class_Obj.inspectionmethod = Convert.ToString(row.Cells["Ins"].Value);

                                ds = FGTestMaster_Class_Obj.Select_tblFinishGoodDetails_FGMethodNo();
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(ds.Tables[0].Rows[i]["FGMethodNo"]);
                                    FGTestMaster_Class_Obj.Insert_tblFGCodeFamilyTestRelationUP();
                                }

                            }
                        }

                        #endregion                        
                        if (FinishedGoodMaster_Class_Obj.fgno != 0)
                        {
                            if (chkSemiFinish.Checked)
                            {
                                #region SF
                                // Now save record in tblFGLinkSF
                                for (int i = 0; i < dgFGCode.Rows.Count; i++)
                                {
                                    FinishedGoodMaster_Class_Obj.subfgno = Convert.ToInt32(dgFGCode["FGNo", i].Value);                                    
                                    FinishedGoodMaster_Class_Obj.Insert_tblFGLinkSF();
                                }
                                #endregion
                            }
                            else
                            {
                                #region Kit or normal
                                // Now save record in tblFG_FormulaMaster
                                for (int i = 0; i < dgFormulaNo.Rows.Count; i++)
                                {
                                    FinishedGoodMaster_Class_Obj.fno = Convert.ToInt32(dgFormulaNo["FNo", i].Value);
                                    FinishedGoodMaster_Class_Obj.type = Convert.ToString(dgFormulaNo["Type", i].Value);
                                    if (dgFormulaNo["FGMicro", i].Value.ToString() == "Yes")
                                    {
                                        FinishedGoodMaster_Class_Obj.fgmicro = 1;
                                    }
                                    else if (dgFormulaNo["FGMicro", i].Value.ToString() == "No")
                                    {
                                        FinishedGoodMaster_Class_Obj.fgmicro = 0;
                                    }
                                    FinishedGoodMaster_Class_Obj.Insert_tblFG_FormulaMaster();
                                }
                                #endregion
                            }
                        }

                        MessageBox.Show("Record Saved Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgTest.Rows.Clear();
                        BtnReset_Click(sender, e);
                    }
                    else
                    {
                        // Update Code
                        FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(List.SelectedValue.ToString());
                        FinishedGoodMaster_Class_Obj.result = Convert.ToInt64(List.SelectedValue.ToString());
                        FinishedGoodMaster_Class_Obj.fgcode = txtFgCode.Text.Trim();
                        FinishedGoodMaster_Class_Obj.fgdesc = txtFgDesc.Text.Trim();
                        FinishedGoodMaster_Class_Obj.fillvolume = txtFillVolume.Text.Trim();
                        FinishedGoodMaster_Class_Obj.pkgtechno = Convert.ToInt32(cmbTechnicalFamily.SelectedValue);
                        FinishedGoodMaster_Class_Obj.fgglobalfamilyid = Convert.ToInt32(cmbFGGlobalFamily.SelectedValue);

                        FinishedGoodMaster_Class_Obj.createdby = Convert.ToInt32(GlobalVariables.uid);

                        if (chkKit.CheckState == CheckState.Checked)
                        {
                            FinishedGoodMaster_Class_Obj.kit = 1;
                        }
                        else if (chkKit.CheckState == CheckState.Unchecked)
                        {
                            FinishedGoodMaster_Class_Obj.kit = 0;
                        }

                        if (chkSemiFinish.Checked)
                            FinishedGoodMaster_Class_Obj.sf = 1;
                        else
                            FinishedGoodMaster_Class_Obj.sf = 0;


                        FGTestMaster_Class_Obj.fgno = FinishedGoodMaster_Class_Obj.fgno;
                        //FGTestMaster_Class_Obj.Delete_tblFGCodeFamilyTestRelation();

                        //foreach (DataGridViewRow row in dgTest.Rows)
                        //{
                        //    if (row.Cells["Mark"].Value != null && Convert.ToInt32(row.Cells["Mark"].Value) == 1)
                        //    {
                        //        FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(row.Cells["FGMethodNo"].Value);
                        //        //FGTestMaster_Class_Obj.Insert_tblFGCodeFamilyTestRelation();
                        //    }
                        //}

                        bool b = false;
                        if (MessageBox.Show("Modify this Record ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        { 
                            b = FinishedGoodMaster_Class_Obj.Update_tblFGMaster();                            
                        }

                        if (b == true)
                        {
                            #region Delete old records
                            //We need to delete from both tables as 
                            //delete record from tblFGLinkSF
                            FinishedGoodMaster_Class_Obj.Delete_tblFGLinkSF();
                            // delete record from tblFgMaster_FormulaNo
                            FinishedGoodMaster_Class_Obj.Delete_tblFgMaster_FormulaNo(); 
                            #endregion
                            
                            if (chkSemiFinish.Checked)//SF
                            {                              
                                // Now save record in tblFGLinkSF
                                for (int i = 0; i < dgFGCode.Rows.Count; i++)
                                {
                                    FinishedGoodMaster_Class_Obj.subfgno = Convert.ToInt32(dgFGCode["FGNo", i].Value);
                                    FinishedGoodMaster_Class_Obj.Insert_tblFGLinkSF();
                                }   
                            }
                            else//Normal or Kit
                            {
                                // Now save record in tblFG_FormulaMaster
                                for (int i = 0; i < dgFormulaNo.Rows.Count; i++)
                                {
                                    FinishedGoodMaster_Class_Obj.fno = Convert.ToInt32(dgFormulaNo["FNo", i].Value);
                                    FinishedGoodMaster_Class_Obj.type = Convert.ToString(dgFormulaNo["Type", i].Value);
                                    if (dgFormulaNo["FGMicro", i].Value.ToString() == "Yes")
                                    {
                                        FinishedGoodMaster_Class_Obj.fgmicro = 1;
                                    }
                                    else if (dgFormulaNo["FGMicro", i].Value.ToString() == "No")
                                    {
                                        FinishedGoodMaster_Class_Obj.fgmicro = 0;
                                    }
                                    FinishedGoodMaster_Class_Obj.Insert_tblFG_FormulaMaster();
                                }
                            }
                            // update code by virendra on 17 /06/2010
                            FGTestMaster_Class_Obj.fgno = FinishedGoodMaster_Class_Obj.fgno;
                            FGTestMaster_Class_Obj.Delete_tblFGCodeFamilyTestRelation();
                            FGTestMaster_Class_Obj.Delete_tblFGCodeFamilyTestRelationUP();
                            DataSet ds = new DataSet();

                            foreach (DataGridViewRow row in dgTest.Rows)
                            {
                                if (row.Cells["Mark"].Value != null && Convert.ToInt32(row.Cells["Mark"].Value) == 1)
                                {
                                    // dgTest["TestNo", i].Value;
                                    // FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(row.Cells["FGMethodNo"].Value);

                                    FGTestMaster_Class_Obj.testno = Convert.ToInt64(row.Cells["TestNo"].Value);
                                    FGTestMaster_Class_Obj.frequency = Convert.ToString(row.Cells["Fre"].Value);
                                    FGTestMaster_Class_Obj.inspectionmethod = Convert.ToString(row.Cells["Ins"].Value);

                                    ////======================Changed Code for Scoop Manish K =============================// 
                                    //FGTestMaster_Class_Obj.quality = (bool)row.Cells["Quality"].FormattedValue;
                                    //FGTestMaster_Class_Obj.up = (bool)row.Cells["UP"].FormattedValue;
                                    ////====================================================================================//

                                    ds = FGTestMaster_Class_Obj.Select_tblFinishGoodDetails_FGMethodNo();
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(ds.Tables[0].Rows[i]["FGMethodNo"]);
                                        FGTestMaster_Class_Obj.Scoop_Qty = false;
                                        FGTestMaster_Class_Obj.Insert_tblFGCodeFamilyTestRelation();
                               
                                    }


                                }
                                if (row.Cells["QualitySCOOP"].Value != null && Convert.ToInt32(row.Cells["QualitySCOOP"].Value) == 1)
                                {
                                    // dgTest["TestNo", i].Value;
                                    // FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(row.Cells["FGMethodNo"].Value);

                                    FGTestMaster_Class_Obj.testno = Convert.ToInt64(row.Cells["TestNo"].Value);
                                    FGTestMaster_Class_Obj.frequency = Convert.ToString(row.Cells["Fre"].Value);
                                    FGTestMaster_Class_Obj.inspectionmethod = Convert.ToString(row.Cells["Ins"].Value);

                                    ////======================Changed Code for Scoop Manish K =============================// 
                                    //FGTestMaster_Class_Obj.quality = (bool)row.Cells["Quality"].FormattedValue;
                                    //FGTestMaster_Class_Obj.up = (bool)row.Cells["UP"].FormattedValue;
                                    ////====================================================================================//

                                    ds = FGTestMaster_Class_Obj.Select_tblFinishGoodDetails_FGMethodNo();
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(ds.Tables[0].Rows[i]["FGMethodNo"]);
                                        FGTestMaster_Class_Obj.Scoop_Qty = true;
                                        FGTestMaster_Class_Obj.Insert_tblFGCodeFamilyTestRelation();

                                    }


                                }
                                if ((bool)row.Cells["UP"].FormattedValue == true)//<----------------------------- CODE TO SAVE SCOOP RECORDS(Manish K)
                                {

                                    FGTestMaster_Class_Obj.testno = Convert.ToInt64(row.Cells["TestNo"].Value);
                                    FGTestMaster_Class_Obj.frequency = Convert.ToString(row.Cells["Fre"].Value);
                                    FGTestMaster_Class_Obj.inspectionmethod = Convert.ToString(row.Cells["Ins"].Value);

                                    ds = FGTestMaster_Class_Obj.Select_tblFinishGoodDetails_FGMethodNo();
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        FGTestMaster_Class_Obj.fgmethodno = Convert.ToInt64(ds.Tables[0].Rows[i]["FGMethodNo"]);
                                        FGTestMaster_Class_Obj.Insert_tblFGCodeFamilyTestRelationUP();
                                    }


                                }
                            }
                           
                            MessageBox.Show("Record Update Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgTest.Rows.Clear();
                            txtFgCode.Enabled = true;
                            BtnReset_Click(sender, e);
                        }
                    }
                    Bind_List();
                    Bind_ComboFG();
                    SaveAs = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFgCode.Focus();
                Modify = false;
                SaveAs = false;
            }
        }

               

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Modify = false;
            Reset();
            Bind_List();
            txtSearch.Text = "";
            //txtFgCode.Focus();
        }

        private void Reset()
        {
            SaveAs = false;
            BtnDelete.Enabled = false;
            txtFgCode.Text = "";
            txtFillVolume.Text = "";
            txtFgCode.Enabled = true;
            cmbTechnicalFamily.Text = "--Select--";
            cmbFGGlobalFamily.Text = "--Select--";
            txtFgDesc.Text = "";
            chkKit.CheckState = CheckState.Unchecked;
            chkSemiFinish.Checked = false;
            CmbFormulaNo.Text = "--Select--";
            cmbFGMicro.Text = "Yes";
            CmbType.Text = "No Type";
            dgFormulaNo.Rows.Clear();
            dgFGCode.Rows.Clear();
            if (cmbTechnicalFamily.Text == "--Select--")
            {
                dgTest.Rows.Clear();
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            txtFgCode.Enabled = false;
            List.Enabled = true;            
            List_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //txtSearch.Text = Convert.ToString(List.Text);
                Reset();                
                if (List.SelectedValue == null)
                {
                    return;
                }

                #region Common values
                dgFormulaNo.Rows.Clear();

                DataSet ds = new DataSet();
                FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(List.SelectedValue.ToString()); 
                ds = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFgMaster_FGNo();

                txtFgCode.Text = List.Text;
                txtFgDesc.Text = ds.Tables[0].Rows[0]["FGDesc"].ToString();
                txtFillVolume.Text = ds.Tables[0].Rows[0]["FillVolume"].ToString();                

                PackingFamilyMaster_Class_Obj.pkgtechno = Convert.ToInt64(ds.Tables[0].Rows[0]["PKGTechNo"]);
                cmbTechnicalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["PkgTechNo"]);

                if (ds.Tables[0].Rows[0]["FGGlobalFamilyID"] is System.DBNull)
                {
                    cmbFGGlobalFamily.SelectedValue = 0;
                }
                else
                {
                    cmbFGGlobalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["FGGlobalFamilyID"]);
                }
                cmbTechnicalFamily_SelectionChangeCommitted(sender, e);
                #endregion

                if (ds.Tables[0].Rows[0]["SF"].ToString() == "1")
                // FG Code is either SF or kit.(It cant be both at a time)
                {
                    chkSemiFinish.Checked = true;

                    #region Fill grid
                    //with sub FG Unnder 
                    DataTable DtSubFg;
                    DtSubFg = FinishedGoodMaster_Class_Obj.SELECT_tblFgMaster_SubSF();
                    for (int i = 0; i < DtSubFg.Rows.Count; i++)
                    {
                        dgFGCode.Rows.Add();
                        dgFGCode["FGNo", dgFGCode.Rows.Count - 1].Value = DtSubFg.Rows[i]["FGNo"].ToString();
                        dgFGCode["FGCode", dgFGCode.Rows.Count - 1].Value = DtSubFg.Rows[i]["FGCode"].ToString();
                    }
                    #endregion
                }

                else // For Kit or normal Entry
                {
                    if (ds.Tables[0].Rows[0]["Kit"].ToString() == "0")
                    {
                        chkKit.CheckState = CheckState.Unchecked;
                    }
                    else if (ds.Tables[0].Rows[0]["Kit"].ToString() == "1")
                    {
                        chkKit.CheckState = CheckState.Checked;
                    }
                    #region Show formulas in greed
                    //DataSet ds1 = new DataSet();
                    //ds1 = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster_By_TechFamNo();
                    //if (ds1.Tables[0].Rows.Count > 0)
                    //{
                    //    cmbTechnicalFamily.Text = ds1.Tables[0].Rows[0]["TechFamDesc"].ToString();
                    //}

                    // Now get Formuala No
                    DataSet ds2 = new DataSet();
                    ds2 = FinishedGoodMaster_Class_Obj.SELECT_tblFgMaster_FormulaNo();
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        dgFormulaNo.Rows.Add();
                        dgFormulaNo["FNo", dgFormulaNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["FNo"].ToString();
                        dgFormulaNo["FormulaNo", dgFormulaNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["FormulaNo"].ToString();
                        if (Convert.ToInt16(ds2.Tables[0].Rows[i]["FGMicro"]) == 1)
                        {
                            dgFormulaNo["FGMicro", dgFormulaNo.Rows.Count - 1].Value = "Yes";
                        }
                        else if (Convert.ToInt16(ds2.Tables[0].Rows[i]["FGMicro"]) == 0)
                        {
                            dgFormulaNo["FGMicro", dgFormulaNo.Rows.Count - 1].Value = "No";
                        }
                        dgFormulaNo["Type", dgFormulaNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["Type"].ToString();
                    }
                    #endregion
                }

                //new change update code by virendra on 17/06/2010
                
              FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(List.SelectedValue.ToString());
                DataTable Dt = new DataTable();
            //  Dt = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFGCodeFamilyTestRelation_FGNoScoop();
                Dt = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFGCodeFamilyTestRelation_FGNo();

                //new change update code by Avinash on 11-07-2014
                 for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dgTest.Rows.Count; j++)
                    {

                        if (((bool)Dt.Rows[i]["IsSCOOPTest"] == false) && (Convert.ToInt64(Dt.Rows[i]["TestNo"]) == Convert.ToInt64(dgTest["TestNo", j].Value)) && (Convert.ToString(Dt.Rows[i]["InspectionMethod"]) == Convert.ToString(dgTest["Ins", j].Value)) && (Convert.ToString(Dt.Rows[i]["Frequency"]) == Convert.ToString(dgTest["Fre", j].Value))) // && (Convert.ToString(Dt.Rows[i]["TestNo"]) == Convert.ToString(dgPMPeriodicTest["ValPMTestNo", j].Value)))
                            dgTest["Mark", j].Value = 1;
                        if (((bool)Dt.Rows[i]["IsSCOOPTest"] == true) && (Convert.ToInt64(Dt.Rows[i]["TestNo"]) == Convert.ToInt64(dgTest["TestNo", j].Value)) && (Convert.ToString(Dt.Rows[i]["InspectionMethod"]) == Convert.ToString(dgTest["Ins", j].Value)) && (Convert.ToString(Dt.Rows[i]["Frequency"]) == Convert.ToString(dgTest["Fre", j].Value))) // && (Convert.ToString(Dt.Rows[i]["TestNo"]) == Convert.ToString(dgPMPeriodicTest["ValPMTestNo", j].Value)))
                            dgTest["QualitySCOOP", j].Value = 1;
                    }
                }

                 DataTable DT_UP = new DataTable();  //  ||<----------------------------------------------------------------- CODE FOR UP TO DISPLAY IN GRIDVIEW(SCOOP ,Manish K)

                 DT_UP = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFGCodeFamilyTestRelation_FGNoUP();
                 for (int i = 0; i < DT_UP.Rows.Count; i++)
                 {
                     for (int j = 0; j < dgTest.Rows.Count; j++)
                     {

                         if ((Convert.ToInt64(DT_UP.Rows[i]["TestNo"]) == Convert.ToInt64(dgTest["TestNo", j].Value)) && (Convert.ToString(DT_UP.Rows[i]["InspectionMethod"]) == Convert.ToString(dgTest["Ins", j].Value)) && (Convert.ToString(DT_UP.Rows[i]["Frequency"]) == Convert.ToString(dgTest["Fre", j].Value)))
                         {                           
                             dgTest["UP", j].Value = 1;// Convert.ToBoolean(Dt.Rows[i]["up"].ToString());
            
                         }

                     }
                 }



                BtnDelete.Enabled = true;
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
                FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(List.SelectedValue.ToString());
                if (FinishedGoodMaster_Class_Obj.fgno == 0)
                {
                    MessageBox.Show("Select Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //first delete 
                    FinishedGoodMaster_Class_Obj.Delete_tblFGMaster();

                    //We have to clear both tables tblFGLinkSF and tblFgMaster
                    FinishedGoodMaster_Class_Obj.Delete_tblFGLinkSF();                    
                    FinishedGoodMaster_Class_Obj.Delete_tblFgMaster_FormulaNo();
                    MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BtnReset_Click(sender, e);
                    BtnDelete.Enabled = false;
                    Bind_List();
                    Bind_ComboFG();
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Can't Delete This Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Modify = false;
                txtFgCode.Focus();
            }
        }

        private void txtFgCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(32))
            {
                e.Handled = true;
            }            
        }

        private void txtFgDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// Only 0-9 and a-z and A-Z allowed
            //if (e.KeyChar != Convert.ToChar(8))
            //{
            //    if (((e.KeyChar >= Convert.ToChar(48)) && (e.KeyChar <= Convert.ToChar(57))) || (e.KeyChar >= Convert.ToChar(65)) && (e.KeyChar <= Convert.ToChar(90)) || (e.KeyChar >= Convert.ToChar(97)) && (e.KeyChar <= Convert.ToChar(122)))
            //    {

            //    }
            //    else
            //    {
            //        e.Handled = true;
            //    }
            //}
        }

        private void txtFillVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// Only 0-9 and dot(.) allowed
            //if ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 46))
            //{
            //    if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
            //    {

            //    }
            //    else
            //    { e.Handled = true; }
            //}

        }

        private void txtFgCode_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtFgCode.Text = textInfo.ToTitleCase(txtFgCode.Text);
        }

        private void txtFgDesc_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtFgDesc.Text = textInfo.ToTitleCase(txtFgDesc.Text);
        }

        private void txtFillVolume_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtFillVolume.Text = textInfo.ToTitleCase(txtFillVolume.Text);
        }
        
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            List.Enabled = true;
            SaveAs = true;
            List_DoubleClick(sender, e); 
        }

        private void btnModify_Click_1(object sender, EventArgs e)
        {
            List.Enabled = true;
            Modify = true;
            List_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }
        
        private void btnFormulaAdd_Click(object sender, EventArgs e)
        {
            try
            {  
                if (CmbFormulaNo.SelectedValue == null || CmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CmbFormulaNo.Focus();
                    return;
                }               

                for (int i = 0; i < dgFormulaNo.Rows.Count; i++)
                {
                    if (dgFormulaNo["FNo", i].Value.ToString() == CmbFormulaNo.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("Update Micro?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            dgFormulaNo["FGMicro", i].Value = cmbFGMicro.Text;
                            btnFormulaReset_Click(sender, e);
                        }
                        return;                        
                    }
                }

                if (chkKit.Checked != true && dgFormulaNo.Rows.Count > 0)
                {
                    return;
                }

                dgFormulaNo.Rows.Add();
                dgFormulaNo["FNo", dgFormulaNo.Rows.Count - 1].Value = CmbFormulaNo.SelectedValue.ToString();
                dgFormulaNo["FormulaNo", dgFormulaNo.Rows.Count - 1].Value = CmbFormulaNo.Text;
                dgFormulaNo["FGMicro", dgFormulaNo.Rows.Count - 1].Value = cmbFGMicro.Text;
                dgFormulaNo["Type", dgFormulaNo.Rows.Count - 1].Value = CmbType.Text;
 
                btnFormulaReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFormulaReset_Click(object sender, EventArgs e)
        {
            CmbFormulaNo.Text = "--Select--";
            cmbFGMicro.Text = "Yes";
            CmbType.Text = "No Type";
            CmbFormulaNo.Focus();
        }

        private void btnFormulaDelete_Click(object sender, EventArgs e)
        {           
            if (dgFormulaNo.SelectedRows != null && dgFormulaNo.SelectedRows.Count != 0)
            {
                for (int i = 0; i < dgFormulaNo.SelectedRows.Count; i++)
                {
                    if (MessageBox.Show("Delete This Formuala..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        dgFormulaNo.Rows.Remove(dgFormulaNo.SelectedRows[i]);
                    }
                }
                btnFormulaReset_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please Select Formula From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgFormulaNo.Focus();
                return;
            }       
        }

        private void dgFormulaNo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CmbFormulaNo.Text = dgFormulaNo["FormulaNo", e.RowIndex].Value.ToString();
            cmbFGMicro.Text = dgFormulaNo["FGMicro", e.RowIndex].Value.ToString();
            CmbType.Text = dgFormulaNo["Type", e.RowIndex].Value.ToString();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void chkSemiFinish_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSemiFinish.Checked)
            {
                gbKit.Enabled = false;
                chkKit.Checked = false;
                gbSF.Enabled = true;
                dgFormulaNo.Rows.Clear();
            }
            else
            {
                gbKit.Enabled = true;
                gbSF.Enabled = false;
                dgFGCode.Rows.Clear();
            }
        }

        private void chkKit_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkKit.Checked)
            {
                gbSF.Enabled = false;
                chkSemiFinish.Checked = false;
                dgFGCode.Rows.Clear();
            }
            else
            {
                gbSF.Enabled = true;
            }
        }

        private void btnFGReset_Click(object sender, EventArgs e)
        {
            cmbFgCode.Text = "--Select--";
            cmbFgCode.Focus();
        }

        private void btnFGDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgFGCode.SelectedRows != null && dgFGCode.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgFGCode.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Formuala..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            dgFGCode.Rows.Remove(dgFGCode.SelectedRows[i]);
                        }
                    }
                    btnFGReset_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Please Select Formula From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgFGCode.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFGAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFgCode.SelectedValue == null || cmbFgCode.Text == "--Select--")
                {
                    MessageBox.Show("Select FG Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFgCode.Focus();
                    return;
                }

                for (int i = 0; i < dgFGCode.Rows.Count; i++)
                {
                    if (dgFGCode["FGNo", i].Value.ToString() == cmbFgCode.SelectedValue.ToString())
                    {
                        MessageBox.Show("FG Code Already Added?");
                        return;
                    }
                }

                if (chkSemiFinish.Checked == false)
                {
                    MessageBox.Show("Select SF");
                    chkSemiFinish.Focus();
                    return;
                }

                dgFGCode.Rows.Add();
                dgFGCode["FGNo", dgFGCode.Rows.Count - 1].Value = cmbFgCode.SelectedValue.ToString();
                dgFGCode["FGCode", dgFGCode.Rows.Count - 1].Value = cmbFgCode.Text;

                btnFGReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void List_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                List_DoubleClick(sender, e);
        }

        private void cmbTechnicalFamily_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //BtnReset_Click(sender, e);
            if ((cmbTechnicalFamily.SelectedValue.ToString() != null) && (cmbTechnicalFamily.SelectedValue.ToString() != ""))
            {
                //int i = Convert.ToInt32(cmbTechnicalFamily.SelectedValue.ToString());
                FGTestMaster_Class_Obj = new FGTestMaster_Class();
                FGTestMaster_Class_Obj.pkgtechno = Convert.ToInt32(cmbTechnicalFamily.SelectedValue);
                Fill_dataGridView1();
            }
            else if (cmbTechnicalFamily.Text == "--Select--")
            {
                dgTest.Rows.Clear();
            }
        }

        public void Fill_dataGridView1()
        {
            dgTest.Rows.Clear();
            DataSet ds = new DataSet();
            ds = FGTestMaster_Class_Obj.Select_FinishGoodDetails_PKGTechNo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgTest.Rows.Add();
                   //dgTest["FGMethodNo", i].Value = ds.Tables[0].Rows[i]["FGMethodNo"].ToString();
                    dgTest["TestNo", i].Value = ds.Tables[0].Rows[i]["TestNo"].ToString();
                    dgTest["TestMethod", i].Value = ds.Tables[0].Rows[i]["Test"].ToString();
                    dgTest["Fre", i].Value = ds.Tables[0].Rows[i]["Frequency"].ToString();
                    dgTest["Ins", i].Value = ds.Tables[0].Rows[i]["InspectionMethod"].ToString();
                   // dgTest_CellClick(object dgTest.r, DataGridViewCellEventArgs e);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = " FGCode like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "FGCode";
            List.ValueMember = "FGNo";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    Reset();
                    if (List.SelectedValue == null)
                    {
                        return;
                    }

                    #region Common values
                    dgFormulaNo.Rows.Clear();

                    DataSet ds = new DataSet();
                    FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(List.SelectedValue.ToString());
                    ds = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFgMaster_FGNo();

                    txtFgCode.Text = List.Text;
                    txtFgDesc.Text = ds.Tables[0].Rows[0]["FGDesc"].ToString();
                    txtFillVolume.Text = ds.Tables[0].Rows[0]["FillVolume"].ToString();

                    PackingFamilyMaster_Class_Obj.pkgtechno = Convert.ToInt64(ds.Tables[0].Rows[0]["PKGTechNo"]);
                    cmbTechnicalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["PkgTechNo"]);

                    if (ds.Tables[0].Rows[0]["FGGlobalFamilyID"] is System.DBNull)
                    {
                        cmbFGGlobalFamily.SelectedValue = 0;
                    }
                    else
                    {
                        cmbFGGlobalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["FGGlobalFamilyID"]);
                    }
                    cmbTechnicalFamily_SelectionChangeCommitted(sender, e);
                    #endregion

                    if (ds.Tables[0].Rows[0]["SF"].ToString() == "1")
                    // FG Code is either SF or kit.(It cant be both at a time)
                    {
                        chkSemiFinish.Checked = true;
                        #region Fill grid
                        //with sub FG Unnder 
                        DataTable DtSubFg;
                        DtSubFg = FinishedGoodMaster_Class_Obj.SELECT_tblFgMaster_SubSF();
                        for (int i = 0; i < DtSubFg.Rows.Count; i++)
                        {
                            dgFGCode.Rows.Add();
                            dgFGCode["FGNo", dgFGCode.Rows.Count - 1].Value = DtSubFg.Rows[i]["FGNo"].ToString();
                            dgFGCode["FGCode", dgFGCode.Rows.Count - 1].Value = DtSubFg.Rows[i]["FGCode"].ToString();
                        }
                        #endregion
                    }

                    else // For Kit or normal Entry
                    {
                        if (ds.Tables[0].Rows[0]["Kit"].ToString() == "0")
                        {
                            chkKit.CheckState = CheckState.Unchecked;
                        }
                        else if (ds.Tables[0].Rows[0]["Kit"].ToString() == "1")
                        {
                            chkKit.CheckState = CheckState.Checked;
                        }
                        #region Show formulas in greed
                        //DataSet ds1 = new DataSet();
                        //ds1 = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster_By_TechFamNo();
                        //if (ds1.Tables[0].Rows.Count > 0)
                        //{
                        //    cmbTechnicalFamily.Text = ds1.Tables[0].Rows[0]["TechFamDesc"].ToString();
                        //}

                        // Now get Formuala No
                        DataSet ds2 = new DataSet();
                        ds2 = FinishedGoodMaster_Class_Obj.SELECT_tblFgMaster_FormulaNo();
                        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                        {
                            dgFormulaNo.Rows.Add();
                            dgFormulaNo["FNo", dgFormulaNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["FNo"].ToString();
                            dgFormulaNo["FormulaNo", dgFormulaNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["FormulaNo"].ToString();
                            if (Convert.ToInt16(ds2.Tables[0].Rows[i]["FGMicro"]) == 1)
                            {
                                dgFormulaNo["FGMicro", dgFormulaNo.Rows.Count - 1].Value = "Yes";
                            }
                            else if (Convert.ToInt16(ds2.Tables[0].Rows[i]["FGMicro"]) == 0)
                            {
                                dgFormulaNo["FGMicro", dgFormulaNo.Rows.Count - 1].Value = "No";
                            }
                        }
                        #endregion
                    }

                    //new change update code by virendra on 17/06/2010

                    FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(List.SelectedValue.ToString());
                    DataTable Dt = new DataTable();
                    Dt = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFGCodeFamilyTestRelation_FGNo();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgTest.Rows.Count; j++)
                        {

                            if ((Convert.ToInt64(Dt.Rows[i]["TestNo"]) == Convert.ToInt64(dgTest["TestNo", j].Value)) && (Convert.ToString(Dt.Rows[i]["InspectionMethod"]) == Convert.ToString(dgTest["Ins", j].Value)) && (Convert.ToString(Dt.Rows[i]["Frequency"]) == Convert.ToString(dgTest["Fre", j].Value))) // && (Convert.ToString(Dt.Rows[i]["TestNo"]) == Convert.ToString(dgPMPeriodicTest["ValPMTestNo", j].Value)))
                                dgTest["Mark", j].Value = 1;
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
                    Reset();
                    if (List.SelectedValue == null)
                    {
                        return;
                    }

                    #region Common values
                    dgFormulaNo.Rows.Clear();

                    DataSet ds = new DataSet();
                    FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(List.SelectedValue.ToString());
                    ds = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFgMaster_FGNo();

                    txtFgCode.Text = List.Text;
                    txtFgDesc.Text = ds.Tables[0].Rows[0]["FGDesc"].ToString();
                    txtFillVolume.Text = ds.Tables[0].Rows[0]["FillVolume"].ToString();

                    PackingFamilyMaster_Class_Obj.pkgtechno = Convert.ToInt64(ds.Tables[0].Rows[0]["PKGTechNo"]);
                    cmbTechnicalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["PkgTechNo"]);

                    if (ds.Tables[0].Rows[0]["FGGlobalFamilyID"] is System.DBNull)
                    {
                        cmbFGGlobalFamily.SelectedValue = 0;
                    }
                    else
                    {
                        cmbFGGlobalFamily.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["FGGlobalFamilyID"]);
                    }
                    cmbTechnicalFamily_SelectionChangeCommitted(sender, e);
                    #endregion

                    if (ds.Tables[0].Rows[0]["SF"].ToString() == "1")
                    // FG Code is either SF or kit.(It cant be both at a time)
                    {
                        chkSemiFinish.Checked = true;
                        #region Fill grid
                        //with sub FG Unnder 
                        DataTable DtSubFg;
                        DtSubFg = FinishedGoodMaster_Class_Obj.SELECT_tblFgMaster_SubSF();
                        for (int i = 0; i < DtSubFg.Rows.Count; i++)
                        {
                            dgFGCode.Rows.Add();
                            dgFGCode["FGNo", dgFGCode.Rows.Count - 1].Value = DtSubFg.Rows[i]["FGNo"].ToString();
                            dgFGCode["FGCode", dgFGCode.Rows.Count - 1].Value = DtSubFg.Rows[i]["FGCode"].ToString();
                        }
                        #endregion
                    }

                    else // For Kit or normal Entry
                    {
                        if (ds.Tables[0].Rows[0]["Kit"].ToString() == "0")
                        {
                            chkKit.CheckState = CheckState.Unchecked;
                        }
                        else if (ds.Tables[0].Rows[0]["Kit"].ToString() == "1")
                        {
                            chkKit.CheckState = CheckState.Checked;
                        }
                        #region Show formulas in greed
                        //DataSet ds1 = new DataSet();
                        //ds1 = PackingFamilyMaster_Class_Obj.Select_tblPkgFamilyMaster_By_TechFamNo();
                        //if (ds1.Tables[0].Rows.Count > 0)
                        //{
                        //    cmbTechnicalFamily.Text = ds1.Tables[0].Rows[0]["TechFamDesc"].ToString();
                        //}

                        // Now get Formuala No
                        DataSet ds2 = new DataSet();
                        ds2 = FinishedGoodMaster_Class_Obj.SELECT_tblFgMaster_FormulaNo();
                        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                        {
                            dgFormulaNo.Rows.Add();
                            dgFormulaNo["FNo", dgFormulaNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["FNo"].ToString();
                            dgFormulaNo["FormulaNo", dgFormulaNo.Rows.Count - 1].Value = ds2.Tables[0].Rows[i]["FormulaNo"].ToString();
                            if (Convert.ToInt16(ds2.Tables[0].Rows[i]["FGMicro"]) == 1)
                            {
                                dgFormulaNo["FGMicro", dgFormulaNo.Rows.Count - 1].Value = "Yes";
                            }
                            else if (Convert.ToInt16(ds2.Tables[0].Rows[i]["FGMicro"]) == 0)
                            {
                                dgFormulaNo["FGMicro", dgFormulaNo.Rows.Count - 1].Value = "No";
                            }
                        }
                        #endregion
                    }

                    //new change update code by virendra on 17/06/2010

                    FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(List.SelectedValue.ToString());
                    DataTable Dt = new DataTable();
                    Dt = FinishedGoodMaster_Class_Obj.STP_SELECT_tblFGCodeFamilyTestRelation_FGNo();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgTest.Rows.Count; j++)
                        {

                            if ((Convert.ToInt64(Dt.Rows[i]["TestNo"]) == Convert.ToInt64(dgTest["TestNo", j].Value)) && (Convert.ToString(Dt.Rows[i]["InspectionMethod"]) == Convert.ToString(dgTest["Ins", j].Value)) && (Convert.ToString(Dt.Rows[i]["Frequency"]) == Convert.ToString(dgTest["Fre", j].Value))) // && (Convert.ToString(Dt.Rows[i]["TestNo"]) == Convert.ToString(dgPMPeriodicTest["ValPMTestNo", j].Value)))
                                dgTest["Mark", j].Value = 1;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            try
            {
                FinishedGoodMaster_Class objFinishedGoodMaster_Class = new FinishedGoodMaster_Class();
                DataSet ds = new DataSet();
                ds = objFinishedGoodMaster_Class.Select_All_Record_tblFGMaster();

               
                 ExportToExcel objExport = new ExportToExcel();
                 objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgTest_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (dgTest.RowCount > 0)
            //    {
            //        if (dgTest.CurrentCell.OwningColumn.Name == "Mark")
            //        {
            //            if ((bool)(dgTest.CurrentCell.FormattedValue) == false)
            //            {
            //                dgTest.CurrentCell.OwningRow.Cells["Quality"].Value = false;
            //                dgTest.CurrentCell.OwningRow.Cells["UP"].Value = false;

            //                dgTest.CurrentCell.OwningRow.Cells["Quality"].ReadOnly = true;
            //                dgTest.CurrentCell.OwningRow.Cells["UP"].ReadOnly = true;
                           
            //            }
            //            else
            //            {
                        
            //                dgTest.CurrentCell.OwningRow.Cells["Quality"].ReadOnly = false;
            //                dgTest.CurrentCell.OwningRow.Cells["UP"].ReadOnly = false;
            //            }
            //        }
            //    }
              
            //}
            //catch
            //{

            //}

        }

        private void dgTest_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           //dgTest_CellValueChanged(sender, e);
        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (GlobalVariables.City.ToLower() == "pune")
            {
                DataSet Ds = new DataSet();
                FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                Ds = FormulaNoMaster_Class_Obj.Select_From_TblBulkMaster_By_FNo();
                string StrFDExport = Convert.ToString(Ds.Tables[0].Rows[0]["FDAApprovalDateExport"]);
                string StrFDLocal = Convert.ToString(Ds.Tables[0].Rows[0]["FDAApprovalDate"]);
                if (StrFDLocal != "" && StrFDExport != "")
                {
                    DateTime FDADAte = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
                    DateTime FDADAteLocal = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDate"].ToString());
                    if (MessageBox.Show("This Formuala under FDA Local date : " + FDADAteLocal.ToString("dd-MMM-yyyy") + " and FDA Export date : " + FDADAte.ToString("dd-MMM-yyyy") + " Do you want continue with formula. ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        //dgFGCode.Rows.Remove(dgFGCode.SelectedRows[i]);
                    }
                    else
                    {
                        CmbFormulaNo.Text = "--Select--";
                    }
                }
                else if (StrFDLocal != "" && StrFDExport == "")
                {
                    //DateTime FDADAte = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
                    DateTime FDADAteLocal = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDate"].ToString());
                    if (MessageBox.Show("This Formuala under FDA Local date : " + FDADAteLocal.ToString("dd-MMM-yyyy") + " Do you want continue with formula. ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        //dgFGCode.Rows.Remove(dgFGCode.SelectedRows[i]);
                    }
                    else
                    {
                        CmbFormulaNo.Text = "--Select--";
                    }
                }
                else if (StrFDLocal == "" && StrFDExport != "")
                {
                    DateTime FDADAte = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
                    //DateTime FDADAteLocal = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDate"].ToString());
                    if (MessageBox.Show("This Formuala under FDA Export date : " + FDADAte.ToString("dd-MMM-yyyy") + " Do you want continue with formula. ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        //dgFGCode.Rows.Remove(dgFGCode.SelectedRows[i]);
                    }
                    else
                    {
                        CmbFormulaNo.Text = "--Select--";
                    }
                }

                //if (Ds.Tables[0].Rows[0]["FDAApprovalDateExport"] is System.DBNull)
                //{ }
                //else
                //{
                //    DateTime FDADAte = Convert.ToDateTime(Ds.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
                //    if (MessageBox.Show("This Formuala under FDA Export date : " + FDADAte.ToString("dd-MMM-yyyy") + " Do you want continue with formula. ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                //    {
                //        //dgFGCode.Rows.Remove(dgFGCode.SelectedRows[i]);
                //    }
                //    else
                //    {
                //        CmbFormulaNo.Text = "--Select--";
                //    }
                //    //DtpFDAApprovalExport.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["FDAApprovalDateExport"].ToString());
                //}
            }
        }

    }
}