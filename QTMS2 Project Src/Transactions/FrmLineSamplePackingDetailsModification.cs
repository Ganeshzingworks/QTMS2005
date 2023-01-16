using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Transactions
{
    public partial class FrmLineSamplePackingDetailsModification : Form
    {
        public FrmLineSamplePackingDetailsModification()
        {
            InitializeComponent();
        }
        # region Varibles
        public bool Flag = false;
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.LineSamplePackingDetails_Class LineSamplePackingDetails_Class_Obj = new BusinessFacade.Transactions.LineSamplePackingDetails_Class();
        TankMaster_Class TankMaster_Class_Obj = new TankMaster_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        BulkFamilyMaster_Class BulkFamilyMaster_Class_Obj = new BulkFamilyMaster_Class();
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        PackingFamilyMaster_Class PackingFamilyMaster_Class_Obj = new PackingFamilyMaster_Class();
        RetainerLocation_Class RetainerLocation_Class_Obj = new RetainerLocation_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        # endregion

        static DataSet ds_Details = new DataSet();
        private static FrmLineSamplePackingDetailsModification frmLineSamplePackingDetailsModification_Obj = null;
        public static FrmLineSamplePackingDetailsModification GetInstance()
        {
            if (frmLineSamplePackingDetailsModification_Obj == null)
            {
                frmLineSamplePackingDetailsModification_Obj = new FrmLineSamplePackingDetailsModification();
            }
            return frmLineSamplePackingDetailsModification_Obj;
        }

        private void FrmLineSamplePackingDetailsModification_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            LoadStatus = "Load";
            DtpTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpFrom.Value = DtpTo.Value.AddDays(-5);

            Bind_Details();
            LoadStatus = "LoadComplete";
            Bind_Location();
            Bind_InspectedBy();
            Bind_VerifiedBy();
            cmbDetails.Text = "--Select--";
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpFillDate.Value = Comman_Class_Obj.Select_ServerDate();

            LineSamplePackingDetails_Class_Obj.fmid = 0;
            cmbDetails.Focus();

            if (GlobalVariables.City == "BADDI")
            {
                lblLocation.Visible = false;
                cmbLocation.Visible = false;

                lblDeveloper.Visible = lblColorant.Visible = lblFG.Visible = lblOther.Visible = lblSF.Visible = false;
                txtDeveloper.Visible = txtColorant.Visible = txtFG.Visible = txtOther.Visible = txtSF.Visible = false;
            }
        }
        delegate void SetTextDelegate(DataSet ds);
        public void Bind_Details()
        {
            if (DtpFrom.Checked == true)
            {
                LineSamplePackingDetails_Class_Obj.fromdate = DtpFrom.Value.ToShortDateString();
            }
            else
            {
                LineSamplePackingDetails_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
            }

            if (DtpTo.Checked == true)
            {
                LineSamplePackingDetails_Class_Obj.todate = DtpTo.Value.ToShortDateString();
            }
            else
            {
                LineSamplePackingDetails_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
            }

            DataSet ds = new DataSet();
            DataRow dr;
            ds = LineSamplePackingDetails_Class_Obj.Select_ModificationLinePackingDetails(Convert.ToDateTime(LineSamplePackingDetails_Class_Obj.fromdate), Convert.ToDateTime(LineSamplePackingDetails_Class_Obj.todate));
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            dr["TLFID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.ValueMember = "TLFID";
                cmbDetails.DisplayMember = "Details";
            }
            #region Code for Thread
            //if (ds_Details!=null)
            //{
            //    if (ds_Details.Tables.Count>0)
            //    {
            //        if (ds_Details.Tables[0].Rows.Count>0)
            //        {
            //            cmbDetails.DataSource = ds_Details.Tables[0];
            //            cmbDetails.ValueMember = "TLFID";
            //            cmbDetails.DisplayMember = "Details";
            //        }
            //        else
            //        {

            //        }
            //    }
            //    else
            //    {
            //        DataSet ds = new DataSet();
            //        DataRow dr;
            //        ds = LineSamplePackingDetails_Class_Obj.Select_ModificationLinePackingDetails();
            //        dr = ds.Tables[0].NewRow();
            //        dr["Details"] = "--Select--";
            //        dr["TLFID"] = "0";
            //        ds.Tables[0].Rows.InsertAt(dr, 0);
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            if (cmbDetails.InvokeRequired)
            //            {
            //                Invoke(new SetTextDelegate(SetText), ds);
            //            }
            //            else
            //            {
            //                if (cmbDetails.DataSource == null)
            //                {
            //                    cmbDetails.DataSource = ds.Tables[0];
            //                    cmbDetails.ValueMember = "TLFID";
            //                    cmbDetails.DisplayMember = "Details";
            //                }
            //            }
            //        }
            //    }
            //} 
            #endregion


        }


        public void SetText(DataSet ds)
        {
            if (cmbDetails.DataSource == null)
            {
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.ValueMember = "TLFID";
                cmbDetails.DisplayMember = "Details";
            }
        }

        //public static void Bind_Details_Data()
        //{
        //    BusinessFacade.Transactions.LineSamplePackingDetails_Class LineSamplePackingDetails_Class_ObjData = new BusinessFacade.Transactions.LineSamplePackingDetails_Class();
        //    //DataSet ds = new DataSet();
        //    DataRow dr;
        //    ds_Details = LineSamplePackingDetails_Class_ObjData.Select_ModificationLinePackingDetails();
        //    dr = ds_Details.Tables[0].NewRow();
        //    dr["Details"] = "--Select--";
        //    dr["TLFID"] = "0";
        //    ds_Details.Tables[0].Rows.InsertAt(dr, 0);
        //    //if (ds.Tables[0].Rows.Count > 0)
        //    //{
        //    //    cmbDetails.DataSource = ds.Tables[0];
        //    //    cmbDetails.ValueMember = "TLFID";
        //    //    cmbDetails.DisplayMember = "Details";
        //    //}
        //}

        public void Bind_Location()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = RetainerLocation_Class_Obj.Select_tblRetainerLocation();
            dr = ds.Tables[0].NewRow();
            dr["Location"] = "--Select--";
            dr["LocationID"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbLocation.DataSource = ds.Tables[0];
                cmbLocation.DisplayMember = "Location";
                cmbLocation.ValueMember = "LocationID";
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

        public void Bind_VerifiedBy()
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
                cmbVerifiedBy.DataSource = ds.Tables[0];
                cmbVerifiedBy.DisplayMember = "UserName";
                cmbVerifiedBy.ValueMember = "UserID";
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_Details();
            cmbDetails.Text = "--Select--";
            reset();
            LineSamplePackingDetails_Class_Obj.fno = 0;
            cmbDetails.Focus();
        }

        public void reset()
        {
            txtDescription.Text = "";
            txtTechnicalFamily.Text = "";

            ChkKit.Checked = false;
            ChkSF.Checked = false;
            txtBatchCode.Text = "";
            txtFillVolume.Text = "";
            txtPrice.Text = "";
            txtSpecification.Text = "";
            txtPkgWoNo.Text = "";

            txtDeveloper.Text = txtColorant.Text = txtFG.Text = txtOther.Text = txtSF.Text = "";

            DtpFillDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpInspDate.Value = Comman_Class_Obj.Select_ServerDate();

            cmbLocation.Text = "--Select--";

            ChkSemiFinished.Checked = false;
            ChkAOCPending.Checked = false;
            ChkWip.Checked = false;
            ChkFinishedProduct.Checked = false;

            txtSemiFinished.Text = "";
            txtAOCPending.Text = "";
            txtComment.Text = "";
            cmbInspectedBy.Text = "--Select--";
            cmbVerifiedBy.Text = "--Select--";
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                reset();

                if (cmbDetails.SelectedValue is DBNull)
                {

                }
                else
                {
                    DataSet ds = new DataSet();
                    LineSamplePackingDetails_Class_Obj.tlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());
                    ds = LineSamplePackingDetails_Class_Obj.Select_ModificationLinePackingDetails_Details();
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        LineSamplePackingDetails_Class_Obj.trackcode = Convert.ToString(ds.Tables[0].Rows[0]["TrackCode"]);

                        LineSamplePackingDetails_Class_Obj.lno = Convert.ToInt32(ds.Tables[0].Rows[0]["LNo"]);

                        LineSamplePackingDetails_Class_Obj.fgno = Convert.ToInt64(ds.Tables[0].Rows[0]["FGNo"]);

                        if (Convert.ToInt16(ds.Tables[0].Rows[0]["KitFlag"]) == 1)
                        {
                            ChkKit.Checked = true;
                            LineSamplePackingDetails_Class_Obj.kitflag = 1;
                        }
                        else
                        {
                            ChkKit.Checked = false;
                            LineSamplePackingDetails_Class_Obj.kitflag = 0;
                        }

                        if (Convert.ToInt16(ds.Tables[0].Rows[0]["SFFlag"]) == 1)
                        {
                            ChkSF.Checked = true;
                            LineSamplePackingDetails_Class_Obj.sfflag = 1;
                        }
                        else
                        {
                            ChkSF.Checked = false;
                            LineSamplePackingDetails_Class_Obj.sfflag = 0;
                        }


                        txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);
                        txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);

                        txtBatchCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["BatchNo"]);
                        txtFillVolume.Text = Convert.ToString(ds.Tables[0].Rows[0]["FillVolume"]);
                        txtPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["Price"]);
                        txtSpecification.Text = Convert.ToString(ds.Tables[0].Rows[0]["specification"]);
                        txtPkgWoNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PkgWO"]);

                        DtpFillDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["FillDate"]);
                        DtpInspDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspDate"]);

                        if (ds.Tables[0].Rows[0]["LocationID"] is DBNull)
                        {
                            cmbLocation.SelectedValue = 0;
                        }
                        else
                        {
                            cmbLocation.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["LocationID"]);
                        }

                        if (ds.Tables[0].Rows[0]["ProddecSF"].ToString() == "Y")
                        {
                            ChkSemiFinished.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["ProddecSF"].ToString() == "N")
                        {
                            ChkSemiFinished.Checked = false;
                        }
                        txtSemiFinished.Text = ds.Tables[0].Rows[0]["CommentsSF"].ToString();

                        if (ds.Tables[0].Rows[0]["AOCPend"].ToString() == "Y")
                        {
                            ChkAOCPending.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["AOCPend"].ToString() == "N")
                        {
                            ChkAOCPending.Checked = false;
                        }
                        txtAOCPending.Text = ds.Tables[0].Rows[0]["CommentsAOC"].ToString();

                        if (ds.Tables[0].Rows[0]["ProddecWIP"].ToString() == "Y")
                        {
                            ChkWip.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["ProddecWIP"].ToString() == "N")
                        {
                            ChkWip.Checked = false;
                        }

                        if (ds.Tables[0].Rows[0]["ProddecFP"].ToString() == "Y")
                        {
                            ChkFinishedProduct.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["ProddecFP"].ToString() == "N")
                        {
                            ChkFinishedProduct.Checked = false;
                        }

                        if (ds.Tables[0].Rows[0]["Status"].ToString() == "A")
                        {
                            RdoAccepted.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "R")
                        {
                            RdoRejected.Checked = true;
                        }
                        txtComment.Text = ds.Tables[0].Rows[0]["Comments"].ToString();

                        if (ds.Tables[0].Rows[0]["InspectedBy"] is DBNull)
                        {
                            cmbInspectedBy.SelectedValue = 0;
                        }
                        else
                        {
                            cmbInspectedBy.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["InspectedBy"]);
                        }
                        if (ds.Tables[0].Rows[0]["VerifiedBy"] is DBNull)
                        {
                            cmbVerifiedBy.SelectedValue = 0;
                        }
                        else
                        {
                            cmbVerifiedBy.SelectedValue = Convert.ToInt64(ds.Tables[0].Rows[0]["VerifiedBy"]);
                        }
                        if (ds.Tables[0].Rows[0]["Colorant"] is DBNull)
                            txtColorant.Text = "";
                        else
                            txtColorant.Text = Convert.ToString(ds.Tables[0].Rows[0]["Colorant"]);
                        if (ds.Tables[0].Rows[0]["Developer"] is DBNull)
                            txtDeveloper.Text = "";
                        else
                            txtDeveloper.Text = Convert.ToString(ds.Tables[0].Rows[0]["Developer"]);
                        if (ds.Tables[0].Rows[0]["SF"] is DBNull)
                            txtSF.Text = "";
                        else
                            txtSF.Text = Convert.ToString(ds.Tables[0].Rows[0]["SF"]);
                        if (ds.Tables[0].Rows[0]["FG"] is DBNull)
                            txtFG.Text = "";
                        else
                            txtFG.Text = Convert.ToString(ds.Tables[0].Rows[0]["FG"]);
                        if (ds.Tables[0].Rows[0]["Other"] is DBNull)
                            txtOther.Text = "";
                        else
                            txtOther.Text = Convert.ToString(ds.Tables[0].Rows[0]["Other"]);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkSemiFinished_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSemiFinished.Checked == true)
            {
                txtSemiFinished.Enabled = true;

                //Record cant accepted when it is semifinished
                RdoRejected.Checked = true;
            }
            else if (ChkSemiFinished.Checked == false)
            {
                txtSemiFinished.Enabled = false;
                txtSemiFinished.Text = "";

                RdoAccepted.Checked = true;
            }
        }

        private void ChkAOCPending_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAOCPending.Checked == true)
            {
                txtAOCPending.Enabled = true;
            }
            else if (ChkAOCPending.Checked == false)
            {
                txtAOCPending.Enabled = false;
                txtAOCPending.Text = "";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if ((cmbDetails.Text == "--Select--" || cmbDetails.SelectedValue == null || cmbDetails.SelectedValue.ToString() == ""))
                {
                    MessageBox.Show("Please Select Details ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                    return;
                }

                if (txtBatchCode.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Batch Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchCode.Focus();
                    return;
                }

                if (txtFillVolume.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Fill Volume", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFillVolume.Focus();
                    return;
                }

                if (txtPrice.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Price", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrice.Focus();
                    return;
                }

                if (txtSpecification.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Specification", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSpecification.Focus();
                    return;
                }

                if (txtPkgWoNo.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Packing Work", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPkgWoNo.Focus();
                    return;
                }

                if ((ChkAOCPending.Checked == false) && (ChkFinishedProduct.Checked == false) && (ChkSemiFinished.Checked == false) && (ChkWip.Checked == false))
                {
                    MessageBox.Show("Select atleast one Product Decleration", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChkSemiFinished.Focus();
                    return;
                }

                if (ChkSemiFinished.Checked == true)
                {
                    if (txtSemiFinished.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter Semi Finished Comment", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSemiFinished.Focus();
                        return;
                    }
                }

                if (ChkAOCPending.Checked == true)
                {
                    if (txtAOCPending.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter AOC Pending Comment", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAOCPending.Focus();
                        return;
                    }
                }
                if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbInspectedBy.Focus();
                    return;
                }
                if (cmbVerifiedBy.SelectedValue == null || cmbVerifiedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Verified By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbVerifiedBy.Focus();
                    return;
                }

                //--------- Commented as per Nilesh's suggestion----------

                //if (ChkSemiFinished.Checked == true && RdoAccepted.Checked == true)
                //{
                //    MessageBox.Show("Semifinished Can't Accepted..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    RdoRejected.Checked = true;
                //    RdoRejected.Focus();
                //    return;
                //}                            

                LineSamplePackingDetails_Class_Obj.batchno = txtBatchCode.Text.Trim();
                LineSamplePackingDetails_Class_Obj.fillvolume = txtFillVolume.Text.Trim();
                LineSamplePackingDetails_Class_Obj.pkgwo = txtPkgWoNo.Text.Trim();
                LineSamplePackingDetails_Class_Obj.price = txtPrice.Text.Trim();
                LineSamplePackingDetails_Class_Obj.Specification = txtSpecification.Text.Trim();
                LineSamplePackingDetails_Class_Obj.filldate = DtpFillDate.Value.ToShortDateString();
                LineSamplePackingDetails_Class_Obj.inspdate = DtpInspDate.Value.ToShortDateString();

                LineSamplePackingDetails_Class_Obj.locationid = Convert.ToInt64(cmbLocation.SelectedValue);

                if (ChkSemiFinished.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.proddecsf = Convert.ToChar("Y");
                    LineSamplePackingDetails_Class_Obj.commentssf = txtSemiFinished.Text.Trim();
                }
                else
                {
                    LineSamplePackingDetails_Class_Obj.proddecsf = Convert.ToChar("N");
                    LineSamplePackingDetails_Class_Obj.commentssf = "";
                }

                if (ChkAOCPending.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.aocPend = Convert.ToChar("Y");
                    LineSamplePackingDetails_Class_Obj.commentsaoc = txtAOCPending.Text.Trim();
                }
                else
                {
                    LineSamplePackingDetails_Class_Obj.aocPend = Convert.ToChar("N");
                    LineSamplePackingDetails_Class_Obj.commentsaoc = "";
                }

                if (ChkWip.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.proddecwip = Convert.ToChar("Y");
                }
                else
                {
                    LineSamplePackingDetails_Class_Obj.proddecwip = Convert.ToChar("N");
                }

                if (ChkFinishedProduct.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.proddecfp = Convert.ToChar("Y");
                }
                else
                {
                    LineSamplePackingDetails_Class_Obj.proddecfp = Convert.ToChar("N");
                }

                if (RdoAccepted.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.status = Convert.ToChar("A");
                }
                if (RdoRejected.Checked == true)
                {
                    LineSamplePackingDetails_Class_Obj.status = Convert.ToChar("R");
                }

                LineSamplePackingDetails_Class_Obj.comments = txtComment.Text.Trim();

                LineSamplePackingDetails_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);
                LineSamplePackingDetails_Class_Obj.verifiedby = Convert.ToInt32(cmbVerifiedBy.SelectedValue);

                if (GlobalVariables.City == "BADDI")
                {
                    LineSamplePackingDetails_Class_Obj.developer = -1;
                }
                else
                {
                    if (txtDeveloper.Text != "")
                        LineSamplePackingDetails_Class_Obj.developer = Convert.ToInt32(txtDeveloper.Text.Trim());
                    else
                        LineSamplePackingDetails_Class_Obj.developer = 0;
                    if (txtColorant.Text != "")
                        LineSamplePackingDetails_Class_Obj.colorant = Convert.ToInt32(txtColorant.Text.Trim());
                    else
                        LineSamplePackingDetails_Class_Obj.colorant = 0;
                    if (txtSF.Text != "")
                        LineSamplePackingDetails_Class_Obj.sf = Convert.ToInt32(txtSF.Text.Trim());
                    else
                        LineSamplePackingDetails_Class_Obj.sf = 0;
                    if (txtFG.Text != "")
                        LineSamplePackingDetails_Class_Obj.fg = Convert.ToInt32(txtFG.Text.Trim());
                    else
                        LineSamplePackingDetails_Class_Obj.fg = 0;
                    if (txtOther.Text != "")
                        LineSamplePackingDetails_Class_Obj.other = Convert.ToInt32(txtOther.Text.Trim());
                    else
                        LineSamplePackingDetails_Class_Obj.other = 0;
                }
                LineSamplePackingDetails_Class_Obj.loginid = FrmMain.LoginID;

                LineSamplePackingDetails_Class_Obj.tlfid = Convert.ToInt64(cmbDetails.SelectedValue);

                bool b = LineSamplePackingDetails_Class_Obj.Update_tblPkgSamp();

                //----- update KitFlag---------

                if ((LineSamplePackingDetails_Class_Obj.kitflag == 0 && ChkKit.Checked == true) || (LineSamplePackingDetails_Class_Obj.sfflag == 0 && ChkSF.Checked == true))
                {
                    if (ChkKit.Checked == true)
                    {
                        LineSamplePackingDetails_Class_Obj.kitflag = 1;
                    }
                    else
                    {
                        LineSamplePackingDetails_Class_Obj.kitflag = 0;
                    }

                    if (ChkSF.Checked == true)
                    {
                        LineSamplePackingDetails_Class_Obj.sfflag = 1;
                    }
                    else
                    {
                        LineSamplePackingDetails_Class_Obj.sfflag = 0;
                    }

                    LineSamplePackingDetails_Class_Obj.Update_tblTransTLF_KitFlag_SFFlag();
                    LineSamplePackingDetails_Class_Obj.Delete_tblFGTLF_TLFID();
                }
                else if ((LineSamplePackingDetails_Class_Obj.kitflag == 1 && ChkKit.Checked == false) || (LineSamplePackingDetails_Class_Obj.sfflag == 1 && ChkSF.Checked == false))
                {
                    //--- No need to do this - nilesh

                    if (ChkKit.Checked == true)
                    {
                        LineSamplePackingDetails_Class_Obj.kitflag = 1;
                    }
                    else
                    {
                        LineSamplePackingDetails_Class_Obj.kitflag = 0;
                    }

                    if (ChkSF.Checked == true)
                    {
                        LineSamplePackingDetails_Class_Obj.sfflag = 1;
                    }
                    else
                    {
                        LineSamplePackingDetails_Class_Obj.sfflag = 0;
                    }

                    LineSamplePackingDetails_Class_Obj.Update_tblTransTLF_KitFlag_SFFlag();
                    LineSamplePackingDetails_Class_Obj.Delete_tblFGTLF_TLFID();

                    //check whether combination of TrackCode,LNo,FGNo already exists in tblFGTLF 
                    DataSet dsFGTLFID = new DataSet();
                    dsFGTLFID = LineSamplePackingDetails_Class_Obj.Select_tblFGTLF_TLF();
                    if (dsFGTLFID.Tables[0].Rows.Count > 0)
                    {
                        LineSamplePackingDetails_Class_Obj.fgtlfid = Convert.ToInt64(dsFGTLFID.Tables[0].Rows[0]["FGTLFID"]);
                    }
                    else
                    {
                        LineSamplePackingDetails_Class_Obj.fgtlfid = LineSamplePackingDetails_Class_Obj.Insert_tblFGTLF();
                    }

                    DataSet dsLinkTLFID = new DataSet();
                    dsLinkTLFID = LineSamplePackingDetails_Class_Obj.Select_tblLinkTLF();
                    if (dsLinkTLFID.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        LineSamplePackingDetails_Class_Obj.Insert_tblLinkTLF();
                    }

                }
                else if ((LineSamplePackingDetails_Class_Obj.kitflag == 0 && ChkKit.Checked == false) && (LineSamplePackingDetails_Class_Obj.sfflag == 0 && ChkSF.Checked == false))
                {

                    //check whether combination of TrackCode,LNo,FGNo already exists in tblFGTLF 
                    DataSet dsFGTLFID = new DataSet();
                    dsFGTLFID = LineSamplePackingDetails_Class_Obj.Select_tblFGTLF_TLF();
                    if (dsFGTLFID.Tables[0].Rows.Count > 0)
                    {
                        LineSamplePackingDetails_Class_Obj.fgtlfid = Convert.ToInt64(dsFGTLFID.Tables[0].Rows[0]["FGTLFID"]);

                        //update entries in tblFGTLF for normal FGCode 
                        LineSamplePackingDetails_Class_Obj.Update_tblFGTLF_TLFID();
                    }
                    else
                    {
                        LineSamplePackingDetails_Class_Obj.fgtlfid = LineSamplePackingDetails_Class_Obj.Insert_tblFGTLF();
                    }

                    DataSet dsLinkTLFID = new DataSet();
                    dsLinkTLFID = LineSamplePackingDetails_Class_Obj.Select_tblLinkTLF();
                    if (dsLinkTLFID.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        LineSamplePackingDetails_Class_Obj.Insert_tblLinkTLF();
                    }
                }

                ////--------- insert entries into fgtlf -----------------
                //if ((LineSamplePackingDetails_Class_Obj.kitflag == 0 && ChkKit.Checked == false) || (LineSamplePackingDetails_Class_Obj.sfflag == 0 && ChkSF.Checked == false))
                //{
                //    //check whether combination of TrackCode,LNo,FGNo already exists in tblFGTLF 
                //    DataSet dsFGTLFID = new DataSet();
                //    dsFGTLFID = LineSamplePackingDetails_Class_Obj.Select_tblFGTLF_TLF();
                //    if (dsFGTLFID.Tables[0].Rows.Count > 0)
                //    {
                //        LineSamplePackingDetails_Class_Obj.fgtlfid = Convert.ToInt64(dsFGTLFID.Tables[0].Rows[0]["FGTLFID"]);
                //    }
                //    else
                //    {
                //        LineSamplePackingDetails_Class_Obj.fgtlfid = LineSamplePackingDetails_Class_Obj.Insert_tblFGTLF();
                //    }

                //    DataSet dsLinkTLFID = new DataSet();
                //    dsLinkTLFID = LineSamplePackingDetails_Class_Obj.Select_tblLinkTLF();
                //    if (dsLinkTLFID.Tables[0].Rows.Count > 0)
                //    {

                //    }
                //    else
                //    {
                //        LineSamplePackingDetails_Class_Obj.Insert_tblLinkTLF();
                //    }
                //}

                if (b == true)
                {
                    MessageBox.Show("Record Saved Sucessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnReset_Click(sender, e);
                    //Bind_FormulaNo();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cmbDetails.Text == "--Select--" || cmbDetails.SelectedValue == null || cmbDetails.SelectedValue.ToString() == ""))
                {
                    MessageBox.Show("Please Select Details ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                    return;
                }

                LineSamplePackingDetails_Class_Obj.tlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());

                if (MessageBox.Show("Are You sure want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    //bool b = LineSamplePackingDetails_Class_Obj.Delete_tblPkgSamp();
                    //if (b == true)
                    //{
                    //    bool b1 = LineSamplePackingDetails_Class_Obj.Delete_tblLinkTLF();
                    //    if (b1 == true)
                    //    {

                    if (LineSamplePackingDetails_Class_Obj.kitflag == 0)
                    {
                        LineSamplePackingDetails_Class_Obj.Delete_tblFGTLF_TLFID();
                    }

                    //LineSamplePackingDetails_Class_Obj.linepkgdone = false;    
                    //bool b = LineSamplePackingDetails_Class_Obj.Update_tblTransTLF_LinePkgDone();

                    bool b2 = LineSamplePackingDetails_Class_Obj.Delete_tblTransTLF();
                    if (b2 == true)
                    {
                        MessageBox.Show("Record deleted Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                    }



                    //    }
                    //}
                }

            }
            catch
            {
                MessageBox.Show("Sorry you Can't Delete this Record", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSpecification_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtSpecification.Text = textInfo.ToTitleCase(txtSpecification.Text);

        }

        private void txtPkgWoNo_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtPkgWoNo.Text = textInfo.ToTitleCase(txtPkgWoNo.Text);
        }

        private void txtSemiFinished_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtSemiFinished.Text = textInfo.ToTitleCase(txtSemiFinished.Text);
        }

        private void txtAOCPending_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtAOCPending.Text = textInfo.ToTitleCase(txtAOCPending.Text);
        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtComment.Text = textInfo.ToTitleCase(txtComment.Text);
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LoadStatus))
            {
                if (LoadStatus.Equals("LoadComplete"))
                {
                    Bind_Details();
                }
            }
        }
        private string _LoadStatus;

        public string LoadStatus
        {
            get { return _LoadStatus; }
            set { _LoadStatus = value; }
        }
        private void DtpTo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoadStatus))
            {
                if (LoadStatus.Equals("LoadComplete"))
                {
                    Bind_Details();
                }
            }
        }

        private void txtColorant_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedValue != null && cmbLocation.SelectedValue.ToString() != "0" && cmbLocation.SelectedIndex != 0)
            {
                RetainerLocation_Class_Obj.locationid = Convert.ToInt64(cmbLocation.SelectedValue);
                DataSet DsTran = new DataSet();
                DsTran = RetainerLocation_Class_Obj.Select_RetainerLocation_TransactionExiest();
                if (DsTran.Tables[0].Rows.Count > 0)
                {
                    DataSet Ds = new DataSet();
                    Ds = RetainerLocation_Class_Obj.Select_RetainerLocation_Destruct();
                    if (Ds.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please Desctruct location !!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbLocation.SelectedIndex = 0;
                    }
                }
            }
        }



    }
}