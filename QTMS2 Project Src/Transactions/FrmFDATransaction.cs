using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade.Transactions;
using QTMS.Tools;

namespace QTMS.Transactions
{
    public partial class FrmFDATransaction : System.Windows.Forms.Form
    {
        public FrmFDATransaction()
        {            
            InitializeComponent();
        }
        
        #region Variables
       
        FDATransaction_Class FDATransaction_Class_obj = new FDATransaction_Class();
        #endregion

        private static FrmFDATransaction frmFDATransaction_Obj = null;

        public static FrmFDATransaction GetInstance()
        {
            if (frmFDATransaction_Obj == null)
            {
                frmFDATransaction_Obj = new Transactions.FrmFDATransaction();
            }
            return frmFDATransaction_Obj;
        }

        private void FrmFDATransaction_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            Bind_Details();
            Bind_InspectedBy();
        }

        public void Bind_Details()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = FDATransaction_Class_obj.Select_PendingFDADetails();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["FMID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                
                cmbFDADetails.DataSource = ds.Tables[0];
                cmbFDADetails.DisplayMember = "Details";
                cmbFDADetails.ValueMember = "FMID";         
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void reset()
        {
            txtTechnicalFamily.Clear();
            txtBulkDescription.Clear();

            dgControlTest.Rows.Clear();
            dgIdTest.Rows.Clear();
            dgAnalysisTest.Rows.Clear();

            rdoAccepted.Checked = false;
            rdoRejected.Checked = false;
            rdoHold.Checked = false;

            RdoFDABPC.Checked = false;
            RdoFDANonBPC.Checked = false;
            
            cmbInspectedBy.Text = "--Select--"; 
        }

        private void BtnFDATRansactionReset_Click(object sender, EventArgs e)
        {
            Bind_Details();
            reset();
        }

         private void cmbFDADetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                reset();

                if (cmbFDADetails.SelectedValue.ToString() != null && cmbFDADetails.SelectedValue.ToString() != "")
                {

                    FDATransaction_Class_obj.fmid = Convert.ToInt64(cmbFDADetails.SelectedValue.ToString());

                    //To Feel Descriptions
                    DataTable Dt;
                    Dt = FDATransaction_Class_obj.Select_FDATransactionDetails_FMID();
                    if (Dt.Rows.Count > 0)
                    {
                        txtTechnicalFamily.Text = Dt.Rows[0]["FamilyDesc"].ToString().Trim();
                        txtBulkDescription.Text = Dt.Rows[0]["BulkDesc"].ToString().Trim();
                    }                    

                    //To Feel Control greed
                    DataSet dscontrol = new DataSet();
                    dscontrol = FDATransaction_Class_obj.Select_FDAPhysicochemicalTestMethodMaster_TestMaster_Control_FMID();                   

                    if (dscontrol.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dscontrol.Tables[0].Rows.Count; i++)
                        {
                            dgControlTest.Rows.Add();
                            dgControlTest["ValFDATransactionControlMethodNo", dgControlTest.Rows.Count - 1].Value = dscontrol.Tables[0].Rows[i]["FDAPhyMethodNo"].ToString();
                            dgControlTest["ValFDATransactionControlTestNo", dgControlTest.Rows.Count - 1].Value = dscontrol.Tables[0].Rows[i]["TestNo"].ToString();
                            dgControlTest["ValFDATransactionControlTestName", dgControlTest.Rows.Count - 1].Value = dscontrol.Tables[0].Rows[i]["TestName"].ToString();
                            dgControlTest["ValFDATransactionControlMin", dgControlTest.Rows.Count - 1].Value = dscontrol.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgControlTest["ValFDATransactionControlMax", dgControlTest.Rows.Count - 1].Value = dscontrol.Tables[0].Rows[i]["NormsMax"].ToString();
                        }
                    }

                    //To Feel identification greed
                    DataSet dsidentification = new DataSet();
                    dsidentification = FDATransaction_Class_obj.Select_FDAPhysicochemicalTestMethodMaster_TestMaster_Identification_FMID();

                    if (dsidentification.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsidentification.Tables[0].Rows.Count; i++)
                        {
                            dgIdTest.Rows.Add();
                            dgIdTest["ValFDATransactionIdMethodNo", dgIdTest.Rows.Count - 1].Value = dsidentification.Tables[0].Rows[i]["FDAPhyMethodNo"].ToString();
                            dgIdTest["ValFDATransactionIdTestNo", dgIdTest.Rows.Count - 1].Value = dsidentification.Tables[0].Rows[i]["TestNo"].ToString();
                            dgIdTest["ValFDATransactionIdTestName", dgIdTest.Rows.Count - 1].Value = dsidentification.Tables[0].Rows[i]["TestName"].ToString();
                            dgIdTest["ValFDATransactionIdMin", dgIdTest.Rows.Count - 1].Value = dsidentification.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgIdTest["ValFDATransactionIdMax", dgIdTest.Rows.Count - 1].Value = dsidentification.Tables[0].Rows[i]["NormsMax"].ToString();
                        }
                    }


                    //To Feel analysis greed
                    DataSet dsanalysis = new DataSet();
                    dsanalysis = FDATransaction_Class_obj.Select_FDAPhysicochemicalTestMethodMaster_TestMaster_Analysis_FMID();


                    if (dsanalysis.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsanalysis.Tables[0].Rows.Count; i++)
                        {
                            dgAnalysisTest.Rows.Add();
                            dgAnalysisTest["ValFDATransactionAnalysisMethodNo", dgAnalysisTest.Rows.Count - 1].Value = dsanalysis.Tables[0].Rows[i]["FDAPresMethodNo"].ToString();
                            dgAnalysisTest["ValFDATransactionAnalysisTestNo", dgAnalysisTest.Rows.Count - 1].Value = dsanalysis.Tables[0].Rows[i]["Prsno"].ToString();
                            dgAnalysisTest["ValFDATransactionAnalysisTest", dgAnalysisTest.Rows.Count - 1].Value = dsanalysis.Tables[0].Rows[i]["PresType"].ToString();
                            dgAnalysisTest["ValFDATransactionAnalysisMin", dgAnalysisTest.Rows.Count - 1].Value = dsanalysis.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgAnalysisTest["ValFDATransactionAnalysisMax", dgAnalysisTest.Rows.Count - 1].Value = dsanalysis.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgAnalysisTest["PresFormula", dgAnalysisTest.Rows.Count - 1].Value = dsanalysis.Tables[0].Rows[i]["PresFormula"].ToString();
                        }
                        //for (int i = 0; i < dsanalysis.Tables[0].Rows.Count; i++)
                        //{
                        //    dgFDATransactionAnalysis1.Rows.Add();
                        //    dgFDATransactionAnalysis1["ValFDATransactionAnalysisMethodNo", dgFDATransactionAnalysis1.Rows.Count - 1].Value = dsanalysis.Tables[0].Rows[i]["FDAPresMethodNo"].ToString();
                        //    dgFDATransactionAnalysis1["ValFDATransactionAnalysisTestNo", dgFDATransactionAnalysis1.Rows.Count - 1].Value = dsanalysis.Tables[0].Rows[i]["Prsno"].ToString();
                        //    dgFDATransactionAnalysis1["ValFDATransactionAnalysisTest", dgFDATransactionAnalysis1.Rows.Count - 1].Value = dsanalysis.Tables[0].Rows[i]["PresType"].ToString();
                        //    dgFDATransactionAnalysis1["ValFDATransactionAnalysisMin", dgFDATransactionAnalysis1.Rows.Count - 1].Value = dsanalysis.Tables[0].Rows[i]["NormsMin"].ToString();
                        //    dgFDATransactionAnalysis1["ValFDATransactionAnalysisMax", dgFDATransactionAnalysis1.Rows.Count - 1].Value = dsanalysis.Tables[0].Rows[i]["NormsMax"].ToString();
                        //}
                    }
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       

        private Boolean IsValidData()
        {
            #region Check Completion Of Data

            if (cmbFDADetails.Text == "--Select--")
            {
                MessageBox.Show("Please Select Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!rdoHold.Checked)
            {
                #region Identification 
                for (int i = 0; i < dgIdTest.Rows.Count; i++)
                {
                    if (dgIdTest["ValFDATransactionIdReading", i].Value == null || dgIdTest["ValFDATransactionIdReading", i].Value.ToString().Trim() == "")
                    {

                        MessageBox.Show("Please Enter All Norms Reading for Identification Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgIdTest.Focus();
                        return false;
                    }
                }
                #endregion

                #region Control
                for (int i = 0; i < dgControlTest.Rows.Count; i++)
                {
                    if (dgControlTest["ValFDATransactionControlReading", i].Value == null || dgControlTest["ValFDATransactionControlReading", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Enter All Norms Reading for Control Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgControlTest.Focus();
                        return false;
                    }
                }
                #endregion

                #region Analysis
                for (int i = 0; i < dgAnalysisTest.Rows.Count; i++)
                {
                    if (dgAnalysisTest["ValFDATransactionAnalysisMin", i].Value == null || dgAnalysisTest["ValFDATransactionAnalysisMin", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Enter All Norms Reading for Analysis Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgAnalysisTest.Focus();
                        return false;
                    }

                    if (dgAnalysisTest["ValFDATransactionAnalysisMax", i].Value == null || dgAnalysisTest["ValFDATransactionAnalysisMax", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Enter All Norms Reading for Analysis Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgAnalysisTest.Focus();
                        return false;
                    }

                    if (dgAnalysisTest["PresFormula", i].Value == null || dgAnalysisTest["PresFormula", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Enter All Norms Reading for Analysis Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgAnalysisTest.Focus();
                        return false;
                    }

                    if (dgAnalysisTest["WeightSample", i].Value == null || dgAnalysisTest["WeightSample", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Enter All Norms Reading for Analysis Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgAnalysisTest.Focus();
                        return false;
                    }

                    if (dgAnalysisTest["WeightReference", i].Value == null || dgAnalysisTest["WeightReference", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Enter All Norms Reading for Analysis Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgAnalysisTest.Focus();
                        return false;
                    }

                    if (dgAnalysisTest["AreaSample", i].Value == null || dgAnalysisTest["AreaSample", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Enter All Norms Reading for Analysis Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgAnalysisTest.Focus();
                        return false;
                    }

                    if (dgAnalysisTest["AreaReference", i].Value == null || dgAnalysisTest["AreaReference", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Enter All Norms Reading for Analysis Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgAnalysisTest.Focus();
                        return false;
                    }
                    
                    if (dgAnalysisTest["VolumeSample", i].Value == null || dgAnalysisTest["VolumeSample", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Enter All Norms Reading for Analysis Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgAnalysisTest.Focus();
                        return false;
                    }

                    if (dgAnalysisTest["AssayConc", i].Value == null || dgAnalysisTest["AssayConc", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Enter All Norms Reading for Analysis Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgAnalysisTest.Focus();
                        return false;
                    }
                    
                    if (dgAnalysisTest["ValFDATransactionAnalysisReading", i].Value == null || dgAnalysisTest["ValFDATransactionAnalysisReading", i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Enter All Norms Reading for Analysis Tests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgAnalysisTest.Focus();
                        return false;
                    }
                }
                #endregion
            }

            if (rdoAccepted.Checked == false && rdoRejected.Checked == false && rdoHold.Checked == false)
            {
                MessageBox.Show("Please Select Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
            {
                MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbInspectedBy.Focus();
                return false;
            }
            if (RdoFDABPC.Checked == false && RdoFDANonBPC.Checked == false)
            {
                MessageBox.Show("Please Select Decision", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            #endregion

            return true;
        }

        private void BtnFDATransactionSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidData())
                {

                    #region Confirmation Of Selection
                    if (rdoAccepted.Checked == true)
                    {
                        if (MessageBox.Show("ACCEPT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                            return;
                        else
                            FDATransaction_Class_obj.status = Convert.ToChar("A");
                    }
                    else if (rdoRejected.Checked == true)
                    {
                        if (MessageBox.Show("REJECT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                            return;
                        else
                            FDATransaction_Class_obj.status = Convert.ToChar("R");
                    }
                    else if (rdoHold.Checked == true)
                    {
                        if (MessageBox.Show("HOLD?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                            return;
                        else
                            FDATransaction_Class_obj.status = Convert.ToChar("H");
                    }



                    if (RdoFDABPC.Checked == true)
                    {
                        if (MessageBox.Show("BPC ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                            return;
                        else
                            FDATransaction_Class_obj.decision = Convert.ToChar("B");
                    }

                    if (RdoFDANonBPC.Checked == true)
                    {
                        if (MessageBox.Show("NON BPC ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                            return;
                        else
                            FDATransaction_Class_obj.decision = Convert.ToChar("N");
                    }
                    #endregion

                    FDATransaction_Class_obj.fmid = Convert.ToInt64(cmbFDADetails.SelectedValue.ToString());
                    FDATransaction_Class_obj.loginid = FrmMain.LoginID;
                    FDATransaction_Class_obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);                   

                    DataTable DsFDATransId =FDATransaction_Class_obj.Select_FDATransaction_FMID().Tables[0];                   
                    if (DsFDATransId.Rows.Count > 0)
                    {
                        //Record Already present update the existing record
                        FDATransaction_Class_obj.fdatransid =Convert.ToInt64(DsFDATransId.Rows[0]["FDATransID"]);
                        FDATransaction_Class_obj.Update_tblFDATransaction();
                    }
                    else //No Record Present for same FMID
                        FDATransaction_Class_obj.fdatransid = FDATransaction_Class_obj.Insert_tblFDATransaction();

                    //Delete previous readings
                    FDATransaction_Class_obj.Delete_tblFDAPhysicoChemicalTestMethodDetails();

                    #region Identification Test
                    for (int i = 0; i < dgIdTest.Rows.Count; i++)
                    {
                        //FDATransaction_Class_obj.fdatransid = Convert.ToInt64(ds.Tables[0].Rows[0]["FDATransID"].ToString());
                        FDATransaction_Class_obj.fdaphymethodno = Convert.ToInt64(dgIdTest["ValFDATransactionIdMethodNo", i].Value.ToString());
                        if (dgIdTest["ValFDATransactionIdMin", i].Value == null)
                        {
                            FDATransaction_Class_obj.normsmin = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.normsmin = dgIdTest["ValFDATransactionIdMin", i].Value.ToString().Trim();
                        }
                        if (dgIdTest["ValFDATransactionIdMax", i].Value == null)
                        {
                            FDATransaction_Class_obj.normsmax = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.normsmax = dgIdTest["ValFDATransactionIdMax", i].Value.ToString().Trim();
                        }
                        
                        if (dgIdTest["ValFDATransactionIdReading", i].Value == null)
                        {
                            FDATransaction_Class_obj.normsreading = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.normsreading = dgIdTest["ValFDATransactionIdReading", i].Value.ToString().Trim();
                        }
                        
                        FDATransaction_Class_obj.Insert_tblFDAPhysicoChemicalTestMethodDetails();
                    }
                    #endregion

                    #region Control Test
                    for (int i = 0; i < dgControlTest.Rows.Count; i++)
                    {
                        //FDATransaction_Class_obj.fdatransid = Convert.ToInt64(ds.Tables[0].Rows[0]["FDATransID"].ToString());
                        FDATransaction_Class_obj.fdaphymethodno = Convert.ToInt64(dgControlTest["ValFDATransactionControlMethodNo", i].Value.ToString());
                        if (dgControlTest["ValFDATransactionControlMin", i].Value == null)
                        {
                            FDATransaction_Class_obj.normsmin = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.normsmin = dgControlTest["ValFDATransactionControlMin", i].Value.ToString().Trim();
                        }
                        if (dgControlTest["ValFDATransactionControlMax", i].Value == null)
                        {
                            FDATransaction_Class_obj.normsmax = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.normsmax = dgControlTest["ValFDATransactionControlMax", i].Value.ToString().Trim();
                        }

                        if (dgControlTest["ValFDATransactionControlReading", i].Value == null)
                        {
                            FDATransaction_Class_obj.normsreading = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.normsreading = dgControlTest["ValFDATransactionControlReading", i].Value.ToString().Trim();
                        }
                        
                        FDATransaction_Class_obj.Insert_tblFDAPhysicoChemicalTestMethodDetails();
                    }
                    #endregion

                    FDATransaction_Class_obj.Delete_tblFDAPreservativeTestMethodDetails();

                    #region AnalysisTest
                    for (int i = 0; i < dgAnalysisTest.Rows.Count; i++)
                    {
                        //FDATransaction_Class_obj.fdatransid = Convert.ToInt64(ds.Tables[0].Rows[0]["FDATransID"].ToString());
                        FDATransaction_Class_obj.fdapresmethodno = Convert.ToInt64(dgAnalysisTest["ValFDATransactionAnalysisMethodNo", i].Value.ToString());

                        if (dgAnalysisTest["ValFDATransactionAnalysisMin", i].Value == null)
                        {
                            FDATransaction_Class_obj.normsmin = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.normsmin = dgAnalysisTest["ValFDATransactionAnalysisMin", i].Value.ToString().Trim();
                        }
                        if (dgAnalysisTest["ValFDATransactionAnalysisMax", i].Value == null)
                        {
                            FDATransaction_Class_obj.normsmax = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.normsmax = dgAnalysisTest["ValFDATransactionAnalysisMax", i].Value.ToString().Trim();
                        }

                        if (dgAnalysisTest["PresFormula", i].Value == null)
                        {
                            FDATransaction_Class_obj.presformula = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.presformula = dgAnalysisTest["PresFormula", i].Value.ToString().Trim();
                        }  

                        if (dgAnalysisTest["WeightSample", i].Value == null)
                        {
                            FDATransaction_Class_obj.weightsample = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.weightsample = dgAnalysisTest["WeightSample", i].Value.ToString().Trim();
                        }
                        if (dgAnalysisTest["WeightReference", i].Value == null)
                        {
                            FDATransaction_Class_obj.weightreference = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.weightreference = dgAnalysisTest["WeightReference", i].Value.ToString().Trim();
                        }
                        if (dgAnalysisTest["AreaSample", i].Value == null)
                        {
                            FDATransaction_Class_obj.areasample = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.areasample = dgAnalysisTest["AreaSample", i].Value.ToString().Trim();
                        }
                        if (dgAnalysisTest["AreaReference", i].Value == null)
                        {
                            FDATransaction_Class_obj.areareference = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.areareference = dgAnalysisTest["AreaReference", i].Value.ToString().Trim();
                        }
                        if (dgAnalysisTest["VolumeSample", i].Value == null)
                        {
                            FDATransaction_Class_obj.volumesample = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.volumesample = dgAnalysisTest["VolumeSample", i].Value.ToString().Trim();
                        }
                        if (dgAnalysisTest["AssayConc", i].Value == null)
                        {
                            FDATransaction_Class_obj.assayconc = "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.assayconc = dgAnalysisTest["AssayConc", i].Value.ToString().Trim();
                        }

                        if (dgAnalysisTest["ValFDATransactionAnalysisReading", i].Value == null)
                        {
                            FDATransaction_Class_obj.normsreading= "";
                        }
                        else
                        {
                            FDATransaction_Class_obj.normsreading = dgAnalysisTest["ValFDATransactionAnalysisReading", i].Value.ToString().Trim();
                        }                         

                        FDATransaction_Class_obj.Insert_tblFDAPreservativeTestMethodDetails();
                    }
                    #endregion

                    if (rdoHold.Checked != true)
                    {
                        FDATransaction_Class_obj.fdadone = true;
                        bool s = FDATransaction_Class_obj.Update_tblTransFM_FDADone();
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                    BtnFDATRansactionReset_Click(sender, e);
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Method Details for this MfgWo and FormulaNo Already Added", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRMTransactionExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }               
        
        private void dgFDATransactionControl_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgControlTest.CurrentCell.RowIndex < 0
                || (dgControlTest.CurrentCell.ColumnIndex != dgControlTest.Columns["ValFDATransactionControlReading"].Index))
            {
                return;
            }
            else if (dgControlTest.CurrentCell.ColumnIndex == dgControlTest.Columns["ValFDATransactionControlReading"].Index)
            {
                dgControlTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }           
        }

        void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }        
        }

        private void dgFDATransactionId_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (dgIdTest.CurrentCell.RowIndex < 0
                || (dgIdTest.CurrentCell.ColumnIndex != dgIdTest.Columns["ValFDATransactionIdReading"].Index))
            {
                return;
            }
            else if (dgIdTest.CurrentCell.ColumnIndex == dgIdTest.Columns["ValFDATransactionIdReading"].Index)
            {
                dgIdTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }    
        }

        private void dgFDATransactionAnalysis_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgAnalysisTest.CurrentCell.RowIndex >= 0)
            {
                if (dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["ValFDATransactionAnalysisReading"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["WeightSample"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["WeightReference"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["AreaSample"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["AreaReference"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["VolumeSample"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["AssayConc"].Index)
                {
                    dgAnalysisTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
                }
            }

            #region OldCode
            //if (dgFDATransactionAnalysis.CurrentCell.RowIndex < 0
            //   || (dgFDATransactionAnalysis.CurrentCell.ColumnIndex != dgFDATransactionAnalysis.Columns["ValFDATransactionAnalysisReading"].Index))
            //{
            //    return;
            //}
            //else if (dgFDATransactionAnalysis.CurrentCell.ColumnIndex == dgFDATransactionAnalysis.Columns["ValFDATransactionAnalysisReading"].Index)
            //{
            //    dgFDATransactionAnalysis.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            //}    
            #endregion
        }

        private void dgFDATransactionControl_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgControlTest.Columns["ValFDATransactionControlReading"].Index)
            {
                return;
            }
            else
            {
                if (dgControlTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgControlTest["ValFDATransactionControlMax", dgControlTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgControlTest["ValFDATransactionControlMin", dgControlTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgControlTest.CurrentCell.Style.BackColor = Color.Red;
                        return;
                    }

                    if (dgControlTest["ValFDATransactionControlMax", dgControlTest.CurrentCell.RowIndex].Value != null && dgControlTest["ValFDATransactionControlMax", dgControlTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgControlTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgControlTest["ValFDATransactionControlMax", dgControlTest.CurrentCell.RowIndex].Value))
                        {
                            dgControlTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgControlTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgControlTest["ValFDATransactionControlMin", dgControlTest.CurrentCell.RowIndex].Value != null && dgControlTest["ValFDATransactionControlMin", dgControlTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgControlTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgControlTest["ValFDATransactionControlMin", dgControlTest.CurrentCell.RowIndex].Value))
                        {
                            dgControlTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgControlTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dgControlTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        private void dgFDATransactionId_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgIdTest.Columns["ValFDATransactionIdReading"].Index)
            {
                return;
            }
            else
            {
                if (dgIdTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgIdTest["ValFDATransactionIdMax", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgIdTest["ValFDATransactionIdMin", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgIdTest.CurrentCell.Style.BackColor = Color.Red;
                        return;
                    }

                    if (dgIdTest["ValFDATransactionIdMax", dgIdTest.CurrentCell.RowIndex].Value != null && dgIdTest["ValFDATransactionIdMax", dgIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgIdTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgIdTest["ValFDATransactionIdMax", dgIdTest.CurrentCell.RowIndex].Value))
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgIdTest["ValFDATransactionIdMin", dgIdTest.CurrentCell.RowIndex].Value != null && dgIdTest["ValFDATransactionIdMin", dgIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgIdTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgIdTest["ValFDATransactionIdMin", dgIdTest.CurrentCell.RowIndex].Value))
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dgIdTest.CurrentCell.Style.BackColor = Color.White;
                }

            }

        }

        private void dgFDATransactionAnalysis_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgAnalysisTest.Columns["ValFDATransactionAnalysisReading"].Index)
            {
                return;
            }
            else
            {
                if (dgAnalysisTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgAnalysisTest["ValFDATransactionAnalysisMax", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgAnalysisTest["ValFDATransactionAnalysisMin", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgAnalysisTest.CurrentCell.Style.BackColor = Color.Red;
                        return;
                    }

                    if (dgAnalysisTest["ValFDATransactionAnalysisMax", dgAnalysisTest.CurrentCell.RowIndex].Value != null && dgAnalysisTest["ValFDATransactionAnalysisMax", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgAnalysisTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgAnalysisTest["ValFDATransactionAnalysisMax", dgAnalysisTest.CurrentCell.RowIndex].Value))
                        {
                            dgAnalysisTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgAnalysisTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgAnalysisTest["ValFDATransactionAnalysisMin", dgAnalysisTest.CurrentCell.RowIndex].Value != null && dgAnalysisTest["ValFDATransactionAnalysisMin", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgAnalysisTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgAnalysisTest["ValFDATransactionAnalysisMin", dgAnalysisTest.CurrentCell.RowIndex].Value))
                        {
                            dgAnalysisTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgAnalysisTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dgAnalysisTest.CurrentCell.Style.BackColor = Color.White;
                }
            }

            #region Old Code
            //if (e.RowIndex < 0 || e.ColumnIndex != dgFDATransactionAnalysis.Columns["ValFDATransactionAnalysisReading"].Index)
            //{
            //    return;
            //}
            //else
            //{
            //    if (dgFDATransactionAnalysis.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
            //    {
            //        if (dgFDATransactionAnalysis["ValFDATransactionAnalysisMax", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgFDATransactionAnalysis["ValFDATransactionAnalysisMin", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value.ToString().Trim() == "")
            //        {
            //            dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.Red;
            //            return;
            //        }

            //        if (dgFDATransactionAnalysis["ValFDATransactionAnalysisMax", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value != null && dgFDATransactionAnalysis["ValFDATransactionAnalysisMax", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value.ToString() != "")
            //        {
            //            if (Convert.ToDouble(dgFDATransactionAnalysis.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgFDATransactionAnalysis["ValFDATransactionAnalysisMax", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value))
            //            {
            //                dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.Red;
            //                return;
            //            }
            //            else
            //            {
            //                dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.White;
            //            }
            //        }

            //        if (dgFDATransactionAnalysis["ValFDATransactionAnalysisMin", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value != null && dgFDATransactionAnalysis["ValFDATransactionAnalysisMin", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value.ToString() != "")
            //        {
            //            if (Convert.ToDouble(dgFDATransactionAnalysis.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgFDATransactionAnalysis["ValFDATransactionAnalysisMin", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value))
            //            {
            //                dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.Red;
            //                return;
            //            }
            //            else
            //            {
            //                dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.White;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.White;
            //    }

            //}
            #endregion
        }

        private void dgFDATransactionControl_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgControlTest.Columns["ValFDATransactionControlReading"].Index)
            {
                return;
            }
            else
            {
                for (int i = 0; i < dgControlTest.Rows.Count; i++)
                {
                    if (dgControlTest["ValFDATransactionControlReading", i].Style.BackColor == Color.Red)
                    {
                        rdoRejected.Checked = true;
                        return;
                    }
                    else
                    {
                        rdoAccepted.Checked = true;
                    }
                }

                for (int i = 0; i < dgIdTest.Rows.Count; i++)
                {
                    if (dgIdTest["ValFDATransactionIdReading", i].Style.BackColor == Color.Red)
                    {
                        rdoRejected.Checked = true;
                        return;
                    }
                    else
                    {
                        rdoAccepted.Checked = true;
                    }
                }

                for (int i = 0; i < dgAnalysisTest.Rows.Count; i++)
                {
                    if (dgAnalysisTest["ValFDATransactionAnalysisReading", i].Style.BackColor == Color.Red)
                    {
                        rdoRejected.Checked = true;
                        return;
                    }
                    else
                    {
                        rdoAccepted.Checked = true;
                    }
                }                       
            }
        }

        private void dgFDATransactionId_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgIdTest.Columns["ValFDATransactionIdReading"].Index)
            {
                return;
            }
            else
            {
                for (int i = 0; i < dgControlTest.Rows.Count; i++)
                {
                    if (dgControlTest["ValFDATransactionControlReading", i].Style.BackColor == Color.Red)
                    {
                        rdoRejected.Checked = true;
                        return;
                    }
                    else
                    {
                        rdoAccepted.Checked = true;
                    }
                }

                for (int i = 0; i < dgIdTest.Rows.Count; i++)
                {
                    if (dgIdTest["ValFDATransactionIdReading", i].Style.BackColor == Color.Red)
                    {
                        rdoRejected.Checked = true;
                        return;
                    }
                    else
                    {
                        rdoAccepted.Checked = true;
                    }
                }

                for (int i = 0; i < dgAnalysisTest.Rows.Count; i++)
                {
                    if (dgAnalysisTest["ValFDATransactionAnalysisReading", i].Style.BackColor == Color.Red)
                    {
                        rdoRejected.Checked = true;
                        return;
                    }
                    else
                    {
                        rdoAccepted.Checked = true;
                    }
                }

            }
        }

        private void dgFDATransactionAnalysis_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex != dgAnalysisTest.Columns["ValFDATransactionAnalysisReading"].Index)
            {
                return;
            }
            else
            {
                for (int i = 0; i < dgAnalysisTest.Rows.Count; i++)
                {
                    if (dgAnalysisTest["ValFDATransactionAnalysisReading", i].Style.BackColor == Color.Red)
                    {
                        rdoRejected.Checked = true;
                        return;
                    }
                    else
                    {
                        rdoRejected.Checked = true;
                    }
                }
            }

            #region Old Code
            //if (e.RowIndex < 0 || e.ColumnIndex != dgFDATransactionAnalysis.Columns["ValFDATransactionAnalysisReading"].Index)
            //{
            //    return;
            //}
            //else
            //{
            //    for (int i = 0; i < dgFDATransactionControl.Rows.Count; i++)
            //    {
            //        if (dgFDATransactionControl["ValFDATransactionControlReading", i].Style.BackColor == Color.Red)
            //        {
            //            RdoFDARejected.Checked = true;
            //            return;
            //        }
            //        else
            //        {
            //            RdoFDAAccepted.Checked = true;
            //        }
            //    }

            //    for (int i = 0; i < dgFDATransactionId.Rows.Count; i++)
            //    {
            //        if (dgFDATransactionId["ValFDATransactionIdReading", i].Style.BackColor == Color.Red)
            //        {
            //            RdoFDARejected.Checked = true;
            //            return;
            //        }
            //        else
            //        {
            //            RdoFDAAccepted.Checked = true;
            //        }
            //    }

            //    for (int i = 0; i < dgFDATransactionAnalysis.Rows.Count; i++)
            //    {
            //        if (dgFDATransactionAnalysis["ValFDATransactionAnalysisReading", i].Style.BackColor == Color.Red)
            //        {
            //            RdoFDARejected.Checked = true;
            //            return;
            //        }
            //        else
            //        {
            //            RdoFDAAccepted.Checked = true;
            //        }
            //    }

            //}
            #endregion
        }

        #region Comment
        //private void dgFDATransactionAnalysis_CellValidated_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0 || e.ColumnIndex != dgFDATransactionAnalysis.Columns["Reading"].Index)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < dgFDATransactionAnalysis.Rows.Count; i++)
        //        {
        //            if (dgFDATransactionAnalysis["Reading", i].Style.BackColor == Color.Red)
        //            {
        //                RdoRejected.Checked = true;
        //                return;
        //            }
        //            else
        //            {
        //                RdoAccepted.Checked = true;
        //            }
        //        }
        //    }
        //}

        //private void dgFDATransactionAnalysis_CellValidating_1(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    if (e.RowIndex < 0 || e.ColumnIndex != dgFDATransactionAnalysis.Columns["Reading"].Index)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        if (dgFDATransactionAnalysis.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
        //        {
        //            if (dgFDATransactionAnalysis["Max", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgFDATransactionAnalysis["Min", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value.ToString().Trim() == "")
        //            {
        //                dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.Red;
        //                return;
        //            }

        //            if (dgFDATransactionAnalysis["Max", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value != null && dgFDATransactionAnalysis["Max", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value.ToString() != "")
        //            {
        //                if (Convert.ToDouble(dgFDATransactionAnalysis.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgFDATransactionAnalysis["Max", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value))
        //                {
        //                    dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.Red;
        //                    return;
        //                }
        //                else
        //                {
        //                    dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.White;
        //                }
        //            }

        //            if (dgFDATransactionAnalysis["Min", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value != null && dgFDATransactionAnalysis["Min", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value.ToString() != "")
        //            {
        //                if (Convert.ToDouble(dgFDATransactionAnalysis.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgFDATransactionAnalysis["Min", dgFDATransactionAnalysis.CurrentCell.RowIndex].Value))
        //                {
        //                    dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.Red;
        //                    return;
        //                }
        //                else
        //                {
        //                    dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.White;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            dgFDATransactionAnalysis.CurrentCell.Style.BackColor = Color.White;
        //        }
        //    }
        //}
        #endregion

        private void dgFDATransactionAnalysis_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgAnalysisTest.CurrentCell != null && dgAnalysisTest.CurrentCell.RowIndex >= 0)
            {
                if (dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["ValFDATransactionAnalysisReading"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["WeightSample"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["WeightReference"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["AreaSample"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["AreaReference"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["VolumeSample"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["AssayConc"].Index
                         || dgAnalysisTest.CurrentCell.ColumnIndex == dgAnalysisTest.Columns["PresFormula"].Index)
                {
                    if (dgAnalysisTest["PresFormula", dgAnalysisTest.CurrentCell.RowIndex].Value != null && dgAnalysisTest["PresFormula", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        string PresValue = dgAnalysisTest["PresFormula", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString();

                        if (dgAnalysisTest["WeightSample", dgAnalysisTest.CurrentCell.RowIndex].Value != null && dgAnalysisTest["WeightSample", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString() != "" &&
                            dgAnalysisTest["WeightReference", dgAnalysisTest.CurrentCell.RowIndex].Value != null && dgAnalysisTest["WeightReference", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString() != "" &&
                        dgAnalysisTest["AreaSample", dgAnalysisTest.CurrentCell.RowIndex].Value != null && dgAnalysisTest["AreaSample", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString() != "" &&
                        dgAnalysisTest["AreaReference", dgAnalysisTest.CurrentCell.RowIndex].Value != null && dgAnalysisTest["AreaReference", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString() != "" &&
                        dgAnalysisTest["VolumeSample", dgAnalysisTest.CurrentCell.RowIndex].Value != null && dgAnalysisTest["VolumeSample", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString() != "" &&
                        dgAnalysisTest["AssayConc", dgAnalysisTest.CurrentCell.RowIndex].Value != null && dgAnalysisTest["AssayConc", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString() != "")
                        {

                            PresValue = PresValue.Replace("WS", dgAnalysisTest["WeightSample", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString());
                            PresValue = PresValue.Replace("WR", dgAnalysisTest["WeightReference", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString());
                            PresValue = PresValue.Replace("AS", dgAnalysisTest["AreaSample", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString());
                            PresValue = PresValue.Replace("AR", dgAnalysisTest["AreaReference", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString());
                            PresValue = PresValue.Replace("VS", dgAnalysisTest["VolumeSample", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString());
                            PresValue = PresValue.Replace("AC", dgAnalysisTest["AssayConc", dgAnalysisTest.CurrentCell.RowIndex].Value.ToString());

                            dgAnalysisTest["ValFDATransactionAnalysisReading", dgAnalysisTest.CurrentCell.RowIndex].Value = Evaluate(PresValue);
                        }
                    }
                }
            }
        }

        public static double Evaluate(string expression)
        {
            try
            {
                System.Data.DataTable table = new System.Data.DataTable();
                table.Columns.Add("expression", string.Empty.GetType(), expression);
                System.Data.DataRow row = table.NewRow();
                table.Rows.Add(row);
                return Math.Round(double.Parse((string)row["expression"]), 4);
            }
            catch
            {
                MessageBox.Show("Preservative Formula is not valid..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
  }
        
}
