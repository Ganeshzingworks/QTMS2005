using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmPMSupplierMaster : System.Windows.Forms.Form
    {
        public FrmPMSupplierMaster()
        {
            InitializeComponent();
        }

        DataSet dsList = new DataSet();
        #region Variables
        BusinessFacade.Transactions.Comman_Class Comman_Class_obj = new BusinessFacade.Transactions.Comman_Class();
        PMSupplierMaster_Class PMSupplierMaster_Class_obj = new PMSupplierMaster_Class();
        bool modify = false;
        #endregion

        private static FrmPMSupplierMaster frmPMSupplierMaster_Obj = null;
        public static FrmPMSupplierMaster GetInstance()
        {
            if (frmPMSupplierMaster_Obj == null)
            {
                frmPMSupplierMaster_Obj = new Forms.FrmPMSupplierMaster();
            }
            return frmPMSupplierMaster_Obj;
        }


        private void FrmPMSupplierMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            dtpPMAuditDate.Value = Comman_Class_obj.Select_ServerDate();
            dtpPMAuditDate.Checked = false;
            Bind_List();
        }

       
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Bind_List();
            txtSearch.Text = "";
            txtPMSupplierName.Text = "";
            txtSupplierMailID.Text = "";
            dtpPMAuditDate.Value = Comman_Class_obj.Select_ServerDate();
            dtpPMAuditDate.Checked = false;
            modify = false;
            btnDelete.Enabled = false;
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPMSupplierName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Supplier Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPMSupplierName.Focus();
                    return;

                }
                if (txtSupplierMailID.Text.Trim() != "")
                {
                    if (CheckValidMail.IsEmailValid(txtSupplierMailID.Text.Trim()) == false)
                    {
                        MessageBox.Show("Please Enter Valid Supplier Mail ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSupplierMailID.Focus();
                        return;
                    }
                }
                PMSupplierMaster_Class_obj.createdby = FrmMain.LoginID;
                PMSupplierMaster_Class_obj.modifiedby = FrmMain.LoginID;
                if (modify == false)
                {
                    PMSupplierMaster_Class_obj.pmsuppliername = txtPMSupplierName.Text.ToString();
                    PMSupplierMaster_Class_obj.supplierMailID = txtSupplierMailID.Text.Trim();
                    if (dtpPMAuditDate.Checked == true)
                    {
                        PMSupplierMaster_Class_obj.pmauditdate = dtpPMAuditDate.Value.ToShortDateString();
                    }
                    else
                    {
                        PMSupplierMaster_Class_obj.pmauditdate = null;
                    }
                    bool b = PMSupplierMaster_Class_obj.Insert_PMSupplierMaster();
                    if (b == true)
                    {
                        MessageBox.Show("Record Saved Successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnReset_Click(sender, e);
                        Bind_List();

                    }
                }
                else
                {
                    if (txtPMSupplierName.Text.ToString() == "")
                    {
                        MessageBox.Show("Supplier Name cannot be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPMSupplierName.Focus();
                        return;
                    }
                    PMSupplierMaster_Class_obj.pmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
                    PMSupplierMaster_Class_obj.pmsuppliername = txtPMSupplierName.Text.ToString();
                    PMSupplierMaster_Class_obj.supplierMailID = txtSupplierMailID.Text.Trim();// Add supplier mail ID
                    if (dtpPMAuditDate.Checked == true)
                    {
                        PMSupplierMaster_Class_obj.pmauditdate = dtpPMAuditDate.Value.ToShortDateString();
                    }
                    else
                    {
                        PMSupplierMaster_Class_obj.pmauditdate = null;
                    }
                    
                    bool b1=PMSupplierMaster_Class_obj.Update_PMSupplierMaster();
                    if (b1 == true)
                    {
                        MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        Bind_List();
                        modify = false;
                        btnReset_Click(sender, e);
                    }
                    
                }

            }
            catch 
            {
                MessageBox.Show("Same Supplier Already Exist","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtPMSupplierName.Text = "";
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            List_DoubleClick(sender, e);
            modify = true;
        }

        public void Bind_List()
        {
            try
            {
               
                dsList = PMSupplierMaster_Class_obj.Select_PMSupplierMaster();
                if (dsList.Tables[0].Rows.Count >= 0)
                {
                    List.DataSource = dsList.Tables[0];
                    List.DisplayMember = "PMSupplierName";
                    List.ValueMember = "PMSupplierID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
           // txtSearch.Text = Convert.ToString(List.Text);
          //  btnReset_Click(sender, e);
            DataSet ds = new DataSet();
            PMSupplierMaster_Class_obj.pmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
            ds = PMSupplierMaster_Class_obj.Select_PMSupplierMaster_PMSupplierID();
            txtPMSupplierName.Text = List.Text.ToString();
            if (ds.Tables[0].Rows[0]["AuditConducted"].ToString() != "")
            {
                dtpPMAuditDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["AuditConducted"].ToString());
            }
            if (ds.Tables[0].Rows[0]["PMSupplierMail"].ToString() != "")
            {
                txtSupplierMailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMSupplierMail"].ToString());
            }
            
            btnDelete.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                PMSupplierMaster_Class_obj.pmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());

                if (PMSupplierMaster_Class_obj.pmsupplierid > 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        bool b = PMSupplierMaster_Class_obj.Delete_PMSupplierMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnReset_Click(sender, e);
                            Bind_List();
                            modify = false;
                            btnDelete.Enabled = false;
                        }
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Record Cannot Be Deleted","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void txtPMSupplierName_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtPMSupplierName.Text = textInfo.ToTitleCase(txtPMSupplierName.Text.Trim());
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            dsList .Tables[0].DefaultView.RowFilter = "PMSupplierName like  '" + searchString + "%'";
            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "PMSupplierName";
            List.ValueMember = "PMSupplierID";
        }
        
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
         {
            if(e.KeyChar==13)
            {
                txtSearch.Text = Convert.ToString(List.Text);
              //  btnReset_Click(sender, e);
                DataSet ds = new DataSet();
                PMSupplierMaster_Class_obj.pmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
                ds = PMSupplierMaster_Class_obj.Select_PMSupplierMaster_PMSupplierID();
                txtPMSupplierName.Text = List.Text.ToString();
                if (ds.Tables[0].Rows[0]["AuditConducted"].ToString() != "")
                {
                    dtpPMAuditDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["AuditConducted"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PMSupplierMail"].ToString() != "")
                {
                    txtSupplierMailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMSupplierMail"].ToString());
                }

                btnDelete.Enabled = true;
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
              //  btnReset_Click(sender, e);
                DataSet ds = new DataSet();
                PMSupplierMaster_Class_obj.pmsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
                ds = PMSupplierMaster_Class_obj.Select_PMSupplierMaster_PMSupplierID();
                txtPMSupplierName.Text = List.Text.ToString();
                if (ds.Tables[0].Rows[0]["AuditConducted"].ToString() != "")
                {
                    dtpPMAuditDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["AuditConducted"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PMSupplierMail"].ToString() != "")
                {
                    txtSupplierMailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMSupplierMail"].ToString());
                }

                btnDelete.Enabled = true;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                PMSupplierMaster_Class objPMSupplierMaster_Class = new PMSupplierMaster_Class();
                DataSet ds = new DataSet();
                ds = objPMSupplierMaster_Class.Select_All_Record_tblPMSupplierMaster();

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