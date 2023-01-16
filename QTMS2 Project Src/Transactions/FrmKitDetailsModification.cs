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
    public partial class FrmKitDetailsModification : Form
    {
        public FrmKitDetailsModification()
        {
            InitializeComponent();
        }

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        DyeKit_Class DyeKit_Class_Obj = new DyeKit_Class();
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();

        private static FrmKitDetailsModification frmKitDetailsModification_Obj = null;
        public static FrmKitDetailsModification GetInstance()
        {
            if (frmKitDetailsModification_Obj == null)
            {
                frmKitDetailsModification_Obj = new FrmKitDetailsModification();
            }
            return frmKitDetailsModification_Obj;
        }

        private void FrmKitDetailsModification_Load(object sender, EventArgs e)
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
                ds = DyeKit_Class_Obj.Select_ModificationKitDetails();
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

                    dslnk = DyeKit_Class_Obj.Select_tblLinkTLF_FGTLFID();
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
                    /*
                    ds = DyeKit_Class_Obj.Select_Formula_MfgWo_Kit();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgKit.Rows.Add();
                        dgKit["TLFID", dgKit.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TLFID"].ToString();
                        dgKit["FormulaNo", dgKit.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["FormulaNo"].ToString();
                        dgKit["MfgWo", dgKit.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MfgWo"].ToString();
                        dgKit["FGCode", dgKit.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["FGCode"].ToString();
                        dgKit["TrackCode", dgKit.Rows.Count - 1].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["TrackCode"]).ToShortDateString();
                        dgKit["LineDesc", dgKit.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["LineDesc"].ToString();
                        dgKit["PkgWO", dgKit.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["PkgWO"].ToString();
                        dgKit["FillDate", dgKit.Rows.Count - 1].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["FillDate"]).ToShortDateString();
                        dgKit["Price", dgKit.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Price"].ToString();
                        dgKit["specification", dgKit.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["specification"].ToString();
                        dgKit["AOCPend", dgKit.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AOCPend"].ToString();
                        dgKit["Status", dgKit.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Status"].ToString();
                    }
                    */
                    DataTable dt = new DataTable();
                    dt = DyeKit_Class_Obj.Select_tblLinkTLF_FGTLFID_SFFlag();
                    if (dt.Rows.Count > 0)
                        ChkSF.Checked = true;
                    else
                        ChkSF.Checked = false;

                    /*
                    for (int i = 0; i < dslnk.Tables[0].Rows.Count; i++)
                    {
                        foreach (DataGridViewRow row in dgKit.Rows)
                        {
                            if (row.Cells["TLFID"].Value.ToString() == dslnk.Tables[0].Rows[i]["TLFID"].ToString())
                            {
                                row.Cells["Mark"].Value = true;
                                break;
                            }
                        }
                    }

                    dgKit.Sort(dgKit.Columns["Mark"], ListSortDirection.Descending);
                    */
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
            //        dgKit.Rows.Clear();
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
            dgKit.Rows.Clear();
            DtpFillDate.Value = Comman_Class_Obj.Select_ServerDate();
            txtPkgWoNo.Text = "";
            txtPrice.Text = "";
            txtBatchCode.Text = "";
            txtSpecification.Text = "";
            ChkAOCPending.Checked = false;
            txtAOCPending.Text = "";
            ChkSF.Checked = false;
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
                if (cmbDetails.Text == "--Select--" || cmbDetails.SelectedValue == null || cmbDetails.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Select FG Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                    return;
                }

                if (dgKit.Rows.Count == 0)
                {
                    MessageBox.Show("No linked Formulas...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                    return;
                }

                bool f = false;
                foreach (DataGridViewRow row in dgKit.Rows)
                {
                    //if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value == true)
                    if (row.Cells["Mark"].Value != null && row.Cells["Mark"].Value.ToString() == "1")
                    {
                        f = true;
                        break;
                    }
                }
                if (f == false)
                {
                    MessageBox.Show("Select Formulas to link with FGCode...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbDetails.Focus();
                    return;
                }

                //bool m = true;               

                //for (int i = 0; i < dgKit.Rows.Count; i++)
                //{
                //    m = true;
                //    foreach (DataGridViewRow row in dgKit.Rows) 
                //    {
                //        if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value == true)
                //        {
                //            if (row.Cells["FormulaNo"].Value.ToString() == dgKit["FormulaNo", i].Value.ToString())
                //            {
                //                m = true;
                //                break;
                //            }
                //            else
                //            {
                //                m=false;
                //            }
                //        }
                //    }
                //    if(m ==false)
                //    {
                //        MessageBox.Show("Select atleast one MfgWo of all Formulas...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        dgKit.Focus();
                //        return;
                //    }
                //}                

                
                //------ Select atleast one MfgWo of all Linked Formulas...
                bool m = true;
                string formula = "";
                DataSet ds = new DataSet();
                ds = DyeKit_Class_Obj.SELECT_tblFgMaster_FormulaNo();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    m = true;
                    formula = ds.Tables[0].Rows[i]["FormulaNo"].ToString();
                    foreach (DataGridViewRow row in dgKit.Rows)
                    {
                        //if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value == true)
                        if (Convert.ToString(row.Cells["Mark"].Value) == "1")// && (bool)row.Cells["Mark"].Value == true)
                        {
                            if (row.Cells["FormulaNo"].Value.ToString() == ds.Tables[0].Rows[i]["FormulaNo"].ToString())
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
                        MessageBox.Show("Select atleast one MfgWo of Formula - " + formula + "...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgKit.Focus();
                        return;
                    }
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

                DyeKit_Class_Obj.Delete_tblLinkTLF_FGTLFID();

                foreach (DataGridViewRow row in dgKit.Rows)
                {
                    ////if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value)
                    ////{
                    ////    DyeKit_Class_Obj.tlfid = Convert.ToInt64(row.Cells["TLFID"].Value);

                    ////    //Insert FGTLFID and TLFID into tblLinkTLF 
                    ////    DyeKit_Class_Obj.Insert_tblLinkTLF();
                    ////}

                    //if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value && row.Cells["SubContractor"].Value.ToString() == "No")
                    if (row.Cells["SubContractor"].Value.ToString() == "No")
                    {
                        DyeKit_Class_Obj.tlfid = Convert.ToInt64(row.Cells["TLFID"].Value);

                        //Insert FGTLFID and TLFID into tblLinkTLF 
                        DyeKit_Class_Obj.Insert_tblLinkTLF();
                    }
                    //if (row.Cells["Mark"].Value != null && (bool)row.Cells["Mark"].Value && row.Cells["SubContractor"].Value.ToString() == "Yes")
                    if (row.Cells["SubContractor"].Value.ToString() == "Yes")
                    {
                        DyeKit_Class_Obj.tlfid = Convert.ToInt64(row.Cells["TLFID"].Value);

                        //Insert FGTLFID and TLFID into tblLinkTLF 
                        DyeKit_Class_Obj.Insert_tblLinkTLF_Sub();
                    }
                }

                MessageBox.Show("Record Saved Successfully..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                BtnReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
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
                MessageBox.Show("Sorry you Can't Delete this Record", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgKit_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0 && dgKit.Rows.Count > 0)
            {
                QTMS.Transactions.FrmKitSearch frm = new FrmKitSearch();
                frm.ShowDialog();

                if (FrmKitSearch.SearchText != "")
                {
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        if (dgKit[e.ColumnIndex, i].Value.ToString() == FrmKitSearch.SearchText)
                        {
                            dgKit.Rows[i].Selected = true;
                            dgKit.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Blue;
                            dgKit.FirstDisplayedScrollingRowIndex = i;
                        }
                    }
                }
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnplnLorealOK_Click(object sender, EventArgs e)
        {
            /*
            //------ Select atleast one MfgWo of all Linked Formulas...
            bool m = true;
            string formula = "";
            DataSet ds = new DataSet();
            ds = DyeKit_Class_Obj.SELECT_tblFgMaster_FormulaNo();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                m = true;
                formula = ds.Tables[0].Rows[i]["FormulaNo"].ToString();
                foreach (DataGridViewRow row in dgkitLoreal.Rows)
                {
                    if (row.Cells["Mark_L"].Value != null && (bool)row.Cells["Mark_L"].Value == true)
                    {
                        if (row.Cells["FormulaNo_L"].Value.ToString() == ds.Tables[0].Rows[i]["FormulaNo"].ToString())
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
                    MessageBox.Show("Select atleast one MfgWo of Formula - " + formula + "...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgKit.Focus();
                    return;
                }
            }
            */
            int checkduplicate = 0;
            foreach (DataGridViewRow row in dgkitLoreal.Rows)
            {
                
                if (row.Cells["Mark_L"].Value != null && (bool)row.Cells["Mark_L"].Value == true)
                {
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        if (dgKit.Rows[i].Cells["TLFID"].Value.ToString() == row.Cells["TLFID_L"].Value.ToString())
                        {
                            checkduplicate = 1;
                            break;
                        }
                    }

                    if (checkduplicate == 1)
                    { }
                    else
                    {
                        dgKit.Rows.Add();
                        dgKit["Mark", dgKit.Rows.Count - 1].Value = 1;
                        dgKit["SubContractor", dgKit.Rows.Count - 1].Value = "No";
                        dgKit["TLFID", dgKit.Rows.Count - 1].Value = row.Cells["TLFID_L"].Value.ToString();
                        dgKit["FormulaNo", dgKit.Rows.Count - 1].Value = row.Cells["FormulaNo_L"].Value.ToString();
                        dgKit["MfgWo", dgKit.Rows.Count - 1].Value = row.Cells["MfgWo_L"].Value.ToString();
                        dgKit["FGCode", dgKit.Rows.Count - 1].Value = row.Cells["FGCode_L"].Value.ToString();
                        dgKit["TrackCode", dgKit.Rows.Count - 1].Value = row.Cells["TrackCode_L"].Value.ToString(); //Convert.ToDateTime(ds.Tables[0].Rows[i]["TrackCode"]).ToShortDateString();
                        dgKit["LineDesc", dgKit.Rows.Count - 1].Value = row.Cells["LineDesc_L"].Value.ToString();
                        dgKit["PkgWO", dgKit.Rows.Count - 1].Value = row.Cells["PkgWO_L"].Value.ToString();
                        dgKit["FillDate", dgKit.Rows.Count - 1].Value = row.Cells["FillDate_L"].Value.ToString(); //Convert.ToDateTime(ds.Tables[0].Rows[i]["FillDate"]).ToShortDateString();
                        dgKit["Price", dgKit.Rows.Count - 1].Value = row.Cells["Price_L"].Value.ToString();
                        dgKit["specification", dgKit.Rows.Count - 1].Value = row.Cells["specification_L"].Value.ToString();
                        dgKit["AOCPend", dgKit.Rows.Count - 1].Value = row.Cells["AOCPend_L"].Value.ToString();
                        dgKit["Status", dgKit.Rows.Count - 1].Value = row.Cells["Status_L"].Value.ToString();
                    }
                    checkduplicate = 0;
                }
            }

            pnlLoreal.Visible = false;
        }

        private void btnLoreal_Click(object sender, EventArgs e)
        {
            try
            {
                //reset();
                Cursor.Current = Cursors.WaitCursor;
                DataSet ds = new DataSet();
                DataSet dslnk = new DataSet();

                if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "")
                {

                    DyeKit_Class_Obj.fgtlfid = Convert.ToInt64(cmbDetails.SelectedValue);

                    dslnk = DyeKit_Class_Obj.Select_tblLinkTLF_FGTLFID();
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

                    ds = DyeKit_Class_Obj.Select_Formula_MfgWo_Kit();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgkitLoreal.Rows.Add();
                        dgkitLoreal["TLFID_L", dgkitLoreal.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TLFID"].ToString();
                        dgkitLoreal["FormulaNo_L", dgkitLoreal.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["FormulaNo"].ToString();
                        dgkitLoreal["MfgWo_L", dgkitLoreal.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MfgWo"].ToString();
                        dgkitLoreal["FGCode_L", dgkitLoreal.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["FGCode"].ToString();
                        dgkitLoreal["TrackCode_L", dgkitLoreal.Rows.Count - 1].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["TrackCode"]).ToShortDateString();
                        dgkitLoreal["LineDesc_L", dgkitLoreal.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["LineDesc"].ToString();
                        dgkitLoreal["PkgWO_L", dgkitLoreal.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["PkgWO"].ToString();
                        dgkitLoreal["FillDate_L", dgkitLoreal.Rows.Count - 1].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["FillDate"]).ToShortDateString();
                        dgkitLoreal["Price_L", dgkitLoreal.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Price"].ToString();
                        dgkitLoreal["specification_L", dgkitLoreal.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["specification"].ToString();
                        dgkitLoreal["AOCPend_L", dgkitLoreal.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AOCPend"].ToString();
                        dgkitLoreal["Status_L", dgkitLoreal.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Status"].ToString();
                    }
                    /*
                    DataTable dt = new DataTable();
                    dt = DyeKit_Class_Obj.Select_tblLinkTLF_FGTLFID_SFFlag();
                    if (dt.Rows.Count > 0)
                        ChkSF.Checked = true;
                    else
                        ChkSF.Checked = false;
                    */

                    for (int i = 0; i < dslnk.Tables[0].Rows.Count; i++)
                    {
                        foreach (DataGridViewRow row in dgkitLoreal.Rows)
                        {
                            if (row.Cells["TLFID_L"].Value.ToString() == dslnk.Tables[0].Rows[i]["TLFID"].ToString())
                            {
                                row.Cells["Mark_L"].Value = true;
                                break;
                            }
                        }
                    }

                    dgkitLoreal.Sort(dgkitLoreal.Columns["Mark_L"], ListSortDirection.Descending);
                }
                pnlLoreal.Visible = true;

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
                //throw ex;
            }
        }

        private void btnplnLorealCancel_Click(object sender, EventArgs e)
        {
            pnlLoreal.Visible = false;
        }

        private void btnSubContractor_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            dgkitSub.Rows.Clear();

            if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "")
            {
                DataSet dslnk = new DataSet();
                dslnk = DyeKit_Class_Obj.Select_tblLinkTLF_FGTLFID_SubContractor();
                if (dslnk.Tables[0].Rows.Count > 0)
                {
                    DyeKit_Class_Obj.fgnokit = Convert.ToInt32(dslnk.Tables[0].Rows[0]["FGNoFG"]);
                }


                ds = DyeKit_Class_Obj.Select_Formula_MfgWo_Kit_Subcontractor();
                dgkitSub.Columns["LineDesc_S"].HeaderText = "Sub Contractor";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgkitSub.Rows.Add();
                    dgkitSub["TLFID_S", dgkitSub.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TLFID"].ToString();
                    dgkitSub["FormulaNo_S", dgkitSub.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["FormulaNo"].ToString();
                    dgkitSub["MfgWo_S", dgkitSub.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["MfgWo"].ToString();
                    dgkitSub["FGCode_S", dgkitSub.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["FGCode"].ToString();
                    dgkitSub["TrackCode_S", dgkitSub.Rows.Count - 1].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["TrackCode"]).ToShortDateString();
                    dgkitSub["LineDesc_S", dgkitSub.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["FGSupplierName"].ToString();
                    dgkitSub["PkgWO_S", dgkitSub.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["PkgWO"].ToString();
                    dgkitSub["FillDate_S", dgkitSub.Rows.Count - 1].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["FillDate"]).ToShortDateString();
                    dgkitSub["Price_S", dgkitSub.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Price"].ToString();
                    dgkitSub["specification_S", dgkitSub.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["specification"].ToString();
                    dgkitSub["AOCPend_S", dgkitSub.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AOCPend"].ToString();
                    dgkitSub["Status_S", dgkitSub.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Status"].ToString();

                }
                dgkitSub.Sort(dgkitSub.Columns["MfgWo_S"], ListSortDirection.Ascending);



                for (int i = 0; i < dslnk.Tables[0].Rows.Count; i++)
                {
                    foreach (DataGridViewRow row in dgkitSub.Rows)
                    {
                        if (row.Cells["TLFID_S"].Value.ToString() == dslnk.Tables[0].Rows[i]["TLFID_S"].ToString())
                        {
                            row.Cells["Mark_S"].Value = true;
                            break;
                        }
                    }
                }

                dgkitSub.Sort(dgkitSub.Columns["Mark_S"], ListSortDirection.Descending);


                pnlSubcontractor.Visible = true;
            }
        }

        private void btnpnlSubCancel_Click(object sender, EventArgs e)
        {
            pnlSubcontractor.Visible = false;
        }

        private void btnPnlSubOK_Click(object sender, EventArgs e)
        {
            int checkduplicate = 0;
            foreach (DataGridViewRow row in dgkitSub.Rows)
            {
                if (row.Cells["Mark_S"].Value != null && (bool)row.Cells["Mark_S"].Value == true)
                {
                    for (int i = 0; i < dgKit.Rows.Count; i++)
                    {
                        if (dgKit.Rows[i].Cells["TLFID"].Value.ToString() == row.Cells["TLFID_S"].Value.ToString())
                        {
                            checkduplicate = 1;
                            break;
                        }
                    }

                    if (checkduplicate == 1)
                    { }
                    else
                    {
                        dgKit.Rows.Add();
                        dgKit["Mark", dgKit.Rows.Count - 1].Value = 1;
                        dgKit["SubContractor", dgKit.Rows.Count - 1].Value = "Yes";
                        dgKit["TLFID", dgKit.Rows.Count - 1].Value = row.Cells["TLFID_S"].Value.ToString();
                        dgKit["FormulaNo", dgKit.Rows.Count - 1].Value = row.Cells["FormulaNo_S"].Value.ToString();
                        dgKit["MfgWo", dgKit.Rows.Count - 1].Value = row.Cells["MfgWo_S"].Value.ToString();
                        dgKit["FGCode", dgKit.Rows.Count - 1].Value = row.Cells["FGCode_S"].Value.ToString();
                        dgKit["TrackCode", dgKit.Rows.Count - 1].Value = row.Cells["TrackCode_S"].Value.ToString(); //Convert.ToDateTime(ds.Tables[0].Rows[i]["TrackCode"]).ToShortDateString();
                        dgKit["LineDesc", dgKit.Rows.Count - 1].Value = row.Cells["LineDesc_S"].Value.ToString();
                        dgKit["PkgWO", dgKit.Rows.Count - 1].Value = row.Cells["PkgWO_S"].Value.ToString();
                        dgKit["FillDate", dgKit.Rows.Count - 1].Value = row.Cells["FillDate_S"].Value.ToString(); //Convert.ToDateTime(ds.Tables[0].Rows[i]["FillDate"]).ToShortDateString();
                        dgKit["Price", dgKit.Rows.Count - 1].Value = row.Cells["Price_S"].Value.ToString();
                        dgKit["specification", dgKit.Rows.Count - 1].Value = row.Cells["specification_S"].Value.ToString();
                        dgKit["AOCPend", dgKit.Rows.Count - 1].Value = row.Cells["AOCPend_S"].Value.ToString();
                        dgKit["Status", dgKit.Rows.Count - 1].Value = row.Cells["Status_S"].Value.ToString();
                    }
                    checkduplicate = 0;
                }
            }

            pnlSubcontractor.Visible = false;
        }

        private void dgkitLoreal_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0 && dgkitLoreal.Rows.Count > 0)
            {
                QTMS.Transactions.FrmKitSearch frm = new FrmKitSearch();
                frm.ShowDialog();

                if (FrmKitSearch.SearchText != "")
                {
                    for (int i = 0; i < dgkitLoreal.Rows.Count; i++)
                    {
                        if (dgkitLoreal[e.ColumnIndex, i].Value.ToString() == FrmKitSearch.SearchText)
                        {
                            dgkitLoreal.Rows[i].Selected = true;
                            dgkitLoreal.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Blue;
                            dgkitLoreal.FirstDisplayedScrollingRowIndex = i;
                        }
                    }
                }
            }
        }

        private void dgkitSub_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex > 0 && dgkitSub.Rows.Count > 0)
            {
                QTMS.Transactions.FrmKitSearch frm = new FrmKitSearch();
                frm.ShowDialog();

                if (FrmKitSearch.SearchText != "")
                {
                    for (int i = 0; i < dgkitSub.Rows.Count; i++)
                    {
                        if (dgkitSub[e.ColumnIndex, i].Value.ToString() == FrmKitSearch.SearchText)
                        {
                            dgkitSub.Rows[i].Selected = true;
                            dgkitSub.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Blue;
                            dgkitSub.FirstDisplayedScrollingRowIndex = i;
                        }
                    }
                }
            }
        }










    }
}