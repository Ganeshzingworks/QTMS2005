using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade.Transactions;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace QTMS.Transactions
{
    public partial class FrmReagentModification : Form
    {
        #region variables
        ReagentTransaction_Class ReagentTransaction_Class_obj = new ReagentTransaction_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        bool modify = false;
        DataSet dsList = new DataSet();
        public string _LayoutFilePath = "";
        private string shairedpath;
        #endregion

        public FrmReagentModification()
        {
            InitializeComponent();
        }
        private static FrmReagentModification FrmReagentModification_Obj = null;
        internal static FrmReagentModification GetInstance()
        {
            if (FrmReagentModification_Obj == null)
            {
                FrmReagentModification_Obj = new Transactions.FrmReagentModification();
            }
            return FrmReagentModification_Obj;
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

            Bind_Details();
            Bind_InspectedBy();
            bind_NormalityUnit();

            btnDelete.Enabled = false;
            //bind_list();
            // cmbNormalityUnit.SelectedIndex = 0;
            shairedpath = ConfigurationManager.AppSettings["ReagentCOA"].ToString();

        }

        public void Bind_Details()
        {
            CmbDetails.BeginUpdate();
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                //those for which Kitflag is 1 
                ds = ReagentTransaction_Class_obj.Select_ModificationReagentTransaction();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                CmbDetails.DataSource = ds.Tables[0];
                CmbDetails.DisplayMember = "Details";
                CmbDetails.ValueMember = "ReagentTransID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CmbDetails.EndUpdate();
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



        //private void bind_list()
        //{
        //    try
        //    {

        //        dsList = ReagentTransaction_Class_obj.Select_tblReagenMaster_tblReagentTransaction_RACode();
        //        if (dsList.Tables[0].Rows.Count > 0)
        //        {
        //            List.DataSource = dsList.Tables[0];
        //            List.DisplayMember = "RACode";
        //            List.ValueMember = "ReagentTransID";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}



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



        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["connectionstring"]);
                /* Transaction  */
                // Using SQL TRansaction for commit & rollback

                con.Open();
                ReagentTransaction_Class_obj.trans = con.BeginTransaction();

                #region validation

                if (CmbDetails.SelectedValue == null || CmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Select Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbDetails.Focus();
                    return;
                }

                if (txtReagentName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Reagent Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReagentName.Focus();
                    return;

                }

                if (txtSupplierName.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Supplier Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierName.Focus();
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

                if (txtNoOfUnits.Text.Trim() == "")
                {
                    MessageBox.Show("Enter No. of Units", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNoOfUnits.Focus();
                    return;

                }
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
                    MessageBox.Show("Enter Normality Unit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReagentNormality.Focus();
                    return;

                }
                if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Select InspectedBy", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbInspectedBy.Focus();
                    return;
                }
                #endregion

                ReagentTransaction_Class_obj.loginid = FrmMain.LoginID;
                //if (modify == false  )
                //{  
                //  //Check for duplicate RACode

                //}
                //else
                //{
                // select total no of bottles insearted 
                // get previous bottle count
                int NumOfUnits = Convert.ToInt32(txtNoOfUnits.Text);
                DataSet dsBottleCount = new DataSet();
                int transID = Convert.ToInt32(CmbDetails.SelectedValue.ToString());
                dsBottleCount = ReagentTransaction_Class_obj.GetBottleCOunt(transID);
                // if bottles r greater than previous 
                //Insert into tblReagentBottle No. of bottles from one to Units 
                //if there are 4 units then insert 5,6,7  no. of bottles in tblReagentBottle
                int previousbottleCount = Convert.ToInt32(dsBottleCount.Tables[0].Rows[0][0].ToString());


                if (NumOfUnits > previousbottleCount)
                {
                    // update transaction table with num of units
                    ReagentTransaction_Class_obj.UpdateNumOfBottle(NumOfUnits, transID);

                    for (int BottleNo = previousbottleCount + 1; BottleNo <= NumOfUnits; BottleNo++)
                    {
                        // insert remaining bottles
                        ReagentTransaction_Class_obj.Insert_tblReagentBottle(BottleNo, transID);
                    }
                }
                //if number of count is less than previous bottle then 
                //check bottles are standerdise or consumed - if yes then 
                //give message bottle units cant be updated
                //else update eith new bottle
                if (NumOfUnits < Convert.ToInt32(dsBottleCount.Tables[0].Rows[0][0].ToString()))
                {
                    //Not requried with new requriment remove standration form. Avinash S 19-Nov-2019

                    ////DataSet dsStdCount = new DataSet();
                    ////// get standerdise bottle count
                    ////dsStdCount = ReagentTransaction_Class_obj.GetStdCOunt(transID);
                    ////int StdCount = Convert.ToInt32(dsStdCount.Tables[0].Rows[0][0].ToString());
                    ////if (StdCount > 0)
                    ////{
                    ////    MessageBox.Show("You can not modify No.of Units ,they are Standardise/Consumed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ////    return;
                    ////}
                    ////else
                    {
                        //update tblReagentbottle
                        bool deleteFlag = ReagentTransaction_Class_obj.Delete_NonStd_ByTransID(transID);

                        if (deleteFlag == true)
                        {
                            int BottleCount = Convert.ToInt32(txtNoOfUnits.Text);
                            // update transaction table with num of units
                            ReagentTransaction_Class_obj.UpdateNumOfBottle(BottleCount, transID);

                            for (int BottleNo = 1; BottleNo <= BottleCount; BottleNo++)
                            {
                                ReagentTransaction_Class_obj.Insert_tblReagentBottle(BottleNo, transID);
                            }
                        }
                    }

                }

                ReagentTransaction_Class_obj.coafile = _LayoutFilePath;
                if (_LayoutFilePath != "")
                    ReagentTransaction_Class_obj.Insert_tblReagentCOAFile(ReagentTransaction_Class_obj.reagenttransid);

                //update record

                ReagentTransaction_Class_obj.mfgdate = Convert.ToDateTime(dtpMfgDate.Value);
                ReagentTransaction_Class_obj.validatedate = Convert.ToDateTime(dtpValidityDate.Value);
                ReagentTransaction_Class_obj.inspectedby = Convert.ToInt64(cmbInspectedBy.SelectedValue);
                ReagentTransaction_Class_obj.comments = txtcomments.Text.Trim();

                ReagentTransaction_Class_obj.suppliername = txtSupplierName.Text.Trim();
                //ReagentTransaction_Class_obj.reagentlotno = cmbLotNos.Text.Trim();
                //ReagentTransaction_Class_obj.receivedate = Convert.ToDateTime(dtpTransDate.Text.Trim());
                ReagentTransaction_Class_obj.qtyperunit = Convert.ToDouble(txtQty.Text.Trim());
                ReagentTransaction_Class_obj.unit = cmbUnit.Text;
                ReagentTransaction_Class_obj.numofunit = Convert.ToDouble(txtNoOfUnits.Text);
                ReagentTransaction_Class_obj.totalqty = Convert.ToDouble(txtTotalQty.Text);
                ReagentTransaction_Class_obj.reagentnormality = Convert.ToInt32(txtReagentNormality.Text.Trim());
                ReagentTransaction_Class_obj.normalityunit = txtNormalityUnit.Text;
                

                bool status = ReagentTransaction_Class_obj.Update_tblReagentTransaction();
                if (status == true)
                {
                    MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ReagentTransaction_Class_obj.trans.Commit();
                    modify = false;
                    BtnReset_Click(sender, e);
                }


                // }

            }
            catch (Exception ex)
            {
                ReagentTransaction_Class_obj.trans.Rollback();
                MessageBox.Show(ex.Message);

            }
        }


        private void cmbLotNos_SelectionChangeCommitted(object sender, EventArgs e)
        {

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
            //bind_NormalityUnit();

            txtSupplierName.Text = "";


            txtQty.Text = "";
            txtNoOfUnits.Text = "";
            txtTotalQty.Text = "";
            txtReagentNormality.Text = "";
            txtReagentName.Text = "";

            dtpMfgDate.Text = "";
            dtpValidityDate.Text = "";
            lblFileName.Text = "";
            _LayoutFilePath = "";
            lnlviewfile.Visible = false;
            txtcomments.Text = "";
            cmbInspectedBy.Text = "--Select--";
            CmbDetails.Text = "--Select--";
            cmbUnit.SelectedIndex = 0;
            txtNormalityUnit.Text = "";
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //modify = true;
        }

        //private void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    // search code -- searches on dataset which is common for list 
        //    string searchString = txtSearch.Text;
        //    dsList.Tables[0].DefaultView.RowFilter = "RACode like  '" + searchString + "%'    ";


        //    List.DataSource = dsList.Tables[0];

        //    List.DisplayMember = "RACode";
        //    List.ValueMember = "ReagentTransID";
        //}

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    // on ENTER 
            //    if (e.KeyChar == 13)
            //    {
            //        // select record from list on double click
            //        modify = true;
            //        DataSet ds = new DataSet();
            //        ReagentTransaction_Class_obj.reagenttransid = Convert.ToInt64(List.SelectedValue.ToString());
            //        ds = ReagentTransaction_Class_obj.Select_tblReagentTransaction_Details();
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            txtSearch.Text = Convert.ToString(List.Text);


            //            txtSupplierName.Text = ds.Tables[0].Rows[0]["SupplierName"].ToString();
            //            cmbLotNos.Text = ds.Tables[0].Rows[0]["ReagentLotNo"].ToString();
            //            dtpTransDate.Text = ds.Tables[0].Rows[0]["ReceiveDate"].ToString();
            //            txtQty.Text = ds.Tables[0].Rows[0]["QtyPerUnit"].ToString();
            //            cmbUnit.Text = ds.Tables[0].Rows[0]["Unit"].ToString();
            //            txtNoOfUnits.Text = ds.Tables[0].Rows[0]["NumOfUnit"].ToString();
            //            txtTotalQty.Text = ds.Tables[0].Rows[0]["TotalQty"].ToString();
            //            txtReagentNormality.Text = ds.Tables[0].Rows[0]["ReagentNormality"].ToString();
            //          //  cmbNormalityUnit.Text = ds.Tables[0].Rows[0]["NormalityUnit"].ToString();
            //            cmbRACode.Text = ds.Tables[0].Rows[0]["RACode"].ToString();
            //            txtReagentName.Text = ds.Tables[0].Rows[0]["ReagentName"].ToString();


            //            BtnDelete.Enabled = true;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Down)
            //    {
            //        List.Select();
            //        List.SelectedIndex = List.SelectedIndex + 1;
            //    }
            //}
            //catch (ArgumentOutOfRangeException exAOR)
            //{

            //    MessageBox.Show("This is last item", "QTMS");
            //}
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Up)
            //    {
            //        List.Select();
            //        List.SelectedIndex = List.SelectedIndex - 1;
            //    }
            //}
            //catch (ArgumentOutOfRangeException exAOR)
            //{

            //    MessageBox.Show("This is last item", "QTMS");
            //}
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            //txtSearch.SelectAll();
        }

        //private void List_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    try
        //    {
        //        // on ENTER 
        //        if (e.KeyChar == 13)
        //        {
        //            // select record from list on double click
        //            modify = true;
        //            DataSet ds = new DataSet();
        //            ReagentTransaction_Class_obj.reagenttransid = Convert.ToInt64(List.SelectedValue.ToString());
        //            ds = ReagentTransaction_Class_obj.Select_tblReagentTransaction_Details();
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                txtSearch.Text = Convert.ToString(List.Text);


        //                txtSupplierName.Text = ds.Tables[0].Rows[0]["SupplierName"].ToString();
        //              //  cmbLotNos.Text = ds.Tables[0].Rows[0]["ReagentLotNo"].ToString();
        //                dtpTransDate.Text = ds.Tables[0].Rows[0]["ReceiveDate"].ToString();
        //                txtQty.Text = ds.Tables[0].Rows[0]["QtyPerUnit"].ToString();
        //                cmbUnit.Text = ds.Tables[0].Rows[0]["Unit"].ToString();
        //                txtNoOfUnits.Text = ds.Tables[0].Rows[0]["NumOfUnit"].ToString();
        //                txtTotalQty.Text = ds.Tables[0].Rows[0]["TotalQty"].ToString();
        //                txtReagentNormality.Text = ds.Tables[0].Rows[0]["ReagentNormality"].ToString();
        //                cmbNormalityUnit.Text = ds.Tables[0].Rows[0]["NormalityUnit"].ToString();
        //                cmbRACode.Text = ds.Tables[0].Rows[0]["RACode"].ToString();
        //                txtReagentName.Text = ds.Tables[0].Rows[0]["ReagentName"].ToString();


        //                BtnDelete.Enabled = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

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



        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (txtQty.Text != "" && Convert.ToDouble(txtQty.Text) > 10000)
            {
                MessageBox.Show("Normality unit must be less than 10000", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtReagentNormality_Leave(object sender, EventArgs e)
        {
            if (txtReagentNormality.Text != "" && Convert.ToDouble(txtReagentNormality.Text) > 10)
            {
                MessageBox.Show("Normality unit must be between 0 to 10", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void txtReagentNormality_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ////// if count is greater than zero then transaction and bottles are standardise occured then do not delete
                ////DataSet dsCheckCount = new DataSet();
                ////long ReagentTransID = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                ////dsCheckCount = ReagentTransaction_Class_obj.tblReagentBottle_CheckDelete_Count(ReagentTransID);

                ////if (Convert.ToInt32(dsCheckCount.Tables[0].Rows[0][0].ToString()) > 0)
                ////{
                ////    MessageBox.Show("You can not delete Lot No. This is used in Standardazation !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ////}
                ////else
                {

                    // soft delete Lot No. by its transaction id . Active transactionId =0
                    // deleteStatus is true when Active flag =0
                    long TransactionID = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                    //delete record
                    bool deleteStatus = ReagentTransaction_Class_obj.Update_tblReagentTransaction_ActiveFlag(TransactionID);

                    if (deleteStatus == true)
                    {
                        MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                    }
                }

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

        private void CmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //BtnReset_Click(sender, e);

                if (CmbDetails.SelectedValue != null && CmbDetails.SelectedValue.ToString() != "")
                {
                    ReagentTransaction_Class_obj.reagenttransid = Convert.ToInt64(CmbDetails.SelectedValue);
                    DataSet ds = new DataSet();
                    ds = ReagentTransaction_Class_obj.Select_ReagentTransactionDetails();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        btnDelete.Enabled = true;
                        txtReagentName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReagentName"].ToString());
                        txtSupplierName.Text = Convert.ToString(ds.Tables[0].Rows[0]["SupplierName"].ToString());
                        dtpMfgDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["MfgDate"].ToString());
                        dtpValidityDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ValidityDate"].ToString());
                        txtQty.Text = Convert.ToString(ds.Tables[0].Rows[0]["QtyPerUnit"].ToString());
                        cmbUnit.Text = Convert.ToString(ds.Tables[0].Rows[0]["Unit"].ToString());
                        txtNoOfUnits.Text = Convert.ToString(ds.Tables[0].Rows[0]["NumOfUnit"].ToString());
                        ReagentTransaction_Class_obj.numofunit = Convert.ToDouble(ds.Tables[0].Rows[0]["NumOfUnit"].ToString());
                        txtTotalQty.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalQty"].ToString());
                        txtReagentNormality.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReagentNormality"].ToString());
                        txtNormalityUnit.Text = Convert.ToString(ds.Tables[0].Rows[0]["NormalityUnit"].ToString());
                        txtcomments.Text = Convert.ToString(ds.Tables[0].Rows[0]["Comments"].ToString());
                        cmbInspectedBy.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["InspectedBy"].ToString());

                        ReagentTransaction_Class_obj.reagentlotno = Convert.ToString(ds.Tables[0].Rows[0]["ReagentLotNo"].ToString());
                        ReagentTransaction_Class_obj.reagentid = Convert.ToInt64(ds.Tables[0].Rows[0]["ReagentID"].ToString());

                        DataSet dsLotNo = new DataSet();
                        dsLotNo = ReagentTransaction_Class_obj.Check_LotNumber(ReagentTransaction_Class_obj.reagentlotno);
                        if (dsLotNo.Tables[1].Rows.Count > 0)
                        {
                            _LayoutFilePath = dsLotNo.Tables[1].Rows[0]["COAFile"].ToString();
                            lblFileName.Text = System.IO.Path.GetFileName(dsLotNo.Tables[1].Rows[0]["COAFile"].ToString());
                            lnlviewfile.Visible = true;
                        }
                        else
                        {
                            _LayoutFilePath = lblFileName.Text = "";
                            lnlviewfile.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lnlviewfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_LayoutFilePath != "")
                Process.Start(_LayoutFilePath);
        }



    }
}