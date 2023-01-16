using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using BusinessFacade;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmRMFamilyMaster : System.Windows.Forms.Form
    {
        DataSet dsList = new DataSet();

        # region Variables
        bool modify = false;
        RMFamilyMaster_Class RMFamilyMaster_Class_obj = new RMFamilyMaster_Class(); 
        #endregion

        private static FrmRMFamilyMaster frmRMFamilyMaster_Obj = null;
        public static FrmRMFamilyMaster GetInstance()
        {
            if (frmRMFamilyMaster_Obj == null)
            {
       
                frmRMFamilyMaster_Obj = new Forms.FrmRMFamilyMaster();
            }
            return frmRMFamilyMaster_Obj;
        }



        public FrmRMFamilyMaster()
        {
            InitializeComponent();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtFamilyName.Text = "";
            txtFamilyName.Focus();
            BtnDelete.Enabled = false;
            modify = false;
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
                if (txtFamilyName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Family Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFamilyName.Text = "";
                    txtFamilyName.Focus();
                    return;

                }
                RMFamilyMaster_Class_obj.rmfamilyname = txtFamilyName.Text.Trim();
                RMFamilyMaster_Class_obj.createdby = FrmMain.LoginID;
                RMFamilyMaster_Class_obj.modifiedby = FrmMain.LoginID;
                ds = RMFamilyMaster_Class_obj.Select_RMFamilyMaster_RMFamilyName();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    if (modify == false)
                    {
                        RMFamilyMaster_Class_obj.rmfamilyname = txtFamilyName.Text.Trim();
                        bool b = RMFamilyMaster_Class_obj.Insert_RMFamilyMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFamilyName.Text = "";
                            txtFamilyName.Focus();
                            Bind_List();

                        }
                    }
                    else
                    {
                        RMFamilyMaster_Class_obj.rmfamilyname = txtFamilyName.Text.Trim();
                        RMFamilyMaster_Class_obj.rmfamilyid = Convert.ToInt64(List.SelectedValue.ToString());
                        bool b = RMFamilyMaster_Class_obj.Update_RMFamilyMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFamilyName.Text = "";
                            txtFamilyName.Focus();
                            Bind_List();
                            modify = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Family Already Exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFamilyName.Focus();
                }

            }
            catch 
            {
                MessageBox.Show("Record Already Exists","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtFamilyName.Focus();
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                RMFamilyMaster_Class_obj.rmfamilyid = Convert.ToInt64(List.SelectedValue.ToString());
                if (RMFamilyMaster_Class_obj.rmfamilyid > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = RMFamilyMaster_Class_obj.Delete_RMFamilyMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFamilyName.Text = "";
                            txtFamilyName.Focus();
                            BtnDelete.Enabled = false;
                            Bind_List();
                            modify = false;
                        }
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Cannot Delete this Record","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }
       

        private void BtnModify_Click(object sender, EventArgs e)
        {
            modify = true;
            List_DoubleClick(sender, e);
            BtnDelete.Enabled = true;
        }
        public void Bind_List()
        {
            try
            {

                dsList = RMFamilyMaster_Class_obj.Select_RMFamilyMaster();
                if (dsList.Tables[0].Rows.Count >= 0)
                {
                    List.DataSource = dsList.Tables[0];
                    List.DisplayMember = "RMFamilyName";
                    List.ValueMember = "RMFamilyID";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmRMFamilyMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            Bind_List();
            BtnDelete.Enabled = false;
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            //txtSearch.Text = Convert.ToString(List.Text);
            //DataSet ds = new DataSet();
            RMFamilyMaster_Class_obj.rmfamilyid = Convert.ToInt64(List.SelectedValue.ToString());
            txtFamilyName.Text = List.Text;
            BtnDelete.Enabled = true;
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "RMFamilyName like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "RMFamilyName";
            List.ValueMember = "RMFamilyID";
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSearch.Text = Convert.ToString(List.Text);
                //DataSet ds = new DataSet();
                RMFamilyMaster_Class_obj.rmfamilyid = Convert.ToInt64(List.SelectedValue.ToString());
                txtFamilyName.Text = List.Text;
                BtnDelete.Enabled = true;
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
                txtSearch.Text = Convert.ToString(List.Text);
                //DataSet ds = new DataSet();
                RMFamilyMaster_Class_obj.rmfamilyid = Convert.ToInt64(List.SelectedValue.ToString());
                txtFamilyName.Text = List.Text;
                BtnDelete.Enabled = true;
            }
        }

         

      
    }
}