using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;


namespace QTMS.Forms
{
    public partial class FrmChangeUserPassword : Form
    {
        CompareOptions compareOptions = CompareOptions.IgnoreCase;
        BusinessFacade.UserManagement_Class obj_UserManagement = new BusinessFacade.UserManagement_Class();
        public FrmChangeUserPassword()
        {
            InitializeComponent();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtcnfPass.Text = "";
            txtNewPass.Text = "";
            txtOldPass.Text = "";
        }

        private void FrmChangeUserPassword_Load(object sender, EventArgs e)
        {
            QTMS.Tools.Painter.Paint(this);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // checks the old password valid or not?
            if (checkPassword())
            {
                // checks the new pass and confirm password same or not?
                if (CheckPasswordMatch())
                {
                    int userid = 0;
                    DataSet ds = new DataSet();
                    obj_UserManagement.UserID = Convert.ToString(FrmMain.LoginID);
                    ds = obj_UserManagement.Select_SelectedUser();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        userid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    }
                    // update old password with new password.
                    obj_UserManagement.UID = Convert.ToInt32(userid);
                    obj_UserManagement.Password = txtNewPass.Text.Trim();
                    obj_UserManagement.Update_UserPassword();
                    MessageBox.Show("Password Updated Sucessfully!");
                    BtnReset_Click(sender, e);
                }
            }
        }

        private void txtOldPass_Leave(object sender, EventArgs e)
        {
            checkPassword();
        }

        private bool checkPassword()
        {
            if (txtOldPass.Text.Trim() != "")
            {
                string strOldPass = "";
                DataSet ds = new DataSet();
                obj_UserManagement.UserID = Convert.ToString(FrmMain.LoginID);
                ds = obj_UserManagement.Select_SelectedUser();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strOldPass = ds.Tables[0].Rows[0]["UserPass"].ToString();
                }
                //if (string.Compare(strOldPass, txtOldPass.Text.Trim(), CultureInfo.CurrentCulture, compareOptions) == 0)//txtOldPass.Text.Trim().ToLower())

                if (string.Compare(strOldPass, txtOldPass.Text.Trim(),false,CultureInfo.CurrentCulture) == 0)//txtOldPass.Text.Trim().ToLower())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Sorry Invalid Old Password!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please Enter Old Password!");
                return false;
            }
        }
        private void txtcnfPass_Leave(object sender, EventArgs e)
        {
            //CheckPasswordMatch();
        }

        private bool CheckPasswordMatch()
        {
            string strNewPass = txtNewPass.Text.Trim();
            string strCnfPass = txtcnfPass.Text.Trim();
            if (strNewPass != "") //&& strCnfPass != "")
            {
                CompareOptions compareOptions = CompareOptions.IgnoreCase;
                if (string.Compare(strNewPass, strCnfPass, false, CultureInfo.CurrentCulture) == 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Sorry Passwords Are Not Matching!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please Enter New Password!");
                return false;
            }
        }


    }
}