using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade.Transactions;
using BusinessFacade;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace QTMS.Transactions
{
    public partial class FrmReagentTransaction : Form
    {
        #region variables
        ReagentTransaction_Class ReagentTransaction_Class_obj = new ReagentTransaction_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        ReagentSupplierPONumber_Class ReagentSupplierPONumber_Class_obj = new ReagentSupplierPONumber_Class();
        bool modify = false;
        DataSet dsList = new DataSet();
        public string _LayoutFilePath = "";
        private string shairedpath;
        #endregion

        public FrmReagentTransaction()
        {
            InitializeComponent();
        }
        private static FrmReagentTransaction FrmReagentTransaction_Obj = null;
        internal static FrmReagentTransaction GetInstance()
        {
            if (FrmReagentTransaction_Obj == null)
            {
                FrmReagentTransaction_Obj = new Transactions.FrmReagentTransaction();
            }
            return FrmReagentTransaction_Obj;
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
            bind_NormalityUnit();
            bind_RACode();
            Bind_InspectedBy();
            Bind_PONumber();
            //bind_list();
            // cmbNormalityUnit.SelectedIndex = 0;

            shairedpath = ConfigurationManager.AppSettings["ReagentCOA"].ToString();

        }

        private void bind_list()
        {
            try
            {

                dsList = ReagentTransaction_Class_obj.Select_tblReagenMaster_tblReagentTransaction_RACode();
                if (dsList.Tables[0].Rows.Count > 0)
                {
                    //List.DataSource = dsList.Tables[0];
                    //List.DisplayMember = "RACode";
                    //List.ValueMember = "ReagentTransID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bind_RACode()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = ReagentTransaction_Class_obj.Select_tblReagent_RACode();
                dr = ds.Tables[0].NewRow();
                dr["RACode"] = "--Select--";
                dr["ReagentID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);


                cmbRACode.DataSource = ds.Tables[0];
                cmbRACode.DisplayMember = "RACode";
                cmbRACode.ValueMember = "ReagentID";


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
                ds = ReagentTransaction_Class_obj.Select_tblReagent_Unit();
                dr = ds.Tables[0].NewRow();
                dr["NormalityUnit"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                //cmbNormalityUnit .DataSource = ds.Tables[0];
                //cmbNormalityUnit.DisplayMember = "NormalityUnit";
                //cmbNormalityUnit.ValueMember = "NormalityUnitID";

                cmbUnit.DataSource = ds.Tables[0];
                cmbUnit.DisplayMember = "NormalityUnit";
                cmbUnit.ValueMember = "NormalityUnitID";


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_InspectedBy()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = UserManagement_Class_Obj.Select_AllUser();
            dr = ds.Tables[0].NewRow();
            dr["UserName"] = "--Select--";
            dr["UserID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbInspectedBy.DataSource = ds.Tables[0];
                cmbInspectedBy.DisplayMember = "UserName";
                cmbInspectedBy.ValueMember = "UserID";
            }
        }

        public void Bind_PONumber()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = ReagentSupplierPONumber_Class_obj.Select_PONumber_All();
            dr = ds.Tables[0].NewRow();
            dr["PONumber"] = "--Select--";
            dr["ID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbPONumber.DataSource = ds.Tables[0];
                CmbPONumber.DisplayMember = "PONumber";
                CmbPONumber.ValueMember = "ID";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbRACode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbRACode.SelectedValue != null && cmbRACode.SelectedValue.ToString() != "")
                {
                    ReagentTransaction_Class_obj.reagentid = Convert.ToInt32(cmbRACode.SelectedValue.ToString());
                    DataSet ds = new DataSet();
                    ds = ReagentTransaction_Class_obj.Select_tblReagentMaster_ReagentName();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtReagentName.Text = ds.Tables[0].Rows[0]["ReagentName"].ToString();
                        lblNormUnit.Text = ds.Tables[0].Rows[0]["NormalityUnit"].ToString();
                    }
                    else
                    {
                        txtReagentName.Text = lblNormUnit.Text = "";
                    }
                }
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
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connectionstring"]);

                #region Validation


                //Check for duplicate Lot No.
                /* old logic comment by Avinash S 14-Nov-2019
                DataSet dsLotNo = new DataSet();
                dsLotNo = ReagentTransaction_Class_obj.Check_tblReagenTransaction_lotNo();
                for (int i = 0; i < dsLotNo.Tables[0].Rows.Count; i++)
                {
                    if (txtLotNo.Text.Trim() == dsLotNo.Tables[0].Rows[i]["ReagentLotNo"].ToString())
                    {
                        MessageBox.Show("Lot No. Already Exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLotNo.Focus();
                        txtLotNo.Text = "";
                        return;
                    }
                }
                 */
                if (cmbRACode.SelectedValue == null || cmbRACode.Text == "--Select--")
                {
                    MessageBox.Show("Select RACode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRACode.Focus();
                    return;
                }
                if (txtReagentName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter RACode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReagentName.Focus();
                    return;

                }
                if (CmbPONumber.SelectedValue == null || CmbPONumber.Text == "--Select--")
                {
                    MessageBox.Show("Select PONumber", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbPONumber.Focus();
                    return;
                }
                if (txtSupplierName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Supplier Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierName.Focus();
                    return;

                }
                if (txtLotNo.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Lot No. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLotNo.Focus();
                    return;

                }
                if (dtpMfgDate.Checked == false)
                {
                    MessageBox.Show("Enter Mfg Date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpMfgDate.Focus();
                    return;

                }
                if (dtpValidityDate.Checked == false)
                {
                    MessageBox.Show("Enter Validity Date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpValidityDate.Focus();
                    return;

                }

                if (dtpTransDate.Checked == false)
                {
                    MessageBox.Show("Enter Receive Date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTransDate.Focus();
                    return;

                }

                if (txtQty.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQty.Focus();
                    return;

                }
                if (cmbUnit.SelectedValue == null || cmbUnit.Text == "--Select--")
                {
                    MessageBox.Show("Select Quantity Measurment Unit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbUnit.Focus();
                    return;
                }

                //if (txtNoOfUnits .Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter No.of Units", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtNoOfUnits.Focus();
                //    return;

                //}
                if (txtTotalQty.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Total Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTotalQty.Focus();
                    return;

                }
                if (txtNoOfUnits.Text.Trim() == "")
                {
                    MessageBox.Show("Enter No. of Units", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNoOfUnits.Focus();
                    return;

                }
                if (txtReagentNormality.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Reagent Normality", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReagentNormality.Focus();
                    return;

                }
                if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Select InsectedBy", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbInspectedBy.Focus();
                    return;
                }


                #endregion


                if (modify == false)
                {

                    // Insert Record
                    ReagentTransaction_Class_obj.suppliername = txtSupplierName.Text.Trim();
                    ReagentTransaction_Class_obj.reagentlotno = txtLotNo.Text.Trim();
                    ReagentTransaction_Class_obj.receivedate = Convert.ToDateTime(dtpTransDate.Text.Trim());
                    ReagentTransaction_Class_obj.qtyperunit = Convert.ToDouble(txtQty.Text.Trim());
                    ReagentTransaction_Class_obj.unit = cmbUnit.Text;
                    ReagentTransaction_Class_obj.numofunit = Convert.ToDouble(txtNoOfUnits.Text.Trim());
                    ReagentTransaction_Class_obj.totalqty = Convert.ToDouble(txtTotalQty.Text.Trim());
                    ReagentTransaction_Class_obj.reagentnormality = Convert.ToDouble(txtReagentNormality.Text.Trim());
                    ReagentTransaction_Class_obj.normalityunit = lblNormUnit.Text;
                    ReagentTransaction_Class_obj.loginid = FrmMain.LoginID;

                    ReagentTransaction_Class_obj.poid = Convert.ToInt64(CmbPONumber.SelectedValue);
                    ReagentTransaction_Class_obj.mfgdate = Convert.ToDateTime(dtpMfgDate.Text.Trim());
                    ReagentTransaction_Class_obj.validatedate = Convert.ToDateTime(dtpValidityDate.Text.Trim());
                    ReagentTransaction_Class_obj.comments = txtcomments.Text.Trim();
                    ReagentTransaction_Class_obj.inspectedby = Convert.ToInt64(cmbInspectedBy.SelectedValue);
                    ReagentTransaction_Class_obj.coafile = _LayoutFilePath;

                    DataSet DsCheckExists = new DataSet();
                    DsCheckExists = ReagentTransaction_Class_obj.CheckReagentTransaction_Exists();
                    if (DsCheckExists.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Transaction already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        BtnReset_Click(sender, e);
                        return;
                    }


                    int OutTransID = ReagentTransaction_Class_obj.Insert_tblReagentTransaction();


                    /* Transaction  */
                    // Using SQL TRansaction for commit & rollback

                    con.Open();
                    ReagentTransaction_Class_obj.trans = con.BeginTransaction();


                    //Insert into tblReagentBottle No. of bottles from one to Units 
                    //if there are 4 units then insert 1,2,3,4  no. of bottles in tblReagentBottle

                    long BottleCount = Convert.ToInt64(txtNoOfUnits.Text);
                    for (int BottleNo = 1; BottleNo <= BottleCount; BottleNo++)
                    {
                        ReagentTransaction_Class_obj.Insert_tblReagentBottle(BottleNo, OutTransID);
                    }

                    if (_LayoutFilePath != "")
                        ReagentTransaction_Class_obj.Insert_tblReagentCOAFile(OutTransID);

                    if (OutTransID > 0)
                    {


                        //  bind_list();

                        //MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (MessageBox.Show("Record Saved Successfully\n\nPrint Label?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            //display Print Label
                            QTMS.Reports_Forms.FrmReagentPrintLabel pro = new QTMS.Reports_Forms.FrmReagentPrintLabel("Reagent Print Label", OutTransID);
                            pro.ShowDialog();
                        }

                        BtnReset_Click(sender, e);


                    }



                }
                else
                {
                    //update record

                    ReagentTransaction_Class_obj.suppliername = txtSupplierName.Text;
                    ReagentTransaction_Class_obj.reagentlotno = txtLotNo.Text;
                    ReagentTransaction_Class_obj.receivedate = Convert.ToDateTime(dtpTransDate.Text);
                    ReagentTransaction_Class_obj.qtyperunit = Convert.ToDouble(txtQty.Text);
                    ReagentTransaction_Class_obj.unit = cmbUnit.Text;
                    ReagentTransaction_Class_obj.numofunit = Convert.ToDouble(txtNoOfUnits.Text);
                    ReagentTransaction_Class_obj.totalqty = Convert.ToDouble(txtTotalQty.Text);
                    ReagentTransaction_Class_obj.reagentnormality = Convert.ToDouble(txtReagentNormality.Text);
                    ReagentTransaction_Class_obj.normalityunit = lblNormUnit.Text;
                    ReagentTransaction_Class_obj.loginid = FrmMain.LoginID;

                    bool status = ReagentTransaction_Class_obj.Update_tblReagentTransaction();
                    if (status == true)
                    {
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //  bind_list();
                        modify = false;
                        ReagentTransaction_Class_obj.trans.Commit();
                        BtnReset_Click(sender, e);
                    }

                }

            }
            catch (Exception ex)
            {
                // MessageBox.Show("Exception Occured..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReagentTransaction_Class_obj.trans.Rollback();
                MessageBox.Show(ex.Message);

            }
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    // select record from list on double click
            //    modify = true;
            //    DataSet ds = new DataSet();
            //    ReagentTransaction_Class_obj.reagenttransid = Convert.ToInt64(List.SelectedValue.ToString());
            //    ds = ReagentTransaction_Class_obj.Select_tblReagentTransaction_Details();
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        //  txtSearch.Text = Convert.ToString(LstTest.Text);


            //        txtSupplierName.Text = ds.Tables[0].Rows[0]["SupplierName"].ToString();  
            //        txtLotNo.Text = ds.Tables[0].Rows[0]["ReagentLotNo"].ToString();  
            //        dtpTransDate.Text = ds.Tables[0].Rows[0]["ReceiveDate"].ToString();  
            //        txtQty.Text = ds.Tables[0].Rows[0]["QtyPerUnit"].ToString();  
            //        cmbUnit.Text = ds.Tables[0].Rows[0]["Unit"].ToString();  
            //        txtNoOfUnits.Text = ds.Tables[0].Rows[0]["NumOfUnit"].ToString();  
            //        txtTotalQty.Text = ds.Tables[0].Rows[0]["TotalQty"].ToString();  
            //        txtReagentNormality.Text = ds.Tables[0].Rows[0]["ReagentNormality"].ToString();  
            //        cmbNormalityUnit.Text = ds.Tables[0].Rows[0]["NormalityUnit"].ToString();  
            //        cmbRACode.Text = ds.Tables[0].Rows[0]["RACode"].ToString(); 
            //        txtReagentName.Text = ds.Tables[0].Rows[0]["ReagentName"].ToString(); 


            //        BtnDelete.Enabled = true;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // bind_list();
            bind_NormalityUnit();
            bind_RACode();
            txtSupplierName.Text = "";
            txtLotNo.Text = "";
            dtpTransDate.Text = "";
            txtQty.Text = "";
            txtNoOfUnits.Text = "";
            txtTotalQty.Text = "";
            txtReagentNormality.Text = "";

            lblNormUnit.Text = "";
            txtReagentName.Text = "";

            CmbPONumber.Text = "--Select--";
            dtpMfgDate.Text = "";
            dtpValidityDate.Text = "";
            lblFileName.Text = "";
            _LayoutFilePath = "";
            lnlviewfile.Visible = false;
            txtcomments.Text = "";
            cmbInspectedBy.Text = "--Select--";
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            modify = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // search code -- searches on dataset which is common for list 
            //string searchString = txtSearch.Text;
            //dsList.Tables[0].DefaultView.RowFilter = "RACode like  '" + searchString + "%'    ";


            //List.DataSource = dsList.Tables[0];

            //List.DisplayMember = "RACode";
            //List.ValueMember = "ReagentTransID";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // on ENTER 
                if (e.KeyChar == 13)
                {
                    // select record from list on double click
                    modify = true;
                    DataSet ds = new DataSet();
                    //ReagentTransaction_Class_obj.reagenttransid = Convert.ToInt64(List.SelectedValue.ToString());
                    ds = ReagentTransaction_Class_obj.Select_tblReagentTransaction_Details();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //txtSearch.Text = Convert.ToString(List.Text);


                        txtSupplierName.Text = ds.Tables[0].Rows[0]["SupplierName"].ToString();
                        txtLotNo.Text = ds.Tables[0].Rows[0]["ReagentLotNo"].ToString();
                        dtpTransDate.Text = ds.Tables[0].Rows[0]["ReceiveDate"].ToString();
                        txtQty.Text = ds.Tables[0].Rows[0]["QtyPerUnit"].ToString();
                        cmbUnit.Text = ds.Tables[0].Rows[0]["Unit"].ToString();
                        txtNoOfUnits.Text = ds.Tables[0].Rows[0]["NumOfUnit"].ToString();
                        txtTotalQty.Text = ds.Tables[0].Rows[0]["TotalQty"].ToString();
                        txtReagentNormality.Text = ds.Tables[0].Rows[0]["ReagentNormality"].ToString();
                        //  cmbNormalityUnit.Text = ds.Tables[0].Rows[0]["NormalityUnit"].ToString();
                        cmbRACode.Text = ds.Tables[0].Rows[0]["RACode"].ToString();
                        txtReagentName.Text = ds.Tables[0].Rows[0]["ReagentName"].ToString();


                        //BtnDelete.Enabled = true;
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
                    //List.Select();
                    //List.SelectedIndex = List.SelectedIndex + 1;
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
                    //List.Select();
                    //List.SelectedIndex = List.SelectedIndex - 1;
                }
            }
            catch (ArgumentOutOfRangeException exAOR)
            {

                MessageBox.Show("This is last item", "QTMS");
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            //txtSearch.SelectAll();
        }

        private void List_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // on ENTER 
                if (e.KeyChar == 13)
                {
                    // select record from list on double click
                    // modify = true;
                    DataSet ds = new DataSet();
                    //ReagentTransaction_Class_obj.reagenttransid = Convert.ToInt64(List.SelectedValue.ToString());
                    ds = ReagentTransaction_Class_obj.Select_tblReagentTransaction_Details();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //txtSearch.Text = Convert.ToString(List.Text);


                        txtSupplierName.Text = ds.Tables[0].Rows[0]["SupplierName"].ToString();
                        txtLotNo.Text = ds.Tables[0].Rows[0]["ReagentLotNo"].ToString();
                        dtpTransDate.Text = ds.Tables[0].Rows[0]["ReceiveDate"].ToString();
                        txtQty.Text = ds.Tables[0].Rows[0]["QtyPerUnit"].ToString();
                        cmbUnit.Text = ds.Tables[0].Rows[0]["Unit"].ToString();
                        txtNoOfUnits.Text = ds.Tables[0].Rows[0]["NumOfUnit"].ToString();
                        txtTotalQty.Text = ds.Tables[0].Rows[0]["TotalQty"].ToString();
                        txtReagentNormality.Text = ds.Tables[0].Rows[0]["ReagentNormality"].ToString();
                        lblNormUnit.Text = ds.Tables[0].Rows[0]["NormalityUnit"].ToString();
                        cmbRACode.Text = ds.Tables[0].Rows[0]["RACode"].ToString();
                        txtReagentName.Text = ds.Tables[0].Rows[0]["ReagentName"].ToString();


                        //BtnDelete.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtNoOfUnits_TextChanged(object sender, EventArgs e)
        {
            double qty;
            double noOfUnits;

            if (txtQty.Text != "" && txtNoOfUnits.Text != "")
            {

                qty = double.Parse(txtQty.Text);
                noOfUnits = double.Parse(txtNoOfUnits.Text);
                double total = qty * noOfUnits;
                txtTotalQty.Text = Convert.ToString(total);

            }
            else
            {
                txtTotalQty.Text = "";
            }


        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                  e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
            //if (e.KeyChar ==46)
            //{
            //    e.Handled = false ;
            //}
        }

        private void txtNoOfUnits_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                  e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
            //if (e.KeyChar ==46)
            //{
            //    e.Handled = false ;
            //}
        }

        private void txtNoOfUnits_Enter(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
            {

                MessageBox.Show("Select Quantity Per Unit", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQty.Focus();
                return;
            }
        }

        private void dtpTransDate_Leave(object sender, EventArgs e)
        {
            /*
            if (dtpTransDate.Checked == true)
            {
                //date validation 
                //date range allow is today to 6 days backwords
                //get date enterd by user
                DateTime Recivedt = new DateTime();
                Recivedt = Convert.ToDateTime(dtpTransDate.Text);

                //get current date
                DateTime dt1;
                dt1 = new DateTime();
                DateTime dt2 = new DateTime();

                dt1 = DateTime.Now.Date;
                //date before 6 days
                dt2 = dt1.AddDays(-6);
                //check date validation
                if (Recivedt.Date < dt2 || Recivedt.Date > dt1)
                {
                    MessageBox.Show("Date range must be from  '" + Convert.ToString(dt1.Date.AddDays(-6).ToString("dd-MMM-yyyy")) + "'" + " To " + " '" + dt1.Date.ToString("dd-MMM-yyyy") + "'  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTransDate.Checked = false;
                    dtpTransDate.Focus();
                    return;

                }
            }
             */
        }

        private void txtReagentNormality_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                  e.KeyChar != 13 &&
                 e.KeyChar != 9 && e.KeyChar != 46)
            {

                e.Handled = true;

            }
            //if (e.KeyChar ==46)
            //{
            //    e.Handled = false ;
            //}

        }

        private void txtReagentNormality_Leave(object sender, EventArgs e)
        {
            //if (txtReagentNormality.Text != "" && Convert.ToDouble(txtReagentNormality.Text) > 10)
            //{
            //    MessageBox.Show("Normality unit must be between 0 to 10", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (txtQty.Text != "" && Convert.ToDouble(txtQty.Text) > 10000)
            {
                MessageBox.Show("Normality unit must be less than 10000", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            double qty;
            double noOfUnits;

            if (txtNoOfUnits.Text == "" && txtQty.Text != "")
            {

                noOfUnits = 0;
                qty = double.Parse(txtQty.Text);
                double total = qty * noOfUnits;
                txtTotalQty.Text = Convert.ToString(total);

            }
            else
            {
                if (txtQty.Text != "")
                {
                    qty = double.Parse(txtQty.Text);
                    noOfUnits = double.Parse(txtNoOfUnits.Text);
                    double total = qty * noOfUnits;
                    txtTotalQty.Text = Convert.ToString(total);
                }
                else
                {
                    txtTotalQty.Text = "";
                }

            }
        }

        private void CmbPONumber_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (CmbPONumber.SelectedValue != null && CmbPONumber.SelectedValue.ToString() != "")
                {
                    ReagentSupplierPONumber_Class_obj.id = Convert.ToInt32(CmbPONumber.SelectedValue.ToString());
                    DataSet ds = new DataSet();
                    ds = ReagentSupplierPONumber_Class_obj.Select_SupplierName_ByPONumber();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtSupplierName.Text = ds.Tables[0].Rows[0]["SupplierName"].ToString();
                    }
                    else
                        txtSupplierName.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUploadCOA_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialogCOA.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // result.
                {
                    _LayoutFilePath = string.Empty;
                    if (!(System.IO.Path.GetExtension(openFileDialogCOA.FileName) == ".pdf"))
                    {
                        //MessageBox.Show("Please select valid jpg, jpeg, png file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show("Please select valid pdf file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(shairedpath))
                            System.IO.Directory.CreateDirectory(shairedpath);
                        if (!System.IO.Directory.Exists(shairedpath + "\\COA\\"))
                            System.IO.Directory.CreateDirectory(shairedpath + "\\COA\\");
                        lblFileName.Text = System.IO.Path.GetFileName(openFileDialogCOA.FileName);
                        File.Copy(openFileDialogCOA.FileName, shairedpath + "\\COA\\" + System.IO.Path.GetFileName(openFileDialogCOA.FileName), true);
                        _LayoutFilePath = shairedpath + "\\COA\\" + System.IO.Path.GetFileName(openFileDialogCOA.FileName);
                        MessageBox.Show("COA file upload successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void txtLotNo_Leave(object sender, EventArgs e)
        {
            if (cmbRACode.SelectedValue == null || cmbRACode.Text == "--Select--")
            {
                MessageBox.Show("Select RACode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRACode.Focus();
                txtLotNo.Text = "";
                return;
            }

            //Check for duplicate Lot No.

            DataSet dsLotNo = new DataSet();
            dsLotNo = ReagentTransaction_Class_obj.Check_LotNumber(txtLotNo.Text.Trim());
            for (int i = 0; i < dsLotNo.Tables[0].Rows.Count; i++)
            {
                if (Convert.ToInt64(cmbRACode.SelectedValue) != Convert.ToInt64(dsLotNo.Tables[0].Rows[i]["ReagentID"].ToString()))
                {
                    MessageBox.Show("Lot No. Already Exist! for another RA Code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLotNo.Focus();
                    txtLotNo.Text = ""; lnlviewfile.Visible = false;
                    return;
                }
            }

            if (dsLotNo.Tables[1].Rows.Count > 0)
            {
                _LayoutFilePath = dsLotNo.Tables[1].Rows[0]["COAFile"].ToString();
                lblFileName.Text = System.IO.Path.GetFileName(dsLotNo.Tables[1].Rows[0]["COAFile"].ToString());
                lnlviewfile.Visible = true;
            }
            else
                lnlviewfile.Visible = false;
        }

        private void lnlviewfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_LayoutFilePath != "")
                Process.Start(_LayoutFilePath);
        }
    }
}