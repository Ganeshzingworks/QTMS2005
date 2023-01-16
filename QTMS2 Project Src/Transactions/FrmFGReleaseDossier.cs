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
    public partial class FrmFGReleaseDossier : Form
    {

        public FrmFGReleaseDossier()
        {
            InitializeComponent();
        }

        #region variables
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();
        BusinessFacade.Transactions.FGReleaseDossier FGReleaseDossier_Obj = new BusinessFacade.Transactions.FGReleaseDossier();
        DataSet dsMfg = new DataSet();
        #endregion

        //get the active instance of the form
        private static FrmFGReleaseDossier frmFGReleaseDossier_Obj = null;
        public static FrmFGReleaseDossier GetInstance()
        {
            if (frmFGReleaseDossier_Obj == null)
            {
                frmFGReleaseDossier_Obj = new FrmFGReleaseDossier();
            }
            return frmFGReleaseDossier_Obj;
        }

        private void FrmFGReleaseDossier_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_FormulaNo();
            BtnReset_Click(sender, e);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            cmbFormulaNo.Text = "--Select--";
            Reset();
        }

        public void Reset()
        {
            txtDesc.Clear();
            txtFamily.Clear();
            DtpFDAApproval.Value = Comman_Class_Obj.Select_ServerDate();

            txtOffRefNo.Clear();
            txtOffPIFRef.Clear();
            txtOffKITRef.Clear();

            dgPF.Rows.Clear();

            txtReceivedFrom.Clear();
            txtLotNo.Clear();
            DtpReceivedOn.Value = DtpFDAApproval.Value;
            DtpReceivedOn.Checked = false;
            DtpValidityDate.Value = DtpFDAApproval.Value;
            DtpValidityDate.Checked = false;

            DtpAOCApproval.Value = DtpFDAApproval.Value;
            DtpAOCApproval.Checked = false;
            DtpIntranetRecord.Value = DtpFDAApproval.Value;
            DtpIntranetRecord.Checked = false; 
            DTPFormulationApproval.Value=DtpFDAApproval.Value;
            chkRAD.Checked = false;
            DTPRIApproved.Value = DtpFDAApproval.Value;
            DTPRIApproved.Checked = false;

            dgPFRAD.Rows.Clear();

            txtComments.Clear();
        }

        public void Bind_FormulaNo()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = FormulaNoMaster_Class_Obj.Select_TblBulkMaster();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbFormulaNo.DataSource = ds.Tables[0];
                cmbFormulaNo.DisplayMember = "FormulaNo";
                cmbFormulaNo.ValueMember = "FNo";
            }
        }

        public void AddBulkPFDetails(DataSet dsMfg)
        {
            if (dgPF.Rows.Count == 0)
            {
                DataGridViewComboBoxCell cmb = new DataGridViewComboBoxCell();
                for (int i = 0; i < dsMfg.Tables[0].Rows.Count; i++)
                {
                    cmb.Items.Add(Convert.ToString(dsMfg.Tables[0].Rows[i]["MfgWo"]));
                    cmb.ValueMember = Convert.ToString(dsMfg.Tables[0].Rows[i]["FMID"]);
                }

                dgPF.Rows.Add();
                dgPF["Production", 0].Value = Convert.ToString("First");
                dgPF.Rows[0].Cells["MfgWo"] = cmb;
                dgPF.Rows[0].Cells["MfgWo"].Value = "--Select--";                 
            }
        }

        public void AddbulkPFDetailsRAD(DataSet dsMfg)
        {
            if (dgPFRAD.Rows.Count == 0)
            {
                DataGridViewComboBoxCell cmb;

                dgPFRAD.Rows.Add();
                cmb = new DataGridViewComboBoxCell();
                for (int i = 0; i < dsMfg.Tables[0].Rows.Count; i++)
                {
                    cmb.Items.Add(Convert.ToString(dsMfg.Tables[0].Rows[i]["MfgWo"]));
                    cmb.ValueMember = Convert.ToString(dsMfg.Tables[0].Rows[i]["FMID"]);
                }
                dgPFRAD["RADProduction", dgPFRAD.Rows.Count - 1].Value = Convert.ToString("First");
                dgPFRAD["RADMfgWo", dgPFRAD.Rows.Count - 1] = cmb;
                dgPFRAD["RADMfgWo", dgPFRAD.Rows.Count - 1].Value = "--Select--"; 

                dgPFRAD.Rows.Add();
                cmb = new DataGridViewComboBoxCell();
                for (int i = 0; i < dsMfg.Tables[0].Rows.Count; i++)
                {
                    cmb.Items.Add(Convert.ToString(dsMfg.Tables[0].Rows[i]["MfgWo"]));
                    cmb.ValueMember = Convert.ToString(dsMfg.Tables[0].Rows[i]["FMID"]);
                }
                dgPFRAD["RADProduction", dgPFRAD.Rows.Count - 1].Value = Convert.ToString("Second");
                dgPFRAD["RADMfgWo", dgPFRAD.Rows.Count - 1] = cmb;
                dgPFRAD["RADMfgWo", dgPFRAD.Rows.Count - 1].Value = "--Select--";  

                dgPFRAD.Rows.Add();
                cmb = new DataGridViewComboBoxCell();
                for (int i = 0; i < dsMfg.Tables[0].Rows.Count; i++)
                {
                    cmb.Items.Add(Convert.ToString(dsMfg.Tables[0].Rows[i]["MfgWo"]));
                    cmb.ValueMember = Convert.ToString(dsMfg.Tables[0].Rows[i]["FMID"]);
                }
                dgPFRAD["RADProduction", dgPFRAD.Rows.Count - 1].Value = Convert.ToString("Third");
                dgPFRAD["RADMfgWo", dgPFRAD.Rows.Count - 1] = cmb;
                dgPFRAD["RADMfgWo", dgPFRAD.Rows.Count - 1].Value = "--Select--"; 
            }
        }
       
       

        private void cmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Reset();

            if (cmbFormulaNo.SelectedValue != null && cmbFormulaNo.SelectedValue.ToString() != "")
            {
                //Get the details of the formula
                DataSet ds = new DataSet();
                FormulaNoMaster_Class_Obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue.ToString());
                ds = FormulaNoMaster_Class_Obj.SELECT_TblBulkMaster_tblblkfamilyMaster();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);             
                    txtFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);
                    if (ds.Tables[0].Rows[0]["FDAApprovalDate"] is System.DBNull)
                    {
                        DtpFDAApproval.Value = Comman_Class_Obj.Select_ServerDate();                        
                    }
                    else
                    {
                        DtpFDAApproval.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["FDAApprovalDate"]);
                    }                    
                }

                DataRow dr;                
                FGReleaseDossier_Obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                dsMfg = FGReleaseDossier_Obj.Select_View_BMR_Report_FNo();
                dr = dsMfg.Tables[0].NewRow();
                dr["MfgWo"] = "--Select--";
                dr["FMID"] = "0";
                dsMfg.Tables[0].Rows.InsertAt(dr, 0);

                AddBulkPFDetails(dsMfg);

                DataSet dsFP = new DataSet();
                dsFP = FGReleaseDossier_Obj.Select_tblFPRelease_FNo();
                if (dsFP.Tables[0].Rows.Count > 0)
                {
                    FGReleaseDossier_Obj.fpid = Convert.ToInt64(dsFP.Tables[0].Rows[0]["FPID"]);

                    txtOffRefNo.Text = Convert.ToString(dsFP.Tables[0].Rows[0]["OffRefNo"]);
                    txtOffPIFRef.Text = Convert.ToString(dsFP.Tables[0].Rows[0]["OffPIFRef"]);
                    txtOffKITRef.Text = Convert.ToString(dsFP.Tables[0].Rows[0]["OffKITRef"]);
                    txtReceivedFrom.Text = Convert.ToString(dsFP.Tables[0].Rows[0]["ReceivedFrom"]);
                    txtLotNo.Text = Convert.ToString(dsFP.Tables[0].Rows[0]["LotNo"]);
                    if (dsFP.Tables[0].Rows[0]["ReceivedOn"] is System.DBNull)
                    {
                        
                    }
                    else
                    {
                        DtpReceivedOn.Value = Convert.ToDateTime(dsFP.Tables[0].Rows[0]["ReceivedOn"]);
                    }
                    if (dsFP.Tables[0].Rows[0]["ValidityDate"] is System.DBNull)
                    {
                        
                    }
                    else
                    {
                        DtpValidityDate.Value = Convert.ToDateTime(dsFP.Tables[0].Rows[0]["ValidityDate"]);
                    }
                    if (dsFP.Tables[0].Rows[0]["AOCApprovalDate"] is System.DBNull)
                    {

                    }
                    else
                    {
                        DtpAOCApproval.Value = Convert.ToDateTime(dsFP.Tables[0].Rows[0]["AOCApprovalDate"]);
                    }
                    if (dsFP.Tables[0].Rows[0]["IntranetRecordDate"] is System.DBNull)
                    {

                    }
                    else
                    {
                        DtpIntranetRecord.Value = Convert.ToDateTime(dsFP.Tables[0].Rows[0]["IntranetRecordDate"]);
                    }
                    txtComments.Text = Convert.ToString(dsFP.Tables[0].Rows[0]["Comments"]);

                    if (dsFP.Tables[0].Rows[0]["FormulationApproved"] is System.DBNull)
                    { }
                    else
                        DTPFormulationApproval.Value = Convert.ToDateTime(dsFP.Tables[0].Rows[0]["FormulationApproved"]);
                    if (dsFP.Tables[0].Rows[0]["RandIApprovalDate"] is System.DBNull)
                    { }
                    else
                        DTPRIApproved.Value = Convert.ToDateTime(dsFP.Tables[0].Rows[0]["RandIApprovalDate"]);
                    if (dsFP.Tables[0].Rows[0]["Status"].ToString() == "A")
                        RdoAccepted.Checked = true;
                    else if (dsFP.Tables[0].Rows[0]["Status"].ToString() == "R")
                        RdoRejected.Checked = true;
                    else if (dsFP.Tables[0].Rows[0]["Status"].ToString() == "H")
                        RdoHold.Checked = true;


                    DataSet dsBMR;
                    DataSet dsFPDetails = new DataSet();
                    dsFPDetails = FGReleaseDossier_Obj.Select_tblFPReleaseDetails_FPID();
                    if (dsFPDetails.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsFPDetails.Tables[0].Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dsFPDetails.Tables[0].Rows[i]["RAD"]) == false)
                            {
                                dgPF["MfgWo", 0].Value = Convert.ToString(dsFPDetails.Tables[0].Rows[i]["MfgWo"]);

                                dsBMR = new DataSet();
                                FGReleaseDossier_Obj.mfgwo = Convert.ToString(dsFPDetails.Tables[0].Rows[i]["MfgWo"]);
                                dsBMR = FGReleaseDossier_Obj.Select_View_BMR_Report_BulkPFDetails();
                                if (dsBMR.Tables[0].Rows.Count > 0)
                                {
                                    dgPF["FMID", 0].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["FMID"]);
                                    dgPF["MfgDate", 0].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["Completedon"]).ToShortDateString();
                                    dgPF["BatchSize", 0].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["BatchSize"]);
                                    dgPF["DateOfPFProduction", 0].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["FillDate"]).ToShortDateString();
                                    dgPF["NoOfPFUnits", 0].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["PFUnits"]);
                                    dgPF["FGCode", 0].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["FGCode"]);
                                }   
                            }
                            else if (Convert.ToBoolean(dsFPDetails.Tables[0].Rows[i]["RAD"]) == true)
                            {
                                chkRAD.Checked = true;

                                if (Convert.ToChar(dsFPDetails.Tables[0].Rows[i]["Production"]) == 'F')
                                {
                                    dgPFRAD["RADMfgWo", 0].Value = Convert.ToString(dsFPDetails.Tables[0].Rows[i]["MfgWo"]);

                                    dsBMR = new DataSet();
                                    FGReleaseDossier_Obj.mfgwo = Convert.ToString(dsFPDetails.Tables[0].Rows[i]["MfgWo"]);
                                    dsBMR = FGReleaseDossier_Obj.Select_View_BMR_Report_BulkPFDetails();
                                    if (dsBMR.Tables[0].Rows.Count > 0)
                                    {
                                        dgPFRAD["RADFMID", 0].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["FMID"]);
                                        dgPFRAD["RADMfgDate", 0].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["Completedon"]).ToShortDateString();
                                        dgPFRAD["RADBatchSize", 0].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["BatchSize"]);
                                        dgPFRAD["RADDateOfPFProduction", 0].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["FillDate"]).ToShortDateString();
                                        dgPFRAD["RADNoOfPFUnits", 0].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["PFUnits"]);
                                        dgPFRAD["RADFGCode", 0].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["FGCode"]);
                                    }
                                }
                                else if (Convert.ToChar(dsFPDetails.Tables[0].Rows[i]["Production"]) == 'S')
                                {
                                    dgPFRAD["RADMfgWo", 1].Value = Convert.ToString(dsFPDetails.Tables[0].Rows[i]["MfgWo"]);

                                    dsBMR = new DataSet();
                                    FGReleaseDossier_Obj.mfgwo = Convert.ToString(dsFPDetails.Tables[0].Rows[i]["MfgWo"]);
                                    dsBMR = FGReleaseDossier_Obj.Select_View_BMR_Report_BulkPFDetails();
                                    if (dsBMR.Tables[0].Rows.Count > 0)
                                    {
                                        dgPFRAD["RADFMID", 1].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["FMID"]);
                                        dgPFRAD["RADMfgDate", 1].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["Completedon"]).ToShortDateString();
                                        dgPFRAD["RADBatchSize", 1].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["BatchSize"]);
                                        dgPFRAD["RADDateOfPFProduction", 1].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["FillDate"]).ToShortDateString();
                                        dgPFRAD["RADNoOfPFUnits", 1].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["PFUnits"]);
                                        dgPFRAD["RADFGCode", 1].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["FGCode"]);
                                    }
                                }
                                else if (Convert.ToChar(dsFPDetails.Tables[0].Rows[i]["Production"]) == 'T')
                                {
                                    dgPFRAD["RADMfgWo", 2].Value = Convert.ToString(dsFPDetails.Tables[0].Rows[i]["MfgWo"]);

                                    dsBMR = new DataSet();
                                    FGReleaseDossier_Obj.mfgwo = Convert.ToString(dsFPDetails.Tables[0].Rows[i]["MfgWo"]);
                                    dsBMR = FGReleaseDossier_Obj.Select_View_BMR_Report_BulkPFDetails();
                                    if (dsBMR.Tables[0].Rows.Count > 0)
                                    {
                                        dgPFRAD["RADFMID", 2].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["FMID"]);
                                        dgPFRAD["RADMfgDate", 2].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["Completedon"]).ToShortDateString();
                                        dgPFRAD["RADBatchSize", 2].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["BatchSize"]);
                                        dgPFRAD["RADDateOfPFProduction", 2].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["FillDate"]).ToShortDateString();
                                        dgPFRAD["RADNoOfPFUnits", 2].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["PFUnits"]);
                                        dgPFRAD["RADFGCode", 2].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["FGCode"]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        ComboBox cmb;
        private void dgPF_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgPF.CurrentCell.RowIndex < 0 || dgPF.CurrentCell.ColumnIndex != dgPF.Columns["MfgWo"].Index)
            {
                return;
            }
            else
            {
                cmb = (ComboBox)e.Control;
                cmb.SelectionChangeCommitted +=new EventHandler(cmb_SelectionChangeCommitted);
            }
        }

        private void cmb_SelectionChangeCommitted(object Sender, EventArgs e)
        {
            dgPF["FMID", dgPF.CurrentCell.RowIndex].Value = "";
            dgPF["MfgDate", dgPF.CurrentCell.RowIndex].Value = "";
            dgPF["BatchSize", dgPF.CurrentCell.RowIndex].Value = "";
            dgPF["DateOfPFProduction", dgPF.CurrentCell.RowIndex].Value = "";
            dgPF["NoOfPFUnits", dgPF.CurrentCell.RowIndex].Value = "";
            dgPF["FGCode", dgPF.CurrentCell.RowIndex].Value = "";

            if (cmb.Text != "--Select--")
            {
                DataSet dsBMR = new DataSet();
                FGReleaseDossier_Obj.mfgwo = Convert.ToString(cmb.Text.Trim());
                dsBMR = FGReleaseDossier_Obj.Select_View_BMR_Report_BulkPFDetails();
                if (dsBMR.Tables[0].Rows.Count > 0)
                {
                    dgPF["FMID", dgPF.CurrentCell.RowIndex].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["FMID"]);
                    dgPF["MfgDate", dgPF.CurrentCell.RowIndex].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["Completedon"]).ToShortDateString();
                    dgPF["BatchSize", dgPF.CurrentCell.RowIndex].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["BatchSize"]);
                    dgPF["DateOfPFProduction", dgPF.CurrentCell.RowIndex].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["FillDate"]).ToShortDateString();
                    dgPF["NoOfPFUnits", dgPF.CurrentCell.RowIndex].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["PFUnits"]);
                    dgPF["FGCode", dgPF.CurrentCell.RowIndex].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["FGCode"]);
                }                                
            }
        }

        ComboBox cmbRAD;
        private void dgPFRAD_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgPFRAD.CurrentCell.RowIndex < 0 || dgPFRAD.CurrentCell.ColumnIndex != dgPFRAD.Columns["RADMfgWo"].Index)
            {
                return;
            }
            else
            {
                cmbRAD = (ComboBox)e.Control;
                cmbRAD.SelectionChangeCommitted += new EventHandler(cmbRAD_SelectionChangeCommitted);
            }
        }

        private void cmbRAD_SelectionChangeCommitted(object Sender, EventArgs e)
        {
            dgPFRAD["RADFMID", dgPFRAD.CurrentCell.RowIndex].Value = "";
            dgPFRAD["RADMfgDate", dgPFRAD.CurrentCell.RowIndex].Value = "";
            dgPFRAD["RADBatchSize", dgPFRAD.CurrentCell.RowIndex].Value = "";
            dgPFRAD["RADDateOfPFProduction", dgPFRAD.CurrentCell.RowIndex].Value = "";
            dgPFRAD["RADNoOfPFUnits", dgPFRAD.CurrentCell.RowIndex].Value = "";
            dgPFRAD["RADFGCode", dgPFRAD.CurrentCell.RowIndex].Value = "";


            if (cmbRAD.Text != "--Select--")
            {
                DataSet dsBMR = new DataSet();
                FGReleaseDossier_Obj.mfgwo = Convert.ToString(cmbRAD.Text.Trim());
                dsBMR = FGReleaseDossier_Obj.Select_View_BMR_Report_BulkPFDetails();
                if (dsBMR.Tables[0].Rows.Count > 0)
                {
                    dgPFRAD["RADFMID", dgPFRAD.CurrentCell.RowIndex].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["FMID"]);
                    dgPFRAD["RADMfgDate", dgPFRAD.CurrentCell.RowIndex].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["Completedon"]).ToShortDateString();
                    dgPFRAD["RADBatchSize", dgPFRAD.CurrentCell.RowIndex].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["BatchSize"]);
                    dgPFRAD["RADDateOfPFProduction", dgPFRAD.CurrentCell.RowIndex].Value = Convert.ToDateTime(dsBMR.Tables[0].Rows[0]["FillDate"]).ToShortDateString();
                    dgPFRAD["RADNoOfPFUnits", dgPFRAD.CurrentCell.RowIndex].Value = Convert.ToInt64(dsBMR.Tables[0].Rows[0]["PFUnits"]);
                    dgPFRAD["RADFGCode", dgPFRAD.CurrentCell.RowIndex].Value = Convert.ToString(dsBMR.Tables[0].Rows[0]["FGCode"]);
                }               
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

        private void chkRAD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRAD.Checked == true)
            {
                AddbulkPFDetailsRAD(dsMfg);
                DTPRIApproved.Checked = true;
            }
            else if(chkRAD.Checked == false)
            {
                dgPFRAD.Rows.Clear();
                DTPRIApproved.Checked = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFormulaNo.SelectedValue == null || cmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula No", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    cmbFormulaNo.Focus();
                    return;
                }
                if (dgPF["FMID", 0].Value == null || Convert.ToString(dgPF["FMID", 0].Value) == "")
                {
                    MessageBox.Show("Select Bulk PF Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    dgPF["MfgWO", 0].Selected = true;
                    return;
                }
                if (chkRAD.Checked == true)
                {
                    if (DTPRIApproved.Checked == true)
                    { }
                    else
                    {
                        MessageBox.Show("Select R&I Approval Date", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        DTPRIApproved.Focus();
                        return;
                    }
                       
                }
                if (chkRAD.Checked == true)
                {
                    bool b = false;
                    for (int i = 0; i < dgPFRAD.Rows.Count;i++)
                    {
                        if (dgPFRAD["RADFMID", i].Value != null && Convert.ToString(dgPFRAD["RADFMID", i].Value) != "")
                        {
                            b = true;
                            break;
                        }
                    }
                    if (b == false)
                    {
                        MessageBox.Show("Select RAD Bulk PF Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        dgPFRAD["RADMfgWO", 0].Selected = true;
                        return;
                    }
                }

                FGReleaseDossier_Obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                FGReleaseDossier_Obj.offrefno = txtOffRefNo.Text.Trim();
                FGReleaseDossier_Obj.offpifref = txtOffPIFRef.Text.Trim();
                FGReleaseDossier_Obj.offkitref = txtOffKITRef.Text.Trim();
                FGReleaseDossier_Obj.receivedfrom = txtReceivedFrom.Text.Trim();
                FGReleaseDossier_Obj.lotno = txtLotNo.Text.Trim();
                if (DtpReceivedOn.Checked == true)
                {
                    FGReleaseDossier_Obj.receivedon = DtpReceivedOn.Value.ToShortDateString();
                }
                else
                {
                    FGReleaseDossier_Obj.receivedon = null;
                }
                if (DtpValidityDate.Checked == true)
                {
                    FGReleaseDossier_Obj.validitydate = DtpValidityDate.Value.ToShortDateString();
                }
                else
                {
                    FGReleaseDossier_Obj.validitydate = null;
                }
                if (DtpAOCApproval.Checked == true)
                {
                    FGReleaseDossier_Obj.aocapprovaldate = DtpAOCApproval.Value.ToShortDateString();
                }
                else
                {
                    FGReleaseDossier_Obj.aocapprovaldate = null;
                }
                if (DtpIntranetRecord.Checked == true)
                {
                    FGReleaseDossier_Obj.intranetrecorddate = DtpIntranetRecord.Value.ToShortDateString();
                }
                else
                {
                    FGReleaseDossier_Obj.intranetrecorddate = null;
                }
                FGReleaseDossier_Obj.comments = txtComments.Text.Trim();
                FGReleaseDossier_Obj.loginid = Convert.ToInt32(FrmMain.LoginID);

                FGReleaseDossier_Obj.FormulationApproved = DTPFormulationApproval.Value.ToShortDateString();
                if (chkRAD.Checked == true)
                    FGReleaseDossier_Obj.RandI = true;
                else
                    FGReleaseDossier_Obj.RandI = false;
                if (DTPRIApproved.Checked == true)
                    FGReleaseDossier_Obj.RandIApprovalDate = DTPRIApproved.Value.ToShortDateString();
                else
                    FGReleaseDossier_Obj.RandIApprovalDate = null;
                if (RdoAccepted.Checked == true)
                    FGReleaseDossier_Obj.Status = 'A';
                else if (RdoRejected.Checked == true)
                    FGReleaseDossier_Obj.Status = 'R';
                else if (RdoHold.Checked == true)
                    FGReleaseDossier_Obj.Status = 'H';

                DataSet ds = new DataSet();
                ds = FGReleaseDossier_Obj.Select_tblFPRelease_FNo();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (MessageBox.Show("Record for this FormulaNo already exists.\nModify","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }

                    FGReleaseDossier_Obj.fpid = Convert.ToInt64(ds.Tables[0].Rows[0]["FPID"]);
                    FGReleaseDossier_Obj.Update_tblFPRelease();
                }
                else
                {
                    FGReleaseDossier_Obj.fpid = FGReleaseDossier_Obj.Insert_tblFPRelease();
                }

                FGReleaseDossier_Obj.Delete_tblFPReleaseDetails();

                for (int i = 0; i < dgPF.Rows.Count; i++)
                {
                    FGReleaseDossier_Obj.rad = false;

                    if (dgPF["FMID", i].Value != null && Convert.ToString(dgPF["FMID", i].Value) != "")
                    {
                        FGReleaseDossier_Obj.fmid = Convert.ToInt64(dgPF["FMID", i].Value);

                        if (Convert.ToString(dgPF["Production", i].Value) == "First")
                        {
                            FGReleaseDossier_Obj.production = 'F';
                        }                        

                        FGReleaseDossier_Obj.Insert_tblFPReleaseDetails();
                    }
                }

                if (chkRAD.Checked == true)
                {
                    for (int i = 0; i < dgPFRAD.Rows.Count; i++)
                    {
                        FGReleaseDossier_Obj.rad = true;

                        if (dgPFRAD["RADFMID", i].Value != null && Convert.ToString(dgPFRAD["RADFMID", i].Value) != "")
                        {
                            FGReleaseDossier_Obj.fmid = Convert.ToInt64(dgPFRAD["RADFMID", i].Value);

                            if (Convert.ToString(dgPFRAD["RADProduction", i].Value) == "First")
                            {
                                FGReleaseDossier_Obj.production = 'F';
                            }
                            else if (Convert.ToString(dgPFRAD["RADProduction", i].Value) == "Second")
                            {
                                FGReleaseDossier_Obj.production = 'S';
                            }
                            else if (Convert.ToString(dgPFRAD["RADProduction", i].Value) == "Third")
                            {
                                FGReleaseDossier_Obj.production = 'T';
                            }

                            FGReleaseDossier_Obj.Insert_tblFPReleaseDetails();
                        }
                    }
                }

                MessageBox.Show("Record saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                BtnReset_Click(sender, e);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFormulaNo.SelectedValue == null || cmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula No", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                    cmbFormulaNo.Focus();
                    return;
                }

                if (MessageBox.Show("Delete this record?","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    FGReleaseDossier_Obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                    bool b = FGReleaseDossier_Obj.Delete_tblFPRelease();
                    if (b == true)
                    {
                        MessageBox.Show("Record deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                        BtnReset_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

          
    }
}