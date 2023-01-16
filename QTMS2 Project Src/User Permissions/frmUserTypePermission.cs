using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade.Transactions;
using QTMS.Tools;
namespace QTMS.User_Permissions
{
    public partial class frmUserTypePermission : Form
    {
        public frmUserTypePermission()
        {
            InitializeComponent();
        }

        private void frmUserTypePermission_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);            
            BindUserType();
            PopulateTreeView();
        }

        private void BindUserType()
        {
            UserData UserDataObj = new UserData();
            DataTable Dt = new DataTable();
            DataRow dr;

            Dt = UserDataObj.Show_AllUserType();

            dr = Dt.NewRow();
            dr["UserType"] = "-- Select User Type --";
            dr["UserTypeID"] = "00";
            Dt.Rows.InsertAt(dr, 0);

            cmbUserType.DataSource = Dt;
            cmbUserType.DisplayMember = "UserType";
            cmbUserType.ValueMember = "UserTypeID";

            cmbUserType.SelectedIndex = 0;
        }

        private void PopulateTreeView()
        {            
            UserData UserDataObj = new UserData();
            DataTable Dt = new DataTable();
            TreeNode parentnode = null;
            TreeNode childnode = null;
            TreeNode subchildnode = null;
            Dt = UserDataObj.Show_AllForms();
            if (Dt.Rows.Count > 0)
            {
                Dt.DefaultView.RowFilter = "ParentID = 0";
                foreach (DataRowView dr in Dt.DefaultView)
                {
                    parentnode = new TreeNode(dr["FormName"].ToString());
                    parentnode.Tag = Convert.ToString(dr["FormID"].ToString());
                    parentnode.ForeColor = Color.Red;
                    parentnode.NodeFont = new Font("Verdana", 10, FontStyle.Bold);
                    
                    Dt.DefaultView.RowFilter = "ParentID =" + parentnode.Tag;
                    foreach (DataRowView drChild in Dt.DefaultView)
                    {
                        childnode = new TreeNode(drChild["FormName"].ToString());
                        childnode.Tag = Convert.ToString(drChild["FormID"].ToString());
                        childnode.ForeColor = Color.Maroon;
                        childnode.NodeFont = new Font("Verdana",10,  FontStyle.Bold);

                        Dt.DefaultView.RowFilter = "ParentID =" + childnode.Tag;

                        foreach (DataRowView drSubChild in Dt.DefaultView)
                        {
                            subchildnode = new TreeNode(drSubChild["FormName"].ToString());
                            subchildnode.Tag = Convert.ToString(drSubChild["FormID"].ToString());
                            subchildnode.NodeFont = new Font("Verdana", 10);
                            childnode.Nodes.Add(subchildnode);
                        }
                        parentnode.Nodes.Add(childnode);
                    }
                    tvPermissions.Nodes.Add(parentnode);
                    parentnode.ExpandAll();
                }
            }
        }

        private void Reset()
        {
            cmbUserType.SelectedIndex = 0;
            if (cmbUserType.SelectedValue.ToString() == "0")
            {
                foreach (TreeNode treenode in tvPermissions.Nodes)
                {
                    TreeNodeCollection ChildNode = treenode.Nodes;
                    foreach (TreeNode cnode in ChildNode)
                    {
                        TreeNodeCollection subChildNode = cnode.Nodes;
                        foreach (TreeNode subnode in subChildNode)
                        {
                            subnode.Checked = false;
                        }
                        cnode.Checked = false;
                    }
                    treenode.Checked = false;
                }
            }
            cmbUserType.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkAddNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reset();
            grbAddUserType.Visible = true;
            grbPermission.Enabled  = false;
            grbAddUserType.BringToFront();
            txtUserType.Focus();
        }
        // Add New User Type or Edit User Type
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbUserType.SelectedValue) == 0)
                {
                    if (txtUserType.Text.Trim().Length != 0)
                    {
                        UserData UserDataObj = new UserData();
                        UserDataObj.usertype = txtUserType.Text.Trim();
                        if (UserDataObj.AddUserType_tblUserTypes())
                        {
                            MessageBox.Show("User Type Added Successfully");
                            BindUserType();
                            //cmbUserType.Text = txtUserType.Text.Trim();
                            txtUserType.Clear();
                            grbAddUserType.Visible = false;
                            grbPermission.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Insert User Type");
                    }
                }
                else
                {
                    if (txtUserType.Text.Trim().Length != 0)
                    {
                        UserData UserDataObj = new UserData();
                        UserDataObj.usertypeid = Convert.ToInt32(cmbUserType.SelectedValue);
                        UserDataObj.usertype = txtUserType.Text.Trim();
                        if (UserDataObj.EditUserType_tblUserTypes())
                        {
                            MessageBox.Show("User Type updated Successfully");
                            BindUserType();
                            //cmbUserType.Text = txtUserType.Text.Trim();
                            txtUserType.Clear();
                            grbAddUserType.Visible = false;
                            grbPermission.Enabled = true;                           
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Insert User Type");
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("This user type already present");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grbAddUserType.Visible = false;
            grbPermission.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UserData UD = new UserData();
                //Delele all image compare permission against user type
                
                if (Convert.ToInt32(cmbUserType.SelectedValue) == 0) //If User Type is not selected then permission not set
                {
                    MessageBox.Show("Please Select User Type");
                    return;
                }
                UD.usertypeid = Convert.ToInt32(cmbUserType.SelectedValue);
                UD.DeleteUType_FormName_tblImageComparePermission();
                foreach (TreeNode treenode in tvPermissions.Nodes)
                {
                    //if (treenode.Checked)
                    //{
                    //    str += treenode.Text;
                    //}
                    TreeNodeCollection ChildNode = treenode.Nodes;
                    foreach (TreeNode cnode in ChildNode)
                    {
                        //str += cnode.Text;
                        TreeNodeCollection subChildNode = cnode.Nodes;
                        foreach (TreeNode subnode in subChildNode)
                        {
                            DataTable Dt = new DataTable();
                            //UD.usertypeid = Convert.ToInt32(cmbUserType.SelectedValue);
                            UD.formid = Convert.ToInt32(subnode.Tag.ToString());
                            UD.formname = subnode.Text.Trim();
                            if (UD.usertypeid == 0) //If User Type is not selected then permission not set
                            {
                                MessageBox.Show("Please Select User Type");
                                return;
                            }
                           
                            Dt = UD.CheckUTID_FormIDExist(); //Check User Type ID & Form ID Already Exist 

                            if (subnode.Checked)
                            {
                                if (UD.formid == 241)
                                {
                                    UD.AddUType_FormName_tblImageComparePermission();
                                    continue;
                                }
                                else if (UD.formid == 242)
                                {
                                    UD.AddUType_FormName_tblImageComparePermission();
                                    continue;
                                }
                                else if (UD.formid == 243)
                                {
                                    UD.AddUType_FormName_tblImageComparePermission();
                                    continue;
                                }
                                UD.formpermission = 1;
                                if (Dt.Rows.Count > 0)
                                {
                                    if (UD.UpdateUType_FormName_tblSoftwareTypeForm())
                                    {
                                        //MessageBox.Show("User Type & Form Permission Updated Successfully");

                                    }
                                }
                                else
                                {

                                    if (UD.AddUType_FormName_tblSoftwareTypeForm())
                                    {
                                        //MessageBox.Show("User Type & Form Permission Added Successfully");
                                        //tvPermissions.Nodes.Clear();
                                        //PopulateTreeView();
                                    }
                                }
                                
                            }
                            else
                            {
                                UD.formpermission = 0;
                                if (Dt.Rows.Count > 0)
                                {
                                    if (UD.UpdateUType_FormName_tblSoftwareTypeForm())
                                    {
                                        //MessageBox.Show("User Type & Form Permission Updated Successfully");

                                    }
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("User Type & Form Permission set Successfully");
                Reset();
                showUserTypeFormPermission();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
                showUserTypeFormPermission();
        }

        private void showUserTypeFormPermission()//Show all form permission by user type
        {
            try
            {
                tvPermissions.Refresh();
                foreach (TreeNode treenode in tvPermissions.Nodes)
                    {                        
                        TreeNodeCollection ChildNode = treenode.Nodes;
                        foreach (TreeNode cnode in ChildNode)
                        {
                            TreeNodeCollection subChildNode = cnode.Nodes;
                            foreach (TreeNode subnode in subChildNode)
                            {
                                DataTable Dt = new DataTable();
                                UserData userdata1 = new UserData();
                                userdata1.usertypeid = Convert.ToInt32(cmbUserType.SelectedValue);
                                userdata1.formid = Convert.ToInt32(subnode.Tag.ToString());
                                if (userdata1.usertypeid == 0)
                                {
                                    Reset();
                                    return;
                                }

                                if (userdata1.formid == 241 || userdata1.formid == 242 || userdata1.formid == 243)
                                {
                                    DataTable dtImageCompareForm = new DataTable();
                                    dtImageCompareForm = userdata1.CheckUTID_FormIDExistINImageComapareTable();
                                    if (dtImageCompareForm.Rows.Count > 0)
                                    {
                                        subnode.Checked = true;
                                        cnode.Checked = true;
                                        treenode.Checked = true;
                                    }
                                    else
                                    {
                                        subnode.Checked = false;
                                        cnode.Checked = false;
                                        treenode.Checked = false;
                                    }
                                    continue;
                                }


                                Dt = userdata1.CheckUTID_FormIDExist();
                                if (Dt.Rows.Count > 0)
                                {
                                    if (Dt.Rows[0]["FormPermission"].ToString() == "True")
                                    {
                                        subnode.Checked = true;
                                        cnode.Checked = true;
                                        treenode.Checked = true;
                                    }
                                    else
                                    {
                                        subnode.Checked = false;
                                        cnode.Checked = false;
                                    }
                                }
                                else
                                {
                                    subnode.Checked = false;
                                    cnode.Checked = false;
                                    treenode.Checked = false;
                                }
                                
                                treenode.ExpandAll();
                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void cmbUserType_SelectionChangeCommitted(object sender, EventArgs e)
        {
                showUserTypeFormPermission();
        }

        private void tvPermissions_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Checked)
                {
                    if (e.Node.Parent == null)
                    {
                        TreeNodeCollection ChildNode = e.Node.Nodes;
                        foreach (TreeNode cnode in ChildNode)
                        {
                            TreeNodeCollection subChildNode = cnode.Nodes;
                            foreach (TreeNode subnode in subChildNode)
                            {
                                subnode.Checked = true;

                            }
                            cnode.Checked = true;
                        }
                    }
                    else
                    {
                        TreeNodeCollection subChildNode = e.Node.Nodes;
                        foreach (TreeNode subnode in subChildNode)
                        {
                            subnode.Checked = true;
                        }
                        e.Node.Parent.Checked = true;
                        if (e.Node.Parent.Parent != null)
                            e.Node.Parent.Parent.Checked = true;
                    }
                }
                else
                {
                    if (e.Node.Parent == null)
                    {
                        TreeNodeCollection ChildNode = e.Node.Nodes;
                        foreach (TreeNode cnode in ChildNode)
                        {
                            TreeNodeCollection subChildNode = cnode.Nodes;
                            foreach (TreeNode subnode in subChildNode)
                            {
                                subnode.Checked = false;
                            }
                            cnode.Checked = false;
                        }
                    }
                    else
                    {
                        TreeNodeCollection subChildNode = e.Node.Nodes;

                        foreach (TreeNode subnode in subChildNode)
                        {
                            subnode.Checked = false;
                        }
                        TreeNodeCollection childnode = e.Node.Parent.Nodes;

                        foreach (TreeNode cnode in childnode)
                        {
                            if (cnode.Checked)
                            {
                                cnode.Checked = true;
                                return;
                            }

                            //else
                            //    cnode .Checked = false ;

                        }
                        e.Node.Parent.Checked = false;
                        if (e.Node.Parent.Parent != null)
                        {
                            TreeNodeCollection parentNode = e.Node.Parent.Parent.Nodes;
                            foreach (TreeNode pNode in parentNode)
                            {
                                if (pNode.Checked)
                                {
                                    pNode.Checked = true;
                                    return;
                                }
                            }
                            e.Node.Parent.Parent.Checked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void lnkEditUserType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Convert.ToInt32(cmbUserType.SelectedValue) > 0)
            {
                txtUserType.Text = cmbUserType.Text.Trim();
            }
            else
            {
                MessageBox.Show("Please Select User Type");
                cmbUserType.Focus();
                return;
            }
            grbAddUserType.Visible = true;
            grbPermission.Enabled = false;
            grbAddUserType.BringToFront();
            txtUserType.Focus();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}