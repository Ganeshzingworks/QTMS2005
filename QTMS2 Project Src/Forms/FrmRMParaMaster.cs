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
    public partial class FrmRMParaMaster : System.Windows.Forms.Form
    {
        DataSet dsList = new DataSet();
        #region Varibles
        RMParaMaster_Class RMParaMaster_Class_Obj = new RMParaMaster_Class();
        bool Modify = false;
        #endregion

        private static FrmRMParaMaster frmRMParaMaster_Obj = null;
        public static FrmRMParaMaster GetInstance()
        {
            if (frmRMParaMaster_Obj == null)
            {
                frmRMParaMaster_Obj = new FrmRMParaMaster();
            }
            return frmRMParaMaster_Obj;
        }

        public FrmRMParaMaster()
        {
            InitializeComponent();
        }

        private void FrmRMParaMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            txtParameterName.Focus();
            Bind_List();            
        }
        public void Bind_List()
        {
           
            dsList = RMParaMaster_Class_Obj.Select_ParaMaster();
            if (dsList.Tables[0].Rows.Count >= 0)
            {
                List.DataSource = dsList.Tables[0];
                List.DisplayMember = "ParaName";
                List.ValueMember = "ParaNo";

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
                DataSet ds = new DataSet();
                if (txtParameterName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Parameter Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtParameterName.Focus();
                    return;
                }
                
                RMParaMaster_Class_Obj.paraname = txtParameterName.Text.Trim();
                RMParaMaster_Class_Obj.createdby = FrmMain.LoginID;
                RMParaMaster_Class_Obj.modifiedby = FrmMain.LoginID;


                if (Modify == false)
                    {
                        RMParaMaster_Class_Obj.paraname = txtParameterName.Text.Trim();                        
                        ds = RMParaMaster_Class_Obj.Select_ParaMaster_ParaName();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            bool b = RMParaMaster_Class_Obj.Insert_ParaMaster();
                            if (b == true)
                            {
                                MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BtnReset_Click(sender, e);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Parameter Already Present", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtParameterName.Focus();
                            return;
                        }
                    }
                    else
                    {                        
                        RMParaMaster_Class_Obj.paraname = txtParameterName.Text.ToString().Trim();
                        RMParaMaster_Class_Obj.parano = Convert.ToInt32(List.SelectedValue.ToString());
                        if (RMParaMaster_Class_Obj.parano == 0)
                        {
                            MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        bool b = RMParaMaster_Class_Obj.Update_ParaMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnReset_Click(sender, e);
                        }
                    }                
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtParameterName.Focus();
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            List.Enabled = true;
            Modify = true;
            List_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               // txtSearch.Text = Convert.ToString(List.Text);
                Modify = true;
                DataSet ds = new DataSet();
                RMParaMaster_Class_Obj.parano = Convert.ToInt32(List.SelectedValue.ToString());
                ds = RMParaMaster_Class_Obj.Select_ParaMaster_ParaNo();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtParameterName.Text = ds.Tables[0].Rows[0]["ParaName"].ToString();
                   
                }
                BtnDelete.Enabled = true;
                BtnModify.Enabled = true;
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
                RMParaMaster_Class_Obj.parano = Convert.ToInt32(List.SelectedValue.ToString());

                if (RMParaMaster_Class_Obj.parano > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = RMParaMaster_Class_Obj.Delete_ParaMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnReset_Click(sender, e);
                        }
                    }
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Sorry You Can't delete this record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtParameterName.Focus();
                Modify = false;
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtParameterName.Text = "";
            txtParameterName.Focus();
            Modify = false;
            RMParaMaster_Class_Obj.parano = 0;
            BtnDelete.Enabled = false;            
            Bind_List();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
  
        //private void txtParameterName_Leave(object sender, EventArgs e)
        //{
        //    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        //    TextInfo textInfo = cultureInfo.TextInfo;
        //    txtParameterName.Text = textInfo.ToTitleCase(txtParameterName.Text);
        //}

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "ParaName like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "ParaName";
            List.ValueMember = "ParaNo";
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    Modify = true;
                    DataSet ds = new DataSet();
                    RMParaMaster_Class_Obj.parano = Convert.ToInt32(List.SelectedValue.ToString());
                    ds = RMParaMaster_Class_Obj.Select_ParaMaster_ParaNo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtParameterName.Text = ds.Tables[0].Rows[0]["ParaName"].ToString();

                    }
                    BtnDelete.Enabled = true;
                    BtnModify.Enabled = true;
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

        private void List_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    Modify = true;
                    DataSet ds = new DataSet();
                    RMParaMaster_Class_Obj.parano = Convert.ToInt32(List.SelectedValue.ToString());
                    ds = RMParaMaster_Class_Obj.Select_ParaMaster_ParaNo();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtParameterName.Text = ds.Tables[0].Rows[0]["ParaName"].ToString();

                    }
                    BtnDelete.Enabled = true;
                    BtnModify.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

      
        
    }
}