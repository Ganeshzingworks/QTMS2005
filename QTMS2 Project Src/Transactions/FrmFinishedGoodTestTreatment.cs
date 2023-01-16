using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Transactions
{
    public partial class FrmFinishedGoodTestTreatment : Form
    {

        public FrmFinishedGoodTestTreatment()
        {            
            InitializeComponent();
        }

        #region variables        
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class(); 
        #endregion      

        private static FrmFinishedGoodTestTreatment frmFinishedGoodTestTreatment_Obj = null;
        public static FrmFinishedGoodTestTreatment GetInstance()
        {
            if (frmFinishedGoodTestTreatment_Obj == null)
            {
                frmFinishedGoodTestTreatment_Obj = new FrmFinishedGoodTestTreatment();
            }
            return frmFinishedGoodTestTreatment_Obj;
        }

        private void FrmFinishedGoodTestTreatment_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            DtpDate.Value = Comman_Class_Obj.Select_ServerDate();
            Bind_Details();
            Bind_InspectedBy();
            cmbDetails.Focus();
        }

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                //those for which Kitflag is 1 
                ds = FinishedGoodTest_Class_Obj.Select_PendingFinishedGoodTreatmentDetails();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "Details";
                cmbDetails.ValueMember = "FGTLFID";
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

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                BtnReset_Click(sender, e);

                if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "")
                {

                    FinishedGoodTest_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);

                    //Select FGdetails from fgno 
                    DataSet dsFG = new DataSet();
                    dsFG = FinishedGoodTest_Class_Obj.Select_FinishedGood_FGDetails();
                    if (dsFG.Tables[0].Rows.Count > 0)
                    {
                        txtFGDesc.Text = dsFG.Tables[0].Rows[0]["FGDesc"].ToString();
                        txtPkgFamily.Text = dsFG.Tables[0].Rows[0]["TechFamDesc"].ToString();
                        FinishedGoodTest_Class_Obj.pkgtechno = Convert.ToInt64(dsFG.Tables[0].Rows[0]["PKGTechNo"]);
                        FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dsFG.Tables[0].Rows[0]["LNoFG"]);

                        if (dsFG.Tables[0].Rows[0]["VersionNo"] is System.DBNull)
                        {
                            FinishedGoodTest_Class_Obj.versionno = "";
                        }
                        else
                        {
                            FinishedGoodTest_Class_Obj.versionno = dsFG.Tables[0].Rows[0]["VersionNo"].ToString();
                        }
                    }

                    //Select Bulk & Packing Details 
                    DataSet dsPkgBulk = new DataSet();
                    dsPkgBulk = FinishedGoodTest_Class_Obj.Select_FinishedGood_PackingBulkTestDetails();
                    for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)
                    {
                        dgKit.Rows.Add();
                        dgKit["TLFID", i].Value = dsPkgBulk.Tables[0].Rows[i]["TLFID"].ToString();
                        dgKit["FNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString();
                        dgKit["FormulaNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString();
                        dgKit["MfgWo", i].Value = dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();
                        dgKit["FGNo", i].Value = dsPkgBulk.Tables[0].Rows[i]["FGNo"].ToString();
                        dgKit["FGCode", i].Value = dsPkgBulk.Tables[0].Rows[i]["FGCode"].ToString();
                        dgKit["TrackCode", i].Value = Convert.ToDateTime(dsPkgBulk.Tables[0].Rows[i]["TrackCode"]).ToShortDateString();
                        dgKit["LineDesc", i].Value = dsPkgBulk.Tables[0].Rows[i]["LineDesc"].ToString();
                        dgKit["PkgWO", i].Value = dsPkgBulk.Tables[0].Rows[i]["PkgWOFG"].ToString();
                        dgKit["FillDate", i].Value = Convert.ToDateTime(dsPkgBulk.Tables[0].Rows[i]["FillDateFG"]).ToShortDateString();
                        dgKit["Price", i].Value = dsPkgBulk.Tables[0].Rows[i]["PriceFG"].ToString();
                        dgKit["specification", i].Value = dsPkgBulk.Tables[0].Rows[i]["specificationFG"].ToString();
                        dgKit["Status", i].Value = dsPkgBulk.Tables[0].Rows[i]["Status"].ToString();
                    }

                    //Display unit PackSize and Weight
                    DataSet dsUnit;
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        dsUnit = new DataSet();
                        FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                        dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                        if (dsUnit.Tables[0].Rows.Count > 0)
                        {
                            if (dsUnit.Tables[0].Rows[0]["PackSize"] is DBNull)
                            {

                            }
                            else
                            {
                                dgKit["PackSize", i].Value = dsUnit.Tables[0].Rows[0]["PackSize"].ToString();
                            }

                            if (dsUnit.Tables[0].Rows[0]["Weight"] is DBNull)
                            {

                            }
                            else
                            {
                                dgKit["Weight", i].Value = dsUnit.Tables[0].Rows[0]["Weight"].ToString();
                            }
                        }
                    }

                    //Add column in dgTest for Packing
                    dgTest.Columns.Add("Packing", "Packing");
                    dgTest.Columns["Packing"].Width = 100;
                    dgTest.Columns["Packing"].ReadOnly = true;

                    //Select PkgStatus from fgno,fno,trackcode,lno and display into packing cell 
                    DataSet ds1 = new DataSet();
                    ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPackingDetails_PkgStatus();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dgTest["packing", 0].Value = ds1.Tables[0].Rows[0]["PkgStatus"].ToString();
                        FinishedGoodTest_Class_Obj.quantity = Convert.ToInt32(ds1.Tables[0].Rows[0]["Quantity"]);
                    }
                    else
                    {
                        dgTest["packing", 0].Value = "";
                        FinishedGoodTest_Class_Obj.quantity = 0;
                    }

                    //add columns in dgTest depends on no of MfgWo
                    for (int i = 0; i < dsPkgBulk.Tables[0].Rows.Count; i++)
                    {
                        //Check whether the column exists 
                        if (dgTest.Columns.Contains(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()) == false)
                        {
                            dgTest.Columns.Add(dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), dsPkgBulk.Tables[0].Rows[i]["FormulaNo"].ToString() + "\n" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString());
                            dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].Width = 100;
                            dgTest.Columns[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString()].ReadOnly = true;

                            FinishedGoodTest_Class_Obj.fno = Convert.ToInt64(dsPkgBulk.Tables[0].Rows[i]["FNo"]);
                            FinishedGoodTest_Class_Obj.mfgwo = dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString();

                            DataSet ds2 = new DataSet();
                            //Select PhyCheStatus from fgno,fno,trackcode,lno, mfgwo and display into cell
                            ds2 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus();
                            if (ds2.Tables[0].Rows.Count > 0)
                            {
                                dgTest[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), 0].Value = ds2.Tables[0].Rows[0]["PhyCheStatus"].ToString();
                            }
                            else
                            {
                                dgTest[dsPkgBulk.Tables[0].Rows[i]["FNo"].ToString() + "-" + dsPkgBulk.Tables[0].Rows[i]["MfgWo"].ToString(), 0].Value = "";
                            }
                        }
                    }

                    //GET CONTROL FROM tblFinishedGoodTestDetails using FGTLFID
                    DataSet ds = new DataSet();
                    ds = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodDetails_ControlType_FGTLFID();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        FinishedGoodTest_Class_Obj.type = ds.Tables[0].Rows[0]["ControlType"].ToString().Trim();
                    }
                    txtControltype.Text = FinishedGoodTest_Class_Obj.type;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //cmbDetails.Text = "--Select--";
            txtFGDesc.Text = "";
            txtPkgFamily.Text = "";
            txtControltype.Text = "";
            dgKit.Rows.Clear();
            dgTest.Columns.Clear();

            RdoAccepted.Checked = true;
            txtComment.Text = "";
            RdoBpc.Checked = true;
            txtComment_NonBpc.Text = "";
            cmbInspectedBy.Text = "--Select--";
            //RdoLaunch.Checked = true;

            ChkReject.Visible = false;
            for (int i = 0; i < ChkReject.Items.Count; i++)
            {
                if (ChkReject.GetItemChecked(i) == true)
                {
                    ChkReject.SetItemChecked(i, false);
                }
            }
            lblNoOfDefets.Visible = false;
            txtNoOfDefects.Visible = false;
            txtNoOfDefects.Text = "";
            lblNoOfSamples.Visible = false;
            txtNoOfSamples.Visible = false;
            txtNoOfSamples.Text = "";


            cmbDetails.Focus();

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("please select Details", "Message");
                    return;
                }
                else
                {
                    //Can't ACCEPT if any pack/phyche contains 'R'
                    bool R = false;                   
                    for (int i = 0; i < dgTest.Columns.Count; i++)
                    {
                        if (dgTest[i, 0].Value.ToString() == "R")
                        {
                            R = true;
                            break;
                        }                       
                    }
                    if (RdoAccepted.Checked == true && R == true)
                    {
                        MessageBox.Show("Sorry can't ACCEPT..!\n\nSome tests are rejected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RdoRejected.Focus();
                        return;
                    }
                    bool H = false;
                    for (int i = 0; i < dgTest.Columns.Count; i++)
                    {
                        if (dgTest[i, 0].Value.ToString() == "H")
                        {
                            H = true;
                            break;
                        }
                    }
                    if ((RdoAccepted.Checked == true || RdoRejected.Checked == true || RdoAWD.Checked == true ) && H == true)
                    {
                        MessageBox.Show("Sorry can't ACCEPT..!\n\nSome tests are Hold", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RdoHold.Focus();
                        return;
                    }

                    if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbInspectedBy.Focus();
                        return;
                    }

                    //Insert unit details
                    DataSet dsUnit;
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        dsUnit = new DataSet();
                        FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                        FinishedGoodTest_Class_Obj.packsize = Convert.ToInt32(dgKit["PackSize", i].Value);
                        FinishedGoodTest_Class_Obj.weight = Convert.ToDouble(dgKit["Weight", i].Value);
                        dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                        if (dsUnit.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_Class_Obj.Update_tblFinishedGoodUnitDetails();
                        }
                        else
                        {
                            FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodUnitDetails();
                        }
                    }


                    FinishedGoodTest_Class_Obj.testdate = Convert.ToString(DtpDate.Value);

                    if (RdoAccepted.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.status = "A";
                    }
                    else if (RdoHold.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.status = "H";
                    }
                    else if (RdoRejected.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.status = "R";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.status = "A";
                    }
                    

                    //------Actual Status------

                    if (RdoAccepted.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.actualstatus = "A";
                    }
                    else if (RdoHold.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.actualstatus = "H";
                    }
                    else if (RdoRejected.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.actualstatus = "R";
                    }
                    else if (RdoAWD.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.actualstatus = "D";
                    }
                    
                    FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("N/A");
                    for (int i = 0; i < ChkReject.Items.Count; i++)
                    {
                        if (ChkReject.GetItemChecked(i) == true)
                        {
                            if (i == 0)
                            {
                                FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("ZD");
                                break;
                            }
                            else if (i == 1)
                            {
                                FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("ZN");
                                break;
                            }
                            else if (i == 2)
                            {
                                FinishedGoodTest_Class_Obj.rejectcomment = Convert.ToString("Other");
                                break;
                            }
                        }
                    }

                    if (txtNoOfDefects.Text.Trim() != "")
                    {
                        FinishedGoodTest_Class_Obj.noofdefects = Convert.ToInt32(txtNoOfDefects.Text.Trim());
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.noofdefects = 0;
                    }

                    if (txtNoOfSamples.Text.Trim() != "")
                    {
                        FinishedGoodTest_Class_Obj.noofsamples = Convert.ToInt32(txtNoOfSamples.Text.Trim());
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.noofsamples = 0;
                    }

                    FinishedGoodTest_Class_Obj.Comment = txtComment.Text.Trim();
                    if (RdoBpc.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.decision = "B";
                        FinishedGoodTest_Class_Obj.nonbpccomment = "";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.decision = "N";
                        FinishedGoodTest_Class_Obj.nonbpccomment = txtComment_NonBpc.Text;
                    }


                    if (RdoLaunch.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.catagory = "Launch";
                    }
                    else if (RdoPriceChange.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.catagory = "PriceChange";
                    }
                    else if (RdoArtWorkChange.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.catagory = "ArtWorkChange";
                    }
                    else if (RdoRenovation.Checked == true)
                    {
                        FinishedGoodTest_Class_Obj.catagory = "Renovation";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.catagory = "N/A";
                    }
                    
                     
                    FinishedGoodTest_Class_Obj.currentflag = 1;

                    FinishedGoodTest_Class_Obj.treatmentdone = 1;
                    
                    FinishedGoodTest_Class_Obj.treatmented = 1;

                    FinishedGoodTest_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                    FinishedGoodTest_Class_Obj.loginid = FrmMain.LoginID;

                    //ControlType
                    //LNo

                    DataSet ds1 = new DataSet();
                    //Select FGTestNo from FGTLFID
                    ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodDetails_FGTLFID();
                    if (ds1.Tables[0].Rows.Count > 0)  // if exists then modify
                    {
                        FinishedGoodTest_Class_Obj.fgtestno = Convert.ToInt64(ds1.Tables[0].Rows[0]["FGTestNo"]);
                        FinishedGoodTest_Class_Obj.Update_tblFinishedGoodTestDetails();
                    }
                    else // insert
                    {
                        FinishedGoodTest_Class_Obj.fgtestno = FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodTestDetails();
                    }

                    //Make TreatementDone = 1 of all records (old + new) using FGTLFID
                    FinishedGoodTest_Class_Obj.Update_tblFinishedGoodTestDetails_TreatmentDone();
                    

                    //update FGDone=1  in tblFGTLF from FGTLFID 
                    if (RdoHold.Checked != true)
                    {
                        FinishedGoodTest_Class_Obj.fgdone = true;
                        FinishedGoodTest_Class_Obj.Update_tblFGTLF_FGDone();
                    }

                    MessageBox.Show("Record Saved Successfully..", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Bind_Details();
                    BtnReset_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void RdoNonBpc_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoNonBpc.Checked == true)
            {
                txtComment_NonBpc.Enabled = true;
                txtComment_NonBpc.Focus();
            }
        }

        private void RdoBpc_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoBpc.Checked == true)
            {
                txtComment_NonBpc.Text = "";
                txtComment_NonBpc.Enabled = false;
            }
        }

        private void RdoRejected_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoRejected.Checked == true)
            {
                RdoAWD.Visible = true;
                ChkReject.Visible = true;
                lblNoOfDefets.Visible = true;
                txtNoOfDefects.Visible = true;
                lblNoOfSamples.Visible = true;
                txtNoOfSamples.Visible = true;   

                //if rejected then NonBPC
                RdoNonBpc.Checked = true;
            }
        }

        private void RdoAccepted_CheckedChanged(object sender, EventArgs e)
        {
            RdoAWD.Visible = false;            
            ChkReject.Visible = false;
            lblNoOfDefets.Visible = false;
            txtNoOfDefects.Visible = false;
            txtNoOfDefects.Text = "";
            lblNoOfSamples.Visible = false;
            txtNoOfSamples.Visible = false;
            txtNoOfSamples.Text = "";
            for (int i = 0; i < ChkReject.Items.Count; i++)
            {
                if (ChkReject.GetItemChecked(i) == true)
                {
                    ChkReject.SetItemChecked(i, false);
                }
            }
        }

        private void RdoHold_CheckedChanged(object sender, EventArgs e)
        {
            RdoAWD.Visible = false;            
            ChkReject.Visible = false;
            lblNoOfDefets.Visible = false;
            txtNoOfDefects.Visible = false;
            txtNoOfDefects.Text = "";
            lblNoOfSamples.Visible = false;
            txtNoOfSamples.Visible = false;
            txtNoOfSamples.Text = "";
            for (int i = 0; i < ChkReject.Items.Count; i++)
            {
                if (ChkReject.GetItemChecked(i) == true)
                {
                    ChkReject.SetItemChecked(i, false);
                }
            }
        }

        private void ChkReject_Click(object sender, EventArgs e)
        {
            if (ChkReject.GetItemCheckState(ChkReject.SelectedIndex) == CheckState.Unchecked)
            {
                ChkReject.SetItemCheckState(ChkReject.SelectedIndex, CheckState.Checked);
            }
            else if (ChkReject.GetItemCheckState(ChkReject.SelectedIndex) == CheckState.Checked)
            {
                ChkReject.SetItemCheckState(ChkReject.SelectedIndex, CheckState.Unchecked);
            }
        }

        private void ChkReject_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Can select only one item
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < ChkReject.Items.Count; i++)
                {
                    if (e.Index != i)
                    {
                        ChkReject.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void dgKit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgKit.CurrentCell.ReadOnly == false)
            {
                dgKit.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void txtNoOfDefects_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void txtNoOfSamples_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void dgTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                //if (dgTest[e.ColumnIndex, e.RowIndex].Value != null)
                //{
                //    MessageBox.Show("Testing already Done...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                //    return;
                //}

                if (e.ColumnIndex == dgTest.Columns[0].Index)    //Packing
                {
                    FrmFGPackingTest.Detail detail_Obj = new FrmFGPackingTest.Detail();
                    detail_Obj.D_fgtlfid = FinishedGoodTest_Class_Obj.fgtlfid;
                    detail_Obj.D_pkgtechno = FinishedGoodTest_Class_Obj.pkgtechno;
                    detail_Obj.D_type = FinishedGoodTest_Class_Obj.type;
                    detail_Obj.D_Quantity = FinishedGoodTest_Class_Obj.quantity;
                    detail_Obj.D_pkgstatus = dgTest[e.ColumnIndex, e.RowIndex].Value.ToString();

                    if (dgTest[e.ColumnIndex, 0].Value.ToString() == "")
                    {
                        detail_Obj.Done = 'N';
                    }
                    else
                    {
                        detail_Obj.Done = 'Y';
                    }

                    int sum = 0;
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        sum = sum + Convert.ToInt32(dgKit["PackSize", i].Value);
                    }
                    if (FinishedGoodTest_Class_Obj.quantity == 0)
                        detail_Obj.D_Quantity = sum;

                    //Insert unit details
                    DataSet dsUnit;
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        dsUnit = new DataSet();
                        FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                        FinishedGoodTest_Class_Obj.packsize = Convert.ToInt32(dgKit["PackSize", i].Value);
                        FinishedGoodTest_Class_Obj.weight = Convert.ToDouble(dgKit["Weight", i].Value);
                        dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                        if (dsUnit.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_Class_Obj.Update_tblFinishedGoodUnitDetails();
                        }
                        else
                        {
                            FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodUnitDetails();
                        }
                    }

                    //Display FG Packing Test form
                    FrmFGPackingTest fmPack = new FrmFGPackingTest(detail_Obj);
                    fmPack.ShowDialog();

                    DataSet ds1 = new DataSet();
                    //Select PkgStatus from fgno,trackcode,lno
                    ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPackingDetails_PkgStatus();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, e.RowIndex].Value = ds1.Tables[0].Rows[0]["PkgStatus"].ToString();
                    }


                }
                else if (e.ColumnIndex > 0)   //Physico-Chemical
                {
                    FrmFGPhysicoChemicalTest.Detail detail_Obj = new FrmFGPhysicoChemicalTest.Detail();
                    detail_Obj.D_fgtlfid = FinishedGoodTest_Class_Obj.fgtlfid;
                    detail_Obj.D_fno = FinishedGoodTest_Class_Obj.fno;
                    detail_Obj.D_pkgtechno = FinishedGoodTest_Class_Obj.pkgtechno;
                    detail_Obj.D_type = FinishedGoodTest_Class_Obj.type;
                    detail_Obj.D_phychestatus = dgTest[e.ColumnIndex, e.RowIndex].Value.ToString();

                    if (dgTest[e.ColumnIndex, 0].Value.ToString() == "")
                    {
                        detail_Obj.Done = 'N';
                    }
                    else
                    {
                        detail_Obj.Done = 'Y';
                    }

                    //Insert unit details
                    DataSet dsUnit;
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        dsUnit = new DataSet();
                        FinishedGoodTest_Class_Obj.tlfid = Convert.ToInt64(dgKit["TLFID", i].Value);
                        FinishedGoodTest_Class_Obj.packsize = Convert.ToInt32(dgKit["PackSize", i].Value);
                        FinishedGoodTest_Class_Obj.weight = Convert.ToDouble(dgKit["Weight", i].Value);
                        dsUnit = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID();
                        if (dsUnit.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_Class_Obj.Update_tblFinishedGoodUnitDetails();
                        }
                        else
                        {
                            FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodUnitDetails();
                        }
                    }


                    string[] Formula = dgTest.Columns[e.ColumnIndex].HeaderText.Split('\n');
                    detail_Obj.D_FormulaNo = Formula[0];

                    string[] Name = dgTest.Columns[e.ColumnIndex].Name.Split('-');
                    //Get FNo from column name 
                    FinishedGoodTest_Class_Obj.fno = Convert.ToInt64(Name[0]);
                    //Get MfgWo from column name
                    FinishedGoodTest_Class_Obj.mfgwo = Name[1];

                    detail_Obj.D_fno = FinishedGoodTest_Class_Obj.fno;
                    detail_Obj.D_mfgwo = FinishedGoodTest_Class_Obj.mfgwo;

                    //Display FG Physico-Chemical Test form
                    FrmFGPhysicoChemicalTest fmPhy = new FrmFGPhysicoChemicalTest(detail_Obj);
                    fmPhy.ShowDialog();

                    DataSet ds1 = new DataSet();
                    //Select PhyCheStatus from fgno,fno,trackcode,lno
                    ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPhyCheDetails_PhyCheStatus();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        dgTest[e.ColumnIndex, e.RowIndex].Value = ds1.Tables[0].Rows[0]["PhyCheStatus"].ToString();
                    }

                }
            }

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       
    }
}