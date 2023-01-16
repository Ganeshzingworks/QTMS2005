using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;
using BusinessFacade.Transactions;
using QTMS.User_Permissions;

namespace QTMS.Forms
{
    public partial class FrmGroupMailMaster : Form
    {
        public FrmGroupMailMaster()
        {
            InitializeComponent();
        }

        private static FrmGroupMailMaster FrmGroupMailMaster_Obj = null;
        public static FrmGroupMailMaster GetInstance()
        {
            if (FrmGroupMailMaster_Obj == null)
            {
                FrmGroupMailMaster_Obj = new FrmGroupMailMaster();
            }
            return FrmGroupMailMaster_Obj;
        }

        # region Varibles
        GroupMaster_Class GroupMaster_Class_Obj = new GroupMaster_Class();
        UserData UserDataObj = new UserData();
        bool Modify = false;

        # endregion

        private void FrmRetainerLocationMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            txtGroupName.Focus();
            Bind_List();
            Bind_UserNames();
            BindUserType();
            pnlAddUser.Visible = false;
        }

        public void Bind_List()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = GroupMaster_Class_Obj.Select_tblSoftwareUserGroup();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LstGroupName.DataSource = ds.Tables[0];
                    LstGroupName.DisplayMember = "GroupName";
                    LstGroupName.ValueMember = "GroupID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_UserNames()
        {
            try
            {
                //DataRow dr;
                DataTable dt = new DataTable();
                dt = UserDataObj.Show_AllUser_Group();
                //dr = ds.Tables[0].NewRow();
                //dr["UserName"] = "--Select--";
                //dr["UserID"] = "0";
                //ds.Tables[0].Rows.InsertAt(dr, 0);

                if (dt.Rows.Count > 0)
                {
                    ChkLstUserNames.DataSource = dt;
                    ChkLstUserNames.DisplayMember = "UserName";
                    ChkLstUserNames.ValueMember = "UserID";
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int res = 0;

                if (txtGroupName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Group Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGroupName.Focus();
                    return;

                }
                if (Modify == false)
                {
                    GroupMaster_Class_Obj.groupName = txtGroupName.Text.Trim();
                    if (chkIsActive.Checked)
                        GroupMaster_Class_Obj.activeFlag = 1;
                    else
                        GroupMaster_Class_Obj.activeFlag = 0;

                    DataSet ds = new DataSet();
                    ds = GroupMaster_Class_Obj.Select_tblSoftwareUserGroup_GroupName();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Group Name Already Exist.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtGroupName.Focus();
                        return;
                    }
                    //bool b = GroupMaster_Class_Obj.Insert_tblSoftwareUserGroup();
                    //if (b == true)
                    //{
                    //    MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                    res = GroupMaster_Class_Obj.Insert_tblSoftwareUserGroup();
                    if(res!=0)
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    GroupMaster_Class_Obj.groupName = txtGroupName.Text.Trim();
                    GroupMaster_Class_Obj.groupID = Convert.ToInt32(LstGroupName.SelectedValue.ToString());
                    res = GroupMaster_Class_Obj.groupID;

                    if (chkIsActive.Checked)
                        GroupMaster_Class_Obj.activeFlag = 1;
                    else
                        GroupMaster_Class_Obj.activeFlag = 0;


                    if (GroupMaster_Class_Obj.groupID == 0)
                    {
                        MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    bool b = GroupMaster_Class_Obj.Update_tblSoftwareUserGroup();
                    if (b == true)
                    {
                        MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Saved Group by users
                UserDataObj.groupID = Convert.ToInt32(res);
                DeleteCategory(res);
                for (int i = 0; i < ChkLstUserNames.Items.Count; i++)
                {
                    if (ChkLstUserNames.GetItemChecked(i) == true)
                    {
                        ChkLstUserNames.SetSelected(i, true);
                        int userID = Convert.ToInt32(ChkLstUserNames.SelectedValue);
                        UserDataObj.userid = userID;
                        UserDataObj.Insert_SoftwareUserGroupRelation();
                    }
                }



                BtnReset_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Sorry Record Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LstLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               
                if (LstGroupName.SelectedValue != null)
                {
                    Modify = true;
                    DataSet ds = new DataSet();
                    GroupMaster_Class_Obj.groupID = Convert.ToInt32(LstGroupName.SelectedValue.ToString());
                    ds = GroupMaster_Class_Obj.Select_tblSoftwareUserGroup_GroupID();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        txtGroupName.Text = Convert.ToString(dr["GroupName"]);
                        if (Convert.ToString(dr["Del"]) == "True")
                            chkIsActive.Checked = true;
                        else
                            chkIsActive.Checked = false;
                    }
                    //txtGroupName.Text = LstGroupName.Text;
                    BtnDelete.Enabled = true;
                    SelectGroupByUsers(GroupMaster_Class_Obj.groupID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtGroupName.Text = "";
            txtGroupName.Focus();
            chkIsActive.Checked = false;
            BtnDelete.Enabled = false;
            Modify = false;
            Bind_List();
            ResetAllUserNames();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            LstGroupName.Enabled = true;
            Modify = true;
            LstLocation_DoubleClick(sender, e);
            BtnDelete.Enabled = true;

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                GroupMaster_Class_Obj.groupID = Convert.ToInt32(LstGroupName.SelectedValue.ToString());

                if (GroupMaster_Class_Obj.groupID > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = GroupMaster_Class_Obj.Delete_tblSoftwareUserGroup();
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
                MessageBox.Show("Sorry You Can't delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGroupName_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtGroupName.Text = textInfo.ToTitleCase(txtGroupName.Text);
            chkIsActive.Checked = true;
        }

        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(32))
            {
                e.Handled = true;
            }
        }
        private void ResetAllUserNames()
        {
            try
            {
                for (int i = 0; i < ChkLstUserNames.Items.Count; i++)
                {
                    ChkLstUserNames.SetItemChecked(i, false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SelectGroupByUsers(int groupid)
        {
            try
            {
                DataTable Dt = new DataTable();
                UserDataObj.groupID = Convert.ToInt32(groupid);
                Dt = UserDataObj.Select_SoftwareUserGroupRelation();

                ResetAllUserNames();

                foreach (DataRow dr in Dt.Rows)
                {
                    for (int i = 0; i < ChkLstUserNames.Items.Count; i++)
                    {
                        object Items = ChkLstUserNames.Items[i];
                        if (Convert.ToInt64((((System.Data.DataRowView)(Items)).Row.ItemArray[0])) == Convert.ToInt64(dr["UserID"]))
                        {
                            ChkLstUserNames.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void DeleteCategory(int groupid)
        {
            try
            {
                UserDataObj.groupID = Convert.ToInt32(groupid);
                UserDataObj.Delete_SoftwareUserGroupRelation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void lnkAddUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int res = 0;

            if (txtGroupName.Text.Trim() == "")
            {
                MessageBox.Show("Enter Group Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGroupName.Focus();
                return;

            }
            if (Modify == false)
            {
                GroupMaster_Class_Obj.groupName = txtGroupName.Text.Trim();
                if (chkIsActive.Checked)
                    GroupMaster_Class_Obj.activeFlag = 1;
                else
                    GroupMaster_Class_Obj.activeFlag = 0;

                DataSet ds = new DataSet();
                ds = GroupMaster_Class_Obj.Select_tblSoftwareUserGroup_GroupName();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    UserDataObj.groupID = Convert.ToInt32(ds.Tables[0].Rows[0]["GroupID"]);
                }
                else
                {
                    res = GroupMaster_Class_Obj.Insert_tblSoftwareUserGroup();
                    UserDataObj.groupID = res;
                }
            }
            else
            {
                GroupMaster_Class_Obj.groupName = txtGroupName.Text.Trim();
                GroupMaster_Class_Obj.groupID = Convert.ToInt32(LstGroupName.SelectedValue.ToString());
                res = GroupMaster_Class_Obj.groupID;
                UserDataObj.groupID = res;
                //if (chkIsActive.Checked)
                //    GroupMaster_Class_Obj.activeFlag = 1;
                //else
                //    GroupMaster_Class_Obj.activeFlag = 0;
                
                //if (GroupMaster_Class_Obj.groupID == 0)
                //{
                //    MessageBox.Show("Select Record From List", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //bool b = GroupMaster_Class_Obj.Update_tblSoftwareUserGroup();
               
            }

            //frmUsers fm = new frmUsers(res);
            ////fm.MdiParent = this;
           
            ////fm.Show();
            //fm.ShowDialog();

            pnlAddUser.Visible = true;
        }

        private void BindUserType()
        {
            DataTable Dt = new DataTable();
            Dt = UserDataObj.Show_AllUserType();

            cmbUserType.DataSource = Dt;
            cmbUserType.DisplayMember = "UserType";
            cmbUserType.ValueMember = "UserTypeID";
        }

        private void btnUserExit_Click(object sender, EventArgs e)
        {
            pnlAddUser.Visible = false;
            cmbUserType.SelectedIndex = 0;
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            txtUserMailID.Text = "";
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Enter User Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return ;
            }
            if (txtPassword.Text == "" || txtRePassword.Text == "" || txtPassword.Text.Trim() != txtRePassword.Text.Trim())
            {
                MessageBox.Show("Re-Enter Password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Text = "";
                txtRePassword.Text = "";
                txtPassword.Focus();
                return ;
            }
            if (txtUserMailID.Text.Trim() != "")
            {
                if (BusinessFacade.CheckValidMail.IsEmailValid(txtUserMailID.Text.Trim()) == false)
                {
                    MessageBox.Show("Please Enter valid mail ID", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbUserType.SelectedIndex = 0;
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtRePassword.Text = "";
                    txtUserMailID.Text = "";
                    txtUserMailID.Focus();
                    return ;
                }
            }

            DataTable Dt = new DataTable();
            UserDataObj.username = txtUserName.Text.Trim();
            Dt = UserDataObj.Show_SelectedUser_ByUserName();
            if (Dt.Rows.Count > 0)
            {
                MessageBox.Show("This User Already Exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UserDataObj.username = txtUserName.Text.Trim();
            UserDataObj.password = txtPassword.Text.Trim();
            UserDataObj.usertypeid = Convert.ToInt32(cmbUserType.SelectedValue);
            UserDataObj.userMailID = txtUserMailID.Text.Trim();
            UserDataObj.del = 1;
            UserDataObj.userid = UserDataObj.Insert_Users();

            //UserDataObj.groupID = groupid;
            UserDataObj.Insert_SoftwareUserGroupRelation();

            Bind_List();
            Bind_UserNames();

            Modify = true;
            DataSet ds = new DataSet();
            GroupMaster_Class_Obj.groupID = Convert.ToInt32(UserDataObj.groupID);
            ds = GroupMaster_Class_Obj.Select_tblSoftwareUserGroup_GroupID();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                txtGroupName.Text = Convert.ToString(dr["GroupName"]);
                if (Convert.ToString(dr["Del"]) == "True")
                    chkIsActive.Checked = true;
                else
                    chkIsActive.Checked = false;
            }
            //txtGroupName.Text = LstGroupName.Text;
            BtnDelete.Enabled = true;
            SelectGroupByUsers(GroupMaster_Class_Obj.groupID);

            btnUserExit_Click(sender, e);
            pnlAddUser.Visible = false;
        }
    }
}