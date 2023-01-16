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
    /// <summary>
    /// Create By - Avinash S
    /// Created On - 18-Feb-2020
    /// Description - Use this form for showing reslut in mettler reading form.
    /// </summary>
    public partial class FrmSPCMaster : Form
    {
        public FrmSPCMaster()
        {
            InitializeComponent();
        }
        # region Varibles
        public bool Modify = false;
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        SPCMaster_Class SPCMaster_Class_Obj = new SPCMaster_Class();
        DataTable DtList = new DataTable();
        # endregion
        private void FrmSPCMaster_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_LineNo();
            Bind_FGCode();
            Bind_List();

            GrpAverage.Enabled = GrpDespersion.Enabled = false;
            PnlGroupNo.Visible = false;
        }

        public void Bind_List()
        {
            try
            {

                DtList = SPCMaster_Class_Obj.Select_tblMettlerSPCMaster();

                List.DataSource = DtList;
                List.DisplayMember = "Details";
                List.ValueMember = "SPCID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }


        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Bind Line No from line No master
        /// </summary>
        DataSet Lineds;
        public void Bind_LineNo()
        {
            Lineds = new DataSet();
            DataRow dr;
            Lineds = LineMaster_Class_Obj.Select_LineMaster();
            dr = Lineds.Tables[0].NewRow();
            dr["LineDesc"] = "--Select--";
            dr["LNo"] = "0";
            Lineds.Tables[0].Rows.InsertAt(dr, 0);

            if (Lineds.Tables[0].Rows.Count > 0)
            {

                CmbLineNo.DataSource = Lineds.Tables[0];
                CmbLineNo.DisplayMember = "LineDesc";
                CmbLineNo.ValueMember = "LNo";
            }
        }

        /// <summary>
        /// Bind FG Code from FG Code master
        /// </summary>
        DataSet FGds;
        public void Bind_FGCode()
        {
            FGds = new DataSet();
            DataRow dr;
            FGds = FinishedGoodMaster_Class_Obj.Select_From_tblFGMaster();
            dr = FGds.Tables[0].NewRow();
            dr["FGCode"] = "--Select--";
            dr["FGNo"] = "0";
            FGds.Tables[0].Rows.InsertAt(dr, 0);

            if (Lineds.Tables[0].Rows.Count > 0)
            {

                CmbFgCode.DataSource = FGds.Tables[0];
                CmbFgCode.DisplayMember = "FGCode";
                CmbFgCode.ValueMember = "FGNo";
            }
        }

        private void CmbFgCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataRow dr;
                FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                DataSet ds2 = new DataSet();
                ds2 = FinishedGoodMaster_Class_Obj.SELECT_tblFgMaster_FormulaNo();
                dr = ds2.Tables[0].NewRow();
                dr["FormulaNo"] = "--Select--";
                dr["FNo"] = "0";
                ds2.Tables[0].Rows.InsertAt(dr, 0);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    CmbFormulaNo.DataSource = ds2.Tables[0];
                    CmbFormulaNo.DisplayMember = "FormulaNo";
                    CmbFormulaNo.ValueMember = "FNo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            CmbLineNo.SelectedValue = 0;
            CmbFgCode.SelectedValue = 0;
            CmbFormulaNo.SelectedValue = 0;
            txtAverageLCL.Text = txtAverageLowerTol.Text = txtAverageTarget.Text = txtAverageUCL.Text = txtAverageUpperTol.Text = txtAverageUSL.Text = txtAverageLSL.Text = string.Empty;
            txtDispersionTarget.Text = txtDispersionUSL.Text = txtSearch.Text = string.Empty;

            Modify = false;
            BtnSave.Enabled= grpDetails.Enabled = true;
            SPCMaster_Class_Obj.spcid = 0;
            BtnModify.Enabled = BtnDelete.Enabled = false;
            txtGroupNo.Text = string.Empty;
            GrpAverage.Enabled = GrpDespersion.Enabled = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToInt64(CmbLineNo.SelectedValue) == 0)
                {
                    MessageBox.Show("Select Line ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbLineNo.Focus();
                    return;
                }
                if (Convert.ToInt64(CmbFgCode.SelectedValue) == 0)
                {
                    MessageBox.Show("Select FG Code ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbFgCode.Focus();
                    return;
                }
                if (Convert.ToInt64(CmbFormulaNo.SelectedValue) == 0)
                {
                    MessageBox.Show("Select Formula ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbFormulaNo.Focus();
                    return;
                }
                if (txtGroupNo.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Enter Group No.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGroupNo.Focus();
                    return;
                }
                if (txtAverageLCL.Text.Trim() == string.Empty || txtAverageLowerTol.Text.Trim() == string.Empty || txtAverageLSL.Text.Trim() == string.Empty || txtAverageTarget.Text.Trim() == string.Empty || txtAverageUCL.Text.Trim() == string.Empty || txtAverageUpperTol.Text.Trim() == string.Empty || txtAverageUSL.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Input values of control chart of average (GM)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAverageUSL.Focus();
                    return;
                }
                if (txtDispersionTarget.Text.Trim() == string.Empty || txtDispersionUSL.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Input values of control chart of dispersion (GM)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDispersionTarget.Focus();
                    return;
                }

                SPCMaster_Class_Obj.lno = Convert.ToInt64(CmbLineNo.SelectedValue);
                SPCMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                SPCMaster_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                SPCMaster_Class_Obj.groupno = Convert.ToInt32(txtGroupNo.Text.Trim());

                SPCMaster_Class_Obj.averageUSL = txtAverageUSL.Text.Trim();
                SPCMaster_Class_Obj.averageUCL = txtAverageUCL.Text.Trim();
                SPCMaster_Class_Obj.averageUpperTOL = txtAverageUpperTol.Text.Trim();
                SPCMaster_Class_Obj.averageLSL = txtAverageLSL.Text.Trim();
                SPCMaster_Class_Obj.averageLCL = txtAverageLCL.Text.Trim();
                SPCMaster_Class_Obj.averageLowerTOL = txtAverageLowerTol.Text.Trim();
                SPCMaster_Class_Obj.averageTarget = txtAverageTarget.Text.Trim();

                SPCMaster_Class_Obj.dispersionTarget = txtDispersionTarget.Text.Trim();
                SPCMaster_Class_Obj.dispersionUSL = txtDispersionUSL.Text.Trim();

                SPCMaster_Class_Obj.createdBy = FrmMain.LoginID;

                if (Modify)//for update
                {
                    bool Result = SPCMaster_Class_Obj.Update_tblMettlerSPCMaster();
                    if (Result == true)
                    {
                        MessageBox.Show("Record Update Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnReset_Click(sender, e);
                        Bind_List();
                    }
                }
                else //for insert
                {
                     DataTable Dt = SPCMaster_Class_Obj.Select_tblMettlerSPCMaster_Exist();
                     if (Dt.Rows.Count > 0)
                     {
                         if (Dt.Rows[0]["Active"].ToString() == "1")
                         {
                             MessageBox.Show("Record already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             BtnReset_Click(sender, e);
                         }
                         if (Dt.Rows[0]["Active"].ToString() == "0")
                         {
                             //MessageBox.Show("Record already exists in deactivated(delete). Do you want activate this record.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             if (MessageBox.Show("Record already exists in deactivated(delete). Do you want activate this record.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                             {
                                 bool Result = SPCMaster_Class_Obj.Update_tblMettlerSPCMaster_Activate();
                                 if (Result == true)
                                 {
                                     MessageBox.Show("Record Activate Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);                                     
                                     Bind_List();
                                 }
                             }
                             BtnReset_Click(sender, e);
                         }
                     }
                     else
                     {
                         bool Result = SPCMaster_Class_Obj.Insert_tblMettlerSPCMaster();
                         if (Result == true)
                         {
                             MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             BtnReset_Click(sender, e);
                             Bind_List();
                         }
                     }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void List_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // txtSearch.Text = Convert.ToString(List.Text);
                Modify = true;
                BtnDelete.Enabled = true;
                SPCMaster_Class_Obj.spcid = Convert.ToInt32(List.SelectedValue.ToString());
                Bind_Information();
                //grpDetails.Enabled = false;
                BtnSave.Enabled = false;
                BtnModify.Enabled = BtnModify.Enabled = true;
                CmbFgCode.Enabled = CmbFormulaNo.Enabled = CmbLineNo.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_Information()
        {
            DataTable Dt = SPCMaster_Class_Obj.Select_tblMettlerSPCMaster_ByID();
            if (Dt.Rows.Count > 0)
            {
                CmbLineNo.SelectedValue = Convert.ToInt64(Dt.Rows[0]["LNo"].ToString());
                CmbFgCode.SelectedValue = Convert.ToInt64(Dt.Rows[0]["FGNo"].ToString());

                #region BindFormula
                DataRow dr;
                FinishedGoodMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                DataSet ds2 = new DataSet();
                ds2 = FinishedGoodMaster_Class_Obj.SELECT_tblFgMaster_FormulaNo();
                dr = ds2.Tables[0].NewRow();
                dr["FormulaNo"] = "--Select--";
                dr["FNo"] = "0";
                ds2.Tables[0].Rows.InsertAt(dr, 0);

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    CmbFormulaNo.DataSource = ds2.Tables[0];
                    CmbFormulaNo.DisplayMember = "FormulaNo";
                    CmbFormulaNo.ValueMember = "FNo";
                }
                #endregion

                txtGroupNo.Text = Dt.Rows[0]["GroupNo"].ToString();

                CmbFormulaNo.SelectedValue = Convert.ToInt64(Dt.Rows[0]["FNo"].ToString());
                txtAverageUSL.Text = Dt.Rows[0]["AverageUSL"].ToString();
                txtAverageUCL.Text = Dt.Rows[0]["AverageUCL"].ToString();
                txtAverageUpperTol.Text = Dt.Rows[0]["AverageUpperTol"].ToString();
                txtAverageLSL.Text = Dt.Rows[0]["AverageLSL"].ToString();
                txtAverageLCL.Text = Dt.Rows[0]["AverageLCL"].ToString();
                txtAverageLowerTol.Text = Dt.Rows[0]["AverageLowerTol"].ToString();
                txtAverageTarget.Text = Dt.Rows[0]["AverageTarget"].ToString();

                txtDispersionTarget.Text = Dt.Rows[0]["DispersionTarget"].ToString();
                txtDispersionUSL.Text = Dt.Rows[0]["DispersionUSL"].ToString();
            }
        }

        private void List_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                List_DoubleClick(sender, e);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchString = txtSearch.Text;
            DtList.DefaultView.RowFilter = "Details like  '" + searchString + "%'";
            List.DataSource = DtList;

            List.DisplayMember = "Details";
            List.ValueMember = "SPCID";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    txtSearch.Text = Convert.ToString(List.Text);
                    Modify = true;
                    BtnDelete.Enabled = true;
                    SPCMaster_Class_Obj.spcid = Convert.ToInt32(List.SelectedValue.ToString());
                    Bind_Information();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (SPCMaster_Class_Obj.spcid != 0)
                {
                    if (MessageBox.Show("Are You Sure Want To Delete", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SPCMaster_Class_Obj.spcid = Convert.ToInt32(List.SelectedValue.ToString());
                        SPCMaster_Class_Obj.createdBy = FrmMain.LoginID;
                        bool b = SPCMaster_Class_Obj.Delete_tblMettlerSPCMaster();
                        if (b == true)
                        {
                            MessageBox.Show("Record Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Bind_List();
                            BtnReset_Click(sender, e);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry You Can't delete this Record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {            
            Modify = true;            
            BtnSave.Enabled = true;
            BtnModify.Enabled = BtnModify.Enabled = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                FormulaNoMaster_Class objFormulaNoMaster_Class = new FormulaNoMaster_Class();

                DataTable dt = new DataTable();
                dt = SPCMaster_Class_Obj.Select_tblMettlerSPCMaster_Export();

                ExportToExcel objExport = new ExportToExcel();
                objExport.GenerateExcelFile(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtAverageUSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtGroupNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtGroupNo_Leave(object sender, EventArgs e)
        {
            checkGRoupNoExiest();
        }

        public void checkGRoupNoExiest()
        {
            txtAverageLCL.Text = txtAverageLowerTol.Text = txtAverageTarget.Text = txtAverageUCL.Text = txtAverageUpperTol.Text = txtAverageUSL.Text = txtAverageLSL.Text = string.Empty;
            txtDispersionTarget.Text = txtDispersionUSL.Text = txtSearch.Text = string.Empty;

            SPCMaster_Class_Obj.groupno = Convert.ToInt32(txtGroupNo.Text.Trim());
            DataTable Dt = SPCMaster_Class_Obj.Select_tblMettlerSPCMaster_ByGroupNo();
            if (Dt.Rows.Count > 0)
            {
                GrpAverage.Enabled = GrpDespersion.Enabled = false;

                txtAverageUSL.Text = Dt.Rows[0]["AverageUSL"].ToString();
                txtAverageUCL.Text = Dt.Rows[0]["AverageUCL"].ToString();
                txtAverageUpperTol.Text = Dt.Rows[0]["AverageUpperTol"].ToString();
                txtAverageLSL.Text = Dt.Rows[0]["AverageLSL"].ToString();
                txtAverageLCL.Text = Dt.Rows[0]["AverageLCL"].ToString();
                txtAverageLowerTol.Text = Dt.Rows[0]["AverageLowerTol"].ToString();
                txtAverageTarget.Text = Dt.Rows[0]["AverageTarget"].ToString();

                txtDispersionTarget.Text = Dt.Rows[0]["DispersionTarget"].ToString();
                txtDispersionUSL.Text = Dt.Rows[0]["DispersionUSL"].ToString();

            }
            else
            {
                GrpAverage.Enabled = GrpDespersion.Enabled = true;
                txtAverageUSL.Focus();
            }
        }

        private void GrpView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PnlGroupNo.Visible = true;
            DataTable Dt = SPCMaster_Class_Obj.Select_tblMettlerSPCMaster_GroupNo();
            if (Dt.Rows.Count > 0)
            {
                DgvGroupNo.DataSource = Dt;                
            }
            else
                DgvGroupNo.DataSource = null;   
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PnlGroupNo.Visible = false;
        }
    }
}