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

namespace QTMS.Forms
{
    public partial class FrmPreservativeMethodMaster : Form
    {
        DataSet dsList = new DataSet();
        public FrmPreservativeMethodMaster()
        {
            InitializeComponent();
        }
        # region Varibles
        public bool Modify = false;
        public bool SaveAs = false;
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        PreservetiveMaster_Class PreservetiveMaster_Class_Obj = new PreservetiveMaster_Class();
        PreservativeMethodMaster_Class PreservativeMethodMaster_Class_Obj = new PreservativeMethodMaster_Class();
        # endregion

        private static FrmPreservativeMethodMaster frmPreservativeMethodMaster_Obj = null;
        public static FrmPreservativeMethodMaster GetInstance()
        {
            if (frmPreservativeMethodMaster_Obj == null)
            {
                frmPreservativeMethodMaster_Obj = new FrmPreservativeMethodMaster();
            }
            return frmPreservativeMethodMaster_Obj;
        }

        private void FrmPreservativeMethodMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_FormulaNo();            
            Bind_List();
            Bind_PresTest();

            PreservativeMethodMaster_Class_Obj.fno = 0;
        }
        public void Bind_FormulaNo()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = FormulaNoMaster_Class_Obj.SELECT_FormulaNo_Preservative();
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

                dsList = PreservativeMethodMaster_Class_Obj.SELECT_tblPreservativeMethodMaster_tblBulkMaster();
                List.DataSource = dsList.Tables[0];
                List.DisplayMember = "FormulaNo";
                List.ValueMember = "FNo";
                
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
                ds = PreservetiveMaster_Class_Obj.STP_Select_tblPreservativeMaster();
                dr = ds.Tables[0].NewRow();
                dr["PresType"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                    cmbPresTest.DataSource = ds.Tables[0];
                    cmbPresTest.DisplayMember = "PresType";
                    cmbPresTest.ValueMember = "Prsno";
                //}
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
            CmbFormulaNo.Text = "--Select--";
            dgPres.Rows.Clear();
            btnPresReset_Click(sender, e);
            CmbFormulaNo.Focus();
            Bind_List();
            Bind_FormulaNo();
            Modify = false;
            SaveAs = false;
            BtnDelete.Enabled = false;                       
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            List.Enabled = true;
            Modify = true;
            List_DoubleClick(sender, e);
            
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                BtnDelete.Enabled = true;
                dgPres.Rows.Clear();

                if (List.SelectedValue != null)
                {
                  //  txtSearch.Text = Convert.ToString(List.Text);
                    DataSet ds = new DataSet();
                    PreservativeMethodMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                    CmbFormulaNo.Text = List.Text;
                    ds = PreservativeMethodMaster_Class_Obj.SELECT_tblPreservativeMethodMaster_tblBulkMaster_tblPreservativeMaster();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        CmbFormulaNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FormulaNo"]);
                                                
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dgPres.Rows.Add();
                            dgPres["PresTestNo", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Prsno"].ToString();
                            dgPres["PresTest", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["PresType"].ToString();
                            dgPres["PresMin", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgPres["PresMax", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
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
                if (PreservativeMethodMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula from List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }
                                
                if (MessageBox.Show("Delete All Tests for this Formula ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PreservativeMethodMaster_Class_Obj.del = 1;

                    //PreservativeMethodMaster_Class_Obj.DELETE_tblPreservativeMethodMaster();
                    PreservativeMethodMaster_Class_Obj.Update_tblPreservativeMethodMaster_FNo_Del();
                    
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

        private void btnPresReset_Click(object sender, EventArgs e)
        {
            cmbPresTest.Text = "--Select--";
            txtPresMin.Text = "";
            txtPresMax.Text = "";
            cmbPresTest.Focus();
        }

        private void txtPresMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void txtPresMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab

            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&

                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&

                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
        }

        private void dgPres_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPres.Rows.Count > 0)
            {
                if (dgPres.Rows[e.RowIndex].Cells["PresTest"].Value != null)
                {
                    cmbPresTest.Text = dgPres["PresTest", e.RowIndex].Value.ToString();
                }
                if (dgPres.Rows[e.RowIndex].Cells["PresMin"].Value != null)
                {
                    txtPresMin.Text = dgPres["PresMin", e.RowIndex].Value.ToString();
                }
                if (dgPres.Rows[e.RowIndex].Cells["PresMax"].Value != null)
                {
                    txtPresMax.Text = dgPres["PresMax", e.RowIndex].Value.ToString();
                }
            }
        }

        private void btnPresAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (PreservativeMethodMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula from List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (cmbPresTest.Text == "--Select--" || cmbPresTest.SelectedValue == null || cmbPresTest.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Select Test", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbPresTest.Focus();
                    return;
                }
                //if (txtPresMin.Text == "")
                //{
                //    MessageBox.Show("Select Min", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtPresMin.Focus();
                //    return;
                //}
                //if (txtPresMax.Text == "")
                //{
                //    MessageBox.Show("Select Max", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtPresMax.Focus();
                //    return;
                //}

                for (int i = 0; i < dgPres.Rows.Count; i++)
                {
                    if (dgPres["PresTestNo", i].Value.ToString() == cmbPresTest.SelectedValue.ToString())
                    {
                        if (MessageBox.Show("This Test already Exists..\n\nModify ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            PreservativeMethodMaster_Class_Obj.testno = Convert.ToInt32(cmbPresTest.SelectedValue.ToString());
                            PreservativeMethodMaster_Class_Obj.min = Convert.ToString(txtPresMin.Text);
                            PreservativeMethodMaster_Class_Obj.max = Convert.ToString(txtPresMax.Text);

                            PreservativeMethodMaster_Class_Obj.Update_tblPreservativeMethodMaster();

                            dgPres["PresMin", i].Value = txtPresMin.Text;
                            dgPres["PresMax", i].Value = txtPresMax.Text;
                        }

                        btnPresReset_Click(sender, e);
                        Bind_List();
                        Bind_FormulaNo();
                        return;
                    }
                }

                dgPres.Rows.Add();
                dgPres["PresTestNo", dgPres.Rows.Count - 1].Value = cmbPresTest.SelectedValue.ToString();
                dgPres["PresTest", dgPres.Rows.Count - 1].Value = cmbPresTest.Text;
                dgPres["PresMin", dgPres.Rows.Count - 1].Value = txtPresMin.Text;
                dgPres["PresMax", dgPres.Rows.Count - 1].Value = txtPresMax.Text;

                PreservativeMethodMaster_Class_Obj.testno = Convert.ToInt32(cmbPresTest.SelectedValue.ToString());
                PreservativeMethodMaster_Class_Obj.min = Convert.ToString(txtPresMin.Text);
                PreservativeMethodMaster_Class_Obj.max = Convert.ToString(txtPresMax.Text);

                PreservativeMethodMaster_Class_Obj.Insert_tblPreservativeMethodMaster();

                btnPresReset_Click(sender, e);
                Bind_List();
                Bind_FormulaNo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPresDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (PreservativeMethodMaster_Class_Obj.fno == 0)
                {
                    MessageBox.Show("Please Select Formula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (dgPres.SelectedRows != null && dgPres.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgPres.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            PreservativeMethodMaster_Class_Obj.del = 1;

                            //FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                            PreservativeMethodMaster_Class_Obj.testno = Convert.ToInt32(dgPres["PresTestNo", dgPres.SelectedRows[i].Index].Value);
                            //PreservativeMethodMaster_Class_Obj.Delete_tblPreservativeMethodMaster_Prsno();
                            PreservativeMethodMaster_Class_Obj.Update_tblPreservativeMethodMaster_Del();

                            dgPres.Rows.Remove(dgPres.SelectedRows[i]);
                        }
                    }
                                        
                    btnPresReset_Click(sender, e);                    
                    Bind_FormulaNo();
                    Bind_List();
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgPres.Focus();
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
            dgPres.Rows.Clear();

            if (CmbFormulaNo.SelectedValue != null && CmbFormulaNo.SelectedValue.ToString() != "")
            {
                
                PreservativeMethodMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());

                DataSet ds = new DataSet();

                ds = PreservativeMethodMaster_Class_Obj.SELECT_tblPreservativeMethodMaster_tblBulkMaster_tblPreservativeMaster();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgPres.Rows.Add();
                        dgPres["PresTestNo", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Prsno"].ToString();
                        dgPres["PresTest", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["PresType"].ToString();
                        dgPres["PresMin", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgPres["PresMax", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                    }
                }
                
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
            try
            {
                if (e.KeyChar == 13)
                {
                    BtnDelete.Enabled = true;
                    dgPres.Rows.Clear();

                    if (List.SelectedValue != null)
                    {
                        txtSearch.Text = Convert.ToString(List.Text);
                        DataSet ds = new DataSet();
                        PreservativeMethodMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                        CmbFormulaNo.Text = List.Text;
                        ds = PreservativeMethodMaster_Class_Obj.SELECT_tblPreservativeMethodMaster_tblBulkMaster_tblPreservativeMaster();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            CmbFormulaNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FormulaNo"]);

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dgPres.Rows.Add();
                                dgPres["PresTestNo", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Prsno"].ToString();
                                dgPres["PresTest", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["PresType"].ToString();
                                dgPres["PresMin", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgPres["PresMax", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
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
                    BtnDelete.Enabled = true;
                    dgPres.Rows.Clear();

                    if (List.SelectedValue != null)
                    {
                        txtSearch.Text = Convert.ToString(List.Text);
                        DataSet ds = new DataSet();
                        PreservativeMethodMaster_Class_Obj.fno = Convert.ToInt64(List.SelectedValue.ToString());
                        CmbFormulaNo.Text = List.Text;
                        ds = PreservativeMethodMaster_Class_Obj.SELECT_tblPreservativeMethodMaster_tblBulkMaster_tblPreservativeMaster();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            CmbFormulaNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FormulaNo"]);

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dgPres.Rows.Add();
                                dgPres["PresTestNo", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Prsno"].ToString();
                                dgPres["PresTest", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["PresType"].ToString();
                                dgPres["PresMin", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                                dgPres["PresMax", dgPres.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
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
 
          
    }
}