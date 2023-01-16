using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmReagentSupplierPOMappingMaster : Form
    {
        public FrmReagentSupplierPOMappingMaster()
        {
            InitializeComponent();
        }

        #region Variables
        bool modify = false;
        ReagentSupplierPONumber_Class ReagentSupplierPONumber_Class_obj = new ReagentSupplierPONumber_Class();
        #endregion

        private static FrmReagentSupplierPOMappingMaster frmReagentSupplierPOMappingMaster_Obj = null;
        public static FrmReagentSupplierPOMappingMaster GetInstance()
        {
            if (frmReagentSupplierPOMappingMaster_Obj == null)
            {
                frmReagentSupplierPOMappingMaster_Obj = new Forms.FrmReagentSupplierPOMappingMaster();
            }
            return frmReagentSupplierPOMappingMaster_Obj;
        }

        public void Bind_Supplier()
        {
            try
            {
                ReagentSupplierMaster_Class ReagentSupplierMaster_Class_obj = new ReagentSupplierMaster_Class();
                DataSet ds = new DataSet();
                DataRow dr;
                ds = ReagentSupplierMaster_Class_obj.Select_ReagentSupplierMaster();
                dr = ds.Tables[0].NewRow();
                dr["SupplierName"] = "--Select--";
                dr["ReAgentSupplierID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                CmbSupplier.DataSource = ds.Tables[0];
                CmbSupplier.DisplayMember = "SupplierName";
                CmbSupplier.ValueMember = "ReAgentSupplierID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmReagentSupplierPOMappingMaster_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            Bind_Supplier();
            Dgv.AutoGenerateColumns = false;
        }

        private void CmbSupplier_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CmbSupplier.SelectedValue != null && CmbSupplier.SelectedValue.ToString() != "" && CmbSupplier.SelectedIndex != 0)
            {
                Bind_BindGrid();
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                if (CmbSupplier.Text == "--Select--")
                {
                    MessageBox.Show("Select Supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbSupplier.Focus();
                    return;
                }

                if (txtPONumber.Text.Trim() == "")
                {
                    MessageBox.Show("Enter PO Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPONumber.Text = "";
                    txtPONumber.Focus();
                    return;
                }

                ReagentSupplierPONumber_Class_obj.reagentsupplierid = Convert.ToInt64(CmbSupplier.SelectedValue);
                ReagentSupplierPONumber_Class_obj.ponumber = txtPONumber.Text.Trim();
                ReagentSupplierPONumber_Class_obj.createdby = FrmMain.LoginID;
                ReagentSupplierPONumber_Class_obj.modifiedby = FrmMain.LoginID;
                ds = ReagentSupplierPONumber_Class_obj.Select_ReagentSupplierPONumber();
                if (ds.Tables[0].Rows.Count == 0)
                {
                    if (modify == false)
                    {
                        bool b = ReagentSupplierPONumber_Class_obj.Insert_ReagentSupplierPONumberMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPONumber.Text = "";
                            txtPONumber.Focus();
                            Bind_BindGrid();

                        }
                    }
                    else
                    {
                        if (ReagentSupplierPONumber_Class_obj.id != 0)
                        {
                            bool b = ReagentSupplierPONumber_Class_obj.Update_ReagentSupplierPONumberMaster();
                            if (b == true)
                            {
                                MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtPONumber.Text = "";
                                txtPONumber.Focus();
                                Bind_BindGrid();
                                ReagentSupplierPONumber_Class_obj.id = 0;
                            }
                            modify = false;
                        }
                        //ReagentSupplierMaster_Class_obj.reagentsuppliername = txtSupplierName.Text.Trim();
                        //ReagentSupplierMaster_Class_obj.reagentsupplierid = Convert.ToInt64(List.SelectedValue.ToString());
                        //bool b = ReagentSupplierMaster_Class_obj.Update_ReagentSupplierMaster();
                        //if (b == true)
                        //{
                        //    MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    txtSupplierName.Text = "";
                        //    txtSupplierName.Focus();
                        //    Bind_List();
                        //    modify = false;
                        //}
                    }
                }
                else
                {
                    MessageBox.Show("Record Already Exists.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPONumber.Focus();
                }

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPONumber.Focus();
            }
        }

        public void Bind_BindGrid()
        {
            try
            {
                ReagentSupplierPONumber_Class_obj.reagentsupplierid = Convert.ToInt64(CmbSupplier.SelectedValue);
                DataSet ds = new DataSet();
                ds = ReagentSupplierPONumber_Class_obj.Select_ReagentSupplierPONumberMaster_SupplierID();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Dgv.DataSource = ds.Tables[0];
                }
                else
                    Dgv.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CmbSupplier.SelectedIndex = 0;
            txtPONumber.Text = "";
            Dgv.DataSource = null;
            modify = false;
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex >= 0)
            {
                txtPONumber.Text = Dgv.Rows[e.RowIndex].Cells["PONumber"].Value.ToString();
                ReagentSupplierPONumber_Class_obj.id = Convert.ToInt64(Dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            }
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ReagentSupplierPONumber_Class_obj.id = Convert.ToInt64(Dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    ReagentSupplierPONumber_Class_obj.modifiedby = FrmMain.LoginID;
                    bool b = ReagentSupplierPONumber_Class_obj.Delete_tblReagentSupplierPONumberMappingMaster();
                    if (b == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bind_BindGrid();
                        modify = false;
                        ReagentSupplierPONumber_Class_obj.id = 0;
                    }
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            modify = true;
        }
    }
}