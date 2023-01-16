using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;

namespace QTMS.Forms
{
    public partial class FrmReagentMaster : Form
    {
        #region variables
        ReagentMaster_Class ReagentMaster_Class_obj = new ReagentMaster_Class();
        SafetySymbol_Class SafetySymbol_Class_obj = new SafetySymbol_Class();
        bool modify = false;
        DataSet dsList = new DataSet();
        string safetysymbol = "";
        #endregion

        public FrmReagentMaster()
        {
            InitializeComponent();
        }
        private static FrmReagentMaster FrmReagentMaster_Obj = null;
        internal static FrmReagentMaster GetInstance()
        {
            if (FrmReagentMaster_Obj == null)
            {
                FrmReagentMaster_Obj = new Forms.FrmReagentMaster();
            }
            return FrmReagentMaster_Obj;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReagentMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);
            bind_list();
            //  bind_NormalityUnit();
            cmbNormalityUnit.SelectedIndex = 0;
            btnModify.Enabled = false;
            Bind_SaftySymbols();
        }

        public void Bind_SaftySymbols()
        {
            DataRow dr;
            DataSet ds = new DataSet();


            ds = SafetySymbol_Class_obj.Select_SafetySymbol_symb();

            if (ds.Tables[0].Rows.Count > 0)
            {

                checklistSafetysymbol.DataSource = ds.Tables[0];

                checklistSafetysymbol.DisplayMember = "Safetysign";
                checklistSafetysymbol.ValueMember = "SymID";
                checklistSafetysymbol.Text = "select";
            }
        }

        private void bind_list()
        {
            try
            {

                dsList = ReagentMaster_Class_obj.Select_tblReagenMaster_RACode();
                if (dsList.Tables[0].Rows.Count > 0)
                {
                    List.DataSource = dsList.Tables[0];
                    List.DisplayMember = "RACode";
                    List.ValueMember = "ReagentID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bind_NormalityUnit()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = ReagentMaster_Class_obj.Select_tblReagent_Normality();
                dr = ds.Tables[0].NewRow();
                dr["NormalityUnit"] = "--Select--";
                dr["NormalityUnitID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cmbNormalityUnit.DataSource = ds.Tables[0];
                cmbNormalityUnit.DisplayMember = "NormalityUnit";
                cmbNormalityUnit.ValueMember = "NormalityUnitID";


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRACode.Text.Trim() == "")
                {
                    MessageBox.Show("Enter RACode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRACode.Focus();
                    return;

                }
                if (txtReagentName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Reagent Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReagentName.Focus();
                    return;

                }
                if (txtReorderLevel.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Reorder Level", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReorderLevel.Focus();
                    return;

                }
                if (cmbNormalityUnit.SelectedIndex == 0)
                {
                    MessageBox.Show("Select Normality Unit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbNormalityUnit.Focus();
                    return;
                }

                safetysymbol = "";
                for (int i = 0; i < checklistSafetysymbol.Items.Count; i++)
                {
                    if (checklistSafetysymbol.GetItemCheckState(i) == CheckState.Checked)
                    {
                        safetysymbol += checklistSafetysymbol.GetItemText(checklistSafetysymbol.Items[i]) + ",";
                    }
                }
                safetysymbol = safetysymbol.TrimEnd(',');
                ReagentMaster_Class_obj.symb = safetysymbol;

                if (modify == false)
                {

                    //Check for duplicate RACode
                    DataSet dsRACode = new DataSet();
                    dsRACode = ReagentMaster_Class_obj.Select_tblReagenMaster_RACode();
                    for (int i = 0; i < dsRACode.Tables[0].Rows.Count; i++)
                    {
                        if (txtRACode.Text.Trim().ToUpper() == dsRACode.Tables[0].Rows[i]["RACode"].ToString().ToUpper())
                        {
                            MessageBox.Show("RACode Already Exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtRACode.Focus();
                            txtRACode.Text = "";
                            return;
                        }
                    }

                    // Insert Record
                    ReagentMaster_Class_obj.racode = txtRACode.Text.ToString().Trim();
                    ReagentMaster_Class_obj.reagentname = txtReagentName.Text.ToString().Trim();
                    ReagentMaster_Class_obj.reorderlevel = Convert.ToInt32(txtReorderLevel.Text.ToString().Trim());
                    ReagentMaster_Class_obj.normalityunit = cmbNormalityUnit.Text;
                    ReagentMaster_Class_obj.loginid = FrmMain.LoginID;
                    bool status = ReagentMaster_Class_obj.Insert_tblReagentMaster();
                    if (status == true)
                    {
                        bind_list();
                        BtnReset_Click(sender, e);
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }



                }
                else
                {
                    //update record
                    ReagentMaster_Class_obj.racode = txtRACode.Text.ToString().Trim();
                    ReagentMaster_Class_obj.reagentname = txtReagentName.Text.ToString().Trim();
                    ReagentMaster_Class_obj.reorderlevel = Convert.ToInt32(txtReorderLevel.Text.ToString().Trim());
                    ReagentMaster_Class_obj.normalityunit = cmbNormalityUnit.Text;
                    ReagentMaster_Class_obj.loginid = FrmMain.LoginID;


                    bool status = ReagentMaster_Class_obj.Update_tblReagentMaster();
                    if (status == true)
                    {
                        MessageBox.Show("Record Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        modify = false;
                        BtnReset_Click(sender, e);
                    }

                }

            }
            catch
            {
                MessageBox.Show("RACode already exists..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRACode.Text = "";
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtRACode.Text = "";
            BtnDelete.Enabled = false;
            btnModify.Enabled = false;
            txtReagentName.Text = "";
            txtReorderLevel.Text = "";
            cmbNormalityUnit.SelectedIndex = 0;
            bind_list();
            modify = false;
            for (int i = 0; i < checklistSafetysymbol.Items.Count; i++)
            {
                if (checklistSafetysymbol.GetItemCheckState(i) == CheckState.Checked)
                {
                    checklistSafetysymbol.SetItemChecked(i, false);
                }
            }
            checklistSafetysymbol.ClearSelected();
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // select record from list on double click
                // modify = true;
                DataSet ds = new DataSet();
                ReagentMaster_Class_obj.reagentid = Convert.ToInt64(List.SelectedValue.ToString());
                ds = ReagentMaster_Class_obj.Select_tblReagentMaster_Details();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //  txtSearch.Text = Convert.ToString(LstTest.Text);
                    txtRACode.Text = ds.Tables[0].Rows[0]["RACode"].ToString();
                    txtReagentName.Text = ds.Tables[0].Rows[0]["ReagentName"].ToString();
                    txtReorderLevel.Text = ds.Tables[0].Rows[0]["ReorderLevel"].ToString();
                    cmbNormalityUnit.Text = ds.Tables[0].Rows[0]["NormalityUnit"].ToString();


                    string symb = ds.Tables[0].Rows[0]["Symb"].ToString(); //dataGridView1["Symb", e.RowIndex].Value.ToString();

                    string[] symb1 = symb.Split(',');

                    for (int i = 0; i < checklistSafetysymbol.Items.Count; i++)
                    {
                        for (int j = 0; j < symb1.Length; j++)
                        {
                            if (checklistSafetysymbol.GetItemText(checklistSafetysymbol.Items[i]) == symb1[j].ToString())
                                checklistSafetysymbol.SetItemChecked(i, true);
                        }
                    }


                    BtnDelete.Enabled = true;
                    btnModify.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Please Select/Enter RACode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // if count is greater than zero then transaction occured then do not delete
                    DataSet dsCheckCount = new DataSet();
                    long ReagentID = Convert.ToInt64(List.SelectedValue.ToString());
                    dsCheckCount = ReagentMaster_Class_obj.Check_Transaction_Count(ReagentID);

                    if (Convert.ToInt32(dsCheckCount.Tables[0].Rows[0][0].ToString()) > 0)
                    {
                        MessageBox.Show("You can not delete RACode.This is used in Transaction !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool status = ReagentMaster_Class_obj.Delete_Selected_Record();
                        if (status == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        BtnReset_Click(sender, e);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // search code -- searches on dataset which is common for list 
            string searchString = txtSearch.Text;
            dsList.Tables[0].DefaultView.RowFilter = "RACode like  '" + searchString + "%'    ";


            List.DataSource = dsList.Tables[0];

            List.DisplayMember = "RACode";
            List.ValueMember = "ReagentID";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // on ENTER 
                if (e.KeyChar == 13)
                {
                    modify = true;
                    DataSet ds = new DataSet();
                    ReagentMaster_Class_obj.reagentid = Convert.ToInt64(List.SelectedValue.ToString());
                    ds = ReagentMaster_Class_obj.Select_tblReagentMaster_Details();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //  txtSearch.Text = Convert.ToString(LstTest.Text);
                        txtRACode.Text = ds.Tables[0].Rows[0]["RACode"].ToString();
                        txtReagentName.Text = ds.Tables[0].Rows[0]["ReagentName"].ToString();
                        txtReorderLevel.Text = ds.Tables[0].Rows[0]["ReorderLevel"].ToString();
                        cmbNormalityUnit.Text = ds.Tables[0].Rows[0]["NormalityUnit"].ToString();


                        BtnDelete.Enabled = true;
                        btnModify.Enabled = true;
                    }

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

                MessageBox.Show("This is last item", "QTMS");
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void List_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    modify = true;
                    DataSet ds = new DataSet();
                    ReagentMaster_Class_obj.reagentid = Convert.ToInt64(List.SelectedValue.ToString());
                    ds = ReagentMaster_Class_obj.Select_tblReagentMaster_Details();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //  txtSearch.Text = Convert.ToString(LstTest.Text);
                        txtRACode.Text = ds.Tables[0].Rows[0]["RACode"].ToString();
                        txtReagentName.Text = ds.Tables[0].Rows[0]["ReagentName"].ToString();
                        txtReorderLevel.Text = ds.Tables[0].Rows[0]["ReorderLevel"].ToString();
                        cmbNormalityUnit.Text = ds.Tables[0].Rows[0]["NormalityUnit"].ToString();


                        BtnDelete.Enabled = true;
                        btnModify.Enabled = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtReorderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                  e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            modify = true;
        }
    }
}