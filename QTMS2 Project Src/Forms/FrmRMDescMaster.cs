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
    public partial class FrmRMDescMaster : Form
    {
        
                DataSet dsList = new DataSet();
        public FrmRMDescMaster()
        {
            InitializeComponent();
        }
        # region Varibles
        public bool Modify = false;
        RMParaMaster_Class RMParaMaster_Class_Obj = new RMParaMaster_Class();
        RMDescMaster_Class RMDescMaster_Class_Obj = new RMDescMaster_Class();
        # endregion

        private static FrmRMDescMaster frmRMDescMaster_Obj = null;
        public static FrmRMDescMaster GetInstance()
        {
            if (frmRMDescMaster_Obj == null)
            {
                frmRMDescMaster_Obj = new FrmRMDescMaster();
            }
            return frmRMDescMaster_Obj;
        }

        private void FrmRMDescMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_Parameter();
            Bind_List();
           
           // PreservativeMethodMaster_Class_Obj.fno = 0;
        }
        public void Bind_Parameter()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = RMParaMaster_Class_Obj.Select_ParaMaster();
                dr = ds.Tables[0].NewRow();
                dr["ParaName"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                
                CmbParameterName.DataSource = ds.Tables[0];
                CmbParameterName.DisplayMember = "ParaName";
                CmbParameterName.ValueMember = "ParaNo";

               
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
               
                dsList = RMDescMaster_Class_Obj.Select_ParaMaster_DescMaster();
                List.DataSource = dsList.Tables[0];
                List.DisplayMember = "ParaName";
                List.ValueMember = "ParaNo";
               
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


       
        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                btnDescDelete.Enabled = true;
                btnDescModify.Enabled = true;
                dgRMDesc.Rows.Clear();

                if (List.SelectedValue != null)
                {
                   // txtSearch.Text = Convert.ToString(List.Text);
                    DataSet ds = new DataSet();
                    RMDescMaster_Class_Obj.parano = Convert.ToInt32(List.SelectedValue.ToString());
                    CmbParameterName.Text = List.Text;
                    ds = RMDescMaster_Class_Obj.Select_DescMaster_ParaNo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dgRMDesc.Rows.Add();
                            dgRMDesc["DescNo", dgRMDesc.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescNo"].ToString();
                            dgRMDesc["DescName", dgRMDesc.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescName"].ToString();
               
                        }
                    }
                    btnDescDelete.Enabled = true;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
       

       
        private void dgPres_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgRMDesc.Rows.Count > 0)
            {
                if (dgRMDesc.Rows[e.RowIndex].Cells["DescName"].Value != null)
                {
                    txtDescription.Text = dgRMDesc["DescName", e.RowIndex].Value.ToString();
                }
            }
        }

        
       
       
        private void btnDescAdd_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = new DataSet();
                if (CmbParameterName.Text == "--Select--" || CmbParameterName.SelectedValue == null || CmbParameterName.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Select Parameter ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbParameterName.Focus();
                    return;
                }
                if (txtDescription.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Description", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescription.Focus();
                    return;
                }

                for (int i = 0; i < dgRMDesc.Rows.Count; i++)
                {
                    if (dgRMDesc["DescName", i].Value.ToString() == txtDescription.Text.ToString().Trim())
                    {
                        MessageBox.Show("This Description  Already Exists For the Parameter...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescription.Focus();
                        return;
                    }
                }

                if (Modify == true)
                {
                    for (int i = 0; i < dgRMDesc.SelectedRows.Count; i++)
                    {

                        RMDescMaster_Class_Obj.descno=Convert.ToInt32(dgRMDesc["DescNo", dgRMDesc.SelectedRows[i].Index].Value);
                        RMDescMaster_Class_Obj.parano = Convert.ToInt32(CmbParameterName.SelectedValue.ToString());
                        RMDescMaster_Class_Obj.descname = txtDescription.Text.ToString().Trim();
                        RMDescMaster_Class_Obj.createdby = FrmMain.LoginID;
                        RMDescMaster_Class_Obj.modifiedby = FrmMain.LoginID;
                        RMDescMaster_Class_Obj.Update_DescMaster();
                        dgRMDesc["DescNo", dgRMDesc.SelectedRows[i].Index].Value = Convert.ToInt32(RMDescMaster_Class_Obj.descno);
                        dgRMDesc["DescName", dgRMDesc.SelectedRows[i].Index].Value = txtDescription.Text.ToString().Trim();

                        
                    }

                    //btnDescReset_Click(sender, e);
                    Bind_List();
                    Bind_Parameter();
                    return;


                }
               
                RMDescMaster_Class_Obj.parano = Convert.ToInt32(CmbParameterName.SelectedValue.ToString());
                RMDescMaster_Class_Obj.descname = Convert.ToString(txtDescription.Text.ToString().Trim());
                RMDescMaster_Class_Obj.createdby = FrmMain.LoginID;
                RMDescMaster_Class_Obj.modifiedby = FrmMain.LoginID;
                ds = RMDescMaster_Class_Obj.Select_DescMaster_DescName();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    RMDescMaster_Class_Obj.descno = RMDescMaster_Class_Obj.Insert_DescMaster();

                    dgRMDesc.Rows.Add();
                    dgRMDesc["DescName", dgRMDesc.Rows.Count - 1].Value = txtDescription.Text.ToString().Trim();
                    dgRMDesc["DescNo", dgRMDesc.Rows.Count - 1].Value = Convert.ToInt32(RMDescMaster_Class_Obj.descno);



                    //btnDescReset_Click(sender, e);
                    Bind_List();
                    txtDescription.Text = "";
                }
                else
                {
                    MessageBox.Show("Same Description Already Present For the parameter", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDescription.Focus();

                }

                //Bind_Parameter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDescReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            CmbParameterName.Text = "--Select--";
            txtDescription.Text = "";
            CmbParameterName.Focus();
            Modify = false;
            btnDescDelete.Enabled = false;
            btnDescModify.Enabled = false;
            dgRMDesc.Rows.Clear();
          
        }

        private void CmbParameterName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dgRMDesc.Rows.Clear();
                txtDescription.Text = "";
                btnDescDelete.Enabled = true;
                if (CmbParameterName.SelectedValue != null && CmbParameterName.SelectedValue.ToString() != "")
                {

                    RMDescMaster_Class_Obj.parano = Convert.ToInt32(CmbParameterName.SelectedValue.ToString());

                    DataSet ds = new DataSet();

                    ds = RMDescMaster_Class_Obj.Select_DescMaster_ParaNo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dgRMDesc.Rows.Add();
                            dgRMDesc["DescNo", dgRMDesc.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescNo"].ToString();
                            dgRMDesc["DescName", dgRMDesc.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescName"].ToString();

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDescDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (RMDescMaster_Class_Obj.parano == 0)
                {
                    MessageBox.Show("Please Select Parameter ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    List.Focus();
                    return;
                }

                if (dgRMDesc.SelectedRows != null && dgRMDesc.SelectedRows.Count != 0)
                {
                    for (int i = 0; i < dgRMDesc.SelectedRows.Count; i++)
                    {
                        if (MessageBox.Show("Delete This Record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {


                            RMDescMaster_Class_Obj.descno = Convert.ToInt32(dgRMDesc["DescNo", dgRMDesc.SelectedRows[i].Index].Value);
                            RMDescMaster_Class_Obj.descname = dgRMDesc["DescName", dgRMDesc.SelectedRows[i].Index].Value.ToString().Trim();
                            RMDescMaster_Class_Obj.Delete_DescMaster();
                            dgRMDesc.Rows.Remove(dgRMDesc.SelectedRows[i]);
                        }
                    }

                    //btnDescReset_Click(sender, e);
                    //Bind_Parameter();
                    txtDescription.Text = "";
                    Bind_List();
                }
                else
                {
                    MessageBox.Show("Please Select Test From Grid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgRMDesc.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Can't Delete this Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDescModify_Click(object sender, EventArgs e)
        {
            List.Enabled = true;
            Modify = true;
            
        
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "ParaName like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "ParaName";
            List.ValueMember = "ParaNo";
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    btnDescDelete.Enabled = true;
                    btnDescModify.Enabled = true;
                    dgRMDesc.Rows.Clear();

                    if (List.SelectedValue != null)
                    {
                        txtSearch.Text = Convert.ToString(List.Text);
                        DataSet ds = new DataSet();
                        RMDescMaster_Class_Obj.parano = Convert.ToInt32(List.SelectedValue.ToString());
                        CmbParameterName.Text = List.Text;
                        ds = RMDescMaster_Class_Obj.Select_DescMaster_ParaNo();
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dgRMDesc.Rows.Add();
                                dgRMDesc["DescNo", dgRMDesc.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescNo"].ToString();
                                dgRMDesc["DescName", dgRMDesc.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescName"].ToString();

                            }
                        }
                        btnDescDelete.Enabled = true;

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
                    btnDescDelete.Enabled = true;
                    btnDescModify.Enabled = true;
                    dgRMDesc.Rows.Clear();

                    if (List.SelectedValue != null)
                    {
                        txtSearch.Text = Convert.ToString(List.Text);
                        DataSet ds = new DataSet();
                        RMDescMaster_Class_Obj.parano = Convert.ToInt32(List.SelectedValue.ToString());
                        CmbParameterName.Text = List.Text;
                        ds = RMDescMaster_Class_Obj.Select_DescMaster_ParaNo();
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dgRMDesc.Rows.Add();
                                dgRMDesc["DescNo", dgRMDesc.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescNo"].ToString();
                                dgRMDesc["DescName", dgRMDesc.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescName"].ToString();

                            }
                        }
                        btnDescDelete.Enabled = true;

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