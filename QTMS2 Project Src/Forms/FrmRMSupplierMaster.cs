using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Threading;
using System.Globalization;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmRMSupplierMaster : System.Windows.Forms.Form
    {
        DataSet dsList = new DataSet();

        #region Variables
        bool modify = false;
        RMSupplierMaster_Class RMSupplierMaster_Class_obj = new RMSupplierMaster_Class();
        #endregion

        private static FrmRMSupplierMaster frmRMSupplerMaster_Obj = null;
        public static FrmRMSupplierMaster GetInstance()
        {
            if (frmRMSupplerMaster_Obj == null)
            {
                frmRMSupplerMaster_Obj = new Forms.FrmRMSupplierMaster();
            }
            return frmRMSupplerMaster_Obj;
        }

       
        public FrmRMSupplierMaster()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtSupplierName.Text = "";
            txtDGACode.Text = "";
            txtSupplierName.Focus();
            btnDelete.Enabled = false;
            modify = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                if (txtSupplierName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Supplier Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierName.Text = "";
                    txtSupplierName.Focus();
                    return;

                }
                RMSupplierMaster_Class_obj.rmsuppliername = txtSupplierName.Text.Trim();
                RMSupplierMaster_Class_obj.dgacode = txtDGACode.Text.Trim();
                RMSupplierMaster_Class_obj.createdby = FrmMain.LoginID;
                RMSupplierMaster_Class_obj.modifiedby = FrmMain.LoginID;
                ds = RMSupplierMaster_Class_obj.Select_RMSupplierMaster_RMSupplierName();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    if (modify == false)
                    {
                        RMSupplierMaster_Class_obj.rmsuppliername = txtSupplierName.Text.Trim();
                        RMSupplierMaster_Class_obj.dgacode = txtDGACode.Text.Trim();
                        bool b = RMSupplierMaster_Class_obj.Insert_RMSupplierMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtSupplierName.Text = "";
                            txtDGACode.Text = "";
                            txtSupplierName.Focus();
                            Bind_List();

                        }
                    }
                    else
                    {
                        RMSupplierMaster_Class_obj.rmsuppliername = txtSupplierName.Text.Trim();
                        RMSupplierMaster_Class_obj.dgacode = txtDGACode.Text.Trim();
                        RMSupplierMaster_Class_obj.rmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
                        bool b = RMSupplierMaster_Class_obj.Update_RMSupplierMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtSupplierName.Text = "";
                            txtDGACode.Text = "";
                            txtSupplierName.Focus();
                            Bind_List();
                            modify = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Supplier Already Exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSupplierName.Focus();
                }
            }
            catch 
            {
                MessageBox.Show("Record Already Exist", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierName.Focus();
            }
        }
        public void Bind_List()
        {
           
              
                dsList = RMSupplierMaster_Class_obj.Select_RMSupplierMaster();
                if (dsList.Tables[0].Rows.Count >= 0)
                {
                    List.DataSource = dsList.Tables[0];
                    List.DisplayMember = "RMSupplierName";
                    List.ValueMember = "RMSupplierID";

                }
           
            
        }

        
        private void FrmRMSupplierMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            Bind_List();
            btnDelete.Enabled = false;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            modify = true;
            List_DoubleClick(sender, e);
            btnDelete.Enabled = true;
                         
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //txtSearch.Text = Convert.ToString(List.Text);
                DataSet ds = new DataSet();
                RMSupplierMaster_Class_obj.rmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
                txtSupplierName.Text = List.Text;
                btnDelete.Enabled = true;

                //txtDGACode.Text = RMSupplierMaster_Class_obj.Select_RMSupplierMaster_DGACode();
            }
            catch 
            {
                MessageBox.Show("List Contains no Items","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {   
                
                RMSupplierMaster_Class_obj.rmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
                if (RMSupplierMaster_Class_obj.rmsupplierid > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = RMSupplierMaster_Class_obj.Delete_RMSupplierMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtSupplierName.Text = "";
                            txtDGACode.Text = "";
                            txtSupplierName.Focus();
                            btnDelete.Enabled = false;
                            Bind_List();
                            modify = false;
                        }
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Can't Delete this Record","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void txtSupplierName_Leave(object sender, EventArgs e)
        //{
        //    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
        //    TextInfo textInfo = cultureInfo.TextInfo;
        //    txtSupplierName.Text = textInfo.ToTitleCase(txtSupplierName.Text);
        //}
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "RMSupplierName like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "RMSupplierName";
            List.ValueMember = "RMSupplierID";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    DataSet ds = new DataSet();
                    RMSupplierMaster_Class_obj.rmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
                    txtSupplierName.Text = List.Text;
                    btnDelete.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("List Contains no Items", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                   List.SelectedIndex =  List.SelectedIndex - 1;
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

        private void List_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void List_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    DataSet ds = new DataSet();
                    RMSupplierMaster_Class_obj.rmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
                    txtSupplierName.Text = List.Text;
                    btnDelete.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("List Contains no Items", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                RMSupplierMaster_Class objRMSupplierMaster_Class = new RMSupplierMaster_Class();
                DataSet ds = new DataSet();
                ds = objRMSupplierMaster_Class.Select_All_Record_tblRMSupplierMaster();

                ExportToExcel objExport = new ExportToExcel();
                objExport.GenerateExcelFile(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}