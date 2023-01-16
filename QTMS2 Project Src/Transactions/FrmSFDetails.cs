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
    public partial class FrmSFDetails : Form
    {
        public FrmSFDetails()
        {
            InitializeComponent();
        }

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        DyeKit_Class DyeKit_Class_Obj = new DyeKit_Class();
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        FinishedGoodMaster_Class FinishedGoodMaster_Obj = new FinishedGoodMaster_Class();
        private static FrmSFDetails frmSF_Obj = null;
        public static FrmSFDetails GetInstance()
        {
            if (frmSF_Obj == null)
            {
                frmSF_Obj = new FrmSFDetails();
            }
            return frmSF_Obj;
        }

        private void FrmSFDetails_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_FGCode();
            Bind_LineNo();
            BtnReset_Click(sender, e);
            cmbFGCode.Focus();
        }

        public void Bind_FGCode()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = DyeKit_Class_Obj.Select_SFDetails();
                //ds = FinishedGoodMaster_Obj.Select_From_tblFGMaster();
                dr = ds.Tables[0].NewRow();
                dr["FGCode"] = "--Select--";
                dr["FGNo"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbFGCode.DataSource = ds.Tables[0];
                cmbFGCode.ValueMember = "FGNo";
                cmbFGCode.DisplayMember = "FGCode";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_LineNo()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = LineMaster_Class_Obj.Select_LineMaster();
            dr = ds.Tables[0].NewRow();
            dr["LineDesc"] = "--Select--";
            dr["LNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {

                CmbLineNo.DataSource = ds.Tables[0];
                CmbLineNo.DisplayMember = "LineDesc";
                CmbLineNo.ValueMember = "LNo";
            }
        }

        private void cmbFGCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dgSF.Rows.Clear();

                if (cmbFGCode.SelectedValue != null && cmbFGCode.SelectedValue.ToString() != "")
                {
                    DyeKit_Class_Obj.fgnokit = Convert.ToInt64(cmbFGCode.SelectedValue);

                    //IF FGCode is Kit then it returns records which is saved as kit in line packig  
                    //ds = DyeKit_Class_Obj.Select_Formula_MfgWo_SF();
                    //IF FGCode is Semifinished then it return FGCode, Track code & line number
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
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbFGCode_Leave(object sender, EventArgs e)
        {
            //if (cmbFGCode.Text == "--Select--" || cmbFGCode.SelectedValue == null || cmbFGCode.SelectedValue.ToString() == "")
            //{
            //    if (cmbFGCode.Text == "")
            //    {
            //        dgKit.Rows.Clear();
            //    }
            //}
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            dgSF.Rows.Clear();
            CmbLineNo.Text = "--Select--";
            cmbFGCode.Text = "--Select--";
            DtpFillDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpTrackCode.Value = Comman_Class_Obj.Select_ServerDate();
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
                txtAOCPending.Focus();
            }
            else
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
                if (cmbFGCode.Text == "--Select--" || cmbFGCode.SelectedValue == null || cmbFGCode.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Select FG Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbFGCode.Focus();
                    return;
                }

                if (dgSF.Rows.Count == 0)
                {
                    MessageBox.Show("No linked Formulas...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbFGCode.Focus();
                    return;
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
                    cmbFGCode.Focus();
                    return;
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
                        return;
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
                //        return;
                //    }
                //}



                if (CmbLineNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Line No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbLineNo.Focus();
                    return;
                }

                if (txtPkgWoNo.Text.Trim() == "")
                {
                    MessageBox.Show("Enter PkgWo", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPkgWoNo.Focus();
                    return;
                }

                if (txtPrice.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Price", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPrice.Focus();
                    return;
                }

                if (txtBatchCode.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Batch Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBatchCode.Focus();
                    return;
                }

                if (txtSpecification.Text.Trim() == "")
                {
                    MessageBox.Show("Enter Specification", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSpecification.Focus();
                    return;
                }

                if (ChkAOCPending.Checked == true)
                {
                    if (txtAOCPending.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter AOC Pending Comment", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAOCPending.Text = "";
                        txtAOCPending.Focus();
                        return;
                    }
                }

                DyeKit_Class_Obj.fgnokit = Convert.ToInt64(cmbFGCode.SelectedValue);
                DyeKit_Class_Obj.lnofg = Convert.ToInt32(CmbLineNo.SelectedValue);
                DyeKit_Class_Obj.trackcodefg = DtpTrackCode.Value.ToShortDateString();

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


                //check whether combination of TrackCode,LNo,FGNo already exists in tblFGTLF 
                DataSet dsFGTLFID = new DataSet();
                dsFGTLFID = DyeKit_Class_Obj.Select_tblFGTLF_TLF();
                if (dsFGTLFID.Tables[0].Rows.Count > 0)
                {
                    //DyeKit_Class_Obj.fgtlfid = Convert.ToInt64(dsFGTLFID.Tables[0].Rows[0]["FGTLFID"]);
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    BtnReset_Click(sender, e);
                    return;
                }
                else
                {
                    DyeKit_Class_Obj.fgtlfid = DyeKit_Class_Obj.Insert_tblFGTLF();
                }

                foreach (DataGridViewRow row in dgSF.Rows)
                {
                    if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value)
                    {
                        if (Convert.ToInt64(row.Cells["TLFID"].Value) > 0)
                        {
                            DyeKit_Class_Obj.tlfid = Convert.ToInt64(row.Cells["TLFID"].Value);
                            DyeKit_Class_Obj.kitfgtlfid = 0;//IF TLFID > 0 
                            //Insert FGTLFID and TLFID into tblLinkSF
                            //DyeKit_Class_Obj.Insert_tblLinkTLF();
                            DyeKit_Class_Obj.Insert_tblLinkSF();
                        }
                        else if (Convert.ToInt64(row.Cells["FGTLFID"].Value) > 0) // If FGTLFID greater than 0 then get TLFID from tblLinkTLF whose SFFlag =1
                        {
                            DataTable dt = new DataTable();
                            DyeKit_Class_Obj.kitfgtlfid = Convert.ToInt64(row.Cells["FGTLFID"].Value);// To get kit FGTLFID
                            DyeKit_Class_Obj.tlfid = 0;
                            //Insert FGTLFID and TLFID into tblLinkSF
                            DyeKit_Class_Obj.Insert_tblLinkSF();
                            //dt = DyeKit_Class_Obj.Select_tblLinkTLF_FGTLFID_SFFlag();
                            //if (dt.Rows.Count > 0)
                            //{
                            //    foreach (DataRow dr in dt.Rows)
                            //    {
                            //        DyeKit_Class_Obj.tlfid = Convert.ToInt64(dr["TLFID"]);
                            //        //Insert FGTLFID and TLFID into tblLinkSF
                            //        DyeKit_Class_Obj.Insert_tblLinkSF();
                            //    }
                            //}
                        }
                    }
                }

                MessageBox.Show("Record Saved Successfully..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                BtnReset_Click(sender, e);
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
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);                
            }
        }

    }
}