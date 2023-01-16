using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade.Transactions;
using QTMS.Tools;
namespace QTMS.User_Permissions
{
    public partial class frmUsers : Form
    {
       
        public frmUsers()
        {
            InitializeComponent();
            
        }
        UserData UserDataObj = new UserData();
        bool modify = false;
        DataSet DsList = new DataSet();
        private void frmUsers_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            BindList();
            BindUserType();
            resetAll();

            
        }
        
        private void BindList()
        {
            try
            {
                //DataTable Dt = new DataTable();
                //Dt = UserDataObj.Show_AllUser();
                //DsList.Tables.Add(Dt);
                //lstUsers.DataSource = Dt;
                //lstUsers.DisplayMember = "UserName";
                //lstUsers.ValueMember = "UserID";


                DsList = UserDataObj.Show_AllUser_1();

                lstUsers.DataSource = DsList.Tables[0];
                lstUsers.DisplayMember = "UserName";
                lstUsers.ValueMember = "UserID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        private void BindUserType()
        {
            DataTable Dt = new DataTable();
            Dt = UserDataObj.Show_AllUserType();

            cmbUserType.DataSource = Dt;
            cmbUserType.DisplayMember = "UserType";
            cmbUserType.ValueMember = "UserTypeID";
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            resetAll();
        }
        private void resetAll()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            txtUserMailID.Text = "";
            if (cmbUserType.SelectedValue != null)
                cmbUserType.SelectedIndex = 0;
            txtUserName.Focus();
            modify = false;
            lstUsers.SelectedValue = 0;
        }

        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            UserDataObj.userid = Convert.ToInt32(lstUsers.SelectedValue);
            Dt = UserDataObj.Show_SelectedUser();

            if (Dt.Rows.Count > 0)
            {
                txtUserName.Text = Dt.Rows[0]["UserName"].ToString();
                txtPassword.Text = Dt.Rows[0]["UserPass"].ToString();
                txtRePassword.Text = Dt.Rows[0]["UserPass"].ToString();
                cmbUserType.SelectedValue = Dt.Rows[0]["UserTypeID"].ToString();
                txtUserMailID.Text = Convert.ToString(Dt.Rows[0]["UserMailID"]);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            modify = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool IsValid()
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Enter User Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return false;
            }
            if (txtPassword.Text == "" || txtRePassword.Text == "" || txtPassword.Text.Trim() != txtRePassword.Text.Trim())
            {
                MessageBox.Show("Re-Enter Password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Text = "";
                txtRePassword.Text = "";
                txtPassword.Focus();
                return false;
            }
            if (txtUserMailID.Text.Trim() != "")
            {
                if (BusinessFacade.CheckValidMail.IsEmailValid(txtUserMailID.Text.Trim()) == false)
                {
                    MessageBox.Show("Please Enter valid mail ID", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserMailID.Focus();
                    return false;
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (!modify)
                {
                    if (lstUsers.SelectedValue != null)
                    {
                        DataTable Dt = new DataTable();
                        UserDataObj.username = lstUsers.Text;
                        Dt = UserDataObj.Show_SelectedUser();
                        if (Dt.Rows.Count > 0)
                        {
                            MessageBox.Show("This User Already Exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resetAll();
                        }
                    }
                    else
                    {
                        UserDataObj.username = txtUserName.Text.Trim();
                        UserDataObj.password = txtPassword.Text.Trim();
                        UserDataObj.usertypeid = Convert.ToInt32(cmbUserType.SelectedValue);
                        UserDataObj.userMailID = txtUserMailID.Text.Trim();
                        UserDataObj.del = 1;
                        UserDataObj.userid = UserDataObj.Insert_Users();
                        

                        if (UserDataObj.userid!=0)
                        {
                            MessageBox.Show("User added Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindList();
                            resetAll();
                        }
                    }
                }
                else
                {
                    if (lstUsers.SelectedValue != null)
                    {
                        UserDataObj.userid = Convert.ToInt32(lstUsers.SelectedValue);
                        UserDataObj.username = txtUserName.Text.Trim();
                        UserDataObj.password = txtPassword.Text.Trim();
                        UserDataObj.usertypeid = Convert.ToInt32(cmbUserType.SelectedValue);
                        UserDataObj.userMailID = txtUserMailID.Text.Trim();
                        UserDataObj.del = 1;
                        bool b = UserDataObj.Update_User();
                        if (b == true)
                        {
                            MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindList();
                            resetAll();
                        }
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
                if (lstUsers.SelectedValue != null)
                {
                    UserDataObj.userid = Convert.ToInt32(lstUsers.SelectedValue);
                    UserDataObj.del = 0;
                    bool b = UserDataObj.Delete_User();
                    if (b == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindList();
                        resetAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
                    

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtsearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Down)
                {
                    lstUsers.Select();
                    lstUsers.SelectedIndex = lstUsers.SelectedIndex + 1;
                }
            }
            catch (ArgumentOutOfRangeException exAOR)
            {

                MessageBox.Show("This is last item", "QTMS");
                //   MessageBox.Show("This is last item", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtsearch.Text;
            DsList.Tables[0].DefaultView.RowFilter = "UserName like  '" + searchString + "%'";
            lstUsers.DataSource = DsList.Tables[0];

            lstUsers.DisplayMember = "UserName";
            lstUsers.ValueMember = "UserID";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {                
                DataSet ds = new DataSet();
                ds = UserDataObj.Select_All_Record_tblSoftwareUserInfo();

                BusinessFacade.ExportToExcel objExport = new BusinessFacade.ExportToExcel();
                objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

                    

    }
}