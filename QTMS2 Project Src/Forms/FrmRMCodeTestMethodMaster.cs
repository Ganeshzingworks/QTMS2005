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
    public partial class FrmRMCodeTestMethodMaster : System.Windows.Forms.Form
    {
        DataSet dsList = new DataSet();
        #region Variables
        RMCodeTestMethodMaster_Class RMCodeTestMethodMaster_Class_obj = new RMCodeTestMethodMaster_Class();
        RMParaMaster_Class RMParaMaster_Class_obj = new RMParaMaster_Class();
        #endregion

        private static FrmRMCodeTestMethodMaster frmRMCodeTestMethodMaster_Obj = null;
        public static FrmRMCodeTestMethodMaster GetInstance()
        {
            if (frmRMCodeTestMethodMaster_Obj == null)
            {
                frmRMCodeTestMethodMaster_Obj = new Forms.FrmRMCodeTestMethodMaster();
            }
            return frmRMCodeTestMethodMaster_Obj;
        }

        public FrmRMCodeTestMethodMaster()
        {
            InitializeComponent();
        }

        private void FrmRMCodeTestMethodMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            Bind_RMCode();
            Bind_List();
            BindPara();
            BtnReset_Click(sender, e);
        }

        public void Bind_RMCode()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = RMCodeTestMethodMaster_Class_obj.Select_RMCodeMaster();
                dr = ds.Tables[0].NewRow();
                dr["RMCode"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CmbRMCode.DataSource = ds.Tables[0];
                    CmbRMCode.DisplayMember = "RMCode";
                    CmbRMCode.ValueMember = "RMCodeID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_List()
        {
            
            dsList = RMCodeTestMethodMaster_Class_obj.Select_tblRMPhysicochemicalTestMethodMaster();
            List.DataSource = dsList.Tables[0];
            List.DisplayMember = "RMCode";
            List.ValueMember = "RMCodeID";            
        }

        public void BindPara()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = RMParaMaster_Class_obj.Select_ParaMaster();
                dr = ds.Tables[0].NewRow();
                dr["ParaName"] = "--Select--";
                dr["ParaNo"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbParaRed.DataSource = ds.Tables[0];
                    cmbParaRed.DisplayMember = "ParaName";
                    cmbParaRed.ValueMember = "ParaNo";

                    cmbParaFull.DataSource = ds.Tables[0];
                    cmbParaFull.DisplayMember = "ParaName";
                    cmbParaFull.ValueMember = "ParaNo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbParaRed_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if ((cmbParaRed.SelectedValue.ToString() != null) && (cmbParaRed.SelectedValue.ToString() != ""))
                {
                    DataSet ds = new DataSet();
                    RMCodeTestMethodMaster_Class_obj.rmparano = Convert.ToInt32(cmbParaRed.SelectedValue.ToString().Trim());
                    ds = RMCodeTestMethodMaster_Class_obj.Select_RMDescMaster_ParaNo();
                    DataRow dr;
                    dr = ds.Tables[0].NewRow();
                    dr["DescName"] = "--Select--";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    if (ds.Tables[0].Rows.Count >= 0)
                    {
                        cmbDescRed.DataSource = ds.Tables[0];
                        cmbDescRed.DisplayMember = "DescName";
                        cmbDescRed.ValueMember = "DescNo";
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbParaFull_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if ((cmbParaFull.SelectedValue.ToString() != null) && (cmbParaFull.SelectedValue.ToString() != ""))
                {
                    DataSet ds = new DataSet();
                    RMCodeTestMethodMaster_Class_obj.rmparano = Convert.ToInt32(cmbParaFull.SelectedValue.ToString().Trim());
                    ds = RMCodeTestMethodMaster_Class_obj.Select_RMDescMaster_ParaNo();
                    DataRow dr;
                    dr = ds.Tables[0].NewRow();
                    dr["DescName"] = "--Select--";
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        cmbDescFull.DataSource = ds.Tables[0];
                        cmbDescFull.DisplayMember = "DescName";
                        cmbDescFull.ValueMember = "DescNo";
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

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtFamilyName.Text = "";
            txtINCIName.Text = "";
            txtRMDescription.Text = "";            

            dgId.Rows.Clear();            
            dgCon.Rows.Clear();

            btnFullReset_Click(sender, e);
            btnRedReset_Click(sender, e);            
        }

        private void btnRedReset_Click(object sender, EventArgs e)
        {
            cmbParaRed.Text = "--Select--";
            if (cmbParaRed.Items.Count != 0)
            {
                cmbParaRed_SelectionChangeCommitted(sender, e);
            }            
            
            txtMinRed.Text = "";
            txtMaxRed.Text = "";
            cmbParaRed.Focus();
        }

        private void btnFullReset_Click(object sender, EventArgs e)
        {
            cmbParaFull.Text = "--Select--";
            if (cmbParaFull.Items.Count != 0)
            {
                cmbParaFull_SelectionChangeCommitted(sender, e);
            }
            
            txtMinFull.Text = "";
            txtMaxFull.Text = "";
            cmbParaFull.Focus();
        }      

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(List.SelectedValue.ToString());
                if (RMCodeTestMethodMaster_Class_obj.rmcodeid == 0)
                {
                    MessageBox.Show("Select Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Delete all the Tests for this RM Code?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RMCodeTestMethodMaster_Class_obj.del = 1;

                    //bool b = RMCodeTestMethodMaster_Class_obj.Delete_tblRMPhysicochemicalTestMethodMaster_RMCodeID();
                    bool b = RMCodeTestMethodMaster_Class_obj.Update_tblRMPhysicochemicalTestMethodMaster_RMCodeID_Del();
                    if (b == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);                        
                        Bind_List();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Cant Delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CmbRMCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {                
                BtnReset_Click(sender, e);

                if ((CmbRMCode.SelectedValue.ToString() != null) && (CmbRMCode.SelectedValue.ToString() != ""))
                {
                    List.SelectedValue = CmbRMCode.SelectedValue;

                    RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue.ToString());

                    DataSet ds = new DataSet();                                        
                    ds = RMCodeTestMethodMaster_Class_obj.Select_RMCodeMaster_RMCodeID_All();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtRMDescription.Text = ds.Tables[0].Rows[0]["RMDescription"].ToString();
                        txtINCIName.Text = ds.Tables[0].Rows[0]["RMINCIName"].ToString();
                        txtFamilyName.Text = ds.Tables[0].Rows[0]["RMFamilyName"].ToString();
                    }
                    else
                    {
                        txtRMDescription.Text = "";
                        txtINCIName.Text = "";
                        txtFamilyName.Text = "";
                    }

                    DataSet dsTest = new DataSet();
                    dsTest = RMCodeTestMethodMaster_Class_obj.Select_RMPhysicochemicalTestMethodMaster_RMCodeID();
                    if (dsTest.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsTest.Tables[0].Rows.Count; i++)
                        {
                            if (dsTest.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                            {
                                dgId.Rows.Add();
                                dgId["DescNoRed", dgId.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["DescNo"].ToString();
                                dgId["ParaRed", dgId.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["ParaName"].ToString();
                                dgId["DescRed", dgId.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["DescName"].ToString();
                                dgId["MinRed", dgId.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgId["MaxRed", dgId.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMax"].ToString();
                                dgId.ClearSelection();
                            }
                            else if (dsTest.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                            {
                                dgCon.Rows.Add();
                                dgCon["DescNoFullCon", dgCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["DescNo"].ToString();
                                dgCon["ParaFullCon", dgCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["ParaName"].ToString();
                                dgCon["DescFullCon", dgCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["DescName"].ToString();
                                dgCon["MinFullCon", dgCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgCon["MaxFullCon", dgCon.Rows.Count - 1].Value = dsTest.Tables[0].Rows[i]["NormsMax"].ToString();
                                dgCon.ClearSelection();
                            }
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
              
                CmbRMCode.SelectedValue = List.SelectedValue;
                CmbRMCode_SelectionChangeCommitted(sender, e);
               // txtSearch.Text = Convert.ToString(List.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       

        private void btnRedAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (RMCodeTestMethodMaster_Class_obj.rmcodeid == 0 || CmbRMCode.Text == "--Select--")
                {
                    MessageBox.Show("Please Select RM Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    List.Focus();
                    return;
                }
                if (cmbParaRed.Text == "--Select--" || cmbParaRed.SelectedValue==null)
                {
                    MessageBox.Show("Select Parameter", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbParaRed.Focus();
                    return;
                }
                if (cmbDescRed.Text.Trim() == "" || cmbDescRed.Text.Trim() == "--Select--" || cmbDescRed.SelectedValue==null)
                {
                    MessageBox.Show("Select Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDescRed.Focus();
                    return;
                }
                RMCodeTestMethodMaster_Class_obj.createdby = FrmMain.LoginID;
                RMCodeTestMethodMaster_Class_obj.modifiedby = FrmMain.LoginID;
                for (int i = 0; i < dgId.Rows.Count; i++)
                {
                    if (dgId["DescNoRed", i].Value.ToString().Trim() == cmbDescRed.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("This Description already Exists For the Parameter..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue.ToString());
                            RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(dgId["DescNoRed", i].Value.ToString());                        
                            RMCodeTestMethodMaster_Class_obj.normsmin = Convert.ToString(txtMinRed.Text);
                            RMCodeTestMethodMaster_Class_obj.normsmax = Convert.ToString(txtMaxRed.Text);
                            RMCodeTestMethodMaster_Class_obj.testtype = "Identification";
                            RMCodeTestMethodMaster_Class_obj.rowindex = i + 1;
                            RMCodeTestMethodMaster_Class_obj.del = 0;

                            RMCodeTestMethodMaster_Class_obj.Update_RMPhysicochemicalTestMethodMaster();

                            
                            dgId["MinRed", i].Value = txtMinRed.Text;
                            dgId["MaxRed", i].Value = txtMaxRed.Text;
                        }
                        Bind_List();
                        btnRedReset_Click(sender, e);                                               

                        return;
                    }
                }
                
                dgId.Rows.Add();                
                dgId["DescNoRed", dgId.Rows.Count - 1].Value = cmbDescRed.SelectedValue.ToString();
                dgId["ParaRed", dgId.Rows.Count - 1].Value = cmbParaRed.Text.Trim();
                dgId["DescRed", dgId.Rows.Count - 1].Value = cmbDescRed.Text.ToString().Trim();
                dgId["MinRed", dgId.Rows.Count - 1].Value = txtMinRed.Text.Trim();
                dgId["MaxRed", dgId.Rows.Count - 1].Value = txtMaxRed.Text.Trim();
                dgId.ClearSelection();

                RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue.ToString());
                RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(cmbDescRed.SelectedValue.ToString());
                RMCodeTestMethodMaster_Class_obj.testtype = "Identification";
                RMCodeTestMethodMaster_Class_obj.normsmin = Convert.ToString(txtMinRed.Text);
                RMCodeTestMethodMaster_Class_obj.normsmax = Convert.ToString(txtMaxRed.Text);
                RMCodeTestMethodMaster_Class_obj.rowindex = dgId.Rows.Count;
                RMCodeTestMethodMaster_Class_obj.del = 0;

                RMCodeTestMethodMaster_Class_obj.Insert_RMPhysicochemicalTestMethodMaster();

                Bind_List();
                btnRedReset_Click(sender, e);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRedDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgId.SelectedRows != null && dgId.SelectedRows.Count != 0)
                {
                    for (int row = 0; row < dgId.SelectedRows.Count; row++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(dgId["DescNoRed", dgId.SelectedRows[row].Index].Value);
                            RMCodeTestMethodMaster_Class_obj.testtype = "Identification";
                            RMCodeTestMethodMaster_Class_obj.del = 1;

                            //RMCodeTestMethodMaster_Class_obj.Delete_RMPhysicochemicalTestMethodMaster();
                            RMCodeTestMethodMaster_Class_obj.Update_tblRMPhysicochemicalTestMethodMaster_Del();
                            dgId.Rows.Remove(dgId.SelectedRows[row]);

                            //Reset RowIndex
                            for (int i = 0; i < dgId.Rows.Count; i++)
                            {
                                RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue.ToString());
                                RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(dgId["DescNoRed", i].Value.ToString());
                                RMCodeTestMethodMaster_Class_obj.testtype = "Identification";
                                RMCodeTestMethodMaster_Class_obj.rowindex = i + 1;

                                RMCodeTestMethodMaster_Class_obj.Update_tblRMPhysicochemicalTestMethodMaster_RowIndex();
                            }
                        }
                    }

                    btnRedReset_Click(sender, e);
                    Bind_List();                    
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgId.Focus();
                    return;
                }
            }
            catch 
            {
                MessageBox.Show("Cannot Delete this record","Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnFullAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (RMCodeTestMethodMaster_Class_obj.rmcodeid == 0 || CmbRMCode.Text == "--Select--")
                {
                    MessageBox.Show("Please Select RM Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    List.Focus();
                    return;
                }
                if (cmbParaFull.Text == "--Select--" || cmbParaFull.SelectedValue == null)
                {
                    MessageBox.Show("Select Parameter", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbParaFull.Focus();
                    return;
                }
                if (cmbDescFull.Text.Trim() == "" || (cmbDescFull.Text.Trim() == "--Select--") || cmbDescFull.SelectedValue == null)
                {
                    MessageBox.Show("Select Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDescFull.Focus();
                    return;
                }
                              
                 for (int i = 0; i < dgCon.Rows.Count; i++)
                {
                    if ((dgCon["DescNoFullCon", i].Value.ToString() == cmbDescFull.SelectedValue.ToString()))
                    {
                        if (MessageBox.Show("This Description Already Exists For Parameter already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue.ToString());
                            RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(dgCon["DescNoFullCon", i].Value.ToString());
                            RMCodeTestMethodMaster_Class_obj.normsmin = Convert.ToString(txtMinFull.Text);
                            RMCodeTestMethodMaster_Class_obj.normsmax = Convert.ToString(txtMaxFull.Text);
                            RMCodeTestMethodMaster_Class_obj.testtype = "Control";
                            RMCodeTestMethodMaster_Class_obj.rowindex = i+1;
                            RMCodeTestMethodMaster_Class_obj.del = 0;

                            RMCodeTestMethodMaster_Class_obj.Update_RMPhysicochemicalTestMethodMaster();

                            dgCon["MinFullCon", i].Value = txtMinFull.Text;
                            dgCon["MaxFullCon", i].Value = txtMaxFull.Text;
                        }

                        btnFullReset_Click(sender, e);
                        Bind_List();

                        return;
                    }
                }

                dgCon.Rows.Add();
                dgCon["DescNoFullCon", dgCon.Rows.Count - 1].Value = cmbDescFull.SelectedValue.ToString();
                dgCon["ParaFullCon", dgCon.Rows.Count - 1].Value = cmbParaFull.Text;
                dgCon["DescFullCon", dgCon.Rows.Count - 1].Value = cmbDescFull.Text;
                dgCon["MinFullCon", dgCon.Rows.Count - 1].Value = txtMinFull.Text;
                dgCon["MaxFullCon", dgCon.Rows.Count - 1].Value = txtMaxFull.Text;
                dgCon.ClearSelection();


                RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue.ToString());
                RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(cmbDescFull.SelectedValue.ToString());
                RMCodeTestMethodMaster_Class_obj.testtype = "Control";
                RMCodeTestMethodMaster_Class_obj.normsmin = Convert.ToString(txtMinFull.Text);
                RMCodeTestMethodMaster_Class_obj.normsmax = Convert.ToString(txtMaxFull.Text);
                RMCodeTestMethodMaster_Class_obj.rowindex = dgCon.Rows.Count;
                RMCodeTestMethodMaster_Class_obj.del = 0;
               
                RMCodeTestMethodMaster_Class_obj.Insert_RMPhysicochemicalTestMethodMaster();
                btnFullReset_Click(sender, e);
                Bind_List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void btnFullDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgCon.SelectedRows != null && dgCon.SelectedRows.Count != 0)
                {
                    for (int row = 0; row < dgCon.SelectedRows.Count; row++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(dgCon["DescNoFullCon", dgCon.SelectedRows[row].Index].Value);
                            RMCodeTestMethodMaster_Class_obj.testtype = "Control";
                            RMCodeTestMethodMaster_Class_obj.del = 1;

                            //RMCodeTestMethodMaster_Class_obj.Delete_RMPhysicochemicalTestMethodMaster();
                            RMCodeTestMethodMaster_Class_obj.Update_tblRMPhysicochemicalTestMethodMaster_Del();
                            dgCon.Rows.Remove(dgCon.SelectedRows[row]);

                            //Reset RowIndex
                            for (int i = 0; i < dgCon.Rows.Count; i++)
                            {
                                RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue.ToString());
                                RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(dgCon["DescNoFullCon", i].Value.ToString());
                                RMCodeTestMethodMaster_Class_obj.normsmin = dgCon["MinFullCon", i].Value.ToString();
                                RMCodeTestMethodMaster_Class_obj.normsmax = dgCon["MaxFullCon", i].Value.ToString();
                                RMCodeTestMethodMaster_Class_obj.testtype = "Control";
                                RMCodeTestMethodMaster_Class_obj.rowindex = i + 1;

                                RMCodeTestMethodMaster_Class_obj.Update_tblRMPhysicochemicalTestMethodMaster_RowIndex();
                            }
                        }
                    }

                    btnFullReset_Click(sender, e);
                    Bind_List();
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                    return;
                }
            }
            catch 
            {
                MessageBox.Show("Cannot Delete this record","Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
                
        private void txtRedMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9 && e.KeyChar != 45 && e.KeyChar != 43)
            {
                e.Handled = true;
            }
        }

        private void txtRedMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9 && e.KeyChar != 45 && e.KeyChar != 43)
            {
                e.Handled = true;
            }
        }

        private void txtFullMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9 && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void txtFullMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                e.KeyChar != 9 && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }
                     
       
        private void dgRedId_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgId.Rows.Count > 0)
            {                
                if (dgId.Rows[e.RowIndex].Cells["ParaRed"].Value != null)
                {
                    cmbParaRed.Text = dgId["ParaRed", e.RowIndex].Value.ToString();

                    if ((cmbParaRed.SelectedValue.ToString() != null) && (cmbParaRed.SelectedValue.ToString() != ""))
                    {
                        DataSet ds = new DataSet();
                        RMCodeTestMethodMaster_Class_obj.rmparano = Convert.ToInt32(cmbParaRed.SelectedValue.ToString().Trim());
                        ds = RMCodeTestMethodMaster_Class_obj.Select_RMDescMaster_ParaNo();
                        DataRow dr;
                        dr = ds.Tables[0].NewRow();
                        dr["DescName"] = "--Select--";
                        ds.Tables[0].Rows.InsertAt(dr, 0);
                        if (ds.Tables[0].Rows.Count >= 0)
                        {
                            cmbDescRed.DataSource = ds.Tables[0];
                            cmbDescRed.DisplayMember = "DescName";
                            cmbDescRed.ValueMember = "DescNo";
                        }
                    }
                }
                if (dgId.Rows[e.RowIndex].Cells["DescRed"].Value != null)
                {
                    cmbDescRed.Text = dgId["DescRed", e.RowIndex].Value.ToString();
                }
                if (dgId.Rows[e.RowIndex].Cells["MinRed"].Value != null)
                {
                    txtMinRed.Text = dgId["MinRed", e.RowIndex].Value.ToString();
                }
                if (dgId.Rows[e.RowIndex].Cells["MaxRed"].Value != null)
                {
                    txtMaxRed.Text = dgId["MaxRed", e.RowIndex].Value.ToString();
                }                
            }
        }
               

        private void dgFullCon_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgCon.Rows.Count > 0)
            {
                if (dgCon.Rows[e.RowIndex].Cells["ParaFullCon"].Value != null)
                {
                    cmbParaFull.Text = dgCon["ParaFullCon", e.RowIndex].Value.ToString();

                    if ((cmbParaFull.SelectedValue.ToString() != null) && (cmbParaFull.SelectedValue.ToString() != ""))
                    {
                        DataSet ds = new DataSet();
                        RMCodeTestMethodMaster_Class_obj.rmparano = Convert.ToInt32(cmbParaFull.SelectedValue.ToString().Trim());
                        ds = RMCodeTestMethodMaster_Class_obj.Select_RMDescMaster_ParaNo();
                        DataRow dr;
                        dr = ds.Tables[0].NewRow();
                        dr["DescName"] = "--Select--";
                        ds.Tables[0].Rows.InsertAt(dr, 0);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            cmbDescFull.DataSource = ds.Tables[0];
                            cmbDescFull.DisplayMember = "DescName";
                            cmbDescFull.ValueMember = "DescNo";
                        }
                    }
                }
                if (dgCon.Rows[e.RowIndex].Cells["DescFullCon"].Value != null)
                {
                    cmbDescFull.Text = dgCon["DescFullCon", e.RowIndex].Value.ToString();
                }

                if (dgCon.Rows[e.RowIndex].Cells["MinFullCon"].Value != null)
                {
                    txtMinFull.Text = dgCon["MinFullCon", e.RowIndex].Value.ToString();
                }
                if (dgCon.Rows[e.RowIndex].Cells["MaxFullCon"].Value != null)
                {
                    txtMaxFull.Text = dgCon["MaxFullCon", e.RowIndex].Value.ToString();
                }                
            }
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            if (CmbRMCode.Text != "--Select--")
            {
                if (dgId.CurrentCell.RowIndex > 0)
                {
                    DataGridViewRow dr = dgId.CurrentRow;
                    int RowIndex = dr.Index;
                    dgId.Rows.Remove(dr);
                    dgId.Rows.Insert(RowIndex - 1, dr);
                    dgId.CurrentCell = dgId[1, RowIndex - 1];

                    for (int i = 0; i < dgId.Rows.Count; i++)
                    {
                        RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue.ToString());
                        RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(dgId["DescNoRed", i].Value.ToString());
                        RMCodeTestMethodMaster_Class_obj.testtype = "Identification";
                        RMCodeTestMethodMaster_Class_obj.rowindex = i + 1;

                        RMCodeTestMethodMaster_Class_obj.Update_tblRMPhysicochemicalTestMethodMaster_RowIndex();
                    }
                }
            }
        }

        private void btnDOWN_Click(object sender, EventArgs e)
        {
            if (CmbRMCode.Text != "--Select--")
            {
                if (dgId.CurrentCell.RowIndex < dgId.Rows.Count - 1)
                {
                    DataGridViewRow dr = dgId.CurrentRow;
                    int RowIndex = dr.Index;
                    dgId.Rows.Remove(dr);
                    dgId.Rows.Insert(RowIndex + 1, dr);
                    dgId.CurrentCell = dgId[1, RowIndex + 1];

                    for (int i = 0; i < dgId.Rows.Count; i++)
                    {
                        RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue.ToString());
                        RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(dgId["DescNoRed", i].Value.ToString());
                        RMCodeTestMethodMaster_Class_obj.normsmin = dgId["MinRed", i].Value.ToString();
                        RMCodeTestMethodMaster_Class_obj.normsmax = dgId["MaxRed", i].Value.ToString();
                        RMCodeTestMethodMaster_Class_obj.testtype = "Identification";
                        RMCodeTestMethodMaster_Class_obj.rowindex = i + 1;

                        RMCodeTestMethodMaster_Class_obj.Update_tblRMPhysicochemicalTestMethodMaster_RowIndex();
                    }
                }
            }
        }

        private void btnConUP_Click(object sender, EventArgs e)
        {
            if (CmbRMCode.Text != "--Select--")
            {
                if (dgCon.CurrentCell.RowIndex > 0)
                {
                    DataGridViewRow dr = dgCon.CurrentRow;
                    int RowIndex = dr.Index;
                    dgCon.Rows.Remove(dr);
                    dgCon.Rows.Insert(RowIndex - 1, dr);
                    dgCon.CurrentCell = dgCon[1, RowIndex - 1];

                    for (int i = 0; i < dgCon.Rows.Count; i++)
                    {
                        RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue.ToString());
                        RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(dgCon["DescNoFullCon", i].Value.ToString());
                        RMCodeTestMethodMaster_Class_obj.normsmin = dgCon["MinFullCon", i].Value.ToString();
                        RMCodeTestMethodMaster_Class_obj.normsmax = dgCon["MaxFullCon", i].Value.ToString();
                        RMCodeTestMethodMaster_Class_obj.testtype = "Control";
                        RMCodeTestMethodMaster_Class_obj.rowindex = i + 1;

                        RMCodeTestMethodMaster_Class_obj.Update_tblRMPhysicochemicalTestMethodMaster_RowIndex();
                    }
                }
            }
        }

        private void btnConDOWN_Click(object sender, EventArgs e)
        {
            if (CmbRMCode.Text != "--Select--")
            {
                if (dgCon.CurrentCell.RowIndex < dgCon.Rows.Count - 1)
                {
                    DataGridViewRow dr = dgCon.CurrentRow;
                    int RowIndex = dr.Index;
                    dgCon.Rows.Remove(dr);
                    dgCon.Rows.Insert(RowIndex + 1, dr);
                    dgCon.CurrentCell = dgCon[1, RowIndex + 1];

                    for (int i = 0; i < dgCon.Rows.Count; i++)
                    {
                        RMCodeTestMethodMaster_Class_obj.rmcodeid = Convert.ToInt64(CmbRMCode.SelectedValue.ToString());
                        RMCodeTestMethodMaster_Class_obj.descno = Convert.ToInt32(dgCon["DescNoFullCon", i].Value.ToString());
                        RMCodeTestMethodMaster_Class_obj.normsmin = dgCon["MinFullCon", i].Value.ToString();
                        RMCodeTestMethodMaster_Class_obj.normsmax = dgCon["MaxFullCon", i].Value.ToString();
                        RMCodeTestMethodMaster_Class_obj.testtype = "Control";
                        RMCodeTestMethodMaster_Class_obj.rowindex = i + 1;

                        RMCodeTestMethodMaster_Class_obj.Update_tblRMPhysicochemicalTestMethodMaster_RowIndex();
                    }
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
            dsList.Tables[0].DefaultView.RowFilter = "RMCode like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "RMCode";
            List.ValueMember = "RMCodeID";           
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    
                    CmbRMCode.SelectedValue = List.SelectedValue;
                    CmbRMCode_SelectionChangeCommitted(sender, e);
                    txtSearch.Text = Convert.ToString(List.Text);
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
                   
                    CmbRMCode.SelectedValue = List.SelectedValue;
                    CmbRMCode_SelectionChangeCommitted(sender, e);
                    txtSearch.Text = Convert.ToString(List.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}