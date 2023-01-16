using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;

namespace QTMS
{
    public partial class FrmUserManagement : Form
    {
        public FrmUserManagement()
        {
            InitializeComponent();
        }

        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        bool Modify = false;

        private void FrmUserManagement_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            txtUserName.Focus();
            BindList();
            cmbUserType.SelectedIndex = 0;          

        }

        public void BindList()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = UserManagement_Class_Obj.Select_AllUser();

                lstUsers.DataSource = ds.Tables[0];
                lstUsers.DisplayMember = "UserName";
                lstUsers.ValueMember = "UserID";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Modify = false;
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            cmbUserType.SelectedIndex = 0;          

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Modify = true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Enter User Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return;
            }
            else
            {
                if (txtPassword.Text == "" || txtRePassword.Text == "" || txtPassword.Text.Trim() != txtRePassword.Text.Trim())
                {
                    MessageBox.Show("Re-Enter Password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Text = "";
                    txtRePassword.Text = "";
                    txtPassword.Focus();
                    return;
                }
                else
                {
                    if (MessageBox.Show("Save this User ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        DataSet ds = new DataSet();
                        UserManagement_Class_Obj.Login = txtUserName.Text.Trim();

                        UserManagement_Class_Obj.Password = txtPassword.Text.Trim();

                        if (cmbUserType.Text == "Admin")
                        {
                            UserManagement_Class_Obj.userType = "A";
                        }
                        else if (cmbUserType.Text == "Master")
                        {
                            UserManagement_Class_Obj.userType = "M";
                        }
                        else if (cmbUserType.Text == "Update")
                        {
                            UserManagement_Class_Obj.userType = "U";
                        }
                        else if (cmbUserType.Text == "Normal")
                        {
                            UserManagement_Class_Obj.userType = "N";
                        }
                        

                        if (Modify == false)
                        {
                            ds = UserManagement_Class_Obj.Select_UserName();
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("This User Already Exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtUserName.Text = "";
                                txtPassword.Text = "";
                                txtRePassword.Text = "";
                                txtUserName.Focus();
                                return;
                            }
                            else
                            {                                
                                bool b = UserManagement_Class_Obj.Insert_Users();
                                if (b == true)
                                {
                                    MessageBox.Show("User added Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            ds = UserManagement_Class_Obj.Select_UserName();
                            if (ds.Tables[0].Rows.Count == 0)
                            {
                                MessageBox.Show("This User does not Exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtUserName.Text = "";
                                txtPassword.Text = "";
                                txtRePassword.Text = "";
                                txtUserName.Focus();
                                return;
                            }
                            else
                            {
                                UserManagement_Class_Obj.UserID = lstUsers.SelectedValue.ToString();
                                bool b = UserManagement_Class_Obj.Update_User();
                                if (b == true)
                                {
                                    MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Modify = false;
                                }
                            }
                        }
                        txtUserName.Text = "";
                        txtPassword.Text = "";
                        txtRePassword.Text = "";
                        cmbUserType.SelectedIndex = 0;
                        txtUserName.Focus();
                        BindList();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == "" || lstUsers.SelectedValue == null)
                {
                    MessageBox.Show("Please select the User", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (MessageBox.Show("Delete this User ", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        UserManagement_Class_Obj.UserID = lstUsers.SelectedValue.ToString().Trim();
                        bool b = UserManagement_Class_Obj.Delete_User();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUserName.Text = "";
                            txtPassword.Text = "";
                            txtRePassword.Text = "";
                            cmbUserType.SelectedIndex = 0;
                            txtUserName.Focus();
                            BindList();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Can't Delete This Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            UserManagement_Class_Obj.UserID = lstUsers.SelectedValue.ToString();
            ds = UserManagement_Class_Obj.Select_SelectedUser();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString().Trim();
                txtPassword.Text = ds.Tables[0].Rows[0]["UserPass"].ToString().Trim();
                txtRePassword.Text = ds.Tables[0].Rows[0]["UserPass"].ToString().Trim();
                if (ds.Tables[0].Rows[0]["UserType"].ToString() == "A")
                {
                    cmbUserType.SelectedIndex = 0;
                }
                else if (ds.Tables[0].Rows[0]["UserType"].ToString() == "M")
                {
                    cmbUserType.SelectedIndex = 1;
                }
                else if (ds.Tables[0].Rows[0]["UserType"].ToString() == "U")
                {
                    cmbUserType.SelectedIndex = 2;
                }
                else if (ds.Tables[0].Rows[0]["UserType"].ToString() == "N")
                {
                    cmbUserType.SelectedIndex = 3;
                }
                
            }
        }







    }
}