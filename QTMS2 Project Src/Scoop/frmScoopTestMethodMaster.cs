using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessFacade;
using BusinessFacade.Scoop_Class;
using BusinessFacade.Transactions;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Scoop
{
    public partial class frmScoopTestMethodMaster : Form
    {
        public frmScoopTestMethodMaster()
        {
            InitializeComponent();
        }

        #region Class_variable
        LineMaster_Class obj_LineMaster_Class = new LineMaster_Class();
        LineSamplingPointMaster_Class obj_LineSamplingPointMaster_Class = new LineSamplingPointMaster_Class();
        BusinessFacade.Transactions.Line_SamplePoint obj_Line_SamplePoint = new Line_SamplePoint();
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        FGTestMaster_Class FGTestMaster_Class_Obj = new FGTestMaster_Class();
        SCOOPTestMethodMaster_Class SCOOPTestMethodMaster_Class_Obj = new SCOOPTestMethodMaster_Class();
        #endregion

        DataSet DslineNo; DataSet DsSapmlingPnt, dsFGList, DsFgTestList, DsTest, DsData;
        string SamplinExistName; int SamplingPointFrequency, SamplingPointSize;
        int existingRecordsCount;
        private static frmScoopTestMethodMaster frmScoopTestMethodMaster_Obj = null;

        public static frmScoopTestMethodMaster GetInstance()
        {
            if (frmScoopTestMethodMaster_Obj == null)
            {
                frmScoopTestMethodMaster_Obj = new frmScoopTestMethodMaster();
            }
            return frmScoopTestMethodMaster_Obj;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScoopTestMethodMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            Bind_LiineList();
            Bind_FGList();
            foreach (DataGridViewColumn clm in dgvScoopTestMethodMaster.Columns)
            {
                clm.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bind_LiineList()
        {
            try
            {
                DslineNo = obj_LineMaster_Class.Select_ScoopApplLineMaster();
                DataRow dr = DslineNo.Tables[0].NewRow();
                dr["LineDesc"] = "-select-";
                DslineNo.Tables[0].Rows.InsertAt(dr, 0);
                cmbLine.DisplayMember = "LineDesc";
                cmbLine.ValueMember = "LNo";
                cmbLine.DataSource = DslineNo.Tables[0];
            }
            catch
            {
                throw;
            }
        }

        private void Bind_samplingPoints()
        {
            try
            {
                DsSapmlingPnt = obj_Line_SamplePoint.Select_SamplingPointForLine();
                cmbSamlingPoint.DisplayMember = "SamplingPointName";
                cmbSamlingPoint.ValueMember = "SamplingPointId";
                cmbSamlingPoint.DataSource = DsSapmlingPnt.Tables[0];
            }
            catch
            {
                throw;
            }
        }

        public void Bind_FGList()
        {
            dsFGList = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster();        
            DataRow dr = dsFGList.Tables[0].NewRow();
            dr["FGCode"] = "-select-";
            dsFGList.Tables[0].Rows.InsertAt(dr, 0);
            cmbFGCode.DisplayMember = "FGCode";
            cmbFGCode.ValueMember = "FGNo";
            cmbFGCode.DataSource = dsFGList.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SamplinExistName = "NO"; SamplingPointFrequency = 0; SamplingPointSize = 0;
            if (!ExistAlready_InGRid() && validate() && !Is_Blank())
            {
                CheckAlreadySampling();
                if (SamplingPointFrequency == 0)
                {
                    dgvScoopTestMethodMaster.Rows.Add(cmbSamlingPoint.Text,cmbSamlingPoint.SelectedValue.ToString(), cmbTestMethod.Text,cmbTestMethod.SelectedValue.ToString(), "", "",0, 0, 0, 0, 3);
                }
                else
                {
                    dgvScoopTestMethodMaster.Rows.Add(cmbSamlingPoint.Text,cmbSamlingPoint.SelectedValue.ToString(), cmbTestMethod.Text,cmbTestMethod.SelectedValue.ToString(), SamplingPointFrequency, SamplingPointSize,0, 0, 0, 0, 3);
                }
               
            }
           
        }

        private bool ExistAlready_InGRid()
        {
            foreach (DataGridViewRow dr in dgvScoopTestMethodMaster.Rows)
            {
                if ((dr.Cells["SamplingPoint"].Value.ToString() == cmbSamlingPoint.Text) && (dr.Cells["Test"].Value.ToString() == cmbTestMethod.Text) && dr.Visible == true) 
                {
                    MessageBox.Show("Record exist already", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else if ((dr.Cells["SamplingPoint"].Value.ToString() == cmbSamlingPoint.Text) && (dr.Cells["Test"].Value.ToString() == cmbTestMethod.Text) && dr.Visible == false)
                {
                    dr.Visible = true;
                    return true;
                }
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvScoopTestMethodMaster.SelectedRows.Count == 0 ||dgvScoopTestMethodMaster.CurrentRow==null || dgvScoopTestMethodMaster.CurrentRow.Visible==false)
            {
                MessageBox.Show("Please select the row to be deleted.", "Inforamtion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvScoopTestMethodMaster.Rows.Count>0)
            {
                dgvScoopTestMethodMaster.Rows.RemoveAt(dgvScoopTestMethodMaster.CurrentRow.Index);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (dgvScoopTestMethodMaster.RowCount > 0)
            {
                dgvScoopTestMethodMaster.Rows.Clear();
            }
            cmbLine.SelectedIndex = 0;
            cmbFGCode.SelectedIndex = 0;
            cmbSamlingPoint.DataSource = null;
            cmbTestMethod.DataSource = null;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validate())
                {
                    return;
                
                }
                if (dgvScoopTestMethodMaster.Rows.Count == 0)
                {
                    MessageBox.Show("No record to save..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dgvScoopTestMethodMaster.RowCount > 0 && existingRecordsCount==0)
                {
                    SCOOPTestMethodMaster_Class_Obj.lno = Convert.ToInt32(cmbLine.SelectedValue.ToString());
                    SCOOPTestMethodMaster_Class_Obj.fgNo = Convert.ToInt64(cmbFGCode.SelectedValue.ToString());
                    foreach (DataGridViewRow dr in dgvScoopTestMethodMaster.Rows)
                    {
                        SCOOPTestMethodMaster_Class_Obj.samplingPointId = Convert.ToInt64(dr.Cells["SamplingPointID"].Value.ToString());
                        SCOOPTestMethodMaster_Class_Obj.testNo = Convert.ToInt64(dr.Cells["TestID"].Value.ToString());
                        SCOOPTestMethodMaster_Class_Obj.frequency = Convert.ToInt32(dr.Cells["Frequency"].Value.ToString());
                        SCOOPTestMethodMaster_Class_Obj.sampleSize = Convert.ToInt32(dr.Cells["SampleSize"].Value.ToString());
                        SCOOPTestMethodMaster_Class_Obj.aql = Convert.ToInt32(dr.Cells["AQL"].Value.ToString());
                        SCOOPTestMethodMaster_Class_Obj.aqlz = Convert.ToInt32(dr.Cells["AQLZ"].Value.ToString());
                        SCOOPTestMethodMaster_Class_Obj.aqlc = Convert.ToInt32(dr.Cells["AQLC"].Value.ToString());
                        SCOOPTestMethodMaster_Class_Obj.aqlm = Convert.ToInt32(dr.Cells["AQLM"].Value.ToString());
                        SCOOPTestMethodMaster_Class_Obj.aqlm1 = Convert.ToInt32(dr.Cells["AQLM1"].Value.ToString());
                        SCOOPTestMethodMaster_Class_Obj.del =false;
                        SCOOPTestMethodMaster_Class_Obj.Insert_tblSCOOPtestMethodMaster();
                    }
                    MessageBox.Show("Record saved successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dgvScoopTestMethodMaster.RowCount > 0 && existingRecordsCount > 0)
                {
                    int c=0;
                    for (c = 0; c < existingRecordsCount; c++)
                    {
                        if (dgvScoopTestMethodMaster.Rows[c].Visible == false)
                        {
                            SCOOPTestMethodMaster_Class_Obj.del = true;
                            SCOOPTestMethodMaster_Class_Obj.samplingPointId = Convert.ToInt64(dgvScoopTestMethodMaster.Rows[c].Cells["SamplingPointID"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.testNo = Convert.ToInt64(dgvScoopTestMethodMaster.Rows[c].Cells["TestID"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.Delete_tblSCOOPtestMethodMaster();                    
                        }
                        else
                        {
                            SCOOPTestMethodMaster_Class_Obj.del = false;
                            SCOOPTestMethodMaster_Class_Obj.samplingPointId = Convert.ToInt64(dgvScoopTestMethodMaster.Rows[c].Cells["SamplingPointID"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.testNo = Convert.ToInt64(dgvScoopTestMethodMaster.Rows[c].Cells["TestID"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.frequency = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c].Cells["Frequency"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.sampleSize = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c].Cells["SampleSize"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.aqlz = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c].Cells["AQLZ"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.aqlc = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c].Cells["AQLC"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.aqlm = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c].Cells["AQLM"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.aqlm1 = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c].Cells["AQLM1"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.aql = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c].Cells["AQL"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.Update_tblSCOOPtestMethodMaster();
                        }
                       
                    }
                    for (int c2 = c; c2 < dgvScoopTestMethodMaster.Rows.Count; c2++)
                    {

                        if (dgvScoopTestMethodMaster.Rows[c2].Visible == true)
                        {
                            SCOOPTestMethodMaster_Class_Obj.del = false;
                            SCOOPTestMethodMaster_Class_Obj.samplingPointId = Convert.ToInt64(dgvScoopTestMethodMaster.Rows[c2].Cells["SamplingPointID"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.testNo = Convert.ToInt64(dgvScoopTestMethodMaster.Rows[c2].Cells["TestID"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.frequency = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c2].Cells["Frequency"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.sampleSize = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c2].Cells["SampleSize"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.aqlz = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c2].Cells["AQLZ"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.aqlc = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c2].Cells["AQLC"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.aqlm = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c2].Cells["AQLM"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.aqlm1 = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c2].Cells["AQLM1"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.aql = Convert.ToInt32(dgvScoopTestMethodMaster.Rows[c2].Cells["AQL"].Value.ToString());
                            SCOOPTestMethodMaster_Class_Obj.Insert_tblSCOOPtestMethodMaster();
                        }
                    
                    
                    }
                    MessageBox.Show("Record saved succesfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                btnReset_Click(sender, e);
            }
            catch
            { 
            
            
            }
        }

        bool evencreted = false;

        private void dgvScoopTestMethodMaster_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            e.Handled = false;
            if (dgvScoopTestMethodMaster.CurrentCell.OwningColumn.Name == "Frequency" || dgvScoopTestMethodMaster.CurrentCell.OwningColumn.Name == "SampleSize" || dgvScoopTestMethodMaster.CurrentCell.OwningColumn.Name == "AQLZ" || dgvScoopTestMethodMaster.CurrentCell.OwningColumn.Name == "AQLC" || dgvScoopTestMethodMaster.CurrentCell.OwningColumn.Name == "AQLM" || dgvScoopTestMethodMaster.CurrentCell.OwningColumn.Name == "AQLM1" || dgvScoopTestMethodMaster.CurrentCell.OwningColumn.Name == "AQL")
            { 
              
                if (!char.IsDigit(e.KeyChar) && e.KeyChar!=8)
                {
                                  
                  //  dgvScoopTestMethodMaster.CurrentCell.Value = string.Empty;
                    MessageBox.Show("Please enter digits only.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Handled = true;
                }
                
            }
            
        }

        private void dgvScoopTestMethodMaster_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (evencreted == false)
            {
                e.Control.KeyPress += new KeyPressEventHandler(dgvScoopTestMethodMaster_KeyPress);
                evencreted = true;
            }
        }

        private bool validate()
        {
            foreach (DataGridViewRow dr in dgvScoopTestMethodMaster.Rows)
            {

                if (dr.Visible == true)
                {
                    if (dr.Cells["Frequency"].Value == null || dr.Cells["SampleSize"].Value == null || dr.Cells["Frequency"].Value.ToString() == string.Empty || dr.Cells["SampleSize"].Value.ToString() == string.Empty)
                    {
                        string msg = dr.Cells["Frequency"].Value.ToString() == string.Empty ? " 'Frequency' " : " 'Sample size' ";

                        MessageBox.Show("Please enter the value in " + msg + " of sampling point " + dr.Cells["SamplingPoint"].Value.ToString() + " and test method " + dr.Cells["Test"].Value.ToString() + "", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (Convert.ToInt32(dr.Cells["Frequency"].Value.ToString()) > 60 || Convert.ToInt32(dr.Cells["Frequency"].Value.ToString()) < 10)
                    {

                        MessageBox.Show("Frequency should be between 60 and 10", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;

                    }
                    else if (dr.Cells["AQLZ"].Value == null || dr.Cells["AQLZ"].Value.ToString().Trim()==string.Empty)
                    {

                        MessageBox.Show("Please enter the value in " + "AQLZ" + " of sampling point " + dr.Cells["SamplingPoint"].Value.ToString() + " and test method " + dr.Cells["Test"].Value.ToString() + "", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (dr.Cells["AQLC"].Value == null || dr.Cells["AQLC"].Value.ToString().Trim() == string.Empty)
                    {

                        MessageBox.Show("Please enter the value in " + "AQLC" + " of sampling point " + dr.Cells["SamplingPoint"].Value.ToString() + " and test method " + dr.Cells["Test"].Value.ToString() + "", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (dr.Cells["AQLM"].Value == null || dr.Cells["AQLM"].Value.ToString().Trim() == string.Empty)
                    {

                        MessageBox.Show("Please enter the value in " + "AQLM" + " of sampling point " + dr.Cells["SamplingPoint"].Value.ToString() + " and test method " + dr.Cells["Test"].Value.ToString() + "", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (dr.Cells["AQLM1"].Value == null || dr.Cells["AQLM1"].Value.ToString().Trim() == string.Empty)
                    {

                        MessageBox.Show("Please enter the value in " + "AQLM1" + " of sampling point " + dr.Cells["SamplingPoint"].Value.ToString() + " and test method " + dr.Cells["Test"].Value.ToString() + "", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (dr.Cells["AQL"].Value == null || dr.Cells["AQL"].Value.ToString().Trim() == string.Empty)
                    {

                        MessageBox.Show("Please enter the value in " + "AQL" + " of sampling point " + dr.Cells["SamplingPoint"].Value.ToString() + " and test method " + dr.Cells["Test"].Value.ToString() + "", "message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

            }
            return true;
        
        }

        private void CheckAlreadySampling()
        {
            foreach (DataGridViewRow dr in dgvScoopTestMethodMaster.Rows)
            {
               
                if (dr.Cells["SamplingPoint"].Value.ToString() == cmbSamlingPoint.Text)
                {
                    SamplinExistName = cmbSamlingPoint.Text;
                    SamplingPointFrequency = dr.Cells["Frequency"].Value.ToString() == string.Empty ? 0 : Convert.ToInt32(dr.Cells["Frequency"].Value.ToString());
                    SamplingPointSize = dr.Cells["SampleSize"].Value.ToString() == string.Empty ? 0 : Convert.ToInt32(dr.Cells["SampleSize"].Value.ToString());
                    return;
                }

            }
           
        
        }

        private void BindCmbTest()
        {
            if (DsTest != null)
            {
                DsTest.Clear();
            }
            else
            {
                DsTest = new DataSet();
            }

         //   DsTest = SCOOPTestMethodMaster_Class_Obj.Select_ScoopTestForFGNo();
            DsTest = SCOOPTestMethodMaster_Class_Obj.Select_ScoopTestMethodForFGNo();
            if (DsTest.Tables[0].Rows.Count > 0)
            {
                cmbTestMethod.DisplayMember = "TestName";
                cmbTestMethod.ValueMember = "TestNo";
                cmbTestMethod.DataSource = DsTest.Tables[0];
            }
       
        }

        private void cmbFGCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Reset_grid();
                if (cmbFGCode.SelectedValue.ToString() != "" && cmbLine.SelectedValue.ToString() != "")
                {
                    SCOOPTestMethodMaster_Class_Obj.fgNo = Convert.ToInt64(cmbFGCode.SelectedValue.ToString());
                    BindCmbTest();
                    existingRecordsCount = 0;
                    Getdata();
                }
            }
            catch
            { 
            
            }
        }

        private void Getdata()
        {
            existingRecordsCount = 0;
            if (DsData == null)
            {
                DsData = new DataSet();
            }
            else
            {
                DsData.Clear();
            }
            SCOOPTestMethodMaster_Class_Obj.fgNo = Convert.ToInt64(cmbFGCode.SelectedValue.ToString());
            SCOOPTestMethodMaster_Class_Obj.lno = Convert.ToInt32(cmbLine.SelectedValue.ToString());
            DsData = SCOOPTestMethodMaster_Class_Obj.select_tblSCOOPtestMethodMaster_LineFG();
            existingRecordsCount = DsData.Tables[0].Rows.Count;
            if (existingRecordsCount > 0)
            {
                foreach (DataRow dr in DsData.Tables[0].Rows)
                {
                    dgvScoopTestMethodMaster.Rows.Add(dr["SamplingPointName"].ToString(), dr["SamplingPointId"].ToString(), dr["TestName"], dr["TestNo"].ToString(), dr["Frequency"].ToString(), dr["SampleSize"].ToString(), dr["AQL"].ToString(),dr["AQLZ"].ToString(), dr["AQLC"].ToString(), dr["AQLM"].ToString(), dr["AQLM1"].ToString());              
                }

                for (int i = 0; i < dgvScoopTestMethodMaster.Rows.Count; i++)
                {
                    if (dgvScoopTestMethodMaster.Rows[i].Cells["AQL"].Value.ToString() != "0")
                    {
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLZ"].ReadOnly = true;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLC"].ReadOnly = true;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLM"].ReadOnly = true;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLM1"].ReadOnly = true;

                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLZ"].Style.BackColor = System.Drawing.Color.Gray;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLC"].Style.BackColor = System.Drawing.Color.Gray;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLM"].Style.BackColor = System.Drawing.Color.Gray;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLM1"].Style.BackColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLZ"].ReadOnly = false;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLC"].ReadOnly = false;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLM"].ReadOnly = false;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLM1"].ReadOnly = false;

                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLZ"].Style.BackColor = System.Drawing.Color.White;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLC"].Style.BackColor = System.Drawing.Color.White;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLM"].Style.BackColor = System.Drawing.Color.White;
                        dgvScoopTestMethodMaster.Rows[i].Cells["AQLM1"].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }

        private bool Is_Blank()
        {

            try
            {
                if (cmbSamlingPoint.Text.Trim() == string.Empty || cmbTestMethod.Text.Trim() == string.Empty)
                {
                    string msg = cmbTestMethod.Text.Trim() == string.Empty ? "Ther is no TestMethod for the FGCode " : "Thers no sampling point for the line ";
                    MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void Reset_grid()
        {
            if (dgvScoopTestMethodMaster.RowCount > 0)
            {
                dgvScoopTestMethodMaster.Rows.Clear();
            }
        }

        private void cmbLine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbFGCode.SelectedIndex = 0;

            if (DsSapmlingPnt != null)
            {
                DsSapmlingPnt.Clear();
            }
            if (dgvScoopTestMethodMaster.RowCount > 0)
            {
                dgvScoopTestMethodMaster.Rows.Clear();
            }
            Reset_grid();
            if (cmbLine.SelectedValue.ToString() != "")
            {
                obj_Line_SamplePoint.lno = Convert.ToInt32(cmbLine.SelectedValue.ToString());
                Bind_samplingPoints();
            }
            if (cmbLine.SelectedValue.ToString() != "" && cmbFGCode.SelectedValue.ToString() != "")
            {
                SCOOPTestMethodMaster_Class_Obj.fgNo = Convert.ToInt64(cmbFGCode.SelectedValue.ToString());
                existingRecordsCount = 0;
                Getdata();
            }
        }

        private bool EdittedFrequencyChange_Remain()
        {

            try
            {
                if (existingRecordsCount > 0)
                {
                   
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

        string ChngedFrequencyTest, ChngedFrequencySamplingPnt;

        private void dgvScoopTestMethodMaster_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvScoopTestMethodMaster.CurrentCell.RowIndex < 0)
                {
                    return;
                }

                if (dgvScoopTestMethodMaster.Rows.Count > 0)
                {
                    ChngedFrequencyTest = dgvScoopTestMethodMaster.CurrentRow.Cells["Test"].Value.ToString();
                    ChngedFrequencySamplingPnt = dgvScoopTestMethodMaster.CurrentRow.Cells["SamplingPoint"].Value.ToString();

                    if (dgvScoopTestMethodMaster.CurrentCell.OwningColumn.Name == "Frequency")
                    {
                        string valu = dgvScoopTestMethodMaster.CurrentCell.Value.ToString();
                        foreach (DataGridViewRow dr in dgvScoopTestMethodMaster.Rows)
                        {
                            if (dr.Cells["SamplingPoint"].Value.ToString() == ChngedFrequencySamplingPnt)
                            {
                                dr.Cells["Frequency"].ValueType = typeof(string);
                                dr.Cells["Frequency"].Value = valu;

                            }

                        }

                    }
                    if (dgvScoopTestMethodMaster.CurrentCell.OwningColumn.Name == "SampleSize")
                    {
                        string valu = dgvScoopTestMethodMaster.CurrentCell.Value.ToString();
                        foreach (DataGridViewRow dr in dgvScoopTestMethodMaster.Rows)
                        {
                            if (dr.Cells["SamplingPoint"].Value.ToString() == ChngedFrequencySamplingPnt)
                            {
                               dr.Cells["SampleSize"].ValueType = typeof(string);
                                dr.Cells["SampleSize"].Value = valu;

                            }

                        }

                    }
                    int index = dgvScoopTestMethodMaster.CurrentRow.Index;
                    if (dgvScoopTestMethodMaster.CurrentCell.OwningColumn.Name == "AQL")
                    {
                        if (dgvScoopTestMethodMaster.CurrentCell.Value.ToString() != "0")
                        {
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLZ"].ReadOnly = true;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLC"].ReadOnly = true;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLM"].ReadOnly = true;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLM1"].ReadOnly = true;

                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLZ"].Style.BackColor = System.Drawing.Color.Gray;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLC"].Style.BackColor = System.Drawing.Color.Gray;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLM"].Style.BackColor = System.Drawing.Color.Gray;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLM1"].Style.BackColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLZ"].ReadOnly = false;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLC"].ReadOnly = false;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLM"].ReadOnly = false;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLM1"].ReadOnly = false;

                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLZ"].Style.BackColor = System.Drawing.Color.White;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLC"].Style.BackColor = System.Drawing.Color.White;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLM"].Style.BackColor = System.Drawing.Color.White;
                            dgvScoopTestMethodMaster.Rows[index].Cells["AQLM1"].Style.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
            }
            catch 
            { 
            
            }
        }

        
    }
}
