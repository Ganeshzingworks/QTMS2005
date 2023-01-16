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
    public partial class FrmCompatibility : Form
    {
        public FrmCompatibility()
        {
            InitializeComponent();
        }

        # region Varibles
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        CompatibilityMaster_Class CompatibilityMaster_Class_Obj = new BusinessFacade.CompatibilityMaster_Class();        
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();        
        # endregion

        private static FrmCompatibility frmCompatibility_Obj = null;
        public static FrmCompatibility GetInstance()
        {
            if (frmCompatibility_Obj == null)
            {
                frmCompatibility_Obj = new FrmCompatibility();
            }
            return frmCompatibility_Obj;
        }

        private void FrmCompatibility_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                Bind_FormulaNo();
                Bind_InspectedBy();
                Bind_AcNatureReference();
                Bind_AcMaterialReference();

                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);               
            }
        }        

        private void Bind_AcNatureReference()
        {
            try
            {
                DataGridViewComboBoxColumn DataGridViewComboBoxColumnObj;
                DataGridViewComboBoxColumnObj = (DataGridViewComboBoxColumn)(dgPkgDesc.Columns[0]);
                DataTable DtNatureRef = new DataTable();
                DataRow dr;
                DtNatureRef = CompatibilityMaster_Class_Obj.SELECT_tblCompatAcNatureMaster();

                dr = DtNatureRef.NewRow();
                dr["AcNatureNo"] = "0";
                dr["AcNatureRef"] = "--Select--";

                DtNatureRef.Rows.InsertAt(dr, 0);
                
                if (DtNatureRef.Rows.Count > 0)
                {
                    DataGridViewComboBoxColumnObj.DataSource = DtNatureRef;
                    DataGridViewComboBoxColumnObj.ValueMember = "AcNatureNo";
                    DataGridViewComboBoxColumnObj.DisplayMember = "AcNatureRef";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Bind_AcMaterialReference()
        {
            try
            {
                DataGridViewComboBoxColumn DataGridViewComboBoxColumnObj;
                DataGridViewComboBoxColumnObj = (DataGridViewComboBoxColumn)(dgPkgDesc.Columns[1]);
                DataTable DtMaterialRef = new DataTable();
                DataRow dr;
                DtMaterialRef = CompatibilityMaster_Class_Obj.SELECT_CompatAcMaterialMaster();

                dr = DtMaterialRef.NewRow();
                dr["AcMaterialNo"] = "0";
                dr["AcMaterialRef"] = "--Select--";
                DtMaterialRef.Rows.InsertAt(dr, 0);

                if (DtMaterialRef.Rows.Count > 0)
                {
                    DataGridViewComboBoxColumnObj.DataSource = DtMaterialRef;
                    DataGridViewComboBoxColumnObj.ValueMember = "AcMaterialNo";
                    DataGridViewComboBoxColumnObj.DisplayMember = "AcMaterialRef";
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
                CmbFormulaNo.ValueMember = "FNo";
                CmbFormulaNo.DisplayMember = "FormulaNo";
            }
        }

        public void Bind_InspectedBy()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
            ds = UserManagement_Class_Obj.Select_AllUser();
            dr = ds.Tables[0].NewRow();
            dr["UserName"] = "--Select--";
            dr["UserID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbInspectedBy.DataSource = ds.Tables[0];
                cmbInspectedBy.DisplayMember = "UserName";
                cmbInspectedBy.ValueMember = "UserID";
            }
        }   

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //CmbFormulaNo.Text = "--Select--";
            //DtpControl 
            Reset();
            
        }

        private void Reset()
        {
            try
            {
                txtBulkDesc.Clear();
                txtTechnicalFamily.Clear();
                txtFillVolume.Clear();
                txtReportNo.Clear();
                cmbType.SelectedIndex = 0;

                DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpInitialStudy.Value = DtpInspDate.Value;

                dgPkgDesc.Rows.Clear();

                //txtLossOfPressure.Clear();
                cmbInspectedBy.Text = "--Select--";
                cmbNatureOfDefect.Text = "No Defect";
                RdoCompatible.Checked = true;
                txtComment.Clear();
               
                for (int i = 0; i < dgObs.Columns.Count; i++)
                {
                    if (!(dgObs.Columns[i].Name.Contains("Weight")))
                    {
                        dgObs.Columns.Remove(dgObs.Columns[i].Name);
                        i--;
                    }                   
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
           

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            { 
                if (CmbFormulaNo.SelectedValue != null && CmbFormulaNo.SelectedValue.ToString() != "")
                {
                    Reset();
                    dgPkgDesc.Rows.Clear();
                    DataSet ds = new DataSet();
                    FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                    ds = FormulaNoMaster_Class_Obj.SELECT_TblBulkMaster_tblblkfamilyMaster();
                    if (ds.Tables[0].Rows.Count > 0)
                    {                        
                        txtBulkDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);                       
                        txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);                        
                    }
                    CompatibilityMaster_Class_Obj.formulaNo = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());

                    DataSet dsCompat = new DataSet();
                    dsCompat = CompatibilityMaster_Class_Obj.Select_Compatibility_FNo();
                    foreach (DataRow dr in dsCompat.Tables[0].Rows)
                    {
                        CompatibilityMaster_Class_Obj.compNo = Convert.ToInt64(dr["CompNo"]);
                        cmbType.Text = Convert.ToString(dr["ReportType"]);
                        txtFillVolume.Text = Convert.ToString(dr["FillVolume"]);
                        DtpInspDate.Value = Convert.ToDateTime(dr["InspDate"]);
                        DtpInitialStudy.Value = Convert.ToDateTime(dr["InitialStudyDate"]);
                        DtpControl.Value = Convert.ToDateTime(dr["ControlDate"]);
                        cmbInspectedBy.SelectedValue = Convert.ToInt32(dr["InspectedBy"]);
                        cmbNatureOfDefect.Text = Convert.ToString(dr["NatureOfDefect"]);
                        if (Convert.ToChar(dr["Conclusion"]) == 'C')
                        {
                            RdoCompatible.Checked = true;
                        }
                        else if (Convert.ToChar(dr["Conclusion"]) == 'N')
                        {
                            RdoNonCompatible.Checked = true;
                        }
                        txtComment.Text = Convert.ToString(dr["Comment"]);
                        txtReportNo.Text = Convert.ToString(dr["ReportNo"]);
                    }

                    if (CompatibilityMaster_Class_Obj.compNo > 0)
                    {                        
                        DataSet dsPkgDesc = new DataSet();
                        dsPkgDesc = CompatibilityMaster_Class_Obj.Select_CompatibilityPkgDesc_CompNo();
                        
                        

                        foreach (DataRow dr in dsPkgDesc.Tables[0].Rows)
                        {
                            dgPkgDesc.Rows.Add();
                            dgPkgDesc["NatureOfACRef", dgPkgDesc.Rows.Count-2].Value = dr["NatureOfACRef"];
                            dgPkgDesc["ACMaterialRef", dgPkgDesc.Rows.Count-2].Value = dr["ACMaterialRef"];
                            dgPkgDesc["Supplier", dgPkgDesc.Rows.Count-2].Value = dr["Supplier"];
                            dgPkgDesc["Description", dgPkgDesc.Rows.Count-2].Value = dr["Description"];
                            
                        }
                    }
                    BindTest_FormulaNo();

                    
                    DataSet ds1 = new DataSet();
                    ds1 = CompatibilityMaster_Class_Obj.Select_CompatibilityTestDetails_FNo_GetStatus();

                    dgObs["Weight", 0].Value = "";
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        
                        if (Convert.ToInt32(dr["TestNo"]) != 0)
                        {
                            cmbTestName.SelectedValue = Convert.ToInt32(dr["TestNo"]);
                            btnAdd_Click(sender, e);
                            dgObs[cmbTestName.SelectedValue.ToString(), 0].Value = Convert.ToString(dr["Status"]);
                        }
                        else
                        {
                            dgObs["Weight", 0].Value = Convert.ToString(dr["Status"]);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbNatureOfDefect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbNatureOfDefect.Text == "Major")
                {
                    RdoNonCompatible.Checked = true;
                }
                else
                {
                    RdoCompatible.Checked = true;
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

        private void dgObs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == 0 && e.ColumnIndex == dgObs.Columns["Weight"].Index)
                {
                    FrmCompatWeight.Detail detailObj = new FrmCompatWeight.Detail();

                    detailObj.testNo = Convert.ToInt32(0);
                    detailObj.FNo = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                    detailObj.formulaType = string.Empty;
                    FrmCompatWeight frm = new FrmCompatWeight(detailObj);
                    frm.ShowDialog();

                    CompatibilityMaster_Class_Obj.formulaNo = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                    DataSet ds1 = new DataSet();
                    ds1 = CompatibilityMaster_Class_Obj.Select_CompatibilityTestDetails_FNo_GetStatus();
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(dr["TestNo"]) == 0)
                        {
                            dgObs[e.ColumnIndex, e.RowIndex].Value = Convert.ToString(dr["Status"]);
                        }
                         
                    }
                }
                else if (e.RowIndex == 0 && e.ColumnIndex > 0)
                {
                    FrmCompatTest.Detail detailObj = new FrmCompatTest.Detail();
                    detailObj.testNo = Convert.ToInt32(dgObs.Columns[e.ColumnIndex].Name);
                    detailObj.FNo = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                    string[] str = dgObs.Columns[e.ColumnIndex].HeaderText.Split('-');
                    if (str.Length > 0)
                        detailObj.formulaType = str[1];
                    else
                        detailObj.formulaType = string.Empty;

                    
                    

                    FrmCompatTest frm = new FrmCompatTest(detailObj);
                    frm.ShowDialog();

                    CompatibilityMaster_Class_Obj.formulaNo = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                    DataSet ds1 = new DataSet();
                    ds1 = CompatibilityMaster_Class_Obj.Select_CompatibilityTestDetails_FNo_GetStatus();
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        if (Convert.ToInt32(dr["TestNo"]) == Convert.ToInt32(dgObs.Columns[e.ColumnIndex].Name))
                        {
                            dgObs[e.ColumnIndex, e.RowIndex].Value = Convert.ToString(dr["Status"]);
                        }

                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                if (IsValid())
                {
                    CompatibilityMaster_Class_Obj.formulaNo = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                    CompatibilityMaster_Class_Obj.fillVolume = txtFillVolume.Text.Trim();
                    CompatibilityMaster_Class_Obj.reportNo = Convert.ToString(txtReportNo.Text.Trim());
                    CompatibilityMaster_Class_Obj.reportType = cmbType.Text;
                    CompatibilityMaster_Class_Obj.inspectionDate = DtpInspDate.Value.ToShortDateString();
                    CompatibilityMaster_Class_Obj.initialStudyDate = DtpInitialStudy.Value.ToShortDateString();

                    CompatibilityMaster_Class_Obj.controlDate = DtpControl.Value.ToShortDateString();
                    //CompatibilityMaster_Class_Obj.pressureLoss = txtLossOfPressure.Text.Trim();

                    CompatibilityMaster_Class_Obj.loginid = FrmMain.LoginID;
                    CompatibilityMaster_Class_Obj.inspectedBy = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                    CompatibilityMaster_Class_Obj.natureOfDefect = cmbNatureOfDefect.Text;
                    if (RdoCompatible.Checked) 
                        CompatibilityMaster_Class_Obj.compatible ='C' ;
                    if (RdoNonCompatible.Checked)
                        CompatibilityMaster_Class_Obj.compatible = 'N';
                    
                    CompatibilityMaster_Class_Obj.comment = txtComment.Text.Trim();
                     DataSet dsCompat = new DataSet();
                    dsCompat = CompatibilityMaster_Class_Obj.Select_Compatibility_FNo();
                    if (dsCompat.Tables[0].Rows.Count > 0)
                    {
                        CompatibilityMaster_Class_Obj.compNo = Convert.ToInt64(dsCompat.Tables[0].Rows[0]["CompNo"]);
                        CompatibilityMaster_Class_Obj.Update_Compatibility();
                    }
                    else
                    {
                        CompatibilityMaster_Class_Obj.compNo = CompatibilityMaster_Class_Obj.Insert_Compatibility();
                    }

                    CompatibilityMaster_Class_Obj.Delete_CompatPkgDesc_CompNo();
                    for (int i = 0; i < dgPkgDesc.Rows.Count; i++)
                    {                         
                        if (!dgPkgDesc.Rows[i].IsNewRow)
                        {
                            CompatibilityMaster_Class_Obj.natureOfACRef = Convert.ToInt32(dgPkgDesc["NatureOfACRef", i].Value);
                            CompatibilityMaster_Class_Obj.aCMaterialRef = Convert.ToInt32(dgPkgDesc["ACMaterialRef", i].Value);                            
                            CompatibilityMaster_Class_Obj.supplier = Convert.ToString(dgPkgDesc["Supplier", i].Value).Trim();
                            CompatibilityMaster_Class_Obj.packingDescription = Convert.ToString(dgPkgDesc["Description", i].Value).Trim();                        
                            CompatibilityMaster_Class_Obj.Insert_CompatPkgDesc();
                        }
                    }
                    
                    MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsValid()
        {
            try
            {
                if (CmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Please select formula number");
                    CmbFormulaNo.Focus();
                    return false;
                }
                if (txtFillVolume.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter FillVolume");
                    txtFillVolume.Focus();
                    return false;
                }
                if (cmbType.Text == "--Select--")
                {
                    MessageBox.Show("Please select type");
                    cmbType.Focus();
                    return false;
                }

                #region GridValidation
                int Count = 0;
                for (int i = 0; i < dgPkgDesc.Rows.Count; i++)
                {
                    if (!dgPkgDesc.Rows[i].IsNewRow)
                    {
                        Count++;
                        if (Convert.ToString(dgPkgDesc["NatureOfACRef", i].Value) == "--Select--")
                        {
                            MessageBox.Show("Please fill Nature Of AC/Ref");
                            dgPkgDesc["NatureOfACRef", i].Selected = true;
                            return false;
                        }

                        if (Convert.ToString(dgPkgDesc["ACMaterialRef", i].Value) == "--Select--")
                        {
                            MessageBox.Show("Please fill AC Material/Ref");
                            dgPkgDesc["ACMaterialRef", i].Selected = true;
                            return false;
                        }

                        if (Convert.ToString(dgPkgDesc["Supplier", i].Value).Trim() == "")
                        {
                            MessageBox.Show("Please fill Supplier");
                            dgPkgDesc["Supplier", i].Selected = true;
                            return false;
                        }
                    }
                }

                if (Count == 0)
                {
                    MessageBox.Show("Please select values for packing description");
                    dgPkgDesc["NatureOfACRef", 0].Selected = true;
                    return false;
                }
                #endregion

                if (cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please select inspected by");
                    cmbInspectedBy.Focus();
                    return false;
                }

                if (RdoNonCompatible.Checked)
                {
                    if (txtComment.Text.Trim() == "")
                    {
                        MessageBox.Show("Please fill comment");
                        txtComment.Focus();
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BindTest_FormulaNo()
        {
            try
            {                  
                DataSet ds = new DataSet();
                DataRow dr;
                FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                ds = FormulaNoMaster_Class_Obj.SELECT_BulkPhysicochemicalTestMethodMaster_tblTestMaster_FNo();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["TestNo"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbTestName.DataSource = ds.Tables[0];
                    cmbTestName.ValueMember = "TestNo";
                    cmbTestName.DisplayMember = "Details";
                }          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            try
            {
                if (cmbTestName.SelectedValue.ToString() != "0")
                {
                    foreach (DataGridViewColumn col in dgObs.Columns)
                    {
                        if (col.HeaderText.Contains(cmbTestName.Text.Trim()))
                        {
                            MessageBox.Show("Test Already Added! ","Test",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            cmbTestName.Focus();
                            return;
                        }
                    }
                   
                    dgObs.Columns.Add(cmbTestName.SelectedValue.ToString(), cmbTestName.Text);
                    dgObs.Columns[cmbTestName.SelectedValue.ToString()].Width = 150;
                }
                else
                {
                    MessageBox.Show("Please select Test");
                    cmbTestName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProtocol_Click(object sender, EventArgs e)
        {
            try
            {

                if (CmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Please select formula number");
                    CmbFormulaNo.Focus();
                    return ;
                }
                if (txtFillVolume.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter FillVolume");
                    txtFillVolume.Focus();
                    return ;
                }
                if (cmbType.Text == "--Select--")
                {
                    MessageBox.Show("Please select type");
                    cmbType.Focus();
                    return ;
                }
                if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbInspectedBy.Focus();
                    return;
                }

                CompatibilityMaster_Class_Obj.formulaNo = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                CompatibilityMaster_Class_Obj.fillVolume = txtFillVolume.Text.Trim();
                CompatibilityMaster_Class_Obj.reportNo = Convert.ToString(txtReportNo.Text.Trim());
                CompatibilityMaster_Class_Obj.reportType = cmbType.Text;
                CompatibilityMaster_Class_Obj.inspectionDate = DtpInspDate.Value.ToShortDateString();
                CompatibilityMaster_Class_Obj.initialStudyDate = DtpInitialStudy.Value.ToShortDateString();

                CompatibilityMaster_Class_Obj.controlDate = DtpControl.Value.ToShortDateString();
                //CompatibilityMaster_Class_Obj.pressureLoss = txtLossOfPressure.Text.Trim();

                CompatibilityMaster_Class_Obj.loginid = FrmMain.LoginID;
                CompatibilityMaster_Class_Obj.inspectedBy = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                DataSet dsCompat = new DataSet();
                dsCompat = CompatibilityMaster_Class_Obj.Select_Compatibility_FNo();
                if (dsCompat.Tables[0].Rows.Count > 0)
                {
                    CompatibilityMaster_Class_Obj.compNo = Convert.ToInt64(dsCompat.Tables[0].Rows[0]["CompNo"]);
                    CompatibilityMaster_Class_Obj.Update_Compatibility();
                }
                else
                {
                    CompatibilityMaster_Class_Obj.compNo = CompatibilityMaster_Class_Obj.Insert_Compatibility();
                }

                string ProtocolNo = "";
                if (CompatibilityMaster_Class_Obj.compNo != 0)
                {
                    ProtocolNo = "Compat" + CompatibilityMaster_Class_Obj.compNo.ToString().PadLeft(6, '0');
                }

                QTMS.Reports_Forms.FrmCompatibilityProtocol objProtocol = new QTMS.Reports_Forms.FrmCompatibilityProtocol("Compatibility Protocol", Convert.ToInt64(CmbFormulaNo.SelectedValue), ProtocolNo, cmbInspectedBy.Text.Trim());
                objProtocol.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }
    }
}