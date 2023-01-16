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
using BusinessFacade.Transactions;
using QTMS.Tools;

namespace QTMS.Transactions
{
    public partial class FrmSFDetailsModification : Form
    {
        public FrmSFDetailsModification()
        {
            InitializeComponent();
        }

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        DyeKit_Class DyeKit_Class_Obj = new DyeKit_Class();
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();

        private static FrmSFDetailsModification frmSFDetailsModification_Obj = null;
        public static FrmSFDetailsModification GetInstance()
        {
            if (frmSFDetailsModification_Obj == null)
            {
                frmSFDetailsModification_Obj = new FrmSFDetailsModification();
            }
            return frmSFDetailsModification_Obj;
        }

        private void FrmSFDetailsModification_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_Details();
            BtnReset_Click(sender, e);
            cmbDetails.Focus();
        }

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                // only Kit FGCode
                ds = DyeKit_Class_Obj.Select_ModificationSFDetails();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.ValueMember = "FGTLFID";
                cmbDetails.DisplayMember = "Details";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbFGCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                reset();

                DataSet ds = new DataSet();
                DataSet dslnk = new DataSet();

                if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "")
                {
                    DyeKit_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);

                    //dslnk = DyeKit_Class_Obj.Select_tblLinkTLF_FGTLFID();
                    dslnk = DyeKit_Class_Obj.Select_tblLinkSF_FGTLFID();
                    if (dslnk.Tables[0].Rows.Count > 0)
                    {
                        DyeKit_Class_Obj.fgnokit = Convert.ToInt32(dslnk.Tables[0].Rows[0]["FGNoFG"]);

                        DtpFillDate.Value = Convert.ToDateTime(dslnk.Tables[0].Rows[0]["FillDateFG"]);
                        txtPkgWoNo.Text = dslnk.Tables[0].Rows[0]["PkgWOFG"].ToString();
                        txtBatchCode.Text = dslnk.Tables[0].Rows[0]["BatchNoFG"].ToString();
                        txtPrice.Text = dslnk.Tables[0].Rows[0]["PriceFG"].ToString();
                        txtSpecification.Text = dslnk.Tables[0].Rows[0]["specificationFG"].ToString();
                        if (dslnk.Tables[0].Rows[0]["AOCPendFG"].ToString() == "Y")
                        {
                            ChkAOCPending.Checked = true;
                        }
                        else if (dslnk.Tables[0].Rows[0]["AOCPendFG"].ToString() == "N")
                        {
                            ChkAOCPending.Checked = false;
                        }
                        txtAOCPending.Text = dslnk.Tables[0].Rows[0]["CommentsAOCFG"].ToString();
                    }

                    //ds = DyeKit_Class_Obj.Select_Formula_MfgWo_SF();
                    DataTable dt = new DataTable();
                    //dt = DyeKit_Class_Obj.Select_Formula_MfgWo_SF();
                    dt = DyeKit_Class_Obj.Select_FGCode_SF();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgSF.Rows.Add();
                        dgSF["TLFID", dgSF.Rows.Count - 1].Value = dt.Rows[i]["TLFID"].ToString();
                        dgSF["FGTLFID", dgSF.Rows.Count - 1].Value = dt.Rows[i]["FGTLFID"].ToString();
                        //dgSF["FormulaNo", dgSF.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["FormulaNo"].ToString();
                        //dgSF["MfgWo", dgSF.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MfgWo"].ToString();
                        dgSF["FGCode", dgSF.Rows.Count - 1].Value = dt.Rows[i]["FGCode"].ToString();
                        dgSF["TrackCode", dgSF.Rows.Count - 1].Value = Convert.ToDateTime(dt.Rows[i]["TrackCode"]).ToShortDateString();
                        dgSF["LineDesc", dgSF.Rows.Count - 1].Value = dt.Rows[i]["LineDesc"].ToString();
                        //dgSF["PkgWO", dgSF.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["PkgWO"].ToString();
                        //dgSF["FillDate", dgSF.Rows.Count - 1].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["FillDate"]).ToShortDateString();
                        //dgSF["Price", dgSF.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Price"].ToString();
                        //dgSF["specification", dgSF.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["specification"].ToString();
                        //dgSF["AOCPend", dgSF.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AOCPend"].ToString();
                        //dgSF["Status", dgSF.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Status"].ToString();

                    }

                    foreach (DataGridViewRow row in dgSF.Rows)
                    {
                        if (Convert.ToInt64(row.Cells["TLFID"].Value) > 0)
                        {
                            DataSet dsMarkFG = new DataSet();
                            //DyeKit_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);
                            //DyeKit_Class_Obj.fgcodefg = Convert.ToString(dgSF["FGCode", dgSF.Rows.Count - 1].Value);
                            //DyeKit_Class_Obj.trackcodefg = Convert.ToString(dgSF["TrackCode", dgSF.Rows.Count - 1].Value);
                            //DyeKit_Class_Obj.linedesc = Convert.ToString(dgSF["LineDesc", dgSF.Rows.Count - 1].Value);

                            dsMarkFG = DyeKit_Class_Obj.Select_tblLinkSF_tblTransTLF_MarkFGCode();

                            for (int i = 0; i < dsMarkFG.Tables[0].Rows.Count; i++)
                            {
                                if (row.Cells["TLFID"].Value.ToString() == dsMarkFG.Tables[0].Rows[i]["TLFID"].ToString())
                                {
                                    row.Cells["Mark"].Value = true;
                                    break;
                                }
                            }
                           
                        }
                    }

                   


                    foreach (DataGridViewRow row in dgSF.Rows)
                    {
                        if (Convert.ToInt64(row.Cells["FGTLFID"].Value) > 0)
                        {
                            DataSet dsMarkFGTLFID = new DataSet();
                            //DyeKit_Class_Obj.fgcodefg = Convert.ToString(dgSF["FGCode", dgSF.Rows.Count - 1].Value);
                            //DyeKit_Class_Obj.trackcodefg = Convert.ToString(dgSF["TrackCode", dgSF.Rows.Count - 1].Value);
                            //DyeKit_Class_Obj.linedesc = Convert.ToString(dgSF["LineDesc", dgSF.Rows.Count - 1].Value);
                            dsMarkFGTLFID = DyeKit_Class_Obj.Select_tblLinkSF_tblFGTLF_MarkFGCode();
                            for (int i = 0; i < dsMarkFGTLFID.Tables[0].Rows.Count; i++)
                            {
                                if (row.Cells["FGTLFID"].Value.ToString() == dsMarkFGTLFID.Tables[0].Rows[i]["FGTLFID"].ToString())
                                {
                                    row.Cells["Mark"].Value = true;
                                    break;
                                }
                            }

                        }

                    }
                  

                  
                    dgSF.Sort(dgSF.Columns["Mark"], ListSortDirection.Descending);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw ex;
            }

        }

        private void cmbFGCode_Leave(object sender, EventArgs e)
        {
            //if (cmbFGCode.Text == "--Select--" || cmbFGCode.SelectedValue == null || cmbFGCode.SelectedValue.ToString() == "")
            //{
            //    if (cmbFGCode.Text == "")
            //    {
            //        dgSF.Rows.Clear();
            //    }
            //}
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            cmbDetails.Text = "--Select--";
            reset();
            cmbDetails.Focus();
        }

        public void reset()
        {
            dgSF.Rows.Clear();
            DtpFillDate.Value = Comman_Class_Obj.Select_ServerDate();
            txtPkgWoNo.Text = "";
            txtPrice.Text = "";
            txtBatchCode.Text = "";
            txtSpecification.Text = "";
            ChkAOCPending.Checked = false;
            txtAOCPending.Text = "";
        }

        private void ChkAOCPending_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAOCPending.Checked == true)
            {
                txtAOCPending.Enabled = true;
            }
            else if (ChkAOCPending.Checked == false)
            {
                txtAOCPending.Text = "";
                txtAOCPending.Enabled = false;
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


        private void txtAOCPending_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtAOCPending.Text = textInfo.ToTitleCase(txtAOCPending.Text);
        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            //CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            //TextInfo textInfo = cultureInfo.TextInfo;
            //txtComment.Text = textInfo.ToTitleCase(txtComment.Text);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    DyeKit_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);

                    DyeKit_Class_Obj.batchnofg = txtBatchCode.Text.Trim();
                    DyeKit_Class_Obj.filldatefg = DtpFillDate.Value.ToShortDateString();
                    DyeKit_Class_Obj.pkgwofg = txtPkgWoNo.Text.Trim();
                    DyeKit_Class_Obj.pricefg = txtPrice.Text.Trim();
                    DyeKit_Class_Obj.specificationfg = txtSpecification.Text.Trim();
                    if (ChkAOCPending.Checked == true)
                    {
                        DyeKit_Class_Obj.aocPendfg = 'Y';
                    }
                    else if (ChkAOCPending.Checked == false)
                    {
                        DyeKit_Class_Obj.aocPendfg = 'N';
                    }
                    DyeKit_Class_Obj.commentsaocfg = txtAOCPending.Text.Trim();

                    //-- update record--                
                    DyeKit_Class_Obj.Update_tblFGTLF();

                    //-- first delete previous links and then add new--------

                    //DyeKit_Class_Obj.Delete_tblLinkTLF_FGTLFID();
                    DyeKit_Class_Obj.Delete_tblLinkSF_FGTLFID();

                    foreach (DataGridViewRow row in dgSF.Rows)
                    {
                        if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value)
                        {
                            if (Convert.ToInt64(row.Cells["TLFID"].Value) > 0)
                            {
                                DyeKit_Class_Obj.tlfid = Convert.ToInt64(row.Cells["TLFID"].Value);
                                DyeKit_Class_Obj.kitfgtlfid = 0;//IF TLFID > 0 
                                //Insert FGTLFID and TLFID into tblLinkSF                                
                                DyeKit_Class_Obj.Insert_tblLinkSF();
                            }
                            else if (Convert.ToInt64(row.Cells["FGTLFID"].Value) > 0) // If FGTLFID greater than 0 then get TLFID from tblLinkTLF whose SFFlag =1
                            {
                                DataTable dt = new DataTable();
                                DyeKit_Class_Obj.kitfgtlfid = Convert.ToInt64(row.Cells["FGTLFID"].Value);// To get kit FGTLFID
                                DyeKit_Class_Obj.tlfid = 0;
                                //Insert FGTLFID and TLFID into tblLinkSF
                                DyeKit_Class_Obj.Insert_tblLinkSF();                               
                            }
                        }
                    }

                    //foreach (DataGridViewRow row in dgSF.Rows)
                    //{
                    //    if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value)
                    //    {
                    //        DyeKit_Class_Obj.tlfid = Convert.ToInt64(row.Cells["TLFID"].Value);

                    //        //Insert FGTLFID and TLFID into tblLinkSF
                    //        //DyeKit_Class_Obj.Insert_tblLinkTLF();
                    //        //Insert FGTLFID and TLFID into tblLinkSF 
                    //        DyeKit_Class_Obj.Insert_tblLinkSF();
                    //    }
                    //}

                    MessageBox.Show("Record Saved Successfully..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    BtnReset_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsValid()
        {
            try
            {
               if (cmbDetails.Text == "--Select--" || cmbDetails.SelectedValue == null || cmbDetails.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Select FG Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                    return false;
                }

                if (dgSF.Rows.Count == 0)
                {
                    MessageBox.Show("No linked Formulas...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                    return false;
                }

                bool f = false;
                foreach (DataGridViewRow row in dgSF.Rows)
                {
                    if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value == true)
                    {
                        f = true;
                        break;
                    }
                }
                if (f == false)
                {
                    MessageBox.Show("Select FGCode...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                    return false;
                }

                bool m = true;

                for (int i = 0; i < dgSF.Rows.Count; i++)
                {
                    m = true;
                    foreach (DataGridViewRow row in dgSF.Rows)
                    {
                        if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value == true)
                        {
                            if (row.Cells["FGCode"].Value.ToString() == dgSF["FGCode", i].Value.ToString())
                            {
                                m = true;
                                break;
                            }
                            else
                            {
                                m = false;
                            }
                        }
                    }
                    if (m == false)
                    {
                        MessageBox.Show("Select atleast one FG Code of all FGs...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgSF.Focus();
                        return false;
                    }
                }                

                //------ Select atleast one MfgWo of all Linked Formulas...
                //bool m = true;
                //string formula = "";
                //DataSet ds = new DataSet();
                //ds = DyeKit_Class_Obj.SELECT_tblFgMaster_FormulaNo();
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    m = true;
                //    formula = ds.Tables[0].Rows[i]["FormulaNo"].ToString();
                //    foreach (DataGridViewRow row in dgSF.Rows)
                //    {
                //        if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value == true)
                //        {
                //            if (row.Cells["FormulaNo"].Value.ToString() == ds.Tables[0].Rows[i]["FormulaNo"].ToString())
                //            {
                //                m = true;
                //                break;
                //            }
                //            else
                //            {
                //                m = false;
                //            }
                //        }
                //    }

                //    if (m == false)
                //    {
                //        MessageBox.Show("Select atleast one MfgWo of Formula - " + formula + "...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        dgSF.Focus();
                //        return false;
                //    }
                //}


                if (txtPkgWoNo.Text.Trim() == "")
                {
                    MessageBox.Show("Enter PkgWo", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPkgWoNo.Focus();
                    return false;
                }

                if (txtPrice.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Price", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrice.Focus();
                    return false;
                }

                if (txtBatchCode.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Batch Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchCode.Focus();
                    return false;
                }

                if (txtSpecification.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Specification", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSpecification.Focus();
                    return false;
                }

                if (ChkAOCPending.Checked == true)
                {
                    if (txtAOCPending.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter AOC Pending Comment", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAOCPending.Text = "";
                        txtAOCPending.Focus();
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                
                throw;
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

                DyeKit_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue.ToString());

                if (MessageBox.Show("Are You sure want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    bool b = DyeKit_Class_Obj.Delete_tblFGTLF_FGTLFID();
                    if (b == true)
                    {
                        MessageBox.Show("Record deleted Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgSF_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > 0 && dgSF.Rows.Count > 0)
                {
                    QTMS.Transactions.FrmKitSearch frm = new FrmKitSearch();
                    frm.ShowDialog();

                    if (FrmKitSearch.SearchText != "")
                    {
                        for (int i = 0; i < dgSF.Rows.Count; i++)
                        {
                            if (dgSF[e.ColumnIndex, i].Value.ToString() == FrmKitSearch.SearchText)
                            {
                                dgSF.Rows[i].Selected = true;
                                dgSF.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Blue;
                                dgSF.FirstDisplayedScrollingRowIndex = i;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}